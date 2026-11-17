namespace RoutineHelper;

public class RecentTestFileItem
{
	public string DisplayName { get; set; }

	public string FullPath { get; set; }

	public override string ToString()
	{
		return DisplayName;
	}
}
