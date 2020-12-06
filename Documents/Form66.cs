using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using FormLbr;

internal partial class Form66 : FormBase
{
	internal Form66()
	{
		
		
		this.method_0();
		this.dateTimePicker_0.Value = DateTime.Now.Date;
		this.textBox_0.Text = "Excavation.html";
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		SaveFileDialog saveFileDialog = new SaveFileDialog();
		if (saveFileDialog.ShowDialog() == DialogResult.OK)
		{
			this.textBox_0.Text = saveFileDialog.FileName;
		}
	}

	private void button_2_Click(object sender, EventArgs e)
	{
		base.Close();
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		try
		{
			Class165.smethod_2(this.SqlSettings, this.textBox_0.Text, this.dateTimePicker_0.Value, this.checkBox_0.Checked);
			MessageBox.Show("Данные выгружены успешно");
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, ex.Source);
		}
	}

	private void button_3_Click(object sender, EventArgs e)
	{
		DateTime dateTime = new DateTime(2014, 7, 4);
		while (dateTime <= new DateTime(2014, 7, 13))
		{
			Class165.smethod_2(this.SqlSettings, "d:\\temp\\exc\\" + dateTime.ToString("yyyyMMdd") + ".html", dateTime, this.checkBox_0.Checked);
			dateTime = dateTime.AddDays(1.0);
		}
		MessageBox.Show("Данные выгружены успешно");
	}

	private void method_0()
	{
		this.label_0 = new Label();
		this.dateTimePicker_0 = new DateTimePicker();
		this.label_1 = new Label();
		this.textBox_0 = new TextBox();
		this.button_0 = new Button();
		this.button_1 = new Button();
		this.button_2 = new Button();
		this.checkBox_0 = new CheckBox();
		this.button_3 = new Button();
		base.SuspendLayout();
		this.label_0.AutoSize = true;
		this.label_0.Location = new Point(12, 9);
		this.label_0.Name = "label1";
		this.label_0.Size = new Size(33, 13);
		this.label_0.TabIndex = 0;
		this.label_0.Text = "Дата";
		this.dateTimePicker_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.dateTimePicker_0.Location = new Point(15, 25);
		this.dateTimePicker_0.Name = "dateTimePicker";
		this.dateTimePicker_0.Size = new Size(229, 20);
		this.dateTimePicker_0.TabIndex = 1;
		this.label_1.AutoSize = true;
		this.label_1.Location = new Point(12, 48);
		this.label_1.Name = "label2";
		this.label_1.Size = new Size(64, 13);
		this.label_1.TabIndex = 2;
		this.label_1.Text = "Имя файла";
		this.textBox_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_0.Location = new Point(15, 64);
		this.textBox_0.Name = "textBoxFile";
		this.textBox_0.Size = new Size(200, 20);
		this.textBox_0.TabIndex = 3;
		this.button_0.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.button_0.Location = new Point(221, 64);
		this.button_0.Name = "buttonFile";
		this.button_0.Size = new Size(23, 20);
		this.button_0.TabIndex = 4;
		this.button_0.Text = "...";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_0.Click += this.button_0_Click;
		this.button_1.Location = new Point(15, 130);
		this.button_1.Name = "buttonSave";
		this.button_1.Size = new Size(76, 23);
		this.button_1.TabIndex = 5;
		this.button_1.Text = "Экспорт";
		this.button_1.UseVisualStyleBackColor = true;
		this.button_1.Click += this.button_1_Click;
		this.button_2.Location = new Point(170, 130);
		this.button_2.Name = "buttonClose";
		this.button_2.Size = new Size(75, 23);
		this.button_2.TabIndex = 6;
		this.button_2.Text = "Закрыть";
		this.button_2.UseVisualStyleBackColor = true;
		this.button_2.Click += this.button_2_Click;
		this.checkBox_0.AutoSize = true;
		this.checkBox_0.Checked = true;
		this.checkBox_0.CheckState = CheckState.Checked;
		this.checkBox_0.Location = new Point(15, 96);
		this.checkBox_0.Name = "checkBoxAgreed";
		this.checkBox_0.Size = new Size(106, 17);
		this.checkBox_0.TabIndex = 7;
		this.checkBox_0.Text = "Согласованные";
		this.checkBox_0.UseVisualStyleBackColor = true;
		this.button_3.Location = new Point(109, 130);
		this.button_3.Name = "button1";
		this.button_3.Size = new Size(75, 23);
		this.button_3.TabIndex = 8;
		this.button_3.Text = "button1";
		this.button_3.UseVisualStyleBackColor = true;
		this.button_3.Visible = false;
		this.button_3.Click += this.button_3_Click;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(257, 165);
		base.Controls.Add(this.button_3);
		base.Controls.Add(this.checkBox_0);
		base.Controls.Add(this.button_2);
		base.Controls.Add(this.button_1);
		base.Controls.Add(this.button_0);
		base.Controls.Add(this.textBox_0);
		base.Controls.Add(this.label_1);
		base.Controls.Add(this.dateTimePicker_0);
		base.Controls.Add(this.label_0);
		base.Name = "FormExportExcavation";
		this.Text = "Экспорт журанала раскопок";
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	internal static void dQhGKD0nkOB1IkWcqQB0(Form form_0, bool bool_0)
	{
		form_0.Dispose(bool_0);
	}

	private Label label_0;

	private DateTimePicker dateTimePicker_0;

	private Label label_1;

	private TextBox textBox_0;

	private Button button_0;

	private Button button_1;

	private Button button_2;

	private CheckBox checkBox_0;

	private Button button_3;
}
