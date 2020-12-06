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
using Documents.Forms.DailyReport.Reports;
using FormLbr;
using SchemeModel;

namespace Documents.Forms.DailyReport.ActDetection
{
	public partial class FormJournalActDetection : FormBase
	{
		public FormJournalActDetection()
		{
			
			
			this.method_6();
			this.toolStripDropDownButton_1.Visible = false;
		}

		public FormJournalActDetection(List<int> checkedSubstation)
		{
			
			
			this.method_6();
			this.list_0 = checkedSubstation;
			this.toolStripDropDownButton_1.Visible = false;
		}

		private void FormJournalActDetection_Load(object sender, EventArgs e)
		{
			this.method_5();
			this.method_0();
			base.LoadFormConfig(null);
			this.treeViewSchmObjects_0.SqlSettings = this.SqlSettings;
			this.treeViewSchmObjects_0.Load(this.list_0);
			this.method_4(-1);
		}

		private void FormJournalActDetection_FormClosed(object sender, FormClosedEventArgs e)
		{
			base.SaveFormConfig(null);
		}

		private void method_0()
		{
			this.dateTimePicker_0.Value = new DateTime(DateTime.Now.Year + 1, 1, 1).AddSeconds(-1.0);
			this.HwxCmhcuWjh.Value = new DateTime(DateTime.Now.Year, 1, 1);
			this.treeViewSchmObjects_0.ClearTreeChecked();
		}

		private void toolStripMenuItem_4_Click(object sender, EventArgs e)
		{
			this.method_1(null, false);
		}

		private void toolStripMenuItem_5_Click(object sender, EventArgs e)
		{
			if (this.bindingSource_0.Current != null)
			{
				DataRow row = ((DataRowView)this.bindingSource_0.Current).Row;
				this.method_1(new int?(Convert.ToInt32(row["id"])), false);
			}
		}

		private void toolStripMenuItem_6_Click(object sender, EventArgs e)
		{
			if (this.bindingSource_0.Current != null)
			{
				DataRow row = ((DataRowView)this.bindingSource_0.Current).Row;
				this.method_1(new int?(Convert.ToInt32(row["id"])), true);
			}
		}

		private void method_1(int? nullable_0 = null, bool bool_0 = false)
		{
			Form86 form = new Form86(nullable_0);
			form.SqlSettings = this.SqlSettings;
			form.MdiParent = base.MdiParent;
			form.method_1(bool_0);
			if (!bool_0)
			{
				form.FormClosed += this.method_2;
			}
			form.Show();
		}

		private void method_2(object sender, FormClosedEventArgs e)
		{
			if (sender is Form && ((Form)sender).DialogResult == DialogResult.OK)
			{
				int int_ = -1;
				if (sender is Form86 && ((Form86)sender).method_2() != null)
				{
					int_ = ((Form86)sender).method_2().Value;
				}
				this.method_4(int_);
			}
		}

