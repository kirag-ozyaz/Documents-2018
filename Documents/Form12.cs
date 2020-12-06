using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DataSql;
using FormLbr;

internal partial class Form12 : FormBase
{
	internal Form12(bool bool_1, object object_0, SQLSettings sqlsettings_0)
	{
		
		
		this.method_0();
		this.SqlSettings = sqlsettings_0;
		this.bool_0 = bool_1;
		if (bool_1)
		{
			this.class568_0 = (Class548.Class568)((DataRowView)object_0).Row;
			if (this.class568_0.method_16())
			{
				if (!this.class568_0.method_42())
				{
					this.Text = this.class568_0.NoDogAbn;
				}
				else
				{
					this.Text = "";
				}
			}
			else if (!this.class568_0.method_20())
			{
				this.Text = this.class568_0.AbnObj;
			}
			else
			{
				this.Text = "";
			}
		}
		else
		{
			this.class572_0 = (Class548.Class572)((DataRowView)object_0).Row;
			if (!this.class572_0.method_2())
			{
				this.Text = this.class572_0.FIO;
				if (!this.class572_0.method_4())
				{
					this.Text = this.Text + ", " + this.class572_0.Address;
				}
			}
			else if (!this.class572_0.method_4())
			{
				this.Text = this.class572_0.Address;
			}
		}
		this.class597_0.SqlConnection_0.ConnectionString = this.SqlSettings.GetConnectionString();
		this.class590_0.SqlConnection_0.ConnectionString = this.SqlSettings.GetConnectionString();
		this.class598_0.SqlConnection_0.ConnectionString = this.SqlSettings.GetConnectionString();
	}

	private void Form12_Load(object sender, EventArgs e)
	{
		this.class597_0.vmethod_0(this.class548_0.NetArea);
		string string_ = string.Empty;
		int netAreaExec;
		if (this.bool_0)
		{
			if (this.class568_0.method_24())
			{
				this.checkBox_0.Checked = false;
				if (!this.class568_0.method_28())
				{
					this.textBox_0.Text = this.class568_0.ReasonFailure;
				}
			}
			else
			{
				this.checkBox_0.Checked = true;
				if (!this.class568_0.method_24())
				{
					this.dateTimePicker_0.Value = this.class568_0.DateExec;
				}
			}
			if (this.class568_0.method_26())
			{
				this.comboBox_0.SelectedIndex = 0;
				this.class568_0.NetAreaExec = (int)this.comboBox_0.SelectedValue;
				this.checkBox_1.Checked = false;
			}
			else
			{
				this.comboBox_0.SelectedValue = this.class568_0.NetAreaExec;
				this.class568_0.NetAreaExec = (int)this.comboBox_0.SelectedValue;
				this.comboBox_1.SelectedValue = this.class568_0.FIOExec;
				this.checkBox_1.Checked = true;
			}
			netAreaExec = this.class568_0.NetAreaExec;
			if (!this.class568_0.method_12())
			{
				this.textBox_1.Text = this.class568_0.Comments;
			}
			if (!this.class568_0.method_46())
			{
				this.checkBox_2.Checked = this.class568_0.Matrix;
			}
			else
			{
				this.checkBox_2.Checked = false;
			}
		}
		else
		{
			if (this.class572_0.method_28())
			{
				this.checkBox_0.Checked = false;
				if (!this.class572_0.method_33())
				{
					this.textBox_0.Text = this.class572_0.ReasonFailure;
				}
			}
			else
			{
				this.checkBox_0.Checked = true;
				if (!this.class572_0.method_28())
				{
					this.dateTimePicker_0.Value = this.class572_0.DateExec;
				}
			}
			if (this.class572_0.method_30())
			{
				this.comboBox_0.SelectedIndex = 0;
				this.class572_0.NetAreaExec = (int)this.comboBox_0.SelectedValue;
				this.checkBox_1.Checked = false;
			}
			else
			{
				this.comboBox_0.SelectedValue = this.class572_0.NetAreaExec;
				this.class572_0.NetAreaExec = (int)this.comboBox_0.SelectedValue;
				this.comboBox_1.SelectedValue = this.class572_0.FioExec;
				this.checkBox_1.Checked = true;
			}
			netAreaExec = this.class572_0.NetAreaExec;
			if (!this.class572_0.method_12())
			{
				this.textBox_1.Text = this.class572_0.Comments;
			}
			if (!this.class572_0.method_43())
			{
				this.checkBox_2.Checked = this.class572_0.Matrix;
			}
			else
			{
				this.checkBox_2.Checked = false;
			}
		}
		switch (netAreaExec)
		{
		case 23:
			string_ = ";GroupWorker;PersonApplDiscon;Performer;NA1;";
			break;
		case 24:
			string_ = ";GroupWorker;PersonApplDiscon;Performer;NA2;";
			break;
		case 25:
			string_ = ";GroupWorker;PersonApplDiscon;Performer;NA3;";
			break;
		case 26:
			break;
		case 27:
			string_ = ";GroupWorker;PersonApplDiscon;Performer;NA4;";
			break;
		default:
			if (netAreaExec == 41)
			{
				string_ = ";GroupWorker;PersonApplDiscon;Performer;DispDep;";
			}
			break;
		}
		this.class598_0.vmethod_2(this.class548_0.tR_Worker, string_);
	}

