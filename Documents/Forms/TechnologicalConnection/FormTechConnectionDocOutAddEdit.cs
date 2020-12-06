using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ControlsLbr;
using FormLbr;

namespace Documents.Forms.TechnologicalConnection
{
	public partial class FormTechConnectionDocOutAddEdit : FormBase
	{
		public int IdDocOut
		{
			get
			{
				return this.int_0;
			}
		}

		public FormTechConnectionDocOutAddEdit()
		{
			
			this.int_0 = -1;
			this.int_1 = -1;
			
			this.method_2();
		}

		public FormTechConnectionDocOutAddEdit(int id, int idDoc)
		{
			
			this.int_0 = -1;
			this.int_1 = -1;
			
			this.method_2();
			this.int_0 = id;
			this.int_1 = idDoc;
			this.Text = ((id == -1) ? "Новый документ" : "Редактирование");
			this.nullableDateTimePicker_0.Value = DateTime.Now.Date;
		}

		private void method_0()
		{
			Class10.Class14 @class = new Class10.Class14();
			base.SelectSqlData(@class, true, string.Concat(new string[]
			{
				" where id in (",
				1124.ToString(),
				",",
				1151.ToString(),
				",",
				1152.ToString(),
				",",
				1153.ToString(),
				",",
				1154.ToString(),
				",",
				1155.ToString(),
				",",
				2255.ToString(),
				") order by name"
			}), null, false, 0);
			if (this.int_1 != -1)
			{
				DataTable dataTable = base.SelectSqlData("tTC_Doc", true, "where id = " + this.int_1.ToString());
				if (dataTable.Rows.Count > 0)
				{
					int num = Convert.ToInt32(dataTable.Rows[0]["TypeDoc"]);
					if (num == 1220)
					{
						base.SelectSqlData(@class, true, string.Concat(new string[]
						{
							" where id in (",
							1124.ToString(),
							",",
							1125.ToString(),
							",",
							1151.ToString(),
							",",
							1152.ToString(),
							",",
							1153.ToString(),
							",",
							1154.ToString(),
							",",
							1218.ToString(),
							",",
							1155.ToString(),
							",",
							1237.ToString(),
							") order by name"
						}), null, false, 0);
					}
				}
			}
			this.comboBox_0.DataSource = @class;
			this.comboBox_0.DisplayMember = "Name";
			this.comboBox_0.ValueMember = "id";
			Class10.Class14 class2 = new Class10.Class14();
			base.SelectSqlData(class2, true, " where ParentKey = ';TechConnect;DocOutStatus;' and isGRoup = 0 and deleted = 0 order by name", null, false, 0);
			this.comboBox_1.DataSource = class2;
			this.comboBox_1.DisplayMember = "Name";
			this.comboBox_1.ValueMember = "id";
			Class10.Class14 class3 = new Class10.Class14();
			base.SelectSqlData(class3, true, " where ParentKey = ';TechConnect;DocSendMode;' and isGRoup = 0 and deleted = 0 order by name", null, false, 0);
			this.comboBox_2.DataSource = class3;
			this.comboBox_2.DisplayMember = "Name";
			this.comboBox_2.ValueMember = "id";
		}

		private void method_1()
		{
			DataRow dataRow = this.class10_0.tTC_Doc.NewRow();
			dataRow["TypeDoc"] = -1;
			this.class10_0.tTC_Doc.Rows.Add(dataRow);
		}

		private void FormTechConnectionDocOutAddEdit_Load(object sender, EventArgs e)
		{
			this.method_0();
			if (this.int_0 == -1)
			{
				this.method_1();
				DataRow dataRow = this.class10_0.tTC_DocOut.NewRow();
				dataRow["idDoc"] = this.int_1;
				dataRow["idDocOut"] = this.class10_0.tTC_Doc.Rows[0]["id"];
				this.class10_0.tTC_DocOut.Rows.Add(dataRow);
				return;
			}
			base.SelectSqlData(this.class10_0, this.class10_0.tTC_DocOut, true, "where id = " + this.int_0.ToString());
			if (this.class10_0.tTC_DocOut.Rows.Count > 0)
			{
				base.SelectSqlData(this.class10_0, this.class10_0.tTC_Doc, true, " where id = " + this.class10_0.tTC_DocOut.Rows[0]["idDocOut"].ToString());
			}
		}

