using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Documents.Forms.Measurement;
using FormLbr;

internal partial class Form40 : FormBase
{
	internal int IdBus { get; set; }

	[CompilerGenerated]
	internal int method_0()
	{
		return this.int_1;
	}

	[CompilerGenerated]
	internal void method_1(int int_5)
	{
		this.int_1 = int_5;
	}

	[CompilerGenerated]
	internal int method_2()
	{
		return this.int_2;
	}

	[CompilerGenerated]
	internal void method_3(int int_5)
	{
		this.int_2 = int_5;
	}

	[CompilerGenerated]
	internal int method_4()
	{
		return this.int_3;
	}

	[CompilerGenerated]
	internal void method_5(int int_5)
	{
		this.int_3 = int_5;
	}

	[CompilerGenerated]
	internal string method_6()
	{
		return this.string_0;
	}

	[CompilerGenerated]
	internal void method_7(string string_1)
	{
		this.string_0 = string_1;
	}

	internal Class255.Class419[] Rows { get; private set; }

	[CompilerGenerated]
	internal Class255.Class316 method_8()
	{
		return this.class316_0;
	}

	[CompilerGenerated]
	private void method_9(Class255.Class316 class316_1)
	{
		this.class316_0 = class316_1;
	}

	[CompilerGenerated]
	internal int method_10()
	{
		return this.int_4;
	}

	[CompilerGenerated]
	internal void method_11(int int_5)
	{
		this.int_4 = int_5;
	}

	internal FormMeasurement.TypeDoc TypeDoc { get; set; }

	internal Form40()
	{
		
		
		this.method_26();
	}

	internal Form40(int int_5, int int_6, int int_7, int int_8, int int_9, FormMeasurement.TypeDoc typeDoc_1)
	{
		
		
		this.method_26();
		this.IdBus = int_5;
		this.method_1(int_6);
		this.method_3(int_7);
		this.method_5(int_8);
		this.method_11(int_9);
		this.TypeDoc = typeDoc_1;
	}

	private void Form40_Load(object sender, EventArgs e)
	{
		base.SelectSqlData(this.class255_0, this.class255_0.vJ_CableReference, true);
		EnumerableRowCollection<DataRow> source = base.SelectSqlData("tSchm_ObjList", true, string.Format("WHERE idParent = {0} AND Deleted = ((0)) AND (id = {1} OR Tag = {1})", this.method_2(), this.IdBus)).AsEnumerable();
		string arg = string.Join(",", (from r in source
		select r.Field("Id").ToString()).ToArray<string>());
		base.SelectSqlData(this.class255_0, this.class255_0.vJ_CellByBus, true, string.Format("WHERE idBus IN ({0}) AND idParent = {1}", arg, this.method_2()));
		string arg2 = string.Join(",", (from i in this.class255_0.vJ_CellByBus
		select i.id.ToString()).ToArray<string>());
		base.SelectSqlData(this.class255_0, this.class255_0.vJ_TransfByCell, true, string.Format("WHERE idCell IN ({0})", arg2));
		base.SelectSqlData(this.class255_0, this.class255_0.vJ_CableByCell, true, string.Format("WHERE idCell IN ({0})", arg2));
		this.method_12(this.class255_0.tJ_MeasCable, 0);
		foreach (object obj in this.class255_0.tJ_MeasCable.Rows)
		{
			((DataRow)obj).EndEdit();
		}
	}

	private int method_12(Class255.Class313 class313_0, int int_5)
	{
		foreach (var <>f__AnonymousType in (from s in (from <>h__TransparentIdentifier0 in (from c in this.class255_0.vJ_CellByBus
		join cab in this.class255_0.vJ_CableByCell on c.id equals cab.idCell
		select new
		{
			c,
			cab
		}).Where(new Func<<>f__AnonymousType8<Class255.Class432, Class255.Class422>, bool>(this.method_27))
		select new
		{
			idBus = ((<>h__TransparentIdentifier0.c["idBus"] != null) ? ((int)<>h__TransparentIdentifier0.c["idBus"]) : -1),
			idCell = ((<>h__TransparentIdentifier0.cab["idCell"] != null) ? ((int)<>h__TransparentIdentifier0.cab["idCell"]) : -1),
			NameCell = ((<>h__TransparentIdentifier0.c["Name"] != null) ? <>h__TransparentIdentifier0.c["Name"].ToString() : ""),
			idCable = ((<>h__TransparentIdentifier0.cab["id"] != null) ? ((int)<>h__TransparentIdentifier0.cab["id"]) : -1),
			NameCable = ((<>h__TransparentIdentifier0.cab["Name"] != null) ? <>h__TransparentIdentifier0.cab["Name"].ToString() : "")
		}).Where(new Func<<>f__AnonymousType7<int, int, string, int, string>, bool>(this.method_28))
		orderby Regex.Match(s.NameCell, "^\\D").Length == 0, Regex.Match(s.NameCell, "\\D*").Value
		select s).ThenBy(delegate(s)
		{
			if (!int.TryParse(Regex.Match(s.NameCell, "\\d+").Value, out int_5))
			{
				return 0;
			}
			return int.Parse(Regex.Match(s.NameCell, "\\d+").Value);
		}))
		{
			this.class255_0.vJ_LastCableInfo.Rows.Clear();
			if (<>f__AnonymousType.idCable != -1)
			{
				base.SelectSqlData(this.class255_0.vJ_LastCableInfo, true, string.Format("WHERE idCable = {0} AND idCell = {1} ORDER BY [Year] DESC", <>f__AnonymousType.idCable, <>f__AnonymousType.idCell), null, false, 1);
			}
			Class255.Class419 @class = class313_0.method_5();
			Class255.Class419 class2 = @class;
			int id;
			if (class313_0.Rows.Count <= 0)
			{
				id = this.method_10();
			}
			else
			{
				id = class313_0.Min((Class255.Class419 r) => r.id) - 1;
			}
			class2.id = id;
			@class.idMeasurement = this.method_0();
			@class.idBus = this.IdBus;
			@class.idTransf = this.method_4();
			@class["idCable"] = <>f__AnonymousType.idCable;
			@class.idCell = <>f__AnonymousType.idCell;
			if (this.class255_0.vJ_LastCableInfo.Rows.Count > 0)
			{
				@class["Address"] = this.class255_0.vJ_LastCableInfo.First<Class255.Class420>()["Address"];
				@class["Company"] = this.class255_0.vJ_LastCableInfo.First<Class255.Class420>()["Company"];
				@class["Makeup"] = this.class255_0.vJ_LastCableInfo.First<Class255.Class420>()["Makeup"];
				@class["Voltage"] = this.class255_0.vJ_LastCableInfo.First<Class255.Class420>()["Voltage"];
				@class["Wires"] = this.class255_0.vJ_LastCableInfo.First<Class255.Class420>()["Wires"];
				@class["CrossSection"] = this.class255_0.vJ_LastCableInfo.First<Class255.Class420>()["CrossSection"];
				@class["PermisAmperage"] = this.class255_0.vJ_LastCableInfo.First<Class255.Class420>()["PermisAmperage"];
			}
			else
			{
				@class.Makeup = "";
				@class.Voltage = -1;
				@class.PermisAmperage = 0.0;
			}
			@class.Deleted = false;
			class313_0.method_0(@class);
		}
		return int_5;
	}

