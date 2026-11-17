using System;
using System.Reflection;

namespace SilverfishWrapper;

public class Ai
{
	public object Inst;

	public static Type Type;

	private const BindingFlags AllFlags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

	public int maxdeep
	{
		get
		{
			return (int)Type.GetField("maxdeep", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("maxdeep", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int maxwide
	{
		get
		{
			return (int)Type.GetField("maxwide", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("maxwide", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int maxCal
	{
		get
		{
			return (int)Type.GetField("maxCal", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("maxCal", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int playaroundprob2
	{
		get
		{
			return (int)Type.GetField("playaroundprob2", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("playaroundprob2", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int maxNumberOfThreads
	{
		get
		{
			return (int)Type.GetField("maxNumberOfThreads", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("maxNumberOfThreads", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool usePenalityManager
	{
		get
		{
			return (bool)Type.GetField("usePenalityManager", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("usePenalityManager", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool useCutingTargets
	{
		get
		{
			return (bool)Type.GetField("useCutingTargets", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("useCutingTargets", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool dontRecalc
	{
		get
		{
			return (bool)Type.GetField("dontRecalc", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("dontRecalc", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool useLethalCheck
	{
		get
		{
			return (bool)Type.GetField("useLethalCheck", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("useLethalCheck", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool useComparison
	{
		get
		{
			return (bool)Type.GetField("useComparison", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("useComparison", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object bestplay
	{
		get
		{
			return Type.GetField("bestplay", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("bestplay", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int lethalMissing
	{
		get
		{
			return (int)Type.GetField("lethalMissing", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("lethalMissing", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object mainTurnSimulator
	{
		get
		{
			return Type.GetField("mainTurnSimulator", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("mainTurnSimulator", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object enemyTurnSim
	{
		get
		{
			return Type.GetField("enemyTurnSim", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyTurnSim", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object nextTurnSimulator
	{
		get
		{
			return Type.GetField("nextTurnSimulator", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("nextTurnSimulator", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object enemySecondTurnSim
	{
		get
		{
			return Type.GetField("enemySecondTurnSim", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemySecondTurnSim", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public string currentCalculatedBoard
	{
		get
		{
			return (string)Type.GetField("currentCalculatedBoard", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("currentCalculatedBoard", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object penman
	{
		get
		{
			return Type.GetField("penman", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("penman", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object settings
	{
		get
		{
			return Type.GetField("settings", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("settings", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object posmoves
	{
		get
		{
			return Type.GetField("posmoves", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("posmoves", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object hp
	{
		get
		{
			return Type.GetField("hp", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("hp", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object hm
	{
		get
		{
			return Type.GetField("hm", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("hm", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object help
	{
		get
		{
			return Type.GetField("help", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("help", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object bestmove
	{
		get
		{
			return Type.GetField("bestmove", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("bestmove", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public float bestmoveValue
	{
		get
		{
			return (float)Type.GetField("bestmoveValue", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("bestmoveValue", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object nextMoveGuess
	{
		get
		{
			return Type.GetField("nextMoveGuess", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("nextMoveGuess", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object botBase
	{
		get
		{
			return Type.GetField("botBase", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("botBase", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object bestActions
	{
		get
		{
			return Type.GetField("bestActions", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("bestActions", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool secondturnsim
	{
		get
		{
			return (bool)Type.GetField("secondturnsim", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("secondturnsim", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool playaround
	{
		get
		{
			return (bool)Type.GetField("playaround", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("playaround", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public static object instance
	{
		get
		{
			return Type.GetField("instance", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(null);
		}
		set
		{
			Type.GetField("instance", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetValue(null, value);
		}
	}

	public static object Instance => Type.GetProperty("Instance", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(null);

	public Ai(object inst)
	{
		Inst = inst;
	}

	public void setMaxWide(int mw)
	{
		Type[] types = new Type[1] { typeof(int) };
		Type.GetMethod("setMaxWide", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { mw });
	}

	public void setMaxDeep(int mw)
	{
		Type[] types = new Type[1] { typeof(int) };
		Type.GetMethod("setMaxDeep", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { mw });
	}

	public void setMaxCal(int mw)
	{
		Type[] types = new Type[1] { typeof(int) };
		Type.GetMethod("setMaxCal", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { mw });
	}

	public void setTwoTurnSimulation(bool stts, int amount)
	{
		Type[] types = new Type[2]
		{
			typeof(bool),
			typeof(int)
		};
		Type.GetMethod("setTwoTurnSimulation", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { stts, amount });
	}

	public void updateTwoTurnSim()
	{
		Type[] types = new Type[0];
		Type.GetMethod("updateTwoTurnSim", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public void setPlayAround()
	{
		Type[] types = new Type[0];
		Type.GetMethod("setPlayAround", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public void doallmoves(bool test, bool isLethalCheck)
	{
		Type[] types = new Type[2]
		{
			typeof(bool),
			typeof(bool)
		};
		(Type.GetMethod("doAllMoves", BindingFlags.Instance | BindingFlags.Public) ?? Type.GetMethod("doallmoves", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null)).InvokeCompatible(Inst, new object[2] { test, isLethalCheck });
	}

	public void doNextCalcedMove()
	{
		Type[] types = new Type[0];
		Type.GetMethod("doNextCalcedMove", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public void dosomethingclever(object bbase)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Behavior") };
		Type.GetMethod("dosomethingclever", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { bbase });
	}

	public object autoTester(bool printstuff, string data, int mode)
	{
		Type[] types = new Type[3]
		{
			typeof(bool),
			typeof(string),
			typeof(int)
		};
		return Type.GetMethod("autoTester", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[3] { printstuff, data, mode });
	}

	public void simmulateWholeTurn(object bt)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.BoardTester") };
		Type.GetMethod("simmulateWholeTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { bt });
	}

	public void simmulateWholeTurnandPrint()
	{
		Type[] types = new Type[0];
		Type.GetMethod("simmulateWholeTurnandPrint", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public void updateEntitiy(int old, int newone)
	{
		Type[] types = new Type[2]
		{
			typeof(int),
			typeof(int)
		};
		Type.GetMethod("updateEntitiy", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { old, newone });
	}
}
