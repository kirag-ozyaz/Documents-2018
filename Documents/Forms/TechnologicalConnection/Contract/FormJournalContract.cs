using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using ControlsLbr.DataGridViewExcelFilter;
using ControlsLbr.DataGridViewExcelFilter.DataGridViewColumsLibraty;
using DataSql;
using Documents.Forms.TechnologicalConnection.TU;
using Documents.Properties;
using FormLbr;
using FormLbr.Classes;
using Microsoft.Office.Interop.Excel;

namespace Documents.Forms.TechnologicalConnection.Contract
{
	public partial class FormJournalContract : FormBase
	{
		public FormJournalContract()
		{
			
			this.int_0 = -1;
			this.int_1 = -1;
			this.int_2 = -1;
			this.int_3 = -1;
			this.int_4 = -1;
			
			this.method_8();
			this.method_3();
		}

		public FormJournalContract(int idContract)
		{
			
			this.int_0 = -1;
			this.int_1 = -1;
			this.int_2 = -1;
			this.int_3 = -1;
			this.int_4 = -1;
			
			this.method_8();
			this.method_3();
			this.int_0 = idContract;
		}

		public FormJournalContract(List<int> checkedSubstation)
		{
			
			this.int_0 = -1;
			this.int_1 = -1;
			this.int_2 = -1;
			this.int_3 = -1;
			this.int_4 = -1;
			
			this.method_8();
			this.method_3();
			this.list_0 = checkedSubstation;
		}

		private void FormJournalContract_Load(object sender, EventArgs e)
		{
			this.toolStripButton_16.Visible = false;
			base.LoadFormConfig(null);
			this.method_6();
			int num = -1;
			if (this.int_0 > 0)
			{
				Class10.Class12 @class = new Class10.Class12();
				base.SelectSqlData(@class, true, " where id = " + this.int_0.ToString(), null, false, 0);
				if (@class.Rows.Count > 0)
				{
					if (@class.Rows[0]["DateDoc"] != DBNull.Value)
					{
						DateTime dateTime = Convert.ToDateTime(@class.Rows[0]["DateDoc"]);
						this.dateTimePicker_1.Value = new DateTime(dateTime.Year, 1, 1);
						this.dateTimePicker_0.Value = new DateTime(dateTime.Year, 12, 31);
					}
					num = this.int_1;
				}
			}
			this.method_0();
			if (num != -1)
			{
				this.dataGridViewExcelFilter_0.SearchGrid(this.dataGridViewTextBoxColumn_87.Name, num.ToString(), false);
				if (this.dataGridViewExcelFilter_0.CurrentRow != null)
				{
					this.dataGridViewExcelFilter_0.FirstDisplayedScrollingRowIndex = this.dataGridViewExcelFilter_0.CurrentRow.Index;
				}
			}
		}

		private void FormJournalContract_FormClosed(object sender, FormClosedEventArgs e)
		{
			base.SaveFormConfig(null);
		}

		private void method_0()
		{
			int num = this.int_0;
			List<int> list = this.method_7(this.treeView_0.Nodes);
			string text = string.Format(" where DateDoc >= '{0}' and DateDoc <= '{1}'", this.dateTimePicker_1.Value.ToString("yyyyMMdd"), this.dateTimePicker_0.Value.ToString("yyyyMMdd"));
			if (list != null && list.Count > 0)
			{
				string text2 = "";
				foreach (int num2 in list)
				{
					if (string.IsNullOrEmpty(text2))
					{
						text2 = num2.ToString();
					}
					else
					{
						text2 = text2 + "," + num2.ToString();
					}
				}
				text += string.Format(" and idTU in (select idTU from ttc_tuPointAttach where idSubPoint in ({0}) and (typeDoc is null or typeDoc = {1})) ", text2, 1123);
			}
			text += " ORDER BY CONVERT(BIGINT, CASE WHEN numdoc like '%[^0-9]%' THEN SUBSTRING(numdoc,1,PATINDEX('%[^0-9]%',numdoc)-1) ELSE numdoc END) desc";
			base.SelectSqlData(this.class10_0, this.class10_0.vTC_Contract, true, text);
			if (num > 0)
			{
				this.dataGridViewExcelFilter_0.SearchGrid(this.dataGridViewTextBoxColumn_87.Name, num.ToString(), false);
			}
		}

		private void dataGridViewExcelFilter_0_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
		{
			((DataGridView)sender).AutoResizeRow(e.RowIndex);
		}

