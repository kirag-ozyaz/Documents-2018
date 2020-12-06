using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ControlsLbr;
using DataSql;
using FormLbr;

internal partial class Form85 : FormBase
{
	internal string TagName
	{
		get
		{
			return this.textBox_0.Text;
		}
	}

	internal string method_0()
	{
		if (this.comboBox_0.SelectedItem != null)
		{
			return ((DataRowView)this.comboBox_0.SelectedItem).Row["Name"].ToString();
		}
		return null;
	}

	internal object method_1()
	{
		return this.comboBox_0.SelectedValue;
	}

	internal string method_2()
	{
		if (this.comboBox_1.SelectedItem != null)
		{
			return ((DataRowView)this.comboBox_1.SelectedItem).Row["FIO"].ToString();
		}
		return null;
	}

	internal object method_3()
	{
		return this.comboBox_1.SelectedValue;
	}

	internal string Contact
	{
		get
		{
			return this.textBox_1.Text;
		}
	}

	internal Form85(Form85.Enum21 enum21_1 = (Form85.Enum21)0, Form85.Enum22 enum22_1 = (Form85.Enum22)0, TreeDataGridViewNode treeDataGridViewNode_1 = null)
	{
		
		
		this.method_8();
		this.enum21_0 = enum21_1;
		this.Text = ((enum21_1 == (Form85.Enum21)0) ? "Добавление" : "Редактирование");
		this.enum22_0 = enum22_1;
		this.treeDataGridViewNode_0 = treeDataGridViewNode_1;
		switch (enum22_1)
		{
		case (Form85.Enum22)0:
		{
			this.Text += " тэга";
			Control control = this.label_1;
			this.comboBox_0.Visible = false;
			control.Visible = false;
			this.panel_0.Visible = false;
			base.Height -= 114;
			return;
		}
		case (Form85.Enum22)1:
			this.Text += " подразделения";
			this.panel_0.Visible = false;
			base.Height -= 79;
			this.textBox_0.ReadOnly = true;
			this.textBox_0.BackColor = SystemColors.Window;
			return;
		case (Form85.Enum22)2:
			this.textBox_0.ReadOnly = true;
			this.textBox_0.BackColor = SystemColors.Window;
			this.comboBox_0.Enabled = false;
			return;
		default:
			return;
		}
	}

	private void Form85_Load(object sender, EventArgs e)
	{
		this.textBox_0.Text = this.method_4(this.treeDataGridViewNode_0);
		DataTable dataTable = this.method_7();
		base.SelectSqlData(dataTable, true, " where ParentKey = ';ReportDaily;DivisionApply;' and isgroup = 0 and deleted = 0 order by name", null, false, 0);
		dataTable.Rows.Add(new object[]
		{
			"-1",
			"Производственная лаборатория"
		});
		List<int> list = new List<int>();
		TreeDataGridViewNode treeDataGridViewNode = null;
		if (this.treeDataGridViewNode_0 != null)
		{
			switch (this.treeDataGridViewNode_0.Level)
			{
			case 1:
				treeDataGridViewNode = this.treeDataGridViewNode_0;
				break;
			case 2:
				treeDataGridViewNode = this.treeDataGridViewNode_0.Parent;
				break;
			case 3:
				treeDataGridViewNode = this.treeDataGridViewNode_0.Parent.Parent;
				break;
			}
		}
		if (treeDataGridViewNode != null)
		{
			foreach (TreeDataGridViewNode treeDataGridViewNode2 in treeDataGridViewNode.Nodes)
			{
				if (treeDataGridViewNode2.Cells[1].Value != null && (this.enum21_0 != (Form85.Enum21)1 || this.enum22_0 != (Form85.Enum22)1 || this.treeDataGridViewNode_0.Cells[1].Value != treeDataGridViewNode2.Cells[1].Value) && this.enum22_0 != (Form85.Enum22)2)
				{
					list.Add(Convert.ToInt32(treeDataGridViewNode2.Cells[1].Value));
				}
			}
		}
		foreach (int num in list)
		{
			DataRow dataRow = dataTable.Rows.Find(num);
			if (dataRow != null)
			{
				dataTable.Rows.Remove(dataRow);
			}
		}
		this.comboBox_0.DisplayMember = "name";
		this.comboBox_0.ValueMember = "id";
		this.comboBox_0.DataSource = dataTable;
		int? num2 = this.method_5(this.treeDataGridViewNode_0);
		if (num2 != null)
		{
			this.comboBox_0.SelectedValue = num2;
		}
		else
		{
			this.comboBox_0.SelectedIndex = -1;
		}
		DataTable dataSource = new SqlDataCommand(this.SqlSettings).SelectSqlData("select id, f + isnull(' ' + i, '') + isnull(' ' + o, '') as fio from tr_worker where dateEnd is null order by f,i,o");
		this.comboBox_1.DisplayMember = "FIO";
		this.comboBox_1.ValueMember = "ID";
		this.comboBox_1.DataSource = dataSource;
		int? num3 = this.method_6(this.treeDataGridViewNode_0);
		if (num3 != null)
		{
			this.comboBox_1.SelectedValue = num3;
		}
		else
		{
			this.comboBox_1.SelectedIndex = -1;
		}
		if (this.treeDataGridViewNode_0 != null && this.treeDataGridViewNode_0.Level == 3 && this.treeDataGridViewNode_0.Cells[4].Value != null)
		{
			this.textBox_1.Text = this.treeDataGridViewNode_0.Cells[4].Value.ToString();
		}
	}

