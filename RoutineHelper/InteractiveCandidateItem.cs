using System.Collections.Generic;

namespace RoutineHelper;

public class InteractiveCandidateItem
{
	public CandidateActionView Candidate { get; set; }

	public string Action { get; set; }

	public string ChangeSummary { get; set; }

	public string Source { get; set; }

	public string Target { get; set; }

	public string SourceImage { get; set; }

	public string TargetImage { get; set; }

	public int SourceEntityId { get; set; }

	public List<int> TargetEntityIds { get; set; } = new List<int>();

	public override string ToString()
	{
		return Action ?? string.Empty;
	}
}
