using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using DataSql;
using FormLbr;
using Microsoft.Office.Interop.Excel;

namespace GRP
{
	public partial class UnloadingGWC : FormBase
	{
		public UnloadingGWC()
		{
			
			
			this.method_4();
			Control.CheckForIllegalCrossThreadCalls = false;
			this.button_1.Click += this.button_3_Click;
			this.button_2.Click += this.button_3_Click;
			this.button_4.Click += this.button_3_Click;
			this.button_3.Click += this.button_3_Click;
		}

		private void button_3_Click(object sender, EventArgs e)
		{
			((System.Windows.Forms.Button)sender).Enabled = false;
			bool T1 = true;
			bool T2 = true;
			bool T3 = true;
			bool T5 = true;
			bool T6 = true;
			bool T7 = true;
			bool flag = true;
			bool T9 = true;
			if (this.checkBox_0.Checked)
			{
				T1 = false;
				new Thread(delegate
				{
					T1 = this.method_2(1, this.checkBox_0.Text, "Select * FROM fun_Abn_X1()", this.progressBar_0);
					this.method_1(this.button_1, new bool[]
					{
						T1,
						T7
					});
				}).Start();
			}
			if (this.checkBox_5.Checked)
			{
				T7 = false;
				object[] arr = new object[]
				{
					new UnloadingGWC.Struct0("@Date", SqlDbType.SmallDateTime, this.dateTimePicker_4.Value.Date)
				};
				new Thread(delegate
				{
					T7 = this.method_3(2, this.checkBox_5.Text, "Select * FROM fun_AbnObj_X7(@Date)", this.progressBar_5, arr);
					this.method_1(this.button_1, new bool[]
					{
						T1,
						T7
					});
				}).Start();
			}
			if (this.checkBox_2.Checked)
			{
				T5 = false;
				object[] arr = new object[]
				{
					new UnloadingGWC.Struct0("@Date", SqlDbType.SmallDateTime, this.dateTimePicker_0.Value.Date)
				};
				new Thread(delegate
				{
					T5 = this.method_3(5, this.checkBox_2.Text, "Select * FROM fun_AbnObj_Month_Value_X5(@Date)", this.progressBar_1, arr);
					this.method_1(this.button_4, new bool[]
					{
						T5
					});
				}).Start();
			}
			if (this.checkBox_1.Checked)
			{
				T3 = false;
				object[] arr = new object[]
				{
					new UnloadingGWC.Struct0("@DateBegin", SqlDbType.SmallDateTime, this.dateTimePicker_3.Value.Date),
					new UnloadingGWC.Struct0("@DateEnd", SqlDbType.SmallDateTime, this.dateTimePicker_2.Value.Date)
				};
				new Thread(delegate
				{
					T3 = this.method_3(3, this.checkBox_1.Text, "Select * FROM fun_Abn_Value_X4(@DateBegin , @DateEnd)", this.progressBar_2, arr);
					this.method_1(this.button_2, new bool[]
					{
						T3
					});
				}).Start();
			}
			if (this.checkBox_3.Checked)
			{
				T2 = false;
				object[] arr = new object[]
				{
					new UnloadingGWC.Struct0("@Year", SqlDbType.SmallDateTime, this.dateTimePicker_0.Value.Year)
				};
				new Thread(delegate
				{
					T2 = this.method_3(2, this.checkBox_3.Text, "Select * FROM fun_Abn_X2(@Year)", this.progressBar_3, arr);
					this.method_1(this.button_3, new bool[]
					{
						T2,
						T6
					});
				}).Start();
			}
			if (this.checkBox_4.Checked)
			{
				T6 = false;
				object[] arr = new object[]
				{
					new UnloadingGWC.Struct0("@Year", SqlDbType.SmallDateTime, this.dateTimePicker_0.Value.Year)
				};
				new Thread(delegate
				{
					T6 = this.method_3(6, this.checkBox_4.Text, "Select * FROM fun_AbnObj_X2(@Year)", this.progressBar_4, arr);
					this.method_1(this.button_3, new bool[]
					{
						T2,
						T6
					});
				}).Start();
			}
			if (this.checkBox_7.Checked)
			{
				object[] array = new object[]
				{
					new UnloadingGWC.Struct0("@DateBegin", SqlDbType.SmallDateTime, new DateTime(this.dateTimePicker_6.Value.Year, this.dateTimePicker_6.Value.Month, 1).ToString()),
					new UnloadingGWC.Struct0("@DateEnd", SqlDbType.SmallDateTime, new DateTime(this.dateTimePicker_6.Value.Year, this.dateTimePicker_6.Value.Month, DateTime.DaysInMonth(this.dateTimePicker_6.Value.Year, this.dateTimePicker_6.Value.Month)).ToString()),
					new UnloadingGWC.Struct0("@DateLast", SqlDbType.SmallDateTime, this.dateTimePicker_5.Value.Date)
				};
				flag = this.method_0(new bool[0]);
			}
			if (this.checkBox_6.Checked)
			{
				T9 = false;
				new Thread(delegate
				{
					this.method_1(this.button_5, new bool[]
					{
						T9
					});
				}).Start();
			}
			this.method_1(this.button_6, new bool[]
			{
				flag
			});
			this.method_1(this.button_5, new bool[]
			{
				T9
			});
			this.method_1(this.button_1, new bool[]
			{
				T1,
				T7
			});
			this.method_1(this.button_4, new bool[]
			{
				T5
			});
			this.method_1(this.button_2, new bool[]
			{
				T3
			});
			this.method_1(this.button_3, new bool[]
			{
				T2,
				T6
			});
			this.method_1(this.button_6, new bool[]
			{
				flag
			});
			this.method_1(this.button_5, new bool[]
			{
				T9
			});
			GC.Collect();
			GC.GetTotalMemory(true);
		}

