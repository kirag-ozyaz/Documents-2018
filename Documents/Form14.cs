using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using FormLbr;

internal partial class Form14 : FormBase
{
	internal Form14()
	{
		
		this.int_0 = -1;
		this.int_1 = -1;
		
		this.method_0();
	}

	internal Form14(int int_2, int int_3, bool bool_0)
	{
		
		this.int_0 = -1;
		this.int_1 = -1;
		
		this.method_0();
		this.int_0 = int_2;
		this.int_1 = int_3;
		this.Text = ((int_2 == -1) ? "Новый статус" : "Редактирование");
		this.dateTimePicker_0.Value = DateTime.Now.Date;
		if (!bool_0)
		{
			base.Height -= this.label_2.Height + this.comboBox_1.Height;
		}
		Control control = this.label_2;
		this.comboBox_1.Visible = bool_0;
		control.Visible = bool_0;
	}

	private void Form14_Load(object sender, EventArgs e)
	{
		base.SelectSqlData(this.class10_0, this.class10_0.tR_Classifier, true, " where ParentKey = ';TechConnect;RequestStatus;' and isGRoup = 0 and deleted = 0 order by name");
		Class10.Class14 @class = new Class10.Class14();
		base.SelectSqlData(@class, true, " where ParentKey = ';TechConnect;DocSendMode;' and isGRoup = 0 and deleted = 0 order by name", null, false, 0);
		this.comboBox_1.DataSource = @class;
		this.comboBox_1.DisplayMember = "Name";
		this.comboBox_1.ValueMember = "id";
		if (this.int_0 == -1)
		{
			DataRow dataRow = this.class10_0.tTC_DocStatus.NewRow();
			dataRow["idDoc"] = this.int_1;
			dataRow["DateChange"] = DateTime.Now.Date;
			dataRow["idStatus"] = -1;
			this.class10_0.tTC_DocStatus.Rows.Add(dataRow);
			return;
		}
		base.SelectSqlData(this.class10_0, this.class10_0.tTC_DocStatus, true, " where id = " + this.int_0.ToString());
	}

