using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using DataSql;
using FormLbr;
using Microsoft.Reporting.WinForms;

internal partial class Form44 : FormBase
{
	[CompilerGenerated]
	internal Enum13 method_0()
	{
		return this.enum13_0;
	}

	[CompilerGenerated]
	internal void method_1(Enum13 enum13_1)
	{
		this.enum13_0 = enum13_1;
	}

	[CompilerGenerated]
	internal int method_2()
	{
		return this.int_0;
	}

	[CompilerGenerated]
	internal void method_3(int int_9)
	{
		this.int_0 = int_9;
	}

	[CompilerGenerated]
	internal int method_4()
	{
		return this.int_1;
	}

	[CompilerGenerated]
	internal void method_5(int int_9)
	{
		this.int_1 = int_9;
	}

	[CompilerGenerated]
	internal int method_6()
	{
		return this.int_2;
	}

	[CompilerGenerated]
	internal void method_7(int int_9)
	{
		this.int_2 = int_9;
	}

	[CompilerGenerated]
	internal int method_8()
	{
		return this.int_3;
	}

	[CompilerGenerated]
	internal void method_9(int int_9)
	{
		this.int_3 = int_9;
	}

	internal int IdBus { get; set; }

	[CompilerGenerated]
	internal int method_10()
	{
		return this.int_5;
	}

	[CompilerGenerated]
	internal void method_11(int int_9)
	{
		this.int_5 = int_9;
	}

	internal int Year { get; set; }

	[CompilerGenerated]
	internal int method_12()
	{
		return this.int_7;
	}

	[CompilerGenerated]
	internal void method_13(int int_9)
	{
		this.int_7 = int_9;
	}

	[CompilerGenerated]
	internal decimal method_14()
	{
		return this.decimal_0;
	}

	[CompilerGenerated]
	internal void method_15(decimal decimal_2)
	{
		this.decimal_0 = decimal_2;
	}

	[CompilerGenerated]
	internal int method_16()
	{
		return this.int_8;
	}

	[CompilerGenerated]
	internal void method_17(int int_9)
	{
		this.int_8 = int_9;
	}

	[CompilerGenerated]
	internal bool method_18()
	{
		return this.bool_0;
	}

	[CompilerGenerated]
	internal void method_19(bool bool_4)
	{
		this.bool_0 = bool_4;
	}

	[CompilerGenerated]
	internal decimal method_20()
	{
		return this.decimal_1;
	}

	[CompilerGenerated]
	internal void method_21(decimal decimal_2)
	{
		this.decimal_1 = decimal_2;
	}

	[CompilerGenerated]
	internal bool method_22()
	{
		return this.bool_1;
	}

	[CompilerGenerated]
	internal void method_23(bool bool_4)
	{
		this.bool_1 = bool_4;
	}

	[CompilerGenerated]
	internal bool method_24()
	{
		return this.bool_2;
	}

	[CompilerGenerated]
	internal void method_25(bool bool_4)
	{
		this.bool_2 = bool_4;
	}

	[CompilerGenerated]
	internal bool method_26()
	{
		return this.bool_3;
	}

	[CompilerGenerated]
	internal void method_27(bool bool_4)
	{
		this.bool_3 = bool_4;
	}

	internal Form44()
	{
		
		
		this.method_47();
	}

	internal Form44(SQLSettings sqlsettings_0, int int_9, int int_10, decimal decimal_2)
	{
		
		
		this.method_47();
		this.SqlSettings = sqlsettings_0;
		this.Year = int_9;
		this.method_13(int_10);
		this.method_15(decimal_2);
		this.method_1((Enum13)3);
	}

	internal Form44(SQLSettings sqlsettings_0, Enum13 enum13_1, int int_9, int int_10, int int_11, bool bool_4, decimal decimal_2, bool bool_5, bool bool_6, bool bool_7)
	{
		
		
		this.method_47();
		this.SqlSettings = sqlsettings_0;
		this.Year = int_9;
		this.method_13(int_10);
		this.method_17(int_11);
		this.method_19(bool_4);
		this.method_21(decimal_2);
		this.method_23(bool_5);
		this.method_25(bool_6);
		this.method_27(bool_7);
		this.method_1(enum13_1);
	}

	internal Form44(SQLSettings sqlsettings_0, Enum13 enum13_1, int int_9, int int_10, int int_11)
	{
		
		
		this.method_47();
		this.SqlSettings = sqlsettings_0;
		this.method_1(enum13_1);
		this.method_3(int_9);
		this.method_11(int_10);
		if (enum13_1 == (Enum13)0)
		{
			this.method_5(int_11);
			return;
		}
		if (enum13_1 != (Enum13)2)
		{
			return;
		}
		this.method_7(int_11);
	}

	internal Form44(SQLSettings sqlsettings_0, Enum13 enum13_1, int int_9, int int_10, int int_11 = -1, int int_12 = -1)
	{
		
		
		this.method_47();
		this.SqlSettings = sqlsettings_0;
		this.method_1(enum13_1);
		this.method_3(int_9);
		this.IdBus = int_10;
		this.method_11(int_11);
		if (enum13_1 == (Enum13)0)
		{
			this.method_5(int_12);
			return;
		}
		if (enum13_1 != (Enum13)2)
		{
			return;
		}
		this.method_7(int_12);
	}

	private void Form44_Load(object sender, EventArgs e)
	{
		this.method_28();
	}

