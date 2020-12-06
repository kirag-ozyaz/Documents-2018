using System;
using System.Drawing;
using System.Runtime.InteropServices;

internal static class Class35
{
	[DllImport("shell32.dll")]
	internal static extern int SHGetFileInfo(string string_0, uint uint_4, ref Class35.Struct1 struct1_0, int int_0, uint uint_5);

	internal static Icon smethod_0(string string_0)
	{
		Class35.Struct1 @struct = default(Class35.Struct1);
		uint num = Class35.uint_2 | Class35.uint_0;
		num |= Class35.uint_1;
		if (Class35.SHGetFileInfo(string_0, Class35.uint_3, ref @struct, Marshal.SizeOf(@struct), num) == 0)
		{
			return null;
		}
		return Icon.FromHandle(@struct.intptr_0);
	}

	// Note: this type is marked as 'beforefieldinit'.
	static Class35()
	{
		Class38.TqlX7ZmzmDDi2();
		Class35.uint_0 = 256u;
		Class35.uint_1 = 0u;
		Class35.uint_2 = 16u;
		Class35.uint_3 = 128u;
	}

	internal static uint uint_0;

	private static uint uint_1;

	private static uint uint_2;

	private static uint uint_3;

	internal struct Struct1
	{
		public IntPtr intptr_0;

		public IntPtr intptr_1;

		public uint uint_0;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
		public string string_0;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
		public string string_1;
	}
}
