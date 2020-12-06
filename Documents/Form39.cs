using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Constants;
using ControlsLbr;
using DataSql;
using Documents.Forms.Measurement;
using Documents.Properties;
using FormLbr;
using FormLbr.Classes;
using Passport.Classes;
using Reference.Forms;

internal partial class Form39 : FormBase
{
	internal int Year { get; set; }

	[CompilerGenerated]
	internal int method_0()
	{
		return this.int_1;
	}

	[CompilerGenerated]
	internal void method_1(int int_7)
	{
		this.int_1 = int_7;
	}

	[CompilerGenerated]
	internal int method_2()
	{
		return this.int_2;
	}

	[CompilerGenerated]
	internal void method_3(int int_7)
	{
		this.int_2 = int_7;
	}

	[CompilerGenerated]
	internal string method_4()
	{
		return this.string_0;
	}

	[CompilerGenerated]
	internal void method_5(string string_2)
	{
		this.string_0 = string_2;
	}

	[CompilerGenerated]
	internal int method_6()
	{
		return this.int_3;
	}

	[CompilerGenerated]
	internal void method_7(int int_7)
	{
		this.int_3 = int_7;
	}

	internal int IdBus { get; set; }

	[CompilerGenerated]
	internal int method_8()
	{
		return this.int_5;
	}

	[CompilerGenerated]
	internal void method_9(int int_7)
	{
		this.int_5 = int_7;
	}

	[CompilerGenerated]
	internal StateFormCreate method_10()
	{
		return this.stateFormCreate_0;
	}

	[CompilerGenerated]
	internal void method_11(StateFormCreate stateFormCreate_1)
	{
		this.stateFormCreate_0 = stateFormCreate_1;
	}

	internal Form39()
	{
		
		
		this.method_51();
	}

	internal Form39(SQLSettings sqlsettings_0, int int_7, string string_2, int int_8 = -1, int int_9 = -1, int int_10 = -1)
	{
		
		
		this.method_51();
		this.SqlSettings = sqlsettings_0;
		this.method_1(int_7);
		this.method_5(string_2);
		this.method_3(int_10);
		this.IdBus = int_8;
		this.method_7(int_9);
		this.method_11((int_10 == -1) ? StateFormCreate.Add : StateFormCreate.Edit);
	}

	private void textBox_11_KeyPress(object sender, KeyPressEventArgs e)
	{
		InputCheck.OnlyDigit(sender, e);
	}

	private void Form39_Load(object sender, EventArgs e)
	{
		this.Text = ((this.method_10() == StateFormCreate.Add) ? "Добавление замера" : "Редактирование замера");
		this.Text += ((this.method_4().Length > 0) ? (": " + this.method_4()) : "");
		this.dataGridView_0.Columns["dgvcIdCell"].ReadOnly = (this.method_10() == StateFormCreate.Add);
		this.dataGridView_0.Columns["dgvcIdCable"].ReadOnly = (this.method_10() == StateFormCreate.Add);
		this.method_15();
		this.method_18();
		this.method_17();
		this.method_16();
		this.int_6 = this.method_14();
		if (this.method_10() == StateFormCreate.Add)
		{
			this.method_13();
		}
		else
		{
			base.SelectSqlData(this.class255_0, this.class255_0.tJ_Measurement, true, string.Format("WHERE id = {0} AND Deleted = ((0))", this.method_2()));
		}
		this.method_12();
		InputCheck.AddBindingNull(this.textBox_11);
		InputCheck.AddBindingNull(this.textBox_7);
		InputCheck.AddBindingNull(this.textBox_9);
		InputCheck.AddBindingNull(this.textBox_6);
		InputCheck.AddBindingNull(this.textBox_10);
		InputCheck.AddBindingNull(this.textBox_2);
		InputCheck.AddBindingNull(this.textBox_5);
		InputCheck.AddBindingNull(this.textBox_3);
		InputCheck.AddBindingNull(this.textBox_8);
		InputCheck.AddBindingNull(this.textBox_1);
		InputCheck.AddBindingNull(this.textBox_4);
		InputCheck.AddBindingNull(this.textBox_0);
	}

	private void method_12()
	{
		this.bindingSource_12.RaiseListChangedEvents = true;
		this.bindingSource_12.CurrentChanged -= this.bindingSource_12_CurrentChanged;
		if (this.method_10() == StateFormCreate.Edit)
		{
			base.SelectSqlData(this.class255_0, this.class255_0.vJ_BusesTransfs, true, string.Format("WHERE idMeasurement = {0} ORDER By Name", this.method_2()));
			base.SelectSqlData(this.class255_0, this.class255_0.vJ_BusesTransfSchema, true, string.Format("WHERE idSub = {0} AND parentKeyBus = ';SCM;BUS;BUSLV;' ORDER By NameTransf", this.method_0()));
			var enumerable = (from row in this.class255_0.vJ_BusesTransfSchema
			select new
			{
				idBus = row.idBus,
				NameBus = row.nameBus,
				idTransf = ((row["idTransf"] == DBNull.Value) ? -1 : row.idTransf),
				NameTransf = ((row["NameTransf"] == DBNull.Value) ? "" : row.NameTransf),
				NameBusTransf = ((row["nameBusTransf"] == DBNull.Value) ? row.nameBus : row.nameBusTransf)
			}).Except(from row in this.class255_0.vJ_BusesTransfs
			select new
			{
				idBus = ((row["IdBus"] == DBNull.Value) ? -1 : row.idBus),
				NameBus = ((row["nameBus"] == DBNull.Value) ? "" : row.nameBus),
				idTransf = ((row["idTransf"] == DBNull.Value) ? -1 : row.idTransf),
				NameTransf = ((row["nameTransf"] == DBNull.Value) ? "" : row.nameTransf),
				NameBusTransf = row.Name
			}).Union(from row in this.class255_0.vJ_BusesTransfs
			select new
			{
				idBus = ((row["IdBus"] == DBNull.Value) ? -1 : row.idBus),
				NameBus = ((row["nameBus"] == DBNull.Value) ? "" : row.nameBus),
				idTransf = ((row["idTransf"] == DBNull.Value) ? -1 : row.idTransf),
				NameTransf = ((row["nameTransf"] == DBNull.Value) ? "" : row.nameTransf),
				NameBusTransf = row.Name
			});
			this.class255_0.dtBusesTransf.Rows.Clear();
			foreach (var <>f__AnonymousType in enumerable)
			{
				Class255.Class433 @class = this.class255_0.dtBusesTransf.method_4();
				@class.idBus = <>f__AnonymousType.idBus;
				@class.NameBus = <>f__AnonymousType.NameBus;
				@class.idTransf = <>f__AnonymousType.idTransf;
				@class.NameTransf = <>f__AnonymousType.NameTransf;
				@class.NameBusTransf = <>f__AnonymousType.NameBusTransf;
				this.class255_0.dtBusesTransf.method_0(@class);
			}
		}
		if (this.method_10() == StateFormCreate.Add)
		{
			base.SelectSqlData(this.class255_0, this.class255_0.vJ_BusesTransfSchema, true, string.Format("WHERE idSub = {0} AND parentKeyBus = ';SCM;BUS;BUSLV;' ORDER By NameTransf", this.method_0()));
			this.class255_0.dtBusesTransf.Rows.Clear();
			foreach (Class255.Class434 class2 in this.class255_0.vJ_BusesTransfSchema)
			{
				Class255.Class433 class3 = this.class255_0.dtBusesTransf.method_4();
				class3.idBus = class2.idBus;
				class3.NameBus = class2.nameBus;
				class3.idTransf = class2.idTransf;
				class3.NameTransf = class2.NameTransf;
				class3.NameBusTransf = class2.nameBusTransf;
				this.class255_0.dtBusesTransf.method_0(class3);
			}
			DataTable dataTable = (from r in this.class255_0.dtBusesTransf
			orderby r.NameBusTransf
			select r).CopyToDataTable<Class255.Class433>();
			this.class255_0.dtBusesTransf.Rows.Clear();
			foreach (object obj in dataTable.Rows)
			{
				DataRow row2 = (DataRow)obj;
				this.class255_0.dtBusesTransf.ImportRow(row2);
			}
		}
		this.method_6();
		if (this.method_6() != -1)
		{
			this.method_6();
		}
		else
		{
			int idBus = this.IdBus;
		}
		if (this.method_6() == -1)
		{
			int num = this.bindingSource_12.Find("IdBus", this.IdBus);
			if (num != -1)
			{
				this.bindingSource_12.Position = num;
			}
		}
		else
		{
			EnumerableRowCollection<Class255.Class433> source = this.class255_0.dtBusesTransf.Where(new Func<Class255.Class433, bool>(this.method_52));
			if (source.Count<Class255.Class433>() > 0)
			{
				this.bindingSource_12.Position = this.class255_0.dtBusesTransf.Rows.IndexOf(source.First<Class255.Class433>());
			}
		}
		this.bindingSource_12.CurrentChanged += this.bindingSource_12_CurrentChanged;
		this.bindingSource_12.RaiseListChangedEvents = false;
		this.bindingSource_12_CurrentChanged(this.bindingSource_12, new EventArgs());
	}

	private void method_13()
	{
		Class255.Class410 @class = this.class255_0.tJ_Measurement.method_5();
		@class.idObjList = this.method_0();
		@class.TypeDoc = this.int_6;
		try
		{
			SqlDataConnect sqlDataConnect = new SqlDataConnect();
			sqlDataConnect.OpenConnection(this.SqlSettings);
			SqlCommand sqlCommand = new SqlCommand(string.Format("select dbo.fn_J_GetIdDefaultMounterWorker({0})", this.method_0().ToString()), sqlDataConnect.Connection);
			@class.idWorker = (int)sqlCommand.ExecuteScalar();
		}
		catch
		{
			@class.idWorker = -1;
		}
		@class.Deleted = false;
		this.class255_0.tJ_Measurement.method_0(@class);
	}

	private int method_14()
	{
		return (from row in this.class255_0.tR_Classifier
		where row.ParentKey == ";Measurement;Type;" && row.Value == 1m
		select row.Id).First<int>();
	}

	private void method_15()
	{
		DataTable dataTable = new DataTable();
		dataTable.Columns.Add("Year");
		for (int i = DateTime.Now.Year - 10; i < DateTime.Now.Year + 11; i++)
		{
			dataTable.Rows.Add(new object[]
			{
				i
			});
		}
		this.comboBox_3.DataSource = dataTable;
		this.comboBox_3.DisplayMember = "Year";
		this.comboBox_3.ValueMember = "Year";
		this.comboBox_3.SelectedValue = DateTime.Now.Year;
	}

	private void method_16()
	{
		base.SelectSqlData(this.class255_0, this.class255_0.vP_Worker, true, string.Format("WHERE ParentKey = ';GroupWorker;Meas;' AND DateEnd IS NULL", new object[0]));
		Class255.Class381 @class = this.class255_0.vP_Worker.method_4();
		@class.Id = -1;
		@class.F = "";
		@class.FIO = "";
		@class.ParentKey = "";
		@class.idGroup = 1;
		@class.isGroup = false;
		this.class255_0.vP_Worker.method_0(@class);
	}

	private void method_17()
	{
		base.SelectSqlData(this.class255_0, this.class255_0.tR_Classifier, true, string.Format("WHERE ParentKey IN (';Measurement;Type;', ';Measurement;Switch;') AND Deleted = ((0)) AND isGroup = ((0))", new object[0]));
		Class255.Class369 @class = this.class255_0.tR_Classifier.method_5();
		@class.Id = -1;
		@class.Name = "";
		@class.ParentKey = ";Measurement;Switch;";
		@class.IsGroup = false;
		@class.Deleted = false;
		this.class255_0.tR_Classifier.method_0(@class);
	}

	private void method_18()
	{
		base.SelectSqlData(this.class255_0, this.class255_0.vJ_CableReference, true);
	}

