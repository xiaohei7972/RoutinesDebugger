using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using SilverfishWrapper;

namespace RoutineHelper;

internal static class BoardTesterInputCompat
{
	private enum SnapshotZone
	{
		None,
		Board,
		Hand,
		Quests,
		Graveyard
	}

	private sealed class SnapshotBoard
	{
		public int Turn { get; set; }

		public int Step { get; set; }

		public SnapshotSide Friendly { get; private set; }

		public SnapshotSide Opposing { get; private set; }

		public bool IsValid => Friendly.Hero != null && Opposing.Hero != null;

		public SnapshotBoard()
		{
			Friendly = new SnapshotSide();
			Opposing = new SnapshotSide();
		}
	}

	private sealed class SnapshotSide
	{
		public int Controller { get; set; }

		public string Class { get; set; }

		public int Fatigue { get; set; }

		public int Resources { get; set; }

		public int Used { get; set; }

		public int Temp { get; set; }

		public int OverloadLocked { get; set; }

		public int OverloadOwed { get; set; }

		public int DeckCount { get; set; }

		public int SecretCount { get; set; }

		public SnapshotEntity Hero { get; set; }

		public SnapshotEntity HeroPower { get; set; }

		public SnapshotEntity Weapon { get; set; }

		public List<SnapshotEntity> Board { get; private set; }

		public List<SnapshotEntity> Hand { get; private set; }

		public List<SnapshotQuest> Quests { get; private set; }

		public Dictionary<string, int> GraveyardCounts { get; private set; }

		public SnapshotSide()
		{
			Board = new List<SnapshotEntity>();
			Hand = new List<SnapshotEntity>();
			Quests = new List<SnapshotQuest>();
			GraveyardCounts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
		}
	}

	private sealed class SnapshotEntity
	{
		public int EntityId { get; set; }

		public string CardId { get; set; }

		public string Name { get; set; }

		public string Type { get; set; }

		public string Class { get; set; }

		public int Cost { get; set; }

		public int Attack { get; set; }

		public int Health { get; set; }

		public int MaxHealth { get; set; }

		public int Armor { get; set; }

		public int ZonePos { get; set; }

		public int Controller { get; set; }

		public int Creator { get; set; }

		public Dictionary<string, int> Tags { get; private set; }

		public List<string> Enchantments { get; private set; }

		public SnapshotEntity()
		{
			Tags = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
			Enchantments = new List<string>();
		}
	}

	private sealed class SnapshotQuest
	{
		public string CardId { get; set; }

		public int Progress { get; set; }

		public int Maximum { get; set; }

		public bool IsQuest { get; set; }
	}

	private struct CardBaseStats
	{
		public int Attack;

		public int Health;
	}

	private const string EntitySnapshotBeginMarker = "### ENTITY_SNAPSHOT_BEGIN ###";

	private const string EntitySnapshotEndMarker = "### ENTITY_SNAPSHOT_END ###";

	internal static string PrepareForBoardTester(string rawInput)
	{
        return Regex.Replace(NormalizeLegacyMinions(PrepareBoardText(rawInput)), @"(?m)^pos[ \t]+[^\r\n]+", match =>
        {
            List<string> fields = Regex.Split(match.Value.Trim(), @"[ \t]+").ToList();
            if (fields.Count < 7)
                return match.Value;

            // Older logs omit attack, health, highlight and modular-card fields.
            while (fields.Count < 10)
                fields.Add("0");

            if (fields.Count < 12 || !int.TryParse(fields[10], out _) || !int.TryParse(fields[11], out _))
                fields.InsertRange(10, new[] { "0", "0" });

            return string.Join(" ", fields);
        });
	}

    private static string NormalizeLegacyMinions(string text)
    {
        return Regex.Replace(text, @"(?m)^(?<name>[^\r\n]+?)\s+\((?<stats>-?\d+/-?\d+)\)\s+(?<position>\d+)\s+zp:[ \t]+(?<rest>e:[^\r\n]+)", match =>
        {
            string name = match.Groups["name"].Value.Trim();
            var database = new CardDB(CardDB.Instance);
            var card = new Card(database.getCardData(database.cardNameCNstringToEnum(name)));
            if (card.cardIDenum == cardIDEnum.None)
                throw new FormatException("旧局面记录缺少卡牌 ID，无法解析随从 " + name);
            string rest = Regex.Replace(match.Groups["rest"].Value.Replace(" rey:", " rdy:"), @"\b(e|A|H|mH|rdy|natt):[ \t]+", "$1:");
            return name.Replace(" ", "") + "(" + match.Groups["stats"].Value + ") " + card.cardIDenum +
                " zp:" + match.Groups["position"].Value + " " + rest;
        });
    }

