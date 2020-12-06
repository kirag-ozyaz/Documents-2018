using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DataSql;
using Documents.Properties;
using FormLbr;

internal partial class Form27 : FormBase
{
	internal Dictionary<int, string> method_0()
	{
		return this.dictionary_0;
	}

	internal void method_1(Dictionary<int, string> dictionary_1)
	{
		this.dictionary_0 = dictionary_1;
	}

	internal bool method_2()
	{
		return this.bool_0;
	}

	internal void method_3(bool bool_1)
	{
		this.bool_0 = bool_1;
		this.treeView_0.CheckBoxes = this.bool_0;
	}

	internal int? method_4()
	{
		return this.nullable_0;
	}

	internal void method_5(int? nullable_1)
	{
		this.checkBox_0.Checked = (nullable_1 == null);
		this.checkBox_0.Visible = (nullable_1 != null);
		this.nullable_0 = nullable_1;
	}

	internal Form27()
	{
		
		this.dictionary_0 = new Dictionary<int, string>();
		
		this.method_11();
	}

	private void Form27_Load(object sender, EventArgs e)
	{
		this.method_6();
	}

	private void method_6()
	{
		Class255 @class = new Class255();
		base.SelectSqlData(@class, @class.tR_Classifier, true, " where ParentKey = ';SCM;PS;' and isgroup = 0 and deleted = 0 order by name");
		this.treeView_0.BeginUpdate();
		this.treeView_0.Nodes.Clear();
		foreach (object obj in @class.tR_Classifier.Rows)
		{
			DataRow dataRow = (DataRow)obj;
			TreeNode treeNode = this.treeView_0.Nodes.Add(dataRow["SocrName"].ToString());
			treeNode.Tag = dataRow["id"];
			DataTable dataTable = new DataTable();
			if (this.nullable_0 != null && !this.checkBox_0.Checked)
			{
				dataTable = new SqlDataCommand(this.SqlSettings).SelectSqlData(string.Format("select sub.id, sub.typeCodeSocr, sub.name from tSChm_ObjList line\r\n\t                                                    inner join tSChm_Relation relLine on relLine.Edge = line.id\r\n\t                                                    inner join tSChm_Relation relCell on relCell.id <> relLine.id and (relCell.DestObj in (relLine.DestObj, relLine.SourceObj) or\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\trelCell.SourceObj in (relLine.DestObj, relLine.SourceObj))\r\n\t                                                    inner join tSchm_ObjList cell on cell.id = relCell.Edge and cell.TypeCodeId in (672,679,678,676,674,675) and cell.Deleted = 0\r\n\t                                                    inner join vSchm_ObjList sub on sub.id = cell.idparent and sub.TypeCodeId in (535,536,537,538,1034,1275) and sub.deleted = 0\r\n\t                                                    inner join tP_ObjAddress addr on addr.idObjList = line.id and addr.idStreet = {0}\r\n                                                       where line.typeCodeId in (546,547,983)\r\n\t                                                            and line.deleted = 0 and sub.typeCodeId = {1}\r\n                                                       group by  sub.id, sub.typeCodeSocr, sub.name", this.nullable_0, dataRow["id"]));
			}
			else
			{
				base.SelectSqlData(@class, @class.vSchm_ObjList, true, " where typeCodeId = " + dataRow["id"].ToString() + " and deleted = 0 order by name");
				dataTable = @class.vSchm_ObjList;
			}
			foreach (object obj2 in dataTable.Rows)
			{
				DataRow dataRow2 = (DataRow)obj2;
				TreeNode treeNode2 = treeNode.Nodes.Add(dataRow2["typeCodeSocr"].ToString() + "-" + dataRow2["Name"].ToString());
				treeNode2.Tag = dataRow2["id"];
				treeNode2.Nodes.Add("");
			}
		}
		this.treeView_0.EndUpdate();
		if (!this.checkBox_0.Checked)
		{
			bool flag = false;
			using (IEnumerator enumerator = this.treeView_0.Nodes.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (((TreeNode)enumerator.Current).Nodes.Count > 0)
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				this.checkBox_0.Checked = true;
			}
		}
	}

	private void treeView_0_BeforeExpand(object sender, TreeViewCancelEventArgs e)
	{
		if (e.Node.Nodes.Count > 0 && e.Node.Level > 0)
		{
			e.Node.Nodes.Clear();
			int level = e.Node.Level;
			if (level == 1)
			{
				Class255 @class = new Class255();
				base.SelectSqlData(@class, @class.tSchm_ObjList, true, " where idParentAddl = " + e.Node.Tag.ToString() + " and typecodeid = 556 and deleted = 0");
				foreach (DataRow dataRow in @class.tSchm_ObjList)
				{
					TreeNode treeNode = e.Node.Nodes.Add(dataRow["Name"].ToString());
					treeNode.Tag = dataRow["id"];
					treeNode.Nodes.Add("");
				}
			}
		}
	}