		private void toolStripMenuItem_7_Click(object sender, EventArgs e)
		{
			if (this.bindingSource_0.Current != null)
			{
				if (this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewFilterCheckBoxColumn_1.Name].Value != DBNull.Value && this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewFilterCheckBoxColumn_1.Name].Value != null && Convert.ToBoolean(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewFilterCheckBoxColumn_1.Name].Value))
				{
					MessageBox.Show("Невозможно удалить исполненный документ", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
				if (MessageBox.Show("Вы действительно хотите удалить выбранный документ и подчиненные данному документу?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					int num = Convert.ToInt32(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_3.Name].Value);
					if (base.DeleteSqlDataById(this.class171_0.tJ_Damage, num))
					{
						this.method_3(num);
						this.method_4(-1);
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

		private void method_3(int int_0)
		{
			try
			{
				using (SqlConnection sqlConnection = new SqlConnection(this.SqlSettings.GetConnectionString()))
				{
					sqlConnection.Open();
					using (SqlCommand sqlCommand = new SqlCommand())
					{
						sqlCommand.Connection = sqlConnection;
						sqlCommand.CommandText = string.Format("update tj_damage \r\n                                                          set idParent = null\r\n                                                          where idParent = {0} and isApply = 1", int_0);
						sqlCommand.ExecuteNonQuery();
						sqlCommand.CommandText = string.Format("delete tj_damage \r\n                                                          where idParent = {0} and (isApply = 0 or isApply is null)", int_0.ToString());
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
			this.method_4(-1);
		}

		private void toolStripButton_11_Click(object sender, EventArgs e)
		{
			this.dataGridViewExcelFilter_0.SearchGrid(DataGridViewExcelFilter.TypeFind.Begin, this.toolStripTextBox_1.Text);
		}

		private void toolStripButton_12_Click(object sender, EventArgs e)
		{
			this.dataGridViewExcelFilter_0.SearchGrid(DataGridViewExcelFilter.TypeFind.Prev, this.toolStripTextBox_1.Text);
		}

		private void TofCmzEeWbS_Click(object sender, EventArgs e)
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

		private void toolStripButton_14_Click(object sender, EventArgs e)
		{
			this.dataGridViewExcelFilter_0.ExportToExcel();
		}

		private void toolStripButton_15_Click(object sender, EventArgs e)
		{
			this.dataGridViewExcelFilter_0.PrintDataGridView();
		}

		private void toolStripButton_0_Click(object sender, EventArgs e)
		{
			this.method_4(-1);
		}

		private void toolStripButton_1_Click(object sender, EventArgs e)
		{
			this.method_0();
			this.dataGridViewExcelFilter_0.ClearFilter();
			this.method_4(-1);
		}

		private void toolStripButton_2_Click(object sender, EventArgs e)
		{
			this.HwxCmhcuWjh.Value = new DateTime(this.HwxCmhcuWjh.Value.Year - 1, this.HwxCmhcuWjh.Value.Month, this.HwxCmhcuWjh.Value.Day);
			this.dateTimePicker_0.Value = new DateTime(this.dateTimePicker_0.Value.Year - 1, this.dateTimePicker_0.Value.Month, this.dateTimePicker_0.Value.Day);
		}

		private void toolStripButton_3_Click(object sender, EventArgs e)
		{
			this.dateTimePicker_0.Value = new DateTime(this.dateTimePicker_0.Value.Year + 1, this.dateTimePicker_0.Value.Month, this.dateTimePicker_0.Value.Day);
			this.HwxCmhcuWjh.Value = new DateTime(this.HwxCmhcuWjh.Value.Year + 1, this.HwxCmhcuWjh.Value.Month, this.HwxCmhcuWjh.Value.Day);
		}

		private void HwxCmhcuWjh_ValueChanged(object sender, EventArgs e)
		{
			if (this.HwxCmhcuWjh.Value > this.dateTimePicker_0.Value)
			{
				this.dateTimePicker_0.Value = this.HwxCmhcuWjh.Value;
			}
		}

		private void dateTimePicker_0_ValueChanged(object sender, EventArgs e)
		{
			if (this.dateTimePicker_0.Value < this.HwxCmhcuWjh.Value)
			{
				this.HwxCmhcuWjh.Value = this.dateTimePicker_0.Value;
			}
		}

		private void method_4(int int_0 = -1)
		{
			if (int_0 == -1 && this.dataGridViewExcelFilter_0.CurrentRow != null)
			{
				int_0 = Convert.ToInt32(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_3.Name].Value);
			}
			string text = "select d.*, c_sc.Name as signCrashType, c_sc.Name + ' ' + c_sc.Comment as signCrashName,\r\nc_te.Name as typeEquip, c_te.Name + ' ' + c_te.Comment as typeEquipName,\r\nc_rce.Name as reasonCrashEquipType, c_rce.Name + ' ' + c_rce.Comment as reasonCrashEquipName,\r\nc_rc.Name as reasonCrashType, c_rc.Name + ' ' + c_rc.Comment as reasonCrashName\r\nfrom vJ_Damage as d\r\nleft join tJ_DamageActDetection as dAct on dAct.idDamage = d.id\r\nleft join tR_Classifier as c_sc on c_sc.Id = dAct.idSignCrash\r\nleft join tR_Classifier as c_te on c_te.Id = dAct.idTypeEquipment\r\nleft join tR_Classifier as c_rce on c_rce.Id = dAct.idReasonCrashEquipment\r\nleft join tR_Classifier as c_rc on c_rc.Id = dAct.idReasonCrash\r\n";
			string text2 = "";
			text2 = string.Format(" where (d.deleted = 0) and ((d.dateDoc >= '{0}' and d.dateDoc < '{1}') or d.dateDoc is null)", this.HwxCmhcuWjh.Value.ToString("yyyyMMdd"), this.dateTimePicker_0.Value.AddDays(1.0).ToString("yyyyMMdd"));
			text2 += string.Format(" and (d.TypeDoc = {0}) ", 1874);
			List<int> listChecked = this.treeViewSchmObjects_0.GetListChecked();
			if (listChecked.Count > 0)
			{
				string text3 = "";
				foreach (int num in listChecked)
				{
					if (string.IsNullOrEmpty(text3))
					{
						text3 = num.ToString();
					}
					else
					{
						text3 = text3 + "," + num.ToString();
					}
				}
				if (this.checkBox_0.Checked)
				{
					text2 += string.Format(" and (d.idSchmObj in ({0}) or d.idSub in ({0}))", text3);
				}
				else
				{
					text2 += string.Format(" and (d.idSchmObj in ({0}))", text3);
				}
			}
			text += text2;
			DataTable dataSource = new SqlDataCommand(this.SqlSettings).SelectSqlData(text);
			this.dataGridViewExcelFilter_0.AutoGenerateColumns = false;
			this.bindingSource_0.DataSource = dataSource;
			this.dataGridViewExcelFilter_0.SearchGrid(this.dataGridViewTextBoxColumn_3.Name, int_0.ToString(), true);
		}

		private void dataGridViewExcelFilter_0_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
			{
				if (this.toolStripButton_4.Enabled && this.toolStripButton_4.Visible)
				{
					this.toolStripMenuItem_5_Click(sender, e);
					return;
				}
				if (this.toolStripButton_5.Enabled && this.toolStripButton_5.Visible)
				{
					this.toolStripMenuItem_6_Click(sender, e);
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
				else if (this.dataGridViewExcelFilter_0[this.dataGridViewFilterTextBoxColumn_2.Name, e.RowIndex].Value != DBNull.Value && this.dataGridViewExcelFilter_0[this.dataGridViewFilterTextBoxColumn_2.Name, e.RowIndex].Value != null && Convert.ToDateTime(this.dataGridViewExcelFilter_0[this.dataGridViewFilterTextBoxColumn_2.Name, e.RowIndex].Value).Date < DateTime.Now.Date.AddDays(-10.0))
				{
					e.CellStyle.ForeColor = Color.Red;
					return;
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

		private void toolStripMenuItem_8_Click(object sender, EventArgs e)
		{
			new Form79
			{
				SqlSettings = this.SqlSettings,
				MdiParent = base.MdiParent
			}.Show();
		}

		private void toolStripMenuItem_9_Click(object sender, EventArgs e)
		{
			new FormReportAccidents
			{
				SqlSettings = this.SqlSettings,
				MdiParent = base.MdiParent
			}.Show();
		}

		private void toolStripMenuItem_0_Click(object sender, EventArgs e)
		{
			Class226.smethod_0(this.SqlSettings, new SQLSettings("ulges-sql", "SR4", "WINDOWS", "", ""));
			this.method_4(-1);
		}

		private void bMuCmfbYpf0(object sender, EventArgs e)
		{
			Class224.smethod_0(this.SqlSettings);
			this.method_4(-1);
		}

		private void toolStripMenuItem_2_Click(object sender, EventArgs e)
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

		private void toolStripMenuItem_3_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				Class222.smethod_0(openFileDialog.FileName, this.SqlSettings);
			}
		}

		private void method_5()
		{
			DataTable dataTable = new DataTable("tUser");
			dataTable.Columns.Add("idUser", typeof(int));
			base.SelectSqlData(dataTable, true, " left join vworkergroup w on w.id = tuser.idWorker\r\n                                where w.ParentKey = ';GroupWorker;DailyReport;AdminActDetection;' and tuser.login = SYSTEM_USER", null, false, 0);
			if (dataTable.Rows.Count > 0)
			{
				this.toolStripButton_13.Visible = true;
				return;
			}
			this.toolStripButton_13.Visible = false;
		}

		private void toolStripButton_13_Click(object sender, EventArgs e)
		{
			if (this.bindingSource_0.Current != null)
			{
				if (this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewFilterCheckBoxColumn_1.Name].Value != DBNull.Value && this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewFilterCheckBoxColumn_1.Name].Value != null && Convert.ToBoolean(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewFilterCheckBoxColumn_1.Name].Value))
				{
					if (MessageBox.Show("Вы действительно хотите разблокировать текущий документ?", "Разблокировка", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
					{
						return;
					}
					int num = Convert.ToInt32(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_3.Name].Value);
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
									this.method_4(-1);
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
			XmlAttribute xmlAttribute = xmlDocument.CreateAttribute("dateBeg");
			xmlAttribute.Value = this.HwxCmhcuWjh.Value.ToString();
			xmlNode.Attributes.Append(xmlAttribute);
			xmlAttribute = xmlDocument.CreateAttribute("dateEnd");
			xmlAttribute.Value = this.dateTimePicker_0.Value.ToString();
			xmlNode.Attributes.Append(xmlAttribute);
			return xmlDocument;
		}

		protected override void ApplyConfig(XmlDocument doc)
		{
			List<int> list = new List<int>();
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
			XmlAttribute xmlAttribute2 = xmlNode.Attributes["dateBeg"];
			if (xmlAttribute2.Value != null)
			{
				this.HwxCmhcuWjh.Value = Convert.ToDateTime(xmlAttribute2.Value);
			}
			xmlAttribute2 = xmlNode.Attributes["dateEnd"];
			if (xmlAttribute2.Value != null)
			{
				this.dateTimePicker_0.Value = Convert.ToDateTime(xmlAttribute2.Value);
			}
		}

		private void contextMenuStrip_0_Opening(object sender, CancelEventArgs e)
		{
			if (this.bindingSource_0.Current != null)
			{
				this.toolStripMenuItem_5.Enabled = true;
				this.toolStripMenuItem_6.Enabled = true;
				this.toolStripMenuItem_7.Enabled = true;
				return;
			}
			this.toolStripMenuItem_5.Enabled = false;
			this.toolStripMenuItem_6.Enabled = false;
			this.toolStripMenuItem_7.Enabled = false;
		}

		private void method_6()
		{
			this.icontainer_0 = new Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FormJournalActDetection));
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
			this.toolStrip_0 = new ToolStrip();
			this.gdsCnMvWiGu = new ToolStripButton();
			this.toolStripButton_4 = new ToolStripButton();
			this.toolStripButton_5 = new ToolStripButton();
			this.toolStripButton_9 = new ToolStripButton();
			this.toolStripSeparator_0 = new ToolStripSeparator();
			this.toolStripButton_10 = new ToolStripButton();
			this.toolStripSeparator_1 = new ToolStripSeparator();
			this.toolStripButton_11 = new ToolStripButton();
			this.toolStripTextBox_1 = new ToolStripTextBox();
			this.toolStripButton_12 = new ToolStripButton();
			this.TofCmzEeWbS = new ToolStripButton();
			this.toolStripSeparator_2 = new ToolStripSeparator();
			this.toolStripDropDownButton_0 = new ToolStripDropDownButton();
			this.toolStripMenuItem_8 = new ToolStripMenuItem();
			this.toolStripDropDownButton_1 = new ToolStripDropDownButton();
			this.toolStripMenuItem_0 = new ToolStripMenuItem();
			this.toolStripMenuItem_1 = new ToolStripMenuItem();
			this.toolStripMenuItem_2 = new ToolStripMenuItem();
			this.toolStripMenuItem_3 = new ToolStripMenuItem();
			this.toolStripButton_13 = new ToolStripButton();
			this.toolStripButton_14 = new ToolStripButton();
			this.toolStripButton_15 = new ToolStripButton();
			this.splitContainer_0 = new SplitContainer();
			this.checkBox_0 = new CheckBox();
			this.toolStrip_2 = new ToolStrip();
			this.toolStripButton_6 = new ToolStripButton();
			this.toolStripTextBox_0 = new ToolStripTextBox();
			this.toolStripButton_7 = new ToolStripButton();
			this.toolStripButton_8 = new ToolStripButton();
			this.treeViewSchmObjects_0 = new TreeViewSchmObjects();
			this.dateTimePicker_0 = new DateTimePicker();
			this.label_0 = new Label();
			this.HwxCmhcuWjh = new DateTimePicker();
			this.label_1 = new Label();
			this.toolStrip_1 = new ToolStrip();
			this.toolStripButton_0 = new ToolStripButton();
			this.toolStripButton_1 = new ToolStripButton();
			this.toolStripSeparator_3 = new ToolStripSeparator();
			this.toolStripButton_2 = new ToolStripButton();
			this.toolStripButton_3 = new ToolStripButton();
			this.dataGridViewExcelFilter_0 = new DataGridViewExcelFilter();
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
			this.dataGridViewFilterCheckBoxColumn_0 = new DataGridViewFilterCheckBoxColumn();
			this.dataGridViewFilterTextBoxColumn_11 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterCheckBoxColumn_1 = new DataGridViewFilterCheckBoxColumn();
			this.dataGridViewFilterTextBoxColumn_12 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_13 = new DataGridViewFilterTextBoxColumn();
			this.rqiCnkKyvdA = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_14 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_15 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_16 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_17 = new DataGridViewFilterTextBoxColumn();
			this.ucvCnGfImtA = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_3 = new DataGridViewTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_18 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_19 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_20 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_21 = new DataGridViewFilterTextBoxColumn();
			this.yjqCnLapbPB = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_22 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_23 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_24 = new DataGridViewFilterTextBoxColumn();
			this.bindingSource_0 = new BindingSource(this.icontainer_0);
			this.class171_0 = new Class171();
			this.toolStripMenuItem_4 = new ToolStripMenuItem();
			this.toolStripMenuItem_5 = new ToolStripMenuItem();
			this.toolStripMenuItem_6 = new ToolStripMenuItem();
			this.toolStripMenuItem_7 = new ToolStripMenuItem();
			this.contextMenuStrip_0 = new ContextMenuStrip(this.icontainer_0);
			this.toolStripMenuItem_9 = new ToolStripMenuItem();
			this.toolStrip_0.SuspendLayout();
			this.splitContainer_0.Panel1.SuspendLayout();
			this.splitContainer_0.Panel2.SuspendLayout();
			this.splitContainer_0.SuspendLayout();
			this.toolStrip_2.SuspendLayout();
			this.toolStrip_1.SuspendLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_0).BeginInit();
			((ISupportInitialize)this.bindingSource_0).BeginInit();
			((ISupportInitialize)this.class171_0).BeginInit();
			this.contextMenuStrip_0.SuspendLayout();
			base.SuspendLayout();
			this.toolStrip_0.Items.AddRange(new ToolStripItem[]
			{
				this.gdsCnMvWiGu,
				this.toolStripButton_4,
				this.toolStripButton_5,
				this.toolStripButton_9,
				this.toolStripSeparator_0,
				this.toolStripButton_10,
				this.toolStripSeparator_1,
				this.toolStripButton_11,
				this.toolStripTextBox_1,
				this.toolStripButton_12,
				this.TofCmzEeWbS,
				this.toolStripSeparator_2,
				this.toolStripDropDownButton_0,
				this.toolStripDropDownButton_1,
				this.toolStripButton_13,
				this.toolStripButton_14,
				this.toolStripButton_15
			});
			this.toolStrip_0.Location = new Point(0, 0);
			this.toolStrip_0.Name = "toolStrip";
			this.toolStrip_0.Size = new Size(1022, 25);
			this.toolStrip_0.TabIndex = 0;
			this.toolStrip_0.Text = "toolStrip1";
			this.gdsCnMvWiGu.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.gdsCnMvWiGu.Image = (Image)componentResourceManager.GetObject("toolBtnAdd.Image");
			this.gdsCnMvWiGu.ImageTransparentColor = Color.Magenta;
			this.gdsCnMvWiGu.Name = "toolBtnAdd";
			this.gdsCnMvWiGu.Size = new Size(23, 22);
			this.gdsCnMvWiGu.Text = "Добавить";
			this.gdsCnMvWiGu.Click += this.toolStripMenuItem_4_Click;
			this.toolStripButton_4.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_4.Image = (Image)componentResourceManager.GetObject("toolBtnEdit.Image");
			this.toolStripButton_4.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_4.Name = "toolBtnEdit";
			this.toolStripButton_4.Size = new Size(23, 22);
			this.toolStripButton_4.Text = "Редактировать";
			this.toolStripButton_4.Click += this.toolStripMenuItem_5_Click;
			this.toolStripButton_5.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_5.Image = (Image)componentResourceManager.GetObject("toolBtnInfo.Image");
			this.toolStripButton_5.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_5.Name = "toolBtnInfo";
			this.toolStripButton_5.Size = new Size(23, 22);
			this.toolStripButton_5.Text = "Информация";
			this.toolStripButton_5.Click += this.toolStripMenuItem_6_Click;
			this.toolStripButton_9.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_9.Image = (Image)componentResourceManager.GetObject("toolBtnDel.Image");
			this.toolStripButton_9.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_9.Name = "toolBtnDel";
			this.toolStripButton_9.Size = new Size(23, 22);
			this.toolStripButton_9.Text = "Удалить документ";
			this.toolStripButton_9.Click += this.toolStripMenuItem_7_Click;
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
			this.TofCmzEeWbS.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.TofCmzEeWbS.Image = (Image)componentResourceManager.GetObject("toolBtnFindNext.Image");
			this.TofCmzEeWbS.ImageTransparentColor = Color.Magenta;
			this.TofCmzEeWbS.Name = "toolBtnFindNext";
			this.TofCmzEeWbS.Size = new Size(23, 22);
			this.TofCmzEeWbS.Text = "Искать вперед";
			this.TofCmzEeWbS.Click += this.TofCmzEeWbS_Click;
			this.toolStripSeparator_2.Name = "toolStripSeparator3";
			this.toolStripSeparator_2.Size = new Size(6, 25);
			this.toolStripDropDownButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripDropDownButton_0.DropDownItems.AddRange(new ToolStripItem[]
			{
				this.toolStripMenuItem_8,
				this.toolStripMenuItem_9
			});
			this.toolStripDropDownButton_0.Image = (Image)componentResourceManager.GetObject("toolBtnReport.Image");
			this.toolStripDropDownButton_0.ImageTransparentColor = Color.Magenta;
			this.toolStripDropDownButton_0.Name = "toolBtnReport";
			this.toolStripDropDownButton_0.Size = new Size(29, 22);
			this.toolStripDropDownButton_0.Text = "Отчеты";
			this.toolStripMenuItem_8.Name = "tsMenuAmergencyShutdown";
			this.toolStripMenuItem_8.Size = new Size(270, 22);
			this.toolStripMenuItem_8.Text = "Бюллетень аварийных отключений";
			this.toolStripMenuItem_8.Click += this.toolStripMenuItem_8_Click;
			this.toolStripDropDownButton_1.Alignment = ToolStripItemAlignment.Right;
			this.toolStripDropDownButton_1.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripDropDownButton_1.DropDownItems.AddRange(new ToolStripItem[]
			{
				this.toolStripMenuItem_0,
				this.toolStripMenuItem_1,
				this.toolStripMenuItem_2,
				this.toolStripMenuItem_3
			});
			this.toolStripDropDownButton_1.Image = (Image)componentResourceManager.GetObject("toolBTnLoadOld.Image");
			this.toolStripDropDownButton_1.ImageTransparentColor = Color.Magenta;
			this.toolStripDropDownButton_1.Name = "toolBTnLoadOld";
			this.toolStripDropDownButton_1.Size = new Size(29, 22);
			this.toolStripDropDownButton_1.Text = "Загрузка из старой базы";
			this.toolStripMenuItem_0.Name = "toolBtnLoadOldDamageLV";
			this.toolStripMenuItem_0.Size = new Size(210, 22);
			this.toolStripMenuItem_0.Text = "0.4кВ";
			this.toolStripMenuItem_0.Click += this.toolStripMenuItem_0_Click;
			this.toolStripMenuItem_1.Name = "toolBtnLoadOldDefect";
			this.toolStripMenuItem_1.Size = new Size(210, 22);
			this.toolStripMenuItem_1.Text = "Дефект";
			this.toolStripMenuItem_1.Click += this.bMuCmfbYpf0;
			this.toolStripMenuItem_2.Name = "toolBtnLoadAbnDefectLV";
			this.toolStripMenuItem_2.Size = new Size(210, 22);
			this.toolStripMenuItem_2.Text = "Загрузить абонентов НН";
			this.toolStripMenuItem_2.Click += this.toolStripMenuItem_2_Click;
			this.toolStripMenuItem_3.Name = "toolBtnLoadOldDamageНV";
			this.toolStripMenuItem_3.Size = new Size(210, 22);
			this.toolStripMenuItem_3.Text = "ВН";
			this.toolStripMenuItem_3.Click += this.toolStripMenuItem_3_Click;
			this.toolStripButton_13.Alignment = ToolStripItemAlignment.Right;
			this.toolStripButton_13.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_13.Image = (Image)componentResourceManager.GetObject("toolBtnDamageNoApply.Image");
			this.toolStripButton_13.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_13.Name = "toolBtnDamageNoApply";
			this.toolStripButton_13.Size = new Size(23, 22);
			this.toolStripButton_13.Text = "Разблокировать документ";
			this.toolStripButton_13.Visible = false;
			this.toolStripButton_13.Click += this.toolStripButton_13_Click;
			this.toolStripButton_14.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_14.Image = (Image)componentResourceManager.GetObject("toolBtnExportExcel.Image");
			this.toolStripButton_14.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_14.Name = "toolBtnExportExcel";
			this.toolStripButton_14.Size = new Size(23, 22);
			this.toolStripButton_14.Text = "Экспорт в Excel";
			this.toolStripButton_14.Click += this.toolStripButton_14_Click;
			this.toolStripButton_15.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_15.Image = (Image)componentResourceManager.GetObject("toolBtnPrint.Image");
			this.toolStripButton_15.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_15.Name = "toolBtnPrint";
			this.toolStripButton_15.Size = new Size(23, 22);
			this.toolStripButton_15.Text = "Печать";
			this.toolStripButton_15.Click += this.toolStripButton_15_Click;
			this.splitContainer_0.Dock = DockStyle.Fill;
			this.splitContainer_0.FixedPanel = FixedPanel.Panel1;
			this.splitContainer_0.Location = new Point(0, 25);
			this.splitContainer_0.Name = "splitContainer";
			this.splitContainer_0.Panel1.Controls.Add(this.checkBox_0);
			this.splitContainer_0.Panel1.Controls.Add(this.toolStrip_2);
			this.splitContainer_0.Panel1.Controls.Add(this.treeViewSchmObjects_0);
			this.splitContainer_0.Panel1.Controls.Add(this.dateTimePicker_0);
			this.splitContainer_0.Panel1.Controls.Add(this.label_0);
			this.splitContainer_0.Panel1.Controls.Add(this.HwxCmhcuWjh);
			this.splitContainer_0.Panel1.Controls.Add(this.label_1);
			this.splitContainer_0.Panel1.Controls.Add(this.toolStrip_1);
			this.splitContainer_0.Panel2.Controls.Add(this.dataGridViewExcelFilter_0);
			this.splitContainer_0.Size = new Size(1022, 577);
			this.splitContainer_0.SplitterDistance = 258;
			this.splitContainer_0.TabIndex = 1;
			this.checkBox_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.checkBox_0.AutoSize = true;
			this.checkBox_0.Checked = true;
			this.checkBox_0.CheckState = CheckState.Checked;
			this.checkBox_0.Location = new Point(15, 555);
			this.checkBox_0.Name = "checkBoxWhereSub";
			this.checkBox_0.Size = new Size(180, 17);
			this.checkBox_0.TabIndex = 12;
			this.checkBox_0.Text = "Фильтровать по подстанциям";
			this.checkBox_0.UseVisualStyleBackColor = true;
			this.toolStrip_2.Dock = DockStyle.None;
			this.toolStrip_2.GripStyle = ToolStripGripStyle.Hidden;
			this.toolStrip_2.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripButton_6,
				this.toolStripTextBox_0,
				this.toolStripButton_7,
				this.toolStripButton_8
			});
			this.toolStrip_2.Location = new Point(15, 103);
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
			this.treeViewSchmObjects_0.Location = new Point(12, 126);
			this.treeViewSchmObjects_0.Name = "treeViewSchmObjects";
			this.treeViewSchmObjects_0.Size = new Size(234, 423);
			this.treeViewSchmObjects_0.SqlSettings = null;
			this.treeViewSchmObjects_0.TabIndex = 10;
			this.dateTimePicker_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.dateTimePicker_0.CausesValidation = false;
			this.dateTimePicker_0.Location = new Point(12, 80);
			this.dateTimePicker_0.Name = "dtpFilterEnd";
			this.dateTimePicker_0.Size = new Size(234, 20);
			this.dateTimePicker_0.TabIndex = 4;
			this.dateTimePicker_0.ValueChanged += this.dateTimePicker_0_ValueChanged;
			this.label_0.AutoSize = true;
			this.label_0.Location = new Point(12, 64);
			this.label_0.Name = "label2";
			this.label_0.Size = new Size(22, 13);
			this.label_0.TabIndex = 3;
			this.label_0.Text = "До";
			this.HwxCmhcuWjh.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.HwxCmhcuWjh.CausesValidation = false;
			this.HwxCmhcuWjh.Location = new Point(12, 41);
			this.HwxCmhcuWjh.Name = "dtpFilterBeg";
			this.HwxCmhcuWjh.Size = new Size(234, 20);
			this.HwxCmhcuWjh.TabIndex = 2;
			this.HwxCmhcuWjh.ValueChanged += this.HwxCmhcuWjh_ValueChanged;
			this.label_1.AutoSize = true;
			this.label_1.Location = new Point(12, 25);
			this.label_1.Name = "label1";
			this.label_1.Size = new Size(20, 13);
			this.label_1.TabIndex = 1;
			this.label_1.Text = "От";
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
			this.dataGridViewExcelFilter_0.AllowUserToAddRows = false;
			this.dataGridViewExcelFilter_0.AllowUserToDeleteRows = false;
			this.dataGridViewExcelFilter_0.AllowUserToOrderColumns = true;
			this.dataGridViewExcelFilter_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
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
				this.dataGridViewFilterTextBoxColumn_0,
				this.dataGridViewFilterTextBoxColumn_1,
				this.dataGridViewFilterTextBoxColumn_2,
				this.dataGridViewFilterTextBoxColumn_3,
				this.dataGridViewFilterTextBoxColumn_4,
				this.dataGridViewFilterTextBoxColumn_5,
				this.dataGridViewFilterTextBoxColumn_6,
				this.dataGridViewFilterTextBoxColumn_7,
				this.dataGridViewFilterTextBoxColumn_8,
				this.dataGridViewFilterTextBoxColumn_9,
				this.dataGridViewFilterTextBoxColumn_10,
				this.dataGridViewFilterCheckBoxColumn_0,
				this.dataGridViewFilterTextBoxColumn_11,
				this.dataGridViewFilterCheckBoxColumn_1,
				this.dataGridViewFilterTextBoxColumn_12,
				this.dataGridViewFilterTextBoxColumn_13,
				this.rqiCnkKyvdA,
				this.dataGridViewFilterTextBoxColumn_14,
				this.dataGridViewFilterTextBoxColumn_15,
				this.dataGridViewFilterTextBoxColumn_16,
				this.dataGridViewTextBoxColumn_0,
				this.dataGridViewFilterTextBoxColumn_17,
				this.ucvCnGfImtA,
				this.dataGridViewTextBoxColumn_1,
				this.dataGridViewTextBoxColumn_2,
				this.dataGridViewTextBoxColumn_3,
				this.dataGridViewFilterTextBoxColumn_18,
				this.dataGridViewFilterTextBoxColumn_19,
				this.dataGridViewFilterTextBoxColumn_20,
				this.dataGridViewFilterTextBoxColumn_21,
				this.yjqCnLapbPB,
				this.dataGridViewFilterTextBoxColumn_22,
				this.dataGridViewFilterTextBoxColumn_23,
				this.dataGridViewFilterTextBoxColumn_24
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
			this.dataGridViewExcelFilter_0.Location = new Point(0, 0);
			this.dataGridViewExcelFilter_0.Name = "dgvActDetection";
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
			this.dataGridViewExcelFilter_0.Size = new Size(760, 577);
			this.dataGridViewExcelFilter_0.TabIndex = 0;
			this.dataGridViewExcelFilter_0.CellDoubleClick += this.dataGridViewExcelFilter_0_CellDoubleClick;
			this.dataGridViewExcelFilter_0.CellFormatting += this.dataGridViewExcelFilter_0_CellFormatting;
			this.dataGridViewExcelFilter_0.CellMouseClick += this.dataGridViewExcelFilter_0_CellMouseClick;
			this.dataGridViewExcelFilter_0.RowPostPaint += this.dataGridViewExcelFilter_0_RowPostPaint;
			this.dataGridViewFilterTextBoxColumn_0.DataPropertyName = "numrequest";
			this.dataGridViewFilterTextBoxColumn_0.HeaderText = "№ заявки";
			this.dataGridViewFilterTextBoxColumn_0.Name = "numrequestDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_0.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_0.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_1.DataPropertyName = "numDoc";
			this.dataGridViewFilterTextBoxColumn_1.HeaderText = "№ документа";
			this.dataGridViewFilterTextBoxColumn_1.Name = "numDocDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_1.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_1.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_1.Visible = false;
			this.dataGridViewFilterTextBoxColumn_2.DataPropertyName = "dateDoc";
			this.dataGridViewFilterTextBoxColumn_2.HeaderText = "Дата заявки";
			this.dataGridViewFilterTextBoxColumn_2.Name = "dateDocDgvColumn";
			this.dataGridViewFilterTextBoxColumn_2.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_2.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_3.DataPropertyName = "TypeDocName";
			this.dataGridViewFilterTextBoxColumn_3.HeaderText = "Тип";
			this.dataGridViewFilterTextBoxColumn_3.Name = "typeDocNameDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_3.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_3.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_3.Visible = false;
			this.dataGridViewFilterTextBoxColumn_4.DataPropertyName = "Division";
			this.dataGridViewFilterTextBoxColumn_4.HeaderText = "Подразделение";
			this.dataGridViewFilterTextBoxColumn_4.Name = "divisionDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_4.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_4.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_4.Visible = false;
			this.dataGridViewFilterTextBoxColumn_5.DataPropertyName = "schmObjName";
			this.dataGridViewFilterTextBoxColumn_5.HeaderText = "Электроустановка";
			this.dataGridViewFilterTextBoxColumn_5.Name = "schmObjNameDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_5.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_5.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_5.Width = 200;
			this.dataGridViewFilterTextBoxColumn_6.DataPropertyName = "NetRegionSub";
			this.dataGridViewFilterTextBoxColumn_6.HeaderText = "Сетевой район";
			this.dataGridViewFilterTextBoxColumn_6.Name = "netRegionSubDgvColumn";
			this.dataGridViewFilterTextBoxColumn_6.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_7.DataPropertyName = "numcrash";
			this.dataGridViewFilterTextBoxColumn_7.HeaderText = "Номер аварии";
			this.dataGridViewFilterTextBoxColumn_7.Name = "numcrashDgvColumn";
			this.dataGridViewFilterTextBoxColumn_7.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_8.DataPropertyName = "defectLocation";
			dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_8.DefaultCellStyle = dataGridViewCellStyle4;
			this.dataGridViewFilterTextBoxColumn_8.HeaderText = "Место повреждения";
			this.dataGridViewFilterTextBoxColumn_8.Name = "defectLocationDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_8.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_8.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_8.Visible = false;
			this.dataGridViewFilterTextBoxColumn_9.DataPropertyName = "Reason";
			dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_9.DefaultCellStyle = dataGridViewCellStyle5;
			this.dataGridViewFilterTextBoxColumn_9.HeaderText = "Причина";
			this.dataGridViewFilterTextBoxColumn_9.Name = "reasonDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_9.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_9.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_9.Visible = false;
			this.dataGridViewFilterTextBoxColumn_10.DataPropertyName = "DivisionApply";
			dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_10.DefaultCellStyle = dataGridViewCellStyle6;
			this.dataGridViewFilterTextBoxColumn_10.HeaderText = "Подразделение исполнитель";
			this.dataGridViewFilterTextBoxColumn_10.Name = "divisionApplyDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_10.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_10.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_10.Visible = false;
			this.dataGridViewFilterCheckBoxColumn_0.DataPropertyName = "isLaboratory";
			this.dataGridViewFilterCheckBoxColumn_0.HeaderText = "ПЛ";
			this.dataGridViewFilterCheckBoxColumn_0.Name = "isLaboratoryDgvColumn";
			this.dataGridViewFilterCheckBoxColumn_0.ReadOnly = true;
			this.dataGridViewFilterCheckBoxColumn_0.Visible = false;
			this.dataGridViewFilterCheckBoxColumn_0.Width = 40;
			this.dataGridViewFilterTextBoxColumn_11.DataPropertyName = "dateApply";
			this.dataGridViewFilterTextBoxColumn_11.HeaderText = "Дата устранения";
			this.dataGridViewFilterTextBoxColumn_11.Name = "dateApplyDgvColumn";
			this.dataGridViewFilterTextBoxColumn_11.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_11.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_11.Visible = false;
			this.dataGridViewFilterCheckBoxColumn_1.DataPropertyName = "isApply";
			this.dataGridViewFilterCheckBoxColumn_1.HeaderText = "Выполнено";
			this.dataGridViewFilterCheckBoxColumn_1.Name = "isApplyDgvColumn";
			this.dataGridViewFilterCheckBoxColumn_1.ReadOnly = true;
			this.dataGridViewFilterCheckBoxColumn_1.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterCheckBoxColumn_1.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewFilterCheckBoxColumn_1.Visible = false;
			this.dataGridViewFilterTextBoxColumn_12.DataPropertyName = "workerApply";
			this.dataGridViewFilterTextBoxColumn_12.HeaderText = "Выполнил";
			this.dataGridViewFilterTextBoxColumn_12.Name = "workerApplyDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_12.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_12.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_12.Visible = false;
			this.dataGridViewFilterTextBoxColumn_13.DataPropertyName = "completedWork";
			dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_13.DefaultCellStyle = dataGridViewCellStyle7;
			this.dataGridViewFilterTextBoxColumn_13.HeaderText = "Выполненная работа";
			this.dataGridViewFilterTextBoxColumn_13.Name = "completedWorkDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_13.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_13.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_13.Visible = false;
			this.rqiCnkKyvdA.DataPropertyName = "compiler";
			this.rqiCnkKyvdA.HeaderText = "Составитель";
			this.rqiCnkKyvdA.Name = "compilerDataGridViewTextBoxColumn";
			this.rqiCnkKyvdA.ReadOnly = true;
			this.rqiCnkKyvdA.Resizable = DataGridViewTriState.True;
			this.rqiCnkKyvdA.Visible = false;
			this.dataGridViewFilterTextBoxColumn_14.DataPropertyName = "Instruction";
			dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_14.DefaultCellStyle = dataGridViewCellStyle8;
			this.dataGridViewFilterTextBoxColumn_14.HeaderText = "Указания";
			this.dataGridViewFilterTextBoxColumn_14.Name = "InstructionDgvColumn";
			this.dataGridViewFilterTextBoxColumn_14.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_14.Visible = false;
			this.dataGridViewFilterTextBoxColumn_14.Width = 120;
			this.dataGridViewFilterTextBoxColumn_15.DataPropertyName = "ownerName";
			this.dataGridViewFilterTextBoxColumn_15.HeaderText = "Автор";
			this.dataGridViewFilterTextBoxColumn_15.Name = "nameOwnerDgvColumn";
			this.dataGridViewFilterTextBoxColumn_15.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_15.Visible = false;
			this.dataGridViewFilterTextBoxColumn_16.DataPropertyName = "dateOwner";
			this.dataGridViewFilterTextBoxColumn_16.HeaderText = "Дата создания";
			this.dataGridViewFilterTextBoxColumn_16.Name = "dateOwnerDgvColumn";
			this.dataGridViewFilterTextBoxColumn_16.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_16.Visible = false;
			this.dataGridViewTextBoxColumn_0.DataPropertyName = "ComletedWorkText";
			dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_0.DefaultCellStyle = dataGridViewCellStyle9;
			this.dataGridViewTextBoxColumn_0.HeaderText = "Выполненная работа текст";
			this.dataGridViewTextBoxColumn_0.Name = "comletedWorkTextDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_0.ReadOnly = true;
			this.dataGridViewTextBoxColumn_0.Visible = false;
			this.dataGridViewFilterTextBoxColumn_17.DataPropertyName = "KodPTS";
			dataGridViewCellStyle10.Format = "N0";
			dataGridViewCellStyle10.NullValue = null;
			this.dataGridViewFilterTextBoxColumn_17.DefaultCellStyle = dataGridViewCellStyle10;
			this.dataGridViewFilterTextBoxColumn_17.HeaderText = "Код повреждения";
			this.dataGridViewFilterTextBoxColumn_17.Name = "KodPTSDgvColumn";
			this.dataGridViewFilterTextBoxColumn_17.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_17.Visible = false;
			this.ucvCnGfImtA.DataPropertyName = "KodPTSStr";
			this.ucvCnGfImtA.HeaderText = "Код повреждения (стр)";
			this.ucvCnGfImtA.Name = "kodPTSStrDgvColumn";
			this.ucvCnGfImtA.ReadOnly = true;
			this.ucvCnGfImtA.Resizable = DataGridViewTriState.True;
			this.ucvCnGfImtA.Visible = false;
			this.dataGridViewTextBoxColumn_1.DataPropertyName = "idParent";
			this.dataGridViewTextBoxColumn_1.HeaderText = "Родитель";
			this.dataGridViewTextBoxColumn_1.Name = "idParentDgvColumn";
			this.dataGridViewTextBoxColumn_1.ReadOnly = true;
			this.dataGridViewTextBoxColumn_1.Visible = false;
			this.dataGridViewTextBoxColumn_2.DataPropertyName = "TypeDoc";
			this.dataGridViewTextBoxColumn_2.HeaderText = "TypeDoc";
			this.dataGridViewTextBoxColumn_2.Name = "typeDocDgvColumn";
			this.dataGridViewTextBoxColumn_2.ReadOnly = true;
			this.dataGridViewTextBoxColumn_2.Visible = false;
			this.dataGridViewTextBoxColumn_3.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_3.HeaderText = "id";
			this.dataGridViewTextBoxColumn_3.Name = "idDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_3.ReadOnly = true;
			this.dataGridViewTextBoxColumn_3.Visible = false;
			this.dataGridViewFilterTextBoxColumn_18.DataPropertyName = "signCrashType";
			this.dataGridViewFilterTextBoxColumn_18.HeaderText = "Код учетного признака аварии";
			this.dataGridViewFilterTextBoxColumn_18.Name = "signCrashTypeDgvActDetection";
			this.dataGridViewFilterTextBoxColumn_18.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_18.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_19.DataPropertyName = "signCrashName";
			this.dataGridViewFilterTextBoxColumn_19.HeaderText = "Учетный признак аварии";
			this.dataGridViewFilterTextBoxColumn_19.Name = "signCrashNameDgvActDetection";
			this.dataGridViewFilterTextBoxColumn_19.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_19.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_20.DataPropertyName = "typeEquip";
			this.dataGridViewFilterTextBoxColumn_20.HeaderText = "Код оборудования";
			this.dataGridViewFilterTextBoxColumn_20.Name = "typeEquipDgvActDetection";
			this.dataGridViewFilterTextBoxColumn_20.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_20.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_21.DataPropertyName = "typeEquipName";
			this.dataGridViewFilterTextBoxColumn_21.HeaderText = "Вид оборудования";
			this.dataGridViewFilterTextBoxColumn_21.Name = "typeEquipNameDgvActDetection";
			this.dataGridViewFilterTextBoxColumn_21.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_21.Resizable = DataGridViewTriState.True;
			this.yjqCnLapbPB.DataPropertyName = "reasonCrashEquipType";
			this.yjqCnLapbPB.HeaderText = "Код технической причины";
			this.yjqCnLapbPB.Name = "reasonCrashEquipTypeDgvActDetection";
			this.yjqCnLapbPB.ReadOnly = true;
			this.yjqCnLapbPB.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_22.DataPropertyName = "reasonCrashEquipName";
			this.dataGridViewFilterTextBoxColumn_22.HeaderText = "Техническая причина";
			this.dataGridViewFilterTextBoxColumn_22.Name = "reasonCrashEquipNameDgvActDetection";
			this.dataGridViewFilterTextBoxColumn_22.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_22.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_23.DataPropertyName = "reasonCrashType";
			this.dataGridViewFilterTextBoxColumn_23.HeaderText = "Код организ. причины аварии";
			this.dataGridViewFilterTextBoxColumn_23.Name = "reasonCrashTypeDgvActDetection";
			this.dataGridViewFilterTextBoxColumn_23.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_23.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_24.DataPropertyName = "reasonCrashName";
			this.dataGridViewFilterTextBoxColumn_24.HeaderText = "Организ. причина аварии";
			this.dataGridViewFilterTextBoxColumn_24.Name = "reasonCrashNameDgvActDetection";
			this.dataGridViewFilterTextBoxColumn_24.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_24.Resizable = DataGridViewTriState.True;
			this.bindingSource_0.DataMember = "vJ_Damage";
			this.bindingSource_0.DataSource = this.class171_0;
			this.class171_0.DataSetName = "DataSetDamage";
			this.class171_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
			this.toolStripMenuItem_4.Image = (Image)componentResourceManager.GetObject("toolItemAdd.Image");
			this.toolStripMenuItem_4.Name = "toolItemAdd";
			this.toolStripMenuItem_4.Size = new Size(135, 26);
			this.toolStripMenuItem_4.Text = "Добавить";
			this.toolStripMenuItem_4.Click += this.toolStripMenuItem_4_Click;
			this.toolStripMenuItem_5.Image = (Image)componentResourceManager.GetObject("toolItemEdit.Image");
			this.toolStripMenuItem_5.Name = "toolItemEdit";
			this.toolStripMenuItem_5.Size = new Size(135, 26);
			this.toolStripMenuItem_5.Text = "Изменить";
			this.toolStripMenuItem_5.Click += this.toolStripMenuItem_5_Click;
			this.toolStripMenuItem_6.Image = (Image)componentResourceManager.GetObject("toolItemInfo.Image");
			this.toolStripMenuItem_6.Name = "toolItemInfo";
			this.toolStripMenuItem_6.Size = new Size(135, 26);
			this.toolStripMenuItem_6.Text = "Просмотр";
			this.toolStripMenuItem_6.Click += this.toolStripMenuItem_6_Click;
			this.toolStripMenuItem_7.Image = (Image)componentResourceManager.GetObject("toolItemDel.Image");
			this.toolStripMenuItem_7.Name = "toolItemDel";
			this.toolStripMenuItem_7.Size = new Size(135, 26);
			this.toolStripMenuItem_7.Text = "Удалить";
			this.toolStripMenuItem_7.Click += this.toolStripMenuItem_7_Click;
			this.contextMenuStrip_0.ImageScalingSize = new Size(20, 20);
			this.contextMenuStrip_0.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripMenuItem_4,
				this.toolStripMenuItem_5,
				this.toolStripMenuItem_6,
				this.toolStripMenuItem_7
			});
			this.contextMenuStrip_0.Name = "contextMenuDamage";
			this.contextMenuStrip_0.Size = new Size(136, 108);
			this.contextMenuStrip_0.Opening += this.contextMenuStrip_0_Opening;
			this.toolStripMenuItem_9.Name = "tsMenuReportAccidents";
			this.toolStripMenuItem_9.Size = new Size(270, 22);
			this.toolStripMenuItem_9.Text = "Перечень аварий";
			this.toolStripMenuItem_9.Click += this.toolStripMenuItem_9_Click;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(1022, 602);
			base.Controls.Add(this.splitContainer_0);
			base.Controls.Add(this.toolStrip_0);
			base.Name = "FormJournalActDetection";
			this.Text = "Журнал актов расследования";
			base.FormClosed += this.FormJournalActDetection_FormClosed;
			base.Load += this.FormJournalActDetection_Load;
			this.toolStrip_0.ResumeLayout(false);
			this.toolStrip_0.PerformLayout();
			this.splitContainer_0.Panel1.ResumeLayout(false);
			this.splitContainer_0.Panel1.PerformLayout();
			this.splitContainer_0.Panel2.ResumeLayout(false);
			this.splitContainer_0.ResumeLayout(false);
			this.toolStrip_2.ResumeLayout(false);
			this.toolStrip_2.PerformLayout();
			this.toolStrip_1.ResumeLayout(false);
			this.toolStrip_1.PerformLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_0).EndInit();
			((ISupportInitialize)this.bindingSource_0).EndInit();
			((ISupportInitialize)this.class171_0).EndInit();
			this.contextMenuStrip_0.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private List<int> list_0;

		private ToolStrip toolStrip_0;

		private SplitContainer splitContainer_0;

		private DateTimePicker dateTimePicker_0;

		private Label label_0;

		private DateTimePicker HwxCmhcuWjh;

		private Label label_1;

		private ToolStrip toolStrip_1;

		private ToolStripButton toolStripButton_0;

		private ToolStripButton toolStripButton_1;

		private ToolStripButton toolStripButton_2;

		private ToolStripButton toolStripButton_3;

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

		private ToolStripButton TofCmzEeWbS;

		private ToolStripSeparator toolStripSeparator_2;

		private ToolStripDropDownButton toolStripDropDownButton_0;

		private ToolStripSeparator toolStripSeparator_3;

		private ToolStripDropDownButton toolStripDropDownButton_1;

		private ToolStripMenuItem toolStripMenuItem_0;

		private ToolStripMenuItem toolStripMenuItem_1;

		private ToolStripButton toolStripButton_13;

		private ToolStripButton toolStripButton_14;

		private ToolStripButton toolStripButton_15;

		private ToolStripMenuItem toolStripMenuItem_2;

		private ToolStripMenuItem toolStripMenuItem_3;

		private ToolStripButton gdsCnMvWiGu;

		private ToolStripMenuItem toolStripMenuItem_4;

		private ToolStripMenuItem toolStripMenuItem_5;

		private ToolStripMenuItem toolStripMenuItem_6;

		private ToolStripMenuItem toolStripMenuItem_7;

		private ContextMenuStrip contextMenuStrip_0;

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

		private DataGridViewFilterCheckBoxColumn dataGridViewFilterCheckBoxColumn_0;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_11;

		private DataGridViewFilterCheckBoxColumn dataGridViewFilterCheckBoxColumn_1;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_12;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_13;

		private DataGridViewFilterTextBoxColumn rqiCnkKyvdA;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_14;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_15;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_16;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_17;

		private DataGridViewFilterTextBoxColumn ucvCnGfImtA;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_3;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_18;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_19;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_20;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_21;

		private DataGridViewFilterTextBoxColumn yjqCnLapbPB;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_22;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_23;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_24;

		private ToolStripMenuItem toolStripMenuItem_8;

		private ToolStripMenuItem toolStripMenuItem_9;
	}
}
