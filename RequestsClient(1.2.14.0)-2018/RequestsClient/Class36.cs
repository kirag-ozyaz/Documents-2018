using System;
using System.Diagnostics;
using System.IO;

internal static class Class36
{
	internal static void smethod_0(string string_0, string string_1, string string_2, string string_3, string string_4, string string_5, string string_6, string string_7)
	{
		new Process
		{
			StartInfo = 
			{
				UseShellExecute = false,
				CreateNoWindow = true,
				FileName = string_0,
				WorkingDirectory = Path.GetDirectoryName(string_0),
				Arguments = (string.IsNullOrEmpty(string_6) ? "" : string.Format(" -U {0}:{1} ", string_6, string_7)) + (string.IsNullOrEmpty(string_5) ? "" : string.Format(" -x {0} ", string_5)) + string.Format(" -T {0} ftp://{1}:{2}@{3}", new object[]
				{
					string_4,
					string_2,
					string_3,
					string_1
				})
			}
		}.Start();
	}
}