	private void Form14_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (base.DialogResult == DialogResult.OK)
		{
			if (this.comboBox_0.SelectedIndex < 0)
			{
				MessageBox.Show("Не выбран статус документа");
				e.Cancel = true;
				return;
			}
			this.class10_0.tTC_DocStatus.Rows[0].EndEdit();
			if (this.int_0 == -1)
			{
				this.int_0 = base.InsertSqlDataOneRow(this.class10_0, this.class10_0.tTC_DocStatus);
				return;
			}
			base.UpdateSqlData(this.class10_0, this.class10_0.tTC_DocStatus);
		}
	}

	private void method_0()
	{
		this.label_0 = new Label();
		this.dateTimePicker_0 = new DateTimePicker();
		this.class10_0 = new Class10();
		this.label_1 = new Label();
		this.comboBox_0 = new ComboBox();
		this.button_0 = new Button();
		this.button_1 = new Button();
		this.label_2 = new Label();
		this.comboBox_1 = new ComboBox();
		this.label_3 = new Label();
		this.textBox_0 = new TextBox();
		((ISupportInitialize)this.class10_0).BeginInit();
		base.SuspendLayout();
		this.label_0.AutoSize = true;
		this.label_0.Location = new Point(12, 9);
		this.label_0.Name = "label1";
		this.label_0.Size = new Size(33, 13);
		this.label_0.TabIndex = 0;
		this.label_0.Text = "Дата";
		this.dateTimePicker_0.DataBindings.Add(new Binding("Value", this.class10_0, "tTC_DocStatus.DateChange", true));
		this.dateTimePicker_0.Location = new Point(12, 25);
		this.dateTimePicker_0.Name = "dateTimePicker";
		this.dateTimePicker_0.Size = new Size(249, 20);
		this.dateTimePicker_0.TabIndex = 1;
		this.class10_0.DataSetName = "DataSetTechConnection";
		this.class10_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		this.label_1.AutoSize = true;
		this.label_1.Location = new Point(12, 48);
		this.label_1.Name = "label2";
		this.label_1.Size = new Size(41, 13);
		this.label_1.TabIndex = 2;
		this.label_1.Text = "Статус";
		this.comboBox_0.DataBindings.Add(new Binding("SelectedValue", this.class10_0, "tTC_DocStatus.idStatus", true));
		this.comboBox_0.DataSource = this.class10_0;
		this.comboBox_0.DisplayMember = "tR_Classifier.Name";
		this.comboBox_0.FormattingEnabled = true;
		this.comboBox_0.Location = new Point(12, 64);
		this.comboBox_0.Name = "cmbStatus";
		this.comboBox_0.Size = new Size(249, 21);
		this.comboBox_0.TabIndex = 3;
		this.comboBox_0.ValueMember = "tR_Classifier.Id";
		this.button_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.button_0.DialogResult = DialogResult.OK;
		this.button_0.Location = new Point(12, 232);
		this.button_0.Name = "buttonOK";
		this.button_0.Size = new Size(75, 23);
		this.button_0.TabIndex = 4;
		this.button_0.Text = "ОК";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.button_1.DialogResult = DialogResult.Cancel;
		this.button_1.Location = new Point(186, 232);
		this.button_1.Name = "buttonCancel";
		this.button_1.Size = new Size(75, 23);
		this.button_1.TabIndex = 5;
		this.button_1.Text = "Отмена";
		this.button_1.UseVisualStyleBackColor = true;
		this.label_2.AutoSize = true;
		this.label_2.Location = new Point(9, 88);
		this.label_2.Name = "labelSendMode";
		this.label_2.Size = new Size(94, 13);
		this.label_2.TabIndex = 6;
		this.label_2.Text = "Способ отправки";
		this.comboBox_1.DataBindings.Add(new Binding("SelectedValue", this.class10_0, "tTC_DocStatus.SendMode", true));
		this.comboBox_1.FormattingEnabled = true;
		this.comboBox_1.Location = new Point(12, 104);
		this.comboBox_1.Name = "cmbSendMode";
		this.comboBox_1.Size = new Size(249, 21);
		this.comboBox_1.TabIndex = 7;
		this.label_3.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.label_3.AutoSize = true;
		this.label_3.Location = new Point(12, 128);
		this.label_3.Name = "labelComment";
		this.label_3.Size = new Size(77, 13);
		this.label_3.TabIndex = 8;
		this.label_3.Text = "Комментарий";
		this.textBox_0.AcceptsReturn = true;
		this.textBox_0.AcceptsTab = true;
		this.textBox_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.textBox_0.DataBindings.Add(new Binding("Text", this.class10_0, "tTC_DocStatus.Comment", true));
		this.textBox_0.Location = new Point(12, 144);
		this.textBox_0.Multiline = true;
		this.textBox_0.Name = "txtComment";
		this.textBox_0.Size = new Size(249, 82);
		this.textBox_0.TabIndex = 9;
		base.AcceptButton = this.button_0;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = this.button_1;
		base.ClientSize = new Size(271, 267);
		base.Controls.Add(this.textBox_0);
		base.Controls.Add(this.label_3);
		base.Controls.Add(this.comboBox_1);
		base.Controls.Add(this.label_2);
		base.Controls.Add(this.button_1);
		base.Controls.Add(this.button_0);
		base.Controls.Add(this.comboBox_0);
		base.Controls.Add(this.label_1);
		base.Controls.Add(this.dateTimePicker_0);
		base.Controls.Add(this.label_0);
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "FormTechConnectionAddEditRequestStatus";
		this.Text = "FormTechConnectionAddEditRequestStatus";
		base.FormClosing += this.Form14_FormClosing;
		base.Load += this.Form14_Load;
		((ISupportInitialize)this.class10_0).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	internal static void ChjsCqhLwZd5Zn1W8VD(Form form_0, bool bool_0)
	{
		form_0.Dispose(bool_0);
	}

	private int int_0;

	private int int_1;

	private Label label_0;

	private DateTimePicker dateTimePicker_0;

	private Class10 class10_0;

	private Label label_1;

	private ComboBox comboBox_0;

	private Button button_0;

	private Button button_1;

	private Label label_2;

	private ComboBox comboBox_1;

	private Label label_3;

	private TextBox textBox_0;
}
