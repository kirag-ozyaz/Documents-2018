using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ControlsLbr.ReportViewerRus;
using FormLbr;
using Microsoft.Reporting.WinForms;

internal partial class Form52 : FormBase
{
	public Form52(int int_1)
	{
		
		this.int_0 = -1;
		
		this.method_0();
		this.int_0 = int_1;
	}

	private void Form52_Load(object sender, EventArgs e)
	{
		base.SelectSqlData(this.class255_0, this.class255_0.vJ_Request, true, " where id = " + this.int_0.ToString());
		base.SelectSqlData(this.class255_0, this.class255_0.tJ_RequestDoc, true, "where idRequest = " + this.int_0.ToString());
		this.reportViewerRus_0.RefreshReport();
	}

	private void method_0()
	{
		this.icontainer_0 = new Container();
		ReportDataSource reportDataSource = new ReportDataSource();
		ReportDataSource reportDataSource2 = new ReportDataSource();
		this.bindingSource_0 = new BindingSource(this.icontainer_0);
		this.class255_0 = new Class255();
		this.reportViewerRus_0 = new ReportViewerRus();
		this.bindingSource_1 = new BindingSource(this.icontainer_0);
		((ISupportInitialize)this.bindingSource_0).BeginInit();
		((ISupportInitialize)this.class255_0).BeginInit();
		((ISupportInitialize)this.bindingSource_1).BeginInit();
		base.SuspendLayout();
		this.bindingSource_0.DataMember = "vJ_Request";
		this.bindingSource_0.DataSource = this.class255_0;
		this.class255_0.DataSetName = "DataSetGES";
		this.class255_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		this.reportViewerRus_0.Dock = DockStyle.Fill;
		reportDataSource.Name = "DataSetGES";
		reportDataSource.Value = this.bindingSource_0;
		reportDataSource2.Name = "DataSetDoc";
		reportDataSource2.Value = this.bindingSource_1;
		this.reportViewerRus_0.LocalReport.DataSources.Add(reportDataSource);
		this.reportViewerRus_0.LocalReport.DataSources.Add(reportDataSource2);
		this.reportViewerRus_0.LocalReport.ReportEmbeddedResource = "Documents.Forms.JournalRequest.ReportRequest.rdlc";
		this.reportViewerRus_0.Location = new Point(0, 0);
		this.reportViewerRus_0.Name = "reportViewerRus1";
		this.reportViewerRus_0.Size = new Size(408, 262);
		this.reportViewerRus_0.TabIndex = 0;
		this.bindingSource_1.DataMember = "tJ_RequestDoc";
		this.bindingSource_1.DataSource = this.class255_0;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(408, 262);
		base.Controls.Add(this.reportViewerRus_0);
		base.Name = "FormReportRequest";
		this.Text = "Печать задлачи";
		base.Load += this.Form52_Load;
		((ISupportInitialize)this.bindingSource_0).EndInit();
		((ISupportInitialize)this.class255_0).EndInit();
		((ISupportInitialize)this.bindingSource_1).EndInit();
		base.ResumeLayout(false);
	}

	internal static void x2d4M10gsFRnO4jKLfbe(Form form_0, bool bool_0)
	{
		form_0.Dispose(bool_0);
	}

	private int int_0;

	private Class255 class255_0;

	private ReportViewerRus reportViewerRus_0;

	private BindingSource bindingSource_0;

	private BindingSource bindingSource_1;
}
