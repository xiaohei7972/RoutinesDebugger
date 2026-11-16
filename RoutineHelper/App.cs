using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows;

namespace RoutineHelper;

public partial class App : Application
{
    private static string LaunchDirectory = Environment.CurrentDirectory;
	protected override void OnStartup(StartupEventArgs e)
	{
		System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        Directory.SetCurrentDirectory(AppContext.BaseDirectory);
        AppDomain.CurrentDomain.AssemblyResolve += ResolveRoutineHelperAssembly;
		if (e.Args.Length != 0)
		{
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput(), new System.Text.UTF8Encoding(false)) { AutoFlush = true });
            if (string.Equals(e.Args[0], "--compile", StringComparison.OrdinalIgnoreCase))
            {
                string sourcePath = e.Args.Length > 1 ? RoutineRuntime.NormalizeSilverfishPath(Path.GetFullPath(e.Args[1], LaunchDirectory)) : null;
                if (e.Args.Length == 1)
                    RoutineRuntime.TryResolveSilverfishPath(out sourcePath);
                if (sourcePath == null)
                {
                    Console.WriteLine("未找到有效的 Silverfish 源码目录。");
                    Environment.Exit(2);
                }
                var results = RoutinesDebugger.Shared.SilverfishBuildService.Compile(sourcePath,
                    RoutineRuntime.GetCompiledAssemblyPath(), Path.Combine(AppContext.BaseDirectory, "compile_attempt.log"));
                foreach (CompilerError error in results.Errors)
                    Console.WriteLine(error);
                if (!results.Errors.HasErrors)
                {
                    var config = new XmlConfigUtil(RoutineRuntime.RoutineXmlPath);
                    config.Write(RoutineRuntime.NormalizeDefaultRoutinePath(sourcePath), "RoutinePath");
                    config.Write(sourcePath, "SilverfishPath");
                }
                Environment.Exit(results.Errors.HasErrors ? 1 : 0);
                return;
            }

			if (string.Equals(e.Args[0], "--run-test", StringComparison.OrdinalIgnoreCase))
			{
				string testFilePath = ((e.Args.Length > 1) ? Path.GetFullPath(e.Args[1], LaunchDirectory) : null);
				string requestedBehaviorName = ((e.Args.Length > 2) ? e.Args[2] : null);
				int exitCode = RoutineRuntime.RunCliTest(testFilePath, requestedBehaviorName, Console.Out);
				Environment.Exit(exitCode);
				return;
			}
			if (string.Equals(e.Args[0], "--run-latest-test", StringComparison.OrdinalIgnoreCase))
			{
				if (!RoutineRuntime.TryResolveSilverfishPath(out var silverfishPath))
				{
					Console.WriteLine("未找到当前 Silverfish 路径。");
					Environment.Exit(2);
				}
				else
				{
					string testFilePath2 = RoutineRuntime.FindMostRecentTestFile(silverfishPath);
					int exitCode2 = RoutineRuntime.RunCliTest(testFilePath2, (e.Args.Length > 1) ? e.Args[1] : null, Console.Out);
					Environment.Exit(exitCode2);
				}
				return;
			}
            Console.Error.WriteLine("未知参数。支持 --compile、--run-test、--run-latest-test。");
            Environment.Exit(2);
            return;
		}
		base.OnStartup(e);
	}

	private static Assembly ResolveRoutineHelperAssembly(object sender, ResolveEventArgs args)
	{
		string name = new AssemblyName(args.Name).Name;
        if (name.EndsWith(".resources", StringComparison.OrdinalIgnoreCase))
            return null;
		string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        if (RoutineRuntime.TryResolveSilverfishPath(out string silverfishPath))
        {
            string runtimeDirectory = RuntimeDependencies.ResolveDirectory(silverfishPath);
            string assemblyPath = RuntimeDependencies.FindAssembly(runtimeDirectory, name);
            if (assemblyPath != null)
                return Assembly.LoadFrom(assemblyPath);
        }
        string bundledPath = RuntimeDependencies.FindAssembly(Path.Combine(baseDirectory, "CompiledAssemblies"), name);
        if (bundledPath != null)
            return Assembly.LoadFrom(bundledPath);
		return null;
	}

}
