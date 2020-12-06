using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ControlsLbr.ReportViewerRus;
using FormLbr;
using Microsoft.Reporting.WinForms;

internal partial class FormReportAct : FormBase
{
	internal FormReportAct()
	{
		
		this.int_0 = -1;
		
		this.InitializeComponent();
	}

	internal FormReportAct(int int_1)
	{
		
		this.int_0 = -1;
		
		this.InitializeComponent();
		this.int_0 = int_1;
	}

	private void FormReportAct_Load(object sender, EventArgs e)
	{
		DataSetExcavation.Class143 @class = new DataSetExcavation.Class143();
		base.SelectSqlData(@class, true, " where idExcavation = " + this.int_0.ToString() + " and idType = " + 2.ToString(), null, false, 0);
		this.bindingSource.DataSource = @class;
		DataTable dataTable = base.SelectSqlData("vj_excavationSurface", true, " where idExcavation = " + this.int_0.ToString() + " and idType = " + 3.ToString());
		string text = string.Empty;
		foreach (object obj in dataTable.Rows)
		{
			DataRow dataRow = (DataRow)obj;
			if (!string.IsNullOrEmpty(text))
			{
				text += "; ";
			}
			text = string.Concat(new string[]
			{
				text,
				dataRow["surName"].ToString(),
				": ",
				dataRow["Value"].ToString(),
				" ",
				dataRow["Unit"].ToString()
			});
		}
		ReportParameter reportParameter = new ReportParameter("Material", text);
		this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
		{
			reportParameter
		});
		dataTable = base.SelectSqlData("vj_excavationschmObj", true, " where idExcavation = " + this.int_0.ToString());
		string text2 = string.Empty;
		foreach (object obj2 in dataTable.Rows)
		{
			DataRow dataRow2 = (DataRow)obj2;
			if (!string.IsNullOrEmpty(text2))
			{
				text2 += "; ";
			}
			text2 += dataRow2["name"].ToString();
		}
		ReportParameter reportParameter2 = new ReportParameter("Cable", text2);
		this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
		{
			reportParameter2
		});
		dataTable = base.SelectSqlData("vj_excavation", true, " where id = " + this.int_0.ToString());
		if (dataTable.Rows.Count > 0)
		{
			if (dataTable.Rows[0]["typeWorkName"] != DBNull.Value)
			{
				ReportParameter reportParameter3 = new ReportParameter("typeWork", dataTable.Rows[0]["typeWorkName"].ToString());
				this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
				{
					reportParameter3
				});
			}
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			dictionary.Add(759, 4);
			dictionary.Add(757, 2);
			dictionary.Add(756, 1);
			dictionary.Add(758, 3);
			Dictionary<int, string> dictionary2 = new Dictionary<int, string>();
			dictionary2.Add(759, "Исаев В.М.");
			dictionary2.Add(757, "Рябов Д.А.");
			dictionary2.Add(756, "Куфтырев Д.В.");
			dictionary2.Add(758, "Савинов Ю.М.");
			if (dataTable.Rows.Count > 0)
			{
				if (dataTable.Rows[0]["idSR"] == DBNull.Value)
				{
					MessageBox.Show("Не введен сетевой район");
				}
				else
				{
					try
					{
						int key = Convert.ToInt32(dataTable.Rows[0]["idSR"]);
						ReportParameter reportParameter4 = new ReportParameter("sr", dictionary[key].ToString());
						this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
						{
							reportParameter4
						});
						ReportParameter reportParameter5 = new ReportParameter("chieff", dictionary2[key]);
						this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
						{
							reportParameter5
						});
					}
					catch
					{
					}
				}
			}
		}
		dataTable = base.SelectSqlData("vj_excavationaddress", true, " where idExcavation = " + this.int_0.ToString());
		string text3 = string.Empty;
		foreach (object obj3 in dataTable.Rows)
		{
			DataRow dataRow3 = (DataRow)obj3;
			if (!string.IsNullOrEmpty(text3))
			{
				text3 += "; ";
			}
			text3 = text3 + dataRow3["street"].ToString() + ", " + dataRow3["house"].ToString();
		}
		ReportParameter reportParameter6 = new ReportParameter("Address", text3);
		this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
		{
			reportParameter6
		});
		this.reportViewerRus_0.RefreshReport();
	}

	

	private int int_0;


}
