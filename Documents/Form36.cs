using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using FormLbr;

internal partial class Form36 : FormBase
{
	[CompilerGenerated]
	internal bool method_0()
	{
		return this.bool_0;
	}

	[CompilerGenerated]
	internal void method_1(bool bool_1)
	{
		this.bool_0 = bool_1;
	}

	internal string Password { get; set; }

	internal Form36()
	{
		
		
		this.method_2();
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		if (string.IsNullOrEmpty(this.textBox_0.Text))
		{
			MessageBox.Show("Пароль не может быть пустым", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return;
		}
		this.method_1(this.checkBox_0.Checked);
		this.Password = this.textBox_0.Text;
		base.DialogResult = DialogResult.OK;
		base.Close();
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		base.Close();
	}

	private void method_2()
	{
		this.textBox_0 = new TextBox();
		this.button_0 = new Button();
		this.button_1 = new Button();
		this.label_0 = new Label();
		this.checkBox_0 = new CheckBox();
		base.SuspendLayout();
		this.textBox_0.Location = new Point(15, 44);
		this.textBox_0.Name = "tbPassword";
		this.textBox_0.Size = new Size(277, 20);
		this.textBox_0.TabIndex = 0;
		this.textBox_0.UseSystemPasswordChar = true;
		this.button_0.DialogResult = DialogResult.OK;
		this.button_0.Location = new Point(167, 79);
		this.button_0.Name = "btnOk";
		this.button_0.Size = new Size(43, 23);
		this.button_0.TabIndex = 2;
		this.button_0.Text = "Ок";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_0.Click += this.button_0_Click;
		this.button_1.DialogResult = DialogResult.Cancel;
		this.button_1.Location = new Point(217, 79);
		this.button_1.Name = "btnCancel";
		this.button_1.Size = new Size(75, 23);
		this.button_1.TabIndex = 3;
		this.button_1.Text = "Отмена";
		this.button_1.UseVisualStyleBackColor = true;
		this.button_1.Click += this.button_1_Click;
		this.label_0.AutoSize = true;
		this.label_0.Location = new Point(12, 19);
		this.label_0.Name = "label1";
		this.label_0.Size = new Size(188, 13);
		this.label_0.TabIndex = 4;
		this.label_0.Text = "Введите пароль к \"Босс Референт\"";
		this.checkBox_0.AutoSize = true;
		this.checkBox_0.Location = new Point(15, 83);
		this.checkBox_0.Name = "checkBox1";
		this.checkBox_0.Size = new Size(82, 17);
		this.checkBox_0.TabIndex = 1;
		this.checkBox_0.Text = "Запомнить";
		this.checkBox_0.UseVisualStyleBackColor = true;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(304, 110);
		base.Controls.Add(this.checkBox_0);
		base.Controls.Add(this.label_0);
		base.Controls.Add(this.button_1);
		base.Controls.Add(this.button_0);
		base.Controls.Add(this.textBox_0);
		base.Name = "FormPassword";
		base.StartPosition = FormStartPosition.CenterScreen;
		this.Text = "Проверка входа доступа";
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	[CompilerGenerated]
	private bool bool_0;

	[CompilerGenerated]
	private string string_0;

	private TextBox textBox_0;

	private Button button_0;

	private Button button_1;

	private Label label_0;

	private CheckBox checkBox_0;
}
