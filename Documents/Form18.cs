using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ControlsLbr;
using FormLbr;

internal partial class Form18 : FormBase
{
	internal DataRow method_0()
	{
		return this.dataRow_0;
	}

	internal Form18(DataRow dataRow_1)
	{
		
		
		this.method_1();
		this.dataRow_0 = dataRow_1;
	}

	private void MugRoTrqlR()
	{
		DataTable dataTable = new DataTable("tR_Classifier");
		dataTable.Columns.Add("id", typeof(int));
		dataTable.Columns.Add("name", typeof(string));
		base.SelectSqlData(dataTable, true, "where ParentKey = ';TechConnect;TypeDoc;Rebinding;TypeDocInRebinding;' and isGroup = 0 and deleted = 0 order by name", null, false, 0);
		this.comboBox_0.DisplayMember = "name";
		this.comboBox_0.ValueMember = "id";
		this.comboBox_0.DataSource = dataTable;
		this.comboBox_0.SelectedIndex = -1;
	}

	private void Form18_Load(object sender, EventArgs e)
	{
		this.MugRoTrqlR();
		if (this.dataRow_0["numDoc"] != DBNull.Value)
		{
			this.textBox_0.Text = this.dataRow_0["numDoc"].ToString();
		}
		if (this.dataRow_0["dateDoc"] != DBNull.Value)
		{
			this.nullableDateTimePicker_0.Value = Convert.ToDateTime(this.dataRow_0["datedoc"]);
		}
		if (this.dataRow_0["typeDoc"] != DBNull.Value)
		{
			this.comboBox_0.SelectedValue = this.dataRow_0["typedoc"];
		}
		if (this.dataRow_0["comment"] != DBNull.Value)
		{
			this.richTextBox_0.Text = this.dataRow_0["comment"].ToString();
		}
	}