	private string method_4(TreeDataGridViewNode treeDataGridViewNode_1)
	{
		if (treeDataGridViewNode_1 == null)
		{
			return null;
		}
		switch (treeDataGridViewNode_1.Level)
		{
		case 1:
			return treeDataGridViewNode_1.Cells[0].Value.ToString();
		case 2:
			return treeDataGridViewNode_1.Parent.Cells[0].Value.ToString();
		case 3:
			return treeDataGridViewNode_1.Parent.Parent.Cells[0].Value.ToString();
		default:
			return null;
		}
	}

	private int? method_5(TreeDataGridViewNode treeDataGridViewNode_1)
	{
		if (treeDataGridViewNode_1 == null)
		{
			return null;
		}
		int level = treeDataGridViewNode_1.Level;
		if (level != 2)
		{
			if (level != 3)
			{
				return null;
			}
			if (treeDataGridViewNode_1.Parent.Cells[1].Value != null)
			{
				return new int?(Convert.ToInt32(treeDataGridViewNode_1.Parent.Cells[1].Value));
			}
			return null;
		}
		else
		{
			if (treeDataGridViewNode_1.Cells[1].Value != null)
			{
				return new int?(Convert.ToInt32(treeDataGridViewNode_1.Cells[1].Value));
			}
			return null;
		}
	}

	private int? method_6(TreeDataGridViewNode treeDataGridViewNode_1)
	{
		if (treeDataGridViewNode_1 == null)
		{
			return null;
		}
		int level = treeDataGridViewNode_1.Level;
		if (level != 3)
		{
			return null;
		}
		if (treeDataGridViewNode_1.Cells[3].Value != null)
		{
			return new int?(Convert.ToInt32(treeDataGridViewNode_1.Cells[3].Value));
		}
		return null;
	}

