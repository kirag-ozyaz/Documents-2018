using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using ControlsLbr.DataGridViewExcelFilter;
using ControlsLbr.Scheme;
using DataSql;
using FormLbr;
using SchemeModel;

namespace Documents.Forms.DailyReport.JournalDamage
{
	public partial class FormJournalDamage : FormBase
	{
		public FormJournalDamage()
		{
			
			this.string_0 = "";
			this.int_0 = 400;
			
			this.method_11();
			this.toolStripDropDownButton_2.Visible = false;
		}

		public FormJournalDamage(List<int> checkedSubstation)
		{
			
			this.string_0 = "";
			this.int_0 = 400;
			
			this.method_11();
			this.list_0 = checkedSubstation;
			this.toolStripDropDownButton_2.Visible = false;
		}

		private void FormJournalDamage_Load(object sender, EventArgs e)
		{
			this.method_8();
			this.method_0();
			this.method_9();
			base.LoadFormConfig(null);
			this.method_1();
			this.treeViewSchmObjects_0.SqlSettings = this.SqlSettings;
			this.treeViewSchmObjects_0.Load(this.list_0);
			this.method_7(-1);
		}

		private void FormJournalDamage_FormClosed(object sender, FormClosedEventArgs e)
		{
			base.SaveFormConfig(null);
		}

		private void method_0()
		{
			this.dateTimePicker_1.Value = new DateTime(DateTime.Now.Year, 1, 1);
			this.dateTimePicker_0.Value = new DateTime(DateTime.Now.Year + 1, 1, 1).AddSeconds(-1.0);
			this.checkedListBox_0.Items.Clear();
			DataTable dataTable = new DataTable("tR_Classifier");
			dataTable.Columns.Add("id", typeof(int));
			dataTable.Columns.Add("name", typeof(string));
			dataTable.Columns.Add("socrname", typeof(string));
			base.SelectSqlData(dataTable, true, "where ParentKey = ';GroupWorker;DailyReport;' and isGroup = 0 and Deleted = 0", null, false, 0);
			foreach (object obj in dataTable.Rows)
			{
				DataRow dataRow = (DataRow)obj;
				this.checkedListBox_0.Items.Add(new FormJournalDamage.Struct10(Convert.ToInt32(dataRow["id"]), dataRow["SocrName"].ToString()), true);
			}
			this.treeViewSchmObjects_0.ClearTreeChecked();
			this.checkedListBox_1.Items.Clear();
			base.SelectSqlData(dataTable, true, "where ParentKey = ';GroupWorker;DailyReport;' and isGroup = 0 and Deleted = 0", null, false, 0);
			foreach (object obj2 in dataTable.Rows)
			{
				DataRow dataRow2 = (DataRow)obj2;
				this.checkedListBox_1.Items.Add(new FormJournalDamage.Struct10(Convert.ToInt32(dataRow2["id"]), dataRow2["SocrName"].ToString()), true);
			}
			base.SelectSqlData(dataTable, true, "where ParentKey = ';ReportDaily;DivisionApply;' and isGroup = 0 and Deleted = 0", null, false, 0);
			foreach (object obj3 in dataTable.Rows)
			{
				DataRow dataRow3 = (DataRow)obj3;
				this.checkedListBox_1.Items.Add(new FormJournalDamage.Struct10(Convert.ToInt32(dataRow3["id"]), dataRow3["Name"].ToString()), true);
			}
			this.checkedListBox_1.Items.Add(new FormJournalDamage.Struct10(-1, "Производственная лаборатория"), true);
		}

		private void method_1()
		{
			DataTable dataTable = new DataTable("tR_Classifier");
			dataTable.Columns.Add("id", typeof(int));
			dataTable.Columns.Add("name", typeof(string));
			base.SelectSqlData(dataTable, true, " where ParentKey = ';ReportDaily;TypeDoc;' and isgroup = 0 and deleted = 0", null, false, 0);
			foreach (object obj in dataTable.Rows)
			{
				DataRow dataRow = (DataRow)obj;
				ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
				toolStripMenuItem.Click += this.method_2;
				toolStripMenuItem.Text = dataRow["Name"].ToString();
				toolStripMenuItem.Tag = dataRow["id"];
				this.toolStripDropDownButton_0.DropDownItems.Add(toolStripMenuItem);
				ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem();
				toolStripMenuItem2.Click += this.method_2;
				toolStripMenuItem2.Text = dataRow["Name"].ToString();
				toolStripMenuItem2.Tag = dataRow["id"];
				this.toolStripMenuItem_8.DropDownItems.Add(toolStripMenuItem2);
			}
		}

		private void method_2(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
			if (toolStripMenuItem.Tag == null)
			{
				return;
			}
			this.method_3(Convert.ToInt32(toolStripMenuItem.Tag), -1, false);
		}

		private void toolStripMenuItem_9_Click(object sender, EventArgs e)
		{
			if (this.bindingSource_0.Current != null)
			{
				DataRow row = ((DataRowView)this.bindingSource_0.Current).Row;
				this.method_3(Convert.ToInt32(row["TypeDoc"]), Convert.ToInt32(row["id"]), false);
			}
		}

		private void toolStripMenuItem_10_Click(object sender, EventArgs e)
		{
			if (this.bindingSource_0.Current != null)
			{
				DataRow row = ((DataRowView)this.bindingSource_0.Current).Row;
				this.method_3(Convert.ToInt32(row["TypeDoc"]), Convert.ToInt32(row["id"]), true);
			}
		}

		private void method_3(int int_1, int int_2 = -1, bool bool_0 = false)
		{
			if (int_1 <= 1844)
			{
				switch (int_1)
				{
				case 1401:
					goto IL_C1;
				case 1402:
				{
					Form81 form = new Form81(int_2);
					form.SqlSettings = this.SqlSettings;
					form.MdiParent = base.MdiParent;
					form.method_2(bool_0);
					if (!bool_0)
					{
						form.FormClosed += this.method_4;
					}
					form.Show();
					return;
				}
				case 1403:
					break;
				default:
					if (int_1 != 1844)
					{
						return;
					}
					break;
				}
				Form83 form2 = new Form83(int_2, int_1);
				form2.SqlSettings = this.SqlSettings;
				form2.MdiParent = base.MdiParent;
				form2.method_2(bool_0);
				if (!bool_0)
				{
					form2.FormClosed += this.method_4;
				}
				form2.Show();
				return;
			}
			if (int_1 != 1874)
			{
				if (int_1 == 2254)
				{
					goto IL_C1;
				}
			}
			else
			{
				Form86 form3 = new Form86(new int?(int_2));
				form3.SqlSettings = this.SqlSettings;
				form3.MdiParent = base.MdiParent;
				form3.method_1(bool_0);
				form3.Show();
			}
			return;
			IL_C1:
			Form84 form4 = new Form84(int_2, (Enum20)int_1);
			form4.SqlSettings = this.SqlSettings;
			form4.MdiParent = base.MdiParent;
			form4.method_2(bool_0);
			if (!bool_0)
			{
				form4.FormClosed += this.method_4;
			}
			form4.Show();
		}

		private void method_4(object sender, FormClosedEventArgs e)
		{
			if (sender is Form && ((Form)sender).DialogResult == DialogResult.OK)
			{
				int int_ = -1;
				if (sender is Form84)
				{
					int_ = ((Form84)sender).method_0();
				}
				if (sender is Form83)
				{
					int_ = ((Form83)sender).method_0();
				}
				this.method_7(int_);
			}
		}