	private void method_7(TreeNode treeNode_0, List<int> list_0)
	{
		if (treeNode_0.Checked && treeNode_0.Tag != null && treeNode_0.Level > 1)
		{
			if (treeNode_0.Tag is int)
			{
				list_0.Add(Convert.ToInt32(treeNode_0.Tag));
			}
			if (treeNode_0.Tag is List<int>)
			{
				list_0.Add(((List<int>)treeNode_0.Tag)[0]);
			}
		}
		foreach (object obj in treeNode_0.Nodes)
		{
			TreeNode treeNode_ = (TreeNode)obj;
			this.method_7(treeNode_, list_0);
		}
	}

	private void vmkoxTftaEX(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.OK;
		this.dictionary_0.Clear();
		if (this.method_2())
		{
			List<int> list = new List<int>();
			foreach (object obj in this.treeView_0.Nodes)
			{
				TreeNode treeNode_ = (TreeNode)obj;
				this.method_7(treeNode_, list);
			}
			using (List<int>.Enumerator enumerator2 = list.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					int key = enumerator2.Current;
					if (!this.dictionary_0.ContainsKey(key))
					{
						this.dictionary_0.Add(key, base.CallSQLScalarFunction("dbo.fn_Schm_GetFullNameObjById", new string[]
						{
							key.ToString()
						}).ToString());
					}
				}
				goto IL_1EA;
			}
		}
		if (this.treeView_0.SelectedNode != null && this.treeView_0.SelectedNode.Tag != null && this.treeView_0.SelectedNode.Level > 1)
		{
			List<int> list2 = new List<int>();
			if (this.treeView_0.SelectedNode.Tag is int)
			{
				list2.Add(Convert.ToInt32(this.treeView_0.SelectedNode.Tag));
			}
			if (this.treeView_0.SelectedNode.Tag is List<int>)
			{
				list2.Add(((List<int>)this.treeView_0.SelectedNode.Tag)[0]);
			}
			foreach (int key2 in list2)
			{
				if (!this.dictionary_0.ContainsKey(key2))
				{
					this.dictionary_0.Add(key2, base.CallSQLScalarFunction("dbo.fn_Schm_GetFullNameObjById", new string[]
					{
						key2.ToString()
					}).ToString());
				}
			}
		}
		IL_1EA:
		base.Close();
	}

	private void toolStripButton_0_Click(object sender, EventArgs e)
	{
		List<TreeNode> list_ = new List<TreeNode>();
		list_ = this.method_8(this.treeView_0.Nodes, list_);
		TreeNode treeNode = this.method_9(list_, this.treeView_0.SelectedNode, this.toolStripTextBox_0.Text, (Form27.Enum7)0);
		if (treeNode != null)
		{
			this.treeView_0.SelectedNode = treeNode;
			this.treeView_0.SelectedNode.Expand();
		}
	}

	private void toolStripButton_1_Click(object sender, EventArgs e)
	{
		List<TreeNode> list_ = new List<TreeNode>();
		list_ = this.method_8(this.treeView_0.Nodes, list_);
		TreeNode treeNode = this.method_9(list_, this.treeView_0.SelectedNode, this.toolStripTextBox_0.Text, (Form27.Enum7)1);
		if (treeNode != null)
		{
			this.treeView_0.SelectedNode = treeNode;
			this.treeView_0.SelectedNode.Expand();
		}
	}

	private void toolStripButton_2_Click(object sender, EventArgs e)
	{
		List<TreeNode> list_ = new List<TreeNode>();
		list_ = this.method_8(this.treeView_0.Nodes, list_);
		TreeNode treeNode = this.method_9(list_, this.treeView_0.SelectedNode, this.toolStripTextBox_0.Text, (Form27.Enum7)2);
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

	private List<TreeNode> method_8(TreeNodeCollection treeNodeCollection_0, List<TreeNode> list_0)
	{
		foreach (object obj in treeNodeCollection_0)
		{
			TreeNode treeNode = (TreeNode)obj;
			list_0.Add(treeNode);
			list_0 = this.method_8(treeNode.Nodes, list_0);
		}
		return list_0;
	}

	private TreeNode method_9(List<TreeNode> list_0, TreeNode treeNode_0, string string_0, Form27.Enum7 enum7_0)
	{
		bool flag = enum7_0 == (Form27.Enum7)0;
		if (enum7_0 == (Form27.Enum7)2)
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

	private void method_10(object sender, EventArgs e)
	{
		this.method_6();
	}

	private void checkBox_0_CheckedChanged(object sender, EventArgs e)
	{
		this.method_6();
	}

	private void NeVoxjvlomq_Click(object sender, EventArgs e)
	{
		base.Close();
	}

	private void method_11()
	{
		this.treeView_0 = new TreeView();
		this.button_0 = new Button();
		this.NeVoxjvlomq = new Button();
		this.toolStrip_0 = new ToolStrip();
		this.toolStripButton_0 = new ToolStripButton();
		this.toolStripTextBox_0 = new ToolStripTextBox();
		this.toolStripButton_1 = new ToolStripButton();
		this.toolStripButton_2 = new ToolStripButton();
		this.label_0 = new Label();
		this.checkBox_0 = new CheckBox();
		this.toolStrip_0.SuspendLayout();
		base.SuspendLayout();
		this.treeView_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.treeView_0.HideSelection = false;
		this.treeView_0.Location = new Point(0, 28);
		this.treeView_0.Name = "treeViewSubstation";
		this.treeView_0.Size = new Size(466, 404);
		this.treeView_0.TabIndex = 0;
		this.treeView_0.BeforeExpand += this.treeView_0_BeforeExpand;
		this.button_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.button_0.DialogResult = DialogResult.OK;
		this.button_0.Location = new Point(3, 464);
		this.button_0.Name = "buttonOk";
		this.button_0.Size = new Size(75, 23);
		this.button_0.TabIndex = 5;
		this.button_0.Text = "OK";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_0.Click += this.vmkoxTftaEX;
		this.NeVoxjvlomq.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.NeVoxjvlomq.DialogResult = DialogResult.Cancel;
		this.NeVoxjvlomq.Location = new Point(379, 464);
		this.NeVoxjvlomq.Name = "buttonCancel";
		this.NeVoxjvlomq.Size = new Size(75, 23);
		this.NeVoxjvlomq.TabIndex = 6;
		this.NeVoxjvlomq.Text = "Отмена";
		this.NeVoxjvlomq.UseVisualStyleBackColor = true;
		this.NeVoxjvlomq.Click += this.NeVoxjvlomq_Click;
		this.toolStrip_0.Items.AddRange(new ToolStripItem[]
		{
			this.toolStripButton_0,
			this.toolStripTextBox_0,
			this.toolStripButton_1,
			this.toolStripButton_2
		});
		this.toolStrip_0.Location = new Point(0, 0);
		this.toolStrip_0.Name = "toolStrip1";
		this.toolStrip_0.Size = new Size(466, 25);
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
		this.checkBox_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.checkBox_0.AutoSize = true;
		this.checkBox_0.Location = new Point(296, 441);
		this.checkBox_0.Name = "chkFilterAllSubstations";
		this.checkBox_0.Size = new Size(158, 17);
		this.checkBox_0.TabIndex = 11;
		this.checkBox_0.Text = "Показать все подстанции";
		this.checkBox_0.UseVisualStyleBackColor = true;
		this.checkBox_0.Visible = false;
		this.checkBox_0.CheckedChanged += this.checkBox_0_CheckedChanged;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = this.NeVoxjvlomq;
		base.ClientSize = new Size(466, 502);
		base.Controls.Add(this.checkBox_0);
		base.Controls.Add(this.treeView_0);
		base.Controls.Add(this.label_0);
		base.Controls.Add(this.toolStrip_0);
		base.Controls.Add(this.NeVoxjvlomq);
		base.Controls.Add(this.button_0);
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.Name = "FormSelectTrans";
		base.StartPosition = FormStartPosition.CenterParent;
		this.Text = "Привязка объекта к схеме";
		base.Load += this.Form27_Load;
		this.toolStrip_0.ResumeLayout(false);
		this.toolStrip_0.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	internal static void CnpBcHOjKMXDXtCVgL1Q(Form form_0, bool bool_1)
	{
		form_0.Dispose(bool_1);
	}

	private bool bool_0;

	private int? nullable_0;

	private Dictionary<int, string> dictionary_0;

	private TreeView treeView_0;

	private Button button_0;

	private Button NeVoxjvlomq;

	private ToolStrip toolStrip_0;

	private ToolStripButton toolStripButton_0;

	private ToolStripTextBox toolStripTextBox_0;

	private ToolStripButton toolStripButton_1;

	private ToolStripButton toolStripButton_2;

	private Label label_0;

	private CheckBox checkBox_0;

	private struct Struct1
	{
		public Struct1(int int_1, string string_1)
		{
			
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

	private enum Enum7
	{

	}
}
