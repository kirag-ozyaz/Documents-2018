using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using FormLbr;
using RequestsClient.Properties;

internal partial class FormLinkRequestAndSchm : FormBase
{
	internal Dictionary<int, string> method_0()
	{
		return this.dictionary_0;
	}

	internal void method_1(Dictionary<int, string> dictionary_1)
	{
		this.dictionary_0 = dictionary_1;
	}

	internal short Num
	{
		get
		{
			return this.short_0;
		}
		set
		{
			this.short_0 = value;
		}
	}

	internal DateTime DateBeg
	{
		get
		{
			return this.dateTimePickerDateBeg.Value;
		}
		set
		{
			this.dateTimePickerDateBeg.Value = value;
		}
	}

	internal DateTime DateEnd
	{
		get
		{
			return this.dateTimePickerDateEnd.Value;
		}
		set
		{
			this.dateTimePickerDateEnd.Value = value;
		}
	}

	internal string Duration
	{
		get
		{
			return this.textBoxDuration.Text;
		}
		set
		{
			this.textBoxDuration.Text = value;
		}
	}

	internal FormLinkRequestAndSchm()
	{
		Class38.TqlX7ZmzmDDi2();
		this.dictionary_0 = new Dictionary<int, string>();
		
		this.InitializeComponent();
	}

	private void FormLinkRequestAndSchm_Load(object sender, EventArgs e)
	{
		this.method_2();
		this.listBoxObjects.Items.Clear();
		foreach (int num in this.dictionary_0.Keys)
		{
			this.listBoxObjects.Items.Add(new FormLinkRequestAndSchm.Struct0(num, this.dictionary_0[num]));
		}
	}

	private void method_2()
	{
		Class3 @class = new Class3();
		base.SelectSqlData(@class, @class.tR_Classifier, true, " where ParentKey = ';SCM;PS;' and isgroup = 0 and deleted = 0 order by name");
		this.treeViewSubstation.BeginUpdate();
		foreach (object obj in @class.tR_Classifier.Rows)
		{
			DataRow dataRow = (DataRow)obj;
			TreeNode treeNode = this.treeViewSubstation.Nodes.Add(dataRow["SocrName"].ToString());
			treeNode.Tag = dataRow["id"];
			base.SelectSqlData(@class, @class.vSchm_ObjList, true, " where typeCodeId = " + dataRow["id"].ToString() + " and deleted = 0 order by name");
			foreach (DataRow dataRow2 in @class.vSchm_ObjList)
			{
				TreeNode treeNode2 = treeNode.Nodes.Add(dataRow2["typeCodeSocr"].ToString() + "-" + dataRow2["Name"].ToString());
				treeNode2.Tag = dataRow2["id"];
				treeNode2.Nodes.Add("");
			}
		}
		this.treeViewSubstation.EndUpdate();
	}

	private void treeViewSubstation_AfterSelect(object sender, TreeViewEventArgs e)
	{
	}

