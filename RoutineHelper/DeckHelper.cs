using System;
using System.Collections.Generic;
using System.Linq;
using SilverfishWrapper;

namespace RoutineHelper;

public class DeckHelper
{
	public static List<Card> Deserialize(string input)
	{
		List<Card> list = null;
		IEnumerable<string> enumerable = from x in input.Split('\n')
			select x.Trim();
		string text = null;
		string text2 = null;
		foreach (string item in enumerable)
		{
			if (string.IsNullOrEmpty(item))
			{
				continue;
			}
			if (item.StartsWith("#"))
			{
				if (item.StartsWith("###"))
				{
					text = item.Substring(3).Trim();
				}
				if (item.StartsWith("# Deck ID:"))
				{
					text2 = item.Substring(10).Trim();
				}
			}
			else if (list == null)
			{
				list = DeserializeDeckString(item);
			}
		}
		return list;
	}

	private static List<Card> DeserializeDeckString(string deckString)
	{
		List<Card> deck = new List<Card>();
		byte[] bytes;
		try
		{
			bytes = Convert.FromBase64String(deckString);
		}
		catch (Exception innerException)
		{
			throw new ArgumentException("Input is not a valid deck string.", innerException);
		}
		int offset = 0;
		offset++;
		Read();
		Read();
		Read();
		Read();
		int num = (int)Read();
		for (int i = 0; i < num; i++)
		{
			AddCard();
		}
		int num2 = (int)Read();
		for (int j = 0; j < num2; j++)
		{
			AddCard(null, 2);
		}
		int num3 = (int)Read();
		for (int k = 0; k < num3; k++)
		{
			int value = (int)Read();
			int count = (int)Read();
			AddCard(value, count);
		}
		return deck;
		void AddCard(int? dbfId = null, int count2 = 1)
		{
			dbfId = dbfId ?? ((int)Read());
			CardDB cardDB = new CardDB(CardDB.Instance);
			Card item = new Card(cardDB.getCardDataFromDbfID(dbfId.ToString()))
			{
				count = count2
			};
			deck.Add(item);
		}
		ulong Read()
		{
			if (offset > bytes.Length)
			{
				throw new ArgumentException("Input is not a valid deck string.");
			}
			int length;
			ulong result = VarInt.ReadNext(bytes.Skip(offset).ToArray(), out length);
			offset += length;
			return result;
		}
	}

	private static string TitleCase(string str)
	{
		if (string.IsNullOrEmpty(str))
		{
			return string.Empty;
		}
		if (str.Length == 1)
		{
			return str.ToUpperInvariant();
		}
		return str.Substring(0, 1).ToUpperInvariant() + str.Substring(1, str.Length - 1).ToLowerInvariant();
	}
}