	private void Form18_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (base.DialogResult == DialogResult.OK)
		{
			if (string.IsNullOrEmpty(this.textBox_0.Text) && this.nullableDateTimePicker_0.Value == null && this.comboBox_0.SelectedIndex < 0)
			{
				MessageBox.Show("Не введены рексвизиты документа");
				e.Cancel = true;
				return;
			}
			if (string.IsNullOrEmpty(this.textBox_0.Text))
			{
				this.dataRow_0["numDoc"] = DBNull.Value;
			}
			else
			{
				this.dataRow_0["numdoc"] = this.textBox_0.Text;
			}
			if (this.nullableDateTimePicker_0.Value == null)
			{
				this.dataRow_0["datedoc"] = DBNull.Value;
			}
			else
			{
				this.dataRow_0["datedoc"] = this.nullableDateTimePicker_0.Value;
			}
			if (this.comboBox_0.SelectedIndex < 0)
			{
				this.dataRow_0["typeDoc"] = DBNull.Value;
			}
			else
			{
				this.dataRow_0["typeDoc"] = this.comboBox_0.SelectedValue;
			}
			if (string.IsNullOrEmpty(this.richTextBox_0.Text))
			{
				this.dataRow_0["Comment"] = DBNull.Value;
				return;
			}
			this.dataRow_0["Comment"] = this.richTextBox_0.Text;
		}
	}

	private void method_1()
	{
		this.label_0 = new Label();
		this.textBox_0 = new TextBox();
		this.label_1 = new Label();
		this.nullableDateTimePicker_0 = new NullableDateTimePicker();
		this.label_2 = new Label();
		this.comboBox_0 = new ComboBox();
		this.label_3 = new Label();
		this.richTextBox_0 = new RichTextBox();
		this.button_0 = new Button();
		this.button_1 = new Button();
		base.SuspendLayout();
		this.label_0.AutoSize = true;
		this.label_0.Location = new Point(12, 9);
		this.label_0.Name = "label1";
		this.label_0.Size = new Size(75, 13);
		this.label_0.TabIndex = 0;
		this.label_0.Text = "№ документа";
		this.textBox_0.Location = new Point(93, 6);
		this.textBox_0.Name = "txtNumDoc";
		this.textBox_0.Size = new Size(86, 20);
		this.textBox_0.TabIndex = 1;
		this.label_1.AutoSize = true;
		this.label_1.Location = new Point(185, 9);
		this.label_1.Name = "label2";
		this.label_1.Size = new Size(90, 13);
		this.label_1.TabIndex = 2;
		this.label_1.Text = "Дата документа";
		this.nullableDateTimePicker_0.Location = new Point(281, 6);
		this.nullableDateTimePicker_0.Name = "dtpDate";
		this.nullableDateTimePicker_0.Size = new Size(143, 20);
		this.nullableDateTimePicker_0.TabIndex = 3;
		this.nullableDateTimePicker_0.Value = new DateTime(2015, 4, 28, 9, 16, 53, 420);
		this.label_2.AutoSize = true;
		this.label_2.Location = new Point(12, 35);
		this.label_2.Name = "label3";
		this.label_2.Size = new Size(83, 13);
		this.label_2.TabIndex = 4;
		this.label_2.Text = "Тип документа";
		this.comboBox_0.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBox_0.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBox_0.FormattingEnabled = true;
		this.comboBox_0.Location = new Point(93, 32);
		this.comboBox_0.Name = "cmbTypeDoc";
		this.comboBox_0.Size = new Size(331, 21);
		this.comboBox_0.TabIndex = 5;
		this.label_3.AutoSize = true;
		this.label_3.Location = new Point(12, 61);
		this.label_3.Name = "label4";
		this.label_3.Size = new Size(77, 13);
		this.label_3.TabIndex = 6;
		this.label_3.Text = "Комментарий";
		this.richTextBox_0.AcceptsTab = true;
		this.richTextBox_0.Location = new Point(15, 77);
		this.richTextBox_0.Name = "txtComment";
		this.richTextBox_0.Size = new Size(409, 96);
		this.richTextBox_0.TabIndex = 7;
		this.richTextBox_0.Text = "";
		this.button_0.DialogResult = DialogResult.OK;
		this.button_0.Location = new Point(15, 180);
		this.button_0.Name = "buttonOK";
		this.button_0.Size = new Size(75, 23);
		this.button_0.TabIndex = 8;
		this.button_0.Text = "ОК";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_1.DialogResult = DialogResult.Cancel;
		this.button_1.Location = new Point(349, 180);
		this.button_1.Name = "buutonCancel";
		this.button_1.Size = new Size(75, 23);
		this.button_1.TabIndex = 9;
		this.button_1.Text = "Отмена";
		this.button_1.UseVisualStyleBackColor = true;
		base.AcceptButton = this.button_0;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = this.button_1;
		base.ClientSize = new Size(431, 215);
		base.Controls.Add(this.button_1);
		base.Controls.Add(this.button_0);
		base.Controls.Add(this.richTextBox_0);
		base.Controls.Add(this.label_3);
		base.Controls.Add(this.comboBox_0);
		base.Controls.Add(this.label_2);
		base.Controls.Add(this.nullableDateTimePicker_0);
		base.Controls.Add(this.label_1);
		base.Controls.Add(this.textBox_0);
		base.Controls.Add(this.label_0);
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "FormDocInAddEdit";
		this.Text = "Регламентирующий документ";
		base.FormClosing += this.Form18_FormClosing;
		base.Load += this.Form18_Load;
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	internal static void lfCelwPvd8WnfYAwNXd(Form form_0, bool bool_0)
	{
		form_0.Dispose(bool_0);
	}

	private DataRow dataRow_0;

	private Label label_0;

	private TextBox textBox_0;

	private Label label_1;

	private NullableDateTimePicker nullableDateTimePicker_0;

	private Label label_2;

	private ComboBox comboBox_0;

	private Label label_3;

	private RichTextBox richTextBox_0;

	private Button button_0;

	private Button button_1;
}
