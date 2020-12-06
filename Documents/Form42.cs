using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DataSql;
using FormLbr;
using Passport.Classes;

internal partial class Form42 : FormBase
{
	[CompilerGenerated]
	internal Enum13 method_0()
	{
		return this.NtToSuqedq2;
	}

	[CompilerGenerated]
	internal void method_1(Enum13 enum13_0)
	{
		this.NtToSuqedq2 = enum13_0;
	}

	internal Form42()
	{
		
		
		this.InitializeComponent();
	}

	internal Form42(SQLSettings sqlsettings_0, Enum13 enum13_0)
	{
		
		
		this.InitializeComponent();
		this.SqlSettings = sqlsettings_0;
		this.method_1(enum13_0);
	}

	private void Form42_Load(object sender, EventArgs e)
	{
		this.Text = ((this.method_0() == (Enum13)4) ? "Анализ коэффициента загрузки" : ((this.method_0() == (Enum13)5) ? "Анализ коэффициента неравномерности фаз" : ""));
		this.label_3.Text = ((this.method_0() == (Enum13)4) ? "Коэффициент загрузки" : ((this.method_0() == (Enum13)5) ? "Коэффициент неравномерности" : ""));
		base.SelectSqlData(this.class255_0, this.class255_0.tR_Classifier, true, "WHERE ParentKey = ';NetworkAreas;' AND isGroup = 0 AND Deleted = 0");
		Class255.Class369 @class = this.class255_0.tR_Classifier.method_5();
		@class.Id = -1;
		@class.Name = "Все";
		@class.IsGroup = false;
		@class.Deleted = false;
		this.class255_0.tR_Classifier.method_0(@class);
		from r in this.class255_0.tR_Classifier
		orderby r.Name
		select r;
		this.comboBox_0.DataSource = this.class255_0.tR_Classifier;
		this.comboBox_0.DisplayMember = "Name";
		this.comboBox_0.ValueMember = "Id";
		DataTable dataTable = new DataTable();
		dataTable.Columns.Add("Year", typeof(int));
		for (int i = DateTime.Now.Year - 30; i < DateTime.Now.Year + 1; i++)
		{
			dataTable.Rows.Add(new object[]
			{
				i
			});
		}
		from r in dataTable.AsEnumerable()
		orderby r.Field("Year")
		select r;
		this.comboBox_1.DataSource = dataTable;
		this.comboBox_1.DisplayMember = "Year";
		this.comboBox_1.ValueMember = "Year";
		this.comboBox_1.SelectedValue = DateTime.Now.Year;
		this.comboBox_2.SelectedIndex = 0;
		this.comboBox_3.SelectedIndex = 0;
	}

	private void textBox_0_KeyPress(object sender, KeyPressEventArgs e)
	{
		InputCheck.OnlyDigit(sender, e);
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		base.Close();
	}

