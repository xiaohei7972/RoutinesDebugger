using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using SilverfishWrapper;

namespace RoutineHelper;

public static class RoutineRuntime
{
	public static string RoutineXmlPath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Settings\\Default\\routine.xml");

	public static bool TryResolveDefaultRoutinePath(out string routinePath)
	{
		XmlConfigUtil xmlConfigUtil = new XmlConfigUtil(RoutineXmlPath);
		foreach (string item in EnumerateDefaultRoutineCandidates(xmlConfigUtil))
		{
			string text = NormalizeDefaultRoutinePath(item);
			if (!string.IsNullOrWhiteSpace(text))
			{
				try
				{
					xmlConfigUtil.Write(text, "RoutinePath");
					xmlConfigUtil.Write(Path.Combine(text, "Silverfish"), "SilverfishPath");
				}
				catch
				{
				}
				routinePath = text;
				return true;
			}
		}
		routinePath = null;
		return false;
	}

	public static bool TryResolveSilverfishPath(out string silverfishPath)
	{
		if (!TryResolveDefaultRoutinePath(out var routinePath))
		{
			silverfishPath = null;
			return false;
		}
		silverfishPath = NormalizeSilverfishPath(routinePath);
		return !string.IsNullOrWhiteSpace(silverfishPath);
	}

	public static string NormalizeDefaultRoutinePath(string path)
	{
		if (string.IsNullOrWhiteSpace(path))
		{
			return null;
		}
		try
		{
			string fullPath = Path.GetFullPath(path);
			if (IsDefaultRoutineDirectory(fullPath))
			{
				return fullPath;
			}
			if (IsSilverfishDirectory(fullPath))
			{
				string directoryName = Path.GetDirectoryName(fullPath);
				if (IsDefaultRoutineDirectory(directoryName))
				{
					return directoryName;
				}
			}
		}
		catch
		{
		}
		return null;
	}

	private static IEnumerable<string> EnumerateDefaultRoutineCandidates(XmlConfigUtil util)
	{
		string[] array = new string[5]
		{
			util.Read("RoutinePath"),
			util.Read("SilverfishPath"),
			Environment.GetEnvironmentVariable("HB_DEFAULTROUTINE_PATH"),
			Environment.GetEnvironmentVariable("HB_SILVERFISH_PATH"),
			Environment.GetEnvironmentVariable("ROUTINEHELPER_DEFAULTROUTINE_PATH")
		};
		foreach (string candidate in array)
		{
			if (!string.IsNullOrWhiteSpace(candidate))
			{
				yield return candidate;
			}
		}
		foreach (string item in DiscoverPortableDefaultRoutineCandidates(AppDomain.CurrentDomain.BaseDirectory))
		{
			yield return item;
		}
	}

	private static IEnumerable<string> DiscoverPortableDefaultRoutineCandidates(string startDirectory)
	{
		HashSet<string> seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
		DirectoryInfo current = new DirectoryInfo(Path.GetFullPath(startDirectory));
		int depth = 0;
		while (current != null && depth < 6)
		{
			string[] array = new string[9]
			{
				current.FullName,
				Path.Combine(current.FullName, "DefaultRoutine"),
				Path.Combine(current.FullName, "Routines", "DefaultRoutine"),
				Path.Combine(current.FullName, "Build", "bin", "x86", "Debug", "net472", "Routines", "DefaultRoutine"),
				Path.Combine(current.FullName, "Build", "bin", "Debug", "net472", "Routines", "DefaultRoutine"),
				Path.Combine(current.FullName, "bin", "x86", "Debug", "net472", "Routines", "DefaultRoutine"),
				Path.Combine(current.FullName, "bin", "Debug", "net472", "Routines", "DefaultRoutine"),
				Path.Combine(current.FullName, "Silverfish"),
				Path.Combine(current.FullName, "Routines", "DefaultRoutine", "Silverfish")
			};
			foreach (string candidate in array)
			{
				if (!string.IsNullOrWhiteSpace(candidate) && seen.Add(candidate))
				{
					yield return candidate;
				}
			}
			depth++;
			current = current.Parent;
		}
	}

