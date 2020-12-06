using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Constants;
using ControlsLbr;
using FormLbr;

internal partial class Form33 : FormBase
{
	internal int Id { get; set; }

	[CompilerGenerated]
	internal int method_0()
	{
		return this.int_1;
	}

	[CompilerGenerated]
	internal void method_1(int int_2)
	{
		this.int_1 = int_2;
	}

	[CompilerGenerated]
	internal StateFormCreate method_2()
	{
		return this.stateFormCreate_0;
	}

	[CompilerGenerated]
	internal void method_3(StateFormCreate stateFormCreate_1)
	{
		this.stateFormCreate_0 = stateFormCreate_1;
	}

	internal Form33()
	{
		
		
		this.method_5();
	}

	private void Form33_Load(object sender, EventArgs e)
	{
		this.method_4();
		StateFormCreate stateFormCreate = this.method_2();
		if (stateFormCreate == StateFormCreate.Add)
		{
			this.Text = "Добавление пользователя";
			Class255.Class466 @class = this.class255_0.tJ_BossUser.method_5();
			@class.idGroup = this.method_0();
			@class.Deleted = false;
			this.class255_0.tJ_BossUser.method_0(@class);
			return;
		}
		if (stateFormCreate == StateFormCreate.Edit)
		{
			this.Text = "Редактирование пользователя";
			this.button_0.Text = "Сохранить";
			base.SelectSqlData(this.class255_0, this.class255_0.tJ_BossUser, true, "WHERE id = " + this.Id.ToString());
			return;
		}
		if (stateFormCreate != StateFormCreate.View)
		{
			return;
		}
		this.Text = "Просмотр пользователя";
		base.SelectSqlData(this.class255_0, this.class255_0.tJ_BossUser, true, "WHERE id = " + this.Id.ToString());
		this.textBox_0.ReadOnly = true;
		this.textBox_1.ReadOnly = true;
		this.textBox_2.ReadOnly = true;
		this.textBox_3.ReadOnly = true;
		this.textBox_4.ReadOnly = true;
		this.comboBoxReadOnly_0.ReadOnly = true;
		this.button_0.Visible = false;
	}

	private void method_4()
	{
		base.SelectSqlData(this.class255_0, this.class255_0.vJ_Worker, true, "WHERE DateEnd IS NULL ORDER BY FIO");
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		this.class255_0.tJ_BossUser.Rows[0].EndEdit();
		if (this.method_2() == StateFormCreate.Add)
		{
			this.Id = base.InsertSqlDataOneRow(this.class255_0.tJ_BossUser.Rows[0]);
		}
		else
		{
			base.UpdateSqlDataOnlyChange(this.class255_0.tJ_BossUser);
		}
		base.Close();
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		base.Close();
	}

