﻿namespace RequestsClient.Forms.JournalRequestForRepair
{
	public partial class FormSettingsSender : FormLbr.FormBase
	{
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RequestsClient.Forms.JournalRequestForRepair.FormSettingsSender));
			this.txtFTP05_FileName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtFTP05_NameFTP = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtFTP05_FTPUser = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.txtFTP05_FTPPwd = new System.Windows.Forms.MaskedTextBox();
			this.chbFTP05_Proxy = new System.Windows.Forms.CheckBox();
			this.txtFTP05_Proxy = new System.Windows.Forms.TextBox();
			this.txtFTP05_ProxyUser = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.txtFTP05_ProxyPwd = new System.Windows.Forms.MaskedTextBox();
			this.chbUseFTP05 = new System.Windows.Forms.CheckBox();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPagePlan = new System.Windows.Forms.TabPage();
			this.groupBoxSheduleFTP = new System.Windows.Forms.GroupBox();
			this.numFTP_weeks = new System.Windows.Forms.NumericUpDown();
			this.numFTP_days = new System.Windows.Forms.NumericUpDown();
			this.numFTP_hours = new System.Windows.Forms.NumericUpDown();
			this.rbFTP_weeks = new System.Windows.Forms.RadioButton();
			this.rbFTP_days = new System.Windows.Forms.RadioButton();
			this.rbFTP_hours = new System.Windows.Forms.RadioButton();
			this.label11 = new System.Windows.Forms.Label();
			this.dtpFTP_start = new System.Windows.Forms.DateTimePicker();
			this.label12 = new System.Windows.Forms.Label();
			this.btnFTP_ChoicePath = new System.Windows.Forms.Button();
			this.btnFTP_ChoiceFileName = new System.Windows.Forms.Button();
			this.label13 = new System.Windows.Forms.Label();
			this.txtFTP_PathName = new System.Windows.Forms.TextBox();
			this.chbUseFTP = new System.Windows.Forms.CheckBox();
			this.txtFTP_FileName = new System.Windows.Forms.TextBox();
			this.txtFTP_ProxyPwd = new System.Windows.Forms.MaskedTextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.txtFTP_NameFTP = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.txtFTP_ProxyUser = new System.Windows.Forms.TextBox();
			this.label18 = new System.Windows.Forms.Label();
			this.txtFTP_Proxy = new System.Windows.Forms.TextBox();
			this.txtFTP_FTPUser = new System.Windows.Forms.TextBox();
			this.chbFTP_Proxy = new System.Windows.Forms.CheckBox();
			this.label19 = new System.Windows.Forms.Label();
			this.txtFTP_FTPPwd = new System.Windows.Forms.MaskedTextBox();
			this.tabPageCrash = new System.Windows.Forms.TabPage();
			this.groupBoxSheduleFTP05 = new System.Windows.Forms.GroupBox();
			this.numFTP05_weeks = new System.Windows.Forms.NumericUpDown();
			this.numFTP05_days = new System.Windows.Forms.NumericUpDown();
			this.numFTP05_hours = new System.Windows.Forms.NumericUpDown();
			this.rbFTP05_weeks = new System.Windows.Forms.RadioButton();
			this.rbFTP05_days = new System.Windows.Forms.RadioButton();
			this.rbFTP05_hours = new System.Windows.Forms.RadioButton();
			this.label10 = new System.Windows.Forms.Label();
			this.dtpFTP05_start = new System.Windows.Forms.DateTimePicker();
			this.label9 = new System.Windows.Forms.Label();
			this.btnFTP05_ChoicePath = new System.Windows.Forms.Button();
			this.btnFTP05_ChoiceFileName = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.txtFTP05_PathName = new System.Windows.Forms.TextBox();
			this.tabPagePlannedMail = new System.Windows.Forms.TabPage();
			this.groupBoxSheduleMailPlanned = new System.Windows.Forms.GroupBox();
			this.numMailPlanned_weeks = new System.Windows.Forms.NumericUpDown();
			this.numMailPlanned_days = new System.Windows.Forms.NumericUpDown();
			this.numMailPlanned_hours = new System.Windows.Forms.NumericUpDown();
			this.rbMailPlanned_weeks = new System.Windows.Forms.RadioButton();
			this.rbMailPlanned_days = new System.Windows.Forms.RadioButton();
			this.rbMailPlanned_hours = new System.Windows.Forms.RadioButton();
			this.label30 = new System.Windows.Forms.Label();
			this.dtpMailPlanned_start = new System.Windows.Forms.DateTimePicker();
			this.label31 = new System.Windows.Forms.Label();
			this.label29 = new System.Windows.Forms.Label();
			this.txtBodyPlanned = new System.Windows.Forms.TextBox();
			this.label28 = new System.Windows.Forms.Label();
			this.txtSubjectPlanned = new System.Windows.Forms.TextBox();
			this.dgvRecipients = new System.Windows.Forms.DataGridView();
			this.addressRecipientDgvColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.nameRecipientDgvColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.label27 = new System.Windows.Forms.Label();
			this.groupBoxSender = new System.Windows.Forms.GroupBox();
			this.label26 = new System.Windows.Forms.Label();
			this.txtSenderNamePlanned = new System.Windows.Forms.TextBox();
			this.label25 = new System.Windows.Forms.Label();
			this.txtSenderAddressPlanned = new System.Windows.Forms.TextBox();
			this.groupBoxSMTP = new System.Windows.Forms.GroupBox();
			this.label24 = new System.Windows.Forms.Label();
			this.txtPwdSMTPPlanned = new System.Windows.Forms.TextBox();
			this.label23 = new System.Windows.Forms.Label();
			this.txtLoginSMTPPlanned = new System.Windows.Forms.TextBox();
			this.label22 = new System.Windows.Forms.Label();
			this.txtSMTPServerPortPlanned = new System.Windows.Forms.NumericUpDown();
			this.label21 = new System.Windows.Forms.Label();
			this.txtSMTPServerPlanned = new System.Windows.Forms.TextBox();
			this.btnChoiseFileMail = new System.Windows.Forms.Button();
			this.txtFileNameMailPlanned = new System.Windows.Forms.TextBox();
			this.label20 = new System.Windows.Forms.Label();
			this.chkUseMailPlanned = new System.Windows.Forms.CheckBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtCURL = new System.Windows.Forms.TextBox();
			this.btnChoiceCURL = new System.Windows.Forms.Button();
			this.tabPageRIC = new System.Windows.Forms.TabPage();
			this.checkBoxSendRIC = new System.Windows.Forms.CheckBox();
			this.tabControl.SuspendLayout();
			this.tabPagePlan.SuspendLayout();
			this.groupBoxSheduleFTP.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.numFTP_weeks).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.numFTP_days).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.numFTP_hours).BeginInit();
			this.tabPageCrash.SuspendLayout();
			this.groupBoxSheduleFTP05.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.numFTP05_weeks).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.numFTP05_days).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.numFTP05_hours).BeginInit();
			this.tabPagePlannedMail.SuspendLayout();
			this.groupBoxSheduleMailPlanned.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.numMailPlanned_weeks).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.numMailPlanned_days).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.numMailPlanned_hours).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.dgvRecipients).BeginInit();
			this.groupBoxSender.SuspendLayout();
			this.groupBoxSMTP.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.txtSMTPServerPortPlanned).BeginInit();
			this.tabPageRIC.SuspendLayout();
			base.SuspendLayout();
			this.txtFTP05_FileName.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.txtFTP05_FileName.Location = new System.Drawing.Point(90, 39);
			this.txtFTP05_FileName.Name = "txtFTP05_FileName";
			this.txtFTP05_FileName.Size = new System.Drawing.Size(358, 20);
			this.txtFTP05_FileName.TabIndex = 0;
			this.txtFTP05_FileName.Text = "\\\\ulges-fs\\software\\Ulges\\Site\\oper_otkl.html";
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(7, 42);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Имя файла";
			this.txtFTP05_NameFTP.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.txtFTP05_NameFTP.Location = new System.Drawing.Point(90, 92);
			this.txtFTP05_NameFTP.Name = "txtFTP05_NameFTP";
			this.txtFTP05_NameFTP.Size = new System.Drawing.Size(389, 20);
			this.txtFTP05_NameFTP.TabIndex = 2;
			this.txtFTP05_NameFTP.Text = "ftp://pike.z8.ru/www/site1/public_html/consumer/rabota/oper_otkl.html";
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(7, 95);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(54, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Путь FTP";
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(7, 121);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(61, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Логин FTP";
			this.txtFTP05_FTPUser.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.txtFTP05_FTPUser.Location = new System.Drawing.Point(90, 118);
			this.txtFTP05_FTPUser.Name = "txtFTP05_FTPUser";
			this.txtFTP05_FTPUser.Size = new System.Drawing.Size(389, 20);
			this.txtFTP05_FTPUser.TabIndex = 5;
			this.txtFTP05_FTPUser.Text = "ulges";
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(7, 147);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(68, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "Пароль FTP";
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(12, 556);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 8;
			this.btnOK.Text = "ОК";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			this.btnClose.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Location = new System.Drawing.Point(409, 556);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 9;
			this.btnClose.Text = "Закрыть";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			this.txtFTP05_FTPPwd.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.txtFTP05_FTPPwd.Location = new System.Drawing.Point(90, 144);
			this.txtFTP05_FTPPwd.Name = "txtFTP05_FTPPwd";
			this.txtFTP05_FTPPwd.PasswordChar = '*';
			this.txtFTP05_FTPPwd.Size = new System.Drawing.Size(389, 20);
			this.txtFTP05_FTPPwd.TabIndex = 10;
			this.txtFTP05_FTPPwd.Text = "kil777o";
			this.chbFTP05_Proxy.AutoSize = true;
			this.chbFTP05_Proxy.Location = new System.Drawing.Point(10, 172);
			this.chbFTP05_Proxy.Name = "chbFTP05_Proxy";
			this.chbFTP05_Proxy.Size = new System.Drawing.Size(138, 17);
			this.chbFTP05_Proxy.TabIndex = 11;
			this.chbFTP05_Proxy.Text = "Использовать прокси";
			this.chbFTP05_Proxy.UseVisualStyleBackColor = true;
			this.chbFTP05_Proxy.CheckedChanged += new System.EventHandler(this.chbFTP05_Proxy_CheckedChanged);
			this.txtFTP05_Proxy.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.txtFTP05_Proxy.Enabled = false;
			this.txtFTP05_Proxy.Location = new System.Drawing.Point(154, 170);
			this.txtFTP05_Proxy.Name = "txtFTP05_Proxy";
			this.txtFTP05_Proxy.Size = new System.Drawing.Size(325, 20);
			this.txtFTP05_Proxy.TabIndex = 12;
			this.txtFTP05_Proxy.Text = "ulges-proxy:8080";
			this.txtFTP05_ProxyUser.Enabled = false;
			this.txtFTP05_ProxyUser.Location = new System.Drawing.Point(132, 196);
			this.txtFTP05_ProxyUser.Name = "txtFTP05_ProxyUser";
			this.txtFTP05_ProxyUser.Size = new System.Drawing.Size(139, 20);
			this.txtFTP05_ProxyUser.TabIndex = 13;
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(7, 199);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(119, 13);
			this.label5.TabIndex = 14;
			this.label5.Text = "Пользователь прокси";
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(277, 199);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(45, 13);
			this.label6.TabIndex = 15;
			this.label6.Text = "Пароль";
			this.txtFTP05_ProxyPwd.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.txtFTP05_ProxyPwd.Enabled = false;
			this.txtFTP05_ProxyPwd.Location = new System.Drawing.Point(328, 196);
			this.txtFTP05_ProxyPwd.Name = "txtFTP05_ProxyPwd";
			this.txtFTP05_ProxyPwd.PasswordChar = '*';
			this.txtFTP05_ProxyPwd.Size = new System.Drawing.Size(151, 20);
			this.txtFTP05_ProxyPwd.TabIndex = 16;
			this.txtFTP05_ProxyPwd.Text = "kil777o";
			this.chbUseFTP05.AutoSize = true;
			this.chbUseFTP05.Checked = true;
			this.chbUseFTP05.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chbUseFTP05.Location = new System.Drawing.Point(10, 16);
			this.chbUseFTP05.Name = "chbUseFTP05";
			this.chbUseFTP05.Size = new System.Drawing.Size(186, 17);
			this.chbUseFTP05.TabIndex = 17;
			this.chbUseFTP05.Text = "Использовать отправку на FTP";
			this.chbUseFTP05.UseVisualStyleBackColor = true;
			this.chbUseFTP05.CheckedChanged += new System.EventHandler(this.chbUseFTP05_CheckedChanged);
			this.tabControl.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.tabControl.Controls.Add(this.tabPagePlan);
			this.tabControl.Controls.Add(this.tabPageCrash);
			this.tabControl.Controls.Add(this.tabPagePlannedMail);
			this.tabControl.Controls.Add(this.tabPageRIC);
			this.tabControl.Location = new System.Drawing.Point(1, 39);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(498, 511);
			this.tabControl.TabIndex = 18;
			this.tabPagePlan.Controls.Add(this.groupBoxSheduleFTP);
			this.tabPagePlan.Controls.Add(this.btnFTP_ChoicePath);
			this.tabPagePlan.Controls.Add(this.btnFTP_ChoiceFileName);
			this.tabPagePlan.Controls.Add(this.label13);
			this.tabPagePlan.Controls.Add(this.txtFTP_PathName);
			this.tabPagePlan.Controls.Add(this.chbUseFTP);
			this.tabPagePlan.Controls.Add(this.txtFTP_FileName);
			this.tabPagePlan.Controls.Add(this.txtFTP_ProxyPwd);
			this.tabPagePlan.Controls.Add(this.label14);
			this.tabPagePlan.Controls.Add(this.label15);
			this.tabPagePlan.Controls.Add(this.txtFTP_NameFTP);
			this.tabPagePlan.Controls.Add(this.label16);
			this.tabPagePlan.Controls.Add(this.label17);
			this.tabPagePlan.Controls.Add(this.txtFTP_ProxyUser);
			this.tabPagePlan.Controls.Add(this.label18);
			this.tabPagePlan.Controls.Add(this.txtFTP_Proxy);
			this.tabPagePlan.Controls.Add(this.txtFTP_FTPUser);
			this.tabPagePlan.Controls.Add(this.chbFTP_Proxy);
			this.tabPagePlan.Controls.Add(this.label19);
			this.tabPagePlan.Controls.Add(this.txtFTP_FTPPwd);
			this.tabPagePlan.Location = new System.Drawing.Point(4, 22);
			this.tabPagePlan.Name = "tabPagePlan";
			this.tabPagePlan.Padding = new System.Windows.Forms.Padding(3);
			this.tabPagePlan.Size = new System.Drawing.Size(490, 485);
			this.tabPagePlan.TabIndex = 0;
			this.tabPagePlan.Text = "Плановые";
			this.tabPagePlan.UseVisualStyleBackColor = true;
			this.groupBoxSheduleFTP.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.groupBoxSheduleFTP.Controls.Add(this.numFTP_weeks);
			this.groupBoxSheduleFTP.Controls.Add(this.numFTP_days);
			this.groupBoxSheduleFTP.Controls.Add(this.numFTP_hours);
			this.groupBoxSheduleFTP.Controls.Add(this.rbFTP_weeks);
			this.groupBoxSheduleFTP.Controls.Add(this.rbFTP_days);
			this.groupBoxSheduleFTP.Controls.Add(this.rbFTP_hours);
			this.groupBoxSheduleFTP.Controls.Add(this.label11);
			this.groupBoxSheduleFTP.Controls.Add(this.dtpFTP_start);
			this.groupBoxSheduleFTP.Controls.Add(this.label12);
			this.groupBoxSheduleFTP.Location = new System.Drawing.Point(12, 217);
			this.groupBoxSheduleFTP.Name = "groupBoxSheduleFTP";
			this.groupBoxSheduleFTP.Size = new System.Drawing.Size(467, 254);
			this.groupBoxSheduleFTP.TabIndex = 44;
			this.groupBoxSheduleFTP.TabStop = false;
			this.groupBoxSheduleFTP.Text = "Расписание";
			this.numFTP_weeks.Enabled = false;
			this.numFTP_weeks.Location = new System.Drawing.Point(80, 121);
			this.numFTP_weeks.Name = "numFTP_weeks";
			this.numFTP_weeks.Size = new System.Drawing.Size(120, 20);
			this.numFTP_weeks.TabIndex = 11;
			this.numFTP_days.Enabled = false;
			this.numFTP_days.Location = new System.Drawing.Point(80, 98);
			this.numFTP_days.Name = "numFTP_days";
			this.numFTP_days.Size = new System.Drawing.Size(120, 20);
			this.numFTP_days.TabIndex = 10;
			this.numFTP_hours.Location = new System.Drawing.Point(80, 75);
			this.numFTP_hours.Name = "numFTP_hours";
			this.numFTP_hours.Size = new System.Drawing.Size(120, 20);
			this.numFTP_hours.TabIndex = 8;
			this.rbFTP_weeks.AutoSize = true;
			this.rbFTP_weeks.Location = new System.Drawing.Point(13, 124);
			this.rbFTP_weeks.Name = "rbFTP_weeks";
			this.rbFTP_weeks.Size = new System.Drawing.Size(63, 17);
			this.rbFTP_weeks.TabIndex = 5;
			this.rbFTP_weeks.Text = "Недели";
			this.rbFTP_weeks.UseVisualStyleBackColor = true;
			this.rbFTP_weeks.CheckedChanged += new System.EventHandler(this.rbFTP_hours_CheckedChanged);
			this.rbFTP_days.AutoSize = true;
			this.rbFTP_days.Location = new System.Drawing.Point(13, 101);
			this.rbFTP_days.Name = "rbFTP_days";
			this.rbFTP_days.Size = new System.Drawing.Size(46, 17);
			this.rbFTP_days.TabIndex = 4;
			this.rbFTP_days.Text = "Дни";
			this.rbFTP_days.UseVisualStyleBackColor = true;
			this.rbFTP_days.CheckedChanged += new System.EventHandler(this.rbFTP_hours_CheckedChanged);
			this.rbFTP_hours.AutoSize = true;
			this.rbFTP_hours.Checked = true;
			this.rbFTP_hours.Location = new System.Drawing.Point(13, 78);
			this.rbFTP_hours.Name = "rbFTP_hours";
			this.rbFTP_hours.Size = new System.Drawing.Size(53, 17);
			this.rbFTP_hours.TabIndex = 3;
			this.rbFTP_hours.TabStop = true;
			this.rbFTP_hours.Text = "Часы";
			this.rbFTP_hours.UseVisualStyleBackColor = true;
			this.rbFTP_hours.CheckedChanged += new System.EventHandler(this.rbFTP_hours_CheckedChanged);
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(10, 51);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(104, 13);
			this.label11.TabIndex = 2;
			this.label11.Text = "Повторять каждые";
			this.dtpFTP_start.Cursor = System.Windows.Forms.Cursors.Default;
			this.dtpFTP_start.CustomFormat = "dd.MM.yyyy HH:mm";
			this.dtpFTP_start.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpFTP_start.Location = new System.Drawing.Point(80, 19);
			this.dtpFTP_start.Name = "dtpFTP_start";
			this.dtpFTP_start.Size = new System.Drawing.Size(200, 20);
			this.dtpFTP_start.TabIndex = 1;
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(6, 25);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(55, 13);
			this.label12.TabIndex = 0;
			this.label12.Text = "Начать с ";
			this.btnFTP_ChoicePath.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnFTP_ChoicePath.Location = new System.Drawing.Point(451, 58);
			this.btnFTP_ChoicePath.Name = "btnFTP_ChoicePath";
			this.btnFTP_ChoicePath.Size = new System.Drawing.Size(28, 23);
			this.btnFTP_ChoicePath.TabIndex = 43;
			this.btnFTP_ChoicePath.Text = "...";
			this.btnFTP_ChoicePath.UseVisualStyleBackColor = true;
			this.btnFTP_ChoicePath.Click += new System.EventHandler(this.btnFTP_ChoicePath_Click);
			this.btnFTP_ChoiceFileName.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnFTP_ChoiceFileName.Location = new System.Drawing.Point(451, 32);
			this.btnFTP_ChoiceFileName.Name = "btnFTP_ChoiceFileName";
			this.btnFTP_ChoiceFileName.Size = new System.Drawing.Size(28, 23);
			this.btnFTP_ChoiceFileName.TabIndex = 42;
			this.btnFTP_ChoiceFileName.Text = "...";
			this.btnFTP_ChoiceFileName.UseVisualStyleBackColor = true;
			this.btnFTP_ChoiceFileName.Click += new System.EventHandler(this.btnFTP_ChoiceFileName_Click);
			this.label13.Location = new System.Drawing.Point(9, 57);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(78, 31);
			this.label13.TabIndex = 41;
			this.label13.Text = "Пусть файла (для службы)";
			this.txtFTP_PathName.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.txtFTP_PathName.Location = new System.Drawing.Point(92, 60);
			this.txtFTP_PathName.Name = "txtFTP_PathName";
			this.txtFTP_PathName.Size = new System.Drawing.Size(356, 20);
			this.txtFTP_PathName.TabIndex = 40;
			this.txtFTP_PathName.Text = "\\\\ulges-fs\\software\\Ulges\\Site\\oper_otkl.html";
			this.chbUseFTP.AutoSize = true;
			this.chbUseFTP.Checked = true;
			this.chbUseFTP.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chbUseFTP.Location = new System.Drawing.Point(12, 11);
			this.chbUseFTP.Name = "chbUseFTP";
			this.chbUseFTP.Size = new System.Drawing.Size(186, 17);
			this.chbUseFTP.TabIndex = 39;
			this.chbUseFTP.Text = "Использовать отправку на FTP";
			this.chbUseFTP.UseVisualStyleBackColor = true;
			this.chbUseFTP.CheckedChanged += new System.EventHandler(this.checkBox_1_CheckedChanged);
			this.txtFTP_FileName.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.txtFTP_FileName.Location = new System.Drawing.Point(92, 34);
			this.txtFTP_FileName.Name = "txtFTP_FileName";
			this.txtFTP_FileName.Size = new System.Drawing.Size(356, 20);
			this.txtFTP_FileName.TabIndex = 25;
			this.txtFTP_FileName.Text = "\\\\ulges-fs\\software\\Ulges\\Site\\oper_otkl.html";
			this.txtFTP_ProxyPwd.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.txtFTP_ProxyPwd.Enabled = false;
			this.txtFTP_ProxyPwd.Location = new System.Drawing.Point(330, 191);
			this.txtFTP_ProxyPwd.Name = "txtFTP_ProxyPwd";
			this.txtFTP_ProxyPwd.PasswordChar = '*';
			this.txtFTP_ProxyPwd.Size = new System.Drawing.Size(149, 20);
			this.txtFTP_ProxyPwd.TabIndex = 38;
			this.txtFTP_ProxyPwd.Text = "kil777o";
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(9, 37);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(64, 13);
			this.label14.TabIndex = 26;
			this.label14.Text = "Имя файла";
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(279, 194);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(45, 13);
			this.label15.TabIndex = 37;
			this.label15.Text = "Пароль";
			this.txtFTP_NameFTP.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.txtFTP_NameFTP.Location = new System.Drawing.Point(92, 87);
			this.txtFTP_NameFTP.Name = "txtFTP_NameFTP";
			this.txtFTP_NameFTP.Size = new System.Drawing.Size(387, 20);
			this.txtFTP_NameFTP.TabIndex = 27;
			this.txtFTP_NameFTP.Text = "ftp://pike.z8.ru/www/site1/public_html/consumer/rabota/oper_otkl.html";
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(9, 194);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(119, 13);
			this.label16.TabIndex = 36;
			this.label16.Text = "Пользователь прокси";
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(9, 90);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(54, 13);
			this.label17.TabIndex = 28;
			this.label17.Text = "Путь FTP";
			this.txtFTP_ProxyUser.Enabled = false;
			this.txtFTP_ProxyUser.Location = new System.Drawing.Point(134, 191);
			this.txtFTP_ProxyUser.Name = "txtFTP_ProxyUser";
			this.txtFTP_ProxyUser.Size = new System.Drawing.Size(139, 20);
			this.txtFTP_ProxyUser.TabIndex = 35;
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(9, 116);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(61, 13);
			this.label18.TabIndex = 29;
			this.label18.Text = "Логин FTP";
			this.txtFTP_Proxy.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.txtFTP_Proxy.Enabled = false;
			this.txtFTP_Proxy.Location = new System.Drawing.Point(156, 165);
			this.txtFTP_Proxy.Name = "txtFTP_Proxy";
			this.txtFTP_Proxy.Size = new System.Drawing.Size(323, 20);
			this.txtFTP_Proxy.TabIndex = 34;
			this.txtFTP_Proxy.Text = "ulges-proxy:8080";
			this.txtFTP_FTPUser.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.txtFTP_FTPUser.Location = new System.Drawing.Point(92, 113);
			this.txtFTP_FTPUser.Name = "txtFTP_FTPUser";
			this.txtFTP_FTPUser.Size = new System.Drawing.Size(387, 20);
			this.txtFTP_FTPUser.TabIndex = 30;
			this.txtFTP_FTPUser.Text = "ulges";
			this.chbFTP_Proxy.AutoSize = true;
			this.chbFTP_Proxy.Location = new System.Drawing.Point(12, 167);
			this.chbFTP_Proxy.Name = "chbFTP_Proxy";
			this.chbFTP_Proxy.Size = new System.Drawing.Size(138, 17);
			this.chbFTP_Proxy.TabIndex = 33;
			this.chbFTP_Proxy.Text = "Использовать прокси";
			this.chbFTP_Proxy.UseVisualStyleBackColor = true;
			this.chbFTP_Proxy.CheckedChanged += new System.EventHandler(this.chbFTP_Proxy_CheckedChanged);
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(9, 142);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(68, 13);
			this.label19.TabIndex = 31;
			this.label19.Text = "Пароль FTP";
			this.txtFTP_FTPPwd.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.txtFTP_FTPPwd.Location = new System.Drawing.Point(92, 139);
			this.txtFTP_FTPPwd.Name = "txtFTP_FTPPwd";
			this.txtFTP_FTPPwd.PasswordChar = '*';
			this.txtFTP_FTPPwd.Size = new System.Drawing.Size(387, 20);
			this.txtFTP_FTPPwd.TabIndex = 32;
			this.txtFTP_FTPPwd.Text = "kil777o";
			this.tabPageCrash.Controls.Add(this.groupBoxSheduleFTP05);
			this.tabPageCrash.Controls.Add(this.btnFTP05_ChoicePath);
			this.tabPageCrash.Controls.Add(this.btnFTP05_ChoiceFileName);
			this.tabPageCrash.Controls.Add(this.label8);
			this.tabPageCrash.Controls.Add(this.txtFTP05_PathName);
			this.tabPageCrash.Controls.Add(this.chbUseFTP05);
			this.tabPageCrash.Controls.Add(this.txtFTP05_FileName);
			this.tabPageCrash.Controls.Add(this.txtFTP05_ProxyPwd);
			this.tabPageCrash.Controls.Add(this.label1);
			this.tabPageCrash.Controls.Add(this.label6);
			this.tabPageCrash.Controls.Add(this.txtFTP05_NameFTP);
			this.tabPageCrash.Controls.Add(this.label5);
			this.tabPageCrash.Controls.Add(this.label2);
			this.tabPageCrash.Controls.Add(this.txtFTP05_ProxyUser);
			this.tabPageCrash.Controls.Add(this.label3);
			this.tabPageCrash.Controls.Add(this.txtFTP05_Proxy);
			this.tabPageCrash.Controls.Add(this.txtFTP05_FTPUser);
			this.tabPageCrash.Controls.Add(this.chbFTP05_Proxy);
			this.tabPageCrash.Controls.Add(this.label4);
			this.tabPageCrash.Controls.Add(this.txtFTP05_FTPPwd);
			this.tabPageCrash.Location = new System.Drawing.Point(4, 22);
			this.tabPageCrash.Name = "tabPageCrash";
			this.tabPageCrash.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageCrash.Size = new System.Drawing.Size(490, 485);
			this.tabPageCrash.TabIndex = 1;
			this.tabPageCrash.Text = "Аварийные";
			this.tabPageCrash.UseVisualStyleBackColor = true;
			this.groupBoxSheduleFTP05.Controls.Add(this.numFTP05_weeks);
			this.groupBoxSheduleFTP05.Controls.Add(this.numFTP05_days);
			this.groupBoxSheduleFTP05.Controls.Add(this.numFTP05_hours);
			this.groupBoxSheduleFTP05.Controls.Add(this.rbFTP05_weeks);
			this.groupBoxSheduleFTP05.Controls.Add(this.rbFTP05_days);
			this.groupBoxSheduleFTP05.Controls.Add(this.rbFTP05_hours);
			this.groupBoxSheduleFTP05.Controls.Add(this.label10);
			this.groupBoxSheduleFTP05.Controls.Add(this.dtpFTP05_start);
			this.groupBoxSheduleFTP05.Controls.Add(this.label9);
			this.groupBoxSheduleFTP05.Location = new System.Drawing.Point(10, 222);
			this.groupBoxSheduleFTP05.Name = "groupBoxSheduleFTP05";
			this.groupBoxSheduleFTP05.Size = new System.Drawing.Size(585, 151);
			this.groupBoxSheduleFTP05.TabIndex = 24;
			this.groupBoxSheduleFTP05.TabStop = false;
			this.groupBoxSheduleFTP05.Text = "Расписание";
			this.numFTP05_weeks.Enabled = false;
			this.numFTP05_weeks.Location = new System.Drawing.Point(80, 121);
			this.numFTP05_weeks.Name = "numFTP05_weeks";
			this.numFTP05_weeks.Size = new System.Drawing.Size(120, 20);
			this.numFTP05_weeks.TabIndex = 11;
			this.numFTP05_days.Enabled = false;
			this.numFTP05_days.Location = new System.Drawing.Point(80, 98);
			this.numFTP05_days.Name = "numFTP05_days";
			this.numFTP05_days.Size = new System.Drawing.Size(120, 20);
			this.numFTP05_days.TabIndex = 10;
			this.numFTP05_hours.Location = new System.Drawing.Point(80, 75);
			this.numFTP05_hours.Name = "numFTP05_hours";
			this.numFTP05_hours.Size = new System.Drawing.Size(120, 20);
			this.numFTP05_hours.TabIndex = 8;
			this.rbFTP05_weeks.AutoSize = true;
			this.rbFTP05_weeks.Location = new System.Drawing.Point(13, 124);
			this.rbFTP05_weeks.Name = "rbFTP05_weeks";
			this.rbFTP05_weeks.Size = new System.Drawing.Size(63, 17);
			this.rbFTP05_weeks.TabIndex = 5;
			this.rbFTP05_weeks.Text = "Недели";
			this.rbFTP05_weeks.UseVisualStyleBackColor = true;
			this.rbFTP05_weeks.CheckedChanged += new System.EventHandler(this.rbFTP05_hours_CheckedChanged);
			this.rbFTP05_days.AutoSize = true;
			this.rbFTP05_days.Location = new System.Drawing.Point(13, 101);
			this.rbFTP05_days.Name = "rbFTP05_days";
			this.rbFTP05_days.Size = new System.Drawing.Size(46, 17);
			this.rbFTP05_days.TabIndex = 4;
			this.rbFTP05_days.Text = "Дни";
			this.rbFTP05_days.UseVisualStyleBackColor = true;
			this.rbFTP05_days.CheckedChanged += new System.EventHandler(this.rbFTP05_hours_CheckedChanged);
			this.rbFTP05_hours.AutoSize = true;
			this.rbFTP05_hours.Checked = true;
			this.rbFTP05_hours.Location = new System.Drawing.Point(13, 78);
			this.rbFTP05_hours.Name = "rbFTP05_hours";
			this.rbFTP05_hours.Size = new System.Drawing.Size(53, 17);
			this.rbFTP05_hours.TabIndex = 3;
			this.rbFTP05_hours.TabStop = true;
			this.rbFTP05_hours.Text = "Часы";
			this.rbFTP05_hours.UseVisualStyleBackColor = true;
			this.rbFTP05_hours.CheckedChanged += new System.EventHandler(this.rbFTP05_hours_CheckedChanged);
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(10, 51);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(104, 13);
			this.label10.TabIndex = 2;
			this.label10.Text = "Повторять каждые";
			this.dtpFTP05_start.Cursor = System.Windows.Forms.Cursors.Default;
			this.dtpFTP05_start.CustomFormat = "dd.MM.yyyy HH:mm";
			this.dtpFTP05_start.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpFTP05_start.Location = new System.Drawing.Point(80, 19);
			this.dtpFTP05_start.Name = "dtpFTP05_start";
			this.dtpFTP05_start.Size = new System.Drawing.Size(200, 20);
			this.dtpFTP05_start.TabIndex = 1;
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(6, 25);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(55, 13);
			this.label9.TabIndex = 0;
			this.label9.Text = "Начать с ";
			this.btnFTP05_ChoicePath.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnFTP05_ChoicePath.Location = new System.Drawing.Point(451, 63);
			this.btnFTP05_ChoicePath.Name = "btnFTP05_ChoicePath";
			this.btnFTP05_ChoicePath.Size = new System.Drawing.Size(28, 23);
			this.btnFTP05_ChoicePath.TabIndex = 23;
			this.btnFTP05_ChoicePath.Text = "...";
			this.btnFTP05_ChoicePath.UseVisualStyleBackColor = true;
			this.btnFTP05_ChoicePath.Click += new System.EventHandler(this.btnFTP05_ChoicePath_Click);
			this.btnFTP05_ChoiceFileName.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnFTP05_ChoiceFileName.Location = new System.Drawing.Point(451, 37);
			this.btnFTP05_ChoiceFileName.Name = "btnFTP05_ChoiceFileName";
			this.btnFTP05_ChoiceFileName.Size = new System.Drawing.Size(28, 23);
			this.btnFTP05_ChoiceFileName.TabIndex = 22;
			this.btnFTP05_ChoiceFileName.Text = "...";
			this.btnFTP05_ChoiceFileName.UseVisualStyleBackColor = true;
			this.btnFTP05_ChoiceFileName.Click += new System.EventHandler(this.btnFTP05_ChoiceFileName_Click);
			this.label8.Location = new System.Drawing.Point(7, 62);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(78, 31);
			this.label8.TabIndex = 19;
			this.label8.Text = "Пусть файла (для службы)";
			this.txtFTP05_PathName.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.txtFTP05_PathName.Location = new System.Drawing.Point(90, 65);
			this.txtFTP05_PathName.Name = "txtFTP05_PathName";
			this.txtFTP05_PathName.Size = new System.Drawing.Size(358, 20);
			this.txtFTP05_PathName.TabIndex = 18;
			this.txtFTP05_PathName.Text = "\\\\ulges-fs\\software\\Ulges\\Site\\oper_otkl.html";
			this.tabPagePlannedMail.Controls.Add(this.groupBoxSheduleMailPlanned);
			this.tabPagePlannedMail.Controls.Add(this.label29);
			this.tabPagePlannedMail.Controls.Add(this.txtBodyPlanned);
			this.tabPagePlannedMail.Controls.Add(this.label28);
			this.tabPagePlannedMail.Controls.Add(this.txtSubjectPlanned);
			this.tabPagePlannedMail.Controls.Add(this.dgvRecipients);
			this.tabPagePlannedMail.Controls.Add(this.label27);
			this.tabPagePlannedMail.Controls.Add(this.groupBoxSender);
			this.tabPagePlannedMail.Controls.Add(this.groupBoxSMTP);
			this.tabPagePlannedMail.Controls.Add(this.btnChoiseFileMail);
			this.tabPagePlannedMail.Controls.Add(this.txtFileNameMailPlanned);
			this.tabPagePlannedMail.Controls.Add(this.label20);
			this.tabPagePlannedMail.Controls.Add(this.chkUseMailPlanned);
			this.tabPagePlannedMail.Location = new System.Drawing.Point(4, 22);
			this.tabPagePlannedMail.Name = "tabPagePlannedMail";
			this.tabPagePlannedMail.Padding = new System.Windows.Forms.Padding(3);
			this.tabPagePlannedMail.Size = new System.Drawing.Size(490, 485);
			this.tabPagePlannedMail.TabIndex = 2;
			this.tabPagePlannedMail.Text = "Плановые почта";
			this.tabPagePlannedMail.UseVisualStyleBackColor = true;
			this.groupBoxSheduleMailPlanned.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.groupBoxSheduleMailPlanned.Controls.Add(this.numMailPlanned_weeks);
			this.groupBoxSheduleMailPlanned.Controls.Add(this.numMailPlanned_days);
			this.groupBoxSheduleMailPlanned.Controls.Add(this.numMailPlanned_hours);
			this.groupBoxSheduleMailPlanned.Controls.Add(this.rbMailPlanned_weeks);
			this.groupBoxSheduleMailPlanned.Controls.Add(this.rbMailPlanned_days);
			this.groupBoxSheduleMailPlanned.Controls.Add(this.rbMailPlanned_hours);
			this.groupBoxSheduleMailPlanned.Controls.Add(this.label30);
			this.groupBoxSheduleMailPlanned.Controls.Add(this.dtpMailPlanned_start);
			this.groupBoxSheduleMailPlanned.Controls.Add(this.label31);
			this.groupBoxSheduleMailPlanned.Location = new System.Drawing.Point(7, 365);
			this.groupBoxSheduleMailPlanned.Name = "groupBoxSheduleMailPlanned";
			this.groupBoxSheduleMailPlanned.Size = new System.Drawing.Size(472, 117);
			this.groupBoxSheduleMailPlanned.TabIndex = 45;
			this.groupBoxSheduleMailPlanned.TabStop = false;
			this.groupBoxSheduleMailPlanned.Text = "Расписание";
			this.numMailPlanned_weeks.Enabled = false;
			this.numMailPlanned_weeks.Location = new System.Drawing.Point(192, 88);
			this.numMailPlanned_weeks.Name = "numMailPlanned_weeks";
			this.numMailPlanned_weeks.Size = new System.Drawing.Size(120, 20);
			this.numMailPlanned_weeks.TabIndex = 11;
			this.numMailPlanned_days.Enabled = false;
			this.numMailPlanned_days.Location = new System.Drawing.Point(192, 65);
			this.numMailPlanned_days.Name = "numMailPlanned_days";
			this.numMailPlanned_days.Size = new System.Drawing.Size(120, 20);
			this.numMailPlanned_days.TabIndex = 10;
			this.numMailPlanned_hours.Location = new System.Drawing.Point(192, 42);
			this.numMailPlanned_hours.Name = "numMailPlanned_hours";
			this.numMailPlanned_hours.Size = new System.Drawing.Size(120, 20);
			this.numMailPlanned_hours.TabIndex = 8;
			this.rbMailPlanned_weeks.AutoSize = true;
			this.rbMailPlanned_weeks.Location = new System.Drawing.Point(125, 91);
			this.rbMailPlanned_weeks.Name = "rbMailPlanned_weeks";
			this.rbMailPlanned_weeks.Size = new System.Drawing.Size(63, 17);
			this.rbMailPlanned_weeks.TabIndex = 5;
			this.rbMailPlanned_weeks.Text = "Недели";
			this.rbMailPlanned_weeks.UseVisualStyleBackColor = true;
			this.rbMailPlanned_weeks.CheckedChanged += new System.EventHandler(this.rbMailPlanned_hours_CheckedChanged);
			this.rbMailPlanned_days.AutoSize = true;
			this.rbMailPlanned_days.Location = new System.Drawing.Point(125, 68);
			this.rbMailPlanned_days.Name = "rbMailPlanned_days";
			this.rbMailPlanned_days.Size = new System.Drawing.Size(46, 17);
			this.rbMailPlanned_days.TabIndex = 4;
			this.rbMailPlanned_days.Text = "Дни";
			this.rbMailPlanned_days.UseVisualStyleBackColor = true;
			this.rbMailPlanned_days.CheckedChanged += new System.EventHandler(this.rbMailPlanned_hours_CheckedChanged);
			this.rbMailPlanned_hours.AutoSize = true;
			this.rbMailPlanned_hours.Checked = true;
			this.rbMailPlanned_hours.Location = new System.Drawing.Point(125, 45);
			this.rbMailPlanned_hours.Name = "rbMailPlanned_hours";
			this.rbMailPlanned_hours.Size = new System.Drawing.Size(53, 17);
			this.rbMailPlanned_hours.TabIndex = 3;
			this.rbMailPlanned_hours.TabStop = true;
			this.rbMailPlanned_hours.Text = "Часы";
			this.rbMailPlanned_hours.UseVisualStyleBackColor = true;
			this.rbMailPlanned_hours.CheckedChanged += new System.EventHandler(this.rbMailPlanned_hours_CheckedChanged);
			this.label30.AutoSize = true;
			this.label30.Location = new System.Drawing.Point(6, 42);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(104, 13);
			this.label30.TabIndex = 2;
			this.label30.Text = "Повторять каждые";
			this.dtpMailPlanned_start.Cursor = System.Windows.Forms.Cursors.Default;
			this.dtpMailPlanned_start.CustomFormat = "dd.MM.yyyy HH:mm";
			this.dtpMailPlanned_start.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpMailPlanned_start.Location = new System.Drawing.Point(80, 19);
			this.dtpMailPlanned_start.Name = "dtpMailPlanned_start";
			this.dtpMailPlanned_start.Size = new System.Drawing.Size(200, 20);
			this.dtpMailPlanned_start.TabIndex = 1;
			this.label31.AutoSize = true;
			this.label31.Location = new System.Drawing.Point(6, 25);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(55, 13);
			this.label31.TabIndex = 0;
			this.label31.Text = "Начать с ";
			this.label29.AutoSize = true;
			this.label29.Location = new System.Drawing.Point(7, 342);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(97, 13);
			this.label29.TabIndex = 33;
			this.label29.Text = "Текст сообщения";
			this.txtBodyPlanned.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.txtBodyPlanned.Location = new System.Drawing.Point(107, 339);
			this.txtBodyPlanned.Name = "txtBodyPlanned";
			this.txtBodyPlanned.Size = new System.Drawing.Size(372, 20);
			this.txtBodyPlanned.TabIndex = 32;
			this.label28.AutoSize = true;
			this.label28.Location = new System.Drawing.Point(7, 316);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(94, 13);
			this.label28.TabIndex = 31;
			this.label28.Text = "Тема сообщения";
			this.txtSubjectPlanned.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.txtSubjectPlanned.Location = new System.Drawing.Point(107, 313);
			this.txtSubjectPlanned.Name = "txtSubjectPlanned";
			this.txtSubjectPlanned.Size = new System.Drawing.Size(372, 20);
			this.txtSubjectPlanned.TabIndex = 30;
			this.dgvRecipients.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.dgvRecipients.BackgroundColor = System.Drawing.SystemColors.Control;
			this.dgvRecipients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvRecipients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
			{
				this.addressRecipientDgvColumn,
				this.nameRecipientDgvColumn
			});
			this.dgvRecipients.Location = new System.Drawing.Point(10, 227);
			this.dgvRecipients.Name = "dgvRecipients";
			this.dgvRecipients.RowHeadersWidth = 15;
			this.dgvRecipients.Size = new System.Drawing.Size(469, 80);
			this.dgvRecipients.TabIndex = 29;
			this.addressRecipientDgvColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.addressRecipientDgvColumn.HeaderText = "Адрес";
			this.addressRecipientDgvColumn.Name = "addressRecipientDgvColumn";
			this.nameRecipientDgvColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.nameRecipientDgvColumn.HeaderText = "Имя";
			this.nameRecipientDgvColumn.Name = "nameRecipientDgvColumn";
			this.label27.AutoSize = true;
			this.label27.Location = new System.Drawing.Point(16, 211);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(66, 13);
			this.label27.TabIndex = 28;
			this.label27.Text = "Получатели";
			this.groupBoxSender.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.groupBoxSender.Controls.Add(this.label26);
			this.groupBoxSender.Controls.Add(this.txtSenderNamePlanned);
			this.groupBoxSender.Controls.Add(this.label25);
			this.groupBoxSender.Controls.Add(this.txtSenderAddressPlanned);
			this.groupBoxSender.Location = new System.Drawing.Point(10, 134);
			this.groupBoxSender.Name = "groupBoxSender";
			this.groupBoxSender.Size = new System.Drawing.Size(469, 74);
			this.groupBoxSender.TabIndex = 27;
			this.groupBoxSender.TabStop = false;
			this.groupBoxSender.Text = "Отправитель";
			this.label26.AutoSize = true;
			this.label26.Location = new System.Drawing.Point(6, 48);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(29, 13);
			this.label26.TabIndex = 4;
			this.label26.Text = "Имя";
			this.txtSenderNamePlanned.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.txtSenderNamePlanned.Location = new System.Drawing.Point(80, 45);
			this.txtSenderNamePlanned.Name = "txtSenderNamePlanned";
			this.txtSenderNamePlanned.Size = new System.Drawing.Size(383, 20);
			this.txtSenderNamePlanned.TabIndex = 3;
			this.label25.AutoSize = true;
			this.label25.Location = new System.Drawing.Point(6, 22);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(38, 13);
			this.label25.TabIndex = 2;
			this.label25.Text = "Адрес";
			this.txtSenderAddressPlanned.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.txtSenderAddressPlanned.Location = new System.Drawing.Point(80, 19);
			this.txtSenderAddressPlanned.Name = "txtSenderAddressPlanned";
			this.txtSenderAddressPlanned.Size = new System.Drawing.Size(383, 20);
			this.txtSenderAddressPlanned.TabIndex = 1;
			this.groupBoxSMTP.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.groupBoxSMTP.Controls.Add(this.label24);
			this.groupBoxSMTP.Controls.Add(this.txtPwdSMTPPlanned);
			this.groupBoxSMTP.Controls.Add(this.label23);
			this.groupBoxSMTP.Controls.Add(this.txtLoginSMTPPlanned);
			this.groupBoxSMTP.Controls.Add(this.label22);
			this.groupBoxSMTP.Controls.Add(this.txtSMTPServerPortPlanned);
			this.groupBoxSMTP.Controls.Add(this.label21);
			this.groupBoxSMTP.Controls.Add(this.txtSMTPServerPlanned);
			this.groupBoxSMTP.Location = new System.Drawing.Point(10, 55);
			this.groupBoxSMTP.Name = "groupBoxSMTP";
			this.groupBoxSMTP.Size = new System.Drawing.Size(469, 73);
			this.groupBoxSMTP.TabIndex = 26;
			this.groupBoxSMTP.TabStop = false;
			this.groupBoxSMTP.Text = "SMTP-сервер (сервер отправки)";
			this.label24.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.label24.AutoSize = true;
			this.label24.Location = new System.Drawing.Point(275, 48);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(45, 13);
			this.label24.TabIndex = 7;
			this.label24.Text = "Пароль";
			this.txtPwdSMTPPlanned.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.txtPwdSMTPPlanned.Location = new System.Drawing.Point(326, 45);
			this.txtPwdSMTPPlanned.Name = "txtPwdSMTPPlanned";
			this.txtPwdSMTPPlanned.PasswordChar = '*';
			this.txtPwdSMTPPlanned.Size = new System.Drawing.Size(137, 20);
			this.txtPwdSMTPPlanned.TabIndex = 6;
			this.label23.AutoSize = true;
			this.label23.Location = new System.Drawing.Point(6, 48);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(38, 13);
			this.label23.TabIndex = 5;
			this.label23.Text = "Логин";
			this.txtLoginSMTPPlanned.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.txtLoginSMTPPlanned.Location = new System.Drawing.Point(80, 45);
			this.txtLoginSMTPPlanned.Name = "txtLoginSMTPPlanned";
			this.txtLoginSMTPPlanned.Size = new System.Drawing.Size(189, 20);
			this.txtLoginSMTPPlanned.TabIndex = 4;
			this.label22.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.label22.AutoSize = true;
			this.label22.Location = new System.Drawing.Point(346, 22);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(32, 13);
			this.label22.TabIndex = 3;
			this.label22.Text = "Порт";
			this.txtSMTPServerPortPlanned.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.txtSMTPServerPortPlanned.Location = new System.Drawing.Point(384, 19);
			this.txtSMTPServerPortPlanned.Name = "txtSMTPServerPortPlanned";
			this.txtSMTPServerPortPlanned.Size = new System.Drawing.Size(79, 20);
			this.txtSMTPServerPortPlanned.TabIndex = 2;
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(6, 22);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(74, 13);
			this.label21.TabIndex = 1;
			this.label21.Text = "Имя сервера";
			this.txtSMTPServerPlanned.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.txtSMTPServerPlanned.Location = new System.Drawing.Point(80, 19);
			this.txtSMTPServerPlanned.Name = "txtSMTPServerPlanned";
			this.txtSMTPServerPlanned.Size = new System.Drawing.Size(260, 20);
			this.txtSMTPServerPlanned.TabIndex = 0;
			this.btnChoiseFileMail.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnChoiseFileMail.Location = new System.Drawing.Point(451, 27);
			this.btnChoiseFileMail.Name = "btnChoiseFileMail";
			this.btnChoiseFileMail.Size = new System.Drawing.Size(28, 23);
			this.btnChoiseFileMail.TabIndex = 25;
			this.btnChoiseFileMail.Text = "...";
			this.btnChoiseFileMail.UseVisualStyleBackColor = true;
			this.btnChoiseFileMail.Click += new System.EventHandler(this.btnChoiseFileMail_Click);
			this.txtFileNameMailPlanned.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.txtFileNameMailPlanned.Location = new System.Drawing.Point(90, 29);
			this.txtFileNameMailPlanned.Name = "txtFileNameMailPlanned";
			this.txtFileNameMailPlanned.Size = new System.Drawing.Size(358, 20);
			this.txtFileNameMailPlanned.TabIndex = 23;
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(7, 32);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(64, 13);
			this.label20.TabIndex = 24;
			this.label20.Text = "Имя файла";
			this.chkUseMailPlanned.AutoSize = true;
			this.chkUseMailPlanned.Checked = true;
			this.chkUseMailPlanned.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkUseMailPlanned.Location = new System.Drawing.Point(10, 6);
			this.chkUseMailPlanned.Name = "chkUseMailPlanned";
			this.chkUseMailPlanned.Size = new System.Drawing.Size(124, 17);
			this.chkUseMailPlanned.TabIndex = 0;
			this.chkUseMailPlanned.Text = "Включить отправку";
			this.chkUseMailPlanned.UseVisualStyleBackColor = true;
			this.chkUseMailPlanned.CheckedChanged += new System.EventHandler(this.chkUseMailPlanned_CheckedChanged);
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(12, 15);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(77, 13);
			this.label7.TabIndex = 19;
			this.label7.Text = "Путь до cURL";
			this.txtCURL.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.txtCURL.BackColor = System.Drawing.SystemColors.Window;
			this.txtCURL.Location = new System.Drawing.Point(95, 12);
			this.txtCURL.Name = "txtCURL";
			this.txtCURL.Size = new System.Drawing.Size(358, 20);
			this.txtCURL.TabIndex = 20;
			this.txtCURL.Text = "\\\\ulges-fs\\software\\Ulges\\EIS\\Plugins\\curl.exe";
			this.btnChoiceCURL.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnChoiceCURL.Location = new System.Drawing.Point(456, 10);
			this.btnChoiceCURL.Name = "btnChoiceCURL";
			this.btnChoiceCURL.Size = new System.Drawing.Size(28, 23);
			this.btnChoiceCURL.TabIndex = 21;
			this.btnChoiceCURL.Text = "...";
			this.btnChoiceCURL.UseVisualStyleBackColor = true;
			this.btnChoiceCURL.Click += new System.EventHandler(this.btnChoiceCURL_Click);
			this.tabPageRIC.Controls.Add(this.checkBoxSendRIC);
			this.tabPageRIC.Location = new System.Drawing.Point(4, 22);
			this.tabPageRIC.Name = "tabPageRIC";
			this.tabPageRIC.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageRIC.Size = new System.Drawing.Size(490, 485);
			this.tabPageRIC.TabIndex = 3;
			this.tabPageRIC.Text = "РИЦ";
			this.tabPageRIC.UseVisualStyleBackColor = true;
			this.checkBoxSendRIC.AutoSize = true;
			this.checkBoxSendRIC.Location = new System.Drawing.Point(10, 16);
			this.checkBoxSendRIC.Name = "checkBoxSendRIC";
			this.checkBoxSendRIC.Size = new System.Drawing.Size(162, 17);
			this.checkBoxSendRIC.TabIndex = 0;
			this.checkBoxSendRIC.Text = "Отправлять данные в РИЦ";
			this.checkBoxSendRIC.UseVisualStyleBackColor = true;
			base.AcceptButton = this.btnOK;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.btnClose;
			base.ClientSize = new System.Drawing.Size(496, 587);
			base.Controls.Add(this.btnChoiceCURL);
			base.Controls.Add(this.txtCURL);
			base.Controls.Add(this.label7);
			base.Controls.Add(this.tabControl);
			base.Controls.Add(this.btnClose);
			base.Controls.Add(this.btnOK);
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			this.MinimumSize = new System.Drawing.Size(500, 514);
			base.Name = "FormSettingsSender";
			this.Text = "Настройки FTP";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSettingsSender_FormClosing);
			base.Load += new System.EventHandler(this.FormSettingsSender_Load);
			this.tabControl.ResumeLayout(false);
			this.tabPagePlan.ResumeLayout(false);
			this.tabPagePlan.PerformLayout();
			this.groupBoxSheduleFTP.ResumeLayout(false);
			this.groupBoxSheduleFTP.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.numFTP_weeks).EndInit();
			((System.ComponentModel.ISupportInitialize)this.numFTP_days).EndInit();
			((System.ComponentModel.ISupportInitialize)this.numFTP_hours).EndInit();
			this.tabPageCrash.ResumeLayout(false);
			this.tabPageCrash.PerformLayout();
			this.groupBoxSheduleFTP05.ResumeLayout(false);
			this.groupBoxSheduleFTP05.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.numFTP05_weeks).EndInit();
			((System.ComponentModel.ISupportInitialize)this.numFTP05_days).EndInit();
			((System.ComponentModel.ISupportInitialize)this.numFTP05_hours).EndInit();
			this.tabPagePlannedMail.ResumeLayout(false);
			this.tabPagePlannedMail.PerformLayout();
			this.groupBoxSheduleMailPlanned.ResumeLayout(false);
			this.groupBoxSheduleMailPlanned.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.numMailPlanned_weeks).EndInit();
			((System.ComponentModel.ISupportInitialize)this.numMailPlanned_days).EndInit();
			((System.ComponentModel.ISupportInitialize)this.numMailPlanned_hours).EndInit();
			((System.ComponentModel.ISupportInitialize)this.dgvRecipients).EndInit();
			this.groupBoxSender.ResumeLayout(false);
			this.groupBoxSender.PerformLayout();
			this.groupBoxSMTP.ResumeLayout(false);
			this.groupBoxSMTP.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.txtSMTPServerPortPlanned).EndInit();
			this.tabPageRIC.ResumeLayout(false);
			this.tabPageRIC.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private System.ComponentModel.IContainer components=null;

		private System.Windows.Forms.TextBox txtFTP05_FileName;

		private System.Windows.Forms.Label label1;

		private System.Windows.Forms.TextBox txtFTP05_NameFTP;

		private System.Windows.Forms.Label label2;

		private System.Windows.Forms.Label label3;

		private System.Windows.Forms.TextBox txtFTP05_FTPUser;

		private System.Windows.Forms.Label label4;

		private System.Windows.Forms.Button btnOK;

		private System.Windows.Forms.Button btnClose;

		private System.Windows.Forms.MaskedTextBox txtFTP05_FTPPwd;

		private System.Windows.Forms.CheckBox chbFTP05_Proxy;

		private System.Windows.Forms.TextBox txtFTP05_Proxy;

		private System.Windows.Forms.TextBox txtFTP05_ProxyUser;

		private System.Windows.Forms.Label label5;

		private System.Windows.Forms.Label label6;

		private System.Windows.Forms.MaskedTextBox txtFTP05_ProxyPwd;

		private System.Windows.Forms.CheckBox chbUseFTP05;

		private System.Windows.Forms.TabControl tabControl;

		private System.Windows.Forms.TabPage tabPagePlan;

		private System.Windows.Forms.TabPage tabPageCrash;

		private System.Windows.Forms.Label label7;

		private System.Windows.Forms.TextBox txtCURL;

		private System.Windows.Forms.Button btnChoiceCURL;

		private System.Windows.Forms.Button btnFTP05_ChoiceFileName;

		private System.Windows.Forms.Label label8;

		private System.Windows.Forms.TextBox txtFTP05_PathName;

		private System.Windows.Forms.Button btnFTP05_ChoicePath;

		private System.Windows.Forms.GroupBox groupBoxSheduleFTP05;

		private System.Windows.Forms.RadioButton rbFTP05_weeks;

		private System.Windows.Forms.RadioButton rbFTP05_days;

		private System.Windows.Forms.RadioButton rbFTP05_hours;

		private System.Windows.Forms.Label label10;

		private System.Windows.Forms.DateTimePicker dtpFTP05_start;

		private System.Windows.Forms.Label label9;

		private System.Windows.Forms.NumericUpDown numFTP05_weeks;

		private System.Windows.Forms.NumericUpDown numFTP05_days;

		private System.Windows.Forms.NumericUpDown numFTP05_hours;

		private System.Windows.Forms.GroupBox groupBoxSheduleFTP;

		private System.Windows.Forms.NumericUpDown numFTP_weeks;

		private System.Windows.Forms.NumericUpDown numFTP_days;

		private System.Windows.Forms.NumericUpDown numFTP_hours;

		private System.Windows.Forms.RadioButton rbFTP_weeks;

		private System.Windows.Forms.RadioButton rbFTP_days;

		private System.Windows.Forms.RadioButton rbFTP_hours;

		private System.Windows.Forms.Label label11;

		private System.Windows.Forms.DateTimePicker dtpFTP_start;

		private System.Windows.Forms.Label label12;

		private System.Windows.Forms.Button btnFTP_ChoicePath;

		private System.Windows.Forms.Button btnFTP_ChoiceFileName;

		private System.Windows.Forms.Label label13;

		private System.Windows.Forms.TextBox txtFTP_PathName;

		private System.Windows.Forms.CheckBox chbUseFTP;

		private System.Windows.Forms.TextBox txtFTP_FileName;

		private System.Windows.Forms.MaskedTextBox txtFTP_ProxyPwd;

		private System.Windows.Forms.Label label14;

		private System.Windows.Forms.Label label15;

		private System.Windows.Forms.TextBox txtFTP_NameFTP;

		private System.Windows.Forms.Label label16;

		private System.Windows.Forms.Label label17;

		private System.Windows.Forms.TextBox txtFTP_ProxyUser;

		private System.Windows.Forms.Label label18;

		private System.Windows.Forms.TextBox txtFTP_Proxy;

		private System.Windows.Forms.TextBox txtFTP_FTPUser;

		private System.Windows.Forms.CheckBox chbFTP_Proxy;

		private System.Windows.Forms.Label label19;

		private System.Windows.Forms.MaskedTextBox txtFTP_FTPPwd;

		private System.Windows.Forms.TabPage tabPagePlannedMail;

		private System.Windows.Forms.Button btnChoiseFileMail;

		private System.Windows.Forms.TextBox txtFileNameMailPlanned;

		private System.Windows.Forms.Label label20;

		private System.Windows.Forms.CheckBox chkUseMailPlanned;

		private System.Windows.Forms.GroupBox groupBoxSMTP;

		private System.Windows.Forms.Label label24;

		private System.Windows.Forms.TextBox txtPwdSMTPPlanned;

		private System.Windows.Forms.Label label23;

		private System.Windows.Forms.TextBox txtLoginSMTPPlanned;

		private System.Windows.Forms.Label label22;

		private System.Windows.Forms.NumericUpDown txtSMTPServerPortPlanned;

		private System.Windows.Forms.Label label21;

		private System.Windows.Forms.TextBox txtSMTPServerPlanned;

		private System.Windows.Forms.GroupBox groupBoxSender;

		private System.Windows.Forms.Label label26;

		private System.Windows.Forms.TextBox txtSenderNamePlanned;

		private System.Windows.Forms.Label label25;

		private System.Windows.Forms.TextBox txtSenderAddressPlanned;

		private System.Windows.Forms.Label label27;

		private System.Windows.Forms.GroupBox groupBoxSheduleMailPlanned;

		private System.Windows.Forms.NumericUpDown numMailPlanned_weeks;

		private System.Windows.Forms.NumericUpDown numMailPlanned_days;

		private System.Windows.Forms.NumericUpDown numMailPlanned_hours;

		private System.Windows.Forms.RadioButton rbMailPlanned_weeks;

		private System.Windows.Forms.RadioButton rbMailPlanned_days;

		private System.Windows.Forms.RadioButton rbMailPlanned_hours;

		private System.Windows.Forms.Label label30;

		private System.Windows.Forms.DateTimePicker dtpMailPlanned_start;

		private System.Windows.Forms.Label label31;

		private System.Windows.Forms.Label label29;

		private System.Windows.Forms.TextBox txtBodyPlanned;

		private System.Windows.Forms.Label label28;

		private System.Windows.Forms.TextBox txtSubjectPlanned;

		private System.Windows.Forms.DataGridView dgvRecipients;

		private System.Windows.Forms.DataGridViewTextBoxColumn addressRecipientDgvColumn;

		private System.Windows.Forms.DataGridViewTextBoxColumn nameRecipientDgvColumn;

		private System.Windows.Forms.TabPage tabPageRIC;

		private System.Windows.Forms.CheckBox checkBoxSendRIC;
	}
}
