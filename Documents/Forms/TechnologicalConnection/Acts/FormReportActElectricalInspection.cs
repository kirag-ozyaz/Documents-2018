using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using FormLbr;
using FormLbr.Classes;
using Microsoft.Reporting.WinForms;

namespace Documents.Forms.TechnologicalConnection.Acts
{
	public partial class FormReportActElectricalInspection : FormBase
	{
		internal FormReportActElectricalInspection()
		{
			
			this.int_0 = -1;
			this.int_1 = -1;
			this.dateTime_0 = DateTime.MinValue;
			
			this.method_7();
		}

		public FormReportActElectricalInspection(int idAct)
		{
			
			this.int_0 = -1;
			this.int_1 = -1;
			this.dateTime_0 = DateTime.MinValue;
			
			this.method_7();
			this.int_0 = idAct;
		}

		private void FormReportActElectricalInspection_Load(object sender, EventArgs e)
		{
			base.SelectSqlData(this.class10_0, this.class10_0.tTC_Doc, true, "where id = " + this.int_0.ToString());
			if (this.class10_0.tTC_Doc.Rows.Count > 0)
			{
				this.int_1 = Convert.ToInt32(this.class10_0.tTC_Doc.Rows[0]["TypeDoc"]);
				this.dateTime_0 = Convert.ToDateTime(this.class10_0.tTC_Doc.Rows[0]["dateDoc"]);
				switch (this.int_1)
				{
				case 1238:
					this.reportViewer_0.LocalReport.ReportEmbeddedResource = "Documents.Forms.TechnologicalConnection.Acts.Reports.ActElectricalInspection2.rdlc";
					this.method_1();
					break;
				case 1239:
					this.method_0();
					return;
				case 1240:
					this.reportViewer_0.LocalReport.ReportEmbeddedResource = "Documents.Forms.TechnologicalConnection.Acts.Reports.ActTC.rdlc";
					this.Text = "Акт технологического присоединения";
					break;
				}
				if (this.class10_0.tTC_Doc.Rows[0]["idparent"] != DBNull.Value)
				{
					DataTable dataTable = base.SelectSqlData("vtc_tu", true, " where id = " + this.class10_0.tTC_Doc.Rows[0]["idparent"].ToString());
					if (dataTable.Rows.Count > 0)
					{
						if (dataTable.Rows[0]["dateDoc"] != DBNull.Value)
						{
							ReportParameter reportParameter = new ReportParameter("DateTU", Convert.ToDateTime(dataTable.Rows[0]["dateDoc"]).ToString("dd.MM.yyyy"));
							this.reportViewer_0.LocalReport.SetParameters(new ReportParameter[]
							{
								reportParameter
							});
						}
						if (dataTable.Rows[0]["numDoc"] != DBNull.Value)
						{
							ReportParameter reportParameter2 = new ReportParameter("NumTU", dataTable.Rows[0]["numDoc"].ToString());
							this.reportViewer_0.LocalReport.SetParameters(new ReportParameter[]
							{
								reportParameter2
							});
						}
						if (dataTable.Rows[0]["Power"] != DBNull.Value)
						{
							ReportParameter reportParameter3 = new ReportParameter("PowerAdd", dataTable.Rows[0]["Power"].ToString());
							this.reportViewer_0.LocalReport.SetParameters(new ReportParameter[]
							{
								reportParameter3
							});
						}
						if (dataTable.Rows[0]["PowerSum"] != DBNull.Value)
						{
							ReportParameter reportParameter4 = new ReportParameter("PowerSum", dataTable.Rows[0]["PowerSum"].ToString());
							this.reportViewer_0.LocalReport.SetParameters(new ReportParameter[]
							{
								reportParameter4
							});
						}
						if (dataTable.Rows[0]["dateContractor"] != DBNull.Value)
						{
							ReportParameter reportParameter5 = new ReportParameter("DateContract", Convert.ToDateTime(dataTable.Rows[0]["dateContractor"]).ToString("dd.MM.yyyy"));
							this.reportViewer_0.LocalReport.SetParameters(new ReportParameter[]
							{
								reportParameter5
							});
						}
						if (dataTable.Rows[0]["numContractor"] != DBNull.Value)
						{
							ReportParameter reportParameter6 = new ReportParameter("NumContract", dataTable.Rows[0]["numContractor"].ToString());
							this.reportViewer_0.LocalReport.SetParameters(new ReportParameter[]
							{
								reportParameter6
							});
						}
						if (this.int_1 == 1240)
						{
							if (dataTable.Rows[0]["idContractor"] != DBNull.Value)
							{
								DataTable dataTable2 = base.SelectSqlData("ttc_contract", true, "where id = " + dataTable.Rows[0]["idContractor"].ToString());
								if (dataTable2.Rows.Count > 0)
								{
									if (dataTable2.Rows[0]["SumContract"] != DBNull.Value)
									{
										ReportParameter reportParameter7 = new ReportParameter("SumContract", Convert.ToDecimal(dataTable2.Rows[0]["SumContract"]).ToString("N"));
										this.reportViewer_0.LocalReport.SetParameters(new ReportParameter[]
										{
											reportParameter7
										});
										string value = RuDateAndMoneyConverter.CurrencyToTxt(Convert.ToDouble(dataTable2.Rows[0]["SumContract"]), false);
										reportParameter7 = new ReportParameter("SumContractTxt", value);
										this.reportViewer_0.LocalReport.SetParameters(new ReportParameter[]
										{
											reportParameter7
										});
									}
									if (dataTable2.Rows[0]["SumNDS"] != DBNull.Value)
									{
										ReportParameter reportParameter8 = new ReportParameter("SumNDS", Convert.ToDecimal(dataTable2.Rows[0]["SumNDS"]).ToString("N"));
										this.reportViewer_0.LocalReport.SetParameters(new ReportParameter[]
										{
											reportParameter8
										});
										string value2 = RuDateAndMoneyConverter.CurrencyToTxt(Convert.ToDouble(dataTable2.Rows[0]["SumNDS"]), false);
										reportParameter8 = new ReportParameter("SumNDSTxt", value2);
										this.reportViewer_0.LocalReport.SetParameters(new ReportParameter[]
										{
											reportParameter8
										});
									}
								}
							}
							DataTable dataTable3 = base.SelectSqlData("tTC_doc", true, "where idParent = " + dataTable.Rows[0]["id"].ToString() + " and typeDoc = " + 1239.ToString());
							if (dataTable3.Rows.Count > 0)
							{
								if (dataTable3.Rows[0]["numDoc"] != DBNull.Value)
								{
									ReportParameter reportParameter9 = new ReportParameter("NumPerformanceTU", dataTable3.Rows[0]["numDoc"].ToString());
									this.reportViewer_0.LocalReport.SetParameters(new ReportParameter[]
									{
										reportParameter9
									});
								}
								if (dataTable3.Rows[0]["dateDoc"] != DBNull.Value)
								{
									ReportParameter reportParameter10 = new ReportParameter("DatePerformanceTU", Convert.ToDateTime(dataTable3.Rows[0]["dateDoc"]).ToString("dd.MM.yyyy"));
									this.reportViewer_0.LocalReport.SetParameters(new ReportParameter[]
									{
										reportParameter10
									});
								}
							}
						}
						if (dataTable.Rows[0]["categoryName"] != DBNull.Value)
						{
							ReportParameter reportParameter11 = new ReportParameter("Category", dataTable.Rows[0]["categoryName"].ToString());
							this.reportViewer_0.LocalReport.SetParameters(new ReportParameter[]
							{
								reportParameter11
							});
						}
						this.method_5();
						base.SelectSqlData(this.class10_0, this.class10_0.vTC_TUPointAttach, true, string.Concat(new string[]
						{
							"where idTU = ",
							dataTable.Rows[0]["id"].ToString(),
							" and (typeDoc is null or typeDoc = ",
							1123.ToString(),
							") "
						}));
					}
				}
			}
			this.reportViewer_0.RefreshReport();
		}

