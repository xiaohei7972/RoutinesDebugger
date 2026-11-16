using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Media;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Markup;
using RoutinesDebugger.Shared;

namespace RoutineHelper;

public partial class CompilerWindow : Window
{
	public string RoutinePath;

	public CompilerResults Results = null;

	private readonly string _routineXml = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Settings\\Default\\routine.xml");

	private readonly string _compileLog = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "compile_attempt.log");






	private static string ResolveHbRuntimeDir(string silverfishPath)
	{
		return Path.GetFullPath(Path.Combine(silverfishPath, "..", "..", ".."));
	}

	public CompilerWindow(string hint)
	{
		InitializeComponent();
		RoutineRuntime.TryResolveDefaultRoutinePath(out RoutinePath);
		SilverfishPathTextBox.Text = RoutinePath ?? string.Empty;
		PathGroupBox.Header = (string.IsNullOrWhiteSpace(hint) ? "请选择 DefaultRoutine 文件夹" : hint);
	}

	private async void Button_Click(object sender, RoutedEventArgs e)
	{
		string defaultRoutinePath = RoutineRuntime.NormalizeDefaultRoutinePath(SilverfishPathTextBox.Text);
		if (string.IsNullOrWhiteSpace(defaultRoutinePath))
		{
			System.Windows.MessageBox.Show("请先导入 DefaultRoutine 文件夹，或直接选择其中的 Silverfish 子目录。", "路径无效");
			return;
		}
		RoutinePath = defaultRoutinePath;
		SilverfishPathTextBox.Text = defaultRoutinePath;
		((System.Windows.Controls.Button)sender).Content = "编译中...";
		((System.Windows.Controls.Button)sender).IsEnabled = false;
		CompilerResults result = (Results = await Task.Run((Func<CompilerResults>)CompileRoutinesWorker));
		if (result != null && !result.Errors.HasErrors)
		{
			SystemSounds.Exclamation.Play();
			base.DialogResult = true;
		}
		else if (result != null)
		{
			SystemSounds.Hand.Play();
		}
		((System.Windows.Controls.Button)sender).Content = "编译";
		((System.Windows.Controls.Button)sender).IsEnabled = true;
		if (result != null)
		{
			string silverfishPath = RoutineRuntime.NormalizeSilverfishPath(RoutinePath);
			XmlConfigUtil util = new XmlConfigUtil(_routineXml);
			util.Write(RoutinePath, "RoutinePath");
			if (!string.IsNullOrWhiteSpace(silverfishPath))
			{
				util.Write(silverfishPath, "SilverfishPath");
			}
			Close();
		}
	}

	public CompilerResults CompileRoutinesWorker()
	{
		try
		{
			string text = RoutineRuntime.NormalizeSilverfishPath(RoutinePath);
			if (string.IsNullOrWhiteSpace(text))
			{
				throw new DirectoryNotFoundException("请选择有效的 DefaultRoutine 文件夹，目录下必须包含 Silverfish 子目录。");
			}
			string text2 = ResolveHbRuntimeDir(text);
			string text3 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CompiledAssemblies");
			string outputAssemblyPath = Path.Combine(text3, "Silverfish.dll");
			Directory.CreateDirectory(text3);
			File.AppendAllText(_compileLog, $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Compile start{Environment.NewLine}" + "RoutinePath=" + RoutinePath + Environment.NewLine + "SilverfishPath=" + text + Environment.NewLine + "RuntimeDir=" + text2 + Environment.NewLine + "OutputDir=" + text3 + Environment.NewLine);
			return SilverfishBuildService.Compile(text, outputAssemblyPath, _compileLog);
		}
		catch (Exception ex)
		{
			File.AppendAllText(_compileLog, "exception=" + ex?.ToString() + Environment.NewLine);
			System.Windows.MessageBox.Show(ex.Message, "CompilerErrors");
		}
		return null;
	}

	private void SelectSilverfishPathButton_Click(object sender, RoutedEventArgs e)
	{
		FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
		folderBrowserDialog.Description = "请选择 DefaultRoutine 文件夹（或其下的 Silverfish 子目录）";
		folderBrowserDialog.SelectedPath = ((!string.IsNullOrWhiteSpace(RoutinePath) && Directory.Exists(RoutinePath)) ? RoutinePath : AppDomain.CurrentDomain.BaseDirectory);
		if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
		{
			string text = RoutineRuntime.NormalizeDefaultRoutinePath(folderBrowserDialog.SelectedPath);
			if (!string.IsNullOrEmpty(text))
			{
				RoutinePath = text;
				SilverfishPathTextBox.Text = text;
			}
			else
			{
				System.Windows.MessageBox.Show("请选择有效的 DefaultRoutine 文件夹，目录下必须包含 Silverfish 子目录。", "路径无效");
			}
		}
	}

}
