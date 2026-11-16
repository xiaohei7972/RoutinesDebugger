using System.Collections.Generic;
using SilverfishWrapper;

namespace RoutineHelper;

public class ActionItem
{
	public List<ActionItem> subGroups = new List<ActionItem>();

	public float Score { get; set; }

	public string Action { get; set; }

	public string Decision { get; set; }

	public string Source { get; set; }

	public int Level { get; set; }

	public string Target { get; set; }

	public ActionItem Father { get; set; }

	public Playfield Board { get; set; }

	public IList<object> Items
	{
		get
		{
			IList<object> list = new List<object>();
			foreach (ActionItem subGroup in subGroups)
			{
				list.Add(subGroup);
			}
			return list;
		}
	}
}
