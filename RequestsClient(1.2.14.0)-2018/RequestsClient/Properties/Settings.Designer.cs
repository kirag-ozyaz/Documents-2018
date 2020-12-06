using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace RequestsClient.Properties
{
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		[DebuggerNonUserCode]
		[DefaultSettingValue("Data Source=coder-sergey;Initial Catalog=GES;User ID=sasha;Password=\"cegth pfobnf\";Connect Timeout=60;Encrypt=False;TrustServerCertificate=True")]
		[SpecialSetting(SpecialSetting.ConnectionString)]
		[ApplicationScopedSetting]
		public string GESConnectionString
		{
			get
			{
				return (string)this["GESConnectionString"];
			}
		}

		private static Settings defaultInstance;
	}
}
