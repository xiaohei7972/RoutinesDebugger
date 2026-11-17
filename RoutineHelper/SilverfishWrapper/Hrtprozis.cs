using System;
using System.Reflection;

namespace SilverfishWrapper;

public class Hrtprozis
{
	public object Inst;

	public static Type Type;

	private const BindingFlags AllFlags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

	public int pId
	{
		get
		{
			return (int)Type.GetField("pId", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("pId", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int attackFaceHp
	{
		get
		{
			return (int)Type.GetField("attackFaceHp", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("attackFaceHp", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
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

	public int ownHeroEntity
	{
		get
		{
			return (int)Type.GetField("ownHeroEntity", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownHeroEntity", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyHeroEntitiy
	{
		get
		{
			return (int)Type.GetField("enemyHeroEntitiy", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyHeroEntitiy", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public DateTime roundstart
	{
		get
		{
			return (DateTime)Type.GetField("roundstart", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("roundstart", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int currentMana
	{
		get
		{
			return (int)Type.GetField("currentMana", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("currentMana", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int heroHp
	{
		get
		{
			return (int)Type.GetField("heroHp", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("heroHp", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyHp
	{
		get
		{
			return (int)Type.GetField("enemyHp", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyHp", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int heroAtk
	{
		get
		{
			return (int)Type.GetField("heroAtk", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("heroAtk", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyAtk
	{
		get
		{
			return (int)Type.GetField("enemyAtk", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyAtk", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int heroDefence
	{
		get
		{
			return (int)Type.GetField("heroDefence", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("heroDefence", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyDefence
	{
		get
		{
			return (int)Type.GetField("enemyDefence", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyDefence", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool ownheroisread
	{
		get
		{
			return (bool)Type.GetField("ownheroisread", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownheroisread", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownHeroNumAttacksThisTurn
	{
		get
		{
			return (int)Type.GetField("ownHeroNumAttacksThisTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownHeroNumAttacksThisTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool ownHeroWindfury
	{
		get
		{
			return (bool)Type.GetField("ownHeroWindfury", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownHeroWindfury", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool herofrozen
	{
		get
		{
			return (bool)Type.GetField("herofrozen", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("herofrozen", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool enemyfrozen
	{
		get
		{
			return (bool)Type.GetField("enemyfrozen", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyfrozen", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object ownSecretList
	{
		get
		{
			return Type.GetField("ownSecretList", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownSecretList", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object ownAuraList
	{
		get
		{
			return Type.GetField("ownAuraList", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownAuraList", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
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

	public object DiscoverCards
	{
		get
		{
			return Type.GetField("DiscoverCards", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("DiscoverCards", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object turnDeck
	{
		get
		{
			return Type.GetField("turnDeck", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("turnDeck", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object deckCardForCost
	{
		get
		{
			return Type.GetField("deckCardForCost", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("deckCardForCost", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool noDuplicates
	{
		get
		{
			return (bool)Type.GetField("noDuplicates", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("noDuplicates", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
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

	public object ownStartingDeckCardCounts
	{
		get
		{
			return Type.GetField("ownStartingDeckCardCounts", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownStartingDeckCardCounts", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object ownSeenStartingDeckCardCopies
	{
		get
		{
			return Type.GetField("ownSeenStartingDeckCardCopies", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownSeenStartingDeckCardCopies", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object ownHandCardStartedInDeck
	{
		get
		{
			return Type.GetField("ownHandCardStartedInDeck", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownHandCardStartedInDeck", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object ownHandCardBaseIds
	{
		get
		{
			return Type.GetField("ownHandCardBaseIds", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownHandCardBaseIds", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object ownHandCardSpellDamageBonus
	{
		get
		{
			return Type.GetField("ownHandCardSpellDamageBonus", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownHandCardSpellDamageBonus", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object ownHandCardAttackBonus
	{
		get
		{
			return Type.GetField("ownHandCardAttackBonus", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownHandCardAttackBonus", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object ownHandCardHealthBonus
	{
		get
		{
			return Type.GetField("ownHandCardHealthBonus", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownHandCardHealthBonus", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object ownHandCardDiscovered
	{
		get
		{
			return Type.GetField("ownHandCardDiscovered", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownHandCardDiscovered", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object ownHandCardDiscoveredTurn
	{
		get
		{
			return Type.GetField("ownHandCardDiscoveredTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownHandCardDiscoveredTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object ownHandCardDiscoverFollowups
	{
		get
		{
			return Type.GetField("ownHandCardDiscoverFollowups", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownHandCardDiscoverFollowups", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object ownHandCardCostsHealthInsteadOfMana
	{
		get
		{
			return Type.GetField("ownHandCardCostsHealthInsteadOfMana", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownHandCardCostsHealthInsteadOfMana", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object ownHandCardJarStoredMinionIds
	{
		get
		{
			return Type.GetField("ownHandCardJarStoredMinionIds", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownHandCardJarStoredMinionIds", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object ownHandCardJarStoredMinionAttackBonuses
	{
		get
		{
			return Type.GetField("ownHandCardJarStoredMinionAttackBonuses", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownHandCardJarStoredMinionAttackBonuses", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object ownHandCardJarStoredMinionHealthBonuses
	{
		get
		{
			return Type.GetField("ownHandCardJarStoredMinionHealthBonuses", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownHandCardJarStoredMinionHealthBonuses", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool ownStartingDeckSnapshotReady
	{
		get
		{
			return (bool)Type.GetField("ownStartingDeckSnapshotReady", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownStartingDeckSnapshotReady", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int numTauntCards
	{
		get
		{
			return (int)Type.GetField("numTauntCards", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("numTauntCards", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int numDivineShieldCards
	{
		get
		{
			return (int)Type.GetField("numDivineShieldCards", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("numDivineShieldCards", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int numLifestealCards
	{
		get
		{
			return (int)Type.GetField("numLifestealCards", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("numLifestealCards", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int numWindfuryCards
	{
		get
		{
			return (int)Type.GetField("numWindfuryCards", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("numWindfuryCards", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int numSecretCards
	{
		get
		{
			return (int)Type.GetField("numSecretCards", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("numSecretCards", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool setGameRule
	{
		get
		{
			return (bool)Type.GetField("setGameRule", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("setGameRule", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public HeroEnum heroname
	{
		get
		{
			return ReflectionHelper.ConvertValue<HeroEnum>(Type.GetField("heroname", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst));
		}
		set
		{
			Type.GetField("heroname", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public HeroEnum enemyHeroname
	{
		get
		{
			return ReflectionHelper.ConvertValue<HeroEnum>(Type.GetField("enemyHeroname", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst));
		}
		set
		{
			Type.GetField("enemyHeroname", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public string heronameingame
	{
		get
		{
			return (string)Type.GetField("heronameingame", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("heronameingame", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public string enemyHeronameingame
	{
		get
		{
			return (string)Type.GetField("enemyHeronameingame", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyHeronameingame", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
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

	public int ownHeraldCount
	{
		get
		{
			return (int)Type.GetField("ownHeraldCount", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownHeraldCount", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyHeraldCount
	{
		get
		{
			return (int)Type.GetField("enemyHeraldCount", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyHeraldCount", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object heroAbility
	{
		get
		{
			return Type.GetField("heroAbility", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("heroAbility", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool ownAbilityisReady
	{
		get
		{
			return (bool)Type.GetField("ownAbilityisReady", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownAbilityisReady", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownHeroPowerCost
	{
		get
		{
			return (int)Type.GetField("ownHeroPowerCost", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownHeroPowerCost", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object enemyAbility
	{
		get
		{
			return Type.GetField("enemyAbility", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyAbility", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyHeroPowerCost
	{
		get
		{
			return (int)Type.GetField("enemyHeroPowerCost", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyHeroPowerCost", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
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

	public int numOptionsPlayedThisTurn
	{
		get
		{
			return (int)Type.GetField("numOptionsPlayedThisTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("numOptionsPlayedThisTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int numMinionsPlayedThisTurn
	{
		get
		{
			return (int)Type.GetField("numMinionsPlayedThisTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("numMinionsPlayedThisTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
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

	public object ownPlayer
	{
		get
		{
			return Type.GetField("ownPlayer", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownPlayer", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object enemyPlayer
	{
		get
		{
			return Type.GetField("enemyPlayer", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyPlayer", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
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

	public int ownElementalsHaveLifesteal
	{
		get
		{
			return (int)Type.GetField("ownElementalsHaveLifesteal", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownElementalsHaveLifesteal", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownPlayerController
	{
		get
		{
			return (int)Type.GetField("ownPlayerController", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownPlayerController", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
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

	public string enemyDeckName
	{
		get
		{
			return (string)Type.GetField("enemyDeckName", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyDeckName", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public string enemyDeckCode
	{
		get
		{
			return (string)Type.GetField("enemyDeckCode", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyDeckCode", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object guessEnemyDeck
	{
		get
		{
			return Type.GetField("guessEnemyDeck", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("guessEnemyDeck", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int enemyDirectDmg
	{
		get
		{
			return (int)Type.GetField("enemyDirectDmg", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enemyDirectDmg", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int similarity
	{
		get
		{
			return (int)Type.GetField("similarity", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("similarity", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownConsecutiveElementalTurns
	{
		get
		{
			return (int)Type.GetField("ownConsecutiveElementalTurns", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownConsecutiveElementalTurns", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int auraRoundCount
	{
		get
		{
			return (int)Type.GetField("auraRoundCount", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("auraRoundCount", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int ownElementalsPlayedLastTurn
	{
		get
		{
			return (int)Type.GetField("ownElementalsPlayedLastTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("ownElementalsPlayedLastTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
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

	public object lastNonRogueClassCardPlayed
	{
		get
		{
			return Type.GetField("lastNonRogueClassCardPlayed", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("lastNonRogueClassCardPlayed", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
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

	public bool playfieldPatchesInDeck
	{
		get
		{
			return (bool)Type.GetField("playfieldPatchesInDeck", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("playfieldPatchesInDeck", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object enchs
	{
		get
		{
			return Type.GetField("enchs", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("enchs", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
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

	public object cdb
	{
		get
		{
			return Type.GetField("cdb", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("cdb", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzOwnLifesteal
	{
		get
		{
			return (int)Type.GetField("anzOwnLifesteal", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzOwnLifesteal", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int anzEnemyLifesteal
	{
		get
		{
			return (int)Type.GetField("anzEnemyLifesteal", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("anzEnemyLifesteal", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
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

	public Hrtprozis(object inst)
	{
		Inst = inst;
	}

	public void setInstances()
	{
		Type[] types = new Type[0];
		Type.GetMethod("setInstances", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public void setAttackFaceHP(int hp)
	{
		Type[] types = new Type[1] { typeof(int) };
		Type.GetMethod("setAttackFaceHP", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { hp });
	}

	public int getPid()
	{
		Type[] types = new Type[0];
		return (int)Type.GetMethod("getPid", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public void clearAllNewGame()
	{
		Type[] types = new Type[0];
		Type.GetMethod("clearAllNewGame", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public void clearAllRecalc()
	{
		Type[] types = new Type[0];
		Type.GetMethod("clearAllRecalc", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public void setOwnPlayer(int controllerId)
	{
		Type[] types = new Type[1] { typeof(int) };
		Type.GetMethod("setOwnPlayer", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { controllerId });
	}

	public void setEnemyPlayer(int controllerId)
	{
		Type[] types = new Type[1] { typeof(int) };
		Type.GetMethod("setEnemyPlayer", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { controllerId });
	}

	public int getOwnController()
	{
		Type[] types = new Type[0];
		return (int)Type.GetMethod("getOwnController", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public void updateGlobalState(GlobalStateType type, int value)
	{
		Type[] types = new Type[2]
		{
			Type.Assembly.GetType("HREngine.Bots.GlobalStateType"),
			typeof(int)
		};
		Type.GetMethod("updateGlobalState", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { type, value });
	}

	public void updatePlayerAttachments(bool LothraxionsPower)
	{
		Type[] types = new Type[1] { typeof(bool) };
		Type.GetMethod("updatePlayerAttachments", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { LothraxionsPower });
	}

	public void updateJadeGolemsInfo(int anzOwnJG, int anzEmemyJG)
	{
		Type[] types = new Type[2]
		{
			typeof(int),
			typeof(int)
		};
		Type.GetMethod("updateJadeGolemsInfo", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { anzOwnJG, anzEmemyJG });
	}

	public void updateCrystalCore(int num)
	{
		Type[] types = new Type[1] { typeof(int) };
		Type.GetMethod("updateCrystalCore", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { num });
	}

	public void updateInfestor(int num)
	{
		Type[] types = new Type[1] { typeof(int) };
		Type.GetMethod("updateInfestor", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { num });
	}

	public void updateOwnMinionsInDeckCost0(bool tmp)
	{
		Type[] types = new Type[1] { typeof(bool) };
		Type.GetMethod("updateOwnMinionsInDeckCost0", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { tmp });
	}

	public void updateElementals(int anzOwnElemTT, int anzOwnElemLT, int ownElementalsHaveLS)
	{
		Type[] types = new Type[3]
		{
			typeof(int),
			typeof(int),
			typeof(int)
		};
		Type.GetMethod("updateElementals", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[3] { anzOwnElemTT, anzOwnElemLT, ownElementalsHaveLS });
	}

	public string heroIDtoName(string s)
	{
		Type[] types = new Type[1] { typeof(string) };
		return (string)Type.GetMethod("heroIDtoName", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { s });
	}

	public string heroPowerToName(string s)
	{
		Type[] types = new Type[1] { typeof(string) };
		return (string)Type.GetMethod("heroPowerToName", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { s });
	}

	public bool isBlessingHeroPower(cardIDEnum id)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.CardDB+cardIDEnum") };
		return (bool)Type.GetMethod("isBlessingHeroPower", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { id });
	}

	public HeroEnum heroNametoEnum(string s)
	{
		Type[] types = new Type[1] { typeof(string) };
		return ReflectionHelper.ConvertValue<HeroEnum>(Type.GetMethod("heroNametoEnum", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { s }));
	}

	public TAG_CLASS heroEnumtoTagClass(HeroEnum he)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.HeroEnum") };
		return ReflectionHelper.ConvertValue<TAG_CLASS>(Type.GetMethod("heroEnumtoTagClass", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { he }));
	}

	public HeroEnum heroTAG_CLASSstringToEnum(string s)
	{
		Type[] types = new Type[1] { typeof(string) };
		return ReflectionHelper.ConvertValue<HeroEnum>(Type.GetMethod("heroTAG_CLASSstringToEnum", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { s }));
	}

	public cardIDEnum getDeckCardsForCost(int cost)
	{
		Type[] types = new Type[1] { typeof(int) };
		return ReflectionHelper.ConvertValue<cardIDEnum>(Type.GetMethod("getDeckCardsForCost", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { cost }));
	}

	public int numDeckCardsByTag(GAME_TAGs tag)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.GAME_TAGs") };
		return (int)Type.GetMethod("numDeckCardsByTag", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { tag });
	}

	public void updatePlayer(int maxmana, int currentmana, int cardsplayedthisturn, int numMinionsplayed, int optionsPlayedThisTurn, int overload, int lockedmana, int heroentity, int enemyentity)
	{
		Type[] types = new Type[9]
		{
			typeof(int),
			typeof(int),
			typeof(int),
			typeof(int),
			typeof(int),
			typeof(int),
			typeof(int),
			typeof(int),
			typeof(int)
		};
		Type.GetMethod("updatePlayer", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[9] { maxmana, currentmana, cardsplayedthisturn, numMinionsplayed, optionsPlayedThisTurn, overload, lockedmana, heroentity, enemyentity });
	}

	public void updateCorpses(int corpseGained, int corpseUsed)
	{
		Type[] types = new Type[2]
		{
			typeof(int),
			typeof(int)
		};
		Type.GetMethod("updateCorpses", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { corpseGained, corpseUsed });
	}

	public void updateHeroStartClass(TAG_CLASS ownHSClass, TAG_CLASS enemyHSClass)
	{
		Type[] types = new Type[2]
		{
			Type.Assembly.GetType("HREngine.Bots.TAG_CLASS"),
			Type.Assembly.GetType("HREngine.Bots.TAG_CLASS")
		};
		Type.GetMethod("updateHeroStartClass", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { ownHSClass, enemyHSClass });
	}

	public void updateHero(object w, string heron, object ability, bool abrdy, int abCost, object hero, int enMaxMana)
	{
		Type[] types = new Type[7]
		{
			Type.Assembly.GetType("HREngine.Bots.Weapon"),
			typeof(string),
			Type.Assembly.GetType("HREngine.Bots.CardDB+Card"),
			typeof(bool),
			typeof(int),
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			typeof(int)
		};
		Type.GetMethod("updateHero", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[7] { w, heron, ability, abrdy, abCost, hero, enMaxMana });
	}

	public void updateTurnInfo(int turn, int step)
	{
		Type[] types = new Type[2]
		{
			typeof(int),
			typeof(int)
		};
		Type.GetMethod("updateTurnInfo", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { turn, step });
	}

	public void updateCThunInfo(int OgOwnCThunAngrBonus, int OgOwnCThunHpBonus, int OgOwnCThunTaunt)
	{
		Type[] types = new Type[3]
		{
			typeof(int),
			typeof(int),
			typeof(int)
		};
		Type.GetMethod("updateCThunInfo", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[3] { OgOwnCThunAngrBonus, OgOwnCThunHpBonus, OgOwnCThunTaunt });
	}

	public void updateFatigueStats(int ods, int ohf, int eds, int ehf)
	{
		Type[] types = new Type[4]
		{
			typeof(int),
			typeof(int),
			typeof(int),
			typeof(int)
		};
		Type.GetMethod("updateFatigueStats", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[4] { ods, ohf, eds, ehf });
	}

	public void updatePositions()
	{
		Type[] types = new Type[0];
		Type.GetMethod("updatePositions", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public void updateOwnLastDiedMinion(cardIDEnum cid)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.CardDB+cardIDEnum") };
		Type.GetMethod("updateOwnLastDiedMinion", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { cid });
	}

	public object createNewMinion(object hc, int id)
	{
		Type[] types = new Type[2]
		{
			Type.Assembly.GetType("HREngine.Bots.Handmanager+Handcard"),
			typeof(int)
		};
		return Type.GetMethod("createNewMinion", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { hc, id });
	}

	public void printHero()
	{
		Type[] types = new Type[0];
		Type.GetMethod("printHero", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public void printOwnMinions()
	{
		Type[] types = new Type[0];
		Type.GetMethod("printOwnMinions", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public void printEnemyMinions()
	{
		Type[] types = new Type[0];
		Type.GetMethod("printEnemyMinions", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public void printOwnDeck()
	{
		Type[] types = new Type[0];
		Type.GetMethod("printOwnDeck", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}
}
