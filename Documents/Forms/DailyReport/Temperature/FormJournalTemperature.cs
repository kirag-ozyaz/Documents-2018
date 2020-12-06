using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ControlsLbr;
using ControlsLbr.DataGridViewExcelFilter;
using DataSql;
using Documents.Properties;
using FormLbr;

namespace Documents.Forms.DailyReport.Temperature
{
	public partial class FormJournalTemperature : FormBase
	{
		public FormJournalTemperature()
		{
			
			
			this.method_3();
			this.toolStripButton_7.Visible = false;
			this.dateTimePicker_1 = new DateTimePicker();
			this.dateTimePicker_1.Format = DateTimePickerFormat.Short;
			this.dateTimePicker_1.Value = new DateTime(DateTime.Now.Year + 1, 1, 1).AddDays(-1.0);
			this.dateTimePicker_1.Size = new Size(100, 20);
			ToolStripControlHost toolStripControlHost = new ToolStripControlHost(this.dateTimePicker_1);
			toolStripControlHost.Alignment = ToolStripItemAlignment.Right;
			this.toolStrip_0.Items.Add(toolStripControlHost);
			ToolStripLabel toolStripLabel = new ToolStripLabel("Дата до");
			toolStripLabel.Alignment = ToolStripItemAlignment.Right;
			this.toolStrip_0.Items.Add(toolStripLabel);
			this.dateTimePicker_0 = new DateTimePicker();
			this.dateTimePicker_0.Format = DateTimePickerFormat.Short;
			this.dateTimePicker_0.Value = new DateTime(DateTime.Now.Year, 1, 1);
			this.dateTimePicker_0.Size = new Size(100, 20);
			ToolStripControlHost toolStripControlHost2 = new ToolStripControlHost(this.dateTimePicker_0);
			toolStripControlHost2.Alignment = ToolStripItemAlignment.Right;
			this.toolStrip_0.Items.Add(toolStripControlHost2);
			ToolStripLabel toolStripLabel2 = new ToolStripLabel("Дата от");
			toolStripLabel2.Alignment = ToolStripItemAlignment.Right;
			this.toolStrip_0.Items.Add(toolStripLabel2);
		}

		private void FormJournalTemperature_Load(object sender, EventArgs e)
		{
			this.method_1(null);
		}

		private void method_0()
		{
			DataTable dataTable = new DataTable("tR_Classifier");
			dataTable.Columns.Add("id", typeof(int));
			dataTable.Columns.Add("name", typeof(string));
			base.SelectSqlData(dataTable, true, "where ParentKey = ';ReportDaily;WindDirect;' and isGroup = 0 and deleted = 0 order by name", null, false, 0);
			BindingSource bindingSource = new BindingSource();
			bindingSource.DataSource = dataTable;
			this.dataGridViewFilterComboBoxColumn_0.DisplayMember = "name";
			this.dataGridViewFilterComboBoxColumn_0.ValueMember = "id";
			this.dataGridViewFilterComboBoxColumn_0.DataSource = bindingSource;
		}

		private void method_1(int? nullable_0 = null)
		{
			this.method_0();
			if (nullable_0 == null && this.bindingSource_0.Current != null)
			{
				nullable_0 = new int?(Convert.ToInt32(((DataRowView)this.bindingSource_0.Current).Row["id"]));
			}
			base.SelectSqlData(this.class171_0.tJ_Temperature, true, string.Format("where dateTemp >= '{0}' and dateTEmp <= '{1}' order by datetemp desc", this.dateTimePicker_0.Value.ToString("yyyyMMdd"), this.dateTimePicker_1.Value.ToString("yyyyMMdd")), null, false, 0);
			if (nullable_0 != null)
			{
				this.dataGridViewExcelFilter_0.SearchGrid(this.dataGridViewTextBoxColumn_0.Name, nullable_0.ToString(), true);
			}
			this.chart_0.DataBind();
			this.chart_0.Update();
		}

		private void toolStripButton_0_Click(object sender, EventArgs e)
		{
			Form74 form = new Form74(null);
			form.MdiParent = base.MdiParent;
			form.SqlSettings = this.SqlSettings;
			form.FormClosed += this.method_2;
			form.Show();
		}

