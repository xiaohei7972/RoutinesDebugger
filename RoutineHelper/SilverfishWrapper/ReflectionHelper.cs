using System;
using System.Linq;
using System.Reflection;

namespace SilverfishWrapper;

internal static class ReflectionHelper
{
	private const BindingFlags AllFlags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

    public static T ConvertValue<T>(object value)
    {
        return (T)ConvertEnum(value, typeof(T));
    }

    private static object ConvertEnum(object value, Type targetType)
    {
        if (value == null || !targetType.IsEnum || value.GetType() == targetType)
            return value;
        // Names remain stable when a routine adds entries to its positional enums.
        return Enum.Parse(targetType, value.ToString());
    }

    public static void SetCompatibleValue(this FieldInfo field, object instance, object value)
    {
        field.SetValue(instance, ConvertEnum(value, field.FieldType));
    }

    public static void SetCompatibleValue(this PropertyInfo property, object instance, object value)
    {
        property.SetValue(instance, ConvertEnum(value, property.PropertyType));
    }

    public static object InvokeCompatible(this MethodInfo method, object instance, object[] arguments)
    {
        ParameterInfo[] parameters = method.GetParameters();
        for (int index = 0; index < arguments.Length; index++)
            arguments[index] = ConvertEnum(arguments[index], parameters[index].ParameterType);
        return method.Invoke(instance, arguments);
    }

	public static T ReflectionGetFieldValue<T>(this object obj, string name)
	{
		return (T)obj.GetType().GetField(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(obj);
	}

	public static T ReflectionCall<T>(this object obj, string name, params object[] parameters)
	{
		return (T)obj.GetType().GetMethod(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, parameters.Select((object x) => x.GetType()).ToArray(), null).Invoke(obj, parameters);
	}
}
