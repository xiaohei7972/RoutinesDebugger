using System.IO;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.Loader;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using RoutineHelper;
[assembly: System.Runtime.Versioning.SupportedOSPlatform("windows7.0")]

internal static class Program
{
    [STAThread]
    public static int Main(string[] args)
    {
        string editorDirectory = Path.GetFullPath(args[0]);
        string runtimeDirectory = Path.GetFullPath(args[1]);
        string record = Path.GetFullPath(args[2]);
        string testRecord = Path.Combine(AppContext.BaseDirectory, "smoke-input.txt");
        File.Copy(record, testRecord, true);
        record = testRecord;
        Environment.SetEnvironmentVariable("HB_DEFAULTROUTINE_PATH", Path.Combine(runtimeDirectory, "Routines", "DefaultRoutine"));
        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        AssemblyLoadContext.Default.Resolving += (_, name) =>
        {
            string path = RuntimeDependencies.FindAssembly(runtimeDirectory, name.Name);
            return path == null ? null : AssemblyLoadContext.Default.LoadFromAssemblyPath(path);
        };
        Directory.CreateDirectory(Path.Combine(AppContext.BaseDirectory, "CompiledAssemblies"));
        File.Copy(Path.Combine(editorDirectory, "CompiledAssemblies", "Silverfish.dll"), RoutineRuntime.GetCompiledAssemblyPath(), true);
        var config = new XmlConfigUtil(RoutineRuntime.RoutineXmlPath);
        config.Write(Path.Combine(runtimeDirectory, "Routines", "DefaultRoutine"), "RoutinePath");
        var application = new Application { ShutdownMode = ShutdownMode.OnExplicitShutdown };
        int result = 1;
        application.DispatcherUnhandledException += (_, e) => { Console.Error.WriteLine(e.Exception); e.Handled = true; application.Shutdown(1); };
        var compilerDialog = new CompilerWindow("Smoke");
        Require(compilerDialog.FindName("SilverfishPathTextBox") is TextBox, "Compiler XAML loads");
        compilerDialog.Close();
        var compiler = new RoutineCompiler.MainWindow();
        Require(compiler.FindName("LaunchButton") is Button, "Standalone compiler XAML loads");
        compiler.Close();
        var window = new MainWindow { ShowInTaskbar = false };
        application.MainWindow = window;
        var timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(100) };
        DateTime deadline = DateTime.UtcNow.AddMinutes(2);
        timer.Tick += async (_, _) =>
        {
            try
            {
                var execute = (Button)window.FindName("ExecuteButton");
                if (!execute.IsEnabled)
                {
                    if (execute.Content?.ToString().Contains("失 败") == true) deadline = DateTime.MinValue;
                    if (DateTime.UtcNow > deadline) throw new TimeoutException("UI startup timed out. " + ((Label)window.FindName("CardSearchStatusBar")).Content + "\n" + new System.Windows.Documents.TextRange(((RichTextBox)window.FindName("LogRichTextBox")).Document.ContentStart, ((RichTextBox)window.FindName("LogRichTextBox")).Document.ContentEnd).Text);
                    return;
                }
                timer.Stop();
                ((ComboBox)window.FindName("RoutineComboBox")).SelectedItem = "丨通用丨不设惩罚";
                ((TextBox)window.FindName("TestPathBox")).Text = record;
                typeof(MainWindow).GetMethod("RefreshRecentTestFiles", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(window, null);
                var recent = ((ComboBox)window.FindName("RecentTestFilesComboBox")).SelectedItem;
                Require(recent?.GetType().GetProperty("FullPath").GetValue(recent)?.ToString() == record,
                    "Recent selection preserves an external imported record");
                execute.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                object summary = typeof(MainWindow).GetField("_lastTestSummary", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(window);
                Require(summary != null, "UI replay completes");
                var score = (float)summary.GetType().GetProperty("BestMoveValue").GetValue(summary);
                Require(score == float.Parse(args[3], System.Globalization.CultureInfo.InvariantCulture), "UI score matches CLI");
                int count = ((System.Collections.ICollection)summary.GetType().GetProperty("BestActions").GetValue(summary)).Count;
                Require(count >= 2, "Replay includes first and subsequent actions");
                Require(((ListBox)window.FindName("BestActionListBox")).Items.Count == count, "UI displays every best action");
                Require(((ListBox)window.FindName("EnemyMinionsListBox")).Items.Count > 0, "Imported enemy board is visible");
                Require(window.allCardsList.Count > 0, "Card database loads");
                var lookup = (TextBox)window.FindName("CardListSearchBox");
                lookup.Text = "火球术";
                typeof(MainWindow).GetMethod("CardListSearchBox_KeyDown", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(window,
                    new object[] { lookup, new System.Windows.Input.KeyEventArgs(System.Windows.Input.Keyboard.PrimaryDevice,
                        System.Windows.PresentationSource.FromVisual(window), 0, System.Windows.Input.Key.Enter) { RoutedEvent = System.Windows.Input.Keyboard.KeyDownEvent } });
                DateTime searchDeadline = DateTime.UtcNow.AddSeconds(10);
                while (window.searchWorker?.IsBusy == true && DateTime.UtcNow < searchDeadline) await Task.Delay(50);
                Require(((ListBox)window.FindName("CardListBox")).Items.Count > 0, "Card search returns matches");
                int[] existingProcesses = Process.GetProcessesByName("RoutineHelper").Select(process => process.Id).ToArray();
                ((Button)compiler.FindName("LaunchButton")).RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                await Task.Delay(500);
                using var launched = Process.GetProcessesByName("RoutineHelper").FirstOrDefault(process => !existingProcesses.Contains(process.Id));
                Require(launched != null && !launched.HasExited, "Standalone compiler launches editor");
                try
                {
                    launched.WaitForInputIdle(10000);
                    Require(!launched.HasExited, "Launched editor remains running");
                }
                finally
                {
                    if (!launched.HasExited)
                    {
                        launched.CloseMainWindow();
                        if (!launched.WaitForExit(10000)) launched.Kill();
                    }
                }
                result = 0;
                window.Close();
                application.Shutdown();
            }
            catch (Exception exception) { timer.Stop(); Console.Error.WriteLine(exception); Console.Error.WriteLine(new System.Windows.Documents.TextRange(((RichTextBox)window.FindName("LogRichTextBox")).Document.ContentStart, ((RichTextBox)window.FindName("LogRichTextBox")).Document.ContentEnd).Text); window.Close(); application.Shutdown(1); }
        };
        Console.WriteLine("Opening editor window");
        window.Show();
        Console.WriteLine("Editor window opened");
        timer.Start();
        application.Run();
        return result;
    }

    private static void Require(bool condition, string message)
    {
        if (!condition) throw new InvalidOperationException(message);
        Console.WriteLine("PASS " + message);
    }
}
