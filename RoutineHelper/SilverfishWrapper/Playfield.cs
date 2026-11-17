using System;
using System.Reflection;

namespace SilverfishWrapper;

public class Playfield
{
	public object Inst;

	public static Type Type;

	private const BindingFlags AllFlags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

	public int activeCardSummonOwner
	{
		get
		{
			return (int)Type.GetField("activeCardSummonOwner", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("activeCardSummonOwner", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int activeCardSummonMultiplier
	{
		get
		{
			return (int)Type.GetField("activeCardSummonMultiplier", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("activeCardSummonMultiplier", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int turn
	{
		get
		{
			return (int)Type.GetField("turn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("turn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool spellCostIncrease
	{
		get
		{
			return (bool)Type.GetField("spellCostIncrease", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("spellCostIncrease", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int loathebManaCostIncrease
	{
		get
		{
			return (int)Type.GetField("loathebManaCostIncrease", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("loathebManaCostIncrease", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object enemyHand
	{
		get
		{
			return Type.GetField("enemyHand", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyHand", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object ownDeck
	{
		get
		{
			return Type.GetField("ownDeck", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownDeck", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object enemyDeck
	{
		get
		{
			return Type.GetField("enemyDeck", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyDeck", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object ownGraveyard
	{
		get
		{
			return Type.GetField("ownGraveyard", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownGraveyard", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object ownSecretsIDList
	{
		get
		{
			return Type.GetField("ownSecretsIDList", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownSecretsIDList", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object ownAuraIDList
	{
		get
		{
			return Type.GetField("ownAuraIDList", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownAuraIDList", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object enemySecretList
	{
		get
		{
			return Type.GetField("enemySecretList", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemySecretList", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object enemyCardsOut
	{
		get
		{
			return Type.GetField("enemyCardsOut", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyCardsOut", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object nextPlayfields
	{
		get
		{
			return Type.GetField("nextPlayfields", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("nextPlayfields", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object ownMinions
	{
		get
		{
			return Type.GetField("ownMinions", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownMinions", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object enemyMinions
	{
		get
		{
			return Type.GetField("enemyMinions", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyMinions", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object diedMinions
	{
		get
		{
			return Type.GetField("diedMinions", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("diedMinions", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object LurkersDB
	{
		get
		{
			return Type.GetField("LurkersDB", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("LurkersDB", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object owncards
	{
		get
		{
			return Type.GetField("owncards", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("owncards", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object playactions
	{
		get
		{
			return Type.GetField("playactions", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("playactions", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object pIdHistory
	{
		get
		{
			return Type.GetField("pIdHistory", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("pIdHistory", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object spellHistory
	{
		get
		{
			return Type.GetField("spellHistory", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("spellHistory", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public string name
	{
		get
		{
			return (string)Type.GetField("name", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("name", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public string enemyGuessDeck
	{
		get
		{
			return (string)Type.GetField("enemyGuessDeck", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyGuessDeck", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool logging
	{
		get
		{
			return (bool)Type.GetField("logging", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("logging", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool complete
	{
		get
		{
			return (bool)Type.GetField("complete", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("complete", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int bestBoard
	{
		get
		{
			return (int)Type.GetField("bestBoard", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("bestBoard", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool dirtyTwoTurnSim
	{
		get
		{
			return (bool)Type.GetField("dirtyTwoTurnSim", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("dirtyTwoTurnSim", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool checkLostAct
	{
		get
		{
			return (bool)Type.GetField("checkLostAct", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("checkLostAct", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int totalAngr
	{
		get
		{
			return (int)Type.GetField("totalAngr", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("totalAngr", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyTotalAngr
	{
		get
		{
			return (int)Type.GetField("enemyTotalAngr", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyTotalAngr", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool patchesInDeck
	{
		get
		{
			return (bool)Type.GetField("patchesInDeck", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("patchesInDeck", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownMinionsDied
	{
		get
		{
			return (int)Type.GetField("ownMinionsDied", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownMinionsDied", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyMinionsDied
	{
		get
		{
			return (int)Type.GetField("enemyMinionsDied", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyMinionsDied", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool anzSolor
	{
		get
		{
			return (bool)Type.GetField("anzSolor", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzSolor", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownMinionStartCount
	{
		get
		{
			return (int)Type.GetField("ownMinionStartCount", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownMinionStartCount", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyMinionStartCount
	{
		get
		{
			return (int)Type.GetField("enemyMinionStartCount", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyMinionStartCount", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool hatchingPoolRush
	{
		get
		{
			return (bool)Type.GetField("hatchingPoolRush", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("hatchingPoolRush", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int spellsplayedThisTurn
	{
		get
		{
			return (int)Type.GetField("spellsplayedThisTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("spellsplayedThisTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int healOrDamageTimes
	{
		get
		{
			return (int)Type.GetField("healOrDamageTimes", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("healOrDamageTimes", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int oneCostCardsPlayedCount
	{
		get
		{
			return (int)Type.GetField("oneCostCardsPlayedCount", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("oneCostCardsPlayedCount", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int healTimes
	{
		get
		{
			return (int)Type.GetField("healTimes", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("healTimes", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool setMankrik
	{
		get
		{
			return (bool)Type.GetField("setMankrik", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("setMankrik", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int deckAngrBuff
	{
		get
		{
			return (int)Type.GetField("deckAngrBuff", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("deckAngrBuff", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int deckHpBuff
	{
		get
		{
			return (int)Type.GetField("deckHpBuff", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("deckHpBuff", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int nextEntity
	{
		get
		{
			return (int)Type.GetField("nextEntity", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("nextEntity", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int pID
	{
		get
		{
			return (int)Type.GetField("pID", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("pID", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool isLethalCheck
	{
		get
		{
			return (bool)Type.GetField("isLethalCheck", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("isLethalCheck", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyTurnsCount
	{
		get
		{
			return (int)Type.GetField("enemyTurnsCount", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyTurnsCount", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object tempTrigger
	{
		get
		{
			return Type.GetField("tempTrigger", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("tempTrigger", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object prozis
	{
		get
		{
			return Type.GetField("prozis", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("prozis", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int gTurn
	{
		get
		{
			return (int)Type.GetField("gTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("gTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int gTurnStep
	{
		get
		{
			return (int)Type.GetField("gTurnStep", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("gTurnStep", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int AnzSoulFragments
	{
		get
		{
			return (int)Type.GetField("AnzSoulFragments", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("AnzSoulFragments", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzOwnRaidleader
	{
		get
		{
			return (int)Type.GetField("anzOwnRaidleader", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzOwnRaidleader", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int leechDamage
	{
		get
		{
			return (int)Type.GetField("leechDamage", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("leechDamage", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyLeechDamage
	{
		get
		{
			return (int)Type.GetField("enemyLeechDamage", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyLeechDamage", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzEnemyRaidleader
	{
		get
		{
			return (int)Type.GetField("anzEnemyRaidleader", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzEnemyRaidleader", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzOwnVessina
	{
		get
		{
			return (int)Type.GetField("anzOwnVessina", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzOwnVessina", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzEnemyVessina
	{
		get
		{
			return (int)Type.GetField("anzEnemyVessina", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzEnemyVessina", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzOwnStormwindChamps
	{
		get
		{
			return (int)Type.GetField("anzOwnStormwindChamps", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzOwnStormwindChamps", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int zilliaxBonusAttack
	{
		get
		{
			return (int)Type.GetField("zilliaxBonusAttack", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("zilliaxBonusAttack", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzEnemyStormwindChamps
	{
		get
		{
			return (int)Type.GetField("anzEnemyStormwindChamps", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzEnemyStormwindChamps", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzOwnWarhorseTrainer
	{
		get
		{
			return (int)Type.GetField("anzOwnWarhorseTrainer", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzOwnWarhorseTrainer", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzEnemyWarhorseTrainer
	{
		get
		{
			return (int)Type.GetField("anzEnemyWarhorseTrainer", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzEnemyWarhorseTrainer", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzOwnTundrarhino
	{
		get
		{
			return (int)Type.GetField("anzOwnTundrarhino", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzOwnTundrarhino", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzEnemyTundrarhino
	{
		get
		{
			return (int)Type.GetField("anzEnemyTundrarhino", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzEnemyTundrarhino", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzOwnMrSmite
	{
		get
		{
			return (int)Type.GetField("anzOwnMrSmite", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzOwnMrSmite", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzEnemyMrSmite
	{
		get
		{
			return (int)Type.GetField("anzEnemyMrSmite", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzEnemyMrSmite", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzOwnTimberWolfs
	{
		get
		{
			return (int)Type.GetField("anzOwnTimberWolfs", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzOwnTimberWolfs", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzEnemyTimberWolfs
	{
		get
		{
			return (int)Type.GetField("anzEnemyTimberWolfs", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzEnemyTimberWolfs", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzOwnMurlocWarleader
	{
		get
		{
			return (int)Type.GetField("anzOwnMurlocWarleader", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzOwnMurlocWarleader", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzEnemyMurlocWarleader
	{
		get
		{
			return (int)Type.GetField("anzEnemyMurlocWarleader", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzEnemyMurlocWarleader", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzAcidmaw
	{
		get
		{
			return (int)Type.GetField("anzAcidmaw", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzAcidmaw", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzRazorscale
	{
		get
		{
			return (int)Type.GetField("anzRazorscale", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzRazorscale", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzOwnGrimscaleOracle
	{
		get
		{
			return (int)Type.GetField("anzOwnGrimscaleOracle", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzOwnGrimscaleOracle", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzEnemyGrimscaleOracle
	{
		get
		{
			return (int)Type.GetField("anzEnemyGrimscaleOracle", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzEnemyGrimscaleOracle", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzOwnShadowfiend
	{
		get
		{
			return (int)Type.GetField("anzOwnShadowfiend", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzOwnShadowfiend", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzOwnAuchenaiSoulpriest
	{
		get
		{
			return (int)Type.GetField("anzOwnAuchenaiSoulpriest", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzOwnAuchenaiSoulpriest", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzEnemyAuchenaiSoulpriest
	{
		get
		{
			return (int)Type.GetField("anzEnemyAuchenaiSoulpriest", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzEnemyAuchenaiSoulpriest", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzOwnSouthseacaptain
	{
		get
		{
			return (int)Type.GetField("anzOwnSouthseacaptain", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzOwnSouthseacaptain", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzEnemySouthseacaptain
	{
		get
		{
			return (int)Type.GetField("anzEnemySouthseacaptain", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzEnemySouthseacaptain", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzOwnMalGanis
	{
		get
		{
			return (int)Type.GetField("anzOwnMalGanis", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzOwnMalGanis", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzEnemyMalGanis
	{
		get
		{
			return (int)Type.GetField("anzEnemyMalGanis", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzEnemyMalGanis", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzOwnPiratesStarted
	{
		get
		{
			return (int)Type.GetField("anzOwnPiratesStarted", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzOwnPiratesStarted", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzOwnMurlocStarted
	{
		get
		{
			return (int)Type.GetField("anzOwnMurlocStarted", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzOwnMurlocStarted", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzOwnElementStarted
	{
		get
		{
			return (int)Type.GetField("anzOwnElementStarted", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzOwnElementStarted", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzOwnDraeneiStarted
	{
		get
		{
			return (int)Type.GetField("anzOwnDraeneiStarted", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzOwnDraeneiStarted", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzOwnTreantStarted
	{
		get
		{
			return (int)Type.GetField("anzOwnTreantStarted", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzOwnTreantStarted", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int copyDrawnCard
	{
		get
		{
			return (int)Type.GetField("copyDrawnCard", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("copyDrawnCard", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyCopyDrawnCard
	{
		get
		{
			return (int)Type.GetField("enemyCopyDrawnCard", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyCopyDrawnCard", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int dragonCostReduction
	{
		get
		{
			return (int)Type.GetField("dragonCostReduction", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("dragonCostReduction", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownFirstDragonCostOneAura
	{
		get
		{
			return (int)Type.GetField("ownFirstDragonCostOneAura", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownFirstDragonCostOneAura", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzOwnMurlocConsort
	{
		get
		{
			return (int)Type.GetField("anzOwnMurlocConsort", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzOwnMurlocConsort", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int dragonCostReductionJustUsed
	{
		get
		{
			return (int)Type.GetField("dragonCostReductionJustUsed", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("dragonCostReductionJustUsed", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownElementCost
	{
		get
		{
			return (int)Type.GetField("ownElementCost", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownElementCost", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownElementCostStarted
	{
		get
		{
			return (int)Type.GetField("ownElementCostStarted", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownElementCostStarted", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownBeastCostLessOnce
	{
		get
		{
			return (int)Type.GetField("ownBeastCostLessOnce", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownBeastCostLessOnce", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownBeastCostLessOnceStarted
	{
		get
		{
			return (int)Type.GetField("ownBeastCostLessOnceStarted", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownBeastCostLessOnceStarted", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzOwnBolfRamshield
	{
		get
		{
			return (int)Type.GetField("anzOwnBolfRamshield", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzOwnBolfRamshield", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzEnemyBolfRamshield
	{
		get
		{
			return (int)Type.GetField("anzEnemyBolfRamshield", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzEnemyBolfRamshield", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzOwnHorsemen
	{
		get
		{
			return (int)Type.GetField("anzOwnHorsemen", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzOwnHorsemen", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzEnemyHorsemen
	{
		get
		{
			return (int)Type.GetField("anzEnemyHorsemen", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzEnemyHorsemen", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzOwnAnimatedArmor
	{
		get
		{
			return (int)Type.GetField("anzOwnAnimatedArmor", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzOwnAnimatedArmor", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzEnemyAnimatedArmor
	{
		get
		{
			return (int)Type.GetField("anzEnemyAnimatedArmor", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzEnemyAnimatedArmor", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzMoorabi
	{
		get
		{
			return (int)Type.GetField("anzMoorabi", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzMoorabi", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzDark
	{
		get
		{
			return (int)Type.GetField("anzDark", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzDark", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzTamsinroame
	{
		get
		{
			return (int)Type.GetField("anzTamsinroame", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzTamsinroame", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzOldWoman
	{
		get
		{
			return (int)Type.GetField("anzOldWoman", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzOldWoman", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool anzTamsin
	{
		get
		{
			return (bool)Type.GetField("anzTamsin", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzTamsin", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzUsedOwnHeroPower
	{
		get
		{
			return (int)Type.GetField("anzUsedOwnHeroPower", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzUsedOwnHeroPower", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzUsedEnemyHeroPower
	{
		get
		{
			return (int)Type.GetField("anzUsedEnemyHeroPower", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzUsedEnemyHeroPower", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownHeroPowerUsesThisGame
	{
		get
		{
			return (int)Type.GetField("ownHeroPowerUsesThisGame", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownHeroPowerUsesThisGame", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyHeroPowerUsesThisGame
	{
		get
		{
			return (int)Type.GetField("enemyHeroPowerUsesThisGame", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyHeroPowerUsesThisGame", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzOwnExtraAngrHp
	{
		get
		{
			return (int)Type.GetField("anzOwnExtraAngrHp", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzOwnExtraAngrHp", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzEnemyExtraAngrHp
	{
		get
		{
			return (int)Type.GetField("anzEnemyExtraAngrHp", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzEnemyExtraAngrHp", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzOwnMechwarper
	{
		get
		{
			return (int)Type.GetField("anzOwnMechwarper", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzOwnMechwarper", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzOwnMechwarperStarted
	{
		get
		{
			return (int)Type.GetField("anzOwnMechwarperStarted", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzOwnMechwarperStarted", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzEnemyMechwarper
	{
		get
		{
			return (int)Type.GetField("anzEnemyMechwarper", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzEnemyMechwarper", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzEnemyMechwarperStarted
	{
		get
		{
			return (int)Type.GetField("anzEnemyMechwarperStarted", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzEnemyMechwarperStarted", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzOgOwnCThun
	{
		get
		{
			return (int)Type.GetField("anzOgOwnCThun", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzOgOwnCThun", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzHologramTech
	{
		get
		{
			return (int)Type.GetField("anzHologramTech", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzHologramTech", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool reverseDraw
	{
		get
		{
			return (bool)Type.GetField("reverseDraw", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("reverseDraw", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzOgOwnCThunHpBonus
	{
		get
		{
			return (int)Type.GetField("anzOgOwnCThunHpBonus", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzOgOwnCThunHpBonus", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzOgOwnCThunAngrBonus
	{
		get
		{
			return (int)Type.GetField("anzOgOwnCThunAngrBonus", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzOgOwnCThunAngrBonus", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzOgOwnCThunTaunt
	{
		get
		{
			return (int)Type.GetField("anzOgOwnCThunTaunt", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzOgOwnCThunTaunt", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzOwnJadeGolem
	{
		get
		{
			return (int)Type.GetField("anzOwnJadeGolem", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzOwnJadeGolem", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzEnemyJadeGolem
	{
		get
		{
			return (int)Type.GetField("anzEnemyJadeGolem", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzEnemyJadeGolem", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzOwnElementalsThisTurn
	{
		get
		{
			return (int)Type.GetField("anzOwnElementalsThisTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzOwnElementalsThisTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzOwnElementalsLastTurn
	{
		get
		{
			return (int)Type.GetField("anzOwnElementalsLastTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzOwnElementalsLastTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object ownRacesPlayedThisTurn
	{
		get
		{
			return Type.GetField("ownRacesPlayedThisTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownRacesPlayedThisTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object ownRacesPlayedLastTurn
	{
		get
		{
			return Type.GetField("ownRacesPlayedLastTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownRacesPlayedLastTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownDragonsPlayedThisTurn
	{
		get
		{
			return (int)Type.GetField("ownDragonsPlayedThisTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownDragonsPlayedThisTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object ownSpellSchoolsPlayedThisTurn
	{
		get
		{
			return Type.GetField("ownSpellSchoolsPlayedThisTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownSpellSchoolsPlayedThisTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object ownSpellSchoolsPlayedLastTurn
	{
		get
		{
			return Type.GetField("ownSpellSchoolsPlayedLastTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownSpellSchoolsPlayedLastTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object ownSpellsPlayedThisTurn
	{
		get
		{
			return Type.GetField("ownSpellsPlayedThisTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownSpellsPlayedThisTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object ownSpellsPlayedLastTurn
	{
		get
		{
			return Type.GetField("ownSpellsPlayedLastTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownSpellsPlayedLastTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownPendingRavenousFlock
	{
		get
		{
			return (int)Type.GetField("ownPendingRavenousFlock", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownPendingRavenousFlock", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyPendingRavenousFlock
	{
		get
		{
			return (int)Type.GetField("enemyPendingRavenousFlock", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyPendingRavenousFlock", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzEnemyTaunt
	{
		get
		{
			return (int)Type.GetField("anzEnemyTaunt", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzEnemyTaunt", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzOwnTaunt
	{
		get
		{
			return (int)Type.GetField("anzOwnTaunt", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzOwnTaunt", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ashElementalDmgCounter
	{
		get
		{
			return (int)Type.GetField("ashElementalDmgCounter", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ashElementalDmgCounter", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzOwnHeraldCount
	{
		get
		{
			return (int)Type.GetField("anzOwnHeraldCount", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzOwnHeraldCount", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzEnemyHeraldCount
	{
		get
		{
			return (int)Type.GetField("anzEnemyHeraldCount", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzEnemyHeraldCount", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzStoneshaper
	{
		get
		{
			return (int)Type.GetField("anzStoneshaper", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzStoneshaper", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int usedUndeadAllies
	{
		get
		{
			return (int)Type.GetField("usedUndeadAllies", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("usedUndeadAllies", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownAbilityFreezesTarget
	{
		get
		{
			return (int)Type.GetField("ownAbilityFreezesTarget", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownAbilityFreezesTarget", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyAbilityFreezesTarget
	{
		get
		{
			return (int)Type.GetField("enemyAbilityFreezesTarget", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyAbilityFreezesTarget", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownHeroPowerCostLessOnce
	{
		get
		{
			return (int)Type.GetField("ownHeroPowerCostLessOnce", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownHeroPowerCostLessOnce", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyHeroPowerCostLessOnce
	{
		get
		{
			return (int)Type.GetField("enemyHeroPowerCostLessOnce", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyHeroPowerCostLessOnce", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownHeroPowerCostLessTwice
	{
		get
		{
			return (int)Type.GetField("ownHeroPowerCostLessTwice", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownHeroPowerCostLessTwice", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownHeroPowerFixedCost
	{
		get
		{
			return (int)Type.GetField("ownHeroPowerFixedCost", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownHeroPowerFixedCost", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyHeroPowerFixedCost
	{
		get
		{
			return (int)Type.GetField("enemyHeroPowerFixedCost", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyHeroPowerFixedCost", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownDemonCostLessOnce
	{
		get
		{
			return (int)Type.GetField("ownDemonCostLessOnce", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownDemonCostLessOnce", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownHeroPowerExtraDamage
	{
		get
		{
			return (int)Type.GetField("ownHeroPowerExtraDamage", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownHeroPowerExtraDamage", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyHeroPowerExtraDamage
	{
		get
		{
			return (int)Type.GetField("enemyHeroPowerExtraDamage", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyHeroPowerExtraDamage", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownHeroPowerAllowedQuantity
	{
		get
		{
			return (int)Type.GetField("ownHeroPowerAllowedQuantity", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownHeroPowerAllowedQuantity", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyHeroPowerAllowedQuantity
	{
		get
		{
			return (int)Type.GetField("enemyHeroPowerAllowedQuantity", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyHeroPowerAllowedQuantity", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int useNature
	{
		get
		{
			return (int)Type.GetField("useNature", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("useNature", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int blackwaterpirate
	{
		get
		{
			return (int)Type.GetField("blackwaterpirate", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("blackwaterpirate", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int blackwaterpirateStarted
	{
		get
		{
			return (int)Type.GetField("blackwaterpirateStarted", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("blackwaterpirateStarted", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int embracetheshadow
	{
		get
		{
			return (int)Type.GetField("embracetheshadow", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("embracetheshadow", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownHealingEffectsBonus
	{
		get
		{
			return (int)Type.GetField("ownHealingEffectsBonus", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownHealingEffectsBonus", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyHealingEffectsBonus
	{
		get
		{
			return (int)Type.GetField("enemyHealingEffectsBonus", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyHealingEffectsBonus", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownNextHealingDamageEffects
	{
		get
		{
			return (int)Type.GetField("ownNextHealingDamageEffects", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownNextHealingDamageEffects", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyNextHealingDamageEffects
	{
		get
		{
			return (int)Type.GetField("enemyNextHealingDamageEffects", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyNextHealingDamageEffects", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool ownDragonsHaveRush
	{
		get
		{
			return (bool)Type.GetField("ownDragonsHaveRush", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownDragonsHaveRush", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool enemyDragonsHaveRush
	{
		get
		{
			return (bool)Type.GetField("enemyDragonsHaveRush", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyDragonsHaveRush", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownFullHealthDeal15ToEnemy
	{
		get
		{
			return (int)Type.GetField("ownFullHealthDeal15ToEnemy", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownFullHealthDeal15ToEnemy", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyFullHealthDeal15ToEnemy
	{
		get
		{
			return (int)Type.GetField("enemyFullHealthDeal15ToEnemy", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyFullHealthDeal15ToEnemy", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownMograineEndTurnDamage
	{
		get
		{
			return (int)Type.GetField("ownMograineEndTurnDamage", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownMograineEndTurnDamage", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyMograineEndTurnDamage
	{
		get
		{
			return (int)Type.GetField("enemyMograineEndTurnDamage", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyMograineEndTurnDamage", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool ownOtherClassSpellsCastTwice
	{
		get
		{
			return (bool)Type.GetField("ownOtherClassSpellsCastTwice", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownOtherClassSpellsCastTwice", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool enemyOtherClassSpellsCastTwice
	{
		get
		{
			return (bool)Type.GetField("enemyOtherClassSpellsCastTwice", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyOtherClassSpellsCastTwice", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownNextSpellsCastTwice
	{
		get
		{
			return (int)Type.GetField("ownNextSpellsCastTwice", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownNextSpellsCastTwice", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyNextSpellsCastTwice
	{
		get
		{
			return (int)Type.GetField("enemyNextSpellsCastTwice", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyNextSpellsCastTwice", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownBeastsDealDoubleDamage
	{
		get
		{
			return (int)Type.GetField("ownBeastsDealDoubleDamage", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownBeastsDealDoubleDamage", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyBeastsDealDoubleDamage
	{
		get
		{
			return (int)Type.GetField("enemyBeastsDealDoubleDamage", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyBeastsDealDoubleDamage", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownDivineShieldsNeedThreeHits
	{
		get
		{
			return (int)Type.GetField("ownDivineShieldsNeedThreeHits", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownDivineShieldsNeedThreeHits", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyDivineShieldsNeedThreeHits
	{
		get
		{
			return (int)Type.GetField("enemyDivineShieldsNeedThreeHits", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyDivineShieldsNeedThreeHits", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownCrystalCore
	{
		get
		{
			return (int)Type.GetField("ownCrystalCore", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownCrystalCore", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownInfested
	{
		get
		{
			return (int)Type.GetField("ownInfested", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownInfested", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool ownMinionsInDeckCost0
	{
		get
		{
			return (bool)Type.GetField("ownMinionsInDeckCost0", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownMinionsInDeckCost0", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool LothraxionsPower
	{
		get
		{
			return (bool)Type.GetField("LothraxionsPower", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("LothraxionsPower", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownMinionsDiedTurn
	{
		get
		{
			return (int)Type.GetField("ownMinionsDiedTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownMinionsDiedTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyMinionsDiedTurn
	{
		get
		{
			return (int)Type.GetField("enemyMinionsDiedTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyMinionsDiedTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool feugenDied
	{
		get
		{
			return (bool)Type.GetField("feugenDied", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("feugenDied", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool stalaggDied
	{
		get
		{
			return (bool)Type.GetField("stalaggDied", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("stalaggDied", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool weHavePlayedMillhouseManastorm
	{
		get
		{
			return (bool)Type.GetField("weHavePlayedMillhouseManastorm", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("weHavePlayedMillhouseManastorm", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool ownGadgetzanSniper
	{
		get
		{
			return (bool)Type.GetField("ownGadgetzanSniper", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownGadgetzanSniper", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool enemyGadgetzanSniper
	{
		get
		{
			return (bool)Type.GetField("enemyGadgetzanSniper", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyGadgetzanSniper", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool ownSpiritclaws
	{
		get
		{
			return (bool)Type.GetField("ownSpiritclaws", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownSpiritclaws", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool enemySpiritclaws
	{
		get
		{
			return (bool)Type.GetField("enemySpiritclaws", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemySpiritclaws", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool needGraveyard
	{
		get
		{
			return (bool)Type.GetField("needGraveyard", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("needGraveyard", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int doublepriest
	{
		get
		{
			return (int)Type.GetField("doublepriest", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("doublepriest", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownFriendlyAttacksThisGame
	{
		get
		{
			return (int)Type.GetField("ownFriendlyAttacksThisGame", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownFriendlyAttacksThisGame", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyFriendlyAttacksThisGame
	{
		get
		{
			return (int)Type.GetField("enemyFriendlyAttacksThisGame", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyFriendlyAttacksThisGame", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public cardIDEnum ownLastDraeneiCardId
	{
		get
		{
			return ReflectionHelper.ConvertValue<cardIDEnum>(Type.GetField("ownLastDraeneiCardId", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst));
		}
		set
		{
			Type.GetField("ownLastDraeneiCardId", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public cardIDEnum enemyLastDraeneiCardId
	{
		get
		{
			return ReflectionHelper.ConvertValue<cardIDEnum>(Type.GetField("enemyLastDraeneiCardId", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst));
		}
		set
		{
			Type.GetField("enemyLastDraeneiCardId", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public cardIDEnum ownLastPlayedMinionCardId
	{
		get
		{
			return ReflectionHelper.ConvertValue<cardIDEnum>(Type.GetField("ownLastPlayedMinionCardId", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst));
		}
		set
		{
			Type.GetField("ownLastPlayedMinionCardId", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public cardIDEnum enemyLastPlayedMinionCardId
	{
		get
		{
			return ReflectionHelper.ConvertValue<cardIDEnum>(Type.GetField("enemyLastPlayedMinionCardId", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst));
		}
		set
		{
			Type.GetField("enemyLastPlayedMinionCardId", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownNonDeckCardsPlayedThisGame
	{
		get
		{
			return (int)Type.GetField("ownNonDeckCardsPlayedThisGame", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownNonDeckCardsPlayedThisGame", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownCardsNotInDeckCostReduction
	{
		get
		{
			return (int)Type.GetField("ownCardsNotInDeckCostReduction", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownCardsNotInDeckCostReduction", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownCardsShuffledIntoDeckThisGame
	{
		get
		{
			return (int)Type.GetField("ownCardsShuffledIntoDeckThisGame", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownCardsShuffledIntoDeckThisGame", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownCardsDiscoveredThisTurn
	{
		get
		{
			return (int)Type.GetField("ownCardsDiscoveredThisTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownCardsDiscoveredThisTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownNextTemporaryCardCostReduction
	{
		get
		{
			return (int)Type.GetField("ownNextTemporaryCardCostReduction", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownNextTemporaryCardCostReduction", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownNextOutcastCardCostReduction
	{
		get
		{
			return (int)Type.GetField("ownNextOutcastCardCostReduction", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownNextOutcastCardCostReduction", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownNextComboCardCostReduction
	{
		get
		{
			return (int)Type.GetField("ownNextComboCardCostReduction", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownNextComboCardCostReduction", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownNextSpellCostReduction
	{
		get
		{
			return (int)Type.GetField("ownNextSpellCostReduction", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownNextSpellCostReduction", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownNextRafaamCostReduction
	{
		get
		{
			return (int)Type.GetField("ownNextRafaamCostReduction", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownNextRafaamCostReduction", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyNextRafaamCostReduction
	{
		get
		{
			return (int)Type.GetField("enemyNextRafaamCostReduction", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyNextRafaamCostReduction", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownNextSpellHandSpellDamageBonus
	{
		get
		{
			return (int)Type.GetField("ownNextSpellHandSpellDamageBonus", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownNextSpellHandSpellDamageBonus", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool ownMinionsCostFiveThisGame
	{
		get
		{
			return (bool)Type.GetField("ownMinionsCostFiveThisGame", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownMinionsCostFiveThisGame", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool ownCardsCostOneThisGame
	{
		get
		{
			return (bool)Type.GetField("ownCardsCostOneThisGame", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownCardsCostOneThisGame", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool enemyCardsCostOneThisGame
	{
		get
		{
			return (bool)Type.GetField("enemyCardsCostOneThisGame", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyCardsCostOneThisGame", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownMoonCycleTurnsRemaining
	{
		get
		{
			return (int)Type.GetField("ownMoonCycleTurnsRemaining", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownMoonCycleTurnsRemaining", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyMoonCycleTurnsRemaining
	{
		get
		{
			return (int)Type.GetField("enemyMoonCycleTurnsRemaining", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyMoonCycleTurnsRemaining", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool ownBarrenDiscoverDraw
	{
		get
		{
			return (bool)Type.GetField("ownBarrenDiscoverDraw", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownBarrenDiscoverDraw", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool enemyBarrenDiscoverDraw
	{
		get
		{
			return (bool)Type.GetField("enemyBarrenDiscoverDraw", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyBarrenDiscoverDraw", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownDiscardedCardsThisGame
	{
		get
		{
			return (int)Type.GetField("ownDiscardedCardsThisGame", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownDiscardedCardsThisGame", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyDiscardedCardsThisGame
	{
		get
		{
			return (int)Type.GetField("enemyDiscardedCardsThisGame", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyDiscardedCardsThisGame", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool ownSpellDamageDealtThisTurn
	{
		get
		{
			return (bool)Type.GetField("ownSpellDamageDealtThisTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownSpellDamageDealtThisTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool enemySpellDamageDealtThisTurn
	{
		get
		{
			return (bool)Type.GetField("enemySpellDamageDealtThisTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemySpellDamageDealtThisTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object currentDiscardBatch
	{
		get
		{
			return Type.GetField("currentDiscardBatch", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("currentDiscardBatch", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyMinionsCostMoreNextTurn
	{
		get
		{
			return (int)Type.GetField("enemyMinionsCostMoreNextTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyMinionsCostMoreNextTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool ownReachEquilibriumActive
	{
		get
		{
			return (bool)Type.GetField("ownReachEquilibriumActive", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownReachEquilibriumActive", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool ownReachEquilibriumHolyActive
	{
		get
		{
			return (bool)Type.GetField("ownReachEquilibriumHolyActive", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownReachEquilibriumHolyActive", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool ownReachEquilibriumShadowActive
	{
		get
		{
			return (bool)Type.GetField("ownReachEquilibriumShadowActive", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownReachEquilibriumShadowActive", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownReachEquilibriumHolyProgress
	{
		get
		{
			return (int)Type.GetField("ownReachEquilibriumHolyProgress", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownReachEquilibriumHolyProgress", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownReachEquilibriumShadowProgress
	{
		get
		{
			return (int)Type.GetField("ownReachEquilibriumShadowProgress", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownReachEquilibriumShadowProgress", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object ownHolySpellsCastThisTurn
	{
		get
		{
			return Type.GetField("ownHolySpellsCastThisTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownHolySpellsCastThisTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownGrazingStegodonDeckAttackBonus
	{
		get
		{
			return (int)Type.GetField("ownGrazingStegodonDeckAttackBonus", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownGrazingStegodonDeckAttackBonus", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownDeckBeastAttackBonus
	{
		get
		{
			return (int)Type.GetField("ownDeckBeastAttackBonus", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownDeckBeastAttackBonus", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownDeckBeastHealthBonus
	{
		get
		{
			return (int)Type.GetField("ownDeckBeastHealthBonus", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownDeckBeastHealthBonus", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool ownDeckMinionStatsDoubled
	{
		get
		{
			return (bool)Type.GetField("ownDeckMinionStatsDoubled", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownDeckMinionStatsDoubled", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object ownDeckSpecificDoubledMinionCopies
	{
		get
		{
			return Type.GetField("ownDeckSpecificDoubledMinionCopies", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownDeckSpecificDoubledMinionCopies", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownStoryOfLakkariTurnsRemaining
	{
		get
		{
			return (int)Type.GetField("ownStoryOfLakkariTurnsRemaining", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownStoryOfLakkariTurnsRemaining", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool ownNinjasShuffleIntoDeckOnDeath
	{
		get
		{
			return (bool)Type.GetField("ownNinjasShuffleIntoDeckOnDeath", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownNinjasShuffleIntoDeckOnDeath", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownQuestLastFullBoardTurn
	{
		get
		{
			return (int)Type.GetField("ownQuestLastFullBoardTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownQuestLastFullBoardTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownFutureMinionsAdaptTimes
	{
		get
		{
			return (int)Type.GetField("ownFutureMinionsAdaptTimes", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownFutureMinionsAdaptTimes", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object ownPendingHatchingCeremonyTurnCounts
	{
		get
		{
			return Type.GetField("ownPendingHatchingCeremonyTurnCounts", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownPendingHatchingCeremonyTurnCounts", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object enemyPendingHatchingCeremonyTurnCounts
	{
		get
		{
			return Type.GetField("enemyPendingHatchingCeremonyTurnCounts", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyPendingHatchingCeremonyTurnCounts", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object ownPendingFracturedPowerTurnCounts
	{
		get
		{
			return Type.GetField("ownPendingFracturedPowerTurnCounts", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownPendingFracturedPowerTurnCounts", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object enemyPendingFracturedPowerTurnCounts
	{
		get
		{
			return Type.GetField("enemyPendingFracturedPowerTurnCounts", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyPendingFracturedPowerTurnCounts", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownElementalDamageBonus
	{
		get
		{
			return (int)Type.GetField("ownElementalDamageBonus", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownElementalDamageBonus", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyElementalDamageBonus
	{
		get
		{
			return (int)Type.GetField("enemyElementalDamageBonus", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyElementalDamageBonus", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemydoublepriest
	{
		get
		{
			return (int)Type.GetField("enemydoublepriest", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemydoublepriest", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownMistcaller
	{
		get
		{
			return (int)Type.GetField("ownMistcaller", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownMistcaller", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int lockandload
	{
		get
		{
			return (int)Type.GetField("lockandload", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("lockandload", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int stampede
	{
		get
		{
			return (int)Type.GetField("stampede", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("stampede", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownBaronRivendare
	{
		get
		{
			return (int)Type.GetField("ownBaronRivendare", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownBaronRivendare", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyBaronRivendare
	{
		get
		{
			return (int)Type.GetField("enemyBaronRivendare", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyBaronRivendare", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownAbilityExtraTriggers
	{
		get
		{
			return (int)Type.GetField("ownAbilityExtraTriggers", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownAbilityExtraTriggers", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownImbueCount
	{
		get
		{
			return (int)Type.GetField("ownImbueCount", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownImbueCount", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyImbueCount
	{
		get
		{
			return (int)Type.GetField("enemyImbueCount", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyImbueCount", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool ownImbuePassiveUsedThisTurn
	{
		get
		{
			return (bool)Type.GetField("ownImbuePassiveUsedThisTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownImbuePassiveUsedThisTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool ownHamuulActive
	{
		get
		{
			return (bool)Type.GetField("ownHamuulActive", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownHamuulActive", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownHamuulSpellProgress
	{
		get
		{
			return (int)Type.GetField("ownHamuulSpellProgress", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownHamuulSpellProgress", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownBrannBronzebeard
	{
		get
		{
			return (int)Type.GetField("ownBrannBronzebeard", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownBrannBronzebeard", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyBrannBronzebeard
	{
		get
		{
			return (int)Type.GetField("enemyBrannBronzebeard", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyBrannBronzebeard", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownTurnEndEffectsTriggerTwice
	{
		get
		{
			return (int)Type.GetField("ownTurnEndEffectsTriggerTwice", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownTurnEndEffectsTriggerTwice", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyTurnEndEffectsTriggerTwice
	{
		get
		{
			return (int)Type.GetField("enemyTurnEndEffectsTriggerTwice", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyTurnEndEffectsTriggerTwice", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownSandfuryAuraTurns1
	{
		get
		{
			return (int)Type.GetField("ownSandfuryAuraTurns1", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownSandfuryAuraTurns1", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownSandfuryAuraTurns2
	{
		get
		{
			return (int)Type.GetField("ownSandfuryAuraTurns2", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownSandfuryAuraTurns2", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownSandfuryAuraTurns3
	{
		get
		{
			return (int)Type.GetField("ownSandfuryAuraTurns3", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownSandfuryAuraTurns3", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemySandfuryAuraTurns1
	{
		get
		{
			return (int)Type.GetField("enemySandfuryAuraTurns1", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemySandfuryAuraTurns1", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemySandfuryAuraTurns2
	{
		get
		{
			return (int)Type.GetField("enemySandfuryAuraTurns2", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemySandfuryAuraTurns2", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemySandfuryAuraTurns3
	{
		get
		{
			return (int)Type.GetField("enemySandfuryAuraTurns3", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemySandfuryAuraTurns3", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownFandralStaghelm
	{
		get
		{
			return (int)Type.GetField("ownFandralStaghelm", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownFandralStaghelm", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int tempanzOwnCards
	{
		get
		{
			return (int)Type.GetField("tempanzOwnCards", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("tempanzOwnCards", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int tempanzEnemyCards
	{
		get
		{
			return (int)Type.GetField("tempanzEnemyCards", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("tempanzEnemyCards", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool isOwnTurn
	{
		get
		{
			return (bool)Type.GetField("isOwnTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("isOwnTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int turnCounter
	{
		get
		{
			return (int)Type.GetField("turnCounter", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("turnCounter", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool attacked
	{
		get
		{
			return (bool)Type.GetField("attacked", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("attacked", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int attackFaceHP
	{
		get
		{
			return (int)Type.GetField("attackFaceHP", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("attackFaceHP", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownController
	{
		get
		{
			return (int)Type.GetField("ownController", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownController", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int evaluatePenality
	{
		get
		{
			return (int)Type.GetField("evaluatePenality", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("evaluatePenality", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ruleWeight
	{
		get
		{
			return (int)Type.GetField("ruleWeight", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ruleWeight", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public string rulesUsed
	{
		get
		{
			return (string)Type.GetField("rulesUsed", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("rulesUsed", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
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

	public bool print
	{
		get
		{
			return (bool)Type.GetField("print", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("print", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public long hashcode
	{
		get
		{
			return (long)Type.GetField("hashcode", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("hashcode", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public float value
	{
		get
		{
			return (float)Type.GetField("value", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("value", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int guessingHeroHP
	{
		get
		{
			return (int)Type.GetField("guessingHeroHP", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("guessingHeroHP", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public float doDirtyTts
	{
		get
		{
			return (float)Type.GetField("doDirtyTts", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("doDirtyTts", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int mana
	{
		get
		{
			return (int)Type.GetField("mana", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("mana", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int manaTurnEnd
	{
		get
		{
			return (int)Type.GetField("manaTurnEnd", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("manaTurnEnd", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemySecretCount
	{
		get
		{
			return (int)Type.GetField("enemySecretCount", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemySecretCount", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object ownHero
	{
		get
		{
			return Type.GetField("ownHero", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownHero", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object enemyHero
	{
		get
		{
			return Type.GetField("enemyHero", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyHero", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public HeroEnum ownHeroName
	{
		get
		{
			return ReflectionHelper.ConvertValue<HeroEnum>(Type.GetField("ownHeroName", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst));
		}
		set
		{
			Type.GetField("ownHeroName", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public HeroEnum enemyHeroName
	{
		get
		{
			return ReflectionHelper.ConvertValue<HeroEnum>(Type.GetField("enemyHeroName", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst));
		}
		set
		{
			Type.GetField("enemyHeroName", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public TAG_CLASS ownHeroStartClass
	{
		get
		{
			return ReflectionHelper.ConvertValue<TAG_CLASS>(Type.GetField("ownHeroStartClass", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst));
		}
		set
		{
			Type.GetField("ownHeroStartClass", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public TAG_CLASS enemyHeroStartClass
	{
		get
		{
			return ReflectionHelper.ConvertValue<TAG_CLASS>(Type.GetField("enemyHeroStartClass", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst));
		}
		set
		{
			Type.GetField("enemyHeroStartClass", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object ownWeapon
	{
		get
		{
			return Type.GetField("ownWeapon", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownWeapon", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object enemyWeapon
	{
		get
		{
			return Type.GetField("enemyWeapon", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyWeapon", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object ownQuest
	{
		get
		{
			return Type.GetField("ownQuest", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownQuest", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object enemyQuest
	{
		get
		{
			return Type.GetField("enemyQuest", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyQuest", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object sideQuest
	{
		get
		{
			return Type.GetField("sideQuest", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("sideQuest", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int owncarddraw
	{
		get
		{
			return (int)Type.GetField("owncarddraw", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("owncarddraw", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemycarddraw
	{
		get
		{
			return (int)Type.GetField("enemycarddraw", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemycarddraw", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyAnzCards
	{
		get
		{
			return (int)Type.GetField("enemyAnzCards", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyAnzCards", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int libram
	{
		get
		{
			return (int)Type.GetField("libram", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("libram", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int protoss
	{
		get
		{
			return (int)Type.GetField("protoss", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("protoss", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int spellpower
	{
		get
		{
			return (int)Type.GetField("spellpower", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("spellpower", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int spellpowerStarted
	{
		get
		{
			return (int)Type.GetField("spellpowerStarted", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("spellpowerStarted", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyspellpower
	{
		get
		{
			return (int)Type.GetField("enemyspellpower", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyspellpower", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyspellpowerStarted
	{
		get
		{
			return (int)Type.GetField("enemyspellpowerStarted", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyspellpowerStarted", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int wehaveCounterspell
	{
		get
		{
			return (int)Type.GetField("wehaveCounterspell", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("wehaveCounterspell", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int lethlMissing
	{
		get
		{
			return (int)Type.GetField("lethlMissing", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("lethlMissing", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool nextSecretThisTurnCost0
	{
		get
		{
			return (bool)Type.GetField("nextSecretThisTurnCost0", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("nextSecretThisTurnCost0", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool playedPreparation
	{
		get
		{
			return (bool)Type.GetField("playedPreparation", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("playedPreparation", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool nextSpellThisTurnCost0
	{
		get
		{
			return (bool)Type.GetField("nextSpellThisTurnCost0", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("nextSpellThisTurnCost0", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool nextMurlocThisTurnCostHealth
	{
		get
		{
			return (bool)Type.GetField("nextMurlocThisTurnCostHealth", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("nextMurlocThisTurnCostHealth", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int nextMurlocReduction
	{
		get
		{
			return (int)Type.GetField("nextMurlocReduction", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("nextMurlocReduction", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool nextMurlocGetsDivineShield
	{
		get
		{
			return (bool)Type.GetField("nextMurlocGetsDivineShield", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("nextMurlocGetsDivineShield", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool nextSpellThisTurnCostHealth
	{
		get
		{
			return (bool)Type.GetField("nextSpellThisTurnCostHealth", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("nextSpellThisTurnCostHealth", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int winzigebeschwoererin
	{
		get
		{
			return (int)Type.GetField("winzigebeschwoererin", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("winzigebeschwoererin", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int startedWithWinzigebeschwoererin
	{
		get
		{
			return (int)Type.GetField("startedWithWinzigebeschwoererin", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("startedWithWinzigebeschwoererin", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int winRazormaneBattleguard
	{
		get
		{
			return (int)Type.GetField("winRazormaneBattleguard", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("winRazormaneBattleguard", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int startedRazormaneBattleguard
	{
		get
		{
			return (int)Type.GetField("startedRazormaneBattleguard", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("startedRazormaneBattleguard", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int managespenst
	{
		get
		{
			return (int)Type.GetField("managespenst", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("managespenst", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int startedWithManagespenst
	{
		get
		{
			return (int)Type.GetField("startedWithManagespenst", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("startedWithManagespenst", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownMinionsCostMore
	{
		get
		{
			return (int)Type.GetField("ownMinionsCostMore", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownMinionsCostMore", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownMinionsCostMoreAtStart
	{
		get
		{
			return (int)Type.GetField("ownMinionsCostMoreAtStart", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownMinionsCostMoreAtStart", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownSpelsCostMore
	{
		get
		{
			return (int)Type.GetField("ownSpelsCostMore", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownSpelsCostMore", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownSpelsCostMoreAtStart
	{
		get
		{
			return (int)Type.GetField("ownSpelsCostMoreAtStart", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownSpelsCostMoreAtStart", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownDRcardsCostMore
	{
		get
		{
			return (int)Type.GetField("ownDRcardsCostMore", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownDRcardsCostMore", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownDRcardsCostMoreAtStart
	{
		get
		{
			return (int)Type.GetField("ownDRcardsCostMoreAtStart", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownDRcardsCostMoreAtStart", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int beschwoerungsportal
	{
		get
		{
			return (int)Type.GetField("beschwoerungsportal", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("beschwoerungsportal", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int startedWithbeschwoerungsportal
	{
		get
		{
			return (int)Type.GetField("startedWithbeschwoerungsportal", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("startedWithbeschwoerungsportal", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int myCardsCostLess
	{
		get
		{
			return (int)Type.GetField("myCardsCostLess", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("myCardsCostLess", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int startedWithmyCardsCostLess
	{
		get
		{
			return (int)Type.GetField("startedWithmyCardsCostLess", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("startedWithmyCardsCostLess", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzOwnAviana
	{
		get
		{
			return (int)Type.GetField("anzOwnAviana", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzOwnAviana", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzNagaSeaWitch
	{
		get
		{
			return (int)Type.GetField("anzNagaSeaWitch", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzNagaSeaWitch", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzOwnScargil
	{
		get
		{
			return (int)Type.GetField("anzOwnScargil", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzOwnScargil", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzMysteriousHuntress
	{
		get
		{
			return (int)Type.GetField("anzMysteriousHuntress", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzMysteriousHuntress", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzOwnRazorfenRockstar
	{
		get
		{
			return (int)Type.GetField("anzOwnRazorfenRockstar", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzOwnRazorfenRockstar", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzOwnXB931Housekeeper
	{
		get
		{
			return (int)Type.GetField("anzOwnXB931Housekeeper", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzOwnXB931Housekeeper", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzOwnPopGarThePutrid
	{
		get
		{
			return (int)Type.GetField("anzOwnPopGarThePutrid", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzOwnPopGarThePutrid", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzEnemyPopGarThePutrid
	{
		get
		{
			return (int)Type.GetField("anzEnemyPopGarThePutrid", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzEnemyPopGarThePutrid", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzNerubarWeblord
	{
		get
		{
			return (int)Type.GetField("anzNerubarWeblord", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzNerubarWeblord", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int startedWithnerubarweblord
	{
		get
		{
			return (int)Type.GetField("startedWithnerubarweblord", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("startedWithnerubarweblord", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool startedWithDamagedMinions
	{
		get
		{
			return (bool)Type.GetField("startedWithDamagedMinions", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("startedWithDamagedMinions", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownWeaponAttackStarted
	{
		get
		{
			return (int)Type.GetField("ownWeaponAttackStarted", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownWeaponAttackStarted", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownMobsCountStarted
	{
		get
		{
			return (int)Type.GetField("ownMobsCountStarted", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownMobsCountStarted", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownCardsCountStarted
	{
		get
		{
			return (int)Type.GetField("ownCardsCountStarted", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownCardsCountStarted", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyMobsCountStarted
	{
		get
		{
			return (int)Type.GetField("enemyMobsCountStarted", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyMobsCountStarted", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyCardsCountStarted
	{
		get
		{
			return (int)Type.GetField("enemyCardsCountStarted", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyCardsCountStarted", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownHeroHpStarted
	{
		get
		{
			return (int)Type.GetField("ownHeroHpStarted", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownHeroHpStarted", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyHeroHpStarted
	{
		get
		{
			return (int)Type.GetField("enemyHeroHpStarted", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyHeroHpStarted", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int mobsplayedThisTurn
	{
		get
		{
			return (int)Type.GetField("mobsplayedThisTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("mobsplayedThisTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int startedWithMobsPlayedThisTurn
	{
		get
		{
			return (int)Type.GetField("startedWithMobsPlayedThisTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("startedWithMobsPlayedThisTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int spellsplayedSinceRecalc
	{
		get
		{
			return (int)Type.GetField("spellsplayedSinceRecalc", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("spellsplayedSinceRecalc", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int secretsplayedSinceRecalc
	{
		get
		{
			return (int)Type.GetField("secretsplayedSinceRecalc", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("secretsplayedSinceRecalc", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int optionsPlayedThisTurn
	{
		get
		{
			return (int)Type.GetField("optionsPlayedThisTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("optionsPlayedThisTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int cardsPlayedThisTurn
	{
		get
		{
			return (int)Type.GetField("cardsPlayedThisTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("cardsPlayedThisTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ueberladung
	{
		get
		{
			return (int)Type.GetField("ueberladung", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ueberladung", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int lockedMana
	{
		get
		{
			return (int)Type.GetField("lockedMana", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("lockedMana", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int corpseGainedThisGame
	{
		get
		{
			return (int)Type.GetField("corpseGainedThisGame", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("corpseGainedThisGame", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int corpseUsedThisGame
	{
		get
		{
			return (int)Type.GetField("corpseUsedThisGame", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("corpseUsedThisGame", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyOptionsDoneThisTurn
	{
		get
		{
			return (int)Type.GetField("enemyOptionsDoneThisTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyOptionsDoneThisTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownMaxMana
	{
		get
		{
			return (int)Type.GetField("ownMaxMana", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownMaxMana", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyMaxMana
	{
		get
		{
			return (int)Type.GetField("enemyMaxMana", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyMaxMana", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool ownPlayedQuestThisGame
	{
		get
		{
			return (bool)Type.GetField("ownPlayedQuestThisGame", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownPlayedQuestThisGame", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool enemyPlayedQuestThisGame
	{
		get
		{
			return (bool)Type.GetField("enemyPlayedQuestThisGame", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyPlayedQuestThisGame", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool ownHeroHealBlockedUntilEnemyTurnStart
	{
		get
		{
			return (bool)Type.GetField("ownHeroHealBlockedUntilEnemyTurnStart", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownHeroHealBlockedUntilEnemyTurnStart", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool enemyHeroHealBlockedUntilOwnTurnStart
	{
		get
		{
			return (bool)Type.GetField("enemyHeroHealBlockedUntilOwnTurnStart", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyHeroHealBlockedUntilOwnTurnStart", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool ownHeroWasHealedThisTurn
	{
		get
		{
			return (bool)Type.GetField("ownHeroWasHealedThisTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownHeroWasHealedThisTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool enemyHeroWasHealedThisTurn
	{
		get
		{
			return (bool)Type.GetField("enemyHeroWasHealedThisTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyHeroWasHealedThisTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool ownDealExactlyTwoMoreActive
	{
		get
		{
			return (bool)Type.GetField("ownDealExactlyTwoMoreActive", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownDealExactlyTwoMoreActive", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool enemyDealExactlyTwoMoreActive
	{
		get
		{
			return (bool)Type.GetField("enemyDealExactlyTwoMoreActive", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyDealExactlyTwoMoreActive", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool resolvingExactTwoDamageBonus
	{
		get
		{
			return (bool)Type.GetField("resolvingExactTwoDamageBonus", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("resolvingExactTwoDamageBonus", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool resolvingOwnSpellDamageWindow
	{
		get
		{
			return (bool)Type.GetField("resolvingOwnSpellDamageWindow", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("resolvingOwnSpellDamageWindow", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool resolvingEnemySpellDamageWindow
	{
		get
		{
			return (bool)Type.GetField("resolvingEnemySpellDamageWindow", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("resolvingEnemySpellDamageWindow", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool spellDealtDamageDuringResolution
	{
		get
		{
			return (bool)Type.GetField("spellDealtDamageDuringResolution", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("spellDealtDamageDuringResolution", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int lostDamage
	{
		get
		{
			return (int)Type.GetField("lostDamage", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("lostDamage", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int lostHeal
	{
		get
		{
			return (int)Type.GetField("lostHeal", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("lostHeal", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int lostWeaponDamage
	{
		get
		{
			return (int)Type.GetField("lostWeaponDamage", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("lostWeaponDamage", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownDeckSize
	{
		get
		{
			return (int)Type.GetField("ownDeckSize", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownDeckSize", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyDeckSize
	{
		get
		{
			return (int)Type.GetField("enemyDeckSize", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyDeckSize", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownHeroFatigue
	{
		get
		{
			return (int)Type.GetField("ownHeroFatigue", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownHeroFatigue", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyHeroFatigue
	{
		get
		{
			return (int)Type.GetField("enemyHeroFatigue", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyHeroFatigue", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool ownAbilityReady
	{
		get
		{
			return (bool)Type.GetField("ownAbilityReady", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownAbilityReady", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object ownHeroAblility
	{
		get
		{
			return Type.GetField("ownHeroAblility", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownHeroAblility", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool enemyAbilityReady
	{
		get
		{
			return (bool)Type.GetField("enemyAbilityReady", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyAbilityReady", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object enemyHeroAblility
	{
		get
		{
			return Type.GetField("enemyHeroAblility", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyHeroAblility", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public cardIDEnum ownStoredHeroPowerCardId
	{
		get
		{
			return ReflectionHelper.ConvertValue<cardIDEnum>(Type.GetField("ownStoredHeroPowerCardId", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst));
		}
		set
		{
			Type.GetField("ownStoredHeroPowerCardId", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownStoryOfSulfurasUsesRemaining
	{
		get
		{
			return (int)Type.GetField("ownStoryOfSulfurasUsesRemaining", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownStoryOfSulfurasUsesRemaining", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object bestEnemyPlay
	{
		get
		{
			return Type.GetField("bestEnemyPlay", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("bestEnemyPlay", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object endTurnState
	{
		get
		{
			return Type.GetField("endTurnState", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("endTurnState", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public cardIDEnum revivingOwnMinion
	{
		get
		{
			return ReflectionHelper.ConvertValue<cardIDEnum>(Type.GetField("revivingOwnMinion", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst));
		}
		set
		{
			Type.GetField("revivingOwnMinion", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public cardIDEnum revivingEnemyMinion
	{
		get
		{
			return ReflectionHelper.ConvertValue<cardIDEnum>(Type.GetField("revivingEnemyMinion", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst));
		}
		set
		{
			Type.GetField("revivingEnemyMinion", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public cardIDEnum OwnLastDiedMinion
	{
		get
		{
			return ReflectionHelper.ConvertValue<cardIDEnum>(Type.GetField("OwnLastDiedMinion", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst));
		}
		set
		{
			Type.GetField("OwnLastDiedMinion", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int shadowmadnessed
	{
		get
		{
			return (int)Type.GetField("shadowmadnessed", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("shadowmadnessed", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyHeroTurnStartedHp
	{
		get
		{
			return (int)Type.GetField("enemyHeroTurnStartedHp", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyHeroTurnStartedHp", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownHeroTurnStartedHp
	{
		get
		{
			return (int)Type.GetField("ownHeroTurnStartedHp", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownHeroTurnStartedHp", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object sigilsToTriggerOnOwnTurnStart
	{
		get
		{
			return Type.GetField("sigilsToTriggerOnOwnTurnStart", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("sigilsToTriggerOnOwnTurnStart", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object ownSpellSchoolCounts
	{
		get
		{
			return Type.GetField("ownSpellSchoolCounts", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownSpellSchoolCounts", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownElizagoreblade
	{
		get
		{
			return (int)Type.GetField("ownElizagoreblade", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownElizagoreblade", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object cardsToReturnAtEndOfTurn
	{
		get
		{
			return Type.GetField("cardsToReturnAtEndOfTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("cardsToReturnAtEndOfTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownSunscreenTurns
	{
		get
		{
			return (int)Type.GetField("ownSunscreenTurns", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownSunscreenTurns", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemySunscreenTurns
	{
		get
		{
			return (int)Type.GetField("enemySunscreenTurns", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemySunscreenTurns", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownAccelerationAuraTurns
	{
		get
		{
			return (int)Type.GetField("ownAccelerationAuraTurns", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownAccelerationAuraTurns", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyAccelerationAuraTurns
	{
		get
		{
			return (int)Type.GetField("enemyAccelerationAuraTurns", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyAccelerationAuraTurns", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownChronologicalAuraTurns
	{
		get
		{
			return (int)Type.GetField("ownChronologicalAuraTurns", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownChronologicalAuraTurns", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyChronologicalAuraTurns
	{
		get
		{
			return (int)Type.GetField("enemyChronologicalAuraTurns", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyChronologicalAuraTurns", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownGnomishAuraTurns
	{
		get
		{
			return (int)Type.GetField("ownGnomishAuraTurns", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownGnomishAuraTurns", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyGnomishAuraTurns
	{
		get
		{
			return (int)Type.GetField("enemyGnomishAuraTurns", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyGnomishAuraTurns", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownMekkatorqueAuraTurns
	{
		get
		{
			return (int)Type.GetField("ownMekkatorqueAuraTurns", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownMekkatorqueAuraTurns", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyMekkatorqueAuraTurns
	{
		get
		{
			return (int)Type.GetField("enemyMekkatorqueAuraTurns", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyMekkatorqueAuraTurns", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownCraftersAuraTurns
	{
		get
		{
			return (int)Type.GetField("ownCraftersAuraTurns", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownCraftersAuraTurns", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyCraftersAuraTurns
	{
		get
		{
			return (int)Type.GetField("enemyCraftersAuraTurns", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyCraftersAuraTurns", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownCrusaderAuraTurns
	{
		get
		{
			return (int)Type.GetField("ownCrusaderAuraTurns", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownCrusaderAuraTurns", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyCrusaderAuraTurns
	{
		get
		{
			return (int)Type.GetField("enemyCrusaderAuraTurns", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyCrusaderAuraTurns", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownResistanceAuraTurns
	{
		get
		{
			return (int)Type.GetField("ownResistanceAuraTurns", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownResistanceAuraTurns", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyResistanceAuraTurns
	{
		get
		{
			return (int)Type.GetField("enemyResistanceAuraTurns", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyResistanceAuraTurns", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownChronikarAttackTurns
	{
		get
		{
			return (int)Type.GetField("ownChronikarAttackTurns", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownChronikarAttackTurns", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyChronikarAttackTurns
	{
		get
		{
			return (int)Type.GetField("enemyChronikarAttackTurns", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyChronikarAttackTurns", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownDeputizationAuraTurns
	{
		get
		{
			return (int)Type.GetField("ownDeputizationAuraTurns", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownDeputizationAuraTurns", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyDeputizationAuraTurns
	{
		get
		{
			return (int)Type.GetField("enemyDeputizationAuraTurns", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyDeputizationAuraTurns", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownDeputizationAuraTargetEntityId
	{
		get
		{
			return (int)Type.GetField("ownDeputizationAuraTargetEntityId", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownDeputizationAuraTargetEntityId", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyDeputizationAuraTargetEntityId
	{
		get
		{
			return (int)Type.GetField("enemyDeputizationAuraTargetEntityId", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyDeputizationAuraTargetEntityId", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object ownPlayedDeathrattleCards
	{
		get
		{
			return Type.GetField("ownPlayedDeathrattleCards", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownPlayedDeathrattleCards", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object enemyPlayedDeathrattleCards
	{
		get
		{
			return Type.GetField("enemyPlayedDeathrattleCards", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyPlayedDeathrattleCards", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool ownHeroPowerCanBeUsedMultipleTimes
	{
		get
		{
			return (bool)Type.GetField("ownHeroPowerCanBeUsedMultipleTimes", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownHeroPowerCanBeUsedMultipleTimes", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object ownMinionsPlayedThisGame
	{
		get
		{
			return Type.GetField("ownMinionsPlayedThisGame", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownMinionsPlayedThisGame", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int excavationCount
	{
		get
		{
			return (int)Type.GetField("excavationCount", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("excavationCount", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int allExcavationCount
	{
		get
		{
			return (int)Type.GetField("allExcavationCount", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("allExcavationCount", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int nextBattlecryTriggers
	{
		get
		{
			return (int)Type.GetField("nextBattlecryTriggers", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("nextBattlecryTriggers", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int nextKindredTriggers
	{
		get
		{
			return (int)Type.GetField("nextKindredTriggers", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("nextKindredTriggers", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object ownFrostmourneVictims
	{
		get
		{
			return Type.GetField("ownFrostmourneVictims", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownFrostmourneVictims", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object enemyFrostmourneVictims
	{
		get
		{
			return Type.GetField("enemyFrostmourneVictims", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyFrostmourneVictims", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool ownRelicDoubleCast
	{
		get
		{
			return (bool)Type.GetField("ownRelicDoubleCast", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownRelicDoubleCast", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool enemyRelicDoubleCast
	{
		get
		{
			return (bool)Type.GetField("enemyRelicDoubleCast", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyRelicDoubleCast", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownRelicPower
	{
		get
		{
			return (int)Type.GetField("ownRelicPower", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownRelicPower", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyRelicPower
	{
		get
		{
			return (int)Type.GetField("enemyRelicPower", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyRelicPower", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool nextMinionBecomesFiveFive
	{
		get
		{
			return (bool)Type.GetField("nextMinionBecomesFiveFive", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("nextMinionBecomesFiveFive", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int tempSpellPower
	{
		get
		{
			return (int)Type.GetField("tempSpellPower", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("tempSpellPower", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool nextChooseOneHasBothEffects
	{
		get
		{
			return (bool)Type.GetField("nextChooseOneHasBothEffects", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("nextChooseOneHasBothEffects", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int parrotSanctuaryCount
	{
		get
		{
			return (int)Type.GetField("parrotSanctuaryCount", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("parrotSanctuaryCount", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int lastDrawnCardEntityID
	{
		get
		{
			return (int)Type.GetField("lastDrawnCardEntityID", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("lastDrawnCardEntityID", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool ownLegionInvasion
	{
		get
		{
			return (bool)Type.GetField("ownLegionInvasion", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownLegionInvasion", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool enemyLegionInvasion
	{
		get
		{
			return (bool)Type.GetField("enemyLegionInvasion", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyLegionInvasion", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool ownAmitusThePeacekeeper
	{
		get
		{
			return (bool)Type.GetField("ownAmitusThePeacekeeper", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownAmitusThePeacekeeper", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool enemyAmitusThePeacekeeper
	{
		get
		{
			return (bool)Type.GetField("enemyAmitusThePeacekeeper", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyAmitusThePeacekeeper", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool ownBackstabKing
	{
		get
		{
			return (bool)Type.GetField("ownBackstabKing", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownBackstabKing", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool enemyBackstabKing
	{
		get
		{
			return (bool)Type.GetField("enemyBackstabKing", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyBackstabKing", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int damageDealtToEnemyHeroThisTurn
	{
		get
		{
			return (int)Type.GetField("damageDealtToEnemyHeroThisTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("damageDealtToEnemyHeroThisTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int nextElementalReduction
	{
		get
		{
			return (int)Type.GetField("nextElementalReduction", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("nextElementalReduction", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int thisTurnNextElementalReduction
	{
		get
		{
			return (int)Type.GetField("thisTurnNextElementalReduction", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("thisTurnNextElementalReduction", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int lastPlayedCardCost
	{
		get
		{
			return (int)Type.GetField("lastPlayedCardCost", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("lastPlayedCardCost", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool playedElementalThisTurn
	{
		get
		{
			return (bool)Type.GetField("playedElementalThisTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("playedElementalThisTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownElementalsPlayedThisTurn
	{
		get
		{
			return (int)Type.GetField("ownElementalsPlayedThisTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownElementalsPlayedThisTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int tarslick
	{
		get
		{
			return (int)Type.GetField("tarslick", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("tarslick", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool ownSunsapperlynessa
	{
		get
		{
			return (bool)Type.GetField("ownSunsapperlynessa", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownSunsapperlynessa", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object watercolorArtistHand
	{
		get
		{
			return Type.GetField("watercolorArtistHand", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("watercolorArtistHand", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool spellsCost5UntilNextTurn
	{
		get
		{
			return (bool)Type.GetField("spellsCost5UntilNextTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("spellsCost5UntilNextTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int effectEndTurn
	{
		get
		{
			return (int)Type.GetField("effectEndTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("effectEndTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemySpellCostOffsetNextTurn
	{
		get
		{
			return (int)Type.GetField("enemySpellCostOffsetNextTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemySpellCostOffsetNextTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object nextNonRogueClassCardCostReduction
	{
		get
		{
			return Type.GetField("nextNonRogueClassCardCostReduction", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("nextNonRogueClassCardCostReduction", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool ownNextSpellCastWhenDrawn
	{
		get
		{
			return (bool)Type.GetField("ownNextSpellCastWhenDrawn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownNextSpellCastWhenDrawn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool ownHeroHasCleave
	{
		get
		{
			return (bool)Type.GetField("ownHeroHasCleave", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownHeroHasCleave", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool enemyHeroHasCleave
	{
		get
		{
			return (bool)Type.GetField("enemyHeroHasCleave", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyHeroHasCleave", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownMinionsMaxSlots
	{
		get
		{
			return (int)Type.GetField("ownMinionsMaxSlots", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownMinionsMaxSlots", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyMinionsMaxSlots
	{
		get
		{
			return (int)Type.GetField("enemyMinionsMaxSlots", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyMinionsMaxSlots", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int renoEffectEndTurn
	{
		get
		{
			return (int)Type.GetField("renoEffectEndTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("renoEffectEndTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int sigilOfSkydivingTrigger
	{
		get
		{
			return (int)Type.GetField("sigilOfSkydivingTrigger", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("sigilOfSkydivingTrigger", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownSigilOfCinderTrigger
	{
		get
		{
			return (int)Type.GetField("ownSigilOfCinderTrigger", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownSigilOfCinderTrigger", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemySigilOfCinderTrigger
	{
		get
		{
			return (int)Type.GetField("enemySigilOfCinderTrigger", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemySigilOfCinderTrigger", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownSigilOfSeasTrigger
	{
		get
		{
			return (int)Type.GetField("ownSigilOfSeasTrigger", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownSigilOfSeasTrigger", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemySigilOfSeasTrigger
	{
		get
		{
			return (int)Type.GetField("enemySigilOfSeasTrigger", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemySigilOfSeasTrigger", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object enemyFieldOfStrifeDurations
	{
		get
		{
			return Type.GetField("enemyFieldOfStrifeDurations", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyFieldOfStrifeDurations", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object rng
	{
		get
		{
			return Type.GetField("rng", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("rng", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public static object ilog_0
	{
		get
		{
			return Type.GetField("ilog_0", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(null);
		}
		set
		{
			Type.GetField("ilog_0", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetValue(null, value);
		}
	}

	public static object _copyableInstanceFields
	{
		get
		{
			return Type.GetField("_copyableInstanceFields", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(null);
		}
		set
		{
			Type.GetField("_copyableInstanceFields", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetValue(null, value);
		}
	}

	public static object TitanographerOskForms
	{
		get
		{
			return Type.GetField("TitanographerOskForms", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(null);
		}
		set
		{
			Type.GetField("TitanographerOskForms", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetValue(null, value);
		}
	}

	public static object _random
	{
		get
		{
			return Type.GetField("_random", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(null);
		}
		set
		{
			Type.GetField("_random", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetValue(null, value);
		}
	}

	public Playfield(object inst)
	{
		Inst = inst;
	}

	public object getLegendaryTreasure()
	{
		Type[] types = new Type[0];
		return Type.GetMethod("getLegendaryTreasure", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public object getRandomCardFromPool(string quality)
	{
		Type[] types = new Type[1] { typeof(string) };
		return Type.GetMethod("getRandomCardFromPool", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { quality });
	}

	public bool hasLegendaryTreasure()
	{
		Type[] types = new Type[0];
		return (bool)Type.GetMethod("hasLegendaryTreasure", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public void useLocation(object own, object target)
	{
		Type[] types = new Type[2]
		{
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			Type.Assembly.GetType("HREngine.Bots.Minion")
		};
		Type.GetMethod("useLocation", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { own, target });
	}

	public void useStarship(object own, object target)
	{
		Type[] types = new Type[2]
		{
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			Type.Assembly.GetType("HREngine.Bots.Minion")
		};
		Type.GetMethod("useStarship", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { own, target });
	}

	public void useTitanAbility(object own, int titanAbilityNO, object target)
	{
		Type[] types = new Type[3]
		{
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			typeof(int),
			Type.Assembly.GetType("HREngine.Bots.Minion")
		};
		Type.GetMethod("useTitanAbility", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[3] { own, titanAbilityNO, target });
	}

	public void drawTemporaryCard(cardIDEnum ss, bool own)
	{
		Type[] types = new Type[2]
		{
			Type.Assembly.GetType("HREngine.Bots.CardDB+cardIDEnum"),
			typeof(bool)
		};
		Type.GetMethod("drawTemporaryCard", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { ss, own });
	}

	public void removeTemporaryCards(bool own)
	{
		Type[] types = new Type[1] { typeof(bool) };
		Type.GetMethod("removeTemporaryCards", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { own });
	}

	public int CountSpellSchoolsPlayed()
	{
		Type[] types = new Type[0];
		return (int)Type.GetMethod("CountSpellSchoolsPlayed", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public void allMinionsGetRandomDamage(int totalDamage)
	{
		Type[] types = new Type[1] { typeof(int) };
		Type.GetMethod("allMinionsGetRandomDamage", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { totalDamage });
	}

	public bool hasMinionsInDeck()
	{
		Type[] types = new Type[0];
		return (bool)Type.GetMethod("hasMinionsInDeck", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public void RandomEnemyMinionsAttackEachOther()
	{
		Type[] types = new Type[0];
		Type.GetMethod("RandomEnemyMinionsAttackEachOther", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public int getPosition(bool ownplay)
	{
		Type[] types = new Type[1] { typeof(bool) };
		return (int)Type.GetMethod("getPosition", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { ownplay });
	}

	public bool anyRaceCardInHand(Race race)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.CardDB+Race") };
		return (bool)Type.GetMethod("anyRaceCardInHand", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { race });
	}

	public void drawACard(cardIDEnum ss, bool own, bool nopen)
	{
		Type[] types = new Type[3]
		{
			Type.Assembly.GetType("HREngine.Bots.CardDB+cardIDEnum"),
			typeof(bool),
			typeof(bool)
		};
		Type.GetMethod("drawACard", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[3] { ss, own, nopen });
	}

	public bool TrySummonWhenDrawnOwnCard(object card)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.CardDB+Card") };
		return (bool)Type.GetMethod("TrySummonWhenDrawnOwnCard", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { card });
	}

	public bool TryCastWhenDrawnCard(object card, bool ownplay)
	{
		Type[] types = new Type[2]
		{
			Type.Assembly.GetType("HREngine.Bots.CardDB+Card"),
			typeof(bool)
		};
		return (bool)Type.GetMethod("TryCastWhenDrawnCard", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { card, ownplay });
	}

	public void handleShatterDraw(object shatterCard)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.CardDB+Card") };
		Type.GetMethod("handleShatterDraw", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { shatterCard });
	}

	public void checkShatterMerge()
	{
		Type[] types = new Type[0];
		Type.GetMethod("checkShatterMerge", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public void removeCard(object hcc)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Handmanager+Handcard") };
		Type.GetMethod("removeCard", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { hcc });
	}

	public void attackEnemyHeroWithoutKill(int dmg)
	{
		Type[] types = new Type[1] { typeof(int) };
		Type.GetMethod("attackEnemyHeroWithoutKill", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { dmg });
	}

	public void minionGetDestroyed(object m)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Minion") };
		Type.GetMethod("minionGetDestroyed", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { m });
	}

	public void RemoveMinionWithoutDeathrattle(object m)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Minion") };
		Type.GetMethod("RemoveMinionWithoutDeathrattle", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { m });
	}

	public void allMinionsGetDestroyed()
	{
		Type[] types = new Type[0];
		Type.GetMethod("allMinionsGetDestroyed", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public void minionGetArmor(object m, int armor)
	{
		Type[] types = new Type[2]
		{
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			typeof(int)
		};
		Type.GetMethod("minionGetArmor", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { m, armor });
	}

	public void minionReturnToHand(object m, bool own, int manachange)
	{
		Type[] types = new Type[3]
		{
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			typeof(bool),
			typeof(int)
		};
		Type.GetMethod("minionReturnToHand", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[3] { m, own, manachange });
	}

	public void minionReturnToDeck(object m, bool own)
	{
		Type[] types = new Type[2]
		{
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			typeof(bool)
		};
		Type.GetMethod("minionReturnToDeck", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { m, own });
	}

	public void minionTransform(object m, object c)
	{
		Type[] types = new Type[2]
		{
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			Type.Assembly.GetType("HREngine.Bots.CardDB+Card")
		};
		Type.GetMethod("minionTransform", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { m, c });
	}

	public object getRandomCardForManaMinion(int manaCost)
	{
		Type[] types = new Type[1] { typeof(int) };
		return Type.GetMethod("getRandomCardForManaMinion", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { manaCost });
	}

	public object getEnemyCharTargetForRandomSingleDamage(int damage, bool onlyMinions)
	{
		Type[] types = new Type[2]
		{
			typeof(int),
			typeof(bool)
		};
		return Type.GetMethod("getEnemyCharTargetForRandomSingleDamage", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { damage, onlyMinions });
	}

	public object getEnemyCharTargetForRandomSingleDamage1(int damage, bool onlyMinions)
	{
		Type[] types = new Type[2]
		{
			typeof(int),
			typeof(bool)
		};
		return Type.GetMethod("getEnemyCharTargetForRandomSingleDamage1", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { damage, onlyMinions });
	}

	public void minionGetControlled(object m, bool newOwner, bool canAttack, bool forced)
	{
		Type[] types = new Type[4]
		{
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			typeof(bool),
			typeof(bool),
			typeof(bool)
		};
		Type.GetMethod("minionGetControlled", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[4] { m, newOwner, canAttack, forced });
	}

	public void Magnetic(object mOwn)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Minion") };
		Type.GetMethod("Magnetic", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { mOwn });
	}

	public void minionGetWindfurry(object m)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Minion") };
		Type.GetMethod("minionGetWindfurry", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { m });
	}

	public void minionGetCharge(object m)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Minion") };
		Type.GetMethod("minionGetCharge", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { m });
	}

	public void minionGetRush(object m)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Minion") };
		Type.GetMethod("minionGetRush", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { m });
	}

	public void minionLostCharge(object m)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Minion") };
		Type.GetMethod("minionLostCharge", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { m });
	}

	public void minionGetTempBuff(object m, int tempAttack, int tempHp)
	{
		Type[] types = new Type[3]
		{
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			typeof(int),
			typeof(int)
		};
		Type.GetMethod("minionGetTempBuff", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[3] { m, tempAttack, tempHp });
	}

	public void minionGetAdjacentBuff(object m, int angr, int vert)
	{
		Type[] types = new Type[3]
		{
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			typeof(int),
			typeof(int)
		};
		Type.GetMethod("minionGetAdjacentBuff", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[3] { m, angr, vert });
	}

	public void allMinionOfASideGetBuffed(bool own, int attackbuff, int hpbuff)
	{
		Type[] types = new Type[3]
		{
			typeof(bool),
			typeof(int),
			typeof(int)
		};
		Type.GetMethod("allMinionOfASideGetBuffed", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[3] { own, attackbuff, hpbuff });
	}

	public void minionGetBuffed(object m, int attackbuff, int hpbuff)
	{
		Type[] types = new Type[3]
		{
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			typeof(int),
			typeof(int)
		};
		Type.GetMethod("minionGetBuffed", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[3] { m, attackbuff, hpbuff });
	}

	public void cthunGetBuffed(int attackbuff, int hpbuff, int tauntbuff)
	{
		Type[] types = new Type[3]
		{
			typeof(int),
			typeof(int),
			typeof(int)
		};
		Type.GetMethod("cthunGetBuffed", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[3] { attackbuff, hpbuff, tauntbuff });
	}

	public void minionLosesDivineShield(object m)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Minion") };
		Type.GetMethod("minionLosesDivineShield", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { m });
	}

	public void discardCards(int num, bool own)
	{
		Type[] types = new Type[2]
		{
			typeof(int),
			typeof(bool)
		};
		Type.GetMethod("discardCards", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { num, own });
	}

	public int calculateCardValue(object hc, object c)
	{
		Type[] types = new Type[2]
		{
			Type.Assembly.GetType("HREngine.Bots.Handmanager+Handcard"),
			Type.Assembly.GetType("HREngine.Bots.CardDB+Card")
		};
		return (int)Type.GetMethod("calculateCardValue", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { hc, c });
	}

	public int getCardValueRatio(int manaCost)
	{
		Type[] types = new Type[1] { typeof(int) };
		return (int)Type.GetMethod("getCardValueRatio", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { manaCost });
	}

	public void RecordDiscardForTracking(object hc, bool own)
	{
		Type[] types = new Type[2]
		{
			Type.Assembly.GetType("HREngine.Bots.Handmanager+Handcard"),
			typeof(bool)
		};
		Type.GetMethod("RecordDiscardForTracking", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { hc, own });
	}

	public object GetPreferredDiscardCard(bool own)
	{
		Type[] types = new Type[1] { typeof(bool) };
		return Type.GetMethod("GetPreferredDiscardCard", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { own });
	}

	public void DiscardSpecificCard(object hc, bool own)
	{
		Type[] types = new Type[2]
		{
			Type.Assembly.GetType("HREngine.Bots.Handmanager+Handcard"),
			typeof(bool)
		};
		Type.GetMethod("DiscardSpecificCard", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { hc, own });
	}

	public int lethalMissing()
	{
		Type[] types = new Type[0];
		return (int)Type.GetMethod("lethalMissing", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public bool nextTurnWin()
	{
		Type[] types = new Type[0];
		return (bool)Type.GetMethod("nextTurnWin", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public int CalculatePotentialDamage()
	{
		Type[] types = new Type[0];
		return (int)Type.GetMethod("CalculatePotentialDamage", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public int calDirectDmg(int mana, bool force, bool calNextTurn, int maxCal, int calMax)
	{
		Type[] types = new Type[5]
		{
			typeof(int),
			typeof(bool),
			typeof(bool),
			typeof(int),
			typeof(int)
		};
		return (int)Type.GetMethod("calDirectDmg", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[5] { mana, force, calNextTurn, maxCal, calMax });
	}

	public void minionSetAngrToX(object m, int newAngr)
	{
		Type[] types = new Type[2]
		{
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			typeof(int)
		};
		Type.GetMethod("minionSetAngrToX", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { m, newAngr });
	}

	public void minionSetLifetoX(object m, int newHp)
	{
		Type[] types = new Type[2]
		{
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			typeof(int)
		};
		Type.GetMethod("minionSetLifetoX", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { m, newHp });
	}

	public void minionSetAngrToHP(object m)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Minion") };
		Type.GetMethod("minionSetAngrToHP", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { m });
	}

	public void minionSwapAngrAndHP(object m)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Minion") };
		Type.GetMethod("minionSwapAngrAndHP", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { m });
	}

	public void minionGetDamageOrHeal(object m, int dmgOrHeal, bool dontDmgLoss)
	{
		Type[] types = new Type[3]
		{
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			typeof(int),
			typeof(bool)
		};
		Type.GetMethod("minionGetDamageOrHeal", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[3] { m, dmgOrHeal, dontDmgLoss });
	}

	public int ApplyDamageDealtMultipliers(object source, int damage)
	{
		Type[] types = new Type[2]
		{
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			typeof(int)
		};
		return (int)Type.GetMethod("ApplyDamageDealtMultipliers", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { source, damage });
	}

	public void HandleFullHealthHeroTriggers(object target, int actualDelta)
	{
		Type[] types = new Type[2]
		{
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			typeof(int)
		};
		Type.GetMethod("HandleFullHealthHeroTriggers", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { target, actualDelta });
	}

	public void HandleEnemyHealingAndExactTwoDamageTriggers(object target, int actualDelta)
	{
		Type[] types = new Type[2]
		{
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			typeof(int)
		};
		Type.GetMethod("HandleEnemyHealingAndExactTwoDamageTriggers", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { target, actualDelta });
	}

	public void allMinionOfASideGetDamage(bool own, int damages, bool frozen)
	{
		Type[] types = new Type[3]
		{
			typeof(bool),
			typeof(int),
			typeof(bool)
		};
		Type.GetMethod("allMinionOfASideGetDamage", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[3] { own, damages, frozen });
	}

	public void allCharsOfASideGetDamage(bool own, int damages)
	{
		Type[] types = new Type[2]
		{
			typeof(bool),
			typeof(int)
		};
		Type.GetMethod("allCharsOfASideGetDamage", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { own, damages });
	}

	public void allCharsOfASideGetRandomDamage(bool ownSide, int times)
	{
		Type[] types = new Type[2]
		{
			typeof(bool),
			typeof(int)
		};
		Type.GetMethod("allCharsOfASideGetRandomDamage", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { ownSide, times });
	}

	public void minionGetDamageOrHealToHero(bool ownHero, int dmgOrHeal, bool dontDmgLoss)
	{
		Type[] types = new Type[3]
		{
			typeof(bool),
			typeof(int),
			typeof(bool)
		};
		Type.GetMethod("minionGetDamageOrHealToHero", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[3] { ownHero, dmgOrHeal, dontDmgLoss });
	}

	public void allCharsGetDamage(int damages, int exceptID)
	{
		Type[] types = new Type[2]
		{
			typeof(int),
			typeof(int)
		};
		Type.GetMethod("allCharsGetDamage", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { damages, exceptID });
	}

	public void allMinionsGetDamage(int damages, int exceptID)
	{
		Type[] types = new Type[2]
		{
			typeof(int),
			typeof(int)
		};
		Type.GetMethod("allMinionsGetDamage", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { damages, exceptID });
	}

	public void DealDamageToRandomCharacter(bool isEnemy, int damage)
	{
		Type[] types = new Type[2]
		{
			typeof(bool),
			typeof(int)
		};
		Type.GetMethod("DealDamageToRandomCharacter", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { isEnemy, damage });
	}

	public void setNewHeroPower(cardIDEnum newHeroPower, bool own)
	{
		Type[] types = new Type[2]
		{
			Type.Assembly.GetType("HREngine.Bots.CardDB+cardIDEnum"),
			typeof(bool)
		};
		Type.GetMethod("setNewHeroPower", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { newHeroPower, own });
	}

	public void imbueHeroPower(bool own)
	{
		Type[] types = new Type[1] { typeof(bool) };
		Type.GetMethod("imbueHeroPower", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { own });
	}

	public cardIDEnum getBlessingCardId(HeroEnum hero)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.HeroEnum") };
		return ReflectionHelper.ConvertValue<cardIDEnum>(Type.GetMethod("getBlessingCardId", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { hero }));
	}

	public void ActivateStoryOfSulfuras()
	{
		Type[] types = new Type[0];
		Type.GetMethod("ActivateStoryOfSulfuras", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public void ConsumeStoryOfSulfurasUse()
	{
		Type[] types = new Type[0];
		Type.GetMethod("ConsumeStoryOfSulfurasUse", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public int getImbueValue(bool own)
	{
		Type[] types = new Type[1] { typeof(bool) };
		return (int)Type.GetMethod("getImbueValue", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { own });
	}

	public int calTotalAngr()
	{
		Type[] types = new Type[0];
		return (int)Type.GetMethod("calTotalAngr", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public int calEnemyTotalAngr()
	{
		Type[] types = new Type[0];
		return (int)Type.GetMethod("calEnemyTotalAngr", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public object getNextJadeGolem(bool own)
	{
		Type[] types = new Type[1] { typeof(bool) };
		return Type.GetMethod("getNextJadeGolem", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { own });
	}

	public void debugMinions()
	{
		Type[] types = new Type[0];
		Type.GetMethod("debugMinions", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public void printBoard()
	{
		Type[] types = new Type[0];
		Type.GetMethod("printBoard", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public string printBoardString()
	{
		Type[] types = new Type[0];
		return (string)Type.GetMethod("printBoardString", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public void printBoardDebug()
	{
		Type[] types = new Type[0];
		Type.GetMethod("printBoardDebug", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public object getNextAction()
	{
		Type[] types = new Type[0];
		return Type.GetMethod("getNextAction", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public cardIDEnum CheckTurnDeckExists(TAG_RACE race)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.TAG_RACE") };
		return ReflectionHelper.ConvertValue<cardIDEnum>(Type.GetMethod("CheckTurnDeckExists", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { race }));
	}

	public object CheckTurnDeckForType(cardtype type, int num)
	{
		Type[] types = new Type[2]
		{
			Type.Assembly.GetType("HREngine.Bots.CardDB+cardtype"),
			typeof(int)
		};
		return Type.GetMethod("CheckTurnDeckForType", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { type, num });
	}

	public void printActions(bool toBuffer)
	{
		Type[] types = new Type[1] { typeof(bool) };
		Type.GetMethod("printActions", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { toBuffer });
	}

	public void printActionforDummies(object a)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Action") };
		Type.GetMethod("printActionforDummies", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { a });
	}

	public int getRandomNumber(int minValue, int maxValue)
	{
		Type[] types = new Type[2]
		{
			typeof(int),
			typeof(int)
		};
		return (int)Type.GetMethod("getRandomNumber", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { minValue, maxValue });
	}

	public object handleExcavation()
	{
		Type[] types = new Type[0];
		return Type.GetMethod("handleExcavation", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public object getTreasurePool(string quality)
	{
		Type[] types = new Type[1] { typeof(string) };
		return Type.GetMethod("getTreasurePool", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { quality });
	}

	public void ApplyNiriMinionBuff(object hc)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Handmanager+Handcard") };
		Type.GetMethod("ApplyNiriMinionBuff", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { hc });
	}

	public void RepeatOneCostSpellForNiri(object hc, object target, int choice)
	{
		Type[] types = new Type[3]
		{
			Type.Assembly.GetType("HREngine.Bots.Handmanager+Handcard"),
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			typeof(int)
		};
		Type.GetMethod("RepeatOneCostSpellForNiri", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[3] { hc, target, choice });
	}

	public void HandleOutcastEffect(object hc, bool outcast)
	{
		Type[] types = new Type[2]
		{
			Type.Assembly.GetType("HREngine.Bots.Handmanager+Handcard"),
			typeof(bool)
		};
		Type.GetMethod("HandleOutcastEffect", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { hc, outcast });
	}

	public void HandleSpellburstEffect(object hc)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Handmanager+Handcard") };
		Type.GetMethod("HandleSpellburstEffect", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { hc });
	}

	public void HandleCounterspellOrSpellbender(object c, object target)
	{
		Type[] types = new Type[2]
		{
			Type.Assembly.GetType("HREngine.Bots.CardDB+Card"),
			Type.Assembly.GetType("HREngine.Bots.Minion")
		};
		Type.GetMethod("HandleCounterspellOrSpellbender", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { c, target });
	}

	public void ApplyBuffEffect(object hc)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Handmanager+Handcard") };
		Type.GetMethod("ApplyBuffEffect", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { hc });
	}

	public void EnemyplaysACard(object c, object target, int position, int choice, int penality)
	{
		Type[] types = new Type[5]
		{
			Type.Assembly.GetType("HREngine.Bots.CardDB+Card"),
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			typeof(int),
			typeof(int),
			typeof(int)
		};
		Type.GetMethod("EnemyplaysACard", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[5] { c, target, position, choice, penality });
	}

	public object EnemyUpdateTargetBasedOnSecret(int newTarget, object target)
	{
		Type[] types = new Type[2]
		{
			typeof(int),
			Type.Assembly.GetType("HREngine.Bots.Minion")
		};
		return Type.GetMethod("EnemyUpdateTargetBasedOnSecret", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { newTarget, target });
	}

	public void EnemyHandleEnemyMinionPlay(object hc, object target, int position, int choice)
	{
		Type[] types = new Type[4]
		{
			Type.Assembly.GetType("HREngine.Bots.Handmanager+Handcard"),
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			typeof(int),
			typeof(int)
		};
		Type.GetMethod("EnemyHandleEnemyMinionPlay", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[4] { hc, target, position, choice });
	}

	public void PlayHeroPower(object target, int penality, bool ownturn, int choice)
	{
		Type[] types = new Type[4]
		{
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			typeof(int),
			typeof(bool),
			typeof(int)
		};
		Type.GetMethod("PlayHeroPower", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[4] { target, penality, ownturn, choice });
	}

	public void lowerWeaponDurability(int value, bool own)
	{
		Type[] types = new Type[2]
		{
			typeof(int),
			typeof(bool)
		};
		Type.GetMethod("lowerWeaponDurability", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { value, own });
	}

	public void HandleWeaponBreak(object weapon, bool own)
	{
		Type[] types = new Type[2]
		{
			Type.Assembly.GetType("HREngine.Bots.Weapon"),
			typeof(bool)
		};
		Type.GetMethod("HandleWeaponBreak", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { weapon, own });
	}

	public void doDmgTriggers()
	{
		Type[] types = new Type[0];
		Type.GetMethod("doDmgTriggers", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public void ResetMinionDeathTriggers()
	{
		Type[] types = new Type[0];
		Type.GetMethod("ResetMinionDeathTriggers", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public bool HasPendingTriggers()
	{
		Type[] types = new Type[0];
		return (bool)Type.GetMethod("HasPendingTriggers", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public void triggerACharGotHealed()
	{
		Type[] types = new Type[0];
		Type.GetMethod("triggerACharGotHealed", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public void triggerAMinionGotHealed()
	{
		Type[] types = new Type[0];
		Type.GetMethod("triggerAMinionGotHealed", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public void triggerAMinionGotDmg()
	{
		Type[] types = new Type[0];
		Type.GetMethod("triggerAMinionGotDmg", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public void triggerAMinionLosesDivineShield()
	{
		Type[] types = new Type[0];
		Type.GetMethod("triggerAMinionLosesDivineShield", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public void triggerAMinionDied()
	{
		Type[] types = new Type[0];
		Type.GetMethod("triggerAMinionDied", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public void HandleHeroAbilitySummon(object ability, int minionsDied, bool isOwn)
	{
		Type[] types = new Type[3]
		{
			Type.Assembly.GetType("HREngine.Bots.Handmanager+Handcard"),
			typeof(int),
			typeof(bool)
		};
		Type.GetMethod("HandleHeroAbilitySummon", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[3] { ability, minionsDied, isOwn });
	}

	public void InfuseDeckCards()
	{
		Type[] types = new Type[0];
		Type.GetMethod("InfuseDeckCards", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public void InfuseHandCards()
	{
		Type[] types = new Type[0];
		Type.GetMethod("InfuseHandCards", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public void InfuseCard(object hc)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Handmanager+Handcard") };
		Type.GetMethod("InfuseCard", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { hc });
	}

	public void HandleWeaponEffectOnMinionDeath(object weapon, bool own)
	{
		Type[] types = new Type[2]
		{
			Type.Assembly.GetType("HREngine.Bots.Weapon"),
			typeof(bool)
		};
		Type.GetMethod("HandleWeaponEffectOnMinionDeath", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { weapon, own });
	}

	public void triggerAMinionIsGoingToAttack(object attacker, object target)
	{
		Type[] types = new Type[2]
		{
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			Type.Assembly.GetType("HREngine.Bots.Minion")
		};
		Type.GetMethod("triggerAMinionIsGoingToAttack", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { attacker, target });
	}

	public void triggerAMinionDealedDmg(object m, int dmgDone, bool isAttacker)
	{
		Type[] types = new Type[3]
		{
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			typeof(int),
			typeof(bool)
		};
		Type.GetMethod("triggerAMinionDealedDmg", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[3] { m, dmgDone, isAttacker });
	}

	public void triggerACardWillBePlayed(object hc, bool own)
	{
		Type[] types = new Type[2]
		{
			Type.Assembly.GetType("HREngine.Bots.Handmanager+Handcard"),
			typeof(bool)
		};
		Type.GetMethod("triggerACardWillBePlayed", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { hc, own });
	}

	public void triggerAMinionIsSummoned(object m)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Minion") };
		Type.GetMethod("triggerAMinionIsSummoned", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { m });
	}

	public void triggerAMinionWasSummoned(object mnn)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Minion") };
		Type.GetMethod("triggerAMinionWasSummoned", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { mnn });
	}

	public void triggerEndTurn(bool ownturn)
	{
		Type[] types = new Type[1] { typeof(bool) };
		Type.GetMethod("triggerEndTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { ownturn });
	}

	public void HandleShadowMadnessEffect(bool ownturn)
	{
		Type[] types = new Type[1] { typeof(bool) };
		Type.GetMethod("HandleShadowMadnessEffect", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { ownturn });
	}

	public void ResetSpecialCardEffects()
	{
		Type[] types = new Type[0];
		Type.GetMethod("ResetSpecialCardEffects", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public void triggerStartTurn(bool ownturn)
	{
		Type[] types = new Type[1] { typeof(bool) };
		Type.GetMethod("triggerStartTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { ownturn });
	}

	public void triggerAHeroGotArmor(bool ownHero)
	{
		Type[] types = new Type[1] { typeof(bool) };
		Type.GetMethod("triggerAHeroGotArmor", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { ownHero });
	}

	public void ResolvePendingStartOfTurnSummons(bool ownturn)
	{
		Type[] types = new Type[1] { typeof(bool) };
		Type.GetMethod("ResolvePendingStartOfTurnSummons", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { ownturn });
	}

	public void ResolveTimedAuraStartOfTurn(bool ownturn)
	{
		Type[] types = new Type[1] { typeof(bool) };
		Type.GetMethod("ResolveTimedAuraStartOfTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { ownturn });
	}

	public void ResolveTimedAuraEndOfTurn(bool ownturn)
	{
		Type[] types = new Type[1] { typeof(bool) };
		Type.GetMethod("ResolveTimedAuraEndOfTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { ownturn });
	}

	public void RefreshDeputizationAuraTarget(bool ownSide)
	{
		Type[] types = new Type[1] { typeof(bool) };
		Type.GetMethod("RefreshDeputizationAuraTarget", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { ownSide });
	}

	public void ResolveStartOfTurnDraw(bool ownturn)
	{
		Type[] types = new Type[1] { typeof(bool) };
		Type.GetMethod("ResolveStartOfTurnDraw", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { ownturn });
	}

	public void ResolveBarrenDiscoverDraw(bool ownturn)
	{
		Type[] types = new Type[1] { typeof(bool) };
		Type.GetMethod("ResolveBarrenDiscoverDraw", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { ownturn });
	}

	public void ResolveEnemyBarrenDiscoverDraw()
	{
		Type[] types = new Type[0];
		Type.GetMethod("ResolveEnemyBarrenDiscoverDraw", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public object GetPreferredBarrenDeckOptions()
	{
		Type[] types = new Type[0];
		return Type.GetMethod("GetPreferredBarrenDeckOptions", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public void ResolvePendingHatchingCeremony(bool ownTurnEnded)
	{
		Type[] types = new Type[1] { typeof(bool) };
		Type.GetMethod("ResolvePendingHatchingCeremony", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { ownTurnEnded });
	}

	public void ResolvePendingFracturedPower()
	{
		Type[] types = new Type[0];
		Type.GetMethod("ResolvePendingFracturedPower", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public void TrackPlayedCardState(object hc, bool wasOwnCard)
	{
		Type[] types = new Type[2]
		{
			Type.Assembly.GetType("HREngine.Bots.Handmanager+Handcard"),
			typeof(bool)
		};
		Type.GetMethod("TrackPlayedCardState", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { hc, wasOwnCard });
	}

	public void TransformDragonReactiveHandCards()
	{
		Type[] types = new Type[0];
		Type.GetMethod("TransformDragonReactiveHandCards", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public static bool IsRafaamFamilyCard(cardIDEnum cardId)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.CardDB+cardIDEnum") };
		return (bool)Type.GetMethod("IsRafaamFamilyCard", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).Invoke(null, new object[1] { cardId });
	}

	public void TriggerCardWasPlayed(object card, bool wasOwnCard)
	{
		Type[] types = new Type[2]
		{
			Type.Assembly.GetType("HREngine.Bots.CardDB+Card"),
			typeof(bool)
		};
		Type.GetMethod("TriggerCardWasPlayed", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { card, wasOwnCard });
	}

	public void TrackFullBoardQuestProgress(bool ownSide)
	{
		Type[] types = new Type[1] { typeof(bool) };
		Type.GetMethod("TrackFullBoardQuestProgress", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { ownSide });
	}

	public int GetElementalDamageBonus(object minion)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Minion") };
		return (int)Type.GetMethod("GetElementalDamageBonus", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { minion });
	}

	public void triggerCardsChanged(bool own)
	{
		Type[] types = new Type[1] { typeof(bool) };
		Type.GetMethod("triggerCardsChanged", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { own });
	}

	public void triggerInspire(bool ownturn)
	{
		Type[] types = new Type[1] { typeof(bool) };
		Type.GetMethod("triggerInspire", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { ownturn });
	}

	public void spendMana(int cost)
	{
		Type[] types = new Type[1] { typeof(int) };
		Type.GetMethod("spendMana", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { cost });
	}

	public void triggerSpendLastManaCrystal()
	{
		Type[] types = new Type[0];
		Type.GetMethod("triggerSpendLastManaCrystal", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public int secretTrigger_CharIsAttacked(object attacker, object defender)
	{
		Type[] types = new Type[2]
		{
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			Type.Assembly.GetType("HREngine.Bots.Minion")
		};
		return (int)Type.GetMethod("secretTrigger_CharIsAttacked", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { attacker, defender });
	}

	public void secretTrigger_HeroGotDmg(bool own, int dmg)
	{
		Type[] types = new Type[2]
		{
			typeof(bool),
			typeof(int)
		};
		Type.GetMethod("secretTrigger_HeroGotDmg", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { own, dmg });
	}

	public void secretTrigger_MinionIsPlayed(object playedMinion)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Minion") };
		Type.GetMethod("secretTrigger_MinionIsPlayed", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { playedMinion });
	}

	public int secretTrigger_SpellIsPlayed(object target, object c)
	{
		Type[] types = new Type[2]
		{
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			Type.Assembly.GetType("HREngine.Bots.CardDB+Card")
		};
		return (int)Type.GetMethod("secretTrigger_SpellIsPlayed", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { target, c });
	}

	public void secretTrigger_MinionDied(bool own)
	{
		Type[] types = new Type[1] { typeof(bool) };
		Type.GetMethod("secretTrigger_MinionDied", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { own });
	}

	public void secretTrigger_HeroPowerUsed()
	{
		Type[] types = new Type[0];
		Type.GetMethod("secretTrigger_HeroPowerUsed", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public int getSecretTriggersByType(int type, bool actedMinionOwn, bool actedMinionIsHero, object target)
	{
		Type[] types = new Type[4]
		{
			typeof(int),
			typeof(bool),
			typeof(bool),
			Type.Assembly.GetType("HREngine.Bots.Minion")
		};
		return (int)Type.GetMethod("getSecretTriggersByType", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[4] { type, actedMinionOwn, actedMinionIsHero, target });
	}

	public void TriggerSheepMaskDeathrattle(object m)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Minion") };
		Type.GetMethod("TriggerSheepMaskDeathrattle", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { m });
	}

	public void updateBoards()
	{
		Type[] types = new Type[0];
		Type.GetMethod("updateBoards", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public void handleSpiritClaws(object weapon, object hero, int currentSpellPower, int initialSpellPower, bool spiritClawsActive)
	{
		Type[] types = new Type[5]
		{
			Type.Assembly.GetType("HREngine.Bots.Weapon"),
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			typeof(int),
			typeof(int),
			typeof(bool)
		};
		Type.GetMethod("handleSpiritClaws", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[5] { weapon, hero, currentSpellPower, initialSpellPower, spiritClawsActive });
	}

	public void minionGetOrEraseAllAreaBuffs(object m, bool get)
	{
		Type[] types = new Type[2]
		{
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			typeof(bool)
		};
		Type.GetMethod("minionGetOrEraseAllAreaBuffs", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { m, get });
	}

	public void handleRaceSpecificBuffs(object m, bool get, bool own)
	{
		Type[] types = new Type[3]
		{
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			typeof(bool),
			typeof(bool)
		};
		Type.GetMethod("handleRaceSpecificBuffs", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[3] { m, get, own });
	}

	public void updateAdjacentBuffs(bool own)
	{
		Type[] types = new Type[1] { typeof(bool) };
		Type.GetMethod("updateAdjacentBuffs", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { own });
	}

	public object createNewMinion(object hc, int zonepos, bool own)
	{
		Type[] types = new Type[3]
		{
			Type.Assembly.GetType("HREngine.Bots.Handmanager+Handcard"),
			typeof(int),
			typeof(bool)
		};
		return Type.GetMethod("createNewMinion", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[3] { hc, zonepos, own });
	}

	public void placeAmobSomewhere(object hc, int choice, int zonepos)
	{
		Type[] types = new Type[3]
		{
			Type.Assembly.GetType("HREngine.Bots.Handmanager+Handcard"),
			typeof(int),
			typeof(int)
		};
		Type.GetMethod("placeAmobSomewhere", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[3] { hc, choice, zonepos });
	}

	public void addMinionToBattlefield(object m, bool isSummon)
	{
		Type[] types = new Type[2]
		{
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			typeof(bool)
		};
		Type.GetMethod("addMinionToBattlefield", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { m, isSummon });
	}

	public void equipWeapon(object c, bool own)
	{
		Type[] types = new Type[2]
		{
			Type.Assembly.GetType("HREngine.Bots.CardDB+Card"),
			typeof(bool)
		};
		Type.GetMethod("equipWeapon", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { c, own });
	}

	public void minionGetFrozen(object target)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Minion") };
		Type.GetMethod("minionGetFrozen", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { target });
	}

	public void TriggerCardDrawHooks(object drawnCard, bool ownDraw)
	{
		Type[] types = new Type[2]
		{
			Type.Assembly.GetType("HREngine.Bots.CardDB+Card"),
			typeof(bool)
		};
		Type.GetMethod("TriggerCardDrawHooks", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { drawnCard, ownDraw });
	}

	public void minionGetSilenced(object m)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Minion") };
		Type.GetMethod("minionGetSilenced", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { m });
	}

	public void allMinionsGetSilenced(bool own)
	{
		Type[] types = new Type[1] { typeof(bool) };
		Type.GetMethod("allMinionsGetSilenced", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { own });
	}

	public void drawACard(string cardName, bool own, bool nopen)
	{
		Type[] types = new Type[3]
		{
			typeof(string),
			typeof(bool),
			typeof(bool)
		};
		Type.GetMethod("drawACard", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[3] { cardName, own, nopen });
	}

	public void drawACard(Race race, bool own, bool nopen)
	{
		Type[] types = new Type[3]
		{
			Type.Assembly.GetType("HREngine.Bots.CardDB+Race"),
			typeof(bool),
			typeof(bool)
		};
		Type.GetMethod("drawACard", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[3] { race, own, nopen });
	}

	public void drawACard(cardNameEN ss, bool own, bool nopen)
	{
		Type[] types = new Type[3]
		{
			Type.Assembly.GetType("HREngine.Bots.CardDB+cardNameEN"),
			typeof(bool),
			typeof(bool)
		};
		Type.GetMethod("drawACard", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[3] { ss, own, nopen });
	}

	public int EnemyCardPlaying(TAG_CLASS enemyHeroStrtClass, int currmana, int cardcount, int playAroundProb, int pap2)
	{
		Type[] types = new Type[5]
		{
			Type.Assembly.GetType("HREngine.Bots.TAG_CLASS"),
			typeof(int),
			typeof(int),
			typeof(int),
			typeof(int)
		};
		return (int)Type.GetMethod("EnemyCardPlaying", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[5] { enemyHeroStrtClass, currmana, cardcount, playAroundProb, pap2 });
	}

	public int EnemyPlaysACard(cardNameEN cardname, int currmana, int playAroundProb, int pap2)
	{
		Type[] types = new Type[4]
		{
			Type.Assembly.GetType("HREngine.Bots.CardDB+cardNameEN"),
			typeof(int),
			typeof(int),
			typeof(int)
		};
		return (int)Type.GetMethod("EnemyPlaysACard", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[4] { cardname, currmana, playAroundProb, pap2 });
	}

	public int getNextEntity()
	{
		Type[] types = new Type[0];
		return (int)Type.GetMethod("getNextEntity", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public object GetAttackTargets(bool own, bool isLethalCheck)
	{
		Type[] types = new Type[2]
		{
			typeof(bool),
			typeof(bool)
		};
		return Type.GetMethod("GetAttackTargets", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { own, isLethalCheck });
	}

	public int getBestPlace(object card, bool lethal)
	{
		Type[] types = new Type[2]
		{
			Type.Assembly.GetType("HREngine.Bots.CardDB+Card"),
			typeof(bool)
		};
		return (int)Type.GetMethod("getBestPlace", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { card, lethal });
	}

	public int getBestAdapt(object m)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Minion") };
		return (int)Type.GetMethod("getBestAdapt", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { m });
	}

	public int guessEnemyHeroLethalMissing()
	{
		Type[] types = new Type[0];
		return (int)Type.GetMethod("guessEnemyHeroLethalMissing", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public void guessHeroDamage()
	{
		Type[] types = new Type[0];
		Type.GetMethod("guessHeroDamage", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public bool ownHeroHasDirectLethal()
	{
		Type[] types = new Type[0];
		return (bool)Type.GetMethod("ownHeroHasDirectLethal", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public void simulateTrapsStartEnemyTurn()
	{
		Type[] types = new Type[0];
		Type.GetMethod("simulateTrapsStartEnemyTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public void simulateTrapsEndEnemyTurn()
	{
		Type[] types = new Type[0];
		Type.GetMethod("simulateTrapsEndEnemyTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public int getHeraldMultiplier(bool own)
	{
		Type[] types = new Type[1] { typeof(bool) };
		return (int)Type.GetMethod("getHeraldMultiplier", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { own });
	}

	public object callKidHeraldUpgraded(object c, int zonepos, bool own)
	{
		Type[] types = new Type[3]
		{
			Type.Assembly.GetType("HREngine.Bots.CardDB+Card"),
			typeof(int),
			typeof(bool)
		};
		return Type.GetMethod("callKidHeraldUpgraded", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[3] { c, zonepos, own });
	}

	public object heraldSummon(bool own)
	{
		Type[] types = new Type[1] { typeof(bool) };
		return Type.GetMethod("heraldSummon", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { own });
	}

	public void callKid(object c, int zonepos, bool own, bool spawnKid, bool oneMoreIsAllowed)
	{
		Type[] types = new Type[5]
		{
			Type.Assembly.GetType("HREngine.Bots.CardDB+Card"),
			typeof(int),
			typeof(bool),
			typeof(bool),
			typeof(bool)
		};
		Type.GetMethod("callKid", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[5] { c, zonepos, own, spawnKid, oneMoreIsAllowed });
	}

	public void CallMinionCopy(object originMinion, bool own, int callCount, bool surroundSummon)
	{
		Type[] types = new Type[4]
		{
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			typeof(bool),
			typeof(int),
			typeof(bool)
		};
		Type.GetMethod("CallMinionCopy", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[4] { originMinion, own, callCount, surroundSummon });
	}

	public object callKidAndReturn(object c, int zonepos, bool own, bool spawnKid, bool oneMoreIsAllowed)
	{
		Type[] types = new Type[5]
		{
			Type.Assembly.GetType("HREngine.Bots.CardDB+Card"),
			typeof(int),
			typeof(bool),
			typeof(bool),
			typeof(bool)
		};
		return Type.GetMethod("callKidAndReturn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[5] { c, zonepos, own, spawnKid, oneMoreIsAllowed });
	}

	public void endTurn()
	{
		Type[] types = new Type[0];
		Type.GetMethod("endTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public void startTurn()
	{
		Type[] types = new Type[0];
		Type.GetMethod("startTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public void SummonIllidari()
	{
		Type[] types = new Type[0];
		Type.GetMethod("SummonIllidari", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public void ShuffleIntoOwnDeck(object card)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.CardDB+Card") };
		Type.GetMethod("ShuffleIntoOwnDeck", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { card });
	}

	public void MarkOwnDeckSpecificDoubledMinion(cardIDEnum cardId)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.CardDB+cardIDEnum") };
		Type.GetMethod("MarkOwnDeckSpecificDoubledMinion", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { cardId });
	}

	public void ResolveSigilOfCinderAtStartOfTurn()
	{
		Type[] types = new Type[0];
		Type.GetMethod("ResolveSigilOfCinderAtStartOfTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public bool ConsumeOwnDeckSpecificDoubledMinion(cardIDEnum cardId)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.CardDB+cardIDEnum") };
		return (bool)Type.GetMethod("ConsumeOwnDeckSpecificDoubledMinion", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { cardId });
	}

	public void ApplySpecificDeckDoubleStatsBonusToHandcard(object card, object handcard)
	{
		Type[] types = new Type[2]
		{
			Type.Assembly.GetType("HREngine.Bots.CardDB+Card"),
			Type.Assembly.GetType("HREngine.Bots.Handmanager+Handcard")
		};
		Type.GetMethod("ApplySpecificDeckDoubleStatsBonus", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { card, handcard });
	}

	public void ApplySpecificDeckDoubleStatsBonusToMinion(object card, object minion)
	{
		Type[] types = new Type[2]
		{
			Type.Assembly.GetType("HREngine.Bots.CardDB+Card"),
			Type.Assembly.GetType("HREngine.Bots.Minion")
		};
		Type.GetMethod("ApplySpecificDeckDoubleStatsBonus", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { card, minion });
	}

	public void ResolveSigilOfSeasAtStartOfTurn()
	{
		Type[] types = new Type[0];
		Type.GetMethod("ResolveSigilOfSeasAtStartOfTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public int GetSandfuryAuraCount(bool own)
	{
		Type[] types = new Type[1] { typeof(bool) };
		return (int)Type.GetMethod("GetSandfuryAuraCount", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { own });
	}

	public void AdvanceSandfuryAuraAtStartOfTurn(bool ownTurnStarting)
	{
		Type[] types = new Type[1] { typeof(bool) };
		Type.GetMethod("AdvanceSandfuryAuraAtStartOfTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { ownTurnStarting });
	}

	public bool HandleDelayedTemporaryControlReturn(object m)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Minion") };
		return (bool)Type.GetMethod("HandleDelayedTemporaryControlReturn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { m });
	}

	public void BeginSpellDamageTracking(bool ownSide)
	{
		Type[] types = new Type[1] { typeof(bool) };
		Type.GetMethod("BeginSpellDamageTracking", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { ownSide });
	}

	public void EndSpellDamageTracking(bool ownSide)
	{
		Type[] types = new Type[1] { typeof(bool) };
		Type.GetMethod("EndSpellDamageTracking", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { ownSide });
	}

	public void RegisterSpellDamageDealt(bool ownSide)
	{
		Type[] types = new Type[1] { typeof(bool) };
		Type.GetMethod("RegisterSpellDamageDealt", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { ownSide });
	}

	public void AdvanceAvianaMoonCycleAtStartOfTurn()
	{
		Type[] types = new Type[0];
		Type.GetMethod("AdvanceAvianaMoonCycleAtStartOfTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public void unlockMana()
	{
		Type[] types = new Type[0];
		Type.GetMethod("unlockMana", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public int getHeroPowerDamage(int dmg)
	{
		Type[] types = new Type[1] { typeof(int) };
		return (int)Type.GetMethod("getHeroPowerDamage", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { dmg });
	}

	public int getEnemyHeroPowerDamage(int dmg)
	{
		Type[] types = new Type[1] { typeof(int) };
		return (int)Type.GetMethod("getEnemyHeroPowerDamage", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { dmg });
	}

	public int getSpellDamageDamage(int dmg)
	{
		Type[] types = new Type[1] { typeof(int) };
		return (int)Type.GetMethod("getSpellDamageDamage", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { dmg });
	}

	public int getSpellHeal(int heal)
	{
		Type[] types = new Type[1] { typeof(int) };
		return (int)Type.GetMethod("getSpellHeal", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { heal });
	}

	public void applySpellLifesteal(int heal, bool own)
	{
		Type[] types = new Type[2]
		{
			typeof(int),
			typeof(bool)
		};
		Type.GetMethod("applySpellLifesteal", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { heal, own });
	}

	public int getMinionHeal(int heal)
	{
		Type[] types = new Type[1] { typeof(int) };
		return (int)Type.GetMethod("getMinionHeal", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { heal });
	}

	public int getEnemySpellDamageDamage(int dmg)
	{
		Type[] types = new Type[1] { typeof(int) };
		return (int)Type.GetMethod("getEnemySpellDamageDamage", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { dmg });
	}

	public int getEnemySpellHeal(int heal)
	{
		Type[] types = new Type[1] { typeof(int) };
		return (int)Type.GetMethod("getEnemySpellHeal", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { heal });
	}

	public int getEnemyMinionHeal(int heal)
	{
		Type[] types = new Type[1] { typeof(int) };
		return (int)Type.GetMethod("getEnemyMinionHeal", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { heal });
	}

	public void doAction(object aa)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Action") };
		Type.GetMethod("doAction", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { aa });
	}

	public object FindMinionByEntityId(object target)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Minion") };
		return Type.GetMethod("FindMinionByEntityId", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { target });
	}

	public object FindHandCard(object aa)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Action") };
		return Type.GetMethod("FindHandCard", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { aa });
	}

	public void HandleMinionAttack(object a)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Action") };
		Type.GetMethod("HandleMinionAttack", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { a });
	}

	public void HandleTamsinRoameEffect(object a)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Action") };
		Type.GetMethod("HandleTamsinRoameEffect", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { a });
	}

	public void HandlePatchesSummon(object a)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Action") };
		Type.GetMethod("HandlePatchesSummon", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { a });
	}

	public void HandleQuestCompletion()
	{
		Type[] types = new Type[0];
		Type.GetMethod("HandleQuestCompletion", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public void HandleTrade(object a)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Action") };
		Type.GetMethod("HandleTrade", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { a });
	}

	public void HandleForge(object a)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Action") };
		Type.GetMethod("HandleForge", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { a });
	}

	public void triggerAMinionAttacks(object attackingMinion)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Minion") };
		Type.GetMethod("triggerAMinionAttacks", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { attackingMinion });
	}

	public void minionAttacksMinion(object attacker, object defender, bool dontcount)
	{
		Type[] types = new Type[3]
		{
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			typeof(bool)
		};
		Type.GetMethod("minionAttacksMinion", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[3] { attacker, defender, dontcount });
	}

	public void HandleHeroAttack(object attacker, object defender, int oldHp)
	{
		Type[] types = new Type[3]
		{
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			typeof(int)
		};
		Type.GetMethod("HandleHeroAttack", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[3] { attacker, defender, oldHp });
	}

	public int AdjustDamageForWeapon(object attacker, int dmg)
	{
		Type[] types = new Type[2]
		{
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			typeof(int)
		};
		return (int)Type.GetMethod("AdjustDamageForWeapon", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { attacker, dmg });
	}

	public void DecreaseWeaponDurability(bool own)
	{
		Type[] types = new Type[1] { typeof(bool) };
		Type.GetMethod("DecreaseWeaponDurability", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { own });
	}

	public void HandleWeaponSpecialEffects(object attacker, object defender, int oldHp)
	{
		Type[] types = new Type[3]
		{
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			typeof(int)
		};
		Type.GetMethod("HandleWeaponSpecialEffects", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[3] { attacker, defender, oldHp });
	}

	public void HandleDefenderDamageEffects(object attacker, object defender, int oldHp, bool defenderHasDivineshild)
	{
		Type[] types = new Type[4]
		{
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			typeof(int),
			typeof(bool)
		};
		Type.GetMethod("HandleDefenderDamageEffects", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[4] { attacker, defender, oldHp, defenderHasDivineshild });
	}

	public void HandleAttackerDamageEffects(object attacker, object defender, int oldHp)
	{
		Type[] types = new Type[3]
		{
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			typeof(int)
		};
		Type.GetMethod("HandleAttackerDamageEffects", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[3] { attacker, defender, oldHp });
	}

	public void HandleOverkillAndHonorableKill(object attacker, object defender, int oldHp, int attackerAngr, bool defenderHasDivineshild)
	{
		Type[] types = new Type[5]
		{
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			typeof(int),
			typeof(int),
			typeof(bool)
		};
		Type.GetMethod("HandleOverkillAndHonorableKill", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[5] { attacker, defender, oldHp, attackerAngr, defenderHasDivineshild });
	}

	public void HealHero(bool own, int amount)
	{
		Type[] types = new Type[2]
		{
			typeof(bool),
			typeof(int)
		};
		Type.GetMethod("HealHero", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { own, amount });
	}

	public void HandlePostAttackEffects(object attacker, object defender, bool dontcount)
	{
		Type[] types = new Type[3]
		{
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			typeof(bool)
		};
		Type.GetMethod("HandlePostAttackEffects", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[3] { attacker, defender, dontcount });
	}

	public void AttackAdjacentMinions(object attacker, object defender)
	{
		Type[] types = new Type[2]
		{
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			Type.Assembly.GetType("HREngine.Bots.Minion")
		};
		Type.GetMethod("AttackAdjacentMinions", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { attacker, defender });
	}

	public void SummonMurlocs(object attacker)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Minion") };
		Type.GetMethod("SummonMurlocs", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { attacker });
	}

	public void attackWithWeapon(object hero, object target, int penality)
	{
		Type[] types = new Type[3]
		{
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			typeof(int)
		};
		Type.GetMethod("attackWithWeapon", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[3] { hero, target, penality });
	}

	public void PlayACard(object hc, object target, int position, int choice, int penality)
	{
		Type[] types = new Type[5]
		{
			Type.Assembly.GetType("HREngine.Bots.Handmanager+Handcard"),
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			typeof(int),
			typeof(int),
			typeof(int)
		};
		Type.GetMethod("PlayACard", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[5] { hc, target, position, choice, penality });
	}

	public void PlayACard(object hc, object target, object target2, object target3, int position, int choice, int penality, int targetCount)
	{
		Type[] types = new Type[8]
		{
			Type.Assembly.GetType("HREngine.Bots.Handmanager+Handcard"),
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			typeof(int),
			typeof(int),
			typeof(int),
			typeof(int)
		};
		Type.GetMethod("PlayACard", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[8] { hc, target, target2, target3, position, choice, penality, targetCount });
	}

	public void HandleSpecialCardCost(object hc)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Handmanager+Handcard") };
		Type.GetMethod("HandleSpecialCardCost", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { hc });
	}

	public void PayHealthForSpell(object hc)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Handmanager+Handcard") };
		Type.GetMethod("PayHealthForSpell", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { hc });
	}

	public void PayHealthForMurloc(object hc)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Handmanager+Handcard") };
		Type.GetMethod("PayHealthForMurloc", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { hc });
	}

	public void RemoveOtherDiscoveredCards(object hc)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Handmanager+Handcard") };
		Type.GetMethod("RemoveOtherDiscoveredCards", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { hc });
	}

	public void UpdateElementalAndNatureFlags(object c)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.CardDB+Card") };
		Type.GetMethod("UpdateElementalAndNatureFlags", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { c });
	}

	public void UpdateElementalFlag()
	{
		Type[] types = new Type[0];
		Type.GetMethod("UpdateElementalFlag", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public void UpdateNatureSpellFlag(object c)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.CardDB+Card") };
		Type.GetMethod("UpdateNatureSpellFlag", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { c });
	}

	public void HandleSpellCardEffects(object hc, object target, int choice)
	{
		Type[] types = new Type[3]
		{
			Type.Assembly.GetType("HREngine.Bots.Handmanager+Handcard"),
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			typeof(int)
		};
		Type.GetMethod("HandleSpellCardEffects", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[3] { hc, target, choice });
	}

	public void HandleSpellTargetEffects(object hc, object target, int choice)
	{
		Type[] types = new Type[3]
		{
			Type.Assembly.GetType("HREngine.Bots.Handmanager+Handcard"),
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			typeof(int)
		};
		Type.GetMethod("HandleSpellTargetEffects", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[3] { hc, target, choice });
	}

	public object UpdateTargetBasedOnSecret(int newTarget, object target)
	{
		Type[] types = new Type[2]
		{
			typeof(int),
			Type.Assembly.GetType("HREngine.Bots.Minion")
		};
		return Type.GetMethod("UpdateTargetBasedOnSecret", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { newTarget, target });
	}

	public void HandleMinionOrSpellPlay(object hc, object target, int position, int choice)
	{
		Type[] types = new Type[4]
		{
			Type.Assembly.GetType("HREngine.Bots.Handmanager+Handcard"),
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			typeof(int),
			typeof(int)
		};
		Type.GetMethod("HandleMinionOrSpellPlay", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[4] { hc, target, position, choice });
	}

	public void HandleLocationPlay(object hc, int position, int choice)
	{
		Type[] types = new Type[3]
		{
			Type.Assembly.GetType("HREngine.Bots.Handmanager+Handcard"),
			typeof(int),
			typeof(int)
		};
		Type.GetMethod("HandleLocationPlay", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[3] { hc, position, choice });
	}

	public void HandleWeaponPlay(object hc, object target, int choice)
	{
		Type[] types = new Type[3]
		{
			Type.Assembly.GetType("HREngine.Bots.Handmanager+Handcard"),
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			typeof(int)
		};
		Type.GetMethod("HandleWeaponPlay", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[3] { hc, target, choice });
	}

	public void HandleHeroPlay(object hc, int choice)
	{
		Type[] types = new Type[2]
		{
			Type.Assembly.GetType("HREngine.Bots.Handmanager+Handcard"),
			typeof(int)
		};
		Type.GetMethod("HandleHeroPlay", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { hc, choice });
	}

	public void HandleMinionPlay(object hc, int position, int choice)
	{
		Type[] types = new Type[3]
		{
			Type.Assembly.GetType("HREngine.Bots.Handmanager+Handcard"),
			typeof(int),
			typeof(int)
		};
		Type.GetMethod("HandleMinionPlay", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[3] { hc, position, choice });
	}

	public void HandleSpellPlay(object hc, object target, int choice)
	{
		Type[] types = new Type[3]
		{
			Type.Assembly.GetType("HREngine.Bots.Handmanager+Handcard"),
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			typeof(int)
		};
		Type.GetMethod("HandleSpellPlay", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[3] { hc, target, choice });
	}

	public void onOwnTurnStart(object p)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Playfield") };
		Type.GetMethod("onOwnTurnStart", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { p });
	}

	public void PlayCard(object hc, object target, int choice)
	{
		Type[] types = new Type[3]
		{
			Type.Assembly.GetType("HREngine.Bots.Handmanager+Handcard"),
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			typeof(int)
		};
		Type.GetMethod("PlayCard", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[3] { hc, target, choice });
	}

	public object GetAllMinions()
	{
		Type[] types = new Type[0];
		return Type.GetMethod("GetAllMinions", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public void onOwnTurnEnd()
	{
		Type[] types = new Type[0];
		Type.GetMethod("onOwnTurnEnd", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public object dredge(bool own)
	{
		Type[] types = new Type[1] { typeof(bool) };
		return Type.GetMethod("dredge", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { own });
	}

	public void onEnemyTurnStart()
	{
		Type[] types = new Type[0];
		Type.GetMethod("onEnemyTurnStart", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public void onEnemyTurnEnd()
	{
		Type[] types = new Type[0];
		Type.GetMethod("onEnemyTurnEnd", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public void applyLoathebEffect()
	{
		Type[] types = new Type[0];
		Type.GetMethod("applyLoathebEffect", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public void AddToEnemyHand(object card)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Handmanager+Handcard") };
		Type.GetMethod("AddToEnemyHand", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { card });
	}

	public void RemoveFromEnemyHand(object card)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Handmanager+Handcard") };
		Type.GetMethod("RemoveFromEnemyHand", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { card });
	}

	public void AddToDeck(object card)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.CardDB+Card") };
		Type.GetMethod("AddToDeck", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { card });
	}

	public void RemoveFromDeck(object card)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.CardDB+Card") };
		Type.GetMethod("RemoveFromDeck", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { card });
	}

	public void addCorpses(int count)
	{
		Type[] types = new Type[1] { typeof(int) };
		Type.GetMethod("addCorpses", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { count });
	}

	public void summonPirate(object p)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Playfield") };
		Type.GetMethod("summonPirate", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { p });
	}

	public void corpseConsumption(int count)
	{
		Type[] types = new Type[1] { typeof(int) };
		Type.GetMethod("corpseConsumption", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { count });
	}

	public int getCorpseCount()
	{
		Type[] types = new Type[0];
		return (int)Type.GetMethod("getCorpseCount", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public void RestoreOwnHandCardMetadata()
	{
		Type[] types = new Type[0];
		Type.GetMethod("RestoreOwnHandCardMetadata", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public void InitializeOwnStartingDeckSnapshotIfNeeded()
	{
		Type[] types = new Type[0];
		Type.GetMethod("InitializeOwnStartingDeckSnapshotIfNeeded", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public bool IsLikelyGeneratedOpeningHandCard(object hc)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Handmanager+Handcard") };
		return (bool)Type.GetMethod("IsLikelyGeneratedOpeningHandCard", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { hc });
	}

	public bool InferStartedInDeckForNewOwnHandCard(object hc)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Handmanager+Handcard") };
		return (bool)Type.GetMethod("InferStartedInDeckForNewOwnHandCard", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { hc });
	}

	public void RecordSeenStartingDeckCopy(cardIDEnum baseCardId)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.CardDB+cardIDEnum") };
		Type.GetMethod("RecordSeenStartingDeckCopy", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { baseCardId });
	}

	public void SaveOwnHandCardMetadata(object hc)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Handmanager+Handcard") };
		Type.GetMethod("SaveOwnHandCardMetadata", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { hc });
	}

	public void AddHandSpellDamageBonus(object hc, int amount)
	{
		Type[] types = new Type[2]
		{
			Type.Assembly.GetType("HREngine.Bots.Handmanager+Handcard"),
			typeof(int)
		};
		Type.GetMethod("AddHandSpellDamageBonus", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { hc, amount });
	}

	public object GetNewestOwnHandCard(int previousCount)
	{
		Type[] types = new Type[1] { typeof(int) };
		return Type.GetMethod("GetNewestOwnHandCard", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { previousCount });
	}

	public void MarkHandCardCostsHealthInsteadOfMana(object hc)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Handmanager+Handcard") };
		Type.GetMethod("MarkHandCardCostsHealthInsteadOfMana", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { hc });
	}

	public object ReleaseJarStoredMinion(object jar)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Minion") };
		return Type.GetMethod("ReleaseJarStoredMinion", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { jar });
	}

	public void TryGrantDiscoverFollowup(object hc)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Handmanager+Handcard") };
		Type.GetMethod("TryGrantDiscoverFollowup", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { hc });
	}

	public void TryResolveOriginStone(object hc)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Handmanager+Handcard") };
		Type.GetMethod("TryResolveOriginStone", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { hc });
	}

	public void PlayCardByEffectFromCard(object card)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.CardDB+Card") };
		Type.GetMethod("PlayCardByEffectFromCard", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { card });
	}

	public void TryMergeSoletosHalves()
	{
		Type[] types = new Type[0];
		Type.GetMethod("TryMergeSoletosHalves", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public void HandleReachEquilibriumProgress(SpellSchool school)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.CardDB+SpellSchool") };
		Type.GetMethod("HandleReachEquilibriumProgress", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { school });
	}

	public void RefreshSpecialHandTransforms()
	{
		Type[] types = new Type[0];
		Type.GetMethod("RefreshSpecialHandTransforms", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public void ApplyHandMirrorTransform(object hc, cardIDEnum sourceCardId)
	{
		Type[] types = new Type[2]
		{
			Type.Assembly.GetType("HREngine.Bots.Handmanager+Handcard"),
			Type.Assembly.GetType("HREngine.Bots.CardDB+cardIDEnum")
		};
		Type.GetMethod("ApplyHandMirrorTransform", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { hc, sourceCardId });
	}

	public void ApplyTitanographerOskHandTransform(object hc)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Handmanager+Handcard") };
		Type.GetMethod("ApplyTitanographerOskHandTransform", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { hc });
	}

	public void ApplyTwistedMonstrosityHandTransform(object hc)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Handmanager+Handcard") };
		Type.GetMethod("ApplyTwistedMonstrosityHandTransform", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { hc });
	}

	public void ApplyRavenousFelfisherHandReduction(object hc)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Handmanager+Handcard") };
		Type.GetMethod("ApplyRavenousFelfisherHandReduction", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { hc });
	}

	public void ApplyCursedGennHandTransform(object hc)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Handmanager+Handcard") };
		Type.GetMethod("ApplyCursedGennHandTransform", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { hc });
	}

	public void ApplyGronnGiantHandReduction(object hc)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Handmanager+Handcard") };
		Type.GetMethod("ApplyGronnGiantHandReduction", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { hc });
	}

	public void ApplyMuradinLastStandHandReduction(object hc)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Handmanager+Handcard") };
		Type.GetMethod("ApplyMuradinLastStandHandReduction", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { hc });
	}

	public void ApplyShadowedInformantHandTransform(object hc)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Handmanager+Handcard") };
		Type.GetMethod("ApplyShadowedInformantHandTransform", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { hc });
	}

	public void copyValuesFrom(object p)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Playfield") };
		Type.GetMethod("copyValuesFrom", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { p });
	}

	public void RegisterKindredPlay(object c)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.CardDB+Card") };
		Type.GetMethod("RegisterKindredPlay", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { c });
	}

	public bool IsKindredActive(object card)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.CardDB+Card") };
		return (bool)Type.GetMethod("IsKindredActive", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { card });
	}

	public int ConsumeKindredTriggerCount(object card)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.CardDB+Card") };
		return (int)Type.GetMethod("ConsumeKindredTriggerCount", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { card });
	}

	public void PrepareNextKindredTriggerTwice()
	{
		Type[] types = new Type[0];
		Type.GetMethod("PrepareNextKindredTriggerTwice", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public int ConsumeOwnBattlecryTriggerCount(object card)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.CardDB+Card") };
		return (int)Type.GetMethod("ConsumeOwnBattlecryTriggerCount", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { card });
	}

	public void SyncTurnScopedStateToProzis()
	{
		Type[] types = new Type[0];
		Type.GetMethod("SyncTurnScopedStateToProzis", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public void ApplyNextSummonedMinionFiveFive(object minion)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Minion") };
		Type.GetMethod("ApplyNextSummonedMinionFiveFive", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { minion });
	}

	public static bool IsBladedGauntlet(object weapon)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Weapon") };
		return (bool)Type.GetMethod("IsBladedGauntlet", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).Invoke(null, new object[1] { weapon });
	}

	public static bool IsKhadgar(object minion)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Minion") };
		return (bool)Type.GetMethod("IsKhadgar", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).Invoke(null, new object[1] { minion });
	}

	public static bool IsMayorNoggenfogger(object minion)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Minion") };
		return (bool)Type.GetMethod("IsMayorNoggenfogger", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).Invoke(null, new object[1] { minion });
	}

	public static bool IsSmallTimeBuccaneer(object minion)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Minion") };
		return (bool)Type.GetMethod("IsSmallTimeBuccaneer", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).Invoke(null, new object[1] { minion });
	}

	public int GetCardSummonMultiplier(bool ownSide)
	{
		Type[] types = new Type[1] { typeof(bool) };
		return (int)Type.GetMethod("GetCardSummonMultiplier", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { ownSide });
	}

	public bool HasNoggenfoggerAura()
	{
		Type[] types = new Type[0];
		return (bool)Type.GetMethod("HasNoggenfoggerAura", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public object RerollTargetForNoggenfogger(object card, object currentTarget, bool ownSide, int salt)
	{
		Type[] types = new Type[4]
		{
			Type.Assembly.GetType("HREngine.Bots.CardDB+Card"),
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			typeof(bool),
			typeof(int)
		};
		return Type.GetMethod("RerollTargetForNoggenfogger", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[4] { card, currentTarget, ownSide, salt });
	}

	public void RefreshArmorScaledWeaponAttack(bool ownSide)
	{
		Type[] types = new Type[1] { typeof(bool) };
		Type.GetMethod("RefreshArmorScaledWeaponAttack", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { ownSide });
	}

	public void RefreshSmallTimeBuccaneerBuffs(bool ownSide)
	{
		Type[] types = new Type[1] { typeof(bool) };
		Type.GetMethod("RefreshSmallTimeBuccaneerBuffs", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { ownSide });
	}

	public static bool IsRelicCard(cardIDEnum cardId)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.CardDB+cardIDEnum") };
		return (bool)Type.GetMethod("IsRelicCard", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).Invoke(null, new object[1] { cardId });
	}

	public int GetRelicPower(object hc, bool ownSide)
	{
		Type[] types = new Type[2]
		{
			Type.Assembly.GetType("HREngine.Bots.Handmanager+Handcard"),
			typeof(bool)
		};
		return (int)Type.GetMethod("GetRelicPower", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { hc, ownSide });
	}

	public void RefreshRelicPowerInHand(bool ownSide)
	{
		Type[] types = new Type[1] { typeof(bool) };
		Type.GetMethod("RefreshRelicPowerInHand", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { ownSide });
	}

	public void ImproveFutureRelics(bool ownSide)
	{
		Type[] types = new Type[1] { typeof(bool) };
		Type.GetMethod("ImproveFutureRelics", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { ownSide });
	}

	public int ConsumeRelicDoubleCastCount(bool ownSide)
	{
		Type[] types = new Type[1] { typeof(bool) };
		return (int)Type.GetMethod("ConsumeRelicDoubleCastCount", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { ownSide });
	}

	public void CastRelicById(cardIDEnum relicId, bool ownSide)
	{
		Type[] types = new Type[2]
		{
			Type.Assembly.GetType("HREngine.Bots.CardDB+cardIDEnum"),
			typeof(bool)
		};
		Type.GetMethod("CastRelicById", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { relicId, ownSide });
	}

	public static bool IsTrackableKindredRace(Race race)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.CardDB+Race") };
		return (bool)Type.GetMethod("IsTrackableKindredRace", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).Invoke(null, new object[1] { race });
	}

	public static bool IsTrackableKindredSpellSchool(SpellSchool school)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.CardDB+SpellSchool") };
		return (bool)Type.GetMethod("IsTrackableKindredSpellSchool", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).Invoke(null, new object[1] { school });
	}

	public static long AddHash(long hash, int value)
	{
		Type[] types = new Type[2]
		{
			typeof(long),
			typeof(int)
		};
		return (long)Type.GetMethod("AddHash", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).Invoke(null, new object[2] { hash, value });
	}

	public static long AddHash(long hash, bool value)
	{
		Type[] types = new Type[2]
		{
			typeof(long),
			typeof(bool)
		};
		return (long)Type.GetMethod("AddHash", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).Invoke(null, new object[2] { hash, value });
	}

	public static long AddHash(long hash, cardIDEnum value)
	{
		Type[] types = new Type[2]
		{
			typeof(long),
			Type.Assembly.GetType("HREngine.Bots.CardDB+cardIDEnum")
		};
		return (long)Type.GetMethod("AddHash", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).Invoke(null, new object[2] { hash, value });
	}

	public bool HasSameExtendedFutureState(object p)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Playfield") };
		return (bool)Type.GetMethod("HasSameExtendedFutureState", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { p });
	}

	public long GetExtendedFutureStateHashContribution()
	{
		Type[] types = new Type[0];
		return (long)Type.GetMethod("GetExtendedFutureStateHashContribution", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public bool isEqual(object p, bool logg)
	{
		Type[] types = new Type[2]
		{
			Type.Assembly.GetType("HREngine.Bots.Playfield"),
			typeof(bool)
		};
		return (bool)Type.GetMethod("isEqual", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { p, logg });
	}

	public bool isEqualf(object p)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Playfield") };
		return (bool)Type.GetMethod("isEqualf", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { p });
	}

	public long GetPHash()
	{
		Type[] types = new Type[0];
		return (long)Type.GetMethod("GetPHash", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public void enemyPlaysAoe(int pprob, int pprob2)
	{
		Type[] types = new Type[2]
		{
			typeof(int),
			typeof(int)
		};
		Type.GetMethod("enemyPlaysAoe", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { pprob, pprob2 });
	}
}