	private void method_5()
	{
		this.icontainer_0 = new Container();
		this.textBox_0 = new TextBox();
		this.bindingSource_0 = new BindingSource(this.icontainer_0);
		this.class255_0 = new Class255();
		this.textBox_1 = new TextBox();
		this.textBox_2 = new TextBox();
		this.textBox_3 = new TextBox();
		this.button_0 = new Button();
		this.button_1 = new Button();
		this.label_0 = new Label();
		this.label_1 = new Label();
		this.label_2 = new Label();
		this.label_3 = new Label();
		this.textBox_4 = new TextBox();
		this.bindingSource_1 = new BindingSource(this.icontainer_0);
		this.label_4 = new Label();
		this.label_5 = new Label();
		this.comboBoxReadOnly_0 = new ComboBoxReadOnly();
		((ISupportInitialize)this.bindingSource_0).BeginInit();
		((ISupportInitialize)this.class255_0).BeginInit();
		((ISupportInitialize)this.bindingSource_1).BeginInit();
		base.SuspendLayout();
		this.textBox_0.DataBindings.Add(new Binding("Text", this.bindingSource_0, "FirstName", true));
		this.textBox_0.Location = new Point(140, 12);
		this.textBox_0.Name = "tbFirstName";
		this.textBox_0.Size = new Size(219, 20);
		this.textBox_0.TabIndex = 0;
		this.bindingSource_0.DataMember = "tJ_BossUser";
		this.bindingSource_0.DataSource = this.class255_0;
		this.class255_0.DataSetName = "DataSetGES";
		this.class255_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		this.textBox_1.DataBindings.Add(new Binding("Text", this.bindingSource_0, "LastName", true));
		this.textBox_1.Location = new Point(140, 38);
		this.textBox_1.Name = "tbLastName";
		this.textBox_1.Size = new Size(219, 20);
		this.textBox_1.TabIndex = 1;
		this.textBox_2.DataBindings.Add(new Binding("Text", this.bindingSource_0, "MiddleInitial", true));
		this.textBox_2.Location = new Point(140, 64);
		this.textBox_2.Name = "tbMiddleInitial";
		this.textBox_2.Size = new Size(219, 20);
		this.textBox_2.TabIndex = 2;
		this.textBox_3.DataBindings.Add(new Binding("Text", this.bindingSource_0, "Password", true));
		this.textBox_3.Location = new Point(140, 143);
		this.textBox_3.Name = "tbPassword";
		this.textBox_3.Size = new Size(219, 20);
		this.textBox_3.TabIndex = 3;
		this.button_0.DialogResult = DialogResult.OK;
		this.button_0.Location = new Point(192, 179);
		this.button_0.Name = "btnAccept";
		this.button_0.Size = new Size(75, 23);
		this.button_0.TabIndex = 4;
		this.button_0.Text = "Добавить";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_0.Click += this.button_0_Click;
		this.button_1.DialogResult = DialogResult.Cancel;
		this.button_1.Location = new Point(284, 179);
		this.button_1.Name = "btnCancel";
		this.button_1.Size = new Size(75, 23);
		this.button_1.TabIndex = 5;
		this.button_1.Text = "Отмена";
		this.button_1.UseVisualStyleBackColor = true;
		this.button_1.Click += this.button_1_Click;
		this.label_0.AutoSize = true;
		this.label_0.Location = new Point(12, 15);
		this.label_0.Name = "label1";
		this.label_0.Size = new Size(56, 13);
		this.label_0.TabIndex = 6;
		this.label_0.Text = "Фамилия";
		this.label_1.AutoSize = true;
		this.label_1.Location = new Point(12, 41);
		this.label_1.Name = "label2";
		this.label_1.Size = new Size(29, 13);
		this.label_1.TabIndex = 7;
		this.label_1.Text = "Имя";
		this.label_2.AutoSize = true;
		this.label_2.Location = new Point(12, 67);
		this.label_2.Name = "label3";
		this.label_2.Size = new Size(54, 13);
		this.label_2.TabIndex = 8;
		this.label_2.Text = "Отчество";
		this.label_3.AutoSize = true;
		this.label_3.Location = new Point(12, 146);
		this.label_3.Name = "label4";
		this.label_3.Size = new Size(45, 13);
		this.label_3.TabIndex = 9;
		this.label_3.Text = "Пароль";
		this.textBox_4.DataBindings.Add(new Binding("Text", this.bindingSource_0, "Mail", true));
		this.textBox_4.Location = new Point(140, 117);
		this.textBox_4.Name = "tbMail";
		this.textBox_4.Size = new Size(219, 20);
		this.textBox_4.TabIndex = 10;
		this.bindingSource_1.DataMember = "vJ_Worker";
		this.bindingSource_1.DataSource = this.class255_0;
		this.label_4.AutoSize = true;
		this.label_4.Location = new Point(12, 93);
		this.label_4.Name = "label5";
		this.label_4.Size = new Size(122, 13);
		this.label_4.TabIndex = 12;
		this.label_4.Text = "Польз. \"Энергосхема\"";
		this.label_5.AutoSize = true;
		this.label_5.Location = new Point(12, 120);
		this.label_5.Name = "label6";
		this.label_5.Size = new Size(67, 13);
		this.label_5.TabIndex = 13;
		this.label_5.Text = "Почт. адрес";
		this.comboBoxReadOnly_0.DataBindings.Add(new Binding("SelectedValue", this.bindingSource_0, "idWorker", true));
		this.comboBoxReadOnly_0.DataSource = this.bindingSource_1;
		this.comboBoxReadOnly_0.DisplayMember = "FIO";
		this.comboBoxReadOnly_0.FormattingEnabled = true;
		this.comboBoxReadOnly_0.Location = new Point(140, 90);
		this.comboBoxReadOnly_0.Name = "cbroGesWorker";
		this.comboBoxReadOnly_0.ReadOnlyBackColor = SystemColors.Control;
		this.comboBoxReadOnly_0.ReadOnlyForeColor = SystemColors.WindowText;
		this.comboBoxReadOnly_0.Size = new Size(219, 21);
		this.comboBoxReadOnly_0.TabIndex = 14;
		this.comboBoxReadOnly_0.ValueMember = "Id";
		base.AcceptButton = this.button_0;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = this.button_1;
		base.ClientSize = new Size(371, 214);
		base.Controls.Add(this.comboBoxReadOnly_0);
		base.Controls.Add(this.label_5);
		base.Controls.Add(this.label_4);
		base.Controls.Add(this.textBox_4);
		base.Controls.Add(this.label_3);
		base.Controls.Add(this.label_2);
		base.Controls.Add(this.label_1);
		base.Controls.Add(this.label_0);
		base.Controls.Add(this.button_1);
		base.Controls.Add(this.button_0);
		base.Controls.Add(this.textBox_3);
		base.Controls.Add(this.textBox_2);
		base.Controls.Add(this.textBox_1);
		base.Controls.Add(this.textBox_0);
		base.Name = "FormAddBossUser";
		base.StartPosition = FormStartPosition.CenterScreen;
		this.Text = "Добавление пользователя";
		base.Load += this.Form33_Load;
		((ISupportInitialize)this.bindingSource_0).EndInit();
		((ISupportInitialize)this.class255_0).EndInit();
		((ISupportInitialize)this.bindingSource_1).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	internal static void UqEqhMONpbTnbAf2vhLJ(Form form_0, bool bool_0)
	{
		form_0.Dispose(bool_0);
	}

	[CompilerGenerated]
	private int int_0;

	[CompilerGenerated]
	private int int_1;

	[CompilerGenerated]
	private StateFormCreate stateFormCreate_0;

	private TextBox textBox_0;

	private TextBox textBox_1;

	private TextBox textBox_2;

	private TextBox textBox_3;

	private Button button_0;

	private Button button_1;

	private Label label_0;

	private Label label_1;

	private Label label_2;

	private Label label_3;

	private BindingSource bindingSource_0;

	private Class255 class255_0;

	private TextBox textBox_4;

	private Label label_4;

	private Label label_5;

	private BindingSource bindingSource_1;

	private ComboBoxReadOnly comboBoxReadOnly_0;
}
