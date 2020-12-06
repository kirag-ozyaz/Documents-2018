using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ControlsLbr.DataGridViewExcelFilter;
using DataSql;
using Documents.Properties;
using FormLbr;

namespace Documents.Forms.JournalRelayProtectionAutomation
{
	public partial class FormJournalRelayProtectionAutomation : FormBase
	{
		public FormJournalRelayProtectionAutomation()
		{
			
			
			this.method_5();
			this.toolStripButton_9.Visible = false;
		}

		public FormJournalRelayProtectionAutomation(int selSubstation)
		{
			
			
			this.method_5();
			this.nullable_0 = new int?(selSubstation);
			this.toolStripButton_9.Visible = false;
		}

		private void FormJournalRelayProtectionAutomation_Load(object sender, EventArgs e)
		{
			this.method_0();
		}

		private void method_0()
		{
			Class469 @class = new Class469();
			base.SelectSqlData(@class, @class.tR_Classifier, true, " where ParentKey = ';SCM;PS;' and isgroup = 0 and deleted = 0 order by name");
			this.treeView_0.BeginUpdate();
			TreeNode treeNode = this.treeView_0.Nodes.Add("Все объекты");
			this.treeView_0.SelectedNode = treeNode;
			foreach (object obj in @class.tR_Classifier.Rows)
			{
				DataRow dataRow = (DataRow)obj;
				TreeNode treeNode2 = treeNode.Nodes.Add(dataRow["SocrName"].ToString());
				treeNode2.Tag = dataRow["id"];
				base.SelectSqlData(@class, @class.vSchm_ObjList, true, " where typeCodeId = " + dataRow["id"].ToString() + " and deleted = 0 order by name");
				foreach (DataRow dataRow2 in @class.vSchm_ObjList)
				{
					string str = "";
					TreeNode treeNode3 = treeNode2.Nodes.Add(dataRow2["typeCodeSocr"].ToString() + "-" + dataRow2["Name"].ToString() + str);
					treeNode3.Tag = dataRow2["id"];
					if (this.nullable_0 != null && Convert.ToInt32(dataRow2["id"]) == this.nullable_0.Value)
					{
						this.treeView_0.SelectedNode = treeNode3;
					}
					treeNode3.Nodes.Add("");
				}
			}
			this.treeView_0.EndUpdate();
			treeNode.Expand();
		}

		private void treeView_0_BeforeExpand(object sender, TreeViewCancelEventArgs e)
		{
			if (e.Node.Nodes.Count > 0 && e.Node.Level > 1)
			{
				e.Node.Nodes.Clear();
				int level = e.Node.Level;
				Class469 @class;
				if (level != 2)
				{
					if (level != 3)
					{
						return;
					}
					@class = new Class469();
					base.SelectSqlData(@class, @class.vSchm_TreeCellLine, true, " where ParentLink = " + e.Node.Tag.ToString());
					using (IEnumerator<Class469.Class496> enumerator = @class.vSchm_TreeCellLine.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							DataRow dataRow = enumerator.Current;
							string str = "";
							TreeNode treeNode = e.Node.Nodes.Add(dataRow["FullName"].ToString() + str);
							treeNode.Tag = dataRow["id"];
							treeNode.Nodes.Add("");
						}
						return;
					}
				}
				@class = new Class469();
				base.SelectSqlData(@class, @class.tR_Classifier, true, " where ParentKey in (';SCM;BUS;BUSHV;', ';SCM;BUS;BUSMV;') and deleted = 0 and isgroup = 0 ");
				string text = "";
				foreach (object obj in @class.tR_Classifier.Rows)
				{
					DataRow dataRow2 = (DataRow)obj;
					text = text + dataRow2["id"].ToString() + ",";
				}
				text = text.Remove(text.Length - 1);
				base.SelectSqlData(@class, @class.vSchm_ObjList, true, string.Concat(new string[]
				{
					" where idParent = ",
					e.Node.Tag.ToString(),
					" and typecodeId in (",
					text,
					") and deleted = 0"
				}));
				foreach (DataRow dataRow3 in @class.vSchm_ObjList)
				{
					string str2 = "";
					TreeNode treeNode2 = e.Node.Nodes.Add(dataRow3["TypeCodeSocr"].ToString() + " - " + dataRow3["Name"].ToString() + str2);
					treeNode2.Tag = dataRow3["id"];
					treeNode2.Nodes.Add("");
				}
			}
		}

		private void toolStripButton_0_Click(object sender, EventArgs e)
		{
			List<TreeNode> list_ = new List<TreeNode>();
			list_ = this.method_1(this.treeView_0.Nodes, list_);
			TreeNode treeNode = this.method_2(list_, this.treeView_0.SelectedNode, this.toolStripTextBox_0.Text, (FormJournalRelayProtectionAutomation.Enum17)0);
			if (treeNode != null)
			{
				this.treeView_0.SelectedNode = treeNode;
				this.treeView_0.SelectedNode.Expand();
			}
		}

		private void toolStripButton_1_Click(object sender, EventArgs e)
		{
			List<TreeNode> list_ = new List<TreeNode>();
			list_ = this.method_1(this.treeView_0.Nodes, list_);
			TreeNode treeNode = this.method_2(list_, this.treeView_0.SelectedNode, this.toolStripTextBox_0.Text, (FormJournalRelayProtectionAutomation.Enum17)2);
			if (treeNode != null)
			{
				this.treeView_0.SelectedNode = treeNode;
				this.treeView_0.SelectedNode.Expand();
			}
		}

		private void toolStripButton_2_Click(object sender, EventArgs e)
		{
			List<TreeNode> list_ = new List<TreeNode>();
			list_ = this.method_1(this.treeView_0.Nodes, list_);
			TreeNode treeNode = this.method_2(list_, this.treeView_0.SelectedNode, this.toolStripTextBox_0.Text, (FormJournalRelayProtectionAutomation.Enum17)1);
			if (treeNode != null)
			{
				this.treeView_0.SelectedNode = treeNode;
				this.treeView_0.SelectedNode.Expand();
			}
		}

