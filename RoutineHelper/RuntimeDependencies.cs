using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace RoutineHelper;

public static class RuntimeDependencies
{
    private static readonly string[] ReferenceNames =
    {
        "Hearthbuddy", "GreyMagic", "log4net", "IronPython", "IronPython.Modules",
        "Microsoft.Dynamic", "Microsoft.Scripting", "Microsoft.Scripting.Metadata",
        "Newtonsoft.Json", "System.CodeDom", "System.Management", "Mono.Unix"
    };

    public static string ResolveDirectory(string silverfishPath)
    {
        string runtimeDirectory = Path.GetFullPath(Path.Combine(silverfishPath, "..", "..", ".."));
        if (FindAssembly(runtimeDirectory, "Hearthbuddy") != null)
            return runtimeDirectory;

        string bundledDirectory = Path.Combine(AppContext.BaseDirectory, "CompiledAssemblies");
        if (FindAssembly(bundledDirectory, "Hearthbuddy") != null)
            return bundledDirectory;

        throw new FileNotFoundException("未找到可加载的炉石兄弟托管程序集，请核对安装目录 " + runtimeDirectory, Path.Combine(runtimeDirectory, "Hearthbuddy.dll"));
    }

    public static string FindAssembly(string runtimeDirectory, string name)
    {
        // Modern installations keep dependencies in lib and the managed entry point in a DLL.
        return new[] { runtimeDirectory, Path.Combine(runtimeDirectory, "lib") }
            .SelectMany(directory => new[] { Path.Combine(directory, name + ".dll"), Path.Combine(directory, name + ".exe") })
            .FirstOrDefault(path => IsManagedAssembly(path, name));
    }

    private static bool IsManagedAssembly(string path, string name)
    {
        if (!File.Exists(path)) return false;
        try { return string.Equals(AssemblyName.GetAssemblyName(path).Name, name, StringComparison.OrdinalIgnoreCase); }
        catch (BadImageFormatException) { return false; }
        catch (FileLoadException) { return false; }
    }

    public static IEnumerable<string> GetReferencePaths(string runtimeDirectory)
    {
        return ReferenceNames.Select(name => FindAssembly(runtimeDirectory, name)).Where(path => path != null);
    }
}
