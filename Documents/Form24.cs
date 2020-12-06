using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ControlsLbr;
using FormLbr;

internal partial class Form24 : FormBase
{
	internal int method_0()
	{
		return this.int_0;
	}

	internal Form24()
	{
		
		this.int_0 = -1;
		this.int_1 = -1;
		this.int_2 = -1;
		this.class10_0 = new Class10();
		
		this.method_2();
	}

	internal Form24(int int_3, int int_4 = -1, int int_5 = -1)
	{
		
		this.int_0 = -1;
		this.int_1 = -1;
		this.int_2 = -1;
		this.class10_0 = new Class10();
		
		this.method_2();
		this.int_0 = int_3;
		this.int_1 = int_4;
		this.int_2 = int_5;
		this.Text = ((int_3 == -1) ? "Новый договор" : "Редактирование договор");
		this.nullableDateTimePicker_0.Value = DateTime.Now.Date;
	}

	private void method_1()
	{
		DataRow dataRow = this.class10_1.tTC_Doc.NewRow();
		dataRow["TypeDoc"] = 1220;
		dataRow["DateDoc"] = DateTime.Now.Date;
		this.class10_1.tTC_Doc.Rows.Add(dataRow);
	}

	private void Form24_Load(object sender, EventArgs e)
	{
		if (this.int_0 == -1)
		{
			this.method_1();
			if (this.int_1 == -1)
			{
				base.SelectSqlData(this.class10_1, this.class10_1.vTC_DocOut, true, string.Concat(new string[]
				{
					"where idDocOut = ",
					this.int_2.ToString(),
					" and typeDoc in (",
					1113.ToString(),
					",",
					1203.ToString(),
					")"
				}));
				if (this.class10_1.vTC_DocOut.Rows.Count > 0)
				{
					this.int_1 = Convert.ToInt32(this.class10_1.vTC_DocOut.Rows[0]["idDoc"]);
				}
				else
				{
					MessageBox.Show("Ошибка");
					this.button_0.Enabled = false;
				}
			}
			DataRow dataRow = this.class10_1.tTC_DocOut.NewRow();
			dataRow["idDoc"] = this.int_1;
			dataRow["idDocOut"] = this.class10_1.tTC_Doc.Rows[0]["id"];
			this.class10_1.tTC_DocOut.Rows.Add(dataRow);
			if (this.int_2 == -1)
			{
				base.SelectSqlData(this.class10_1, this.class10_1.vTC_DocOut, true, "where idDoc = " + this.int_1.ToString() + " and typeDocOut = " + 1123.ToString());
				if (this.class10_1.vTC_DocOut.Rows.Count > 0)
				{
					this.int_2 = Convert.ToInt32(this.class10_1.vTC_DocOut.Rows[0]["idDocOut"]);
				}
				else
				{
					MessageBox.Show("Ошибка");
					this.button_0.Enabled = false;
				}
			}
			base.SelectSqlData(this.class10_0, this.class10_0.tTC_Doc, true, "where id = " + this.int_2.ToString());
			return;
		}
		base.SelectSqlData(this.class10_1, this.class10_1.tTC_Doc, true, "where id = " + this.int_0.ToString());
		base.SelectSqlData(this.class10_1, this.class10_1.tTC_DocOut, true, "where idDocOut = " + this.int_0.ToString());
		base.SelectSqlData(this.class10_0, this.class10_0.tTC_Doc, true, "where idParent = " + this.int_0.ToString());
	}