	private static string PrepareBoardText(string rawInput)
	{
		if (string.IsNullOrWhiteSpace(rawInput))
		{
			return string.Empty;
		}
		string text = ExtractMarkedSection(rawInput, "### ENTITY_SNAPSHOT_BEGIN ###", "### ENTITY_SNAPSHOT_END ###");
		bool flag = false;
		if (string.IsNullOrWhiteSpace(text) && LooksLikeEntitySnapshot(rawInput))
		{
			text = rawInput.Trim();
			flag = true;
		}
		string text2 = (flag ? string.Empty : RemoveMarkedSection(rawInput, "### ENTITY_SNAPSHOT_BEGIN ###", "### ENTITY_SNAPSHOT_END ###"));
		if (ContainsLegacyBoardTesterPayload(text2))
		{
			return text2.Trim();
		}
		SnapshotBoard snapshotBoard = ParseEntitySnapshot(text);
		if (snapshotBoard == null || !snapshotBoard.IsValid)
		{
			return text2.Trim();
		}
		string text3 = BuildLegacyBoardTesterText(snapshotBoard);
		if (string.IsNullOrWhiteSpace(text3))
		{
			return text2.Trim();
		}
		if (string.IsNullOrWhiteSpace(text2))
		{
			return text3;
		}
		return text3 + Environment.NewLine + Environment.NewLine + text2.Trim();
	}

	private static bool ContainsLegacyBoardTesterPayload(string content)
	{
		if (string.IsNullOrWhiteSpace(content))
		{
			return false;
		}
		return content.IndexOf("player:", StringComparison.OrdinalIgnoreCase) >= 0 && content.IndexOf("ownhero:", StringComparison.OrdinalIgnoreCase) >= 0 && content.IndexOf("enemyhero:", StringComparison.OrdinalIgnoreCase) >= 0 && content.IndexOf("OwnMinions:", StringComparison.OrdinalIgnoreCase) >= 0 && content.IndexOf("Own Handcards:", StringComparison.OrdinalIgnoreCase) >= 0;
	}

