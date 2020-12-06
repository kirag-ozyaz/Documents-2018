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

internal partial class Form16 : FormBase
{
	internal Form16()
	{
		
		
		this.method_1();
		this.dateTimePicker_1.Value = new DateTime(DateTime.Now.Year, 1, 1);
		this.dateTimePicker_0.Value = new DateTime(DateTime.Now.Year + 1, 1, 1).AddSeconds(-1.0);
	}

	private void Form16_Load(object sender, EventArgs e)
	{
		this.method_0();
	}

	private void method_0()
	{
		DbDataAdapter dbDataAdapter = new SqlDataAdapter(string.Concat(new string[]
		{
			"with Request(VoltageLevel, CategoryPower, [Count], PowerAdd, [PowerSum]) as  (select case when voltage.ParentKey = ';VoltageLevels;LV;' then '0,4' when voltage.ParentKey = ';VoltageLevels;MV;' then '6-10' when voltage.ParentKey = ';VoltageLevels;HV;' then '35-110' else 'неопределено' end as VoltageLevel, case when voltage.ParentKey = ';VoltageLevels;LV;' then case when r.power <= 15 then 'до 15 кВт' when r.Power > 15  and r.Power <= 150  then 'свыше 15 кВт до 150 кВт' when r.Power > 150 and r.Power <= 8900 then 'свыше 150 кВт до 8900 кВт' else 'неопределено' end when voltage.ParentKey = ';VoltageLevels;MV;' then case when r.power <= 15 then  'до 15 кВт' when r.Power > 15  and r.Power <= 150  then 'свыше 15 кВт до 150 кВт' when r.Power > 150 and r.Power <= 8900 then 'свыше 150 кВт до 8900 кВт' else 'неопределено' end when voltage.ParentKey = ';VoltageLevels;HV;' then case when r.Power > 150 and r.Power <= 8900  then 'свыше 150 кВт до 8900 кВт' when r.Power > 8900 then 'свыше 8900 кВт' else 'неопределено' end else 'неопределено' end CategoryPower, count (*) as [count], sum(PowerAdd) as PowerAdd, sum([Power]) as [Power] from ttc_Doc dReq left join ttc_request r on r.id = dReq.id left join tr_classifier voltage on  voltage.id = r.voltagelevel where dReq.typeDoc = 1113 and dReq.DateDoc >= '",
			this.dateTimePicker_1.Value.ToString("yyyyMMdd"),
			"' and dREq.DateDoc <= '",
			this.dateTimePicker_0.Value.ToString("yyyyMMdd"),
			"' group by voltage.ParentKey, ( case when voltage.ParentKey = ';VoltageLevels;LV;' then  case when r.power <= 15 then 'до 15 кВт' when r.Power > 15  and r.Power <= 150  then 'свыше 15 кВт до 150 кВт' when r.Power > 150 and r.Power <= 8900 then 'свыше 150 кВт до 8900 кВт' else 'неопределено' end when voltage.ParentKey = ';VoltageLevels;MV;' then case when r.power <= 15 then  'до 15 кВт'  when r.Power > 15  and r.Power <= 150  then 'свыше 15 кВт до 150 кВт' when r.Power > 150 and r.Power <= 8900 then 'свыше 150 кВт до 8900 кВт' else 'неопределено' end when voltage.ParentKey = ';VoltageLevels;HV;' then case when r.Power > 150 and r.Power <= 8900  then 'свыше 150 кВт до 8900 кВт' when r.Power > 8900 then 'свыше 8900 кВт' else 'неопределено' end else 'неопределено' end))  select * from request order by (case when voltageLevel = '0,4' then 1 when voltageLevel = '6-10' then 2\t when voltageLevel = '35-110' then 3 else 4\tend), (case when CategoryPower = 'до 15 кВт' then 1  when CategoryPower = 'свыше 15 кВт до 150 кВт' then 2 when CategoryPower = 'свыше 150 кВт до 8900 кВт' then 3 when CategoryPower = 'свыше 8900 кВт' then 4 else 5 end) "
		}), this.SqlSettings.GetConnectionString());
		this.class10_0.ReportCountRequest.Clear();
		dbDataAdapter.Fill(this.class10_0.ReportCountRequest);
		ReportParameter reportParameter = new ReportParameter("dBeg", this.dateTimePicker_1.Value.ToString("dd.MM.yyyy"));
		this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
		{
			reportParameter
		});
		reportParameter = new ReportParameter("dEnd", this.dateTimePicker_0.Value.ToString("dd.MM.yyyy"));
		this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
		{
			reportParameter
		});
		this.reportViewerRus_0.RefreshReport();
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		this.method_0();
	}

	private void method_1()
	{
		this.icontainer_0 = new Container();
		ReportDataSource reportDataSource = new ReportDataSource();
		this.reportViewerRus_0 = new ReportViewerRus();
		this.class10_0 = new Class10();
		this.bindingSource_0 = new BindingSource(this.icontainer_0);
		this.panel_0 = new Panel();
		this.label_1 = new Label();
		this.dateTimePicker_1 = new DateTimePicker();
		this.label_0 = new Label();
		this.dateTimePicker_0 = new DateTimePicker();
		this.button_0 = new Button();
		((ISupportInitialize)this.class10_0).BeginInit();
		((ISupportInitialize)this.bindingSource_0).BeginInit();
		this.panel_0.SuspendLayout();
		base.SuspendLayout();
		this.reportViewerRus_0.Dock = DockStyle.Fill;
		reportDataSource.Name = "ReportCountRequest";
		reportDataSource.Value = this.bindingSource_0;
		this.reportViewerRus_0.LocalReport.DataSources.Add(reportDataSource);
		this.reportViewerRus_0.LocalReport.ReportEmbeddedResource = "Documents.Forms.TechnologicalConnection.Report.FileReports.ReportCountRequest.rdlc";
		this.reportViewerRus_0.Location = new Point(0, 49);
		this.reportViewerRus_0.Name = "reportViewerRus1";
		this.reportViewerRus_0.Size = new Size(632, 467);
		this.reportViewerRus_0.TabIndex = 1;
		this.class10_0.DataSetName = "DataSetTechConnection";
		this.class10_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		this.bindingSource_0.DataMember = "ReportCountRequest";
		this.bindingSource_0.DataSource = this.class10_0;
		this.panel_0.Controls.Add(this.button_0);
		this.panel_0.Controls.Add(this.dateTimePicker_0);
		this.panel_0.Controls.Add(this.label_0);
		this.panel_0.Controls.Add(this.dateTimePicker_1);
		this.panel_0.Controls.Add(this.label_1);
		this.panel_0.Dock = DockStyle.Top;
		this.panel_0.Location = new Point(0, 0);
		this.panel_0.Name = "panel1";
		this.panel_0.Size = new Size(632, 49);
		this.panel_0.TabIndex = 2;
		this.label_1.AutoSize = true;
		this.label_1.Location = new Point(9, 18);
		this.label_1.Name = "label1";
		this.label_1.Size = new Size(13, 13);
		this.label_1.TabIndex = 0;
		this.label_1.Text = "с";
		this.dateTimePicker_1.Location = new Point(28, 12);
		this.dateTimePicker_1.Name = "dtpBegin";
		this.dateTimePicker_1.Size = new Size(137, 20);
		this.dateTimePicker_1.TabIndex = 1;
		this.label_0.AutoSize = true;
		this.label_0.Location = new Point(171, 18);
		this.label_0.Name = "label2";
		this.label_0.Size = new Size(19, 13);
		this.label_0.TabIndex = 2;
		this.label_0.Text = "по";
		this.dateTimePicker_0.Location = new Point(196, 12);
		this.dateTimePicker_0.Name = "dtpEnd";
		this.dateTimePicker_0.Size = new Size(137, 20);
		this.dateTimePicker_0.TabIndex = 3;
		this.button_0.Location = new Point(354, 12);
		this.button_0.Name = "buttonApply";
		this.button_0.Size = new Size(108, 23);
		this.button_0.TabIndex = 4;
		this.button_0.Text = "Сформировать";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_0.Click += this.button_0_Click;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(632, 516);
		base.Controls.Add(this.reportViewerRus_0);
		base.Controls.Add(this.panel_0);
		base.Name = "FormReportCountRequest";
		this.Text = "Отчет по заявкам на тех присоединение";
		base.Load += this.Form16_Load;
		((ISupportInitialize)this.class10_0).EndInit();
		((ISupportInitialize)this.bindingSource_0).EndInit();
		this.panel_0.ResumeLayout(false);
		this.panel_0.PerformLayout();
		base.ResumeLayout(false);
	}

	private ReportViewerRus reportViewerRus_0;

	private BindingSource bindingSource_0;

	private Class10 class10_0;

	private Panel panel_0;

	private Button button_0;

	private DateTimePicker dateTimePicker_0;

	private Label label_0;

	private DateTimePicker dateTimePicker_1;

	private Label label_1;
}
