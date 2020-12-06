using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using DataSql;
using FormLbr;
using Microsoft.Reporting.WinForms;

internal partial class Form11 : FormBase
{
	public Form11(Class548.Class567 class567_1, SQLSettings sqlsettings_0)
	{
		
		this.list_0 = new List<string>();
		this.list_1 = new List<string>();
		this.list_2 = new List<string>();
		this.string_0 = string.Empty;
		this.string_1 = string.Empty;
		this.string_2 = string.Empty;
		this.string_3 = string.Empty;
		this.string_4 = string.Empty;
		
		this.method_4();
		this.SqlSettings = sqlsettings_0;
		this.class567_0 = class567_1;
		this.class594_0.SqlConnection_0.ConnectionString = this.SqlSettings.GetConnectionString();
		this.class590_0.SqlConnection_0.ConnectionString = this.SqlSettings.GetConnectionString();
		this.class586_0.SqlConnection_0.ConnectionString = this.SqlSettings.GetConnectionString();
		this.class587_0.SqlConnection_0.ConnectionString = this.SqlSettings.GetConnectionString();
		this.class585_0.SqlConnection_0.ConnectionString = this.SqlSettings.GetConnectionString();
	}

	public Form11(DateTime dateTime_2, DateTime dateTime_3, SQLSettings sqlsettings_0)
	{
		
		this.list_0 = new List<string>();
		this.list_1 = new List<string>();
		this.list_2 = new List<string>();
		this.string_0 = string.Empty;
		this.string_1 = string.Empty;
		this.string_2 = string.Empty;
		this.string_3 = string.Empty;
		this.string_4 = string.Empty;
		
		this.method_4();
		this.SqlSettings = sqlsettings_0;
		this.bool_0 = true;
		this.dateTime_0 = dateTime_2;
		this.dateTime_1 = dateTime_3;
		this.class594_0.SqlConnection_0.ConnectionString = this.SqlSettings.GetConnectionString();
		this.class590_0.SqlConnection_0.ConnectionString = this.SqlSettings.GetConnectionString();
		this.class586_0.SqlConnection_0.ConnectionString = this.SqlSettings.GetConnectionString();
		this.class587_0.SqlConnection_0.ConnectionString = this.SqlSettings.GetConnectionString();
		this.class585_0.SqlConnection_0.ConnectionString = this.SqlSettings.GetConnectionString();
	}

