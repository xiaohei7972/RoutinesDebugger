using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using RoutineHelper;
using RoutinesDebugger.Shared;

namespace RoutineCompiler;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        RoutineRuntime.TryResolveSilverfishPath(out var sourcePath);
        Log(sourcePath == null ? "请选择 DefaultRoutine 或 Silverfish 目录。" : sourcePath);
    }

    private void Log(string message)
    {
        LogRichTextBox.Document.Blocks.Add(new Paragraph(new Run(message)));
        LogScrollViewer.ScrollToEnd();
    }

    private async void RecompileButton_Click(object sender, RoutedEventArgs e)
    {
        if (!RoutineRuntime.TryResolveSilverfishPath(out var sourcePath))
        {
            ReconfigureButton_Click(sender, e);
            if (!RoutineRuntime.TryResolveSilverfishPath(out sourcePath)) return;
        }
        RecompileButton.IsEnabled = LaunchButton.IsEnabled = ReconfigureButton.IsEnabled = false;
        try
        {
            var results = await Task.Run(() => SilverfishBuildService.Compile(sourcePath,
                RoutineRuntime.GetCompiledAssemblyPath(), Path.Combine(AppContext.BaseDirectory, "compile_attempt.log")));
            foreach (CompilerError error in results.Errors) Log(error.ToString());
            Log(results.Errors.HasErrors ? "编译失败，请查看上述诊断。" : "编译成功，可以启动策略编辑器。");
        }
        catch (Exception exception) { Log(exception.ToString()); }
        finally { RecompileButton.IsEnabled = LaunchButton.IsEnabled = ReconfigureButton.IsEnabled = true; }
    }

    private void ReconfigureButton_Click(object sender, RoutedEventArgs e)
    {
        RoutineRuntime.TryResolveSilverfishPath(out var currentPath);
        var dialog = new SettingsPopup(currentPath, "请选择 DefaultRoutine 或 Silverfish 目录") { Owner = this };
        if (dialog.ShowDialog() != true) return;
        string path = RoutineRuntime.NormalizeDefaultRoutinePath(dialog.silverfishPath);
        if (path == null) { Log("所选目录中未找到 Silverfish/ai 和 Silverfish/cards。"); return; }
        var config = new XmlConfigUtil(RoutineRuntime.RoutineXmlPath);
        config.Write(path, "RoutinePath");
        config.Write(Path.Combine(path, "Silverfish"), "SilverfishPath");
        Log("策略目录已保存 " + path);
    }

    private void LaunchButton_Click(object sender, RoutedEventArgs e)
    {
        string executable = Path.Combine(AppContext.BaseDirectory, "RoutineHelper.exe");
        if (!File.Exists(executable)) { Log("未找到 " + executable + "，请使用完整发布包。"); return; }
        if (!File.Exists(RoutineRuntime.GetCompiledAssemblyPath())) { Log("请先编译策略。"); return; }
        try { Process.Start(new ProcessStartInfo(executable) { WorkingDirectory = AppContext.BaseDirectory, UseShellExecute = true }); }
        catch (Exception exception) { Log(exception.Message); }
    }
}