	private void treeViewSubstation_BeforeExpand(object sender, TreeViewCancelEventArgs e)
	{
		if (e.Node.Nodes.Count > 0 && e.Node.Level > 0)
		{
			e.Node.Nodes.Clear();
			Class3 @class;
			switch (e.Node.Level)
			{
			case 1:
			{
				@class = new Class3();
				base.SelectSqlData(@class, @class.tR_Classifier, true, " where ParentKey like ';SCM;BUS;%' and deleted = 0 and isgroup = 0 ");
				string text = "";
				foreach (object obj in @class.tR_Classifier.Rows)
				{
					DataRow dataRow = (DataRow)obj;
					text = text + dataRow["id"].ToString() + ",";
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
				using (IEnumerator<Class3.Class19> enumerator2 = @class.vSchm_ObjList.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						DataRow dataRow2 = enumerator2.Current;
						TreeNode treeNode = e.Node.Nodes.Add(dataRow2["TypeCodeSocr"].ToString() + " - " + dataRow2["Name"].ToString());
						treeNode.Tag = dataRow2["id"];
						treeNode.Nodes.Add("");
					}
					return;
				}
				break;
			}
			case 2:
				break;
			case 3:
				goto IL_262;
			default:
				return;
			}
			@class = new Class3();
			base.SelectSqlData(@class, @class.vSchm_TreeCellLine, true, " where ParentLink = " + e.Node.Tag.ToString());
			using (IEnumerator<Class3.Class20> enumerator3 = @class.vSchm_TreeCellLine.GetEnumerator())
			{
				while (enumerator3.MoveNext())
				{
					DataRow dataRow3 = enumerator3.Current;
					TreeNode treeNode2 = e.Node.Nodes.Add(dataRow3["FullName"].ToString());
					treeNode2.Tag = dataRow3["id"];
					treeNode2.Nodes.Add("");
				}
				return;
			}
			IL_262:
			@class = new Class3();
			base.SelectSqlData(@class, @class.tSchm_Relation, true, " where Edge = " + e.Node.Tag.ToString());
			if (@class.tSchm_Relation.Rows.Count > 0)
			{
				string text = "";
				foreach (DataRow dataRow4 in @class.tSchm_Relation)
				{
					text = text + dataRow4["id"].ToString() + ",";
				}
				text = text.Remove(text.Length - 1);
				base.SelectSqlData(@class, @class.vSchm_ObjList, true, " where idparent in (" + text + ") and deleted = 0");
				foreach (DataRow dataRow5 in @class.vSchm_ObjList)
				{
					e.Node.Nodes.Add(dataRow5["TypeCodeSocr"].ToString() + " - " + dataRow5["Name"].ToString()).Tag = dataRow5["id"];
				}
			}
			@class = new Class3();
			base.SelectSqlData(@class, @class.vSchm_TreeCellLine, true, " where ParentLink = " + e.Node.Tag.ToString());
			foreach (DataRow dataRow6 in @class.vSchm_TreeCellLine)
			{
				e.Node.Nodes.Add(dataRow6["FullName"].ToString()).Tag = dataRow6["id"];
			}
		}
	}

	private void method_3(TreeNode treeNode_0)
	{
		Class3 @class = new Class3();
		base.SelectSqlData(@class, @class.vSchm_TreeCellLine, true, " where ParentLink = " + treeNode_0.Tag.ToString());
		foreach (DataRow dataRow in @class.vSchm_TreeCellLine)
		{
			TreeNode treeNode = treeNode_0.Nodes.Add(dataRow["FullName"].ToString());
			treeNode.Tag = dataRow["id"];
			this.method_4(treeNode);
			this.method_5(treeNode);
		}
	}

	private void method_4(TreeNode treeNode_0)
	{
		Class3 @class = new Class3();
		base.SelectSqlData(@class, @class.tSchm_Relation, true, " where Edge = " + treeNode_0.Tag.ToString());
		if (@class.tSchm_Relation.Rows.Count > 0)
		{
			string text = "";
			foreach (DataRow dataRow in @class.tSchm_Relation)
			{
				text = text + dataRow["id"].ToString() + ",";
			}
			text = text.Remove(text.Length - 1);
			base.SelectSqlData(@class, @class.vSchm_ObjList, true, " where idparent in (" + text + ") and deleted = 0");
			foreach (DataRow dataRow2 in @class.vSchm_ObjList)
			{
				treeNode_0.Nodes.Add(dataRow2["TypeCodeSocr"].ToString() + " - " + dataRow2["Name"].ToString()).Tag = dataRow2["id"];
			}
		}
	}

	private void method_5(TreeNode treeNode_0)
	{
		Class3 @class = new Class3();
		base.SelectSqlData(@class, @class.vSchm_TreeCellLine, true, " where ParentLink = " + treeNode_0.Tag.ToString());
		foreach (DataRow dataRow in @class.vSchm_TreeCellLine)
		{
			treeNode_0.Nodes.Add(dataRow["FullName"].ToString()).Tag = dataRow["id"];
		}
	}

	private void buttonAdd_Click(object sender, EventArgs e)
	{
		List<int> list = new List<int>();
		foreach (object obj in this.treeViewSubstation.Nodes)
		{
			TreeNode treeNode_ = (TreeNode)obj;
			this.method_6(treeNode_, list);
		}
		foreach (int key in list)
		{
			if (!this.dictionary_0.ContainsKey(key))
			{
				this.dictionary_0.Add(key, base.CallSQLScalarFunction("dbo.fn_Schm_GetFullNameObjById", new string[]
				{
					key.ToString()
				}).ToString());
			}
		}
		this.listBoxObjects.Items.Clear();
		foreach (int num in this.dictionary_0.Keys)
		{
			this.listBoxObjects.Items.Add(new FormLinkRequestAndSchm.Struct0(num, this.dictionary_0[num]));
		}
	}

