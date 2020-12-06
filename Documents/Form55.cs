using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Documents.Properties;
using FormLbr;

internal partial class Form55 : FormBase
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
			return this.dateTimePicker_1.Value;
		}
		set
		{
			this.dateTimePicker_1.Value = value;
		}
	}

	internal DateTime DateEnd
	{
		get
		{
			return this.dateTimePicker_0.Value;
		}
		set
		{
			this.dateTimePicker_0.Value = value;
		}
	}

	internal string Duration
	{
		get
		{
			return this.textBox_0.Text;
		}
		set
		{
			this.textBox_0.Text = value;
		}
	}

	internal Form55()
	{
		
		this.dictionary_0 = new Dictionary<int, string>();
		
		this.method_9();
	}

	private void Form55_Load(object sender, EventArgs e)
	{
		this.method_2();
		this.listBox_0.Items.Clear();
		foreach (int num in this.dictionary_0.Keys)
		{
			this.listBox_0.Items.Add(new Form55.Struct8(num, this.dictionary_0[num]));
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
				goto IL_260;
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
			IL_260:
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

	private void button_0_Click(object sender, EventArgs e)
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
			this.listBox_0.Items.Add(new Form55.Struct8(num, this.dictionary_0[num]));
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
			this.dictionary_0.Remove(((Form55.Struct8)obj).int_0);
		}
		this.listBox_0.Items.Clear();
		foreach (int num in this.dictionary_0.Keys)
		{
			this.listBox_0.Items.Add(new Form55.Struct8(num, this.dictionary_0[num]));
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
		TreeNode treeNode = this.method_8(list_, this.treeView_0.SelectedNode, this.toolStripTextBox_0.Text, (Form55.Enum16)0);
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
		TreeNode treeNode = this.method_8(list_, this.treeView_0.SelectedNode, this.toolStripTextBox_0.Text, (Form55.Enum16)1);
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
		TreeNode treeNode = this.method_8(list_, this.treeView_0.SelectedNode, this.toolStripTextBox_0.Text, (Form55.Enum16)2);
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

	private TreeNode method_8(List<TreeNode> list_0, TreeNode treeNode_0, string string_0, Form55.Enum16 enum16_0)
	{
		bool flag = enum16_0 == (Form55.Enum16)0;
		if (enum16_0 == (Form55.Enum16)2)
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
		this.groupBox_0 = new GroupBox();
		this.label_4 = new Label();
		this.dateTimePicker_1 = new DateTimePicker();
		this.dateTimePicker_0 = new DateTimePicker();
		this.label_3 = new Label();
		this.label_2 = new Label();
		this.textBox_0 = new TextBox();
		this.toolStrip_0.SuspendLayout();
		this.groupBox_0.SuspendLayout();
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
		this.listBox_0.Size = new Size(232, 277);
		this.listBox_0.Sorted = true;
		this.listBox_0.TabIndex = 2;
		this.button_0.Location = new Point(218, 28);
		this.button_0.Name = "buttonAdd";
		this.button_0.Size = new Size(53, 23);
		this.button_0.TabIndex = 3;
		this.button_0.Text = ">>>";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_0.Click += this.button_0_Click;
		this.button_1.Location = new Point(218, 57);
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
		this.groupBox_0.Controls.Add(this.textBox_0);
		this.groupBox_0.Controls.Add(this.label_2);
		this.groupBox_0.Controls.Add(this.dateTimePicker_0);
		this.groupBox_0.Controls.Add(this.label_3);
		this.groupBox_0.Controls.Add(this.dateTimePicker_1);
		this.groupBox_0.Controls.Add(this.label_4);
		this.groupBox_0.Location = new Point(277, 308);
		this.groupBox_0.Name = "groupBoxDuration";
		this.groupBox_0.Size = new Size(232, 150);
		this.groupBox_0.TabIndex = 10;
		this.groupBox_0.TabStop = false;
		this.groupBox_0.Text = "Период";
		this.label_4.AutoSize = true;
		this.label_4.Location = new Point(6, 16);
		this.label_4.Name = "label3";
		this.label_4.Size = new Size(71, 13);
		this.label_4.TabIndex = 0;
		this.label_4.Text = "Дата начала";
		this.dateTimePicker_1.CustomFormat = "dd.MM.yyyy HH:mm";
		this.dateTimePicker_1.Format = DateTimePickerFormat.Custom;
		this.dateTimePicker_1.Location = new Point(9, 32);
		this.dateTimePicker_1.Name = "dateTimePickerDateBeg";
		this.dateTimePicker_1.Size = new Size(217, 20);
		this.dateTimePicker_1.TabIndex = 1;
		this.dateTimePicker_0.CustomFormat = "dd.MM.yyyy HH:mm";
		this.dateTimePicker_0.Format = DateTimePickerFormat.Custom;
		this.dateTimePicker_0.Location = new Point(9, 71);
		this.dateTimePicker_0.Name = "dateTimePickerDateEnd";
		this.dateTimePicker_0.Size = new Size(217, 20);
		this.dateTimePicker_0.TabIndex = 3;
		this.label_3.AutoSize = true;
		this.label_3.Location = new Point(6, 55);
		this.label_3.Name = "label4";
		this.label_3.Size = new Size(71, 13);
		this.label_3.TabIndex = 2;
		this.label_3.Text = "Дата начала";
		this.label_2.AutoSize = true;
		this.label_2.Location = new Point(6, 94);
		this.label_2.Name = "label5";
		this.label_2.Size = new Size(80, 13);
		this.label_2.TabIndex = 4;
		this.label_2.Text = "Длительность";
		this.textBox_0.Location = new Point(9, 110);
		this.textBox_0.Name = "textBoxDuration";
		this.textBox_0.Size = new Size(217, 20);
		this.textBox_0.TabIndex = 5;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = this.button_3;
		base.ClientSize = new Size(521, 495);
		base.Controls.Add(this.groupBox_0);
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
		base.Name = "FormLinkRequestAndSchm";
		base.StartPosition = FormStartPosition.CenterParent;
		this.Text = "Привязка заявок к схеме";
		base.Load += this.Form55_Load;
		this.toolStrip_0.ResumeLayout(false);
		this.toolStrip_0.PerformLayout();
		this.groupBox_0.ResumeLayout(false);
		this.groupBox_0.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	private Dictionary<int, string> dictionary_0;

	private short short_0;

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

	private GroupBox groupBox_0;

	private TextBox textBox_0;

	private Label label_2;

	private DateTimePicker dateTimePicker_0;

	private Label label_3;

	private DateTimePicker dateTimePicker_1;

	private Label label_4;

	private struct Struct8
	{
		public Struct8(int int_1, string string_1)
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

	private enum Enum16
	{

	}
}
