using System.Reflection;
using System.IO;
using System.Runtime.Loader;
using RoutinesDebugger.Shared;
using SilverfishWrapper;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Text;
[assembly: System.Runtime.Versioning.SupportedOSPlatform("windows7.0")]

using var helpOutput = new StringWriter();
Require(RoutineHelper.App.RunCommandLine(new[] { "--help" }, Environment.CurrentDirectory, helpOutput) == 0
    && helpOutput.ToString().Contains("--run-test"), "CLI help works without a configured runtime");
foreach (string[] invalid in new[]
{
    new[] { "--run-test" }, new[] { "--compile", "path", "extra" },
    new[] { "--run-latest-test", "policy", "extra" }, new[] { "--unknown" },
    new[] { "--run-test", "\0" }
})
{
    using var errorOutput = new StringWriter();
    Require(RoutineHelper.App.RunCommandLine(invalid, Environment.CurrentDirectory, errorOutput) == 2,
        "CLI rejects invalid input " + invalid[0]);
}

string temporaryRuntime = args.Length == 0 ? CreateFixtureRuntime() : null;
try
{
string editorDirectory = args.Length == 0 ? temporaryRuntime : Path.GetFullPath(args[0]);
string runtimeDirectory = args.Length == 0 ? temporaryRuntime : Path.GetFullPath(args[1]);
AssemblyLoadContext.Default.Resolving += (_, name) =>
{
    string[] candidates =
    {
        Path.Combine(runtimeDirectory, name.Name + ".dll"),
        Path.Combine(runtimeDirectory, "lib", name.Name + ".dll"),
        Path.Combine(editorDirectory, name.Name + ".dll")
    };
    string path = candidates.FirstOrDefault(File.Exists);
    return path == null ? null : AssemblyLoadContext.Default.LoadFromAssemblyPath(path);
};

Assembly kernel = Assembly.Load(File.ReadAllBytes(Path.Combine(editorDirectory, "CompiledAssemblies", "Silverfish.dll")));
Card.Type = kernel.GetType("HREngine.Bots.CardDB+Card", true);
CardDB.Type = kernel.GetType("HREngine.Bots.CardDB", true);
SilverfishWrapper.Settings.Type = kernel.GetType("HREngine.Bots.Settings", true);
new SilverfishWrapper.Settings(SilverfishWrapper.Settings.Instance).path =
    Path.Combine(runtimeDirectory, "Routines", "DefaultRoutine", "Silverfish", "data") + Path.DirectorySeparatorChar;

// Use a card whose positional name enum changed between the old and current kernels.
object runtimeCard = Activator.CreateInstance(Card.Type);
Type runtimeEnglish = kernel.GetType("HREngine.Bots.CardDB+cardNameEN", true);
Type runtimeChinese = kernel.GetType("HREngine.Bots.CardDB+cardNameCN", true);
Card.Type.GetField("nameEN").SetValue(runtimeCard, Enum.Parse(runtimeEnglish, "polymorph"));
Card.Type.GetField("nameCN").SetValue(runtimeCard, Enum.Parse(runtimeChinese, "变形术"));
Card wrapper = new Card(runtimeCard);
wrapper.superwindfury = true;
Require(wrapper.megaWindfury, "Current megaWindfury field alias");
Require(wrapper.name == "变形术", "Card name falls back to current kernel enum");
Require(wrapper.nameEN.ToString() == "polymorph", "English card name conversion");
Require(wrapper.nameCN.ToString() == "变形术", "Chinese card name conversion");
wrapper.nameEN = cardNameEN.fireball;
Require(Card.Type.GetField("nameEN").GetValue(runtimeCard).ToString() == "fireball", "Card name setter");
CardDB database = new CardDB(CardDB.Instance);
Require(database.cardNameENstringToEnum("fireball").ToString() == "fireball", "Enum method return");
Require(new Card(database.getCardDataFromID(cardIDEnum.CS2_029)).cardIDenum == cardIDEnum.CS2_029,
    "Enum method argument");

string legacyLine = "变形术 (1/2) 1 zp: e: 46 A:1 H:2 mH:2 rey:True natt:0";
string prepared = RoutineHelper.BoardTesterInputCompat.PrepareForBoardTester(legacyLine);
Require(prepared.Contains("zp:1 e:46") && prepared.Contains("rdy:True"), "Legacy minion fields normalize");
string fixtureRoot = Path.Combine(Path.GetTempPath(), "RoutineHelperSmoke_中文 空格_" + Guid.NewGuid().ToString("N"));
try
{
    string sourceDirectory = Path.Combine(fixtureRoot, "Routines", "DefaultRoutine", "Silverfish");
    Directory.CreateDirectory(Path.Combine(sourceDirectory, "Test"));
    Directory.CreateDirectory(Path.Combine(sourceDirectory, "ai"));
    Directory.CreateDirectory(Path.Combine(sourceDirectory, "cards"));
    File.Copy(Path.Combine(runtimeDirectory, "Hearthbuddy.dll"), Path.Combine(fixtureRoot, "Hearthbuddy.dll"));
    File.WriteAllText(Path.Combine(sourceDirectory, "Test", "TestBase.cs"), "namespace HREngine.Bots { public class TestBase {} }");
    string markerPath = Path.Combine(sourceDirectory, "..", "silverfish_HB.cs");
    string outputPath = Path.Combine(fixtureRoot, "CompiledAssemblies", "Silverfish.dll");
    string logPath = Path.Combine(fixtureRoot, "compile.log");
    File.WriteAllText(markerPath, "#if APPLICATION_MODE\n#error Offline kernels must compile without editor callbacks\n#endif\nnamespace SmokeFixture { public class Marker { public int Value => new[] { 1 }.FirstOrDefault(); } }");
    byte[] originalSource = File.ReadAllBytes(markerPath);
    var firstBuild = SilverfishBuildService.Compile(sourceDirectory, outputPath, logPath);
    Require(!firstBuild.Errors.HasErrors, "First strategy compile");
    Require(File.ReadAllBytes(markerPath).SequenceEqual(originalSource), "Compilation keeps input source unchanged");
    Require(RoutineHelper.RoutineRuntime.IsCompiledKernelUsable(outputPath), "Current offline kernel cache is usable");
    string invalidKernelPath = Path.Combine(fixtureRoot, "invalid.dll");
    File.WriteAllText(invalidKernelPath, "invalid binary");
    Require(!RoutineHelper.RoutineRuntime.IsCompiledKernelUsable(invalidKernelPath), "Corrupt cache triggers compilation");
    string legacyKernelPath = Path.Combine(fixtureRoot, "legacy.dll");
    var legacyCompilation = CSharpCompilation.Create("Silverfish",
        new[] { CSharpSyntaxTree.ParseText("public class Legacy { public object Editor => typeof(RoutineHelper.MainWindow); }") },
        ((string)AppContext.GetData("TRUSTED_PLATFORM_ASSEMBLIES")).Split(Path.PathSeparator).Select(path => MetadataReference.CreateFromFile(path)),
        new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary, platform: Platform.X64));
    using (var stream = File.Create(legacyKernelPath))
        Require(legacyCompilation.Emit(stream).Success, "Legacy kernel fixture builds");
    Require(!RoutineHelper.RoutineRuntime.IsCompiledKernelUsable(legacyKernelPath), "Editor-coupled cache triggers compilation");
    byte[] firstBytes = File.ReadAllBytes(outputPath);
    Assembly firstAssembly = Assembly.Load(firstBytes);

    File.WriteAllText(markerPath, "public class EditorDependency { public object Value => typeof(RoutineHelper.MainWindow); }");
    var failedBuild = SilverfishBuildService.Compile(sourceDirectory, outputPath, logPath);
    Require(failedBuild.Errors.HasErrors, "Offline compilation excludes editor assembly references");
    Require(File.ReadAllBytes(outputPath).SequenceEqual(firstBytes), "Failed compile preserves working DLL");

    File.WriteAllText(markerPath, "namespace SmokeFixture { public class Marker { public int Value => 2; } }");
    var secondBuild = SilverfishBuildService.Compile(sourceDirectory, outputPath, logPath);
    Require(!secondBuild.Errors.HasErrors, "Recompile while previous assembly remains loaded");
    Assembly secondAssembly = Assembly.Load(File.ReadAllBytes(outputPath));
    Type markerType = secondAssembly.GetType("SmokeFixture.Marker", true);
    Require((int)markerType.GetProperty("Value").GetValue(Activator.CreateInstance(markerType)) == 2,
        "Reload uses updated strategy");
    var concurrent = new[] { 0, 1 }.Select(_ => Task.Run(() => SilverfishBuildService.Compile(sourceDirectory, outputPath, logPath))).ToArray();
    Task.WaitAll(concurrent);
    Require(concurrent.All(task => !task.Result.Errors.HasErrors), "Concurrent compile uses consistent output");
    Require(Assembly.Load(File.ReadAllBytes(outputPath)).GetType("SmokeFixture.Marker") != null, "Concurrent output loads");
    string missingSource = Path.Combine(fixtureRoot, "missing", "Routines", "DefaultRoutine", "Silverfish");
    Directory.CreateDirectory(missingSource);
    var missingBuild = SilverfishBuildService.Compile(missingSource, outputPath, logPath);
    Require(missingBuild.Errors.HasErrors && missingBuild.Errors[0].ErrorText.Contains("Hearthbuddy"), "Missing runtime identifies dependency");
    Require(RoutineHelper.RoutineRuntime.NormalizeDefaultRoutinePath(sourceDirectory) == Path.GetDirectoryName(sourceDirectory), "Chinese and space path normalization");
    string modernLog = Path.Combine(fixtureRoot, "Logs", "Data", "对局记录", "modern.txt");
    string legacyLog = Path.Combine(sourceDirectory, "Test", "Data", "legacy.txt");
    Directory.CreateDirectory(Path.GetDirectoryName(modernLog));
    Directory.CreateDirectory(Path.GetDirectoryName(legacyLog));
    File.WriteAllText(modernLog, "modern");
    File.WriteAllText(legacyLog, "legacy");
    File.SetLastWriteTimeUtc(modernLog, DateTime.UtcNow.AddMinutes(-2));
    File.SetLastWriteTimeUtc(legacyLog, DateTime.UtcNow.AddMinutes(-1));
    Require(RoutineHelper.RoutineRuntime.FindMostRecentTestFile(sourceDirectory) == legacyLog,
        "Newest record spans modern and legacy folders");
    string configPath = Path.Combine(fixtureRoot, "Settings", "routine.xml");
    Parallel.For(0, 20, index => new RoutineHelper.XmlConfigUtil(configPath).Write(index.ToString(), "Key" + index));
    Require(Enumerable.Range(0, 20).All(index => new RoutineHelper.XmlConfigUtil(configPath).Read("Key" + index) == index.ToString()),
        "Concurrent configuration writes preserve every key");
    File.WriteAllText(configPath, "<broken");
    try
    {
        new RoutineHelper.XmlConfigUtil(configPath).Write("value", "NewKey");
        Require(false, "Invalid config reports an error");
    }
    catch (System.Xml.XmlException)
    {
        Require(File.ReadAllText(configPath) == "<broken", "Failed config update preserves original data");
    }
    GC.KeepAlive(firstAssembly);
}
finally
{
    Directory.Delete(fixtureRoot, true);
}

