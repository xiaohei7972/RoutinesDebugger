using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using RoutinesDebugger.Shared;

namespace RoutineHelper;

public partial class CompilerWindow : Window
{
    public string RoutinePath;
    public CompilerResults Results;
    private bool _isCompiling;

    public CompilerWindow(string hint)
    {
        InitializeComponent();
        RoutineRuntime.TryResolveDefaultRoutinePath(out RoutinePath);
        SilverfishPathTextBox.Text = RoutinePath ?? string.Empty;
        PathGroupBox.Header = hint ?? "请选择 DefaultRoutine 或 Silverfish 目录";
    }

    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        if (_isCompiling) return;
        string routinePath = RoutineRuntime.NormalizeDefaultRoutinePath(SilverfishPathTextBox.Text);
        if (routinePath == null)
        {
            StatusText.Text = "目录无效，请选择 DefaultRoutine 或 Silverfish 文件夹。";
            return;
        }
        RoutinePath = routinePath;
        SilverfishPathTextBox.Text = routinePath;
        DiagnosticsTextBox.Clear();
        SetCompiling(true);
        bool success = false;
        try
        {
            StatusText.Text = "正在编译策略，完成后自动加载。";
            Results = await Task.Run(CompileRoutinesWorker);
            DiagnosticsTextBox.Text = string.Join(Environment.NewLine, Results.Errors.Cast<CompilerError>());
            if (Results.Errors.HasErrors)
            {
                StatusText.Text = "编译失败，请根据诊断修正源码后重试。";
                return;
            }
            var config = new XmlConfigUtil(RoutineRuntime.RoutineXmlPath);
            config.Write(routinePath, "RoutinePath");
            config.Write(RoutineRuntime.NormalizeSilverfishPath(routinePath), "SilverfishPath");
            success = true;
        }
        catch (Exception exception)
        {
            StatusText.Text = "编译或保存配置失败，请检查诊断。";
            DiagnosticsTextBox.Text = exception.ToString();
        }
        finally
        {
            SetCompiling(false);
        }
        if (success) DialogResult = true;
    }

    private void SetCompiling(bool value)
    {
        _isCompiling = value;
        CompileButton.IsEnabled = SelectSilverfishPathButton.IsEnabled = SilverfishPathTextBox.IsEnabled = CancelButton.IsEnabled = !value;
        CompileProgress.IsIndeterminate = value;
        CompileButton.Content = value ? "编译中…" : "编译并加载";
    }

    protected override void OnClosing(CancelEventArgs e)
    {
        if (_isCompiling) e.Cancel = true;
        base.OnClosing(e);
    }

    public CompilerResults CompileRoutinesWorker()
    {
        string sourcePath = RoutineRuntime.NormalizeSilverfishPath(RoutinePath);
        if (sourcePath == null)
        {
            var results = new CompilerResults(new TempFileCollection());
            results.Errors.Add(new CompilerError { ErrorNumber = "PATH", ErrorText = "未找到有效的 Silverfish 源码目录。" });
            return results;
        }
        return SilverfishBuildService.Compile(sourcePath, RoutineRuntime.GetCompiledAssemblyPath(),
            Path.Combine(AppContext.BaseDirectory, "compile_attempt.log"));
    }

    private void SelectSilverfishPathButton_Click(object sender, RoutedEventArgs e)
    {
        using var dialog = new System.Windows.Forms.FolderBrowserDialog
        {
            Description = "请选择 DefaultRoutine 文件夹或其下的 Silverfish 子目录",
            SelectedPath = Directory.Exists(RoutinePath) ? RoutinePath : AppContext.BaseDirectory
        };
        if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            SilverfishPathTextBox.Text = dialog.SelectedPath;
    }
}
