using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Documents.Properties;
using FormLbr;
using FormLbr.Classes;
using OfficeLB.Word;
using Passport.Classes;
using Passport.Forms;
using WinFormsUI.Docking;

namespace Documents.Forms.Measurement
{
	public partial class FormMeasurement : DockContentBase
	{
		public int IdObjList
		{
			get
			{
				if (this.objList_0 == null)
				{
					return -1;
				}
				return this.objList_0.Id;
			}
			set
			{
				this.fillTree_0 = FormDockPassport.FillTree.One;
				this.int_1 = value;
			}
		}

		public FormMeasurement()
		{
			
			this.fillTree_0 = FormDockPassport.FillTree.All;
			this.int_0 = -1;
			this.typeDoc_0 = FormMeasurement.TypeDoc.None;
			
			this.method_29();
		}

		public FormMeasurement(int idObjList)
		{
			
			this.fillTree_0 = FormDockPassport.FillTree.All;
			this.int_0 = -1;
			this.typeDoc_0 = FormMeasurement.TypeDoc.None;
			
			this.method_29();
			this.fillTree_0 = FormDockPassport.FillTree.One;
			this.int_1 = idObjList;
		}

		private void dataGridView_2_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
		{
			this.method_0(this.dataGridView_2, this.dataGridView_1, e, 14, 24);
		}

		private void dataGridView_5_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
		{
			this.method_1(this.dataGridView_5, this.dataGridView_4, e, 3, 11);
		}

		private void method_0(DataGridView dataGridView_6, DataGridView dataGridView_7, DataGridViewColumnEventArgs dataGridViewColumnEventArgs_0, int int_7, int int_8)
		{
			if (this.bool_0 && dataGridViewColumnEventArgs_0.Column.Index < int_7 + 1)
			{
				int num = 0;
				foreach (object obj in this.dataGridView_2.Columns)
				{
					DataGridViewColumn dataGridViewColumn = (DataGridViewColumn)obj;
					if (dataGridViewColumn.Index < int_7 + 1 && dataGridViewColumn.Visible)
					{
						num += dataGridViewColumn.Width;
					}
				}
				dataGridView_7.Columns[0].Width = num;
			}
			if (this.bool_0 && dataGridViewColumnEventArgs_0.Column.Index > int_7 && dataGridViewColumnEventArgs_0.Column.Index < int_8)
			{
				dataGridView_7.Columns[dataGridViewColumnEventArgs_0.Column.Index - int_7].Width = dataGridViewColumnEventArgs_0.Column.Width;
			}
		}

		private void method_1(DataGridView dataGridView_6, DataGridView dataGridView_7, DataGridViewColumnEventArgs dataGridViewColumnEventArgs_0, int int_7, int int_8)
		{
			if (this.bool_0 && dataGridViewColumnEventArgs_0.Column.Index < int_7 + 1)
			{
				int num = 0;
				foreach (object obj in this.dataGridView_2.Columns)
				{
					DataGridViewColumn dataGridViewColumn = (DataGridViewColumn)obj;
					if (dataGridViewColumn.Index < int_7 + 1 && dataGridViewColumn.Visible)
					{
						num += dataGridViewColumn.Width;
					}
				}
				dataGridView_7.Columns[0].Width = num;
			}
			if (this.bool_0 && dataGridViewColumnEventArgs_0.Column.Index > int_7 && dataGridViewColumnEventArgs_0.Column.Index < int_8)
			{
				dataGridView_7.Columns[dataGridViewColumnEventArgs_0.Column.Index - int_7].Width = dataGridViewColumnEventArgs_0.Column.Width;
			}
		}

		private void dataGridView_2_Scroll(object sender, ScrollEventArgs e)
		{
			this.dataGridView_1.HorizontalScrollingOffset = this.dataGridView_2.HorizontalScrollingOffset;
		}

		private void dataGridView_5_Scroll(object sender, ScrollEventArgs e)
		{
			this.dataGridView_4.HorizontalScrollingOffset = this.dataGridView_5.HorizontalScrollingOffset;
		}

		private void method_2(FormDockPassport.Sort sort_1, FormMeasurement.TypeDoc typeDoc_2)
		{
			this.treeView_0.BeginUpdate();
			this.treeView_0.Nodes.Clear();
			this.method_4(this.treeView_0);
			DataTable source = base.SelectSqlData("vP_ObjList", true, string.Format("WHERE ParentKey = '{0}' AND Value IN ({1}) AND Deleted = ((0))", ";SCM;PS;", (this.typeDoc_1 == FormMeasurement.TypeDoc.LowMeasurement) ? "2,3,4" : "2,4,5"));
			string arg = (typeDoc_2 == FormMeasurement.TypeDoc.LowMeasurement) ? ";SCM;BUS;BUSLV;" : ((typeDoc_2 == FormMeasurement.TypeDoc.HighMeasurement) ? ";SCM;BUS;BUSMV;" : "");
			DataTable source2 = base.SelectSqlData("vP_ObjList", true, string.Format("WHERE ParentKey = '{0}' AND Tag IS NULL AND Deleted = ((0))", arg));
			using (IEnumerator<DataRow> enumerator = (from r in source.AsEnumerable()
			orderby r.Field("Name")
			select r).GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					DataRow row = enumerator.Current;
					TreeNode treeNode = new TreeNode(row["Text"].ToString());
					TreeObject treeObject = default(TreeObject);
					treeObject.TypeNode = TypeNode.Substation;
					treeObject.idSub = (int)row["Id"];
					treeNode.Name = row["TypeCodeId"].ToString();
					treeNode.Tag = treeObject;
					if ((from r in source2.AsEnumerable()
					where (int)r["IdParent"] == (int)row["Id"]
					orderby r.Field("Name")
					select r).Count<DataRow>() > 0)
					{
						TreeNode node = new TreeNode("None");
						treeNode.Nodes.Add(node);
					}
					this.treeView_0.Nodes[row["TypeCodeId"].ToString()].Nodes.Add(treeNode);
				}
			}
			this.treeView_0.EndUpdate();
		}

