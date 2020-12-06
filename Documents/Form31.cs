using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Documents.Properties;
using FormLbr;

internal partial class Form31 : FormBase
{
	internal Dictionary<int, string> method_0()
	{
		return this.dictionary_0;
	}

	internal void method_1(Dictionary<int, string> dictionary_1)
	{
		this.dictionary_0 = dictionary_1;
	}

	internal Form31()
	{
		
		this.dictionary_0 = new Dictionary<int, string>();
		
		this.method_9();
	}

	private void Form31_Load(object sender, EventArgs e)
	{
		this.method_2();
		this.listBox_0.Items.Clear();
		foreach (int num in this.dictionary_0.Keys)
		{
			this.listBox_0.Items.Add(new Form31.Struct5(num, this.dictionary_0[num]));
		}
	}

	private void method_2()
	{
		Class469 @class = new Class469();
		base.SelectSqlData(@class, @class.tR_Classifier, true, " where ParentKey = ';SCM;PS;' and isgroup = 0 and deleted = 0 order by name");
		this.treeView_0.BeginUpdate();
		foreach (object obj in @class.tR_Classifier.Rows)
		{
			DataRow dataRow = (DataRow)obj;
			TreeNode treeNode = this.treeView_0.Nodes.Add(dataRow["SocrName"].ToString());
			treeNode.Tag = dataRow["id"];
			base.SelectSqlData(@class, @class.vSchm_ObjList, true, " where typeCodeId = " + dataRow["id"].ToString() + " and deleted = 0 order by name");
			foreach (DataRow dataRow2 in @class.vSchm_ObjList)
			{
				TreeNode treeNode2 = treeNode.Nodes.Add(dataRow2["typeCodeSocr"].ToString() + "-" + dataRow2["Name"].ToString());
				treeNode2.Tag = dataRow2["id"];
				treeNode2.Nodes.Add("");
			}
		}
		this.treeView_0.EndUpdate();
	}

	private void treeView_0_AfterSelect(object sender, TreeViewEventArgs e)
	{
	}