var generated = ReflectionCodeGenerator.CodeGen.Generate(new[] { Card.Type, CardDB.Type, SilverfishWrapper.Settings.Type, typeof(OverloadFixture) });
using (var stream = typeof(ReflectionCodeGenerator.CodeGen).Assembly.GetManifestResourceStream("ReflectionHelper.cs"))
using (var reader = new StreamReader(stream)) generated.Add("ReflectionHelper.cs", reader.ReadToEnd());
var generatedCompilation = CSharpCompilation.Create("GeneratedSmoke", generated.Values.Select(source => CSharpSyntaxTree.ParseText(source)),
    ((string)AppContext.GetData("TRUSTED_PLATFORM_ASSEMBLIES")).Split(Path.PathSeparator).Select(path => MetadataReference.CreateFromFile(path)),
    new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
using var generatedBytes = new MemoryStream();
var generatedResult = generatedCompilation.Emit(generatedBytes);
Require(generatedResult.Success, "Generated wrappers compile " + string.Join("\n", generatedResult.Diagnostics.Where(diagnostic => diagnostic.Severity == DiagnosticSeverity.Error)));
Assembly generatedAssembly = Assembly.Load(generatedBytes.ToArray());
Type generatedCardType = generatedAssembly.GetType("SilverfishWrapper.Card");
generatedCardType.GetField("Type").SetValue(null, Card.Type);
object generatedCard = Activator.CreateInstance(generatedCardType, runtimeCard);
Require(generatedCardType.GetProperty("nameEN").GetValue(generatedCard).ToString() == "fireball", "Generated enum getter");
Type generatedEnglish = generatedAssembly.GetType("SilverfishWrapper.cardNameEN");
generatedCardType.GetProperty("nameEN").SetValue(generatedCard, Enum.Parse(generatedEnglish, "polymorph"));
Require(Card.Type.GetField("nameEN").GetValue(runtimeCard).ToString() == "polymorph", "Generated enum setter");
Type generatedDatabaseType = generatedAssembly.GetType("SilverfishWrapper.CardDB");
generatedDatabaseType.GetField("Type").SetValue(null, CardDB.Type);
object generatedDatabase = Activator.CreateInstance(generatedDatabaseType, CardDB.Instance);
Type generatedId = generatedAssembly.GetType("SilverfishWrapper.cardIDEnum");
object returnedCard = generatedDatabaseType.GetMethod("getCardDataFromID").Invoke(generatedDatabase,
    new[] { Enum.Parse(generatedId, "CS2_029") });
Require(Card.Type.GetField("cardIDenum").GetValue(returnedCard).ToString() == "CS2_029", "Generated enum method argument");
Require(generatedDatabaseType.GetMethod("cardNameENstringToEnum").Invoke(generatedDatabase, new object[] { "fireball" }).ToString() == "fireball", "Generated enum method return");
Type overloadWrapperType = generatedAssembly.GetType("SilverfishWrapper.OverloadFixture");
overloadWrapperType.GetField("Type").SetValue(null, typeof(OverloadFixture));
object overloadInstance = Activator.CreateInstance(overloadWrapperType, new OverloadFixture());
Require(overloadWrapperType.GetMethod("Choose").Invoke(overloadInstance, new object[] { new object() }).ToString() == "object",
    "Generated object overload preserves original entry point");
Require(overloadWrapperType.GetMethod("Choose__Uri").Invoke(overloadInstance, new object[] { new Uri("https://example.com") }).ToString() == "uri",
    "Generated colliding overload remains callable");
Require(overloadInstance.Equals(overloadWrapperType.GetField("Inst").GetValue(overloadInstance)), "Generated object Equals override works");
Console.WriteLine("Editor smoke checks passed.");
}
finally
{
    if (temporaryRuntime != null) Directory.Delete(temporaryRuntime, true);
}

