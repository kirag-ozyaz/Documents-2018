using ControlsLbr.ReportViewerRus;
using Microsoft.Reporting.WinForms;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

internal partial class FormReportAct : global::FormLbr.FormBase
{
	protected override void Dispose(bool disposing)
	{
		if (disposing && this.components != null)
		{
			this.components.Dispose();
		}
		base.Dispose(disposing);
	}

	private global::System.ComponentModel.IContainer components;
    private void InitializeComponent()
    {
        this.components = new Container();
        ReportDataSource reportDataSource = new ReportDataSource();
        ComponentResourceManager components = new ComponentResourceManager(typeof(FormReportAct));
        this.reportViewerRus_0 = new ReportViewerRus();
        this.dataSetExcavation = new DataSetExcavation();
        this.bindingSource = new BindingSource(this.components);
        ((ISupportInitialize)this.dataSetExcavation).BeginInit();
        ((ISupportInitialize)this.bindingSource).BeginInit();
        base.SuspendLayout();
        this.reportViewerRus_0.Dock = DockStyle.Fill;
        reportDataSource.Name = "DataSetRecovery";
        reportDataSource.Value = this.bindingSource;
        this.reportViewerRus_0.LocalReport.DataSources.Add(reportDataSource);
        this.reportViewerRus_0.LocalReport.ReportEmbeddedResource = "Documents.Forms.JournalExcavation.Reports.ReportExcavationAct.rdlc";
        this.reportViewerRus_0.Location = new Point(0, 0);
        this.reportViewerRus_0.Name = "reportViewerRus1";
        this.reportViewerRus_0.Size = new Size(667, 414);
        this.reportViewerRus_0.TabIndex = 0;
        this.dataSetExcavation.DataSetName = "DataSetExcavation";
        this.dataSetExcavation.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
        base.AutoScaleDimensions = new SizeF(6f, 13f);
        base.AutoScaleMode = AutoScaleMode.Font;
        base.ClientSize = new Size(667, 414);
        base.Controls.Add(this.reportViewerRus_0);
        base.Icon = (Icon)components.GetObject("$this.Icon");
        base.Name = "FormReportAct";
        this.Text = "Акт передачи раскопок под асфальтирование";
        base.Load += this.FormReportAct_Load;
        ((ISupportInitialize)this.dataSetExcavation).EndInit();
        ((ISupportInitialize)this.bindingSource).EndInit();
        base.ResumeLayout(false);
    }
    private ReportViewerRus reportViewerRus_0;
    private DataSetExcavation dataSetExcavation;
    private BindingSource bindingSource;
}
