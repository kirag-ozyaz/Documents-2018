using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using ControlsLbr.ReportViewerRus;
using FormLbr;
using Microsoft.Reporting.WinForms;

internal partial class Form78 : FormBase
{
	internal Form78()
	{
		
		
		this.method_1();
		this.dateTimePicker_0 = new DateTimePicker();
		this.dateTimePicker_0.Value = DateTime.Now.Date;
		this.toolStrip_0.Items.Insert(1, new ToolStripControlHost(this.dateTimePicker_0));
		this.checkBox_0 = new CheckBox();
		this.checkBox_0.Text = "Разбить по районам";
		this.toolStrip_0.Items.Insert(2, new ToolStripControlHost(this.checkBox_0));
	}

	private void method_0()
	{
		this.class171_0.ReportDailyLV.Clear();
		this.class171_0.vJ_Temperature.Clear();
		this.reportViewerRus_0.LocalReport.ReportEmbeddedResource = "Documents.Forms.DailyReport.Reports.ReportDailyLV.rdlc";
		this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter("dateReport", this.dateTimePicker_0.Value.ToString()));
		this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter("GroupNetRegion", (!this.checkBox_0.Checked).ToString()));
		using (SqlConnection sqlConnection = new SqlConnection(this.SqlSettings.GetConnectionString() + ";Connection Timeout=1000"))
		{
			sqlConnection.Open();
			using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
			{
				try
				{
					using (SqlCommand sqlCommand = new SqlCommand("SELECT t.[id],t.[DateTemp],t.[NightDown],t.[NightUp],t.[DayDown],t.[DayUp],t.[TempAverage],t.[Wind]\r\n                                            ,c.name as windname,t.[SpeedDown],t.[SpeedUp],t.[Comment],t.[DateOwner],t.[idOwner],t.[Owner]\r\n                                    FROM [tJ_Temperature] t\r\n                                             LEFT JOIN tr_Classifier c on c.id = t.wind\r\n                                    WHERE t.dateTEmp = @date", sqlConnection))
					{
						sqlCommand.CommandTimeout = 0;
						sqlCommand.Transaction = sqlTransaction;
						sqlCommand.Parameters.Add("date", SqlDbType.DateTime).Value = this.dateTimePicker_0.Value.Date;
						new SqlDataAdapter(sqlCommand).Fill(this.class171_0.vJ_Temperature);
					}
					if (this.class171_0.vJ_Temperature.Rows.Count > 0)
					{
						using (SqlCommand sqlCommand2 = new SqlCommand(Class7.smethod_2("Documents.Forms.DailyReport.SqlScripts.ReportDailyLV.sql"), sqlConnection))
						{
							sqlCommand2.CommandTimeout = 0;
							sqlCommand2.Transaction = sqlTransaction;
							sqlCommand2.Parameters.Add("date", SqlDbType.DateTime).Value = this.dateTimePicker_0.Value.Date;
							new SqlDataAdapter(sqlCommand2).Fill(this.class171_0.ReportDailyLV);
						}
						using (SqlCommand sqlCommand3 = new SqlCommand("select isnull(w.fio, u.name) as name from tuser u\r\n\t                                left join vr_worker w on u.idWorker = w.id\r\n                                    where login = SYSTEM_USER", sqlConnection))
						{
							sqlCommand3.CommandTimeout = 0;
							sqlCommand3.Transaction = sqlTransaction;
							DbDataAdapter dbDataAdapter = new SqlDataAdapter(sqlCommand3);
							DataTable dataTable = new DataTable();
							dbDataAdapter.Fill(dataTable);
							if (dataTable.Rows.Count > 0 && dataTable.Rows[0]["name"] != DBNull.Value)
							{
								this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter("reportUser", dataTable.Rows[0]["name"].ToString()));
							}
							goto IL_27E;
						}
					}
					this.reportViewerRus_0.LocalReport.ReportEmbeddedResource = null;
					MessageBox.Show("На данную дату не введены показания температуры");
					IL_27E:
					sqlTransaction.Commit();
				}
				catch (Exception ex)
				{
					sqlTransaction.Rollback();
					MessageBox.Show(ex.Message, ex.Source);
				}
			}
		}
		this.reportViewerRus_0.RefreshReport();
	}

	private void Form78_Load(object sender, EventArgs e)
	{
		this.method_0();
	}

	private void toolStripButton_0_Click(object sender, EventArgs e)
	{
		this.method_0();
	}

	private void method_1()
	{
		this.icontainer_0 = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form78));
		ReportDataSource reportDataSource = new ReportDataSource();
		ReportDataSource reportDataSource2 = new ReportDataSource();
		this.bindingSource_0 = new BindingSource(this.icontainer_0);
		this.class171_0 = new Class171();
		this.bindingSource_1 = new BindingSource(this.icontainer_0);
		this.toolStrip_0 = new ToolStrip();
		this.toolStripLabel_0 = new ToolStripLabel();
		this.toolStripButton_0 = new ToolStripButton();
		this.reportViewerRus_0 = new ReportViewerRus();
		((ISupportInitialize)this.bindingSource_0).BeginInit();
		((ISupportInitialize)this.class171_0).BeginInit();
		((ISupportInitialize)this.bindingSource_1).BeginInit();
		this.toolStrip_0.SuspendLayout();
		base.SuspendLayout();
		this.bindingSource_0.DataMember = "ReportDailyLV";
		this.bindingSource_0.DataSource = this.class171_0;
		this.class171_0.DataSetName = "DataSetDamage";
		this.class171_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		this.bindingSource_1.DataMember = "vJ_Temperature";
		this.bindingSource_1.DataSource = this.class171_0;
		this.toolStrip_0.Items.AddRange(new ToolStripItem[]
		{
			this.toolStripLabel_0,
			this.toolStripButton_0
		});
		this.toolStrip_0.Location = new Point(0, 0);
		this.toolStrip_0.Name = "toolStrip";
		this.toolStrip_0.Size = new Size(751, 25);
		this.toolStrip_0.TabIndex = 0;
		this.toolStrip_0.Text = "toolStrip1";
		this.toolStripLabel_0.Name = "toolStripLabel1";
		this.toolStripLabel_0.Size = new Size(73, 22);
		this.toolStripLabel_0.Text = "Выбор даты";
		this.toolStripButton_0.DisplayStyle = ToolStripItemDisplayStyle.Text;
		this.toolStripButton_0.Image = (Image)componentResourceManager.GetObject("toolBtnLoad.Image");
		this.toolStripButton_0.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_0.Name = "toolBtnLoad";
		this.toolStripButton_0.Size = new Size(74, 22);
		this.toolStripButton_0.Text = "Применить";
		this.toolStripButton_0.Click += this.toolStripButton_0_Click;
		this.reportViewerRus_0.Dock = DockStyle.Fill;
		reportDataSource.Name = "DataSetReport";
		reportDataSource.Value = this.bindingSource_0;
		reportDataSource2.Name = "DataSetTemperature";
		reportDataSource2.Value = this.bindingSource_1;
		this.reportViewerRus_0.LocalReport.DataSources.Add(reportDataSource);
		this.reportViewerRus_0.LocalReport.DataSources.Add(reportDataSource2);
		this.reportViewerRus_0.LocalReport.ReportEmbeddedResource = "Documents.Forms.DailyReport.Reports.ReportDailyLV.rdlc";
		this.reportViewerRus_0.Location = new Point(0, 25);
		this.reportViewerRus_0.Name = "reportViewerRus1";
		this.reportViewerRus_0.Size = new Size(751, 488);
		this.reportViewerRus_0.TabIndex = 1;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(751, 513);
		base.Controls.Add(this.reportViewerRus_0);
		base.Controls.Add(this.toolStrip_0);
		base.Name = "FormReportDailyLV";
		this.Text = "Суточный рапорт в сетях 0,4 кВ (ОДС)";
		base.Load += this.Form78_Load;
		((ISupportInitialize)this.bindingSource_0).EndInit();
		((ISupportInitialize)this.class171_0).EndInit();
		((ISupportInitialize)this.bindingSource_1).EndInit();
		this.toolStrip_0.ResumeLayout(false);
		this.toolStrip_0.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	private DateTimePicker dateTimePicker_0;

	private CheckBox checkBox_0;

	private ToolStrip toolStrip_0;

	private ToolStripLabel toolStripLabel_0;

	private ToolStripButton toolStripButton_0;

	private ReportViewerRus reportViewerRus_0;

	private BindingSource bindingSource_0;

	private Class171 class171_0;

	private BindingSource bindingSource_1;
}
