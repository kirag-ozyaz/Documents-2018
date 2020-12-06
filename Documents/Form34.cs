using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Constants;
using FormLbr;

internal partial class Form34 : FormBase
{
	internal int IdParent { get; set; }

	internal int Id { get; set; }

	[CompilerGenerated]
	internal StateFormCreate method_0()
	{
		return this.stateFormCreate_0;
	}

	[CompilerGenerated]
	internal void method_1(StateFormCreate stateFormCreate_1)
	{
		this.stateFormCreate_0 = stateFormCreate_1;
	}

	internal Form34()
	{
		
		
		this.method_2();
	}

	private void Form34_Load(object sender, EventArgs e)
	{
		if (this.method_0() == StateFormCreate.Add)
		{
			this.Text = "Добавление группы";
			Class255.Class459 @class = this.class255_0.tJ_BossUserGroup.method_5();
			if (this.IdParent > 0)
			{
				@class.idParent = this.IdParent;
			}
			@class.Deleted = false;
			this.class255_0.tJ_BossUserGroup.method_0(@class);
			return;
		}
		this.Text = "Редактирование группы";
		base.SelectSqlData(this.class255_0, this.class255_0.tJ_BossUserGroup, true, "WHERE id = " + this.Id.ToString());
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		this.class255_0.tJ_BossUserGroup.Rows[0].EndEdit();
		if (this.method_0() == StateFormCreate.Add)
		{
			this.class255_0.tJ_BossUserGroup.Rows[0].EndEdit();
			this.Id = base.InsertSqlDataOneRow(this.class255_0.tJ_BossUserGroup.Rows[0]);
		}
		else
		{
			this.class255_0.tJ_BossUserGroup.Rows[0].EndEdit();
			base.UpdateSqlDataOnlyChange(this.class255_0.tJ_BossUserGroup);
		}
		base.Close();
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		base.Close();
	}

	private void method_2()
	{
		this.icontainer_0 = new Container();
		this.label_0 = new Label();
		this.textBox_0 = new TextBox();
		this.class255_0 = new Class255();
		this.button_0 = new Button();
		this.button_1 = new Button();
		this.bindingSource_0 = new BindingSource(this.icontainer_0);
		((ISupportInitialize)this.class255_0).BeginInit();
		((ISupportInitialize)this.bindingSource_0).BeginInit();
		base.SuspendLayout();
		this.label_0.AutoSize = true;
		this.label_0.Location = new Point(12, 15);
		this.label_0.Name = "label1";
		this.label_0.Size = new Size(83, 13);
		this.label_0.TabIndex = 0;
		this.label_0.Text = "Наименование";
		this.textBox_0.DataBindings.Add(new Binding("Text", this.class255_0, "tJ_BossUserGroup.Name", true));
		this.textBox_0.Location = new Point(101, 12);
		this.textBox_0.Name = "tbNameGroup";
		this.textBox_0.Size = new Size(294, 20);
		this.textBox_0.TabIndex = 1;
		this.class255_0.DataSetName = "DataSetGES";
		this.class255_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		this.button_0.DialogResult = DialogResult.OK;
		this.button_0.Location = new Point(228, 46);
		this.button_0.Name = "btnAccept";
		this.button_0.Size = new Size(75, 23);
		this.button_0.TabIndex = 2;
		this.button_0.Text = "Добавить";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_0.Click += this.button_0_Click;
		this.button_1.DialogResult = DialogResult.Cancel;
		this.button_1.Location = new Point(320, 46);
		this.button_1.Name = "btnCancel";
		this.button_1.Size = new Size(75, 23);
		this.button_1.TabIndex = 3;
		this.button_1.Text = "Отмена";
		this.button_1.UseVisualStyleBackColor = true;
		this.button_1.Click += this.button_1_Click;
		base.AcceptButton = this.button_0;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = this.button_1;
		base.ClientSize = new Size(407, 77);
		base.Controls.Add(this.button_1);
		base.Controls.Add(this.button_0);
		base.Controls.Add(this.textBox_0);
		base.Controls.Add(this.label_0);
		base.Name = "FormAddBossUserGroup";
		base.StartPosition = FormStartPosition.CenterScreen;
		this.Text = "Добавление группы";
		base.Load += this.Form34_Load;
		((ISupportInitialize)this.class255_0).EndInit();
		((ISupportInitialize)this.bindingSource_0).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	[CompilerGenerated]
	private int int_0;

	[CompilerGenerated]
	private int int_1;

	[CompilerGenerated]
	private StateFormCreate stateFormCreate_0;

	private Label label_0;

	private TextBox textBox_0;

	private Button button_0;

	private Button button_1;

	private Class255 class255_0;

	private BindingSource bindingSource_0;
}