	private void Form24_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (base.DialogResult == DialogResult.OK)
		{
			if (string.IsNullOrEmpty(this.textBox_0.Text))
			{
				MessageBox.Show("Не введен номер договора");
				e.Cancel = true;
				return;
			}
			if (this.int_0 == -1)
			{
				this.class10_1.tTC_Doc.Rows[0].EndEdit();
				int num = base.InsertSqlDataOneRow(this.class10_1, this.class10_1.tTC_Doc);
				this.class10_1.tTC_DocOut.Rows[0]["idDocOut"] = num;
				this.class10_1.tTC_DocOut.Rows[0].EndEdit();
				this.int_0 = base.InsertSqlDataOneRow(this.class10_1, this.class10_1.tTC_DocOut);
				this.class10_0.tTC_Doc.Rows[0]["idParent"] = num;
				this.class10_0.tTC_Doc.Rows[0].EndEdit();
				base.UpdateSqlData(this.class10_0, this.class10_0.tTC_Doc);
				return;
			}
			this.class10_1.tTC_Doc.Rows[0].EndEdit();
			base.UpdateSqlData(this.class10_1, this.class10_1.tTC_Doc);
			this.class10_1.tTC_DocOut.Rows[0].EndEdit();
			base.UpdateSqlData(this.class10_1, this.class10_1.tTC_DocOut);
			this.class10_0.tTC_Doc.Rows[0].EndEdit();
			base.UpdateSqlData(this.class10_0, this.class10_0.tTC_Doc);
		}
	}

	private void method_2()
	{
		this.class10_1 = new Class10();
		this.label_0 = new Label();
		this.textBox_0 = new TextBox();
		this.nullableDateTimePicker_0 = new NullableDateTimePicker();
		this.button_0 = new Button();
		this.button_1 = new Button();
		this.label_1 = new Label();
		this.textBox_1 = new TextBox();
		this.label_2 = new Label();
		this.textBox_2 = new TextBox();
		this.AwSomcGngeI = new Label();
		((ISupportInitialize)this.class10_1).BeginInit();
		base.SuspendLayout();
		this.class10_1.DataSetName = "DataSetTechConnection";
		this.class10_1.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		this.label_0.AutoSize = true;
		this.label_0.Location = new Point(9, 9);
		this.label_0.Name = "label2";
		this.label_0.Size = new Size(124, 13);
		this.label_0.TabIndex = 2;
		this.label_0.Text = "Номер договора на ТП";
		this.textBox_0.DataBindings.Add(new Binding("Text", this.class10_1, "tTC_Doc.numDoc", true));
		this.textBox_0.Location = new Point(12, 25);
		this.textBox_0.Name = "txtNumDocOut";
		this.textBox_0.Size = new Size(293, 20);
		this.textBox_0.TabIndex = 3;
		this.nullableDateTimePicker_0.DataBindings.Add(new Binding("Value", this.class10_1, "tTC_Doc.dateDoc", true));
		this.nullableDateTimePicker_0.Location = new Point(12, 64);
		this.nullableDateTimePicker_0.Name = "dateTimePickerDocOut";
		this.nullableDateTimePicker_0.Size = new Size(293, 20);
		this.nullableDateTimePicker_0.TabIndex = 4;
		this.nullableDateTimePicker_0.Value = new DateTime(2013, 4, 29, 14, 38, 3, 750);
		this.button_0.DialogResult = DialogResult.OK;
		this.button_0.Location = new Point(12, 295);
		this.button_0.Name = "buttonOK";
		this.button_0.Size = new Size(75, 23);
		this.button_0.TabIndex = 11;
		this.button_0.Text = "ОК";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_1.DialogResult = DialogResult.Cancel;
		this.button_1.Location = new Point(230, 295);
		this.button_1.Name = "buttonCancel";
		this.button_1.Size = new Size(75, 23);
		this.button_1.TabIndex = 12;
		this.button_1.Text = "Отмена";
		this.button_1.UseVisualStyleBackColor = true;
		this.label_1.AutoSize = true;
		this.label_1.Location = new Point(12, 171);
		this.label_1.Name = "label6";
		this.label_1.Size = new Size(77, 13);
		this.label_1.TabIndex = 9;
		this.label_1.Text = "Комментарий";
		this.textBox_1.AcceptsReturn = true;
		this.textBox_1.AcceptsTab = true;
		this.textBox_1.DataBindings.Add(new Binding("Text", this.class10_1, "tTC_Doc.Comment", true));
		this.textBox_1.Location = new Point(12, 187);
		this.textBox_1.Multiline = true;
		this.textBox_1.Name = "txtComment";
		this.textBox_1.Size = new Size(293, 103);
		this.textBox_1.TabIndex = 10;
		this.label_2.AutoSize = true;
		this.label_2.Location = new Point(12, 87);
		this.label_2.Name = "label7";
		this.label_2.Size = new Size(70, 13);
		this.label_2.TabIndex = 5;
		this.label_2.Text = "Содержание";
		this.textBox_2.AcceptsReturn = true;
		this.textBox_2.AcceptsTab = true;
		this.textBox_2.DataBindings.Add(new Binding("Text", this.class10_1, "tTC_Doc.Body", true));
		this.textBox_2.Location = new Point(12, 103);
		this.textBox_2.Multiline = true;
		this.textBox_2.Name = "txtBody";
		this.textBox_2.Size = new Size(293, 65);
		this.textBox_2.TabIndex = 6;
		this.AwSomcGngeI.AutoSize = true;
		this.AwSomcGngeI.Location = new Point(12, 48);
		this.AwSomcGngeI.Name = "label1";
		this.AwSomcGngeI.Size = new Size(116, 13);
		this.AwSomcGngeI.TabIndex = 17;
		this.AwSomcGngeI.Text = "Дата договора на ТП";
		base.AcceptButton = this.button_0;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = this.button_1;
		base.ClientSize = new Size(309, 330);
		base.Controls.Add(this.AwSomcGngeI);
		base.Controls.Add(this.textBox_2);
		base.Controls.Add(this.label_2);
		base.Controls.Add(this.textBox_1);
		base.Controls.Add(this.label_1);
		base.Controls.Add(this.button_1);
		base.Controls.Add(this.button_0);
		base.Controls.Add(this.nullableDateTimePicker_0);
		base.Controls.Add(this.textBox_0);
		base.Controls.Add(this.label_0);
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "FormSmallContractAddEdit";
		this.Text = "FormTechConnectionDocOutAddEdit";
		base.FormClosing += this.Form24_FormClosing;
		base.Load += this.Form24_Load;
		((ISupportInitialize)this.class10_1).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	internal static void qTJfg3OT4B00ydktc2RP(Form form_0, bool bool_0)
	{
		form_0.Dispose(bool_0);
	}

	private int int_0;

	private int int_1;

	private int int_2;

	private Class10 class10_0;

	private Label label_0;

	private TextBox textBox_0;

	private NullableDateTimePicker nullableDateTimePicker_0;

	private Class10 class10_1;

	private Button button_0;

	private Button button_1;

	private Label label_1;

	private TextBox textBox_1;

	private Label label_2;

	private TextBox textBox_2;

	private Label AwSomcGngeI;
}