		private void method_0()
		{
			this.reportViewer_0.LocalReport.ReportEmbeddedResource = "Documents.Forms.TechnologicalConnection.Acts.Reports.ActPerformingTU2.rdlc";
			this.Text = "Акт о выполнении технических условий";
			if (this.class10_0.tTC_Doc.Rows[0]["idparent"] != DBNull.Value)
			{
				DataTable dataTable = base.SelectSqlData("vtc_tu", true, " where id = " + this.class10_0.tTC_Doc.Rows[0]["idparent"].ToString());
				if (dataTable.Rows.Count > 0)
				{
					if (dataTable.Rows[0]["dateDoc"] != DBNull.Value)
					{
						ReportParameter reportParameter = new ReportParameter("DateTU", Convert.ToDateTime(dataTable.Rows[0]["dateDoc"]).ToString("dd.MM.yyyy"));
						this.reportViewer_0.LocalReport.SetParameters(new ReportParameter[]
						{
							reportParameter
						});
					}
					if (dataTable.Rows[0]["numDoc"] != DBNull.Value)
					{
						ReportParameter reportParameter2 = new ReportParameter("NumTU", dataTable.Rows[0]["numDoc"].ToString());
						this.reportViewer_0.LocalReport.SetParameters(new ReportParameter[]
						{
							reportParameter2
						});
					}
					if (dataTable.Rows[0]["Power"] != DBNull.Value)
					{
						ReportParameter reportParameter3 = new ReportParameter("PowerAdd", dataTable.Rows[0]["Power"].ToString());
						this.reportViewer_0.LocalReport.SetParameters(new ReportParameter[]
						{
							reportParameter3
						});
					}
					if (dataTable.Rows[0]["PowerSum"] != DBNull.Value)
					{
						ReportParameter reportParameter4 = new ReportParameter("PowerSum", dataTable.Rows[0]["PowerSum"].ToString());
						this.reportViewer_0.LocalReport.SetParameters(new ReportParameter[]
						{
							reportParameter4
						});
					}
					if (dataTable.Rows[0]["dateContractor"] != DBNull.Value)
					{
						ReportParameter reportParameter5 = new ReportParameter("DateContract", Convert.ToDateTime(dataTable.Rows[0]["dateContractor"]).ToString("dd.MM.yyyy"));
						this.reportViewer_0.LocalReport.SetParameters(new ReportParameter[]
						{
							reportParameter5
						});
					}
					if (dataTable.Rows[0]["numContractor"] != DBNull.Value)
					{
						ReportParameter reportParameter6 = new ReportParameter("NumContract", dataTable.Rows[0]["numContractor"].ToString());
						this.reportViewer_0.LocalReport.SetParameters(new ReportParameter[]
						{
							reportParameter6
						});
					}
					if (dataTable.Rows[0]["categoryName"] != DBNull.Value)
					{
						ReportParameter reportParameter7 = new ReportParameter("Category", dataTable.Rows[0]["categoryName"].ToString());
						this.reportViewer_0.LocalReport.SetParameters(new ReportParameter[]
						{
							reportParameter7
						});
					}
					if (dataTable.Rows[0]["NameAbn"] != DBNull.Value)
					{
						ReportParameter reportParameter8 = new ReportParameter("AbnName", dataTable.Rows[0]["NameAbn"].ToString());
						this.reportViewer_0.LocalReport.SetParameters(new ReportParameter[]
						{
							reportParameter8
						});
					}
					if (dataTable.Rows[0]["Address"] != DBNull.Value)
					{
						ReportParameter reportParameter9 = new ReportParameter("Address", dataTable.Rows[0]["Address"].ToString());
						this.reportViewer_0.LocalReport.SetParameters(new ReportParameter[]
						{
							reportParameter9
						});
					}
					this.method_5();
					this.method_6();
					base.SelectSqlData(this.class10_0, this.class10_0.vTC_TUPointAttach, true, string.Concat(new string[]
					{
						"where idTU = ",
						dataTable.Rows[0]["id"].ToString(),
						" and (typeDoc is null or typeDoc = ",
						1123.ToString(),
						") "
					}));
				}
				DataTable dataTable2 = base.SelectSqlData("ttc_tu", true, " where id = " + this.class10_0.tTC_Doc.Rows[0]["idparent"].ToString());
				if (dataTable2.Rows.Count > 0 && dataTable2.Rows[0]["DeviceName"] != DBNull.Value)
				{
					ReportParameter reportParameter10 = new ReportParameter("VRU", dataTable2.Rows[0]["DeviceName"].ToString());
					this.reportViewer_0.LocalReport.SetParameters(new ReportParameter[]
					{
						reportParameter10
					});
				}
				DataTable dataTable3 = base.SelectSqlData("ttc_PerformingTU", true, "where id = " + this.class10_0.tTC_Doc.Rows[0]["id"].ToString());
				if (dataTable3.Rows.Count > 0)
				{
					if (dataTable3.Rows[0]["FaceNetWork"] != DBNull.Value)
					{
						ReportParameter reportParameter11 = new ReportParameter("FaceNetWork", dataTable3.Rows[0]["FaceNetWork"].ToString());
						this.reportViewer_0.LocalReport.SetParameters(new ReportParameter[]
						{
							reportParameter11
						});
					}
					if (dataTable3.Rows[0]["BasisNetWork"] != DBNull.Value)
					{
						ReportParameter reportParameter12 = new ReportParameter("BasisNetWork", dataTable3.Rows[0]["BasisNetWork"].ToString());
						this.reportViewer_0.LocalReport.SetParameters(new ReportParameter[]
						{
							reportParameter12
						});
					}
					if (dataTable3.Rows[0]["FaceApplicant"] != DBNull.Value)
					{
						ReportParameter reportParameter13 = new ReportParameter("FaceApplicant", dataTable3.Rows[0]["FaceApplicant"].ToString());
						this.reportViewer_0.LocalReport.SetParameters(new ReportParameter[]
						{
							reportParameter13
						});
					}
					if (dataTable3.Rows[0]["BasisApplicant"] != DBNull.Value)
					{
						ReportParameter reportParameter14 = new ReportParameter("BasisApplicant", dataTable3.Rows[0]["BasisApplicant"].ToString());
						this.reportViewer_0.LocalReport.SetParameters(new ReportParameter[]
						{
							reportParameter14
						});
					}
				}
				ReportDataSource reportDataSource = new ReportDataSource();
				reportDataSource.Name = "tTC_TUTypeWork";
				reportDataSource.Value = this.class10_0.tTC_TUTypeWork;
				this.reportViewer_0.LocalReport.DataSources.Add(reportDataSource);
				base.SelectSqlData(this.class10_0.tTC_TUTypeWork, true, " where idTU = " + this.class10_0.tTC_Doc.Rows[0]["idparent"].ToString() + " and typeWork = 2 order by num", null, false, 0);
				DataTable dataTable4 = base.SelectSqlData("ttc_doc", true, " where idParent = " + this.class10_0.tTC_Doc.Rows[0]["idparent"].ToString() + " and typeDoc = " + 1238.ToString());
				if (dataTable4.Rows.Count > 0 && dataTable4.Rows[0]["numDoc"] != DBNull.Value)
				{
					string text = "№" + dataTable4.Rows[0]["numDoc"].ToString();
					if (dataTable4.Rows[0]["dateDoc"] != DBNull.Value)
					{
						text = text + " от " + Convert.ToDateTime(dataTable4.Rows[0]["dateDoc"]).ToString("dd.MM.yyyy");
					}
					ReportParameter reportParameter15 = new ReportParameter("ActElInsp", text);
					this.reportViewer_0.LocalReport.SetParameters(new ReportParameter[]
					{
						reportParameter15
					});
				}
			}
			this.reportViewer_0.RefreshReport();
		}