		private void method_2(object sender, FormClosedEventArgs e)
		{
			Form74 form = (Form74)sender;
			this.method_1(form.method_0());
		}

		private void toolStripButton_1_Click(object sender, EventArgs e)
		{
			if (this.bindingSource_0.Current == null)
			{
				MessageBox.Show("Не выбрана запись для редактирования", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			DataRow row = ((DataRowView)this.bindingSource_0.Current).Row;
			if (Convert.ToDateTime(row["dateTemp"]) < DateTime.Now.Date.AddDays(-2.0))
			{
				MessageBox.Show("Редактирование невозможно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			Form74 form = new Form74(new int?(Convert.ToInt32(row["id"])));
			form.MdiParent = base.MdiParent;
			form.SqlSettings = this.SqlSettings;
			form.FormClosed += this.method_2;
			form.Show();
		}

		private void toolStripButton_2_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_0.CurrentRow != null)
			{
				int id = Convert.ToInt32(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_0.Name].Value);
				if (base.DeleteSqlDataById(this.class171_0.tJ_Temperature, id))
				{
					this.dataGridViewExcelFilter_0.Rows.Remove(this.dataGridViewExcelFilter_0.CurrentRow);
					MessageBox.Show("Строка успешно удалена");
					return;
				}
			}
			else
			{
				MessageBox.Show("Не выбрана запись для удаления", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void toolStripButton_3_Click(object sender, EventArgs e)
		{
			this.method_1(null);
		}

		private void toolStripButton_4_Click(object sender, EventArgs e)
		{
			this.dataGridViewExcelFilter_0.SearchGrid(DataGridViewExcelFilter.TypeFind.Begin, this.toolStripTextBox_0.Text);
		}

		private void toolStripButton_5_Click(object sender, EventArgs e)
		{
			this.dataGridViewExcelFilter_0.SearchGrid(DataGridViewExcelFilter.TypeFind.Prev, this.toolStripTextBox_0.Text);
		}

		private void toolStripButton_6_Click(object sender, EventArgs e)
		{
			this.dataGridViewExcelFilter_0.SearchGrid(DataGridViewExcelFilter.TypeFind.Next, this.toolStripTextBox_0.Text);
		}

		private void toolStripTextBox_0_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				if (e.Modifiers == Keys.Shift)
				{
					this.dataGridViewExcelFilter_0.SearchGrid(DataGridViewExcelFilter.TypeFind.Prev, this.toolStripTextBox_0.Text);
				}
				if (e.Modifiers == Keys.NoName)
				{
					this.dataGridViewExcelFilter_0.SearchGrid(DataGridViewExcelFilter.TypeFind.Next, this.toolStripTextBox_0.Text);
				}
			}
		}

		private void dataGridViewExcelFilter_0_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && this.toolStripButton_1.Visible && this.toolStripButton_1.Enabled)
			{
				this.toolStripButton_1_Click(sender, e);
			}
		}