	private void method_28()
	{
		this.reportViewer_0.Clear();
		this.reportViewer_0.Reset();
		this.method_29();
		string reportEmbeddedResource = this.method_30(this.method_0());
		this.reportViewer_0.LocalReport.ReportEmbeddedResource = reportEmbeddedResource;
		this.tableLayoutPanel_0.RowStyles[0] = new RowStyle(SizeType.Absolute, (this.method_0() == (Enum13)0) ? 29f : 0f);
		this.reportViewer_0.LocalReport.DataSources.Clear();
		if (this.method_0() == (Enum13)0 || this.method_0() == (Enum13)2)
		{
			this.reportViewer_0.LocalReport.DataSources.Add(new ReportDataSource("dsMeasurement", this.method_31()));
			this.reportViewer_0.LocalReport.DataSources.Add(new ReportDataSource("dsMeasTransfPassport", this.method_32()));
		}
		if (this.method_0() == (Enum13)0)
		{
			this.reportViewer_0.LocalReport.DataSources.Add(new ReportDataSource("dsVoltageTransf", this.method_33()));
			if (this.checkBox_0.Checked)
			{
				this.reportViewer_0.LocalReport.DataSources.Add(new ReportDataSource("dsMeasCable", this.method_35()));
			}
			else
			{
				this.reportViewer_0.LocalReport.DataSources.Add(new ReportDataSource("dsMeasCable", this.method_36()));
			}
			this.reportViewer_0.LocalReport.DataSources.Add(new ReportDataSource("dsMeasCableRatio", this.method_39()));
		}
		if (this.method_0() == (Enum13)1)
		{
			this.reportViewer_0.LocalReport.DataSources.Add(new ReportDataSource("dsMeasurement", this.method_31()));
			BindingSource dataSourceValue = this.method_36();
			this.reportViewer_0.LocalReport.DataSources.Add(new ReportDataSource("dsMeasCable", dataSourceValue));
			this.reportViewer_0.LocalReport.DataSources.Add(new ReportDataSource("dsMeasCableRatio", this.method_39()));
		}
		if (this.method_0() == (Enum13)2)
		{
			this.reportViewer_0.LocalReport.DataSources.Add(new ReportDataSource("dsMeasTransfAmperage", this.method_34()));
			this.reportViewer_0.LocalReport.DataSources.Add(new ReportDataSource("dtAddlData", this.method_41()));
			this.reportViewer_0.LocalReport.DataSources.Add(new ReportDataSource("dsMeasCell", this.method_38()));
			this.reportViewer_0.LocalReport.DataSources.Add(new ReportDataSource("dsMeasCellRatio", this.method_40()));
		}
		if (this.method_0() == (Enum13)3)
		{
			this.reportViewer_0.LocalReport.DataSources.Add(new ReportDataSource("dsExcelessLoad", this.method_42()));
			this.reportViewer_0.LocalReport.DataSources.Add(new ReportDataSource("dsAddl", this.method_43()));
		}
		if (this.method_0() == (Enum13)4)
		{
			this.reportViewer_0.LocalReport.DataSources.Add(new ReportDataSource("dsCoefficientLoading", this.method_44()));
			this.reportViewer_0.LocalReport.DataSources.Add(new ReportDataSource("dsAddl", this.method_45()));
		}
		if (this.method_0() == (Enum13)5)
		{
			this.reportViewer_0.LocalReport.DataSources.Add(new ReportDataSource("dsCoefficientIrregularity", this.method_46()));
			this.reportViewer_0.LocalReport.DataSources.Add(new ReportDataSource("dsAddl", this.method_45()));
		}
		this.reportViewer_0.RefreshReport();
	}

	private void method_29()
	{
		switch (this.method_0())
		{
		case (Enum13)0:
			this.Text = "Отчет по замерам низкой стороны";
			return;
		case (Enum13)1:
			break;
		case (Enum13)2:
			this.Text = "Отчет по замерам высокой стороны";
			return;
		case (Enum13)3:
			this.Text = "Превышение нагрузки";
			return;
		case (Enum13)4:
			this.Text = "Анализ коэффициента загрузки трансформаторов";
			return;
		case (Enum13)5:
			this.Text = "Анализ коэффициента неравномерности фаз";
			return;
		case (Enum13)6:
			this.Text = "Трансформаторы по центрам питания";
			break;
		default:
			return;
		}
	}

	private string method_30(Enum13 enum13_1)
	{
		switch (enum13_1)
		{
		case (Enum13)0:
			if (this.checkBox_1.Checked)
			{
				return "Documents.Forms.Measurement.ReportMeasLowVoltageWithOutNameObj.rdlc";
			}
			return "Documents.Forms.Measurement.ReportMeasLowVoltage.rdlc";
		case (Enum13)1:
			return "Documents.Forms.Measurement.ReportMeasLowVoltageSP.rdlc";
		case (Enum13)2:
			return "Documents.Forms.Measurement.ReportMeasHighVoltage.rdlc";
		case (Enum13)3:
			return "Documents.Forms.Measurement.ReportExcelessLoad.rdlc";
		case (Enum13)4:
			return "Documents.Forms.Measurement.ReportCoefficientLoading.rdlc";
		case (Enum13)5:
			return "Documents.Forms.Measurement.ReportCoefficientIrregularity.rdlc";
		case (Enum13)6:
			return "Documents.Forms.Measurement.";
		default:
			return "";
		}
	}

