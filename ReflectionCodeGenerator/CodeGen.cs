using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace ReflectionCodeGenerator;

internal static class CodeGen
{
    private const BindingFlags Flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance | BindingFlags.DeclaredOnly;
    private const string Header = "using System;\nusing System.Reflection;\nnamespace SilverfishWrapper;\n";
    private static string Quote(string value) => JsonSerializer.Serialize(value);
    private static bool Supported(Type type) => !type.IsByRef && !type.IsPointer && !type.ContainsGenericParameters;
    private static bool Named(MemberInfo member) => !member.Name.Contains('<') && !member.Name.Contains('.');
    private static string WrapperType(Type type) => type == typeof(void) ? "void" :
        type.IsEnum ? "@" + type.Name :
        type == typeof(string) || type.IsPrimitive || type == typeof(decimal) ? "global::" + type.FullName : "object";
    private static string RuntimeType(Type type, Type declaringType)
    {
        if (type.Assembly == declaringType.Assembly)
            return "Type.Assembly.GetType(" + Quote(type.FullName) + ", true)";
        if (type.IsGenericType)
            return "System.Type.GetType(" + Quote(type.GetGenericTypeDefinition().AssemblyQualifiedName) + ", true).MakeGenericType(new Type[] { " +
                string.Join(", ", type.GetGenericArguments().Select(argument => RuntimeType(argument, declaringType))) + " })";
        return "System.Type.GetType(" + Quote(type.AssemblyQualifiedName) + ", true)";
    }

    public static Dictionary<string, string> Generate(Type[] types)
    {
        var files = new Dictionary<string, string>();
        var enums = new HashSet<Type>();
        foreach (Type type in types)
        {
            var body = new StringBuilder(Header);
            body.AppendLine($"public class @{type.Name}\n{{\n    public object Inst;\n    public static Type Type;\n    public @{type.Name}(object instance) {{ Inst = instance; }}");
            body.AppendLine("    private const BindingFlags Flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance | BindingFlags.DeclaredOnly;");
            foreach (var field in type.GetFields(Flags).Where(field => Named(field) && Supported(field.FieldType)))
            {
                RememberEnum(field.FieldType, enums);
                string target = field.IsStatic ? "null" : "Inst";
                string member = $"Type.GetField({Quote(field.Name)}, Flags)";
                body.AppendLine($"    public {(field.IsStatic ? "static " : "")}{WrapperType(field.FieldType)} @{field.Name}\n    {{");
                body.AppendLine($"        get => ReflectionHelper.ConvertValue<{WrapperType(field.FieldType)}>({member}.GetValue({target}));");
                if (!field.IsInitOnly && !field.IsLiteral)
                    body.AppendLine($"        set => {member}.SetCompatibleValue({target}, value);");
                body.AppendLine("    }");
            }
            foreach (var property in type.GetProperties(Flags).Where(property => Named(property) && property.GetIndexParameters().Length == 0 && Supported(property.PropertyType)))
            {
                RememberEnum(property.PropertyType, enums);
                bool isStatic = (property.GetGetMethod(true) ?? property.GetSetMethod(true)).IsStatic;
                string target = isStatic ? "null" : "Inst";
                string member = $"Type.GetProperty({Quote(property.Name)}, Flags)";
                body.AppendLine($"    public {(isStatic ? "static " : "")}{WrapperType(property.PropertyType)} @{property.Name}\n    {{");
                if (property.CanRead)
                    body.AppendLine($"        get => ReflectionHelper.ConvertValue<{WrapperType(property.PropertyType)}>({member}.GetValue({target}));");
                if (property.CanWrite)
                    body.AppendLine($"        set => {member}.SetCompatibleValue({target}, value);");
                body.AppendLine("    }");
            }
            var signatures = new HashSet<string>();
            foreach (var method in type.GetMethods(Flags).Where(method => Named(method) && !method.IsGenericMethod && !method.IsSpecialName && Supported(method.ReturnType) && method.GetParameters().All(parameter => Supported(parameter.ParameterType))))
            {
                var parameters = method.GetParameters();
                string signature = method.Name + "(" + string.Join(",", parameters.Select(parameter => WrapperType(parameter.ParameterType))) + ")";
                if (!signatures.Add(signature))
                {
                    Console.Error.WriteLine("Skipped wrapper signature collision: " + type.FullName + "." + signature);
                    continue;
                }
                RememberEnum(method.ReturnType, enums);
                foreach (var parameter in parameters) RememberEnum(parameter.ParameterType, enums);
                string declarations = string.Join(", ", parameters.Select((parameter, index) => WrapperType(parameter.ParameterType) + " arg" + index));
                string arguments = string.Join(", ", parameters.Select((_, index) => "arg" + index));
                string signatureTypes = string.Join(", ", parameters.Select(parameter => RuntimeType(parameter.ParameterType, type)));
                string target = method.IsStatic ? "null" : "Inst";
                string call = $"Type.GetMethod({Quote(method.Name)}, Flags, null, new Type[] {{ {signatureTypes} }}, null).InvokeCompatible({target}, new object[] {{ {arguments} }})";
                body.AppendLine($"    public {(method.IsStatic ? "static " : "")}{WrapperType(method.ReturnType)} @{method.Name}({declarations})");
                body.AppendLine(method.ReturnType == typeof(void)
                    ? $"        => {call};" : $"        => ReflectionHelper.ConvertValue<{WrapperType(method.ReturnType)}>({call});");
            }
            body.AppendLine("}");
            files.Add(type.Name + ".cs", body.ToString());
        }
        foreach (var group in enums.GroupBy(type => type.Name))
        {
            if (group.Count() != 1) throw new InvalidOperationException("Conflicting enum name: " + group.Key);
            Type type = group.Single();
            var body = new StringBuilder(Header);
            body.AppendLine($"public enum @{type.Name} : {WrapperType(Enum.GetUnderlyingType(type))}\n{{");
            foreach (string name in Enum.GetNames(type))
            {
                object value = Convert.ChangeType(Enum.Parse(type, name), Enum.GetUnderlyingType(type), CultureInfo.InvariantCulture);
                body.AppendLine($"    @{name} = {Convert.ToString(value, CultureInfo.InvariantCulture)},");
            }
            body.AppendLine("}");
            files.Add(type.Name + ".cs", body.ToString());
        }
        return files;
    }

    private static void RememberEnum(Type type, HashSet<Type> enums)
    {
        if (type.IsEnum) enums.Add(type);
    }
}