static void Require(bool success, string description)
{
    if (!success)
        throw new InvalidOperationException(description);
    Console.WriteLine("PASS " + description);
}

static string CreateFixtureRuntime()
{
    string root = Path.Combine(Path.GetTempPath(), "DebuggerFixture_" + Guid.NewGuid().ToString("N"));
    string source = Path.Combine(root, "Routines", "DefaultRoutine", "Silverfish");
    Directory.CreateDirectory(Path.Combine(source, "Test"));
    var references = ((string)AppContext.GetData("TRUSTED_PLATFORM_ASSEMBLIES")).Split(Path.PathSeparator).Select(path => MetadataReference.CreateFromFile(path));
    var stub = CSharpCompilation.Create("Hearthbuddy", new[] { CSharpSyntaxTree.ParseText("public class RuntimeMarker {}") }, references,
        new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
    using (var output = File.Create(Path.Combine(root, "Hearthbuddy.dll")))
        if (!stub.Emit(output).Success) throw new InvalidOperationException("Cannot build fixture runtime");
    File.WriteAllText(Path.Combine(source, "Test", "TestBase.cs"), "namespace HREngine.Bots { public class TestBase {} }");
    File.WriteAllText(Path.Combine(source, "..", "silverfish_HB.cs"), "");
    File.WriteAllText(Path.Combine(source, "Fixture.cs"), """
namespace HREngine.Bots
{
    public class Settings { public static Settings Instance { get; } = new Settings(); public string path; }
    public class CardDB
    {
        public enum cardNameEN { polymorph = 71, fireball = 99 }
        public enum cardNameCN { 变形术 = 18 }
        public enum cardIDEnum { None, CS2_029 }
        public class Card { public bool megaWindfury; public cardNameEN nameEN; public cardNameCN nameCN; public cardIDEnum cardIDenum; }
        public static CardDB Instance { get; } = new CardDB();
        public cardNameEN cardNameENstringToEnum(string value) => (cardNameEN)System.Enum.Parse(typeof(cardNameEN), value);
        public cardNameCN cardNameCNstringToEnum(string value) => (cardNameCN)System.Enum.Parse(typeof(cardNameCN), value);
        public object getCardData(cardNameCN value) => new Card { cardIDenum = cardIDEnum.CS2_029 };
        public object getCardDataFromID(cardIDEnum value) => new Card { cardIDenum = value };
    }
}
""", Encoding.UTF8);
    var result = SilverfishBuildService.Compile(source, Path.Combine(root, "CompiledAssemblies", "Silverfish.dll"), Path.Combine(root, "compile.log"));
    if (result.Errors.HasErrors) throw new InvalidOperationException(string.Join("\n", result.Errors.Cast<object>()));
    return root;
}

public sealed class OverloadFixture
{
    public string Choose(object value) => "object";
    public string Choose(Uri value) => "uri";
    public override bool Equals(object value) => ReferenceEquals(this, value);
    public override int GetHashCode() => 7;
}
