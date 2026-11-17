using System;
using System.Reflection;

namespace SilverfishWrapper;

public class QuestItem
{
	public object Inst;

	public static Type Type;

	private const BindingFlags AllFlags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

	public object mobsTurn
	{
		get
		{
			return Type.GetField("mobsTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("mobsTurn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public cardIDEnum Id
	{
		get
		{
			return ReflectionHelper.ConvertValue<cardIDEnum>(Type.GetField("Id", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst));
		}
		set
		{
			Type.GetField("Id", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int questProgress
	{
		get
		{
			return (int)Type.GetField("questProgress", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("questProgress", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int maxProgress
	{
		get
		{
			return (int)Type.GetField("maxProgress", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("maxProgress", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object uniqueMinionTypesPlayed
	{
		get
		{
			return Type.GetField("uniqueMinionTypesPlayed", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("uniqueMinionTypesPlayed", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object questAttackValuesPlayed
	{
		get
		{
			return Type.GetField("questAttackValuesPlayed", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("questAttackValuesPlayed", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public QuestItem(object inst)
	{
		Inst = inst;
	}

	public void Copy(object q)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Questmanager+QuestItem") };
		Type.GetMethod("Copy", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { q });
	}

	public void Reset()
	{
		Type[] types = new Type[0];
		Type.GetMethod("Reset", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public static bool IsTrackableUniqueRace(Race race)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.CardDB+Race") };
		return (bool)Type.GetMethod("IsTrackableUniqueRace", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).Invoke(null, new object[1] { race });
	}

	public void trigger_MinionWasPlayed(object m)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Minion") };
		Type.GetMethod("trigger_MinionWasPlayed", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { m });
	}

	public void trigger_MinionWasSummoned(object m)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.Minion") };
		Type.GetMethod("trigger_MinionWasSummoned", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { m });
	}

	public void trigger_SpellWasPlayed(object target, int qId)
	{
		Type[] types = new Type[2]
		{
			Type.Assembly.GetType("HREngine.Bots.Minion"),
			typeof(int)
		};
		Type.GetMethod("trigger_SpellWasPlayed", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { target, qId });
	}

	public void trigger_WasDiscard(int num)
	{
		Type[] types = new Type[1] { typeof(int) };
		Type.GetMethod("trigger_WasDiscard", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { num });
	}

	public cardIDEnum Reward()
	{
		Type[] types = new Type[0];
		return ReflectionHelper.ConvertValue<cardIDEnum>(Type.GetMethod("Reward", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]));
	}
}
