using System;
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
using DataSql;
using Documents.Forms.TechnologicalConnection.Acts;
using Documents.Forms.TechnologicalConnection.TU;
using Documents.Properties;
using FormLbr;
using FormLbr.Classes;
using Microsoft.Office.Interop.Excel;

namespace Documents.Forms.TechnologicalConnection.ActTC
{
	public partial class FormJournalActs : FormBase
	{
		public FormJournalActs()
		{
			
			this.int_0 = -1;
			this.int_1 = -1;
			this.TypeDoc = 1240;
			
			this.InitializeComponent();
			this.method_4();
			this.CreateCaptionForm();
		}

		public FormJournalActs(int int_3 = -1, int typeAct = 1240)
		{
			
			this.int_0 = -1;
			this.int_1 = -1;
			this.TypeDoc = 1240;
			
			this.InitializeComponent();
			this.method_4();
			this.int_0 = int_3;
			this.TypeDoc = typeAct;
			this.CreateCaptionForm();
		}

		public FormJournalActs(List<int> checkedSubstation, int typeAct = 1240)
		{
			
			this.int_0 = -1;
			this.int_1 = -1;
			this.TypeDoc = 1240;
			
			this.InitializeComponent();
			this.method_4();
			this.list_0 = checkedSubstation;
			this.TypeDoc = typeAct;
			this.CreateCaptionForm();
		}

		private void CreateCaptionForm()
		{
			int typeDoc = this.TypeDoc;
			if (typeDoc == 1238)
			{
				this.Text = "Журнал актов осмотра электроустановок";
				return;
			}
			if (typeDoc != 1239)
			{
				return;
			}
			this.Text = "Журнал актов выполнения технических условий";
		}

		private void FormJournalActs_Load(object sender, EventArgs e)
		{
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
			this.method_1();
			if (num != -1)
			{
				this.dataGridViewExcelFilter_0.SearchGrid(this.dataGridViewFilterTextBoxColumn_20.Name, num.ToString(), false);
				if (this.dataGridViewExcelFilter_0.CurrentRow != null)
				{
					this.dataGridViewExcelFilter_0.FirstDisplayedScrollingRowIndex = this.dataGridViewExcelFilter_0.CurrentRow.Index;
				}
			}
		}

		private void FormJournalActs_FormClosed(object sender, FormClosedEventArgs e)
		{
			base.SaveFormConfig(null);
		}

		private void method_1()
		{
			int num = this.int_0;
			List<int> list = this.method_7(this.treeView_0.Nodes);
			string text = string.Format(" where DateDoc >= '{0}' and DateDoc <= '{1}' and typeDoc = {2} ", this.dateTimePicker_1.Value.ToString("yyyyMMdd"), this.dateTimePicker_0.Value.ToString("yyyyMMdd"), this.TypeDoc);
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
			base.SelectSqlData(this.class10_0, this.class10_0.vTC_Act, true, text);
			if (num > 0)
			{
				this.dataGridViewExcelFilter_0.SearchGrid(this.dataGridViewFilterTextBoxColumn_20.Name, num.ToString(), false);
			}
		}

		private void bbLoHuKujYv(object sender, DataGridViewRowPostPaintEventArgs e)
		{
			((DataGridView)sender).AutoResizeRow(e.RowIndex);
		}

