using SilverfishWrapper;

namespace RoutineHelper;

public class ManualActionStep
{
	public int StepIndex { get; set; }

	public string Action { get; set; }

	public string ChangeSummary { get; set; }

	public string SourceImage { get; set; }

	public string TargetImage { get; set; }

	public object ActionObject { get; set; }

	public Action ActionWrapper { get; set; }

	public Playfield BoardBefore { get; set; }

	public Playfield BoardAfter { get; set; }

	public string Title => "第" + StepIndex + "步";

	public override string ToString()
	{
		return Title + " " + (Action ?? string.Empty);
	}
}
