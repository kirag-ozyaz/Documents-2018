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

///
/// FormReportDailyHV
///
internal partial class Form77 : FormBase
{
	internal Form77()
	{
		
		
		this.method_1();
		this.dateTimePicker_0 = new DateTimePicker();
		this.dateTimePicker_0.Value = DateTime.Now.Date;
		this.toolStrip_0.Items.Insert(1, new ToolStripControlHost(this.dateTimePicker_0));
		this.dateTimePicker_1 = new DateTimePicker();
		this.dateTimePicker_1.Value = DateTime.Now.Date;
		this.toolStrip_0.Items.Insert(3, new ToolStripControlHost(this.dateTimePicker_1));
		this.checkBox_0 = new CheckBox();
		this.checkBox_0.Text = "Показать состав дежурных";
		this.checkBox_0.Checked = false;
		this.toolStrip_0.Items.Insert(4, new ToolStripControlHost(this.checkBox_0));
	}

	private void method_0()
	{
		this.class171_0.ReportDailyHV.Clear();
		this.reportViewerRus_0.LocalReport.ReportEmbeddedResource = "Documents.Forms.DailyReport.Reports.ReportDailyHV.rdlc";
		string value = this.dateTimePicker_0.Value.ToString("dd.MM.yyyy");
		if (this.dateTimePicker_0.Value != this.dateTimePicker_1.Value)
		{
			value = this.dateTimePicker_0.Value.ToString("dd.MM.yyyy") + " - " + this.dateTimePicker_1.Value.ToString("dd.MM.yyyy");
		}
		this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter("dateReport", value));
		this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter("ShowDispatcher", this.checkBox_0.Checked.ToString()));
		using (SqlConnection sqlConnection = new SqlConnection(this.SqlSettings.GetConnectionString() + ";Connection Timeout=1000"))
		{
			sqlConnection.Open();
			using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
			{
				try
				{
					using (SqlCommand sqlCommand = new SqlCommand(Class7.smethod_2("Documents.Forms.DailyReport.SqlScripts.ReportDailyHV.sql"), sqlConnection))
					{
						sqlCommand.CommandTimeout = 0;
						sqlCommand.Transaction = sqlTransaction;
						sqlCommand.Parameters.Add("dateBeg", SqlDbType.DateTime).Value = this.dateTimePicker_0.Value.Date;
						sqlCommand.Parameters.Add("dateEnd", SqlDbType.DateTime).Value = this.dateTimePicker_1.Value.Date.AddDays(1.0).AddMilliseconds(-1.0);
						new SqlDataAdapter(sqlCommand).Fill(this.class171_0.ReportDailyHV);
					}
					using (SqlCommand sqlCommand2 = new SqlCommand("select isnull(w.fio, u.name) as name from tuser u\r\n\t                                left join vr_worker w on u.idWorker = w.id\r\n                                    where login = SYSTEM_USER", sqlConnection))
					{
						sqlCommand2.CommandTimeout = 0;
						sqlCommand2.Transaction = sqlTransaction;
						DbDataAdapter dbDataAdapter = new SqlDataAdapter(sqlCommand2);
						DataTable dataTable = new DataTable();
						dbDataAdapter.Fill(dataTable);
						if (dataTable.Rows.Count > 0 && dataTable.Rows[0]["name"] != DBNull.Value)
						{
							this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter("reportUser", dataTable.Rows[0]["name"].ToString()));
						}
					}
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

	private void Form77_Load(object sender, EventArgs e)
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form77));
		ReportDataSource reportDataSource = new ReportDataSource();
		this.bindingSource_0 = new BindingSource(this.icontainer_0);
		this.class171_0 = new Class171();
		this.toolStrip_0 = new ToolStrip();
		this.toolStripLabel_0 = new ToolStripLabel();
		this.toolStripLabel_1 = new ToolStripLabel();
		this.toolStripButton_0 = new ToolStripButton();
		this.reportViewerRus_0 = new ReportViewerRus();
		((ISupportInitialize)this.bindingSource_0).BeginInit();
		((ISupportInitialize)this.class171_0).BeginInit();
		this.toolStrip_0.SuspendLayout();
		base.SuspendLayout();
		this.bindingSource_0.DataMember = "ReportDailyHV";
		this.bindingSource_0.DataSource = this.class171_0;
		this.class171_0.DataSetName = "DataSetDamage";
		this.class171_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		this.toolStrip_0.Items.AddRange(new ToolStripItem[]
		{
			this.toolStripLabel_0,
			this.toolStripLabel_1,
			this.toolStripButton_0
		});
		this.toolStrip_0.Location = new Point(0, 0);
		this.toolStrip_0.Name = "toolStrip";
		this.toolStrip_0.Size = new Size(810, 25);
		this.toolStrip_0.TabIndex = 1;
		this.toolStrip_0.Text = "toolStrip1";
		this.toolStripLabel_0.Name = "toolStripLabel1";
		this.toolStripLabel_0.Size = new Size(88, 22);
		this.toolStripLabel_0.Text = "Выбор даты от";
		this.toolStripLabel_1.Name = "toolStripLabel2";
		this.toolStripLabel_1.Size = new Size(20, 22);
		this.toolStripLabel_1.Text = "до";
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
		this.reportViewerRus_0.LocalReport.DataSources.Add(reportDataSource);
		this.reportViewerRus_0.LocalReport.ReportEmbeddedResource = "Documents.Forms.DailyReport.Reports.ReportDailyHV.rdlc";
		this.reportViewerRus_0.Location = new Point(0, 25);
		this.reportViewerRus_0.Name = "reportViewerRus1";
		this.reportViewerRus_0.Size = new Size(810, 480);
		this.reportViewerRus_0.TabIndex = 2;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(810, 505);
		base.Controls.Add(this.reportViewerRus_0);
		base.Controls.Add(this.toolStrip_0);
		base.Name = "FormReportDailyHV";
		this.Text = "Суточный рапорт в сетях 10/6 кВ";
		base.Load += this.Form77_Load;
		((ISupportInitialize)this.bindingSource_0).EndInit();
		((ISupportInitialize)this.class171_0).EndInit();
		this.toolStrip_0.ResumeLayout(false);
		this.toolStrip_0.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	private DateTimePicker dateTimePicker_0;

	private DateTimePicker dateTimePicker_1;

	private CheckBox checkBox_0;

	private ToolStrip toolStrip_0;

	private ToolStripLabel toolStripLabel_0;

	private ToolStripButton toolStripButton_0;

	private ReportViewerRus reportViewerRus_0;

	private ToolStripLabel toolStripLabel_1;

	private Class171 class171_0;

	private BindingSource bindingSource_0;
}
