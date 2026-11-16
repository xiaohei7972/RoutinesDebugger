using SilverfishWrapper;

namespace RoutineHelper;

public class CandidateActionView
{
	public object ActionObject { get; set; }

	public Action ActionWrapper { get; set; }

	public Playfield Board { get; set; }

	public float Score { get; set; }
}
