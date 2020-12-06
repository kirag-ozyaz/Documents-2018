using System;
using System.Reflection;

internal class Class37
{
	internal static void Nt5X7Zmm99XRy(int typemdt)
	{
		Type type = Class37.module_0.ResolveType(33554432 + typemdt);
		foreach (FieldInfo fieldInfo in type.GetFields())
		{
			MethodInfo method = (MethodInfo)Class37.module_0.ResolveMethod(fieldInfo.MetadataToken + 100663296);
			fieldInfo.SetValue(null, (MulticastDelegate)Delegate.CreateDelegate(type, method));
		}
	}

	//public Class37()
	//{
	//	//Class38.TqlX7ZmzmDDi2();
	//	//
	//}

	// Note: this type is marked as 'beforefieldinit'.
	static Class37()
	{
		//Class38.TqlX7ZmzmDDi2();
		Class37.module_0 = typeof(Class37).Assembly.ManifestModule;
	}

	internal static Module module_0;

	internal delegate void Delegate14(object o);
}