		private void toolStripTextBox_0_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				Keys modifiers = e.Modifiers;
				if (modifiers == Keys.None)
				{
					this.toolStripButton_2_Click(sender, e);
					return;
				}
				if (modifiers != Keys.Shift)
				{
					return;
				}
				this.toolStripButton_1_Click(sender, e);
			}
		}

		private List<TreeNode> method_1(TreeNodeCollection treeNodeCollection_0, List<TreeNode> list_0)
		{
			foreach (object obj in treeNodeCollection_0)
			{
				TreeNode treeNode = (TreeNode)obj;
				list_0.Add(treeNode);
				list_0 = this.method_1(treeNode.Nodes, list_0);
			}
			return list_0;
		}

		private TreeNode method_2(List<TreeNode> list_0, TreeNode treeNode_0, string string_0, FormJournalRelayProtectionAutomation.Enum17 enum17_0)
		{
			bool flag = enum17_0 == (FormJournalRelayProtectionAutomation.Enum17)0;
			if (enum17_0 == (FormJournalRelayProtectionAutomation.Enum17)2)
			{
				list_0.Reverse();
			}
			foreach (TreeNode treeNode in list_0)
			{
				if (flag && treeNode.Text.ToUpper().Contains(string_0.ToUpper()))
				{
					return treeNode;
				}
				if (treeNode == treeNode_0)
				{
					flag = true;
				}
			}
			return null;
		}

		private void treeView_0_AfterSelect(object sender, TreeViewEventArgs e)
		{
			this.method_3();
		}

		private void method_3()
		{
			int num = -1;
			if (this.dataGridViewExcelFilter_0.CurrentRow != null)
			{
				num = Convert.ToInt32(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_0.Name].Value);
			}
			string text;
			if (this.toolStripButton_8.Checked)
			{
				text = " deleted in (0,1) ";
			}
			else
			{
				text = string.Concat(new string[]
				{
					" (deleted = ",
					Convert.ToInt32(this.toolStripButton_8.Checked).ToString(),
					" and deletedObj = ",
					Convert.ToInt32(this.toolStripButton_8.Checked).ToString(),
					") "
				});
			}
			switch (this.treeView_0.SelectedNode.Level)
			{
			case 0:
				base.SelectSqlData(this.class255_0, this.class255_0.vJ_RelayProtectionAutomation, true, " where " + text + " order by Sub_name, bus_name, cell_name");
				break;
			case 1:
				base.SelectSqlData(this.class255_0, this.class255_0.vJ_RelayProtectionAutomation, true, string.Concat(new string[]
				{
					" where TypeSub = ",
					this.treeView_0.SelectedNode.Tag.ToString(),
					" and ",
					text,
					" order by Sub_name, bus_name, cell_name"
				}));
				break;
			case 2:
				base.SelectSqlData(this.class255_0, this.class255_0.vJ_RelayProtectionAutomation, true, string.Concat(new string[]
				{
					" where subId = ",
					this.treeView_0.SelectedNode.Tag.ToString(),
					" and ",
					text,
					" order by Sub_name, bus_name, cell_name"
				}));
				break;
			case 3:
				base.SelectSqlData(this.class255_0, this.class255_0.vJ_RelayProtectionAutomation, true, string.Concat(new string[]
				{
					" where busId = ",
					this.treeView_0.SelectedNode.Tag.ToString(),
					" and ",
					text,
					" order by Sub_name, bus_name, cell_name"
				}));
				break;
			case 4:
				base.SelectSqlData(this.class255_0, this.class255_0.vJ_RelayProtectionAutomation, true, string.Concat(new string[]
				{
					" where cellId = ",
					this.treeView_0.SelectedNode.Tag.ToString(),
					" and ",
					text,
					" order by Sub_name, bus_name, cell_name"
				}));
				break;
			}
			if (num > 0)
			{
				this.dataGridViewExcelFilter_0.SearchGrid(this.dataGridViewTextBoxColumn_0.Name, num.ToString(), false);
			}
		}

		private void toolStripButton_3_Click(object sender, EventArgs e)
		{
			int int_ = -1;
			int int_2 = -1;
			int int_3 = -1;
			int int_4 = -1;
			if (this.treeView_0.SelectedNode != null)
			{
				switch (this.treeView_0.SelectedNode.Level)
				{
				case 1:
					int_ = Convert.ToInt32(this.treeView_0.SelectedNode.Tag);
					break;
				case 2:
					int_2 = Convert.ToInt32(this.treeView_0.SelectedNode.Tag);
					int_ = Convert.ToInt32(this.treeView_0.SelectedNode.Parent.Tag);
					break;
				case 3:
					int_3 = Convert.ToInt32(this.treeView_0.SelectedNode.Tag);
					int_2 = Convert.ToInt32(this.treeView_0.SelectedNode.Parent.Tag);
					int_ = Convert.ToInt32(this.treeView_0.SelectedNode.Parent.Parent.Tag);
					break;
				case 4:
					int_4 = Convert.ToInt32(this.treeView_0.SelectedNode.Tag);
					int_3 = Convert.ToInt32(this.treeView_0.SelectedNode.Parent.Tag);
					int_2 = Convert.ToInt32(this.treeView_0.SelectedNode.Parent.Parent.Tag);
					int_ = Convert.ToInt32(this.treeView_0.SelectedNode.Parent.Parent.Parent.Tag);
					break;
				}
			}
			Form58 form = new Form58(int_, int_2, int_3, int_4, -1, -1);
			form.SqlSettings = this.SqlSettings;
			form.MdiParent = base.MdiParent;
			form.FormClosed += this.method_4;
			form.Show();
		}

		private void method_4(object sender, FormClosedEventArgs e)
		{
			if (((Form)sender).DialogResult == DialogResult.OK)
			{
				this.method_3();
			}
		}

		private void toolStripButton_5_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_0.CurrentRow != null)
			{
				if (Convert.ToBoolean(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewCheckBoxColumn_4.Name].Value))
				{
					MessageBox.Show("Данный объект удален из схемы. Редактирование уставки РЗиА невозможно. ");
					return;
				}
				int int_ = Convert.ToInt32(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_4.Name].Value);
				int int_2 = Convert.ToInt32(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_2.Name].Value);
				int int_3 = Convert.ToInt32(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_5.Name].Value);
				int int_4 = Convert.ToInt32(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_9.Name].Value);
				int int_5 = Convert.ToInt32(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_0.Name].Value);
				Form58 form = new Form58(int_, int_2, int_3, int_4, int_5, -1);
				form.SqlSettings = this.SqlSettings;
				form.MdiParent = base.MdiParent;
				form.FormClosed += this.method_4;
				form.Show();
			}
		}

		private void toolStripButton_4_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_0.CurrentRow != null)
			{
				if (Convert.ToBoolean(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewCheckBoxColumn_4.Name].Value))
				{
					MessageBox.Show("Данный объект удален из схемы. Редактирование уставки РЗиА невозможно. ");
					return;
				}
				int int_ = Convert.ToInt32(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_4.Name].Value);
				int int_2 = Convert.ToInt32(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_2.Name].Value);
				int int_3 = Convert.ToInt32(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_5.Name].Value);
				int int_4 = Convert.ToInt32(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_9.Name].Value);
				int int_5 = Convert.ToInt32(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_0.Name].Value);
				int int_6 = Convert.ToInt32(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_1.Name].Value);
				Form58 form = new Form58(int_, int_2, int_3, int_4, int_5, int_6);
				form.SqlSettings = this.SqlSettings;
				form.MdiParent = base.MdiParent;
				form.FormClosed += this.method_4;
				form.Show();
			}
		}

		private void toolStripButton_11_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_0.CurrentRow != null)
			{
				try
				{
					int int_ = Convert.ToInt32(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_4.Name].Value);
					int int_2 = Convert.ToInt32(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_2.Name].Value);
					int int_3 = Convert.ToInt32(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_5.Name].Value);
					int int_4 = Convert.ToInt32(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_9.Name].Value);
					int int_5 = Convert.ToInt32(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_0.Name].Value);
					int int_6 = Convert.ToInt32(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_1.Name].Value);
					Form58 form = new Form58(int_, int_2, int_3, int_4, int_5, int_6, true);
					form.SqlSettings = this.SqlSettings;
					form.MdiParent = base.MdiParent;
					form.FormClosed += this.method_4;
					form.Show();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, ex.Source);
				}
			}
		}

		private void dataGridViewExcelFilter_0_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (this.toolStripButton_4.Enabled && this.toolStripButton_4.Visible)
			{
				this.toolStripButton_4_Click(sender, e);
				return;
			}
			this.toolStripButton_11_Click(sender, e);
		}

		private void toolStripButton_6_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_0.CurrentRow != null && MessageBox.Show("Вы действиетльно хотите удалить выделенную уставку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				int num = Convert.ToInt32(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_0.Name].Value);
				base.SelectSqlData(this.class255_0, this.class255_0.tJ_RelayProtectionAutomation, true, " where id = " + num.ToString());
				if (this.class255_0.tJ_RelayProtectionAutomation.Rows.Count >= 0)
				{
					this.class255_0.tJ_RelayProtectionAutomation.Rows[0]["deleted"] = true;
					this.class255_0.tJ_RelayProtectionAutomation.Rows[0].EndEdit();
					base.UpdateSqlData(this.class255_0, this.class255_0.tJ_RelayProtectionAutomation);
					MessageBox.Show("Уставка успешно удалена", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					this.method_3();
					return;
				}
				MessageBox.Show("Нету записи для удаления", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void toolStripButton_10_Click(object sender, EventArgs e)
		{
			this.method_3();
		}

		private void dataGridViewExcelFilter_0_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				if (Convert.ToBoolean(this.dataGridViewExcelFilter_0[this.dataGridViewCheckBoxColumn_3.Name, e.RowIndex].Value))
				{
					e.CellStyle.ForeColor = Color.Red;
				}
				if (Convert.ToBoolean(this.dataGridViewExcelFilter_0[this.dataGridViewCheckBoxColumn_4.Name, e.RowIndex].Value))
				{
					e.CellStyle.ForeColor = Color.Red;
					e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold | FontStyle.Italic);
				}
			}
		}

		private void toolStripButton_7_Click(object sender, EventArgs e)
		{
			if (!this.toolStripButton_7.Checked)
			{
				this.toolStripButton_7.Text = "Показать дерево объектов";
				this.splitContainer_0.Panel1Collapsed = true;
				return;
			}
			this.toolStripButton_7.Text = "Скрыть дерево объектов";
			this.splitContainer_0.Panel1Collapsed = false;
		}

		private void toolStripButton_8_Click(object sender, EventArgs e)
		{
			if (this.toolStripButton_8.Checked)
			{
				this.toolStripButton_8.Text = "Скрыть удаленные уставки";
			}
			else
			{
				this.toolStripButton_8.Text = "Показать удаленные уставки";
			}
			this.method_3();
		}

		private void toolStripButton_9_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Удалить существующие уставки?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				base.SelectSqlData(this.class255_0, this.class255_0.tJ_RelayProtectionAutomation, true);
				foreach (Class255.Class374 @class in this.class255_0.tJ_RelayProtectionAutomation)
				{
					@class["deleted"] = true;
					@class.EndEdit();
				}
				base.UpdateSqlData(this.class255_0, this.class255_0.tJ_RelayProtectionAutomation);
			}
			DataTable dataTable = new SqlDataCommand(new SQLSettings("ulges-sql", "PTS", "WINDOWS", "", "")).SelectSqlData("RZA", false, "", null);
			Class469 class2 = new Class469();
			base.SelectSqlData(class2, class2.vSchm_ObjList, true, "where typecodeid in (535,536,537,538, 674,675,676)");
			List<string> list = new List<string>();
			List<string> list2 = new List<string>();
			base.SelectSqlData(class2, class2.tR_Classifier, true, " where isGRoup = 0 and ParentKey in (';TypeTransformatorAmperage;')");
			foreach (object obj in dataTable.Rows)
			{
				DataRow dataRow = (DataRow)obj;
				string text = dataRow["ps"].ToString();
				if (text.Trim() == "ПС УЛЬЯНОВСКАЯ - 110/6 кВ")
				{
					text = "ПС УЛЬЯНОВСКАЯ Новое ЗРУ-6кВ";
				}
				DataRow[] array = class2.vSchm_ObjList.Select("TypeCodeId in (535,536,537,538) and name = '" + text + "'");
				if (array.Length != 0)
				{
					DataRow[] array2 = class2.vSchm_ObjList.Select(" TypeCodeId in (674,675,676) and name = '" + dataRow["cell"].ToString() + "' and idParent = " + array[0]["id"].ToString());
					if (array2.Length != 0)
					{
						int num = Convert.ToInt32(array2[0]["id"]);
						if (array2.Length > 1)
						{
							array2 = class2.vSchm_ObjList.Select(string.Concat(new string[]
							{
								" TypeCodeId in (674,675,676) and name = '",
								dataRow["cell"].ToString(),
								"' and idParent = ",
								array[0]["id"].ToString(),
								" and deleted = 0"
							}));
							if (array2.Length != 0)
							{
								num = Convert.ToInt32(array2[0]["id"]);
							}
						}
						this.class255_0.tJ_RelayProtectionAutomation.Clear();
						DataRow dataRow2 = this.class255_0.tJ_RelayProtectionAutomation.NewRow();
						dataRow2["idSChmObj"] = num;
						dataRow2["name"] = dataRow["cell_note"].ToString().Trim();
						dataRow2["deleted"] = false;
						this.class255_0.tJ_RelayProtectionAutomation.Rows.Add(dataRow2);
						int num2 = base.InsertSqlDataOneRow(this.class255_0, this.class255_0.tJ_RelayProtectionAutomation);
						this.class255_0.tJ_RelayProtectionAutomationValue.Clear();
						dataRow2 = this.class255_0.tJ_RelayProtectionAutomationValue.NewRow();
						if (dataRow["trr_type"] != DBNull.Value)
						{
							string text2 = dataRow["trr_type"].ToString().Trim();
							if (text2 == "ТВЛМ10")
							{
								text2 = "ТВЛМ-10";
							}
							if (text2 == "ТПЛ_10")
							{
								text2 = "ТПЛ-10";
							}
							if (text2 == "ТЛК10")
							{
								text2 = "ТЛК-10";
							}
							DataRow[] array3 = class2.tR_Classifier.Select(" PArentKey = ';TypeTransformatorAmperage;' and name = '" + text2 + "'");
							if (array3.Length != 0)
							{
								dataRow2["idTypeTR"] = array3[0]["id"];
							}
							else
							{
								MessageBox.Show(text2);
							}
						}
						dataRow2["amp_primary"] = dataRow["trr_kf"];
						dataRow2["amp_secondary"] = dataRow["trr_kf1"];
						dataRow2["amp_mtz"] = dataRow["i_mtz_max"];
						dataRow2["time_mtz"] = dataRow["t_mtz"];
						dataRow2["amp_to"] = dataRow["i_to"];
						dataRow2["time_to"] = dataRow["t_to"];
						dataRow2["amp_ozz"] = dataRow["i_ozz"];
						dataRow2["time_ozz"] = dataRow["t_ozz"];
						dataRow2["type_relay"] = dataRow["device_type1"].ToString().Trim();
						dataRow2["type_proc"] = dataRow["device_type2"].ToString().Trim();
						dataRow2["cp"] = dataRow["cp"].ToString().Trim();
						dataRow2["cp_cell"] = dataRow["cp_cell"].ToString().Trim();
						dataRow2["comment"] = dataRow["note"].ToString().Trim();
						dataRow2["idRelay"] = num2;
						dataRow2["dateCreate"] = DateTime.Now;
						dataRow2["DateIn"] = new DateTime(2012, 1, 1);
						dataRow2["deleted"] = false;
						this.class255_0.tJ_RelayProtectionAutomationValue.Rows.Add(dataRow2);
						base.InsertSqlDataOneRow(this.class255_0, this.class255_0.tJ_RelayProtectionAutomationValue);
					}
					else
					{
						list2.Add(dataRow["ps"].ToString() + " ячейка - " + dataRow["cell"].ToString());
					}
				}
				else if (!list.Contains(dataRow["ps"].ToString()))
				{
					list.Add(dataRow["ps"].ToString());
				}
			}
			string str = "";
			foreach (string str2 in list)
			{
				str = str + str2 + "\n";
			}
			foreach (string str3 in list2)
			{
				str = str + str3 + "\n";
			}
			File.WriteAllLines("RZANoFind.txt", list.ToArray());
			list2.Sort();
			File.WriteAllLines("RZANoFind.txt", list2.ToArray());
			this.method_3();
			MessageBox.Show("ОК");
		}

		private void toolStripButton_12_Click(object sender, EventArgs e)
		{
			new Form57
			{
				SqlSettings = this.SqlSettings,
				MdiParent = base.MdiParent
			}.Show();
		}

		private void method_5()
		{
			this.icontainer_0 = new Container();
			DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FormJournalRelayProtectionAutomation));
			this.toolStrip_0 = new ToolStrip();
			this.toolStripButton_3 = new ToolStripButton();
			this.toolStripButton_6 = new ToolStripButton();
			this.toolStripSeparator_1 = new ToolStripSeparator();
			this.toolStripButton_10 = new ToolStripButton();
			this.toolStripSeparator_0 = new ToolStripSeparator();
			this.toolStripButton_7 = new ToolStripButton();
			this.toolStripButton_8 = new ToolStripButton();
			this.toolStripButton_9 = new ToolStripButton();
			this.toolStripSeparator_2 = new ToolStripSeparator();
			this.toolStripButton_12 = new ToolStripButton();
			this.toolStripButton_4 = new ToolStripButton();
			this.splitContainer_0 = new SplitContainer();
			this.treeView_0 = new TreeView();
			this.toolStrip_1 = new ToolStrip();
			this.toolStripButton_0 = new ToolStripButton();
			this.toolStripTextBox_0 = new ToolStripTextBox();
			this.toolStripButton_1 = new ToolStripButton();
			this.toolStripButton_2 = new ToolStripButton();
			this.dataGridViewExcelFilter_0 = new DataGridViewExcelFilter();
			this.toolStrip_2 = new ToolStrip();
			this.toolStripButton_5 = new ToolStripButton();
			this.toolStripButton_11 = new ToolStripButton();
			this.bindingSource_0 = new BindingSource(this.icontainer_0);
			this.class255_0 = new Class255();
			this.dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_3 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_4 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_5 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_6 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_7 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_8 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_9 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_10 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_11 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_12 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_13 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_14 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_15 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_16 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_17 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_18 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_19 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_20 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_21 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_22 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_23 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_24 = new DataGridViewTextBoxColumn();
			this.dataGridViewCheckBoxColumn_0 = new DataGridViewCheckBoxColumn();
			this.dataGridViewCheckBoxColumn_1 = new DataGridViewCheckBoxColumn();
			this.dataGridViewCheckBoxColumn_2 = new DataGridViewCheckBoxColumn();
			this.dataGridViewTextBoxColumn_25 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_26 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_27 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_28 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_29 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_30 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_31 = new DataGridViewTextBoxColumn();
			this.dataGridViewCheckBoxColumn_3 = new DataGridViewCheckBoxColumn();
			this.dataGridViewCheckBoxColumn_4 = new DataGridViewCheckBoxColumn();
			this.toolStrip_0.SuspendLayout();
			this.splitContainer_0.Panel1.SuspendLayout();
			this.splitContainer_0.Panel2.SuspendLayout();
			this.splitContainer_0.SuspendLayout();
			this.toolStrip_1.SuspendLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_0).BeginInit();
			this.toolStrip_2.SuspendLayout();
			((ISupportInitialize)this.bindingSource_0).BeginInit();
			((ISupportInitialize)this.class255_0).BeginInit();
			base.SuspendLayout();
			this.toolStrip_0.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripButton_3,
				this.toolStripButton_6,
				this.toolStripSeparator_1,
				this.toolStripButton_10,
				this.toolStripSeparator_0,
				this.toolStripButton_7,
				this.toolStripButton_8,
				this.toolStripButton_9,
				this.toolStripSeparator_2,
				this.toolStripButton_12
			});
			this.toolStrip_0.Location = new Point(0, 0);
			this.toolStrip_0.Name = "toolStripMain";
			this.toolStrip_0.Size = new Size(1090, 25);
			this.toolStrip_0.TabIndex = 0;
			this.toolStrip_0.Text = "toolStrip1";
			this.toolStripButton_3.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_3.Image = Resources.ElementAdd;
			this.toolStripButton_3.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_3.Name = "toolBtnAdd";
			this.toolStripButton_3.Size = new Size(23, 22);
			this.toolStripButton_3.Text = "Новая уставка";
			this.toolStripButton_3.Click += this.toolStripButton_3_Click;
			this.toolStripButton_6.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_6.Image = Resources.ElementDel;
			this.toolStripButton_6.ImageTransparentColor = Color.Transparent;
			this.toolStripButton_6.Name = "toolBtnDel";
			this.toolStripButton_6.Size = new Size(23, 22);
			this.toolStripButton_6.Text = "Удалить уставку";
			this.toolStripButton_6.Click += this.toolStripButton_6_Click;
			this.toolStripSeparator_1.Name = "toolStripSeparator2";
			this.toolStripSeparator_1.Size = new Size(6, 25);
			this.toolStripButton_10.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_10.Image = Resources.refresh_16;
			this.toolStripButton_10.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_10.Name = "toolBtnRefresh";
			this.toolStripButton_10.Size = new Size(23, 22);
			this.toolStripButton_10.Text = "Обновить";
			this.toolStripButton_10.Click += this.toolStripButton_10_Click;
			this.toolStripSeparator_0.Name = "toolStripSeparator1";
			this.toolStripSeparator_0.Size = new Size(6, 25);
			this.toolStripButton_7.Checked = true;
			this.toolStripButton_7.CheckOnClick = true;
			this.toolStripButton_7.CheckState = CheckState.Checked;
			this.toolStripButton_7.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_7.Image = Resources.Tree3;
			this.toolStripButton_7.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_7.Name = "toolBtnShowTree";
			this.toolStripButton_7.Size = new Size(23, 22);
			this.toolStripButton_7.Text = "Скрыть дерево объектов";
			this.toolStripButton_7.Click += this.toolStripButton_7_Click;
			this.toolStripButton_8.CheckOnClick = true;
			this.toolStripButton_8.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_8.Image = Resources.Trash;
			this.toolStripButton_8.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_8.Name = "toolBrnShowDel";
			this.toolStripButton_8.Size = new Size(23, 22);
			this.toolStripButton_8.Text = "Показать удаленные уставки";
			this.toolStripButton_8.Click += this.toolStripButton_8_Click;
			this.toolStripButton_9.Alignment = ToolStripItemAlignment.Right;
			this.toolStripButton_9.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_9.Image = Resources.ElementGo;
			this.toolStripButton_9.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_9.Name = "toolBTnImportOldBase";
			this.toolStripButton_9.Size = new Size(23, 22);
			this.toolStripButton_9.Text = "Загрузить из старой базы";
			this.toolStripButton_9.Click += this.toolStripButton_9_Click;
			this.toolStripSeparator_2.Name = "toolStripSeparator3";
			this.toolStripSeparator_2.Size = new Size(6, 25);
			this.toolStripButton_12.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_12.Image = Resources.report;
			this.toolStripButton_12.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_12.Name = "toolBtnReport";
			this.toolStripButton_12.Size = new Size(23, 22);
			this.toolStripButton_12.Text = "Отчет";
			this.toolStripButton_12.Click += this.toolStripButton_12_Click;
			this.toolStripButton_4.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_4.Image = Resources.ElementEdit;
			this.toolStripButton_4.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_4.Name = "toolBtnEditValue";
			this.toolStripButton_4.Size = new Size(23, 22);
			this.toolStripButton_4.Text = "Редактировать";
			this.toolStripButton_4.Click += this.toolStripButton_4_Click;
			this.splitContainer_0.Dock = DockStyle.Fill;
			this.splitContainer_0.FixedPanel = FixedPanel.Panel1;
			this.splitContainer_0.Location = new Point(0, 25);
			this.splitContainer_0.Name = "splitContainer";
			this.splitContainer_0.Panel1.Controls.Add(this.treeView_0);
			this.splitContainer_0.Panel1.Controls.Add(this.toolStrip_1);
			this.splitContainer_0.Panel2.Controls.Add(this.dataGridViewExcelFilter_0);
			this.splitContainer_0.Panel2.Controls.Add(this.toolStrip_2);
			this.splitContainer_0.Size = new Size(1090, 549);
			this.splitContainer_0.SplitterDistance = 190;
			this.splitContainer_0.TabIndex = 1;
			this.treeView_0.Dock = DockStyle.Fill;
			this.treeView_0.HideSelection = false;
			this.treeView_0.Location = new Point(0, 25);
			this.treeView_0.Name = "treeViewSubstation";
			this.treeView_0.Size = new Size(190, 524);
			this.treeView_0.TabIndex = 1;
			this.treeView_0.BeforeExpand += this.treeView_0_BeforeExpand;
			this.treeView_0.AfterSelect += this.treeView_0_AfterSelect;
			this.toolStrip_1.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripButton_0,
				this.toolStripTextBox_0,
				this.toolStripButton_1,
				this.toolStripButton_2
			});
			this.toolStrip_1.Location = new Point(0, 0);
			this.toolStrip_1.Name = "toolStripTree";
			this.toolStrip_1.Size = new Size(190, 25);
			this.toolStrip_1.TabIndex = 0;
			this.toolStrip_1.Text = "toolStrip1";
			this.toolStripButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_0.Image = Resources.Find;
			this.toolStripButton_0.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_0.Name = "toolBtnFindTree";
			this.toolStripButton_0.Size = new Size(23, 22);
			this.toolStripButton_0.Text = "toolStripButton1";
			this.toolStripButton_0.Click += this.toolStripButton_0_Click;
			this.toolStripTextBox_0.Name = "toolTxtFind";
			this.toolStripTextBox_0.Size = new Size(100, 25);
			this.toolStripTextBox_0.KeyDown += this.toolStripTextBox_0_KeyDown;
			this.toolStripButton_1.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_1.Image = Resources.FindPrev;
			this.toolStripButton_1.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_1.Name = "toolBtnFindPrevTree";
			this.toolStripButton_1.Size = new Size(23, 22);
			this.toolStripButton_1.Text = "toolStripButton1";
			this.toolStripButton_1.Click += this.toolStripButton_1_Click;
			this.toolStripButton_2.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_2.Image = Resources.FindNext;
			this.toolStripButton_2.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_2.Name = "toolBtnFindNextTree";
			this.toolStripButton_2.Size = new Size(23, 22);
			this.toolStripButton_2.Text = "toolStripButton2";
			this.toolStripButton_2.Click += this.toolStripButton_2_Click;
			this.dataGridViewExcelFilter_0.AllowUserToAddRows = false;
			this.dataGridViewExcelFilter_0.AllowUserToDeleteRows = false;
			this.dataGridViewExcelFilter_0.AllowUserToOrderColumns = true;
			dataGridViewCellStyle.BackColor = Color.FromArgb(224, 224, 224);
			this.dataGridViewExcelFilter_0.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle;
			this.dataGridViewExcelFilter_0.AutoGenerateColumns = false;
			this.dataGridViewExcelFilter_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewExcelFilter_0.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewTextBoxColumn_0,
				this.dataGridViewTextBoxColumn_1,
				this.dataGridViewTextBoxColumn_2,
				this.dataGridViewTextBoxColumn_3,
				this.dataGridViewTextBoxColumn_4,
				this.dataGridViewTextBoxColumn_5,
				this.dataGridViewTextBoxColumn_6,
				this.dataGridViewTextBoxColumn_7,
				this.dataGridViewTextBoxColumn_8,
				this.dataGridViewTextBoxColumn_9,
				this.dataGridViewTextBoxColumn_10,
				this.dataGridViewTextBoxColumn_11,
				this.dataGridViewTextBoxColumn_12,
				this.dataGridViewTextBoxColumn_13,
				this.dataGridViewTextBoxColumn_14,
				this.dataGridViewTextBoxColumn_15,
				this.dataGridViewTextBoxColumn_16,
				this.dataGridViewTextBoxColumn_17,
				this.dataGridViewTextBoxColumn_18,
				this.dataGridViewTextBoxColumn_19,
				this.dataGridViewTextBoxColumn_20,
				this.dataGridViewTextBoxColumn_21,
				this.dataGridViewTextBoxColumn_22,
				this.dataGridViewTextBoxColumn_23,
				this.dataGridViewTextBoxColumn_24,
				this.dataGridViewCheckBoxColumn_0,
				this.dataGridViewCheckBoxColumn_1,
				this.dataGridViewCheckBoxColumn_2,
				this.dataGridViewTextBoxColumn_25,
				this.dataGridViewTextBoxColumn_26,
				this.dataGridViewTextBoxColumn_27,
				this.dataGridViewTextBoxColumn_28,
				this.dataGridViewTextBoxColumn_29,
				this.dataGridViewTextBoxColumn_30,
				this.dataGridViewTextBoxColumn_31,
				this.dataGridViewCheckBoxColumn_3,
				this.dataGridViewCheckBoxColumn_4
			});
			this.dataGridViewExcelFilter_0.DataSource = this.bindingSource_0;
			this.dataGridViewExcelFilter_0.Dock = DockStyle.Fill;
			this.dataGridViewExcelFilter_0.Location = new Point(0, 25);
			this.dataGridViewExcelFilter_0.Name = "dgvRelay";
			this.dataGridViewExcelFilter_0.ReadOnly = true;
			this.dataGridViewExcelFilter_0.RowHeadersWidth = 21;
			this.dataGridViewExcelFilter_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewExcelFilter_0.Size = new Size(896, 524);
			this.dataGridViewExcelFilter_0.TabIndex = 0;
			this.dataGridViewExcelFilter_0.CellDoubleClick += this.dataGridViewExcelFilter_0_CellDoubleClick;
			this.dataGridViewExcelFilter_0.CellFormatting += this.dataGridViewExcelFilter_0_CellFormatting;
			this.toolStrip_2.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripButton_5,
				this.toolStripButton_4,
				this.toolStripButton_11
			});
			this.toolStrip_2.Location = new Point(0, 0);
			this.toolStrip_2.Name = "toolStripValue";
			this.toolStrip_2.Size = new Size(896, 25);
			this.toolStrip_2.TabIndex = 1;
			this.toolStrip_2.Text = "toolStrip1";
			this.toolStripButton_5.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_5.Image = Resources.ElementAdd;
			this.toolStripButton_5.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_5.Name = "toolBtnNewValue";
			this.toolStripButton_5.Size = new Size(23, 22);
			this.toolStripButton_5.Text = "Новые значения";
			this.toolStripButton_5.Click += this.toolStripButton_5_Click;
			this.toolStripButton_11.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_11.Image = Resources.ElementInformation;
			this.toolStripButton_11.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_11.Name = "toolBtnReadValue";
			this.toolStripButton_11.Size = new Size(23, 22);
			this.toolStripButton_11.Text = "Просмотр";
			this.toolStripButton_11.Click += this.toolStripButton_11_Click;
			this.bindingSource_0.DataMember = "vJ_RelayProtectionAutomation";
			this.bindingSource_0.DataSource = this.class255_0;
			this.class255_0.DataSetName = "DataSetGES";
			this.class255_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
			this.dataGridViewTextBoxColumn_0.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_0.HeaderText = "id";
			this.dataGridViewTextBoxColumn_0.Name = "idDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_0.ReadOnly = true;
			this.dataGridViewTextBoxColumn_0.Visible = false;
			this.dataGridViewTextBoxColumn_1.DataPropertyName = "relayidValue";
			this.dataGridViewTextBoxColumn_1.HeaderText = "relayidValue";
			this.dataGridViewTextBoxColumn_1.Name = "relayidValueDgvTxtColumn";
			this.dataGridViewTextBoxColumn_1.ReadOnly = true;
			this.dataGridViewTextBoxColumn_1.Visible = false;
			this.dataGridViewTextBoxColumn_2.DataPropertyName = "subId";
			this.dataGridViewTextBoxColumn_2.HeaderText = "subId";
			this.dataGridViewTextBoxColumn_2.Name = "subIdDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_2.ReadOnly = true;
			this.dataGridViewTextBoxColumn_2.Visible = false;
			this.dataGridViewTextBoxColumn_3.DataPropertyName = "sub_Name";
			this.dataGridViewTextBoxColumn_3.HeaderText = "Подстанция";
			this.dataGridViewTextBoxColumn_3.Name = "subNameDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_3.ReadOnly = true;
			this.dataGridViewTextBoxColumn_3.Width = 80;
			this.dataGridViewTextBoxColumn_4.DataPropertyName = "typeSub";
			this.dataGridViewTextBoxColumn_4.HeaderText = "typeSub";
			this.dataGridViewTextBoxColumn_4.Name = "typeSubDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_4.ReadOnly = true;
			this.dataGridViewTextBoxColumn_4.Visible = false;
			this.dataGridViewTextBoxColumn_5.DataPropertyName = "busID";
			this.dataGridViewTextBoxColumn_5.HeaderText = "busID";
			this.dataGridViewTextBoxColumn_5.Name = "busIDDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_5.ReadOnly = true;
			this.dataGridViewTextBoxColumn_5.Visible = false;
			this.dataGridViewTextBoxColumn_6.DataPropertyName = "bus_name";
			this.dataGridViewTextBoxColumn_6.HeaderText = "Шина";
			this.dataGridViewTextBoxColumn_6.Name = "busnameDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_6.ReadOnly = true;
			this.dataGridViewTextBoxColumn_6.Width = 40;
			this.dataGridViewTextBoxColumn_7.DataPropertyName = "cell_Name";
			this.dataGridViewTextBoxColumn_7.HeaderText = "Ячейка";
			this.dataGridViewTextBoxColumn_7.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_7.ReadOnly = true;
			this.dataGridViewTextBoxColumn_7.Width = 50;
			this.dataGridViewTextBoxColumn_8.DataPropertyName = "relName";
			this.dataGridViewTextBoxColumn_8.HeaderText = "№ прогр.";
			this.dataGridViewTextBoxColumn_8.Name = "relNameDgvTxtColumn";
			this.dataGridViewTextBoxColumn_8.ReadOnly = true;
			this.dataGridViewTextBoxColumn_8.Width = 35;
			this.dataGridViewTextBoxColumn_9.DataPropertyName = "cellID";
			this.dataGridViewTextBoxColumn_9.HeaderText = "cellID";
			this.dataGridViewTextBoxColumn_9.Name = "cellIDDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_9.ReadOnly = true;
			this.dataGridViewTextBoxColumn_9.Visible = false;
			this.dataGridViewTextBoxColumn_10.DataPropertyName = "coefTR";
			this.dataGridViewTextBoxColumn_10.HeaderText = "Коэф. тр.";
			this.dataGridViewTextBoxColumn_10.Name = "coefTRDgvTxtColumn";
			this.dataGridViewTextBoxColumn_10.ReadOnly = true;
			this.dataGridViewTextBoxColumn_10.Width = 50;
			this.dataGridViewTextBoxColumn_11.DataPropertyName = "amp_primary";
			this.dataGridViewTextBoxColumn_11.HeaderText = "Ток1";
			this.dataGridViewTextBoxColumn_11.Name = "ampprimaryDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_11.ReadOnly = true;
			this.dataGridViewTextBoxColumn_11.Visible = false;
			this.dataGridViewTextBoxColumn_12.DataPropertyName = "amp_secondary";
			this.dataGridViewTextBoxColumn_12.HeaderText = "Ток2";
			this.dataGridViewTextBoxColumn_12.Name = "ampsecondaryDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_12.ReadOnly = true;
			this.dataGridViewTextBoxColumn_12.Visible = false;
			this.dataGridViewTextBoxColumn_13.DataPropertyName = "idTypeTr";
			this.dataGridViewTextBoxColumn_13.HeaderText = "idTypeTr";
			this.dataGridViewTextBoxColumn_13.Name = "idTypeTrDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_13.ReadOnly = true;
			this.dataGridViewTextBoxColumn_13.Visible = false;
			this.dataGridViewTextBoxColumn_14.DataPropertyName = "Typetr";
			this.dataGridViewTextBoxColumn_14.HeaderText = "Тип ТТ";
			this.dataGridViewTextBoxColumn_14.Name = "typetrDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_14.ReadOnly = true;
			this.dataGridViewTextBoxColumn_14.Width = 60;
			this.dataGridViewTextBoxColumn_15.DataPropertyName = "amp_mtz";
			this.dataGridViewTextBoxColumn_15.HeaderText = "МТЗ, А";
			this.dataGridViewTextBoxColumn_15.Name = "ampmtzDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_15.ReadOnly = true;
			this.dataGridViewTextBoxColumn_15.Width = 40;
			this.dataGridViewTextBoxColumn_16.DataPropertyName = "time_mtz";
			this.dataGridViewTextBoxColumn_16.HeaderText = "МТЗ, с";
			this.dataGridViewTextBoxColumn_16.Name = "timemtzDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_16.ReadOnly = true;
			this.dataGridViewTextBoxColumn_16.Width = 40;
			this.dataGridViewTextBoxColumn_17.DataPropertyName = "amp_to";
			this.dataGridViewTextBoxColumn_17.HeaderText = "ТО, А";
			this.dataGridViewTextBoxColumn_17.Name = "amptoDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_17.ReadOnly = true;
			this.dataGridViewTextBoxColumn_17.Width = 40;
			this.dataGridViewTextBoxColumn_18.DataPropertyName = "time_to";
			this.dataGridViewTextBoxColumn_18.HeaderText = "ТО, с";
			this.dataGridViewTextBoxColumn_18.Name = "timetoDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_18.ReadOnly = true;
			this.dataGridViewTextBoxColumn_18.Width = 40;
			this.dataGridViewTextBoxColumn_19.DataPropertyName = "amp_ozz";
			this.dataGridViewTextBoxColumn_19.HeaderText = "ОЗЗ, А";
			this.dataGridViewTextBoxColumn_19.Name = "ampozzDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_19.ReadOnly = true;
			this.dataGridViewTextBoxColumn_19.Width = 40;
			this.dataGridViewTextBoxColumn_20.DataPropertyName = "time_ozz";
			this.dataGridViewTextBoxColumn_20.HeaderText = "ОЗЗ, с";
			this.dataGridViewTextBoxColumn_20.Name = "timeozzDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_20.ReadOnly = true;
			this.dataGridViewTextBoxColumn_20.Width = 40;
			this.dataGridViewTextBoxColumn_21.DataPropertyName = "speed_mtz";
			this.dataGridViewTextBoxColumn_21.HeaderText = "Ускор МТЗ";
			this.dataGridViewTextBoxColumn_21.Name = "speedmtzDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_21.ReadOnly = true;
			this.dataGridViewTextBoxColumn_21.Width = 40;
			this.dataGridViewTextBoxColumn_22.DataPropertyName = "act_ozz";
			this.dataGridViewTextBoxColumn_22.HeaderText = "Действие ОЗЗ";
			this.dataGridViewTextBoxColumn_22.Name = "act_ozzDGVTxtColumn";
			this.dataGridViewTextBoxColumn_22.ReadOnly = true;
			this.dataGridViewTextBoxColumn_22.Width = 40;
			this.dataGridViewTextBoxColumn_23.DataPropertyName = "amp_urov";
			this.dataGridViewTextBoxColumn_23.HeaderText = "УРОВ, А";
			this.dataGridViewTextBoxColumn_23.Name = "ampurovDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_23.ReadOnly = true;
			this.dataGridViewTextBoxColumn_23.Width = 40;
			this.dataGridViewTextBoxColumn_24.DataPropertyName = "time_urov";
			this.dataGridViewTextBoxColumn_24.HeaderText = "УРОВ, с";
			this.dataGridViewTextBoxColumn_24.Name = "timeurovDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_24.ReadOnly = true;
			this.dataGridViewTextBoxColumn_24.Width = 40;
			this.dataGridViewCheckBoxColumn_0.DataPropertyName = "avr";
			this.dataGridViewCheckBoxColumn_0.HeaderText = "АВР";
			this.dataGridViewCheckBoxColumn_0.Name = "avrDGVTxtColumn";
			this.dataGridViewCheckBoxColumn_0.ReadOnly = true;
			this.dataGridViewCheckBoxColumn_0.Width = 30;
			this.dataGridViewCheckBoxColumn_1.DataPropertyName = "lzsh";
			this.dataGridViewCheckBoxColumn_1.HeaderText = "ЛЗШ";
			this.dataGridViewCheckBoxColumn_1.Name = "lzshDataGridViewCheckBoxColumn";
			this.dataGridViewCheckBoxColumn_1.ReadOnly = true;
			this.dataGridViewCheckBoxColumn_1.Width = 35;
			this.dataGridViewCheckBoxColumn_2.DataPropertyName = "ArcProtection";
			this.dataGridViewCheckBoxColumn_2.HeaderText = "Дугоая защита";
			this.dataGridViewCheckBoxColumn_2.Name = "ArcProtection";
			this.dataGridViewCheckBoxColumn_2.ReadOnly = true;
			this.dataGridViewCheckBoxColumn_2.Width = 50;
			this.dataGridViewTextBoxColumn_25.DataPropertyName = "type_relay";
			this.dataGridViewTextBoxColumn_25.HeaderText = "Тип реле";
			this.dataGridViewTextBoxColumn_25.Name = "typerelayDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_25.ReadOnly = true;
			this.dataGridViewTextBoxColumn_25.Width = 50;
			this.dataGridViewTextBoxColumn_26.DataPropertyName = "type_proc";
			this.dataGridViewTextBoxColumn_26.HeaderText = "Тип микропроц.";
			this.dataGridViewTextBoxColumn_26.Name = "typeprocDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_26.ReadOnly = true;
			this.dataGridViewTextBoxColumn_26.Width = 50;
			this.dataGridViewTextBoxColumn_27.DataPropertyName = "cp";
			this.dataGridViewTextBoxColumn_27.HeaderText = "Наименование присоединения";
			this.dataGridViewTextBoxColumn_27.Name = "cpDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_27.ReadOnly = true;
			this.dataGridViewTextBoxColumn_28.DataPropertyName = "cp_cell";
			this.dataGridViewTextBoxColumn_28.HeaderText = "Ячейка присоединения";
			this.dataGridViewTextBoxColumn_28.Name = "cpcellDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_28.ReadOnly = true;
			this.dataGridViewTextBoxColumn_28.Width = 40;
			this.dataGridViewTextBoxColumn_29.DataPropertyName = "comment";
			this.dataGridViewTextBoxColumn_29.HeaderText = "Примечание";
			this.dataGridViewTextBoxColumn_29.Name = "commentDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_29.ReadOnly = true;
			this.dataGridViewTextBoxColumn_30.DataPropertyName = "dateCreate";
			this.dataGridViewTextBoxColumn_30.HeaderText = "dateCreate";
			this.dataGridViewTextBoxColumn_30.Name = "dateCreateDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_30.ReadOnly = true;
			this.dataGridViewTextBoxColumn_30.Visible = false;
			this.dataGridViewTextBoxColumn_31.DataPropertyName = "dateIn";
			this.dataGridViewTextBoxColumn_31.HeaderText = "dateIn";
			this.dataGridViewTextBoxColumn_31.Name = "dateInDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_31.ReadOnly = true;
			this.dataGridViewTextBoxColumn_31.Visible = false;
			this.dataGridViewCheckBoxColumn_3.DataPropertyName = "deleted";
			this.dataGridViewCheckBoxColumn_3.HeaderText = "deleted";
			this.dataGridViewCheckBoxColumn_3.Name = "deletedDataGridViewCheckBoxColumn";
			this.dataGridViewCheckBoxColumn_3.ReadOnly = true;
			this.dataGridViewCheckBoxColumn_3.Visible = false;
			this.dataGridViewCheckBoxColumn_4.DataPropertyName = "deletedObj";
			this.dataGridViewCheckBoxColumn_4.HeaderText = "deletedObj";
			this.dataGridViewCheckBoxColumn_4.Name = "deletedObjDgvColumn";
			this.dataGridViewCheckBoxColumn_4.ReadOnly = true;
			this.dataGridViewCheckBoxColumn_4.Visible = false;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(1090, 574);
			base.Controls.Add(this.splitContainer_0);
			base.Controls.Add(this.toolStrip_0);
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "FormJournalRelayProtectionAutomation";
			this.Text = "Уставки РЗА";
			base.Load += this.FormJournalRelayProtectionAutomation_Load;
			this.toolStrip_0.ResumeLayout(false);
			this.toolStrip_0.PerformLayout();
			this.splitContainer_0.Panel1.ResumeLayout(false);
			this.splitContainer_0.Panel1.PerformLayout();
			this.splitContainer_0.Panel2.ResumeLayout(false);
			this.splitContainer_0.Panel2.PerformLayout();
			this.splitContainer_0.ResumeLayout(false);
			this.toolStrip_1.ResumeLayout(false);
			this.toolStrip_1.PerformLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_0).EndInit();
			this.toolStrip_2.ResumeLayout(false);
			this.toolStrip_2.PerformLayout();
			((ISupportInitialize)this.bindingSource_0).EndInit();
			((ISupportInitialize)this.class255_0).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private int? nullable_0;

		private ToolStrip toolStrip_0;

		private SplitContainer splitContainer_0;

		private TreeView treeView_0;

		private ToolStrip toolStrip_1;

		private ToolStripButton toolStripButton_0;

		private ToolStripTextBox toolStripTextBox_0;

		private ToolStripButton toolStripButton_1;

		private ToolStripButton toolStripButton_2;

		private Class255 class255_0;

		private DataGridViewExcelFilter dataGridViewExcelFilter_0;

		private BindingSource bindingSource_0;

		private ToolStripButton toolStripButton_3;

		private ToolStripButton toolStripButton_4;

		private ToolStrip toolStrip_2;

		private ToolStripButton toolStripButton_5;

		private ToolStripButton toolStripButton_6;

		private ToolStripSeparator toolStripSeparator_0;

		private ToolStripButton toolStripButton_7;

		private ToolStripButton toolStripButton_8;

		private ToolStripButton toolStripButton_9;

		private ToolStripSeparator toolStripSeparator_1;

		private ToolStripButton toolStripButton_10;

		private ToolStripButton toolStripButton_11;

		private ToolStripSeparator toolStripSeparator_2;

		private ToolStripButton toolStripButton_12;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_3;

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

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_14;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_15;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_16;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_17;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_18;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_19;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_20;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_21;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_22;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_23;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_24;

		private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn_0;

		private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn_1;

		private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn_2;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_25;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_26;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_27;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_28;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_29;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_30;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_31;

		private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn_3;

		private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn_4;

		private enum Enum17
		{

		}
	}
}