		private void toolStripButton_7_Click(object sender, EventArgs e)
		{
			using (SqlConnection sqlConnection = new SqlConnection(this.SqlSettings.GetConnectionString()))
			{
				sqlConnection.Open();
				SqlTransaction sqlTransaction = sqlConnection.BeginTransaction("LoadOldTemp");
				SqlCommand sqlCommand = sqlConnection.CreateCommand();
				sqlCommand.Connection = sqlConnection;
				sqlCommand.Transaction = sqlTransaction;
				try
				{
					sqlCommand.CommandText = "delete tJ_temperature ";
					sqlCommand.ExecuteNonQuery();
					sqlCommand.CommandText = "DBCC CHECKIDENT (tj_temperature, RESEED, 0)";
					sqlCommand.ExecuteNonQuery();
					DataTable dataTable = new SqlDataCommand(new SQLSettings("ulges-sql", "SR", "WINDOWS", "", "")).SelectSqlData("СоставительНизкого", false, "", null);
					sqlCommand.CommandText = "";
					List<DateTime> list = new List<DateTime>();
					foreach (object obj in dataTable.Rows)
					{
						DataRow dataRow = (DataRow)obj;
						if (dataRow["Дата1"] != DBNull.Value && !list.Contains(Convert.ToDateTime(dataRow["Дата1"])))
						{
							list.Add(Convert.ToDateTime(dataRow["Дата1"]));
							string text = "null";
							if (dataRow["Ветер"] != DBNull.Value)
							{
								string text2 = dataRow["Ветер"].ToString();
								uint num = PrivateImplementationDetails.ComputeStringHash(text2);
								if (num <= 1603275976u)
								{
									if (num <= 696002790u)
									{
										if (num != 45186588u)
										{
											if (num == 696002790u)
											{
												if (text2 == "юго-восточный")
												{
													text = "1608";
												}
											}
										}
										else if (text2 == "юго-западный")
										{
											text = "1606";
										}
									}
									else if (num != 1472010880u)
									{
										if (num == 1603275976u)
										{
											if (text2 == "восточный")
											{
												text = "1609";
											}
										}
									}
									else if (text2 == "южный")
									{
										text = "1607";
									}
								}
								else if (num <= 1710837092u)
								{
									if (num != 1707431918u)
									{
										if (num == 1710837092u)
										{
											if (text2 == "северо-западный")
											{
												text = "1604";
											}
										}
									}
									else if (text2 == "западный")
									{
										text = "1605";
									}
								}
								else if (num != 3493755726u)
								{
									if (num == 3496321677u)
									{
										if (text2 == "северный")
										{
											text = "1603";
										}
									}
								}
								else if (text2 == "северо-восточный")
								{
									text = "1610";
								}
							}
							SqlCommand sqlCommand2 = sqlCommand;
							sqlCommand2.CommandText += string.Format(" insert into tJ_Temperature(DateTEmp, NightDown, NightUp, DayDown, DayUp, \r\n                                                        TempAverage, wind, speeddown, speedup, comment, dateOwner, owner) \r\n                                                Values('{0}', {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11})", new object[]
							{
								Convert.ToDateTime(dataRow["Дата1"]).ToString("yyyyMMdd"),
								(dataRow["ТемператураНОт"] == DBNull.Value) ? "null" : dataRow["ТемператураНОт"].ToString(),
								(dataRow["ТемператураНДо"] == DBNull.Value) ? "null" : dataRow["ТемператураНДо"].ToString(),
								(dataRow["ТемператураДДо"] == DBNull.Value) ? "null" : dataRow["ТемператураДДо"].ToString(),
								(dataRow["ТемператураДДо"] == DBNull.Value) ? "null" : dataRow["ТемператураДДо"].ToString(),
								(dataRow["TemperatSrSut"] == DBNull.Value) ? "null" : dataRow["TemperatSrSut"].ToString(),
								text,
								(dataRow["СкоростьОт"] == DBNull.Value) ? "null" : dataRow["СкоростьОт"].ToString(),
								(dataRow["СкоростьДо"] == DBNull.Value) ? "null" : dataRow["СкоростьДо"].ToString(),
								(dataRow["Примечание"] == DBNull.Value) ? "null" : ("'" + dataRow["Примечание"].ToString() + "'"),
								(dataRow["Дата"] == DBNull.Value) ? "null" : ("'" + Convert.ToDateTime(dataRow["Дата"]).ToString("yyyyMMdd") + "'"),
								(dataRow["Составил"] == DBNull.Value) ? "null" : ("'" + dataRow["Составил"].ToString() + "'")
							});
						}
					}
					sqlCommand.ExecuteNonQuery();
					sqlTransaction.Commit();
					this.method_1(null);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, ex.Source);
					try
					{
						sqlTransaction.Rollback();
					}
					catch (Exception ex2)
					{
						MessageBox.Show(ex2.Message, ex2.Source);
					}
				}
			}
		}

