using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Constants;
using ControlsLbr;
using DataSql;
using Documents.Properties;
using FormLbr;
using Passport.Classes;

internal partial class Form38 : FormBase
{
	internal int Year { get; set; }

	[CompilerGenerated]
	internal StateFormCreate method_0()
	{
		return this.stateFormCreate_0;
	}

	[CompilerGenerated]
	internal void method_1(StateFormCreate stateFormCreate_1)
	{
		this.stateFormCreate_0 = stateFormCreate_1;
	}

	[CompilerGenerated]
	internal int method_2()
	{
		return this.int_1;
	}

	[CompilerGenerated]
	internal void method_3(int int_7)
	{
		this.int_1 = int_7;
	}

	[CompilerGenerated]
	internal int method_4()
	{
		return this.int_2;
	}

	[CompilerGenerated]
	internal void method_5(int int_7)
	{
		this.int_2 = int_7;
	}

	[CompilerGenerated]
	internal string method_6()
	{
		return this.string_0;
	}

	[CompilerGenerated]
	internal void method_7(string string_3)
	{
		this.string_0 = string_3;
	}

	internal int IdBus { get; set; }

	internal int IdTransf { get; set; }

	internal string NameTransf { get; set; }

	[DefaultValue(-1)]
	internal int Int32_0 { get; set; }

	[CompilerGenerated]
	internal int method_8()
	{
		return this.int_6;
	}

	[CompilerGenerated]
	internal void method_9(int int_7)
	{
		this.int_6 = int_7;
	}

	internal Form38()
	{
		
		
		this.method_23();
	}

	internal Form38(SQLSettings sqlsettings_0, int int_7, string string_3, int int_8, int int_9)
	{
		
		
		this.method_23();
		this.SqlSettings = sqlsettings_0;
		this.method_1(StateFormCreate.Add);
		this.method_5(int_7);
		this.method_7(string_3);
		this.IdBus = int_8;
		this.IdTransf = int_9;
	}

	internal Form38(SQLSettings sqlsettings_0, int int_7, string string_3, int int_8, int int_9, string string_4, int int_10, int int_11)
	{
		
		
		this.method_23();
		this.SqlSettings = sqlsettings_0;
		this.method_1(StateFormCreate.Edit);
		this.method_5(int_7);
		this.method_7(string_3);
		this.IdBus = int_8;
		this.IdTransf = int_9;
		this.NameTransf = string_4;
		this.Int32_0 = int_10;
		this.method_9(int_11);
	}

