using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using FormLbr;

internal partial class Form63 : FormBase
{
	internal int method_0()
	{
		return this.int_0;
	}

	internal void method_1(int int_2)
	{
		this.int_0 = int_2;
	}

	public Form63()
	{
		
		this.int_0 = -1;
		this.int_1 = -1;
		this.dictionary_0 = new Dictionary<string, string>();
		
		this.method_3();
		this.method_2();
	}

	internal Form63(int int_2, int int_3, Enum19 enum19_1)
	{
		
		this.int_0 = -1;
		this.int_1 = -1;
		this.dictionary_0 = new Dictionary<string, string>();
		
		this.method_3();
		this.int_0 = int_2;
		this.int_1 = int_3;
		this.enum19_0 = enum19_1;
		this.method_2();
	}

	private void method_2()
	{
		this.Text = ((this.int_0 == -1) ? "Добавление " : "Редактирование ");
		switch (this.enum19_0)
		{
		case (Enum19)1:
		{
			this.Text += "повреждения";
			Control control = this.label_2;
			Control control2 = this.label_1;
			Control control3 = this.textBox_1;
			this.textBox_0.Visible = false;
			control3.Visible = false;
			control2.Visible = false;
			control.Visible = false;
			base.Height = 155;
			break;
		}
		case (Enum19)2:
			this.Text += "площади восстановления";
			break;
		case (Enum19)3:
			this.Text += "материала";
			break;
		}
		this.dictionary_0.Add("песок", "тонн");
		this.dictionary_0.Add("семена", "кг");
		this.dictionary_0.Add("щебень", "тонн");
		this.dictionary_0.Add("бордюрный камень (б\\у)", "м");
		this.dictionary_0.Add("тротуар", "кв.м");
		this.dictionary_0.Add("местный проезд", "кв.м");
		this.dictionary_0.Add("дорога", "кв.м");
		this.dictionary_0.Add("бордюрный камень", "м");
		this.dictionary_0.Add("грунт-зеленая зона", "кв.м");
		this.dictionary_0.Add("плитка", "кв.м");
	}

	private void Form63_Load(object sender, EventArgs e)
	{
		switch (this.enum19_0)
		{
		case (Enum19)1:
		case (Enum19)2:
			base.SelectSqlData(this.class130_0, this.class130_0.tR_Classifier, true, " where ParentKey = ';Excavation;Surface;' and isGroup = 0 and deleted = 0 order by name");
			break;
		case (Enum19)3:
			base.SelectSqlData(this.class130_0, this.class130_0.tR_Classifier, true, " where ParentKey = ';Excavation;Materials;' and isGroup = 0 and deleted = 0 order by name");
			break;
		}
		if (this.int_0 == -1)
		{
			DataRow dataRow = this.class130_0.tJ_ExcavationSurface.NewRow();
			dataRow["idExcavation"] = this.int_1;
			dataRow["idType"] = (int)this.enum19_0;
			dataRow["idSurface"] = -1;
			this.class130_0.tJ_ExcavationSurface.Rows.Add(dataRow);
		}
		else
		{
			base.SelectSqlData(this.class130_0, this.class130_0.tJ_ExcavationSurface, true, "where id = " + this.int_0.ToString());
		}
		this.class130_0.tJ_ExcavationSurface.Rows[0].BeginEdit();
	}

