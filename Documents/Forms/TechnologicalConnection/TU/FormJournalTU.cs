using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml;
using Constants;
using ControlsLbr.DataGridViewExcelFilter;
using DataSql;
using Documents.Forms.Memorandums;
using Documents.Forms.TechnologicalConnection.Acts;
using Documents.Forms.TechnologicalConnection.ActTC;
using Documents.Forms.TechnologicalConnection.RBP;
using Documents.Properties;
using FormLbr;
using FormLbr.Classes;
using Microsoft.Office.Interop.Excel;

namespace Documents.Forms.TechnologicalConnection.TU
{
	public partial class FormJournalTU : FormBase
	{
		public FormJournalTU()
		{
			
			this.int_0 = -1;
			this.int_1 = -1;
			this.int_2 = -1;
			this.int_3 = -1;
			this.int_4 = -1;
			
			this.method_20();
			this.method_3();
		}

		public FormJournalTU(int idTU)
		{
			
			this.int_0 = -1;
			this.int_1 = -1;
			this.int_2 = -1;
			this.int_3 = -1;
			this.int_4 = -1;
			
			this.method_20();
			this.method_3();
			this.int_0 = idTU;
		}

		public FormJournalTU(List<int> checkedSubstation)
		{
			
			this.int_0 = -1;
			this.int_1 = -1;
			this.int_2 = -1;
			this.int_3 = -1;
			this.int_4 = -1;
			
			this.method_20();
			this.method_3();
			this.list_0 = checkedSubstation;
		}

		private void FormJournalTU_Load(object sender, EventArgs e)
		{
			this.toolStripButton_15.Visible = false;
			base.LoadFormConfig(null);
			this.method_18();
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
				this.FkSanDtyTi.SearchGrid(this.dataGridViewTextBoxColumn_137.Name, num.ToString(), false);
				if (this.FkSanDtyTi.CurrentRow != null)
				{
					this.FkSanDtyTi.FirstDisplayedScrollingRowIndex = this.FkSanDtyTi.CurrentRow.Index;
				}
			}
		}

		private void FormJournalTU_FormClosed(object sender, FormClosedEventArgs e)
		{
			base.SaveFormConfig(null);
		}

