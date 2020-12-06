using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DataSql;
using FormLbr;

internal partial class Form10 : FormBase
{
	internal Form10(int int_1, SQLSettings sqlsettings_0)
	{
		
		
		this.method_0();
		this.SqlSettings = sqlsettings_0;
		this.int_0 = int_1;
		this.class593_0.SqlConnection_0.ConnectionString = this.SqlSettings.GetConnectionString();
		this.class591_0.SqlConnection_0.ConnectionString = this.SqlSettings.GetConnectionString();
		this.class594_0.SqlConnection_0.ConnectionString = this.SqlSettings.GetConnectionString();
		this.class590_0.SqlConnection_0.ConnectionString = this.SqlSettings.GetConnectionString();
		this.class587_0.SqlConnection_0.ConnectionString = this.SqlSettings.GetConnectionString();
	}

	private void Form10_Load(object sender, EventArgs e)
	{
		this.class594_0.vmethod_0(this.class548_0.tblAbnAplConnectPointForIndividualUsers);
		this.class587_0.vmethod_0(this.class548_0.tblAbnAplForDisconReason, new int?(this.int_0));
	}

	private void maskedTextBox_0_TextChanged(object sender, EventArgs e)
	{
		new Class599();
		if (this.checkBox_1.Checked)
		{
			if (this.maskedTextBox_0.Text.Length > 0)
			{
				this.class591_0.vmethod_0(this.class548_0.tAbonent, Convert.ToInt32(this.maskedTextBox_0.Text));
				if (this.bindingSource_2.Count > 0)
				{
					Class548.Class573 @class = (Class548.Class573)((DataRowView)this.bindingSource_2[0]).Row;
					this.dateTimePicker_0.Value = @class.StartDate;
					this.textBox_1.Text = @class.FIO;
					this.textBox_2.Text = @class.Address;
					return;
				}
				this.dateTimePicker_0.Value = DateTime.Today;
				this.textBox_1.Text = string.Empty;
				this.textBox_2.Text = string.Empty;
				this.checkBox_2.Checked = false;
				this.checkBox_3.Checked = true;
				return;
			}
			else
			{
				this.class591_0.vmethod_0(this.class548_0.tAbonent, -1);
			}
		}
	}

	private void checkBox_1_CheckedChanged(object sender, EventArgs e)
	{
		this.textBox_1.ReadOnly = this.checkBox_1.Checked;
		this.textBox_2.ReadOnly = this.checkBox_1.Checked;
		this.checkBox_2.Enabled = !this.checkBox_1.Checked;
	}