		private void method_1()
		{
			this.Text = "Акт осмотра электроустановок";
			if (this.int_1 == 1238)
			{
				base.SelectSqlData(this.class10_0.tTC_ElectricalInspection, true, "where id = " + this.int_0.ToString(), null, false, 0);
				if (this.class10_0.tTC_ElectricalInspection.Rows.Count > 0)
				{
					if (this.class10_0.tTC_ElectricalInspection.Rows[0]["idWorker"] != DBNull.Value)
					{
						this.method_3(Convert.ToInt32(this.class10_0.tTC_ElectricalInspection.Rows[0]["idWorker"]));
					}
					if (this.class10_0.tTC_ElectricalInspection.Rows[0]["Declarer"] != DBNull.Value)
					{
						ReportParameter reportParameter = new ReportParameter("Declarer", this.class10_0.tTC_ElectricalInspection.Rows[0]["Declarer"].ToString());
						this.reportViewer_0.LocalReport.SetParameters(new ReportParameter[]
						{
							reportParameter
						});
					}
					if (this.class10_0.tTC_ElectricalInspection.Rows[0]["Electrical"] != DBNull.Value)
					{
						ReportParameter reportParameter2 = new ReportParameter("Electrical", this.class10_0.tTC_ElectricalInspection.Rows[0]["Electrical"].ToString());
						this.reportViewer_0.LocalReport.SetParameters(new ReportParameter[]
						{
							reportParameter2
						});
					}
					if (this.class10_0.tTC_ElectricalInspection.Rows[0]["SetElectrical"] != DBNull.Value)
					{
						ReportParameter reportParameter3 = new ReportParameter("SetElectrical", this.class10_0.tTC_ElectricalInspection.Rows[0]["SetElectrical"].ToString());
						this.reportViewer_0.LocalReport.SetParameters(new ReportParameter[]
						{
							reportParameter3
						});
					}
					if (this.class10_0.tTC_ElectricalInspection.Rows[0]["SetMeterDevice"] != DBNull.Value)
					{
						ReportParameter reportParameter4 = new ReportParameter("SetMeterDevice", this.class10_0.tTC_ElectricalInspection.Rows[0]["SetMeterDevice"].ToString());
						this.reportViewer_0.LocalReport.SetParameters(new ReportParameter[]
						{
							reportParameter4
						});
					}
					if (this.class10_0.tTC_ElectricalInspection.Rows[0]["SetRZA"] != DBNull.Value)
					{
						ReportParameter reportParameter5 = new ReportParameter("SetRZA", this.class10_0.tTC_ElectricalInspection.Rows[0]["SetRZA"].ToString());
						this.reportViewer_0.LocalReport.SetParameters(new ReportParameter[]
						{
							reportParameter5
						});
					}
					if (this.class10_0.tTC_ElectricalInspection.Rows[0]["SetReserveCP"] != DBNull.Value)
					{
						ReportParameter reportParameter6 = new ReportParameter("SetReserveCP", this.class10_0.tTC_ElectricalInspection.Rows[0]["SetReserveCP"].ToString());
						this.reportViewer_0.LocalReport.SetParameters(new ReportParameter[]
						{
							reportParameter6
						});
					}
					if (this.class10_0.tTC_ElectricalInspection.Rows[0]["SetDocument"] != DBNull.Value)
					{
						ReportParameter reportParameter7 = new ReportParameter("SetDocument", this.class10_0.tTC_ElectricalInspection.Rows[0]["SetDocument"].ToString());
						this.reportViewer_0.LocalReport.SetParameters(new ReportParameter[]
						{
							reportParameter7
						});
					}
					this.method_2();
				}
			}
		}