	private void Form42_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (base.DialogResult == DialogResult.OK)
		{
			new Form44(this.SqlSettings, this.method_0(), (int)this.comboBox_1.SelectedValue, (int)this.comboBox_0.SelectedValue, (this.textBox_0.Text.Length > 0) ? int.Parse(this.textBox_0.Text) : -1, this.comboBox_2.SelectedItem.ToString() == ">", this.numericUpDown_0.Value, this.comboBox_3.SelectedItem.ToString() == ">", this.checkBox_0.Checked, this.checkBox_1.Checked)
			{
				MdiParent = base.MdiParent
			}.Show();
		}
	}

	private void InitializeComponent()
	{
		this.label_0 = new Label();
		this.label_1 = new Label();
		this.comboBox_0 = new ComboBox();
		this.label_2 = new Label();
		this.comboBox_1 = new ComboBox();
		this.tableLayoutPanel_0 = new TableLayoutPanel();
		this.button_0 = new Button();
		this.button_1 = new Button();
		this.class255_0 = new Class255();
		this.textBox_0 = new TextBox();
		this.comboBox_2 = new ComboBox();
		this.comboBox_3 = new ComboBox();
		this.label_3 = new Label();
		this.checkBox_0 = new CheckBox();
		this.checkBox_1 = new CheckBox();
		this.numericUpDown_0 = new NumericUpDown();
		this.tableLayoutPanel_0.SuspendLayout();
		((ISupportInitialize)this.class255_0).BeginInit();
		((ISupportInitialize)this.numericUpDown_0).BeginInit();
		base.SuspendLayout();
		this.label_0.AutoSize = true;
		this.label_0.Location = new Point(12, 67);
		this.label_0.Name = "label3";
		this.label_0.Size = new Size(149, 13);
		this.label_0.TabIndex = 13;
		this.label_0.Text = "Мощность трансформатора";
		this.label_1.AutoSize = true;
		this.label_1.Location = new Point(12, 41);
		this.label_1.Name = "label2";
		this.label_1.Size = new Size(82, 13);
		this.label_1.TabIndex = 11;
		this.label_1.Text = "Сетевой район";
		this.comboBox_0.FormattingEnabled = true;
		this.comboBox_0.Location = new Point(187, 38);
		this.comboBox_0.Name = "cbNetworkAreas";
		this.comboBox_0.Size = new Size(143, 21);
		this.comboBox_0.TabIndex = 10;
		this.label_2.AutoSize = true;
		this.label_2.Location = new Point(12, 14);
		this.label_2.Name = "label1";
		this.label_2.Size = new Size(25, 13);
		this.label_2.TabIndex = 9;
		this.label_2.Text = "Год";
		this.comboBox_1.FormattingEnabled = true;
		this.comboBox_1.Location = new Point(187, 11);
		this.comboBox_1.Name = "cbYear";
		this.comboBox_1.Size = new Size(143, 21);
		this.comboBox_1.TabIndex = 8;
		this.tableLayoutPanel_0.ColumnCount = 2;
		this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 97f));
		this.tableLayoutPanel_0.Controls.Add(this.button_0, 0, 0);
		this.tableLayoutPanel_0.Controls.Add(this.button_1, 1, 0);
		this.tableLayoutPanel_0.Dock = DockStyle.Bottom;
		this.tableLayoutPanel_0.Location = new Point(0, 151);
		this.tableLayoutPanel_0.Name = "tableLayoutPanel1";
		this.tableLayoutPanel_0.RowCount = 1;
		this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		this.tableLayoutPanel_0.Size = new Size(340, 35);
		this.tableLayoutPanel_0.TabIndex = 7;
		this.button_0.DialogResult = DialogResult.OK;
		this.button_0.Dock = DockStyle.Right;
		this.button_0.Location = new Point(141, 6);
		this.button_0.Margin = new Padding(3, 6, 10, 6);
		this.button_0.Name = "btnAccept";
		this.button_0.Size = new Size(92, 23);
		this.button_0.TabIndex = 0;
		this.button_0.Text = "Применить";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_0.Click += this.button_1_Click;
		this.button_1.DialogResult = DialogResult.Cancel;
		this.button_1.Dock = DockStyle.Left;
		this.button_1.Location = new Point(253, 6);
		this.button_1.Margin = new Padding(10, 6, 3, 6);
		this.button_1.Name = "btnCancel";
		this.button_1.Size = new Size(70, 23);
		this.button_1.TabIndex = 1;
		this.button_1.Text = "Отмена";
		this.button_1.UseVisualStyleBackColor = true;
		this.button_1.Click += this.button_1_Click;
		this.class255_0.DataSetName = "DataSetGES";
		this.class255_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		this.textBox_0.Location = new Point(240, 64);
		this.textBox_0.Name = "tbPowerTransf";
		this.textBox_0.Size = new Size(90, 20);
		this.textBox_0.TabIndex = 14;
		this.textBox_0.KeyPress += this.textBox_0_KeyPress;
		this.comboBox_2.FormattingEnabled = true;
		this.comboBox_2.Items.AddRange(new object[]
		{
			">",
			"<"
		});
		this.comboBox_2.Location = new Point(187, 63);
		this.comboBox_2.Name = "cbIsPowerLarge";
		this.comboBox_2.Size = new Size(47, 21);
		this.comboBox_2.TabIndex = 15;
		this.comboBox_3.FormattingEnabled = true;
		this.comboBox_3.Items.AddRange(new object[]
		{
			">",
			"<"
		});
		this.comboBox_3.Location = new Point(187, 90);
		this.comboBox_3.Name = "cbIsCoeffLarge";
		this.comboBox_3.Size = new Size(47, 21);
		this.comboBox_3.TabIndex = 18;
		this.label_3.AutoSize = true;
		this.label_3.Location = new Point(12, 93);
		this.label_3.Name = "label4";
		this.label_3.Size = new Size(126, 13);
		this.label_3.TabIndex = 16;
		this.label_3.Text = "Коэффициент загрузки";
		this.checkBox_0.AutoSize = true;
		this.checkBox_0.Location = new Point(194, 121);
		this.checkBox_0.Name = "chbIsDay";
		this.checkBox_0.Size = new Size(53, 17);
		this.checkBox_0.TabIndex = 19;
		this.checkBox_0.Text = "День";
		this.checkBox_0.UseVisualStyleBackColor = true;
		this.checkBox_1.AutoSize = true;
		this.checkBox_1.Location = new Point(263, 121);
		this.checkBox_1.Name = "chbIsNight";
		this.checkBox_1.Size = new Size(51, 17);
		this.checkBox_1.TabIndex = 20;
		this.checkBox_1.Text = "Ночь";
		this.checkBox_1.UseVisualStyleBackColor = true;
		this.numericUpDown_0.Location = new Point(240, 90);
		this.numericUpDown_0.Name = "nudCoeffLoading";
		this.numericUpDown_0.Size = new Size(90, 20);
		this.numericUpDown_0.TabIndex = 21;
		base.AcceptButton = this.button_0;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = this.button_1;
		base.ClientSize = new Size(340, 186);
		base.Controls.Add(this.numericUpDown_0);
		base.Controls.Add(this.checkBox_1);
		base.Controls.Add(this.checkBox_0);
		base.Controls.Add(this.comboBox_3);
		base.Controls.Add(this.label_3);
		base.Controls.Add(this.comboBox_2);
		base.Controls.Add(this.textBox_0);
		base.Controls.Add(this.label_0);
		base.Controls.Add(this.label_1);
		base.Controls.Add(this.comboBox_0);
		base.Controls.Add(this.label_2);
		base.Controls.Add(this.comboBox_1);
		base.Controls.Add(this.tableLayoutPanel_0);
		base.Name = "FormCoefficientLoadihgParam";
		this.Text = "Анализ коэффициента загрузки\t";
		base.FormClosing += this.Form42_FormClosing;
		base.Load += this.Form42_Load;
		this.tableLayoutPanel_0.ResumeLayout(false);
		((ISupportInitialize)this.class255_0).EndInit();
		((ISupportInitialize)this.numericUpDown_0).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	internal static void lINydr0XrffgD55fCxR0(Form42 form_0, bool bool_0)
	{
		form_0.Dispose(bool_0);
	}

	[CompilerGenerated]
	private Enum13 NtToSuqedq2;

	private Label label_0;

	private Label label_1;

	private ComboBox comboBox_0;

	private Label label_2;

	private ComboBox comboBox_1;

	private TableLayoutPanel tableLayoutPanel_0;

	private Button button_0;

	private Button button_1;

	private Class255 class255_0;

	private TextBox textBox_0;

	private ComboBox comboBox_2;

	private ComboBox comboBox_3;

	private Label label_3;

	private CheckBox checkBox_0;

	private CheckBox checkBox_1;

	private NumericUpDown numericUpDown_0;
}