	public static string NormalizeSilverfishPath(string path)
	{
		if (string.IsNullOrWhiteSpace(path))
		{
			return null;
		}
		try
		{
			string fullPath = Path.GetFullPath(path);
			if (IsSilverfishDirectory(fullPath))
			{
				return fullPath;
			}
			string text = Path.Combine(fullPath, "Silverfish");
			if (IsSilverfishDirectory(text))
			{
				return text;
			}
		}
		catch
		{
		}
		return null;
	}

	public static string GetTestDataDirectory(string silverfishPath)
	{
        string runtimeDirectory = Path.GetFullPath(Path.Combine(silverfishPath, "..", "..", ".."));
        string modernLogDirectory = Path.Combine(runtimeDirectory, "Logs", "Data");
        string boardRecordDirectory = Path.Combine(modernLogDirectory, "对局记录");
        if (Directory.Exists(boardRecordDirectory))
            return boardRecordDirectory;
        return Directory.Exists(modernLogDirectory)
            ? modernLogDirectory
            : Path.Combine(silverfishPath, "Test", "Data");
	}

    internal static IEnumerable<FileInfo> EnumerateTestFiles(string silverfishPath)
    {
        var options = new EnumerationOptions { RecurseSubdirectories = true, IgnoreInaccessible = true };
        return new[] { GetTestDataDirectory(silverfishPath), Path.Combine(silverfishPath, "Test") }
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .Where(Directory.Exists)
            .SelectMany(directory => new DirectoryInfo(directory).EnumerateFiles("*.txt", options))
            .DistinctBy(file => file.FullName, StringComparer.OrdinalIgnoreCase);
    }

    public static string FindMostRecentTestFile(string silverfishPath)
    {
        return EnumerateTestFiles(silverfishPath)
            .OrderByDescending(file => file.LastWriteTimeUtc)
            .ThenBy(file => file.FullName, StringComparer.OrdinalIgnoreCase)
            .FirstOrDefault()?.FullName;
    }

	public static void ApplySettingsToWrapper()
	{
		if (TryResolveSilverfishPath(out var silverfishPath))
		{
			XmlConfigUtil xmlConfigUtil = new XmlConfigUtil(RoutineXmlPath);
			string text = NormalizeSilverfishPath(silverfishPath);
			Settings settings = new Settings(Settings.Instance);
			string value = NormalizeDefaultRoutinePath(silverfishPath);
			settings.mainPath = Path.TrimEndingDirectorySeparator(text) + Path.DirectorySeparatorChar;
			settings.logpath = Path.Combine(AppContext.BaseDirectory, "Logs") + Path.DirectorySeparatorChar;
            Directory.CreateDirectory(settings.logpath);
			settings.path = Path.Combine(text, "data") + Path.DirectorySeparatorChar;
			if (!string.IsNullOrWhiteSpace(value))
			{
				xmlConfigUtil.Write(value, "RoutinePath");
			}
			xmlConfigUtil.Write(text, "SilverfishPath");
		}
	}

	public static string GetCompiledAssemblyPath()
	{
		return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CompiledAssemblies", "Silverfish.dll");
	}

    internal static bool IsCompiledKernelUsable(string assemblyPath)
    {
        if (!File.Exists(assemblyPath)) return false;
        try
        {
            using var stream = File.OpenRead(assemblyPath);
            using var reader = new PEReader(stream);
            if (!reader.HasMetadata || reader.PEHeaders.CoffHeader.Machine != Machine.Amd64) return false;
            MetadataReader metadata = reader.GetMetadataReader();
            return metadata.IsAssembly && metadata.GetString(metadata.GetAssemblyDefinition().Name) == "Silverfish"
                && !metadata.AssemblyReferences.Any(reference =>
                    metadata.GetString(metadata.GetAssemblyReference(reference).Name) == "RoutineHelper");
        }
        catch (Exception exception) when (exception is IOException or UnauthorizedAccessException or BadImageFormatException)
        {
            return false;
        }
    }

