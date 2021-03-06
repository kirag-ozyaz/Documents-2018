﻿namespace RequestsClient.Forms.JournalRequestForRepair
{
	public partial class FormJournalRequestForRepairAddEdit : FormLbr.FormBase
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
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			this.label1 = new System.Windows.Forms.Label();
			this.cmbWorker = new System.Windows.Forms.ComboBox();
			this.dataSetN = new Class3();
			this.labelRequestFiled = new System.Windows.Forms.Label();
			this.labelSR = new System.Windows.Forms.Label();
			this.cmbSR = new System.Windows.Forms.ComboBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cmbTypeDamage = new System.Windows.Forms.ComboBox();
			this.cmbTypeDisable = new System.Windows.Forms.ComboBox();
			this.cmbIsPlanned = new System.Windows.Forms.ComboBox();
			this.labelIsPlanned = new System.Windows.Forms.Label();
			this.labelPurpose = new System.Windows.Forms.Label();
			this.txtPurpose = new System.Windows.Forms.TextBox();
			this.txtObject = new System.Windows.Forms.TextBox();
			this.labelObject = new System.Windows.Forms.Label();
			this.toolStripScheme = new System.Windows.Forms.ToolStrip();
			this.toolBtnLinkSchmObj = new System.Windows.Forms.ToolStripButton();
			this.toolBtnLinkSchmObjEdit = new System.Windows.Forms.ToolStripButton();
			this.toolBtnDelSchmObj = new System.Windows.Forms.ToolStripButton();
			this.toolBtnViewSChmObj = new System.Windows.Forms.ToolStripButton();
			this.groupBoxDaily = new System.Windows.Forms.GroupBox();
			this.dateTimePickerFactEnd = new ControlsLbr.NullableDateTimePicker();
			this.label3 = new System.Windows.Forms.Label();
			this.buttonDaily = new System.Windows.Forms.Button();
			this.dgvDaily = new System.Windows.Forms.DataGridView();
			this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.idRequestDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dateBegDataGridViewTextBoxColumn = new ControlsLbr.DataGridViewExcelFilter.DataGridViewFilterDateTimePickerColumn();
			this.dateEndDataGridViewTextBoxColumn = new ControlsLbr.DataGridViewExcelFilter.DataGridViewFilterDateTimePickerColumn();
			this.checkBoxWeekEnd = new System.Windows.Forms.CheckBox();
			this.checkBoxDaily = new System.Windows.Forms.CheckBox();
			this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
			this.label9 = new System.Windows.Forms.Label();
			this.dateTimePickerBeg = new System.Windows.Forms.DateTimePicker();
			this.label8 = new System.Windows.Forms.Label();
			this.groupBox_0 = new System.Windows.Forms.GroupBox();
			this.cmbStatus = new System.Windows.Forms.ComboBox();
			this.labelStatus = new System.Windows.Forms.Label();
			this.txtAdress = new System.Windows.Forms.TextBox();
			this.cmbDispatcher = new System.Windows.Forms.ComboBox();
			this.label14 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.dateTimePickerDateAgreed = new ControlsLbr.NullableDateTimePicker();
			this.rWoeDxUpjP = new System.Windows.Forms.CheckBox();
			this.labelAddress = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.txtComment = new System.Windows.Forms.TextBox();
			this.txtAgreeWith = new System.Windows.Forms.TextBox();
			this.buttonOK = new System.Windows.Forms.Button();
			this.cmbUserCreate = new System.Windows.Forms.ComboBox();
			this.label15 = new System.Windows.Forms.Label();
			this.txtNum = new System.Windows.Forms.TextBox();
			this.labelWorker = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.dateTimePickerDateCreate = new ControlsLbr.NullableDateTimePicker();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.EhhneeGlqI = new System.Windows.Forms.TabPage();
			this.chkSendToSite = new System.Windows.Forms.CheckBox();
			this.cmbGroupWorks = new System.Windows.Forms.ComboBox();
			this.bindingSource_2 = new System.Windows.Forms.BindingSource(this.components);
			this.labelGroupWork = new System.Windows.Forms.Label();
			this.cmbPerformerOrganization = new System.Windows.Forms.ComboBox();
			this.labelPerformer = new System.Windows.Forms.Label();
			this.cmbOrganization = new System.Windows.Forms.ComboBox();
			this.labelOrganization = new System.Windows.Forms.Label();
			this.cmbRegion = new System.Windows.Forms.ComboBox();
			this.txtRequestFiled = new System.Windows.Forms.ComboBox();
			this.toolStripMain = new System.Windows.Forms.ToolStrip();
			this.toolBtnCopy = new System.Windows.Forms.ToolStripButton();
			this.toolBtnSettingsFTP = new System.Windows.Forms.ToolStripButton();
			this.tabPageSwitching = new System.Windows.Forms.TabPage();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.dgvLinkObjects = new ControlsLbr.DataGridViewExcelFilter.DataGridViewExcelFilter();
			this.objectsDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dateBegDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dateEndDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.durationDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.numDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.disabledDgvColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.bsLinkObjects = new System.Windows.Forms.BindingSource(this.components);
			this.dataSet_0 = new System.Data.DataSet();
			this.dataTable_8 = new System.Data.DataTable();
			this.dataColumn_0 = new System.Data.DataColumn();
			this.dataColumn_1 = new System.Data.DataColumn();
			this.dataColumn_2 = new System.Data.DataColumn();
			this.dataColumn_3 = new System.Data.DataColumn();
			this.dataColumn_4 = new System.Data.DataColumn();
			this.dataColumn_16 = new System.Data.DataColumn();
			this.dataTable_9 = new System.Data.DataTable();
			this.dataColumn_5 = new System.Data.DataColumn();
			this.ngrnvWyUkq = new System.Data.DataColumn();
			this.dataColumn_6 = new System.Data.DataColumn();
			this.dataColumn_7 = new System.Data.DataColumn();
			this.dataTable_10 = new System.Data.DataTable();
			this.dataColumn_8 = new System.Data.DataColumn();
			this.dataColumn_9 = new System.Data.DataColumn();
			this.dataColumn_10 = new System.Data.DataColumn();
			this.dataColumn_11 = new System.Data.DataColumn();
			this.dataColumn_12 = new System.Data.DataColumn();
			this.dataColumn_13 = new System.Data.DataColumn();
			this.dataColumn_14 = new System.Data.DataColumn();
			this.dataColumn_15 = new System.Data.DataColumn();
			this.dgvAddress = new ControlsLbr.DataGridViewExcelFilter.DataGridViewExcelFilter();
			this.cityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.idAddressDgvColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.idRequestDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.idKladrObjDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.streetDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.idKladrStreetDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.houseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.bindingSource_3 = new System.Windows.Forms.BindingSource(this.components);
			this.toolStripAddress = new System.Windows.Forms.ToolStrip();
			this.toolBtnAddAddress = new System.Windows.Forms.ToolStripButton();
			this.toolBtnDelAddress = new System.Windows.Forms.ToolStripButton();
			this.tabPageDocuments = new System.Windows.Forms.TabPage();
			this.dgvDocs = new ControlsLbr.DataGridViewExcelFilter.DataGridViewExcelFilter();
			this.idDataGridViewTextBoxColumnDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.idRequestDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.fileNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewLinkColumn();
			this.commentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnImage = new ControlsLbr.DataGridViewExcelFilter.DataGridViewImageColumnNotNull();
			this.bindingSource_1 = new System.Windows.Forms.BindingSource(this.components);
			this.toolStripDocuments = new System.Windows.Forms.ToolStrip();
			this.toolBtnAddDoc = new System.Windows.Forms.ToolStripButton();
			this.toolBtnDelDoc = new System.Windows.Forms.ToolStripButton();
			this.toolBtnViewDoc = new System.Windows.Forms.ToolStripButton();
			this.toolBtnSaveDoc = new System.Windows.Forms.ToolStripButton();
			this.tabPageLog = new System.Windows.Forms.TabPage();
			this.dataGridViewExcelFilter1 = new ControlsLbr.DataGridViewExcelFilter.DataGridViewExcelFilter();
			this.dateLogDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.idDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.idRequestDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.userLogIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.userLogDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.userLogNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.idCommandDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.commandDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.isSiteDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.bindingSource_4 = new System.Windows.Forms.BindingSource(this.components);
			this.buttonCopy = new System.Windows.Forms.Button();
			this.backgroundWorker_0 = new System.ComponentModel.BackgroundWorker();
			this.buttonCancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)this.dataSetN).BeginInit();
			this.groupBox1.SuspendLayout();
			this.toolStripScheme.SuspendLayout();
			this.groupBoxDaily.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.dgvDaily).BeginInit();
			this.groupBox_0.SuspendLayout();
			this.tabControl.SuspendLayout();
			this.EhhneeGlqI.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.bindingSource_2).BeginInit();
			this.toolStripMain.SuspendLayout();
			this.tabPageSwitching.SuspendLayout();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvLinkObjects).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.bsLinkObjects).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.dataSet_0).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.dataTable_8).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.dataTable_9).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.dataTable_10).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.dgvAddress).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.bindingSource_3).BeginInit();
			this.toolStripAddress.SuspendLayout();
			this.tabPageDocuments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvDocs).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.bindingSource_1).BeginInit();
			this.toolStripDocuments.SuspendLayout();
			this.tabPageLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.dataGridViewExcelFilter1).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.bindingSource_4).BeginInit();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(58, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(37, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Автор";
			this.cmbWorker.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cmbWorker.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cmbWorker.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.dataSetN, "tJ_RequestForRepair.idWorker", true));
			this.cmbWorker.FormattingEnabled = true;
			this.cmbWorker.Location = new System.Drawing.Point(288, 66);
			this.cmbWorker.Name = "cmbWorker";
			this.cmbWorker.Size = new System.Drawing.Size(21, 21);
			this.cmbWorker.TabIndex = 3;
			this.cmbWorker.Visible = false;
			this.cmbWorker.SelectedIndexChanged += new System.EventHandler(this.cmbWorker_SelectedIndexChanged);
			this.dataSetN.DataSetName = "DataSetGES";
			this.dataSetN.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			this.labelRequestFiled.AutoSize = true;
			this.labelRequestFiled.Location = new System.Drawing.Point(8, 66);
			this.labelRequestFiled.Name = "labelRequestFiled";
			this.labelRequestFiled.Size = new System.Drawing.Size(76, 13);
			this.labelRequestFiled.TabIndex = 4;
			this.labelRequestFiled.Text = "Заявку подал";
			this.labelSR.AutoSize = true;
			this.labelSR.Location = new System.Drawing.Point(305, 39);
			this.labelSR.Name = "labelSR";
			this.labelSR.Size = new System.Drawing.Size(38, 13);
			this.labelSR.TabIndex = 6;
			this.labelSR.Text = "Район";
			this.cmbSR.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.cmbSR.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cmbSR.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cmbSR.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.dataSetN, "tJ_RequestForRepair.idSR", true));
			this.cmbSR.FormattingEnabled = true;
			this.cmbSR.Location = new System.Drawing.Point(358, 36);
			this.cmbSR.Name = "cmbSR";
			this.cmbSR.Size = new System.Drawing.Size(287, 21);
			this.cmbSR.TabIndex = 7;
			this.cmbSR.SelectedIndexChanged += new System.EventHandler(this.cmbSR_SelectedIndexChanged);
			this.cmbSR.SelectedValueChanged += new System.EventHandler(this.cmbSR_SelectedValueChanged);
			this.groupBox1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.groupBox1.Controls.Add(this.cmbTypeDamage);
			this.groupBox1.Controls.Add(this.cmbTypeDisable);
			this.groupBox1.Controls.Add(this.cmbIsPlanned);
			this.groupBox1.Controls.Add(this.labelIsPlanned);
			this.groupBox1.Controls.Add(this.labelPurpose);
			this.groupBox1.Controls.Add(this.txtPurpose);
			this.groupBox1.Controls.Add(this.txtObject);
			this.groupBox1.Controls.Add(this.labelObject);
			this.groupBox1.Location = new System.Drawing.Point(11, 89);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(634, 97);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			this.cmbTypeDamage.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.cmbTypeDamage.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.dataSetN, "tJ_RequestForRepair.idTypeDamage", true));
			this.cmbTypeDamage.FormattingEnabled = true;
			this.cmbTypeDamage.Location = new System.Drawing.Point(366, 68);
			this.cmbTypeDamage.Name = "cmbTypeDamage";
			this.cmbTypeDamage.Size = new System.Drawing.Size(262, 21);
			this.cmbTypeDamage.TabIndex = 7;
			this.cmbTypeDisable.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cmbTypeDisable.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cmbTypeDisable.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.dataSetN, "tJ_RequestForRepair.typeDisable", true));
			this.cmbTypeDisable.FormattingEnabled = true;
			this.cmbTypeDisable.Items.AddRange(new object[]
			{
				"Аварийный",
				"Плановый"
			});
			this.cmbTypeDisable.Location = new System.Drawing.Point(230, 68);
			this.cmbTypeDisable.Name = "cmbTypeDisable";
			this.cmbTypeDisable.Size = new System.Drawing.Size(121, 21);
			this.cmbTypeDisable.TabIndex = 6;
			this.cmbTypeDisable.SelectedValueChanged += new System.EventHandler(this.cmbTypeDisable_SelectedValueChanged);
			this.cmbIsPlanned.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.dataSetN, "tJ_RequestForRepair.IsPlanned", true));
			this.cmbIsPlanned.FormattingEnabled = true;
			this.cmbIsPlanned.Items.AddRange(new object[]
			{
				"Аварийный",
				"Плановый"
			});
			this.cmbIsPlanned.Location = new System.Drawing.Point(101, 68);
			this.cmbIsPlanned.Name = "cmbIsPlanned";
			this.cmbIsPlanned.Size = new System.Drawing.Size(121, 21);
			this.cmbIsPlanned.TabIndex = 5;
			this.cmbIsPlanned.SelectedIndexChanged += new System.EventHandler(this.cmbIsPlanned_SelectedIndexChanged);
			this.cmbIsPlanned.SelectedValueChanged += new System.EventHandler(this.cmbIsPlanned_SelectedValueChanged);
			this.labelIsPlanned.AutoSize = true;
			this.labelIsPlanned.Location = new System.Drawing.Point(6, 71);
			this.labelIsPlanned.Name = "labelIsPlanned";
			this.labelIsPlanned.Size = new System.Drawing.Size(89, 13);
			this.labelIsPlanned.TabIndex = 4;
			this.labelIsPlanned.Text = "Вид отключения";
			this.labelPurpose.AutoSize = true;
			this.labelPurpose.Location = new System.Drawing.Point(6, 45);
			this.labelPurpose.Name = "labelPurpose";
			this.labelPurpose.Size = new System.Drawing.Size(33, 13);
			this.labelPurpose.TabIndex = 3;
			this.labelPurpose.Text = "Цель";
			this.txtPurpose.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.txtPurpose.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dataSetN, "tJ_RequestForRepair.Purpose", true));
			this.txtPurpose.Location = new System.Drawing.Point(101, 42);
			this.txtPurpose.Name = "txtPurpose";
			this.txtPurpose.Size = new System.Drawing.Size(527, 20);
			this.txtPurpose.TabIndex = 2;
			this.txtPurpose.TextChanged += new System.EventHandler(this.txtPurpose_TextChanged);
			this.txtObject.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.txtObject.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dataSetN, "tJ_RequestForRepair.schmObj", true));
			this.txtObject.Location = new System.Drawing.Point(101, 16);
			this.txtObject.Name = "txtObject";
			this.txtObject.Size = new System.Drawing.Size(527, 20);
			this.txtObject.TabIndex = 1;
			this.txtObject.TextChanged += new System.EventHandler(this.txtObject_TextChanged);
			this.labelObject.AutoSize = true;
			this.labelObject.Location = new System.Drawing.Point(6, 16);
			this.labelObject.Name = "labelObject";
			this.labelObject.Size = new System.Drawing.Size(45, 13);
			this.labelObject.TabIndex = 0;
			this.labelObject.Text = "Объект";
			this.toolStripScheme.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStripScheme.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
			{
				this.toolBtnLinkSchmObj,
				this.toolBtnLinkSchmObjEdit,
				this.toolBtnDelSchmObj,
				this.toolBtnViewSChmObj
			});
			this.toolStripScheme.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
			this.toolStripScheme.Location = new System.Drawing.Point(3, 3);
			this.toolStripScheme.Name = "toolStripScheme";
			this.toolStripScheme.Size = new System.Drawing.Size(724, 25);
			this.toolStripScheme.TabIndex = 47;
			this.toolStripScheme.Text = "toolStrip1";
			this.toolBtnLinkSchmObj.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolBtnLinkSchmObj.Image = RequestsClient.Properties.Resources.ElementAdd;
			this.toolBtnLinkSchmObj.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolBtnLinkSchmObj.Name = "toolBtnLinkSchmObj";
			this.toolBtnLinkSchmObj.Size = new System.Drawing.Size(23, 22);
			this.toolBtnLinkSchmObj.Text = "Привязать к схеме";
			this.toolBtnLinkSchmObj.Click += new System.EventHandler(this.toolBtnLinkSchmObj_Click);
			this.toolBtnLinkSchmObjEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolBtnLinkSchmObjEdit.Image = RequestsClient.Properties.Resources.ElementEdit;
			this.toolBtnLinkSchmObjEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolBtnLinkSchmObjEdit.Name = "toolBtnLinkSchmObjEdit";
			this.toolBtnLinkSchmObjEdit.Size = new System.Drawing.Size(23, 22);
			this.toolBtnLinkSchmObjEdit.Text = "Редактировать";
			this.toolBtnLinkSchmObjEdit.Click += new System.EventHandler(this.toolBtnLinkSchmObjEdit_Click);
			this.toolBtnDelSchmObj.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolBtnDelSchmObj.Image = RequestsClient.Properties.Resources.ElementDel;
			this.toolBtnDelSchmObj.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolBtnDelSchmObj.Name = "toolBtnDelSchmObj";
			this.toolBtnDelSchmObj.Size = new System.Drawing.Size(23, 22);
			this.toolBtnDelSchmObj.Text = "Удалить";
			this.toolBtnDelSchmObj.Click += new System.EventHandler(this.toolBtnDelSchmObj_Click);
			this.toolBtnViewSChmObj.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolBtnViewSChmObj.Enabled = false;
			this.toolBtnViewSChmObj.Image = RequestsClient.Properties.Resources.ElementInformation;
			this.toolBtnViewSChmObj.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolBtnViewSChmObj.Name = "toolBtnViewSChmObj";
			this.toolBtnViewSChmObj.Size = new System.Drawing.Size(23, 22);
			this.toolBtnViewSChmObj.Text = "Показать на схеме";
			this.toolBtnViewSChmObj.Click += new System.EventHandler(this.toolBtnViewSChmObj_Click);
			this.groupBoxDaily.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.groupBoxDaily.Controls.Add(this.dateTimePickerFactEnd);
			this.groupBoxDaily.Controls.Add(this.label3);
			this.groupBoxDaily.Controls.Add(this.buttonDaily);
			this.groupBoxDaily.Controls.Add(this.dgvDaily);
			this.groupBoxDaily.Controls.Add(this.checkBoxWeekEnd);
			this.groupBoxDaily.Controls.Add(this.checkBoxDaily);
			this.groupBoxDaily.Controls.Add(this.dateTimePickerEnd);
			this.groupBoxDaily.Controls.Add(this.label9);
			this.groupBoxDaily.Controls.Add(this.dateTimePickerBeg);
			this.groupBoxDaily.Controls.Add(this.label8);
			this.groupBoxDaily.Location = new System.Drawing.Point(11, 192);
			this.groupBoxDaily.Name = "groupBoxDaily";
			this.groupBoxDaily.Size = new System.Drawing.Size(634, 173);
			this.groupBoxDaily.TabIndex = 10;
			this.groupBoxDaily.TabStop = false;
			this.groupBoxDaily.Text = "Даты отключения";
			this.dateTimePickerFactEnd.CustomFormat = "dd.MM.yyyy HH:mm";
			this.dateTimePickerFactEnd.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.dataSetN, "tJ_RequestForRepair.dateFactEnd", true));
			this.dateTimePickerFactEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerFactEnd.Location = new System.Drawing.Point(351, 144);
			this.dateTimePickerFactEnd.Name = "dateTimePickerFactEnd";
			this.dateTimePickerFactEnd.Size = new System.Drawing.Size(188, 20);
			this.dateTimePickerFactEnd.TabIndex = 16;
			this.dateTimePickerFactEnd.Value = new System.DateTime(2015, 8, 10, 13, 57, 6, 22);
			this.label3.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(175, 148);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(176, 13);
			this.label3.TabIndex = 14;
			this.label3.Text = "Фактическое время выполнения";
			this.buttonDaily.Location = new System.Drawing.Point(9, 115);
			this.buttonDaily.Name = "buttonDaily";
			this.buttonDaily.Size = new System.Drawing.Size(75, 23);
			this.buttonDaily.TabIndex = 13;
			this.buttonDaily.Text = "Добавить";
			this.buttonDaily.UseVisualStyleBackColor = true;
			this.buttonDaily.Click += new System.EventHandler(this.buttonDaily_Click);
			this.dgvDaily.AllowUserToAddRows = false;
			this.dgvDaily.AllowUserToResizeColumns = false;
			this.dgvDaily.AllowUserToResizeRows = false;
			this.dgvDaily.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.dgvDaily.AutoGenerateColumns = false;
			this.dgvDaily.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvDaily.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
			{
				this.idDataGridViewTextBoxColumn,
				this.idRequestDataGridViewTextBoxColumn,
				this.dateBegDataGridViewTextBoxColumn,
				this.dateEndDataGridViewTextBoxColumn
			});
			this.dgvDaily.DataMember = "tJ_RequestForRepairDaily";
			this.dgvDaily.DataSource = this.dataSetN;
			this.dgvDaily.Location = new System.Drawing.Point(178, 8);
			this.dgvDaily.Name = "dgvDaily";
			this.dgvDaily.RowHeadersWidth = 30;
			this.dgvDaily.Size = new System.Drawing.Size(456, 130);
			this.dgvDaily.TabIndex = 12;
			this.dgvDaily.VirtualMode = true;
			this.dgvDaily.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDaily_CellEndEdit);
			this.dgvDaily.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDaily_CellFormatting);
			this.dgvDaily.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvDaily_EditingControlShowing);
			this.dgvDaily.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvDaily_RowsAdded);
			this.dgvDaily.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvDaily_RowsRemoved);
			this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
			this.idDataGridViewTextBoxColumn.HeaderText = "id";
			this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
			this.idDataGridViewTextBoxColumn.ReadOnly = true;
			this.idDataGridViewTextBoxColumn.Visible = false;
			this.idRequestDataGridViewTextBoxColumn.DataPropertyName = "idRequest";
			this.idRequestDataGridViewTextBoxColumn.HeaderText = "idRequest";
			this.idRequestDataGridViewTextBoxColumn.Name = "idRequestDataGridViewTextBoxColumn";
			this.idRequestDataGridViewTextBoxColumn.Visible = false;
			this.dateBegDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.dateBegDataGridViewTextBoxColumn.DataPropertyName = "dateBeg";
			dataGridViewCellStyle.Format = "dd.MM.yyyy HH:mm";
			this.dateBegDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle;
			this.dateBegDataGridViewTextBoxColumn.FillWeight = 50f;
			this.dateBegDataGridViewTextBoxColumn.HeaderText = "Начало";
			this.dateBegDataGridViewTextBoxColumn.Name = "dateBegDataGridViewTextBoxColumn";
			this.dateBegDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dateEndDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.dateEndDataGridViewTextBoxColumn.DataPropertyName = "dateEnd";
			dataGridViewCellStyle2.Format = "dd.MM.yyyy HH:mm";
			this.dateEndDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
			this.dateEndDataGridViewTextBoxColumn.FillWeight = 50f;
			this.dateEndDataGridViewTextBoxColumn.HeaderText = "Окончание";
			this.dateEndDataGridViewTextBoxColumn.Name = "dateEndDataGridViewTextBoxColumn";
			this.dateEndDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.checkBoxWeekEnd.AutoSize = true;
			this.checkBoxWeekEnd.Checked = true;
			this.checkBoxWeekEnd.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxWeekEnd.Enabled = false;
			this.checkBoxWeekEnd.Location = new System.Drawing.Point(9, 92);
			this.checkBoxWeekEnd.Name = "checkBoxWeekEnd";
			this.checkBoxWeekEnd.Size = new System.Drawing.Size(78, 17);
			this.checkBoxWeekEnd.TabIndex = 11;
			this.checkBoxWeekEnd.Text = "Выходные";
			this.checkBoxWeekEnd.UseVisualStyleBackColor = true;
			this.checkBoxDaily.AutoSize = true;
			this.checkBoxDaily.Location = new System.Drawing.Point(9, 69);
			this.checkBoxDaily.Name = "checkBoxDaily";
			this.checkBoxDaily.Size = new System.Drawing.Size(83, 17);
			this.checkBoxDaily.TabIndex = 10;
			this.checkBoxDaily.Text = "Ежедневно";
			this.checkBoxDaily.UseVisualStyleBackColor = true;
			this.checkBoxDaily.CheckedChanged += new System.EventHandler(this.checkBoxDaily_CheckedChanged);
			this.dateTimePickerEnd.CustomFormat = "dd.MM.yyyy HH:mm";
			this.dateTimePickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerEnd.Location = new System.Drawing.Point(30, 43);
			this.dateTimePickerEnd.Name = "dateTimePickerEnd";
			this.dateTimePickerEnd.Size = new System.Drawing.Size(124, 20);
			this.dateTimePickerEnd.TabIndex = 1;
			this.dateTimePickerEnd.ValueChanged += new System.EventHandler(this.dateTimePickerEnd_ValueChanged);
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(6, 50);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(19, 13);
			this.label9.TabIndex = 9;
			this.label9.Text = "по";
			this.dateTimePickerBeg.CustomFormat = "dd.MM.yyyy HH:mm";
			this.dateTimePickerBeg.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerBeg.Location = new System.Drawing.Point(30, 19);
			this.dateTimePickerBeg.Name = "dateTimePickerBeg";
			this.dateTimePickerBeg.Size = new System.Drawing.Size(124, 20);
			this.dateTimePickerBeg.TabIndex = 0;
			this.dateTimePickerBeg.ValueChanged += new System.EventHandler(this.dateTimePickerBeg_ValueChanged);
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(11, 22);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(13, 13);
			this.label8.TabIndex = 8;
			this.label8.Text = "с";
			this.groupBox_0.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.groupBox_0.Controls.Add(this.cmbStatus);
			this.groupBox_0.Controls.Add(this.labelStatus);
			this.groupBox_0.Controls.Add(this.txtAdress);
			this.groupBox_0.Controls.Add(this.cmbDispatcher);
			this.groupBox_0.Controls.Add(this.label14);
			this.groupBox_0.Controls.Add(this.label13);
			this.groupBox_0.Controls.Add(this.dateTimePickerDateAgreed);
			this.groupBox_0.Controls.Add(this.rWoeDxUpjP);
			this.groupBox_0.Controls.Add(this.labelAddress);
			this.groupBox_0.Controls.Add(this.label11);
			this.groupBox_0.Controls.Add(this.label10);
			this.groupBox_0.Controls.Add(this.txtComment);
			this.groupBox_0.Controls.Add(this.txtAgreeWith);
			this.groupBox_0.Location = new System.Drawing.Point(11, 411);
			this.groupBox_0.Name = "groupBoxODS";
			this.groupBox_0.Size = new System.Drawing.Size(634, 200);
			this.groupBox_0.TabIndex = 9;
			this.groupBox_0.TabStop = false;
			this.groupBox_0.VisibleChanged += new System.EventHandler(this.groupBox_0_VisibleChanged);
			this.cmbStatus.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.cmbStatus.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.dataSetN, "tJ_RequestForRepair.status", true));
			this.cmbStatus.FormattingEnabled = true;
			this.cmbStatus.Location = new System.Drawing.Point(160, 170);
			this.cmbStatus.Name = "cmbStatus";
			this.cmbStatus.Size = new System.Drawing.Size(379, 21);
			this.cmbStatus.TabIndex = 13;
			this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
			this.labelStatus.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.labelStatus.AutoSize = true;
			this.labelStatus.Location = new System.Drawing.Point(74, 173);
			this.labelStatus.Name = "labelStatus";
			this.labelStatus.Size = new System.Drawing.Size(80, 13);
			this.labelStatus.TabIndex = 12;
			this.labelStatus.Text = "Статус заявки";
			this.txtAdress.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.txtAdress.BackColor = System.Drawing.SystemColors.Window;
			this.txtAdress.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dataSetN, "tJ_RequestForRepair.Address", true));
			this.txtAdress.Location = new System.Drawing.Point(101, 71);
			this.txtAdress.Multiline = true;
			this.txtAdress.Name = "txtAdress";
			this.txtAdress.ReadOnly = true;
			this.txtAdress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtAdress.Size = new System.Drawing.Size(527, 72);
			this.txtAdress.TabIndex = 11;
			this.cmbDispatcher.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.cmbDispatcher.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cmbDispatcher.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cmbDispatcher.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.dataSetN, "tJ_RequestForRepair.WorkerAgreed", true));
			this.cmbDispatcher.FormattingEnabled = true;
			this.cmbDispatcher.Location = new System.Drawing.Point(412, 145);
			this.cmbDispatcher.Name = "cmbDispatcher";
			this.cmbDispatcher.Size = new System.Drawing.Size(216, 21);
			this.cmbDispatcher.TabIndex = 10;
			this.label14.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(329, 151);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(77, 13);
			this.label14.TabIndex = 9;
			this.label14.Text = "Согласующий";
			this.label13.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(121, 153);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(33, 13);
			this.label13.TabIndex = 8;
			this.label13.Text = "Дата";
			this.dateTimePickerDateAgreed.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.dateTimePickerDateAgreed.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.dataSetN, "tJ_RequestForRepair.DateAgreed", true));
			this.dateTimePickerDateAgreed.Location = new System.Drawing.Point(160, 147);
			this.dateTimePickerDateAgreed.Name = "dateTimePickerDateAgreed";
			this.dateTimePickerDateAgreed.Size = new System.Drawing.Size(163, 20);
			this.dateTimePickerDateAgreed.TabIndex = 7;
			this.dateTimePickerDateAgreed.Value = new System.DateTime(2012, 9, 26, 9, 58, 28, 932);
			this.rWoeDxUpjP.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.rWoeDxUpjP.AutoSize = true;
			this.rWoeDxUpjP.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.dataSetN, "tJ_RequestForRepair.Agreed", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.rWoeDxUpjP.Location = new System.Drawing.Point(9, 150);
			this.rWoeDxUpjP.Name = "checkBoxAgreed";
			this.rWoeDxUpjP.Size = new System.Drawing.Size(92, 17);
			this.rWoeDxUpjP.TabIndex = 6;
			this.rWoeDxUpjP.Text = "Согласовано";
			this.rWoeDxUpjP.UseVisualStyleBackColor = true;
			this.rWoeDxUpjP.CheckedChanged += new System.EventHandler(this.rWoeDxUpjP_CheckedChanged);
			this.rWoeDxUpjP.CheckStateChanged += new System.EventHandler(this.rWoeDxUpjP_CheckStateChanged);
			this.labelAddress.AutoSize = true;
			this.labelAddress.Location = new System.Drawing.Point(6, 74);
			this.labelAddress.Name = "labelAddress";
			this.labelAddress.Size = new System.Drawing.Size(44, 13);
			this.labelAddress.TabIndex = 5;
			this.labelAddress.Text = "Адреса";
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(6, 48);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(77, 13);
			this.label11.TabIndex = 4;
			this.label11.Text = "Комментарий";
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(6, 22);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(81, 13);
			this.label10.TabIndex = 3;
			this.label10.Text = "Согласовать с";
			this.txtComment.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.txtComment.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dataSetN, "tJ_RequestForRepair.Comment", true));
			this.txtComment.Location = new System.Drawing.Point(101, 45);
			this.txtComment.Name = "txtComment";
			this.txtComment.Size = new System.Drawing.Size(527, 20);
			this.txtComment.TabIndex = 1;
			this.txtAgreeWith.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.txtAgreeWith.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dataSetN, "tJ_RequestForRepair.AgreeWith", true));
			this.txtAgreeWith.Location = new System.Drawing.Point(101, 19);
			this.txtAgreeWith.Name = "txtAgreeWith";
			this.txtAgreeWith.Size = new System.Drawing.Size(527, 20);
			this.txtAgreeWith.TabIndex = 0;
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Location = new System.Drawing.Point(15, 678);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 10;
			this.buttonOK.Text = "ОК";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			this.cmbUserCreate.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.dataSetN, "tJ_RequestForRepair.idUserCreate", true));
			this.cmbUserCreate.Enabled = false;
			this.cmbUserCreate.FormattingEnabled = true;
			this.cmbUserCreate.Location = new System.Drawing.Point(101, 5);
			this.cmbUserCreate.Name = "cmbUserCreate";
			this.cmbUserCreate.Size = new System.Drawing.Size(181, 21);
			this.cmbUserCreate.TabIndex = 12;
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(302, 8);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(41, 13);
			this.label15.TabIndex = 13;
			this.label15.Text = "Номер";
			this.txtNum.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.txtNum.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dataSetN, "tJ_RequestForRepair.num", true));
			this.txtNum.Location = new System.Drawing.Point(358, 5);
			this.txtNum.Name = "txtNum";
			this.txtNum.ReadOnly = true;
			this.txtNum.Size = new System.Drawing.Size(287, 20);
			this.txtNum.TabIndex = 14;
			this.labelWorker.AutoSize = true;
			this.labelWorker.Location = new System.Drawing.Point(276, 86);
			this.labelWorker.Name = "labelWorker";
			this.labelWorker.Size = new System.Drawing.Size(56, 13);
			this.labelWorker.TabIndex = 15;
			this.labelWorker.Text = "Оператор";
			this.labelWorker.Visible = false;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(8, 39);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(84, 13);
			this.label2.TabIndex = 16;
			this.label2.Text = "Дата создания";
			this.dateTimePickerDateCreate.CustomFormat = "dd.MM.yyyy HH:mm";
			this.dateTimePickerDateCreate.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.dataSetN, "tJ_RequestForRepair.dateCreate", true));
			this.dateTimePickerDateCreate.Enabled = false;
			this.dateTimePickerDateCreate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerDateCreate.Location = new System.Drawing.Point(101, 37);
			this.dateTimePickerDateCreate.Name = "dateTimePickerDateCreate";
			this.dateTimePickerDateCreate.Size = new System.Drawing.Size(181, 20);
			this.dateTimePickerDateCreate.TabIndex = 17;
			this.dateTimePickerDateCreate.Value = new System.DateTime(2012, 10, 18, 8, 39, 41, 178);
			this.tabControl.Controls.Add(this.EhhneeGlqI);
			this.tabControl.Controls.Add(this.tabPageSwitching);
			this.tabControl.Controls.Add(this.tabPageDocuments);
			this.tabControl.Controls.Add(this.tabPageLog);
			this.tabControl.Location = new System.Drawing.Point(0, 0);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(665, 669);
			this.tabControl.TabIndex = 49;
			this.EhhneeGlqI.Controls.Add(this.chkSendToSite);
			this.EhhneeGlqI.Controls.Add(this.cmbGroupWorks);
			this.EhhneeGlqI.Controls.Add(this.labelGroupWork);
			this.EhhneeGlqI.Controls.Add(this.cmbPerformerOrganization);
			this.EhhneeGlqI.Controls.Add(this.labelPerformer);
			this.EhhneeGlqI.Controls.Add(this.cmbOrganization);
			this.EhhneeGlqI.Controls.Add(this.labelOrganization);
			this.EhhneeGlqI.Controls.Add(this.cmbRegion);
			this.EhhneeGlqI.Controls.Add(this.txtRequestFiled);
			this.EhhneeGlqI.Controls.Add(this.toolStripMain);
			this.EhhneeGlqI.Controls.Add(this.cmbSR);
			this.EhhneeGlqI.Controls.Add(this.label1);
			this.EhhneeGlqI.Controls.Add(this.groupBoxDaily);
			this.EhhneeGlqI.Controls.Add(this.cmbWorker);
			this.EhhneeGlqI.Controls.Add(this.labelRequestFiled);
			this.EhhneeGlqI.Controls.Add(this.groupBox_0);
			this.EhhneeGlqI.Controls.Add(this.dateTimePickerDateCreate);
			this.EhhneeGlqI.Controls.Add(this.label2);
			this.EhhneeGlqI.Controls.Add(this.groupBox1);
			this.EhhneeGlqI.Controls.Add(this.labelSR);
			this.EhhneeGlqI.Controls.Add(this.labelWorker);
			this.EhhneeGlqI.Controls.Add(this.cmbUserCreate);
			this.EhhneeGlqI.Controls.Add(this.txtNum);
			this.EhhneeGlqI.Controls.Add(this.label15);
			this.EhhneeGlqI.Location = new System.Drawing.Point(4, 22);
			this.EhhneeGlqI.Name = "tabPageGeneral";
			this.EhhneeGlqI.Padding = new System.Windows.Forms.Padding(3);
			this.EhhneeGlqI.Size = new System.Drawing.Size(657, 643);
			this.EhhneeGlqI.TabIndex = 0;
			this.EhhneeGlqI.Text = "Общие";
			this.EhhneeGlqI.UseVisualStyleBackColor = true;
			this.chkSendToSite.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.chkSendToSite.AutoSize = true;
			this.chkSendToSite.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.dataSetN, "tJ_RequestForRepair.SendSite", true));
			this.chkSendToSite.Location = new System.Drawing.Point(20, 620);
			this.chkSendToSite.Name = "chkSendToSite";
			this.chkSendToSite.Size = new System.Drawing.Size(121, 17);
			this.chkSendToSite.TabIndex = 27;
			this.chkSendToSite.Text = "Отправить на сайт";
			this.chkSendToSite.UseVisualStyleBackColor = true;
			this.cmbGroupWorks.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindingSource_2, "groupWorks", true));
			this.cmbGroupWorks.FormattingEnabled = true;
			this.cmbGroupWorks.Location = new System.Drawing.Point(391, 384);
			this.cmbGroupWorks.Name = "cmbGroupWorks";
			this.cmbGroupWorks.Size = new System.Drawing.Size(159, 21);
			this.cmbGroupWorks.TabIndex = 26;
			this.cmbGroupWorks.SelectedIndexChanged += new System.EventHandler(this.cmbGroupWorks_SelectedIndexChanged);
			this.bindingSource_2.DataMember = "tJ_RequestForRepair";
			this.bindingSource_2.DataSource = this.dataSetN;
			this.labelGroupWork.AutoSize = true;
			this.labelGroupWork.Location = new System.Drawing.Point(388, 368);
			this.labelGroupWork.Name = "labelGroupWork";
			this.labelGroupWork.Size = new System.Drawing.Size(74, 13);
			this.labelGroupWork.TabIndex = 25;
			this.labelGroupWork.Text = "Группа работ";
			this.cmbPerformerOrganization.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.dataSetN, "tJ_RequestForRepair.performerOrganization", true));
			this.cmbPerformerOrganization.FormattingEnabled = true;
			this.cmbPerformerOrganization.Location = new System.Drawing.Point(189, 384);
			this.cmbPerformerOrganization.Name = "cmbPerformerOrganization";
			this.cmbPerformerOrganization.Size = new System.Drawing.Size(193, 21);
			this.cmbPerformerOrganization.TabIndex = 24;
			this.cmbPerformerOrganization.SelectedIndexChanged += new System.EventHandler(this.cmbPerformerOrganization_SelectedIndexChanged);
			this.labelPerformer.AutoSize = true;
			this.labelPerformer.Location = new System.Drawing.Point(186, 368);
			this.labelPerformer.Name = "labelPerformer";
			this.labelPerformer.Size = new System.Drawing.Size(144, 13);
			this.labelPerformer.TabIndex = 23;
			this.labelPerformer.Text = "Фактический исполнитель";
			this.cmbOrganization.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.dataSetN, "tJ_RequestForRepair.organization", true));
			this.cmbOrganization.FormattingEnabled = true;
			this.cmbOrganization.Location = new System.Drawing.Point(20, 384);
			this.cmbOrganization.Name = "cmbOrganization";
			this.cmbOrganization.Size = new System.Drawing.Size(163, 21);
			this.cmbOrganization.TabIndex = 22;
			this.cmbOrganization.SelectedIndexChanged += new System.EventHandler(this.cmbOrganization_SelectedIndexChanged);
			this.labelOrganization.AutoSize = true;
			this.labelOrganization.Location = new System.Drawing.Point(17, 368);
			this.labelOrganization.Name = "labelOrganization";
			this.labelOrganization.Size = new System.Drawing.Size(111, 13);
			this.labelOrganization.TabIndex = 21;
			this.labelOrganization.Text = "Ответственное лицо";
			this.cmbRegion.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.cmbRegion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cmbRegion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cmbRegion.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.dataSetN, "tJ_RequestForRepair.idRegion", true));
			this.cmbRegion.FormattingEnabled = true;
			this.cmbRegion.Location = new System.Drawing.Point(358, 63);
			this.cmbRegion.Name = "cmbRegion";
			this.cmbRegion.Size = new System.Drawing.Size(287, 21);
			this.cmbRegion.TabIndex = 20;
			this.cmbRegion.SelectedValueChanged += new System.EventHandler(this.cmbRegion_SelectedValueChanged);
			this.txtRequestFiled.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.txtRequestFiled.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.txtRequestFiled.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dataSetN, "tJ_RequestForRepair.reguestFiled", true));
			this.txtRequestFiled.FormattingEnabled = true;
			this.txtRequestFiled.Location = new System.Drawing.Point(101, 62);
			this.txtRequestFiled.Name = "txtRequestFiled";
			this.txtRequestFiled.Size = new System.Drawing.Size(181, 21);
			this.txtRequestFiled.TabIndex = 19;
			this.txtRequestFiled.SelectedIndexChanged += new System.EventHandler(this.txtRequestFiled_SelectedIndexChanged);
			this.toolStripMain.Dock = System.Windows.Forms.DockStyle.None;
			this.toolStripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
			{
				this.toolBtnCopy,
				this.toolBtnSettingsFTP
			});
			this.toolStripMain.Location = new System.Drawing.Point(0, 0);
			this.toolStripMain.Name = "toolStripMain";
			this.toolStripMain.Size = new System.Drawing.Size(26, 25);
			this.toolStripMain.TabIndex = 18;
			this.toolStripMain.Text = "toolStrip1";
			this.toolBtnCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolBtnCopy.Image = RequestsClient.Properties.Resources.CopyBuffer;
			this.toolBtnCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolBtnCopy.Name = "toolBtnCopy";
			this.toolBtnCopy.Size = new System.Drawing.Size(23, 22);
			this.toolBtnCopy.Text = "Копировать";
			this.toolBtnCopy.Click += new System.EventHandler(this.buttonCopy_Click);
			this.toolBtnSettingsFTP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolBtnSettingsFTP.Image = RequestsClient.Properties.Resources.FTP;
			this.toolBtnSettingsFTP.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolBtnSettingsFTP.Name = "toolBtnSettingsFTP";
			this.toolBtnSettingsFTP.Size = new System.Drawing.Size(23, 22);
			this.toolBtnSettingsFTP.Text = "Настройки FTP";
			this.toolBtnSettingsFTP.Visible = false;
			this.toolBtnSettingsFTP.Click += new System.EventHandler(this.toolBtnSettingsFTP_Click);
			this.tabPageSwitching.Controls.Add(this.splitContainer1);
			this.tabPageSwitching.Controls.Add(this.toolStripScheme);
			this.tabPageSwitching.Location = new System.Drawing.Point(4, 22);
			this.tabPageSwitching.Name = "tabPageSwitching";
			this.tabPageSwitching.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageSwitching.Size = new System.Drawing.Size(730, 643);
			this.tabPageSwitching.TabIndex = 1;
			this.tabPageSwitching.Text = "Оперативные переключения";
			this.tabPageSwitching.UseVisualStyleBackColor = true;
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(3, 28);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			this.splitContainer1.Panel1.Controls.Add(this.dgvLinkObjects);
			this.splitContainer1.Panel2.Controls.Add(this.dgvAddress);
			this.splitContainer1.Panel2.Controls.Add(this.toolStripAddress);
			this.splitContainer1.Size = new System.Drawing.Size(724, 612);
			this.splitContainer1.SplitterDistance = 276;
			this.splitContainer1.TabIndex = 50;
			this.dgvLinkObjects.AllowUserToAddRows = false;
			this.dgvLinkObjects.AllowUserToDeleteRows = false;
			this.dgvLinkObjects.AllowUserToVisibleColumns = false;
			this.dgvLinkObjects.AutoGenerateColumns = false;
			this.dgvLinkObjects.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dgvLinkObjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvLinkObjects.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
			{
				this.objectsDataGridViewTextBoxColumn1,
				this.dateBegDataGridViewTextBoxColumn2,
				this.dateEndDataGridViewTextBoxColumn2,
				this.durationDataGridViewTextBoxColumn1,
				this.numDataGridViewTextBoxColumn1,
				this.disabledDgvColumn
			});
			this.dgvLinkObjects.DataSource = this.bsLinkObjects;
			this.dgvLinkObjects.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvLinkObjects.Location = new System.Drawing.Point(0, 0);
			this.dgvLinkObjects.Name = "dgvLinkObjects";
			this.dgvLinkObjects.ReadOnly = true;
			this.dgvLinkObjects.RowHeadersWidth = 21;
			this.dgvLinkObjects.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dgvLinkObjects.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvLinkObjects.Size = new System.Drawing.Size(724, 276);
			this.dgvLinkObjects.TabIndex = 49;
			this.dgvLinkObjects.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLinkObjects_CellDoubleClick);
			this.dgvLinkObjects.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvLinkObjects_CellFormatting);
			this.objectsDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.objectsDataGridViewTextBoxColumn1.DataPropertyName = "Objects";
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.objectsDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle3;
			this.objectsDataGridViewTextBoxColumn1.HeaderText = "Объекты";
			this.objectsDataGridViewTextBoxColumn1.Name = "objectsDataGridViewTextBoxColumn1";
			this.objectsDataGridViewTextBoxColumn1.ReadOnly = true;
			this.objectsDataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.dateBegDataGridViewTextBoxColumn2.DataPropertyName = "DateBeg";
			this.dateBegDataGridViewTextBoxColumn2.HeaderText = "Начало";
			this.dateBegDataGridViewTextBoxColumn2.Name = "dateBegDataGridViewTextBoxColumn2";
			this.dateBegDataGridViewTextBoxColumn2.ReadOnly = true;
			this.dateBegDataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.dateBegDataGridViewTextBoxColumn2.Width = 90;
			this.dateEndDataGridViewTextBoxColumn2.DataPropertyName = "DateEnd";
			this.dateEndDataGridViewTextBoxColumn2.HeaderText = "Окончание";
			this.dateEndDataGridViewTextBoxColumn2.Name = "dateEndDataGridViewTextBoxColumn2";
			this.dateEndDataGridViewTextBoxColumn2.ReadOnly = true;
			this.dateEndDataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.dateEndDataGridViewTextBoxColumn2.Width = 90;
			this.durationDataGridViewTextBoxColumn1.DataPropertyName = "Duration";
			this.durationDataGridViewTextBoxColumn1.HeaderText = "Длительность";
			this.durationDataGridViewTextBoxColumn1.Name = "durationDataGridViewTextBoxColumn1";
			this.durationDataGridViewTextBoxColumn1.ReadOnly = true;
			this.durationDataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.durationDataGridViewTextBoxColumn1.Width = 90;
			this.numDataGridViewTextBoxColumn1.DataPropertyName = "Num";
			this.numDataGridViewTextBoxColumn1.HeaderText = "Num";
			this.numDataGridViewTextBoxColumn1.Name = "numDataGridViewTextBoxColumn1";
			this.numDataGridViewTextBoxColumn1.ReadOnly = true;
			this.numDataGridViewTextBoxColumn1.Visible = false;
			this.disabledDgvColumn.DataPropertyName = "Disabled";
			this.disabledDgvColumn.HeaderText = "Disabled";
			this.disabledDgvColumn.Name = "disabledDgvColumn";
			this.disabledDgvColumn.ReadOnly = true;
			this.disabledDgvColumn.Visible = false;
			this.bsLinkObjects.DataMember = "tableLinkObjects";
			this.bsLinkObjects.DataSource = this.dataSet_0;
			this.bsLinkObjects.Sort = "Num";
			this.dataSet_0.DataSetName = "NewDataSet";
			this.dataSet_0.Tables.AddRange(new System.Data.DataTable[]
			{
				this.dataTable_8,
				this.dataTable_9,
				this.dataTable_10
			});
			this.dataTable_8.Columns.AddRange(new System.Data.DataColumn[]
			{
				this.dataColumn_0,
				this.dataColumn_1,
				this.dataColumn_2,
				this.dataColumn_3,
				this.dataColumn_4,
				this.dataColumn_16
			});
			this.dataTable_8.TableName = "tableLinkObjects";
			this.dataColumn_0.ColumnName = "Objects";
			this.dataColumn_1.ColumnName = "DateBeg";
			this.dataColumn_1.DataType = typeof(System.DateTime);
			this.dataColumn_2.ColumnName = "DateEnd";
			this.dataColumn_2.DataType = typeof(System.DateTime);
			this.dataColumn_3.ColumnName = "Duration";
			this.dataColumn_4.ColumnName = "Num";
			this.dataColumn_4.DataType = typeof(short);
			this.dataColumn_16.ColumnName = "Disabled";
			this.dataColumn_16.DataType = typeof(bool);
			this.dataTable_9.Columns.AddRange(new System.Data.DataColumn[]
			{
				this.dataColumn_5,
				this.ngrnvWyUkq,
				this.dataColumn_6,
				this.dataColumn_7
			});
			this.dataTable_9.TableName = "tJ_RequestForReapirDoc";
			this.dataColumn_5.AllowDBNull = false;
			this.dataColumn_5.AutoIncrement = true;
			this.dataColumn_5.ColumnName = "id";
			this.dataColumn_5.DataType = typeof(int);
			this.ngrnvWyUkq.AllowDBNull = false;
			this.ngrnvWyUkq.ColumnName = "idRequest";
			this.ngrnvWyUkq.DataType = typeof(int);
			this.dataColumn_6.ColumnName = "FileName";
			this.dataColumn_7.ColumnName = "Comment";
			this.dataTable_10.Columns.AddRange(new System.Data.DataColumn[]
			{
				this.dataColumn_8,
				this.dataColumn_9,
				this.dataColumn_10,
				this.dataColumn_11,
				this.dataColumn_12,
				this.dataColumn_13,
				this.dataColumn_14,
				this.dataColumn_15
			});
			this.dataTable_10.TableName = "tableAddress";
			this.dataColumn_8.ColumnName = "id";
			this.dataColumn_8.DataType = typeof(int);
			this.dataColumn_9.ColumnName = "idRequest";
			this.dataColumn_9.DataType = typeof(int);
			this.dataColumn_10.ColumnName = "City";
			this.dataColumn_11.ColumnName = "idKladrObj";
			this.dataColumn_11.DataType = typeof(int);
			this.dataColumn_12.ColumnName = "Street";
			this.dataColumn_13.ColumnName = "idKladrStreet";
			this.dataColumn_13.DataType = typeof(int);
			this.dataColumn_14.ColumnName = "House";
			this.dataColumn_15.ColumnName = "Name";
			this.dgvAddress.AllowUserToAddRows = false;
			this.dgvAddress.AllowUserToDeleteRows = false;
			this.dgvAddress.AutoGenerateColumns = false;
			this.dgvAddress.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvAddress.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
			{
				this.cityDataGridViewTextBoxColumn,
				this.idAddressDgvColumn,
				this.idRequestDataGridViewTextBoxColumn2,
				this.idKladrObjDataGridViewTextBoxColumn,
				this.streetDataGridViewTextBoxColumn,
				this.idKladrStreetDataGridViewTextBoxColumn,
				this.houseDataGridViewTextBoxColumn,
				this.nameDataGridViewTextBoxColumn
			});
			this.dgvAddress.DataSource = this.bindingSource_3;
			this.dgvAddress.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvAddress.Location = new System.Drawing.Point(0, 25);
			this.dgvAddress.Name = "dgvAddress";
			this.dgvAddress.ReadOnly = true;
			this.dgvAddress.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvAddress.Size = new System.Drawing.Size(724, 307);
			this.dgvAddress.TabIndex = 1;
			this.cityDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.cityDataGridViewTextBoxColumn.DataPropertyName = "City";
			this.cityDataGridViewTextBoxColumn.FillWeight = 30f;
			this.cityDataGridViewTextBoxColumn.HeaderText = "Нас пункт";
			this.cityDataGridViewTextBoxColumn.Name = "cityDataGridViewTextBoxColumn";
			this.cityDataGridViewTextBoxColumn.ReadOnly = true;
			this.idAddressDgvColumn.DataPropertyName = "id";
			this.idAddressDgvColumn.HeaderText = "id";
			this.idAddressDgvColumn.Name = "idAddressDgvColumn";
			this.idAddressDgvColumn.ReadOnly = true;
			this.idAddressDgvColumn.Visible = false;
			this.idRequestDataGridViewTextBoxColumn2.DataPropertyName = "idRequest";
			this.idRequestDataGridViewTextBoxColumn2.HeaderText = "idRequest";
			this.idRequestDataGridViewTextBoxColumn2.Name = "idRequestDataGridViewTextBoxColumn2";
			this.idRequestDataGridViewTextBoxColumn2.ReadOnly = true;
			this.idRequestDataGridViewTextBoxColumn2.Visible = false;
			this.idKladrObjDataGridViewTextBoxColumn.DataPropertyName = "idKladrObj";
			this.idKladrObjDataGridViewTextBoxColumn.HeaderText = "idKladrObj";
			this.idKladrObjDataGridViewTextBoxColumn.Name = "idKladrObjDataGridViewTextBoxColumn";
			this.idKladrObjDataGridViewTextBoxColumn.ReadOnly = true;
			this.idKladrObjDataGridViewTextBoxColumn.Visible = false;
			this.streetDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.streetDataGridViewTextBoxColumn.DataPropertyName = "Street";
			this.streetDataGridViewTextBoxColumn.FillWeight = 50f;
			this.streetDataGridViewTextBoxColumn.HeaderText = "Улица";
			this.streetDataGridViewTextBoxColumn.Name = "streetDataGridViewTextBoxColumn";
			this.streetDataGridViewTextBoxColumn.ReadOnly = true;
			this.idKladrStreetDataGridViewTextBoxColumn.DataPropertyName = "idKladrStreet";
			this.idKladrStreetDataGridViewTextBoxColumn.HeaderText = "idKladrStreet";
			this.idKladrStreetDataGridViewTextBoxColumn.Name = "idKladrStreetDataGridViewTextBoxColumn";
			this.idKladrStreetDataGridViewTextBoxColumn.ReadOnly = true;
			this.idKladrStreetDataGridViewTextBoxColumn.Visible = false;
			this.houseDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.houseDataGridViewTextBoxColumn.DataPropertyName = "House";
			this.houseDataGridViewTextBoxColumn.FillWeight = 20f;
			this.houseDataGridViewTextBoxColumn.HeaderText = "Дом";
			this.houseDataGridViewTextBoxColumn.Name = "houseDataGridViewTextBoxColumn";
			this.houseDataGridViewTextBoxColumn.ReadOnly = true;
			this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
			this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
			this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
			this.nameDataGridViewTextBoxColumn.ReadOnly = true;
			this.nameDataGridViewTextBoxColumn.Visible = false;
			this.bindingSource_3.DataMember = "tableAddress";
			this.bindingSource_3.DataSource = this.dataSet_0;
			this.bindingSource_3.Sort = "City, Street, House";
			this.toolStripAddress.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
			{
				this.toolBtnAddAddress,
				this.toolBtnDelAddress
			});
			this.toolStripAddress.Location = new System.Drawing.Point(0, 0);
			this.toolStripAddress.Name = "toolStripAddress";
			this.toolStripAddress.Size = new System.Drawing.Size(724, 25);
			this.toolStripAddress.TabIndex = 0;
			this.toolStripAddress.Text = "toolStrip1";
			this.toolBtnAddAddress.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolBtnAddAddress.Image = RequestsClient.Properties.Resources.ElementAdd;
			this.toolBtnAddAddress.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolBtnAddAddress.Name = "toolBtnAddAddress";
			this.toolBtnAddAddress.Size = new System.Drawing.Size(23, 22);
			this.toolBtnAddAddress.Text = "Добавить адрес";
			this.toolBtnAddAddress.Click += new System.EventHandler(this.avQgwXctpp);
			this.toolBtnDelAddress.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolBtnDelAddress.Image = RequestsClient.Properties.Resources.ElementDel;
			this.toolBtnDelAddress.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolBtnDelAddress.Name = "toolBtnDelAddress";
			this.toolBtnDelAddress.Size = new System.Drawing.Size(23, 22);
			this.toolBtnDelAddress.Text = "Удалить адрес";
			this.toolBtnDelAddress.Click += new System.EventHandler(this.toolBtnDelAddress_Click);
			this.tabPageDocuments.Controls.Add(this.dgvDocs);
			this.tabPageDocuments.Controls.Add(this.toolStripDocuments);
			this.tabPageDocuments.Location = new System.Drawing.Point(4, 22);
			this.tabPageDocuments.Name = "tabPageDocuments";
			this.tabPageDocuments.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageDocuments.Size = new System.Drawing.Size(730, 643);
			this.tabPageDocuments.TabIndex = 2;
			this.tabPageDocuments.Text = "Документы";
			this.tabPageDocuments.UseVisualStyleBackColor = true;
			this.dgvDocs.AllowUserToAddRows = false;
			this.dgvDocs.AllowUserToDeleteRows = false;
			this.dgvDocs.AutoGenerateColumns = false;
			this.dgvDocs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvDocs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
			{
				this.idDataGridViewTextBoxColumnDoc,
				this.idRequestDataGridViewTextBoxColumn1,
				this.fileNameDataGridViewTextBoxColumn,
				this.commentDataGridViewTextBoxColumn,
				this.ColumnImage
			});
			this.dgvDocs.DataSource = this.bindingSource_1;
			this.dgvDocs.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvDocs.Location = new System.Drawing.Point(3, 28);
			this.dgvDocs.Name = "dgvDocs";
			this.dgvDocs.RowHeadersWidth = 21;
			this.dgvDocs.Size = new System.Drawing.Size(724, 612);
			this.dgvDocs.TabIndex = 1;
			this.dgvDocs.VirtualMode = true;
			this.dgvDocs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocs_CellContentClick);
			this.dgvDocs.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgvDocs_CellValueNeeded);
			this.idDataGridViewTextBoxColumnDoc.DataPropertyName = "id";
			this.idDataGridViewTextBoxColumnDoc.HeaderText = "id";
			this.idDataGridViewTextBoxColumnDoc.Name = "idDataGridViewTextBoxColumnDoc";
			this.idDataGridViewTextBoxColumnDoc.ReadOnly = true;
			this.idDataGridViewTextBoxColumnDoc.Visible = false;
			this.idRequestDataGridViewTextBoxColumn1.DataPropertyName = "idRequest";
			this.idRequestDataGridViewTextBoxColumn1.HeaderText = "idRequest";
			this.idRequestDataGridViewTextBoxColumn1.Name = "idRequestDataGridViewTextBoxColumn1";
			this.idRequestDataGridViewTextBoxColumn1.Visible = false;
			this.fileNameDataGridViewTextBoxColumn.DataPropertyName = "FileName";
			this.fileNameDataGridViewTextBoxColumn.HeaderText = "Файл";
			this.fileNameDataGridViewTextBoxColumn.Name = "fileNameDataGridViewTextBoxColumn";
			this.fileNameDataGridViewTextBoxColumn.ReadOnly = true;
			this.fileNameDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.fileNameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.fileNameDataGridViewTextBoxColumn.Width = 200;
			this.commentDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.commentDataGridViewTextBoxColumn.DataPropertyName = "Comment";
			this.commentDataGridViewTextBoxColumn.HeaderText = "Комментарий";
			this.commentDataGridViewTextBoxColumn.Name = "commentDataGridViewTextBoxColumn";
			dataGridViewCellStyle4.NullValue = null;
			this.ColumnImage.DefaultCellStyle = dataGridViewCellStyle4;
			this.ColumnImage.HeaderText = "";
			this.ColumnImage.Name = "ColumnImage";
			this.ColumnImage.ReadOnly = true;
			this.ColumnImage.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.ColumnImage.Width = 30;
			this.bindingSource_1.DataMember = "tJ_RequestForRepairDoc";
			this.bindingSource_1.DataSource = this.dataSetN;
			this.toolStripDocuments.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
			{
				this.toolBtnAddDoc,
				this.toolBtnDelDoc,
				this.toolBtnViewDoc,
				this.toolBtnSaveDoc
			});
			this.toolStripDocuments.Location = new System.Drawing.Point(3, 3);
			this.toolStripDocuments.Name = "toolStripDocuments";
			this.toolStripDocuments.Size = new System.Drawing.Size(724, 25);
			this.toolStripDocuments.TabIndex = 0;
			this.toolStripDocuments.Text = "toolStrip1";
			this.toolBtnAddDoc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolBtnAddDoc.Image = RequestsClient.Properties.Resources.ElementAdd;
			this.toolBtnAddDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolBtnAddDoc.Name = "toolBtnAddDoc";
			this.toolBtnAddDoc.Size = new System.Drawing.Size(23, 22);
			this.toolBtnAddDoc.Text = "Добавить документ";
			this.toolBtnAddDoc.Click += new System.EventHandler(this.toolBtnAddDoc_Click);
			this.toolBtnDelDoc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolBtnDelDoc.Image = RequestsClient.Properties.Resources.ElementDel;
			this.toolBtnDelDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolBtnDelDoc.Name = "toolBtnDelDoc";
			this.toolBtnDelDoc.Size = new System.Drawing.Size(23, 22);
			this.toolBtnDelDoc.Text = "Удалить документ";
			this.toolBtnDelDoc.Click += new System.EventHandler(this.toolBtnDelDoc_Click);
			this.toolBtnViewDoc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolBtnViewDoc.Image = RequestsClient.Properties.Resources.ElementInformation;
			this.toolBtnViewDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolBtnViewDoc.Name = "toolBtnViewDoc";
			this.toolBtnViewDoc.Size = new System.Drawing.Size(23, 22);
			this.toolBtnViewDoc.Text = "Открыть документ";
			this.toolBtnViewDoc.Click += new System.EventHandler(this.toolBtnViewDoc_Click);
			this.toolBtnSaveDoc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolBtnSaveDoc.Image = RequestsClient.Properties.Resources.ElementGo;
			this.toolBtnSaveDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolBtnSaveDoc.Name = "toolBtnSaveDoc";
			this.toolBtnSaveDoc.Size = new System.Drawing.Size(23, 22);
			this.toolBtnSaveDoc.Text = "Сохранить документ";
			this.toolBtnSaveDoc.Click += new System.EventHandler(this.toolBtnSaveDoc_Click);
			this.tabPageLog.Controls.Add(this.dataGridViewExcelFilter1);
			this.tabPageLog.Location = new System.Drawing.Point(4, 22);
			this.tabPageLog.Name = "tabPageLog";
			this.tabPageLog.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageLog.Size = new System.Drawing.Size(730, 643);
			this.tabPageLog.TabIndex = 3;
			this.tabPageLog.Text = "Логирование";
			this.tabPageLog.UseVisualStyleBackColor = true;
			this.dataGridViewExcelFilter1.AllowUserToAddRows = false;
			this.dataGridViewExcelFilter1.AllowUserToDeleteRows = false;
			this.dataGridViewExcelFilter1.AutoGenerateColumns = false;
			this.dataGridViewExcelFilter1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewExcelFilter1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
			{
				this.dateLogDataGridViewTextBoxColumn,
				this.idDataGridViewTextBoxColumn1,
				this.idRequestDataGridViewTextBoxColumn3,
				this.userLogIDDataGridViewTextBoxColumn,
				this.userLogDataGridViewTextBoxColumn,
				this.userLogNameDataGridViewTextBoxColumn,
				this.idCommandDataGridViewTextBoxColumn,
				this.commandDataGridViewTextBoxColumn,
				this.isSiteDataGridViewCheckBoxColumn
			});
			this.dataGridViewExcelFilter1.DataSource = this.bindingSource_4;
			this.dataGridViewExcelFilter1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridViewExcelFilter1.Location = new System.Drawing.Point(3, 3);
			this.dataGridViewExcelFilter1.Name = "dataGridViewExcelFilter1";
			this.dataGridViewExcelFilter1.ReadOnly = true;
			this.dataGridViewExcelFilter1.RowHeadersWidth = 21;
			this.dataGridViewExcelFilter1.Size = new System.Drawing.Size(724, 637);
			this.dataGridViewExcelFilter1.TabIndex = 0;
			this.dateLogDataGridViewTextBoxColumn.DataPropertyName = "dateLog";
			this.dateLogDataGridViewTextBoxColumn.HeaderText = "Дата";
			this.dateLogDataGridViewTextBoxColumn.Name = "dateLogDataGridViewTextBoxColumn";
			this.dateLogDataGridViewTextBoxColumn.ReadOnly = true;
			this.idDataGridViewTextBoxColumn1.DataPropertyName = "id";
			this.idDataGridViewTextBoxColumn1.HeaderText = "id";
			this.idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
			this.idDataGridViewTextBoxColumn1.ReadOnly = true;
			this.idDataGridViewTextBoxColumn1.Visible = false;
			this.idRequestDataGridViewTextBoxColumn3.DataPropertyName = "idRequest";
			this.idRequestDataGridViewTextBoxColumn3.HeaderText = "idRequest";
			this.idRequestDataGridViewTextBoxColumn3.Name = "idRequestDataGridViewTextBoxColumn3";
			this.idRequestDataGridViewTextBoxColumn3.ReadOnly = true;
			this.idRequestDataGridViewTextBoxColumn3.Visible = false;
			this.userLogIDDataGridViewTextBoxColumn.DataPropertyName = "userLogID";
			this.userLogIDDataGridViewTextBoxColumn.HeaderText = "userLogID";
			this.userLogIDDataGridViewTextBoxColumn.Name = "userLogIDDataGridViewTextBoxColumn";
			this.userLogIDDataGridViewTextBoxColumn.ReadOnly = true;
			this.userLogIDDataGridViewTextBoxColumn.Visible = false;
			this.userLogDataGridViewTextBoxColumn.DataPropertyName = "userLog";
			this.userLogDataGridViewTextBoxColumn.HeaderText = "userLog";
			this.userLogDataGridViewTextBoxColumn.Name = "userLogDataGridViewTextBoxColumn";
			this.userLogDataGridViewTextBoxColumn.ReadOnly = true;
			this.userLogDataGridViewTextBoxColumn.Visible = false;
			this.userLogNameDataGridViewTextBoxColumn.DataPropertyName = "userLogName";
			this.userLogNameDataGridViewTextBoxColumn.HeaderText = "Автор";
			this.userLogNameDataGridViewTextBoxColumn.Name = "userLogNameDataGridViewTextBoxColumn";
			this.userLogNameDataGridViewTextBoxColumn.ReadOnly = true;
			this.idCommandDataGridViewTextBoxColumn.DataPropertyName = "idCommand";
			this.idCommandDataGridViewTextBoxColumn.HeaderText = "idCommand";
			this.idCommandDataGridViewTextBoxColumn.Name = "idCommandDataGridViewTextBoxColumn";
			this.idCommandDataGridViewTextBoxColumn.ReadOnly = true;
			this.idCommandDataGridViewTextBoxColumn.Visible = false;
			this.commandDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.commandDataGridViewTextBoxColumn.DataPropertyName = "Command";
			this.commandDataGridViewTextBoxColumn.HeaderText = "Действие";
			this.commandDataGridViewTextBoxColumn.Name = "commandDataGridViewTextBoxColumn";
			this.commandDataGridViewTextBoxColumn.ReadOnly = true;
			this.isSiteDataGridViewCheckBoxColumn.DataPropertyName = "isSite";
			this.isSiteDataGridViewCheckBoxColumn.HeaderText = "isSite";
			this.isSiteDataGridViewCheckBoxColumn.Name = "isSiteDataGridViewCheckBoxColumn";
			this.isSiteDataGridViewCheckBoxColumn.ReadOnly = true;
			this.bindingSource_4.DataMember = "tJ_RequestForRepairLog";
			this.bindingSource_4.DataSource = this.dataSetN;
			this.bindingSource_4.Sort = "dateLog desc, id desc";
			this.buttonCopy.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.buttonCopy.Location = new System.Drawing.Point(240, 682);
			this.buttonCopy.Name = "buttonCopy";
			this.buttonCopy.Size = new System.Drawing.Size(75, 23);
			this.buttonCopy.TabIndex = 50;
			this.buttonCopy.Text = "Копировать";
			this.buttonCopy.UseVisualStyleBackColor = true;
			this.buttonCopy.Visible = false;
			this.buttonCopy.Click += new System.EventHandler(this.buttonCopy_Click);
			this.backgroundWorker_0.DoWork += new System.ComponentModel.DoWorkEventHandler(this.EaxgBgllje);
			this.backgroundWorker_0.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_0_RunWorkerCompleted);
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(574, 678);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 51;
			this.buttonCancel.Text = "Отмена";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			base.AcceptButton = this.buttonOK;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.buttonCancel;
			base.ClientSize = new System.Drawing.Size(664, 713);
			base.Controls.Add(this.buttonCancel);
			base.Controls.Add(this.buttonCopy);
			base.Controls.Add(this.tabControl);
			base.Controls.Add(this.buttonOK);
			base.Name = "FormJournalRequestForRepairAddEdit";
			this.Text = "FormJournalRequestForRepairAddEdit";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormJournalRequestForRepairAddEdit_FormClosing);
			base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormJournalRequestForRepairAddEdit_FormClosed);
			base.Load += new System.EventHandler(this.FormJournalRequestForRepairAddEdit_Load);
			((System.ComponentModel.ISupportInitialize)this.dataSetN).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.toolStripScheme.ResumeLayout(false);
			this.toolStripScheme.PerformLayout();
			this.groupBoxDaily.ResumeLayout(false);
			this.groupBoxDaily.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.dgvDaily).EndInit();
			this.groupBox_0.ResumeLayout(false);
			this.groupBox_0.PerformLayout();
			this.tabControl.ResumeLayout(false);
			this.EhhneeGlqI.ResumeLayout(false);
			this.EhhneeGlqI.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.bindingSource_2).EndInit();
			this.toolStripMain.ResumeLayout(false);
			this.toolStripMain.PerformLayout();
			this.tabPageSwitching.ResumeLayout(false);
			this.tabPageSwitching.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.dgvLinkObjects).EndInit();
			((System.ComponentModel.ISupportInitialize)this.bsLinkObjects).EndInit();
			((System.ComponentModel.ISupportInitialize)this.dataSet_0).EndInit();
			((System.ComponentModel.ISupportInitialize)this.dataTable_8).EndInit();
			((System.ComponentModel.ISupportInitialize)this.dataTable_9).EndInit();
			((System.ComponentModel.ISupportInitialize)this.dataTable_10).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.dgvAddress).EndInit();
			((System.ComponentModel.ISupportInitialize)this.bindingSource_3).EndInit();
			this.toolStripAddress.ResumeLayout(false);
			this.toolStripAddress.PerformLayout();
			this.tabPageDocuments.ResumeLayout(false);
			this.tabPageDocuments.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvDocs).EndInit();
			((System.ComponentModel.ISupportInitialize)this.bindingSource_1).EndInit();
			this.toolStripDocuments.ResumeLayout(false);
			this.toolStripDocuments.PerformLayout();
			this.tabPageLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.dataGridViewExcelFilter1).EndInit();
			((System.ComponentModel.ISupportInitialize)this.bindingSource_4).EndInit();
			base.ResumeLayout(false);
		}

		private System.ComponentModel.IContainer components = null;

		private Class3 dataSetN;

		private System.Windows.Forms.Label label1;

		private System.Windows.Forms.ComboBox cmbWorker;

		private System.Windows.Forms.Label labelRequestFiled;

		private System.Windows.Forms.Label labelSR;

		private System.Windows.Forms.ComboBox cmbSR;

		private System.Windows.Forms.GroupBox groupBox1;

		private System.Windows.Forms.Label label8;

		private System.Windows.Forms.ComboBox cmbIsPlanned;

		private System.Windows.Forms.Label labelIsPlanned;

		private System.Windows.Forms.Label labelPurpose;

		private System.Windows.Forms.TextBox txtPurpose;

		private System.Windows.Forms.TextBox txtObject;

		private System.Windows.Forms.Label labelObject;

		private System.Windows.Forms.Label label9;

		private System.Windows.Forms.GroupBox groupBox_0;

		private System.Windows.Forms.TextBox txtComment;

		private System.Windows.Forms.TextBox txtAgreeWith;

		private System.Windows.Forms.Button buttonOK;

		private System.Windows.Forms.ComboBox cmbDispatcher;

		private System.Windows.Forms.Label label14;

		private System.Windows.Forms.Label label13;

		private ControlsLbr.NullableDateTimePicker dateTimePickerDateAgreed;

		private System.Windows.Forms.CheckBox rWoeDxUpjP;

		private System.Windows.Forms.Label labelAddress;

		private System.Windows.Forms.Label label11;

		private System.Windows.Forms.Label label10;

		private System.Windows.Forms.ComboBox cmbUserCreate;

		private System.Windows.Forms.Label label15;

		private System.Windows.Forms.TextBox txtNum;

		private System.Windows.Forms.GroupBox groupBoxDaily;

		private System.Windows.Forms.Button buttonDaily;

		private System.Windows.Forms.DataGridView dgvDaily;

		private System.Windows.Forms.CheckBox checkBoxWeekEnd;

		private System.Windows.Forms.CheckBox checkBoxDaily;

		private System.Windows.Forms.DateTimePicker dateTimePickerEnd;

		private System.Windows.Forms.DateTimePicker dateTimePickerBeg;

		private System.Windows.Forms.Label labelWorker;

		private System.Windows.Forms.Label label2;

		private ControlsLbr.NullableDateTimePicker dateTimePickerDateCreate;

		private System.Windows.Forms.ToolStrip toolStripScheme;

		private System.Windows.Forms.ToolStripButton toolBtnLinkSchmObj;

		private System.Windows.Forms.ToolStripButton toolBtnDelSchmObj;

		private System.Windows.Forms.ToolStripButton toolBtnViewSChmObj;

		private System.Windows.Forms.TabControl tabControl;

		private System.Windows.Forms.TabPage EhhneeGlqI;

		private System.Windows.Forms.TabPage tabPageSwitching;

		private System.Windows.Forms.TabPage tabPageDocuments;

		private System.Data.DataSet dataSet_0;

		private System.Data.DataTable dataTable_8;

		private System.Data.DataColumn dataColumn_0;

		private System.Data.DataColumn dataColumn_1;

		private System.Data.DataColumn dataColumn_2;

		private System.Data.DataColumn dataColumn_3;

		private System.Data.DataColumn dataColumn_4;

		private System.Windows.Forms.ToolStripButton toolBtnLinkSchmObjEdit;

		private ControlsLbr.DataGridViewExcelFilter.DataGridViewExcelFilter dgvLinkObjects;

		private System.Windows.Forms.BindingSource bsLinkObjects;

		private ControlsLbr.DataGridViewExcelFilter.DataGridViewExcelFilter dgvDocs;

		private System.Windows.Forms.BindingSource bindingSource_1;

		private System.Windows.Forms.ToolStrip toolStripDocuments;

		private System.Windows.Forms.ToolStripButton toolBtnAddDoc;

		private System.Data.DataTable dataTable_9;

		private System.Data.DataColumn dataColumn_5;

		private System.Data.DataColumn ngrnvWyUkq;

		private System.Data.DataColumn dataColumn_6;

		private System.Data.DataColumn dataColumn_7;

		private System.Windows.Forms.ToolStripButton toolBtnDelDoc;

		private System.Windows.Forms.ToolStripButton toolBtnViewDoc;

		private System.Windows.Forms.ToolStripButton toolBtnSaveDoc;

		private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumnDoc;

		private ControlsLbr.DataGridViewExcelFilter.DataGridViewImageColumnNotNull ColumnImage;

		private System.Windows.Forms.DataGridViewTextBoxColumn idRequestDataGridViewTextBoxColumn1;

		private System.Windows.Forms.DataGridViewLinkColumn fileNameDataGridViewTextBoxColumn;

		private System.Windows.Forms.DataGridViewTextBoxColumn commentDataGridViewTextBoxColumn;

		private System.Windows.Forms.Button buttonCopy;

		private System.Windows.Forms.ToolStrip toolStripMain;

		private System.Windows.Forms.ToolStripButton toolBtnCopy;

		private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;

		private System.Windows.Forms.DataGridViewTextBoxColumn idRequestDataGridViewTextBoxColumn;

		private ControlsLbr.DataGridViewExcelFilter.DataGridViewFilterDateTimePickerColumn dateBegDataGridViewTextBoxColumn;

		private ControlsLbr.DataGridViewExcelFilter.DataGridViewFilterDateTimePickerColumn dateEndDataGridViewTextBoxColumn;

		private System.Windows.Forms.TextBox txtAdress;

		private System.Windows.Forms.ComboBox txtRequestFiled;

		private System.Windows.Forms.ComboBox cmbRegion;

		private System.Windows.Forms.ComboBox cmbTypeDisable;

		private System.Windows.Forms.Label label3;

		private System.Windows.Forms.ComboBox cmbPerformerOrganization;

		private System.Windows.Forms.Label labelPerformer;

		private System.Windows.Forms.ComboBox cmbOrganization;

		private System.Windows.Forms.Label labelOrganization;

		private System.Windows.Forms.ComboBox cmbGroupWorks;

		private System.Windows.Forms.Label labelGroupWork;

		private System.Windows.Forms.BindingSource bindingSource_2;

		private System.Windows.Forms.ComboBox cmbStatus;

		private System.Windows.Forms.Label labelStatus;

		private System.Windows.Forms.SplitContainer splitContainer1;

		private System.Data.DataTable dataTable_10;

		private System.Data.DataColumn dataColumn_8;

		private System.Data.DataColumn dataColumn_9;

		private System.Data.DataColumn dataColumn_10;

		private System.Data.DataColumn dataColumn_11;

		private System.Data.DataColumn dataColumn_12;

		private System.Data.DataColumn dataColumn_13;

		private System.Data.DataColumn dataColumn_14;

		private System.Data.DataColumn dataColumn_15;

		private ControlsLbr.DataGridViewExcelFilter.DataGridViewExcelFilter dgvAddress;

		private System.Windows.Forms.BindingSource bindingSource_3;

		private System.Windows.Forms.ToolStrip toolStripAddress;

		private System.Windows.Forms.ToolStripButton toolBtnAddAddress;

		private System.Windows.Forms.ToolStripButton toolBtnDelAddress;

		private System.ComponentModel.BackgroundWorker backgroundWorker_0;

		private System.Windows.Forms.DataGridViewTextBoxColumn cityDataGridViewTextBoxColumn;

		private System.Windows.Forms.DataGridViewTextBoxColumn idAddressDgvColumn;

		private System.Windows.Forms.DataGridViewTextBoxColumn idRequestDataGridViewTextBoxColumn2;

		private System.Windows.Forms.DataGridViewTextBoxColumn idKladrObjDataGridViewTextBoxColumn;

		private System.Windows.Forms.DataGridViewTextBoxColumn streetDataGridViewTextBoxColumn;

		private System.Windows.Forms.DataGridViewTextBoxColumn idKladrStreetDataGridViewTextBoxColumn;

		private System.Windows.Forms.DataGridViewTextBoxColumn houseDataGridViewTextBoxColumn;

		private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;

		private ControlsLbr.NullableDateTimePicker dateTimePickerFactEnd;

		private System.Windows.Forms.ToolStripButton toolBtnSettingsFTP;

		private System.Windows.Forms.ComboBox cmbTypeDamage;

		private System.Data.DataColumn dataColumn_16;

		private System.Windows.Forms.DataGridViewTextBoxColumn objectsDataGridViewTextBoxColumn1;

		private System.Windows.Forms.DataGridViewTextBoxColumn dateBegDataGridViewTextBoxColumn2;

		private System.Windows.Forms.DataGridViewTextBoxColumn dateEndDataGridViewTextBoxColumn2;

		private System.Windows.Forms.DataGridViewTextBoxColumn durationDataGridViewTextBoxColumn1;

		private System.Windows.Forms.DataGridViewTextBoxColumn numDataGridViewTextBoxColumn1;

		private System.Windows.Forms.DataGridViewCheckBoxColumn disabledDgvColumn;

		private System.Windows.Forms.CheckBox chkSendToSite;

		private System.Windows.Forms.TabPage tabPageLog;

		private ControlsLbr.DataGridViewExcelFilter.DataGridViewExcelFilter dataGridViewExcelFilter1;

		private System.Windows.Forms.BindingSource bindingSource_4;

		private System.Windows.Forms.DataGridViewTextBoxColumn dateLogDataGridViewTextBoxColumn;

		private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;

		private System.Windows.Forms.DataGridViewTextBoxColumn idRequestDataGridViewTextBoxColumn3;

		private System.Windows.Forms.DataGridViewTextBoxColumn userLogIDDataGridViewTextBoxColumn;

		private System.Windows.Forms.DataGridViewTextBoxColumn userLogDataGridViewTextBoxColumn;

		private System.Windows.Forms.DataGridViewTextBoxColumn userLogNameDataGridViewTextBoxColumn;

		private System.Windows.Forms.DataGridViewTextBoxColumn idCommandDataGridViewTextBoxColumn;

		private System.Windows.Forms.DataGridViewTextBoxColumn commandDataGridViewTextBoxColumn;

		private System.Windows.Forms.DataGridViewCheckBoxColumn isSiteDataGridViewCheckBoxColumn;

		private System.Windows.Forms.Button buttonCancel;
	}
}