	private void Form10_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (base.DialogResult == DialogResult.OK)
		{
			if (this.comboBox_0.SelectedIndex == -1)
			{
				string text = this.comboBox_0.Text;
				this.bindingSource_4.AddNew();
				((Class548.Class576)((DataRowView)this.bindingSource_4.Current).Row).Point = text;
				this.bindingSource_4.EndEdit();
				this.class594_0.vmethod_2(this.class548_0.tblAbnAplConnectPointForIndividualUsers);
				((Class548.Class572)((DataRowView)this.bindingSource_0.Current).Row).PlaceId = ((Class548.Class576)((DataRowView)this.bindingSource_4.Current).Row).Id;
			}
			if (this.comboBox_1.SelectedIndex == -1)
			{
				string text2 = this.comboBox_1.Text;
				this.bindingSource_1.AddNew();
				((Class548.Class569)((DataRowView)this.bindingSource_1.Current).Row).Reason = text2;
				((Class548.Class569)((DataRowView)this.bindingSource_1.Current).Row).IdTypeApl = this.int_0;
				this.bindingSource_1.EndEdit();
				this.class587_0.vmethod_2(this.class548_0.tblAbnAplForDisconReason);
				((Class548.Class572)((DataRowView)this.bindingSource_0.Current).Row).Reason = ((Class548.Class569)((DataRowView)this.bindingSource_1.Current).Row).Id;
			}
			((Class548.Class572)((DataRowView)this.bindingSource_0.Current).Row).Point = this.comboBox_0.Text;
			this.bindingSource_0.EndEdit();
			return;
		}
		this.bindingSource_0.CancelEdit();
	}

	private void method_0()
	{
		this.icontainer_0 = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form10));
		this.label_0 = new Label();
		this.label_1 = new Label();
		this.label_2 = new Label();
		this.label_3 = new Label();
		this.label_4 = new Label();
		this.checkBox_0 = new CheckBox();
		this.bindingSource_0 = new BindingSource(this.icontainer_0);
		this.class548_0 = new Class548();
		this.textBox_0 = new TextBox();
		this.button_0 = new Button();
		this.button_1 = new Button();
		this.maskedTextBox_0 = new MaskedTextBox();
		this.textBox_1 = new TextBox();
		this.textBox_2 = new TextBox();
		this.comboBox_0 = new ComboBox();
		this.bindingSource_4 = new BindingSource(this.icontainer_0);
		this.comboBox_1 = new ComboBox();
		this.bindingSource_1 = new BindingSource(this.icontainer_0);
		this.label_5 = new Label();
		this.checkBox_1 = new CheckBox();
		this.label_6 = new Label();
		this.dateTimePicker_0 = new DateTimePicker();
		this.class590_0 = new Class590();
		this.class587_0 = new Class587();
		this.bindingSource_2 = new BindingSource(this.icontainer_0);
		this.class591_0 = new Class591();
		this.bindingSource_3 = new BindingSource(this.icontainer_0);
		this.class593_0 = new Class593();
		this.class594_0 = new Class594();
		this.checkBox_2 = new CheckBox();
		this.checkBox_3 = new CheckBox();
		((ISupportInitialize)this.bindingSource_0).BeginInit();
		((ISupportInitialize)this.class548_0).BeginInit();
		((ISupportInitialize)this.bindingSource_4).BeginInit();
		((ISupportInitialize)this.bindingSource_1).BeginInit();
		((ISupportInitialize)this.bindingSource_2).BeginInit();
		((ISupportInitialize)this.bindingSource_3).BeginInit();
		base.SuspendLayout();
		this.label_0.AutoSize = true;
		this.label_0.Location = new Point(12, 9);
		this.label_0.Name = "label1";
		this.label_0.Size = new Size(26, 13);
		this.label_0.TabIndex = 0;
		this.label_0.Text = "Код";
		this.label_1.AutoSize = true;
		this.label_1.Location = new Point(12, 60);
		this.label_1.Name = "label2";
		this.label_1.Size = new Size(34, 13);
		this.label_1.TabIndex = 0;
		this.label_1.Text = "ФИО";
		this.label_2.AutoSize = true;
		this.label_2.Location = new Point(12, 83);
		this.label_2.Name = "label3";
		this.label_2.Size = new Size(38, 13);
		this.label_2.TabIndex = 0;
		this.label_2.Text = "Адрес";
		this.label_3.AutoSize = true;
		this.label_3.Location = new Point(12, 132);
		this.label_3.Name = "label4";
		this.label_3.Size = new Size(100, 13);
		this.label_3.TabIndex = 0;
		this.label_3.Text = "Пункт отключения";
		this.label_4.AutoSize = true;
		this.label_4.Location = new Point(12, 159);
		this.label_4.Name = "label5";
		this.label_4.Size = new Size(50, 13);
		this.label_4.TabIndex = 0;
		this.label_4.Text = "Причина";
		this.checkBox_0.AutoSize = true;
		this.checkBox_0.DataBindings.Add(new Binding("Checked", this.bindingSource_0, "IsNC", true));
		this.checkBox_0.Enabled = false;
		this.checkBox_0.Location = new Point(308, 34);
		this.checkBox_0.Name = "checkBox1";
		this.checkBox_0.Size = new Size(77, 17);
		this.checkBox_0.TabIndex = 1;
		this.checkBox_0.Text = "Заволжье";
		this.checkBox_0.UseVisualStyleBackColor = true;
		this.checkBox_0.Visible = false;
		this.bindingSource_0.DataMember = "tblAbnAplForDisconIndividualUsers";
		this.bindingSource_0.DataSource = this.class548_0;
		this.class548_0.DataSetName = "OrgDataSet";
		this.class548_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		this.textBox_0.DataBindings.Add(new Binding("Text", this.bindingSource_0, "Comments", true));
		this.textBox_0.Location = new Point(15, 219);
		this.textBox_0.MaxLength = 255;
		this.textBox_0.Multiline = true;
		this.textBox_0.Name = "textBoxComments";
		this.textBox_0.Size = new Size(393, 68);
		this.textBox_0.TabIndex = 2;
		this.button_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.button_0.DialogResult = DialogResult.Cancel;
		this.button_0.Location = new Point(330, 296);
		this.button_0.Name = "buttonCancel";
		this.button_0.Size = new Size(75, 23);
		this.button_0.TabIndex = 3;
		this.button_0.Text = "Отмена";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.button_1.DialogResult = DialogResult.OK;
		this.button_1.Location = new Point(249, 296);
		this.button_1.Name = "buttonOk";
		this.button_1.Size = new Size(75, 23);
		this.button_1.TabIndex = 3;
		this.button_1.Text = "Готово";
		this.button_1.UseVisualStyleBackColor = true;
		this.maskedTextBox_0.DataBindings.Add(new Binding("Text", this.bindingSource_0, "Code", true));
		this.maskedTextBox_0.Location = new Point(79, 6);
		this.maskedTextBox_0.Mask = "999999999";
		this.maskedTextBox_0.Name = "maskedTextBox1";
		this.maskedTextBox_0.Size = new Size(221, 20);
		this.maskedTextBox_0.TabIndex = 4;
		this.maskedTextBox_0.TextChanged += this.maskedTextBox_0_TextChanged;
		this.textBox_1.DataBindings.Add(new Binding("Text", this.bindingSource_0, "FIO", true));
		this.textBox_1.Location = new Point(79, 57);
		this.textBox_1.Name = "textBox1";
		this.textBox_1.Size = new Size(221, 20);
		this.textBox_1.TabIndex = 5;
		this.textBox_2.DataBindings.Add(new Binding("Text", this.bindingSource_0, "Address", true));
		this.textBox_2.Location = new Point(79, 80);
		this.textBox_2.Name = "textBox2";
		this.textBox_2.Size = new Size(221, 20);
		this.textBox_2.TabIndex = 5;
		this.comboBox_0.DataBindings.Add(new Binding("SelectedValue", this.bindingSource_0, "PlaceId", true));
		this.comboBox_0.DataSource = this.bindingSource_4;
		this.comboBox_0.DisplayMember = "Point";
		this.comboBox_0.FormattingEnabled = true;
		this.comboBox_0.Location = new Point(118, 129);
		this.comboBox_0.Name = "comboBox1";
		this.comboBox_0.Size = new Size(182, 21);
		this.comboBox_0.TabIndex = 6;
		this.comboBox_0.ValueMember = "Id";
		this.bindingSource_4.DataMember = "tblAbnAplConnectPointForIndividualUsers";
		this.bindingSource_4.DataSource = this.class548_0;
		this.comboBox_1.DataBindings.Add(new Binding("SelectedValue", this.bindingSource_0, "Reason", true));
		this.comboBox_1.DataSource = this.bindingSource_1;
		this.comboBox_1.DisplayMember = "Reason";
		this.comboBox_1.FormattingEnabled = true;
		this.comboBox_1.Location = new Point(118, 156);
		this.comboBox_1.Name = "comboBox2";
		this.comboBox_1.Size = new Size(182, 21);
		this.comboBox_1.TabIndex = 6;
		this.comboBox_1.ValueMember = "Id";
		this.bindingSource_1.DataMember = "tblAbnAplForDisconReason";
		this.bindingSource_1.DataSource = this.class548_0;
		this.label_5.AutoSize = true;
		this.label_5.Location = new Point(12, 203);
		this.label_5.Name = "label6";
		this.label_5.Size = new Size(70, 13);
		this.label_5.TabIndex = 0;
		this.label_5.Text = "Примечание";
		this.checkBox_1.AutoSize = true;
		this.checkBox_1.Location = new Point(308, 8);
		this.checkBox_1.Name = "checkBox2";
		this.checkBox_1.Size = new Size(110, 17);
		this.checkBox_1.TabIndex = 7;
		this.checkBox_1.Text = "Автозаполнение";
		this.checkBox_1.UseVisualStyleBackColor = true;
		this.checkBox_1.CheckedChanged += this.checkBox_1_CheckedChanged;
		this.label_6.AutoSize = true;
		this.label_6.Location = new Point(12, 35);
		this.label_6.Name = "label7";
		this.label_6.Size = new Size(33, 13);
		this.label_6.TabIndex = 0;
		this.label_6.Text = "Дата";
		this.dateTimePicker_0.DataBindings.Add(new Binding("Value", this.bindingSource_0, "DateDog", true));
		this.dateTimePicker_0.Location = new Point(79, 31);
		this.dateTimePicker_0.Name = "dateTimePicker1";
		this.dateTimePicker_0.Size = new Size(221, 20);
		this.dateTimePicker_0.TabIndex = 8;
		this.class590_0.Boolean_0 = true;
		this.class587_0.Boolean_0 = true;
		this.bindingSource_2.DataMember = "tAbonent";
		this.bindingSource_2.DataSource = this.class548_0;
		this.class591_0.Boolean_0 = true;
		this.bindingSource_3.DataMember = "tAbonentNC";
		this.bindingSource_3.DataSource = this.class548_0;
		this.class593_0.Boolean_0 = true;
		this.class594_0.Boolean_0 = true;
		this.checkBox_2.AutoSize = true;
		this.checkBox_2.Location = new Point(15, 106);
		this.checkBox_2.Name = "matrixСheckBox";
		this.checkBox_2.Size = new Size(181, 17);
		this.checkBox_2.TabIndex = 9;
		this.checkBox_2.Text = "Абонент подключён к матрице";
		this.checkBox_2.UseVisualStyleBackColor = true;
		this.checkBox_3.AutoSize = true;
		this.checkBox_3.DataBindings.Add(new Binding("Checked", this.bindingSource_0, "IsFullRestriction", true));
		this.checkBox_3.Location = new Point(15, 183);
		this.checkBox_3.Name = "cbFullRestriction";
		this.checkBox_3.Size = new Size(131, 17);
		this.checkBox_3.TabIndex = 9;
		this.checkBox_3.Text = "Полное ограничение";
		this.checkBox_3.UseVisualStyleBackColor = true;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(417, 331);
		base.Controls.Add(this.checkBox_3);
		base.Controls.Add(this.checkBox_2);
		base.Controls.Add(this.dateTimePicker_0);
		base.Controls.Add(this.checkBox_1);
		base.Controls.Add(this.comboBox_1);
		base.Controls.Add(this.comboBox_0);
		base.Controls.Add(this.textBox_2);
		base.Controls.Add(this.textBox_1);
		base.Controls.Add(this.maskedTextBox_0);
		base.Controls.Add(this.button_1);
		base.Controls.Add(this.button_0);
		base.Controls.Add(this.textBox_0);
		base.Controls.Add(this.checkBox_0);
		base.Controls.Add(this.label_5);
		base.Controls.Add(this.label_4);
		base.Controls.Add(this.label_3);
		base.Controls.Add(this.label_6);
		base.Controls.Add(this.label_2);
		base.Controls.Add(this.label_1);
		base.Controls.Add(this.label_0);
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "FormIndividualUser";
		base.PermissionsSql = false;
		this.Text = "Физическое лицо";
		base.FormClosing += this.Form10_FormClosing;
		base.Load += this.Form10_Load;
		((ISupportInitialize)this.bindingSource_0).EndInit();
		((ISupportInitialize)this.class548_0).EndInit();
		((ISupportInitialize)this.bindingSource_4).EndInit();
		((ISupportInitialize)this.bindingSource_1).EndInit();
		((ISupportInitialize)this.bindingSource_2).EndInit();
		((ISupportInitialize)this.bindingSource_3).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	private int int_0;

	private Label label_0;

	private Label label_1;

	private Label label_2;

	private Label label_3;

	private Label label_4;

	private CheckBox checkBox_0;

	private TextBox textBox_0;

	private Button button_0;

	private Button button_1;

	private MaskedTextBox maskedTextBox_0;

	private TextBox textBox_1;

	private TextBox textBox_2;

	private ComboBox comboBox_0;

	private ComboBox comboBox_1;

	private Label label_5;

	private Class548 class548_0;

	private Class590 class590_0;

	public BindingSource bindingSource_0;

	private BindingSource bindingSource_1;

	private Class587 class587_0;

	private CheckBox checkBox_1;

	private Label label_6;

	private DateTimePicker dateTimePicker_0;

	private BindingSource bindingSource_2;

	private Class591 class591_0;

	private BindingSource bindingSource_3;

	private Class593 class593_0;

	private BindingSource bindingSource_4;

	private Class594 class594_0;

	private CheckBox checkBox_2;

	private CheckBox checkBox_3;
}
