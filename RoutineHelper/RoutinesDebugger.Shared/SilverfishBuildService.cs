using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Security.Cryptography;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using Microsoft.CodeAnalysis.Text;
using RoutineHelper;

namespace RoutinesDebugger.Shared;

public static class SilverfishBuildService
{

    public static CompilerResults Compile(string silverfishPath, string outputAssemblyPath, string logPath)
    {
        string key = Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(Path.GetFullPath(outputAssemblyPath).ToUpperInvariant())));
        using var mutex = new Mutex(false, "Local\\RoutinesDebugger_" + key);
        try { mutex.WaitOne(); }
        catch (AbandonedMutexException) { }
        try { return CompileCore(silverfishPath, outputAssemblyPath, logPath); }
        finally { mutex.ReleaseMutex(); }
    }

    private static CompilerResults CompileCore(string silverfishPath, string outputAssemblyPath, string logPath)
    {
		CompilerResults compilerResults = new CompilerResults(new TempFileCollection());
        string temporaryDirectory = null;
		try
		{
			Directory.CreateDirectory(Path.GetDirectoryName(Path.GetFullPath(logPath)));
			string fullPath = Path.GetFullPath(silverfishPath);
			string fullPath2 = Path.GetFullPath(outputAssemblyPath);
			string text = Path.GetDirectoryName(fullPath2) ?? AppDomain.CurrentDomain.BaseDirectory;
			string text2 = RuntimeDependencies.ResolveDirectory(fullPath);
			string text3 = Path.ChangeExtension(fullPath2, ".pdb");
			ValidateSilverfishLayout(fullPath);
			Directory.CreateDirectory(text);

			string path = temporaryDirectory = PrepareTempBuildRoot(text);
			string text4 = Path.Combine(path, "CompatStubs.cs");
			File.WriteAllText(text4, BuildCompatStubs(fullPath), Encoding.UTF8);
			List<string> list = BuildSourceFileList(fullPath, text4);
			List<MetadataReference> list2 = BuildMetadataReferences(text2, logPath);
			CSharpParseOptions options = new CSharpParseOptions(LanguageVersion.Preview, DocumentationMode.Parse, SourceCodeKind.Regular, new string[1] { "APPLICATION_MODE" });
			List<SyntaxTree> list3 = new List<SyntaxTree>(list.Count);
			foreach (string item in list)
			{
				list3.Add(CSharpSyntaxTree.ParseText(ReadSourceText(item), options, item));
			}
            CSharpCompilationOptions options2 = new CSharpCompilationOptions(
                OutputKind.DynamicallyLinkedLibrary,
                optimizationLevel: OptimizationLevel.Debug,
                allowUnsafe: true,
                platform: Platform.X64,
                concurrentBuild: true,
                assemblyIdentityComparer: DesktopAssemblyIdentityComparer.Default);
			CSharpCompilation cSharpCompilation = CSharpCompilation.Create(Path.GetFileNameWithoutExtension(fullPath2), list3, list2, options2);
			File.AppendAllText(logPath, $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] roslyn compile start{Environment.NewLine}" + "silverfishPath=" + fullPath + Environment.NewLine + "runtimeDir=" + text2 + Environment.NewLine + "outputAssembly=" + fullPath2 + Environment.NewLine + "pdbPath=" + text3 + Environment.NewLine + $"sourceFiles={list.Count}{Environment.NewLine}" + $"references={list2.Count}{Environment.NewLine}");
			EmitResult emitResult;
			string temporaryAssembly = Path.Combine(path, "Silverfish.dll");
            using (FileStream peStream = new FileStream(temporaryAssembly, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                emitResult = cSharpCompilation.Emit(peStream, options: new EmitOptions(debugInformationFormat: DebugInformationFormat.Embedded));
            }

			StringBuilder stringBuilder = new StringBuilder();
			foreach (Diagnostic item2 in emitResult.Diagnostics.OrderBy(GetDiagnosticSortKey))
			{
				CompilerError compilerError = AddDiagnostic(compilerResults, item2);
				if (compilerError != null)
				{
					stringBuilder.AppendLine(compilerError.ToString());
				}
			}
			if (stringBuilder.Length > 0)
			{
				File.AppendAllText(logPath, stringBuilder.ToString());
			}
			if (emitResult.Success)
			{
				File.Delete(text3);
				File.Move(temporaryAssembly, fullPath2, true);
				compilerResults.PathToAssembly = fullPath2;
			}
			else
			{

				if (compilerResults.Errors.Count == 0)
				{
					compilerResults.Errors.Add(new CompilerError
					{
						ErrorNumber = "BUILD",
						ErrorText = "Roslyn emit failed."
					});
				}
			}
			File.AppendAllText(logPath, $"emitSuccess={emitResult.Success}{Environment.NewLine}" + $"outputExists={File.Exists(fullPath2)}{Environment.NewLine}" + $"parsedDiagnostics={compilerResults.Errors.Count}{Environment.NewLine}");
		}
		catch (Exception ex)
		{
			try { File.AppendAllText(logPath, "exception=" + ex + Environment.NewLine); }
            catch (IOException) { }
            catch (UnauthorizedAccessException) { }
			compilerResults.Errors.Add(new CompilerError
			{
				ErrorNumber = "EXCEPTION",
				ErrorText = ex is FileNotFoundException missing ? ex.Message + " " + missing.FileName : ex.Message
			});
		}
        finally
        {
            if (temporaryDirectory != null)
            {
                try
                {
                    Directory.Delete(temporaryDirectory, recursive: true);
                }
                catch (IOException) { }
                catch (UnauthorizedAccessException) { }
            }
        }
		return compilerResults;
	}

	private static int GetDiagnosticSortKey(Diagnostic diagnostic)
	{
		if (diagnostic.Severity == DiagnosticSeverity.Error)
		{
			return 0;
		}
		if (diagnostic.Severity == DiagnosticSeverity.Warning)
		{
			return 1;
		}
		return 2;
	}

	private static CompilerError AddDiagnostic(CompilerResults results, Diagnostic diagnostic)
	{
		if (diagnostic.Severity == DiagnosticSeverity.Hidden || diagnostic.Severity == DiagnosticSeverity.Info)
		{
			return null;
		}
		string fileName = string.Empty;
		int line = 0;
		int column = 0;
		if (diagnostic.Location != Location.None && diagnostic.Location.IsInSource)
		{
			FileLinePositionSpan lineSpan = diagnostic.Location.GetLineSpan();
			fileName = lineSpan.Path ?? string.Empty;
			line = lineSpan.StartLinePosition.Line + 1;
			column = lineSpan.StartLinePosition.Character + 1;
		}
		CompilerError compilerError = new CompilerError(fileName, line, column, diagnostic.Id, diagnostic.GetMessage());
		compilerError.IsWarning = diagnostic.Severity != DiagnosticSeverity.Error;
		results.Errors.Add(compilerError);
		return compilerError;
	}

	private static void ValidateSilverfishLayout(string silverfishPath)
	{
		if (!Directory.Exists(silverfishPath))
		{
			throw new DirectoryNotFoundException("Silverfish directory not found: " + silverfishPath);
		}
	}

	private static List<string> BuildSourceFileList(string silverfishPath, string compatStubPath)
	{
		List<string> list = Directory.EnumerateFiles(silverfishPath, "*.cs", SearchOption.AllDirectories)
            .Where(file => !Path.GetRelativePath(silverfishPath, file).Split(Path.DirectorySeparatorChar)
                .Any(part => part is "obj" or "bin" or "_tempbuild"))
            .OrderBy(file => file, StringComparer.OrdinalIgnoreCase).ToList();
		string fullPath = Path.GetFullPath(Path.Combine(silverfishPath, ".."));
		string text = Path.Combine(fullPath, "CardSpecialHandlingLists.cs");
		if (File.Exists(text))
		{
			list.Add(text);
		}
		string fullPath2 = Path.GetFullPath(Path.Combine(silverfishPath, "..", "silverfish_HB.cs"));
		if (!File.Exists(fullPath2))
		{
			throw new FileNotFoundException("silverfish_HB.cs not found", fullPath2);
		}
		list.Add(fullPath2);
		list.Add(compatStubPath);
		return list.Distinct(StringComparer.OrdinalIgnoreCase).ToList();
	}

	private static List<MetadataReference> BuildMetadataReferences(string runtimeDir, string logPath)
	{
		List<MetadataReference> list = new List<MetadataReference>();
		HashSet<string> seenPaths = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
		foreach (string item in EnumerateFrameworkReferencePaths().Concat(RuntimeDependencies.GetReferencePaths(runtimeDir)).Append(typeof(SilverfishBuildService).Assembly.Location))
		{
			TryAddMetadataReference(list, seenPaths, item, logPath);
		}
		return list;
	}

    private static IEnumerable<string> EnumerateFrameworkReferencePaths()
    {
        // Use the running .NET runtime and WPF assemblies, including type-forwarding facades.
        return ((string)AppContext.GetData("TRUSTED_PLATFORM_ASSEMBLIES"))
            .Split(Path.PathSeparator);
    }

	private static void TryAddMetadataReference(List<MetadataReference> references, HashSet<string> seenPaths, string referencePath, string logPath)
	{
		if (string.IsNullOrWhiteSpace(referencePath) || !File.Exists(referencePath))
		{
			return;
		}
		string fullPath;
		try
		{
			fullPath = Path.GetFullPath(referencePath);
		}
		catch
		{
			return;
		}
		if (!seenPaths.Add(fullPath))
		{
			return;
		}
		try
		{
			AssemblyName.GetAssemblyName(fullPath);
			references.Add(MetadataReference.CreateFromFile(fullPath));
		}
		catch (Exception ex)
		{
			File.AppendAllText(logPath, "[reference-skip] " + fullPath + " :: " + ex.Message + Environment.NewLine);
		}
	}

	private static SourceText ReadSourceText(string path)
	{
		using FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
		using StreamReader streamReader = new StreamReader(stream, Encoding.UTF8, detectEncodingFromByteOrderMarks: true);
		string text = streamReader.ReadToEnd();
		text = NormalizeSourceForEditorCompile(text);
		return SourceText.From(text, streamReader.CurrentEncoding ?? Encoding.UTF8);
	}

	private static string NormalizeSourceForEditorCompile(string text)
	{
		if (string.IsNullOrEmpty(text))
		{
			return text;
		}
		if (!text.Contains("using System.Linq;") && (text.Contains(".FirstOrDefault(") || text.Contains(".Where(") || text.Contains(".Any(") || text.Contains(".ToArray(") || text.Contains(".Count(")))
		{
			text = "using System.Linq;" + Environment.NewLine + "#line 1" + Environment.NewLine + text;
		}
		// Legacy kernels call the editor directly. CLI replay has no main window.
        text = text.Replace("(Application.Current.MainWindow as MainWindow).BestScore = bestval;",
            "if (Application.Current?.MainWindow is MainWindow editorWindow) editorWindow.BestScore = bestval;");
        text = text.Replace("(Application.Current.MainWindow as MainWindow).",
            "(Application.Current?.MainWindow as MainWindow)?.");
        return text;
    }

    private static string PrepareTempBuildRoot(string outputDirectory)
    {
        string buildDirectory = Path.Combine(outputDirectory, "_tempbuild", "SilverfishProject_" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(buildDirectory);
        return buildDirectory;
    }

    private static string BuildCompatStubs(string silverfishPath)
    {
        string stubs = @"namespace Triton.Bot.Logic.Bots.DefaultBot
{
    public sealed class DefaultBotSettings
    {
        public static DefaultBotSettings Instance { get; } = new DefaultBotSettings();
        public long LastDeckId { get; set; }
    }
}
namespace HREngine.Bots
{
    public sealed class DefaultRoutineSettings
    {
        public static DefaultRoutineSettings Instance { get; } = new DefaultRoutineSettings();
        public int MaxWide { get; set; } = 3000;
    }
}";
        // Recent distributions removed the offline test harness from the routine tree.
        if (!File.Exists(Path.Combine(silverfishPath, "Test", "TestBase.cs")))
        {
            stubs += @"
namespace HREngine.Bots
{
    public class TestBase
    {
        public void InitSetting()
        {
            Settings.Instance.writeToSingleFile = true;
            if (Hrtprozis.Instance.settings == null)
            {
                Hrtprozis.Instance.setInstances();
                ComboBreaker.Instance.setInstances();
                PenalityManager.Instance.setInstances();
            }
        }
    }
}";
        }
        return stubs;
    }
}
