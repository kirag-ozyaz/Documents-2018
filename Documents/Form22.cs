using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using FormLbr;

internal partial class Form22 : FormBase
{
	internal DataRow method_0()
	{
		if (this.class10_0.tTC_Doc.Rows.Count > 0)
		{
			return this.class10_0.tTC_Doc.Rows[0];
		}
		return null;
	}

	internal DataRow method_1()
	{
		if (this.class10_0.tTC_Payment.Rows.Count > 0)
		{
			return this.class10_0.tTC_Payment.Rows[0];
		}
		return null;
	}

	internal Form22()
	{
		
		this.int_0 = -1;
		
		this.method_3();
	}

	internal Form22(DataRow dataRow_2, DataRow dataRow_3)
	{
		
		this.int_0 = -1;
		
		this.method_3();
		this.dataRow_0 = dataRow_2;
		this.dataRow_1 = dataRow_3;
	}

	private void Form22_Load(object sender, EventArgs e)
	{
		this.method_2();
		if (this.int_0 == -1 && this.dataRow_0 == null && this.dataRow_1 == null)
		{
			this.Text = "Новый документ";
			DataRow dataRow = this.class10_0.tTC_Doc.NewRow();
			dataRow["TypeDoc"] = -1;
			dataRow["dateDoc"] = DateTime.Now.Date;
			this.class10_0.tTC_Doc.Rows.Add(dataRow);
			DataRow dataRow2 = this.class10_0.tTC_Payment.NewRow();
			dataRow2["id"] = this.int_0;
			dataRow2["summa"] = 0;
			this.class10_0.tTC_Payment.Rows.Add(dataRow2);
			return;
		}
		this.Text = "Редактировать документ";
		if (this.dataRow_0 != null)
		{
			DataRow dataRow3 = this.class10_0.tTC_Doc.NewRow();
			dataRow3["typeDoc"] = this.dataRow_0["typeDoc"];
			dataRow3["numDoc"] = this.dataRow_0["numdoc"];
			dataRow3["dateDoc"] = this.dataRow_0["datedoc"];
			dataRow3["comment"] = this.dataRow_0["comment"];
			this.class10_0.tTC_Doc.Rows.Add(dataRow3);
			if (this.dataRow_1 != null)
			{
				DataRow dataRow4 = this.class10_0.tTC_Payment.NewRow();
				dataRow4["id"] = dataRow3["id"];
				dataRow4["summa"] = this.dataRow_1["summa"];
				dataRow4["idDog"] = this.dataRow_1["iddog"];
				this.class10_0.tTC_Payment.Rows.Add(dataRow4);
				return;
			}
			DataRow dataRow5 = this.class10_0.tTC_Payment.NewRow();
			dataRow5["id"] = dataRow3["id"];
			dataRow5["summa"] = 0;
			this.class10_0.tTC_Payment.Rows.Add(dataRow5);
		}
	}