		private void method_3(FormDockPassport.Sort sort_1, int int_7, FormMeasurement.TypeDoc typeDoc_2)
		{
			this.treeView_0.BeginUpdate();
			this.treeView_0.Nodes.Clear();
			int idSub = (this.objList_1.GroupType == TypeObjListGroup.Buses) ? this.objList_1.IdParent : ((this.objList_1.GroupType == TypeObjListGroup.Substations) ? this.objList_1.Id : ((this.objList_1.GroupType == TypeObjListGroup.Switches) ? this.objList_1.IdParentAddl : -1));
			string arg = (typeDoc_2 == FormMeasurement.TypeDoc.LowMeasurement) ? ";SCM;BUS;BUSLV;" : ((typeDoc_2 == FormMeasurement.TypeDoc.HighMeasurement) ? ";SCM;BUS;BUSMV;" : "");
			string where = string.Format("WHERE id = {0} OR idParent = {0} AND ParentKey = '{1}' AND Tag IS NULL AND Deleted = 0", idSub, arg);
			DataTable source = base.SelectSqlData("vP_ObjList", true, where);
			EnumerableRowCollection<DataRow> source2 = source.AsEnumerable();
			Func<DataRow, bool> <>9__0;
			Func<DataRow, bool> predicate;
			if ((predicate = <>9__0) == null)
			{
				predicate = (<>9__0 = ((DataRow row) => row.Field("Id") == idSub));
			}
			using (IEnumerator<DataRow> enumerator = (from r in source2.Where(predicate)
			orderby r.Field("Name")
			select r).GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					DataRow row = enumerator.Current;
					TreeNode treeNode = new TreeNode(row["Text"].ToString());
					TreeObject treeObject = default(TreeObject);
					treeObject.TypeNode = TypeNode.Substation;
					treeObject.idSub = (int)row["Id"];
					treeNode.Name = row["TypeCodeId"].ToString();
					treeNode.Tag = treeObject;
					if ((from r in source.AsEnumerable()
					where (int)r["IdParent"] == (int)row["Id"]
					orderby r.Field("Name")
					select r).Count<DataRow>() > 0)
					{
						TreeNode node = new TreeNode("None");
						treeNode.Nodes.Add(node);
					}
					this.treeView_0.Nodes.Add(treeNode);
				}
			}
			if (this.treeView_0.Nodes.Count > 0)
			{
				this.treeView_0.SelectedNode = this.treeView_0.Nodes[0];
			}
			this.treeView_0.EndUpdate();
		}

		private void method_4(TreeView treeView_1)
		{
			foreach (object obj in base.SelectSqlData("tR_Classifier", true, string.Format("WHERE ParentKey = '{0}' AND Value IN ({1}) AND Deleted = ((0))", ";SCM;PS;", (this.typeDoc_1 == FormMeasurement.TypeDoc.LowMeasurement) ? "2,3,4" : "2,4,5")).Rows)
			{
				DataRow dataRow = (DataRow)obj;
				TreeNode treeNode = new TreeNode(dataRow["SocrName"].ToString());
				treeNode.Tag = new TreeObject
				{
					TypeNode = TypeNode.Group
				};
				treeNode.Name = dataRow["Id"].ToString();
				treeView_1.Nodes.Add(treeNode);
			}
		}

		private void toolStripButton_1_Click(object sender, EventArgs e)
		{
			List<TreeNode> list_ = new List<TreeNode>();
			list_ = this.method_5(this.treeView_0.Nodes, list_);
			TreeNode treeNode = this.method_7(list_, this.treeView_0.SelectedNode, this.toolStripTextBox_0.Text);
			if (treeNode != null)
			{
				this.treeView_0.Focus();
				this.treeView_0.SelectedNode = treeNode;
				this.treeView_0.SelectedNode.Expand();
			}
		}

		private void toolStripButton_0_Click(object sender, EventArgs e)
		{
			List<TreeNode> list_ = new List<TreeNode>();
			list_ = this.method_5(this.treeView_0.Nodes, list_);
			TreeNode treeNode = this.method_8(list_, this.toolStripTextBox_0.Text);
			if (treeNode != null)
			{
				this.treeView_0.Focus();
				this.treeView_0.SelectedNode = treeNode;
				this.treeView_0.SelectedNode.Expand();
			}
		}

		private List<TreeNode> method_5(TreeNodeCollection treeNodeCollection_0, List<TreeNode> list_0)
		{
			foreach (object obj in treeNodeCollection_0)
			{
				TreeNode treeNode = (TreeNode)obj;
				list_0.Add(treeNode);
				list_0 = this.method_5(treeNode.Nodes, list_0);
			}
			return list_0;
		}

		private List<TreeNode> method_6(TreeNodeCollection treeNodeCollection_0, List<TreeNode> list_0)
		{
			foreach (object obj in treeNodeCollection_0)
			{
				TreeNode treeNode = (TreeNode)obj;
				if (treeNode.IsExpanded)
				{
					list_0.Add(treeNode);
				}
				list_0 = this.method_6(treeNode.Nodes, list_0);
			}
			return list_0;
		}

		private TreeNode method_7(List<TreeNode> list_0, TreeNode treeNode_0, string string_2)
		{
			bool flag = false;
			foreach (TreeNode treeNode in list_0)
			{
				if (flag && treeNode.Text.ToUpper().Contains(string_2.ToUpper()))
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

		private TreeNode method_8(List<TreeNode> list_0, string string_2)
		{
			foreach (TreeNode treeNode in list_0)
			{
				if (treeNode.Text.ToUpper().Contains(string_2.ToUpper()))
				{
					return treeNode;
				}
			}
			return null;
		}

		private TreeNode method_9(List<TreeNode> list_0, int int_7)
		{
			foreach (TreeNode treeNode in list_0)
			{
				if (treeNode.Tag != null && ((TreeObject)treeNode.Tag).TypeNode == TypeNode.Substation && ((TreeObject)treeNode.Tag).idSub == int_7)
				{
					return treeNode;
				}
			}
			return null;
		}

		private bool method_10(TreeNode treeNode_0)
		{
			return treeNode_0.Nodes[0].Text == "None";
		}

		private void toolStripTextBox_0_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				List<TreeNode> list_ = new List<TreeNode>();
				list_ = this.method_5(this.treeView_0.Nodes, list_);
				TreeNode treeNode = this.method_8(list_, this.toolStripTextBox_0.Text);
				if (treeNode != null)
				{
					this.treeView_0.SelectedNode = treeNode;
					this.treeView_0.SelectedNode.Expand();
				}
			}
		}

		private void toolStripButton_2_Click(object sender, EventArgs e)
		{
			this.toolStripButton_2.Image = ((this.sort_0 == FormDockPassport.Sort.Asc) ? Resources.sortZA : Resources.sortAZ);
			this.sort_0 = ((this.sort_0 == FormDockPassport.Sort.Asc) ? FormDockPassport.Sort.Desc : FormDockPassport.Sort.Asc);
			List<TreeNode> list = new List<TreeNode>();
			this.method_6(this.treeView_0.Nodes, list);
			this.method_2(this.sort_0, this.typeDoc_1);
			List<TreeNode> list2 = new List<TreeNode>();
			this.method_5(this.treeView_0.Nodes, list2);
			using (List<TreeNode>.Enumerator enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					TreeNode node = enumerator.Current;
					IEnumerable<TreeNode> source = from n in list2
					where n.Text == node.Text || (n.Tag == node.Tag && n.Text == node.Text)
					select n;
					if (source.Count<TreeNode>() > 0)
					{
						source.First<TreeNode>().Expand();
					}
				}
			}
		}

		private void treeView_0_BeforeExpand(object sender, TreeViewCancelEventArgs e)
		{
			if (((TreeObject)e.Node.Tag).TypeNode == TypeNode.Substation)
			{
				this.treeView_0.BeginUpdate();
				e.Node.Nodes.Clear();
				string arg = (this.typeDoc_1 == FormMeasurement.TypeDoc.LowMeasurement) ? ";SCM;BUS;BUSLV;" : ((this.typeDoc_1 == FormMeasurement.TypeDoc.HighMeasurement) ? ";SCM;BUS;BUSMV;" : "");
				base.SelectSqlData(this.class255_0, this.class255_0.vJ_BusesTransfSchema, true, string.Format("WHERE idSub = {0} AND parentKeyBus = '{1}' ORDER By NameTransf", ((TreeObject)e.Node.Tag).idSub, arg));
				foreach (Class255.Class434 @class in this.class255_0.vJ_BusesTransfSchema)
				{
					TreeNode treeNode = new TreeNode();
					TreeObject treeObject = default(TreeObject);
					treeObject.TypeNode = TypeNode.Bus;
					treeObject.idSub = @class.idSub;
					treeObject.idBus = @class.idBus;
					treeObject.idTransf = @class.idTransf;
					treeObject.NameTransf = @class.NameTransf;
					treeNode.Text = @class.nameBusTransf;
					treeNode.Tag = treeObject;
					e.Node.Nodes.Add(treeNode);
				}
				this.treeView_0.EndUpdate();
			}
		}

		private void treeView_0_AfterSelect(object sender, TreeViewEventArgs e)
		{
			this.int_5 = -1;
			this.int_6 = -1;
			if (((TreeObject)e.Node.Tag).TypeNode == TypeNode.Substation)
			{
				if (this.objList_0 == null || this.objList_0.Id != ((TreeObject)e.Node.Tag).idSub)
				{
					this.objList_0 = new ObjList(this.SqlSettings);
					this.objList_0.Id = ((TreeObject)e.Node.Tag).idSub;
				}
				this.enum11_0 = ((this.objList_0.Id == this.int_0) ? ((FormMeasurement.Enum11)0) : ((FormMeasurement.Enum11)1));
				this.method_11(this.int_2);
			}
			if (((TreeObject)e.Node.Tag).TypeNode == TypeNode.Bus)
			{
				this.int_5 = ((TreeObject)e.Node.Tag).idBus;
				this.int_6 = ((TreeObject)e.Node.Tag).idTransf;
				this.string_1 = ((TreeObject)e.Node.Tag).NameTransf;
				if (this.objList_0 == null || this.objList_0.Id != this.int_5)
				{
					this.objList_0 = new ObjList(this.SqlSettings);
					this.objList_0.Id = this.int_5;
				}
				this.enum11_0 = ((this.objList_0.IdParent == this.int_0) ? ((FormMeasurement.Enum11)0) : ((FormMeasurement.Enum11)1));
				if (this.enum11_0 == (FormMeasurement.Enum11)1)
				{
					this.method_11(this.int_2);
				}
				if (this.bindingSource_15.Count == 0)
				{
					this.bindingSource_15_CurrentChanged(this.bindingSource_15, new EventArgs());
					return;
				}
				int num = -1;
				this.bindingSource_15.RaiseListChangedEvents = false;
				this.bindingSource_15.CurrentChanged -= this.bindingSource_15_CurrentChanged;
				int num2;
				if (this.int_6 != -1)
				{
					num2 = this.bindingSource_15.Find("idTransf", this.int_6);
					if (num2 == -1)
					{
						DataTable dataTable = base.SelectSqlData("vJ_MeasByBusTransf", true, string.Format("WHERE Year = {0} AND idBus = {1} AND idObjList = {2}", (int)((DataRowView)this.bindingSource_13.Current)["Year"], this.int_5, this.int_6));
						if (dataTable.Rows.Count > 0)
						{
							num = this.bindingSource_9.Find("id", (int)dataTable.Rows[0]["id"]);
							this.bindingSource_9.Position = num;
						}
						if (num == -1)
						{
							num2 = this.bindingSource_15.Find("idBus", this.int_5);
						}
					}
				}
				else
				{
					num2 = this.bindingSource_15.Find("idBus", this.int_5);
				}
				if (num2 != -1)
				{
					this.bindingSource_15.Position = num2;
				}
				this.bindingSource_15.CurrentChanged += this.bindingSource_15_CurrentChanged;
				this.bindingSource_15.RaiseListChangedEvents = false;
				this.bindingSource_15_CurrentChanged(this.bindingSource_15, new EventArgs());
			}
		}

		private void method_11(int int_7)
		{
			this.method_12(int_7, -1);
		}

		private void method_12(int int_7, int int_8)
		{
			if (int_8 == -1)
			{
				int_8 = ((this.toolStripComboBox_0.ComboBox.SelectedValue is int) ? ((int)this.toolStripComboBox_0.ComboBox.SelectedValue) : -1);
			}
			this.bindingSource_13.RaiseListChangedEvents = true;
			this.bindingSource_13.CurrentChanged -= this.bindingSource_13_CurrentChanged;
			this.class255_0.vJ_GetMeasYears.Clear();
			if (int_7 != -1)
			{
				base.SelectSqlData(this.class255_0.vJ_GetMeasYears, true, string.Format("WHERE idObjList = {0} AND TypeDoc = {1}", this.method_19(), int_7), new int?(0), true, 0);
				if (int_8 != -1)
				{
					this.bindingSource_13.Position = this.bindingSource_13.Find("Year", int_8);
				}
			}
			this.bindingSource_13.CurrentChanged += this.bindingSource_13_CurrentChanged;
			this.bindingSource_13.RaiseListChangedEvents = false;
			this.bindingSource_13_CurrentChanged(this.bindingSource_13, new EventArgs());
		}

		private void method_13()
		{
			base.SelectSqlDataTableOther(this.class255_0, this.class255_0.tR_CableVoltage, "tR_Classifier", true, "WHERE ParentKey LIKE ';VoltageLevels;%' AND IsGroup = 0 AND Deleted = 0 ORDER BY Value");
			Class255.Class392 @class = this.class255_0.tR_CableVoltage.method_5();
			@class.Id = -1;
			@class.Name = "";
			this.class255_0.tR_CableVoltage.method_0(@class);
		}

		private void method_14()
		{
			base.SelectSqlData(this.class255_0, this.class255_0.vP_Worker, true, string.Format("WHERE ParentKey IN (';GroupWorker;Meas;', ';GroupWorker;MeasDispatchers;') AND DateEnd IS NULL", new object[0]));
			Class255.Class381 @class = this.class255_0.vP_Worker.method_4();
			@class.Id = -1;
			@class.F = "";
			@class.FIO = "";
			@class.ParentKey = "";
			@class.idGroup = 1;
			@class.isGroup = false;
			this.class255_0.vP_Worker.method_0(@class);
		}

		private void method_15()
		{
			base.SelectSqlData(this.class255_0, this.class255_0.tR_Classifier, true, string.Format("WHERE ParentKey IN (';Measurement;Switch;', ';Measurement;Type;') AND Deleted = ((0)) AND isGroup = ((0))", new object[0]));
			Class255.Class369 @class = this.class255_0.tR_Classifier.method_5();
			@class.Id = -1;
			@class.Name = "";
			@class.ParentKey = ";Measurement;Switch;";
			@class.IsGroup = false;
			@class.Deleted = false;
			this.class255_0.tR_Classifier.method_0(@class);
			this.comboBox_1.SelectedValue = -1;
		}

		private void method_16()
		{
			this.dataGridView_1.Rows.Clear();
			decimal num = (from row in this.class255_0.vJ_MeasCable
			where row["Iad"] != DBNull.Value
			select row).Sum((Class255.Class413 row) => row.Iad);
			decimal num2 = (from row in this.class255_0.vJ_MeasCable
			where row["Ian"] != DBNull.Value
			select row).Sum((Class255.Class413 row) => row.Ian);
			decimal num3 = (from row in this.class255_0.vJ_MeasCable
			where row["Ibd"] != DBNull.Value
			select row).Sum((Class255.Class413 row) => row.Ibd);
			decimal num4 = (from row in this.class255_0.vJ_MeasCable
			where row["Ibn"] != DBNull.Value
			select row).Sum((Class255.Class413 row) => row.Ibn);
			decimal num5 = (from row in this.class255_0.vJ_MeasCable
			where row["Icd"] != DBNull.Value
			select row).Sum((Class255.Class413 row) => row.Icd);
			decimal num6 = (from row in this.class255_0.vJ_MeasCable
			where row["Icn"] != DBNull.Value
			select row).Sum((Class255.Class413 row) => row.Icn);
			decimal num7 = (from row in this.class255_0.vJ_MeasCable
			where row["Iod"] != DBNull.Value
			select row).Sum((Class255.Class413 row) => row.Iod);
			decimal num8 = (from row in this.class255_0.vJ_MeasCable
			where row["Ion"] != DBNull.Value
			select row).Sum((Class255.Class413 row) => row.Ion);
			decimal num9 = 0m;
			decimal num10 = 0m;
			this.dataGridView_1.Rows.Add(new object[]
			{
				"Суммарная нагрузка Iсум, A",
				num,
				num2,
				num3,
				num4,
				num5,
				num6,
				num7,
				num8,
				""
			});
			if (this.tabControl_0.SelectedTab == this.tabPage_0)
			{
				decimal d = Math.Round((num + num3 + num5) / 3m, 0);
				decimal d2 = Math.Round((num2 + num4 + num6) / 3m, 0);
				decimal d3 = decimal.Parse((this.textBox_7.Text.Length == 0) ? "0" : this.textBox_7.Text);
				this.textBox_5.Text = d.ToString();
				this.textBox_4.Text = d2.ToString();
				this.textBox_3.Text = ((d3 == 0m) ? "0" : Math.Round(d / (d3 / 100m), 1).ToString());
				this.textBox_2.Text = ((d3 == 0m) ? "0" : Math.Round(d2 / (d3 / 100m), 1).ToString());
				decimal num11 = Math.Max(Math.Abs(num - num3), Math.Abs(num - num5));
				num11 = Math.Max(num11, Math.Abs(num3 - num5));
				if (num + num3 + num5 != 0m)
				{
					num9 = Math.Round(num11 / ((num + num3 + num5) / 100m), 0);
				}
				decimal num12 = Math.Max(Math.Abs(num2 - num4), Math.Abs(num2 - num6));
				num12 = Math.Max(num12, Math.Abs(num4 - num6));
				if (num2 + num4 + num6 != 0m)
				{
					num10 = Math.Round(num12 / ((num2 + num4 + num6) / 100m));
				}
				this.textBox_1.Text = num9.ToString();
				this.textBox_0.Text = num10.ToString();
				return;
			}
			this.dataGridView_1.Rows.Add(new object[]
			{
				"Суммарная нагрузка Iсум, A",
				num,
				num2,
				num3,
				num4,
				num5,
				num6,
				num7,
				num8,
				""
			});
		}

		private void method_17()
		{
			if (this.class255_0.vJ_MeasCell.Rows.Count > 0)
			{
				this.dataGridView_4.Rows.Clear();
				decimal num = (from row in this.class255_0.vJ_MeasCell
				where row["Iad"] != DBNull.Value
				select row).Sum((Class255.Class440 row) => row.Iad);
				decimal num2 = (from row in this.class255_0.vJ_MeasCell
				where row["Ian"] != DBNull.Value
				select row).Sum((Class255.Class440 row) => row.Ian);
				decimal num3 = (from row in this.class255_0.vJ_MeasCell
				where row["Ibd"] != DBNull.Value
				select row).Sum((Class255.Class440 row) => row.Ibd);
				decimal num4 = (from row in this.class255_0.vJ_MeasCell
				where row["Ibn"] != DBNull.Value
				select row).Sum((Class255.Class440 row) => row.Ibn);
				decimal num5 = (from row in this.class255_0.vJ_MeasCell
				where row["Icd"] != DBNull.Value
				select row).Sum((Class255.Class440 row) => row.Icd);
				decimal num6 = (from row in this.class255_0.vJ_MeasCell
				where row["Icn"] != DBNull.Value
				select row).Sum((Class255.Class440 row) => row.Icn);
				this.dataGridView_4.Rows.Add(new object[]
				{
					"Суммарная нагрузка Iсум, A",
					num,
					num2,
					num3,
					num4,
					num5,
					num6,
					""
				});
				return;
			}
			this.dataGridView_4.Rows.Add(new object[]
			{
				"Суммарная нагрузка Iсум, A",
				0,
				0,
				0,
				0,
				0,
				0,
				""
			});
		}

		private void method_18()
		{
			if (this.toolStripComboBox_0.ComboBox.SelectedValue is int)
			{
				int num = (int)this.toolStripComboBox_0.ComboBox.SelectedValue;
			}
			int num2 = (this.dataGridView_3.SelectedRows == null || this.dataGridView_3.SelectedRows.Count <= 0) ? -1 : ((int)this.dataGridView_3.SelectedRows[0].Cells["idDataGridViewTextBoxColumn1"].Value);
			this.method_11(this.int_2);
			this.bindingSource_9.RaiseListChangedEvents = true;
			this.bindingSource_9.CurrentChanged -= this.bindingSource_9_CurrentChanged;
			this.bindingSource_9.Position = this.bindingSource_9.Find("Id", num2);
			this.bindingSource_9.CurrentChanged += this.bindingSource_9_CurrentChanged;
			this.bindingSource_9.RaiseListChangedEvents = false;
			if (this.typeDoc_1 == FormMeasurement.TypeDoc.LowMeasurement)
			{
				this.bindingSource_15.Position = this.bindingSource_15.Find("idBus", this.int_3);
			}
			if (this.typeDoc_1 == FormMeasurement.TypeDoc.HighMeasurement)
			{
				this.bindingSource_15.Position = this.bindingSource_15.Find("idBus", this.int_3);
			}
		}

		private int method_19()
		{
			if (this.treeView_0.SelectedNode == null || ((TreeObject)this.treeView_0.SelectedNode.Tag).TypeNode == TypeNode.Group)
			{
				return -1;
			}
			if (this.objList_0.GroupType != TypeObjListGroup.Substations)
			{
				return this.objList_0.IdParent;
			}
			return this.objList_0.Id;
		}

		private string method_20(TreeNode treeNode_0)
		{
			if (((TreeObject)treeNode_0.Tag).TypeNode == TypeNode.Bus)
			{
				return treeNode_0.Parent.Text;
			}
			if (((TreeObject)treeNode_0.Tag).TypeNode != TypeNode.Substation)
			{
				return "";
			}
			return treeNode_0.Text;
		}

		private string method_21()
		{
			return this.method_20(this.treeView_0.SelectedNode);
		}

		private int method_22(FormMeasurement.TypeDoc typeDoc_2)
		{
			return (from row in this.class255_0.tR_Classifier.Where(new Func<Class255.Class369, bool>(this.method_30))
			select row.Id).First<int>();
		}

		private void method_23(FormMeasurement.TypeDoc typeDoc_2)
		{
			switch (typeDoc_2)
			{
			case FormMeasurement.TypeDoc.None:
			case (FormMeasurement.TypeDoc)0:
				break;
			case FormMeasurement.TypeDoc.LowMeasurement:
				this.tableLayoutPanel_1.RowStyles[2] = new RowStyle(SizeType.Percent, 100f);
				this.tableLayoutPanel_1.RowStyles[3] = new RowStyle(SizeType.Absolute, 0f);
				this.dataGridViewTextBoxColumn_149.Visible = true;
				this.dataGridViewTextBoxColumn_150.Visible = true;
				this.dataGridViewComboBoxColumn_1.Visible = false;
				return;
			case FormMeasurement.TypeDoc.HighMeasurement:
				this.tableLayoutPanel_1.RowStyles[2] = new RowStyle(SizeType.Absolute, 0f);
				this.tableLayoutPanel_1.RowStyles[3] = new RowStyle(SizeType.Percent, 100f);
				this.dataGridViewTextBoxColumn_149.Visible = false;
				this.dataGridViewTextBoxColumn_150.Visible = false;
				this.dataGridViewComboBoxColumn_1.Visible = true;
				break;
			default:
				return;
			}
		}

		private void method_24(string string_2, object object_0)
		{
			if (this.bindingSource_15.Count == 0)
			{
				this.bindingSource_15_CurrentChanged(this.bindingSource_15, new EventArgs());
				return;
			}
			this.bindingSource_15.RaiseListChangedEvents = false;
			this.bindingSource_15.CurrentChanged -= this.bindingSource_15_CurrentChanged;
			int num = this.bindingSource_15.Find(string_2, object_0);
			if (num != -1)
			{
				this.bindingSource_15.Position = num;
			}
			else
			{
				this.class255_0.vJ_BusesTransfs.Rows.Clear();
			}
			this.bindingSource_15.CurrentChanged += this.bindingSource_15_CurrentChanged;
			this.bindingSource_15.RaiseListChangedEvents = false;
			this.bindingSource_15_CurrentChanged(this.bindingSource_15, new EventArgs());
		}

		private void bindingSource_13_CurrentChanged(object sender, EventArgs e)
		{
			this.bindingSource_9.RaiseListChangedEvents = true;
			this.bindingSource_9.CurrentChanged -= this.bindingSource_9_CurrentChanged;
			this.class255_0.tJ_Measurement.Rows.Clear();
			if (this.bindingSource_13.Current != null)
			{
				string sort = (this.bindingSource_9.Sort != null) ? this.bindingSource_9.Sort : "";
				if (((DataRowView)this.bindingSource_13.Current)["Year"] is int)
				{
					base.SelectSqlData(this.class255_0, this.class255_0.tJ_Measurement, true, string.Format("WHERE idObjList = {0} AND TypeDoc = {1} AND Year = {2} AND Deleted = ((0))", this.method_19(), this.int_2, (int)((DataRowView)this.bindingSource_13.Current)["Year"]));
					this.bindingSource_9.Sort = sort;
				}
			}
			this.bindingSource_9.CurrentChanged += this.bindingSource_9_CurrentChanged;
			this.bindingSource_9.RaiseListChangedEvents = false;
			this.bindingSource_9_CurrentChanged(this.bindingSource_9, new EventArgs());
		}

		private void bindingSource_9_CurrentChanged(object sender, EventArgs e)
		{
			this.bindingSource_15.RaiseListChangedEvents = true;
			this.bindingSource_15.CurrentChanged -= this.bindingSource_15_CurrentChanged;
			this.class255_0.vJ_BusesTransfs.Rows.Clear();
			if (this.bindingSource_9.Current != null)
			{
				base.SelectSqlData(this.class255_0, this.class255_0.vJ_BusesTransfs, true, string.Format("WHERE idMeasurement = {0} AND TypeDoc = {1} ORDER BY Name", (int)((DataRowView)this.bindingSource_9.Current)["id"], this.int_2));
			}
			this.bindingSource_15.CurrentChanged += this.bindingSource_15_CurrentChanged;
			this.bindingSource_15.RaiseListChangedEvents = false;
			this.int_4 = ((this.bindingSource_15.Current == null || !(((DataRowView)this.bindingSource_15.Current)["IdTransf"] is int)) ? -1 : ((int)((DataRowView)this.bindingSource_15.Current)["IdTransf"]));
			this.string_0 = ((this.bindingSource_15.Current == null || !(((DataRowView)this.bindingSource_15.Current)["IdTransf"] is string)) ? "" : ((DataRowView)this.bindingSource_15.Current)["IdTransf"].ToString());
			this.int_3 = ((this.bindingSource_15.Current == null || !(((DataRowView)this.bindingSource_15.Current)["IdBus"] is int)) ? -1 : ((int)((DataRowView)this.bindingSource_15.Current)["IdBus"]));
			if (this.typeDoc_1 == FormMeasurement.TypeDoc.HighMeasurement && this.bindingSource_9.Current != null)
			{
				this.method_25((int)((DataRowView)this.bindingSource_9.Current)["id"]);
			}
			if (this.fillTree_0 != FormDockPassport.FillTree.One)
			{
				this.bindingSource_15_CurrentChanged(this.bindingSource_15, new EventArgs());
				return;
			}
			if (this.objList_1.GroupType == TypeObjListGroup.Buses)
			{
				this.method_24("idBus", this.int_3);
				return;
			}
			if (this.objList_1.GroupType == TypeObjListGroup.Switches)
			{
				this.method_24("idTransf", this.int_4);
				return;
			}
			this.bindingSource_15_CurrentChanged(this.bindingSource_15, new EventArgs());
		}

		private int method_25(int int_7)
		{
			int num = -1;
			DataTable dataTable = base.SelectSqlData("tJ_MeasAmperageTransf", true, string.Format("WHERE idMeasurement = {0} AND Deleted = ((0))", int_7));
			if (dataTable.Rows.Count > 0)
			{
				DataRow dataRow = dataTable.AsEnumerable().First<DataRow>();
				if (dataRow["idBus"] != DBNull.Value)
				{
					dataRow.Field("idBus");
				}
				if (dataRow["idObjList"] != DBNull.Value)
				{
					dataRow.Field("idObjList");
				}
				if (this.bindingSource_15.Count != 0)
				{
					this.bindingSource_15.RaiseListChangedEvents = true;
					this.bindingSource_15.CurrentChanged -= this.bindingSource_15_CurrentChanged;
					if (this.int_4 == -1)
					{
						num = this.bindingSource_15.Find("idBus", this.int_3);
					}
					else
					{
						num = this.bindingSource_15.Find("IdTransf", this.int_4);
						if (num != -1)
						{
							num = this.bindingSource_15.Find("idBus", this.int_3);
						}
					}
					if (num != -1)
					{
						this.bindingSource_15.Position = num;
					}
					this.bindingSource_15.CurrentChanged += this.bindingSource_15_CurrentChanged;
					this.bindingSource_15.RaiseListChangedEvents = false;
				}
			}
			return num;
		}

		private void bindingSource_15_CurrentChanged(object sender, EventArgs e)
		{
			this.int_4 = ((this.bindingSource_15.Current == null || !(((DataRowView)this.bindingSource_15.Current)["IdTransf"] is int)) ? -1 : ((int)((DataRowView)this.bindingSource_15.Current)["IdTransf"]));
			this.string_0 = ((this.bindingSource_15.Current == null || !(((DataRowView)this.bindingSource_15.Current)["IdTransf"] is string)) ? "" : ((DataRowView)this.bindingSource_15.Current)["IdTransf"].ToString());
			this.int_3 = ((this.bindingSource_15.Current == null || !(((DataRowView)this.bindingSource_15.Current)["IdBus"] is int)) ? -1 : ((int)((DataRowView)this.bindingSource_15.Current)["IdBus"]));
			if (this.typeDoc_1 == FormMeasurement.TypeDoc.LowMeasurement)
			{
				this.class255_0.fn_J_MeasTransfPassport.Rows.Clear();
				if (this.int_4 != -1)
				{
					base.CallSQLTableValuedFunction(this.class255_0, this.class255_0.fn_J_MeasTransfPassport, "", new string[]
					{
						this.int_4.ToString()
					});
				}
				this.class255_0.tJ_MeasVoltageTransf.Rows.Clear();
				if (this.bindingSource_9.Current != null)
				{
					base.SelectSqlData(this.class255_0, this.class255_0.tJ_MeasVoltageTransf, true, string.Format("WHERE idMeasurement = {0} AND IdBus = {1} AND idObjList = {2} AND Deleted = ((0))", (int)((DataRowView)this.bindingSource_9.Current)["id"], this.int_3, this.int_4));
				}
				this.bindingSource_7.RaiseListChangedEvents = true;
				this.bindingSource_7.CurrentChanged -= this.bindingSource_7_CurrentChanged;
				this.class255_0.vJ_MeasCable.Rows.Clear();
				this.dataGridView_1.Rows.Clear();
				if (this.bindingSource_15.Current != null && this.bindingSource_9.Current != null)
				{
					string sort = (this.bindingSource_7.Sort != null) ? this.bindingSource_7.Sort : "";
					base.SelectSqlData(this.class255_0, this.class255_0.vJ_MeasCable, true, string.Format("WHERE idMeasurement = {0} AND IdBus = {1} AND idTransf = {2} AND Deleted = ((0)) ORDER BY CONVERT(INT, CASE WHEN NameCell like '%[^0-9]%' THEN SUBSTRING(NameCell,1,PATINDEX('%[^0-9]%',NameCell)-1) ELSE NameCell END), OldCell", (int)((DataRowView)this.bindingSource_9.Current)["id"], this.int_3, this.int_4));
					this.bindingSource_7.Sort = sort;
				}
				this.bindingSource_7.CurrentChanged += this.bindingSource_7_CurrentChanged;
				this.bindingSource_7.RaiseListChangedEvents = false;
				this.bindingSource_7_CurrentChanged(this.bindingSource_7, new EventArgs());
			}
			if (this.typeDoc_1 == FormMeasurement.TypeDoc.HighMeasurement)
			{
				this.label_29.Text = "";
				this.class255_0.tJ_MeasAmperageTransf.Rows.Clear();
				this.class255_0.fn_J_MeasTransfPassport.Rows.Clear();
				if (this.bindingSource_15.Current != null)
				{
					if (this.int_4 != -1)
					{
						base.CallSQLTableValuedFunction(this.class255_0, this.class255_0.fn_J_MeasTransfPassport, "", new string[]
						{
							this.int_4.ToString()
						});
						this.label_29.Text = "Трансформатор № " + this.class255_0.fn_J_MeasTransfPassport.Rows[0]["Name"].ToString();
					}
					if (this.bindingSource_9.Current != null)
					{
						base.SelectSqlData(this.class255_0, this.class255_0.tJ_MeasAmperageTransf, true, string.Format("WHERE idMeasurement = {0} AND idBus = {1} AND idObjList = {2} AND Deleted = ((0))", (int)((DataRowView)this.bindingSource_9.Current)["id"], this.int_3, this.int_4));
					}
				}
				this.bindingSource_14.RaiseListChangedEvents = true;
				this.bindingSource_14.CurrentChanged -= this.bindingSource_14_CurrentChanged;
				this.class255_0.vJ_MeasCell.Rows.Clear();
				this.dataGridView_4.Rows.Clear();
				if (this.bindingSource_9.Current != null && this.bindingSource_15.Current != null)
				{
					string sort2 = (this.bindingSource_14.Sort != null) ? this.bindingSource_14.Sort : "";
					base.SelectSqlData(this.class255_0, this.class255_0.vJ_MeasCell, true, string.Format("WHERE idMeasurement = {0} AND idBus = {1} AND idTransf = {2} AND Deleted = ((0)) ORDER BY CONVERT(INT, CASE WHEN NameCell like '%[^0-9]%' THEN SUBSTRING(NameCell,1,PATINDEX('%[^0-9]%',NameCell)-1) ELSE NameCell END)", (int)((DataRowView)this.bindingSource_9.Current)["id"], this.int_3, this.int_4));
					this.bindingSource_14.Sort = sort2;
				}
				this.bindingSource_14.CurrentChanged += this.bindingSource_14_CurrentChanged;
				this.bindingSource_14.RaiseListChangedEvents = false;
				this.bindingSource_14_CurrentChanged(this.bindingSource_14, new EventArgs());
			}
		}

		private void bindingSource_7_CurrentChanged(object sender, EventArgs e)
		{
			this.method_16();
			if (this.tabControl_0.SelectedTab == this.tabPage_1)
			{
				this.class255_0.vJ_MeasAbnObj.Rows.Clear();
				if (this.bindingSource_7.Current != null && ((DataRowView)this.bindingSource_7.Current)["idCell"] is int)
				{
					base.SelectSqlData(this.class255_0, this.class255_0.vJ_MeasAbnObj, true, string.Format("WHERE idSchmObj = {0}", (int)((DataRowView)this.bindingSource_7.Current)["idCell"]));
				}
			}
		}

		private void bindingSource_14_CurrentChanged(object sender, EventArgs e)
		{
			this.method_17();
		}

		private void FormMeasurement_Shown(object sender, EventArgs e)
		{
			this.bool_0 = true;
		}

		private void FormMeasurement_Load(object sender, EventArgs e)
		{
			this.int_3 = -1;
			this.int_4 = -1;
			this.toolStripComboBox_0.ComboBox.DataSource = this.bindingSource_13;
			this.toolStripComboBox_0.ComboBox.DisplayMember = "Year";
			this.toolStripComboBox_0.ComboBox.ValueMember = "Year";
			this.method_13();
			this.method_15();
			IList list = this.riZoLnrtjNx.List;
			this.toolStripMenuItem_4.Tag = 1;
			this.toolStripMenuItem_5.Tag = 2;
			this.method_14();
			if (this.fillTree_0 == FormDockPassport.FillTree.All)
			{
				this.toolStripMenuItem_4.Checked = true;
				this.tableLayoutPanel_2.ColumnStyles[0] = new ColumnStyle(SizeType.Absolute, 212f);
				return;
			}
			this.objList_1 = new ObjList(this.SqlSettings);
			this.objList_1.Id = this.int_1;
			TypeObjList type = this.objList_1.Type;
			if (type != TypeObjList.SwitchTransf)
			{
				switch (type)
				{
				case TypeObjList.Bus10:
				case TypeObjList.Bus35:
				case TypeObjList.Bus6:
					this.toolStripMenuItem_5.Checked = true;
					this.toolStripSplitButton_1.Enabled = false;
					goto IL_148;
				}
			}
			this.toolStripMenuItem_4.Checked = true;
			this.toolStripSplitButton_1.Enabled = true;
			IL_148:
			this.tableLayoutPanel_2.ColumnStyles[0] = new ColumnStyle(SizeType.Absolute, 0f);
			base.Width -= 210;
		}

		private void toolStripButton_3_Click(object sender, EventArgs e)
		{
			int num = this.method_19();
			if (num != -1 && ((this.objList_0.GroupType == TypeObjListGroup.Substations && this.treeView_0.SelectedNode.Nodes.Count > 0) || this.objList_0.GroupType == TypeObjListGroup.Switches || this.objList_0.GroupType == TypeObjListGroup.Buses))
			{
				switch (this.typeDoc_1)
				{
				case FormMeasurement.TypeDoc.None:
				case (FormMeasurement.TypeDoc)0:
					break;
				case FormMeasurement.TypeDoc.LowMeasurement:
				{
					Form39 form = new Form39(this.SqlSettings, num, this.method_21(), this.int_5, this.int_6, -1);
					form.ShowForm += this.method_26;
					form.FormClosed += this.method_27;
					form.MdiParent = base.MdiParent;
					form.PermissionsSql = false;
					form.Show();
					return;
				}
				case FormMeasurement.TypeDoc.HighMeasurement:
				{
					Form38 form2 = new Form38(this.SqlSettings, num, this.method_21(), this.int_5, this.int_6);
					form2.FormClosed += this.method_28;
					form2.MdiParent = base.MdiParent;
					form2.PermissionsSql = false;
					form2.Show();
					return;
				}
				default:
					return;
				}
			}
			else
			{
				MessageBox.Show("Не выбрана подстанция или отсутствует " + ((this.typeDoc_1 == FormMeasurement.TypeDoc.LowMeasurement) ? "шина(трансформатор)." : "шина."), "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		private void toolStripButton_5_Click(object sender, EventArgs e)
		{
			if (this.bindingSource_9.Current != null && ((DataRowView)this.bindingSource_9.Current)["id"] is int && MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление.", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
			{
				this.class255_0.tJ_Measurement.Single(new Func<Class255.Class410, bool>(this.method_31)).Deleted = true;
				base.UpdateSqlData(this.class255_0, this.class255_0.tJ_Measurement);
				this.method_18();
			}
		}

		private void toolStripButton_4_Click(object sender, EventArgs e)
		{
			if (this.riZoLnrtjNx.Current != null)
			{
				if ((decimal)((DataRowView)this.riZoLnrtjNx.Current)["Value"] == 1m)
				{
					if (this.bindingSource_9.Current == null)
					{
						MessageBox.Show("Не выбран замер, либо в подстанции отсутствуют трансформаторы!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}
					Form39 form = new Form39(this.SqlSettings, this.method_19(), this.method_21(), this.int_3, this.int_4, (int)((DataRowView)this.bindingSource_9.Current)["id"]);
					form.ShowForm += this.method_26;
					form.FormClosed += this.method_27;
					form.MdiParent = base.MdiParent;
					form.PermissionsSql = false;
					form.Show();
				}
				if ((decimal)((DataRowView)this.riZoLnrtjNx.Current)["Value"] == 2m)
				{
					if (this.bindingSource_9.Current != null)
					{
						int int_ = (this.bindingSource_11.Current == null || !(((DataRowView)this.bindingSource_11.Current)["id"] is int)) ? -1 : ((int)((DataRowView)this.bindingSource_11.Current)["id"]);
						Form38 form2 = new Form38(this.SqlSettings, this.method_19(), this.method_21(), this.int_3, this.int_4, this.string_0, (int)((DataRowView)this.bindingSource_9.Current)["id"], int_);
						form2.FormClosed += this.method_28;
						form2.MdiParent = base.MdiParent;
						form2.PermissionsSql = false;
						form2.Show();
						return;
					}
					MessageBox.Show("Не выбран замер.", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
			}
			else
			{
				MessageBox.Show("Не выбран, либо отсутствуют тип замера!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		private void toolStripButton_6_Click(object sender, EventArgs e)
		{
			this.method_18();
		}

		private void toolStripButton_7_Click(object sender, EventArgs e)
		{
			if (this.riZoLnrtjNx.Current != null)
			{
				if ((decimal)((DataRowView)this.riZoLnrtjNx.Current)["Value"] == 1m && this.bindingSource_9.Current != null && this.bindingSource_15.Current != null)
				{
					ObjList objList = new ObjList(this.SqlSettings);
					objList.Id = this.method_19();
					int int_ = (((DataRowView)this.bindingSource_9.Current)["id"] is int) ? ((int)((DataRowView)this.bindingSource_9.Current)["id"]) : -1;
					int int_2 = (this.bindingSource_1.Current == null || !(((DataRowView)this.bindingSource_1.Current)["id"] is int)) ? -1 : ((int)((DataRowView)this.bindingSource_1.Current)["id"]);
					if (objList.Type == TypeObjList.SubstationConnecting)
					{
						new Form44(this.SqlSettings, (Enum13)1, int_, this.int_3, -1, -1)
						{
							MdiParent = base.MdiParent
						}.Show();
					}
					else
					{
						new Form44(this.SqlSettings, (Enum13)0, int_, this.int_3, this.int_4, int_2)
						{
							MdiParent = base.MdiParent
						}.Show();
					}
				}
				if ((decimal)((DataRowView)this.riZoLnrtjNx.Current)["Value"] == 2m && this.bindingSource_9.Current != null && this.bindingSource_15.Current != null)
				{
					int int_3 = (((DataRowView)this.bindingSource_9.Current)["id"] is int) ? ((int)((DataRowView)this.bindingSource_9.Current)["id"]) : -1;
					int int_4 = (this.bindingSource_11.Current == null || !(((DataRowView)this.bindingSource_11.Current)["id"] is int)) ? -1 : ((int)((DataRowView)this.bindingSource_11.Current)["id"]);
					new Form44(this.SqlSettings, (Enum13)2, int_3, this.int_3, this.int_4, int_4)
					{
						MdiParent = base.MdiParent
					}.Show();
				}
			}
		}

		private void toolStripMenuItem_0_Click(object sender, EventArgs e)
		{
			new Form43
			{
				SqlSettings = this.SqlSettings,
				MdiParent = base.MdiParent
			}.Show();
		}

		private void toolStripMenuItem_1_Click(object sender, EventArgs e)
		{
			Form42 form = new Form42();
			form.SqlSettings = this.SqlSettings;
			form.method_1((Enum13)4);
			form.MdiParent = base.MdiParent;
			form.Show();
		}

		private void toolStripMenuItem_2_Click(object sender, EventArgs e)
		{
			Form42 form = new Form42();
			form.SqlSettings = this.SqlSettings;
			form.method_1((Enum13)5);
			form.MdiParent = base.MdiParent;
			form.Show();
		}

		private void toolStripMenuItem_5_CheckedChanged(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
			int num = (int)toolStripMenuItem.Tag;
			ToolStripMenuItem toolStripMenuItem2 = (num == 1) ? this.toolStripMenuItem_5 : ((num == 2) ? this.toolStripMenuItem_4 : null);
			if (toolStripMenuItem.Checked == toolStripMenuItem2.Checked)
			{
				toolStripMenuItem2.Checked = !toolStripMenuItem.Checked;
			}
			if (toolStripMenuItem != null && toolStripMenuItem.Checked)
			{
				this.riZoLnrtjNx.Position = this.riZoLnrtjNx.Find("Value", num);
				this.toolStripSplitButton_1.Text = (toolStripMenuItem.Checked ? toolStripMenuItem.Text : toolStripMenuItem2.Text);
				this.typeDoc_1 = (((decimal)((DataRowView)this.riZoLnrtjNx.Current)["Value"] == 1m) ? FormMeasurement.TypeDoc.LowMeasurement : (((decimal)((DataRowView)this.riZoLnrtjNx.Current)["Value"] == 2m) ? FormMeasurement.TypeDoc.HighMeasurement : FormMeasurement.TypeDoc.None));
				this.int_2 = this.method_22(this.typeDoc_1);
				this.method_23(this.typeDoc_1);
				if (this.fillTree_0 == FormDockPassport.FillTree.All)
				{
					int num2 = this.method_19();
					this.method_2(this.sort_0, this.typeDoc_1);
					if (num2 != -1)
					{
						List<TreeNode> list_ = new List<TreeNode>();
						list_ = this.method_5(this.treeView_0.Nodes, list_);
						TreeNode treeNode = this.method_9(list_, num2);
						if (treeNode != null)
						{
							this.treeView_0.Focus();
							this.treeView_0.SelectedNode = treeNode;
							this.treeView_0.SelectedNode.Expand();
						}
					}
				}
				else
				{
					this.method_3(this.sort_0, this.int_1, this.typeDoc_1);
				}
				this.method_11(this.int_2);
				this.typeDoc_0 = this.typeDoc_1;
			}
		}

		private FormBase method_26(object object_0, ShowFormEventArgs showFormEventArgs_0)
		{
			return this.OnShowForm(showFormEventArgs_0);
		}

		private void method_27(object sender, FormClosedEventArgs e)
		{
			Form39 form = (Form39)sender;
			if (form.DialogResult == DialogResult.OK)
			{
				this.method_18();
				this.bindingSource_9.Position = this.bindingSource_9.Find("Id", form.method_2());
				this.bindingSource_15.Position = this.bindingSource_15.Find("idTransf", form.method_6());
			}
		}

		private void method_28(object sender, FormClosedEventArgs e)
		{
			Form38 form = (Form38)sender;
			if (form.DialogResult == DialogResult.OK)
			{
				this.method_18();
				this.bindingSource_9.Position = this.bindingSource_9.Find("Id", form.Int32_0);
				this.bindingSource_15.Position = this.bindingSource_15.Find("idBus", form.IdBus);
			}
		}

		private void textBox_21_KeyPress(object sender, KeyPressEventArgs e)
		{
			InputCheck.OnlyDigit(sender, e);
		}

		private void button_0_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void dataGridView_3_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
		}

		private void tabControl_0_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.bindingSource_7_CurrentChanged(this.bindingSource_7, new EventArgs());
		}

		private void rKroglMajQE_Click(object sender, EventArgs e)
		{
			new Form41
			{
				MdiParent = base.MdiParent,
				SqlSettings = this.SqlSettings
			}.Show();
		}

		private void toolStripButton_8_Click(object sender, EventArgs e)
		{
		}

		private void UaAoRsTxyRR(object sender, EventArgs e)
		{
			byte[] faq_Measurement = Resources.FAQ_Measurement;
			string text = Path.ChangeExtension(Path.GetTempFileName(), ".doc");
			using (FileStream fileStream = File.Create(text))
			{
				fileStream.Write(faq_Measurement, 0, faq_Measurement.Length);
			}
			new OfficeLB.Word.Application
			{
				Visible = true
			}.Documents.Add(text);
			try
			{
				File.Delete(text);
			}
			catch
			{
			}
		}

		private void toolStripMenuItem_6_Click(object sender, EventArgs e)
		{
			int num = (this.toolStripComboBox_0.ComboBox.SelectedValue is int) ? ((int)this.toolStripComboBox_0.ComboBox.SelectedValue) : -1;
			new Form45(this.SqlSettings, num)
			{
				MdiParent = base.MdiParent
			}.Show();
		}

		private void method_29()
		{
			this.DopoRbgBvpu = new Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FormMeasurement));
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
			this.tableLayoutPanel_0 = new TableLayoutPanel();
			this.treeView_0 = new TreeView();
			this.toolStrip_0 = new ToolStrip();
			this.toolStripTextBox_0 = new ToolStripTextBox();
			this.toolStripButton_0 = new ToolStripButton();
			this.toolStripButton_1 = new ToolStripButton();
			this.toolStripSeparator_0 = new ToolStripSeparator();
			this.toolStripButton_2 = new ToolStripButton();
			this.tableLayoutPanel_1 = new TableLayoutPanel();
			this.toolStrip_1 = new ToolStrip();
			this.toolStripButton_3 = new ToolStripButton();
			this.toolStripButton_4 = new ToolStripButton();
			this.toolStripButton_5 = new ToolStripButton();
			this.toolStripSeparator_1 = new ToolStripSeparator();
			this.toolStripButton_6 = new ToolStripButton();
			this.toolStripSeparator_3 = new ToolStripSeparator();
			this.toolStripButton_7 = new ToolStripButton();
			this.toolStripSeparator_4 = new ToolStripSeparator();
			this.toolStripSplitButton_1 = new ToolStripSplitButton();
			this.toolStripMenuItem_4 = new ToolStripMenuItem();
			this.toolStripMenuItem_5 = new ToolStripMenuItem();
			this.toolStripSeparator_2 = new ToolStripSeparator();
			this.toolStripLabel_0 = new ToolStripLabel();
			this.toolStripComboBox_0 = new ToolStripComboBox();
			this.toolStripSplitButton_0 = new ToolStripSplitButton();
			this.toolStripMenuItem_0 = new ToolStripMenuItem();
			this.toolStripMenuItem_1 = new ToolStripMenuItem();
			this.toolStripMenuItem_2 = new ToolStripMenuItem();
			this.toolStripMenuItem_3 = new ToolStripMenuItem();
			this.rKroglMajQE = new ToolStripMenuItem();
			this.toolStripMenuItem_6 = new ToolStripMenuItem();
			this.toolStripButton_8 = new ToolStripButton();
			this.toolStripButton_9 = new ToolStripButton();
			this.button_0 = new Button();
			this.tableLayoutPanel_3 = new TableLayoutPanel();
			this.comboBox_0 = new ComboBox();
			this.bindingSource_15 = new BindingSource(this.DopoRbgBvpu);
			this.class255_0 = new Class255();
			this.label_0 = new Label();
			this.tabControl_0 = new TabControl();
			this.tabPage_0 = new TabPage();
			this.label_1 = new Label();
			this.label_2 = new Label();
			this.label_3 = new Label();
			this.label_4 = new Label();
			this.label_5 = new Label();
			this.label_6 = new Label();
			this.textBox_0 = new TextBox();
			this.textBox_1 = new TextBox();
			this.textBox_2 = new TextBox();
			this.textBox_3 = new TextBox();
			this.textBox_4 = new TextBox();
			this.textBox_5 = new TextBox();
			this.tabPage_1 = new TabPage();
			this.dataGridView_0 = new DataGridView();
			this.dataGridViewTextBoxColumn_140 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_141 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_142 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_143 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_144 = new DataGridViewTextBoxColumn();
			this.bindingSource_8 = new BindingSource(this.DopoRbgBvpu);
			this.panel_0 = new Panel();
			this.label_7 = new Label();
			this.label_8 = new Label();
			this.label_9 = new Label();
			this.label_10 = new Label();
			this.label_11 = new Label();
			this.panel_1 = new Panel();
			this.YfQoLrPgfVl = new TextBox();
			this.bindingSource_0 = new BindingSource(this.DopoRbgBvpu);
			this.textBox_6 = new TextBox();
			this.label_12 = new Label();
			this.label_13 = new Label();
			this.panel_2 = new Panel();
			this.comboBox_1 = new ComboBox();
			this.bindingSource_1 = new BindingSource(this.DopoRbgBvpu);
			this.bindingSource_12 = new BindingSource(this.DopoRbgBvpu);
			this.panel_3 = new Panel();
			this.textBox_7 = new TextBox();
			this.panel_4 = new Panel();
			this.textBox_8 = new TextBox();
			this.panel_5 = new Panel();
			this.textBox_9 = new TextBox();
			this.dataGridView_1 = new DataGridView();
			this.dataGridViewTextBoxColumn_130 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_131 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_132 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_133 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_134 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_135 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_136 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_137 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_138 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_139 = new DataGridViewTextBoxColumn();
			this.panel_6 = new Panel();
			this.panel_7 = new Panel();
			this.label_14 = new Label();
			this.panel_8 = new Panel();
			this.panel_9 = new Panel();
			this.label_15 = new Label();
			this.label_16 = new Label();
			this.label_17 = new Label();
			this.panel_10 = new Panel();
			this.textBox_10 = new TextBox();
			this.textBox_11 = new TextBox();
			this.textBox_12 = new TextBox();
			this.textBox_13 = new TextBox();
			this.textBox_14 = new TextBox();
			this.textBox_15 = new TextBox();
			this.panel_11 = new Panel();
			this.label_18 = new Label();
			this.label_19 = new Label();
			this.label_20 = new Label();
			this.panel_12 = new Panel();
			this.textBox_16 = new TextBox();
			this.textBox_17 = new TextBox();
			this.textBox_18 = new TextBox();
			this.textBox_19 = new TextBox();
			this.textBox_20 = new TextBox();
			this.textBox_21 = new TextBox();
			this.panel_13 = new Panel();
			this.label_21 = new Label();
			this.label_22 = new Label();
			this.dataGridView_2 = new DataGridView();
			this.dataGridViewCheckBoxColumn_3 = new DataGridViewCheckBoxColumn();
			this.dataGridViewTextBoxColumn_107 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_108 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_109 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_110 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_111 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_112 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_113 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_114 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_115 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_116 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_117 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_118 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_119 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_120 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_121 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_122 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_123 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_124 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_125 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_126 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_127 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_128 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_129 = new DataGridViewTextBoxColumn();
			this.bindingSource_7 = new BindingSource(this.DopoRbgBvpu);
			this.dataGridView_3 = new DataGridView();
			this.dataGridViewComboBoxColumn_0 = new DataGridViewComboBoxColumn();
			this.bindingSource_10 = new BindingSource(this.DopoRbgBvpu);
			this.dataGridViewComboBoxColumn_1 = new DataGridViewComboBoxColumn();
			this.bindingSource_17 = new BindingSource(this.DopoRbgBvpu);
			this.dataGridViewCheckBoxColumn_4 = new DataGridViewCheckBoxColumn();
			this.dataGridViewTextBoxColumn_145 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_146 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_147 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_148 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_149 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_150 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_151 = new DataGridViewTextBoxColumn();
			this.bindingSource_9 = new BindingSource(this.DopoRbgBvpu);
			this.tableLayoutPanel_4 = new TableLayoutPanel();
			this.panel_14 = new Panel();
			this.label_24 = new Label();
			this.SeroruImpei = new Label();
			this.label_25 = new Label();
			this.label_26 = new Label();
			this.panel_15 = new Panel();
			this.textBox_22 = new TextBox();
			this.textBox_23 = new TextBox();
			this.label_27 = new Label();
			this.label_28 = new Label();
			this.panel_16 = new Panel();
			this.textBox_24 = new TextBox();
			this.panel_17 = new Panel();
			this.textBox_25 = new TextBox();
			this.panel_18 = new Panel();
			this.kKnoracFnyK = new TextBox();
			this.panel_19 = new Panel();
			this.panel_20 = new Panel();
			this.label_30 = new Label();
			this.panel_21 = new Panel();
			this.label_31 = new Label();
			this.panel_22 = new Panel();
			this.label_32 = new Label();
			this.panel_23 = new Panel();
			this.textBox_26 = new TextBox();
			this.bindingSource_11 = new BindingSource(this.DopoRbgBvpu);
			this.panel_24 = new Panel();
			this.textBox_27 = new TextBox();
			this.label_33 = new Label();
			this.panel_25 = new Panel();
			this.textBox_28 = new TextBox();
			this.dataGridView_4 = new DataGridView();
			this.dataGridViewTextBoxColumn_32 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_33 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_34 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_35 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_36 = new DataGridViewTextBoxColumn();
			this.cEuordftJiB = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_37 = new DataGridViewTextBoxColumn();
			this.usrorTnxaCv = new DataGridViewTextBoxColumn();
			this.dataGridView_5 = new DataGridView();
			this.dataGridViewCheckBoxColumn_2 = new DataGridViewCheckBoxColumn();
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
			this.bindingSource_14 = new BindingSource(this.DopoRbgBvpu);
			this.label_23 = new Label();
			this.comboBox_2 = new ComboBox();
			this.label_29 = new Label();
			this.tableLayoutPanel_2 = new TableLayoutPanel();
			this.dataGridViewCheckBoxColumn_0 = new DataGridViewCheckBoxColumn();
			this.dataGridViewCheckBoxColumn_1 = new DataGridViewCheckBoxColumn();
			this.bindingSource_3 = new BindingSource(this.DopoRbgBvpu);
			this.bindingSource_4 = new BindingSource(this.DopoRbgBvpu);
			this.bindingSource_5 = new BindingSource(this.DopoRbgBvpu);
			this.bindingSource_6 = new BindingSource(this.DopoRbgBvpu);
			this.bindingSource_2 = new BindingSource(this.DopoRbgBvpu);
			this.riZoLnrtjNx = new BindingSource(this.DopoRbgBvpu);
			this.bindingSource_13 = new BindingSource(this.DopoRbgBvpu);
			this.dataGridViewTextBoxColumn_51 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_52 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_53 = new DataGridViewTextBoxColumn();
			this.yKeogyoCsw7 = new DataGridViewTextBoxColumn();
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
			this.WrRogfhGjk9 = new DataGridViewTextBoxColumn();
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
			this.eeEoggXrFln = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_98 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_99 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_100 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_101 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_102 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_103 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_104 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_105 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_106 = new DataGridViewTextBoxColumn();
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
			this.dataGridViewTextBoxColumn_25 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_26 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_27 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_28 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_29 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_30 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_31 = new DataGridViewTextBoxColumn();
			this.bindingSource_16 = new BindingSource(this.DopoRbgBvpu);
			this.tableLayoutPanel_0.SuspendLayout();
			this.toolStrip_0.SuspendLayout();
			this.tableLayoutPanel_1.SuspendLayout();
			this.toolStrip_1.SuspendLayout();
			this.tableLayoutPanel_3.SuspendLayout();
			((ISupportInitialize)this.bindingSource_15).BeginInit();
			((ISupportInitialize)this.class255_0).BeginInit();
			this.tabControl_0.SuspendLayout();
			this.tabPage_0.SuspendLayout();
			this.tabPage_1.SuspendLayout();
			((ISupportInitialize)this.dataGridView_0).BeginInit();
			((ISupportInitialize)this.bindingSource_8).BeginInit();
			this.panel_0.SuspendLayout();
			this.panel_1.SuspendLayout();
			((ISupportInitialize)this.bindingSource_0).BeginInit();
			this.panel_2.SuspendLayout();
			((ISupportInitialize)this.bindingSource_1).BeginInit();
			((ISupportInitialize)this.bindingSource_12).BeginInit();
			this.panel_3.SuspendLayout();
			this.panel_4.SuspendLayout();
			this.panel_5.SuspendLayout();
			((ISupportInitialize)this.dataGridView_1).BeginInit();
			this.panel_6.SuspendLayout();
			this.panel_7.SuspendLayout();
			this.panel_9.SuspendLayout();
			this.panel_10.SuspendLayout();
			this.panel_11.SuspendLayout();
			this.panel_12.SuspendLayout();
			this.panel_13.SuspendLayout();
			((ISupportInitialize)this.dataGridView_2).BeginInit();
			((ISupportInitialize)this.bindingSource_7).BeginInit();
			((ISupportInitialize)this.dataGridView_3).BeginInit();
			((ISupportInitialize)this.bindingSource_10).BeginInit();
			((ISupportInitialize)this.bindingSource_17).BeginInit();
			((ISupportInitialize)this.bindingSource_9).BeginInit();
			this.tableLayoutPanel_4.SuspendLayout();
			this.panel_14.SuspendLayout();
			this.panel_15.SuspendLayout();
			this.panel_16.SuspendLayout();
			this.panel_17.SuspendLayout();
			this.panel_18.SuspendLayout();
			this.panel_19.SuspendLayout();
			this.panel_20.SuspendLayout();
			this.panel_21.SuspendLayout();
			this.panel_22.SuspendLayout();
			this.panel_23.SuspendLayout();
			((ISupportInitialize)this.bindingSource_11).BeginInit();
			this.panel_24.SuspendLayout();
			this.panel_25.SuspendLayout();
			((ISupportInitialize)this.dataGridView_4).BeginInit();
			((ISupportInitialize)this.dataGridView_5).BeginInit();
			((ISupportInitialize)this.bindingSource_14).BeginInit();
			this.tableLayoutPanel_2.SuspendLayout();
			((ISupportInitialize)this.bindingSource_3).BeginInit();
			((ISupportInitialize)this.bindingSource_4).BeginInit();
			((ISupportInitialize)this.bindingSource_5).BeginInit();
			((ISupportInitialize)this.bindingSource_6).BeginInit();
			((ISupportInitialize)this.bindingSource_2).BeginInit();
			((ISupportInitialize)this.riZoLnrtjNx).BeginInit();
			((ISupportInitialize)this.bindingSource_13).BeginInit();
			((ISupportInitialize)this.bindingSource_16).BeginInit();
			base.SuspendLayout();
			this.tableLayoutPanel_0.ColumnCount = 1;
			this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel_0.Controls.Add(this.treeView_0, 0, 1);
			this.tableLayoutPanel_0.Controls.Add(this.toolStrip_0, 0, 0);
			this.tableLayoutPanel_0.Dock = DockStyle.Fill;
			this.tableLayoutPanel_0.Location = new Point(3, 3);
			this.tableLayoutPanel_0.Name = "tlpTreeView";
			this.tableLayoutPanel_0.RowCount = 2;
			this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Absolute, 25f));
			this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel_0.Size = new Size(206, 556);
			this.tableLayoutPanel_0.TabIndex = 0;
			this.treeView_0.Dock = DockStyle.Fill;
			this.treeView_0.HideSelection = false;
			this.treeView_0.Location = new Point(3, 28);
			this.treeView_0.MinimumSize = new Size(200, 4);
			this.treeView_0.Name = "trvObject";
			this.treeView_0.Size = new Size(200, 525);
			this.treeView_0.TabIndex = 6;
			this.treeView_0.BeforeExpand += this.treeView_0_BeforeExpand;
			this.treeView_0.AfterSelect += this.treeView_0_AfterSelect;
			this.toolStrip_0.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripTextBox_0,
				this.toolStripButton_0,
				this.toolStripButton_1,
				this.toolStripSeparator_0,
				this.toolStripButton_2
			});
			this.toolStrip_0.Location = new Point(0, 0);
			this.toolStrip_0.Name = "tsTree";
			this.toolStrip_0.Size = new Size(206, 25);
			this.toolStrip_0.TabIndex = 5;
			this.toolStrip_0.Text = "Панель инструментов дерва данных";
			this.toolStripTextBox_0.Name = "tstbFindObj";
			this.toolStripTextBox_0.Size = new Size(100, 25);
			this.toolStripTextBox_0.KeyPress += this.toolStripTextBox_0_KeyPress;
			this.toolStripButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_0.Image = (Image)componentResourceManager.GetObject("tsbFindObj.Image");
			this.toolStripButton_0.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_0.Name = "tsbFindObj";
			this.toolStripButton_0.Size = new Size(23, 22);
			this.toolStripButton_0.Text = "Найти";
			this.toolStripButton_0.Click += this.toolStripButton_0_Click;
			this.toolStripButton_1.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_1.Image = (Image)componentResourceManager.GetObject("tsbFindNextObj.Image");
			this.toolStripButton_1.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_1.Name = "tsbFindNextObj";
			this.toolStripButton_1.Size = new Size(23, 22);
			this.toolStripButton_1.Text = "Найти далее";
			this.toolStripButton_1.Click += this.toolStripButton_1_Click;
			this.toolStripSeparator_0.Name = "toolStripSeparator10";
			this.toolStripSeparator_0.Size = new Size(6, 25);
			this.toolStripButton_2.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_2.Image = (Image)componentResourceManager.GetObject("tsbSortTree.Image");
			this.toolStripButton_2.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_2.Name = "tsbSortTree";
			this.toolStripButton_2.Size = new Size(23, 22);
			this.toolStripButton_2.Text = "Сортировка";
			this.toolStripButton_2.Click += this.toolStripButton_2_Click;
			this.tableLayoutPanel_1.ColumnCount = 3;
			this.tableLayoutPanel_1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 4f));
			this.tableLayoutPanel_1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel_1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 4f));
			this.tableLayoutPanel_1.Controls.Add(this.toolStrip_1, 0, 0);
			this.tableLayoutPanel_1.Controls.Add(this.button_0, 1, 4);
			this.tableLayoutPanel_1.Controls.Add(this.tableLayoutPanel_3, 1, 2);
			this.tableLayoutPanel_1.Controls.Add(this.dataGridView_3, 1, 1);
			this.tableLayoutPanel_1.Controls.Add(this.tableLayoutPanel_4, 1, 3);
			this.tableLayoutPanel_1.Dock = DockStyle.Fill;
			this.tableLayoutPanel_1.Location = new Point(215, 3);
			this.tableLayoutPanel_1.Name = "tlpGeneral";
			this.tableLayoutPanel_1.RowCount = 5;
			this.tableLayoutPanel_1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25f));
			this.tableLayoutPanel_1.RowStyles.Add(new RowStyle(SizeType.Absolute, 97f));
			this.tableLayoutPanel_1.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
			this.tableLayoutPanel_1.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
			this.tableLayoutPanel_1.RowStyles.Add(new RowStyle(SizeType.Absolute, 37f));
			this.tableLayoutPanel_1.Size = new Size(816, 556);
			this.tableLayoutPanel_1.TabIndex = 0;
			this.tableLayoutPanel_1.SetColumnSpan(this.toolStrip_1, 3);
			this.toolStrip_1.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripButton_3,
				this.toolStripButton_4,
				this.toolStripButton_5,
				this.toolStripSeparator_1,
				this.toolStripButton_6,
				this.toolStripSeparator_3,
				this.toolStripButton_7,
				this.toolStripSeparator_4,
				this.toolStripSplitButton_1,
				this.toolStripSeparator_2,
				this.toolStripLabel_0,
				this.toolStripComboBox_0,
				this.toolStripSplitButton_0,
				this.toolStripButton_8,
				this.toolStripButton_9
			});
			this.toolStrip_1.Location = new Point(0, 0);
			this.toolStrip_1.Name = "tsGeneral";
			this.toolStrip_1.Size = new Size(816, 25);
			this.toolStrip_1.TabIndex = 1;
			this.toolStrip_1.Text = "toolStrip1";
			this.toolStripButton_3.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_3.Image = (Image)componentResourceManager.GetObject("tssbMeasAdd.Image");
			this.toolStripButton_3.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_3.Name = "tssbMeasAdd";
			this.toolStripButton_3.Size = new Size(23, 22);
			this.toolStripButton_3.Text = "Добавить";
			this.toolStripButton_3.Click += this.toolStripButton_3_Click;
			this.toolStripButton_4.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_4.Image = (Image)componentResourceManager.GetObject("tsbMeasEdit.Image");
			this.toolStripButton_4.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_4.Name = "tsbMeasEdit";
			this.toolStripButton_4.Size = new Size(23, 22);
			this.toolStripButton_4.Text = "Редактировать";
			this.toolStripButton_4.Click += this.toolStripButton_4_Click;
			this.toolStripButton_5.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_5.Image = (Image)componentResourceManager.GetObject("tsbMeasDelete.Image");
			this.toolStripButton_5.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_5.Name = "tsbMeasDelete";
			this.toolStripButton_5.Size = new Size(23, 22);
			this.toolStripButton_5.Text = "Удалить";
			this.toolStripButton_5.Click += this.toolStripButton_5_Click;
			this.toolStripSeparator_1.Name = "toolStripSeparator2";
			this.toolStripSeparator_1.Size = new Size(6, 25);
			this.toolStripButton_6.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_6.Image = (Image)componentResourceManager.GetObject("tsbMeasRefresh.Image");
			this.toolStripButton_6.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_6.Name = "tsbMeasRefresh";
			this.toolStripButton_6.Size = new Size(23, 22);
			this.toolStripButton_6.Text = "Обновить";
			this.toolStripButton_6.Click += this.toolStripButton_6_Click;
			this.toolStripSeparator_3.Name = "toolStripSeparator3";
			this.toolStripSeparator_3.Size = new Size(6, 25);
			this.toolStripButton_7.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_7.Image = (Image)componentResourceManager.GetObject("tsbPrint.Image");
			this.toolStripButton_7.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_7.Name = "tsbPrint";
			this.toolStripButton_7.Size = new Size(23, 22);
			this.toolStripButton_7.Text = "Печать";
			this.toolStripButton_7.Click += this.toolStripButton_7_Click;
			this.toolStripSeparator_4.Name = "tssPrint";
			this.toolStripSeparator_4.Size = new Size(6, 25);
			this.toolStripSplitButton_1.DisplayStyle = ToolStripItemDisplayStyle.Text;
			this.toolStripSplitButton_1.DropDownItems.AddRange(new ToolStripItem[]
			{
				this.toolStripMenuItem_4,
				this.toolStripMenuItem_5
			});
			this.toolStripSplitButton_1.Image = (Image)componentResourceManager.GetObject("tssbMeasType.Image");
			this.toolStripSplitButton_1.ImageTransparentColor = Color.Magenta;
			this.toolStripSplitButton_1.Name = "tssbMeasType";
			this.toolStripSplitButton_1.Size = new Size(58, 22);
			this.toolStripSplitButton_1.Text = "Замер";
			this.toolStripMenuItem_4.CheckOnClick = true;
			this.toolStripMenuItem_4.Name = "tsmiMeasLow";
			this.toolStripMenuItem_4.Size = new Size(113, 22);
			this.toolStripMenuItem_4.Text = "0,4 кВ";
			this.toolStripMenuItem_4.CheckedChanged += this.toolStripMenuItem_5_CheckedChanged;
			this.toolStripMenuItem_5.CheckOnClick = true;
			this.toolStripMenuItem_5.Name = "tsmiMeasHigh";
			this.toolStripMenuItem_5.Size = new Size(113, 22);
			this.toolStripMenuItem_5.Text = "6-10 кВ";
			this.toolStripMenuItem_5.CheckedChanged += this.toolStripMenuItem_5_CheckedChanged;
			this.toolStripSeparator_2.Name = "toolStripSeparator1";
			this.toolStripSeparator_2.Size = new Size(6, 25);
			this.toolStripLabel_0.Name = "toolStripLabel1";
			this.toolStripLabel_0.Size = new Size(55, 22);
			this.toolStripLabel_0.Text = "Период: ";
			this.toolStripComboBox_0.Name = "tscbMeasYear";
			this.toolStripComboBox_0.Size = new Size(80, 25);
			this.toolStripSplitButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripSplitButton_0.DropDownItems.AddRange(new ToolStripItem[]
			{
				this.toolStripMenuItem_0,
				this.toolStripMenuItem_1,
				this.toolStripMenuItem_2,
				this.toolStripMenuItem_3,
				this.rKroglMajQE,
				this.toolStripMenuItem_6
			});
			this.toolStripSplitButton_0.Image = (Image)componentResourceManager.GetObject("tssbReports.Image");
			this.toolStripSplitButton_0.ImageTransparentColor = Color.Magenta;
			this.toolStripSplitButton_0.Name = "tssbReports";
			this.toolStripSplitButton_0.Size = new Size(32, 22);
			this.toolStripSplitButton_0.Text = "Отчеты";
			this.toolStripMenuItem_0.Name = "tsmiExcessLoad";
			this.toolStripMenuItem_0.Size = new Size(254, 22);
			this.toolStripMenuItem_0.Text = "Превышение нагрузки";
			this.toolStripMenuItem_0.Click += this.toolStripMenuItem_0_Click;
			this.toolStripMenuItem_1.Name = "tsmiCoefficientLoading";
			this.toolStripMenuItem_1.Size = new Size(254, 22);
			this.toolStripMenuItem_1.Text = "Коэфициент загрузки";
			this.toolStripMenuItem_1.Click += this.toolStripMenuItem_1_Click;
			this.toolStripMenuItem_2.Name = "tsmiCoefficientIrregularity";
			this.toolStripMenuItem_2.Size = new Size(254, 22);
			this.toolStripMenuItem_2.Text = "Коэффициент неравномерности";
			this.toolStripMenuItem_2.Click += this.toolStripMenuItem_2_Click;
			this.toolStripMenuItem_3.Name = "tsmiTransfByCP";
			this.toolStripMenuItem_3.Size = new Size(254, 22);
			this.toolStripMenuItem_3.Text = "Трансформаторы по ЦП";
			this.toolStripMenuItem_3.Visible = false;
			this.rKroglMajQE.Name = "объемСвободнойМощностиToolStripMenuItem";
			this.rKroglMajQE.Size = new Size(254, 22);
			this.rKroglMajQE.Text = "Объем свободной мощности";
			this.rKroglMajQE.Click += this.rKroglMajQE_Click;
			this.toolStripMenuItem_6.Name = "toolStripMenuItemMeasExist";
			this.toolStripMenuItem_6.Size = new Size(254, 22);
			this.toolStripMenuItem_6.Text = "Наличие замеров";
			this.toolStripMenuItem_6.Click += this.toolStripMenuItem_6_Click;
			this.toolStripButton_8.DisplayStyle = ToolStripItemDisplayStyle.Text;
			this.toolStripButton_8.Image = (Image)componentResourceManager.GetObject("toolStripButton1.Image");
			this.toolStripButton_8.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_8.Name = "toolStripButton1";
			this.toolStripButton_8.Size = new Size(72, 22);
			this.toolStripButton_8.Text = "insert idBus";
			this.toolStripButton_8.Visible = false;
			this.toolStripButton_8.Click += this.toolStripButton_8_Click;
			this.toolStripButton_9.DisplayStyle = ToolStripItemDisplayStyle.Text;
			this.toolStripButton_9.Image = (Image)componentResourceManager.GetObject("btnFAQ.Image");
			this.toolStripButton_9.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_9.Name = "btnFAQ";
			this.toolStripButton_9.Size = new Size(60, 22);
			this.toolStripButton_9.Text = "Помощь";
			this.toolStripButton_9.Click += this.UaAoRsTxyRR;
			this.button_0.Dock = DockStyle.Right;
			this.button_0.Location = new Point(717, 524);
			this.button_0.Margin = new Padding(10, 6, 15, 6);
			this.button_0.Name = "btnCancel";
			this.button_0.Size = new Size(80, 26);
			this.button_0.TabIndex = 5;
			this.button_0.Text = "Закрыть";
			this.button_0.UseVisualStyleBackColor = true;
			this.button_0.Click += this.button_0_Click;
			this.tableLayoutPanel_3.ColumnCount = 3;
			this.tableLayoutPanel_3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 158f));
			this.tableLayoutPanel_3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 267f));
			this.tableLayoutPanel_3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel_3.Controls.Add(this.comboBox_0, 1, 0);
			this.tableLayoutPanel_3.Controls.Add(this.label_0, 0, 0);
			this.tableLayoutPanel_3.Controls.Add(this.tabControl_0, 0, 4);
			this.tableLayoutPanel_3.Controls.Add(this.panel_0, 0, 1);
			this.tableLayoutPanel_3.Controls.Add(this.dataGridView_1, 0, 3);
			this.tableLayoutPanel_3.Controls.Add(this.panel_6, 2, 1);
			this.tableLayoutPanel_3.Controls.Add(this.dataGridView_2, 0, 2);
			this.tableLayoutPanel_3.Dock = DockStyle.Fill;
			this.tableLayoutPanel_3.Location = new Point(7, 125);
			this.tableLayoutPanel_3.Name = "tlpMeasurementLow";
			this.tableLayoutPanel_3.RowCount = 5;
			this.tableLayoutPanel_3.RowStyles.Add(new RowStyle(SizeType.Absolute, 21f));
			this.tableLayoutPanel_3.RowStyles.Add(new RowStyle(SizeType.Absolute, 108f));
			this.tableLayoutPanel_3.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel_3.RowStyles.Add(new RowStyle(SizeType.Absolute, 31f));
			this.tableLayoutPanel_3.RowStyles.Add(new RowStyle(SizeType.Absolute, 120f));
			this.tableLayoutPanel_3.Size = new Size(802, 192);
			this.tableLayoutPanel_3.TabIndex = 0;
			this.comboBox_0.DataSource = this.bindingSource_15;
			this.comboBox_0.DisplayMember = "Name";
			this.comboBox_0.Dock = DockStyle.Left;
			this.comboBox_0.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_0.FormattingEnabled = true;
			this.comboBox_0.Location = new Point(161, 0);
			this.comboBox_0.Margin = new Padding(3, 0, 3, 3);
			this.comboBox_0.Name = "cbBusesTransfLV";
			this.comboBox_0.Size = new Size(110, 21);
			this.comboBox_0.TabIndex = 1;
			this.comboBox_0.ValueMember = "idBus";
			this.bindingSource_15.DataMember = "vJ_BusesTransfs";
			this.bindingSource_15.DataSource = this.class255_0;
			this.class255_0.DataSetName = "DataSetGES";
			this.class255_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
			this.label_0.BorderStyle = BorderStyle.FixedSingle;
			this.label_0.Dock = DockStyle.Fill;
			this.label_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label_0.Location = new Point(3, 0);
			this.label_0.Name = "labelTrans";
			this.label_0.Size = new Size(152, 21);
			this.label_0.TabIndex = 10;
			this.label_0.Text = "Секция шин №";
			this.label_0.TextAlign = ContentAlignment.MiddleCenter;
			this.tableLayoutPanel_3.SetColumnSpan(this.tabControl_0, 3);
			this.tabControl_0.Controls.Add(this.tabPage_0);
			this.tabControl_0.Controls.Add(this.tabPage_1);
			this.tabControl_0.Dock = DockStyle.Fill;
			this.tabControl_0.Location = new Point(3, 75);
			this.tabControl_0.Name = "tcMeasurement";
			this.tabControl_0.SelectedIndex = 0;
			this.tabControl_0.Size = new Size(796, 114);
			this.tabControl_0.TabIndex = 14;
			this.tabControl_0.SelectedIndexChanged += this.tabControl_0_SelectedIndexChanged;
			this.tabPage_0.Controls.Add(this.label_1);
			this.tabPage_0.Controls.Add(this.label_2);
			this.tabPage_0.Controls.Add(this.label_3);
			this.tabPage_0.Controls.Add(this.label_4);
			this.tabPage_0.Controls.Add(this.label_5);
			this.tabPage_0.Controls.Add(this.label_6);
			this.tabPage_0.Controls.Add(this.textBox_0);
			this.tabPage_0.Controls.Add(this.textBox_1);
			this.tabPage_0.Controls.Add(this.textBox_2);
			this.tabPage_0.Controls.Add(this.textBox_3);
			this.tabPage_0.Controls.Add(this.textBox_4);
			this.tabPage_0.Controls.Add(this.textBox_5);
			this.tabPage_0.Location = new Point(4, 22);
			this.tabPage_0.Name = "tpRatio";
			this.tabPage_0.Padding = new Padding(3);
			this.tabPage_0.Size = new Size(788, 88);
			this.tabPage_0.TabIndex = 1;
			this.tabPage_0.Text = "Коэффициент";
			this.tabPage_0.UseVisualStyleBackColor = true;
			this.label_1.AutoSize = true;
			this.label_1.Location = new Point(455, 53);
			this.label_1.Name = "label6";
			this.label_1.Size = new Size(237, 13);
			this.label_1.TabIndex = 11;
			this.label_1.Text = "Коэффициент неравномерности Кл.фаз Кз %";
			this.label_2.AutoSize = true;
			this.label_2.Location = new Point(455, 27);
			this.label_2.Name = "label5";
			this.label_2.Size = new Size(237, 13);
			this.label_2.TabIndex = 10;
			this.label_2.Text = "Коэффициент неравномерности Кл.фаз Кз %";
			this.label_3.AutoSize = true;
			this.label_3.Location = new Point(133, 53);
			this.label_3.Name = "label4";
			this.label_3.Size = new Size(242, 13);
			this.label_3.TabIndex = 9;
			this.label_3.Text = "Коэффициент нагрузки трансформатора Кз %";
			this.label_4.AutoSize = true;
			this.label_4.Location = new Point(133, 27);
			this.label_4.Name = "label3";
			this.label_4.Size = new Size(242, 13);
			this.label_4.TabIndex = 8;
			this.label_4.Text = "Коэффициент нагрузки трансформатора Кз %";
			this.label_5.AutoSize = true;
			this.label_5.Location = new Point(6, 53);
			this.label_5.Name = "label2";
			this.label_5.Size = new Size(58, 13);
			this.label_5.TabIndex = 7;
			this.label_5.Text = "Вечер  Iср";
			this.label_6.AutoSize = true;
			this.label_6.Location = new Point(6, 27);
			this.label_6.Name = "label1";
			this.label_6.Size = new Size(58, 13);
			this.label_6.TabIndex = 6;
			this.label_6.Text = "День   Iср";
			this.textBox_0.BackColor = Color.White;
			this.textBox_0.Location = new Point(707, 50);
			this.textBox_0.Name = "tbKNKFn";
			this.textBox_0.ReadOnly = true;
			this.textBox_0.Size = new Size(36, 20);
			this.textBox_0.TabIndex = 5;
			this.textBox_1.BackColor = Color.White;
			this.textBox_1.Location = new Point(707, 24);
			this.textBox_1.Name = "tbKNKFd";
			this.textBox_1.ReadOnly = true;
			this.textBox_1.Size = new Size(36, 20);
			this.textBox_1.TabIndex = 4;
			this.textBox_2.BackColor = Color.White;
			this.textBox_2.Location = new Point(394, 50);
			this.textBox_2.Name = "tbKNTn";
			this.textBox_2.ReadOnly = true;
			this.textBox_2.Size = new Size(36, 20);
			this.textBox_2.TabIndex = 3;
			this.textBox_3.BackColor = Color.White;
			this.textBox_3.Location = new Point(394, 24);
			this.textBox_3.Name = "tbKNTd";
			this.textBox_3.ReadOnly = true;
			this.textBox_3.Size = new Size(36, 20);
			this.textBox_3.TabIndex = 2;
			this.textBox_4.BackColor = Color.White;
			this.textBox_4.Location = new Point(76, 50);
			this.textBox_4.Name = "tbIsrn";
			this.textBox_4.ReadOnly = true;
			this.textBox_4.Size = new Size(36, 20);
			this.textBox_4.TabIndex = 1;
			this.textBox_5.BackColor = Color.White;
			this.textBox_5.Location = new Point(76, 24);
			this.textBox_5.Name = "tbIsrd";
			this.textBox_5.ReadOnly = true;
			this.textBox_5.Size = new Size(36, 20);
			this.textBox_5.TabIndex = 0;
			this.tabPage_1.Controls.Add(this.dataGridView_0);
			this.tabPage_1.Location = new Point(4, 22);
			this.tabPage_1.Name = "tpAddress";
			this.tabPage_1.Padding = new Padding(3);
			this.tabPage_1.Size = new Size(788, 88);
			this.tabPage_1.TabIndex = 0;
			this.tabPage_1.Text = "Адреса";
			this.tabPage_1.UseVisualStyleBackColor = true;
			this.dataGridView_0.AllowUserToAddRows = false;
			this.dataGridView_0.AllowUserToDeleteRows = false;
			this.dataGridView_0.AllowUserToOrderColumns = true;
			this.dataGridView_0.AllowUserToResizeRows = false;
			this.dataGridView_0.AutoGenerateColumns = false;
			this.dataGridView_0.BackgroundColor = Color.White;
			dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle.BackColor = SystemColors.Control;
			dataGridViewCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
			this.dataGridView_0.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
			this.dataGridView_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView_0.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewTextBoxColumn_140,
				this.dataGridViewTextBoxColumn_141,
				this.dataGridViewTextBoxColumn_142,
				this.dataGridViewTextBoxColumn_143,
				this.dataGridViewTextBoxColumn_144
			});
			this.dataGridView_0.DataSource = this.bindingSource_8;
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = Color.White;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
			this.dataGridView_0.DefaultCellStyle = dataGridViewCellStyle2;
			this.dataGridView_0.Dock = DockStyle.Fill;
			this.dataGridView_0.Location = new Point(3, 3);
			this.dataGridView_0.MultiSelect = false;
			this.dataGridView_0.Name = "dgvAbnObj";
			this.dataGridView_0.ReadOnly = true;
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = SystemColors.Control;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
			this.dataGridView_0.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.dataGridView_0.RowHeadersVisible = false;
			this.dataGridView_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView_0.Size = new Size(782, 82);
			this.dataGridView_0.TabIndex = 12;
			this.dataGridViewTextBoxColumn_140.DataPropertyName = "idSchmObj";
			this.dataGridViewTextBoxColumn_140.HeaderText = "idSchmObj";
			this.dataGridViewTextBoxColumn_140.Name = "idSchmObjDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_140.ReadOnly = true;
			this.dataGridViewTextBoxColumn_140.Visible = false;
			this.dataGridViewTextBoxColumn_141.DataPropertyName = "Street";
			this.dataGridViewTextBoxColumn_141.HeaderText = "Улица";
			this.dataGridViewTextBoxColumn_141.Name = "streetDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_141.ReadOnly = true;
			this.dataGridViewTextBoxColumn_141.Width = 180;
			this.dataGridViewTextBoxColumn_142.DataPropertyName = "House";
			this.dataGridViewTextBoxColumn_142.HeaderText = "Дом";
			this.dataGridViewTextBoxColumn_142.Name = "houseDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_142.ReadOnly = true;
			this.dataGridViewTextBoxColumn_142.Width = 50;
			this.dataGridViewTextBoxColumn_143.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_143.DataPropertyName = "Name";
			this.dataGridViewTextBoxColumn_143.HeaderText = "Наименование";
			this.dataGridViewTextBoxColumn_143.Name = "nameDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_143.ReadOnly = true;
			this.dataGridViewTextBoxColumn_144.DataPropertyName = "codeAbonent";
			this.dataGridViewTextBoxColumn_144.HeaderText = "Номер договора";
			this.dataGridViewTextBoxColumn_144.Name = "codeAbonent";
			this.dataGridViewTextBoxColumn_144.ReadOnly = true;
			this.dataGridViewTextBoxColumn_144.Width = 120;
			this.bindingSource_8.DataMember = "vJ_MeasAbnObj";
			this.bindingSource_8.DataSource = this.class255_0;
			this.bindingSource_8.Sort = "";
			this.tableLayoutPanel_3.SetColumnSpan(this.panel_0, 2);
			this.panel_0.Controls.Add(this.label_7);
			this.panel_0.Controls.Add(this.label_8);
			this.panel_0.Controls.Add(this.label_9);
			this.panel_0.Controls.Add(this.label_10);
			this.panel_0.Controls.Add(this.label_11);
			this.panel_0.Controls.Add(this.panel_1);
			this.panel_0.Controls.Add(this.panel_2);
			this.panel_0.Controls.Add(this.panel_3);
			this.panel_0.Controls.Add(this.panel_4);
			this.panel_0.Controls.Add(this.panel_5);
			this.panel_0.Location = new Point(3, 24);
			this.panel_0.Name = "pnlTransfReference";
			this.panel_0.Size = new Size(419, 102);
			this.panel_0.TabIndex = 8;
			this.label_7.BorderStyle = BorderStyle.FixedSingle;
			this.label_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label_7.Location = new Point(0, 0);
			this.label_7.Name = "label8";
			this.label_7.Size = new Size(124, 51);
			this.label_7.TabIndex = 0;
			this.label_7.Text = "Трансформатор";
			this.label_7.TextAlign = ContentAlignment.MiddleCenter;
			this.label_8.BorderStyle = BorderStyle.FixedSingle;
			this.label_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label_8.Location = new Point(123, 0);
			this.label_8.Name = "label9";
			this.label_8.Size = new Size(75, 51);
			this.label_8.TabIndex = 0;
			this.label_8.Text = "Мощность кВт";
			this.label_8.TextAlign = ContentAlignment.MiddleCenter;
			this.label_9.BorderStyle = BorderStyle.FixedSingle;
			this.label_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label_9.Location = new Point(197, 0);
			this.label_9.Name = "label10";
			this.label_9.Size = new Size(51, 51);
			this.label_9.TabIndex = 0;
			this.label_9.Text = "Uвн\r\n(раб)";
			this.label_9.TextAlign = ContentAlignment.MiddleCenter;
			this.label_10.BorderStyle = BorderStyle.FixedSingle;
			this.label_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label_10.Location = new Point(247, 0);
			this.label_10.Name = "label11";
			this.label_10.Size = new Size(47, 51);
			this.label_10.TabIndex = 0;
			this.label_10.Text = "Iном\r\nА";
			this.label_10.TextAlign = ContentAlignment.MiddleCenter;
			this.label_11.BorderStyle = BorderStyle.FixedSingle;
			this.label_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label_11.Location = new Point(292, 0);
			this.label_11.Name = "label12";
			this.label_11.Size = new Size(127, 51);
			this.label_11.TabIndex = 0;
			this.label_11.Text = "Положение\r\nпереключателя\r\nнапряжения";
			this.label_11.TextAlign = ContentAlignment.MiddleCenter;
			this.panel_1.BorderStyle = BorderStyle.FixedSingle;
			this.panel_1.Controls.Add(this.YfQoLrPgfVl);
			this.panel_1.Controls.Add(this.textBox_6);
			this.panel_1.Controls.Add(this.label_12);
			this.panel_1.Controls.Add(this.label_13);
			this.panel_1.Location = new Point(0, 50);
			this.panel_1.Name = "panelTransType";
			this.panel_1.Size = new Size(124, 52);
			this.panel_1.TabIndex = 5;
			this.YfQoLrPgfVl.BackColor = Color.White;
			this.YfQoLrPgfVl.DataBindings.Add(new Binding("Text", this.bindingSource_0, "Type", true));
			this.YfQoLrPgfVl.Location = new Point(36, 2);
			this.YfQoLrPgfVl.Name = "tbTransType";
			this.YfQoLrPgfVl.ReadOnly = true;
			this.YfQoLrPgfVl.Size = new Size(79, 20);
			this.YfQoLrPgfVl.TabIndex = 2;
			this.bindingSource_0.DataMember = "fn_J_MeasTransfPassport";
			this.bindingSource_0.DataSource = this.class255_0;
			this.textBox_6.BackColor = Color.White;
			this.textBox_6.DataBindings.Add(new Binding("Text", this.bindingSource_0, "InvNumber", true));
			this.textBox_6.Location = new Point(36, 28);
			this.textBox_6.Name = "tbTransNumber";
			this.textBox_6.ReadOnly = true;
			this.textBox_6.Size = new Size(79, 20);
			this.textBox_6.TabIndex = 2;
			this.label_12.AutoSize = true;
			this.label_12.Location = new Point(4, 5);
			this.label_12.Name = "label18";
			this.label_12.Size = new Size(26, 13);
			this.label_12.TabIndex = 4;
			this.label_12.Text = "Тип";
			this.label_13.AutoSize = true;
			this.label_13.Location = new Point(8, 31);
			this.label_13.Name = "label19";
			this.label_13.Size = new Size(18, 13);
			this.label_13.TabIndex = 4;
			this.label_13.Text = "№";
			this.panel_2.BorderStyle = BorderStyle.FixedSingle;
			this.panel_2.Controls.Add(this.comboBox_1);
			this.panel_2.Location = new Point(293, 50);
			this.panel_2.Name = "panel8";
			this.panel_2.Size = new Size(126, 52);
			this.panel_2.TabIndex = 5;
			this.comboBox_1.BackColor = Color.White;
			this.comboBox_1.DataBindings.Add(new Binding("SelectedValue", this.bindingSource_1, "idSwitchPosition", true));
			this.comboBox_1.DataSource = this.bindingSource_12;
			this.comboBox_1.DisplayMember = "Name";
			this.comboBox_1.DropDownStyle = ComboBoxStyle.Simple;
			this.comboBox_1.FormattingEnabled = true;
			this.comboBox_1.Location = new Point(2, 15);
			this.comboBox_1.Name = "cbSwitchPosition";
			this.comboBox_1.Size = new Size(120, 21);
			this.comboBox_1.TabIndex = 3;
			this.comboBox_1.ValueMember = "id";
			this.bindingSource_1.DataMember = "tJ_MeasVoltageTransf";
			this.bindingSource_1.DataSource = this.class255_0;
			this.bindingSource_12.DataMember = "tR_Classifier";
			this.bindingSource_12.DataSource = this.class255_0;
			this.bindingSource_12.Filter = "ParentKey = ';Measurement;Switch;'";
			this.panel_3.BorderStyle = BorderStyle.FixedSingle;
			this.panel_3.Controls.Add(this.textBox_7);
			this.panel_3.Location = new Point(247, 50);
			this.panel_3.Name = "panel7";
			this.panel_3.Size = new Size(47, 52);
			this.panel_3.TabIndex = 5;
			this.textBox_7.BackColor = Color.White;
			this.textBox_7.DataBindings.Add(new Binding("Text", this.bindingSource_0, "Inom", true));
			this.textBox_7.Location = new Point(2, 15);
			this.textBox_7.Name = "tbTransAmperage";
			this.textBox_7.ReadOnly = true;
			this.textBox_7.Size = new Size(40, 20);
			this.textBox_7.TabIndex = 2;
			this.panel_4.BorderStyle = BorderStyle.FixedSingle;
			this.panel_4.Controls.Add(this.textBox_8);
			this.panel_4.Location = new Point(123, 50);
			this.panel_4.Name = "panel5";
			this.panel_4.Size = new Size(75, 52);
			this.panel_4.TabIndex = 5;
			this.textBox_8.BackColor = Color.White;
			this.textBox_8.DataBindings.Add(new Binding("Text", this.bindingSource_0, "Power", true));
			this.textBox_8.Location = new Point(3, 15);
			this.textBox_8.Name = "tbTransPower";
			this.textBox_8.ReadOnly = true;
			this.textBox_8.Size = new Size(67, 20);
			this.textBox_8.TabIndex = 2;
			this.panel_5.BorderStyle = BorderStyle.FixedSingle;
			this.panel_5.Controls.Add(this.textBox_9);
			this.panel_5.Location = new Point(197, 50);
			this.panel_5.Name = "panel6";
			this.panel_5.Size = new Size(51, 52);
			this.panel_5.TabIndex = 5;
			this.textBox_9.BackColor = Color.White;
			this.textBox_9.DataBindings.Add(new Binding("Text", this.bindingSource_0, "Unom", true));
			this.textBox_9.Location = new Point(2, 15);
			this.textBox_9.Name = "tbTransVoltage";
			this.textBox_9.ReadOnly = true;
			this.textBox_9.Size = new Size(44, 20);
			this.textBox_9.TabIndex = 2;
			this.dataGridView_1.AllowUserToResizeRows = false;
			this.dataGridView_1.BackgroundColor = Color.White;
			dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = SystemColors.Control;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
			this.dataGridView_1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
			this.dataGridView_1.ColumnHeadersVisible = false;
			this.dataGridView_1.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewTextBoxColumn_130,
				this.dataGridViewTextBoxColumn_131,
				this.dataGridViewTextBoxColumn_132,
				this.dataGridViewTextBoxColumn_133,
				this.dataGridViewTextBoxColumn_134,
				this.dataGridViewTextBoxColumn_135,
				this.dataGridViewTextBoxColumn_136,
				this.dataGridViewTextBoxColumn_137,
				this.dataGridViewTextBoxColumn_138,
				this.dataGridViewTextBoxColumn_139
			});
			this.tableLayoutPanel_3.SetColumnSpan(this.dataGridView_1, 3);
			dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle5.BackColor = Color.White;
			dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle5.ForeColor = Color.Black;
			dataGridViewCellStyle5.SelectionBackColor = Color.White;
			dataGridViewCellStyle5.SelectionForeColor = Color.Black;
			dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
			this.dataGridView_1.DefaultCellStyle = dataGridViewCellStyle5;
			this.dataGridView_1.Dock = DockStyle.Fill;
			this.dataGridView_1.Location = new Point(3, 44);
			this.dataGridView_1.Margin = new Padding(3, 3, 7, 3);
			this.dataGridView_1.MultiSelect = false;
			this.dataGridView_1.Name = "dgvSumCable";
			this.dataGridView_1.ReadOnly = true;
			dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle6.BackColor = SystemColors.Control;
			dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
			this.dataGridView_1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
			this.dataGridView_1.RowHeadersVisible = false;
			this.dataGridView_1.ScrollBars = ScrollBars.None;
			this.dataGridView_1.Size = new Size(792, 25);
			this.dataGridView_1.TabIndex = 15;
			this.dataGridViewTextBoxColumn_130.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			this.dataGridViewTextBoxColumn_130.HeaderText = "SumName";
			this.dataGridViewTextBoxColumn_130.Name = "SumName";
			this.dataGridViewTextBoxColumn_130.ReadOnly = true;
			this.dataGridViewTextBoxColumn_130.Width = 660;
			this.dataGridViewTextBoxColumn_131.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			this.dataGridViewTextBoxColumn_131.HeaderText = "ad";
			this.dataGridViewTextBoxColumn_131.Name = "ad";
			this.dataGridViewTextBoxColumn_131.ReadOnly = true;
			this.dataGridViewTextBoxColumn_131.Width = 40;
			this.dataGridViewTextBoxColumn_132.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			this.dataGridViewTextBoxColumn_132.HeaderText = "an";
			this.dataGridViewTextBoxColumn_132.Name = "an";
			this.dataGridViewTextBoxColumn_132.ReadOnly = true;
			this.dataGridViewTextBoxColumn_132.Width = 40;
			this.dataGridViewTextBoxColumn_133.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			this.dataGridViewTextBoxColumn_133.HeaderText = "bd";
			this.dataGridViewTextBoxColumn_133.Name = "bd";
			this.dataGridViewTextBoxColumn_133.ReadOnly = true;
			this.dataGridViewTextBoxColumn_133.Width = 40;
			this.dataGridViewTextBoxColumn_134.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			this.dataGridViewTextBoxColumn_134.HeaderText = "bn";
			this.dataGridViewTextBoxColumn_134.Name = "bn";
			this.dataGridViewTextBoxColumn_134.ReadOnly = true;
			this.dataGridViewTextBoxColumn_134.Width = 40;
			this.dataGridViewTextBoxColumn_135.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			this.dataGridViewTextBoxColumn_135.HeaderText = "cd";
			this.dataGridViewTextBoxColumn_135.Name = "cd";
			this.dataGridViewTextBoxColumn_135.ReadOnly = true;
			this.dataGridViewTextBoxColumn_135.Width = 40;
			this.dataGridViewTextBoxColumn_136.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			this.dataGridViewTextBoxColumn_136.HeaderText = "cn";
			this.dataGridViewTextBoxColumn_136.Name = "cn";
			this.dataGridViewTextBoxColumn_136.ReadOnly = true;
			this.dataGridViewTextBoxColumn_136.Width = 40;
			this.dataGridViewTextBoxColumn_137.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			this.dataGridViewTextBoxColumn_137.HeaderText = "od";
			this.dataGridViewTextBoxColumn_137.Name = "od";
			this.dataGridViewTextBoxColumn_137.ReadOnly = true;
			this.dataGridViewTextBoxColumn_137.Width = 40;
			this.dataGridViewTextBoxColumn_138.HeaderText = "on";
			this.dataGridViewTextBoxColumn_138.Name = "on";
			this.dataGridViewTextBoxColumn_138.ReadOnly = true;
			this.dataGridViewTextBoxColumn_138.Width = 40;
			this.dataGridViewTextBoxColumn_139.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_139.HeaderText = "Comment";
			this.dataGridViewTextBoxColumn_139.MinimumWidth = 80;
			this.dataGridViewTextBoxColumn_139.Name = "Column1";
			this.dataGridViewTextBoxColumn_139.ReadOnly = true;
			this.panel_6.Controls.Add(this.panel_7);
			this.panel_6.Controls.Add(this.panel_8);
			this.panel_6.Controls.Add(this.panel_9);
			this.panel_6.Controls.Add(this.panel_10);
			this.panel_6.Controls.Add(this.panel_11);
			this.panel_6.Controls.Add(this.panel_12);
			this.panel_6.Controls.Add(this.panel_13);
			this.panel_6.Dock = DockStyle.Fill;
			this.panel_6.Location = new Point(428, 24);
			this.panel_6.Name = "panel4";
			this.panel_6.Size = new Size(371, 102);
			this.panel_6.TabIndex = 9;
			this.panel_7.BorderStyle = BorderStyle.FixedSingle;
			this.panel_7.Controls.Add(this.label_14);
			this.panel_7.Location = new Point(61, 0);
			this.panel_7.Name = "panel11";
			this.panel_7.Size = new Size(185, 26);
			this.panel_7.TabIndex = 5;
			this.label_14.AutoSize = true;
			this.label_14.Location = new Point(49, 6);
			this.label_14.Name = "label15";
			this.label_14.Size = new Size(84, 13);
			this.label_14.TabIndex = 4;
			this.label_14.Text = "Напряжение, В";
			this.panel_8.BorderStyle = BorderStyle.FixedSingle;
			this.panel_8.Location = new Point(11, 0);
			this.panel_8.Name = "panel3";
			this.panel_8.Size = new Size(51, 51);
			this.panel_8.TabIndex = 5;
			this.panel_9.BorderStyle = BorderStyle.FixedSingle;
			this.panel_9.Controls.Add(this.label_15);
			this.panel_9.Controls.Add(this.label_16);
			this.panel_9.Controls.Add(this.label_17);
			this.panel_9.Location = new Point(153, 25);
			this.panel_9.Name = "panel10";
			this.panel_9.Size = new Size(93, 26);
			this.panel_9.TabIndex = 5;
			this.label_15.AutoSize = true;
			this.label_15.Location = new Point(58, 3);
			this.label_15.Name = "label23";
			this.label_15.Size = new Size(30, 13);
			this.label_15.TabIndex = 4;
			this.label_15.Text = "Uc-o";
			this.label_16.AutoSize = true;
			this.label_16.Location = new Point(2, 3);
			this.label_16.Name = "label21";
			this.label_16.Size = new Size(30, 13);
			this.label_16.TabIndex = 4;
			this.label_16.Text = "Ua-o";
			this.label_17.AutoSize = true;
			this.label_17.Location = new Point(30, 3);
			this.label_17.Name = "label22";
			this.label_17.Size = new Size(30, 13);
			this.label_17.TabIndex = 4;
			this.label_17.Text = "Ub-o";
			this.panel_10.BorderStyle = BorderStyle.FixedSingle;
			this.panel_10.Controls.Add(this.textBox_10);
			this.panel_10.Controls.Add(this.textBox_11);
			this.panel_10.Controls.Add(this.textBox_12);
			this.panel_10.Controls.Add(this.textBox_13);
			this.panel_10.Controls.Add(this.textBox_14);
			this.panel_10.Controls.Add(this.textBox_15);
			this.panel_10.Location = new Point(61, 50);
			this.panel_10.Name = "panelTB1";
			this.panel_10.Size = new Size(93, 51);
			this.panel_10.TabIndex = 5;
			this.textBox_10.BackColor = Color.White;
			this.textBox_10.DataBindings.Add(new Binding("Text", this.bindingSource_1, "Ucan", true));
			this.textBox_10.Location = new Point(60, 25);
			this.textBox_10.Name = "mtbUcan";
			this.textBox_10.ReadOnly = true;
			this.textBox_10.Size = new Size(26, 20);
			this.textBox_10.TabIndex = 6;
			this.textBox_10.KeyPress += this.textBox_21_KeyPress;
			this.textBox_11.BackColor = Color.White;
			this.textBox_11.DataBindings.Add(new Binding("Text", this.bindingSource_1, "Ubcn", true));
			this.textBox_11.Location = new Point(32, 25);
			this.textBox_11.Name = "mtbUbcn";
			this.textBox_11.ReadOnly = true;
			this.textBox_11.Size = new Size(26, 20);
			this.textBox_11.TabIndex = 6;
			this.textBox_11.KeyPress += this.textBox_21_KeyPress;
			this.textBox_12.BackColor = Color.White;
			this.textBox_12.DataBindings.Add(new Binding("Text", this.bindingSource_1, "Uabn", true));
			this.textBox_12.Location = new Point(4, 25);
			this.textBox_12.Name = "mtbUabn";
			this.textBox_12.ReadOnly = true;
			this.textBox_12.Size = new Size(26, 20);
			this.textBox_12.TabIndex = 6;
			this.textBox_12.KeyPress += this.textBox_21_KeyPress;
			this.textBox_13.BackColor = Color.White;
			this.textBox_13.DataBindings.Add(new Binding("Text", this.bindingSource_1, "Ucad", true));
			this.textBox_13.Location = new Point(60, 3);
			this.textBox_13.Name = "mtbUcad";
			this.textBox_13.ReadOnly = true;
			this.textBox_13.Size = new Size(26, 20);
			this.textBox_13.TabIndex = 6;
			this.textBox_13.KeyPress += this.textBox_21_KeyPress;
			this.textBox_14.BackColor = Color.White;
			this.textBox_14.DataBindings.Add(new Binding("Text", this.bindingSource_1, "Ubcd", true));
			this.textBox_14.Location = new Point(32, 3);
			this.textBox_14.Name = "mtbUbcd";
			this.textBox_14.ReadOnly = true;
			this.textBox_14.Size = new Size(26, 20);
			this.textBox_14.TabIndex = 6;
			this.textBox_14.KeyPress += this.textBox_21_KeyPress;
			this.textBox_15.BackColor = Color.White;
			this.textBox_15.DataBindings.Add(new Binding("Text", this.bindingSource_1, "Uabd", true));
			this.textBox_15.Location = new Point(4, 3);
			this.textBox_15.Name = "mtbUabd";
			this.textBox_15.ReadOnly = true;
			this.textBox_15.Size = new Size(26, 20);
			this.textBox_15.TabIndex = 6;
			this.textBox_15.KeyPress += this.textBox_21_KeyPress;
			this.panel_11.BorderStyle = BorderStyle.FixedSingle;
			this.panel_11.Controls.Add(this.label_18);
			this.panel_11.Controls.Add(this.label_19);
			this.panel_11.Controls.Add(this.label_20);
			this.panel_11.Location = new Point(61, 25);
			this.panel_11.Name = "panel9";
			this.panel_11.Size = new Size(93, 26);
			this.panel_11.TabIndex = 5;
			this.label_18.AutoSize = true;
			this.label_18.Location = new Point(60, 3);
			this.label_18.Name = "label20";
			this.label_18.Size = new Size(27, 13);
			this.label_18.TabIndex = 4;
			this.label_18.Text = "Uca";
			this.label_19.AutoSize = true;
			this.label_19.Location = new Point(32, 3);
			this.label_19.Name = "label17";
			this.label_19.Size = new Size(27, 13);
			this.label_19.TabIndex = 4;
			this.label_19.Text = "Ubc";
			this.label_20.AutoSize = true;
			this.label_20.Location = new Point(4, 3);
			this.label_20.Name = "label16";
			this.label_20.Size = new Size(27, 13);
			this.label_20.TabIndex = 4;
			this.label_20.Text = "Uab";
			this.panel_12.BorderStyle = BorderStyle.FixedSingle;
			this.panel_12.Controls.Add(this.textBox_16);
			this.panel_12.Controls.Add(this.textBox_17);
			this.panel_12.Controls.Add(this.textBox_18);
			this.panel_12.Controls.Add(this.textBox_19);
			this.panel_12.Controls.Add(this.textBox_20);
			this.panel_12.Controls.Add(this.textBox_21);
			this.panel_12.Location = new Point(153, 50);
			this.panel_12.Name = "panelTB2";
			this.panel_12.Size = new Size(93, 51);
			this.panel_12.TabIndex = 5;
			this.textBox_16.BackColor = Color.White;
			this.textBox_16.DataBindings.Add(new Binding("Text", this.bindingSource_1, "Ucon", true));
			this.textBox_16.Location = new Point(60, 25);
			this.textBox_16.Name = "mtbUcon";
			this.textBox_16.ReadOnly = true;
			this.textBox_16.Size = new Size(26, 20);
			this.textBox_16.TabIndex = 6;
			this.textBox_16.KeyPress += this.textBox_21_KeyPress;
			this.textBox_17.BackColor = Color.White;
			this.textBox_17.DataBindings.Add(new Binding("Text", this.bindingSource_1, "Ubon", true));
			this.textBox_17.Location = new Point(32, 25);
			this.textBox_17.Name = "mtnUbon";
			this.textBox_17.ReadOnly = true;
			this.textBox_17.Size = new Size(26, 20);
			this.textBox_17.TabIndex = 6;
			this.textBox_17.KeyPress += this.textBox_21_KeyPress;
			this.textBox_18.BackColor = Color.White;
			this.textBox_18.DataBindings.Add(new Binding("Text", this.bindingSource_1, "Uaon", true));
			this.textBox_18.Location = new Point(4, 25);
			this.textBox_18.Name = "mmtbUaon";
			this.textBox_18.ReadOnly = true;
			this.textBox_18.Size = new Size(26, 20);
			this.textBox_18.TabIndex = 6;
			this.textBox_18.KeyPress += this.textBox_21_KeyPress;
			this.textBox_19.BackColor = Color.White;
			this.textBox_19.DataBindings.Add(new Binding("Text", this.bindingSource_1, "Ucod", true));
			this.textBox_19.Location = new Point(60, 3);
			this.textBox_19.Name = "mtbUcod";
			this.textBox_19.ReadOnly = true;
			this.textBox_19.Size = new Size(26, 20);
			this.textBox_19.TabIndex = 6;
			this.textBox_19.KeyPress += this.textBox_21_KeyPress;
			this.textBox_20.BackColor = Color.White;
			this.textBox_20.DataBindings.Add(new Binding("Text", this.bindingSource_1, "Ubod", true));
			this.textBox_20.Location = new Point(32, 3);
			this.textBox_20.Name = "mtbUbod";
			this.textBox_20.ReadOnly = true;
			this.textBox_20.Size = new Size(26, 20);
			this.textBox_20.TabIndex = 6;
			this.textBox_20.KeyPress += this.textBox_21_KeyPress;
			this.textBox_21.BackColor = Color.White;
			this.textBox_21.DataBindings.Add(new Binding("Text", this.bindingSource_1, "Uaod", true));
			this.textBox_21.Location = new Point(4, 3);
			this.textBox_21.Name = "mtbUaod";
			this.textBox_21.ReadOnly = true;
			this.textBox_21.Size = new Size(26, 20);
			this.textBox_21.TabIndex = 6;
			this.textBox_21.KeyPress += this.textBox_21_KeyPress;
			this.panel_13.BorderStyle = BorderStyle.FixedSingle;
			this.panel_13.Controls.Add(this.label_21);
			this.panel_13.Controls.Add(this.label_22);
			this.panel_13.Location = new Point(11, 50);
			this.panel_13.Name = "panel2";
			this.panel_13.Size = new Size(51, 51);
			this.panel_13.TabIndex = 5;
			this.label_21.AutoSize = true;
			this.label_21.Location = new Point(3, 28);
			this.label_21.Name = "label14";
			this.label_21.Size = new Size(37, 13);
			this.label_21.TabIndex = 4;
			this.label_21.Text = "Вечер";
			this.label_22.AutoSize = true;
			this.label_22.Location = new Point(3, 6);
			this.label_22.Name = "label13";
			this.label_22.Size = new Size(34, 13);
			this.label_22.TabIndex = 4;
			this.label_22.Text = "День";
			this.dataGridView_2.AllowUserToAddRows = false;
			this.dataGridView_2.AllowUserToDeleteRows = false;
			this.dataGridView_2.AllowUserToOrderColumns = true;
			this.dataGridView_2.AllowUserToResizeRows = false;
			this.dataGridView_2.AutoGenerateColumns = false;
			this.dataGridView_2.BackgroundColor = Color.White;
			dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle7.BackColor = SystemColors.Control;
			dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle7.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
			this.dataGridView_2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
			this.dataGridView_2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView_2.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewCheckBoxColumn_3,
				this.dataGridViewTextBoxColumn_107,
				this.dataGridViewTextBoxColumn_108,
				this.dataGridViewTextBoxColumn_109,
				this.dataGridViewTextBoxColumn_110,
				this.dataGridViewTextBoxColumn_111,
				this.dataGridViewTextBoxColumn_112,
				this.dataGridViewTextBoxColumn_113,
				this.dataGridViewTextBoxColumn_114,
				this.dataGridViewTextBoxColumn_115,
				this.dataGridViewTextBoxColumn_116,
				this.dataGridViewTextBoxColumn_117,
				this.dataGridViewTextBoxColumn_118,
				this.dataGridViewTextBoxColumn_119,
				this.dataGridViewTextBoxColumn_120,
				this.dataGridViewTextBoxColumn_121,
				this.dataGridViewTextBoxColumn_122,
				this.dataGridViewTextBoxColumn_123,
				this.dataGridViewTextBoxColumn_124,
				this.dataGridViewTextBoxColumn_125,
				this.dataGridViewTextBoxColumn_126,
				this.dataGridViewTextBoxColumn_127,
				this.dataGridViewTextBoxColumn_128,
				this.dataGridViewTextBoxColumn_129
			});
			this.tableLayoutPanel_3.SetColumnSpan(this.dataGridView_2, 3);
			this.dataGridView_2.DataSource = this.bindingSource_7;
			dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle8.BackColor = Color.White;
			dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle8.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
			this.dataGridView_2.DefaultCellStyle = dataGridViewCellStyle8;
			this.dataGridView_2.Dock = DockStyle.Fill;
			this.dataGridView_2.Location = new Point(3, 132);
			this.dataGridView_2.Margin = new Padding(3, 3, 7, 3);
			this.dataGridView_2.MultiSelect = false;
			this.dataGridView_2.Name = "dgvMeasCable";
			this.dataGridView_2.ReadOnly = true;
			dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle9.BackColor = SystemColors.Control;
			dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle9.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle9.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle9.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
			this.dataGridView_2.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
			this.dataGridView_2.RowHeadersVisible = false;
			this.dataGridView_2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView_2.Size = new Size(792, 1);
			this.dataGridView_2.TabIndex = 11;
			this.dataGridView_2.ColumnWidthChanged += this.dataGridView_2_ColumnWidthChanged;
			this.dataGridView_2.Scroll += this.dataGridView_2_Scroll;
			this.dataGridViewCheckBoxColumn_3.DataPropertyName = "Deleted";
			this.dataGridViewCheckBoxColumn_3.HeaderText = "Deleted";
			this.dataGridViewCheckBoxColumn_3.Name = "deletedDataGridViewCheckBoxColumn";
			this.dataGridViewCheckBoxColumn_3.ReadOnly = true;
			this.dataGridViewCheckBoxColumn_3.Visible = false;
			this.dataGridViewTextBoxColumn_107.DataPropertyName = "NameCell";
			this.dataGridViewTextBoxColumn_107.HeaderText = "№ руб.";
			this.dataGridViewTextBoxColumn_107.Name = "NameCell";
			this.dataGridViewTextBoxColumn_107.ReadOnly = true;
			this.dataGridViewTextBoxColumn_107.Width = 30;
			this.dataGridViewTextBoxColumn_108.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_108.HeaderText = "id";
			this.dataGridViewTextBoxColumn_108.Name = "idDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_108.ReadOnly = true;
			this.dataGridViewTextBoxColumn_108.Visible = false;
			this.dataGridViewTextBoxColumn_109.DataPropertyName = "idMeasurement";
			this.dataGridViewTextBoxColumn_109.HeaderText = "idMeasurement";
			this.dataGridViewTextBoxColumn_109.Name = "idMeasurement";
			this.dataGridViewTextBoxColumn_109.ReadOnly = true;
			this.dataGridViewTextBoxColumn_109.Visible = false;
			this.dataGridViewTextBoxColumn_110.DataPropertyName = "idCell";
			this.dataGridViewTextBoxColumn_110.HeaderText = "idCell";
			this.dataGridViewTextBoxColumn_110.Name = "idCellDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_110.ReadOnly = true;
			this.dataGridViewTextBoxColumn_110.Resizable = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_110.Visible = false;
			this.dataGridViewTextBoxColumn_110.Width = 30;
			this.dataGridViewTextBoxColumn_111.DataPropertyName = "OldCell";
			this.dataGridViewTextBoxColumn_111.HeaderText = "№ Ст.р";
			this.dataGridViewTextBoxColumn_111.Name = "OldCell";
			this.dataGridViewTextBoxColumn_111.ReadOnly = true;
			this.dataGridViewTextBoxColumn_111.Width = 30;
			this.dataGridViewTextBoxColumn_112.DataPropertyName = "NameCable";
			this.dataGridViewTextBoxColumn_112.HeaderText = "Кабель";
			this.dataGridViewTextBoxColumn_112.Name = "NameCable";
			this.dataGridViewTextBoxColumn_112.ReadOnly = true;
			this.dataGridViewTextBoxColumn_113.DataPropertyName = "Address";
			this.dataGridViewTextBoxColumn_113.HeaderText = "Адрес объекта";
			this.dataGridViewTextBoxColumn_113.Name = "Address";
			this.dataGridViewTextBoxColumn_113.ReadOnly = true;
			this.dataGridViewTextBoxColumn_113.Width = 150;
			this.dataGridViewTextBoxColumn_114.DataPropertyName = "Company";
			this.dataGridViewTextBoxColumn_114.HeaderText = "Наименование объекта";
			this.dataGridViewTextBoxColumn_114.Name = "Company";
			this.dataGridViewTextBoxColumn_114.ReadOnly = true;
			this.dataGridViewTextBoxColumn_114.Width = 150;
			this.dataGridViewTextBoxColumn_115.DataPropertyName = "idSchmAbn";
			this.dataGridViewTextBoxColumn_115.HeaderText = "idSchmAbn";
			this.dataGridViewTextBoxColumn_115.Name = "idSchmAbnDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_115.ReadOnly = true;
			this.dataGridViewTextBoxColumn_115.Visible = false;
			this.dataGridViewTextBoxColumn_116.DataPropertyName = "Makeup";
			this.dataGridViewTextBoxColumn_116.HeaderText = "Марка кабеля";
			this.dataGridViewTextBoxColumn_116.Name = "makeupDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_116.ReadOnly = true;
			this.dataGridViewTextBoxColumn_116.Resizable = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_116.Width = 60;
			this.dataGridViewTextBoxColumn_117.DataPropertyName = "Voltage";
			this.dataGridViewTextBoxColumn_117.HeaderText = "Напр.";
			this.dataGridViewTextBoxColumn_117.Name = "voltageDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_117.ReadOnly = true;
			this.dataGridViewTextBoxColumn_117.Resizable = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_117.Visible = false;
			this.dataGridViewTextBoxColumn_117.Width = 70;
			this.dataGridViewTextBoxColumn_118.DataPropertyName = "Wires";
			this.dataGridViewTextBoxColumn_118.HeaderText = "Кол-во жил";
			this.dataGridViewTextBoxColumn_118.Name = "wiresDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_118.ReadOnly = true;
			this.dataGridViewTextBoxColumn_118.Width = 40;
			this.dataGridViewTextBoxColumn_119.DataPropertyName = "CrossSection";
			this.dataGridViewTextBoxColumn_119.HeaderText = "Сечение";
			this.dataGridViewTextBoxColumn_119.Name = "crossSectionDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_119.ReadOnly = true;
			this.dataGridViewTextBoxColumn_119.Resizable = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_119.Width = 50;
			this.dataGridViewTextBoxColumn_120.DataPropertyName = "PermisAmperage";
			dataGridViewCellStyle10.Format = "N0";
			this.dataGridViewTextBoxColumn_120.DefaultCellStyle = dataGridViewCellStyle10;
			this.dataGridViewTextBoxColumn_120.HeaderText = "Допуст. нагр., А";
			this.dataGridViewTextBoxColumn_120.Name = "PermisAmperage";
			this.dataGridViewTextBoxColumn_120.ReadOnly = true;
			this.dataGridViewTextBoxColumn_120.Width = 50;
			this.dataGridViewTextBoxColumn_121.DataPropertyName = "Iad";
			dataGridViewCellStyle11.Format = "N0";
			dataGridViewCellStyle11.NullValue = null;
			this.dataGridViewTextBoxColumn_121.DefaultCellStyle = dataGridViewCellStyle11;
			this.dataGridViewTextBoxColumn_121.HeaderText = "А дн.";
			this.dataGridViewTextBoxColumn_121.Name = "Iad";
			this.dataGridViewTextBoxColumn_121.ReadOnly = true;
			this.dataGridViewTextBoxColumn_121.Width = 40;
			this.dataGridViewTextBoxColumn_122.DataPropertyName = "Ian";
			dataGridViewCellStyle12.Format = "N0";
			this.dataGridViewTextBoxColumn_122.DefaultCellStyle = dataGridViewCellStyle12;
			this.dataGridViewTextBoxColumn_122.HeaderText = "А вч.";
			this.dataGridViewTextBoxColumn_122.Name = "Ian";
			this.dataGridViewTextBoxColumn_122.ReadOnly = true;
			this.dataGridViewTextBoxColumn_122.Width = 40;
			this.dataGridViewTextBoxColumn_123.DataPropertyName = "Ibd";
			this.dataGridViewTextBoxColumn_123.HeaderText = "В дн.";
			this.dataGridViewTextBoxColumn_123.Name = "Ibd";
			this.dataGridViewTextBoxColumn_123.ReadOnly = true;
			this.dataGridViewTextBoxColumn_123.Width = 40;
			this.dataGridViewTextBoxColumn_124.DataPropertyName = "Ibn";
			this.dataGridViewTextBoxColumn_124.HeaderText = "В вч.";
			this.dataGridViewTextBoxColumn_124.Name = "Ibn";
			this.dataGridViewTextBoxColumn_124.ReadOnly = true;
			this.dataGridViewTextBoxColumn_124.Width = 40;
			this.dataGridViewTextBoxColumn_125.DataPropertyName = "Icd";
			this.dataGridViewTextBoxColumn_125.HeaderText = "С дн.";
			this.dataGridViewTextBoxColumn_125.Name = "Icd";
			this.dataGridViewTextBoxColumn_125.ReadOnly = true;
			this.dataGridViewTextBoxColumn_125.Width = 40;
			this.dataGridViewTextBoxColumn_126.DataPropertyName = "Icn";
			this.dataGridViewTextBoxColumn_126.HeaderText = "С вч.";
			this.dataGridViewTextBoxColumn_126.Name = "Icn";
			this.dataGridViewTextBoxColumn_126.ReadOnly = true;
			this.dataGridViewTextBoxColumn_126.Width = 40;
			this.dataGridViewTextBoxColumn_127.DataPropertyName = "Iod";
			this.dataGridViewTextBoxColumn_127.HeaderText = "0 дн.";
			this.dataGridViewTextBoxColumn_127.Name = "Iod";
			this.dataGridViewTextBoxColumn_127.ReadOnly = true;
			this.dataGridViewTextBoxColumn_127.Width = 40;
			this.dataGridViewTextBoxColumn_128.DataPropertyName = "Ion";
			this.dataGridViewTextBoxColumn_128.HeaderText = "0 вч.";
			this.dataGridViewTextBoxColumn_128.Name = "Ion";
			this.dataGridViewTextBoxColumn_128.ReadOnly = true;
			this.dataGridViewTextBoxColumn_128.Width = 40;
			this.dataGridViewTextBoxColumn_129.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_129.DataPropertyName = "Comment";
			this.dataGridViewTextBoxColumn_129.HeaderText = "Комментарий";
			this.dataGridViewTextBoxColumn_129.MinimumWidth = 80;
			this.dataGridViewTextBoxColumn_129.Name = "commentDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_129.ReadOnly = true;
			this.bindingSource_7.DataMember = "vJ_MeasCable";
			this.bindingSource_7.DataSource = this.class255_0;
			this.dataGridView_3.AllowUserToAddRows = false;
			this.dataGridView_3.AllowUserToDeleteRows = false;
			this.dataGridView_3.AllowUserToResizeRows = false;
			this.dataGridView_3.AutoGenerateColumns = false;
			this.dataGridView_3.BackgroundColor = Color.White;
			dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle13.BackColor = SystemColors.Control;
			dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle13.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle13.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle13.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle13.WrapMode = DataGridViewTriState.True;
			this.dataGridView_3.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
			this.dataGridView_3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView_3.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewComboBoxColumn_0,
				this.dataGridViewComboBoxColumn_1,
				this.dataGridViewCheckBoxColumn_4,
				this.dataGridViewTextBoxColumn_145,
				this.dataGridViewTextBoxColumn_146,
				this.dataGridViewTextBoxColumn_147,
				this.dataGridViewTextBoxColumn_148,
				this.dataGridViewTextBoxColumn_149,
				this.dataGridViewTextBoxColumn_150,
				this.dataGridViewTextBoxColumn_151
			});
			this.dataGridView_3.DataSource = this.bindingSource_9;
			dataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle14.BackColor = Color.White;
			dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle14.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle14.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle14.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle14.WrapMode = DataGridViewTriState.False;
			this.dataGridView_3.DefaultCellStyle = dataGridViewCellStyle14;
			this.dataGridView_3.Dock = DockStyle.Fill;
			this.dataGridView_3.Location = new Point(7, 28);
			this.dataGridView_3.Margin = new Padding(3, 3, 7, 3);
			this.dataGridView_3.MultiSelect = false;
			this.dataGridView_3.Name = "dgvMeasurement";
			this.dataGridView_3.ReadOnly = true;
			dataGridViewCellStyle15.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle15.BackColor = SystemColors.Control;
			dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle15.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle15.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle15.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle15.WrapMode = DataGridViewTriState.True;
			this.dataGridView_3.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
			this.dataGridView_3.RowHeadersVisible = false;
			this.dataGridView_3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView_3.Size = new Size(798, 91);
			this.dataGridView_3.TabIndex = 13;
			this.dataGridView_3.DataError += this.dataGridView_3_DataError;
			this.dataGridViewComboBoxColumn_0.DataPropertyName = "idWorker";
			this.dataGridViewComboBoxColumn_0.DataSource = this.bindingSource_10;
			this.dataGridViewComboBoxColumn_0.DisplayMember = "FIO";
			this.dataGridViewComboBoxColumn_0.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
			this.dataGridViewComboBoxColumn_0.HeaderText = "Электромонтер";
			this.dataGridViewComboBoxColumn_0.MinimumWidth = 70;
			this.dataGridViewComboBoxColumn_0.Name = "idWorkerDataGridViewTextBoxColumn";
			this.dataGridViewComboBoxColumn_0.ReadOnly = true;
			this.dataGridViewComboBoxColumn_0.Resizable = DataGridViewTriState.True;
			this.dataGridViewComboBoxColumn_0.SortMode = DataGridViewColumnSortMode.Automatic;
			this.dataGridViewComboBoxColumn_0.ValueMember = "Id";
			this.dataGridViewComboBoxColumn_0.Width = 150;
			this.bindingSource_10.DataMember = "vP_Worker";
			this.bindingSource_10.DataSource = this.class255_0;
			this.bindingSource_10.Filter = "ParentKey = '' OR ParentKey = ';GroupWorker;Meas;'";
			this.bindingSource_10.Sort = "FIO";
			this.dataGridViewComboBoxColumn_1.DataPropertyName = "idWorkerCheck";
			this.dataGridViewComboBoxColumn_1.DataSource = this.bindingSource_17;
			this.dataGridViewComboBoxColumn_1.DisplayMember = "FIO";
			this.dataGridViewComboBoxColumn_1.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
			this.dataGridViewComboBoxColumn_1.HeaderText = "Диспетчер";
			this.dataGridViewComboBoxColumn_1.Name = "idWorkerCheck";
			this.dataGridViewComboBoxColumn_1.ReadOnly = true;
			this.dataGridViewComboBoxColumn_1.Resizable = DataGridViewTriState.True;
			this.dataGridViewComboBoxColumn_1.SortMode = DataGridViewColumnSortMode.Automatic;
			this.dataGridViewComboBoxColumn_1.ValueMember = "Id";
			this.bindingSource_17.DataMember = "vP_Worker";
			this.bindingSource_17.DataSource = this.class255_0;
			this.bindingSource_17.Filter = "ParentKey = '' OR ParentKey = ';GroupWorker;MeasDispatchers;'";
			this.bindingSource_17.Sort = "FIO";
			this.dataGridViewCheckBoxColumn_4.DataPropertyName = "Deleted";
			this.dataGridViewCheckBoxColumn_4.HeaderText = "Deleted";
			this.dataGridViewCheckBoxColumn_4.Name = "deletedDataGridViewCheckBoxColumn1";
			this.dataGridViewCheckBoxColumn_4.ReadOnly = true;
			this.dataGridViewCheckBoxColumn_4.Visible = false;
			this.dataGridViewTextBoxColumn_145.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_145.HeaderText = "id";
			this.dataGridViewTextBoxColumn_145.Name = "idDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_145.ReadOnly = true;
			this.dataGridViewTextBoxColumn_145.Visible = false;
			this.dataGridViewTextBoxColumn_146.DataPropertyName = "idObjList";
			this.dataGridViewTextBoxColumn_146.HeaderText = "idObjList";
			this.dataGridViewTextBoxColumn_146.Name = "idObjListDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_146.ReadOnly = true;
			this.dataGridViewTextBoxColumn_146.Visible = false;
			this.dataGridViewTextBoxColumn_147.DataPropertyName = "DateD";
			this.dataGridViewTextBoxColumn_147.HeaderText = "Дата замера дн.";
			this.dataGridViewTextBoxColumn_147.MinimumWidth = 70;
			this.dataGridViewTextBoxColumn_147.Name = "dateDDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_147.ReadOnly = true;
			this.dataGridViewTextBoxColumn_148.DataPropertyName = "TemperatureD";
			dataGridViewCellStyle16.Alignment = DataGridViewContentAlignment.MiddleCenter;
			this.dataGridViewTextBoxColumn_148.DefaultCellStyle = dataGridViewCellStyle16;
			this.dataGridViewTextBoxColumn_148.HeaderText = "Температура дн.";
			this.dataGridViewTextBoxColumn_148.MinimumWidth = 70;
			this.dataGridViewTextBoxColumn_148.Name = "temperatureDDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_148.ReadOnly = true;
			this.dataGridViewTextBoxColumn_149.DataPropertyName = "DateN";
			this.dataGridViewTextBoxColumn_149.HeaderText = "Дата замера вч.";
			this.dataGridViewTextBoxColumn_149.MinimumWidth = 70;
			this.dataGridViewTextBoxColumn_149.Name = "dateNDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_149.ReadOnly = true;
			this.dataGridViewTextBoxColumn_150.DataPropertyName = "TemperatureN";
			dataGridViewCellStyle17.Alignment = DataGridViewContentAlignment.MiddleCenter;
			this.dataGridViewTextBoxColumn_150.DefaultCellStyle = dataGridViewCellStyle17;
			this.dataGridViewTextBoxColumn_150.HeaderText = "Температура вч.";
			this.dataGridViewTextBoxColumn_150.MinimumWidth = 70;
			this.dataGridViewTextBoxColumn_150.Name = "temperatureNDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_150.ReadOnly = true;
			this.dataGridViewTextBoxColumn_151.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_151.DataPropertyName = "Comment";
			this.dataGridViewTextBoxColumn_151.HeaderText = "Дополнительно";
			this.dataGridViewTextBoxColumn_151.MinimumWidth = 100;
			this.dataGridViewTextBoxColumn_151.Name = "Comment";
			this.dataGridViewTextBoxColumn_151.ReadOnly = true;
			this.bindingSource_9.DataMember = "tJ_Measurement";
			this.bindingSource_9.DataSource = this.class255_0;
			this.bindingSource_9.CurrentChanged += this.bindingSource_9_CurrentChanged;
			this.tableLayoutPanel_4.ColumnCount = 3;
			this.tableLayoutPanel_4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 158f));
			this.tableLayoutPanel_4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 143f));
			this.tableLayoutPanel_4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel_4.Controls.Add(this.panel_14, 0, 1);
			this.tableLayoutPanel_4.Controls.Add(this.panel_19, 2, 1);
			this.tableLayoutPanel_4.Controls.Add(this.dataGridView_4, 0, 3);
			this.tableLayoutPanel_4.Controls.Add(this.dataGridView_5, 0, 2);
			this.tableLayoutPanel_4.Controls.Add(this.label_23, 0, 0);
			this.tableLayoutPanel_4.Controls.Add(this.comboBox_2, 1, 0);
			this.tableLayoutPanel_4.Controls.Add(this.label_29, 2, 0);
			this.tableLayoutPanel_4.Dock = DockStyle.Fill;
			this.tableLayoutPanel_4.Location = new Point(7, 323);
			this.tableLayoutPanel_4.Name = "tlpMeasurementHigh";
			this.tableLayoutPanel_4.RowCount = 4;
			this.tableLayoutPanel_4.RowStyles.Add(new RowStyle(SizeType.Absolute, 21f));
			this.tableLayoutPanel_4.RowStyles.Add(new RowStyle(SizeType.Absolute, 108f));
			this.tableLayoutPanel_4.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel_4.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
			this.tableLayoutPanel_4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
			this.tableLayoutPanel_4.Size = new Size(802, 192);
			this.tableLayoutPanel_4.TabIndex = 17;
			this.tableLayoutPanel_4.SetColumnSpan(this.panel_14, 2);
			this.panel_14.Controls.Add(this.label_24);
			this.panel_14.Controls.Add(this.SeroruImpei);
			this.panel_14.Controls.Add(this.label_25);
			this.panel_14.Controls.Add(this.label_26);
			this.panel_14.Controls.Add(this.panel_15);
			this.panel_14.Controls.Add(this.panel_16);
			this.panel_14.Controls.Add(this.panel_17);
			this.panel_14.Controls.Add(this.panel_18);
			this.panel_14.Dock = DockStyle.Fill;
			this.panel_14.Location = new Point(3, 24);
			this.panel_14.Name = "pnlTransfReferenceCell";
			this.panel_14.Size = new Size(295, 102);
			this.panel_14.TabIndex = 20;
			this.label_24.BorderStyle = BorderStyle.FixedSingle;
			this.label_24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label_24.Location = new Point(0, 0);
			this.label_24.Name = "label29";
			this.label_24.Size = new Size(124, 51);
			this.label_24.TabIndex = 0;
			this.label_24.Text = "Трансформатор";
			this.label_24.TextAlign = ContentAlignment.MiddleCenter;
			this.SeroruImpei.BorderStyle = BorderStyle.FixedSingle;
			this.SeroruImpei.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.SeroruImpei.Location = new Point(123, 0);
			this.SeroruImpei.Name = "label30";
			this.SeroruImpei.Size = new Size(75, 51);
			this.SeroruImpei.TabIndex = 0;
			this.SeroruImpei.Text = "Мощность кВт";
			this.SeroruImpei.TextAlign = ContentAlignment.MiddleCenter;
			this.label_25.BorderStyle = BorderStyle.FixedSingle;
			this.label_25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label_25.Location = new Point(197, 0);
			this.label_25.Name = "label31";
			this.label_25.Size = new Size(51, 51);
			this.label_25.TabIndex = 0;
			this.label_25.Text = "Uвн\r\n(раб)";
			this.label_25.TextAlign = ContentAlignment.MiddleCenter;
			this.label_26.BorderStyle = BorderStyle.FixedSingle;
			this.label_26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label_26.Location = new Point(247, 0);
			this.label_26.Name = "label32";
			this.label_26.Size = new Size(47, 51);
			this.label_26.TabIndex = 0;
			this.label_26.Text = "Iном\r\nА";
			this.label_26.TextAlign = ContentAlignment.MiddleCenter;
			this.panel_15.BorderStyle = BorderStyle.FixedSingle;
			this.panel_15.Controls.Add(this.textBox_22);
			this.panel_15.Controls.Add(this.textBox_23);
			this.panel_15.Controls.Add(this.label_27);
			this.panel_15.Controls.Add(this.label_28);
			this.panel_15.Location = new Point(0, 50);
			this.panel_15.Name = "panel16";
			this.panel_15.Size = new Size(124, 52);
			this.panel_15.TabIndex = 5;
			this.textBox_22.BackColor = Color.White;
			this.textBox_22.DataBindings.Add(new Binding("Text", this.bindingSource_0, "Type", true));
			this.textBox_22.Location = new Point(36, 2);
			this.textBox_22.Name = "textBox5";
			this.textBox_22.ReadOnly = true;
			this.textBox_22.Size = new Size(79, 20);
			this.textBox_22.TabIndex = 2;
			this.textBox_23.BackColor = Color.White;
			this.textBox_23.DataBindings.Add(new Binding("Text", this.bindingSource_0, "InvNumber", true));
			this.textBox_23.Location = new Point(36, 28);
			this.textBox_23.Name = "textBox6";
			this.textBox_23.ReadOnly = true;
			this.textBox_23.Size = new Size(79, 20);
			this.textBox_23.TabIndex = 2;
			this.label_27.AutoSize = true;
			this.label_27.Location = new Point(4, 5);
			this.label_27.Name = "label34";
			this.label_27.Size = new Size(26, 13);
			this.label_27.TabIndex = 4;
			this.label_27.Text = "Тип";
			this.label_28.AutoSize = true;
			this.label_28.Location = new Point(8, 31);
			this.label_28.Name = "label35";
			this.label_28.Size = new Size(18, 13);
			this.label_28.TabIndex = 4;
			this.label_28.Text = "№";
			this.panel_16.BorderStyle = BorderStyle.FixedSingle;
			this.panel_16.Controls.Add(this.textBox_24);
			this.panel_16.Location = new Point(247, 50);
			this.panel_16.Name = "panel18";
			this.panel_16.Size = new Size(47, 52);
			this.panel_16.TabIndex = 5;
			this.textBox_24.BackColor = Color.White;
			this.textBox_24.DataBindings.Add(new Binding("Text", this.bindingSource_0, "InomHV", true));
			this.textBox_24.Location = new Point(2, 15);
			this.textBox_24.Name = "textBox7";
			this.textBox_24.ReadOnly = true;
			this.textBox_24.Size = new Size(40, 20);
			this.textBox_24.TabIndex = 2;
			this.panel_17.BorderStyle = BorderStyle.FixedSingle;
			this.panel_17.Controls.Add(this.textBox_25);
			this.panel_17.Location = new Point(123, 50);
			this.panel_17.Name = "panel19";
			this.panel_17.Size = new Size(75, 52);
			this.panel_17.TabIndex = 5;
			this.textBox_25.BackColor = Color.White;
			this.textBox_25.DataBindings.Add(new Binding("Text", this.bindingSource_0, "Power", true));
			this.textBox_25.Location = new Point(3, 15);
			this.textBox_25.Name = "textBox8";
			this.textBox_25.ReadOnly = true;
			this.textBox_25.Size = new Size(67, 20);
			this.textBox_25.TabIndex = 2;
			this.panel_18.BorderStyle = BorderStyle.FixedSingle;
			this.panel_18.Controls.Add(this.kKnoracFnyK);
			this.panel_18.Location = new Point(197, 50);
			this.panel_18.Name = "panel20";
			this.panel_18.Size = new Size(51, 52);
			this.panel_18.TabIndex = 5;
			this.kKnoracFnyK.BackColor = Color.White;
			this.kKnoracFnyK.DataBindings.Add(new Binding("Text", this.bindingSource_0, "Unom", true));
			this.kKnoracFnyK.Location = new Point(2, 15);
			this.kKnoracFnyK.Name = "textBox9";
			this.kKnoracFnyK.ReadOnly = true;
			this.kKnoracFnyK.Size = new Size(44, 20);
			this.kKnoracFnyK.TabIndex = 2;
			this.panel_19.Controls.Add(this.panel_20);
			this.panel_19.Controls.Add(this.panel_21);
			this.panel_19.Controls.Add(this.panel_22);
			this.panel_19.Controls.Add(this.panel_23);
			this.panel_19.Controls.Add(this.panel_24);
			this.panel_19.Controls.Add(this.label_33);
			this.panel_19.Controls.Add(this.panel_25);
			this.panel_19.Dock = DockStyle.Fill;
			this.panel_19.Location = new Point(304, 24);
			this.panel_19.Name = "pnlAmperageTransf";
			this.panel_19.Size = new Size(495, 102);
			this.panel_19.TabIndex = 17;
			this.panel_20.BorderStyle = BorderStyle.FixedSingle;
			this.panel_20.Controls.Add(this.label_30);
			this.panel_20.Location = new Point(211, 0);
			this.panel_20.Name = "panel21";
			this.panel_20.Size = new Size(69, 51);
			this.panel_20.TabIndex = 16;
			this.label_30.Dock = DockStyle.Fill;
			this.label_30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label_30.Location = new Point(0, 0);
			this.label_30.Name = "label25";
			this.label_30.Size = new Size(67, 49);
			this.label_30.TabIndex = 2;
			this.label_30.Text = "B";
			this.label_30.TextAlign = ContentAlignment.MiddleCenter;
			this.panel_21.BorderStyle = BorderStyle.FixedSingle;
			this.panel_21.Controls.Add(this.label_31);
			this.panel_21.Location = new Point(279, 0);
			this.panel_21.Name = "panel17";
			this.panel_21.Size = new Size(72, 51);
			this.panel_21.TabIndex = 15;
			this.label_31.Dock = DockStyle.Fill;
			this.label_31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label_31.Location = new Point(0, 0);
			this.label_31.Name = "label26";
			this.label_31.Size = new Size(70, 49);
			this.label_31.TabIndex = 2;
			this.label_31.Text = "C";
			this.label_31.TextAlign = ContentAlignment.MiddleCenter;
			this.panel_22.BorderStyle = BorderStyle.FixedSingle;
			this.panel_22.Controls.Add(this.label_32);
			this.panel_22.Location = new Point(140, 0);
			this.panel_22.Name = "panel1";
			this.panel_22.Size = new Size(72, 51);
			this.panel_22.TabIndex = 14;
			this.label_32.Dock = DockStyle.Fill;
			this.label_32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label_32.Location = new Point(0, 0);
			this.label_32.Name = "label24";
			this.label_32.Size = new Size(70, 49);
			this.label_32.TabIndex = 1;
			this.label_32.Text = "A";
			this.label_32.TextAlign = ContentAlignment.MiddleCenter;
			this.panel_23.BorderStyle = BorderStyle.FixedSingle;
			this.panel_23.Controls.Add(this.textBox_26);
			this.panel_23.Location = new Point(279, 50);
			this.panel_23.Name = "panel13";
			this.panel_23.Size = new Size(72, 52);
			this.panel_23.TabIndex = 12;
			this.textBox_26.BackColor = Color.White;
			this.textBox_26.DataBindings.Add(new Binding("Text", this.bindingSource_11, "Ic", true));
			this.textBox_26.Location = new Point(3, 16);
			this.textBox_26.Name = "textBox3";
			this.textBox_26.ReadOnly = true;
			this.textBox_26.Size = new Size(63, 20);
			this.textBox_26.TabIndex = 2;
			this.bindingSource_11.DataMember = "tJ_MeasAmperageTransf";
			this.bindingSource_11.DataSource = this.class255_0;
			this.panel_24.BorderStyle = BorderStyle.FixedSingle;
			this.panel_24.Controls.Add(this.textBox_27);
			this.panel_24.Location = new Point(211, 50);
			this.panel_24.Name = "panel12";
			this.panel_24.Size = new Size(69, 52);
			this.panel_24.TabIndex = 11;
			this.textBox_27.BackColor = Color.White;
			this.textBox_27.DataBindings.Add(new Binding("Text", this.bindingSource_11, "Ib", true));
			this.textBox_27.Location = new Point(3, 16);
			this.textBox_27.Name = "textBox1";
			this.textBox_27.ReadOnly = true;
			this.textBox_27.Size = new Size(61, 20);
			this.textBox_27.TabIndex = 2;
			this.label_33.BorderStyle = BorderStyle.FixedSingle;
			this.label_33.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label_33.Location = new Point(0, 0);
			this.label_33.Name = "label7";
			this.label_33.Size = new Size(141, 102);
			this.label_33.TabIndex = 10;
			this.label_33.Text = "Ток нагрузки";
			this.label_33.TextAlign = ContentAlignment.MiddleCenter;
			this.panel_25.BorderStyle = BorderStyle.FixedSingle;
			this.panel_25.Controls.Add(this.textBox_28);
			this.panel_25.Location = new Point(140, 50);
			this.panel_25.Name = "panel14";
			this.panel_25.Size = new Size(72, 52);
			this.panel_25.TabIndex = 6;
			this.textBox_28.BackColor = Color.White;
			this.textBox_28.DataBindings.Add(new Binding("Text", this.bindingSource_11, "Ia", true));
			this.textBox_28.Location = new Point(3, 16);
			this.textBox_28.Name = "tbIa";
			this.textBox_28.ReadOnly = true;
			this.textBox_28.Size = new Size(64, 20);
			this.textBox_28.TabIndex = 2;
			this.dataGridView_4.AllowUserToResizeRows = false;
			this.dataGridView_4.BackgroundColor = Color.White;
			dataGridViewCellStyle18.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle18.BackColor = SystemColors.Control;
			dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle18.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle18.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle18.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle18.WrapMode = DataGridViewTriState.True;
			this.dataGridView_4.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle18;
			this.dataGridView_4.ColumnHeadersVisible = false;
			this.dataGridView_4.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewTextBoxColumn_32,
				this.dataGridViewTextBoxColumn_33,
				this.dataGridViewTextBoxColumn_34,
				this.dataGridViewTextBoxColumn_35,
				this.dataGridViewTextBoxColumn_36,
				this.cEuordftJiB,
				this.dataGridViewTextBoxColumn_37,
				this.usrorTnxaCv
			});
			this.tableLayoutPanel_4.SetColumnSpan(this.dataGridView_4, 3);
			dataGridViewCellStyle19.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle19.BackColor = Color.White;
			dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle19.ForeColor = Color.Black;
			dataGridViewCellStyle19.SelectionBackColor = Color.White;
			dataGridViewCellStyle19.SelectionForeColor = Color.Black;
			dataGridViewCellStyle19.WrapMode = DataGridViewTriState.False;
			this.dataGridView_4.DefaultCellStyle = dataGridViewCellStyle19;
			this.dataGridView_4.Dock = DockStyle.Fill;
			this.dataGridView_4.Location = new Point(3, 167);
			this.dataGridView_4.Margin = new Padding(3, 3, 7, 3);
			this.dataGridView_4.MultiSelect = false;
			this.dataGridView_4.Name = "dgvSumCell";
			this.dataGridView_4.ReadOnly = true;
			dataGridViewCellStyle20.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle20.BackColor = SystemColors.Control;
			dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle20.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle20.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle20.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle20.WrapMode = DataGridViewTriState.True;
			this.dataGridView_4.RowHeadersDefaultCellStyle = dataGridViewCellStyle20;
			this.dataGridView_4.RowHeadersVisible = false;
			this.dataGridView_4.ScrollBars = ScrollBars.None;
			this.dataGridView_4.Size = new Size(792, 22);
			this.dataGridView_4.TabIndex = 16;
			this.dataGridViewTextBoxColumn_32.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			this.dataGridViewTextBoxColumn_32.DataPropertyName = "Address";
			this.dataGridViewTextBoxColumn_32.HeaderText = "SumName";
			this.dataGridViewTextBoxColumn_32.Name = "dataGridViewTextBoxColumn23";
			this.dataGridViewTextBoxColumn_32.ReadOnly = true;
			this.dataGridViewTextBoxColumn_32.Width = 110;
			this.dataGridViewTextBoxColumn_33.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			this.dataGridViewTextBoxColumn_33.DataPropertyName = "Company";
			this.dataGridViewTextBoxColumn_33.HeaderText = "ad";
			this.dataGridViewTextBoxColumn_33.Name = "dataGridViewTextBoxColumn24";
			this.dataGridViewTextBoxColumn_33.ReadOnly = true;
			this.dataGridViewTextBoxColumn_33.Width = 60;
			this.dataGridViewTextBoxColumn_34.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			this.dataGridViewTextBoxColumn_34.DataPropertyName = "idSchmAbn";
			this.dataGridViewTextBoxColumn_34.HeaderText = "an";
			this.dataGridViewTextBoxColumn_34.Name = "dataGridViewTextBoxColumn25";
			this.dataGridViewTextBoxColumn_34.ReadOnly = true;
			this.dataGridViewTextBoxColumn_34.Visible = false;
			this.dataGridViewTextBoxColumn_34.Width = 60;
			this.dataGridViewTextBoxColumn_35.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			this.dataGridViewTextBoxColumn_35.DataPropertyName = "Makeup";
			this.dataGridViewTextBoxColumn_35.HeaderText = "bd";
			this.dataGridViewTextBoxColumn_35.Name = "dataGridViewTextBoxColumn26";
			this.dataGridViewTextBoxColumn_35.ReadOnly = true;
			this.dataGridViewTextBoxColumn_35.Resizable = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_35.Width = 60;
			this.dataGridViewTextBoxColumn_36.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			this.dataGridViewTextBoxColumn_36.DataPropertyName = "Voltage";
			this.dataGridViewTextBoxColumn_36.HeaderText = "bn";
			this.dataGridViewTextBoxColumn_36.Name = "dataGridViewTextBoxColumn27";
			this.dataGridViewTextBoxColumn_36.ReadOnly = true;
			this.dataGridViewTextBoxColumn_36.Resizable = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_36.Visible = false;
			this.dataGridViewTextBoxColumn_36.Width = 60;
			this.cEuordftJiB.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			this.cEuordftJiB.DataPropertyName = "Wires";
			this.cEuordftJiB.HeaderText = "cd";
			this.cEuordftJiB.Name = "dataGridViewTextBoxColumn28";
			this.cEuordftJiB.ReadOnly = true;
			this.cEuordftJiB.Width = 60;
			this.dataGridViewTextBoxColumn_37.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			this.dataGridViewTextBoxColumn_37.DataPropertyName = "CrossSection";
			this.dataGridViewTextBoxColumn_37.HeaderText = "cn";
			this.dataGridViewTextBoxColumn_37.Name = "dataGridViewTextBoxColumn29";
			this.dataGridViewTextBoxColumn_37.ReadOnly = true;
			this.dataGridViewTextBoxColumn_37.Resizable = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_37.Width = 60;
			this.usrorTnxaCv.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.usrorTnxaCv.DataPropertyName = "Ian";
			dataGridViewCellStyle21.Format = "N0";
			this.usrorTnxaCv.DefaultCellStyle = dataGridViewCellStyle21;
			this.usrorTnxaCv.HeaderText = "Comment";
			this.usrorTnxaCv.MinimumWidth = 80;
			this.usrorTnxaCv.Name = "dataGridViewTextBoxColumn32";
			this.usrorTnxaCv.ReadOnly = true;
			this.dataGridView_5.AllowUserToAddRows = false;
			this.dataGridView_5.AllowUserToDeleteRows = false;
			this.dataGridView_5.AllowUserToOrderColumns = true;
			this.dataGridView_5.AllowUserToResizeRows = false;
			this.dataGridView_5.AutoGenerateColumns = false;
			this.dataGridView_5.BackgroundColor = Color.White;
			dataGridViewCellStyle22.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle22.BackColor = SystemColors.Control;
			dataGridViewCellStyle22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle22.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle22.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle22.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle22.WrapMode = DataGridViewTriState.True;
			this.dataGridView_5.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
			this.dataGridView_5.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView_5.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewCheckBoxColumn_2,
				this.dataGridViewTextBoxColumn_38,
				this.dataGridViewTextBoxColumn_39,
				this.dataGridViewTextBoxColumn_40,
				this.dataGridViewTextBoxColumn_41,
				this.dataGridViewTextBoxColumn_42,
				this.dataGridViewTextBoxColumn_43,
				this.dataGridViewTextBoxColumn_44,
				this.dataGridViewTextBoxColumn_45,
				this.dataGridViewTextBoxColumn_46,
				this.dataGridViewTextBoxColumn_47,
				this.dataGridViewTextBoxColumn_48,
				this.dataGridViewTextBoxColumn_49,
				this.dataGridViewTextBoxColumn_50
			});
			this.tableLayoutPanel_4.SetColumnSpan(this.dataGridView_5, 3);
			this.dataGridView_5.DataSource = this.bindingSource_14;
			dataGridViewCellStyle23.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle23.BackColor = Color.White;
			dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle23.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle23.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle23.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle23.WrapMode = DataGridViewTriState.False;
			this.dataGridView_5.DefaultCellStyle = dataGridViewCellStyle23;
			this.dataGridView_5.Dock = DockStyle.Fill;
			this.dataGridView_5.Location = new Point(3, 132);
			this.dataGridView_5.Margin = new Padding(3, 3, 7, 3);
			this.dataGridView_5.MultiSelect = false;
			this.dataGridView_5.Name = "dgvMeasCell";
			this.dataGridView_5.ReadOnly = true;
			dataGridViewCellStyle24.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle24.BackColor = SystemColors.Control;
			dataGridViewCellStyle24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle24.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle24.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle24.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle24.WrapMode = DataGridViewTriState.True;
			this.dataGridView_5.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
			this.dataGridView_5.RowHeadersVisible = false;
			this.dataGridView_5.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView_5.Size = new Size(792, 29);
			this.dataGridView_5.TabIndex = 12;
			this.dataGridView_5.ColumnWidthChanged += this.dataGridView_5_ColumnWidthChanged;
			this.dataGridView_5.Scroll += this.dataGridView_5_Scroll;
			this.dataGridViewCheckBoxColumn_2.DataPropertyName = "Deleted";
			this.dataGridViewCheckBoxColumn_2.HeaderText = "Deleted";
			this.dataGridViewCheckBoxColumn_2.Name = "deletedDataGridViewCheckBoxColumn4";
			this.dataGridViewCheckBoxColumn_2.ReadOnly = true;
			this.dataGridViewCheckBoxColumn_2.Visible = false;
			this.dataGridViewTextBoxColumn_38.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_38.HeaderText = "id";
			this.dataGridViewTextBoxColumn_38.Name = "idDataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn_38.ReadOnly = true;
			this.dataGridViewTextBoxColumn_38.Visible = false;
			this.dataGridViewTextBoxColumn_39.DataPropertyName = "idMeasurement";
			this.dataGridViewTextBoxColumn_39.HeaderText = "idMeasurement";
			this.dataGridViewTextBoxColumn_39.Name = "idMeasurementDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_39.ReadOnly = true;
			this.dataGridViewTextBoxColumn_39.Visible = false;
			this.dataGridViewTextBoxColumn_40.DataPropertyName = "idBus";
			this.dataGridViewTextBoxColumn_40.HeaderText = "idBus";
			this.dataGridViewTextBoxColumn_40.Name = "idBus";
			this.dataGridViewTextBoxColumn_40.ReadOnly = true;
			this.dataGridViewTextBoxColumn_40.Visible = false;
			this.dataGridViewTextBoxColumn_41.DataPropertyName = "NameBus";
			this.dataGridViewTextBoxColumn_41.HeaderText = "NameBus";
			this.dataGridViewTextBoxColumn_41.Name = "nameBusDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_41.ReadOnly = true;
			this.dataGridViewTextBoxColumn_41.Visible = false;
			this.dataGridViewTextBoxColumn_42.DataPropertyName = "NameCell";
			this.dataGridViewTextBoxColumn_42.HeaderText = "№ руб.";
			this.dataGridViewTextBoxColumn_42.Name = "nameCellDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_42.ReadOnly = true;
			this.dataGridViewTextBoxColumn_42.Width = 30;
			this.dataGridViewTextBoxColumn_43.DataPropertyName = "PermissAmperage";
			this.dataGridViewTextBoxColumn_43.HeaderText = "Допуст. нагр., А";
			this.dataGridViewTextBoxColumn_43.Name = "permissAmperageDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_43.ReadOnly = true;
			this.dataGridViewTextBoxColumn_43.Width = 80;
			this.dataGridViewTextBoxColumn_44.DataPropertyName = "Iad";
			this.dataGridViewTextBoxColumn_44.HeaderText = "А дн.";
			this.dataGridViewTextBoxColumn_44.Name = "iadDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_44.ReadOnly = true;
			this.dataGridViewTextBoxColumn_44.Width = 60;
			this.dataGridViewTextBoxColumn_45.DataPropertyName = "Ian";
			this.dataGridViewTextBoxColumn_45.HeaderText = "А вч.";
			this.dataGridViewTextBoxColumn_45.Name = "ianDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_45.ReadOnly = true;
			this.dataGridViewTextBoxColumn_45.Width = 60;
			this.dataGridViewTextBoxColumn_46.DataPropertyName = "Ibd";
			this.dataGridViewTextBoxColumn_46.HeaderText = "В дн.";
			this.dataGridViewTextBoxColumn_46.Name = "ibdDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_46.ReadOnly = true;
			this.dataGridViewTextBoxColumn_46.Width = 60;
			this.dataGridViewTextBoxColumn_47.DataPropertyName = "Ibn";
			this.dataGridViewTextBoxColumn_47.HeaderText = "В вч.";
			this.dataGridViewTextBoxColumn_47.Name = "ibnDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_47.ReadOnly = true;
			this.dataGridViewTextBoxColumn_47.Width = 60;
			this.dataGridViewTextBoxColumn_48.DataPropertyName = "Icd";
			this.dataGridViewTextBoxColumn_48.HeaderText = "С дн.";
			this.dataGridViewTextBoxColumn_48.Name = "icdDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_48.ReadOnly = true;
			this.dataGridViewTextBoxColumn_48.Width = 60;
			this.dataGridViewTextBoxColumn_49.DataPropertyName = "Icn";
			this.dataGridViewTextBoxColumn_49.HeaderText = "С вч.";
			this.dataGridViewTextBoxColumn_49.Name = "icnDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_49.ReadOnly = true;
			this.dataGridViewTextBoxColumn_49.Width = 60;
			this.dataGridViewTextBoxColumn_50.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_50.DataPropertyName = "Comment";
			this.dataGridViewTextBoxColumn_50.HeaderText = "Комментарий";
			this.dataGridViewTextBoxColumn_50.Name = "commentDataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn_50.ReadOnly = true;
			this.bindingSource_14.DataMember = "vJ_MeasCell";
			this.bindingSource_14.DataSource = this.class255_0;
			this.label_23.AutoSize = true;
			this.label_23.BorderStyle = BorderStyle.FixedSingle;
			this.label_23.Dock = DockStyle.Fill;
			this.label_23.Location = new Point(3, 0);
			this.label_23.Name = "label28";
			this.label_23.Size = new Size(152, 21);
			this.label_23.TabIndex = 18;
			this.label_23.Text = "Секция шин №";
			this.label_23.TextAlign = ContentAlignment.MiddleCenter;
			this.comboBox_2.DataSource = this.bindingSource_15;
			this.comboBox_2.DisplayMember = "Name";
			this.comboBox_2.Dock = DockStyle.Left;
			this.comboBox_2.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_2.FormattingEnabled = true;
			this.comboBox_2.Location = new Point(158, 0);
			this.comboBox_2.Margin = new Padding(0);
			this.comboBox_2.Name = "cbBusesMV";
			this.comboBox_2.Size = new Size(103, 21);
			this.comboBox_2.TabIndex = 19;
			this.comboBox_2.ValueMember = "idBus";
			this.label_29.AutoSize = true;
			this.label_29.Dock = DockStyle.Left;
			this.label_29.Location = new Point(304, 0);
			this.label_29.Name = "lbTransfName";
			this.label_29.Size = new Size(106, 21);
			this.label_29.TabIndex = 21;
			this.label_29.Text = "Трансформатор № ";
			this.label_29.TextAlign = ContentAlignment.MiddleLeft;
			this.tableLayoutPanel_2.ColumnCount = 2;
			this.tableLayoutPanel_2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 212f));
			this.tableLayoutPanel_2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel_2.Controls.Add(this.tableLayoutPanel_1, 1, 0);
			this.tableLayoutPanel_2.Controls.Add(this.tableLayoutPanel_0, 0, 0);
			this.tableLayoutPanel_2.Dock = DockStyle.Fill;
			this.tableLayoutPanel_2.Location = new Point(0, 0);
			this.tableLayoutPanel_2.Name = "tableLayoutPanel1";
			this.tableLayoutPanel_2.RowCount = 1;
			this.tableLayoutPanel_2.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel_2.Size = new Size(1034, 562);
			this.tableLayoutPanel_2.TabIndex = 3;
			this.dataGridViewCheckBoxColumn_0.DataPropertyName = "Deleted";
			this.dataGridViewCheckBoxColumn_0.HeaderText = "Deleted";
			this.dataGridViewCheckBoxColumn_0.Name = "deletedDataGridViewCheckBoxColumn2";
			this.dataGridViewCheckBoxColumn_1.DataPropertyName = "Deleted";
			this.dataGridViewCheckBoxColumn_1.HeaderText = "Deleted";
			this.dataGridViewCheckBoxColumn_1.Name = "deletedDataGridViewCheckBoxColumn3";
			this.bindingSource_3.DataMember = "fn_J_GetCellLVByTransf";
			this.bindingSource_3.DataSource = this.class255_0;
			this.bindingSource_3.Sort = "Name";
			this.bindingSource_4.DataMember = "tR_CableMakeup";
			this.bindingSource_4.DataSource = this.class255_0;
			this.bindingSource_4.Filter = "";
			this.bindingSource_5.DataMember = "tR_CableVoltage";
			this.bindingSource_5.DataSource = this.class255_0;
			this.bindingSource_5.Filter = "";
			this.bindingSource_6.DataMember = "tR_CrossSection";
			this.bindingSource_6.DataSource = this.class255_0;
			this.bindingSource_6.Filter = "";
			this.bindingSource_2.DataMember = "tP_ValueLists";
			this.bindingSource_2.DataSource = this.class255_0;
			this.bindingSource_2.Sort = "Name";
			this.riZoLnrtjNx.DataMember = "tR_Classifier";
			this.riZoLnrtjNx.DataSource = this.class255_0;
			this.riZoLnrtjNx.Filter = "ParentKey = ';Measurement;Type;'";
			this.bindingSource_13.DataMember = "vJ_GetMeasYears";
			this.bindingSource_13.DataSource = this.class255_0;
			this.bindingSource_13.Sort = "Year DESC";
			this.bindingSource_13.CurrentChanged += this.bindingSource_13_CurrentChanged;
			this.dataGridViewTextBoxColumn_51.DataPropertyName = "idSchmObj";
			this.dataGridViewTextBoxColumn_51.HeaderText = "idSchmObj";
			this.dataGridViewTextBoxColumn_51.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_51.Visible = false;
			this.dataGridViewTextBoxColumn_52.DataPropertyName = "Region";
			this.dataGridViewTextBoxColumn_52.HeaderText = "Район";
			this.dataGridViewTextBoxColumn_52.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn_52.Width = 120;
			this.dataGridViewTextBoxColumn_53.DataPropertyName = "Street";
			this.dataGridViewTextBoxColumn_53.HeaderText = "Улица";
			this.dataGridViewTextBoxColumn_53.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn_53.Width = 180;
			this.yKeogyoCsw7.DataPropertyName = "House";
			this.yKeogyoCsw7.HeaderText = "Дом";
			this.yKeogyoCsw7.Name = "dataGridViewTextBoxColumn4";
			this.yKeogyoCsw7.Width = 50;
			this.dataGridViewTextBoxColumn_54.DataPropertyName = "HousePrefix";
			this.dataGridViewTextBoxColumn_54.HeaderText = "Доп.";
			this.dataGridViewTextBoxColumn_54.Name = "dataGridViewTextBoxColumn5";
			this.dataGridViewTextBoxColumn_54.Width = 50;
			this.dataGridViewTextBoxColumn_55.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_55.DataPropertyName = "Name";
			this.dataGridViewTextBoxColumn_55.HeaderText = "Наименование";
			this.dataGridViewTextBoxColumn_55.Name = "dataGridViewTextBoxColumn6";
			this.dataGridViewTextBoxColumn_56.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			this.dataGridViewTextBoxColumn_56.HeaderText = "SumName";
			this.dataGridViewTextBoxColumn_56.Name = "dataGridViewTextBoxColumn7";
			this.dataGridViewTextBoxColumn_56.Width = 360;
			this.dataGridViewTextBoxColumn_57.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			this.dataGridViewTextBoxColumn_57.HeaderText = "ad";
			this.dataGridViewTextBoxColumn_57.Name = "dataGridViewTextBoxColumn8";
			this.dataGridViewTextBoxColumn_57.Width = 40;
			this.dataGridViewTextBoxColumn_58.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			this.dataGridViewTextBoxColumn_58.HeaderText = "an";
			this.dataGridViewTextBoxColumn_58.Name = "dataGridViewTextBoxColumn9";
			this.dataGridViewTextBoxColumn_58.Width = 40;
			this.dataGridViewTextBoxColumn_59.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			this.dataGridViewTextBoxColumn_59.HeaderText = "bd";
			this.dataGridViewTextBoxColumn_59.Name = "dataGridViewTextBoxColumn10";
			this.dataGridViewTextBoxColumn_59.Width = 40;
			this.dataGridViewTextBoxColumn_60.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			this.dataGridViewTextBoxColumn_60.HeaderText = "bn";
			this.dataGridViewTextBoxColumn_60.Name = "dataGridViewTextBoxColumn11";
			this.dataGridViewTextBoxColumn_60.Width = 40;
			this.dataGridViewTextBoxColumn_61.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			this.dataGridViewTextBoxColumn_61.HeaderText = "cd";
			this.dataGridViewTextBoxColumn_61.Name = "dataGridViewTextBoxColumn12";
			this.dataGridViewTextBoxColumn_61.Width = 40;
			this.dataGridViewTextBoxColumn_62.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			this.dataGridViewTextBoxColumn_62.HeaderText = "cn";
			this.dataGridViewTextBoxColumn_62.Name = "dataGridViewTextBoxColumn13";
			this.dataGridViewTextBoxColumn_62.Width = 40;
			this.dataGridViewTextBoxColumn_63.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			this.dataGridViewTextBoxColumn_63.HeaderText = "od";
			this.dataGridViewTextBoxColumn_63.Name = "dataGridViewTextBoxColumn14";
			this.dataGridViewTextBoxColumn_63.Width = 40;
			this.dataGridViewTextBoxColumn_64.HeaderText = "on";
			this.dataGridViewTextBoxColumn_64.Name = "dataGridViewTextBoxColumn15";
			this.dataGridViewTextBoxColumn_64.Width = 40;
			this.dataGridViewTextBoxColumn_65.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_65.HeaderText = "Comment";
			this.dataGridViewTextBoxColumn_65.MinimumWidth = 80;
			this.dataGridViewTextBoxColumn_65.Name = "dataGridViewTextBoxColumn16";
			this.dataGridViewTextBoxColumn_66.DataPropertyName = "NameCell";
			this.dataGridViewTextBoxColumn_66.HeaderText = "№ руб.";
			this.dataGridViewTextBoxColumn_66.Name = "dataGridViewTextBoxColumn17";
			this.dataGridViewTextBoxColumn_66.Width = 30;
			this.dataGridViewTextBoxColumn_67.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_67.HeaderText = "id";
			this.dataGridViewTextBoxColumn_67.Name = "dataGridViewTextBoxColumn18";
			this.dataGridViewTextBoxColumn_67.Visible = false;
			this.dataGridViewTextBoxColumn_68.DataPropertyName = "idMeasurement";
			this.dataGridViewTextBoxColumn_68.HeaderText = "idMeasurement";
			this.dataGridViewTextBoxColumn_68.Name = "dataGridViewTextBoxColumn19";
			this.dataGridViewTextBoxColumn_68.Visible = false;
			this.dataGridViewTextBoxColumn_69.DataPropertyName = "idTransf";
			this.dataGridViewTextBoxColumn_69.HeaderText = "idTransf";
			this.dataGridViewTextBoxColumn_69.Name = "dataGridViewTextBoxColumn20";
			this.dataGridViewTextBoxColumn_69.Visible = false;
			this.dataGridViewTextBoxColumn_70.DataPropertyName = "idCell";
			this.dataGridViewTextBoxColumn_70.HeaderText = "idCell";
			this.dataGridViewTextBoxColumn_70.Name = "dataGridViewTextBoxColumn21";
			this.dataGridViewTextBoxColumn_70.Resizable = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_70.Visible = false;
			this.dataGridViewTextBoxColumn_70.Width = 30;
			this.WrRogfhGjk9.DataPropertyName = "OldCell";
			this.WrRogfhGjk9.HeaderText = "№ Ст.р";
			this.WrRogfhGjk9.Name = "dataGridViewTextBoxColumn22";
			this.WrRogfhGjk9.Width = 30;
			this.dataGridViewTextBoxColumn_71.DataPropertyName = "PermisAmperage";
			dataGridViewCellStyle25.Format = "N0";
			this.dataGridViewTextBoxColumn_71.DefaultCellStyle = dataGridViewCellStyle25;
			this.dataGridViewTextBoxColumn_71.HeaderText = "Допуст. нагр., А";
			this.dataGridViewTextBoxColumn_71.Name = "dataGridViewTextBoxColumn30";
			this.dataGridViewTextBoxColumn_71.Width = 50;
			this.dataGridViewTextBoxColumn_72.DataPropertyName = "Iad";
			dataGridViewCellStyle26.Format = "N0";
			dataGridViewCellStyle26.NullValue = null;
			this.dataGridViewTextBoxColumn_72.DefaultCellStyle = dataGridViewCellStyle26;
			this.dataGridViewTextBoxColumn_72.HeaderText = "А дн.";
			this.dataGridViewTextBoxColumn_72.Name = "dataGridViewTextBoxColumn31";
			this.dataGridViewTextBoxColumn_72.Width = 40;
			this.dataGridViewTextBoxColumn_73.DataPropertyName = "Ibd";
			this.dataGridViewTextBoxColumn_73.HeaderText = "В дн.";
			this.dataGridViewTextBoxColumn_73.Name = "dataGridViewTextBoxColumn33";
			this.dataGridViewTextBoxColumn_73.Width = 40;
			this.dataGridViewTextBoxColumn_74.DataPropertyName = "Ibn";
			this.dataGridViewTextBoxColumn_74.HeaderText = "В вч.";
			this.dataGridViewTextBoxColumn_74.Name = "dataGridViewTextBoxColumn34";
			this.dataGridViewTextBoxColumn_74.Width = 40;
			this.dataGridViewTextBoxColumn_75.DataPropertyName = "Icd";
			this.dataGridViewTextBoxColumn_75.HeaderText = "С дн.";
			this.dataGridViewTextBoxColumn_75.Name = "dataGridViewTextBoxColumn35";
			this.dataGridViewTextBoxColumn_75.Width = 40;
			this.dataGridViewTextBoxColumn_76.DataPropertyName = "Icn";
			this.dataGridViewTextBoxColumn_76.HeaderText = "С вч.";
			this.dataGridViewTextBoxColumn_76.Name = "dataGridViewTextBoxColumn36";
			this.dataGridViewTextBoxColumn_76.Width = 40;
			this.dataGridViewTextBoxColumn_77.DataPropertyName = "Iod";
			this.dataGridViewTextBoxColumn_77.HeaderText = "0 дн.";
			this.dataGridViewTextBoxColumn_77.Name = "dataGridViewTextBoxColumn37";
			this.dataGridViewTextBoxColumn_77.Width = 40;
			this.dataGridViewTextBoxColumn_78.DataPropertyName = "Ion";
			this.dataGridViewTextBoxColumn_78.HeaderText = "0 вч.";
			this.dataGridViewTextBoxColumn_78.Name = "dataGridViewTextBoxColumn38";
			this.dataGridViewTextBoxColumn_78.Width = 40;
			this.dataGridViewTextBoxColumn_79.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_79.DataPropertyName = "Comment";
			this.dataGridViewTextBoxColumn_79.HeaderText = "Комментарий";
			this.dataGridViewTextBoxColumn_79.MinimumWidth = 80;
			this.dataGridViewTextBoxColumn_79.Name = "dataGridViewTextBoxColumn39";
			this.dataGridViewTextBoxColumn_80.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_80.HeaderText = "id";
			this.dataGridViewTextBoxColumn_80.Name = "dataGridViewTextBoxColumn40";
			this.dataGridViewTextBoxColumn_80.Visible = false;
			this.dataGridViewTextBoxColumn_81.DataPropertyName = "idObjList";
			this.dataGridViewTextBoxColumn_81.HeaderText = "idObjList";
			this.dataGridViewTextBoxColumn_81.Name = "dataGridViewTextBoxColumn41";
			this.dataGridViewTextBoxColumn_81.Visible = false;
			this.dataGridViewTextBoxColumn_82.DataPropertyName = "DateD";
			this.dataGridViewTextBoxColumn_82.HeaderText = "Дата замера дн.";
			this.dataGridViewTextBoxColumn_82.MinimumWidth = 70;
			this.dataGridViewTextBoxColumn_82.Name = "dataGridViewTextBoxColumn42";
			this.dataGridViewTextBoxColumn_83.DataPropertyName = "TemperatureD";
			dataGridViewCellStyle27.Alignment = DataGridViewContentAlignment.MiddleCenter;
			this.dataGridViewTextBoxColumn_83.DefaultCellStyle = dataGridViewCellStyle27;
			this.dataGridViewTextBoxColumn_83.HeaderText = "Температура дн.";
			this.dataGridViewTextBoxColumn_83.MinimumWidth = 70;
			this.dataGridViewTextBoxColumn_83.Name = "dataGridViewTextBoxColumn43";
			this.dataGridViewTextBoxColumn_84.DataPropertyName = "DateN";
			this.dataGridViewTextBoxColumn_84.HeaderText = "Дата замера вч.";
			this.dataGridViewTextBoxColumn_84.MinimumWidth = 70;
			this.dataGridViewTextBoxColumn_84.Name = "dataGridViewTextBoxColumn44";
			this.dataGridViewTextBoxColumn_85.DataPropertyName = "TemperatureN";
			dataGridViewCellStyle28.Alignment = DataGridViewContentAlignment.MiddleCenter;
			this.dataGridViewTextBoxColumn_85.DefaultCellStyle = dataGridViewCellStyle28;
			this.dataGridViewTextBoxColumn_85.HeaderText = "Температура вч.";
			this.dataGridViewTextBoxColumn_85.MinimumWidth = 70;
			this.dataGridViewTextBoxColumn_85.Name = "dataGridViewTextBoxColumn45";
			this.dataGridViewTextBoxColumn_86.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_86.DataPropertyName = "Comment";
			this.dataGridViewTextBoxColumn_86.HeaderText = "Дополнительно";
			this.dataGridViewTextBoxColumn_86.MinimumWidth = 100;
			this.dataGridViewTextBoxColumn_86.Name = "dataGridViewTextBoxColumn46";
			this.dataGridViewTextBoxColumn_87.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			this.dataGridViewTextBoxColumn_87.HeaderText = "SumName";
			this.dataGridViewTextBoxColumn_87.Name = "dataGridViewTextBoxColumn47";
			this.dataGridViewTextBoxColumn_87.Width = 110;
			this.dataGridViewTextBoxColumn_88.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			this.dataGridViewTextBoxColumn_88.HeaderText = "ad";
			this.dataGridViewTextBoxColumn_88.Name = "dataGridViewTextBoxColumn48";
			this.dataGridViewTextBoxColumn_88.Width = 60;
			this.dataGridViewTextBoxColumn_89.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			this.dataGridViewTextBoxColumn_89.HeaderText = "an";
			this.dataGridViewTextBoxColumn_89.Name = "dataGridViewTextBoxColumn49";
			this.dataGridViewTextBoxColumn_89.Width = 60;
			this.dataGridViewTextBoxColumn_90.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			this.dataGridViewTextBoxColumn_90.HeaderText = "bd";
			this.dataGridViewTextBoxColumn_90.Name = "dataGridViewTextBoxColumn50";
			this.dataGridViewTextBoxColumn_90.Width = 60;
			this.dataGridViewTextBoxColumn_91.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			this.dataGridViewTextBoxColumn_91.HeaderText = "bn";
			this.dataGridViewTextBoxColumn_91.Name = "dataGridViewTextBoxColumn51";
			this.dataGridViewTextBoxColumn_91.Width = 60;
			this.dataGridViewTextBoxColumn_92.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			this.dataGridViewTextBoxColumn_92.HeaderText = "cd";
			this.dataGridViewTextBoxColumn_92.Name = "dataGridViewTextBoxColumn52";
			this.dataGridViewTextBoxColumn_92.Width = 60;
			this.dataGridViewTextBoxColumn_93.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			this.dataGridViewTextBoxColumn_93.HeaderText = "cn";
			this.dataGridViewTextBoxColumn_93.Name = "dataGridViewTextBoxColumn53";
			this.dataGridViewTextBoxColumn_93.Width = 60;
			this.dataGridViewTextBoxColumn_94.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_94.HeaderText = "Comment";
			this.dataGridViewTextBoxColumn_94.MinimumWidth = 80;
			this.dataGridViewTextBoxColumn_94.Name = "dataGridViewTextBoxColumn54";
			this.dataGridViewTextBoxColumn_95.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_95.HeaderText = "id";
			this.dataGridViewTextBoxColumn_95.Name = "dataGridViewTextBoxColumn55";
			this.dataGridViewTextBoxColumn_95.Visible = false;
			this.dataGridViewTextBoxColumn_96.DataPropertyName = "idMeasurement";
			this.dataGridViewTextBoxColumn_96.HeaderText = "idMeasurement";
			this.dataGridViewTextBoxColumn_96.Name = "dataGridViewTextBoxColumn56";
			this.dataGridViewTextBoxColumn_96.Visible = false;
			this.dataGridViewTextBoxColumn_97.DataPropertyName = "idBus";
			this.dataGridViewTextBoxColumn_97.HeaderText = "idBus";
			this.dataGridViewTextBoxColumn_97.Name = "dataGridViewTextBoxColumn57";
			this.dataGridViewTextBoxColumn_97.Visible = false;
			this.eeEoggXrFln.DataPropertyName = "NameBus";
			this.eeEoggXrFln.HeaderText = "NameBus";
			this.eeEoggXrFln.Name = "dataGridViewTextBoxColumn58";
			this.eeEoggXrFln.Visible = false;
			this.dataGridViewTextBoxColumn_98.DataPropertyName = "NameCell";
			this.dataGridViewTextBoxColumn_98.HeaderText = "№ руб.";
			this.dataGridViewTextBoxColumn_98.Name = "dataGridViewTextBoxColumn59";
			this.dataGridViewTextBoxColumn_98.Width = 30;
			this.dataGridViewTextBoxColumn_99.DataPropertyName = "PermissAmperage";
			this.dataGridViewTextBoxColumn_99.HeaderText = "Допуст. нагр., А";
			this.dataGridViewTextBoxColumn_99.Name = "dataGridViewTextBoxColumn60";
			this.dataGridViewTextBoxColumn_99.Width = 80;
			this.dataGridViewTextBoxColumn_100.DataPropertyName = "Iad";
			this.dataGridViewTextBoxColumn_100.HeaderText = "А дн.";
			this.dataGridViewTextBoxColumn_100.Name = "dataGridViewTextBoxColumn61";
			this.dataGridViewTextBoxColumn_100.Width = 60;
			this.dataGridViewTextBoxColumn_101.DataPropertyName = "Ian";
			this.dataGridViewTextBoxColumn_101.HeaderText = "А вч.";
			this.dataGridViewTextBoxColumn_101.Name = "dataGridViewTextBoxColumn62";
			this.dataGridViewTextBoxColumn_101.Width = 60;
			this.dataGridViewTextBoxColumn_102.DataPropertyName = "Ibd";
			this.dataGridViewTextBoxColumn_102.HeaderText = "В дн.";
			this.dataGridViewTextBoxColumn_102.Name = "dataGridViewTextBoxColumn63";
			this.dataGridViewTextBoxColumn_102.Width = 60;
			this.dataGridViewTextBoxColumn_103.DataPropertyName = "Ibn";
			this.dataGridViewTextBoxColumn_103.HeaderText = "В вч.";
			this.dataGridViewTextBoxColumn_103.Name = "dataGridViewTextBoxColumn64";
			this.dataGridViewTextBoxColumn_103.Width = 60;
			this.dataGridViewTextBoxColumn_104.DataPropertyName = "Icd";
			this.dataGridViewTextBoxColumn_104.HeaderText = "С дн.";
			this.dataGridViewTextBoxColumn_104.Name = "dataGridViewTextBoxColumn65";
			this.dataGridViewTextBoxColumn_104.Width = 60;
			this.dataGridViewTextBoxColumn_105.DataPropertyName = "Icn";
			this.dataGridViewTextBoxColumn_105.HeaderText = "С вч.";
			this.dataGridViewTextBoxColumn_105.Name = "dataGridViewTextBoxColumn66";
			this.dataGridViewTextBoxColumn_105.Width = 60;
			this.dataGridViewTextBoxColumn_106.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_106.DataPropertyName = "Comment";
			this.dataGridViewTextBoxColumn_106.HeaderText = "Комментарий";
			this.dataGridViewTextBoxColumn_106.Name = "dataGridViewTextBoxColumn67";
			this.dataGridViewTextBoxColumn_0.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_0.HeaderText = "id";
			this.dataGridViewTextBoxColumn_0.Name = "idDataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn_0.ReadOnly = true;
			this.dataGridViewTextBoxColumn_1.DataPropertyName = "idObjList";
			this.dataGridViewTextBoxColumn_1.HeaderText = "idObjList";
			this.dataGridViewTextBoxColumn_1.Name = "idObjListDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_2.DataPropertyName = "TypeDoc";
			this.dataGridViewTextBoxColumn_2.HeaderText = "TypeDoc";
			this.dataGridViewTextBoxColumn_2.Name = "typeDocDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_3.DataPropertyName = "Year";
			this.dataGridViewTextBoxColumn_3.HeaderText = "Year";
			this.dataGridViewTextBoxColumn_3.Name = "yearDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_4.DataPropertyName = "DateD";
			this.dataGridViewTextBoxColumn_4.HeaderText = "DateD";
			this.dataGridViewTextBoxColumn_4.Name = "dateDDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_5.DataPropertyName = "TemperatureD";
			this.dataGridViewTextBoxColumn_5.HeaderText = "TemperatureD";
			this.dataGridViewTextBoxColumn_5.Name = "temperatureDDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_6.DataPropertyName = "DateN";
			this.dataGridViewTextBoxColumn_6.HeaderText = "DateN";
			this.dataGridViewTextBoxColumn_6.Name = "dateNDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_7.DataPropertyName = "TemperatureN";
			this.dataGridViewTextBoxColumn_7.HeaderText = "TemperatureN";
			this.dataGridViewTextBoxColumn_7.Name = "temperatureNDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_8.DataPropertyName = "idWorker";
			this.dataGridViewTextBoxColumn_8.HeaderText = "idWorker";
			this.dataGridViewTextBoxColumn_8.Name = "idWorkerDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_9.DataPropertyName = "Comment";
			this.dataGridViewTextBoxColumn_9.HeaderText = "Comment";
			this.dataGridViewTextBoxColumn_9.Name = "commentDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_10.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_10.HeaderText = "id";
			this.dataGridViewTextBoxColumn_10.Name = "idDataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn_11.DataPropertyName = "idMeasurement";
			this.dataGridViewTextBoxColumn_11.HeaderText = "idMeasurement";
			this.dataGridViewTextBoxColumn_11.Name = "idMeasurementDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_12.DataPropertyName = "idTransf";
			this.dataGridViewTextBoxColumn_12.HeaderText = "idTransf";
			this.dataGridViewTextBoxColumn_12.Name = "idTransfDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_13.DataPropertyName = "idCell";
			this.dataGridViewTextBoxColumn_13.HeaderText = "idCell";
			this.dataGridViewTextBoxColumn_13.Name = "idCellDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_14.DataPropertyName = "NameCell";
			this.dataGridViewTextBoxColumn_14.HeaderText = "NameCell";
			this.dataGridViewTextBoxColumn_14.Name = "nameCellDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_15.DataPropertyName = "OldCell";
			this.dataGridViewTextBoxColumn_15.HeaderText = "OldCell";
			this.dataGridViewTextBoxColumn_15.Name = "oldCellDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_16.DataPropertyName = "idCable";
			this.dataGridViewTextBoxColumn_16.HeaderText = "idCable";
			this.dataGridViewTextBoxColumn_16.Name = "idCableDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_17.DataPropertyName = "idSchmAbn";
			this.dataGridViewTextBoxColumn_17.HeaderText = "idSchmAbn";
			this.dataGridViewTextBoxColumn_17.Name = "idSchmAbnDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_18.DataPropertyName = "Makeup";
			this.dataGridViewTextBoxColumn_18.HeaderText = "Makeup";
			this.dataGridViewTextBoxColumn_18.Name = "makeupDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_19.DataPropertyName = "Voltage";
			this.dataGridViewTextBoxColumn_19.HeaderText = "Voltage";
			this.dataGridViewTextBoxColumn_19.Name = "voltageDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_20.DataPropertyName = "Wires";
			this.dataGridViewTextBoxColumn_20.HeaderText = "Wires";
			this.dataGridViewTextBoxColumn_20.Name = "wiresDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_21.DataPropertyName = "CrossSection";
			this.dataGridViewTextBoxColumn_21.HeaderText = "CrossSection";
			this.dataGridViewTextBoxColumn_21.Name = "crossSectionDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_22.DataPropertyName = "PermisAmperage";
			this.dataGridViewTextBoxColumn_22.HeaderText = "PermisAmperage";
			this.dataGridViewTextBoxColumn_22.Name = "permisAmperageDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_23.DataPropertyName = "Iad";
			this.dataGridViewTextBoxColumn_23.HeaderText = "Iad";
			this.dataGridViewTextBoxColumn_23.Name = "iadDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_24.DataPropertyName = "Ian";
			this.dataGridViewTextBoxColumn_24.HeaderText = "Ian";
			this.dataGridViewTextBoxColumn_24.Name = "ianDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_25.DataPropertyName = "Ibd";
			this.dataGridViewTextBoxColumn_25.HeaderText = "Ibd";
			this.dataGridViewTextBoxColumn_25.Name = "ibdDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_26.DataPropertyName = "Ibn";
			this.dataGridViewTextBoxColumn_26.HeaderText = "Ibn";
			this.dataGridViewTextBoxColumn_26.Name = "ibnDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_27.DataPropertyName = "Icd";
			this.dataGridViewTextBoxColumn_27.HeaderText = "Icd";
			this.dataGridViewTextBoxColumn_27.Name = "icdDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_28.DataPropertyName = "Icn";
			this.dataGridViewTextBoxColumn_28.HeaderText = "Icn";
			this.dataGridViewTextBoxColumn_28.Name = "icnDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_29.DataPropertyName = "Iod";
			this.dataGridViewTextBoxColumn_29.HeaderText = "Iod";
			this.dataGridViewTextBoxColumn_29.Name = "iodDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_30.DataPropertyName = "Ion";
			this.dataGridViewTextBoxColumn_30.HeaderText = "Ion";
			this.dataGridViewTextBoxColumn_30.Name = "ionDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_31.DataPropertyName = "Comment";
			this.dataGridViewTextBoxColumn_31.HeaderText = "Comment";
			this.dataGridViewTextBoxColumn_31.Name = "commentDataGridViewTextBoxColumn2";
			this.bindingSource_16.DataMember = "vJ_BusesTransfSchema";
			this.bindingSource_16.DataSource = this.class255_0;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(1034, 562);
			base.Controls.Add(this.tableLayoutPanel_2);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "FormMeasurement";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Листок замеров";
			base.Load += this.FormMeasurement_Load;
			base.Shown += this.FormMeasurement_Shown;
			this.tableLayoutPanel_0.ResumeLayout(false);
			this.tableLayoutPanel_0.PerformLayout();
			this.toolStrip_0.ResumeLayout(false);
			this.toolStrip_0.PerformLayout();
			this.tableLayoutPanel_1.ResumeLayout(false);
			this.tableLayoutPanel_1.PerformLayout();
			this.toolStrip_1.ResumeLayout(false);
			this.toolStrip_1.PerformLayout();
			this.tableLayoutPanel_3.ResumeLayout(false);
			((ISupportInitialize)this.bindingSource_15).EndInit();
			((ISupportInitialize)this.class255_0).EndInit();
			this.tabControl_0.ResumeLayout(false);
			this.tabPage_0.ResumeLayout(false);
			this.tabPage_0.PerformLayout();
			this.tabPage_1.ResumeLayout(false);
			((ISupportInitialize)this.dataGridView_0).EndInit();
			((ISupportInitialize)this.bindingSource_8).EndInit();
			this.panel_0.ResumeLayout(false);
			this.panel_1.ResumeLayout(false);
			this.panel_1.PerformLayout();
			((ISupportInitialize)this.bindingSource_0).EndInit();
			this.panel_2.ResumeLayout(false);
			((ISupportInitialize)this.bindingSource_1).EndInit();
			((ISupportInitialize)this.bindingSource_12).EndInit();
			this.panel_3.ResumeLayout(false);
			this.panel_3.PerformLayout();
			this.panel_4.ResumeLayout(false);
			this.panel_4.PerformLayout();
			this.panel_5.ResumeLayout(false);
			this.panel_5.PerformLayout();
			((ISupportInitialize)this.dataGridView_1).EndInit();
			this.panel_6.ResumeLayout(false);
			this.panel_7.ResumeLayout(false);
			this.panel_7.PerformLayout();
			this.panel_9.ResumeLayout(false);
			this.panel_9.PerformLayout();
			this.panel_10.ResumeLayout(false);
			this.panel_10.PerformLayout();
			this.panel_11.ResumeLayout(false);
			this.panel_11.PerformLayout();
			this.panel_12.ResumeLayout(false);
			this.panel_12.PerformLayout();
			this.panel_13.ResumeLayout(false);
			this.panel_13.PerformLayout();
			((ISupportInitialize)this.dataGridView_2).EndInit();
			((ISupportInitialize)this.bindingSource_7).EndInit();
			((ISupportInitialize)this.dataGridView_3).EndInit();
			((ISupportInitialize)this.bindingSource_10).EndInit();
			((ISupportInitialize)this.bindingSource_17).EndInit();
			((ISupportInitialize)this.bindingSource_9).EndInit();
			this.tableLayoutPanel_4.ResumeLayout(false);
			this.tableLayoutPanel_4.PerformLayout();
			this.panel_14.ResumeLayout(false);
			this.panel_15.ResumeLayout(false);
			this.panel_15.PerformLayout();
			this.panel_16.ResumeLayout(false);
			this.panel_16.PerformLayout();
			this.panel_17.ResumeLayout(false);
			this.panel_17.PerformLayout();
			this.panel_18.ResumeLayout(false);
			this.panel_18.PerformLayout();
			this.panel_19.ResumeLayout(false);
			this.panel_20.ResumeLayout(false);
			this.panel_21.ResumeLayout(false);
			this.panel_22.ResumeLayout(false);
			this.panel_23.ResumeLayout(false);
			this.panel_23.PerformLayout();
			((ISupportInitialize)this.bindingSource_11).EndInit();
			this.panel_24.ResumeLayout(false);
			this.panel_24.PerformLayout();
			this.panel_25.ResumeLayout(false);
			this.panel_25.PerformLayout();
			((ISupportInitialize)this.dataGridView_4).EndInit();
			((ISupportInitialize)this.dataGridView_5).EndInit();
			((ISupportInitialize)this.bindingSource_14).EndInit();
			this.tableLayoutPanel_2.ResumeLayout(false);
			((ISupportInitialize)this.bindingSource_3).EndInit();
			((ISupportInitialize)this.bindingSource_4).EndInit();
			((ISupportInitialize)this.bindingSource_5).EndInit();
			((ISupportInitialize)this.bindingSource_6).EndInit();
			((ISupportInitialize)this.bindingSource_2).EndInit();
			((ISupportInitialize)this.riZoLnrtjNx).EndInit();
			((ISupportInitialize)this.bindingSource_13).EndInit();
			((ISupportInitialize)this.bindingSource_16).EndInit();
			base.ResumeLayout(false);
		}

		[CompilerGenerated]
		private bool method_30(Class255.Class369 class369_0)
		{
			return class369_0.Value == (int)this.typeDoc_1 && class369_0.ParentKey == ";Measurement;Type;";
		}

		[CompilerGenerated]
		private bool method_31(Class255.Class410 class410_0)
		{
			return class410_0.id == (int)((DataRowView)this.bindingSource_9.Current)["id"];
		}

		internal static void mYW7dK0yJ91iNuB2BTFU(Form form_0, bool bool_1)
		{
			form_0.Dispose(bool_1);
		}

		private FormMeasurement.Enum11 enum11_0;

		private FormDockPassport.Sort sort_0;

		private FormDockPassport.FillTree fillTree_0;

		private ObjList objList_0;

		private ObjList objList_1;

		private int int_0;

		private FormMeasurement.TypeDoc typeDoc_0;

		private FormMeasurement.TypeDoc typeDoc_1;

		private bool bool_0;

		private int int_1;

		private int int_2;

		private int int_3;

		private int int_4;

		private string string_0;

		private int int_5;

		private int int_6;

		private string string_1;

		private TableLayoutPanel tableLayoutPanel_0;

		private TreeView treeView_0;

		private ToolStrip toolStrip_0;

		private ToolStripTextBox toolStripTextBox_0;

		private ToolStripButton toolStripButton_0;

		private ToolStripButton toolStripButton_1;

		private ToolStripSeparator toolStripSeparator_0;

		private ToolStripButton toolStripButton_2;

		private TableLayoutPanel tableLayoutPanel_1;

		private ToolStrip toolStrip_1;

		private ToolStripButton toolStripButton_3;

		private ToolStripButton toolStripButton_4;

		private ToolStripButton toolStripButton_5;

		private ToolStripSeparator toolStripSeparator_1;

		private ToolStripSeparator toolStripSeparator_2;

		private ToolStripLabel toolStripLabel_0;

		private ToolStripComboBox toolStripComboBox_0;

		private Button button_0;

		private BindingSource bindingSource_0;

		private Class255 class255_0;

		private BindingSource bindingSource_1;

		private BindingSource bindingSource_2;

		private BindingSource bindingSource_3;

		private BindingSource bindingSource_4;

		private BindingSource bindingSource_5;

		private BindingSource bindingSource_6;

		private BindingSource bindingSource_7;

		private BindingSource bindingSource_8;

		private BindingSource bindingSource_9;

		private BindingSource bindingSource_10;

		private BindingSource bindingSource_11;

		private BindingSource bindingSource_12;

		private BindingSource riZoLnrtjNx;

		private ToolStripButton toolStripButton_6;

		private ToolStripSeparator toolStripSeparator_3;

		private BindingSource bindingSource_13;

		private TableLayoutPanel tableLayoutPanel_2;

		private ToolStripButton toolStripButton_7;

		private ToolStripSeparator toolStripSeparator_4;

		private ToolStripSplitButton toolStripSplitButton_0;

		private ToolStripMenuItem toolStripMenuItem_0;

		private ToolStripMenuItem toolStripMenuItem_1;

		private ToolStripMenuItem toolStripMenuItem_2;

		private ToolStripMenuItem toolStripMenuItem_3;

		private ToolStripSplitButton toolStripSplitButton_1;

		private ToolStripMenuItem toolStripMenuItem_4;

		private ToolStripMenuItem toolStripMenuItem_5;

		private TableLayoutPanel tableLayoutPanel_3;

		private ComboBox comboBox_0;

		private Label label_0;

		private TabControl tabControl_0;

		private TabPage tabPage_0;

		private Label label_1;

		private Label label_2;

		private Label label_3;

		private Label label_4;

		private Label label_5;

		private Label label_6;

		private TextBox textBox_0;

		private TextBox textBox_1;

		private TextBox textBox_2;

		private TextBox textBox_3;

		private TextBox textBox_4;

		private TextBox textBox_5;

		private TabPage tabPage_1;

		private DataGridView dataGridView_0;

		private Panel panel_0;

		private Label label_7;

		private Label label_8;

		private Label label_9;

		private Label label_10;

		private Label label_11;

		private Panel panel_1;

		private TextBox YfQoLrPgfVl;

		private TextBox textBox_6;

		private Label label_12;

		private Label label_13;

		private Panel panel_2;

		private ComboBox comboBox_1;

		private Panel panel_3;

		private TextBox textBox_7;

		private Panel panel_4;

		private TextBox textBox_8;

		private Panel panel_5;

		private TextBox textBox_9;

		private DataGridView dataGridView_1;

		private Panel panel_6;

		private Panel panel_7;

		private Label label_14;

		private Panel panel_8;

		private Panel panel_9;

		private Label label_15;

		private Label label_16;

		private Label label_17;

		private Panel panel_10;

		private TextBox textBox_10;

		private TextBox textBox_11;

		private TextBox textBox_12;

		private TextBox textBox_13;

		private TextBox textBox_14;

		private TextBox textBox_15;

		private Panel panel_11;

		private Label label_18;

		private Label label_19;

		private Label label_20;

		private Panel panel_12;

		private TextBox textBox_16;

		private TextBox textBox_17;

		private TextBox textBox_18;

		private TextBox textBox_19;

		private TextBox textBox_20;

		private TextBox textBox_21;

		private Panel panel_13;

		private Label label_21;

		private Label label_22;

		private DataGridView dataGridView_2;

		private DataGridView dataGridView_3;

		private TableLayoutPanel tableLayoutPanel_4;

		private DataGridView dataGridView_4;

		private DataGridView dataGridView_5;

		private Label label_23;

		private ComboBox comboBox_2;

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

		private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn_0;

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

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_25;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_26;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_27;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_28;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_29;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_30;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_31;

		private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn_1;

		private BindingSource bindingSource_14;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_32;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_33;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_34;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_35;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_36;

		private DataGridViewTextBoxColumn cEuordftJiB;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_37;

		private DataGridViewTextBoxColumn usrorTnxaCv;

		private Panel panel_14;

		private Label label_24;

		private Label SeroruImpei;

		private Label label_25;

		private Label label_26;

		private Panel panel_15;

		private TextBox textBox_22;

		private TextBox textBox_23;

		private Label label_27;

		private Label label_28;

		private Panel panel_16;

		private TextBox textBox_24;

		private Panel panel_17;

		private TextBox textBox_25;

		private Panel panel_18;

		private TextBox kKnoracFnyK;

		private Label label_29;

		private Panel panel_19;

		private Panel panel_20;

		private Label label_30;

		private Panel panel_21;

		private Label label_31;

		private Panel panel_22;

		private Label label_32;

		private Panel panel_23;

		private TextBox textBox_26;

		private Panel panel_24;

		private TextBox textBox_27;

		private Label label_33;

		private Panel panel_25;

		private TextBox textBox_28;

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

		private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn_2;

		private ToolStripMenuItem rKroglMajQE;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_51;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_52;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_53;

		private DataGridViewTextBoxColumn yKeogyoCsw7;

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

		private DataGridViewTextBoxColumn WrRogfhGjk9;

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

		private DataGridViewTextBoxColumn eeEoggXrFln;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_98;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_99;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_100;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_101;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_102;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_103;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_104;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_105;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_106;

		private ToolStripButton toolStripButton_8;

		private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn_3;

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

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_137;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_138;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_139;

		private BindingSource bindingSource_15;

		private BindingSource bindingSource_16;

		private ToolStripButton toolStripButton_9;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_140;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_141;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_142;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_143;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_144;

		private BindingSource bindingSource_17;

		private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_0;

		private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_1;

		private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn_4;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_145;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_146;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_147;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_148;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_149;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_150;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_151;

		private ToolStripMenuItem toolStripMenuItem_6;

		public enum TypeDoc
		{
			None = -1,
			LowMeasurement = 1,
			HighMeasurement
		}

		private enum Enum11
		{

		}
	}
}