		private void toolStripMenuItem_11_Click(object sender, EventArgs e)
		{
			if (this.bindingSource_0.Current != null)
			{
				if (this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewFilterCheckBoxColumn_1.Name].Value != DBNull.Value && this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewFilterCheckBoxColumn_1.Name].Value != null && Convert.ToBoolean(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewFilterCheckBoxColumn_1.Name].Value))
				{
					MessageBox.Show("Невозможно удалить исполненный документ", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
				if ((Convert.ToInt32(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_13.Name].Value) == 1403 || Convert.ToInt32(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_13.Name].Value) == 1844) && this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_12.Name].Value != DBNull.Value && this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_12.Name].Value != null)
				{
					DataTable dataTable = new DataTable("VJ_Damage");
					dataTable.Columns.Add("Division", typeof(string));
					base.SelectSqlData(dataTable, true, " where id = " + this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_12.Name].Value.ToString(), null, false, 0);
					string str = "";
					if (dataTable.Rows.Count > 0 && dataTable.Rows[0]["Division"] != DBNull.Value)
					{
						str = dataTable.Rows[0]["division"].ToString();
					}
					MessageBox.Show("Для удаления данного документа обратитесь в службу " + str, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
				if (MessageBox.Show("Вы действительно хотите удалить выбранный документ и подчиненные данному документу?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					int num = Convert.ToInt32(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_14.Name].Value);
					if (base.DeleteSqlDataById(this.class171_0.tJ_Damage, num))
					{
						this.method_5(num);
						this.method_7(-1);
						MessageBox.Show("Документ успешно удален");
						return;
					}
				}
			}
			else
			{
				MessageBox.Show("Не выбран документ для удаления");
			}
		}

		private void method_5(int int_1)
		{
			try
			{
				using (SqlConnection sqlConnection = new SqlConnection(this.SqlSettings.GetConnectionString()))
				{
					sqlConnection.Open();
					using (SqlCommand sqlCommand = new SqlCommand())
					{
						sqlCommand.Connection = sqlConnection;
						sqlCommand.CommandText = string.Format("update tj_damage \r\n                                                          set idParent = null\r\n                                                          where idParent = {0} and isApply = 1", int_1);
						sqlCommand.ExecuteNonQuery();
						sqlCommand.CommandText = string.Format("delete tj_damage \r\n                                                          where idParent = {0} and (isApply = 0 or isApply is null)", int_1);
						sqlCommand.ExecuteNonQuery();
					}
					sqlConnection.Close();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, ex.Source);
			}
		}

		private void toolStripButton_10_Click(object sender, EventArgs e)
		{
			this.method_7(-1);
		}

		private void toolStripButton_11_Click(object sender, EventArgs e)
		{
			this.dataGridViewExcelFilter_0.SearchGrid(DataGridViewExcelFilter.TypeFind.Begin, this.toolStripTextBox_1.Text);
		}

		private void toolStripButton_12_Click(object sender, EventArgs e)
		{
			this.dataGridViewExcelFilter_0.SearchGrid(DataGridViewExcelFilter.TypeFind.Prev, this.toolStripTextBox_1.Text);
		}

		private void toolStripButton_13_Click(object sender, EventArgs e)
		{
			this.dataGridViewExcelFilter_0.SearchGrid(DataGridViewExcelFilter.TypeFind.Next, this.toolStripTextBox_1.Text);
		}

		private void toolStripTextBox_1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				if (e.Modifiers == Keys.None)
				{
					this.dataGridViewExcelFilter_0.SearchGrid(DataGridViewExcelFilter.TypeFind.Next, this.toolStripTextBox_1.Text);
				}
				if (e.Modifiers == Keys.Shift)
				{
					this.dataGridViewExcelFilter_0.SearchGrid(DataGridViewExcelFilter.TypeFind.Prev, this.toolStripTextBox_1.Text);
				}
			}
		}

		private void toolStripButton_15_Click(object sender, EventArgs e)
		{
			this.dataGridViewExcelFilter_0.ExportToExcel();
		}

		private void toolStripButton_16_Click(object sender, EventArgs e)
		{
			this.dataGridViewExcelFilter_0.PrintDataGridView();
		}

		private void toolStripButton_0_Click(object sender, EventArgs e)
		{
			this.method_7(-1);
		}

		private void toolStripButton_1_Click(object sender, EventArgs e)
		{
			this.method_0();
			this.dataGridViewExcelFilter_0.ClearFilter();
			this.method_7(-1);
		}

		private void toolStripButton_2_Click(object sender, EventArgs e)
		{
			this.dateTimePicker_1.Value = new DateTime(this.dateTimePicker_1.Value.Year - 1, this.dateTimePicker_1.Value.Month, this.dateTimePicker_1.Value.Day);
			this.dateTimePicker_0.Value = new DateTime(this.dateTimePicker_0.Value.Year - 1, this.dateTimePicker_0.Value.Month, this.dateTimePicker_0.Value.Day);
		}

		private void toolStripButton_3_Click(object sender, EventArgs e)
		{
			this.dateTimePicker_0.Value = new DateTime(this.dateTimePicker_0.Value.Year + 1, this.dateTimePicker_0.Value.Month, this.dateTimePicker_0.Value.Day);
			this.dateTimePicker_1.Value = new DateTime(this.dateTimePicker_1.Value.Year + 1, this.dateTimePicker_1.Value.Month, this.dateTimePicker_1.Value.Day);
		}

		private void dateTimePicker_1_ValueChanged(object sender, EventArgs e)
		{
			this.dateTimePicker_0.MinDate = this.dateTimePicker_1.Value;
		}

		private void dateTimePicker_0_ValueChanged(object sender, EventArgs e)
		{
			this.dateTimePicker_1.MaxDate = this.dateTimePicker_0.Value;
		}

		private void method_6(int int_1 = -1)
		{
			this.toolStrip_0.Enabled = false;
			this.toolStripProgressBar_0.Visible = true;
			this.splitContainer_0.Enabled = false;
			this.string_0 = this.bindingSource_0.Sort;
			this.bindingSource_0.Sort = string.Empty;
			this.bindingSource_0.DataMember = null;
			this.backgroundWorker_0.RunWorkerAsync(int_1);
		}

		private void backgroundWorker_0_DoWork(object sender, DoWorkEventArgs e)
		{
			string str = "";
			str = string.Format(" where (deleted = 0) and (dateDoc >= '{0}' and dateDoc < '{1}') ", this.dateTimePicker_1.Value.ToString("yyyyMMdd"), this.dateTimePicker_0.Value.AddDays(1.0).ToString("yyyyMMdd"));
			if (this.checkedListBox_0.CheckedItems.Count > 0 && this.checkedListBox_0.CheckedItems.Count < this.checkedListBox_0.Items.Count)
			{
				string text = "";
				foreach (object obj in this.checkedListBox_0.CheckedItems)
				{
					if (string.IsNullOrEmpty(text))
					{
						FormJournalDamage.Struct10 @struct = (FormJournalDamage.Struct10)obj;
						text = @struct.int_0.ToString();
					}
					else
					{
						string str2 = text;
						string str3 = ",";
						FormJournalDamage.Struct10 @struct = (FormJournalDamage.Struct10)obj;
						text = str2 + str3 + @struct.int_0.ToString();
					}
				}
				str += string.Format(" and (idDivision in ({0}))", text);
			}
			List<int> listChecked = this.treeViewSchmObjects_0.GetListChecked();
			if (listChecked.Count > 0)
			{
				string text2 = "";
				foreach (int num in listChecked)
				{
					if (string.IsNullOrEmpty(text2))
					{
						text2 = num.ToString();
					}
					else
					{
						text2 = text2 + "," + num.ToString();
					}
				}
				if (this.checkBox_0.Checked)
				{
					str += string.Format(" and (idSchmObj in ({0}) or idSub in ({0}))", text2);
				}
				else
				{
					str += string.Format(" and (idSchmObj in ({0}))", text2);
				}
			}
			if (this.checkedListBox_1.Items.Count > 0)
			{
				if (this.checkedListBox_1.CheckedItems.Count == 0)
				{
					str += " and (idDivisionApply is null and (isLaboratory is null or isLaboratory = 0)) ";
				}
				if (this.checkedListBox_1.CheckedItems.Count < this.checkedListBox_1.Items.Count)
				{
					bool flag = false;
					string text3 = "";
					foreach (object obj2 in this.checkedListBox_1.CheckedItems)
					{
						if (((FormJournalDamage.Struct10)obj2).int_0 == -1)
						{
							flag = true;
						}
						else if (string.IsNullOrEmpty(text3))
						{
							FormJournalDamage.Struct10 @struct = (FormJournalDamage.Struct10)obj2;
							text3 = @struct.int_0.ToString();
						}
						else
						{
							string str4 = text3;
							string str5 = ",";
							FormJournalDamage.Struct10 @struct = (FormJournalDamage.Struct10)obj2;
							text3 = str4 + str5 + @struct.int_0.ToString();
						}
					}
					if (string.IsNullOrEmpty(text3))
					{
						if (flag)
						{
							str += " and (IsLaboratory = 1 and typedoc in (1403,1844)) ";
						}
					}
					else if (flag)
					{
						str += string.Format(" and (idDivisionApply in ({0}) or (isLaboratory = 1 and typedoc in (1403,1844))\r\n                                                       or (idDivisionApply is null and (isLaboratory is null or isLaboratory = 0)))", text3);
					}
					else
					{
						str += string.Format(" and (idDivisionApply in ({0}) or\r\n                                                          (idDivisionApply is null and (isLaboratory is null or isLaboratory = 0)))", text3);
					}
				}
			}
			base.SelectSqlData(this.class171_0.vJ_Damage, true, str + " order by dateDoc desc", new int?(0), false, 0);
			e.Result = e.Argument;
		}

		private void backgroundWorker_0_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.toolStrip_0.Enabled = true;
			this.toolStripProgressBar_0.Visible = false;
			this.splitContainer_0.Enabled = true;
			this.bindingSource_0.DataMember = this.class171_0.vJ_Damage.TableName;
			this.bindingSource_0.Sort = this.string_0;
			if (e.Result != null && Convert.ToInt32(e.Result) > 0)
			{
				this.dataGridViewExcelFilter_0.SearchGrid(this.dataGridViewTextBoxColumn_14.Name, e.Result.ToString(), true);
			}
		}

		private void method_7(int int_1 = -1)
		{
			if (int_1 == -1 && this.dataGridViewExcelFilter_0.CurrentRow != null)
			{
				int_1 = Convert.ToInt32(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_14.Name].Value);
			}
			this.method_6(int_1);
		}

		private void dataGridViewExcelFilter_0_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
			{
				if (this.toolStripButton_4.Enabled && this.toolStripButton_4.Visible)
				{
					this.toolStripMenuItem_9_Click(sender, e);
					return;
				}
				if (this.toolStripButton_5.Enabled && this.toolStripButton_5.Visible)
				{
					this.toolStripMenuItem_10_Click(sender, e);
				}
			}
		}

		private void dataGridViewExcelFilter_0_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				if (this.dataGridViewExcelFilter_0[this.dataGridViewFilterCheckBoxColumn_1.Name, e.RowIndex].Value != DBNull.Value && this.dataGridViewExcelFilter_0[this.dataGridViewFilterCheckBoxColumn_1.Name, e.RowIndex].Value != null && Convert.ToBoolean(this.dataGridViewExcelFilter_0[this.dataGridViewFilterCheckBoxColumn_1.Name, e.RowIndex].Value))
				{
					e.CellStyle.ForeColor = Color.Green;
				}
				else
				{
					if (this.dataGridViewExcelFilter_0[this.dataGridViewFilterTextBoxColumn_34.Name, e.RowIndex].Value != DBNull.Value && this.dataGridViewExcelFilter_0[this.dataGridViewFilterTextBoxColumn_34.Name, e.RowIndex].Value != null)
					{
						DateTime dateTime = Convert.ToDateTime(this.dataGridViewExcelFilter_0[this.dataGridViewFilterTextBoxColumn_34.Name, e.RowIndex].Value);
						if (dateTime.Date.AddDays(1.0) < DateTime.Now)
						{
							e.CellStyle.ForeColor = Color.Red;
							if (e.ColumnIndex == this.dataGridViewFilterTextBoxColumn_36.Index)
							{
								e.CellStyle.ForeColor = Color.Gray;
								e.CellStyle.Font = new Font(e.CellStyle.Font.FontFamily, e.CellStyle.Font.Size - 1f, FontStyle.Italic);
								e.Value = "Просрочено на " + (DateTime.Now.Date - dateTime.Date).Days.ToString() + " дн.";
							}
						}
						else if (dateTime.Date == DateTime.Now.Date)
						{
							if (e.ColumnIndex == this.dataGridViewFilterTextBoxColumn_36.Index)
							{
								e.CellStyle.ForeColor = Color.Gray;
								e.CellStyle.Font = new Font(e.CellStyle.Font.FontFamily, e.CellStyle.Font.Size - 1f, FontStyle.Italic);
								e.Value = "Просрочится сегодня";
							}
						}
						else if (e.ColumnIndex == this.dataGridViewFilterTextBoxColumn_36.Index)
						{
							e.CellStyle.ForeColor = Color.Gray;
							e.CellStyle.Font = new Font(e.CellStyle.Font.FontFamily, e.CellStyle.Font.Size - 1f, FontStyle.Italic);
							e.Value = "Осталось по плану " + (dateTime.Date - DateTime.Now.Date).Days.ToString() + " дн.";
						}
					}
					if (this.dataGridViewExcelFilter_0[this.dataGridViewTextBoxColumn_16.Name, e.RowIndex].Value != DBNull.Value && this.dataGridViewExcelFilter_0[this.dataGridViewTextBoxColumn_15.Name, e.RowIndex].Value == DBNull.Value)
					{
						e.CellStyle.BackColor = Color.LightPink;
						if (e.ColumnIndex != this.dataGridViewFilterTextBoxColumn_36.Index)
						{
							e.CellStyle.ForeColor = Color.Red;
							e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
						}
					}
				}
				if (Convert.ToBoolean(this.dataGridViewExcelFilter_0[this.dataGridViewFilterCheckBoxColumn_2.Name, e.RowIndex].Value) && e.ColumnIndex == this.dataGridViewFilterTextBoxColumn_22.Index)
				{
					e.CellStyle.BackColor = Color.Orange;
				}
			}
		}

		private void dataGridViewExcelFilter_0_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
		{
			this.dataGridViewExcelFilter_0.AutoResizeRow(e.RowIndex);
		}

		private void dataGridViewExcelFilter_0_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Button == MouseButtons.Right)
			{
				this.contextMenuStrip_0.Show(Cursor.Position);
			}
		}

		private void toolStripButton_6_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(this.toolStripTextBox_0.Text))
			{
				this.treeViewSchmObjects_0.Find(this.toolStripTextBox_0.Text);
			}
		}

		private void toolStripButton_7_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(this.toolStripTextBox_0.Text))
			{
				this.treeViewSchmObjects_0.FindPrev(this.toolStripTextBox_0.Text);
			}
		}

		private void toolStripButton_8_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(this.toolStripTextBox_0.Text))
			{
				this.treeViewSchmObjects_0.FindNext(this.toolStripTextBox_0.Text);
			}
		}

		private void toolStripTextBox_0_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				Keys modifiers = e.Modifiers;
				if (modifiers != Keys.None)
				{
					if (modifiers != Keys.Shift)
					{
						return;
					}
					if (!string.IsNullOrEmpty(this.toolStripTextBox_0.Text))
					{
						this.treeViewSchmObjects_0.FindPrev(this.toolStripTextBox_0.Text);
					}
				}
				else if (!string.IsNullOrEmpty(this.toolStripTextBox_0.Text))
				{
					this.treeViewSchmObjects_0.FindNext(this.toolStripTextBox_0.Text);
					return;
				}
			}
		}

		private void toolStripMenuItem_0_Click(object sender, EventArgs e)
		{
			new Form78
			{
				SqlSettings = this.SqlSettings,
				MdiParent = base.MdiParent
			}.Show();
		}

		private void toolStripMenuItem_2_Click(object sender, EventArgs e)
		{
			new Form80
			{
				SqlSettings = this.SqlSettings,
				MdiParent = base.MdiParent
			}.Show();
		}

		private void toolStripMenuItem_3_Click(object sender, EventArgs e)
		{
			new Form76
			{
				SqlSettings = this.SqlSettings,
				MdiParent = base.MdiParent
			}.Show();
		}

		private void toolStripMenuItem_5_Click(object sender, EventArgs e)
		{
			new Form77
			{
				SqlSettings = this.SqlSettings,
				MdiParent = base.MdiParent
			}.Show();
		}

		private void toolStripMenuItem_14_Click(object sender, EventArgs e)
		{
			new Form79
			{
				SqlSettings = this.SqlSettings,
				MdiParent = base.MdiParent
			}.Show();
		}

		private void toolStripMenuItem_18_Click(object sender, EventArgs e)
		{
			new Form75
			{
				SqlSettings = this.SqlSettings,
				MdiParent = base.MdiParent
			}.Show();
		}

		private void toolStripMenuItem_1_Click(object sender, EventArgs e)
		{
			Class226.smethod_0(this.SqlSettings, new SQLSettings("ulges-sql", "SR4", "WINDOWS", "", ""));
			this.method_7(-1);
		}

		private void toolStripMenuItem_15_Click(object sender, EventArgs e)
		{
			Class223.smethod_0(this.SqlSettings);
			this.method_7(-1);
		}

		private void toolStripMenuItem_4_Click(object sender, EventArgs e)
		{
			Class224.smethod_0(this.SqlSettings);
			this.method_7(-1);
		}

		private void toolStripMenuItem_6_Click(object sender, EventArgs e)
		{
			try
			{
				using (SqlConnection sqlConnection = new SqlConnection(this.SqlSettings.GetConnectionString()))
				{
					try
					{
						sqlConnection.Open();
						SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
						try
						{
							DataTable dataTable = new DataTable();
							using (SqlCommand sqlCommand = new SqlCommand())
							{
								sqlCommand.Connection = sqlConnection;
								sqlCommand.Transaction = sqlTransaction;
								sqlCommand.CommandText = "select d.id, d.idSchmObj, d.dateDoc, dLv.iddamage, dlv.abnOff from tj_damage d\r\n\t                                                left join tj_damagelv dlv on dlv.iddamage = d.id\r\n                                                where d.typeDoc = 1401\r\n\t                                                    and d.idSchmObj is not null\r\n\t                                                    and d.datedoc >= '20150101'\r\n\t                                                    and dlv.abnOff is null\r\n                                            and d.id not in (48483, 48485, 48487,48615,48888,48897)";
								new SqlDataAdapter(sqlCommand).Fill(dataTable);
							}
							using (IEnumerator enumerator = dataTable.Rows.GetEnumerator())
							{
								while (enumerator.MoveNext())
								{
									DataRow dr = (DataRow)enumerator.Current;
									if (dr["dateDoc"] != DBNull.Value)
									{
										ElectricModel electricModel = new ElectricModel();
										electricModel.SqlSettings = this.SqlSettings;
										electricModel.LoadSchema(Convert.ToDateTime(dr["dateDoc"]));
										electricModel.PoweringReportForDrawObject(Convert.ToInt32(dr["idSchmObj"]), true);
										IEnumerable<ElectricObject> source = from obj in electricModel.Objects
										where obj.Id == Convert.ToInt32(dr["idSchmObj"])
										select obj;
										if (source.Count<ElectricObject>() > 0)
										{
											List<ElectricObject> list = electricModel.PoweringReportForDrawObject(source.First<ElectricObject>(), true, true);
											DataSet dataSet = new DataSet();
											DataTable dataTable2 = new DataTable("vL_SchmAbnFull");
											dataTable2.Columns.Add("idAbn", typeof(int));
											dataTable2.Columns.Add("idAbnObj", typeof(int));
											dataSet.Tables.Add(dataTable2);
											if (list.Count > 0)
											{
												string text = "";
												foreach (ElectricObject electricObject in list)
												{
													if (string.IsNullOrEmpty(text))
													{
														text = electricObject.Id.ToString();
													}
													else
													{
														text = text + "," + electricObject.Id.ToString();
													}
												}
												base.SelectSqlData(dataTable2, true, " where idSchmObj in (" + text + ") and abnActive = 1 and objactive = 1  group by idAbn, codeAbonent, nameAbn, typeAbn, idAbnObj, nameObj ", new int?(0), false, 0);
											}
											else
											{
												dataTable2.Clear();
											}
											DataTable dataTable3 = new DataTable("tj_damagelv");
											DataColumn dataColumn = dataTable3.Columns.Add("idDamage", typeof(int));
											dataTable3.Columns.Add("abnoff", typeof(string));
											dataTable3.PrimaryKey = new DataColumn[]
											{
												dataColumn
											};
											base.SelectSqlData(dataTable3, true, "where iddamage = " + dr["id"].ToString(), null, false, 0);
											if (dataTable3.Rows.Count == 0)
											{
												DataRow dataRow = dataTable3.NewRow();
												dataRow["idDamage"] = dr["id"];
												dataRow["abnOff"] = Class228.smethod_3(dataTable2).InnerXml;
												dataTable3.Rows.Add(dataRow);
												base.InsertSqlData(dataTable3);
											}
											else
											{
												dataTable3.Rows[0]["abnOff"] = Class228.smethod_3(dataTable2).InnerXml;
												dataTable3.Rows[0].EndEdit();
												base.UpdateSqlData(dataTable3);
											}
										}
									}
								}
							}
							sqlTransaction.Commit();
						}
						catch (Exception ex)
						{
							sqlTransaction.Rollback();
							MessageBox.Show(ex.Message, ex.Source);
						}
					}
					catch (Exception ex2)
					{
						MessageBox.Show(ex2.Message, ex2.Source);
					}
				}
			}
			catch (Exception ex3)
			{
				MessageBox.Show(ex3.Message, ex3.Source);
			}
		}

		private void toolStripMenuItem_7_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				Class222.smethod_0(openFileDialog.FileName, this.SqlSettings);
			}
		}

		private void toolStripMenuItem_16_Click(object sender, EventArgs e)
		{
			Class171 @class = new Class171();
			base.SelectSqlData(@class.tJ_Damage, true, " where TypeDoc = 1402", null, false, 0);
			base.SelectSqlData(@class.tJ_DamageHV, true, "", null, false, 0);
			foreach (DataRow dataRow in @class.tJ_Damage)
			{
				DataRow[] array = @class.tJ_DamageHV.Select("idDamage = " + dataRow["id"].ToString());
				if (array.Length != 0)
				{
					XmlDocument xmlDocument = new XmlDocument();
					if (dataRow["CommentXml"] != DBNull.Value)
					{
						try
						{
							xmlDocument.LoadXml(dataRow["CommentXml"].ToString());
							goto IL_1FA;
						}
						catch
						{
							goto IL_1FA;
						}
						goto IL_CB;
					}
					goto IL_1FA;
					IL_E3:
					XmlNode xmlNode2;
					XmlNode xmlNode = xmlNode2.SelectSingleNode("AbnOff");
					if (xmlNode != null)
					{
						xmlNode2.RemoveChild(xmlNode);
					}
					if (array[0]["AbnOff"] != DBNull.Value)
					{
						XmlDocument xmlDocument2 = new XmlDocument();
						xmlDocument2.LoadXml(array[0]["AbnOff"].ToString());
						XmlNode xmlNode3 = xmlDocument2.SelectSingleNode("AbnOff");
						if (xmlNode3 != null)
						{
							xmlNode2.AppendChild(xmlDocument.ImportNode(xmlNode3, true));
						}
					}
					XmlNode xmlNode4 = xmlNode2.SelectSingleNode("TransOff");
					if (xmlNode4 != null)
					{
						xmlNode2.RemoveChild(xmlNode4);
					}
					if (array[0]["TransOff"] != DBNull.Value)
					{
						XmlDocument xmlDocument3 = new XmlDocument();
						xmlDocument3.LoadXml(array[0]["TransOff"].ToString());
						XmlNode xmlNode5 = xmlDocument3.SelectSingleNode("TransOff");
						if (xmlNode5 != null)
						{
							xmlNode2.AppendChild(xmlDocument.ImportNode(xmlNode5, true));
						}
					}
					dataRow["CommentXml"] = xmlDocument.InnerXml;
					dataRow.EndEdit();
					base.UpdateSqlDataOnlyChange(@class.tJ_Damage);
					@class.tJ_Damage.AcceptChanges();
					continue;
					IL_1FA:
					xmlNode2 = xmlDocument.SelectSingleNode("Doc");
					if (xmlNode2 != null)
					{
						goto IL_E3;
					}
					IL_CB:
					xmlNode2 = xmlDocument.CreateElement("Doc");
					xmlDocument.AppendChild(xmlNode2);
					goto IL_E3;
				}
			}
		}

		private void toolStripMenuItem_17_Click(object sender, EventArgs e)
		{
			Class171 @class = new Class171();
			base.SelectSqlData(@class.tJ_Damage, true, " where TypeDoc = 1401", null, false, 0);
			base.SelectSqlData(@class.tJ_DamageLV, true, "", null, false, 0);
			foreach (DataRow dataRow in @class.tJ_Damage)
			{
				DataRow[] array = @class.tJ_DamageLV.Select("idDamage = " + dataRow["id"].ToString());
				if (array.Length != 0)
				{
					XmlDocument xmlDocument = new XmlDocument();
					if (dataRow["CommentXml"] != DBNull.Value)
					{
						try
						{
							xmlDocument.LoadXml(dataRow["CommentXml"].ToString());
							goto IL_189;
						}
						catch
						{
							goto IL_189;
						}
						goto IL_CB;
					}
					goto IL_189;
					IL_E3:
					XmlNode xmlNode2;
					XmlNode xmlNode = xmlNode2.SelectSingleNode("AbnOff");
					if (xmlNode != null)
					{
						xmlNode2.RemoveChild(xmlNode);
					}
					if (array[0]["AbnOff"] != DBNull.Value)
					{
						XmlDocument xmlDocument2 = new XmlDocument();
						xmlDocument2.LoadXml(array[0]["AbnOff"].ToString());
						XmlNode xmlNode3 = xmlDocument2.SelectSingleNode("AbnOff");
						if (xmlNode3 != null)
						{
							xmlNode2.AppendChild(xmlDocument.ImportNode(xmlNode3, true));
						}
					}
					dataRow["CommentXml"] = xmlDocument.InnerXml;
					dataRow.EndEdit();
					base.UpdateSqlDataOnlyChange(@class.tJ_Damage);
					@class.tJ_Damage.AcceptChanges();
					continue;
					IL_189:
					xmlNode2 = xmlDocument.SelectSingleNode("Doc");
					if (xmlNode2 != null)
					{
						goto IL_E3;
					}
					IL_CB:
					xmlNode2 = xmlDocument.CreateElement("Doc");
					xmlDocument.AppendChild(xmlNode2);
					goto IL_E3;
				}
			}
		}

		private void method_8()
		{
			DataTable dataTable = new DataTable("tUser");
			dataTable.Columns.Add("idUser", typeof(int));
			base.SelectSqlData(dataTable, true, " left join vworkergroup w on w.id = tuser.idWorker\r\n                                where w.ParentKey = ';GroupWorker;DailyReport;Admin;' and tuser.login = SYSTEM_USER", null, false, 0);
			if (dataTable.Rows.Count > 0)
			{
				this.toolStripButton_14.Visible = true;
				return;
			}
			this.toolStripButton_14.Visible = false;
		}

		private void toolStripButton_14_Click(object sender, EventArgs e)
		{
			if (this.bindingSource_0.Current != null)
			{
				if (this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewFilterCheckBoxColumn_1.Name].Value != DBNull.Value && this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewFilterCheckBoxColumn_1.Name].Value != null && Convert.ToBoolean(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewFilterCheckBoxColumn_1.Name].Value))
				{
					if (MessageBox.Show("Вы действительно хотите разблокировать текущий документ?", "Разблокировка", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
					{
						return;
					}
					int num = Convert.ToInt32(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_14.Name].Value);
					try
					{
						using (SqlConnection sqlConnection = new SqlConnection(this.SqlSettings.GetConnectionString()))
						{
							sqlConnection.Open();
							using (SqlCommand sqlCommand = new SqlCommand())
							{
								sqlCommand.Connection = sqlConnection;
								sqlCommand.CommandText = string.Format("update tj_damage \r\n                                                                  set isapply = 0\r\n                                                                   where id = {0}", num);
								if (sqlCommand.ExecuteNonQuery() > 0)
								{
									this.method_7(-1);
								}
							}
							sqlConnection.Close();
							MessageBox.Show("Документ успешно разблокирован");
						}
						return;
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, ex.Source);
						return;
					}
				}
				MessageBox.Show("Документ уже разблокирован");
			}
		}

		protected override XmlDocument CreateXmlConfig()
		{
			XmlDocument xmlDocument = new XmlDocument();
			XmlNode newChild = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", null);
			xmlDocument.AppendChild(newChild);
			XmlNode xmlNode = xmlDocument.CreateElement(base.Name);
			xmlDocument.AppendChild(xmlNode);
			foreach (object obj in this.checkedListBox_0.CheckedItems)
			{
				XmlNode xmlNode2 = xmlDocument.CreateElement("CheckDivision");
				XmlAttribute xmlAttribute = xmlDocument.CreateAttribute("Id");
				XmlNode xmlNode3 = xmlAttribute;
				FormJournalDamage.Struct10 @struct = (FormJournalDamage.Struct10)obj;
				xmlNode3.Value = @struct.int_0.ToString();
				xmlNode2.Attributes.Append(xmlAttribute);
				xmlNode.AppendChild(xmlNode2);
			}
			XmlNode xmlNode4 = xmlDocument.CreateElement("DivisionApply");
			xmlNode.AppendChild(xmlNode4);
			foreach (object obj2 in this.checkedListBox_1.CheckedItems)
			{
				XmlNode xmlNode5 = xmlDocument.CreateElement("CheckDivisionApply");
				XmlAttribute xmlAttribute2 = xmlDocument.CreateAttribute("Id");
				XmlNode xmlNode6 = xmlAttribute2;
				FormJournalDamage.Struct10 @struct = (FormJournalDamage.Struct10)obj2;
				xmlNode6.Value = @struct.int_0.ToString();
				xmlNode5.Attributes.Append(xmlAttribute2);
				xmlNode4.AppendChild(xmlNode5);
			}
			XmlAttribute xmlAttribute3 = xmlDocument.CreateAttribute("dateBeg");
			xmlAttribute3.Value = this.dateTimePicker_1.Value.ToString();
			xmlNode.Attributes.Append(xmlAttribute3);
			xmlAttribute3 = xmlDocument.CreateAttribute("dateEnd");
			xmlAttribute3.Value = this.dateTimePicker_0.Value.ToString();
			xmlNode.Attributes.Append(xmlAttribute3);
			return xmlDocument;
		}

		protected override void ApplyConfig(XmlDocument doc)
		{
			List<int> list = new List<int>();
			List<int> list2 = new List<int>();
			XmlNode xmlNode = doc.SelectSingleNode(base.Name);
			if (xmlNode == null)
			{
				return;
			}
			foreach (object obj in xmlNode.SelectNodes("CheckDivision"))
			{
				XmlAttribute xmlAttribute = ((XmlNode)obj).Attributes["Id"];
				if (xmlAttribute != null)
				{
					list.Add(Convert.ToInt32(xmlAttribute.Value));
				}
			}
			for (int i = 0; i < this.checkedListBox_0.Items.Count; i++)
			{
				if (list.Contains(((FormJournalDamage.Struct10)this.checkedListBox_0.Items[i]).int_0))
				{
					this.checkedListBox_0.SetItemChecked(i, true);
				}
				else
				{
					this.checkedListBox_0.SetItemChecked(i, false);
				}
			}
			XmlNode xmlNode2 = xmlNode.SelectSingleNode("DivisionApply");
			if (xmlNode2 != null)
			{
				foreach (object obj2 in xmlNode2.SelectNodes("CheckDivisionApply"))
				{
					XmlAttribute xmlAttribute2 = ((XmlNode)obj2).Attributes["Id"];
					if (xmlAttribute2 != null)
					{
						list2.Add(Convert.ToInt32(xmlAttribute2.Value));
					}
				}
				for (int j = 0; j < this.checkedListBox_1.Items.Count; j++)
				{
					if (list2.Contains(((FormJournalDamage.Struct10)this.checkedListBox_1.Items[j]).int_0))
					{
						this.checkedListBox_1.SetItemChecked(j, true);
					}
					else
					{
						this.checkedListBox_1.SetItemChecked(j, false);
					}
				}
			}
			XmlAttribute xmlAttribute3 = xmlNode.Attributes["dateBeg"];
			if (xmlAttribute3.Value != null)
			{
				this.dateTimePicker_1.Value = Convert.ToDateTime(xmlAttribute3.Value);
			}
			xmlAttribute3 = xmlNode.Attributes["dateEnd"];
			if (xmlAttribute3.Value != null)
			{
				this.dateTimePicker_0.Value = Convert.ToDateTime(xmlAttribute3.Value);
			}
		}

		private void contextMenuStrip_0_Opening(object sender, CancelEventArgs e)
		{
			if (this.bindingSource_0.Current == null)
			{
				this.toolStripMenuItem_9.Enabled = false;
				this.toolStripMenuItem_10.Enabled = false;
				this.toolStripMenuItem_11.Enabled = false;
				this.toolStripMenuItem_12.Visible = false;
				return;
			}
			this.toolStripMenuItem_9.Enabled = true;
			this.toolStripMenuItem_10.Enabled = true;
			this.toolStripMenuItem_11.Enabled = true;
			if (Convert.ToInt32(((DataRowView)this.bindingSource_0.Current).Row["TypeDoc"]) == 1402)
			{
				this.toolStripMenuItem_12.Visible = true;
				return;
			}
			this.toolStripMenuItem_12.Visible = false;
		}

		private void toolStripMenuItem_13_Click(object sender, EventArgs e)
		{
			if (this.bindingSource_0.Current != null)
			{
				DataRow row = ((DataRowView)this.bindingSource_0.Current).Row;
				if (Convert.ToInt32(row["TypeDoc"]) == 1402)
				{
					int value = Convert.ToInt32(row["id"]);
					Form87 form = new Form87(new int?(value), null, null);
					form.SqlSettings = this.SqlSettings;
					if (form.ShowDialog() == DialogResult.OK)
					{
						new Form86(new int?(value), form.method_0().ToList<int>())
						{
							SqlSettings = this.SqlSettings,
							MdiParent = base.MdiParent
						}.Show();
					}
				}
			}
		}

		private void method_9()
		{
			this.splitContainer_1.SplitterDistance = this.splitContainer_1.Height - this.splitContainer_1.SplitterWidth - this.label_3.Height;
			this.splitContainer_1.IsSplitterFixed = true;
		}

		private void label_3_Click(object sender, EventArgs e)
		{
			if (this.label_3.Cursor == Cursors.PanNorth)
			{
				this.splitContainer_1.SplitterDistance = this.int_0;
				this.splitContainer_1.IsSplitterFixed = false;
				this.label_3.Cursor = Cursors.PanSouth;
				return;
			}
			if (this.label_3.Cursor == Cursors.PanSouth)
			{
				this.int_0 = this.splitContainer_1.SplitterDistance;
				this.splitContainer_1.SplitterDistance = this.splitContainer_1.Height - this.splitContainer_1.SplitterWidth - this.label_3.Height;
				this.splitContainer_1.IsSplitterFixed = true;
				this.label_3.Cursor = Cursors.PanNorth;
			}
		}

		private void method_10()
		{
			if (this.bindingSource_0.Current != null && this.bindingSource_0.Current is DataRowView)
			{
				this.dataTable_0.Clear();
				Convert.ToInt32(((DataRowView)this.bindingSource_0.Current).Row["id"]);
				try
				{
					using (SqlConnection sqlConnection = new SqlConnection(this.SqlSettings.GetConnectionString()))
					{
						sqlConnection.Open();
						if (((DataRowView)this.bindingSource_0.Current).Row["idParent"] != DBNull.Value)
						{
							using (SqlCommand sqlCommand = new SqlCommand())
							{
								sqlCommand.CommandText = " select id, typeDoc, typedocName, \r\n                                                      numRequest as numDoc, dateDoc, idReqForRepair, (1) as isParent\r\n                                                    from vj_damage \r\n                                                    where id = " + ((DataRowView)this.bindingSource_0.Current).Row["idParent"] + " and deleted = 0 ";
								sqlCommand.Connection = sqlConnection;
								new SqlDataAdapter(sqlCommand).Fill(this.dataTable_0);
							}
						}
						if (this.dataTable_0.Rows.Count > 0 && this.dataTable_0.Rows[0]["idReqForRepair"] != DBNull.Value)
						{
							using (SqlCommand sqlCommand2 = new SqlCommand())
							{
								sqlCommand2.CommandText = " select id, -1 as typeDoc, 'Аварийная заявка' as typedocName, \r\n                                                      num as numDoc, datecreate as dateDoc, null as idReqForRepair, (1) as isParent\r\n                                                    from tJ_RequestForRepair \r\n                                                    where id = " + this.dataTable_0.Rows[0]["idReqForRepair"].ToString() + " and deleted = 0 ";
								sqlCommand2.Connection = sqlConnection;
								new SqlDataAdapter(sqlCommand2).Fill(this.dataTable_0);
							}
						}
						if (((DataRowView)this.bindingSource_0.Current).Row["idReqForRepair"] != DBNull.Value)
						{
							using (SqlCommand sqlCommand3 = new SqlCommand())
							{
								sqlCommand3.CommandText = " select id, -1 as typeDoc, 'Аварийная заявка' as typedocName, \r\n                                                      num as numDoc, datecreate as dateDoc, null as idReqForRepair, (1) as isParent\r\n                                                    from tJ_RequestForRepair \r\n                                                    where id = " + ((DataRowView)this.bindingSource_0.Current).Row["idReqForRepair"] + " and deleted = 0 ";
								sqlCommand3.Connection = sqlConnection;
								new SqlDataAdapter(sqlCommand3).Fill(this.dataTable_0);
							}
						}
						using (SqlCommand sqlCommand4 = new SqlCommand())
						{
							sqlCommand4.CommandText = " select id, typeDoc, typedocName, \r\n                                                      numRequest as numDoc, dateDoc\r\n                                                    from vj_damage \r\n                                                    where idParent = " + ((DataRowView)this.bindingSource_0.Current).Row["id"] + " and deleted = 0 ";
							sqlCommand4.Connection = sqlConnection;
							new SqlDataAdapter(sqlCommand4).Fill(this.dataTable_0);
						}
					}
					return;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, ex.Source);
					return;
				}
			}
			this.dataTable_0.Clear();
		}

		private void dataGridViewExcelFilter_1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && this.bindingSource_0.Current != null && this.bindingSource_0.Current is DataRowView)
			{
				if (((DataRowView)this.bindingSource_0.Current).Row["idParent"] != DBNull.Value && Convert.ToInt32(this.dataGridViewExcelFilter_1[this.dataGridViewTextBoxColumn_8.Name, e.RowIndex].Value) == Convert.ToInt32(((DataRowView)this.bindingSource_0.Current).Row["idParent"]))
				{
					e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
				}
				if (((DataRowView)this.bindingSource_0.Current).Row["idReqForRepair"] != DBNull.Value && Convert.ToInt32(this.dataGridViewExcelFilter_1[this.dataGridViewTextBoxColumn_8.Name, e.RowIndex].Value) == Convert.ToInt32(((DataRowView)this.bindingSource_0.Current).Row["idReqForRepair"]))
				{
					e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
				}
				if (this.dataGridViewExcelFilter_1[this.dataGridViewCheckBoxColumn_0.Name, e.RowIndex].Value != DBNull.Value && Convert.ToBoolean(this.dataGridViewExcelFilter_1[this.dataGridViewCheckBoxColumn_0.Name, e.RowIndex].Value))
				{
					e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
				}
			}
		}

		private void bindingSource_0_CurrentChanged(object sender, EventArgs e)
		{
			this.method_10();
		}

		private void bindingSource_0_ListChanged(object sender, ListChangedEventArgs e)
		{
			string arg = "";
			if (this.bindingSource_0.Filter != null && !string.IsNullOrEmpty(this.bindingSource_0.Filter))
			{
				arg = string.Format("({0}) and ", this.bindingSource_0.Filter);
			}
			this.textBox_0.Text = this.class171_0.vJ_Damage.Compute("count(id)", string.Format("{0} isApply = 1", arg)).ToString() + " - устранено";
			this.textBox_4.Text = this.class171_0.vJ_Damage.Compute("count(id)", string.Format("{0} (isApply is null or isApply = 0) \r\n                    and (datePlanEnd is null or datePlanEnd >= '{1}')\r\n                    and not (idReqForRepair is not null and idReason is null)", arg, DateTime.Now.Date.ToString("yyyy-MM-dd") + " 00:00:00")).ToString() + " - в работе";
			this.textBox_3.Text = this.class171_0.vJ_Damage.Compute("count(id)", string.Format("{0} (isApply is null or isApply = 0) \r\n                    and (datePlanEnd < '{1}')\r\n                    and not (idReqForRepair is not null and idReason is null)", arg, DateTime.Now.Date.ToString("yyyy-MM-dd") + " 00:00:00")).ToString() + " - просрочено";
			this.textBox_2.Text = this.class171_0.vJ_Damage.Compute("count(id)", string.Format("{0} (isApply is null or isApply = 0) \r\n                    and (idReqForRepair is not null and idReason is null)", arg)).ToString() + " - неоформлено";
			this.textBox_1.Text = this.class171_0.vJ_Damage.Compute("count(id)", string.Format("{0} (isNoSESNO = 1)", arg)).ToString() + " - нет сетей Горсвет";
		}

		private void toolStripButton_17_Click(object sender, EventArgs e)
		{
			new Form82
			{
				SqlSettings = this.SqlSettings,
				MdiParent = base.MdiParent
			}.Show();
		}

		private void method_11()
		{
			this.icontainer_0 = new Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FormJournalDamage));
			DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle16 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle17 = new DataGridViewCellStyle();
			this.toolStrip_0 = new ToolStrip();
			this.toolStripDropDownButton_0 = new ToolStripDropDownButton();
			this.toolStripButton_4 = new ToolStripButton();
			this.toolStripButton_5 = new ToolStripButton();
			this.toolStripButton_9 = new ToolStripButton();
			this.toolStripSeparator_0 = new ToolStripSeparator();
			this.toolStripButton_10 = new ToolStripButton();
			this.toolStripSeparator_1 = new ToolStripSeparator();
			this.toolStripButton_11 = new ToolStripButton();
			this.toolStripTextBox_1 = new ToolStripTextBox();
			this.toolStripButton_12 = new ToolStripButton();
			this.toolStripButton_13 = new ToolStripButton();
			this.toolStripSeparator_2 = new ToolStripSeparator();
			this.toolStripDropDownButton_1 = new ToolStripDropDownButton();
			this.toolStripMenuItem_0 = new ToolStripMenuItem();
			this.toolStripMenuItem_2 = new ToolStripMenuItem();
			this.toolStripMenuItem_3 = new ToolStripMenuItem();
			this.toolStripMenuItem_5 = new ToolStripMenuItem();
			this.toolStripMenuItem_14 = new ToolStripMenuItem();
			this.toolStripMenuItem_18 = new ToolStripMenuItem();
			this.toolStripDropDownButton_2 = new ToolStripDropDownButton();
			this.toolStripMenuItem_1 = new ToolStripMenuItem();
			this.toolStripMenuItem_4 = new ToolStripMenuItem();
			this.toolStripMenuItem_6 = new ToolStripMenuItem();
			this.toolStripMenuItem_7 = new ToolStripMenuItem();
			this.toolStripMenuItem_15 = new ToolStripMenuItem();
			this.toolStripMenuItem_16 = new ToolStripMenuItem();
			this.toolStripMenuItem_17 = new ToolStripMenuItem();
			this.toolStripButton_14 = new ToolStripButton();
			this.toolStripButton_15 = new ToolStripButton();
			this.toolStripButton_16 = new ToolStripButton();
			this.toolStripButton_17 = new ToolStripButton();
			this.toolStripProgressBar_0 = new ToolStripProgressBar();
			this.splitContainer_0 = new SplitContainer();
			this.groupBox_0 = new GroupBox();
			this.textBox_1 = new TextBox();
			this.textBox_2 = new TextBox();
			this.textBox_3 = new TextBox();
			this.textBox_4 = new TextBox();
			this.textBox_0 = new TextBox();
			this.checkedListBox_1 = new CheckedListBox();
			this.checkBox_0 = new CheckBox();
			this.label_4 = new Label();
			this.toolStrip_2 = new ToolStrip();
			this.toolStripButton_6 = new ToolStripButton();
			this.toolStripTextBox_0 = new ToolStripTextBox();
			this.toolStripButton_7 = new ToolStripButton();
			this.toolStripButton_8 = new ToolStripButton();
			this.treeViewSchmObjects_0 = new TreeViewSchmObjects();
			this.checkedListBox_0 = new CheckedListBox();
			this.label_0 = new Label();
			this.dateTimePicker_0 = new DateTimePicker();
			this.label_1 = new Label();
			this.dateTimePicker_1 = new DateTimePicker();
			this.label_2 = new Label();
			this.toolStrip_1 = new ToolStrip();
			this.toolStripButton_0 = new ToolStripButton();
			this.toolStripButton_1 = new ToolStripButton();
			this.toolStripSeparator_3 = new ToolStripSeparator();
			this.toolStripButton_2 = new ToolStripButton();
			this.toolStripButton_3 = new ToolStripButton();
			this.splitContainer_1 = new SplitContainer();
			this.dataGridViewExcelFilter_0 = new DataGridViewExcelFilter();
			this.dataGridViewFilterCheckBoxColumn_0 = new DataGridViewFilterCheckBoxColumn();
			this.dataGridViewFilterCheckBoxColumn_1 = new DataGridViewFilterCheckBoxColumn();
			this.dataGridViewFilterTextBoxColumn_20 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_21 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_22 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_23 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_24 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_25 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_26 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_27 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_28 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_29 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_30 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_31 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_32 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_33 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_34 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_35 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_36 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_37 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_38 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_39 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_40 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewTextBoxColumn_11 = new DataGridViewTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_41 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_42 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewTextBoxColumn_12 = new DataGridViewTextBoxColumn();
			this.dataGridViewFilterCheckBoxColumn_2 = new DataGridViewFilterCheckBoxColumn();
			this.dataGridViewFilterCheckBoxColumn_3 = new DataGridViewFilterCheckBoxColumn();
			this.dataGridViewTextBoxColumn_13 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_14 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_15 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_16 = new DataGridViewTextBoxColumn();
			this.bindingSource_0 = new BindingSource(this.icontainer_0);
			this.class171_0 = new Class171();
			this.dataGridViewExcelFilter_1 = new DataGridViewExcelFilter();
			this.dataGridViewTextBoxColumn_6 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_7 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_8 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_9 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_10 = new DataGridViewTextBoxColumn();
			this.dataGridViewCheckBoxColumn_0 = new DataGridViewCheckBoxColumn();
			this.bindingSource_1 = new BindingSource(this.icontainer_0);
			this.dataSet_0 = new DataSet();
			this.dataTable_0 = new DataTable();
			this.dataColumn_0 = new DataColumn();
			this.dataColumn_1 = new DataColumn();
			this.dataColumn_2 = new DataColumn();
			this.dataColumn_3 = new DataColumn();
			this.dataColumn_4 = new DataColumn();
			this.dataColumn_5 = new DataColumn();
			this.dataColumn_6 = new DataColumn();
			this.label_3 = new Label();
			this.contextMenuStrip_0 = new ContextMenuStrip(this.icontainer_0);
			this.toolStripMenuItem_8 = new ToolStripMenuItem();
			this.toolStripMenuItem_9 = new ToolStripMenuItem();
			this.toolStripMenuItem_10 = new ToolStripMenuItem();
			this.toolStripMenuItem_11 = new ToolStripMenuItem();
			this.toolStripSeparator_4 = new ToolStripSeparator();
			this.toolStripMenuItem_12 = new ToolStripMenuItem();
			this.toolStripMenuItem_13 = new ToolStripMenuItem();
			this.toolStripSeparator_5 = new ToolStripSeparator();
			this.dataGridViewFilterTextBoxColumn_0 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_1 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_2 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_3 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_4 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_5 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_6 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_7 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_8 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_9 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_10 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_11 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_19 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_13 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_14 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_15 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_16 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_17 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_18 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_3 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_4 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_5 = new DataGridViewTextBoxColumn();
			this.backgroundWorker_0 = new BackgroundWorker();
			this.toolStrip_0.SuspendLayout();
			this.splitContainer_0.Panel1.SuspendLayout();
			this.splitContainer_0.Panel2.SuspendLayout();
			this.splitContainer_0.SuspendLayout();
			this.groupBox_0.SuspendLayout();
			this.toolStrip_2.SuspendLayout();
			this.toolStrip_1.SuspendLayout();
			this.splitContainer_1.Panel1.SuspendLayout();
			this.splitContainer_1.Panel2.SuspendLayout();
			this.splitContainer_1.SuspendLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_0).BeginInit();
			((ISupportInitialize)this.bindingSource_0).BeginInit();
			((ISupportInitialize)this.class171_0).BeginInit();
			((ISupportInitialize)this.dataGridViewExcelFilter_1).BeginInit();
			((ISupportInitialize)this.bindingSource_1).BeginInit();
			((ISupportInitialize)this.dataSet_0).BeginInit();
			((ISupportInitialize)this.dataTable_0).BeginInit();
			this.contextMenuStrip_0.SuspendLayout();
			base.SuspendLayout();
			this.toolStrip_0.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripDropDownButton_0,
				this.toolStripButton_4,
				this.toolStripButton_5,
				this.toolStripButton_9,
				this.toolStripSeparator_0,
				this.toolStripButton_10,
				this.toolStripSeparator_1,
				this.toolStripButton_11,
				this.toolStripTextBox_1,
				this.toolStripButton_12,
				this.toolStripButton_13,
				this.toolStripSeparator_2,
				this.toolStripDropDownButton_1,
				this.toolStripDropDownButton_2,
				this.toolStripButton_14,
				this.toolStripButton_15,
				this.toolStripButton_16,
				this.toolStripButton_17,
				this.toolStripProgressBar_0
			});
			this.toolStrip_0.Location = new Point(0, 0);
			this.toolStrip_0.Name = "toolStrip";
			this.toolStrip_0.Size = new Size(1329, 25);
			this.toolStrip_0.TabIndex = 0;
			this.toolStrip_0.Text = "toolStrip1";
			this.toolStripDropDownButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripDropDownButton_0.Image = (Image)componentResourceManager.GetObject("toolBtnAdd.Image");
			this.toolStripDropDownButton_0.ImageTransparentColor = Color.Magenta;
			this.toolStripDropDownButton_0.Name = "toolBtnAdd";
			this.toolStripDropDownButton_0.Size = new Size(29, 22);
			this.toolStripDropDownButton_0.Text = "Добавить";
			this.toolStripButton_4.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_4.Image = (Image)componentResourceManager.GetObject("toolBtnEdit.Image");
			this.toolStripButton_4.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_4.Name = "toolBtnEdit";
			this.toolStripButton_4.Size = new Size(23, 22);
			this.toolStripButton_4.Text = "Редактировать";
			this.toolStripButton_4.Click += this.toolStripMenuItem_9_Click;
			this.toolStripButton_5.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_5.Image = (Image)componentResourceManager.GetObject("toolBtnInfo.Image");
			this.toolStripButton_5.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_5.Name = "toolBtnInfo";
			this.toolStripButton_5.Size = new Size(23, 22);
			this.toolStripButton_5.Text = "Информация";
			this.toolStripButton_5.Click += this.toolStripMenuItem_10_Click;
			this.toolStripButton_9.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_9.Image = (Image)componentResourceManager.GetObject("toolBtnDel.Image");
			this.toolStripButton_9.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_9.Name = "toolBtnDel";
			this.toolStripButton_9.Size = new Size(23, 22);
			this.toolStripButton_9.Text = "Удалить документ";
			this.toolStripButton_9.Click += this.toolStripMenuItem_11_Click;
			this.toolStripSeparator_0.Name = "toolStripSeparator1";
			this.toolStripSeparator_0.Size = new Size(6, 25);
			this.toolStripButton_10.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_10.Image = (Image)componentResourceManager.GetObject("toolBtnRefresh.Image");
			this.toolStripButton_10.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_10.Name = "toolBtnRefresh";
			this.toolStripButton_10.Size = new Size(23, 22);
			this.toolStripButton_10.Text = "Обновить";
			this.toolStripButton_10.Click += this.toolStripButton_10_Click;
			this.toolStripSeparator_1.Name = "toolStripSeparator2";
			this.toolStripSeparator_1.Size = new Size(6, 25);
			this.toolStripButton_11.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_11.Image = (Image)componentResourceManager.GetObject("toolBtnFind.Image");
			this.toolStripButton_11.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_11.Name = "toolBtnFind";
			this.toolStripButton_11.Size = new Size(23, 22);
			this.toolStripButton_11.Text = "Искать";
			this.toolStripButton_11.Click += this.toolStripButton_11_Click;
			this.toolStripTextBox_1.Name = "txtFind";
			this.toolStripTextBox_1.Size = new Size(100, 25);
			this.toolStripTextBox_1.ToolTipText = "Текст для поиска";
			this.toolStripTextBox_1.KeyDown += this.toolStripTextBox_1_KeyDown;
			this.toolStripButton_12.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_12.Image = (Image)componentResourceManager.GetObject("toolBtnFindPrev.Image");
			this.toolStripButton_12.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_12.Name = "toolBtnFindPrev";
			this.toolStripButton_12.Size = new Size(23, 22);
			this.toolStripButton_12.Text = "Искать назад";
			this.toolStripButton_12.Click += this.toolStripButton_12_Click;
			this.toolStripButton_13.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_13.Image = (Image)componentResourceManager.GetObject("toolBtnFindNext.Image");
			this.toolStripButton_13.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_13.Name = "toolBtnFindNext";
			this.toolStripButton_13.Size = new Size(23, 22);
			this.toolStripButton_13.Text = "Искать вперед";
			this.toolStripButton_13.Click += this.toolStripButton_13_Click;
			this.toolStripSeparator_2.Name = "toolStripSeparator3";
			this.toolStripSeparator_2.Size = new Size(6, 25);
			this.toolStripDropDownButton_1.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripDropDownButton_1.DropDownItems.AddRange(new ToolStripItem[]
			{
				this.toolStripMenuItem_0,
				this.toolStripMenuItem_2,
				this.toolStripMenuItem_3,
				this.toolStripMenuItem_5,
				this.toolStripMenuItem_14,
				this.toolStripMenuItem_18
			});
			this.toolStripDropDownButton_1.Image = (Image)componentResourceManager.GetObject("toolBtnReport.Image");
			this.toolStripDropDownButton_1.ImageTransparentColor = Color.Magenta;
			this.toolStripDropDownButton_1.Name = "toolBtnReport";
			this.toolStripDropDownButton_1.Size = new Size(29, 22);
			this.toolStripDropDownButton_1.Text = "Отчеты";
			this.toolStripMenuItem_0.Name = "toolMenuItemReportDailyLV";
			this.toolStripMenuItem_0.Size = new Size(381, 22);
			this.toolStripMenuItem_0.Text = "Суточный рапорт в сетях 0,4кВ (ОДС)";
			this.toolStripMenuItem_0.Click += this.toolStripMenuItem_0_Click;
			this.toolStripMenuItem_2.Name = "toolMenuItemSheetInterruptLV";
			this.toolStripMenuItem_2.Size = new Size(381, 22);
			this.toolStripMenuItem_2.Text = "Бюллетень перерывов электроснабжения в сетях 0,4 кВ";
			this.toolStripMenuItem_2.Click += this.toolStripMenuItem_2_Click;
			this.toolStripMenuItem_3.Name = "toolMenuItemReportDailyDefect";
			this.toolStripMenuItem_3.Size = new Size(381, 22);
			this.toolStripMenuItem_3.Text = "Суточный рапорт по дефектам";
			this.toolStripMenuItem_3.Click += this.toolStripMenuItem_3_Click;
			this.toolStripMenuItem_5.Name = "toolMenuItemReportDailyHV";
			this.toolStripMenuItem_5.Size = new Size(381, 22);
			this.toolStripMenuItem_5.Text = "Суточный рапорт в сетях 6-10 кВ";
			this.toolStripMenuItem_5.Click += this.toolStripMenuItem_5_Click;
			this.toolStripMenuItem_14.Name = "tsMenuAmergencyShutdown";
			this.toolStripMenuItem_14.Size = new Size(381, 22);
			this.toolStripMenuItem_14.Text = "Бюллетень аварийных отключений";
			this.toolStripMenuItem_14.Click += this.toolStripMenuItem_14_Click;
			this.toolStripMenuItem_18.Name = "toolMenuItemReport81";
			this.toolStripMenuItem_18.Size = new Size(381, 22);
			this.toolStripMenuItem_18.Text = "Бюллетень 8.1";
			this.toolStripMenuItem_18.Click += this.toolStripMenuItem_18_Click;
			this.toolStripDropDownButton_2.Alignment = ToolStripItemAlignment.Right;
			this.toolStripDropDownButton_2.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripDropDownButton_2.DropDownItems.AddRange(new ToolStripItem[]
			{
				this.toolStripMenuItem_1,
				this.toolStripMenuItem_4,
				this.toolStripMenuItem_6,
				this.toolStripMenuItem_7,
				this.toolStripMenuItem_15,
				this.toolStripMenuItem_16,
				this.toolStripMenuItem_17
			});
			this.toolStripDropDownButton_2.Image = (Image)componentResourceManager.GetObject("toolBTnLoadOld.Image");
			this.toolStripDropDownButton_2.ImageTransparentColor = Color.Magenta;
			this.toolStripDropDownButton_2.Name = "toolBTnLoadOld";
			this.toolStripDropDownButton_2.Size = new Size(29, 22);
			this.toolStripDropDownButton_2.Text = "Загрузка из старой базы";
			this.toolStripMenuItem_1.Name = "toolBtnLoadOldDamageLV";
			this.toolStripMenuItem_1.Size = new Size(218, 22);
			this.toolStripMenuItem_1.Text = "0.4кВ";
			this.toolStripMenuItem_1.Click += this.toolStripMenuItem_1_Click;
			this.toolStripMenuItem_4.Name = "toolBtnLoadOldDefect";
			this.toolStripMenuItem_4.Size = new Size(218, 22);
			this.toolStripMenuItem_4.Text = "Дефект";
			this.toolStripMenuItem_4.Click += this.toolStripMenuItem_4_Click;
			this.toolStripMenuItem_6.Name = "toolBtnLoadAbnDefectLV";
			this.toolStripMenuItem_6.Size = new Size(218, 22);
			this.toolStripMenuItem_6.Text = "Загрузить абонентов НН";
			this.toolStripMenuItem_6.Click += this.toolStripMenuItem_6_Click;
			this.toolStripMenuItem_7.Name = "toolBtnLoadOldDamageНV";
			this.toolStripMenuItem_7.Size = new Size(218, 22);
			this.toolStripMenuItem_7.Text = "ВН";
			this.toolStripMenuItem_7.Click += this.toolStripMenuItem_7_Click;
			this.toolStripMenuItem_15.Name = "toolBtnLoadOldDamageLVMySQL";
			this.toolStripMenuItem_15.Size = new Size(218, 22);
			this.toolStripMenuItem_15.Text = "Mysql";
			this.toolStripMenuItem_15.Click += this.toolStripMenuItem_15_Click;
			this.toolStripMenuItem_16.Name = "damageHVToDamageMainToolStripMenuItem";
			this.toolStripMenuItem_16.Size = new Size(218, 22);
			this.toolStripMenuItem_16.Text = "DamageHVToDamageMain";
			this.toolStripMenuItem_16.Click += this.toolStripMenuItem_16_Click;
			this.toolStripMenuItem_17.Name = "damageLVToDamageMainToolStripMenuItem";
			this.toolStripMenuItem_17.Size = new Size(218, 22);
			this.toolStripMenuItem_17.Text = "DamageLVToDamageMain";
			this.toolStripMenuItem_17.Click += this.toolStripMenuItem_17_Click;
			this.toolStripButton_14.Alignment = ToolStripItemAlignment.Right;
			this.toolStripButton_14.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_14.Image = (Image)componentResourceManager.GetObject("toolBtnDamageNoApply.Image");
			this.toolStripButton_14.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_14.Name = "toolBtnDamageNoApply";
			this.toolStripButton_14.Size = new Size(23, 22);
			this.toolStripButton_14.Text = "Разблокировать документ";
			this.toolStripButton_14.Visible = false;
			this.toolStripButton_14.Click += this.toolStripButton_14_Click;
			this.toolStripButton_15.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_15.Image = (Image)componentResourceManager.GetObject("toolBtnExportExcel.Image");
			this.toolStripButton_15.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_15.Name = "toolBtnExportExcel";
			this.toolStripButton_15.Size = new Size(23, 22);
			this.toolStripButton_15.Text = "Экспорт в Excel";
			this.toolStripButton_15.Click += this.toolStripButton_15_Click;
			this.toolStripButton_16.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_16.Image = (Image)componentResourceManager.GetObject("toolBtnPrint.Image");
			this.toolStripButton_16.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_16.Name = "toolBtnPrint";
			this.toolStripButton_16.Size = new Size(23, 22);
			this.toolStripButton_16.Text = "Печать";
			this.toolStripButton_16.Click += this.toolStripButton_16_Click;
			this.toolStripButton_17.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_17.Image = (Image)componentResourceManager.GetObject("toolBtnSettingMail.Image");
			this.toolStripButton_17.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_17.Name = "toolBtnSettingMail";
			this.toolStripButton_17.Size = new Size(23, 22);
			this.toolStripButton_17.Text = "Настройки отправки почты";
			this.toolStripButton_17.Click += this.toolStripButton_17_Click;
			this.toolStripProgressBar_0.Alignment = ToolStripItemAlignment.Right;
			this.toolStripProgressBar_0.Name = "progressBar";
			this.toolStripProgressBar_0.Size = new Size(100, 22);
			this.toolStripProgressBar_0.Style = ProgressBarStyle.Marquee;
			this.toolStripProgressBar_0.ToolTipText = "Загрузка данных";
			this.toolStripProgressBar_0.Visible = false;
			this.splitContainer_0.Dock = DockStyle.Fill;
			this.splitContainer_0.FixedPanel = FixedPanel.Panel1;
			this.splitContainer_0.Location = new Point(0, 25);
			this.splitContainer_0.Name = "splitContainer";
			this.splitContainer_0.Panel1.Controls.Add(this.groupBox_0);
			this.splitContainer_0.Panel1.Controls.Add(this.checkedListBox_1);
			this.splitContainer_0.Panel1.Controls.Add(this.checkBox_0);
			this.splitContainer_0.Panel1.Controls.Add(this.label_4);
			this.splitContainer_0.Panel1.Controls.Add(this.toolStrip_2);
			this.splitContainer_0.Panel1.Controls.Add(this.treeViewSchmObjects_0);
			this.splitContainer_0.Panel1.Controls.Add(this.checkedListBox_0);
			this.splitContainer_0.Panel1.Controls.Add(this.label_0);
			this.splitContainer_0.Panel1.Controls.Add(this.dateTimePicker_0);
			this.splitContainer_0.Panel1.Controls.Add(this.label_1);
			this.splitContainer_0.Panel1.Controls.Add(this.dateTimePicker_1);
			this.splitContainer_0.Panel1.Controls.Add(this.label_2);
			this.splitContainer_0.Panel1.Controls.Add(this.toolStrip_1);
			this.splitContainer_0.Panel2.Controls.Add(this.splitContainer_1);
			this.splitContainer_0.Size = new Size(1329, 713);
			this.splitContainer_0.SplitterDistance = 258;
			this.splitContainer_0.TabIndex = 1;
			this.groupBox_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox_0.Controls.Add(this.textBox_1);
			this.groupBox_0.Controls.Add(this.textBox_2);
			this.groupBox_0.Controls.Add(this.textBox_3);
			this.groupBox_0.Controls.Add(this.textBox_4);
			this.groupBox_0.Controls.Add(this.textBox_0);
			this.groupBox_0.Location = new Point(0, 559);
			this.groupBox_0.Name = "groupBoxLegend";
			this.groupBox_0.Size = new Size(258, 151);
			this.groupBox_0.TabIndex = 16;
			this.groupBox_0.TabStop = false;
			this.groupBox_0.Text = "Легенда";
			this.textBox_1.BackColor = Color.Orange;
			this.textBox_1.Location = new Point(6, 123);
			this.textBox_1.Name = "txtLegendNoSESNO";
			this.textBox_1.ReadOnly = true;
			this.textBox_1.Size = new Size(183, 20);
			this.textBox_1.TabIndex = 5;
			this.textBox_1.Text = "0 - нет сетей Горсвет";
			this.textBox_2.BackColor = Color.LightPink;
			this.textBox_2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 204);
			this.textBox_2.ForeColor = Color.Red;
			this.textBox_2.Location = new Point(6, 97);
			this.textBox_2.Name = "txtLegendUnExec";
			this.textBox_2.ReadOnly = true;
			this.textBox_2.Size = new Size(183, 20);
			this.textBox_2.TabIndex = 4;
			this.textBox_2.Text = "0 - неоформлено";
			this.textBox_3.BackColor = SystemColors.Window;
			this.textBox_3.ForeColor = Color.Red;
			this.textBox_3.Location = new Point(6, 71);
			this.textBox_3.Name = "txtLegendOverdue";
			this.textBox_3.ReadOnly = true;
			this.textBox_3.Size = new Size(183, 20);
			this.textBox_3.TabIndex = 3;
			this.textBox_3.Text = "0 - просрочено";
			this.textBox_4.BackColor = SystemColors.Window;
			this.textBox_4.Location = new Point(6, 45);
			this.textBox_4.Name = "txtLegendInWork";
			this.textBox_4.ReadOnly = true;
			this.textBox_4.Size = new Size(183, 20);
			this.textBox_4.TabIndex = 2;
			this.textBox_4.Text = "0 - в работе";
			this.textBox_0.BackColor = SystemColors.Window;
			this.textBox_0.ForeColor = Color.Green;
			this.textBox_0.Location = new Point(6, 19);
			this.textBox_0.Name = "txtLegendApply";
			this.textBox_0.ReadOnly = true;
			this.textBox_0.Size = new Size(183, 20);
			this.textBox_0.TabIndex = 0;
			this.textBox_0.Text = "0 - устранено";
			this.checkedListBox_1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.checkedListBox_1.CheckOnClick = true;
			this.checkedListBox_1.FormattingEnabled = true;
			this.checkedListBox_1.Location = new Point(12, 217);
			this.checkedListBox_1.Name = "checkedListBoxDivisionApply";
			this.checkedListBox_1.Size = new Size(234, 94);
			this.checkedListBox_1.TabIndex = 14;
			this.checkBox_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.checkBox_0.AutoSize = true;
			this.checkBox_0.Checked = true;
			this.checkBox_0.CheckState = CheckState.Checked;
			this.checkBox_0.Location = new Point(12, 536);
			this.checkBox_0.Name = "checkBoxWhereSub";
			this.checkBox_0.Size = new Size(180, 17);
			this.checkBox_0.TabIndex = 12;
			this.checkBox_0.Text = "Фильтровать по подстанциям";
			this.checkBox_0.UseVisualStyleBackColor = true;
			this.label_4.AutoSize = true;
			this.label_4.Location = new Point(12, 201);
			this.label_4.Name = "label4";
			this.label_4.Size = new Size(155, 13);
			this.label_4.TabIndex = 13;
			this.label_4.Text = "Подразделение-исполнитель";
			this.toolStrip_2.Dock = DockStyle.None;
			this.toolStrip_2.GripStyle = ToolStripGripStyle.Hidden;
			this.toolStrip_2.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripButton_6,
				this.toolStripTextBox_0,
				this.toolStripButton_7,
				this.toolStripButton_8
			});
			this.toolStrip_2.Location = new Point(15, 314);
			this.toolStrip_2.Name = "toolStripTreeSchmObj";
			this.toolStrip_2.Size = new Size(174, 25);
			this.toolStrip_2.TabIndex = 11;
			this.toolStrip_2.Text = "toolStrip1";
			this.toolStripButton_6.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_6.Image = (Image)componentResourceManager.GetObject("toolBtnFindTreeSchmObj.Image");
			this.toolStripButton_6.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_6.Name = "toolBtnFindTreeSchmObj";
			this.toolStripButton_6.Size = new Size(23, 22);
			this.toolStripButton_6.Text = "Искать";
			this.toolStripButton_6.Click += this.toolStripButton_6_Click;
			this.toolStripTextBox_0.Name = "txtFindTreeSchmObj";
			this.toolStripTextBox_0.Size = new Size(100, 25);
			this.toolStripTextBox_0.ToolTipText = "Текст для поиска";
			this.toolStripTextBox_0.KeyDown += this.toolStripTextBox_0_KeyDown;
			this.toolStripButton_7.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_7.Image = (Image)componentResourceManager.GetObject("toolBtnFindPrevTreeSchmObj.Image");
			this.toolStripButton_7.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_7.Name = "toolBtnFindPrevTreeSchmObj";
			this.toolStripButton_7.Size = new Size(23, 22);
			this.toolStripButton_7.Text = "Искать назад";
			this.toolStripButton_7.Click += this.toolStripButton_7_Click;
			this.toolStripButton_8.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_8.Image = (Image)componentResourceManager.GetObject("toolBtnFindNextTreeSchmObj.Image");
			this.toolStripButton_8.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_8.Name = "toolBtnFindNextTreeSchmObj";
			this.toolStripButton_8.Size = new Size(23, 22);
			this.toolStripButton_8.Text = "Искать вперед";
			this.toolStripButton_8.Click += this.toolStripButton_8_Click;
			this.treeViewSchmObjects_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.treeViewSchmObjects_0.CheckBoxes = true;
			this.treeViewSchmObjects_0.Location = new Point(12, 342);
			this.treeViewSchmObjects_0.Name = "treeViewSchmObjects";
			this.treeViewSchmObjects_0.Size = new Size(234, 188);
			this.treeViewSchmObjects_0.SqlSettings = null;
			this.treeViewSchmObjects_0.TabIndex = 10;
			this.checkedListBox_0.CheckOnClick = true;
			this.checkedListBox_0.FormattingEnabled = true;
			this.checkedListBox_0.Location = new Point(12, 119);
			this.checkedListBox_0.Name = "checkedListBoxDivision";
			this.checkedListBox_0.Size = new Size(234, 79);
			this.checkedListBox_0.TabIndex = 6;
			this.label_0.AutoSize = true;
			this.label_0.Location = new Point(12, 103);
			this.label_0.Name = "label3";
			this.label_0.Size = new Size(87, 13);
			this.label_0.TabIndex = 5;
			this.label_0.Text = "Подразделения";
			this.dateTimePicker_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.dateTimePicker_0.CausesValidation = false;
			this.dateTimePicker_0.Location = new Point(12, 80);
			this.dateTimePicker_0.Name = "dtpFilterEnd";
			this.dateTimePicker_0.Size = new Size(234, 20);
			this.dateTimePicker_0.TabIndex = 4;
			this.dateTimePicker_0.ValueChanged += this.dateTimePicker_0_ValueChanged;
			this.label_1.AutoSize = true;
			this.label_1.Location = new Point(12, 64);
			this.label_1.Name = "label2";
			this.label_1.Size = new Size(22, 13);
			this.label_1.TabIndex = 3;
			this.label_1.Text = "До";
			this.dateTimePicker_1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.dateTimePicker_1.CausesValidation = false;
			this.dateTimePicker_1.Location = new Point(12, 41);
			this.dateTimePicker_1.Name = "dtpFilterBeg";
			this.dateTimePicker_1.Size = new Size(234, 20);
			this.dateTimePicker_1.TabIndex = 2;
			this.dateTimePicker_1.ValueChanged += this.dateTimePicker_1_ValueChanged;
			this.label_2.AutoSize = true;
			this.label_2.Location = new Point(12, 25);
			this.label_2.Name = "label1";
			this.label_2.Size = new Size(20, 13);
			this.label_2.TabIndex = 1;
			this.label_2.Text = "От";
			this.toolStrip_1.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripButton_0,
				this.toolStripButton_1,
				this.toolStripSeparator_3,
				this.toolStripButton_2,
				this.toolStripButton_3
			});
			this.toolStrip_1.Location = new Point(0, 0);
			this.toolStrip_1.Name = "toolStripFilter";
			this.toolStrip_1.Size = new Size(258, 25);
			this.toolStrip_1.TabIndex = 0;
			this.toolStrip_1.Text = "toolStrip1";
			this.toolStripButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_0.Image = (Image)componentResourceManager.GetObject("toolBtnFilterApply.Image");
			this.toolStripButton_0.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_0.Name = "toolBtnFilterApply";
			this.toolStripButton_0.Size = new Size(23, 22);
			this.toolStripButton_0.Text = "Применить фильтр";
			this.toolStripButton_0.Click += this.toolStripButton_0_Click;
			this.toolStripButton_1.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_1.Image = (Image)componentResourceManager.GetObject("toolBtnFilterDelete.Image");
			this.toolStripButton_1.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_1.Name = "toolBtnFilterDelete";
			this.toolStripButton_1.Size = new Size(23, 22);
			this.toolStripButton_1.Text = "Убрать фильтр";
			this.toolStripButton_1.Click += this.toolStripButton_1_Click;
			this.toolStripSeparator_3.Name = "toolStripSeparator4";
			this.toolStripSeparator_3.Size = new Size(6, 25);
			this.toolStripButton_2.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_2.Image = (Image)componentResourceManager.GetObject("toolBtnPrevYear.Image");
			this.toolStripButton_2.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_2.Name = "toolBtnPrevYear";
			this.toolStripButton_2.Size = new Size(23, 22);
			this.toolStripButton_2.Text = "Предыдущий год";
			this.toolStripButton_2.Click += this.toolStripButton_2_Click;
			this.toolStripButton_3.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_3.Image = (Image)componentResourceManager.GetObject("toolBtnNextYear.Image");
			this.toolStripButton_3.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_3.Name = "toolBtnNextYear";
			this.toolStripButton_3.Size = new Size(23, 22);
			this.toolStripButton_3.Text = "Следующий год";
			this.toolStripButton_3.Click += this.toolStripButton_3_Click;
			this.splitContainer_1.Dock = DockStyle.Fill;
			this.splitContainer_1.FixedPanel = FixedPanel.Panel2;
			this.splitContainer_1.Location = new Point(0, 0);
			this.splitContainer_1.Name = "splitContainerDgv";
			this.splitContainer_1.Orientation = Orientation.Horizontal;
			this.splitContainer_1.Panel1.Controls.Add(this.dataGridViewExcelFilter_0);
			this.splitContainer_1.Panel2.Controls.Add(this.dataGridViewExcelFilter_1);
			this.splitContainer_1.Panel2.Controls.Add(this.label_3);
			this.splitContainer_1.Panel2MinSize = 13;
			this.splitContainer_1.Size = new Size(1067, 713);
			this.splitContainer_1.SplitterDistance = 555;
			this.splitContainer_1.TabIndex = 1;
			this.dataGridViewExcelFilter_0.AllowUserToAddRows = false;
			this.dataGridViewExcelFilter_0.AllowUserToDeleteRows = false;
			this.dataGridViewExcelFilter_0.AllowUserToOrderColumns = true;
			this.dataGridViewExcelFilter_0.AutoGenerateColumns = false;
			dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle.BackColor = SystemColors.Control;
			dataGridViewCellStyle.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
			this.dataGridViewExcelFilter_0.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
			this.dataGridViewExcelFilter_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewExcelFilter_0.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewFilterCheckBoxColumn_0,
				this.dataGridViewFilterCheckBoxColumn_1,
				this.dataGridViewFilterTextBoxColumn_20,
				this.dataGridViewFilterTextBoxColumn_21,
				this.dataGridViewFilterTextBoxColumn_22,
				this.dataGridViewFilterTextBoxColumn_23,
				this.dataGridViewFilterTextBoxColumn_24,
				this.dataGridViewFilterTextBoxColumn_25,
				this.dataGridViewFilterTextBoxColumn_26,
				this.dataGridViewFilterTextBoxColumn_27,
				this.dataGridViewFilterTextBoxColumn_28,
				this.dataGridViewFilterTextBoxColumn_29,
				this.dataGridViewFilterTextBoxColumn_30,
				this.dataGridViewFilterTextBoxColumn_31,
				this.dataGridViewFilterTextBoxColumn_32,
				this.dataGridViewFilterTextBoxColumn_33,
				this.dataGridViewFilterTextBoxColumn_34,
				this.dataGridViewFilterTextBoxColumn_35,
				this.dataGridViewFilterTextBoxColumn_36,
				this.dataGridViewFilterTextBoxColumn_37,
				this.dataGridViewFilterTextBoxColumn_38,
				this.dataGridViewFilterTextBoxColumn_39,
				this.dataGridViewFilterTextBoxColumn_40,
				this.dataGridViewTextBoxColumn_11,
				this.dataGridViewFilterTextBoxColumn_41,
				this.dataGridViewFilterTextBoxColumn_42,
				this.dataGridViewTextBoxColumn_12,
				this.dataGridViewFilterCheckBoxColumn_2,
				this.dataGridViewFilterCheckBoxColumn_3,
				this.dataGridViewTextBoxColumn_13,
				this.dataGridViewTextBoxColumn_14,
				this.dataGridViewTextBoxColumn_15,
				this.dataGridViewTextBoxColumn_16
			});
			this.dataGridViewExcelFilter_0.DataSource = this.bindingSource_0;
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = SystemColors.Window;
			dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
			this.dataGridViewExcelFilter_0.DefaultCellStyle = dataGridViewCellStyle2;
			this.dataGridViewExcelFilter_0.Dock = DockStyle.Fill;
			this.dataGridViewExcelFilter_0.Location = new Point(0, 0);
			this.dataGridViewExcelFilter_0.Name = "dgvDamage";
			this.dataGridViewExcelFilter_0.ReadOnly = true;
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = SystemColors.Control;
			dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
			this.dataGridViewExcelFilter_0.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.dataGridViewExcelFilter_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewExcelFilter_0.Size = new Size(1067, 555);
			this.dataGridViewExcelFilter_0.TabIndex = 0;
			this.dataGridViewExcelFilter_0.CellDoubleClick += this.dataGridViewExcelFilter_0_CellDoubleClick;
			this.dataGridViewExcelFilter_0.CellFormatting += this.dataGridViewExcelFilter_0_CellFormatting;
			this.dataGridViewExcelFilter_0.CellMouseClick += this.dataGridViewExcelFilter_0_CellMouseClick;
			this.dataGridViewExcelFilter_0.RowPostPaint += this.dataGridViewExcelFilter_0_RowPostPaint;
			this.dataGridViewFilterCheckBoxColumn_0.DataPropertyName = "isLaboratory";
			this.dataGridViewFilterCheckBoxColumn_0.FalseValue = "Нет";
			this.dataGridViewFilterCheckBoxColumn_0.HeaderText = "ПЛ";
			this.dataGridViewFilterCheckBoxColumn_0.Name = "isLaboratoryDgvColumn";
			this.dataGridViewFilterCheckBoxColumn_0.ReadOnly = true;
			this.dataGridViewFilterCheckBoxColumn_0.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterCheckBoxColumn_0.TrueValue = "Да";
			this.dataGridViewFilterCheckBoxColumn_0.Visible = false;
			this.dataGridViewFilterCheckBoxColumn_0.Width = 40;
			this.dataGridViewFilterCheckBoxColumn_1.DataPropertyName = "isApply";
			this.dataGridViewFilterCheckBoxColumn_1.HeaderText = "Выполнено";
			this.dataGridViewFilterCheckBoxColumn_1.Name = "isApplyDgvColumn";
			this.dataGridViewFilterCheckBoxColumn_1.ReadOnly = true;
			this.dataGridViewFilterCheckBoxColumn_1.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterCheckBoxColumn_1.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewFilterCheckBoxColumn_1.Visible = false;
			this.dataGridViewFilterTextBoxColumn_20.DataPropertyName = "numrequest";
			this.dataGridViewFilterTextBoxColumn_20.HeaderText = "№ заявки";
			this.dataGridViewFilterTextBoxColumn_20.Name = "numrequestDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_20.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_20.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_21.DataPropertyName = "numDoc";
			this.dataGridViewFilterTextBoxColumn_21.HeaderText = "№ документа";
			this.dataGridViewFilterTextBoxColumn_21.Name = "numDocDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_21.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_21.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_21.Visible = false;
			this.dataGridViewFilterTextBoxColumn_22.DataPropertyName = "dateDoc";
			this.dataGridViewFilterTextBoxColumn_22.HeaderText = "Дата заявки";
			this.dataGridViewFilterTextBoxColumn_22.Name = "dateDocDgvColumn";
			this.dataGridViewFilterTextBoxColumn_22.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_22.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_23.DataPropertyName = "TypeDocName";
			this.dataGridViewFilterTextBoxColumn_23.HeaderText = "Тип";
			this.dataGridViewFilterTextBoxColumn_23.Name = "typeDocNameDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_23.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_23.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_24.DataPropertyName = "Division";
			this.dataGridViewFilterTextBoxColumn_24.HeaderText = "Подразделение";
			this.dataGridViewFilterTextBoxColumn_24.Name = "divisionDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_24.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_24.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_24.Visible = false;
			this.dataGridViewFilterTextBoxColumn_25.DataPropertyName = "schmObjName";
			this.dataGridViewFilterTextBoxColumn_25.HeaderText = "Электроустановка";
			this.dataGridViewFilterTextBoxColumn_25.Name = "schmObjNameDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_25.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_25.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_26.DataPropertyName = "NetRegionSub";
			this.dataGridViewFilterTextBoxColumn_26.HeaderText = "Сетевой район";
			this.dataGridViewFilterTextBoxColumn_26.Name = "netRegionSubDgvColumn";
			this.dataGridViewFilterTextBoxColumn_26.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_27.DataPropertyName = "defectLocation";
			dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_27.DefaultCellStyle = dataGridViewCellStyle4;
			this.dataGridViewFilterTextBoxColumn_27.HeaderText = "Место повреждения";
			this.dataGridViewFilterTextBoxColumn_27.Name = "defectLocationDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_27.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_27.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_28.DataPropertyName = "City";
			this.dataGridViewFilterTextBoxColumn_28.HeaderText = "Город";
			this.dataGridViewFilterTextBoxColumn_28.Name = "cityDgvColumn";
			this.dataGridViewFilterTextBoxColumn_28.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_28.Visible = false;
			this.dataGridViewFilterTextBoxColumn_29.DataPropertyName = "Street";
			this.dataGridViewFilterTextBoxColumn_29.HeaderText = "Улица";
			this.dataGridViewFilterTextBoxColumn_29.Name = "streetDgvColumn";
			this.dataGridViewFilterTextBoxColumn_29.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_29.Visible = false;
			this.dataGridViewFilterTextBoxColumn_30.DataPropertyName = "Reason";
			dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_30.DefaultCellStyle = dataGridViewCellStyle5;
			this.dataGridViewFilterTextBoxColumn_30.HeaderText = "Причина";
			this.dataGridViewFilterTextBoxColumn_30.Name = "reasonDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_30.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_30.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_31.DataPropertyName = "Character";
			this.dataGridViewFilterTextBoxColumn_31.HeaderText = "Характер повреждения";
			this.dataGridViewFilterTextBoxColumn_31.Name = "characterDgvColumn";
			this.dataGridViewFilterTextBoxColumn_31.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_31.Visible = false;
			this.dataGridViewFilterTextBoxColumn_32.DataPropertyName = "DivisionApply";
			dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_32.DefaultCellStyle = dataGridViewCellStyle6;
			this.dataGridViewFilterTextBoxColumn_32.FilteringEnabled = false;
			this.dataGridViewFilterTextBoxColumn_32.HeaderText = "Подразделение исполнитель";
			this.dataGridViewFilterTextBoxColumn_32.Name = "divisionApplyDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_32.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_32.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_33.DataPropertyName = "dateApply";
			this.dataGridViewFilterTextBoxColumn_33.HeaderText = "Дата устранения";
			this.dataGridViewFilterTextBoxColumn_33.Name = "dateApplyDgvColumn";
			this.dataGridViewFilterTextBoxColumn_33.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_33.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_34.DataPropertyName = "datePlanEnd";
			this.dataGridViewFilterTextBoxColumn_34.HeaderText = "План дата устранения";
			this.dataGridViewFilterTextBoxColumn_34.Name = "datePlanEndDgvColumn";
			this.dataGridViewFilterTextBoxColumn_34.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_35.DataPropertyName = "workerApply";
			this.dataGridViewFilterTextBoxColumn_35.HeaderText = "Выполнил";
			this.dataGridViewFilterTextBoxColumn_35.Name = "workerApplyDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_35.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_35.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_36.DataPropertyName = "completedWork";
			dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_36.DefaultCellStyle = dataGridViewCellStyle7;
			this.dataGridViewFilterTextBoxColumn_36.HeaderText = "Выполненная работа";
			this.dataGridViewFilterTextBoxColumn_36.Name = "completedWorkDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_36.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_36.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_37.DataPropertyName = "compiler";
			this.dataGridViewFilterTextBoxColumn_37.HeaderText = "Составитель";
			this.dataGridViewFilterTextBoxColumn_37.Name = "compilerDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_37.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_37.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_37.Visible = false;
			this.dataGridViewFilterTextBoxColumn_38.DataPropertyName = "Instruction";
			dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_38.DefaultCellStyle = dataGridViewCellStyle8;
			this.dataGridViewFilterTextBoxColumn_38.HeaderText = "Указания";
			this.dataGridViewFilterTextBoxColumn_38.Name = "InstructionDgvColumn";
			this.dataGridViewFilterTextBoxColumn_38.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_38.Width = 120;
			this.dataGridViewFilterTextBoxColumn_39.DataPropertyName = "ownerName";
			this.dataGridViewFilterTextBoxColumn_39.HeaderText = "Автор";
			this.dataGridViewFilterTextBoxColumn_39.Name = "nameOwnerDgvColumn";
			this.dataGridViewFilterTextBoxColumn_39.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_39.Visible = false;
			this.dataGridViewFilterTextBoxColumn_40.DataPropertyName = "dateOwner";
			this.dataGridViewFilterTextBoxColumn_40.HeaderText = "Дата создания";
			this.dataGridViewFilterTextBoxColumn_40.Name = "dateOwnerDgvColumn";
			this.dataGridViewFilterTextBoxColumn_40.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_40.Visible = false;
			this.dataGridViewTextBoxColumn_11.DataPropertyName = "ComletedWorkText";
			dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_11.DefaultCellStyle = dataGridViewCellStyle9;
			this.dataGridViewTextBoxColumn_11.HeaderText = "Выполненная работа текст";
			this.dataGridViewTextBoxColumn_11.Name = "comletedWorkTextDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_11.ReadOnly = true;
			this.dataGridViewTextBoxColumn_11.Visible = false;
			this.dataGridViewFilterTextBoxColumn_41.DataPropertyName = "KodPTS";
			dataGridViewCellStyle10.Format = "N0";
			dataGridViewCellStyle10.NullValue = null;
			this.dataGridViewFilterTextBoxColumn_41.DefaultCellStyle = dataGridViewCellStyle10;
			this.dataGridViewFilterTextBoxColumn_41.HeaderText = "Код повреждения";
			this.dataGridViewFilterTextBoxColumn_41.Name = "KodPTSDgvColumn";
			this.dataGridViewFilterTextBoxColumn_41.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_41.Visible = false;
			this.dataGridViewFilterTextBoxColumn_42.DataPropertyName = "KodPTSStr";
			this.dataGridViewFilterTextBoxColumn_42.HeaderText = "Код повреждения (стр)";
			this.dataGridViewFilterTextBoxColumn_42.Name = "kodPTSStrDgvColumn";
			this.dataGridViewFilterTextBoxColumn_42.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_42.Resizable = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_12.DataPropertyName = "idParent";
			this.dataGridViewTextBoxColumn_12.HeaderText = "Родитель";
			this.dataGridViewTextBoxColumn_12.Name = "idParentDgvColumn";
			this.dataGridViewTextBoxColumn_12.ReadOnly = true;
			this.dataGridViewTextBoxColumn_12.Visible = false;
			this.dataGridViewFilterCheckBoxColumn_2.DataPropertyName = "isNoSESNO";
			this.dataGridViewFilterCheckBoxColumn_2.HeaderText = "не горсвет";
			this.dataGridViewFilterCheckBoxColumn_2.Name = "isNoSESNODgvColumn";
			this.dataGridViewFilterCheckBoxColumn_2.ReadOnly = true;
			this.dataGridViewFilterCheckBoxColumn_2.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterCheckBoxColumn_2.Visible = false;
			this.dataGridViewFilterCheckBoxColumn_3.DataPropertyName = "is81";
			this.dataGridViewFilterCheckBoxColumn_3.HeaderText = "8.1";
			this.dataGridViewFilterCheckBoxColumn_3.Name = "is81DgvColumn";
			this.dataGridViewFilterCheckBoxColumn_3.ReadOnly = true;
			this.dataGridViewTextBoxColumn_13.DataPropertyName = "TypeDoc";
			this.dataGridViewTextBoxColumn_13.HeaderText = "TypeDoc";
			this.dataGridViewTextBoxColumn_13.Name = "typeDocDgvColumn";
			this.dataGridViewTextBoxColumn_13.ReadOnly = true;
			this.dataGridViewTextBoxColumn_13.Visible = false;
			this.dataGridViewTextBoxColumn_14.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_14.HeaderText = "id";
			this.dataGridViewTextBoxColumn_14.Name = "idDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_14.ReadOnly = true;
			this.dataGridViewTextBoxColumn_14.Visible = false;
			this.dataGridViewTextBoxColumn_15.DataPropertyName = "idReason";
			this.dataGridViewTextBoxColumn_15.HeaderText = "idReason";
			this.dataGridViewTextBoxColumn_15.Name = "idReasonDgvColumn";
			this.dataGridViewTextBoxColumn_15.ReadOnly = true;
			this.dataGridViewTextBoxColumn_15.Visible = false;
			this.dataGridViewTextBoxColumn_16.DataPropertyName = "idReqForRepair";
			this.dataGridViewTextBoxColumn_16.HeaderText = "idReqForRepair";
			this.dataGridViewTextBoxColumn_16.Name = "idReqForRepairDgvColumn";
			this.dataGridViewTextBoxColumn_16.ReadOnly = true;
			this.dataGridViewTextBoxColumn_16.Visible = false;
			this.bindingSource_0.DataMember = "vJ_Damage";
			this.bindingSource_0.DataSource = this.class171_0;
			this.bindingSource_0.CurrentChanged += this.bindingSource_0_CurrentChanged;
			this.bindingSource_0.ListChanged += this.bindingSource_0_ListChanged;
			this.class171_0.DataSetName = "DataSetDamage";
			this.class171_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
			this.dataGridViewExcelFilter_1.AllowUserToAddRows = false;
			this.dataGridViewExcelFilter_1.AllowUserToDeleteRows = false;
			this.dataGridViewExcelFilter_1.AllowUserToVisibleColumns = false;
			this.dataGridViewExcelFilter_1.AutoGenerateColumns = false;
			this.dataGridViewExcelFilter_1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewExcelFilter_1.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewTextBoxColumn_6,
				this.dataGridViewTextBoxColumn_7,
				this.dataGridViewTextBoxColumn_8,
				this.dataGridViewTextBoxColumn_9,
				this.dataGridViewTextBoxColumn_10,
				this.dataGridViewCheckBoxColumn_0
			});
			this.dataGridViewExcelFilter_1.DataSource = this.bindingSource_1;
			this.dataGridViewExcelFilter_1.Dock = DockStyle.Fill;
			this.dataGridViewExcelFilter_1.Location = new Point(0, 13);
			this.dataGridViewExcelFilter_1.Name = "dgvLinkDocs";
			this.dataGridViewExcelFilter_1.ReadOnly = true;
			this.dataGridViewExcelFilter_1.Size = new Size(1067, 141);
			this.dataGridViewExcelFilter_1.TabIndex = 10;
			this.dataGridViewExcelFilter_1.CellFormatting += this.dataGridViewExcelFilter_1_CellFormatting;
			this.dataGridViewTextBoxColumn_6.DataPropertyName = "numDoc";
			this.dataGridViewTextBoxColumn_6.HeaderText = "№ документа";
			this.dataGridViewTextBoxColumn_6.Name = "numDocDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_6.ReadOnly = true;
			this.dataGridViewTextBoxColumn_7.DataPropertyName = "dateDoc";
			this.dataGridViewTextBoxColumn_7.HeaderText = "Дата документа";
			this.dataGridViewTextBoxColumn_7.Name = "dateDocDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_7.ReadOnly = true;
			this.dataGridViewTextBoxColumn_7.Width = 150;
			this.dataGridViewTextBoxColumn_8.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_8.HeaderText = "id";
			this.dataGridViewTextBoxColumn_8.Name = "idLinkDocDgvColumn";
			this.dataGridViewTextBoxColumn_8.ReadOnly = true;
			this.dataGridViewTextBoxColumn_8.Visible = false;
			this.dataGridViewTextBoxColumn_9.DataPropertyName = "TypeDoc";
			this.dataGridViewTextBoxColumn_9.HeaderText = "TypeDoc";
			this.dataGridViewTextBoxColumn_9.Name = "typeDocDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_9.ReadOnly = true;
			this.dataGridViewTextBoxColumn_9.Visible = false;
			this.dataGridViewTextBoxColumn_10.DataPropertyName = "TypeDocName";
			this.dataGridViewTextBoxColumn_10.HeaderText = "Тип документа";
			this.dataGridViewTextBoxColumn_10.Name = "typeDocNameDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_10.ReadOnly = true;
			this.dataGridViewTextBoxColumn_10.Width = 250;
			this.dataGridViewCheckBoxColumn_0.DataPropertyName = "isParent";
			this.dataGridViewCheckBoxColumn_0.HeaderText = "isParent";
			this.dataGridViewCheckBoxColumn_0.Name = "isParentDgvColumn";
			this.dataGridViewCheckBoxColumn_0.ReadOnly = true;
			this.dataGridViewCheckBoxColumn_0.Visible = false;
			this.bindingSource_1.DataMember = "dtLinkDocs";
			this.bindingSource_1.DataSource = this.dataSet_0;
			this.dataSet_0.DataSetName = "NewDataSet";
			this.dataSet_0.Tables.AddRange(new DataTable[]
			{
				this.dataTable_0
			});
			this.dataTable_0.Columns.AddRange(new DataColumn[]
			{
				this.dataColumn_0,
				this.dataColumn_1,
				this.dataColumn_2,
				this.dataColumn_3,
				this.dataColumn_4,
				this.dataColumn_5,
				this.dataColumn_6
			});
			this.dataTable_0.TableName = "dtLinkDocs";
			this.dataColumn_0.ColumnName = "id";
			this.dataColumn_0.DataType = typeof(int);
			this.dataColumn_1.ColumnName = "TypeDoc";
			this.dataColumn_1.DataType = typeof(int);
			this.dataColumn_2.ColumnName = "TypeDocName";
			this.dataColumn_3.ColumnName = "numDoc";
			this.dataColumn_4.ColumnName = "dateDoc";
			this.dataColumn_4.DataType = typeof(DateTime);
			this.dataColumn_5.ColumnName = "idReqForRepair";
			this.dataColumn_5.DataType = typeof(int);
			this.dataColumn_6.ColumnName = "isParent";
			this.dataColumn_6.DataType = typeof(bool);
			this.label_3.Cursor = Cursors.PanNorth;
			this.label_3.Dock = DockStyle.Top;
			this.label_3.Location = new Point(0, 0);
			this.label_3.Name = "lbLinkDoc";
			this.label_3.Size = new Size(1067, 13);
			this.label_3.TabIndex = 9;
			this.label_3.Text = "Связанные документы";
			this.label_3.TextAlign = ContentAlignment.TopCenter;
			this.label_3.Click += this.label_3_Click;
			this.contextMenuStrip_0.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripMenuItem_8,
				this.toolStripMenuItem_9,
				this.toolStripMenuItem_10,
				this.toolStripMenuItem_11,
				this.toolStripSeparator_4,
				this.toolStripMenuItem_12
			});
			this.contextMenuStrip_0.Name = "contextMenuDamage";
			this.contextMenuStrip_0.Size = new Size(180, 120);
			this.contextMenuStrip_0.Opening += this.contextMenuStrip_0_Opening;
			this.toolStripMenuItem_8.Image = (Image)componentResourceManager.GetObject("toolItemAdd.Image");
			this.toolStripMenuItem_8.Name = "toolItemAdd";
			this.toolStripMenuItem_8.Size = new Size(179, 22);
			this.toolStripMenuItem_8.Text = "Добавить";
			this.toolStripMenuItem_9.Image = (Image)componentResourceManager.GetObject("toolItemEdit.Image");
			this.toolStripMenuItem_9.Name = "toolItemEdit";
			this.toolStripMenuItem_9.Size = new Size(179, 22);
			this.toolStripMenuItem_9.Text = "Изменить";
			this.toolStripMenuItem_9.Click += this.toolStripMenuItem_9_Click;
			this.toolStripMenuItem_10.Image = (Image)componentResourceManager.GetObject("toolItemInfo.Image");
			this.toolStripMenuItem_10.Name = "toolItemInfo";
			this.toolStripMenuItem_10.Size = new Size(179, 22);
			this.toolStripMenuItem_10.Text = "Просмотр";
			this.toolStripMenuItem_10.Click += this.toolStripMenuItem_10_Click;
			this.toolStripMenuItem_11.Image = (Image)componentResourceManager.GetObject("toolItemDel.Image");
			this.toolStripMenuItem_11.Name = "toolItemDel";
			this.toolStripMenuItem_11.Size = new Size(179, 22);
			this.toolStripMenuItem_11.Text = "Удалить";
			this.toolStripMenuItem_11.Click += this.toolStripMenuItem_11_Click;
			this.toolStripSeparator_4.Name = "toolStripSeparator5";
			this.toolStripSeparator_4.Size = new Size(176, 6);
			this.toolStripMenuItem_12.DropDownItems.AddRange(new ToolStripItem[]
			{
				this.toolStripMenuItem_13,
				this.toolStripSeparator_5
			});
			this.toolStripMenuItem_12.Name = "toolItemActDetection";
			this.toolStripMenuItem_12.Size = new Size(179, 22);
			this.toolStripMenuItem_12.Text = "Акт расследования";
			this.toolStripMenuItem_13.Name = "toolItemActDetectionAdd";
			this.toolStripMenuItem_13.Size = new Size(117, 22);
			this.toolStripMenuItem_13.Text = "Создать";
			this.toolStripMenuItem_13.Click += this.toolStripMenuItem_13_Click;
			this.toolStripSeparator_5.Name = "toolStripSeparator6";
			this.toolStripSeparator_5.Size = new Size(114, 6);
			this.dataGridViewFilterTextBoxColumn_0.DataPropertyName = "numrequest";
			this.dataGridViewFilterTextBoxColumn_0.HeaderText = "№ заявки";
			this.dataGridViewFilterTextBoxColumn_0.Name = "dataGridViewFilterTextBoxColumn1";
			this.dataGridViewFilterTextBoxColumn_0.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_1.DataPropertyName = "numDoc";
			this.dataGridViewFilterTextBoxColumn_1.HeaderText = "№ документа";
			this.dataGridViewFilterTextBoxColumn_1.Name = "dataGridViewFilterTextBoxColumn2";
			this.dataGridViewFilterTextBoxColumn_1.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_1.Visible = false;
			this.dataGridViewFilterTextBoxColumn_2.DataPropertyName = "dateDoc";
			this.dataGridViewFilterTextBoxColumn_2.HeaderText = "Дата заявки";
			this.dataGridViewFilterTextBoxColumn_2.Name = "dataGridViewFilterTextBoxColumn3";
			this.dataGridViewFilterTextBoxColumn_2.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_3.DataPropertyName = "TypeDocName";
			this.dataGridViewFilterTextBoxColumn_3.HeaderText = "Тип";
			this.dataGridViewFilterTextBoxColumn_3.Name = "dataGridViewFilterTextBoxColumn4";
			this.dataGridViewFilterTextBoxColumn_3.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_4.DataPropertyName = "Division";
			this.dataGridViewFilterTextBoxColumn_4.HeaderText = "Подразделение";
			this.dataGridViewFilterTextBoxColumn_4.Name = "dataGridViewFilterTextBoxColumn5";
			this.dataGridViewFilterTextBoxColumn_4.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_4.Visible = false;
			this.dataGridViewFilterTextBoxColumn_5.DataPropertyName = "schmObjName";
			this.dataGridViewFilterTextBoxColumn_5.HeaderText = "Электроустановка";
			this.dataGridViewFilterTextBoxColumn_5.Name = "dataGridViewFilterTextBoxColumn6";
			this.dataGridViewFilterTextBoxColumn_5.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_6.DataPropertyName = "NetRegionSub";
			this.dataGridViewFilterTextBoxColumn_6.HeaderText = "Сетевой район";
			this.dataGridViewFilterTextBoxColumn_6.Name = "dataGridViewFilterTextBoxColumn7";
			this.dataGridViewFilterTextBoxColumn_7.DataPropertyName = "defectLocation";
			dataGridViewCellStyle11.WrapMode = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_7.DefaultCellStyle = dataGridViewCellStyle11;
			this.dataGridViewFilterTextBoxColumn_7.HeaderText = "Место повреждения";
			this.dataGridViewFilterTextBoxColumn_7.Name = "dataGridViewFilterTextBoxColumn8";
			this.dataGridViewFilterTextBoxColumn_7.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_8.DataPropertyName = "Reason";
			dataGridViewCellStyle12.WrapMode = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_8.DefaultCellStyle = dataGridViewCellStyle12;
			this.dataGridViewFilterTextBoxColumn_8.HeaderText = "Причина";
			this.dataGridViewFilterTextBoxColumn_8.Name = "dataGridViewFilterTextBoxColumn9";
			this.dataGridViewFilterTextBoxColumn_8.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_9.DataPropertyName = "DivisionApply";
			dataGridViewCellStyle13.WrapMode = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_9.DefaultCellStyle = dataGridViewCellStyle13;
			this.dataGridViewFilterTextBoxColumn_9.HeaderText = "Подразделение исполнитель";
			this.dataGridViewFilterTextBoxColumn_9.Name = "dataGridViewFilterTextBoxColumn10";
			this.dataGridViewFilterTextBoxColumn_9.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_10.DataPropertyName = "dateApply";
			this.dataGridViewFilterTextBoxColumn_10.HeaderText = "Дата устранения";
			this.dataGridViewFilterTextBoxColumn_10.Name = "dataGridViewFilterTextBoxColumn11";
			this.dataGridViewFilterTextBoxColumn_10.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_11.DataPropertyName = "workerApply";
			this.dataGridViewFilterTextBoxColumn_11.HeaderText = "Выполнил";
			this.dataGridViewFilterTextBoxColumn_11.Name = "dataGridViewFilterTextBoxColumn12";
			this.dataGridViewFilterTextBoxColumn_11.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_19.DataPropertyName = "completedWork";
			dataGridViewCellStyle14.WrapMode = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_19.DefaultCellStyle = dataGridViewCellStyle14;
			this.dataGridViewFilterTextBoxColumn_19.HeaderText = "Выполненная работа";
			this.dataGridViewFilterTextBoxColumn_19.Name = "dataGridViewFilterTextBoxColumn13";
			this.dataGridViewFilterTextBoxColumn_19.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_13.DataPropertyName = "compiler";
			this.dataGridViewFilterTextBoxColumn_13.HeaderText = "Составитель";
			this.dataGridViewFilterTextBoxColumn_13.Name = "dataGridViewFilterTextBoxColumn14";
			this.dataGridViewFilterTextBoxColumn_13.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_13.Visible = false;
			this.dataGridViewFilterTextBoxColumn_14.DataPropertyName = "Instruction";
			dataGridViewCellStyle15.WrapMode = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_14.DefaultCellStyle = dataGridViewCellStyle15;
			this.dataGridViewFilterTextBoxColumn_14.HeaderText = "Указания";
			this.dataGridViewFilterTextBoxColumn_14.Name = "dataGridViewFilterTextBoxColumn15";
			this.dataGridViewFilterTextBoxColumn_14.Width = 120;
			this.dataGridViewFilterTextBoxColumn_15.DataPropertyName = "ownerName";
			this.dataGridViewFilterTextBoxColumn_15.HeaderText = "Автор";
			this.dataGridViewFilterTextBoxColumn_15.Name = "dataGridViewFilterTextBoxColumn16";
			this.dataGridViewFilterTextBoxColumn_15.Visible = false;
			this.dataGridViewFilterTextBoxColumn_16.DataPropertyName = "dateOwner";
			this.dataGridViewFilterTextBoxColumn_16.HeaderText = "Дата создания";
			this.dataGridViewFilterTextBoxColumn_16.Name = "dataGridViewFilterTextBoxColumn17";
			this.dataGridViewFilterTextBoxColumn_16.Visible = false;
			this.dataGridViewTextBoxColumn_0.DataPropertyName = "ComletedWorkText";
			dataGridViewCellStyle16.WrapMode = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_0.DefaultCellStyle = dataGridViewCellStyle16;
			this.dataGridViewTextBoxColumn_0.HeaderText = "Выполненная работа текст";
			this.dataGridViewTextBoxColumn_0.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_0.Visible = false;
			this.dataGridViewFilterTextBoxColumn_17.DataPropertyName = "KodPTS";
			dataGridViewCellStyle17.Format = "N0";
			dataGridViewCellStyle17.NullValue = null;
			this.dataGridViewFilterTextBoxColumn_17.DefaultCellStyle = dataGridViewCellStyle17;
			this.dataGridViewFilterTextBoxColumn_17.HeaderText = "Код повреждения";
			this.dataGridViewFilterTextBoxColumn_17.Name = "dataGridViewFilterTextBoxColumn18";
			this.dataGridViewFilterTextBoxColumn_17.Visible = false;
			this.dataGridViewFilterTextBoxColumn_18.DataPropertyName = "KodPTSStr";
			this.dataGridViewFilterTextBoxColumn_18.HeaderText = "Код повреждения (стр)";
			this.dataGridViewFilterTextBoxColumn_18.Name = "dataGridViewFilterTextBoxColumn19";
			this.dataGridViewFilterTextBoxColumn_18.Resizable = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_1.DataPropertyName = "idParent";
			this.dataGridViewTextBoxColumn_1.HeaderText = "Родитель";
			this.dataGridViewTextBoxColumn_1.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn_1.Visible = false;
			this.dataGridViewTextBoxColumn_2.DataPropertyName = "TypeDoc";
			this.dataGridViewTextBoxColumn_2.HeaderText = "TypeDoc";
			this.dataGridViewTextBoxColumn_2.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn_2.Visible = false;
			this.dataGridViewTextBoxColumn_3.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_3.HeaderText = "id";
			this.dataGridViewTextBoxColumn_3.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn_3.Visible = false;
			this.dataGridViewTextBoxColumn_4.DataPropertyName = "idReason";
			this.dataGridViewTextBoxColumn_4.HeaderText = "idReason";
			this.dataGridViewTextBoxColumn_4.Name = "dataGridViewTextBoxColumn5";
			this.dataGridViewTextBoxColumn_4.Visible = false;
			this.dataGridViewTextBoxColumn_5.DataPropertyName = "idReqForRepair";
			this.dataGridViewTextBoxColumn_5.HeaderText = "idReqForRepair";
			this.dataGridViewTextBoxColumn_5.Name = "dataGridViewTextBoxColumn6";
			this.dataGridViewTextBoxColumn_5.Visible = false;
			this.backgroundWorker_0.DoWork += this.backgroundWorker_0_DoWork;
			this.backgroundWorker_0.RunWorkerCompleted += this.backgroundWorker_0_RunWorkerCompleted;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(1329, 738);
			base.Controls.Add(this.splitContainer_0);
			base.Controls.Add(this.toolStrip_0);
			base.Name = "FormJournalDamage";
			this.Text = "Журнал технологических нарушений";
			base.FormClosed += this.FormJournalDamage_FormClosed;
			base.Load += this.FormJournalDamage_Load;
			this.toolStrip_0.ResumeLayout(false);
			this.toolStrip_0.PerformLayout();
			this.splitContainer_0.Panel1.ResumeLayout(false);
			this.splitContainer_0.Panel1.PerformLayout();
			this.splitContainer_0.Panel2.ResumeLayout(false);
			this.splitContainer_0.ResumeLayout(false);
			this.groupBox_0.ResumeLayout(false);
			this.groupBox_0.PerformLayout();
			this.toolStrip_2.ResumeLayout(false);
			this.toolStrip_2.PerformLayout();
			this.toolStrip_1.ResumeLayout(false);
			this.toolStrip_1.PerformLayout();
			this.splitContainer_1.Panel1.ResumeLayout(false);
			this.splitContainer_1.Panel2.ResumeLayout(false);
			this.splitContainer_1.ResumeLayout(false);
			((ISupportInitialize)this.dataGridViewExcelFilter_0).EndInit();
			((ISupportInitialize)this.bindingSource_0).EndInit();
			((ISupportInitialize)this.class171_0).EndInit();
			((ISupportInitialize)this.dataGridViewExcelFilter_1).EndInit();
			((ISupportInitialize)this.bindingSource_1).EndInit();
			((ISupportInitialize)this.dataSet_0).EndInit();
			((ISupportInitialize)this.dataTable_0).EndInit();
			this.contextMenuStrip_0.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private List<int> list_0;

		private string string_0;

		private int int_0;

		private ToolStrip toolStrip_0;

		private SplitContainer splitContainer_0;

		private CheckedListBox checkedListBox_0;

		private Label label_0;

		private DateTimePicker dateTimePicker_0;

		private Label label_1;

		private DateTimePicker dateTimePicker_1;

		private Label label_2;

		private ToolStrip toolStrip_1;

		private ToolStripButton toolStripButton_0;

		private ToolStripButton toolStripButton_1;

		private ToolStripButton toolStripButton_2;

		private ToolStripButton toolStripButton_3;

		private ToolStripDropDownButton toolStripDropDownButton_0;

		private ToolStripButton toolStripButton_4;

		private DataGridViewExcelFilter dataGridViewExcelFilter_0;

		private BindingSource bindingSource_0;

		private Class171 class171_0;

		private ToolStripButton toolStripButton_5;

		private TreeViewSchmObjects treeViewSchmObjects_0;

		private ToolStrip toolStrip_2;

		private ToolStripButton toolStripButton_6;

		private ToolStripTextBox toolStripTextBox_0;

		private ToolStripButton toolStripButton_7;

		private ToolStripButton toolStripButton_8;

		private CheckBox checkBox_0;

		private ToolStripButton toolStripButton_9;

		private ToolStripSeparator toolStripSeparator_0;

		private ToolStripButton toolStripButton_10;

		private ToolStripSeparator toolStripSeparator_1;

		private ToolStripButton toolStripButton_11;

		private ToolStripTextBox toolStripTextBox_1;

		private ToolStripButton toolStripButton_12;

		private ToolStripButton toolStripButton_13;

		private ToolStripSeparator toolStripSeparator_2;

		private ToolStripDropDownButton toolStripDropDownButton_1;

		private ToolStripMenuItem toolStripMenuItem_0;

		private ToolStripSeparator toolStripSeparator_3;

		private ToolStripDropDownButton toolStripDropDownButton_2;

		private ToolStripMenuItem toolStripMenuItem_1;

		private ToolStripMenuItem toolStripMenuItem_2;

		private ToolStripMenuItem toolStripMenuItem_3;

		private ToolStripMenuItem toolStripMenuItem_4;

		private ToolStripButton toolStripButton_14;

		private ToolStripButton toolStripButton_15;

		private ToolStripButton toolStripButton_16;

		private ToolStripMenuItem toolStripMenuItem_5;

		private ToolStripMenuItem toolStripMenuItem_6;

		private ToolStripMenuItem toolStripMenuItem_7;

		private ContextMenuStrip contextMenuStrip_0;

		private ToolStripMenuItem toolStripMenuItem_8;

		private ToolStripMenuItem toolStripMenuItem_9;

		private ToolStripMenuItem toolStripMenuItem_10;

		private ToolStripMenuItem toolStripMenuItem_11;

		private ToolStripSeparator toolStripSeparator_4;

		private ToolStripMenuItem toolStripMenuItem_12;

		private ToolStripMenuItem toolStripMenuItem_13;

		private ToolStripSeparator toolStripSeparator_5;

		private SplitContainer splitContainer_1;

		private Label label_3;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_0;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_1;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_2;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_3;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_4;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_5;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_6;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_7;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_8;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_9;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_10;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_11;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_12;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_13;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_14;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_15;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_16;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_17;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_18;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_3;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_4;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_5;

		private DataGridViewExcelFilter dataGridViewExcelFilter_1;

		private BindingSource bindingSource_1;

		private DataSet dataSet_0;

		private DataTable dataTable_0;

		private DataColumn dataColumn_0;

		private DataColumn dataColumn_1;

		private DataColumn dataColumn_2;

		private DataColumn dataColumn_3;

		private DataColumn dataColumn_4;

		private DataColumn dataColumn_5;

		private DataColumn dataColumn_6;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_6;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_7;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_8;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_9;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_10;

		private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn_0;

		private CheckedListBox checkedListBox_1;

		private Label label_4;

		private ToolStripMenuItem toolStripMenuItem_14;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_19;

		private GroupBox groupBox_0;

		private TextBox textBox_0;

		private TextBox textBox_1;

		private TextBox textBox_2;

		private TextBox textBox_3;

		private TextBox textBox_4;

		private ToolStripMenuItem toolStripMenuItem_15;

		private ToolStripButton toolStripButton_17;

		private ToolStripProgressBar toolStripProgressBar_0;

		private BackgroundWorker backgroundWorker_0;

		private DataGridViewFilterCheckBoxColumn dataGridViewFilterCheckBoxColumn_0;

		private DataGridViewFilterCheckBoxColumn dataGridViewFilterCheckBoxColumn_1;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_20;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_21;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_22;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_23;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_24;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_25;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_26;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_27;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_28;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_29;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_30;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_31;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_32;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_33;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_34;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_35;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_36;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_37;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_38;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_39;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_40;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_11;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_41;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_42;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_12;

		private DataGridViewFilterCheckBoxColumn dataGridViewFilterCheckBoxColumn_2;

		private DataGridViewFilterCheckBoxColumn dataGridViewFilterCheckBoxColumn_3;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_13;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_14;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_15;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_16;

		private ToolStripMenuItem toolStripMenuItem_16;

		private ToolStripMenuItem toolStripMenuItem_17;

		private ToolStripMenuItem toolStripMenuItem_18;

		private struct Struct10
		{
			internal Struct10(int int_1, string string_1)
			{
				
				this.int_0 = int_1;
				this.string_0 = string_1;
			}

			public override string ToString()
			{
				return this.string_0;
			}

			internal int int_0;

			internal string string_0;
		}
	}
}