		private bool method_0(params bool[] ListThread)
		{
			bool result;
			try
			{
				result = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Неудачная выгрузка!!!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				result = false;
			}
			return result;
		}

		private void method_1(System.Windows.Forms.Button button_7, params bool[] ListThread)
		{
			for (int i = 0; i < ListThread.Length; i++)
			{
				if (!ListThread[i])
				{
					button_7.Enabled = false;
					return;
				}
			}
			button_7.Enabled = true;
		}

		private bool method_2(int int_0, string string_0, string string_1, ProgressBar progressBar_6)
		{
			return this.method_3(int_0, string_0, string_1, progressBar_6, null);
		}

		private bool method_3(int int_0, string string_0, string string_1, ProgressBar progressBar_6, object[] object_0)
		{
			if (progressBar_6.Tag != null)
			{
				return false;
			}
			System.Data.DataTable dataTable = new System.Data.DataTable();
			Microsoft.Office.Interop.Excel.Application application = new ApplicationClass();
			application.SheetsInNewWorkbook = 1;
			application.Workbooks.Add(Type.Missing);
			Worksheet worksheet = (Worksheet)application.Workbooks[1].Worksheets.get_Item(1);
			SQLSettings sqlsettings = new SQLSettings(this.SqlSettings);
			sqlsettings.ServerDB = "192.168.8.252";
			sqlsettings.DBName = "Org";
			SqlDataConnect sqlDataConnect = new SqlDataConnect();
			sqlDataConnect.OpenConnection(sqlsettings);
			progressBar_6.Tag = 1;
			bool result;
			try
			{
				SqlCommand sqlCommand = new SqlCommand(string_1, sqlDataConnect.Connection);
				sqlCommand.CommandTimeout = 0;
				if (object_0 != null)
				{
					foreach (object obj in object_0)
					{
						sqlCommand.Parameters.AddWithValue(((UnloadingGWC.Struct0)obj).string_0, ((UnloadingGWC.Struct0)obj).object_1);
					}
				}
				new SqlDataAdapter
				{
					SelectCommand = sqlCommand
				}.Fill(dataTable);
				Range range = (Range)worksheet.Cells[1, 1];
				range.Value2 = string_0;
				for (int j = 1; j <= dataTable.Columns.Count; j++)
				{
					range = (Range)worksheet.Cells[2, j];
					range.Value2 = dataTable.Columns[j - 1].ColumnName;
				}
				progressBar_6.Maximum = dataTable.Rows.Count;
				int num = 1;
				foreach (object obj2 in dataTable.Rows)
				{
					DataRow dataRow = (DataRow)obj2;
					num++;
					foreach (object obj3 in dataTable.Columns)
					{
						DataColumn dataColumn = (DataColumn)obj3;
						range = (Range)worksheet.Cells[num + 1, dataColumn.Ordinal + 1];
						if (dataColumn.DataType == Type.GetType("System.String"))
						{
							range.NumberFormat = "@";
						}
						if (dataColumn.DataType == Type.GetType("System.DateTime"))
						{
							range.NumberFormat = "ДД.ММ.ГГГГ";
						}
						if (dataColumn.DataType == Type.GetType("System.Boolean"))
						{
							range.NumberFormat = "@";
						}
						range.Value2 = dataRow[dataColumn];
					}
					progressBar_6.Value = num - 1;
				}
				application.Visible = true;
				progressBar_6.Tag = null;
				result = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Неудачная выгрузка №" + int_0.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				application = null;
				progressBar_6.Tag = null;
				result = false;
			}
			finally
			{
				sqlDataConnect.CloseConnection();
			}
			return result;
		}

