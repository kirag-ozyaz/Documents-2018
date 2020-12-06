using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using System.Xml;
using ControlsLbr;
using ControlsLbr.DataGridViewExcelFilter;
using DataSql;
using FormLbr;
using FormLbr.Classes;
using RequestsClient.Properties;
using RequestsClient.RequestService;
using SchemeModel;
using SchemeModel.Calculations;
/// <summary>
/// Документ аварийные заявки и на ремонт оборудования
/// Производственная лаборатория
/// </summary>
namespace RequestsClient.Forms.JournalRequestForRepair
{
	public partial class FormJournalRequestForRepairAddEdit : FormBase
	{
		private bool method_0()
		{
			return this.bool_0;
		}

		private void method_1(bool value)
		{
			this.bool_0 = value;
			this.method_28();
		}

		public FormJournalRequestForRepairAddEdit()
		{
			Class38.TqlX7ZmzmDDi2();
			this.int_0 = -1;
			this.int_1 = -1;
			this.eActionRequestRepair = eActionRequestRepair.Read;
			this.dateTime_0 = new DateTime(1900, 1, 1);
			this.dateTime_1 = new DateTime(9000, 1, 1);
			this.int_2 = -1;
			this.dictionary_0 = new Dictionary<int, string>();
			this.int_3 = -1;
			this.list_0 = new List<int>();
			//
			this.InitializeComponent();
			this.method_2();
		}

		public FormJournalRequestForRepairAddEdit(int idRequest, int idDivision, eActionRequestRepair action, bool isCrash = false)
		{
			Class38.TqlX7ZmzmDDi2();
			this.int_0 = -1;
			this.int_1 = -1;
			this.eActionRequestRepair = eActionRequestRepair.Read;
			this.dateTime_0 = new DateTime(1900, 1, 1);
			this.dateTime_1 = new DateTime(9000, 1, 1);
			this.int_2 = -1;
			this.dictionary_0 = new Dictionary<int, string>();
			this.int_3 = -1;
			this.list_0 = new List<int>();
			
			this.InitializeComponent();
			this.method_2();
			this.int_0 = idRequest;
			this.int_1 = idDivision;
			this.eActionRequestRepair = action;
			this.method_1(isCrash);
		}

		public FormJournalRequestForRepairAddEdit(DataRow copy)
		{
			Class38.TqlX7ZmzmDDi2();
			this.int_0 = -1;
			this.int_1 = -1;
			this.eActionRequestRepair = eActionRequestRepair.Read;
			this.dateTime_0 = new DateTime(1900, 1, 1);
			this.dateTime_1 = new DateTime(9000, 1, 1);
			this.int_2 = -1;
			this.dictionary_0 = new Dictionary<int, string>();
			this.int_3 = -1;
			this.list_0 = new List<int>();
			
			this.InitializeComponent();
			this.method_2();
			this.int_0 = -1;
			this.int_1 = Convert.ToInt32(copy["idDivision"]);
			this.eActionRequestRepair = eActionRequestRepair.Add;
			this.dataRow_0 = copy;
		}

		private void method_2()
		{
			this.cmbIsPlanned.DataBindings.Clear();
			this.cmbIsPlanned.DataBindings.Add(new Binding("SelectedValue", this.dataSetN, "tJ_RequestForRepair.IsPlanned", true, DataSourceUpdateMode.OnPropertyChanged));
			this.cmbTypeDisable.DataBindings.Clear();
			this.cmbTypeDisable.DataBindings.Add(new Binding("SelectedValue", this.dataSetN, "tJ_RequestForRepair.typeDisable", true, DataSourceUpdateMode.OnPropertyChanged));
			this.cmbSR.DataBindings.Clear();
			this.cmbSR.DataBindings.Add(new Binding("SelectedValue", this.dataSetN, "tJ_RequestForRepair.idSR", true, DataSourceUpdateMode.OnPropertyChanged));
			this.cmbRegion.DataBindings.Clear();
			this.cmbRegion.DataBindings.Add(new Binding("SelectedValue", this.dataSetN, "tJ_RequestForRepair.idRegion", true, DataSourceUpdateMode.OnPropertyChanged));
			this.dateTimePickerDateAgreed.DataBindings.Clear();
			this.dateTimePickerDateAgreed.DataBindings.Add(new Binding("Value", this.dataSetN, "tJ_RequestForRepair.DateAgreed", true, DataSourceUpdateMode.OnPropertyChanged));
			this.dateTimePickerFactEnd.DataBindings.Clear();
			this.dateTimePickerFactEnd.DataBindings.Add(new Binding("Value", this.dataSetN, "tJ_RequestForRepair.DateFactEnd", true, DataSourceUpdateMode.OnPropertyChanged));
			this.cmbStatus.DataBindings.Clear();
			this.cmbStatus.DataBindings.Add(new Binding("SelectedValue", this.dataSetN, "tJ_RequestForRepair.status", true, DataSourceUpdateMode.OnPropertyChanged));
			this.txtAdress.DataBindings.Clear();
			this.txtAdress.DataBindings.Add(new Binding("Text", this.dataSetN, "tJ_RequestForRepair.Address", true, DataSourceUpdateMode.OnPropertyChanged));
		}

		private void method_3()
		{
			using (SqlConnection sqlConnection = new SqlConnection(this.SqlSettings.GetConnectionString()))
			{
				try
				{
					sqlConnection.Open();
					DbDataAdapter dbDataAdapter = new SqlDataAdapter("select [Settings] from tSettings where module = 'FTP05'", sqlConnection);
					DataTable dataTable = new DataTable();
					dbDataAdapter.Fill(dataTable);
					if (dataTable.Rows.Count > 0 && dataTable.Rows[0]["Settings"] != DBNull.Value)
					{
						XmlDocument xmlDocument = new XmlDocument();
						xmlDocument.LoadXml(dataTable.Rows[0]["Settings"].ToString());
						XmlNode xmlNode = xmlDocument.SelectSingleNode("ReqForRepairFTP");
						if (xmlNode != null)
						{
							XmlNode xmlNode2 = xmlNode.SelectSingleNode("RIC");
							if (xmlNode2 != null)
							{
								XmlAttribute xmlAttribute = xmlNode2.Attributes["SendRIC"];
								if (xmlAttribute != null)
								{
									this.isSendRIC = Convert.ToBoolean(xmlAttribute.Value);
								}
							}
						}
					}
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message, ex.InnerException);
				}
			}
		}