		private void method_2()
		{
			if (this.class10_0.tTC_ElectricalInspection.Rows.Count > 0 && this.class10_0.tTC_ElectricalInspection.Rows[0]["Officials"] != DBNull.Value)
			{
				try
				{
					XmlDocument xmlDocument = new XmlDocument();
					xmlDocument.LoadXml(this.class10_0.tTC_ElectricalInspection.Rows[0]["Officials"].ToString());
					XmlNode xmlNode = xmlDocument.SelectSingleNode("Official");
					if (xmlNode != null)
					{
						XmlNode xmlNode2 = xmlNode.SelectSingleNode("Seti");
						if (xmlNode2 != null)
						{
							XmlNode xmlNode3 = xmlNode2.SelectSingleNode("FIO1");
							if (xmlNode3 != null)
							{
								XmlAttribute xmlAttribute = xmlNode3.Attributes["FIO"];
								if (xmlAttribute != null)
								{
									ReportParameter reportParameter = new ReportParameter("SetFIO1", xmlAttribute.Value);
									this.reportViewer_0.LocalReport.SetParameters(new ReportParameter[]
									{
										reportParameter
									});
								}
								xmlAttribute = xmlNode3.Attributes["JobTitle"];
								if (xmlAttribute != null)
								{
									ReportParameter reportParameter2 = new ReportParameter("SetJob1", xmlAttribute.Value);
									this.reportViewer_0.LocalReport.SetParameters(new ReportParameter[]
									{
										reportParameter2
									});
								}
							}
							XmlNode xmlNode4 = xmlNode2.SelectSingleNode("FIO2");
							if (xmlNode4 != null)
							{
								XmlAttribute xmlAttribute2 = xmlNode4.Attributes["FIO"];
								if (xmlAttribute2 != null)
								{
									ReportParameter reportParameter3 = new ReportParameter("SetFIO2", xmlAttribute2.Value);
									this.reportViewer_0.LocalReport.SetParameters(new ReportParameter[]
									{
										reportParameter3
									});
								}
								xmlAttribute2 = xmlNode4.Attributes["JobTitle"];
								if (xmlAttribute2 != null)
								{
									ReportParameter reportParameter4 = new ReportParameter("SetJob2", xmlAttribute2.Value);
									this.reportViewer_0.LocalReport.SetParameters(new ReportParameter[]
									{
										reportParameter4
									});
								}
							}
							XmlNode xmlNode5 = xmlNode2.SelectSingleNode("FIO3");
							if (xmlNode5 != null)
							{
								XmlAttribute xmlAttribute3 = xmlNode5.Attributes["FIO"];
								if (xmlAttribute3 != null)
								{
									ReportParameter reportParameter5 = new ReportParameter("SetFIO3", xmlAttribute3.Value);
									this.reportViewer_0.LocalReport.SetParameters(new ReportParameter[]
									{
										reportParameter5
									});
								}
								xmlAttribute3 = xmlNode5.Attributes["JobTitle"];
								if (xmlAttribute3 != null)
								{
									ReportParameter reportParameter6 = new ReportParameter("SetJob3", xmlAttribute3.Value);
									this.reportViewer_0.LocalReport.SetParameters(new ReportParameter[]
									{
										reportParameter6
									});
								}
							}
							XmlNode xmlNode6 = xmlNode2.SelectSingleNode("Official");
							if (xmlNode6 != null)
							{
								XmlAttribute xmlAttribute4 = xmlNode6.Attributes["FIO"];
								if (xmlAttribute4 != null)
								{
									ReportParameter reportParameter7 = new ReportParameter("SetFIO4", xmlAttribute4.Value);
									this.reportViewer_0.LocalReport.SetParameters(new ReportParameter[]
									{
										reportParameter7
									});
								}
								xmlAttribute4 = xmlNode6.Attributes["JobTitle"];
								if (xmlAttribute4 != null)
								{
									ReportParameter reportParameter8 = new ReportParameter("SetJob4", xmlAttribute4.Value);
									this.reportViewer_0.LocalReport.SetParameters(new ReportParameter[]
									{
										reportParameter8
									});
								}
							}
						}
						XmlNode xmlNode7 = xmlNode.SelectSingleNode("Declarer");
						if (xmlNode7 != null)
						{
							XmlNode xmlNode8 = xmlNode7.SelectSingleNode("FIO1");
							if (xmlNode8 != null)
							{
								XmlAttribute xmlAttribute5 = xmlNode8.Attributes["FIO"];
								if (xmlAttribute5 != null)
								{
									ReportParameter reportParameter9 = new ReportParameter("DeclarerFIO1", xmlAttribute5.Value);
									this.reportViewer_0.LocalReport.SetParameters(new ReportParameter[]
									{
										reportParameter9
									});
								}
								xmlAttribute5 = xmlNode8.Attributes["JobTitle"];
								if (xmlAttribute5 != null)
								{
									ReportParameter reportParameter10 = new ReportParameter("DeclarerJob1", xmlAttribute5.Value);
									this.reportViewer_0.LocalReport.SetParameters(new ReportParameter[]
									{
										reportParameter10
									});
								}
							}
							xmlNode8 = xmlNode7.SelectSingleNode("FIO2");
							if (xmlNode8 != null)
							{
								XmlAttribute xmlAttribute6 = xmlNode8.Attributes["FIO"];
								if (xmlAttribute6 != null)
								{
									ReportParameter reportParameter11 = new ReportParameter("DeclarerFIO2", xmlAttribute6.Value);
									this.reportViewer_0.LocalReport.SetParameters(new ReportParameter[]
									{
										reportParameter11
									});
								}
								xmlAttribute6 = xmlNode8.Attributes["JobTitle"];
								if (xmlAttribute6 != null)
								{
									ReportParameter reportParameter12 = new ReportParameter("DeclarerJob2", xmlAttribute6.Value);
									this.reportViewer_0.LocalReport.SetParameters(new ReportParameter[]
									{
										reportParameter12
									});
								}
							}
							xmlNode8 = xmlNode7.SelectSingleNode("FIO3");
							if (xmlNode8 != null)
							{
								XmlAttribute xmlAttribute7 = xmlNode8.Attributes["FIO"];
								if (xmlAttribute7 != null)
								{
									ReportParameter reportParameter13 = new ReportParameter("DeclarerFIO3", xmlAttribute7.Value);
									this.reportViewer_0.LocalReport.SetParameters(new ReportParameter[]
									{
										reportParameter13
									});
								}
								xmlAttribute7 = xmlNode8.Attributes["JobTitle"];
								if (xmlAttribute7 != null)
								{
									ReportParameter reportParameter14 = new ReportParameter("DeclarerJob3", xmlAttribute7.Value);
									this.reportViewer_0.LocalReport.SetParameters(new ReportParameter[]
									{
										reportParameter14
									});
								}
							}
							xmlNode8 = xmlNode7.SelectSingleNode("FIO4");
							if (xmlNode8 != null)
							{
								XmlAttribute xmlAttribute8 = xmlNode8.Attributes["FIO"];
								if (xmlAttribute8 != null)
								{
									ReportParameter reportParameter15 = new ReportParameter("DeclarerFIO4", xmlAttribute8.Value);
									this.reportViewer_0.LocalReport.SetParameters(new ReportParameter[]
									{
										reportParameter15
									});
								}
								xmlAttribute8 = xmlNode8.Attributes["JobTitle"];
								if (xmlAttribute8 != null)
								{
									ReportParameter reportParameter16 = new ReportParameter("DeclarerJob4", xmlAttribute8.Value);
									this.reportViewer_0.LocalReport.SetParameters(new ReportParameter[]
									{
										reportParameter16
									});
								}
							}
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, ex.Source);
				}
			}
		}

		private void TwYofHahem5()
		{
		}

		private void method_3(int int_2)
		{
			DataTable dataTable = base.SelectSqlData("tr_Worker", true, "where id = " + int_2.ToString());
			if (dataTable.Rows.Count > 0)
			{
				string text = "";
				string text2 = "";
				string text3 = "";
				string text4 = "";
				if (dataTable.Rows[0]["Padez"] != DBNull.Value)
				{
					try
					{
						XmlDocument xmlDocument = new XmlDocument();
						xmlDocument.LoadXml((string)dataTable.Rows[0]["Padez"]);
						XmlNode xmlNode = xmlDocument.SelectSingleNode("FIO");
						if (xmlNode != null)
						{
							XmlNode xmlNode2 = xmlNode.SelectSingleNode("ablative");
							if (xmlNode2 != null)
							{
								XmlAttribute xmlAttribute = (XmlAttribute)xmlNode2.Attributes.GetNamedItem("F");
								if (xmlAttribute != null)
								{
									text = xmlAttribute.Value;
								}
								xmlAttribute = (XmlAttribute)xmlNode2.Attributes.GetNamedItem("I");
								if (xmlAttribute != null)
								{
									text2 = xmlAttribute.Value;
								}
								xmlAttribute = (XmlAttribute)xmlNode2.Attributes.GetNamedItem("O");
								if (xmlAttribute != null)
								{
									text3 = xmlAttribute.Value;
								}
							}
						}
					}
					catch
					{
					}
				}
				if (string.IsNullOrEmpty(text))
				{
					text = dataTable.Rows[0]["F"].ToString();
				}
				if (string.IsNullOrEmpty(text2))
				{
					text2 = dataTable.Rows[0]["i"].ToString();
				}
				if (string.IsNullOrEmpty(text3))
				{
					text3 = dataTable.Rows[0]["o"].ToString();
				}
				text4 = text;
				if (!string.IsNullOrEmpty(text2) && text2.Length > 0)
				{
					text4 = text4 + " " + text2.Substring(0, 1) + ".";
					if (!string.IsNullOrEmpty(text3) && text3.Length > 0)
					{
						text4 = text4 + text3.Substring(0, 1) + ".";
					}
				}
				string value = "";
				if (dataTable.Rows[0]["JobTitle"] != DBNull.Value)
				{
					DataTable dataTable2 = base.SelectSqlData("tr_JobTitle", true, "where id = " + dataTable.Rows[0]["JobTitle"].ToString());
					if (dataTable2.Rows.Count > 0)
					{
						if (dataTable2.Rows[0]["Padez"] != DBNull.Value)
						{
							try
							{
								XmlDocument xmlDocument2 = new XmlDocument();
								xmlDocument2.LoadXml((string)dataTable2.Rows[0]["Padez"]);
								XmlNode xmlNode3 = xmlDocument2.SelectSingleNode("JobTitle");
								if (xmlNode3 != null)
								{
									XmlNode xmlNode4 = xmlNode3.SelectSingleNode("ablative");
									if (xmlNode4 != null)
									{
										XmlAttribute xmlAttribute2 = (XmlAttribute)xmlNode4.Attributes.GetNamedItem("Description");
										if (xmlAttribute2 != null)
										{
											value = xmlAttribute2.Value;
										}
									}
								}
							}
							catch
							{
							}
						}
						if (string.IsNullOrEmpty(value) && dataTable2.Rows[0]["Description"] != DBNull.Value)
						{
							value = dataTable2.Rows[0]["Description"].ToString();
						}
						ReportParameter reportParameter = new ReportParameter("JobTitle", value);
						this.reportViewer_0.LocalReport.SetParameters(new ReportParameter[]
						{
							reportParameter
						});
					}
				}
				if (!string.IsNullOrEmpty(value))
				{
					string text5 = this.method_4();
					if (!string.IsNullOrEmpty(text5))
					{
						text4 = text5 + " " + text4;
					}
				}
				ReportParameter reportParameter2 = new ReportParameter("ChiefSR", text4);
				this.reportViewer_0.LocalReport.SetParameters(new ReportParameter[]
				{
					reportParameter2
				});
			}
		}

		private string method_4()
		{
			DataTable dataTable = base.SelectSqlData("vAbnType", true, " where typeKontragent = " + 1115.ToString());
			if (dataTable.Rows.Count > 0)
			{
				return dataTable.Rows[0]["Name"].ToString();
			}
			return string.Empty;
		}

		private void method_5()
		{
			DataTable dataTable = base.SelectSqlData("vAbnType", true, " where typeKontragent = " + 1115.ToString());
			if (dataTable.Rows.Count > 0)
			{
				ReportParameter reportParameter = new ReportParameter("OrgOwn", dataTable.Rows[0]["Name"].ToString());
				this.reportViewer_0.LocalReport.SetParameters(new ReportParameter[]
				{
					reportParameter
				});
			}
		}

		private void method_6()
		{
			DataTable dataTable = base.SelectSqlData("vAbnType", true, " where typeKontragent = " + 1115.ToString());
			if (dataTable.Rows.Count > 0)
			{
				DataTable dataTable2 = base.SelectSqlData("tg_AbnInfo", true, " where idAbn = " + dataTable.Rows[0]["idAbn"].ToString() + " order by DateChange desc");
				if (dataTable2.Rows.Count > 0 && dataTable2.Rows[0]["NameShort"] != DBNull.Value && !string.IsNullOrEmpty(dataTable2.Rows[0]["NameShort"].ToString()))
				{
					ReportParameter reportParameter = new ReportParameter("OrgOwnShort", dataTable2.Rows[0]["NameShort"].ToString());
					this.reportViewer_0.LocalReport.SetParameters(new ReportParameter[]
					{
						reportParameter
					});
					return;
				}
				ReportParameter reportParameter2 = new ReportParameter("OrgOwnShort", dataTable.Rows[0]["Name"].ToString());
				this.reportViewer_0.LocalReport.SetParameters(new ReportParameter[]
				{
					reportParameter2
				});
			}
		}

		private void checkBox_0_CheckedChanged(object sender, EventArgs e)
		{
			if (this.class10_0.tTC_Doc.Rows.Count > 0)
			{
				if (this.checkBox_0.Checked && this.dateTime_0 != DateTime.MinValue)
				{
					this.class10_0.tTC_Doc.Rows[0]["datedoc"] = this.dateTime_0;
				}
				else
				{
					this.class10_0.tTC_Doc.Rows[0]["datedoc"] = DBNull.Value;
				}
				this.reportViewer_0.RefreshReport();
			}
		}

		private void method_7()
		{
			this.icontainer_0 = new Container();
			ReportDataSource reportDataSource = new ReportDataSource();
			ReportDataSource reportDataSource2 = new ReportDataSource();
			this.Rygoffcowh5 = new BindingSource(this.icontainer_0);
			this.class10_0 = new Class10();
			this.bindingSource_0 = new BindingSource(this.icontainer_0);
			this.reportViewer_0 = new ReportViewer();
			this.panel_0 = new Panel();
			this.checkBox_0 = new CheckBox();
			((ISupportInitialize)this.Rygoffcowh5).BeginInit();
			((ISupportInitialize)this.class10_0).BeginInit();
			((ISupportInitialize)this.bindingSource_0).BeginInit();
			this.panel_0.SuspendLayout();
			base.SuspendLayout();
			this.Rygoffcowh5.DataMember = "tTC_Doc";
			this.Rygoffcowh5.DataSource = this.class10_0;
			this.class10_0.DataSetName = "DataSetTechConnection";
			this.class10_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
			this.bindingSource_0.DataMember = "vTC_TUPointAttach";
			this.bindingSource_0.DataSource = this.class10_0;
			this.reportViewer_0.Dock = DockStyle.Fill;
			reportDataSource.Name = "tTC_Doc";
			reportDataSource.Value = this.Rygoffcowh5;
			reportDataSource2.Name = "vTC_TUPointAttach";
			reportDataSource2.Value = this.bindingSource_0;
			this.reportViewer_0.LocalReport.DataSources.Add(reportDataSource);
			this.reportViewer_0.LocalReport.DataSources.Add(reportDataSource2);
			this.reportViewer_0.LocalReport.ReportEmbeddedResource = "Documents.Forms.TechnologicalConnection.Acts.Reports.ActElectricalInspection.rdlc";
			this.reportViewer_0.Location = new Point(0, 38);
			this.reportViewer_0.Name = "reportViewer1";
			this.reportViewer_0.Size = new Size(771, 316);
			this.reportViewer_0.TabIndex = 0;
			this.panel_0.Controls.Add(this.checkBox_0);
			this.panel_0.Dock = DockStyle.Top;
			this.panel_0.Location = new Point(0, 0);
			this.panel_0.Name = "panel1";
			this.panel_0.Size = new Size(771, 38);
			this.panel_0.TabIndex = 1;
			this.checkBox_0.AutoSize = true;
			this.checkBox_0.Checked = true;
			this.checkBox_0.CheckState = CheckState.Checked;
			this.checkBox_0.Location = new Point(12, 12);
			this.checkBox_0.Name = "checkBoxDateOut";
			this.checkBox_0.Size = new Size(152, 17);
			this.checkBox_0.TabIndex = 0;
			this.checkBox_0.Text = "Вывести дату документа";
			this.checkBox_0.UseVisualStyleBackColor = true;
			this.checkBox_0.CheckedChanged += this.checkBox_0_CheckedChanged;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(771, 354);
			base.Controls.Add(this.reportViewer_0);
			base.Controls.Add(this.panel_0);
			base.Name = "FormReportActElectricalInspection";
			this.Text = "Акт осмотра электроустановок";
			base.Load += this.FormReportActElectricalInspection_Load;
			((ISupportInitialize)this.Rygoffcowh5).EndInit();
			((ISupportInitialize)this.class10_0).EndInit();
			((ISupportInitialize)this.bindingSource_0).EndInit();
			this.panel_0.ResumeLayout(false);
			this.panel_0.PerformLayout();
			base.ResumeLayout(false);
		}

		private int int_0;

		private int int_1;

		private DateTime dateTime_0;

		private Class10 class10_0;

		private ReportViewer reportViewer_0;

		private BindingSource Rygoffcowh5;

		private BindingSource bindingSource_0;

		private Panel panel_0;

		private CheckBox checkBox_0;
	}
}
