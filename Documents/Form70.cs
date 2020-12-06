using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ControlsLbr.ReportViewerRus;
using FormLbr;
using Microsoft.Reporting.WinForms;

internal partial class Form70 : FormBase
{
	internal Form70()
	{
		
		
		this.method_1();
		this.dateTimePicker_1.Value = (this.dateTimePicker_0.Value = DateTime.Now.Date);
		for (int i = 1990; i < DateTime.Now.Year + 20; i++)
		{
			this.comboBox_1.Items.Add(i);
			this.comboBox_0.Items.Add(i);
		}
		this.comboBox_2.SelectedIndex = DateTime.Now.Month - 1;
		this.comboBox_1.SelectedItem = DateTime.Now.Year;
		this.comboBox_0.SelectedItem = DateTime.Now.Year;
	}

	private void Form70_Load(object sender, EventArgs e)
	{
		this.comboBox_2.SelectedIndexChanged += this.comboBox_0_SelectedIndexChanged;
		this.comboBox_1.SelectedIndexChanged += this.comboBox_0_SelectedIndexChanged;
		this.comboBox_0.SelectedIndexChanged += this.comboBox_0_SelectedIndexChanged;
		this.dateTimePicker_1.ValueChanged += this.dateTimePicker_0_ValueChanged;
		this.dateTimePicker_0.ValueChanged += this.dateTimePicker_0_ValueChanged;
		this.method_0();
		this.reportViewerRus_0.RefreshReport();
	}

	private void dateTimePicker_0_ValueChanged(object sender, EventArgs e)
	{
		this.method_0();
	}

