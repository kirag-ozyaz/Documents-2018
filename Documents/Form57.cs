using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ControlsLbr.ReportViewerRus;
using FormLbr;
using Microsoft.Reporting.WinForms;

internal partial class Form57 : FormBase
{
	internal Form57()
	{
		
		
		this.method_0();
	}

	private void Form57_Load(object sender, EventArgs e)
	{
		string str = " (deleted = 0 and deletedObj = 0) ";
		base.SelectSqlData(this.class255_0, this.class255_0.vJ_RelayProtectionAutomation, true, " where " + str + " order by Sub_name, bus_name, cell_name");
		this.reportViewerRus_0.RefreshReport();
	}

	private void method_0()
	{
		this.icontainer_0 = new Container();
		ReportDataSource reportDataSource = new ReportDataSource();
		this.bindingSource_0 = new BindingSource(this.icontainer_0);
		this.class255_0 = new Class255();
		this.reportViewerRus_0 = new ReportViewerRus();
		((ISupportInitialize)this.bindingSource_0).BeginInit();
		((ISupportInitialize)this.class255_0).BeginInit();
		base.SuspendLayout();
		this.bindingSource_0.DataMember = "vJ_RelayProtectionAutomation";
		this.bindingSource_0.DataSource = this.class255_0;
		this.class255_0.DataSetName = "DataSetGES";
		this.class255_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		this.reportViewerRus_0.Dock = DockStyle.Fill;
		reportDataSource.Name = "dsGES";
		reportDataSource.Value = this.bindingSource_0;
		this.reportViewerRus_0.LocalReport.DataSources.Add(reportDataSource);
		this.reportViewerRus_0.LocalReport.ReportEmbeddedResource = "Documents.Forms.JournalRelayProtectionAutomation.ReportRelayProtectionAutomation.rdlc";
		this.reportViewerRus_0.Location = new Point(0, 0);
		this.reportViewerRus_0.Name = "reportViewer1";
		this.reportViewerRus_0.Size = new Size(603, 262);
		this.reportViewerRus_0.TabIndex = 0;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(603, 262);
		base.Controls.Add(this.reportViewerRus_0);
		base.Name = "FormReportRelayProtectionAutomation";
		this.Text = "FormReportRelayProtectionAutomation";
		base.Load += this.Form57_Load;
		((ISupportInitialize)this.bindingSource_0).EndInit();
		((ISupportInitialize)this.class255_0).EndInit();
		base.ResumeLayout(false);
	}

	private ReportViewerRus reportViewerRus_0;

	private BindingSource bindingSource_0;

	private Class255 class255_0;
}
