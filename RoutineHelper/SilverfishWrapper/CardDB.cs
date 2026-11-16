using System;
using System.Reflection;

namespace SilverfishWrapper;

public class CardDB
{
	public object Inst;

	public static Type Type;

	private const BindingFlags AllFlags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

	public object AllCards
	{
		get
		{
			return Type.GetField("AllCards", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("AllCards", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object cardlist
	{
		get
		{
			return Type.GetField("cardlist", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("cardlist", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object cardidToCardList
	{
		get
		{
			return Type.GetField("cardidToCardList", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("cardidToCardList", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object carddbfidToCardList
	{
		get
		{
			return Type.GetField("carddbfidToCardList", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("carddbfidToCardList", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object cardNameCNToCardList
	{
		get
		{
			return Type.GetField("cardNameCNToCardList", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("cardNameCNToCardList", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object cardNameENToCardList
	{
		get
		{
			return Type.GetField("cardNameENToCardList", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("cardNameENToCardList", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object unknownCard
	{
		get
		{
			return Type.GetField("unknownCard", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("unknownCard", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool installedWrong
	{
		get
		{
			return (bool)Type.GetField("installedWrong", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("installedWrong", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object burlyrockjaw
	{
		get
		{
			return Type.GetField("burlyrockjaw", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("burlyrockjaw", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object treasurePools
	{
		get
		{
			return Type.GetField("treasurePools", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("treasurePools", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public static object Log
	{
		get
		{
			return Type.GetField("Log", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(null);
		}
		set
		{
			Type.GetField("Log", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetValue(null, value);
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

	public static object raceMapping
	{
		get
		{
			return Type.GetField("raceMapping", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(null);
		}
		set
		{
			Type.GetField("raceMapping", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetValue(null, value);
		}
	}

	public object cards
	{
		get
		{
			return Type.GetProperty("cards", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetProperty("cards", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public static object Instance => Type.GetProperty("Instance", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(null);

	public CardDB(object inst)
	{
		Inst = inst;
	}

	public object chnNameToCard(string chnName)
	{
		Type[] types = new Type[1] { typeof(string) };
		return Type.GetMethod("chnNameToCard", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { chnName });
	}

	public cardIDEnum cardIdstringToEnum(string s)
	{
		Type[] types = new Type[1] { typeof(string) };
		return ReflectionHelper.ConvertValue<cardIDEnum>(Type.GetMethod("cardIdstringToEnum", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { s }));
	}

	public cardNameEN cardNameENstringToEnum(string s)
	{
		Type[] types = new Type[1] { typeof(string) };
		return ReflectionHelper.ConvertValue<cardNameEN>(Type.GetMethod("cardNameENstringToEnum", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { s }));
	}

	public cardNameCN cardNameENstringToEnumCN(string s)
	{
		Type[] types = new Type[1] { typeof(string) };
		return ReflectionHelper.ConvertValue<cardNameCN>(Type.GetMethod("cardNameENstringToEnumCN", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { s }));
	}

	public cardNameCN cardNameCNstringToEnum(string s)
	{
		Type[] types = new Type[1] { typeof(string) };
		return ReflectionHelper.ConvertValue<cardNameCN>(Type.GetMethod("cardNameCNstringToEnum", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { s }));
	}

	public Race raceNameStringToEnum(string s)
	{
		Type[] types = new Type[1] { typeof(string) };
		return ReflectionHelper.ConvertValue<Race>(Type.GetMethod("raceNameStringToEnum", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { s }));
	}

	public SpellSchool spellSchoolNameStringToEnum(string s)
	{
		Type[] types = new Type[1] { typeof(string) };
		return ReflectionHelper.ConvertValue<SpellSchool>(Type.GetMethod("spellSchoolNameStringToEnum", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { s }));
	}

	public int getRequiredTargetCount(object card)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.CardDB+Card") };
		return (int)Type.GetMethod("getRequiredTargetCount", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { card });
	}

	public object GetAllCards()
	{
		Type[] types = new Type[0];
		return Type.GetMethod("GetAllCards", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public object GetCardByName(string cardName)
	{
		Type[] types = new Type[1] { typeof(string) };
		return Type.GetMethod("GetCardByName", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { cardName });
	}

	public object GetAllDeathrattleCards()
	{
		Type[] types = new Type[0];
		return Type.GetMethod("GetAllDeathrattleCards", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public object GetMageSpells()
	{
		Type[] types = new Type[0];
		return Type.GetMethod("GetMageSpells", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public object GetAllSpells()
	{
		Type[] types = new Type[0];
		return Type.GetMethod("GetAllSpells", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public object GetAllMinions()
	{
		Type[] types = new Type[0];
		return Type.GetMethod("GetAllMinions", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public object getCostMinions(int cost)
	{
		Type[] types = new Type[1] { typeof(int) };
		return Type.GetMethod("getCostMinions", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { cost });
	}

	public object getAllWeapons()
	{
		Type[] types = new Type[0];
		return Type.GetMethod("getAllWeapons", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public object getCardData(cardNameEN cardname)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.CardDB+cardNameEN") };
		return Type.GetMethod("getCardData", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { cardname });
	}

	public object getCardData(cardNameCN cardname)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.CardDB+cardNameCN") };
		return Type.GetMethod("getCardData", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { cardname });
	}

	public object getCardDataFromID(cardIDEnum id)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.CardDB+cardIDEnum") };
		return Type.GetMethod("getCardDataFromID", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { id });
	}

	public object getCardDataFromDbfID(string dbfID)
	{
		Type[] types = new Type[1] { typeof(string) };
		return Type.GetMethod("getCardDataFromDbfID", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { dbfID });
	}

	public void setAdditionalData()
	{
		Type[] types = new Type[0];
		Type.GetMethod("setAdditionalData", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public void setupShatterData()
	{
		Type[] types = new Type[0];
		Type.GetMethod("setupShatterData", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public void setupShatterCard(cardIDEnum main, cardIDEnum left, cardIDEnum right)
	{
		Type[] types = new Type[3]
		{
			Type.Assembly.GetType("HREngine.Bots.CardDB+cardIDEnum"),
			Type.Assembly.GetType("HREngine.Bots.CardDB+cardIDEnum"),
			Type.Assembly.GetType("HREngine.Bots.CardDB+cardIDEnum")
		};
		Type.GetMethod("setupShatterCard", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[3] { main, left, right });
	}
}
