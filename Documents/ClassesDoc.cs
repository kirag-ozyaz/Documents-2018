using System;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using FormLbr;

namespace Documents
{
	public class ClassesDoc
	{
		public double GetDoubleFromString(string aStr)
		{
			aStr = aStr.Trim(new char[]
			{
				'(',
				')',
				' '
			});
			double result = 0.0;
			NumberFormatInfo numberFormatInfo = new NumberFormatInfo();
			if (!double.TryParse(aStr, NumberStyles.Float, numberFormatInfo, out result))
			{
				if (numberFormatInfo.NumberDecimalSeparator == ",")
				{
					numberFormatInfo.NumberDecimalSeparator = ".";
				}
				else if (numberFormatInfo.NumberDecimalSeparator == ".")
				{
					numberFormatInfo.NumberDecimalSeparator = ",";
				}
				if (!double.TryParse(aStr, NumberStyles.Float, numberFormatInfo, out result))
				{
					return -1.0;
				}
			}
			return result;
		}

		public decimal ReturnNumber(object param)
		{
			decimal result;
			try
			{
				new NumberFormatInfo();
				if (param.ToString().IndexOf(',') >= 0)
				{
					result = Convert.ToDecimal(param);
				}
				else if (param.ToString().IndexOf('.') >= 0)
				{
					result = Convert.ToDecimal(param.ToString().Replace('.', ','));
				}
				else
				{
					result = Convert.ToInt32(param);
				}
			}
			catch
			{
				result = 0m;
			}
			return result;
		}

		public void Show(Form owner, Type frmType, FormBase FormParent, int? id)
		{
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			Form0 form = null;
			foreach (FormBase formBase in owner.MdiChildren)
			{
				if (formBase.GetType() == frmType)
				{
					int id2 = ((Form0)formBase).Id;
					int? num = id;
					if (id2 == num.GetValueOrDefault())
					{
						bool flag = num != null;
					}
					form = (Form0)formBase;
					IL_61:
					if (form == null)
					{
						form = (executingAssembly.CreateInstance(frmType.FullName, false, BindingFlags.Instance | BindingFlags.Public | BindingFlags.CreateInstance, null, new object[]
						{
							id
						}, null, null) as Form0);
						form.MdiParent = owner;
						form.SqlSettings = FormParent.SqlSettings;
						form.FormBase_0 = FormParent;
						try
						{
							form.Show();
							goto IL_BA;
						}
						catch
						{
							goto IL_BA;
						}
					}
					form.Activate();
					IL_BA:
					if (form.WindowState != FormWindowState.Maximized)
					{
						form.WindowState = FormWindowState.Normal;
					}
					else
					{
						form.WindowState = FormWindowState.Maximized;
					}
					if (!form.Visible)
					{
						form.Visible = true;
					}
					return;
				}
			}
			goto IL_61;
		}

		public ClassesDoc()
		{
			
			
		}

		public class Parametry
		{
			public object Id { get; set; }

			public object Name { get; set; }

			public Parametry()
			{
				
				
			}

			[CompilerGenerated]
			private object object_0;

			[CompilerGenerated]
			private object object_1;
		}

		public class ParametryColumnsDataGridView
		{
			public ParametryColumnsDataGridView()
			{
				
				this.bool_0 = true;
				
			}

			public ParametryColumnsDataGridView(object Column, string Name, bool Visible)
			{
				
				this.bool_0 = true;
				
				this.object_0 = Column;
				this.string_0 = Name;
				this.bool_0 = Visible;
			}

			public ParametryColumnsDataGridView(object Column, string Name)
			{
				
				this.bool_0 = true;
				
				this.object_0 = Column;
				this.string_0 = Name;
				this.bool_0 = true;
			}

			public object Column
			{
				get
				{
					return this.object_0;
				}
				set
				{
					this.object_0 = value;
				}
			}

			public string Name
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

			public bool Visible
			{
				get
				{
					return this.bool_0;
				}
				set
				{
					this.bool_0 = value;
				}
			}

			public object DataSource
			{
				get
				{
					return this.object_1;
				}
				set
				{
					this.object_1 = value;
				}
			}

			public string DisplayMember
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

			public string ValueMember
			{
				get
				{
					return this.string_2;
				}
				set
				{
					this.string_2 = value;
				}
			}

			public ParametryColumnsDataGridView(object Column, string Name, bool Visible, object DataSource, string DisplayMember, string ValueMember)
			{
				
				this.bool_0 = true;
				
				this.object_0 = Column;
				this.string_0 = Name;
				this.bool_0 = Visible;
				this.object_1 = DataSource;
				this.string_1 = DisplayMember;
				this.string_2 = ValueMember;
			}

			private object object_0;

			private string string_0;

			private bool bool_0;

			private object object_1;

			private string string_1;

			private string string_2;
		}
	}
}
