using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using FormLbr;

internal partial class Form43 : FormBase
{
	internal Form43()
	{
		
		
		this.method_0();
	}

	private void Form43_Load(object sender, EventArgs e)
	{
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
		this.comboBox_1.DataSource = this.class255_0.tR_Classifier;
		this.comboBox_1.DisplayMember = "Name";
		this.comboBox_1.ValueMember = "Id";
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
		this.comboBox_0.DataSource = dataTable;
		this.comboBox_0.DisplayMember = "Year";
		this.comboBox_0.ValueMember = "Year";
		this.comboBox_0.SelectedValue = DateTime.Now.Year;
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		base.Close();
	}

	private void Form43_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (base.DialogResult == DialogResult.OK)
		{
			new Form44(this.SqlSettings, (int)this.comboBox_0.SelectedValue, (int)this.comboBox_1.SelectedValue, this.numericUpDown_0.Value)
			{
				MdiParent = base.MdiParent
			}.Show();
		}
	}

	private void method_0()
	{
		this.slhoSjdNhfc = new TableLayoutPanel();
		this.button_0 = new Button();
		this.button_1 = new Button();
		this.comboBox_0 = new ComboBox();
		this.label_0 = new Label();
		this.comboBox_1 = new ComboBox();
		this.label_1 = new Label();
		this.numericUpDown_0 = new NumericUpDown();
		this.label_2 = new Label();
		this.class255_0 = new Class255();
		this.slhoSjdNhfc.SuspendLayout();
		((ISupportInitialize)this.numericUpDown_0).BeginInit();
		((ISupportInitialize)this.class255_0).BeginInit();
		base.SuspendLayout();
		this.slhoSjdNhfc.ColumnCount = 2;
		this.slhoSjdNhfc.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		this.slhoSjdNhfc.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 98f));
		this.slhoSjdNhfc.Controls.Add(this.button_0, 0, 0);
		this.slhoSjdNhfc.Controls.Add(this.button_1, 1, 0);
		this.slhoSjdNhfc.Dock = DockStyle.Bottom;
		this.slhoSjdNhfc.Location = new Point(0, 121);
		this.slhoSjdNhfc.Name = "tableLayoutPanel1";
		this.slhoSjdNhfc.RowCount = 1;
		this.slhoSjdNhfc.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		this.slhoSjdNhfc.Size = new Size(261, 35);
		this.slhoSjdNhfc.TabIndex = 0;
		this.button_0.DialogResult = DialogResult.OK;
		this.button_0.Dock = DockStyle.Right;
		this.button_0.Location = new Point(61, 6);
		this.button_0.Margin = new Padding(3, 6, 10, 6);
		this.button_0.Name = "btnAccept";
		this.button_0.Size = new Size(92, 23);
		this.button_0.TabIndex = 0;
		this.button_0.Text = "Применить";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_0.Click += this.button_1_Click;
		this.button_1.DialogResult = DialogResult.Cancel;
		this.button_1.Dock = DockStyle.Left;
		this.button_1.Location = new Point(173, 6);
		this.button_1.Margin = new Padding(10, 6, 3, 6);
		this.button_1.Name = "btnCancel";
		this.button_1.Size = new Size(70, 23);
		this.button_1.TabIndex = 1;
		this.button_1.Text = "Отмена";
		this.button_1.UseVisualStyleBackColor = true;
		this.button_1.Click += this.button_1_Click;
		this.comboBox_0.FormattingEnabled = true;
		this.comboBox_0.Location = new Point(100, 22);
		this.comboBox_0.Name = "cbYear";
		this.comboBox_0.Size = new Size(149, 21);
		this.comboBox_0.TabIndex = 1;
		this.label_0.AutoSize = true;
		this.label_0.Location = new Point(12, 25);
		this.label_0.Name = "label1";
		this.label_0.Size = new Size(25, 13);
		this.label_0.TabIndex = 2;
		this.label_0.Text = "Год";
		this.comboBox_1.FormattingEnabled = true;
		this.comboBox_1.Location = new Point(100, 49);
		this.comboBox_1.Name = "cbNetworkAreas";
		this.comboBox_1.Size = new Size(149, 21);
		this.comboBox_1.TabIndex = 3;
		this.label_1.AutoSize = true;
		this.label_1.Location = new Point(12, 52);
		this.label_1.Name = "label2";
		this.label_1.Size = new Size(82, 13);
		this.label_1.TabIndex = 4;
		this.label_1.Text = "Сетевой район";
		this.numericUpDown_0.DecimalPlaces = 1;
		this.numericUpDown_0.Increment = new decimal(new int[]
		{
			1,
			0,
			0,
			65536
		});
		this.numericUpDown_0.Location = new Point(101, 76);
		this.numericUpDown_0.Name = "nudFactor";
		this.numericUpDown_0.Size = new Size(148, 20);
		this.numericUpDown_0.TabIndex = 5;
		this.label_2.AutoSize = true;
		this.label_2.Location = new Point(12, 78);
		this.label_2.Name = "label3";
		this.label_2.Size = new Size(77, 13);
		this.label_2.TabIndex = 6;
		this.label_2.Text = "Коэффициент";
		this.class255_0.DataSetName = "DataSetGES";
		this.class255_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		base.AcceptButton = this.button_0;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = this.button_1;
		base.ClientSize = new Size(261, 156);
		base.Controls.Add(this.label_2);
		base.Controls.Add(this.numericUpDown_0);
		base.Controls.Add(this.label_1);
		base.Controls.Add(this.comboBox_1);
		base.Controls.Add(this.label_0);
		base.Controls.Add(this.comboBox_0);
		base.Controls.Add(this.slhoSjdNhfc);
		base.Name = "FormExcessLoadParam";
		base.StartPosition = FormStartPosition.CenterScreen;
		this.Text = "Превышение нагрузки";
		base.FormClosing += this.Form43_FormClosing;
		base.Load += this.Form43_Load;
		this.slhoSjdNhfc.ResumeLayout(false);
		((ISupportInitialize)this.numericUpDown_0).EndInit();
		((ISupportInitialize)this.class255_0).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	private TableLayoutPanel slhoSjdNhfc;

	private Button button_0;

	private Button button_1;

	private ComboBox comboBox_0;

	private Label label_0;

	private ComboBox comboBox_1;

	private Label label_1;

	private NumericUpDown numericUpDown_0;

	private Label label_2;

	private Class255 class255_0;
}