	private void dataGridView_0_DataError(object sender, DataGridViewDataErrorEventArgs e)
	{
	}

	private void dataGridView_0_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
	{
		new DataTable();
		string text = (this.dataGridView_0.Rows[e.RowIndex].Cells["dgvcCableMakeup"].Value is string) ? this.dataGridView_0.Rows[e.RowIndex].Cells["dgvcCableMakeup"].Value.ToString() : "";
		int num = (this.dataGridView_0.Rows[e.RowIndex].Cells["dgvcWires"].Value is int) ? ((int)this.dataGridView_0.Rows[e.RowIndex].Cells["dgvcWires"].Value) : 0;
		double num2 = (this.dataGridView_0.Rows[e.RowIndex].Cells["dgvcCrossSection"].Value is double) ? ((double)this.dataGridView_0.Rows[e.RowIndex].Cells["dgvcCrossSection"].Value) : 0.0;
		double num3 = (this.dataGridView_0.Rows[e.RowIndex].Cells["dgvcPermisAmperage"].Value is double) ? ((double)this.dataGridView_0.Rows[e.RowIndex].Cells["dgvcPermisAmperage"].Value) : 0.0;
		if (e.ColumnIndex == this.dataGridView_0.Columns["dgvcCableMakeup"].Index)
		{
			DataTable dataTable = this.method_21(e.RowIndex, true);
			int num4 = dataTable.Select("CableMakeup = '" + text + "'").Length;
			if (dataTable.Select("CableMakeup = '" + text + "'").Length == 0)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow["CableMakeup"] = text;
				dataTable.Rows.InsertAt(dataRow, 0);
			}
		}
		if (e.ColumnIndex == this.dataGridView_0.Columns["dgvcWires"].Index)
		{
			DataTable dataTable2 = this.method_24(e.RowIndex, false);
			dataTable2 = this.method_16(e.RowIndex, dataTable2, text);
			if (dataTable2.Select("Wires = " + num.ToString()).Length == 0)
			{
				DataRow dataRow2 = dataTable2.NewRow();
				dataRow2["Wires"] = num;
				dataTable2.Rows.InsertAt(dataRow2, 0);
			}
		}
		if (e.ColumnIndex == this.dataGridView_0.Columns["dgvcCrossSection"].Index)
		{
			DataTable dataTable3 = this.method_23(e.RowIndex, false);
			dataTable3 = this.method_18(e.RowIndex, dataTable3, text, num);
			if (dataTable3.Select("CrossSection = " + num2.ToString().Replace(',', '.')).Length == 0)
			{
				DataRow dataRow3 = dataTable3.NewRow();
				dataRow3["CrossSection"] = num2;
				dataTable3.Rows.InsertAt(dataRow3, 0);
			}
		}
		if (e.ColumnIndex == this.dataGridView_0.Columns["dgvcPermisAmperage"].Index)
		{
			DataTable dataTable4 = this.method_22(e.RowIndex, false);
			dataTable4 = this.method_20(e.RowIndex, dataTable4, text, num, num2);
			if (dataTable4.Select("AmperageValue = " + num3.ToString().Replace(',', '.')).Length == 0)
			{
				DataRow dataRow4 = dataTable4.NewRow();
				dataRow4["AmperageType"] = num3;
				dataRow4["AmperageValue"] = num3;
				dataTable4.Rows.InsertAt(dataRow4, 0);
			}
		}
	}

	private void dataGridView_0_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
	{
		this.method_13(e.RowIndex);
	}

	private void dataGridView_0_CellEndEdit(object sender, DataGridViewCellEventArgs e)
	{
	}

	private void method_13(int int_5)
	{
		try
		{
			DataTable dataTable = this.class255_0.DataTableCollection_0["dtCable_" + this.method_4().ToString() + "_" + int_5.ToString()];
			if (((DataGridViewComboBoxCell)this.dataGridView_0.Rows[int_5].Cells["dgvcIdCable"]).DataSource == null)
			{
				if (dataTable == null)
				{
					dataTable = new DataTable("dtCable_" + this.method_4().ToString() + "_" + int_5.ToString());
					dataTable.Columns.Add("Id", typeof(int));
					dataTable.Columns.Add("Name", typeof(string));
					this.class255_0.DataTableCollection_0.Add(dataTable);
				}
				var enumerable = from row in this.class255_0.vJ_CableByCell.AsEnumerable<Class255.Class422>()
				where row["id"] != DBNull.Value
				group row by new
				{
					row.id,
					row.Name
				} into g
				select new
				{
					IdCable = g.Key.id,
					NameCable = g.Key.Name
				};
				dataTable.Rows.Clear();
				foreach (var <>f__AnonymousType in enumerable)
				{
					dataTable.Rows.Add(new object[]
					{
						<>f__AnonymousType.IdCable,
						<>f__AnonymousType.NameCable
					});
				}
				((DataGridViewComboBoxCell)this.dataGridView_0.Rows[int_5].Cells["dgvcIdCable"]).DataSource = dataTable;
				((DataGridViewComboBoxCell)this.dataGridView_0.Rows[int_5].Cells["dgvcIdCable"]).DisplayMember = "Name";
				((DataGridViewComboBoxCell)this.dataGridView_0.Rows[int_5].Cells["dgvcIdCable"]).ValueMember = "Id";
			}
			string text = (this.dataGridView_0.Rows[int_5].Cells["dgvcCableMakeup"].Value is string) ? this.dataGridView_0.Rows[int_5].Cells["dgvcCableMakeup"].Value.ToString() : "";
			DataTable dataTable2 = this.method_21(int_5, true);
			int num = dataTable2.Select("CableMakeup = '" + text + "'").Length;
			if (dataTable2.Select("CableMakeup = '" + text + "'").Length == 0)
			{
				DataRow dataRow = dataTable2.NewRow();
				dataRow["CableMakeup"] = text;
				dataTable2.Rows.InsertAt(dataRow, 0);
			}
			int num2 = (this.dataGridView_0.Rows[int_5].Cells["dgvcWires"].Value is int) ? ((int)this.dataGridView_0.Rows[int_5].Cells["dgvcWires"].Value) : 0;
			DataTable dataTable3 = this.method_24(int_5, false);
			dataTable3 = this.method_16(int_5, dataTable3, text);
			if (dataTable3.Select("Wires = " + num2.ToString()).Length == 0)
			{
				DataRow dataRow2 = dataTable3.NewRow();
				dataRow2["Wires"] = num2;
				dataTable3.Rows.InsertAt(dataRow2, 0);
			}
			double num3 = (this.dataGridView_0.Rows[int_5].Cells["dgvcCrossSection"].Value is double) ? ((double)this.dataGridView_0.Rows[int_5].Cells["dgvcCrossSection"].Value) : 0.0;
			DataTable dataTable4 = this.method_23(int_5, false);
			dataTable4 = this.method_18(int_5, dataTable4, text, num2);
			if (dataTable4.Select("CrossSection = " + num3.ToString().Replace(',', '.')).Length == 0)
			{
				DataRow dataRow3 = dataTable4.NewRow();
				dataRow3["CrossSection"] = num3;
				dataTable4.Rows.InsertAt(dataRow3, 0);
			}
			double num4 = (this.dataGridView_0.Rows[int_5].Cells["dgvcPermisAmperage"].Value is double) ? ((double)this.dataGridView_0.Rows[int_5].Cells["dgvcPermisAmperage"].Value) : 0.0;
			DataTable dataTable5 = this.method_22(int_5, false);
			dataTable5 = this.method_20(int_5, dataTable5, text, num2, num3);
			if (dataTable5.Select("AmperageValue = " + num4.ToString().Replace(',', '.')).Length == 0)
			{
				DataRow dataRow4 = dataTable5.NewRow();
				dataRow4["AmperageType"] = num4;
				dataRow4["AmperageValue"] = num4;
				dataTable5.Rows.InsertAt(dataRow4, 0);
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private DataTable method_14(int int_5, DataTable dataTable_0)
	{
		dataTable_0 = this.class255_0.DataTableCollection_0["dtCableMakeup_" + this.method_4().ToString() + "_" + int_5.ToString()];
		IEnumerable<string> enumerable = (from row in this.class255_0.vJ_CableReference.AsEnumerable<Class255.Class395>()
		orderby row.CableMakeup
		select row.CableMakeup).Distinct<string>();
		dataTable_0.Rows.Clear();
		foreach (string text in enumerable)
		{
			dataTable_0.Rows.Add(new object[]
			{
				text
			});
		}
		return dataTable_0;
	}

	private DataTable method_15(int int_5, DataTable dataTable_0)
	{
		dataTable_0 = this.class255_0.DataTableCollection_0["dtWires_" + this.method_4().ToString() + "_" + int_5.ToString()];
		IEnumerable<int> enumerable = (from row in this.class255_0.vJ_CableReference.AsEnumerable<Class255.Class395>()
		orderby row.Wires
		select row.Wires).Distinct<int>();
		dataTable_0.Rows.Clear();
		foreach (int num in enumerable)
		{
			dataTable_0.Rows.Add(new object[]
			{
				num
			});
		}
		return dataTable_0;
	}

	private DataTable method_16(int int_5, DataTable dataTable_0, string string_1)
	{
		dataTable_0 = this.class255_0.DataTableCollection_0["dtWires_" + this.method_4().ToString() + "_" + int_5.ToString()];
		IEnumerable<int> enumerable = (from row in this.class255_0.vJ_CableReference.AsEnumerable<Class255.Class395>()
		where row.CableMakeup == string_1
		orderby row.Wires
		select row.Wires).Distinct<int>();
		dataTable_0.Rows.Clear();
		foreach (int num in enumerable)
		{
			dataTable_0.Rows.Add(new object[]
			{
				num
			});
		}
		return dataTable_0;
	}

	private DataTable method_17(int int_5, DataTable dataTable_0)
	{
		dataTable_0 = this.class255_0.DataTableCollection_0["dtCrossSection_" + this.method_4().ToString() + "_" + int_5.ToString()];
		IEnumerable<double> enumerable = (from row in this.class255_0.vJ_CableReference.AsEnumerable<Class255.Class395>()
		where row.Voltage == 0.4m
		orderby row.CrossSection
		select row.CrossSection).Distinct<double>();
		dataTable_0.Rows.Clear();
		foreach (double num in enumerable)
		{
			int num2 = (int)num;
			dataTable_0.Rows.Add(new object[]
			{
				num2
			});
		}
		return dataTable_0;
	}

	private DataTable method_18(int int_5, DataTable dataTable_0, string string_1, int int_6)
	{
		dataTable_0 = this.class255_0.DataTableCollection_0["dtCrossSection_" + this.method_4().ToString() + "_" + int_5.ToString()];
		IEnumerable<double> enumerable = (from row in this.class255_0.vJ_CableReference.AsEnumerable<Class255.Class395>()
		where row.CableMakeup == string_1 && row.Wires == int_6 && row.Voltage == 0.4m
		orderby row.CrossSection
		select row.CrossSection).Distinct<double>();
		dataTable_0.Rows.Clear();
		foreach (double num in enumerable)
		{
			int num2 = (int)num;
			dataTable_0.Rows.Add(new object[]
			{
				num2
			});
		}
		return dataTable_0;
	}

	private DataTable method_19(int int_5, DataTable dataTable_0)
	{
		dataTable_0 = this.class255_0.DataTableCollection_0["dtPermisAmperage_" + this.method_4().ToString() + "_" + int_5.ToString()];
		var enumerable = (from row in this.class255_0.vJ_CableReference.AsEnumerable<Class255.Class395>()
		where row.Voltage == 0.4m
		orderby row.AmperageValue
		select new
		{
			row.AmperageValue,
			row.AmperageType
		}).Distinct();
		dataTable_0.Rows.Clear();
		foreach (var <>f__AnonymousType in enumerable)
		{
			dataTable_0.Rows.Add(new object[]
			{
				<>f__AnonymousType.AmperageValue,
				<>f__AnonymousType.AmperageType
			});
		}
		dataTable_0.Rows.Add(new object[]
		{
			0
		});
		return dataTable_0;
	}

	private DataTable method_20(int int_5, DataTable dataTable_0, string string_1, int int_6, double double_0)
	{
		dataTable_0 = this.class255_0.DataTableCollection_0["dtPermisAmperage_" + this.method_4().ToString() + "_" + int_5.ToString()];
		IEnumerable<Class255.Class395> enumerable = (from row in this.class255_0.vJ_CableReference.AsEnumerable<Class255.Class395>()
		where row.CableMakeup == string_1 && row.Wires == int_6 && row.CrossSection == double_0 && row.Voltage == 0.4m
		orderby row.AmperageValue
		select row).Distinct<Class255.Class395>();
		dataTable_0.Rows.Clear();
		foreach (Class255.Class395 @class in enumerable)
		{
			dataTable_0.Rows.Add(new object[]
			{
				@class.AmperageValue,
				@class.AmperageType
			});
		}
		dataTable_0.Rows.Add(new object[]
		{
			0
		});
		return dataTable_0;
	}

	private DataTable method_21(int int_5, bool bool_0)
	{
		DataTable dataTable;
		if (this.class255_0.DataTableCollection_0.Contains("dtCableMakeup_" + this.method_4().ToString() + "_" + int_5.ToString()))
		{
			dataTable = this.class255_0.DataTableCollection_0["dtCableMakeup_" + this.method_4().ToString() + "_" + int_5.ToString()];
		}
		else
		{
			dataTable = new DataTable("dtCableMakeup_" + this.method_4().ToString() + "_" + int_5.ToString());
			dataTable.Columns.Add("CableMakeup", typeof(string));
			this.class255_0.DataTableCollection_0.Add(dataTable);
		}
		dataTable = this.method_14(int_5, dataTable);
		((DataGridViewComboBoxCell)this.dataGridView_0.Rows[int_5].Cells["dgvcCableMakeup"]).DataSource = dataTable;
		((DataGridViewComboBoxCell)this.dataGridView_0.Rows[int_5].Cells["dgvcCableMakeup"]).DisplayMember = "CableMakeup";
		((DataGridViewComboBoxCell)this.dataGridView_0.Rows[int_5].Cells["dgvcCableMakeup"]).ValueMember = "CableMakeup";
		return dataTable;
	}

	private DataTable method_22(int int_5, bool bool_0)
	{
		DataTable dataTable;
		if (this.class255_0.DataTableCollection_0.Contains("dtPermisAmperage_" + this.method_4().ToString() + "_" + int_5.ToString()))
		{
			dataTable = this.class255_0.DataTableCollection_0["dtPermisAmperage_" + this.method_4().ToString() + "_" + int_5.ToString()];
		}
		else
		{
			dataTable = new DataTable("dtPermisAmperage_" + this.method_4().ToString() + "_" + int_5.ToString());
			dataTable.Columns.Add("AmperageValue", typeof(double));
			dataTable.Columns.Add("AmperageType", typeof(string));
			this.class255_0.DataTableCollection_0.Add(dataTable);
		}
		this.method_19(int_5, dataTable);
		((DataGridViewComboBoxCell)this.dataGridView_0.Rows[int_5].Cells["dgvcPermisAmperage"]).DataSource = dataTable;
		((DataGridViewComboBoxCell)this.dataGridView_0.Rows[int_5].Cells["dgvcPermisAmperage"]).DisplayMember = "AmperageType";
		((DataGridViewComboBoxCell)this.dataGridView_0.Rows[int_5].Cells["dgvcPermisAmperage"]).ValueMember = "AmperageValue";
		return dataTable;
	}

	private DataTable method_23(int int_5, bool bool_0)
	{
		DataTable dataTable;
		if (this.class255_0.DataTableCollection_0.Contains("dtCrossSection_" + this.method_4().ToString() + "_" + int_5.ToString()))
		{
			dataTable = this.class255_0.DataTableCollection_0["dtCrossSection_" + this.method_4().ToString() + "_" + int_5.ToString()];
		}
		else
		{
			dataTable = new DataTable("dtCrossSection_" + this.method_4().ToString() + "_" + int_5.ToString());
			dataTable.Columns.Add("CrossSection", typeof(double));
			this.class255_0.DataTableCollection_0.Add(dataTable);
		}
		this.method_17(int_5, dataTable);
		((DataGridViewComboBoxCell)this.dataGridView_0.Rows[int_5].Cells["dgvcCrossSection"]).DataSource = dataTable;
		((DataGridViewComboBoxCell)this.dataGridView_0.Rows[int_5].Cells["dgvcCrossSection"]).DisplayMember = "CrossSection";
		((DataGridViewComboBoxCell)this.dataGridView_0.Rows[int_5].Cells["dgvcCrossSection"]).ValueMember = "CrossSection";
		return dataTable;
	}

	private DataTable method_24(int int_5, bool bool_0)
	{
		DataTable dataTable;
		if (this.class255_0.DataTableCollection_0.Contains("dtWires_" + this.method_4().ToString() + "_" + int_5.ToString()))
		{
			dataTable = this.class255_0.DataTableCollection_0["dtWires_" + this.method_4().ToString() + "_" + int_5.ToString()];
		}
		else
		{
			dataTable = new DataTable("dtWires_" + this.method_4().ToString() + "_" + int_5.ToString());
			dataTable.Columns.Add("Wires", typeof(int));
			this.class255_0.DataTableCollection_0.Add(dataTable);
		}
		this.method_15(int_5, dataTable);
		((DataGridViewComboBoxCell)this.dataGridView_0.Rows[int_5].Cells["dgvcWires"]).DataSource = dataTable;
		((DataGridViewComboBoxCell)this.dataGridView_0.Rows[int_5].Cells["dgvcWires"]).DisplayMember = "Wires";
		((DataGridViewComboBoxCell)this.dataGridView_0.Rows[int_5].Cells["dgvcWires"]).ValueMember = "Wires";
		return dataTable;
	}

	private DataTable method_25(int int_5, DataTable dataTable_0, int int_6)
	{
		if (((DataGridViewComboBoxCell)this.dataGridView_0.Rows[int_5].Cells["dgvcIdCable"]).DataSource == null)
		{
			dataTable_0 = this.class255_0.DataTableCollection_0["dtCable_" + this.method_4().ToString() + "_" + int_5.ToString()];
			if (dataTable_0 == null)
			{
				dataTable_0 = new DataTable("dtCable_" + this.method_4().ToString() + "_" + int_5.ToString());
				dataTable_0.Columns.Add("Id", typeof(int));
				dataTable_0.Columns.Add("Name", typeof(string));
				this.class255_0.DataTableCollection_0.Add(dataTable_0);
			}
			var enumerable = from row in this.class255_0.vJ_CableByCell.AsEnumerable<Class255.Class422>()
			where row.idCell == int_6 && row["id"] != DBNull.Value
			group row by new
			{
				row.id,
				row.Name
			} into g
			select new
			{
				IdCable = g.Key.id,
				NameCable = g.Key.Name
			};
			dataTable_0.Rows.Clear();
			foreach (var <>f__AnonymousType in enumerable)
			{
				dataTable_0.Rows.Add(new object[]
				{
					<>f__AnonymousType.IdCable,
					<>f__AnonymousType.NameCable
				});
			}
			((DataGridViewComboBoxCell)this.dataGridView_0.Rows[int_5].Cells["dgvcIdCable"]).DataSource = dataTable_0;
			((DataGridViewComboBoxCell)this.dataGridView_0.Rows[int_5].Cells["dgvcIdCable"]).DisplayMember = "Name";
			((DataGridViewComboBoxCell)this.dataGridView_0.Rows[int_5].Cells["dgvcIdCable"]).ValueMember = "Id";
		}
		return dataTable_0;
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		base.Close();
	}

	private void Form40_FormClosing(object sender, FormClosingEventArgs e)
	{
		IEnumerable<int> source = from DataGridViewRow row in this.dataGridView_0.Rows
		where row.Cells["Selected"].Value != null && (bool)row.Cells["Selected"].Value
		select (int)row.Cells["dgvcId"].Value;
		if (source.Count<int>() == 0 && base.DialogResult == DialogResult.OK)
		{
			MessageBox.Show("Не выбрано ни одной строки.", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			e.Cancel = true;
			return;
		}
		int[] ids = source.ToArray<int>();
		this.Rows = (from row in this.class255_0.tJ_MeasCable
		where ids.Contains(row.id)
		select row).ToArray<Class255.Class419>();
		this.method_9(this.class255_0.vJ_CableByCell);
	}

	private void method_26()
	{
		this.icontainer_0 = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
		this.tableLayoutPanel_0 = new TableLayoutPanel();
		this.dataGridView_0 = new DataGridView();
		this.bindingSource_0 = new BindingSource(this.icontainer_0);
		this.class255_0 = new Class255();
		this.tableLayoutPanel_1 = new TableLayoutPanel();
		this.button_0 = new Button();
		this.button_1 = new Button();
		this.bindingSource_1 = new BindingSource(this.icontainer_0);
		this.dataGridViewCheckBoxColumn_0 = new DataGridViewCheckBoxColumn();
		this.dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
		this.dataGridViewComboBoxColumn_0 = new DataGridViewComboBoxColumn();
		this.dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
		this.dataGridViewComboBoxColumn_1 = new DataGridViewComboBoxColumn();
		this.dataGridViewTextBoxColumn_3 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_4 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_5 = new DataGridViewTextBoxColumn();
		this.dataGridViewComboBoxColumn_2 = new DataGridViewComboBoxColumn();
		this.dataGridViewComboBoxColumn_3 = new DataGridViewComboBoxColumn();
		this.dataGridViewComboBoxColumn_4 = new DataGridViewComboBoxColumn();
		this.dataGridViewComboBoxColumn_5 = new DataGridViewComboBoxColumn();
		this.dataGridViewComboBoxColumn_6 = new DataGridViewComboBoxColumn();
		this.dataGridViewTextBoxColumn_6 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_7 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_8 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_9 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_10 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_11 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_12 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_13 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_14 = new DataGridViewTextBoxColumn();
		this.dataGridViewCheckBoxColumn_1 = new DataGridViewCheckBoxColumn();
		this.tableLayoutPanel_0.SuspendLayout();
		((ISupportInitialize)this.dataGridView_0).BeginInit();
		((ISupportInitialize)this.bindingSource_0).BeginInit();
		((ISupportInitialize)this.class255_0).BeginInit();
		this.tableLayoutPanel_1.SuspendLayout();
		((ISupportInitialize)this.bindingSource_1).BeginInit();
		base.SuspendLayout();
		this.tableLayoutPanel_0.ColumnCount = 1;
		this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
		this.tableLayoutPanel_0.Controls.Add(this.dataGridView_0, 0, 0);
		this.tableLayoutPanel_0.Controls.Add(this.tableLayoutPanel_1, 0, 1);
		this.tableLayoutPanel_0.Dock = DockStyle.Fill;
		this.tableLayoutPanel_0.Location = new Point(0, 0);
		this.tableLayoutPanel_0.Name = "tableLayoutPanel1";
		this.tableLayoutPanel_0.RowCount = 2;
		this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
		this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Absolute, 39f));
		this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
		this.tableLayoutPanel_0.Size = new Size(748, 294);
		this.tableLayoutPanel_0.TabIndex = 0;
		this.dataGridView_0.AllowUserToAddRows = false;
		this.dataGridView_0.AllowUserToDeleteRows = false;
		this.dataGridView_0.AllowUserToResizeRows = false;
		this.dataGridView_0.AutoGenerateColumns = false;
		this.dataGridView_0.BackgroundColor = Color.White;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle.BackColor = SystemColors.Control;
		dataGridViewCellStyle.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		this.dataGridView_0.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		this.dataGridView_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView_0.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewCheckBoxColumn_0,
			this.dataGridViewTextBoxColumn_0,
			this.dataGridViewTextBoxColumn_1,
			this.dataGridViewComboBoxColumn_0,
			this.dataGridViewTextBoxColumn_2,
			this.dataGridViewComboBoxColumn_1,
			this.dataGridViewTextBoxColumn_3,
			this.dataGridViewTextBoxColumn_4,
			this.dataGridViewTextBoxColumn_5,
			this.dataGridViewComboBoxColumn_2,
			this.dataGridViewComboBoxColumn_3,
			this.dataGridViewComboBoxColumn_4,
			this.dataGridViewComboBoxColumn_5,
			this.dataGridViewComboBoxColumn_6,
			this.dataGridViewTextBoxColumn_6,
			this.dataGridViewTextBoxColumn_7,
			this.dataGridViewTextBoxColumn_8,
			this.dataGridViewTextBoxColumn_9,
			this.dataGridViewTextBoxColumn_10,
			this.dataGridViewTextBoxColumn_11,
			this.dataGridViewTextBoxColumn_12,
			this.dataGridViewTextBoxColumn_13,
			this.dataGridViewTextBoxColumn_14,
			this.dataGridViewCheckBoxColumn_1
		});
		this.tableLayoutPanel_0.SetColumnSpan(this.dataGridView_0, 6);
		this.dataGridView_0.DataSource = this.bindingSource_0;
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = SystemColors.Window;
		dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
		this.dataGridView_0.DefaultCellStyle = dataGridViewCellStyle2;
		this.dataGridView_0.Dock = DockStyle.Fill;
		this.dataGridView_0.EditMode = DataGridViewEditMode.EditOnEnter;
		this.dataGridView_0.Location = new Point(3, 3);
		this.dataGridView_0.MultiSelect = false;
		this.dataGridView_0.Name = "dgvMeasCable";
		dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle3.BackColor = SystemColors.Control;
		dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
		this.dataGridView_0.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
		this.dataGridView_0.RowHeadersVisible = false;
		this.dataGridView_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		this.dataGridView_0.Size = new Size(742, 249);
		this.dataGridView_0.TabIndex = 21;
		this.dataGridView_0.CellBeginEdit += this.dataGridView_0_CellBeginEdit;
		this.dataGridView_0.CellEndEdit += this.dataGridView_0_CellEndEdit;
		this.dataGridView_0.DataError += this.dataGridView_0_DataError;
		this.dataGridView_0.RowsAdded += this.dataGridView_0_RowsAdded;
		this.bindingSource_0.DataMember = "tJ_MeasCable";
		this.bindingSource_0.DataSource = this.class255_0;
		this.class255_0.DataSetName = "DataSetGES";
		this.class255_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		this.tableLayoutPanel_1.ColumnCount = 2;
		this.tableLayoutPanel_0.SetColumnSpan(this.tableLayoutPanel_1, 5);
		this.tableLayoutPanel_1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		this.tableLayoutPanel_1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 116f));
		this.tableLayoutPanel_1.Controls.Add(this.button_0, 1, 0);
		this.tableLayoutPanel_1.Controls.Add(this.button_1, 0, 0);
		this.tableLayoutPanel_1.Dock = DockStyle.Fill;
		this.tableLayoutPanel_1.Location = new Point(3, 258);
		this.tableLayoutPanel_1.Name = "tableLayoutPanel2";
		this.tableLayoutPanel_1.RowCount = 1;
		this.tableLayoutPanel_1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		this.tableLayoutPanel_1.Size = new Size(742, 33);
		this.tableLayoutPanel_1.TabIndex = 20;
		this.button_0.DialogResult = DialogResult.Cancel;
		this.button_0.Dock = DockStyle.Left;
		this.button_0.Location = new Point(636, 3);
		this.button_0.Margin = new Padding(10, 3, 3, 3);
		this.button_0.Name = "btnCancel";
		this.button_0.Size = new Size(75, 27);
		this.button_0.TabIndex = 6;
		this.button_0.Text = "Отмена";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_0.Click += this.button_1_Click;
		this.button_1.DialogResult = DialogResult.OK;
		this.button_1.Dock = DockStyle.Right;
		this.button_1.Location = new Point(517, 3);
		this.button_1.Margin = new Padding(3, 3, 10, 3);
		this.button_1.Name = "btnAccept";
		this.button_1.Size = new Size(99, 27);
		this.button_1.TabIndex = 8;
		this.button_1.Text = "Применить";
		this.button_1.UseVisualStyleBackColor = true;
		this.button_1.Click += this.button_1_Click;
		this.bindingSource_1.DataMember = "vJ_CellByBus";
		this.bindingSource_1.DataSource = this.class255_0;
		this.bindingSource_1.Sort = "Name";
		this.dataGridViewCheckBoxColumn_0.HeaderText = "";
		this.dataGridViewCheckBoxColumn_0.Name = "Selected";
		this.dataGridViewCheckBoxColumn_0.Resizable = DataGridViewTriState.True;
		this.dataGridViewCheckBoxColumn_0.SortMode = DataGridViewColumnSortMode.Automatic;
		this.dataGridViewCheckBoxColumn_0.Width = 30;
		this.dataGridViewTextBoxColumn_0.DataPropertyName = "id";
		this.dataGridViewTextBoxColumn_0.HeaderText = "id";
		this.dataGridViewTextBoxColumn_0.Name = "dgvcId";
		this.dataGridViewTextBoxColumn_0.ReadOnly = true;
		this.dataGridViewTextBoxColumn_0.SortMode = DataGridViewColumnSortMode.Programmatic;
		this.dataGridViewTextBoxColumn_0.Visible = false;
		this.dataGridViewTextBoxColumn_0.Width = 40;
		this.dataGridViewTextBoxColumn_1.DataPropertyName = "idMeasTrans";
		this.dataGridViewTextBoxColumn_1.HeaderText = "idMeasTrans";
		this.dataGridViewTextBoxColumn_1.Name = "idMeasTrans";
		this.dataGridViewTextBoxColumn_1.SortMode = DataGridViewColumnSortMode.Programmatic;
		this.dataGridViewTextBoxColumn_1.Visible = false;
		this.dataGridViewComboBoxColumn_0.DataPropertyName = "idCell";
		this.dataGridViewComboBoxColumn_0.DataSource = this.bindingSource_1;
		this.dataGridViewComboBoxColumn_0.DisplayMember = "Name";
		this.dataGridViewComboBoxColumn_0.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
		this.dataGridViewComboBoxColumn_0.FlatStyle = FlatStyle.Popup;
		this.dataGridViewComboBoxColumn_0.HeaderText = "№ руб.";
		this.dataGridViewComboBoxColumn_0.Name = "dgvcIdCell";
		this.dataGridViewComboBoxColumn_0.Resizable = DataGridViewTriState.True;
		this.dataGridViewComboBoxColumn_0.SortMode = DataGridViewColumnSortMode.Programmatic;
		this.dataGridViewComboBoxColumn_0.ValueMember = "id";
		this.dataGridViewComboBoxColumn_0.Width = 30;
		this.dataGridViewTextBoxColumn_2.DataPropertyName = "OldCell";
		this.dataGridViewTextBoxColumn_2.HeaderText = "№ ст. руб.";
		this.dataGridViewTextBoxColumn_2.Name = "OldCell";
		this.dataGridViewTextBoxColumn_2.ReadOnly = true;
		this.dataGridViewTextBoxColumn_2.SortMode = DataGridViewColumnSortMode.Programmatic;
		this.dataGridViewTextBoxColumn_2.Visible = false;
		this.dataGridViewTextBoxColumn_2.Width = 50;
		this.dataGridViewComboBoxColumn_1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewComboBoxColumn_1.DataPropertyName = "idCable";
		this.dataGridViewComboBoxColumn_1.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
		this.dataGridViewComboBoxColumn_1.DropDownWidth = 200;
		this.dataGridViewComboBoxColumn_1.FlatStyle = FlatStyle.Popup;
		this.dataGridViewComboBoxColumn_1.HeaderText = "Кабель";
		this.dataGridViewComboBoxColumn_1.Name = "dgvcIdCable";
		this.dataGridViewComboBoxColumn_1.Resizable = DataGridViewTriState.True;
		this.dataGridViewComboBoxColumn_1.SortMode = DataGridViewColumnSortMode.Programmatic;
		this.dataGridViewTextBoxColumn_3.DataPropertyName = "Address";
		this.dataGridViewTextBoxColumn_3.HeaderText = "Адрес объекта";
		this.dataGridViewTextBoxColumn_3.Name = "Address";
		this.dataGridViewTextBoxColumn_3.ReadOnly = true;
		this.dataGridViewTextBoxColumn_3.Visible = false;
		this.dataGridViewTextBoxColumn_4.DataPropertyName = "Company";
		this.dataGridViewTextBoxColumn_4.HeaderText = "Наименование объекта";
		this.dataGridViewTextBoxColumn_4.Name = "Company";
		this.dataGridViewTextBoxColumn_4.ReadOnly = true;
		this.dataGridViewTextBoxColumn_4.Visible = false;
		this.dataGridViewTextBoxColumn_5.DataPropertyName = "idSchmAbn";
		this.dataGridViewTextBoxColumn_5.HeaderText = "idSchmAbn";
		this.dataGridViewTextBoxColumn_5.Name = "idSchmAbnDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_5.SortMode = DataGridViewColumnSortMode.Programmatic;
		this.dataGridViewTextBoxColumn_5.Visible = false;
		this.dataGridViewComboBoxColumn_2.DataPropertyName = "Makeup";
		this.dataGridViewComboBoxColumn_2.FlatStyle = FlatStyle.Popup;
		this.dataGridViewComboBoxColumn_2.HeaderText = "Марка кабеля";
		this.dataGridViewComboBoxColumn_2.Name = "dgvcCableMakeup";
		this.dataGridViewComboBoxColumn_2.Resizable = DataGridViewTriState.True;
		this.dataGridViewComboBoxColumn_2.SortMode = DataGridViewColumnSortMode.Programmatic;
		this.dataGridViewComboBoxColumn_2.Visible = false;
		this.dataGridViewComboBoxColumn_2.Width = 70;
		this.dataGridViewComboBoxColumn_3.DataPropertyName = "Voltage";
		this.dataGridViewComboBoxColumn_3.FlatStyle = FlatStyle.Popup;
		this.dataGridViewComboBoxColumn_3.HeaderText = "Напр.";
		this.dataGridViewComboBoxColumn_3.Name = "dgvcVoltage";
		this.dataGridViewComboBoxColumn_3.Resizable = DataGridViewTriState.True;
		this.dataGridViewComboBoxColumn_3.SortMode = DataGridViewColumnSortMode.Programmatic;
		this.dataGridViewComboBoxColumn_3.Visible = false;
		this.dataGridViewComboBoxColumn_3.Width = 70;
		this.dataGridViewComboBoxColumn_4.DataPropertyName = "Wires";
		dataGridViewCellStyle4.Format = "N0";
		this.dataGridViewComboBoxColumn_4.DefaultCellStyle = dataGridViewCellStyle4;
		this.dataGridViewComboBoxColumn_4.FlatStyle = FlatStyle.Popup;
		this.dataGridViewComboBoxColumn_4.HeaderText = "Кол-во жил";
		this.dataGridViewComboBoxColumn_4.Name = "dgvcWires";
		this.dataGridViewComboBoxColumn_4.Resizable = DataGridViewTriState.True;
		this.dataGridViewComboBoxColumn_4.SortMode = DataGridViewColumnSortMode.Programmatic;
		this.dataGridViewComboBoxColumn_4.Visible = false;
		this.dataGridViewComboBoxColumn_4.Width = 40;
		this.dataGridViewComboBoxColumn_5.DataPropertyName = "CrossSection";
		this.dataGridViewComboBoxColumn_5.FlatStyle = FlatStyle.Popup;
		this.dataGridViewComboBoxColumn_5.HeaderText = "Сечение";
		this.dataGridViewComboBoxColumn_5.Name = "dgvcCrossSection";
		this.dataGridViewComboBoxColumn_5.Resizable = DataGridViewTriState.True;
		this.dataGridViewComboBoxColumn_5.SortMode = DataGridViewColumnSortMode.Programmatic;
		this.dataGridViewComboBoxColumn_5.Visible = false;
		this.dataGridViewComboBoxColumn_5.Width = 50;
		this.dataGridViewComboBoxColumn_6.DataPropertyName = "PermisAmperage";
		this.dataGridViewComboBoxColumn_6.DropDownWidth = 90;
		this.dataGridViewComboBoxColumn_6.FlatStyle = FlatStyle.Popup;
		this.dataGridViewComboBoxColumn_6.HeaderText = "Допуст. нагр., А";
		this.dataGridViewComboBoxColumn_6.Name = "dgvcPermisAmperage";
		this.dataGridViewComboBoxColumn_6.Resizable = DataGridViewTriState.True;
		this.dataGridViewComboBoxColumn_6.SortMode = DataGridViewColumnSortMode.Programmatic;
		this.dataGridViewComboBoxColumn_6.Visible = false;
		this.dataGridViewComboBoxColumn_6.Width = 60;
		this.dataGridViewTextBoxColumn_6.DataPropertyName = "Iad";
		dataGridViewCellStyle5.Format = "N0";
		this.dataGridViewTextBoxColumn_6.DefaultCellStyle = dataGridViewCellStyle5;
		this.dataGridViewTextBoxColumn_6.HeaderText = "А дн.";
		this.dataGridViewTextBoxColumn_6.Name = "Iad";
		this.dataGridViewTextBoxColumn_6.SortMode = DataGridViewColumnSortMode.Programmatic;
		this.dataGridViewTextBoxColumn_6.Visible = false;
		this.dataGridViewTextBoxColumn_6.Width = 35;
		this.dataGridViewTextBoxColumn_7.DataPropertyName = "Ian";
		dataGridViewCellStyle6.Format = "N0";
		this.dataGridViewTextBoxColumn_7.DefaultCellStyle = dataGridViewCellStyle6;
		this.dataGridViewTextBoxColumn_7.HeaderText = "А вч.";
		this.dataGridViewTextBoxColumn_7.Name = "Ian";
		this.dataGridViewTextBoxColumn_7.SortMode = DataGridViewColumnSortMode.Programmatic;
		this.dataGridViewTextBoxColumn_7.Visible = false;
		this.dataGridViewTextBoxColumn_7.Width = 35;
		this.dataGridViewTextBoxColumn_8.DataPropertyName = "Ibd";
		dataGridViewCellStyle7.Format = "N0";
		this.dataGridViewTextBoxColumn_8.DefaultCellStyle = dataGridViewCellStyle7;
		this.dataGridViewTextBoxColumn_8.HeaderText = "В дн.";
		this.dataGridViewTextBoxColumn_8.Name = "Ibd";
		this.dataGridViewTextBoxColumn_8.SortMode = DataGridViewColumnSortMode.Programmatic;
		this.dataGridViewTextBoxColumn_8.Visible = false;
		this.dataGridViewTextBoxColumn_8.Width = 35;
		this.dataGridViewTextBoxColumn_9.DataPropertyName = "Ibn";
		dataGridViewCellStyle8.Format = "N0";
		this.dataGridViewTextBoxColumn_9.DefaultCellStyle = dataGridViewCellStyle8;
		this.dataGridViewTextBoxColumn_9.HeaderText = "В вч.";
		this.dataGridViewTextBoxColumn_9.Name = "Ibn";
		this.dataGridViewTextBoxColumn_9.SortMode = DataGridViewColumnSortMode.Programmatic;
		this.dataGridViewTextBoxColumn_9.Visible = false;
		this.dataGridViewTextBoxColumn_9.Width = 35;
		this.dataGridViewTextBoxColumn_10.DataPropertyName = "Icd";
		dataGridViewCellStyle9.Format = "N0";
		this.dataGridViewTextBoxColumn_10.DefaultCellStyle = dataGridViewCellStyle9;
		this.dataGridViewTextBoxColumn_10.HeaderText = "С дн.";
		this.dataGridViewTextBoxColumn_10.Name = "Icd";
		this.dataGridViewTextBoxColumn_10.SortMode = DataGridViewColumnSortMode.Programmatic;
		this.dataGridViewTextBoxColumn_10.Visible = false;
		this.dataGridViewTextBoxColumn_10.Width = 35;
		this.dataGridViewTextBoxColumn_11.DataPropertyName = "Icn";
		dataGridViewCellStyle10.Format = "N0";
		this.dataGridViewTextBoxColumn_11.DefaultCellStyle = dataGridViewCellStyle10;
		this.dataGridViewTextBoxColumn_11.HeaderText = "С вч.";
		this.dataGridViewTextBoxColumn_11.Name = "Icn";
		this.dataGridViewTextBoxColumn_11.SortMode = DataGridViewColumnSortMode.Programmatic;
		this.dataGridViewTextBoxColumn_11.Visible = false;
		this.dataGridViewTextBoxColumn_11.Width = 35;
		this.dataGridViewTextBoxColumn_12.DataPropertyName = "Iod";
		dataGridViewCellStyle11.Format = "N0";
		this.dataGridViewTextBoxColumn_12.DefaultCellStyle = dataGridViewCellStyle11;
		this.dataGridViewTextBoxColumn_12.HeaderText = "0 дн.";
		this.dataGridViewTextBoxColumn_12.Name = "Iod";
		this.dataGridViewTextBoxColumn_12.SortMode = DataGridViewColumnSortMode.Programmatic;
		this.dataGridViewTextBoxColumn_12.Visible = false;
		this.dataGridViewTextBoxColumn_12.Width = 35;
		this.dataGridViewTextBoxColumn_13.DataPropertyName = "Ion";
		dataGridViewCellStyle12.Format = "N0";
		dataGridViewCellStyle12.NullValue = null;
		this.dataGridViewTextBoxColumn_13.DefaultCellStyle = dataGridViewCellStyle12;
		this.dataGridViewTextBoxColumn_13.HeaderText = "0 вч.";
		this.dataGridViewTextBoxColumn_13.Name = "Ion";
		this.dataGridViewTextBoxColumn_13.SortMode = DataGridViewColumnSortMode.Programmatic;
		this.dataGridViewTextBoxColumn_13.Visible = false;
		this.dataGridViewTextBoxColumn_13.Width = 35;
		this.dataGridViewTextBoxColumn_14.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_14.DataPropertyName = "Comment";
		this.dataGridViewTextBoxColumn_14.HeaderText = "Комментарий";
		this.dataGridViewTextBoxColumn_14.MinimumWidth = 80;
		this.dataGridViewTextBoxColumn_14.Name = "commentDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_14.SortMode = DataGridViewColumnSortMode.Programmatic;
		this.dataGridViewTextBoxColumn_14.Visible = false;
		this.dataGridViewCheckBoxColumn_1.DataPropertyName = "Deleted";
		this.dataGridViewCheckBoxColumn_1.HeaderText = "Deleted";
		this.dataGridViewCheckBoxColumn_1.Name = "deletedDataGridViewCheckBoxColumn";
		this.dataGridViewCheckBoxColumn_1.SortMode = DataGridViewColumnSortMode.Programmatic;
		this.dataGridViewCheckBoxColumn_1.Visible = false;
		base.AcceptButton = this.button_1;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = this.button_0;
		base.ClientSize = new Size(748, 294);
		base.Controls.Add(this.tableLayoutPanel_0);
		base.Name = "FormAddMeasCable";
		this.Text = "Добавление недостающих кабельных линий";
		base.FormClosing += this.Form40_FormClosing;
		base.Load += this.Form40_Load;
		this.tableLayoutPanel_0.ResumeLayout(false);
		((ISupportInitialize)this.dataGridView_0).EndInit();
		((ISupportInitialize)this.bindingSource_0).EndInit();
		((ISupportInitialize)this.class255_0).EndInit();
		this.tableLayoutPanel_1.ResumeLayout(false);
		((ISupportInitialize)this.bindingSource_1).EndInit();
		base.ResumeLayout(false);
	}

	[CompilerGenerated]
	private bool method_27(<>f__AnonymousType8<Class255.Class432, Class255.Class422> <>f__AnonymousType8_0)
	{
		return (from t in this.class255_0.vJ_TransfByCell
		where t.idCell == <>f__AnonymousType8_0.c.id
		select t).Count<Class255.Class421>() == 0;
	}

	[CompilerGenerated]
	private bool method_28(<>f__AnonymousType7<int, int, string, int, string> <>f__AnonymousType7_0)
	{
		if ((from Class255.Class419 rowCell in this.class255_0.tJ_MeasCable
		where rowCell["idCell"] != DBNull.Value
		select rowCell.idCell).ToArray<int>().Contains(<>f__AnonymousType7_0.idCell))
		{
			return !(from Class255.Class419 rowCable in this.class255_0.tJ_MeasCable
			where rowCable["idCable"] != DBNull.Value
			select rowCable.idCable).ToArray<int>().Contains(<>f__AnonymousType7_0.idCable);
		}
		return true;
	}

	[CompilerGenerated]
	private int int_0;

	[CompilerGenerated]
	private int int_1;

	[CompilerGenerated]
	private int int_2;

	[CompilerGenerated]
	private int int_3;

	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private Class255.Class419[] class419_0;

	[CompilerGenerated]
	private Class255.Class316 class316_0;

	[CompilerGenerated]
	private int int_4;

	[CompilerGenerated]
	private FormMeasurement.TypeDoc typeDoc_0;

	private TableLayoutPanel tableLayoutPanel_0;

	private TableLayoutPanel tableLayoutPanel_1;

	private Button button_0;

	private Button button_1;

	private Class255 class255_0;

	private BindingSource bindingSource_0;

	private DataGridView dataGridView_0;

	private BindingSource bindingSource_1;

	private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_1;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_3;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_4;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_5;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_2;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_3;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_4;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_5;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_6;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_6;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_7;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_8;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_9;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_10;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_11;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_12;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_13;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_14;

	private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn_1;
}