	private void method_10()
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
		this.comboBox_2.DataSource = dataTable;
		this.comboBox_2.DisplayMember = "Year";
		this.comboBox_2.ValueMember = "Year";
	}

	private void method_11()
	{
		base.SelectSqlData(this.class255_0, this.class255_0.tR_Classifier, true, string.Format("WHERE ParentKey = ';Measurement;Type;' AND Deleted = ((0)) AND isGroup = ((0))", new object[0]));
	}

	private int spcoGbvjtk7()
	{
		return (from row in this.class255_0.tR_Classifier
		where row.ParentKey == ";Measurement;Type;" && row.Value == 2m
		select row.Id).First<int>();
	}

	private int method_12()
	{
		DataTable dataTable = new DataTable("tUser");
		base.SelectSqlData(dataTable, true, string.Format("where [login] = '{0}'", this.SqlSettings.SqlUserConnect), null, false, 0);
		if (dataTable.Rows.Count != 0 && dataTable.Rows[0]["idWorker"] is int)
		{
			return Convert.ToInt32(dataTable.Rows[0]["idWorker"]);
		}
		return -1;
	}

	private Class255.Class410 method_13()
	{
		if (this.method_0() == StateFormCreate.Add)
		{
			Class255.Class410 @class = this.class255_0.tJ_Measurement.method_5();
			@class.idObjList = this.method_4();
			@class.TypeDoc = this.method_2();
			@class["DateN"] = DBNull.Value;
			@class["TemperatureN"] = DBNull.Value;
			@class.Year = DateTime.Now.Year;
			@class.idWorkerCheck = this.method_12();
			@class.Deleted = false;
			this.class255_0.tJ_Measurement.method_0(@class);
			this.Int32_0 = -1;
			this.bindingSource_2.ResetBindings(false);
			return @class;
		}
		base.SelectSqlData(this.class255_0.tJ_Measurement, true, string.Format("WHERE id = {0} AND Deleted = ((0))", this.Int32_0), new int?(0), true, 0);
		this.bindingSource_2.ResetBindings(false);
		if (this.class255_0.tJ_Measurement.Rows.Count <= 0)
		{
			return null;
		}
		return (Class255.Class410)this.class255_0.tJ_Measurement.Rows[0];
	}

	private Class255.Class318 method_14()
	{
		Class255.Class318 @class = new Class255.Class318();
		@class.TableName = "tJ_MeasAmperageTransf";
		if (this.method_0() == StateFormCreate.Add)
		{
			@class = this.method_15(-1);
		}
		else
		{
			base.SelectSqlData(@class, true, string.Format("WHERE idMeasurement = {0} AND idBus = {1} AND idObjList = {2} AND Deleted = ((0))", this.Int32_0, this.IdBus, this.IdTransf), null, false, 0);
			@class = ((@class.Rows.Count > 0) ? @class : this.method_15(this.Int32_0));
		}
		return @class;
	}

	private Class255.Class318 method_15(int int_7)
	{
		Class255.Class318 @class = new Class255.Class318();
		@class.TableName = "tJ_MeasAmperageTransf";
		Class255.Class424 class2 = @class.method_5();
		class2.IdBus = this.IdBus;
		class2.idObjList = this.IdTransf;
		class2.idMeasurement = int_7;
		class2.Deleted = false;
		@class.method_0(class2);
		return @class;
	}

	private void method_16()
	{
		this.bindingSource_5.RaiseListChangedEvents = true;
		this.bindingSource_5.CurrentChanged -= this.bindingSource_5_CurrentChanged;
		if (this.method_0() == StateFormCreate.Add)
		{
			base.SelectSqlData(this.class255_0, this.class255_0.vJ_BusesTransfSchema, true, string.Format("WHERE idSub = {0}  AND parentKeyBus = ';SCM;BUS;BUSMV;' ORDER By NameTransf", this.method_4()));
		}
		else
		{
			base.SelectSqlData(this.class255_0, this.class255_0.vJ_BusesTransfs, true, string.Format("WHERE idMeasurement = {0} ORDER By Name", this.Int32_0));
			base.SelectSqlData(this.class255_0, this.class255_0.vJ_BusesTransfSchema, true, string.Format("WHERE idSub = {0} AND parentKeyBus = ';SCM;BUS;BUSMV; AND tagBus IS NULL' ORDER By NameTransf", this.method_4()));
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
				idBus = row.idBus,
				NameBus = row.nameBus,
				idTransf = ((row["idTransf"] == DBNull.Value) ? -1 : row.idTransf),
				NameTransf = ((row["nameTransf"] == DBNull.Value) ? "" : row.nameTransf),
				NameBusTransf = row.Name
			}).Union(from row in this.class255_0.vJ_BusesTransfs
			select new
			{
				idBus = row.idBus,
				NameBus = row.nameBus,
				idTransf = ((row["idTransf"] == DBNull.Value) ? -1 : row.idTransf),
				NameTransf = ((row["nameTransf"] == DBNull.Value) ? "" : row.nameTransf),
				NameBusTransf = row.Name
			});
			this.class255_0.vJ_BusesTransfSchema.Rows.Clear();
			foreach (var <>f__AnonymousType in enumerable)
			{
				Class255.Class434 @class = this.class255_0.vJ_BusesTransfSchema.method_4();
				@class.idSub = this.method_4();
				@class.idBus = <>f__AnonymousType.idBus;
				@class.nameBus = <>f__AnonymousType.NameBus;
				@class.idTransf = <>f__AnonymousType.idTransf;
				@class.NameTransf = <>f__AnonymousType.NameTransf;
				@class.nameBusTransf = <>f__AnonymousType.NameBusTransf;
				this.class255_0.vJ_BusesTransfSchema.method_0(@class);
			}
		}
		this.bindingSource_5.ResetBindings(false);
		if (this.bindingSource_5.Count == 0)
		{
			this.bindingSource_5_CurrentChanged(this.bindingSource_5, new EventArgs());
			return;
		}
		int num;
		if (string.IsNullOrEmpty(this.NameTransf))
		{
			num = this.bindingSource_5.Find("idBus", this.IdBus);
		}
		else
		{
			num = this.bindingSource_5.Find("idTransf", this.IdTransf);
			if (num != -1)
			{
				num = this.bindingSource_5.Find("idBus", this.IdBus);
			}
		}
		if (num != -1)
		{
			this.bindingSource_5.Position = num;
		}
		this.bindingSource_5.CurrentChanged += this.bindingSource_5_CurrentChanged;
		this.bindingSource_5.RaiseListChangedEvents = false;
		this.bindingSource_5_CurrentChanged(this.bindingSource_5, new EventArgs());
	}

	private void method_17()
	{
		base.SelectSqlData(this.class255_0, this.class255_0.vP_Worker, true, string.Format("WHERE ParentKey IN (';GroupWorker;Meas;', ';GroupWorker;MeasDispatchers;')  AND DateEnd IS NULL", new object[0]));
		Class255.Class381 @class = this.class255_0.vP_Worker.method_4();
		@class.Id = -1;
		@class.F = "";
		@class.FIO = "";
		@class.ParentKey = "";
		@class.idGroup = 1;
		@class.isGroup = false;
		this.class255_0.vP_Worker.method_0(@class);
	}

	private void Form38_Load(object sender, EventArgs e)
	{
		this.method_10();
		this.method_11();
		this.method_3(this.spcoGbvjtk7());
		this.method_17();
		this.method_16();
		this.class410_0 = this.method_13();
		if (this.method_0() == StateFormCreate.Add)
		{
			this.nullableDateTimePicker_0.Value = null;
		}
		this.Text = ((this.method_0() == StateFormCreate.Add) ? "Добавление замера" : "Редактирование замера");
		this.Text += ((this.method_6().Length > 0) ? (": " + this.method_6()) : "");
		InputCheck.AddBindingNull(this.textBox_1);
		InputCheck.AddBindingNull(this.textBox_2);
		InputCheck.AddBindingNull(this.textBox_0);
	}

	private void Form38_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (base.DialogResult == DialogResult.OK)
		{
			if (this.comboBox_2.SelectedValue == null || (!(this.comboBox_2.SelectedValue is int) && int.Parse(this.comboBox_2.SelectedValue.ToString()) < 1900))
			{
				MessageBox.Show("Поле \"Период\" не заполнено.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				e.Cancel = true;
				return;
			}
			if (this.numericUpDown_0.Value == 0m)
			{
				this.class255_0.tJ_Measurement.First<Class255.Class410>().TemperatureD = 0;
				this.class255_0.tJ_Measurement.First<Class255.Class410>().EndEdit();
			}
			if (this.nullableDateTimePicker_0.Value == null)
			{
				MessageBox.Show("Поле \"Дата/Время\" не заполнено.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				e.Cancel = true;
				return;
			}
			if (this.comboBox_0.SelectedValue == null || (!(this.comboBox_0.SelectedValue is int) && int.Parse(this.comboBox_0.SelectedValue.ToString()) < 1))
			{
				MessageBox.Show("Поле \"Замеры проводил\" не заполнено.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				e.Cancel = true;
				return;
			}
			if (this.bindingSource_5.Current == null)
			{
				MessageBox.Show("Поле \"Секция шин\" не заполнено.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				e.Cancel = true;
				return;
			}
			if (string.IsNullOrEmpty(this.textBox_1.Text))
			{
				MessageBox.Show("Поле \"Ток нагрузки А\" не заполнено.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				e.Cancel = true;
				return;
			}
			if (string.IsNullOrEmpty(this.textBox_2.Text))
			{
				MessageBox.Show("Поле \"Ток нагрузки В\" не заполнено.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				e.Cancel = true;
				return;
			}
			if (string.IsNullOrEmpty(this.textBox_0.Text))
			{
				MessageBox.Show("Поле \"Ток нагрузки С\" не заполнено.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				e.Cancel = true;
				return;
			}
			if (!this.method_18())
			{
				e.Cancel = true;
			}
		}
	}

	private bool method_18()
	{
		if (this.comboBox_1.SelectedValue == null || !(this.comboBox_1.SelectedValue is int) || this.class255_0.tJ_Measurement.Rows.Count <= 0)
		{
			return false;
		}
		foreach (Class255.Class410 @class in this.class255_0.tJ_Measurement)
		{
			@class.EndEdit();
		}
		if (this.method_0() == StateFormCreate.Add)
		{
			this.Int32_0 = base.InsertSqlDataOneRow(this.class255_0, this.class255_0.tJ_Measurement);
		}
		if (this.method_0() == StateFormCreate.Edit)
		{
			this.bindingSource_2.EndEdit();
			base.UpdateSqlData(this.class255_0, this.class255_0.tJ_Measurement);
		}
		if (this.Int32_0 == -1)
		{
			return false;
		}
		foreach (KeyValuePair<string, Class255.Class318> keyValuePair in this.class124_0)
		{
			if (Class125.smethod_0(this.class124_0[keyValuePair.Key]) || Class125.smethod_0(this.class123_0[keyValuePair.Key]) || this.method_0() == StateFormCreate.Edit)
			{
				foreach (Class255.Class424 class2 in this.class124_0[keyValuePair.Key])
				{
					class2.idMeasurement = this.Int32_0;
					class2.EndEdit();
				}
				base.InsertSqlData(this.class124_0[keyValuePair.Key]);
				base.UpdateSqlData(this.class124_0[keyValuePair.Key]);
				base.DeleteSqlData(this.class124_0[keyValuePair.Key]);
				foreach (Class255.Class439 class3 in this.class123_0[keyValuePair.Key])
				{
					class3.idMeasurement = this.Int32_0;
					class3.EndEdit();
				}
				base.InsertSqlData(this.class123_0[keyValuePair.Key]);
				base.UpdateSqlData(this.class123_0[keyValuePair.Key]);
				base.DeleteSqlData(this.class123_0[keyValuePair.Key]);
			}
		}
		MessageBox.Show("Данные успешно внесены.");
		return true;
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.OK;
		base.Close();
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		base.Close();
	}

	private void bindingSource_5_CurrentChanged(object sender, EventArgs e)
	{
		if (this.bindingSource_5.Current != null)
		{
			this.IdTransf = ((this.bindingSource_5.Current == null || !(((DataRowView)this.bindingSource_5.Current)["IdTransf"] is int)) ? -1 : ((int)((DataRowView)this.bindingSource_5.Current)["IdTransf"]));
			this.IdBus = ((this.bindingSource_5.Current == null || !(((DataRowView)this.bindingSource_5.Current)["IdBus"] is int)) ? -1 : ((int)((DataRowView)this.bindingSource_5.Current)["IdBus"]));
			this.string_2 = string.Format("{0}+{1}", this.IdBus, this.IdTransf);
			if (this.list_0 == null)
			{
				this.list_0 = new List<string>();
			}
			if (!this.list_0.Contains(this.string_2))
			{
				this.list_0.Add(this.string_2);
			}
			if (this.class122_0 == null)
			{
				this.class122_0 = new Class122();
			}
			if (this.class123_0 == null)
			{
				this.class123_0 = new Class123();
			}
			if (this.class124_0 == null)
			{
				this.class124_0 = new Class124();
			}
			if (!this.class124_0.ContainsKey(this.string_2))
			{
				this.class124_0.Add(this.string_2, this.method_14());
			}
			if (!this.class122_0.ContainsKey(this.string_2))
			{
				Class255.Class303 @class = new Class255.Class303();
				base.SelectSqlData(this.class255_0, this.class255_0.vJ_CellByBus, true, string.Format("WHERE idBus = {0} AND idParent = {1}", this.IdBus, this.method_4()));
				string text = string.Join(",", (from i in this.class255_0.vJ_CellByBus
				select i.id.ToString()).ToArray<string>());
				if (!string.IsNullOrEmpty(text))
				{
					base.SelectSqlData(this.class255_0, this.class255_0.vJ_TransfByCell, true, string.Format("WHERE idCell IN ({0})", text));
					foreach (var <>f__AnonymousType in from c in this.class255_0.vJ_CellByBus.Where(new Func<Class255.Class432, bool>(this.method_24))
					select new
					{
						idBus = ((c["idBus"] != null) ? ((int)c["idBus"]) : -1),
						NameBus = ((c["NameBus"] != null) ? c["NameBus"].ToString() : ""),
						idCell = ((c["id"] != null) ? ((int)c["id"]) : -1),
						NameCell = ((c["Name"] != null) ? c["Name"].ToString() : "")
					})
					{
						@class.method_1(<>f__AnonymousType.idCell, <>f__AnonymousType.NameCell);
					}
					this.class122_0.Add(this.string_2, @class);
				}
			}
			if (!this.class123_0.ContainsKey(this.string_2))
			{
				Class255.Class333 class2 = new Class255.Class333();
				class2.TableName = "tJ_MeasCell";
				if (this.method_0() == StateFormCreate.Edit)
				{
					base.SelectSqlData(class2, true, string.Format("WHERE idMeasurement = {0} AND idBus = {1} AND idTransf = {2} AND Deleted = ((0))", this.Int32_0, this.IdBus, this.IdTransf), null, false, 0);
					if (class2.Rows.Count == 0)
					{
						class2 = this.method_19();
					}
				}
				else
				{
					class2 = this.method_19();
				}
				this.class123_0.Add(this.string_2, class2);
			}
			if ((from item in this.class124_0.Where(new Func<KeyValuePair<string, Class255.Class318>, bool>(this.method_25))
			select item.Value).First<Class255.Class318>().First<Class255.Class424>().idObjList != -1)
			{
				base.CallSQLTableValuedFunction(this.class255_0, this.class255_0.fn_J_MeasTransfPassport, "", new string[]
				{
					this.IdTransf.ToString()
				});
				this.method_20(this.IdTransf, (this.class255_0.fn_J_MeasTransfPassport.Rows.Count > 0) ? this.class255_0.fn_J_MeasTransfPassport.Rows[0]["InvNumber"].ToString() : "");
			}
			else
			{
				this.method_20(-1, "");
			}
			if (this.class124_0.ContainsKey(this.string_2))
			{
				foreach (Class255.Class424 class3 in this.class124_0[this.string_2])
				{
					class3.EndEdit();
				}
				this.bindingSource_1.DataSource = this.class124_0[this.string_2];
				this.bindingSource_1.ResetBindings(false);
			}
			if (this.class122_0.ContainsKey(this.string_2))
			{
				this.bindingSource_6.DataSource = this.class122_0[this.string_2];
				this.bindingSource_6.ResetBindings(false);
			}
			if (this.class123_0.ContainsKey(this.string_2))
			{
				foreach (Class255.Class439 class4 in this.class123_0[this.string_2])
				{
					class4.EndEdit();
				}
				this.bindingSource_4.DataSource = this.class123_0[this.string_2];
				this.bindingSource_4.ResetBindings(false);
				return;
			}
		}
		else
		{
			this.class255_0.fn_J_MeasTransfPassport.Clear();
		}
	}

	private Class255.Class333 method_19()
	{
		Class255.Class333 @class = new Class255.Class333();
		@class.TableName = "tJ_MeasCell";
		foreach (var <>f__AnonymousType in from c in this.class255_0.vJ_CellByBus.Where(new Func<Class255.Class432, bool>(this.method_26))
		select new
		{
			idBus = ((c["idBus"] != null) ? ((int)c["idBus"]) : -1),
			NameBus = ((c["NameBus"] != null) ? c["NameBus"].ToString() : ""),
			idCell = ((c["id"] != null) ? ((int)c["id"]) : -1),
			NameCell = ((c["Name"] != null) ? c["Name"].ToString() : "")
		})
		{
			Class255.Class439 class2 = @class.method_5();
			class2.Deleted = false;
			class2.idBus = this.IdBus;
			class2.idTransf = this.IdTransf;
			class2.idCell = <>f__AnonymousType.idCell;
			class2.idMeasurement = this.Int32_0;
			@class.method_0(class2);
		}
		return @class;
	}

	private void method_20(int int_7, string string_3)
	{
		this.label_9.Text = "Заводской № " + string_3;
		if (int_7 != -1)
		{
			this.method_21(int_7);
			return;
		}
		this.class255_0.fn_J_MeasTransfPassport.Clear();
	}

	private void method_21(int int_7)
	{
		this.class255_0.fn_J_MeasTransfPassport.Rows.Clear();
		base.CallSQLTableValuedFunction(this.class255_0, this.class255_0.fn_J_MeasTransfPassport, "", new string[]
		{
			int_7.ToString()
		});
	}

	private void comboBox_2_SelectedValueChanged(object sender, EventArgs e)
	{
		if (this.comboBox_2.SelectedValue != null && this.comboBox_2.SelectedValue is int)
		{
			this.Year = (int)this.comboBox_2.SelectedValue;
		}
	}

	private void toolStripButton_0_Click(object sender, EventArgs e)
	{
	}

	private void toolStripButton_1_Click(object sender, EventArgs e)
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

	private void dataGridView_0_CellEndEdit(object sender, DataGridViewCellEventArgs e)
	{
		if (this.dataGridView_0.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Length == 0)
		{
			this.dataGridView_0.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = DBNull.Value;
		}
	}

	private void dataGridView_0_DataError(object sender, DataGridViewDataErrorEventArgs e)
	{
	}

	private void button_2_Click(object sender, EventArgs e)
	{
		if (MessageBox.Show("Вы действительно хотите удалить замеры на выбранную шину?", "Удаление.", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
		{
			if (this.method_0() == StateFormCreate.Add)
			{
				this.class124_0.Remove(this.string_2);
				this.class123_0.Remove(this.string_2);
			}
			else
			{
				for (int i = this.class124_0[this.string_2].Rows.Count - 1; i >= 0; i--)
				{
					this.class124_0[this.string_2].Rows[i]["Deleted"] = true;
				}
				for (int j = this.class123_0[this.string_2].Rows.Count - 1; j >= 0; j--)
				{
					this.class123_0[this.string_2].Rows[j]["Deleted"] = true;
				}
			}
			this.class255_0.vJ_BusesTransfSchema.Where(new Func<Class255.Class434, bool>(this.method_27)).First<Class255.Class434>().Delete();
		}
	}

	private void tableLayoutPanel_0_Paint(object sender, PaintEventArgs e)
	{
	}

	private void toolStripButton_2_Click(object sender, EventArgs e)
	{
		this.method_22();
	}

	private void method_22()
	{
		if (this.nullableDateTimePicker_0.Value == null)
		{
			MessageBox.Show("Не указана дата");
			return;
		}
		DataSet dataSet = new DataSet();
		DataTable dataTable = new DataTable("tj_temperature");
		dataTable.Columns.Add("NightDown", typeof(int));
		dataTable.Columns.Add("DayDown", typeof(int));
		dataSet.Tables.Add(dataTable);
		if (this.nullableDateTimePicker_0.Value != null)
		{
			base.SelectSqlData(dataTable, true, "where dateTemp = '" + Convert.ToDateTime(this.nullableDateTimePicker_0.Value).ToString("yyyyMMdd") + "'", null, false, 0);
			if (dataTable.Rows.Count > 0 && dataTable.Rows[0]["DayDown"] != DBNull.Value)
			{
				this.numericUpDown_0.Value = Convert.ToInt32(dataTable.Rows[0]["DayDown"]);
			}
		}
	}

	private void nullableDateTimePicker_0_ValueChanged(object sender, EventArgs e)
	{
		if (this.nullableDateTimePicker_0.Value != null)
		{
			this.method_22();
		}
	}

	private void method_23()
	{
		this.icontainer_0 = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form38));
		this.tableLayoutPanel_0 = new TableLayoutPanel();
		this.label_10 = new Label();
		this.comboBox_3 = new ComboBox();
		this.bindingSource_2 = new BindingSource(this.icontainer_0);
		this.class255_0 = new Class255();
		this.bindingSource_7 = new BindingSource(this.icontainer_0);
		this.label_9 = new Label();
		this.dataGridView_0 = new DataGridView();
		this.dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
		this.dataGridViewComboBoxColumn_0 = new DataGridViewComboBoxColumn();
		this.bindingSource_6 = new BindingSource(this.icontainer_0);
		this.dataGridViewTextBoxColumn_3 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_4 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_5 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_6 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_7 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_8 = new DataGridViewTextBoxColumn();
		this.uhloDtYvOvm = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_9 = new DataGridViewTextBoxColumn();
		this.dataGridViewCheckBoxColumn_0 = new DataGridViewCheckBoxColumn();
		this.bindingSource_4 = new BindingSource(this.icontainer_0);
		this.comboBox_2 = new ComboBox();
		this.label_8 = new Label();
		this.nullableDateTimePicker_0 = new NullableDateTimePicker();
		this.comboBox_0 = new ComboBox();
		this.bindingSource_3 = new BindingSource(this.icontainer_0);
		this.label_5 = new Label();
		this.comboBox_1 = new ComboBox();
		this.bindingSource_5 = new BindingSource(this.icontainer_0);
		this.label_6 = new Label();
		this.label_0 = new Label();
		this.label_7 = new Label();
		this.label_1 = new Label();
		this.label_3 = new Label();
		this.numericUpDown_0 = new NumericUpDown();
		this.label_4 = new Label();
		this.textBox_2 = new TextBox();
		this.bindingSource_1 = new BindingSource(this.icontainer_0);
		this.textBox_0 = new TextBox();
		this.textBox_1 = new TextBox();
		this.tableLayoutPanel_1 = new TableLayoutPanel();
		this.button_0 = new Button();
		this.button_1 = new Button();
		this.toolStrip_0 = new ToolStrip();
		this.toolStripButton_0 = new ToolStripButton();
		this.toolStripButton_1 = new ToolStripButton();
		this.button_2 = new Button();
		this.label_2 = new Label();
		this.toolStrip_1 = new ToolStrip();
		this.toolStripButton_2 = new ToolStripButton();
		this.bindingSource_0 = new BindingSource(this.icontainer_0);
		this.tableLayoutPanel_0.SuspendLayout();
		((ISupportInitialize)this.bindingSource_2).BeginInit();
		((ISupportInitialize)this.class255_0).BeginInit();
		((ISupportInitialize)this.bindingSource_7).BeginInit();
		((ISupportInitialize)this.dataGridView_0).BeginInit();
		((ISupportInitialize)this.bindingSource_6).BeginInit();
		((ISupportInitialize)this.bindingSource_4).BeginInit();
		((ISupportInitialize)this.bindingSource_3).BeginInit();
		((ISupportInitialize)this.bindingSource_5).BeginInit();
		((ISupportInitialize)this.numericUpDown_0).BeginInit();
		((ISupportInitialize)this.bindingSource_1).BeginInit();
		this.tableLayoutPanel_1.SuspendLayout();
		this.toolStrip_0.SuspendLayout();
		this.toolStrip_1.SuspendLayout();
		((ISupportInitialize)this.bindingSource_0).BeginInit();
		base.SuspendLayout();
		this.tableLayoutPanel_0.ColumnCount = 14;
		this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 17f));
		this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 102f));
		this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 22f));
		this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120f));
		this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 25f));
		this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 27f));
		this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 102f));
		this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20f));
		this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 27f));
		this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 137f));
		this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 9f));
		this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 78f));
		this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 85f));
		this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20f));
		this.tableLayoutPanel_0.Controls.Add(this.label_10, 11, 2);
		this.tableLayoutPanel_0.Controls.Add(this.comboBox_3, 12, 2);
		this.tableLayoutPanel_0.Controls.Add(this.label_9, 6, 3);
		this.tableLayoutPanel_0.Controls.Add(this.dataGridView_0, 0, 7);
		this.tableLayoutPanel_0.Controls.Add(this.comboBox_2, 3, 1);
		this.tableLayoutPanel_0.Controls.Add(this.label_8, 1, 1);
		this.tableLayoutPanel_0.Controls.Add(this.nullableDateTimePicker_0, 3, 2);
		this.tableLayoutPanel_0.Controls.Add(this.comboBox_0, 9, 2);
		this.tableLayoutPanel_0.Controls.Add(this.label_5, 8, 4);
		this.tableLayoutPanel_0.Controls.Add(this.comboBox_1, 3, 3);
		this.tableLayoutPanel_0.Controls.Add(this.label_6, 4, 4);
		this.tableLayoutPanel_0.Controls.Add(this.label_0, 1, 3);
		this.tableLayoutPanel_0.Controls.Add(this.label_7, 2, 4);
		this.tableLayoutPanel_0.Controls.Add(this.label_1, 6, 2);
		this.tableLayoutPanel_0.Controls.Add(this.label_3, 1, 2);
		this.tableLayoutPanel_0.Controls.Add(this.numericUpDown_0, 9, 1);
		this.tableLayoutPanel_0.Controls.Add(this.label_4, 1, 4);
		this.tableLayoutPanel_0.Controls.Add(this.textBox_2, 5, 4);
		this.tableLayoutPanel_0.Controls.Add(this.textBox_0, 9, 4);
		this.tableLayoutPanel_0.Controls.Add(this.textBox_1, 3, 4);
		this.tableLayoutPanel_0.Controls.Add(this.tableLayoutPanel_1, 0, 8);
		this.tableLayoutPanel_0.Controls.Add(this.toolStrip_0, 0, 6);
		this.tableLayoutPanel_0.Controls.Add(this.button_2, 4, 3);
		this.tableLayoutPanel_0.Controls.Add(this.label_2, 6, 1);
		this.tableLayoutPanel_0.Controls.Add(this.toolStrip_1, 7, 1);
		this.tableLayoutPanel_0.Dock = DockStyle.Fill;
		this.tableLayoutPanel_0.Location = new Point(0, 0);
		this.tableLayoutPanel_0.Name = "tableLayoutPanel1";
		this.tableLayoutPanel_0.RowCount = 9;
		this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Absolute, 13f));
		this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Absolute, 25f));
		this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Absolute, 25f));
		this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Absolute, 25f));
		this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Absolute, 25f));
		this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Absolute, 9f));
		this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Absolute, 24f));
		this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Absolute, 40f));
		this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
		this.tableLayoutPanel_0.Size = new Size(906, 377);
		this.tableLayoutPanel_0.TabIndex = 1;
		this.tableLayoutPanel_0.Paint += this.tableLayoutPanel_0_Paint;
		this.label_10.AutoSize = true;
		this.label_10.Dock = DockStyle.Fill;
		this.label_10.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.label_10.Location = new Point(611, 38);
		this.label_10.Name = "label1";
		this.label_10.Size = new Size(72, 25);
		this.label_10.TabIndex = 37;
		this.label_10.Text = "Диспетчер:";
		this.label_10.TextAlign = ContentAlignment.MiddleLeft;
		this.comboBox_3.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBox_3.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.tableLayoutPanel_0.SetColumnSpan(this.comboBox_3, 2);
		this.comboBox_3.DataBindings.Add(new Binding("SelectedValue", this.bindingSource_2, "idWorkerCheck", true));
		this.comboBox_3.DataSource = this.bindingSource_7;
		this.comboBox_3.DisplayMember = "FIO";
		this.comboBox_3.Dock = DockStyle.Left;
		this.comboBox_3.FormattingEnabled = true;
		this.comboBox_3.Location = new Point(689, 41);
		this.comboBox_3.Name = "cbDispatcher";
		this.comboBox_3.Size = new Size(138, 21);
		this.comboBox_3.TabIndex = 36;
		this.comboBox_3.ValueMember = "Id";
		this.bindingSource_2.DataMember = "tJ_Measurement";
		this.bindingSource_2.DataSource = this.class255_0;
		this.class255_0.DataSetName = "DataSetGES";
		this.class255_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		this.bindingSource_7.DataMember = "vP_Worker";
		this.bindingSource_7.DataSource = this.class255_0;
		this.bindingSource_7.Filter = "ParentKey = ';GroupWorker;MeasDispatchers;' OR ParentKey = ''";
		this.bindingSource_7.Sort = "FIO";
		this.label_9.AutoSize = true;
		this.tableLayoutPanel_0.SetColumnSpan(this.label_9, 5);
		this.label_9.Dock = DockStyle.Left;
		this.label_9.Location = new Point(316, 63);
		this.label_9.Name = "lbSerialNumber";
		this.label_9.Size = new Size(79, 25);
		this.label_9.TabIndex = 33;
		this.label_9.Text = "Заводской № ";
		this.label_9.TextAlign = ContentAlignment.MiddleLeft;
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
			this.dataGridViewTextBoxColumn_0,
			this.dataGridViewTextBoxColumn_1,
			this.dataGridViewTextBoxColumn_2,
			this.dataGridViewComboBoxColumn_0,
			this.dataGridViewTextBoxColumn_3,
			this.dataGridViewTextBoxColumn_4,
			this.dataGridViewTextBoxColumn_5,
			this.dataGridViewTextBoxColumn_6,
			this.dataGridViewTextBoxColumn_7,
			this.dataGridViewTextBoxColumn_8,
			this.uhloDtYvOvm,
			this.dataGridViewTextBoxColumn_9,
			this.dataGridViewCheckBoxColumn_0
		});
		this.tableLayoutPanel_0.SetColumnSpan(this.dataGridView_0, 14);
		this.dataGridView_0.DataSource = this.bindingSource_4;
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
		this.dataGridView_0.Location = new Point(3, 149);
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
		this.dataGridView_0.Size = new Size(900, 185);
		this.dataGridView_0.TabIndex = 31;
		this.dataGridView_0.CellEndEdit += this.dataGridView_0_CellEndEdit;
		this.dataGridView_0.DataError += this.dataGridView_0_DataError;
		this.dataGridViewTextBoxColumn_0.DataPropertyName = "id";
		this.dataGridViewTextBoxColumn_0.HeaderText = "id";
		this.dataGridViewTextBoxColumn_0.Name = "idDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_0.ReadOnly = true;
		this.dataGridViewTextBoxColumn_0.Visible = false;
		this.dataGridViewTextBoxColumn_1.DataPropertyName = "idMeasurement";
		this.dataGridViewTextBoxColumn_1.HeaderText = "idMeasurement";
		this.dataGridViewTextBoxColumn_1.Name = "idMeasurementDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_1.Visible = false;
		this.dataGridViewTextBoxColumn_2.DataPropertyName = "idBus";
		this.dataGridViewTextBoxColumn_2.HeaderText = "idBus";
		this.dataGridViewTextBoxColumn_2.Name = "idBusDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_2.Visible = false;
		this.dataGridViewComboBoxColumn_0.DataPropertyName = "idCell";
		this.dataGridViewComboBoxColumn_0.DataSource = this.bindingSource_6;
		this.dataGridViewComboBoxColumn_0.DisplayMember = "Name";
		this.dataGridViewComboBoxColumn_0.FlatStyle = FlatStyle.Popup;
		this.dataGridViewComboBoxColumn_0.HeaderText = "№ руб.";
		this.dataGridViewComboBoxColumn_0.Name = "idCellDataGridViewTextBoxColumn";
		this.dataGridViewComboBoxColumn_0.Resizable = DataGridViewTriState.True;
		this.dataGridViewComboBoxColumn_0.SortMode = DataGridViewColumnSortMode.Automatic;
		this.dataGridViewComboBoxColumn_0.ValueMember = "id";
		this.dataGridViewComboBoxColumn_0.Width = 50;
		this.bindingSource_6.DataMember = "dtCells";
		this.bindingSource_6.DataSource = this.class255_0;
		this.dataGridViewTextBoxColumn_3.DataPropertyName = "PermissAmperage";
		this.dataGridViewTextBoxColumn_3.HeaderText = "Допуст. нагр., А";
		this.dataGridViewTextBoxColumn_3.Name = "permissAmperageDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_3.Width = 80;
		this.dataGridViewTextBoxColumn_4.DataPropertyName = "Iad";
		this.dataGridViewTextBoxColumn_4.HeaderText = "А дн.";
		this.dataGridViewTextBoxColumn_4.Name = "iadDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_4.Width = 60;
		this.dataGridViewTextBoxColumn_5.DataPropertyName = "Ian";
		this.dataGridViewTextBoxColumn_5.HeaderText = "А вч.";
		this.dataGridViewTextBoxColumn_5.Name = "ianDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_5.Width = 60;
		this.dataGridViewTextBoxColumn_6.DataPropertyName = "Ibd";
		this.dataGridViewTextBoxColumn_6.HeaderText = "В дн.";
		this.dataGridViewTextBoxColumn_6.Name = "ibdDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_6.Width = 60;
		this.dataGridViewTextBoxColumn_7.DataPropertyName = "Ibn";
		this.dataGridViewTextBoxColumn_7.HeaderText = "В вч.";
		this.dataGridViewTextBoxColumn_7.Name = "ibnDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_7.Width = 60;
		this.dataGridViewTextBoxColumn_8.DataPropertyName = "Icd";
		this.dataGridViewTextBoxColumn_8.HeaderText = "С дн.";
		this.dataGridViewTextBoxColumn_8.Name = "icdDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_8.Width = 60;
		this.uhloDtYvOvm.DataPropertyName = "Icn";
		this.uhloDtYvOvm.HeaderText = "С вч.";
		this.uhloDtYvOvm.Name = "icnDataGridViewTextBoxColumn";
		this.uhloDtYvOvm.Width = 60;
		this.dataGridViewTextBoxColumn_9.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_9.DataPropertyName = "Comment";
		this.dataGridViewTextBoxColumn_9.HeaderText = "Комментарий";
		this.dataGridViewTextBoxColumn_9.Name = "commentDataGridViewTextBoxColumn";
		this.dataGridViewCheckBoxColumn_0.DataPropertyName = "Deleted";
		this.dataGridViewCheckBoxColumn_0.HeaderText = "Deleted";
		this.dataGridViewCheckBoxColumn_0.Name = "deletedDataGridViewCheckBoxColumn";
		this.dataGridViewCheckBoxColumn_0.Visible = false;
		this.bindingSource_4.DataMember = "tJ_MeasCell";
		this.bindingSource_4.DataSource = this.class255_0;
		this.comboBox_2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBox_2.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBox_2.DataBindings.Add(new Binding("SelectedValue", this.bindingSource_2, "Year", true));
		this.comboBox_2.DisplayMember = "Id";
		this.comboBox_2.Dock = DockStyle.Fill;
		this.comboBox_2.FormattingEnabled = true;
		this.comboBox_2.Location = new Point(144, 16);
		this.comboBox_2.Name = "cbYear";
		this.comboBox_2.Size = new Size(114, 21);
		this.comboBox_2.TabIndex = 30;
		this.comboBox_2.ValueMember = "Id";
		this.comboBox_2.SelectedValueChanged += this.comboBox_2_SelectedValueChanged;
		this.label_8.AutoSize = true;
		this.tableLayoutPanel_0.SetColumnSpan(this.label_8, 2);
		this.label_8.Dock = DockStyle.Fill;
		this.label_8.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.label_8.Location = new Point(20, 13);
		this.label_8.Name = "label2";
		this.label_8.Size = new Size(118, 25);
		this.label_8.TabIndex = 29;
		this.label_8.Text = "Период:";
		this.label_8.TextAlign = ContentAlignment.MiddleLeft;
		this.tableLayoutPanel_0.SetColumnSpan(this.nullableDateTimePicker_0, 3);
		this.nullableDateTimePicker_0.CustomFormat = "ddMMMMyyyy г. HH:mm";
		this.nullableDateTimePicker_0.DataBindings.Add(new Binding("Value", this.bindingSource_2, "DateD", true));
		this.nullableDateTimePicker_0.Dock = DockStyle.Left;
		this.nullableDateTimePicker_0.Format = DateTimePickerFormat.Custom;
		this.nullableDateTimePicker_0.Location = new Point(144, 41);
		this.nullableDateTimePicker_0.Name = "dtpDateD";
		this.nullableDateTimePicker_0.Size = new Size(163, 20);
		this.nullableDateTimePicker_0.TabIndex = 4;
		this.nullableDateTimePicker_0.Value = new DateTime(2013, 8, 29, 10, 49, 16, 759);
		this.nullableDateTimePicker_0.ValueChanged += this.nullableDateTimePicker_0_ValueChanged;
		this.comboBox_0.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBox_0.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBox_0.DataBindings.Add(new Binding("SelectedValue", this.bindingSource_2, "idWorker", true));
		this.comboBox_0.DataSource = this.bindingSource_3;
		this.comboBox_0.DisplayMember = "FIO";
		this.comboBox_0.Dock = DockStyle.Fill;
		this.comboBox_0.FormattingEnabled = true;
		this.comboBox_0.Location = new Point(465, 41);
		this.comboBox_0.Name = "cbWorker";
		this.comboBox_0.Size = new Size(131, 21);
		this.comboBox_0.TabIndex = 3;
		this.comboBox_0.ValueMember = "Id";
		this.bindingSource_3.DataMember = "vP_Worker";
		this.bindingSource_3.DataSource = this.class255_0;
		this.bindingSource_3.Filter = "ParentKey = ';GroupWorker;Meas;' OR ParentKey = ''";
		this.bindingSource_3.Sort = "FIO";
		this.label_5.AutoSize = true;
		this.label_5.Dock = DockStyle.Fill;
		this.label_5.Location = new Point(438, 88);
		this.label_5.Name = "label21";
		this.label_5.Size = new Size(21, 25);
		this.label_5.TabIndex = 22;
		this.label_5.Text = "С";
		this.label_5.TextAlign = ContentAlignment.MiddleLeft;
		this.comboBox_1.DataSource = this.bindingSource_5;
		this.comboBox_1.DisplayMember = "nameBusTransf";
		this.comboBox_1.Dock = DockStyle.Fill;
		this.comboBox_1.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_1.FormattingEnabled = true;
		this.comboBox_1.Location = new Point(144, 66);
		this.comboBox_1.Name = "cbBuses";
		this.comboBox_1.Size = new Size(114, 21);
		this.comboBox_1.TabIndex = 12;
		this.comboBox_1.ValueMember = "idBus";
		this.bindingSource_5.DataMember = "vJ_BusesTransfSchema";
		this.bindingSource_5.DataSource = this.class255_0;
		this.bindingSource_5.CurrentChanged += this.bindingSource_5_CurrentChanged;
		this.label_6.AutoSize = true;
		this.label_6.Dock = DockStyle.Fill;
		this.label_6.Location = new Point(264, 88);
		this.label_6.Name = "label20";
		this.label_6.Size = new Size(19, 25);
		this.label_6.TabIndex = 24;
		this.label_6.Text = "В";
		this.label_6.TextAlign = ContentAlignment.MiddleLeft;
		this.label_0.BorderStyle = BorderStyle.FixedSingle;
		this.tableLayoutPanel_0.SetColumnSpan(this.label_0, 2);
		this.label_0.Dock = DockStyle.Fill;
		this.label_0.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.label_0.Location = new Point(20, 63);
		this.label_0.Name = "lbBuses";
		this.label_0.Size = new Size(118, 25);
		this.label_0.TabIndex = 11;
		this.label_0.Text = "Секция шин (тр-р) №";
		this.label_0.TextAlign = ContentAlignment.MiddleLeft;
		this.label_7.AutoSize = true;
		this.label_7.Dock = DockStyle.Fill;
		this.label_7.Location = new Point(122, 88);
		this.label_7.Name = "label17";
		this.label_7.Size = new Size(16, 25);
		this.label_7.TabIndex = 19;
		this.label_7.Text = "А";
		this.label_7.TextAlign = ContentAlignment.MiddleLeft;
		this.label_1.AutoSize = true;
		this.tableLayoutPanel_0.SetColumnSpan(this.label_1, 3);
		this.label_1.Dock = DockStyle.Fill;
		this.label_1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.label_1.Location = new Point(316, 38);
		this.label_1.Name = "label7";
		this.label_1.Size = new Size(143, 25);
		this.label_1.TabIndex = 0;
		this.label_1.Text = "Замеры проводил:";
		this.label_1.TextAlign = ContentAlignment.MiddleLeft;
		this.label_3.AutoSize = true;
		this.tableLayoutPanel_0.SetColumnSpan(this.label_3, 2);
		this.label_3.Dock = DockStyle.Fill;
		this.label_3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.label_3.Location = new Point(20, 38);
		this.label_3.Name = "label3";
		this.label_3.Size = new Size(118, 25);
		this.label_3.TabIndex = 0;
		this.label_3.Text = "Дата/Время:";
		this.label_3.TextAlign = ContentAlignment.MiddleLeft;
		this.numericUpDown_0.DataBindings.Add(new Binding("Value", this.bindingSource_2, "TemperatureD", true));
		this.numericUpDown_0.Dock = DockStyle.Left;
		this.numericUpDown_0.Location = new Point(465, 16);
		this.numericUpDown_0.Minimum = new decimal(new int[]
		{
			100,
			0,
			0,
			int.MinValue
		});
		this.numericUpDown_0.Name = "nudTemperatureD";
		this.numericUpDown_0.Size = new Size(48, 20);
		this.numericUpDown_0.TabIndex = 2;
		this.label_4.AutoSize = true;
		this.label_4.Dock = DockStyle.Fill;
		this.label_4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.label_4.Location = new Point(20, 88);
		this.label_4.Name = "label13";
		this.label_4.Size = new Size(96, 25);
		this.label_4.TabIndex = 25;
		this.label_4.Text = "Ток нагрузки";
		this.label_4.TextAlign = ContentAlignment.MiddleLeft;
		this.tableLayoutPanel_0.SetColumnSpan(this.textBox_2, 2);
		this.textBox_2.DataBindings.Add(new Binding("Text", this.bindingSource_1, "Ib", true));
		this.textBox_2.Dock = DockStyle.Fill;
		this.textBox_2.Location = new Point(289, 91);
		this.textBox_2.Name = "tbUbcd";
		this.textBox_2.Size = new Size(123, 20);
		this.textBox_2.TabIndex = 11;
		this.bindingSource_1.DataMember = "tJ_MeasAmperageTransf";
		this.bindingSource_1.DataSource = this.class255_0;
		this.textBox_0.DataBindings.Add(new Binding("Text", this.bindingSource_1, "Ic", true));
		this.textBox_0.Dock = DockStyle.Fill;
		this.textBox_0.Location = new Point(465, 91);
		this.textBox_0.Name = "tbUcad";
		this.textBox_0.Size = new Size(131, 20);
		this.textBox_0.TabIndex = 7;
		this.textBox_1.DataBindings.Add(new Binding("Text", this.bindingSource_1, "Ia", true));
		this.textBox_1.Dock = DockStyle.Fill;
		this.textBox_1.Location = new Point(144, 91);
		this.textBox_1.Name = "tbUaod";
		this.textBox_1.Size = new Size(114, 20);
		this.textBox_1.TabIndex = 12;
		this.tableLayoutPanel_1.ColumnCount = 3;
		this.tableLayoutPanel_0.SetColumnSpan(this.tableLayoutPanel_1, 14);
		this.tableLayoutPanel_1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
		this.tableLayoutPanel_1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 133f));
		this.tableLayoutPanel_1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 98f));
		this.tableLayoutPanel_1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20f));
		this.tableLayoutPanel_1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20f));
		this.tableLayoutPanel_1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20f));
		this.tableLayoutPanel_1.Controls.Add(this.button_0, 1, 0);
		this.tableLayoutPanel_1.Controls.Add(this.button_1, 2, 0);
		this.tableLayoutPanel_1.Dock = DockStyle.Fill;
		this.tableLayoutPanel_1.Location = new Point(3, 340);
		this.tableLayoutPanel_1.Name = "tableLayoutPanel2";
		this.tableLayoutPanel_1.RowCount = 1;
		this.tableLayoutPanel_1.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
		this.tableLayoutPanel_1.Size = new Size(900, 34);
		this.tableLayoutPanel_1.TabIndex = 28;
		this.button_0.DialogResult = DialogResult.OK;
		this.button_0.Dock = DockStyle.Right;
		this.button_0.Location = new Point(693, 6);
		this.button_0.Margin = new Padding(3, 6, 10, 6);
		this.button_0.Name = "btnAccept";
		this.button_0.Size = new Size(99, 22);
		this.button_0.TabIndex = 8;
		this.button_0.Text = "Применить";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_0.Click += this.button_0_Click;
		this.button_1.Dock = DockStyle.Left;
		this.button_1.Location = new Point(812, 6);
		this.button_1.Margin = new Padding(10, 6, 3, 6);
		this.button_1.Name = "btnCancel";
		this.button_1.Size = new Size(75, 22);
		this.button_1.TabIndex = 6;
		this.button_1.Text = "Закрыть";
		this.button_1.UseVisualStyleBackColor = true;
		this.button_1.Click += this.button_1_Click;
		this.tableLayoutPanel_0.SetColumnSpan(this.toolStrip_0, 13);
		this.toolStrip_0.Dock = DockStyle.Fill;
		this.toolStrip_0.Items.AddRange(new ToolStripItem[]
		{
			this.toolStripButton_0,
			this.toolStripButton_1
		});
		this.toolStrip_0.Location = new Point(0, 122);
		this.toolStrip_0.Name = "tsCells";
		this.toolStrip_0.Size = new Size(771, 24);
		this.toolStrip_0.TabIndex = 34;
		this.toolStrip_0.Text = "toolStrip1";
		this.toolStripButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_0.Image = (Image)componentResourceManager.GetObject("tssbAddMissingCells.Image");
		this.toolStripButton_0.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_0.Name = "tssbAddMissingCells";
		this.toolStripButton_0.Size = new Size(23, 21);
		this.toolStripButton_0.Text = "Загрузить недостающие ячейки";
		this.toolStripButton_0.Visible = false;
		this.toolStripButton_0.Click += this.toolStripButton_0_Click;
		this.toolStripButton_1.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_1.Image = (Image)componentResourceManager.GetObject("tssbCellsDeleted.Image");
		this.toolStripButton_1.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_1.Name = "tssbCellsDeleted";
		this.toolStripButton_1.Size = new Size(23, 21);
		this.toolStripButton_1.Text = "Удалить строку";
		this.toolStripButton_1.Click += this.toolStripButton_1_Click;
		this.button_2.Dock = DockStyle.Fill;
		this.button_2.Image = (Image)componentResourceManager.GetObject("btnDeleteData.Image");
		this.button_2.Location = new Point(261, 65);
		this.button_2.Margin = new Padding(0, 2, 0, 0);
		this.button_2.Name = "btnDeleteData";
		this.button_2.Size = new Size(25, 23);
		this.button_2.TabIndex = 35;
		this.button_2.UseVisualStyleBackColor = true;
		this.button_2.Visible = false;
		this.button_2.Click += this.button_2_Click;
		this.label_2.AutoSize = true;
		this.label_2.Dock = DockStyle.Fill;
		this.label_2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.label_2.Location = new Point(316, 13);
		this.label_2.Name = "label5";
		this.label_2.Size = new Size(96, 25);
		this.label_2.TabIndex = 0;
		this.label_2.Text = "Температура:";
		this.label_2.TextAlign = ContentAlignment.MiddleLeft;
		this.tableLayoutPanel_0.SetColumnSpan(this.toolStrip_1, 2);
		this.toolStrip_1.Dock = DockStyle.None;
		this.toolStrip_1.GripStyle = ToolStripGripStyle.Hidden;
		this.toolStrip_1.Items.AddRange(new ToolStripItem[]
		{
			this.toolStripButton_2
		});
		this.toolStrip_1.Location = new Point(415, 13);
		this.toolStrip_1.Name = "toolStripTemperature";
		this.toolStrip_1.Size = new Size(26, 25);
		this.toolStrip_1.TabIndex = 38;
		this.toolStrip_1.Text = "toolStrip1";
		this.toolStripButton_2.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_2.Image = Resources.report_go;
		this.toolStripButton_2.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_2.Name = "toolBtnImportTemperature";
		this.toolStripButton_2.Size = new Size(23, 22);
		this.toolStripButton_2.Text = "Загрузка из реестра температур";
		this.toolStripButton_2.Click += this.toolStripButton_2_Click;
		this.bindingSource_0.DataMember = "tSchm_ObjList";
		this.bindingSource_0.DataSource = this.class255_0;
		this.bindingSource_0.Sort = "Name";
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(906, 377);
		base.Controls.Add(this.tableLayoutPanel_0);
		base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		base.Name = "FormAddEditMeasHighVoltage";
		base.StartPosition = FormStartPosition.CenterScreen;
		base.FormClosing += this.Form38_FormClosing;
		base.Load += this.Form38_Load;
		this.tableLayoutPanel_0.ResumeLayout(false);
		this.tableLayoutPanel_0.PerformLayout();
		((ISupportInitialize)this.bindingSource_2).EndInit();
		((ISupportInitialize)this.class255_0).EndInit();
		((ISupportInitialize)this.bindingSource_7).EndInit();
		((ISupportInitialize)this.dataGridView_0).EndInit();
		((ISupportInitialize)this.bindingSource_6).EndInit();
		((ISupportInitialize)this.bindingSource_4).EndInit();
		((ISupportInitialize)this.bindingSource_3).EndInit();
		((ISupportInitialize)this.bindingSource_5).EndInit();
		((ISupportInitialize)this.numericUpDown_0).EndInit();
		((ISupportInitialize)this.bindingSource_1).EndInit();
		this.tableLayoutPanel_1.ResumeLayout(false);
		this.toolStrip_0.ResumeLayout(false);
		this.toolStrip_0.PerformLayout();
		this.toolStrip_1.ResumeLayout(false);
		this.toolStrip_1.PerformLayout();
		((ISupportInitialize)this.bindingSource_0).EndInit();
		base.ResumeLayout(false);
	}

	[CompilerGenerated]
	private bool method_24(Class255.Class432 class432_0)
	{
		return (from t in this.class255_0.vJ_TransfByCell
		where t.idCell == class432_0.id
		select t).Count<Class255.Class421>() == 0;
	}

	[CompilerGenerated]
	private bool method_25(KeyValuePair<string, Class255.Class318> keyValuePair_0)
	{
		return keyValuePair_0.Key == this.string_2;
	}

	[CompilerGenerated]
	private bool method_26(Class255.Class432 class432_0)
	{
		return (from t in this.class255_0.vJ_TransfByCell
		where t.idCell == class432_0.id
		select t).Count<Class255.Class421>() == 0;
	}

	[CompilerGenerated]
	private bool method_27(Class255.Class434 class434_0)
	{
		return class434_0.idBus == this.IdBus && class434_0.idTransf == this.IdTransf;
	}

	internal static void KCYcMKOiZtChGqJ9LGUP(Form form_0, bool bool_0)
	{
		form_0.Dispose(bool_0);
	}

	[CompilerGenerated]
	private int int_0;

	[CompilerGenerated]
	private StateFormCreate stateFormCreate_0;

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
	private string string_1;

	[CompilerGenerated]
	private int int_5;

	[CompilerGenerated]
	private int int_6;

	private Class255.Class410 class410_0;

	private List<string> list_0;

	private string string_2;

	private Class122 class122_0;

	private Class123 class123_0;

	private Class124 class124_0;

	private TableLayoutPanel tableLayoutPanel_0;

	private Label label_0;

	private Label label_1;

	private Label label_2;

	private Label label_3;

	private Button button_0;

	private Button button_1;

	private Label label_4;

	private Label label_5;

	private Label label_6;

	private Label label_7;

	private TextBox textBox_0;

	private TextBox textBox_1;

	private TextBox textBox_2;

	private TableLayoutPanel tableLayoutPanel_1;

	private NullableDateTimePicker nullableDateTimePicker_0;

	private ComboBox comboBox_0;

	private ComboBox comboBox_1;

	private NumericUpDown numericUpDown_0;

	private Class255 class255_0;

	private BindingSource bindingSource_0;

	private BindingSource bindingSource_1;

	private BindingSource bindingSource_2;

	private BindingSource bindingSource_3;

	private ComboBox comboBox_2;

	private Label label_8;

	private DataGridView dataGridView_0;

	private BindingSource bindingSource_4;

	private BindingSource bindingSource_5;

	private BindingSource bindingSource_6;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_3;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_4;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_5;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_6;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_7;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_8;

	private DataGridViewTextBoxColumn uhloDtYvOvm;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_9;

	private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn_0;

	private Label label_9;

	private ToolStrip toolStrip_0;

	private ToolStripButton toolStripButton_0;

	private ToolStripButton toolStripButton_1;

	private Button button_2;

	private Label label_10;

	private ComboBox comboBox_3;

	private BindingSource bindingSource_7;

	private ToolStrip toolStrip_1;

	private ToolStripButton toolStripButton_2;
}
