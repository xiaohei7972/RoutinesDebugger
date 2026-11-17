using System.IO;

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
        Require(File.Exists(Path.Combine(editorDirectory, "RoutineHelper.exe"))
            && !File.Exists(Path.Combine(editorDirectory, "RoutineCompiler.exe")), "Package uses a single compilation and debugging entry point");
        string runtimeDirectory = Path.GetFullPath(args[1]);
        string record = Path.GetFullPath(args[2]);
        string inputDirectory = Path.Combine(AppContext.BaseDirectory, "Inputs", Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(inputDirectory);
        string testRecord = Path.Combine(inputDirectory, "smoke-input.txt");
        File.Copy(record, testRecord, true);
        record = testRecord;
        byte[] inputBytes = File.ReadAllBytes(record);
        string[] originalInputFiles = Directory.GetFiles(inputDirectory);
        Environment.SetEnvironmentVariable("HB_DEFAULTROUTINE_PATH", Path.Combine(runtimeDirectory, "Routines", "DefaultRoutine"));
        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        AssemblyLoadContext.Default.Resolving += (_, name) =>
        {
            string path = RuntimeDependencies.FindAssembly(runtimeDirectory, name.Name);
            return path == null ? null : AssemblyLoadContext.Default.LoadFromAssemblyPath(path);
        };
        Directory.CreateDirectory(Path.Combine(AppContext.BaseDirectory, "CompiledAssemblies"));
        File.Delete(RoutineRuntime.GetCompiledAssemblyPath());
        var config = new XmlConfigUtil(RoutineRuntime.RoutineXmlPath);
        config.Write(Path.Combine(runtimeDirectory, "Routines", "DefaultRoutine"), "RoutinePath");
        var application = new Application { ShutdownMode = ShutdownMode.OnExplicitShutdown };
        int result = 1;
        application.DispatcherUnhandledException += (_, e) => { Console.Error.WriteLine(e.Exception); e.Handled = true; application.Shutdown(1); };
        var compilerDialog = new CompilerWindow("Smoke");
        Require(compilerDialog.FindName("SilverfishPathTextBox") is TextBox, "Compiler XAML loads");
        compilerDialog.Close();
        string failureRoot = Path.Combine(AppContext.BaseDirectory, "CompileFailure");
        string failureSource = Path.Combine(failureRoot, "Routines", "DefaultRoutine", "Silverfish");
        Directory.CreateDirectory(Path.Combine(failureSource, "ai"));
        Directory.CreateDirectory(Path.Combine(failureSource, "cards"));
        Directory.CreateDirectory(Path.Combine(failureSource, "Test"));
        File.Copy(Path.Combine(runtimeDirectory, "Hearthbuddy.dll"), Path.Combine(failureRoot, "Hearthbuddy.dll"), true);
        File.WriteAllText(Path.Combine(failureSource, "..", "silverfish_HB.cs"), "broken source");
        File.WriteAllText(Path.Combine(failureSource, "Test", "TestBase.cs"), "namespace HREngine.Bots { public class TestBase {} }");
        var failureDialog = new CompilerWindow("Failure smoke");
        ((TextBox)failureDialog.FindName("SilverfishPathTextBox")).Text = failureSource;
        string originalRoutinePath = config.Read("RoutinePath");
        var failureTimer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(100) };
        bool failureStarted = false;
        failureTimer.Tick += (_, _) =>
        {
            var button = (Button)failureDialog.FindName("CompileButton");
            if (!failureStarted)
            {
                failureStarted = true;
                button.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
            else if (button.IsEnabled && failureDialog.Results != null)
            {
                failureTimer.Stop();
                Require(failureDialog.Results.Errors.HasErrors && failureDialog.IsVisible
                    && !string.IsNullOrWhiteSpace(((TextBox)failureDialog.FindName("DiagnosticsTextBox")).Text),
                    "Failed integrated compilation displays diagnostics and permits retry");
                Require(config.Read("RoutinePath") == originalRoutinePath, "Failed integrated compilation preserves configured source path");
                failureDialog.Close();
            }
        };
        failureTimer.Start();
        failureDialog.ShowDialog();
        bool compilationStarted = false;
        int responsiveTicks = 0;
        var compilationTimer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(100) };
        DateTime compilationDeadline = DateTime.UtcNow.AddMinutes(3);
        compilationTimer.Tick += (_, _) =>
        {
            var dialog = application.Windows.OfType<CompilerWindow>().FirstOrDefault(window => window.IsVisible);
            if (dialog == null) return;
            if (DateTime.UtcNow > compilationDeadline)
            {
                Console.Error.WriteLine("Integrated compilation timed out");
                application.Shutdown(1);
                return;
            }
            var button = (Button)dialog.FindName("CompileButton");
            if (!compilationStarted)
            {
                ((TextBox)dialog.FindName("SilverfishPathTextBox")).Text = Path.Combine(runtimeDirectory, "Routines", "DefaultRoutine");
                compilationStarted = true;
                button.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
            else if (!button.IsEnabled) responsiveTicks++;
            else if (dialog.Results?.Errors.HasErrors == true)
            {
                Console.Error.WriteLine(((TextBox)dialog.FindName("DiagnosticsTextBox")).Text);
                dialog.Close();
                application.Shutdown(1);
            }
        };
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
                Require(File.Exists(RoutineRuntime.GetCompiledAssemblyPath()) && compilationStarted && responsiveTicks > 0,
                    "First startup compiles inside RoutineHelper with a responsive UI");
                var artifacts = typeof(MainWindow).GetField("_lastAiFixArtifacts", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(window);
                string promptPath = artifacts.GetType().GetProperty("PromptPath").GetValue(artifacts).ToString();
                Require(promptPath.StartsWith(Path.Combine(AppContext.BaseDirectory, "Outputs") + Path.DirectorySeparatorChar)
                    && File.Exists(promptPath), "Replay artifacts stay inside debugger output directory");
                Require(File.ReadAllBytes(record).SequenceEqual(inputBytes)
                    && Directory.GetFiles(inputDirectory).SequenceEqual(originalInputFiles), "Replay keeps the imported input directory unchanged");
                Require(!MainWindow.compiledRoutines.GetReferencedAssemblies().Any(name => name.Name == "RoutineHelper"),
                    "Offline kernel has no editor assembly dependency");
                result = 0;
                window.Close();
                application.Shutdown();
            }
            catch (Exception exception) { timer.Stop(); Console.Error.WriteLine(exception); Console.Error.WriteLine(new System.Windows.Documents.TextRange(((RichTextBox)window.FindName("LogRichTextBox")).Document.ContentStart, ((RichTextBox)window.FindName("LogRichTextBox")).Document.ContentEnd).Text); window.Close(); application.Shutdown(1); }
        };
        Console.WriteLine("Opening editor window");
        compilationTimer.Start();
        window.Show();
        compilationTimer.Stop();
        deadline = DateTime.UtcNow.AddMinutes(2);
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