		private void method_0()
		{
			int num = this.int_0;
			List<int> list = this.method_19(this.treeView_0.Nodes);
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
				text += string.Format(" and id in (select idTU from ttc_tuPointAttach where idSubPoint in ({0}) and (typeDoc is null or typeDoc = {1})) ", text2, 1123);
			}
			text += " ORDER BY CONVERT(BIGINT, CASE WHEN numdoc like '%[^0-9]%' THEN SUBSTRING(numdoc,1,PATINDEX('%[^0-9]%',numdoc)-1) ELSE numdoc END) desc";
			base.SelectSqlData(this.class10_0, this.class10_0.vTC_TU, true, text);
			if (num > 0)
			{
				this.FkSanDtyTi.SearchGrid(this.dataGridViewTextBoxColumn_137.Name, num.ToString(), false);
			}
		}

		private void FkSanDtyTi_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
		{
			((DataGridView)sender).AutoResizeRow(e.RowIndex);
		}

		private void FkSanDtyTi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && this.toolStripButton_1.Enabled && this.toolStripButton_1.Visible)
			{
				this.toolStripButton_1_Click(sender, e);
			}
		}

		private void FkSanDtyTi_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				if (this.FkSanDtyTi[this.waFeUdmntD.Name, e.RowIndex].Value != null && this.FkSanDtyTi[this.waFeUdmntD.Name, e.RowIndex].Value != DBNull.Value)
				{
					e.CellStyle.BackColor = Color.LightGray;
				}
				if (this.FkSanDtyTi[this.dataGridViewCheckBoxColumn_0.Name, e.RowIndex].Value != null && this.FkSanDtyTi[this.dataGridViewCheckBoxColumn_0.Name, e.RowIndex].Value != DBNull.Value && Convert.ToBoolean(this.FkSanDtyTi[this.dataGridViewCheckBoxColumn_0.Name, e.RowIndex].Value))
				{
					e.CellStyle.ForeColor = Color.Red;
				}
			}
		}

		private void toolStripButton_0_Click(object sender, EventArgs e)
		{
			FormTUAddEdit formTUAddEdit = new FormTUAddEdit();
			formTUAddEdit.SqlSettings = this.SqlSettings;
			formTUAddEdit.MdiParent = base.MdiParent;
			formTUAddEdit.FormClosed += this.method_1;
			formTUAddEdit.Show();
		}

		private void method_1(object sender, FormClosedEventArgs e)
		{
			this.int_0 = ((FormTUAddEdit)sender).IdTU;
			this.method_0();
		}

		private void toolStripButton_1_Click(object sender, EventArgs e)
		{
			if (this.int_0 != -1)
			{
				FormTUAddEdit formTUAddEdit = new FormTUAddEdit(this.int_0, -1);
				formTUAddEdit.SqlSettings = this.SqlSettings;
				formTUAddEdit.MdiParent = base.MdiParent;
				formTUAddEdit.FormClosed += this.method_1;
				formTUAddEdit.Show();
			}
		}

		private void toolStripButton_2_Click(object sender, EventArgs e)
		{
			if (this.int_0 > 0 && this.FkSanDtyTi.CurrentRow != null && MessageBox.Show("Вы действительно хотите удалить текущую запись?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes && base.DeleteSqlDataById(this.class10_0.tTC_Doc, this.int_0))
			{
				this.FkSanDtyTi.Rows.Remove(this.FkSanDtyTi.CurrentRow);
				MessageBox.Show("Запись успешно удалена");
			}
		}

		private void toolStripButton_9_Click(object sender, EventArgs e)
		{
			this.method_0();
		}

		private void toolStripButton_3_Click(object sender, EventArgs e)
		{
			if (this.FkSanDtyTi.CurrentRow != null && this.FkSanDtyTi.CurrentRow.Cells[this.dataGridViewTextBoxColumn_140.Name].Value != null && this.FkSanDtyTi.CurrentRow.Cells[this.dataGridViewTextBoxColumn_140.Name].Value != DBNull.Value)
			{
				new FormTechConnectionRequest(Convert.ToInt32(this.FkSanDtyTi.CurrentRow.Cells[this.dataGridViewTextBoxColumn_140.Name].Value))
				{
					MdiParent = base.MdiParent,
					SqlSettings = this.SqlSettings
				}.Show();
			}
		}

		private void toolStripButton_4_Click(object sender, EventArgs e)
		{
			this.FkSanDtyTi.SearchGrid(DataGridViewExcelFilter.TypeFind.Begin, this.toolStripTextBox_0.Text);
		}

		private void toolStripButton_5_Click(object sender, EventArgs e)
		{
			this.FkSanDtyTi.SearchGrid(DataGridViewExcelFilter.TypeFind.Prev, this.toolStripTextBox_0.Text);
		}

		private void toolStripButton_6_Click(object sender, EventArgs e)
		{
			this.FkSanDtyTi.SearchGrid(DataGridViewExcelFilter.TypeFind.Next, this.toolStripTextBox_0.Text);
		}

		private void toolStripTextBox_0_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				if (e.Modifiers == Keys.None)
				{
					this.FkSanDtyTi.SearchGrid(DataGridViewExcelFilter.TypeFind.Next, this.toolStripTextBox_0.Text);
				}
				if (e.Modifiers == Keys.Shift)
				{
					this.FkSanDtyTi.SearchGrid(DataGridViewExcelFilter.TypeFind.Prev, this.toolStripTextBox_0.Text);
				}
			}
		}

		private void QxUkSviJgI_Click(object sender, EventArgs e)
		{
			this.method_2(this.FkSanDtyTi);
		}

		private void method_2(DataGridView dataGridView_0)
		{
			_Application application = new ApplicationClass();
			_Workbook workbook = application.Workbooks.Add(Type.Missing);
			application.Visible = false;
			_Worksheet worksheet = (Worksheet)workbook.ActiveSheet;
			worksheet.Name = "Exported from gridview";
			int num = 1;
			for (int i = 1; i < dataGridView_0.Columns.Count; i++)
			{
				if (dataGridView_0.Columns[i].Visible)
				{
					worksheet.Cells[1, num] = dataGridView_0.Columns[i].HeaderText;
					((Range)worksheet.Cells[1, num]).Font.Bold = true;
					num++;
				}
			}
			for (int j = 0; j < dataGridView_0.Rows.Count - 1; j++)
			{
				num = 1;
				Color c = Color.White;
				if (dataGridView_0[this.dataGridViewTextBoxColumn_145.Name, j].Value != null && dataGridView_0[this.dataGridViewTextBoxColumn_145.Name, j].Value != DBNull.Value)
				{
					c = Color.LightGreen;
				}
				for (int k = 1; k < dataGridView_0.Columns.Count; k++)
				{
					if (dataGridView_0.Columns[k].Visible)
					{
						worksheet.Cells[j + 2, num] = dataGridView_0.Rows[j].Cells[k].Value.ToString();
						((Range)worksheet.Cells[j + 2, num]).WrapText = true;
						((Range)worksheet.Cells[j + 2, num]).Interior.Color = ColorTranslator.ToOle(c);
						num++;
					}
				}
			}
			application.Visible = true;
		}

		private void bindingSource_0_CurrentChanged(object sender, EventArgs e)
		{
			this.int_2 = -1;
			this.toolStripButton_16.Enabled = true;
			this.toolStripButton_17.Enabled = false;
			this.toolStripButton_18.Enabled = false;
			if (this.bindingSource_0.Current != null)
			{
				this.int_0 = Convert.ToInt32(((DataRowView)this.bindingSource_0.Current).Row["id"]);
				if (((DataRowView)this.bindingSource_0.Current).Row["idRequest"] != DBNull.Value)
				{
					this.int_1 = Convert.ToInt32(((DataRowView)this.bindingSource_0.Current).Row["idRequest"]);
				}
				else
				{
					this.int_1 = -1;
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
				base.SelectSqlData(this.class10_0, this.class10_0.tTC_TUTypeWork, true, " where idTU = " + this.int_0.ToString());
				if (((DataRowView)this.bindingSource_0.Current).Row["idContractor"] != DBNull.Value)
				{
					this.int_2 = Convert.ToInt32(((DataRowView)this.bindingSource_0.Current).Row["idContractor"]);
					base.SelectSqlData(this.class10_1, this.class10_1.tTC_Doc, true, " where id = " + this.int_2.ToString());
					this.toolStripButton_16.Enabled = false;
					this.toolStripButton_17.Enabled = true;
					this.toolStripButton_18.Enabled = true;
				}
				else
				{
					this.class10_1.tTC_Doc.Clear();
				}
				this.method_7();
				this.method_15(false);
			}
			else
			{
				this.int_0 = -1;
				this.int_1 = -1;
				this.class10_0.tTC_DocFile.Clear();
				this.class10_0.vTC_DocOut.Clear();
				this.class10_0.tTC_TUTypeWork.Clear();
				this.class10_1.tTC_Doc.Clear();
				this.class10_0.vTC_Doc.Clear();
				this.class10_0.tJ_Memorandum.Clear();
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
			foreach (object obj in this.treeView_0.Nodes)
			{
				((TreeNode)obj).Checked = false;
			}
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

		private void dataGridViewExcelFilter_0_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
		{
			if (((DataGridView)sender).RowCount > 0 && this.dataGridViewExcelFilter_0[this.dataGridViewLinkColumn_0.Name, e.RowIndex].Value != null)
			{
				if (e.ColumnIndex == this.dataGridViewExcelFilter_0.Columns[this.dataGridViewImageColumnNotNull_0.Name].Index)
				{
					if (!string.IsNullOrEmpty(Path.GetFileName(this.dataGridViewExcelFilter_0[this.dataGridViewLinkColumn_0.Name, e.RowIndex].Value.ToString())))
					{
						e.Value = Path.GetFileName(this.dataGridViewExcelFilter_0[this.dataGridViewLinkColumn_0.Name, e.RowIndex].Value.ToString());
					}
					else
					{
						e.Value = this.dataGridViewExcelFilter_0[this.dataGridViewLinkColumn_0.Name, e.RowIndex].Value.ToString();
					}
				}
				if (e.ColumnIndex == this.dataGridViewExcelFilter_0.Columns[this.dataGridViewImageColumnNotNull_0.Name].Index)
				{
					Icon icon = FormLbr.Classes.FileInfo.IconOfFile(this.dataGridViewExcelFilter_0[this.dataGridViewLinkColumn_0.Name, e.RowIndex].Value.ToString());
					if (icon != null)
					{
						e.Value = icon.ToBitmap();
					}
				}
			}
		}

		private void dataGridViewExcelFilter_0_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (this.dataGridViewExcelFilter_0.CurrentRow == null)
			{
				return;
			}
			int num = Convert.ToInt32(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_0.Name].Value);
			if (e.ColumnIndex == this.dataGridViewExcelFilter_0.Columns[this.dataGridViewLinkColumn_0.Name].Index)
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

		private void dataGridViewExcelFilter_1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.RowIndex >= 0 && Convert.ToInt32(this.dataGridViewExcelFilter_1[this.dataGridViewTextBoxColumn_8.Name, e.RowIndex].Value) == 1113)
			{
				e.CellStyle.Font = new System.Drawing.Font(e.CellStyle.Font, FontStyle.Bold);
				e.CellStyle.BackColor = Color.LightGray;
			}
		}

		private void dataGridViewExcelFilter_1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
		{
			this.dataGridViewExcelFilter_1.AutoResizeRow(e.RowIndex);
		}

		private void dataGridViewExcelFilter_2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.RowIndex >= 0 && Convert.ToInt32(this.dataGridViewExcelFilter_2[this.dataGridViewTextBoxColumn_24.Name, e.RowIndex].Value) != this.int_0)
			{
				e.CellStyle.BackColor = Color.LightGray;
			}
		}

		private void toolStripMenuItem_7_Click(object sender, EventArgs e)
		{
			if (this.int_0 != -1)
			{
				FormTechConnectionDocOutAddEdit formTechConnectionDocOutAddEdit = new FormTechConnectionDocOutAddEdit(-1, this.int_0);
				formTechConnectionDocOutAddEdit.SqlSettings = this.SqlSettings;
				if (formTechConnectionDocOutAddEdit.ShowDialog() == DialogResult.OK)
				{
					this.method_0();
					this.dataGridViewExcelFilter_2.SearchGrid(this.dataGridViewTextBoxColumn_22.Name, formTechConnectionDocOutAddEdit.IdDocOut.ToString(), false);
				}
			}
		}

		private void toolStripMenuItem_6_Click(object sender, EventArgs e)
		{
			if (this.int_0 != -1)
			{
				Form19 form = new Form19(-1, this.int_0);
				form.SqlSettings = this.SqlSettings;
				form.MdiParent = base.MdiParent;
				form.FormClosed += this.method_5;
				form.Show();
			}
		}

		private void method_5(object sender, FormClosedEventArgs e)
		{
			int num = ((Form19)sender).method_0();
			this.method_0();
			this.dataGridViewExcelFilter_2.SearchGrid(this.dataGridViewTextBoxColumn_22.Name, num.ToString(), false);
		}

		private void toolStripButton_10_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_2.CurrentRow != null)
			{
				int num = Convert.ToInt32(this.dataGridViewExcelFilter_2.CurrentRow.Cells[this.dataGridViewTextBoxColumn_24.Name].Value);
				int num2 = Convert.ToInt32(this.dataGridViewExcelFilter_2.CurrentRow.Cells[this.dataGridViewTextBoxColumn_26.Name].Value);
				if (num != this.int_0)
				{
					MessageBox.Show("Невозможно редактировать данный документ");
					return;
				}
				int id = Convert.ToInt32(this.dataGridViewExcelFilter_2.CurrentRow.Cells[this.dataGridViewTextBoxColumn_22.Name].Value);
				if (num2 != 1125)
				{
					if (num2 != 1218)
					{
						FormTechConnectionDocOutAddEdit formTechConnectionDocOutAddEdit = new FormTechConnectionDocOutAddEdit(id, this.int_0);
						formTechConnectionDocOutAddEdit.SqlSettings = this.SqlSettings;
						if (formTechConnectionDocOutAddEdit.ShowDialog() == DialogResult.OK)
						{
							this.method_0();
							this.dataGridViewExcelFilter_2.SearchGrid(this.dataGridViewTextBoxColumn_22.Name, formTechConnectionDocOutAddEdit.IdDocOut.ToString(), false);
							return;
						}
						return;
					}
				}
				if (this.int_3 > 0)
				{
					Form19 form = new Form19(this.int_3, -1);
					form.SqlSettings = this.SqlSettings;
					form.FormClosed += this.method_5;
					form.Show();
					return;
				}
			}
		}

		private void toolStripButton_11_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_2.CurrentRow != null)
			{
				if (Convert.ToInt32(this.dataGridViewExcelFilter_2.CurrentRow.Cells[this.dataGridViewTextBoxColumn_24.Name].Value) != this.int_0)
				{
					MessageBox.Show("Невозможно удалить данный документ");
					return;
				}
				if (MessageBox.Show("Вы действительно хотите удалить текущий документ", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					Convert.ToInt32(this.dataGridViewExcelFilter_2.CurrentRow.Cells[this.dataGridViewTextBoxColumn_22.Name].Value);
					int id = Convert.ToInt32(this.dataGridViewExcelFilter_2.CurrentRow.Cells[this.dataGridViewTextBoxColumn_27.Name].Value);
					if (base.DeleteSqlDataById(this.class10_0.tTC_Doc, id))
					{
						this.dataGridViewExcelFilter_2.Rows.Remove(this.dataGridViewExcelFilter_2.CurrentRow);
						this.method_0();
						MessageBox.Show("Документ успешно удален");
					}
				}
			}
		}

		private void bindingSource_3_CurrentChanged(object sender, EventArgs e)
		{
			if (this.bindingSource_3.Current != null)
			{
				this.int_3 = Convert.ToInt32(((DataRowView)this.bindingSource_3.Current)["idDocOut"]);
				this.int_4 = Convert.ToInt32(((DataRowView)this.bindingSource_3.Current)["idDoc"]);
				this.method_6();
				return;
			}
			this.int_3 = -1;
			this.int_4 = -1;
			this.bindingSource_4.DataSource = null;
		}

		private void method_6()
		{
			Class10.Class25 @class = new Class10.Class25();
			base.SelectSqlData(@class, true, " where idDoc = " + this.int_3.ToString() + " order by dateChange desc", null, false, 0);
			this.bindingSource_4.DataSource = @class;
			this.dataGridViewTextBoxColumn_119.Visible = false;
		}

		private void toolStripButton_12_Click(object sender, EventArgs e)
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
					this.method_6();
				}
			}
		}

		private void toolStripButton_13_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_3.CurrentRow != null && this.int_3 != -1)
			{
				if (this.int_4 != this.int_0)
				{
					MessageBox.Show("Невозможно редактировать данный документ");
					return;
				}
				int num = Convert.ToInt32(this.dataGridViewExcelFilter_3.CurrentRow.Cells[this.dataGridViewTextBoxColumn_119.Name].Value);
				if (new Form14(num, this.int_3, true)
				{
					SqlSettings = this.SqlSettings
				}.ShowDialog() == DialogResult.OK)
				{
					this.method_6();
					this.dataGridViewExcelFilter_3.SearchGrid(this.dataGridViewTextBoxColumn_119.Name, num.ToString(), false);
				}
			}
		}

		private void toolStripButton_14_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_3.CurrentRow != null)
			{
				if (this.int_4 != this.int_0)
				{
					MessageBox.Show("Невозможно редактировать данный документ");
					return;
				}
				if (MessageBox.Show("Вы действительно хотите удалить текущий статус", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					int id = Convert.ToInt32(this.dataGridViewExcelFilter_3.CurrentRow.Cells[this.dataGridViewTextBoxColumn_119.Name].Value);
					if (base.DeleteSqlDataById(this.class10_0.tTC_DocStatus, id))
					{
						this.dataGridViewExcelFilter_3.Rows.Remove(this.dataGridViewExcelFilter_3.CurrentRow);
						MessageBox.Show("Статус успешно удален");
					}
				}
			}
		}

		private void toolStripButton_15_Click(object sender, EventArgs e)
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

		private void dataGridViewExcelFilter_5_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
		{
			((DataGridView)sender).AutoResizeRow(e.RowIndex);
		}

		private void toolStripButton_16_Click(object sender, EventArgs e)
		{
			if (this.int_0 != -1 && new Form20(-1, -1, this.int_0)
			{
				SqlSettings = this.SqlSettings
			}.ShowDialog() == DialogResult.OK)
			{
				this.method_0();
			}
		}

		private void toolStripButton_17_Click(object sender, EventArgs e)
		{
			if (this.int_0 != -1 && this.int_2 != -1 && new Form20(this.int_2, -1, -1)
			{
				SqlSettings = this.SqlSettings
			}.ShowDialog() == DialogResult.OK)
			{
				this.method_0();
			}
		}

		private void toolStripButton_18_Click(object sender, EventArgs e)
		{
			if (this.int_2 != -1 && this.int_0 != -1 && MessageBox.Show("Вы действительно хотите удалить договор", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes && base.DeleteSqlDataById(this.class10_0.tTC_Doc, this.int_2))
			{
				this.method_0();
				MessageBox.Show("Документ успешно удален");
			}
		}

		private void method_7()
		{
			base.SelectSqlData(this.class10_0, this.class10_0.vTC_Doc, true, " where idParent = " + this.int_0.ToString() + " order by dateDoc");
			DataRow[] array = this.class10_0.vTC_Doc.Select("typeDoc = " + 1238.ToString());
			if (array.Length != 0)
			{
				this.toolStripMenuItem_0.Enabled = false;
			}
			else
			{
				this.toolStripMenuItem_0.Enabled = true;
			}
			array = this.class10_0.vTC_Doc.Select("typeDoc = " + 1239.ToString());
			if (array.Length != 0)
			{
				this.toolStripMenuItem_1.Enabled = false;
			}
			else
			{
				this.toolStripMenuItem_1.Enabled = true;
			}
			array = this.class10_0.vTC_Doc.Select("typeDoc = " + 1240.ToString());
			if (array.Length != 0)
			{
				foreach (object obj in base.SelectSqlData("vActBalance", true, string.Concat(new string[]
				{
					" inner join tAbnObjDoc_AktRBP on tAbnObjDoc_AktRBP.idList = vActBalance.idList  where (tAbnObjDoc_AktRBP.idActTehConnection = ",
					Convert.ToInt32(array[0]["id"]).ToString(),
					" or tAbnObjDoc_AktRBP.idTU = ",
					this.int_0.ToString(),
					")"
				})).Rows)
				{
					DataRow dataRow = (DataRow)obj;
					DataRow dataRow2 = this.class10_0.vTC_Doc.NewRow();
					dataRow2["id"] = dataRow["idList"];
					dataRow2["numDoc"] = dataRow["actNumber"];
					dataRow2["dateDoc"] = dataRow["actDate"];
					dataRow2["typeDoc"] = dataRow["idDocType"];
					dataRow2["TypeDocName"] = dataRow["TypeDoc"];
					this.class10_0.vTC_Doc.Rows.Add(dataRow2);
					this.class10_0.vTC_Doc.AcceptChanges();
				}
				this.toolStripMenuItem_2.Enabled = false;
			}
			else
			{
				foreach (object obj2 in base.SelectSqlData("vActBalance", true, " inner join tAbnObjDoc_AktRBP on tAbnObjDoc_AktRBP.idList = vActBalance.idList  where tAbnObjDoc_AktRBP.idTU = " + this.int_0.ToString()).Rows)
				{
					DataRow dataRow3 = (DataRow)obj2;
					DataRow dataRow4 = this.class10_0.vTC_Doc.NewRow();
					dataRow4["id"] = dataRow3["idList"];
					dataRow4["numDoc"] = dataRow3["actNumber"];
					dataRow4["dateDoc"] = dataRow3["actDate"];
					dataRow4["typeDoc"] = dataRow3["idDocType"];
					dataRow4["TypeDocName"] = dataRow3["TypeDoc"];
					this.class10_0.vTC_Doc.Rows.Add(dataRow4);
					this.class10_0.vTC_Doc.AcceptChanges();
				}
				this.toolStripMenuItem_2.Enabled = true;
			}
			array = this.class10_0.vTC_Doc.Select("typeDoc = " + 497.ToString());
			if (array.Length != 0)
			{
				this.toolStripMenuItem_3.Enabled = false;
			}
			else
			{
				this.toolStripMenuItem_2.Enabled = false;
				this.toolStripMenuItem_3.Enabled = true;
			}
			array = this.class10_0.vTC_Doc.Select("typeDoc = " + 1246.ToString());
			if (array.Length != 0)
			{
				this.toolStripMenuItem_4.Enabled = false;
				return;
			}
			this.toolStripMenuItem_4.Enabled = true;
		}

		private void bindingSource_7_CurrentChanged(object sender, EventArgs e)
		{
			if (this.bindingSource_7.Current == null)
			{
				this.dataTable_0.Clear();
				return;
			}
			int num = Convert.ToInt32(((DataRowView)this.bindingSource_7.Current)["id"]);
			int num2 = Convert.ToInt32(((DataRowView)this.bindingSource_7.Current)["TypeDoc"]);
			if (num2 != 497 && num2 != 1246)
			{
				this.bindingSource_8.DataSource = this.dataTable_0;
				base.SelectSqlData(this.dataTable_0, true, " where idDoc = " + num.ToString() + " order by filename", null, false, 0);
				return;
			}
			this.bindingSource_8.DataSource = this.dataTable_1;
			base.SelectSqlData(this.dataTable_1, true, " where idList = " + num.ToString() + " order by filename", null, false, 0);
		}

		private void toolStripDropDownButton_0_Click(object sender, EventArgs e)
		{
		}

		private void toolStripMenuItem_0_Click(object sender, EventArgs e)
		{
			FormActElectricalInspection formActElectricalInspection = new FormActElectricalInspection(-1, this.int_0, 1238);
			formActElectricalInspection.SqlSettings = this.SqlSettings;
			formActElectricalInspection.MdiParent = base.MdiParent;
			formActElectricalInspection.FormClosed += this.method_8;
			formActElectricalInspection.Show();
		}

		private void toolStripMenuItem_1_Click(object sender, EventArgs e)
		{
			FormActPerformingTU formActPerformingTU = new FormActPerformingTU(-1, this.int_0, 1239);
			formActPerformingTU.SqlSettings = this.SqlSettings;
			formActPerformingTU.MdiParent = base.MdiParent;
			formActPerformingTU.FormClosed += this.method_8;
			formActPerformingTU.Show();
		}

		private void toolStripMenuItem_2_Click(object sender, EventArgs e)
		{
			FormTCAddEdit formTCAddEdit = new FormTCAddEdit(-1, this.int_0);
			formTCAddEdit.SqlSettings = this.SqlSettings;
			formTCAddEdit.MdiParent = base.MdiParent;
			formTCAddEdit.FormClosed += this.method_8;
			formTCAddEdit.Show();
		}

		private void toolStripMenuItem_3_Click(object sender, EventArgs e)
		{
			int idActTeh = -1;
			DataRow[] array = this.class10_0.vTC_Doc.Select("typeDoc = " + 1240.ToString());
			if (array.Length != 0)
			{
				idActTeh = Convert.ToInt32(array[0]["id"]);
			}
			FormAbnAktRBP formAbnAktRBP = new FormAbnAktRBP(this.SqlSettings, idActTeh, this.int_0, TypeDocValue.ActBalance);
			formAbnAktRBP.SqlSettings = this.SqlSettings;
			formAbnAktRBP.MdiParent = base.MdiParent;
			formAbnAktRBP.FormClosed += this.method_8;
			formAbnAktRBP.Show();
		}

		private void sidcIfjxrO(object sender, EventArgs e)
		{
			int idActTeh = -1;
			DataRow[] array = this.class10_0.vTC_Doc.Select("typeDoc = " + 1240.ToString());
			if (array.Length != 0)
			{
				idActTeh = Convert.ToInt32(array[0]["id"]);
			}
			FormAbnAktRBP formAbnAktRBP = new FormAbnAktRBP(this.SqlSettings, idActTeh, this.int_0, TypeDocValue.ActLiability);
			formAbnAktRBP.SqlSettings = this.SqlSettings;
			formAbnAktRBP.MdiParent = base.MdiParent;
			formAbnAktRBP.FormClosed += this.method_8;
			formAbnAktRBP.Show();
		}

		private void toolStripButton_19_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_7.CurrentRow != null)
			{
				int num = Convert.ToInt32(this.dataGridViewExcelFilter_7.CurrentRow.Cells[this.dataGridViewTextBoxColumn_113.Name].Value);
				if (num <= 1239)
				{
					if (num == 497)
					{
						goto IL_143;
					}
					if (num == 1239)
					{
						FormActPerformingTU formActPerformingTU = new FormActPerformingTU(Convert.ToInt32(this.dataGridViewExcelFilter_7.CurrentRow.Cells[this.dataGridViewTextBoxColumn_112.Name].Value), this.int_0, 1239);
						formActPerformingTU.SqlSettings = this.SqlSettings;
						formActPerformingTU.MdiParent = base.MdiParent;
						formActPerformingTU.FormClosed += this.method_8;
						formActPerformingTU.Show();
						return;
					}
				}
				else
				{
					if (num == 1240)
					{
						FormTCAddEdit formTCAddEdit = new FormTCAddEdit(Convert.ToInt32(this.dataGridViewExcelFilter_7.CurrentRow.Cells[this.dataGridViewTextBoxColumn_112.Name].Value), this.int_0);
						formTCAddEdit.SqlSettings = this.SqlSettings;
						formTCAddEdit.MdiParent = base.MdiParent;
						formTCAddEdit.FormClosed += this.method_8;
						formTCAddEdit.Show();
						return;
					}
					if (num == 1246)
					{
						goto IL_143;
					}
				}
				FormActElectricalInspection formActElectricalInspection = new FormActElectricalInspection(Convert.ToInt32(this.dataGridViewExcelFilter_7.CurrentRow.Cells[this.dataGridViewTextBoxColumn_112.Name].Value), this.int_0, 1238);
				formActElectricalInspection.SqlSettings = this.SqlSettings;
				formActElectricalInspection.MdiParent = base.MdiParent;
				formActElectricalInspection.FormClosed += this.method_8;
				formActElectricalInspection.Show();
				return;
				IL_143:
				FormAbnAktRBP formAbnAktRBP = new FormAbnAktRBP(this.SqlSettings, -1, Convert.ToInt32(this.dataGridViewExcelFilter_7.CurrentRow.Cells[this.dataGridViewTextBoxColumn_112.Name].Value));
				formAbnAktRBP.SqlSettings = this.SqlSettings;
				formAbnAktRBP.MdiParent = base.MdiParent;
				formAbnAktRBP.FormClosed += this.method_8;
				formAbnAktRBP.Show();
				return;
			}
		}

		private void method_8(object sender, FormClosedEventArgs e)
		{
			this.method_7();
		}

		private void toolStripButton_20_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_7.CurrentRow != null && MessageBox.Show("Вы действительно хотите удалить текущий документ?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				int num = Convert.ToInt32(this.dataGridViewExcelFilter_7.CurrentRow.Cells[this.dataGridViewTextBoxColumn_113.Name].Value);
				if (num != 497)
				{
					if (num != 1246)
					{
						if (base.DeleteSqlDataById(this.class10_0.tTC_Doc, Convert.ToInt32(this.dataGridViewExcelFilter_7.CurrentRow.Cells[this.dataGridViewTextBoxColumn_112.Name].Value)))
						{
							this.method_7();
							MessageBox.Show("Документ успешно удален");
							return;
						}
						return;
					}
				}
				int num2 = Convert.ToInt32(this.dataGridViewExcelFilter_7.CurrentRow.Cells[this.dataGridViewTextBoxColumn_112.Name].Value);
				System.Data.DataTable dataTable = base.SelectSqlData("tAbnObjDoc_List", true, "where id = " + num2);
				foreach (object obj in dataTable.Columns)
				{
					DataColumn dataColumn = (DataColumn)obj;
					if (dataColumn.ColumnName.ToUpper() == "id".ToUpper())
					{
						dataTable.PrimaryKey = new DataColumn[]
						{
							dataColumn
						};
						break;
					}
				}
				if (dataTable.Rows.Count > 0)
				{
					dataTable.Rows[0]["deleted"] = true;
					dataTable.Rows[0].EndEdit();
					if (base.UpdateSqlData(dataTable))
					{
						this.method_7();
						MessageBox.Show("Документ успешно удален");
						return;
					}
				}
			}
		}

		private void toolStripButton_21_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_7.CurrentRow != null)
			{
				int num = Convert.ToInt32(this.dataGridViewExcelFilter_7.CurrentRow.Cells[this.dataGridViewTextBoxColumn_113.Name].Value);
				if (num != 497)
				{
					if (num == 1246)
					{
						MessageBox.Show("Для данного акта не предусмотрена печатная форма.");
						return;
					}
					new FormReportActElectricalInspection(Convert.ToInt32(this.dataGridViewExcelFilter_7.CurrentRow.Cells[this.dataGridViewTextBoxColumn_112.Name].Value))
					{
						SqlSettings = this.SqlSettings,
						MdiParent = base.MdiParent
					}.Show();
				}
			}
		}

		private void zDiccocdp8(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && this.toolStripButton_19.Enabled && this.toolStripButton_19.Visible)
			{
				this.toolStripButton_19_Click(sender, e);
			}
		}

		private void dataGridViewExcelFilter_6_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			DataGridView dataGridView = (DataGridView)sender;
			if (dataGridView.CurrentRow == null)
			{
				return;
			}
			int num = Convert.ToInt32(dataGridView.CurrentRow.Cells[this.dataGridViewTextBoxColumn_43.Name].Value);
			if (e.ColumnIndex == dataGridView.Columns[this.dataGridViewLinkColumn_1.Name].Index)
			{
				SqlDataCommand sqlDataCommand = new SqlDataCommand(this.SqlSettings);
				System.Data.DataTable dataTable = new System.Data.DataTable();
				if (this.bindingSource_8.DataSource == this.dataTable_0)
				{
					dataTable = sqlDataCommand.SelectSqlData("select [FileName], [File] from [tTC_DocFile] where id = " + num.ToString());
				}
				if (this.bindingSource_8.DataSource == this.dataTable_1)
				{
					dataTable = sqlDataCommand.SelectSqlData("select [FileName], [File] from [tAbnObjDoc_File] where id = " + num.ToString());
				}
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

		private void dataGridViewExcelFilter_6_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
		{
			DataGridView dataGridView = (DataGridView)sender;
			if (dataGridView.RowCount > 0 && dataGridView[this.dataGridViewLinkColumn_1.Name, e.RowIndex].Value != null && e.ColumnIndex == dataGridView.Columns[this.dataGridViewImageColumnNotNull_1.Name].Index)
			{
				Icon icon = FormLbr.Classes.FileInfo.IconOfFile(dataGridView[this.dataGridViewLinkColumn_1.Name, e.RowIndex].Value.ToString());
				if (icon != null)
				{
					e.Value = icon.ToBitmap();
				}
			}
		}

		private void tabControl_0_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.tabControl_0.SelectedTab == this.tabPage_5)
			{
				this.method_15(false);
			}
		}

		private int method_9()
		{
			int count = base.SelectSqlData("tUser", true, "WHERE [Login] LIKE SYSTEM_USER").Rows.Count;
			return 213;
		}

		private int method_10(string string_0)
		{
			System.Data.DataTable dataTable = base.SelectSqlData("tUser", true, "WHERE [Login] LIKE '" + string_0 + "'");
			if (dataTable.Rows.Count > 0)
			{
				return (int)dataTable.Rows[0]["IDUser"];
			}
			return -1;
		}

		private int method_11(string string_0)
		{
			System.Data.DataTable dataTable = base.SelectSqlData("tR_Worker", true, "WHERE F + ' ' + I + ' ' + O LIKE '" + string_0 + "'");
			if (dataTable.Rows.Count > 0)
			{
				return (int)dataTable.Rows[0]["ID"];
			}
			return -1;
		}

		private void pcueoNrZpi_Click(object sender, EventArgs e)
		{
			Form37 form = new Form37();
			form.SqlSettings = this.SqlSettings;
			form.MdiParent = base.MdiParent;
			form.method_1(this.int_0);
			form.idUser = this.method_9();
			form.method_5(StateFormCreate.Add);
			form.FormClosed += this.method_12;
			form.Show();
		}

		private void toolStripMenuItem_5_Click(object sender, EventArgs e)
		{
			FormMemorandumJournal formMemorandumJournal = new FormMemorandumJournal(StateFormCreate.Add);
			formMemorandumJournal.MdiParent = base.MdiParent;
			formMemorandumJournal.SqlSettings = this.SqlSettings;
			formMemorandumJournal.IdTU = this.int_0;
			formMemorandumJournal.FormClosed += this.method_12;
			formMemorandumJournal.Show();
		}

		private void method_12(object sender, FormClosedEventArgs e)
		{
			if (sender is FormMemorandumJournal)
			{
				this.method_15(false);
			}
			if (sender is Form37)
			{
				this.method_14(((Form37)sender).method_2());
			}
		}

		private void toolStripButton_22_Click(object sender, EventArgs e)
		{
			this.method_13();
		}

		private void method_13()
		{
			if (this.bindingSource_9.Current != null && MessageBox.Show("Вы действительно хотите удалить текущую запись?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				EnumerableRowCollection<Class10.Class107> source = this.class10_0.tJ_Memorandum.Where(new Func<Class10.Class107, bool>(this.method_21));
				if (source.Count<Class10.Class107>() > 0)
				{
					source.First<Class10.Class107>().Deleted = true;
					if (base.UpdateSqlData(this.class10_0.tJ_Memorandum))
					{
						this.class10_0.tJ_Memorandum.AcceptChanges();
						MessageBox.Show("Запись успешно удалена.");
						this.method_15(false);
					}
				}
			}
		}

		private void toolStripButton_23_Click(object sender, EventArgs e)
		{
			this.method_15(true);
		}

		private void method_14(int int_5)
		{
			this.method_15(false);
			this.bindingSource_9.Position = this.bindingSource_9.Find("id", int_5);
		}

		private void method_15(bool bool_0)
		{
			bool_0 = (bool_0 ? (this.bindingSource_9.Current != null) : bool_0);
			int num = -1;
			if (bool_0)
			{
				num = (int)((DataRowView)this.bindingSource_9.Current)["id"];
			}
			base.SelectSqlData(this.class10_0, this.class10_0.tJ_Memorandum, true, string.Format("WHERE idWorker = {0} AND idTehConnect = {1} AND Deleted = 0", this.method_9(), this.int_0));
			base.SelectSqlData(this.class10_0, this.class10_0.vJ_Memorandum, true, string.Format("WHERE idWorker = {0} AND idTehConnect = {1} AND Deleted = 0", this.method_9(), this.int_0));
			if (bool_0)
			{
				this.bindingSource_9.Position = this.bindingSource_9.Find("id", num);
			}
		}

		private void backgroundWorker_0_DoWork(object sender, DoWorkEventArgs e)
		{
		}

		private void backgroundWorker_0_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.toolStripButton_23.Enabled = true;
		}

		private void dataGridViewExcelFilter_8_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
		}

		private void toolStripButton_24_Click(object sender, EventArgs e)
		{
			this.method_16();
		}

		private void dataGridViewExcelFilter_8_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex != -1 && e.RowIndex != -1)
			{
				this.method_16();
			}
		}

		private void method_16()
		{
			if (this.bindingSource_9.Current != null)
			{
				Form37 form = new Form37();
				form.SqlSettings = this.SqlSettings;
				form.MdiParent = base.MdiParent;
				form.method_1(this.int_0);
				form.idUser = this.method_9();
				form.method_3((int)((DataRowView)this.bindingSource_9.Current)["id"]);
				form.method_5(StateFormCreate.View);
				form.FormClosed += this.method_12;
				form.Show();
			}
		}

		private void method_17()
		{
			if (this.bindingSource_9.Current != null)
			{
				if (((DataRowView)this.bindingSource_9.Current)["Status"].ToString() == "Отправлен" || ((DataRowView)this.bindingSource_9.Current)["Status"].ToString() == "Документ получен адресатом")
				{
					MessageBox.Show("Вы не можете править этот документ!", "Предупреждение.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
				Form37 form = new Form37();
				form.SqlSettings = this.SqlSettings;
				form.MdiParent = base.MdiParent;
				form.idUser = this.method_9();
				form.method_3((int)((DataRowView)this.bindingSource_9.Current)["id"]);
				form.method_5(StateFormCreate.Edit);
				form.FormClosed += this.method_12;
				form.Show();
			}
		}

		private void toolStripButton_25_Click(object sender, EventArgs e)
		{
			this.method_17();
		}

		private void method_18()
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

		private List<int> method_19(TreeNodeCollection treeNodeCollection_0)
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
					list.AddRange(this.method_19(treeNode.Nodes));
				}
			}
			return list;
		}

		private void method_20()
		{
			this.icontainer_0 = new Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FormJournalTU));
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
			DataGridViewCellStyle dataGridViewCellStyle30 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle31 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle32 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle33 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle34 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle35 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle36 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle37 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle38 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle39 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle40 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle41 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle42 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle43 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle44 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle45 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle46 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle47 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle48 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle49 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle50 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle51 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle52 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle53 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle54 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle55 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle56 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle57 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle58 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle59 = new DataGridViewCellStyle();
			this.toolStrip_0 = new ToolStrip();
			this.toolStripButton_0 = new ToolStripButton();
			this.toolStripButton_1 = new ToolStripButton();
			this.toolStripButton_2 = new ToolStripButton();
			this.toolStripSeparator_2 = new ToolStripSeparator();
			this.toolStripButton_9 = new ToolStripButton();
			this.toolStripSeparator_0 = new ToolStripSeparator();
			this.toolStripButton_3 = new ToolStripButton();
			this.toolStripSeparator_1 = new ToolStripSeparator();
			this.toolStripButton_4 = new ToolStripButton();
			this.toolStripTextBox_0 = new ToolStripTextBox();
			this.toolStripButton_5 = new ToolStripButton();
			this.toolStripButton_6 = new ToolStripButton();
			this.toolStripButton_15 = new ToolStripButton();
			this.toolStripSeparator_3 = new ToolStripSeparator();
			this.QxUkSviJgI = new ToolStripButton();
			this.FkSanDtyTi = new DataGridViewExcelFilter();
			this.dataGridViewCheckBoxColumn_0 = new DataGridViewCheckBoxColumn();
			this.dataGridViewTextBoxColumn_137 = new DataGridViewTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_17 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_18 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_19 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewTextBoxColumn_138 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_139 = new DataGridViewTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_20 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewTextBoxColumn_140 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_141 = new DataGridViewTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_21 = new DataGridViewFilterTextBoxColumn();
			this.lHbekeicuS = new DataGridViewTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_22 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_23 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewTextBoxColumn_142 = new DataGridViewTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_24 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_25 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_26 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_27 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewTextBoxColumn_143 = new DataGridViewTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_28 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewTextBoxColumn_144 = new DataGridViewTextBoxColumn();
			this.waFeUdmntD = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_29 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_30 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewTextBoxColumn_145 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_146 = new DataGridViewTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_31 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_32 = new DataGridViewFilterTextBoxColumn();
			this.bindingSource_0 = new BindingSource(this.icontainer_0);
			this.class10_0 = new Class10();
			this.splitContainer_0 = new SplitContainer();
			this.treeView_0 = new TreeView();
			this.label_5 = new System.Windows.Forms.Label();
			this.dateTimePicker_0 = new DateTimePicker();
			this.label_0 = new System.Windows.Forms.Label();
			this.dateTimePicker_1 = new DateTimePicker();
			this.label_1 = new System.Windows.Forms.Label();
			this.toolStrip_1 = new ToolStrip();
			this.toolStripButton_7 = new ToolStripButton();
			this.toolStripButton_8 = new ToolStripButton();
			this.splitContainer_1 = new SplitContainer();
			this.tabControl_0 = new TabControl();
			this.tabPage_0 = new TabPage();
			this.dataGridViewExcelFilter_0 = new DataGridViewExcelFilter();
			this.dataGridViewLinkColumn_0 = new DataGridViewLinkColumn();
			this.dataGridViewImageColumnNotNull_0 = new DataGridViewImageColumnNotNull();
			this.dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_3 = new DataGridViewTextBoxColumn();
			this.bindingSource_1 = new BindingSource(this.icontainer_0);
			this.tabPage_1 = new TabPage();
			this.dataGridViewExcelFilter_1 = new DataGridViewExcelFilter();
			this.dataGridViewTextBoxColumn_4 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_14 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_5 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_6 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_7 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_8 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_9 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_10 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_11 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_12 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_13 = new DataGridViewTextBoxColumn();
			this.alragsoaPf = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_15 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_16 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_17 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_18 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_19 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_20 = new DataGridViewTextBoxColumn();
			this.bindingSource_2 = new BindingSource(this.icontainer_0);
			this.tabPage_3 = new TabPage();
			this.splitContainer_3 = new SplitContainer();
			this.dataGridViewExcelFilter_4 = new DataGridViewExcelFilter();
			this.dataGridViewTextBoxColumn_33 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_34 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_35 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_36 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_37 = new DataGridViewTextBoxColumn();
			this.bindingSource_5 = new BindingSource(this.icontainer_0);
			this.dataGridViewExcelFilter_5 = new DataGridViewExcelFilter();
			this.dataGridViewTextBoxColumn_38 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_39 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_40 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_41 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_42 = new DataGridViewTextBoxColumn();
			this.bindingSource_6 = new BindingSource(this.icontainer_0);
			this.tabPage_2 = new TabPage();
			this.splitContainer_2 = new SplitContainer();
			this.dataGridViewExcelFilter_2 = new DataGridViewExcelFilter();
			this.dataGridViewTextBoxColumn_21 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_22 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_23 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_24 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_25 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_26 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_27 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_28 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_29 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_30 = new DataGridViewTextBoxColumn();
			this.ymuksnNoEU = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_31 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_32 = new DataGridViewTextBoxColumn();
			this.bindingSource_3 = new BindingSource(this.icontainer_0);
			this.toolStrip_2 = new ToolStrip();
			this.toolStripButton_10 = new ToolStripButton();
			this.toolStripButton_11 = new ToolStripButton();
			this.dataGridViewExcelFilter_3 = new DataGridViewExcelFilter();
			this.dataGridViewTextBoxColumn_115 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_116 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_117 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_118 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_119 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_120 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_121 = new DataGridViewTextBoxColumn();
			this.bindingSource_4 = new BindingSource(this.icontainer_0);
			this.toolStrip_3 = new ToolStrip();
			this.toolStripButton_12 = new ToolStripButton();
			this.toolStripButton_13 = new ToolStripButton();
			this.toolStripButton_14 = new ToolStripButton();
			this.tabPage_4 = new TabPage();
			this.richTextBox_0 = new RichTextBox();
			this.class10_1 = new Class10();
			this.label_2 = new System.Windows.Forms.Label();
			this.dateTimePicker_2 = new DateTimePicker();
			this.label_3 = new System.Windows.Forms.Label();
			this.textBox_0 = new System.Windows.Forms.TextBox();
			this.label_4 = new System.Windows.Forms.Label();
			this.toolStrip_4 = new ToolStrip();
			this.toolStripButton_16 = new ToolStripButton();
			this.toolStripButton_17 = new ToolStripButton();
			this.toolStripButton_18 = new ToolStripButton();
			this.pevkEfUdfJ = new TabPage();
			this.splitContainer_4 = new SplitContainer();
			this.dataGridViewExcelFilter_7 = new DataGridViewExcelFilter();
			this.dataGridViewTextBoxColumn_108 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_109 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_110 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_111 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_112 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_113 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_114 = new DataGridViewTextBoxColumn();
			this.bindingSource_7 = new BindingSource(this.icontainer_0);
			this.toolStrip_5 = new ToolStrip();
			this.toolStripDropDownButton_0 = new ToolStripDropDownButton();
			this.toolStripMenuItem_0 = new ToolStripMenuItem();
			this.toolStripMenuItem_1 = new ToolStripMenuItem();
			this.toolStripMenuItem_2 = new ToolStripMenuItem();
			this.toolStripMenuItem_3 = new ToolStripMenuItem();
			this.toolStripMenuItem_4 = new ToolStripMenuItem();
			this.toolStripButton_19 = new ToolStripButton();
			this.toolStripButton_20 = new ToolStripButton();
			this.toolStripSeparator_4 = new ToolStripSeparator();
			this.toolStripButton_21 = new ToolStripButton();
			this.dataGridViewExcelFilter_6 = new DataGridViewExcelFilter();
			this.dataGridViewLinkColumn_1 = new DataGridViewLinkColumn();
			this.dataGridViewTextBoxColumn_43 = new DataGridViewTextBoxColumn();
			this.dataGridViewImageColumnNotNull_1 = new DataGridViewImageColumnNotNull();
			this.bindingSource_8 = new BindingSource(this.icontainer_0);
			this.dataSet_0 = new DataSet();
			this.dataTable_0 = new System.Data.DataTable();
			this.dataColumn_0 = new DataColumn();
			this.dataColumn_1 = new DataColumn();
			this.dataTable_1 = new System.Data.DataTable();
			this.dataColumn_2 = new DataColumn();
			this.dataColumn_3 = new DataColumn();
			this.tabPage_5 = new TabPage();
			this.dataGridViewExcelFilter_8 = new DataGridViewExcelFilter();
			this.dataGridViewTextBoxColumn_122 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_123 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_124 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_125 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_126 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_127 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_128 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_129 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_130 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_131 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_132 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_133 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_134 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_135 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_136 = new DataGridViewTextBoxColumn();
			this.bindingSource_9 = new BindingSource(this.icontainer_0);
			this.toolStrip_6 = new ToolStrip();
			this.toolStripSplitButton_0 = new ToolStripSplitButton();
			this.pcueoNrZpi = new ToolStripMenuItem();
			this.toolStripMenuItem_5 = new ToolStripMenuItem();
			this.toolStripButton_25 = new ToolStripButton();
			this.toolStripButton_24 = new ToolStripButton();
			this.toolStripButton_22 = new ToolStripButton();
			this.toolStripSeparator_5 = new ToolStripSeparator();
			this.toolStripButton_23 = new ToolStripButton();
			this.dataGridViewFilterTextBoxColumn_0 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_1 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_2 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_3 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_4 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_5 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_6 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewTextBoxColumn_44 = new DataGridViewTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_7 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_8 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_9 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_10 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewTextBoxColumn_45 = new DataGridViewTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_11 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewTextBoxColumn_46 = new DataGridViewTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_12 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_13 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_14 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewTextBoxColumn_47 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_48 = new DataGridViewTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_15 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_16 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewTextBoxColumn_49 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_50 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_51 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_52 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_53 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_54 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_55 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_56 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_57 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_58 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_59 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_60 = new DataGridViewTextBoxColumn();
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
			this.dataGridViewTextBoxColumn_79 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_80 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_81 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_82 = new DataGridViewTextBoxColumn();
			this.eedhdsdanG = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_83 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_84 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_85 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_86 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_87 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_88 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_89 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_90 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_91 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_92 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_93 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_94 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_95 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_96 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_97 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_98 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_99 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_100 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_101 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_102 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_103 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_104 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_105 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_106 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_107 = new DataGridViewTextBoxColumn();
			this.backgroundWorker_0 = new BackgroundWorker();
			this.toolStripDropDownButton_1 = new ToolStripDropDownButton();
			this.toolStripMenuItem_6 = new ToolStripMenuItem();
			this.toolStripSeparator_6 = new ToolStripSeparator();
			this.toolStripMenuItem_7 = new ToolStripMenuItem();
			this.toolStrip_0.SuspendLayout();
			((ISupportInitialize)this.FkSanDtyTi).BeginInit();
			((ISupportInitialize)this.bindingSource_0).BeginInit();
			((ISupportInitialize)this.class10_0).BeginInit();
			this.splitContainer_0.Panel1.SuspendLayout();
			this.splitContainer_0.Panel2.SuspendLayout();
			this.splitContainer_0.SuspendLayout();
			this.toolStrip_1.SuspendLayout();
			this.splitContainer_1.Panel1.SuspendLayout();
			this.splitContainer_1.Panel2.SuspendLayout();
			this.splitContainer_1.SuspendLayout();
			this.tabControl_0.SuspendLayout();
			this.tabPage_0.SuspendLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_0).BeginInit();
			((ISupportInitialize)this.bindingSource_1).BeginInit();
			this.tabPage_1.SuspendLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_1).BeginInit();
			((ISupportInitialize)this.bindingSource_2).BeginInit();
			this.tabPage_3.SuspendLayout();
			this.splitContainer_3.Panel1.SuspendLayout();
			this.splitContainer_3.Panel2.SuspendLayout();
			this.splitContainer_3.SuspendLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_4).BeginInit();
			((ISupportInitialize)this.bindingSource_5).BeginInit();
			((ISupportInitialize)this.dataGridViewExcelFilter_5).BeginInit();
			((ISupportInitialize)this.bindingSource_6).BeginInit();
			this.tabPage_2.SuspendLayout();
			this.splitContainer_2.Panel1.SuspendLayout();
			this.splitContainer_2.Panel2.SuspendLayout();
			this.splitContainer_2.SuspendLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_2).BeginInit();
			((ISupportInitialize)this.bindingSource_3).BeginInit();
			this.toolStrip_2.SuspendLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_3).BeginInit();
			((ISupportInitialize)this.bindingSource_4).BeginInit();
			this.toolStrip_3.SuspendLayout();
			this.tabPage_4.SuspendLayout();
			((ISupportInitialize)this.class10_1).BeginInit();
			this.toolStrip_4.SuspendLayout();
			this.pevkEfUdfJ.SuspendLayout();
			this.splitContainer_4.Panel1.SuspendLayout();
			this.splitContainer_4.Panel2.SuspendLayout();
			this.splitContainer_4.SuspendLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_7).BeginInit();
			((ISupportInitialize)this.bindingSource_7).BeginInit();
			this.toolStrip_5.SuspendLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_6).BeginInit();
			((ISupportInitialize)this.bindingSource_8).BeginInit();
			((ISupportInitialize)this.dataSet_0).BeginInit();
			((ISupportInitialize)this.dataTable_0).BeginInit();
			((ISupportInitialize)this.dataTable_1).BeginInit();
			this.tabPage_5.SuspendLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_8).BeginInit();
			((ISupportInitialize)this.bindingSource_9).BeginInit();
			this.toolStrip_6.SuspendLayout();
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
				this.toolStripSeparator_1,
				this.toolStripButton_4,
				this.toolStripTextBox_0,
				this.toolStripButton_5,
				this.toolStripButton_6,
				this.toolStripButton_15,
				this.toolStripSeparator_3,
				this.QxUkSviJgI
			});
			this.toolStrip_0.Location = new System.Drawing.Point(0, 0);
			this.toolStrip_0.Name = "toolStrip";
			this.toolStrip_0.Size = new Size(964, 25);
			this.toolStrip_0.TabIndex = 0;
			this.toolStrip_0.Text = "toolStrip1";
			this.toolStripButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_0.Image = (Image)componentResourceManager.GetObject("toolBtnAddTU.Image");
			this.toolStripButton_0.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_0.Name = "toolBtnAddTU";
			this.toolStripButton_0.Size = new Size(23, 22);
			this.toolStripButton_0.Text = "Добавить тех уловие";
			this.toolStripButton_0.Click += this.toolStripButton_0_Click;
			this.toolStripButton_1.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_1.Image = (Image)componentResourceManager.GetObject("toolBtnEditTU.Image");
			this.toolStripButton_1.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_1.Name = "toolBtnEditTU";
			this.toolStripButton_1.Size = new Size(23, 22);
			this.toolStripButton_1.Text = "Редактировать тех условие";
			this.toolStripButton_1.Click += this.toolStripButton_1_Click;
			this.toolStripButton_2.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_2.Image = (Image)componentResourceManager.GetObject("toolBtnDelTU.Image");
			this.toolStripButton_2.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_2.Name = "toolBtnDelTU";
			this.toolStripButton_2.Size = new Size(23, 22);
			this.toolStripButton_2.Text = "Удалить тех условие";
			this.toolStripButton_2.Click += this.toolStripButton_2_Click;
			this.toolStripSeparator_2.Name = "toolStripSeparator3";
			this.toolStripSeparator_2.Size = new Size(6, 25);
			this.toolStripButton_9.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_9.Image = (Image)componentResourceManager.GetObject("toolBtnRefresh.Image");
			this.toolStripButton_9.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_9.Name = "toolBtnRefresh";
			this.toolStripButton_9.Size = new Size(23, 22);
			this.toolStripButton_9.Text = "Обновить";
			this.toolStripButton_9.Click += this.toolStripButton_9_Click;
			this.toolStripSeparator_0.Name = "toolStripSeparator1";
			this.toolStripSeparator_0.Size = new Size(6, 25);
			this.toolStripButton_3.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_3.Image = (Image)componentResourceManager.GetObject("toolBtnShowRequest.Image");
			this.toolStripButton_3.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_3.Name = "toolBtnShowRequest";
			this.toolStripButton_3.Size = new Size(23, 22);
			this.toolStripButton_3.Text = "Открыть заявку";
			this.toolStripButton_3.Click += this.toolStripButton_3_Click;
			this.toolStripSeparator_1.Name = "toolStripSeparator2";
			this.toolStripSeparator_1.Size = new Size(6, 25);
			this.toolStripButton_4.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_4.Image = (Image)componentResourceManager.GetObject("toolBtnFind.Image");
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
			this.toolStripButton_5.Image = (Image)componentResourceManager.GetObject("toolBtnFindPrev.Image");
			this.toolStripButton_5.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_5.Name = "toolBtnFindPrev";
			this.toolStripButton_5.Size = new Size(23, 22);
			this.toolStripButton_5.Text = "Поиск назад";
			this.toolStripButton_5.Click += this.toolStripButton_5_Click;
			this.toolStripButton_6.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_6.Image = (Image)componentResourceManager.GetObject("toolBtnFindNext.Image");
			this.toolStripButton_6.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_6.Name = "toolBtnFindNext";
			this.toolStripButton_6.Size = new Size(23, 22);
			this.toolStripButton_6.Text = "Поиск вперед";
			this.toolStripButton_6.Click += this.toolStripButton_6_Click;
			this.toolStripButton_15.Alignment = ToolStripItemAlignment.Right;
			this.toolStripButton_15.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_15.Image = (Image)componentResourceManager.GetObject("toolBtnLoadold.Image");
			this.toolStripButton_15.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_15.Name = "toolBtnLoadold";
			this.toolStripButton_15.Size = new Size(23, 22);
			this.toolStripButton_15.Text = "Загрузка из старой базы";
			this.toolStripButton_15.Click += this.toolStripButton_15_Click;
			this.toolStripSeparator_3.Name = "toolStripSeparator4";
			this.toolStripSeparator_3.Size = new Size(6, 25);
			this.QxUkSviJgI.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.QxUkSviJgI.Image = (Image)componentResourceManager.GetObject("toolBtnExportExcel.Image");
			this.QxUkSviJgI.ImageTransparentColor = Color.Magenta;
			this.QxUkSviJgI.Name = "toolBtnExportExcel";
			this.QxUkSviJgI.Size = new Size(23, 22);
			this.QxUkSviJgI.Text = "Экспорт в Excel";
			this.QxUkSviJgI.Click += this.QxUkSviJgI_Click;
			this.FkSanDtyTi.AllowUserToAddRows = false;
			this.FkSanDtyTi.AllowUserToDeleteRows = false;
			this.FkSanDtyTi.AllowUserToOrderColumns = true;
			this.FkSanDtyTi.AutoGenerateColumns = false;
			dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle.BackColor = SystemColors.Control;
			dataGridViewCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
			this.FkSanDtyTi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
			this.FkSanDtyTi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.FkSanDtyTi.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewCheckBoxColumn_0,
				this.dataGridViewTextBoxColumn_137,
				this.dataGridViewFilterTextBoxColumn_17,
				this.dataGridViewFilterTextBoxColumn_18,
				this.dataGridViewFilterTextBoxColumn_19,
				this.dataGridViewTextBoxColumn_138,
				this.dataGridViewTextBoxColumn_139,
				this.dataGridViewFilterTextBoxColumn_20,
				this.dataGridViewTextBoxColumn_140,
				this.dataGridViewTextBoxColumn_141,
				this.dataGridViewFilterTextBoxColumn_21,
				this.lHbekeicuS,
				this.dataGridViewFilterTextBoxColumn_22,
				this.dataGridViewFilterTextBoxColumn_23,
				this.dataGridViewTextBoxColumn_142,
				this.dataGridViewFilterTextBoxColumn_24,
				this.dataGridViewFilterTextBoxColumn_25,
				this.dataGridViewFilterTextBoxColumn_26,
				this.dataGridViewFilterTextBoxColumn_27,
				this.dataGridViewTextBoxColumn_143,
				this.dataGridViewFilterTextBoxColumn_28,
				this.dataGridViewTextBoxColumn_144,
				this.waFeUdmntD,
				this.dataGridViewFilterTextBoxColumn_29,
				this.dataGridViewFilterTextBoxColumn_30,
				this.dataGridViewTextBoxColumn_145,
				this.dataGridViewTextBoxColumn_146,
				this.dataGridViewFilterTextBoxColumn_31,
				this.dataGridViewFilterTextBoxColumn_32
			});
			this.FkSanDtyTi.DataSource = this.bindingSource_0;
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
			this.FkSanDtyTi.DefaultCellStyle = dataGridViewCellStyle2;
			this.FkSanDtyTi.Dock = DockStyle.Fill;
			this.FkSanDtyTi.Location = new System.Drawing.Point(0, 0);
			this.FkSanDtyTi.Name = "dgvTU";
			this.FkSanDtyTi.ReadOnly = true;
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = SystemColors.Control;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
			this.FkSanDtyTi.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.FkSanDtyTi.Size = new Size(789, 294);
			this.FkSanDtyTi.TabIndex = 1;
			this.FkSanDtyTi.VirtualMode = true;
			this.FkSanDtyTi.CellDoubleClick += this.FkSanDtyTi_CellDoubleClick;
			this.FkSanDtyTi.CellFormatting += this.FkSanDtyTi_CellFormatting;
			this.FkSanDtyTi.RowPostPaint += this.FkSanDtyTi_RowPostPaint;
			this.dataGridViewCheckBoxColumn_0.DataPropertyName = "IsCancelContract";
			this.dataGridViewCheckBoxColumn_0.HeaderText = "IsCancelContract";
			this.dataGridViewCheckBoxColumn_0.Name = "IsCancelContractDgvColumn";
			this.dataGridViewCheckBoxColumn_0.ReadOnly = true;
			this.dataGridViewCheckBoxColumn_0.Visible = false;
			this.dataGridViewTextBoxColumn_137.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_137.HeaderText = "id";
			this.dataGridViewTextBoxColumn_137.Name = "idDgvColumn";
			this.dataGridViewTextBoxColumn_137.ReadOnly = true;
			this.dataGridViewTextBoxColumn_137.Visible = false;
			this.dataGridViewFilterTextBoxColumn_17.DataPropertyName = "NumDateIn";
			dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_17.DefaultCellStyle = dataGridViewCellStyle4;
			this.dataGridViewFilterTextBoxColumn_17.HeaderText = "№, дата входящего";
			this.dataGridViewFilterTextBoxColumn_17.Name = "numDateInDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_17.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_17.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_18.DataPropertyName = "numDoc";
			this.dataGridViewFilterTextBoxColumn_18.HeaderText = "№ ТУ";
			this.dataGridViewFilterTextBoxColumn_18.Name = "numDocDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_18.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_18.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_19.DataPropertyName = "dateDoc";
			this.dataGridViewFilterTextBoxColumn_19.HeaderText = "Дата выдачи";
			this.dataGridViewFilterTextBoxColumn_19.Name = "dateDocDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_19.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_19.Resizable = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_138.DataPropertyName = "numIn";
			this.dataGridViewTextBoxColumn_138.HeaderText = "numIn";
			this.dataGridViewTextBoxColumn_138.Name = "numInDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_138.ReadOnly = true;
			this.dataGridViewTextBoxColumn_138.Visible = false;
			this.dataGridViewTextBoxColumn_139.DataPropertyName = "DateIn";
			this.dataGridViewTextBoxColumn_139.HeaderText = "DateIn";
			this.dataGridViewTextBoxColumn_139.Name = "dateInDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_139.ReadOnly = true;
			this.dataGridViewTextBoxColumn_139.Visible = false;
			this.dataGridViewFilterTextBoxColumn_20.DataPropertyName = "body";
			dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_20.DefaultCellStyle = dataGridViewCellStyle5;
			this.dataGridViewFilterTextBoxColumn_20.HeaderText = "Содержание";
			this.dataGridViewFilterTextBoxColumn_20.Name = "bodyDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_20.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_20.Resizable = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_140.DataPropertyName = "idRequest";
			this.dataGridViewTextBoxColumn_140.HeaderText = "idRequest";
			this.dataGridViewTextBoxColumn_140.Name = "idRequestDgvColumn";
			this.dataGridViewTextBoxColumn_140.ReadOnly = true;
			this.dataGridViewTextBoxColumn_140.Visible = false;
			this.dataGridViewTextBoxColumn_141.DataPropertyName = "idAbn";
			this.dataGridViewTextBoxColumn_141.HeaderText = "idAbn";
			this.dataGridViewTextBoxColumn_141.Name = "idAbnDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_141.ReadOnly = true;
			this.dataGridViewTextBoxColumn_141.Visible = false;
			this.dataGridViewFilterTextBoxColumn_21.DataPropertyName = "nameAbn";
			dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_21.DefaultCellStyle = dataGridViewCellStyle6;
			this.dataGridViewFilterTextBoxColumn_21.HeaderText = "Потребитель";
			this.dataGridViewFilterTextBoxColumn_21.Name = "nameAbnDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_21.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_21.Resizable = DataGridViewTriState.True;
			this.lHbekeicuS.DataPropertyName = "idAbnObj";
			this.lHbekeicuS.HeaderText = "idAbnObj";
			this.lHbekeicuS.Name = "idAbnObjDataGridViewTextBoxColumn";
			this.lHbekeicuS.ReadOnly = true;
			this.lHbekeicuS.Visible = false;
			this.dataGridViewFilterTextBoxColumn_22.DataPropertyName = "nameObj";
			dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_22.DefaultCellStyle = dataGridViewCellStyle7;
			this.dataGridViewFilterTextBoxColumn_22.HeaderText = "Объект";
			this.dataGridViewFilterTextBoxColumn_22.Name = "nameObjDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_22.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_22.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_23.DataPropertyName = "address";
			dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_23.DefaultCellStyle = dataGridViewCellStyle8;
			this.dataGridViewFilterTextBoxColumn_23.HeaderText = "Адрес";
			this.dataGridViewFilterTextBoxColumn_23.Name = "addressDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_23.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_23.Resizable = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_142.DataPropertyName = "addressFull";
			this.dataGridViewTextBoxColumn_142.HeaderText = "addressFull";
			this.dataGridViewTextBoxColumn_142.Name = "addressFullDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_142.ReadOnly = true;
			this.dataGridViewTextBoxColumn_142.Visible = false;
			this.dataGridViewFilterTextBoxColumn_24.DataPropertyName = "Power";
			this.dataGridViewFilterTextBoxColumn_24.HeaderText = "Существующая мощность";
			this.dataGridViewFilterTextBoxColumn_24.Name = "powerDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_24.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_24.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_25.DataPropertyName = "PowerAdd";
			this.dataGridViewFilterTextBoxColumn_25.HeaderText = "Доп мощность";
			this.dataGridViewFilterTextBoxColumn_25.Name = "powerAddDgvColumn";
			this.dataGridViewFilterTextBoxColumn_25.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_25.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_26.DataPropertyName = "PowerSum";
			this.dataGridViewFilterTextBoxColumn_26.HeaderText = "Максимальная мощность";
			this.dataGridViewFilterTextBoxColumn_26.Name = "powerSumDgvColumn";
			this.dataGridViewFilterTextBoxColumn_26.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_26.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_27.DataPropertyName = "VoltageLevel";
			this.dataGridViewFilterTextBoxColumn_27.HeaderText = "Ур-нь напр-ния";
			this.dataGridViewFilterTextBoxColumn_27.Name = "voltageLevelDgvColumn";
			this.dataGridViewFilterTextBoxColumn_27.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_27.Width = 70;
			this.dataGridViewTextBoxColumn_143.DataPropertyName = "Category";
			this.dataGridViewTextBoxColumn_143.HeaderText = "Category";
			this.dataGridViewTextBoxColumn_143.Name = "categoryDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_143.ReadOnly = true;
			this.dataGridViewTextBoxColumn_143.Visible = false;
			this.dataGridViewFilterTextBoxColumn_28.DataPropertyName = "CategoryName";
			this.dataGridViewFilterTextBoxColumn_28.HeaderText = "Категор. элек-ния";
			this.dataGridViewFilterTextBoxColumn_28.Name = "categoryNameDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_28.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_28.Resizable = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_144.DataPropertyName = "idSchmObj";
			this.dataGridViewTextBoxColumn_144.HeaderText = "idSchmObj";
			this.dataGridViewTextBoxColumn_144.Name = "idSchmObjDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_144.ReadOnly = true;
			this.dataGridViewTextBoxColumn_144.Visible = false;
			this.waFeUdmntD.DataPropertyName = "numContractor";
			this.waFeUdmntD.HeaderText = "№ договора";
			this.waFeUdmntD.Name = "numContractorDgvColumn";
			this.waFeUdmntD.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_29.DataPropertyName = "dateContractor";
			this.dataGridViewFilterTextBoxColumn_29.HeaderText = "Дата договора";
			this.dataGridViewFilterTextBoxColumn_29.Name = "dateContractorDgvColumn";
			this.dataGridViewFilterTextBoxColumn_29.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_30.DataPropertyName = "PerformerFIO";
			this.dataGridViewFilterTextBoxColumn_30.HeaderText = "Исполнитель";
			this.dataGridViewFilterTextBoxColumn_30.Name = "performerFIODataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_30.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_30.Resizable = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_145.DataPropertyName = "NameDocOut";
			dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_145.DefaultCellStyle = dataGridViewCellStyle9;
			this.dataGridViewTextBoxColumn_145.HeaderText = "Выданные документы";
			this.dataGridViewTextBoxColumn_145.Name = "nameDocOutDgvColumn";
			this.dataGridViewTextBoxColumn_145.ReadOnly = true;
			this.dataGridViewTextBoxColumn_146.DataPropertyName = "Performer";
			this.dataGridViewTextBoxColumn_146.HeaderText = "Performer";
			this.dataGridViewTextBoxColumn_146.Name = "performerDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_146.ReadOnly = true;
			this.dataGridViewTextBoxColumn_146.Visible = false;
			this.dataGridViewFilterTextBoxColumn_31.DataPropertyName = "SchmTP";
			dataGridViewCellStyle10.WrapMode = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_31.DefaultCellStyle = dataGridViewCellStyle10;
			this.dataGridViewFilterTextBoxColumn_31.HeaderText = "ТП";
			this.dataGridViewFilterTextBoxColumn_31.Name = "schmTPDgvColumn";
			this.dataGridViewFilterTextBoxColumn_31.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_32.DataPropertyName = "SchmCP";
			dataGridViewCellStyle11.WrapMode = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_32.DefaultCellStyle = dataGridViewCellStyle11;
			this.dataGridViewFilterTextBoxColumn_32.HeaderText = "ЦП";
			this.dataGridViewFilterTextBoxColumn_32.Name = "schmCPDgvColumn";
			this.dataGridViewFilterTextBoxColumn_32.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_32.Width = 150;
			this.bindingSource_0.DataMember = "vTC_TU";
			this.bindingSource_0.DataSource = this.class10_0;
			this.bindingSource_0.CurrentChanged += this.bindingSource_0_CurrentChanged;
			this.class10_0.DataSetName = "DataSetTechConnection";
			this.class10_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
			this.splitContainer_0.Dock = DockStyle.Fill;
			this.splitContainer_0.FixedPanel = FixedPanel.Panel1;
			this.splitContainer_0.Location = new System.Drawing.Point(0, 25);
			this.splitContainer_0.Name = "splitContainerMain";
			this.splitContainer_0.Panel1.Controls.Add(this.treeView_0);
			this.splitContainer_0.Panel1.Controls.Add(this.label_5);
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
			this.treeView_0.TabIndex = 11;
			this.treeView_0.AfterCheck += this.treeView_0_AfterCheck;
			this.label_5.AutoSize = true;
			this.label_5.Location = new System.Drawing.Point(12, 103);
			this.label_5.Name = "label6";
			this.label_5.Size = new Size(68, 13);
			this.label_5.TabIndex = 10;
			this.label_5.Text = "Подстанции";
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
			this.toolStripButton_7.Image = (Image)componentResourceManager.GetObject("toolBtnApplyFilter.Image");
			this.toolStripButton_7.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_7.Name = "toolBtnApplyFilter";
			this.toolStripButton_7.Size = new Size(23, 22);
			this.toolStripButton_7.Text = "Применить фильтр";
			this.toolStripButton_7.Click += this.toolStripButton_7_Click;
			this.toolStripButton_8.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_8.Image = (Image)componentResourceManager.GetObject("toolBtnClearFilter.Image");
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
			this.splitContainer_1.Panel1.Controls.Add(this.FkSanDtyTi);
			this.splitContainer_1.Panel2.Controls.Add(this.tabControl_0);
			this.splitContainer_1.Size = new Size(789, 497);
			this.splitContainer_1.SplitterDistance = 294;
			this.splitContainer_1.TabIndex = 2;
			this.tabControl_0.Controls.Add(this.tabPage_0);
			this.tabControl_0.Controls.Add(this.tabPage_1);
			this.tabControl_0.Controls.Add(this.tabPage_3);
			this.tabControl_0.Controls.Add(this.tabPage_2);
			this.tabControl_0.Controls.Add(this.tabPage_4);
			this.tabControl_0.Controls.Add(this.pevkEfUdfJ);
			this.tabControl_0.Controls.Add(this.tabPage_5);
			this.tabControl_0.Dock = DockStyle.Fill;
			this.tabControl_0.Location = new System.Drawing.Point(0, 0);
			this.tabControl_0.Name = "tcGeneral";
			this.tabControl_0.SelectedIndex = 0;
			this.tabControl_0.Size = new Size(789, 199);
			this.tabControl_0.TabIndex = 0;
			this.tabControl_0.SelectedIndexChanged += this.tabControl_0_SelectedIndexChanged;
			this.tabPage_0.Controls.Add(this.dataGridViewExcelFilter_0);
			this.tabPage_0.Location = new System.Drawing.Point(4, 22);
			this.tabPage_0.Name = "tabPageFiles";
			this.tabPage_0.Padding = new Padding(3);
			this.tabPage_0.Size = new Size(781, 173);
			this.tabPage_0.TabIndex = 0;
			this.tabPage_0.Text = "Файлы";
			this.tabPage_0.UseVisualStyleBackColor = true;
			this.dataGridViewExcelFilter_0.AllowUserToAddRows = false;
			this.dataGridViewExcelFilter_0.AllowUserToDeleteRows = false;
			this.dataGridViewExcelFilter_0.AllowUserToResizeColumns = false;
			this.dataGridViewExcelFilter_0.AllowUserToResizeRows = false;
			this.dataGridViewExcelFilter_0.AutoGenerateColumns = false;
			dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle12.BackColor = SystemColors.Control;
			dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle12.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle12.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle12.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle12.WrapMode = DataGridViewTriState.True;
			this.dataGridViewExcelFilter_0.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
			this.dataGridViewExcelFilter_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewExcelFilter_0.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewLinkColumn_0,
				this.dataGridViewImageColumnNotNull_0,
				this.dataGridViewTextBoxColumn_0,
				this.dataGridViewTextBoxColumn_1,
				this.dataGridViewTextBoxColumn_2,
				this.dataGridViewTextBoxColumn_3
			});
			this.dataGridViewExcelFilter_0.DataSource = this.bindingSource_1;
			dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle13.BackColor = SystemColors.Window;
			dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle13.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle13.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle13.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle13.WrapMode = DataGridViewTriState.False;
			this.dataGridViewExcelFilter_0.DefaultCellStyle = dataGridViewCellStyle13;
			this.dataGridViewExcelFilter_0.Dock = DockStyle.Fill;
			this.dataGridViewExcelFilter_0.EditMode = DataGridViewEditMode.EditProgrammatically;
			this.dataGridViewExcelFilter_0.Location = new System.Drawing.Point(3, 3);
			this.dataGridViewExcelFilter_0.Name = "dgvFile";
			this.dataGridViewExcelFilter_0.ReadOnly = true;
			dataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle14.BackColor = SystemColors.Control;
			dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle14.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle14.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle14.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle14.WrapMode = DataGridViewTriState.True;
			this.dataGridViewExcelFilter_0.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
			this.dataGridViewExcelFilter_0.RowHeadersVisible = false;
			this.dataGridViewExcelFilter_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewExcelFilter_0.Size = new Size(775, 167);
			this.dataGridViewExcelFilter_0.TabIndex = 7;
			this.dataGridViewExcelFilter_0.VirtualMode = true;
			this.dataGridViewExcelFilter_0.CellContentClick += this.dataGridViewExcelFilter_0_CellContentClick;
			this.dataGridViewExcelFilter_0.CellValueNeeded += this.dataGridViewExcelFilter_0_CellValueNeeded;
			this.dataGridViewLinkColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewLinkColumn_0.DataPropertyName = "FileName";
			this.dataGridViewLinkColumn_0.HeaderText = "Файл";
			this.dataGridViewLinkColumn_0.Name = "fileNameDgvColumn";
			this.dataGridViewLinkColumn_0.ReadOnly = true;
			this.dataGridViewLinkColumn_0.Resizable = DataGridViewTriState.True;
			this.dataGridViewLinkColumn_0.SortMode = DataGridViewColumnSortMode.Automatic;
			dataGridViewCellStyle15.NullValue = null;
			this.dataGridViewImageColumnNotNull_0.DefaultCellStyle = dataGridViewCellStyle15;
			this.dataGridViewImageColumnNotNull_0.HeaderText = "";
			this.dataGridViewImageColumnNotNull_0.ImageLayout = DataGridViewImageCellLayout.Zoom;
			this.dataGridViewImageColumnNotNull_0.Name = "imageDgvColumn";
			this.dataGridViewImageColumnNotNull_0.ReadOnly = true;
			this.dataGridViewImageColumnNotNull_0.Width = 30;
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
			this.bindingSource_1.DataMember = "tTC_DocFile";
			this.bindingSource_1.DataSource = this.class10_0;
			this.tabPage_1.Controls.Add(this.dataGridViewExcelFilter_1);
			this.tabPage_1.Location = new System.Drawing.Point(4, 22);
			this.tabPage_1.Name = "tabPageRequestHistory";
			this.tabPage_1.Padding = new Padding(3);
			this.tabPage_1.Size = new Size(781, 173);
			this.tabPage_1.TabIndex = 1;
			this.tabPage_1.Text = "История заявок";
			this.tabPage_1.UseVisualStyleBackColor = true;
			this.dataGridViewExcelFilter_1.AllowUserToAddRows = false;
			this.dataGridViewExcelFilter_1.AllowUserToDeleteRows = false;
			this.dataGridViewExcelFilter_1.AutoGenerateColumns = false;
			dataGridViewCellStyle16.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle16.BackColor = SystemColors.Control;
			dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle16.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle16.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle16.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle16.WrapMode = DataGridViewTriState.True;
			this.dataGridViewExcelFilter_1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
			this.dataGridViewExcelFilter_1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewExcelFilter_1.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewTextBoxColumn_4,
				this.dataGridViewTextBoxColumn_14,
				this.dataGridViewTextBoxColumn_5,
				this.dataGridViewTextBoxColumn_6,
				this.dataGridViewTextBoxColumn_7,
				this.dataGridViewTextBoxColumn_8,
				this.dataGridViewTextBoxColumn_9,
				this.dataGridViewTextBoxColumn_10,
				this.dataGridViewTextBoxColumn_11,
				this.dataGridViewTextBoxColumn_12,
				this.dataGridViewTextBoxColumn_13,
				this.alragsoaPf,
				this.dataGridViewTextBoxColumn_15,
				this.dataGridViewTextBoxColumn_16,
				this.dataGridViewTextBoxColumn_17,
				this.dataGridViewTextBoxColumn_18,
				this.dataGridViewTextBoxColumn_19,
				this.dataGridViewTextBoxColumn_20
			});
			this.dataGridViewExcelFilter_1.DataSource = this.bindingSource_2;
			dataGridViewCellStyle17.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle17.BackColor = SystemColors.Window;
			dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle17.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle17.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle17.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle17.WrapMode = DataGridViewTriState.False;
			this.dataGridViewExcelFilter_1.DefaultCellStyle = dataGridViewCellStyle17;
			this.dataGridViewExcelFilter_1.Dock = DockStyle.Fill;
			this.dataGridViewExcelFilter_1.Location = new System.Drawing.Point(3, 3);
			this.dataGridViewExcelFilter_1.MultiSelect = false;
			this.dataGridViewExcelFilter_1.Name = "dgvRequestHistory";
			this.dataGridViewExcelFilter_1.ReadOnly = true;
			dataGridViewCellStyle18.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle18.BackColor = SystemColors.Control;
			dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle18.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle18.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle18.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle18.WrapMode = DataGridViewTriState.True;
			this.dataGridViewExcelFilter_1.RowHeadersDefaultCellStyle = dataGridViewCellStyle18;
			this.dataGridViewExcelFilter_1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewExcelFilter_1.Size = new Size(775, 167);
			this.dataGridViewExcelFilter_1.TabIndex = 4;
			this.dataGridViewExcelFilter_1.VirtualMode = true;
			this.dataGridViewExcelFilter_1.CellFormatting += this.dataGridViewExcelFilter_1_CellFormatting;
			this.dataGridViewExcelFilter_1.RowPostPaint += this.dataGridViewExcelFilter_1_RowPostPaint;
			this.dataGridViewTextBoxColumn_4.DataPropertyName = "numDateIn";
			dataGridViewCellStyle19.WrapMode = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_4.DefaultCellStyle = dataGridViewCellStyle19;
			this.dataGridViewTextBoxColumn_4.HeaderText = "№, дата вход.";
			this.dataGridViewTextBoxColumn_4.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_4.ReadOnly = true;
			this.dataGridViewTextBoxColumn_4.Visible = false;
			this.dataGridViewTextBoxColumn_4.Width = 80;
			this.dataGridViewTextBoxColumn_14.DataPropertyName = "PowerAdd";
			this.dataGridViewTextBoxColumn_14.HeaderText = "Доп мощность";
			this.dataGridViewTextBoxColumn_14.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn_14.ReadOnly = true;
			this.dataGridViewTextBoxColumn_14.Visible = false;
			this.dataGridViewTextBoxColumn_14.Width = 70;
			this.dataGridViewTextBoxColumn_5.DataPropertyName = "numDoc";
			this.dataGridViewTextBoxColumn_5.HeaderText = "numDoc";
			this.dataGridViewTextBoxColumn_5.Name = "numDocDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_5.ReadOnly = true;
			this.dataGridViewTextBoxColumn_5.Visible = false;
			this.dataGridViewTextBoxColumn_6.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_6.HeaderText = "id";
			this.dataGridViewTextBoxColumn_6.Name = "idRequestHistoryDgvColumn";
			this.dataGridViewTextBoxColumn_6.ReadOnly = true;
			this.dataGridViewTextBoxColumn_6.Visible = false;
			this.dataGridViewTextBoxColumn_7.DataPropertyName = "dateDoc";
			this.dataGridViewTextBoxColumn_7.HeaderText = "Дата получения";
			this.dataGridViewTextBoxColumn_7.Name = "dateDocDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_7.ReadOnly = true;
			this.dataGridViewTextBoxColumn_7.Width = 80;
			this.dataGridViewTextBoxColumn_8.DataPropertyName = "TypeDoc";
			this.dataGridViewTextBoxColumn_8.HeaderText = "TypeDoc";
			this.dataGridViewTextBoxColumn_8.Name = "typeDocRequestHistoryDgvColumn";
			this.dataGridViewTextBoxColumn_8.ReadOnly = true;
			this.dataGridViewTextBoxColumn_8.Visible = false;
			this.dataGridViewTextBoxColumn_9.DataPropertyName = "numIn";
			this.dataGridViewTextBoxColumn_9.HeaderText = "numIn";
			this.dataGridViewTextBoxColumn_9.Name = "numInDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_9.ReadOnly = true;
			this.dataGridViewTextBoxColumn_9.Visible = false;
			this.dataGridViewTextBoxColumn_10.DataPropertyName = "dateIn";
			this.dataGridViewTextBoxColumn_10.HeaderText = "dateIn";
			this.dataGridViewTextBoxColumn_10.Name = "dateInDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_10.ReadOnly = true;
			this.dataGridViewTextBoxColumn_10.Visible = false;
			this.dataGridViewTextBoxColumn_11.DataPropertyName = "idAbn";
			this.dataGridViewTextBoxColumn_11.HeaderText = "idAbn";
			this.dataGridViewTextBoxColumn_11.Name = "idAbnDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_11.ReadOnly = true;
			this.dataGridViewTextBoxColumn_11.Visible = false;
			this.dataGridViewTextBoxColumn_12.DataPropertyName = "idAbnObj";
			this.dataGridViewTextBoxColumn_12.HeaderText = "idAbnObj";
			this.dataGridViewTextBoxColumn_12.Name = "idAbnObjDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_12.ReadOnly = true;
			this.dataGridViewTextBoxColumn_12.Visible = false;
			this.dataGridViewTextBoxColumn_13.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_13.DataPropertyName = "body";
			dataGridViewCellStyle20.WrapMode = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_13.DefaultCellStyle = dataGridViewCellStyle20;
			this.dataGridViewTextBoxColumn_13.HeaderText = "Тело письма";
			this.dataGridViewTextBoxColumn_13.Name = "bodyDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_13.ReadOnly = true;
			this.alragsoaPf.DataPropertyName = "PowerCurrent";
			this.alragsoaPf.HeaderText = "Текущая мощность";
			this.alragsoaPf.Name = "powerCurrentDgvColumn";
			this.alragsoaPf.ReadOnly = true;
			this.alragsoaPf.Width = 70;
			this.dataGridViewTextBoxColumn_15.DataPropertyName = "Power";
			this.dataGridViewTextBoxColumn_15.HeaderText = "Суммарная мощность";
			this.dataGridViewTextBoxColumn_15.Name = "powerDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_15.ReadOnly = true;
			this.dataGridViewTextBoxColumn_15.Width = 70;
			this.dataGridViewTextBoxColumn_16.DataPropertyName = "VoltageName";
			this.dataGridViewTextBoxColumn_16.HeaderText = "Напряжение";
			this.dataGridViewTextBoxColumn_16.Name = "voltageNameDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_16.ReadOnly = true;
			this.dataGridViewTextBoxColumn_16.Width = 70;
			this.dataGridViewTextBoxColumn_17.DataPropertyName = "Comment";
			this.dataGridViewTextBoxColumn_17.HeaderText = "Комментарий";
			this.dataGridViewTextBoxColumn_17.Name = "commentDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_17.ReadOnly = true;
			this.dataGridViewTextBoxColumn_17.Width = 70;
			this.dataGridViewTextBoxColumn_18.DataPropertyName = "VoltageLevel";
			this.dataGridViewTextBoxColumn_18.HeaderText = "VoltageLevel";
			this.dataGridViewTextBoxColumn_18.Name = "voltageLevelDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_18.ReadOnly = true;
			this.dataGridViewTextBoxColumn_18.Visible = false;
			this.dataGridViewTextBoxColumn_19.DataPropertyName = "VoltageValue";
			this.dataGridViewTextBoxColumn_19.HeaderText = "VoltageValue";
			this.dataGridViewTextBoxColumn_19.Name = "voltageValueDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_19.ReadOnly = true;
			this.dataGridViewTextBoxColumn_19.Visible = false;
			this.dataGridViewTextBoxColumn_20.DataPropertyName = "IdParent";
			this.dataGridViewTextBoxColumn_20.HeaderText = "IdParent";
			this.dataGridViewTextBoxColumn_20.Name = "idParentDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_20.ReadOnly = true;
			this.dataGridViewTextBoxColumn_20.Visible = false;
			this.bindingSource_2.DataMember = "vTC_RequestHistory";
			this.bindingSource_2.DataSource = this.class10_0;
			this.tabPage_3.Controls.Add(this.splitContainer_3);
			this.tabPage_3.Location = new System.Drawing.Point(4, 22);
			this.tabPage_3.Name = "tabPageTypeWork";
			this.tabPage_3.Size = new Size(781, 173);
			this.tabPage_3.TabIndex = 3;
			this.tabPage_3.Text = "Вид работ";
			this.tabPage_3.UseVisualStyleBackColor = true;
			this.splitContainer_3.Dock = DockStyle.Fill;
			this.splitContainer_3.Location = new System.Drawing.Point(0, 0);
			this.splitContainer_3.Name = "splitContainer2";
			this.splitContainer_3.Panel1.Controls.Add(this.dataGridViewExcelFilter_4);
			this.splitContainer_3.Panel2.Controls.Add(this.dataGridViewExcelFilter_5);
			this.splitContainer_3.Size = new Size(781, 173);
			this.splitContainer_3.SplitterDistance = 366;
			this.splitContainer_3.TabIndex = 0;
			this.dataGridViewExcelFilter_4.AllowUserToAddRows = false;
			this.dataGridViewExcelFilter_4.AllowUserToDeleteRows = false;
			this.dataGridViewExcelFilter_4.AutoGenerateColumns = false;
			dataGridViewCellStyle21.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle21.BackColor = SystemColors.Control;
			dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle21.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle21.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle21.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle21.WrapMode = DataGridViewTriState.True;
			this.dataGridViewExcelFilter_4.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle21;
			this.dataGridViewExcelFilter_4.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewExcelFilter_4.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewTextBoxColumn_33,
				this.dataGridViewTextBoxColumn_34,
				this.dataGridViewTextBoxColumn_35,
				this.dataGridViewTextBoxColumn_36,
				this.dataGridViewTextBoxColumn_37
			});
			this.dataGridViewExcelFilter_4.DataSource = this.bindingSource_5;
			dataGridViewCellStyle22.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle22.BackColor = SystemColors.Window;
			dataGridViewCellStyle22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle22.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle22.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle22.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle22.WrapMode = DataGridViewTriState.False;
			this.dataGridViewExcelFilter_4.DefaultCellStyle = dataGridViewCellStyle22;
			this.dataGridViewExcelFilter_4.Dock = DockStyle.Fill;
			this.dataGridViewExcelFilter_4.Location = new System.Drawing.Point(0, 0);
			this.dataGridViewExcelFilter_4.Name = "dgvNetWork";
			this.dataGridViewExcelFilter_4.ReadOnly = true;
			dataGridViewCellStyle23.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle23.BackColor = SystemColors.Control;
			dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle23.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle23.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle23.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle23.WrapMode = DataGridViewTriState.True;
			this.dataGridViewExcelFilter_4.RowHeadersDefaultCellStyle = dataGridViewCellStyle23;
			this.dataGridViewExcelFilter_4.RowHeadersWidth = 21;
			this.dataGridViewExcelFilter_4.Size = new Size(366, 173);
			this.dataGridViewExcelFilter_4.TabIndex = 2;
			this.dataGridViewExcelFilter_4.RowPostPaint += this.dataGridViewExcelFilter_5_RowPostPaint;
			this.dataGridViewTextBoxColumn_33.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_33.DataPropertyName = "Work";
			dataGridViewCellStyle24.WrapMode = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_33.DefaultCellStyle = dataGridViewCellStyle24;
			this.dataGridViewTextBoxColumn_33.HeaderText = "Работы сетевой организации";
			this.dataGridViewTextBoxColumn_33.Name = "workDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_33.ReadOnly = true;
			this.dataGridViewTextBoxColumn_33.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn_34.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_34.HeaderText = "id";
			this.dataGridViewTextBoxColumn_34.Name = "idNetWorkDgvColumn";
			this.dataGridViewTextBoxColumn_34.ReadOnly = true;
			this.dataGridViewTextBoxColumn_34.Visible = false;
			this.dataGridViewTextBoxColumn_35.DataPropertyName = "idTU";
			this.dataGridViewTextBoxColumn_35.HeaderText = "idTU";
			this.dataGridViewTextBoxColumn_35.Name = "idTUNetWorkDgvColumn";
			this.dataGridViewTextBoxColumn_35.ReadOnly = true;
			this.dataGridViewTextBoxColumn_35.Visible = false;
			this.dataGridViewTextBoxColumn_36.DataPropertyName = "num";
			this.dataGridViewTextBoxColumn_36.HeaderText = "num";
			this.dataGridViewTextBoxColumn_36.Name = "numNetWorkDgvColumn";
			this.dataGridViewTextBoxColumn_36.ReadOnly = true;
			this.dataGridViewTextBoxColumn_36.Visible = false;
			this.dataGridViewTextBoxColumn_37.DataPropertyName = "TypeWork";
			this.dataGridViewTextBoxColumn_37.HeaderText = "TypeWork";
			this.dataGridViewTextBoxColumn_37.Name = "typeWorkNetWorkDgvColumn";
			this.dataGridViewTextBoxColumn_37.ReadOnly = true;
			this.dataGridViewTextBoxColumn_37.Visible = false;
			this.bindingSource_5.DataMember = "tTC_TUTypeWork";
			this.bindingSource_5.DataSource = this.class10_0;
			this.bindingSource_5.Filter = "TypeWork = 1";
			this.bindingSource_5.Sort = "num";
			this.dataGridViewExcelFilter_5.AllowUserToAddRows = false;
			this.dataGridViewExcelFilter_5.AllowUserToDeleteRows = false;
			this.dataGridViewExcelFilter_5.AutoGenerateColumns = false;
			dataGridViewCellStyle25.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle25.BackColor = SystemColors.Control;
			dataGridViewCellStyle25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle25.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle25.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle25.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle25.WrapMode = DataGridViewTriState.True;
			this.dataGridViewExcelFilter_5.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle25;
			this.dataGridViewExcelFilter_5.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewExcelFilter_5.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewTextBoxColumn_38,
				this.dataGridViewTextBoxColumn_39,
				this.dataGridViewTextBoxColumn_40,
				this.dataGridViewTextBoxColumn_41,
				this.dataGridViewTextBoxColumn_42
			});
			this.dataGridViewExcelFilter_5.DataSource = this.bindingSource_6;
			dataGridViewCellStyle26.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle26.BackColor = SystemColors.Window;
			dataGridViewCellStyle26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle26.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle26.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle26.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle26.WrapMode = DataGridViewTriState.False;
			this.dataGridViewExcelFilter_5.DefaultCellStyle = dataGridViewCellStyle26;
			this.dataGridViewExcelFilter_5.Dock = DockStyle.Fill;
			this.dataGridViewExcelFilter_5.Location = new System.Drawing.Point(0, 0);
			this.dataGridViewExcelFilter_5.Name = "dgvClientWork";
			this.dataGridViewExcelFilter_5.ReadOnly = true;
			dataGridViewCellStyle27.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle27.BackColor = SystemColors.Control;
			dataGridViewCellStyle27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle27.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle27.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle27.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle27.WrapMode = DataGridViewTriState.True;
			this.dataGridViewExcelFilter_5.RowHeadersDefaultCellStyle = dataGridViewCellStyle27;
			this.dataGridViewExcelFilter_5.RowHeadersWidth = 21;
			this.dataGridViewExcelFilter_5.Size = new Size(411, 173);
			this.dataGridViewExcelFilter_5.TabIndex = 3;
			this.dataGridViewExcelFilter_5.RowPostPaint += this.dataGridViewExcelFilter_5_RowPostPaint;
			this.dataGridViewTextBoxColumn_38.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_38.DataPropertyName = "Work";
			dataGridViewCellStyle28.WrapMode = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_38.DefaultCellStyle = dataGridViewCellStyle28;
			this.dataGridViewTextBoxColumn_38.HeaderText = "Работы заказчика";
			this.dataGridViewTextBoxColumn_38.Name = "workDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_38.ReadOnly = true;
			this.dataGridViewTextBoxColumn_38.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn_39.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_39.HeaderText = "id";
			this.dataGridViewTextBoxColumn_39.Name = "idClientWorkDgvColumn";
			this.dataGridViewTextBoxColumn_39.ReadOnly = true;
			this.dataGridViewTextBoxColumn_39.Visible = false;
			this.dataGridViewTextBoxColumn_40.DataPropertyName = "idTU";
			this.dataGridViewTextBoxColumn_40.HeaderText = "idTU";
			this.dataGridViewTextBoxColumn_40.Name = "idTUClientWorkDgvColumn";
			this.dataGridViewTextBoxColumn_40.ReadOnly = true;
			this.dataGridViewTextBoxColumn_40.Visible = false;
			this.dataGridViewTextBoxColumn_41.DataPropertyName = "num";
			this.dataGridViewTextBoxColumn_41.HeaderText = "num";
			this.dataGridViewTextBoxColumn_41.Name = "numClientWorkDgvColumn";
			this.dataGridViewTextBoxColumn_41.ReadOnly = true;
			this.dataGridViewTextBoxColumn_41.Visible = false;
			this.dataGridViewTextBoxColumn_42.DataPropertyName = "TypeWork";
			this.dataGridViewTextBoxColumn_42.HeaderText = "TypeWork";
			this.dataGridViewTextBoxColumn_42.Name = "typeWorkClientWorkDgvColumn";
			this.dataGridViewTextBoxColumn_42.ReadOnly = true;
			this.dataGridViewTextBoxColumn_42.Visible = false;
			this.bindingSource_6.DataMember = "tTC_TUTypeWork";
			this.bindingSource_6.DataSource = this.class10_0;
			this.bindingSource_6.Filter = "TypeWork = 2";
			this.bindingSource_6.Sort = "num";
			this.tabPage_2.Controls.Add(this.splitContainer_2);
			this.tabPage_2.Location = new System.Drawing.Point(4, 22);
			this.tabPage_2.Name = "tabPageDocOut";
			this.tabPage_2.Padding = new Padding(3);
			this.tabPage_2.Size = new Size(781, 173);
			this.tabPage_2.TabIndex = 2;
			this.tabPage_2.Text = "Выданные документы";
			this.tabPage_2.UseVisualStyleBackColor = true;
			this.splitContainer_2.Dock = DockStyle.Fill;
			this.splitContainer_2.Location = new System.Drawing.Point(3, 3);
			this.splitContainer_2.Name = "splitContainerDocOut";
			this.splitContainer_2.Panel1.Controls.Add(this.dataGridViewExcelFilter_2);
			this.splitContainer_2.Panel1.Controls.Add(this.toolStrip_2);
			this.splitContainer_2.Panel2.Controls.Add(this.dataGridViewExcelFilter_3);
			this.splitContainer_2.Panel2.Controls.Add(this.toolStrip_3);
			this.splitContainer_2.Size = new Size(775, 167);
			this.splitContainer_2.SplitterDistance = 416;
			this.splitContainer_2.TabIndex = 0;
			this.dataGridViewExcelFilter_2.AllowUserToAddRows = false;
			this.dataGridViewExcelFilter_2.AllowUserToDeleteRows = false;
			this.dataGridViewExcelFilter_2.AllowUserToOrderColumns = true;
			this.dataGridViewExcelFilter_2.AllowUserToVisibleColumns = false;
			this.dataGridViewExcelFilter_2.AutoGenerateColumns = false;
			dataGridViewCellStyle29.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle29.BackColor = SystemColors.Control;
			dataGridViewCellStyle29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle29.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle29.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle29.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle29.WrapMode = DataGridViewTriState.True;
			this.dataGridViewExcelFilter_2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle29;
			this.dataGridViewExcelFilter_2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewExcelFilter_2.Columns.AddRange(new DataGridViewColumn[]
			{
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
				this.ymuksnNoEU,
				this.dataGridViewTextBoxColumn_31,
				this.dataGridViewTextBoxColumn_32
			});
			this.dataGridViewExcelFilter_2.DataSource = this.bindingSource_3;
			dataGridViewCellStyle30.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle30.BackColor = SystemColors.Window;
			dataGridViewCellStyle30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle30.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle30.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle30.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle30.WrapMode = DataGridViewTriState.False;
			this.dataGridViewExcelFilter_2.DefaultCellStyle = dataGridViewCellStyle30;
			this.dataGridViewExcelFilter_2.Dock = DockStyle.Fill;
			this.dataGridViewExcelFilter_2.Location = new System.Drawing.Point(32, 0);
			this.dataGridViewExcelFilter_2.Name = "dgvDocOut";
			this.dataGridViewExcelFilter_2.ReadOnly = true;
			dataGridViewCellStyle31.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle31.BackColor = SystemColors.Control;
			dataGridViewCellStyle31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle31.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle31.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle31.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle31.WrapMode = DataGridViewTriState.True;
			this.dataGridViewExcelFilter_2.RowHeadersDefaultCellStyle = dataGridViewCellStyle31;
			this.dataGridViewExcelFilter_2.RowHeadersWidth = 21;
			this.dataGridViewExcelFilter_2.Size = new Size(384, 167);
			this.dataGridViewExcelFilter_2.TabIndex = 3;
			this.dataGridViewExcelFilter_2.VirtualMode = true;
			this.dataGridViewExcelFilter_2.CellFormatting += this.dataGridViewExcelFilter_2_CellFormatting;
			this.dataGridViewTextBoxColumn_21.DataPropertyName = "TypeDocNameOut";
			this.dataGridViewTextBoxColumn_21.HeaderText = "Документ";
			this.dataGridViewTextBoxColumn_21.Name = "typeDocNameOutDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_21.ReadOnly = true;
			this.dataGridViewTextBoxColumn_22.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_22.HeaderText = "id";
			this.dataGridViewTextBoxColumn_22.Name = "idLinkDocOutDgvColumn";
			this.dataGridViewTextBoxColumn_22.ReadOnly = true;
			this.dataGridViewTextBoxColumn_22.Visible = false;
			this.dataGridViewTextBoxColumn_23.DataPropertyName = "numDateDocOut";
			this.dataGridViewTextBoxColumn_23.HeaderText = "numDateDocOut";
			this.dataGridViewTextBoxColumn_23.Name = "numDateDocOutDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_23.ReadOnly = true;
			this.dataGridViewTextBoxColumn_23.Visible = false;
			this.dataGridViewTextBoxColumn_24.DataPropertyName = "idDoc";
			this.dataGridViewTextBoxColumn_24.HeaderText = "idDoc";
			this.dataGridViewTextBoxColumn_24.Name = "idDocDgvColumn";
			this.dataGridViewTextBoxColumn_24.ReadOnly = true;
			this.dataGridViewTextBoxColumn_24.Visible = false;
			this.dataGridViewTextBoxColumn_25.DataPropertyName = "numDocOut";
			this.dataGridViewTextBoxColumn_25.HeaderText = "№";
			this.dataGridViewTextBoxColumn_25.Name = "numDocOutDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_25.ReadOnly = true;
			this.dataGridViewTextBoxColumn_26.DataPropertyName = "TypeDocOut";
			this.dataGridViewTextBoxColumn_26.HeaderText = "TypeDocOut";
			this.dataGridViewTextBoxColumn_26.Name = "typeDocOutDgvColumn";
			this.dataGridViewTextBoxColumn_26.ReadOnly = true;
			this.dataGridViewTextBoxColumn_26.Visible = false;
			this.dataGridViewTextBoxColumn_27.DataPropertyName = "idDocOut";
			this.dataGridViewTextBoxColumn_27.HeaderText = "idDocOut";
			this.dataGridViewTextBoxColumn_27.Name = "idDocOutDgvColumn";
			this.dataGridViewTextBoxColumn_27.ReadOnly = true;
			this.dataGridViewTextBoxColumn_27.Visible = false;
			this.dataGridViewTextBoxColumn_28.DataPropertyName = "dateDocOut";
			dataGridViewCellStyle32.Format = "d";
			dataGridViewCellStyle32.NullValue = null;
			this.dataGridViewTextBoxColumn_28.DefaultCellStyle = dataGridViewCellStyle32;
			this.dataGridViewTextBoxColumn_28.HeaderText = "Дата";
			this.dataGridViewTextBoxColumn_28.Name = "dateDocOutDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_28.ReadOnly = true;
			this.dataGridViewTextBoxColumn_29.DataPropertyName = "Status";
			this.dataGridViewTextBoxColumn_29.HeaderText = "Статус";
			this.dataGridViewTextBoxColumn_29.Name = "statusDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_29.ReadOnly = true;
			this.dataGridViewTextBoxColumn_29.Visible = false;
			this.dataGridViewTextBoxColumn_30.DataPropertyName = "BodyDocOut";
			this.dataGridViewTextBoxColumn_30.HeaderText = "Содержание";
			this.dataGridViewTextBoxColumn_30.Name = "bodyDocOutDgvColumn";
			this.dataGridViewTextBoxColumn_30.ReadOnly = true;
			this.ymuksnNoEU.DataPropertyName = "SendModeName";
			this.ymuksnNoEU.HeaderText = "Способ отправки";
			this.ymuksnNoEU.Name = "sendModeNameDataGridViewTextBoxColumn";
			this.ymuksnNoEU.ReadOnly = true;
			this.ymuksnNoEU.Visible = false;
			this.dataGridViewTextBoxColumn_31.DataPropertyName = "number";
			this.dataGridViewTextBoxColumn_31.HeaderText = "Кол-во";
			this.dataGridViewTextBoxColumn_31.Name = "numberDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_31.ReadOnly = true;
			this.dataGridViewTextBoxColumn_32.DataPropertyName = "comment";
			this.dataGridViewTextBoxColumn_32.HeaderText = "Комментарий";
			this.dataGridViewTextBoxColumn_32.Name = "commentDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_32.ReadOnly = true;
			this.dataGridViewTextBoxColumn_32.Visible = false;
			this.bindingSource_3.DataMember = "vTC_DocOut";
			this.bindingSource_3.DataSource = this.class10_0;
			this.bindingSource_3.CurrentChanged += this.bindingSource_3_CurrentChanged;
			this.toolStrip_2.Dock = DockStyle.Left;
			this.toolStrip_2.GripStyle = ToolStripGripStyle.Hidden;
			this.toolStrip_2.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripDropDownButton_1,
				this.toolStripButton_10,
				this.toolStripButton_11
			});
			this.toolStrip_2.Location = new System.Drawing.Point(0, 0);
			this.toolStrip_2.Name = "toolStripDocOut";
			this.toolStrip_2.Size = new Size(32, 167);
			this.toolStrip_2.TabIndex = 2;
			this.toolStrip_2.Text = "toolStrip1";
			this.toolStripButton_10.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_10.Image = (Image)componentResourceManager.GetObject("toolBtnEditDocOut.Image");
			this.toolStripButton_10.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_10.Name = "toolBtnEditDocOut";
			this.toolStripButton_10.Size = new Size(29, 20);
			this.toolStripButton_10.Text = "Редактировать документ";
			this.toolStripButton_10.Click += this.toolStripButton_10_Click;
			this.toolStripButton_11.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_11.Image = (Image)componentResourceManager.GetObject("toolBtnDelDocOut.Image");
			this.toolStripButton_11.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_11.Name = "toolBtnDelDocOut";
			this.toolStripButton_11.Size = new Size(29, 20);
			this.toolStripButton_11.Text = "Удалить документ";
			this.toolStripButton_11.Click += this.toolStripButton_11_Click;
			this.dataGridViewExcelFilter_3.AllowUserToAddRows = false;
			this.dataGridViewExcelFilter_3.AllowUserToDeleteRows = false;
			this.dataGridViewExcelFilter_3.AllowUserToOrderColumns = true;
			this.dataGridViewExcelFilter_3.AllowUserToVisibleColumns = false;
			this.dataGridViewExcelFilter_3.AutoGenerateColumns = false;
			dataGridViewCellStyle33.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle33.BackColor = SystemColors.Control;
			dataGridViewCellStyle33.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle33.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle33.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle33.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle33.WrapMode = DataGridViewTriState.True;
			this.dataGridViewExcelFilter_3.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle33;
			this.dataGridViewExcelFilter_3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewExcelFilter_3.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewTextBoxColumn_115,
				this.dataGridViewTextBoxColumn_116,
				this.dataGridViewTextBoxColumn_117,
				this.dataGridViewTextBoxColumn_118,
				this.dataGridViewTextBoxColumn_119,
				this.dataGridViewTextBoxColumn_120,
				this.dataGridViewTextBoxColumn_121
			});
			this.dataGridViewExcelFilter_3.DataSource = this.bindingSource_4;
			dataGridViewCellStyle34.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle34.BackColor = SystemColors.Window;
			dataGridViewCellStyle34.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle34.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle34.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle34.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle34.WrapMode = DataGridViewTriState.False;
			this.dataGridViewExcelFilter_3.DefaultCellStyle = dataGridViewCellStyle34;
			this.dataGridViewExcelFilter_3.Dock = DockStyle.Fill;
			this.dataGridViewExcelFilter_3.Location = new System.Drawing.Point(0, 25);
			this.dataGridViewExcelFilter_3.Name = "dgvDocOutStatus";
			this.dataGridViewExcelFilter_3.ReadOnly = true;
			dataGridViewCellStyle35.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle35.BackColor = SystemColors.Control;
			dataGridViewCellStyle35.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle35.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle35.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle35.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle35.WrapMode = DataGridViewTriState.True;
			this.dataGridViewExcelFilter_3.RowHeadersDefaultCellStyle = dataGridViewCellStyle35;
			this.dataGridViewExcelFilter_3.RowHeadersVisible = false;
			this.dataGridViewExcelFilter_3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewExcelFilter_3.Size = new Size(355, 142);
			this.dataGridViewExcelFilter_3.TabIndex = 3;
			this.dataGridViewTextBoxColumn_115.DataPropertyName = "statusName";
			this.dataGridViewTextBoxColumn_115.HeaderText = "Статус";
			this.dataGridViewTextBoxColumn_115.Name = "dataGridViewTextBoxColumn5";
			this.dataGridViewTextBoxColumn_115.ReadOnly = true;
			this.dataGridViewTextBoxColumn_115.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn_116.DataPropertyName = "idDoc";
			this.dataGridViewTextBoxColumn_116.HeaderText = "idDoc";
			this.dataGridViewTextBoxColumn_116.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn_116.ReadOnly = true;
			this.dataGridViewTextBoxColumn_116.Visible = false;
			this.dataGridViewTextBoxColumn_117.DataPropertyName = "idStatus";
			this.dataGridViewTextBoxColumn_117.HeaderText = "idStatus";
			this.dataGridViewTextBoxColumn_117.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn_117.ReadOnly = true;
			this.dataGridViewTextBoxColumn_117.Visible = false;
			this.dataGridViewTextBoxColumn_118.DataPropertyName = "DateChange";
			dataGridViewCellStyle36.Format = "d";
			dataGridViewCellStyle36.NullValue = null;
			this.dataGridViewTextBoxColumn_118.DefaultCellStyle = dataGridViewCellStyle36;
			this.dataGridViewTextBoxColumn_118.HeaderText = "Дата";
			this.dataGridViewTextBoxColumn_118.Name = "dataGridViewTextBoxColumn6";
			this.dataGridViewTextBoxColumn_118.ReadOnly = true;
			this.dataGridViewTextBoxColumn_118.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn_118.Width = 70;
			this.dataGridViewTextBoxColumn_119.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_119.HeaderText = "id";
			this.dataGridViewTextBoxColumn_119.Name = "idStatusDocOutDgvColumn";
			this.dataGridViewTextBoxColumn_119.ReadOnly = true;
			this.dataGridViewTextBoxColumn_119.Visible = false;
			this.dataGridViewTextBoxColumn_120.DataPropertyName = "SendName";
			this.dataGridViewTextBoxColumn_120.HeaderText = "Способ отправки";
			this.dataGridViewTextBoxColumn_120.Name = "sendNameDgvColumn";
			this.dataGridViewTextBoxColumn_120.ReadOnly = true;
			this.dataGridViewTextBoxColumn_121.DataPropertyName = "Comment";
			this.dataGridViewTextBoxColumn_121.HeaderText = "Комментарий";
			this.dataGridViewTextBoxColumn_121.Name = "сommentDocOutStatusDgvColumn";
			this.dataGridViewTextBoxColumn_121.ReadOnly = true;
			this.bindingSource_4.DataMember = "vTC_DocStatus";
			this.bindingSource_4.DataSource = this.class10_0;
			this.toolStrip_3.GripStyle = ToolStripGripStyle.Hidden;
			this.toolStrip_3.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripButton_12,
				this.toolStripButton_13,
				this.toolStripButton_14
			});
			this.toolStrip_3.Location = new System.Drawing.Point(0, 0);
			this.toolStrip_3.Name = "toolStripDocOutStatus";
			this.toolStrip_3.Size = new Size(355, 25);
			this.toolStrip_3.TabIndex = 2;
			this.toolStrip_3.Text = "toolStrip1";
			this.toolStripButton_12.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_12.Image = (Image)componentResourceManager.GetObject("toolBtnAddDocOutStatus.Image");
			this.toolStripButton_12.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_12.Name = "toolBtnAddDocOutStatus";
			this.toolStripButton_12.Size = new Size(23, 22);
			this.toolStripButton_12.Text = "Новый статус";
			this.toolStripButton_12.Click += this.toolStripButton_12_Click;
			this.toolStripButton_13.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_13.Image = (Image)componentResourceManager.GetObject("toolBtnEditDocOutStatus.Image");
			this.toolStripButton_13.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_13.Name = "toolBtnEditDocOutStatus";
			this.toolStripButton_13.Size = new Size(23, 22);
			this.toolStripButton_13.Text = "Редактировать статус";
			this.toolStripButton_13.Click += this.toolStripButton_13_Click;
			this.toolStripButton_14.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_14.Image = (Image)componentResourceManager.GetObject("toolBtnDelDocOutStatus.Image");
			this.toolStripButton_14.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_14.Name = "toolBtnDelDocOutStatus";
			this.toolStripButton_14.Size = new Size(23, 22);
			this.toolStripButton_14.Text = "Удалить статус";
			this.toolStripButton_14.Click += this.toolStripButton_14_Click;
			this.tabPage_4.Controls.Add(this.richTextBox_0);
			this.tabPage_4.Controls.Add(this.label_2);
			this.tabPage_4.Controls.Add(this.dateTimePicker_2);
			this.tabPage_4.Controls.Add(this.label_3);
			this.tabPage_4.Controls.Add(this.textBox_0);
			this.tabPage_4.Controls.Add(this.label_4);
			this.tabPage_4.Controls.Add(this.toolStrip_4);
			this.tabPage_4.Location = new System.Drawing.Point(4, 22);
			this.tabPage_4.Name = "tabPageContractor";
			this.tabPage_4.Padding = new Padding(3);
			this.tabPage_4.Size = new Size(781, 173);
			this.tabPage_4.TabIndex = 4;
			this.tabPage_4.Text = "Договор на ТП";
			this.tabPage_4.UseVisualStyleBackColor = true;
			this.richTextBox_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.richTextBox_0.BackColor = SystemColors.Window;
			this.richTextBox_0.DataBindings.Add(new Binding("Text", this.class10_1, "tTC_Doc.Body", true));
			this.richTextBox_0.Location = new System.Drawing.Point(30, 69);
			this.richTextBox_0.Name = "richTextBox1";
			this.richTextBox_0.ReadOnly = true;
			this.richTextBox_0.Size = new Size(748, 104);
			this.richTextBox_0.TabIndex = 9;
			this.richTextBox_0.Text = "";
			this.class10_1.DataSetName = "DataSetTechConnection";
			this.class10_1.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
			this.label_2.AutoSize = true;
			this.label_2.Location = new System.Drawing.Point(39, 52);
			this.label_2.Name = "label5";
			this.label_2.Size = new Size(70, 13);
			this.label_2.TabIndex = 8;
			this.label_2.Text = "Содержание";
			this.dateTimePicker_2.DataBindings.Add(new Binding("Value", this.class10_1, "tTC_Doc.dateDoc", true));
			this.dateTimePicker_2.Enabled = false;
			this.dateTimePicker_2.Location = new System.Drawing.Point(262, 29);
			this.dateTimePicker_2.Name = "dateTimePicker1";
			this.dateTimePicker_2.Size = new Size(200, 20);
			this.dateTimePicker_2.TabIndex = 7;
			this.label_3.AutoSize = true;
			this.label_3.Location = new System.Drawing.Point(259, 13);
			this.label_3.Name = "label4";
			this.label_3.Size = new Size(33, 13);
			this.label_3.TabIndex = 6;
			this.label_3.Text = "Дата";
			this.textBox_0.BackColor = SystemColors.Window;
			this.textBox_0.DataBindings.Add(new Binding("Text", this.class10_1, "tTC_Doc.numDoc", true));
			this.textBox_0.Location = new System.Drawing.Point(30, 29);
			this.textBox_0.Name = "textBox1";
			this.textBox_0.ReadOnly = true;
			this.textBox_0.Size = new Size(212, 20);
			this.textBox_0.TabIndex = 5;
			this.label_4.AutoSize = true;
			this.label_4.Location = new System.Drawing.Point(39, 13);
			this.label_4.Name = "label3";
			this.label_4.Size = new Size(41, 13);
			this.label_4.TabIndex = 4;
			this.label_4.Text = "Номер";
			this.toolStrip_4.Dock = DockStyle.Left;
			this.toolStrip_4.GripStyle = ToolStripGripStyle.Hidden;
			this.toolStrip_4.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripButton_16,
				this.toolStripButton_17,
				this.toolStripButton_18
			});
			this.toolStrip_4.Location = new System.Drawing.Point(3, 3);
			this.toolStrip_4.Name = "toolStrip1";
			this.toolStrip_4.Size = new Size(24, 167);
			this.toolStrip_4.TabIndex = 3;
			this.toolStrip_4.Text = "toolStrip1";
			this.toolStripButton_16.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_16.Image = (Image)componentResourceManager.GetObject("toolBtnAddContractor.Image");
			this.toolStripButton_16.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_16.Name = "toolBtnAddContractor";
			this.toolStripButton_16.Size = new Size(21, 20);
			this.toolStripButton_16.Text = "Новый документ";
			this.toolStripButton_16.Click += this.toolStripButton_16_Click;
			this.toolStripButton_17.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_17.Image = (Image)componentResourceManager.GetObject("toolBtnEditContractor.Image");
			this.toolStripButton_17.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_17.Name = "toolBtnEditContractor";
			this.toolStripButton_17.Size = new Size(21, 20);
			this.toolStripButton_17.Text = "Редактировать документ";
			this.toolStripButton_17.Click += this.toolStripButton_17_Click;
			this.toolStripButton_18.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_18.Image = (Image)componentResourceManager.GetObject("toolBtnDelContractor.Image");
			this.toolStripButton_18.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_18.Name = "toolBtnDelContractor";
			this.toolStripButton_18.Size = new Size(21, 20);
			this.toolStripButton_18.Text = "Удалить документ";
			this.toolStripButton_18.Click += this.toolStripButton_18_Click;
			this.pevkEfUdfJ.Controls.Add(this.splitContainer_4);
			this.pevkEfUdfJ.Location = new System.Drawing.Point(4, 22);
			this.pevkEfUdfJ.Name = "tabPageActs";
			this.pevkEfUdfJ.Padding = new Padding(3);
			this.pevkEfUdfJ.Size = new Size(781, 173);
			this.pevkEfUdfJ.TabIndex = 5;
			this.pevkEfUdfJ.Text = "Акты";
			this.pevkEfUdfJ.UseVisualStyleBackColor = true;
			this.splitContainer_4.Dock = DockStyle.Fill;
			this.splitContainer_4.Location = new System.Drawing.Point(3, 3);
			this.splitContainer_4.Name = "splitContainerActs";
			this.splitContainer_4.Panel1.Controls.Add(this.dataGridViewExcelFilter_7);
			this.splitContainer_4.Panel1.Controls.Add(this.toolStrip_5);
			this.splitContainer_4.Panel2.Controls.Add(this.dataGridViewExcelFilter_6);
			this.splitContainer_4.Size = new Size(775, 167);
			this.splitContainer_4.SplitterDistance = 505;
			this.splitContainer_4.TabIndex = 0;
			this.dataGridViewExcelFilter_7.AllowUserToAddRows = false;
			this.dataGridViewExcelFilter_7.AllowUserToDeleteRows = false;
			this.dataGridViewExcelFilter_7.AutoGenerateColumns = false;
			dataGridViewCellStyle37.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle37.BackColor = SystemColors.Control;
			dataGridViewCellStyle37.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle37.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle37.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle37.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle37.WrapMode = DataGridViewTriState.True;
			this.dataGridViewExcelFilter_7.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle37;
			this.dataGridViewExcelFilter_7.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewExcelFilter_7.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewTextBoxColumn_108,
				this.dataGridViewTextBoxColumn_109,
				this.dataGridViewTextBoxColumn_110,
				this.dataGridViewTextBoxColumn_111,
				this.dataGridViewTextBoxColumn_112,
				this.dataGridViewTextBoxColumn_113,
				this.dataGridViewTextBoxColumn_114
			});
			this.dataGridViewExcelFilter_7.DataSource = this.bindingSource_7;
			dataGridViewCellStyle38.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle38.BackColor = SystemColors.Window;
			dataGridViewCellStyle38.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle38.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle38.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle38.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle38.WrapMode = DataGridViewTriState.False;
			this.dataGridViewExcelFilter_7.DefaultCellStyle = dataGridViewCellStyle38;
			this.dataGridViewExcelFilter_7.Dock = DockStyle.Fill;
			this.dataGridViewExcelFilter_7.Location = new System.Drawing.Point(30, 0);
			this.dataGridViewExcelFilter_7.Name = "dgvActs";
			this.dataGridViewExcelFilter_7.ReadOnly = true;
			dataGridViewCellStyle39.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle39.BackColor = SystemColors.Control;
			dataGridViewCellStyle39.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle39.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle39.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle39.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle39.WrapMode = DataGridViewTriState.True;
			this.dataGridViewExcelFilter_7.RowHeadersDefaultCellStyle = dataGridViewCellStyle39;
			this.dataGridViewExcelFilter_7.Size = new Size(475, 167);
			this.dataGridViewExcelFilter_7.TabIndex = 4;
			this.dataGridViewExcelFilter_7.CellDoubleClick += this.zDiccocdp8;
			this.dataGridViewTextBoxColumn_108.DataPropertyName = "typeDocName";
			this.dataGridViewTextBoxColumn_108.HeaderText = "Тип";
			this.dataGridViewTextBoxColumn_108.Name = "typeDocNameDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_108.ReadOnly = true;
			this.dataGridViewTextBoxColumn_108.Width = 150;
			this.dataGridViewTextBoxColumn_109.DataPropertyName = "numDoc";
			this.dataGridViewTextBoxColumn_109.HeaderText = "№ акта";
			this.dataGridViewTextBoxColumn_109.Name = "numDocDataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn_109.ReadOnly = true;
			this.dataGridViewTextBoxColumn_110.DataPropertyName = "dateDoc";
			dataGridViewCellStyle40.Format = "d";
			dataGridViewCellStyle40.NullValue = null;
			this.dataGridViewTextBoxColumn_110.DefaultCellStyle = dataGridViewCellStyle40;
			this.dataGridViewTextBoxColumn_110.HeaderText = "Дата";
			this.dataGridViewTextBoxColumn_110.Name = "dateDocDataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn_110.ReadOnly = true;
			this.dataGridViewTextBoxColumn_111.DataPropertyName = "Comment";
			this.dataGridViewTextBoxColumn_111.HeaderText = "Комментарий";
			this.dataGridViewTextBoxColumn_111.Name = "commentDataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn_111.ReadOnly = true;
			this.dataGridViewTextBoxColumn_112.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_112.HeaderText = "id";
			this.dataGridViewTextBoxColumn_112.Name = "idActDgvColumn";
			this.dataGridViewTextBoxColumn_112.ReadOnly = true;
			this.dataGridViewTextBoxColumn_112.Visible = false;
			this.dataGridViewTextBoxColumn_113.DataPropertyName = "TypeDoc";
			this.dataGridViewTextBoxColumn_113.HeaderText = "TypeDoc";
			this.dataGridViewTextBoxColumn_113.Name = "typeActDgvColumn";
			this.dataGridViewTextBoxColumn_113.ReadOnly = true;
			this.dataGridViewTextBoxColumn_113.Visible = false;
			this.dataGridViewTextBoxColumn_114.DataPropertyName = "Body";
			this.dataGridViewTextBoxColumn_114.HeaderText = "Body";
			this.dataGridViewTextBoxColumn_114.Name = "bodyDataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn_114.ReadOnly = true;
			this.dataGridViewTextBoxColumn_114.Visible = false;
			this.bindingSource_7.DataMember = "vTC_Doc";
			this.bindingSource_7.DataSource = this.class10_0;
			this.bindingSource_7.CurrentChanged += this.bindingSource_7_CurrentChanged;
			this.toolStrip_5.Dock = DockStyle.Left;
			this.toolStrip_5.GripStyle = ToolStripGripStyle.Hidden;
			this.toolStrip_5.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripDropDownButton_0,
				this.toolStripButton_19,
				this.toolStripButton_20,
				this.toolStripSeparator_4,
				this.toolStripButton_21
			});
			this.toolStrip_5.Location = new System.Drawing.Point(0, 0);
			this.toolStrip_5.Name = "toolStripActs";
			this.toolStrip_5.Size = new Size(30, 167);
			this.toolStrip_5.TabIndex = 3;
			this.toolStrip_5.Text = "toolStrip1";
			this.toolStripDropDownButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripDropDownButton_0.DropDownItems.AddRange(new ToolStripItem[]
			{
				this.toolStripMenuItem_0,
				this.toolStripMenuItem_1,
				this.toolStripMenuItem_2,
				this.toolStripMenuItem_3,
				this.toolStripMenuItem_4
			});
			this.toolStripDropDownButton_0.Image = (Image)componentResourceManager.GetObject("toolBtnAddAct.Image");
			this.toolStripDropDownButton_0.ImageTransparentColor = Color.Magenta;
			this.toolStripDropDownButton_0.Name = "toolBtnAddAct";
			this.toolStripDropDownButton_0.Size = new Size(27, 20);
			this.toolStripDropDownButton_0.Text = "Новый документ";
			this.toolStripDropDownButton_0.Click += this.toolStripDropDownButton_0_Click;
			this.toolStripMenuItem_0.Name = "toolBtnAddActElectricalInspection";
			this.toolStripMenuItem_0.Size = new Size(345, 22);
			this.toolStripMenuItem_0.Text = "Акт осмотра электроустановки";
			this.toolStripMenuItem_0.Click += this.toolStripMenuItem_0_Click;
			this.toolStripMenuItem_1.Name = "toolBtnAddActPerformingTU";
			this.toolStripMenuItem_1.Size = new Size(345, 22);
			this.toolStripMenuItem_1.Text = "Акт о выполнении ТУ";
			this.toolStripMenuItem_1.Click += this.toolStripMenuItem_1_Click;
			this.toolStripMenuItem_2.Name = "toolBtnAddActTC";
			this.toolStripMenuItem_2.Size = new Size(345, 22);
			this.toolStripMenuItem_2.Text = "Акт о технологическом присоединении";
			this.toolStripMenuItem_2.Click += this.toolStripMenuItem_2_Click;
			this.toolStripMenuItem_3.Name = "toolBtnAddActRBP";
			this.toolStripMenuItem_3.Size = new Size(345, 22);
			this.toolStripMenuItem_3.Text = "Акт разграничения балансовой принадлежности";
			this.toolStripMenuItem_3.Click += this.toolStripMenuItem_3_Click;
			this.toolStripMenuItem_4.Name = "toolBtnAddActOperRep";
			this.toolStripMenuItem_4.Size = new Size(345, 22);
			this.toolStripMenuItem_4.Text = "Акт эксплатационной ответственности";
			this.toolStripMenuItem_4.Click += this.sidcIfjxrO;
			this.toolStripButton_19.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_19.Image = (Image)componentResourceManager.GetObject("toolBtnEditAct.Image");
			this.toolStripButton_19.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_19.Name = "toolBtnEditAct";
			this.toolStripButton_19.Size = new Size(27, 20);
			this.toolStripButton_19.Text = "Редактировать документ";
			this.toolStripButton_19.Click += this.toolStripButton_19_Click;
			this.toolStripButton_20.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_20.Image = (Image)componentResourceManager.GetObject("toolBtnDelAct.Image");
			this.toolStripButton_20.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_20.Name = "toolBtnDelAct";
			this.toolStripButton_20.Size = new Size(27, 20);
			this.toolStripButton_20.Text = "Удалить документ";
			this.toolStripButton_20.Click += this.toolStripButton_20_Click;
			this.toolStripSeparator_4.Name = "toolStripSeparator5";
			this.toolStripSeparator_4.Size = new Size(27, 6);
			this.toolStripButton_21.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_21.Image = (Image)componentResourceManager.GetObject("toolBtnPrintAct.Image");
			this.toolStripButton_21.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_21.Name = "toolBtnPrintAct";
			this.toolStripButton_21.Size = new Size(27, 20);
			this.toolStripButton_21.Text = "Печать";
			this.toolStripButton_21.Click += this.toolStripButton_21_Click;
			this.dataGridViewExcelFilter_6.AllowUserToAddRows = false;
			this.dataGridViewExcelFilter_6.AllowUserToDeleteRows = false;
			this.dataGridViewExcelFilter_6.AllowUserToResizeColumns = false;
			this.dataGridViewExcelFilter_6.AllowUserToResizeRows = false;
			this.dataGridViewExcelFilter_6.AutoGenerateColumns = false;
			dataGridViewCellStyle41.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle41.BackColor = SystemColors.Control;
			dataGridViewCellStyle41.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle41.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle41.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle41.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle41.WrapMode = DataGridViewTriState.True;
			this.dataGridViewExcelFilter_6.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle41;
			this.dataGridViewExcelFilter_6.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewExcelFilter_6.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewLinkColumn_1,
				this.dataGridViewTextBoxColumn_43,
				this.dataGridViewImageColumnNotNull_1
			});
			this.dataGridViewExcelFilter_6.DataSource = this.bindingSource_8;
			dataGridViewCellStyle42.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle42.BackColor = SystemColors.Window;
			dataGridViewCellStyle42.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle42.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle42.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle42.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle42.WrapMode = DataGridViewTriState.False;
			this.dataGridViewExcelFilter_6.DefaultCellStyle = dataGridViewCellStyle42;
			this.dataGridViewExcelFilter_6.Dock = DockStyle.Fill;
			this.dataGridViewExcelFilter_6.EditMode = DataGridViewEditMode.EditProgrammatically;
			this.dataGridViewExcelFilter_6.Location = new System.Drawing.Point(0, 0);
			this.dataGridViewExcelFilter_6.Name = "dgvActsFiles";
			this.dataGridViewExcelFilter_6.ReadOnly = true;
			dataGridViewCellStyle43.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle43.BackColor = SystemColors.Control;
			dataGridViewCellStyle43.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle43.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle43.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle43.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle43.WrapMode = DataGridViewTriState.True;
			this.dataGridViewExcelFilter_6.RowHeadersDefaultCellStyle = dataGridViewCellStyle43;
			this.dataGridViewExcelFilter_6.RowHeadersVisible = false;
			this.dataGridViewExcelFilter_6.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewExcelFilter_6.Size = new Size(266, 167);
			this.dataGridViewExcelFilter_6.TabIndex = 8;
			this.dataGridViewExcelFilter_6.VirtualMode = true;
			this.dataGridViewExcelFilter_6.CellContentClick += this.dataGridViewExcelFilter_6_CellContentClick;
			this.dataGridViewExcelFilter_6.CellValueNeeded += this.dataGridViewExcelFilter_6_CellValueNeeded;
			this.dataGridViewLinkColumn_1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewLinkColumn_1.DataPropertyName = "FileName";
			this.dataGridViewLinkColumn_1.HeaderText = "Файлы";
			this.dataGridViewLinkColumn_1.Name = "fileNameActdgvColumn";
			this.dataGridViewLinkColumn_1.ReadOnly = true;
			this.dataGridViewLinkColumn_1.Resizable = DataGridViewTriState.True;
			this.dataGridViewLinkColumn_1.SortMode = DataGridViewColumnSortMode.Automatic;
			this.dataGridViewTextBoxColumn_43.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_43.HeaderText = "id";
			this.dataGridViewTextBoxColumn_43.Name = "idActFileDgvColumn";
			this.dataGridViewTextBoxColumn_43.ReadOnly = true;
			this.dataGridViewTextBoxColumn_43.Visible = false;
			dataGridViewCellStyle44.NullValue = null;
			this.dataGridViewImageColumnNotNull_1.DefaultCellStyle = dataGridViewCellStyle44;
			this.dataGridViewImageColumnNotNull_1.HeaderText = "";
			this.dataGridViewImageColumnNotNull_1.ImageLayout = DataGridViewImageCellLayout.Zoom;
			this.dataGridViewImageColumnNotNull_1.Name = "imageActDgvColumn";
			this.dataGridViewImageColumnNotNull_1.ReadOnly = true;
			this.dataGridViewImageColumnNotNull_1.Width = 30;
			this.bindingSource_8.DataMember = "tTC_DocFile";
			this.bindingSource_8.DataSource = this.dataSet_0;
			this.dataSet_0.DataSetName = "NewDataSet";
			this.dataSet_0.Tables.AddRange(new System.Data.DataTable[]
			{
				this.dataTable_0,
				this.dataTable_1
			});
			this.dataTable_0.Columns.AddRange(new DataColumn[]
			{
				this.dataColumn_0,
				this.dataColumn_1
			});
			this.dataTable_0.TableName = "tTC_DocFile";
			this.dataColumn_0.ColumnName = "id";
			this.dataColumn_0.DataType = typeof(int);
			this.dataColumn_1.ColumnName = "FileName";
			this.dataTable_1.Columns.AddRange(new DataColumn[]
			{
				this.dataColumn_2,
				this.dataColumn_3
			});
			this.dataTable_1.TableName = "tAbnObjDoc_File";
			this.dataColumn_2.ColumnName = "id";
			this.dataColumn_3.ColumnName = "FileName";
			this.tabPage_5.Controls.Add(this.dataGridViewExcelFilter_8);
			this.tabPage_5.Controls.Add(this.toolStrip_6);
			this.tabPage_5.Location = new System.Drawing.Point(4, 22);
			this.tabPage_5.Name = "tpMemorandum";
			this.tabPage_5.Padding = new Padding(3);
			this.tabPage_5.Size = new Size(781, 173);
			this.tabPage_5.TabIndex = 6;
			this.tabPage_5.Text = "Осущ. тех. присоединения";
			this.tabPage_5.UseVisualStyleBackColor = true;
			this.dataGridViewExcelFilter_8.AllowUserToAddRows = false;
			this.dataGridViewExcelFilter_8.AllowUserToDeleteRows = false;
			this.dataGridViewExcelFilter_8.AllowUserToOrderColumns = true;
			this.dataGridViewExcelFilter_8.AllowUserToVisibleColumns = false;
			this.dataGridViewExcelFilter_8.AutoGenerateColumns = false;
			dataGridViewCellStyle45.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle45.BackColor = SystemColors.Control;
			dataGridViewCellStyle45.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle45.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle45.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle45.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle45.WrapMode = DataGridViewTriState.True;
			this.dataGridViewExcelFilter_8.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle45;
			this.dataGridViewExcelFilter_8.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewExcelFilter_8.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewTextBoxColumn_122,
				this.dataGridViewTextBoxColumn_123,
				this.dataGridViewTextBoxColumn_124,
				this.dataGridViewTextBoxColumn_125,
				this.dataGridViewTextBoxColumn_126,
				this.dataGridViewTextBoxColumn_127,
				this.dataGridViewTextBoxColumn_128,
				this.dataGridViewTextBoxColumn_129,
				this.dataGridViewTextBoxColumn_130,
				this.dataGridViewTextBoxColumn_131,
				this.dataGridViewTextBoxColumn_132,
				this.dataGridViewTextBoxColumn_133,
				this.dataGridViewTextBoxColumn_134,
				this.dataGridViewTextBoxColumn_135,
				this.dataGridViewTextBoxColumn_136
			});
			this.dataGridViewExcelFilter_8.DataSource = this.bindingSource_9;
			dataGridViewCellStyle46.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle46.BackColor = SystemColors.Window;
			dataGridViewCellStyle46.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle46.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle46.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle46.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle46.WrapMode = DataGridViewTriState.False;
			this.dataGridViewExcelFilter_8.DefaultCellStyle = dataGridViewCellStyle46;
			this.dataGridViewExcelFilter_8.Dock = DockStyle.Fill;
			this.dataGridViewExcelFilter_8.Location = new System.Drawing.Point(36, 3);
			this.dataGridViewExcelFilter_8.Name = "dgvMemorandum";
			this.dataGridViewExcelFilter_8.ReadOnly = true;
			dataGridViewCellStyle47.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle47.BackColor = SystemColors.Control;
			dataGridViewCellStyle47.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle47.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle47.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle47.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle47.WrapMode = DataGridViewTriState.True;
			this.dataGridViewExcelFilter_8.RowHeadersDefaultCellStyle = dataGridViewCellStyle47;
			this.dataGridViewExcelFilter_8.RowHeadersWidth = 21;
			this.dataGridViewExcelFilter_8.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewExcelFilter_8.Size = new Size(742, 167);
			this.dataGridViewExcelFilter_8.TabIndex = 5;
			this.dataGridViewExcelFilter_8.VirtualMode = true;
			this.dataGridViewExcelFilter_8.CellDoubleClick += this.dataGridViewExcelFilter_8_CellDoubleClick;
			this.dataGridViewExcelFilter_8.DataError += this.dataGridViewExcelFilter_8_DataError;
			this.dataGridViewTextBoxColumn_122.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_122.HeaderText = "id";
			this.dataGridViewTextBoxColumn_122.Name = "idDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_122.ReadOnly = true;
			this.dataGridViewTextBoxColumn_122.Visible = false;
			this.dataGridViewTextBoxColumn_123.DataPropertyName = "idTehConnect";
			this.dataGridViewTextBoxColumn_123.HeaderText = "idTehConnect";
			this.dataGridViewTextBoxColumn_123.Name = "idTehConnectDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_123.ReadOnly = true;
			this.dataGridViewTextBoxColumn_123.Visible = false;
			this.dataGridViewTextBoxColumn_124.DataPropertyName = "idWorker";
			this.dataGridViewTextBoxColumn_124.HeaderText = "idWorker";
			this.dataGridViewTextBoxColumn_124.Name = "idWorkerDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_124.ReadOnly = true;
			this.dataGridViewTextBoxColumn_124.Visible = false;
			this.dataGridViewTextBoxColumn_125.DataPropertyName = "UniversalID";
			this.dataGridViewTextBoxColumn_125.HeaderText = "UniversalID";
			this.dataGridViewTextBoxColumn_125.Name = "universalIDDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_125.ReadOnly = true;
			this.dataGridViewTextBoxColumn_125.Visible = false;
			this.dataGridViewTextBoxColumn_126.DataPropertyName = "ctb_InheritedID";
			this.dataGridViewTextBoxColumn_126.HeaderText = "ctb_InheritedID";
			this.dataGridViewTextBoxColumn_126.Name = "ctbInheritedIDDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_126.ReadOnly = true;
			this.dataGridViewTextBoxColumn_126.Visible = false;
			this.dataGridViewTextBoxColumn_127.DataPropertyName = "Status";
			this.dataGridViewTextBoxColumn_127.HeaderText = "Статус";
			this.dataGridViewTextBoxColumn_127.Name = "statusDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_127.ReadOnly = true;
			this.dataGridViewTextBoxColumn_127.Resizable = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_128.DataPropertyName = "StatusOrder";
			this.dataGridViewTextBoxColumn_128.HeaderText = "Статус поручения";
			this.dataGridViewTextBoxColumn_128.Name = "statusOrderDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_128.ReadOnly = true;
			this.dataGridViewTextBoxColumn_128.Resizable = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_128.Width = 150;
			this.dataGridViewTextBoxColumn_129.DataPropertyName = "SignDate";
			this.dataGridViewTextBoxColumn_129.HeaderText = "Дата подписания";
			this.dataGridViewTextBoxColumn_129.Name = "signDateDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_129.ReadOnly = true;
			this.dataGridViewTextBoxColumn_130.DataPropertyName = "RgNum";
			this.dataGridViewTextBoxColumn_130.HeaderText = "Рег. номер";
			this.dataGridViewTextBoxColumn_130.Name = "rgNumDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_130.ReadOnly = true;
			this.dataGridViewTextBoxColumn_131.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_131.DataPropertyName = "Subject";
			this.dataGridViewTextBoxColumn_131.HeaderText = "По вопросу";
			this.dataGridViewTextBoxColumn_131.Name = "subjectDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_131.ReadOnly = true;
			this.dataGridViewTextBoxColumn_132.DataPropertyName = "Body_C";
			this.dataGridViewTextBoxColumn_132.HeaderText = "Body_C";
			this.dataGridViewTextBoxColumn_132.Name = "bodyCDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_132.ReadOnly = true;
			this.dataGridViewTextBoxColumn_132.Visible = false;
			this.dataGridViewTextBoxColumn_133.DataPropertyName = "RespDate";
			this.dataGridViewTextBoxColumn_133.HeaderText = "RespDate";
			this.dataGridViewTextBoxColumn_133.Name = "respDateDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_133.ReadOnly = true;
			this.dataGridViewTextBoxColumn_133.Visible = false;
			this.dataGridViewTextBoxColumn_134.DataPropertyName = "RespNum";
			this.dataGridViewTextBoxColumn_134.HeaderText = "RespNum";
			this.dataGridViewTextBoxColumn_134.Name = "respNumDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_134.ReadOnly = true;
			this.dataGridViewTextBoxColumn_134.Visible = false;
			this.dataGridViewTextBoxColumn_135.DataPropertyName = "CorrName";
			this.dataGridViewTextBoxColumn_135.HeaderText = "CorrName";
			this.dataGridViewTextBoxColumn_135.Name = "corrNameDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_135.ReadOnly = true;
			this.dataGridViewTextBoxColumn_135.Visible = false;
			this.dataGridViewTextBoxColumn_136.DataPropertyName = "ctbDateCreate";
			this.dataGridViewTextBoxColumn_136.HeaderText = "ctbDateCreate";
			this.dataGridViewTextBoxColumn_136.Name = "ctbDateCreateDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_136.ReadOnly = true;
			this.dataGridViewTextBoxColumn_136.Visible = false;
			this.bindingSource_9.DataMember = "vJ_Memorandum";
			this.bindingSource_9.DataSource = this.class10_0;
			this.toolStrip_6.Dock = DockStyle.Left;
			this.toolStrip_6.GripStyle = ToolStripGripStyle.Hidden;
			this.toolStrip_6.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripSplitButton_0,
				this.toolStripButton_25,
				this.toolStripButton_24,
				this.toolStripButton_22,
				this.toolStripSeparator_5,
				this.toolStripButton_23
			});
			this.toolStrip_6.Location = new System.Drawing.Point(3, 3);
			this.toolStrip_6.Name = "tsbMemorandum";
			this.toolStrip_6.Size = new Size(33, 167);
			this.toolStrip_6.TabIndex = 4;
			this.toolStrip_6.Text = "toolStrip1";
			this.toolStripSplitButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripSplitButton_0.DropDownItems.AddRange(new ToolStripItem[]
			{
				this.pcueoNrZpi,
				this.toolStripMenuItem_5
			});
			this.toolStripSplitButton_0.Image = Resources.ElementAdd;
			this.toolStripSplitButton_0.ImageTransparentColor = Color.Magenta;
			this.toolStripSplitButton_0.Name = "Добавить";
			this.toolStripSplitButton_0.Size = new Size(30, 20);
			this.toolStripSplitButton_0.Text = "Добавить";
			this.pcueoNrZpi.Name = "tsmiSendMemorandum";
			this.pcueoNrZpi.Size = new Size(163, 22);
			this.pcueoNrZpi.Text = "Новый";
			this.pcueoNrZpi.Click += this.pcueoNrZpi_Click;
			this.toolStripMenuItem_5.Name = "tsmiExistsMemorandum";
			this.toolStripMenuItem_5.Size = new Size(163, 22);
			this.toolStripMenuItem_5.Text = "Существующий";
			this.toolStripMenuItem_5.Click += this.toolStripMenuItem_5_Click;
			this.toolStripButton_25.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_25.Image = Resources.ElementEdit;
			this.toolStripButton_25.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_25.Name = "tsbEdit";
			this.toolStripButton_25.Size = new Size(30, 20);
			this.toolStripButton_25.Text = "Редактирование";
			this.toolStripButton_25.Click += this.toolStripButton_25_Click;
			this.toolStripButton_24.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_24.Image = Resources.ElementInformation;
			this.toolStripButton_24.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_24.Name = "tsbView";
			this.toolStripButton_24.Size = new Size(30, 20);
			this.toolStripButton_24.Text = "Открыть";
			this.toolStripButton_24.Click += this.toolStripButton_24_Click;
			this.toolStripButton_22.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_22.Image = (Image)componentResourceManager.GetObject("toolStripButton3.Image");
			this.toolStripButton_22.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_22.Name = "toolStripButton3";
			this.toolStripButton_22.Size = new Size(30, 20);
			this.toolStripButton_22.Text = "Удалить";
			this.toolStripButton_22.Click += this.toolStripButton_22_Click;
			this.toolStripSeparator_5.Name = "toolStripSeparator6";
			this.toolStripSeparator_5.Size = new Size(30, 6);
			this.toolStripButton_23.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_23.Image = Resources.refresh_16;
			this.toolStripButton_23.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_23.Name = "tsbRefresh";
			this.toolStripButton_23.Size = new Size(30, 20);
			this.toolStripButton_23.Text = "Обновить";
			this.toolStripButton_23.Click += this.toolStripButton_23_Click;
			this.dataGridViewFilterTextBoxColumn_0.DataPropertyName = "NumDateIn";
			dataGridViewCellStyle48.WrapMode = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_0.DefaultCellStyle = dataGridViewCellStyle48;
			this.dataGridViewFilterTextBoxColumn_0.HeaderText = "№, дата входящего";
			this.dataGridViewFilterTextBoxColumn_0.Name = "dataGridViewFilterTextBoxColumn1";
			this.dataGridViewFilterTextBoxColumn_0.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_1.DataPropertyName = "numDoc";
			this.dataGridViewFilterTextBoxColumn_1.HeaderText = "№ ТУ";
			this.dataGridViewFilterTextBoxColumn_1.Name = "dataGridViewFilterTextBoxColumn2";
			this.dataGridViewFilterTextBoxColumn_1.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_2.DataPropertyName = "dateDoc";
			this.dataGridViewFilterTextBoxColumn_2.HeaderText = "Дата выдачи";
			this.dataGridViewFilterTextBoxColumn_2.Name = "dataGridViewFilterTextBoxColumn3";
			this.dataGridViewFilterTextBoxColumn_2.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_3.DataPropertyName = "body";
			dataGridViewCellStyle49.WrapMode = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_3.DefaultCellStyle = dataGridViewCellStyle49;
			this.dataGridViewFilterTextBoxColumn_3.HeaderText = "Содержание";
			this.dataGridViewFilterTextBoxColumn_3.Name = "dataGridViewFilterTextBoxColumn4";
			this.dataGridViewFilterTextBoxColumn_3.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_4.DataPropertyName = "nameAbn";
			dataGridViewCellStyle50.WrapMode = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_4.DefaultCellStyle = dataGridViewCellStyle50;
			this.dataGridViewFilterTextBoxColumn_4.HeaderText = "Потребитель";
			this.dataGridViewFilterTextBoxColumn_4.Name = "dataGridViewFilterTextBoxColumn5";
			this.dataGridViewFilterTextBoxColumn_4.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_5.DataPropertyName = "nameObj";
			this.dataGridViewFilterTextBoxColumn_5.HeaderText = "Объект";
			this.dataGridViewFilterTextBoxColumn_5.Name = "dataGridViewFilterTextBoxColumn6";
			this.dataGridViewFilterTextBoxColumn_5.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_6.DataPropertyName = "address";
			this.dataGridViewFilterTextBoxColumn_6.HeaderText = "Адрес";
			this.dataGridViewFilterTextBoxColumn_6.Name = "dataGridViewFilterTextBoxColumn7";
			this.dataGridViewFilterTextBoxColumn_6.Resizable = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_44.DataPropertyName = "addressFull";
			this.dataGridViewTextBoxColumn_44.HeaderText = "addressFull";
			this.dataGridViewTextBoxColumn_44.Name = "dataGridViewTextBoxColumn7";
			this.dataGridViewTextBoxColumn_44.Visible = false;
			this.dataGridViewFilterTextBoxColumn_7.DataPropertyName = "Power";
			this.dataGridViewFilterTextBoxColumn_7.HeaderText = "Существующая мощность";
			this.dataGridViewFilterTextBoxColumn_7.Name = "dataGridViewFilterTextBoxColumn8";
			this.dataGridViewFilterTextBoxColumn_7.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_8.DataPropertyName = "PowerAdd";
			this.dataGridViewFilterTextBoxColumn_8.HeaderText = "Доп мощность";
			this.dataGridViewFilterTextBoxColumn_8.Name = "dataGridViewFilterTextBoxColumn9";
			this.dataGridViewFilterTextBoxColumn_8.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_9.DataPropertyName = "PowerSum";
			this.dataGridViewFilterTextBoxColumn_9.HeaderText = "Максимальная мощность";
			this.dataGridViewFilterTextBoxColumn_9.Name = "dataGridViewFilterTextBoxColumn10";
			this.dataGridViewFilterTextBoxColumn_9.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_10.DataPropertyName = "VoltageLevel";
			this.dataGridViewFilterTextBoxColumn_10.HeaderText = "Ур-нь напр-ния";
			this.dataGridViewFilterTextBoxColumn_10.Name = "dataGridViewFilterTextBoxColumn11";
			this.dataGridViewFilterTextBoxColumn_10.Width = 70;
			this.dataGridViewTextBoxColumn_45.DataPropertyName = "Category";
			this.dataGridViewTextBoxColumn_45.HeaderText = "Category";
			this.dataGridViewTextBoxColumn_45.Name = "dataGridViewTextBoxColumn8";
			this.dataGridViewTextBoxColumn_45.Visible = false;
			this.dataGridViewFilterTextBoxColumn_11.DataPropertyName = "CategoryName";
			this.dataGridViewFilterTextBoxColumn_11.HeaderText = "Категор. элек-ния";
			this.dataGridViewFilterTextBoxColumn_11.Name = "dataGridViewFilterTextBoxColumn12";
			this.dataGridViewFilterTextBoxColumn_11.Resizable = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_46.DataPropertyName = "idSchmObj";
			this.dataGridViewTextBoxColumn_46.HeaderText = "idSchmObj";
			this.dataGridViewTextBoxColumn_46.Name = "dataGridViewTextBoxColumn9";
			this.dataGridViewTextBoxColumn_46.Visible = false;
			this.dataGridViewFilterTextBoxColumn_12.DataPropertyName = "numContractor";
			this.dataGridViewFilterTextBoxColumn_12.HeaderText = "№ договора";
			this.dataGridViewFilterTextBoxColumn_12.Name = "dataGridViewFilterTextBoxColumn13";
			this.dataGridViewFilterTextBoxColumn_13.DataPropertyName = "dateContractor";
			this.dataGridViewFilterTextBoxColumn_13.HeaderText = "Дата договора";
			this.dataGridViewFilterTextBoxColumn_13.Name = "dataGridViewFilterTextBoxColumn14";
			this.dataGridViewFilterTextBoxColumn_14.DataPropertyName = "PerformerFIO";
			this.dataGridViewFilterTextBoxColumn_14.HeaderText = "Исполнитель";
			this.dataGridViewFilterTextBoxColumn_14.Name = "dataGridViewFilterTextBoxColumn15";
			this.dataGridViewFilterTextBoxColumn_14.Resizable = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_47.DataPropertyName = "NameDocOut";
			dataGridViewCellStyle51.WrapMode = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_47.DefaultCellStyle = dataGridViewCellStyle51;
			this.dataGridViewTextBoxColumn_47.HeaderText = "Выданные документы";
			this.dataGridViewTextBoxColumn_47.Name = "dataGridViewTextBoxColumn10";
			this.dataGridViewTextBoxColumn_48.DataPropertyName = "Performer";
			this.dataGridViewTextBoxColumn_48.HeaderText = "Performer";
			this.dataGridViewTextBoxColumn_48.Name = "dataGridViewTextBoxColumn11";
			this.dataGridViewTextBoxColumn_48.Visible = false;
			this.dataGridViewFilterTextBoxColumn_15.DataPropertyName = "SchmTP";
			dataGridViewCellStyle52.WrapMode = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_15.DefaultCellStyle = dataGridViewCellStyle52;
			this.dataGridViewFilterTextBoxColumn_15.HeaderText = "ТП";
			this.dataGridViewFilterTextBoxColumn_15.Name = "dataGridViewFilterTextBoxColumn16";
			this.dataGridViewFilterTextBoxColumn_16.DataPropertyName = "SchmCP";
			dataGridViewCellStyle53.WrapMode = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_16.DefaultCellStyle = dataGridViewCellStyle53;
			this.dataGridViewFilterTextBoxColumn_16.HeaderText = "ЦП";
			this.dataGridViewFilterTextBoxColumn_16.Name = "dataGridViewFilterTextBoxColumn17";
			this.dataGridViewFilterTextBoxColumn_16.Width = 150;
			this.dataGridViewTextBoxColumn_49.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_49.HeaderText = "id";
			this.dataGridViewTextBoxColumn_49.Name = "dataGridViewTextBoxColumn12";
			this.dataGridViewTextBoxColumn_49.Visible = false;
			this.dataGridViewTextBoxColumn_50.DataPropertyName = "idDoc";
			this.dataGridViewTextBoxColumn_50.HeaderText = "idDoc";
			this.dataGridViewTextBoxColumn_50.Name = "dataGridViewTextBoxColumn13";
			this.dataGridViewTextBoxColumn_50.Visible = false;
			this.dataGridViewTextBoxColumn_51.DataPropertyName = "dateChange";
			this.dataGridViewTextBoxColumn_51.HeaderText = "dateChange";
			this.dataGridViewTextBoxColumn_51.Name = "dataGridViewTextBoxColumn14";
			this.dataGridViewTextBoxColumn_51.Visible = false;
			this.dataGridViewTextBoxColumn_52.DataPropertyName = "idTemplate";
			this.dataGridViewTextBoxColumn_52.HeaderText = "idTemplate";
			this.dataGridViewTextBoxColumn_52.Name = "dataGridViewTextBoxColumn15";
			this.dataGridViewTextBoxColumn_52.Visible = false;
			this.dataGridViewTextBoxColumn_53.DataPropertyName = "numDateIn";
			dataGridViewCellStyle54.WrapMode = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_53.DefaultCellStyle = dataGridViewCellStyle54;
			this.dataGridViewTextBoxColumn_53.HeaderText = "№, дата вход.";
			this.dataGridViewTextBoxColumn_53.Name = "dataGridViewTextBoxColumn16";
			this.dataGridViewTextBoxColumn_53.Width = 80;
			this.dataGridViewTextBoxColumn_54.DataPropertyName = "numDoc";
			this.dataGridViewTextBoxColumn_54.HeaderText = "numDoc";
			this.dataGridViewTextBoxColumn_54.Name = "dataGridViewTextBoxColumn17";
			this.dataGridViewTextBoxColumn_54.Visible = false;
			this.dataGridViewTextBoxColumn_55.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_55.HeaderText = "id";
			this.dataGridViewTextBoxColumn_55.Name = "dataGridViewTextBoxColumn18";
			this.dataGridViewTextBoxColumn_55.Visible = false;
			this.dataGridViewTextBoxColumn_56.DataPropertyName = "dateDoc";
			this.dataGridViewTextBoxColumn_56.HeaderText = "Дата получения";
			this.dataGridViewTextBoxColumn_56.Name = "dataGridViewTextBoxColumn19";
			this.dataGridViewTextBoxColumn_56.Width = 80;
			this.dataGridViewTextBoxColumn_57.DataPropertyName = "TypeDoc";
			this.dataGridViewTextBoxColumn_57.HeaderText = "TypeDoc";
			this.dataGridViewTextBoxColumn_57.Name = "dataGridViewTextBoxColumn20";
			this.dataGridViewTextBoxColumn_57.Visible = false;
			this.dataGridViewTextBoxColumn_58.DataPropertyName = "numIn";
			this.dataGridViewTextBoxColumn_58.HeaderText = "numIn";
			this.dataGridViewTextBoxColumn_58.Name = "dataGridViewTextBoxColumn21";
			this.dataGridViewTextBoxColumn_58.Visible = false;
			this.dataGridViewTextBoxColumn_59.DataPropertyName = "dateIn";
			this.dataGridViewTextBoxColumn_59.HeaderText = "dateIn";
			this.dataGridViewTextBoxColumn_59.Name = "dataGridViewTextBoxColumn22";
			this.dataGridViewTextBoxColumn_59.Visible = false;
			this.dataGridViewTextBoxColumn_60.DataPropertyName = "idAbn";
			this.dataGridViewTextBoxColumn_60.HeaderText = "idAbn";
			this.dataGridViewTextBoxColumn_60.Name = "dataGridViewTextBoxColumn23";
			this.dataGridViewTextBoxColumn_60.Visible = false;
			this.dataGridViewTextBoxColumn_61.DataPropertyName = "idAbnObj";
			this.dataGridViewTextBoxColumn_61.HeaderText = "idAbnObj";
			this.dataGridViewTextBoxColumn_61.Name = "dataGridViewTextBoxColumn24";
			this.dataGridViewTextBoxColumn_61.Visible = false;
			this.dataGridViewTextBoxColumn_62.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_62.DataPropertyName = "body";
			dataGridViewCellStyle55.WrapMode = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_62.DefaultCellStyle = dataGridViewCellStyle55;
			this.dataGridViewTextBoxColumn_62.HeaderText = "Тело письма";
			this.dataGridViewTextBoxColumn_62.Name = "dataGridViewTextBoxColumn25";
			this.dataGridViewTextBoxColumn_63.DataPropertyName = "PowerCurrent";
			this.dataGridViewTextBoxColumn_63.HeaderText = "Текущая мощность";
			this.dataGridViewTextBoxColumn_63.Name = "dataGridViewTextBoxColumn26";
			this.dataGridViewTextBoxColumn_63.Width = 70;
			this.dataGridViewTextBoxColumn_64.DataPropertyName = "PowerAdd";
			this.dataGridViewTextBoxColumn_64.HeaderText = "Доп мощность";
			this.dataGridViewTextBoxColumn_64.Name = "dataGridViewTextBoxColumn27";
			this.dataGridViewTextBoxColumn_64.Width = 70;
			this.dataGridViewTextBoxColumn_65.DataPropertyName = "Power";
			this.dataGridViewTextBoxColumn_65.HeaderText = "Суммарная мощность";
			this.dataGridViewTextBoxColumn_65.Name = "dataGridViewTextBoxColumn28";
			this.dataGridViewTextBoxColumn_65.Width = 70;
			this.dataGridViewTextBoxColumn_66.DataPropertyName = "VoltageName";
			this.dataGridViewTextBoxColumn_66.HeaderText = "Напряжение";
			this.dataGridViewTextBoxColumn_66.Name = "dataGridViewTextBoxColumn29";
			this.dataGridViewTextBoxColumn_66.Width = 70;
			this.dataGridViewTextBoxColumn_67.DataPropertyName = "Comment";
			this.dataGridViewTextBoxColumn_67.HeaderText = "Комментарий";
			this.dataGridViewTextBoxColumn_67.Name = "dataGridViewTextBoxColumn30";
			this.dataGridViewTextBoxColumn_67.Width = 70;
			this.dataGridViewTextBoxColumn_68.DataPropertyName = "VoltageLevel";
			this.dataGridViewTextBoxColumn_68.HeaderText = "VoltageLevel";
			this.dataGridViewTextBoxColumn_68.Name = "dataGridViewTextBoxColumn31";
			this.dataGridViewTextBoxColumn_68.Visible = false;
			this.dataGridViewTextBoxColumn_69.DataPropertyName = "VoltageValue";
			this.dataGridViewTextBoxColumn_69.HeaderText = "VoltageValue";
			this.dataGridViewTextBoxColumn_69.Name = "dataGridViewTextBoxColumn32";
			this.dataGridViewTextBoxColumn_69.Visible = false;
			this.dataGridViewTextBoxColumn_70.DataPropertyName = "IdParent";
			this.dataGridViewTextBoxColumn_70.HeaderText = "IdParent";
			this.dataGridViewTextBoxColumn_70.Name = "dataGridViewTextBoxColumn33";
			this.dataGridViewTextBoxColumn_70.Visible = false;
			this.dataGridViewTextBoxColumn_71.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_71.DataPropertyName = "Work";
			dataGridViewCellStyle56.WrapMode = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_71.DefaultCellStyle = dataGridViewCellStyle56;
			this.dataGridViewTextBoxColumn_71.HeaderText = "Работы сетевой организации";
			this.dataGridViewTextBoxColumn_71.Name = "dataGridViewTextBoxColumn34";
			this.dataGridViewTextBoxColumn_71.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn_72.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_72.HeaderText = "id";
			this.dataGridViewTextBoxColumn_72.Name = "dataGridViewTextBoxColumn35";
			this.dataGridViewTextBoxColumn_72.Visible = false;
			this.dataGridViewTextBoxColumn_73.DataPropertyName = "idTU";
			this.dataGridViewTextBoxColumn_73.HeaderText = "idTU";
			this.dataGridViewTextBoxColumn_73.Name = "dataGridViewTextBoxColumn36";
			this.dataGridViewTextBoxColumn_73.Visible = false;
			this.dataGridViewTextBoxColumn_74.DataPropertyName = "num";
			this.dataGridViewTextBoxColumn_74.HeaderText = "num";
			this.dataGridViewTextBoxColumn_74.Name = "dataGridViewTextBoxColumn37";
			this.dataGridViewTextBoxColumn_74.Visible = false;
			this.dataGridViewTextBoxColumn_75.DataPropertyName = "TypeWork";
			this.dataGridViewTextBoxColumn_75.HeaderText = "TypeWork";
			this.dataGridViewTextBoxColumn_75.Name = "dataGridViewTextBoxColumn38";
			this.dataGridViewTextBoxColumn_75.Visible = false;
			this.dataGridViewTextBoxColumn_76.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_76.DataPropertyName = "Work";
			dataGridViewCellStyle57.WrapMode = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_76.DefaultCellStyle = dataGridViewCellStyle57;
			this.dataGridViewTextBoxColumn_76.HeaderText = "Работы заказчика";
			this.dataGridViewTextBoxColumn_76.Name = "dataGridViewTextBoxColumn39";
			this.dataGridViewTextBoxColumn_76.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn_77.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_77.HeaderText = "id";
			this.dataGridViewTextBoxColumn_77.Name = "dataGridViewTextBoxColumn40";
			this.dataGridViewTextBoxColumn_77.Visible = false;
			this.dataGridViewTextBoxColumn_78.DataPropertyName = "idTU";
			this.dataGridViewTextBoxColumn_78.HeaderText = "idTU";
			this.dataGridViewTextBoxColumn_78.Name = "dataGridViewTextBoxColumn41";
			this.dataGridViewTextBoxColumn_78.Visible = false;
			this.dataGridViewTextBoxColumn_79.DataPropertyName = "num";
			this.dataGridViewTextBoxColumn_79.HeaderText = "num";
			this.dataGridViewTextBoxColumn_79.Name = "dataGridViewTextBoxColumn42";
			this.dataGridViewTextBoxColumn_79.Visible = false;
			this.dataGridViewTextBoxColumn_80.DataPropertyName = "TypeWork";
			this.dataGridViewTextBoxColumn_80.HeaderText = "TypeWork";
			this.dataGridViewTextBoxColumn_80.Name = "dataGridViewTextBoxColumn43";
			this.dataGridViewTextBoxColumn_80.Visible = false;
			this.dataGridViewTextBoxColumn_81.DataPropertyName = "TypeDocNameOut";
			this.dataGridViewTextBoxColumn_81.HeaderText = "Документ";
			this.dataGridViewTextBoxColumn_81.Name = "dataGridViewTextBoxColumn44";
			this.dataGridViewTextBoxColumn_82.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_82.HeaderText = "id";
			this.dataGridViewTextBoxColumn_82.Name = "dataGridViewTextBoxColumn45";
			this.dataGridViewTextBoxColumn_82.Visible = false;
			this.eedhdsdanG.DataPropertyName = "numDateDocOut";
			this.eedhdsdanG.HeaderText = "numDateDocOut";
			this.eedhdsdanG.Name = "dataGridViewTextBoxColumn46";
			this.eedhdsdanG.Visible = false;
			this.dataGridViewTextBoxColumn_83.DataPropertyName = "idDoc";
			this.dataGridViewTextBoxColumn_83.HeaderText = "idDoc";
			this.dataGridViewTextBoxColumn_83.Name = "dataGridViewTextBoxColumn47";
			this.dataGridViewTextBoxColumn_83.Visible = false;
			this.dataGridViewTextBoxColumn_84.DataPropertyName = "numDocOut";
			this.dataGridViewTextBoxColumn_84.HeaderText = "№";
			this.dataGridViewTextBoxColumn_84.Name = "dataGridViewTextBoxColumn48";
			this.dataGridViewTextBoxColumn_85.DataPropertyName = "TypeDocOut";
			this.dataGridViewTextBoxColumn_85.HeaderText = "TypeDocOut";
			this.dataGridViewTextBoxColumn_85.Name = "dataGridViewTextBoxColumn49";
			this.dataGridViewTextBoxColumn_85.Visible = false;
			this.dataGridViewTextBoxColumn_86.DataPropertyName = "idDocOut";
			this.dataGridViewTextBoxColumn_86.HeaderText = "idDocOut";
			this.dataGridViewTextBoxColumn_86.Name = "dataGridViewTextBoxColumn50";
			this.dataGridViewTextBoxColumn_86.Visible = false;
			this.dataGridViewTextBoxColumn_87.DataPropertyName = "dateDocOut";
			dataGridViewCellStyle58.Format = "d";
			dataGridViewCellStyle58.NullValue = null;
			this.dataGridViewTextBoxColumn_87.DefaultCellStyle = dataGridViewCellStyle58;
			this.dataGridViewTextBoxColumn_87.HeaderText = "Дата";
			this.dataGridViewTextBoxColumn_87.Name = "dataGridViewTextBoxColumn51";
			this.dataGridViewTextBoxColumn_88.DataPropertyName = "Status";
			this.dataGridViewTextBoxColumn_88.HeaderText = "Статус";
			this.dataGridViewTextBoxColumn_88.Name = "dataGridViewTextBoxColumn52";
			this.dataGridViewTextBoxColumn_88.Visible = false;
			this.dataGridViewTextBoxColumn_89.DataPropertyName = "BodyDocOut";
			this.dataGridViewTextBoxColumn_89.HeaderText = "Содержание";
			this.dataGridViewTextBoxColumn_89.Name = "dataGridViewTextBoxColumn53";
			this.dataGridViewTextBoxColumn_90.DataPropertyName = "SendModeName";
			this.dataGridViewTextBoxColumn_90.HeaderText = "Способ отправки";
			this.dataGridViewTextBoxColumn_90.Name = "dataGridViewTextBoxColumn54";
			this.dataGridViewTextBoxColumn_90.Visible = false;
			this.dataGridViewTextBoxColumn_91.DataPropertyName = "number";
			this.dataGridViewTextBoxColumn_91.HeaderText = "Кол-во";
			this.dataGridViewTextBoxColumn_91.Name = "dataGridViewTextBoxColumn55";
			this.dataGridViewTextBoxColumn_92.DataPropertyName = "comment";
			this.dataGridViewTextBoxColumn_92.HeaderText = "Комментарий";
			this.dataGridViewTextBoxColumn_92.Name = "dataGridViewTextBoxColumn56";
			this.dataGridViewTextBoxColumn_92.Visible = false;
			this.dataGridViewTextBoxColumn_93.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_93.HeaderText = "id";
			this.dataGridViewTextBoxColumn_93.Name = "dataGridViewTextBoxColumn57";
			this.dataGridViewTextBoxColumn_93.Visible = false;
			this.dataGridViewTextBoxColumn_94.DataPropertyName = "idDoc";
			this.dataGridViewTextBoxColumn_94.HeaderText = "idDoc";
			this.dataGridViewTextBoxColumn_94.Name = "dataGridViewTextBoxColumn58";
			this.dataGridViewTextBoxColumn_94.Visible = false;
			this.dataGridViewTextBoxColumn_95.DataPropertyName = "idStatus";
			this.dataGridViewTextBoxColumn_95.HeaderText = "idStatus";
			this.dataGridViewTextBoxColumn_95.Name = "dataGridViewTextBoxColumn59";
			this.dataGridViewTextBoxColumn_95.Visible = false;
			this.dataGridViewTextBoxColumn_96.DataPropertyName = "statusName";
			this.dataGridViewTextBoxColumn_96.HeaderText = "Статус";
			this.dataGridViewTextBoxColumn_96.Name = "dataGridViewTextBoxColumn60";
			this.dataGridViewTextBoxColumn_96.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn_97.DataPropertyName = "DateChange";
			dataGridViewCellStyle59.Format = "d";
			dataGridViewCellStyle59.NullValue = null;
			this.dataGridViewTextBoxColumn_97.DefaultCellStyle = dataGridViewCellStyle59;
			this.dataGridViewTextBoxColumn_97.HeaderText = "Дата";
			this.dataGridViewTextBoxColumn_97.Name = "dataGridViewTextBoxColumn61";
			this.dataGridViewTextBoxColumn_97.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn_97.Width = 70;
			this.dataGridViewTextBoxColumn_98.DataPropertyName = "SendName";
			this.dataGridViewTextBoxColumn_98.HeaderText = "Способ отправки";
			this.dataGridViewTextBoxColumn_98.Name = "dataGridViewTextBoxColumn62";
			this.dataGridViewTextBoxColumn_99.DataPropertyName = "Comment";
			this.dataGridViewTextBoxColumn_99.HeaderText = "Комментарий";
			this.dataGridViewTextBoxColumn_99.Name = "dataGridViewTextBoxColumn63";
			this.dataGridViewTextBoxColumn_100.DataPropertyName = "typeDocName";
			this.dataGridViewTextBoxColumn_100.HeaderText = "Тип";
			this.dataGridViewTextBoxColumn_100.Name = "dataGridViewTextBoxColumn64";
			this.dataGridViewTextBoxColumn_100.Width = 150;
			this.dataGridViewTextBoxColumn_101.DataPropertyName = "numDoc";
			this.dataGridViewTextBoxColumn_101.HeaderText = "№ акта";
			this.dataGridViewTextBoxColumn_101.Name = "dataGridViewTextBoxColumn65";
			this.dataGridViewTextBoxColumn_102.DataPropertyName = "dateDoc";
			this.dataGridViewTextBoxColumn_102.HeaderText = "Дата";
			this.dataGridViewTextBoxColumn_102.Name = "dataGridViewTextBoxColumn66";
			this.dataGridViewTextBoxColumn_103.DataPropertyName = "Comment";
			this.dataGridViewTextBoxColumn_103.HeaderText = "Комментарий";
			this.dataGridViewTextBoxColumn_103.Name = "dataGridViewTextBoxColumn67";
			this.dataGridViewTextBoxColumn_104.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_104.HeaderText = "id";
			this.dataGridViewTextBoxColumn_104.Name = "dataGridViewTextBoxColumn68";
			this.dataGridViewTextBoxColumn_104.Visible = false;
			this.dataGridViewTextBoxColumn_105.DataPropertyName = "TypeDoc";
			this.dataGridViewTextBoxColumn_105.HeaderText = "TypeDoc";
			this.dataGridViewTextBoxColumn_105.Name = "dataGridViewTextBoxColumn69";
			this.dataGridViewTextBoxColumn_105.Visible = false;
			this.dataGridViewTextBoxColumn_106.DataPropertyName = "Body";
			this.dataGridViewTextBoxColumn_106.HeaderText = "Body";
			this.dataGridViewTextBoxColumn_106.Name = "dataGridViewTextBoxColumn70";
			this.dataGridViewTextBoxColumn_106.Visible = false;
			this.dataGridViewTextBoxColumn_107.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_107.HeaderText = "id";
			this.dataGridViewTextBoxColumn_107.Name = "dataGridViewTextBoxColumn71";
			this.dataGridViewTextBoxColumn_107.Visible = false;
			this.backgroundWorker_0.DoWork += this.backgroundWorker_0_DoWork;
			this.backgroundWorker_0.RunWorkerCompleted += this.backgroundWorker_0_RunWorkerCompleted;
			this.toolStripDropDownButton_1.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripDropDownButton_1.DropDownItems.AddRange(new ToolStripItem[]
			{
				this.toolStripMenuItem_6,
				this.toolStripSeparator_6,
				this.toolStripMenuItem_7
			});
			this.toolStripDropDownButton_1.Image = (Image)componentResourceManager.GetObject("toolBtnAddDocOut.Image");
			this.toolStripDropDownButton_1.ImageTransparentColor = Color.Magenta;
			this.toolStripDropDownButton_1.Name = "toolBtnAddDocOut";
			this.toolStripDropDownButton_1.Size = new Size(29, 20);
			this.toolStripDropDownButton_1.Text = "Новый документ";
			this.toolStripMenuItem_6.Name = "toolBtnAddDocOutMail";
			this.toolStripMenuItem_6.Size = new Size(177, 22);
			this.toolStripMenuItem_6.Text = "Письмо";
			this.toolStripMenuItem_6.Click += this.toolStripMenuItem_6_Click;
			this.toolStripSeparator_6.Name = "toolStripSeparator7";
			this.toolStripSeparator_6.Size = new Size(174, 6);
			this.toolStripMenuItem_7.Name = "toolBtnAddDocOutOther";
			this.toolStripMenuItem_7.Size = new Size(177, 22);
			this.toolStripMenuItem_7.Text = "Другие документы";
			this.toolStripMenuItem_7.Click += this.toolStripMenuItem_7_Click;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(964, 522);
			base.Controls.Add(this.splitContainer_0);
			base.Controls.Add(this.toolStrip_0);
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "FormJournalTU";
			this.Text = "Журнал технических условий";
			base.FormClosed += this.FormJournalTU_FormClosed;
			base.Load += this.FormJournalTU_Load;
			this.toolStrip_0.ResumeLayout(false);
			this.toolStrip_0.PerformLayout();
			((ISupportInitialize)this.FkSanDtyTi).EndInit();
			((ISupportInitialize)this.bindingSource_0).EndInit();
			((ISupportInitialize)this.class10_0).EndInit();
			this.splitContainer_0.Panel1.ResumeLayout(false);
			this.splitContainer_0.Panel1.PerformLayout();
			this.splitContainer_0.Panel2.ResumeLayout(false);
			this.splitContainer_0.ResumeLayout(false);
			this.toolStrip_1.ResumeLayout(false);
			this.toolStrip_1.PerformLayout();
			this.splitContainer_1.Panel1.ResumeLayout(false);
			this.splitContainer_1.Panel2.ResumeLayout(false);
			this.splitContainer_1.ResumeLayout(false);
			this.tabControl_0.ResumeLayout(false);
			this.tabPage_0.ResumeLayout(false);
			((ISupportInitialize)this.dataGridViewExcelFilter_0).EndInit();
			((ISupportInitialize)this.bindingSource_1).EndInit();
			this.tabPage_1.ResumeLayout(false);
			((ISupportInitialize)this.dataGridViewExcelFilter_1).EndInit();
			((ISupportInitialize)this.bindingSource_2).EndInit();
			this.tabPage_3.ResumeLayout(false);
			this.splitContainer_3.Panel1.ResumeLayout(false);
			this.splitContainer_3.Panel2.ResumeLayout(false);
			this.splitContainer_3.ResumeLayout(false);
			((ISupportInitialize)this.dataGridViewExcelFilter_4).EndInit();
			((ISupportInitialize)this.bindingSource_5).EndInit();
			((ISupportInitialize)this.dataGridViewExcelFilter_5).EndInit();
			((ISupportInitialize)this.bindingSource_6).EndInit();
			this.tabPage_2.ResumeLayout(false);
			this.splitContainer_2.Panel1.ResumeLayout(false);
			this.splitContainer_2.Panel1.PerformLayout();
			this.splitContainer_2.Panel2.ResumeLayout(false);
			this.splitContainer_2.Panel2.PerformLayout();
			this.splitContainer_2.ResumeLayout(false);
			((ISupportInitialize)this.dataGridViewExcelFilter_2).EndInit();
			((ISupportInitialize)this.bindingSource_3).EndInit();
			this.toolStrip_2.ResumeLayout(false);
			this.toolStrip_2.PerformLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_3).EndInit();
			((ISupportInitialize)this.bindingSource_4).EndInit();
			this.toolStrip_3.ResumeLayout(false);
			this.toolStrip_3.PerformLayout();
			this.tabPage_4.ResumeLayout(false);
			this.tabPage_4.PerformLayout();
			((ISupportInitialize)this.class10_1).EndInit();
			this.toolStrip_4.ResumeLayout(false);
			this.toolStrip_4.PerformLayout();
			this.pevkEfUdfJ.ResumeLayout(false);
			this.splitContainer_4.Panel1.ResumeLayout(false);
			this.splitContainer_4.Panel1.PerformLayout();
			this.splitContainer_4.Panel2.ResumeLayout(false);
			this.splitContainer_4.ResumeLayout(false);
			((ISupportInitialize)this.dataGridViewExcelFilter_7).EndInit();
			((ISupportInitialize)this.bindingSource_7).EndInit();
			this.toolStrip_5.ResumeLayout(false);
			this.toolStrip_5.PerformLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_6).EndInit();
			((ISupportInitialize)this.bindingSource_8).EndInit();
			((ISupportInitialize)this.dataSet_0).EndInit();
			((ISupportInitialize)this.dataTable_0).EndInit();
			((ISupportInitialize)this.dataTable_1).EndInit();
			this.tabPage_5.ResumeLayout(false);
			this.tabPage_5.PerformLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_8).EndInit();
			((ISupportInitialize)this.bindingSource_9).EndInit();
			this.toolStrip_6.ResumeLayout(false);
			this.toolStrip_6.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		[CompilerGenerated]
		private bool method_21(Class10.Class107 class107_0)
		{
			return class107_0.RowState == DataRowState.Unchanged && class107_0.id == (int)((DataRowView)this.bindingSource_9.Current)["id"];
		}

		internal static void oKx6lwQk2rkJKNgbTmY(Form form_0, bool bool_0)
		{
			form_0.Dispose(bool_0);
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

		private DataGridViewExcelFilter FkSanDtyTi;

		private BindingSource bindingSource_0;

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

		private DataGridViewExcelFilter dataGridViewExcelFilter_0;

		private BindingSource bindingSource_1;

		private DataGridViewImageColumnNotNull dataGridViewImageColumnNotNull_0;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

		private DataGridViewLinkColumn dataGridViewLinkColumn_0;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_3;

		private TabPage tabPage_1;

		private BindingSource bindingSource_2;

		private DataGridViewExcelFilter dataGridViewExcelFilter_1;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_4;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_5;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_6;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_7;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_8;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_9;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_10;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_11;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_12;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_13;

		private DataGridViewTextBoxColumn alragsoaPf;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_14;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_15;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_16;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_17;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_18;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_19;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_20;

		private ToolStripSeparator toolStripSeparator_2;

		private ToolStripButton toolStripButton_9;

		private TabPage tabPage_2;

		private SplitContainer splitContainer_2;

		private ToolStrip toolStrip_2;

		private ToolStripButton toolStripButton_10;

		private ToolStripButton toolStripButton_11;

		private BindingSource bindingSource_3;

		private DataGridViewExcelFilter dataGridViewExcelFilter_2;

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

		private DataGridViewTextBoxColumn ymuksnNoEU;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_31;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_32;

		private BindingSource bindingSource_4;

		private ToolStrip toolStrip_3;

		private ToolStripButton toolStripButton_12;

		private ToolStripButton toolStripButton_13;

		private ToolStripButton toolStripButton_14;

		private DataGridViewExcelFilter dataGridViewExcelFilter_3;

		private ToolStripButton toolStripButton_15;

		private TabPage tabPage_3;

		private SplitContainer splitContainer_3;

		private BindingSource bindingSource_5;

		private BindingSource bindingSource_6;

		private DataGridViewExcelFilter dataGridViewExcelFilter_4;

		private DataGridViewExcelFilter dataGridViewExcelFilter_5;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_33;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_34;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_35;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_36;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_37;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_38;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_39;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_40;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_41;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_42;

		private TabPage tabPage_4;

		private RichTextBox richTextBox_0;

		private System.Windows.Forms.Label label_2;

		private DateTimePicker dateTimePicker_2;

		private System.Windows.Forms.Label label_3;

		private System.Windows.Forms.TextBox textBox_0;

		private System.Windows.Forms.Label label_4;

		private ToolStrip toolStrip_4;

		private ToolStripButton toolStripButton_16;

		private ToolStripButton toolStripButton_17;

		private ToolStripButton toolStripButton_18;

		private Class10 class10_1;

		private ToolStripSeparator toolStripSeparator_3;

		private ToolStripButton QxUkSviJgI;

		private TabPage pevkEfUdfJ;

		private SplitContainer splitContainer_4;

		private DataGridViewExcelFilter dataGridViewExcelFilter_6;

		private DataGridViewExcelFilter dataGridViewExcelFilter_7;

		private ToolStrip toolStrip_5;

		private ToolStripButton toolStripButton_19;

		private ToolStripButton toolStripButton_20;

		private BindingSource bindingSource_7;

		private ToolStripSeparator toolStripSeparator_4;

		private ToolStripButton toolStripButton_21;

		private ToolStripDropDownButton toolStripDropDownButton_0;

		private ToolStripMenuItem toolStripMenuItem_0;

		private ToolStripMenuItem toolStripMenuItem_1;

		private ToolStripMenuItem toolStripMenuItem_2;

		private BindingSource bindingSource_8;

		private DataSet dataSet_0;

		private System.Data.DataTable dataTable_0;

		private DataColumn dataColumn_0;

		private DataColumn dataColumn_1;

		private DataGridViewImageColumnNotNull dataGridViewImageColumnNotNull_1;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_43;

		private DataGridViewLinkColumn dataGridViewLinkColumn_1;

		private System.Data.DataTable dataTable_1;

		private DataColumn dataColumn_2;

		private DataColumn dataColumn_3;

		private ToolStripMenuItem toolStripMenuItem_3;

		private ToolStripMenuItem toolStripMenuItem_4;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_0;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_1;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_2;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_3;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_4;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_5;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_6;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_44;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_7;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_8;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_9;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_10;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_45;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_11;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_46;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_12;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_13;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_14;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_47;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_48;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_15;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_16;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_49;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_50;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_51;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_52;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_53;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_54;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_55;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_56;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_57;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_58;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_59;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_60;

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

		private DataGridViewTextBoxColumn eedhdsdanG;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_83;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_84;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_85;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_86;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_87;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_88;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_89;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_90;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_91;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_92;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_93;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_94;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_95;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_96;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_97;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_98;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_99;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_100;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_101;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_102;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_103;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_104;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_105;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_106;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_107;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_108;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_109;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_110;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_111;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_112;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_113;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_114;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_115;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_116;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_117;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_118;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_119;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_120;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_121;

		private TabPage tabPage_5;

		private DataGridViewExcelFilter dataGridViewExcelFilter_8;

		private ToolStrip toolStrip_6;

		private ToolStripButton toolStripButton_22;

		private BindingSource bindingSource_9;

		private ToolStripSeparator toolStripSeparator_5;

		private ToolStripButton toolStripButton_23;

		private BackgroundWorker backgroundWorker_0;

		private ToolStripSplitButton toolStripSplitButton_0;

		private ToolStripMenuItem pcueoNrZpi;

		private ToolStripMenuItem toolStripMenuItem_5;

		private ToolStripButton toolStripButton_24;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_122;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_123;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_124;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_125;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_126;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_127;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_128;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_129;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_130;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_131;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_132;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_133;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_134;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_135;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_136;

		private ToolStripButton toolStripButton_25;

		private TreeView treeView_0;

		private System.Windows.Forms.Label label_5;

		private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn_0;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_137;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_17;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_18;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_19;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_138;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_139;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_20;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_140;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_141;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_21;

		private DataGridViewTextBoxColumn lHbekeicuS;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_22;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_23;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_142;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_24;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_25;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_26;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_27;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_143;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_28;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_144;

		private DataGridViewFilterTextBoxColumn waFeUdmntD;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_29;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_30;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_145;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_146;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_31;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_32;

		private ToolStripDropDownButton toolStripDropDownButton_1;

		private ToolStripMenuItem toolStripMenuItem_6;

		private ToolStripSeparator toolStripSeparator_6;

		private ToolStripMenuItem toolStripMenuItem_7;
	}
}
