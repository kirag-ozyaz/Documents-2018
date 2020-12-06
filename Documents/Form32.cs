using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using FormLbr;
using Microsoft.Reporting.WinForms;

internal partial class Form32 : FormBase
{
	internal Form32()
	{
		
		this.int_0 = -1;
		
		this.method_2();
	}

	internal Form32(int int_1)
	{
		
		this.int_0 = -1;
		
		this.method_2();
		this.int_0 = int_1;
		this.reportViewer_0.LocalReport.SubreportProcessing += this.method_0;
	}

	private void method_0(object sender, SubreportProcessingEventArgs e)
	{
	}

	private void Form32_Load(object sender, EventArgs e)
	{
		base.SelectSqlData(this.kwqoanwqrrJ, this.kwqoanwqrrJ.tJ_Order, true, " where id = " + this.int_0.ToString());
		base.SelectSqlData(this.kwqoanwqrrJ, this.kwqoanwqrrJ.vJ_Order, true, " where id = " + this.int_0.ToString());
		base.SelectSqlData(this.kwqoanwqrrJ, this.kwqoanwqrrJ.tJ_OrderBrigade, true, " where idorder = " + this.int_0.ToString());
		string text = "";
		foreach (object obj in this.kwqoanwqrrJ.tJ_OrderBrigade.Rows)
		{
			DataRow dataRow = (DataRow)obj;
			text = text + dataRow["idWorker"].ToString() + ",";
		}
		if (!string.IsNullOrEmpty(text))
		{
			text = text.Remove(text.Length - 1);
			base.SelectSqlData(this.kwqoanwqrrJ, this.kwqoanwqrrJ.vR_Worker, true, " where id in (" + text + ")");
		}
		string text2 = "";
		foreach (DataRow dataRow2 in this.kwqoanwqrrJ.vR_Worker)
		{
			string str = "";
			if (dataRow2["GroupElectrical"] != DBNull.Value)
			{
				switch (Convert.ToInt32(dataRow2["GroupElectrical"]))
				{
				case 1:
					str = " I гр.";
					break;
				case 2:
					str = " II гр.";
					break;
				case 3:
					str = " III гр.";
					break;
				case 4:
					str = " IV гр.";
					break;
				case 5:
					str = " V гр.";
					break;
				}
			}
			text2 = text2 + dataRow2["FIO"].ToString() + str + ",";
		}
		if (!string.IsNullOrEmpty(text2))
		{
			text2 = text2.Remove(text2.Length - 1);
		}
		ReportParameter reportParameter = new ReportParameter("Brigade", text2);
		this.reportViewer_0.LocalReport.SetParameters(new ReportParameter[]
		{
			reportParameter
		});
		base.SelectSqlData(this.kwqoanwqrrJ, this.kwqoanwqrrJ.tJ_OrderInstruction, true, " where idorder = " + this.int_0.ToString() + " order by rec_num");
		base.SelectSqlData(this.kwqoanwqrrJ, this.kwqoanwqrrJ.tJ_OrderResolution, true, " where idorder = " + this.int_0.ToString() + " order by datebegin ");
		this.reportViewer_0.RefreshReport();
	}

	private void method_1(object sender, SubreportProcessingEventArgs e)
	{
	}

	private void method_2()
	{
		this.icontainer_0 = new Container();
		ReportDataSource reportDataSource = new ReportDataSource();
		ReportDataSource reportDataSource2 = new ReportDataSource();
		this.bindingSource_0 = new BindingSource(this.icontainer_0);
		this.kwqoanwqrrJ = new Class469();
		this.bindingSource_1 = new BindingSource(this.icontainer_0);
		this.reportViewer_0 = new ReportViewer();
		((ISupportInitialize)this.bindingSource_0).BeginInit();
		((ISupportInitialize)this.kwqoanwqrrJ).BeginInit();
		((ISupportInitialize)this.bindingSource_1).BeginInit();
		base.SuspendLayout();
		this.bindingSource_0.DataMember = "vJ_Order";
		this.bindingSource_0.DataSource = this.kwqoanwqrrJ;
		this.kwqoanwqrrJ.DataSetName = "DataSetOrder";
		this.kwqoanwqrrJ.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		this.bindingSource_1.DataMember = "tJ_OrderInstruction";
		this.bindingSource_1.DataSource = this.kwqoanwqrrJ;
		this.reportViewer_0.Dock = DockStyle.Fill;
		reportDataSource.Name = "vJ_Order";
		reportDataSource.Value = this.bindingSource_0;
		reportDataSource2.Name = "tJ_OrderInstruction";
		reportDataSource2.Value = this.bindingSource_1;
		this.reportViewer_0.LocalReport.DataSources.Add(reportDataSource);
		this.reportViewer_0.LocalReport.DataSources.Add(reportDataSource2);
		this.reportViewer_0.LocalReport.ReportEmbeddedResource = "Documents.Reports.ReportOrder.rdlc";
		this.reportViewer_0.Location = new Point(0, 0);
		this.reportViewer_0.Name = "reportViewer1";
		this.reportViewer_0.Size = new Size(607, 430);
		this.reportViewer_0.TabIndex = 0;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(607, 430);
		base.Controls.Add(this.reportViewer_0);
		base.Name = "FormReportOrder";
		this.Text = "FormReportOrder";
		base.Load += this.Form32_Load;
		((ISupportInitialize)this.bindingSource_0).EndInit();
		((ISupportInitialize)this.kwqoanwqrrJ).EndInit();
		((ISupportInitialize)this.bindingSource_1).EndInit();
		base.ResumeLayout(false);
	}

	internal static void CZlDBeO8k7iG5fKB3sHq(Form form_0, bool bool_0)
	{
		form_0.Dispose(bool_0);
	}

	private int int_0;

	private Class469 kwqoanwqrrJ;

	private ReportViewer reportViewer_0;

	private BindingSource bindingSource_0;

	private BindingSource bindingSource_1;
}