	private void Form63_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (base.DialogResult == DialogResult.OK)
		{
			if (this.comboBox_0.SelectedIndex < 0)
			{
				MessageBox.Show("не введены обязательные поля");
				e.Cancel = true;
				return;
			}
			if (this.enum19_0 == (Enum19)1)
			{
				this.class130_0.tJ_ExcavationSurface.Rows[0]["Value"] = DBNull.Value;
				this.class130_0.tJ_ExcavationSurface.Rows[0]["Unit"] = DBNull.Value;
			}
			if (this.int_0 == -1)
			{
				this.class130_0.tJ_ExcavationSurface.Rows[0].EndEdit();
				this.int_0 = base.InsertSqlDataOneRow(this.class130_0, this.class130_0.tJ_ExcavationSurface);
				return;
			}
			this.class130_0.tJ_ExcavationSurface.Rows[0].EndEdit();
			base.UpdateSqlData(this.class130_0, this.class130_0.tJ_ExcavationSurface);
		}
	}

	private void comboBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.comboBox_0.SelectedIndex >= 0 && !string.IsNullOrEmpty(this.comboBox_0.Text) && this.dictionary_0.ContainsKey(this.comboBox_0.Text))
		{
			this.class130_0.tJ_ExcavationSurface.Rows[0]["unit"] = this.dictionary_0[this.comboBox_0.Text];
			this.textBox_1.Text = this.dictionary_0[this.comboBox_0.Text];
		}
	}

	private void method_3()
	{
		this.label_0 = new Label();
		this.comboBox_0 = new ComboBox();
		this.label_1 = new Label();
		this.textBox_0 = new TextBox();
		this.label_2 = new Label();
		this.textBox_1 = new TextBox();
		this.label_3 = new Label();
		this.textBox_2 = new TextBox();
		this.button_0 = new Button();
		this.button_1 = new Button();
		this.class130_0 = new DataSetExcavation();
		((ISupportInitialize)this.class130_0).BeginInit();
		base.SuspendLayout();
		this.label_0.AutoSize = true;
		this.label_0.Location = new Point(12, 18);
		this.label_0.Name = "label1";
		this.label_0.Size = new Size(57, 13);
		this.label_0.TabIndex = 0;
		this.label_0.Text = "Материал";
		this.comboBox_0.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBox_0.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBox_0.DataBindings.Add(new Binding("SelectedValue", this.class130_0, "tJ_ExcavationSurface.idSurface", true));
		this.comboBox_0.DataSource = this.class130_0;
		this.comboBox_0.DisplayMember = "tR_Classifier.Name";
		this.comboBox_0.FormattingEnabled = true;
		this.comboBox_0.Location = new Point(94, 15);
		this.comboBox_0.Name = "cmbSurface";
		this.comboBox_0.Size = new Size(249, 21);
		this.comboBox_0.TabIndex = 1;
		this.comboBox_0.ValueMember = "tR_Classifier.Id";
		this.comboBox_0.SelectedIndexChanged += this.comboBox_0_SelectedIndexChanged;
		this.label_1.AutoSize = true;
		this.label_1.Location = new Point(12, 45);
		this.label_1.Name = "labelValue";
		this.label_1.Size = new Size(55, 13);
		this.label_1.TabIndex = 2;
		this.label_1.Text = "Значение";
		this.textBox_0.DataBindings.Add(new Binding("Text", this.class130_0, "tJ_ExcavationSurface.Value", true));
		this.textBox_0.Location = new Point(94, 42);
		this.textBox_0.Name = "txtValue";
		this.textBox_0.Size = new Size(249, 20);
		this.textBox_0.TabIndex = 3;
		this.label_2.AutoSize = true;
		this.label_2.Location = new Point(12, 71);
		this.label_2.Name = "labelUnit";
		this.label_2.Size = new Size(76, 13);
		this.label_2.TabIndex = 4;
		this.label_2.Text = "Единица изм.";
		this.textBox_1.DataBindings.Add(new Binding("Text", this.class130_0, "tJ_ExcavationSurface.unit", true));
		this.textBox_1.Location = new Point(94, 68);
		this.textBox_1.Name = "txtUnit";
		this.textBox_1.Size = new Size(249, 20);
		this.textBox_1.TabIndex = 5;
		this.label_3.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.label_3.AutoSize = true;
		this.label_3.Location = new Point(12, 97);
		this.label_3.Name = "label4";
		this.label_3.Size = new Size(70, 13);
		this.label_3.TabIndex = 6;
		this.label_3.Text = "Примечание";
		this.textBox_2.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.textBox_2.DataBindings.Add(new Binding("Text", this.class130_0, "tJ_ExcavationSurface.comment", true));
		this.textBox_2.Location = new Point(94, 94);
		this.textBox_2.Name = "txtComment";
		this.textBox_2.Size = new Size(249, 20);
		this.textBox_2.TabIndex = 7;
		this.button_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.button_0.DialogResult = DialogResult.OK;
		this.button_0.Location = new Point(15, 129);
		this.button_0.Name = "buttonOK";
		this.button_0.Size = new Size(75, 23);
		this.button_0.TabIndex = 8;
		this.button_0.Text = "ОК";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.button_1.DialogResult = DialogResult.Cancel;
		this.button_1.Location = new Point(268, 129);
		this.button_1.Name = "buttonCancel";
		this.button_1.Size = new Size(75, 23);
		this.button_1.TabIndex = 9;
		this.button_1.Text = "Отмена";
		this.button_1.UseVisualStyleBackColor = true;
		this.class130_0.DataSetName = "DataSetExcavation";
		this.class130_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		base.AcceptButton = this.button_0;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = this.button_1;
		base.ClientSize = new Size(350, 163);
		base.Controls.Add(this.button_1);
		base.Controls.Add(this.button_0);
		base.Controls.Add(this.textBox_2);
		base.Controls.Add(this.label_3);
		base.Controls.Add(this.textBox_1);
		base.Controls.Add(this.label_2);
		base.Controls.Add(this.textBox_0);
		base.Controls.Add(this.label_1);
		base.Controls.Add(this.comboBox_0);
		base.Controls.Add(this.label_0);
		base.Name = "FormExcavationSurfaceAddEdit";
		this.Text = "FormExcavationSurfaceAddEdit";
		base.FormClosing += this.Form63_FormClosing;
		base.Load += this.Form63_Load;
		((ISupportInitialize)this.class130_0).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	private int int_0;

	private Enum19 enum19_0;

	private int int_1;

	private Dictionary<string, string> dictionary_0;

	private Label label_0;

	private ComboBox comboBox_0;

	private Label label_1;

	private TextBox textBox_0;

	private Label label_2;

	private TextBox textBox_1;

	private Label label_3;

	private TextBox textBox_2;

	private Button button_0;

	private Button button_1;

	private DataSetExcavation class130_0;
}