		private void button_0_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void label_0_Click(object sender, EventArgs e)
		{
		}

		private void method_4()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(UnloadingGWC));
			this.button_0 = new System.Windows.Forms.Button();
			this.label_0 = new System.Windows.Forms.Label();
			this.checkBox_0 = new System.Windows.Forms.CheckBox();
			this.checkBox_1 = new System.Windows.Forms.CheckBox();
			this.checkBox_2 = new System.Windows.Forms.CheckBox();
			this.progressBar_0 = new ProgressBar();
			this.progressBar_3 = new ProgressBar();
			this.checkBox_3 = new System.Windows.Forms.CheckBox();
			this.progressBar_2 = new ProgressBar();
			this.progressBar_1 = new ProgressBar();
			this.label_1 = new System.Windows.Forms.Label();
			this.dateTimePicker_0 = new DateTimePicker();
			this.checkBox_4 = new System.Windows.Forms.CheckBox();
			this.progressBar_4 = new ProgressBar();
			this.tabControl_0 = new TabControl();
			this.tabPage_0 = new TabPage();
			this.label_4 = new System.Windows.Forms.Label();
			this.dateTimePicker_4 = new DateTimePicker();
			this.button_1 = new System.Windows.Forms.Button();
			this.checkBox_5 = new System.Windows.Forms.CheckBox();
			this.progressBar_5 = new ProgressBar();
			this.tabPage_1 = new TabPage();
			this.IogenngvC = new System.Windows.Forms.Label();
			this.dateTimePicker_2 = new DateTimePicker();
			this.label_3 = new System.Windows.Forms.Label();
			this.dateTimePicker_3 = new DateTimePicker();
			this.button_4 = new System.Windows.Forms.Button();
			this.button_2 = new System.Windows.Forms.Button();
			this.tabPage_2 = new TabPage();
			this.button_3 = new System.Windows.Forms.Button();
			this.label_2 = new System.Windows.Forms.Label();
			this.dateTimePicker_1 = new DateTimePicker();
			this.tabPage_3 = new TabPage();
			this.checkBox_6 = new System.Windows.Forms.CheckBox();
			this.button_5 = new System.Windows.Forms.Button();
			this.checkBox_7 = new System.Windows.Forms.CheckBox();
			this.button_6 = new System.Windows.Forms.Button();
			this.label_5 = new System.Windows.Forms.Label();
			this.dateTimePicker_5 = new DateTimePicker();
			this.label_6 = new System.Windows.Forms.Label();
			this.dateTimePicker_6 = new DateTimePicker();
			this.tabControl_0.SuspendLayout();
			this.tabPage_0.SuspendLayout();
			this.tabPage_1.SuspendLayout();
			this.tabPage_2.SuspendLayout();
			this.tabPage_3.SuspendLayout();
			base.SuspendLayout();
			this.button_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.button_0.Location = new System.Drawing.Point(381, 215);
			this.button_0.Name = "btnClose";
			this.button_0.Size = new Size(81, 23);
			this.button_0.TabIndex = 1;
			this.button_0.Text = "Закрыть";
			this.button_0.UseVisualStyleBackColor = true;
			this.button_0.Click += this.button_0_Click;
			this.label_0.Dock = DockStyle.Top;
			this.label_0.Font = new System.Drawing.Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 204);
			this.label_0.Location = new System.Drawing.Point(0, 0);
			this.label_0.Name = "label1";
			this.label_0.Size = new Size(466, 24);
			this.label_0.TabIndex = 2;
			this.label_0.Text = "Выгрузка группы по работе с потребителями";
			this.label_0.Visible = false;
			this.label_0.Click += this.label_0_Click;
			this.checkBox_0.AutoSize = true;
			this.checkBox_0.Location = new System.Drawing.Point(6, 6);
			this.checkBox_0.Name = "checkBox1";
			this.checkBox_0.Size = new Size(286, 17);
			this.checkBox_0.TabIndex = 3;
			this.checkBox_0.Text = "Контактная информация по потребителям (файл 1)";
			this.checkBox_0.UseVisualStyleBackColor = true;
			this.checkBox_1.AutoSize = true;
			this.checkBox_1.Location = new System.Drawing.Point(9, 106);
			this.checkBox_1.Name = "checkBox3";
			this.checkBox_1.Size = new Size(227, 17);
			this.checkBox_1.TabIndex = 5;
			this.checkBox_1.Text = "Потребление по потребителям (файл 4)";
			this.checkBox_1.UseVisualStyleBackColor = true;
			this.checkBox_2.AutoSize = true;
			this.checkBox_2.Location = new System.Drawing.Point(9, 34);
			this.checkBox_2.Name = "checkBox5";
			this.checkBox_2.Size = new Size(273, 17);
			this.checkBox_2.TabIndex = 7;
			this.checkBox_2.Text = "Потребление по объектам потребления (файл 3)";
			this.checkBox_2.UseVisualStyleBackColor = true;
			this.progressBar_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.progressBar_0.Location = new System.Drawing.Point(292, 6);
			this.progressBar_0.Name = "progressBar1";
			this.progressBar_0.Size = new Size(155, 17);
			this.progressBar_0.TabIndex = 9;
			this.progressBar_3.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.progressBar_3.Location = new System.Drawing.Point(313, 37);
			this.progressBar_3.Name = "progressBar2";
			this.progressBar_3.Size = new Size(136, 17);
			this.progressBar_3.TabIndex = 16;
			this.checkBox_3.AutoSize = true;
			this.checkBox_3.Location = new System.Drawing.Point(6, 37);
			this.checkBox_3.Name = "checkBox2";
			this.checkBox_3.Size = new Size(250, 17);
			this.checkBox_3.TabIndex = 15;
			this.checkBox_3.Text = "Плановые объемы по потребителю (файл 5)";
			this.checkBox_3.UseVisualStyleBackColor = true;
			this.progressBar_2.Location = new System.Drawing.Point(87, 132);
			this.progressBar_2.Name = "progressBar3";
			this.progressBar_2.Size = new Size(358, 17);
			this.progressBar_2.TabIndex = 13;
			this.progressBar_1.Location = new System.Drawing.Point(87, 57);
			this.progressBar_1.Name = "progressBar5";
			this.progressBar_1.Size = new Size(358, 17);
			this.progressBar_1.TabIndex = 12;
			this.label_1.Location = new System.Drawing.Point(6, 11);
			this.label_1.Name = "label2";
			this.label_1.Size = new Size(55, 20);
			this.label_1.TabIndex = 9;
			this.label_1.Text = "Период:";
			this.dateTimePicker_0.CustomFormat = "MMMM yyyy";
			this.dateTimePicker_0.Format = DateTimePickerFormat.Custom;
			this.dateTimePicker_0.Location = new System.Drawing.Point(67, 9);
			this.dateTimePicker_0.Name = "dtOUT";
			this.dateTimePicker_0.Size = new Size(115, 20);
			this.dateTimePicker_0.TabIndex = 8;
			this.checkBox_4.AutoSize = true;
			this.checkBox_4.Location = new System.Drawing.Point(6, 60);
			this.checkBox_4.Name = "checkBox6";
			this.checkBox_4.Size = new Size(301, 17);
			this.checkBox_4.TabIndex = 17;
			this.checkBox_4.Text = "Плановые объемы по объектам потребителя (файл 6)";
			this.checkBox_4.UseVisualStyleBackColor = true;
			this.progressBar_4.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.progressBar_4.Location = new System.Drawing.Point(313, 60);
			this.progressBar_4.Name = "progressBar6";
			this.progressBar_4.Size = new Size(136, 17);
			this.progressBar_4.TabIndex = 18;
			this.tabControl_0.Controls.Add(this.tabPage_0);
			this.tabControl_0.Controls.Add(this.tabPage_1);
			this.tabControl_0.Controls.Add(this.tabPage_2);
			this.tabControl_0.Controls.Add(this.tabPage_3);
			this.tabControl_0.Location = new System.Drawing.Point(5, 27);
			this.tabControl_0.Name = "tabControl1";
			this.tabControl_0.SelectedIndex = 0;
			this.tabControl_0.Size = new Size(461, 184);
			this.tabControl_0.TabIndex = 12;
			this.tabPage_0.BackColor = SystemColors.Control;
			this.tabPage_0.Controls.Add(this.label_4);
			this.tabPage_0.Controls.Add(this.dateTimePicker_4);
			this.tabPage_0.Controls.Add(this.button_1);
			this.tabPage_0.Controls.Add(this.checkBox_0);
			this.tabPage_0.Controls.Add(this.progressBar_0);
			this.tabPage_0.Controls.Add(this.checkBox_5);
			this.tabPage_0.Controls.Add(this.progressBar_5);
			this.tabPage_0.Location = new System.Drawing.Point(4, 22);
			this.tabPage_0.Name = "tabPage1";
			this.tabPage_0.Padding = new Padding(3);
			this.tabPage_0.Size = new Size(453, 158);
			this.tabPage_0.TabIndex = 0;
			this.tabPage_0.Text = "Информация";
			this.label_4.Location = new System.Drawing.Point(6, 36);
			this.label_4.Name = "label6";
			this.label_4.Size = new Size(55, 20);
			this.label_4.TabIndex = 15;
			this.label_4.Text = "Период:";
			this.dateTimePicker_4.CustomFormat = "MMMM yyyy";
			this.dateTimePicker_4.Format = DateTimePickerFormat.Custom;
			this.dateTimePicker_4.Location = new System.Drawing.Point(67, 34);
			this.dateTimePicker_4.Name = "dtOutAbnObj";
			this.dateTimePicker_4.Size = new Size(115, 20);
			this.dateTimePicker_4.TabIndex = 14;
			this.button_1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.button_1.Location = new System.Drawing.Point(3, 129);
			this.button_1.Name = "btnInfo";
			this.button_1.Size = new Size(75, 23);
			this.button_1.TabIndex = 13;
			this.button_1.Text = "Выгрузка";
			this.button_1.UseVisualStyleBackColor = true;
			this.checkBox_5.AutoSize = true;
			this.checkBox_5.Location = new System.Drawing.Point(6, 59);
			this.checkBox_5.Name = "checkBox7";
			this.checkBox_5.Size = new Size(272, 17);
			this.checkBox_5.TabIndex = 7;
			this.checkBox_5.Text = "Информация по объектам потребления (файл 2)";
			this.checkBox_5.UseVisualStyleBackColor = true;
			this.progressBar_5.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.progressBar_5.Location = new System.Drawing.Point(292, 61);
			this.progressBar_5.Name = "progressBar7";
			this.progressBar_5.Size = new Size(155, 15);
			this.progressBar_5.TabIndex = 12;
			this.tabPage_1.BackColor = SystemColors.Control;
			this.tabPage_1.Controls.Add(this.IogenngvC);
			this.tabPage_1.Controls.Add(this.dateTimePicker_2);
			this.tabPage_1.Controls.Add(this.label_3);
			this.tabPage_1.Controls.Add(this.dateTimePicker_3);
			this.tabPage_1.Controls.Add(this.button_4);
			this.tabPage_1.Controls.Add(this.button_2);
			this.tabPage_1.Controls.Add(this.checkBox_1);
			this.tabPage_1.Controls.Add(this.progressBar_2);
			this.tabPage_1.Controls.Add(this.checkBox_2);
			this.tabPage_1.Controls.Add(this.progressBar_1);
			this.tabPage_1.Controls.Add(this.label_1);
			this.tabPage_1.Controls.Add(this.dateTimePicker_0);
			this.tabPage_1.Location = new System.Drawing.Point(4, 22);
			this.tabPage_1.Name = "tabPage2";
			this.tabPage_1.Padding = new Padding(3);
			this.tabPage_1.Size = new Size(453, 158);
			this.tabPage_1.TabIndex = 1;
			this.tabPage_1.Text = "Потребление";
			this.IogenngvC.Location = new System.Drawing.Point(191, 80);
			this.IogenngvC.Name = "label5";
			this.IogenngvC.Size = new Size(25, 20);
			this.IogenngvC.TabIndex = 20;
			this.IogenngvC.Text = "по:";
			this.IogenngvC.TextAlign = ContentAlignment.MiddleLeft;
			this.dateTimePicker_2.CustomFormat = "MMMM yyyy";
			this.dateTimePicker_2.Format = DateTimePickerFormat.Short;
			this.dateTimePicker_2.Location = new System.Drawing.Point(231, 80);
			this.dateTimePicker_2.Name = "dtEnd";
			this.dateTimePicker_2.Size = new Size(95, 20);
			this.dateTimePicker_2.TabIndex = 19;
			this.label_3.Location = new System.Drawing.Point(6, 80);
			this.label_3.Name = "label4";
			this.label_3.Size = new Size(75, 20);
			this.label_3.TabIndex = 18;
			this.label_3.Text = "Период с:";
			this.label_3.TextAlign = ContentAlignment.MiddleLeft;
			this.dateTimePicker_3.CustomFormat = "MMMM yyyy";
			this.dateTimePicker_3.Format = DateTimePickerFormat.Short;
			this.dateTimePicker_3.Location = new System.Drawing.Point(87, 80);
			this.dateTimePicker_3.Name = "dtBegin";
			this.dateTimePicker_3.Size = new Size(95, 20);
			this.dateTimePicker_3.TabIndex = 17;
			this.button_4.Location = new System.Drawing.Point(6, 55);
			this.button_4.Name = "btnOut1";
			this.button_4.Size = new Size(75, 23);
			this.button_4.TabIndex = 16;
			this.button_4.Text = "Выгрузка";
			this.button_4.UseVisualStyleBackColor = true;
			this.button_2.Location = new System.Drawing.Point(9, 129);
			this.button_2.Name = "btnOut";
			this.button_2.Size = new Size(75, 23);
			this.button_2.TabIndex = 15;
			this.button_2.Text = "Выгрузка";
			this.button_2.UseVisualStyleBackColor = true;
			this.tabPage_2.BackColor = SystemColors.Control;
			this.tabPage_2.Controls.Add(this.button_3);
			this.tabPage_2.Controls.Add(this.label_2);
			this.tabPage_2.Controls.Add(this.dateTimePicker_1);
			this.tabPage_2.Controls.Add(this.progressBar_4);
			this.tabPage_2.Controls.Add(this.checkBox_3);
			this.tabPage_2.Controls.Add(this.checkBox_4);
			this.tabPage_2.Controls.Add(this.progressBar_3);
			this.tabPage_2.Location = new System.Drawing.Point(4, 22);
			this.tabPage_2.Name = "tabPage3";
			this.tabPage_2.Padding = new Padding(3);
			this.tabPage_2.Size = new Size(453, 158);
			this.tabPage_2.TabIndex = 2;
			this.tabPage_2.Text = "Плановые объемы";
			this.button_3.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.button_3.Location = new System.Drawing.Point(3, 132);
			this.button_3.Name = "btnVolume";
			this.button_3.Size = new Size(75, 23);
			this.button_3.TabIndex = 21;
			this.button_3.Text = "Выгрузка";
			this.button_3.UseVisualStyleBackColor = true;
			this.label_2.Location = new System.Drawing.Point(6, 7);
			this.label_2.Name = "label3";
			this.label_2.Size = new Size(56, 20);
			this.label_2.TabIndex = 20;
			this.label_2.Text = "Период:";
			this.dateTimePicker_1.CustomFormat = "yyyy";
			this.dateTimePicker_1.Format = DateTimePickerFormat.Custom;
			this.dateTimePicker_1.Location = new System.Drawing.Point(93, 5);
			this.dateTimePicker_1.Name = "dtPlanVolum";
			this.dateTimePicker_1.Size = new Size(66, 20);
			this.dateTimePicker_1.TabIndex = 19;
			this.tabPage_3.Controls.Add(this.checkBox_6);
			this.tabPage_3.Controls.Add(this.button_5);
			this.tabPage_3.Controls.Add(this.checkBox_7);
			this.tabPage_3.Controls.Add(this.button_6);
			this.tabPage_3.Controls.Add(this.label_5);
			this.tabPage_3.Controls.Add(this.dateTimePicker_5);
			this.tabPage_3.Controls.Add(this.label_6);
			this.tabPage_3.Controls.Add(this.dateTimePicker_6);
			this.tabPage_3.Location = new System.Drawing.Point(4, 22);
			this.tabPage_3.Name = "tabPage4";
			this.tabPage_3.Padding = new Padding(3);
			this.tabPage_3.Size = new Size(453, 158);
			this.tabPage_3.TabIndex = 3;
			this.tabPage_3.Text = "Закрытие";
			this.tabPage_3.UseVisualStyleBackColor = true;
			this.checkBox_6.AutoSize = true;
			this.checkBox_6.Location = new System.Drawing.Point(179, 57);
			this.checkBox_6.Name = "checkBox9";
			this.checkBox_6.Size = new Size(204, 17);
			this.checkBox_6.TabIndex = 28;
			this.checkBox_6.Text = "Анализ по объектам потребителей";
			this.checkBox_6.UseVisualStyleBackColor = true;
			this.button_5.Location = new System.Drawing.Point(176, 80);
			this.button_5.Name = "btnAnalizAbnObj";
			this.button_5.Size = new Size(75, 23);
			this.button_5.TabIndex = 27;
			this.button_5.Text = "Выгрузка";
			this.button_5.UseVisualStyleBackColor = true;
			this.checkBox_7.AutoSize = true;
			this.checkBox_7.Location = new System.Drawing.Point(9, 57);
			this.checkBox_7.Name = "checkBox8";
			this.checkBox_7.Size = new Size(153, 17);
			this.checkBox_7.TabIndex = 26;
			this.checkBox_7.Text = "Анализ по потребителям";
			this.checkBox_7.UseVisualStyleBackColor = true;
			this.button_6.Location = new System.Drawing.Point(6, 80);
			this.button_6.Name = "btnAnalizAbn";
			this.button_6.Size = new Size(75, 23);
			this.button_6.TabIndex = 25;
			this.button_6.Text = "Выгрузка";
			this.button_6.UseVisualStyleBackColor = true;
			this.label_5.Location = new System.Drawing.Point(6, 34);
			this.label_5.Name = "label8";
			this.label_5.Size = new Size(124, 20);
			this.label_5.TabIndex = 24;
			this.label_5.Text = "Период прошлый:";
			this.dateTimePicker_5.CustomFormat = "MMMM yyyy";
			this.dateTimePicker_5.Format = DateTimePickerFormat.Custom;
			this.dateTimePicker_5.Location = new System.Drawing.Point(136, 34);
			this.dateTimePicker_5.Name = "dtLastAnaliz";
			this.dateTimePicker_5.Size = new Size(115, 20);
			this.dateTimePicker_5.TabIndex = 23;
			this.label_6.Location = new System.Drawing.Point(6, 12);
			this.label_6.Name = "label7";
			this.label_6.Size = new Size(124, 20);
			this.label_6.TabIndex = 22;
			this.label_6.Text = "Период текущий:";
			this.dateTimePicker_6.CustomFormat = "MMMM yyyy";
			this.dateTimePicker_6.Format = DateTimePickerFormat.Custom;
			this.dateTimePicker_6.Location = new System.Drawing.Point(136, 8);
			this.dateTimePicker_6.Name = "dtCurrentAnaliz";
			this.dateTimePicker_6.Size = new Size(115, 20);
			this.dateTimePicker_6.TabIndex = 21;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(466, 250);
			base.Controls.Add(this.tabControl_0);
			base.Controls.Add(this.label_0);
			base.Controls.Add(this.button_0);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "UnloadingGWC";
			this.Text = "Выгрузка группы по работе с потребителями";
			this.tabControl_0.ResumeLayout(false);
			this.tabPage_0.ResumeLayout(false);
			this.tabPage_0.PerformLayout();
			this.tabPage_1.ResumeLayout(false);
			this.tabPage_1.PerformLayout();
			this.tabPage_2.ResumeLayout(false);
			this.tabPage_2.PerformLayout();
			this.tabPage_3.ResumeLayout(false);
			this.tabPage_3.PerformLayout();
			base.ResumeLayout(false);
		}

		private System.Windows.Forms.Button button_0;

		private System.Windows.Forms.Label label_0;

		private System.Windows.Forms.CheckBox checkBox_0;

		private System.Windows.Forms.CheckBox checkBox_1;

		private System.Windows.Forms.CheckBox checkBox_2;

		private ProgressBar progressBar_0;

		private System.Windows.Forms.Label label_1;

		private DateTimePicker dateTimePicker_0;

		private ProgressBar progressBar_1;

		private ProgressBar progressBar_2;

		private ProgressBar progressBar_3;

		private System.Windows.Forms.CheckBox checkBox_3;

		private ProgressBar progressBar_4;

		private System.Windows.Forms.CheckBox checkBox_4;

		private TabControl tabControl_0;

		private TabPage tabPage_0;

		private TabPage tabPage_1;

		private System.Windows.Forms.CheckBox checkBox_5;

		private ProgressBar progressBar_5;

		private TabPage tabPage_2;

		private System.Windows.Forms.Label label_2;

		private DateTimePicker dateTimePicker_1;

		private System.Windows.Forms.Button button_1;

		private System.Windows.Forms.Button button_2;

		private System.Windows.Forms.Button button_3;

		private System.Windows.Forms.Button button_4;

		private System.Windows.Forms.Label IogenngvC;

		private DateTimePicker dateTimePicker_2;

		private System.Windows.Forms.Label label_3;

		private DateTimePicker dateTimePicker_3;

		private System.Windows.Forms.Label label_4;

		private DateTimePicker dateTimePicker_4;

		private TabPage tabPage_3;

		private System.Windows.Forms.CheckBox checkBox_6;

		private System.Windows.Forms.Button button_5;

		private System.Windows.Forms.CheckBox checkBox_7;

		private System.Windows.Forms.Button button_6;

		private System.Windows.Forms.Label label_5;

		private DateTimePicker dateTimePicker_5;

		private System.Windows.Forms.Label label_6;

		private DateTimePicker dateTimePicker_6;

		private struct Struct0
		{
			public Struct0(string string_1, object object_2, object object_3)
			{
				
				this.string_0 = string_1;
				this.object_0 = object_2;
				this.object_1 = object_3;
			}

			public string string_0;

			public object object_0;

			public object object_1;
		}
	}
}
