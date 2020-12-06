using System;
using System.Data;
using System.Linq;

internal class Class125
{
	internal static bool smethod_0(DataTable dataTable_0)
	{
		if (dataTable_0 is Class255.Class318)
		{
			Class255.Class318 source = (Class255.Class318)dataTable_0;
			return !source.First<Class255.Class424>().method_2() || !source.First<Class255.Class424>().method_4() || !source.First<Class255.Class424>().method_6();
		}
		if (dataTable_0 is Class255.Class331)
		{
			Class255.Class331 source2 = (Class255.Class331)dataTable_0;
			return !source2.First<Class255.Class437>().method_4() || !source2.First<Class255.Class437>().method_6() || !source2.First<Class255.Class437>().method_16() || !source2.First<Class255.Class437>().method_18() || !source2.First<Class255.Class437>().method_8() || !source2.First<Class255.Class437>().method_10() || !source2.First<Class255.Class437>().method_20() || !source2.First<Class255.Class437>().method_22() || !source2.First<Class255.Class437>().method_12() || !source2.First<Class255.Class437>().method_14() || !source2.First<Class255.Class437>().method_24() || !source2.First<Class255.Class437>().method_26();
		}
		if (dataTable_0 is Class255.Class313)
		{
			bool result = false;
			foreach (Class255.Class419 @class in ((Class255.Class313)dataTable_0))
			{
				result = (!@class.ziEntvHvSjj() || !@class.method_21() || !@class.method_23() || !@class.method_25() || !@class.method_27() || !@class.method_29() || !@class.method_31() || !@class.method_33() || !@class.method_35() || !@class.method_37());
			}
			return result;
		}
		if (dataTable_0 is Class255.Class333)
		{
			bool result2 = false;
			foreach (Class255.Class439 class2 in ((Class255.Class333)dataTable_0))
			{
				result2 = (!class2.method_2() || !class2.method_4() || !class2.method_6() || !class2.method_8() || !class2.method_10() || !class2.method_12() || !class2.method_14());
			}
			return result2;
		}
		return true;
	}

	public Class125()
	{
		
		
	}
}
