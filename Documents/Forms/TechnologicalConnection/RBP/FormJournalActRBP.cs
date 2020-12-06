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
using Constants;
using ControlsLbr.DataGridViewExcelFilter;
using ControlsLbr.Scheme;
using DataSql;
using Documents.DataSets;
using Documents.Properties;
using FormLbr;
using FormLbr.Classes;
using RikTheVeggie;

namespace Documents.Forms.TechnologicalConnection.RBP
{
	public partial class FormJournalActRBP : FormBase
	{
		public FormJournalActRBP()
		{
			
			this.IDLIST = -1;
			this.ABNSELECT = -1;
			this.OBJSELECT = -1;
			this.dictionary_0 = new Dictionary<string, FileWatcherArgsAddl>();
			
			this.method_15();
			FormJournalActRBP.instance = this;
		}

		public FormJournalActRBP(List<int> checkedSubstation)
		{
			
			this.IDLIST = -1;
			this.ABNSELECT = -1;
			this.OBJSELECT = -1;
			this.dictionary_0 = new Dictionary<string, FileWatcherArgsAddl>();
			
			this.method_15();
			FormJournalActRBP.instance = this;
			this.list_0 = checkedSubstation;
		}

		private void FormJournalActRBP_Load(object sender, EventArgs e)
		{
			this.dateTimePicker_1.Value = new DateTime(DateTime.Now.Year, 1, 1);
			this.dateTimePicker_0.Value = new DateTime(DateTime.Now.Year + 1, 1, 1).AddSeconds(-1.0);
			this.method_1();
			this.treeViewSchmObjects_0.SqlSettings = this.SqlSettings;
			this.treeViewSchmObjects_0.Load(this.list_0);
			this.method_0();
		}

		private void method_0()
		{
			string text = string.Empty;
			string text2 = this.method_2(this.triStateTreeView_0.Nodes);
			string text3 = string.Empty;
			string text4 = string.Empty;
			if (this.checkBox_0.Checked)
			{
				foreach (int num in this.method_4())
				{
					if (string.IsNullOrEmpty(text3))
					{
						text3 += num.ToString();
					}
					else
					{
						text3 = text3 + ", " + num.ToString();
					}
				}
				if (!string.IsNullOrEmpty(text3))
				{
					text4 += string.Format(" and tc.idSubPoint in ({0}) ", text3);
				}
			}
			else
			{
				foreach (int num2 in this.treeViewSchmObjects_0.GetListChecked())
				{
					if (string.IsNullOrEmpty(text3))
					{
						text3 += num2.ToString();
					}
					else
					{
						text3 = text3 + ", " + num2.ToString();
					}
				}
				if (!string.IsNullOrEmpty(text3))
				{
					text4 += string.Format(" and (tc.idSubPoint in ({0}) or tc.idBusPoint in ({0})  or tc.idCellPoint in ({0})) ", text3);
				}
			}
			string str = string.Format("select distinct doc.id, doc.idAbn, doc.idAbnObj, cd.name as typeDoc,  tAbn.CodeAbonent, tAbn.Name, tAbnObj.Name as objName, rbp.Data,  doc.DocNumber as actNumber, doc.DocDate as actDate,  fullPointName.SBC AS StationList, doc.idDocType,  cr.Name as actRegion, doc.isActive, doc.Deleted  from tAbnObjDoc_List as doc left join  (\tselect d.id, SBC = (select (ISNULL(schmS.typeCodeSocr + '-' + schmS.Name, '') +  ISNULL('\\'+ schmB.typeCodeSocr + '-' + schmB.Name, '')  + ISNULL('\\' + schmC.typeCodeSocr + '-' + schmC.Name, '') + char(10) + char(13))  from tTC_TUPointAttach as tc left join  vSchm_ObjList as schmS on schmS.Id = tc.idSubPoint left join  vSchm_ObjList as schmB on schmB.Id = tc.idBusPoint left join  vSchm_ObjList as schmC on schmC.Id = tc.idCellPoint  where tc.idTU = d.id and tc.TypeDoc = d.idDocType {2} for xml path(''), type).value('.', 'varchar(max)')  from tAbnObjDoc_List as d) as fullPointName on fullPointName.id = doc.id left join  tTC_TUPointAttach as tc on tc.idTU = doc.id left join  tR_Classifier as cd on cd.Id = doc.idDocType left join  tAbnObjDoc_AktRBP as rbp on rbp.idList = doc.id left join  tR_Classifier as cr on cr.Id = rbp.NetRegion left join  tAbn on tabn.id = doc.idAbn left join  tAbnObj on tAbnObj.id = doc.idAbnObj  where doc.DocDate >= '{0}' and doc.DocDate <= '{1}' {2} ", this.dateTimePicker_1.Value.Date.ToString("yyyyMMdd"), this.dateTimePicker_0.Value.Date.ToString("yyyyMMdd"), text4);
			if (!string.IsNullOrEmpty(text2))
			{
				text += string.Format(" and doc.idDocType in ({0}) ", text2);
			}
			if (!this.toolStripButton_9.Checked)
			{
				text += " and doc.deleted = 0 ";
			}
			string str2 = " order by tAbn.CodeAbonent, tAbnObj.Name ";
			string select = str + text + str2;
			SqlDataCommand sqlDataCommand = new SqlDataCommand(this.SqlSettings);
			DataTable dataSource = new DataTable();
			dataSource = sqlDataCommand.SelectSqlData(select);
			this.bindingSource_0.DataSource = dataSource;
		}