	private void Form85_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (base.DialogResult == DialogResult.OK)
		{
			if (string.IsNullOrEmpty(this.textBox_0.Text))
			{
				MessageBox.Show("Не введено имя тэга", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				e.Cancel = true;
				return;
			}
			if (this.enum22_0 == (Form85.Enum22)1 && this.comboBox_0.SelectedIndex < 0)
			{
				MessageBox.Show("Не выбрано подразделение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				e.Cancel = true;
				return;
			}
			if (this.enum22_0 == (Form85.Enum22)2)
			{
				if (this.comboBox_1.SelectedIndex < 0)
				{
					MessageBox.Show("Не выбран сотрудник", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					e.Cancel = true;
					return;
				}
				if (string.IsNullOrEmpty(this.textBox_1.Text))
				{
					MessageBox.Show("Не введен контакт", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					e.Cancel = true;
					return;
				}
			}
		}
	}

	private DataTable method_7()
	{
		DataTable dataTable = new DataTable("tR_Classifier");
		DataColumn dataColumn = dataTable.Columns.Add("id", typeof(int));
		dataTable.Columns.Add("name", typeof(string));
		dataTable.PrimaryKey = new DataColumn[]
		{
			dataColumn
		};
		return dataTable;
	}

	private void method_8()
	{
		this.label_0 = new Label();
		this.textBox_0 = new TextBox();
		this.label_1 = new Label();
		this.comboBox_0 = new ComboBox();
		this.label_2 = new Label();
		this.comboBox_1 = new ComboBox();
		this.label_3 = new Label();
		this.textBox_1 = new TextBox();
		this.button_0 = new Button();
		this.button_1 = new Button();
		this.panel_0 = new Panel();
		this.panel_0.SuspendLayout();
		base.SuspendLayout();
		this.label_0.AutoSize = true;
		this.label_0.Location = new Point(12, 9);
		this.label_0.Name = "labelTag";
		this.label_0.Size = new Size(54, 13);
		this.label_0.TabIndex = 0;
		this.label_0.Text = "Имя тэга";
		this.textBox_0.Location = new Point(12, 25);
		this.textBox_0.Name = "txtTag";
		this.textBox_0.Size = new Size(396, 20);
		this.textBox_0.TabIndex = 1;
		this.label_1.AutoSize = true;
		this.label_1.Location = new Point(12, 48);
		this.label_1.Name = "labelDivision";
		this.label_1.Size = new Size(87, 13);
		this.label_1.TabIndex = 2;
		this.label_1.Text = "Подразделение";
		this.comboBox_0.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBox_0.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBox_0.FormattingEnabled = true;
		this.comboBox_0.Location = new Point(12, 64);
		this.comboBox_0.Name = "cmbDivision";
		this.comboBox_0.Size = new Size(396, 21);
		this.comboBox_0.TabIndex = 3;
		this.label_2.AutoSize = true;
		this.label_2.Location = new Point(13, 0);
		this.label_2.Name = "labelFIO";
		this.label_2.Size = new Size(34, 13);
		this.label_2.TabIndex = 4;
		this.label_2.Text = "ФИО";
		this.comboBox_1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBox_1.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBox_1.FormattingEnabled = true;
		this.comboBox_1.Location = new Point(12, 16);
		this.comboBox_1.Name = "cmbFIO";
		this.comboBox_1.Size = new Size(396, 21);
		this.comboBox_1.TabIndex = 5;
		this.label_3.AutoSize = true;
		this.label_3.Location = new Point(13, 40);
		this.label_3.Name = "labelContact";
		this.label_3.Size = new Size(48, 13);
		this.label_3.TabIndex = 6;
		this.label_3.Text = "Контакт";
		this.textBox_1.Location = new Point(13, 56);
		this.textBox_1.Name = "txtContact";
		this.textBox_1.Size = new Size(396, 20);
		this.textBox_1.TabIndex = 7;
		this.button_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.button_0.DialogResult = DialogResult.OK;
		this.button_0.Location = new Point(12, 170);
		this.button_0.Name = "buttonOK";
		this.button_0.Size = new Size(75, 23);
		this.button_0.TabIndex = 8;
		this.button_0.Text = "ОК";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.button_1.DialogResult = DialogResult.Cancel;
		this.button_1.Location = new Point(333, 170);
		this.button_1.Name = "buttonCancel";
		this.button_1.Size = new Size(75, 23);
		this.button_1.TabIndex = 9;
		this.button_1.Text = "Отмена";
		this.button_1.UseVisualStyleBackColor = true;
		this.panel_0.AutoSize = true;
		this.panel_0.Controls.Add(this.label_2);
		this.panel_0.Controls.Add(this.comboBox_1);
		this.panel_0.Controls.Add(this.label_3);
		this.panel_0.Controls.Add(this.textBox_1);
		this.panel_0.Location = new Point(0, 88);
		this.panel_0.Name = "panel1";
		this.panel_0.Size = new Size(412, 79);
		this.panel_0.TabIndex = 10;
		base.AcceptButton = this.button_0;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = this.button_1;
		base.ClientSize = new Size(413, 200);
		base.Controls.Add(this.panel_0);
		base.Controls.Add(this.button_1);
		base.Controls.Add(this.button_0);
		base.Controls.Add(this.comboBox_0);
		base.Controls.Add(this.label_1);
		base.Controls.Add(this.textBox_0);
		base.Controls.Add(this.label_0);
		base.Name = "FormTagContactAddEdit";
		this.Text = "FormTagContactAddEdit";
		base.FormClosing += this.Form85_FormClosing;
		base.Load += this.Form85_Load;
		this.panel_0.ResumeLayout(false);
		this.panel_0.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	private Form85.Enum21 enum21_0;

	private Form85.Enum22 enum22_0;

	private TreeDataGridViewNode treeDataGridViewNode_0;

	private Label label_0;

	private TextBox textBox_0;

	private Label label_1;

	private ComboBox comboBox_0;

	private Label label_2;

	private ComboBox comboBox_1;

	private Label label_3;

	private TextBox textBox_1;

	private Button button_0;

	private Button button_1;

	private Panel panel_0;

	internal enum Enum21
	{

	}

	internal enum Enum22
	{

	}
}