		private void dataGridViewExcelFilter_0_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && this.PcUoHilawyb.Enabled && this.PcUoHilawyb.Visible)
			{
				this.PcUoHilawyb_Click(sender, e);
			}
		}

		private void dataGridViewExcelFilter_0_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			int rowIndex = e.RowIndex;
		}

		private void toolStripButton_0_Click(object sender, EventArgs e)
		{
			switch (this.TypeDoc)
			{
			case 1238:
			{
				FormActElectricalInspection formActElectricalInspection = new FormActElectricalInspection();
				formActElectricalInspection.SqlSettings = this.SqlSettings;
				formActElectricalInspection.MdiParent = base.MdiParent;
				formActElectricalInspection.FormClosed += this.method_2;
				formActElectricalInspection.Show();
				return;
			}
			case 1239:
			{
				FormActPerformingTU formActPerformingTU = new FormActPerformingTU();
				formActPerformingTU.SqlSettings = this.SqlSettings;
				formActPerformingTU.MdiParent = base.MdiParent;
				formActPerformingTU.FormClosed += this.method_2;
				formActPerformingTU.Show();
				return;
			}
			case 1240:
			{
				FormTCAddEdit formTCAddEdit = new FormTCAddEdit();
				formTCAddEdit.SqlSettings = this.SqlSettings;
				formTCAddEdit.MdiParent = base.MdiParent;
				formTCAddEdit.FormClosed += this.method_2;
				formTCAddEdit.Show();
				return;
			}
			default:
				return;
			}
		}

		private void method_2(object sender, FormClosedEventArgs e)
		{
			switch (this.TypeDoc)
			{
			case 1238:
				this.int_0 = ((FormActElectricalInspection)sender).method_0();
				break;
			case 1239:
				this.int_0 = ((FormActPerformingTU)sender).method_0();
				break;
			case 1240:
				this.int_0 = ((FormTCAddEdit)sender).method_0();
				break;
			}
			this.method_1();
		}

		private void PcUoHilawyb_Click(object sender, EventArgs e)
		{
			if (this.int_0 != -1)
			{
				switch (this.TypeDoc)
				{
				case 1238:
				{
					FormActElectricalInspection formActElectricalInspection = new FormActElectricalInspection(this.int_0, -1, 1238);
					formActElectricalInspection.SqlSettings = this.SqlSettings;
					formActElectricalInspection.MdiParent = base.MdiParent;
					formActElectricalInspection.FormClosed += this.method_2;
					formActElectricalInspection.Show();
					return;
				}
				case 1239:
				{
					FormActPerformingTU formActPerformingTU = new FormActPerformingTU(this.int_0, -1, 1239);
					formActPerformingTU.SqlSettings = this.SqlSettings;
					formActPerformingTU.MdiParent = base.MdiParent;
					formActPerformingTU.FormClosed += this.method_2;
					formActPerformingTU.Show();
					break;
				}
				case 1240:
				{
					FormTCAddEdit formTCAddEdit = new FormTCAddEdit(this.int_0, -1);
					formTCAddEdit.SqlSettings = this.SqlSettings;
					formTCAddEdit.MdiParent = base.MdiParent;
					formTCAddEdit.FormClosed += this.method_2;
					formTCAddEdit.Show();
					return;
				}
				default:
					return;
				}
			}
		}

		private void toolStripButton_1_Click(object sender, EventArgs e)
		{
			if (this.int_0 > 0 && this.dataGridViewExcelFilter_0.CurrentRow != null && MessageBox.Show("Вы действительно хотите удалить текущую запись?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes && base.DeleteSqlDataById(this.class10_0.tTC_Doc, this.int_0))
			{
				this.dataGridViewExcelFilter_0.Rows.Remove(this.dataGridViewExcelFilter_0.CurrentRow);
				MessageBox.Show("Запись успешно удалена");
			}
		}

		private void toolStripButton_7_Click(object sender, EventArgs e)
		{
			this.method_1();
		}

		private void laSoWlyuudL_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_0.CurrentRow != null && this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewFilterTextBoxColumn_26.Name].Value != null && this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewFilterTextBoxColumn_26.Name].Value != DBNull.Value)
			{
				new FormTechConnectionRequest(Convert.ToInt32(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewFilterTextBoxColumn_26.Name].Value))
				{
					MdiParent = base.MdiParent,
					SqlSettings = this.SqlSettings
				}.Show();
			}
		}

		private void toolStripButton_9_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_0.CurrentRow != null && this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewFilterTextBoxColumn_24.Name].Value != null && this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewFilterTextBoxColumn_24.Name].Value != DBNull.Value)
			{
				new FormJournalTU(Convert.ToInt32(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewFilterTextBoxColumn_24.Name].Value))
				{
					MdiParent = base.MdiParent,
					SqlSettings = this.SqlSettings
				}.Show();
			}
		}

		private void toolStripButton_2_Click(object sender, EventArgs e)
		{
			this.dataGridViewExcelFilter_0.SearchGrid(DataGridViewExcelFilter.TypeFind.Begin, this.toolStripTextBox_0.Text);
		}

		private void toolStripButton_3_Click(object sender, EventArgs e)
		{
			this.dataGridViewExcelFilter_0.SearchGrid(DataGridViewExcelFilter.TypeFind.Prev, this.toolStripTextBox_0.Text);
		}

		private void toolStripButton_4_Click(object sender, EventArgs e)
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

		private void toolStripButton_8_Click(object sender, EventArgs e)
		{
			this.method_3(this.dataGridViewExcelFilter_0);
		}

		private void method_3(DataGridView dataGridView_0)
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
				Color white = Color.White;
				for (int k = 1; k < dataGridView_0.Columns.Count; k++)
				{
					if (dataGridView_0.Columns[k].Visible)
					{
						worksheet.Cells[j + 2, num] = dataGridView_0.Rows[j].Cells[k].Value.ToString();
						((Range)worksheet.Cells[j + 2, num]).WrapText = true;
						((Range)worksheet.Cells[j + 2, num]).Interior.Color = ColorTranslator.ToOle(white);
						num++;
					}
				}
			}
			application.Visible = true;
		}

		private void toolStripButton_10_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_0.CurrentRow != null)
			{
				new FormReportActElectricalInspection(this.int_0)
				{
					SqlSettings = this.SqlSettings,
					MdiParent = base.MdiParent
				}.Show();
			}
		}

		private void bindingSource_0_CurrentChanged(object sender, EventArgs e)
		{
			if (this.bsTC_Act.Current != null)
			{
				this.int_0 = Convert.ToInt32(((DataRowView)this.bsTC_Act.Current).Row["id"]);
				if (((DataRowView)this.bsTC_Act.Current).Row["idRequest"] != DBNull.Value)
				{
					this.int_1 = Convert.ToInt32(((DataRowView)this.bsTC_Act.Current).Row["idRequest"]);
				}
				else
				{
					this.int_1 = -1;
				}
				this.method_5();
			}
			else
			{
				this.int_0 = -1;
				this.int_1 = -1;
				this.class10_0.tTC_DocFile.Clear();
				this.class10_0.vTC_Doc.Clear();
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

		private void method_4()
		{
			this.dateTimePicker_1.Value = new DateTime(DateTime.Now.Year, 1, 1);
			this.dateTimePicker_0.Value = new DateTime(DateTime.Now.Year, 12, 31);
		}

		private void toolStripButton_5_Click(object sender, EventArgs e)
		{
			this.method_1();
		}

		private void toolStripButton_6_Click(object sender, EventArgs e)
		{
			this.method_4();
			this.method_1();
		}

		private void method_5()
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
			if (((DataGridView)sender).RowCount > 0 && this.dataGridViewExcelFilter_1[this.dataGridViewLinkColumn_0.Name, e.RowIndex].Value != null)
			{
				if (e.ColumnIndex == this.dataGridViewExcelFilter_1.Columns[this.dataGridViewImageColumnNotNull_0.Name].Index)
				{
					if (!string.IsNullOrEmpty(Path.GetFileName(this.dataGridViewExcelFilter_1[this.dataGridViewLinkColumn_0.Name, e.RowIndex].Value.ToString())))
					{
						e.Value = Path.GetFileName(this.dataGridViewExcelFilter_1[this.dataGridViewLinkColumn_0.Name, e.RowIndex].Value.ToString());
					}
					else
					{
						e.Value = this.dataGridViewExcelFilter_1[this.dataGridViewLinkColumn_0.Name, e.RowIndex].Value.ToString();
					}
				}
				if (e.ColumnIndex == this.dataGridViewExcelFilter_1.Columns[this.dataGridViewImageColumnNotNull_0.Name].Index)
				{
					Icon icon = FormLbr.Classes.FileInfo.IconOfFile(this.dataGridViewExcelFilter_1[this.dataGridViewLinkColumn_0.Name, e.RowIndex].Value.ToString());
					if (icon != null)
					{
						e.Value = icon.ToBitmap();
					}
				}
			}
		}

		private void dataGridViewExcelFilter_1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (this.dataGridViewExcelFilter_1.CurrentRow == null)
			{
				return;
			}
			int num = Convert.ToInt32(this.dataGridViewExcelFilter_1.CurrentRow.Cells[this.dataGridViewTextBoxColumn_0.Name].Value);
			if (e.ColumnIndex == this.dataGridViewExcelFilter_1.Columns[this.dataGridViewLinkColumn_0.Name].Index)
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
			if (e.RowIndex >= 0 && Convert.ToInt32(this.dataGridViewExcelFilter_2[this.dataGridViewTextBoxColumn_7.Name, e.RowIndex].Value) == 1113)
			{
				e.CellStyle.Font = new System.Drawing.Font(e.CellStyle.Font, FontStyle.Bold);
				e.CellStyle.BackColor = Color.LightGray;
			}
		}

		private void dataGridViewExcelFilter_2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
		{
			this.dataGridViewExcelFilter_2.AutoResizeRow(e.RowIndex);
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

		private void InitializeComponent()
		{
			this.icontainer_0 = new Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FormJournalActs));
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
			this.toolStrip_0 = new ToolStrip();
			this.toolStripButton_0 = new ToolStripButton();
			this.PcUoHilawyb = new ToolStripButton();
			this.toolStripButton_1 = new ToolStripButton();
			this.toolStripSeparator_2 = new ToolStripSeparator();
			this.toolStripButton_7 = new ToolStripButton();
			this.toolStripSeparator_0 = new ToolStripSeparator();
			this.toolStripButton_9 = new ToolStripButton();
			this.laSoWlyuudL = new ToolStripButton();
			this.toolStripSeparator_1 = new ToolStripSeparator();
			this.toolStripButton_2 = new ToolStripButton();
			this.toolStripTextBox_0 = new ToolStripTextBox();
			this.toolStripButton_3 = new ToolStripButton();
			this.toolStripButton_4 = new ToolStripButton();
			this.toolStripSeparator_3 = new ToolStripSeparator();
			this.toolStripButton_8 = new ToolStripButton();
			this.toolStripButton_10 = new ToolStripButton();
			this.dataGridViewExcelFilter_0 = new DataGridViewExcelFilter();
			this.bsTC_Act = new BindingSource(this.icontainer_0);
			this.class10_0 = new Class10();
			this.splitContainer_0 = new SplitContainer();
			this.treeView_0 = new TreeView();
			this.label_2 = new System.Windows.Forms.Label();
			this.dateTimePicker_0 = new DateTimePicker();
			this.label_0 = new System.Windows.Forms.Label();
			this.dateTimePicker_1 = new DateTimePicker();
			this.label_1 = new System.Windows.Forms.Label();
			this.toolStrip_1 = new ToolStrip();
			this.toolStripButton_5 = new ToolStripButton();
			this.toolStripButton_6 = new ToolStripButton();
			this.splitContainer_1 = new SplitContainer();
			this.tabControl_0 = new TabControl();
			this.tabPage_0 = new TabPage();
			this.dataGridViewExcelFilter_1 = new DataGridViewExcelFilter();
			this.dataGridViewLinkColumn_0 = new DataGridViewLinkColumn();
			this.dataGridViewImageColumnNotNull_0 = new DataGridViewImageColumnNotNull();
			this.dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
			this.WuFoWxtYnFH = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
			this.bsTC_DocFile = new BindingSource(this.icontainer_0);
			this.tabPage_1 = new TabPage();
			this.dataGridViewExcelFilter_2 = new DataGridViewExcelFilter();
			this.dataGridViewTextBoxColumn_3 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_12 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_4 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_5 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_6 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_7 = new DataGridViewTextBoxColumn();
			this.jhJoWkUrbs9 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_8 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_9 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_10 = new DataGridViewTextBoxColumn();
			this.vejoWbrnip3 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_11 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_13 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_14 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_15 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_16 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_17 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_18 = new DataGridViewTextBoxColumn();
			this.bindingSource_2 = new BindingSource(this.icontainer_0);
			this.dataSet_0 = new DataSet();
			this.dataTable_0 = new System.Data.DataTable();
			this.dataColumn_0 = new DataColumn();
			this.dataColumn_1 = new DataColumn();
			this.dataTable_1 = new System.Data.DataTable();
			this.dataColumn_2 = new DataColumn();
			this.dataColumn_3 = new DataColumn();
			this.dataGridViewFilterTextBoxColumn_0 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_1 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_2 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_3 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_4 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_5 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_6 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewTextBoxColumn_19 = new DataGridViewTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_7 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_8 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_9 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_10 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewTextBoxColumn_20 = new DataGridViewTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_11 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewTextBoxColumn_21 = new DataGridViewTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_12 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_13 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_14 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewTextBoxColumn_22 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_23 = new DataGridViewTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_15 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_16 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewTextBoxColumn_24 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_25 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_26 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_27 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_28 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_29 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_30 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_31 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_32 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_33 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_34 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_35 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_36 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_37 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_38 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_39 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_40 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_41 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_42 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_43 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_44 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_45 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_46 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_47 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_48 = new DataGridViewTextBoxColumn();
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
			this.dataGridViewTextBoxColumn_83 = new DataGridViewTextBoxColumn();
			this.class10_1 = new Class10();
			this.dataGridViewFilterTextBoxColumn_17 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewTextBoxColumn_84 = new DataGridViewTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_18 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_19 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_20 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_21 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_22 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_23 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_24 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_25 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_26 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_27 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_28 = new DataGridViewFilterTextBoxColumn();
			this.KjRoPkSkqu1 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_29 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_30 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_31 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_32 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_33 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_34 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_35 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_36 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_37 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewTextBoxColumn_85 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_86 = new DataGridViewTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_38 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_39 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_40 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_41 = new DataGridViewFilterTextBoxColumn();
			this.toolStrip_0.SuspendLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_0).BeginInit();
			((ISupportInitialize)this.bsTC_Act).BeginInit();
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
			((ISupportInitialize)this.dataGridViewExcelFilter_1).BeginInit();
			((ISupportInitialize)this.bsTC_DocFile).BeginInit();
			this.tabPage_1.SuspendLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_2).BeginInit();
			((ISupportInitialize)this.bindingSource_2).BeginInit();
			((ISupportInitialize)this.dataSet_0).BeginInit();
			((ISupportInitialize)this.dataTable_0).BeginInit();
			((ISupportInitialize)this.dataTable_1).BeginInit();
			((ISupportInitialize)this.class10_1).BeginInit();
			base.SuspendLayout();
			this.toolStrip_0.GripStyle = ToolStripGripStyle.Hidden;
			this.toolStrip_0.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripButton_0,
				this.PcUoHilawyb,
				this.toolStripButton_1,
				this.toolStripSeparator_2,
				this.toolStripButton_7,
				this.toolStripSeparator_0,
				this.toolStripButton_9,
				this.laSoWlyuudL,
				this.toolStripSeparator_1,
				this.toolStripButton_2,
				this.toolStripTextBox_0,
				this.toolStripButton_3,
				this.toolStripButton_4,
				this.toolStripSeparator_3,
				this.toolStripButton_8,
				this.toolStripButton_10
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
			this.toolStripButton_0.Text = "Добавить акт";
			this.toolStripButton_0.Click += this.toolStripButton_0_Click;
			this.PcUoHilawyb.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.PcUoHilawyb.Image = (Image)componentResourceManager.GetObject("toolBtnEditTU.Image");
			this.PcUoHilawyb.ImageTransparentColor = Color.Magenta;
			this.PcUoHilawyb.Name = "toolBtnEditTU";
			this.PcUoHilawyb.Size = new Size(23, 22);
			this.PcUoHilawyb.Text = "Редактировать акт";
			this.PcUoHilawyb.Click += this.PcUoHilawyb_Click;
			this.toolStripButton_1.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_1.Image = (Image)componentResourceManager.GetObject("toolBtnDelTU.Image");
			this.toolStripButton_1.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_1.Name = "toolBtnDelTU";
			this.toolStripButton_1.Size = new Size(23, 22);
			this.toolStripButton_1.Text = "Удалить акт";
			this.toolStripButton_1.Click += this.toolStripButton_1_Click;
			this.toolStripSeparator_2.Name = "toolStripSeparator3";
			this.toolStripSeparator_2.Size = new Size(6, 25);
			this.toolStripButton_7.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_7.Image = (Image)componentResourceManager.GetObject("toolBtnRefresh.Image");
			this.toolStripButton_7.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_7.Name = "toolBtnRefresh";
			this.toolStripButton_7.Size = new Size(23, 22);
			this.toolStripButton_7.Text = "Обновить";
			this.toolStripButton_7.Click += this.toolStripButton_7_Click;
			this.toolStripSeparator_0.Name = "toolStripSeparator1";
			this.toolStripSeparator_0.Size = new Size(6, 25);
			this.toolStripButton_9.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_9.Image = Resources._1381484495_Terms_rev;
			this.toolStripButton_9.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_9.Name = "toolBtnShowTU";
			this.toolStripButton_9.Size = new Size(23, 22);
			this.toolStripButton_9.Text = "Открыть тех условие";
			this.toolStripButton_9.Click += this.toolStripButton_9_Click;
			this.laSoWlyuudL.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.laSoWlyuudL.Image = (Image)componentResourceManager.GetObject("toolBtnShowRequest.Image");
			this.laSoWlyuudL.ImageTransparentColor = Color.Magenta;
			this.laSoWlyuudL.Name = "toolBtnShowRequest";
			this.laSoWlyuudL.Size = new Size(23, 22);
			this.laSoWlyuudL.Text = "Открыть заявку";
			this.laSoWlyuudL.Click += this.laSoWlyuudL_Click;
			this.toolStripSeparator_1.Name = "toolStripSeparator2";
			this.toolStripSeparator_1.Size = new Size(6, 25);
			this.toolStripButton_2.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_2.Image = (Image)componentResourceManager.GetObject("toolBtnFind.Image");
			this.toolStripButton_2.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_2.Name = "toolBtnFind";
			this.toolStripButton_2.Size = new Size(23, 22);
			this.toolStripButton_2.Text = "Поиск";
			this.toolStripButton_2.Click += this.toolStripButton_2_Click;
			this.toolStripTextBox_0.Name = "toolTxtFind";
			this.toolStripTextBox_0.Size = new Size(100, 25);
			this.toolStripTextBox_0.ToolTipText = "Текст поиска";
			this.toolStripTextBox_0.KeyDown += this.toolStripTextBox_0_KeyDown;
			this.toolStripButton_3.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_3.Image = (Image)componentResourceManager.GetObject("toolBtnFindPrev.Image");
			this.toolStripButton_3.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_3.Name = "toolBtnFindPrev";
			this.toolStripButton_3.Size = new Size(23, 22);
			this.toolStripButton_3.Text = "Поиск назад";
			this.toolStripButton_3.Click += this.toolStripButton_3_Click;
			this.toolStripButton_4.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_4.Image = (Image)componentResourceManager.GetObject("toolBtnFindNext.Image");
			this.toolStripButton_4.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_4.Name = "toolBtnFindNext";
			this.toolStripButton_4.Size = new Size(23, 22);
			this.toolStripButton_4.Text = "Поиск вперед";
			this.toolStripButton_4.Click += this.toolStripButton_4_Click;
			this.toolStripSeparator_3.Name = "toolStripSeparator4";
			this.toolStripSeparator_3.Size = new Size(6, 25);
			this.toolStripButton_8.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_8.Image = (Image)componentResourceManager.GetObject("toolBtnExportExcel.Image");
			this.toolStripButton_8.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_8.Name = "toolBtnExportExcel";
			this.toolStripButton_8.Size = new Size(23, 22);
			this.toolStripButton_8.Text = "Экспорт в Excel";
			this.toolStripButton_8.Click += this.toolStripButton_8_Click;
			this.toolStripButton_10.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_10.Image = Resources.printer;
			this.toolStripButton_10.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_10.Name = "toolBtnPrint";
			this.toolStripButton_10.Size = new Size(23, 22);
			this.toolStripButton_10.Text = "Печать";
			this.toolStripButton_10.Click += this.toolStripButton_10_Click;
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
				this.dataGridViewFilterTextBoxColumn_17,
				this.dataGridViewTextBoxColumn_84,
				this.dataGridViewFilterTextBoxColumn_18,
				this.dataGridViewFilterTextBoxColumn_19,
				this.dataGridViewFilterTextBoxColumn_20,
				this.dataGridViewFilterTextBoxColumn_21,
				this.dataGridViewFilterTextBoxColumn_22,
				this.dataGridViewFilterTextBoxColumn_23,
				this.dataGridViewFilterTextBoxColumn_24,
				this.dataGridViewFilterTextBoxColumn_25,
				this.dataGridViewFilterTextBoxColumn_26,
				this.dataGridViewFilterTextBoxColumn_27,
				this.dataGridViewFilterTextBoxColumn_28,
				this.KjRoPkSkqu1,
				this.dataGridViewFilterTextBoxColumn_29,
				this.dataGridViewFilterTextBoxColumn_30,
				this.dataGridViewFilterTextBoxColumn_31,
				this.dataGridViewFilterTextBoxColumn_32,
				this.dataGridViewFilterTextBoxColumn_33,
				this.dataGridViewFilterTextBoxColumn_34,
				this.dataGridViewFilterTextBoxColumn_35,
				this.dataGridViewFilterTextBoxColumn_36,
				this.dataGridViewFilterTextBoxColumn_37,
				this.dataGridViewTextBoxColumn_85,
				this.dataGridViewTextBoxColumn_86,
				this.dataGridViewFilterTextBoxColumn_38,
				this.dataGridViewFilterTextBoxColumn_39,
				this.dataGridViewFilterTextBoxColumn_40,
				this.dataGridViewFilterTextBoxColumn_41
			});
			this.dataGridViewExcelFilter_0.DataSource = this.bsTC_Act;
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
			this.dataGridViewExcelFilter_0.Name = "dgvTС";
			this.dataGridViewExcelFilter_0.ReadOnly = true;
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = SystemColors.Control;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
			this.dataGridViewExcelFilter_0.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.dataGridViewExcelFilter_0.RowHeadersWidth = 21;
			this.dataGridViewExcelFilter_0.Size = new Size(789, 294);
			this.dataGridViewExcelFilter_0.TabIndex = 1;
			this.dataGridViewExcelFilter_0.VirtualMode = true;
			this.dataGridViewExcelFilter_0.CellDoubleClick += this.dataGridViewExcelFilter_0_CellDoubleClick;
			this.dataGridViewExcelFilter_0.CellFormatting += this.dataGridViewExcelFilter_0_CellFormatting;
			this.dataGridViewExcelFilter_0.RowPostPaint += this.bbLoHuKujYv;
			this.bsTC_Act.DataMember = "vTC_Act";
			this.bsTC_Act.DataSource = this.class10_0;
			this.bsTC_Act.CurrentChanged += this.bindingSource_0_CurrentChanged;
			this.class10_0.DataSetName = "DataSetTechConnection";
			this.class10_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
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
			this.treeView_0.Location = new System.Drawing.Point(0, 116);
			this.treeView_0.Name = "treeViewSubstation";
			this.treeView_0.Size = new Size(171, 378);
			this.treeView_0.TabIndex = 12;
			this.treeView_0.AfterCheck += this.treeView_0_AfterCheck;
			this.label_2.AutoSize = true;
			this.label_2.Location = new System.Drawing.Point(12, 103);
			this.label_2.Name = "label6";
			this.label_2.Size = new Size(68, 13);
			this.label_2.TabIndex = 11;
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
				this.toolStripButton_5,
				this.toolStripButton_6
			});
			this.toolStrip_1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip_1.Name = "toolStripFilter";
			this.toolStrip_1.Size = new Size(171, 25);
			this.toolStrip_1.TabIndex = 5;
			this.toolStrip_1.Text = "toolStrip1";
			this.toolStripButton_5.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_5.Image = (Image)componentResourceManager.GetObject("toolBtnApplyFilter.Image");
			this.toolStripButton_5.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_5.Name = "toolBtnApplyFilter";
			this.toolStripButton_5.Size = new Size(23, 22);
			this.toolStripButton_5.Text = "Применить фильтр";
			this.toolStripButton_5.Click += this.toolStripButton_5_Click;
			this.toolStripButton_6.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_6.Image = (Image)componentResourceManager.GetObject("toolBtnClearFilter.Image");
			this.toolStripButton_6.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_6.Name = "toolBtnClearFilter";
			this.toolStripButton_6.Size = new Size(23, 22);
			this.toolStripButton_6.Text = "Очистить фильтр";
			this.toolStripButton_6.Click += this.toolStripButton_6_Click;
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
			this.tabControl_0.Controls.Add(this.tabPage_0);
			this.tabControl_0.Controls.Add(this.tabPage_1);
			this.tabControl_0.Dock = DockStyle.Fill;
			this.tabControl_0.Location = new System.Drawing.Point(0, 0);
			this.tabControl_0.Name = "tabControl";
			this.tabControl_0.SelectedIndex = 0;
			this.tabControl_0.Size = new Size(789, 199);
			this.tabControl_0.TabIndex = 0;
			this.tabPage_0.Controls.Add(this.dataGridViewExcelFilter_1);
			this.tabPage_0.Location = new System.Drawing.Point(4, 22);
			this.tabPage_0.Name = "tabPageFiles";
			this.tabPage_0.Padding = new Padding(3);
			this.tabPage_0.Size = new Size(781, 173);
			this.tabPage_0.TabIndex = 0;
			this.tabPage_0.Text = "Файлы";
			this.tabPage_0.UseVisualStyleBackColor = true;
			this.dataGridViewExcelFilter_1.AllowUserToAddRows = false;
			this.dataGridViewExcelFilter_1.AllowUserToDeleteRows = false;
			this.dataGridViewExcelFilter_1.AllowUserToResizeColumns = false;
			this.dataGridViewExcelFilter_1.AllowUserToResizeRows = false;
			this.dataGridViewExcelFilter_1.AutoGenerateColumns = false;
			dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = SystemColors.Control;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
			this.dataGridViewExcelFilter_1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
			this.dataGridViewExcelFilter_1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewExcelFilter_1.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewLinkColumn_0,
				this.dataGridViewImageColumnNotNull_0,
				this.dataGridViewTextBoxColumn_0,
				this.dataGridViewTextBoxColumn_1,
				this.WuFoWxtYnFH,
				this.dataGridViewTextBoxColumn_2
			});
			this.dataGridViewExcelFilter_1.DataSource = this.bsTC_DocFile;
			dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle5.BackColor = SystemColors.Window;
			dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
			this.dataGridViewExcelFilter_1.DefaultCellStyle = dataGridViewCellStyle5;
			this.dataGridViewExcelFilter_1.Dock = DockStyle.Fill;
			this.dataGridViewExcelFilter_1.EditMode = DataGridViewEditMode.EditProgrammatically;
			this.dataGridViewExcelFilter_1.Location = new System.Drawing.Point(3, 3);
			this.dataGridViewExcelFilter_1.Name = "dgvFile";
			this.dataGridViewExcelFilter_1.ReadOnly = true;
			dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle6.BackColor = SystemColors.Control;
			dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
			this.dataGridViewExcelFilter_1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
			this.dataGridViewExcelFilter_1.RowHeadersVisible = false;
			this.dataGridViewExcelFilter_1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewExcelFilter_1.Size = new Size(775, 167);
			this.dataGridViewExcelFilter_1.TabIndex = 7;
			this.dataGridViewExcelFilter_1.VirtualMode = true;
			this.dataGridViewExcelFilter_1.CellContentClick += this.dataGridViewExcelFilter_1_CellContentClick;
			this.dataGridViewExcelFilter_1.CellValueNeeded += this.dataGridViewExcelFilter_1_CellValueNeeded;
			this.dataGridViewLinkColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewLinkColumn_0.DataPropertyName = "FileName";
			this.dataGridViewLinkColumn_0.HeaderText = "Файл";
			this.dataGridViewLinkColumn_0.Name = "fileNameDgvColumn";
			this.dataGridViewLinkColumn_0.ReadOnly = true;
			this.dataGridViewLinkColumn_0.Resizable = DataGridViewTriState.True;
			this.dataGridViewLinkColumn_0.SortMode = DataGridViewColumnSortMode.Automatic;
			dataGridViewCellStyle7.NullValue = null;
			this.dataGridViewImageColumnNotNull_0.DefaultCellStyle = dataGridViewCellStyle7;
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
			this.WuFoWxtYnFH.DataPropertyName = "dateChange";
			this.WuFoWxtYnFH.HeaderText = "dateChange";
			this.WuFoWxtYnFH.Name = "dateChangeDataGridViewTextBoxColumn";
			this.WuFoWxtYnFH.ReadOnly = true;
			this.WuFoWxtYnFH.Visible = false;
			this.dataGridViewTextBoxColumn_2.DataPropertyName = "idTemplate";
			this.dataGridViewTextBoxColumn_2.HeaderText = "idTemplate";
			this.dataGridViewTextBoxColumn_2.Name = "idTemplateDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_2.ReadOnly = true;
			this.dataGridViewTextBoxColumn_2.Visible = false;
			this.bsTC_DocFile.DataMember = "tTC_DocFile";
			this.bsTC_DocFile.DataSource = this.class10_0;
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
			dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle8.BackColor = SystemColors.Control;
			dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle8.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
			this.dataGridViewExcelFilter_2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
			this.dataGridViewExcelFilter_2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewExcelFilter_2.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewTextBoxColumn_3,
				this.dataGridViewTextBoxColumn_12,
				this.dataGridViewTextBoxColumn_4,
				this.dataGridViewTextBoxColumn_5,
				this.dataGridViewTextBoxColumn_6,
				this.dataGridViewTextBoxColumn_7,
				this.jhJoWkUrbs9,
				this.dataGridViewTextBoxColumn_8,
				this.dataGridViewTextBoxColumn_9,
				this.dataGridViewTextBoxColumn_10,
				this.vejoWbrnip3,
				this.dataGridViewTextBoxColumn_11,
				this.dataGridViewTextBoxColumn_13,
				this.dataGridViewTextBoxColumn_14,
				this.dataGridViewTextBoxColumn_15,
				this.dataGridViewTextBoxColumn_16,
				this.dataGridViewTextBoxColumn_17,
				this.dataGridViewTextBoxColumn_18
			});
			this.dataGridViewExcelFilter_2.DataSource = this.bindingSource_2;
			dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle9.BackColor = SystemColors.Window;
			dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle9.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle9.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle9.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle9.WrapMode = DataGridViewTriState.False;
			this.dataGridViewExcelFilter_2.DefaultCellStyle = dataGridViewCellStyle9;
			this.dataGridViewExcelFilter_2.Dock = DockStyle.Fill;
			this.dataGridViewExcelFilter_2.Location = new System.Drawing.Point(3, 3);
			this.dataGridViewExcelFilter_2.MultiSelect = false;
			this.dataGridViewExcelFilter_2.Name = "dgvRequestHistory";
			this.dataGridViewExcelFilter_2.ReadOnly = true;
			dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle10.BackColor = SystemColors.Control;
			dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle10.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle10.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle10.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle10.WrapMode = DataGridViewTriState.True;
			this.dataGridViewExcelFilter_2.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
			this.dataGridViewExcelFilter_2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewExcelFilter_2.Size = new Size(775, 167);
			this.dataGridViewExcelFilter_2.TabIndex = 4;
			this.dataGridViewExcelFilter_2.VirtualMode = true;
			this.dataGridViewExcelFilter_2.CellFormatting += this.dataGridViewExcelFilter_2_CellFormatting;
			this.dataGridViewExcelFilter_2.RowPostPaint += this.dataGridViewExcelFilter_2_RowPostPaint;
			this.dataGridViewTextBoxColumn_3.DataPropertyName = "numDateIn";
			dataGridViewCellStyle11.WrapMode = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_3.DefaultCellStyle = dataGridViewCellStyle11;
			this.dataGridViewTextBoxColumn_3.HeaderText = "№, дата вход.";
			this.dataGridViewTextBoxColumn_3.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_3.ReadOnly = true;
			this.dataGridViewTextBoxColumn_3.Visible = false;
			this.dataGridViewTextBoxColumn_3.Width = 80;
			this.dataGridViewTextBoxColumn_12.DataPropertyName = "PowerAdd";
			this.dataGridViewTextBoxColumn_12.HeaderText = "Доп мощность";
			this.dataGridViewTextBoxColumn_12.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn_12.ReadOnly = true;
			this.dataGridViewTextBoxColumn_12.Visible = false;
			this.dataGridViewTextBoxColumn_12.Width = 70;
			this.dataGridViewTextBoxColumn_4.DataPropertyName = "numDoc";
			this.dataGridViewTextBoxColumn_4.HeaderText = "numDoc";
			this.dataGridViewTextBoxColumn_4.Name = "numDocDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_4.ReadOnly = true;
			this.dataGridViewTextBoxColumn_4.Visible = false;
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
			this.dataGridViewTextBoxColumn_7.DataPropertyName = "TypeDoc";
			this.dataGridViewTextBoxColumn_7.HeaderText = "TypeDoc";
			this.dataGridViewTextBoxColumn_7.Name = "typeDocRequestHistoryDgvColumn";
			this.dataGridViewTextBoxColumn_7.ReadOnly = true;
			this.dataGridViewTextBoxColumn_7.Visible = false;
			this.jhJoWkUrbs9.DataPropertyName = "numIn";
			this.jhJoWkUrbs9.HeaderText = "numIn";
			this.jhJoWkUrbs9.Name = "numInDataGridViewTextBoxColumn1";
			this.jhJoWkUrbs9.ReadOnly = true;
			this.jhJoWkUrbs9.Visible = false;
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
			this.vejoWbrnip3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.vejoWbrnip3.DataPropertyName = "body";
			dataGridViewCellStyle12.WrapMode = DataGridViewTriState.True;
			this.vejoWbrnip3.DefaultCellStyle = dataGridViewCellStyle12;
			this.vejoWbrnip3.HeaderText = "Тело письма";
			this.vejoWbrnip3.Name = "bodyDataGridViewTextBoxColumn1";
			this.vejoWbrnip3.ReadOnly = true;
			this.dataGridViewTextBoxColumn_11.DataPropertyName = "PowerCurrent";
			this.dataGridViewTextBoxColumn_11.HeaderText = "Текущая мощность";
			this.dataGridViewTextBoxColumn_11.Name = "powerCurrentDgvColumn";
			this.dataGridViewTextBoxColumn_11.ReadOnly = true;
			this.dataGridViewTextBoxColumn_11.Width = 70;
			this.dataGridViewTextBoxColumn_13.DataPropertyName = "Power";
			this.dataGridViewTextBoxColumn_13.HeaderText = "Суммарная мощность";
			this.dataGridViewTextBoxColumn_13.Name = "powerDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_13.ReadOnly = true;
			this.dataGridViewTextBoxColumn_13.Width = 70;
			this.dataGridViewTextBoxColumn_14.DataPropertyName = "VoltageName";
			this.dataGridViewTextBoxColumn_14.HeaderText = "Напряжение";
			this.dataGridViewTextBoxColumn_14.Name = "voltageNameDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_14.ReadOnly = true;
			this.dataGridViewTextBoxColumn_14.Width = 70;
			this.dataGridViewTextBoxColumn_15.DataPropertyName = "Comment";
			this.dataGridViewTextBoxColumn_15.HeaderText = "Комментарий";
			this.dataGridViewTextBoxColumn_15.Name = "commentDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_15.ReadOnly = true;
			this.dataGridViewTextBoxColumn_15.Width = 70;
			this.dataGridViewTextBoxColumn_16.DataPropertyName = "VoltageLevel";
			this.dataGridViewTextBoxColumn_16.HeaderText = "VoltageLevel";
			this.dataGridViewTextBoxColumn_16.Name = "voltageLevelDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_16.ReadOnly = true;
			this.dataGridViewTextBoxColumn_16.Visible = false;
			this.dataGridViewTextBoxColumn_17.DataPropertyName = "VoltageValue";
			this.dataGridViewTextBoxColumn_17.HeaderText = "VoltageValue";
			this.dataGridViewTextBoxColumn_17.Name = "voltageValueDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_17.ReadOnly = true;
			this.dataGridViewTextBoxColumn_17.Visible = false;
			this.dataGridViewTextBoxColumn_18.DataPropertyName = "IdParent";
			this.dataGridViewTextBoxColumn_18.HeaderText = "IdParent";
			this.dataGridViewTextBoxColumn_18.Name = "idParentDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_18.ReadOnly = true;
			this.dataGridViewTextBoxColumn_18.Visible = false;
			this.bindingSource_2.DataMember = "vTC_RequestHistory";
			this.bindingSource_2.DataSource = this.class10_0;
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
			this.dataGridViewFilterTextBoxColumn_0.DataPropertyName = "NumDateIn";
			dataGridViewCellStyle13.WrapMode = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_0.DefaultCellStyle = dataGridViewCellStyle13;
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
			dataGridViewCellStyle14.WrapMode = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_3.DefaultCellStyle = dataGridViewCellStyle14;
			this.dataGridViewFilterTextBoxColumn_3.HeaderText = "Содержание";
			this.dataGridViewFilterTextBoxColumn_3.Name = "dataGridViewFilterTextBoxColumn4";
			this.dataGridViewFilterTextBoxColumn_3.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_4.DataPropertyName = "nameAbn";
			dataGridViewCellStyle15.WrapMode = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_4.DefaultCellStyle = dataGridViewCellStyle15;
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
			this.dataGridViewTextBoxColumn_19.DataPropertyName = "addressFull";
			this.dataGridViewTextBoxColumn_19.HeaderText = "addressFull";
			this.dataGridViewTextBoxColumn_19.Name = "dataGridViewTextBoxColumn7";
			this.dataGridViewTextBoxColumn_19.Visible = false;
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
			this.dataGridViewTextBoxColumn_20.DataPropertyName = "Category";
			this.dataGridViewTextBoxColumn_20.HeaderText = "Category";
			this.dataGridViewTextBoxColumn_20.Name = "dataGridViewTextBoxColumn8";
			this.dataGridViewTextBoxColumn_20.Visible = false;
			this.dataGridViewFilterTextBoxColumn_11.DataPropertyName = "CategoryName";
			this.dataGridViewFilterTextBoxColumn_11.HeaderText = "Категор. элек-ния";
			this.dataGridViewFilterTextBoxColumn_11.Name = "dataGridViewFilterTextBoxColumn12";
			this.dataGridViewFilterTextBoxColumn_11.Resizable = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_21.DataPropertyName = "idSchmObj";
			this.dataGridViewTextBoxColumn_21.HeaderText = "idSchmObj";
			this.dataGridViewTextBoxColumn_21.Name = "dataGridViewTextBoxColumn9";
			this.dataGridViewTextBoxColumn_21.Visible = false;
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
			this.dataGridViewTextBoxColumn_22.DataPropertyName = "NameDocOut";
			dataGridViewCellStyle16.WrapMode = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_22.DefaultCellStyle = dataGridViewCellStyle16;
			this.dataGridViewTextBoxColumn_22.HeaderText = "Выданные документы";
			this.dataGridViewTextBoxColumn_22.Name = "dataGridViewTextBoxColumn10";
			this.dataGridViewTextBoxColumn_23.DataPropertyName = "Performer";
			this.dataGridViewTextBoxColumn_23.HeaderText = "Performer";
			this.dataGridViewTextBoxColumn_23.Name = "dataGridViewTextBoxColumn11";
			this.dataGridViewTextBoxColumn_23.Visible = false;
			this.dataGridViewFilterTextBoxColumn_15.DataPropertyName = "SchmTP";
			dataGridViewCellStyle17.WrapMode = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_15.DefaultCellStyle = dataGridViewCellStyle17;
			this.dataGridViewFilterTextBoxColumn_15.HeaderText = "ТП";
			this.dataGridViewFilterTextBoxColumn_15.Name = "dataGridViewFilterTextBoxColumn16";
			this.dataGridViewFilterTextBoxColumn_16.DataPropertyName = "SchmCP";
			dataGridViewCellStyle18.WrapMode = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_16.DefaultCellStyle = dataGridViewCellStyle18;
			this.dataGridViewFilterTextBoxColumn_16.HeaderText = "ЦП";
			this.dataGridViewFilterTextBoxColumn_16.Name = "dataGridViewFilterTextBoxColumn17";
			this.dataGridViewFilterTextBoxColumn_16.Width = 150;
			this.dataGridViewTextBoxColumn_24.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_24.HeaderText = "id";
			this.dataGridViewTextBoxColumn_24.Name = "dataGridViewTextBoxColumn12";
			this.dataGridViewTextBoxColumn_24.Visible = false;
			this.dataGridViewTextBoxColumn_25.DataPropertyName = "idDoc";
			this.dataGridViewTextBoxColumn_25.HeaderText = "idDoc";
			this.dataGridViewTextBoxColumn_25.Name = "dataGridViewTextBoxColumn13";
			this.dataGridViewTextBoxColumn_25.Visible = false;
			this.dataGridViewTextBoxColumn_26.DataPropertyName = "dateChange";
			this.dataGridViewTextBoxColumn_26.HeaderText = "dateChange";
			this.dataGridViewTextBoxColumn_26.Name = "dataGridViewTextBoxColumn14";
			this.dataGridViewTextBoxColumn_26.Visible = false;
			this.dataGridViewTextBoxColumn_27.DataPropertyName = "idTemplate";
			this.dataGridViewTextBoxColumn_27.HeaderText = "idTemplate";
			this.dataGridViewTextBoxColumn_27.Name = "dataGridViewTextBoxColumn15";
			this.dataGridViewTextBoxColumn_27.Visible = false;
			this.dataGridViewTextBoxColumn_28.DataPropertyName = "numDateIn";
			dataGridViewCellStyle19.WrapMode = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_28.DefaultCellStyle = dataGridViewCellStyle19;
			this.dataGridViewTextBoxColumn_28.HeaderText = "№, дата вход.";
			this.dataGridViewTextBoxColumn_28.Name = "dataGridViewTextBoxColumn16";
			this.dataGridViewTextBoxColumn_28.Width = 80;
			this.dataGridViewTextBoxColumn_29.DataPropertyName = "numDoc";
			this.dataGridViewTextBoxColumn_29.HeaderText = "numDoc";
			this.dataGridViewTextBoxColumn_29.Name = "dataGridViewTextBoxColumn17";
			this.dataGridViewTextBoxColumn_29.Visible = false;
			this.dataGridViewTextBoxColumn_30.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_30.HeaderText = "id";
			this.dataGridViewTextBoxColumn_30.Name = "dataGridViewTextBoxColumn18";
			this.dataGridViewTextBoxColumn_30.Visible = false;
			this.dataGridViewTextBoxColumn_31.DataPropertyName = "dateDoc";
			this.dataGridViewTextBoxColumn_31.HeaderText = "Дата получения";
			this.dataGridViewTextBoxColumn_31.Name = "dataGridViewTextBoxColumn19";
			this.dataGridViewTextBoxColumn_31.Width = 80;
			this.dataGridViewTextBoxColumn_32.DataPropertyName = "TypeDoc";
			this.dataGridViewTextBoxColumn_32.HeaderText = "TypeDoc";
			this.dataGridViewTextBoxColumn_32.Name = "dataGridViewTextBoxColumn20";
			this.dataGridViewTextBoxColumn_32.Visible = false;
			this.dataGridViewTextBoxColumn_33.DataPropertyName = "numIn";
			this.dataGridViewTextBoxColumn_33.HeaderText = "numIn";
			this.dataGridViewTextBoxColumn_33.Name = "dataGridViewTextBoxColumn21";
			this.dataGridViewTextBoxColumn_33.Visible = false;
			this.dataGridViewTextBoxColumn_34.DataPropertyName = "dateIn";
			this.dataGridViewTextBoxColumn_34.HeaderText = "dateIn";
			this.dataGridViewTextBoxColumn_34.Name = "dataGridViewTextBoxColumn22";
			this.dataGridViewTextBoxColumn_34.Visible = false;
			this.dataGridViewTextBoxColumn_35.DataPropertyName = "idAbn";
			this.dataGridViewTextBoxColumn_35.HeaderText = "idAbn";
			this.dataGridViewTextBoxColumn_35.Name = "dataGridViewTextBoxColumn23";
			this.dataGridViewTextBoxColumn_35.Visible = false;
			this.dataGridViewTextBoxColumn_36.DataPropertyName = "idAbnObj";
			this.dataGridViewTextBoxColumn_36.HeaderText = "idAbnObj";
			this.dataGridViewTextBoxColumn_36.Name = "dataGridViewTextBoxColumn24";
			this.dataGridViewTextBoxColumn_36.Visible = false;
			this.dataGridViewTextBoxColumn_37.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_37.DataPropertyName = "body";
			dataGridViewCellStyle20.WrapMode = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_37.DefaultCellStyle = dataGridViewCellStyle20;
			this.dataGridViewTextBoxColumn_37.HeaderText = "Тело письма";
			this.dataGridViewTextBoxColumn_37.Name = "dataGridViewTextBoxColumn25";
			this.dataGridViewTextBoxColumn_38.DataPropertyName = "PowerCurrent";
			this.dataGridViewTextBoxColumn_38.HeaderText = "Текущая мощность";
			this.dataGridViewTextBoxColumn_38.Name = "dataGridViewTextBoxColumn26";
			this.dataGridViewTextBoxColumn_38.Width = 70;
			this.dataGridViewTextBoxColumn_39.DataPropertyName = "PowerAdd";
			this.dataGridViewTextBoxColumn_39.HeaderText = "Доп мощность";
			this.dataGridViewTextBoxColumn_39.Name = "dataGridViewTextBoxColumn27";
			this.dataGridViewTextBoxColumn_39.Width = 70;
			this.dataGridViewTextBoxColumn_40.DataPropertyName = "Power";
			this.dataGridViewTextBoxColumn_40.HeaderText = "Суммарная мощность";
			this.dataGridViewTextBoxColumn_40.Name = "dataGridViewTextBoxColumn28";
			this.dataGridViewTextBoxColumn_40.Width = 70;
			this.dataGridViewTextBoxColumn_41.DataPropertyName = "VoltageName";
			this.dataGridViewTextBoxColumn_41.HeaderText = "Напряжение";
			this.dataGridViewTextBoxColumn_41.Name = "dataGridViewTextBoxColumn29";
			this.dataGridViewTextBoxColumn_41.Width = 70;
			this.dataGridViewTextBoxColumn_42.DataPropertyName = "Comment";
			this.dataGridViewTextBoxColumn_42.HeaderText = "Комментарий";
			this.dataGridViewTextBoxColumn_42.Name = "dataGridViewTextBoxColumn30";
			this.dataGridViewTextBoxColumn_42.Width = 70;
			this.dataGridViewTextBoxColumn_43.DataPropertyName = "VoltageLevel";
			this.dataGridViewTextBoxColumn_43.HeaderText = "VoltageLevel";
			this.dataGridViewTextBoxColumn_43.Name = "dataGridViewTextBoxColumn31";
			this.dataGridViewTextBoxColumn_43.Visible = false;
			this.dataGridViewTextBoxColumn_44.DataPropertyName = "VoltageValue";
			this.dataGridViewTextBoxColumn_44.HeaderText = "VoltageValue";
			this.dataGridViewTextBoxColumn_44.Name = "dataGridViewTextBoxColumn32";
			this.dataGridViewTextBoxColumn_44.Visible = false;
			this.dataGridViewTextBoxColumn_45.DataPropertyName = "IdParent";
			this.dataGridViewTextBoxColumn_45.HeaderText = "IdParent";
			this.dataGridViewTextBoxColumn_45.Name = "dataGridViewTextBoxColumn33";
			this.dataGridViewTextBoxColumn_45.Visible = false;
			this.dataGridViewTextBoxColumn_46.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_46.DataPropertyName = "Work";
			dataGridViewCellStyle21.WrapMode = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_46.DefaultCellStyle = dataGridViewCellStyle21;
			this.dataGridViewTextBoxColumn_46.HeaderText = "Работы сетевой организации";
			this.dataGridViewTextBoxColumn_46.Name = "dataGridViewTextBoxColumn34";
			this.dataGridViewTextBoxColumn_46.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn_47.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_47.HeaderText = "id";
			this.dataGridViewTextBoxColumn_47.Name = "dataGridViewTextBoxColumn35";
			this.dataGridViewTextBoxColumn_47.Visible = false;
			this.dataGridViewTextBoxColumn_48.DataPropertyName = "idTU";
			this.dataGridViewTextBoxColumn_48.HeaderText = "idTU";
			this.dataGridViewTextBoxColumn_48.Name = "dataGridViewTextBoxColumn36";
			this.dataGridViewTextBoxColumn_48.Visible = false;
			this.dataGridViewTextBoxColumn_49.DataPropertyName = "num";
			this.dataGridViewTextBoxColumn_49.HeaderText = "num";
			this.dataGridViewTextBoxColumn_49.Name = "dataGridViewTextBoxColumn37";
			this.dataGridViewTextBoxColumn_49.Visible = false;
			this.dataGridViewTextBoxColumn_50.DataPropertyName = "TypeWork";
			this.dataGridViewTextBoxColumn_50.HeaderText = "TypeWork";
			this.dataGridViewTextBoxColumn_50.Name = "dataGridViewTextBoxColumn38";
			this.dataGridViewTextBoxColumn_50.Visible = false;
			this.dataGridViewTextBoxColumn_51.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_51.DataPropertyName = "Work";
			dataGridViewCellStyle22.WrapMode = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_51.DefaultCellStyle = dataGridViewCellStyle22;
			this.dataGridViewTextBoxColumn_51.HeaderText = "Работы заказчика";
			this.dataGridViewTextBoxColumn_51.Name = "dataGridViewTextBoxColumn39";
			this.dataGridViewTextBoxColumn_51.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn_52.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_52.HeaderText = "id";
			this.dataGridViewTextBoxColumn_52.Name = "dataGridViewTextBoxColumn40";
			this.dataGridViewTextBoxColumn_52.Visible = false;
			this.dataGridViewTextBoxColumn_53.DataPropertyName = "idTU";
			this.dataGridViewTextBoxColumn_53.HeaderText = "idTU";
			this.dataGridViewTextBoxColumn_53.Name = "dataGridViewTextBoxColumn41";
			this.dataGridViewTextBoxColumn_53.Visible = false;
			this.dataGridViewTextBoxColumn_54.DataPropertyName = "num";
			this.dataGridViewTextBoxColumn_54.HeaderText = "num";
			this.dataGridViewTextBoxColumn_54.Name = "dataGridViewTextBoxColumn42";
			this.dataGridViewTextBoxColumn_54.Visible = false;
			this.dataGridViewTextBoxColumn_55.DataPropertyName = "TypeWork";
			this.dataGridViewTextBoxColumn_55.HeaderText = "TypeWork";
			this.dataGridViewTextBoxColumn_55.Name = "dataGridViewTextBoxColumn43";
			this.dataGridViewTextBoxColumn_55.Visible = false;
			this.dataGridViewTextBoxColumn_56.DataPropertyName = "TypeDocNameOut";
			this.dataGridViewTextBoxColumn_56.HeaderText = "Документ";
			this.dataGridViewTextBoxColumn_56.Name = "dataGridViewTextBoxColumn44";
			this.dataGridViewTextBoxColumn_57.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_57.HeaderText = "id";
			this.dataGridViewTextBoxColumn_57.Name = "dataGridViewTextBoxColumn45";
			this.dataGridViewTextBoxColumn_57.Visible = false;
			this.dataGridViewTextBoxColumn_58.DataPropertyName = "numDateDocOut";
			this.dataGridViewTextBoxColumn_58.HeaderText = "numDateDocOut";
			this.dataGridViewTextBoxColumn_58.Name = "dataGridViewTextBoxColumn46";
			this.dataGridViewTextBoxColumn_58.Visible = false;
			this.dataGridViewTextBoxColumn_59.DataPropertyName = "idDoc";
			this.dataGridViewTextBoxColumn_59.HeaderText = "idDoc";
			this.dataGridViewTextBoxColumn_59.Name = "dataGridViewTextBoxColumn47";
			this.dataGridViewTextBoxColumn_59.Visible = false;
			this.dataGridViewTextBoxColumn_60.DataPropertyName = "numDocOut";
			this.dataGridViewTextBoxColumn_60.HeaderText = "№";
			this.dataGridViewTextBoxColumn_60.Name = "dataGridViewTextBoxColumn48";
			this.dataGridViewTextBoxColumn_61.DataPropertyName = "TypeDocOut";
			this.dataGridViewTextBoxColumn_61.HeaderText = "TypeDocOut";
			this.dataGridViewTextBoxColumn_61.Name = "dataGridViewTextBoxColumn49";
			this.dataGridViewTextBoxColumn_61.Visible = false;
			this.dataGridViewTextBoxColumn_62.DataPropertyName = "idDocOut";
			this.dataGridViewTextBoxColumn_62.HeaderText = "idDocOut";
			this.dataGridViewTextBoxColumn_62.Name = "dataGridViewTextBoxColumn50";
			this.dataGridViewTextBoxColumn_62.Visible = false;
			this.dataGridViewTextBoxColumn_63.DataPropertyName = "dateDocOut";
			dataGridViewCellStyle23.Format = "d";
			dataGridViewCellStyle23.NullValue = null;
			this.dataGridViewTextBoxColumn_63.DefaultCellStyle = dataGridViewCellStyle23;
			this.dataGridViewTextBoxColumn_63.HeaderText = "Дата";
			this.dataGridViewTextBoxColumn_63.Name = "dataGridViewTextBoxColumn51";
			this.dataGridViewTextBoxColumn_64.DataPropertyName = "Status";
			this.dataGridViewTextBoxColumn_64.HeaderText = "Статус";
			this.dataGridViewTextBoxColumn_64.Name = "dataGridViewTextBoxColumn52";
			this.dataGridViewTextBoxColumn_64.Visible = false;
			this.dataGridViewTextBoxColumn_65.DataPropertyName = "BodyDocOut";
			this.dataGridViewTextBoxColumn_65.HeaderText = "Содержание";
			this.dataGridViewTextBoxColumn_65.Name = "dataGridViewTextBoxColumn53";
			this.dataGridViewTextBoxColumn_66.DataPropertyName = "SendModeName";
			this.dataGridViewTextBoxColumn_66.HeaderText = "Способ отправки";
			this.dataGridViewTextBoxColumn_66.Name = "dataGridViewTextBoxColumn54";
			this.dataGridViewTextBoxColumn_66.Visible = false;
			this.dataGridViewTextBoxColumn_67.DataPropertyName = "number";
			this.dataGridViewTextBoxColumn_67.HeaderText = "Кол-во";
			this.dataGridViewTextBoxColumn_67.Name = "dataGridViewTextBoxColumn55";
			this.dataGridViewTextBoxColumn_68.DataPropertyName = "comment";
			this.dataGridViewTextBoxColumn_68.HeaderText = "Комментарий";
			this.dataGridViewTextBoxColumn_68.Name = "dataGridViewTextBoxColumn56";
			this.dataGridViewTextBoxColumn_68.Visible = false;
			this.dataGridViewTextBoxColumn_69.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_69.HeaderText = "id";
			this.dataGridViewTextBoxColumn_69.Name = "dataGridViewTextBoxColumn57";
			this.dataGridViewTextBoxColumn_69.Visible = false;
			this.dataGridViewTextBoxColumn_70.DataPropertyName = "idDoc";
			this.dataGridViewTextBoxColumn_70.HeaderText = "idDoc";
			this.dataGridViewTextBoxColumn_70.Name = "dataGridViewTextBoxColumn58";
			this.dataGridViewTextBoxColumn_70.Visible = false;
			this.dataGridViewTextBoxColumn_71.DataPropertyName = "idStatus";
			this.dataGridViewTextBoxColumn_71.HeaderText = "idStatus";
			this.dataGridViewTextBoxColumn_71.Name = "dataGridViewTextBoxColumn59";
			this.dataGridViewTextBoxColumn_71.Visible = false;
			this.dataGridViewTextBoxColumn_72.DataPropertyName = "statusName";
			this.dataGridViewTextBoxColumn_72.HeaderText = "Статус";
			this.dataGridViewTextBoxColumn_72.Name = "dataGridViewTextBoxColumn60";
			this.dataGridViewTextBoxColumn_72.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn_73.DataPropertyName = "DateChange";
			dataGridViewCellStyle24.Format = "d";
			dataGridViewCellStyle24.NullValue = null;
			this.dataGridViewTextBoxColumn_73.DefaultCellStyle = dataGridViewCellStyle24;
			this.dataGridViewTextBoxColumn_73.HeaderText = "Дата";
			this.dataGridViewTextBoxColumn_73.Name = "dataGridViewTextBoxColumn61";
			this.dataGridViewTextBoxColumn_73.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn_73.Width = 70;
			this.dataGridViewTextBoxColumn_74.DataPropertyName = "SendName";
			this.dataGridViewTextBoxColumn_74.HeaderText = "Способ отправки";
			this.dataGridViewTextBoxColumn_74.Name = "dataGridViewTextBoxColumn62";
			this.dataGridViewTextBoxColumn_75.DataPropertyName = "Comment";
			this.dataGridViewTextBoxColumn_75.HeaderText = "Комментарий";
			this.dataGridViewTextBoxColumn_75.Name = "dataGridViewTextBoxColumn63";
			this.dataGridViewTextBoxColumn_76.DataPropertyName = "typeDocName";
			this.dataGridViewTextBoxColumn_76.HeaderText = "Тип";
			this.dataGridViewTextBoxColumn_76.Name = "dataGridViewTextBoxColumn64";
			this.dataGridViewTextBoxColumn_76.Width = 150;
			this.dataGridViewTextBoxColumn_77.DataPropertyName = "numDoc";
			this.dataGridViewTextBoxColumn_77.HeaderText = "№ акта";
			this.dataGridViewTextBoxColumn_77.Name = "dataGridViewTextBoxColumn65";
			this.dataGridViewTextBoxColumn_78.DataPropertyName = "dateDoc";
			this.dataGridViewTextBoxColumn_78.HeaderText = "Дата";
			this.dataGridViewTextBoxColumn_78.Name = "dataGridViewTextBoxColumn66";
			this.dataGridViewTextBoxColumn_79.DataPropertyName = "Comment";
			this.dataGridViewTextBoxColumn_79.HeaderText = "Комментарий";
			this.dataGridViewTextBoxColumn_79.Name = "dataGridViewTextBoxColumn67";
			this.dataGridViewTextBoxColumn_80.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_80.HeaderText = "id";
			this.dataGridViewTextBoxColumn_80.Name = "dataGridViewTextBoxColumn68";
			this.dataGridViewTextBoxColumn_80.Visible = false;
			this.dataGridViewTextBoxColumn_81.DataPropertyName = "TypeDoc";
			this.dataGridViewTextBoxColumn_81.HeaderText = "TypeDoc";
			this.dataGridViewTextBoxColumn_81.Name = "dataGridViewTextBoxColumn69";
			this.dataGridViewTextBoxColumn_81.Visible = false;
			this.dataGridViewTextBoxColumn_82.DataPropertyName = "Body";
			this.dataGridViewTextBoxColumn_82.HeaderText = "Body";
			this.dataGridViewTextBoxColumn_82.Name = "dataGridViewTextBoxColumn70";
			this.dataGridViewTextBoxColumn_82.Visible = false;
			this.dataGridViewTextBoxColumn_83.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_83.HeaderText = "id";
			this.dataGridViewTextBoxColumn_83.Name = "dataGridViewTextBoxColumn71";
			this.dataGridViewTextBoxColumn_83.Visible = false;
			this.class10_1.DataSetName = "DataSetTechConnection";
			this.class10_1.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
			this.dataGridViewFilterTextBoxColumn_17.DataPropertyName = "numDoc";
			this.dataGridViewFilterTextBoxColumn_17.HeaderText = "№ ТП";
			this.dataGridViewFilterTextBoxColumn_17.Name = "numDocDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_17.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_17.Resizable = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_84.DataPropertyName = "dateDoc";
			this.dataGridViewTextBoxColumn_84.HeaderText = "Дата ТП";
			this.dataGridViewTextBoxColumn_84.Name = "dateDocDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_84.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_18.DataPropertyName = "nameAbn";
			dataGridViewCellStyle25.WrapMode = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_18.DefaultCellStyle = dataGridViewCellStyle25;
			this.dataGridViewFilterTextBoxColumn_18.HeaderText = "Потребитель";
			this.dataGridViewFilterTextBoxColumn_18.Name = "nameAbnDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_18.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_18.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_19.DataPropertyName = "nameObj";
			dataGridViewCellStyle26.WrapMode = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_19.DefaultCellStyle = dataGridViewCellStyle26;
			this.dataGridViewFilterTextBoxColumn_19.HeaderText = "Объект";
			this.dataGridViewFilterTextBoxColumn_19.Name = "nameObjDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_19.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_19.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_20.DataPropertyName = "id";
			this.dataGridViewFilterTextBoxColumn_20.HeaderText = "id";
			this.dataGridViewFilterTextBoxColumn_20.Name = "idDgvColumn";
			this.dataGridViewFilterTextBoxColumn_20.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_20.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_20.Visible = false;
			this.dataGridViewFilterTextBoxColumn_21.DataPropertyName = "numIn";
			this.dataGridViewFilterTextBoxColumn_21.HeaderText = "№ вх.";
			this.dataGridViewFilterTextBoxColumn_21.Name = "numInDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_21.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_21.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_21.Visible = false;
			this.dataGridViewFilterTextBoxColumn_22.DataPropertyName = "DateIn";
			this.dataGridViewFilterTextBoxColumn_22.HeaderText = "Дата вх.";
			this.dataGridViewFilterTextBoxColumn_22.Name = "dateInDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_22.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_22.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_22.Visible = false;
			this.dataGridViewFilterTextBoxColumn_23.DataPropertyName = "numDateIn";
			this.dataGridViewFilterTextBoxColumn_23.HeaderText = "№ и дата вх.";
			this.dataGridViewFilterTextBoxColumn_23.Name = "numDateInDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_23.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_23.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_23.Visible = false;
			this.dataGridViewFilterTextBoxColumn_24.DataPropertyName = "idTU";
			this.dataGridViewFilterTextBoxColumn_24.HeaderText = "idTU";
			this.dataGridViewFilterTextBoxColumn_24.Name = "idTUDgvColumn";
			this.dataGridViewFilterTextBoxColumn_24.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_24.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_24.Visible = false;
			this.dataGridViewFilterTextBoxColumn_25.DataPropertyName = "body";
			this.dataGridViewFilterTextBoxColumn_25.HeaderText = "body";
			this.dataGridViewFilterTextBoxColumn_25.Name = "bodyDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_25.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_25.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_25.Visible = false;
			this.dataGridViewFilterTextBoxColumn_26.DataPropertyName = "idRequest";
			this.dataGridViewFilterTextBoxColumn_26.HeaderText = "idRequest";
			this.dataGridViewFilterTextBoxColumn_26.Name = "idRequestDgvColumn";
			this.dataGridViewFilterTextBoxColumn_26.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_26.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_26.Visible = false;
			this.dataGridViewFilterTextBoxColumn_27.DataPropertyName = "idAbn";
			this.dataGridViewFilterTextBoxColumn_27.HeaderText = "idAbn";
			this.dataGridViewFilterTextBoxColumn_27.Name = "idAbnDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_27.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_27.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_27.Visible = false;
			this.dataGridViewFilterTextBoxColumn_28.DataPropertyName = "idAbnObj";
			this.dataGridViewFilterTextBoxColumn_28.HeaderText = "idAbnObj";
			this.dataGridViewFilterTextBoxColumn_28.Name = "idAbnObjDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_28.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_28.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_28.Visible = false;
			this.KjRoPkSkqu1.DataPropertyName = "address";
			dataGridViewCellStyle27.WrapMode = DataGridViewTriState.True;
			this.KjRoPkSkqu1.DefaultCellStyle = dataGridViewCellStyle27;
			this.KjRoPkSkqu1.HeaderText = "Адрес";
			this.KjRoPkSkqu1.Name = "addressDataGridViewTextBoxColumn";
			this.KjRoPkSkqu1.ReadOnly = true;
			this.KjRoPkSkqu1.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_29.DataPropertyName = "numDateTU";
			this.dataGridViewFilterTextBoxColumn_29.HeaderText = "№ и дата ТУ";
			this.dataGridViewFilterTextBoxColumn_29.Name = "numDateTUDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_29.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_29.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_30.DataPropertyName = "addressFull";
			this.dataGridViewFilterTextBoxColumn_30.HeaderText = "Адрес объекта";
			this.dataGridViewFilterTextBoxColumn_30.Name = "addressFullDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_30.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_30.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_30.Visible = false;
			this.dataGridViewFilterTextBoxColumn_31.DataPropertyName = "PowerCurrent";
			this.dataGridViewFilterTextBoxColumn_31.HeaderText = "Существующая мощность";
			this.dataGridViewFilterTextBoxColumn_31.Name = "powerCurrentDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_31.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_31.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_32.DataPropertyName = "PowerAdd";
			this.dataGridViewFilterTextBoxColumn_32.HeaderText = "Дополнительная мощность";
			this.dataGridViewFilterTextBoxColumn_32.Name = "powerAddDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_32.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_32.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_33.DataPropertyName = "PowerSum";
			this.dataGridViewFilterTextBoxColumn_33.HeaderText = "Максимальная мощность";
			this.dataGridViewFilterTextBoxColumn_33.Name = "powerSumDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_33.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_33.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_34.DataPropertyName = "Category";
			this.dataGridViewFilterTextBoxColumn_34.HeaderText = "Category";
			this.dataGridViewFilterTextBoxColumn_34.Name = "categoryDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_34.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_34.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_34.Visible = false;
			this.dataGridViewFilterTextBoxColumn_35.DataPropertyName = "CategoryName";
			this.dataGridViewFilterTextBoxColumn_35.HeaderText = "Категория";
			this.dataGridViewFilterTextBoxColumn_35.Name = "categoryNameDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_35.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_35.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_36.DataPropertyName = "VoltageLevel";
			this.dataGridViewFilterTextBoxColumn_36.HeaderText = "Ур-нь напряжения";
			this.dataGridViewFilterTextBoxColumn_36.Name = "voltageLevelDataGridViewTextBoxColumn1";
			this.dataGridViewFilterTextBoxColumn_36.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_36.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_37.DataPropertyName = "PerformerFIO";
			this.dataGridViewFilterTextBoxColumn_37.HeaderText = "Исполнитель";
			this.dataGridViewFilterTextBoxColumn_37.Name = "performerFIODataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_37.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_37.Resizable = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_85.DataPropertyName = "SchmTP";
			dataGridViewCellStyle28.WrapMode = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_85.DefaultCellStyle = dataGridViewCellStyle28;
			this.dataGridViewTextBoxColumn_85.HeaderText = "Точки прис-ия";
			this.dataGridViewTextBoxColumn_85.Name = "schmTPDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_85.ReadOnly = true;
			this.dataGridViewTextBoxColumn_86.DataPropertyName = "SchmCP";
			dataGridViewCellStyle29.WrapMode = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_86.DefaultCellStyle = dataGridViewCellStyle29;
			this.dataGridViewTextBoxColumn_86.HeaderText = "ЦП";
			this.dataGridViewTextBoxColumn_86.Name = "schmCPDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_86.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_38.DataPropertyName = "numContractor";
			this.dataGridViewFilterTextBoxColumn_38.HeaderText = "№ договора ТП";
			this.dataGridViewFilterTextBoxColumn_38.Name = "numContractorDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_38.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_38.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_39.DataPropertyName = "dateContractor";
			this.dataGridViewFilterTextBoxColumn_39.HeaderText = "Дата договора ТП";
			this.dataGridViewFilterTextBoxColumn_39.Name = "dateContractorDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_39.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_39.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_40.DataPropertyName = "Contact";
			dataGridViewCellStyle30.WrapMode = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_40.DefaultCellStyle = dataGridViewCellStyle30;
			this.dataGridViewFilterTextBoxColumn_40.HeaderText = "Контакты";
			this.dataGridViewFilterTextBoxColumn_40.Name = "contactDgvColumn";
			this.dataGridViewFilterTextBoxColumn_40.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_40.Visible = false;
			this.dataGridViewFilterTextBoxColumn_41.DataPropertyName = "LegalAddress";
			this.dataGridViewFilterTextBoxColumn_41.HeaderText = "Юр. адрес";
			this.dataGridViewFilterTextBoxColumn_41.Name = "legalAddressDgvColumn";
			this.dataGridViewFilterTextBoxColumn_41.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_41.Visible = false;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(964, 522);
			base.Controls.Add(this.splitContainer_0);
			base.Controls.Add(this.toolStrip_0);
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "FormJournalActs";
			this.Text = "Журнал актов технологических присоединений";
			base.FormClosed += this.FormJournalActs_FormClosed;
			base.Load += this.FormJournalActs_Load;
			this.toolStrip_0.ResumeLayout(false);
			this.toolStrip_0.PerformLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_0).EndInit();
			((ISupportInitialize)this.bsTC_Act).EndInit();
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
			((ISupportInitialize)this.dataGridViewExcelFilter_1).EndInit();
			((ISupportInitialize)this.bsTC_DocFile).EndInit();
			this.tabPage_1.ResumeLayout(false);
			((ISupportInitialize)this.dataGridViewExcelFilter_2).EndInit();
			((ISupportInitialize)this.bindingSource_2).EndInit();
			((ISupportInitialize)this.dataSet_0).EndInit();
			((ISupportInitialize)this.dataTable_0).EndInit();
			((ISupportInitialize)this.dataTable_1).EndInit();
			((ISupportInitialize)this.class10_1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		internal static void FYFxrhOU4uxpHHy6LYjL(Form form_0, bool bool_0)
		{
			form_0.Dispose(bool_0);
		}

		private int int_0;

		private int int_1;

		private List<int> list_0;

		private int TypeDoc;

		private ToolStrip toolStrip_0;

		private ToolStripButton toolStripButton_0;

		private ToolStripButton PcUoHilawyb;

		private ToolStripButton toolStripButton_1;

		private DataGridViewExcelFilter dataGridViewExcelFilter_0;

		private BindingSource bsTC_Act;

		private Class10 class10_0;

		private ToolStripSeparator toolStripSeparator_0;

		private ToolStripButton laSoWlyuudL;

		private ToolStripSeparator toolStripSeparator_1;

		private ToolStripButton toolStripButton_2;

		private ToolStripTextBox toolStripTextBox_0;

		private ToolStripButton toolStripButton_3;

		private ToolStripButton toolStripButton_4;

		private SplitContainer splitContainer_0;

		private DateTimePicker dateTimePicker_0;

		private System.Windows.Forms.Label label_0;

		private DateTimePicker dateTimePicker_1;

		private System.Windows.Forms.Label label_1;

		private ToolStrip toolStrip_1;

		private ToolStripButton toolStripButton_5;

		private ToolStripButton toolStripButton_6;

		private SplitContainer splitContainer_1;

		private TabControl tabControl_0;

		private TabPage tabPage_0;

		private DataGridViewExcelFilter dataGridViewExcelFilter_1;

		private BindingSource bsTC_DocFile;

		private DataGridViewImageColumnNotNull dataGridViewImageColumnNotNull_0;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

		private DataGridViewLinkColumn dataGridViewLinkColumn_0;

		private DataGridViewTextBoxColumn WuFoWxtYnFH;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

		private TabPage tabPage_1;

		private BindingSource bindingSource_2;

		private DataGridViewExcelFilter dataGridViewExcelFilter_2;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_3;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_4;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_5;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_6;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_7;

		private DataGridViewTextBoxColumn jhJoWkUrbs9;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_8;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_9;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_10;

		private DataGridViewTextBoxColumn vejoWbrnip3;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_11;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_12;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_13;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_14;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_15;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_16;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_17;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_18;

		private ToolStripSeparator toolStripSeparator_2;

		private ToolStripButton toolStripButton_7;

		private Class10 class10_1;

		private ToolStripSeparator toolStripSeparator_3;

		private ToolStripButton toolStripButton_8;

		private DataSet dataSet_0;

		private System.Data.DataTable dataTable_0;

		private DataColumn dataColumn_0;

		private DataColumn dataColumn_1;

		private System.Data.DataTable dataTable_1;

		private DataColumn dataColumn_2;

		private DataColumn dataColumn_3;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_0;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_1;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_2;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_3;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_4;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_5;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_6;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_19;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_7;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_8;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_9;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_10;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_20;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_11;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_21;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_12;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_13;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_14;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_22;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_23;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_15;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_16;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_24;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_25;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_26;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_27;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_28;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_29;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_30;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_31;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_32;

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

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_43;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_44;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_45;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_46;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_47;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_48;

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

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_83;

		private ToolStripButton toolStripButton_9;

		private ToolStripButton toolStripButton_10;

		private System.Windows.Forms.Label label_2;

		private TreeView treeView_0;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_17;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_84;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_18;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_19;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_20;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_21;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_22;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_23;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_24;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_25;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_26;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_27;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_28;

		private DataGridViewFilterTextBoxColumn KjRoPkSkqu1;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_29;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_30;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_31;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_32;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_33;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_34;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_35;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_36;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_37;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_85;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_86;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_38;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_39;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_40;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_41;
	}
}