	private void checkBox_1_CheckedChanged(object sender, EventArgs e)
	{
		this.groupBox_0.Enabled = this.checkBox_1.Checked;
	}

	private void checkBox_0_CheckedChanged(object sender, EventArgs e)
	{
		this.groupBox_1.Enabled = this.checkBox_0.Checked;
		this.groupBox_2.Enabled = !this.checkBox_0.Checked;
	}

	private void comboBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		string string_ = string.Empty;
		int num = (int)this.comboBox_0.SelectedValue;
		switch (num)
		{
		case 23:
			string_ = ";GroupWorker;PersonApplDiscon;Performer;NA1;";
			break;
		case 24:
			string_ = ";GroupWorker;PersonApplDiscon;Performer;NA2;";
			break;
		case 25:
			string_ = ";GroupWorker;PersonApplDiscon;Performer;NA3;";
			break;
		case 26:
			break;
		case 27:
			string_ = ";GroupWorker;PersonApplDiscon;Performer;NA4;";
			break;
		default:
			if (num == 41)
			{
				string_ = ";GroupWorker;PersonApplDiscon;Performer;DispDep;";
			}
			break;
		}
		if (this.bool_0)
		{
			this.class568_0.NetAreaExec = (int)this.comboBox_0.SelectedValue;
		}
		else
		{
			this.class572_0.NetAreaExec = (int)this.comboBox_0.SelectedValue;
		}
		this.class598_0.vmethod_2(this.class548_0.tR_Worker, string_);
	}

	private void Form12_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (base.DialogResult == DialogResult.OK)
		{
			if (this.bool_0)
			{
				this.class568_0.Comments = this.textBox_1.Text;
				if (this.checkBox_1.Checked)
				{
					this.class568_0.NetAreaExec = (int)this.comboBox_0.SelectedValue;
					this.class568_0.FIOExec = (int)this.comboBox_1.SelectedValue;
				}
				else
				{
					this.class568_0.method_31();
					this.class568_0.method_27();
				}
				if (this.checkBox_0.Checked)
				{
					this.class568_0.DateExec = this.dateTimePicker_0.Value;
					this.class568_0.method_29();
				}
				else
				{
					this.class568_0.ReasonFailure = this.textBox_0.Text;
					this.class568_0.method_25();
				}
				this.class568_0.Matrix = this.checkBox_2.Checked;
				this.class568_0.EndEdit();
				return;
			}
			this.class572_0.Comments = this.textBox_1.Text;
			if (this.checkBox_1.Checked)
			{
				this.class572_0.NetAreaExec = (int)this.comboBox_0.SelectedValue;
				this.class572_0.FioExec = (int)this.comboBox_1.SelectedValue;
			}
			else
			{
				this.class572_0.method_32();
				this.class572_0.XbjWtsSwil5();
			}
			if (this.checkBox_0.Checked)
			{
				this.class572_0.DateExec = this.dateTimePicker_0.Value;
				this.class572_0.method_34();
			}
			else
			{
				this.class572_0.ReasonFailure = this.textBox_0.Text;
				this.class572_0.method_29();
			}
			this.class572_0.Matrix = this.checkBox_2.Checked;
			this.class572_0.EndEdit();
			return;
		}
		else
		{
			if (this.bool_0)
			{
				this.class568_0.CancelEdit();
				return;
			}
			this.class572_0.CancelEdit();
			return;
		}
	}

	private void checkBox_0_EnabledChanged(object sender, EventArgs e)
	{
	}

	private void textBox_0_TextChanged(object sender, EventArgs e)
	{
	}

	private void method_0()
	{
		this.TxhAgYeciA = new Container();
		this.class548_0 = new Class548();
		this.bindingSource_0 = new BindingSource(this.TxhAgYeciA);
		this.class586_0 = new Class586();
		this.bindingSource_1 = new BindingSource(this.TxhAgYeciA);
		this.class590_0 = new Class590();
		this.groupBox_0 = new GroupBox();
		this.label_0 = new Label();
		this.label_1 = new Label();
		this.comboBox_1 = new ComboBox();
		this.bindingSource_3 = new BindingSource(this.TxhAgYeciA);
		this.comboBox_0 = new ComboBox();
		this.bindingSource_2 = new BindingSource(this.TxhAgYeciA);
		this.groupBox_1 = new GroupBox();
		this.dateTimePicker_0 = new DateTimePicker();
		this.checkBox_0 = new CheckBox();
		this.class597_0 = new Class597();
		this.button_0 = new Button();
		this.button_1 = new Button();
		this.class598_0 = new Class598();
		this.groupBox_2 = new GroupBox();
		this.textBox_0 = new TextBox();
		this.groupBox_3 = new GroupBox();
		this.textBox_1 = new TextBox();
		this.checkBox_1 = new CheckBox();
		this.checkBox_2 = new CheckBox();
		this.class598_1 = new Class598();
		((ISupportInitialize)this.class548_0).BeginInit();
		((ISupportInitialize)this.bindingSource_0).BeginInit();
		((ISupportInitialize)this.bindingSource_1).BeginInit();
		this.groupBox_0.SuspendLayout();
		((ISupportInitialize)this.bindingSource_3).BeginInit();
		((ISupportInitialize)this.bindingSource_2).BeginInit();
		this.groupBox_1.SuspendLayout();
		this.groupBox_2.SuspendLayout();
		this.groupBox_3.SuspendLayout();
		base.SuspendLayout();
		this.class548_0.DataSetName = "OrgDataSet";
		this.class548_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		this.bindingSource_0.DataMember = "tblAbnAplForDisconObjects";
		this.bindingSource_0.DataSource = this.class548_0;
		this.class586_0.Boolean_0 = true;
		this.bindingSource_1.DataMember = "tblAbnAplForDisconIndividualUsers";
		this.bindingSource_1.DataSource = this.class548_0;
		this.class590_0.Boolean_0 = true;
		this.groupBox_0.Controls.Add(this.label_0);
		this.groupBox_0.Controls.Add(this.label_1);
		this.groupBox_0.Controls.Add(this.comboBox_1);
		this.groupBox_0.Controls.Add(this.comboBox_0);
		this.groupBox_0.Dock = DockStyle.Top;
		this.groupBox_0.Enabled = false;
		this.groupBox_0.Location = new Point(0, 0);
		this.groupBox_0.Name = "groupBoxExecuter";
		this.groupBox_0.Size = new Size(534, 54);
		this.groupBox_0.TabIndex = 0;
		this.groupBox_0.TabStop = false;
		this.label_0.AutoSize = true;
		this.label_0.Location = new Point(268, 22);
		this.label_0.Name = "label2";
		this.label_0.Size = new Size(37, 13);
		this.label_0.TabIndex = 1;
		this.label_0.Text = "ФИО:";
		this.label_1.AutoSize = true;
		this.label_1.Location = new Point(12, 22);
		this.label_1.Name = "label1";
		this.label_1.Size = new Size(85, 13);
		this.label_1.TabIndex = 1;
		this.label_1.Text = "Сетевой район:";
		this.comboBox_1.DataSource = this.bindingSource_3;
		this.comboBox_1.DisplayMember = "FIO";
		this.comboBox_1.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_1.FormattingEnabled = true;
		this.comboBox_1.Location = new Point(322, 19);
		this.comboBox_1.Name = "comboBoxFIOExec";
		this.comboBox_1.Size = new Size(200, 21);
		this.comboBox_1.TabIndex = 0;
		this.comboBox_1.ValueMember = "id";
		this.bindingSource_3.DataMember = "tR_Worker";
		this.bindingSource_3.DataSource = this.class548_0;
		this.comboBox_0.DataSource = this.bindingSource_2;
		this.comboBox_0.DisplayMember = "Description";
		this.comboBox_0.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_0.FormattingEnabled = true;
		this.comboBox_0.Location = new Point(103, 19);
		this.comboBox_0.Name = "comboBoxNetAreaExec";
		this.comboBox_0.Size = new Size(146, 21);
		this.comboBox_0.TabIndex = 0;
		this.comboBox_0.ValueMember = "id";
		this.comboBox_0.SelectedIndexChanged += this.comboBox_0_SelectedIndexChanged;
		this.bindingSource_2.DataMember = "NetArea";
		this.bindingSource_2.DataSource = this.class548_0;
		this.groupBox_1.Controls.Add(this.dateTimePicker_0);
		this.groupBox_1.Dock = DockStyle.Top;
		this.groupBox_1.Enabled = false;
		this.groupBox_1.Location = new Point(0, 54);
		this.groupBox_1.Name = "groupBoxExecution";
		this.groupBox_1.Size = new Size(534, 49);
		this.groupBox_1.TabIndex = 0;
		this.groupBox_1.TabStop = false;
		this.dateTimePicker_0.CustomFormat = "dd.MM.yyyy HH:mm";
		this.dateTimePicker_0.Format = DateTimePickerFormat.Custom;
		this.dateTimePicker_0.Location = new Point(6, 21);
		this.dateTimePicker_0.Name = "dateTimePickerExec";
		this.dateTimePicker_0.ShowUpDown = true;
		this.dateTimePicker_0.Size = new Size(212, 20);
		this.dateTimePicker_0.TabIndex = 1;
		this.checkBox_0.AutoSize = true;
		this.checkBox_0.Location = new Point(9, 54);
		this.checkBox_0.Name = "checkBoxExecute";
		this.checkBox_0.Size = new Size(82, 17);
		this.checkBox_0.TabIndex = 1;
		this.checkBox_0.Text = "Исполнено";
		this.checkBox_0.UseVisualStyleBackColor = true;
		this.checkBox_0.CheckedChanged += this.checkBox_0_CheckedChanged;
		this.checkBox_0.EnabledChanged += this.checkBox_0_EnabledChanged;
		this.class597_0.Boolean_0 = true;
		this.button_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.button_0.DialogResult = DialogResult.Cancel;
		this.button_0.Location = new Point(447, 334);
		this.button_0.Name = "buttonCancel";
		this.button_0.Size = new Size(75, 23);
		this.button_0.TabIndex = 2;
		this.button_0.Text = "Отмена";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.button_1.DialogResult = DialogResult.OK;
		this.button_1.Location = new Point(366, 334);
		this.button_1.Name = "buttonOK";
		this.button_1.Size = new Size(75, 23);
		this.button_1.TabIndex = 2;
		this.button_1.Text = "Готово";
		this.button_1.UseVisualStyleBackColor = true;
		this.class598_0.Boolean_0 = true;
		this.groupBox_2.Controls.Add(this.textBox_0);
		this.groupBox_2.Dock = DockStyle.Top;
		this.groupBox_2.Location = new Point(0, 103);
		this.groupBox_2.Name = "groupBoxReasonFailure";
		this.groupBox_2.Size = new Size(534, 102);
		this.groupBox_2.TabIndex = 3;
		this.groupBox_2.TabStop = false;
		this.groupBox_2.Text = "Причина неисполнения";
		this.textBox_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_0.Location = new Point(8, 19);
		this.textBox_0.Multiline = true;
		this.textBox_0.Name = "textBoxReasonFailure";
		this.textBox_0.Size = new Size(521, 77);
		this.textBox_0.TabIndex = 0;
		this.textBox_0.TextChanged += this.textBox_0_TextChanged;
		this.groupBox_3.Controls.Add(this.textBox_1);
		this.groupBox_3.Dock = DockStyle.Top;
		this.groupBox_3.Location = new Point(0, 205);
		this.groupBox_3.Name = "groupBox1";
		this.groupBox_3.Size = new Size(534, 102);
		this.groupBox_3.TabIndex = 4;
		this.groupBox_3.TabStop = false;
		this.groupBox_3.Text = "Примечание";
		this.textBox_1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_1.Location = new Point(8, 19);
		this.textBox_1.Multiline = true;
		this.textBox_1.Name = "textBoxComments";
		this.textBox_1.Size = new Size(521, 77);
		this.textBox_1.TabIndex = 0;
		this.checkBox_1.AutoSize = true;
		this.checkBox_1.Location = new Point(10, 0);
		this.checkBox_1.Name = "checkBoxExecuter";
		this.checkBox_1.Size = new Size(93, 17);
		this.checkBox_1.TabIndex = 5;
		this.checkBox_1.Text = "Исполнитель";
		this.checkBox_1.UseVisualStyleBackColor = true;
		this.checkBox_1.CheckedChanged += this.checkBox_1_CheckedChanged;
		this.checkBox_2.AutoSize = true;
		this.checkBox_2.Location = new Point(8, 313);
		this.checkBox_2.Name = "matrixCheckBox";
		this.checkBox_2.Size = new Size(176, 17);
		this.checkBox_2.TabIndex = 6;
		this.checkBox_2.Text = "Клиент подключен к Матрице";
		this.checkBox_2.UseVisualStyleBackColor = true;
		this.class598_1.Boolean_0 = true;
		base.AcceptButton = this.button_1;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = this.button_0;
		base.ClientSize = new Size(534, 369);
		base.Controls.Add(this.checkBox_2);
		base.Controls.Add(this.checkBox_1);
		base.Controls.Add(this.groupBox_3);
		base.Controls.Add(this.checkBox_0);
		base.Controls.Add(this.groupBox_2);
		base.Controls.Add(this.groupBox_1);
		base.Controls.Add(this.groupBox_0);
		base.Controls.Add(this.button_1);
		base.Controls.Add(this.button_0);
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "FormODSEdit";
		this.Text = "FormODSEdit";
		base.FormClosing += this.Form12_FormClosing;
		base.Load += this.Form12_Load;
		((ISupportInitialize)this.class548_0).EndInit();
		((ISupportInitialize)this.bindingSource_0).EndInit();
		((ISupportInitialize)this.bindingSource_1).EndInit();
		this.groupBox_0.ResumeLayout(false);
		this.groupBox_0.PerformLayout();
		((ISupportInitialize)this.bindingSource_3).EndInit();
		((ISupportInitialize)this.bindingSource_2).EndInit();
		this.groupBox_1.ResumeLayout(false);
		this.groupBox_2.ResumeLayout(false);
		this.groupBox_2.PerformLayout();
		this.groupBox_3.ResumeLayout(false);
		this.groupBox_3.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	internal static void DE0ZgsbSPhiHtFrOsvg(Form form_0, bool bool_1)
	{
		form_0.Dispose(bool_1);
	}

	private bool bool_0;

	private Class548.Class572 class572_0;

	private Class548.Class568 class568_0;

	private Class548 class548_0;

	private BindingSource bindingSource_0;

	private Class586 class586_0;

	private BindingSource bindingSource_1;

	private Class590 class590_0;

	private GroupBox groupBox_0;

	private GroupBox groupBox_1;

	private CheckBox checkBox_0;

	private ComboBox comboBox_0;

	private DateTimePicker dateTimePicker_0;

	private BindingSource bindingSource_2;

	private Class597 class597_0;

	private ComboBox comboBox_1;

	private Button button_0;

	private Button button_1;

	private BindingSource bindingSource_3;

	private Class598 class598_0;

	private GroupBox groupBox_2;

	private TextBox textBox_0;

	private Label label_0;

	private Label label_1;

	private GroupBox groupBox_3;

	private TextBox textBox_1;

	private CheckBox checkBox_1;

	private CheckBox checkBox_2;

	private Class598 class598_1;
}
