using System.Collections.Generic;

namespace RoutineHelper;

public class CardLoadResult
{
	public double ElapsedSeconds { get; set; }

	public List<CardListEntry> Cards { get; set; }

	public Dictionary<string, string> CardNameLookup { get; set; }
}