	private void method_19(int int_7)
	{
		try
		{
			DataTable dataTable = this.class255_0.DataTableCollection_0["dtCable_" + this.method_6().ToString() + "_" + int_7.ToString()];
			if (((DataGridViewComboBoxCell)this.dataGridView_0.Rows[int_7].Cells["dgvcIdCable"]).DataSource == null)
			{
				if (dataTable == null)
				{
					dataTable = new DataTable("dtCable_" + this.method_6().ToString() + "_" + int_7.ToString());
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
				BindingSource bindingSource = new BindingSource();
				bindingSource.DataSource = dataTable;
				((DataGridViewComboBoxCell)this.dataGridView_0.Rows[int_7].Cells["dgvcIdCable"]).DataSource = bindingSource;
				((DataGridViewComboBoxCell)this.dataGridView_0.Rows[int_7].Cells["dgvcIdCable"]).DisplayMember = "Name";
				((DataGridViewComboBoxCell)this.dataGridView_0.Rows[int_7].Cells["dgvcIdCable"]).ValueMember = "Id";
			}
			string makeup = (this.dataGridView_0.Rows[int_7].Cells["dgvcCableMakeup"].Value is string) ? this.dataGridView_0.Rows[int_7].Cells["dgvcCableMakeup"].Value.ToString() : "";
			DataTable dataTable2 = this.method_33(int_7, true);
			DataRow dataRow = dataTable2.NewRow();
			dataRow["CableMakeup"] = "";
			dataTable2.Rows.InsertAt(dataRow, 0);
			if ((from r in dataTable2.AsEnumerable()
			where r.Field("CableMakeup") == makeup
			select r).Count<DataRow>() == 0)
			{
				DataRow dataRow2 = dataTable2.NewRow();
				dataRow2["CableMakeup"] = makeup;
				dataTable2.Rows.InsertAt(dataRow2, 1);
			}
			int? num = this.method_26(int_7, makeup);
			double double_ = 0.0;
			if (num != null)
			{
				double_ = this.method_29(int_7, makeup, num.Value);
			}
			if (num != null)
			{
				this.method_32(int_7, makeup, num.Value, double_);
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void method_20()
	{
		if (this.bindingSource_3.Count > 0 && ((DataRowView)this.bindingSource_3.Current)["idCell"] is int)
		{
			base.SelectSqlData(this.class255_0.vJ_MeasAbnObj, true, string.Format("WHERE idSchmObj = {0}", (int)((DataRowView)this.bindingSource_3.Current)["idCell"]), new int?(120), false, 0);
		}
	}

	private void method_21(List<string> list_1)
	{
		this.method_20();
		if (list_1.Count > 0)
		{
			foreach (object obj in this.dataGridView_1.SelectedRows)
			{
				((DataGridViewRow)obj).Selected = false;
			}
			foreach (string b in list_1)
			{
				foreach (object obj2 in ((IEnumerable)this.dataGridView_1.Rows))
				{
					DataGridViewRow dataGridViewRow = (DataGridViewRow)obj2;
					if (dataGridViewRow.Cells["dgvcIds"].Value.ToString() == b)
					{
						dataGridViewRow.Selected = true;
					}
				}
			}
			MessageBox.Show("Оставшиеся выделенные строки невозможно удалить.", "Внимание.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
	}

	private DataTable method_22(int int_7, DataTable dataTable_0)
	{
		dataTable_0 = this.class255_0.DataTableCollection_0["dtCableMakeup_" + this.method_6().ToString() + "_" + int_7.ToString()];
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

	private void method_23(int int_7, string string_2)
	{
		DataTable dataTable = new DataTable();
		dataTable = this.method_22(int_7, dataTable);
		DataRow dataRow = dataTable.NewRow();
		dataRow["CableMakeup"] = "";
		dataTable.Rows.InsertAt(dataRow, 0);
		if ((from r in dataTable.AsEnumerable()
		where r["CableMakeup"] != DBNull.Value && r.Field("CableMakeup").ToUpper().Trim() == string_2.ToUpper().Trim()
		select r).Count<DataRow>() == 0)
		{
			DataRow dataRow2 = dataTable.NewRow();
			dataRow2["CableMakeup"] = string_2;
			dataTable.Rows.InsertAt(dataRow2, 1);
		}
	}

	private DataTable method_24(int int_7, DataTable dataTable_0, string string_2)
	{
		dataTable_0 = this.class255_0.DataTableCollection_0["dtWires_" + this.method_6().ToString() + "_" + int_7.ToString()];
		IEnumerable<int> enumerable = (from row in this.class255_0.vJ_CableReference.AsEnumerable<Class255.Class395>()
		where row.CableMakeup.StartsWith(string_2) && row.CableMakeup.EndsWith(string_2)
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

	private DataTable method_25(int int_7, string string_2)
	{
		DataTable dataTable;
		if (this.class255_0.DataTableCollection_0.Contains("dtWires_" + this.method_6().ToString() + "_" + int_7.ToString()))
		{
			dataTable = this.class255_0.DataTableCollection_0["dtWires_" + this.method_6().ToString() + "_" + int_7.ToString()];
		}
		else
		{
			dataTable = new DataTable("dtWires_" + this.method_6().ToString() + "_" + int_7.ToString());
			dataTable.Columns.Add("Wires", typeof(int));
			this.class255_0.DataTableCollection_0.Add(dataTable);
		}
		BindingSource bindingSource = new BindingSource();
		bindingSource.CurrentChanged -= this.method_35;
		bindingSource.DataSource = dataTable;
		((DataGridViewComboBoxCell)this.dataGridView_0.Rows[int_7].Cells["dgvcWires"]).DataSource = bindingSource;
		((DataGridViewComboBoxCell)this.dataGridView_0.Rows[int_7].Cells["dgvcWires"]).DisplayMember = "Wires";
		((DataGridViewComboBoxCell)this.dataGridView_0.Rows[int_7].Cells["dgvcWires"]).ValueMember = "Wires";
		dataTable = this.method_24(int_7, dataTable, string_2);
		bindingSource.CurrentChanged += this.method_35;
		return dataTable;
	}

	private int? method_26(int int_7, string string_2)
	{
		int? wires = null;
		if (this.dataGridView_0.Rows[int_7].Cells["dgvcWires"].Value is int)
		{
			wires = new int?((int)this.dataGridView_0.Rows[int_7].Cells["dgvcWires"].Value);
		}
		DataTable dataTable = this.method_25(int_7, string_2);
		DataRow dataRow = dataTable.NewRow();
		dataRow["Wires"] = DBNull.Value;
		dataTable.Rows.InsertAt(dataRow, 0);
		if (wires != null && (from r in dataTable.AsEnumerable()
		where r["Wires"] != DBNull.Value && r.Field("Wires") == wires
		select r).Count<DataRow>() == 0)
		{
			DataRow dataRow2 = dataTable.NewRow();
			dataRow2["Wires"] = wires;
			dataTable.Rows.InsertAt(dataRow2, 1);
		}
		return wires;
	}

	private DataTable method_27(int int_7, DataTable dataTable_0)
	{
		dataTable_0 = this.class255_0.DataTableCollection_0["dtCrossSection_" + this.method_6().ToString() + "_" + int_7.ToString()];
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

	private DataTable method_28(int int_7, DataTable dataTable_0, string string_2, int int_8)
	{
		dataTable_0 = this.class255_0.DataTableCollection_0["dtCrossSection_" + this.method_6().ToString() + "_" + int_7.ToString()];
		IEnumerable<double> enumerable = (from row in this.class255_0.vJ_CableReference.AsEnumerable<Class255.Class395>()
		where row.CableMakeup == string_2 && row.Wires == int_8 && row.Voltage == 0.4m
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

	private double method_29(int int_7, string string_2, int int_8)
	{
		double crossSection = (this.dataGridView_0.Rows[int_7].Cells["dgvcCrossSection"].Value is double) ? ((double)this.dataGridView_0.Rows[int_7].Cells["dgvcCrossSection"].Value) : 0.0;
		DataTable dataTable = this.method_38(int_7, false);
		dataTable = this.method_28(int_7, dataTable, string_2, int_8);
		DataRow dataRow = dataTable.NewRow();
		dataRow["CrossSection"] = DBNull.Value;
		dataTable.Rows.InsertAt(dataRow, 0);
		if ((from r in dataTable.AsEnumerable()
		where r["CrossSection"] != DBNull.Value && r.Field("CrossSection") == crossSection
		select r).Count<DataRow>() == 0)
		{
			DataRow dataRow2 = dataTable.NewRow();
			dataRow2["CrossSection"] = crossSection;
			dataTable.Rows.InsertAt(dataRow2, 1);
		}
		return crossSection;
	}

	private DataTable method_30(int int_7, DataTable dataTable_0)
	{
		dataTable_0 = this.class255_0.DataTableCollection_0["dtPermisAmperage_" + this.method_6().ToString() + "_" + int_7.ToString()];
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

	private DataTable method_31(int int_7, DataTable dataTable_0, string string_2, int int_8, double double_0)
	{
		dataTable_0 = this.class255_0.DataTableCollection_0["dtPermisAmperage_" + this.method_6().ToString() + "_" + int_7.ToString()];
		var enumerable = (from row in this.class255_0.vJ_CableReference.AsEnumerable<Class255.Class395>()
		where row.CableMakeup == string_2 && row.Wires == int_8 && row.CrossSection == double_0 && row.Voltage == 0.4m
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

	private void method_32(int int_7, string string_2, int int_8, double double_0)
	{
		double num = (this.dataGridView_0.Rows[int_7].Cells["dgvcPermisAmperage"].Value is double) ? ((double)this.dataGridView_0.Rows[int_7].Cells["dgvcPermisAmperage"].Value) : 0.0;
		DataTable dataTable = this.method_37(int_7, false);
		dataTable = this.method_31(int_7, dataTable, string_2, int_8, double_0);
		if (dataTable.Select("AmperageValue = " + num.ToString().Replace(',', '.')).Length == 0)
		{
			DataRow dataRow = dataTable.NewRow();
			dataRow["AmperageType"] = num;
			dataRow["AmperageValue"] = num;
			dataTable.Rows.InsertAt(dataRow, 0);
		}
	}

	private DataTable method_33(int int_7, bool bool_1)
	{
		DataTable dataTable;
		if (this.class255_0.DataTableCollection_0.Contains("dtCableMakeup_" + this.method_6().ToString() + "_" + int_7.ToString()))
		{
			dataTable = this.class255_0.DataTableCollection_0["dtCableMakeup_" + this.method_6().ToString() + "_" + int_7.ToString()];
		}
		else
		{
			dataTable = new DataTable("dtCableMakeup_" + this.method_6().ToString() + "_" + int_7.ToString());
			dataTable.Columns.Add("CableMakeup", typeof(string));
			this.class255_0.DataTableCollection_0.Add(dataTable);
		}
		dataTable = this.method_22(int_7, dataTable);
		BindingSource bindingSource = new BindingSource();
		bindingSource.RaiseListChangedEvents = true;
		bindingSource.CurrentChanged -= this.method_34;
		bindingSource.DataSource = dataTable;
		((DataGridViewComboBoxCell)this.dataGridView_0.Rows[int_7].Cells["dgvcCableMakeup"]).DataSource = bindingSource;
		((DataGridViewComboBoxCell)this.dataGridView_0.Rows[int_7].Cells["dgvcCableMakeup"]).DisplayMember = "CableMakeup";
		((DataGridViewComboBoxCell)this.dataGridView_0.Rows[int_7].Cells["dgvcCableMakeup"]).ValueMember = "CableMakeup";
		bindingSource.CurrentChanged += this.method_34;
		bindingSource.RaiseListChangedEvents = false;
		return dataTable;
	}

	private void method_34(object sender, EventArgs e)
	{
		Point currentCellAddress = this.dataGridView_0.CurrentCellAddress;
		if (currentCellAddress.X != -1 && currentCellAddress.Y != -1)
		{
			DataGridViewComboBoxCell dataGridViewComboBoxCell = (DataGridViewComboBoxCell)this.dataGridView_0.Rows[currentCellAddress.Y].Cells["dgvcWires"];
			if (((BindingSource)sender).Current != null)
			{
				this.method_26(dataGridViewComboBoxCell.RowIndex, ((DataRowView)((BindingSource)sender).Current)["CableMakeup"].ToString());
			}
		}
	}

	private void method_35(object sender, EventArgs e)
	{
		Point currentCellAddress = this.dataGridView_0.CurrentCellAddress;
		if (currentCellAddress.X != -1 && currentCellAddress.Y != -1)
		{
			DataGridViewCell dataGridViewCell = this.dataGridView_0.Rows[currentCellAddress.Y].Cells["dgvcCableMakeup"];
			DataGridViewComboBoxCell dataGridViewComboBoxCell = (DataGridViewComboBoxCell)this.dataGridView_0.Rows[currentCellAddress.Y].Cells["dgvcCrossSection"];
			if (((BindingSource)sender).Current != null)
			{
				int int_ = (((DataRowView)((BindingSource)sender).Current)["Wires"] is int) ? ((int)((DataRowView)((BindingSource)sender).Current)["Wires"]) : -1;
				this.method_29(dataGridViewComboBoxCell.RowIndex, dataGridViewCell.Value.ToString(), int_);
			}
		}
	}

	private void method_36(object sender, EventArgs e)
	{
		Point currentCellAddress = this.dataGridView_0.CurrentCellAddress;
		if (currentCellAddress.X != -1 && currentCellAddress.Y != -1)
		{
			DataGridViewCell dataGridViewCell = this.dataGridView_0.Rows[currentCellAddress.Y].Cells["dgvcCableMakeup"];
			DataGridViewCell dataGridViewCell2 = this.dataGridView_0.Rows[currentCellAddress.Y].Cells["dgvcWires"];
			DataGridViewComboBoxCell dataGridViewComboBoxCell = (DataGridViewComboBoxCell)this.dataGridView_0.Rows[currentCellAddress.Y].Cells["dgvcCrossSection"];
			if (((BindingSource)sender).Current != null)
			{
				double double_ = (((DataRowView)((BindingSource)sender).Current)["CrossSection"] is double) ? ((double)((DataRowView)((BindingSource)sender).Current)["CrossSection"]) : -1.0;
				this.method_32(dataGridViewComboBoxCell.RowIndex, dataGridViewCell.Value.ToString(), (dataGridViewCell2.Value is int) ? ((int)dataGridViewCell2.Value) : -1, double_);
			}
		}
	}

	private DataTable method_37(int int_7, bool bool_1)
	{
		DataTable dataTable;
		if (this.class255_0.DataTableCollection_0.Contains("dtPermisAmperage_" + this.method_6().ToString() + "_" + int_7.ToString()))
		{
			dataTable = this.class255_0.DataTableCollection_0["dtPermisAmperage_" + this.method_6().ToString() + "_" + int_7.ToString()];
		}
		else
		{
			dataTable = new DataTable("dtPermisAmperage_" + this.method_6().ToString() + "_" + int_7.ToString());
			dataTable.Columns.Add("AmperageValue", typeof(double));
			dataTable.Columns.Add("AmperageType", typeof(string));
			this.class255_0.DataTableCollection_0.Add(dataTable);
		}
		BindingSource bindingSource = new BindingSource();
		bindingSource.DataSource = dataTable;
		((DataGridViewComboBoxCell)this.dataGridView_0.Rows[int_7].Cells["dgvcPermisAmperage"]).DataSource = bindingSource;
		((DataGridViewComboBoxCell)this.dataGridView_0.Rows[int_7].Cells["dgvcPermisAmperage"]).DisplayMember = "AmperageType";
		((DataGridViewComboBoxCell)this.dataGridView_0.Rows[int_7].Cells["dgvcPermisAmperage"]).ValueMember = "AmperageValue";
		return dataTable;
	}

	private DataTable method_38(int int_7, bool bool_1)
	{
		DataTable dataTable;
		if (this.class255_0.DataTableCollection_0.Contains("dtCrossSection_" + this.method_6().ToString() + "_" + int_7.ToString()))
		{
			dataTable = this.class255_0.DataTableCollection_0["dtCrossSection_" + this.method_6().ToString() + "_" + int_7.ToString()];
		}
		else
		{
			dataTable = new DataTable("dtCrossSection_" + this.method_6().ToString() + "_" + int_7.ToString());
			dataTable.Columns.Add("CrossSection", typeof(double));
			this.class255_0.DataTableCollection_0.Add(dataTable);
		}
		BindingSource bindingSource = new BindingSource();
		bindingSource.RaiseListChangedEvents = true;
		bindingSource.CurrentChanged -= this.method_36;
		bindingSource.DataSource = dataTable;
		bindingSource.CurrentChanged += this.method_36;
		bindingSource.RaiseListChangedEvents = false;
		this.method_36(bindingSource, new EventArgs());
		((DataGridViewComboBoxCell)this.dataGridView_0.Rows[int_7].Cells["dgvcCrossSection"]).DataSource = bindingSource;
		((DataGridViewComboBoxCell)this.dataGridView_0.Rows[int_7].Cells["dgvcCrossSection"]).DisplayMember = "CrossSection";
		((DataGridViewComboBoxCell)this.dataGridView_0.Rows[int_7].Cells["dgvcCrossSection"]).ValueMember = "CrossSection";
		return dataTable;
	}

	private DataTable method_39(int int_7, DataTable dataTable_0, int int_8)
	{
		if (((DataGridViewComboBoxCell)this.dataGridView_0.Rows[int_7].Cells["dgvcIdCable"]).DataSource == null)
		{
			dataTable_0 = this.class255_0.DataTableCollection_0["dtCable_" + this.method_6().ToString() + "_" + int_7.ToString()];
			if (dataTable_0 == null)
			{
				dataTable_0 = new DataTable("dtCable_" + this.method_6().ToString() + "_" + int_7.ToString());
				dataTable_0.Columns.Add("Id", typeof(int));
				dataTable_0.Columns.Add("Name", typeof(string));
				this.class255_0.DataTableCollection_0.Add(dataTable_0);
			}
			var enumerable = from row in this.class255_0.vJ_CableByCell.AsEnumerable<Class255.Class422>()
			where row.idCell == int_8 && row["id"] != DBNull.Value
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
			BindingSource bindingSource = new BindingSource();
			bindingSource.DataSource = dataTable_0;
			((DataGridViewComboBoxCell)this.dataGridView_0.Rows[int_7].Cells["dgvcIdCable"]).DataSource = bindingSource;
			((DataGridViewComboBoxCell)this.dataGridView_0.Rows[int_7].Cells["dgvcIdCable"]).DisplayMember = "Name";
			((DataGridViewComboBoxCell)this.dataGridView_0.Rows[int_7].Cells["dgvcIdCable"]).ValueMember = "Id";
		}
		return dataTable_0;
	}

	private void method_40(int int_7, DataTable dataTable_0, string string_2, object object_0, string string_3, object object_1)
	{
		if ((from row in dataTable_0.AsEnumerable()
		where row.Field(string_2) == object_0
		select row).Count<DataRow>() == 0)
		{
			DataRow dataRow = dataTable_0.NewRow();
			dataRow[string_2] = object_0;
			dataRow[string_3] = object_1;
			dataTable_0.Rows.InsertAt(dataRow, 0);
		}
	}

	private void bindingSource_12_CurrentChanged(object sender, EventArgs e)
	{
		this.method_7((this.bindingSource_12.Current == null || !(((DataRowView)this.bindingSource_12.Current)["IdTransf"] is int)) ? -1 : ((int)((DataRowView)this.bindingSource_12.Current)["IdTransf"]));
		this.IdBus = ((this.bindingSource_12.Current == null || !(((DataRowView)this.bindingSource_12.Current)["IdBus"] is int)) ? -1 : ((int)((DataRowView)this.bindingSource_12.Current)["IdBus"]));
		this.string_1 = string.Format("{0}+{1}", this.IdBus, this.method_6());
		if (this.list_0 == null)
		{
			this.list_0 = new List<string>();
		}
		if (!this.list_0.Contains(this.string_1))
		{
			this.list_0.Add(this.string_1);
		}
		if (this.method_6() != -1)
		{
			base.CallSQLTableValuedFunction(this.class255_0, this.class255_0.fn_J_MeasTransfPassport, "", new string[]
			{
				this.method_6().ToString()
			});
			this.label_17.Text = "Заводской № " + this.class255_0.fn_J_MeasTransfPassport.Rows[0]["InvNumber"].ToString();
		}
		DataTable dataTable = base.SelectSqlData("tSchm_ObjList", true, string.Format("WHERE id = {0}", this.IdBus));
		if (dataTable.Rows.Count == 0)
		{
			MessageBox.Show("Не удалось найти шину по низкой стороне.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return;
		}
		if ((bool)dataTable.Rows[0]["Deleted"])
		{
			MessageBox.Show("Шина удалена со схемы.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return;
		}
		EnumerableRowCollection<DataRow> source = base.SelectSqlData("tSchm_ObjList", true, string.Format("WHERE idParent = {0} AND Deleted = ((0)) AND (id = {1} OR Tag = {1})", this.method_0(), this.IdBus)).AsEnumerable();
		string text = string.Join(",", (from r in source
		select r.Field("Id").ToString()).ToArray<string>());
		if (string.IsNullOrEmpty(text))
		{
			MessageBox.Show("Не удалось найти шину по низкой стороне.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return;
		}
		base.SelectSqlData(this.class255_0, this.class255_0.vJ_CellByBus, true, string.Format("WHERE idBus IN ({0}) AND idParent = {1} ORDER BY CONVERT(INT, CASE WHEN Name like '%[^0-9]%' THEN SUBSTRING(Name,1,PATINDEX('%[^0-9]%',Name)-1) ELSE Name END)", text, this.method_0()));
		string text2 = string.Join(",", (from i in this.class255_0.vJ_CellByBus
		select i.id.ToString()).ToArray<string>());
		if (!string.IsNullOrEmpty(text2))
		{
			base.SelectSqlData(this.class255_0, this.class255_0.vJ_TransfByCell, true, string.Format("WHERE idCell IN ({0})", text2));
			if (this.class255_0.vJ_TransfByCell.Count > 0)
			{
				this.class255_0.vJ_CellByBus.method_4(this.class255_0.vJ_CellByBus.Where(new Func<Class255.Class432, bool>(this.method_53)).First<Class255.Class432>());
			}
			base.SelectSqlData(this.class255_0, this.class255_0.vJ_CableByCell, true, string.Format("WHERE idCell IN ({0})", text2));
		}
		this.method_41();
	}

	private void method_41()
	{
		if (this.idictionary_0 == null)
		{
			this.idictionary_0 = new Dictionary<string, Class255.Class331>();
		}
		this.bindingSource_1.EndEdit();
		if (this.idictionary_1 == null)
		{
			this.idictionary_1 = new Dictionary<string, Class255.Class313>();
		}
		this.bindingSource_3.EndEdit();
		if (!this.idictionary_0.ContainsKey(this.string_1))
		{
			Class255.Class331 @class = new Class255.Class331();
			@class.TableName = "tJ_MeasVoltageTransf";
			if (this.method_10() == StateFormCreate.Add)
			{
				Class255.Class437 class2 = @class.method_5();
				class2.idMeasurement = this.method_2();
				class2.idBus = this.IdBus;
				class2.idObjList = this.method_6();
				class2.idSwitchPosition = -1;
				class2["idOldMeasurementTransf"] = DBNull.Value;
				class2.Deleted = false;
				@class.method_0(class2);
			}
			else
			{
				base.SelectSqlData(@class, true, string.Format("WHERE idMeasurement = {0} AND idBus = {1} AND idObjList = {2} AND Deleted = ((0))", this.method_2(), this.IdBus, this.method_6()), null, false, 0);
				if (@class.Rows.Count == 0)
				{
					Class255.Class437 class3 = @class.method_5();
					class3.idMeasurement = this.method_2();
					class3.idBus = this.IdBus;
					class3.idObjList = this.method_6();
					class3.idSwitchPosition = -1;
					class3["idOldMeasurementTransf"] = DBNull.Value;
					class3.Deleted = false;
					@class.method_0(class3);
				}
			}
			this.idictionary_0.Add(new KeyValuePair<string, Class255.Class331>(this.string_1, @class));
		}
		else
		{
			foreach (object obj in this.idictionary_0[this.string_1].Rows)
			{
				((DataRow)obj).EndEdit();
			}
		}
		this.bindingSource_2.DataSource = this.idictionary_0[this.string_1];
		if (!this.idictionary_1.ContainsKey(this.string_1))
		{
			Class255.Class313 class4 = new Class255.Class313();
			this.idictionary_1.Add(new KeyValuePair<string, Class255.Class313>(this.string_1, class4));
			this.bindingSource_3.DataSource = this.idictionary_1[this.string_1];
			this.bindingSource_3.ResetBindings(false);
			int int_ = 0;
			class4.TableName = "tJ_MeasCable";
			if (this.method_10() == StateFormCreate.Add)
			{
				int_ = this.method_42(class4, int_);
				return;
			}
			using (IEnumerator enumerator = base.SelectSqlData(class4.TableName, true, string.Format("WHERE idMeasurement = {0} AND idBus = {1} AND idTransf = {2} AND Deleted = ((0)) AND NOT EXISTS(SELECT * FROM tSchm_ObjList AS ol WHERE ol.id = idCell AND ol.Deleted = 1)", this.method_2(), this.IdBus, this.method_6())).Rows.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					DataRow row = (DataRow)enumerator.Current;
					Class255.Class419 class5 = class4.method_5();
					class5["id"] = row["id"];
					class5["idMeasurement"] = row["idMeasurement"];
					class5["idBus"] = row["idBus"];
					class5["idTransf"] = row["idTransf"];
					class5["idCable"] = row["idCable"];
					class5["idCell"] = row["idCell"];
					class5["NameCell"] = "";
					if (row["idCell"] != DBNull.Value)
					{
						EnumerableRowCollection<string> source = from r in this.class255_0.vJ_CellByBus
						where r.id == (int)row["idCell"]
						select r.Name;
						if (source.Count<string>() > 0)
						{
							class5["NameCell"] = source.First<string>();
						}
					}
					class5["NameCable"] = "";
					if (row["idCable"] != DBNull.Value)
					{
						EnumerableRowCollection<string> source2 = from r in this.class255_0.vJ_CableByCell
						where r.id == (int)row["idCable"]
						select r.Name;
						if (source2.Count<string>() > 0)
						{
							class5["NameCable"] = source2.First<string>();
						}
					}
					class5["OldCell"] = row["OldCell"];
					class5["idSchmAbn"] = row["idSchmAbn"];
					class5["Address"] = row["Address"];
					class5["Company"] = row["Company"];
					class5["Makeup"] = row["Makeup"];
					class5["Voltage"] = row["Voltage"];
					class5["Wires"] = row["Wires"];
					class5["Voltage"] = row["Voltage"];
					class5["CrossSection"] = row["CrossSection"];
					class5["PermisAmperage"] = row["PermisAmperage"];
					class5["Iad"] = row["Iad"];
					class5["Ian"] = row["Ian"];
					class5["Ibd"] = row["Ibd"];
					class5["Ibn"] = row["Ibn"];
					class5["Icd"] = row["Icd"];
					class5["Icn"] = row["Icn"];
					class5["Iod"] = row["Iod"];
					class5["Ion"] = row["Ion"];
					class5["Comment"] = row["Comment"];
					class5["idOldMeasurementCable"] = row["idOldMeasurementCable"];
					class5["Deleted"] = row["Deleted"];
					class4.method_0(class5);
					class5.AcceptChanges();
					class5.SetModified();
				}
			}
			if (class4.Rows.Count == 0)
			{
				int_ = this.method_42(class4, int_);
				return;
			}
		}
		else
		{
			Class255.Class313 class6 = new Class255.Class313();
			foreach (DataRow row3 in this.idictionary_1[this.string_1])
			{
				class6.ImportRow(row3);
			}
			this.idictionary_1[this.string_1].Rows.Clear();
			this.bindingSource_3.DataSource = this.idictionary_1[this.string_1];
			this.bindingSource_3.ResetBindings(false);
			foreach (object obj2 in class6.Rows)
			{
				DataRow row2 = (DataRow)obj2;
				this.idictionary_1[this.string_1].ImportRow(row2);
			}
			foreach (object obj3 in this.idictionary_1[this.string_1].Rows)
			{
				((DataRow)obj3).EndEdit();
			}
			this.bindingSource_3.Sort = string.Format("NameCell ASC, OldCell ASC", new object[0]);
			this.bindingSource_3.ResetBindings(true);
		}
	}

	private int method_42(Class255.Class313 class313_0, int int_7)
	{
		foreach (var <>f__AnonymousType in (from s in (from <>h__TransparentIdentifier1 in (from c in this.class255_0.vJ_CellByBus
		join cab in this.class255_0.vJ_CableByCell on c.id equals cab.idCell into leftCab
		from cab in leftCab.DefaultIfEmpty<Class255.Class422>()
		select new
		{
			<>h__TransparentIdentifier0,
			cab
		}).Where(new Func<<>f__AnonymousType6<<>f__AnonymousType5<Class255.Class432, IEnumerable<Class255.Class422>>, Class255.Class422>, bool>(this.method_54))
		select new
		{
			idBus = ((<>h__TransparentIdentifier1.<>h__TransparentIdentifier0.c["idBus"] != null) ? ((int)<>h__TransparentIdentifier1.<>h__TransparentIdentifier0.c["idBus"]) : -1),
			idCell = ((<>h__TransparentIdentifier1.<>h__TransparentIdentifier0.c["id"] != null) ? ((int)<>h__TransparentIdentifier1.<>h__TransparentIdentifier0.c["id"]) : -1),
			NameCell = ((<>h__TransparentIdentifier1.<>h__TransparentIdentifier0.c["Name"] != null) ? <>h__TransparentIdentifier1.<>h__TransparentIdentifier0.c["Name"].ToString() : ""),
			idCable = ((<>h__TransparentIdentifier1.cab != null) ? ((int)<>h__TransparentIdentifier1.cab["id"]) : -1),
			NameCable = ((<>h__TransparentIdentifier1.cab != null) ? <>h__TransparentIdentifier1.cab["Name"].ToString() : "")
		}).Where(new Func<<>f__AnonymousType7<int, int, string, int, string>, bool>(this.method_55))
		orderby Regex.Match(s.NameCell, "^\\D").Length == 0, Regex.Match(s.NameCell, "\\D*").Value
		select s).ThenBy(delegate(s)
		{
			if (!int.TryParse(Regex.Match(s.NameCell, "\\d+").Value, out int_7))
			{
				return 0;
			}
			return int.Parse(Regex.Match(s.NameCell, "\\d+").Value);
		}))
		{
			this.class255_0.vJ_LastCableInfo.Rows.Clear();
			if (<>f__AnonymousType.idCable != -1)
			{
				base.SelectSqlData(this.class255_0.vJ_LastCableInfo, true, string.Format("WHERE idCable = {0} AND idSubstation = {1} AND idCell = {2} ORDER BY [Year] DESC", <>f__AnonymousType.idCable, this.method_0(), <>f__AnonymousType.idCell), null, false, 1);
			}
			Class255.Class419 @class = class313_0.method_5();
			Class255.Class419 class2 = @class;
			int id;
			if (class313_0.Rows.Count <= 0)
			{
				id = -1;
			}
			else
			{
				id = class313_0.Min((Class255.Class419 r) => r.id) - 1;
			}
			class2.id = id;
			@class.idMeasurement = this.method_2();
			@class.idBus = this.IdBus;
			@class.idTransf = this.method_6();
			@class.idCable = <>f__AnonymousType.idCable;
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
		return int_7;
	}

	private void bindingSource_3_CurrentChanged(object sender, EventArgs e)
	{
		if (this.bindingSource_3.Current != null)
		{
			this.method_20();
		}
	}

	private bool method_43(int int_7)
	{
		string arg = (this.dataGridView_0.Rows[int_7].Cells["dgvcCableMakeup"].Value is string) ? this.dataGridView_0.Rows[int_7].Cells["dgvcCableMakeup"].Value.ToString() : "";
		int num = (this.dataGridView_0.Rows[int_7].Cells["dgvcWires"].Value is int) ? ((int)this.dataGridView_0.Rows[int_7].Cells["dgvcWires"].Value) : 0;
		double num2 = (this.dataGridView_0.Rows[int_7].Cells["dgvcCrossSection"].Value is double) ? ((double)this.dataGridView_0.Rows[int_7].Cells["dgvcCrossSection"].Value) : 0.0;
		return base.SelectSqlData("tR_Cable", true, string.Format("WHERE CableMakeup = '{0}' AND Wires = {1} AND CrossSection = {2} AND Deleted = ((0))", arg, num, num2.ToString().Replace(',', '.'))).Rows.Count > 0;
	}

	private void toolStripButton_0_Click(object sender, EventArgs e)
	{
		try
		{
			if (this.dataGridView_0.Rows.Count > 0 && this.dataGridView_0.SelectedRows[0].Cells["dgvcIdCell"].Value != null && this.dataGridView_0.SelectedRows[0].Cells["dgvcIdCell"].Value is int)
			{
				int num = (int)this.dataGridView_0.SelectedRows[0].Cells["dgvcIdCell"].Value;
				object obj = base.CallSQLScalarFunction("dbo.fn_GetIdBusByCell", new string[]
				{
					num.ToString()
				});
				int num2 = (obj != null) ? ((int)obj) : -1;
				ShowFormEventArgs showFormEventArgs = new ShowFormEventArgs();
				showFormEventArgs.TypeForm = "Scheme.Forms.LinkSchmAbn.FormLinkSchmAbnAdd, Scheme";
				showFormEventArgs.FormMode = eFormMode.Mdi;
				showFormEventArgs.Param = new object[4];
				showFormEventArgs.Param[0] = this.int_6;
				showFormEventArgs.Param[1] = this.method_0();
				showFormEventArgs.Param[2] = num2;
				showFormEventArgs.Param[3] = num;
				showFormEventArgs.SQLSettings = this.SqlSettings;
				this.OnShowForm(showFormEventArgs).FormClosed += this.method_44;
			}
			else
			{
				MessageBox.Show("Не выбран, либо отсутствует выключатель!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.ToString(), ex.Message);
		}
	}

	private void method_44(object sender, FormClosedEventArgs e)
	{
		this.method_20();
	}

	private void toolStripButton_3_Click(object sender, EventArgs e)
	{
		this.method_20();
	}

	private void dataGridView_1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
	{
		if (e.RowIndex >= 0 && (this.dataGridView_1[this.dataGridViewTextBoxColumn_18.Name, e.RowIndex].Value == DBNull.Value || Convert.ToInt32(this.dataGridView_1[this.dataGridViewTextBoxColumn_18.Name, e.RowIndex].Value) != 1191))
		{
			e.CellStyle.BackColor = Color.LightGray;
		}
	}

	private void toolStripButton_2_Click(object sender, EventArgs e)
	{
		if (this.dataGridView_1.Rows.Count != 0 && this.dataGridView_1.SelectedRows[0].Cells["idSchmObjDataGridViewTextBoxColumn"].Value is int)
		{
			List<string> list = new List<string>();
			if (MessageBox.Show("Вы действительно хотите удалить выделенные записи?", "Удаление.", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
			{
				string text = "";
				foreach (object obj in this.dataGridView_1.SelectedRows)
				{
					DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
					if (dataGridViewRow.Cells["dgvcIds"].Value != DBNull.Value && dataGridViewRow.Cells["dgvcIds"].Value.ToString().Length > 0)
					{
						if (dataGridViewRow.Cells["typeDocDgvColumn"].Value != DBNull.Value && (int)dataGridViewRow.Cells["typeDocDgvColumn"].Value == 1191)
						{
							text = text + ((text != "") ? "," : "") + dataGridViewRow.Cells["dgvcIds"].Value.ToString();
						}
						else
						{
							list.Add(dataGridViewRow.Cells["dgvcIds"].Value.ToString());
						}
					}
				}
				if (!string.IsNullOrEmpty(text))
				{
					base.DeleteSqlDataWhere(this.class255_0.tL_SchmAbn, string.Format("WHERE id IN ({0})", text));
				}
				this.method_21(list);
			}
			return;
		}
		MessageBox.Show("Не выбран адрес.", "Внимание.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
	}

	private void method_45(object sender, FormClosedEventArgs e)
	{
		this.method_20();
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		if (!this.method_47())
		{
			return;
		}
		if (this.method_46())
		{
			MessageBox.Show("Данные успешно сохранены.", "Сохранение.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			base.DialogResult = DialogResult.OK;
		}
		else
		{
			base.DialogResult = DialogResult.Cancel;
		}
		base.Close();
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		base.Close();
	}

	private bool method_46()
	{
		if (this.method_10() == StateFormCreate.Add)
		{
			foreach (Class255.Class410 @class in this.class255_0.tJ_Measurement)
			{
				@class.EndEdit();
			}
			this.method_3(base.InsertSqlDataOneRow(this.class255_0, this.class255_0.tJ_Measurement));
			if (this.method_2() != -1)
			{
				using (List<string>.Enumerator enumerator2 = this.list_0.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						string key = enumerator2.Current;
						if (Class125.smethod_0(this.idictionary_0[key]) || Class125.smethod_0(this.idictionary_1[key]) || this.method_10() == StateFormCreate.Edit)
						{
							foreach (Class255.Class437 class2 in this.idictionary_0[key])
							{
								class2.idMeasurement = this.method_2();
								class2.EndEdit();
							}
							base.InsertSqlData(this.idictionary_0[key]);
							base.UpdateSqlData(this.idictionary_0[key]);
							base.DeleteSqlData(this.idictionary_0[key]);
							foreach (Class255.Class419 class3 in this.idictionary_1[key])
							{
								class3.idMeasurement = this.method_2();
								class3.EndEdit();
							}
							this.idictionary_1[key].Columns.Remove("NameCell");
							this.idictionary_1[key].Columns.Remove("NameCable");
							base.InsertSqlData(this.idictionary_1[key]);
							base.UpdateSqlData(this.idictionary_1[key]);
							base.DeleteSqlData(this.idictionary_1[key]);
						}
					}
					return true;
				}
			}
			return false;
		}
		foreach (object obj in this.class255_0.tJ_Measurement.Rows)
		{
			((DataRow)obj).EndEdit();
		}
		base.UpdateSqlData(this.class255_0, this.class255_0.tJ_Measurement);
		foreach (string key2 in this.list_0)
		{
			if (this.idictionary_0.ContainsKey(key2))
			{
				foreach (object obj2 in this.idictionary_0[key2].Rows)
				{
					((DataRow)obj2).EndEdit();
				}
				base.UpdateSqlData(this.idictionary_0[key2]);
				base.InsertSqlData(this.idictionary_0[key2]);
				foreach (object obj3 in this.idictionary_1[key2].Rows)
				{
					((DataRow)obj3).EndEdit();
				}
				this.idictionary_1[key2].Columns.Remove("NameCell");
				this.idictionary_1[key2].Columns.Remove("NameCable");
				base.UpdateSqlData(this.idictionary_1[key2]);
				base.InsertSqlData(this.idictionary_1[key2]);
				base.DeleteSqlData(this.idictionary_1[key2]);
			}
		}
		return true;
	}

	private bool method_47()
	{
		if (this.comboBox_3.SelectedValue == null || (!(this.comboBox_3.SelectedValue is int) && int.Parse(this.comboBox_3.SelectedValue.ToString()) < 1900))
		{
			MessageBox.Show("Поле \"Период\" не заполнено.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return false;
		}
		if (this.numericUpDown_1.Value == 0m)
		{
			this.class255_0.tJ_Measurement.First<Class255.Class410>().TemperatureD = 0;
			this.class255_0.tJ_Measurement.First<Class255.Class410>().EndEdit();
		}
		if (this.numericUpDown_0.Value == 0m)
		{
			this.class255_0.tJ_Measurement.First<Class255.Class410>().TemperatureN = 0;
			this.class255_0.tJ_Measurement.First<Class255.Class410>().EndEdit();
		}
		if (this.nullableDateTimePicker_1.Value == null)
		{
			MessageBox.Show("Поле \"День\" не заполнено.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return false;
		}
		if (this.nullableDateTimePicker_0.Value == null)
		{
			MessageBox.Show("Поле \"Вечер\" не заполнено.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return false;
		}
		if (this.comboBox_0.SelectedValue == null || !(this.comboBox_0.SelectedValue is int) || int.Parse(this.comboBox_0.SelectedValue.ToString()) < 1)
		{
			MessageBox.Show("Поле \"Замеры проводил\" не заполнено.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return false;
		}
		if (this.bindingSource_12.Current == null)
		{
			MessageBox.Show("Поле \"Секция шин\" не заполнено.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return false;
		}
		return true;
	}

	private void comboBox_3_SelectedValueChanged(object sender, EventArgs e)
	{
		if (this.comboBox_3.SelectedValue != null && this.comboBox_3.SelectedValue is int)
		{
			this.Year = (int)this.comboBox_3.SelectedValue;
		}
	}

	private void toolStripMenuItem_1_Click(object sender, EventArgs e)
	{
		if (MessageBox.Show("Вы действительно хотите удалить наименование объекта?", "Удаление.", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
		{
			this.dataGridView_0.SelectedRows[0].Cells["Company"].Value = "";
		}
	}

	private void toolStripMenuItem_0_Click(object sender, EventArgs e)
	{
		if (MessageBox.Show("Вы действительно хотите удалить адрес объекта?", "Удаление.", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
		{
			this.dataGridView_0.SelectedRows[0].Cells["Address"].Value = "";
		}
	}

	private void toolStripMenuItem_2_Click(object sender, EventArgs e)
	{
		if (MessageBox.Show("Вы действительно хотите удалить строку?", "Удаление.", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
		{
			foreach (object obj in this.dataGridView_0.SelectedRows)
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
				this.dataGridView_0.Rows.Remove(dataGridViewRow);
			}
			MessageBox.Show("Строка успешно удалена.");
		}
	}

	private void EkOojOiomxm(object sender, EventArgs e)
	{
		EnumerableRowCollection<Class255.Class419> source = from r in this.idictionary_1[this.string_1]
		where r.RowState != DataRowState.Deleted && r.id < 0
		select r;
		Form40 form = new Form40();
		form.SqlSettings = this.SqlSettings;
		form.IdBus = this.IdBus;
		form.method_1(this.method_2());
		form.method_3(this.method_0());
		form.method_5(this.method_6());
		form.method_7(this.string_1);
		int num;
		if (source.Count<Class255.Class419>() <= 0)
		{
			num = -1;
		}
		else
		{
			num = source.Min((Class255.Class419 r) => r.id) - 1;
		}
		form.method_11(num);
		form.TypeDoc = (FormMeasurement.TypeDoc)this.int_6;
		form.FormClosed += this.method_48;
		form.MdiParent = base.MdiParent;
		form.Show();
	}

	private void method_48(object sender, FormClosedEventArgs e)
	{
		Form40 form = (Form40)sender;
		Class255.Class419[] rows = form.Rows;
		form.method_8().Except(this.class255_0.vJ_CableByCell).ToList<Class255.Class422>().ForEach(new Action<Class255.Class422>(this.method_56));
		foreach (Class255.Class419 row in form.Rows)
		{
			this.idictionary_1[form.method_6()].ImportRow(row);
		}
		this.bindingSource_3.ResetBindings(false);
		for (int j = 0; j < this.dataGridView_0.Rows.Count; j++)
		{
			for (int k = 0; k < this.dataGridView_0.Columns.Count; k++)
			{
				if (this.dataGridView_0.Rows[j].Cells[k] is DataGridViewComboBoxCell && this.dataGridView_0.Rows[j].Cells[k].Visible)
				{
					string name = this.dataGridView_0.Columns[k].Name;
					if (k == this.dataGridView_0.Rows[j].Cells["dgvcIdCable"].ColumnIndex && this.dataGridView_0.Rows[j].Cells["dgvcIdCell"].Value is int)
					{
						int int_ = (int)this.dataGridView_0.Rows[j].Cells[k].Value;
						this.method_39(j, new DataTable(), int_);
					}
					DataGridViewComboBoxCell currentCell = (DataGridViewComboBoxCell)this.dataGridView_0.Rows[j].Cells[k];
					this.dataGridView_0.CurrentCell = currentCell;
					this.dataGridView_0.BeginEdit(false);
					this.dataGridView_0.EndEdit();
					this.dataGridView_0.CurrentCell = null;
				}
			}
		}
	}

	private void toolStripButton_4_Click(object sender, EventArgs e)
	{
		FormCable formCable = new FormCable();
		formCable.SqlSettings = this.SqlSettings;
		formCable.FormClosed += this.method_49;
		formCable.MdiParent = base.MdiParent;
		formCable.Show();
	}

	private void method_49(object sender, FormClosedEventArgs e)
	{
		CloseReason closeReason = e.CloseReason;
	}

	private void dataGridView_0_MouseClick(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Right)
		{
			int rowIndex = this.dataGridView_0.HitTest(e.X, e.Y).RowIndex;
			if (rowIndex >= 0)
			{
				this.dataGridView_0.Rows[rowIndex].Selected = true;
				ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
				ToolStripButton toolStripButton = new ToolStripButton("Удалить адрес объекта");
				toolStripButton.Click += this.toolStripMenuItem_0_Click;
				contextMenuStrip.Items.Add(toolStripButton);
				ToolStripButton toolStripButton2 = new ToolStripButton("Удалить наименование объекта");
				toolStripButton2.Click += this.toolStripMenuItem_1_Click;
				contextMenuStrip.Items.Add(toolStripButton2);
				contextMenuStrip.Items.Add(new ToolStripSeparator());
				ToolStripButton toolStripButton3 = new ToolStripButton("Удалить строку");
				toolStripButton3.Click += this.toolStripMenuItem_2_Click;
				contextMenuStrip.Items.Add(toolStripButton3);
				if (this.dataGridView_0.Rows[rowIndex].DefaultCellStyle.BackColor == Color.Yellow)
				{
					contextMenuStrip.Items.Add(new ToolStripSeparator());
					ToolStripButton toolStripButton4 = new ToolStripButton("Справочник кабелей");
					contextMenuStrip.Items.Add(toolStripButton4);
					toolStripButton4.Click += this.toolStripButton_4_Click;
				}
				contextMenuStrip.Show(this.dataGridView_0, e.Location);
			}
		}
	}

	private void dataGridView_0_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
	{
		this.method_19(e.RowIndex);
	}

	private void dataGridView_0_CellEndEdit(object sender, DataGridViewCellEventArgs e)
	{
		if (this.dataGridView_0.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Length == 0)
		{
			this.dataGridView_0.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = DBNull.Value;
		}
		if (this.dataGridView_0.Rows[e.RowIndex].Cells[e.ColumnIndex].Value is int && (int)this.dataGridView_0.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == -1)
		{
			this.dataGridView_0.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = DBNull.Value;
		}
	}

	private void ydXojhEhNhr(object sender, EventArgs e)
	{
		if (this.dataGridView_0.SelectedRows != null)
		{
			int count = this.dataGridView_0.SelectedRows.Count;
		}
	}

	private void cHkojevBpau(object sender, DataGridViewDataErrorEventArgs e)
	{
		int int_ = (this.dataGridView_0.Rows[e.RowIndex].Cells["dgvcIdCell"].Value is int) ? ((int)this.dataGridView_0.Rows[e.RowIndex].Cells["dgvcIdCell"].Value) : 0;
		string text = (this.dataGridView_0.Columns[e.ColumnIndex].DataPropertyName == "idCable") ? "Cable" : this.dataGridView_0.Columns[e.ColumnIndex].DataPropertyName;
		string name = string.Concat(new string[]
		{
			"dt",
			text,
			"_",
			this.method_6().ToString(),
			"_",
			e.RowIndex.ToString()
		});
		string string_ = (this.dataGridView_0.Rows[e.RowIndex].Cells["dgvcCableMakeup"].Value is string) ? this.dataGridView_0.Rows[e.RowIndex].Cells["dgvcCableMakeup"].Value.ToString() : "";
		int int_2 = (this.dataGridView_0.Rows[e.RowIndex].Cells["dgvcWires"].Value is int) ? ((int)this.dataGridView_0.Rows[e.RowIndex].Cells["dgvcWires"].Value) : 0;
		double double_ = (this.dataGridView_0.Rows[e.RowIndex].Cells["dgvcCrossSection"].Value is double) ? ((double)this.dataGridView_0.Rows[e.RowIndex].Cells["dgvcCrossSection"].Value) : 0.0;
		if (this.dataGridView_0.Rows[e.RowIndex].Cells["dgvcPermisAmperage"].Value is double)
		{
			double num = (double)this.dataGridView_0.Rows[e.RowIndex].Cells["dgvcPermisAmperage"].Value;
		}
		if (this.class255_0.DataTableCollection_0.Contains(name))
		{
			string dataPropertyName = this.dataGridView_0.Columns[e.ColumnIndex].DataPropertyName;
			if (dataPropertyName == "cable")
			{
				this.method_39(e.RowIndex, new DataTable(), int_);
				return;
			}
			if (dataPropertyName == "makeup")
			{
				this.method_23(e.RowIndex, string_);
				return;
			}
			if (dataPropertyName == "Wires")
			{
				this.method_26(e.RowIndex, string_);
				return;
			}
			if (dataPropertyName == "CrossSection")
			{
				this.method_29(e.RowIndex, string_, int_2);
				return;
			}
			if (!(dataPropertyName == "PermisAmperage"))
			{
				return;
			}
			this.method_32(e.RowIndex, string_, int_2, double_);
		}
	}

	private void dataGridView_0_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
	{
	}

	private void AgcojwYvpTS(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '.')
		{
			Point currentCellAddress = this.dataGridView_0.CurrentCellAddress;
			Point currentCellAddress2 = this.dataGridView_0.CurrentCellAddress;
			if (this.dataGridView_0.Columns[currentCellAddress2.X].Name == "dgvcIdCell")
			{
				this.dataGridView_0.Rows[currentCellAddress2.Y].Cells[currentCellAddress2.X].Value = -1;
			}
		}
	}

	private void dataGridView_0_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
	{
		this.method_50(e.ColumnIndex);
	}

	private void method_50(int int_7)
	{
		DataGridViewColumn dataGridViewColumn = this.dataGridView_0.Columns[int_7];
		this.bool_0 = (this.dataGridViewColumn_0 == null || !this.bool_0);
		ListSortDirection direction = this.bool_0 ? ListSortDirection.Ascending : ListSortDirection.Descending;
		string text = (dataGridViewColumn.Name == "dgvcIdCell") ? "dgvcNameCell" : dataGridViewColumn.Name;
		string columnName = (dataGridViewColumn.Name == "dgvcIdCable") ? "dgvcNameCable" : dataGridViewColumn.Name;
		this.dataGridView_0.Sort(this.dataGridView_0.Columns[columnName], direction);
		this.bindingSource_3.ResetBindings(true);
		if (this.dataGridViewColumn_0 != null)
		{
			this.dataGridViewColumn_0.HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.None;
		}
		dataGridViewColumn.HeaderCell.SortGlyphDirection = (this.bool_0 ? System.Windows.Forms.SortOrder.Ascending : System.Windows.Forms.SortOrder.Descending);
		this.dataGridViewColumn_0 = dataGridViewColumn;
	}

	private void dataGridView_0_Sorted(object sender, EventArgs e)
	{
	}

	private void bindingSource_7_CurrentChanged(object sender, EventArgs e)
	{
		Point currentCellAddress = this.dataGridView_0.CurrentCellAddress;
		if (currentCellAddress.X != -1 && currentCellAddress.Y != -1)
		{
			DataGridViewComboBoxCell dataGridViewComboBoxCell = (DataGridViewComboBoxCell)this.dataGridView_0.Rows[currentCellAddress.Y].Cells["dgvcIdCable"];
			if (this.bindingSource_7.Current != null)
			{
				EnumerableRowCollection<Class255.Class422> source = this.class255_0.vJ_CableByCell.Where(new Func<Class255.Class422, bool>(this.method_57));
				dataGridViewComboBoxCell.Value = ((source.Count<Class255.Class422>() > 0) ? ((source.First<Class255.Class422>()["id"] == DBNull.Value) ? -1 : source.First<Class255.Class422>().id) : -1);
			}
		}
	}

	private void toolStripButton_5_Click(object sender, EventArgs e)
	{
		if (this.nullableDateTimePicker_1.Value == null && this.nullableDateTimePicker_0.Value == null)
		{
			MessageBox.Show("Не указана дата");
			return;
		}
		DataSet dataSet = new DataSet();
		DataTable dataTable = new DataTable("tj_temperature");
		dataTable.Columns.Add("NightDown", typeof(int));
		dataTable.Columns.Add("DayDown", typeof(int));
		dataSet.Tables.Add(dataTable);
		if (this.nullableDateTimePicker_1.Value != null)
		{
			base.SelectSqlData(dataTable, true, "where dateTemp = '" + Convert.ToDateTime(this.nullableDateTimePicker_1.Value).ToString("yyyyMMdd") + "'", null, false, 0);
			if (dataTable.Rows.Count > 0 && dataTable.Rows[0]["DayDown"] != DBNull.Value)
			{
				this.numericUpDown_1.Value = Convert.ToInt32(dataTable.Rows[0]["DayDown"]);
			}
		}
		if (this.nullableDateTimePicker_0.Value != null)
		{
			base.SelectSqlData(dataTable, true, "where dateTemp = '" + Convert.ToDateTime(this.nullableDateTimePicker_0.Value).ToString("yyyyMMdd") + "'", null, false, 0);
			if (dataTable.Rows.Count > 0 && dataTable.Rows[0]["NightDown"] != DBNull.Value)
			{
				this.numericUpDown_0.Value = Convert.ToInt32(dataTable.Rows[0]["NightDown"]);
			}
		}
	}

	private void method_51()
	{
		this.icontainer_0 = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form39));
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
		DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
		this.tableLayoutPanel_0 = new TableLayoutPanel();
		this.toolStrip_1 = new ToolStrip();
		this.uLioUhyvJfQ = new ToolStripButton();
		this.toolStripSeparator_2 = new ToolStripSeparator();
		this.toolStripSplitButton_0 = new ToolStripSplitButton();
		this.toolStripMenuItem_0 = new ToolStripMenuItem();
		this.toolStripMenuItem_1 = new ToolStripMenuItem();
		this.toolStripSeparator_1 = new ToolStripSeparator();
		this.toolStripMenuItem_2 = new ToolStripMenuItem();
		this.toolStripSeparator_3 = new ToolStripSeparator();
		this.toolStripButton_4 = new ToolStripButton();
		this.label_17 = new Label();
		this.label_15 = new Label();
		this.dataGridView_1 = new DataGridView();
		this.dataGridViewTextBoxColumn_16 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_17 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_18 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_19 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_20 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_21 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_22 = new DataGridViewTextBoxColumn();
		this.bindingSource_11 = new BindingSource(this.icontainer_0);
		this.class255_0 = new Class255();
		this.dataGridView_0 = new DataGridView();
		this.dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
		this.dataGridViewComboBoxColumn_0 = new DataGridViewComboBoxColumn();
		this.bindingSource_7 = new BindingSource(this.icontainer_0);
		this.dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_3 = new DataGridViewTextBoxColumn();
		this.dataGridViewComboBoxColumn_1 = new DataGridViewComboBoxColumn();
		this.HvHoUgxkjqO = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_4 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_5 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_6 = new DataGridViewTextBoxColumn();
		this.dataGridViewComboBoxColumn_2 = new DataGridViewComboBoxColumn();
		this.dataGridViewComboBoxColumn_3 = new DataGridViewComboBoxColumn();
		this.dataGridViewComboBoxColumn_4 = new DataGridViewComboBoxColumn();
		this.dataGridViewComboBoxColumn_5 = new DataGridViewComboBoxColumn();
		this.dataGridViewComboBoxColumn_6 = new DataGridViewComboBoxColumn();
		this.dataGridViewTextBoxColumn_7 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_8 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_9 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_10 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_11 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_12 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_13 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_14 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_15 = new DataGridViewTextBoxColumn();
		this.dataGridViewCheckBoxColumn_0 = new DataGridViewCheckBoxColumn();
		this.bindingSource_3 = new BindingSource(this.icontainer_0);
		this.comboBox_1 = new ComboBox();
		this.bindingSource_12 = new BindingSource(this.icontainer_0);
		this.label_6 = new Label();
		this.groupBox_0 = new GroupBox();
		this.toolStrip_2 = new ToolStrip();
		this.toolStripButton_5 = new ToolStripButton();
		this.label_16 = new Label();
		this.comboBox_3 = new ComboBox();
		this.bindingSource_1 = new BindingSource(this.icontainer_0);
		this.nullableDateTimePicker_0 = new NullableDateTimePicker();
		this.nullableDateTimePicker_1 = new NullableDateTimePicker();
		this.comboBox_0 = new ComboBox();
		this.bindingSource_0 = new BindingSource(this.icontainer_0);
		this.numericUpDown_0 = new NumericUpDown();
		this.numericUpDown_1 = new NumericUpDown();
		this.label_0 = new Label();
		this.label_1 = new Label();
		this.label_2 = new Label();
		this.label_3 = new Label();
		this.label_4 = new Label();
		this.label_5 = new Label();
		this.panel_0 = new Panel();
		this.label_13 = new Label();
		this.label_14 = new Label();
		this.label_7 = new Label();
		this.label_8 = new Label();
		this.label_9 = new Label();
		this.label_10 = new Label();
		this.label_11 = new Label();
		this.label_12 = new Label();
		this.textBox_0 = new TextBox();
		this.bindingSource_2 = new BindingSource(this.icontainer_0);
		this.textBox_1 = new TextBox();
		this.textBox_2 = new TextBox();
		this.textBox_3 = new TextBox();
		this.textBox_4 = new TextBox();
		this.textBox_5 = new TextBox();
		this.textBox_6 = new TextBox();
		this.textBox_7 = new TextBox();
		this.textBox_8 = new TextBox();
		this.textBox_9 = new TextBox();
		this.textBox_10 = new TextBox();
		this.textBox_11 = new TextBox();
		this.toolStrip_0 = new ToolStrip();
		this.toolStripButton_0 = new ToolStripButton();
		this.toolStripButton_1 = new ToolStripButton();
		this.toolStripButton_2 = new ToolStripButton();
		this.toolStripSeparator_0 = new ToolStripSeparator();
		this.toolStripButton_3 = new ToolStripButton();
		this.comboBox_2 = new ComboBox();
		this.bindingSource_13 = new BindingSource(this.icontainer_0);
		this.tableLayoutPanel_1 = new TableLayoutPanel();
		this.button_0 = new Button();
		this.button_1 = new Button();
		this.bindingSource_8 = new BindingSource(this.icontainer_0);
		this.bindingSource_9 = new BindingSource(this.icontainer_0);
		this.bindingSource_15 = new BindingSource(this.icontainer_0);
		this.bindingSource_10 = new BindingSource(this.icontainer_0);
		this.bindingSource_14 = new BindingSource(this.icontainer_0);
		this.bindingSource_4 = new BindingSource(this.icontainer_0);
		this.bindingSource_5 = new BindingSource(this.icontainer_0);
		this.bindingSource_6 = new BindingSource(this.icontainer_0);
		this.tableLayoutPanel_0.SuspendLayout();
		this.toolStrip_1.SuspendLayout();
		((ISupportInitialize)this.dataGridView_1).BeginInit();
		((ISupportInitialize)this.bindingSource_11).BeginInit();
		((ISupportInitialize)this.class255_0).BeginInit();
		((ISupportInitialize)this.dataGridView_0).BeginInit();
		((ISupportInitialize)this.bindingSource_7).BeginInit();
		((ISupportInitialize)this.bindingSource_3).BeginInit();
		((ISupportInitialize)this.bindingSource_12).BeginInit();
		this.groupBox_0.SuspendLayout();
		this.toolStrip_2.SuspendLayout();
		((ISupportInitialize)this.bindingSource_1).BeginInit();
		((ISupportInitialize)this.bindingSource_0).BeginInit();
		((ISupportInitialize)this.numericUpDown_0).BeginInit();
		((ISupportInitialize)this.numericUpDown_1).BeginInit();
		this.panel_0.SuspendLayout();
		((ISupportInitialize)this.bindingSource_2).BeginInit();
		this.toolStrip_0.SuspendLayout();
		((ISupportInitialize)this.bindingSource_13).BeginInit();
		this.tableLayoutPanel_1.SuspendLayout();
		((ISupportInitialize)this.bindingSource_8).BeginInit();
		((ISupportInitialize)this.bindingSource_9).BeginInit();
		((ISupportInitialize)this.bindingSource_15).BeginInit();
		((ISupportInitialize)this.bindingSource_10).BeginInit();
		((ISupportInitialize)this.bindingSource_14).BeginInit();
		((ISupportInitialize)this.bindingSource_4).BeginInit();
		((ISupportInitialize)this.bindingSource_5).BeginInit();
		((ISupportInitialize)this.bindingSource_6).BeginInit();
		base.SuspendLayout();
		this.tableLayoutPanel_0.ColumnCount = 6;
		this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 141f));
		this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 101f));
		this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 8f));
		this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 175f));
		this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 164f));
		this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		this.tableLayoutPanel_0.Controls.Add(this.toolStrip_1, 0, 3);
		this.tableLayoutPanel_0.Controls.Add(this.label_17, 3, 1);
		this.tableLayoutPanel_0.Controls.Add(this.label_15, 4, 1);
		this.tableLayoutPanel_0.Controls.Add(this.dataGridView_1, 0, 6);
		this.tableLayoutPanel_0.Controls.Add(this.dataGridView_0, 0, 4);
		this.tableLayoutPanel_0.Controls.Add(this.comboBox_1, 1, 1);
		this.tableLayoutPanel_0.Controls.Add(this.label_6, 0, 1);
		this.tableLayoutPanel_0.Controls.Add(this.groupBox_0, 0, 0);
		this.tableLayoutPanel_0.Controls.Add(this.panel_0, 0, 2);
		this.tableLayoutPanel_0.Controls.Add(this.toolStrip_0, 0, 5);
		this.tableLayoutPanel_0.Controls.Add(this.comboBox_2, 5, 1);
		this.tableLayoutPanel_0.Controls.Add(this.tableLayoutPanel_1, 0, 7);
		this.tableLayoutPanel_0.Dock = DockStyle.Fill;
		this.tableLayoutPanel_0.Location = new Point(0, 0);
		this.tableLayoutPanel_0.Name = "tableLayoutPanel1";
		this.tableLayoutPanel_0.RowCount = 8;
		this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Absolute, 79f));
		this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Absolute, 21f));
		this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Absolute, 67f));
		this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Absolute, 24f));
		this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Absolute, 24f));
		this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Absolute, 134f));
		this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Absolute, 39f));
		this.tableLayoutPanel_0.Size = new Size(698, 562);
		this.tableLayoutPanel_0.TabIndex = 0;
		this.tableLayoutPanel_0.SetColumnSpan(this.toolStrip_1, 12);
		this.toolStrip_1.Dock = DockStyle.Fill;
		this.toolStrip_1.Items.AddRange(new ToolStripItem[]
		{
			this.uLioUhyvJfQ,
			this.toolStripSeparator_2,
			this.toolStripSplitButton_0,
			this.toolStripSeparator_3,
			this.toolStripButton_4
		});
		this.toolStrip_1.Location = new Point(0, 167);
		this.toolStrip_1.Name = "tsCells";
		this.toolStrip_1.Size = new Size(698, 24);
		this.toolStrip_1.TabIndex = 7;
		this.toolStrip_1.Text = "toolStrip1";
		this.uLioUhyvJfQ.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.uLioUhyvJfQ.Image = (Image)componentResourceManager.GetObject("tssbAddMissingCells.Image");
		this.uLioUhyvJfQ.ImageTransparentColor = Color.Magenta;
		this.uLioUhyvJfQ.Name = "tssbAddMissingCells";
		this.uLioUhyvJfQ.Size = new Size(23, 21);
		this.uLioUhyvJfQ.Text = "Добавление недостающих кабельных линий";
		this.uLioUhyvJfQ.Click += this.EkOojOiomxm;
		this.toolStripSeparator_2.Name = "toolStripSeparator3";
		this.toolStripSeparator_2.Size = new Size(6, 24);
		this.toolStripSplitButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripSplitButton_0.DropDownItems.AddRange(new ToolStripItem[]
		{
			this.toolStripMenuItem_0,
			this.toolStripMenuItem_1,
			this.toolStripSeparator_1,
			this.toolStripMenuItem_2
		});
		this.toolStripSplitButton_0.Image = (Image)componentResourceManager.GetObject("toolStripSplitButton1.Image");
		this.toolStripSplitButton_0.ImageTransparentColor = Color.Magenta;
		this.toolStripSplitButton_0.Name = "toolStripSplitButton1";
		this.toolStripSplitButton_0.Size = new Size(32, 21);
		this.toolStripMenuItem_0.Name = "tsmiMeasCableDelAddress";
		this.toolStripMenuItem_0.Size = new Size(249, 22);
		this.toolStripMenuItem_0.Text = "Удалить адрес объекта";
		this.toolStripMenuItem_0.Click += this.toolStripMenuItem_0_Click;
		this.toolStripMenuItem_1.Name = "tsmiMeasCableDelCompany";
		this.toolStripMenuItem_1.Size = new Size(249, 22);
		this.toolStripMenuItem_1.Text = "Удалить наименование объекта";
		this.toolStripMenuItem_1.Click += this.toolStripMenuItem_1_Click;
		this.toolStripSeparator_1.Name = "toolStripSeparator2";
		this.toolStripSeparator_1.Size = new Size(246, 6);
		this.toolStripMenuItem_2.Name = "tsmiMeasCableDelRow";
		this.toolStripMenuItem_2.Size = new Size(249, 22);
		this.toolStripMenuItem_2.Text = "Удалить строку";
		this.toolStripMenuItem_2.Click += this.toolStripMenuItem_2_Click;
		this.toolStripSeparator_3.Name = "tssCableReference";
		this.toolStripSeparator_3.Size = new Size(6, 24);
		this.toolStripButton_4.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_4.Image = (Image)componentResourceManager.GetObject("tsbCableReference.Image");
		this.toolStripButton_4.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_4.Name = "tsbCableReference";
		this.toolStripButton_4.Size = new Size(23, 21);
		this.toolStripButton_4.Text = "Cправочник кабеля";
		this.toolStripButton_4.Click += this.toolStripButton_4_Click;
		this.label_17.AutoSize = true;
		this.label_17.BorderStyle = BorderStyle.FixedSingle;
		this.label_17.Dock = DockStyle.Left;
		this.label_17.Location = new Point(253, 79);
		this.label_17.Name = "lbSerialNumber";
		this.label_17.Size = new Size(81, 21);
		this.label_17.TabIndex = 3;
		this.label_17.Text = "Заводской № ";
		this.label_17.TextAlign = ContentAlignment.MiddleLeft;
		this.label_15.BorderStyle = BorderStyle.FixedSingle;
		this.label_15.Dock = DockStyle.Fill;
		this.label_15.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.label_15.Location = new Point(428, 79);
		this.label_15.Name = "label8";
		this.label_15.Size = new Size(158, 21);
		this.label_15.TabIndex = 4;
		this.label_15.Text = "Положение перекл. напр.";
		this.label_15.TextAlign = ContentAlignment.TopRight;
		this.dataGridView_1.AllowUserToAddRows = false;
		this.dataGridView_1.AllowUserToDeleteRows = false;
		this.dataGridView_1.AllowUserToOrderColumns = true;
		this.dataGridView_1.AllowUserToResizeRows = false;
		this.dataGridView_1.AutoGenerateColumns = false;
		this.dataGridView_1.BackgroundColor = Color.White;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle.BackColor = SystemColors.Control;
		dataGridViewCellStyle.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		this.dataGridView_1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		this.dataGridView_1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView_1.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewTextBoxColumn_16,
			this.dataGridViewTextBoxColumn_17,
			this.dataGridViewTextBoxColumn_18,
			this.dataGridViewTextBoxColumn_19,
			this.dataGridViewTextBoxColumn_20,
			this.dataGridViewTextBoxColumn_21,
			this.dataGridViewTextBoxColumn_22
		});
		this.tableLayoutPanel_0.SetColumnSpan(this.dataGridView_1, 6);
		this.dataGridView_1.DataSource = this.bindingSource_11;
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = Color.White;
		dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
		this.dataGridView_1.DefaultCellStyle = dataGridViewCellStyle2;
		this.dataGridView_1.Dock = DockStyle.Fill;
		this.dataGridView_1.Location = new Point(3, 392);
		this.dataGridView_1.Name = "dgvAbnObj";
		this.dataGridView_1.ReadOnly = true;
		dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle3.BackColor = SystemColors.Control;
		dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
		this.dataGridView_1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
		this.dataGridView_1.RowHeadersVisible = false;
		this.dataGridView_1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		this.dataGridView_1.Size = new Size(692, 128);
		this.dataGridView_1.TabIndex = 10;
		this.dataGridView_1.VirtualMode = true;
		this.dataGridView_1.CellFormatting += this.dataGridView_1_CellFormatting;
		this.dataGridViewTextBoxColumn_16.DataPropertyName = "Street";
		this.dataGridViewTextBoxColumn_16.HeaderText = "Улица";
		this.dataGridViewTextBoxColumn_16.Name = "streetDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_16.ReadOnly = true;
		this.dataGridViewTextBoxColumn_16.Width = 180;
		this.dataGridViewTextBoxColumn_17.DataPropertyName = "idSchmObj";
		this.dataGridViewTextBoxColumn_17.HeaderText = "idSchmObj";
		this.dataGridViewTextBoxColumn_17.Name = "idSchmObjDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_17.ReadOnly = true;
		this.dataGridViewTextBoxColumn_17.Visible = false;
		this.dataGridViewTextBoxColumn_18.DataPropertyName = "TypeDoc";
		this.dataGridViewTextBoxColumn_18.HeaderText = "TypeDoc";
		this.dataGridViewTextBoxColumn_18.Name = "typeDocDgvColumn";
		this.dataGridViewTextBoxColumn_18.ReadOnly = true;
		this.dataGridViewTextBoxColumn_18.Visible = false;
		this.dataGridViewTextBoxColumn_19.DataPropertyName = "House";
		this.dataGridViewTextBoxColumn_19.HeaderText = "Дом";
		this.dataGridViewTextBoxColumn_19.Name = "houseDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_19.ReadOnly = true;
		this.dataGridViewTextBoxColumn_19.Width = 50;
		this.dataGridViewTextBoxColumn_20.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_20.DataPropertyName = "Name";
		this.dataGridViewTextBoxColumn_20.HeaderText = "Наименование";
		this.dataGridViewTextBoxColumn_20.Name = "nameDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_20.ReadOnly = true;
		this.dataGridViewTextBoxColumn_21.DataPropertyName = "codeAbonent";
		this.dataGridViewTextBoxColumn_21.HeaderText = "Номер договора";
		this.dataGridViewTextBoxColumn_21.Name = "codeAbonent";
		this.dataGridViewTextBoxColumn_21.ReadOnly = true;
		this.dataGridViewTextBoxColumn_21.Width = 120;
		this.dataGridViewTextBoxColumn_22.DataPropertyName = "ids";
		this.dataGridViewTextBoxColumn_22.HeaderText = "ids";
		this.dataGridViewTextBoxColumn_22.Name = "dgvcIds";
		this.dataGridViewTextBoxColumn_22.ReadOnly = true;
		this.dataGridViewTextBoxColumn_22.Visible = false;
		this.bindingSource_11.DataMember = "vJ_MeasAbnObj";
		this.bindingSource_11.DataSource = this.class255_0;
		this.bindingSource_11.Sort = "";
		this.class255_0.DataSetName = "DataSetGES";
		this.class255_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		this.dataGridView_0.AllowUserToAddRows = false;
		this.dataGridView_0.AllowUserToDeleteRows = false;
		this.dataGridView_0.AllowUserToResizeRows = false;
		this.dataGridView_0.AutoGenerateColumns = false;
		this.dataGridView_0.BackgroundColor = Color.White;
		dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle4.BackColor = SystemColors.Control;
		dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
		this.dataGridView_0.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
		this.dataGridView_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView_0.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewTextBoxColumn_0,
			this.dataGridViewTextBoxColumn_1,
			this.dataGridViewComboBoxColumn_0,
			this.dataGridViewTextBoxColumn_2,
			this.dataGridViewTextBoxColumn_3,
			this.dataGridViewComboBoxColumn_1,
			this.HvHoUgxkjqO,
			this.dataGridViewTextBoxColumn_4,
			this.dataGridViewTextBoxColumn_5,
			this.dataGridViewTextBoxColumn_6,
			this.dataGridViewComboBoxColumn_2,
			this.dataGridViewComboBoxColumn_3,
			this.dataGridViewComboBoxColumn_4,
			this.dataGridViewComboBoxColumn_5,
			this.dataGridViewComboBoxColumn_6,
			this.dataGridViewTextBoxColumn_7,
			this.dataGridViewTextBoxColumn_8,
			this.dataGridViewTextBoxColumn_9,
			this.dataGridViewTextBoxColumn_10,
			this.dataGridViewTextBoxColumn_11,
			this.dataGridViewTextBoxColumn_12,
			this.dataGridViewTextBoxColumn_13,
			this.dataGridViewTextBoxColumn_14,
			this.dataGridViewTextBoxColumn_15,
			this.dataGridViewCheckBoxColumn_0
		});
		this.tableLayoutPanel_0.SetColumnSpan(this.dataGridView_0, 6);
		this.dataGridView_0.DataSource = this.bindingSource_3;
		dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle5.BackColor = SystemColors.Window;
		dataGridViewCellStyle5.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
		dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
		this.dataGridView_0.DefaultCellStyle = dataGridViewCellStyle5;
		this.dataGridView_0.Dock = DockStyle.Fill;
		this.dataGridView_0.EditMode = DataGridViewEditMode.EditOnEnter;
		this.dataGridView_0.Location = new Point(3, 194);
		this.dataGridView_0.MultiSelect = false;
		this.dataGridView_0.Name = "dgvMeasCable";
		dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle6.BackColor = SystemColors.Control;
		dataGridViewCellStyle6.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
		this.dataGridView_0.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
		this.dataGridView_0.RowHeadersVisible = false;
		this.dataGridView_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		this.dataGridView_0.Size = new Size(692, 168);
		this.dataGridView_0.TabIndex = 8;
		this.dataGridView_0.CellBeginEdit += this.dataGridView_0_CellBeginEdit;
		this.dataGridView_0.CellEndEdit += this.dataGridView_0_CellEndEdit;
		this.dataGridView_0.ColumnHeaderMouseClick += this.dataGridView_0_ColumnHeaderMouseClick;
		this.dataGridView_0.DataError += this.cHkojevBpau;
		this.dataGridView_0.RowsAdded += this.dataGridView_0_RowsAdded;
		this.dataGridView_0.SelectionChanged += this.ydXojhEhNhr;
		this.dataGridView_0.Sorted += this.dataGridView_0_Sorted;
		this.dataGridView_0.KeyPress += this.AgcojwYvpTS;
		this.dataGridView_0.MouseClick += this.dataGridView_0_MouseClick;
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
		this.dataGridViewComboBoxColumn_0.DataSource = this.bindingSource_7;
		this.dataGridViewComboBoxColumn_0.DisplayMember = "Name";
		this.dataGridViewComboBoxColumn_0.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
		this.dataGridViewComboBoxColumn_0.FlatStyle = FlatStyle.Popup;
		this.dataGridViewComboBoxColumn_0.HeaderText = "№ руб.";
		this.dataGridViewComboBoxColumn_0.Name = "dgvcIdCell";
		this.dataGridViewComboBoxColumn_0.Resizable = DataGridViewTriState.True;
		this.dataGridViewComboBoxColumn_0.SortMode = DataGridViewColumnSortMode.Programmatic;
		this.dataGridViewComboBoxColumn_0.ValueMember = "id";
		this.dataGridViewComboBoxColumn_0.Width = 30;
		this.bindingSource_7.DataMember = "vJ_CellByBus";
		this.bindingSource_7.DataSource = this.class255_0;
		this.bindingSource_7.Sort = "";
		this.bindingSource_7.CurrentChanged += this.bindingSource_7_CurrentChanged;
		this.dataGridViewTextBoxColumn_2.DataPropertyName = "NameCell";
		this.dataGridViewTextBoxColumn_2.HeaderText = "NameCell";
		this.dataGridViewTextBoxColumn_2.Name = "dgvcNameCell";
		this.dataGridViewTextBoxColumn_2.Visible = false;
		this.dataGridViewTextBoxColumn_3.DataPropertyName = "OldCell";
		this.dataGridViewTextBoxColumn_3.HeaderText = "№ ст. руб.";
		this.dataGridViewTextBoxColumn_3.Name = "OldCell";
		this.dataGridViewTextBoxColumn_3.ReadOnly = true;
		this.dataGridViewTextBoxColumn_3.SortMode = DataGridViewColumnSortMode.Programmatic;
		this.dataGridViewTextBoxColumn_3.Width = 50;
		this.dataGridViewComboBoxColumn_1.DataPropertyName = "idCable";
		this.dataGridViewComboBoxColumn_1.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
		this.dataGridViewComboBoxColumn_1.DropDownWidth = 200;
		this.dataGridViewComboBoxColumn_1.FlatStyle = FlatStyle.Popup;
		this.dataGridViewComboBoxColumn_1.HeaderText = "Кабель";
		this.dataGridViewComboBoxColumn_1.Name = "dgvcIdCable";
		this.dataGridViewComboBoxColumn_1.Resizable = DataGridViewTriState.True;
		this.dataGridViewComboBoxColumn_1.SortMode = DataGridViewColumnSortMode.Programmatic;
		this.dataGridViewComboBoxColumn_1.Width = 70;
		this.HvHoUgxkjqO.DataPropertyName = "NameCable";
		this.HvHoUgxkjqO.HeaderText = "NameCable";
		this.HvHoUgxkjqO.Name = "dgvcNameCable";
		this.HvHoUgxkjqO.Visible = false;
		this.dataGridViewTextBoxColumn_4.DataPropertyName = "Address";
		this.dataGridViewTextBoxColumn_4.HeaderText = "Адрес объекта";
		this.dataGridViewTextBoxColumn_4.Name = "Address";
		this.dataGridViewTextBoxColumn_4.ReadOnly = true;
		this.dataGridViewTextBoxColumn_4.SortMode = DataGridViewColumnSortMode.Programmatic;
		this.dataGridViewTextBoxColumn_5.DataPropertyName = "Company";
		this.dataGridViewTextBoxColumn_5.HeaderText = "Наименование объекта";
		this.dataGridViewTextBoxColumn_5.Name = "Company";
		this.dataGridViewTextBoxColumn_5.ReadOnly = true;
		this.dataGridViewTextBoxColumn_5.SortMode = DataGridViewColumnSortMode.Programmatic;
		this.dataGridViewTextBoxColumn_6.DataPropertyName = "idSchmAbn";
		this.dataGridViewTextBoxColumn_6.HeaderText = "idSchmAbn";
		this.dataGridViewTextBoxColumn_6.Name = "idSchmAbnDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_6.SortMode = DataGridViewColumnSortMode.Programmatic;
		this.dataGridViewTextBoxColumn_6.Visible = false;
		this.dataGridViewComboBoxColumn_2.DataPropertyName = "Makeup";
		this.dataGridViewComboBoxColumn_2.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
		this.dataGridViewComboBoxColumn_2.FlatStyle = FlatStyle.Popup;
		this.dataGridViewComboBoxColumn_2.HeaderText = "Марка кабеля";
		this.dataGridViewComboBoxColumn_2.Name = "dgvcCableMakeup";
		this.dataGridViewComboBoxColumn_2.Resizable = DataGridViewTriState.True;
		this.dataGridViewComboBoxColumn_2.SortMode = DataGridViewColumnSortMode.Programmatic;
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
		dataGridViewCellStyle7.Format = "N0";
		this.dataGridViewComboBoxColumn_4.DefaultCellStyle = dataGridViewCellStyle7;
		this.dataGridViewComboBoxColumn_4.FlatStyle = FlatStyle.Popup;
		this.dataGridViewComboBoxColumn_4.HeaderText = "Кол-во жил";
		this.dataGridViewComboBoxColumn_4.Name = "dgvcWires";
		this.dataGridViewComboBoxColumn_4.Resizable = DataGridViewTriState.True;
		this.dataGridViewComboBoxColumn_4.SortMode = DataGridViewColumnSortMode.Programmatic;
		this.dataGridViewComboBoxColumn_4.Width = 40;
		this.dataGridViewComboBoxColumn_5.DataPropertyName = "CrossSection";
		this.dataGridViewComboBoxColumn_5.FlatStyle = FlatStyle.Popup;
		this.dataGridViewComboBoxColumn_5.HeaderText = "Сечение";
		this.dataGridViewComboBoxColumn_5.Name = "dgvcCrossSection";
		this.dataGridViewComboBoxColumn_5.Resizable = DataGridViewTriState.True;
		this.dataGridViewComboBoxColumn_5.SortMode = DataGridViewColumnSortMode.Programmatic;
		this.dataGridViewComboBoxColumn_5.Width = 50;
		this.dataGridViewComboBoxColumn_6.DataPropertyName = "PermisAmperage";
		this.dataGridViewComboBoxColumn_6.DropDownWidth = 90;
		this.dataGridViewComboBoxColumn_6.FlatStyle = FlatStyle.Popup;
		this.dataGridViewComboBoxColumn_6.HeaderText = "Допуст. нагр., А";
		this.dataGridViewComboBoxColumn_6.Name = "dgvcPermisAmperage";
		this.dataGridViewComboBoxColumn_6.Resizable = DataGridViewTriState.True;
		this.dataGridViewComboBoxColumn_6.SortMode = DataGridViewColumnSortMode.Programmatic;
		this.dataGridViewComboBoxColumn_6.Width = 60;
		this.dataGridViewTextBoxColumn_7.DataPropertyName = "Iad";
		dataGridViewCellStyle8.Format = "N0";
		this.dataGridViewTextBoxColumn_7.DefaultCellStyle = dataGridViewCellStyle8;
		this.dataGridViewTextBoxColumn_7.HeaderText = "А дн.";
		this.dataGridViewTextBoxColumn_7.Name = "Iad";
		this.dataGridViewTextBoxColumn_7.SortMode = DataGridViewColumnSortMode.Programmatic;
		this.dataGridViewTextBoxColumn_7.Width = 35;
		this.dataGridViewTextBoxColumn_8.DataPropertyName = "Ian";
		dataGridViewCellStyle9.Format = "N0";
		this.dataGridViewTextBoxColumn_8.DefaultCellStyle = dataGridViewCellStyle9;
		this.dataGridViewTextBoxColumn_8.HeaderText = "А вч.";
		this.dataGridViewTextBoxColumn_8.Name = "Ian";
		this.dataGridViewTextBoxColumn_8.SortMode = DataGridViewColumnSortMode.Programmatic;
		this.dataGridViewTextBoxColumn_8.Width = 35;
		this.dataGridViewTextBoxColumn_9.DataPropertyName = "Ibd";
		dataGridViewCellStyle10.Format = "N0";
		this.dataGridViewTextBoxColumn_9.DefaultCellStyle = dataGridViewCellStyle10;
		this.dataGridViewTextBoxColumn_9.HeaderText = "В дн.";
		this.dataGridViewTextBoxColumn_9.Name = "Ibd";
		this.dataGridViewTextBoxColumn_9.SortMode = DataGridViewColumnSortMode.Programmatic;
		this.dataGridViewTextBoxColumn_9.Width = 35;
		this.dataGridViewTextBoxColumn_10.DataPropertyName = "Ibn";
		dataGridViewCellStyle11.Format = "N0";
		this.dataGridViewTextBoxColumn_10.DefaultCellStyle = dataGridViewCellStyle11;
		this.dataGridViewTextBoxColumn_10.HeaderText = "В вч.";
		this.dataGridViewTextBoxColumn_10.Name = "Ibn";
		this.dataGridViewTextBoxColumn_10.SortMode = DataGridViewColumnSortMode.Programmatic;
		this.dataGridViewTextBoxColumn_10.Width = 35;
		this.dataGridViewTextBoxColumn_11.DataPropertyName = "Icd";
		dataGridViewCellStyle12.Format = "N0";
		this.dataGridViewTextBoxColumn_11.DefaultCellStyle = dataGridViewCellStyle12;
		this.dataGridViewTextBoxColumn_11.HeaderText = "С дн.";
		this.dataGridViewTextBoxColumn_11.Name = "Icd";
		this.dataGridViewTextBoxColumn_11.SortMode = DataGridViewColumnSortMode.Programmatic;
		this.dataGridViewTextBoxColumn_11.Width = 35;
		this.dataGridViewTextBoxColumn_12.DataPropertyName = "Icn";
		dataGridViewCellStyle13.Format = "N0";
		this.dataGridViewTextBoxColumn_12.DefaultCellStyle = dataGridViewCellStyle13;
		this.dataGridViewTextBoxColumn_12.HeaderText = "С вч.";
		this.dataGridViewTextBoxColumn_12.Name = "Icn";
		this.dataGridViewTextBoxColumn_12.SortMode = DataGridViewColumnSortMode.Programmatic;
		this.dataGridViewTextBoxColumn_12.Width = 35;
		this.dataGridViewTextBoxColumn_13.DataPropertyName = "Iod";
		dataGridViewCellStyle14.Format = "N0";
		this.dataGridViewTextBoxColumn_13.DefaultCellStyle = dataGridViewCellStyle14;
		this.dataGridViewTextBoxColumn_13.HeaderText = "0 дн.";
		this.dataGridViewTextBoxColumn_13.Name = "Iod";
		this.dataGridViewTextBoxColumn_13.SortMode = DataGridViewColumnSortMode.Programmatic;
		this.dataGridViewTextBoxColumn_13.Width = 35;
		this.dataGridViewTextBoxColumn_14.DataPropertyName = "Ion";
		dataGridViewCellStyle15.Format = "N0";
		dataGridViewCellStyle15.NullValue = null;
		this.dataGridViewTextBoxColumn_14.DefaultCellStyle = dataGridViewCellStyle15;
		this.dataGridViewTextBoxColumn_14.HeaderText = "0 вч.";
		this.dataGridViewTextBoxColumn_14.Name = "Ion";
		this.dataGridViewTextBoxColumn_14.SortMode = DataGridViewColumnSortMode.Programmatic;
		this.dataGridViewTextBoxColumn_14.Width = 35;
		this.dataGridViewTextBoxColumn_15.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_15.DataPropertyName = "Comment";
		this.dataGridViewTextBoxColumn_15.HeaderText = "Комментарий";
		this.dataGridViewTextBoxColumn_15.MinimumWidth = 80;
		this.dataGridViewTextBoxColumn_15.Name = "commentDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_15.SortMode = DataGridViewColumnSortMode.Programmatic;
		this.dataGridViewCheckBoxColumn_0.DataPropertyName = "Deleted";
		this.dataGridViewCheckBoxColumn_0.HeaderText = "Deleted";
		this.dataGridViewCheckBoxColumn_0.Name = "deletedDataGridViewCheckBoxColumn";
		this.dataGridViewCheckBoxColumn_0.SortMode = DataGridViewColumnSortMode.Programmatic;
		this.dataGridViewCheckBoxColumn_0.Visible = false;
		this.bindingSource_3.DataMember = "tJ_MeasCable";
		this.bindingSource_3.DataSource = this.class255_0;
		this.bindingSource_3.CurrentChanged += this.bindingSource_3_CurrentChanged;
		this.comboBox_1.DataSource = this.bindingSource_12;
		this.comboBox_1.DisplayMember = "NameBusTransf";
		this.comboBox_1.Dock = DockStyle.Fill;
		this.comboBox_1.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_1.FormattingEnabled = true;
		this.comboBox_1.Location = new Point(144, 79);
		this.comboBox_1.Margin = new Padding(3, 0, 3, 3);
		this.comboBox_1.Name = "cbTransformer";
		this.comboBox_1.Size = new Size(95, 21);
		this.comboBox_1.TabIndex = 2;
		this.comboBox_1.ValueMember = "idBus";
		this.bindingSource_12.DataMember = "dtBusesTransf";
		this.bindingSource_12.DataSource = this.class255_0;
		this.bindingSource_12.Sort = "NameBusTransf";
		this.label_6.BorderStyle = BorderStyle.FixedSingle;
		this.label_6.Dock = DockStyle.Fill;
		this.label_6.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.label_6.Location = new Point(3, 79);
		this.label_6.Name = "labelTrans";
		this.label_6.Size = new Size(135, 21);
		this.label_6.TabIndex = 1;
		this.label_6.Text = "Секция шин (тр-р) №";
		this.label_6.TextAlign = ContentAlignment.TopRight;
		this.tableLayoutPanel_0.SetColumnSpan(this.groupBox_0, 6);
		this.groupBox_0.Controls.Add(this.toolStrip_2);
		this.groupBox_0.Controls.Add(this.label_16);
		this.groupBox_0.Controls.Add(this.comboBox_3);
		this.groupBox_0.Controls.Add(this.nullableDateTimePicker_0);
		this.groupBox_0.Controls.Add(this.nullableDateTimePicker_1);
		this.groupBox_0.Controls.Add(this.comboBox_0);
		this.groupBox_0.Controls.Add(this.numericUpDown_0);
		this.groupBox_0.Controls.Add(this.numericUpDown_1);
		this.groupBox_0.Controls.Add(this.label_0);
		this.groupBox_0.Controls.Add(this.label_1);
		this.groupBox_0.Controls.Add(this.label_2);
		this.groupBox_0.Controls.Add(this.label_3);
		this.groupBox_0.Controls.Add(this.label_4);
		this.groupBox_0.Controls.Add(this.label_5);
		this.groupBox_0.Dock = DockStyle.Fill;
		this.groupBox_0.Location = new Point(3, 3);
		this.groupBox_0.Name = "groupBox1";
		this.groupBox_0.Size = new Size(692, 73);
		this.groupBox_0.TabIndex = 0;
		this.groupBox_0.TabStop = false;
		this.groupBox_0.Text = "Параметры замера";
		this.toolStrip_2.Dock = DockStyle.None;
		this.toolStrip_2.Items.AddRange(new ToolStripItem[]
		{
			this.toolStripButton_5
		});
		this.toolStrip_2.Location = new Point(373, 44);
		this.toolStrip_2.Name = "toolStripTemperature";
		this.toolStrip_2.Size = new Size(35, 25);
		this.toolStrip_2.TabIndex = 7;
		this.toolStrip_2.Text = "toolStrip1";
		this.toolStripButton_5.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_5.Image = Resources.report_go;
		this.toolStripButton_5.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_5.Name = "toolBtnImportTemperature";
		this.toolStripButton_5.Size = new Size(23, 22);
		this.toolStripButton_5.Text = "Загрузка из реестра температур";
		this.toolStripButton_5.Click += this.toolStripButton_5_Click;
		this.label_16.AutoSize = true;
		this.label_16.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.label_16.Location = new Point(9, 21);
		this.label_16.Name = "label3";
		this.label_16.Size = new Size(48, 13);
		this.label_16.TabIndex = 0;
		this.label_16.Text = "Период:";
		this.label_16.TextAlign = ContentAlignment.MiddleLeft;
		this.comboBox_3.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBox_3.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBox_3.DataBindings.Add(new Binding("SelectedValue", this.bindingSource_1, "Year", true));
		this.comboBox_3.DisplayMember = "Id";
		this.comboBox_3.FormattingEnabled = true;
		this.comboBox_3.Location = new Point(9, 44);
		this.comboBox_3.Name = "cbYear";
		this.comboBox_3.Size = new Size(78, 21);
		this.comboBox_3.TabIndex = 1;
		this.comboBox_3.ValueMember = "Id";
		this.comboBox_3.SelectedValueChanged += this.comboBox_3_SelectedValueChanged;
		this.bindingSource_1.DataMember = "tJ_Measurement";
		this.bindingSource_1.DataSource = this.class255_0;
		this.nullableDateTimePicker_0.CustomFormat = "ddMMMMyyyy г. HH:mm";
		this.nullableDateTimePicker_0.DataBindings.Add(new Binding("Value", this.bindingSource_1, "DateN", true));
		this.nullableDateTimePicker_0.Format = DateTimePickerFormat.Custom;
		this.nullableDateTimePicker_0.Location = new Point(144, 45);
		this.nullableDateTimePicker_0.Name = "dtpDateN";
		this.nullableDateTimePicker_0.Size = new Size(166, 20);
		this.nullableDateTimePicker_0.TabIndex = 5;
		this.nullableDateTimePicker_0.Value = new DateTime(2013, 8, 29, 10, 49, 16, 759);
		this.nullableDateTimePicker_1.CustomFormat = "ddMMMMyyyy г. HH:mm";
		this.nullableDateTimePicker_1.DataBindings.Add(new Binding("Value", this.bindingSource_1, "DateD", true));
		this.nullableDateTimePicker_1.Format = DateTimePickerFormat.Custom;
		this.nullableDateTimePicker_1.Location = new Point(144, 20);
		this.nullableDateTimePicker_1.Name = "dtpDateD";
		this.nullableDateTimePicker_1.Size = new Size(166, 20);
		this.nullableDateTimePicker_1.TabIndex = 4;
		this.nullableDateTimePicker_1.Value = new DateTime(2013, 8, 29, 10, 49, 16, 759);
		this.comboBox_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.comboBox_0.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBox_0.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBox_0.DataBindings.Add(new Binding("SelectedValue", this.bindingSource_1, "idWorker", true));
		this.comboBox_0.DataSource = this.bindingSource_0;
		this.comboBox_0.DisplayMember = "FIO";
		this.comboBox_0.FormattingEnabled = true;
		this.comboBox_0.Location = new Point(525, 44);
		this.comboBox_0.Name = "cbWorker";
		this.comboBox_0.Size = new Size(154, 21);
		this.comboBox_0.TabIndex = 13;
		this.comboBox_0.ValueMember = "Id";
		this.bindingSource_0.DataMember = "vP_Worker";
		this.bindingSource_0.DataSource = this.class255_0;
		this.bindingSource_0.Sort = "FIO";
		this.numericUpDown_0.DataBindings.Add(new Binding("Value", this.bindingSource_1, "TemperatureN", true));
		this.numericUpDown_0.Location = new Point(459, 45);
		this.numericUpDown_0.Minimum = new decimal(new int[]
		{
			100,
			0,
			0,
			int.MinValue
		});
		this.numericUpDown_0.Name = "nudTemperatureN";
		this.numericUpDown_0.Size = new Size(48, 20);
		this.numericUpDown_0.TabIndex = 11;
		this.numericUpDown_1.DataBindings.Add(new Binding("Value", this.bindingSource_1, "TemperatureD", true));
		this.numericUpDown_1.Location = new Point(459, 18);
		this.numericUpDown_1.Minimum = new decimal(new int[]
		{
			100,
			0,
			0,
			int.MinValue
		});
		this.numericUpDown_1.Name = "nudTemperatureD";
		this.numericUpDown_1.Size = new Size(48, 20);
		this.numericUpDown_1.TabIndex = 9;
		this.label_0.AutoSize = true;
		this.label_0.Location = new Point(419, 47);
		this.label_0.Name = "label6";
		this.label_0.Size = new Size(37, 13);
		this.label_0.TabIndex = 10;
		this.label_0.Text = "Вечер";
		this.label_1.AutoSize = true;
		this.label_1.Location = new Point(101, 47);
		this.label_1.Name = "label2";
		this.label_1.Size = new Size(37, 13);
		this.label_1.TabIndex = 3;
		this.label_1.Text = "Вечер";
		this.label_2.AutoSize = true;
		this.label_2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.label_2.Location = new Point(522, 20);
		this.label_2.Name = "label7";
		this.label_2.Size = new Size(102, 13);
		this.label_2.TabIndex = 12;
		this.label_2.Text = "Замеры проводил:";
		this.label_3.AutoSize = true;
		this.label_3.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.label_3.Location = new Point(324, 21);
		this.label_3.Name = "label5";
		this.label_3.Size = new Size(87, 15);
		this.label_3.TabIndex = 6;
		this.label_3.Text = "Температура:";
		this.label_4.AutoSize = true;
		this.label_4.Location = new Point(422, 20);
		this.label_4.Name = "label4";
		this.label_4.Size = new Size(34, 13);
		this.label_4.TabIndex = 8;
		this.label_4.Text = "День";
		this.label_5.AutoSize = true;
		this.label_5.Location = new Point(101, 23);
		this.label_5.Name = "label1";
		this.label_5.Size = new Size(34, 13);
		this.label_5.TabIndex = 2;
		this.label_5.Text = "День";
		this.tableLayoutPanel_0.SetColumnSpan(this.panel_0, 6);
		this.panel_0.Controls.Add(this.label_13);
		this.panel_0.Controls.Add(this.label_14);
		this.panel_0.Controls.Add(this.label_7);
		this.panel_0.Controls.Add(this.label_8);
		this.panel_0.Controls.Add(this.label_9);
		this.panel_0.Controls.Add(this.label_10);
		this.panel_0.Controls.Add(this.label_11);
		this.panel_0.Controls.Add(this.label_12);
		this.panel_0.Controls.Add(this.textBox_0);
		this.panel_0.Controls.Add(this.textBox_1);
		this.panel_0.Controls.Add(this.textBox_2);
		this.panel_0.Controls.Add(this.textBox_3);
		this.panel_0.Controls.Add(this.textBox_4);
		this.panel_0.Controls.Add(this.textBox_5);
		this.panel_0.Controls.Add(this.textBox_6);
		this.panel_0.Controls.Add(this.textBox_7);
		this.panel_0.Controls.Add(this.textBox_8);
		this.panel_0.Controls.Add(this.textBox_9);
		this.panel_0.Controls.Add(this.textBox_10);
		this.panel_0.Controls.Add(this.textBox_11);
		this.panel_0.Dock = DockStyle.Fill;
		this.panel_0.Location = new Point(3, 103);
		this.panel_0.Name = "panel1";
		this.panel_0.Size = new Size(692, 61);
		this.panel_0.TabIndex = 6;
		this.label_13.AutoSize = true;
		this.label_13.Location = new Point(28, 40);
		this.label_13.Name = "label14";
		this.label_13.Size = new Size(37, 13);
		this.label_13.TabIndex = 13;
		this.label_13.Text = "Вечер";
		this.label_14.AutoSize = true;
		this.label_14.Location = new Point(31, 14);
		this.label_14.Name = "label13";
		this.label_14.Size = new Size(34, 13);
		this.label_14.TabIndex = 0;
		this.label_14.Text = "День";
		this.label_7.AutoSize = true;
		this.label_7.Location = new Point(362, 14);
		this.label_7.Name = "label21";
		this.label_7.Size = new Size(30, 13);
		this.label_7.TabIndex = 7;
		this.label_7.Text = "Ua-o";
		this.label_8.AutoSize = true;
		this.label_8.Location = new Point(459, 14);
		this.label_8.Name = "label22";
		this.label_8.Size = new Size(30, 13);
		this.label_8.TabIndex = 9;
		this.label_8.Text = "Ub-o";
		this.label_9.AutoSize = true;
		this.label_9.Location = new Point(270, 14);
		this.label_9.Name = "label20";
		this.label_9.Size = new Size(27, 13);
		this.label_9.TabIndex = 5;
		this.label_9.Text = "Uca";
		this.label_10.AutoSize = true;
		this.label_10.Location = new Point(177, 14);
		this.label_10.Name = "label17";
		this.label_10.Size = new Size(27, 13);
		this.label_10.TabIndex = 3;
		this.label_10.Text = "Ubc";
		this.label_11.AutoSize = true;
		this.label_11.Location = new Point(555, 14);
		this.label_11.Name = "label23";
		this.label_11.Size = new Size(30, 13);
		this.label_11.TabIndex = 11;
		this.label_11.Text = "Uc-o";
		this.label_12.AutoSize = true;
		this.label_12.Location = new Point(86, 14);
		this.label_12.Name = "label16";
		this.label_12.Size = new Size(27, 13);
		this.label_12.TabIndex = 1;
		this.label_12.Text = "Uab";
		this.textBox_0.DataBindings.Add(new Binding("Text", this.bindingSource_2, "Ucon", true));
		this.textBox_0.Location = new Point(591, 37);
		this.textBox_0.Name = "tbUcon";
		this.textBox_0.Size = new Size(44, 20);
		this.textBox_0.TabIndex = 19;
		this.textBox_0.KeyPress += this.textBox_11_KeyPress;
		this.bindingSource_2.DataMember = "tJ_MeasVoltageTransf";
		this.bindingSource_2.DataSource = this.class255_0;
		this.textBox_1.DataBindings.Add(new Binding("Text", this.bindingSource_2, "Ucan", true));
		this.textBox_1.Location = new Point(303, 38);
		this.textBox_1.Name = "tbUcan";
		this.textBox_1.Size = new Size(44, 20);
		this.textBox_1.TabIndex = 16;
		this.textBox_1.KeyPress += this.textBox_11_KeyPress;
		this.textBox_2.DataBindings.Add(new Binding("Text", this.bindingSource_2, "Ubcn", true));
		this.textBox_2.Location = new Point(210, 37);
		this.textBox_2.Name = "tbUbcn";
		this.textBox_2.Size = new Size(44, 20);
		this.textBox_2.TabIndex = 15;
		this.textBox_2.KeyPress += this.textBox_11_KeyPress;
		this.textBox_3.DataBindings.Add(new Binding("Text", this.bindingSource_2, "Ubon", true));
		this.textBox_3.Location = new Point(495, 37);
		this.textBox_3.Name = "tbUbon";
		this.textBox_3.Size = new Size(44, 20);
		this.textBox_3.TabIndex = 18;
		this.textBox_3.KeyPress += this.textBox_11_KeyPress;
		this.textBox_4.DataBindings.Add(new Binding("Text", this.bindingSource_2, "Ucod", true));
		this.textBox_4.Location = new Point(591, 11);
		this.textBox_4.Name = "tbUcod";
		this.textBox_4.Size = new Size(44, 20);
		this.textBox_4.TabIndex = 12;
		this.textBox_4.KeyPress += this.textBox_11_KeyPress;
		this.textBox_5.DataBindings.Add(new Binding("Text", this.bindingSource_2, "Ubod", true));
		this.textBox_5.Location = new Point(495, 11);
		this.textBox_5.Name = "tbUbod";
		this.textBox_5.Size = new Size(44, 20);
		this.textBox_5.TabIndex = 10;
		this.textBox_5.KeyPress += this.textBox_11_KeyPress;
		this.textBox_6.DataBindings.Add(new Binding("Text", this.bindingSource_2, "Uaon", true));
		this.textBox_6.Location = new Point(398, 37);
		this.textBox_6.Name = "tbUaon";
		this.textBox_6.Size = new Size(44, 20);
		this.textBox_6.TabIndex = 17;
		this.textBox_6.KeyPress += this.textBox_11_KeyPress;
		this.textBox_7.DataBindings.Add(new Binding("Text", this.bindingSource_2, "Uabn", true));
		this.textBox_7.Location = new Point(119, 37);
		this.textBox_7.Name = "tbUabn";
		this.textBox_7.Size = new Size(44, 20);
		this.textBox_7.TabIndex = 14;
		this.textBox_7.KeyPress += this.textBox_11_KeyPress;
		this.textBox_8.DataBindings.Add(new Binding("Text", this.bindingSource_2, "Ucad", true));
		this.textBox_8.Location = new Point(303, 11);
		this.textBox_8.Name = "tbUcad";
		this.textBox_8.Size = new Size(44, 20);
		this.textBox_8.TabIndex = 6;
		this.textBox_8.KeyPress += this.textBox_11_KeyPress;
		this.textBox_9.DataBindings.Add(new Binding("Text", this.bindingSource_2, "Uaod", true));
		this.textBox_9.Location = new Point(398, 11);
		this.textBox_9.Name = "tbUaod";
		this.textBox_9.Size = new Size(44, 20);
		this.textBox_9.TabIndex = 8;
		this.textBox_9.KeyPress += this.textBox_11_KeyPress;
		this.textBox_10.DataBindings.Add(new Binding("Text", this.bindingSource_2, "Ubcd", true));
		this.textBox_10.Location = new Point(210, 11);
		this.textBox_10.Name = "tbUbcd";
		this.textBox_10.Size = new Size(44, 20);
		this.textBox_10.TabIndex = 4;
		this.textBox_10.KeyPress += this.textBox_11_KeyPress;
		this.textBox_11.DataBindings.Add(new Binding("Text", this.bindingSource_2, "Uabd", true));
		this.textBox_11.Location = new Point(119, 11);
		this.textBox_11.Name = "tbUabd";
		this.textBox_11.Size = new Size(44, 20);
		this.textBox_11.TabIndex = 2;
		this.textBox_11.KeyPress += this.textBox_11_KeyPress;
		this.tableLayoutPanel_0.SetColumnSpan(this.toolStrip_0, 6);
		this.toolStrip_0.Dock = DockStyle.Fill;
		this.toolStrip_0.Items.AddRange(new ToolStripItem[]
		{
			this.toolStripButton_0,
			this.toolStripButton_1,
			this.toolStripButton_2,
			this.toolStripSeparator_0,
			this.toolStripButton_3
		});
		this.toolStrip_0.Location = new Point(0, 365);
		this.toolStrip_0.Name = "tsMeasAbnObj";
		this.toolStrip_0.Size = new Size(698, 24);
		this.toolStrip_0.TabIndex = 9;
		this.toolStrip_0.Text = "toolStrip1";
		this.toolStripButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_0.Image = (Image)componentResourceManager.GetObject("tsbMeasAbnObjAdd.Image");
		this.toolStripButton_0.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_0.Name = "tsbMeasAbnObjAdd";
		this.toolStripButton_0.Size = new Size(23, 21);
		this.toolStripButton_0.Text = "Добавить";
		this.toolStripButton_0.Click += this.toolStripButton_0_Click;
		this.toolStripButton_1.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_1.Image = (Image)componentResourceManager.GetObject("tsbMeasAbnObjEdit.Image");
		this.toolStripButton_1.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_1.Name = "tsbMeasAbnObjEdit";
		this.toolStripButton_1.Size = new Size(23, 21);
		this.toolStripButton_1.Text = "Редактировать";
		this.toolStripButton_1.Visible = false;
		this.toolStripButton_2.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_2.Image = (Image)componentResourceManager.GetObject("tsbMeasAbnObjDelete.Image");
		this.toolStripButton_2.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_2.Name = "tsbMeasAbnObjDelete";
		this.toolStripButton_2.Size = new Size(23, 21);
		this.toolStripButton_2.Text = "Удалить";
		this.toolStripButton_2.Click += this.toolStripButton_2_Click;
		this.toolStripSeparator_0.Name = "toolStripSeparator1";
		this.toolStripSeparator_0.Size = new Size(6, 24);
		this.toolStripButton_3.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_3.Image = (Image)componentResourceManager.GetObject("tsbMeasAbnObjRefresh.Image");
		this.toolStripButton_3.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_3.Name = "tsbMeasAbnObjRefresh";
		this.toolStripButton_3.Size = new Size(23, 21);
		this.toolStripButton_3.Text = "Обновить";
		this.toolStripButton_3.Click += this.toolStripButton_3_Click;
		this.comboBox_2.DataBindings.Add(new Binding("SelectedValue", this.bindingSource_2, "idSwitchPosition", true));
		this.comboBox_2.DataSource = this.bindingSource_13;
		this.comboBox_2.DisplayMember = "Name";
		this.comboBox_2.Dock = DockStyle.Left;
		this.comboBox_2.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_2.FormattingEnabled = true;
		this.comboBox_2.Location = new Point(592, 79);
		this.comboBox_2.Margin = new Padding(3, 0, 3, 3);
		this.comboBox_2.Name = "cbSwitchPosition";
		this.comboBox_2.Size = new Size(90, 21);
		this.comboBox_2.TabIndex = 5;
		this.comboBox_2.ValueMember = "Id";
		this.bindingSource_13.DataMember = "tR_Classifier";
		this.bindingSource_13.DataSource = this.class255_0;
		this.bindingSource_13.Filter = "ParentKey = ';Measurement;Switch;'";
		this.bindingSource_13.Sort = "Name";
		this.tableLayoutPanel_1.ColumnCount = 2;
		this.tableLayoutPanel_0.SetColumnSpan(this.tableLayoutPanel_1, 6);
		this.tableLayoutPanel_1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		this.tableLayoutPanel_1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 116f));
		this.tableLayoutPanel_1.Controls.Add(this.button_0, 1, 0);
		this.tableLayoutPanel_1.Controls.Add(this.button_1, 0, 0);
		this.tableLayoutPanel_1.Dock = DockStyle.Fill;
		this.tableLayoutPanel_1.Location = new Point(3, 526);
		this.tableLayoutPanel_1.Name = "tableLayoutPanel2";
		this.tableLayoutPanel_1.RowCount = 1;
		this.tableLayoutPanel_1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		this.tableLayoutPanel_1.Size = new Size(692, 33);
		this.tableLayoutPanel_1.TabIndex = 11;
		this.button_0.DialogResult = DialogResult.Cancel;
		this.button_0.Dock = DockStyle.Left;
		this.button_0.Location = new Point(586, 3);
		this.button_0.Margin = new Padding(10, 3, 3, 3);
		this.button_0.Name = "btnCancel";
		this.button_0.Size = new Size(75, 27);
		this.button_0.TabIndex = 1;
		this.button_0.Text = "Отмена";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_0.Click += this.button_0_Click;
		this.button_1.DialogResult = DialogResult.OK;
		this.button_1.Dock = DockStyle.Right;
		this.button_1.Location = new Point(467, 3);
		this.button_1.Margin = new Padding(3, 3, 10, 3);
		this.button_1.Name = "btnAccept";
		this.button_1.Size = new Size(99, 27);
		this.button_1.TabIndex = 0;
		this.button_1.Text = "Применить";
		this.button_1.UseVisualStyleBackColor = true;
		this.button_1.Click += this.button_1_Click;
		this.bindingSource_8.DataMember = "tR_CableMakeup";
		this.bindingSource_8.DataSource = this.class255_0;
		this.bindingSource_8.Filter = "";
		this.bindingSource_8.Sort = "CableMakeup";
		this.bindingSource_9.DataMember = "tR_CableVoltage";
		this.bindingSource_9.DataSource = this.class255_0;
		this.bindingSource_9.Filter = "";
		this.bindingSource_9.Sort = "Name";
		this.bindingSource_15.DataMember = "tR_CableWires";
		this.bindingSource_15.DataSource = this.class255_0;
		this.bindingSource_15.Sort = "Wires";
		this.bindingSource_10.DataMember = "tR_CrossSection";
		this.bindingSource_10.DataSource = this.class255_0;
		this.bindingSource_10.Filter = "";
		this.bindingSource_10.Sort = "CrossSection";
		this.bindingSource_14.DataMember = "tR_CableAmperage";
		this.bindingSource_14.DataSource = this.class255_0;
		this.bindingSource_14.Sort = "Amperage";
		this.bindingSource_4.DataMember = "tJ_MeasAmperageTransf";
		this.bindingSource_4.DataSource = this.class255_0;
		this.bindingSource_5.DataMember = "vJ_MeasTransfPassport";
		this.bindingSource_5.DataSource = this.class255_0;
		this.bindingSource_6.DataMember = "tP_ValueLists";
		this.bindingSource_6.DataSource = this.class255_0;
		this.bindingSource_6.Sort = "Name";
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(698, 562);
		base.Controls.Add(this.tableLayoutPanel_0);
		base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		base.Name = "FormAddEditMeasLowVoltage";
		base.StartPosition = FormStartPosition.CenterScreen;
		this.Text = "FormAddEditMeasTransfVoltage";
		base.Load += this.Form39_Load;
		this.tableLayoutPanel_0.ResumeLayout(false);
		this.tableLayoutPanel_0.PerformLayout();
		this.toolStrip_1.ResumeLayout(false);
		this.toolStrip_1.PerformLayout();
		((ISupportInitialize)this.dataGridView_1).EndInit();
		((ISupportInitialize)this.bindingSource_11).EndInit();
		((ISupportInitialize)this.class255_0).EndInit();
		((ISupportInitialize)this.dataGridView_0).EndInit();
		((ISupportInitialize)this.bindingSource_7).EndInit();
		((ISupportInitialize)this.bindingSource_3).EndInit();
		((ISupportInitialize)this.bindingSource_12).EndInit();
		this.groupBox_0.ResumeLayout(false);
		this.groupBox_0.PerformLayout();
		this.toolStrip_2.ResumeLayout(false);
		this.toolStrip_2.PerformLayout();
		((ISupportInitialize)this.bindingSource_1).EndInit();
		((ISupportInitialize)this.bindingSource_0).EndInit();
		((ISupportInitialize)this.numericUpDown_0).EndInit();
		((ISupportInitialize)this.numericUpDown_1).EndInit();
		this.panel_0.ResumeLayout(false);
		this.panel_0.PerformLayout();
		((ISupportInitialize)this.bindingSource_2).EndInit();
		this.toolStrip_0.ResumeLayout(false);
		this.toolStrip_0.PerformLayout();
		((ISupportInitialize)this.bindingSource_13).EndInit();
		this.tableLayoutPanel_1.ResumeLayout(false);
		((ISupportInitialize)this.bindingSource_8).EndInit();
		((ISupportInitialize)this.bindingSource_9).EndInit();
		((ISupportInitialize)this.bindingSource_15).EndInit();
		((ISupportInitialize)this.bindingSource_10).EndInit();
		((ISupportInitialize)this.bindingSource_14).EndInit();
		((ISupportInitialize)this.bindingSource_4).EndInit();
		((ISupportInitialize)this.bindingSource_5).EndInit();
		((ISupportInitialize)this.bindingSource_6).EndInit();
		base.ResumeLayout(false);
	}

	[CompilerGenerated]
	private bool method_52(Class255.Class433 class433_0)
	{
		return class433_0.idBus == this.IdBus && class433_0.idTransf == this.method_6();
	}

	[CompilerGenerated]
	private bool method_53(Class255.Class432 class432_0)
	{
		return (from c in this.class255_0.vJ_TransfByCell
		select c.idCell).Contains(class432_0.id);
	}

	[CompilerGenerated]
	private bool method_54(<>f__AnonymousType6<<>f__AnonymousType5<Class255.Class432, IEnumerable<Class255.Class422>>, Class255.Class422> <>f__AnonymousType6_0)
	{
		return (from t in this.class255_0.vJ_TransfByCell
		where t.idCell == <>f__AnonymousType6_0.<>h__TransparentIdentifier0.c.id
		select t).Count<Class255.Class421>() == 0;
	}

	[CompilerGenerated]
	private bool method_55(<>f__AnonymousType7<int, int, string, int, string> <>f__AnonymousType7_0)
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
	private void method_56(Class255.Class422 class422_0)
	{
		this.class255_0.vJ_CableByCell.ImportRow(class422_0);
	}

	[CompilerGenerated]
	private bool method_57(Class255.Class422 class422_0)
	{
		return class422_0.idCell == (int)((DataRowView)this.bindingSource_7.Current)["id"];
	}

	internal static void NNV0Z40OO7qAbgyjOVqY(Form form_0, bool bool_1)
	{
		form_0.Dispose(bool_1);
	}

	[CompilerGenerated]
	private int int_0;

	[CompilerGenerated]
	private int int_1;

	[CompilerGenerated]
	private int int_2;

	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private int int_3;

	[CompilerGenerated]
	private int int_4;

	[CompilerGenerated]
	private int int_5;

	[CompilerGenerated]
	private StateFormCreate stateFormCreate_0;

	private int int_6;

	private List<string> list_0;

	private string string_1;

	private IDictionary<string, Class255.Class331> idictionary_0;

	private IDictionary<string, Class255.Class313> idictionary_1;

	private bool bool_0;

	private DataGridViewColumn dataGridViewColumn_0;

	private TableLayoutPanel tableLayoutPanel_0;

	private Button button_0;

	private Button button_1;

	private GroupBox groupBox_0;

	private NullableDateTimePicker nullableDateTimePicker_0;

	private NullableDateTimePicker nullableDateTimePicker_1;

	private ComboBox comboBox_0;

	private NumericUpDown numericUpDown_0;

	private NumericUpDown numericUpDown_1;

	private Label label_0;

	private Label label_1;

	private Label label_2;

	private Label label_3;

	private Label label_4;

	private Label label_5;

	private Label label_6;

	private ComboBox comboBox_1;

	private Panel panel_0;

	private TextBox textBox_0;

	private TextBox textBox_1;

	private TextBox textBox_2;

	private TextBox textBox_3;

	private TextBox textBox_4;

	private TextBox textBox_5;

	private TextBox textBox_6;

	private TextBox textBox_7;

	private TextBox textBox_8;

	private TextBox textBox_9;

	private TextBox textBox_10;

	private TextBox textBox_11;

	private Label label_7;

	private Label label_8;

	private Label label_9;

	private Label label_10;

	private Label label_11;

	private Label label_12;

	private Label label_13;

	private Label label_14;

	private Class255 class255_0;

	private BindingSource bindingSource_0;

	private BindingSource bindingSource_1;

	private BindingSource bindingSource_2;

	private BindingSource bindingSource_3;

	private BindingSource bindingSource_4;

	private BindingSource bindingSource_5;

	private BindingSource bindingSource_6;

	private BindingSource bindingSource_7;

	private BindingSource bindingSource_8;

	private BindingSource bindingSource_9;

	private BindingSource bindingSource_10;

	private BindingSource bindingSource_11;

	private DataGridView dataGridView_0;

	private DataGridView dataGridView_1;

	private ToolStrip toolStrip_0;

	private ToolStripButton toolStripButton_0;

	private ToolStripButton toolStripButton_1;

	private ToolStripSeparator toolStripSeparator_0;

	private ToolStripButton toolStripButton_2;

	private ToolStripButton toolStripButton_3;

	private BindingSource bindingSource_12;

	private ComboBox comboBox_2;

	private Label label_15;

	private BindingSource bindingSource_13;

	private BindingSource bindingSource_14;

	private BindingSource bindingSource_15;

	private ComboBox comboBox_3;

	private Label label_16;

	private TableLayoutPanel tableLayoutPanel_1;

	private Label label_17;

	private ToolStrip toolStrip_1;

	private ToolStripButton uLioUhyvJfQ;

	private ToolStripSplitButton toolStripSplitButton_0;

	private ToolStripMenuItem toolStripMenuItem_0;

	private ToolStripMenuItem toolStripMenuItem_1;

	private ToolStripSeparator toolStripSeparator_1;

	private ToolStripMenuItem toolStripMenuItem_2;

	private ToolStripSeparator toolStripSeparator_2;

	private ToolStripSeparator toolStripSeparator_3;

	private ToolStripButton toolStripButton_4;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_3;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_1;

	private DataGridViewTextBoxColumn HvHoUgxkjqO;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_4;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_5;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_6;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_2;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_3;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_4;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_5;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_6;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_7;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_8;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_9;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_10;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_11;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_12;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_13;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_14;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_15;

	private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_16;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_17;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_18;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_19;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_20;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_21;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_22;

	private ToolStrip toolStrip_2;

	private ToolStripButton toolStripButton_5;
}