		private void method_4()
		{
			try
			{
				this.dataTable_0 = new DataTable("tR_RequestForRepairClient");
				base.SelectSqlData(this.dataTable_0, true, "where type = 2 order by name", null, false, 0);

                DataTable dataTable = new DataTable("tR_RequestForRepairClient");
				dataTable.Columns.Add("name", typeof(string));
				dataTable.Columns.Add("value", typeof(int));

                this.cmbRegion.DataSource = dataTable;
				this.cmbRegion.DisplayMember = "Name";
				this.cmbRegion.ValueMember = "Value";
				if (this.isSendRIC)
				{
					try
					{
#pragma warning disable CS0618 // Тип или член устарел
                        ServicePointManager.CertificatePolicy = new Class1();
#pragma warning restore CS0618 // Тип или член устарел
                        foreach (DICTIONARY dictionary in new RequestsServiceSoapClient
						{
							InnerChannel = 
							{
								OperationTimeout = new TimeSpan(0, 0, 5)
							}
						}.GetDictTypeRegion())
						{
							dataTable.Rows.Add(new object[]
							{
								dictionary.Name,
								dictionary.Value
							});
						}
                        return;
					}
					catch (Exception)
					{
						this.cmbRegion.ForeColor = Color.Red;
						if (dataTable.Rows.Count == 0)
						{
							foreach (DataRow dataRow in this.dataTable_0.Rows)
							{
								dataTable.Rows.Add(new object[]
								{
									dataRow["name"],
									dataRow["Value"]
								});
							}
						}
						return;
					}
				}
				if (dataTable.Rows.Count == 0)
				{
					foreach (DataRow dataRow2 in this.dataTable_0.Rows)
					{
						dataTable.Rows.Add(new object[]
						{
							dataRow2["name"],
							dataRow2["Value"]
						});
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void cmbSR_SelectedValueChanged(object sender, EventArgs e)
		{
			if (this.cmbSR.SelectedValue != null)
			{
				if (this.cmbSR.SelectedValue != DBNull.Value)
				{
					if (this.dataTable_0 != null)
					{
						DataRow[] array = this.dataTable_0.Select("GESid = " + this.cmbSR.SelectedValue.ToString());
						if (array.Length != 0 && array[0]["Value"] != DBNull.Value)
						{
							this.cmbRegion.SelectedValue = array[0]["Value"];
						}
					}
					return;
				}
			}
			this.cmbRegion.SelectedIndex = -1;
		}

		private void cmbRegion_SelectedValueChanged(object sender, EventArgs e)
		{
			if (this.cmbRegion.SelectedValue != null)
			{
				if (this.cmbRegion.SelectedValue != DBNull.Value)
				{
					if (this.dataTable_0 != null)
					{
						DataRow[] array = this.dataTable_0.Select("Value = " + this.cmbRegion.SelectedValue.ToString());
						if (array.Length != 0 && array[0]["GesId"] != DBNull.Value)
						{
							this.cmbSR.SelectedValue = array[0]["GESId"];
						}
					}
					return;
				}
			}
			this.cmbSR.SelectedIndex = -1;
		}

		private void method_5()
		{
			this.dataTable_1 = new DataTable("tR_RequestForRepairClient");
			base.SelectSqlData(this.dataTable_1, true, "where type = 1 order by name", null, false, 0);
			DataTable dataTable = new DataTable("tR_RequestForRepairClient");
			dataTable.Columns.Add("name", typeof(string));
			dataTable.Columns.Add("value", typeof(int));
			this.cmbTypeDisable.DataSource = dataTable;
			this.cmbTypeDisable.DisplayMember = "Name";
			this.cmbTypeDisable.ValueMember = "Value";
			if (this.isSendRIC)
			{
				try
				{
#pragma warning disable CS0618 // Тип или член устарел
                    ServicePointManager.CertificatePolicy = new Class1();
#pragma warning restore CS0618 // Тип или член устарел
                    foreach (DICTIONARY dictionary in new RequestsServiceSoapClient
					{
						InnerChannel = 
						{
							OperationTimeout = new TimeSpan(0, 0, 5)
						}
					}.GetDictTypeDisable())
					{
						dataTable.Rows.Add(new object[]
						{
							dictionary.Name,
							dictionary.Value
						});
					}
					return;
				}
				catch (Exception)
				{
					this.cmbTypeDisable.ForeColor = Color.Red;
					if (dataTable.Rows.Count == 0)
					{
						foreach (object obj in this.dataTable_1.Rows)
						{
							DataRow dataRow = (DataRow)obj;
							dataTable.Rows.Add(new object[]
							{
								dataRow["name"],
								dataRow["Value"]
							});
						}
					}
					return;
				}
			}
			if (dataTable.Rows.Count == 0)
			{
				foreach (object obj2 in this.dataTable_1.Rows)
				{
					DataRow dataRow2 = (DataRow)obj2;
					dataTable.Rows.Add(new object[]
					{
						dataRow2["name"],
						dataRow2["Value"]
					});
				}
			}
		}

		private void cmbTypeDisable_SelectedValueChanged(object sender, EventArgs e)
		{
			if (this.cmbTypeDisable.SelectedValue != null)
			{
				if (this.cmbTypeDisable.SelectedValue != DBNull.Value)
				{
					if (this.dataTable_1 != null)
					{
						DataRow[] array = this.dataTable_1.Select("Value = " + this.cmbTypeDisable.SelectedValue.ToString());
						if (array.Length != 0 && array[0]["GesId"] != DBNull.Value)
						{
							this.cmbIsPlanned.SelectedValue = Convert.ToBoolean(array[0]["GesId"]);
						}
					}
					return;
				}
			}
			this.cmbIsPlanned.SelectedIndex = -1;
		}

		private void cmbIsPlanned_SelectedValueChanged(object sender, EventArgs e)
		{
			if (this.cmbIsPlanned.SelectedValue != null)
			{
				if (this.cmbIsPlanned.SelectedValue != DBNull.Value)
				{
					if (this.dataTable_1 != null)
					{
						DataRow[] array = this.dataTable_1.Select("GesId = " + Convert.ToInt32(this.cmbIsPlanned.SelectedValue).ToString());
						if (array.Length != 0 && array[0]["Value"] != DBNull.Value)
						{
							this.cmbTypeDisable.SelectedValue = array[0]["Value"];
						}
					}
					return;
				}
			}
			this.cmbTypeDisable.SelectedIndex = -1;
		}

		private void method_6()
		{
			this.dataTable_2 = new DataTable("tR_RequestForRepairClient");
			base.SelectSqlData(this.dataTable_2, true, "where type = 3 order by name", null, false, 0);
			DataTable dataTable = new DataTable("tR_RequestForRepairClient");
			dataTable.Columns.Add("name", typeof(string));
			dataTable.Columns.Add("value", typeof(int));
			this.cmbOrganization.DataSource = dataTable;
			this.cmbOrganization.DisplayMember = "Name";
			this.cmbOrganization.ValueMember = "Value";
			DataTable dataTable2 = new DataTable("tR_RequestForRepairClient");
			dataTable2.Columns.Add("name", typeof(string));
			dataTable2.Columns.Add("value", typeof(int));
			this.cmbPerformerOrganization.DataSource = dataTable2;
			this.cmbPerformerOrganization.DisplayMember = "Name";
			this.cmbPerformerOrganization.ValueMember = "Value";
			if (this.isSendRIC)
			{
				try
				{
#pragma warning disable CS0618 // Тип или член устарел
                    ServicePointManager.CertificatePolicy = new Class1();
#pragma warning restore CS0618 // Тип или член устарел
                    foreach (DICTIONARY dictionary in new RequestsServiceSoapClient
					{
						InnerChannel = 
						{
							OperationTimeout = new TimeSpan(0, 0, 5)
						}
					}.GetDictTypeOrganization())
					{
						dataTable.Rows.Add(new object[]
						{
							dictionary.Name,
							dictionary.Value
						});
						dataTable2.Rows.Add(new object[]
						{
							dictionary.Name,
							dictionary.Value
						});
					}
					return;
				}
				catch (Exception)
				{
					this.cmbOrganization.ForeColor = Color.Red;
					this.cmbPerformerOrganization.ForeColor = Color.Red;
					if (dataTable.Rows.Count == 0)
					{
						foreach (object obj in this.dataTable_2.Rows)
						{
							DataRow dataRow = (DataRow)obj;
							dataTable.Rows.Add(new object[]
							{
								dataRow["name"],
								dataRow["Value"]
							});
							dataTable2.Rows.Add(new object[]
							{
								dataRow["name"],
								dataRow["Value"]
							});
						}
					}
					return;
				}
			}
			if (dataTable.Rows.Count == 0)
			{
				foreach (object obj2 in this.dataTable_2.Rows)
				{
					DataRow dataRow2 = (DataRow)obj2;
					dataTable.Rows.Add(new object[]
					{
						dataRow2["name"],
						dataRow2["Value"]
					});
					dataTable2.Rows.Add(new object[]
					{
						dataRow2["name"],
						dataRow2["Value"]
					});
				}
			}
		}

		private void method_7()
		{
			this.dataTable_3 = new DataTable("tR_RequestForRepairClient");
			base.SelectSqlData(this.dataTable_3, true, "where type = 4 order by name", null, false, 0);
			DataTable dataTable = new DataTable("tR_RequestForRepairClient");
			dataTable.Columns.Add("name", typeof(string));
			dataTable.Columns.Add("value", typeof(int));
			this.cmbGroupWorks.DataSource = dataTable;
			this.cmbGroupWorks.DisplayMember = "Name";
			this.cmbGroupWorks.ValueMember = "Value";
			if (this.isSendRIC)
			{
				try
				{
#pragma warning disable CS0618 // Тип или член устарел
                    ServicePointManager.CertificatePolicy = new Class1();
#pragma warning restore CS0618 // Тип или член устарел
                    foreach (DICTIONARY dictionary in new RequestsServiceSoapClient
					{
						InnerChannel = 
						{
							OperationTimeout = new TimeSpan(0, 0, 5)
						}
					}.GetDictGroupWorks())
					{
						dataTable.Rows.Add(new object[]
						{
							dictionary.Name,
							dictionary.Value
						});
					}
					return;
				}
				catch (Exception)
				{
					this.cmbGroupWorks.ForeColor = Color.Red;
					if (dataTable.Rows.Count == 0)
					{
						foreach (object obj in this.dataTable_3.Rows)
						{
							DataRow dataRow = (DataRow)obj;
							dataTable.Rows.Add(new object[]
							{
								dataRow["name"],
								dataRow["Value"]
							});
						}
					}
					return;
				}
			}
			if (dataTable.Rows.Count == 0)
			{
				foreach (object obj2 in this.dataTable_3.Rows)
				{
					DataRow dataRow2 = (DataRow)obj2;
					dataTable.Rows.Add(new object[]
					{
						dataRow2["name"],
						dataRow2["Value"]
					});
				}
			}
		}

		private void method_8()
		{
			this.dataTable_4 = new DataTable("tR_RequestForRepairClient");
			base.SelectSqlData(this.dataTable_4, true, "where type = 5 order by name", null, false, 0);
			DataTable dataTable = new DataTable("tR_RequestForRepairClient");
			dataTable.Columns.Add("name", typeof(string));
			dataTable.Columns.Add("value", typeof(int));
			this.cmbStatus.DataSource = dataTable;
			this.cmbStatus.DisplayMember = "Name";
			this.cmbStatus.ValueMember = "Value";
			if (this.isSendRIC)
			{
				try
				{
#pragma warning disable CS0618 // Тип или член устарел
                    ServicePointManager.CertificatePolicy = new Class1();
#pragma warning restore CS0618 // Тип или член устарел
                    foreach (DICTIONARY dictionary in new RequestsServiceSoapClient
					{
						InnerChannel = 
						{
							OperationTimeout = new TimeSpan(0, 0, 5)
						}
					}.GetDictStatus())
					{
						dataTable.Rows.Add(new object[]
						{
							dictionary.Name,
							dictionary.Value
						});
					}
					return;
				}
				catch (Exception)
				{
					this.cmbStatus.ForeColor = Color.Red;
					if (dataTable.Rows.Count == 0)
					{
						foreach (object obj in this.dataTable_4.Rows)
						{
							DataRow dataRow = (DataRow)obj;
							dataTable.Rows.Add(new object[]
							{
								dataRow["name"],
								dataRow["Value"]
							});
						}
					}
					return;
				}
			}
			if (dataTable.Rows.Count == 0)
			{
				foreach (object obj2 in this.dataTable_4.Rows)
				{
					DataRow dataRow2 = (DataRow)obj2;
					dataTable.Rows.Add(new object[]
					{
						dataRow2["name"],
						dataRow2["Value"]
					});
				}
			}
		}

		private void FormJournalRequestForRepairAddEdit_Load(object sender, EventArgs e)
		{
			this.method_3();
			this.method_43();
			WebRequest.DefaultWebProxy.Credentials = CredentialCache.DefaultNetworkCredentials;
			this.txtAdress.ReadOnly = false;
			this.dateTimePickerBeg.Value = DateTime.Now.Date.AddHours(8.0);
			this.dateTimePickerEnd.Value = DateTime.Now.Date.AddHours(17.0);
			this.method_14();
			this.method_4();
			this.method_5();
			this.method_6();
			this.method_7();
			this.method_8();
			base.LoadFormConfig(null);
			switch (this.eActionRequestRepair)
			{
			case eActionRequestRepair.Add:
				if (this.dataRow_0 != null)
				{
					DataRow dataRow = this.dataSetN.tJ_RequestForRepair.NewRow();
					dataRow["num"] = 0;
					dataRow["dateCreate"] = DateTime.Now;
					this.method_10(DateTime.Now);
					dataRow["idWorker"] = this.dataRow_0["idWorker"];
					dataRow["reguestFiled"] = this.dataRow_0["reguestFiled"];
					dataRow["idSR"] = this.dataRow_0["idSR"];
					if (this.dataTable_0 != null)
					{
						DataRow[] array = this.dataTable_0.Select("GESid = " + this.dataRow_0["idSR"].ToString());
						if (array.Length != 0 && array[0]["Value"] != DBNull.Value)
						{
							dataRow["idRegion"] = array[0]["Value"];
						}
					}
					dataRow["schmObj"] = this.dataRow_0["schmObj"];
					dataRow["Purpose"] = this.dataRow_0["Purpose"];
					dataRow["IsPlanned"] = this.dataRow_0["IsPlanned"];
					dataRow["crash"] = this.dataRow_0["crash"];
					if (this.dataTable_1 != null)
					{
						DataRow[] array2 = this.dataTable_1.Select("GesId = " + Convert.ToInt32(this.dataRow_0["IsPlanned"]).ToString());
						if (array2.Length != 0 && array2[0]["Value"] != DBNull.Value)
						{
							dataRow["typeDisable"] = array2[0]["Value"];
						}
					}
					dataRow["agreed"] = false;
					dataRow["iddivision"] = this.dataRow_0["iddivision"];
					dataRow["deleted"] = false;
					if (this.bool_0)
					{
						dataRow["SendSite"] = true;
					}
					else
					{
						dataRow["SendSite"] = false;
					}
					if (this.dataTable_2 != null)
					{
						DataRow[] array3 = this.dataTable_2.Select("isDefault = true");
						if (array3.Length != 0)
						{
							dataRow["Organization"] = array3[0]["Value"];
							dataRow["performerOrganization"] = array3[0]["Value"];
						}
					}
					if (this.dataTable_3 != null)
					{
						DataRow[] array4 = this.dataTable_3.Select("isDefault = true");
						if (array4.Length != 0)
						{
							dataRow["groupWorks"] = array4[0]["Value"];
						}
					}
					DataTable dataTable = this.method_13();
					base.SelectSqlData(dataTable, true, " where [Login] = SYSTEM_USER ", null, false, 0);
					if (dataTable.Rows.Count > 0)
					{
						dataRow["idUserCreate"] = dataTable.Rows[0]["iduser"];
						if (dataTable.Rows[0]["idWorker"] != DBNull.Value)
						{
							dataRow["IdWorker"] = dataTable.Rows[0]["idWorker"];
						}
					}
					this.dataSetN.tJ_RequestForRepair.Rows.Add(dataRow);
				}
				else
				{
					DataRow dataRow2 = this.dataSetN.tJ_RequestForRepair.NewRow();
					dataRow2["num"] = 0;
					dataRow2["dateCreate"] = DateTime.Now;
					this.method_10(DateTime.Now);
					dataRow2["idWorker"] = -1;
					dataRow2["reguestFiled"] = "";
					dataRow2["idSR"] = this.int_3;
					dataRow2["schmObj"] = "";
					dataRow2["Purpose"] = "";
					dataRow2["crash"] = this.method_0();
					if (this.method_0())
					{
						dataRow2["IsPlanned"] = false;
					}
					else
					{
						dataRow2["IsPlanned"] = true;
					}
					dataRow2["agreed"] = false;
					dataRow2["iddivision"] = this.int_1;
					dataRow2["deleted"] = false;
					if (this.bool_0)
					{
						dataRow2["SendSite"] = true;
					}
					else
					{
						dataRow2["SendSite"] = false;
					}
					if (this.dataTable_2 != null)
					{
						DataRow[] array5 = this.dataTable_2.Select("isDefault = true");
						if (array5.Length != 0)
						{
							dataRow2["Organization"] = array5[0]["Value"];
							dataRow2["performerOrganization"] = array5[0]["Value"];
						}
					}
					if (this.dataTable_3 != null)
					{
						DataRow[] array6 = this.dataTable_3.Select("isDefault = true");
						if (array6.Length != 0)
						{
							dataRow2["groupWorks"] = array6[0]["Value"];
						}
					}
					DataTable dataTable2 = this.method_13();
					base.SelectSqlData(dataTable2, true, " where [Login] = SYSTEM_USER ", null, false, 0);
					if (dataTable2.Rows.Count > 0)
					{
						dataRow2["idUserCreate"] = dataTable2.Rows[0]["iduser"];
						if (dataTable2.Rows[0]["idWorker"] != DBNull.Value)
						{
							dataRow2["IdWorker"] = dataTable2.Rows[0]["idWorker"];
						}
					}
					this.dataSetN.tJ_RequestForRepair.Rows.Add(dataRow2);
					if (this.method_0())
					{
						this.cmbIsPlanned.SelectedIndex = 0;
					}
					else
					{
						this.cmbIsPlanned.SelectedIndex = 1;
					}
					if (this.cmbWorker.SelectedItem != null)
					{
						dataRow2["reguestFiled"] = this.cmbWorker.Text;
					}
				}
				break;
			case eActionRequestRepair.Edit:
				if (this.int_0 > 0)
				{
					base.SelectSqlData(this.dataSetN, this.dataSetN.tJ_RequestForRepair, true, " where id = " + this.int_0.ToString());
					if (this.dataSetN.tJ_RequestForRepair.Rows.Count > 0 && this.dataSetN.tJ_RequestForRepair.Rows[0]["DateCreate"] != DBNull.Value)
					{
						this.method_10(Convert.ToDateTime(this.dataSetN.tJ_RequestForRepair.Rows[0]["DateCreate"]));
					}
					base.SelectSqlData(this.dataSetN, this.dataSetN.tJ_RequestForRepairDaily, true, " where idRequest = " + this.int_0.ToString());
					base.SelectSqlData(this.dataSetN, this.dataSetN.tJ_RequestForRepairDoc, true, " where idRequest = " + this.int_0.ToString());
					base.SelectSqlData(this.dataSetN, this.dataSetN.tJ_RequestForRepairAddress, true, " where idRequest = " + this.int_0.ToString());
					this.method_22();
					this.method_26();
				}
				break;
			case eActionRequestRepair.Read:
				if (this.int_0 > 0)
				{
					base.SelectSqlData(this.dataSetN, this.dataSetN.tJ_RequestForRepair, true, " where id = " + this.int_0.ToString());
					base.SelectSqlData(this.dataSetN, this.dataSetN.tJ_RequestForRepairDaily, true, " where idRequest = " + this.int_0.ToString());
					base.SelectSqlData(this.dataSetN, this.dataSetN.tJ_RequestForRepairDoc, true, " where idRequest = " + this.int_0.ToString());
					base.SelectSqlData(this.dataSetN, this.dataSetN.tJ_RequestForRepairAddress, true, " where idRequest = " + this.int_0.ToString());
					this.method_22();
					this.method_26();
				}
				this.method_9();
				break;
			}
			if (this.dataSetN.tJ_RequestForRepair.Rows.Count > 0)
			{
				if (this.eActionRequestRepair == eActionRequestRepair.Edit && this.dataSetN.tJ_RequestForRepair.Rows[0]["Status"] != DBNull.Value)
				{
					this.int_2 = Convert.ToInt32(this.dataSetN.tJ_RequestForRepair.Rows[0]["Status"]);
				}
				if (this.dataSetN.tJ_RequestForRepair.Rows[0]["Agreed"] != DBNull.Value)
				{
					this.bool_1 = Convert.ToBoolean(this.dataSetN.tJ_RequestForRepair.Rows[0]["Agreed"]);
				}
				if (this.int_1 <= 0)
				{
					this.int_1 = Convert.ToInt32(this.dataSetN.tJ_RequestForRepair.Rows[0]["IdDivision"]);
				}
				if (this.dataSetN.tJ_RequestForRepair.Rows[0]["Crash"] != DBNull.Value && Convert.ToBoolean(this.dataSetN.tJ_RequestForRepair.Rows[0]["Crash"]))
				{
					this.cmbIsPlanned.Enabled = false;
					this.cmbTypeDisable.Enabled = false;
					this.method_1(true);
				}
			}
			if (!this.method_0())
			{
				this.cmbTypeDamage.Visible = false;
			}
			else
			{
				this.method_30();
				this.method_31();
			}
			this.method_11();
			if (this.int_1 == 921)
			{
				this.groupBox_0.Visible = false;
			}
			this.method_28();
			this.method_44();
		}

		private void FormJournalRequestForRepairAddEdit_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (base.DialogResult == DialogResult.OK)
			{
				if (this.eActionRequestRepair != eActionRequestRepair.Read && !this.method_15())
				{
					MessageBox.Show("Не введены обязательные поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					e.Cancel = true;
					return;
				}
				//eActionRequestRepair eActionRequestRepair = this.eActionRequestRepair;
				if (eActionRequestRepair != eActionRequestRepair.Add)
				{
					if (eActionRequestRepair == eActionRequestRepair.Edit)
					{
						this.dataSetN.tJ_RequestForRepair.Rows[0].EndEdit();
						base.UpdateSqlData(this.dataSetN, this.dataSetN.tJ_RequestForRepair);
					}
				}
				else
				{
					this.dataSetN.tJ_RequestForRepair.Rows[0].EndEdit();
					this.int_0 = base.InsertSqlDataOneRow(this.dataSetN, this.dataSetN.tJ_RequestForRepair);
				}
				foreach (DataRow dataRow in this.dataSetN.tJ_RequestForRepairDaily)
				{
					if (dataRow.RowState != DataRowState.Detached && dataRow.RowState != DataRowState.Deleted)
					{
						if (Convert.ToInt32(dataRow["idrequest"]) != this.int_0)
						{
							dataRow["idRequest"] = this.int_0;
						}
						dataRow.EndEdit();
					}
				}
				base.InsertSqlData(this.dataSetN, this.dataSetN.tJ_RequestForRepairDaily);
				base.UpdateSqlData(this.dataSetN, this.dataSetN.tJ_RequestForRepairDaily);
				base.DeleteSqlData(this.dataSetN, this.dataSetN.tJ_RequestForRepairDaily);
				this.method_23();
				this.method_24();
				this.method_27();
				this.method_45();
				this.method_16();
				this.method_29();
				this.method_32();
			}
		}

		private void FormJournalRequestForRepairAddEdit_FormClosed(object sender, FormClosedEventArgs e)
		{
			base.SaveFormConfig(null);
		}

		private void method_9()
		{
			this.cmbWorker.Enabled = false;
			this.txtRequestFiled.Enabled = false;
			this.cmbSR.Enabled = false;
			this.txtObject.ReadOnly = true;
			this.txtPurpose.ReadOnly = true;
			this.cmbIsPlanned.Enabled = false;
			this.groupBoxDaily.Enabled = false;
			this.txtAgreeWith.ReadOnly = true;
			this.txtComment.ReadOnly = true;
			this.txtAdress.ReadOnly = true;
			this.rWoeDxUpjP.Enabled = false;
			this.dateTimePickerDateAgreed.Enabled = false;
			this.cmbDispatcher.Enabled = false;
			this.cmbTypeDamage.Enabled = false;
			Control control = this.cmbOrganization;
			Control control2 = this.cmbPerformerOrganization;
			this.cmbGroupWorks.Enabled = false;
			control2.Enabled = false;
			control.Enabled = false;
			this.cmbStatus.Enabled = false;
			this.method_28();
			Control control3 = this.toolStripScheme;
			this.toolStripAddress.Enabled = false;
			control3.Enabled = false;
			this.toolStripDocuments.Enabled = false;
			this.toolBtnCopy.Enabled = false;
			this.buttonOK.Visible = false;
		}

		private void method_10(DateTime dateTime_2)
		{
			this.dateTime_0 = dateTime_2.AddDays(-1.0).Date;
			this.dateTimePickerBeg.MinDate = this.dateTime_0;
			this.dateTimePickerFactEnd.MinDate = this.dateTime_0;
			this.dateTimePickerDateAgreed.MinDate = this.dateTime_0;
		}

		private void groupBox_0_VisibleChanged(object sender, EventArgs e)
		{
		}

		private void method_11()
		{
			string str = "";
			if (this.int_1 > 0)
			{
				DataTable dataTable = new DataTable("tR_Classifier");
				dataTable.Columns.Add("SocrName", typeof(string));
				base.SelectSqlData(dataTable, true, "where id = " + this.int_1.ToString(), null, false, 0);
				if (dataTable.Rows.Count > 0)
				{
					str = " " + dataTable.Rows[0]["SocrName"].ToString();
				}
			}
			switch (this.eActionRequestRepair)
			{
			case eActionRequestRepair.Add:
				if (this.method_0())
				{
					this.Text = "Создать новую аварийную заявку" + str;
					return;
				}
				this.Text = "Создать новую заявку" + str;
				return;
			case eActionRequestRepair.Edit:
				if (this.method_0())
				{
					this.Text = "Редактирование аварийной заявки" + str;
					return;
				}
				this.Text = "Редактирование заявки" + str;
				return;
			case eActionRequestRepair.Read:
				if (this.method_0())
				{
					this.Text = "Просмотр аварийной заявки" + str;
					return;
				}
				this.Text = "Просмотр заявки" + str;
				return;
			default:
				return;
			}
		}

		private DataTable method_12()
		{
			Type type = Type.GetType("System.Int32");
			DataTable dataTable = new DataTable("vWorkerGroup");
			DataColumn dataColumn = new DataColumn("id", type);
			dataTable.Columns.Add(dataColumn);
			DataColumn column = new DataColumn("fio", Type.GetType("System.String"));
			dataTable.Columns.Add(column);
			DataColumn column2 = new DataColumn("GroupElectrical", type);
			dataTable.Columns.Add(column2);
			dataTable.PrimaryKey = new DataColumn[]
			{
				dataColumn
			};
			DataColumn dataColumn2 = new DataColumn("GroupRoman", Type.GetType("System.String"));
			dataColumn2.Expression = "IIF(groupElectrical = 1, 'I', IIF(groupElectrical = 2, 'II', IIF(groupelectrical=3, 'III', IIF(groupelectrical = 4, 'IV', iif(groupelectrical = 5, 'V', '')))))";
			dataTable.Columns.Add(dataColumn2);
			return dataTable;
		}

		private DataTable method_13()
		{
			Type type = Type.GetType("System.Int32");
			DataTable dataTable = new DataTable("tUser");
			DataColumn dataColumn = new DataColumn("idUser", type);
			dataTable.Columns.Add(dataColumn);
			DataColumn column = new DataColumn("idWorker", type);
			dataTable.Columns.Add(column);
			DataColumn column2 = new DataColumn("name", Type.GetType("System.String"));
			dataTable.Columns.Add(column2);
			dataTable.PrimaryKey = new DataColumn[]
			{
				dataColumn
			};
			return dataTable;
		}

		private void method_14()
		{
			DataTable dataTable = this.method_13();
			base.SelectSqlData(dataTable, true, " order by name ", null, false, 0);
			this.cmbUserCreate.DataSource = dataTable;
			this.cmbUserCreate.DisplayMember = "NAME";
			this.cmbUserCreate.ValueMember = "IDUSER";
			DataTable dataTable2 = this.method_12();
			base.SelectSqlData(dataTable2, true, " where ParentKey in (';GroupWorker;ITR;')  and dateend is null group by id, fio, groupelectrical order by fio ", null, false, 0);
			this.cmbWorker.DataSource = dataTable2;
			this.cmbWorker.DisplayMember = "FIO";
			this.cmbWorker.ValueMember = "ID";
			this.txtRequestFiled.DataSource = dataTable2;
			this.txtRequestFiled.DisplayMember = "FIO";
			this.txtRequestFiled.ValueMember = "ID";
			DataTable dataTable3 = this.method_12();
			base.SelectSqlData(dataTable3, true, " where ParentKey in (';GroupWorker;ReconcileRequestRepair;')  and dateend is null group by id, fio, groupelectrical order by fio ", null, false, 0);
			this.cmbDispatcher.DataSource = dataTable3;
			this.cmbDispatcher.DisplayMember = "FIO";
			this.cmbDispatcher.ValueMember = "ID";
			base.SelectSqlData(this.dataSetN, this.dataSetN.tR_Classifier, true, " where ParentKey = ';NetworkAreas;' and deleted = 0 and isGroup = 0 order by name ");
			this.cmbSR.DataSource = this.dataSetN.tR_Classifier;
			this.cmbSR.DisplayMember = "name";
			this.cmbSR.ValueMember = "ID";
			this.cmbSR.SelectedIndex = -1;
			DataTable dataTable4 = new DataTable();
			dataTable4.Columns.Add("name", typeof(string));
			dataTable4.Columns.Add("value", typeof(bool));
			this.cmbIsPlanned.DataSource = dataTable4;
			this.cmbIsPlanned.DisplayMember = "name";
			this.cmbIsPlanned.ValueMember = "value";
			if (this.method_0())
			{
				dataTable4.Rows.Add(new object[]
				{
					"Аварийный",
					false
				});
			}
			else
			{
				dataTable4.Rows.Add(new object[]
				{
					"Срочный",
					false
				});
			}
			dataTable4.Rows.Add(new object[]
			{
				"Плановый",
				true
			});
			DataTable dataTable5 = new DataTable("tR_Classifier");
			dataTable5.Columns.Add("id", typeof(int));
			dataTable5.Columns.Add("name", typeof(string));
			base.SelectSqlData(dataTable5, true, string.Format(" where id in ({0}, {1})", 1402, 1401), null, false, 0);
			this.cmbTypeDamage.DisplayMember = "name";
			this.cmbTypeDamage.ValueMember = "id";
			this.cmbTypeDamage.DataSource = dataTable5;
			this.cmbTypeDamage.SelectedIndex = -1;
		}

		private bool method_15()
		{
			bool result = true;
			if (string.IsNullOrEmpty(this.txtRequestFiled.Text))
			{
				this.labelRequestFiled.ForeColor = Color.Red;
				result = false;
			}
			if (this.cmbSR.SelectedIndex < 0)
			{
				this.labelSR.ForeColor = Color.Red;
				result = false;
			}
			if (string.IsNullOrEmpty(this.txtObject.Text))
			{
				this.labelObject.ForeColor = Color.Red;
				result = false;
			}
			if (string.IsNullOrEmpty(this.txtPurpose.Text))
			{
				this.labelPurpose.ForeColor = Color.Red;
				result = false;
			}
			if (this.cmbIsPlanned.SelectedIndex < 0)
			{
				this.labelIsPlanned.ForeColor = Color.Red;
				result = false;
			}
			if (this.dataSetN.tJ_RequestForRepairDaily.Rows.Count <= 0)
			{
				List<Color> list = new List<Color>();
				foreach (object obj in this.groupBoxDaily.Controls)
				{
					Control control = (Control)obj;
					list.Add(control.ForeColor);
				}
				this.groupBoxDaily.ForeColor = Color.Red;
				int num = 0;
				foreach (object obj2 in this.groupBoxDaily.Controls)
				{
					((Control)obj2).ForeColor = list[num];
					num++;
				}
				result = false;
			}
			if (this.rWoeDxUpjP.Checked && this.int_1 == 920)
			{
				if (this.cmbOrganization.SelectedIndex < 0)
				{
					this.labelOrganization.ForeColor = Color.Red;
					result = true;
				}
				if (this.cmbPerformerOrganization.SelectedIndex < 0)
				{
					this.labelPerformer.ForeColor = Color.Red;
					result = true;
				}
				if (this.cmbGroupWorks.SelectedIndex < 0)
				{
					this.labelGroupWork.ForeColor = Color.Red;
					result = true;
				}
				if (this.cmbStatus.SelectedIndex < 0)
				{
					this.labelStatus.ForeColor = Color.Red;
					result = false;
				}
				if (this.method_0() && this.cmbTypeDamage.SelectedIndex < 0)
				{
					result = false;
				}
			}
			return result;
		}

		private void method_16()
		{
			if (!this.isSendRIC)
			{
				return;
			}
			if (!this.method_0())
			{
				return;
			}
			if (this.int_0 == -1)
			{
				return;
			}
			if (!this.rWoeDxUpjP.Checked)
			{
				return;
			}
			base.SelectSqlData(this.dataSetN, this.dataSetN.tJ_RequestForRepair, true, " where id = " + this.int_0.ToString());
			if (this.dataSetN.tJ_RequestForRepair.Rows.Count > 0)
			{
				if (this.dataSetN.tJ_RequestForRepair.Rows[0]["idRIC"] == DBNull.Value)
				{
					try
					{
						RequestsServiceSoapClient requestsServiceSoapClient = new RequestsServiceSoapClient();
						Request request = new Request();
						if (this.dataSetN.tJ_RequestForRepair.Rows[0]["num"] != DBNull.Value)
						{
							request.Number = this.dataSetN.tJ_RequestForRepair.Rows[0]["num"].ToString();
						}
						if (this.dataSetN.tJ_RequestForRepair.Rows[0]["schmObj"] != DBNull.Value)
						{
							request.AddressDisableText = this.dataSetN.tJ_RequestForRepair.Rows[0]["schmObj"].ToString();
						}
						using (SqlConnection sqlConnection = new SqlConnection(this.SqlSettings.GetConnectionString()))
						{
							sqlConnection.Open();
							DbDataAdapter dbDataAdapter = new SqlDataAdapter(" select o.name as city, o.socr as citytype, s.name as street, s.socr as streettype, a.house  from tj_requestforrepairaddress a  inner join tr_kladrstreet s on s.id = a.idkladrstreet  inner join tr_kladrobj o on o.id = s.kladrObjid  where a.idREquest = " + this.int_0.ToString(), sqlConnection);
							DataTable dataTable = new DataTable();
							dbDataAdapter.Fill(dataTable);
							request.AddressHousesDidable = new AddressObjects[dataTable.Rows.Count];
							for (int i = 0; i < dataTable.Rows.Count; i++)
							{
								DataRow dataRow = dataTable.Rows[i];
								request.AddressHousesDidable[i] = new AddressObjects();
								if (dataRow["city"] != DBNull.Value)
								{
									request.AddressHousesDidable[i].City = dataRow["city"].ToString();
								}
								if (dataRow["citytype"] != DBNull.Value)
								{
									request.AddressHousesDidable[i].CityType = dataRow["citytype"].ToString();
								}
								if (dataRow["street"] != DBNull.Value)
								{
									request.AddressHousesDidable[i].Street = dataRow["street"].ToString();
								}
								if (dataRow["streettype"] != DBNull.Value)
								{
									request.AddressHousesDidable[i].StreetType = dataRow["streettype"].ToString();
								}
								if (dataRow["house"] != DBNull.Value)
								{
									request.AddressHousesDidable[i].House = dataRow["house"].ToString();
								}
							}
						}
						base.SelectSqlData(this.dataSetN, this.dataSetN.tJ_RequestForRepairDaily, true, " where idRequest = " + this.int_0.ToString());
						request.DateBeginEnd = new DateBeginEndList[this.dataSetN.tJ_RequestForRepairDaily.Rows.Count];
						for (int j = 0; j < this.dataSetN.tJ_RequestForRepairDaily.Rows.Count; j++)
						{
							DataRow dataRow2 = this.dataSetN.tJ_RequestForRepairDaily.Rows[j];
							request.DateBeginEnd[j] = new DateBeginEndList();
							if (dataRow2["dateBeg"] != DBNull.Value)
							{
								request.DateBeginEnd[j].DateBegin = Convert.ToDateTime(dataRow2["dateBeg"]);
								if (j == 0)
								{
									request.DateBegin = Convert.ToDateTime(dataRow2["dateBeg"]);
								}
							}
							if (dataRow2["dateEnd"] != DBNull.Value)
							{
								request.DateBeginEnd[j].DateEnd = Convert.ToDateTime(dataRow2["dateEnd"]);
								if (j == this.dataSetN.tJ_RequestForRepairDaily.Rows.Count - 1)
								{
									request.DatePlan = new DateTime?(Convert.ToDateTime(dataRow2["dateEnd"]));
									request.DateEnd = new DateTime?(Convert.ToDateTime(dataRow2["dateEnd"]));
								}
							}
						}
						if (this.dataSetN.tJ_RequestForRepair.Rows[0]["typeDisable"] != DBNull.Value)
						{
							request.RefTypeDisable = (long)Convert.ToInt32(this.dataSetN.tJ_RequestForRepair.Rows[0]["typeDisable"]);
						}
						if (this.dataSetN.tJ_RequestForRepair.Rows[0]["purpose"] != DBNull.Value)
						{
							request.Cause = this.dataSetN.tJ_RequestForRepair.Rows[0]["purpose"].ToString();
						}
						if (this.dataSetN.tJ_RequestForRepair.Rows[0]["organization"] != DBNull.Value)
						{
							request.ToOrganizationId = Convert.ToInt32(this.dataSetN.tJ_RequestForRepair.Rows[0]["organization"]);
						}
						if (this.dataSetN.tJ_RequestForRepair.Rows[0]["status"] != DBNull.Value)
						{
							request.RefRequestStatusId = (long)Convert.ToInt32(this.dataSetN.tJ_RequestForRepair.Rows[0]["status"]);
						}
						if (this.dataSetN.tJ_RequestForRepair.Rows[0]["performerorganization"] != DBNull.Value)
						{
							request.PerformerOrganizationId = Convert.ToInt32(this.dataSetN.tJ_RequestForRepair.Rows[0]["performerorganization"]);
						}
						if (this.dataSetN.tJ_RequestForRepair.Rows[0]["groupWorks"] != DBNull.Value)
						{
							request.RefGroupWorksId = (long)Convert.ToInt32(this.dataSetN.tJ_RequestForRepair.Rows[0]["groupWorks"]);
						}
						if (this.dataSetN.tJ_RequestForRepair.Rows[0]["idRegion"] != DBNull.Value)
						{
							request.RefRegionId = (long)Convert.ToInt32(this.dataSetN.tJ_RequestForRepair.Rows[0]["idRegion"]);
						}
						Response response = requestsServiceSoapClient.SendReq(request);
						if (response.RequestId > 0L)
						{
							this.dataSetN.tJ_RequestForRepair.Rows[0]["idric"] = response.RequestId;
							this.dataSetN.tJ_RequestForRepair.Rows[0]["isSEnd"] = true;
							this.dataSetN.tJ_RequestForRepair.Rows[0].EndEdit();
							base.UpdateSqlData(this.dataSetN, this.dataSetN.tJ_RequestForRepair);
						}
						else
						{
							if (this.dataSetN.tJ_RequestForRepair.Rows[0]["messageRic"] == DBNull.Value)
							{
								this.dataSetN.tJ_RequestForRepair.Rows[0]["messageRic"] = response.Message;
							}
							else
							{
								this.dataSetN.tJ_RequestForRepair.Rows[0]["messageRic"] = response.Message + " \r\n" + this.dataSetN.tJ_RequestForRepair.Rows[0]["messageRic"].ToString();
							}
							if (this.dataSetN.tJ_RequestForRepair.Rows[0]["messageRic"].ToString().Length > 1024)
							{
								this.dataSetN.tJ_RequestForRepair.Rows[0]["messageRic"] = this.dataSetN.tJ_RequestForRepair.Rows[0]["messageRic"].ToString().Substring(0, 1024);
							}
							this.dataSetN.tJ_RequestForRepair.Rows[0]["isSEnd"] = false;
							this.dataSetN.tJ_RequestForRepair.Rows[0].EndEdit();
							base.UpdateSqlData(this.dataSetN, this.dataSetN.tJ_RequestForRepair);
							MessageBox.Show(response.Message, "Сообщение из РИЦ", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
						return;
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, ex.Source);
						return;
					}
				}
				if (this.dataSetN.tJ_RequestForRepair.Rows[0]["Status"] == DBNull.Value)
				{
					return;
				}
				int num = Convert.ToInt32(this.dataSetN.tJ_RequestForRepair.Rows[0]["idRIC"]);
				if (this.int_2 != Convert.ToInt32(this.dataSetN.tJ_RequestForRepair.Rows[0]["Status"]))
				{
					if (Convert.ToInt32(this.dataSetN.tJ_RequestForRepair.Rows[0]["Status"]) == 164277)
					{
						try
						{
							RequestsServiceSoapClient requestsServiceSoapClient2 = new RequestsServiceSoapClient();
							DateTime dateEnd = DateTime.Now;
							if (this.dataSetN.tJ_RequestForRepair.Rows[0]["dateFactEnd"] != DBNull.Value)
							{
								dateEnd = Convert.ToDateTime(this.dataSetN.tJ_RequestForRepair.Rows[0]["dateFactEnd"]);
							}
							Response response2 = requestsServiceSoapClient2.Succsess((long)num, dateEnd);
							if (response2.Code != 0)
							{
								MessageBox.Show(response2.Message, "Сообщение из РИЦ", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							}
						}
						catch (Exception ex2)
						{
							MessageBox.Show(ex2.Message, ex2.Source);
						}
					}
					if (Convert.ToInt32(this.dataSetN.tJ_RequestForRepair.Rows[0]["Status"]) == 164280)
					{
						try
						{
							Response response3 = new RequestsServiceSoapClient().RequestCancel((long)num);
							if (response3.Code != 0)
							{
								MessageBox.Show(response3.Message, "Сообщение из РИЦ", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							}
						}
						catch (Exception ex3)
						{
							MessageBox.Show(ex3.Message, ex3.Source);
						}
					}
				}
			}
		}

		private void checkBoxDaily_CheckedChanged(object sender, EventArgs e)
		{
			this.checkBoxWeekEnd.Enabled = this.checkBoxDaily.Checked;
		}

		private void dateTimePickerBeg_ValueChanged(object sender, EventArgs e)
		{
			this.dateTimePickerEnd.MinDate = this.dateTimePickerBeg.Value.AddMinutes(1.0);
		}

		private void dateTimePickerEnd_ValueChanged(object sender, EventArgs e)
		{
			this.dateTimePickerBeg.MaxDate = this.dateTimePickerEnd.Value.AddMinutes(-1.0);
		}

		private void method_17()
		{
			DateTime dateTime = DateTimePicker.MinimumDateTime;
			if ((from o in this.dataSetN.tJ_RequestForRepairDaily
			where o.RowState != DataRowState.Deleted && o.RowState != DataRowState.Detached
			select o).Count<Class3.Class24>() > 0)
			{
				try
				{
					DataRow dataRow = (from o in this.dataSetN.tJ_RequestForRepairDaily
					where o.RowState != DataRowState.Deleted && o.RowState != DataRowState.Detached
					select o into a
					orderby a["DateBeg"]
					select a).First<Class3.Class24>();
					if (dataRow != null && dataRow["DateBeg"] != DBNull.Value)
					{
						dateTime = Convert.ToDateTime(dataRow["DateBeg"]);
					}
				}
				catch
				{
				}
			}
			if (this.dataSetN.tJ_RequestForRepair.Rows.Count > 0 && this.dataSetN.tJ_RequestForRepair.Rows[0]["DateCreate"] != DBNull.Value && dateTime < Convert.ToDateTime(this.dataSetN.tJ_RequestForRepair.Rows[0]["DateCreate"]).AddDays(-1.0).Date)
			{
				dateTime = Convert.ToDateTime(this.dataSetN.tJ_RequestForRepair.Rows[0]["DateCreate"]).AddDays(-1.0).Date;
			}
			this.dateTimePickerFactEnd.MinDate = dateTime;
		}

		private void dgvDaily_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
		{
			DataRow dataRow = (from o in this.dataSetN.tJ_RequestForRepairDaily
			where o.RowState != DataRowState.Deleted && o.RowState != DataRowState.Detached
			select o into a
			orderby a.dateEnd descending
			select a).First<Class3.Class24>();
			if (Convert.ToDateTime(dataRow["DateEnd"]) > this.dateTimePickerBeg.MaxDate)
			{
				this.dateTimePickerBeg.MaxDate = DateTimePicker.MaximumDateTime;
			}
			this.dateTimePickerBeg.MinDate = Convert.ToDateTime(dataRow["DateEnd"]);
			this.method_17();
			this.method_18(Convert.ToDateTime(dataRow["DateEnd"]));
		}

		private void method_18(DateTime dateTime_2)
		{
			if (this.dataSetN.tJ_RequestForRepair.Rows.Count > 0 && ((this.dataSetN.tJ_RequestForRepair.Rows[0].HasVersion(DataRowVersion.Original) && this.dataSetN.tJ_RequestForRepair.Rows[0]["dateFactEnd", DataRowVersion.Original] == DBNull.Value) || !this.dataSetN.tJ_RequestForRepair.Rows[0].HasVersion(DataRowVersion.Original)) && !this.method_0())
			{
				this.dateTimePickerFactEnd.Value = dateTime_2;
			}
		}

		private void dgvDaily_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
		{
			this.method_17();
			if (this.dataSetN.tJ_RequestForRepairDaily.Rows.Count <= 0)
			{
				this.dateTimePickerBeg.MinDate = this.dateTime_0;
				this.method_18(this.dateTime_0);
				return;
			}
			if ((from o in this.dataSetN.tJ_RequestForRepairDaily
			where o.RowState != DataRowState.Deleted && o.RowState != DataRowState.Detached
			select o).Count<Class3.Class24>() > 0)
			{
				DataRow dataRow = (from o in this.dataSetN.tJ_RequestForRepairDaily
				where o.RowState != DataRowState.Deleted && o.RowState != DataRowState.Detached
				select o into a
				orderby a.dateEnd descending
				select a).First<Class3.Class24>();
				this.dateTimePickerBeg.MinDate = Convert.ToDateTime(dataRow["DateEnd"]);
				this.method_18(Convert.ToDateTime(dataRow["DateEnd"]));
				return;
			}
			this.dateTimePickerBeg.MinDate = this.dateTime_0;
			this.method_18(this.dateTime_0);
		}

		private void dgvDaily_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			this.method_17();
			if (e.RowIndex == this.dgvDaily.Rows.Count - 1)
			{
				DateTime dateTime = Convert.ToDateTime(this.dgvDaily[this.dateEndDataGridViewTextBoxColumn.Name, e.RowIndex].Value);
				if (dateTime > this.dateTimePickerBeg.MaxDate)
				{
					this.dateTimePickerBeg.MaxDate = DateTimePicker.MaximumDateTime;
				}
				this.dateTimePickerBeg.MinDate = dateTime;
				this.method_18(dateTime);
			}
		}

		private void dgvDaily_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
		{
			if (e.Control is DateTimePicker)
			{
				if (this.dgvDaily.CurrentCell.OwningColumn.Name == this.dateBegDataGridViewTextBoxColumn.Name)
				{
					(e.Control as DateTimePicker).MaxDate = Convert.ToDateTime(this.dgvDaily[this.dateEndDataGridViewTextBoxColumn.Name, this.dgvDaily.CurrentCell.RowIndex].Value);
					if (this.dgvDaily.CurrentCell.RowIndex == 0)
					{
						(e.Control as DateTimePicker).MinDate = this.dateTime_0;
					}
					if (this.dgvDaily.CurrentCell.RowIndex > 0)
					{
						(e.Control as DateTimePicker).MinDate = Convert.ToDateTime(this.dgvDaily[this.dateEndDataGridViewTextBoxColumn.Name, this.dgvDaily.CurrentCell.RowIndex - 1].Value);
					}
				}
				if (this.dgvDaily.CurrentCell.OwningColumn.Name == this.dateEndDataGridViewTextBoxColumn.Name)
				{
					(e.Control as DateTimePicker).MinDate = Convert.ToDateTime(this.dgvDaily[this.dateBegDataGridViewTextBoxColumn.Name, this.dgvDaily.CurrentCell.RowIndex].Value);
					if (this.dgvDaily.CurrentCell.RowIndex == this.dgvDaily.Rows.Count - 1)
					{
						(e.Control as DateTimePicker).MaxDate = new DateTime(9998, 12, 31);
					}
					if (this.dgvDaily.CurrentCell.RowIndex < this.dgvDaily.Rows.Count - 1)
					{
						(e.Control as DateTimePicker).MaxDate = Convert.ToDateTime(this.dgvDaily[this.dateBegDataGridViewTextBoxColumn.Name, this.dgvDaily.CurrentCell.RowIndex + 1].Value);
					}
				}
			}
		}

		private void dgvDaily_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				DayOfWeek dayOfWeek = DayOfWeek.Monday;
				if (this.dgvDaily[this.dateBegDataGridViewTextBoxColumn.Name, e.RowIndex].Value != null)
				{
					dayOfWeek = Convert.ToDateTime(this.dgvDaily[this.dateBegDataGridViewTextBoxColumn.Name, e.RowIndex].Value).DayOfWeek;
				}
				DayOfWeek dayOfWeek2 = DayOfWeek.Monday;
				if (this.dgvDaily[this.dateEndDataGridViewTextBoxColumn.Name, e.RowIndex].Value != null)
				{
					dayOfWeek2 = Convert.ToDateTime(this.dgvDaily[this.dateEndDataGridViewTextBoxColumn.Name, e.RowIndex].Value).DayOfWeek;
				}
				if ((dayOfWeek == DayOfWeek.Sunday || dayOfWeek == DayOfWeek.Saturday) && this.dgvDaily.Columns[e.ColumnIndex] == this.dateBegDataGridViewTextBoxColumn)
				{
					e.CellStyle.ForeColor = Color.Red;
				}
				if ((dayOfWeek2 == DayOfWeek.Sunday || dayOfWeek2 == DayOfWeek.Saturday) && this.dgvDaily.Columns[e.ColumnIndex] == this.dateEndDataGridViewTextBoxColumn)
				{
					e.CellStyle.ForeColor = Color.Red;
				}
			}
		}

		private void buttonDaily_Click(object sender, EventArgs e)
		{
			bool flag = false;
			this.dgvDaily.RowsAdded -= this.dgvDaily_RowsAdded;
			if (this.checkBoxDaily.Checked)
			{
				for (int i = 0; i <= (this.dateTimePickerEnd.Value - this.dateTimePickerBeg.Value).Days; i++)
				{
					if (this.checkBoxWeekEnd.Checked || (this.dateTimePickerBeg.Value.AddDays((double)i).DayOfWeek != DayOfWeek.Saturday && this.dateTimePickerBeg.Value.AddDays((double)i).DayOfWeek != DayOfWeek.Sunday))
					{
						try
						{
							DataRow dataRow = this.dataSetN.tJ_RequestForRepairDaily.NewRow();
							dataRow["idRequest"] = this.int_0;
							dataRow["dateBeg"] = this.dateTimePickerBeg.Value.AddDays((double)i);
							dataRow["dateEnd"] = this.dateTimePickerBeg.Value.AddDays((double)i).Date + this.dateTimePickerEnd.Value.TimeOfDay;
							this.dataSetN.tJ_RequestForRepairDaily.Rows.Add(dataRow);
							flag = true;
							this.groupBoxDaily.ForeColor = SystemColors.ControlText;
						}
						catch (Exception ex)
						{
							MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
					}
				}
			}
			else
			{
				try
				{
					DataRow dataRow2 = this.dataSetN.tJ_RequestForRepairDaily.NewRow();
					dataRow2["idRequest"] = this.int_0;
					dataRow2["dateBeg"] = this.dateTimePickerBeg.Value;
					dataRow2["dateEnd"] = this.dateTimePickerEnd.Value;
					this.dataSetN.tJ_RequestForRepairDaily.Rows.Add(dataRow2);
					flag = true;
					this.groupBoxDaily.ForeColor = SystemColors.ControlText;
				}
				catch (Exception ex2)
				{
					MessageBox.Show(ex2.Message, ex2.Source, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			this.dgvDaily.RowsAdded += this.dgvDaily_RowsAdded;
			if (flag)
			{
				DataRow dataRow3 = (from o in this.dataSetN.tJ_RequestForRepairDaily
				where o.RowState != DataRowState.Deleted && o.RowState != DataRowState.Detached
				select o into a
				orderby a.dateEnd descending
				select a).First<Class3.Class24>();
				if (Convert.ToDateTime(dataRow3["DateEnd"]) > this.dateTimePickerBeg.MaxDate)
				{
					this.dateTimePickerBeg.MaxDate = this.dateTime_1;
				}
				this.dateTimePickerBeg.MinDate = Convert.ToDateTime(dataRow3["DateEnd"]);
				this.method_17();
				this.method_18(Convert.ToDateTime(dataRow3["DateEnd"]));
			}
		}

		private void cmbIsPlanned_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.cmbIsPlanned.SelectedIndex >= 0)
			{
				this.labelIsPlanned.ForeColor = SystemColors.ControlText;
			}
		}

		private void cmbWorker_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.cmbWorker.SelectedIndex >= 0)
			{
				this.labelWorker.ForeColor = SystemColors.ControlText;
			}
		}

		private void method_19(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(this.txtRequestFiled.Text))
			{
				this.labelRequestFiled.ForeColor = SystemColors.ControlText;
			}
		}

		private void cmbSR_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.cmbSR.SelectedIndex >= 0)
			{
				this.labelSR.ForeColor = SystemColors.ControlText;
			}
		}

		private void txtObject_TextChanged(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(this.txtObject.Text))
			{
				this.labelObject.ForeColor = SystemColors.ControlText;
			}
		}

