using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Documents.Properties;
using FormLbr;
using Microsoft.Reporting.WinForms;

internal partial class Form41 : FormBase
{
	internal Form41()
	{
		
		
		this.method_14();
	}

	private void Form41_Load(object sender, EventArgs e)
	{
		this.method_0(true);
		this.backgroundWorker_0.RunWorkerAsync();
		this.method_1(this.enum12_0);
		this.reportViewer_0.RefreshReport();
	}

	private void method_0(bool bool_0)
	{
		this.toolStripProgressBar_0.Style = (bool_0 ? ProgressBarStyle.Continuous : ProgressBarStyle.Blocks);
		this.toolStripStatusLabel_0.Text = (bool_0 ? "Выполняется загрузка данных..." : "");
		this.button_0.Enabled = !bool_0;
	}

	private void method_1(Form41.Enum12 enum12_1)
	{
		string text = (enum12_1 == (Form41.Enum12)0) ? " ASC" : " DESC";
		this.treeView_0.BeginUpdate();
		this.treeView_0.Nodes.Clear();
		base.SelectSqlData(this.class255_0, this.class255_0.tR_Classifier, true, "WHERE ParentKey = ';SCM;PS;' AND Value in (2,4) AND id NOT IN (SELECT p.idObjList FROM tP_Passport AS p INNER JOIN tP_ObjectChar AS oc ON p.id = oc.idPassport AND oc.Deleted = 0 AND oc.idObjChar = 174 AND Value = 293 WHERE p.isActive = 1 AND p.Deleted = 0) ORDER BY Name" + text);
		string str = string.Join(",", (from i in this.class255_0.tR_Classifier
		select i.Id.ToString()).ToArray<string>());
		base.SelectSqlDataTableOther(this.class255_0, this.class255_0.tSchm_ObjList1, "tSchm_ObjList", true, "WHERE TypeCodeId IN (" + str + ") AND Deleted = ((0)) ORDER BY Name" + text);
		TreeNode treeNode = new TreeNode("Все");
		using (IEnumerator<Class255.Class369> enumerator = this.class255_0.tR_Classifier.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				Class255.Class369 item = enumerator.Current;
				TreeNode treeNode2 = new TreeNode(item.Name);
				foreach (Class255.Class415 @class in from row in this.class255_0.tSchm_ObjList1
				where row.TypeCodeId == item.Id
				select row)
				{
					TreeNode treeNode3 = new TreeNode(@class.Name);
					treeNode3.Tag = @class.Id;
					treeNode2.Nodes.Add(treeNode3);
				}
				treeNode.Nodes.Add(treeNode2);
			}
		}
		this.treeView_0.Nodes.Add(treeNode);
		this.treeView_0.EndUpdate();
	}

	private void toolStripButton_2_Click(object sender, EventArgs e)
	{
		List<TreeNode> list_ = new List<TreeNode>();
		list_ = this.method_2(this.treeView_0.Nodes, list_);
		TreeNode treeNode = this.method_5(list_, this.treeView_0.SelectedNode, this.toolStripTextBox_0.Text);
		if (treeNode != null)
		{
			this.treeView_0.Focus();
			this.treeView_0.SelectedNode = treeNode;
			this.treeView_0.SelectedNode.Expand();
		}
	}

	private void toolStripButton_1_Click(object sender, EventArgs e)
	{
		List<TreeNode> list_ = new List<TreeNode>();
		list_ = this.method_2(this.treeView_0.Nodes, list_);
		TreeNode treeNode = this.method_6(list_, this.toolStripTextBox_0.Text);
		if (treeNode != null)
		{
			this.treeView_0.Focus();
			this.treeView_0.SelectedNode = treeNode;
			this.treeView_0.SelectedNode.Expand();
		}
	}

	private List<TreeNode> method_2(TreeNodeCollection treeNodeCollection_0, List<TreeNode> list_0)
	{
		foreach (object obj in treeNodeCollection_0)
		{
			TreeNode treeNode = (TreeNode)obj;
			list_0.Add(treeNode);
			list_0 = this.method_2(treeNode.Nodes, list_0);
		}
		return list_0;
	}

	private List<TreeNode> method_3(TreeNodeCollection treeNodeCollection_0, List<TreeNode> list_0)
	{
		foreach (object obj in treeNodeCollection_0)
		{
			TreeNode treeNode = (TreeNode)obj;
			if (treeNode.IsExpanded)
			{
				list_0.Add(treeNode);
			}
			list_0 = this.method_3(treeNode.Nodes, list_0);
		}
		return list_0;
	}

	private List<TreeNode> method_4(TreeNodeCollection treeNodeCollection_0, List<TreeNode> list_0)
	{
		foreach (object obj in treeNodeCollection_0)
		{
			TreeNode treeNode = (TreeNode)obj;
			if (treeNode.Checked)
			{
				list_0.Add(treeNode);
			}
			list_0 = this.method_4(treeNode.Nodes, list_0);
		}
		return list_0;
	}

	private TreeNode method_5(List<TreeNode> list_0, TreeNode treeNode_0, string string_0)
	{
		bool flag = false;
		foreach (TreeNode treeNode in list_0)
		{
			if (flag && treeNode.Name.ToUpper().Contains(string_0.ToUpper()))
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

	private TreeNode method_6(List<TreeNode> list_0, string string_0)
	{
		foreach (TreeNode treeNode in list_0)
		{
			if (treeNode.Name.ToUpper().Contains(string_0.ToUpper()))
			{
				return treeNode;
			}
		}
		return null;
	}

	private TreeNode method_7(List<TreeNode> list_0, int int_0)
	{
		foreach (TreeNode treeNode in list_0)
		{
			if ((int)treeNode.Tag == int_0)
			{
				return treeNode;
			}
		}
		return null;
	}

	private bool method_8(TreeNode treeNode_0)
	{
		return treeNode_0.Nodes[0].Text == "None";
	}

	private void method_9(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r')
		{
			List<TreeNode> list_ = new List<TreeNode>();
			list_ = this.method_2(this.treeView_0.Nodes, list_);
			TreeNode treeNode = this.method_6(list_, this.toolStripTextBox_0.Text);
			if (treeNode != null)
			{
				this.treeView_0.SelectedNode = treeNode;
				this.treeView_0.SelectedNode.Expand();
			}
		}
	}

	private void toolStripButton_3_Click(object sender, EventArgs e)
	{
		this.method_10();
	}

	private void method_10()
	{
		this.toolStripButton_3.Image = ((this.enum12_0 == (Form41.Enum12)0) ? Resources.sortZA : Resources.sortAZ);
		this.enum12_0 = ((this.enum12_0 == (Form41.Enum12)0) ? ((Form41.Enum12)1) : ((Form41.Enum12)0));
		this.method_11();
	}

	private void method_11()
	{
		TreeNode topNode = this.treeView_0.TopNode;
		List<TreeNode> list = new List<TreeNode>();
		this.method_3(this.treeView_0.Nodes, list);
		List<TreeNode> list2 = new List<TreeNode>();
		this.method_4(this.treeView_0.Nodes, list2);
		this.method_1(this.enum12_0);
		List<TreeNode> newList = new List<TreeNode>();
		this.method_2(this.treeView_0.Nodes, newList);
		list.ForEach(delegate(TreeNode oldChecked)
		{
			(from n in newList
			where n.Text == oldChecked.Text || (n.Tag == oldChecked.Tag && n.Text == oldChecked.Text)
			select n).ToList<TreeNode>().ForEach(delegate(TreeNode node)
			{
				node.Expand();
			});
		});
		list2.ForEach(delegate(TreeNode oldChecked)
		{
			(from n in newList
			where n.Text == oldChecked.Text || (n.Tag == oldChecked.Tag && n.Text == oldChecked.Text)
			select n).ToList<TreeNode>().ForEach(delegate(TreeNode node)
			{
				node.Checked = true;
			});
		});
		(from n in newList
		where n.Text == topNode.Text || (n.Tag == topNode.Tag && n.Text == topNode.Text)
		select n).ToList<TreeNode>().ForEach(new Action<TreeNode>(this.method_15));
	}

	private List<int> method_12(TreeNodeCollection treeNodeCollection_0, List<int> list_0)
	{
		foreach (object obj in treeNodeCollection_0)
		{
			TreeNode treeNode = (TreeNode)obj;
			if (treeNode.Checked && treeNode.Tag is int)
			{
				list_0.Add((int)treeNode.Tag);
			}
			list_0 = this.method_12(treeNode.Nodes, list_0);
		}
		return list_0;
	}

	private void treeView_0_AfterCheck(object sender, TreeViewEventArgs e)
	{
		foreach (object obj in e.Node.Nodes)
		{
			((TreeNode)obj).Checked = e.Node.Checked;
		}
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		this.reportViewer_0.Clear();
		this.reportViewer_0.ShowProgress = true;
		List<int> arrayId = new List<int>();
		arrayId = this.method_12(this.treeView_0.Nodes, arrayId);
		IEnumerable<Class255.Class416> source;
		if (!this.checkBox_0.Checked)
		{
			source = from row in this.class255_0.vJ_PowerISR_SSTransf
			where row["Isr"] != DBNull.Value
			select row;
		}
		else
		{
			source = from row in this.class255_0.vJ_PowerISR_SSTransf
			select row;
		}
		IEnumerable<<>f__AnonymousType9<int, int>> rowCounts = from row in source
		where arrayId.Contains(row.idSub)
		group row by row.idSub into grp
		select new
		{
			idSubstation = grp.Key,
			countTransf = grp.Count<Class255.Class416>()
		};
		var enumerable = from row in source
		where arrayId.Contains(row.idSub)
		orderby row.NameSub, row["NameTransf"]
		select new
		{
			nameSubstation = row.NameSub,
			nameTransf = ((row["NameTransf"] != DBNull.Value) ? row.NameTransf : ""),
			amountFreeCapasity = this.method_13(row["Power"], (from r in rowCounts
			where r.idSubstation == row.idSub
			select r.countTransf).First<int>(), row["Isr"])
		};
		this.class255_0.dtAmountFreeCapasity.Rows.Clear();
		foreach (var <>f__AnonymousType in enumerable)
		{
			this.class255_0.dtAmountFreeCapasity.method_1(<>f__AnonymousType.nameSubstation, <>f__AnonymousType.nameTransf, <>f__AnonymousType.amountFreeCapasity);
		}
		BindingSource bindingSource = new BindingSource();
		bindingSource.DataSource = this.class255_0.dtAmountFreeCapasity;
		this.reportViewer_0.LocalReport.DataSources.Add(new ReportDataSource("dsAmount", bindingSource));
		this.reportViewer_0.RefreshReport();
	}

	private string method_13(object object_0, object object_1, object object_2)
	{
		if (object_1 == DBNull.Value)
		{
			return "";
		}
		if (object_0 == DBNull.Value)
		{
			return "";
		}
		if (object_2 == DBNull.Value)
		{
			return "";
		}
		double num = (double)((int)object_0) * (((int)object_1 == 1) ? 0.95 : 0.7);
		double num2 = Math.Sqrt(3.0) * 0.4 * (double)((int)object_2);
		double num3 = Math.Round((num - num2) * 0.89, 0);
		if (num3 >= 0.0)
		{
			return num3.ToString();
		}
		return "0";
	}

	private void Form41_Shown(object sender, EventArgs e)
	{
	}

	private void backgroundWorker_0_DoWork(object sender, DoWorkEventArgs e)
	{
		base.SelectSqlData(this.class255_0, this.class255_0.vJ_PowerISR_SSTransf, true, "");
	}

	private void backgroundWorker_0_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		this.method_0(false);
	}

	private void toolStripButton_4_Click(object sender, EventArgs e)
	{
		this.method_0(true);
		this.backgroundWorker_0.RunWorkerAsync();
		this.method_11();
	}

	private void method_14()
	{
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form41));
		this.splitContainer_0 = new SplitContainer();
		this.tableLayoutPanel_0 = new TableLayoutPanel();
		this.toolStrip_0 = new ToolStrip();
		this.toolStripButton_0 = new ToolStripButton();
		this.toolStripTextBox_0 = new ToolStripTextBox();
		this.toolStripButton_1 = new ToolStripButton();
		this.toolStripButton_2 = new ToolStripButton();
		this.toolStripSeparator_0 = new ToolStripSeparator();
		this.toolStripButton_3 = new ToolStripButton();
		this.toolStripButton_4 = new ToolStripButton();
		this.treeView_0 = new TreeView();
		this.button_0 = new Button();
		this.checkBox_0 = new CheckBox();
		this.reportViewer_0 = new ReportViewer();
		this.class255_0 = new Class255();
		this.statusStrip_0 = new StatusStrip();
		this.toolStripProgressBar_0 = new ToolStripProgressBar();
		this.toolStripStatusLabel_0 = new ToolStripStatusLabel();
		this.tableLayoutPanel_1 = new TableLayoutPanel();
		this.backgroundWorker_0 = new BackgroundWorker();
		this.splitContainer_0.Panel1.SuspendLayout();
		this.splitContainer_0.Panel2.SuspendLayout();
		this.splitContainer_0.SuspendLayout();
		this.tableLayoutPanel_0.SuspendLayout();
		this.toolStrip_0.SuspendLayout();
		((ISupportInitialize)this.class255_0).BeginInit();
		this.statusStrip_0.SuspendLayout();
		this.tableLayoutPanel_1.SuspendLayout();
		base.SuspendLayout();
		this.splitContainer_0.Dock = DockStyle.Fill;
		this.splitContainer_0.Location = new Point(3, 3);
		this.splitContainer_0.Name = "splitContainer1";
		this.splitContainer_0.Panel1.Controls.Add(this.tableLayoutPanel_0);
		this.splitContainer_0.Panel2.Controls.Add(this.reportViewer_0);
		this.splitContainer_0.Size = new Size(778, 534);
		this.splitContainer_0.SplitterDistance = 257;
		this.splitContainer_0.TabIndex = 0;
		this.tableLayoutPanel_0.ColumnCount = 1;
		this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		this.tableLayoutPanel_0.Controls.Add(this.toolStrip_0, 0, 0);
		this.tableLayoutPanel_0.Controls.Add(this.treeView_0, 0, 1);
		this.tableLayoutPanel_0.Controls.Add(this.button_0, 0, 3);
		this.tableLayoutPanel_0.Controls.Add(this.checkBox_0, 0, 2);
		this.tableLayoutPanel_0.Dock = DockStyle.Fill;
		this.tableLayoutPanel_0.Location = new Point(0, 0);
		this.tableLayoutPanel_0.Margin = new Padding(10, 3, 3, 3);
		this.tableLayoutPanel_0.Name = "tableLayoutPanel1";
		this.tableLayoutPanel_0.RowCount = 4;
		this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Absolute, 26f));
		this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Absolute, 22f));
		this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Absolute, 32f));
		this.tableLayoutPanel_0.Size = new Size(257, 534);
		this.tableLayoutPanel_0.TabIndex = 0;
		this.toolStrip_0.Items.AddRange(new ToolStripItem[]
		{
			this.toolStripButton_0,
			this.toolStripTextBox_0,
			this.toolStripButton_1,
			this.toolStripButton_2,
			this.toolStripSeparator_0,
			this.toolStripButton_3,
			this.toolStripButton_4
		});
		this.toolStrip_0.Location = new Point(0, 0);
		this.toolStrip_0.Name = "tsTree";
		this.toolStrip_0.Size = new Size(257, 25);
		this.toolStrip_0.TabIndex = 3;
		this.toolStrip_0.Text = "Панель инструментов дерва данных";
		this.toolStripButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_0.Image = (Image)componentResourceManager.GetObject("tsbShowDeletedObject.Image");
		this.toolStripButton_0.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_0.Name = "tsbShowDeletedObject";
		this.toolStripButton_0.Size = new Size(23, 22);
		this.toolStripButton_0.Text = "Отобразить удаленные объекты";
		this.toolStripButton_0.Visible = false;
		this.toolStripTextBox_0.Name = "tstbFindObj";
		this.toolStripTextBox_0.Size = new Size(100, 25);
		this.toolStripButton_1.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_1.Image = (Image)componentResourceManager.GetObject("tsbFindObj.Image");
		this.toolStripButton_1.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_1.Name = "tsbFindObj";
		this.toolStripButton_1.Size = new Size(23, 22);
		this.toolStripButton_1.Text = "Найти";
		this.toolStripButton_1.Click += this.toolStripButton_1_Click;
		this.toolStripButton_2.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_2.Image = (Image)componentResourceManager.GetObject("tsbFindNextObj.Image");
		this.toolStripButton_2.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_2.Name = "tsbFindNextObj";
		this.toolStripButton_2.Size = new Size(23, 22);
		this.toolStripButton_2.Text = "Найти далее";
		this.toolStripButton_2.Click += this.toolStripButton_2_Click;
		this.toolStripSeparator_0.Name = "toolStripSeparator10";
		this.toolStripSeparator_0.Size = new Size(6, 25);
		this.toolStripButton_3.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_3.Image = Resources.sortAZ;
		this.toolStripButton_3.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_3.Name = "tsbSortTree";
		this.toolStripButton_3.Size = new Size(23, 22);
		this.toolStripButton_3.Text = "Сортировка";
		this.toolStripButton_3.TextImageRelation = TextImageRelation.Overlay;
		this.toolStripButton_3.Click += this.toolStripButton_3_Click;
		this.toolStripButton_4.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_4.Image = Resources.refresh_16;
		this.toolStripButton_4.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_4.Name = "tsbRefreshAll";
		this.toolStripButton_4.Size = new Size(23, 22);
		this.toolStripButton_4.Text = "Обновить";
		this.toolStripButton_4.Click += this.toolStripButton_4_Click;
		this.treeView_0.CheckBoxes = true;
		this.treeView_0.Dock = DockStyle.Fill;
		this.treeView_0.Location = new Point(3, 29);
		this.treeView_0.Name = "trvSchmObj";
		this.treeView_0.Size = new Size(251, 448);
		this.treeView_0.TabIndex = 4;
		this.treeView_0.AfterCheck += this.treeView_0_AfterCheck;
		this.button_0.Dock = DockStyle.Fill;
		this.button_0.Location = new Point(3, 505);
		this.button_0.Name = "button1";
		this.button_0.Size = new Size(251, 26);
		this.button_0.TabIndex = 5;
		this.button_0.Text = "Сформировать отчет";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_0.Click += this.button_0_Click;
		this.checkBox_0.AutoSize = true;
		this.checkBox_0.Checked = true;
		this.checkBox_0.CheckState = CheckState.Checked;
		this.checkBox_0.Location = new Point(10, 483);
		this.checkBox_0.Margin = new Padding(10, 3, 3, 3);
		this.checkBox_0.Name = "chbIsNullIsr";
		this.checkBox_0.Size = new Size(232, 16);
		this.checkBox_0.TabIndex = 6;
		this.checkBox_0.Text = "Включая пустые значения св. мощности";
		this.checkBox_0.UseVisualStyleBackColor = true;
		this.reportViewer_0.Dock = DockStyle.Fill;
		this.reportViewer_0.LocalReport.ReportEmbeddedResource = "Documents.Forms.Measurement.ReportAmountFreeCapacity.rdlc";
		this.reportViewer_0.Location = new Point(0, 0);
		this.reportViewer_0.Name = "rvGeneral";
		this.reportViewer_0.Size = new Size(517, 534);
		this.reportViewer_0.TabIndex = 0;
		this.class255_0.DataSetName = "DataSetGES";
		this.class255_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		this.statusStrip_0.Items.AddRange(new ToolStripItem[]
		{
			this.toolStripProgressBar_0,
			this.toolStripStatusLabel_0
		});
		this.statusStrip_0.Location = new Point(0, 540);
		this.statusStrip_0.Name = "statusStrip1";
		this.statusStrip_0.Size = new Size(784, 22);
		this.statusStrip_0.TabIndex = 1;
		this.statusStrip_0.Text = "statusStrip1";
		this.toolStripProgressBar_0.Name = "tspbStatus";
		this.toolStripProgressBar_0.Size = new Size(200, 16);
		this.toolStripStatusLabel_0.Name = "tsslStatus";
		this.toolStripStatusLabel_0.Size = new Size(118, 17);
		this.toolStripStatusLabel_0.Text = "toolStripStatusLabel1";
		this.tableLayoutPanel_1.ColumnCount = 1;
		this.tableLayoutPanel_1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		this.tableLayoutPanel_1.Controls.Add(this.splitContainer_0, 0, 0);
		this.tableLayoutPanel_1.Dock = DockStyle.Fill;
		this.tableLayoutPanel_1.Location = new Point(0, 0);
		this.tableLayoutPanel_1.Name = "tableLayoutPanel2";
		this.tableLayoutPanel_1.RowCount = 1;
		this.tableLayoutPanel_1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		this.tableLayoutPanel_1.Size = new Size(784, 540);
		this.tableLayoutPanel_1.TabIndex = 2;
		this.backgroundWorker_0.DoWork += this.backgroundWorker_0_DoWork;
		this.backgroundWorker_0.RunWorkerCompleted += this.backgroundWorker_0_RunWorkerCompleted;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(784, 562);
		base.Controls.Add(this.tableLayoutPanel_1);
		base.Controls.Add(this.statusStrip_0);
		base.Name = "FormAmountFreeCapacity";
		this.Text = "Объем свободной мощности";
		base.Load += this.Form41_Load;
		base.Shown += this.Form41_Shown;
		this.splitContainer_0.Panel1.ResumeLayout(false);
		this.splitContainer_0.Panel2.ResumeLayout(false);
		this.splitContainer_0.ResumeLayout(false);
		this.tableLayoutPanel_0.ResumeLayout(false);
		this.tableLayoutPanel_0.PerformLayout();
		this.toolStrip_0.ResumeLayout(false);
		this.toolStrip_0.PerformLayout();
		((ISupportInitialize)this.class255_0).EndInit();
		this.statusStrip_0.ResumeLayout(false);
		this.statusStrip_0.PerformLayout();
		this.tableLayoutPanel_1.ResumeLayout(false);
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	[CompilerGenerated]
	private void method_15(TreeNode treeNode_0)
	{
		this.treeView_0.TopNode = treeNode_0;
	}

	internal static void cXKA2y0ZO0AGs4ZNdB3W(Form form_0, bool bool_0)
	{
		form_0.Dispose(bool_0);
	}

	private Form41.Enum12 enum12_0;

	private SplitContainer splitContainer_0;

	private ReportViewer reportViewer_0;

	private Class255 class255_0;

	private TableLayoutPanel tableLayoutPanel_0;

	private ToolStrip toolStrip_0;

	private ToolStripButton toolStripButton_0;

	private ToolStripTextBox toolStripTextBox_0;

	private ToolStripButton toolStripButton_1;

	private ToolStripButton toolStripButton_2;

	private ToolStripSeparator toolStripSeparator_0;

	private ToolStripButton toolStripButton_3;

	private TreeView treeView_0;

	private Button button_0;

	private StatusStrip statusStrip_0;

	private ToolStripProgressBar toolStripProgressBar_0;

	private ToolStripStatusLabel toolStripStatusLabel_0;

	private TableLayoutPanel tableLayoutPanel_1;

	private BackgroundWorker backgroundWorker_0;

	private ToolStripButton toolStripButton_4;

	private CheckBox checkBox_0;

	internal enum Enum12
	{

	}
}
