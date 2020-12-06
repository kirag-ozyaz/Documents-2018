using System;

namespace Documents.Forms.DailyReport.Reports
{
	public class Approver
	{
		public Approver()
		{
			
			this.string_0 = string.Empty;
			this.string_1 = string.Empty;
			
			this.string_0 = string.Empty;
			this.string_1 = string.Empty;
		}

		public Approver(string Name, string Post)
		{
			
			this.string_0 = string.Empty;
			this.string_1 = string.Empty;
			
			this.string_1 = Name;
			this.string_0 = Post;
		}

		public Approver(Approver appr)
		{
			
			this.string_0 = string.Empty;
			this.string_1 = string.Empty;
			
			this.string_1 = appr.Name;
			this.string_0 = appr.Post;
		}

		public string Name
		{
			get
			{
				return this.string_1;
			}
			set
			{
				this.string_1 = value;
			}
		}

		public string Post
		{
			get
			{
				return this.string_0;
			}
			set
			{
				this.string_0 = value;
			}
		}

		private string string_0;

		private string string_1;
	}
}
