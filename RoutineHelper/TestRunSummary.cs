using System.Collections.Generic;

namespace RoutineHelper;

internal sealed class TestRunSummary
{
	public string BehaviorName { get; set; }

	public string TestFilePath { get; set; }

	public float BestMoveValue { get; set; }

	public List<string> BestActions { get; set; } = new List<string>();

	public string LogFilePath { get; set; }

	public string CurrentCalculatedBoard { get; set; }
}
