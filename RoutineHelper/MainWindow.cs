using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Xml;
using Microsoft.Win32;
using SilverfishWrapper;

namespace RoutineHelper;

public partial class MainWindow : Window, INotifyPropertyChanged
{
	private enum InteractiveSpecialSourceKind
	{
		None,
		HeroPower
	}

	private sealed class InteractiveDragPayload
	{
		public InteractiveSpecialSourceKind SpecialSource { get; set; }

		public int SourceEntityId { get; set; }

		public InteractiveEntityKind SourceKind { get; set; }
	}

	private static readonly bool EnableImagePreview = true;

	private const string EntitySnapshotBeginMarker = "### ENTITY_SNAPSHOT_BEGIN ###";

	private const string EntitySnapshotEndMarker = "### ENTITY_SNAPSHOT_END ###";

	public CardDB cardDB;

	public List<CardListEntry> allCardsList;

	public BackgroundWorker searchWorker;

	public ActionItem actionItem;

	public List<ActionItem> bestActionItem = new List<ActionItem>();

	public float lastHighlightedScore = -1f;

	public Dictionary<float, List<ActionItem>> actionScoreMap = new Dictionary<float, List<ActionItem>>();

	public Dictionary<string, object> playfieldActionList = new Dictionary<string, object>();

	public Dictionary<string, List<ActionItem>> playfieldActionDisplayMap = new Dictionary<string, List<ActionItem>>();

	public bool isExporting = false;

	public static Assembly compiledRoutines;

	private bool _suppressRecentTestSelectionChanged;

	private Dictionary<string, string> _cardNameLookup = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

	private string _currentEntitySnapshot = string.Empty;

	private string _currentAiFixPrompt = string.Empty;

	private string _currentManualActionScript = string.Empty;

	private string _lastExecutedTestFilePath;

	private string _lastExecutedBehaviorName;

	private TestRunSummary _lastTestSummary;

	private AiFixArtifacts _lastAiFixArtifacts;

	private Playfield _interactiveRootBoard;

	private Playfield _interactiveCurrentBoard;

	private readonly Dictionary<int, int> _interactiveRootHandCostByEntityId = new Dictionary<int, int>();

	private InteractiveEntityItem _interactiveSelectedSource;

	private InteractiveEntityItem _interactiveSelectedTarget;

	private bool _suppressInteractiveSelectionChanged;

	private readonly List<ManualActionStep> _interactiveActionSteps = new List<ManualActionStep>();

	private readonly List<InteractiveCandidateItem> _interactiveCandidateItems = new List<InteractiveCandidateItem>();

	private List<CandidateActionView> _interactiveAllCandidates = new List<CandidateActionView>();

	private readonly HashSet<int> _interactiveLegalSourceEntityIds = new HashSet<int>();

	private readonly HashSet<int> _interactiveLegalTargetEntityIds = new HashSet<int>();

	private int _interactiveCandidateTotalCount;

	private bool _interactiveCanUseHeroPower;

	private bool _interactiveCanEndTurn;

	private InteractiveSpecialSourceKind _interactiveSelectedSpecialSource;

	private int? _interactiveSelectedPreferredPlace;

	private Point _interactiveDragStartPoint;

	private InteractiveDragPayload _interactivePendingDrag;

	private Window _interactiveAiFixWindow;

	private object _interactiveAiFixHostPlaceholder;

	private float bestScore;

	private readonly string _defaultXmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Settings\\Default");

	private readonly string _routineXml = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Settings\\Default\\routine.xml");

	private readonly string _compiledAssemblies = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CompiledAssemblies");