		private void dataGridViewExcelFilter_0_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				if (Convert.ToInt32(this.dataGridViewExcelFilter_0[this.dataGridViewFilterCheckBoxColumn_0.Name, e.RowIndex].Value) == 0)
				{
					e.CellStyle.Font = new Font(this.dataGridViewExcelFilter_0.Font, FontStyle.Italic);
				}
				if (Convert.ToInt32(this.dataGridViewExcelFilter_0[this.dataGridViewTextBoxColumn_20.Name, e.RowIndex].Value) == 1)
				{
					e.CellStyle.ForeColor = Color.Red;
				}
			}
		}

		private void method_1()
		{
			DataTable dataTable = new DataTable("tR_Classifier");
			dataTable.Columns.Add("id", typeof(int));
			dataTable.Columns.Add("name", typeof(string));
			base.SelectSqlData(dataTable, true, " where ParentKey = ';TypeDoc;tAbnobj;' and Value in (1, 4) order by Name ", null, false, 0);
			foreach (object obj in dataTable.Rows)
			{
				DataRow dataRow = (DataRow)obj;
				TreeNode treeNode = new TreeNode(dataRow["name"].ToString());
				treeNode.Tag = dataRow["id"];
				treeNode.Checked = true;
				this.triStateTreeView_0.Nodes.Add(treeNode);
			}
			this.triStateTreeView_0.LoadStates();
		}

		private string method_2(TreeNodeCollection treeNodeCollection_0)
		{
			string text = string.Empty;
			List<int> list = new List<int>();
			foreach (object obj in treeNodeCollection_0)
			{
				TreeNode treeNode_ = (TreeNode)obj;
				this.method_3(treeNode_, list);
			}
			foreach (int num in list)
			{
				if (string.IsNullOrEmpty(text))
				{
					text += num.ToString();
				}
				else
				{
					text = text + ", " + num.ToString();
				}
			}
			return text;
		}

		private void method_3(TreeNode treeNode_0, List<int> list_1)
		{
			if (treeNode_0.Checked && treeNode_0.Tag != null)
			{
				list_1.Add(Convert.ToInt32(treeNode_0.Tag));
			}
			foreach (object obj in treeNode_0.Nodes)
			{
				TreeNode treeNode_ = (TreeNode)obj;
				this.method_3(treeNode_, list_1);
			}
		}

		private List<int> method_4()
		{
			List<int> list = new List<int>();
			foreach (object obj in this.treeViewSchmObjects_0.Nodes)
			{
				TreeNode treeNode = (TreeNode)obj;
				this.method_5(treeNode.Nodes, list);
			}
			return list;
		}

		private void method_5(TreeNodeCollection treeNodeCollection_0, List<int> list_1)
		{
			int count = list_1.Count;
			foreach (object obj in treeNodeCollection_0)
			{
				TreeNode treeNode = (TreeNode)obj;
				if (treeNode.Checked)
				{
					switch (treeNode.Level)
					{
					case 1:
						list_1.Add((int)treeNode.Tag);
						break;
					case 2:
						list_1.Add((int)treeNode.Parent.Tag);
						break;
					case 3:
						list_1.Add((int)treeNode.Parent.Parent.Tag);
						break;
					}
				}
				else
				{
					this.method_5(treeNode.Nodes, list_1);
					if (list_1.Count > count)
					{
						break;
					}
				}
			}
		}

		private void method_6(TreeNodeCollection treeNodeCollection_0, bool bool_0 = false)
		{
			foreach (object obj in treeNodeCollection_0)
			{
				TreeNode treeNode = (TreeNode)obj;
				treeNode.Checked = bool_0;
				this.method_6(treeNode.Nodes, bool_0);
			}
		}

		private void toolStripMenuItem_0_Click(object sender, EventArgs e)
		{
			if (new FormObjFind
			{
				Owner = this,
				SqlSettings = this.SqlSettings
			}.ShowDialog() == DialogResult.OK)
			{
				FormAbnAktRBP formAbnAktRBP = new FormAbnAktRBP(this.SqlSettings, true, true, this.ABNSELECT, this.OBJSELECT, TypeDocValue.ActBalance);
				formAbnAktRBP.Owner = this;
				formAbnAktRBP.FormClosed += this.method_7;
				formAbnAktRBP.MdiParent = base.MdiParent;
				formAbnAktRBP.Show();
			}
		}

		private void toolStripMenuItem_1_Click(object sender, EventArgs e)
		{
			if (new FormObjFind
			{
				Owner = this,
				SqlSettings = this.SqlSettings
			}.ShowDialog() == DialogResult.OK)
			{
				FormAbnAktRBP formAbnAktRBP = new FormAbnAktRBP(this.SqlSettings, true, true, this.ABNSELECT, this.OBJSELECT, TypeDocValue.ActLiability);
				formAbnAktRBP.Owner = this;
				formAbnAktRBP.FormClosed += this.method_7;
				formAbnAktRBP.MdiParent = base.MdiParent;
				formAbnAktRBP.Show();
			}
		}

		private void method_7(object sender, FormClosedEventArgs e)
		{
			if (((Form)sender).DialogResult == DialogResult.OK)
			{
				this.method_0();
				this.method_8((sender is FormAbnAktRBP) ? ((FormAbnAktRBP)sender).IdList : -1);
			}
		}

		private void toolStripButton_6_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_0.SelectedRows != null && this.dataGridViewExcelFilter_0.SelectedRows.Count > 0 && this.IDLIST != -1)
			{
				int idAbnObj = 0;
				if (((DataRowView)this.bindingSource_0.Current)["idAbnObj"] != DBNull.Value)
				{
					idAbnObj = Convert.ToInt32(((DataRowView)this.bindingSource_0.Current)["idAbnObj"]);
				}
				FormAbnAktRBP formAbnAktRBP = new FormAbnAktRBP(this.SqlSettings, idAbnObj, this.IDLIST);
				formAbnAktRBP.MdiParent = base.MdiParent;
				formAbnAktRBP.FormClosed += this.method_7;
				formAbnAktRBP.Show();
			}
		}

		private void toolStripButton_7_Click(object sender, EventArgs e)
		{
			new FormAbnAktRBP(this.SqlSettings, 1, this.IDLIST, true)
			{
				MdiParent = base.MdiParent
			}.Show();
		}

		private void dataGridViewExcelFilter_0_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			new FormAbnAktRBP(this.SqlSettings, 1, this.IDLIST, true)
			{
				MdiParent = base.MdiParent
			}.Show();
		}

		private void toolStripButton_8_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_0.SelectedRows != null && this.dataGridViewExcelFilter_0.SelectedRows.Count > 0 && MessageBox.Show("Вы действительно хотите удалить текущий документ?", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				int index = this.dataGridViewExcelFilter_0.CurrentRow.Index;
				DataSetAbnObjAct dataSetAbnObjAct = new DataSetAbnObjAct();
				base.SelectSqlData(dataSetAbnObjAct, dataSetAbnObjAct.tAbnObjDoc_List, true, "where id = " + this.IDLIST);
				dataSetAbnObjAct.tAbnObjDoc_List.First<DataSetAbnObjAct.tAbnObjDoc_ListRow>().Deleted = !dataSetAbnObjAct.tAbnObjDoc_List.First<DataSetAbnObjAct.tAbnObjDoc_ListRow>().Deleted;
				dataSetAbnObjAct.tAbnObjDoc_List.Rows[0].EndEdit();
				if (base.UpdateSqlData(dataSetAbnObjAct, dataSetAbnObjAct.tAbnObjDoc_List))
				{
					if (dataSetAbnObjAct.tAbnObjDoc_List.First<DataSetAbnObjAct.tAbnObjDoc_ListRow>().Deleted)
					{
						this.method_0();
						MessageBox.Show("Документ успешно удален");
					}
					else
					{
						this.method_0();
						MessageBox.Show("Документ успешно восстановлен");
					}
					this.method_0();
				}
			}
		}

		private void method_8(int int_0)
		{
			this.bindingSource_0.Position = this.bindingSource_0.Find("id", int_0);
			this.method_9(int_0);
		}

		private void method_9(int int_0)
		{
			base.SelectSqlData(this.dataSetAbnObjAct_0.tAbnObjDoc_File, true, " where idList = " + int_0.ToString(), null, false, 0);
			this.method_11();
		}

		private void toolStripMenuItem_2_Click(object sender, EventArgs e)
		{
			if (new FormObjFind
			{
				Owner = this,
				SqlSettings = this.SqlSettings
			}.ShowDialog() == DialogResult.OK)
			{
				FormAbnAktRBP formAbnAktRBP = new FormAbnAktRBP(this.SqlSettings, true, this.ABNSELECT, TypeDocValue.ActBalance);
				formAbnAktRBP.Owner = this;
				formAbnAktRBP.MdiParent = base.MdiParent;
				formAbnAktRBP.FormClosed += this.method_7;
				formAbnAktRBP.Show();
			}
		}

		private void toolStripMenuItem_3_Click(object sender, EventArgs e)
		{
			if (new FormObjFind
			{
				Owner = this,
				SqlSettings = this.SqlSettings
			}.ShowDialog() == DialogResult.OK)
			{
				FormAbnAktRBP formAbnAktRBP = new FormAbnAktRBP(this.SqlSettings, true, this.ABNSELECT, TypeDocValue.ActLiability);
				formAbnAktRBP.Owner = this;
				formAbnAktRBP.MdiParent = base.MdiParent;
				formAbnAktRBP.FormClosed += this.method_7;
				formAbnAktRBP.Show();
			}
		}

		private void toolStripButton_17_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_0.SelectedRows != null && this.dataGridViewExcelFilter_0.SelectedRows.Count > 0 && new FormObjFind
			{
				Owner = this,
				SqlSettings = this.SqlSettings
			}.ShowDialog() == DialogResult.OK)
			{
				FormAbnAktRBP formAbnAktRBP = new FormAbnAktRBP(this.SqlSettings, this.OBJSELECT, this.IDLIST, this.ABNSELECT);
				formAbnAktRBP.Owner = this;
				formAbnAktRBP.MdiParent = base.MdiParent;
				formAbnAktRBP.FormClosed += this.method_7;
				formAbnAktRBP.Show();
			}
		}

		private void toolStripButton_16_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_0.SelectedRows != null && this.dataGridViewExcelFilter_0.SelectedRows.Count > 0 && new FormObjFind
			{
				Owner = this,
				SqlSettings = this.SqlSettings
			}.ShowDialog() == DialogResult.OK)
			{
				base.SelectSqlData(this.dataSetAbnObjAct_0, this.dataSetAbnObjAct_0.tAbnObjDoc_List, true, " where id = " + this.IDLIST);
				this.dataSetAbnObjAct_0.tAbnObjDoc_List.First<DataSetAbnObjAct.tAbnObjDoc_ListRow>().idAbn = this.ABNSELECT;
				this.dataSetAbnObjAct_0.tAbnObjDoc_List.First<DataSetAbnObjAct.tAbnObjDoc_ListRow>().idAbnObj = this.OBJSELECT;
				base.UpdateSqlData(this.dataSetAbnObjAct_0, this.dataSetAbnObjAct_0.tAbnObjDoc_List);
				FormAbnAktRBP formAbnAktRBP = new FormAbnAktRBP(this.SqlSettings, this.OBJSELECT, this.IDLIST, this.ABNSELECT);
				formAbnAktRBP.Owner = this;
				formAbnAktRBP.MdiParent = base.MdiParent;
				formAbnAktRBP.FormClosed += this.method_7;
				formAbnAktRBP.Show();
			}
		}

		private void toolStripButton_0_Click(object sender, EventArgs e)
		{
			this.method_0();
		}

		private void toolStripButton_1_Click(object sender, EventArgs e)
		{
			this.toolStripButton_9.Checked = false;
			this.checkBox_0.Checked = false;
			this.method_6(this.triStateTreeView_0.Nodes, true);
			this.treeViewSchmObjects_0.ClearTreeChecked();
			this.treeViewSchmObjects_0.CollapseAll();
			this.dateTimePicker_1.Value = new DateTime(DateTime.Now.Year, 1, 1);
			this.dateTimePicker_0.Value = new DateTime(DateTime.Now.Year + 1, 1, 1).AddSeconds(-1.0);
			this.method_0();
		}

		private void toolStripButton_2_Click(object sender, EventArgs e)
		{
			this.dateTimePicker_1.Value = this.dateTimePicker_1.Value.AddYears(-1);
			this.dateTimePicker_0.Value = this.dateTimePicker_0.Value.AddYears(-1);
		}

		private void toolStripButton_3_Click(object sender, EventArgs e)
		{
			this.dateTimePicker_0.Value = this.dateTimePicker_0.Value.AddYears(1);
			this.dateTimePicker_1.Value = this.dateTimePicker_1.Value.AddYears(1);
		}

		private void toolStripButton_4_Click(object sender, EventArgs e)
		{
			this.method_13(false);
		}

		private void oSySwegtED_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			this.method_13(false);
		}

		private void toolStripButton_5_Click(object sender, EventArgs e)
		{
			if (this.bindingSource_1.Current != null)
			{
				DataSetAbnObjAct.tAbnObjDoc_FileRow tAbnObjDoc_FileRow = (DataSetAbnObjAct.tAbnObjDoc_FileRow)((DataRowView)this.bindingSource_1.Current).Row;
				if (tAbnObjDoc_FileRow["File"] == DBNull.Value)
				{
					try
					{
						using (SqlConnection sqlConnection = new SqlConnection(this.SqlSettings.GetConnectionString()))
						{
							sqlConnection.Open();
							SqlDataReader sqlDataReader = new SqlCommand("SELECT [File] FROM tTC_DocFile WHERE id = " + tAbnObjDoc_FileRow["id"].ToString(), sqlConnection).ExecuteReader();
							while (sqlDataReader.Read())
							{
								tAbnObjDoc_FileRow["File"] = sqlDataReader["File"];
							}
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, ex.Source);
					}
				}
				byte[] file = tAbnObjDoc_FileRow.File;
				SaveFileDialog saveFileDialog = new SaveFileDialog();
				saveFileDialog.FileName = tAbnObjDoc_FileRow.FileName;
				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					this.ByteArrayToFile(saveFileDialog.FileName, file);
				}
			}
		}

		public bool ByteArrayToFile(string fileName, byte[] byteArray)
		{
			try
			{
				FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
				fileStream.Write(byteArray, 0, byteArray.Length);
				fileStream.Close();
				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, ex.Source);
				ex.ToString();
			}
			return false;
		}

		private void toolStripButton_10_Click(object sender, EventArgs e)
		{
			this.dataGridViewExcelFilter_0.SearchGrid(DataGridViewExcelFilter.TypeFind.Begin, this.toolStripTextBox_0.Text);
		}

		private void toolStripButton_11_Click(object sender, EventArgs e)
		{
			this.dataGridViewExcelFilter_0.SearchGrid(DataGridViewExcelFilter.TypeFind.Prev, this.toolStripTextBox_0.Text);
		}

		private void toolStripButton_12_Click(object sender, EventArgs e)
		{
			this.dataGridViewExcelFilter_0.SearchGrid(DataGridViewExcelFilter.TypeFind.Next, this.toolStripTextBox_0.Text);
		}

		private void toolStripTextBox_0_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (char.IsControl(e.KeyChar) && this.toolStripTextBox_0.Text.Length > 0)
			{
				if (e.KeyChar == '\r' && (Control.ModifierKeys & Keys.Shift) == Keys.Shift)
				{
					e.Handled = true;
					this.dataGridViewExcelFilter_0.SearchGrid(DataGridViewExcelFilter.TypeFind.Prev, this.toolStripTextBox_0.Text);
					return;
				}
				if (e.KeyChar == '\r')
				{
					e.Handled = true;
					this.dataGridViewExcelFilter_0.SearchGrid(DataGridViewExcelFilter.TypeFind.Next, this.toolStripTextBox_0.Text);
				}
			}
		}

		private void toolStripButton_18_Click(object sender, EventArgs e)
		{
			this.dataGridViewExcelFilter_0.ExportToExcel();
		}

		private void toolStripButton_13_Click(object sender, EventArgs e)
		{
			if (this.toolStripTextBox_1.Text.Length > 0)
			{
				this.treeViewSchmObjects_0.Find(this.toolStripTextBox_1.Text);
				this.treeViewSchmObjects_0.Focus();
			}
		}

		private void toolStripButton_14_Click(object sender, EventArgs e)
		{
			if (this.toolStripTextBox_1.Text.Length > 0)
			{
				this.treeViewSchmObjects_0.FindPrev(this.toolStripTextBox_1.Text);
				this.treeViewSchmObjects_0.Focus();
			}
		}

		private void toolStripButton_15_Click(object sender, EventArgs e)
		{
			if (this.toolStripTextBox_1.Text.Length > 0)
			{
				this.treeViewSchmObjects_0.FindNext(this.toolStripTextBox_1.Text);
				this.treeViewSchmObjects_0.Focus();
			}
		}

		private void treeViewSchmObjects_0_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (char.IsControl(e.KeyChar) && this.toolStripTextBox_1.Text.Length > 0)
			{
				if (e.KeyChar == '\r' && (Control.ModifierKeys & Keys.Shift) == Keys.Shift)
				{
					e.Handled = true;
					this.treeViewSchmObjects_0.FindPrev(this.toolStripTextBox_1.Text);
					this.treeViewSchmObjects_0.Focus();
					return;
				}
				if (e.KeyChar == '\r')
				{
					e.Handled = true;
					this.treeViewSchmObjects_0.FindNext(this.toolStripTextBox_1.Text);
					this.treeViewSchmObjects_0.Focus();
				}
			}
		}

		private void dateTimePicker_1_ValueChanged(object sender, EventArgs e)
		{
			this.dateTimePicker_0.MinDate = this.dateTimePicker_1.Value;
		}

		private void dateTimePicker_0_ValueChanged(object sender, EventArgs e)
		{
			this.dateTimePicker_1.MaxDate = this.dateTimePicker_0.Value;
		}

		private void bindingSource_0_CurrentChanged(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_0.CurrentRow != null)
			{
				this.IDLIST = Convert.ToInt32(((DataRowView)this.bindingSource_0.Current)["id"]);
				this.method_10(this.IDLIST);
				return;
			}
			this.IDLIST = -1;
		}

		private void toolStripButton_9_CheckedChanged(object sender, EventArgs e)
		{
			this.toolStripButton_9.Text = (this.toolStripButton_9.Checked ? "Скрыть удаленные документы" : "Показать удаленные документы");
			this.method_0();
		}

		private void treeViewSchmObjects_0_BeforeExpand(object sender, TreeViewCancelEventArgs e)
		{
			if (e.Node.Level == 2)
			{
				foreach (object obj in e.Node.Nodes)
				{
					foreach (object obj2 in ((TreeNode)obj).Nodes)
					{
						((TreeNode)obj2).Remove();
					}
				}
			}
		}

		private void FormJournalActRBP_SizeChanged(object sender, EventArgs e)
		{
			this.toolStrip_3.Location = new Point(this.splitContainer_0.SplitterDistance + this.splitContainer_0.SplitterWidth + 21, this.toolStrip_3.Location.Y);
		}

		private void splitContainer_0_SplitterMoved(object sender, SplitterEventArgs e)
		{
			this.toolStrip_3.Location = new Point(this.splitContainer_0.SplitterDistance + this.splitContainer_0.SplitterWidth + 21, this.toolStrip_3.Location.Y);
		}

		private void method_10(int int_0)
		{
			base.SelectSqlData(this.dataSetAbnObjAct_0.tAbnObjDoc_File, true, " where idList = " + int_0, null, false, 0);
			this.method_11();
		}

		private void method_11()
		{
			if (base.InvokeRequired)
			{
				base.Invoke(new Action(this.method_16));
				return;
			}
			this.bindingSource_1.ResetBindings(false);
		}

		private string method_12()
		{
			string str = (!(((DataRowView)this.bindingSource_0.Current)["idAbn"] is string) || !string.IsNullOrEmpty(((DataRowView)this.bindingSource_0.Current)["idAbn"].ToString())) ? "tmp" : ((DataRowView)this.bindingSource_0.Current)["idAbn"].ToString();
			string text = Path.GetTempPath() + "\\" + str + "\\";
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			return text;
		}

		private void method_13(bool bool_0 = false)
		{
			if (this.bindingSource_1.Current != null)
			{
				DataSetAbnObjAct.tAbnObjDoc_FileRow tAbnObjDoc_FileRow = (DataSetAbnObjAct.tAbnObjDoc_FileRow)((DataRowView)this.bindingSource_1.Current).Row;
				string fileName = tAbnObjDoc_FileRow.FileName;
				string text = this.method_12();
				string newFileNameIsExists = FileBinary.GetNewFileNameIsExists(text, fileName, false);
				int? idTemplate = null;
				if (tAbnObjDoc_FileRow["idTemplate"] != DBNull.Value)
				{
					idTemplate = new int?(tAbnObjDoc_FileRow.idTemplate);
				}
				DateTime dateChange = tAbnObjDoc_FileRow.dateChange;
				if (tAbnObjDoc_FileRow["file"] == DBNull.Value)
				{
					try
					{
						using (SqlConnection sqlConnection = new SqlConnection(this.SqlSettings.GetConnectionString()))
						{
							sqlConnection.Open();
							SqlDataReader sqlDataReader = new SqlCommand("select [file] from tDocAct_File where id = " + tAbnObjDoc_FileRow["id"].ToString(), sqlConnection).ExecuteReader();
							while (sqlDataReader.Read())
							{
								tAbnObjDoc_FileRow["file"] = sqlDataReader["file"];
							}
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, ex.Source);
					}
				}
				byte[] file;
				try
				{
					file = tAbnObjDoc_FileRow.File;
				}
				catch
				{
					MessageBox.Show("Нет содержимого файла");
					return;
				}
				FileBinary fileBinary = new FileBinary(file, newFileNameIsExists, DateTime.Now);
				fileBinary.SaveToDisk(text);
				Process.Start(text + "\\" + fileBinary.Name);
				if (bool_0)
				{
					if (this.dictionary_0.ContainsKey(fileName))
					{
						if (this.dictionary_0[fileName].Watcher == null)
						{
							FileWatcher fileWatcher = new FileWatcher(text, newFileNameIsExists);
							fileWatcher.AnyChanged += this.method_14;
							fileWatcher.Start();
							this.dictionary_0[fileName].Watcher = fileWatcher;
						}
						else
						{
							this.dictionary_0[fileName].Watcher.AnyChanged -= this.method_14;
							this.dictionary_0[fileName].Watcher.Stop();
							FileWatcher fileWatcher2 = new FileWatcher(text, newFileNameIsExists);
							fileWatcher2.AnyChanged += this.method_14;
							fileWatcher2.Start();
							this.dictionary_0[fileName].Watcher = fileWatcher2;
						}
						this.dictionary_0[fileName].TempName = newFileNameIsExists;
						this.dictionary_0[fileName].OpenState = FileOpenState.Editing;
						return;
					}
					FileWatcher fileWatcher3 = new FileWatcher(text, newFileNameIsExists);
					fileWatcher3.AnyChanged += this.method_14;
					fileWatcher3.Start();
					FileWatcherArgsAddl value = new FileWatcherArgsAddl(idTemplate, fileName, newFileNameIsExists, fileWatcher3, FileOpenState.Editing);
					this.dictionary_0.Add(fileName, value);
				}
			}
		}

		private void method_14(object sender, FileSystemEventArgs e)
		{
			IEnumerable<KeyValuePair<string, FileWatcherArgsAddl>> fwargs = from item in this.dictionary_0
			where item.Value.TempName == e.Name
			select item;
			if (fwargs.Count<KeyValuePair<string, FileWatcherArgsAddl>>() > 0)
			{
				FileBinary fileBinary = new FileBinary(e.FullPath);
				EnumerableRowCollection<DataSetAbnObjAct.tAbnObjDoc_FileRow> source = from rowFiles in this.dataSetAbnObjAct_0.tAbnObjDoc_File
				where rowFiles.RowState != DataRowState.Deleted && rowFiles.FileName == fwargs.First<KeyValuePair<string, FileWatcherArgsAddl>>().Value.OriginalName
				select rowFiles;
				if (source.Count<DataSetAbnObjAct.tAbnObjDoc_FileRow>() == 0)
				{
					DataSetAbnObjAct.tAbnObjDoc_FileRow tAbnObjDoc_FileRow = this.dataSetAbnObjAct_0.tAbnObjDoc_File.NewtAbnObjDoc_FileRow();
					DataSetAbnObjAct.tAbnObjDoc_FileRow tAbnObjDoc_FileRow2 = tAbnObjDoc_FileRow;
					int id;
					if (this.dataSetAbnObjAct_0.tAbnObjDoc_File.Min((DataSetAbnObjAct.tAbnObjDoc_FileRow min) => min.id) >= 0)
					{
						id = -1;
					}
					else
					{
						id = this.dataSetAbnObjAct_0.tAbnObjDoc_File.Min((DataSetAbnObjAct.tAbnObjDoc_FileRow min) => min.id) - 1;
					}
					tAbnObjDoc_FileRow2.id = id;
					tAbnObjDoc_FileRow.idList = this.IDLIST;
					tAbnObjDoc_FileRow.FileName = fwargs.First<KeyValuePair<string, FileWatcherArgsAddl>>().Value.OriginalName;
					tAbnObjDoc_FileRow.File = fileBinary.ByteArray;
					tAbnObjDoc_FileRow.dateChange = fileBinary.LastChanged;
					tAbnObjDoc_FileRow.idTemplate = fwargs.First<KeyValuePair<string, FileWatcherArgsAddl>>().Value.IdTemplate.Value;
					this.dataSetAbnObjAct_0.tAbnObjDoc_File.AddtAbnObjDoc_FileRow(tAbnObjDoc_FileRow);
				}
				else
				{
					source.First<DataSetAbnObjAct.tAbnObjDoc_FileRow>().File = fileBinary.ByteArray;
					source.First<DataSetAbnObjAct.tAbnObjDoc_FileRow>().dateChange = fileBinary.LastChanged;
					source.First<DataSetAbnObjAct.tAbnObjDoc_FileRow>().EndEdit();
				}
			}
			if (base.InvokeRequired)
			{
				base.Invoke(new Action(this.method_17));
				return;
			}
			this.bindingSource_1.ResetBindings(false);
		}

		private void method_15()
		{
			this.icontainer_0 = new Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FormJournalActRBP));
			DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
			this.toolStrip_0 = new ToolStrip();
			this.toolStripSplitButton_0 = new ToolStripSplitButton();
			this.toolStripMenuItem_0 = new ToolStripMenuItem();
			this.toolStripMenuItem_1 = new ToolStripMenuItem();
			this.toolStripButton_6 = new ToolStripButton();
			this.toolStripButton_7 = new ToolStripButton();
			this.toolStripButton_8 = new ToolStripButton();
			this.toolStripButton_16 = new ToolStripButton();
			this.toolStripButton_17 = new ToolStripButton();
			this.toolStripSeparator_1 = new ToolStripSeparator();
			this.toolStripSplitButton_1 = new ToolStripSplitButton();
			this.toolStripMenuItem_2 = new ToolStripMenuItem();
			this.toolStripMenuItem_3 = new ToolStripMenuItem();
			this.splitContainer_0 = new SplitContainer();
			this.toolStrip_4 = new ToolStrip();
			this.toolStripButton_13 = new ToolStripButton();
			this.toolStripTextBox_1 = new ToolStripTextBox();
			this.toolStripButton_14 = new ToolStripButton();
			this.toolStripButton_15 = new ToolStripButton();
			this.treeViewSchmObjects_0 = new TreeViewSchmObjects();
			this.triStateTreeView_0 = new TriStateTreeView();
			this.label_2 = new Label();
			this.checkBox_0 = new CheckBox();
			this.label_0 = new Label();
			this.label_1 = new Label();
			this.dateTimePicker_0 = new DateTimePicker();
			this.dateTimePicker_1 = new DateTimePicker();
			this.toolStrip_1 = new ToolStrip();
			this.toolStripButton_0 = new ToolStripButton();
			this.toolStripButton_1 = new ToolStripButton();
			this.toolStripButton_2 = new ToolStripButton();
			this.toolStripButton_3 = new ToolStripButton();
			this.toolStripSeparator_0 = new ToolStripSeparator();
			this.toolStripButton_9 = new ToolStripButton();
			this.splitContainer_1 = new SplitContainer();
			this.dataGridViewExcelFilter_0 = new DataGridViewExcelFilter();
			this.dataGridViewTextBoxColumn_15 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_16 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_17 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_18 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_19 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_20 = new DataGridViewTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_10 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_11 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_12 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_13 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_14 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_15 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_16 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_17 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterCheckBoxColumn_0 = new DataGridViewFilterCheckBoxColumn();
			this.bindingSource_0 = new BindingSource(this.icontainer_0);
			this.dataSetAbnObjAct_0 = new DataSetAbnObjAct();
			this.oSySwegtED = new DataGridView();
			this.dataGridViewImageColumnNotNull_0 = new DataGridViewImageColumnNotNull();
			this.dataGridViewFilterTextBoxColumn_9 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewTextBoxColumn_11 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_12 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_13 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_14 = new DataGridViewTextBoxColumn();
			this.bindingSource_1 = new BindingSource(this.icontainer_0);
			this.toolStrip_2 = new ToolStrip();
			this.toolStripButton_4 = new ToolStripButton();
			this.toolStripButton_5 = new ToolStripButton();
			this.dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_3 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_4 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_5 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_6 = new DataGridViewTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_0 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_1 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_2 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_3 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_4 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_5 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_6 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_7 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewTextBoxColumn_7 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_8 = new DataGridViewTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_8 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewImageColumn_0 = new DataGridViewImageColumn();
			this.dataGridViewTextBoxColumn_9 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_10 = new DataGridViewTextBoxColumn();
			this.toolStrip_3 = new ToolStrip();
			this.toolStripButton_10 = new ToolStripButton();
			this.toolStripTextBox_0 = new ToolStripTextBox();
			this.toolStripButton_11 = new ToolStripButton();
			this.toolStripButton_12 = new ToolStripButton();
			this.toolStripSeparator_2 = new ToolStripSeparator();
			this.toolStripButton_18 = new ToolStripButton();
			this.toolStrip_0.SuspendLayout();
			this.splitContainer_0.Panel1.SuspendLayout();
			this.splitContainer_0.Panel2.SuspendLayout();
			this.splitContainer_0.SuspendLayout();
			this.toolStrip_4.SuspendLayout();
			this.toolStrip_1.SuspendLayout();
			this.splitContainer_1.Panel1.SuspendLayout();
			this.splitContainer_1.Panel2.SuspendLayout();
			this.splitContainer_1.SuspendLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_0).BeginInit();
			((ISupportInitialize)this.bindingSource_0).BeginInit();
			((ISupportInitialize)this.dataSetAbnObjAct_0).BeginInit();
			((ISupportInitialize)this.oSySwegtED).BeginInit();
			((ISupportInitialize)this.bindingSource_1).BeginInit();
			this.toolStrip_2.SuspendLayout();
			this.toolStrip_3.SuspendLayout();
			base.SuspendLayout();
			this.toolStrip_0.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripSplitButton_0,
				this.toolStripButton_6,
				this.toolStripButton_7,
				this.toolStripButton_8,
				this.toolStripSeparator_1,
				this.toolStripSplitButton_1,
				this.toolStripSeparator_2,
				this.toolStripButton_17,
				this.toolStripButton_16
			});
			this.toolStrip_0.Location = new Point(0, 0);
			this.toolStrip_0.Name = "toolStripAct";
			this.toolStrip_0.Size = new Size(979, 25);
			this.toolStrip_0.TabIndex = 1;
			this.toolStripSplitButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripSplitButton_0.DropDownItems.AddRange(new ToolStripItem[]
			{
				this.toolStripMenuItem_0,
				this.toolStripMenuItem_1
			});
			this.toolStripSplitButton_0.Image = Resources.ElementAdd;
			this.toolStripSplitButton_0.ImageTransparentColor = Color.Magenta;
			this.toolStripSplitButton_0.Name = "toolSBtnAdd";
			this.toolStripSplitButton_0.Size = new Size(32, 22);
			this.toolStripSplitButton_0.Text = "Добавить акт";
			this.toolStripMenuItem_0.Name = "toolSBtnAddActBalance";
			this.toolStripMenuItem_0.Size = new Size(422, 22);
			this.toolStripMenuItem_0.Text = "Акт разграничения балансовой принадлежности сторон";
			this.toolStripMenuItem_0.Click += this.toolStripMenuItem_0_Click;
			this.toolStripMenuItem_1.Name = "toolSBtnAddActLiability";
			this.toolStripMenuItem_1.Size = new Size(422, 22);
			this.toolStripMenuItem_1.Text = "Акт разграничения эксплуатационной ответственности сторон";
			this.toolStripMenuItem_1.Click += this.toolStripMenuItem_1_Click;
			this.toolStripButton_6.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_6.Image = Resources.ElementEdit;
			this.toolStripButton_6.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_6.Name = "toolBtnEditAct";
			this.toolStripButton_6.Size = new Size(23, 22);
			this.toolStripButton_6.Text = "Редактировать акт";
			this.toolStripButton_6.Click += this.toolStripButton_6_Click;
			this.toolStripButton_7.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_7.Image = Resources.ElementInformation;
			this.toolStripButton_7.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_7.Name = "toolBtnViewAct";
			this.toolStripButton_7.Size = new Size(23, 22);
			this.toolStripButton_7.Text = "Просмотр акта";
			this.toolStripButton_7.Click += this.toolStripButton_7_Click;
			this.toolStripButton_8.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_8.Image = Resources.ElementDel;
			this.toolStripButton_8.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_8.Name = "toolBtnDelAct";
			this.toolStripButton_8.Size = new Size(23, 22);
			this.toolStripButton_8.Text = "Удалить акт";
			this.toolStripButton_8.Click += this.toolStripButton_8_Click;
			this.toolStripButton_16.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_16.Image = (Image)componentResourceManager.GetObject("toolBtnMoveAct.Image");
			this.toolStripButton_16.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_16.Name = "toolBtnMoveAct";
			this.toolStripButton_16.Size = new Size(23, 22);
			this.toolStripButton_16.Text = "Переместить акт";
			this.toolStripButton_16.Click += this.toolStripButton_16_Click;
			this.toolStripButton_17.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_17.Image = Resources.CopyBuffer;
			this.toolStripButton_17.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_17.Name = "toolBtnCopyAct";
			this.toolStripButton_17.Size = new Size(23, 22);
			this.toolStripButton_17.Text = "Скопировать акт";
			this.toolStripButton_17.Click += this.toolStripButton_17_Click;
			this.toolStripSeparator_1.Name = "toolStripSeparator1";
			this.toolStripSeparator_1.Size = new Size(6, 25);
			this.toolStripSplitButton_1.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripSplitButton_1.DropDownItems.AddRange(new ToolStripItem[]
			{
				this.toolStripMenuItem_2,
				this.toolStripMenuItem_3
			});
			this.toolStripSplitButton_1.Image = (Image)componentResourceManager.GetObject("toolBtnAddActWithoutObj.Image");
			this.toolStripSplitButton_1.ImageTransparentColor = Color.Magenta;
			this.toolStripSplitButton_1.Name = "toolBtnAddActWithoutObj";
			this.toolStripSplitButton_1.Size = new Size(32, 22);
			this.toolStripSplitButton_1.Text = "Акт разграничения балансовой принадлежности сторон";
			this.toolStripMenuItem_2.Name = "toolBtnAddActBalanceWithoutObj";
			this.toolStripMenuItem_2.Size = new Size(422, 22);
			this.toolStripMenuItem_2.Text = "Акт разграничения балансовой принадлежности сторон";
			this.toolStripMenuItem_2.Click += this.toolStripMenuItem_2_Click;
			this.toolStripMenuItem_3.Name = "toolBtnAddActLiabilityWithoutObj";
			this.toolStripMenuItem_3.Size = new Size(422, 22);
			this.toolStripMenuItem_3.Text = "Акт разграничения эксплуатационной ответственности сторон";
			this.toolStripMenuItem_3.Click += this.toolStripMenuItem_3_Click;
			this.splitContainer_0.Dock = DockStyle.Fill;
			this.splitContainer_0.Location = new Point(0, 25);
			this.splitContainer_0.Name = "splitContainer1";
			this.splitContainer_0.Panel1.Controls.Add(this.toolStrip_4);
			this.splitContainer_0.Panel1.Controls.Add(this.treeViewSchmObjects_0);
			this.splitContainer_0.Panel1.Controls.Add(this.triStateTreeView_0);
			this.splitContainer_0.Panel1.Controls.Add(this.label_2);
			this.splitContainer_0.Panel1.Controls.Add(this.checkBox_0);
			this.splitContainer_0.Panel1.Controls.Add(this.label_0);
			this.splitContainer_0.Panel1.Controls.Add(this.label_1);
			this.splitContainer_0.Panel1.Controls.Add(this.dateTimePicker_0);
			this.splitContainer_0.Panel1.Controls.Add(this.dateTimePicker_1);
			this.splitContainer_0.Panel1.Controls.Add(this.toolStrip_1);
			this.splitContainer_0.Panel1MinSize = 188;
			this.splitContainer_0.Panel2.Controls.Add(this.splitContainer_1);
			this.splitContainer_0.Size = new Size(979, 497);
			this.splitContainer_0.SplitterDistance = 188;
			this.splitContainer_0.TabIndex = 2;
			this.splitContainer_0.SplitterMoved += this.splitContainer_0_SplitterMoved;
			this.toolStrip_4.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.toolStrip_4.AutoSize = false;
			this.toolStrip_4.Dock = DockStyle.None;
			this.toolStrip_4.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripButton_13,
				this.toolStripTextBox_1,
				this.toolStripButton_14,
				this.toolStripButton_15
			});
			this.toolStrip_4.Location = new Point(0, 254);
			this.toolStrip_4.Name = "toolStripFindSubs";
			this.toolStrip_4.Size = new Size(187, 25);
			this.toolStrip_4.TabIndex = 15;
			this.toolStripButton_13.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_13.Image = Resources.Find;
			this.toolStripButton_13.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_13.Name = "toolSubsBtnFind";
			this.toolStripButton_13.Size = new Size(23, 22);
			this.toolStripButton_13.Text = "Поиск";
			this.toolStripButton_13.Click += this.toolStripButton_13_Click;
			this.toolStripTextBox_1.BorderStyle = BorderStyle.FixedSingle;
			this.toolStripTextBox_1.Name = "toolSubsTxtFind";
			this.toolStripTextBox_1.Size = new Size(85, 25);
			this.toolStripTextBox_1.KeyPress += this.treeViewSchmObjects_0_KeyPress;
			this.toolStripButton_14.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_14.Image = Resources.FindPrev;
			this.toolStripButton_14.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_14.Name = "toolSubsBtnFindBack";
			this.toolStripButton_14.Size = new Size(23, 22);
			this.toolStripButton_14.Text = "Поиск назад";
			this.toolStripButton_14.Click += this.toolStripButton_14_Click;
			this.toolStripButton_15.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_15.Image = Resources.FindNext;
			this.toolStripButton_15.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_15.Name = "toolSubsFindNext";
			this.toolStripButton_15.Size = new Size(23, 22);
			this.toolStripButton_15.Text = "Поиск вперед";
			this.toolStripButton_15.Click += this.toolStripButton_15_Click;
			this.treeViewSchmObjects_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.treeViewSchmObjects_0.CheckBoxes = true;
			this.treeViewSchmObjects_0.HideSelection = false;
			this.treeViewSchmObjects_0.Location = new Point(7, 282);
			this.treeViewSchmObjects_0.Name = "treeViewSchmObj";
			this.treeViewSchmObjects_0.Size = new Size(175, 187);
			this.treeViewSchmObjects_0.SqlSettings = null;
			this.treeViewSchmObjects_0.TabIndex = 14;
			this.treeViewSchmObjects_0.BeforeExpand += this.treeViewSchmObjects_0_BeforeExpand;
			this.treeViewSchmObjects_0.KeyPress += this.treeViewSchmObjects_0_KeyPress;
			this.triStateTreeView_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.triStateTreeView_0.Location = new Point(7, 131);
			this.triStateTreeView_0.Name = "treeViewAct";
			this.triStateTreeView_0.Size = new Size(175, 120);
			this.triStateTreeView_0.TabIndex = 13;
			this.label_2.AutoSize = true;
			this.label_2.Location = new Point(12, 115);
			this.label_2.Name = "label3";
			this.label_2.Size = new Size(33, 13);
			this.label_2.TabIndex = 11;
			this.label_2.Text = "Акты";
			this.checkBox_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.checkBox_0.AutoSize = true;
			this.checkBox_0.Location = new Point(7, 475);
			this.checkBox_0.Name = "chBoxFilterSub";
			this.checkBox_0.Size = new Size(180, 17);
			this.checkBox_0.TabIndex = 10;
			this.checkBox_0.Text = "Фильтровать по подстанциям";
			this.checkBox_0.UseVisualStyleBackColor = true;
			this.label_0.AutoSize = true;
			this.label_0.Location = new Point(12, 72);
			this.label_0.Name = "label2";
			this.label_0.Size = new Size(89, 13);
			this.label_0.TabIndex = 6;
			this.label_0.Text = "Дата окончания";
			this.label_1.AutoSize = true;
			this.label_1.Location = new Point(12, 30);
			this.label_1.Name = "label1";
			this.label_1.Size = new Size(71, 13);
			this.label_1.TabIndex = 5;
			this.label_1.Text = "Дата начала";
			this.dateTimePicker_0.Location = new Point(7, 88);
			this.dateTimePicker_0.Name = "dtpEnd";
			this.dateTimePicker_0.Size = new Size(175, 20);
			this.dateTimePicker_0.TabIndex = 2;
			this.dateTimePicker_0.ValueChanged += this.dateTimePicker_0_ValueChanged;
			this.dateTimePicker_1.Location = new Point(7, 46);
			this.dateTimePicker_1.Margin = new Padding(7, 3, 7, 3);
			this.dateTimePicker_1.Name = "dtpBegin";
			this.dateTimePicker_1.Size = new Size(175, 20);
			this.dateTimePicker_1.TabIndex = 1;
			this.dateTimePicker_1.ValueChanged += this.dateTimePicker_1_ValueChanged;
			this.toolStrip_1.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripButton_0,
				this.toolStripButton_1,
				this.toolStripButton_2,
				this.toolStripButton_3,
				this.toolStripSeparator_0,
				this.toolStripButton_9
			});
			this.toolStrip_1.Location = new Point(0, 0);
			this.toolStrip_1.Name = "toolStripFilter";
			this.toolStrip_1.Size = new Size(188, 25);
			this.toolStrip_1.TabIndex = 0;
			this.toolStripButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_0.Image = Resources.filter;
			this.toolStripButton_0.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_0.Name = "toolBtnAddFilter";
			this.toolStripButton_0.Size = new Size(23, 22);
			this.toolStripButton_0.Text = "Применить фильтр";
			this.toolStripButton_0.Click += this.toolStripButton_0_Click;
			this.toolStripButton_1.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_1.Image = Resources.filter_delete;
			this.toolStripButton_1.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_1.Name = "toolBtnDelFilter";
			this.toolStripButton_1.Size = new Size(23, 22);
			this.toolStripButton_1.Text = "Сбросить фильтр";
			this.toolStripButton_1.Click += this.toolStripButton_1_Click;
			this.toolStripButton_2.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_2.Image = Resources.Bitmap_2;
			this.toolStripButton_2.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_2.Name = "toolBtnPreviousYear";
			this.toolStripButton_2.Size = new Size(23, 22);
			this.toolStripButton_2.Text = "Предыдущий год";
			this.toolStripButton_2.Click += this.toolStripButton_2_Click;
			this.toolStripButton_3.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_3.Image = Resources.Bitmap_1;
			this.toolStripButton_3.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_3.Name = "toolBtnNextYear";
			this.toolStripButton_3.Size = new Size(23, 22);
			this.toolStripButton_3.Text = "Следующий год";
			this.toolStripButton_3.Click += this.toolStripButton_3_Click;
			this.toolStripSeparator_0.Name = "toolStripSeparator2";
			this.toolStripSeparator_0.Size = new Size(6, 25);
			this.toolStripButton_9.CheckOnClick = true;
			this.toolStripButton_9.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_9.Image = Resources.Trash;
			this.toolStripButton_9.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_9.Name = "toolBtnShowDelAct";
			this.toolStripButton_9.Size = new Size(23, 22);
			this.toolStripButton_9.Text = "Показать удаленные документы";
			this.toolStripButton_9.CheckedChanged += this.toolStripButton_9_CheckedChanged;
			this.splitContainer_1.Dock = DockStyle.Fill;
			this.splitContainer_1.Location = new Point(0, 0);
			this.splitContainer_1.Name = "splitContainer2";
			this.splitContainer_1.Orientation = Orientation.Horizontal;
			this.splitContainer_1.Panel1.Controls.Add(this.dataGridViewExcelFilter_0);
			this.splitContainer_1.Panel2.Controls.Add(this.oSySwegtED);
			this.splitContainer_1.Panel2.Controls.Add(this.toolStrip_2);
			this.splitContainer_1.Size = new Size(787, 497);
			this.splitContainer_1.SplitterDistance = 337;
			this.splitContainer_1.TabIndex = 0;
			this.dataGridViewExcelFilter_0.AllowUserToAddRows = false;
			this.dataGridViewExcelFilter_0.AllowUserToDeleteRows = false;
			this.dataGridViewExcelFilter_0.AutoGenerateColumns = false;
			this.dataGridViewExcelFilter_0.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
			this.dataGridViewExcelFilter_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewExcelFilter_0.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewTextBoxColumn_15,
				this.dataGridViewTextBoxColumn_16,
				this.dataGridViewTextBoxColumn_17,
				this.dataGridViewTextBoxColumn_18,
				this.dataGridViewTextBoxColumn_19,
				this.dataGridViewTextBoxColumn_20,
				this.dataGridViewFilterTextBoxColumn_10,
				this.dataGridViewFilterTextBoxColumn_11,
				this.dataGridViewFilterTextBoxColumn_12,
				this.dataGridViewFilterTextBoxColumn_13,
				this.dataGridViewFilterTextBoxColumn_14,
				this.dataGridViewFilterTextBoxColumn_15,
				this.dataGridViewFilterTextBoxColumn_16,
				this.dataGridViewFilterTextBoxColumn_17,
				this.dataGridViewFilterCheckBoxColumn_0
			});
			this.dataGridViewExcelFilter_0.DataSource = this.bindingSource_0;
			this.dataGridViewExcelFilter_0.Dock = DockStyle.Fill;
			this.dataGridViewExcelFilter_0.Location = new Point(0, 0);
			this.dataGridViewExcelFilter_0.Name = "dgvAct";
			this.dataGridViewExcelFilter_0.ReadOnly = true;
			this.dataGridViewExcelFilter_0.RowHeadersWidth = 21;
			this.dataGridViewExcelFilter_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewExcelFilter_0.Size = new Size(787, 337);
			this.dataGridViewExcelFilter_0.TabIndex = 0;
			this.dataGridViewExcelFilter_0.CellContentDoubleClick += this.dataGridViewExcelFilter_0_CellContentDoubleClick;
			this.dataGridViewExcelFilter_0.CellFormatting += this.dataGridViewExcelFilter_0_CellFormatting;
			this.dataGridViewTextBoxColumn_15.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_15.HeaderText = "id";
			this.dataGridViewTextBoxColumn_15.Name = "idDgvColumn";
			this.dataGridViewTextBoxColumn_15.ReadOnly = true;
			this.dataGridViewTextBoxColumn_15.Visible = false;
			this.dataGridViewTextBoxColumn_16.DataPropertyName = "idList";
			this.dataGridViewTextBoxColumn_16.HeaderText = "idList";
			this.dataGridViewTextBoxColumn_16.Name = "idListDgvColumn";
			this.dataGridViewTextBoxColumn_16.ReadOnly = true;
			this.dataGridViewTextBoxColumn_16.Visible = false;
			this.dataGridViewTextBoxColumn_17.DataPropertyName = "idAbn";
			this.dataGridViewTextBoxColumn_17.HeaderText = "idAbn";
			this.dataGridViewTextBoxColumn_17.Name = "idAbnDgvColumn";
			this.dataGridViewTextBoxColumn_17.ReadOnly = true;
			this.dataGridViewTextBoxColumn_17.Visible = false;
			this.dataGridViewTextBoxColumn_18.DataPropertyName = "idAbnObj";
			this.dataGridViewTextBoxColumn_18.HeaderText = "idAbnObj";
			this.dataGridViewTextBoxColumn_18.Name = "idAbnObjDgvColumn";
			this.dataGridViewTextBoxColumn_18.ReadOnly = true;
			this.dataGridViewTextBoxColumn_18.Visible = false;
			this.dataGridViewTextBoxColumn_19.DataPropertyName = "Data";
			this.dataGridViewTextBoxColumn_19.HeaderText = "Data";
			this.dataGridViewTextBoxColumn_19.Name = "dataDgvColumn";
			this.dataGridViewTextBoxColumn_19.ReadOnly = true;
			this.dataGridViewTextBoxColumn_19.Visible = false;
			this.dataGridViewTextBoxColumn_20.DataPropertyName = "deleted";
			this.dataGridViewTextBoxColumn_20.HeaderText = "deleted";
			this.dataGridViewTextBoxColumn_20.Name = "deletedDgvColumn";
			this.dataGridViewTextBoxColumn_20.ReadOnly = true;
			this.dataGridViewTextBoxColumn_20.Visible = false;
			this.dataGridViewFilterTextBoxColumn_10.DataPropertyName = "TypeDoc";
			this.dataGridViewFilterTextBoxColumn_10.HeaderText = "Тип документа";
			this.dataGridViewFilterTextBoxColumn_10.Name = "typeDocDgvColumn";
			this.dataGridViewFilterTextBoxColumn_10.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_10.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_10.Width = 150;
			this.dataGridViewFilterTextBoxColumn_11.DataPropertyName = "StationList";
			dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_11.DefaultCellStyle = dataGridViewCellStyle;
			this.dataGridViewFilterTextBoxColumn_11.HeaderText = "Электроустановки";
			this.dataGridViewFilterTextBoxColumn_11.Name = "stationListDgvColumn";
			this.dataGridViewFilterTextBoxColumn_11.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_11.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_11.Width = 150;
			this.dataGridViewFilterTextBoxColumn_12.DataPropertyName = "CodeAbonent";
			this.dataGridViewFilterTextBoxColumn_12.HeaderText = "Код";
			this.dataGridViewFilterTextBoxColumn_12.Name = "codeAbonentDgvColumn";
			this.dataGridViewFilterTextBoxColumn_12.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_12.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_12.Width = 60;
			this.dataGridViewFilterTextBoxColumn_13.DataPropertyName = "Name";
			this.dataGridViewFilterTextBoxColumn_13.HeaderText = "Потребитель";
			this.dataGridViewFilterTextBoxColumn_13.Name = "nameDgvColumn";
			this.dataGridViewFilterTextBoxColumn_13.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_13.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_13.Width = 260;
			this.dataGridViewFilterTextBoxColumn_14.DataPropertyName = "ObjName";
			this.dataGridViewFilterTextBoxColumn_14.HeaderText = "Объект";
			this.dataGridViewFilterTextBoxColumn_14.Name = "objNameDgvColumn";
			this.dataGridViewFilterTextBoxColumn_14.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_14.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_14.Width = 250;
			this.dataGridViewFilterTextBoxColumn_15.DataPropertyName = "ActNumber";
			this.dataGridViewFilterTextBoxColumn_15.HeaderText = "Номер";
			this.dataGridViewFilterTextBoxColumn_15.Name = "actNumberDgvColumn";
			this.dataGridViewFilterTextBoxColumn_15.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_15.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_15.Width = 65;
			this.dataGridViewFilterTextBoxColumn_16.DataPropertyName = "ActDate";
			this.dataGridViewFilterTextBoxColumn_16.HeaderText = "Дата";
			this.dataGridViewFilterTextBoxColumn_16.Name = "actDateDgvColumn";
			this.dataGridViewFilterTextBoxColumn_16.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_16.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_16.Width = 85;
			this.dataGridViewFilterTextBoxColumn_17.DataPropertyName = "ActRegion";
			this.dataGridViewFilterTextBoxColumn_17.HeaderText = "Район";
			this.dataGridViewFilterTextBoxColumn_17.Name = "actRegionDgvColumn";
			this.dataGridViewFilterTextBoxColumn_17.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_17.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_17.Width = 120;
			this.dataGridViewFilterCheckBoxColumn_0.DataPropertyName = "isActive";
			this.dataGridViewFilterCheckBoxColumn_0.HeaderText = "Активный";
			this.dataGridViewFilterCheckBoxColumn_0.Name = "isActiveDgvColumn";
			this.dataGridViewFilterCheckBoxColumn_0.ReadOnly = true;
			this.dataGridViewFilterCheckBoxColumn_0.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterCheckBoxColumn_0.Width = 75;
			this.bindingSource_0.DataMember = "vActBalance";
			this.bindingSource_0.DataSource = this.dataSetAbnObjAct_0;
			this.bindingSource_0.CurrentChanged += this.bindingSource_0_CurrentChanged;
			this.dataSetAbnObjAct_0.DataSetName = "DataSetAbnObjAct";
			this.dataSetAbnObjAct_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
			this.oSySwegtED.AllowUserToAddRows = false;
			this.oSySwegtED.AllowUserToDeleteRows = false;
			this.oSySwegtED.AllowUserToResizeRows = false;
			this.oSySwegtED.AutoGenerateColumns = false;
			this.oSySwegtED.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.oSySwegtED.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewImageColumnNotNull_0,
				this.dataGridViewFilterTextBoxColumn_9,
				this.dataGridViewTextBoxColumn_11,
				this.dataGridViewTextBoxColumn_12,
				this.dataGridViewTextBoxColumn_13,
				this.dataGridViewTextBoxColumn_14
			});
			this.oSySwegtED.DataSource = this.bindingSource_1;
			this.oSySwegtED.Dock = DockStyle.Fill;
			this.oSySwegtED.Location = new Point(0, 25);
			this.oSySwegtED.Name = "dgvFile";
			this.oSySwegtED.ReadOnly = true;
			this.oSySwegtED.RowHeadersWidth = 21;
			this.oSySwegtED.Size = new Size(787, 131);
			this.oSySwegtED.TabIndex = 1;
			this.oSySwegtED.CellDoubleClick += this.oSySwegtED_CellDoubleClick;
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
			this.dataGridViewImageColumnNotNull_0.DefaultCellStyle = dataGridViewCellStyle2;
			this.dataGridViewImageColumnNotNull_0.HeaderText = "";
			this.dataGridViewImageColumnNotNull_0.ImageLayout = DataGridViewImageCellLayout.Zoom;
			this.dataGridViewImageColumnNotNull_0.Name = "fileDataGridViewImageColumn";
			this.dataGridViewImageColumnNotNull_0.ReadOnly = true;
			this.dataGridViewImageColumnNotNull_0.Visible = false;
			this.dataGridViewImageColumnNotNull_0.Width = 30;
			this.dataGridViewFilterTextBoxColumn_9.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewFilterTextBoxColumn_9.DataPropertyName = "FileName";
			this.dataGridViewFilterTextBoxColumn_9.HeaderText = "Файл";
			this.dataGridViewFilterTextBoxColumn_9.Name = "fileNameDgvColumn";
			this.dataGridViewFilterTextBoxColumn_9.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_9.Resizable = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_11.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_11.HeaderText = "id";
			this.dataGridViewTextBoxColumn_11.Name = "idDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_11.ReadOnly = true;
			this.dataGridViewTextBoxColumn_11.Visible = false;
			this.dataGridViewTextBoxColumn_12.DataPropertyName = "idList";
			this.dataGridViewTextBoxColumn_12.HeaderText = "idList";
			this.dataGridViewTextBoxColumn_12.Name = "idListDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_12.ReadOnly = true;
			this.dataGridViewTextBoxColumn_12.Visible = false;
			this.dataGridViewTextBoxColumn_13.DataPropertyName = "dateChange";
			this.dataGridViewTextBoxColumn_13.HeaderText = "dateChange";
			this.dataGridViewTextBoxColumn_13.Name = "dateChangeDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_13.ReadOnly = true;
			this.dataGridViewTextBoxColumn_13.Visible = false;
			this.dataGridViewTextBoxColumn_14.DataPropertyName = "idTemplate";
			this.dataGridViewTextBoxColumn_14.HeaderText = "idTemplate";
			this.dataGridViewTextBoxColumn_14.Name = "idTemplateDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_14.ReadOnly = true;
			this.dataGridViewTextBoxColumn_14.Visible = false;
			this.bindingSource_1.DataMember = "tAbnObjDoc_File";
			this.bindingSource_1.DataSource = this.dataSetAbnObjAct_0;
			this.toolStrip_2.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripButton_4,
				this.toolStripButton_5
			});
			this.toolStrip_2.Location = new Point(0, 0);
			this.toolStrip_2.Name = "toolStripFile";
			this.toolStrip_2.Size = new Size(787, 25);
			this.toolStrip_2.TabIndex = 0;
			this.toolStrip_2.Text = "toolStrip2";
			this.toolStripButton_4.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_4.Image = Resources.ElementInformation;
			this.toolStripButton_4.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_4.Name = "toolBtnViewFile";
			this.toolStripButton_4.Size = new Size(23, 22);
			this.toolStripButton_4.Text = "Просмотр файла";
			this.toolStripButton_4.Click += this.toolStripButton_4_Click;
			this.toolStripButton_5.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_5.Image = Resources.floppy_black;
			this.toolStripButton_5.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_5.Name = "toolBtnSaveToDisk";
			this.toolStripButton_5.Size = new Size(23, 22);
			this.toolStripButton_5.Text = "Сохранить файл на диск";
			this.toolStripButton_5.Click += this.toolStripButton_5_Click;
			this.dataGridViewTextBoxColumn_0.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_0.HeaderText = "id";
			this.dataGridViewTextBoxColumn_0.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_0.Visible = false;
			this.dataGridViewTextBoxColumn_1.DataPropertyName = "idList";
			this.dataGridViewTextBoxColumn_1.HeaderText = "idList";
			this.dataGridViewTextBoxColumn_1.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn_1.Visible = false;
			this.dataGridViewTextBoxColumn_2.DataPropertyName = "idAbn";
			this.dataGridViewTextBoxColumn_2.HeaderText = "idAbn";
			this.dataGridViewTextBoxColumn_2.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn_2.Visible = false;
			this.dataGridViewTextBoxColumn_3.DataPropertyName = "idAbnObj";
			this.dataGridViewTextBoxColumn_3.HeaderText = "idAbnObj";
			this.dataGridViewTextBoxColumn_3.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn_3.Visible = false;
			this.dataGridViewTextBoxColumn_4.DataPropertyName = "Data";
			this.dataGridViewTextBoxColumn_4.HeaderText = "Data";
			this.dataGridViewTextBoxColumn_4.Name = "dataGridViewTextBoxColumn5";
			this.dataGridViewTextBoxColumn_4.Visible = false;
			this.dataGridViewTextBoxColumn_5.DataPropertyName = "isActive";
			this.dataGridViewTextBoxColumn_5.HeaderText = "isActive";
			this.dataGridViewTextBoxColumn_5.Name = "dataGridViewTextBoxColumn6";
			this.dataGridViewTextBoxColumn_5.Visible = false;
			this.dataGridViewTextBoxColumn_6.DataPropertyName = "deleted";
			this.dataGridViewTextBoxColumn_6.HeaderText = "deleted";
			this.dataGridViewTextBoxColumn_6.Name = "dataGridViewTextBoxColumn7";
			this.dataGridViewTextBoxColumn_6.Visible = false;
			this.dataGridViewFilterTextBoxColumn_0.DataPropertyName = "TypeDoc";
			this.dataGridViewFilterTextBoxColumn_0.HeaderText = "Тип документа";
			this.dataGridViewFilterTextBoxColumn_0.Name = "dataGridViewFilterTextBoxColumn1";
			this.dataGridViewFilterTextBoxColumn_0.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_0.Width = 130;
			this.dataGridViewFilterTextBoxColumn_1.DataPropertyName = "StationList";
			this.dataGridViewFilterTextBoxColumn_1.HeaderText = "Подстанция";
			this.dataGridViewFilterTextBoxColumn_1.Name = "dataGridViewFilterTextBoxColumn2";
			this.dataGridViewFilterTextBoxColumn_1.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_2.DataPropertyName = "CodeAbonent";
			this.dataGridViewFilterTextBoxColumn_2.HeaderText = "Код";
			this.dataGridViewFilterTextBoxColumn_2.Name = "dataGridViewFilterTextBoxColumn3";
			this.dataGridViewFilterTextBoxColumn_2.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_2.Width = 60;
			this.dataGridViewFilterTextBoxColumn_3.DataPropertyName = "Name";
			this.dataGridViewFilterTextBoxColumn_3.HeaderText = "Потребитель";
			this.dataGridViewFilterTextBoxColumn_3.Name = "dataGridViewFilterTextBoxColumn4";
			this.dataGridViewFilterTextBoxColumn_3.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_3.Width = 260;
			this.dataGridViewFilterTextBoxColumn_4.DataPropertyName = "ObjName";
			this.dataGridViewFilterTextBoxColumn_4.HeaderText = "Объект";
			this.dataGridViewFilterTextBoxColumn_4.Name = "dataGridViewFilterTextBoxColumn5";
			this.dataGridViewFilterTextBoxColumn_4.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_4.Width = 320;
			this.dataGridViewFilterTextBoxColumn_5.DataPropertyName = "ActNumber";
			this.dataGridViewFilterTextBoxColumn_5.HeaderText = "Номер";
			this.dataGridViewFilterTextBoxColumn_5.Name = "dataGridViewFilterTextBoxColumn6";
			this.dataGridViewFilterTextBoxColumn_5.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_5.Width = 65;
			this.dataGridViewFilterTextBoxColumn_6.DataPropertyName = "ActDate";
			this.dataGridViewFilterTextBoxColumn_6.HeaderText = "Дата";
			this.dataGridViewFilterTextBoxColumn_6.Name = "dataGridViewFilterTextBoxColumn7";
			this.dataGridViewFilterTextBoxColumn_6.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_6.Width = 85;
			this.dataGridViewFilterTextBoxColumn_7.DataPropertyName = "ActRegion";
			this.dataGridViewFilterTextBoxColumn_7.HeaderText = "Район";
			this.dataGridViewFilterTextBoxColumn_7.Name = "dataGridViewFilterTextBoxColumn8";
			this.dataGridViewFilterTextBoxColumn_7.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_7.Width = 75;
			this.dataGridViewTextBoxColumn_7.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_7.HeaderText = "id";
			this.dataGridViewTextBoxColumn_7.Name = "dataGridViewTextBoxColumn8";
			this.dataGridViewTextBoxColumn_7.Visible = false;
			this.dataGridViewTextBoxColumn_8.DataPropertyName = "idList";
			this.dataGridViewTextBoxColumn_8.HeaderText = "idList";
			this.dataGridViewTextBoxColumn_8.Name = "dataGridViewTextBoxColumn9";
			this.dataGridViewTextBoxColumn_8.Visible = false;
			this.dataGridViewFilterTextBoxColumn_8.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewFilterTextBoxColumn_8.DataPropertyName = "FileName";
			this.dataGridViewFilterTextBoxColumn_8.HeaderText = "Файл";
			this.dataGridViewFilterTextBoxColumn_8.Name = "dataGridViewFilterTextBoxColumn9";
			this.dataGridViewFilterTextBoxColumn_8.Resizable = DataGridViewTriState.True;
			this.dataGridViewImageColumn_0.DataPropertyName = "File";
			this.dataGridViewImageColumn_0.HeaderText = "File";
			this.dataGridViewImageColumn_0.Name = "dataGridViewImageColumn1";
			this.dataGridViewImageColumn_0.Visible = false;
			this.dataGridViewTextBoxColumn_9.DataPropertyName = "dateChange";
			this.dataGridViewTextBoxColumn_9.HeaderText = "dateChange";
			this.dataGridViewTextBoxColumn_9.Name = "dataGridViewTextBoxColumn10";
			this.dataGridViewTextBoxColumn_9.Visible = false;
			this.dataGridViewTextBoxColumn_10.DataPropertyName = "idTemplate";
			this.dataGridViewTextBoxColumn_10.HeaderText = "idTemplate";
			this.dataGridViewTextBoxColumn_10.Name = "dataGridViewTextBoxColumn11";
			this.dataGridViewTextBoxColumn_10.Visible = false;
			this.toolStrip_3.Dock = DockStyle.None;
			this.toolStrip_3.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripButton_10,
				this.toolStripTextBox_0,
				this.toolStripButton_11,
				this.toolStripButton_12,
				this.toolStripButton_18
			});
			this.toolStrip_3.Location = new Point(213, 0);
			this.toolStrip_3.Name = "toolStripFind";
			this.toolStrip_3.Size = new Size(256, 25);
			this.toolStrip_3.TabIndex = 3;
			this.toolStripButton_10.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_10.Image = Resources.Find;
			this.toolStripButton_10.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_10.Name = "toolBtnFind";
			this.toolStripButton_10.Size = new Size(23, 22);
			this.toolStripButton_10.Text = "Поиск";
			this.toolStripButton_10.Click += this.toolStripButton_10_Click;
			this.toolStripTextBox_0.BorderStyle = BorderStyle.FixedSingle;
			this.toolStripTextBox_0.Name = "toolTxtFind";
			this.toolStripTextBox_0.Size = new Size(150, 25);
			this.toolStripTextBox_0.KeyPress += this.toolStripTextBox_0_KeyPress;
			this.toolStripButton_11.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_11.Image = Resources.FindPrev;
			this.toolStripButton_11.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_11.Name = "toolBtnFindBack";
			this.toolStripButton_11.Size = new Size(23, 22);
			this.toolStripButton_11.Text = "Поиск назад";
			this.toolStripButton_11.Click += this.toolStripButton_11_Click;
			this.toolStripButton_12.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_12.Image = Resources.FindNext;
			this.toolStripButton_12.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_12.Name = "toolBtnFindNext";
			this.toolStripButton_12.Size = new Size(23, 22);
			this.toolStripButton_12.Text = "Поиск вперед";
			this.toolStripButton_12.Click += this.toolStripButton_12_Click;
			this.toolStripSeparator_2.Name = "toolStripSeparator3";
			this.toolStripSeparator_2.Size = new Size(6, 25);
			this.toolStripButton_18.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_18.Image = Resources.microsoftoffice2007excel_7581;
			this.toolStripButton_18.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_18.Name = "toolBtnExpExcel";
			this.toolStripButton_18.Size = new Size(23, 22);
			this.toolStripButton_18.Text = "Экспорт в Excel";
			this.toolStripButton_18.Click += this.toolStripButton_18_Click;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(979, 522);
			base.Controls.Add(this.toolStrip_3);
			base.Controls.Add(this.splitContainer_0);
			base.Controls.Add(this.toolStrip_0);
			this.MinimumSize = new Size(450, 280);
			base.Name = "FormJournalActRBP";
			this.Text = "Реестр актов разграничения балансовой принадлежности";
			base.Load += this.FormJournalActRBP_Load;
			base.SizeChanged += this.FormJournalActRBP_SizeChanged;
			this.toolStrip_0.ResumeLayout(false);
			this.toolStrip_0.PerformLayout();
			this.splitContainer_0.Panel1.ResumeLayout(false);
			this.splitContainer_0.Panel1.PerformLayout();
			this.splitContainer_0.Panel2.ResumeLayout(false);
			this.splitContainer_0.ResumeLayout(false);
			this.toolStrip_4.ResumeLayout(false);
			this.toolStrip_4.PerformLayout();
			this.toolStrip_1.ResumeLayout(false);
			this.toolStrip_1.PerformLayout();
			this.splitContainer_1.Panel1.ResumeLayout(false);
			this.splitContainer_1.Panel2.ResumeLayout(false);
			this.splitContainer_1.Panel2.PerformLayout();
			this.splitContainer_1.ResumeLayout(false);
			((ISupportInitialize)this.dataGridViewExcelFilter_0).EndInit();
			((ISupportInitialize)this.bindingSource_0).EndInit();
			((ISupportInitialize)this.dataSetAbnObjAct_0).EndInit();
			((ISupportInitialize)this.oSySwegtED).EndInit();
			((ISupportInitialize)this.bindingSource_1).EndInit();
			this.toolStrip_2.ResumeLayout(false);
			this.toolStrip_2.PerformLayout();
			this.toolStrip_3.ResumeLayout(false);
			this.toolStrip_3.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		[CompilerGenerated]
		private void method_16()
		{
			this.bindingSource_1.ResetBindings(false);
		}

		[CompilerGenerated]
		private void method_17()
		{
			this.bindingSource_1.ResetBindings(false);
		}

		public int IDLIST;

		public int ABNSELECT;

		public int OBJSELECT;

		public static FormJournalActRBP instance;

		private List<int> list_0;

		private Dictionary<string, FileWatcherArgsAddl> dictionary_0;

		private ToolStrip toolStrip_0;

		private SplitContainer splitContainer_0;

		private ToolStrip toolStrip_1;

		private ToolStripButton toolStripButton_0;

		private ToolStripButton toolStripButton_1;

		private ToolStripButton toolStripButton_2;

		private ToolStripButton toolStripButton_3;

		private SplitContainer splitContainer_1;

		private ToolStrip toolStrip_2;

		private ToolStripSplitButton toolStripSplitButton_0;

		private ToolStripMenuItem toolStripMenuItem_0;

		private ToolStripMenuItem toolStripMenuItem_1;

		private ToolStripButton toolStripButton_4;

		private ToolStripButton toolStripButton_5;

		private ToolStripButton toolStripButton_6;

		private ToolStripButton toolStripButton_7;

		private ToolStripButton toolStripButton_8;

		private DataGridView oSySwegtED;

		private DateTimePicker dateTimePicker_0;

		private DateTimePicker dateTimePicker_1;

		private Label label_0;

		private Label label_1;

		private BindingSource bindingSource_0;

		private BindingSource bindingSource_1;

		private DataSetAbnObjAct dataSetAbnObjAct_0;

		private CheckBox checkBox_0;

		private Label label_2;

		private TriStateTreeView triStateTreeView_0;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_3;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_4;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_5;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_6;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_0;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_1;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_2;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_3;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_4;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_5;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_6;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_7;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_7;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_8;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_8;

		private DataGridViewImageColumn dataGridViewImageColumn_0;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_9;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_10;

		private DataGridViewImageColumnNotNull dataGridViewImageColumnNotNull_0;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_9;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_11;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_12;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_13;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_14;

		private TreeViewSchmObjects treeViewSchmObjects_0;

		private ToolStripButton toolStripButton_9;

		private ToolStripSeparator toolStripSeparator_0;

		private DataGridViewExcelFilter dataGridViewExcelFilter_0;

		private ToolStrip toolStrip_3;

		private ToolStripButton toolStripButton_10;

		private ToolStripTextBox toolStripTextBox_0;

		private ToolStripButton toolStripButton_11;

		private ToolStripButton toolStripButton_12;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_15;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_16;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_17;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_18;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_19;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_20;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_10;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_11;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_12;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_13;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_14;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_15;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_16;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_17;

		private DataGridViewFilterCheckBoxColumn dataGridViewFilterCheckBoxColumn_0;

		private ToolStrip toolStrip_4;

		private ToolStripButton toolStripButton_13;

		private ToolStripTextBox toolStripTextBox_1;

		private ToolStripButton toolStripButton_14;

		private ToolStripButton toolStripButton_15;

		private ToolStripButton toolStripButton_16;

		private ToolStripButton toolStripButton_17;

		private ToolStripSeparator toolStripSeparator_1;

		private ToolStripSplitButton toolStripSplitButton_1;

		private ToolStripMenuItem toolStripMenuItem_2;

		private ToolStripMenuItem toolStripMenuItem_3;

		private ToolStripSeparator toolStripSeparator_2;

		private ToolStripButton toolStripButton_18;

		private enum Enum3
		{

		}
	}
}
