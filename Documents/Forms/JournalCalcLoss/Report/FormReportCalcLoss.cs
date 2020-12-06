using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using ControlsLbr.ReportViewerRus;
using FormLbr;
using Microsoft.Reporting.WinForms;

namespace Documents.Forms.JournalCalcLoss.Report
{
	public partial class FormReportCalcLoss : FormBase
	{
		public FormReportCalcLoss()
		{
			
			this.bool_0 = true;
			this.int_0 = -1;
			this.dateTime_0 = DateTime.Now;
			this.dateTime_1 = new DateTime(2014, 9, 1);
			this.string_0 = "";
			this.string_1 = "";
			
			this.method_15();
		}

		public FormReportCalcLoss(int id)
		{
			
			this.bool_0 = true;
			this.int_0 = -1;
			this.dateTime_0 = DateTime.Now;
			this.dateTime_1 = new DateTime(2014, 9, 1);
			this.string_0 = "";
			this.string_1 = "";
			
			this.method_15();
			this.int_0 = id;
		}

		public FormReportCalcLoss(DataTable dtCalcLoss, DataTable dtCalcLossCable)
		{
			
			this.bool_0 = true;
			this.int_0 = -1;
			this.dateTime_0 = DateTime.Now;
			this.dateTime_1 = new DateTime(2014, 9, 1);
			this.string_0 = "";
			this.string_1 = "";
			
			this.method_15();
			if (dtCalcLoss.Rows.Count > 0)
			{
				this.class498_0.tJ_CalcLoss.ImportRow(dtCalcLoss.Rows[0]);
			}
			if (dtCalcLossCable.Rows.Count > 0)
			{
				this.class498_0.tJ_CalcLossCable.ImportRow(dtCalcLossCable.Rows[0]);
			}
		}

		private void FormReportCalcLoss_Load(object sender, EventArgs e)
		{
			base.LoadFormConfig(null);
			if (this.int_0 != -1)
			{
				base.SelectSqlData(this.class498_0, this.class498_0.tJ_CalcLoss, true, "where id = " + this.int_0.ToString());
				base.SelectSqlData(this.class498_0, this.class498_0.tJ_CalcLossCable, true, "where idcalc = " + this.int_0.ToString());
			}
			if (this.class498_0.tJ_CalcLoss.Rows.Count > 0)
			{
				this.dateTime_0 = Convert.ToDateTime(this.class498_0.tJ_CalcLoss.Rows[0]["DateCalc"]);
				string text;
				if (this.class498_0.tJ_CalcLoss.Rows[0]["num"] == DBNull.Value)
				{
					text = "№ -1";
				}
				else
				{
					text = "№ " + this.class498_0.tJ_CalcLoss.Rows[0]["num"].ToString();
				}
				text = text + " от " + Convert.ToDateTime(this.class498_0.tJ_CalcLoss.Rows[0]["DateCalc"]).ToString("dd MMMM yyyy");
				ReportParameter reportParameter = new ReportParameter("numDate", text);
				this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
				{
					reportParameter
				});
				this.method_0();
				this.method_1();
				this.method_2();
				this.method_3();
				this.method_4();
				this.method_5();
				this.method_6();
				this.method_7();
				this.method_8();
				this.method_9();
				this.method_10();
				this.method_11();
				this.method_12();
				this.method_13();
				this.method_14();
			}
			this.reportViewerRus_0.RefreshReport();
		}

		private void FormReportCalcLoss_FormClosing(object sender, FormClosingEventArgs e)
		{
			base.SaveFormConfig(null);
		}