	public static Assembly LoadCompiledRoutinesOrThrow()
	{
		string compiledAssemblyPath = GetCompiledAssemblyPath();
		if (!File.Exists(compiledAssemblyPath))
		{
			throw new FileNotFoundException("未找到已编译的 Silverfish.dll", compiledAssemblyPath);
		}
        string symbolsPath = Path.ChangeExtension(compiledAssemblyPath, ".pdb");
        byte[] assemblyBytes = File.ReadAllBytes(compiledAssemblyPath);
        return File.Exists(symbolsPath)
            ? Assembly.Load(assemblyBytes, File.ReadAllBytes(symbolsPath))
            : Assembly.Load(assemblyBytes);
	}

	public static void InitializeWrapperTypes(Assembly compiledRoutines)
	{
		SilverfishWrapper.Action.Type = compiledRoutines.GetType("HREngine.Bots.Action", throwOnError: true);
		Ai.Type = compiledRoutines.GetType("HREngine.Bots.Ai", throwOnError: true);
		Card.Type = compiledRoutines.GetType("HREngine.Bots.CardDB+Card", throwOnError: true);
		CardDB.Type = compiledRoutines.GetType("HREngine.Bots.CardDB", throwOnError: true);
		Handcard.Type = compiledRoutines.GetType("HREngine.Bots.Handmanager+Handcard", throwOnError: true);
		Hrtprozis.Type = compiledRoutines.GetType("HREngine.Bots.Hrtprozis", throwOnError: true);
		Minion.Type = compiledRoutines.GetType("HREngine.Bots.Minion", throwOnError: true);
		Playfield.Type = compiledRoutines.GetType("HREngine.Bots.Playfield", throwOnError: true);
		QuestItem.Type = compiledRoutines.GetType("HREngine.Bots.Questmanager+QuestItem", throwOnError: true);
		SecretItem.Type = compiledRoutines.GetType("HREngine.Bots.SecretItem", throwOnError: true);
		Settings.Type = compiledRoutines.GetType("HREngine.Bots.Settings", throwOnError: true);
		TestBase.Type = compiledRoutines.GetType("HREngine.Bots.TestBase", throwOnError: true);
	}

	public static List<string> GetBehaviorNames(Assembly compiledRoutines)
	{
		return (from type in compiledRoutines.ExportedTypes
			where type.Name != "Behavior" && type.Name.Contains("Behavior")
			select type.Name.Replace("Behavior", "")).ToList();
	}

	public static string ResolvePreferredBehaviorName(Assembly compiledRoutines, string requestedBehaviorName)
	{
		List<string> behaviorNames = GetBehaviorNames(compiledRoutines);
		if (behaviorNames.Count == 0)
		{
			return null;
		}
		if (!string.IsNullOrWhiteSpace(requestedBehaviorName))
		{
			string text = behaviorNames.FirstOrDefault((string name) => string.Equals(name, requestedBehaviorName, StringComparison.OrdinalIgnoreCase));
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentException("策略名称不存在 " + requestedBehaviorName + "。可用策略 " + string.Join(", ", behaviorNames));
            return text;
        }
        try
		{
			XmlConfigUtil xmlConfigUtil = new XmlConfigUtil(RoutineXmlPath);
			string s = xmlConfigUtil.Read("LastRoutine");
			if (int.TryParse(s, out var result) && result >= 0 && result < behaviorNames.Count)
			{
				return behaviorNames[result];
			}
		}
		catch
		{
		}
		return behaviorNames[0];
	}

	internal static TestRunSummary CaptureTestRunSummary(string behaviorName, string testFilePath)
	{
		Ai ai = new Ai(Ai.Instance);
		Settings settings = new Settings(Settings.Instance);
		return new TestRunSummary
		{
			BehaviorName = behaviorName,
			TestFilePath = Path.GetFullPath(testFilePath),
			BestMoveValue = ai.bestmoveValue,
            BestActions = ExtractActionLines(GetBestActions(ai)),
			LogFilePath = CombineLogPath(settings.logpath, settings.logfile),
			CurrentCalculatedBoard = ai.currentCalculatedBoard
		};
	}

