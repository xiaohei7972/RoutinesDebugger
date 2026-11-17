using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using SilverfishWrapper;

namespace RoutineHelper;

internal class PlayfieldSerializer
{
	private static PlayfieldSerializer playfieldSerializer;

	public static PlayfieldSerializer Instance
	{
		get
		{
			if (playfieldSerializer == null)
			{
				playfieldSerializer = new PlayfieldSerializer();
			}
			return playfieldSerializer;
		}
	}

	public List<string> SerializeObject(object self, List<string> serialized)
	{
		List<string> list = (from field in self.GetType().GetFields()
			where field.FieldType == typeof(bool) || field.FieldType == typeof(int) || field.FieldType == typeof(TAG_CLASS)
			select Convert.ToInt32(field.GetValue(self)).ToString()).ToList();
		foreach (string item in list)
		{
			serialized.Add(item);
		}
		if (self.GetType().Name == "Minion")
		{
			Minion minion = new Minion(self);
			Handcard handcard = new Handcard(minion.handcard);
			Card card = new Card(handcard.card);
			serialized.Add(((int)minion.cardClass).ToString());
			if (handcard.card != null && card.textCN.Length > 0)
			{
				serialized.Add(Regex.Replace(card.textCN, "\\t|\\n|\\r", ""));
			}
			else
			{
				serialized.Add("空");
			}
			if (handcard.card != null)
			{
				serialized.Add(((int)card.race).ToString());
			}
			else
			{
				serialized.Add("0");
			}
		}
		if (self.GetType().Name == "Handcard")
		{
			Handcard handcard2 = new Handcard(self);
			Card card2 = new Card(handcard2.card);
			if (handcard2.card != null && card2.textCN.Length > 0)
			{
				serialized.Add(Regex.Replace(card2.textCN, "\\t|\\n|\\r", ""));
			}
			else
			{
				serialized.Add("空");
			}
			if (handcard2.card != null)
			{
				serialized.Add(((int)card2.race).ToString());
			}
			else
			{
				serialized.Add("0");
			}
		}
		return serialized;
	}

	public string SerializePlayfield(Playfield playfield)
	{
		List<string> serialized = new List<string>();
		serialized = SerializeObject(playfield, serialized);
		serialized = SerializeObject(playfield.ownHero, serialized);
		serialized = SerializeObject(playfield.ownWeapon, serialized);
		serialized = SerializeObject(playfield.ownQuest, serialized);
		for (int i = 0; i < 7; i++)
		{
			serialized = ((i >= playfield.ownMinions.ReflectionCall<int>("get_Count", Array.Empty<object>())) ? SerializeObject(Activator.CreateInstance(MainWindow.compiledRoutines.GetType("HREngine.Bots.Minion")), serialized) : SerializeObject(playfield.ownMinions.ReflectionCall<object>("get_Item", new object[1] { i }), serialized));
		}
		CardDB cardDB = new CardDB(CardDB.Instance);
		for (int j = 0; j < 5; j++)
		{
			serialized = ((j >= playfield.ownSecretsIDList.ReflectionCall<int>("get_Count", Array.Empty<object>())) ? SerializeObject(cardDB.unknownCard, serialized) : SerializeObject(cardDB.getCardDataFromID(playfield.ownSecretsIDList.ReflectionCall<cardIDEnum>("get_Item", new object[1] { j })), serialized));
		}
		serialized = SerializeObject(playfield.enemyHero, serialized);
		serialized = SerializeObject(playfield.enemyWeapon, serialized);
		serialized = SerializeObject(playfield.enemyQuest, serialized);
		for (int k = 0; k < 7; k++)
		{
			serialized = ((k >= playfield.enemyMinions.ReflectionCall<int>("get_Count", Array.Empty<object>())) ? SerializeObject(Activator.CreateInstance(MainWindow.compiledRoutines.GetType("HREngine.Bots.Minion")), serialized) : SerializeObject(playfield.enemyMinions.ReflectionCall<object>("get_Item", new object[1] { k }), serialized));
		}
		for (int l = 0; l < 5; l++)
		{
			serialized = ((l >= playfield.enemySecretList.ReflectionCall<int>("get_Count", Array.Empty<object>())) ? SerializeObject(Activator.CreateInstance(MainWindow.compiledRoutines.GetType("HREngine.Bots.SecretItem")), serialized) : SerializeObject(playfield.enemySecretList.ReflectionCall<object>("get_Item", new object[1] { l }), serialized));
		}
		for (int m = 0; m < 10; m++)
		{
			serialized = ((m >= playfield.owncards.ReflectionCall<int>("get_Count", Array.Empty<object>())) ? SerializeObject(Activator.CreateInstance(MainWindow.compiledRoutines.GetType("HREngine.Bots.Handmanager+Handcard")), serialized) : SerializeObject(playfield.owncards.ReflectionCall<object>("get_Item", new object[1] { m }), serialized));
		}
		for (int n = 0; n < 10; n++)
		{
			if (n < playfield.playactions.ReflectionCall<int>("get_Count", Array.Empty<object>()))
			{
				serialized.Add(((int)new SilverfishWrapper.Action(playfield.playactions.ReflectionCall<object>("get_Item", new object[1] { n })).actionType).ToString());
			}
			else
			{
				serialized.Add("0");
			}
		}
		return string.Join(",", serialized);
	}
}