	private BindingSource method_31()
	{
		base.SelectSqlData(this.class255_0, this.class255_0.vJ_MeasurementReport, true, "WHERE id = " + this.method_2().ToString());
		return new BindingSource
		{
			DataSource = this.class255_0.vJ_MeasurementReport
		};
	}

	private BindingSource method_32()
	{
		base.CallSQLTableValuedFunction(this.class255_0, this.class255_0.fn_J_MeasTransfPassport, "", new string[]
		{
			this.method_10().ToString()
		});
		return new BindingSource
		{
			DataSource = this.class255_0.fn_J_MeasTransfPassport
		};
	}

	private BindingSource method_33()
	{
		base.SelectSqlData(this.class255_0, this.class255_0.vJ_MeasTransfVoltage, true, string.Format("WHERE id = {0}", this.method_4()));
		return new BindingSource
		{
			DataSource = this.class255_0.vJ_MeasTransfVoltage
		};
	}

	private BindingSource method_34()
	{
		base.SelectSqlData(this.class255_0, this.class255_0.tJ_MeasAmperageTransf, true, string.Format("WHERE id = {0}", this.method_6()));
		return new BindingSource
		{
			DataSource = this.class255_0.tJ_MeasAmperageTransf
		};
	}

	private BindingSource method_35()
	{
		base.SelectSqlData(this.class255_0, this.class255_0.vJ_MeasCableReport, true, string.Format("WHERE idMeasurement = {0} AND idBus = {1} AND idTransf = {2} ORDER BY CONVERT(BIGINT, CASE WHEN CellName like '%[^0-9]%' THEN SUBSTRING(CellName,1,PATINDEX('%[^0-9]%',CellName)-1) ELSE CellName END)", this.method_2(), this.IdBus, this.method_10()));
		return new BindingSource
		{
			DataSource = this.class255_0.vJ_MeasCableReport
		};
	}

	private BindingSource method_36()
	{
		this.class255_0.vJ_MeasCableReport2.Rows.Clear();
		base.SelectSqlData(this.class255_0, this.class255_0.vJ_MeasCableReport2, true, string.Format("WHERE idMeasurement = {0} AND idBus = {1} AND idTransf = {2} ORDER BY CONVERT(BIGINT, CASE WHEN CellName like '%[^0-9]%' THEN SUBSTRING(CellName,1,PATINDEX('%[^0-9]%',CellName)-1) ELSE CellName END), Company, Street, House", this.method_2(), this.IdBus, this.method_10()));
		var dataSource = (from row in this.class255_0.vJ_MeasCableReport2
		group row by new
		{
			id = ((row["id"] != null) ? row["id"] : -1),
			idMeasurement = ((row["idMeasurement"] != null) ? row["idMeasurement"] : -1),
			idBus = ((row["idBus"] != null) ? row["idBus"] : -1),
			idTransf = ((row["idTransf"] != null) ? row["idTransf"] : -1),
			idCell = ((row["idCell"] != null) ? row["idCell"] : -1),
			CellName = ((row["CellName"] != null) ? row["CellName"] : ""),
			idCable = ((row["idCable"] != null) ? row["idCable"] : -1),
			idSchmAbn = ((row["idSchmAbn"] != null) ? row["idSchmAbn"] : -1),
			Makeup = ((row["Makeup"] != null) ? row["Makeup"] : ""),
			Voltage = ((row["Voltage"] != null) ? row["Voltage"] : -1),
			Wires = ((row["Wires"] != null) ? row["Wires"] : -1),
			CrossSection = Convert.ToDouble((row["CrossSection"] != DBNull.Value) ? row["CrossSection"] : 0),
			PermisAmperage = Convert.ToDouble((row["PermisAmperage"] != DBNull.Value) ? row["PermisAmperage"] : 0),
			Iad = ((row["Iad"] != null) ? row["Iad"] : -1),
			Ian = ((row["Ian"] != null) ? row["Ian"] : -1),
			Ibd = ((row["Ibd"] != null) ? row["Ibd"] : -1),
			Ibn = ((row["Ibn"] != null) ? row["Ibn"] : -1),
			Icd = ((row["Icd"] != null) ? row["Icd"] : -1),
			Icn = ((row["Icn"] != null) ? row["Icn"] : -1),
			Iod = ((row["Iod"] != null) ? row["Iod"] : -1),
			Ion = ((row["Ion"] != null) ? row["Ion"] : -1),
			Comment = ((row["Comment"] != null) ? row["Comment"] : "")
		}).Select(new Func<IGrouping<<>f__AnonymousType11<object, object, object, object, object, object, object, object, object, object, object, double, double, object, object, object, object, object, object, object, object, object>, Class255.Class438>, <>f__AnonymousType12<object, object, object, object, object, object, string, object, object, object, object, double, double, object, object, object, object, object, object, object, object>>(this.method_48)).AsEnumerable();
		return new BindingSource
		{
			DataSource = dataSource
		};
	}

