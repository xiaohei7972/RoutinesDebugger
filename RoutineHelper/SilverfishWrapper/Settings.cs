using System;
using System.Reflection;

namespace SilverfishWrapper;

public class Settings
{
	public object Inst;

	public static Type Type;

	private const BindingFlags AllFlags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

	public int enfacehp
	{
		get
		{
			return (int)Type.GetField("enfacehp", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enfacehp", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int weaponOnlyAttackMobsUntilEnfacehp
	{
		get
		{
			return (int)Type.GetField("weaponOnlyAttackMobsUntilEnfacehp", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("weaponOnlyAttackMobsUntilEnfacehp", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
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

	public int playaroundprob
	{
		get
		{
			return (int)Type.GetField("playaroundprob", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("playaroundprob", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
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

	public int twotsamount
	{
		get
		{
			return (int)Type.GetField("twotsamount", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("twotsamount", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyTurnMaxWide
	{
		get
		{
			return (int)Type.GetField("enemyTurnMaxWide", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyTurnMaxWide", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyTurnMaxWideSecondStep
	{
		get
		{
			return (int)Type.GetField("enemyTurnMaxWideSecondStep", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyTurnMaxWideSecondStep", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int nextTurnDeep
	{
		get
		{
			return (int)Type.GetField("nextTurnDeep", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("nextTurnDeep", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int nextTurnMaxWide
	{
		get
		{
			return (int)Type.GetField("nextTurnMaxWide", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("nextTurnMaxWide", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int nextTurnTotalBoards
	{
		get
		{
			return (int)Type.GetField("nextTurnTotalBoards", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("nextTurnTotalBoards", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int berserkIfCanFinishNextTour
	{
		get
		{
			return (int)Type.GetField("berserkIfCanFinishNextTour", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("berserkIfCanFinishNextTour", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int alpha
	{
		get
		{
			return (int)Type.GetField("alpha", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("alpha", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool useSecretsPlayAround
	{
		get
		{
			return (bool)Type.GetField("useSecretsPlayAround", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("useSecretsPlayAround", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int placement
	{
		get
		{
			return (int)Type.GetField("placement", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("placement", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool useExternalProcess
	{
		get
		{
			return (bool)Type.GetField("useExternalProcess", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("useExternalProcess", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool passiveWaiting
	{
		get
		{
			return (bool)Type.GetField("passiveWaiting", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("passiveWaiting", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int speedupLevel
	{
		get
		{
			return (int)Type.GetField("speedupLevel", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("speedupLevel", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int adjustActions
	{
		get
		{
			return (int)Type.GetField("adjustActions", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("adjustActions", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int printRules
	{
		get
		{
			return (int)Type.GetField("printRules", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("printRules", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int concedeMode
	{
		get
		{
			return (int)Type.GetField("concedeMode", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("concedeMode", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public float firstweight
	{
		get
		{
			return (float)Type.GetField("firstweight", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("firstweight", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public float secondweight
	{
		get
		{
			return (float)Type.GetField("secondweight", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("secondweight", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int numberOfThreads
	{
		get
		{
			return (int)Type.GetField("numberOfThreads", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("numberOfThreads", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool simulateEnemysTurn
	{
		get
		{
			return (bool)Type.GetField("simulateEnemysTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("simulateEnemysTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int secondTurnAmount
	{
		get
		{
			return (int)Type.GetField("secondTurnAmount", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("secondTurnAmount", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public string mainPath
	{
		get
		{
			return (string)Type.GetField("mainPath", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("mainPath", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public string path
	{
		get
		{
			return (string)Type.GetField("path", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("path", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public string logpath
	{
		get
		{
			return (string)Type.GetField("logpath", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("logpath", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public string logfile
	{
		get
		{
			return (string)Type.GetField("logfile", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("logfile", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool concede
	{
		get
		{
			return (bool)Type.GetField("concede", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("concede", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool enemyConcede
	{
		get
		{
			return (bool)Type.GetField("enemyConcede", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyConcede", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool writeToSingleFile
	{
		get
		{
			return (bool)Type.GetField("writeToSingleFile", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("writeToSingleFile", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool learnmode
	{
		get
		{
			return (bool)Type.GetField("learnmode", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("learnmode", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool printlearnmode
	{
		get
		{
			return (bool)Type.GetField("printlearnmode", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("printlearnmode", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool test
	{
		get
		{
			return (bool)Type.GetField("test", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("test", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
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

	public Settings(object inst)
	{
		Inst = inst;
	}

	public void setSettings(string behavName, bool nameIsPath)
	{
		Type[] types = new Type[2]
		{
			typeof(string),
			typeof(bool)
		};
		Type.GetMethod("setSettings", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { behavName, nameIsPath });
	}

	public void endOfSetSettings()
	{
		Type[] types = new Type[0];
		Type.GetMethod("endOfSetSettings", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public void setWeights(int alpha)
	{
		Type[] types = new Type[1] { typeof(int) };
		Type.GetMethod("setWeights", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { alpha });
	}

	public void setFilePath(string path)
	{
		Type[] types = new Type[1] { typeof(string) };
		Type.GetMethod("setFilePath", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { path });
	}

	public void setLoggPath(string path)
	{
		Type[] types = new Type[1] { typeof(string) };
		Type.GetMethod("setLoggPath", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { path });
	}

	public void setLoggFile(string path)
	{
		Type[] types = new Type[1] { typeof(string) };
		Type.GetMethod("setLoggFile", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { path });
	}

	public void printSettings()
	{
		Type[] types = new Type[0];
		Type.GetMethod("printSettings", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}
}
