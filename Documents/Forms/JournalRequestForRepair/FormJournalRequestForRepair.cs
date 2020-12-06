using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using ControlsLbr.DataGridViewExcelFilter;
using DataSql;
using Documents.Properties;
using FormLbr;
using FormLbr.Classes;
using RequestsClient.Forms.JournalRequestForRepair;

namespace Documents.Forms.JournalRequestForRepair
{
	public partial class FormJournalRequestForRepair : FormBase
	{
		public FormJournalRequestForRepair()
		{
			
			this.string_0 = "";
			this.int_0 = 400;
			
			this.method_12();
		}

		public FormJournalRequestForRepair(bool isCrash = false)
		{
			
			this.string_0 = "";
			this.int_0 = 400;
			
			this.method_12();
			this.bool_1 = isCrash;
			if (isCrash)
			{
				this.Text = "Журнал по отключениям для службы 05";
				base.Icon = Resources.repair_Crash1;
			}
		}

		private void FormJournalRequestForRepair_Load(object sender, EventArgs e)
		{
			this.toolStripSplitButton_1.Visible = false;
			this.dateTimePicker_1.Value = DateTime.Now.Date;
			this.dateTimePicker_0.Value = new DateTime(DateTime.Now.Year + 1, 1, 1).AddSeconds(-1.0);
			this.method_0();
			base.SelectSqlData(this.class255_0, this.class255_0.tR_Classifier, true, " where ParentKey = ';Other;DivisionRequestRepair;' and isgroup = 0 and deleted = 0 order by name");
			foreach (object obj in this.class255_0.tR_Classifier.Rows)
			{
				DataRow dataRow = (DataRow)obj;
				ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
				toolStripMenuItem.Click += this.method_2;
				toolStripMenuItem.Text = dataRow["SocrName"].ToString();
				toolStripMenuItem.Tag = dataRow["id"];
				this.toolStripSplitButton_0.DropDownItems.Add(toolStripMenuItem);
				ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem();
				toolStripMenuItem2.Click += this.method_7;
				toolStripMenuItem2.Text = dataRow["SocrName"].ToString();
				toolStripMenuItem2.Tag = dataRow["id"];
				this.toolStripSplitButton_2.DropDownItems.Add(toolStripMenuItem2);
				Struct7 @struct = new Struct7(Convert.ToInt32(dataRow["Id"]), dataRow["Name"].ToString());
				this.checkedListBox_0.Items.Add(@struct, true);
			}
			this.method_11();
			this.method_10();
		}

		private void method_0()
		{
			try
			{
				Assembly.Load("RequestsClient");
				this.bool_0 = true;
			}
			catch (Exception)
			{
			}
			this.toolStripButton_11.Visible = this.bool_0;
		}

		private void method_1(object sender, EventArgs e)
		{
			FormJournalRequestForRepairAddEdit formJournalRequestForRepairAddEdit = new FormJournalRequestForRepairAddEdit(-1, Convert.ToInt32(((ToolStripMenuItem)sender).Tag), eActionRequestRepair.Add, this.bool_1);
			formJournalRequestForRepairAddEdit.GoToSchema += this.method_3;
			formJournalRequestForRepairAddEdit.SqlSettings = this.SqlSettings;
			formJournalRequestForRepairAddEdit.MdiParent = base.MdiParent;
			formJournalRequestForRepairAddEdit.FormClosed += this.method_5;
			formJournalRequestForRepairAddEdit.Show();
		}

		private void method_2(object sender, EventArgs e)
		{
			if (Convert.ToInt32(((ToolStripMenuItem)sender).Tag) == 920 && this.bool_0)
			{
				this.method_1(sender, e);
				return;
			}
			Form54 form = new Form54(-1, Convert.ToInt32(((ToolStripMenuItem)sender).Tag), (Enum15)0, this.bool_1);
			form.GoToSchema += this.method_3;
			form.SqlSettings = this.SqlSettings;
			form.MdiParent = base.MdiParent;
			form.FormClosed += this.method_5;
			form.Show();
		}

		private void method_3(object sender, GoToSchemaEventArgs e)
		{
			this.OnGoToSchema(e);
		}