		private void dataGridViewExcelFilter_0_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && this.toolStripButton_1.Enabled && this.toolStripButton_1.Visible)
			{
				this.toolStripButton_1_Click(sender, e);
			}
		}

		private void dataGridViewExcelFilter_0_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.RowIndex >= 0 && this.dataGridViewExcelFilter_0[this.dataGridViewCheckBoxColumn_0.Name, e.RowIndex].Value != null && this.dataGridViewExcelFilter_0[this.dataGridViewCheckBoxColumn_0.Name, e.RowIndex].Value != DBNull.Value && Convert.ToBoolean(this.dataGridViewExcelFilter_0[this.dataGridViewCheckBoxColumn_0.Name, e.RowIndex].Value))
			{
				e.CellStyle.ForeColor = Color.Red;
			}
		}

		private void dataGridViewExcelFilter_0_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
		{
		}

		private void dataGridViewExcelFilter_0_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
		{
			for (int i = e.RowIndex; i < e.RowIndex + e.RowCount; i++)
			{
				if (i >= 0)
				{
					DataGridViewColumn dataGridViewColumn = this.dataGridViewFilterProgressColumn_0;
					if (this.dataGridViewExcelFilter_0[dataGridViewColumn.Index, i].Value != null && this.dataGridViewExcelFilter_0[dataGridViewColumn.Index, i].Value != DBNull.Value && this.dataGridViewExcelFilter_0[this.dataGridViewTextBoxColumn_93.Index, i].Value != null && this.dataGridViewExcelFilter_0[this.dataGridViewTextBoxColumn_93.Index, i].Value != DBNull.Value)
					{
						int progressValue = Convert.ToInt32(Convert.ToDecimal(this.dataGridViewExcelFilter_0[this.dataGridViewTextBoxColumn_93.Index, i].Value) / Convert.ToDecimal(this.dataGridViewExcelFilter_0[dataGridViewColumn.Index, i].Value) * 100m);
						((DataGridViewFilterProgressCell)this.dataGridViewExcelFilter_0[this.dataGridViewFilterProgressColumn_0.Index, i]).ProgressValue = progressValue;
						this.dataGridViewExcelFilter_0[this.dataGridViewFilterProgressColumn_0.Index, i].ToolTipText = progressValue.ToString() + "%";
					}
					else
					{
						this.dataGridViewExcelFilter_0[this.dataGridViewFilterProgressColumn_0.Index, i].ToolTipText = "0%";
					}
				}
			}
		}

		private void toolStripButton_0_Click(object sender, EventArgs e)
		{
			Form20 form = new Form20();
			form.SqlSettings = this.SqlSettings;
			form.MdiParent = base.MdiParent;
			form.FormClosed += this.method_1;
			form.Show();
		}

		private void method_1(object sender, FormClosedEventArgs e)
		{
			this.int_0 = ((Form20)sender).method_0();
			this.method_0();
		}

		private void toolStripButton_1_Click(object sender, EventArgs e)
		{
			if (this.int_0 != -1)
			{
				Form20 form = new Form20(this.int_0, -1, -1);
				form.SqlSettings = this.SqlSettings;
				form.MdiParent = base.MdiParent;
				form.FormClosed += this.method_1;
				form.Show();
			}
		}

		private void toolStripButton_2_Click(object sender, EventArgs e)
		{
			if (this.int_0 > 0 && this.dataGridViewExcelFilter_0.CurrentRow != null && MessageBox.Show("Вы действительно хотите удалить текущую запись?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes && base.DeleteSqlDataById(this.class10_0.tTC_Doc, this.int_0))
			{
				this.dataGridViewExcelFilter_0.Rows.Remove(this.dataGridViewExcelFilter_0.CurrentRow);
				MessageBox.Show("Запись успешно удалена");
			}
		}

		private void toolStripButton_9_Click(object sender, EventArgs e)
		{
			this.method_0();
		}

		private void toolStripButton_3_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_0.CurrentRow != null && this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_89.Name].Value != null && this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_89.Name].Value != DBNull.Value)
			{
				new FormTechConnectionRequest(Convert.ToInt32(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_89.Name].Value))
				{
					MdiParent = base.MdiParent,
					SqlSettings = this.SqlSettings
				}.Show();
			}
		}

		private void toolStripButton_17_Click(object sender, EventArgs e)
		{
			if (this.int_2 != -1)
			{
				new FormJournalTU(this.int_2)
				{
					MdiParent = base.MdiParent,
					SqlSettings = this.SqlSettings
				}.Show();
			}
		}

		private void toolStripButton_4_Click(object sender, EventArgs e)
		{
			this.dataGridViewExcelFilter_0.SearchGrid(DataGridViewExcelFilter.TypeFind.Begin, this.toolStripTextBox_0.Text);
		}

		private void qmwoCohnfwh(object sender, EventArgs e)
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
				if (e.Modifiers == Keys.None)
				{
					this.dataGridViewExcelFilter_0.SearchGrid(DataGridViewExcelFilter.TypeFind.Next, this.toolStripTextBox_0.Text);
				}
				if (e.Modifiers == Keys.Shift)
				{
					this.dataGridViewExcelFilter_0.SearchGrid(DataGridViewExcelFilter.TypeFind.Prev, this.toolStripTextBox_0.Text);
				}
			}
		}

		private void toolStripButton_18_Click(object sender, EventArgs e)
		{
			this.method_2(this.dataGridViewExcelFilter_0);
		}

		private void method_2(DataGridView dataGridView_1)
		{
			_Application application = new ApplicationClass();
			_Workbook workbook = application.Workbooks.Add(Type.Missing);
			application.Visible = false;
			_Worksheet worksheet = (Worksheet)workbook.ActiveSheet;
			worksheet.Name = "Exported from gridview";
			int num = 1;
			for (int i = 0; i < dataGridView_1.Columns.Count; i++)
			{
				if (dataGridView_1.Columns[i].Visible)
				{
					worksheet.Cells[1, num] = dataGridView_1.Columns[i].HeaderText;
					((Range)worksheet.Cells[1, num]).Font.Bold = true;
					num++;
				}
			}
			for (int j = 0; j < dataGridView_1.Rows.Count - 1; j++)
			{
				num = 1;
				Color white = Color.White;
				for (int k = 0; k < dataGridView_1.Columns.Count; k++)
				{
					if (dataGridView_1.Columns[k].Visible)
					{
						worksheet.Cells[j + 2, num] = dataGridView_1.Rows[j].Cells[k].Value.ToString();
						((Range)worksheet.Cells[j + 2, num]).WrapText = true;
						((Range)worksheet.Cells[j + 2, num]).Interior.Color = ColorTranslator.ToOle(white);
						num++;
					}
				}
			}
			application.Visible = true;
		}

		private void toolStripButton_19_Click(object sender, EventArgs e)
		{
			new Form21
			{
				SqlSettings = this.SqlSettings,
				MdiParent = base.MdiParent
			}.Show();
		}

		private void bindingSource_0_CurrentChanged(object sender, EventArgs e)
		{
			if (this.bsTC_Contract.Current != null)
			{
				this.int_0 = Convert.ToInt32(((DataRowView)this.bsTC_Contract.Current).Row["id"]);
				if (((DataRowView)this.bsTC_Contract.Current).Row["idRequest"] != DBNull.Value)
				{
					this.int_1 = Convert.ToInt32(((DataRowView)this.bsTC_Contract.Current).Row["idRequest"]);
				}
				else
				{
					this.int_1 = -1;
				}
				if (((DataRowView)this.bsTC_Contract.Current).Row["idTU"] != DBNull.Value)
				{
					this.int_2 = Convert.ToInt32(((DataRowView)this.bsTC_Contract.Current).Row["idTU"]);
				}
				else
				{
					this.int_2 = -1;
				}
				this.method_4();
				if (this.int_1 == -1)
				{
					base.SelectSqlData(this.class10_0, this.class10_0.vTC_DocOut, true, " where (idDoc = " + this.int_0.ToString() + ")  order by dateDocOut desc");
				}
				else
				{
					base.SelectSqlData(this.class10_0, this.class10_0.vTC_DocOut, true, string.Concat(new string[]
					{
						" where (idDoc = ",
						this.int_0.ToString(),
						") or  (idDoc = ",
						this.int_1.ToString(),
						" and TypeDocOut = ",
						1218.ToString(),
						") order by dateDocOut desc"
					}));
				}
				base.SelectSqlData(this.class10_0, this.class10_0.tTC_TUTypeWork, true, " where idTU = " + this.int_2.ToString());
				base.SelectSqlData(this.class10_0, this.class10_0.vTC_Payment, true, " where idParent = " + this.int_0.ToString());
				base.SelectSqlData(this.class10_0, this.class10_0.tTC_PaymentShedule, true, " where idDoc = " + this.int_0.ToString());
			}
			else
			{
				this.int_0 = -1;
				this.int_1 = -1;
				this.class10_0.tTC_DocFile.Clear();
				this.class10_0.vTC_DocOut.Clear();
				this.class10_0.tTC_TUTypeWork.Clear();
				this.class10_0.vTC_Payment.Clear();
				this.class10_0.tTC_PaymentShedule.Clear();
				this.class10_1.tTC_Doc.Clear();
			}
			if (this.int_1 == -1)
			{
				this.class10_0.vTC_RequestHistory.Clear();
				return;
			}
			Class10.Class12 @class = new Class10.Class12();
			base.SelectSqlData(@class, true, " where id = " + this.int_1.ToString(), null, false, 0);
			int num = this.int_1;
			if (@class.Rows.Count > 0 && @class.Rows[0]["idParent"] != DBNull.Value)
			{
				num = Convert.ToInt32(@class.Rows[0]["idParent"]);
			}
			base.SelectSqlData(this.class10_0, this.class10_0.vTC_RequestHistory, true, string.Concat(new string[]
			{
				"where id = ",
				num.ToString(),
				" or IdParent = ",
				num.ToString(),
				" order by dateDoc"
			}));
		}

		private void method_3()
		{
			this.dateTimePicker_1.Value = new DateTime(DateTime.Now.Year, 1, 1);
			this.dateTimePicker_0.Value = new DateTime(DateTime.Now.Year, 12, 31);
		}

		private void toolStripButton_7_Click(object sender, EventArgs e)
		{
			this.method_0();
		}

		private void toolStripButton_8_Click(object sender, EventArgs e)
		{
			this.method_3();
			this.method_0();
		}

		private void method_4()
		{
			if (this.int_0 != -1)
			{
				try
				{
					this.class10_0.tTC_DocFile.Clear();
					using (SqlConnection sqlConnection = new SqlConnection(this.SqlSettings.GetConnectionString()))
					{
						sqlConnection.Open();
						SqlDataReader sqlDataReader = new SqlCommand("SELECT id, idDoc, FileName, dateChange, idTemplate FROM tTC_DocFile WHERE idDoc = " + this.int_0.ToString(), sqlConnection).ExecuteReader();
						while (sqlDataReader.Read())
						{
							Class10.Class88 @class = this.class10_0.tTC_DocFile.method_5();
							@class.id = (int)sqlDataReader["id"];
							@class.idDoc = (int)sqlDataReader["idDoc"];
							@class.FileName = sqlDataReader["FileName"].ToString();
							if (sqlDataReader["dateChange"] != DBNull.Value)
							{
								@class.dateChange = (DateTime)sqlDataReader["dateChange"];
							}
							if (sqlDataReader["idTemplate"] != DBNull.Value)
							{
								@class.idTemplate = (int)sqlDataReader["idTemplate"];
							}
							this.class10_0.tTC_DocFile.Rows.Add(@class);
							@class.AcceptChanges();
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, ex.Source);
				}
			}
		}

		private void dataGridViewExcelFilter_1_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
		{
			if (((DataGridView)sender).RowCount > 0 && this.dgvFile[this.dataGridViewLinkColumn_0.Name, e.RowIndex].Value != null)
			{
				if (e.ColumnIndex == this.dgvFile.Columns[this.dataGridViewImageColumnNotNull_0.Name].Index)
				{
					if (!string.IsNullOrEmpty(Path.GetFileName(this.dgvFile[this.dataGridViewLinkColumn_0.Name, e.RowIndex].Value.ToString())))
					{
						e.Value = Path.GetFileName(this.dgvFile[this.dataGridViewLinkColumn_0.Name, e.RowIndex].Value.ToString());
					}
					else
					{
						e.Value = this.dgvFile[this.dataGridViewLinkColumn_0.Name, e.RowIndex].Value.ToString();
					}
				}
				if (e.ColumnIndex == this.dgvFile.Columns[this.dataGridViewImageColumnNotNull_0.Name].Index)
				{
					Icon icon = FormLbr.Classes.FileInfo.IconOfFile(this.dgvFile[this.dataGridViewLinkColumn_0.Name, e.RowIndex].Value.ToString());
					if (icon != null)
					{
						e.Value = icon.ToBitmap();
					}
				}
			}
		}

		private void dgvFile_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (this.dgvFile.CurrentRow == null)
			{
				return;
			}
			int num = Convert.ToInt32(this.dgvFile.CurrentRow.Cells[this.dataGridViewTextBoxColumn_0.Name].Value);
			if (e.ColumnIndex == this.dgvFile.Columns[this.dataGridViewLinkColumn_0.Name].Index)
			{
				System.Data.DataTable dataTable = new SqlDataCommand(this.SqlSettings).SelectSqlData("select [FileName], [File] from [tTC_DocFile] where id = " + num.ToString());
				if (dataTable.Rows.Count <= 0)
				{
					return;
				}
				byte[] array = (byte[])dataTable.Rows[0]["File"];
				string text = Path.GetTempFileName();
				text = Path.ChangeExtension(text, Path.GetExtension(dataTable.Rows[0]["FileName"].ToString()));
				FileStream fileStream = File.Create(text);
				fileStream.Write(array, 0, array.Length);
				fileStream.Close();
				try
				{
					new Process
					{
						StartInfo = 
						{
							FileName = text,
							UseShellExecute = true
						}
					}.Start();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, ex.Source);
				}
			}
		}

		protected override XmlDocument CreateXmlConfig()
		{
			XmlDocument xmlDocument = new XmlDocument();
			XmlNode newChild = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", null);
			xmlDocument.AppendChild(newChild);
			XmlNode xmlNode = xmlDocument.CreateElement(base.Name);
			xmlDocument.AppendChild(xmlNode);
			XmlAttribute xmlAttribute = xmlDocument.CreateAttribute("FilterDateBeg");
			xmlAttribute.Value = this.dateTimePicker_1.Value.ToString();
			xmlNode.Attributes.Append(xmlAttribute);
			xmlAttribute = xmlDocument.CreateAttribute("FilterDateEnd");
			xmlAttribute.Value = this.dateTimePicker_0.Value.ToString();
			xmlNode.Attributes.Append(xmlAttribute);
			return xmlDocument;
		}

		protected override void ApplyConfig(XmlDocument doc)
		{
			XmlNode xmlNode = doc.SelectSingleNode(base.Name);
			if (xmlNode != null)
			{
				XmlAttribute xmlAttribute = xmlNode.Attributes["FilterDateBeg"];
				if (xmlAttribute != null)
				{
					this.dateTimePicker_1.Value = Convert.ToDateTime(xmlAttribute.Value);
				}
				xmlAttribute = xmlNode.Attributes["FilterDateEnd"];
				if (xmlAttribute != null)
				{
					this.dateTimePicker_0.Value = Convert.ToDateTime(xmlAttribute.Value);
				}
			}
		}

		private void dataGridViewExcelFilter_2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.RowIndex >= 0 && Convert.ToInt32(this.dataGridViewExcelFilter_2[this.dataGridViewTextBoxColumn_71.Name, e.RowIndex].Value) == 1113)
			{
				e.CellStyle.Font = new System.Drawing.Font(e.CellStyle.Font, FontStyle.Bold);
				e.CellStyle.BackColor = Color.LightGray;
			}
		}

		private void dataGridViewExcelFilter_2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
		{
			this.dataGridViewExcelFilter_2.AutoResizeRow(e.RowIndex);
		}

		private void dataGridViewExcelFilter_3_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.RowIndex >= 0 && Convert.ToInt32(this.dataGridViewExcelFilter_3[this.dataGridViewTextBoxColumn_23.Name, e.RowIndex].Value) != this.int_0)
			{
				e.CellStyle.BackColor = Color.LightGray;
			}
		}

		private void toolStripButton_12_Click(object sender, EventArgs e)
		{
			if (this.int_0 != -1)
			{
				FormTechConnectionDocOutAddEdit formTechConnectionDocOutAddEdit = new FormTechConnectionDocOutAddEdit(-1, this.int_0);
				formTechConnectionDocOutAddEdit.SqlSettings = this.SqlSettings;
				if (formTechConnectionDocOutAddEdit.ShowDialog() == DialogResult.OK)
				{
					this.method_0();
					this.dataGridViewExcelFilter_3.SearchGrid(this.dataGridViewTextBoxColumn_21.Name, formTechConnectionDocOutAddEdit.IdDocOut.ToString(), false);
				}
			}
		}

		private void toolStripButton_10_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_3.CurrentRow != null)
			{
				if (Convert.ToInt32(this.dataGridViewExcelFilter_3.CurrentRow.Cells[this.dataGridViewTextBoxColumn_23.Name].Value) != this.int_0)
				{
					MessageBox.Show("Невозможно редактировать данный документ");
					return;
				}
				FormTechConnectionDocOutAddEdit formTechConnectionDocOutAddEdit = new FormTechConnectionDocOutAddEdit(Convert.ToInt32(this.dataGridViewExcelFilter_3.CurrentRow.Cells[this.dataGridViewTextBoxColumn_21.Name].Value), this.int_0);
				formTechConnectionDocOutAddEdit.SqlSettings = this.SqlSettings;
				if (formTechConnectionDocOutAddEdit.ShowDialog() == DialogResult.OK)
				{
					this.method_0();
					this.dataGridViewExcelFilter_3.SearchGrid(this.dataGridViewTextBoxColumn_21.Name, formTechConnectionDocOutAddEdit.IdDocOut.ToString(), false);
				}
			}
		}

		private void toolStripButton_11_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_3.CurrentRow != null)
			{
				if (Convert.ToInt32(this.dataGridViewExcelFilter_3.CurrentRow.Cells[this.dataGridViewTextBoxColumn_23.Name].Value) != this.int_0)
				{
					MessageBox.Show("Невозможно удалить данный документ");
					return;
				}
				if (MessageBox.Show("Вы действительно хотите удалить текущий документ", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					Convert.ToInt32(this.dataGridViewExcelFilter_3.CurrentRow.Cells[this.dataGridViewTextBoxColumn_21.Name].Value);
					int id = Convert.ToInt32(this.dataGridViewExcelFilter_3.CurrentRow.Cells[this.dataGridViewTextBoxColumn_26.Name].Value);
					if (base.DeleteSqlDataById(this.class10_0.tTC_Doc, id))
					{
						this.dataGridViewExcelFilter_3.Rows.Remove(this.dataGridViewExcelFilter_3.CurrentRow);
						this.method_0();
						MessageBox.Show("Документ успешно удален");
					}
				}
			}
		}

		private void bindingSource_2_CurrentChanged(object sender, EventArgs e)
		{
			if (this.bindingSource_2.Current != null)
			{
				this.int_3 = Convert.ToInt32(((DataRowView)this.bindingSource_2.Current)["idDocOut"]);
				this.int_4 = Convert.ToInt32(((DataRowView)this.bindingSource_2.Current)["idDoc"]);
				this.method_5();
				return;
			}
			this.int_3 = -1;
			this.int_4 = -1;
			this.bindingSource_3.DataSource = null;
		}

		private void method_5()
		{
			Class10.Class25 @class = new Class10.Class25();
			base.SelectSqlData(@class, true, " where idDoc = " + this.int_3.ToString() + " order by dateChange desc", null, false, 0);
			this.bindingSource_3.DataSource = @class;
			this.dataGridViewTextBoxColumn_33.Visible = false;
		}

		private void toolStripButton_13_Click(object sender, EventArgs e)
		{
			if (this.int_3 != -1)
			{
				if (this.int_4 != this.int_0)
				{
					MessageBox.Show("Невозможно редактировать данный документ");
					return;
				}
				if (new Form14(-1, this.int_3, true)
				{
					SqlSettings = this.SqlSettings
				}.ShowDialog() == DialogResult.OK)
				{
					this.method_5();
				}
			}
		}

		private void toolStripButton_14_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_4.CurrentRow != null && this.int_3 != -1)
			{
				if (this.int_4 != this.int_0)
				{
					MessageBox.Show("Невозможно редактировать данный документ");
					return;
				}
				int num = Convert.ToInt32(this.dataGridViewExcelFilter_4.CurrentRow.Cells[this.dataGridViewTextBoxColumn_33.Name].Value);
				if (new Form14(num, this.int_3, true)
				{
					SqlSettings = this.SqlSettings
				}.ShowDialog() == DialogResult.OK)
				{
					this.method_5();
					this.dataGridViewExcelFilter_4.SearchGrid(this.dataGridViewTextBoxColumn_33.Name, num.ToString(), false);
				}
			}
		}

		private void toolStripButton_15_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_4.CurrentRow != null)
			{
				if (this.int_4 != this.int_0)
				{
					MessageBox.Show("Невозможно редактировать данный документ");
					return;
				}
				if (MessageBox.Show("Вы действительно хотите удалить текущий статус", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					int id = Convert.ToInt32(this.dataGridViewExcelFilter_4.CurrentRow.Cells[this.dataGridViewTextBoxColumn_33.Name].Value);
					if (base.DeleteSqlDataById(this.class10_0.tTC_DocStatus, id))
					{
						this.dataGridViewExcelFilter_4.Rows.Remove(this.dataGridViewExcelFilter_4.CurrentRow);
						MessageBox.Show("Статус успешно удален");
					}
				}
			}
		}

		private void toolStripButton_16_Click(object sender, EventArgs e)
		{
			foreach (object obj in new SqlDataCommand(new SQLSettings("ulges-sql", "PTS", "WINDOWS", "", "")).SelectSqlData("tbl_TU", false, " where tuvid = 1 and year([Дата])>=2013 and year([Дата]) <= 2013 and [Номер] = 971 and [Номер] < 9999 order by [Дата] desc ", null).Rows)
			{
				DataRow dataRow = (DataRow)obj;
				int num = -1;
				if (dataRow["НомерВ"] != DBNull.Value && dataRow["ДатаВ"] != DBNull.Value)
				{
					System.Data.DataTable dataTable = base.SelectSqlData("ttc_Request", true, " where numIn = '" + dataRow["НомерВ"].ToString() + "' and year(dateIn) = " + Convert.ToDateTime(dataRow["ДатаВ"]).Year.ToString());
					if (dataTable.Rows.Count > 0)
					{
						num = Convert.ToInt32(dataTable.Rows[0]["id"]);
					}
				}
				Class10 @class = new Class10();
				base.SelectSqlData(@class.tTC_Doc, true, string.Concat(new string[]
				{
					" where numDoc = '",
					dataRow["Номер"].ToString(),
					"' and year(dateDoc) = ",
					Convert.ToDateTime(dataRow["Дата"]).Year.ToString(),
					" and typeDoc = ",
					1123.ToString()
				}), null, false, 0);
				int num2;
				if (@class.tTC_Doc.Rows.Count == 0)
				{
					DataRow dataRow2 = @class.tTC_Doc.NewRow();
					dataRow2["numDoc"] = dataRow["Номер"];
					dataRow2["dateDoc"] = dataRow["Дата"];
					dataRow2["TypeDoc"] = 1123;
					dataRow2["Body"] = dataRow["Содержание"];
					if (num == -1)
					{
						dataRow2["Comment"] = string.Concat(new string[]
						{
							"NumIn:",
							dataRow["НомерВ"].ToString(),
							";DateIn:",
							dataRow["ДатаВ"].ToString(),
							";"
						});
					}
					@class.tTC_Doc.Rows.Add(dataRow2);
					num2 = base.InsertSqlDataOneRow(@class.tTC_Doc.Rows[0]);
				}
				else
				{
					if (@class.tTC_Doc.Rows[0]["Body"] == DBNull.Value)
					{
						@class.tTC_Doc.Rows[0]["Body"] = dataRow["Содержание"];
					}
					if (num == -1)
					{
						@class.tTC_Doc.Rows[0]["Comment"] = string.Concat(new string[]
						{
							"NumIn:",
							dataRow["НомерВ"].ToString(),
							";DateIn:",
							dataRow["ДатаВ"].ToString(),
							";"
						});
					}
					@class.tTC_Doc.Rows[0].EndEdit();
					base.UpdateSqlData(@class, @class.tTC_Doc);
					num2 = Convert.ToInt32(@class.tTC_Doc.Rows[0]["id"]);
				}
				if (dataRow["DogNom"] != DBNull.Value && dataRow["DogDate"] != DBNull.Value && dataRow["DogNom"].ToString() != "не подписывались")
				{
					bool flag = false;
					if (@class.tTC_Doc.Rows[0]["idParent"] == DBNull.Value)
					{
						flag = true;
					}
					else if (base.SelectSqlData("ttc_doc", true, "where id = " + @class.tTC_Doc.Rows[0]["idParent"].ToString()).Rows.Count == 0)
					{
						flag = true;
					}
					if (flag)
					{
						Class10 class2 = new Class10();
						DataRow dataRow3 = class2.tTC_Doc.NewRow();
						dataRow3["numDoc"] = dataRow["DogNom"];
						dataRow3["dateDoc"] = dataRow["DogDate"];
						dataRow3["TypeDoc"] = 1220;
						class2.tTC_Doc.Rows.Add(dataRow3);
						int num3 = base.InsertSqlDataOneRow(class2, class2.tTC_Doc);
						if (num3 > 0)
						{
							@class.tTC_Doc.AcceptChanges();
							@class.tTC_Doc.Rows[0]["idParent"] = num3;
							@class.tTC_Doc.Rows[0].EndEdit();
							base.UpdateSqlData(@class, @class.tTC_Doc);
							if (num > 0)
							{
								base.SelectSqlData(class2.tTC_DocOut, true, "where idDoc = " + num.ToString() + " and idDocOut = " + num3.ToString(), null, false, 0);
								if (class2.tTC_DocOut.Rows.Count == 0)
								{
									DataRow dataRow4 = class2.tTC_DocOut.NewRow();
									dataRow4["iddoc"] = num;
									dataRow4["iddocout"] = num3;
									class2.tTC_DocOut.Rows.Add(dataRow4);
									base.InsertSqlDataOneRow(class2.tTC_DocOut.Rows[0]);
								}
							}
						}
					}
				}
				if (num > 0)
				{
					base.SelectSqlData(@class.tTC_DocOut, true, "where idDoc = " + num.ToString() + " and idDocOut = " + num2.ToString(), null, false, 0);
					if (@class.tTC_DocOut.Rows.Count == 0)
					{
						DataRow dataRow5 = @class.tTC_DocOut.NewRow();
						dataRow5["iddoc"] = num;
						dataRow5["iddocout"] = num2;
						@class.tTC_DocOut.Rows.Add(dataRow5);
						base.InsertSqlDataOneRow(@class.tTC_DocOut.Rows[0]);
					}
				}
				base.SelectSqlData(@class.tTC_TU, true, " where id = " + num2.ToString(), null, false, 0);
				if (@class.tTC_TU.Rows.Count > 0)
				{
					if (@class.tTC_TU.Rows[0]["PowerSum"] == DBNull.Value)
					{
						@class.tTC_TU.Rows[0]["PowerSum"] = dataRow["Мощность"];
					}
					if (@class.tTC_TU.Rows[0]["Category"] == DBNull.Value && dataRow["categor"] != DBNull.Value)
					{
						switch (Convert.ToInt32(dataRow["categor"]))
						{
						case 1:
							@class.tTC_TU.Rows[0]["Category"] = 491;
							break;
						case 2:
							@class.tTC_TU.Rows[0]["Category"] = 492;
							break;
						case 3:
							@class.tTC_TU.Rows[0]["Category"] = 493;
							break;
						}
					}
					if (@class.tTC_TU.Rows[0]["Performer"] == DBNull.Value && dataRow["IspolnitTU"] != DBNull.Value)
					{
						string a = dataRow["IspolnitTU"].ToString();
						if (!(a == "Барышникова Т.Б."))
						{
							if (!(a == "Асланова Т.С."))
							{
								if (a == "Белов А.П.")
								{
									@class.tTC_TU.Rows[0]["Performer"] = 386;
								}
							}
							else
							{
								@class.tTC_TU.Rows[0]["Performer"] = 38;
							}
						}
						else
						{
							@class.tTC_TU.Rows[0]["Performer"] = 136;
						}
					}
					@class.tTC_TU.Rows[0]["oldNameAbn"] = dataRow["Потребитель"];
					string text = "";
					if (dataRow["Улица"] != DBNull.Value)
					{
						text = dataRow["Улица"].ToString();
						if (dataRow["Prefix"] != DBNull.Value)
						{
							text = text + " " + dataRow["Prefix"].ToString();
						}
						if (dataRow["Дом"] != DBNull.Value)
						{
							text = text + ", д." + dataRow["Дом"].ToString();
						}
					}
					if (!string.IsNullOrEmpty(text))
					{
						@class.tTC_TU.Rows[0]["oldAddress"] = text;
					}
					@class.tTC_TU.Rows[0].EndEdit();
					base.UpdateSqlData(@class, @class.tTC_TU);
				}
				else
				{
					DataRow dataRow6 = @class.tTC_TU.NewRow();
					dataRow6["id"] = num2;
					dataRow6["PowerSum"] = dataRow["Мощность"];
					if (dataRow["categor"] != DBNull.Value)
					{
						switch (Convert.ToInt32(dataRow["categor"]))
						{
						case 1:
							dataRow6["Category"] = 491;
							break;
						case 2:
							dataRow6["Category"] = 492;
							break;
						case 3:
							dataRow6["Category"] = 493;
							break;
						}
					}
					if (dataRow["IspolnitTU"] != DBNull.Value)
					{
						string a = dataRow["IspolnitTU"].ToString();
						if (!(a == "Барышникова Т.Б."))
						{
							if (!(a == "Асланова Т.С."))
							{
								if (a == "Белов А.П.")
								{
									dataRow6["Performer"] = 386;
								}
							}
							else
							{
								dataRow6["Performer"] = 38;
							}
						}
						else
						{
							dataRow6["Performer"] = 136;
						}
					}
					dataRow6["oldNameAbn"] = dataRow["Потребитель"];
					string text2 = "";
					if (dataRow["Улица"] != DBNull.Value)
					{
						text2 = dataRow["Улица"].ToString();
						if (dataRow["Prefix"] != DBNull.Value)
						{
							text2 = text2 + " " + dataRow["Prefix"].ToString();
						}
						if (dataRow["Дом"] != DBNull.Value)
						{
							text2 = text2 + ", д." + dataRow["Дом"].ToString();
						}
					}
					if (!string.IsNullOrEmpty(text2))
					{
						dataRow6["oldAddress"] = text2;
					}
					@class.tTC_TU.Rows.Add(dataRow6);
					base.InsertSqlData(@class, @class.tTC_TU);
				}
				base.SelectSqlData(@class, @class.tTC_TUPointAttach, true, " where idTU = " + num2.ToString());
				if (@class.tTC_TUPointAttach.Rows.Count == 0)
				{
					int num4 = -1;
					int num5 = -1;
					int num6 = -1;
					if (dataRow["№ТП/РП"] != DBNull.Value)
					{
						System.Data.DataTable dataTable2 = base.SelectSqlData("tSchm_ObjList", true, "where name = '" + dataRow["№ТП/РП"].ToString() + "' and typeCodeId in (535,536,537,538,1034) ");
						if (dataTable2.Rows.Count > 0)
						{
							num4 = Convert.ToInt32(dataTable2.Rows[0]["id"]);
						}
					}
					if (dataRow["ЦП"] != DBNull.Value)
					{
						System.Data.DataTable dataTable3 = base.SelectSqlData("tSchm_ObjList", true, "where name like '%" + dataRow["ЦП"].ToString() + "%' and typeCodeId in (536) ");
						if (dataTable3.Rows.Count > 0)
						{
							num5 = Convert.ToInt32(dataTable3.Rows[0]["id"]);
							if (dataRow["Яч"] != DBNull.Value)
							{
								System.Data.DataTable dataTable4 = base.SelectSqlData("tSchm_ObjList", true, "where name = '" + dataRow["Яч"].ToString() + "' and typeCodeId in (678,679,676,675,674,672) and idParent = " + num5.ToString());
								if (dataTable4.Rows.Count > 0)
								{
									num6 = Convert.ToInt32(dataTable4.Rows[0]["id"]);
								}
							}
						}
					}
					if (num4 != -1 || num5 != -1 || num6 != -1)
					{
						DataRow dataRow7 = @class.tTC_TUPointAttach.NewRow();
						dataRow7["idTU"] = num2;
						dataRow7["num"] = 1;
						if (num4 != -1)
						{
							dataRow7["idsubpoint"] = num4;
						}
						if (num5 != -1)
						{
							dataRow7["idsubcp"] = num5;
						}
						if (num6 != -1)
						{
							dataRow7["idCellCP"] = num6;
						}
						@class.tTC_TUPointAttach.Rows.Add(dataRow7);
						base.InsertSqlDataOneRow(@class, @class.tTC_TUPointAttach);
					}
				}
				System.IO.FileInfo fileInfo = new System.IO.FileInfo(string.Concat(new string[]
				{
					"\\\\ulges-fs\\Work\\TU\\",
					Convert.ToDateTime(dataRow["Дата"]).Year.ToString(),
					"\\",
					Convert.ToDateTime(dataRow["Дата"]).Year.ToString(),
					dataRow["номер"].ToString(),
					".doc"
				}));
				if (fileInfo.Exists)
				{
					base.SelectSqlData(@class.tTC_DocFile, true, string.Concat(new string[]
					{
						"where idDoc = ",
						num2.ToString(),
						" and filename = '",
						fileInfo.Name,
						"'"
					}), null, false, 0);
					if (@class.tTC_DocFile.Rows.Count == 0)
					{
						DataRow dataRow8 = @class.tTC_DocFile.NewRow();
						dataRow8["idDoc"] = num2;
						dataRow8["FileName"] = fileInfo.Name;
						dataRow8["File"] = File.ReadAllBytes(fileInfo.FullName);
						dataRow8["DateChange"] = fileInfo.LastWriteTime;
						@class.tTC_DocFile.Rows.Add(dataRow8);
						base.InsertSqlDataOneRow(@class, @class.tTC_DocFile);
					}
				}
			}
		}

		private void dataGridViewExcelFilter_6_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
		{
			((DataGridView)sender).AutoResizeRow(e.RowIndex);
		}

		private void dataGridViewExcelFilter_7_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0 && e.ColumnIndex == this.dataGridViewExcelFilter_7.Columns[this.dataGridViewLinkColumn_1.Name].Index && this.dataGridViewExcelFilter_7[this.dataGridViewTextBoxColumn_56.Name, e.RowIndex].Value != DBNull.Value)
			{
				int num = Convert.ToInt32(this.dataGridViewExcelFilter_7[this.dataGridViewTextBoxColumn_56.Name, e.RowIndex].Value);
				Class10.Class12 @class = new Class10.Class12();
				base.SelectSqlData(@class, true, "where id = " + num.ToString(), null, false, 0);
				if (@class.Rows.Count > 0)
				{
					DateTime dateTime = Convert.ToDateTime(@class.Rows[0]["datedoc"]);
					this.dateTimePicker_1.Value = new DateTime(dateTime.Year, 1, 1);
					this.dateTimePicker_0.Value = new DateTime(dateTime.Year + 1, 1, 1).AddSeconds(-1.0);
					this.method_0();
					this.dataGridViewExcelFilter_0.SearchGrid(this.dataGridViewTextBoxColumn_87.Name, num.ToString(), false);
				}
			}
		}

		private void method_6()
		{
			this.treeView_0.Nodes.Clear();
			System.Data.DataTable dataTable = new System.Data.DataTable("tr_Classifier");
			dataTable.Columns.Add("id");
			dataTable.Columns.Add("name");
			base.SelectSqlData(dataTable, true, "where ParentKey = ';SCM;PS;' and isGroup = 0 and deleted = 0 order by name", null, false, 0);
			foreach (object obj in dataTable.Rows)
			{
				DataRow dataRow = (DataRow)obj;
				TreeNode treeNode = new TreeNode(dataRow["name"].ToString());
				Class10.Class57 @class = new Class10.Class57();
				base.SelectSqlData(@class, true, " where TypeCodeId = " + dataRow["id"].ToString() + " and deleted = 0 order by name", null, false, 0);
				foreach (object obj2 in @class.Rows)
				{
					DataRow dataRow2 = (DataRow)obj2;
					TreeNode treeNode2 = new TreeNode(dataRow2["TypeCode"].ToString() + "-" + dataRow2["name"].ToString());
					treeNode2.Tag = dataRow2["id"];
					treeNode.Nodes.Add(treeNode2);
					if (this.list_0 != null && this.list_0.Contains(Convert.ToInt32(dataRow2["id"])))
					{
						treeNode2.Checked = true;
						treeNode.Expand();
					}
				}
				if (treeNode.Nodes.Count > 0)
				{
					this.treeView_0.Nodes.Add(treeNode);
				}
			}
		}

		private void treeView_0_AfterCheck(object sender, TreeViewEventArgs e)
		{
			if (e.Node.Level == 0)
			{
				foreach (object obj in e.Node.Nodes)
				{
					((TreeNode)obj).Checked = e.Node.Checked;
				}
			}
		}

		private List<int> method_7(TreeNodeCollection treeNodeCollection_0)
		{
			List<int> list = new List<int>();
			if (treeNodeCollection_0 != null)
			{
				foreach (object obj in treeNodeCollection_0)
				{
					TreeNode treeNode = (TreeNode)obj;
					if (treeNode.Checked && treeNode.Tag != null)
					{
						list.Add(Convert.ToInt32(treeNode.Tag));
					}
					list.AddRange(this.method_7(treeNode.Nodes));
				}
			}
			return list;
		}

		private void method_8()
		{
			this.icontainer_0 = new Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FormJournalContract));
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
			DataGridViewCellStyle dataGridViewCellStyle18 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle19 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle20 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle21 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle22 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle23 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle24 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle25 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle26 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle27 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle28 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle29 = new DataGridViewCellStyle();
			this.toolStrip_0 = new ToolStrip();
			this.toolStripButton_0 = new ToolStripButton();
			this.toolStripButton_1 = new ToolStripButton();
			this.toolStripButton_2 = new ToolStripButton();
			this.toolStripSeparator_2 = new ToolStripSeparator();
			this.toolStripButton_9 = new ToolStripButton();
			this.toolStripSeparator_0 = new ToolStripSeparator();
			this.toolStripButton_3 = new ToolStripButton();
			this.toolStripButton_17 = new ToolStripButton();
			this.toolStripSeparator_1 = new ToolStripSeparator();
			this.toolStripButton_4 = new ToolStripButton();
			this.toolStripTextBox_0 = new ToolStripTextBox();
			this.toolStripButton_5 = new ToolStripButton();
			this.toolStripButton_6 = new ToolStripButton();
			this.toolStripButton_16 = new ToolStripButton();
			this.toolStripSeparator_3 = new ToolStripSeparator();
			this.toolStripButton_18 = new ToolStripButton();
			this.toolStripSeparator_4 = new ToolStripSeparator();
			this.toolStripButton_19 = new ToolStripButton();
			this.splitContainer_0 = new SplitContainer();
			this.treeView_0 = new TreeView();
			this.label_2 = new System.Windows.Forms.Label();
			this.dateTimePicker_0 = new DateTimePicker();
			this.label_0 = new System.Windows.Forms.Label();
			this.dateTimePicker_1 = new DateTimePicker();
			this.label_1 = new System.Windows.Forms.Label();
			this.toolStrip_1 = new ToolStrip();
			this.toolStripButton_7 = new ToolStripButton();
			this.toolStripButton_8 = new ToolStripButton();
			this.splitContainer_1 = new SplitContainer();
			this.dataGridViewExcelFilter_0 = new DataGridViewExcelFilter();
			this.tabControl_0 = new TabControl();
			this.tabPage_0 = new TabPage();
			this.dgvFile = new DataGridViewExcelFilter();
			this.dataGridViewImageColumnNotNull_0 = new DataGridViewImageColumnNotNull();
			this.tabPage_1 = new TabPage();
			this.dataGridViewExcelFilter_2 = new DataGridViewExcelFilter();
			this.tabPage_2 = new TabPage();
			this.splitContainer_3 = new SplitContainer();
			this.dataGridViewExcelFilter_5 = new DataGridViewExcelFilter();
			this.dataGridViewExcelFilter_6 = new DataGridViewExcelFilter();
			this.JpeoyahFdLp = new TabPage();
			this.splitContainer_2 = new SplitContainer();
			this.dataGridViewExcelFilter_3 = new DataGridViewExcelFilter();
			this.dataGridViewTextBoxColumn_23 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_25 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_26 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_29 = new DataGridViewTextBoxColumn();
			this.tgooyFsjvbY = new ToolStrip();
			this.toolStripButton_12 = new ToolStripButton();
			this.toolStripButton_10 = new ToolStripButton();
			this.toolStripButton_11 = new ToolStripButton();
			this.dataGridViewExcelFilter_4 = new DataGridViewExcelFilter();
			this.toolStrip_2 = new ToolStrip();
			this.toolStripButton_13 = new ToolStripButton();
			this.toolStripButton_14 = new ToolStripButton();
			this.toolStripButton_15 = new ToolStripButton();
			this.tabPage_3 = new TabPage();
			this.dataGridViewExcelFilter_7 = new DataGridViewExcelFilter();
			this.tabPage_4 = new TabPage();
			this.dataGridView_0 = new DataGridView();
			this.dataGridViewFilterDateTimePickerColumn_1 = new DataGridViewFilterDateTimePickerColumn();
			this.dataGridViewTextBoxColumn_4 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_13 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_34 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_35 = new DataGridViewTextBoxColumn();
			this.JoaoydTljgn = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_5 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_6 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_7 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_8 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_9 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_10 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_11 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_12 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_14 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_15 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_16 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_17 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_18 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_19 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_33 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_36 = new DataGridViewTextBoxColumn();
			this.oqboZoVnVe7 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_37 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_38 = new DataGridViewTextBoxColumn();
			this.bsTC_Contract = new BindingSource(this.icontainer_0);
			this.class10_0 = new Class10();
			this.dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
			this.dataGridViewLinkColumn_0 = new DataGridViewLinkColumn();
			this.dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_3 = new DataGridViewTextBoxColumn();
			this.bsTC_DocFile = new BindingSource(this.icontainer_0);
			this.dataGridViewTextBoxColumn_61 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_62 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_63 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_64 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_65 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_66 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_67 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_68 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_69 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_70 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_71 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_72 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_73 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_74 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_75 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_76 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_77 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_78 = new DataGridViewTextBoxColumn();
			this.qaooyMwseOB = new BindingSource(this.icontainer_0);
			this.dataGridViewTextBoxColumn_39 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_40 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_41 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_42 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_43 = new DataGridViewTextBoxColumn();
			this.bindingSource_4 = new BindingSource(this.icontainer_0);
			this.dataGridViewTextBoxColumn_44 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_45 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_46 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_47 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_48 = new DataGridViewTextBoxColumn();
			this.lrEoZnScroP = new BindingSource(this.icontainer_0);
			this.dataGridViewTextBoxColumn_20 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_21 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_22 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_24 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_27 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_28 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_30 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_31 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_32 = new DataGridViewTextBoxColumn();
			this.bindingSource_2 = new BindingSource(this.icontainer_0);
			this.dataGridViewTextBoxColumn_79 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_80 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_81 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_82 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_83 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_84 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_85 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_86 = new DataGridViewTextBoxColumn();
			this.bindingSource_3 = new BindingSource(this.icontainer_0);
			this.dataGridViewTextBoxColumn_49 = new DataGridViewTextBoxColumn();
			this.uFxoZadIudn = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_50 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_51 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_52 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_53 = new DataGridViewTextBoxColumn();
			this.KbboZbAmgFn = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_54 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_55 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_56 = new DataGridViewTextBoxColumn();
			this.dataGridViewLinkColumn_1 = new DataGridViewLinkColumn();
			this.bindingSource_5 = new BindingSource(this.icontainer_0);
			this.dataGridViewFilterDateTimePickerColumn_0 = new DataGridViewFilterDateTimePickerColumn();
			this.dataGridViewTextBoxColumn_57 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_58 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_59 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_60 = new DataGridViewTextBoxColumn();
			this.bindingSource_6 = new BindingSource(this.icontainer_0);
			this.class10_1 = new Class10();
			this.dataGridViewFilterTextBoxColumn_0 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewTextBoxColumn_87 = new DataGridViewTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_1 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewTextBoxColumn_88 = new DataGridViewTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_2 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_3 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewTextBoxColumn_89 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_90 = new DataGridViewTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_4 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_5 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewTextBoxColumn_91 = new DataGridViewTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_6 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewTextBoxColumn_92 = new DataGridViewTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_7 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_8 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterProgressColumn_0 = new DataGridViewFilterProgressColumn();
			this.dataGridViewFilterTextBoxColumn_9 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_10 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_11 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_12 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_13 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_14 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_15 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_16 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewCheckBoxColumn_0 = new DataGridViewCheckBoxColumn();
			this.dataGridViewTextBoxColumn_93 = new DataGridViewTextBoxColumn();
			this.toolStrip_0.SuspendLayout();
			this.splitContainer_0.Panel1.SuspendLayout();
			this.splitContainer_0.Panel2.SuspendLayout();
			this.splitContainer_0.SuspendLayout();
			this.toolStrip_1.SuspendLayout();
			this.splitContainer_1.Panel1.SuspendLayout();
			this.splitContainer_1.Panel2.SuspendLayout();
			this.splitContainer_1.SuspendLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_0).BeginInit();
			this.tabControl_0.SuspendLayout();
			this.tabPage_0.SuspendLayout();
			((ISupportInitialize)this.dgvFile).BeginInit();
			this.tabPage_1.SuspendLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_2).BeginInit();
			this.tabPage_2.SuspendLayout();
			this.splitContainer_3.Panel1.SuspendLayout();
			this.splitContainer_3.Panel2.SuspendLayout();
			this.splitContainer_3.SuspendLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_5).BeginInit();
			((ISupportInitialize)this.dataGridViewExcelFilter_6).BeginInit();
			this.JpeoyahFdLp.SuspendLayout();
			this.splitContainer_2.Panel1.SuspendLayout();
			this.splitContainer_2.Panel2.SuspendLayout();
			this.splitContainer_2.SuspendLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_3).BeginInit();
			this.tgooyFsjvbY.SuspendLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_4).BeginInit();
			this.toolStrip_2.SuspendLayout();
			this.tabPage_3.SuspendLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_7).BeginInit();
			this.tabPage_4.SuspendLayout();
			((ISupportInitialize)this.dataGridView_0).BeginInit();
			((ISupportInitialize)this.bsTC_Contract).BeginInit();
			((ISupportInitialize)this.class10_0).BeginInit();
			((ISupportInitialize)this.bsTC_DocFile).BeginInit();
			((ISupportInitialize)this.qaooyMwseOB).BeginInit();
			((ISupportInitialize)this.bindingSource_4).BeginInit();
			((ISupportInitialize)this.lrEoZnScroP).BeginInit();
			((ISupportInitialize)this.bindingSource_2).BeginInit();
			((ISupportInitialize)this.bindingSource_3).BeginInit();
			((ISupportInitialize)this.bindingSource_5).BeginInit();
			((ISupportInitialize)this.bindingSource_6).BeginInit();
			((ISupportInitialize)this.class10_1).BeginInit();
			base.SuspendLayout();
			this.toolStrip_0.GripStyle = ToolStripGripStyle.Hidden;
			this.toolStrip_0.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripButton_0,
				this.toolStripButton_1,
				this.toolStripButton_2,
				this.toolStripSeparator_2,
				this.toolStripButton_9,
				this.toolStripSeparator_0,
				this.toolStripButton_3,
				this.toolStripButton_17,
				this.toolStripSeparator_1,
				this.toolStripButton_4,
				this.toolStripTextBox_0,
				this.toolStripButton_5,
				this.toolStripButton_6,
				this.toolStripButton_16,
				this.toolStripSeparator_3,
				this.toolStripButton_18,
				this.toolStripSeparator_4,
				this.toolStripButton_19
			});
			this.toolStrip_0.Location = new System.Drawing.Point(0, 0);
			this.toolStrip_0.Name = "toolStrip";
			this.toolStrip_0.Size = new Size(964, 25);
			this.toolStrip_0.TabIndex = 0;
			this.toolStrip_0.Text = "toolStrip1";
			this.toolStripButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_0.Image = Resources.ElementAdd;
			this.toolStripButton_0.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_0.Name = "toolBtnAddTU";
			this.toolStripButton_0.Size = new Size(23, 22);
			this.toolStripButton_0.Text = "Добавить договор";
			this.toolStripButton_0.Click += this.toolStripButton_0_Click;
			this.toolStripButton_1.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_1.Image = Resources.ElementEdit;
			this.toolStripButton_1.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_1.Name = "toolBtnEditTU";
			this.toolStripButton_1.Size = new Size(23, 22);
			this.toolStripButton_1.Text = "Редактировать договор";
			this.toolStripButton_1.Click += this.toolStripButton_1_Click;
			this.toolStripButton_2.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_2.Image = Resources.ElementDel;
			this.toolStripButton_2.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_2.Name = "toolBtnDelTU";
			this.toolStripButton_2.Size = new Size(23, 22);
			this.toolStripButton_2.Text = "Удалить договор";
			this.toolStripButton_2.Click += this.toolStripButton_2_Click;
			this.toolStripSeparator_2.Name = "toolStripSeparator3";
			this.toolStripSeparator_2.Size = new Size(6, 25);
			this.toolStripButton_9.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_9.Image = Resources.refresh_16;
			this.toolStripButton_9.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_9.Name = "toolBtnRefresh";
			this.toolStripButton_9.Size = new Size(23, 22);
			this.toolStripButton_9.Text = "Обновить";
			this.toolStripButton_9.Click += this.toolStripButton_9_Click;
			this.toolStripSeparator_0.Name = "toolStripSeparator1";
			this.toolStripSeparator_0.Size = new Size(6, 25);
			this.toolStripButton_3.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_3.Image = Resources.network_connection_manager;
			this.toolStripButton_3.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_3.Name = "toolBtnShowRequest";
			this.toolStripButton_3.Size = new Size(23, 22);
			this.toolStripButton_3.Text = "Открыть заявку";
			this.toolStripButton_3.Click += this.toolStripButton_3_Click;
			this.toolStripButton_17.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_17.Image = Resources._1381484495_Terms_rev;
			this.toolStripButton_17.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_17.Name = "toolBtnShowTU";
			this.toolStripButton_17.Size = new Size(23, 22);
			this.toolStripButton_17.Text = "Открыть тех условие";
			this.toolStripButton_17.Click += this.toolStripButton_17_Click;
			this.toolStripSeparator_1.Name = "toolStripSeparator2";
			this.toolStripSeparator_1.Size = new Size(6, 25);
			this.toolStripButton_4.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_4.Image = Resources.Find;
			this.toolStripButton_4.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_4.Name = "toolBtnFind";
			this.toolStripButton_4.Size = new Size(23, 22);
			this.toolStripButton_4.Text = "Поиск";
			this.toolStripButton_4.Click += this.toolStripButton_4_Click;
			this.toolStripTextBox_0.Name = "toolTxtFind";
			this.toolStripTextBox_0.Size = new Size(100, 25);
			this.toolStripTextBox_0.ToolTipText = "Текст поиска";
			this.toolStripTextBox_0.KeyDown += this.toolStripTextBox_0_KeyDown;
			this.toolStripButton_5.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_5.Image = Resources.FindPrev;
			this.toolStripButton_5.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_5.Name = "toolBtnFindPrev";
			this.toolStripButton_5.Size = new Size(23, 22);
			this.toolStripButton_5.Text = "Поиск назад";
			this.toolStripButton_5.Click += this.qmwoCohnfwh;
			this.toolStripButton_6.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_6.Image = Resources.FindNext;
			this.toolStripButton_6.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_6.Name = "toolBtnFindNext";
			this.toolStripButton_6.Size = new Size(23, 22);
			this.toolStripButton_6.Text = "Поиск вперед";
			this.toolStripButton_6.Click += this.toolStripButton_6_Click;
			this.toolStripButton_16.Alignment = ToolStripItemAlignment.Right;
			this.toolStripButton_16.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_16.Image = (Image)componentResourceManager.GetObject("toolBtnLoadold.Image");
			this.toolStripButton_16.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_16.Name = "toolBtnLoadold";
			this.toolStripButton_16.Size = new Size(23, 22);
			this.toolStripButton_16.Text = "Загрузка из старой базы";
			this.toolStripButton_16.Click += this.toolStripButton_16_Click;
			this.toolStripSeparator_3.Name = "toolStripSeparator4";
			this.toolStripSeparator_3.Size = new Size(6, 25);
			this.toolStripButton_18.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_18.Image = Resources.microsoftoffice2007excel_7581;
			this.toolStripButton_18.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_18.Name = "toolBtnExportExcel";
			this.toolStripButton_18.Size = new Size(23, 22);
			this.toolStripButton_18.Text = "Экспорт в Excel";
			this.toolStripButton_18.Click += this.toolStripButton_18_Click;
			this.toolStripSeparator_4.Name = "toolStripSeparator5";
			this.toolStripSeparator_4.Size = new Size(6, 25);
			this.toolStripButton_19.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_19.Image = Resources.Setting;
			this.toolStripButton_19.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_19.Name = "toolBtnSettingsWord";
			this.toolStripButton_19.Size = new Size(23, 22);
			this.toolStripButton_19.Text = "Настройки для шаблона";
			this.toolStripButton_19.Click += this.toolStripButton_19_Click;
			this.splitContainer_0.Dock = DockStyle.Fill;
			this.splitContainer_0.FixedPanel = FixedPanel.Panel1;
			this.splitContainer_0.Location = new System.Drawing.Point(0, 25);
			this.splitContainer_0.Name = "splitContainerMain";
			this.splitContainer_0.Panel1.Controls.Add(this.treeView_0);
			this.splitContainer_0.Panel1.Controls.Add(this.label_2);
			this.splitContainer_0.Panel1.Controls.Add(this.dateTimePicker_0);
			this.splitContainer_0.Panel1.Controls.Add(this.label_0);
			this.splitContainer_0.Panel1.Controls.Add(this.dateTimePicker_1);
			this.splitContainer_0.Panel1.Controls.Add(this.label_1);
			this.splitContainer_0.Panel1.Controls.Add(this.toolStrip_1);
			this.splitContainer_0.Panel2.Controls.Add(this.splitContainer_1);
			this.splitContainer_0.Size = new Size(964, 497);
			this.splitContainer_0.SplitterDistance = 171;
			this.splitContainer_0.TabIndex = 2;
			this.treeView_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.treeView_0.CheckBoxes = true;
			this.treeView_0.Location = new System.Drawing.Point(0, 119);
			this.treeView_0.Name = "treeViewSubstation";
			this.treeView_0.Size = new Size(171, 378);
			this.treeView_0.TabIndex = 13;
			this.treeView_0.AfterCheck += this.treeView_0_AfterCheck;
			this.label_2.AutoSize = true;
			this.label_2.Location = new System.Drawing.Point(12, 103);
			this.label_2.Name = "label6";
			this.label_2.Size = new Size(68, 13);
			this.label_2.TabIndex = 12;
			this.label_2.Text = "Подстанции";
			this.dateTimePicker_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.dateTimePicker_0.Location = new System.Drawing.Point(12, 80);
			this.dateTimePicker_0.Name = "dateTimePickerFilterEnd";
			this.dateTimePicker_0.Size = new Size(136, 20);
			this.dateTimePicker_0.TabIndex = 9;
			this.label_0.AutoSize = true;
			this.label_0.Location = new System.Drawing.Point(12, 64);
			this.label_0.Name = "label2";
			this.label_0.Size = new Size(89, 13);
			this.label_0.TabIndex = 8;
			this.label_0.Text = "Дата окончания";
			this.dateTimePicker_1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.dateTimePicker_1.Location = new System.Drawing.Point(12, 41);
			this.dateTimePicker_1.Name = "dateTimePickerFilterBeg";
			this.dateTimePicker_1.Size = new Size(139, 20);
			this.dateTimePicker_1.TabIndex = 7;
			this.label_1.AutoSize = true;
			this.label_1.Location = new System.Drawing.Point(12, 25);
			this.label_1.Name = "label1";
			this.label_1.Size = new Size(71, 13);
			this.label_1.TabIndex = 6;
			this.label_1.Text = "Дата начала";
			this.toolStrip_1.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripButton_7,
				this.toolStripButton_8
			});
			this.toolStrip_1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip_1.Name = "toolStripFilter";
			this.toolStrip_1.Size = new Size(171, 25);
			this.toolStrip_1.TabIndex = 5;
			this.toolStrip_1.Text = "toolStrip1";
			this.toolStripButton_7.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_7.Image = Resources.filter;
			this.toolStripButton_7.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_7.Name = "toolBtnApplyFilter";
			this.toolStripButton_7.Size = new Size(23, 22);
			this.toolStripButton_7.Text = "Применить фильтр";
			this.toolStripButton_7.Click += this.toolStripButton_7_Click;
			this.toolStripButton_8.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_8.Image = Resources.filter_delete;
			this.toolStripButton_8.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_8.Name = "toolBtnClearFilter";
			this.toolStripButton_8.Size = new Size(23, 22);
			this.toolStripButton_8.Text = "Очистить фильтр";
			this.toolStripButton_8.Click += this.toolStripButton_8_Click;
			this.splitContainer_1.Dock = DockStyle.Fill;
			this.splitContainer_1.FixedPanel = FixedPanel.Panel2;
			this.splitContainer_1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer_1.Name = "splitContainer1";
			this.splitContainer_1.Orientation = Orientation.Horizontal;
			this.splitContainer_1.Panel1.Controls.Add(this.dataGridViewExcelFilter_0);
			this.splitContainer_1.Panel2.Controls.Add(this.tabControl_0);
			this.splitContainer_1.Size = new Size(789, 497);
			this.splitContainer_1.SplitterDistance = 294;
			this.splitContainer_1.TabIndex = 2;
			this.dataGridViewExcelFilter_0.AllowUserToAddRows = false;
			this.dataGridViewExcelFilter_0.AllowUserToDeleteRows = false;
			this.dataGridViewExcelFilter_0.AllowUserToOrderColumns = true;
			this.dataGridViewExcelFilter_0.AutoGenerateColumns = false;
			dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle.BackColor = SystemColors.Control;
			dataGridViewCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
			this.dataGridViewExcelFilter_0.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
			this.dataGridViewExcelFilter_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewExcelFilter_0.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewFilterTextBoxColumn_0,
				this.dataGridViewTextBoxColumn_87,
				this.dataGridViewFilterTextBoxColumn_1,
				this.dataGridViewTextBoxColumn_88,
				this.dataGridViewFilterTextBoxColumn_2,
				this.dataGridViewFilterTextBoxColumn_3,
				this.dataGridViewTextBoxColumn_89,
				this.dataGridViewTextBoxColumn_90,
				this.dataGridViewFilterTextBoxColumn_4,
				this.dataGridViewFilterTextBoxColumn_5,
				this.dataGridViewTextBoxColumn_91,
				this.dataGridViewFilterTextBoxColumn_6,
				this.dataGridViewTextBoxColumn_92,
				this.dataGridViewFilterTextBoxColumn_7,
				this.dataGridViewFilterTextBoxColumn_8,
				this.dataGridViewFilterProgressColumn_0,
				this.dataGridViewFilterTextBoxColumn_9,
				this.dataGridViewFilterTextBoxColumn_10,
				this.dataGridViewFilterTextBoxColumn_11,
				this.dataGridViewFilterTextBoxColumn_12,
				this.dataGridViewFilterTextBoxColumn_13,
				this.dataGridViewFilterTextBoxColumn_14,
				this.dataGridViewFilterTextBoxColumn_15,
				this.dataGridViewFilterTextBoxColumn_16,
				this.dataGridViewCheckBoxColumn_0,
				this.dataGridViewTextBoxColumn_93
			});
			this.dataGridViewExcelFilter_0.DataSource = this.bsTC_Contract;
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
			this.dataGridViewExcelFilter_0.DefaultCellStyle = dataGridViewCellStyle2;
			this.dataGridViewExcelFilter_0.Dock = DockStyle.Fill;
			this.dataGridViewExcelFilter_0.Location = new System.Drawing.Point(0, 0);
			this.dataGridViewExcelFilter_0.Name = "dgvContract";
			this.dataGridViewExcelFilter_0.ReadOnly = true;
			this.dataGridViewExcelFilter_0.Size = new Size(789, 294);
			this.dataGridViewExcelFilter_0.TabIndex = 1;
			this.dataGridViewExcelFilter_0.VirtualMode = true;
			this.dataGridViewExcelFilter_0.CellDoubleClick += this.dataGridViewExcelFilter_0_CellDoubleClick;
			this.dataGridViewExcelFilter_0.CellFormatting += this.dataGridViewExcelFilter_0_CellFormatting;
			this.dataGridViewExcelFilter_0.CellPainting += this.dataGridViewExcelFilter_0_CellPainting;
			this.dataGridViewExcelFilter_0.RowPostPaint += this.dataGridViewExcelFilter_0_RowPostPaint;
			this.dataGridViewExcelFilter_0.RowsAdded += this.dataGridViewExcelFilter_0_RowsAdded;
			this.tabControl_0.Controls.Add(this.tabPage_0);
			this.tabControl_0.Controls.Add(this.tabPage_1);
			this.tabControl_0.Controls.Add(this.tabPage_2);
			this.tabControl_0.Controls.Add(this.JpeoyahFdLp);
			this.tabControl_0.Controls.Add(this.tabPage_3);
			this.tabControl_0.Controls.Add(this.tabPage_4);
			this.tabControl_0.Dock = DockStyle.Fill;
			this.tabControl_0.Location = new System.Drawing.Point(0, 0);
			this.tabControl_0.Name = "tabControl";
			this.tabControl_0.SelectedIndex = 0;
			this.tabControl_0.Size = new Size(789, 199);
			this.tabControl_0.TabIndex = 0;
			this.tabPage_0.Controls.Add(this.dgvFile);
			this.tabPage_0.Location = new System.Drawing.Point(4, 22);
			this.tabPage_0.Name = "tabPageFiles";
			this.tabPage_0.Padding = new Padding(3);
			this.tabPage_0.Size = new Size(781, 173);
			this.tabPage_0.TabIndex = 0;
			this.tabPage_0.Text = "Файлы";
			this.tabPage_0.UseVisualStyleBackColor = true;
			this.dgvFile.AllowUserToAddRows = false;
			this.dgvFile.AllowUserToDeleteRows = false;
			this.dgvFile.AllowUserToResizeColumns = false;
			this.dgvFile.AllowUserToResizeRows = false;
			this.dgvFile.AutoGenerateColumns = false;
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = SystemColors.Control;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
			this.dgvFile.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.dgvFile.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvFile.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewImageColumnNotNull_0,
				this.dataGridViewTextBoxColumn_0,
				this.dataGridViewTextBoxColumn_1,
				this.dataGridViewLinkColumn_0,
				this.dataGridViewTextBoxColumn_2,
				this.dataGridViewTextBoxColumn_3
			});
			this.dgvFile.DataSource = this.bsTC_DocFile;
			dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = SystemColors.Window;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
			this.dgvFile.DefaultCellStyle = dataGridViewCellStyle4;
			this.dgvFile.Dock = DockStyle.Fill;
			this.dgvFile.EditMode = DataGridViewEditMode.EditProgrammatically;
			this.dgvFile.Location = new System.Drawing.Point(3, 3);
			this.dgvFile.Name = "dgvFile";
			this.dgvFile.ReadOnly = true;
			this.dgvFile.RowHeadersVisible = false;
			this.dgvFile.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dgvFile.Size = new Size(775, 167);
			this.dgvFile.TabIndex = 7;
			this.dgvFile.VirtualMode = true;
			this.dgvFile.CellContentClick += this.dgvFile_CellContentClick;
			this.dgvFile.CellValueNeeded += this.dataGridViewExcelFilter_1_CellValueNeeded;
			dataGridViewCellStyle5.NullValue = null;
			this.dataGridViewImageColumnNotNull_0.DefaultCellStyle = dataGridViewCellStyle5;
			this.dataGridViewImageColumnNotNull_0.HeaderText = "";
			this.dataGridViewImageColumnNotNull_0.ImageLayout = DataGridViewImageCellLayout.Zoom;
			this.dataGridViewImageColumnNotNull_0.Name = "imageDgvColumn";
			this.dataGridViewImageColumnNotNull_0.ReadOnly = true;
			this.dataGridViewImageColumnNotNull_0.Width = 30;
			this.tabPage_1.Controls.Add(this.dataGridViewExcelFilter_2);
			this.tabPage_1.Location = new System.Drawing.Point(4, 22);
			this.tabPage_1.Name = "tabPageRequestHistory";
			this.tabPage_1.Padding = new Padding(3);
			this.tabPage_1.Size = new Size(781, 173);
			this.tabPage_1.TabIndex = 1;
			this.tabPage_1.Text = "История заявок";
			this.tabPage_1.UseVisualStyleBackColor = true;
			this.dataGridViewExcelFilter_2.AllowUserToAddRows = false;
			this.dataGridViewExcelFilter_2.AllowUserToDeleteRows = false;
			this.dataGridViewExcelFilter_2.AutoGenerateColumns = false;
			dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle6.BackColor = SystemColors.Control;
			dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
			this.dataGridViewExcelFilter_2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
			this.dataGridViewExcelFilter_2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewExcelFilter_2.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewTextBoxColumn_61,
				this.dataGridViewTextBoxColumn_62,
				this.dataGridViewTextBoxColumn_63,
				this.dataGridViewTextBoxColumn_64,
				this.dataGridViewTextBoxColumn_65,
				this.dataGridViewTextBoxColumn_66,
				this.dataGridViewTextBoxColumn_67,
				this.dataGridViewTextBoxColumn_68,
				this.dataGridViewTextBoxColumn_69,
				this.dataGridViewTextBoxColumn_70,
				this.dataGridViewTextBoxColumn_71,
				this.dataGridViewTextBoxColumn_72,
				this.dataGridViewTextBoxColumn_73,
				this.dataGridViewTextBoxColumn_74,
				this.dataGridViewTextBoxColumn_75,
				this.dataGridViewTextBoxColumn_76,
				this.dataGridViewTextBoxColumn_77,
				this.dataGridViewTextBoxColumn_78
			});
			this.dataGridViewExcelFilter_2.DataSource = this.qaooyMwseOB;
			dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle7.BackColor = SystemColors.Window;
			dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle7.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
			this.dataGridViewExcelFilter_2.DefaultCellStyle = dataGridViewCellStyle7;
			this.dataGridViewExcelFilter_2.Dock = DockStyle.Fill;
			this.dataGridViewExcelFilter_2.Location = new System.Drawing.Point(3, 3);
			this.dataGridViewExcelFilter_2.MultiSelect = false;
			this.dataGridViewExcelFilter_2.Name = "dgvRequestHistory";
			this.dataGridViewExcelFilter_2.ReadOnly = true;
			this.dataGridViewExcelFilter_2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewExcelFilter_2.Size = new Size(775, 167);
			this.dataGridViewExcelFilter_2.TabIndex = 4;
			this.dataGridViewExcelFilter_2.VirtualMode = true;
			this.dataGridViewExcelFilter_2.CellFormatting += this.dataGridViewExcelFilter_2_CellFormatting;
			this.dataGridViewExcelFilter_2.RowPostPaint += this.dataGridViewExcelFilter_2_RowPostPaint;
			this.tabPage_2.Controls.Add(this.splitContainer_3);
			this.tabPage_2.Location = new System.Drawing.Point(4, 22);
			this.tabPage_2.Name = "tabPageTypeWork";
			this.tabPage_2.Size = new Size(781, 173);
			this.tabPage_2.TabIndex = 3;
			this.tabPage_2.Text = "Вид работ";
			this.tabPage_2.UseVisualStyleBackColor = true;
			this.splitContainer_3.Dock = DockStyle.Fill;
			this.splitContainer_3.Location = new System.Drawing.Point(0, 0);
			this.splitContainer_3.Name = "splitContainer2";
			this.splitContainer_3.Panel1.Controls.Add(this.dataGridViewExcelFilter_5);
			this.splitContainer_3.Panel2.Controls.Add(this.dataGridViewExcelFilter_6);
			this.splitContainer_3.Size = new Size(781, 173);
			this.splitContainer_3.SplitterDistance = 366;
			this.splitContainer_3.TabIndex = 0;
			this.dataGridViewExcelFilter_5.AllowUserToAddRows = false;
			this.dataGridViewExcelFilter_5.AllowUserToDeleteRows = false;
			this.dataGridViewExcelFilter_5.AutoGenerateColumns = false;
			this.dataGridViewExcelFilter_5.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewExcelFilter_5.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewTextBoxColumn_39,
				this.dataGridViewTextBoxColumn_40,
				this.dataGridViewTextBoxColumn_41,
				this.dataGridViewTextBoxColumn_42,
				this.dataGridViewTextBoxColumn_43
			});
			this.dataGridViewExcelFilter_5.DataSource = this.bindingSource_4;
			this.dataGridViewExcelFilter_5.Dock = DockStyle.Fill;
			this.dataGridViewExcelFilter_5.Location = new System.Drawing.Point(0, 0);
			this.dataGridViewExcelFilter_5.Name = "dgvNetWork";
			this.dataGridViewExcelFilter_5.ReadOnly = true;
			this.dataGridViewExcelFilter_5.RowHeadersWidth = 21;
			this.dataGridViewExcelFilter_5.Size = new Size(366, 173);
			this.dataGridViewExcelFilter_5.TabIndex = 2;
			this.dataGridViewExcelFilter_5.RowPostPaint += this.dataGridViewExcelFilter_6_RowPostPaint;
			this.dataGridViewExcelFilter_6.AllowUserToAddRows = false;
			this.dataGridViewExcelFilter_6.AllowUserToDeleteRows = false;
			this.dataGridViewExcelFilter_6.AutoGenerateColumns = false;
			this.dataGridViewExcelFilter_6.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewExcelFilter_6.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewTextBoxColumn_44,
				this.dataGridViewTextBoxColumn_45,
				this.dataGridViewTextBoxColumn_46,
				this.dataGridViewTextBoxColumn_47,
				this.dataGridViewTextBoxColumn_48
			});
			this.dataGridViewExcelFilter_6.DataSource = this.lrEoZnScroP;
			this.dataGridViewExcelFilter_6.Dock = DockStyle.Fill;
			this.dataGridViewExcelFilter_6.Location = new System.Drawing.Point(0, 0);
			this.dataGridViewExcelFilter_6.Name = "dgvClientWork";
			this.dataGridViewExcelFilter_6.ReadOnly = true;
			this.dataGridViewExcelFilter_6.RowHeadersWidth = 21;
			this.dataGridViewExcelFilter_6.Size = new Size(411, 173);
			this.dataGridViewExcelFilter_6.TabIndex = 3;
			this.dataGridViewExcelFilter_6.RowPostPaint += this.dataGridViewExcelFilter_6_RowPostPaint;
			this.JpeoyahFdLp.Controls.Add(this.splitContainer_2);
			this.JpeoyahFdLp.Location = new System.Drawing.Point(4, 22);
			this.JpeoyahFdLp.Name = "tabPageDocOut";
			this.JpeoyahFdLp.Padding = new Padding(3);
			this.JpeoyahFdLp.Size = new Size(781, 173);
			this.JpeoyahFdLp.TabIndex = 2;
			this.JpeoyahFdLp.Text = "Выданные документы";
			this.JpeoyahFdLp.UseVisualStyleBackColor = true;
			this.splitContainer_2.Dock = DockStyle.Fill;
			this.splitContainer_2.Location = new System.Drawing.Point(3, 3);
			this.splitContainer_2.Name = "splitContainerDocOut";
			this.splitContainer_2.Panel1.Controls.Add(this.dataGridViewExcelFilter_3);
			this.splitContainer_2.Panel1.Controls.Add(this.tgooyFsjvbY);
			this.splitContainer_2.Panel2.Controls.Add(this.dataGridViewExcelFilter_4);
			this.splitContainer_2.Panel2.Controls.Add(this.toolStrip_2);
			this.splitContainer_2.Size = new Size(775, 167);
			this.splitContainer_2.SplitterDistance = 416;
			this.splitContainer_2.TabIndex = 0;
			this.dataGridViewExcelFilter_3.AllowUserToAddRows = false;
			this.dataGridViewExcelFilter_3.AllowUserToDeleteRows = false;
			this.dataGridViewExcelFilter_3.AllowUserToOrderColumns = true;
			this.dataGridViewExcelFilter_3.AllowUserToVisibleColumns = false;
			this.dataGridViewExcelFilter_3.AutoGenerateColumns = false;
			dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle8.BackColor = SystemColors.Control;
			dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle8.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
			this.dataGridViewExcelFilter_3.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
			this.dataGridViewExcelFilter_3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewExcelFilter_3.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewTextBoxColumn_20,
				this.dataGridViewTextBoxColumn_21,
				this.dataGridViewTextBoxColumn_22,
				this.dataGridViewTextBoxColumn_23,
				this.dataGridViewTextBoxColumn_24,
				this.dataGridViewTextBoxColumn_25,
				this.dataGridViewTextBoxColumn_26,
				this.dataGridViewTextBoxColumn_27,
				this.dataGridViewTextBoxColumn_28,
				this.dataGridViewTextBoxColumn_29,
				this.dataGridViewTextBoxColumn_30,
				this.dataGridViewTextBoxColumn_31,
				this.dataGridViewTextBoxColumn_32
			});
			this.dataGridViewExcelFilter_3.DataSource = this.bindingSource_2;
			dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle9.BackColor = SystemColors.Window;
			dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle9.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle9.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle9.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle9.WrapMode = DataGridViewTriState.False;
			this.dataGridViewExcelFilter_3.DefaultCellStyle = dataGridViewCellStyle9;
			this.dataGridViewExcelFilter_3.Dock = DockStyle.Fill;
			this.dataGridViewExcelFilter_3.Location = new System.Drawing.Point(24, 0);
			this.dataGridViewExcelFilter_3.Name = "dgvDocOut";
			this.dataGridViewExcelFilter_3.ReadOnly = true;
			this.dataGridViewExcelFilter_3.RowHeadersWidth = 21;
			this.dataGridViewExcelFilter_3.Size = new Size(392, 167);
			this.dataGridViewExcelFilter_3.TabIndex = 3;
			this.dataGridViewExcelFilter_3.VirtualMode = true;
			this.dataGridViewExcelFilter_3.CellFormatting += this.dataGridViewExcelFilter_3_CellFormatting;
			this.dataGridViewTextBoxColumn_23.DataPropertyName = "idDoc";
			this.dataGridViewTextBoxColumn_23.HeaderText = "idDoc";
			this.dataGridViewTextBoxColumn_23.Name = "idDocDgvColumn";
			this.dataGridViewTextBoxColumn_23.ReadOnly = true;
			this.dataGridViewTextBoxColumn_23.Visible = false;
			this.dataGridViewTextBoxColumn_25.DataPropertyName = "TypeDocOut";
			this.dataGridViewTextBoxColumn_25.HeaderText = "TypeDocOut";
			this.dataGridViewTextBoxColumn_25.Name = "typeDocOutDgvColumn";
			this.dataGridViewTextBoxColumn_25.ReadOnly = true;
			this.dataGridViewTextBoxColumn_25.Visible = false;
			this.dataGridViewTextBoxColumn_26.DataPropertyName = "idDocOut";
			this.dataGridViewTextBoxColumn_26.HeaderText = "idDocOut";
			this.dataGridViewTextBoxColumn_26.Name = "idDocOutDgvColumn";
			this.dataGridViewTextBoxColumn_26.ReadOnly = true;
			this.dataGridViewTextBoxColumn_26.Visible = false;
			this.dataGridViewTextBoxColumn_29.DataPropertyName = "BodyDocOut";
			this.dataGridViewTextBoxColumn_29.HeaderText = "Содержание";
			this.dataGridViewTextBoxColumn_29.Name = "bodyDocOutDgvColumn";
			this.dataGridViewTextBoxColumn_29.ReadOnly = true;
			this.tgooyFsjvbY.Dock = DockStyle.Left;
			this.tgooyFsjvbY.GripStyle = ToolStripGripStyle.Hidden;
			this.tgooyFsjvbY.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripButton_12,
				this.toolStripButton_10,
				this.toolStripButton_11
			});
			this.tgooyFsjvbY.Location = new System.Drawing.Point(0, 0);
			this.tgooyFsjvbY.Name = "toolStripDocOut";
			this.tgooyFsjvbY.Size = new Size(24, 167);
			this.tgooyFsjvbY.TabIndex = 2;
			this.tgooyFsjvbY.Text = "toolStrip1";
			this.toolStripButton_12.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_12.Image = Resources.ElementAdd;
			this.toolStripButton_12.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_12.Name = "toolBtnAddDocOut";
			this.toolStripButton_12.Size = new Size(21, 20);
			this.toolStripButton_12.Text = "Новый документ";
			this.toolStripButton_12.Click += this.toolStripButton_12_Click;
			this.toolStripButton_10.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_10.Image = Resources.ElementEdit;
			this.toolStripButton_10.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_10.Name = "toolBtnEditDocOut";
			this.toolStripButton_10.Size = new Size(21, 20);
			this.toolStripButton_10.Text = "Редактировать документ";
			this.toolStripButton_10.Click += this.toolStripButton_10_Click;
			this.toolStripButton_11.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_11.Image = Resources.ElementDel;
			this.toolStripButton_11.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_11.Name = "toolBtnDelDocOut";
			this.toolStripButton_11.Size = new Size(21, 20);
			this.toolStripButton_11.Text = "Удалить документ";
			this.toolStripButton_11.Click += this.toolStripButton_11_Click;
			this.dataGridViewExcelFilter_4.AllowUserToAddRows = false;
			this.dataGridViewExcelFilter_4.AllowUserToDeleteRows = false;
			this.dataGridViewExcelFilter_4.AllowUserToOrderColumns = true;
			this.dataGridViewExcelFilter_4.AllowUserToVisibleColumns = false;
			this.dataGridViewExcelFilter_4.AutoGenerateColumns = false;
			dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle10.BackColor = SystemColors.Control;
			dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle10.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle10.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle10.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle10.WrapMode = DataGridViewTriState.True;
			this.dataGridViewExcelFilter_4.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
			this.dataGridViewExcelFilter_4.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewExcelFilter_4.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewTextBoxColumn_79,
				this.dataGridViewTextBoxColumn_80,
				this.dataGridViewTextBoxColumn_81,
				this.dataGridViewTextBoxColumn_82,
				this.dataGridViewTextBoxColumn_83,
				this.dataGridViewTextBoxColumn_84,
				this.dataGridViewTextBoxColumn_85,
				this.dataGridViewTextBoxColumn_86
			});
			this.dataGridViewExcelFilter_4.DataSource = this.bindingSource_3;
			dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle11.BackColor = SystemColors.Window;
			dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle11.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle11.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle11.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle11.WrapMode = DataGridViewTriState.False;
			this.dataGridViewExcelFilter_4.DefaultCellStyle = dataGridViewCellStyle11;
			this.dataGridViewExcelFilter_4.Dock = DockStyle.Fill;
			this.dataGridViewExcelFilter_4.Location = new System.Drawing.Point(0, 25);
			this.dataGridViewExcelFilter_4.Name = "dgvDocOutStatus";
			this.dataGridViewExcelFilter_4.ReadOnly = true;
			this.dataGridViewExcelFilter_4.RowHeadersVisible = false;
			this.dataGridViewExcelFilter_4.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewExcelFilter_4.Size = new Size(355, 142);
			this.dataGridViewExcelFilter_4.TabIndex = 3;
			this.toolStrip_2.GripStyle = ToolStripGripStyle.Hidden;
			this.toolStrip_2.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripButton_13,
				this.toolStripButton_14,
				this.toolStripButton_15
			});
			this.toolStrip_2.Location = new System.Drawing.Point(0, 0);
			this.toolStrip_2.Name = "toolStripDocOutStatus";
			this.toolStrip_2.Size = new Size(355, 25);
			this.toolStrip_2.TabIndex = 2;
			this.toolStrip_2.Text = "toolStrip1";
			this.toolStripButton_13.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_13.Image = Resources.ElementAdd;
			this.toolStripButton_13.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_13.Name = "toolBtnAddDocOutStatus";
			this.toolStripButton_13.Size = new Size(23, 22);
			this.toolStripButton_13.Text = "Новый статус";
			this.toolStripButton_13.Click += this.toolStripButton_13_Click;
			this.toolStripButton_14.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_14.Image = Resources.ElementEdit;
			this.toolStripButton_14.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_14.Name = "toolBtnEditDocOutStatus";
			this.toolStripButton_14.Size = new Size(23, 22);
			this.toolStripButton_14.Text = "Редактировать статус";
			this.toolStripButton_14.Click += this.toolStripButton_14_Click;
			this.toolStripButton_15.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_15.Image = Resources.ElementDel;
			this.toolStripButton_15.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_15.Name = "toolBtnDelDocOutStatus";
			this.toolStripButton_15.Size = new Size(23, 22);
			this.toolStripButton_15.Text = "Удалить статус";
			this.toolStripButton_15.Click += this.toolStripButton_15_Click;
			this.tabPage_3.Controls.Add(this.dataGridViewExcelFilter_7);
			this.tabPage_3.Location = new System.Drawing.Point(4, 22);
			this.tabPage_3.Name = "tabPagePayment";
			this.tabPage_3.Padding = new Padding(3);
			this.tabPage_3.Size = new Size(781, 173);
			this.tabPage_3.TabIndex = 4;
			this.tabPage_3.Text = "Платежи";
			this.tabPage_3.UseVisualStyleBackColor = true;
			this.dataGridViewExcelFilter_7.AllowUserToAddRows = false;
			this.dataGridViewExcelFilter_7.AllowUserToDeleteRows = false;
			this.dataGridViewExcelFilter_7.AutoGenerateColumns = false;
			this.dataGridViewExcelFilter_7.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewExcelFilter_7.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewTextBoxColumn_49,
				this.uFxoZadIudn,
				this.dataGridViewTextBoxColumn_50,
				this.dataGridViewTextBoxColumn_51,
				this.dataGridViewTextBoxColumn_52,
				this.dataGridViewTextBoxColumn_53,
				this.KbboZbAmgFn,
				this.dataGridViewTextBoxColumn_54,
				this.dataGridViewTextBoxColumn_55,
				this.dataGridViewTextBoxColumn_56,
				this.dataGridViewLinkColumn_1
			});
			this.dataGridViewExcelFilter_7.DataSource = this.bindingSource_5;
			this.dataGridViewExcelFilter_7.Dock = DockStyle.Fill;
			this.dataGridViewExcelFilter_7.Location = new System.Drawing.Point(3, 3);
			this.dataGridViewExcelFilter_7.Name = "dgvPayment";
			this.dataGridViewExcelFilter_7.ReadOnly = true;
			this.dataGridViewExcelFilter_7.RowHeadersWidth = 21;
			this.dataGridViewExcelFilter_7.Size = new Size(775, 167);
			this.dataGridViewExcelFilter_7.TabIndex = 0;
			this.dataGridViewExcelFilter_7.CellContentClick += this.dataGridViewExcelFilter_7_CellContentClick;
			this.tabPage_4.Controls.Add(this.dataGridView_0);
			this.tabPage_4.Location = new System.Drawing.Point(4, 22);
			this.tabPage_4.Name = "tabPagePaymentShedule";
			this.tabPage_4.Padding = new Padding(3);
			this.tabPage_4.Size = new Size(781, 173);
			this.tabPage_4.TabIndex = 5;
			this.tabPage_4.Text = "График платежей";
			this.tabPage_4.UseVisualStyleBackColor = true;
			this.dataGridView_0.AllowUserToAddRows = false;
			this.dataGridView_0.AllowUserToDeleteRows = false;
			this.dataGridView_0.AutoGenerateColumns = false;
			this.dataGridView_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView_0.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewFilterDateTimePickerColumn_0,
				this.dataGridViewTextBoxColumn_57,
				this.dataGridViewTextBoxColumn_58,
				this.dataGridViewTextBoxColumn_59,
				this.dataGridViewTextBoxColumn_60
			});
			this.dataGridView_0.DataSource = this.bindingSource_6;
			this.dataGridView_0.Dock = DockStyle.Fill;
			this.dataGridView_0.Location = new System.Drawing.Point(3, 3);
			this.dataGridView_0.Name = "dgvPaymentShedule";
			this.dataGridView_0.ReadOnly = true;
			this.dataGridView_0.Size = new Size(775, 167);
			this.dataGridView_0.TabIndex = 3;
			this.dataGridViewFilterDateTimePickerColumn_1.DataPropertyName = "DateShedule";
			dataGridViewCellStyle12.Format = "d";
			dataGridViewCellStyle12.NullValue = null;
			this.dataGridViewFilterDateTimePickerColumn_1.DefaultCellStyle = dataGridViewCellStyle12;
			this.dataGridViewFilterDateTimePickerColumn_1.HeaderText = "Дата";
			this.dataGridViewFilterDateTimePickerColumn_1.Name = "dataGridViewFilterDateTimePickerColumn1";
			this.dataGridViewFilterDateTimePickerColumn_1.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterDateTimePickerColumn_1.SortMode = DataGridViewColumnSortMode.Automatic;
			this.dataGridViewTextBoxColumn_4.DataPropertyName = "numDateIn";
			dataGridViewCellStyle13.WrapMode = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_4.DefaultCellStyle = dataGridViewCellStyle13;
			this.dataGridViewTextBoxColumn_4.HeaderText = "№, дата вход.";
			this.dataGridViewTextBoxColumn_4.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_4.ReadOnly = true;
			this.dataGridViewTextBoxColumn_4.Visible = false;
			this.dataGridViewTextBoxColumn_4.Width = 80;
			this.dataGridViewTextBoxColumn_13.DataPropertyName = "PowerAdd";
			this.dataGridViewTextBoxColumn_13.HeaderText = "Доп мощность";
			this.dataGridViewTextBoxColumn_13.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn_13.ReadOnly = true;
			this.dataGridViewTextBoxColumn_13.Visible = false;
			this.dataGridViewTextBoxColumn_13.Width = 70;
			this.dataGridViewTextBoxColumn_34.DataPropertyName = "idDoc";
			dataGridViewCellStyle14.Format = "N2";
			dataGridViewCellStyle14.NullValue = null;
			this.dataGridViewTextBoxColumn_34.DefaultCellStyle = dataGridViewCellStyle14;
			this.dataGridViewTextBoxColumn_34.HeaderText = "idDoc";
			this.dataGridViewTextBoxColumn_34.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn_34.ReadOnly = true;
			this.dataGridViewTextBoxColumn_34.Resizable = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_34.Visible = false;
			this.dataGridViewTextBoxColumn_35.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_35.DataPropertyName = "idStatus";
			this.dataGridViewTextBoxColumn_35.HeaderText = "idStatus";
			this.dataGridViewTextBoxColumn_35.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn_35.ReadOnly = true;
			this.dataGridViewTextBoxColumn_35.Visible = false;
			this.JoaoydTljgn.DataPropertyName = "numDoc";
			this.JoaoydTljgn.HeaderText = "numDoc";
			this.JoaoydTljgn.Name = "numDocDataGridViewTextBoxColumn1";
			this.JoaoydTljgn.ReadOnly = true;
			this.JoaoydTljgn.Visible = false;
			this.dataGridViewTextBoxColumn_5.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_5.HeaderText = "id";
			this.dataGridViewTextBoxColumn_5.Name = "idRequestHistoryDgvColumn";
			this.dataGridViewTextBoxColumn_5.ReadOnly = true;
			this.dataGridViewTextBoxColumn_5.Visible = false;
			this.dataGridViewTextBoxColumn_6.DataPropertyName = "dateDoc";
			this.dataGridViewTextBoxColumn_6.HeaderText = "Дата получения";
			this.dataGridViewTextBoxColumn_6.Name = "dateDocDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_6.ReadOnly = true;
			this.dataGridViewTextBoxColumn_6.Width = 80;
			this.dataGridViewTextBoxColumn_7.DataPropertyName = "numIn";
			this.dataGridViewTextBoxColumn_7.HeaderText = "numIn";
			this.dataGridViewTextBoxColumn_7.Name = "numInDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_7.ReadOnly = true;
			this.dataGridViewTextBoxColumn_7.Visible = false;
			this.dataGridViewTextBoxColumn_8.DataPropertyName = "dateIn";
			this.dataGridViewTextBoxColumn_8.HeaderText = "dateIn";
			this.dataGridViewTextBoxColumn_8.Name = "dateInDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_8.ReadOnly = true;
			this.dataGridViewTextBoxColumn_8.Visible = false;
			this.dataGridViewTextBoxColumn_9.DataPropertyName = "idAbn";
			this.dataGridViewTextBoxColumn_9.HeaderText = "idAbn";
			this.dataGridViewTextBoxColumn_9.Name = "idAbnDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_9.ReadOnly = true;
			this.dataGridViewTextBoxColumn_9.Visible = false;
			this.dataGridViewTextBoxColumn_10.DataPropertyName = "idAbnObj";
			this.dataGridViewTextBoxColumn_10.HeaderText = "idAbnObj";
			this.dataGridViewTextBoxColumn_10.Name = "idAbnObjDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_10.ReadOnly = true;
			this.dataGridViewTextBoxColumn_10.Visible = false;
			this.dataGridViewTextBoxColumn_11.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_11.DataPropertyName = "body";
			dataGridViewCellStyle15.WrapMode = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_11.DefaultCellStyle = dataGridViewCellStyle15;
			this.dataGridViewTextBoxColumn_11.HeaderText = "Тело письма";
			this.dataGridViewTextBoxColumn_11.Name = "bodyDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_11.ReadOnly = true;
			this.dataGridViewTextBoxColumn_12.DataPropertyName = "PowerCurrent";
			this.dataGridViewTextBoxColumn_12.HeaderText = "Текущая мощность";
			this.dataGridViewTextBoxColumn_12.Name = "powerCurrentDgvColumn";
			this.dataGridViewTextBoxColumn_12.ReadOnly = true;
			this.dataGridViewTextBoxColumn_12.Width = 70;
			this.dataGridViewTextBoxColumn_14.DataPropertyName = "Power";
			this.dataGridViewTextBoxColumn_14.HeaderText = "Суммарная мощность";
			this.dataGridViewTextBoxColumn_14.Name = "powerDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_14.ReadOnly = true;
			this.dataGridViewTextBoxColumn_14.Width = 70;
			this.dataGridViewTextBoxColumn_15.DataPropertyName = "VoltageName";
			this.dataGridViewTextBoxColumn_15.HeaderText = "Напряжение";
			this.dataGridViewTextBoxColumn_15.Name = "voltageNameDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_15.ReadOnly = true;
			this.dataGridViewTextBoxColumn_15.Width = 70;
			this.dataGridViewTextBoxColumn_16.DataPropertyName = "Comment";
			this.dataGridViewTextBoxColumn_16.HeaderText = "Комментарий";
			this.dataGridViewTextBoxColumn_16.Name = "commentDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_16.ReadOnly = true;
			this.dataGridViewTextBoxColumn_16.Width = 70;
			this.dataGridViewTextBoxColumn_17.DataPropertyName = "VoltageLevel";
			this.dataGridViewTextBoxColumn_17.HeaderText = "VoltageLevel";
			this.dataGridViewTextBoxColumn_17.Name = "voltageLevelDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_17.ReadOnly = true;
			this.dataGridViewTextBoxColumn_17.Visible = false;
			this.dataGridViewTextBoxColumn_18.DataPropertyName = "VoltageValue";
			this.dataGridViewTextBoxColumn_18.HeaderText = "VoltageValue";
			this.dataGridViewTextBoxColumn_18.Name = "voltageValueDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_18.ReadOnly = true;
			this.dataGridViewTextBoxColumn_18.Visible = false;
			this.dataGridViewTextBoxColumn_19.DataPropertyName = "IdParent";
			this.dataGridViewTextBoxColumn_19.HeaderText = "IdParent";
			this.dataGridViewTextBoxColumn_19.Name = "idParentDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_19.ReadOnly = true;
			this.dataGridViewTextBoxColumn_19.Visible = false;
			this.dataGridViewTextBoxColumn_33.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_33.HeaderText = "id";
			this.dataGridViewTextBoxColumn_33.Name = "idStatusDocOutDgvColumn";
			this.dataGridViewTextBoxColumn_33.ReadOnly = true;
			this.dataGridViewTextBoxColumn_33.Visible = false;
			this.dataGridViewTextBoxColumn_36.DataPropertyName = "statusName";
			this.dataGridViewTextBoxColumn_36.HeaderText = "Статус";
			this.dataGridViewTextBoxColumn_36.Name = "dataGridViewTextBoxColumn5";
			this.dataGridViewTextBoxColumn_36.ReadOnly = true;
			this.dataGridViewTextBoxColumn_36.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.oqboZoVnVe7.DataPropertyName = "DateChange";
			dataGridViewCellStyle16.Format = "d";
			dataGridViewCellStyle16.NullValue = null;
			this.oqboZoVnVe7.DefaultCellStyle = dataGridViewCellStyle16;
			this.oqboZoVnVe7.HeaderText = "Дата";
			this.oqboZoVnVe7.Name = "dataGridViewTextBoxColumn6";
			this.oqboZoVnVe7.ReadOnly = true;
			this.oqboZoVnVe7.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.oqboZoVnVe7.Width = 70;
			this.dataGridViewTextBoxColumn_37.DataPropertyName = "SendName";
			this.dataGridViewTextBoxColumn_37.HeaderText = "Способ отправки";
			this.dataGridViewTextBoxColumn_37.Name = "sendNameDgvColumn";
			this.dataGridViewTextBoxColumn_37.ReadOnly = true;
			this.dataGridViewTextBoxColumn_38.DataPropertyName = "Comment";
			this.dataGridViewTextBoxColumn_38.HeaderText = "Комментарий";
			this.dataGridViewTextBoxColumn_38.Name = "сommentDocOutStatusDgvColumn";
			this.dataGridViewTextBoxColumn_38.ReadOnly = true;
			this.bsTC_Contract.DataMember = "vTC_Contract";
			this.bsTC_Contract.DataSource = this.class10_0;
			this.bsTC_Contract.CurrentChanged += this.bindingSource_0_CurrentChanged;
			this.class10_0.DataSetName = "DataSetTechConnection";
			this.class10_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
			this.dataGridViewTextBoxColumn_0.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_0.HeaderText = "id";
			this.dataGridViewTextBoxColumn_0.Name = "idFileDgvColumn";
			this.dataGridViewTextBoxColumn_0.ReadOnly = true;
			this.dataGridViewTextBoxColumn_0.Visible = false;
			this.dataGridViewTextBoxColumn_1.DataPropertyName = "idDoc";
			this.dataGridViewTextBoxColumn_1.HeaderText = "idDoc";
			this.dataGridViewTextBoxColumn_1.Name = "idDocDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_1.ReadOnly = true;
			this.dataGridViewTextBoxColumn_1.Visible = false;
			this.dataGridViewLinkColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewLinkColumn_0.DataPropertyName = "FileName";
			this.dataGridViewLinkColumn_0.HeaderText = "Файл";
			this.dataGridViewLinkColumn_0.Name = "fileNameDgvColumn";
			this.dataGridViewLinkColumn_0.ReadOnly = true;
			this.dataGridViewLinkColumn_0.Resizable = DataGridViewTriState.True;
			this.dataGridViewLinkColumn_0.SortMode = DataGridViewColumnSortMode.Automatic;
			this.dataGridViewTextBoxColumn_2.DataPropertyName = "dateChange";
			this.dataGridViewTextBoxColumn_2.HeaderText = "dateChange";
			this.dataGridViewTextBoxColumn_2.Name = "dateChangeDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_2.ReadOnly = true;
			this.dataGridViewTextBoxColumn_2.Visible = false;
			this.dataGridViewTextBoxColumn_3.DataPropertyName = "idTemplate";
			this.dataGridViewTextBoxColumn_3.HeaderText = "idTemplate";
			this.dataGridViewTextBoxColumn_3.Name = "idTemplateDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_3.ReadOnly = true;
			this.dataGridViewTextBoxColumn_3.Visible = false;
			this.bsTC_DocFile.DataMember = "tTC_DocFile";
			this.bsTC_DocFile.DataSource = this.class10_0;
			this.dataGridViewTextBoxColumn_61.DataPropertyName = "numDateIn";
			dataGridViewCellStyle17.WrapMode = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_61.DefaultCellStyle = dataGridViewCellStyle17;
			this.dataGridViewTextBoxColumn_61.HeaderText = "№,дата вход";
			this.dataGridViewTextBoxColumn_61.Name = "numDateInDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_61.ReadOnly = true;
			this.dataGridViewTextBoxColumn_61.Width = 80;
			this.dataGridViewTextBoxColumn_62.DataPropertyName = "dateDoc";
			this.dataGridViewTextBoxColumn_62.HeaderText = "Дата получения";
			this.dataGridViewTextBoxColumn_62.Name = "dateDocDataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn_62.ReadOnly = true;
			this.dataGridViewTextBoxColumn_62.Width = 70;
			this.dataGridViewTextBoxColumn_63.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_63.DataPropertyName = "body";
			dataGridViewCellStyle18.WrapMode = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_63.DefaultCellStyle = dataGridViewCellStyle18;
			this.dataGridViewTextBoxColumn_63.HeaderText = "Тело письма";
			this.dataGridViewTextBoxColumn_63.Name = "bodyDataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn_63.ReadOnly = true;
			this.dataGridViewTextBoxColumn_64.DataPropertyName = "PowerCurrent";
			this.dataGridViewTextBoxColumn_64.HeaderText = "Текщая мощность";
			this.dataGridViewTextBoxColumn_64.Name = "powerCurrentDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_64.ReadOnly = true;
			this.dataGridViewTextBoxColumn_64.Width = 70;
			this.dataGridViewTextBoxColumn_65.DataPropertyName = "PowerAdd";
			this.dataGridViewTextBoxColumn_65.HeaderText = "Доп мощность";
			this.dataGridViewTextBoxColumn_65.Name = "powerAddDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_65.ReadOnly = true;
			this.dataGridViewTextBoxColumn_65.Width = 70;
			this.dataGridViewTextBoxColumn_66.DataPropertyName = "Power";
			this.dataGridViewTextBoxColumn_66.HeaderText = "Суммарная мощность";
			this.dataGridViewTextBoxColumn_66.Name = "powerDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_66.ReadOnly = true;
			this.dataGridViewTextBoxColumn_66.Width = 70;
			this.dataGridViewTextBoxColumn_67.DataPropertyName = "VoltageName";
			this.dataGridViewTextBoxColumn_67.HeaderText = "Напряжение";
			this.dataGridViewTextBoxColumn_67.Name = "voltageNameDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_67.ReadOnly = true;
			this.dataGridViewTextBoxColumn_67.Width = 70;
			this.dataGridViewTextBoxColumn_68.DataPropertyName = "Comment";
			this.dataGridViewTextBoxColumn_68.HeaderText = "Комментарий";
			this.dataGridViewTextBoxColumn_68.Name = "commentDataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn_68.ReadOnly = true;
			this.dataGridViewTextBoxColumn_68.Width = 70;
			this.dataGridViewTextBoxColumn_69.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_69.HeaderText = "id";
			this.dataGridViewTextBoxColumn_69.Name = "idDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_69.ReadOnly = true;
			this.dataGridViewTextBoxColumn_69.Visible = false;
			this.dataGridViewTextBoxColumn_70.DataPropertyName = "numDoc";
			this.dataGridViewTextBoxColumn_70.HeaderText = "numDoc";
			this.dataGridViewTextBoxColumn_70.Name = "numDocDataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn_70.ReadOnly = true;
			this.dataGridViewTextBoxColumn_70.Visible = false;
			this.dataGridViewTextBoxColumn_71.DataPropertyName = "TypeDoc";
			this.dataGridViewTextBoxColumn_71.HeaderText = "TypeDoc";
			this.dataGridViewTextBoxColumn_71.Name = "typeDocRequestHistoryDgvColumn";
			this.dataGridViewTextBoxColumn_71.ReadOnly = true;
			this.dataGridViewTextBoxColumn_71.Visible = false;
			this.dataGridViewTextBoxColumn_72.DataPropertyName = "numIn";
			this.dataGridViewTextBoxColumn_72.HeaderText = "numIn";
			this.dataGridViewTextBoxColumn_72.Name = "numInDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_72.ReadOnly = true;
			this.dataGridViewTextBoxColumn_72.Visible = false;
			this.dataGridViewTextBoxColumn_73.DataPropertyName = "dateIn";
			this.dataGridViewTextBoxColumn_73.HeaderText = "dateIn";
			this.dataGridViewTextBoxColumn_73.Name = "dateInDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_73.ReadOnly = true;
			this.dataGridViewTextBoxColumn_73.Visible = false;
			this.dataGridViewTextBoxColumn_74.DataPropertyName = "idAbn";
			this.dataGridViewTextBoxColumn_74.HeaderText = "idAbn";
			this.dataGridViewTextBoxColumn_74.Name = "idAbnDataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn_74.ReadOnly = true;
			this.dataGridViewTextBoxColumn_74.Visible = false;
			this.dataGridViewTextBoxColumn_75.DataPropertyName = "idAbnObj";
			this.dataGridViewTextBoxColumn_75.HeaderText = "idAbnObj";
			this.dataGridViewTextBoxColumn_75.Name = "idAbnObjDataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn_75.ReadOnly = true;
			this.dataGridViewTextBoxColumn_75.Visible = false;
			this.dataGridViewTextBoxColumn_76.DataPropertyName = "VoltageLevel";
			this.dataGridViewTextBoxColumn_76.HeaderText = "VoltageLevel";
			this.dataGridViewTextBoxColumn_76.Name = "voltageLevelDataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn_76.ReadOnly = true;
			this.dataGridViewTextBoxColumn_76.Visible = false;
			this.dataGridViewTextBoxColumn_77.DataPropertyName = "VoltageValue";
			this.dataGridViewTextBoxColumn_77.HeaderText = "VoltageValue";
			this.dataGridViewTextBoxColumn_77.Name = "voltageValueDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_77.ReadOnly = true;
			this.dataGridViewTextBoxColumn_77.Visible = false;
			this.dataGridViewTextBoxColumn_78.DataPropertyName = "IdParent";
			this.dataGridViewTextBoxColumn_78.HeaderText = "IdParent";
			this.dataGridViewTextBoxColumn_78.Name = "idParentDataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn_78.ReadOnly = true;
			this.dataGridViewTextBoxColumn_78.Visible = false;
			this.qaooyMwseOB.DataMember = "vTC_RequestHistory";
			this.qaooyMwseOB.DataSource = this.class10_0;
			this.dataGridViewTextBoxColumn_39.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_39.DataPropertyName = "Work";
			dataGridViewCellStyle19.WrapMode = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_39.DefaultCellStyle = dataGridViewCellStyle19;
			this.dataGridViewTextBoxColumn_39.HeaderText = "Работы сетевой организации";
			this.dataGridViewTextBoxColumn_39.Name = "workDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_39.ReadOnly = true;
			this.dataGridViewTextBoxColumn_39.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn_40.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_40.HeaderText = "id";
			this.dataGridViewTextBoxColumn_40.Name = "idNetWorkDgvColumn";
			this.dataGridViewTextBoxColumn_40.ReadOnly = true;
			this.dataGridViewTextBoxColumn_40.Visible = false;
			this.dataGridViewTextBoxColumn_41.DataPropertyName = "idTU";
			this.dataGridViewTextBoxColumn_41.HeaderText = "idTU";
			this.dataGridViewTextBoxColumn_41.Name = "idTUNetWorkDgvColumn";
			this.dataGridViewTextBoxColumn_41.ReadOnly = true;
			this.dataGridViewTextBoxColumn_41.Visible = false;
			this.dataGridViewTextBoxColumn_42.DataPropertyName = "num";
			this.dataGridViewTextBoxColumn_42.HeaderText = "num";
			this.dataGridViewTextBoxColumn_42.Name = "numNetWorkDgvColumn";
			this.dataGridViewTextBoxColumn_42.ReadOnly = true;
			this.dataGridViewTextBoxColumn_42.Visible = false;
			this.dataGridViewTextBoxColumn_43.DataPropertyName = "TypeWork";
			this.dataGridViewTextBoxColumn_43.HeaderText = "TypeWork";
			this.dataGridViewTextBoxColumn_43.Name = "typeWorkNetWorkDgvColumn";
			this.dataGridViewTextBoxColumn_43.ReadOnly = true;
			this.dataGridViewTextBoxColumn_43.Visible = false;
			this.bindingSource_4.DataMember = "tTC_TUTypeWork";
			this.bindingSource_4.DataSource = this.class10_0;
			this.bindingSource_4.Filter = "TypeWork = 1";
			this.bindingSource_4.Sort = "num";
			this.dataGridViewTextBoxColumn_44.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_44.DataPropertyName = "Work";
			dataGridViewCellStyle20.WrapMode = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_44.DefaultCellStyle = dataGridViewCellStyle20;
			this.dataGridViewTextBoxColumn_44.HeaderText = "Работы заказчика";
			this.dataGridViewTextBoxColumn_44.Name = "workDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_44.ReadOnly = true;
			this.dataGridViewTextBoxColumn_44.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn_45.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_45.HeaderText = "id";
			this.dataGridViewTextBoxColumn_45.Name = "idClientWorkDgvColumn";
			this.dataGridViewTextBoxColumn_45.ReadOnly = true;
			this.dataGridViewTextBoxColumn_45.Visible = false;
			this.dataGridViewTextBoxColumn_46.DataPropertyName = "idTU";
			this.dataGridViewTextBoxColumn_46.HeaderText = "idTU";
			this.dataGridViewTextBoxColumn_46.Name = "idTUClientWorkDgvColumn";
			this.dataGridViewTextBoxColumn_46.ReadOnly = true;
			this.dataGridViewTextBoxColumn_46.Visible = false;
			this.dataGridViewTextBoxColumn_47.DataPropertyName = "num";
			this.dataGridViewTextBoxColumn_47.HeaderText = "num";
			this.dataGridViewTextBoxColumn_47.Name = "numClientWorkDgvColumn";
			this.dataGridViewTextBoxColumn_47.ReadOnly = true;
			this.dataGridViewTextBoxColumn_47.Visible = false;
			this.dataGridViewTextBoxColumn_48.DataPropertyName = "TypeWork";
			this.dataGridViewTextBoxColumn_48.HeaderText = "TypeWork";
			this.dataGridViewTextBoxColumn_48.Name = "typeWorkClientWorkDgvColumn";
			this.dataGridViewTextBoxColumn_48.ReadOnly = true;
			this.dataGridViewTextBoxColumn_48.Visible = false;
			this.lrEoZnScroP.DataMember = "tTC_TUTypeWork";
			this.lrEoZnScroP.DataSource = this.class10_0;
			this.lrEoZnScroP.Filter = "TypeWork = 2";
			this.lrEoZnScroP.Sort = "num";
			this.dataGridViewTextBoxColumn_20.DataPropertyName = "TypeDocNameOut";
			this.dataGridViewTextBoxColumn_20.HeaderText = "Документ";
			this.dataGridViewTextBoxColumn_20.Name = "typeDocNameOutDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_20.ReadOnly = true;
			this.dataGridViewTextBoxColumn_21.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_21.HeaderText = "id";
			this.dataGridViewTextBoxColumn_21.Name = "idLinkDocOutDgvColumn";
			this.dataGridViewTextBoxColumn_21.ReadOnly = true;
			this.dataGridViewTextBoxColumn_21.Visible = false;
			this.dataGridViewTextBoxColumn_22.DataPropertyName = "numDateDocOut";
			this.dataGridViewTextBoxColumn_22.HeaderText = "numDateDocOut";
			this.dataGridViewTextBoxColumn_22.Name = "numDateDocOutDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_22.ReadOnly = true;
			this.dataGridViewTextBoxColumn_22.Visible = false;
			this.dataGridViewTextBoxColumn_24.DataPropertyName = "numDocOut";
			this.dataGridViewTextBoxColumn_24.HeaderText = "№";
			this.dataGridViewTextBoxColumn_24.Name = "numDocOutDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_24.ReadOnly = true;
			this.dataGridViewTextBoxColumn_27.DataPropertyName = "dateDocOut";
			dataGridViewCellStyle21.Format = "d";
			dataGridViewCellStyle21.NullValue = null;
			this.dataGridViewTextBoxColumn_27.DefaultCellStyle = dataGridViewCellStyle21;
			this.dataGridViewTextBoxColumn_27.HeaderText = "Дата";
			this.dataGridViewTextBoxColumn_27.Name = "dateDocOutDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_27.ReadOnly = true;
			this.dataGridViewTextBoxColumn_28.DataPropertyName = "Status";
			this.dataGridViewTextBoxColumn_28.HeaderText = "Статус";
			this.dataGridViewTextBoxColumn_28.Name = "statusDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_28.ReadOnly = true;
			this.dataGridViewTextBoxColumn_28.Visible = false;
			this.dataGridViewTextBoxColumn_30.DataPropertyName = "SendModeName";
			this.dataGridViewTextBoxColumn_30.HeaderText = "Способ отправки";
			this.dataGridViewTextBoxColumn_30.Name = "sendModeNameDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_30.ReadOnly = true;
			this.dataGridViewTextBoxColumn_30.Visible = false;
			this.dataGridViewTextBoxColumn_31.DataPropertyName = "number";
			this.dataGridViewTextBoxColumn_31.HeaderText = "Кол-во";
			this.dataGridViewTextBoxColumn_31.Name = "numberDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_31.ReadOnly = true;
			this.dataGridViewTextBoxColumn_32.DataPropertyName = "comment";
			this.dataGridViewTextBoxColumn_32.HeaderText = "Комментарий";
			this.dataGridViewTextBoxColumn_32.Name = "commentDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_32.ReadOnly = true;
			this.dataGridViewTextBoxColumn_32.Visible = false;
			this.bindingSource_2.DataMember = "vTC_DocOut";
			this.bindingSource_2.DataSource = this.class10_0;
			this.bindingSource_2.CurrentChanged += this.bindingSource_2_CurrentChanged;
			this.dataGridViewTextBoxColumn_79.DataPropertyName = "statusName";
			this.dataGridViewTextBoxColumn_79.HeaderText = "Статус";
			this.dataGridViewTextBoxColumn_79.Name = "statusNameDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_79.ReadOnly = true;
			this.dataGridViewTextBoxColumn_80.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_80.HeaderText = "id";
			this.dataGridViewTextBoxColumn_80.Name = "idDataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn_80.ReadOnly = true;
			this.dataGridViewTextBoxColumn_80.Visible = false;
			this.dataGridViewTextBoxColumn_81.DataPropertyName = "idDoc";
			this.dataGridViewTextBoxColumn_81.HeaderText = "idDoc";
			this.dataGridViewTextBoxColumn_81.Name = "idDocDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_81.ReadOnly = true;
			this.dataGridViewTextBoxColumn_81.Visible = false;
			this.dataGridViewTextBoxColumn_82.DataPropertyName = "idStatus";
			this.dataGridViewTextBoxColumn_82.HeaderText = "idStatus";
			this.dataGridViewTextBoxColumn_82.Name = "idStatusDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_82.ReadOnly = true;
			this.dataGridViewTextBoxColumn_82.Visible = false;
			this.dataGridViewTextBoxColumn_83.DataPropertyName = "DateChange";
			this.dataGridViewTextBoxColumn_83.HeaderText = "Дата отправки";
			this.dataGridViewTextBoxColumn_83.Name = "dateChangeDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_83.ReadOnly = true;
			this.dataGridViewTextBoxColumn_84.DataPropertyName = "SendMode";
			this.dataGridViewTextBoxColumn_84.HeaderText = "SendMode";
			this.dataGridViewTextBoxColumn_84.Name = "sendModeDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_84.ReadOnly = true;
			this.dataGridViewTextBoxColumn_84.Visible = false;
			this.dataGridViewTextBoxColumn_85.DataPropertyName = "SendName";
			this.dataGridViewTextBoxColumn_85.HeaderText = "Способ отправки";
			this.dataGridViewTextBoxColumn_85.Name = "sendNameDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_85.ReadOnly = true;
			this.dataGridViewTextBoxColumn_86.DataPropertyName = "Comment";
			this.dataGridViewTextBoxColumn_86.HeaderText = "Комментарий";
			this.dataGridViewTextBoxColumn_86.Name = "commentDataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn_86.ReadOnly = true;
			this.bindingSource_3.DataMember = "vTC_DocStatus";
			this.bindingSource_3.DataSource = this.class10_0;
			this.dataGridViewTextBoxColumn_49.DataPropertyName = "typeDocName";
			this.dataGridViewTextBoxColumn_49.HeaderText = "Тип документа";
			this.dataGridViewTextBoxColumn_49.Name = "typeDocNameDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_49.ReadOnly = true;
			this.uFxoZadIudn.DataPropertyName = "numDoc";
			this.uFxoZadIudn.HeaderText = "№ документа";
			this.uFxoZadIudn.Name = "numDocDataGridViewTextBoxColumn2";
			this.uFxoZadIudn.ReadOnly = true;
			this.dataGridViewTextBoxColumn_50.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_50.HeaderText = "id";
			this.dataGridViewTextBoxColumn_50.Name = "idDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_50.ReadOnly = true;
			this.dataGridViewTextBoxColumn_50.Visible = false;
			this.dataGridViewTextBoxColumn_51.DataPropertyName = "dateDoc";
			this.dataGridViewTextBoxColumn_51.HeaderText = "Дата";
			this.dataGridViewTextBoxColumn_51.Name = "dateDocDataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn_51.ReadOnly = true;
			this.dataGridViewTextBoxColumn_52.DataPropertyName = "summa";
			dataGridViewCellStyle22.Format = "N2";
			dataGridViewCellStyle22.NullValue = null;
			this.dataGridViewTextBoxColumn_52.DefaultCellStyle = dataGridViewCellStyle22;
			this.dataGridViewTextBoxColumn_52.HeaderText = "Сумма";
			this.dataGridViewTextBoxColumn_52.Name = "summaDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_52.ReadOnly = true;
			this.dataGridViewTextBoxColumn_53.DataPropertyName = "TypeDoc";
			this.dataGridViewTextBoxColumn_53.HeaderText = "TypeDoc";
			this.dataGridViewTextBoxColumn_53.Name = "typeDocDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_53.ReadOnly = true;
			this.dataGridViewTextBoxColumn_53.Visible = false;
			this.KbboZbAmgFn.DataPropertyName = "Body";
			this.KbboZbAmgFn.HeaderText = "Body";
			this.KbboZbAmgFn.Name = "bodyDataGridViewTextBoxColumn";
			this.KbboZbAmgFn.ReadOnly = true;
			this.KbboZbAmgFn.Visible = false;
			this.dataGridViewTextBoxColumn_54.DataPropertyName = "IdParent";
			this.dataGridViewTextBoxColumn_54.HeaderText = "IdParent";
			this.dataGridViewTextBoxColumn_54.Name = "idParentDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_54.ReadOnly = true;
			this.dataGridViewTextBoxColumn_54.Visible = false;
			this.dataGridViewTextBoxColumn_55.DataPropertyName = "Comment";
			this.dataGridViewTextBoxColumn_55.HeaderText = "Комментарий";
			this.dataGridViewTextBoxColumn_55.Name = "commentDataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn_55.ReadOnly = true;
			this.dataGridViewTextBoxColumn_56.DataPropertyName = "idDog";
			this.dataGridViewTextBoxColumn_56.HeaderText = "idDog";
			this.dataGridViewTextBoxColumn_56.Name = "idDogPaymentDgvColumn";
			this.dataGridViewTextBoxColumn_56.ReadOnly = true;
			this.dataGridViewTextBoxColumn_56.Visible = false;
			this.dataGridViewLinkColumn_1.DataPropertyName = "Dog";
			this.dataGridViewLinkColumn_1.HeaderText = "Договор";
			this.dataGridViewLinkColumn_1.Name = "dogPaymentDgvColumn";
			this.dataGridViewLinkColumn_1.ReadOnly = true;
			this.dataGridViewLinkColumn_1.Resizable = DataGridViewTriState.True;
			this.dataGridViewLinkColumn_1.SortMode = DataGridViewColumnSortMode.Automatic;
			this.bindingSource_5.DataMember = "vTC_Payment";
			this.bindingSource_5.DataSource = this.class10_0;
			this.bindingSource_5.Filter = "";
			this.bindingSource_5.Sort = "dateDoc desc";
			this.dataGridViewFilterDateTimePickerColumn_0.DataPropertyName = "DateShedule";
			dataGridViewCellStyle23.Format = "d";
			dataGridViewCellStyle23.NullValue = null;
			this.dataGridViewFilterDateTimePickerColumn_0.DefaultCellStyle = dataGridViewCellStyle23;
			this.dataGridViewFilterDateTimePickerColumn_0.HeaderText = "Дата";
			this.dataGridViewFilterDateTimePickerColumn_0.Name = "dateSheduleDataGridViewTextBoxColumn";
			this.dataGridViewFilterDateTimePickerColumn_0.ReadOnly = true;
			this.dataGridViewFilterDateTimePickerColumn_0.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterDateTimePickerColumn_0.SortMode = DataGridViewColumnSortMode.Automatic;
			this.dataGridViewTextBoxColumn_57.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_57.HeaderText = "id";
			this.dataGridViewTextBoxColumn_57.Name = "dataGridViewTextBoxColumn7";
			this.dataGridViewTextBoxColumn_57.ReadOnly = true;
			this.dataGridViewTextBoxColumn_57.Visible = false;
			this.dataGridViewTextBoxColumn_58.DataPropertyName = "idDoc";
			this.dataGridViewTextBoxColumn_58.HeaderText = "idDoc";
			this.dataGridViewTextBoxColumn_58.Name = "idDocPSDgvColumn";
			this.dataGridViewTextBoxColumn_58.ReadOnly = true;
			this.dataGridViewTextBoxColumn_58.Visible = false;
			this.dataGridViewTextBoxColumn_59.DataPropertyName = "Summa";
			dataGridViewCellStyle24.Format = "N2";
			dataGridViewCellStyle24.NullValue = null;
			this.dataGridViewTextBoxColumn_59.DefaultCellStyle = dataGridViewCellStyle24;
			this.dataGridViewTextBoxColumn_59.HeaderText = "Сумма";
			this.dataGridViewTextBoxColumn_59.Name = "dataGridViewNumericColumn1";
			this.dataGridViewTextBoxColumn_59.ReadOnly = true;
			this.dataGridViewTextBoxColumn_59.Resizable = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_60.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_60.DataPropertyName = "Comment";
			this.dataGridViewTextBoxColumn_60.HeaderText = "Коментарий";
			this.dataGridViewTextBoxColumn_60.Name = "dataGridViewTextBoxColumn8";
			this.dataGridViewTextBoxColumn_60.ReadOnly = true;
			this.bindingSource_6.DataMember = "tTC_PaymentShedule";
			this.bindingSource_6.DataSource = this.class10_0;
			this.class10_1.DataSetName = "DataSetTechConnection";
			this.class10_1.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
			this.dataGridViewFilterTextBoxColumn_0.DataPropertyName = "numDoc";
			this.dataGridViewFilterTextBoxColumn_0.HeaderText = "№ дог";
			this.dataGridViewFilterTextBoxColumn_0.Name = "numDocDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_0.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_0.Resizable = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_87.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_87.HeaderText = "id";
			this.dataGridViewTextBoxColumn_87.Name = "idDgvColumn";
			this.dataGridViewTextBoxColumn_87.ReadOnly = true;
			this.dataGridViewTextBoxColumn_87.Visible = false;
			this.dataGridViewFilterTextBoxColumn_1.DataPropertyName = "dateDoc";
			this.dataGridViewFilterTextBoxColumn_1.HeaderText = "Дата";
			this.dataGridViewFilterTextBoxColumn_1.Name = "dateDocDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_1.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_1.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_1.Width = 70;
			this.dataGridViewTextBoxColumn_88.DataPropertyName = "idTU";
			this.dataGridViewTextBoxColumn_88.HeaderText = "idTU";
			this.dataGridViewTextBoxColumn_88.Name = "idTUDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_88.ReadOnly = true;
			this.dataGridViewTextBoxColumn_88.Visible = false;
			this.dataGridViewFilterTextBoxColumn_2.DataPropertyName = "numTU";
			this.dataGridViewFilterTextBoxColumn_2.HeaderText = "№ТУ";
			this.dataGridViewFilterTextBoxColumn_2.Name = "numTUDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_2.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_2.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_2.Width = 60;
			this.dataGridViewFilterTextBoxColumn_3.DataPropertyName = "dateTU";
			this.dataGridViewFilterTextBoxColumn_3.HeaderText = "Дата ТУ";
			this.dataGridViewFilterTextBoxColumn_3.Name = "dateTUDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_3.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_3.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_3.Width = 70;
			this.dataGridViewTextBoxColumn_89.DataPropertyName = "idRequest";
			this.dataGridViewTextBoxColumn_89.HeaderText = "idRequest";
			this.dataGridViewTextBoxColumn_89.Name = "idRequestDgvColumn";
			this.dataGridViewTextBoxColumn_89.ReadOnly = true;
			this.dataGridViewTextBoxColumn_89.Visible = false;
			this.dataGridViewTextBoxColumn_90.DataPropertyName = "numDateIn";
			this.dataGridViewTextBoxColumn_90.HeaderText = "numDateIn";
			this.dataGridViewTextBoxColumn_90.Name = "numDateInDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_90.ReadOnly = true;
			this.dataGridViewTextBoxColumn_90.Visible = false;
			this.dataGridViewFilterTextBoxColumn_4.DataPropertyName = "numIn";
			this.dataGridViewFilterTextBoxColumn_4.HeaderText = "№ входящего";
			this.dataGridViewFilterTextBoxColumn_4.Name = "numInDgvColumn";
			this.dataGridViewFilterTextBoxColumn_4.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_4.Visible = false;
			this.dataGridViewFilterTextBoxColumn_5.DataPropertyName = "dateIn";
			this.dataGridViewFilterTextBoxColumn_5.HeaderText = "Дата входящего";
			this.dataGridViewFilterTextBoxColumn_5.Name = "dateInDgvColumn";
			this.dataGridViewFilterTextBoxColumn_5.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_5.Visible = false;
			this.dataGridViewTextBoxColumn_91.DataPropertyName = "idAbn";
			this.dataGridViewTextBoxColumn_91.HeaderText = "idAbn";
			this.dataGridViewTextBoxColumn_91.Name = "idAbnDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_91.ReadOnly = true;
			this.dataGridViewTextBoxColumn_91.Visible = false;
			this.dataGridViewFilterTextBoxColumn_6.DataPropertyName = "nameAbn";
			dataGridViewCellStyle25.WrapMode = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_6.DefaultCellStyle = dataGridViewCellStyle25;
			this.dataGridViewFilterTextBoxColumn_6.HeaderText = "Потребитель";
			this.dataGridViewFilterTextBoxColumn_6.Name = "nameAbnDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_6.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_6.Resizable = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_92.DataPropertyName = "idAbnObj";
			this.dataGridViewTextBoxColumn_92.HeaderText = "idAbnObj";
			this.dataGridViewTextBoxColumn_92.Name = "idAbnObjDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_92.ReadOnly = true;
			this.dataGridViewTextBoxColumn_92.Visible = false;
			this.dataGridViewFilterTextBoxColumn_7.DataPropertyName = "nameObj";
			dataGridViewCellStyle26.WrapMode = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_7.DefaultCellStyle = dataGridViewCellStyle26;
			this.dataGridViewFilterTextBoxColumn_7.HeaderText = "Объект";
			this.dataGridViewFilterTextBoxColumn_7.Name = "nameObjDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_7.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_7.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_8.DataPropertyName = "address";
			this.dataGridViewFilterTextBoxColumn_8.HeaderText = "Адрес";
			this.dataGridViewFilterTextBoxColumn_8.Name = "addressDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_8.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_8.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterProgressColumn_0.DataPropertyName = "SumContract";
			dataGridViewCellStyle27.Format = "N2";
			dataGridViewCellStyle27.NullValue = null;
			this.dataGridViewFilterProgressColumn_0.DefaultCellStyle = dataGridViewCellStyle27;
			this.dataGridViewFilterProgressColumn_0.HeaderText = "Цена договора";
			this.dataGridViewFilterProgressColumn_0.Name = "sumContractDgvColumn";
			this.dataGridViewFilterProgressColumn_0.ProgressBarColor = Color.FromArgb(0, 192, 0);
			this.dataGridViewFilterProgressColumn_0.ReadOnly = true;
			this.dataGridViewFilterProgressColumn_0.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_9.DataPropertyName = "DateBegFact";
			this.dataGridViewFilterTextBoxColumn_9.HeaderText = "Дата начала дейс-ия";
			this.dataGridViewFilterTextBoxColumn_9.Name = "dateBegFactDgvColumn";
			this.dataGridViewFilterTextBoxColumn_9.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_9.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_10.DataPropertyName = "DateImplFact";
			this.dataGridViewFilterTextBoxColumn_10.HeaderText = "Дата фактич вып-ия мер-ий";
			this.dataGridViewFilterTextBoxColumn_10.Name = "dateImplFactDgvColumn";
			this.dataGridViewFilterTextBoxColumn_10.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_10.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_11.DataPropertyName = "DatePerfomance";
			this.dataGridViewFilterTextBoxColumn_11.HeaderText = "Срок исполнения";
			this.dataGridViewFilterTextBoxColumn_11.Name = "datePerformanceDgvColumn";
			this.dataGridViewFilterTextBoxColumn_11.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_11.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_12.DataPropertyName = "PowerSum";
			this.dataGridViewFilterTextBoxColumn_12.HeaderText = "Кол-во, кВт";
			this.dataGridViewFilterTextBoxColumn_12.Name = "powerSumDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_12.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_12.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_13.DataPropertyName = "CategoryName";
			this.dataGridViewFilterTextBoxColumn_13.HeaderText = "Категория";
			this.dataGridViewFilterTextBoxColumn_13.Name = "categoryNameDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_13.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_13.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_14.DataPropertyName = "VoltageLevel";
			this.dataGridViewFilterTextBoxColumn_14.HeaderText = "Ур-нь напр-ия";
			this.dataGridViewFilterTextBoxColumn_14.Name = "voltageLevelDataGridViewTextBoxColumn1";
			this.dataGridViewFilterTextBoxColumn_14.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_14.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_15.DataPropertyName = "SchmTP";
			dataGridViewCellStyle28.WrapMode = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_15.DefaultCellStyle = dataGridViewCellStyle28;
			this.dataGridViewFilterTextBoxColumn_15.HeaderText = "ТП";
			this.dataGridViewFilterTextBoxColumn_15.Name = "schmTPDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_15.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_15.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_16.DataPropertyName = "SchmCP";
			dataGridViewCellStyle29.WrapMode = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_16.DefaultCellStyle = dataGridViewCellStyle29;
			this.dataGridViewFilterTextBoxColumn_16.HeaderText = "ЦП";
			this.dataGridViewFilterTextBoxColumn_16.Name = "schmCPDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_16.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_16.Resizable = DataGridViewTriState.True;
			this.dataGridViewCheckBoxColumn_0.DataPropertyName = "IsCancel";
			this.dataGridViewCheckBoxColumn_0.HeaderText = "IsCancel";
			this.dataGridViewCheckBoxColumn_0.Name = "isCancelDgvColumn";
			this.dataGridViewCheckBoxColumn_0.ReadOnly = true;
			this.dataGridViewCheckBoxColumn_0.Visible = false;
			this.dataGridViewTextBoxColumn_93.DataPropertyName = "SumPayment";
			this.dataGridViewTextBoxColumn_93.HeaderText = "SumPayment";
			this.dataGridViewTextBoxColumn_93.Name = "sumPaymentDgvColumn";
			this.dataGridViewTextBoxColumn_93.ReadOnly = true;
			this.dataGridViewTextBoxColumn_93.Visible = false;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(964, 522);
			base.Controls.Add(this.splitContainer_0);
			base.Controls.Add(this.toolStrip_0);
			base.Name = "FormJournalContract";
			this.Text = "Договора на ТП";
			base.FormClosed += this.FormJournalContract_FormClosed;
			base.Load += this.FormJournalContract_Load;
			this.toolStrip_0.ResumeLayout(false);
			this.toolStrip_0.PerformLayout();
			this.splitContainer_0.Panel1.ResumeLayout(false);
			this.splitContainer_0.Panel1.PerformLayout();
			this.splitContainer_0.Panel2.ResumeLayout(false);
			this.splitContainer_0.ResumeLayout(false);
			this.toolStrip_1.ResumeLayout(false);
			this.toolStrip_1.PerformLayout();
			this.splitContainer_1.Panel1.ResumeLayout(false);
			this.splitContainer_1.Panel2.ResumeLayout(false);
			this.splitContainer_1.ResumeLayout(false);
			((ISupportInitialize)this.dataGridViewExcelFilter_0).EndInit();
			this.tabControl_0.ResumeLayout(false);
			this.tabPage_0.ResumeLayout(false);
			((ISupportInitialize)this.dgvFile).EndInit();
			this.tabPage_1.ResumeLayout(false);
			((ISupportInitialize)this.dataGridViewExcelFilter_2).EndInit();
			this.tabPage_2.ResumeLayout(false);
			this.splitContainer_3.Panel1.ResumeLayout(false);
			this.splitContainer_3.Panel2.ResumeLayout(false);
			this.splitContainer_3.ResumeLayout(false);
			((ISupportInitialize)this.dataGridViewExcelFilter_5).EndInit();
			((ISupportInitialize)this.dataGridViewExcelFilter_6).EndInit();
			this.JpeoyahFdLp.ResumeLayout(false);
			this.splitContainer_2.Panel1.ResumeLayout(false);
			this.splitContainer_2.Panel1.PerformLayout();
			this.splitContainer_2.Panel2.ResumeLayout(false);
			this.splitContainer_2.Panel2.PerformLayout();
			this.splitContainer_2.ResumeLayout(false);
			((ISupportInitialize)this.dataGridViewExcelFilter_3).EndInit();
			this.tgooyFsjvbY.ResumeLayout(false);
			this.tgooyFsjvbY.PerformLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_4).EndInit();
			this.toolStrip_2.ResumeLayout(false);
			this.toolStrip_2.PerformLayout();
			this.tabPage_3.ResumeLayout(false);
			((ISupportInitialize)this.dataGridViewExcelFilter_7).EndInit();
			this.tabPage_4.ResumeLayout(false);
			((ISupportInitialize)this.dataGridView_0).EndInit();
			((ISupportInitialize)this.bsTC_Contract).EndInit();
			((ISupportInitialize)this.class10_0).EndInit();
			((ISupportInitialize)this.bsTC_DocFile).EndInit();
			((ISupportInitialize)this.qaooyMwseOB).EndInit();
			((ISupportInitialize)this.bindingSource_4).EndInit();
			((ISupportInitialize)this.lrEoZnScroP).EndInit();
			((ISupportInitialize)this.bindingSource_2).EndInit();
			((ISupportInitialize)this.bindingSource_3).EndInit();
			((ISupportInitialize)this.bindingSource_5).EndInit();
			((ISupportInitialize)this.bindingSource_6).EndInit();
			((ISupportInitialize)this.class10_1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private int int_0;

		private int int_1;

		private int int_2;

		private List<int> list_0;

		private int int_3;

		private int int_4;

		private ToolStrip toolStrip_0;

		private ToolStripButton toolStripButton_0;

		private ToolStripButton toolStripButton_1;

		private ToolStripButton toolStripButton_2;

		private DataGridViewExcelFilter dataGridViewExcelFilter_0;

		private BindingSource bsTC_Contract;

		private Class10 class10_0;

		private ToolStripSeparator toolStripSeparator_0;

		private ToolStripButton toolStripButton_3;

		private ToolStripSeparator toolStripSeparator_1;

		private ToolStripButton toolStripButton_4;

		private ToolStripTextBox toolStripTextBox_0;

		private ToolStripButton toolStripButton_5;

		private ToolStripButton toolStripButton_6;

		private SplitContainer splitContainer_0;

		private DateTimePicker dateTimePicker_0;

		private System.Windows.Forms.Label label_0;

		private DateTimePicker dateTimePicker_1;

		private System.Windows.Forms.Label label_1;

		private ToolStrip toolStrip_1;

		private ToolStripButton toolStripButton_7;

		private ToolStripButton toolStripButton_8;

		private SplitContainer splitContainer_1;

		private TabControl tabControl_0;

		private TabPage tabPage_0;

		private DataGridViewExcelFilter dgvFile;

		private BindingSource bsTC_DocFile;

		private DataGridViewImageColumnNotNull dataGridViewImageColumnNotNull_0;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

		private DataGridViewLinkColumn dataGridViewLinkColumn_0;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_3;

		private TabPage tabPage_1;

		private BindingSource qaooyMwseOB;

		private DataGridViewExcelFilter dataGridViewExcelFilter_2;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_4;

		private DataGridViewTextBoxColumn JoaoydTljgn;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_5;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_6;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_7;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_8;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_9;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_10;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_11;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_12;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_13;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_14;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_15;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_16;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_17;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_18;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_19;

		private ToolStripSeparator toolStripSeparator_2;

		private ToolStripButton toolStripButton_9;

		private TabPage JpeoyahFdLp;

		private SplitContainer splitContainer_2;

		private ToolStrip tgooyFsjvbY;

		private ToolStripButton toolStripButton_10;

		private ToolStripButton toolStripButton_11;

		private BindingSource bindingSource_2;

		private DataGridViewExcelFilter dataGridViewExcelFilter_3;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_20;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_21;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_22;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_23;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_24;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_25;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_26;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_27;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_28;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_29;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_30;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_31;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_32;

		private ToolStripButton toolStripButton_12;

		private BindingSource bindingSource_3;

		private ToolStrip toolStrip_2;

		private ToolStripButton toolStripButton_13;

		private ToolStripButton toolStripButton_14;

		private ToolStripButton toolStripButton_15;

		private DataGridViewExcelFilter dataGridViewExcelFilter_4;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_33;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_34;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_35;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_36;

		private DataGridViewTextBoxColumn oqboZoVnVe7;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_37;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_38;

		private ToolStripButton toolStripButton_16;

		private TabPage tabPage_2;

		private SplitContainer splitContainer_3;

		private BindingSource bindingSource_4;

		private BindingSource lrEoZnScroP;

		private DataGridViewExcelFilter dataGridViewExcelFilter_5;

		private DataGridViewExcelFilter dataGridViewExcelFilter_6;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_39;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_40;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_41;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_42;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_43;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_44;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_45;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_46;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_47;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_48;

		private Class10 class10_1;

		private ToolStripButton toolStripButton_17;

		private BindingSource bindingSource_5;

		private TabPage tabPage_3;

		private DataGridViewExcelFilter dataGridViewExcelFilter_7;

		private TabPage tabPage_4;

		private BindingSource bindingSource_6;

		private DataGridView dataGridView_0;

		private ToolStripSeparator toolStripSeparator_3;

		private ToolStripButton toolStripButton_18;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_49;

		private DataGridViewTextBoxColumn uFxoZadIudn;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_50;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_51;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_52;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_53;

		private DataGridViewTextBoxColumn KbboZbAmgFn;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_54;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_55;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_56;

		private DataGridViewLinkColumn dataGridViewLinkColumn_1;

		private DataGridViewFilterDateTimePickerColumn dataGridViewFilterDateTimePickerColumn_0;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_57;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_58;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_59;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_60;

		private DataGridViewFilterDateTimePickerColumn dataGridViewFilterDateTimePickerColumn_1;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_61;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_62;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_63;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_64;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_65;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_66;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_67;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_68;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_69;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_70;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_71;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_72;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_73;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_74;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_75;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_76;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_77;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_78;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_79;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_80;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_81;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_82;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_83;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_84;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_85;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_86;

		private ToolStripSeparator toolStripSeparator_4;

		private ToolStripButton toolStripButton_19;

		private TreeView treeView_0;

		private System.Windows.Forms.Label label_2;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_0;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_87;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_1;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_88;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_2;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_3;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_89;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_90;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_4;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_5;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_91;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_6;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_92;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_7;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_8;

		private DataGridViewFilterProgressColumn dataGridViewFilterProgressColumn_0;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_9;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_10;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_11;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_12;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_13;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_14;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_15;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_16;

		private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn_0;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_93;
	}
}
