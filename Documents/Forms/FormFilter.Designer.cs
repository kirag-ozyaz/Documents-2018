namespace Documents.Forms
{
	public partial class FormFilter : global::System.Windows.Forms.Form
	{
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.checkBox2 = new global::System.Windows.Forms.CheckBox();
			this.checkBox1 = new global::System.Windows.Forms.CheckBox();
			this.groupBox2 = new global::System.Windows.Forms.GroupBox();
			this.checkBox5 = new global::System.Windows.Forms.CheckBox();
			this.checkBox3 = new global::System.Windows.Forms.CheckBox();
			this.checkBox4 = new global::System.Windows.Forms.CheckBox();
			this.groupBox3 = new global::System.Windows.Forms.GroupBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.dateTimePicker2 = new global::System.Windows.Forms.DateTimePicker();
			this.dateTimePicker1 = new global::System.Windows.Forms.DateTimePicker();
			this.groupBox4 = new global::System.Windows.Forms.GroupBox();
			this.checkBox_5 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_6 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_7 = new global::System.Windows.Forms.CheckBox();
			this.checkBox7 = new global::System.Windows.Forms.CheckBox();
			this.checkBox6 = new global::System.Windows.Forms.CheckBox();
			this.checkBox8 = new global::System.Windows.Forms.CheckBox();
			this.panelPeriodApplication = new global::System.Windows.Forms.Panel();
			this.PeriodExecutionApplication = new global::System.Windows.Forms.Panel();
			this.checkBox9 = new global::System.Windows.Forms.CheckBox();
			this.groupBox5 = new global::System.Windows.Forms.GroupBox();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.dateTimePicker3 = new global::System.Windows.Forms.DateTimePicker();
			this.dateTimePicker4 = new global::System.Windows.Forms.DateTimePicker();
			this.groupBox6 = new global::System.Windows.Forms.GroupBox();
			this.checkBox_4 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_0 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_1 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_2 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_3 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_8 = new global::System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.panelPeriodApplication.SuspendLayout();
			this.PeriodExecutionApplication.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox6.SuspendLayout();
			base.SuspendLayout();
			this.groupBox1.Controls.Add(this.checkBox2);
			this.groupBox1.Controls.Add(this.checkBox1);
			this.groupBox1.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new global::System.Drawing.Point(0, 0);
			this.groupBox1.MinimumSize = new global::System.Drawing.Size(224, 67);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(224, 67);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Тип абонента";
			this.checkBox2.AutoSize = true;
			this.checkBox2.Location = new global::System.Drawing.Point(6, 42);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new global::System.Drawing.Size(117, 17);
			this.checkBox2.TabIndex = 0;
			this.checkBox2.Text = "Физические лица";
			this.checkBox2.UseVisualStyleBackColor = true;
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new global::System.Drawing.Point(6, 19);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new global::System.Drawing.Size(121, 17);
			this.checkBox1.TabIndex = 0;
			this.checkBox1.Text = "Юридические лица";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.groupBox2.Controls.Add(this.checkBox5);
			this.groupBox2.Controls.Add(this.checkBox3);
			this.groupBox2.Controls.Add(this.checkBox4);
			this.groupBox2.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.groupBox2.Location = new global::System.Drawing.Point(0, 67);
			this.groupBox2.MinimumSize = new global::System.Drawing.Size(224, 86);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new global::System.Drawing.Size(224, 86);
			this.groupBox2.TabIndex = 0;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Тип действия";
			this.checkBox5.AutoSize = true;
			this.checkBox5.Location = new global::System.Drawing.Point(6, 65);
			this.checkBox5.Name = "checkBox5";
			this.checkBox5.Size = new global::System.Drawing.Size(65, 17);
			this.checkBox5.TabIndex = 0;
			this.checkBox5.Text = "Отмена";
			this.checkBox5.UseVisualStyleBackColor = true;
			this.checkBox3.AutoSize = true;
			this.checkBox3.Location = new global::System.Drawing.Point(6, 42);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new global::System.Drawing.Size(105, 17);
			this.checkBox3.TabIndex = 0;
			this.checkBox3.Text = "Возобновление";
			this.checkBox3.UseVisualStyleBackColor = true;
			this.checkBox4.AutoSize = true;
			this.checkBox4.Location = new global::System.Drawing.Point(6, 19);
			this.checkBox4.Name = "checkBox4";
			this.checkBox4.Size = new global::System.Drawing.Size(88, 17);
			this.checkBox4.TabIndex = 0;
			this.checkBox4.Text = "Отключение";
			this.checkBox4.UseVisualStyleBackColor = true;
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Controls.Add(this.dateTimePicker2);
			this.groupBox3.Controls.Add(this.dateTimePicker1);
			this.groupBox3.Enabled = false;
			this.groupBox3.Location = new global::System.Drawing.Point(1, 2);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new global::System.Drawing.Size(223, 99);
			this.groupBox3.TabIndex = 0;
			this.groupBox3.TabStop = false;
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(6, 55);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(38, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Конец";
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(6, 16);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(44, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Начало";
			this.dateTimePicker2.Location = new global::System.Drawing.Point(6, 71);
			this.dateTimePicker2.Name = "dateTimePicker2";
			this.dateTimePicker2.ShowUpDown = true;
			this.dateTimePicker2.Size = new global::System.Drawing.Size(188, 20);
			this.dateTimePicker2.TabIndex = 0;
			this.dateTimePicker2.ValueChanged += new global::System.EventHandler(this.dateTimePicker2_ValueChanged);
			this.dateTimePicker1.Location = new global::System.Drawing.Point(6, 32);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.ShowUpDown = true;
			this.dateTimePicker1.Size = new global::System.Drawing.Size(188, 20);
			this.dateTimePicker1.TabIndex = 0;
			this.dateTimePicker1.ValueChanged += new global::System.EventHandler(this.dateTimePicker1_ValueChanged);
			this.groupBox4.Controls.Add(this.checkBox_5);
			this.groupBox4.Controls.Add(this.checkBox_6);
			this.groupBox4.Controls.Add(this.checkBox_7);
			this.groupBox4.Controls.Add(this.checkBox7);
			this.groupBox4.Controls.Add(this.checkBox6);
			this.groupBox4.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.groupBox4.Location = new global::System.Drawing.Point(0, 153);
			this.groupBox4.MinimumSize = new global::System.Drawing.Size(224, 65);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new global::System.Drawing.Size(224, 135);
			this.groupBox4.TabIndex = 0;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Не отображать";
			this.checkBox_5.AutoSize = true;
			this.checkBox_5.Location = new global::System.Drawing.Point(6, 88);
			this.checkBox_5.Name = "checkBox15";
			this.checkBox_5.Size = new global::System.Drawing.Size(113, 17);
			this.checkBox_5.TabIndex = 0;
			this.checkBox_5.Text = "Неотправленные";
			this.checkBox_5.UseVisualStyleBackColor = true;
			this.checkBox_6.AutoSize = true;
			this.checkBox_6.Location = new global::System.Drawing.Point(6, 111);
			this.checkBox_6.Name = "checkBox16";
			this.checkBox_6.Size = new global::System.Drawing.Size(182, 17);
			this.checkBox_6.TabIndex = 0;
			this.checkBox_6.Text = "Невыполненные (вне периода)";
			this.checkBox_6.UseVisualStyleBackColor = true;
			this.checkBox_7.AutoSize = true;
			this.checkBox_7.Location = new global::System.Drawing.Point(6, 65);
			this.checkBox_7.Name = "checkBox17";
			this.checkBox_7.Size = new global::System.Drawing.Size(110, 17);
			this.checkBox_7.TabIndex = 0;
			this.checkBox_7.Text = "Невыполненные";
			this.checkBox_7.UseVisualStyleBackColor = true;
			this.checkBox7.AutoSize = true;
			this.checkBox7.Location = new global::System.Drawing.Point(6, 42);
			this.checkBox7.Name = "checkBox7";
			this.checkBox7.Size = new global::System.Drawing.Size(97, 17);
			this.checkBox7.TabIndex = 0;
			this.checkBox7.Text = "Выполненные";
			this.checkBox7.UseVisualStyleBackColor = true;
			this.checkBox6.AutoSize = true;
			this.checkBox6.Location = new global::System.Drawing.Point(6, 19);
			this.checkBox6.Name = "checkBox6";
			this.checkBox6.Size = new global::System.Drawing.Size(91, 17);
			this.checkBox6.TabIndex = 0;
			this.checkBox6.Text = "Отменённые";
			this.checkBox6.UseVisualStyleBackColor = true;
			this.checkBox8.AutoSize = true;
			this.checkBox8.Location = new global::System.Drawing.Point(6, 0);
			this.checkBox8.Name = "checkBox8";
			this.checkBox8.Size = new global::System.Drawing.Size(103, 17);
			this.checkBox8.TabIndex = 0;
			this.checkBox8.Text = "Период заявки";
			this.checkBox8.UseVisualStyleBackColor = true;
			this.checkBox8.CheckedChanged += new global::System.EventHandler(this.ftZdursrjA);
			this.panelPeriodApplication.Controls.Add(this.checkBox8);
			this.panelPeriodApplication.Controls.Add(this.groupBox3);
			this.panelPeriodApplication.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panelPeriodApplication.Location = new global::System.Drawing.Point(0, 288);
			this.panelPeriodApplication.MinimumSize = new global::System.Drawing.Size(224, 103);
			this.panelPeriodApplication.Name = "panelPeriodApplication";
			this.panelPeriodApplication.Size = new global::System.Drawing.Size(224, 103);
			this.panelPeriodApplication.TabIndex = 1;
			this.PeriodExecutionApplication.Controls.Add(this.checkBox9);
			this.PeriodExecutionApplication.Controls.Add(this.groupBox5);
			this.PeriodExecutionApplication.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.PeriodExecutionApplication.Location = new global::System.Drawing.Point(0, 391);
			this.PeriodExecutionApplication.MinimumSize = new global::System.Drawing.Size(224, 103);
			this.PeriodExecutionApplication.Name = "PeriodExecutionApplication";
			this.PeriodExecutionApplication.Size = new global::System.Drawing.Size(224, 103);
			this.PeriodExecutionApplication.TabIndex = 2;
			this.checkBox9.AutoSize = true;
			this.checkBox9.Location = new global::System.Drawing.Point(6, 0);
			this.checkBox9.Name = "checkBox9";
			this.checkBox9.Size = new global::System.Drawing.Size(166, 17);
			this.checkBox9.TabIndex = 0;
			this.checkBox9.Text = "Период исполнения заявки";
			this.checkBox9.UseVisualStyleBackColor = true;
			this.checkBox9.CheckedChanged += new global::System.EventHandler(this.checkBox9_CheckedChanged);
			this.groupBox5.Controls.Add(this.label3);
			this.groupBox5.Controls.Add(this.label4);
			this.groupBox5.Controls.Add(this.dateTimePicker3);
			this.groupBox5.Controls.Add(this.dateTimePicker4);
			this.groupBox5.Enabled = false;
			this.groupBox5.Location = new global::System.Drawing.Point(1, 2);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new global::System.Drawing.Size(223, 99);
			this.groupBox5.TabIndex = 0;
			this.groupBox5.TabStop = false;
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(6, 55);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(38, 13);
			this.label3.TabIndex = 1;
			this.label3.Text = "Конец";
			this.label4.AutoSize = true;
			this.label4.Location = new global::System.Drawing.Point(6, 16);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(44, 13);
			this.label4.TabIndex = 1;
			this.label4.Text = "Начало";
			this.dateTimePicker3.Location = new global::System.Drawing.Point(6, 71);
			this.dateTimePicker3.Name = "dateTimePicker3";
			this.dateTimePicker3.ShowUpDown = true;
			this.dateTimePicker3.Size = new global::System.Drawing.Size(188, 20);
			this.dateTimePicker3.TabIndex = 0;
			this.dateTimePicker3.ValueChanged += new global::System.EventHandler(this.dateTimePicker3_ValueChanged);
			this.dateTimePicker4.Location = new global::System.Drawing.Point(6, 32);
			this.dateTimePicker4.Name = "dateTimePicker4";
			this.dateTimePicker4.ShowUpDown = true;
			this.dateTimePicker4.Size = new global::System.Drawing.Size(188, 20);
			this.dateTimePicker4.TabIndex = 0;
			this.dateTimePicker4.ValueChanged += new global::System.EventHandler(this.dateTimePicker4_ValueChanged);
			this.groupBox6.Controls.Add(this.checkBox_8);
			this.groupBox6.Controls.Add(this.checkBox_4);
			this.groupBox6.Controls.Add(this.checkBox_0);
			this.groupBox6.Controls.Add(this.checkBox_1);
			this.groupBox6.Controls.Add(this.checkBox_2);
			this.groupBox6.Controls.Add(this.checkBox_3);
			this.groupBox6.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.groupBox6.Location = new global::System.Drawing.Point(0, 494);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new global::System.Drawing.Size(224, 157);
			this.groupBox6.TabIndex = 3;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Районы";
			this.checkBox_4.AutoSize = true;
			this.checkBox_4.Location = new global::System.Drawing.Point(6, 111);
			this.checkBox_4.Name = "checkBox14";
			this.checkBox_4.Size = new global::System.Drawing.Size(50, 17);
			this.checkBox_4.TabIndex = 0;
			this.checkBox_4.Text = "ОДС";
			this.checkBox_4.UseVisualStyleBackColor = true;
			this.checkBox_0.AutoSize = true;
			this.checkBox_0.Location = new global::System.Drawing.Point(6, 88);
			this.checkBox_0.Name = "checkBox13";
			this.checkBox_0.Size = new global::System.Drawing.Size(121, 17);
			this.checkBox_0.TabIndex = 0;
			this.checkBox_0.Text = "Сетевой район №4";
			this.checkBox_0.UseVisualStyleBackColor = true;
			this.checkBox_1.AutoSize = true;
			this.checkBox_1.Location = new global::System.Drawing.Point(6, 65);
			this.checkBox_1.Name = "checkBox12";
			this.checkBox_1.Size = new global::System.Drawing.Size(121, 17);
			this.checkBox_1.TabIndex = 0;
			this.checkBox_1.Text = "Сетевой район №3";
			this.checkBox_1.UseVisualStyleBackColor = true;
			this.checkBox_2.AutoSize = true;
			this.checkBox_2.Location = new global::System.Drawing.Point(6, 42);
			this.checkBox_2.Name = "checkBox11";
			this.checkBox_2.Size = new global::System.Drawing.Size(121, 17);
			this.checkBox_2.TabIndex = 0;
			this.checkBox_2.Text = "Сетевой район №2";
			this.checkBox_2.UseVisualStyleBackColor = true;
			this.checkBox_3.AutoSize = true;
			this.checkBox_3.Location = new global::System.Drawing.Point(6, 19);
			this.checkBox_3.Name = "checkBox10";
			this.checkBox_3.Size = new global::System.Drawing.Size(121, 17);
			this.checkBox_3.TabIndex = 0;
			this.checkBox_3.Text = "Сетевой район №1";
			this.checkBox_3.UseVisualStyleBackColor = true;
			this.checkBox_8.AutoSize = true;
			this.checkBox_8.Location = new global::System.Drawing.Point(6, 134);
			this.checkBox_8.Name = "checkBox18";
			this.checkBox_8.Size = new global::System.Drawing.Size(63, 17);
			this.checkBox_8.TabIndex = 0;
			this.checkBox_8.Text = "СЭСНО";
			this.checkBox_8.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(224, 651);
			base.ControlBox = false;
			base.Controls.Add(this.groupBox6);
			base.Controls.Add(this.PeriodExecutionApplication);
			base.Controls.Add(this.panelPeriodApplication);
			base.Controls.Add(this.groupBox4);
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.groupBox1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "FormFilter";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			base.Load += new global::System.EventHandler(this.FormFilter_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.panelPeriodApplication.ResumeLayout(false);
			this.panelPeriodApplication.PerformLayout();
			this.PeriodExecutionApplication.ResumeLayout(false);
			this.PeriodExecutionApplication.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			base.ResumeLayout(false);
		}

		private global::System.ComponentModel.IContainer icontainer_0;

		private global::System.Windows.Forms.GroupBox groupBox1;

		private global::System.Windows.Forms.CheckBox checkBox1;

		private global::System.Windows.Forms.CheckBox checkBox2;

		private global::System.Windows.Forms.CheckBox checkBox5;

		private global::System.Windows.Forms.CheckBox checkBox3;

		private global::System.Windows.Forms.CheckBox checkBox4;

		private global::System.Windows.Forms.GroupBox groupBox3;

		private global::System.Windows.Forms.Label label2;

		private global::System.Windows.Forms.Label label1;

		private global::System.Windows.Forms.DateTimePicker dateTimePicker2;

		private global::System.Windows.Forms.DateTimePicker dateTimePicker1;

		private global::System.Windows.Forms.CheckBox checkBox7;

		private global::System.Windows.Forms.CheckBox checkBox6;

		private global::System.Windows.Forms.CheckBox checkBox8;

		private global::System.Windows.Forms.Panel panelPeriodApplication;

		private global::System.Windows.Forms.Panel PeriodExecutionApplication;

		private global::System.Windows.Forms.GroupBox groupBox5;

		private global::System.Windows.Forms.Label label3;

		private global::System.Windows.Forms.CheckBox checkBox9;

		private global::System.Windows.Forms.Label label4;

		private global::System.Windows.Forms.DateTimePicker dateTimePicker3;

		private global::System.Windows.Forms.DateTimePicker dateTimePicker4;

		private global::System.Windows.Forms.GroupBox groupBox6;

		private global::System.Windows.Forms.CheckBox checkBox_0;

		private global::System.Windows.Forms.CheckBox checkBox_1;

		private global::System.Windows.Forms.CheckBox checkBox_2;

		private global::System.Windows.Forms.CheckBox checkBox_3;

		private global::System.Windows.Forms.CheckBox checkBox_4;

		private global::System.Windows.Forms.CheckBox checkBox_5;

		private global::System.Windows.Forms.CheckBox checkBox_6;

		private global::System.Windows.Forms.CheckBox checkBox_7;

		private global::System.Windows.Forms.GroupBox groupBox2;

		private global::System.Windows.Forms.GroupBox groupBox4;

		private global::System.Windows.Forms.CheckBox checkBox_8;
	}
}