	private void method_6(TreeNode treeNode_0, List<int> list_0)
	{
		if (treeNode_0.Checked && treeNode_0.Tag != null && treeNode_0.Level > 0)
		{
			list_0.Add(Convert.ToInt32(treeNode_0.Tag));
		}
		foreach (object obj in treeNode_0.Nodes)
		{
			TreeNode treeNode_ = (TreeNode)obj;
			this.method_6(treeNode_, list_0);
		}
	}

	private void buttonDel_Click(object sender, EventArgs e)
	{
		foreach (object obj in this.listBoxObjects.SelectedItems)
		{
			this.dictionary_0.Remove(((FormLinkRequestAndSchm.Struct0)obj).int_0);
		}
		this.listBoxObjects.Items.Clear();
		foreach (int num in this.dictionary_0.Keys)
		{
			this.listBoxObjects.Items.Add(new FormLinkRequestAndSchm.Struct0(num, this.dictionary_0[num]));
		}
	}

	private void buttonOk_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.OK;
		base.Close();
	}

	private void tooBtnFind_Click(object sender, EventArgs e)
	{
		List<TreeNode> list_ = new List<TreeNode>();
		list_ = this.method_7(this.treeViewSubstation.Nodes, list_);
		TreeNode treeNode = this.method_8(list_, this.treeViewSubstation.SelectedNode, this.toolTxtFind.Text, (FormLinkRequestAndSchm.Enum1)0);
		if (treeNode != null)
		{
			this.treeViewSubstation.SelectedNode = treeNode;
			this.treeViewSubstation.SelectedNode.Expand();
		}
	}

	private void toolBtnFindNext_Click(object sender, EventArgs e)
	{
		List<TreeNode> list_ = new List<TreeNode>();
		list_ = this.method_7(this.treeViewSubstation.Nodes, list_);
		TreeNode treeNode = this.method_8(list_, this.treeViewSubstation.SelectedNode, this.toolTxtFind.Text, (FormLinkRequestAndSchm.Enum1)1);
		if (treeNode != null)
		{
			this.treeViewSubstation.SelectedNode = treeNode;
			this.treeViewSubstation.SelectedNode.Expand();
		}
	}

	private void toolBtnFindPrev_Click(object sender, EventArgs e)
	{
		List<TreeNode> list_ = new List<TreeNode>();
		list_ = this.method_7(this.treeViewSubstation.Nodes, list_);
		TreeNode treeNode = this.method_8(list_, this.treeViewSubstation.SelectedNode, this.toolTxtFind.Text, (FormLinkRequestAndSchm.Enum1)2);
		if (treeNode != null)
		{
			this.treeViewSubstation.SelectedNode = treeNode;
			this.treeViewSubstation.SelectedNode.Expand();
		}
	}

	private void toolTxtFind_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			Keys modifiers = e.Modifiers;
			if (modifiers == Keys.None)
			{
				this.toolBtnFindNext_Click(sender, e);
				return;
			}
			if (modifiers != Keys.Shift)
			{
				return;
			}
			this.toolBtnFindPrev_Click(sender, e);
		}
	}

	private List<TreeNode> method_7(TreeNodeCollection treeNodeCollection_0, List<TreeNode> list_0)
	{
		foreach (object obj in treeNodeCollection_0)
		{
			TreeNode treeNode = (TreeNode)obj;
			list_0.Add(treeNode);
			list_0 = this.method_7(treeNode.Nodes, list_0);
		}
		return list_0;
	}

	private TreeNode method_8(List<TreeNode> list_0, TreeNode treeNode_0, string string_0, FormLinkRequestAndSchm.Enum1 enum1_0)
	{
		bool flag = enum1_0 == (FormLinkRequestAndSchm.Enum1)0;
		if (enum1_0 == (FormLinkRequestAndSchm.Enum1)2)
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

	private Dictionary<int, string> dictionary_0;

	private short short_0;

	private struct Struct0
	{
		public Struct0(int int_1, string string_1)
		{
			Class38.TqlX7ZmzmDDi2();
			this.string_0 = string_1;
			this.int_0 = int_1;
		}

		public override string ToString()
		{
			return this.string_0;
		}

		public string string_0;

		public int int_0;
	}

	private enum Enum1
	{

	}
}