		private void dataGridViewExcelFilter_0_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.RowIndex >= 0 && this.dataGridViewExcelFilter_0.Columns[this.dataGridViewFilterTextBoxColumn_0.Name].Index == e.ColumnIndex && (Convert.ToDateTime(this.dataGridViewExcelFilter_0[e.ColumnIndex, e.RowIndex].Value).DayOfWeek == DayOfWeek.Saturday || Convert.ToDateTime(this.dataGridViewExcelFilter_0[e.ColumnIndex, e.RowIndex].Value).DayOfWeek == DayOfWeek.Sunday))
			{
				e.CellStyle.ForeColor = Color.Red;
			}
		}

		private void method_3()
		{
			this.icontainer_0 = new Container();
			DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FormJournalTemperature));
			ChartArea chartArea = new ChartArea();
			ChartArea chartArea2 = new ChartArea();
			Legend legend = new Legend();
			Series series = new Series();
			Series series2 = new Series();
			Series series3 = new Series();
			this.toolStrip_0 = new ToolStrip();
			this.toolStripButton_0 = new ToolStripButton();
			this.toolStripButton_1 = new ToolStripButton();
			this.toolStripButton_2 = new ToolStripButton();
			this.toolStripSeparator_0 = new ToolStripSeparator();
			this.toolStripButton_3 = new ToolStripButton();
			this.toolStripSeparator_1 = new ToolStripSeparator();
			this.toolStripButton_4 = new ToolStripButton();
			this.toolStripTextBox_0 = new ToolStripTextBox();
			this.toolStripButton_5 = new ToolStripButton();
			this.toolStripButton_6 = new ToolStripButton();
			this.dataGridViewExcelFilter_0 = new DataGridViewExcelFilter();
			this.toolStripButton_7 = new ToolStripButton();
			this.bindingSource_0 = new BindingSource(this.icontainer_0);
			this.class171_0 = new Class171();
			this.dataGridViewFilterTextBoxColumn_0 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_1 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_2 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_3 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_4 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_5 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_6 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_7 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterComboBoxColumn_0 = new DataGridViewFilterComboBoxColumn();
			this.dataGridViewFilterTextBoxColumn_8 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_9 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_10 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_11 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_12 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_13 = new DataGridViewFilterTextBoxColumn();
			this.chart_0 = new Chart();
			this.tabControlVertical_0 = new TabControlVertical();
			this.tabPage_0 = new TabPage();
			this.tabPage_1 = new TabPage();
			this.toolStrip_0.SuspendLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_0).BeginInit();
			((ISupportInitialize)this.bindingSource_0).BeginInit();
			((ISupportInitialize)this.class171_0).BeginInit();
			((ISupportInitialize)this.chart_0).BeginInit();
			this.tabControlVertical_0.SuspendLayout();
			this.tabPage_0.SuspendLayout();
			this.tabPage_1.SuspendLayout();
			base.SuspendLayout();
			this.toolStrip_0.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripButton_0,
				this.toolStripButton_1,
				this.toolStripButton_2,
				this.toolStripSeparator_0,
				this.toolStripButton_3,
				this.toolStripSeparator_1,
				this.toolStripButton_4,
				this.toolStripTextBox_0,
				this.toolStripButton_5,
				this.toolStripButton_6,
				this.toolStripButton_7
			});
			this.toolStrip_0.Location = new Point(0, 0);
			this.toolStrip_0.Name = "toolStrip";
			this.toolStrip_0.Size = new Size(1327, 25);
			this.toolStrip_0.TabIndex = 0;
			this.toolStrip_0.Text = "toolStrip1";
			this.toolStripButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_0.Image = Resources.ElementAdd;
			this.toolStripButton_0.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_0.Name = "toolBtnAdd";
			this.toolStripButton_0.Size = new Size(23, 22);
			this.toolStripButton_0.Text = "toolStripButton1";
			this.toolStripButton_0.Click += this.toolStripButton_0_Click;
			this.toolStripButton_1.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_1.Image = Resources.ElementEdit;
			this.toolStripButton_1.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_1.Name = "toolBtnEdit";
			this.toolStripButton_1.Size = new Size(23, 22);
			this.toolStripButton_1.Text = "toolStripButton2";
			this.toolStripButton_1.Click += this.toolStripButton_1_Click;
			this.toolStripButton_2.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_2.Image = Resources.ElementDel;
			this.toolStripButton_2.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_2.Name = "toolBtnDel";
			this.toolStripButton_2.Size = new Size(23, 22);
			this.toolStripButton_2.Text = "toolStripButton3";
			this.toolStripButton_2.Click += this.toolStripButton_2_Click;
			this.toolStripSeparator_0.Name = "toolStripSeparator1";
			this.toolStripSeparator_0.Size = new Size(6, 25);
			this.toolStripButton_3.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_3.Image = Resources.refresh_16;
			this.toolStripButton_3.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_3.Name = "toolBtnRefresh";
			this.toolStripButton_3.Size = new Size(23, 22);
			this.toolStripButton_3.Text = "toolStripButton4";
			this.toolStripButton_3.Click += this.toolStripButton_3_Click;
			this.toolStripSeparator_1.Name = "toolStripSeparator2";
			this.toolStripSeparator_1.Size = new Size(6, 25);
			this.toolStripButton_4.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_4.Image = Resources.Find;
			this.toolStripButton_4.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_4.Name = "toolBtnFind";
			this.toolStripButton_4.Size = new Size(23, 22);
			this.toolStripButton_4.Text = "toolStripButton5";
			this.toolStripButton_4.Click += this.toolStripButton_4_Click;
			this.toolStripTextBox_0.Name = "txtFind";
			this.toolStripTextBox_0.Size = new Size(100, 25);
			this.toolStripTextBox_0.KeyDown += this.toolStripTextBox_0_KeyDown;
			this.toolStripButton_5.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_5.Image = Resources.FindPrev;
			this.toolStripButton_5.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_5.Name = "toolBtnFindPrev";
			this.toolStripButton_5.Size = new Size(23, 22);
			this.toolStripButton_5.Text = "toolStripButton6";
			this.toolStripButton_5.Click += this.toolStripButton_5_Click;
			this.toolStripButton_6.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_6.Image = Resources.FindNext;
			this.toolStripButton_6.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_6.Name = "toolBtnFindNext";
			this.toolStripButton_6.Size = new Size(23, 22);
			this.toolStripButton_6.Text = "toolStripButton7";
			this.toolStripButton_6.Click += this.toolStripButton_6_Click;
			this.dataGridViewExcelFilter_0.AllowUserToAddRows = false;
			this.dataGridViewExcelFilter_0.AllowUserToDeleteRows = false;
			this.dataGridViewExcelFilter_0.AllowUserToOrderColumns = true;
			dataGridViewCellStyle.BackColor = Color.FromArgb(224, 224, 224);
			this.dataGridViewExcelFilter_0.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle;
			this.dataGridViewExcelFilter_0.AutoGenerateColumns = false;
			this.dataGridViewExcelFilter_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewExcelFilter_0.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewFilterTextBoxColumn_0,
				this.dataGridViewTextBoxColumn_0,
				this.dataGridViewFilterTextBoxColumn_1,
				this.dataGridViewFilterTextBoxColumn_2,
				this.dataGridViewFilterTextBoxColumn_3,
				this.dataGridViewFilterTextBoxColumn_4,
				this.dataGridViewFilterTextBoxColumn_5,
				this.dataGridViewFilterTextBoxColumn_6,
				this.dataGridViewFilterTextBoxColumn_7,
				this.dataGridViewFilterComboBoxColumn_0,
				this.dataGridViewFilterTextBoxColumn_8,
				this.dataGridViewFilterTextBoxColumn_9,
				this.dataGridViewFilterTextBoxColumn_10,
				this.dataGridViewFilterTextBoxColumn_11,
				this.dataGridViewFilterTextBoxColumn_12,
				this.dataGridViewTextBoxColumn_1,
				this.dataGridViewFilterTextBoxColumn_13
			});
			this.dataGridViewExcelFilter_0.DataSource = this.bindingSource_0;
			this.dataGridViewExcelFilter_0.Dock = DockStyle.Fill;
			this.dataGridViewExcelFilter_0.Location = new Point(3, 3);
			this.dataGridViewExcelFilter_0.MultiSelect = false;
			this.dataGridViewExcelFilter_0.Name = "dgv";
			this.dataGridViewExcelFilter_0.ReadOnly = true;
			this.dataGridViewExcelFilter_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewExcelFilter_0.Size = new Size(1294, 470);
			this.dataGridViewExcelFilter_0.TabIndex = 1;
			this.dataGridViewExcelFilter_0.CellDoubleClick += this.dataGridViewExcelFilter_0_CellDoubleClick;
			this.dataGridViewExcelFilter_0.CellFormatting += this.dataGridViewExcelFilter_0_CellFormatting;
			this.toolStripButton_7.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_7.Image = (Image)componentResourceManager.GetObject("toolBtnLoadOldBase.Image");
			this.toolStripButton_7.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_7.Name = "toolBtnLoadOldBase";
			this.toolStripButton_7.Size = new Size(23, 22);
			this.toolStripButton_7.Text = "Загрузка из старой базы";
			this.toolStripButton_7.Click += this.toolStripButton_7_Click;
			this.bindingSource_0.DataMember = "tJ_Temperature";
			this.bindingSource_0.DataSource = this.class171_0;
			this.class171_0.DataSetName = "DataSetDamage";
			this.class171_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
			this.dataGridViewFilterTextBoxColumn_0.DataPropertyName = "DateTemp";
			this.dataGridViewFilterTextBoxColumn_0.HeaderText = "Дата";
			this.dataGridViewFilterTextBoxColumn_0.Name = "dateTempDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_0.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_0.Resizable = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_0.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_0.HeaderText = "id";
			this.dataGridViewTextBoxColumn_0.Name = "idDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_0.ReadOnly = true;
			this.dataGridViewTextBoxColumn_0.Visible = false;
			this.dataGridViewFilterTextBoxColumn_1.DataPropertyName = "Night";
			this.dataGridViewFilterTextBoxColumn_1.HeaderText = "t Ночью";
			this.dataGridViewFilterTextBoxColumn_1.Name = "nightColumn";
			this.dataGridViewFilterTextBoxColumn_1.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_1.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_2.DataPropertyName = "NightDown";
			this.dataGridViewFilterTextBoxColumn_2.HeaderText = "t Ночь От";
			this.dataGridViewFilterTextBoxColumn_2.Name = "nightDownDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_2.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_2.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_2.Visible = false;
			this.dataGridViewFilterTextBoxColumn_3.DataPropertyName = "NightUp";
			this.dataGridViewFilterTextBoxColumn_3.HeaderText = "t Ночь До";
			this.dataGridViewFilterTextBoxColumn_3.Name = "nightUpDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_3.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_3.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_3.Visible = false;
			this.dataGridViewFilterTextBoxColumn_4.DataPropertyName = "Day";
			this.dataGridViewFilterTextBoxColumn_4.HeaderText = "t Днем";
			this.dataGridViewFilterTextBoxColumn_4.Name = "dayColumn";
			this.dataGridViewFilterTextBoxColumn_4.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_5.DataPropertyName = "DayDown";
			this.dataGridViewFilterTextBoxColumn_5.HeaderText = "t День От";
			this.dataGridViewFilterTextBoxColumn_5.Name = "dayDownDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_5.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_5.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_5.Visible = false;
			this.dataGridViewFilterTextBoxColumn_6.DataPropertyName = "DayUp";
			this.dataGridViewFilterTextBoxColumn_6.HeaderText = "t День До";
			this.dataGridViewFilterTextBoxColumn_6.Name = "dayUpDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_6.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_6.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_6.Visible = false;
			this.dataGridViewFilterTextBoxColumn_7.DataPropertyName = "TempAverage";
			this.dataGridViewFilterTextBoxColumn_7.HeaderText = "t Средняя";
			this.dataGridViewFilterTextBoxColumn_7.Name = "tempAverageDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_7.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_7.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterComboBoxColumn_0.DataPropertyName = "Wind";
			this.dataGridViewFilterComboBoxColumn_0.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
			this.dataGridViewFilterComboBoxColumn_0.HeaderText = "Ветер";
			this.dataGridViewFilterComboBoxColumn_0.Name = "windDgvColumn";
			this.dataGridViewFilterComboBoxColumn_0.ReadOnly = true;
			this.dataGridViewFilterComboBoxColumn_0.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_8.DataPropertyName = "Speed";
			this.dataGridViewFilterTextBoxColumn_8.HeaderText = "Скорость ";
			this.dataGridViewFilterTextBoxColumn_8.Name = "speedColumn";
			this.dataGridViewFilterTextBoxColumn_8.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_9.DataPropertyName = "SpeedDown";
			this.dataGridViewFilterTextBoxColumn_9.HeaderText = "Скорость От";
			this.dataGridViewFilterTextBoxColumn_9.Name = "speedDownDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_9.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_9.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_9.Visible = false;
			this.dataGridViewFilterTextBoxColumn_10.DataPropertyName = "SpeedUp";
			this.dataGridViewFilterTextBoxColumn_10.HeaderText = "Скорость До";
			this.dataGridViewFilterTextBoxColumn_10.Name = "speedUpDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_10.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_10.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_10.Visible = false;
			this.dataGridViewFilterTextBoxColumn_11.DataPropertyName = "Comment";
			this.dataGridViewFilterTextBoxColumn_11.HeaderText = "Примечание";
			this.dataGridViewFilterTextBoxColumn_11.Name = "commentDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_11.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_11.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_12.DataPropertyName = "DateOwner";
			this.dataGridViewFilterTextBoxColumn_12.HeaderText = "Дата создания";
			this.dataGridViewFilterTextBoxColumn_12.Name = "dateOwnerDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_12.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_12.Resizable = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_1.DataPropertyName = "idOwner";
			this.dataGridViewTextBoxColumn_1.HeaderText = "idOwner";
			this.dataGridViewTextBoxColumn_1.Name = "idOwnerDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_1.ReadOnly = true;
			this.dataGridViewTextBoxColumn_1.Visible = false;
			this.dataGridViewFilterTextBoxColumn_13.DataPropertyName = "Owner";
			this.dataGridViewFilterTextBoxColumn_13.HeaderText = "Автор";
			this.dataGridViewFilterTextBoxColumn_13.Name = "ownerDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_13.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_13.Resizable = DataGridViewTriState.True;
			chartArea.AxisX.LabelStyle.Format = "MM.yyyy";
			chartArea.AxisX.LabelStyle.IntervalType = DateTimeIntervalType.Months;
			chartArea.Name = "ChartArea1";
			chartArea2.Name = "ChartArea2";
			this.chart_0.ChartAreas.Add(chartArea);
			this.chart_0.ChartAreas.Add(chartArea2);
			this.chart_0.DataSource = this.bindingSource_0;
			this.chart_0.Dock = DockStyle.Fill;
			legend.Name = "Legend1";
			this.chart_0.Legends.Add(legend);
			this.chart_0.Location = new Point(3, 3);
			this.chart_0.Name = "chartAbnObjPayment";
			this.chart_0.Palette = ChartColorPalette.Bright;
			series.BorderWidth = 2;
			series.ChartArea = "ChartArea1";
			series.ChartType = SeriesChartType.Line;
			series.Legend = "Legend1";
			series.LegendText = "t Ночью";
			series.Name = "Night";
			series.ToolTip = "#VALX \\n#VAL ℃";
			series.XValueMember = "DateTemp";
			series.YValueMembers = "NightDown, NightUp, DayDown, DayUp";
			series.YValuesPerPoint = 4;
			series2.BorderWidth = 2;
			series2.ChartArea = "ChartArea1";
			series2.ChartType = SeriesChartType.Line;
			series2.Legend = "Legend1";
			series2.LegendText = "t Днем";
			series2.Name = "Day";
			series2.ToolTip = "#VALX\\n#VAL℃";
			series2.XValueMember = "DateTemp";
			series2.XValueType = ChartValueType.Date;
			series2.YValueMembers = "DayDown, DayUp";
			series2.YValuesPerPoint = 2;
			series3.BorderWidth = 2;
			series3.ChartArea = "ChartArea2";
			series3.ChartType = SeriesChartType.Line;
			series3.Label = " ";
			series3.LabelToolTip = "#VAL";
			series3.Legend = "Legend1";
			series3.LegendText = "Скорость ветра";
			series3.Name = "Speed";
			series3.ToolTip = "#VALX\\n#VALм/с";
			series3.XValueMember = "DateTemp";
			series3.XValueType = ChartValueType.Date;
			series3.YValueMembers = "SpeedDown, SpeedUp";
			series3.YValuesPerPoint = 2;
			series3.YValueType = ChartValueType.Int32;
			this.chart_0.Series.Add(series);
			this.chart_0.Series.Add(series2);
			this.chart_0.Series.Add(series3);
			this.chart_0.Size = new Size(1294, 470);
			this.chart_0.TabIndex = 7;
			this.chart_0.Text = "chart1";
			this.tabControlVertical_0.Alignment = TabAlignment.Right;
			this.tabControlVertical_0.Controls.Add(this.tabPage_0);
			this.tabControlVertical_0.Controls.Add(this.tabPage_1);
			this.tabControlVertical_0.Dock = DockStyle.Fill;
			this.tabControlVertical_0.Location = new Point(0, 25);
			this.tabControlVertical_0.Multiline = true;
			this.tabControlVertical_0.Name = "tabControlVertical1";
			this.tabControlVertical_0.SelectedIndex = 0;
			this.tabControlVertical_0.Size = new Size(1327, 484);
			this.tabControlVertical_0.TabIndex = 8;
			this.tabPage_0.Controls.Add(this.dataGridViewExcelFilter_0);
			this.tabPage_0.Location = new Point(4, 4);
			this.tabPage_0.Name = "tabPage1";
			this.tabPage_0.Padding = new Padding(3);
			this.tabPage_0.Size = new Size(1300, 476);
			this.tabPage_0.TabIndex = 0;
			this.tabPage_0.Text = "Таблица";
			this.tabPage_0.UseVisualStyleBackColor = true;
			this.tabPage_1.Controls.Add(this.chart_0);
			this.tabPage_1.Location = new Point(4, 4);
			this.tabPage_1.Name = "tabPage2";
			this.tabPage_1.Padding = new Padding(3);
			this.tabPage_1.Size = new Size(1300, 476);
			this.tabPage_1.TabIndex = 1;
			this.tabPage_1.Text = "График";
			this.tabPage_1.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(1327, 509);
			base.Controls.Add(this.tabControlVertical_0);
			base.Controls.Add(this.toolStrip_0);
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "FormJournalTemperature";
			this.Text = "Архив погоды";
			base.Load += this.FormJournalTemperature_Load;
			this.toolStrip_0.ResumeLayout(false);
			this.toolStrip_0.PerformLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_0).EndInit();
			((ISupportInitialize)this.bindingSource_0).EndInit();
			((ISupportInitialize)this.class171_0).EndInit();
			((ISupportInitialize)this.chart_0).EndInit();
			this.tabControlVertical_0.ResumeLayout(false);
			this.tabPage_0.ResumeLayout(false);
			this.tabPage_1.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private DateTimePicker dateTimePicker_0;

		private DateTimePicker dateTimePicker_1;

		private ToolStrip toolStrip_0;

		private ToolStripButton toolStripButton_0;

		private ToolStripButton toolStripButton_1;

		private ToolStripButton toolStripButton_2;

		private ToolStripSeparator toolStripSeparator_0;

		private ToolStripButton toolStripButton_3;

		private ToolStripSeparator toolStripSeparator_1;

		private ToolStripButton toolStripButton_4;

		private ToolStripTextBox toolStripTextBox_0;

		private ToolStripButton toolStripButton_5;

		private ToolStripButton toolStripButton_6;

		private DataGridViewExcelFilter dataGridViewExcelFilter_0;

		private BindingSource bindingSource_0;

		private Class171 class171_0;

		private ToolStripButton toolStripButton_7;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_0;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_1;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_2;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_3;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_4;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_5;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_6;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_7;

		private DataGridViewFilterComboBoxColumn dataGridViewFilterComboBoxColumn_0;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_8;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_9;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_10;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_11;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_12;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_13;

		private Chart chart_0;

		private TabControlVertical tabControlVertical_0;

		private TabPage tabPage_0;

		private TabPage tabPage_1;
	}
}