	private void Form22_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (base.DialogResult == DialogResult.OK)
		{
			if (this.comboBox_0.SelectedIndex == -1)
			{
				MessageBox.Show("Не выбран тип документа");
				e.Cancel = true;
				return;
			}
			if (this.numericUpDown_0.Value == 0m)
			{
				MessageBox.Show("Сумма должна отличаться от нуля");
				e.Cancel = true;
				return;
			}
		}
	}

	private void method_2()
	{
		Class10 @class = new Class10();
		base.SelectSqlData(@class.tR_Classifier, true, " where ParentKey = ';TechConnect;TypeDoc;Payment;' and isGroup = 0 and deleted = 0 order by name", null, false, 0);
		this.comboBox_0.ValueMember = "id";
		this.comboBox_0.DisplayMember = "name";
		this.comboBox_0.DataSource = @class.tR_Classifier;
		this.comboBox_0.SelectedIndex = -1;
		DataTable dataTable = new DataTable("tTC_Doc");
		dataTable.Columns.Add(new DataColumn("id", typeof(int)));
		dataTable.Columns.Add(new DataColumn("numDoc", typeof(string)));
		dataTable.Columns.Add(new DataColumn("dateDoc", typeof(DateTime)));
		dataTable.Columns.Add(new DataColumn("numdate", typeof(string), "isnull(numDoc, '') + ' от ' + substring(isnull(Convert(dateDoc, 'System.String'), '          '), 1, 10)"));
		base.SelectSqlData(dataTable, true, " where typeDoc = " + 1220.ToString() + " order by numDoc, dateDoc", null, false, 0);
		this.comboBox_1.ValueMember = "id";
		this.comboBox_1.DisplayMember = "numdate";
		this.comboBox_1.DataSource = dataTable;
		this.comboBox_0.SelectedIndex = -1;
	}

	private void method_3()
	{
		this.label_0 = new Label();
		this.comboBox_0 = new ComboBox();
		this.class10_0 = new Class10();
		this.label_1 = new Label();
		this.textBox_0 = new TextBox();
		this.label_2 = new Label();
		this.dateTimePicker_0 = new DateTimePicker();
		this.wbdomltZnds = new Label();
		this.numericUpDown_0 = new NumericUpDown();
		this.label_3 = new Label();
		this.comboBox_1 = new ComboBox();
		this.label_4 = new Label();
		this.richTextBox_0 = new RichTextBox();
		this.button_0 = new Button();
		this.button_1 = new Button();
		((ISupportInitialize)this.class10_0).BeginInit();
		((ISupportInitialize)this.numericUpDown_0).BeginInit();
		base.SuspendLayout();
		this.label_0.AutoSize = true;
		this.label_0.Location = new Point(12, 9);
		this.label_0.Name = "label1";
		this.label_0.Size = new Size(72, 13);
		this.label_0.TabIndex = 0;
		this.label_0.Text = "Вид платежа";
		this.comboBox_0.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBox_0.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBox_0.DataBindings.Add(new Binding("SelectedValue", this.class10_0, "tTC_Doc.TypeDoc", true));
		this.comboBox_0.FormattingEnabled = true;
		this.comboBox_0.Location = new Point(15, 25);
		this.comboBox_0.Name = "cmbTypePayment";
		this.comboBox_0.Size = new Size(378, 21);
		this.comboBox_0.TabIndex = 1;
		this.class10_0.DataSetName = "DataSetTechConnection";
		this.class10_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		this.label_1.AutoSize = true;
		this.label_1.Location = new Point(12, 49);
		this.label_1.Name = "label2";
		this.label_1.Size = new Size(41, 13);
		this.label_1.TabIndex = 2;
		this.label_1.Text = "Номер";
		this.textBox_0.DataBindings.Add(new Binding("Text", this.class10_0, "tTC_Doc.numDoc", true));
		this.textBox_0.Location = new Point(15, 65);
		this.textBox_0.Name = "txtNum";
		this.textBox_0.Size = new Size(197, 20);
		this.textBox_0.TabIndex = 3;
		this.label_2.AutoSize = true;
		this.label_2.Location = new Point(218, 49);
		this.label_2.Name = "label3";
		this.label_2.Size = new Size(33, 13);
		this.label_2.TabIndex = 4;
		this.label_2.Text = "Дата";
		this.dateTimePicker_0.DataBindings.Add(new Binding("Value", this.class10_0, "tTC_Doc.dateDoc", true));
		this.dateTimePicker_0.Location = new Point(221, 65);
		this.dateTimePicker_0.Name = "dateTimePickerPayment";
		this.dateTimePicker_0.Size = new Size(172, 20);
		this.dateTimePicker_0.TabIndex = 5;
		this.wbdomltZnds.AutoSize = true;
		this.wbdomltZnds.Location = new Point(12, 88);
		this.wbdomltZnds.Name = "label4";
		this.wbdomltZnds.Size = new Size(41, 13);
		this.wbdomltZnds.TabIndex = 6;
		this.wbdomltZnds.Text = "Сумма";
		this.numericUpDown_0.DataBindings.Add(new Binding("Value", this.class10_0, "tTC_Payment.summa", true));
		this.numericUpDown_0.DecimalPlaces = 2;
		this.numericUpDown_0.Location = new Point(15, 104);
		NumericUpDown numericUpDown = this.numericUpDown_0;
		int[] array = new int[4];
		array[0] = 999999999;
		numericUpDown.Maximum = new decimal(array);
		this.numericUpDown_0.Minimum = new decimal(new int[]
		{
			999999999,
			0,
			0,
			int.MinValue
		});
		this.numericUpDown_0.Name = "numericUpDownSumma";
		this.numericUpDown_0.Size = new Size(378, 20);
		this.numericUpDown_0.TabIndex = 7;
		this.label_3.AutoSize = true;
		this.label_3.Location = new Point(12, 127);
		this.label_3.Name = "label5";
		this.label_3.Size = new Size(116, 13);
		this.label_3.TabIndex = 8;
		this.label_3.Text = "Договор откуда/куда";
		this.comboBox_1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBox_1.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBox_1.DataBindings.Add(new Binding("SelectedValue", this.class10_0, "tTC_Payment.idDog", true));
		this.comboBox_1.FormattingEnabled = true;
		this.comboBox_1.Location = new Point(15, 143);
		this.comboBox_1.Name = "cmbDog";
		this.comboBox_1.Size = new Size(378, 21);
		this.comboBox_1.TabIndex = 9;
		this.label_4.AutoSize = true;
		this.label_4.Location = new Point(12, 167);
		this.label_4.Name = "label6";
		this.label_4.Size = new Size(77, 13);
		this.label_4.TabIndex = 10;
		this.label_4.Text = "Комментарий";
		this.richTextBox_0.DataBindings.Add(new Binding("Text", this.class10_0, "tTC_Doc.Comment", true));
		this.richTextBox_0.Location = new Point(15, 183);
		this.richTextBox_0.Name = "txtComment";
		this.richTextBox_0.Size = new Size(378, 96);
		this.richTextBox_0.TabIndex = 11;
		this.richTextBox_0.Text = "";
		this.button_0.DialogResult = DialogResult.OK;
		this.button_0.Location = new Point(15, 298);
		this.button_0.Name = "buttonOK";
		this.button_0.Size = new Size(75, 23);
		this.button_0.TabIndex = 12;
		this.button_0.Text = "ОК";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_1.DialogResult = DialogResult.Cancel;
		this.button_1.Location = new Point(318, 298);
		this.button_1.Name = "buttonCancel";
		this.button_1.Size = new Size(75, 23);
		this.button_1.TabIndex = 13;
		this.button_1.Text = "Отмена";
		this.button_1.UseVisualStyleBackColor = true;
		base.AcceptButton = this.button_0;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = this.button_1;
		base.ClientSize = new Size(405, 325);
		base.Controls.Add(this.button_1);
		base.Controls.Add(this.button_0);
		base.Controls.Add(this.richTextBox_0);
		base.Controls.Add(this.label_4);
		base.Controls.Add(this.comboBox_1);
		base.Controls.Add(this.label_3);
		base.Controls.Add(this.numericUpDown_0);
		base.Controls.Add(this.wbdomltZnds);
		base.Controls.Add(this.dateTimePicker_0);
		base.Controls.Add(this.label_2);
		base.Controls.Add(this.textBox_0);
		base.Controls.Add(this.label_1);
		base.Controls.Add(this.comboBox_0);
		base.Controls.Add(this.label_0);
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "FormPaymentAddEdit";
		this.Text = "FormPaymentAddEdit";
		base.FormClosing += this.Form22_FormClosing;
		base.Load += this.Form22_Load;
		((ISupportInitialize)this.class10_0).EndInit();
		((ISupportInitialize)this.numericUpDown_0).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	private int int_0;

	private DataRow dataRow_0;

	private DataRow dataRow_1;

	private Label label_0;

	private ComboBox comboBox_0;

	private Class10 class10_0;

	private Label label_1;

	private TextBox textBox_0;

	private Label label_2;

	private DateTimePicker dateTimePicker_0;

	private Label wbdomltZnds;

	private NumericUpDown numericUpDown_0;

	private Label label_3;

	private ComboBox comboBox_1;

	private Label label_4;

	private RichTextBox richTextBox_0;

	private Button button_0;

	private Button button_1;
}