	private static bool LooksLikeEntitySnapshot(string content)
	{
		if (string.IsNullOrWhiteSpace(content))
		{
			return false;
		}
		return content.IndexOf("[Friendly]", StringComparison.OrdinalIgnoreCase) >= 0 && content.IndexOf("[Opposing]", StringComparison.OrdinalIgnoreCase) >= 0 && content.IndexOf("hero:", StringComparison.OrdinalIgnoreCase) >= 0 && content.IndexOf("board: count=", StringComparison.OrdinalIgnoreCase) >= 0;
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

	private static SnapshotBoard ParseEntitySnapshot(string entitySnapshot)
	{
		if (string.IsNullOrWhiteSpace(entitySnapshot))
		{
			return null;
		}
		SnapshotBoard snapshotBoard = new SnapshotBoard();
		SnapshotSide snapshotSide = null;
		SnapshotZone snapshotZone = SnapshotZone.None;
		SnapshotEntity snapshotEntity = null;
		string[] array = entitySnapshot.Split(new string[2] { "\r\n", "\n" }, StringSplitOptions.None);
		string[] array2 = array;
		foreach (string text in array2)
		{
			string text2 = ((text == null) ? string.Empty : text.Trim());
			if (string.IsNullOrWhiteSpace(text2))
			{
				continue;
			}
			if (text2.StartsWith("turn=", StringComparison.OrdinalIgnoreCase))
			{
				ParseTurnLine(snapshotBoard, text2);
			}
			else if (string.Equals(text2, "[Friendly]", StringComparison.OrdinalIgnoreCase))
			{
				snapshotSide = snapshotBoard.Friendly;
				snapshotZone = SnapshotZone.None;
				snapshotEntity = null;
			}
			else if (string.Equals(text2, "[Opposing]", StringComparison.OrdinalIgnoreCase))
			{
				snapshotSide = snapshotBoard.Opposing;
				snapshotZone = SnapshotZone.None;
				snapshotEntity = null;
			}
			else if (string.Equals(text2, "[ResolvedBoard]", StringComparison.OrdinalIgnoreCase))
			{
				snapshotSide = null;
				snapshotZone = SnapshotZone.None;
				snapshotEntity = null;
			}
			else
			{
				if (snapshotSide == null)
				{
					continue;
				}
				if (text2.StartsWith("controller=", StringComparison.OrdinalIgnoreCase))
				{
					ParseControllerLine(snapshotSide, text2);
					snapshotZone = SnapshotZone.None;
					snapshotEntity = null;
					continue;
				}
				if (text2.StartsWith("hero:", StringComparison.OrdinalIgnoreCase))
				{
					snapshotSide.Hero = ParseEntityLine(text2);
					snapshotEntity = snapshotSide.Hero;
					snapshotZone = SnapshotZone.None;
					continue;
				}
				if (text2.StartsWith("heroPower:", StringComparison.OrdinalIgnoreCase))
				{
					snapshotSide.HeroPower = ParseEntityLine(text2);
					snapshotEntity = snapshotSide.HeroPower;
					snapshotZone = SnapshotZone.None;
					continue;
				}
				if (text2.StartsWith("weapon:", StringComparison.OrdinalIgnoreCase))
				{
					snapshotSide.Weapon = ParseWeaponLine(text2);
					snapshotEntity = snapshotSide.Weapon;
					snapshotZone = SnapshotZone.None;
					continue;
				}
				if (text2.StartsWith("board:", StringComparison.OrdinalIgnoreCase))
				{
					snapshotZone = SnapshotZone.Board;
					snapshotEntity = null;
					continue;
				}
				if (text2.StartsWith("hand:", StringComparison.OrdinalIgnoreCase))
				{
					snapshotZone = SnapshotZone.Hand;
					snapshotEntity = null;
					continue;
				}
				if (text2.StartsWith("quests:", StringComparison.OrdinalIgnoreCase))
				{
					snapshotZone = SnapshotZone.Quests;
					snapshotEntity = null;
					continue;
				}
				if (text2.StartsWith("graveyard:", StringComparison.OrdinalIgnoreCase))
				{
					snapshotZone = SnapshotZone.Graveyard;
					snapshotEntity = null;
					continue;
				}
				if (text2.StartsWith("deck:", StringComparison.OrdinalIgnoreCase) || text2.StartsWith("secrets:", StringComparison.OrdinalIgnoreCase))
				{
					snapshotZone = SnapshotZone.None;
					snapshotEntity = null;
					continue;
				}
				if (text2.StartsWith("tags=", StringComparison.OrdinalIgnoreCase) && snapshotEntity != null)
				{
					ParseTags(snapshotEntity, text2.Substring("tags=".Length));
					continue;
				}
				if (text2.StartsWith("enchantments=", StringComparison.OrdinalIgnoreCase) && snapshotEntity != null)
				{
					ParseEnchantments(snapshotEntity, text2.Substring("enchantments=".Length));
					continue;
				}
				switch (snapshotZone)
				{
				case SnapshotZone.Board:
				{
					SnapshotEntity snapshotEntity2 = ParseIndexedEntityLine(text2);
					if (snapshotEntity2 != null)
					{
						snapshotSide.Board.Add(snapshotEntity2);
						snapshotEntity = snapshotEntity2;
					}
					break;
				}
				case SnapshotZone.Hand:
				{
					SnapshotEntity snapshotEntity3 = ParseIndexedEntityLine(text2);
					if (snapshotEntity3 != null)
					{
						snapshotSide.Hand.Add(snapshotEntity3);
						snapshotEntity = snapshotEntity3;
					}
					break;
				}
				case SnapshotZone.Quests:
				{
					SnapshotQuest snapshotQuest = ParseQuestLine(text2);
					if (snapshotQuest != null)
					{
						snapshotSide.Quests.Add(snapshotQuest);
					}
					break;
				}
				case SnapshotZone.Graveyard:
					ParseGraveyardLine(snapshotSide, text2);
					break;
				}
			}
		}
		return snapshotBoard;
	}

	private static void ParseTurnLine(SnapshotBoard board, string line)
	{
		Match match = Regex.Match(line, "turn=(\\d+)\\/(\\d+)", RegexOptions.IgnoreCase);
		if (match.Success)
		{
			if (int.TryParse(match.Groups[1].Value, out var result))
			{
				board.Turn = result;
			}
			if (int.TryParse(match.Groups[2].Value, out var result2))
			{
				board.Step = result2;
			}
		}
	}

	private static void ParseControllerLine(SnapshotSide side, string line)
	{
		side.Controller = ExtractInt(line, "controller");
		side.Class = ExtractString(line, "class");
		side.Fatigue = ExtractInt(line, "fatigue");
		side.Resources = ExtractInt(line, "resources");
		side.Used = ExtractInt(line, "used");
		side.Temp = ExtractInt(line, "temp");
		side.OverloadLocked = ExtractInt(line, "overloadLocked");
		side.OverloadOwed = ExtractInt(line, "overloadOwed");
		side.DeckCount = ExtractInt(line, "deckCount");
		side.SecretCount = ExtractInt(line, "secretCount");
	}

	private static SnapshotEntity ParseWeaponLine(string line)
	{
		if (line.IndexOf("<null>", StringComparison.OrdinalIgnoreCase) >= 0)
		{
			return null;
		}
		return ParseEntityLine(line);
	}

	private static SnapshotEntity ParseIndexedEntityLine(string line)
	{
		if (!line.StartsWith("[", StringComparison.Ordinal))
		{
			return null;
		}
		int num = line.IndexOf(':');
		if (num < 0 || num + 1 >= line.Length)
		{
			return null;
		}
		return ParseEntityLine(line.Substring(num + 1).Trim());
	}

	private static SnapshotEntity ParseEntityLine(string line)
	{
		string text = line;
		int num = text.IndexOf(':');
		if (num >= 0 && num + 1 < text.Length)
		{
			text = text.Substring(num + 1).Trim();
		}
		if (string.IsNullOrWhiteSpace(text))
		{
			return null;
		}
		SnapshotEntity snapshotEntity = new SnapshotEntity();
		snapshotEntity.EntityId = ExtractInt(text, "entity");
		snapshotEntity.CardId = ExtractString(text, "cardId");
		snapshotEntity.Name = ExtractName(text);
		snapshotEntity.Type = ExtractString(text, "type");
		snapshotEntity.Class = ExtractString(text, "class");
		snapshotEntity.Cost = ExtractInt(text, "cost");
		snapshotEntity.Attack = ExtractInt(text, "atk");
		snapshotEntity.Armor = ExtractInt(text, "armor");
		snapshotEntity.ZonePos = ExtractInt(text, "zonePos");
		snapshotEntity.Controller = ExtractInt(text, "controller");
		snapshotEntity.Creator = ExtractInt(text, "creator");
		ParseHp(text, snapshotEntity);
		return snapshotEntity;
	}

	private static SnapshotQuest ParseQuestLine(string line)
	{
		if (!line.StartsWith("[", StringComparison.Ordinal))
		{
			return null;
		}
		SnapshotQuest snapshotQuest = new SnapshotQuest();
		snapshotQuest.CardId = ExtractString(line, "cardId");
		snapshotQuest.IsQuest = ExtractBool(line, "isQuest");
		Match match = Regex.Match(line, "questProgress=(\\d+)\\/(\\d+)", RegexOptions.IgnoreCase);
		if (match.Success)
		{
			if (int.TryParse(match.Groups[1].Value, out var result))
			{
				snapshotQuest.Progress = result;
			}
			if (int.TryParse(match.Groups[2].Value, out var result2))
			{
				snapshotQuest.Maximum = result2;
			}
		}
		if (string.IsNullOrWhiteSpace(snapshotQuest.CardId))
		{
			return null;
		}
		return snapshotQuest;
	}

	private static void ParseGraveyardLine(SnapshotSide side, string line)
	{
		if (!line.StartsWith("-", StringComparison.Ordinal))
		{
			return;
		}
		string text = ExtractString(line, "card");
		if (!string.IsNullOrWhiteSpace(text))
		{
			if (!side.GraveyardCounts.TryGetValue(text, out var value))
			{
				value = 0;
			}
			side.GraveyardCounts[text] = value + 1;
		}
	}

	private static void ParseHp(string payload, SnapshotEntity entity)
	{
		Match match = Regex.Match(payload, "hp=(-?\\d+)\\/(-?\\d+)", RegexOptions.IgnoreCase);
		if (match.Success)
		{
			if (int.TryParse(match.Groups[1].Value, out var result))
			{
				entity.Health = result;
			}
			if (int.TryParse(match.Groups[2].Value, out var result2))
			{
				entity.MaxHealth = result2;
			}
		}
	}

	private static void ParseTags(SnapshotEntity entity, string payload)
	{
		string[] array = payload.Split(',');
		foreach (string text in array)
		{
			string text2 = text.Trim();
			int num = text2.IndexOf('=');
			if (num > 0 && num < text2.Length - 1)
			{
				string key = text2.Substring(0, num).Trim();
				string s = text2.Substring(num + 1).Trim();
				if (int.TryParse(s, out var result))
				{
					entity.Tags[key] = result;
				}
			}
		}
	}

	private static void ParseEnchantments(SnapshotEntity entity, string payload)
	{
		string[] array = payload.Split(',');
		foreach (string text in array)
		{
			string text2 = text.Trim();
			if (text2.Length != 0)
			{
				int num = text2.IndexOf('(');
				string text3 = ((num > 0) ? text2.Substring(0, num) : text2);
				if (text3.Length > 0)
				{
					entity.Enchantments.Add(text3);
				}
			}
		}
	}

	private static int ExtractInt(string payload, string key)
	{
		Match match = Regex.Match(payload, "\\b" + Regex.Escape(key) + "=(-?\\d+)\\b", RegexOptions.IgnoreCase);
		if (!match.Success)
		{
			return 0;
		}
		int result;
		return int.TryParse(match.Groups[1].Value, out result) ? result : 0;
	}

	private static bool ExtractBool(string payload, string key)
	{
		Match match = Regex.Match(payload, "\\b" + Regex.Escape(key) + "=(True|False)\\b", RegexOptions.IgnoreCase);
		return match.Success && string.Equals(match.Groups[1].Value, "True", StringComparison.OrdinalIgnoreCase);
	}

	private static string ExtractString(string payload, string key)
	{
		Match match = Regex.Match(payload, "\\b" + Regex.Escape(key) + "=([^\\s]+)", RegexOptions.IgnoreCase);
		if (!match.Success)
		{
			return string.Empty;
		}
		return match.Groups[1].Value.Trim();
	}

	private static string ExtractName(string payload)
	{
		Match match = Regex.Match(payload, "\\bname=(.+?)\\s+(?:type|class|race|cost|atk|hp|armor|zonePos|controller|creator)=", RegexOptions.IgnoreCase);
		if (!match.Success)
		{
			return string.Empty;
		}
		return match.Groups[1].Value.Trim();
	}

	private static string BuildLegacyBoardTesterText(SnapshotBoard board)
	{
		SnapshotSide friendly = board.Friendly;
		SnapshotSide opposing = board.Opposing;
		if (friendly.Hero == null || opposing.Hero == null)
		{
			return string.Empty;
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("turn " + Math.Max(board.Turn, 1) + "/" + Math.Max(board.Step, 0));
		stringBuilder.AppendLine("mana " + CalculateAvailableMana(friendly) + "/" + Math.Max(friendly.Resources, 0));
		stringBuilder.AppendLine("emana " + Math.Max(opposing.Resources, 0));
		stringBuilder.AppendLine("enemy secretsCount: " + Math.Max(opposing.SecretCount, 0) + " ;");
		stringBuilder.AppendLine("player:");
		stringBuilder.AppendLine("0 0 " + Math.Max(friendly.OverloadOwed, 0) + " " + Math.Max(friendly.OverloadLocked, 0) + " " + NormalizeOwnPlayer(friendly.Controller));
		stringBuilder.AppendLine("ownhero:");
		stringBuilder.AppendLine(BuildOwnHeroLine(friendly));
		stringBuilder.AppendLine(BuildWeaponLine(friendly.Weapon));
		stringBuilder.AppendLine("ability: " + BuildOwnAbilityReady(friendly.HeroPower) + " " + ResolveHeroPowerCardId(friendly, friendly.HeroPower));
		stringBuilder.AppendLine("osecrets: ");
		stringBuilder.AppendLine("cthunbonus: 0 0 0");
		stringBuilder.AppendLine("jadegolems: 0 0");
		stringBuilder.AppendLine("elementals: 0 0 0");
		stringBuilder.AppendLine(BuildQuestLine(friendly, opposing));
		stringBuilder.AppendLine("advanced: 0 0");
		stringBuilder.AppendLine("enemyhero:");
		stringBuilder.AppendLine(BuildEnemyHeroLine(opposing));
		stringBuilder.AppendLine(BuildWeaponLine(opposing.Weapon));
		stringBuilder.AppendLine("ability: True " + ResolveHeroPowerCardId(opposing, opposing.HeroPower));
		stringBuilder.AppendLine("fatigue: " + Math.Max(friendly.DeckCount, 0) + " " + Math.Max(friendly.Fatigue, 0) + " " + Math.Max(opposing.DeckCount, 0) + " " + Math.Max(opposing.Fatigue, 0));
		stringBuilder.AppendLine("OwnMinions:");
		foreach (string item in BuildBoardLines(friendly.Board))
		{
			stringBuilder.AppendLine(item);
		}
		stringBuilder.AppendLine("LocationContext: ownLocationsUsedThisGame=0 ownNextLocationCostReduction=0 parrotSanctuaryCount=0 lastDrawnCardEntityID=-1");
		stringBuilder.AppendLine("EnemyMinions:");
		foreach (string item2 in BuildBoardLines(opposing.Board))
		{
			stringBuilder.AppendLine(item2);
		}
		stringBuilder.AppendLine("Own Handcards: ");
		foreach (string item3 in BuildHandLines(friendly.Hand))
		{
			stringBuilder.AppendLine(item3);
		}
		stringBuilder.AppendLine("Enemy cards: " + opposing.Hand.Count);
		stringBuilder.AppendLine("GraveYard:");
		AppendCountsLine(stringBuilder, "og:", friendly.GraveyardCounts);
		AppendCountsLine(stringBuilder, "eg:", opposing.GraveyardCounts);
		return stringBuilder.ToString().Trim();
	}

	private static int CalculateAvailableMana(SnapshotSide side)
	{
		return Math.Max(0, side.Resources - side.Used + side.Temp);
	}

	private static int NormalizeOwnPlayer(int controller)
	{
		return (controller <= 0) ? 1 : controller;
	}

	private static string BuildOwnHeroLine(SnapshotSide side)
	{
		SnapshotEntity hero = side.Hero;
		return string.Join(" ", NormalizeHeroClassName(hero.Class), hero.Health.ToString(), Math.Max(hero.MaxHealth, hero.Health).ToString(), hero.Armor.ToString(), ToBoolString(GetTag(hero, "IMMUNE_WHILE_ATTACKING") > 0), ToBoolString(GetTag(hero, "IMMUNE") > 0), hero.EntityId.ToString(), ToBoolString(GetTag(hero, "READY") > 0), GetTag(hero, "NUM_ATTACKS_THIS_TURN").ToString(), ToBoolString(GetTag(hero, "FROZEN") > 0), hero.Attack.ToString(), "0", ToBoolString(GetTag(hero, "STEALTH") > 0), "False");
	}

	private static string BuildEnemyHeroLine(SnapshotSide side)
	{
		SnapshotEntity hero = side.Hero;
		return string.Join(" ", NormalizeHeroClassName(hero.Class), hero.Health.ToString(), Math.Max(hero.MaxHealth, hero.Health).ToString(), hero.Armor.ToString(), ToBoolString(GetTag(hero, "FROZEN") > 0), ToBoolString(GetTag(hero, "IMMUNE") > 0), hero.EntityId.ToString(), ToBoolString(GetTag(hero, "STEALTH") > 0), "False");
	}

	private static string BuildWeaponLine(SnapshotEntity weapon)
	{
		if (weapon == null)
		{
			return "weapon: 0 0 None None 0 0 0";
		}
		return string.Join(" ", "weapon:", weapon.Attack.ToString(), weapon.Health.ToString(), "None", string.IsNullOrWhiteSpace(weapon.CardId) ? "None" : weapon.CardId, ((GetTag(weapon, "POISONOUS") > 0) ? 1 : 0).ToString(), ((GetTag(weapon, "LIFESTEAL") > 0) ? 1 : 0).ToString(), "0");
	}

	private static string BuildOwnAbilityReady(SnapshotEntity heroPower)
	{
		if (heroPower == null)
		{
			return "True";
		}
		return ToBoolString(GetTag(heroPower, "EXHAUSTED") == 0);
	}

	private static string ResolveHeroPowerCardId(SnapshotSide side, SnapshotEntity heroPower)
	{
		if (heroPower != null && !string.IsNullOrWhiteSpace(heroPower.CardId))
		{
			return heroPower.CardId;
		}
		return (side.Class ?? string.Empty).ToUpperInvariant() switch
		{
			"WARRIOR" => "HERO_01bp",
			"SHAMAN" => "HERO_02bp",
			"ROGUE" => "HERO_03bp",
			"PALADIN" => "HERO_04bp",
			"HUNTER" => "HERO_05bp",
			"WARLOCK" => "HERO_07bp",
			"MAGE" => "HERO_08bp",
			"PRIEST" => "HERO_09bp",
			"DEMONHUNTER" => "HERO_10bp",
			_ => "HERO_08bp",
		};
	}

	private static string BuildQuestLine(SnapshotSide own, SnapshotSide enemy)
	{
		SnapshotQuest quest = own.Quests.FirstOrDefault((SnapshotQuest snapshotQuest2) => snapshotQuest2.IsQuest) ?? own.Quests.FirstOrDefault();
		SnapshotQuest quest2 = enemy.Quests.FirstOrDefault((SnapshotQuest snapshotQuest2) => snapshotQuest2.IsQuest) ?? enemy.Quests.FirstOrDefault();
		SnapshotQuest snapshotQuest = own.Quests.FirstOrDefault((SnapshotQuest snapshotQuest2) => !snapshotQuest2.IsQuest);
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("quests: ");
		stringBuilder.Append(FormatQuestBlock(quest));
		stringBuilder.Append(" ");
		stringBuilder.Append(FormatQuestBlock(quest2));
		if (snapshotQuest != null)
		{
			stringBuilder.Append(" ");
			stringBuilder.Append(FormatQuestBlock(snapshotQuest));
		}
		return stringBuilder.ToString();
	}

	private static string FormatQuestBlock(SnapshotQuest quest)
	{
		if (quest == null || string.IsNullOrWhiteSpace(quest.CardId))
		{
			return "None 0 1000";
		}
		int num = ((quest.Maximum > 0) ? quest.Maximum : 1000);
		return quest.CardId + " " + Math.Max(quest.Progress, 0) + " " + num;
	}

	private static IEnumerable<string> BuildBoardLines(List<SnapshotEntity> entities)
	{
		foreach (SnapshotEntity entity in from item in entities
			where item != null
			orderby item.ZonePos, item.EntityId
			select item)
		{
			yield return BuildBoardLine(entity);
		}
	}

	private static string BuildBoardLine(SnapshotEntity entity)
	{
		List<string> list = new List<string>();
		string text = SanitizeToken((!string.IsNullOrWhiteSpace(entity.Name)) ? entity.Name : entity.CardId);
		if (string.IsNullOrWhiteSpace(text))
		{
			text = "entity" + entity.EntityId;
		}
		list.Add(text + "(" + entity.Attack + "/" + entity.Health + ")");
		list.Add(string.IsNullOrWhiteSpace(entity.CardId) ? "None" : entity.CardId);
		list.Add("zp:" + Math.Max(entity.ZonePos, 1));
		list.Add("e:" + entity.EntityId);
		list.Add("A:" + entity.Attack);
		list.Add("H:" + entity.Health);
		list.Add("mH:" + Math.Max(entity.MaxHealth, entity.Health));
		list.Add("rdy:" + ToBoolString(GetTag(entity, "READY") > 0));
		list.Add("natt:" + GetTag(entity, "NUM_ATTACKS_THIS_TURN"));
		if (GetTag(entity, "EXHAUSTED") > 0)
		{
			list.Add("ex");
		}
		if (GetTag(entity, "TAUNT") > 0)
		{
			list.Add("tnt");
		}
		if (GetTag(entity, "FROZEN") > 0)
		{
			list.Add("frz");
		}
		if (GetTag(entity, "DIVINE_SHIELD") > 0)
		{
			list.Add("divshield");
		}
		if (GetTag(entity, "PLAYED_THIS_TURN") > 0)
		{
			list.Add("ptt");
		}
		if (GetTag(entity, "WINDFURY") > 0)
		{
			list.Add("wndfr");
		}
		if (GetTag(entity, "MEGA_WINDFURY") > 0)
		{
			list.Add("superwindfury");
		}
		if (GetTag(entity, "STEALTH") > 0)
		{
			list.Add("stlth");
		}
		if (GetTag(entity, "POISONOUS") > 0)
		{
			list.Add("poi");
		}
		if (GetTag(entity, "LIFESTEAL") > 0)
		{
			list.Add("lfst");
		}
		if (GetTag(entity, "IMMUNE") > 0)
		{
			list.Add("imm");
		}
		if (GetTag(entity, "UNTOUCHABLE") > 0)
		{
			list.Add("untch");
		}
		if (GetTag(entity, "ELUSIVE") > 0)
		{
			list.Add("cbtBySpells");
		}
		if (GetTag(entity, "RUSH") > 0)
		{
			list.Add("rush(1)");
		}
		if (GetTag(entity, "CHARGE") > 0 || GetTag(entity, "NON_KEYWORD_CHARGE") > 0)
		{
			list.Add("chrg(1)");
		}
		if (string.Equals(entity.Type, "LOCATION", StringComparison.OrdinalIgnoreCase))
		{
			list.Add("loc");
			list.Add("cd(" + GetTag(entity, "LOCATION_ACTION_COOLDOWN") + ")");
		}
		return string.Join(" ", list);
	}

	private static IEnumerable<string> BuildHandLines(List<SnapshotEntity> hand)
	{
		int position = 1;
		foreach (SnapshotEntity entity in from item in hand
			where item != null
			orderby item.ZonePos, item.EntityId
			select item)
		{
			yield return BuildHandLine(entity, position);
			position++;
		}
	}

	private static string BuildHandLine(SnapshotEntity entity, int position)
	{
		CardBaseStats cardBaseStats = TryLookupBaseStats(entity.CardId);
		int num = ((entity.MaxHealth > 0) ? entity.MaxHealth : entity.Health);
		int num2 = entity.Attack - cardBaseStats.Attack;
		int num3 = num - cardBaseStats.Health;
		List<string> list = new List<string>();
		list.Add("pos");
		list.Add(position.ToString());
		list.Add(BuildHandLabel(entity));
		list.Add(entity.Cost.ToString());
		list.Add("entity");
		list.Add(entity.EntityId.ToString());
		list.Add(string.IsNullOrWhiteSpace(entity.CardId) ? "None" : entity.CardId);
		list.Add(num2.ToString());
		list.Add(num3.ToString());
		list.Add("0");
		list.Add("0");
		list.Add("0");
		foreach (string item in entity.Enchantments.Where((string id) => !string.IsNullOrWhiteSpace(id)))
		{
			list.Add(item);
		}
		return string.Join(" ", list);
	}

	private static string BuildHandLabel(SnapshotEntity entity)
	{
		string text = SanitizeToken((!string.IsNullOrWhiteSpace(entity.Name)) ? entity.Name : entity.CardId);
		if (string.IsNullOrWhiteSpace(text))
		{
			text = "card" + entity.EntityId;
		}
		int num = ((entity.MaxHealth > 0) ? entity.MaxHealth : entity.Health);
		return text + "(" + entity.Attack + "/" + num + ")";
	}

	private static void AppendCountsLine(StringBuilder builder, string prefix, Dictionary<string, int> counts)
	{
		if (counts == null || counts.Count == 0)
		{
			return;
		}
		builder.Append(prefix);
		builder.Append(" ");
		foreach (KeyValuePair<string, int> item in counts.OrderBy((KeyValuePair<string, int> item) => item.Key, StringComparer.Ordinal))
		{
			builder.Append(item.Key).Append(",").Append(item.Value)
				.Append(";");
		}
		builder.AppendLine();
	}

	private static CardBaseStats TryLookupBaseStats(string cardId)
	{
		CardBaseStats result = default(CardBaseStats);
		if (string.IsNullOrWhiteSpace(cardId) || CardDB.Type == null || Card.Type == null)
		{
			return result;
		}
		try
		{
			CardDB cardDB = new CardDB(CardDB.Instance);
			cardIDEnum id = cardDB.cardIdstringToEnum(cardId);
			Card card = new Card(cardDB.getCardDataFromID(id));
			result.Attack = card.Attack;
			result.Health = card.Health;
		}
		catch
		{
		}
		return result;
	}

	private static string NormalizeHeroClassName(string heroClass)
	{
		return (heroClass ?? string.Empty).ToUpperInvariant() switch
		{
			"ROGUE" => "thief",
			"PALADIN" => "pala",
			"WARRIOR" => "warrior",
			"SHAMAN" => "shaman",
			"HUNTER" => "hunter",
			"DRUID" => "druid",
			"MAGE" => "mage",
			"PRIEST" => "priest",
			"WARLOCK" => "warlock",
			"DEMONHUNTER" => "demonhunter",
			"DEATHKNIGHT" => "deathknight",
			_ => string.IsNullOrWhiteSpace(heroClass) ? "mage" : heroClass.ToLowerInvariant(),
		};
	}

	private static int GetTag(SnapshotEntity entity, string tagName)
	{
		if (entity == null || entity.Tags == null)
		{
			return 0;
		}
		int value;
		return entity.Tags.TryGetValue(tagName, out value) ? value : 0;
	}

	private static string ToBoolString(bool value)
	{
		return value ? "True" : "False";
	}

	private static string SanitizeToken(string value)
	{
		if (string.IsNullOrWhiteSpace(value))
		{
			return string.Empty;
		}
		StringBuilder stringBuilder = new StringBuilder(value.Length);
		foreach (char c in value)
		{
			if (!char.IsWhiteSpace(c) && c != '(' && c != ')' && c != ':' && c != ';')
			{
				stringBuilder.Append(c);
			}
		}
		return stringBuilder.ToString();
	}
}
