using System;
using System.Reflection;

namespace SilverfishWrapper;

public class TestBase
{
	public object Inst;

	public static Type Type;

	private const BindingFlags AllFlags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

	public TestBase(object inst)
	{
		Inst = inst;
	}

	public void InitSetting()
	{
		Type[] types = new Type[0];
		Type.GetMethod("InitSetting", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, types, null).InvokeCompatible(Inst, new object[0]);
	}
}
