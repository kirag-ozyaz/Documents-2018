using System;
using System.Runtime.CompilerServices;
using DataSql;

namespace Documents.Forms.DocTamplateReference
{
	public class DoWorkAsyncArgs
	{
		public SQLSettings SqlSettings { get; set; }

		public int Id { get; set; }

		public int IdTemplate { get; set; }

		public string FileName { get; set; }

		public DoWorkAsyncArgs(SQLSettings settings, int idTemplate)
		{
			
			
			this.SqlSettings = settings;
			this.IdTemplate = idTemplate;
		}

		public DoWorkAsyncArgs(SQLSettings settings, int id, string fileName)
		{
			
			
			this.SqlSettings = settings;
			this.Id = id;
			this.FileName = fileName;
		}

		public DoWorkAsyncArgs(SQLSettings settings, int id, int idTemplate, string fileName)
		{
			
			
			this.SqlSettings = settings;
			this.Id = id;
			this.IdTemplate = idTemplate;
			this.FileName = fileName;
		}

		[CompilerGenerated]
		private SQLSettings sqlsettings_0;

		[CompilerGenerated]
		private int int_0;

		[CompilerGenerated]
		private int int_1;

		[CompilerGenerated]
		private string string_0;
	}
}
