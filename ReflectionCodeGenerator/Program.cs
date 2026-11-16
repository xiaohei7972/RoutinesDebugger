using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using RoutineHelper;

namespace ReflectionCodeGenerator;

internal static class Program
{
    private static readonly string[] RequiredTypes =
    {
        "Playfield", "Action", "CardDB", "CardDB+Card", "Minion", "Handmanager+Handcard",
        "SecretItem", "Questmanager+QuestItem", "Hrtprozis", "Settings", "Ai", "TestBase"
    };

    public static int Main(string[] args)
    {
        if (args.Length != 2)
        {
            Console.Error.WriteLine("Usage: ReflectionCodeGenerator <Silverfish.dll> <output-directory>");
            return 2;
        }
        try
        {
            string assemblyPath = Path.GetFullPath(args[0]);
            string assemblyDirectory = Path.GetDirectoryName(assemblyPath);
            var searchDirectories = new List<string> { assemblyDirectory, AppContext.BaseDirectory };
            if (RoutineRuntime.TryResolveSilverfishPath(out var sourcePath))
                searchDirectories.Add(RuntimeDependencies.ResolveDirectory(sourcePath));
            AssemblyLoadContext.Default.Resolving += (_, name) =>
            {
                string path = searchDirectories.Select(directory => RuntimeDependencies.FindAssembly(directory, name.Name))
                    .FirstOrDefault(candidate => candidate != null);
                return path == null ? null : AssemblyLoadContext.Default.LoadFromAssemblyPath(path);
            };
            Assembly assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(assemblyPath);
            string[] missing = RequiredTypes.Where(name => assembly.GetType("HREngine.Bots." + name) == null).ToArray();
            if (missing.Length > 0)
                throw new TypeLoadException("Missing required types: " + string.Join(", ", missing));
            Type[] types = RequiredTypes.Select(name => assembly.GetType("HREngine.Bots." + name, true)).ToArray();
            string outputDirectory = Path.GetFullPath(args[1]);
            var files = CodeGen.Generate(types);
            Directory.CreateDirectory(outputDirectory);
            foreach (var file in files) File.WriteAllText(Path.Combine(outputDirectory, file.Key), file.Value);
            using var helper = typeof(Program).Assembly.GetManifestResourceStream("ReflectionHelper.cs");
            using var reader = new StreamReader(helper);
            File.WriteAllText(Path.Combine(outputDirectory, "ReflectionHelper.cs"), reader.ReadToEnd());
            Console.WriteLine($"Generated {files.Count + 1} source files in {outputDirectory}");
            return 0;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine(exception.ToString());
            return 1;
        }
    }
}