		private void FormTechConnectionDocOutAddEdit_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (base.DialogResult == DialogResult.OK)
			{
				if (this.comboBox_0.SelectedIndex < 0)
				{
					MessageBox.Show("Не выбран тип документа");
					e.Cancel = true;
					return;
				}
				if (this.int_0 == -1)
				{
					this.class10_0.tTC_Doc.Rows[0].EndEdit();
					int num = base.InsertSqlDataOneRow(this.class10_0, this.class10_0.tTC_Doc);
					this.class10_0.tTC_DocOut.Rows[0]["idDocOut"] = num;
					this.class10_0.tTC_DocOut.Rows[0].EndEdit();
					this.int_0 = base.InsertSqlDataOneRow(this.class10_0, this.class10_0.tTC_DocOut);
					return;
				}
				this.class10_0.tTC_Doc.Rows[0].EndEdit();
				base.UpdateSqlData(this.class10_0, this.class10_0.tTC_Doc);
				this.class10_0.tTC_DocOut.Rows[0].EndEdit();
				base.UpdateSqlData(this.class10_0, this.class10_0.tTC_DocOut);
			}
		}

		private void method_2()
		{
			this.label_0 = new Label();
			this.comboBox_0 = new ComboBox();
			this.class10_0 = new Class10();
			this.label_1 = new Label();
			this.textBox_0 = new TextBox();
			this.nullableDateTimePicker_0 = new NullableDateTimePicker();
			this.button_0 = new Button();
			this.button_1 = new Button();
			this.label_2 = new Label();
			this.comboBox_1 = new ComboBox();
			this.label_3 = new Label();
			this.comboBox_2 = new ComboBox();
			this.label_4 = new Label();
			this.numericUpDown_0 = new NumericUpDown();
			this.label_5 = new Label();
			this.textBox_1 = new TextBox();
			this.label_6 = new Label();
			this.textBox_2 = new TextBox();
			((ISupportInitialize)this.class10_0).BeginInit();
			((ISupportInitialize)this.numericUpDown_0).BeginInit();
			base.SuspendLayout();
			this.label_0.AutoSize = true;
			this.label_0.Location = new Point(12, 9);
			this.label_0.Name = "label1";
			this.label_0.Size = new Size(141, 13);
			this.label_0.TabIndex = 0;
			this.label_0.Text = "Тип выданного документа";
			this.comboBox_0.DataBindings.Add(new Binding("SelectedValue", this.class10_0, "tTC_Doc.TypeDoc", true));
			this.comboBox_0.FormattingEnabled = true;
			this.comboBox_0.Location = new Point(12, 25);
			this.comboBox_0.Name = "cmbTypeDocOut";
			this.comboBox_0.Size = new Size(293, 21);
			this.comboBox_0.TabIndex = 1;
			this.class10_0.DataSetName = "DataSetTechConnection";
			this.class10_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
			this.label_1.AutoSize = true;
			this.label_1.Location = new Point(12, 49);
			this.label_1.Name = "label2";
			this.label_1.Size = new Size(191, 13);
			this.label_1.TabIndex = 2;
			this.label_1.Text = "Номер и дата выданного документа";
			this.textBox_0.DataBindings.Add(new Binding("Text", this.class10_0, "tTC_Doc.numDoc", true));
			this.textBox_0.Location = new Point(12, 65);
			this.textBox_0.Name = "txtNumDocOut";
			this.textBox_0.Size = new Size(128, 20);
			this.textBox_0.TabIndex = 3;
			this.nullableDateTimePicker_0.DataBindings.Add(new Binding("Value", this.class10_0, "tTC_Doc.dateDoc", true));
			this.nullableDateTimePicker_0.Location = new Point(146, 65);
			this.nullableDateTimePicker_0.Name = "dateTimePickerDocOut";
			this.nullableDateTimePicker_0.Size = new Size(159, 20);
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
			this.label_2.AutoSize = true;
			this.label_2.Location = new Point(218, 9);
			this.label_2.Name = "label3";
			this.label_2.Size = new Size(98, 13);
			this.label_2.TabIndex = 13;
			this.label_2.Text = "Статус документа";
			this.label_2.Visible = false;
			this.comboBox_1.DataBindings.Add(new Binding("SelectedValue", this.class10_0, "tTC_DocOut.idStatus", true));
			this.comboBox_1.FormattingEnabled = true;
			this.comboBox_1.Location = new Point(230, 1);
			this.comboBox_1.Name = "cmbDocOutStatus";
			this.comboBox_1.Size = new Size(39, 21);
			this.comboBox_1.TabIndex = 14;
			this.comboBox_1.Visible = false;
			this.label_3.AutoSize = true;
			this.label_3.Location = new Point(111, 301);
			this.label_3.Name = "label4";
			this.label_3.Size = new Size(94, 13);
			this.label_3.TabIndex = 15;
			this.label_3.Text = "Способ отправки";
			this.label_3.Visible = false;
			this.comboBox_2.DataBindings.Add(new Binding("SelectedValue", this.class10_0, "tTC_DocOut.SendMode", true));
			this.comboBox_2.FormattingEnabled = true;
			this.comboBox_2.Location = new Point(123, 306);
			this.comboBox_2.Name = "cmbSendMode";
			this.comboBox_2.Size = new Size(42, 21);
			this.comboBox_2.TabIndex = 16;
			this.comboBox_2.Visible = false;
			this.label_4.AutoSize = true;
			this.label_4.Location = new Point(12, 171);
			this.label_4.Name = "label5";
			this.label_4.Size = new Size(99, 13);
			this.label_4.TabIndex = 7;
			this.label_4.Text = "Количество копий";
			this.numericUpDown_0.DataBindings.Add(new Binding("Value", this.class10_0, "tTC_DocOut.number", true));
			this.numericUpDown_0.Location = new Point(12, 187);
			this.numericUpDown_0.Name = "numericUpDown";
			this.numericUpDown_0.Size = new Size(293, 20);
			this.numericUpDown_0.TabIndex = 8;
			this.numericUpDown_0.TextAlign = HorizontalAlignment.Right;
			this.label_5.AutoSize = true;
			this.label_5.Location = new Point(12, 210);
			this.label_5.Name = "label6";
			this.label_5.Size = new Size(77, 13);
			this.label_5.TabIndex = 9;
			this.label_5.Text = "Комментарий";
			this.textBox_1.AcceptsReturn = true;
			this.textBox_1.AcceptsTab = true;
			this.textBox_1.DataBindings.Add(new Binding("Text", this.class10_0, "tTC_DocOut.comment", true));
			this.textBox_1.Location = new Point(12, 226);
			this.textBox_1.Multiline = true;
			this.textBox_1.Name = "txtComment";
			this.textBox_1.Size = new Size(293, 64);
			this.textBox_1.TabIndex = 10;
			this.label_6.AutoSize = true;
			this.label_6.Location = new Point(12, 88);
			this.label_6.Name = "label7";
			this.label_6.Size = new Size(70, 13);
			this.label_6.TabIndex = 5;
			this.label_6.Text = "Содержание";
			this.textBox_2.AcceptsReturn = true;
			this.textBox_2.AcceptsTab = true;
			this.textBox_2.DataBindings.Add(new Binding("Text", this.class10_0, "tTC_Doc.Body", true));
			this.textBox_2.Location = new Point(12, 104);
			this.textBox_2.Multiline = true;
			this.textBox_2.Name = "txtBody";
			this.textBox_2.Size = new Size(293, 64);
			this.textBox_2.TabIndex = 6;
			base.AcceptButton = this.button_0;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.CancelButton = this.button_1;
			base.ClientSize = new Size(309, 330);
			base.Controls.Add(this.textBox_2);
			base.Controls.Add(this.label_6);
			base.Controls.Add(this.textBox_1);
			base.Controls.Add(this.label_5);
			base.Controls.Add(this.numericUpDown_0);
			base.Controls.Add(this.label_4);
			base.Controls.Add(this.comboBox_2);
			base.Controls.Add(this.label_3);
			base.Controls.Add(this.comboBox_1);
			base.Controls.Add(this.label_2);
			base.Controls.Add(this.button_1);
			base.Controls.Add(this.button_0);
			base.Controls.Add(this.nullableDateTimePicker_0);
			base.Controls.Add(this.textBox_0);
			base.Controls.Add(this.label_1);
			base.Controls.Add(this.comboBox_0);
			base.Controls.Add(this.label_0);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "FormTechConnectionDocOutAddEdit";
			this.Text = "FormTechConnectionDocOutAddEdit";
			base.FormClosing += this.FormTechConnectionDocOutAddEdit_FormClosing;
			base.Load += this.FormTechConnectionDocOutAddEdit_Load;
			((ISupportInitialize)this.class10_0).EndInit();
			((ISupportInitialize)this.numericUpDown_0).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		internal static void Yg3MS1hDRj2SatlqAvS(Form form_0, bool bool_0)
		{
			form_0.Dispose(bool_0);
		}

		private int int_0;

		private int int_1;

		private Label label_0;

		private ComboBox comboBox_0;

		private Label label_1;

		private TextBox textBox_0;

		private NullableDateTimePicker nullableDateTimePicker_0;

		private Class10 class10_0;

		private Button button_0;

		private Button button_1;

		private Label label_2;

		private ComboBox comboBox_1;

		private Label label_3;

		private ComboBox comboBox_2;

		private Label label_4;

		private NumericUpDown numericUpDown_0;

		private Label label_5;

		private TextBox textBox_1;

		private Label label_6;

		private TextBox textBox_2;
	}
}
