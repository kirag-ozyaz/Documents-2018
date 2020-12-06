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
	public partial class FormReportCalcLossTrans : FormBase
	{
		public FormReportCalcLossTrans()
		{
			
			this.int_0 = -1;
			
			this.method_15();
		}

		public FormReportCalcLossTrans(int id)
		{
			
			this.int_0 = -1;
			
			this.method_15();
			this.int_0 = id;
		}

		public FormReportCalcLossTrans(DataTable dtCalcLoss, DataTable dtCalcLossCable)
		{
			
			this.int_0 = -1;
			
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

		private void FormReportCalcLossTrans_Load(object sender, EventArgs e)
		{
			base.LoadFormConfig(null);
			if (this.int_0 != -1)
			{
				base.SelectSqlData(this.class498_0, this.class498_0.tJ_CalcLoss, true, "where id = " + this.int_0.ToString());
				base.SelectSqlData(this.class498_0, this.class498_0.tJ_CalcLossTrans, true, "where idcalc = " + this.int_0.ToString() + " order by numTrans");
				base.SelectSqlData(this.class498_0, this.class498_0.tJ_CalcLossTransHH, true, "where idcalc = " + this.int_0.ToString());
				if (this.class498_0.tJ_CalcLossTransHH.Rows.Count == 0)
				{
					this.reportViewerRus_0.LocalReport.ReportEmbeddedResource = "Documents.Forms.JournalCalcLoss.Report.ReportTrans.rdlc";
				}
			}
			if (this.class498_0.tJ_CalcLoss.Rows.Count > 0)
			{
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

		private void FormReportCalcLossTrans_FormClosing(object sender, FormClosingEventArgs e)
		{
			base.SaveFormConfig(null);
		}

		private void method_0()
		{
			string text = "";
			if (this.class498_0.tJ_CalcLossTrans.Rows.Count > 0 && this.class498_0.tJ_CalcLossTrans.Rows[0]["RatedPower"] != DBNull.Value)
			{
				text = text + Convert.ToInt32(Convert.ToDecimal(this.class498_0.tJ_CalcLossTrans.Rows[0]["ratedpower"]) * 1000m).ToString() + " кВА";
			}
			ReportParameter reportParameter = new ReportParameter("typeCalcStr", text);
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
				if (this.class498_0.tJ_CalcLoss.Rows[0]["idAbn"] != DBNull.Value && this.class498_0.tJ_CalcLoss.Rows[0]["idAbnBalance"].ToString() == this.class498_0.tJ_CalcLoss.Rows[0]["idAbn"].ToString())
				{
					if (this.class498_0.tAbn.Rows.Count > 0)
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
										goto IL_59C;
									}
								}
								text = text + " (" + @class.Rows[0]["AddressFL"].ToString() + ")";
							}
						}
					}
				}
				else if (this.class498_0.tAbn.Rows.Count > 0)
				{
					if (Convert.ToInt32(this.class498_0.tAbn.Rows[0]["codeAbonent"]) > 0)
					{
						text = text + " д." + this.class498_0.tAbn.Rows[0]["codeAbonent"].ToString();
					}
					base.SelectSqlData(this.class498_0, this.class498_0.tAbn, true, "where id = " + this.class498_0.tJ_CalcLoss.Rows[0]["idAbn"].ToString());
					if (this.class498_0.tAbn.Rows.Count > 0)
					{
						text = text + " для " + this.class498_0.tAbn.Rows[0]["name"].ToString();
						if (Convert.ToInt32(this.class498_0.tAbn.Rows[0]["codeAbonent"]) > 0)
						{
							text = text + " д." + this.class498_0.tAbn.Rows[0]["codeAbonent"].ToString();
						}
					}
					int num2 = Convert.ToInt32(this.class498_0.tAbn.Rows[0]["typeAbn"]);
					if (this.class498_0.tJ_CalcLoss.Rows[0]["idAbnObj"] != DBNull.Value)
					{
						Class498.Class507 class2 = new Class498.Class507();
						DataColumn dataColumn2 = new DataColumn("AddressFL");
						dataColumn2.Expression = "street + ', д. ' + houseall + ', кв. ' + name";
						class2.Columns.Add(dataColumn2);
						base.SelectSqlData(class2, true, "where id = " + this.class498_0.tJ_CalcLoss.Rows[0]["idAbnObj"].ToString(), null, false, 0);
						if (class2.Rows.Count > 0)
						{
							if (num2 != 206 && num2 != 253)
							{
								if (num2 != 1037)
								{
									text = text + " (" + class2.Rows[0]["name"].ToString() + ")";
									goto IL_59C;
								}
							}
							text = text + " (" + class2.Rows[0]["AddressFL"].ToString() + ")";
						}
					}
				}
			}
			IL_59C:
			ReportParameter reportParameter = new ReportParameter("AbnBalance", text);
			this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
			{
				reportParameter
			});
		}

		private void method_2()
		{
			string value = "";
			if (this.class498_0.tJ_CalcLoss.Rows[0]["tpName"] != DBNull.Value)
			{
				value = this.class498_0.tJ_CalcLoss.Rows[0]["tpName"].ToString();
			}
			ReportParameter reportParameter = new ReportParameter("tpName", value);
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
			if (this.class498_0.tJ_CalcLossTrans.Rows.Count > 0)
			{
				dataTable.Rows.Add(new object[]
				{
					"Номинальная мощность трансформатора",
					"Sном, МВА",
					Convert.ToDecimal(this.class498_0.tJ_CalcLossTrans.Rows[0]["RatedPower"]).smethod_0()
				});
				dataTable.Rows.Add(new object[]
				{
					"Количество трансформаторов",
					"n, шт",
					this.class498_0.tJ_CalcLossTrans.Rows.Count.ToString()
				});
				dataTable.Rows.Add(new object[]
				{
					"Потери мощности холостого хода",
					"∆Pхх, кВт",
					Convert.ToDecimal(this.class498_0.tJ_CalcLossTrans.Rows[0]["NoLoadLoss"]).smethod_0()
				});
				dataTable.Rows.Add(new object[]
				{
					"Потери мощности короткого замыкания",
					"∆Pкз, кВт",
					Convert.ToDecimal(this.class498_0.tJ_CalcLossTrans.Rows[0]["ShortCircuitLoss"]).smethod_0()
				});
				dataTable.Rows.Add(new object[]
				{
					"Годовое потребление активной электроэнергии за базовый период по счетчику",
					"Wт, кВт*ч",
					this.class498_0.tJ_CalcLossTrans.Rows[0]["Consumption"].ToString()
				});
				dataTable.Rows.Add(new object[]
				{
					"Номинальное напряжение высшей обмотки трансформатора",
					"Uном, кВ",
					Convert.ToDecimal(this.class498_0.tJ_CalcLossTrans.Rows[0]["RatedVoltage"]).smethod_0()
				});
				dataTable.Rows.Add(new object[]
				{
					"Среднее напряжение на высшей стороне трансформатора за базовый период",
					"Uср, кВ",
					Convert.ToDecimal(this.class498_0.tJ_CalcLossTrans.Rows[0]["MiddleVoltage"]).smethod_0()
				});
				dataTable.Rows.Add(new object[]
				{
					"Время работы трансформатора",
					"Т, час",
					this.class498_0.tJ_CalcLossTrans.Rows[0]["period"].ToString()
				});
				dataTable.Rows.Add(new object[]
				{
					"Коэффициент реактивной мощности",
					"tg φ",
					Convert.ToDecimal(this.class498_0.tJ_CalcLossTrans.Rows[0]["CoeffPowerReactive"]).smethod_0()
				});
				dataTable.Rows.Add(new object[]
				{
					"Квадрат коэффициента формы графика за базовый период",
					"kφ², о.е.",
					Convert.ToDecimal(this.class498_0.tJ_CalcLossTrans.Rows[0]["SquareCoeffFromGraph"]).smethod_0()
				});
				dataTable.Rows.Add(new object[]
				{
					"Коэффициент учитывающий различие конфигураций графиков активной и реактивной нагрузки",
					"kк, о.е.",
					Convert.ToDecimal(this.class498_0.tJ_CalcLossTrans.Rows[0]["CoeffDifference"]).smethod_0()
				});
			}
			ReportDataSource reportDataSource = new ReportDataSource();
			reportDataSource.Name = "dsSource";
			reportDataSource.Value = dataTable;
			this.reportViewerRus_0.LocalReport.DataSources.Clear();
			this.reportViewerRus_0.LocalReport.DataSources.Add(reportDataSource);
		}

		private void method_4()
		{
			string value = "";
			if (this.class498_0.tJ_CalcLossTrans.Rows.Count > 0 && this.class498_0.tJ_CalcLossTrans.Rows[0]["NoLoadLoss"] != DBNull.Value && this.class498_0.tJ_CalcLossTrans.Rows[0]["Period"] != DBNull.Value && this.class498_0.tJ_CalcLossTrans.Rows[0]["RatedVoltage"] != DBNull.Value && this.class498_0.tJ_CalcLossTrans.Rows[0]["MiddleVoltage"] != DBNull.Value && this.class498_0.tJ_CalcLossTrans.Rows[0]["LossElectrHH"] != DBNull.Value)
			{
				value = string.Concat(new string[]
				{
					" = ",
					Convert.ToDecimal(this.class498_0.tJ_CalcLossTrans.Rows[0]["NoLoadLoss"]).smethod_0(),
					" * ",
					Convert.ToDecimal(this.class498_0.tJ_CalcLossTrans.Rows[0]["Period"]).smethod_0(),
					" * (",
					Convert.ToDecimal(this.class498_0.tJ_CalcLossTrans.Rows[0]["MiddleVoltage"]).smethod_0(),
					" / ",
					Convert.ToDecimal(this.class498_0.tJ_CalcLossTrans.Rows[0]["RatedVoltage"]).smethod_0(),
					")² = ",
					Convert.ToDecimal(this.class498_0.tJ_CalcLossTrans.Rows[0]["LossElectrHH"]).smethod_0(),
					" кВт*ч"
				});
			}
			ReportParameter reportParameter = new ReportParameter("LossElectrHH", value);
			this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
			{
				reportParameter
			});
		}

		private void method_5()
		{
			if (this.class498_0.tJ_CalcLossTrans.Rows.Count > 0)
			{
				Class498.Class516 @class = new Class498.Class516();
				base.SelectSqlData(@class, true, "where idTRans = " + this.class498_0.tJ_CalcLossTrans.Rows[0]["id"].ToString(), null, false, 0);
				ReportDataSource reportDataSource = new ReportDataSource();
				reportDataSource.Name = "dsTransHH";
				reportDataSource.Value = @class;
				this.reportViewerRus_0.LocalReport.DataSources.Add(reportDataSource);
			}
		}

		private void method_6()
		{
			if (this.class498_0.tJ_CalcLossTrans.Rows.Count > 0)
			{
				if (this.class498_0.tJ_CalcLossTransHH.Rows.Count > 2)
				{
					string value = "Т.к. в трансформаторной подстанции находятся " + (this.class498_0.tJ_CalcLossTransHH.Rows.Count - 1).ToString() + " силовых трансформатора, потери электроэнергии холостого хода учитываются в каждом. Следовательно, суммарные потери холостого хода силовых трансформаторов составят:";
					ReportParameter reportParameter = new ReportParameter("TransSumHH", value);
					this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
					{
						reportParameter
					});
				}
				Class498.Class516 @class = new Class498.Class516();
				base.SelectSqlData(@class, true, "where idCalc = " + this.int_0.ToString() + " and idTRans is null", null, false, 0);
				ReportDataSource reportDataSource = new ReportDataSource();
				reportDataSource.Name = "dsTransSumHH";
				reportDataSource.Value = @class;
				this.reportViewerRus_0.LocalReport.DataSources.Add(reportDataSource);
			}
		}

		private void method_7()
		{
			string value = "";
			if (this.class498_0.tJ_CalcLossTrans.Rows.Count > 0 && this.class498_0.tJ_CalcLossTrans.Rows[0]["ShortCircuitLoss"] != DBNull.Value && this.class498_0.tJ_CalcLossTrans.Rows[0]["RatedVoltage"] != DBNull.Value && this.class498_0.tJ_CalcLossTrans.Rows[0]["RatedPower"] != DBNull.Value && this.class498_0.tJ_CalcLossTrans.Rows[0]["ActiveResistance"] != DBNull.Value)
			{
				value = string.Concat(new string[]
				{
					" = ",
					Convert.ToDecimal(this.class498_0.tJ_CalcLossTrans.Rows[0]["ShortCircuitLoss"]).smethod_0(),
					" * 0.001 * ",
					Convert.ToDecimal(this.class498_0.tJ_CalcLossTrans.Rows[0]["RatedVoltage"]).smethod_0(),
					"² / ",
					Convert.ToDecimal(this.class498_0.tJ_CalcLossTrans.Rows[0]["RatedPower"]).smethod_0(),
					"² = ",
					Convert.ToDecimal(this.class498_0.tJ_CalcLossTrans.Rows[0]["ActiveResistance"]).smethod_0(),
					" Ом/фазу"
				});
			}
			ReportParameter reportParameter = new ReportParameter("ActiveResistance", value);
			this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
			{
				reportParameter
			});
		}

		private void method_8()
		{
			string value = "";
			if (this.class498_0.tJ_CalcLossTrans.Rows.Count > 0 && this.class498_0.tJ_CalcLossTrans.Rows[0]["Consumption"] != DBNull.Value && this.class498_0.tJ_CalcLossTrans.Rows[0]["period"] != DBNull.Value && this.class498_0.tJ_CalcLossTrans.Rows[0]["LoadAverage"] != DBNull.Value)
			{
				value = string.Concat(new string[]
				{
					" = ",
					this.class498_0.tJ_CalcLossTrans.Rows[0]["Consumption"].ToString(),
					" * 0.001 / ",
					this.class498_0.tJ_CalcLossTrans.Rows[0]["period"].ToString(),
					" = ",
					Convert.ToDecimal(this.class498_0.tJ_CalcLossTrans.Rows[0]["LoadAverage"]).smethod_0(),
					" МВт"
				});
			}
			ReportParameter reportParameter = new ReportParameter("LoadAverage", value);
			this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
			{
				reportParameter
			});
		}

		private void method_9()
		{
			string value = "";
			if (this.class498_0.tJ_CalcLossTrans.Rows.Count > 0 && this.class498_0.tJ_CalcLossTrans.Rows[0]["LoadAverage"] != DBNull.Value && this.class498_0.tJ_CalcLossTrans.Rows[0]["ActiveResistance"] != DBNull.Value && this.class498_0.tJ_CalcLossTrans.Rows[0]["CoeffPowerReactive"] != DBNull.Value && this.class498_0.tJ_CalcLossTrans.Rows[0]["MiddleVoltage"] != DBNull.Value && this.class498_0.tJ_CalcLossTrans.Rows[0]["LoadPowerLoss"] != DBNull.Value)
			{
				value = string.Concat(new string[]
				{
					" = ",
					Convert.ToDecimal(this.class498_0.tJ_CalcLossTrans.Rows[0]["LoadAverage"]).smethod_0(),
					"² * 1000 * ",
					Convert.ToDecimal(this.class498_0.tJ_CalcLossTrans.Rows[0]["ActiveResistance"]).smethod_0(),
					" * (1 + ",
					Convert.ToDecimal(this.class498_0.tJ_CalcLossTrans.Rows[0]["CoeffPowerReactive"]).smethod_0(),
					"²) / ",
					Convert.ToDecimal(this.class498_0.tJ_CalcLossTrans.Rows[0]["MiddleVoltage"]).smethod_0(),
					"² = ",
					Convert.ToDecimal(this.class498_0.tJ_CalcLossTrans.Rows[0]["LoadPowerLoss"]).smethod_0(),
					" кВт"
				});
			}
			ReportParameter reportParameter = new ReportParameter("LoadPowerLoss", value);
			this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
			{
				reportParameter
			});
		}

		private void method_10()
		{
			string value = "";
			if (this.class498_0.tJ_CalcLossTrans.Rows.Count > 0 && this.class498_0.tJ_CalcLossTrans.Rows[0]["LoadPowerLoss"] != DBNull.Value && this.class498_0.tJ_CalcLossTrans.Rows[0]["CoeffDifference"] != DBNull.Value && this.class498_0.tJ_CalcLossTrans.Rows[0]["period"] != DBNull.Value && this.class498_0.tJ_CalcLossTrans.Rows[0]["SquareCoeffFromGraph"] != DBNull.Value && this.class498_0.tJ_CalcLossTrans.Rows[0]["LoadLosses"] != DBNull.Value)
			{
				value = string.Concat(new string[]
				{
					" = ",
					Convert.ToDecimal(this.class498_0.tJ_CalcLossTrans.Rows[0]["CoeffDifference"]).smethod_0(),
					" * ",
					Convert.ToDecimal(this.class498_0.tJ_CalcLossTrans.Rows[0]["LoadPowerLoss"]).smethod_0(),
					" * ",
					Convert.ToDecimal(this.class498_0.tJ_CalcLossTrans.Rows[0]["period"]).smethod_0(),
					" * ",
					Convert.ToDecimal(this.class498_0.tJ_CalcLossTrans.Rows[0]["SquareCoeffFromGraph"]).smethod_0(),
					" = ",
					Convert.ToDecimal(this.class498_0.tJ_CalcLossTrans.Rows[0]["LoadLosses"]).smethod_0(),
					" кВт*ч"
				});
			}
			ReportParameter reportParameter = new ReportParameter("LoadLosses", value);
			this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
			{
				reportParameter
			});
		}

		private void method_11()
		{
			string value = "";
			string value2 = "";
			if (this.class498_0.tJ_CalcLossTrans.Rows.Count > 0 && this.class498_0.tJ_CalcLossTrans.Rows[0]["CoeffLosses"] != DBNull.Value)
			{
				value2 = Convert.ToDecimal(this.class498_0.tJ_CalcLossTrans.Rows[0]["CoeffLosses"]).smethod_0();
				if (this.class498_0.tJ_CalcLossTrans.Rows[0]["LoadLosses"] != DBNull.Value && this.class498_0.tJ_CalcLossTrans.Rows[0]["Consumption"] != DBNull.Value)
				{
					value = string.Concat(new string[]
					{
						"100% * ",
						Convert.ToDecimal(this.class498_0.tJ_CalcLossTrans.Rows[0]["LoadLosses"]).smethod_0(),
						" / ",
						this.class498_0.tJ_CalcLossTrans.Rows[0]["Consumption"].ToString(),
						" = ",
						Convert.ToDecimal(this.class498_0.tJ_CalcLossTrans.Rows[0]["CoeffLosses"]).smethod_0(),
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
			this.icontainer_0 = new Container();
			ReportDataSource reportDataSource = new ReportDataSource();
			this.bindingSource_0 = new BindingSource(this.icontainer_0);
			this.class498_0 = new Class498();
			this.reportViewerRus_0 = new ReportViewerRus();
			this.panel_0 = new Panel();
			this.textBox_2 = new TextBox();
			this.label_3 = new Label();
			this.textBox_3 = new TextBox();
			this.label_4 = new Label();
			this.dateTimePicker_0 = new DateTimePicker();
			this.label_0 = new Label();
			this.textBox_0 = new TextBox();
			this.label_1 = new Label();
			this.textBox_1 = new TextBox();
			this.label_2 = new Label();
			((ISupportInitialize)this.bindingSource_0).BeginInit();
			((ISupportInitialize)this.class498_0).BeginInit();
			this.panel_0.SuspendLayout();
			base.SuspendLayout();
			this.bindingSource_0.DataMember = "dtSource";
			this.bindingSource_0.DataSource = this.class498_0;
			this.class498_0.DataSetName = "dsCalc";
			this.class498_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
			this.reportViewerRus_0.Dock = DockStyle.Fill;
			reportDataSource.Name = "dsSource";
			reportDataSource.Value = this.bindingSource_0;
			this.reportViewerRus_0.LocalReport.DataSources.Add(reportDataSource);
			this.reportViewerRus_0.LocalReport.ReportEmbeddedResource = "Documents.Forms.JournalCalcLoss.Report.ReportTransHH.rdlc";
			this.reportViewerRus_0.Location = new Point(0, 0);
			this.reportViewerRus_0.Name = "reportViewer1";
			this.reportViewerRus_0.Size = new Size(813, 440);
			this.reportViewerRus_0.TabIndex = 0;
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
			this.textBox_2.Location = new Point(283, 19);
			this.textBox_2.Name = "txtFIOBoss";
			this.textBox_2.Size = new Size(174, 20);
			this.textBox_2.TabIndex = 9;
			this.textBox_2.Text = "Исаева Н.В.";
			this.textBox_2.TextChanged += this.textBox_2_TextChanged;
			this.label_3.AutoSize = true;
			this.label_3.Location = new Point(280, 3);
			this.label_3.Name = "label5";
			this.label_3.Size = new Size(34, 13);
			this.label_3.TabIndex = 8;
			this.label_3.Text = "ФИО";
			this.textBox_3.Location = new Point(12, 19);
			this.textBox_3.Name = "txtTitleJob";
			this.textBox_3.Size = new Size(251, 20);
			this.textBox_3.TabIndex = 7;
			this.textBox_3.Text = "Начальник СКиУЭЭ";
			this.textBox_3.TextChanged += this.textBox_3_TextChanged;
			this.label_4.AutoSize = true;
			this.label_4.Location = new Point(12, 3);
			this.label_4.Name = "label4";
			this.label_4.Size = new Size(65, 13);
			this.label_4.TabIndex = 6;
			this.label_4.Text = "Должность";
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
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(813, 535);
			base.Controls.Add(this.reportViewerRus_0);
			base.Controls.Add(this.panel_0);
			base.Name = "FormReportCalcLossTrans";
			this.Text = "Печать расчета потерь";
			base.FormClosing += this.FormReportCalcLossTrans_FormClosing;
			base.Load += this.FormReportCalcLossTrans_Load;
			((ISupportInitialize)this.bindingSource_0).EndInit();
			((ISupportInitialize)this.class498_0).EndInit();
			this.panel_0.ResumeLayout(false);
			this.panel_0.PerformLayout();
			base.ResumeLayout(false);
		}

		internal static void AZCjgSrymHHifQAPKCGp(Form form_0, bool bool_0)
		{
			form_0.Dispose(bool_0);
		}

		private int int_0;

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

		private BindingSource bindingSource_0;
	}
}
