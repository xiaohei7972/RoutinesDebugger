using System.Reflection;
using System.IO;
using System.Runtime.Loader;
using RoutinesDebugger.Shared;
using SilverfishWrapper;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Text;
[assembly: System.Runtime.Versioning.SupportedOSPlatform("windows7.0")]

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
    File.WriteAllText(markerPath, "namespace SmokeFixture { public class Marker { public int Value => 1; } }");
    var firstBuild = SilverfishBuildService.Compile(sourceDirectory, outputPath, logPath);
    Require(!firstBuild.Errors.HasErrors, "First strategy compile");
    byte[] firstBytes = File.ReadAllBytes(outputPath);
    Assembly firstAssembly = Assembly.Load(firstBytes);

    File.WriteAllText(markerPath, "broken source");
    var failedBuild = SilverfishBuildService.Compile(sourceDirectory, outputPath, logPath);
    Require(failedBuild.Errors.HasErrors, "Invalid source reports errors");
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
    GC.KeepAlive(firstAssembly);
}
finally
{
    Directory.Delete(fixtureRoot, true);
}

var generated = ReflectionCodeGenerator.CodeGen.Generate(new[] { Card.Type, CardDB.Type, SilverfishWrapper.Settings.Type });
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