	internal static void WriteSummary(TextWriter output, TestRunSummary summary)
	{
		if (summary != null)
		{
			output.WriteLine("测试完成");
			output.WriteLine("策略: " + summary.BehaviorName);
			output.WriteLine("场面文件: " + summary.TestFilePath);
			output.WriteLine("最佳分数: " + summary.BestMoveValue.ToString("0.##"));
			output.WriteLine("最佳动作数: " + summary.BestActions.Count);
			if (!string.IsNullOrWhiteSpace(summary.LogFilePath))
			{
				output.WriteLine("日志文件: " + summary.LogFilePath);
			}
			for (int i = 0; i < summary.BestActions.Count; i++)
			{
				output.WriteLine($"[{i + 1}] {summary.BestActions[i]}");
			}
		}
	}

	public static int RunCliTest(string testFilePath, string requestedBehaviorName, TextWriter output)
	{
		if (string.IsNullOrWhiteSpace(testFilePath) || !File.Exists(testFilePath))
		{
			output.WriteLine("测试文件不存在: " + testFilePath);
			return 2;
		}
		try
		{
			Assembly assembly = LoadCompiledRoutinesOrThrow();
			InitializeWrapperTypes(assembly);
			ApplySettingsToWrapper();
			string text = ResolvePreferredBehaviorName(assembly, requestedBehaviorName);
			if (string.IsNullOrWhiteSpace(text))
			{
				output.WriteLine("未找到可用策略。");
				return 3;
			}
			Type type = assembly.GetType("HREngine.Bots.Behavior" + text);
			if (type == null)
			{
				output.WriteLine("策略类型不存在: " + text);
				return 4;
			}
			AiTestClass aiTestClass = new AiTestClass(Activator.CreateInstance(assembly.GetType("HREngine.Bots.TestBase")));
			aiTestClass.Test(testFilePath, Activator.CreateInstance(type));
			TestRunSummary testRunSummary = CaptureTestRunSummary(text, testFilePath);
			string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "cli_test.log");
			File.AppendAllText(path, $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] behavior={text}{Environment.NewLine}" + "testFile=" + Path.GetFullPath(testFilePath) + Environment.NewLine + "status=success" + Environment.NewLine + $"bestMoveValue={testRunSummary.BestMoveValue}{Environment.NewLine}" + $"bestActions={testRunSummary.BestActions.Count}{Environment.NewLine}" + "logFile=" + testRunSummary.LogFilePath + Environment.NewLine);
			WriteSummary(output, testRunSummary);
			return 0;
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			while (ex2.InnerException != null)
			{
				ex2 = ex2.InnerException;
			}
			string path2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "cli_test.log");
			File.AppendAllText(path2, $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] behavior={requestedBehaviorName}{Environment.NewLine}" + "testFile=" + testFilePath + Environment.NewLine + "status=failed" + Environment.NewLine + ex2?.ToString() + Environment.NewLine);
			output.WriteLine(ex2.ToString());
			return 1;
		}
	}

	private static bool IsSilverfishDirectory(string path)
	{
		return Directory.Exists(path) && Directory.Exists(Path.Combine(path, "ai")) && Directory.Exists(Path.Combine(path, "cards"));
	}

	private static bool IsDefaultRoutineDirectory(string path)
	{
		return Directory.Exists(path) && IsSilverfishDirectory(Path.Combine(path, "Silverfish"));
	}

    internal static List<object> GetBestActions(Ai ai)
    {
        List<object> actions = new List<object>();
        if (ai.bestmove != null)
            actions.Add(ai.bestmove);
        if (ai.bestActions is IEnumerable remainingActions)
            actions.AddRange(remainingActions.Cast<object>().Where(action => action != null));
        return actions;
    }

	private static List<string> ExtractActionLines(object actions)
	{
		List<string> list = new List<string>();
		if (!(actions is IEnumerable enumerable))
		{
			return list;
		}
		foreach (object item in enumerable)
		{
			try
			{
				list.Add(new SilverfishWrapper.Action(item).printString());
			}
			catch
			{
			}
		}
		return list;
	}

	private static string CombineLogPath(string logDirectory, string logFile)
	{
		if (string.IsNullOrWhiteSpace(logDirectory) || string.IsNullOrWhiteSpace(logFile))
		{
			return null;
		}
		try
		{
			return Path.Combine(logDirectory, logFile);
		}
		catch
		{
			return null;
		}
	}
}