		private void toolStripButton_0_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_0.CurrentRow != null)
			{
				if (Convert.ToInt32(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_17.Name].Value) == 920 && this.bool_0)
				{
					this.method_4();
					return;
				}
				Form54 form = new Form54(Convert.ToInt32(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_18.Name].Value), -1, (Enum15)1, false);
				form.GoToSchema += this.method_3;
				form.SqlSettings = this.SqlSettings;
				form.MdiParent = base.MdiParent;
				form.FormClosed += this.method_5;
				form.Show();
			}
		}

		private void method_4()
		{
			FormJournalRequestForRepairAddEdit formJournalRequestForRepairAddEdit = new FormJournalRequestForRepairAddEdit(Convert.ToInt32(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_18.Name].Value), -1, eActionRequestRepair.Edit, this.bool_1);
			formJournalRequestForRepairAddEdit.GoToSchema += this.method_3;
			formJournalRequestForRepairAddEdit.SqlSettings = this.SqlSettings;
			formJournalRequestForRepairAddEdit.MdiParent = base.MdiParent;
			formJournalRequestForRepairAddEdit.FormClosed += this.method_5;
			formJournalRequestForRepairAddEdit.Show();
		}

		private void method_5(object sender, FormClosedEventArgs e)
		{
			if (((Form)sender).DialogResult == DialogResult.OK)
			{
				this.method_10();
			}
		}

		private void toolStripButton_2_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_0.CurrentRow != null)
			{
				if (Convert.ToInt32(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_17.Name].Value) == 920 && this.bool_0)
				{
					this.method_6();
					return;
				}
				Form54 form = new Form54(Convert.ToInt32(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_18.Name].Value), -1, (Enum15)2, false);
				form.GoToSchema += this.method_3;
				form.SqlSettings = this.SqlSettings;
				form.MdiParent = base.MdiParent;
				form.Show();
			}
		}

		private void method_6()
		{
			FormJournalRequestForRepairAddEdit formJournalRequestForRepairAddEdit = new FormJournalRequestForRepairAddEdit(Convert.ToInt32(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_18.Name].Value), -1, eActionRequestRepair.Read, false);
			formJournalRequestForRepairAddEdit.GoToSchema += this.method_3;
			formJournalRequestForRepairAddEdit.SqlSettings = this.SqlSettings;
			formJournalRequestForRepairAddEdit.MdiParent = base.MdiParent;
			formJournalRequestForRepairAddEdit.Show();
		}

		private void toolStripButton_1_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_0.SelectedRows.Count == 0)
			{
				return;
			}
			if (MessageBox.Show("Вы действительно хотите удалить выделенные заявки?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				string text = "";
				foreach (object obj in this.dataGridViewExcelFilter_0.SelectedRows)
				{
					DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
					text = text + dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_18.Name].Value.ToString() + ",";
				}
				base.SelectSqlData(this.class255_0, this.class255_0.tJ_RequestForRepair, true, "where id in (" + text.Remove(text.Length - 1) + ")");
				List<int> list = new List<int>();
				foreach (object obj2 in this.class255_0.tJ_RequestForRepair.Rows)
				{
					DataRow dataRow = (DataRow)obj2;
					if ((dataRow["isSend"] != DBNull.Value && Convert.ToBoolean(dataRow["isSend"])) || (dataRow["SendSite"] != DBNull.Value && Convert.ToBoolean(dataRow["SendSite"])))
					{
						MessageBox.Show("Заявку №" + dataRow["num"].ToString() + " невозможно удалить.\r\nНевозможно удалить отправленные заявки.", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						list.Add(Convert.ToInt32(dataRow["id"]));
					}
					else
					{
						int num = Convert.ToInt32(dataRow["id"]);
						SqlDataCommand sqlDataCommand = new SqlDataCommand(this.SqlSettings);
						DataTable dataTable = sqlDataCommand.SelectSqlData(string.Format("with  tree (id, isApply, level)\r\n                                                as (select id, isApply,  0 as level  from tj_damage\r\n\t                                                where idReqForRepair = {0}\r\n\t                                                union all \r\n\t                                                select tj_damage.id, tJ_Damage.isApply, level+1\r\n\t                                                from tj_damage\t\r\n\t\t                                                inner join tree on tree.id = tj_damage.idParent \r\n\t\t                                            )\r\n\r\n                                                select * from tree\r\n                                                where isApply = 1", num));
						if (dataTable.Rows.Count > 0)
						{
							MessageBox.Show("Заявку №" + dataRow["num"].ToString() + " невозможно удалить.\r\nУ данной заявки есть согласованные дочерние документы.", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							list.Add(Convert.ToInt32(dataRow["id"]));
						}
						else
						{
							dataTable = sqlDataCommand.SelectSqlData(string.Format("with  tree (id,  isApply, nameDOC)\r\n                                                as (select id,  isApply, typeDocname + isnull(' №' + numRequest, '') + \r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\tisnull(' от ' + CONVERT(VARCHAR(10),datedoc,104), '')\r\n\t\t\t\t\t\t\t\t\t\t\t\t   from vj_damage\r\n\t                                                where idReqForRepair = {0}\r\n\t                                                union all \r\n\t                                                select v.id, v.isApply, v.typeDocName+ isnull(' №' + v.numRequest, '') + \r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\tisnull(' от ' + CONVERT(VARCHAR(10),v.datedoc,104), '')\r\n\t                                                from vj_damage\tv\r\n\t\t                                                inner join tree on tree.id = v.idParent \r\n\t\t                                            )\r\n                                                    select * from tree", num));
							if (dataTable.Rows.Count > 0)
							{
								string text2 = "";
								string text3 = "";
								foreach (object obj3 in dataTable.Rows)
								{
									DataRow dataRow2 = (DataRow)obj3;
									if (string.IsNullOrEmpty(text2))
									{
										text2 = dataRow2["nameDoc"].ToString();
									}
									else
									{
										text2 = text2 + "\r\n" + dataRow2["nameDoc"].ToString();
									}
									if (string.IsNullOrEmpty(text3))
									{
										text3 = dataRow2["id"].ToString();
									}
									else
									{
										text3 = text3 + "," + dataRow2["id"].ToString();
									}
								}
								if (MessageBox.Show(string.Format("Вы действительно хотите удалить заявку №{0}?\r\nУ данной заявки есть следующие дочерние документы:\r\n{1}", dataRow["num"].ToString(), text2), "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
								{
									list.Add(Convert.ToInt32(dataRow["id"]));
									continue;
								}
								sqlDataCommand.UpdateSqlData(new DataTable("tJ_damage"), "set deleted = 1", "where id in (" + text3 + ")");
							}
							dataRow["deleted"] = true;
							dataRow.EndEdit();
						}
					}
				}
				base.UpdateSqlData(this.class255_0, this.class255_0.tJ_RequestForRepair);
				foreach (object obj4 in this.dataGridViewExcelFilter_0.SelectedRows)
				{
					DataGridViewRow dataGridViewRow2 = (DataGridViewRow)obj4;
					if (!list.Contains(Convert.ToInt32(dataGridViewRow2.Cells[this.dataGridViewTextBoxColumn_18.Name].Value)))
					{
						this.dataGridViewExcelFilter_0.Rows.Remove(dataGridViewRow2);
					}
				}
			}
		}

		private void method_7(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_0.CurrentRow != null && ((ToolStripMenuItem)sender).Tag != null)
			{
				base.SelectSqlData(this.class255_0, this.class255_0.tJ_RequestForRepair, true, " where id = " + this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_18.Name].Value.ToString());
				if (this.class255_0.tJ_RequestForRepair.Rows.Count > 0)
				{
					DataRow dataRow = this.class255_0.tJ_RequestForRepair.NewRow();
					dataRow.ItemArray = this.class255_0.tJ_RequestForRepair.Rows[0].ItemArray;
					dataRow["idDivision"] = Convert.ToInt32(((ToolStripMenuItem)sender).Tag);
					dataRow["Agreed"] = false;
					if (Convert.ToInt32(((ToolStripMenuItem)sender).Tag) == 920 && this.bool_0)
					{
						this.method_8(dataRow);
						return;
					}
					Form54 form = new Form54(dataRow);
					form.GoToSchema += this.method_3;
					form.SqlSettings = this.SqlSettings;
					form.MdiParent = base.MdiParent;
					form.FormClosed += this.method_5;
					form.Show();
				}
			}
		}

		private void method_8(DataRow dataRow_0)
		{
			FormJournalRequestForRepairAddEdit formJournalRequestForRepairAddEdit = new FormJournalRequestForRepairAddEdit(dataRow_0);
			formJournalRequestForRepairAddEdit.GoToSchema += this.method_3;
			formJournalRequestForRepairAddEdit.SqlSettings = this.SqlSettings;
			formJournalRequestForRepairAddEdit.MdiParent = base.MdiParent;
			formJournalRequestForRepairAddEdit.FormClosed += this.method_5;
			formJournalRequestForRepairAddEdit.Show();
		}

		private void toolStripButton_5_Click(object sender, EventArgs e)
		{
			this.method_10();
		}

		private void toolStripButton_6_Click(object sender, EventArgs e)
		{
			new Form56(this.bool_1)
			{
				SqlSettings = this.SqlSettings,
				MdiParent = base.MdiParent
			}.Show();
		}

		private void toolStripButton_7_Click(object sender, EventArgs e)
		{
			new Form53(this.bool_1)
			{
				SqlSettings = this.SqlSettings,
				MdiParent = base.MdiParent
			}.Show();
		}

		private void dataGridViewExcelFilter_0_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				if (this.toolStripButton_0.Enabled && this.toolStripButton_0.Visible)
				{
					this.toolStripButton_0_Click(sender, e);
					return;
				}
				this.toolStripButton_2_Click(sender, e);
			}
		}

		private void dataGridViewExcelFilter_0_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				if (Convert.ToBoolean(this.dataGridViewExcelFilter_0[this.dataGridViewFilterCheckBoxColumn_0.Name, e.RowIndex].Value))
				{
					e.CellStyle.BackColor = Color.LightGreen;
				}
				if (Convert.ToInt32(this.dataGridViewExcelFilter_0[this.dataGridViewTextBoxColumn_17.Name, e.RowIndex].Value) == 921)
				{
					e.CellStyle.BackColor = Color.LightGray;
				}
				if (this.dataGridViewExcelFilter_0[this.dataGridViewCheckBoxColumn_1.Name, e.RowIndex].Value != DBNull.Value && this.dataGridViewExcelFilter_0.Columns[e.ColumnIndex] == this.dataGridViewFilterTextBoxColumn_12)
				{
					if (!Convert.ToBoolean(this.dataGridViewExcelFilter_0[this.dataGridViewCheckBoxColumn_1.Name, e.RowIndex].Value))
					{
						e.CellStyle.BackColor = Color.Red;
					}
					else
					{
						e.CellStyle.BackColor = Color.Green;
					}
				}
				if (this.dataGridViewExcelFilter_0[this.dataGridViewFilterTextBoxColumn_23.Name, e.RowIndex].Value != DBNull.Value)
				{
					try
					{
						Color backColor = Color.FromName(this.dataGridViewExcelFilter_0[this.dataGridViewFilterTextBoxColumn_23.Name, e.RowIndex].Value.ToString());
						e.CellStyle.BackColor = backColor;
					}
					catch
					{
					}
				}
			}
		}

		private void toolStripMenuItem_0_Click(object sender, EventArgs e)
		{
			this.method_9(920);
		}

		private void toolStripMenuItem_1_Click(object sender, EventArgs e)
		{
			this.method_9(921);
		}

		private void method_9(int int_1)
		{
			SQLSettings sqlSett;
			if (int_1 == 920)
			{
				sqlSett = new SQLSettings("ulges-sql", "zayavki_ODS", "WINDOWS", "", "");
			}
			else
			{
				sqlSett = new SQLSettings("ulges-sql", "zayavki_PL", "WINDOWS", "", "");
			}
			SqlDataCommand sqlDataCommand = new SqlDataCommand(sqlSett);
			DataTable dataTable = sqlDataCommand.SelectSqlData("DH55388", false, "", null);
			DataTable dataTable2 = sqlDataCommand.SelectSqlData("_1SJOURN", false, "", null);
			DataTable dataTable3 = sqlDataCommand.SelectSqlData("SC55410", false, "", null);
			DataTable dataTable4 = base.SelectSqlData("vWorkerGroup", false, "");
			DataTable dataTable5 = base.SelectSqlData("tUser", false, "");
			SqlDataConnect sqlDataConnect = new SqlDataConnect();
			sqlDataConnect.OpenConnection(this.SqlSettings);
			new SqlCommand("disable trigger dbo.AfterInsert_tJ_RequestForRepair on dbo.tj_requestForRepair ", sqlDataConnect.Connection).ExecuteNonQuery();
			Class255 @class = new Class255();
			foreach (object obj in dataTable.Rows)
			{
				DataRow dataRow = (DataRow)obj;
				@class.tJ_RequestForRepair.Clear();
				@class.tJ_RequestForRepairDaily.Clear();
				DataRow dataRow2 = @class.tJ_RequestForRepair.NewRow();
				DataRow dataRow3 = @class.tJ_RequestForRepairDaily.NewRow();
				dataRow2["num"] = -1;
				TimeSpan timeSpan;
				if (int_1 == 920)
				{
					if (TimeSpan.TryParse(dataRow["SP55469"].ToString(), out timeSpan))
					{
						dataRow2["dateCreate"] = Convert.ToDateTime(dataRow["SP55397"]).Add(TimeSpan.Parse(dataRow["SP55469"].ToString()));
					}
					else
					{
						dataRow2["dateCreate"] = Convert.ToDateTime(dataRow["SP55397"]);
					}
				}
				else
				{
					dataRow2["dateCreate"] = Convert.ToDateTime(dataRow["SP55397"]);
				}
				DataRow[] array = dataTable2.Select("IDDOC = '" + dataRow["IDDOC"].ToString() + "'");
				if (array.Length != 0)
				{
					dataRow2["num"] = Convert.ToInt32(array[0]["DOCNO"].ToString().Trim());
					DataRow[] array2 = dataTable3.Select("ID = '" + array[0]["SP55413"].ToString() + "'");
					if (array2.Length != 0)
					{
						DataRow[] array3 = dataTable4.Select("FIO = '" + array2[0]["DESCR"].ToString().Trim() + "'");
						if (array3.Length != 0)
						{
							dataRow2["idWorker"] = array3[0]["id"];
							DataRow[] array4 = dataTable5.Select("idWorker = " + dataTable4.Rows[0]["id"].ToString());
							if (array4.Length != 0)
							{
								dataRow2["idUserCreate"] = array4[0]["idUser"];
							}
						}
						else
						{
							dataRow2["idWorker"] = 0;
						}
					}
					else
					{
						dataRow2["IdWorker"] = -1;
					}
				}
				else
				{
					dataRow2["IdWorker"] = -1;
				}
				dataRow2["ReguestFiled"] = dataRow["SP55452"].ToString().Trim();
				switch (Convert.ToInt32(dataRow["SP55391"]))
				{
				case 1:
					dataRow2["idSR"] = 756;
					break;
				case 2:
					dataRow2["idSR"] = 757;
					break;
				case 3:
					dataRow2["idSR"] = 758;
					break;
				case 4:
					dataRow2["idSR"] = 759;
					break;
				default:
					continue;
				}
				dataRow2["SchmObj"] = dataRow["SP55393"].ToString().Trim();
				dataRow2["Purpose"] = dataRow["SP55394"].ToString().Trim();
				dataRow2["IsPlanned"] = (dataRow["SP55395"].ToString().Trim() == "16QE");
				if (TimeSpan.TryParse(dataRow["SP55398"].ToString(), out timeSpan))
				{
					dataRow3["DateBeg"] = Convert.ToDateTime(dataRow["SP55396"]).Add(TimeSpan.Parse(dataRow["SP55398"].ToString()));
				}
				else
				{
					dataRow3["DateBeg"] = Convert.ToDateTime(dataRow["SP55396"]);
				}
				if (array.Length != 0)
				{
					string text = array[0]["Date_TIMe_IDDOC"].ToString().Trim().Remove(8);
					DateTime dateTime = new DateTime(Convert.ToInt32(text.Remove(4)), Convert.ToInt32(text.Substring(4, 2)), Convert.ToInt32(text.Substring(6, 2)));
					if (TimeSpan.TryParse(dataRow["SP55449"].ToString(), out timeSpan))
					{
						dataRow3["DateEnd"] = dateTime.Add(TimeSpan.Parse(dataRow["SP55449"].ToString()));
					}
					else
					{
						dataRow3["DateEnd"] = dateTime;
					}
				}
				else if (TimeSpan.TryParse(dataRow["SP55449"].ToString(), out timeSpan))
				{
					dataRow3["DateEnd"] = Convert.ToDateTime(dataRow["SP55396"]).Add(TimeSpan.Parse(dataRow["SP55449"].ToString()));
				}
				else
				{
					dataRow3["DateEnd"] = Convert.ToDateTime(dataRow["SP55396"]);
				}
				dataRow2["Agreed"] = (dataRow["SP55400"].ToString().Trim() == "16QY");
				dataRow2["AgreeWith"] = dataRow["SP55399"].ToString().Trim();
				dataRow2["Comment"] = dataRow["SP475"].ToString().Trim();
				if (int_1 == 920)
				{
					dataRow2["Address"] = dataRow["SP55463"].ToString().Trim();
				}
				dataRow2["iddivision"] = int_1;
				dataRow2["deleted"] = false;
				@class.tJ_RequestForRepair.Rows.Add(dataRow2);
				int num = base.InsertSqlDataOneRow(@class, @class.tJ_RequestForRepair);
				dataRow3["idRequest"] = num;
				@class.tJ_RequestForRepairDaily.Rows.Add(dataRow3);
				base.InsertSqlData(@class, @class.tJ_RequestForRepairDaily);
			}
			new SqlCommand("enable trigger dbo.AfterInsert_tJ_RequestForRepair on dbo.tj_requestForRepair ", sqlDataConnect.Connection).ExecuteNonQuery();
		}

		private void dateTimePicker_1_ValueChanged(object sender, EventArgs e)
		{
			this.dateTimePicker_0.MinDate = this.dateTimePicker_1.Value;
		}

		private void dateTimePicker_0_ValueChanged(object sender, EventArgs e)
		{
			this.dateTimePicker_1.MaxDate = this.dateTimePicker_0.Value;
		}

		private void method_10()
		{
			int num = -1;
			if (this.dataGridViewExcelFilter_0.CurrentRow != null)
			{
				num = Convert.ToInt32(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_18.Name].Value);
			}
			this.toolStrip_0.Enabled = false;
			this.splitContainer_0.Enabled = false;
			this.toolStripProgressBar_0.Visible = true;
			this.toolStripLabel_0.Visible = true;
			this.string_0 = this.bindingSource_0.Sort;
			this.bindingSource_0.Sort = string.Empty;
			this.bindingSource_0.DataMember = null;
			this.backgroundWorker_0.RunWorkerAsync(num);
		}

		private void backgroundWorker_0_DoWork(object sender, DoWorkEventArgs e)
		{
			string text = "'" + this.dateTimePicker_1.Value.Date.ToString("yyyyMMdd") + "'";
			string text2 = "'" + this.dateTimePicker_0.Value.ToString("yyyyMMdd HH:mm:ss") + "'";
			string text3 = string.Concat(new string[]
			{
				" ((dateBeg <= ",
				text2,
				" and dateEnd >= ",
				text,
				"))"
			});
			text3 = string.Format(" (id in (select idRequest from tj_requestForRepairDaily where {0})) ", text3);
			string text4 = " and (crash = 0 or crash is null) ";
			if (this.bool_1)
			{
				text4 = " and (crash = 1) ";
			}
			string text5 = "";
			foreach (object obj in this.checkedListBox_0.CheckedItems)
			{
				text5 = text5 + ((Struct7)obj).int_0.ToString() + ",";
			}
			if (text5.Length > 0)
			{
				base.SelectSqlData(this.class255_0, this.class255_0.vJ_RequestForRepair, true, string.Concat(new string[]
				{
					" where ",
					text3,
					text4,
					" and idDivision in (",
					text5.Remove(text5.Length - 1),
					") and deleted = 0 order by datecreate desc"
				}));
			}
			else
			{
				this.class255_0.vJ_RequestForRepair.Clear();
			}
			e.Result = e.Argument;
		}

		private void backgroundWorker_0_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.toolStrip_0.Enabled = true;
			this.splitContainer_0.Enabled = true;
			this.toolStripProgressBar_0.Visible = false;
			this.toolStripLabel_0.Visible = false;
			this.bindingSource_0.DataMember = this.class255_0.vJ_RequestForRepair.TableName;
			this.bindingSource_0.Sort = this.string_0;
			if (e.Result != null && Convert.ToInt32(e.Result) > 0)
			{
				this.dataGridViewExcelFilter_0.SearchGrid(this.dataGridViewTextBoxColumn_18.Name, e.Result.ToString(), false);
			}
		}

		private void toolStripButton_3_Click(object sender, EventArgs e)
		{
			this.method_10();
		}

		private void toolStripButton_4_Click(object sender, EventArgs e)
		{
			this.dateTimePicker_1.MaxDate = new DateTime(DateTime.Now.Year, 1, 1);
			this.dateTimePicker_1.Value = new DateTime(DateTime.Now.Year, 1, 1);
			this.dateTimePicker_0.Value = new DateTime(DateTime.Now.Year + 1, 1, 1).AddSeconds(-1.0);
			for (int i = 0; i < this.checkedListBox_0.Items.Count; i++)
			{
				this.checkedListBox_0.SetItemChecked(i, true);
			}
			this.method_10();
		}

		private void dataGridViewExcelFilter_0_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
		{
			this.dataGridViewExcelFilter_0.AutoResizeRow(e.RowIndex);
		}

		private void toolStripButton_8_Click(object sender, EventArgs e)
		{
			this.dataGridViewExcelFilter_0.SearchGrid(DataGridViewExcelFilter.TypeFind.Begin, this.toolStripTextBox_0.Text);
		}

		private void toolStripButton_9_Click(object sender, EventArgs e)
		{
			this.dataGridViewExcelFilter_0.SearchGrid(DataGridViewExcelFilter.TypeFind.Prev, this.toolStripTextBox_0.Text);
		}

		private void toolStripButton_10_Click(object sender, EventArgs e)
		{
			this.dataGridViewExcelFilter_0.SearchGrid(DataGridViewExcelFilter.TypeFind.Next, this.toolStripTextBox_0.Text);
		}

		private void toolStripTextBox_0_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				Keys modifiers = e.Modifiers;
				if (modifiers == Keys.None)
				{
					this.dataGridViewExcelFilter_0.SearchGrid(DataGridViewExcelFilter.TypeFind.Next, this.toolStripTextBox_0.Text);
					return;
				}
				if (modifiers != Keys.Shift)
				{
					return;
				}
				this.dataGridViewExcelFilter_0.SearchGrid(DataGridViewExcelFilter.TypeFind.Prev, this.toolStripTextBox_0.Text);
			}
		}

		private void toolStripButton_11_Click(object sender, EventArgs e)
		{
			new FormSettingsSender
			{
				SqlSettings = this.SqlSettings,
				MdiParent = base.MdiParent
			}.Show();
		}

		private void method_11()
		{
			if (this.bool_1)
			{
				this.splitContainer_1.SplitterDistance = this.splitContainer_1.Height - this.splitContainer_1.SplitterWidth - this.label_3.Height;
				this.splitContainer_1.IsSplitterFixed = true;
				return;
			}
			this.splitContainer_1.Panel2Collapsed = true;
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

		private void bindingSource_0_CurrentChanged(object sender, EventArgs e)
		{
			this.class171_0.vJ_Damage.Clear();
			if (this.bindingSource_0.Current != null && this.bindingSource_0.Current is DataRowView)
			{
				int num = Convert.ToInt32(((DataRowView)this.bindingSource_0.Current).Row["id"]);
				try
				{
					using (SqlConnection sqlConnection = new SqlConnection(this.SqlSettings.GetConnectionString()))
					{
						sqlConnection.Open();
						using (SqlCommand sqlCommand = new SqlCommand(string.Format("with  tree (numRequest, dateDoc, TypeDocName, TYpeDoc, schmObjName, id, isApply)\r\n                                                as (select numRequest, dateDoc, TypeDocName, TypeDoc, schmObjName, id, isApply\r\n\t\t\t\t\t\t\t\t\t\t\t\t   from vj_damage\r\n\t                                                where idReqForRepair = {0}\r\n\t                                                union all \r\n\t                                                select v.numRequest, v.dateDoc, v.TypeDocName, v.typeDoc, v.schmObjName, v.id, v.isApply\r\n\t                                                from vj_damage\tv\r\n\t\t                                                inner join tree on tree.id = v.idParent \r\n\t\t                                            )\r\n                                                    select * from tree", num), sqlConnection))
						{
							new SqlDataAdapter(sqlCommand).Fill(this.class171_0.vJ_Damage);
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
		}

		private void method_12()
		{
			this.icontainer_0 = new Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FormJournalRequestForRepair));
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
			this.toolStrip_0 = new ToolStrip();
			this.toolStripSplitButton_0 = new ToolStripSplitButton();
			this.toolStripButton_0 = new ToolStripButton();
			this.toolStripButton_2 = new ToolStripButton();
			this.toolStripButton_1 = new ToolStripButton();
			this.toolStripSplitButton_1 = new ToolStripSplitButton();
			this.toolStripMenuItem_0 = new ToolStripMenuItem();
			this.toolStripMenuItem_1 = new ToolStripMenuItem();
			this.toolStripProgressBar_0 = new ToolStripProgressBar();
			this.toolStripLabel_0 = new ToolStripLabel();
			this.toolStripSplitButton_2 = new ToolStripSplitButton();
			this.toolStripSeparator_0 = new ToolStripSeparator();
			this.toolStripButton_5 = new ToolStripButton();
			this.toolStripButton_6 = new ToolStripButton();
			this.toolStripButton_7 = new ToolStripButton();
			this.toolStripSeparator_1 = new ToolStripSeparator();
			this.toolStripButton_8 = new ToolStripButton();
			this.toolStripTextBox_0 = new ToolStripTextBox();
			this.toolStripButton_9 = new ToolStripButton();
			this.toolStripButton_10 = new ToolStripButton();
			this.toolStripSeparator_2 = new ToolStripSeparator();
			this.toolStripButton_11 = new ToolStripButton();
			this.dataGridViewExcelFilter_0 = new DataGridViewExcelFilter();
			this.dataGridViewCheckBoxColumn_1 = new DataGridViewCheckBoxColumn();
			this.dataGridViewCheckBoxColumn_2 = new DataGridViewCheckBoxColumn();
			this.dataGridViewCheckBoxColumn_3 = new DataGridViewCheckBoxColumn();
			this.dataGridViewFilterTextBoxColumn_12 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_13 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_14 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_15 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_16 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_17 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_18 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_19 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterCheckBoxColumn_0 = new DataGridViewFilterCheckBoxColumn();
			this.dataGridViewFilterTextBoxColumn_20 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewTextBoxColumn_12 = new DataGridViewTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_21 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewTextBoxColumn_13 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_14 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_15 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_16 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_17 = new DataGridViewTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_22 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterCheckBoxColumn_1 = new DataGridViewFilterCheckBoxColumn();
			this.dataGridViewTextBoxColumn_18 = new DataGridViewTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_23 = new DataGridViewFilterTextBoxColumn();
			this.bindingSource_0 = new BindingSource(this.icontainer_0);
			this.class255_0 = new Class255();
			this.splitContainer_0 = new SplitContainer();
			this.checkedListBox_0 = new CheckedListBox();
			this.label_2 = new Label();
			this.dateTimePicker_0 = new DateTimePicker();
			this.dateTimePicker_1 = new DateTimePicker();
			this.label_1 = new Label();
			this.label_0 = new Label();
			this.toolStrip_1 = new ToolStrip();
			this.toolStripButton_3 = new ToolStripButton();
			this.toolStripButton_4 = new ToolStripButton();
			this.splitContainer_1 = new SplitContainer();
			this.dataGridViewExcelFilter_1 = new DataGridViewExcelFilter();
			this.dataGridViewTextBoxColumn_7 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_8 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_9 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_10 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_11 = new DataGridViewTextBoxColumn();
			this.dataGridViewCheckBoxColumn_0 = new DataGridViewCheckBoxColumn();
			this.bindingSource_1 = new BindingSource(this.icontainer_0);
			this.class171_0 = new Class171();
			this.label_3 = new Label();
			this.backgroundWorker_0 = new BackgroundWorker();
			this.dataGridViewFilterTextBoxColumn_0 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_1 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_2 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_3 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_4 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_5 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_6 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_7 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_8 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_9 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_3 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_4 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_5 = new DataGridViewTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_10 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewTextBoxColumn_6 = new DataGridViewTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_11 = new DataGridViewFilterTextBoxColumn();
			this.toolStrip_0.SuspendLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_0).BeginInit();
			((ISupportInitialize)this.bindingSource_0).BeginInit();
			((ISupportInitialize)this.class255_0).BeginInit();
			this.splitContainer_0.Panel1.SuspendLayout();
			this.splitContainer_0.Panel2.SuspendLayout();
			this.splitContainer_0.SuspendLayout();
			this.toolStrip_1.SuspendLayout();
			this.splitContainer_1.Panel1.SuspendLayout();
			this.splitContainer_1.Panel2.SuspendLayout();
			this.splitContainer_1.SuspendLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_1).BeginInit();
			((ISupportInitialize)this.bindingSource_1).BeginInit();
			((ISupportInitialize)this.class171_0).BeginInit();
			base.SuspendLayout();
			this.toolStrip_0.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripSplitButton_0,
				this.toolStripButton_0,
				this.toolStripButton_2,
				this.toolStripButton_1,
				this.toolStripSplitButton_1,
				this.toolStripProgressBar_0,
				this.toolStripLabel_0,
				this.toolStripSplitButton_2,
				this.toolStripSeparator_0,
				this.toolStripButton_5,
				this.toolStripButton_6,
				this.toolStripButton_7,
				this.toolStripSeparator_1,
				this.toolStripButton_8,
				this.toolStripTextBox_0,
				this.toolStripButton_9,
				this.toolStripButton_10,
				this.toolStripSeparator_2,
				this.toolStripButton_11
			});
			this.toolStrip_0.Location = new Point(0, 0);
			this.toolStrip_0.Name = "toolStrip";
			this.toolStrip_0.Size = new Size(1026, 25);
			this.toolStrip_0.TabIndex = 0;
			this.toolStrip_0.Text = "toolStrip1";
			this.toolStripSplitButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripSplitButton_0.Image = Resources.ElementAdd;
			this.toolStripSplitButton_0.ImageTransparentColor = Color.Magenta;
			this.toolStripSplitButton_0.Name = "toolSplitBtnAddRequestRepair";
			this.toolStripSplitButton_0.Size = new Size(32, 22);
			this.toolStripSplitButton_0.Text = "Новая заявка";
			this.toolStripButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_0.Image = Resources.ElementEdit;
			this.toolStripButton_0.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_0.Name = "toolBtnEditRequestRepair";
			this.toolStripButton_0.Size = new Size(23, 22);
			this.toolStripButton_0.Text = "Редактировать заявку";
			this.toolStripButton_0.Click += this.toolStripButton_0_Click;
			this.toolStripButton_2.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_2.Image = Resources.ElementInformation;
			this.toolStripButton_2.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_2.Name = "toolBtnReadRequestRepair";
			this.toolStripButton_2.Size = new Size(23, 22);
			this.toolStripButton_2.Text = "Просмотр заявки";
			this.toolStripButton_2.Click += this.toolStripButton_2_Click;
			this.toolStripButton_1.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_1.Image = Resources.ElementDel;
			this.toolStripButton_1.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_1.Name = "toolBtnDelRequestRepair";
			this.toolStripButton_1.Size = new Size(23, 22);
			this.toolStripButton_1.Text = "Удалить заявку";
			this.toolStripButton_1.Click += this.toolStripButton_1_Click;
			this.toolStripSplitButton_1.Alignment = ToolStripItemAlignment.Right;
			this.toolStripSplitButton_1.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripSplitButton_1.DropDownItems.AddRange(new ToolStripItem[]
			{
				this.toolStripMenuItem_0,
				this.toolStripMenuItem_1
			});
			this.toolStripSplitButton_1.Image = (Image)componentResourceManager.GetObject("toolBtnImport.Image");
			this.toolStripSplitButton_1.ImageTransparentColor = Color.Magenta;
			this.toolStripSplitButton_1.Name = "toolBtnImport";
			this.toolStripSplitButton_1.Size = new Size(32, 22);
			this.toolStripSplitButton_1.Text = "toolStripSplitButton1";
			this.toolStripMenuItem_0.Name = "toolBtnImportODS";
			this.toolStripMenuItem_0.Size = new Size(99, 22);
			this.toolStripMenuItem_0.Text = "ОДС";
			this.toolStripMenuItem_0.Click += this.toolStripMenuItem_0_Click;
			this.toolStripMenuItem_1.Name = "toolBtnImportPL";
			this.toolStripMenuItem_1.Size = new Size(99, 22);
			this.toolStripMenuItem_1.Text = "ПЛ";
			this.toolStripMenuItem_1.Click += this.toolStripMenuItem_1_Click;
			this.toolStripProgressBar_0.Alignment = ToolStripItemAlignment.Right;
			this.toolStripProgressBar_0.Name = "toolStripProgressBarLoad";
			this.toolStripProgressBar_0.Size = new Size(100, 22);
			this.toolStripProgressBar_0.Style = ProgressBarStyle.Marquee;
			this.toolStripProgressBar_0.Visible = false;
			this.toolStripLabel_0.Alignment = ToolStripItemAlignment.Right;
			this.toolStripLabel_0.Name = "toolStripLabelLoad";
			this.toolStripLabel_0.Size = new Size(55, 22);
			this.toolStripLabel_0.Text = "Загрузка";
			this.toolStripLabel_0.Visible = false;
			this.toolStripSplitButton_2.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripSplitButton_2.Image = Resources.CopyBuffer;
			this.toolStripSplitButton_2.ImageTransparentColor = Color.Magenta;
			this.toolStripSplitButton_2.Name = "toolBtnRequestCopy";
			this.toolStripSplitButton_2.Size = new Size(32, 22);
			this.toolStripSplitButton_2.Text = "Копировать";
			this.toolStripSeparator_0.Name = "toolStripSeparator1";
			this.toolStripSeparator_0.Size = new Size(6, 25);
			this.toolStripButton_5.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_5.Image = Resources.refresh_16;
			this.toolStripButton_5.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_5.Name = "toolBrnRefresh";
			this.toolStripButton_5.Size = new Size(23, 22);
			this.toolStripButton_5.Text = "Обновить";
			this.toolStripButton_5.Click += this.toolStripButton_5_Click;
			this.toolStripButton_6.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_6.Image = Resources.report;
			this.toolStripButton_6.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_6.Name = "toolBtnReport";
			this.toolStripButton_6.Size = new Size(23, 22);
			this.toolStripButton_6.Text = "Отчет";
			this.toolStripButton_6.Click += this.toolStripButton_6_Click;
			this.toolStripButton_7.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_7.Image = Resources.report_go;
			this.toolStripButton_7.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_7.Name = "toolBtnExport";
			this.toolStripButton_7.Size = new Size(23, 22);
			this.toolStripButton_7.Text = "Экспорт";
			this.toolStripButton_7.Click += this.toolStripButton_7_Click;
			this.toolStripSeparator_1.Name = "toolStripSeparator2";
			this.toolStripSeparator_1.Size = new Size(6, 25);
			this.toolStripButton_8.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_8.Image = Resources.Find;
			this.toolStripButton_8.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_8.Name = "toolBtnFind";
			this.toolStripButton_8.Size = new Size(23, 22);
			this.toolStripButton_8.Text = "Поиск";
			this.toolStripButton_8.Click += this.toolStripButton_8_Click;
			this.toolStripTextBox_0.Name = "toolTextFind";
			this.toolStripTextBox_0.Size = new Size(150, 25);
			this.toolStripTextBox_0.ToolTipText = "Текст для поиска";
			this.toolStripTextBox_0.KeyDown += this.toolStripTextBox_0_KeyDown;
			this.toolStripButton_9.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_9.Image = Resources.FindPrev;
			this.toolStripButton_9.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_9.Name = "toolBtnFindPrev";
			this.toolStripButton_9.Size = new Size(23, 22);
			this.toolStripButton_9.Text = "Поиск назад";
			this.toolStripButton_9.Click += this.toolStripButton_9_Click;
			this.toolStripButton_10.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_10.Image = Resources.FindNext;
			this.toolStripButton_10.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_10.Name = "toolBtnFindNext";
			this.toolStripButton_10.Size = new Size(23, 22);
			this.toolStripButton_10.Text = "Поиск вперед";
			this.toolStripButton_10.Click += this.toolStripButton_10_Click;
			this.toolStripSeparator_2.Name = "toolStripSeparator3";
			this.toolStripSeparator_2.Size = new Size(6, 25);
			this.toolStripButton_11.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_11.Image = Resources.FTP;
			this.toolStripButton_11.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_11.Name = "toolBtnSettingsSend";
			this.toolStripButton_11.Size = new Size(23, 22);
			this.toolStripButton_11.Text = "Настройки отправки";
			this.toolStripButton_11.Click += this.toolStripButton_11_Click;
			this.dataGridViewExcelFilter_0.AllowUserToAddRows = false;
			this.dataGridViewExcelFilter_0.AllowUserToDeleteRows = false;
			this.dataGridViewExcelFilter_0.AllowUserToOrderColumns = true;
			this.dataGridViewExcelFilter_0.AutoGenerateColumns = false;
			dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle.BackColor = SystemColors.Control;
			dataGridViewCellStyle.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
			this.dataGridViewExcelFilter_0.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
			this.dataGridViewExcelFilter_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewExcelFilter_0.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewCheckBoxColumn_1,
				this.dataGridViewCheckBoxColumn_2,
				this.dataGridViewCheckBoxColumn_3,
				this.dataGridViewFilterTextBoxColumn_12,
				this.dataGridViewFilterTextBoxColumn_13,
				this.dataGridViewFilterTextBoxColumn_14,
				this.dataGridViewFilterTextBoxColumn_15,
				this.dataGridViewFilterTextBoxColumn_16,
				this.dataGridViewFilterTextBoxColumn_17,
				this.dataGridViewFilterTextBoxColumn_18,
				this.dataGridViewFilterTextBoxColumn_19,
				this.dataGridViewFilterCheckBoxColumn_0,
				this.dataGridViewFilterTextBoxColumn_20,
				this.dataGridViewTextBoxColumn_12,
				this.dataGridViewFilterTextBoxColumn_21,
				this.dataGridViewTextBoxColumn_13,
				this.dataGridViewTextBoxColumn_14,
				this.dataGridViewTextBoxColumn_15,
				this.dataGridViewTextBoxColumn_16,
				this.dataGridViewTextBoxColumn_17,
				this.dataGridViewFilterTextBoxColumn_22,
				this.dataGridViewFilterCheckBoxColumn_1,
				this.dataGridViewTextBoxColumn_18,
				this.dataGridViewFilterTextBoxColumn_23
			});
			this.dataGridViewExcelFilter_0.DataSource = this.bindingSource_0;
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = SystemColors.Window;
			dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
			this.dataGridViewExcelFilter_0.DefaultCellStyle = dataGridViewCellStyle2;
			this.dataGridViewExcelFilter_0.Dock = DockStyle.Fill;
			this.dataGridViewExcelFilter_0.Location = new Point(0, 0);
			this.dataGridViewExcelFilter_0.Name = "dgv";
			this.dataGridViewExcelFilter_0.ReadOnly = true;
			this.dataGridViewExcelFilter_0.RowHeadersWidth = 21;
			this.dataGridViewExcelFilter_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewExcelFilter_0.Size = new Size(845, 400);
			this.dataGridViewExcelFilter_0.TabIndex = 1;
			this.dataGridViewExcelFilter_0.VirtualMode = true;
			this.dataGridViewExcelFilter_0.CellDoubleClick += this.dataGridViewExcelFilter_0_CellDoubleClick;
			this.dataGridViewExcelFilter_0.CellFormatting += this.dataGridViewExcelFilter_0_CellFormatting;
			this.dataGridViewExcelFilter_0.RowPostPaint += this.dataGridViewExcelFilter_0_RowPostPaint;
			this.dataGridViewCheckBoxColumn_1.DataPropertyName = "isSend";
			this.dataGridViewCheckBoxColumn_1.HeaderText = "isSend";
			this.dataGridViewCheckBoxColumn_1.Name = "isSendDgvColumn";
			this.dataGridViewCheckBoxColumn_1.ReadOnly = true;
			this.dataGridViewCheckBoxColumn_1.Visible = false;
			this.dataGridViewCheckBoxColumn_2.DataPropertyName = "IsPlanned";
			this.dataGridViewCheckBoxColumn_2.HeaderText = "Плановый";
			this.dataGridViewCheckBoxColumn_2.Name = "isPlannedDataGridViewCheckBoxColumn";
			this.dataGridViewCheckBoxColumn_2.ReadOnly = true;
			this.dataGridViewCheckBoxColumn_2.Visible = false;
			this.dataGridViewCheckBoxColumn_3.DataPropertyName = "deleted";
			this.dataGridViewCheckBoxColumn_3.HeaderText = "Удалено";
			this.dataGridViewCheckBoxColumn_3.Name = "deletedDgvCheckBoxColumn";
			this.dataGridViewCheckBoxColumn_3.ReadOnly = true;
			this.dataGridViewCheckBoxColumn_3.Visible = false;
			this.dataGridViewFilterTextBoxColumn_12.DataPropertyName = "num";
			this.dataGridViewFilterTextBoxColumn_12.HeaderText = "Номер";
			this.dataGridViewFilterTextBoxColumn_12.Name = "numDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_12.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_12.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_13.DataPropertyName = "dateCreate";
			this.dataGridViewFilterTextBoxColumn_13.HeaderText = "Дата";
			this.dataGridViewFilterTextBoxColumn_13.Name = "dateCreateDgvColumn";
			this.dataGridViewFilterTextBoxColumn_13.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_14.DataPropertyName = "SRSocr";
			this.dataGridViewFilterTextBoxColumn_14.HeaderText = "Район";
			this.dataGridViewFilterTextBoxColumn_14.Name = "sRDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_14.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_14.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_15.DataPropertyName = "reguestFiled";
			this.dataGridViewFilterTextBoxColumn_15.HeaderText = "Подал";
			this.dataGridViewFilterTextBoxColumn_15.Name = "reguestFiledDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_15.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_15.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_16.DataPropertyName = "schmObj";
			dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_16.DefaultCellStyle = dataGridViewCellStyle3;
			this.dataGridViewFilterTextBoxColumn_16.HeaderText = "Объект";
			this.dataGridViewFilterTextBoxColumn_16.Name = "schmObjDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_16.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_16.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_17.DataPropertyName = "Purpose";
			dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_17.DefaultCellStyle = dataGridViewCellStyle4;
			this.dataGridViewFilterTextBoxColumn_17.HeaderText = "Цель";
			this.dataGridViewFilterTextBoxColumn_17.Name = "PurposeDgvTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_17.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_18.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			this.dataGridViewFilterTextBoxColumn_18.DataPropertyName = "DateTripBeg";
			dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_18.DefaultCellStyle = dataGridViewCellStyle5;
			this.dataGridViewFilterTextBoxColumn_18.HeaderText = "Дата С";
			this.dataGridViewFilterTextBoxColumn_18.Name = "dateTripBegDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_18.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_18.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_19.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			this.dataGridViewFilterTextBoxColumn_19.DataPropertyName = "DateTripEnd";
			dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_19.DefaultCellStyle = dataGridViewCellStyle6;
			this.dataGridViewFilterTextBoxColumn_19.HeaderText = "Дата По";
			this.dataGridViewFilterTextBoxColumn_19.Name = "dateTripEndDgvColumn";
			this.dataGridViewFilterTextBoxColumn_19.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_19.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterCheckBoxColumn_0.DataPropertyName = "Agreed";
			this.dataGridViewFilterCheckBoxColumn_0.FalseValue = "Нет";
			this.dataGridViewFilterCheckBoxColumn_0.HeaderText = "Заявка разрешена";
			this.dataGridViewFilterCheckBoxColumn_0.Name = "agreedDgvColumn";
			this.dataGridViewFilterCheckBoxColumn_0.ReadOnly = true;
			this.dataGridViewFilterCheckBoxColumn_0.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterCheckBoxColumn_0.TrueValue = "Да";
			this.dataGridViewFilterTextBoxColumn_20.DataPropertyName = "DateFactEnd";
			this.dataGridViewFilterTextBoxColumn_20.HeaderText = "Фактическое время выполнения";
			this.dataGridViewFilterTextBoxColumn_20.Name = "dateFactEndDgvColumn";
			this.dataGridViewFilterTextBoxColumn_20.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_20.Visible = false;
			this.dataGridViewTextBoxColumn_12.DataPropertyName = "AgreeWith";
			dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_12.DefaultCellStyle = dataGridViewCellStyle7;
			this.dataGridViewTextBoxColumn_12.HeaderText = "Согласовать с";
			this.dataGridViewTextBoxColumn_12.Name = "agreeWithDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_12.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_21.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			this.dataGridViewFilterTextBoxColumn_21.DataPropertyName = "Comment";
			dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_21.DefaultCellStyle = dataGridViewCellStyle8;
			this.dataGridViewFilterTextBoxColumn_21.HeaderText = "Комментарий";
			this.dataGridViewFilterTextBoxColumn_21.Name = "commentDataGridViewImageColumn";
			this.dataGridViewFilterTextBoxColumn_21.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_21.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_21.Width = 103;
			this.dataGridViewTextBoxColumn_13.DataPropertyName = "workerCreate";
			this.dataGridViewTextBoxColumn_13.HeaderText = "Автор";
			this.dataGridViewTextBoxColumn_13.Name = "workerCreateDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_13.ReadOnly = true;
			this.dataGridViewTextBoxColumn_13.Visible = false;
			this.dataGridViewTextBoxColumn_14.DataPropertyName = "Address";
			this.dataGridViewTextBoxColumn_14.HeaderText = "Адреса";
			this.dataGridViewTextBoxColumn_14.Name = "addressDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_14.ReadOnly = true;
			this.dataGridViewTextBoxColumn_14.Visible = false;
			this.dataGridViewTextBoxColumn_15.DataPropertyName = "DateAgreed";
			dataGridViewCellStyle9.Format = "d";
			dataGridViewCellStyle9.NullValue = null;
			this.dataGridViewTextBoxColumn_15.DefaultCellStyle = dataGridViewCellStyle9;
			this.dataGridViewTextBoxColumn_15.HeaderText = "Дата согласования";
			this.dataGridViewTextBoxColumn_15.Name = "dateAgreedDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_15.ReadOnly = true;
			this.dataGridViewTextBoxColumn_15.Visible = false;
			this.dataGridViewTextBoxColumn_16.DataPropertyName = "FIO";
			this.dataGridViewTextBoxColumn_16.HeaderText = "Диспетчер";
			this.dataGridViewTextBoxColumn_16.Name = "fIODataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_16.ReadOnly = true;
			this.dataGridViewTextBoxColumn_16.Visible = false;
			this.dataGridViewTextBoxColumn_17.DataPropertyName = "iddivision";
			this.dataGridViewTextBoxColumn_17.HeaderText = "Код подразделения";
			this.dataGridViewTextBoxColumn_17.Name = "iddivisionDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_17.ReadOnly = true;
			this.dataGridViewTextBoxColumn_17.Visible = false;
			this.dataGridViewFilterTextBoxColumn_22.DataPropertyName = "division";
			this.dataGridViewFilterTextBoxColumn_22.HeaderText = "Подразделение";
			this.dataGridViewFilterTextBoxColumn_22.Name = "divisionDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_22.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_22.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_22.Visible = false;
			this.dataGridViewFilterCheckBoxColumn_1.DataPropertyName = "SendSite";
			this.dataGridViewFilterCheckBoxColumn_1.HeaderText = "На сайт";
			this.dataGridViewFilterCheckBoxColumn_1.Name = "sendSiteDgvColumn";
			this.dataGridViewFilterCheckBoxColumn_1.ReadOnly = true;
			this.dataGridViewFilterCheckBoxColumn_1.Visible = false;
			this.dataGridViewTextBoxColumn_18.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_18.HeaderText = "id";
			this.dataGridViewTextBoxColumn_18.Name = "idDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_18.ReadOnly = true;
			this.dataGridViewTextBoxColumn_18.Visible = false;
			this.dataGridViewFilterTextBoxColumn_23.DataPropertyName = "colorStatus";
			this.dataGridViewFilterTextBoxColumn_23.HeaderText = "colorStatus";
			this.dataGridViewFilterTextBoxColumn_23.Name = "colorStatusDgvColumn";
			this.dataGridViewFilterTextBoxColumn_23.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_23.Visible = false;
			this.bindingSource_0.DataMember = "vJ_RequestForRepair";
			this.bindingSource_0.DataSource = this.class255_0;
			this.bindingSource_0.CurrentChanged += this.bindingSource_0_CurrentChanged;
			this.class255_0.DataSetName = "DataSetGES";
			this.class255_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
			this.splitContainer_0.Dock = DockStyle.Fill;
			this.splitContainer_0.FixedPanel = FixedPanel.Panel1;
			this.splitContainer_0.Location = new Point(0, 25);
			this.splitContainer_0.Name = "splitContainer";
			this.splitContainer_0.Panel1.Controls.Add(this.checkedListBox_0);
			this.splitContainer_0.Panel1.Controls.Add(this.label_2);
			this.splitContainer_0.Panel1.Controls.Add(this.dateTimePicker_0);
			this.splitContainer_0.Panel1.Controls.Add(this.dateTimePicker_1);
			this.splitContainer_0.Panel1.Controls.Add(this.label_1);
			this.splitContainer_0.Panel1.Controls.Add(this.label_0);
			this.splitContainer_0.Panel1.Controls.Add(this.toolStrip_1);
			this.splitContainer_0.Panel2.Controls.Add(this.splitContainer_1);
			this.splitContainer_0.Size = new Size(1026, 554);
			this.splitContainer_0.SplitterDistance = 177;
			this.splitContainer_0.TabIndex = 2;
			this.checkedListBox_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.checkedListBox_0.CheckOnClick = true;
			this.checkedListBox_0.FormattingEnabled = true;
			this.checkedListBox_0.Location = new Point(15, 123);
			this.checkedListBox_0.Name = "checkedListBoxDivision";
			this.checkedListBox_0.Size = new Size(153, 94);
			this.checkedListBox_0.TabIndex = 5;
			this.label_2.AutoSize = true;
			this.label_2.Location = new Point(12, 107);
			this.label_2.Name = "label3";
			this.label_2.Size = new Size(87, 13);
			this.label_2.TabIndex = 4;
			this.label_2.Text = "Подразделения";
			this.dateTimePicker_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.dateTimePicker_0.CustomFormat = "dd.MM.yyyy HH:mm:ss";
			this.dateTimePicker_0.Format = DateTimePickerFormat.Custom;
			this.dateTimePicker_0.Location = new Point(15, 84);
			this.dateTimePicker_0.Name = "dateTimePickerEnd";
			this.dateTimePicker_0.Size = new Size(153, 20);
			this.dateTimePicker_0.TabIndex = 3;
			this.dateTimePicker_0.ValueChanged += this.dateTimePicker_0_ValueChanged;
			this.dateTimePicker_1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.dateTimePicker_1.CustomFormat = "dd.MM.yyyy HH:mm:ss";
			this.dateTimePicker_1.Format = DateTimePickerFormat.Custom;
			this.dateTimePicker_1.Location = new Point(15, 45);
			this.dateTimePicker_1.Name = "dateTimePickerBeg";
			this.dateTimePicker_1.Size = new Size(153, 20);
			this.dateTimePicker_1.TabIndex = 2;
			this.dateTimePicker_1.ValueChanged += this.dateTimePicker_1_ValueChanged;
			this.label_1.AutoSize = true;
			this.label_1.Location = new Point(12, 68);
			this.label_1.Name = "label2";
			this.label_1.Size = new Size(22, 13);
			this.label_1.TabIndex = 1;
			this.label_1.Text = "До";
			this.label_0.AutoSize = true;
			this.label_0.Location = new Point(12, 29);
			this.label_0.Name = "label1";
			this.label_0.Size = new Size(20, 13);
			this.label_0.TabIndex = 0;
			this.label_0.Text = "От";
			this.toolStrip_1.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripButton_3,
				this.toolStripButton_4
			});
			this.toolStrip_1.Location = new Point(0, 0);
			this.toolStrip_1.Name = "toolStripFilter";
			this.toolStrip_1.Size = new Size(177, 25);
			this.toolStrip_1.TabIndex = 6;
			this.toolStrip_1.Text = "toolStrip1";
			this.toolStripButton_3.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_3.Image = Resources.filter;
			this.toolStripButton_3.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_3.Name = "toolBtnFilter";
			this.toolStripButton_3.Size = new Size(23, 22);
			this.toolStripButton_3.Text = "Применить фильтр";
			this.toolStripButton_3.Click += this.toolStripButton_3_Click;
			this.toolStripButton_4.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_4.Image = Resources.filter_delete;
			this.toolStripButton_4.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_4.Name = "toolBtnNoFilter";
			this.toolStripButton_4.Size = new Size(23, 22);
			this.toolStripButton_4.Text = "Убрать фильтр";
			this.toolStripButton_4.Click += this.toolStripButton_4_Click;
			this.splitContainer_1.Dock = DockStyle.Fill;
			this.splitContainer_1.FixedPanel = FixedPanel.Panel2;
			this.splitContainer_1.Location = new Point(0, 0);
			this.splitContainer_1.Name = "splitContainerDgv";
			this.splitContainer_1.Orientation = Orientation.Horizontal;
			this.splitContainer_1.Panel1.Controls.Add(this.dataGridViewExcelFilter_0);
			this.splitContainer_1.Panel2.Controls.Add(this.dataGridViewExcelFilter_1);
			this.splitContainer_1.Panel2.Controls.Add(this.label_3);
			this.splitContainer_1.Panel2MinSize = 13;
			this.splitContainer_1.Size = new Size(845, 554);
			this.splitContainer_1.SplitterDistance = 400;
			this.splitContainer_1.TabIndex = 2;
			this.dataGridViewExcelFilter_1.AllowUserToAddRows = false;
			this.dataGridViewExcelFilter_1.AllowUserToDeleteRows = false;
			this.dataGridViewExcelFilter_1.AllowUserToVisibleColumns = false;
			this.dataGridViewExcelFilter_1.AutoGenerateColumns = false;
			this.dataGridViewExcelFilter_1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewExcelFilter_1.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewTextBoxColumn_7,
				this.dataGridViewTextBoxColumn_8,
				this.dataGridViewTextBoxColumn_9,
				this.dataGridViewTextBoxColumn_10,
				this.dataGridViewTextBoxColumn_11,
				this.dataGridViewCheckBoxColumn_0
			});
			this.dataGridViewExcelFilter_1.DataSource = this.bindingSource_1;
			this.dataGridViewExcelFilter_1.Dock = DockStyle.Fill;
			this.dataGridViewExcelFilter_1.Location = new Point(0, 13);
			this.dataGridViewExcelFilter_1.Name = "dgvDamage";
			this.dataGridViewExcelFilter_1.ReadOnly = true;
			this.dataGridViewExcelFilter_1.RowHeadersWidth = 21;
			this.dataGridViewExcelFilter_1.Size = new Size(845, 137);
			this.dataGridViewExcelFilter_1.TabIndex = 9;
			this.dataGridViewTextBoxColumn_7.DataPropertyName = "numrequest";
			this.dataGridViewTextBoxColumn_7.HeaderText = "№ док.";
			this.dataGridViewTextBoxColumn_7.Name = "numrequestDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_7.ReadOnly = true;
			this.dataGridViewTextBoxColumn_8.DataPropertyName = "dateDoc";
			this.dataGridViewTextBoxColumn_8.HeaderText = "Дата док";
			this.dataGridViewTextBoxColumn_8.Name = "dateDocDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_8.ReadOnly = true;
			this.dataGridViewTextBoxColumn_9.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_9.DataPropertyName = "TypeDocName";
			this.dataGridViewTextBoxColumn_9.HeaderText = "Тип документа";
			this.dataGridViewTextBoxColumn_9.Name = "typeDocNameDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_9.ReadOnly = true;
			this.dataGridViewTextBoxColumn_10.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_10.DataPropertyName = "schmObjName";
			this.dataGridViewTextBoxColumn_10.HeaderText = "Объект";
			this.dataGridViewTextBoxColumn_10.Name = "schmObjNameDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_10.ReadOnly = true;
			this.dataGridViewTextBoxColumn_11.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_11.HeaderText = "id";
			this.dataGridViewTextBoxColumn_11.Name = "idDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_11.ReadOnly = true;
			this.dataGridViewTextBoxColumn_11.Visible = false;
			this.dataGridViewCheckBoxColumn_0.DataPropertyName = "isApply";
			this.dataGridViewCheckBoxColumn_0.HeaderText = "Исполнен";
			this.dataGridViewCheckBoxColumn_0.Name = "isApplyDataGridViewCheckBoxColumn";
			this.dataGridViewCheckBoxColumn_0.ReadOnly = true;
			this.bindingSource_1.DataMember = "vJ_Damage";
			this.bindingSource_1.DataSource = this.class171_0;
			this.class171_0.DataSetName = "DataSetDamage";
			this.class171_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
			this.label_3.Cursor = Cursors.PanNorth;
			this.label_3.Dock = DockStyle.Top;
			this.label_3.Location = new Point(0, 0);
			this.label_3.Name = "lbChildDoc";
			this.label_3.Size = new Size(845, 13);
			this.label_3.TabIndex = 8;
			this.label_3.Text = "Дочерние документы";
			this.label_3.TextAlign = ContentAlignment.TopCenter;
			this.label_3.Click += this.label_3_Click;
			this.backgroundWorker_0.WorkerReportsProgress = true;
			this.backgroundWorker_0.WorkerSupportsCancellation = true;
			this.backgroundWorker_0.DoWork += this.backgroundWorker_0_DoWork;
			this.backgroundWorker_0.RunWorkerCompleted += this.backgroundWorker_0_RunWorkerCompleted;
			this.dataGridViewFilterTextBoxColumn_0.DataPropertyName = "num";
			this.dataGridViewFilterTextBoxColumn_0.HeaderText = "Номер";
			this.dataGridViewFilterTextBoxColumn_0.Name = "dataGridViewFilterTextBoxColumn1";
			this.dataGridViewFilterTextBoxColumn_0.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_1.DataPropertyName = "dateCreate";
			this.dataGridViewFilterTextBoxColumn_1.HeaderText = "Дата";
			this.dataGridViewFilterTextBoxColumn_1.Name = "dataGridViewFilterTextBoxColumn2";
			this.dataGridViewFilterTextBoxColumn_2.DataPropertyName = "SRSocr";
			this.dataGridViewFilterTextBoxColumn_2.HeaderText = "Район";
			this.dataGridViewFilterTextBoxColumn_2.Name = "dataGridViewFilterTextBoxColumn3";
			this.dataGridViewFilterTextBoxColumn_2.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_3.DataPropertyName = "reguestFiled";
			this.dataGridViewFilterTextBoxColumn_3.HeaderText = "Подал";
			this.dataGridViewFilterTextBoxColumn_3.Name = "dataGridViewFilterTextBoxColumn4";
			this.dataGridViewFilterTextBoxColumn_3.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_4.DataPropertyName = "schmObj";
			dataGridViewCellStyle10.WrapMode = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_4.DefaultCellStyle = dataGridViewCellStyle10;
			this.dataGridViewFilterTextBoxColumn_4.HeaderText = "Объект";
			this.dataGridViewFilterTextBoxColumn_4.Name = "dataGridViewFilterTextBoxColumn5";
			this.dataGridViewFilterTextBoxColumn_4.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_5.DataPropertyName = "Purpose";
			dataGridViewCellStyle11.WrapMode = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_5.DefaultCellStyle = dataGridViewCellStyle11;
			this.dataGridViewFilterTextBoxColumn_5.HeaderText = "Цель";
			this.dataGridViewFilterTextBoxColumn_5.Name = "dataGridViewFilterTextBoxColumn6";
			this.dataGridViewFilterTextBoxColumn_6.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			this.dataGridViewFilterTextBoxColumn_6.DataPropertyName = "DateTripBeg";
			dataGridViewCellStyle12.WrapMode = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_6.DefaultCellStyle = dataGridViewCellStyle12;
			this.dataGridViewFilterTextBoxColumn_6.HeaderText = "Дата С";
			this.dataGridViewFilterTextBoxColumn_6.Name = "dataGridViewFilterTextBoxColumn7";
			this.dataGridViewFilterTextBoxColumn_6.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_7.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			this.dataGridViewFilterTextBoxColumn_7.DataPropertyName = "DateTripEnd";
			dataGridViewCellStyle13.WrapMode = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_7.DefaultCellStyle = dataGridViewCellStyle13;
			this.dataGridViewFilterTextBoxColumn_7.HeaderText = "Дата По";
			this.dataGridViewFilterTextBoxColumn_7.Name = "dataGridViewFilterTextBoxColumn8";
			this.dataGridViewFilterTextBoxColumn_7.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_8.DataPropertyName = "DateFactEnd";
			this.dataGridViewFilterTextBoxColumn_8.HeaderText = "Фактическое время выполнения";
			this.dataGridViewFilterTextBoxColumn_8.Name = "dataGridViewFilterTextBoxColumn9";
			this.dataGridViewFilterTextBoxColumn_8.Visible = false;
			this.dataGridViewTextBoxColumn_0.DataPropertyName = "AgreeWith";
			this.dataGridViewTextBoxColumn_0.HeaderText = "Согласовать с";
			this.dataGridViewTextBoxColumn_0.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewFilterTextBoxColumn_9.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			this.dataGridViewFilterTextBoxColumn_9.DataPropertyName = "Comment";
			dataGridViewCellStyle14.WrapMode = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_9.DefaultCellStyle = dataGridViewCellStyle14;
			this.dataGridViewFilterTextBoxColumn_9.HeaderText = "Комментарий";
			this.dataGridViewFilterTextBoxColumn_9.Name = "dataGridViewFilterTextBoxColumn10";
			this.dataGridViewFilterTextBoxColumn_9.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_9.Width = 103;
			this.dataGridViewTextBoxColumn_1.DataPropertyName = "workerCreate";
			this.dataGridViewTextBoxColumn_1.HeaderText = "Автор";
			this.dataGridViewTextBoxColumn_1.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn_1.Visible = false;
			this.dataGridViewTextBoxColumn_2.DataPropertyName = "Address";
			this.dataGridViewTextBoxColumn_2.HeaderText = "Адреса";
			this.dataGridViewTextBoxColumn_2.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn_2.Visible = false;
			this.dataGridViewTextBoxColumn_3.DataPropertyName = "DateAgreed";
			dataGridViewCellStyle15.Format = "d";
			dataGridViewCellStyle15.NullValue = null;
			this.dataGridViewTextBoxColumn_3.DefaultCellStyle = dataGridViewCellStyle15;
			this.dataGridViewTextBoxColumn_3.HeaderText = "Дата согласования";
			this.dataGridViewTextBoxColumn_3.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn_3.Visible = false;
			this.dataGridViewTextBoxColumn_4.DataPropertyName = "FIO";
			this.dataGridViewTextBoxColumn_4.HeaderText = "Диспетчер";
			this.dataGridViewTextBoxColumn_4.Name = "dataGridViewTextBoxColumn5";
			this.dataGridViewTextBoxColumn_4.Visible = false;
			this.dataGridViewTextBoxColumn_5.DataPropertyName = "iddivision";
			this.dataGridViewTextBoxColumn_5.HeaderText = "Код подразделения";
			this.dataGridViewTextBoxColumn_5.Name = "dataGridViewTextBoxColumn6";
			this.dataGridViewTextBoxColumn_5.Visible = false;
			this.dataGridViewFilterTextBoxColumn_10.DataPropertyName = "division";
			this.dataGridViewFilterTextBoxColumn_10.HeaderText = "Подразделение";
			this.dataGridViewFilterTextBoxColumn_10.Name = "dataGridViewFilterTextBoxColumn11";
			this.dataGridViewFilterTextBoxColumn_10.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_10.Visible = false;
			this.dataGridViewTextBoxColumn_6.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_6.HeaderText = "id";
			this.dataGridViewTextBoxColumn_6.Name = "dataGridViewTextBoxColumn7";
			this.dataGridViewTextBoxColumn_6.Visible = false;
			this.dataGridViewFilterTextBoxColumn_11.DataPropertyName = "colorStatus";
			this.dataGridViewFilterTextBoxColumn_11.HeaderText = "colorStatus";
			this.dataGridViewFilterTextBoxColumn_11.Name = "dataGridViewFilterTextBoxColumn12";
			this.dataGridViewFilterTextBoxColumn_11.Visible = false;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(1026, 579);
			base.Controls.Add(this.splitContainer_0);
			base.Controls.Add(this.toolStrip_0);
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "FormJournalRequestForRepair";
			this.Text = "Журнал заявок на ремонт оборудования";
			base.Load += this.FormJournalRequestForRepair_Load;
			this.toolStrip_0.ResumeLayout(false);
			this.toolStrip_0.PerformLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_0).EndInit();
			((ISupportInitialize)this.bindingSource_0).EndInit();
			((ISupportInitialize)this.class255_0).EndInit();
			this.splitContainer_0.Panel1.ResumeLayout(false);
			this.splitContainer_0.Panel1.PerformLayout();
			this.splitContainer_0.Panel2.ResumeLayout(false);
			this.splitContainer_0.ResumeLayout(false);
			this.toolStrip_1.ResumeLayout(false);
			this.toolStrip_1.PerformLayout();
			this.splitContainer_1.Panel1.ResumeLayout(false);
			this.splitContainer_1.Panel2.ResumeLayout(false);
			this.splitContainer_1.ResumeLayout(false);
			((ISupportInitialize)this.dataGridViewExcelFilter_1).EndInit();
			((ISupportInitialize)this.bindingSource_1).EndInit();
			((ISupportInitialize)this.class171_0).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private bool bool_0;

		private bool bool_1;

		private string string_0;

		private int int_0;

		private Class255 class255_0;

		private ToolStrip toolStrip_0;

		private BindingSource bindingSource_0;

		private DataGridViewExcelFilter dataGridViewExcelFilter_0;

		private ToolStripSplitButton toolStripSplitButton_0;

		private ToolStripButton toolStripButton_0;

		private ToolStripButton toolStripButton_1;

		private ToolStripButton toolStripButton_2;

		private ToolStripSplitButton toolStripSplitButton_1;

		private ToolStripMenuItem toolStripMenuItem_0;

		private ToolStripMenuItem toolStripMenuItem_1;

		private SplitContainer splitContainer_0;

		private Label label_0;

		private DateTimePicker dateTimePicker_0;

		private DateTimePicker dateTimePicker_1;

		private Label label_1;

		private CheckedListBox checkedListBox_0;

		private Label label_2;

		private ToolStripProgressBar toolStripProgressBar_0;

		private ToolStripLabel toolStripLabel_0;

		private BackgroundWorker backgroundWorker_0;

		private ToolStrip toolStrip_1;

		private ToolStripButton toolStripButton_3;

		private ToolStripButton toolStripButton_4;

		private ToolStripSeparator toolStripSeparator_0;

		private ToolStripButton toolStripButton_5;

		private ToolStripButton toolStripButton_6;

		private ToolStripButton toolStripButton_7;

		private ToolStripSplitButton toolStripSplitButton_2;

		private ToolStripSeparator toolStripSeparator_1;

		private ToolStripButton toolStripButton_8;

		private ToolStripTextBox toolStripTextBox_0;

		private ToolStripButton toolStripButton_9;

		private ToolStripButton toolStripButton_10;

		private ToolStripSeparator toolStripSeparator_2;

		private ToolStripButton toolStripButton_11;

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

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_9;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_3;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_4;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_5;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_10;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_6;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_11;

		private DataGridViewExcelFilter dataGridViewExcelFilter_1;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_7;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_8;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_9;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_10;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_11;

		private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn_0;

		private BindingSource bindingSource_1;

		private Class171 class171_0;

		private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn_1;

		private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn_2;

		private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn_3;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_12;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_13;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_14;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_15;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_16;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_17;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_18;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_19;

		private DataGridViewFilterCheckBoxColumn dataGridViewFilterCheckBoxColumn_0;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_20;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_12;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_21;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_13;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_14;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_15;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_16;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_17;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_22;

		private DataGridViewFilterCheckBoxColumn dataGridViewFilterCheckBoxColumn_1;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_18;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_23;
	}
}
