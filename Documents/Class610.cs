using System;
using System.Reflection;

internal class Class610
{
	internal static void dv4E6ZDDbrCQf(int typemdt)
	{
		Type type = Class610.module_0.ResolveType(33554432 + typemdt);
		foreach (FieldInfo fieldInfo in type.GetFields())
		{
			MethodInfo method = (MethodInfo)Class610.module_0.ResolveMethod(fieldInfo.MetadataToken + 100663296);
			fieldInfo.SetValue(null, (MulticastDelegate)Delegate.CreateDelegate(type, method));
		}
	}

	public Class610()
	{
		
		
	}

	static Class610()
	{
		// Note: this type is marked as 'beforefieldinit'.
		
		Class610.module_0 = typeof(Class610).Assembly.ManifestModule;
	}

	internal static Module module_0;

	internal delegate void Delegate275(object o);
}