		private void txtPurpose_TextChanged(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(this.txtPurpose.Text))
			{
				this.labelPurpose.ForeColor = SystemColors.ControlText;
			}
		}

		private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.cmbStatus.SelectedIndex >= 0)
			{
				this.labelStatus.ForeColor = SystemColors.ControlText;
			}
		}

		private void cmbOrganization_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.cmbOrganization.SelectedIndex >= 0)
			{
				this.labelOrganization.ForeColor = SystemColors.ControlText;
			}
		}

		private void cmbPerformerOrganization_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.cmbPerformerOrganization.SelectedIndex >= 0)
			{
				this.labelPerformer.ForeColor = SystemColors.ControlText;
			}
		}

		private void cmbGroupWorks_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.cmbGroupWorks.SelectedIndex >= 0)
			{
				this.labelGroupWork.ForeColor = SystemColors.ControlText;
			}
		}

		private void txtRequestFiled_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.txtRequestFiled.SelectedIndex >= 0)
			{
				this.labelRequestFiled.ForeColor = SystemColors.ControlText;
			}
		}

		private void method_20()
		{
			this.dataTable_8.Clear();
			if (this.dataSetN.tL_RequestForRepairSchmObjList.Rows.Count > 0)
			{
				DataView defaultView = this.dataSetN.tL_RequestForRepairSchmObjList.DefaultView;
				defaultView.Sort = "Num";
				DataTable dataTable = defaultView.ToTable();
				int num = 0;
				bool flag = false;
				List<string> list = new List<string>();
				DateTime dateTime = DateTime.Now;
				DateTime dateTime2 = DateTime.Now;
				string value = "";
				foreach (object obj in dataTable.Rows)
				{
					DataRow dataRow = (DataRow)obj;
					if (num == (int)Convert.ToInt16(dataRow["num"]))
					{
						list.Add(base.CallSQLScalarFunction("dbo.fn_Schm_GetFullNameObjById", new string[]
						{
							dataRow["idSchmObj"].ToString()
						}).ToString());
					}
					else
					{
						if (list.Count > 0)
						{
							list.Sort();
							DataRow dataRow2 = this.dataSet_0.Tables[this.dataTable_8.TableName].NewRow();
							dataRow2["Objects"] = "";
							foreach (string arg in list)
							{
								DataRow dataRow3 = dataRow2;
								dataRow3["Objects"] = dataRow3["Objects"] + arg + "\n";
							}
							dataRow2["Objects"] = ((string)dataRow2["Objects"]).Remove(dataRow2["Objects"].ToString().Length - 1);
							dataRow2["DateBeg"] = dateTime;
							dataRow2["DateEnd"] = dateTime2;
							dataRow2["Duration"] = value;
							dataRow2["disabled"] = flag;
							dataRow2["Num"] = num;
							this.dataSet_0.Tables[this.dataTable_8.TableName].Rows.Add(dataRow2);
						}
						list = new List<string>();
						list.Add(base.CallSQLScalarFunction("dbo.fn_Schm_GetFullNameObjById", new string[]
						{
							dataRow["idSchmObj"].ToString()
						}).ToString());
						dateTime = Convert.ToDateTime(dataRow["DateBeg"]);
						dateTime2 = Convert.ToDateTime(dataRow["DateEnd"]);
						value = dataRow["Duration"].ToString();
						num = (int)Convert.ToInt16(dataRow["Num"]);
						flag = false;
					}
					if (!flag)
					{
						flag = this.method_21(Convert.ToInt32(dataRow["idSchmObj"]));
					}
				}
				if (list.Count > 0)
				{
					list.Sort();
					DataRow dataRow4 = this.dataSet_0.Tables[this.dataTable_8.TableName].NewRow();
					dataRow4["Objects"] = "";
					foreach (string arg2 in list)
					{
						DataRow dataRow3 = dataRow4;
						dataRow3["Objects"] = dataRow3["Objects"] + arg2 + "\n";
					}
					dataRow4["Objects"] = ((string)dataRow4["Objects"]).Remove(dataRow4["Objects"].ToString().Length - 1);
					dataRow4["DateBeg"] = dateTime;
					dataRow4["DateEnd"] = dateTime2;
					dataRow4["Duration"] = value;
					dataRow4["disabled"] = flag;
					dataRow4["Num"] = num;
					this.dataSet_0.Tables[this.dataTable_8.TableName].Rows.Add(dataRow4);
				}
				if (this.dataSet_0.Tables[this.dataTable_8.TableName].Rows.Count > 0)
				{
					this.toolBtnViewSChmObj.Enabled = true;
					return;
				}
				this.toolBtnViewSChmObj.Enabled = false;
			}
		}

		private bool method_21(int int_4)
		{
			return this.int_0 != -1 && new SqlDataCommand(this.SqlSettings).SelectSqlData(string.Format("with  tree (id, isApply, level)\r\n                                                as (select id, isApply,  0 as level  from tj_damage\r\n\t                                                where idReqForRepair = {0} and idSchmObj = {1}\r\n\t                                                union all \r\n\t                                                select tj_damage.id, tJ_Damage.isApply, level+1\r\n\t                                                from tj_damage\t\r\n\t\t                                                inner join tree on tree.id = tj_damage.idParent \r\n\t\t                                            )\r\n\r\n                                                select * from tree\r\n                                                where isApply = 1", this.int_0, int_4)).Rows.Count > 0;
		}

		private void method_22()
		{
			base.SelectSqlData(this.dataSetN, this.dataSetN.tL_RequestForRepairSchmObjList, true, " where idRequest = " + this.int_0.ToString());
			this.method_20();
		}

		private void toolBtnLinkSchmObj_Click(object sender, EventArgs e)
		{
			FormLinkRequestAndSchm formLinkRequestAndSchm = new FormLinkRequestAndSchm();
			formLinkRequestAndSchm.SqlSettings = this.SqlSettings;
			if (formLinkRequestAndSchm.ShowDialog() == DialogResult.OK)
			{
				int num = 1;
				if (this.dataSetN.tL_RequestForRepairSchmObjList.Rows.Count > 0)
				{
					num = (int)((from r in this.dataSetN.tL_RequestForRepairSchmObjList
					where r.RowState != DataRowState.Deleted
					select r).Max((Class3.Class22 x) => x.Num) + 1);
				}
				this.dictionary_0 = formLinkRequestAndSchm.method_0();
				foreach (int num2 in this.dictionary_0.Keys)
				{
					DataRow dataRow = this.dataSetN.tL_RequestForRepairSchmObjList.NewRow();
					dataRow["idRequest"] = this.int_0;
					dataRow["idSchmObj"] = num2;
					dataRow["DAteBeg"] = formLinkRequestAndSchm.DateBeg;
					dataRow["DAteEnd"] = formLinkRequestAndSchm.DateEnd;
					dataRow["duration"] = formLinkRequestAndSchm.Duration;
					dataRow["num"] = num;
					this.dataSetN.tL_RequestForRepairSchmObjList.Rows.Add(dataRow);
				}
				this.method_20();
				this.method_25(this.dictionary_0.Keys.ToList<int>());
			}
		}

		private void dgvLinkObjects_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			this.toolBtnLinkSchmObjEdit_Click(sender, e);
		}

		private void dgvLinkObjects_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && Convert.ToBoolean(this.dgvLinkObjects[this.disabledDgvColumn.Name, e.RowIndex].Value))
			{
				e.CellStyle.BackColor = Color.LightGray;
			}
		}

		private void toolBtnLinkSchmObjEdit_Click(object sender, EventArgs e)
		{
			if (this.dgvLinkObjects.CurrentRow == null)
			{
				return;
			}
			if (Convert.ToBoolean(this.dgvLinkObjects.CurrentRow.Cells[this.disabledDgvColumn.Name].Value))
			{
				MessageBox.Show("Редактирование невозможно. Существует согласованный подчиненный документ.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			DataRow[] array = this.dataSetN.tL_RequestForRepairSchmObjList.Select("num = " + this.dgvLinkObjects.CurrentRow.Cells[this.numDataGridViewTextBoxColumn1.Name].Value.ToString());
			this.dictionary_0.Clear();
			if (array.Length != 0)
			{
				FormLinkRequestAndSchm formLinkRequestAndSchm = new FormLinkRequestAndSchm();
				formLinkRequestAndSchm.SqlSettings = this.SqlSettings;
				formLinkRequestAndSchm.DateBeg = Convert.ToDateTime(array[0]["dateBeg"]);
				formLinkRequestAndSchm.DateEnd = Convert.ToDateTime(array[0]["dateEnd"]);
				formLinkRequestAndSchm.Duration = array[0]["Duration"].ToString();
				formLinkRequestAndSchm.Num = Convert.ToInt16(array[0]["Num"]);
				foreach (DataRow dataRow in array)
				{
					this.dictionary_0.Add(Convert.ToInt32(dataRow["idSchmObj"]), base.CallSQLScalarFunction("dbo.fn_Schm_GetFullNameObjById", new string[]
					{
						dataRow["idSchmObj"].ToString()
					}).ToString());
				}
				formLinkRequestAndSchm.method_1(this.dictionary_0);
				if (formLinkRequestAndSchm.ShowDialog() == DialogResult.OK)
				{
					this.dictionary_0 = formLinkRequestAndSchm.method_0();
					foreach (DataRow dataRow2 in array)
					{
						if (this.dictionary_0.ContainsKey(Convert.ToInt32(dataRow2["idSchmObj"])))
						{
							dataRow2["DAteBeg"] = formLinkRequestAndSchm.DateBeg;
							dataRow2["DAteEnd"] = formLinkRequestAndSchm.DateEnd;
							dataRow2["duration"] = formLinkRequestAndSchm.Duration;
							this.dictionary_0.Remove(Convert.ToInt32(dataRow2["idSchmObj"]));
						}
						else
						{
							dataRow2.Delete();
						}
					}
					foreach (int num in this.dictionary_0.Keys)
					{
						DataRow dataRow3 = this.dataSetN.tL_RequestForRepairSchmObjList.NewRow();
						dataRow3["idRequest"] = this.int_0;
						dataRow3["idSchmObj"] = num;
						dataRow3["DAteBeg"] = formLinkRequestAndSchm.DateBeg;
						dataRow3["DAteEnd"] = formLinkRequestAndSchm.DateEnd;
						dataRow3["duration"] = formLinkRequestAndSchm.Duration;
						dataRow3["num"] = formLinkRequestAndSchm.Num;
						this.dataSetN.tL_RequestForRepairSchmObjList.Rows.Add(dataRow3);
					}
					this.method_20();
				}
			}
		}

		private void toolBtnDelSchmObj_Click(object sender, EventArgs e)
		{
			foreach (object obj in this.dgvLinkObjects.SelectedRows)
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
				if (Convert.ToBoolean(dataGridViewRow.Cells[this.disabledDgvColumn.Name].Value))
				{
					MessageBox.Show("Удаление невозможно. Существует согласованный подчиненный документ.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					break;
				}
				DataRow[] array = this.dataSetN.tL_RequestForRepairSchmObjList.Select("num = " + dataGridViewRow.Cells[this.numDataGridViewTextBoxColumn1.Name].Value.ToString());
				for (int i = 0; i < array.Length; i++)
				{
					array[i].Delete();
				}
			}
			this.method_20();
		}

		private void toolBtnViewSChmObj_Click(object sender, EventArgs e)
		{
			this.dictionary_0.Clear();
			foreach (object obj in this.dgvLinkObjects.SelectedRows)
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
				foreach (DataRow dataRow in this.dataSetN.tL_RequestForRepairSchmObjList.Select("num = " + dataGridViewRow.Cells[this.numDataGridViewTextBoxColumn1.Name].Value.ToString()))
				{
					if (!this.dictionary_0.ContainsKey(Convert.ToInt32(dataRow["idSchmObj"])))
					{
						this.dictionary_0.Add(Convert.ToInt32(dataRow["idSchmObj"]), "");
					}
				}
			}
			GoToSchemaEventArgs e2 = new GoToSchemaEventArgs(this.dictionary_0.Keys.ToList<int>());
			this.OnGoToSchema(e2);
		}

		private void method_23()
		{
			foreach (DataRow dataRow in this.dataSetN.tL_RequestForRepairSchmObjList)
			{
				if (dataRow.RowState != DataRowState.Detached && dataRow.RowState != DataRowState.Deleted)
				{
					dataRow["idRequest"] = this.int_0;
					dataRow.EndEdit();
				}
			}
			base.InsertSqlData(this.dataSetN, this.dataSetN.tL_RequestForRepairSchmObjList);
			base.UpdateSqlData(this.dataSetN, this.dataSetN.tL_RequestForRepairSchmObjList);
			base.DeleteSqlData(this.dataSetN, this.dataSetN.tL_RequestForRepairSchmObjList);
			this.dataSetN.tL_RequestForRepairSchmObjList.AcceptChanges();
		}

		private void rWoeDxUpjP_CheckedChanged(object sender, EventArgs e)
		{
			if (this.rWoeDxUpjP.Checked)
			{
				if (this.dataSetN.tJ_RequestForRepair.Rows.Count > 0 && this.dateTimePickerDateAgreed.Value == null)
				{
					this.dateTimePickerDateAgreed.Value = DateTime.Now;
					return;
				}
			}
			else if (this.dataSetN.tJ_RequestForRepair.Rows.Count > 0 && this.dateTimePickerDateAgreed.Value != null)
			{
				this.dateTimePickerDateAgreed.Value = null;
				this.cmbStatus.SelectedIndex = -1;
			}
		}

		private void rWoeDxUpjP_CheckStateChanged(object sender, EventArgs e)
		{
			this.method_28();
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			base.Close();
		}

		private void toolBtnAddDoc_Click(object sender, EventArgs e)
		{
			try
			{
				OpenFileDialog openFileDialog = new OpenFileDialog();
				openFileDialog.Multiselect = true;
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					for (int i = 0; i < openFileDialog.FileNames.Length; i++)
					{
						DataRow dataRow = this.dataSetN.tJ_RequestForRepairDoc.NewRow();
						dataRow["idRequest"] = this.int_0;
						dataRow["Document"] = File.ReadAllBytes(openFileDialog.FileNames[i]);
						dataRow["FileName"] = Path.GetFileName(openFileDialog.FileNames[i]);
						this.dataSetN.tJ_RequestForRepairDoc.Rows.Add(dataRow);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, ex.Source);
			}
		}

		private void toolBtnDelDoc_Click(object sender, EventArgs e)
		{
			if (this.dgvDocs.CurrentRow != null)
			{
				Convert.ToInt32(this.dgvDocs.CurrentRow.Cells[this.idDataGridViewTextBoxColumnDoc.Name].Value);
				this.dgvDocs.Rows.Remove(this.dgvDocs.CurrentRow);
				return;
			}
			MessageBox.Show("Не выбрано ни одного файла");
		}

		private void toolBtnViewDoc_Click(object sender, EventArgs e)
		{
			if (this.dgvDocs.CurrentRow == null)
			{
				return;
			}
			int num = Convert.ToInt32(this.dgvDocs.CurrentRow.Cells[this.idDataGridViewTextBoxColumnDoc.Name].Value);
			byte[] array = (byte[])this.dataSetN.tJ_RequestForRepairDoc.method_2(num)["Document"];
			string text = Path.GetTempFileName();
			text = Path.ChangeExtension(text, Path.GetExtension(this.dataSetN.tJ_RequestForRepairDoc.method_2(num)["FileName"].ToString()));
			FileStream fileStream = File.Create(text);
			fileStream.Write(array, 0, array.Length);
			fileStream.Close();
			new Process
			{
				StartInfo = 
				{
					FileName = text,
					UseShellExecute = true
				}
			}.Start();
		}

		private void toolBtnSaveDoc_Click(object sender, EventArgs e)
		{
			try
			{
				int num = Convert.ToInt32(this.dgvDocs.CurrentRow.Cells[this.idDataGridViewTextBoxColumnDoc.Name].Value);
				string text = this.dgvDocs.CurrentRow.Cells[this.fileNameDataGridViewTextBoxColumn.Name].Value.ToString();
				string extension = Path.GetExtension(text);
				SaveFileDialog saveFileDialog = new SaveFileDialog();
				saveFileDialog.Filter = "(*" + extension + ")|*" + extension;
				saveFileDialog.FileName = text;
				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					byte[] array = (byte[])this.dataSetN.tJ_RequestForRepairDoc.method_2(num)["Document"];
					FileStream fileStream = File.Create(saveFileDialog.FileName);
					fileStream.Write(array, 0, array.Length);
					fileStream.Close();
					MessageBox.Show("Файл успешно сохранен", "Сохранение");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, ex.Source);
			}
		}

		private void dgvDocs_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
		{
			if (this.dgvDocs.RowCount > 0 && this.dgvDocs[this.fileNameDataGridViewTextBoxColumn.Name, e.RowIndex].Value != null && e.ColumnIndex == this.dgvDocs.Columns[this.ColumnImage.Name].Index)
			{
				Icon icon = Class35.smethod_0(this.dgvDocs[this.fileNameDataGridViewTextBoxColumn.Name, e.RowIndex].Value.ToString());
				e.Value = icon.ToBitmap();
			}
		}

		private void dgvDocs_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (this.dgvDocs.CurrentRow == null)
			{
				return;
			}
			int num = Convert.ToInt32(this.dgvDocs.CurrentRow.Cells[this.idDataGridViewTextBoxColumnDoc.Name].Value);
			if (e.ColumnIndex == this.dgvDocs.Columns[this.fileNameDataGridViewTextBoxColumn.Name].Index)
			{
				byte[] array = (byte[])this.dataSetN.tJ_RequestForRepairDoc.method_2(num)["Document"];
				string text = Path.GetTempFileName();
				text = Path.ChangeExtension(text, Path.GetExtension(this.dataSetN.tJ_RequestForRepairDoc.method_2(num)["FileName"].ToString()));
				FileStream fileStream = File.Create(text);
				fileStream.Write(array, 0, array.Length);
				fileStream.Close();
				new Process
				{
					StartInfo = 
					{
						FileName = text,
						UseShellExecute = true
					}
				}.Start();
			}
		}

		private void method_24()
		{
			foreach (DataRow dataRow in this.dataSetN.tJ_RequestForRepairDoc)
			{
				if (dataRow.RowState != DataRowState.Detached && dataRow.RowState != DataRowState.Deleted)
				{
					dataRow["idRequest"] = this.int_0;
					dataRow.EndEdit();
				}
			}
			base.InsertSqlData(this.dataSetN, this.dataSetN.tJ_RequestForRepairDoc);
			base.UpdateSqlData(this.dataSetN, this.dataSetN.tJ_RequestForRepairDoc);
			base.DeleteSqlData(this.dataSetN, this.dataSetN.tJ_RequestForRepairDoc);
			this.dataSetN.tL_RequestForRepairSchmObjList.AcceptChanges();
		}

		private void buttonCopy_Click(object sender, EventArgs e)
		{
			if (this.dataSetN.tJ_RequestForRepair.Rows.Count <= 0)
			{
				return;
			}
			DataTable dataTable = this.dataSetN.tJ_RequestForRepair.Copy();
			DataRow dataRow = dataTable.NewRow();
			dataRow.ItemArray = dataTable.Rows[0].ItemArray;
			this.dataSetN.tJ_RequestForRepair.Clear();
			this.dataSetN.tJ_RequestForRepairDoc.Clear();
			this.dataSetN.tJ_RequestForRepairDaily.Clear();
			DataRow dataRow2 = this.dataSetN.tJ_RequestForRepair.NewRow();
			dataRow2["num"] = 0;
			dataRow2["dateCreate"] = DateTime.Now;
			if (dataRow["idWorker"] != DBNull.Value)
			{
				dataRow2["idWorker"] = dataRow["idWorker"];
			}
			dataRow2["reguestFiled"] = dataRow["reguestFiled"];
			if (dataRow["idSR"] == DBNull.Value)
			{
				dataRow2["idSR"] = -1;
			}
			else
			{
				dataRow2["idSR"] = dataRow["idSR"];
			}
			dataRow2["idRegion"] = dataRow["idRegion"];
			dataRow2["schmObj"] = dataRow["schmObj"];
			dataRow2["Purpose"] = dataRow["Purpose"];
			if (dataRow["IsPlanned"] == DBNull.Value)
			{
				dataRow2["IsPlanned"] = -1;
			}
			else
			{
				dataRow2["IsPlanned"] = dataRow["IsPlanned"];
			}
			dataRow2["Crash"] = dataRow["Crash"];
			dataRow2["typeDisable"] = dataRow["typeDisable"];
			dataRow2["agreed"] = false;
			dataRow2["iddivision"] = dataRow["iddivision"];
			dataRow2["deleted"] = false;
			dataRow2["Organization"] = dataRow["organization"];
			dataRow2["performerOrganization"] = dataRow["performerorganization"];
			dataRow2["groupworks"] = dataRow["groupworks"];
			DataTable dataTable2 = this.method_13();
			base.SelectSqlData(dataTable2, true, " where [Login] = SYSTEM_USER ", null, false, 0);
			if (dataTable2.Rows.Count > 0)
			{
				dataRow2["idUserCreate"] = dataTable2.Rows[0]["iduser"];
				if (dataTable2.Rows[0]["idWorker"] != DBNull.Value)
				{
					dataRow2["IdWorker"] = dataTable2.Rows[0]["idWorker"];
				}
			}
			if (dataRow2["idWorker"] == DBNull.Value)
			{
				dataRow2["idWorker"] = -1;
			}
			this.int_0 = -1;
			this.eActionRequestRepair = eActionRequestRepair.Add;
			this.dataSetN.tJ_RequestForRepair.Rows.Add(dataRow2);
		}

		protected override XmlDocument CreateXmlConfig()
		{
			XmlDocument xmlDocument = new XmlDocument();
			XmlNode newChild = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", null);
			xmlDocument.AppendChild(newChild);
			XmlNode xmlNode = xmlDocument.CreateElement(base.Name);
			xmlDocument.AppendChild(xmlNode);
			XmlAttribute xmlAttribute = xmlDocument.CreateAttribute("X");
			xmlAttribute.Value = base.Location.X.ToString();
			xmlNode.Attributes.Append(xmlAttribute);
			xmlAttribute = xmlDocument.CreateAttribute("Y");
			xmlAttribute.Value = base.Location.Y.ToString();
			xmlNode.Attributes.Append(xmlAttribute);
			xmlAttribute = xmlDocument.CreateAttribute("SR");
			if (this.eActionRequestRepair == eActionRequestRepair.Add && this.cmbSR.SelectedValue != null)
			{
				xmlAttribute.Value = this.cmbSR.SelectedValue.ToString();
			}
			else
			{
				xmlAttribute.Value = this.int_3.ToString();
			}
			xmlNode.Attributes.Append(xmlAttribute);
			return xmlDocument;
		}

		protected override void ApplyConfig(XmlDocument doc)
		{
			XmlNode xmlNode = doc.SelectSingleNode(base.Name);
			if (xmlNode != null)
			{
				XmlAttribute xmlAttribute = xmlNode.Attributes["X"];
				int? num = null;
				int? num2 = null;
				if (xmlAttribute != null)
				{
					num = new int?(Convert.ToInt32(xmlAttribute.Value));
				}
				xmlAttribute = xmlNode.Attributes["Y"];
				if (xmlAttribute != null)
				{
					num2 = new int?(Convert.ToInt32(xmlAttribute.Value));
				}
				if (num != null && num2 != null)
				{
					if (num < 0)
					{
						num = new int?(0);
					}
					if (num2 < 0)
					{
						num2 = new int?(0);
					}
					base.Location = new Point(num.Value, num2.Value);
				}
				xmlAttribute = xmlNode.Attributes["SR"];
				if (xmlAttribute != null)
				{
					this.int_3 = Convert.ToInt32(xmlAttribute.Value);
				}
			}
		}

		private void method_25(List<int> list_1)
		{
			this.splitContainer1.Panel2.Enabled = false;
			this.toolStripScheme.Enabled = false;
			this.backgroundWorker_0.RunWorkerAsync(list_1);
		}

		private void EaxgBgllje(object sender, DoWorkEventArgs e)
		{
			if (this.electricModel_0 == null)
			{
				this.electricModel_0 = new ElectricModel();
				this.electricModel_0.SqlSettings = this.SqlSettings;
				this.electricModel_0.LoadSchema(false);
			}
			if (this.dataTable_6 == null)
			{
				this.dataTable_6 = new DataTable("tr_kladrstreet");
				base.SelectSqlData(this.dataTable_6, true, "where deleted = 0", null, false, 0);
			}
			if (this.dataTable_5 == null)
			{
				this.dataTable_5 = new DataTable("tr_kladrObj");
				base.SelectSqlData(this.dataTable_5, true, "where deleted = 0", null, false, 0);
			}
			if (this.dataTable_7 == null)
			{
				this.dataTable_7 = new DataTable();
				this.dataTable_7.Columns.Add("KladrObjId", typeof(int));
				this.dataTable_7.Columns.Add("idstreet", typeof(int));
				this.dataTable_7.Columns.Add("house", typeof(string));
			}
			else
			{
				this.dataTable_7.Clear();
			}
			List<int> objectsId = (List<int>)e.Argument;
			IEnumerable<ElectricObject> enumerable = from obj in this.electricModel_0.Objects
			where objectsId.Contains(obj.Id)
			select obj;
			if (enumerable.Count<ElectricObject>() > 0)
			{
				List<ElectricObject> list = new List<ElectricObject>();
				foreach (ElectricObject obj2 in enumerable)
				{
					list.AddRange(this.electricModel_0.PoweringReportForDrawObject(obj2, true, true));
				}
				if (list.Count > 0)
				{
					string text = "";
					foreach (ElectricObject electricObject in list)
					{
						if (string.IsNullOrEmpty(text))
						{
							text = electricObject.Id.ToString();
						}
						else
						{
							text = text + "," + electricObject.Id.ToString();
						}
					}
					using (SqlConnection sqlConnection = new SqlConnection(this.SqlSettings.GetConnectionString()))
					{
						try
						{
							sqlConnection.Open();
							new SqlDataAdapter(" select o.id as KladrObjId, l.id as idStreet, house  from vl_SchmAbnFull l   left join tr_kladrStreet s on l.id = s.id  left join tr_kladrObj o on o.id = s.kladrobjid  where abnActive = 1 and objactive = 1 and idSchmObj in (" + text + ")  group by o.id, l.id, house ", sqlConnection)
							{
								SelectCommand = 
								{
									CommandTimeout = 0
								}
							}.Fill(this.dataTable_7);
						}
						catch (Exception ex)
						{
							MessageBox.Show(ex.Message, ex.Source);
						}
					}
				}
			}
		}

		private void backgroundWorker_0_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			try
			{
				foreach (object obj in this.dataTable_7.Rows)
				{
					DataRow dataRow = (DataRow)obj;
					if (dataRow["idstreet"] != DBNull.Value && dataRow["house"] != DBNull.Value && this.dataSetN.tJ_RequestForRepairAddress.Select(string.Concat(new string[]
					{
						"idKladrStreet = ",
						dataRow["idStreet"].ToString(),
						" and house = '",
						dataRow["house"].ToString(),
						"'"
					})).Length == 0)
					{
						DataRow dataRow2 = this.dataSetN.tJ_RequestForRepairAddress.NewRow();
						dataRow2["idRequest"] = this.int_0;
						dataRow2["idKladrObj"] = dataRow["kladrObjId"];
						dataRow2["idKladrStreet"] = dataRow["idstreet"];
						dataRow2["house"] = dataRow["house"];
						this.dataSetN.tJ_RequestForRepairAddress.Rows.Add(dataRow2);
					}
				}
				this.method_26();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, ex.Source);
			}
			this.splitContainer1.Panel2.Enabled = true;
			this.toolStripScheme.Enabled = true;
		}

		private void method_26()
		{
			this.dataTable_10.Clear();
			if (this.dataTable_6 == null)
			{
				this.dataTable_6 = new DataTable("tr_kladrstreet");
				base.SelectSqlData(this.dataTable_6, true, "where deleted = 0", null, false, 0);
			}
			if (this.dataTable_5 == null)
			{
				this.dataTable_5 = new DataTable("tr_kladrObj");
				base.SelectSqlData(this.dataTable_5, true, "where deleted = 0", null, false, 0);
			}
			foreach (DataRow dataRow in this.dataSetN.tJ_RequestForRepairAddress)
			{
				if (dataRow.RowState != DataRowState.Deleted)
				{
					DataRow dataRow2 = this.dataTable_10.NewRow();
					dataRow2["id"] = dataRow["id"];
					dataRow2["idKladrObj"] = dataRow["idKladrObj"];
					dataRow2["idKladrStreet"] = dataRow["idKladrstreet"];
					dataRow2["house"] = dataRow["house"];
					DataRow[] array = this.dataTable_5.Select("id = " + dataRow["idKladrObj"].ToString());
					if (array.Length != 0)
					{
						dataRow2["City"] = array[0]["name"].ToString() + " " + array[0]["socr"].ToString();
					}
					DataRow[] array2 = this.dataTable_6.Select("id = " + dataRow["idKladrStreet"].ToString());
					if (array2.Length != 0)
					{
						dataRow2["Street"] = array2[0]["name"].ToString() + " " + array2[0]["socr"].ToString();
					}
					this.dataTable_10.Rows.Add(dataRow2);
				}
			}
			List<int> list = new List<int>();
			foreach (object obj in this.dataTable_10.Rows)
			{
				DataRow dataRow3 = (DataRow)obj;
				if (!list.Contains(Convert.ToInt32(dataRow3["idKladrStreet"])))
				{
					list.Add(Convert.ToInt32(dataRow3["idKladrStreet"]));
				}
			}
			string text = "";
			foreach (int num in list)
			{
				DataRow[] array3 = this.dataTable_10.Select("idkladrstreet = " + num.ToString());
				if (array3.Count<DataRow>() > 0)
				{
					string text2 = array3[0]["City"].ToString() + ", " + array3[0]["Street"].ToString() + ", д. ";
					foreach (DataRow dataRow4 in array3)
					{
						text2 = text2 + dataRow4["House"].ToString() + ", ";
					}
					text2 = text2.Remove(text2.Length - 2);
					text = text + text2 + "\r\n";
				}
			}
			this.txtAdress.Text = text;
			if (!string.IsNullOrEmpty(this.txtAdress.Text))
			{
				this.labelAddress.ForeColor = SystemColors.ControlText;
			}
		}

		private void avQgwXctpp(object sender, EventArgs e)
		{
			FormRequestForRepairAddAddress formRequestForRepairAddAddress = new FormRequestForRepairAddAddress();
			formRequestForRepairAddAddress.SqlSettings = this.SqlSettings;
			if (formRequestForRepairAddAddress.ShowDialog() == DialogResult.OK)
			{
				foreach (object obj in formRequestForRepairAddAddress.dataTable_0.Rows)
				{
					DataRow dataRow = (DataRow)obj;
					if (this.dataSetN.tJ_RequestForRepairAddress.Select(string.Concat(new string[]
					{
						"idKladrStreet = ",
						dataRow["idStreet"].ToString(),
						" and house = '",
						dataRow["house"].ToString(),
						"'"
					})).Length == 0)
					{
						DataRow dataRow2 = this.dataSetN.tJ_RequestForRepairAddress.NewRow();
						dataRow2["idRequest"] = this.int_0;
						dataRow2["idKladrObj"] = dataRow["idKladrObj"];
						dataRow2["idKladrStreet"] = dataRow["idstreet"];
						dataRow2["house"] = dataRow["house"];
						this.dataSetN.tJ_RequestForRepairAddress.Rows.Add(dataRow2);
					}
				}
				this.method_26();
			}
		}

		private void toolBtnDelAddress_Click(object sender, EventArgs e)
		{
			if (this.dgvAddress.SelectedRows.Count > 0 && MessageBox.Show("Вы действительно хотите удалить выбранные строки?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				foreach (object obj in this.dgvAddress.SelectedRows)
				{
					int num = Convert.ToInt32(((DataGridViewRow)obj).Cells[this.idAddressDgvColumn.Name].Value);
					DataRow[] array = this.dataSetN.tJ_RequestForRepairAddress.Select("id = " + num.ToString());
					if (array.Length != 0)
					{
						array[0].Delete();
					}
				}
				this.method_26();
			}
		}

		private void method_27()
		{
			foreach (DataRow dataRow in this.dataSetN.tJ_RequestForRepairAddress)
			{
				if (dataRow.RowState != DataRowState.Detached && dataRow.RowState != DataRowState.Deleted)
				{
					dataRow["idRequest"] = this.int_0;
					dataRow.EndEdit();
				}
			}
			base.InsertSqlData(this.dataSetN, this.dataSetN.tJ_RequestForRepairAddress);
			base.UpdateSqlData(this.dataSetN, this.dataSetN.tJ_RequestForRepairAddress);
			base.DeleteSqlData(this.dataSetN, this.dataSetN.tJ_RequestForRepairAddress);
			this.dataSetN.tL_RequestForRepairSchmObjList.AcceptChanges();
		}

		private void method_28()
		{
			if (!this.bool_0)
			{
				if (this.eActionRequestRepair != eActionRequestRepair.Read)
				{
					if (this.dataSetN.tJ_RequestForRepair.Rows.Count <= 0)
					{
						this.chkSendToSite.Enabled = false;
						return;
					}
					if (this.dataSetN.tJ_RequestForRepair.Rows[0]["Agreed"] == DBNull.Value)
					{
						this.chkSendToSite.Enabled = false;
						return;
					}
					if (!Convert.ToBoolean(this.dataSetN.tJ_RequestForRepair.Rows[0]["Agreed"]))
					{
						this.chkSendToSite.Enabled = false;
						return;
					}
					if (this.dataSetN.tJ_RequestForRepair.Rows[0].RowState != DataRowState.Modified)
					{
						if (this.dataSetN.tJ_RequestForRepair.Rows[0].RowState != DataRowState.Unchanged)
						{
							this.chkSendToSite.Enabled = true;
							return;
						}
					}
					if (this.dataSetN.tJ_RequestForRepair.Rows[0]["SendSite", DataRowVersion.Original] != DBNull.Value && Convert.ToBoolean(this.dataSetN.tJ_RequestForRepair.Rows[0]["SendSite", DataRowVersion.Original]))
					{
						this.chkSendToSite.Enabled = false;
						return;
					}
					this.chkSendToSite.Enabled = true;
					return;
				}
			}
			this.chkSendToSite.Enabled = false;
		}

		private void method_29()
		{
			if (this.bool_0)
			{
				try
				{
					Class33.smethod_6(this.SqlSettings);
					Class33.smethod_3(this.SqlSettings, Class33.smethod_5(), DateTime.Now);
					Class33.smethod_8();
					return;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, ex.Source);
					return;
				}
			}
			try
			{
				Class34.smethod_5(this.SqlSettings);
				Class34.smethod_1(this.SqlSettings, Class34.smethod_4(), DateTime.Now.Date, DateTime.Now.Date.AddDays(8.0).AddMilliseconds(-1.0));
				Class34.smethod_7();
			}
			catch (Exception ex2)
			{
				MessageBox.Show(ex2.Message, "Отправка на сайт", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void toolBtnSettingsFTP_Click(object sender, EventArgs e)
		{
			new FormSettingsSender
			{
				SqlSettings = this.SqlSettings,
				MdiParent = base.MdiParent
			}.Show();
		}

		private void method_30()
		{
			if (this.int_0 == -1)
			{
				return;
			}
			DataTable dataTable = new DataTable("tJ_damage");
			dataTable.Columns.Add("id", typeof(int));
			base.SelectSqlData(dataTable, true, " where idReqForRepair = " + this.int_0.ToString() + " and deleted = 0", null, false, 0);
			if (dataTable.Rows.Count > 0)
			{
				this.cmbTypeDamage.Enabled = false;
			}
		}

		private void method_31()
		{
			if (this.int_0 == -1)
			{
				return;
			}
			if (new SqlDataCommand(this.SqlSettings).SelectSqlData(string.Format("with  tree (id, isApply, level)\r\n                                                as (select id, isApply,  0 as level  from tj_damage\r\n\t                                                where idReqForRepair = {0}\r\n\t                                                union all \r\n\t                                                select tj_damage.id, tJ_Damage.isApply, level+1\r\n\t                                                from tj_damage\t\r\n\t\t                                                inner join tree on tree.id = tj_damage.idParent \r\n\t\t                                            )\r\n\r\n                                                select * from tree\r\n                                                where isApply = 1", this.int_0)).Rows.Count > 0)
			{
				this.buttonDaily.Enabled = false;
				this.dgvDaily.ReadOnly = true;
				this.rWoeDxUpjP.Enabled = false;
			}
		}

		private bool method_32()
		{
			if (this.int_0 == -1)
			{
				return true;
			}
			if (!this.method_0())
			{
				return true;
			}
			Class3 @class = new Class3();
			base.SelectSqlData(@class, @class.tJ_Damage, true, "where idReqForRepair = " + this.int_0.ToString());
			base.SelectSqlData(@class, @class.tL_RequestForRepairSchmObjList, true, " where idRequest = " + this.int_0.ToString());
			if (this.rWoeDxUpjP.Checked)
			{
				foreach (DataRow dataRow in @class.tJ_Damage)
				{
					if (!Convert.ToBoolean(dataRow["Deleted"]) && @class.tL_RequestForRepairSchmObjList.Select("idSchmObj = " + dataRow["idSchmObj"].ToString()).Length == 0)
					{
						dataRow["deleted"] = true;
						dataRow.EndEdit();
						base.UpdateSqlData(@class, @class.tJ_Damage);
						Class3 class2 = new Class3();
						base.SelectSqlData(class2, class2.tJ_Damage, true, "where idParent = " + dataRow["id"].ToString());
						foreach (Class3.Class28 class3 in class2.tJ_Damage)
						{
							class3["deleted"] = true;
							class3.EndEdit();
							base.UpdateSqlData(class2, class2.tJ_Damage);
						}
					}
				}
				base.SelectSqlData(@class, @class.tJ_Damage, true, "where idReqForRepair = " + this.int_0.ToString());
				foreach (DataRow dataRow2 in @class.tL_RequestForRepairSchmObjList)
				{
					DataRow[] array = @class.tJ_Damage.Select("idSchmObj = " + dataRow2["idSchmObj"].ToString());
					if (array.Length != 0)
					{
						this.method_33(array[0]);
					}
					else
					{
						this.method_34(Convert.ToInt32(dataRow2["idSchmObj"]));
					}
				}
			}
			return true;
		}

		private void method_33(DataRow dataRow_1)
		{
			if (dataRow_1["isApply"] != DBNull.Value && Convert.ToBoolean(dataRow_1["isApply"]))
			{
				return;
			}
			Class3 @class = new Class3();
			base.SelectSqlData(@class, @class.tJ_Damage, true, "where idParent = " + dataRow_1["id"].ToString());
			bool flag = false;
			foreach (DataRow dataRow in @class.tJ_Damage)
			{
				if (dataRow["isApply"] != DBNull.Value && Convert.ToBoolean(dataRow["isApply"]))
				{
					flag = true;
				}
			}
			if (flag)
			{
				return;
			}
			dataRow_1["Deleted"] = 0;
			dataRow_1["dateDoc"] = this.dataSetN.tJ_RequestForRepairDaily.Rows[0]["dateBeg"];
			this.method_35(dataRow_1, Convert.ToDateTime(this.dataSetN.tJ_RequestForRepairDaily.Rows[0]["dateBeg"]), Convert.ToInt32(dataRow_1["idSchmObj"]));
			dataRow_1.EndEdit();
			base.UpdateSqlDataOnlyChange(dataRow_1.Table);
			foreach (Class3.Class28 class2 in @class.tJ_Damage)
			{
				class2["dateDoc"] = this.dataSetN.tJ_RequestForRepairDaily.Rows[0]["dateBeg"];
				class2.EndEdit();
			}
			base.UpdateSqlData(@class.tJ_Damage);
			this.method_36(Convert.ToInt32(dataRow_1["id"]), Convert.ToDateTime(this.dataSetN.tJ_RequestForRepairDaily.Rows[0]["dateBeg"]), Convert.ToInt32(dataRow_1["idSchmObj"]));
		}

		private void method_34(int int_4)
		{
			Class3 @class = new Class3();
			DataRow dataRow = @class.tJ_Damage.NewRow();
			dataRow["TypeDoc"] = this.dataSetN.tJ_RequestForRepair.Rows[0]["idTypeDamage"];
			dataRow["dateDoc"] = this.dataSetN.tJ_RequestForRepairDaily.Rows[0]["dateBeg"];
			dataRow["idSchmObj"] = int_4;
			dataRow["idReqForRepair"] = this.int_0;
			dataRow["is81"] = false;
			this.method_35(dataRow, Convert.ToDateTime(this.dataSetN.tJ_RequestForRepairDaily.Rows[0]["dateBeg"]), int_4);
			@class.tJ_Damage.Rows.Add(dataRow);
			int num = base.InsertSqlDataOneRow(@class, @class.tJ_Damage);
			if (num > 0)
			{
				this.method_36(num, Convert.ToDateTime(this.dataSetN.tJ_RequestForRepairDaily.Rows[0]["dateBeg"]), int_4);
			}
		}

		private void method_35(DataRow dataRow_1, DateTime dateTime_2, int int_4)
		{
			int num = Convert.ToInt32(this.dataSetN.tJ_RequestForRepair.Rows[0]["idTypeDamage"]);
			if (this.electricModel_1 == null || this.electricModel_1.Objects.Count<ElectricObject>() == 0)
			{
				this.electricModel_1 = new ElectricModel();
				this.electricModel_1.SqlSettings = this.SqlSettings;
				this.electricModel_1.LoadSchema(dateTime_2);
			}
			TreeNodeObj treeNodeObj_ = this.electricModel_1.PoweringReportForDrawObject(int_4, true);
			List<int> list_ = new List<int>();
			FormJournalRequestForRepairAddEdit.smethod_0(treeNodeObj_, list_);
			if (num == 1402)
			{
				DataTable dataTable_ = FormJournalRequestForRepairAddEdit.smethod_1(list_, this.SqlSettings);
				this.method_37(dataRow_1, dataTable_, treeNodeObj_);
			}
			DataTable dataTable = new DataTable("vl_schmAbnFull");
			dataTable.Columns.Add("idAbn", typeof(int));
			dataTable.Columns.Add("idAbnObj", typeof(int));
			IEnumerable<ElectricObject> source = from obj in this.electricModel_1.Objects
			where obj.Id == int_4
			select obj;
			List<ElectricObject> list = this.electricModel_1.PoweringReportForDrawObject(source.First<ElectricObject>(), true, true);
			if (list.Count > 0)
			{
				string text = "";
				foreach (ElectricObject electricObject in list)
				{
					if (string.IsNullOrEmpty(text))
					{
						text = electricObject.Id.ToString();
					}
					else
					{
						text = text + "," + electricObject.Id.ToString();
					}
				}
				new SqlDataCommand(this.SqlSettings).SelectSqlData(dataTable, true, " where idSchmObj in (" + text + ") and abnActive = 1 and objactive = 1  group by idAbn, codeAbonent, nameAbn, typeAbn, idAbnObj, nameObj ", new int?(0), false, 0);
			}
			else
			{
				dataTable.Clear();
			}
			this.method_40(dataRow_1, dataTable);
		}

		private void method_36(int int_4, DateTime dateTime_2, int int_5)
		{
			int num = Convert.ToInt32(this.dataSetN.tJ_RequestForRepair.Rows[0]["idTypeDamage"]);
			Class3 @class = new Class3();
			if (num == 1402)
			{
				base.SelectSqlData(@class.tJ_DamageHV, true, "where idDamage = " + int_4.ToString(), null, false, 0);
				DataRow dataRow;
				if (@class.tJ_DamageHV.Rows.Count > 0)
				{
					dataRow = @class.tJ_DamageHV.Rows[0];
				}
				else
				{
					dataRow = @class.tJ_DamageHV.NewRow();
					dataRow["idDamage"] = int_4;
				}
				if (this.electricModel_1 == null || this.electricModel_1.Objects.Count<ElectricObject>() == 0)
				{
					this.electricModel_1 = new ElectricModel();
					this.electricModel_1.SqlSettings = this.SqlSettings;
					this.electricModel_1.LoadSchema(dateTime_2);
				}
				TreeNodeObj treeNodeObj_ = this.electricModel_1.PoweringReportForDrawObject(int_5, true);
				List<int> list_ = new List<int>();
				FormJournalRequestForRepairAddEdit.smethod_0(treeNodeObj_, list_);
				DataTable dataTable = FormJournalRequestForRepairAddEdit.smethod_1(list_, this.SqlSettings);
				dataRow["countSchmObj"] = dataTable.Rows.Count;
				dataRow["countSchmObjOff"] = 0;
				dataRow["ConnectedPower"] = dataTable.Compute("Sum(Power)", "");
				dataRow["PowerA"] = dataTable.Compute("Sum(Load)", "");
				if (dataRow["CoefFI"] == DBNull.Value)
				{
					dataRow["CoefFI"] = 0.9;
				}
				if (dataRow["CoefSeason"] == DBNull.Value)
				{
					dataRow["CoefSeason"] = 0.8;
				}
				if (@class.tJ_DamageHV.Rows.Count > 0)
				{
					dataRow.EndEdit();
					base.UpdateSqlDataOnlyChange(@class.tJ_DamageHV);
				}
				else
				{
					@class.tJ_DamageHV.Rows.Add(dataRow);
					base.InsertSqlData(@class.tJ_DamageHV);
				}
			}
			if (num == 1401)
			{
				base.SelectSqlData(@class.tJ_DamageLV, true, "where idDamage = " + int_4.ToString(), null, false, 0);
				DataRow dataRow2;
				if (@class.tJ_DamageLV.Rows.Count > 0)
				{
					dataRow2 = @class.tJ_DamageLV.Rows[0];
				}
				else
				{
					dataRow2 = @class.tJ_DamageLV.NewRow();
					dataRow2["idDamage"] = int_4;
				}
				if (@class.tJ_DamageLV.Rows.Count > 0)
				{
					dataRow2.EndEdit();
					base.UpdateSqlDataOnlyChange(@class.tJ_DamageLV);
					return;
				}
				@class.tJ_DamageLV.Rows.Add(dataRow2);
				base.InsertSqlData(@class.tJ_DamageLV);
			}
		}

		private static void smethod_0(TreeNodeObj treeNodeObj_0, List<int> list_1)
		{
			if (treeNodeObj_0.Tag != null && treeNodeObj_0.Tag is ElectricLine)
			{
				foreach (ElectricRelation electricRelation in ((ElectricLine)treeNodeObj_0.Tag).Relations)
				{
					foreach (ElectricObject electricObject in electricRelation.ChildObjects)
					{
						if (electricObject is ElectricSwitch && ((ElectricSwitch)electricObject).TypeSwitch == TypeSwitch.TransformerTool && !list_1.Contains(electricObject.Id))
						{
							list_1.Add(electricObject.Id);
						}
					}
				}
			}
			foreach (TreeNodeObj treeNodeObj_ in treeNodeObj_0.Nodes)
			{
				FormJournalRequestForRepairAddEdit.smethod_0(treeNodeObj_, list_1);
			}
		}

		private static DataTable smethod_1(List<int> list_1, SQLSettings sqlsettings_0)
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("idTr", typeof(int));
			dataTable.Columns.Add("TrName", typeof(string));
			dataTable.Columns.Add("idSub", typeof(int));
			dataTable.Columns.Add("Sub", typeof(string));
			dataTable.Columns.Add("Power", typeof(int));
			dataTable.Columns.Add("load", typeof(int));
			dataTable.Clear();
			using (SqlConnection sqlConnection = new SqlConnection(sqlsettings_0.GetConnectionString() + ";Connection Timeout=1000"))
			{
				sqlConnection.Open();
				using (SqlCommand sqlCommand = new SqlCommand(Class32.smethod_2("RequestsClient.DataSets.GetTransformerSchmObj.sql"), sqlConnection))
				{
					sqlCommand.CommandTimeout = 0;
					DataTable dataTable2 = new DataTable();
					new SqlDataAdapter(sqlCommand).Fill(dataTable2);
					int num = 0;
					foreach (int num2 in list_1)
					{
						DataRow[] array = dataTable2.Select("id = " + num2.ToString());
						if (array.Length != 0)
						{
							DataRow dataRow = dataTable.NewRow();
							dataRow["idTR"] = array[0]["id"];
							dataRow["TrNAme"] = array[0]["Наименование"];
							dataRow["idSub"] = array[0]["idSub"];
							dataRow["Sub"] = array[0]["Расположение"];
							if (array[0]["Мощность"] != DBNull.Value && !string.IsNullOrEmpty(array[0]["Мощность"].ToString()))
							{
								dataRow["Power"] = array[0]["Мощность"];
							}
							if (array[0]["Мощность"] != DBNull.Value && !string.IsNullOrEmpty(array[0]["Мощность"].ToString()))
							{
								num += Convert.ToInt32(array[0]["Мощность"]);
							}
							dataTable.Rows.Add(dataRow);
						}
					}
				}
				using (SqlCommand sqlCommand2 = new SqlCommand("SELECT mat.idbus, mat.[IdObjList],\r\n                        \t(case when max([Ia]) >= max([Ib]) and max([Ia]) >= max([Ic]) \r\n                        \t then max([Ia]) \telse case when max([Ib]) >= max([Ic]) and max([Ib]) >= max([Ia]) then max([Ib]) \r\n                        \t\t\t\t\t                                else case when max([Ic]) >= max([Ia]) and max([Ic]) >= max([Ib]) \r\n                        \t\t\t\t\t                                then max([Ic]) end end end) as I\r\n                         FROM [tJ_MeasAmperageTransf] as mat\r\n                               inner join [tJ_Measurement] as m on mat.[idMeasurement] = m.id\r\n                          where  mat.deleted = 0 and m.[TypeDoc] = 1192\r\n                        \tand ((year(m.[DateD]) = \r\n                        \t\t\t(select case when month(max(dateD)) = 12 then year(max(dateD)) + 1\r\n                        \t\t\t\t\telse year(max(dateD)) end from tj_measurement mes \r\n                        \t\t\tleft join [tJ_MeasAmperageTransf] mt on mt.[idMeasurement] = mes.id\r\n                        \t\t\t where mt.idBus = mat.idBus and mt.deleted = 0 and m.typeDoc = 1192\t\r\n                        \t\t\t and  mt.[Ia] is not null and  mt.[Ib] is not null and  mt.[Ic] is not null)\r\n                                      and month(m.[DateD]) between 1 and 11)\t\r\n                           or (year(m.[DateD]) =(select case when month(max(dateD)) = 12 then year(max(dateD)) + 1\r\n                        \telse year(max(dateD)) end\r\n                        \tfrom tj_measurement mes \r\n                        \tleft join [tJ_MeasAmperageTransf] mt on mt.[idMeasurement] = mes.id\r\n                        \twhere mt.idBus = mat.idBus and mt.deleted = 0 and m.typeDoc = 1192\r\n                        \t and  mt.[Ia] is not null and  mt.[Ib] is not null and  mt.[Ic] is not null)-1 and month(m.[DateD])=12)) \r\n                            and  mat.[Ia] is not null and  mat.[Ib] is not null and  mat.[Ic] is not null \r\n                          group by mat.idBus,  mat.[idObjList]", sqlConnection))
				{
					sqlCommand2.CommandTimeout = 0;
					DataTable dataTable3 = new DataTable();
					new SqlDataAdapter(sqlCommand2).Fill(dataTable3);
					foreach (object obj in dataTable.Rows)
					{
						DataRow dataRow2 = (DataRow)obj;
						DataRow[] array2 = dataTable3.Select("idObjList = " + dataRow2["idTr"].ToString());
						if (array2.Length != 0)
						{
							dataRow2["Load"] = array2[0]["I"];
						}
					}
				}
			}
			return dataTable;
		}

		private void method_37(DataRow dataRow_1, DataTable dataTable_11, TreeNodeObj treeNodeObj_0)
		{
			XmlDocument xmlDocument = new XmlDocument();
			if (dataRow_1["CommentXml"] != DBNull.Value)
			{
				try
				{
					xmlDocument.LoadXml(dataRow_1["CommentXml"].ToString());
				}
				catch
				{
				}
			}
			XmlNode xmlNode = xmlDocument.SelectSingleNode("Doc");
			if (xmlNode == null)
			{
				xmlNode = xmlDocument.CreateElement("Doc");
				xmlDocument.AppendChild(xmlNode);
			}
			XmlNode xmlNode2 = xmlNode.SelectSingleNode("TransOff");
			if (xmlNode2 != null)
			{
				xmlNode2.RemoveAll();
			}
			else
			{
				xmlNode2 = xmlDocument.CreateElement("TransOff");
				xmlNode.AppendChild(xmlNode2);
			}
			foreach (object obj in dataTable_11.Rows)
			{
				DataRow dataRow = (DataRow)obj;
				XmlNode xmlNode3 = xmlDocument.CreateElement("Row");
				xmlNode2.AppendChild(xmlNode3);
				XmlAttribute xmlAttribute = xmlDocument.CreateAttribute("idSub");
				xmlAttribute.Value = dataRow["idSub"].ToString();
				xmlNode3.Attributes.Append(xmlAttribute);
				xmlAttribute = xmlDocument.CreateAttribute("idTr");
				xmlAttribute.Value = dataRow["idTr"].ToString();
				xmlNode3.Attributes.Append(xmlAttribute);
				xmlAttribute = xmlDocument.CreateAttribute("Power");
				xmlAttribute.Value = dataRow["Power"].ToString();
				xmlNode3.Attributes.Append(xmlAttribute);
				xmlAttribute = xmlDocument.CreateAttribute("Load");
				xmlAttribute.Value = dataRow["Load"].ToString();
				xmlNode3.Attributes.Append(xmlAttribute);
			}
			this.list_0 = new List<int>();
			XmlNode xmlNode4 = xmlDocument.CreateElement("TransTree");
			xmlNode2.AppendChild(xmlNode4);
			this.method_38(xmlNode4, treeNodeObj_0, dataTable_11, null);
			dataRow_1["CommentXml"] = xmlDocument.InnerXml;
		}

		private void method_38(XmlNode xmlNode_0, TreeNodeObj treeNodeObj_0, DataTable dataTable_11, XmlNode xmlNode_1 = null)
		{
			if (xmlNode_0 != null && xmlNode_0.OwnerDocument != null)
			{
				XmlDocument ownerDocument = xmlNode_0.OwnerDocument;
				if (treeNodeObj_0.Tag != null)
				{
					if (treeNodeObj_0.Tag is ElectricBus)
					{
						if (this.list_0.Contains(((ElectricBus)treeNodeObj_0.Tag).Id))
						{
							return;
						}
						this.list_0.Add(((ElectricBus)treeNodeObj_0.Tag).Id);
					}
					if (treeNodeObj_0.Tag is ElectricLine)
					{
						ElectricLine electricLine = (ElectricLine)treeNodeObj_0.Tag;
						if (electricLine.IsCell())
						{
							ElectricBus electricBus = null;
							foreach (ElectricPoint electricPoint in electricLine.Ends)
							{
								if (electricPoint.Parent is ElectricBus)
								{
									electricBus = (ElectricBus)electricPoint.Parent;
									if (electricBus.TypeBus == eTypeShinaTool.Shina_10 || electricBus.TypeBus == eTypeShinaTool.Shina_110 || electricBus.TypeBus == eTypeShinaTool.Shina_35)
									{
										break;
									}
									if (electricBus.TypeBus == eTypeShinaTool.Shina_6)
									{
										break;
									}
									electricBus = null;
								}
							}
							if (electricBus != null)
							{
								XmlNode xmlNode;
								if (xmlNode_1 != null)
								{
									xmlNode = xmlNode_1;
								}
								else
								{
									xmlNode = xmlNode_0;
								}
								XmlNode xmlNode2 = ownerDocument.CreateElement("NodeDgv");
								xmlNode.AppendChild(xmlNode2);
								this.method_39(xmlNode2, electricBus.Parent.ToString(), electricBus.Parent.Id.ToString(), electricBus.ToString(), electricBus.Id.ToString(), electricLine.ToString(), electricLine.Id.ToString(), "", "", "");
								xmlNode_1 = xmlNode2;
							}
						}
						foreach (ElectricRelation electricRelation in ((ElectricLine)treeNodeObj_0.Tag).Relations)
						{
							foreach (ElectricObject electricObject in electricRelation.ChildObjects)
							{
								if (electricObject is ElectricSwitch && ((ElectricSwitch)electricObject).TypeSwitch == TypeSwitch.TransformerTool && xmlNode_1 != null)
								{
									if (xmlNode_1.Attributes["idTr"] != null && !string.IsNullOrEmpty(xmlNode_1.Attributes["idTr"].Value))
									{
										XmlNode xmlNode3 = ownerDocument.CreateElement("NodeDgv");
										xmlNode_1.ParentNode.AppendChild(xmlNode3);
										this.method_39(xmlNode3, xmlNode_1.Attributes["SubName"].Value, xmlNode_1.Attributes["idSub"].Value, xmlNode_1.Attributes["BusName"].Value, xmlNode_1.Attributes["idBus"].Value, xmlNode_1.Attributes["CellName"].Value, xmlNode_1.Attributes["idCell"].Value, "", "", "");
										xmlNode_1 = xmlNode3;
									}
									DataRow[] array = dataTable_11.Select("idTr = " + electricObject.Id.ToString());
									int? num = null;
									int? num2 = null;
									if (array.Length != 0)
									{
										if (array[0]["power"] != DBNull.Value)
										{
											num = new int?(Convert.ToInt32(array[0]["power"]));
										}
										if (array[0]["load"] != DBNull.Value)
										{
											num2 = new int?(Convert.ToInt32(array[0]["load"]));
										}
									}
									if (num != null)
									{
										XmlAttribute xmlAttribute;
										if (xmlNode_1.Attributes["Power"] == null)
										{
											xmlAttribute = ownerDocument.CreateAttribute("Power");
											xmlNode_1.Attributes.Append(xmlAttribute);
										}
										else
										{
											xmlAttribute = xmlNode_1.Attributes["Power"];
										}
										if (string.IsNullOrEmpty(xmlAttribute.Value))
										{
											xmlAttribute.Value = num.ToString();
										}
										else
										{
											xmlAttribute.Value = (Convert.ToInt32(xmlAttribute.Value) + num).ToString();
										}
									}
									if (num2 != null)
									{
										XmlAttribute xmlAttribute2;
										if (xmlNode_1.Attributes["Load"] == null)
										{
											xmlAttribute2 = ownerDocument.CreateAttribute("Load");
											xmlNode_1.Attributes.Append(xmlAttribute2);
										}
										else
										{
											xmlAttribute2 = xmlNode_1.Attributes["Load"];
										}
										if (string.IsNullOrEmpty(xmlAttribute2.Value))
										{
											xmlAttribute2.Value = num2.ToString();
										}
										else
										{
											xmlAttribute2.Value = (Convert.ToInt32(xmlAttribute2.Value) + num2).ToString();
										}
									}
									XmlAttribute xmlAttribute3;
									if (xmlNode_1.Attributes["idTr"] == null)
									{
										xmlAttribute3 = ownerDocument.CreateAttribute("idTr");
										xmlNode_1.Attributes.Append(xmlAttribute3);
									}
									else
									{
										xmlAttribute3 = xmlNode_1.Attributes["idTr"];
									}
									XmlAttribute xmlAttribute4;
									if (xmlNode_1.Attributes["TrName"] == null)
									{
										xmlAttribute4 = ownerDocument.CreateAttribute("TrName");
										xmlNode_1.Attributes.Append(xmlAttribute4);
									}
									else
									{
										xmlAttribute4 = xmlNode_1.Attributes["TrName"];
									}
									if (string.IsNullOrEmpty(xmlAttribute3.Value))
									{
										xmlAttribute3.Value = electricObject.Id.ToString();
									}
									else
									{
										XmlAttribute xmlAttribute5 = xmlAttribute3;
										xmlAttribute5.Value = xmlAttribute5.Value + ";" + electricObject.Id.ToString();
									}
									if (string.IsNullOrEmpty(xmlAttribute4.Value))
									{
										xmlAttribute4.Value = electricObject.ToString();
									}
									else
									{
										XmlAttribute xmlAttribute6 = xmlAttribute4;
										xmlAttribute6.Value = xmlAttribute6.Value + ";" + electricObject.ToString();
									}
								}
							}
						}
					}
				}
				foreach (TreeNodeObj treeNodeObj_ in treeNodeObj_0.Nodes)
				{
					this.method_38(xmlNode_0, treeNodeObj_, dataTable_11, xmlNode_1);
				}
				return;
			}
		}

		private void method_39(XmlNode xmlNode_0, string string_0, string string_1, string string_2, string string_3, string string_4, string string_5, string string_6 = "", string string_7 = "", string string_8 = "")
		{
			if (xmlNode_0 != null && xmlNode_0.OwnerDocument != null)
			{
				XmlDocument ownerDocument = xmlNode_0.OwnerDocument;
				XmlAttribute xmlAttribute = ownerDocument.CreateAttribute("SubName");
				xmlAttribute.Value = string_0;
				xmlNode_0.Attributes.Append(xmlAttribute);
				xmlAttribute = ownerDocument.CreateAttribute("idSub");
				xmlAttribute.Value = string_1;
				xmlNode_0.Attributes.Append(xmlAttribute);
				xmlAttribute = ownerDocument.CreateAttribute("BusName");
				xmlAttribute.Value = string_2;
				xmlNode_0.Attributes.Append(xmlAttribute);
				xmlAttribute = ownerDocument.CreateAttribute("idBus");
				xmlAttribute.Value = string_3;
				xmlNode_0.Attributes.Append(xmlAttribute);
				xmlAttribute = ownerDocument.CreateAttribute("CellName");
				xmlAttribute.Value = string_4;
				xmlNode_0.Attributes.Append(xmlAttribute);
				xmlAttribute = ownerDocument.CreateAttribute("idCell");
				xmlAttribute.Value = string_5;
				xmlNode_0.Attributes.Append(xmlAttribute);
				return;
			}
		}

		private void method_40(DataRow dataRow_1, DataTable dataTable_11)
		{
			XmlDocument xmlDocument = new XmlDocument();
			if (dataRow_1["CommentXml"] != DBNull.Value)
			{
				try
				{
					xmlDocument.LoadXml(dataRow_1["CommentXml"].ToString());
				}
				catch
				{
				}
			}
			XmlNode xmlNode = xmlDocument.SelectSingleNode("Doc");
			if (xmlNode == null)
			{
				xmlNode = xmlDocument.CreateElement("Doc");
				xmlDocument.AppendChild(xmlNode);
			}
			XmlNode xmlNode2 = xmlNode.SelectSingleNode("AbnOff");
			if (xmlNode2 != null)
			{
				xmlNode2.RemoveAll();
			}
			else
			{
				xmlNode2 = xmlDocument.CreateElement("AbnOff");
				xmlNode.AppendChild(xmlNode2);
			}
			foreach (object obj in dataTable_11.Rows)
			{
				DataRow dataRow = (DataRow)obj;
				if (dataRow.RowState != DataRowState.Deleted)
				{
					XmlNode xmlNode3 = xmlDocument.CreateElement("Row");
					xmlNode2.AppendChild(xmlNode3);
					XmlAttribute xmlAttribute = xmlDocument.CreateAttribute("idAbnObj");
					xmlAttribute.Value = dataRow["idAbnObj"].ToString();
					xmlNode3.Attributes.Append(xmlAttribute);
				}
			}
			this.method_41(xmlNode2, dataTable_11);
			this.method_42(xmlNode2, dataTable_11);
			dataRow_1["CommentXml"] = xmlDocument.InnerXml;
		}

		private void method_41(XmlNode xmlNode_0, DataTable dataTable_11)
		{
			try
			{
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				int num4 = 0;
				int num5 = 0;
				int num6 = 0;
				int num7 = 0;
				if (dataTable_11.Rows.Count > 0)
				{
					string text = "";
					foreach (object obj in dataTable_11.Rows)
					{
						DataRow dataRow = (DataRow)obj;
						if (dataRow.RowState != DataRowState.Deleted)
						{
							if (string.IsNullOrEmpty(text))
							{
								text = dataRow["idAbnObj"].ToString();
							}
							else
							{
								text = text + "," + dataRow["idAbnObj"].ToString();
							}
						}
					}
					DataTable dataTable = new SqlDataCommand(this.SqlSettings).SelectSqlData(string.Format("select ao.id,\r\n                                        case when a.TypeAbn = 231 then -1 -- сетевая организация\r\n                                        else case when a.typeAbn = 206 and r.category is null then 493 -- если у физика нет категории - ставим ему третью\r\n                                        else case when category is null then 493 else r.category end end end as category\r\n                                     from tAbnObj ao \r\n\t                                    left join tAbn a on a.id = ao.idAbn\r\n\t                                    left join tAbnObjReg r on r.id = (select top 1 id from tAbnObjREg \r\n\t\t\t\t\t\t\t                where idAbnObj = ao.id\r\n\t\t\t\t\t\t\t                order by datechange desc)\r\n                                        left join tPoint p on p.idAbnObj = ao.id and p.dateBegin <= '{0}' and \r\n                                                                (p.dateEnd  >= '{0}' or p.dateEnd is null)\r\n\t                                    /*left join tPointReg pReg on pReg.id = (select top 1 id from tPointReg\r\n\t\t\t\t\t\t\t\t\t\t                                      where idPoint = p.id \r\n\t\t\t\t\t\t\t\t\t\t\t                        and dateBegin <= '{0}' and \r\n                                                                    (dateEnd  >= '{0}' or dateEnd is null)\r\n\t\t\t\t\t\t\t\t\t                                order by dateBegin desc)*/\r\n                                     where ao.id in ({1}) \r\n                                        --and p.id is not null and pREg.id is not null", Convert.ToDateTime(this.dataSetN.tJ_RequestForRepairDaily.Rows[0]["dateBeg"]).ToString("yyyyMMdd"), text));
					num4 = Convert.ToInt32(dataTable.Compute("count(id)", "category in (491,494)"));
					num5 = Convert.ToInt32(dataTable.Compute("count(id)", "category = 492"));
					num6 = Convert.ToInt32(dataTable.Compute("count(id)", "category = 493"));
					num7 = Convert.ToInt32(dataTable.Compute("count(id)", "category = -1"));
				}
				if (xmlNode_0 != null && xmlNode_0.OwnerDocument != null)
				{
					XmlDocument ownerDocument = xmlNode_0.OwnerDocument;
					XmlNode xmlNode = ownerDocument.CreateElement("CountPoint");
					xmlNode_0.AppendChild(xmlNode);
					XmlAttribute xmlAttribute = ownerDocument.CreateAttribute("countPointCat1");
					xmlAttribute.Value = num4.ToString();
					xmlNode.Attributes.Append(xmlAttribute);
					xmlAttribute = ownerDocument.CreateAttribute("countPointCat1Full");
					xmlAttribute.Value = num.ToString();
					xmlNode.Attributes.Append(xmlAttribute);
					xmlAttribute = ownerDocument.CreateAttribute("countPointCat2");
					xmlAttribute.Value = num5.ToString();
					xmlNode.Attributes.Append(xmlAttribute);
					xmlAttribute = ownerDocument.CreateAttribute("countPointCat2Full");
					xmlAttribute.Value = num2.ToString();
					xmlNode.Attributes.Append(xmlAttribute);
					xmlAttribute = ownerDocument.CreateAttribute("countPointCat3");
					xmlAttribute.Value = num6.ToString();
					xmlNode.Attributes.Append(xmlAttribute);
					xmlAttribute = ownerDocument.CreateAttribute("countPointEE");
					xmlAttribute.Value = num7.ToString();
					xmlNode.Attributes.Append(xmlAttribute);
					xmlAttribute = ownerDocument.CreateAttribute("countPointSource");
					xmlAttribute.Value = num3.ToString();
					xmlNode.Attributes.Append(xmlAttribute);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void method_42(XmlNode xmlNode_0, DataTable dataTable_11)
		{
			try
			{
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				int num4 = 0;
				int num5 = 0;
				int num6 = 0;
				int num7 = 0;
				int num8 = 0;
				if (dataTable_11.Rows.Count > 0)
				{
					string text = "";
					foreach (object obj in dataTable_11.Rows)
					{
						DataRow dataRow = (DataRow)obj;
						if (dataRow.RowState != DataRowState.Deleted)
						{
							if (string.IsNullOrEmpty(text))
							{
								text = dataRow["idAbnObj"].ToString();
							}
							else
							{
								text = text + "," + dataRow["idAbnObj"].ToString();
							}
						}
					}
					SqlDataCommand sqlDataCommand = new SqlDataCommand(this.SqlSettings);
					DataTable dataTable = sqlDataCommand.SelectSqlData("select ao.id,\r\n                                        case when a.TypeAbn = 231 then -1 -- сетевая организация\r\n                                        else case when a.typeAbn = 206 and r.category is null then 493 -- если у физика нет категории - ставим ему третью\r\n                                        else case when category is null then 493 else r.category end end end as category\r\n                                     from tAbnObj ao \r\n\t                                    left join tAbn a on a.id = ao.idAbn\r\n\t                                    left join tAbnObjReg r on r.id = (select top 1 id from tAbnObjREg \r\n\t\t\t\t\t\t\t                where idAbnObj = ao.id\r\n\t\t\t\t\t\t\t                order by datechange desc)\r\n                                     where ao.id in (" + text + ")");
					num = Convert.ToInt32(dataTable.Compute("count(id)", "category in (491,494)"));
					num2 = Convert.ToInt32(dataTable.Compute("count(id)", "category = 492"));
					num3 = Convert.ToInt32(dataTable.Compute("count(id)", "category = 493"));
					num4 = Convert.ToInt32(dataTable.Compute("count(id)", "category = -1"));
					DataTable dataTable2 = sqlDataCommand.SelectSqlData("select ao.id,\r\n                                         case when a.TypeAbn = 206 or r.PowerSEt is null then 15\r\n                                        \telse r.PowerSEt end PowerSEt\r\n                                     from tAbnObj ao \r\n\t                                    left join tAbn a on a.id = ao.idAbn\r\n\t                                    left join tAbnObjReg r on r.id = (select top 1 id from tAbnObjREg \r\n\t\t\t\t\t\t\t                where idAbnObj = ao.id\r\n\t\t\t\t\t\t\t                order by datechange desc)\r\n                                     where ao.id in (" + text + ")");
					num6 = Convert.ToInt32(dataTable2.Compute("count(id)", "PowerSet <= 150"));
					num7 = Convert.ToInt32(dataTable2.Compute("count(id)", "PowerSet > 150 and PowerSet <= 670"));
					num8 = Convert.ToInt32(dataTable2.Compute("count(id)", "PowerSet > 670"));
				}
				if (xmlNode_0 != null && xmlNode_0.OwnerDocument != null)
				{
					XmlDocument ownerDocument = xmlNode_0.OwnerDocument;
					XmlNode xmlNode = ownerDocument.CreateElement("CountAbnObj");
					xmlNode_0.AppendChild(xmlNode);
					XmlAttribute xmlAttribute = ownerDocument.CreateAttribute("countAbnObjCat1");
					xmlAttribute.Value = num.ToString();
					xmlNode.Attributes.Append(xmlAttribute);
					xmlAttribute = ownerDocument.CreateAttribute("countAbnObjCat1Full");
					xmlAttribute.Value = "0";
					xmlNode.Attributes.Append(xmlAttribute);
					xmlAttribute = ownerDocument.CreateAttribute("countAbnObjCat2");
					xmlAttribute.Value = num2.ToString();
					xmlNode.Attributes.Append(xmlAttribute);
					xmlAttribute = ownerDocument.CreateAttribute("countAbnObjCat2Full");
					xmlAttribute.Value = "0";
					xmlNode.Attributes.Append(xmlAttribute);
					xmlAttribute = ownerDocument.CreateAttribute("countAbnObjCat3");
					xmlAttribute.Value = num3.ToString();
					xmlNode.Attributes.Append(xmlAttribute);
					xmlAttribute = ownerDocument.CreateAttribute("countAbnObjEE");
					xmlAttribute.Value = num4.ToString();
					xmlNode.Attributes.Append(xmlAttribute);
					xmlAttribute = ownerDocument.CreateAttribute("countAbnObjSource");
					xmlAttribute.Value = num5.ToString();
					xmlNode.Attributes.Append(xmlAttribute);
					xmlAttribute = ownerDocument.CreateAttribute("countAbnObj150");
					xmlAttribute.Value = num6.ToString();
					xmlNode.Attributes.Append(xmlAttribute);
					xmlAttribute = ownerDocument.CreateAttribute("countAbnObj150670");
					xmlAttribute.Value = num7.ToString();
					xmlNode.Attributes.Append(xmlAttribute);
					xmlAttribute = ownerDocument.CreateAttribute("countAbnObj670");
					xmlAttribute.Value = num8.ToString();
					xmlNode.Attributes.Append(xmlAttribute);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private static XmlDocument smethod_2(DataTable dataTable_11)
		{
			XmlDocument xmlDocument = new XmlDocument();
			XmlNode xmlNode = xmlDocument.CreateElement("AbnOff");
			xmlDocument.AppendChild(xmlNode);
			foreach (object obj in dataTable_11.Rows)
			{
				DataRow dataRow = (DataRow)obj;
				if (dataRow.RowState != DataRowState.Deleted)
				{
					XmlNode xmlNode2 = xmlDocument.CreateElement("Row");
					xmlNode.AppendChild(xmlNode2);
					XmlAttribute xmlAttribute = xmlDocument.CreateAttribute("idAbnObj");
					xmlAttribute.Value = dataRow["idAbnObj"].ToString();
					xmlNode2.Attributes.Append(xmlAttribute);
				}
			}
			return xmlDocument;
		}

		private void method_43()
		{
			this.dictionary_1 = new Dictionary<int, string>();
			this.dictionary_1.Add(1, "Создана");
			this.dictionary_1.Add(2, "Согласована");
			this.dictionary_1.Add(3, "Отправлена на сайт");
			this.dictionary_1.Add(104, "Зарегистрирована");
			this.dictionary_1.Add(105, "Отменена");
			this.dictionary_1.Add(106, "В работе");
			this.dictionary_1.Add(7, "Перенесено время работы");
			this.dictionary_1.Add(107, "Перенесено время работы");
			this.dictionary_1.Add(108, "Выполнена");
		}

		private void method_44()
		{
			if (this.int_0 > 0)
			{
				base.SelectSqlData(this.dataSetN.tJ_RequestForRepairLog, true, "where idRequest = " + this.int_0.ToString(), null, false, 0);
			}
		}

		private void method_45()
		{
			if (this.dataSetN.tJ_RequestForRepair.Rows.Count == 0)
			{
				return;
			}
			DataTable tJ_RequestForRepairLog = this.dataSetN.tJ_RequestForRepairLog;
			DataRow[] array = tJ_RequestForRepairLog.Select("idCommand = 108");
			if (array.Length != 0)
			{
				return;
			}
			DataTable dataTable_ = new DataTable("tUser");
			DataRow dataRow = this.dataSetN.tJ_RequestForRepair.Rows[0];
			if (dataRow.RowState == DataRowState.Added)
			{
				this.method_46(dataTable_, 1);
				if (dataRow["Agreed"] != DBNull.Value && Convert.ToBoolean(dataRow["Agreed"]))
				{
					this.method_46(dataTable_, 2);
				}
				if (dataRow["SendSite"] != DBNull.Value && Convert.ToBoolean(dataRow["SendSite"]))
				{
					this.method_46(dataTable_, 3);
				}
				if (dataRow["Agreed"] != DBNull.Value && Convert.ToBoolean(dataRow["Agreed"]) && dataRow["SendSite"] != DBNull.Value && Convert.ToBoolean(dataRow["SendSite"]))
				{
					this.method_46(dataTable_, 104);
				}
			}
			if (dataRow.RowState == DataRowState.Modified)
			{
				array = tJ_RequestForRepairLog.Select("idCommand = 2");
				if (array.Length == 0 && (dataRow["Agreed", DataRowVersion.Original] == DBNull.Value || !Convert.ToBoolean(dataRow["Agreed", DataRowVersion.Original])) && dataRow["Agreed"] != DBNull.Value && Convert.ToBoolean(dataRow["Agreed"]))
				{
					this.method_46(dataTable_, 2);
				}
				array = tJ_RequestForRepairLog.Select("idCommand = 3");
				if (array.Length == 0 && (dataRow["SendSite", DataRowVersion.Original] == DBNull.Value || !Convert.ToBoolean(dataRow["SendSite", DataRowVersion.Original])) && dataRow["SendSite"] != DBNull.Value && Convert.ToBoolean(dataRow["SendSite"]))
				{
					this.method_46(dataTable_, 3);
				}
				array = tJ_RequestForRepairLog.Select("idCommand = 104");
				if (array.Length == 0 && (dataRow["Agreed", DataRowVersion.Original] == DBNull.Value || !Convert.ToBoolean(dataRow["Agreed", DataRowVersion.Original]) || dataRow["SendSite", DataRowVersion.Original] == DBNull.Value || !Convert.ToBoolean(dataRow["SendSite", DataRowVersion.Original])) && dataRow["Agreed"] != DBNull.Value && Convert.ToBoolean(dataRow["Agreed"]) && dataRow["SendSite"] != DBNull.Value && Convert.ToBoolean(dataRow["SendSite"]))
				{
					this.method_46(dataTable_, 104);
				}
				array = tJ_RequestForRepairLog.Select("idCommand = 104");
				if (array.Length != 0 && dataRow["Agreed", DataRowVersion.Original] != DBNull.Value && Convert.ToBoolean(dataRow["Agreed", DataRowVersion.Original]) && dataRow["Agreed"] != DBNull.Value && !Convert.ToBoolean(dataRow["Agreed"]))
				{
					this.method_46(dataTable_, 105);
				}
				array = tJ_RequestForRepairLog.Select("idCommand = 105");
				if (array.Length != 0)
				{
					if (dataRow["Agreed", DataRowVersion.Original] != DBNull.Value && !Convert.ToBoolean(dataRow["Agreed", DataRowVersion.Original]) && dataRow["Agreed"] != DBNull.Value && Convert.ToBoolean(dataRow["Agreed"]))
					{
						this.method_46(dataTable_, 106);
					}
					array = tJ_RequestForRepairLog.Select("idCommand in (105, 7)", "datelog desc, id desc");
					if (array.Length != 0 && Convert.ToInt32(array[0]["idCommand"]) == 7)
					{
						this.method_46(dataTable_, 107);
					}
				}
			}
			if (dataRow.RowState != DataRowState.Added)
			{
				bool flag = false;
				foreach (DataRow dataRow2 in this.dataSetN.tJ_RequestForRepairDaily)
				{
					if (dataRow2.RowState != DataRowState.Added && dataRow2.RowState != DataRowState.Modified)
					{
						if (dataRow2.RowState != DataRowState.Deleted)
						{
							continue;
						}
					}
					flag = true;
					break;
				}
				if (flag)
				{
					DataRow[] array2 = tJ_RequestForRepairLog.Select("isSite = true", "datelog desc, id desc");
					if (array2.Length != 0)
					{
						if (Convert.ToInt32(array2[0]["idCommand"]) == 105)
						{
							this.method_46(dataTable_, 7);
						}
						else
						{
							this.method_46(dataTable_, 107);
						}
					}
				}
			}
			base.InsertSqlData(this.dataSetN.tJ_RequestForRepairLog);
			try
			{
				string cmdText = "declare @userlogId int\r\n                                    declare @userLog varchar(128)\r\n                                    declare @userLogName varchar(128)\r\n                                    \r\n                                    select  @userLogid = iduser, @userLog = SYSTEM_USER, @userLogname = name\r\n                                    from tuser where [login] = SYSTEM_USER\r\n                                    \r\n                                    insert into tJ_RequestForRepairLog(idRequest, datelog, userLogId, userLog, userLogName, idCommand, Command, isSite)\r\n                                    (select r.id, getdate(), @userlogId, @userLog, @userLogName, 108, 'Выполнена', 1\r\n                                      from tJ_RequestForRepair r\r\n                                    \tleft join tj_requestForRepairDaily d on d.id = (select top 1 id \r\n                                    \t\t\t\t\t\t\t\t\t\t\t\t\tfrom tJ_RequestForRepairDaily \r\n                                    \t\t\t\t\t\t\t\t\t\t\t\t\twhere idRequest = r.id\r\n                                    \t\t\t\t\t\t\t\t\t\t\t\t\torder by dateEnd desc)\r\n                                    where r.agreed = 1 and r.SendSite = 1\r\n                                    \tand not exists(select id from tJ_RequestForRepairLog where idRequest = r.id and idCommand = 108)\r\n                                    \tand d.dateEnd < getdate()\r\n                                    )";
				using (SqlConnection sqlConnection = new SqlConnection(this.SqlSettings.GetConnectionString()))
				{
					sqlConnection.Open();
					using (SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection))
					{
						sqlCommand.ExecuteNonQuery();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, ex.Source);
			}
		}

		private void method_46(DataTable dataTable_11, int int_4)
		{
			if (dataTable_11.Rows.Count == 0)
			{
				base.SelectSqlData(dataTable_11, true, "where [Login] = SYSTEM_USER", null, false, 0);
			}
			DataRow dataRow = this.dataSetN.tJ_RequestForRepairLog.NewRow();
			dataRow["idRequest"] = this.int_0;
			dataRow["dateLog"] = DateTime.Now;
			if (dataTable_11.Rows.Count > 0)
			{
				dataRow["userLogId"] = dataTable_11.Rows[0]["idUser"];
				dataRow["userLog"] = dataTable_11.Rows[0]["Login"];
				if (dataTable_11.Rows[0]["name"] != DBNull.Value)
				{
					dataRow["userLogName"] = dataTable_11.Rows[0]["name"];
				}
			}
			dataRow["idCommand"] = int_4;
			if (this.dictionary_1.ContainsKey(int_4))
			{
				dataRow["Command"] = this.dictionary_1[int_4];
			}
			if (int_4 > 100)
			{
				dataRow["isSite"] = true;
			}
			else
			{
				dataRow["isSite"] = false;
			}
			this.dataSetN.tJ_RequestForRepairLog.Rows.Add(dataRow);
		}

		private int int_0;

		private int int_1;

		private eActionRequestRepair eActionRequestRepair;

		private DateTime dateTime_0;

		private DateTime dateTime_1;

		private int int_2;

		private bool bool_0;

		private bool bool_1;

		private bool isSendRIC;

		private DataRow dataRow_0;

		private DataTable dataTable_0;

		private DataTable dataTable_1;

		private DataTable dataTable_2;

		private DataTable dataTable_3;

		private DataTable dataTable_4;

		private Dictionary<int, string> dictionary_0;

		private int int_3;

		private ElectricModel electricModel_0;

		private DataTable dataTable_5;

		private DataTable dataTable_6;

		private DataTable dataTable_7;

		private ElectricModel electricModel_1;

		private List<int> list_0;

		private Dictionary<int, string> dictionary_1;
	}
}