	private void comboBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.method_0();
	}

	private void method_0()
	{
		string where = "";
		string value = null;
		if (this.radioButton_2.Checked)
		{
			DateTime dateTime = new DateTime(Convert.ToInt32(this.comboBox_1.SelectedItem), this.comboBox_2.SelectedIndex + 1, 1);
			where = string.Concat(new string[]
			{
				" where dateDefect >= '",
				dateTime.ToString("yyyyMMdd"),
				"' and dateDefect < '",
				dateTime.AddMonths(1).ToString("yyyyMMdd"),
				"'"
			});
			ReportParameter reportParameter = new ReportParameter("month", this.comboBox_2.SelectedItem.ToString());
			this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
			{
				reportParameter
			});
			ReportParameter reportParameter2 = new ReportParameter("year", this.comboBox_1.SelectedItem.ToString());
			this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
			{
				reportParameter2
			});
			ReportParameter reportParameter3 = new ReportParameter("dBeg", value);
			this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
			{
				reportParameter3
			});
		}
		else if (this.radioButton_1.Checked)
		{
			DateTime dateTime2 = new DateTime(Convert.ToInt32(this.comboBox_0.SelectedItem), 1, 1);
			where = string.Concat(new string[]
			{
				" where dateDefect >= '",
				dateTime2.ToString("yyyyMMdd"),
				"' and dateDefect < '",
				dateTime2.AddYears(1).ToString("yyyyMMdd"),
				"'"
			});
			ReportParameter reportParameter4 = new ReportParameter("month", new string[1]);
			this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
			{
				reportParameter4
			});
			ReportParameter reportParameter5 = new ReportParameter("year", this.comboBox_0.SelectedItem.ToString());
			this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
			{
				reportParameter5
			});
			ReportParameter reportParameter6 = new ReportParameter("dBeg", new string[1]);
			this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
			{
				reportParameter6
			});
		}
		else if (this.radioButton_0.Checked)
		{
			where = string.Concat(new string[]
			{
				" where dateDefect >= '",
				this.dateTimePicker_1.Value.ToString("yyyyMMdd"),
				"' and dateDefect < '",
				this.dateTimePicker_0.Value.AddDays(1.0).ToString("yyyyMMdd"),
				"'"
			});
			ReportParameter reportParameter7 = new ReportParameter("dBeg", this.dateTimePicker_1.Value.ToString());
			this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
			{
				reportParameter7
			});
			ReportParameter reportParameter8 = new ReportParameter("dEnd", this.dateTimePicker_0.Value.ToString());
			this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
			{
				reportParameter8
			});
		}
		else
		{
			ReportParameter reportParameter9 = new ReportParameter("month", new string[1]);
			this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
			{
				reportParameter9
			});
			ReportParameter reportParameter10 = new ReportParameter("year", new string[1]);
			this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
			{
				reportParameter10
			});
			ReportParameter reportParameter11 = new ReportParameter("dBeg", new string[1]);
			this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
			{
				reportParameter11
			});
		}
		base.SelectSqlData(this.dataTable_0, true, where, null, false, 0);
		this.reportViewerRus_0.RefreshReport();
	}

	private void radioButton_2_CheckedChanged(object sender, EventArgs e)
	{
		if (this.radioButton_2.Checked)
		{
			Control control = this.comboBox_1;
			this.comboBox_2.Enabled = true;
			control.Enabled = true;
			this.comboBox_0.Enabled = false;
			Control control2 = this.dateTimePicker_0;
			this.dateTimePicker_1.Enabled = false;
			control2.Enabled = false;
			this.method_0();
		}
	}

	private void radioButton_1_CheckedChanged(object sender, EventArgs e)
	{
		if (this.radioButton_1.Checked)
		{
			Control control = this.comboBox_1;
			this.comboBox_2.Enabled = false;
			control.Enabled = false;
			this.comboBox_0.Enabled = true;
			Control control2 = this.dateTimePicker_0;
			this.dateTimePicker_1.Enabled = false;
			control2.Enabled = false;
			this.method_0();
		}
	}

	private void radioButton_0_CheckedChanged(object sender, EventArgs e)
	{
		if (this.radioButton_0.Checked)
		{
			Control control = this.comboBox_1;
			this.comboBox_2.Enabled = false;
			control.Enabled = false;
			this.comboBox_0.Enabled = false;
			Control control2 = this.dateTimePicker_0;
			this.dateTimePicker_1.Enabled = true;
			control2.Enabled = true;
			this.method_0();
		}
	}

	private void radioButton_3_CheckedChanged(object sender, EventArgs e)
	{
		if (this.radioButton_3.Checked)
		{
			Control control = this.comboBox_1;
			this.comboBox_2.Enabled = false;
			control.Enabled = false;
			this.comboBox_0.Enabled = false;
			Control control2 = this.dateTimePicker_0;
			this.dateTimePicker_1.Enabled = false;
			control2.Enabled = false;
			this.method_0();
		}
	}

	private void method_1()
	{
		this.icontainer_0 = new Container();
		ReportDataSource reportDataSource = new ReportDataSource();
		this.bindingSource_0 = new BindingSource(this.icontainer_0);
		this.dataSet_0 = new DataSet();
		this.dataTable_0 = new DataTable();
		this.dataColumn_0 = new DataColumn();
		this.dataColumn_1 = new DataColumn();
		this.dataColumn_2 = new DataColumn();
		this.dataColumn_3 = new DataColumn();
		this.dataColumn_4 = new DataColumn();
		this.dataColumn_5 = new DataColumn();
		this.splitContainer_0 = new SplitContainer();
		this.radioButton_3 = new RadioButton();
		this.label_0 = new Label();
		this.dateTimePicker_0 = new DateTimePicker();
		this.label_1 = new Label();
		this.dateTimePicker_1 = new DateTimePicker();
		this.radioButton_0 = new RadioButton();
		this.comboBox_0 = new ComboBox();
		this.radioButton_1 = new RadioButton();
		this.comboBox_1 = new ComboBox();
		this.comboBox_2 = new ComboBox();
		this.radioButton_2 = new RadioButton();
		this.label_2 = new Label();
		this.reportViewerRus_0 = new ReportViewerRus();
		((ISupportInitialize)this.bindingSource_0).BeginInit();
		((ISupportInitialize)this.dataSet_0).BeginInit();
		((ISupportInitialize)this.dataTable_0).BeginInit();
		this.splitContainer_0.Panel1.SuspendLayout();
		this.splitContainer_0.Panel2.SuspendLayout();
		this.splitContainer_0.SuspendLayout();
		base.SuspendLayout();
		this.bindingSource_0.DataMember = "tJ_Defect";
		this.bindingSource_0.DataSource = this.dataSet_0;
		this.dataSet_0.DataSetName = "NewDataSet";
		this.dataSet_0.Tables.AddRange(new DataTable[]
		{
			this.dataTable_0
		});
		this.dataTable_0.Columns.AddRange(new DataColumn[]
		{
			this.dataColumn_0,
			this.dataColumn_1,
			this.dataColumn_2,
			this.dataColumn_3,
			this.dataColumn_4,
			this.dataColumn_5
		});
		this.dataTable_0.Constraints.AddRange(new Constraint[]
		{
			new UniqueConstraint("Constraint1", new string[]
			{
				"id"
			}, true)
		});
		this.dataTable_0.PrimaryKey = new DataColumn[]
		{
			this.dataColumn_0
		};
		this.dataTable_0.TableName = "tJ_Defect";
		this.dataColumn_0.AllowDBNull = false;
		this.dataColumn_0.AutoIncrement = true;
		this.dataColumn_0.AutoIncrementStep = -1L;
		this.dataColumn_0.ColumnName = "id";
		this.dataColumn_0.DataType = typeof(int);
		this.dataColumn_1.ColumnName = "num";
		this.dataColumn_1.DataType = typeof(int);
		this.dataColumn_2.ColumnName = "nameDefect";
		this.dataColumn_3.ColumnName = "dateDefect";
		this.dataColumn_3.DataType = typeof(DateTime);
		this.dataColumn_4.ColumnName = "Direct";
		this.dataColumn_5.ColumnName = "Mark";
		this.splitContainer_0.Dock = DockStyle.Fill;
		this.splitContainer_0.Location = new Point(0, 0);
		this.splitContainer_0.Name = "splitContainer1";
		this.splitContainer_0.Panel1.Controls.Add(this.radioButton_3);
		this.splitContainer_0.Panel1.Controls.Add(this.label_0);
		this.splitContainer_0.Panel1.Controls.Add(this.dateTimePicker_0);
		this.splitContainer_0.Panel1.Controls.Add(this.label_1);
		this.splitContainer_0.Panel1.Controls.Add(this.dateTimePicker_1);
		this.splitContainer_0.Panel1.Controls.Add(this.radioButton_0);
		this.splitContainer_0.Panel1.Controls.Add(this.comboBox_0);
		this.splitContainer_0.Panel1.Controls.Add(this.radioButton_1);
		this.splitContainer_0.Panel1.Controls.Add(this.comboBox_1);
		this.splitContainer_0.Panel1.Controls.Add(this.comboBox_2);
		this.splitContainer_0.Panel1.Controls.Add(this.radioButton_2);
		this.splitContainer_0.Panel1.Controls.Add(this.label_2);
		this.splitContainer_0.Panel2.Controls.Add(this.reportViewerRus_0);
		this.splitContainer_0.Size = new Size(885, 393);
		this.splitContainer_0.SplitterDistance = 199;
		this.splitContainer_0.TabIndex = 1;
		this.radioButton_3.AutoSize = true;
		this.radioButton_3.Location = new Point(12, 200);
		this.radioButton_3.Name = "radioButtonAll";
		this.radioButton_3.Size = new Size(44, 17);
		this.radioButton_3.TabIndex = 11;
		this.radioButton_3.TabStop = true;
		this.radioButton_3.Text = "Все";
		this.radioButton_3.UseVisualStyleBackColor = true;
		this.radioButton_3.CheckedChanged += this.radioButton_3_CheckedChanged;
		this.label_0.AutoSize = true;
		this.label_0.Location = new Point(12, 176);
		this.label_0.Name = "label3";
		this.label_0.Size = new Size(19, 13);
		this.label_0.TabIndex = 10;
		this.label_0.Text = "до";
		this.dateTimePicker_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.dateTimePicker_0.Enabled = false;
		this.dateTimePicker_0.Location = new Point(35, 174);
		this.dateTimePicker_0.Name = "dateTimePickerEnd";
		this.dateTimePicker_0.Size = new Size(156, 20);
		this.dateTimePicker_0.TabIndex = 9;
		this.label_1.AutoSize = true;
		this.label_1.Location = new Point(12, 152);
		this.label_1.Name = "label2";
		this.label_1.Size = new Size(18, 13);
		this.label_1.TabIndex = 8;
		this.label_1.Text = "от";
		this.dateTimePicker_1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.dateTimePicker_1.Enabled = false;
		this.dateTimePicker_1.Location = new Point(35, 148);
		this.dateTimePicker_1.Name = "dateTimePickerBeg";
		this.dateTimePicker_1.Size = new Size(156, 20);
		this.dateTimePicker_1.TabIndex = 7;
		this.radioButton_0.AutoSize = true;
		this.radioButton_0.Location = new Point(12, 125);
		this.radioButton_0.Name = "radioButtonPeriod";
		this.radioButton_0.Size = new Size(63, 17);
		this.radioButton_0.TabIndex = 6;
		this.radioButton_0.Text = "Период";
		this.radioButton_0.UseVisualStyleBackColor = true;
		this.radioButton_0.CheckedChanged += this.radioButton_0_CheckedChanged;
		this.comboBox_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.comboBox_0.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBox_0.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBox_0.Enabled = false;
		this.comboBox_0.FormattingEnabled = true;
		this.comboBox_0.Location = new Point(12, 98);
		this.comboBox_0.Name = "cmbYear";
		this.comboBox_0.Size = new Size(179, 21);
		this.comboBox_0.TabIndex = 5;
		this.radioButton_1.AutoSize = true;
		this.radioButton_1.Location = new Point(12, 75);
		this.radioButton_1.Name = "radioButtonYear";
		this.radioButton_1.Size = new Size(43, 17);
		this.radioButton_1.TabIndex = 4;
		this.radioButton_1.Text = "Год";
		this.radioButton_1.UseVisualStyleBackColor = true;
		this.radioButton_1.CheckedChanged += this.radioButton_1_CheckedChanged;
		this.comboBox_1.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.comboBox_1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBox_1.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBox_1.FormattingEnabled = true;
		this.comboBox_1.Location = new Point(125, 48);
		this.comboBox_1.Name = "cmbMonthYear";
		this.comboBox_1.Size = new Size(66, 21);
		this.comboBox_1.TabIndex = 3;
		this.comboBox_2.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.comboBox_2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBox_2.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBox_2.FormattingEnabled = true;
		this.comboBox_2.Items.AddRange(new object[]
		{
			"январь",
			"февраль",
			"март",
			"апрель",
			"май",
			"июнь",
			"июль",
			"август",
			"сентябрь",
			"октябрь",
			"ноябрь",
			"декабрь"
		});
		this.comboBox_2.Location = new Point(12, 48);
		this.comboBox_2.Name = "cmbMonth";
		this.comboBox_2.Size = new Size(112, 21);
		this.comboBox_2.TabIndex = 2;
		this.radioButton_2.AutoSize = true;
		this.radioButton_2.Checked = true;
		this.radioButton_2.Location = new Point(12, 25);
		this.radioButton_2.Name = "radioButtonMonth";
		this.radioButton_2.Size = new Size(58, 17);
		this.radioButton_2.TabIndex = 1;
		this.radioButton_2.TabStop = true;
		this.radioButton_2.Text = "Месяц";
		this.radioButton_2.UseVisualStyleBackColor = true;
		this.radioButton_2.CheckedChanged += this.radioButton_2_CheckedChanged;
		this.label_2.AutoSize = true;
		this.label_2.Location = new Point(12, 9);
		this.label_2.Name = "label1";
		this.label_2.Size = new Size(47, 13);
		this.label_2.TabIndex = 0;
		this.label_2.Text = "Фильтр";
		this.reportViewerRus_0.Dock = DockStyle.Fill;
		reportDataSource.Name = "DataSet1";
		reportDataSource.Value = this.bindingSource_0;
		this.reportViewerRus_0.LocalReport.DataSources.Add(reportDataSource);
		this.reportViewerRus_0.LocalReport.ReportEmbeddedResource = "Documents.Forms.JournalDefect.ReportJDefect.rdlc";
		this.reportViewerRus_0.Location = new Point(0, 0);
		this.reportViewerRus_0.Name = "reportViewerRus1";
		this.reportViewerRus_0.Size = new Size(682, 393);
		this.reportViewerRus_0.TabIndex = 0;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(885, 393);
		base.Controls.Add(this.splitContainer_0);
		base.Name = "FormJDefectReport";
		this.Text = "Журнал дефктов и неполадок";
		base.Load += this.Form70_Load;
		((ISupportInitialize)this.bindingSource_0).EndInit();
		((ISupportInitialize)this.dataSet_0).EndInit();
		((ISupportInitialize)this.dataTable_0).EndInit();
		this.splitContainer_0.Panel1.ResumeLayout(false);
		this.splitContainer_0.Panel1.PerformLayout();
		this.splitContainer_0.Panel2.ResumeLayout(false);
		this.splitContainer_0.ResumeLayout(false);
		base.ResumeLayout(false);
	}

	private SplitContainer splitContainer_0;

	private Label label_0;

	private DateTimePicker dateTimePicker_0;

	private Label label_1;

	private DateTimePicker dateTimePicker_1;

	private RadioButton radioButton_0;

	private ComboBox comboBox_0;

	private RadioButton radioButton_1;

	private ComboBox comboBox_1;

	private ComboBox comboBox_2;

	private RadioButton radioButton_2;

	private Label label_2;

	private ReportViewerRus reportViewerRus_0;

	private BindingSource bindingSource_0;

	private RadioButton radioButton_3;

	private DataSet dataSet_0;

	private DataTable dataTable_0;

	private DataColumn dataColumn_0;

	private DataColumn dataColumn_1;

	private DataColumn dataColumn_2;

	private DataColumn dataColumn_3;

	private DataColumn dataColumn_4;

	private DataColumn dataColumn_5;
}