		private void method_0()
		{
			int num = Convert.ToInt32(this.class498_0.tJ_CalcLoss.Rows[0]["typeCalc"]);
			if (this.class498_0.tJ_CalcLossCable.Rows.Count > 0 && this.class498_0.tJ_CalcLossCable.Rows[0]["IsIsolation"] != DBNull.Value)
			{
				this.bool_1 = Convert.ToBoolean(this.class498_0.tJ_CalcLossCable.Rows[0]["isIsolation"]);
			}
			string text = "";
			string value = "";
			string value2 = "";
			if (num != 1197)
			{
				if (num == 1198)
				{
					text = (value2 = "ВЛ");
					value = "вл";
					if (this.bool_1)
					{
						this.reportViewerRus_0.LocalReport.ReportEmbeddedResource = "Documents.Forms.JournalCalcLoss.Report.ReportVLIsolation.rdlc";
					}
					else
					{
						this.reportViewerRus_0.LocalReport.ReportEmbeddedResource = "Documents.Forms.JournalCalcLoss.Report.ReportVL.rdlc";
					}
					this.bool_0 = false;
					if (this.class498_0.tJ_CalcLossCable.Rows.Count > 0 && this.class498_0.tJ_CalcLossCable.Rows[0]["Voltage"] != DBNull.Value && Convert.ToSingle(this.class498_0.tJ_CalcLossCable.Rows[0]["Voltage"]) < 1f)
					{
						if (this.bool_1)
						{
							this.reportViewerRus_0.LocalReport.ReportEmbeddedResource = "Documents.Forms.JournalCalcLoss.Report.ReportVLIsolation.rdlc";
						}
						else
						{
							this.reportViewerRus_0.LocalReport.ReportEmbeddedResource = "Documents.Forms.JournalCalcLoss.Report.ReportKL.rdlc";
						}
						this.bool_0 = true;
					}
				}
			}
			else
			{
				text = (value2 = "КЛ");
				if (this.bool_1)
				{
					this.reportViewerRus_0.LocalReport.ReportEmbeddedResource = "Documents.Forms.JournalCalcLoss.Report.ReportKLIsolation.rdlc";
				}
				else
				{
					this.reportViewerRus_0.LocalReport.ReportEmbeddedResource = "Documents.Forms.JournalCalcLoss.Report.ReportKL.rdlc";
				}
				this.bool_0 = true;
				value = "кл";
			}
			if (this.class498_0.tJ_CalcLossCable.Rows.Count > 0 && this.class498_0.tJ_CalcLossCable.Rows[0]["Voltage"] != DBNull.Value)
			{
				text = string.Concat(new object[]
				{
					text,
					" ",
					this.class498_0.tJ_CalcLossCable.Rows[0]["Voltage"],
					"кВ"
				});
			}
			ReportParameter reportParameter = new ReportParameter("typeCalcStr", text);
			this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
			{
				reportParameter
			});
			reportParameter = new ReportParameter("typeMin", value);
			this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
			{
				reportParameter
			});
			reportParameter = new ReportParameter("typeMax", value2);
			this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
			{
				reportParameter
			});
			reportParameter = new ReportParameter("isKL", this.bool_0.ToString());
			this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
			{
				reportParameter
			});
		}

		private void method_1()
		{
			string text = "";
			if (this.class498_0.tJ_CalcLoss.Rows[0]["idAbnBalance"] != DBNull.Value)
			{
				base.SelectSqlData(this.class498_0, this.class498_0.tAbn, true, "where id = " + this.class498_0.tJ_CalcLoss.Rows[0]["idAbnBalance"].ToString());
				if (this.class498_0.tAbn.Rows.Count > 0)
				{
					text = this.class498_0.tAbn.Rows[0]["name"].ToString();
				}
				if (this.class498_0.tJ_CalcLoss.Rows[0]["idAbn"] != DBNull.Value && this.class498_0.tJ_CalcLoss.Rows[0]["idAbnBalance"].ToString() == this.class498_0.tJ_CalcLoss.Rows[0]["idAbn"].ToString() && this.class498_0.tAbn.Rows.Count > 0)
				{
					if (Convert.ToInt32(this.class498_0.tAbn.Rows[0]["codeAbonent"]) > 0)
					{
						text = text + " д." + this.class498_0.tAbn.Rows[0]["codeAbonent"].ToString();
					}
					int num = Convert.ToInt32(this.class498_0.tAbn.Rows[0]["typeAbn"]);
					if (this.class498_0.tJ_CalcLoss.Rows[0]["idAbnObj"] != DBNull.Value)
					{
						Class498.Class507 @class = new Class498.Class507();
						DataColumn dataColumn = new DataColumn("AddressFL");
						dataColumn.Expression = "street + ', д. ' + houseall + ', кв. ' + name";
						@class.Columns.Add(dataColumn);
						base.SelectSqlData(@class, true, "where id = " + this.class498_0.tJ_CalcLoss.Rows[0]["idAbnObj"].ToString(), null, false, 0);
						if (@class.Rows.Count > 0)
						{
							if (num != 206 && num != 253)
							{
								if (num != 1037)
								{
									text = text + " (" + @class.Rows[0]["name"].ToString() + ")";
									goto IL_2E9;
								}
							}
							text = text + " (" + @class.Rows[0]["AddressFL"].ToString() + ")";
						}
					}
				}
			}
			IL_2E9:
			ReportParameter reportParameter = new ReportParameter("AbnBalance", text);
			this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
			{
				reportParameter
			});
		}

		private void method_2()
		{
			string text = "";
			if (this.class498_0.tJ_CalcLoss.Rows[0]["tpName"] != DBNull.Value)
			{
				text = this.class498_0.tJ_CalcLoss.Rows[0]["tpName"].ToString();
			}
			if (this.class498_0.tJ_CalcLoss.Rows[0]["idAbn"] != DBNull.Value && this.class498_0.tJ_CalcLoss.Rows[0]["idAbnBalance"].ToString() != this.class498_0.tJ_CalcLoss.Rows[0]["idAbn"].ToString())
			{
				base.SelectSqlData(this.class498_0, this.class498_0.tAbn, true, "where id = " + this.class498_0.tJ_CalcLoss.Rows[0]["idAbn"].ToString());
				if (this.class498_0.tAbn.Rows.Count > 0)
				{
					text = text + " (" + this.class498_0.tAbn.Rows[0]["name"].ToString();
					if (Convert.ToInt32(this.class498_0.tAbn.Rows[0]["codeAbonent"]) > 0)
					{
						text = text + " д." + this.class498_0.tAbn.Rows[0]["codeAbonent"].ToString() + ")";
					}
					else
					{
						text += ")";
					}
				}
			}
			ReportParameter reportParameter = new ReportParameter("tpName", text);
			this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
			{
				reportParameter
			});
		}

		private void method_3()
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("Desription");
			dataTable.Columns.Add("Dimension");
			dataTable.Columns.Add("Val");
			if (this.class498_0.tJ_CalcLossCable.Rows.Count > 0)
			{
				if (this.class498_0.tJ_CalcLossCable.Rows[0]["lenghtcable"] != DBNull.Value)
				{
					this.string_0 = Convert.ToDecimal(this.class498_0.tJ_CalcLossCable.Rows[0]["lenghtcable"]).smethod_0();
				}
				string text = "Длина линии";
				if (this.class498_0.tJ_CalcLossCable.Rows[0]["makeupCable"] != DBNull.Value)
				{
					base.SelectSqlData(this.class498_0.vR_Cable, true, "where id = " + this.class498_0.tJ_CalcLossCable.Rows[0]["makeupCable"].ToString(), null, false, 0);
					if (this.class498_0.vR_Cable.Rows.Count > 0 && this.class498_0.vR_Cable.Rows[0]["CableMakeup"] != DBNull.Value && this.class498_0.vR_Cable.Rows[0]["CrossSection"] != DBNull.Value)
					{
						if (this.class498_0.vR_Cable.Rows[0]["Wires"] != DBNull.Value)
						{
							text = string.Concat(new string[]
							{
								text,
								", (",
								this.class498_0.vR_Cable.Rows[0]["CableMakeup"].ToString(),
								" ",
								this.class498_0.vR_Cable.Rows[0]["Wires"].ToString(),
								"x",
								this.class498_0.vR_Cable.Rows[0]["CrossSection"].ToString(),
								")"
							});
							if (this.class498_0.vR_Cable.Rows[0]["WiresAddl"] != DBNull.Value && Convert.ToInt32(this.class498_0.vR_Cable.Rows[0]["WiresAddl"]) > 0 && this.class498_0.vR_Cable.Rows[0]["CrossSectionAddl"] != DBNull.Value)
							{
								text = string.Concat(new string[]
								{
									text.Remove(text.Length - 1),
									" + ",
									this.class498_0.vR_Cable.Rows[0]["WiresAddl"].ToString(),
									"x",
									this.class498_0.vR_Cable.Rows[0]["CrossSectionAddl"].ToString(),
									")"
								});
							}
						}
						else
						{
							text = string.Concat(new string[]
							{
								text,
								", (",
								this.class498_0.vR_Cable.Rows[0]["CableMakeup"].ToString(),
								"-",
								this.class498_0.vR_Cable.Rows[0]["CrossSection"].ToString(),
								")"
							});
						}
					}
				}
				dataTable.Rows.Add(new object[]
				{
					text,
					"L, км",
					this.string_0
				});
				if (this.class498_0.tJ_CalcLossCable.Rows[0]["UdResistance"] != DBNull.Value)
				{
					dataTable.Rows.Add(new object[]
					{
						"Удельное активное сопротивление линии на 1 км провода",
						"r0, Ом/км",
						Convert.ToDecimal(this.class498_0.tJ_CalcLossCable.Rows[0]["UdResistance"]).smethod_0()
					});
				}
				else
				{
					dataTable.Rows.Add(new object[]
					{
						"Удельное активное сопротивление линии на 1 км провода",
						"r0, Ом/км",
						""
					});
				}
				if (this.class498_0.tJ_CalcLossCable.Rows[0]["Voltage"] != DBNull.Value)
				{
					dataTable.Rows.Add(new object[]
					{
						"Среднее напряжение линии",
						"Uср, кВ",
						Convert.ToDecimal(this.class498_0.tJ_CalcLossCable.Rows[0]["Voltage"]).smethod_0()
					});
				}
				else
				{
					dataTable.Rows.Add(new object[]
					{
						"Среднее напряжение линии",
						"Uср, кВ",
						""
					});
				}
				if (this.class498_0.tJ_CalcLossCable.Rows[0]["Consumption"] != DBNull.Value)
				{
					dataTable.Rows.Add(new object[]
					{
						"Потребление активной электроэнергии за базовый период по счетчику",
						"Wт, кВт*ч",
						this.class498_0.tJ_CalcLossCable.Rows[0]["Consumption"].ToString()
					});
				}
				else
				{
					dataTable.Rows.Add(new object[]
					{
						"Потребление активной электроэнергии за базовый период по счетчику",
						"Wт, кВт*ч",
						""
					});
				}
				if (this.class498_0.tJ_CalcLossCable.Rows[0]["period"] != DBNull.Value)
				{
					dataTable.Rows.Add(new object[]
					{
						"Базовый (расчетный) период",
						"Т, час",
						this.class498_0.tJ_CalcLossCable.Rows[0]["period"].ToString()
					});
				}
				else
				{
					dataTable.Rows.Add(new object[]
					{
						"Базовый (расчетный) период",
						"Т, час",
						""
					});
				}
				if (this.class498_0.tJ_CalcLossCable.Rows[0]["CoeffPowerReactive"] != DBNull.Value)
				{
					dataTable.Rows.Add(new object[]
					{
						"Коэффициент реактивной мощности",
						"tg φ",
						Convert.ToDecimal(this.class498_0.tJ_CalcLossCable.Rows[0]["CoeffPowerReactive"]).smethod_0()
					});
				}
				else
				{
					dataTable.Rows.Add(new object[]
					{
						"Коэффициент реактивной мощности",
						"tg φ",
						""
					});
				}
				if (this.class498_0.tJ_CalcLossCable.Rows[0]["SquareCoeffFromGraph"] != DBNull.Value)
				{
					dataTable.Rows.Add(new object[]
					{
						"Квадрат коэффициента формы графика за базовый период",
						"kφ², о.е.",
						Convert.ToDecimal(this.class498_0.tJ_CalcLossCable.Rows[0]["SquareCoeffFromGraph"]).smethod_0()
					});
				}
				else
				{
					dataTable.Rows.Add(new object[]
					{
						"Квадрат коэффициента формы графика за базовый период",
						"kφ², о.е.",
						""
					});
				}
				if (this.class498_0.tJ_CalcLossCable.Rows[0]["CoeffDifferences"] != DBNull.Value)
				{
					dataTable.Rows.Add(new object[]
					{
						"Коэффициент учитывающий различие конфигураций графиков активной и реактивной нагрузки",
						"kк, о.е.",
						Convert.ToDecimal(this.class498_0.tJ_CalcLossCable.Rows[0]["CoeffDifferences"]).smethod_0()
					});
				}
				else
				{
					dataTable.Rows.Add(new object[]
					{
						"Коэффициент учитывающий различие конфигураций графиков активной и реактивной нагрузки",
						"kк, о.е.",
						""
					});
				}
				this.string_1 = this.class498_0.tJ_CalcLossCable.Rows[0]["CountChain"].ToString();
				dataTable.Rows.Add(new object[]
				{
					"Количество параллельных цепей",
					"nц, шт",
					this.string_1
				});
			}
			ReportDataSource reportDataSource = new ReportDataSource();
			reportDataSource.Name = "dsSource";
			reportDataSource.Value = dataTable;
			this.reportViewerRus_0.LocalReport.DataSources.Add(reportDataSource);
		}

		private void method_4()
		{
			string value = "";
			if (this.class498_0.tJ_CalcLossCable.Rows.Count > 0 && this.class498_0.tJ_CalcLossCable.Rows[0]["UdResistance"] != DBNull.Value && !string.IsNullOrEmpty(this.string_0) && !string.IsNullOrEmpty(this.string_1) && this.class498_0.tJ_CalcLossCable.Rows[0]["ActiveResistance"] != DBNull.Value)
			{
				value = string.Concat(new string[]
				{
					" = ",
					Convert.ToDecimal(this.class498_0.tJ_CalcLossCable.Rows[0]["UdResistance"]).smethod_0(),
					" * ",
					this.string_0,
					" / ",
					this.string_1,
					" = ",
					Convert.ToDecimal(this.class498_0.tJ_CalcLossCable.Rows[0]["ActiveResistance"]).smethod_0(),
					" Ом"
				});
			}
			ReportParameter reportParameter = new ReportParameter("ActiveResistance", value);
			this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
			{
				reportParameter
			});
		}

		private void method_5()
		{
			string value = "";
			if (this.class498_0.tJ_CalcLossCable.Rows.Count > 0 && this.class498_0.tJ_CalcLossCable.Rows[0]["Consumption"] != DBNull.Value && this.class498_0.tJ_CalcLossCable.Rows[0]["period"] != DBNull.Value && this.class498_0.tJ_CalcLossCable.Rows[0]["LoadAverage"] != DBNull.Value)
			{
				value = string.Concat(new string[]
				{
					this.class498_0.tJ_CalcLossCable.Rows[0]["Consumption"].ToString(),
					" * 0.001 / ",
					this.class498_0.tJ_CalcLossCable.Rows[0]["period"].ToString(),
					" = ",
					Convert.ToDecimal(this.class498_0.tJ_CalcLossCable.Rows[0]["LoadAverage"]).smethod_0(),
					" МВт"
				});
			}
			ReportParameter reportParameter = new ReportParameter("LoadAverage", value);
			this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
			{
				reportParameter
			});
		}

		private void method_6()
		{
			string value = "";
			if (this.class498_0.tJ_CalcLossCable.Rows.Count > 0 && this.class498_0.tJ_CalcLossCable.Rows[0]["LoadAverage"] != DBNull.Value && this.class498_0.tJ_CalcLossCable.Rows[0]["ActiveResistance"] != DBNull.Value && this.class498_0.tJ_CalcLossCable.Rows[0]["CoeffPowerReactive"] != DBNull.Value && this.class498_0.tJ_CalcLossCable.Rows[0]["Voltage"] != DBNull.Value && this.class498_0.tJ_CalcLossCable.Rows[0]["LoadPowerLoss"] != DBNull.Value)
			{
				value = string.Concat(new string[]
				{
					Convert.ToDecimal(this.class498_0.tJ_CalcLossCable.Rows[0]["LoadAverage"]).smethod_0(),
					"² * 1000 * ",
					Convert.ToDecimal(this.class498_0.tJ_CalcLossCable.Rows[0]["ActiveResistance"]).smethod_0(),
					" * (1 + ",
					Convert.ToDecimal(this.class498_0.tJ_CalcLossCable.Rows[0]["CoeffPowerReactive"]).smethod_0(),
					"²) / ",
					Convert.ToDecimal(this.class498_0.tJ_CalcLossCable.Rows[0]["Voltage"]).smethod_0(),
					"² = ",
					Convert.ToDecimal(this.class498_0.tJ_CalcLossCable.Rows[0]["LoadPowerLoss"]).smethod_0(),
					" кВт"
				});
			}
			ReportParameter reportParameter = new ReportParameter("LoadPowerLoss", value);
			this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
			{
				reportParameter
			});
		}

		private void method_7()
		{
			string value = "";
			if (this.class498_0.tJ_CalcLossCable.Rows.Count > 0 && this.class498_0.tJ_CalcLossCable.Rows[0]["LoadPowerLoss"] != DBNull.Value && this.class498_0.tJ_CalcLossCable.Rows[0]["CoeffDifferences"] != DBNull.Value && this.class498_0.tJ_CalcLossCable.Rows[0]["period"] != DBNull.Value && this.class498_0.tJ_CalcLossCable.Rows[0]["SquareCoeffFromGraph"] != DBNull.Value && this.class498_0.tJ_CalcLossCable.Rows[0]["LoadLosses"] != DBNull.Value)
			{
				value = string.Concat(new string[]
				{
					Convert.ToDecimal(this.class498_0.tJ_CalcLossCable.Rows[0]["CoeffDifferences"]).smethod_0(),
					" * ",
					Convert.ToDecimal(this.class498_0.tJ_CalcLossCable.Rows[0]["LoadPowerLoss"]).smethod_0(),
					" * ",
					Convert.ToDecimal(this.class498_0.tJ_CalcLossCable.Rows[0]["period"]).smethod_0(),
					" * ",
					Convert.ToDecimal(this.class498_0.tJ_CalcLossCable.Rows[0]["SquareCoeffFromGraph"]).smethod_0(),
					" = ",
					Convert.ToDecimal(this.class498_0.tJ_CalcLossCable.Rows[0]["LoadLosses"]).smethod_0(),
					" кВт*ч"
				});
			}
			ReportParameter reportParameter = new ReportParameter("LoadLosses", value);
			this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
			{
				reportParameter
			});
		}

		private void method_8()
		{
			string text = "";
			string text2 = "";
			if (this.class498_0.tJ_CalcLossCable.Rows.Count > 0 && this.class498_0.tJ_CalcLossCable.Rows[0]["Voltage"] != DBNull.Value)
			{
				text = "1 км - " + Convert.ToDecimal(this.class498_0.tJ_CalcLossCable.Rows[0]["Voltage"]).smethod_0() + " кВ = ";
				if (this.class498_0.tJ_CalcLossCable.Rows[0]["UnitYearLoss"] != DBNull.Value)
				{
					text = text + Convert.ToDecimal(this.class498_0.tJ_CalcLossCable.Rows[0]["UnitYearLoss"]).smethod_0() + " кВт.ч год";
				}
				if (this.class498_0.tJ_CalcLossCable.Rows[0]["lenghtCable"] != DBNull.Value)
				{
					text2 = Convert.ToDecimal(this.class498_0.tJ_CalcLossCable.Rows[0]["lenghtCable"]).smethod_0() + " км - " + Convert.ToDecimal(this.class498_0.tJ_CalcLossCable.Rows[0]["Voltage"]).smethod_0() + " кВ = ";
					if (this.class498_0.tJ_CalcLossCable.Rows[0]["YearLoss"] != DBNull.Value)
					{
						text2 = text2 + Convert.ToDecimal(this.class498_0.tJ_CalcLossCable.Rows[0]["YearLoss"]).smethod_0() + " кВт.ч год";
					}
				}
			}
			ReportParameter reportParameter = new ReportParameter("UnitYearLoss", text);
			this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
			{
				reportParameter
			});
			reportParameter = new ReportParameter("YearLoss", text2);
			this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
			{
				reportParameter
			});
		}

		private void method_9()
		{
			string value = "";
			if (this.class498_0.tJ_CalcLossCable.Rows.Count > 0 && this.class498_0.tJ_CalcLossCable.Rows[0]["LoadLosses"] != DBNull.Value && this.class498_0.tJ_CalcLossCable.Rows[0]["YearLoss"] != DBNull.Value && this.class498_0.tJ_CalcLossCable.Rows[0]["SumLoadLosses"] != DBNull.Value)
			{
				value = string.Concat(new string[]
				{
					Convert.ToDecimal(this.class498_0.tJ_CalcLossCable.Rows[0]["LoadLosses"]).smethod_0(),
					" + ",
					Convert.ToDecimal(this.class498_0.tJ_CalcLossCable.Rows[0]["YearLoss"]).smethod_0(),
					" = ",
					Convert.ToDecimal(this.class498_0.tJ_CalcLossCable.Rows[0]["SumLoadLosses"]).smethod_0(),
					" кВт"
				});
			}
			ReportParameter reportParameter = new ReportParameter("SumLoadLoss", value);
			this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
			{
				reportParameter
			});
		}

		private void method_10()
		{
			string value = "";
			string value2 = "";
			if (this.class498_0.tJ_CalcLossCable.Rows.Count > 0 && this.class498_0.tJ_CalcLossCable.Rows[0]["CoeffLosses"] != DBNull.Value)
			{
				value2 = Convert.ToDecimal(this.class498_0.tJ_CalcLossCable.Rows[0]["CoeffLosses"]).smethod_0();
				if (this.bool_0)
				{
					if (this.class498_0.tJ_CalcLossCable.Rows[0]["LoadLosses"] != DBNull.Value && this.class498_0.tJ_CalcLossCable.Rows[0]["Consumption"] != DBNull.Value)
					{
						value = string.Concat(new string[]
						{
							"100% * ",
							Convert.ToDecimal(this.class498_0.tJ_CalcLossCable.Rows[0]["LoadLosses"]).smethod_0(),
							" / ",
							this.class498_0.tJ_CalcLossCable.Rows[0]["Consumption"].ToString(),
							" = ",
							Convert.ToDecimal(this.class498_0.tJ_CalcLossCable.Rows[0]["CoeffLosses"]).smethod_0(),
							"%"
						});
					}
				}
				else if (this.class498_0.tJ_CalcLossCable.Rows[0]["SumLoadLosses"] != DBNull.Value && this.class498_0.tJ_CalcLossCable.Rows[0]["Consumption"] != DBNull.Value)
				{
					value = string.Concat(new string[]
					{
						"100% * ",
						Convert.ToDecimal(this.class498_0.tJ_CalcLossCable.Rows[0]["SumLoadLosses"]).smethod_0(),
						" / ",
						this.class498_0.tJ_CalcLossCable.Rows[0]["Consumption"].ToString(),
						" = ",
						Convert.ToDecimal(this.class498_0.tJ_CalcLossCable.Rows[0]["CoeffLosses"]).smethod_0(),
						"%"
					});
				}
			}
			ReportParameter reportParameter = new ReportParameter("CoeffLoss", value);
			this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
			{
				reportParameter
			});
			reportParameter = new ReportParameter("Coefficient", value2);
			this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
			{
				reportParameter
			});
		}

		private void method_11()
		{
			if (!this.bool_1)
			{
				return;
			}
			string value = "";
			decimal num = 0m;
			if (this.class498_0.tJ_CalcLossCable.Rows.Count > 0 && this.class498_0.tJ_CalcLossCable.Rows[0]["isolationLosses"] != DBNull.Value)
			{
				num = Convert.ToDecimal(this.class498_0.tJ_CalcLossCable.Rows[0]["isolationLosses"]);
				if (this.class498_0.tJ_CalcLossCable.Rows[0]["CoeffIsolation"] != DBNull.Value && this.class498_0.tJ_CalcLossCable.Rows[0]["lenghtCable"] != DBNull.Value && this.class498_0.tJ_CalcLossCable.Rows[0]["countChain"] != DBNull.Value)
				{
					value = string.Concat(new string[]
					{
						Convert.ToDecimal(this.class498_0.tJ_CalcLossCable.Rows[0]["CoeffIsolation"]).smethod_0(),
						" * ",
						Convert.ToDecimal(this.class498_0.tJ_CalcLossCable.Rows[0]["lenghtCable"]).smethod_0(),
						" * ",
						this.class498_0.tJ_CalcLossCable.Rows[0]["countChain"].ToString(),
						" * 1000 = ",
						(this.dateTime_0 > this.dateTime_1) ? Math.Round(Convert.ToDecimal(this.class498_0.tJ_CalcLossCable.Rows[0]["isolationLosses"]), 0).smethod_0() : Convert.ToDecimal(this.class498_0.tJ_CalcLossCable.Rows[0]["isolationLosses"]).smethod_0(),
						" кВт*ч"
					});
				}
			}
			ReportParameter reportParameter = new ReportParameter("IsolationLoss", value);
			this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
			{
				reportParameter
			});
			reportParameter = new ReportParameter("IsolationLossValue", num.ToString());
			this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
			{
				reportParameter
			});
			DataTable dataTable = new DataTable();
			for (int i = 1; i <= 12; i++)
			{
				dataTable.Columns.Add("Month" + i.ToString(), typeof(decimal));
			}
			DataRow dataRow = dataTable.NewRow();
			if (this.dateTime_0 < this.dateTime_1)
			{
				for (int j = 1; j <= 12; j++)
				{
					if (j == 2)
					{
						dataRow["Month" + j.ToString()] = Math.Round(num, 2) - Math.Round(num / 365m * 30m, 2) * 4m - Math.Round(num / 365m * 31m, 2) * 7m;
					}
					else
					{
						dataRow["Month" + j.ToString()] = Math.Round(num / 365m * DateTime.DaysInMonth(this.dateTime_0.Year, j), 2);
					}
				}
			}
			else
			{
				for (int k = 1; k <= 12; k++)
				{
					if (k == 2)
					{
						dataRow["Month" + k.ToString()] = Math.Round(num, 0) - Math.Round(num / 365m * 30m, 0) * 4m - Math.Round(num / 365m * 31m, 0) * 7m;
					}
					else
					{
						dataRow["Month" + k.ToString()] = Math.Round(num / 365m * DateTime.DaysInMonth(this.dateTime_0.Year, k), 0);
					}
				}
			}
			if (Convert.ToDecimal(dataRow["Month2"]) < 0m)
			{
				dataRow["Month1"] = Convert.ToDecimal(dataRow["Month1"]) + Convert.ToDecimal(dataRow["Month2"]);
				dataRow["Month2"] = 0;
				if (Convert.ToDecimal(dataRow["Month1"]) < 0m)
				{
					dataRow["Month3"] = Convert.ToDecimal(dataRow["Month3"]) + Convert.ToDecimal(dataRow["Month1"]);
					dataRow["Month1"] = 0;
					int num2 = 3;
					while (num2 <= 12 && Convert.ToDecimal(dataRow["Month" + num2.ToString()]) < 0m)
					{
						dataRow["Month" + (num2 + 1).ToString()] = Convert.ToDecimal(dataRow["Month" + (num2 + 1).ToString()]) + Convert.ToDecimal(dataRow["Month" + num2.ToString()]);
						dataRow["Month" + num2.ToString()] = 0;
						num2++;
					}
				}
			}
			dataTable.Rows.Add(dataRow);
			ReportDataSource reportDataSource = new ReportDataSource();
			reportDataSource.Name = "dtIsolationLoss";
			reportDataSource.Value = dataTable;
			this.reportViewerRus_0.LocalReport.DataSources.Add(reportDataSource);
		}

		private void textBox_1_TextChanged(object sender, EventArgs e)
		{
			ReportParameter reportParameter = new ReportParameter("FIOPerformer", this.textBox_1.Text);
			this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
			{
				reportParameter
			});
			this.reportViewerRus_0.RefreshReport();
		}

		private void textBox_0_TextChanged(object sender, EventArgs e)
		{
			ReportParameter reportParameter = new ReportParameter("Phone", this.textBox_0.Text);
			this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
			{
				reportParameter
			});
			this.reportViewerRus_0.RefreshReport();
		}

		private void dateTimePicker_0_ValueChanged(object sender, EventArgs e)
		{
			ReportParameter reportParameter = new ReportParameter("DatePerform", this.dateTimePicker_0.Value.ToShortDateString());
			this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
			{
				reportParameter
			});
			this.reportViewerRus_0.RefreshReport();
		}

		private void method_12()
		{
			if (this.class498_0.tJ_CalcLoss.Rows.Count > 0 && this.class498_0.tJ_CalcLoss.Rows[0]["DateCalc"] != DBNull.Value)
			{
				this.dateTimePicker_0.Value = Convert.ToDateTime(this.class498_0.tJ_CalcLoss.Rows[0]["DateCalc"]);
			}
			else
			{
				this.dateTimePicker_0.Value = DateTime.Now;
			}
			ReportParameter reportParameter = new ReportParameter("DatePerform", this.dateTimePicker_0.Value.ToShortDateString());
			this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
			{
				reportParameter
			});
		}

		protected override XmlDocument CreateXmlConfig()
		{
			XmlDocument xmlDocument = new XmlDocument();
			XmlNode newChild = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", null);
			xmlDocument.AppendChild(newChild);
			XmlNode xmlNode = xmlDocument.CreateElement(base.Name);
			xmlDocument.AppendChild(xmlNode);
			XmlAttribute xmlAttribute = xmlDocument.CreateAttribute("FIOPerformer");
			xmlAttribute.Value = this.textBox_1.Text;
			xmlNode.Attributes.Append(xmlAttribute);
			xmlAttribute = xmlDocument.CreateAttribute("Phone");
			xmlAttribute.Value = this.textBox_0.Text;
			xmlNode.Attributes.Append(xmlAttribute);
			xmlAttribute = xmlDocument.CreateAttribute("JobTitle");
			xmlAttribute.Value = this.textBox_3.Text;
			xmlNode.Attributes.Append(xmlAttribute);
			xmlAttribute = xmlDocument.CreateAttribute("FIOBoss");
			xmlAttribute.Value = this.textBox_2.Text;
			xmlNode.Attributes.Append(xmlAttribute);
			return xmlDocument;
		}

		protected override void ApplyConfig(XmlDocument doc)
		{
			XmlNode xmlNode = doc.SelectSingleNode(base.Name);
			if (xmlNode != null)
			{
				XmlAttribute xmlAttribute = xmlNode.Attributes["FIOPerformer"];
				if (xmlAttribute != null)
				{
					this.textBox_1.Text = xmlAttribute.Value;
				}
				xmlAttribute = xmlNode.Attributes["Phone"];
				if (xmlAttribute != null)
				{
					this.textBox_0.Text = xmlAttribute.Value;
				}
				xmlAttribute = xmlNode.Attributes["JobTitle"];
				if (xmlAttribute != null)
				{
					this.textBox_3.Text = xmlAttribute.Value;
				}
				xmlAttribute = xmlNode.Attributes["FIOBoss"];
				if (xmlAttribute != null)
				{
					this.textBox_2.Text = xmlAttribute.Value;
				}
			}
		}

		private void method_13()
		{
			ReportParameter reportParameter = new ReportParameter("JobTitle", this.textBox_3.Text);
			this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
			{
				reportParameter
			});
			this.reportViewerRus_0.RefreshReport();
		}

		private void method_14()
		{
			ReportParameter reportParameter = new ReportParameter("FIOBoss", this.textBox_2.Text);
			this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
			{
				reportParameter
			});
			this.reportViewerRus_0.RefreshReport();
		}

		private void textBox_3_TextChanged(object sender, EventArgs e)
		{
			this.method_13();
		}

		private void textBox_2_TextChanged(object sender, EventArgs e)
		{
			this.method_14();
		}

		private void method_15()
		{
			this.reportViewerRus_0 = new ReportViewerRus();
			this.class498_0 = new Class498();
			this.panel_0 = new Panel();
			this.dateTimePicker_0 = new DateTimePicker();
			this.label_0 = new Label();
			this.textBox_0 = new TextBox();
			this.label_1 = new Label();
			this.textBox_1 = new TextBox();
			this.label_2 = new Label();
			this.label_4 = new Label();
			this.textBox_3 = new TextBox();
			this.label_3 = new Label();
			this.textBox_2 = new TextBox();
			((ISupportInitialize)this.class498_0).BeginInit();
			this.panel_0.SuspendLayout();
			base.SuspendLayout();
			this.reportViewerRus_0.Dock = DockStyle.Fill;
			this.reportViewerRus_0.LocalReport.ReportEmbeddedResource = "Documents.Forms.JournalCalcLoss.Report.ReportKL.rdlc";
			this.reportViewerRus_0.Location = new Point(0, 0);
			this.reportViewerRus_0.Name = "reportViewer1";
			this.reportViewerRus_0.Size = new Size(813, 440);
			this.reportViewerRus_0.TabIndex = 0;
			this.class498_0.DataSetName = "dsCalc";
			this.class498_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
			this.panel_0.Controls.Add(this.textBox_2);
			this.panel_0.Controls.Add(this.label_3);
			this.panel_0.Controls.Add(this.textBox_3);
			this.panel_0.Controls.Add(this.label_4);
			this.panel_0.Controls.Add(this.dateTimePicker_0);
			this.panel_0.Controls.Add(this.label_0);
			this.panel_0.Controls.Add(this.textBox_0);
			this.panel_0.Controls.Add(this.label_1);
			this.panel_0.Controls.Add(this.textBox_1);
			this.panel_0.Controls.Add(this.label_2);
			this.panel_0.Dock = DockStyle.Bottom;
			this.panel_0.Location = new Point(0, 440);
			this.panel_0.Name = "panelIsp";
			this.panel_0.Size = new Size(813, 95);
			this.panel_0.TabIndex = 1;
			this.dateTimePicker_0.Location = new Point(495, 62);
			this.dateTimePicker_0.Name = "dateTimePicker";
			this.dateTimePicker_0.Size = new Size(146, 20);
			this.dateTimePicker_0.TabIndex = 5;
			this.dateTimePicker_0.ValueChanged += this.dateTimePicker_0_ValueChanged;
			this.label_0.AutoSize = true;
			this.label_0.Location = new Point(492, 46);
			this.label_0.Name = "label3";
			this.label_0.Size = new Size(33, 13);
			this.label_0.TabIndex = 4;
			this.label_0.Text = "Дата";
			this.textBox_0.Location = new Point(283, 62);
			this.textBox_0.Name = "txtPhone";
			this.textBox_0.Size = new Size(174, 20);
			this.textBox_0.TabIndex = 3;
			this.textBox_0.TextChanged += this.textBox_0_TextChanged;
			this.label_1.AutoSize = true;
			this.label_1.Location = new Point(280, 46);
			this.label_1.Name = "label2";
			this.label_1.Size = new Size(52, 13);
			this.label_1.TabIndex = 2;
			this.label_1.Text = "Телефон";
			this.textBox_1.Location = new Point(12, 62);
			this.textBox_1.Name = "txtFIO";
			this.textBox_1.Size = new Size(251, 20);
			this.textBox_1.TabIndex = 1;
			this.textBox_1.TextChanged += this.textBox_1_TextChanged;
			this.label_2.AutoSize = true;
			this.label_2.Location = new Point(12, 46);
			this.label_2.Name = "label1";
			this.label_2.Size = new Size(74, 13);
			this.label_2.TabIndex = 0;
			this.label_2.Text = "Исполнитель";
			this.label_4.AutoSize = true;
			this.label_4.Location = new Point(12, 3);
			this.label_4.Name = "label4";
			this.label_4.Size = new Size(65, 13);
			this.label_4.TabIndex = 6;
			this.label_4.Text = "Должность";
			this.textBox_3.Location = new Point(12, 19);
			this.textBox_3.Name = "txtTitleJob";
			this.textBox_3.Size = new Size(251, 20);
			this.textBox_3.TabIndex = 7;
			this.textBox_3.Text = "Начальник СКиУЭЭ";
			this.textBox_3.TextChanged += this.textBox_3_TextChanged;
			this.label_3.AutoSize = true;
			this.label_3.Location = new Point(280, 3);
			this.label_3.Name = "label5";
			this.label_3.Size = new Size(34, 13);
			this.label_3.TabIndex = 8;
			this.label_3.Text = "ФИО";
			this.textBox_2.Location = new Point(283, 19);
			this.textBox_2.Name = "txtFIOBoss";
			this.textBox_2.Size = new Size(174, 20);
			this.textBox_2.TabIndex = 9;
			this.textBox_2.Text = "Исаева Н.В.";
			this.textBox_2.TextChanged += this.textBox_2_TextChanged;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(813, 535);
			base.Controls.Add(this.reportViewerRus_0);
			base.Controls.Add(this.panel_0);
			base.Name = "FormReportCalcLoss";
			this.Text = "Печать расчета потерь";
			base.FormClosing += this.FormReportCalcLoss_FormClosing;
			base.Load += this.FormReportCalcLoss_Load;
			((ISupportInitialize)this.class498_0).EndInit();
			this.panel_0.ResumeLayout(false);
			this.panel_0.PerformLayout();
			base.ResumeLayout(false);
		}

		private bool bool_0;

		private int int_0;

		private bool bool_1;

		private DateTime dateTime_0;

		private DateTime dateTime_1;

		private string string_0;

		private string string_1;

		private ReportViewerRus reportViewerRus_0;

		private Class498 class498_0;

		private Panel panel_0;

		private DateTimePicker dateTimePicker_0;

		private Label label_0;

		private TextBox textBox_0;

		private Label label_1;

		private TextBox textBox_1;

		private Label label_2;

		private TextBox textBox_2;

		private Label label_3;

		private TextBox textBox_3;

		private Label label_4;
	}
}
