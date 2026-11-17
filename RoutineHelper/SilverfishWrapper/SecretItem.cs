using System;
using System.Reflection;

namespace SilverfishWrapper;

public class SecretItem
{
	public object Inst;

	public static Type Type;

	private const BindingFlags AllFlags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

	public bool triggered
	{
		get
		{
			return (bool)Type.GetField("triggered", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("triggered", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public object data
	{
		get
		{
			return Type.GetField("data", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("data", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool canBe_snaketrap
	{
		get
		{
			return (bool)Type.GetField("canBe_snaketrap", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("canBe_snaketrap", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool canBe_snipe
	{
		get
		{
			return (bool)Type.GetField("canBe_snipe", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("canBe_snipe", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool canBe_explosive
	{
		get
		{
			return (bool)Type.GetField("canBe_explosive", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("canBe_explosive", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool canBe_beartrap
	{
		get
		{
			return (bool)Type.GetField("canBe_beartrap", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("canBe_beartrap", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool canBe_freezing
	{
		get
		{
			return (bool)Type.GetField("canBe_freezing", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("canBe_freezing", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool canBe_missdirection
	{
		get
		{
			return (bool)Type.GetField("canBe_missdirection", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("canBe_missdirection", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool canBe_darttrap
	{
		get
		{
			return (bool)Type.GetField("canBe_darttrap", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("canBe_darttrap", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool canBe_cattrick
	{
		get
		{
			return (bool)Type.GetField("canBe_cattrick", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("canBe_cattrick", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool canBe_counterspell
	{
		get
		{
			return (bool)Type.GetField("canBe_counterspell", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("canBe_counterspell", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool canBe_icebarrier
	{
		get
		{
			return (bool)Type.GetField("canBe_icebarrier", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("canBe_icebarrier", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool canBe_iceblock
	{
		get
		{
			return (bool)Type.GetField("canBe_iceblock", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("canBe_iceblock", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool canBe_mirrorentity
	{
		get
		{
			return (bool)Type.GetField("canBe_mirrorentity", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("canBe_mirrorentity", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool canBe_spellbender
	{
		get
		{
			return (bool)Type.GetField("canBe_spellbender", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("canBe_spellbender", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool canBe_vaporize
	{
		get
		{
			return (bool)Type.GetField("canBe_vaporize", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("canBe_vaporize", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool canBe_duplicate
	{
		get
		{
			return (bool)Type.GetField("canBe_duplicate", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("canBe_duplicate", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool canBe_effigy
	{
		get
		{
			return (bool)Type.GetField("canBe_effigy", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("canBe_effigy", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool canBe_flameward
	{
		get
		{
			return (bool)Type.GetField("canBe_flameward", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("canBe_flameward", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool canBe_explosiverunes
	{
		get
		{
			return (bool)Type.GetField("canBe_explosiverunes", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("canBe_explosiverunes", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool canBe_eyeforaneye
	{
		get
		{
			return (bool)Type.GetField("canBe_eyeforaneye", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("canBe_eyeforaneye", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool canBe_noblesacrifice
	{
		get
		{
			return (bool)Type.GetField("canBe_noblesacrifice", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("canBe_noblesacrifice", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool canBe_redemption
	{
		get
		{
			return (bool)Type.GetField("canBe_redemption", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("canBe_redemption", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool canBe_repentance
	{
		get
		{
			return (bool)Type.GetField("canBe_repentance", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("canBe_repentance", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool canBe_avenge
	{
		get
		{
			return (bool)Type.GetField("canBe_avenge", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("canBe_avenge", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public bool canBe_sacredtrial
	{
		get
		{
			return (bool)Type.GetField("canBe_sacredtrial", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("canBe_sacredtrial", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public int entityId
	{
		get
		{
			return (int)Type.GetField("entityId", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Inst);
		}
		set
		{
			Type.GetField("entityId", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetCompatibleValue(Inst, value);
		}
	}

	public SecretItem(object inst)
	{
		Inst = inst;
	}

	public static object dataToSecretItem(object ba)
	{
		Type[] types = new Type[1] { typeof(object) };
		return Type.GetMethod("dataToSecretItem", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).Invoke(null, new object[1] { ba });
	}

	public static object secretItemToData(object si)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.SecretItem") };
		return Type.GetMethod("secretItemToData", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).Invoke(null, new object[1] { si });
	}

	public void updateCanBeTriggered()
	{
		Type[] types = new Type[0];
		Type.GetMethod("updateCanBeTriggered", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public void usedTrigger_CharIsAttacked(bool DefenderIsHero, bool AttackerIsHero)
	{
		Type[] types = new Type[2]
		{
			typeof(bool),
			typeof(bool)
		};
		Type.GetMethod("usedTrigger_CharIsAttacked", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[2] { DefenderIsHero, AttackerIsHero });
	}

	public void usedTrigger_MinionIsPlayed(int i)
	{
		Type[] types = new Type[1] { typeof(int) };
		Type.GetMethod("usedTrigger_MinionIsPlayed", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { i });
	}

	public void usedTrigger_SpellIsPlayed(bool minionIsTarget)
	{
		Type[] types = new Type[1] { typeof(bool) };
		Type.GetMethod("usedTrigger_SpellIsPlayed", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { minionIsTarget });
	}

	public void usedTrigger_MinionDied()
	{
		Type[] types = new Type[0];
		Type.GetMethod("usedTrigger_MinionDied", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public void usedTrigger_HeroGotDmg(bool deadly)
	{
		Type[] types = new Type[1] { typeof(bool) };
		Type.GetMethod("usedTrigger_HeroGotDmg", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { deadly });
	}

	public void usedTrigger_HeroPowerUsed()
	{
		Type[] types = new Type[0];
		Type.GetMethod("usedTrigger_HeroPowerUsed", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public string returnAString()
	{
		Type[] types = new Type[0];
		return (string)Type.GetMethod("returnAString", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}

	public bool isEqual(object s)
	{
		Type[] types = new Type[1] { Type.Assembly.GetType("HREngine.Bots.SecretItem") };
		return (bool)Type.GetMethod("isEqual", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[1] { s });
	}
}
