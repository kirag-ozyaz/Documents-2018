namespace RequestsClient.Forms
{
	public partial class TemperatureSR : FormLbr.FormBase
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
			this.icontainer_0 = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
			this.toolBtnRefresh = new System.Windows.Forms.ToolStripButton();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPagePB = new System.Windows.Forms.TabPage();
			this.dataGridViewExcelFilter1 = new ControlsLbr.DataGridViewExcelFilter.DataGridViewExcelFilter();
			this.dataGridViewFilterDateTimePickerColumn_0 = new ControlsLbr.DataGridViewExcelFilter.DataGridViewFilterDateTimePickerColumn();
			this.dataGridViewTextBoxColumn_0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.bindingSource_0 = new System.Windows.Forms.BindingSource(this.icontainer_0);
			this.dataSet_0 = new System.Data.DataSet();
			this.dataTable_0 = new System.Data.DataTable();
			this.dataColumn_0 = new System.Data.DataColumn();
			this.dataColumn_1 = new System.Data.DataColumn();
			this.dataColumn_2 = new System.Data.DataColumn();
			this.dataColumn_3 = new System.Data.DataColumn();
			this.dataColumn_4 = new System.Data.DataColumn();
			this.dataColumn_5 = new System.Data.DataColumn();
			this.dataColumn_6 = new System.Data.DataColumn();
			this.dataColumn_7 = new System.Data.DataColumn();
			this.dataColumn_8 = new System.Data.DataColumn();
			this.dataColumn_9 = new System.Data.DataColumn();
			this.tabPageLB = new System.Windows.Forms.TabPage();
			this.dataGridViewExcelFilter2 = new ControlsLbr.DataGridViewExcelFilter.DataGridViewExcelFilter();
			this.dataGridViewFilterDateTimePickerColumn_1 = new ControlsLbr.DataGridViewExcelFilter.DataGridViewFilterDateTimePickerColumn();
			this.dataGridViewTextBoxColumn_9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.bindingSource_1 = new System.Windows.Forms.BindingSource(this.icontainer_0);
			this.dataSet_1 = new System.Data.DataSet();
			this.dataTable_1 = new System.Data.DataTable();
			this.dataColumn_10 = new System.Data.DataColumn();
			this.dataColumn_11 = new System.Data.DataColumn();
			this.dataColumn_12 = new System.Data.DataColumn();
			this.dataColumn_13 = new System.Data.DataColumn();
			this.dataColumn_14 = new System.Data.DataColumn();
			this.dataColumn_15 = new System.Data.DataColumn();
			this.dataColumn_16 = new System.Data.DataColumn();
			this.dataColumn_17 = new System.Data.DataColumn();
			this.dataColumn_18 = new System.Data.DataColumn();
			this.dataColumn_19 = new System.Data.DataColumn();
			this.toolStrip.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPagePB.SuspendLayout();
			//this.dataGridViewExcelFilter1.BeginInit();
			((System.ComponentModel.ISupportInitialize)this.bindingSource_0).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.dataSet_0).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.dataTable_0).BeginInit();
			this.tabPageLB.SuspendLayout();
			//this.dataGridViewExcelFilter2.BeginInit();
			((System.ComponentModel.ISupportInitialize)this.bindingSource_1).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.dataSet_1).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.dataTable_1).BeginInit();
			base.SuspendLayout();
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
			{
				this.toolStripLabel1,
				this.toolStripLabel2,
				this.toolBtnRefresh
			});
			this.toolStrip.Location = new System.Drawing.Point(0, 0);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(851, 25);
			this.toolStrip.TabIndex = 0;
			this.toolStrip.Text = "toolStrip1";
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(47, 22);
			this.toolStripLabel1.Text = "Дата от";
			this.toolStripLabel2.Name = "toolStripLabel2";
			this.toolStripLabel2.Size = new System.Drawing.Size(48, 22);
			this.toolStripLabel2.Text = "Дата до";
			this.toolBtnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolBtnRefresh.Image = RequestsClient.Properties.Resources.refresh_16;
			this.toolBtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolBtnRefresh.Name = "toolBtnRefresh";
			this.toolBtnRefresh.Size = new System.Drawing.Size(23, 22);
			this.toolBtnRefresh.Text = "Обновить";
			this.toolBtnRefresh.Click += new System.EventHandler(this.toolBtnRefresh_Click);
			this.tabControl1.Controls.Add(this.tabPagePB);
			this.tabControl1.Controls.Add(this.tabPageLB);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 25);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(851, 451);
			this.tabControl1.TabIndex = 1;
			this.tabPagePB.Controls.Add(this.dataGridViewExcelFilter1);
			this.tabPagePB.Location = new System.Drawing.Point(4, 22);
			this.tabPagePB.Name = "tabPagePB";
			this.tabPagePB.Padding = new System.Windows.Forms.Padding(3);
			this.tabPagePB.Size = new System.Drawing.Size(843, 425);
			this.tabPagePB.TabIndex = 0;
			this.tabPagePB.Text = "Правый берег";
			this.tabPagePB.UseVisualStyleBackColor = true;
			this.dataGridViewExcelFilter1.AllowUserToAddRows = false;
			this.dataGridViewExcelFilter1.AllowUserToDeleteRows = false;
			dataGridViewCellStyle.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.dataGridViewExcelFilter1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle;
			this.dataGridViewExcelFilter1.AutoGenerateColumns = false;
			this.dataGridViewExcelFilter1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewExcelFilter1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
			{
				this.dataGridViewFilterDateTimePickerColumn_0,
				this.dataGridViewTextBoxColumn_0,
				this.dataGridViewTextBoxColumn_1,
				this.dataGridViewTextBoxColumn_2,
				this.dataGridViewTextBoxColumn_3,
				this.dataGridViewTextBoxColumn_4,
				this.dataGridViewTextBoxColumn_5,
				this.dataGridViewTextBoxColumn_6,
				this.dataGridViewTextBoxColumn_7,
				this.dataGridViewTextBoxColumn_8
			});
			this.dataGridViewExcelFilter1.DataSource = this.bindingSource_0;
			this.dataGridViewExcelFilter1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridViewExcelFilter1.Location = new System.Drawing.Point(3, 3);
			this.dataGridViewExcelFilter1.Name = "dataGridViewExcelFilter1";
			this.dataGridViewExcelFilter1.ReadOnly = true;
			this.dataGridViewExcelFilter1.RowHeadersWidth = 21;
			this.dataGridViewExcelFilter1.Size = new System.Drawing.Size(837, 419);
			this.dataGridViewExcelFilter1.TabIndex = 0;
			this.dataGridViewFilterDateTimePickerColumn_0.DataPropertyName = "Дата";
			dataGridViewCellStyle2.Format = "d";
			this.dataGridViewFilterDateTimePickerColumn_0.DefaultCellStyle = dataGridViewCellStyle2;
			this.dataGridViewFilterDateTimePickerColumn_0.HeaderText = "Дата";
			this.dataGridViewFilterDateTimePickerColumn_0.Name = "датаDataGridViewTextBoxColumn";
			this.dataGridViewFilterDateTimePickerColumn_0.ReadOnly = true;
			this.dataGridViewFilterDateTimePickerColumn_0.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewFilterDateTimePickerColumn_0.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.dataGridViewTextBoxColumn_0.DataPropertyName = "ТемператураНОт";
			this.dataGridViewTextBoxColumn_0.HeaderText = "t Ночь От";
			this.dataGridViewTextBoxColumn_0.Name = "температураНОтDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_0.ReadOnly = true;
			this.dataGridViewTextBoxColumn_1.DataPropertyName = "ТемператураНДо";
			this.dataGridViewTextBoxColumn_1.HeaderText = "t Ночь До";
			this.dataGridViewTextBoxColumn_1.Name = "температураНДоDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_1.ReadOnly = true;
			this.dataGridViewTextBoxColumn_2.DataPropertyName = "ТемператураДОт";
			this.dataGridViewTextBoxColumn_2.HeaderText = "t День От";
			this.dataGridViewTextBoxColumn_2.Name = "температураДОтDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_2.ReadOnly = true;
			this.dataGridViewTextBoxColumn_3.DataPropertyName = "ТемператураДДо";
			this.dataGridViewTextBoxColumn_3.HeaderText = "t День До";
			this.dataGridViewTextBoxColumn_3.Name = "температураДДоDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_3.ReadOnly = true;
			this.dataGridViewTextBoxColumn_4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_4.DataPropertyName = "Ветер";
			this.dataGridViewTextBoxColumn_4.HeaderText = "Ветер";
			this.dataGridViewTextBoxColumn_4.Name = "ветерDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_4.ReadOnly = true;
			this.dataGridViewTextBoxColumn_5.DataPropertyName = "СкоростьОт";
			this.dataGridViewTextBoxColumn_5.HeaderText = "СкоростьОт";
			this.dataGridViewTextBoxColumn_5.Name = "скоростьОтDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_5.ReadOnly = true;
			this.dataGridViewTextBoxColumn_6.DataPropertyName = "СкоростьДо";
			this.dataGridViewTextBoxColumn_6.HeaderText = "СкоростьДо";
			this.dataGridViewTextBoxColumn_6.Name = "скоростьДоDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_6.ReadOnly = true;
			this.dataGridViewTextBoxColumn_7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_7.DataPropertyName = "Примечание";
			this.dataGridViewTextBoxColumn_7.HeaderText = "Примечание";
			this.dataGridViewTextBoxColumn_7.Name = "примечаниеDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_7.ReadOnly = true;
			this.dataGridViewTextBoxColumn_8.DataPropertyName = "Составил";
			this.dataGridViewTextBoxColumn_8.HeaderText = "Составил";
			this.dataGridViewTextBoxColumn_8.Name = "составилDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_8.ReadOnly = true;
			this.bindingSource_0.DataMember = "СоставительНизкого";
			this.bindingSource_0.DataSource = this.dataSet_0;
			this.dataSet_0.DataSetName = "NewDataSet";
			this.dataSet_0.Tables.AddRange(new System.Data.DataTable[]
			{
				this.dataTable_0
			});
			this.dataTable_0.Columns.AddRange(new System.Data.DataColumn[]
			{
				this.dataColumn_0,
				this.dataColumn_1,
				this.dataColumn_2,
				this.dataColumn_3,
				this.dataColumn_4,
				this.dataColumn_5,
				this.dataColumn_6,
				this.dataColumn_7,
				this.dataColumn_8,
				this.dataColumn_9
			});
			this.dataTable_0.TableName = "СоставительНизкого";
			this.dataColumn_0.ColumnName = "Дата";
			this.dataColumn_0.DataType = typeof(System.DateTime);
			this.dataColumn_1.ColumnName = "ТемператураНОт";
			this.dataColumn_1.DataType = typeof(short);
			this.dataColumn_2.ColumnName = "ТемператураНДо";
			this.dataColumn_2.DataType = typeof(short);
			this.dataColumn_3.ColumnName = "ТемператураДОт";
			this.dataColumn_3.DataType = typeof(short);
			this.dataColumn_4.ColumnName = "ТемператураДДо";
			this.dataColumn_4.DataType = typeof(short);
			this.dataColumn_5.ColumnName = "Ветер";
			this.dataColumn_6.ColumnName = "СкоростьОт";
			this.dataColumn_6.DataType = typeof(int);
			this.dataColumn_7.ColumnName = "СкоростьДо";
			this.dataColumn_7.DataType = typeof(int);
			this.dataColumn_8.ColumnName = "Примечание";
			this.dataColumn_9.ColumnName = "Составил";
			this.tabPageLB.Controls.Add(this.dataGridViewExcelFilter2);
			this.tabPageLB.Location = new System.Drawing.Point(4, 22);
			this.tabPageLB.Name = "tabPageLB";
			this.tabPageLB.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageLB.Size = new System.Drawing.Size(843, 425);
			this.tabPageLB.TabIndex = 1;
			this.tabPageLB.Text = "Левый берег";
			this.tabPageLB.UseVisualStyleBackColor = true;
			this.dataGridViewExcelFilter2.AllowUserToAddRows = false;
			this.dataGridViewExcelFilter2.AllowUserToDeleteRows = false;
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.dataGridViewExcelFilter2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
			this.dataGridViewExcelFilter2.AutoGenerateColumns = false;
			this.dataGridViewExcelFilter2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewExcelFilter2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
			{
				this.dataGridViewFilterDateTimePickerColumn_1,
				this.dataGridViewTextBoxColumn_9,
				this.dataGridViewTextBoxColumn_10,
				this.dataGridViewTextBoxColumn_11,
				this.dataGridViewTextBoxColumn_12,
				this.dataGridViewTextBoxColumn_13,
				this.dataGridViewTextBoxColumn_14,
				this.dataGridViewTextBoxColumn_15,
				this.dataGridViewTextBoxColumn_16,
				this.dataGridViewTextBoxColumn_17
			});
			this.dataGridViewExcelFilter2.DataSource = this.bindingSource_1;
			this.dataGridViewExcelFilter2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridViewExcelFilter2.Location = new System.Drawing.Point(3, 3);
			this.dataGridViewExcelFilter2.Name = "dataGridViewExcelFilter2";
			this.dataGridViewExcelFilter2.ReadOnly = true;
			this.dataGridViewExcelFilter2.RowHeadersWidth = 21;
			this.dataGridViewExcelFilter2.Size = new System.Drawing.Size(837, 419);
			this.dataGridViewExcelFilter2.TabIndex = 0;
			this.dataGridViewFilterDateTimePickerColumn_1.DataPropertyName = "Дата";
			dataGridViewCellStyle4.Format = "d";
			this.dataGridViewFilterDateTimePickerColumn_1.DefaultCellStyle = dataGridViewCellStyle4;
			this.dataGridViewFilterDateTimePickerColumn_1.HeaderText = "Дата";
			this.dataGridViewFilterDateTimePickerColumn_1.Name = "датаDataGridViewTextBoxColumn1";
			this.dataGridViewFilterDateTimePickerColumn_1.ReadOnly = true;
			this.dataGridViewFilterDateTimePickerColumn_1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewFilterDateTimePickerColumn_1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.dataGridViewTextBoxColumn_9.DataPropertyName = "ТемператураНОт";
			this.dataGridViewTextBoxColumn_9.HeaderText = "t Ночь От";
			this.dataGridViewTextBoxColumn_9.Name = "температураНОтDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_9.ReadOnly = true;
			this.dataGridViewTextBoxColumn_10.DataPropertyName = "ТемператураНДо";
			this.dataGridViewTextBoxColumn_10.HeaderText = "t Ночь До";
			this.dataGridViewTextBoxColumn_10.Name = "температураНДоDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_10.ReadOnly = true;
			this.dataGridViewTextBoxColumn_11.DataPropertyName = "ТемператураДОт";
			this.dataGridViewTextBoxColumn_11.HeaderText = "t День От";
			this.dataGridViewTextBoxColumn_11.Name = "температураДОтDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_11.ReadOnly = true;
			this.dataGridViewTextBoxColumn_12.DataPropertyName = "ТемператураДДо";
			this.dataGridViewTextBoxColumn_12.HeaderText = "t День До";
			this.dataGridViewTextBoxColumn_12.Name = "температураДДоDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_12.ReadOnly = true;
			this.dataGridViewTextBoxColumn_13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_13.DataPropertyName = "Ветер";
			this.dataGridViewTextBoxColumn_13.HeaderText = "Ветер";
			this.dataGridViewTextBoxColumn_13.Name = "ветерDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_13.ReadOnly = true;
			this.dataGridViewTextBoxColumn_14.DataPropertyName = "СкоростьОт";
			this.dataGridViewTextBoxColumn_14.HeaderText = "СкоростьОт";
			this.dataGridViewTextBoxColumn_14.Name = "скоростьОтDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_14.ReadOnly = true;
			this.dataGridViewTextBoxColumn_15.DataPropertyName = "СкоростьДо";
			this.dataGridViewTextBoxColumn_15.HeaderText = "СкоростьДо";
			this.dataGridViewTextBoxColumn_15.Name = "скоростьДоDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_15.ReadOnly = true;
			this.dataGridViewTextBoxColumn_16.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_16.DataPropertyName = "Примечание";
			this.dataGridViewTextBoxColumn_16.HeaderText = "Примечание";
			this.dataGridViewTextBoxColumn_16.Name = "примечаниеDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_16.ReadOnly = true;
			this.dataGridViewTextBoxColumn_17.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_17.DataPropertyName = "Составил";
			this.dataGridViewTextBoxColumn_17.HeaderText = "Составил";
			this.dataGridViewTextBoxColumn_17.Name = "составилDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_17.ReadOnly = true;
			this.bindingSource_1.DataMember = "СоставительНизкого";
			this.bindingSource_1.DataSource = this.dataSet_1;
			this.dataSet_1.DataSetName = "NewDataSet";
			this.dataSet_1.Tables.AddRange(new System.Data.DataTable[]
			{
				this.dataTable_1
			});
			this.dataTable_1.Columns.AddRange(new System.Data.DataColumn[]
			{
				this.dataColumn_10,
				this.dataColumn_11,
				this.dataColumn_12,
				this.dataColumn_13,
				this.dataColumn_14,
				this.dataColumn_15,
				this.dataColumn_16,
				this.dataColumn_17,
				this.dataColumn_18,
				this.dataColumn_19
			});
			this.dataTable_1.TableName = "СоставительНизкого";
			this.dataColumn_10.ColumnName = "Дата";
			this.dataColumn_10.DataType = typeof(System.DateTime);
			this.dataColumn_11.ColumnName = "ТемператураНОт";
			this.dataColumn_11.DataType = typeof(short);
			this.dataColumn_12.ColumnName = "ТемператураНДо";
			this.dataColumn_12.DataType = typeof(short);
			this.dataColumn_13.ColumnName = "ТемператураДОт";
			this.dataColumn_13.DataType = typeof(short);
			this.dataColumn_14.ColumnName = "ТемператураДДо";
			this.dataColumn_14.DataType = typeof(short);
			this.dataColumn_15.ColumnName = "Ветер";
			this.dataColumn_16.ColumnName = "СкоростьОт";
			this.dataColumn_16.DataType = typeof(int);
			this.dataColumn_17.ColumnName = "СкоростьДо";
			this.dataColumn_17.DataType = typeof(int);
			this.dataColumn_18.ColumnName = "Примечание";
			this.dataColumn_19.ColumnName = "Составил";
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(851, 476);
			base.Controls.Add(this.tabControl1);
			base.Controls.Add(this.toolStrip);
			base.Name = "TemperatureSR";
			this.Text = "Реестр температур";
			base.Load += new System.EventHandler(this.TemperatureSR_Load);
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPagePB.ResumeLayout(false);
			//this.dataGridViewExcelFilter1.EndInit();
			((System.ComponentModel.ISupportInitialize)this.bindingSource_0).EndInit();
			((System.ComponentModel.ISupportInitialize)this.dataSet_0).EndInit();
			((System.ComponentModel.ISupportInitialize)this.dataTable_0).EndInit();
			this.tabPageLB.ResumeLayout(false);
			//this.dataGridViewExcelFilter2.EndInit();
			((System.ComponentModel.ISupportInitialize)this.bindingSource_1).EndInit();
			((System.ComponentModel.ISupportInitialize)this.dataSet_1).EndInit();
			((System.ComponentModel.ISupportInitialize)this.dataTable_1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private System.ComponentModel.IContainer icontainer_0;

		private System.Windows.Forms.ToolStrip toolStrip;

		private System.Windows.Forms.ToolStripLabel toolStripLabel1;

		private System.Windows.Forms.TabControl tabControl1;

		private System.Windows.Forms.TabPage tabPagePB;

		private ControlsLbr.DataGridViewExcelFilter.DataGridViewExcelFilter dataGridViewExcelFilter1;

		private System.Windows.Forms.BindingSource bindingSource_0;

		private System.Data.DataSet dataSet_0;

		private System.Data.DataTable dataTable_0;

		private System.Data.DataColumn dataColumn_0;

		private System.Data.DataColumn dataColumn_1;

		private System.Data.DataColumn dataColumn_2;

		private System.Data.DataColumn dataColumn_3;

		private System.Data.DataColumn dataColumn_4;

		private System.Data.DataColumn dataColumn_5;

		private System.Data.DataColumn dataColumn_6;

		private System.Data.DataColumn dataColumn_7;

		private System.Data.DataColumn dataColumn_8;

		private System.Data.DataColumn dataColumn_9;

		private System.Windows.Forms.TabPage tabPageLB;

		private ControlsLbr.DataGridViewExcelFilter.DataGridViewExcelFilter dataGridViewExcelFilter2;

		private System.Windows.Forms.BindingSource bindingSource_1;

		private System.Data.DataSet dataSet_1;

		private System.Data.DataTable dataTable_1;

		private System.Data.DataColumn dataColumn_10;

		private System.Data.DataColumn dataColumn_11;

		private System.Data.DataColumn dataColumn_12;

		private System.Data.DataColumn dataColumn_13;

		private System.Data.DataColumn dataColumn_14;

		private System.Data.DataColumn dataColumn_15;

		private System.Data.DataColumn dataColumn_16;

		private System.Data.DataColumn dataColumn_17;

		private System.Data.DataColumn dataColumn_18;

		private System.Data.DataColumn dataColumn_19;

		private System.Windows.Forms.ToolStripLabel toolStripLabel2;

		private System.Windows.Forms.ToolStripButton toolBtnRefresh;

		private ControlsLbr.DataGridViewExcelFilter.DataGridViewFilterDateTimePickerColumn dataGridViewFilterDateTimePickerColumn_0;

		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn_3;

		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn_4;

		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn_5;

		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn_6;

		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn_7;

		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn_8;

		private ControlsLbr.DataGridViewExcelFilter.DataGridViewFilterDateTimePickerColumn dataGridViewFilterDateTimePickerColumn_1;

		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn_9;

		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn_10;

		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn_11;

		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn_12;

		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn_13;

		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn_14;

		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn_15;

		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn_16;

		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn_17;
	}
}
