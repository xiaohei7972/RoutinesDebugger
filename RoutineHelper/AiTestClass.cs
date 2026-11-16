using SilverfishWrapper;

namespace RoutineHelper;

public class AiTestClass : TestBase
{
	public AiTestClass(object baseInst)
		: base(baseInst)
	{
	}

	public void Test(string testFilePath, object behavior)
	{
		Settings settings = new Settings(Settings.Instance);
		settings.test = true;
		string rawInput = TextFileUtil.ReadAllTextPreferUtf8(testFilePath);
		InitSetting();
		rawInput = BoardTesterInputCompat.PrepareForBoardTester(rawInput);
		Ai ai = new Ai(Ai.Instance);
		ai.botBase = behavior;
		ai.autoTester(printstuff: true, rawInput, 0);
	}
}