	private void Form11_Load(object sender, EventArgs e)
	{
		SqlConnection sqlConnection = new SqlConnection(SqlDataConnect.GetConnectionString(this.SqlSettings));
		string cmdText = "select top 1 * from tSettings where Module = 'RequestODS'";
		sqlConnection.Open();
		SqlDataReader sqlDataReader = new SqlCommand(cmdText, sqlConnection).ExecuteReader();
		if (sqlDataReader.Read())
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(sqlDataReader["Settings"].ToString());
			XmlNode xmlNode = xmlDocument.SelectSingleNode("ApplSet");
			foreach (object obj in xmlNode.SelectNodes("NetArea"))
			{
				XmlNode xmlNode2 = (XmlNode)obj;
				this.list_0.Add(xmlNode2.Attributes["Name"].Value);
				this.list_1.Add(xmlNode2.Attributes["Genitive"].Value);
				this.list_2.Add(xmlNode2.Attributes["Abbreviation"].Value);
			}
			XmlNode xmlNode3 = xmlNode.SelectSingleNode("Ratifying");
			if (xmlNode3 != null)
			{
				this.string_0 = xmlNode3.Attributes["Post"].Value;
				this.string_1 = xmlNode3.Attributes["Name"].Value;
			}
			xmlNode3 = xmlNode.SelectSingleNode("Signer");
			if (xmlNode3 != null)
			{
				this.string_2 = xmlNode3.Attributes["Post"].Value;
				this.string_3 = xmlNode3.Attributes["Name"].Value;
			}
			xmlNode3 = xmlNode.SelectSingleNode("Performer");
			if (xmlNode3 != null)
			{
				this.string_4 = xmlNode3.Attributes["Name"].Value;
			}
		}
		if (this.bool_0)
		{
			this.method_0();
			return;
		}
		switch (this.class567_0.TypeAction)
		{
		case 0:
			this.method_3();
			return;
		case 1:
			this.method_2();
			return;
		case 2:
			this.method_1();
			return;
		default:
			return;
		}
	}

	private void method_0()
	{
		this.reportViewer_0.LocalReport.ReportEmbeddedResource = "Documents.Reports.ODSReport.rdlc";
		ReportDataSource reportDataSource = new ReportDataSource();
		reportDataSource.Name = "DataSet1";
		reportDataSource.Value = this.bindingSource_7;
		this.reportViewer_0.LocalReport.DataSources.Add(reportDataSource);
		if (this.dateTime_0 != DateTime.MinValue && this.dateTime_1 != DateTime.MinValue)
		{
			string value;
			if (this.dateTime_0.Date == this.dateTime_1.Date)
			{
				value = "за " + this.dateTime_0.Date.ToString("dd.MM.yyyy");
			}
			else
			{
				value = "за период с " + this.dateTime_0.ToString("dd.MM.yyyy") + " по " + this.dateTime_1.ToString("dd.MM.yyyy");
			}
			ReportParameter parameters = new ReportParameter("period", value);
			this.reportViewer_0.LocalReport.SetParameters(parameters);
		}
		this.reportViewer_0.RefreshReport();
	}

	private void method_1()
	{
		this.reportViewer_0.LocalReport.ReportEmbeddedResource = "Documents.Reports.ApplicationCancelReport.rdlc";
		if (this.class567_0.LegalAbns)
		{
			using (IEnumerator enumerator = this.bindingSource_1.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					Class548.Class568 @class = (Class548.Class568)((DataRowView)obj).Row;
					DataRow dataRow = this.class548_0.CancelReport1DataTable.NewRow();
					if (!@class.method_16())
					{
						dataRow[0] = @class.Code.ToString();
						if (!@class.method_14())
						{
							DataRow dataRow2 = dataRow;
							dataRow2[0] = dataRow2[0] + " от " + @class.DateDog.ToString("dd.MM.yyyy");
						}
					}
					dataRow[1] = @class.NameShort;
					dataRow[2] = @class.AbnObj;
					DateTime dateTime = Convert.ToDateTime(this.class585_0.vmethod_23(new int?(@class.IdCancelApl)));
					dataRow[3] = dateTime.ToString("dd.MM.yyyy") + " c " + dateTime.ToString("HH:mm");
					dataRow[4] = this.class587_0.vmethod_9(@class.Reason);
					dateTime = Convert.ToDateTime(this.class585_0.vmethod_24(new int?(@class.IdCancelApl)));
					dataRow[5] = "№" + @class.IdCancelApl.ToString() + " от " + dateTime.ToString("dd.MM.yyyy");
					this.class548_0.CancelReport1DataTable.Rows.Add(dataRow);
				}
				goto IL_36D;
			}
		}
		foreach (object obj2 in this.bindingSource_0)
		{
			Class548.Class572 class2 = (Class548.Class572)((DataRowView)obj2).Row;
			DataRow dataRow3 = this.class548_0.CancelReport1DataTable.NewRow();
			if (!class2.method_18())
			{
				dataRow3[0] = class2.Code.ToString();
				if (!class2.method_20())
				{
					DataRow dataRow2 = dataRow3;
					dataRow2[0] = dataRow2[0] + " от " + class2.DateDog.ToString("dd.MM.yyyy");
				}
			}
			if (!class2.method_2())
			{
				dataRow3[1] = class2.FIO;
			}
			dataRow3[2] = class2.Address;
			DateTime dateTime2 = Convert.ToDateTime(this.class585_0.vmethod_23(new int?(class2.IdCancelApl)));
			dataRow3[3] = dateTime2.ToString("dd.MM.yyyy") + " c " + dateTime2.ToString("HH:mm");
			if (!class2.method_8())
			{
				dataRow3[4] = this.class587_0.vmethod_9(class2.Reason);
			}
			dateTime2 = Convert.ToDateTime(this.class585_0.vmethod_24(new int?(class2.IdCancelApl)));
			dataRow3[5] = "№" + class2.IdCancelApl.ToString() + " от " + dateTime2.ToString("dd.MM.yyyy");
			this.class548_0.CancelReport1DataTable.Rows.Add(dataRow3);
		}
		IL_36D:
		ReportParameter parameters = new ReportParameter("NumAndDateApplication", string.Concat(new object[]
		{
			"№ ",
			this.class567_0.Id,
			" от ",
			this.class567_0.DateAppl.ToString("dd.MM.yyyy")
		}));
		this.reportViewer_0.LocalReport.SetParameters(parameters);
		parameters = new ReportParameter("RatifyingName", this.string_1);
		this.reportViewer_0.LocalReport.SetParameters(parameters);
		parameters = new ReportParameter("RatifyingPost", this.string_0);
		this.reportViewer_0.LocalReport.SetParameters(parameters);
		parameters = new ReportParameter("SignerPost", this.string_2);
		this.reportViewer_0.LocalReport.SetParameters(parameters);
		parameters = new ReportParameter("SignerName", this.string_3);
		this.reportViewer_0.LocalReport.SetParameters(parameters);
		parameters = new ReportParameter("Performer", this.string_4);
		this.reportViewer_0.LocalReport.SetParameters(parameters);
		string value = "";
		if (this.list_0.Count > this.class567_0.NetArea)
		{
			value = this.list_0[this.class567_0.NetArea];
		}
		else
		{
			switch (this.class567_0.NetArea)
			{
			case 0:
				value = "1 сетевой район";
				break;
			case 1:
				value = "2 сетевой район";
				break;
			case 2:
				value = "3 сетевой район";
				break;
			case 3:
				value = "4 сетевой район";
				break;
			case 4:
				value = "ОДС";
				break;
			}
		}
		ReportParameter parameters2 = new ReportParameter("toExecuter", value);
		this.reportViewer_0.LocalReport.SetParameters(parameters2);
		ReportDataSource reportDataSource = new ReportDataSource();
		reportDataSource.Name = "CancelReport";
		reportDataSource.Value = this.class548_0.CancelReport1DataTable;
		this.reportViewer_0.LocalReport.DataSources.Add(reportDataSource);
		this.reportViewer_0.RefreshReport();
	}

	private void method_2()
	{
		this.reportViewer_0.LocalReport.ReportEmbeddedResource = "Documents.Reports.ApplicationResumptionReport.rdlc";
		if (this.class567_0.LegalAbns)
		{
			using (IEnumerator enumerator = this.bindingSource_1.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					Class548.Class568 @class = (Class548.Class568)((DataRowView)obj).Row;
					DataRow dataRow = this.class548_0.Report1DataTable.NewRow();
					if (!@class.method_16())
					{
						dataRow[0] = @class.Code.ToString();
						if (!@class.method_14())
						{
							DataRow dataRow2 = dataRow;
							dataRow2[0] = dataRow2[0] + " от " + @class.DateDog.ToString("dd.MM.yyyy");
						}
					}
					if (!@class.method_18())
					{
						dataRow[1] = @class.NameShort;
					}
					if (!@class.method_20())
					{
						dataRow[2] = @class.AbnObj;
					}
					if (!@class.method_8())
					{
						dataRow[3] = @class.PlaceId;
					}
					if (!this.class567_0.method_8())
					{
						dataRow[4] = this.class567_0.DateAction.ToString("dd.MM.yyyy") + " c " + this.class567_0.DateAction.ToString("HH:mm");
					}
					if (!@class.method_10())
					{
						dataRow[5] = this.class587_0.vmethod_9(@class.Reason);
					}
					if (!@class.method_12())
					{
						dataRow[6] = @class.Comments;
					}
					this.class548_0.Report1DataTable.Rows.Add(dataRow);
				}
				goto IL_352;
			}
		}
		foreach (object obj2 in this.bindingSource_0)
		{
			Class548.Class572 class2 = (Class548.Class572)((DataRowView)obj2).Row;
			DataRow dataRow3 = this.class548_0.Report1DataTable.NewRow();
			if (!class2.method_18())
			{
				dataRow3[0] = class2.Code.ToString();
				if (!class2.method_20())
				{
					DataRow dataRow2 = dataRow3;
					dataRow2[0] = dataRow2[0] + " от " + class2.DateDog.ToString("dd.MM.yyyy");
				}
			}
			if (!class2.method_2())
			{
				dataRow3[1] = class2.FIO;
			}
			if (!class2.method_4())
			{
				dataRow3[2] = class2.Address;
			}
			if (!class2.method_24())
			{
				dataRow3[3] = class2.Point;
			}
			dataRow3[4] = this.class567_0.DateAction.ToString("dd.MM.yyyy") + " c " + this.class567_0.DateAction.ToString("HH:mm");
			if (!class2.method_8())
			{
				dataRow3[5] = this.class587_0.vmethod_9(class2.Reason);
			}
			if (!class2.method_12())
			{
				dataRow3[6] = class2.Comments;
			}
			this.class548_0.Report1DataTable.Rows.Add(dataRow3);
		}
		IL_352:
		ReportParameter parameters = new ReportParameter("NumAndDateApplication", string.Concat(new object[]
		{
			"№ ",
			this.class567_0.Id,
			" от ",
			this.class567_0.DateAppl.ToString("dd.MM.yyyy")
		}));
		this.reportViewer_0.LocalReport.SetParameters(parameters);
		parameters = new ReportParameter("RatifyingName", this.string_1);
		this.reportViewer_0.LocalReport.SetParameters(parameters);
		parameters = new ReportParameter("RatifyingPost", this.string_0);
		this.reportViewer_0.LocalReport.SetParameters(parameters);
		parameters = new ReportParameter("SignerPost", this.string_2);
		this.reportViewer_0.LocalReport.SetParameters(parameters);
		parameters = new ReportParameter("SignerName", this.string_3);
		this.reportViewer_0.LocalReport.SetParameters(parameters);
		parameters = new ReportParameter("Performer", this.string_4);
		this.reportViewer_0.LocalReport.SetParameters(parameters);
		string str = "";
		if (this.list_1.Count > this.class567_0.NetArea)
		{
			str = this.list_1[this.class567_0.NetArea];
		}
		else
		{
			switch (this.class567_0.NetArea)
			{
			case 0:
				str = "сетевого района №1";
				break;
			case 1:
				str = "сетевого района №2";
				break;
			case 2:
				str = "сетевого района №3";
				break;
			case 3:
				str = "сетевого района №4";
				break;
			case 4:
				str = "ОДС";
				break;
			}
		}
		ReportParameter parameters2 = new ReportParameter("toExecuter", "Начальнику " + str + " произвести ВОЗОБНОВЛЕНИЕ");
		this.reportViewer_0.LocalReport.SetParameters(parameters2);
		this.reportViewer_0.RefreshReport();
	}

	private void method_3()
	{
		this.reportViewer_0.LocalReport.ReportEmbeddedResource = "Documents.Reports.ApplicationReport.rdlc";
		if (this.class567_0.LegalAbns)
		{
			using (IEnumerator enumerator = this.bindingSource_1.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					Class548.Class568 @class = (Class548.Class568)((DataRowView)obj).Row;
					DataRow dataRow = this.class548_0.Report1DataTable.NewRow();
					if (!@class.method_16())
					{
						dataRow[0] = @class.Code.ToString();
						if (!@class.method_14())
						{
							DataRow dataRow2 = dataRow;
							dataRow2[0] = dataRow2[0] + " от " + @class.DateDog.ToString("dd.MM.yyyy");
						}
					}
					if (!@class.method_18())
					{
						dataRow[1] = @class.NameShort;
					}
					if (!@class.method_20())
					{
						dataRow[2] = @class.AbnObj;
					}
					if (!@class.method_8())
					{
						dataRow[3] = @class.PlaceId;
					}
					dataRow[4] = this.class567_0.DateAction.ToString("dd.MM.yyyy") + " c " + this.class567_0.DateAction.ToString("HH:mm");
					if (!@class.method_10())
					{
						dataRow[5] = this.class587_0.vmethod_9(@class.Reason);
					}
					if (!@class.method_12())
					{
						dataRow[6] = @class.Comments;
					}
					if (!@class.method_58())
					{
						if (@class.IsFullRestriction)
						{
							dataRow[7] = "Полное";
						}
						else
						{
							dataRow[7] = "Частичное";
						}
					}
					this.class548_0.Report1DataTable.Rows.Add(dataRow);
				}
				goto IL_3B0;
			}
		}
		foreach (object obj2 in this.bindingSource_0)
		{
			Class548.Class572 class2 = (Class548.Class572)((DataRowView)obj2).Row;
			DataRow dataRow3 = this.class548_0.Report1DataTable.NewRow();
			if (!class2.method_18())
			{
				dataRow3[0] = class2.Code.ToString();
				if (!class2.method_20())
				{
					DataRow dataRow2 = dataRow3;
					dataRow2[0] = dataRow2[0] + " от " + class2.DateDog.ToString("dd.MM.yyyy");
				}
			}
			if (!class2.method_2())
			{
				dataRow3[1] = class2.FIO;
			}
			if (!class2.method_4())
			{
				dataRow3[2] = class2.Address;
			}
			if (!class2.method_6())
			{
				dataRow3[3] = class2.Point;
			}
			dataRow3[4] = this.class567_0.DateAction.ToString("dd.MM.yyyy") + " c " + this.class567_0.DateAction.ToString("HH:mm");
			if (!class2.method_8())
			{
				dataRow3[5] = this.class587_0.vmethod_9(class2.Reason);
			}
			if (!class2.method_12())
			{
				dataRow3[6] = class2.Comments;
			}
			if (!class2.method_54())
			{
				if (class2.IsFullRestriction)
				{
					dataRow3[7] = "Полное";
				}
				else
				{
					dataRow3[7] = "Частичное";
				}
			}
			this.class548_0.Report1DataTable.Rows.Add(dataRow3);
		}
		IL_3B0:
		ReportParameter parameters = new ReportParameter("NumAndDateApplication", string.Concat(new object[]
		{
			"№ ",
			this.class567_0.Id,
			" от ",
			this.class567_0.DateAppl.ToString("dd.MM.yyyy")
		}));
		this.reportViewer_0.LocalReport.SetParameters(parameters);
		parameters = new ReportParameter("RatifyingName", this.string_1);
		this.reportViewer_0.LocalReport.SetParameters(parameters);
		parameters = new ReportParameter("RatifyingPost", this.string_0);
		this.reportViewer_0.LocalReport.SetParameters(parameters);
		parameters = new ReportParameter("SignerPost", this.string_2);
		this.reportViewer_0.LocalReport.SetParameters(parameters);
		parameters = new ReportParameter("SignerName", this.string_3);
		this.reportViewer_0.LocalReport.SetParameters(parameters);
		parameters = new ReportParameter("Performer", this.string_4);
		this.reportViewer_0.LocalReport.SetParameters(parameters);
		string str = "";
		if (this.list_1.Count > this.class567_0.NetArea)
		{
			str = this.list_1[this.class567_0.NetArea];
		}
		else
		{
			switch (this.class567_0.NetArea)
			{
			case 0:
				str = "сетевого района 1";
				break;
			case 1:
				str = "сетевого района 2";
				break;
			case 2:
				str = "сетевого района 3";
				break;
			case 3:
				str = "сетевого района 4";
				break;
			case 4:
				str = "ОДС";
				break;
			}
		}
		ReportParameter parameters2 = new ReportParameter("toExecuter", "Начальнику " + str + " произвести ОТКЛЮЧЕНИЕ");
		this.reportViewer_0.LocalReport.SetParameters(parameters2);
		this.reportViewer_0.RefreshReport();
	}

	private void method_4()
	{
		this.icontainer_0 = new Container();
		ReportDataSource reportDataSource = new ReportDataSource();
		this.bindingSource_4 = new BindingSource(this.icontainer_0);
		this.class548_0 = new Class548();
		this.reportViewer_0 = new ReportViewer();
		this.bindingSource_1 = new BindingSource(this.icontainer_0);
		this.class586_0 = new Class586();
		this.bindingSource_2 = new BindingSource(this.icontainer_0);
		this.class587_0 = new Class587();
		this.bindingSource_0 = new BindingSource(this.icontainer_0);
		this.class590_0 = new Class590();
		this.bindingSource_3 = new BindingSource(this.icontainer_0);
		this.class594_0 = new Class594();
		this.bindingSource_5 = new BindingSource(this.icontainer_0);
		this.bindingSource_6 = new BindingSource(this.icontainer_0);
		this.class585_0 = new Class585();
		this.bindingSource_7 = new BindingSource(this.icontainer_0);
		((ISupportInitialize)this.bindingSource_4).BeginInit();
		((ISupportInitialize)this.class548_0).BeginInit();
		((ISupportInitialize)this.bindingSource_1).BeginInit();
		((ISupportInitialize)this.bindingSource_2).BeginInit();
		((ISupportInitialize)this.bindingSource_0).BeginInit();
		((ISupportInitialize)this.bindingSource_3).BeginInit();
		((ISupportInitialize)this.bindingSource_5).BeginInit();
		((ISupportInitialize)this.bindingSource_6).BeginInit();
		((ISupportInitialize)this.bindingSource_7).BeginInit();
		base.SuspendLayout();
		this.bindingSource_4.DataMember = "Report1DataTable";
		this.bindingSource_4.DataSource = this.class548_0;
		this.class548_0.DataSetName = "OrgDataSet";
		this.class548_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		this.reportViewer_0.Dock = DockStyle.Fill;
		reportDataSource.Name = "Reptab";
		reportDataSource.Value = this.bindingSource_4;
		this.reportViewer_0.LocalReport.DataSources.Add(reportDataSource);
		this.reportViewer_0.LocalReport.ReportEmbeddedResource = "Documents.Reports.ApplicationReport.rdlc";
		this.reportViewer_0.Location = new Point(0, 0);
		this.reportViewer_0.Name = "reportViewer1";
		this.reportViewer_0.Size = new Size(727, 525);
		this.reportViewer_0.TabIndex = 0;
		this.bindingSource_1.DataMember = "tblAbnAplForDisconObjects";
		this.bindingSource_1.DataSource = this.class548_0;
		this.class586_0.Boolean_0 = true;
		this.bindingSource_2.DataMember = "tblAbnAplForDisconReason";
		this.bindingSource_2.DataSource = this.class548_0;
		this.class587_0.Boolean_0 = true;
		this.bindingSource_0.DataMember = "tblAbnAplForDisconIndividualUsers";
		this.bindingSource_0.DataSource = this.class548_0;
		this.class590_0.Boolean_0 = true;
		this.bindingSource_3.DataMember = "tblAbnAplConnectPointForIndividualUsers";
		this.bindingSource_3.DataSource = this.class548_0;
		this.class594_0.Boolean_0 = true;
		this.bindingSource_5.DataMember = "CancelReport1DataTable";
		this.bindingSource_5.DataSource = this.class548_0;
		this.bindingSource_6.DataMember = "tblAbnAplForDiscon";
		this.bindingSource_6.DataSource = this.class548_0;
		this.class585_0.Boolean_0 = true;
		this.bindingSource_7.DataMember = "ReportODS";
		this.bindingSource_7.DataSource = this.class548_0;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(727, 525);
		base.Controls.Add(this.reportViewer_0);
		base.Name = "FormLegalApplReport";
		this.Text = "Печатная форма";
		base.Load += this.Form11_Load;
		((ISupportInitialize)this.bindingSource_4).EndInit();
		((ISupportInitialize)this.class548_0).EndInit();
		((ISupportInitialize)this.bindingSource_1).EndInit();
		((ISupportInitialize)this.bindingSource_2).EndInit();
		((ISupportInitialize)this.bindingSource_0).EndInit();
		((ISupportInitialize)this.bindingSource_3).EndInit();
		((ISupportInitialize)this.bindingSource_5).EndInit();
		((ISupportInitialize)this.bindingSource_6).EndInit();
		((ISupportInitialize)this.bindingSource_7).EndInit();
		base.ResumeLayout(false);
	}

	internal static void Lvw82VF3chiQwOm84Gr(Form form_0, bool bool_1)
	{
		form_0.Dispose(bool_1);
	}

	private Class548.Class567 class567_0;

	private bool bool_0;

	private DateTime dateTime_0;

	private DateTime dateTime_1;

	private List<string> list_0;

	private List<string> list_1;

	private List<string> list_2;

	private string string_0;

	private string string_1;

	private string string_2;

	private string string_3;

	private string string_4;

	private ReportViewer reportViewer_0;

	private Class548 class548_0;

	private Class586 class586_0;

	private Class587 class587_0;

	private Class590 class590_0;

	private Class594 class594_0;

	public BindingSource bindingSource_0;

	public BindingSource bindingSource_1;

	public BindingSource bindingSource_2;

	public BindingSource bindingSource_3;

	private BindingSource bindingSource_4;

	private BindingSource bindingSource_5;

	private BindingSource bindingSource_6;

	private Class585 class585_0;

	public BindingSource bindingSource_7;
}