	private void treeView_0_BeforeExpand(object sender, TreeViewCancelEventArgs e)
	{
		if (e.Node.Nodes.Count > 0 && e.Node.Level > 0)
		{
			e.Node.Nodes.Clear();
			Class469 @class;
			switch (e.Node.Level)
			{
			case 1:
			{
				@class = new Class469();
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
				using (IEnumerator<Class469.Class495> enumerator2 = @class.vSchm_ObjList.GetEnumerator())
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
				goto IL_26A;
			default:
				return;
			}
			@class = new Class469();
			base.SelectSqlData(@class, @class.vSchm_TreeCellLine, true, " where ParentLink = " + e.Node.Tag.ToString());
			using (IEnumerator<Class469.Class496> enumerator3 = @class.vSchm_TreeCellLine.GetEnumerator())
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
			IL_26A:
			@class = new Class469();
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
			@class = new Class469();
			base.SelectSqlData(@class, @class.vSchm_TreeCellLine, true, " where ParentLink = " + e.Node.Tag.ToString());
			foreach (DataRow dataRow6 in @class.vSchm_TreeCellLine)
			{
				e.Node.Nodes.Add(dataRow6["FullName"].ToString()).Tag = dataRow6["id"];
			}
		}
	}

	private void method_3(TreeNode treeNode_0)
	{
		Class469 @class = new Class469();
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
		Class469 @class = new Class469();
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
		Class469 @class = new Class469();
		base.SelectSqlData(@class, @class.vSchm_TreeCellLine, true, " where ParentLink = " + treeNode_0.Tag.ToString());
		foreach (DataRow dataRow in @class.vSchm_TreeCellLine)
		{
			treeNode_0.Nodes.Add(dataRow["FullName"].ToString()).Tag = dataRow["id"];
		}
	}

	private void fyHocFuAcAC(object sender, EventArgs e)
	{
		List<int> list = new List<int>();
		foreach (object obj in this.treeView_0.Nodes)
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
		this.listBox_0.Items.Clear();
		foreach (int num in this.dictionary_0.Keys)
		{
			this.listBox_0.Items.Add(new Form31.Struct5(num, this.dictionary_0[num]));
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

	private void button_1_Click(object sender, EventArgs e)
	{
		foreach (object obj in this.listBox_0.SelectedItems)
		{
			this.dictionary_0.Remove(((Form31.Struct5)obj).sDjZoftxTyE);
		}
		this.listBox_0.Items.Clear();
		foreach (int num in this.dictionary_0.Keys)
		{
			this.listBox_0.Items.Add(new Form31.Struct5(num, this.dictionary_0[num]));
		}
	}

	private void button_2_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.OK;
		base.Close();
	}

	private void toolStripButton_0_Click(object sender, EventArgs e)
	{
		List<TreeNode> list_ = new List<TreeNode>();
		list_ = this.method_7(this.treeView_0.Nodes, list_);
		TreeNode treeNode = this.method_8(list_, this.treeView_0.SelectedNode, this.toolStripTextBox_0.Text, (Form31.Enum10)0);
		if (treeNode != null)
		{
			this.treeView_0.SelectedNode = treeNode;
			this.treeView_0.SelectedNode.Expand();
		}
	}

	private void toolStripButton_1_Click(object sender, EventArgs e)
	{
		List<TreeNode> list_ = new List<TreeNode>();
		list_ = this.method_7(this.treeView_0.Nodes, list_);
		TreeNode treeNode = this.method_8(list_, this.treeView_0.SelectedNode, this.toolStripTextBox_0.Text, (Form31.Enum10)1);
		if (treeNode != null)
		{
			this.treeView_0.SelectedNode = treeNode;
			this.treeView_0.SelectedNode.Expand();
		}
	}

	private void toolStripButton_2_Click(object sender, EventArgs e)
	{
		List<TreeNode> list_ = new List<TreeNode>();
		list_ = this.method_7(this.treeView_0.Nodes, list_);
		TreeNode treeNode = this.method_8(list_, this.treeView_0.SelectedNode, this.toolStripTextBox_0.Text, (Form31.Enum10)2);
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
				this.toolStripButton_1_Click(sender, e);
				return;
			}
			if (modifiers != Keys.Shift)
			{
				return;
			}
			this.toolStripButton_2_Click(sender, e);
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

	private TreeNode method_8(List<TreeNode> list_0, TreeNode treeNode_0, string string_0, Form31.Enum10 enum10_0)
	{
		bool flag = enum10_0 == (Form31.Enum10)0;
		if (enum10_0 == (Form31.Enum10)2)
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

	private void method_9()
	{
		this.treeView_0 = new TreeView();
		this.treeView_1 = new TreeView();
		this.listBox_0 = new ListBox();
		this.button_0 = new Button();
		this.button_1 = new Button();
		this.button_2 = new Button();
		this.button_3 = new Button();
		this.toolStrip_0 = new ToolStrip();
		this.toolStripButton_0 = new ToolStripButton();
		this.toolStripTextBox_0 = new ToolStripTextBox();
		this.toolStripButton_1 = new ToolStripButton();
		this.toolStripButton_2 = new ToolStripButton();
		this.label_0 = new Label();
		this.label_1 = new Label();
		this.toolStrip_0.SuspendLayout();
		base.SuspendLayout();
		this.treeView_0.CheckBoxes = true;
		this.treeView_0.HideSelection = false;
		this.treeView_0.Location = new Point(2, 28);
		this.treeView_0.Name = "treeViewSubstation";
		this.treeView_0.Size = new Size(210, 430);
		this.treeView_0.TabIndex = 0;
		this.treeView_0.BeforeExpand += this.treeView_0_BeforeExpand;
		this.treeView_0.AfterSelect += this.treeView_0_AfterSelect;
		this.treeView_1.CheckBoxes = true;
		this.treeView_1.Location = new Point(2, 258);
		this.treeView_1.Name = "treeViewSubs";
		this.treeView_1.Size = new Size(210, 200);
		this.treeView_1.TabIndex = 1;
		this.listBox_0.FormattingEnabled = true;
		this.listBox_0.Location = new Point(277, 25);
		this.listBox_0.Name = "listBoxObjects";
		this.listBox_0.SelectionMode = SelectionMode.MultiExtended;
		this.listBox_0.Size = new Size(232, 433);
		this.listBox_0.Sorted = true;
		this.listBox_0.TabIndex = 2;
		this.button_0.Location = new Point(218, 180);
		this.button_0.Name = "buttonAdd";
		this.button_0.Size = new Size(53, 23);
		this.button_0.TabIndex = 3;
		this.button_0.Text = ">>>";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_0.Click += this.fyHocFuAcAC;
		this.button_1.Location = new Point(218, 279);
		this.button_1.Name = "buttonDel";
		this.button_1.Size = new Size(53, 23);
		this.button_1.TabIndex = 4;
		this.button_1.Text = "<<<";
		this.button_1.UseVisualStyleBackColor = true;
		this.button_1.Click += this.button_1_Click;
		this.button_2.DialogResult = DialogResult.OK;
		this.button_2.Location = new Point(3, 464);
		this.button_2.Name = "buttonOk";
		this.button_2.Size = new Size(75, 23);
		this.button_2.TabIndex = 5;
		this.button_2.Text = "OK";
		this.button_2.UseVisualStyleBackColor = true;
		this.button_2.Click += this.button_2_Click;
		this.button_3.DialogResult = DialogResult.Cancel;
		this.button_3.Location = new Point(434, 464);
		this.button_3.Name = "buttonCancel";
		this.button_3.Size = new Size(75, 23);
		this.button_3.TabIndex = 6;
		this.button_3.Text = "Отмена";
		this.button_3.UseVisualStyleBackColor = true;
		this.toolStrip_0.Dock = DockStyle.None;
		this.toolStrip_0.Items.AddRange(new ToolStripItem[]
		{
			this.toolStripButton_0,
			this.toolStripTextBox_0,
			this.toolStripButton_1,
			this.toolStripButton_2
		});
		this.toolStrip_0.Location = new Point(3, 0);
		this.toolStrip_0.Name = "toolStrip1";
		this.toolStrip_0.Size = new Size(183, 25);
		this.toolStrip_0.TabIndex = 7;
		this.toolStrip_0.Text = "toolStripTreeSubstations";
		this.toolStripButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_0.Image = Resources.Find;
		this.toolStripButton_0.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_0.Name = "tooBtnFind";
		this.toolStripButton_0.Size = new Size(23, 22);
		this.toolStripButton_0.Text = "toolStripButton1";
		this.toolStripButton_0.Click += this.toolStripButton_0_Click;
		this.toolStripTextBox_0.Name = "toolTxtFind";
		this.toolStripTextBox_0.Size = new Size(100, 25);
		this.toolStripTextBox_0.KeyDown += this.toolStripTextBox_0_KeyDown;
		this.toolStripButton_1.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_1.Image = Resources.FindNext;
		this.toolStripButton_1.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_1.Name = "toolBtnFindNext";
		this.toolStripButton_1.Size = new Size(23, 22);
		this.toolStripButton_1.Text = "toolStripButton1";
		this.toolStripButton_1.Click += this.toolStripButton_1_Click;
		this.toolStripButton_2.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_2.Image = Resources.FindPrev;
		this.toolStripButton_2.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_2.Name = "toolBtnFindPrev";
		this.toolStripButton_2.Size = new Size(23, 22);
		this.toolStripButton_2.Text = "toolStripButton2";
		this.toolStripButton_2.Click += this.toolStripButton_2_Click;
		this.label_0.AutoSize = true;
		this.label_0.Location = new Point(12, 242);
		this.label_0.Name = "label1";
		this.label_0.Size = new Size(115, 13);
		this.label_0.TabIndex = 8;
		this.label_0.Text = "Объекты подстанции";
		this.label_1.AutoSize = true;
		this.label_1.Location = new Point(274, 12);
		this.label_1.Name = "label2";
		this.label_1.Size = new Size(124, 13);
		this.label_1.TabIndex = 9;
		this.label_1.Text = "Привязанные объекты";
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = this.button_3;
		base.ClientSize = new Size(512, 495);
		base.Controls.Add(this.treeView_0);
		base.Controls.Add(this.label_1);
		base.Controls.Add(this.label_0);
		base.Controls.Add(this.toolStrip_0);
		base.Controls.Add(this.button_3);
		base.Controls.Add(this.button_2);
		base.Controls.Add(this.button_1);
		base.Controls.Add(this.button_0);
		base.Controls.Add(this.listBox_0);
		base.Controls.Add(this.treeView_1);
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.Name = "FormLinkOrderAndSchm";
		base.StartPosition = FormStartPosition.CenterParent;
		this.Text = "Привязка нарядов к схеме";
		base.Load += this.Form31_Load;
		this.toolStrip_0.ResumeLayout(false);
		this.toolStrip_0.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	private Dictionary<int, string> dictionary_0;

	private TreeView treeView_0;

	private TreeView treeView_1;

	private ListBox listBox_0;

	private Button button_0;

	private Button button_1;

	private Button button_2;

	private Button button_3;

	private ToolStrip toolStrip_0;

	private ToolStripButton toolStripButton_0;

	private ToolStripTextBox toolStripTextBox_0;

	private ToolStripButton toolStripButton_1;

	private ToolStripButton toolStripButton_2;

	private Label label_0;

	private Label label_1;

	private struct Struct5
	{
		public Struct5(int int_0, string string_1)
		{
			
			this.string_0 = string_1;
			this.sDjZoftxTyE = int_0;
		}

		public override string ToString()
		{
			return this.string_0;
		}

		public string string_0;

		public int sDjZoftxTyE;
	}

	private enum Enum10
	{

	}
}