	private string method_37(Class255.Class332 class332_0, int int_9, int int_10)
	{
		var source = from r in class332_0
		where r["House"] != DBNull.Value
		select r into row
		group row by new
		{
			idCell = ((row["idCell"] == DBNull.Value) ? -1 : row.idCell),
			idCable = ((row["idCable"] == DBNull.Value) ? -1 : row.idCable),
			Street = ((row["Street"] == DBNull.Value) ? "" : row.Street.ToString())
		} into g
		where g.Key.idCell == int_9 && g.Key.idCable == int_10
		select new
		{
			idCell = g.Key.idCell,
			idCable = g.Key.idCable,
			Street = g.Key.Street,
			House = Form44.smethod_0((from r in class332_0
			where ((r["idCell"] == DBNull.Value) ? -1 : r.idCell) == int_9 && ((r["idCable"] == DBNull.Value) ? -1 : r.idCable) == int_10 && ((r["Street"] == DBNull.Value) ? "" : r.Street) == g.Key.Street
			orderby r.House
			select r.FullHouse).Distinct<string>().ToArray<string>())
		};
		return string.Join("; ", (from r in source
		select r.Street + ", " + r.House).ToArray<string>());
	}

	private static string smethod_0(string[] string_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < string_0.Length; i++)
		{
			int num;
			if (int.TryParse(string_0[i], out num))
			{
				int num2;
				while (i < string_0.Length - 1 && int.TryParse(string_0[i + 1], out num2))
				{
					if (int.Parse(string_0[i]) + 1 != num2)
					{
						break;
					}
					i++;
				}
				int num3 = int.Parse(string_0[i]);
				stringBuilder.Append((num == num3) ? (num.ToString() + ((i < string_0.Length - 1) ? "," : "")) : ((num == num3 - 1) ? string.Concat(new object[]
				{
					num,
					",",
					num3,
					(i < string_0.Length - 1) ? "," : ""
				}) : string.Concat(new object[]
				{
					num,
					"-",
					num3,
					(i < string_0.Length - 1) ? "," : ""
				})));
			}
			else
			{
				stringBuilder.Append(string_0[i] + ((i < string_0.Length - 1) ? "," : ""));
			}
		}
		return stringBuilder.ToString();
	}

	private BindingSource method_38()
	{
		base.SelectSqlData(this.class255_0, this.class255_0.vJ_MeasCell, true, string.Format("WHERE idMeasurement = {0} AND idBus = {1} ORDER BY CONVERT(BIGINT, CASE WHEN NameBus like '%[^0-9]%' THEN SUBSTRING(NameBus,1,PATINDEX('%[^0-9]%',NameBus)-1) ELSE NameBus END), CONVERT(INT, CASE WHEN NameCell like '%[^0-9]%' THEN SUBSTRING(NameCell,1,PATINDEX('%[^0-9]%',NameCell)-1) ELSE NameCell END)", this.method_2(), this.IdBus));
		return new BindingSource
		{
			DataSource = this.class255_0.vJ_MeasCell
		};
	}

	private BindingSource method_39()
	{
		this.class255_0.dtMeasCableRatio.Rows.Clear();
		var source = (from row in this.class255_0.vJ_MeasCableReport2
		group row by new
		{
			id = ((row["id"] != DBNull.Value) ? row["id"] : -1),
			idMeasurement = ((row["idMeasurement"] != DBNull.Value) ? row["idMeasurement"] : -1),
			idBus = ((row["idBus"] != DBNull.Value) ? row["idBus"] : -1),
			idTransf = ((row["idTransf"] != DBNull.Value) ? row["idTransf"] : -1),
			idCell = ((row["idCell"] != DBNull.Value) ? row["idCell"] : -1),
			CellName = ((row["CellName"] != DBNull.Value) ? row["CellName"] : ""),
			idCable = ((row["idCable"] != DBNull.Value) ? row["idCable"] : -1),
			idSchmAbn = ((row["idSchmAbn"] != DBNull.Value) ? row["idSchmAbn"] : -1),
			Makeup = ((row["Makeup"] != DBNull.Value) ? row["Makeup"] : ""),
			Voltage = ((row["Voltage"] != DBNull.Value) ? row["Voltage"] : -1),
			Wires = ((row["Wires"] != DBNull.Value) ? row["Wires"] : -1),
			CrossSection = Convert.ToDouble((row["CrossSection"] != DBNull.Value) ? row["CrossSection"] : 0),
			PermisAmperage = Convert.ToDouble((row["PermisAmperage"] != DBNull.Value) ? row["PermisAmperage"] : 0),
			Iad = ((row["Iad"] != DBNull.Value) ? row["Iad"] : -1),
			Ian = ((row["Ian"] != DBNull.Value) ? row["Ian"] : -1),
			Ibd = ((row["Ibd"] != DBNull.Value) ? row["Ibd"] : -1),
			Ibn = ((row["Ibn"] != DBNull.Value) ? row["Ibn"] : -1),
			Icd = ((row["Icd"] != DBNull.Value) ? row["Icd"] : -1),
			Icn = ((row["Icn"] != DBNull.Value) ? row["Icn"] : -1),
			Iod = ((row["Iod"] != DBNull.Value) ? row["Iod"] : -1),
			Ion = ((row["Ion"] != DBNull.Value) ? row["Ion"] : -1),
			Comment = ((row["Comment"] != DBNull.Value) ? row["Comment"] : "")
		}).Select(new Func<IGrouping<<>f__AnonymousType11<object, object, object, object, object, object, object, object, object, object, object, double, double, object, object, object, object, object, object, object, object, object>, Class255.Class438>, <>f__AnonymousType12<object, object, object, object, object, object, string, object, object, object, object, double, double, object, object, object, object, object, object, object, object>>(this.method_49)).AsEnumerable();
		var source2 = from row in source
		where (int)row.Iad != -1
		select row;
		var source3 = from row in source
		where (int)row.Ian != -1
		select row;
		var source4 = from row in source
		where (int)row.Ibd != -1
		select row;
		var source5 = from row in source
		where (int)row.Ibn != -1
		select row;
		var source6 = from row in source
		where (int)row.Icd != -1
		select row;
		var source7 = from row in source
		where (int)row.Icn != -1
		select row;
		var source8 = from row in source
		where (int)row.Iod != -1
		select row;
		var source9 = from row in source
		where (int)row.Ion != -1
		select row;
		int value;
		if (source2.Count() <= 0)
		{
			value = 0;
		}
		else
		{
			value = source2.Sum(row => (int)row.Iad);
		}
		decimal num = value;
		int value2;
		if (source3.Count() <= 0)
		{
			value2 = 0;
		}
		else
		{
			value2 = source3.Sum(row => (int)row.Ian);
		}
		decimal num2 = value2;
		int value3;
		if (source4.Count() <= 0)
		{
			value3 = 0;
		}
		else
		{
			value3 = source4.Sum(row => (int)row.Ibd);
		}
		decimal num3 = value3;
		int value4;
		if (source5.Count() <= 0)
		{
			value4 = 0;
		}
		else
		{
			value4 = source5.Sum(row => (int)row.Ibn);
		}
		decimal num4 = value4;
		int value5;
		if (source6.Count() <= 0)
		{
			value5 = 0;
		}
		else
		{
			value5 = source6.Sum(row => (int)row.Icd);
		}
		decimal num5 = value5;
		int value6;
		if (source7.Count() <= 0)
		{
			value6 = 0;
		}
		else
		{
			value6 = source7.Sum(row => (int)row.Icn);
		}
		decimal num6 = value6;
		int value7;
		if (source8.Count() <= 0)
		{
			value7 = 0;
		}
		else
		{
			value7 = source8.Sum(row => (int)row.Iod);
		}
		decimal num7 = value7;
		int value8;
		if (source9.Count() <= 0)
		{
			value8 = 0;
		}
		else
		{
			value8 = source9.Sum(row => (int)row.Ion);
		}
		decimal num8 = value8;
		decimal num9 = 0m;
		decimal num10 = 0m;
		decimal num11 = Math.Round((num + num3 + num5) / 3m, 0);
		decimal num12 = Math.Round((num2 + num4 + num6) / 3m, 0);
		decimal d = (this.class255_0.fn_J_MeasTransfPassport.Rows.Count <= 0 || !(this.class255_0.fn_J_MeasTransfPassport.Rows[0]["Inom"] is decimal)) ? 0m : ((decimal)this.class255_0.fn_J_MeasTransfPassport.Rows[0]["Inom"]);
		decimal num13 = (d != 0m) ? Math.Round(num11 / (d / 100m), 0) : 0m;
		decimal num14 = (d != 0m) ? Math.Round(num12 / (d / 100m), 0) : 0m;
		decimal num15 = Math.Max(Math.Abs(num - num3), Math.Abs(num - num5));
		num15 = Math.Max(num15, Math.Abs(num3 - num5));
		if (num + num3 + num5 != 0m)
		{
			num9 = Math.Round(num15 / ((num + num3 + num5) / 100m), 0);
		}
		decimal num16 = Math.Max(Math.Abs(num2 - num4), Math.Abs(num2 - num6));
		num16 = Math.Max(num16, Math.Abs(num4 - num6));
		if (num2 + num4 + num6 != 0m)
		{
			num10 = Math.Round(num16 / ((num2 + num4 + num6) / 100m));
		}
		string text = (this.method_10() == -1) ? "" : base.SelectSqlData("tSchm_ObjList", true, "WHERE id = " + this.method_10().ToString()).Rows[0]["Name"].ToString();
		string text2 = (this.IdBus == -1) ? "" : base.SelectSqlData("vP_ObjList", true, "WHERE id = " + this.IdBus.ToString()).Rows[0]["Text"].ToString();
		string text3 = (this.class255_0.vJ_MeasurementReport.Rows.Count > 0) ? this.class255_0.vJ_MeasurementReport.Rows[0]["FIO"].ToString() : "";
		this.class255_0.dtMeasCableRatio.Rows.Add(new object[]
		{
			"",
			text,
			text2,
			text3,
			num,
			num2,
			num3,
			num4,
			num5,
			num6,
			num7,
			num8,
			num11,
			num12,
			num13,
			num14,
			num9,
			num10
		});
		return new BindingSource
		{
			DataSource = this.class255_0.dtMeasCableRatio
		};
	}

	private BindingSource method_40()
	{
		this.class255_0.dtMeasCellRatio.Rows.Clear();
		EnumerableRowCollection<Class255.Class440> source = from row in this.class255_0.vJ_MeasCell
		where row["Iad"] != DBNull.Value
		select row;
		EnumerableRowCollection<Class255.Class440> source2 = from row in this.class255_0.vJ_MeasCell
		where row["Ian"] != DBNull.Value
		select row;
		EnumerableRowCollection<Class255.Class440> source3 = from row in this.class255_0.vJ_MeasCell
		where row["Ibd"] != DBNull.Value
		select row;
		EnumerableRowCollection<Class255.Class440> source4 = from row in this.class255_0.vJ_MeasCell
		where row["Ibn"] != DBNull.Value
		select row;
		EnumerableRowCollection<Class255.Class440> source5 = from row in this.class255_0.vJ_MeasCell
		where row["Icd"] != DBNull.Value
		select row;
		EnumerableRowCollection<Class255.Class440> source6 = from row in this.class255_0.vJ_MeasCell
		where row["Icn"] != DBNull.Value
		select row;
		int value;
		if (source.Count<Class255.Class440>() <= 0)
		{
			value = 0;
		}
		else
		{
			value = source.Sum((Class255.Class440 row) => row.Iad);
		}
		decimal num = value;
		int value2;
		if (source2.Count<Class255.Class440>() <= 0)
		{
			value2 = 0;
		}
		else
		{
			value2 = source2.Sum((Class255.Class440 row) => row.Ian);
		}
		decimal num2 = value2;
		int value3;
		if (source3.Count<Class255.Class440>() <= 0)
		{
			value3 = 0;
		}
		else
		{
			value3 = source3.Sum((Class255.Class440 row) => row.Ibd);
		}
		decimal num3 = value3;
		int value4;
		if (source4.Count<Class255.Class440>() <= 0)
		{
			value4 = 0;
		}
		else
		{
			value4 = source4.Sum((Class255.Class440 row) => row.Ibn);
		}
		decimal num4 = value4;
		int value5;
		if (source5.Count<Class255.Class440>() <= 0)
		{
			value5 = 0;
		}
		else
		{
			value5 = source5.Sum((Class255.Class440 row) => row.Icd);
		}
		decimal num5 = value5;
		int value6;
		if (source6.Count<Class255.Class440>() <= 0)
		{
			value6 = 0;
		}
		else
		{
			value6 = source6.Sum((Class255.Class440 row) => row.Icn);
		}
		decimal num6 = value6;
		this.class255_0.dtMeasCellRatio.Rows.Add(new object[]
		{
			num,
			num2,
			num3,
			num4,
			num5,
			num6
		});
		return new BindingSource
		{
			DataSource = this.class255_0.dtMeasCellRatio
		};
	}

	private BindingSource method_41()
	{
		base.CallSQLTableValuedFunction(this.class255_0, this.class255_0.fn_J_GetBusLVByTransf, "", new string[]
		{
			this.method_10().ToString()
		});
		EnumerableRowCollection<string> source = from row in this.class255_0.fn_J_GetBusLVByTransf
		where row.TypeCodeId == 540
		select row.Name;
		string text = (source.Count<string>() > 0) ? source.First<string>() : "";
		this.class255_0.dtMeasTransfAmperageDopDataReport.Rows.Add(new object[]
		{
			text
		});
		return new BindingSource
		{
			DataSource = this.class255_0.dtMeasTransfAmperageDopDataReport
		};
	}

	private BindingSource method_42()
	{
		base.CallSQLTableValuedFunction(this.class255_0, this.class255_0.fn_J_ExcelessLoadReport, "ORDER BY NetRegion, SSSocrName, CONVERT(INT, CASE WHEN Substation like '%[^0-9]%' THEN SUBSTRING(Substation,1,PATINDEX('%[^0-9]%',Substation)-1) ELSE Substation END), CONVERT(INT, CASE WHEN Switch like '%[^0-9]%' THEN SUBSTRING(Switch,1,PATINDEX('%[^0-9]%',Switch)-1) ELSE Switch END)", new string[]
		{
			this.Year.ToString(),
			this.method_14().ToString()
		});
		return new BindingSource
		{
			DataSource = this.class255_0.fn_J_ExcelessLoadReport
		};
	}

	private BindingSource method_43()
	{
		Class255.Class401 @class = this.class255_0.dtExcelessLoadAddlReport.method_4();
		@class.Year = this.Year;
		@class.Coefficient = this.method_14();
		this.class255_0.dtExcelessLoadAddlReport.method_0(@class);
		return new BindingSource
		{
			DataSource = this.class255_0.dtExcelessLoadAddlReport
		};
	}

	private BindingSource method_44()
	{
		string text = (this.method_12() == -1) ? "" : (" AND idNetRegion = " + this.method_12().ToString());
		string text2 = (this.method_16() == -1) ? "" : (" AND Power " + (this.method_18() ? "> " : "< ") + this.method_16().ToString());
		string text3 = this.method_24() ? (" AND Kntd " + (this.method_22() ? "> " : "< ") + this.method_20().ToString()) : "";
		string text4 = this.method_26() ? (" AND Kntn " + (this.method_22() ? "> " : "< ") + this.method_20().ToString()) : "";
		string where = string.Format(" WHERE Year = {0}{1}{2}{3}{4} ORDER BY NetRegion, SSSocrName, CONVERT(INT, CASE WHEN Substation like '%[^0-9]%' THEN SUBSTRING(Substation,1,PATINDEX('%[^0-9]%',Substation)-1) ELSE Substation END), CONVERT(INT, CASE WHEN Transformer like '%[^0-9]%' THEN SUBSTRING(Transformer,1,PATINDEX('%[^0-9]%',Transformer)-1) ELSE Transformer END)", new object[]
		{
			this.Year,
			text,
			text2,
			text3,
			text4
		});
		base.SelectSqlData(this.class255_0, this.class255_0.vJ_CoefficientLoading, true, where);
		return new BindingSource
		{
			DataSource = this.class255_0.vJ_CoefficientLoading
		};
	}

	private BindingSource method_45()
	{
		Class255.Class403 @class = this.class255_0.dtCoefficientLoadingAddl.TdnmoyvvJwN();
		@class.Year = this.Year;
		@class.Power = ((this.method_16() == -1) ? "" : ((this.method_18() ? "> " : "< ") + this.method_16().ToString()));
		@class.Kntd = (this.method_24() ? ((this.method_22() ? "> " : "< ") + this.method_20().ToString()) : "");
		@class.Kntn = (this.method_26() ? ((this.method_22() ? "> " : "< ") + this.method_20().ToString()) : "");
		this.class255_0.dtCoefficientLoadingAddl.idJmolsqNkm(@class);
		return new BindingSource
		{
			DataSource = this.class255_0.dtCoefficientLoadingAddl
		};
	}

	private BindingSource method_46()
	{
		string text = (this.method_12() == -1) ? "" : (" AND idNetRegion = " + this.method_12().ToString());
		string text2 = (this.method_16() == -1) ? "" : (" AND Power " + (this.method_18() ? "> " : "< ") + this.method_16().ToString());
		string text3 = this.method_24() ? (" AND Kpfd " + (this.method_22() ? "> " : "< ") + this.method_20().ToString()) : "";
		string text4 = this.method_26() ? (" AND Kpfn " + (this.method_22() ? "> " : "< ") + this.method_20().ToString()) : "";
		string where = string.Format(" WHERE Year = {0}{1}{2}{3}{4} ORDER BY NetRegion, SSSocrName, CONVERT(INT, CASE WHEN Substation like '%[^0-9]%' THEN SUBSTRING(Substation,1,PATINDEX('%[^0-9]%',Substation)-1) ELSE Substation END), CONVERT(INT, CASE WHEN Transformer like '%[^0-9]%' THEN SUBSTRING(Transformer,1,PATINDEX('%[^0-9]%',Transformer)-1) ELSE Transformer END)", new object[]
		{
			this.Year,
			text,
			text2,
			text3,
			text4
		});
		base.SelectSqlData(this.class255_0, this.class255_0.vJ_CoefficientIrregularity, true, where);
		return new BindingSource
		{
			DataSource = this.class255_0.vJ_CoefficientIrregularity
		};
	}

	private void checkBox_0_CheckedChanged(object sender, EventArgs e)
	{
		this.method_28();
	}

	private void checkBox_1_CheckedChanged(object sender, EventArgs e)
	{
		this.method_28();
	}

	private void method_47()
	{
		this.reportViewer_0 = new ReportViewer();
		this.class255_0 = new Class255();
		this.tableLayoutPanel_0 = new TableLayoutPanel();
		this.checkBox_0 = new CheckBox();
		this.checkBox_1 = new CheckBox();
		((ISupportInitialize)this.class255_0).BeginInit();
		this.tableLayoutPanel_0.SuspendLayout();
		base.SuspendLayout();
		this.tableLayoutPanel_0.SetColumnSpan(this.reportViewer_0, 2);
		this.reportViewer_0.Dock = DockStyle.Fill;
		this.reportViewer_0.Location = new Point(4, 40);
		this.reportViewer_0.Margin = new Padding(4, 4, 4, 4);
		this.reportViewer_0.Name = "rwGeneral";
		this.reportViewer_0.Size = new Size(879, 584);
		this.reportViewer_0.TabIndex = 0;
		this.class255_0.DataSetName = "DataSetGES";
		this.class255_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		this.tableLayoutPanel_0.ColumnCount = 2;
		this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 280f));
		this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		this.tableLayoutPanel_0.Controls.Add(this.reportViewer_0, 0, 1);
		this.tableLayoutPanel_0.Controls.Add(this.checkBox_0, 0, 0);
		this.tableLayoutPanel_0.Controls.Add(this.checkBox_1, 1, 0);
		this.tableLayoutPanel_0.Dock = DockStyle.Fill;
		this.tableLayoutPanel_0.Location = new Point(0, 0);
		this.tableLayoutPanel_0.Margin = new Padding(4, 4, 4, 4);
		this.tableLayoutPanel_0.Name = "tableLayoutPanel1";
		this.tableLayoutPanel_0.RowCount = 2;
		this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Absolute, 36f));
		this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		this.tableLayoutPanel_0.Size = new Size(887, 628);
		this.tableLayoutPanel_0.TabIndex = 1;
		this.checkBox_0.AutoSize = true;
		this.checkBox_0.Dock = DockStyle.Fill;
		this.checkBox_0.Location = new Point(20, 4);
		this.checkBox_0.Margin = new Padding(20, 4, 4, 4);
		this.checkBox_0.Name = "chbWitnName";
		this.checkBox_0.Size = new Size(256, 28);
		this.checkBox_0.TabIndex = 1;
		this.checkBox_0.Text = "с наименованием";
		this.checkBox_0.UseVisualStyleBackColor = true;
		this.checkBox_0.CheckedChanged += this.checkBox_0_CheckedChanged;
		this.checkBox_1.Location = new Point(284, 4);
		this.checkBox_1.Margin = new Padding(4, 4, 4, 4);
		this.checkBox_1.Name = "chbHideNameObj";
		this.checkBox_1.Size = new Size(315, 28);
		this.checkBox_1.TabIndex = 2;
		this.checkBox_1.Text = "Скрыть столбец наименование объекта";
		this.checkBox_1.UseVisualStyleBackColor = true;
		this.checkBox_1.CheckedChanged += this.checkBox_1_CheckedChanged;
		base.AutoScaleDimensions = new SizeF(8f, 16f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(887, 628);
		base.Controls.Add(this.tableLayoutPanel_0);
		base.Margin = new Padding(4, 4, 4, 4);
		base.Name = "FormMeasurementReports";
		base.StartPosition = FormStartPosition.CenterScreen;
		this.Text = "FormMeasurementReports";
		base.Load += this.Form44_Load;
		((ISupportInitialize)this.class255_0).EndInit();
		this.tableLayoutPanel_0.ResumeLayout(false);
		this.tableLayoutPanel_0.PerformLayout();
		base.ResumeLayout(false);
	}

	[CompilerGenerated]
	private <>f__AnonymousType12<object, object, object, object, object, object, string, object, object, object, object, double, double, object, object, object, object, object, object, object, object> method_48(IGrouping<<>f__AnonymousType11<object, object, object, object, object, object, object, object, object, object, object, double, double, object, object, object, object, object, object, object, object, object>, Class255.Class438> igrouping_0)
	{
		return new
		{
			id = igrouping_0.Key.id,
			idMeasurement = igrouping_0.Key.idMeasurement,
			idBus = igrouping_0.Key.idBus,
			idCell = igrouping_0.Key.idCell,
			CellName = igrouping_0.Key.CellName,
			idCable = igrouping_0.Key.idCable,
			Address = this.method_37(this.class255_0.vJ_MeasCableReport2, (igrouping_0.Key.idCell == DBNull.Value) ? -1 : ((int)igrouping_0.Key.idCell), (igrouping_0.Key.idCable == DBNull.Value) ? -1 : ((int)igrouping_0.Key.idCable)),
			idSchmAbn = igrouping_0.Key.idSchmAbn,
			Makeup = igrouping_0.Key.Makeup,
			Voltage = igrouping_0.Key.Voltage,
			Wires = igrouping_0.Key.Wires,
			CrossSection = igrouping_0.Key.CrossSection,
			PermisAmperage = igrouping_0.Key.PermisAmperage,
			Iad = igrouping_0.Key.Iad,
			Ian = igrouping_0.Key.Ian,
			Ibd = igrouping_0.Key.Ibd,
			Ibn = igrouping_0.Key.Ibn,
			Icd = igrouping_0.Key.Icd,
			Icn = igrouping_0.Key.Icn,
			Iod = igrouping_0.Key.Iod,
			Ion = igrouping_0.Key.Ion
		};
	}

	[CompilerGenerated]
	private <>f__AnonymousType12<object, object, object, object, object, object, string, object, object, object, object, double, double, object, object, object, object, object, object, object, object> method_49(IGrouping<<>f__AnonymousType11<object, object, object, object, object, object, object, object, object, object, object, double, double, object, object, object, object, object, object, object, object, object>, Class255.Class438> igrouping_0)
	{
		return new
		{
			id = igrouping_0.Key.id,
			idMeasurement = igrouping_0.Key.idMeasurement,
			idBus = igrouping_0.Key.idBus,
			idCell = igrouping_0.Key.idCell,
			CellName = igrouping_0.Key.CellName,
			idCable = igrouping_0.Key.idCable,
			Address = this.method_37(this.class255_0.vJ_MeasCableReport2, (igrouping_0.Key.idCell == DBNull.Value) ? -1 : ((int)igrouping_0.Key.idCell), (igrouping_0.Key.idCable == DBNull.Value) ? -1 : ((int)igrouping_0.Key.idCable)),
			idSchmAbn = igrouping_0.Key.idSchmAbn,
			Makeup = igrouping_0.Key.Makeup,
			Voltage = igrouping_0.Key.Voltage,
			Wires = igrouping_0.Key.Wires,
			CrossSection = igrouping_0.Key.CrossSection,
			PermisAmperage = igrouping_0.Key.PermisAmperage,
			Iad = igrouping_0.Key.Iad,
			Ian = igrouping_0.Key.Ian,
			Ibd = igrouping_0.Key.Ibd,
			Ibn = igrouping_0.Key.Ibn,
			Icd = igrouping_0.Key.Icd,
			Icn = igrouping_0.Key.Icn,
			Iod = igrouping_0.Key.Iod,
			Ion = igrouping_0.Key.Ion
		};
	}

	internal static void A9QJca0YO7ggqKrr2n8V(Form form_0, bool bool_4)
	{
		form_0.Dispose(bool_4);
	}

	[CompilerGenerated]
	private Enum13 enum13_0;

	[CompilerGenerated]
	private int int_0;

	[CompilerGenerated]
	private int int_1;

	[CompilerGenerated]
	private int int_2;

	[CompilerGenerated]
	private int int_3;

	[CompilerGenerated]
	private int int_4;

	[CompilerGenerated]
	private int int_5;

	[CompilerGenerated]
	private int int_6;

	[CompilerGenerated]
	private int int_7;

	[CompilerGenerated]
	private decimal decimal_0;

	[CompilerGenerated]
	private int int_8;

	[CompilerGenerated]
	private bool bool_0;

	[CompilerGenerated]
	private decimal decimal_1;

	[CompilerGenerated]
	private bool bool_1;

	[CompilerGenerated]
	private bool bool_2;

	[CompilerGenerated]
	private bool bool_3;

	private ReportViewer reportViewer_0;

	private Class255 class255_0;

	private TableLayoutPanel tableLayoutPanel_0;

	private CheckBox checkBox_0;

	private CheckBox checkBox_1;
}