	private readonly string _compileLog = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "compile_attempt.log");

	public float BestScore
	{
		get
		{
			return bestScore;
		}
		set
		{
			if (value != bestScore)
			{
				bestScore = value;
				NotifyPropertyChanged("BestScore");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void NotifyPropertyChanged(string propertyName)
	{
		if (this.PropertyChanged != null)
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}

	public MainWindow()
	{
		InitializeComponent();
	}

	private void LoadAssembly()
	{
		if (!Directory.Exists(_defaultXmlPath))
		{
			Directory.CreateDirectory(_defaultXmlPath);
		}
		if (!Directory.Exists(_compiledAssemblies))
		{
			Directory.CreateDirectory(_compiledAssemblies);
		}
		string path = Path.Combine(_compiledAssemblies, "Silverfish.dll");
		if (File.Exists(path))
		{
			compiledRoutines = Assembly.Load(File.ReadAllBytes(path));
			return;
		}
		CompilerWindow compilerWindow = new CompilerWindow("请先导入 DefaultRoutine 文件夹");
		bool? flag = compilerWindow.ShowDialog();
		if (!flag.HasValue || !flag.Value)
		{
			if (compilerWindow.Results != null)
			{
				string text = "";
				foreach (CompilerError error in compilerWindow.Results.Errors)
				{
					if (!error.IsWarning)
					{
						text += $"{error}\r\n";
					}
				}
				System.Windows.MessageBox.Show(text, "CompilerErrors");
				LoadAssembly();
				return;
			}
			Environment.Exit(0);
		}
		if (File.Exists(path))
		{
			compiledRoutines = Assembly.Load(File.ReadAllBytes(path));
			return;
		}
		System.Windows.MessageBox.Show("编译已执行，但未找到 CompiledAssemblies\\Silverfish.dll", "CompilerErrors");
		LoadAssembly();
	}

	private bool EnsureKernelCompiledOnStartup()
	{
		return (File.Exists(RoutineRuntime.GetCompiledAssemblyPath()) && RoutineRuntime.TryResolveSilverfishPath(out _))
            || CompileKernelViaDialog("请选择并编译本次要使用的 DefaultRoutine 文件夹");
	}

	private bool CompileKernelViaDialog(string hint)
	{
		CompilerWindow compilerWindow = new CompilerWindow(hint);
		Window window = Window.GetWindow(this);
		if (window != null)
		{
			double left = window.Left + (window.Width - compilerWindow.Width) / 2.0;
			double top = window.Top + (window.Height - compilerWindow.Height) / 2.0;
			compilerWindow.WindowStartupLocation = WindowStartupLocation.Manual;
			compilerWindow.Left = left;
			compilerWindow.Top = top;
		}
		bool? flag = compilerWindow.ShowDialog();
		if (flag.HasValue && flag.Value)
		{
			SuccessLog("[Compiler] 启动编译完成。");
			return true;
		}
		if (compilerWindow.Results != null)
		{
			ShowCompilerErrors(compilerWindow.Results, "StartupCompilerErrors");
		}
		return false;
	}

	private static void ShowCompilerErrors(CompilerResults results, string title)
	{
		if (results == null)
		{
			System.Windows.MessageBox.Show("编译失败，但没有返回详细错误。", title);
			return;
		}
		StringBuilder stringBuilder = new StringBuilder();
		foreach (CompilerError error in results.Errors)
		{
			if (!error.IsWarning)
			{
				stringBuilder.AppendLine(error.ToString());
			}
		}
		if (stringBuilder.Length == 0)
		{
			foreach (CompilerError error2 in results.Errors)
			{
				stringBuilder.AppendLine(error2.ToString());
			}
		}
		System.Windows.MessageBox.Show((stringBuilder.Length == 0) ? "编译失败，但没有返回详细错误。" : stringBuilder.ToString(), title);
	}

	private void InitWrapers()
	{
		RoutineRuntime.InitializeWrapperTypes(compiledRoutines);
		LoadConfigFile();
		ConstructCardList();
		CompileRoutinesWorkerCompleted();
	}

	private void MainWindowUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
	{
		ErrorLog("[Runtime Exception] " + e.Exception);
		e.Handled = true;
	}

	private string GetSourceOnlineImageFromAction(SilverfishWrapper.Action action)
	{
		if (!EnableImagePreview)
		{
			return null;
		}
		string result = "";
		try
		{
			if (action.card != null)
			{
				Handcard handcard = new Handcard(action.card);
				Card card = new Card(handcard.card);
				result = card.OnlineCardImage;
			}
			else
			{
				Minion minion = new Minion(action.own);
				Handcard handcard2 = new Handcard(minion.handcard);
				Card card2 = new Card(handcard2.card);
				result = card2.OnlineCardImage;
			}
		}
		catch
		{
		}
		return result;
	}

	private string GetTargetOnlineImageFromAction(SilverfishWrapper.Action action)
	{
		if (!EnableImagePreview)
		{
			return null;
		}
		string result = "";
		try
		{
			if (action.target != null)
			{
				Minion minion = new Minion(action.target);
				Handcard handcard = new Handcard(minion.handcard);
				Card card = new Card(handcard.card);
				result = card.OnlineCardImage;
			}
		}
		catch
		{
		}
		return result;
	}

	public void DisplayCurrentPlayField(object pfInst, string stepKey = null)
	{
		Playfield playfield = new Playfield(pfInst);
		Hrtprozis hrtprozis = new Hrtprozis(playfield.prozis);
		OwnMinionsListBox.ItemsSource = BuildVisualMinionItems((IEnumerable)playfield.ownMinions);
		EnemyMinionsListBox.ItemsSource = BuildVisualMinionItems((IEnumerable)playfield.enemyMinions);
		OwnHandCardListBox.ItemsSource = BuildVisualHandItems(playfield, (IEnumerable)playfield.owncards);
		List<VisualCardItem> list = new List<VisualCardItem>();
		IEnumerable enumerable = (IEnumerable)hrtprozis.turnDeck;
		foreach (object item in enumerable)
		{
			Card card = new Card(new CardDB(CardDB.Instance).getCardDataFromID((cardIDEnum)item.ReflectionCall<int>("get_Key", Array.Empty<object>())));
			card.count = item.ReflectionCall<int>("get_Value", Array.Empty<object>());
			list.Add(CreateVisualCardItemFromCard(card));
		}
		OwnDeckCardListBox.ItemsSource = list;
		List<InfoItem> list2 = new List<InfoItem>();
		Minion minion = new Minion(playfield.ownHero);
		Minion minion2 = new Minion(playfield.enemyHero);
		QuestItem questItem = new QuestItem(playfield.ownQuest);
		QuestItem questItem2 = new QuestItem(playfield.enemyQuest);
		list2.Add(new InfoItem
		{
			Item = "水晶",
			Value = playfield.mana + " / " + playfield.ownMaxMana
		});
		list2.Add(new InfoItem
		{
			Item = "我方英雄",
			Value = playfield.ownHeroName.ToString() + "\n[生命: " + minion.Hp + "+" + minion.armor + "] [手牌: " + playfield.owncards.ReflectionCall<int>("get_Count", Array.Empty<object>()) + "] [奥秘数: " + playfield.ownSecretsIDList.ReflectionCall<int>("get_Count", Array.Empty<object>()) + "]" + (minion.immune ? " [免疫]" : "") + ((minion.spellpower != 0) ? (" [法强+" + minion.spellpower + "]") : "") + (minion.Aura ? " [光环]" : "")
		});
		list2.Add(new InfoItem
		{
			Item = "敌方英雄",
			Value = playfield.enemyHeroName.ToString() + "\n[生命: " + minion2.Hp + "+" + minion2.armor + "] [手牌: " + playfield.enemyAnzCards + "] [奥秘数: " + playfield.enemySecretCount + "]" + (minion2.immune ? " [免疫]" : "") + ((minion2.spellpower != 0) ? (" [法强+" + minion2.spellpower + "]") : "") + (minion2.Aura ? " [光环]" : "")
		});
		list2.Add(new InfoItem
		{
			Item = "我方任务",
			Value = questItem.Id.ToString() + " [" + questItem.questProgress + "/" + questItem.maxProgress + "]"
		});
		list2.Add(new InfoItem
		{
			Item = "敌方任务",
			Value = questItem2.Id.ToString() + " [" + questItem2.questProgress + "/" + questItem2.maxProgress + "]"
		});
		list2.Add(new InfoItem
		{
			Item = "我方法强",
			Value = playfield.spellpower + "（起始 " + playfield.spellpowerStarted + "）"
		});
		list2.Add(new InfoItem
		{
			Item = "敌方法强",
			Value = playfield.enemyspellpower + "（起始 " + playfield.enemyspellpowerStarted + "）"
		});
		list2.Add(new InfoItem
		{
			Item = "我方疲劳/尸体",
			Value = "疲劳 " + playfield.ownHeroFatigue + (Playfield.Type.GetField("corpseGainedThisGame") == null ? " / 内核未提供尸体统计" : " / 尸体 +" + ReadOptionalRuntimeField<int>(playfield.Inst, "corpseGainedThisGame") + " 用" + ReadOptionalRuntimeField<int>(playfield.Inst, "corpseUsedThisGame"))
		});
		list2.Add(new InfoItem
		{
			Item = "敌方疲劳",
			Value = "疲劳 " + playfield.enemyHeroFatigue
		});
		list2.Add(new InfoItem
		{
			Item = "我方武器",
			Value = FormatWeaponInfo(playfield.ownWeapon)
		});
		list2.Add(new InfoItem
		{
			Item = "敌方武器",
			Value = FormatWeaponInfo(playfield.enemyWeapon)
		});
		list2.Add(new InfoItem
		{
			Item = "我方技能",
			Value = FormatHeroPowerInfo(playfield, hrtprozis, own: true)
		});
		list2.Add(new InfoItem
		{
			Item = "敌方技能",
			Value = FormatHeroPowerInfo(playfield, hrtprozis, own: false)
		});
		list2.Add(new InfoItem
		{
			Item = "我方技能来源",
			Value = FormatHeroPowerSource(playfield, hrtprozis, own: true)
		});
		list2.Add(new InfoItem
		{
			Item = "敌方技能来源",
			Value = FormatHeroPowerSource(playfield, hrtprozis, own: false)
		});
		list2.Add(new InfoItem
		{
			Item = "我方灌注/哈缪尔",
			Value = Playfield.Type.GetField("ownImbueCount") == null ? "内核未提供" : "灌注 " + ReadOptionalRuntimeField<int>(playfield.Inst, "ownImbueCount") + " / 哈缪尔" + (ReadOptionalRuntimeField<bool>(playfield.Inst, "ownHamuulActive") ? "已激活" : "未激活") + " / 法术进度 " + ReadOptionalRuntimeField<int>(playfield.Inst, "ownHamuulSpellProgress") + "/3"
		});
		list2.Add(new InfoItem
		{
			Item = "敌方灌注",
			Value = Playfield.Type.GetField("enemyImbueCount") == null ? "内核未提供" : "灌注 " + ReadOptionalRuntimeField<int>(playfield.Inst, "enemyImbueCount")
		});
		list2.Add(new InfoItem
		{
			Item = "我方光环",
			Value = Playfield.Type.GetField("ownAuraIDList") == null ? "内核未提供" : FormatCardIdCollection(ReadOptionalRuntimeField<object>(playfield.Inst, "ownAuraIDList"))
		});
		list2.Add(new InfoItem
		{
			Item = "我方奥秘",
			Value = FormatCardIdCollection(playfield.ownSecretsIDList)
		});
		list2.Add(new InfoItem
		{
			Item = "我方英雄附魔",
			Value = FormatCardIdCollection(minion.enchs)
		});
		list2.Add(new InfoItem
		{
			Item = "敌方英雄附魔",
			Value = FormatCardIdCollection(minion2.enchs)
		});
		if (playfield.enemyGuessDeck != "")
		{
			list2.Add(new InfoItem
			{
				Item = "猜测对手构筑",
				Value = playfield.enemyGuessDeck + "\n预计直伤: " + hrtprozis.enemyDirectDmg + " 预估伤害: " + (hrtprozis.enemyDirectDmg + playfield.calEnemyTotalAngr())
			});
		}
		GeneralInfoListBox.ItemsSource = list2;
		if (!string.IsNullOrWhiteSpace(stepKey) && playfieldActionDisplayMap.TryGetValue(stepKey, out var value))
		{
			PlayfieldActionListBox.ItemsSource = value;
		}
		else
		{
			List<ActionItem> list3 = new List<ActionItem>();
			IEnumerable enumerable2 = playfield.playactions as IEnumerable;
			IEnumerator enumerator2 = enumerable2.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				SilverfishWrapper.Action action = new SilverfishWrapper.Action(enumerator2.Current);
				list3.Add(new ActionItem
				{
					Action = action.printString(),
					Source = GetSourceOnlineImageFromAction(action),
					Target = GetTargetOnlineImageFromAction(action)
				});
			}
			PlayfieldActionListBox.ItemsSource = list3;
		}
		PlayfieldScoreLabel.Content = playfield.value;
		PlayfieldSerializedTextBox.Text = PlayfieldSerializer.Instance.SerializePlayfield(playfield);
	}

	public void UpdatePlayfieldActionList(int select = 0)
	{
		PlayfieldStepComboBox.Items.Clear();
		foreach (KeyValuePair<string, object> playfieldAction in playfieldActionList)
		{
			PlayfieldStepComboBox.Items.Add(playfieldAction.Key);
		}
		PlayfieldStepComboBox.SelectedIndex = select;
	}

	public void UpdateBestActionList(object actions)
	{
		BestActionListBox.ItemsSource = null;
		bestActionItem.Clear();
		IEnumerable enumerable = actions as IEnumerable;
		IEnumerator enumerator = enumerable.GetEnumerator();
		while (enumerator.MoveNext())
		{
			SilverfishWrapper.Action action = new SilverfishWrapper.Action(enumerator.Current);
			bestActionItem.Add(new ActionItem
			{
				Action = action.printString(),
				Source = GetSourceOnlineImageFromAction(action),
				Target = GetTargetOnlineImageFromAction(action)
			});
		}
		BestActionListBox.ItemsSource = bestActionItem;
		UpdateScoreMapList();
	}

	private void BuildVisualizationFromLatestAi()
	{
		Ai ai = new Ai(Ai.Instance);
		List<object> list = BuildBestActionObjects(ai);
		UpdateBestActionList(list);
		playfieldActionList.Clear();
		playfieldActionDisplayMap.Clear();
		actionScoreMap.Clear();
		ActionTreeView.ItemsSource = null;
		ActionScoreComboBox.Items.Clear();
		ActionScoreComboBox.SelectedIndex = -1;
		lastHighlightedScore = -1f;
		Playfield playfield = CreateCurrentPlayfieldWrapper(ai);
		ApplyEntitySnapshotOverrides(playfield, _currentEntitySnapshot);
		playfield.value = GetPlayfieldScore(ai, playfield);
		playfieldActionList["回合开始"] = playfield;
		playfieldActionDisplayMap["回合开始"] = new List<ActionItem>();
		BuildPlayfieldStepSequence(playfield, list);
		BuildCandidateActionTree(ai, playfield, list);
		UpdatePlayfieldActionList();
		DisplayCurrentPlayField(playfield.Inst, "回合开始");
		if (PlayfieldStepComboBox.Items.Count > 0)
		{
			PlayfieldStepComboBox.SelectedIndex = 0;
		}
	}

	private static Playfield CreateCurrentPlayfieldWrapper(Ai ai)
	{
		return new Playfield(Activator.CreateInstance(Playfield.Type));
	}

	private float GetPlayfieldScore(Ai ai, Playfield playfield)
	{
		try
		{
			return ai.botBase.ReflectionCall<float>("getPlayfieldValue", new object[1] { playfield.Inst });
		}
		catch
		{
			return playfield.value;
		}
	}

	private static Playfield ClonePlayfieldWrapper(Playfield source)
	{
		object inst = Activator.CreateInstance(Playfield.Type, source.Inst, false);
		return new Playfield(inst);
	}

	private List<VisualCardItem> BuildVisualMinionItems(IEnumerable source)
	{
		List<VisualCardItem> list = new List<VisualCardItem>();
		if (source == null)
		{
			return list;
		}
		foreach (object item in source)
		{
			try
			{
				Minion minion = new Minion(item);
				list.Add(new VisualCardItem
				{
					Status = FormatMinionVisualStatus(minion),
					OnlineCardImage = GetOnlineImageFromMinion(minion)
				});
			}
			catch
			{
			}
		}
		return list;
	}

	private List<VisualCardItem> BuildVisualHandItems(Playfield playfield, IEnumerable source)
	{
		List<VisualCardItem> list = new List<VisualCardItem>();
		if (source == null)
		{
			return list;
		}
		foreach (object item in source)
		{
			try
			{
				Handcard handcard = new Handcard(item);
				Card card = ((handcard.card != null) ? new Card(handcard.card) : null);
				list.Add(new VisualCardItem
				{
					Status = FormatHandcardVisualStatus(playfield, handcard, card),
					OnlineCardImage = (EnableImagePreview ? handcard.OnlineCardImage : null)
				});
			}
			catch
			{
			}
		}
		return list;
	}

	private VisualCardItem CreateVisualCardItemFromCard(Card card)
	{
		return new VisualCardItem
		{
			Status = FormatDeckCardVisualStatus(card),
			OnlineCardImage = ((!EnableImagePreview) ? null : card?.OnlineCardImage)
		};
	}

	private string GetOnlineImageFromMinion(Minion minion)
	{
		if (!EnableImagePreview || minion == null || minion.handcard == null)
		{
			return null;
		}
		try
		{
			Handcard handcard = new Handcard(minion.handcard);
			Card card = new Card(handcard.card);
			return card.OnlineCardImage;
		}
		catch
		{
			return null;
		}
	}

	private static int GetEffectiveManaCost(Playfield playfield, Card card, Handcard handcard)
	{
		if (playfield == null)
		{
			return handcard?.manacost ?? card?.cost ?? 0;
		}
		try
		{
			if (handcard != null)
			{
				return handcard.getManaCost(playfield.Inst);
			}
		}
		catch
		{
		}
		try
		{
			if (card != null)
			{
				return card.getManaCost(playfield.Inst, handcard?.manacost ?? card.cost);
			}
		}
		catch
		{
		}
		return handcard?.manacost ?? card?.cost ?? 0;
	}

	private static int GetCurrentHandcardCost(Playfield playfield, Handcard handcard, Card card)
	{
		return GetEffectiveManaCost(playfield, card, handcard);
	}

	private static int GetCurrentHandcardBaseCost(Handcard handcard, Card card)
	{
		return handcard?.manacost ?? card?.cost ?? 0;
	}

	private bool IsGigantotemCard(Card card)
	{
		if (card == null)
		{
			return false;
		}
		string a = card.cardIDenum.ToString();
		return card.cardIDenum == cardIDEnum.REV_838 || string.Equals(a, "CORE_REV_838", StringComparison.OrdinalIgnoreCase) || string.Equals(card.nameEN.ToString(), "gigantotem", StringComparison.OrdinalIgnoreCase) || string.Equals(card.nameEN.ToString(), "gigantotem_REV_838", StringComparison.OrdinalIgnoreCase);
	}

	private int CountOwnTotemsSummonedSinceInteractiveRoot()
	{
		if (_interactiveActionSteps.Count == 0)
		{
			return 0;
		}
		int num = 0;
		foreach (ManualActionStep interactiveActionStep in _interactiveActionSteps)
		{
			num += CountAddedOwnTotemMinions(interactiveActionStep.BoardBefore, interactiveActionStep.BoardAfter);
		}
		return num;
	}

	private int CountAddedOwnTotemMinions(Playfield before, Playfield after)
	{
		if (before == null || after == null)
		{
			return 0;
		}
		HashSet<int> hashSet = new HashSet<int>();
		if (before.ownMinions is IEnumerable enumerable)
		{
			foreach (object item in enumerable)
			{
				try
				{
					hashSet.Add(new Minion(item).entitiyID);
				}
				catch
				{
				}
			}
		}
		int num = 0;
		if (after.ownMinions is IEnumerable enumerable2)
		{
			foreach (object item2 in enumerable2)
			{
				try
				{
					Minion minion = new Minion(item2);
					if (hashSet.Contains(minion.entitiyID))
					{
						continue;
					}
					Card card = null;
					try
					{
						Handcard handcard = new Handcard(minion.handcard);
						if (handcard?.card != null)
						{
							card = new Card(handcard.card);
						}
					}
					catch
					{
					}
					if (card != null && card.race == Race.TOTEM)
					{
						num++;
					}
				}
				catch
				{
				}
			}
		}
		return num;
	}

	private int GetInteractiveDisplayedHandcardCost(Playfield playfield, Handcard handcard, Card card)
	{
		int currentHandcardCost = GetCurrentHandcardCost(playfield, handcard, card);
		if (playfield == null || handcard == null || card == null)
		{
			return currentHandcardCost;
		}
		if (playfield != _interactiveCurrentBoard)
		{
			return currentHandcardCost;
		}
		if (!IsGigantotemCard(card))
		{
			return currentHandcardCost;
		}
		if (!_interactiveRootHandCostByEntityId.TryGetValue(handcard.entity, out var value))
		{
			return currentHandcardCost;
		}
		int num = value - CountOwnTotemsSummonedSinceInteractiveRoot();
		if (num < 0)
		{
			num = 0;
		}
		return num;
	}

	private string FormatWeaponInfo(object weaponObject)
	{
		if (weaponObject == null)
		{
			return "无";
		}
		try
		{
			object obj = weaponObject.ReflectionGetFieldValue<object>("card");
			Card card = ((obj != null) ? new Card(obj) : null);
			string text = ((card != null) ? ResolveDisplayName(card, _cardNameLookup) : weaponObject.ReflectionGetFieldValue<object>("name")?.ToString());
			int num = weaponObject.ReflectionGetFieldValue<int>("Angr");
			int num2 = weaponObject.ReflectionGetFieldValue<int>("Durability");
			bool flag = weaponObject.ReflectionGetFieldValue<bool>("windfury");
			bool flag2 = weaponObject.ReflectionGetFieldValue<bool>("lifesteal");
			bool flag3 = weaponObject.ReflectionGetFieldValue<bool>("poisonous");
			bool flag4 = weaponObject.ReflectionGetFieldValue<bool>("immune");
			if (num2 <= 0 && num <= 0 && string.IsNullOrWhiteSpace(text))
			{
				return "无";
			}
			List<string> list = new List<string>();
			if (flag)
			{
				list.Add("风怒");
			}
			if (flag2)
			{
				list.Add("吸血");
			}
			if (flag3)
			{
				list.Add("剧毒");
			}
			if (flag4)
			{
				list.Add("免疫");
			}
			string text2 = TryFormatObjectEnchantments(weaponObject, 6);
			if (text2 != "无")
			{
				list.Add("附魔:" + text2);
			}
			string text3 = ((list.Count > 0) ? (" [" + string.Join(" / ", list) + "]") : string.Empty);
			return (string.IsNullOrWhiteSpace(text) ? "武器" : text) + " " + num + "/" + num2 + text3;
		}
		catch
		{
			return "无";
		}
	}

	private string FormatHandcardInfo(object handcardObject)
	{
		if (handcardObject == null)
		{
			return "无";
		}
		try
		{
			Handcard handcard = new Handcard(handcardObject);
			return handcard.Status;
		}
		catch
		{
			return "无";
		}
	}

	private string FormatHeroPowerInfo(Playfield playfield, Hrtprozis prozis, bool own)
	{
		if (playfield == null || prozis == null)
		{
			return "无";
		}
		try
		{
			Handcard handcard = (own ? new Handcard(playfield.ownHeroAblility) : new Handcard(playfield.enemyHeroAblility));
			Card card = ((handcard != null && handcard.card != null) ? new Card(handcard.card) : null);
			if (card == null)
			{
				return "无";
			}
			int num = (own ? prozis.ownHeroPowerCost : prozis.enemyHeroPowerCost);
			int num2 = (own ? ReadOptionalRuntimeField<int>(prozis.Inst, "ownHeroPowerFixedCost") : ReadOptionalRuntimeField<int>(prozis.Inst, "enemyHeroPowerFixedCost"));
			int val = (own ? ReadOptionalRuntimeField<int>(prozis.Inst, "ownHeroPowerCostLessOnce") : ReadOptionalRuntimeField<int>(prozis.Inst, "enemyHeroPowerCostLessOnce"));
			int val2 = 0;
			int num3 = 0;
			int num4 = 0;
			try
			{
				if (own)
				{
					val2 = playfield.ownHeroPowerCostLessOnce;
					num3 = playfield.ownHeroPowerCostLessTwice;
					num4 = ReadOptionalRuntimeField<int>(playfield.Inst, "ownHeroPowerFixedCost");
				}
				else
				{
					val2 = ReadOptionalRuntimeField<int>(playfield.Inst, "enemyHeroPowerCostLessOnce");
					num4 = ReadOptionalRuntimeField<int>(playfield.Inst, "enemyHeroPowerFixedCost");
				}
			}
			catch
			{
			}
			int num5 = ((num2 > 0) ? num2 : num4);
			int num6 = num;
			if (num5 > 0)
			{
				num6 = num5;
			}
			int num7 = Math.Max(val, val2);
			num6 -= num7;
			if (own && num3 > 0)
			{
				num6 -= 2 * num3;
			}
			if (num6 < 0)
			{
				num6 = 0;
			}
			int manacost = handcard.manacost;
			string value = ResolveDisplayName(card, _cardNameLookup);
			if (string.IsNullOrWhiteSpace(value))
			{
				value = card.cardIDenum.ToString();
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(value).Append(" [费:").Append(num6)
				.Append("]");
			if (manacost != num6)
			{
				stringBuilder.Append(" (卡面:").Append(manacost).Append(")");
			}
			if (own)
			{
				stringBuilder.Append(prozis.ownAbilityisReady ? " [可用]" : " [已用]");
				stringBuilder.Append(" 已用次数:").Append(playfield.anzUsedOwnHeroPower);
			}
			return stringBuilder.ToString();
		}
		catch
		{
			return FormatHandcardInfo(own ? playfield.ownHeroAblility : playfield.enemyHeroAblility);
		}
	}

	private string FormatCardIdCollection(object collectionObject, int maxItems = 8)
	{
		if (!(collectionObject is IEnumerable enumerable))
		{
			return "无";
		}
		List<string> list = new List<string>();
		foreach (object item in enumerable)
		{
			if (item != null)
			{
				string text = ResolveCardIdDisplayName(item);
				if (!string.IsNullOrWhiteSpace(text))
				{
					list.Add(text);
				}
			}
		}
		if (list.Count == 0)
		{
			return "无";
		}
		if (list.Count > maxItems)
		{
			return string.Join(" / ", list.Take(maxItems)) + " 等 " + list.Count + " 项";
		}
		return string.Join(" / ", list);
	}

	private string TryFormatObjectEnchantments(object source, int maxItems = 8)
	{
		if (source == null)
		{
			return "无";
		}
		try
		{
			Type type = source.GetType();
			object obj = type.GetField("enchs", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)?.GetValue(source);
			if (obj != null)
			{
				return FormatCardIdCollection(obj, maxItems);
			}
			object obj2 = type.GetProperty("enchs", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)?.GetValue(source);
			if (obj2 != null)
			{
				return FormatCardIdCollection(obj2, maxItems);
			}
			object obj3 = type.GetField("enchantments", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)?.GetValue(source);
			if (obj3 != null)
			{
				return FormatCardIdCollection(obj3, maxItems);
			}
			object obj4 = type.GetProperty("enchantments", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)?.GetValue(source);
			if (obj4 != null)
			{
				return FormatCardIdCollection(obj4, maxItems);
			}
		}
		catch
		{
		}
		return "无";
	}

	private static bool IsDefinedCardIdEnum(cardIDEnum value)
	{
		return Enum.IsDefined(typeof(cardIDEnum), value);
	}

	private static bool IsBlessingHeroPowerId(cardIDEnum value)
	{
		switch (value.ToString())
		{
		case "EDR_847p":
		case "EDR_850p":
		case "EDR_851p":
		case "EDR_445p":
		case "END_000p":
		case "EDR_448p":
		case "EDR_449p":
		case "END_003p":
			return true;
		default:
			return false;
		}
	}

	private static bool IsUsefulDisplayName(string value)
	{
		if (string.IsNullOrWhiteSpace(value))
		{
			return false;
		}
		if (string.Equals(value, "未知", StringComparison.OrdinalIgnoreCase))
		{
			return false;
		}
		int result;
		return !int.TryParse(value, out result);
	}

	private string BuildCardDebugLabel(Card card, string fallbackRaw = null)
	{
		if (card == null)
		{
			return string.IsNullOrWhiteSpace(fallbackRaw) ? null : ("未映射附魔#" + fallbackRaw);
		}
		string text = ResolveDisplayName(card, _cardNameLookup);
		string text2 = card.cardIDenum.ToString();
		string dbfId = card.dbfId;
		if (!IsUsefulDisplayName(text))
		{
			if (!string.IsNullOrWhiteSpace(fallbackRaw))
			{
				return "未映射附魔#" + fallbackRaw;
			}
			return null;
		}
		List<string> list = new List<string>();
		if (!string.IsNullOrWhiteSpace(text2) && !int.TryParse(text2, out var _))
		{
			list.Add(text2);
		}
		if (!string.IsNullOrWhiteSpace(dbfId))
		{
			list.Add(dbfId);
		}
		if (list.Count == 0)
		{
			return text;
		}
		return text + " [" + string.Join("/", list.Distinct()) + "]";
	}

	private string ResolveCardIdDisplayName(object value)
	{
		if (value == null)
		{
			return null;
		}
		string text = value.ToString();
		if (string.IsNullOrWhiteSpace(text))
		{
			return null;
		}
		if (_cardNameLookup.TryGetValue("ID:" + text, out var value2))
		{
			return value2 + " [" + text + "]";
		}
		if (_cardNameLookup.TryGetValue("CARDID:" + text, out var value3))
		{
			return value3 + " [" + text + "]";
		}
		CardDB cardDB = new CardDB(CardDB.Instance);
		if (int.TryParse(text, out var result))
		{
			try
			{
				Card card = new Card(cardDB.getCardDataFromDbfID(text));
				string text2 = BuildCardDebugLabel(card, text);
				if (!string.IsNullOrWhiteSpace(text2))
				{
					return text2;
				}
			}
			catch
			{
			}
			try
			{
				cardIDEnum id = (cardIDEnum)result;
				Card card2 = new Card(cardDB.getCardDataFromID(id));
				string text3 = BuildCardDebugLabel(card2, text);
				if (!string.IsNullOrWhiteSpace(text3))
				{
					return text3;
				}
			}
			catch
			{
			}
			return "未映射附魔#" + text;
		}
		if (Enum.TryParse<cardIDEnum>(text, out var result2))
		{
			try
			{
				Card card3 = new Card(cardDB.getCardDataFromID(result2));
				return BuildCardDebugLabel(card3, text) ?? text;
			}
			catch
			{
				return text;
			}
		}
		return text;
	}

    private static T ReadOptionalRuntimeField<T>(object instance, string name)
    {
        object value = instance?.GetType().GetField(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)?.GetValue(instance);
        return value == null ? default : ReflectionHelper.ConvertValue<T>(value);
    }

	private string FormatHeroPowerSource(Playfield playfield, Hrtprozis prozis, bool own)
	{
		Handcard handcard = (own ? new Handcard(playfield.ownHeroAblility) : new Handcard(playfield.enemyHeroAblility));
		Card card = ((handcard != null && handcard.card != null) ? new Card(handcard.card) : null);
		if (card == null)
		{
			return "无";
		}
		List<string> list = new List<string>();
		cardIDEnum cardIDenum = card.cardIDenum;
		bool flag = own && ReadOptionalRuntimeField<bool>(playfield.Inst, "ownHamuulActive");
		int num = (own ? ReadOptionalRuntimeField<int>(playfield.Inst, "ownHamuulSpellProgress") : 0);
		int num2 = (own ? ReadOptionalRuntimeField<int>(playfield.Inst, "ownImbueCount") : ReadOptionalRuntimeField<int>(playfield.Inst, "enemyImbueCount"));
		cardIDEnum cardIDEnum2 = (own ? ReadOptionalRuntimeField<cardIDEnum>(playfield.Inst, "ownStoredHeroPowerCardId") : cardIDEnum.None);
		if (IsBlessingHeroPowerId(cardIDenum))
		{
			list.Add("当前为灌注后的祝福技能");
		}
		if (flag)
		{
			list.Add("哈缪尔已激活");
			list.Add("法术进度 " + num + "/3");
		}
		if (num2 > 0)
		{
			list.Add("灌注层数 " + num2);
		}
		if (cardIDEnum2 != cardIDEnum.None && IsDefinedCardIdEnum(cardIDEnum2))
		{
			try
			{
				Card card2 = new Card(new CardDB(CardDB.Instance).getCardDataFromID(cardIDEnum2));
				string text = BuildCardDebugLabel(card2);
				if (!string.IsNullOrWhiteSpace(text))
				{
					list.Add("暂存原技能 " + text);
				}
			}
			catch
			{
			}
		}
		if (list.Count == 0)
		{
			return "基础技能或未记录特殊来源";
		}
		return string.Join(" / ", list);
	}

	private string FormatMinionVisualStatus(Minion minion)
	{
		if (minion == null)
		{
			return string.Empty;
		}
		string status = minion.Status;
		List<string> list = new List<string>();
		if (minion.Ready && !minion.cantAttack && !minion.exhausted && minion.Angr > 0)
		{
			list.Add("可攻击");
		}
		if (minion.taunt)
		{
			list.Add("嘲讽");
		}
		if (minion.divineshild)
		{
			list.Add("圣盾");
		}
		if (minion.frozen)
		{
			list.Add("冻结");
		}
		if (minion.stealth)
		{
			list.Add("潜行");
		}
		if (minion.immune)
		{
			list.Add("免疫");
		}
		if (minion.windfury)
		{
			list.Add("风怒");
		}
		if (minion.superwindfury)
		{
			list.Add("超级风怒");
		}
		if (minion.poisonous)
		{
			list.Add("剧毒");
		}
		if (minion.lifesteal)
		{
			list.Add("吸血");
		}
		if (minion.reborn)
		{
			list.Add("复生");
		}
		if (minion.Elusive)
		{
			list.Add("扰魔");
		}
		if (minion.rush > 0)
		{
			list.Add("突袭");
		}
		if (minion.charge > 0 || ReadOptionalRuntimeField<int>(minion.Inst, "nonKeywordCharge") > 0)
		{
			list.Add("冲锋");
		}
		if (minion.Aura)
		{
			list.Add("光环");
		}
		if (minion.silenced)
		{
			list.Add("沉默");
		}
		if (minion.dormant > 0)
		{
			list.Add("休眠:" + minion.dormant);
		}
		if (minion.spellpower != 0)
		{
			list.Add("法强+" + minion.spellpower);
		}
		if (minion.armor > 0)
		{
			list.Add("护甲+" + minion.armor);
		}
		string text = FormatCardIdCollection(minion.enchs, 6);
		if (text != "无")
		{
			list.Add("附魔:" + text);
		}
		if (list.Count == 0)
		{
			return status;
		}
		return status + "\n" + string.Join(" / ", list);
	}

	private string FormatHandcardVisualStatus(Playfield playfield, Handcard handcard, Card card)
	{
		if (handcard == null || card == null)
		{
			return handcard?.Status ?? string.Empty;
		}
		string text = ResolveDisplayName(card, _cardNameLookup);
		int num = card.Attack + handcard.addattack;
		int num2 = card.Health + handcard.addHp;
		int interactiveDisplayedHandcardCost = GetInteractiveDisplayedHandcardCost(playfield, handcard, card);
		int currentHandcardBaseCost = GetCurrentHandcardBaseCost(handcard, card);
		string text2 = text + " [费:" + interactiveDisplayedHandcardCost + ((interactiveDisplayedHandcardCost != currentHandcardBaseCost) ? (" 原:" + currentHandcardBaseCost) : string.Empty) + "] " + num + "/" + num2 + " [" + card.type.ToString() + "]";
		List<string> list = BuildCardKeywordTags(card);
		if (handcard.temporary)
		{
			list.Add("临时");
		}
		if (handcard.discovered)
		{
			list.Add("发现");
		}
		if (handcard.valeeraShadow)
		{
			list.Add("暗影");
		}
		if (handcard.poweredUp != 0)
		{
			list.Add("强化:" + handcard.poweredUp);
		}
		string text3 = FormatCardIdCollection(handcard.enchs, 6);
		if (text3 != "无")
		{
			list.Add("附魔:" + text3);
		}
		if (list.Count == 0)
		{
			return text2;
		}
		return text2 + "\n" + string.Join(" / ", list);
	}

	private string FormatDeckCardVisualStatus(Card card)
	{
		if (card == null)
		{
			return string.Empty;
		}
		string text = ResolveDisplayName(card, _cardNameLookup);
		string text2 = text + " [费:" + card.cost + "] " + card.Attack + "/" + card.Health + " [" + card.type.ToString() + "]";
		List<string> list = BuildCardKeywordTags(card);
		if (card.count > 1)
		{
			list.Add("数量:" + card.count);
		}
		if (list.Count == 0)
		{
			return text2;
		}
		return text2 + "\n" + string.Join(" / ", list);
	}

	private List<string> BuildCardKeywordTags(Card card)
	{
		List<string> list = new List<string>();
		if (card == null)
		{
			return list;
		}
		if (card.race != Race.INVALID && card.race != Race.BLANK)
		{
			list.Add(card.race.ToString());
		}
		if (card.Secret)
		{
			list.Add("奥秘");
		}
		if (card.Quest)
		{
			list.Add("任务");
		}
		if (card.Questline)
		{
			list.Add("任务线");
		}
		if (card.battlecry)
		{
			list.Add("战吼");
		}
		if (card.deathrattle)
		{
			list.Add("亡语");
		}
		if (card.choice)
		{
			list.Add("抉择");
		}
		if (card.discover)
		{
			list.Add("发现");
		}
		if (card.Charge)
		{
			list.Add("冲锋");
		}
		if (card.Rush)
		{
			list.Add("突袭");
		}
		if (card.windfury)
		{
			list.Add("风怒");
		}
		if (card.superwindfury)
		{
			list.Add("超级风怒");
		}
		if (card.poisonous)
		{
			list.Add("剧毒");
		}
		if (card.lifesteal)
		{
			list.Add("吸血");
		}
		if (card.reborn)
		{
			list.Add("复生");
		}
		if (card.Elusive)
		{
			list.Add("扰魔");
		}
		if (card.Stealth)
		{
			list.Add("潜行");
		}
		if (card.Titan)
		{
			list.Add("泰坦");
		}
		if (card.Forge)
		{
			list.Add("可锻造");
		}
		if (card.Forged)
		{
			list.Add("已锻造");
		}
		if (card.Quickdraw)
		{
			list.Add("快枪");
		}
		if (card.Dredge)
		{
			list.Add("探底");
		}
		if (card.Infuse)
		{
			list.Add("注能");
		}
		if (card.Infused)
		{
			list.Add("已注能");
		}
		if (card.Finale)
		{
			list.Add("压轴");
		}
		if (card.Overheal)
		{
			list.Add("过量治疗");
		}
		if (card.Spellburst)
		{
			list.Add("法术迸发");
		}
		if (card.Frenzy)
		{
			list.Add("暴怒");
		}
		if (card.HonorableKill)
		{
			list.Add("荣誉消灭");
		}
		if (card.Overkill)
		{
			list.Add("超杀");
		}
		if (card.Spellpower)
		{
			list.Add("法强");
		}
		if (card.Outcast)
		{
			list.Add("流放");
		}
		if (card.dormant > 0)
		{
			list.Add("休眠:" + card.dormant);
		}
		return list;
	}

    private static List<object> BuildBestActionObjects(Ai ai)
    {
        return RoutineRuntime.GetBestActions(ai);
    }

	private void BuildCandidateActionTree(Ai ai, Playfield currentBoard, List<object> bestPathActions)
	{
		this.actionItem = new ActionItem
		{
			Score = ai.bestmoveValue,
			Action = "当前局面",
			Board = currentBoard,
			Level = 0,
			Decision = "DarkRed"
		};
		List<CandidateActionView> list = (from candidate in GenerateCandidateActions(ai, currentBoard)
			orderby candidate.Score descending
			select candidate).Take(20).ToList();
		InfoLog("[动作树] 候选第一步动作数: " + list.Count);
		string text = ((bestPathActions.Count > 0) ? new SilverfishWrapper.Action(bestPathActions[0]).printString() : null);
		if (list.Count == 0)
		{
			WarnLog("[动作树] 候选动作为空，回退到最佳路径显示。");
			BuildBestPathFallback(ai.bestmoveValue, currentBoard, bestPathActions);
			return;
		}
		foreach (CandidateActionView item in list)
		{
			ActionItem actionItem = new ActionItem
			{
				Score = item.Score,
				Action = item.ActionWrapper.printString(),
				Source = GetSourceOnlineImageFromAction(item.ActionWrapper),
				Target = GetTargetOnlineImageFromAction(item.ActionWrapper),
				Father = this.actionItem,
				Board = item.Board,
				Level = 1,
				Decision = "DarkRed"
			};
			this.actionItem.subGroups.Add(actionItem);
			actionScoreMap[item.Score] = new List<ActionItem> { this.actionItem, actionItem };
			if (!string.IsNullOrWhiteSpace(text) && string.Equals(actionItem.Action, text, StringComparison.Ordinal))
			{
				AppendBestPathToCandidate(actionItem, bestPathActions.Skip(1).ToList(), ai.bestmoveValue);
				actionScoreMap[item.Score] = FlattenPath(actionItem);
			}
		}
		ActionTreeView.ItemsSource = this.actionItem.Items;
		UpdateScoreMapList();
	}

	private void BuildBestPathFallback(float bestScoreValue, Playfield currentBoard, List<object> bestPathActions)
	{
		List<ActionItem> list = new List<ActionItem> { this.actionItem };
		ActionItem actionItem = this.actionItem;
		foreach (object bestPathAction in bestPathActions)
		{
			SilverfishWrapper.Action action = new SilverfishWrapper.Action(bestPathAction);
			ActionItem actionItem2 = new ActionItem
			{
				Score = bestScoreValue,
				Action = action.printString(),
				Source = GetSourceOnlineImageFromAction(action),
				Target = GetTargetOnlineImageFromAction(action),
				Father = actionItem,
				Board = currentBoard,
				Level = actionItem.Level + 1,
				Decision = "DarkRed"
			};
			actionItem.subGroups.Add(actionItem2);
			actionItem = actionItem2;
			list.Add(actionItem2);
		}
		actionScoreMap[bestScoreValue] = list;
		ActionTreeView.ItemsSource = this.actionItem.Items;
		UpdateScoreMapList();
	}

	private void BuildPlayfieldStepSequence(Playfield currentBoard, List<object> actionObjects)
	{
		Playfield source = currentBoard;
		List<ActionItem> list = new List<ActionItem>();
		for (int i = 0; i < actionObjects.Count; i++)
		{
			SilverfishWrapper.Action action = new SilverfishWrapper.Action(actionObjects[i]);
			list.Add(new ActionItem
			{
				Action = action.printString(),
				Source = GetSourceOnlineImageFromAction(action),
				Target = GetTargetOnlineImageFromAction(action)
			});
			try
			{
				Playfield playfield = ClonePlayfieldWrapper(source);
				playfield.doAction(action.Inst);
				string key = "第" + (i + 1) + "步";
				playfieldActionList[key] = playfield;
				playfieldActionDisplayMap[key] = list.Select((ActionItem item) => new ActionItem
				{
					Action = item.Action,
					Source = item.Source,
					Target = item.Target
				}).ToList();
				source = playfield;
			}
			catch (Exception ex)
			{
				WarnLog("[可视化] 构建第 " + (i + 1) + " 步牌面失败: " + ex.Message);
				break;
			}
		}
	}

	private void AppendBestPathToCandidate(ActionItem parent, List<object> remainingActions, float bestScoreValue)
	{
		ActionItem actionItem = parent;
		foreach (object remainingAction in remainingActions)
		{
			SilverfishWrapper.Action action = new SilverfishWrapper.Action(remainingAction);
			ActionItem actionItem2 = new ActionItem
			{
				Score = bestScoreValue,
				Action = action.printString(),
				Source = GetSourceOnlineImageFromAction(action),
				Target = GetTargetOnlineImageFromAction(action),
				Father = actionItem,
				Board = actionItem.Board,
				Level = actionItem.Level + 1,
				Decision = "DarkRed"
			};
			actionItem.subGroups.Add(actionItem2);
			actionItem = actionItem2;
		}
	}

	private List<CandidateActionView> GenerateCandidateActions(Ai ai, Playfield currentBoard)
	{
		List<CandidateActionView> list = new List<CandidateActionView>();
		try
		{
			object obj = compiledRoutines.GetType("HREngine.Bots.Movegenerator")?.GetProperty("Instance", BindingFlags.Static | BindingFlags.Public)?.GetValue(null);
			object obj2 = obj.ReflectionCall<object>("getMoveList", new object[4] { currentBoard.Inst, true, true, true });
			if (!(obj2 is IEnumerable enumerable))
			{
				return list;
			}
			foreach (object item in enumerable)
			{
				if (item != null)
				{
					SilverfishWrapper.Action actionWrapper = new SilverfishWrapper.Action(item);
					Playfield playfield = ClonePlayfieldWrapper(currentBoard);
					playfield.doAction(item);
					float playfieldScore = GetPlayfieldScore(ai, playfield);
					list.Add(new CandidateActionView
					{
						ActionObject = item,
						ActionWrapper = actionWrapper,
						Board = playfield,
						Score = playfieldScore
					});
				}
			}
		}
		catch (Exception ex)
		{
			WarnLog("[动作树] 生成候选动作失败: " + ex.Message);
		}
		return list;
	}

	private bool EnsureInteractiveAiFixBoardLoaded()
	{
		if (!TryGetSelectedTestContext(out var testFilePath, out var behaviorName))
		{
			return false;
		}
		if (!string.Equals(testFilePath, _lastExecutedTestFilePath, StringComparison.OrdinalIgnoreCase) || !string.Equals(behaviorName, _lastExecutedBehaviorName, StringComparison.OrdinalIgnoreCase) || _lastTestSummary == null)
		{
			InfoLog("[交互修伏笔] 当前牌面还没有最新测试结果，先执行一次测试。");
			if (!RunSelectedTestInternal(testFilePath, behaviorName, verboseLogging: false))
			{
				return false;
			}
		}
		Ai ai = new Ai(Ai.Instance);
		_interactiveRootBoard = CreateCurrentPlayfieldWrapper(ai);
		_interactiveRootBoard.value = GetPlayfieldScore(ai, _interactiveRootBoard);
		ApplyEntitySnapshotOverrides(_interactiveRootBoard, _currentEntitySnapshot);
		_interactiveRootHandCostByEntityId.Clear();
		if (_interactiveRootBoard.owncards is IEnumerable enumerable)
		{
			foreach (object item in enumerable)
			{
				try
				{
					Handcard handcard = new Handcard(item);
					_interactiveRootHandCostByEntityId[handcard.entity] = handcard.manacost;
				}
				catch
				{
				}
			}
		}
		_interactiveCurrentBoard = _interactiveRootBoard;
		_interactiveSelectedSource = null;
		_interactiveSelectedTarget = null;
		_interactiveSelectedSpecialSource = InteractiveSpecialSourceKind.None;
		_interactiveSelectedPreferredPlace = null;
		_interactiveActionSteps.Clear();
		_interactiveCandidateItems.Clear();
		_currentManualActionScript = string.Empty;
		RefreshInteractiveAiFixBoard();
		SuccessLog("[交互修伏笔] 已加载当前回合起始局面。");
		return true;
	}

	private static void ApplyEntitySnapshotOverrides(Playfield playfield, string entitySnapshot)
	{
		if (playfield == null || string.IsNullOrWhiteSpace(entitySnapshot))
		{
			return;
		}
		if (TryExtractHeroPowerCostFromEntitySnapshot(entitySnapshot, friendly: true, out var cost))
		{
			try
			{
				Handcard handcard = new Handcard(playfield.ownHeroAblility);
				handcard.manacost = cost;
			}
			catch
			{
			}
			try
			{
				Hrtprozis hrtprozis = new Hrtprozis(playfield.prozis);
				hrtprozis.ownHeroPowerCost = cost;
			}
			catch
			{
			}
		}
		if (TryExtractHeroPowerCostFromEntitySnapshot(entitySnapshot, friendly: false, out var cost2))
		{
			try
			{
				Handcard handcard2 = new Handcard(playfield.enemyHeroAblility);
				handcard2.manacost = cost2;
			}
			catch
			{
			}
			try
			{
				Hrtprozis hrtprozis2 = new Hrtprozis(playfield.prozis);
				hrtprozis2.enemyHeroPowerCost = cost2;
			}
			catch
			{
			}
		}
		try
		{
			Dictionary<int, int> dictionary = ExtractHandEntityCostMapFromEntitySnapshot(entitySnapshot, friendly: true);
			if (dictionary.Count <= 0 || !(playfield.owncards is IEnumerable enumerable))
			{
				return;
			}
			foreach (object item in enumerable)
			{
				try
				{
					Handcard handcard3 = new Handcard(item);
					if (dictionary.TryGetValue(handcard3.entity, out var value))
					{
						handcard3.manacost = value;
					}
				}
				catch
				{
				}
			}
		}
		catch
		{
		}
	}

	private static bool TryExtractHeroPowerCostFromEntitySnapshot(string entitySnapshot, bool friendly, out int cost)
	{
		cost = 0;
		if (string.IsNullOrWhiteSpace(entitySnapshot))
		{
			return false;
		}
		string b = (friendly ? "[Friendly]" : "[Opposing]");
		bool flag = false;
		string[] array = entitySnapshot.Split(new string[2] { "\r\n", "\n" }, StringSplitOptions.None);
		string[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			string text = array2[i]?.Trim();
			if (string.IsNullOrWhiteSpace(text))
			{
				continue;
			}
			if (IsEntitySnapshotSectionHeader(text))
			{
				flag = string.Equals(text, b, StringComparison.OrdinalIgnoreCase);
			}
			else if (flag && text.StartsWith("heroPower:", StringComparison.OrdinalIgnoreCase))
			{
				Match match = Regex.Match(text, "\\bcost=(\\d+)\\b");
				if (!match.Success)
				{
					return false;
				}
				if (!int.TryParse(match.Groups[1].Value, out cost))
				{
					return false;
				}
				return true;
			}
		}
		return false;
	}

	private static Dictionary<int, int> ExtractHandEntityCostMapFromEntitySnapshot(string entitySnapshot, bool friendly)
	{
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		if (string.IsNullOrWhiteSpace(entitySnapshot))
		{
			return dictionary;
		}
		string b = (friendly ? "[Friendly]" : "[Opposing]");
		bool flag = false;
		bool flag2 = false;
		string[] array = entitySnapshot.Split(new string[2] { "\r\n", "\n" }, StringSplitOptions.None);
		string[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			string text = array2[i]?.Trim();
			if (string.IsNullOrWhiteSpace(text))
			{
				continue;
			}
			if (IsEntitySnapshotSectionHeader(text))
			{
				flag = string.Equals(text, b, StringComparison.OrdinalIgnoreCase);
				flag2 = false;
			}
			else
			{
				if (!flag)
				{
					continue;
				}
				if (text.StartsWith("hand:", StringComparison.OrdinalIgnoreCase))
				{
					flag2 = true;
				}
				else
				{
					if (!flag2)
					{
						continue;
					}
					if (!text.StartsWith("[", StringComparison.Ordinal) && !text.StartsWith("controller=", StringComparison.OrdinalIgnoreCase))
					{
						Match match = Regex.Match(text, "entity=(\\d+).*?\\bcost=(\\d+)\\b");
						if (match.Success && int.TryParse(match.Groups[1].Value, out var result) && int.TryParse(match.Groups[2].Value, out var result2))
						{
							dictionary[result] = result2;
							continue;
						}
					}
					if (text.StartsWith("deck:", StringComparison.OrdinalIgnoreCase) || text.StartsWith("board:", StringComparison.OrdinalIgnoreCase) || text.StartsWith("secrets:", StringComparison.OrdinalIgnoreCase) || text.StartsWith("quests:", StringComparison.OrdinalIgnoreCase) || text.StartsWith("graveyard:", StringComparison.OrdinalIgnoreCase))
					{
						flag2 = false;
					}
				}
			}
		}
		return dictionary;
	}

	private static bool IsEntitySnapshotSectionHeader(string line)
	{
		return string.Equals(line, "[ResolvedBoard]", StringComparison.OrdinalIgnoreCase) || string.Equals(line, "[Friendly]", StringComparison.OrdinalIgnoreCase) || string.Equals(line, "[Opposing]", StringComparison.OrdinalIgnoreCase);
	}

	private void RefreshInteractiveAiFixBoard()
	{
		if (_interactiveCurrentBoard == null)
		{
			AiFixOwnHandListBox.ItemsSource = null;
			AiFixOwnBoardListBox.ItemsSource = null;
			AiFixEnemyBoardListBox.ItemsSource = null;
			AiFixCandidateActionListBox.ItemsSource = null;
			AiFixManualActionListBox.ItemsSource = null;
			AiFixActionChangeTextBox.Text = string.Empty;
			AiFixManualActionScriptTextBox.Text = string.Empty;
			InteractiveAiFixStatusLabel.Content = "点击“加载当前回合”后开始交互。";
			RefreshInteractiveAiFixSpecialActions();
			return;
		}
		_suppressInteractiveSelectionChanged = true;
		try
		{
			AiFixOwnHandListBox.ItemsSource = BuildInteractiveHandItems(_interactiveCurrentBoard);
			AiFixOwnBoardListBox.ItemsSource = BuildInteractiveBoardItems(_interactiveCurrentBoard, own: true);
			AiFixEnemyBoardListBox.ItemsSource = BuildInteractiveBoardItems(_interactiveCurrentBoard, own: false);
			AiFixOwnHandListBox.SelectedItem = null;
			AiFixOwnBoardListBox.SelectedItem = null;
			AiFixEnemyBoardListBox.SelectedItem = null;
		}
		finally
		{
			_suppressInteractiveSelectionChanged = false;
		}
		RebuildInteractiveCandidates();
		UpdateInteractiveEntityVisualHints();
		RefreshInteractiveAiFixSpecialActions();
		AiFixManualActionListBox.ItemsSource = null;
		AiFixManualActionListBox.ItemsSource = _interactiveActionSteps.ToList();
		UpdateManualActionScript();
		UpdateInteractiveStatus();
	}

	private void RebuildInteractiveCandidates()
	{
		_interactiveCandidateItems.Clear();
		_interactiveLegalSourceEntityIds.Clear();
		_interactiveLegalTargetEntityIds.Clear();
		_interactiveCandidateTotalCount = 0;
		_interactiveCanUseHeroPower = false;
		_interactiveCanEndTurn = false;
		_interactiveAllCandidates = new List<CandidateActionView>();
		if (_interactiveCurrentBoard == null)
		{
			AiFixCandidateActionListBox.ItemsSource = null;
			return;
		}
		Ai ai = new Ai(Ai.Instance);
		List<CandidateActionView> list = GenerateCandidateActions(ai, _interactiveCurrentBoard);
		_interactiveCandidateTotalCount = list.Count;
		_interactiveAllCandidates = list;
		foreach (CandidateActionView item in list)
		{
			if (item?.ActionWrapper == null)
			{
				continue;
			}
			if (item.ActionWrapper.actionType == actionEnum.useHeroPower)
			{
				_interactiveCanUseHeroPower = true;
			}
			if (item.ActionWrapper.actionType == actionEnum.endturn)
			{
				_interactiveCanEndTurn = true;
			}
			int actionSourceEntityId = GetActionSourceEntityId(item.ActionWrapper);
			if (actionSourceEntityId != 0)
			{
				_interactiveLegalSourceEntityIds.Add(actionSourceEntityId);
			}
			bool flag = true;
			if (_interactiveSelectedPreferredPlace.HasValue)
			{
				flag = item.ActionWrapper.actionType == actionEnum.playcard && item.ActionWrapper.place == _interactiveSelectedPreferredPlace.Value;
			}
			if (!(_interactiveSelectedSource != null && actionSourceEntityId == _interactiveSelectedSource.EntityId && flag) && (_interactiveSelectedSpecialSource != InteractiveSpecialSourceKind.HeroPower || item.ActionWrapper.actionType != actionEnum.useHeroPower))
			{
				continue;
			}
			foreach (int actionTargetEntityId in GetActionTargetEntityIds(item.ActionWrapper))
			{
				if (actionTargetEntityId != 0)
				{
					_interactiveLegalTargetEntityIds.Add(actionTargetEntityId);
				}
			}
		}
		int num = 0;
		IEnumerable<CandidateActionView> enumerable = list.OrderByDescending((CandidateActionView item) => item.Score);
		if (_interactiveSelectedSpecialSource == InteractiveSpecialSourceKind.HeroPower)
		{
			enumerable = enumerable.Where((CandidateActionView item) => item != null && item.ActionWrapper?.actionType == actionEnum.useHeroPower);
		}
		if (_interactiveSelectedPreferredPlace.HasValue)
		{
			enumerable = enumerable.Where((CandidateActionView item) => item != null && item.ActionWrapper?.actionType == actionEnum.playcard && item.ActionWrapper.place == _interactiveSelectedPreferredPlace.Value);
		}
		foreach (CandidateActionView item2 in enumerable)
		{
			InteractiveCandidateItem interactiveCandidateItem = BuildInteractiveCandidateItem(item2);
			if (interactiveCandidateItem == null || (_interactiveSelectedSource != null && interactiveCandidateItem.SourceEntityId != _interactiveSelectedSource.EntityId) || (_interactiveSelectedTarget != null && (interactiveCandidateItem.TargetEntityIds == null || !interactiveCandidateItem.TargetEntityIds.Contains(_interactiveSelectedTarget.EntityId))))
			{
				continue;
			}
			if (_interactiveSelectedSpecialSource == InteractiveSpecialSourceKind.HeroPower)
			{
				CandidateActionView candidate = interactiveCandidateItem.Candidate;
				if (candidate == null || candidate.ActionWrapper?.actionType != actionEnum.useHeroPower)
				{
					continue;
				}
			}
			if (_interactiveSelectedPreferredPlace.HasValue)
			{
				CandidateActionView candidate2 = interactiveCandidateItem.Candidate;
				if (candidate2 == null || candidate2.ActionWrapper?.actionType != actionEnum.playcard || interactiveCandidateItem.Candidate.ActionWrapper.place != _interactiveSelectedPreferredPlace.Value)
				{
					continue;
				}
			}
			_interactiveCandidateItems.Add(interactiveCandidateItem);
			num++;
			if (num < 250)
			{
				continue;
			}
			break;
		}
		AiFixCandidateActionListBox.ItemsSource = null;
		AiFixCandidateActionListBox.ItemsSource = _interactiveCandidateItems;
		if (_interactiveCandidateItems.Count > 0)
		{
			AiFixCandidateActionListBox.SelectedIndex = 0;
		}
		else
		{
			AiFixActionChangeTextBox.Text = string.Empty;
		}
	}

	private void UpdateInteractiveEntityVisualHints()
	{
		List<InteractiveEntityItem> list = new List<InteractiveEntityItem>();
		IEnumerable itemsSource = AiFixOwnHandListBox.ItemsSource;
		if (itemsSource != null)
		{
			foreach (object item4 in itemsSource)
			{
				if (item4 is InteractiveEntityItem item)
				{
					list.Add(item);
				}
			}
		}
		IEnumerable itemsSource2 = AiFixOwnBoardListBox.ItemsSource;
		if (itemsSource2 != null)
		{
			foreach (object item5 in itemsSource2)
			{
				if (item5 is InteractiveEntityItem item2)
				{
					list.Add(item2);
				}
			}
		}
		IEnumerable itemsSource3 = AiFixEnemyBoardListBox.ItemsSource;
		if (itemsSource3 != null)
		{
			foreach (object item6 in itemsSource3)
			{
				if (item6 is InteractiveEntityItem item3)
				{
					list.Add(item3);
				}
			}
		}
		foreach (InteractiveEntityItem item7 in list)
		{
			bool isSelectedAsSource = _interactiveSelectedSource != null && item7.EntityId == _interactiveSelectedSource.EntityId;
			bool isSelectedAsTarget = _interactiveSelectedTarget != null && item7.EntityId == _interactiveSelectedTarget.EntityId;
			item7.IsSelectedAsSource = isSelectedAsSource;
			item7.IsSelectedAsTarget = isSelectedAsTarget;
			item7.IsCandidateSource = _interactiveLegalSourceEntityIds.Contains(item7.EntityId);
			item7.IsCandidateTarget = (_interactiveSelectedSource != null || _interactiveSelectedSpecialSource != InteractiveSpecialSourceKind.None) && _interactiveLegalTargetEntityIds.Contains(item7.EntityId);
			bool flag = item7.Kind == InteractiveEntityKind.EnemyHero || item7.Kind == InteractiveEntityKind.EnemyMinion || item7.Kind == InteractiveEntityKind.EnemyWeapon || item7.Kind == InteractiveEntityKind.EnemySecret || item7.Kind == InteractiveEntityKind.EnemyQuest;
			bool isSelectable = ((_interactiveSelectedSource == null && _interactiveSelectedSpecialSource == InteractiveSpecialSourceKind.None) ? (!flag && item7.IsCandidateSource) : ((!flag) ? (item7.IsCandidateSource || item7.IsCandidateTarget || item7.IsSelectedAsSource || item7.IsSelectedAsTarget) : (item7.IsCandidateTarget || item7.IsSelectedAsTarget)));
			item7.IsSelectable = isSelectable;
		}
	}

	private void RefreshInteractiveAiFixSpecialActions()
	{
		if (_interactiveCurrentBoard == null)
		{
			if (AiFixHeroPowerCard != null)
			{
				AiFixHeroPowerCard.Opacity = 0.4;
				AiFixHeroPowerCard.IsEnabled = false;
			}
			if (AiFixEndTurnButton != null)
			{
				AiFixEndTurnButton.IsEnabled = false;
			}
			return;
		}
		int num = 0;
		int num2 = 0;
		int val = 0;
		int val2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		bool flag = false;
		string text = "英雄技能";
		try
		{
			Hrtprozis hrtprozis = new Hrtprozis(_interactiveCurrentBoard.prozis);
			num2 = hrtprozis.ownHeroPowerCost;
			val = ReadOptionalRuntimeField<int>(hrtprozis.Inst, "ownHeroPowerCostLessOnce");
			num4 = ReadOptionalRuntimeField<int>(hrtprozis.Inst, "ownHeroPowerFixedCost");
			flag = hrtprozis.ownAbilityisReady;
			Handcard handcard = new Handcard(_interactiveCurrentBoard.ownHeroAblility);
			int manacost = handcard.manacost;
			Card card = ((handcard != null && handcard.card != null) ? new Card(handcard.card) : null);
			if (AiFixHeroPowerImage != null)
			{
				AiFixHeroPowerImage.Source = BuildImageSourceFromPathOrUrl(card?.OnlineCardImage);
			}
			if (AiFixHeroPowerNameTextBlock != null)
			{
				text = ((card != null) ? ResolveDisplayName(card, _cardNameLookup) : "英雄技能");
				num2 = manacost;
			}
		}
		catch
		{
			if (AiFixHeroPowerNameTextBlock != null)
			{
				AiFixHeroPowerNameTextBlock.Text = "英雄技能";
			}
		}
		try
		{
			val2 = _interactiveCurrentBoard.ownHeroPowerCostLessOnce;
			num3 = _interactiveCurrentBoard.ownHeroPowerCostLessTwice;
			num5 = ReadOptionalRuntimeField<int>(_interactiveCurrentBoard.Inst, "ownHeroPowerFixedCost");
		}
		catch
		{
		}
		int num6 = 0;
		try
		{
			num6 = new Hrtprozis(_interactiveCurrentBoard.prozis).ownHeroPowerCost;
		}
		catch
		{
		}
		int num7 = ((num4 > 0) ? num4 : num5);
		int num8 = Math.Max(val, val2);
		num = num6;
		if (num7 > 0)
		{
			num = num7;
		}
		num -= num8;
		if (num3 > 0)
		{
			num -= 2 * num3;
		}
		if (num < 0)
		{
			num = 0;
		}
		if (AiFixHeroPowerNameTextBlock != null)
		{
			AiFixHeroPowerNameTextBlock.Text = text + " " + num + "费";
		}
		if (AiFixHeroPowerCard != null)
		{
			AiFixHeroPowerCard.IsEnabled = _interactiveCanUseHeroPower;
			AiFixHeroPowerCard.Opacity = (_interactiveCanUseHeroPower ? 1.0 : 0.35);
			AiFixHeroPowerCard.BorderBrush = ((_interactiveSelectedSpecialSource == InteractiveSpecialSourceKind.HeroPower) ? Brushes.LimeGreen : ((Brush)new BrushConverter().ConvertFromString("#22000000")));
			string text2 = (flag ? "可用" : "已用/不可用");
			string text3 = $"费用: {num} (卡面 {num2}, base {num6}, lessOnce {num8}, less2x {num3}, fixed {num7})";
			AiFixHeroPowerCard.ToolTip = text + "\n" + text3 + "\n状态: " + text2 + "\n提示: 点击无目标技能可直接放；需要目标请拖到目标上。";
		}
		if (AiFixEndTurnButton != null)
		{
			AiFixEndTurnButton.IsEnabled = _interactiveCanEndTurn;
		}
	}

	private static ImageSource BuildImageSourceFromPathOrUrl(string pathOrUrl)
	{
		if (string.IsNullOrWhiteSpace(pathOrUrl))
		{
			return null;
		}
		try
		{
			return new BitmapImage(new Uri(pathOrUrl, UriKind.RelativeOrAbsolute));
		}
		catch
		{
			return null;
		}
	}

	private InteractiveCandidateItem BuildInteractiveCandidateItem(CandidateActionView candidate)
	{
		if (candidate == null || candidate.ActionWrapper == null)
		{
			return null;
		}
		SilverfishWrapper.Action actionWrapper = candidate.ActionWrapper;
		return new InteractiveCandidateItem
		{
			Candidate = candidate,
			Action = actionWrapper.printString(),
			ChangeSummary = BuildBoardChangeSummary(_interactiveCurrentBoard, candidate.Board),
			Source = GetActionSourceLabel(actionWrapper),
			Target = GetActionTargetLabel(actionWrapper),
			SourceImage = GetSourceOnlineImageFromAction(actionWrapper),
			TargetImage = GetTargetOnlineImageFromAction(actionWrapper),
			SourceEntityId = GetActionSourceEntityId(actionWrapper),
			TargetEntityIds = GetActionTargetEntityIds(actionWrapper)
		};
	}

	private List<InteractiveEntityItem> BuildInteractiveHandItems(Playfield playfield)
	{
		List<InteractiveEntityItem> list = new List<InteractiveEntityItem>();
		if (!(playfield?.owncards is IEnumerable enumerable))
		{
			return list;
		}
		foreach (object item in enumerable)
		{
			try
			{
				Handcard handcard = new Handcard(item);
				Card card = ((handcard.card != null) ? new Card(handcard.card) : null);
				list.Add(new InteractiveEntityItem
				{
					EntityId = handcard.entity,
					Kind = InteractiveEntityKind.OwnHand,
					Status = FormatHandcardVisualStatus(playfield, handcard, card),
					OnlineCardImage = (EnableImagePreview ? handcard.OnlineCardImage : null)
				});
			}
			catch
			{
			}
		}
		return list;
	}

	private List<InteractiveEntityItem> BuildInteractiveBoardItems(Playfield playfield, bool own)
	{
		List<InteractiveEntityItem> list = new List<InteractiveEntityItem>();
		if (playfield == null)
		{
			return list;
		}
		try
		{
			Minion minion = new Minion(own ? playfield.ownHero : playfield.enemyHero);
			list.Add(new InteractiveEntityItem
			{
				EntityId = minion.entitiyID,
				Kind = (own ? InteractiveEntityKind.OwnHero : InteractiveEntityKind.EnemyHero),
				Status = FormatHeroInteractiveStatus(playfield, minion, own),
				OnlineCardImage = GetOnlineImageFromMinion(minion)
			});
		}
		catch
		{
		}
		try
		{
			InteractiveEntityItem interactiveEntityItem = BuildInteractiveWeaponItem(playfield, own);
			if (interactiveEntityItem != null)
			{
				list.Add(interactiveEntityItem);
			}
		}
		catch
		{
		}
		try
		{
			list.AddRange(BuildInteractiveSecretItems(playfield, own));
		}
		catch
		{
		}
		try
		{
			list.AddRange(BuildInteractiveQuestItems(playfield, own));
		}
		catch
		{
		}
		if (!((own ? playfield.ownMinions : playfield.enemyMinions) is IEnumerable enumerable))
		{
			return list;
		}
		foreach (object item in enumerable)
		{
			try
			{
				Minion minion2 = new Minion(item);
				list.Add(new InteractiveEntityItem
				{
					EntityId = minion2.entitiyID,
					Kind = (own ? InteractiveEntityKind.OwnMinion : InteractiveEntityKind.EnemyMinion),
					Status = FormatMinionVisualStatus(minion2),
					OnlineCardImage = GetOnlineImageFromMinion(minion2)
				});
			}
			catch
			{
			}
		}
		return list;
	}

	private InteractiveEntityItem BuildInteractiveWeaponItem(Playfield playfield, bool own)
	{
		object obj = ((!own) ? playfield?.enemyWeapon : playfield?.ownWeapon);
		if (obj == null)
		{
			return null;
		}
		try
		{
			int num = obj.ReflectionGetFieldValue<int>("Angr");
			int num2 = obj.ReflectionGetFieldValue<int>("Durability");
			object obj2 = obj.ReflectionGetFieldValue<object>("card");
			Card card = ((obj2 != null) ? new Card(obj2) : null);
			string text = ((card != null) ? ResolveDisplayName(card, _cardNameLookup) : obj.ReflectionGetFieldValue<object>("name")?.ToString());
			if (string.IsNullOrWhiteSpace(text))
			{
				text = "武器";
			}
			if (num <= 0 && num2 <= 0 && card == null)
			{
				return null;
			}
			int entityId = 0;
			try
			{
				entityId = obj.ReflectionGetFieldValue<int>("entity");
			}
			catch
			{
			}
			InteractiveEntityItem interactiveEntityItem = new InteractiveEntityItem();
			interactiveEntityItem.EntityId = entityId;
			interactiveEntityItem.Kind = (own ? InteractiveEntityKind.OwnWeapon : InteractiveEntityKind.EnemyWeapon);
			interactiveEntityItem.Status = text + "\n[武器] " + num + "/" + num2;
			interactiveEntityItem.OnlineCardImage = ((!EnableImagePreview) ? null : card?.OnlineCardImage);
			return interactiveEntityItem;
		}
		catch
		{
			return null;
		}
	}

	private List<InteractiveEntityItem> BuildInteractiveSecretItems(Playfield playfield, bool own)
	{
		List<InteractiveEntityItem> list = new List<InteractiveEntityItem>();
		if (playfield == null)
		{
			return list;
		}
		if (!own)
		{
			int num = 0;
			try
			{
				num = playfield.enemySecretCount;
			}
			catch
			{
			}
			if (num <= 0)
			{
				return list;
			}
			list.Add(new InteractiveEntityItem
			{
				EntityId = 0,
				Kind = InteractiveEntityKind.EnemySecret,
				Status = "奥秘\n敌方 x" + num,
				OnlineCardImage = null
			});
			return list;
		}
		try
		{
			if (!(playfield.ownSecretsIDList is IEnumerable enumerable))
			{
				return list;
			}
			CardDB cardDB = new CardDB(CardDB.Instance);
			foreach (object item in enumerable)
			{
				try
				{
					if (item is cardIDEnum id)
					{
						Card card = new Card(cardDB.getCardDataFromID(id));
						string text = ResolveDisplayName(card, _cardNameLookup);
						list.Add(new InteractiveEntityItem
						{
							EntityId = 0,
							Kind = InteractiveEntityKind.OwnSecret,
							Status = (string.IsNullOrWhiteSpace(text) ? id.ToString() : text) + "\n[奥秘]",
							OnlineCardImage = (EnableImagePreview ? card.OnlineCardImage : null)
						});
					}
				}
				catch
				{
				}
			}
		}
		catch
		{
		}
		return list;
	}

	private List<InteractiveEntityItem> BuildInteractiveQuestItems(Playfield playfield, bool own)
	{
		List<InteractiveEntityItem> list = new List<InteractiveEntityItem>();
		if (playfield == null)
		{
			return list;
		}
		CardDB cardDB = new CardDB(CardDB.Instance);
		try
		{
			QuestItem questItem = new QuestItem(own ? playfield.ownQuest : playfield.enemyQuest);
			if (questItem != null && questItem.Id != cardIDEnum.None)
			{
				Card card = new Card(cardDB.getCardDataFromID(questItem.Id));
				string text = ResolveDisplayName(card, _cardNameLookup);
				list.Add(new InteractiveEntityItem
				{
					EntityId = 0,
					Kind = (own ? InteractiveEntityKind.OwnQuest : InteractiveEntityKind.EnemyQuest),
					Status = (string.IsNullOrWhiteSpace(text) ? questItem.Id.ToString() : text) + "\n[任务] " + questItem.questProgress + "/" + questItem.maxProgress,
					OnlineCardImage = (EnableImagePreview ? card.OnlineCardImage : null)
				});
			}
		}
		catch
		{
		}
		if (own)
		{
			try
			{
				QuestItem questItem2 = new QuestItem(playfield.sideQuest);
				if (questItem2 != null && questItem2.Id != cardIDEnum.None)
				{
					Card card2 = new Card(cardDB.getCardDataFromID(questItem2.Id));
					string text2 = ResolveDisplayName(card2, _cardNameLookup);
					list.Add(new InteractiveEntityItem
					{
						EntityId = 0,
						Kind = InteractiveEntityKind.OwnSideQuest,
						Status = (string.IsNullOrWhiteSpace(text2) ? questItem2.Id.ToString() : text2) + "\n[支线任务] " + questItem2.questProgress + "/" + questItem2.maxProgress,
						OnlineCardImage = (EnableImagePreview ? card2.OnlineCardImage : null)
					});
				}
			}
			catch
			{
			}
		}
		return list;
	}

	private string FormatHeroInteractiveStatus(Playfield playfield, Minion hero, bool own)
	{
		if (playfield == null || hero == null)
		{
			return string.Empty;
		}
		string text = (own ? playfield.ownHeroName.ToString() : playfield.enemyHeroName.ToString()) + " [英雄] " + hero.Hp + "+" + hero.armor;
		List<string> list = new List<string>();
		if (hero.Ready && hero.Angr > 0 && !hero.exhausted)
		{
			list.Add("可攻击");
		}
		if (hero.immune)
		{
			list.Add("免疫");
		}
		if (hero.frozen)
		{
			list.Add("冻结");
		}
		if (hero.stealth)
		{
			list.Add("潜行");
		}
		if (hero.windfury)
		{
			list.Add("风怒");
		}
		if (hero.spellpower != 0)
		{
			list.Add("法强+" + hero.spellpower);
		}
		string text2 = FormatCardIdCollection(hero.enchs, 6);
		if (text2 != "无")
		{
			list.Add("附魔:" + text2);
		}
		if (list.Count == 0)
		{
			return text;
		}
		return text + "\n" + string.Join(" / ", list);
	}

	private void UpdateInteractiveStatus()
	{
		string text = ((_interactiveSelectedSource == null) ? "未选来源" : ("来源#" + _interactiveSelectedSource.EntityId + " " + BuildInteractiveEntityShortLabel(_interactiveSelectedSource)));
		string text2 = ((_interactiveSelectedTarget == null) ? "未选目标" : ("目标#" + _interactiveSelectedTarget.EntityId + " " + BuildInteractiveEntityShortLabel(_interactiveSelectedTarget)));
		string text3 = (_interactiveSelectedPreferredPlace.HasValue ? ("位置锁定 " + _interactiveSelectedPreferredPlace.Value) : null);
		InteractiveAiFixStatusLabel.Content = text + " | " + text2 + (string.IsNullOrWhiteSpace(text3) ? string.Empty : (" | " + text3)) + " | 候选动作 " + _interactiveCandidateItems.Count + " | 已选动作 " + _interactiveActionSteps.Count;
	}

	private string BuildInteractiveEntityShortLabel(InteractiveEntityItem item)
	{
		if (item == null || string.IsNullOrWhiteSpace(item.Status))
		{
			return string.Empty;
		}
		string[] array = item.Status.Split(new string[2] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
		return (array.Length != 0) ? array[0] : item.Status;
	}

	private string BuildBoardChangeSummary(Playfield before, Playfield after)
	{
		if (before == null || after == null)
		{
			return string.Empty;
		}
		List<string> list = new List<string>();
		AppendHeroChange(list, "我方英雄", new Minion(before.ownHero), new Minion(after.ownHero));
		AppendHeroChange(list, "敌方英雄", new Minion(before.enemyHero), new Minion(after.enemyHero));
		if (before.mana != after.mana || before.ownMaxMana != after.ownMaxMana)
		{
			list.Add("我方水晶 " + before.mana + "/" + before.ownMaxMana + " -> " + after.mana + "/" + after.ownMaxMana);
		}
		string text = FormatWeaponInfo(before.ownWeapon);
		string text2 = FormatWeaponInfo(after.ownWeapon);
		if (!string.Equals(text, text2, StringComparison.Ordinal))
		{
			list.Add("我方武器 " + text + " -> " + text2);
		}
		string text3 = FormatWeaponInfo(before.enemyWeapon);
		string text4 = FormatWeaponInfo(after.enemyWeapon);
		if (!string.Equals(text3, text4, StringComparison.Ordinal))
		{
			list.Add("敌方武器 " + text3 + " -> " + text4);
		}
		string text5 = FormatCardIdCollection(before.ownSecretsIDList);
		string text6 = FormatCardIdCollection(after.ownSecretsIDList);
		if (!string.Equals(text5, text6, StringComparison.Ordinal))
		{
			list.Add("我方奥秘 " + text5 + " -> " + text6);
		}
		if (before.enemySecretCount != after.enemySecretCount)
		{
			list.Add("敌方奥秘数 " + before.enemySecretCount + " -> " + after.enemySecretCount);
		}
		string text7 = FormatQuestState(before.ownQuest);
		string text8 = FormatQuestState(after.ownQuest);
		if (!string.Equals(text7, text8, StringComparison.Ordinal))
		{
			list.Add("我方任务 " + text7 + " -> " + text8);
		}
		string text9 = FormatQuestState(before.enemyQuest);
		string text10 = FormatQuestState(after.enemyQuest);
		if (!string.Equals(text9, text10, StringComparison.Ordinal))
		{
			list.Add("敌方任务 " + text9 + " -> " + text10);
		}
		string text11 = FormatQuestState(before.sideQuest);
		string text12 = FormatQuestState(after.sideQuest);
		if (!string.Equals(text11, text12, StringComparison.Ordinal))
		{
			list.Add("支线任务 " + text11 + " -> " + text12);
		}
		AppendZoneChanges(list, "我方手牌", BuildHandStateMap(before), BuildHandStateMap(after));
		AppendZoneChanges(list, "我方场面", BuildMinionStateMap(before, own: true), BuildMinionStateMap(after, own: true));
		AppendZoneChanges(list, "敌方场面", BuildMinionStateMap(before, own: false), BuildMinionStateMap(after, own: false));
		if (list.Count == 0)
		{
			return "未检测到明显的牌面变化。";
		}
		if (list.Count > 12)
		{
			list = list.Take(12).ToList();
			list.Add("其余变化已省略。");
		}
		return string.Join(Environment.NewLine, list);
	}

	private string FormatQuestState(object questObject)
	{
		if (questObject == null)
		{
			return "无";
		}
		try
		{
			QuestItem questItem = new QuestItem(questObject);
			if (questItem.Id == cardIDEnum.None)
			{
				return "无";
			}
			Card card = new Card(new CardDB(CardDB.Instance).getCardDataFromID(questItem.Id));
			string text = ResolveDisplayName(card, _cardNameLookup);
			if (string.IsNullOrWhiteSpace(text))
			{
				text = questItem.Id.ToString();
			}
			return text + " " + questItem.questProgress + "/" + questItem.maxProgress;
		}
		catch
		{
			return "无";
		}
	}

	private void AppendHeroChange(List<string> changes, string label, Minion before, Minion after)
	{
		if (before != null && after != null && (before.Hp != after.Hp || before.armor != after.armor || before.Angr != after.Angr))
		{
			changes.Add(label + " " + before.Hp + "+" + before.armor + " 攻" + before.Angr + " -> " + after.Hp + "+" + after.armor + " 攻" + after.Angr);
		}
	}

	private Dictionary<int, string> BuildHandStateMap(Playfield playfield)
	{
		Dictionary<int, string> dictionary = new Dictionary<int, string>();
		if (!(playfield?.owncards is IEnumerable enumerable))
		{
			return dictionary;
		}
		foreach (object item in enumerable)
		{
			try
			{
				Handcard handcard = new Handcard(item);
				Card card = ((handcard.card != null) ? new Card(handcard.card) : null);
				dictionary[handcard.entity] = BuildHandcardDiffSummary(playfield, handcard, card);
			}
			catch
			{
			}
		}
		return dictionary;
	}

	private Dictionary<int, string> BuildMinionStateMap(Playfield playfield, bool own)
	{
		Dictionary<int, string> dictionary = new Dictionary<int, string>();
		if (!(((!own) ? playfield?.enemyMinions : playfield?.ownMinions) is IEnumerable enumerable))
		{
			return dictionary;
		}
		foreach (object item in enumerable)
		{
			try
			{
				Minion minion = new Minion(item);
				dictionary[minion.entitiyID] = BuildMinionDiffSummary(minion);
			}
			catch
			{
			}
		}
		return dictionary;
	}

	private string BuildHandcardDiffSummary(Playfield playfield, Handcard handcard, Card card)
	{
		string text = ResolveDisplayName(card, _cardNameLookup);
		int num = ((card != null) ? (card.Attack + handcard.addattack) : 0);
		int num2 = ((card != null) ? (card.Health + handcard.addHp) : 0);
		int interactiveDisplayedHandcardCost = GetInteractiveDisplayedHandcardCost(playfield, handcard, card);
		return text + " [费:" + interactiveDisplayedHandcardCost + "] " + num + "/" + num2;
	}

	private string BuildMinionDiffSummary(Minion minion)
	{
		string text = minion.nameCN.ToString();
		return text + " " + minion.Angr + "/" + minion.Hp + " (e:" + minion.entitiyID + ")";
	}

	private void AppendZoneChanges(List<string> changes, string zoneLabel, Dictionary<int, string> beforeMap, Dictionary<int, string> afterMap)
	{
		foreach (int item in from id in beforeMap.Keys.Except(afterMap.Keys)
			orderby id
			select id)
		{
			changes.Add(zoneLabel + " 移除 " + beforeMap[item]);
		}
		foreach (int item2 in from id in afterMap.Keys.Except(beforeMap.Keys)
			orderby id
			select id)
		{
			changes.Add(zoneLabel + " 新增 " + afterMap[item2]);
		}
		foreach (int item3 in from id in beforeMap.Keys.Intersect(afterMap.Keys)
			orderby id
			select id)
		{
			string text = beforeMap[item3];
			string text2 = afterMap[item3];
			if (!string.Equals(text, text2, StringComparison.Ordinal))
			{
				changes.Add(zoneLabel + " 变化 " + text + " -> " + text2);
			}
		}
	}

	private string GetActionSourceLabel(SilverfishWrapper.Action action)
	{
		if (action == null)
		{
			return "无";
		}
		try
		{
			if (action.card != null)
			{
				Handcard handcard = new Handcard(action.card);
				Card card = ((handcard.card != null) ? new Card(handcard.card) : null);
				return "手牌#" + handcard.entity + " " + BuildHandcardDiffSummary(_interactiveCurrentBoard, handcard, card);
			}
		}
		catch
		{
		}
		try
		{
			if (action.own != null)
			{
				Minion minion = new Minion(action.own);
				return "实体#" + minion.entitiyID + " " + BuildMinionDiffSummary(minion);
			}
		}
		catch
		{
		}
		return "无";
	}

	private string GetActionTargetLabel(SilverfishWrapper.Action action)
	{
		if (action == null)
		{
			return "无";
		}
		List<string> list = new List<string>();
		object[] array = new object[3] { action.target, action.target2, action.target3 };
		foreach (object obj in array)
		{
			if (obj != null)
			{
				try
				{
					Minion minion = new Minion(obj);
					list.Add("实体#" + minion.entitiyID + " " + BuildMinionDiffSummary(minion));
				}
				catch
				{
				}
			}
		}
		return (list.Count == 0) ? "无" : string.Join(" | ", list.Distinct());
	}

	private int GetActionSourceEntityId(SilverfishWrapper.Action action)
	{
		if (action == null)
		{
			return 0;
		}
		try
		{
			if (action.card != null)
			{
				return new Handcard(action.card).entity;
			}
		}
		catch
		{
		}
		try
		{
			if (action.own != null)
			{
				return new Minion(action.own).entitiyID;
			}
		}
		catch
		{
		}
		return 0;
	}

	private List<int> GetActionTargetEntityIds(SilverfishWrapper.Action action)
	{
		List<int> list = new List<int>();
		if (action == null)
		{
			return list;
		}
		object[] array = new object[3] { action.target, action.target2, action.target3 };
		foreach (object obj in array)
		{
			if (obj == null)
			{
				continue;
			}
			try
			{
				int entitiyID = new Minion(obj).entitiyID;
				if (entitiyID != 0)
				{
					list.Add(entitiyID);
				}
			}
			catch
			{
			}
		}
		return list;
	}

	private void UpdateManualActionScript()
	{
		if (_interactiveActionSteps.Count == 0)
		{
			_currentManualActionScript = string.Empty;
			AiFixManualActionScriptTextBox.Text = string.Empty;
			return;
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("期望动作序列：");
		foreach (ManualActionStep interactiveActionStep in _interactiveActionSteps)
		{
			stringBuilder.Append(interactiveActionStep.StepIndex).Append(". ").AppendLine(interactiveActionStep.Action);
			if (!string.IsNullOrWhiteSpace(interactiveActionStep.ChangeSummary))
			{
				stringBuilder.AppendLine(interactiveActionStep.ChangeSummary);
			}
			stringBuilder.AppendLine();
		}
		_currentManualActionScript = stringBuilder.ToString().Trim();
		AiFixManualActionScriptTextBox.Text = _currentManualActionScript;
	}

	private List<ActionItem> FlattenPath(ActionItem leaf)
	{
		List<ActionItem> list = new List<ActionItem>();
		for (ActionItem actionItem = leaf; actionItem != null; actionItem = actionItem.Father)
		{
			list.Add(actionItem);
		}
		list.Reverse();
		return list;
	}

	public void UpdateScoreMapList()
	{
		ActionScoreComboBox.Items.Clear();
		ActionScoreComboBox.SelectedIndex = -1;
		foreach (KeyValuePair<float, List<ActionItem>> item in actionScoreMap.OrderBy((KeyValuePair<float, List<ActionItem>> key) => 0f - key.Key))
		{
			ActionScoreComboBox.Items.Add(item.Key);
		}
		ActionScoreComboBox.SelectedIndex = 0;
	}

	public void UpdateActionViewTree(int level, int id, float score, object actionList, object pfInst)
	{
		Playfield board = new Playfield(pfInst);
		int num = actionList.ReflectionCall<int>("get_Count", Array.Empty<object>());
		if (level < 0 || num != level)
		{
			ErrorLog("[Simulation] Reported action mismatch error.");
			return;
		}
		ActionItem actionItem = null;
		switch (level)
		{
		case 0:
			this.actionItem = new ActionItem
			{
				Score = 0f,
				Action = "Current Board",
				Board = board,
				Level = level,
				Decision = "DarkRed"
			};
			actionScoreMap.Clear();
			ActionScoreComboBox.Items.Clear();
			ActionScoreComboBox.SelectedItem = -1;
			lastHighlightedScore = -1f;
			break;
		case 1:
		{
			SilverfishWrapper.Action action2 = new SilverfishWrapper.Action(actionList.ReflectionCall<object>("get_Item", new object[1] { 0 }));
			ActionItem item2 = new ActionItem
			{
				Score = score,
				Action = action2.printString(),
				Source = GetSourceOnlineImageFromAction(action2),
				Target = GetTargetOnlineImageFromAction(action2),
				Father = this.actionItem,
				Board = board,
				Level = level,
				Decision = "DarkRed"
			};
			this.actionItem.subGroups.Add(item2);
			if (actionScoreMap.ContainsKey(score))
			{
				actionScoreMap[score].Add(item2);
				break;
			}
			actionScoreMap[score] = new List<ActionItem>();
			actionScoreMap[score].Add(item2);
			break;
		}
		default:
		{
			actionItem = this.actionItem;
			for (int i = 0; i < level; i++)
			{
				SilverfishWrapper.Action action = new SilverfishWrapper.Action(actionList.ReflectionCall<object>("get_Item", new object[1] { i }));
				if (i == level - 1)
				{
					ActionItem item = new ActionItem
					{
						Score = score,
						Action = action.printString(),
						Source = GetSourceOnlineImageFromAction(action),
						Target = GetTargetOnlineImageFromAction(action),
						Father = actionItem,
						Board = board,
						Level = level,
						Decision = "DarkRed"
					};
					actionItem.subGroups.Add(item);
					if (actionScoreMap.ContainsKey(score))
					{
						actionScoreMap[score].Add(item);
						break;
					}
					actionScoreMap[score] = new List<ActionItem>();
					actionScoreMap[score].Add(item);
					break;
				}
				foreach (ActionItem subGroup in actionItem.subGroups)
				{
					if (subGroup.Action == action.printString())
					{
						actionItem = subGroup;
					}
					subGroup.Decision = "DarkRed";
				}
			}
			break;
		}
		}
		ActionTreeView.ItemsSource = this.actionItem.Items;
	}

	private void LoadConfigFile()
	{
		CardSearchStatusBar.Content = "设置路径中...";
		if (RoutineRuntime.TryResolveSilverfishPath(out var _))
		{
			RoutineRuntime.ApplySettingsToWrapper();
			CardSearchStatusBar.Content = "DefaultRoutine 路径配置成功";
		}
		else
		{
			CardSearchStatusBar.Content = "请先导入 DefaultRoutine 文件夹";
			WarnLog("[Config] 未找到有效的 DefaultRoutine 文件夹，请先重新导入。");
		}
	}

	public void ConstructCardList()
	{
		BackgroundWorker backgroundWorker = new BackgroundWorker();
		backgroundWorker.DoWork += ConstructCardListWorker;
		backgroundWorker.RunWorkerCompleted += ConstructCardListWorkerCompleted;
		CardSearchStatusBar.Content = "从 CardDefs.xml 加载卡牌数据中...";
		backgroundWorker.RunWorkerAsync(DateTime.Now);
		RoutineSelectionButton.IsEnabled = false;
		RoutineComboBox.IsEnabled = false;
		RoutineComboBox.SelectedItem = -1;
		RoutineComboBox.Items.Clear();
		TestSelectionButton.IsEnabled = false;
		ExecuteButton.IsEnabled = false;
		ExecuteButton.Content = "加 载 中";
		ExportSelectionButton.IsEnabled = false;
		RecentTestFilesComboBox.IsEnabled = false;
		RecentTestRefreshButton.IsEnabled = false;
	}

	public void CompileRoutinesWorkerCompleted()
	{
		RoutineSelectionButton.IsEnabled = true;
		RoutineComboBox.IsEnabled = true;
		TestSelectionButton.IsEnabled = true;
		ExportSelectionButton.IsEnabled = true;
		RecentTestRefreshButton.IsEnabled = true;
		TestPathBox.Text = "";
        RoutineComboBox.Items.Clear();
		foreach (string behaviorName in RoutineRuntime.GetBehaviorNames(compiledRoutines))
		{
			RoutineComboBox.Items.Add(behaviorName);
		}
		InfoLog("[Compiler] Successfully compiled all routines (" + compiledRoutines.ExportedTypes.Count() + ").");
		try
		{
			XmlConfigUtil xmlConfigUtil = new XmlConfigUtil(_routineXml);
            int.TryParse(xmlConfigUtil.Read("LastRoutine"), out int lastRoutine);
            RoutineComboBox.SelectedIndex = RoutineComboBox.Items.Count > 0
                ? Math.Clamp(lastRoutine, 0, RoutineComboBox.Items.Count - 1) : -1;
			InfoLog("[Routine] Selected last used routine " + RoutineComboBox.Text + ".");
			string text = xmlConfigUtil.Read("LastTestFile");
			string silverfishPath;
			if (!string.IsNullOrEmpty(text) && File.Exists(text))
			{
				TestPathBox.Text = text;
			}
			else if (RoutineRuntime.TryResolveSilverfishPath(out silverfishPath))
			{
				string text2 = RoutineRuntime.FindMostRecentTestFile(silverfishPath);
				if (!string.IsNullOrWhiteSpace(text2))
				{
					TestPathBox.Text = text2;
					xmlConfigUtil.Write(text2, "LastTestFile");
					InfoLog("[Test] Auto-selected recent test file " + text2 + ".");
				}
				else
				{
					string testDataDirectory = RoutineRuntime.GetTestDataDirectory(silverfishPath);
					WarnLog("[Test] No test file found under " + testDataDirectory + ".");
				}
			}
		}
		catch
		{
			WarnLog("[Routine] Recent history not found, reset to default.");
		}
		RefreshRecentTestFiles();
		RefreshSelectedTestFileContext();
	}

	public void ConstructCardListWorker(object sender, DoWorkEventArgs e)
	{
		cardDB = new CardDB(CardDB.Instance);
		Dictionary<string, string> cardNameLookup = BuildCardNameLookup();
		List<CardListEntry> list = new List<CardListEntry>();
		IEnumerator enumerator = ((IEnumerable)cardDB.cardlist).GetEnumerator();
		while (enumerator.MoveNext())
		{
			list.Add(CreateCardListEntry(new Card(enumerator.Current), cardNameLookup));
		}
		e.Result = new CardLoadResult
		{
			ElapsedSeconds = (DateTime.Now - (DateTime)e.Argument).TotalSeconds,
			Cards = list,
			CardNameLookup = cardNameLookup
		};
	}

	public void ConstructCardListWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
        if (e.Error != null)
        {
            CardSearchStatusBar.Content = "卡牌加载失败，请检查日志后重新编译";
            ExecuteButton.Content = "加 载 失 败";
            ErrorLog("[CardDB] " + e.Error);
            return;
        }
		CardLoadResult cardLoadResult = e.Result as CardLoadResult;
		CardSearchStatusBar.Content = "加载完成 (" + (cardLoadResult?.ElapsedSeconds ?? 0.0).ToString("0.##") + "s)";
		allCardsList = cardLoadResult?.Cards ?? new List<CardListEntry>();
		_cardNameLookup = cardLoadResult?.CardNameLookup ?? new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
		CardListSearchBox.IsEnabled = true;
		CardListBox.ItemsSource = null;
		ExecuteButton.IsEnabled = true;
		ExecuteButton.Content = "测 试 牌 面";
		System.Windows.Controls.Label cardSearchStatusBar = CardSearchStatusBar;
		cardSearchStatusBar.Content = cardSearchStatusBar.Content?.ToString() + "，输入关键字后按回车搜索";
	}

	private void CopyCardButton_Click(object sender, RoutedEventArgs e)
	{
		if (sender is System.Windows.Controls.Button button)
		{
			CardListEntry cardListEntry = (button.DataContext as CardListEntry) ?? (button.Tag as CardListEntry);
			if (cardListEntry?.Card != null)
			{
				System.Windows.Clipboard.SetText(cardListEntry.Card.cardIDenum.ToString());
				button.Content = "✔";
				BackgroundWorker backgroundWorker = new BackgroundWorker();
				backgroundWorker.DoWork += CopyCardButtonWorker;
				backgroundWorker.RunWorkerCompleted += CopyCardButtonWorkerCompleted;
				CardSearchStatusBar.Content = "已复制卡牌 ID";
				backgroundWorker.RunWorkerAsync(button);
			}
		}
	}

	public void CopyCardButtonWorker(object sender, DoWorkEventArgs e)
	{
		Thread.Sleep(3000);
		e.Result = e.Argument;
	}

	public void CopyCardButtonWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		System.Windows.Controls.Button button = e.Result as System.Windows.Controls.Button;
		button.Content = "\ud83d\udcdd";
	}

	private void CardListSearchBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
	{
		if (e.Key == Key.Return)
		{
			e.Handled = true;
			ExecuteCardSearch((sender as System.Windows.Controls.TextBox)?.Text?.ToString() ?? string.Empty);
		}
	}

	private void ExecuteCardSearch(string searchText)
	{
		if (searchText.Length == 0)
		{
			CardListBox.ItemsSource = null;
			CardSearchStatusBar.Content = "输入关键字后按回车搜索";
			return;
		}
		if (searchText.Length < 2 && searchText != "全部" && searchText.ToLower() != "all" && !searchText.Contains("_"))
		{
			CardListBox.ItemsSource = null;
			CardSearchStatusBar.Content = "至少输入 2 个字符后再搜索";
			return;
		}
		if (searchText == "全部" || searchText.ToLower() == "all")
		{
			CardListBox.ItemsSource = allCardsList.Take(100).ToList();
			CardSearchStatusBar.Content = "仅显示前 100 张卡牌";
			return;
		}
		if (searchWorker != null && searchWorker.IsBusy)
		{
			CardSearchStatusBar.Content = "上一轮搜索尚未完成，请稍候";
			return;
		}
		searchWorker = new BackgroundWorker();
		searchWorker.DoWork += CardListSearchTextWorker;
		searchWorker.RunWorkerCompleted += CardListSearchTextWorkerCompleted;
		CardSearchStatusBar.Content = "正在检索中";
		searchWorker.RunWorkerAsync(searchText);
	}

	private void CardListSearchTextWorker(object sender, DoWorkEventArgs e)
	{
		string text = (e.Argument as string) ?? string.Empty;
		string normalizedCondition = text.ToLowerInvariant();
		try
		{
			List<Card> list = DeckHelper.Deserialize(text);
			list.Sort((Card emp1, Card emp2) => emp1.cost.CompareTo(emp2.cost));
			List<CardListEntry> list2 = list.Select((Card card) => CreateCardListEntry(card, _cardNameLookup)).ToList();
			e.Result = new CardSearchResult
			{
				Cards = list2,
				StatusText = "检索完成，共 " + list2.Count + " 张"
			};
		}
		catch
		{
			List<CardListEntry> list3 = allCardsList.FindAll(delegate(CardListEntry match)
			{
				string searchText = match.SearchText;
				return searchText != null && searchText.IndexOf(normalizedCondition, StringComparison.OrdinalIgnoreCase) >= 0;
			});
			if (list3.Count > 100)
			{
				list3 = list3.Take(100).ToList();
				e.Result = new CardSearchResult
				{
					Cards = list3,
					StatusText = "结果过多，仅显示前 100 张"
				};
			}
			else
			{
				e.Result = new CardSearchResult
				{
					Cards = list3,
					StatusText = "检索完成，共 " + list3.Count + " 张"
				};
			}
		}
	}

	private void CardListSearchTextWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		CardSearchResult cardSearchResult = e.Result as CardSearchResult;
		CardListBox.ItemsSource = cardSearchResult?.Cards;
		CardSearchStatusBar.Content = cardSearchResult?.StatusText ?? "检索完成";
	}

	private CardListEntry CreateCardListEntry(Card card, Dictionary<string, string> cardNameLookup)
	{
		string text = ResolveDisplayName(card, cardNameLookup);
		CardListEntry cardListEntry = new CardListEntry();
		cardListEntry.Card = card;
		cardListEntry.cardIDenum = card.cardIDenum;
		cardListEntry.cardIdText = card.cardIDenum.ToString();
		cardListEntry.cost = card.cost;
		cardListEntry.Color = card.Color;
		cardListEntry.nameCN = text;
		cardListEntry.dbfId = card.dbfId;
		cardListEntry.OnlineCardImage = (EnableImagePreview ? card.OnlineCardImage : null);
		cardListEntry.SearchText = (card.cardIDenum.ToString() + " " + (card.dbfId ?? string.Empty) + " " + text + " " + card.nameEN.ToString() + " " + (card.textCN ?? string.Empty)).ToLowerInvariant();
		return cardListEntry;
	}

	private static string ResolveDisplayName(Card card, Dictionary<string, string> cardNameLookup)
	{
		if (card != null && cardNameLookup != null)
		{
			if (!string.IsNullOrWhiteSpace(card.dbfId) && cardNameLookup.TryGetValue("ID:" + card.dbfId, out var value))
			{
				return value;
			}
			string text = card.cardIDenum.ToString();
			if (!string.IsNullOrWhiteSpace(text) && cardNameLookup.TryGetValue("CARDID:" + text, out var value2))
			{
				return value2;
			}
		}
		if (card != null && !string.IsNullOrWhiteSpace(card.name))
		{
			return card.name;
		}
		return card?.nameCN.ToString() ?? string.Empty;
	}

    private static Dictionary<string, string> BuildCardNameLookup()
    {
        var names = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        string path = Path.Combine(new Settings(Settings.Instance).path, "CardDefs.xml");
        if (!File.Exists(path)) return names;
        using var reader = XmlReader.Create(path, new XmlReaderSettings { DtdProcessing = DtdProcessing.Prohibit });
        string dbfId = null;
        string cardId = null;
        while (reader.Read())
        {
            if (reader.IsStartElement("Entity"))
            {
                dbfId = reader.GetAttribute("ID");
                cardId = reader.GetAttribute("CardID");
            }
            if (!reader.IsStartElement("Tag") || reader.GetAttribute("enumID") != "185") continue;
            using var tag = reader.ReadSubtree();
            string name = null;
            while (tag.Read())
            {
                if (tag.IsStartElement("zhCN")) { name = tag.ReadElementContentAsString().Trim(); break; }
            }
            if (string.IsNullOrWhiteSpace(name)) continue;
            if (!string.IsNullOrWhiteSpace(dbfId)) names["ID:" + dbfId] = name;
            if (!string.IsNullOrWhiteSpace(cardId)) names["CARDID:" + cardId] = name;
        }
        return names;
    }

	private static string NormalizeExistingPath(string path)
	{
		if (string.IsNullOrWhiteSpace(path))
		{
			return null;
		}
		try
		{
			return File.Exists(path) ? Path.GetFullPath(path) : null;
		}
		catch
		{
			return null;
		}
	}

	private bool TryGetSelectedTestContext(out string testFilePath, out string behaviorName)
	{
		testFilePath = NormalizeExistingPath(TestPathBox.Text);
		behaviorName = RoutineComboBox.SelectedItem?.ToString();
		if (string.IsNullOrWhiteSpace(testFilePath))
		{
			ErrorLog("[AI修伏笔] 请先选择有效的对局文件。");
			return false;
		}
		if (string.IsNullOrWhiteSpace(behaviorName))
		{
			ErrorLog("[AI修伏笔] 请先选择策略。");
			return false;
		}
		return true;
	}

	private void RefreshSelectedTestFileContext()
	{
		_interactiveRootBoard = null;
		_interactiveCurrentBoard = null;
		_interactiveSelectedSource = null;
		_interactiveSelectedTarget = null;
		_interactiveActionSteps.Clear();
		_interactiveCandidateItems.Clear();
		_currentManualActionScript = string.Empty;
		string text = NormalizeExistingPath(TestPathBox.Text);
		if (string.IsNullOrWhiteSpace(text))
		{
			_currentEntitySnapshot = string.Empty;
			EntitySnapshotStatusLabel.Content = "当前牌面文件没有实体快照。";
			EntitySnapshotTextBox.Text = string.Empty;
			RefreshInteractiveAiFixBoard();
			AiFixStatusLabel.Content = "选择牌面后可生成 AI 修伏笔提示词。";
			return;
		}
		try
		{
			string content = TextFileUtil.ReadAllTextPreferUtf8(text);
			_currentEntitySnapshot = ExtractMarkedSection(content, "### ENTITY_SNAPSHOT_BEGIN ###", "### ENTITY_SNAPSHOT_END ###");
			if (string.IsNullOrWhiteSpace(_currentEntitySnapshot))
			{
				EntitySnapshotStatusLabel.Content = "当前牌面文件没有实体快照，需用新版 HB 重新导出。";
				EntitySnapshotTextBox.Text = string.Empty;
			}
			else
			{
				int num = _currentEntitySnapshot.Split(new string[2] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries).Length;
				EntitySnapshotStatusLabel.Content = "已读取实体快照，共 " + num + " 行。";
				EntitySnapshotTextBox.Text = _currentEntitySnapshot;
			}
			if (string.Equals(text, _lastExecutedTestFilePath, StringComparison.OrdinalIgnoreCase) && string.Equals(RoutineComboBox.SelectedItem?.ToString(), _lastExecutedBehaviorName, StringComparison.OrdinalIgnoreCase) && !string.IsNullOrWhiteSpace(_currentAiFixPrompt))
			{
				AiFixStatusLabel.Content = "当前提示词已和最近一次测试结果同步，可直接复制给 AI。";
			}
			else
			{
				AiFixStatusLabel.Content = "已加载牌面上下文，点击“生成提示词”可整理 AI 修伏笔材料。";
			}
		}
		catch (Exception ex)
		{
			_currentEntitySnapshot = string.Empty;
			EntitySnapshotStatusLabel.Content = "读取实体快照失败。";
			EntitySnapshotTextBox.Text = string.Empty;
			WarnLog("[实体快照] 读取失败: " + ex.Message);
		}
		RefreshInteractiveAiFixBoard();
	}

	private static string ExtractMarkedSection(string content, string beginMarker, string endMarker)
	{
		if (string.IsNullOrWhiteSpace(content))
		{
			return string.Empty;
		}
		int num = content.IndexOf(beginMarker, StringComparison.OrdinalIgnoreCase);
		if (num < 0)
		{
			return string.Empty;
		}
		num += beginMarker.Length;
		int num2 = content.IndexOf(endMarker, num, StringComparison.OrdinalIgnoreCase);
		if (num2 < 0)
		{
			num2 = content.Length;
		}
		return content.Substring(num, num2 - num).Trim();
	}

	private static string RemoveMarkedSection(string content, string beginMarker, string endMarker)
	{
		if (string.IsNullOrWhiteSpace(content))
		{
			return string.Empty;
		}
		int num = content.IndexOf(beginMarker, StringComparison.OrdinalIgnoreCase);
		if (num < 0)
		{
			return content.Trim();
		}
		int num2 = content.IndexOf(endMarker, num, StringComparison.OrdinalIgnoreCase);
		if (num2 < 0)
		{
			return content.Substring(0, num).Trim();
		}
		string text = content.Substring(0, num);
		string text2 = content.Substring(num2 + endMarker.Length);
		return (text + text2).Trim();
	}

	private static string BuildPromptExcerpt(string content, int maxChars, bool preferTail = false)
	{
		if (string.IsNullOrWhiteSpace(content) || content.Length <= maxChars)
		{
			return content?.Trim() ?? string.Empty;
		}
		if (preferTail)
		{
			return "[内容较长，以下仅保留尾部片段]\r\n" + content.Substring(content.Length - maxChars).Trim();
		}
		return content.Substring(0, maxChars).Trim() + "\r\n[内容较长，后续已截断]";
	}

	private static string ReadPromptFileSection(string path, int maxChars, bool preferTail = false)
	{
		string text = NormalizeExistingPath(path);
		if (string.IsNullOrWhiteSpace(text))
		{
			return string.Empty;
		}
		try
		{
			return BuildPromptExcerpt(TextFileUtil.ReadAllTextPreferUtf8(text), maxChars, preferTail);
		}
		catch
		{
			return string.Empty;
		}
	}

	private static void AppendPromptSection(StringBuilder builder, string title, string content, string codeLanguage = "txt")
	{
		if (!string.IsNullOrWhiteSpace(content))
		{
			builder.AppendLine("## " + title);
			builder.AppendLine("```" + codeLanguage);
			builder.AppendLine(content.Trim());
			builder.AppendLine("```");
			builder.AppendLine();
		}
	}

	private List<string> FindBehaviorSourceFiles(string behaviorName)
	{
		List<string> list = new List<string>();
		if (string.IsNullOrWhiteSpace(behaviorName) || !RoutineRuntime.TryResolveSilverfishPath(out var silverfishPath))
		{
			return list;
		}
		string path = Path.Combine(silverfishPath, "behavior");
		if (!Directory.Exists(path))
		{
			return list;
		}
		try
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(path).EnumerateDirectories("*", SearchOption.TopDirectoryOnly).FirstOrDefault((DirectoryInfo dir) => string.Equals(dir.Name, behaviorName, StringComparison.OrdinalIgnoreCase));
			if (directoryInfo != null)
			{
				list.AddRange(from file in directoryInfo.EnumerateFiles("*.cs", SearchOption.AllDirectories)
					select file.FullName);
			}
			if (list.Count == 0)
			{
				list.AddRange(from file in new DirectoryInfo(path).EnumerateFiles("*.cs", SearchOption.AllDirectories)
					where file.Name.IndexOf(behaviorName, StringComparison.OrdinalIgnoreCase) >= 0 || file.DirectoryName.IndexOf(behaviorName, StringComparison.OrdinalIgnoreCase) >= 0
					select file.FullName);
			}
		}
		catch
		{
		}
		return list.Distinct(StringComparer.OrdinalIgnoreCase).OrderBy((string result) => result, StringComparer.OrdinalIgnoreCase).ToList();
	}

	private static AiFixArtifacts BuildAiFixArtifacts(string testFilePath)
	{
		string text = NormalizeExistingPath(testFilePath);
		if (string.IsNullOrWhiteSpace(text))
		{
			return null;
		}
		string text2 = Path.Combine(Path.GetDirectoryName(text) ?? string.Empty, Path.GetFileNameWithoutExtension(text));
		return new AiFixArtifacts
		{
			ResultPath = text2 + ".editor.result",
			DetailPath = text2 + ".editor.detail",
			PromptPath = text2 + ".ai_fix_prompt.md"
		};
	}

	private void SetPrintUtilsField(string fieldName, object value)
	{
		try
		{
			((compiledRoutines?.GetType("HREngine.Bots.printUtils"))?.GetField(fieldName, BindingFlags.Static | BindingFlags.Public))?.SetValue(null, value);
		}
		catch
		{
		}
	}

	private void PrepareAiFixArtifacts(AiFixArtifacts artifacts)
	{
		if (artifacts == null)
		{
			return;
		}
		string[] array = new string[3] { artifacts.ResultPath, artifacts.DetailPath, artifacts.PromptPath };
		foreach (string text in array)
		{
			try
			{
				if (!string.IsNullOrWhiteSpace(text) && File.Exists(text))
				{
					File.Delete(text);
				}
			}
			catch
			{
			}
		}
		SetPrintUtilsField("outputFilePath", artifacts.ResultPath);
		SetPrintUtilsField("detailFilePath", artifacts.DetailPath);
		SetPrintUtilsField("printResult", false);
	}

	private void ResetAiFixArtifacts()
	{
		SetPrintUtilsField("outputFilePath", null);
		SetPrintUtilsField("detailFilePath", null);
		SetPrintUtilsField("printResult", false);
	}

	private void SettingsButton_Click(object sender, RoutedEventArgs e)
	{
		XmlConfigUtil xmlConfigUtil = new XmlConfigUtil(_routineXml);
		Settings settings = new Settings(Settings.Instance);
		string value = RoutineRuntime.NormalizeDefaultRoutinePath(settings.mainPath);
		if (!string.IsNullOrWhiteSpace(value))
		{
			xmlConfigUtil.Write(value, "RoutinePath");
		}
		xmlConfigUtil.Write(settings.mainPath, "SilverfishPath");
		CardSearchStatusBar.Content = (string.IsNullOrWhiteSpace(value) ? "Silverfish 路径配置成功" : "DefaultRoutine 路径配置成功");
	}

	public static void ShowOpenWithDialog(string path)
	{
		string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "shell32.dll");
		text = text + ",OpenAs_RunDLL " + path;
		Process.Start("rundll32.exe", text);
	}

	private void CheckCardButton_Click(object sender, RoutedEventArgs e)
	{
		System.Windows.Controls.Button button = sender as System.Windows.Controls.Button;
		Settings settings = new Settings(Settings.Instance);
		if (button == null)
		{
			return;
		}
		Card card = ((button.DataContext as CardListEntry) ?? (button.Tag as CardListEntry))?.Card;
		if (card != null)
		{
			string text = card.cardIDenum.ToString();
			List<string> list = (from d in new DirectoryInfo(Path.Combine(settings.mainPath, "cards\\")).EnumerateFiles("Sim_" + text + ".cs", SearchOption.AllDirectories)
				select d.FullName).ToList();
			if (list.Count == 0)
			{
				CardSearchStatusBar.Content = text + " 未找到相关 Sim 文件！";
				button.ToolTip = "找不到文件";
				button.Content = "❓";
				button.IsEnabled = false;
			}
			else if (list.Count == 1 && button.Content.ToString().CompareTo("\ud83d\udcc2") == 0)
			{
				ShowOpenWithDialog(list.First());
				CardSearchStatusBar.Content = text + " 已打开！";
			}
			else if (list.Count == 1)
			{
				CardSearchStatusBar.Content = text + " 已找到相关 Sim 文件！";
				button.ToolTip = "打开 Sim 文件";
				button.Content = "\ud83d\udcc2";
			}
			else
			{
				CardSearchStatusBar.Content = text + " 找到过多匹配的 Sim 文件！";
				button.ToolTip = "文件匹配过多";
				button.Content = "❓";
				button.IsEnabled = false;
			}
		}
	}

	private void RoutineComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		try
		{
			if (RoutineComboBox.Items.Count != 0 && RoutineComboBox.SelectedIndex >= 0)
			{
				XmlConfigUtil xmlConfigUtil = new XmlConfigUtil(_routineXml);
				xmlConfigUtil.Write(RoutineComboBox.SelectedIndex.ToString(), "LastRoutine");
				CardSearchStatusBar.Content = "已切换策略: " + RoutineComboBox.SelectedItem;
			}
		}
		catch
		{
		}
	}

	private void TestSelectionButton_Click(object sender, RoutedEventArgs e)
	{
		string initialDirectory = null;
		string silverfishPath;
		if (File.Exists(TestPathBox.Text))
		{
			initialDirectory = Path.GetDirectoryName(TestPathBox.Text);
		}
		else if (RoutineRuntime.TryResolveSilverfishPath(out silverfishPath))
		{
			string testDataDirectory = RoutineRuntime.GetTestDataDirectory(silverfishPath);
			if (Directory.Exists(testDataDirectory))
			{
				initialDirectory = testDataDirectory;
			}
		}
		Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog
		{
			Filter = "Playfield Log File|*.txt",
			DereferenceLinks = false,
			InitialDirectory = initialDirectory
		};
		if (openFileDialog.ShowDialog() == true)
		{
			TestPathBox.Text = openFileDialog.FileName;
			XmlConfigUtil xmlConfigUtil = new XmlConfigUtil(_routineXml);
			xmlConfigUtil.Write(TestPathBox.Text, "LastTestFile");
			RefreshRecentTestFiles();
			RefreshSelectedTestFileContext();
		}
		else
		{
			TestPathBox.Text = "";
			RefreshSelectedTestFileContext();
		}
	}

	private void RecentTestRefreshButton_Click(object sender, RoutedEventArgs e)
	{
		RefreshRecentTestFiles();
	}

	private void RecentTestFilesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		if (!_suppressRecentTestSelectionChanged && RecentTestFilesComboBox.SelectedItem is RecentTestFileItem recentTestFileItem && File.Exists(recentTestFileItem.FullPath))
		{
			TestPathBox.Text = recentTestFileItem.FullPath;
			XmlConfigUtil xmlConfigUtil = new XmlConfigUtil(_routineXml);
			xmlConfigUtil.Write(recentTestFileItem.FullPath, "LastTestFile");
			CardSearchStatusBar.Content = "已选择最近牌面: " + recentTestFileItem.DisplayName;
			RefreshSelectedTestFileContext();
		}
	}

	public void ErrorLog(string content)
	{
		AddLog(content, Brushes.DarkRed);
	}

	public void InfoLog(string content)
	{
		AddLog(content, Brushes.Black);
	}

	public void SuccessLog(string content)
	{
		AddLog(content, Brushes.DarkGreen);
	}

	public void WarnLog(string content)
	{
		AddLog(content, Brushes.DarkGoldenrod);
	}

	private void AddLog(string content, Brush brush)
	{
		Run run = new Run(content + "\r\n");
		run.Foreground = brush;
		if (LogRichTextBox.Document.Blocks.FirstBlock is Paragraph paragraph)
		{
			paragraph.Inlines.Add(run);
		}
		LogScrollViewer.ScrollToEnd();
	}

	private void RoutineSelectionButton_Click(object sender, RoutedEventArgs e)
	{
		CompilerWindow compilerWindow = new CompilerWindow(null);
		Window window = Window.GetWindow(this);
		double left = window.Left + (window.Width - compilerWindow.Width) / 2.0;
		double top = window.Top + (window.Height - compilerWindow.Height) / 2.0;
		compilerWindow.WindowStartupLocation = WindowStartupLocation.Manual;
		compilerWindow.Left = left;
		compilerWindow.Top = top;
		bool? flag = compilerWindow.ShowDialog();
		if (flag.HasValue && flag.Value)
		{
			string text = compilerWindow.Results?.PathToAssembly;
			if (!string.IsNullOrWhiteSpace(text) && File.Exists(text))
			{
				compiledRoutines = Assembly.Load(File.ReadAllBytes(text));
			}
			else
			{
				compiledRoutines = compilerWindow.Results.CompiledAssembly;
			}
			InitWrapers();
			SystemSounds.Exclamation.Play();
		}
		else
		{
			if (compilerWindow.Results == null)
			{
				return;
			}
			string text2 = "";
			foreach (CompilerError error in compilerWindow.Results.Errors)
			{
				if (!error.IsWarning)
				{
					text2 += $"{error}\r\n";
				}
			}
			System.Windows.MessageBox.Show(text2, "CompilerErrors");
			SystemSounds.Hand.Play();
		}
	}

	private void ExecuteButton_Click(object sender, RoutedEventArgs e)
	{
		if (TryGetSelectedTestContext(out var testFilePath, out var behaviorName))
		{
			if (RunSelectedTestInternal(testFilePath, behaviorName, verboseLogging: true))
			{
				SystemSounds.Asterisk.Play();
			}
			else
			{
				SystemSounds.Hand.Play();
			}
		}
	}

	private bool RunSelectedTestInternal(string testFilePath, string behaviorName, bool verboseLogging)
	{
		if (string.IsNullOrWhiteSpace(testFilePath) || string.IsNullOrWhiteSpace(behaviorName))
		{
			ErrorLog("[Start] Setup is not completed, aborting.");
			return false;
		}
		bestActionItem.Clear();
		if (verboseLogging)
		{
			InfoLog("[Start] Setting up AI test...");
			InfoLog("[Compiler] Now starting to test file...");
		}
		try
		{
			Type type = compiledRoutines.GetType("HREngine.Bots.Behavior" + behaviorName);
			if (type == null)
			{
				ErrorLog("[Compiler] 未找到策略类型: " + behaviorName);
				return false;
			}
			AiFixArtifacts aiFixArtifacts = BuildAiFixArtifacts(testFilePath);
			PrepareAiFixArtifacts(aiFixArtifacts);
			try
			{
				AiTestClass aiTestClass = new AiTestClass(Activator.CreateInstance(compiledRoutines.GetType("HREngine.Bots.TestBase")));
				aiTestClass.Test(testFilePath, Activator.CreateInstance(type));
			}
			finally
			{
				ResetAiFixArtifacts();
			}
			BuildVisualizationFromLatestAi();
			TestRunSummary testRunSummary = RoutineRuntime.CaptureTestRunSummary(behaviorName, testFilePath);
			_lastExecutedTestFilePath = NormalizeExistingPath(testFilePath);
			_lastExecutedBehaviorName = behaviorName;
			_lastTestSummary = testRunSummary;
			_lastAiFixArtifacts = aiFixArtifacts;
			ApplyTestSummary(testRunSummary);
			RefreshSelectedTestFileContext();
			BuildAndPersistAiFixPrompt(testRunSummary, aiFixArtifacts, behaviorName, testFilePath);
			if (verboseLogging)
			{
				SuccessLog("[Start] AI test complete!");
			}
			return true;
		}
		catch (Exception innerException)
		{
			while (innerException.InnerException != null)
			{
				innerException = innerException.InnerException;
			}
			ErrorLog(innerException.ToString());
			return false;
		}
	}

	private void BuildAndPersistAiFixPrompt(TestRunSummary summary, AiFixArtifacts artifacts, string behaviorName, string testFilePath)
	{
		_currentAiFixPrompt = BuildAiFixPrompt(summary, artifacts, behaviorName, testFilePath);
		AiFixPromptTextBox.Text = _currentAiFixPrompt ?? string.Empty;
		if (string.IsNullOrWhiteSpace(_currentAiFixPrompt) || artifacts == null || string.IsNullOrWhiteSpace(artifacts.PromptPath))
		{
			AiFixStatusLabel.Content = "提示词生成失败，请先执行测试。";
			return;
		}
		try
		{
			File.WriteAllText(artifacts.PromptPath, _currentAiFixPrompt, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
			AiFixStatusLabel.Content = "已生成提示词: " + artifacts.PromptPath;
			InfoLog("[AI修伏笔] 提示词已保存到 " + artifacts.PromptPath);
		}
		catch (Exception ex)
		{
			AiFixStatusLabel.Content = "提示词已生成，但保存失败。";
			WarnLog("[AI修伏笔] 保存提示词失败: " + ex.Message);
		}
	}

	private string BuildAiFixPrompt(TestRunSummary summary, AiFixArtifacts artifacts, string behaviorName, string testFilePath)
	{
		if (summary == null)
		{
			return string.Empty;
		}
		string path = NormalizeExistingPath(testFilePath) ?? summary.TestFilePath;
		string path2 = Path.ChangeExtension(path, ".answer");
		string path3 = artifacts?.ResultPath;
		string path4 = artifacts?.DetailPath;
		List<string> list = FindBehaviorSourceFiles(behaviorName);
		StringBuilder stringBuilder = new StringBuilder(65536);
		stringBuilder.AppendLine("# AI 修伏笔任务");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("请基于下面的策略源码、测试用例、当前 AI 输出、细节日志和实体快照，定位导致错误决策的伏笔，并给出最小改动方案。");
		stringBuilder.AppendLine("要求：");
		stringBuilder.AppendLine("1. 先说明问题根因。");
		stringBuilder.AppendLine("2. 优先最小修改，不要改无关逻辑。");
		stringBuilder.AppendLine("3. 直接给出可替换的 C# 代码片段。");
		stringBuilder.AppendLine("4. 如果需要新增判定，请说明应放在哪个策略文件。");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("策略: `" + summary.BehaviorName + "`");
		stringBuilder.AppendLine("对局文件: `" + summary.TestFilePath + "`");
		stringBuilder.AppendLine("当前最佳分数: `" + summary.BestMoveValue.ToString("0.##") + "`");
		stringBuilder.AppendLine("最佳动作数: `" + summary.BestActions.Count + "`");
		if (!string.IsNullOrWhiteSpace(summary.LogFilePath))
		{
			stringBuilder.AppendLine("运行日志: `" + summary.LogFilePath + "`");
		}
		stringBuilder.AppendLine();
		if (summary.BestActions.Count > 0)
		{
			stringBuilder.AppendLine("## 当前最佳动作");
			for (int i = 0; i < summary.BestActions.Count; i++)
			{
				stringBuilder.AppendLine(i + 1 + ". " + summary.BestActions[i]);
			}
			stringBuilder.AppendLine();
		}
		string content = string.Empty;
		try
		{
			content = TextFileUtil.ReadAllTextPreferUtf8(path);
		}
		catch
		{
		}
		AppendPromptSection(stringBuilder, "测试用例（去除实体快照）", BuildPromptExcerpt(RemoveMarkedSection(content, "### ENTITY_SNAPSHOT_BEGIN ###", "### ENTITY_SNAPSHOT_END ###"), 120000));
		AppendPromptSection(stringBuilder, "参考答案", ReadPromptFileSection(path2, 80000));
		AppendPromptSection(stringBuilder, "本次编辑器结果", ReadPromptFileSection(path3, 80000));
		AppendPromptSection(stringBuilder, "本次编辑器细节日志（尾部）", ReadPromptFileSection(path4, 120000, preferTail: true));
		if (!string.IsNullOrWhiteSpace(_currentEntitySnapshot))
		{
			AppendPromptSection(stringBuilder, "HB 实体快照", _currentEntitySnapshot);
		}
		if (!string.IsNullOrWhiteSpace(_currentManualActionScript))
		{
			AppendPromptSection(stringBuilder, "人工期望动作（交互修伏笔）", _currentManualActionScript);
		}
		if (list.Count == 0)
		{
			stringBuilder.AppendLine("## 策略源码");
			stringBuilder.AppendLine("未自动定位到策略源码文件，请结合上面的策略名手动补充。");
			stringBuilder.AppendLine();
		}
		else
		{
			foreach (string item in list)
			{
				string text = item;
				try
				{
					if (RoutineRuntime.TryResolveSilverfishPath(out var silverfishPath))
					{
						string text2 = Path.GetFullPath(silverfishPath).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
						string fullPath = Path.GetFullPath(item);
						if (fullPath.StartsWith(text2, StringComparison.OrdinalIgnoreCase))
						{
							text = fullPath.Substring(text2.Length).TrimStart(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar).Replace('\\', '/');
						}
					}
				}
				catch
				{
				}
				AppendPromptSection(stringBuilder, "策略源码: " + text, ReadPromptFileSection(item, 120000), "csharp");
			}
		}
		return stringBuilder.ToString().Trim();
	}

	private void GenerateAiFixPromptButton_Click(object sender, RoutedEventArgs e)
	{
		if (!TryGetSelectedTestContext(out var testFilePath, out var behaviorName))
		{
			return;
		}
		if (!string.Equals(testFilePath, _lastExecutedTestFilePath, StringComparison.OrdinalIgnoreCase) || !string.Equals(behaviorName, _lastExecutedBehaviorName, StringComparison.OrdinalIgnoreCase) || _lastTestSummary == null)
		{
			InfoLog("[AI修伏笔] 当前牌面还没有最新测试结果，先执行一次测试并生成调试材料。");
			if (!RunSelectedTestInternal(testFilePath, behaviorName, verboseLogging: false))
			{
				return;
			}
		}
		else
		{
			RefreshSelectedTestFileContext();
			BuildAndPersistAiFixPrompt(_lastTestSummary, _lastAiFixArtifacts, behaviorName, testFilePath);
		}
		ProgramTabControl.SelectedIndex = ProgramTabControl.Items.Count - 1;
		SuccessLog("[AI修伏笔] 提示词已准备好，可直接复制给外部 AI。");
	}

	private void CopyAiFixPromptButton_Click(object sender, RoutedEventArgs e)
	{
		if (string.IsNullOrWhiteSpace(AiFixPromptTextBox.Text))
		{
			GenerateAiFixPromptButton_Click(sender, e);
			if (string.IsNullOrWhiteSpace(AiFixPromptTextBox.Text))
			{
				return;
			}
		}
		try
		{
			System.Windows.Clipboard.SetText(AiFixPromptTextBox.Text);
			AiFixStatusLabel.Content = "提示词已复制到剪贴板。";
			SuccessLog("[AI修伏笔] 提示词已复制到剪贴板。");
		}
		catch (Exception ex)
		{
			WarnLog("[AI修伏笔] 复制提示词失败: " + ex.Message);
		}
	}

	private void OpenBehaviorSourceButton_Click(object sender, RoutedEventArgs e)
	{
		string behaviorName = RoutineComboBox.SelectedItem?.ToString();
		List<string> list = FindBehaviorSourceFiles(behaviorName);
		if (list.Count == 0)
		{
			WarnLog("[AI修伏笔] 未找到当前策略源码。");
			return;
		}
		ShowOpenWithDialog(list[0]);
		SuccessLog("[AI修伏笔] 已打开策略源码: " + list[0]);
	}

	private void LoadInteractiveAiFixButton_Click(object sender, RoutedEventArgs e)
	{
		EnsureInteractiveAiFixBoardLoaded();
	}

	private bool ApplyInteractiveCandidate(InteractiveCandidateItem selected, bool autoApplied)
	{
		if (selected == null || selected.Candidate == null)
		{
			WarnLog("[交互修伏笔] 请先选择一个候选动作。");
			return false;
		}
		ManualActionStep manualActionStep = new ManualActionStep
		{
			StepIndex = _interactiveActionSteps.Count + 1,
			Action = selected.Action,
			ChangeSummary = selected.ChangeSummary,
			SourceImage = selected.SourceImage,
			TargetImage = selected.TargetImage,
			ActionObject = selected.Candidate.ActionObject,
			ActionWrapper = selected.Candidate.ActionWrapper,
			BoardBefore = _interactiveCurrentBoard,
			BoardAfter = selected.Candidate.Board
		};
		_interactiveActionSteps.Add(manualActionStep);
		_interactiveCurrentBoard = selected.Candidate.Board;
		_interactiveSelectedSource = null;
		_interactiveSelectedTarget = null;
		_interactiveSelectedSpecialSource = InteractiveSpecialSourceKind.None;
		_interactiveSelectedPreferredPlace = null;
		RefreshInteractiveAiFixBoard();
		AiFixManualActionListBox.SelectedItem = manualActionStep;
		if (!autoApplied)
		{
			SuccessLog("[交互修伏笔] 已应用动作: " + manualActionStep.Action);
		}
		else
		{
			SuccessLog("[交互修伏笔] 已自动应用动作: " + manualActionStep.Action);
		}
		return true;
	}

	private void ApplyInteractiveCandidateButton_Click(object sender, RoutedEventArgs e)
	{
		ApplyInteractiveCandidate(AiFixCandidateActionListBox.SelectedItem as InteractiveCandidateItem, autoApplied: false);
	}

	private void AiFixCandidateActionListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
	{
		ApplyInteractiveCandidate(AiFixCandidateActionListBox.SelectedItem as InteractiveCandidateItem, autoApplied: false);
	}

	private void UndoInteractiveActionButton_Click(object sender, RoutedEventArgs e)
	{
		if (_interactiveRootBoard == null)
		{
			WarnLog("[交互修伏笔] 还没有加载可交互的回合。");
			return;
		}
		if (_interactiveActionSteps.Count > 0)
		{
			_interactiveActionSteps.RemoveAt(_interactiveActionSteps.Count - 1);
		}
		_interactiveCurrentBoard = ((_interactiveActionSteps.Count > 0) ? _interactiveActionSteps[_interactiveActionSteps.Count - 1].BoardAfter : _interactiveRootBoard);
		_interactiveSelectedSource = null;
		_interactiveSelectedTarget = null;
		_interactiveSelectedSpecialSource = InteractiveSpecialSourceKind.None;
		_interactiveSelectedPreferredPlace = null;
		RefreshInteractiveAiFixBoard();
		SuccessLog("[交互修伏笔] 已回退一步。");
	}

	private void ResetInteractiveActionButton_Click(object sender, RoutedEventArgs e)
	{
		if (_interactiveRootBoard == null)
		{
			WarnLog("[交互修伏笔] 还没有加载可交互的回合。");
			return;
		}
		_interactiveCurrentBoard = _interactiveRootBoard;
		_interactiveSelectedSource = null;
		_interactiveSelectedTarget = null;
		_interactiveSelectedSpecialSource = InteractiveSpecialSourceKind.None;
		_interactiveSelectedPreferredPlace = null;
		_interactiveActionSteps.Clear();
		RefreshInteractiveAiFixBoard();
		SuccessLog("[交互修伏笔] 已重置回合操作。");
	}

	private void CopyManualActionButton_Click(object sender, RoutedEventArgs e)
	{
		UpdateManualActionScript();
		if (string.IsNullOrWhiteSpace(_currentManualActionScript))
		{
			WarnLog("[交互修伏笔] 当前还没有手动动作序列。");
			return;
		}
		try
		{
			System.Windows.Clipboard.SetText(_currentManualActionScript);
			SuccessLog("[交互修伏笔] 手动动作序列已复制到剪贴板。");
		}
		catch (Exception ex)
		{
			WarnLog("[交互修伏笔] 复制动作序列失败: " + ex.Message);
		}
	}

	private void InteractiveEntityListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		if (_suppressInteractiveSelectionChanged || _interactiveCurrentBoard == null)
		{
			return;
		}
		System.Windows.Controls.ListBox listBox = sender as System.Windows.Controls.ListBox;
		if (!(listBox?.SelectedItem is InteractiveEntityItem interactiveEntityItem))
		{
			return;
		}
		bool flag = sender == AiFixOwnBoardListBox && _interactiveSelectedSource != null && _interactiveSelectedSource.Kind == InteractiveEntityKind.OwnHand && (interactiveEntityItem.Kind == InteractiveEntityKind.OwnHero || interactiveEntityItem.Kind == InteractiveEntityKind.OwnMinion);
		if (!interactiveEntityItem.IsSelectable && !flag)
		{
			_suppressInteractiveSelectionChanged = true;
			try
			{
				if (listBox != null)
				{
					listBox.SelectedItem = null;
				}
				return;
			}
			finally
			{
				_suppressInteractiveSelectionChanged = false;
			}
		}
		_interactiveSelectedSpecialSource = InteractiveSpecialSourceKind.None;
		if (sender == AiFixOwnHandListBox)
		{
			if (_interactiveSelectedSource != null && interactiveEntityItem.EntityId == _interactiveSelectedSource.EntityId)
			{
				_interactiveSelectedSource = null;
				_interactiveSelectedTarget = null;
				_interactiveSelectedPreferredPlace = null;
			}
			else
			{
				_interactiveSelectedSource = interactiveEntityItem;
				_interactiveSelectedTarget = null;
				_interactiveSelectedPreferredPlace = null;
			}
		}
		else if (sender == AiFixEnemyBoardListBox)
		{
			if (_interactiveSelectedSource == null)
			{
				_interactiveSelectedTarget = null;
			}
			else
			{
				bool flag2 = _interactiveSelectedTarget != null && interactiveEntityItem.EntityId == _interactiveSelectedTarget.EntityId;
				_interactiveSelectedTarget = (flag2 ? null : interactiveEntityItem);
			}
		}
		else if (sender == AiFixOwnBoardListBox)
		{
			if (flag && !interactiveEntityItem.IsCandidateTarget)
			{
				_interactiveSelectedPreferredPlace = GetDesiredPlaceForOwnBoardDropTarget(interactiveEntityItem, placeAfter: true);
				_interactiveSelectedTarget = null;
				RebuildInteractiveCandidates();
				UpdateInteractiveEntityVisualHints();
				UpdateInteractiveStatus();
				_suppressInteractiveSelectionChanged = true;
				try
				{
					if (listBox != null)
					{
						listBox.SelectedItem = null;
					}
				}
				finally
				{
					_suppressInteractiveSelectionChanged = false;
				}
				if (_interactiveCandidateItems.Count == 1 && _interactiveCandidateItems[0]?.Candidate?.ActionWrapper != null && GetActionTargetEntityIds(_interactiveCandidateItems[0].Candidate.ActionWrapper).Count == 0)
				{
					ApplyInteractiveCandidate(_interactiveCandidateItems[0], autoApplied: true);
				}
				return;
			}
			bool flag3 = _interactiveSelectedSource != null && interactiveEntityItem.EntityId == _interactiveSelectedSource.EntityId;
			bool flag4 = _interactiveSelectedTarget != null && interactiveEntityItem.EntityId == _interactiveSelectedTarget.EntityId;
			if (flag3)
			{
				_interactiveSelectedSource = null;
				_interactiveSelectedTarget = null;
				_interactiveSelectedPreferredPlace = null;
			}
			else if (flag4)
			{
				_interactiveSelectedTarget = null;
			}
			else if (_interactiveSelectedSource == null)
			{
				_interactiveSelectedSource = interactiveEntityItem;
				_interactiveSelectedTarget = null;
				_interactiveSelectedPreferredPlace = null;
			}
			else if (interactiveEntityItem.IsCandidateTarget)
			{
				_interactiveSelectedTarget = interactiveEntityItem;
			}
			else
			{
				_interactiveSelectedSource = interactiveEntityItem;
				_interactiveSelectedTarget = null;
				_interactiveSelectedPreferredPlace = null;
			}
		}
		RebuildInteractiveCandidates();
		UpdateInteractiveEntityVisualHints();
		UpdateInteractiveStatus();
		_suppressInteractiveSelectionChanged = true;
		try
		{
			if (listBox != null)
			{
				listBox.SelectedItem = null;
			}
		}
		finally
		{
			_suppressInteractiveSelectionChanged = false;
		}
		if (_interactiveSelectedSource != null && _interactiveSelectedTarget != null && _interactiveCandidateItems.Count == 1)
		{
			ApplyInteractiveCandidate(_interactiveCandidateItems[0], autoApplied: true);
		}
	}

	private void AiFixEndTurnButton_Click(object sender, RoutedEventArgs e)
	{
		if (_interactiveCurrentBoard == null)
		{
			WarnLog("[交互修伏笔] 还没有加载可交互的回合。");
			return;
		}
		CandidateActionView candidateActionView = (from candidate in _interactiveAllCandidates
			where candidate != null && candidate.ActionWrapper?.actionType == actionEnum.endturn
			orderby candidate.Score descending
			select candidate).FirstOrDefault();
		if (candidateActionView == null)
		{
			WarnLog("[交互修伏笔] 当前回合没有可用的结束回合动作。");
		}
		else
		{
			ApplyInteractiveCandidate(BuildInteractiveCandidateItem(candidateActionView), autoApplied: true);
		}
	}

	private void PopoutInteractiveAiFixButton_Click(object sender, RoutedEventArgs e)
	{
		if (_interactiveAiFixWindow != null)
		{
			try
			{
				if (_interactiveAiFixWindow.WindowState == WindowState.Minimized)
				{
					_interactiveAiFixWindow.WindowState = WindowState.Normal;
				}
				_interactiveAiFixWindow.Activate();
				return;
			}
			catch
			{
				return;
			}
		}
		if (AiFixInteractiveHost == null || AiFixInteractiveRoot == null)
		{
			return;
		}
		if (_interactiveAiFixHostPlaceholder == null)
		{
			_interactiveAiFixHostPlaceholder = new Border
			{
				Background = Brushes.Transparent,
				Child = new TextBlock
				{
					Text = "交互盘面已在新窗口打开（关闭窗口会自动回到这里）。",
					Opacity = 0.7,
					TextWrapping = TextWrapping.Wrap,
					Margin = new Thickness(8.0)
				}
			};
		}
		try
		{
			AiFixInteractiveHost.Content = _interactiveAiFixHostPlaceholder;
		}
		catch
		{
			return;
		}
		Window window = new Window
		{
			Title = "AI修伏笔 - 交互盘面",
			Content = AiFixInteractiveRoot,
			Owner = this,
			Width = 1500.0,
			Height = 950.0,
			WindowStartupLocation = WindowStartupLocation.CenterOwner
		};
		window.Closed += delegate
		{
			try
			{
				if (AiFixInteractiveHost != null)
				{
					AiFixInteractiveHost.Content = AiFixInteractiveRoot;
				}
			}
			catch
			{
			}
			_interactiveAiFixWindow = null;
		};
		_interactiveAiFixWindow = window;
		window.Show();
	}

	private void AiFixHeroPowerCard_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
	{
		if (_interactiveCurrentBoard != null)
		{
			CandidateActionView candidateActionView = (from candidate in _interactiveAllCandidates
				where candidate != null && candidate.ActionWrapper?.actionType == actionEnum.useHeroPower
				where GetActionTargetEntityIds(candidate.ActionWrapper).Count == 0
				orderby candidate.Score descending
				select candidate).FirstOrDefault();
			if (candidateActionView != null)
			{
				ApplyInteractiveCandidate(BuildInteractiveCandidateItem(candidateActionView), autoApplied: true);
				return;
			}
			_interactiveSelectedSource = null;
			_interactiveSelectedTarget = null;
			_interactiveSelectedSpecialSource = ((_interactiveSelectedSpecialSource != InteractiveSpecialSourceKind.HeroPower) ? InteractiveSpecialSourceKind.HeroPower : InteractiveSpecialSourceKind.None);
			RebuildInteractiveCandidates();
			UpdateInteractiveEntityVisualHints();
			UpdateInteractiveStatus();
		}
	}

	private void AiFixHeroPowerCard_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
	{
		if (_interactiveCurrentBoard != null)
		{
			_interactivePendingDrag = new InteractiveDragPayload
			{
				SpecialSource = InteractiveSpecialSourceKind.HeroPower,
				SourceEntityId = 0,
				SourceKind = InteractiveEntityKind.Unknown
			};
			_interactiveDragStartPoint = e.GetPosition(sender as IInputElement);
		}
	}

	private void AiFixHeroPowerCard_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
	{
		if (_interactivePendingDrag != null && e.LeftButton == MouseButtonState.Pressed)
		{
			Point position = e.GetPosition(sender as IInputElement);
			if (!(Math.Abs(position.X - _interactiveDragStartPoint.X) < SystemParameters.MinimumHorizontalDragDistance) || !(Math.Abs(position.Y - _interactiveDragStartPoint.Y) < SystemParameters.MinimumVerticalDragDistance))
			{
				System.Windows.DataObject data = new System.Windows.DataObject(typeof(InteractiveDragPayload), _interactivePendingDrag);
				_interactivePendingDrag = null;
				DragDrop.DoDragDrop(sender as DependencyObject, data, System.Windows.DragDropEffects.Move);
			}
		}
	}

	private void InteractiveEntityCard_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
	{
		if (_interactiveCurrentBoard != null && (sender as ListBoxItem)?.DataContext is InteractiveEntityItem interactiveEntityItem)
		{
			if (interactiveEntityItem.Kind != InteractiveEntityKind.OwnHand && interactiveEntityItem.Kind != InteractiveEntityKind.OwnMinion && interactiveEntityItem.Kind != InteractiveEntityKind.OwnHero)
			{
				_interactivePendingDrag = null;
				return;
			}
			_interactivePendingDrag = new InteractiveDragPayload
			{
				SpecialSource = InteractiveSpecialSourceKind.None,
				SourceEntityId = interactiveEntityItem.EntityId,
				SourceKind = interactiveEntityItem.Kind
			};
			_interactiveDragStartPoint = e.GetPosition(sender as IInputElement);
		}
	}

	private void InteractiveEntityCard_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
	{
		if (_interactivePendingDrag != null && e.LeftButton == MouseButtonState.Pressed)
		{
			Point position = e.GetPosition(sender as IInputElement);
			if (!(Math.Abs(position.X - _interactiveDragStartPoint.X) < SystemParameters.MinimumHorizontalDragDistance) || !(Math.Abs(position.Y - _interactiveDragStartPoint.Y) < SystemParameters.MinimumVerticalDragDistance))
			{
				System.Windows.DataObject data = new System.Windows.DataObject(typeof(InteractiveDragPayload), _interactivePendingDrag);
				_interactivePendingDrag = null;
				DragDrop.DoDragDrop(sender as DependencyObject, data, System.Windows.DragDropEffects.Move);
			}
		}
	}

	private void InteractiveEntityCard_DragOver(object sender, System.Windows.DragEventArgs e)
	{
		if (_interactiveCurrentBoard == null || !e.Data.GetDataPresent(typeof(InteractiveDragPayload)))
		{
			e.Effects = System.Windows.DragDropEffects.None;
			e.Handled = true;
			return;
		}
		InteractiveEntityItem interactiveEntityItem = (sender as ListBoxItem)?.DataContext as InteractiveEntityItem;
		InteractiveDragPayload interactiveDragPayload = e.Data.GetData(typeof(InteractiveDragPayload)) as InteractiveDragPayload;
		if (interactiveEntityItem == null || interactiveDragPayload == null)
		{
			e.Effects = System.Windows.DragDropEffects.None;
			e.Handled = true;
			return;
		}
		bool flag = interactiveDragPayload.SpecialSource == InteractiveSpecialSourceKind.None && interactiveDragPayload.SourceKind == InteractiveEntityKind.OwnHand && (interactiveEntityItem.Kind == InteractiveEntityKind.OwnHero || interactiveEntityItem.Kind == InteractiveEntityKind.OwnMinion || interactiveEntityItem.Kind == InteractiveEntityKind.OwnWeapon || interactiveEntityItem.Kind == InteractiveEntityKind.OwnSecret || interactiveEntityItem.Kind == InteractiveEntityKind.OwnQuest || interactiveEntityItem.Kind == InteractiveEntityKind.OwnSideQuest);
		bool flag2 = interactiveEntityItem.IsSelectable || flag;
		e.Effects = (flag2 ? System.Windows.DragDropEffects.Move : System.Windows.DragDropEffects.None);
		e.Handled = true;
	}

	private void InteractiveEntityCard_Drop(object sender, System.Windows.DragEventArgs e)
	{
		if (_interactiveCurrentBoard == null || !e.Data.GetDataPresent(typeof(InteractiveDragPayload)) || !((sender as ListBoxItem)?.DataContext is InteractiveEntityItem interactiveEntityItem))
		{
			return;
		}
		InteractiveDragPayload payload = e.Data.GetData(typeof(InteractiveDragPayload)) as InteractiveDragPayload;
		if (payload == null)
		{
			return;
		}
		if (payload.SpecialSource == InteractiveSpecialSourceKind.HeroPower)
		{
			CandidateActionView candidateActionView = FindBestSpecialCandidate(actionEnum.useHeroPower, interactiveEntityItem.EntityId);
			if (candidateActionView == null)
			{
				WarnLog("[交互修伏笔] 英雄技能无法对该目标使用。");
			}
			else
			{
				ApplyInteractiveCandidate(BuildInteractiveCandidateItem(candidateActionView), autoApplied: true);
			}
		}
		else
		{
			if (payload.SourceEntityId == 0)
			{
				return;
			}
			CandidateActionView candidateActionView2 = FindBestEntityToEntityCandidate(payload.SourceEntityId, interactiveEntityItem.EntityId);
			if (candidateActionView2 != null)
			{
				ApplyInteractiveCandidate(BuildInteractiveCandidateItem(candidateActionView2), autoApplied: true);
			}
			else if (payload.SourceKind == InteractiveEntityKind.OwnHand && (interactiveEntityItem.Kind == InteractiveEntityKind.OwnHero || interactiveEntityItem.Kind == InteractiveEntityKind.OwnMinion || interactiveEntityItem.Kind == InteractiveEntityKind.OwnWeapon || interactiveEntityItem.Kind == InteractiveEntityKind.OwnSecret || interactiveEntityItem.Kind == InteractiveEntityKind.OwnQuest || interactiveEntityItem.Kind == InteractiveEntityKind.OwnSideQuest))
			{
				int desiredPlace;
				if (interactiveEntityItem.Kind == InteractiveEntityKind.OwnMinion)
				{
					bool placeAfter = true;
					try
					{
						if (sender is ListBoxItem listBoxItem)
						{
							placeAfter = e.GetPosition(listBoxItem).X >= listBoxItem.ActualWidth / 2.0;
						}
					}
					catch
					{
					}
					desiredPlace = GetDesiredPlaceForOwnBoardDropTarget(interactiveEntityItem, placeAfter);
				}
				else if (interactiveEntityItem.Kind == InteractiveEntityKind.OwnHero)
				{
					desiredPlace = 0;
				}
				else
				{
					desiredPlace = ComputeOwnBoardPlacementIndexFromDrop(e.GetPosition(AiFixOwnBoardListBox));
				}
				List<CandidateActionView> list = (from candidate in _interactiveAllCandidates
					where candidate?.ActionWrapper != null
					where candidate.ActionWrapper.actionType == actionEnum.playcard
					where GetActionSourceEntityId(candidate.ActionWrapper) == payload.SourceEntityId
					where candidate.ActionWrapper.place == desiredPlace
					orderby candidate.Score descending
					select candidate).ToList();
				if (list.Count == 0)
				{
					CandidateActionView candidateActionView3 = FindBestEntityToNoTargetCandidate(payload.SourceEntityId);
					if (candidateActionView3 != null)
					{
						ApplyInteractiveCandidate(BuildInteractiveCandidateItem(candidateActionView3), autoApplied: true);
					}
					else
					{
						WarnLog("[交互修伏笔] 该位置没有可用的出牌动作。");
					}
					return;
				}
				CandidateActionView candidateActionView4 = list.Where((CandidateActionView candidate) => GetActionTargetEntityIds(candidate.ActionWrapper).Count == 0).FirstOrDefault();
				if (candidateActionView4 != null)
				{
					ApplyInteractiveCandidate(BuildInteractiveCandidateItem(candidateActionView4), autoApplied: true);
					return;
				}
				_interactiveSelectedSpecialSource = InteractiveSpecialSourceKind.None;
				_interactiveSelectedPreferredPlace = desiredPlace;
				_interactiveSelectedTarget = null;
				_interactiveSelectedSource = FindInteractiveEntityItemByEntityId(payload.SourceEntityId) ?? new InteractiveEntityItem
				{
					EntityId = payload.SourceEntityId,
					Kind = payload.SourceKind
				};
				RebuildInteractiveCandidates();
				UpdateInteractiveEntityVisualHints();
				UpdateInteractiveStatus();
				InfoLog("[交互修伏笔] 已锁定放置位置 " + desiredPlace + "，请选择目标。");
			}
			else
			{
				WarnLog("[交互修伏笔] 没有找到匹配的可执行动作。");
			}
		}
	}

	private void InteractiveEntityZone_DragOver(object sender, System.Windows.DragEventArgs e)
	{
		if (_interactiveCurrentBoard == null || !e.Data.GetDataPresent(typeof(InteractiveDragPayload)))
		{
			e.Effects = System.Windows.DragDropEffects.None;
			e.Handled = true;
		}
		else
		{
			e.Effects = System.Windows.DragDropEffects.Move;
			e.Handled = true;
		}
	}

	private void InteractiveEntityZone_Drop(object sender, System.Windows.DragEventArgs e)
	{
		if (_interactiveCurrentBoard == null || !e.Data.GetDataPresent(typeof(InteractiveDragPayload)))
		{
			return;
		}
		InteractiveDragPayload payload = e.Data.GetData(typeof(InteractiveDragPayload)) as InteractiveDragPayload;
		if (payload == null || sender != AiFixOwnBoardListBox)
		{
			return;
		}
		if (payload.SpecialSource == InteractiveSpecialSourceKind.HeroPower)
		{
			CandidateActionView candidateActionView = FindBestSpecialCandidate(actionEnum.useHeroPower, null);
			if (candidateActionView == null)
			{
				WarnLog("[交互修伏笔] 当前英雄技能需要目标，请拖拽到目标上。");
			}
			else
			{
				ApplyInteractiveCandidate(BuildInteractiveCandidateItem(candidateActionView), autoApplied: true);
			}
		}
		else
		{
			if (payload.SourceEntityId == 0)
			{
				return;
			}
			if (payload.SpecialSource == InteractiveSpecialSourceKind.None && payload.SourceKind == InteractiveEntityKind.OwnHand)
			{
				int desiredPlace = ComputeOwnBoardPlacementIndexFromDrop(e.GetPosition(AiFixOwnBoardListBox));
				List<CandidateActionView> list = (from candidate in _interactiveAllCandidates
					where candidate?.ActionWrapper != null
					where candidate.ActionWrapper.actionType == actionEnum.playcard
					where GetActionSourceEntityId(candidate.ActionWrapper) == payload.SourceEntityId
					where candidate.ActionWrapper.place == desiredPlace
					orderby candidate.Score descending
					select candidate).ToList();
				if (list.Count > 0)
				{
					CandidateActionView candidateActionView2 = list.Where((CandidateActionView candidate) => GetActionTargetEntityIds(candidate.ActionWrapper).Count == 0).FirstOrDefault();
					if (candidateActionView2 != null)
					{
						ApplyInteractiveCandidate(BuildInteractiveCandidateItem(candidateActionView2), autoApplied: true);
						return;
					}
					_interactiveSelectedPreferredPlace = desiredPlace;
					_interactiveSelectedTarget = null;
					_interactiveSelectedSpecialSource = InteractiveSpecialSourceKind.None;
					_interactiveSelectedSource = FindInteractiveEntityItemByEntityId(payload.SourceEntityId) ?? new InteractiveEntityItem
					{
						EntityId = payload.SourceEntityId,
						Kind = payload.SourceKind
					};
					RebuildInteractiveCandidates();
					UpdateInteractiveEntityVisualHints();
					UpdateInteractiveStatus();
					InfoLog("[交互修伏笔] 已锁定放置位置 " + desiredPlace + "，请选择目标。");
					return;
				}
			}
			CandidateActionView candidateActionView3 = FindBestEntityToNoTargetCandidate(payload.SourceEntityId);
			if (candidateActionView3 == null)
			{
				WarnLog("[交互修伏笔] 没有找到无需目标的可执行动作。");
			}
			else
			{
				ApplyInteractiveCandidate(BuildInteractiveCandidateItem(candidateActionView3), autoApplied: true);
			}
		}
	}

	private CandidateActionView FindBestSpecialCandidate(actionEnum type, int? targetEntityId)
	{
		IEnumerable<CandidateActionView> source = _interactiveAllCandidates.Where((CandidateActionView candidate) => candidate != null && candidate.ActionWrapper?.actionType == type);
		source = ((!targetEntityId.HasValue) ? source.Where((CandidateActionView candidate) => GetActionTargetEntityIds(candidate.ActionWrapper).Count == 0) : source.Where((CandidateActionView candidate) => GetActionTargetEntityIds(candidate.ActionWrapper).Contains(targetEntityId.Value)));
		return source.OrderByDescending((CandidateActionView candidate) => candidate.Score).FirstOrDefault();
	}

	private CandidateActionView FindBestEntityToEntityCandidate(int sourceEntityId, int targetEntityId)
	{
		return (from candidate in _interactiveAllCandidates
			where candidate?.ActionWrapper != null
			where GetActionSourceEntityId(candidate.ActionWrapper) == sourceEntityId
			where GetActionTargetEntityIds(candidate.ActionWrapper).Contains(targetEntityId)
			orderby candidate.Score descending
			select candidate).FirstOrDefault();
	}

	private CandidateActionView FindBestEntityToNoTargetCandidate(int sourceEntityId)
	{
		return (from candidate in _interactiveAllCandidates
			where candidate?.ActionWrapper != null
			where GetActionSourceEntityId(candidate.ActionWrapper) == sourceEntityId
			where GetActionTargetEntityIds(candidate.ActionWrapper).Count == 0
			orderby candidate.Score descending
			select candidate).FirstOrDefault();
	}

	private CandidateActionView FindBestPlaycardNoTargetCandidate(int sourceEntityId, int desiredPlace)
	{
		List<CandidateActionView> source = (from candidate in _interactiveAllCandidates
			where candidate?.ActionWrapper != null
			where candidate.ActionWrapper.actionType == actionEnum.playcard
			where GetActionSourceEntityId(candidate.ActionWrapper) == sourceEntityId
			where GetActionTargetEntityIds(candidate.ActionWrapper).Count == 0
			select candidate).ToList();
		return (from candidate in source
			where candidate.ActionWrapper.place == desiredPlace
			orderby candidate.Score descending
			select candidate).FirstOrDefault();
	}

	private int GetDesiredPlaceForOwnBoardDropTarget(InteractiveEntityItem target, bool placeAfter)
	{
		if (target == null || _interactiveCurrentBoard == null)
		{
			return 0;
		}
		if (target.Kind == InteractiveEntityKind.OwnHero)
		{
			return 0;
		}
		if (target.Kind != InteractiveEntityKind.OwnMinion)
		{
			return 0;
		}
		int num = 0;
		if (_interactiveCurrentBoard.ownMinions is IEnumerable enumerable)
		{
			foreach (object item in enumerable)
			{
				try
				{
					Minion minion = new Minion(item);
					if (minion.entitiyID == target.EntityId)
					{
						return placeAfter ? (num + 1) : num;
					}
					num++;
				}
				catch
				{
				}
			}
		}
		return 0;
	}

	private int ComputeOwnBoardPlacementIndexFromDrop(Point dropPosition)
	{
		List<InteractiveEntityItem> list = new List<InteractiveEntityItem>();
		IEnumerable enumerable = AiFixOwnBoardListBox?.ItemsSource;
		if (enumerable != null)
		{
			foreach (object item in enumerable)
			{
				if (item is InteractiveEntityItem { Kind: InteractiveEntityKind.OwnMinion } interactiveEntityItem)
				{
					list.Add(interactiveEntityItem);
				}
			}
		}
		if (list.Count == 0)
		{
			return 0;
		}
		int num = 0;
		foreach (InteractiveEntityItem item2 in list)
		{
			if (!(AiFixOwnBoardListBox.ItemContainerGenerator.ContainerFromItem(item2) is ListBoxItem listBoxItem))
			{
				num++;
				continue;
			}
			double num2 = listBoxItem.TranslatePoint(new Point(0.0, 0.0), AiFixOwnBoardListBox).X + listBoxItem.ActualWidth / 2.0;
			if (dropPosition.X < num2)
			{
				return num;
			}
			num++;
		}
		return list.Count;
	}

	private InteractiveEntityItem FindInteractiveEntityItemByEntityId(int entityId)
	{
		if (entityId == 0)
		{
			return null;
		}
		IEnumerable[] array = new IEnumerable[3]
		{
			AiFixOwnHandListBox?.ItemsSource,
			AiFixOwnBoardListBox?.ItemsSource,
			AiFixEnemyBoardListBox?.ItemsSource
		};
		IEnumerable[] array2 = array;
		foreach (IEnumerable enumerable in array2)
		{
			if (enumerable == null)
			{
				continue;
			}
			foreach (object item in enumerable)
			{
				if (item is InteractiveEntityItem interactiveEntityItem && interactiveEntityItem.EntityId == entityId)
				{
					return interactiveEntityItem;
				}
			}
		}
		return null;
	}

	private void InteractiveCandidateActionListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		if (AiFixCandidateActionListBox.SelectedItem is InteractiveCandidateItem interactiveCandidateItem)
		{
			AiFixActionChangeTextBox.Text = "动作: " + interactiveCandidateItem.Action + Environment.NewLine + "来源: " + interactiveCandidateItem.Source + Environment.NewLine + "目标: " + interactiveCandidateItem.Target + Environment.NewLine + Environment.NewLine + interactiveCandidateItem.ChangeSummary;
		}
	}

	private void InteractiveManualActionListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		if (AiFixManualActionListBox.SelectedItem is ManualActionStep manualActionStep)
		{
			AiFixActionChangeTextBox.Text = manualActionStep.Title + " " + manualActionStep.Action + Environment.NewLine + Environment.NewLine + (manualActionStep.ChangeSummary ?? string.Empty);
		}
	}

	private void DeleteLogButton_Click(object sender, RoutedEventArgs e)
	{
		if (LogRichTextBox.Document.Blocks.FirstBlock is Paragraph paragraph)
		{
			paragraph.Inlines.Clear();
		}
		Settings settings = new Settings(Settings.Instance);
		string path = Path.Combine(settings.logpath, settings.logfile);
		if (File.Exists(path))
		{
			File.WriteAllText(path, string.Empty);
		}
	}

	private void CardNameLabel_MouseDown(object sender, MouseButtonEventArgs e)
	{
		if (sender is System.Windows.Controls.Label { Tag: not null } label)
		{
			DragDrop.DoDragDrop(label, label.Tag, System.Windows.DragDropEffects.Move);
		}
	}

	private void PlayfieldStepComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		object value = null;
		if (PlayfieldStepComboBox.SelectedItem == null || isExporting)
		{
			return;
		}
		playfieldActionList.TryGetValue(PlayfieldStepComboBox.SelectedItem.ToString(), out value);
		if (value != null)
		{
			if (value is Playfield playfield)
			{
				DisplayCurrentPlayField(playfield.Inst, PlayfieldStepComboBox.SelectedItem.ToString());
			}
			else
			{
				DisplayCurrentPlayField(value, PlayfieldStepComboBox.SelectedItem.ToString());
			}
			SuccessLog("[Playfield] Now choose to display " + PlayfieldStepComboBox.SelectedItem.ToString() + ".");
		}
		else
		{
			ErrorLog("[Playfield] Failed to display " + PlayfieldStepComboBox.SelectedItem.ToString() + ".");
		}
	}

	private void ActionScoreComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		try
		{
			if (lastHighlightedScore != -1f)
			{
				foreach (ActionItem item in actionScoreMap[lastHighlightedScore])
				{
					ActionItem actionItem = item;
					do
					{
						actionItem.Decision = "DarkRed";
						actionItem = actionItem.Father;
					}
					while (actionItem != null);
				}
			}
			float key = float.Parse(ActionScoreComboBox.SelectedItem.ToString());
			foreach (ActionItem item2 in actionScoreMap[key])
			{
				ActionItem actionItem2 = item2;
				do
				{
					actionItem2.Decision = "DarkGreen";
					actionItem2 = actionItem2.Father;
				}
				while (actionItem2 != null);
			}
			lastHighlightedScore = key;
			ActionTreeView.ItemsSource = this.actionItem.Items;
		}
		catch
		{
		}
	}

	private void VisualizePlayfieldButton_Click(object sender, RoutedEventArgs e)
	{
		ActionItem actionItem = (sender as System.Windows.Controls.Button).Tag as ActionItem;
		playfieldActionList.Clear();
		ActionItem actionItem2 = actionItem;
		do
		{
			playfieldActionList.Add((actionItem2.Level == 0) ? "回合开始" : ("第" + actionItem2.Level + "步"), actionItem2.Board);
			actionItem2 = actionItem2.Father;
		}
		while (actionItem2 != null);
		PlayfieldStepComboBox.SelectedIndex = -1;
		UpdatePlayfieldActionList();
		ProgramTabControl.SelectedItem = PlayfieldVisualizerTab;
	}

	private void ExportSelectionButton_Click(object sender, RoutedEventArgs e)
	{
		FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
		if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
		{
			string selectedPath = folderBrowserDialog.SelectedPath;
			if (!string.IsNullOrEmpty(selectedPath))
			{
				ExportPathBox.Text = selectedPath;
				GenerateButton.IsEnabled = true;
			}
		}
	}

	public static void DoEvents()
	{
		System.Windows.Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, (System.Action)delegate
		{
		});
	}

	public void ExportPlayfield(string path, ActionItem item)
	{
		foreach (ActionItem subGroup in item.subGroups)
		{
			DoEvents();
			ExportPlayfield(path, subGroup);
			DoEvents();
		}
		Playfield board = item.Board;
		if (!File.Exists(path))
		{
			using StreamWriter streamWriter = File.CreateText(path);
			streamWriter.WriteLine(PlayfieldSerializer.Instance.SerializePlayfield(board) + "," + item.Score);
		}
		else
		{
			using StreamWriter streamWriter2 = File.AppendText(path);
			streamWriter2.WriteLine(PlayfieldSerializer.Instance.SerializePlayfield(board) + "," + item.Score);
		}
		DoEvents();
	}

	private void GenerateButton_Click(object sender, RoutedEventArgs e)
	{
		if (!string.IsNullOrEmpty(ExportPathBox.Text))
		{
			string[] array = (from d in new DirectoryInfo(ExportPathBox.Text).EnumerateFiles("*.txt", SearchOption.AllDirectories)
				select d.FullName).ToArray();
			InfoLog("[Exporter] Now starting to export files...");
			isExporting = true;
			int num = 0;
			AiTestClass aiTestClass = new AiTestClass(compiledRoutines.GetType("HREngine.Bots.TestBase"));
			Type type = compiledRoutines.GetType("HREngine.Bots.Behavior" + RoutineComboBox.SelectedItem.ToString());
			string[] array2 = array;
			foreach (string testFilePath in array2)
			{
				DoEvents();
				aiTestClass.Test(testFilePath, Activator.CreateInstance(type));
				DoEvents();
				ExportPlayfield("SerializedResult.txt", actionItem);
				InfoLog("[Exporter] " + num + " / " + array.Length);
				num++;
			}
			isExporting = false;
			SuccessLog("[Exporter] Export complete!");
		}
		else
		{
			ErrorLog("[Exporter] Path undefined.");
		}
	}

	private void ExportCardButton_Click(object sender, RoutedEventArgs e)
	{
		string path = "SerializedCard.txt";
		ExportCardButton.IsEnabled = false;
		IEnumerator enumerator = ((IEnumerable)cardDB.cardlist).GetEnumerator();
		while (enumerator.MoveNext())
		{
			Card card = new Card(enumerator.Current);
			if (!File.Exists(path))
			{
				using StreamWriter streamWriter = File.CreateText(path);
				streamWriter.WriteLine(Regex.Replace(card.textCN, "\\t|\\n|\\r", ""));
			}
			else
			{
				using StreamWriter streamWriter2 = File.AppendText(path);
				streamWriter2.WriteLine(Regex.Replace(card.textCN, "\\t|\\n|\\r", ""));
			}
			DoEvents();
		}
		ExportCardButton.IsEnabled = true;
	}

    private void RefreshRecentTestFiles()
    {
        string desiredPath = NormalizeExistingPath(TestPathBox.Text)
            ?? NormalizeExistingPath(new XmlConfigUtil(_routineXml).Read("LastTestFile"));
        _suppressRecentTestSelectionChanged = true;
        try
        {
            RecentTestFilesComboBox.ItemsSource = null;
            RecentTestFilesComboBox.Items.Clear();
            RecentTestFilesComboBox.IsEnabled = false;
            if (!RoutineRuntime.TryResolveSilverfishPath(out var silverfishPath)) return;
            string testDataDirectory = RoutineRuntime.GetTestDataDirectory(silverfishPath);
            List<RecentTestFileItem> files = RoutineRuntime.EnumerateTestFiles(silverfishPath)
                .OrderByDescending(file => file.LastWriteTimeUtc)
                .ThenBy(file => file.FullName, StringComparer.OrdinalIgnoreCase)
                .Take(50)
                .Select(file => new RecentTestFileItem
                {
                    FullPath = file.FullName,
                    DisplayName = BuildRecentTestDisplayName(testDataDirectory, file.FullName)
                }).ToList();
            RecentTestFileItem selected = files.FirstOrDefault(file => string.Equals(file.FullPath, desiredPath, StringComparison.OrdinalIgnoreCase));
            if (desiredPath != null && selected == null)
            {
                selected = new RecentTestFileItem { FullPath = desiredPath, DisplayName = desiredPath };
                files.Insert(0, selected);
                if (files.Count > 50) files.RemoveAt(files.Count - 1);
            }
            selected ??= files.FirstOrDefault();
            RecentTestFilesComboBox.ItemsSource = files;
            RecentTestFilesComboBox.DisplayMemberPath = "DisplayName";
            RecentTestFilesComboBox.IsEnabled = files.Count > 0;
            RecentTestFilesComboBox.SelectedItem = selected;
            if (selected != null) TestPathBox.Text = selected.FullPath;
        }
        finally
        {
            _suppressRecentTestSelectionChanged = false;
        }
        RefreshSelectedTestFileContext();
    }

    private static string BuildRecentTestDisplayName(string testDataDirectory, string fullPath)
    {
        string relativePath = Path.GetRelativePath(testDataDirectory, fullPath);
        return relativePath.StartsWith(".." + Path.DirectorySeparatorChar, StringComparison.Ordinal)
            || Path.IsPathRooted(relativePath) ? fullPath : relativePath.Replace('\\', '/');
    }

	private void ApplyTestSummary(TestRunSummary summary)
	{
		if (summary == null)
		{
			return;
		}
		BestScore = summary.BestMoveValue;
		InfoLog("[Summary] 策略: " + summary.BehaviorName);
		InfoLog("[Summary] 牌面: " + summary.TestFilePath);
		InfoLog("[Summary] 最佳分数: " + summary.BestMoveValue.ToString("0.##"));
		if (!string.IsNullOrWhiteSpace(summary.LogFilePath))
		{
			InfoLog("[Summary] 日志: " + summary.LogFilePath);
		}
		if (summary.BestActions.Count == 0)
		{
			WarnLog("[Summary] 没有生成最佳动作。");
			return;
		}
		for (int i = 0; i < summary.BestActions.Count; i++)
		{
			InfoLog("[BestAction] (" + (i + 1) + ") " + summary.BestActions[i]);
		}
	}

	private void MainWindowLayout_Loaded(object sender, RoutedEventArgs e)
	{
		ExecuteButton.IsEnabled = false;
		ExecuteButton.Content = "启 动 中";
		base.DataContext = this;
		System.Windows.Application.Current.DispatcherUnhandledException += MainWindowUnhandledException;
		Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
		if (!EnsureKernelCompiledOnStartup())
		{
			Mouse.OverrideCursor = null;
			Close();
		}
		else
		{
			LoadAssembly();
			Mouse.OverrideCursor = null;
			InitWrapers();
		}
	}

}
