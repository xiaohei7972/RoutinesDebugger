using System;
using System.CodeDom.Compiler;
using System.IO;
using System.Reflection;
using System.Windows;

namespace RoutineHelper;

public partial class App : Application
{
    private const string HelpText = """
炉石兄弟策略调试器
  --help | -h
  --compile [DefaultRoutine 或 Silverfish 目录]
  --run-test <局面文件> [策略名称]
  --run-latest-test [策略名称]
相对路径以命令启动目录为基准。
退出码 0 成功，1 编译或运行失败，2 参数或路径无效，3 无可用策略，4 策略类型缺失。
""";

    protected override void OnStartup(StartupEventArgs e)
    {
        string launchDirectory = Environment.CurrentDirectory;
        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        Directory.SetCurrentDirectory(AppContext.BaseDirectory);
        AppDomain.CurrentDomain.AssemblyResolve += ResolveRoutineHelperAssembly;
        if (e.Args.Length == 0)
        {
            base.OnStartup(e);
            return;
        }
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput(), new System.Text.UTF8Encoding(false)) { AutoFlush = true });
        Environment.Exit(RunCommandLine(e.Args, launchDirectory, Console.Out));
    }

    internal static int RunCommandLine(string[] args, string launchDirectory, TextWriter output)
    {
        if (args.Length == 0)
        {
            output.WriteLine(HelpText);
            return 2;
        }
        try
        {
            switch (args[0].ToLowerInvariant())
            {
                case "--help" or "-h" when args.Length == 1:
                    output.WriteLine(HelpText);
                    return 0;
                case "--compile" when args.Length <= 2:
                    string sourcePath = args.Length == 2
                        ? RoutineRuntime.NormalizeSilverfishPath(Path.GetFullPath(args[1], launchDirectory))
                        : null;
                    if (args.Length == 1) RoutineRuntime.TryResolveSilverfishPath(out sourcePath);
                    if (sourcePath == null)
                    {
                        output.WriteLine("未找到有效的 Silverfish 源码目录。");
                        return 2;
                    }
                    var results = RoutinesDebugger.Shared.SilverfishBuildService.Compile(sourcePath,
                        RoutineRuntime.GetCompiledAssemblyPath(), Path.Combine(AppContext.BaseDirectory, "compile_attempt.log"));
                    foreach (CompilerError error in results.Errors) output.WriteLine(error);
                    if (results.Errors.HasErrors) return 1;
                    var config = new XmlConfigUtil(RoutineRuntime.RoutineXmlPath);
                    config.Write(RoutineRuntime.NormalizeDefaultRoutinePath(sourcePath), "RoutinePath");
                    config.Write(sourcePath, "SilverfishPath");
                    return 0;
                case "--run-test" when args.Length is 2 or 3:
                    return RoutineRuntime.RunCliTest(Path.GetFullPath(args[1], launchDirectory),
                        args.Length == 3 ? args[2] : null, output);
                case "--run-latest-test" when args.Length <= 2:
                    if (!RoutineRuntime.TryResolveSilverfishPath(out var silverfishPath))
                    {
                        output.WriteLine("未找到当前 Silverfish 路径。");
                        return 2;
                    }
                    return RoutineRuntime.RunCliTest(RoutineRuntime.FindMostRecentTestFile(silverfishPath),
                        args.Length == 2 ? args[1] : null, output);
                default:
                    output.WriteLine("命令或参数数量无效。");
                    output.WriteLine(HelpText);
                    return 2;
            }
        }
        catch (Exception exception) when (exception is ArgumentException or NotSupportedException or PathTooLongException)
        {
            output.WriteLine("参数或路径无效 " + exception.Message);
            return 2;
        }
        catch (Exception exception)
        {
            output.WriteLine(exception.ToString());
            return 1;
        }
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
