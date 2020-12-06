using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ControlsLbr;
using ControlsLbr.DataGridViewExcelFilter;
using ControlsLbr.ReportViewerRus;
using DataSql;
using Documents.Properties;
using FormLbr;
using Microsoft.Reporting.WinForms;

internal partial class Form86 : FormBase
{
	internal bool method_0()
	{
		return this.bool_1;
	}

	internal void method_1(bool bool_2)
	{
		this.bool_1 = bool_2;
		this.method_59();
	}

	internal int? method_2()
	{
		return this.nullable_0;
	}

	internal Form86()
	{
		
		
		this.method_63();
		this.method_3();
	}

	internal Form86(int? nullable_2 = null)
	{
		
		
		this.method_63();
		this.nullable_0 = nullable_2;
		this.method_3();
	}

	internal Form86(int? nullable_2 = null, List<int> list_1 = null)
	{
		
		
		this.method_63();
		this.method_3();
		this.nullable_1 = nullable_2;
		this.list_0 = list_1;
	}

	private void method_3()
	{
		this.nullableDateTimePicker_0.Value = DateTime.Now;
		this.nullableDateTimePicker_5.Value = DateTime.Now;
		this.nullableDateTimePicker_3.Value = DateTime.Now;
		this.nullableDateTimePicker_4.Value = DateTime.Now;
		this.nullableDateTimePicker_3.MaxDate = (DateTime)this.nullableDateTimePicker_4.Value;
	}

	private void Form86_Load(object sender, EventArgs e)
	{
		this.method_4();
		this.method_14();
		this.method_15();
		this.method_16();
		this.method_29();
		this.method_17();
		this.method_18();
		this.method_19();
		this.method_20();
		this.method_21();
		this.method_22();
		this.method_23();
		this.method_24();
		this.method_25();
		this.method_26();
		this.method_27();
		this.method_28();
		this.method_37();
		if (this.nullable_0 == null)
		{
			DataRow dataRow = this.class171_0.tJ_Damage.NewRow();
			dataRow["TypeDoc"] = 1874;
			if (this.nullable_1 != null)
			{
				dataRow["idParent"] = this.nullable_1.Value;
				this.method_10(this.nullable_1.Value, dataRow);
			}
			this.class171_0.tJ_Damage.Rows.Add(dataRow);
			this.method_5();
			this.method_39(this.list_0);
			this.method_6();
			this.method_7();
		}
		else
		{
			base.SelectSqlData(this.class171_0.tJ_Damage, true, " where id = " + this.nullable_0.Value.ToString(), null, false, 0);
			if (this.class171_0.tJ_Damage.Rows.Count > 0)
			{
				if (this.class171_0.tJ_Damage.Rows[0]["idParent"] != DBNull.Value)
				{
					this.nullable_1 = new int?(Convert.ToInt32(this.class171_0.tJ_Damage.Rows[0]["idParent"]));
				}
				if (this.class171_0.tJ_Damage.Rows[0]["isApply"] != DBNull.Value && Convert.ToBoolean(this.class171_0.tJ_Damage.Rows[0]["isApply"]))
				{
					this.comboBoxReadOnly_26.ReadOnly = true;
					this.nullableDateTimePicker_5.Enabled = false;
				}
			}
			base.SelectSqlData(this.class171_0.tJ_DamageActDetection, true, " where idDamage = " + this.nullable_0.Value.ToString(), null, false, 0);
			if (this.class171_0.tJ_DamageActDetection.Rows.Count == 0)
			{
				this.method_5();
			}
			else
			{
				if (this.class171_0.tJ_DamageActDetection.Rows[0]["NoCrashMeasure"] != DBNull.Value)
				{
					string text = this.class171_0.tJ_DamageActDetection.Rows[0]["NoCrashMeasure"].ToString();
					if (!string.IsNullOrEmpty(text))
					{
						this.dataTable_1.ReadXml(new StringReader(text));
					}
				}
				if (this.class171_0.tJ_DamageActDetection.Rows[0]["Defection"] != DBNull.Value)
				{
					string text2 = this.class171_0.tJ_DamageActDetection.Rows[0]["Defection"].ToString();
					if (!string.IsNullOrEmpty(text2))
					{
						this.dataTable_2.ReadXml(new StringReader(text2));
					}
				}
			}
			this.method_36();
		}
		this.method_57();
		if (this.class171_0.tJ_Damage.Rows.Count > 0)
		{
			if (this.class171_0.tJ_Damage.Rows[0]["idParent"] != DBNull.Value)
			{
				this.method_8(Convert.ToInt32(this.class171_0.tJ_Damage.Rows[0]["idParent"]));
			}
			if (this.class171_0.tJ_Damage.Rows[0]["idSchmObj"] != DBNull.Value)
			{
				this.textBox_3.Text = base.CallSQLScalarFunction("dbo.fn_Schm_GetFullNameObjById", new string[]
				{
					this.class171_0.tJ_Damage.Rows[0]["idSchmObj"].ToString()
				}).ToString();
			}
		}
		if (string.IsNullOrEmpty(this.textBox_8.Text))
		{
			this.textBox_8.Text = "0";
		}
		this.method_9();
		this.method_58(base.Controls);
		this.bool_0 = false;
	}

	private void Form86_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (base.DialogResult != DialogResult.OK)
		{
			if (!this.bool_0 || this.method_0() || MessageBox.Show("Сохранить внесенные изменения", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
			{
				base.DialogResult = DialogResult.Cancel;
				return;
			}
		}
		if (!this.method_30())
		{
			MessageBox.Show("Введите обязательные поля для заполнения");
			base.DialogResult = DialogResult.None;
			e.Cancel = true;
			return;
		}
		if (this.method_31())
		{
			base.DialogResult = DialogResult.OK;
			return;
		}
		base.DialogResult = DialogResult.None;
		e.Cancel = true;
	}

	private void method_4()
	{
		this.textBox_18.DataBindings.Clear();
		this.textBox_18.DataBindings.Add(new Binding("Text", this.class171_0, "tJ_DamageActDetection.numCrash", true, DataSourceUpdateMode.OnPropertyChanged, ""));
		this.richTextBox_0.DataBindings.Clear();
		this.richTextBox_0.DataBindings.Add(new Binding("Text", this.class171_0, "tJ_DamageActDetection.TotalComission", true, DataSourceUpdateMode.OnValidation, ""));
		this.nullableDateTimePicker_2.Value = DateTime.Now;
		this.ouoCyeHwemd.Enabled = true;
		Control control = this.textBox_13;
		Control control2 = this.textBox_17;
		Control control3 = this.textBox_16;
		Control control4 = this.textBox_15;
		this.textBox_14.Enabled = true;
		control4.Enabled = true;
		control3.Enabled = true;
		control2.Enabled = true;
		control.Enabled = true;
		this.textBox_8.DataBindings[0].NullValue = "0";
		foreach (object obj in this.tabControl_0.TabPages)
		{
			((TabPage)obj).Show();
		}
	}

	private void method_5()
	{
		DataRow dataRow = this.class171_0.tJ_DamageActDetection.NewRow();
		dataRow["idDamage"] = -1;
		DataTable dataTable = this.method_13();
		base.SelectSqlData(dataTable, true, string.Format("where typeKontragent = {0} and deleted = 0 order by name", 1115), null, false, 0);
		if (dataTable.Rows.Count > 0)
		{
			dataRow["idOrg"] = dataTable.Rows[0]["idAbn"];
		}
		if (this.comboBoxReadOnly_3.DataSource != null && this.comboBoxReadOnly_3.DataSource is BindingSource && ((BindingSource)this.comboBoxReadOnly_3.DataSource).DataSource is DataTable)
		{
			DataRow[] array = ((DataTable)((BindingSource)this.comboBoxReadOnly_3.DataSource).DataSource).Select("Value = 2.3");
			if (array.Length != 0)
			{
				dataRow["idSignCrash"] = array[0]["id"];
			}
		}
		if (this.comboBoxReadOnly_4.DataSource != null && this.comboBoxReadOnly_4.DataSource is BindingSource && ((BindingSource)this.comboBoxReadOnly_4.DataSource).DataSource is DataTable)
		{
			DataRow[] array2 = ((DataTable)((BindingSource)this.comboBoxReadOnly_4.DataSource).DataSource).Select("Value = 3.311");
			if (array2.Length != 0)
			{
				dataRow["idTypeEquipment"] = array2[0]["id"];
			}
		}
		if (this.comboBoxReadOnly_5.DataSource != null && this.comboBoxReadOnly_5.DataSource is BindingSource && ((BindingSource)this.comboBoxReadOnly_5.DataSource).DataSource is DataTable)
		{
			DataRow[] array3 = ((DataTable)((BindingSource)this.comboBoxReadOnly_5.DataSource).DataSource).Select("Value = 4.12 and ParentKey = ';ReportDaily;ActDetection;ReasonCrashEquipment;'");
			if (array3.Length != 0)
			{
				dataRow["idReasonCrashEquipment"] = array3[0]["id"];
			}
		}
		if (this.comboBoxReadOnly_11.DataSource != null && this.comboBoxReadOnly_11.DataSource is BindingSource && ((BindingSource)this.comboBoxReadOnly_11.DataSource).DataSource is DataTable)
		{
			DataRow[] array4 = ((DataTable)((BindingSource)this.comboBoxReadOnly_11.DataSource).DataSource).Select("Value = 4.12 and ParentKey = ';ReportDaily;ActDetection;ReasonBeginCrash;'");
			if (array4.Length != 0)
			{
				dataRow["idReasonBeginCrash"] = array4[0]["id"];
			}
		}
		if (this.comboBoxReadOnly_7.DataSource != null && this.comboBoxReadOnly_7.DataSource is BindingSource && ((BindingSource)this.comboBoxReadOnly_7.DataSource).DataSource is DataTable)
		{
			DataRow[] array5 = ((DataTable)((BindingSource)this.comboBoxReadOnly_7.DataSource).DataSource).Select("Value = 2.01");
			if (array5.Length != 0)
			{
				dataRow["idStatusBeforeCrash"] = array5[0]["id"];
			}
		}
		if (this.comboBoxReadOnly_8.DataSource != null && this.comboBoxReadOnly_8.DataSource is BindingSource && ((BindingSource)this.comboBoxReadOnly_8.DataSource).DataSource is DataTable)
		{
			DataRow[] array6 = ((DataTable)((BindingSource)this.comboBoxReadOnly_8.DataSource).DataSource).Select("Value = 2.201");
			if (array6.Length != 0)
			{
				dataRow["idStatusCurrentCrash"] = array6[0]["id"];
			}
		}
		dataRow["idClassifierDamage"] = 2010;
		dataRow["idFault"] = 2020;
		this.class171_0.tJ_DamageActDetection.Rows.Add(dataRow);
	}

	private void method_6()
	{
		DataRow dataRow = this.dataTable_1.NewRow();
		dataRow["idNoCrashMeasure"] = 1963;
		DataTable dataTable = new SqlDataCommand(this.SqlSettings).SelectSqlData(string.Format("select idabn from vAbnType where typeKontragent = {0}", 1115));
		if (dataTable.Rows.Count > 0)
		{
			dataRow["idOrg"] = dataTable.Rows[0]["idabn"];
		}
		this.dataTable_1.Rows.Add(dataRow);
	}

	private void method_7()
	{
		DataRow dataRow = this.dataTable_2.NewRow();
		dataRow["idDefection"] = 1976;
		this.dataTable_2.Rows.Add(dataRow);
	}

	private void method_8(int int_0)
	{
		DataTable dataTable = new DataTable("vJ_Damage");
		dataTable.Columns.Add("numDoc", typeof(int));
		dataTable.Columns.Add("dateDoc", typeof(DateTime));
		dataTable.Columns.Add("typeDocName", typeof(string));
		dataTable.Columns.Add("nameDoc", typeof(string), "typedocname + isnull(' №' + convert(numDoc, System.String), ' №б/н') + isnull(' от ' + convert(dateDoc, System.String), '')");
		base.SelectSqlData(dataTable, true, "where id = " + int_0.ToString(), null, false, 0);
		if (dataTable.Rows.Count > 0)
		{
			this.textBox_2.Text = dataTable.Rows[0]["nameDoc"].ToString();
		}
		if (this.class171_0.tJ_DamageActDetection.Rows.Count > 0)
		{
			DataTable dataTable2 = new DataTable("tj_DamageOn");
			dataTable2.Columns.Add("DateOn", typeof(DateTime));
			base.SelectSqlData(dataTable2, true, "where idDamage = " + int_0.ToString() + " order by DateOn desc", null, false, 0);
			if (dataTable2.Rows.Count > 0)
			{
				this.class171_0.tJ_DamageActDetection.Rows[0]["dateEndCrashLocal"] = dataTable2.Rows[0]["dateOn"];
				return;
			}
			this.class171_0.tJ_DamageActDetection.Rows[0]["dateEndCrashLocal"] = DBNull.Value;
		}
	}

	private void method_9()
	{
		if (this.nullable_0 == null)
		{
			DataTable dataTable = new DataTable("tUser");
			dataTable.Columns.Add("name", typeof(string));
			dataTable.Columns.Add("idWorker", typeof(string));
			base.SelectSqlData(dataTable, true, "where [login] = SYSTEM_USER", null, false, 0);
			if (dataTable.Rows.Count > 0 && dataTable.Rows[0]["name"] != DBNull.Value)
			{
				this.textBox_0.Text = dataTable.Rows[0]["name"].ToString();
				return;
			}
		}
		else if (this.class171_0.tJ_Damage.Rows.Count > 0 && this.class171_0.tJ_Damage.Rows[0]["idOwner"] != DBNull.Value)
		{
			DataTable dataTable2 = new DataTable("tUser");
			dataTable2.Columns.Add("name", typeof(string));
			base.SelectSqlData(dataTable2, true, "where [idUser] = " + this.class171_0.tJ_Damage.Rows[0]["idOwner"].ToString(), null, false, 0);
			if (dataTable2.Rows.Count > 0 && dataTable2.Rows[0]["name"] != DBNull.Value)
			{
				this.textBox_0.Text = dataTable2.Rows[0]["name"].ToString();
			}
		}
	}

	private void method_10(int int_0, DataRow dataRow_0)
	{
		DataTable dataTable = new SqlDataCommand(this.SqlSettings).SelectSqlData("select pSub.idNetRegion, d.dateDoc, d.idSchmObj  from vj_damage d\r\n                                        left join vP_SubstationByNetRegion pSub on pSub.id = d.idSub\r\n                                        where d.id = " + int_0.ToString());
		if (dataTable.Rows.Count > 0)
		{
			dataRow_0["idDivision"] = dataTable.Rows[0]["idNetRegion"];
			dataRow_0["dateDoc"] = dataTable.Rows[0]["dateDoc"];
			dataRow_0["idSchmObj"] = dataTable.Rows[0]["idSChmObj"];
		}
	}

	private DataTable method_11()
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
		DataColumn dataColumn3 = new DataColumn("fioGroup", Type.GetType("System.String"));
		dataColumn3.Expression = "fio + ' (' + GroupRoman + ')'";
		dataTable.Columns.Add(dataColumn3);
		return dataTable;
	}

	private DataTable method_12()
	{
		DataTable dataTable = new DataTable("tR_Classifier");
		dataTable.Columns.Add("id", typeof(int));
		dataTable.Columns.Add("name", typeof(string));
		dataTable.Columns.Add("comment", typeof(string));
		dataTable.Columns.Add("ParentKey", typeof(string));
		dataTable.Columns.Add("value", typeof(decimal));
		DataColumn dataColumn = new DataColumn("nameComment", Type.GetType("System.String"));
		dataColumn.Expression = "name + ' ' + comment";
		dataTable.Columns.Add(dataColumn);
		return dataTable;
	}

	private DataTable method_13()
	{
		return new DataTable("vAbnType")
		{
			Columns = 
			{
				{
					"idAbn",
					typeof(int)
				},
				{
					"Name",
					typeof(string)
				}
			}
		};
	}

	private void method_14()
	{
		this.dataTable_0 = this.method_12();
		base.SelectSqlData(this.dataTable_0, true, string.Format(" where (ParentKey in ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}',  \r\n                                        '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{15}', \r\n                                         '{16}', '{17}', '{18}', '{19}', '{20}') or ParentKey like '{14}%')\r\n                and isgroup = 0 and deleted = 0", new object[]
		{
			";NetworkAreas;",
			";ReportDaily;ActDetection;SignCrash;",
			";ReportDaily;ActDetection;TypeEquipment;",
			";ReportDaily;ActDetection;ReasonCrashEquipment;",
			";ReportDaily;ActDetection;ReasonCrash;",
			";ReportDaily;ActDetection;StatusBeforeCrash;",
			";ReportDaily;ActDetection;StatusCurrentCrash;",
			";ReportDaily;ActDetection;Defection;",
			";ReportDaily;ActDetection;NPA;",
			";ReportDaily;ActDetection;ReasonBeginCrash;",
			";ReportDaily;ActDetection;Damage;",
			";ReportDaily;ActDetection;Fault;",
			";ReportDaily;ActDetection;NoCrashMeasure;",
			";ReportDaily;ActDetection;Equipment;Params;",
			";VoltageLevels;",
			";ReportDaily;ActDetection;Equipment;NodeDetail;",
			";ReportDaily;ActDetection;Equipment;NeutralState;",
			";ReportDaily;ActDetection;Equipment;Material;",
			";ReportDaily;ActDetection;Equipment;ClauseWork;",
			";ReportDaily;ActDetection;Equipment;ChrDamage;",
			";ReportDaily;ActDetection;Equipment;ReasonDamage;"
		}), null, false, 0);
	}

	private void method_15()
	{
		DataTable dataTable = this.method_11();
		base.SelectSqlData(dataTable, true, "where ParentKey like ';GroupWorker;DailyReport;MemberActDetection;' and dateEnd is null order by fio ", null, false, 0);
		this.comboBoxReadOnly_1.DisplayMember = "FIO";
		this.comboBoxReadOnly_1.ValueMember = "id";
		this.comboBoxReadOnly_1.DataSource = dataTable;
		this.comboBoxReadOnly_1.SelectedIndex = -1;
		this.comboBoxReadOnly_26.DisplayMember = "FIO";
		this.comboBoxReadOnly_26.ValueMember = "id";
		this.comboBoxReadOnly_26.DataSource = dataTable.Copy();
		this.comboBoxReadOnly_26.SelectedIndex = -1;
		this.comboBoxReadOnly_22.DisplayMember = "FIO";
		this.comboBoxReadOnly_22.ValueMember = "id";
		this.comboBoxReadOnly_22.DataSource = dataTable.Copy();
		this.comboBoxReadOnly_22.SelectedIndex = -1;
		this.comboBoxReadOnly_25.DisplayMember = (this.comboBoxReadOnly_24.DisplayMember = (this.comboBoxReadOnly_23.DisplayMember = (this.comboBoxReadOnly_28.DisplayMember = (this.comboBoxReadOnly_27.DisplayMember = "FIO"))));
		this.comboBoxReadOnly_25.ValueMember = (this.comboBoxReadOnly_24.ValueMember = (this.comboBoxReadOnly_23.ValueMember = (this.comboBoxReadOnly_28.ValueMember = (this.comboBoxReadOnly_27.ValueMember = "id"))));
		DataTable dataTable2 = dataTable.Copy();
		dataTable2.Columns["id"].AutoIncrement = true;
		dataTable2.Columns["id"].AutoIncrementSeed = -1L;
		dataTable2.Columns["id"].AutoIncrementStep = -1L;
		DataRow dataRow = dataTable2.NewRow();
		dataRow["FIO"] = "";
		dataRow.EndEdit();
		dataTable2.Rows.Add(dataRow);
		DataView defaultView = dataTable2.DefaultView;
		defaultView.Sort = "FIO asc";
		DataTable dataTable3 = defaultView.ToTable();
		this.comboBoxReadOnly_25.DataSource = dataTable3.Copy();
		this.comboBoxReadOnly_24.DataSource = dataTable3.Copy();
		this.comboBoxReadOnly_23.DataSource = dataTable3.Copy();
		this.comboBoxReadOnly_28.DataSource = dataTable3.Copy();
		this.comboBoxReadOnly_27.DataSource = dataTable3.Copy();
		ListControl listControl = this.comboBoxReadOnly_25;
		ListControl listControl2 = this.comboBoxReadOnly_24;
		ListControl listControl3 = this.comboBoxReadOnly_23;
		ListControl listControl4 = this.comboBoxReadOnly_28;
		this.comboBoxReadOnly_27.SelectedIndex = -1;
		listControl4.SelectedIndex = -1;
		listControl3.SelectedIndex = -1;
		listControl2.SelectedIndex = -1;
		listControl.SelectedIndex = -1;
	}

	private void method_16()
	{
		BindingSource bindingSource = new BindingSource();
		bindingSource.DataSource = this.dataTable_0.Copy();
		bindingSource.Filter = "ParentKey = ';NetworkAreas;'";
		bindingSource.Sort = "name";
		this.comboBoxReadOnly_0.DisplayMember = "name";
		this.comboBoxReadOnly_0.ValueMember = "id";
		this.comboBoxReadOnly_0.DataSource = bindingSource;
		this.comboBoxReadOnly_0.SelectedIndex = -1;
	}

	private void method_17()
	{
		BindingSource bindingSource = new BindingSource();
		bindingSource.DataSource = this.dataTable_0.Copy();
		bindingSource.Filter = "ParentKey = ';ReportDaily;ActDetection;SignCrash;'";
		bindingSource.Sort = "value";
		this.comboBoxReadOnly_3.DisplayMember = "nameComment";
		this.comboBoxReadOnly_3.ValueMember = "id";
		this.comboBoxReadOnly_3.DataSource = bindingSource;
		this.comboBoxReadOnly_3.SelectedIndex = -1;
	}

	private void method_18()
	{
		BindingSource bindingSource = new BindingSource();
		bindingSource.DataSource = this.dataTable_0.Copy();
		bindingSource.Filter = "ParentKey = ';ReportDaily;ActDetection;TypeEquipment;'";
		bindingSource.Sort = "value";
		this.comboBoxReadOnly_4.DisplayMember = "nameComment";
		this.comboBoxReadOnly_4.ValueMember = "id";
		this.comboBoxReadOnly_4.DataSource = bindingSource;
		this.comboBoxReadOnly_4.SelectedIndex = -1;
	}

	private void method_19()
	{
		BindingSource bindingSource = new BindingSource();
		bindingSource.DataSource = this.dataTable_0.Copy();
		bindingSource.Filter = "ParentKey = ';ReportDaily;ActDetection;ReasonCrashEquipment;'";
		bindingSource.Sort = "value";
		this.comboBoxReadOnly_5.DisplayMember = "nameComment";
		this.comboBoxReadOnly_5.ValueMember = "id";
		this.comboBoxReadOnly_5.DataSource = bindingSource;
		this.comboBoxReadOnly_5.SelectedIndex = -1;
	}

	private void method_20()
	{
		BindingSource bindingSource = new BindingSource();
		bindingSource.DataSource = this.dataTable_0.Copy();
		bindingSource.Filter = "ParentKey = ';ReportDaily;ActDetection;ReasonCrash;'";
		bindingSource.Sort = "value";
		this.comboBoxReadOnly_6.DisplayMember = "nameComment";
		this.comboBoxReadOnly_6.ValueMember = "id";
		this.comboBoxReadOnly_6.DataSource = bindingSource;
		this.comboBoxReadOnly_6.SelectedIndex = -1;
	}

	private void method_21()
	{
		BindingSource bindingSource = new BindingSource();
		bindingSource.DataSource = this.dataTable_0.Copy();
		bindingSource.Filter = "ParentKey = ';ReportDaily;ActDetection;StatusBeforeCrash;'";
		bindingSource.Sort = "value";
		this.comboBoxReadOnly_7.DisplayMember = "nameComment";
		this.comboBoxReadOnly_7.ValueMember = "id";
		this.comboBoxReadOnly_7.DataSource = bindingSource;
		this.comboBoxReadOnly_7.SelectedIndex = -1;
	}

	private void method_22()
	{
		BindingSource bindingSource = new BindingSource();
		bindingSource.DataSource = this.dataTable_0.Copy();
		bindingSource.Filter = "ParentKey = ';ReportDaily;ActDetection;StatusCurrentCrash;'";
		bindingSource.Sort = "value";
		this.comboBoxReadOnly_8.DisplayMember = "nameComment";
		this.comboBoxReadOnly_8.ValueMember = "id";
		this.comboBoxReadOnly_8.DataSource = bindingSource;
		this.comboBoxReadOnly_8.SelectedIndex = -1;
	}

	private void method_23()
	{
		BindingSource bindingSource = new BindingSource();
		bindingSource.DataSource = this.dataTable_0.Copy();
		bindingSource.Filter = "ParentKey = ';ReportDaily;ActDetection;NoCrashMeasure;'";
		bindingSource.Sort = "value";
		this.dataGridViewComboBoxColumn_3.DisplayMember = "name";
		this.dataGridViewComboBoxColumn_3.ValueMember = "id";
		this.dataGridViewComboBoxColumn_3.DataSource = bindingSource;
	}

	private void method_24()
	{
		BindingSource bindingSource = new BindingSource();
		bindingSource.DataSource = this.dataTable_0.Copy();
		bindingSource.Filter = "ParentKey = ';ReportDaily;ActDetection;Defection;'";
		bindingSource.Sort = "value";
		this.dataGridViewComboBoxColumn_0.DisplayMember = "comment";
		this.dataGridViewComboBoxColumn_0.ValueMember = "id";
		this.dataGridViewComboBoxColumn_0.DataSource = bindingSource;
	}

	private void method_25()
	{
		BindingSource bindingSource = new BindingSource();
		bindingSource.DataSource = this.dataTable_0.Copy();
		bindingSource.Filter = "ParentKey = ';ReportDaily;ActDetection;NPA;'";
		bindingSource.Sort = "value";
		this.dataGridViewComboBoxColumn_1.DisplayMember = "name";
		this.dataGridViewComboBoxColumn_1.ValueMember = "id";
		this.dataGridViewComboBoxColumn_1.DataSource = bindingSource;
	}

	private void method_26()
	{
		BindingSource bindingSource = new BindingSource();
		bindingSource.DataSource = this.dataTable_0.Copy();
		bindingSource.Filter = "ParentKey = ';ReportDaily;ActDetection;ReasonBeginCrash;'";
		bindingSource.Sort = "value";
		this.comboBoxReadOnly_11.DisplayMember = "comment";
		this.comboBoxReadOnly_11.ValueMember = "id";
		this.comboBoxReadOnly_11.DataSource = bindingSource;
	}

	private void method_27()
	{
		BindingSource bindingSource = new BindingSource();
		bindingSource.DataSource = this.dataTable_0.Copy();
		bindingSource.Filter = "ParentKey = ';ReportDaily;ActDetection;Damage;'";
		bindingSource.Sort = "value";
		this.comboBoxReadOnly_10.DisplayMember = "name";
		this.comboBoxReadOnly_10.ValueMember = "id";
		this.comboBoxReadOnly_10.DataSource = bindingSource;
	}

	private void method_28()
	{
		BindingSource bindingSource = new BindingSource();
		bindingSource.DataSource = this.dataTable_0.Copy();
		bindingSource.Filter = "ParentKey = ';ReportDaily;ActDetection;Fault;'";
		bindingSource.Sort = "value";
		this.comboBoxReadOnly_9.DisplayMember = "name";
		this.comboBoxReadOnly_9.ValueMember = "id";
		this.comboBoxReadOnly_9.DataSource = bindingSource;
	}

	private void method_29()
	{
		DataTable dataTable = this.method_13();
		base.SelectSqlData(dataTable, true, string.Format("where typeKontragent = {0} and deleted = 0 order by name", 1877), null, false, 0);
		this.comboBoxReadOnly_2.DisplayMember = "name";
		this.comboBoxReadOnly_2.ValueMember = "idAbn";
		this.comboBoxReadOnly_2.DataSource = dataTable;
		this.comboBoxReadOnly_2.SelectedIndex = -1;
		this.dataGridViewComboBoxColumn_4.DisplayMember = "name";
		this.dataGridViewComboBoxColumn_4.ValueMember = "idAbn";
		this.dataGridViewComboBoxColumn_4.DataSource = dataTable.Copy();
		this.dataGridViewComboBoxColumn_2.DisplayMember = "name";
		this.dataGridViewComboBoxColumn_2.ValueMember = "idAbn";
		this.dataGridViewComboBoxColumn_2.DataSource = dataTable.Copy();
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		base.Close();
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		base.Close();
	}

	private bool method_30()
	{
		bool result = true;
		if (this.checkBox_0.Checked)
		{
			if (string.IsNullOrEmpty(this.textBox_18.Text))
			{
				result = false;
				this.label_53.ForeColor = Color.Red;
			}
			if (new SqlDataCommand(this.SqlSettings).SelectSqlData(string.Format("select a.numCrash from tJ_DamageActDetection a\r\n                                            left join tj_damage d on d.id = a.idDamage\r\n                                            where a.numCrash = '{0}' and year(d.DateDoc) = {1} and d.id <> {2}", this.textBox_18.Text, this.dateTimePicker_0.Value.Year, (this.method_2() == null) ? -1 : this.method_2().Value)).Rows.Count > 0)
			{
				result = false;
				this.label_53.ForeColor = Color.Red;
			}
		}
		return result;
	}

	private bool method_31()
	{
		this.class171_0.tJ_Damage.Rows[0].EndEdit();
		if (this.nullable_0 == null)
		{
			this.nullable_0 = new int?(base.InsertSqlDataOneRow(this.class171_0, this.class171_0.tJ_Damage));
			if (this.nullable_0 == -1)
			{
				this.nullable_0 = null;
				return false;
			}
		}
		else if (!base.UpdateSqlData(this.class171_0.tJ_Damage))
		{
			return false;
		}
		return this.method_32() && this.method_33();
	}

	private bool method_32()
	{
		if (this.class171_0.tJ_DamageActDetection.Rows.Count > 0)
		{
			this.class171_0.tJ_DamageActDetection.Rows[0]["idDamage"] = this.nullable_0.Value;
			if (this.dataTable_1.Rows.Count == 0)
			{
				this.class171_0.tJ_DamageActDetection.Rows[0]["NoCrashMeasure"] = DBNull.Value;
			}
			else
			{
				StringWriter stringWriter = new StringWriter();
				this.dataTable_1.WriteXml(stringWriter, XmlWriteMode.WriteSchema, false);
				string value = stringWriter.ToString();
				this.class171_0.tJ_DamageActDetection.Rows[0]["NoCrashMeasure"] = value;
			}
			if (this.dataTable_2.Rows.Count == 0)
			{
				this.class171_0.tJ_DamageActDetection.Rows[0]["Defection"] = DBNull.Value;
			}
			else
			{
				StringWriter stringWriter2 = new StringWriter();
				this.dataTable_2.WriteXml(stringWriter2, XmlWriteMode.WriteSchema, false);
				string value2 = stringWriter2.ToString();
				this.class171_0.tJ_DamageActDetection.Rows[0]["Defection"] = value2;
			}
			if (this.dataTable_4.Rows.Count == 0)
			{
				this.class171_0.tJ_DamageActDetection.Rows[0]["Comission"] = DBNull.Value;
			}
			else
			{
				StringWriter stringWriter3 = new StringWriter();
				this.dataTable_4.WriteXml(stringWriter3, XmlWriteMode.WriteSchema, false);
				string value3 = stringWriter3.ToString();
				this.class171_0.tJ_DamageActDetection.Rows[0]["Comission"] = value3;
			}
			this.class171_0.tJ_DamageActDetection.Rows[0].EndEdit();
			if (!base.InsertSqlData(this.class171_0.tJ_DamageActDetection))
			{
				return false;
			}
			if (!base.UpdateSqlData(this.class171_0.tJ_DamageActDetection))
			{
				return false;
			}
			base.SelectSqlData(this.class171_0.tJ_DamageActDetection, true, "where idDamage = " + this.nullable_0.Value.ToString(), null, false, 0);
		}
		return true;
	}

	private bool method_33()
	{
		foreach (object obj in this.class171_0.tJ_DamageCharacter.Rows)
		{
			DataRow dataRow = (DataRow)obj;
			if (dataRow.RowState != DataRowState.Deleted)
			{
				dataRow["idDamage"] = this.nullable_0.Value;
				dataRow.EndEdit();
			}
		}
		return base.InsertSqlData(this.class171_0.tJ_DamageCharacter) && base.UpdateSqlData(this.class171_0.tJ_DamageCharacter) && base.DeleteSqlData(this.class171_0.tJ_DamageCharacter);
	}

	private void button_2_Click(object sender, EventArgs e)
	{
		Form88 form = new Form88();
		form.SqlSettings = this.SqlSettings;
		if (form.ShowDialog() == DialogResult.OK)
		{
			int value = form.method_0().Value;
			List<int> list_ = new List<int>();
			Form87 form2 = new Form87(new int?(value), list_, this.nullable_0);
			form2.SqlSettings = this.SqlSettings;
			if (form2.ShowDialog() == DialogResult.OK)
			{
				while (this.dataGridView_0.Rows.Count > 0)
				{
					this.dataGridView_0.Rows.RemoveAt(0);
				}
				this.method_39(form2.method_0());
				this.class171_0.tJ_Damage.Rows[0]["idParent"] = (this.nullable_1 = new int?(value));
				this.method_8(value);
			}
		}
	}

	private void button_3_Click(object sender, EventArgs e)
	{
		if (this.nullable_1 == null)
		{
			return;
		}
		DataTable dataTable = base.SelectSqlData("tJ_Damage", true, "where id = " + this.nullable_1.ToString());
		if (dataTable.Rows.Count == 0)
		{
			return;
		}
		this.method_34(Convert.ToInt32(dataTable.Rows[0]["typeDoc"]), Convert.ToInt32(this.nullable_1));
	}

	private void method_34(int int_0, int int_1 = -1)
	{
		switch (int_0)
		{
		case 1401:
		{
			Form84 form = new Form84(int_1, (Enum20)1401);
			form.SqlSettings = this.SqlSettings;
			form.MdiParent = base.MdiParent;
			form.method_2(true);
			form.Show();
			return;
		}
		case 1402:
		{
			Form81 form2 = new Form81(int_1);
			form2.SqlSettings = this.SqlSettings;
			form2.MdiParent = base.MdiParent;
			form2.method_2(true);
			form2.Show();
			return;
		}
		case 1403:
			break;
		default:
			if (int_0 != 1844)
			{
				if (int_0 != 1874)
				{
					return;
				}
				Form86 form3 = new Form86(new int?(int_1));
				form3.SqlSettings = this.SqlSettings;
				form3.MdiParent = base.MdiParent;
				form3.method_1(true);
				form3.Show();
				return;
			}
			break;
		}
		Form83 form4 = new Form83(int_1, int_0);
		form4.SqlSettings = this.SqlSettings;
		form4.MdiParent = base.MdiParent;
		form4.method_2(true);
		form4.Show();
	}

	private void checkBox_0_CheckedChanged(object sender, EventArgs e)
	{
		this.bool_0 = true;
		if (this.checkBox_0.Checked)
		{
			this.textBox_18.Enabled = true;
			if (string.IsNullOrEmpty(this.textBox_18.Text))
			{
				DataTable dataTable = new SqlDataCommand(this.SqlSettings).SelectSqlData(string.Format("select a.numCrash from tJ_DamageActDetection a\r\n                                            left join tj_damage d on d.id = a.idDamage\r\n                                            where isnumeric(a.numCrash) = 1 and year(d.DateDoc) = {0}\r\n                                            order by cast(a.numCrash as int) desc", this.dateTimePicker_0.Value.Year));
				if (dataTable.Rows.Count > 0)
				{
					this.textBox_18.Text = (Convert.ToInt32(dataTable.Rows[0]["numCrash"]) + 1).ToString();
					return;
				}
				this.textBox_18.Text = "1";
				return;
			}
		}
		else
		{
			this.textBox_18.Enabled = false;
			this.textBox_18.Text = "";
		}
	}

	private void textBox_18_TextChanged(object sender, EventArgs e)
	{
		this.bool_0 = true;
		if (!string.IsNullOrEmpty(this.textBox_18.Text))
		{
			this.label_53.ForeColor = Color.Black;
		}
	}

	private void nullableDateTimePicker_2_ValueChanged(object sender, EventArgs e)
	{
		this.bool_0 = true;
		if (this.nullableDateTimePicker_2.Value != null)
		{
			if (this.nullableDateTimePicker_2.Value != DBNull.Value)
			{
				this.nullableDateTimePicker_1.Value = Convert.ToDateTime(this.nullableDateTimePicker_2.Value).AddHours(3.0).AddHours(-TimeZoneInfo.Local.BaseUtcOffset.TotalHours);
				return;
			}
		}
		this.nullableDateTimePicker_1.Value = DBNull.Value;
	}

	private void dataGridViewExcelFilter_0_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
	{
		if (e.Control is DataGridViewComboBoxEditingControl)
		{
			((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
			((ComboBox)e.Control).AutoCompleteSource = AutoCompleteSource.ListItems;
			((ComboBox)e.Control).AutoCompleteMode = AutoCompleteMode.Suggest;
			((ComboBox)e.Control).DropDown -= this.method_35;
			((ComboBox)e.Control).DropDown += this.method_35;
		}
		if (((DataGridView)sender).CurrentCell != null && ((DataGridView)sender).Columns[((DataGridView)sender).CurrentCell.ColumnIndex] == this.dataGridViewFilterDateTimePickerColumn_0 && e.Control is DateTimePicker)
		{
			((DateTimePicker)e.Control).Format = DateTimePickerFormat.Custom;
			((DateTimePicker)e.Control).CustomFormat = "MMMM.yyyy";
			if (((DataGridView)sender).CurrentCell.Value == DBNull.Value)
			{
				((DataGridView)sender).CurrentCell.Value = ((DateTimePicker)e.Control).Value;
			}
		}
	}

	private void method_35(object sender, EventArgs e)
	{
		((ComboBox)sender).DropDownWidth = 500;
	}

	private void dataGridViewExcelFilter_0_MouseClick(object sender, MouseEventArgs e)
	{
		if (((DataGridView)sender).HitTest(e.X, e.Y).Type == DataGridViewHitTestType.RowHeader)
		{
			((DataGridView)sender).EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
			((DataGridView)sender).EndEdit();
			return;
		}
		((DataGridView)sender).EditMode = DataGridViewEditMode.EditOnEnter;
	}

	private void method_36()
	{
		if (this.nullable_0 != null)
		{
			base.SelectSqlData(this.class171_0.tJ_DamageCharacter, true, "where idDamage = " + this.nullable_0.ToString(), null, false, 0);
		}
	}

	private void method_37()
	{
		this.method_38();
		this.method_49();
		this.method_50();
		this.method_51();
		this.method_52();
		this.method_53();
		this.method_54();
		this.method_55();
		this.method_56();
	}

	private void method_38()
	{
		DataTable dataTable = this.method_12();
		base.SelectSqlData(dataTable, true, "where ParentId in (select id from \r\n                                        tr_classifier where ParentKey = ';ReportDaily;NatureDamage;HV;') \r\n                                        and isGroup = 1 and deleted = 0 order by ParentKey", null, false, 0);
		BindingSource bindingSource = new BindingSource();
		bindingSource.DataSource = dataTable;
		bindingSource.Position = -1;
		this.dataGridViewComboBoxColumn_6.DisplayMember = "name";
		this.dataGridViewComboBoxColumn_6.ValueMember = "id";
		this.dataGridViewComboBoxColumn_6.DataSource = bindingSource;
	}

	private void toolStripButton_0_Click(object sender, EventArgs e)
	{
		List<int> list = new List<int>();
		foreach (DataRow dataRow in this.class171_0.tJ_DamageCharacter)
		{
			if (dataRow.RowState != DataRowState.Deleted && dataRow["idCharacterParent"] != DBNull.Value)
			{
				list.Add(Convert.ToInt32(dataRow["idCharacterParent"]));
			}
		}
		Form87 form = new Form87(this.nullable_1, list, this.nullable_0);
		form.SqlSettings = this.SqlSettings;
		if (form.ShowDialog() == DialogResult.OK)
		{
			this.method_39(form.method_0());
		}
	}

	private void method_39(IEnumerable<int> ienumerable_0)
	{
		if (ienumerable_0 != null && ienumerable_0.Count<int>() > 0)
		{
			this.textBox_6.TextChanged -= this.textBox_6_TextChanged;
			string text = "";
			foreach (int num in ienumerable_0)
			{
				if (string.IsNullOrEmpty(text))
				{
					text = num.ToString();
				}
				else
				{
					text = text + "," + num.ToString();
				}
			}
			Class171.Class184 @class = new Class171.Class184();
			base.SelectSqlData(@class, true, "where id in (" + text + ")", null, false, 0);
			foreach (object obj in @class.Rows)
			{
				DataRow dataRow = (DataRow)obj;
				DataRow dataRow2 = this.class171_0.tJ_DamageCharacter.NewRow();
				dataRow2["idDamage"] = ((this.nullable_0 == null) ? -1 : this.nullable_0.Value);
				dataRow2["col1"] = dataRow["col1"];
				dataRow2["idSchmObj"] = dataRow["idSchmObj"];
				dataRow2["idLineSection"] = dataRow["idLineSection"];
				dataRow2["idParameters"] = 2026;
				dataRow2["idCharacterParent"] = dataRow["id"];
				dataRow2["lengthOverLoad"] = 0;
				dataRow2["idNeutralState"] = 2037;
				dataRow2["nodeDetail"] = 2032;
				if (dataRow2["idSchmObj"] != DBNull.Value)
				{
					object obj2 = this.method_40(Convert.ToInt32(dataRow2["idSChmObj"]));
					if (!string.IsNullOrEmpty(obj2.ToString()))
					{
						dataRow2["LengthLine"] = obj2;
					}
					object value = this.method_45(Convert.ToInt32(dataRow2["idSChmObj"]));
					dataRow2["idMark"] = value;
					object obj3 = this.method_41(Convert.ToInt32(dataRow2["idSChmObj"]));
					if (obj3 != DBNull.Value && obj3.ToString() != string.Empty && this.comboBoxReadOnly_13.DataSource != null && this.comboBoxReadOnly_13.DataSource is BindingSource && ((BindingSource)this.comboBoxReadOnly_13.DataSource).DataSource is DataTable)
					{
						DataRow[] array = ((DataTable)((BindingSource)this.comboBoxReadOnly_13.DataSource).DataSource).Select("Value = '" + obj3.ToString() + "' and ParentKey like ';VoltageLevels;%'");
						if (array.Length != 0)
						{
							dataRow2["idVoltage"] = array[0]["id"];
						}
					}
					obj3 = this.method_42(Convert.ToInt32(dataRow2["idSChmObj"]));
					if (obj3 != DBNull.Value && this.comboBoxReadOnly_16.DataSource != null && this.comboBoxReadOnly_16.DataSource is BindingSource && ((BindingSource)this.comboBoxReadOnly_16.DataSource).DataSource is DataTable)
					{
						DataRow[] array2 = ((DataTable)((BindingSource)this.comboBoxReadOnly_16.DataSource).DataSource).Select("Value = " + obj3.ToString().Replace(',', '.') + " and ParentKey like ';VoltageLevels;%'");
						if (array2.Length != 0)
						{
							dataRow2["idVoltageSeti"] = array2[0]["id"];
						}
					}
					object value2 = this.method_44(Convert.ToInt32(dataRow2["idSChmObj"]));
					dataRow2["YearManufacture"] = value2;
					object obj4 = this.method_43(Convert.ToInt32(dataRow2["idSChmObj"]));
					DateTime dateTime;
					if (DateTime.TryParse(obj4.ToString(), out dateTime))
					{
						dataRow2["YearBegEquipment"] = dateTime.ToString("yyyy");
					}
					else
					{
						dataRow2["YearBegEquipment"] = ((obj4.ToString() == string.Empty) ? DBNull.Value : obj4);
					}
					object value3 = this.method_46(Convert.ToInt32(dataRow2["idSChmObj"]));
					dataRow2["LastDateTest"] = value3;
					object value4 = this.method_47(Convert.ToInt32(dataRow2["idSChmObj"]));
					dataRow2["timeRecovery"] = value4;
				}
				this.class171_0.tJ_DamageCharacter.Rows.Add(dataRow2);
			}
		}
	}

	private object method_40(int int_0)
	{
		DataTable dataTable = new DataTable("tSchm_ObjList");
		dataTable.Columns.Add("typeCodeId", typeof(int));
		base.SelectSqlData(dataTable, true, " where id = " + int_0.ToString(), null, false, 0);
		if (dataTable.Rows.Count > 0 && dataTable.Rows[0]["TypeCodeId"] != DBNull.Value)
		{
			if (Convert.ToInt32(dataTable.Rows[0]["TypeCodeId"]) == 546)
			{
				DataTable dataTable2 = base.SelectSqlData("vP_PassportDataReports", true, string.Format("where idObj = {0} and [CharName] like 'Длина трассы'", int_0));
				if (dataTable2.Rows.Count > 0 && dataTable2.Rows[0]["CharValue"] != DBNull.Value)
				{
					return dataTable2.Rows[0]["CharValue"];
				}
			}
			if (Convert.ToInt32(dataTable.Rows[0]["TypeCodeId"]) == 547 || Convert.ToInt32(dataTable.Rows[0]["TypeCodeId"]) == 983)
			{
				DataTable dataTable3 = base.SelectSqlData("vP_PassportDataReports", true, string.Format("where idObj = {0} and [CharName] like 'Протяженность линии'", int_0));
				if (dataTable3.Rows.Count > 0 && dataTable3.Rows[0]["CharValue"] != DBNull.Value)
				{
					return dataTable3.Rows[0]["CharValue"];
				}
			}
		}
		return DBNull.Value;
	}

	private object method_41(int int_0)
	{
		DataTable dataTable = new DataTable("tSchm_ObjList");
		dataTable.Columns.Add("typeCodeId", typeof(int));
		base.SelectSqlData(dataTable, true, " where id = " + int_0.ToString(), null, false, 0);
		if (dataTable.Rows.Count > 0 && dataTable.Rows[0]["TypeCodeId"] != DBNull.Value)
		{
			if (Convert.ToInt32(dataTable.Rows[0]["TypeCodeId"]) == 546)
			{
				DataTable dataTable2 = base.SelectSqlData("vP_PassportDataReports", true, string.Format("where idObj = {0} and [CharName] like 'Напряжение'", int_0));
				if (dataTable2.Rows.Count > 0 && dataTable2.Rows[0]["CharValue"] != DBNull.Value)
				{
					return dataTable2.Rows[0]["CharValue"];
				}
			}
			if (Convert.ToInt32(dataTable.Rows[0]["TypeCodeId"]) == 547 || Convert.ToInt32(dataTable.Rows[0]["TypeCodeId"]) == 983)
			{
				DataTable dataTable3 = base.SelectSqlData("vP_PassportDataReports", true, string.Format("where idObj = {0} and [CharName] like 'Напряжение'", int_0));
				if (dataTable3.Rows.Count > 0 && dataTable3.Rows[0]["CharValue"] != DBNull.Value)
				{
					return dataTable3.Rows[0]["CharValue"];
				}
			}
		}
		return DBNull.Value;
	}

	private object method_42(int int_0)
	{
		DataTable dataTable = new DataTable("tSchm_ObjList");
		dataTable.Columns.Add("typeCodeId", typeof(int));
		base.SelectSqlData(dataTable, true, " where id = " + int_0.ToString(), null, false, 0);
		if (dataTable.Rows.Count > 0 && dataTable.Rows[0]["TypeCodeId"] != DBNull.Value && Convert.ToInt32(dataTable.Rows[0]["TypeCodeId"]) == 546)
		{
			DataTable dataTable2 = base.SelectSqlData("vP_PassportDataReports", true, string.Format("where idObj = {0} and [CharName] like 'Рабочее напряжение'", int_0));
			if (dataTable2.Rows.Count > 0 && dataTable2.Rows[0]["CharValue"] != DBNull.Value)
			{
				return dataTable2.Rows[0]["CharValue"];
			}
		}
		return DBNull.Value;
	}

	private object method_43(int int_0)
	{
		DataTable dataTable = new DataTable("tSchm_ObjList");
		dataTable.Columns.Add("typeCodeId", typeof(int));
		base.SelectSqlData(dataTable, true, " where id = " + int_0.ToString(), null, false, 0);
		if (dataTable.Rows.Count > 0 && dataTable.Rows[0]["TypeCodeId"] != DBNull.Value)
		{
			if (Convert.ToInt32(dataTable.Rows[0]["TypeCodeId"]) == 546)
			{
				DataTable dataTable2 = base.SelectSqlData("vP_PassportDataReports", true, string.Format("where idObj = {0} and [CharName] like 'Год ввода в эксплуатацию'", int_0));
				if (dataTable2.Rows.Count > 0 && dataTable2.Rows[0]["CharValue"] != DBNull.Value)
				{
					return dataTable2.Rows[0]["CharValue"];
				}
			}
			if (Convert.ToInt32(dataTable.Rows[0]["TypeCodeId"]) == 547 || Convert.ToInt32(dataTable.Rows[0]["TypeCodeId"]) == 983)
			{
				string where = string.Format("where idObj = {0} and ([CharName] like 'Год ввода в эксплуатацию'\r\nor [CharName] like 'Дата ввода в эксплуатацию') and [CharValue] is not null and [CharValue] <> ''", int_0);
				DataTable dataTable3 = base.SelectSqlData("vP_PassportDataReports", true, where);
				if (dataTable3.Rows.Count > 0 && dataTable3.Rows[0]["CharValue"] != DBNull.Value)
				{
					return dataTable3.Rows[0]["CharValue"];
				}
			}
		}
		return DBNull.Value;
	}

	private object method_44(int int_0)
	{
		DataTable dataTable = new DataTable("tSchm_ObjList");
		dataTable.Columns.Add("typeCodeId", typeof(int));
		base.SelectSqlData(dataTable, true, " where id = " + int_0.ToString(), null, false, 0);
		if (dataTable.Rows.Count > 0 && dataTable.Rows[0]["TypeCodeId"] != DBNull.Value)
		{
			if (Convert.ToInt32(dataTable.Rows[0]["TypeCodeId"]) == 546)
			{
				DataTable dataTable2 = base.SelectSqlData("vP_PassportDataReports", true, string.Format("where idObj = {0} and [CharName] like 'Год прокладки'", int_0));
				if (dataTable2.Rows.Count > 0 && dataTable2.Rows[0]["CharValue"] != DBNull.Value)
				{
					return dataTable2.Rows[0]["CharValue"];
				}
			}
			if (Convert.ToInt32(dataTable.Rows[0]["TypeCodeId"]) == 547 || Convert.ToInt32(dataTable.Rows[0]["TypeCodeId"]) == 983)
			{
				DataTable dataTable3 = base.SelectSqlData("vP_PassportDataReports", true, string.Format("where idObj = {0} and [CharName] like 'Год постройки'", int_0));
				if (dataTable3.Rows.Count > 0 && dataTable3.Rows[0]["CharValue"] != DBNull.Value)
				{
					return dataTable3.Rows[0]["CharValue"];
				}
			}
		}
		return DBNull.Value;
	}

	private object method_45(int int_0)
	{
		DataTable dataTable = new DataTable("tSchm_ObjList");
		dataTable.Columns.Add("typeCodeId", typeof(int));
		base.SelectSqlData(dataTable, true, " where id = " + int_0.ToString(), null, false, 0);
		if (dataTable.Rows.Count > 0 && dataTable.Rows[0]["TypeCodeId"] != DBNull.Value)
		{
			if (Convert.ToInt32(dataTable.Rows[0]["TypeCodeId"]) == 546)
			{
				DataTable dataTable2 = base.SelectSqlData("tP_Passport", true, string.Format("where idObjList = {0} and [isActive] = '1' and deleted = '0'", int_0));
				if (dataTable2.Rows.Count > 0 && dataTable2.Rows[0]["idEquipment"] != DBNull.Value)
				{
					return dataTable2.Rows[0]["idEquipment"];
				}
			}
			if (Convert.ToInt32(dataTable.Rows[0]["TypeCodeId"]) == 547 || Convert.ToInt32(dataTable.Rows[0]["TypeCodeId"]) == 983)
			{
				DataTable dataTable3 = base.SelectSqlData("tP_Passport", true, string.Format("where idObjList = {0} and [isActive] = '1' and deleted = '0'", int_0));
				if (dataTable3.Rows.Count > 0 && dataTable3.Rows[0]["idEquipment"] != DBNull.Value)
				{
					return dataTable3.Rows[0]["idEquipment"];
				}
			}
		}
		return DBNull.Value;
	}

	private object method_46(int int_0)
	{
		DataTable dataTable = new DataTable("tP_CabTesting");
		dataTable.Columns.Add("date", typeof(DateTime));
		string str = "";
		if (this.class171_0.tJ_Damage.Rows.Count > 0 && this.class171_0.tJ_Damage.Rows[0]["datedoc"] != DBNull.Value)
		{
			str = " and [date] < '" + Convert.ToDateTime(this.class171_0.tJ_Damage.Rows[0]["datedoc"]).ToString("yyyyMMdd") + "'";
		}
		base.SelectSqlData(dataTable, true, " where idObjList = " + int_0.ToString() + str + " and deleted = 0 order by [date] desc", null, false, 0);
		if (dataTable.Rows.Count > 0)
		{
			return dataTable.Rows[0]["Date"];
		}
		return DBNull.Value;
	}

	private object method_47(int int_0)
	{
		DataTable dataTable = new DataTable("tP_CabOperation");
		dataTable.Columns.Add("datecommissioning", typeof(DateTime));
		string str = "";
		if (this.class171_0.tJ_Damage.Rows.Count > 0 && this.class171_0.tJ_Damage.Rows[0]["datedoc"] != DBNull.Value)
		{
			str = " and [datecommissioning] > '" + Convert.ToDateTime(this.class171_0.tJ_Damage.Rows[0]["datedoc"]).ToString("yyyyMMdd") + "'";
		}
		base.SelectSqlData(dataTable, true, " where idObjList = " + int_0.ToString() + str + " and deleted = 0 order by [datecommissioning]", null, false, 0);
		if (dataTable.Rows.Count > 0)
		{
			return dataTable.Rows[0]["datecommissioning"];
		}
		return DBNull.Value;
	}

	private void toolStripButton_1_Click(object sender, EventArgs e)
	{
		if (this.dataGridView_0.CurrentRow != null)
		{
			if (this.dataGridView_0.Rows.Count == 1)
			{
				DataTable dataTable = new DataTable("tJ_Damage");
				dataTable.Columns.Add("id", typeof(int));
				string arg = "";
				if (this.nullable_0 != null)
				{
					arg = "id <> " + this.nullable_0.Value.ToString() + " and ";
				}
				base.SelectSqlData(dataTable, true, string.Format("where {0} idParent = {1} and typeDoc = {2} \r\n                        and not  exists(select id from tJ_DamageCharacter where idDAmage = tj_damage.id)", arg, this.nullable_1, 1874), null, false, 0);
				if (dataTable.Rows.Count > 0)
				{
					MessageBox.Show("Нельзя удалить последнюю строку.\r\nУже существуют документ без оборудования.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
			}
			if (MessageBox.Show("Вы  действительно хотите удалить выбранную строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				this.dataGridView_0.Rows.Remove(this.dataGridView_0.CurrentRow);
			}
		}
	}

	private void dataGridView_0_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
	{
		for (int i = e.RowIndex; i < e.RowIndex + e.RowCount; i++)
		{
			object value = this.dataGridView_0[this.dataGridViewTextBoxColumn_9.Name, i].Value;
			if (value != DBNull.Value && value != null)
			{
				object obj = base.CallSQLScalarFunction("dbo.fn_Schm_GetFullNameObjById", new string[]
				{
					value.ToString()
				});
				if (obj != null && obj != DBNull.Value)
				{
					this.dataGridView_0[this.dataGridViewTextBoxColumn_10.Index, i].Value = obj.ToString();
				}
			}
		}
	}

	private void bindingSource_2_CurrentChanged(object sender, EventArgs e)
	{
		if (this.bindingSource_2.Current != null)
		{
			DataRow row = ((DataRowView)this.bindingSource_2.Current).Row;
			object obj = row["idMark"];
			this.method_48();
			row["idMark"] = obj;
			this.comboBoxReadOnly_15.SelectedValue = obj;
			if (!this.method_0() && !this.checkBox_3.Checked)
			{
				this.method_60(false);
				return;
			}
		}
		else
		{
			this.method_60(true);
		}
	}

	private void method_48()
	{
		if (this.bindingSource_2.Current == null || ((DataRowView)this.bindingSource_2.Current).Row["col1"] == DBNull.Value)
		{
			this.comboBoxReadOnly_15.DataSource = null;
			return;
		}
		DataTable dataTable = this.method_12();
		base.SelectSqlData(dataTable, true, " where id = " + ((DataRowView)this.bindingSource_2.Current).Row["col1"].ToString(), null, false, 0);
		if (dataTable.Rows.Count == 0)
		{
			this.comboBoxReadOnly_15.DataSource = null;
			return;
		}
		string a = dataTable.Rows[0]["ParentKey"].ToString();
		if (!(a == ";ReportDaily;NatureDamage;HV;AirLine;") && !(a == ";ReportDaily;NatureDamage;HV;CableLine;"))
		{
			if (!(a == ";ReportDaily;NatureDamage;HV;Subs;"))
			{
				if (a == ";ReportDaily;NatureDamage;HV;Transformer;")
				{
					DataTable dataSource = new SqlDataCommand(this.SqlSettings).SelectSqlData("select id, name + \r\n                                                                isnull('/' + convert(varchar(20), convert(float, highVoltage)), '') as name\r\n                                                                from tR_Transformer \r\n                                                                where deleted = 0\r\n                                                                order by name, highvoltage");
					this.comboBoxReadOnly_15.DisplayMember = "name";
					this.comboBoxReadOnly_15.ValueMember = "id";
					this.comboBoxReadOnly_15.DataSource = dataSource;
				}
			}
			else
			{
				DataTable dataSource2 = new SqlDataCommand(this.SqlSettings).SelectSqlData("select id, Name\r\n                                                                from tP_ValueLists\r\n                                                                where ParentKey = ';SubstationType;' and isGRoup = 0 and deleted = 0\r\n                                                                order by name");
				this.comboBoxReadOnly_15.DisplayMember = "name";
				this.comboBoxReadOnly_15.ValueMember = "id";
				this.comboBoxReadOnly_15.DataSource = dataSource2;
			}
		}
		else
		{
			DataTable dataSource3 = new SqlDataCommand(this.SqlSettings).SelectSqlData("select cName.id,\r\n                                                                     cName.CableMakeup + '-' + cast(cName.wires as varchar(8)) + 'x' + \r\n                                                                     convert(varchar(20), convert(float, CName.CrossSection))  \r\n                                                                \t + isnull('+' + cast(cName.wiresAddl as varchar(8))+'x'+convert(varchar(20), convert(float, CName.CrossSectionAddl))+'(N)'  , '') \r\n                                                                \t + isnull('-' + convert(varchar(20),convert(float, cV.Value)), '')\r\n                                                                \t as name\r\n                                                                from tr_Cable cName\r\n                                                                \tleft join tr_classifier cV on cV.id = cName.idVoltage\r\n                                                                where cName.CableMakeup is not null and cName.wires is not null and cName.CrossSection is not null\r\n                                                                     and cname.CableMakeup not like '[0-9]%'\r\n                                                                order by cName.CableMakeup, cName.wires, cName.CrossSection");
			this.comboBoxReadOnly_15.DisplayMember = "name";
			this.comboBoxReadOnly_15.ValueMember = "id";
			this.comboBoxReadOnly_15.DataSource = dataSource3;
		}
		this.comboBoxReadOnly_15.SelectedIndex = -1;
	}

	private void method_49()
	{
		BindingSource bindingSource = new BindingSource();
		bindingSource.DataSource = this.dataTable_0.Copy();
		bindingSource.Filter = "ParentKey = ';ReportDaily;ActDetection;Equipment;Params;'";
		bindingSource.Sort = "name";
		this.comboBoxReadOnly_14.DisplayMember = "name";
		this.comboBoxReadOnly_14.ValueMember = "id";
		this.comboBoxReadOnly_14.DataSource = bindingSource;
	}

	private void method_50()
	{
		BindingSource bindingSource = new BindingSource();
		bindingSource.DataSource = this.dataTable_0.Copy();
		bindingSource.Filter = "ParentKey like ';VoltageLevels;MV;%'";
		bindingSource.Sort = "value";
		this.comboBoxReadOnly_13.DisplayMember = "name";
		this.comboBoxReadOnly_13.ValueMember = "id";
		this.comboBoxReadOnly_13.DataSource = bindingSource;
		BindingSource bindingSource2 = new BindingSource();
		bindingSource2.DataSource = this.dataTable_0.Copy();
		bindingSource2.Filter = "ParentKey like ';VoltageLevels;MV;%'";
		bindingSource2.Sort = "value";
		this.comboBoxReadOnly_16.DisplayMember = "name";
		this.comboBoxReadOnly_16.ValueMember = "id";
		this.comboBoxReadOnly_16.DataSource = bindingSource2;
	}

	private void method_51()
	{
		BindingSource bindingSource = new BindingSource();
		bindingSource.DataSource = this.dataTable_0.Copy();
		bindingSource.Filter = "ParentKey = ';ReportDaily;ActDetection;Equipment;NodeDetail;'";
		bindingSource.Sort = "name";
		this.comboBoxReadOnly_12.DisplayMember = "name";
		this.comboBoxReadOnly_12.ValueMember = "id";
		this.comboBoxReadOnly_12.DataSource = bindingSource;
	}

	private void method_52()
	{
		BindingSource bindingSource = new BindingSource();
		bindingSource.DataSource = this.dataTable_0.Copy();
		bindingSource.Filter = "ParentKey = ';ReportDaily;ActDetection;Equipment;NeutralState;'";
		bindingSource.Sort = "name";
		this.comboBoxReadOnly_19.DisplayMember = "name";
		this.comboBoxReadOnly_19.ValueMember = "id";
		this.comboBoxReadOnly_19.DataSource = bindingSource;
		this.comboBoxReadOnly_19.DataBindings[0].DataSourceNullValue = ((DataRowView)this.comboBoxReadOnly_19.Items[0]).Row["id"];
	}

	private void method_53()
	{
		BindingSource bindingSource = new BindingSource();
		bindingSource.DataSource = this.dataTable_0.Copy();
		bindingSource.Filter = "ParentKey = ';ReportDaily;ActDetection;Equipment;Material;'";
		bindingSource.Sort = "name";
		this.comboBoxReadOnly_18.DisplayMember = "name";
		this.comboBoxReadOnly_18.ValueMember = "id";
		this.comboBoxReadOnly_18.DataSource = bindingSource;
		this.comboBoxReadOnly_18.DataBindings[0].DataSourceNullValue = ((DataRowView)this.comboBoxReadOnly_18.Items[0]).Row["id"];
	}

	private void method_54()
	{
		BindingSource bindingSource = new BindingSource();
		bindingSource.DataSource = this.dataTable_0.Copy();
		bindingSource.Filter = "ParentKey = ';ReportDaily;ActDetection;Equipment;ClauseWork;'";
		bindingSource.Sort = "name";
		this.comboBoxReadOnly_17.DisplayMember = "name";
		this.comboBoxReadOnly_17.ValueMember = "id";
		this.comboBoxReadOnly_17.DataSource = bindingSource;
		this.comboBoxReadOnly_17.DataBindings[0].DataSourceNullValue = ((DataRowView)this.comboBoxReadOnly_17.Items[0]).Row["id"];
	}

	private void method_55()
	{
		BindingSource bindingSource = new BindingSource();
		bindingSource.DataSource = this.dataTable_0.Copy();
		bindingSource.Filter = "ParentKey = ';ReportDaily;ActDetection;Equipment;ChrDamage;'";
		bindingSource.Sort = "name";
		this.comboBoxReadOnly_21.DisplayMember = "name";
		this.comboBoxReadOnly_21.ValueMember = "id";
		this.comboBoxReadOnly_21.DataSource = bindingSource;
	}

	private void method_56()
	{
		BindingSource bindingSource = new BindingSource();
		bindingSource.DataSource = this.dataTable_0.Copy();
		bindingSource.Filter = "ParentKey = ';ReportDaily;ActDetection;Equipment;ReasonDamage;'";
		bindingSource.Sort = "name";
		this.comboBoxReadOnly_20.DisplayMember = "name";
		this.comboBoxReadOnly_20.ValueMember = "id";
		this.comboBoxReadOnly_20.DataSource = bindingSource;
	}

	private void method_57()
	{
		this.comboBoxReadOnly_22.SelectedValueChanged -= this.comboBoxReadOnly_22_SelectedValueChanged;
		this.comboBoxReadOnly_25.SelectedValueChanged -= this.comboBoxReadOnly_22_SelectedValueChanged;
		this.comboBoxReadOnly_24.SelectedValueChanged -= this.comboBoxReadOnly_22_SelectedValueChanged;
		this.comboBoxReadOnly_23.SelectedValueChanged -= this.comboBoxReadOnly_22_SelectedValueChanged;
		this.comboBoxReadOnly_28.SelectedValueChanged -= this.comboBoxReadOnly_22_SelectedValueChanged;
		this.comboBoxReadOnly_27.SelectedValueChanged -= this.comboBoxReadOnly_22_SelectedValueChanged;
		if (this.method_2() != null)
		{
			if (this.class171_0.tJ_DamageActDetection.Rows.Count > 0 && this.class171_0.tJ_DamageActDetection.Rows[0]["Comission"] != DBNull.Value)
			{
				string text = this.class171_0.tJ_DamageActDetection.Rows[0]["Comission"].ToString();
				if (!string.IsNullOrEmpty(text))
				{
					this.dataTable_4.ReadXml(new StringReader(text));
				}
			}
		}
		else
		{
			Class171 @class = new Class171();
			base.SelectSqlData(@class.tJ_DamageActDetection, true, " where Comission is not null order by idDamage desc", null, false, 1);
			if (@class.tJ_DamageActDetection.Rows.Count > 0 && @class.tJ_DamageActDetection.Rows[0]["Comission"] != DBNull.Value)
			{
				string text2 = @class.tJ_DamageActDetection.Rows[0]["Comission"].ToString();
				if (!string.IsNullOrEmpty(text2))
				{
					this.dataTable_4.ReadXml(new StringReader(text2));
				}
			}
		}
		if (this.dataTable_4.Rows.Count == 0)
		{
			this.dataTable_4.Rows.Add(new object[0]);
		}
		this.comboBoxReadOnly_22.SelectedValueChanged += this.comboBoxReadOnly_22_SelectedValueChanged;
		this.comboBoxReadOnly_25.SelectedValueChanged += this.comboBoxReadOnly_22_SelectedValueChanged;
		this.comboBoxReadOnly_24.SelectedValueChanged += this.comboBoxReadOnly_22_SelectedValueChanged;
		this.comboBoxReadOnly_23.SelectedValueChanged += this.comboBoxReadOnly_22_SelectedValueChanged;
		this.comboBoxReadOnly_28.SelectedValueChanged += this.comboBoxReadOnly_22_SelectedValueChanged;
		this.comboBoxReadOnly_27.SelectedValueChanged += this.comboBoxReadOnly_22_SelectedValueChanged;
	}

	private void comboBoxReadOnly_22_SelectedValueChanged(object sender, EventArgs e)
	{
		this.bool_0 = true;
		ComboBox comboBox = (ComboBox)sender;
		if (comboBox.SelectedIndex < 0)
		{
			if (comboBox == this.comboBoxReadOnly_22)
			{
				this.textBox_14.Text = "";
			}
			if (comboBox == this.comboBoxReadOnly_25)
			{
				this.textBox_17.Text = "";
			}
			if (comboBox == this.comboBoxReadOnly_24)
			{
				this.textBox_16.Text = "";
			}
			if (comboBox == this.comboBoxReadOnly_23)
			{
				this.textBox_15.Text = "";
			}
			if (comboBox == this.comboBoxReadOnly_28)
			{
				this.textBox_20.Text = "";
			}
			if (comboBox == this.comboBoxReadOnly_27)
			{
				this.textBox_19.Text = "";
				return;
			}
		}
		else
		{
			DataTable dataTable = new SqlDataCommand(this.SqlSettings).SelectSqlData("select t.description from tR_JobTitle t \r\n\t                inner join tR_Worker w on t.id = w.jobtitle\r\n                    where w.id = " + comboBox.SelectedValue.ToString());
			if (dataTable.Rows.Count > 0 && dataTable.Rows[0]["Description"] != DBNull.Value)
			{
				if (comboBox == this.comboBoxReadOnly_22)
				{
					this.textBox_14.Text = dataTable.Rows[0]["Description"].ToString();
				}
				if (comboBox == this.comboBoxReadOnly_25)
				{
					this.textBox_17.Text = dataTable.Rows[0]["Description"].ToString();
				}
				if (comboBox == this.comboBoxReadOnly_24)
				{
					this.textBox_16.Text = dataTable.Rows[0]["Description"].ToString();
				}
				if (comboBox == this.comboBoxReadOnly_23)
				{
					this.textBox_15.Text = dataTable.Rows[0]["Description"].ToString();
				}
				if (comboBox == this.comboBoxReadOnly_28)
				{
					this.textBox_20.Text = dataTable.Rows[0]["Description"].ToString();
				}
				if (comboBox == this.comboBoxReadOnly_27)
				{
					this.textBox_19.Text = dataTable.Rows[0]["Description"].ToString();
					return;
				}
			}
			else
			{
				if (comboBox == this.comboBoxReadOnly_25)
				{
					this.textBox_17.Text = "";
				}
				if (comboBox == this.comboBoxReadOnly_24)
				{
					this.textBox_16.Text = "";
				}
				if (comboBox == this.comboBoxReadOnly_23)
				{
					this.textBox_15.Text = "";
				}
				if (comboBox == this.comboBoxReadOnly_28)
				{
					this.textBox_20.Text = "";
				}
				if (comboBox == this.comboBoxReadOnly_27)
				{
					this.textBox_19.Text = "";
				}
			}
		}
	}

	private void method_58(Control.ControlCollection controlCollection_0)
	{
		using (IEnumerator enumerator = controlCollection_0.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				Control cb = (Control)enumerator.Current;
				if (cb is ComboBox)
				{
					cb.Resize += delegate(object sender, EventArgs e)
					{
						if (cb is ComboBox && !cb.Focused)
						{
							((ComboBox)cb).SelectionLength = 0;
						}
					};
				}
				this.method_58(cb.Controls);
			}
		}
	}

	private void method_59()
	{
		if (!this.method_0() && !this.checkBox_3.Checked)
		{
			this.comboBoxReadOnly_1.ReadOnly = false;
			this.comboBoxReadOnly_0.ReadOnly = false;
			this.checkBox_0.Enabled = true;
			this.button_2.Enabled = true;
			Control control = this.nullableDateTimePicker_0;
			Control control2 = this.checkBox_1;
			this.button_4.Enabled = true;
			control2.Enabled = true;
			control.Enabled = true;
			this.button_5.Enabled = true;
			ComboBoxReadOnly comboBoxReadOnly = this.comboBoxReadOnly_2;
			ComboBoxReadOnly comboBoxReadOnly2 = this.comboBoxReadOnly_3;
			this.comboBoxReadOnly_4.ReadOnly = false;
			comboBoxReadOnly2.ReadOnly = false;
			comboBoxReadOnly.ReadOnly = false;
			ComboBoxReadOnly comboBoxReadOnly3 = this.comboBoxReadOnly_5;
			this.comboBoxReadOnly_6.ReadOnly = false;
			comboBoxReadOnly3.ReadOnly = false;
			this.dataGridViewExcelFilter_0.ReadOnly = false;
			ComboBoxReadOnly comboBoxReadOnly4 = this.comboBoxReadOnly_7;
			ComboBoxReadOnly comboBoxReadOnly5 = this.comboBoxReadOnly_8;
			this.richTextBox_2.ReadOnly = false;
			comboBoxReadOnly5.ReadOnly = false;
			comboBoxReadOnly4.ReadOnly = false;
			this.dataGridViewExcelFilter_1.ReadOnly = false;
			ComboBoxReadOnly comboBoxReadOnly6 = this.comboBoxReadOnly_11;
			TextBoxBase textBoxBase = this.richTextBox_1;
			ComboBoxReadOnly comboBoxReadOnly7 = this.comboBoxReadOnly_10;
			this.comboBoxReadOnly_9.ReadOnly = false;
			comboBoxReadOnly7.ReadOnly = false;
			textBoxBase.ReadOnly = false;
			comboBoxReadOnly6.ReadOnly = false;
			this.toolStrip_0.Enabled = true;
			this.dataGridView_0.ReadOnly = false;
			this.method_60(false);
			this.textBox_13.ReadOnly = false;
			ComboBoxReadOnly comboBoxReadOnly8 = this.comboBoxReadOnly_22;
			this.textBox_14.ReadOnly = false;
			comboBoxReadOnly8.ReadOnly = false;
			ComboBoxReadOnly comboBoxReadOnly9 = this.comboBoxReadOnly_25;
			ComboBoxReadOnly comboBoxReadOnly10 = this.comboBoxReadOnly_24;
			ComboBoxReadOnly comboBoxReadOnly11 = this.comboBoxReadOnly_23;
			ComboBoxReadOnly comboBoxReadOnly12 = this.comboBoxReadOnly_28;
			this.comboBoxReadOnly_27.ReadOnly = false;
			comboBoxReadOnly12.ReadOnly = false;
			comboBoxReadOnly11.ReadOnly = false;
			comboBoxReadOnly10.ReadOnly = false;
			comboBoxReadOnly9.ReadOnly = false;
			TextBoxBase textBoxBase2 = this.textBox_17;
			TextBoxBase textBoxBase3 = this.textBox_16;
			TextBoxBase textBoxBase4 = this.textBox_15;
			TextBoxBase textBoxBase5 = this.textBox_20;
			this.textBox_19.ReadOnly = false;
			textBoxBase5.ReadOnly = false;
			textBoxBase4.ReadOnly = false;
			textBoxBase3.ReadOnly = false;
			textBoxBase2.ReadOnly = false;
			this.richTextBox_0.ReadOnly = false;
		}
		else
		{
			this.comboBoxReadOnly_1.ReadOnly = true;
			this.comboBoxReadOnly_0.ReadOnly = true;
			this.checkBox_0.Enabled = false;
			this.button_2.Enabled = false;
			Control control3 = this.nullableDateTimePicker_0;
			Control control4 = this.checkBox_1;
			this.button_4.Enabled = false;
			control4.Enabled = false;
			control3.Enabled = false;
			this.button_5.Enabled = false;
			ComboBoxReadOnly comboBoxReadOnly13 = this.comboBoxReadOnly_2;
			ComboBoxReadOnly comboBoxReadOnly14 = this.comboBoxReadOnly_3;
			this.comboBoxReadOnly_4.ReadOnly = true;
			comboBoxReadOnly14.ReadOnly = true;
			comboBoxReadOnly13.ReadOnly = true;
			ComboBoxReadOnly comboBoxReadOnly15 = this.comboBoxReadOnly_5;
			this.comboBoxReadOnly_6.ReadOnly = true;
			comboBoxReadOnly15.ReadOnly = true;
			this.dataGridViewExcelFilter_0.ReadOnly = true;
			ComboBoxReadOnly comboBoxReadOnly16 = this.comboBoxReadOnly_7;
			ComboBoxReadOnly comboBoxReadOnly17 = this.comboBoxReadOnly_8;
			this.richTextBox_2.ReadOnly = true;
			comboBoxReadOnly17.ReadOnly = true;
			comboBoxReadOnly16.ReadOnly = true;
			this.dataGridViewExcelFilter_1.ReadOnly = true;
			ComboBoxReadOnly comboBoxReadOnly18 = this.comboBoxReadOnly_11;
			TextBoxBase textBoxBase6 = this.richTextBox_1;
			ComboBoxReadOnly comboBoxReadOnly19 = this.comboBoxReadOnly_10;
			this.comboBoxReadOnly_9.ReadOnly = true;
			comboBoxReadOnly19.ReadOnly = true;
			textBoxBase6.ReadOnly = true;
			comboBoxReadOnly18.ReadOnly = true;
			this.toolStrip_0.Enabled = false;
			this.dataGridView_0.ReadOnly = true;
			this.method_60(true);
			this.textBox_13.ReadOnly = true;
			ComboBoxReadOnly comboBoxReadOnly20 = this.comboBoxReadOnly_22;
			this.textBox_14.ReadOnly = true;
			comboBoxReadOnly20.ReadOnly = true;
			ComboBoxReadOnly comboBoxReadOnly21 = this.comboBoxReadOnly_25;
			ComboBoxReadOnly comboBoxReadOnly22 = this.comboBoxReadOnly_24;
			ComboBoxReadOnly comboBoxReadOnly23 = this.comboBoxReadOnly_23;
			ComboBoxReadOnly comboBoxReadOnly24 = this.comboBoxReadOnly_28;
			this.comboBoxReadOnly_27.ReadOnly = true;
			comboBoxReadOnly24.ReadOnly = true;
			comboBoxReadOnly23.ReadOnly = true;
			comboBoxReadOnly22.ReadOnly = true;
			comboBoxReadOnly21.ReadOnly = true;
			TextBoxBase textBoxBase7 = this.textBox_17;
			TextBoxBase textBoxBase8 = this.textBox_16;
			TextBoxBase textBoxBase9 = this.textBox_15;
			TextBoxBase textBoxBase10 = this.textBox_20;
			this.textBox_19.ReadOnly = true;
			textBoxBase10.ReadOnly = true;
			textBoxBase9.ReadOnly = true;
			textBoxBase8.ReadOnly = true;
			textBoxBase7.ReadOnly = true;
			this.richTextBox_0.ReadOnly = true;
		}
		if (this.method_0())
		{
			this.checkBox_3.Enabled = false;
			this.comboBoxReadOnly_26.ReadOnly = true;
			this.nullableDateTimePicker_5.Enabled = false;
			this.button_0.Enabled = false;
			return;
		}
		this.button_0.Enabled = true;
	}

	private void method_60(bool bool_2)
	{
		this.checkBox_2.Enabled = !bool_2;
		ComboBoxReadOnly comboBoxReadOnly = this.comboBoxReadOnly_15;
		ComboBoxReadOnly comboBoxReadOnly2 = this.comboBoxReadOnly_14;
		this.comboBoxReadOnly_13.ReadOnly = bool_2;
		comboBoxReadOnly2.ReadOnly = bool_2;
		comboBoxReadOnly.ReadOnly = bool_2;
		ComboBoxReadOnly comboBoxReadOnly3 = this.comboBoxReadOnly_12;
		TextBoxBase textBoxBase = this.ouoCyeHwemd;
		this.comboBoxReadOnly_16.ReadOnly = bool_2;
		textBoxBase.ReadOnly = bool_2;
		comboBoxReadOnly3.ReadOnly = bool_2;
		DataGridViewBand dataGridViewBand = this.dataGridViewTextBoxColumn_10;
		this.textBox_21.ReadOnly = bool_2;
		dataGridViewBand.ReadOnly = bool_2;
		TextBoxBase textBoxBase2 = this.textBox_5;
		TextBoxBase textBoxBase3 = this.textBox_4;
		this.textBox_6.ReadOnly = bool_2;
		textBoxBase3.ReadOnly = bool_2;
		textBoxBase2.ReadOnly = bool_2;
		ComboBoxReadOnly comboBoxReadOnly4 = this.comboBoxReadOnly_19;
		this.textBox_9.ReadOnly = bool_2;
		comboBoxReadOnly4.ReadOnly = bool_2;
		TextBoxBase textBoxBase4 = this.textBox_8;
		this.textBox_7.ReadOnly = bool_2;
		textBoxBase4.ReadOnly = bool_2;
		ComboBoxReadOnly comboBoxReadOnly5 = this.comboBoxReadOnly_18;
		this.comboBoxReadOnly_17.ReadOnly = bool_2;
		comboBoxReadOnly5.ReadOnly = bool_2;
		ComboBoxReadOnly comboBoxReadOnly6 = this.comboBoxReadOnly_21;
		this.comboBoxReadOnly_20.ReadOnly = bool_2;
		comboBoxReadOnly6.ReadOnly = bool_2;
		TextBoxBase textBoxBase5 = this.textBox_11;
		TextBoxBase textBoxBase6 = this.textBox_10;
		this.textBox_12.ReadOnly = bool_2;
		textBoxBase6.ReadOnly = bool_2;
		textBoxBase5.ReadOnly = bool_2;
		this.nullableDateTimePicker_3.Enabled = (this.nullableDateTimePicker_4.Enabled = !bool_2);
	}

	private void checkBox_3_CheckedChanged(object sender, EventArgs e)
	{
		this.bool_0 = true;
		this.method_59();
	}

	private void tabControl_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.tabControl_0.SelectedTab == this.tabPage_3)
		{
			ReportViewerRus reportViewerRus = new ReportViewerRus();
			reportViewerRus.LocalReport.ReportEmbeddedResource = "Documents.Forms.DailyReport.ActDetection.ReportActDetection.rdlc";
			reportViewerRus.Dock = DockStyle.Fill;
			this.tabPage_3.Controls.Clear();
			this.tabPage_3.Controls.Add(reportViewerRus);
			ReportDataSource reportDataSource = new ReportDataSource();
			reportDataSource.Name = "dsDamage";
			reportDataSource.Value = this.bindingSource_3;
			reportViewerRus.LocalReport.DataSources.Add(reportDataSource);
			reportDataSource = new ReportDataSource();
			reportDataSource.Name = "dsActDetection";
			reportDataSource.Value = new BindingSource
			{
				DataSource = this.class171_0.tJ_DamageActDetection
			};
			reportViewerRus.LocalReport.DataSources.Add(reportDataSource);
			List<ReportParameter> list = new List<ReportParameter>();
			if (this.comboBoxReadOnly_2.SelectedIndex >= 0)
			{
				list.Add(new ReportParameter("Org", ((DataRowView)this.comboBoxReadOnly_2.SelectedItem).Row["name"].ToString()));
			}
			if (this.comboBoxReadOnly_3.SelectedIndex >= 0)
			{
				list.Add(new ReportParameter("signCrashCode", ((DataRowView)this.comboBoxReadOnly_3.SelectedItem).Row["name"].ToString()));
				list.Add(new ReportParameter("signCrash", ((DataRowView)this.comboBoxReadOnly_3.SelectedItem).Row["comment"].ToString()));
			}
			if (this.comboBoxReadOnly_4.SelectedIndex >= 0)
			{
				list.Add(new ReportParameter("typeEquipmentCode", ((DataRowView)this.comboBoxReadOnly_4.SelectedItem).Row["name"].ToString()));
				list.Add(new ReportParameter("typeEquipment", ((DataRowView)this.comboBoxReadOnly_4.SelectedItem).Row["comment"].ToString()));
			}
			if (this.comboBoxReadOnly_5.SelectedIndex >= 0)
			{
				list.Add(new ReportParameter("reasonCrashEqCode", ((DataRowView)this.comboBoxReadOnly_5.SelectedItem).Row["name"].ToString()));
				list.Add(new ReportParameter("reasonCrashEq", ((DataRowView)this.comboBoxReadOnly_5.SelectedItem).Row["comment"].ToString()));
			}
			if (this.comboBoxReadOnly_6.SelectedIndex >= 0)
			{
				list.Add(new ReportParameter("reasonCrashCode", ((DataRowView)this.comboBoxReadOnly_6.SelectedItem).Row["name"].ToString()));
				list.Add(new ReportParameter("reasonCrash", ((DataRowView)this.comboBoxReadOnly_6.SelectedItem).Row["comment"].ToString()));
			}
			list.Add(new ReportParameter("schmObj", this.textBox_3.Text));
			if (this.comboBoxReadOnly_7.SelectedIndex >= 0)
			{
				list.Add(new ReportParameter("statusBeforeCrash", ((DataRowView)this.comboBoxReadOnly_7.SelectedItem).Row["comment"].ToString()));
			}
			if (!string.IsNullOrEmpty(this.richTextBox_2.Text))
			{
				list.Add(new ReportParameter("statusCurrentCrash", this.richTextBox_2.Text));
			}
			else if (this.comboBoxReadOnly_8.SelectedIndex >= 0)
			{
				list.Add(new ReportParameter("statusCurrentCrash", ((DataRowView)this.comboBoxReadOnly_8.SelectedItem).Row["comment"].ToString()));
			}
			reportDataSource = new ReportDataSource();
			reportDataSource.Name = "ds23";
			BindingSource bindingSource = new BindingSource();
			bindingSource.DataSource = this.class171_0.table23;
			this.class171_0.table23.Clear();
			foreach (object obj in ((IEnumerable)this.dataGridViewExcelFilter_1.Rows))
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
				DataRow dataRow = this.class171_0.table23.NewRow();
				dataRow["Description"] = dataGridViewRow.Cells[this.dataGridViewComboBoxColumn_0.Name].FormattedValue.ToString();
				dataRow["NPA"] = dataGridViewRow.Cells[this.dataGridViewComboBoxColumn_1.Name].FormattedValue.ToString();
				if (dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_0.Name].Value != null)
				{
					dataRow["punktNPA"] = dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_0.Name].Value.ToString();
				}
				dataRow["Org"] = dataGridViewRow.Cells[this.dataGridViewComboBoxColumn_2.Name].FormattedValue.ToString();
				this.class171_0.table23.Rows.Add(dataRow);
			}
			if (this.class171_0.table23.Rows.Count > 0)
			{
				this.class171_0.table23.Rows.RemoveAt(this.class171_0.table23.Rows.Count - 1);
			}
			reportDataSource.Value = bindingSource;
			reportViewerRus.LocalReport.DataSources.Add(reportDataSource);
			if (!string.IsNullOrEmpty(this.richTextBox_1.Text))
			{
				list.Add(new ReportParameter("reasonBeginCrash", this.richTextBox_1.Text));
			}
			else if (this.comboBoxReadOnly_11.SelectedIndex >= 0)
			{
				list.Add(new ReportParameter("reasonBeginCrashCode", ((DataRowView)this.comboBoxReadOnly_11.SelectedItem).Row["name"].ToString()));
				list.Add(new ReportParameter("reasonBeginCrash", ((DataRowView)this.comboBoxReadOnly_11.SelectedItem).Row["comment"].ToString()));
			}
			if (this.comboBoxReadOnly_10.SelectedIndex >= 0)
			{
				list.Add(new ReportParameter("classifierDamage", ((DataRowView)this.comboBoxReadOnly_10.SelectedItem).Row["name"].ToString()));
			}
			if (this.comboBoxReadOnly_9.SelectedIndex >= 0)
			{
				list.Add(new ReportParameter("fault", ((DataRowView)this.comboBoxReadOnly_9.SelectedItem).Row["name"].ToString()));
			}
			reportDataSource = new ReportDataSource();
			reportDataSource.Name = "ds31";
			BindingSource bindingSource2 = new BindingSource();
			bindingSource2.DataSource = this.class171_0.table31;
			this.class171_0.table31.Clear();
			foreach (object obj2 in ((IEnumerable)this.dataGridViewExcelFilter_0.Rows))
			{
				DataGridViewRow dataGridViewRow2 = (DataGridViewRow)obj2;
				DataRow dataRow2 = this.class171_0.table31.NewRow();
				dataRow2["Measure"] = dataGridViewRow2.Cells[this.dataGridViewComboBoxColumn_3.Name].FormattedValue.ToString();
				if (dataGridViewRow2.Cells[this.dataGridViewFilterDateTimePickerColumn_0.Name].Value != null && dataGridViewRow2.Cells[this.dataGridViewFilterDateTimePickerColumn_0.Name].Value != DBNull.Value)
				{
					dataRow2["date"] = Convert.ToDateTime(dataGridViewRow2.Cells[this.dataGridViewFilterDateTimePickerColumn_0.Name].Value).ToString("MMMM yyyy");
				}
				dataRow2["Org"] = dataGridViewRow2.Cells[this.dataGridViewComboBoxColumn_4.Name].FormattedValue.ToString();
				this.class171_0.table31.Rows.Add(dataRow2);
			}
			if (this.class171_0.table31.Rows.Count > 0)
			{
				this.class171_0.table31.Rows.RemoveAt(this.class171_0.table31.Rows.Count - 1);
			}
			reportDataSource.Value = bindingSource2;
			reportViewerRus.LocalReport.DataSources.Add(reportDataSource);
			reportDataSource = new ReportDataSource();
			reportDataSource.Name = "ds4";
			BindingSource bindingSource3 = new BindingSource();
			bindingSource3.DataSource = this.class171_0.table4;
			this.class171_0.table4.Clear();
			int num = 1;
			for (int i = 0; i < this.class171_0.tJ_DamageCharacter.Rows.Count; i++)
			{
				DataRow dataRow3 = this.class171_0.tJ_DamageCharacter.Rows[i];
				if (dataRow3.RowState != DataRowState.Deleted)
				{
					DataRow dataRow4 = this.class171_0.table4.NewRow();
					dataRow4["num"] = "4." + num.ToString() + ".";
					dataRow4["Description"] = "Отказавшее оборудование: ";
					dataRow4["Description"] = dataRow4["Description"].ToString() + this.dataGridView_0[this.dataGridViewComboBoxColumn_6.Name, i].FormattedValue.ToString();
					if (this.dataGridView_0[this.dataGridViewTextBoxColumn_10.Name, i].Value != null)
					{
						dataRow4["Description"] = dataRow4["Description"].ToString() + "   " + this.dataGridView_0[this.dataGridViewTextBoxColumn_10.Name, i].Value.ToString();
					}
					if (this.dataGridView_0[this.dataGridViewTextBoxColumn_14.Name, i].Value != null)
					{
						dataRow4["Description"] = dataRow4["Description"].ToString() + "   " + this.dataGridView_0[this.dataGridViewTextBoxColumn_14.Name, i].Value.ToString();
					}
					this.class171_0.table4.Rows.Add(dataRow4);
					num++;
					dataRow4 = this.class171_0.table4.NewRow();
					dataRow4["num"] = "4." + num.ToString() + ".";
					dataRow4["Description"] = "Марка: ";
					if (dataRow3["idMark"] != DBNull.Value && dataRow3["col1"] != DBNull.Value)
					{
						DataTable dataTable = this.method_12();
						base.SelectSqlData(dataTable, true, " where id = " + dataRow3["col1"].ToString(), null, false, 0);
						if (dataTable.Rows.Count > 0)
						{
							string a = dataTable.Rows[0]["ParentKey"].ToString();
							if (!(a == ";ReportDaily;NatureDamage;HV;AirLine;") && !(a == ";ReportDaily;NatureDamage;HV;CableLine;"))
							{
								if (!(a == ";ReportDaily;NatureDamage;HV;Subs;"))
								{
									if (a == ";ReportDaily;NatureDamage;HV;Transformer;")
									{
										DataTable dataTable2 = new SqlDataCommand(this.SqlSettings).SelectSqlData("select id, name + \r\n                                                                isnull('/' + convert(varchar(20), convert(float, highVoltage)), '') as name\r\n                                                                from tR_Transformer \r\n                                                                where id = " + dataRow3["idMark"].ToString() + " order by name, highvoltage");
										if (dataTable2.Rows.Count > 0)
										{
											dataRow4["Description"] = dataRow4["Description"].ToString() + dataTable2.Rows[0]["Name"].ToString();
										}
									}
								}
								else
								{
									DataTable dataTable3 = new SqlDataCommand(this.SqlSettings).SelectSqlData("select id, Name\r\n                                                                from tP_ValueLists\r\n                                                                where ParentKey = ';SubstationType;' and isGRoup = 0 and deleted = 0\r\n                                                                    and id = " + dataRow3["idMark"].ToString() + " order by name");
									if (dataTable3.Rows.Count > 0)
									{
										dataRow4["Description"] = dataRow4["Description"].ToString() + dataTable3.Rows[0]["Name"].ToString();
									}
								}
							}
							else
							{
								DataTable dataTable4 = new SqlDataCommand(this.SqlSettings).SelectSqlData("select id, CableMakeup + ' ' + cast(wires as varchar(8)) + 'x' + \r\n                                            convert(varchar(20), convert(float, CrossSection)) as name from tr_Cable \r\n                                            where id = " + dataRow3["idMark"].ToString() + " order by CableMakeup, wires, CrossSection");
								if (dataTable4.Rows.Count > 0)
								{
									dataRow4["Description"] = dataRow4["Description"].ToString() + dataTable4.Rows[0]["Name"].ToString();
								}
							}
						}
					}
					this.class171_0.table4.Rows.Add(dataRow4);
					num++;
					dataRow4 = this.class171_0.table4.NewRow();
					dataRow4["num"] = "4." + num.ToString() + ".";
					dataRow4["Description"] = "Параметры: ";
					if (dataRow3["idParameters"] != DBNull.Value)
					{
						DataRow[] array = this.dataTable_0.Select("id = " + dataRow3["idParameters"].ToString());
						if (array.Length != 0)
						{
							dataRow4["Description"] = dataRow4["Description"].ToString() + array[0]["Name"].ToString();
						}
					}
					this.class171_0.table4.Rows.Add(dataRow4);
					num++;
					dataRow4 = this.class171_0.table4.NewRow();
					dataRow4["num"] = "4." + num.ToString() + ".";
					dataRow4["Description"] = "Конструктивное напряжение: ";
					if (dataRow3["idVoltage"] != DBNull.Value)
					{
						DataRow[] array2 = this.dataTable_0.Select("id = " + dataRow3["idVoltage"].ToString());
						if (array2.Length != 0)
						{
							dataRow4["Description"] = dataRow4["Description"].ToString() + array2[0]["Name"].ToString();
						}
					}
					this.class171_0.table4.Rows.Add(dataRow4);
					num++;
					dataRow4 = this.class171_0.table4.NewRow();
					dataRow4["num"] = "4." + num.ToString() + ".";
					dataRow4["Description"] = "Узел, деталь: ";
					if (dataRow3["NodeDetail"] != DBNull.Value)
					{
						DataRow[] array3 = this.dataTable_0.Select("id = " + dataRow3["NodeDetail"].ToString());
						if (array3.Length != 0)
						{
							dataRow4["Description"] = dataRow4["Description"].ToString() + array3[0]["Name"].ToString();
						}
					}
					if (dataRow3["NodeDetailTxt"] != DBNull.Value)
					{
						dataRow4["Description"] = dataRow4["Description"].ToString() + " " + dataRow3["NodeDetailTxt"].ToString();
					}
					this.class171_0.table4.Rows.Add(dataRow4);
					num++;
					dataRow4 = this.class171_0.table4.NewRow();
					dataRow4["num"] = "4." + num.ToString() + ".";
					dataRow4["Description"] = "Количество отказавшего оборудования, узлов: ";
					if (dataRow3["CountDefectEquipment"] != DBNull.Value)
					{
						dataRow4["Description"] = dataRow4["Description"].ToString() + dataRow3["CountDefectEquipment"].ToString();
					}
					this.class171_0.table4.Rows.Add(dataRow4);
					num++;
					dataRow4 = this.class171_0.table4.NewRow();
					dataRow4["num"] = "4." + num.ToString() + ".";
					dataRow4["Description"] = "Напряжение сети: ";
					if (dataRow3["idVoltageSeti"] != DBNull.Value)
					{
						DataRow[] array4 = this.dataTable_0.Select("id = " + dataRow3["idVoltageSEti"].ToString());
						if (array4.Length != 0)
						{
							dataRow4["Description"] = dataRow4["Description"].ToString() + array4[0]["Name"].ToString();
						}
					}
					this.class171_0.table4.Rows.Add(dataRow4);
					num++;
					dataRow4 = this.class171_0.table4.NewRow();
					dataRow4["num"] = "4." + num.ToString() + ".";
					dataRow4["Description"] = "Изготовитель оборудования или повредившегося узла: ";
					if (dataRow3["Manufacturer"] != DBNull.Value)
					{
						dataRow4["Description"] = dataRow4["Description"].ToString() + dataRow3["Manufacturer"].ToString();
					}
					this.class171_0.table4.Rows.Add(dataRow4);
					num++;
					dataRow4 = this.class171_0.table4.NewRow();
					dataRow4["num"] = "4." + num.ToString() + ".";
					dataRow4["Description"] = "Заводской номер: ";
					if (dataRow3["FactoryNumber"] != DBNull.Value)
					{
						dataRow4["Description"] = dataRow4["Description"].ToString() + dataRow3["FactoryNumber"].ToString();
					}
					this.class171_0.table4.Rows.Add(dataRow4);
					num++;
					dataRow4 = this.class171_0.table4.NewRow();
					dataRow4["num"] = "4." + num.ToString() + ".";
					dataRow4["Description"] = "Год изготовления оборудования: ";
					if (dataRow3["YearManufacture"] != DBNull.Value)
					{
						dataRow4["Description"] = dataRow4["Description"].ToString() + dataRow3["YearManufacture"].ToString() + "г.";
					}
					this.class171_0.table4.Rows.Add(dataRow4);
					num++;
					dataRow4 = this.class171_0.table4.NewRow();
					dataRow4["num"] = "4." + num.ToString() + ".";
					dataRow4["Description"] = "Состояние нейтрали: ";
					if (dataRow3["idNeutralState"] != DBNull.Value)
					{
						DataRow[] array5 = this.dataTable_0.Select("id = " + dataRow3["idNeutralState"].ToString());
						if (array5.Length != 0)
						{
							dataRow4["Description"] = dataRow4["Description"].ToString() + array5[0]["Name"].ToString();
						}
					}
					this.class171_0.table4.Rows.Add(dataRow4);
					num++;
					dataRow4 = this.class171_0.table4.NewRow();
					dataRow4["num"] = "4." + num.ToString() + ".";
					dataRow4["Description"] = "Условия отказа оборудования, % относительная нагрузка кабеля, число цепей ВЛ: ";
					if (dataRow3["ClauseFail"] != DBNull.Value)
					{
						dataRow4["Description"] = dataRow4["Description"].ToString() + dataRow3["ClauseFail"].ToString();
					}
					this.class171_0.table4.Rows.Add(dataRow4);
					num++;
					dataRow4 = this.class171_0.table4.NewRow();
					dataRow4["num"] = "4." + num.ToString() + ".";
					dataRow4["Description"] = "Продолжительность работы оборудования с перегрузкой: ";
					if (dataRow3["LengthOverload"] != DBNull.Value)
					{
						dataRow4["Description"] = dataRow4["Description"].ToString() + dataRow3["LengthOverload"].ToString();
					}
					this.class171_0.table4.Rows.Add(dataRow4);
					num++;
					dataRow4 = this.class171_0.table4.NewRow();
					dataRow4["num"] = "4." + num.ToString() + ".";
					dataRow4["Description"] = "Длина КЛ, ВЛ, м: ";
					if (dataRow3["LengthLine"] != DBNull.Value)
					{
						dataRow4["Description"] = dataRow4["Description"].ToString() + dataRow3["LengthLine"].ToString();
					}
					this.class171_0.table4.Rows.Add(dataRow4);
					num++;
					dataRow4 = this.class171_0.table4.NewRow();
					dataRow4["num"] = "4." + num.ToString() + ".";
					dataRow4["Description"] = "Материал: ";
					if (dataRow3["idMaterial"] != DBNull.Value)
					{
						DataRow[] array6 = this.dataTable_0.Select("id = " + dataRow3["idMaterial"].ToString());
						if (array6.Length != 0)
						{
							dataRow4["Description"] = dataRow4["Description"].ToString() + array6[0]["Name"].ToString();
						}
					}
					this.class171_0.table4.Rows.Add(dataRow4);
					num++;
					dataRow4 = this.class171_0.table4.NewRow();
					dataRow4["num"] = "4." + num.ToString() + ".";
					dataRow4["Description"] = "Условия работы: ";
					if (dataRow3["ClauseWork"] != DBNull.Value)
					{
						DataRow[] array7 = this.dataTable_0.Select("id = " + dataRow3["ClauseWork"].ToString());
						if (array7.Length != 0)
						{
							dataRow4["Description"] = dataRow4["Description"].ToString() + array7[0]["Name"].ToString();
						}
					}
					this.class171_0.table4.Rows.Add(dataRow4);
					num++;
					dataRow4 = this.class171_0.table4.NewRow();
					dataRow4["num"] = "4." + num.ToString() + ".";
					dataRow4["Description"] = "Характер повреждения: ";
					if (this.comboBoxReadOnly_10.SelectedIndex >= 0)
					{
						dataRow4["Description"] = dataRow4["Description"].ToString() + ((DataRowView)this.comboBoxReadOnly_10.SelectedItem).Row["name"].ToString();
					}
					this.class171_0.table4.Rows.Add(dataRow4);
					num++;
					dataRow4 = this.class171_0.table4.NewRow();
					dataRow4["num"] = "4." + num.ToString() + ".";
					dataRow4["Description"] = "Причина повреждения: ";
					if (this.comboBoxReadOnly_11.SelectedIndex >= 0)
					{
						dataRow4["Description"] = dataRow4["Description"].ToString() + ((DataRowView)this.comboBoxReadOnly_11.SelectedItem).Row["comment"].ToString().ToLower();
					}
					this.class171_0.table4.Rows.Add(dataRow4);
					num++;
					dataRow4 = this.class171_0.table4.NewRow();
					dataRow4["num"] = "4." + num.ToString() + ".";
					dataRow4["Description"] = "Сопутствующие обстоятельства: ";
					if (dataRow3["AssociatedFact"] != DBNull.Value)
					{
						dataRow4["Description"] = dataRow4["Description"].ToString() + dataRow3["AssociatedFact"].ToString();
					}
					this.class171_0.table4.Rows.Add(dataRow4);
					num++;
					dataRow4 = this.class171_0.table4.NewRow();
					dataRow4["num"] = "4." + num.ToString() + ".";
					dataRow4["Description"] = "Срок службы оборудования от последнего капительного ремонта:\r\n \t\t 1) Начало эксплуатации: ";
					if (dataRow3["yearBegEquipment"] != DBNull.Value)
					{
						dataRow4["Description"] = dataRow4["Description"].ToString() + dataRow3["yearBegEquipment"].ToString() + "г.";
					}
					this.class171_0.table4.Rows.Add(dataRow4);
					num++;
					dataRow4 = this.class171_0.table4.NewRow();
					dataRow4["num"] = "4." + num.ToString() + ".";
					dataRow4["Description"] = "Срок службы поврежденного узла: ";
					if (dataRow3["lenghtWorkEquipment"] != DBNull.Value)
					{
						dataRow4["Description"] = dataRow4["Description"].ToString() + dataRow3["lenghtWorkEquipment"].ToString() + " " + this.method_61(Convert.ToInt32(dataRow3["lenghtWorkEquipment"]));
					}
					this.class171_0.table4.Rows.Add(dataRow4);
					num++;
					dataRow4 = this.class171_0.table4.NewRow();
					dataRow4["num"] = "4." + num.ToString() + ".";
					dataRow4["Description"] = "Последние эксплуатационные испытания: ";
					if (dataRow3["LastDateTest"] != DBNull.Value)
					{
						dataRow4["Description"] = dataRow4["Description"].ToString() + Convert.ToDateTime(dataRow3["LastDateTest"]).ToString("yyyy") + "г.";
					}
					this.class171_0.table4.Rows.Add(dataRow4);
					num++;
					dataRow4 = this.class171_0.table4.NewRow();
					dataRow4["num"] = "4." + num.ToString() + ".";
					dataRow4["Description"] = "Дата восстановления: ";
					if (dataRow3["timeRecovery"] != DBNull.Value)
					{
						dataRow4["Description"] = dataRow4["Description"].ToString() + Convert.ToDateTime(dataRow3["timeRecovery"]).ToString("dd.MM.yyyy") + "г.";
					}
					this.class171_0.table4.Rows.Add(dataRow4);
					num++;
				}
			}
			reportDataSource.Value = bindingSource3;
			reportViewerRus.LocalReport.DataSources.Add(reportDataSource);
			list.Add(new ReportParameter("Order", this.textBox_13.Text));
			if (this.comboBoxReadOnly_22.SelectedIndex >= 0)
			{
				string text = ((DataRowView)this.comboBoxReadOnly_22.SelectedItem).Row["fio"].ToString();
				if (!string.IsNullOrEmpty(this.textBox_14.Text))
				{
					text = text + ", " + this.textBox_14.Text.ToLower();
				}
				list.Add(new ReportParameter("Chairman", text));
			}
			if (this.comboBoxReadOnly_25.SelectedIndex >= 0)
			{
				string text2 = ((DataRowView)this.comboBoxReadOnly_25.SelectedItem).Row["fio"].ToString();
				if (!string.IsNullOrEmpty(this.textBox_17.Text))
				{
					text2 = text2 + ", " + this.textBox_17.Text.ToLower();
				}
				list.Add(new ReportParameter("Comission1", text2));
			}
			if (this.comboBoxReadOnly_24.SelectedIndex >= 0)
			{
				string text3 = ((DataRowView)this.comboBoxReadOnly_24.SelectedItem).Row["fio"].ToString();
				if (!string.IsNullOrEmpty(this.textBox_16.Text))
				{
					text3 = text3 + ", " + this.textBox_16.Text.ToLower();
				}
				list.Add(new ReportParameter("Comission2", text3));
			}
			if (this.comboBoxReadOnly_23.SelectedIndex >= 0)
			{
				string text4 = ((DataRowView)this.comboBoxReadOnly_23.SelectedItem).Row["fio"].ToString();
				if (!string.IsNullOrEmpty(this.textBox_15.Text))
				{
					text4 = text4 + ", " + this.textBox_15.Text.ToLower();
				}
				list.Add(new ReportParameter("Comission3", text4));
			}
			if (this.comboBoxReadOnly_28.SelectedIndex >= 0)
			{
				string text5 = ((DataRowView)this.comboBoxReadOnly_28.SelectedItem).Row["fio"].ToString();
				if (!string.IsNullOrEmpty(this.textBox_20.Text))
				{
					text5 = text5 + ", " + this.textBox_20.Text.ToLower();
				}
				list.Add(new ReportParameter("Comission4", text5));
			}
			if (this.comboBoxReadOnly_27.SelectedIndex >= 0)
			{
				string text6 = ((DataRowView)this.comboBoxReadOnly_27.SelectedItem).Row["fio"].ToString();
				if (!string.IsNullOrEmpty(this.textBox_19.Text))
				{
					text6 = text6 + ", " + this.textBox_19.Text.ToLower();
				}
				list.Add(new ReportParameter("Comission5", text6));
			}
			if (this.comboBoxReadOnly_1.SelectedIndex >= 0)
			{
				string text7 = ((DataRowView)this.comboBoxReadOnly_1.SelectedItem).Row["fio"].ToString();
				if (this.comboBoxReadOnly_1.SelectedIndex >= 0)
				{
					DataTable dataTable5 = new SqlDataCommand(this.SqlSettings).SelectSqlData("select t.description from tR_JobTitle t \r\n\t                                                    inner join tR_Worker w on t.id = w.jobtitle\r\n                                                        where w.id = " + this.comboBoxReadOnly_1.SelectedValue.ToString());
					if (dataTable5.Rows.Count > 0 && dataTable5.Rows[0]["Description"] != DBNull.Value)
					{
						text7 = text7 + ", " + dataTable5.Rows[0]["Description"].ToString().ToLower();
					}
				}
				list.Add(new ReportParameter("Compiler", text7));
			}
			reportViewerRus.LocalReport.SetParameters(list);
			reportViewerRus.RefreshReport();
		}
	}

	private string method_61(int int_0)
	{
		switch (int_0 % 10)
		{
		case 1:
			return "год";
		case 2:
		case 3:
		case 4:
			return "года";
		default:
			return "лет";
		}
	}

	private void comboBoxReadOnly_26_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.bool_0 = true;
		if (this.comboBoxReadOnly_26.SelectedIndex >= 0 && (this.nullableDateTimePicker_5.Value == null || this.nullableDateTimePicker_5.Value == DBNull.Value))
		{
			this.nullableDateTimePicker_5.Value = DateTime.Now;
		}
	}

	private void textBox_6_TextChanged(object sender, EventArgs e)
	{
		this.bool_0 = true;
		this.textBox_10.Text = this.textBox_6.Text;
	}

	private void textBox_6_Enter(object sender, EventArgs e)
	{
		this.textBox_6.TextChanged += this.textBox_6_TextChanged;
	}

	private void textBox_6_Leave(object sender, EventArgs e)
	{
		this.textBox_6.TextChanged -= this.textBox_6_TextChanged;
	}

	private void dateTimePicker_0_ValueChanged(object sender, EventArgs e)
	{
		this.bool_0 = true;
		this.method_62();
	}

	private void textBox_10_TextChanged(object sender, EventArgs e)
	{
		this.bool_0 = true;
		this.method_62();
	}

	private void method_62()
	{
		int num = 0;
		if (int.TryParse(this.textBox_10.Text, out num))
		{
			this.textBox_12.Text = (this.dateTimePicker_0.Value.Year - num).ToString();
		}
	}

	private void dataGridViewExcelFilter_1_DataError(object sender, DataGridViewDataErrorEventArgs e)
	{
		if (((DataGridView)sender).Columns[e.ColumnIndex] is DataGridViewComboBoxColumn)
		{
			e.Cancel = true;
		}
	}

	private void nullableDateTimePicker_4_ValueChanged(object sender, EventArgs e)
	{
		if (this.nullableDateTimePicker_4.Value != null)
		{
			this.nullableDateTimePicker_3.MaxDate = Convert.ToDateTime(this.nullableDateTimePicker_4.Value);
		}
	}

	private void button_4_Click(object sender, EventArgs e)
	{
		if (this.class171_0.tJ_Damage.Rows.Count > 0)
		{
			if (this.class171_0.tJ_Damage.Rows[0]["idParent"] == DBNull.Value)
			{
				MessageBox.Show("Не выбран документ аварийного события", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			DataTable dataTable = new DataTable("tJ_Damage");
			dataTable.Columns.Add("dateDoc", typeof(DateTime));
			base.SelectSqlData(dataTable, true, "where id = " + this.class171_0.tJ_Damage.Rows[0]["idParent"].ToString(), null, false, 0);
			if (dataTable.Rows.Count > 0)
			{
				this.class171_0.tJ_Damage.Rows[0]["DateDoc"] = dataTable.Rows[0]["DateDoc"];
			}
		}
	}

	private void button_5_Click(object sender, EventArgs e)
	{
		if (this.class171_0.tJ_Damage.Rows.Count > 0)
		{
			if (this.class171_0.tJ_Damage.Rows[0]["idParent"] == DBNull.Value)
			{
				MessageBox.Show("Не выбран документ аварийного события", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			if (this.class171_0.tJ_DamageActDetection.Rows.Count > 0)
			{
				DataTable dataTable = new DataTable("tj_DamageOn");
				dataTable.Columns.Add("DateOn", typeof(DateTime));
				base.SelectSqlData(dataTable, true, "where idDamage = " + this.class171_0.tJ_Damage.Rows[0]["idParent"].ToString() + " order by DateOn desc", null, false, 0);
				if (dataTable.Rows.Count > 0)
				{
					this.class171_0.tJ_DamageActDetection.Rows[0]["dateEndCrashLocal"] = dataTable.Rows[0]["dateOn"];
					return;
				}
				this.class171_0.tJ_DamageActDetection.Rows[0]["dateEndCrashLocal"] = DBNull.Value;
			}
		}
	}

	private void method_63()
	{
		this.icontainer_0 = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form86));
		this.tabControl_0 = new TabControl();
		this.tabPage_0 = new TabPage();
		this.label_53 = new Label();
		this.textBox_18 = new TextBox();
		this.class171_0 = new Class171();
		this.splitContainer_0 = new SplitContainer();
		this.button_3 = new Button();
		this.groupBox_2 = new GroupBox();
		this.dataGridViewExcelFilter_0 = new DataGridViewExcelFilter();
		this.dataGridViewComboBoxColumn_3 = new DataGridViewComboBoxColumn();
		this.dataGridViewFilterDateTimePickerColumn_0 = new DataGridViewFilterDateTimePickerColumn();
		this.dataGridViewComboBoxColumn_4 = new DataGridViewComboBoxColumn();
		this.bindingSource_0 = new BindingSource(this.icontainer_0);
		this.dataSet_0 = new DataSet();
		this.dataTable_1 = new DataTable();
		this.dataColumn_0 = new DataColumn();
		this.dataColumn_1 = new DataColumn();
		this.dataColumn_2 = new DataColumn();
		this.dataTable_2 = new DataTable();
		this.dataColumn_3 = new DataColumn();
		this.dataColumn_4 = new DataColumn();
		this.dataColumn_5 = new DataColumn();
		this.dataColumn_6 = new DataColumn();
		this.dataTable_3 = new DataTable();
		this.dataColumn_7 = new DataColumn();
		this.dataColumn_8 = new DataColumn();
		this.dataColumn_9 = new DataColumn();
		this.dataColumn_10 = new DataColumn();
		this.dataColumn_11 = new DataColumn();
		this.dataColumn_12 = new DataColumn();
		this.dataColumn_13 = new DataColumn();
		this.dataTable_4 = new DataTable();
		this.dataColumn_14 = new DataColumn();
		this.dataColumn_15 = new DataColumn();
		this.dataColumn_16 = new DataColumn();
		this.dataColumn_17 = new DataColumn();
		this.dataColumn_18 = new DataColumn();
		this.dataColumn_19 = new DataColumn();
		this.dataColumn_20 = new DataColumn();
		this.dataColumn_21 = new DataColumn();
		this.dataColumn_22 = new DataColumn();
		this.dataColumn_23 = new DataColumn();
		this.dataColumn_24 = new DataColumn();
		this.dataColumn_25 = new DataColumn();
		this.dataColumn_26 = new DataColumn();
		this.groupBox_0 = new GroupBox();
		this.button_4 = new Button();
		this.nullableDateTimePicker_1 = new NullableDateTimePicker();
		this.nullableDateTimePicker_2 = new NullableDateTimePicker();
		this.label_14 = new Label();
		this.label_15 = new Label();
		this.label_16 = new Label();
		this.comboBoxReadOnly_6 = new ComboBoxReadOnly();
		this.label_13 = new Label();
		this.comboBoxReadOnly_5 = new ComboBoxReadOnly();
		this.label_12 = new Label();
		this.comboBoxReadOnly_4 = new ComboBoxReadOnly();
		this.label_11 = new Label();
		this.comboBoxReadOnly_3 = new ComboBoxReadOnly();
		this.label_10 = new Label();
		this.label_9 = new Label();
		this.comboBoxReadOnly_2 = new ComboBoxReadOnly();
		this.checkBox_1 = new CheckBox();
		this.nullableDateTimePicker_0 = new NullableDateTimePicker();
		this.label_6 = new Label();
		this.button_2 = new Button();
		this.textBox_2 = new TextBox();
		this.label_5 = new Label();
		this.checkBox_0 = new CheckBox();
		this.comboBoxReadOnly_0 = new ComboBoxReadOnly();
		this.label_0 = new Label();
		this.comboBoxReadOnly_1 = new ComboBoxReadOnly();
		this.label_1 = new Label();
		this.dateTimePicker_0 = new DateTimePicker();
		this.label_2 = new Label();
		this.textBox_0 = new TextBox();
		this.label_3 = new Label();
		this.label_4 = new Label();
		this.textBox_1 = new TextBox();
		this.tabPage_4 = new TabPage();
		this.groupBox_1 = new GroupBox();
		this.richTextBox_1 = new RichTextBox();
		this.richTextBox_2 = new RichTextBox();
		this.comboBoxReadOnly_9 = new ComboBoxReadOnly();
		this.label_19 = new Label();
		this.comboBoxReadOnly_10 = new ComboBoxReadOnly();
		this.label_20 = new Label();
		this.comboBoxReadOnly_11 = new ComboBoxReadOnly();
		this.label_21 = new Label();
		this.dataGridViewExcelFilter_1 = new DataGridViewExcelFilter();
		this.dataGridViewComboBoxColumn_0 = new DataGridViewComboBoxColumn();
		this.dataGridViewComboBoxColumn_1 = new DataGridViewComboBoxColumn();
		this.dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		this.dataGridViewComboBoxColumn_2 = new DataGridViewComboBoxColumn();
		this.bindingSource_1 = new BindingSource(this.icontainer_0);
		this.label_18 = new Label();
		this.comboBoxReadOnly_8 = new ComboBoxReadOnly();
		this.label_17 = new Label();
		this.comboBoxReadOnly_7 = new ComboBoxReadOnly();
		this.textBox_3 = new TextBox();
		this.label_7 = new Label();
		this.label_8 = new Label();
		this.tabPage_1 = new TabPage();
		this.splitContainer_1 = new SplitContainer();
		this.textBox_21 = new TextBox();
		this.bindingSource_2 = new BindingSource(this.icontainer_0);
		this.label_32 = new Label();
		this.comboBoxReadOnly_18 = new ComboBoxReadOnly();
		this.label_33 = new Label();
		this.textBox_7 = new TextBox();
		this.checkBox_2 = new CheckBox();
		this.label_34 = new Label();
		this.comboBoxReadOnly_15 = new ComboBoxReadOnly();
		this.textBox_8 = new TextBox();
		this.comboBoxReadOnly_14 = new ComboBoxReadOnly();
		this.label_35 = new Label();
		this.label_25 = new Label();
		this.textBox_9 = new TextBox();
		this.label_24 = new Label();
		this.label_36 = new Label();
		this.comboBoxReadOnly_13 = new ComboBoxReadOnly();
		this.comboBoxReadOnly_19 = new ComboBoxReadOnly();
		this.label_23 = new Label();
		this.label_30 = new Label();
		this.comboBoxReadOnly_12 = new ComboBoxReadOnly();
		this.textBox_6 = new TextBox();
		this.JmtCydXvoo4 = new Label();
		this.label_28 = new Label();
		this.comboBoxReadOnly_16 = new ComboBoxReadOnly();
		this.textBox_4 = new TextBox();
		this.label_26 = new Label();
		this.label_29 = new Label();
		this.ouoCyeHwemd = new TextBox();
		this.textBox_5 = new TextBox();
		this.label_27 = new Label();
		this.label_31 = new Label();
		this.comboBoxReadOnly_17 = new ComboBoxReadOnly();
		this.label_43 = new Label();
		this.nullableDateTimePicker_4 = new NullableDateTimePicker();
		this.label_41 = new Label();
		this.label_42 = new Label();
		this.textBox_12 = new TextBox();
		this.label_39 = new Label();
		this.textBox_10 = new TextBox();
		this.label_40 = new Label();
		this.textBox_11 = new TextBox();
		this.label_37 = new Label();
		this.comboBoxReadOnly_20 = new ComboBoxReadOnly();
		this.label_38 = new Label();
		this.comboBoxReadOnly_21 = new ComboBoxReadOnly();
		this.nullableDateTimePicker_3 = new NullableDateTimePicker();
		this.dataGridView_0 = new DataGridView();
		this.dataGridViewComboBoxColumn_6 = new DataGridViewComboBoxColumn();
		this.dataGridViewTextBoxColumn_8 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_9 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_10 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_11 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_12 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_13 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_14 = new DataGridViewTextBoxColumn();
		this.toolStrip_0 = new ToolStrip();
		this.toolStripButton_0 = new ToolStripButton();
		this.toolStripButton_1 = new ToolStripButton();
		this.label_22 = new Label();
		this.tabPage_2 = new TabPage();
		this.textBox_19 = new TextBox();
		this.label_54 = new Label();
		this.comboBoxReadOnly_27 = new ComboBoxReadOnly();
		this.textBox_20 = new TextBox();
		this.label_55 = new Label();
		this.comboBoxReadOnly_28 = new ComboBoxReadOnly();
		this.richTextBox_0 = new RichTextBox();
		this.label_47 = new Label();
		this.textBox_15 = new TextBox();
		this.label_48 = new Label();
		this.comboBoxReadOnly_23 = new ComboBoxReadOnly();
		this.textBox_16 = new TextBox();
		this.label_49 = new Label();
		this.comboBoxReadOnly_24 = new ComboBoxReadOnly();
		this.textBox_17 = new TextBox();
		this.label_50 = new Label();
		this.comboBoxReadOnly_25 = new ComboBoxReadOnly();
		this.label_51 = new Label();
		this.textBox_14 = new TextBox();
		this.label_45 = new Label();
		this.comboBoxReadOnly_22 = new ComboBoxReadOnly();
		this.label_46 = new Label();
		this.textBox_13 = new TextBox();
		this.label_44 = new Label();
		this.tabPage_3 = new TabPage();
		this.button_0 = new Button();
		this.button_1 = new Button();
		this.checkBox_3 = new CheckBox();
		this.label_52 = new Label();
		this.bindingSource_3 = new BindingSource(this.icontainer_0);
		this.dataGridViewComboBoxColumn_5 = new DataGridViewComboBoxColumn();
		this.dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_3 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_4 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_5 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_6 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_7 = new DataGridViewTextBoxColumn();
		this.nullableDateTimePicker_5 = new NullableDateTimePicker();
		this.comboBoxReadOnly_26 = new ComboBoxReadOnly();
		this.button_5 = new Button();
		this.tabControl_0.SuspendLayout();
		this.tabPage_0.SuspendLayout();
		((ISupportInitialize)this.class171_0).BeginInit();
		this.splitContainer_0.Panel1.SuspendLayout();
		this.splitContainer_0.SuspendLayout();
		this.groupBox_2.SuspendLayout();
		((ISupportInitialize)this.dataGridViewExcelFilter_0).BeginInit();
		((ISupportInitialize)this.bindingSource_0).BeginInit();
		((ISupportInitialize)this.dataSet_0).BeginInit();
		((ISupportInitialize)this.dataTable_1).BeginInit();
		((ISupportInitialize)this.dataTable_2).BeginInit();
		((ISupportInitialize)this.dataTable_3).BeginInit();
		((ISupportInitialize)this.dataTable_4).BeginInit();
		this.groupBox_0.SuspendLayout();
		this.tabPage_4.SuspendLayout();
		this.groupBox_1.SuspendLayout();
		((ISupportInitialize)this.dataGridViewExcelFilter_1).BeginInit();
		((ISupportInitialize)this.bindingSource_1).BeginInit();
		this.tabPage_1.SuspendLayout();
		this.splitContainer_1.Panel1.SuspendLayout();
		this.splitContainer_1.Panel2.SuspendLayout();
		this.splitContainer_1.SuspendLayout();
		((ISupportInitialize)this.bindingSource_2).BeginInit();
		((ISupportInitialize)this.dataGridView_0).BeginInit();
		this.toolStrip_0.SuspendLayout();
		this.tabPage_2.SuspendLayout();
		((ISupportInitialize)this.bindingSource_3).BeginInit();
		base.SuspendLayout();
		this.tabControl_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.tabControl_0.Controls.Add(this.tabPage_0);
		this.tabControl_0.Controls.Add(this.tabPage_4);
		this.tabControl_0.Controls.Add(this.tabPage_1);
		this.tabControl_0.Controls.Add(this.tabPage_2);
		this.tabControl_0.Controls.Add(this.tabPage_3);
		this.tabControl_0.Location = new Point(1, -1);
		this.tabControl_0.Name = "tabControl1";
		this.tabControl_0.SelectedIndex = 0;
		this.tabControl_0.Size = new Size(784, 567);
		this.tabControl_0.TabIndex = 0;
		this.tabControl_0.SelectedIndexChanged += this.tabControl_0_SelectedIndexChanged;
		this.tabPage_0.Controls.Add(this.label_53);
		this.tabPage_0.Controls.Add(this.textBox_18);
		this.tabPage_0.Controls.Add(this.splitContainer_0);
		this.tabPage_0.Controls.Add(this.checkBox_0);
		this.tabPage_0.Controls.Add(this.comboBoxReadOnly_0);
		this.tabPage_0.Controls.Add(this.label_0);
		this.tabPage_0.Controls.Add(this.comboBoxReadOnly_1);
		this.tabPage_0.Controls.Add(this.label_1);
		this.tabPage_0.Controls.Add(this.dateTimePicker_0);
		this.tabPage_0.Controls.Add(this.label_2);
		this.tabPage_0.Controls.Add(this.textBox_0);
		this.tabPage_0.Controls.Add(this.label_3);
		this.tabPage_0.Controls.Add(this.label_4);
		this.tabPage_0.Controls.Add(this.textBox_1);
		this.tabPage_0.Location = new Point(4, 22);
		this.tabPage_0.Name = "tabPageGeneral";
		this.tabPage_0.Padding = new Padding(3);
		this.tabPage_0.Size = new Size(776, 541);
		this.tabPage_0.TabIndex = 0;
		this.tabPage_0.Text = "Общие";
		this.tabPage_0.UseVisualStyleBackColor = true;
		this.label_53.AutoSize = true;
		this.label_53.Location = new Point(653, 38);
		this.label_53.Name = "labelNumCrash";
		this.label_53.Size = new Size(57, 13);
		this.label_53.TabIndex = 13;
		this.label_53.Text = "№ аварии";
		this.textBox_18.DataBindings.Add(new Binding("Text", this.class171_0, "tJ_DamageActDetection.numCrash", true));
		this.textBox_18.Enabled = false;
		this.textBox_18.Location = new Point(716, 35);
		this.textBox_18.Name = "txtNumCrash";
		this.textBox_18.Size = new Size(52, 20);
		this.textBox_18.TabIndex = 12;
		this.textBox_18.TextChanged += this.textBox_18_TextChanged;
		this.class171_0.DataSetName = "DataSetDamage";
		this.class171_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		this.splitContainer_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.splitContainer_0.Location = new Point(0, 62);
		this.splitContainer_0.Name = "splitContainer1";
		this.splitContainer_0.Panel1.Controls.Add(this.button_3);
		this.splitContainer_0.Panel1.Controls.Add(this.groupBox_2);
		this.splitContainer_0.Panel1.Controls.Add(this.groupBox_0);
		this.splitContainer_0.Panel1.Controls.Add(this.button_2);
		this.splitContainer_0.Panel1.Controls.Add(this.textBox_2);
		this.splitContainer_0.Panel1.Controls.Add(this.label_5);
		this.splitContainer_0.Panel2Collapsed = true;
		this.splitContainer_0.Size = new Size(776, 479);
		this.splitContainer_0.SplitterDistance = 403;
		this.splitContainer_0.TabIndex = 11;
		this.button_3.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.button_3.BackgroundImage = Resources.ElementInformation;
		this.button_3.BackgroundImageLayout = ImageLayout.Stretch;
		this.button_3.FlatStyle = FlatStyle.Popup;
		this.button_3.Location = new Point(745, 12);
		this.button_3.Name = "btnOpenParentDamage";
		this.button_3.Size = new Size(22, 23);
		this.button_3.TabIndex = 5;
		this.button_3.UseVisualStyleBackColor = true;
		this.button_3.Click += this.button_3_Click;
		this.groupBox_2.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.groupBox_2.Controls.Add(this.dataGridViewExcelFilter_0);
		this.groupBox_2.Location = new Point(0, 349);
		this.groupBox_2.Name = "groupBoxNoCrashEvents";
		this.groupBox_2.Size = new Size(776, 130);
		this.groupBox_2.TabIndex = 4;
		this.groupBox_2.TabStop = false;
		this.groupBox_2.Text = "3. Противоаварийные мероприятия";
		this.groupBox_2.UseCompatibleTextRendering = true;
		this.dataGridViewExcelFilter_0.AutoGenerateColumns = false;
		this.dataGridViewExcelFilter_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridViewExcelFilter_0.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewComboBoxColumn_3,
			this.dataGridViewFilterDateTimePickerColumn_0,
			this.dataGridViewComboBoxColumn_4
		});
		this.dataGridViewExcelFilter_0.DataSource = this.bindingSource_0;
		this.dataGridViewExcelFilter_0.Dock = DockStyle.Fill;
		this.dataGridViewExcelFilter_0.EditMode = DataGridViewEditMode.EditOnEnter;
		this.dataGridViewExcelFilter_0.Location = new Point(3, 16);
		this.dataGridViewExcelFilter_0.Name = "dgvNoCrashMeasure";
		this.dataGridViewExcelFilter_0.RowHeadersWidth = 21;
		this.dataGridViewExcelFilter_0.Size = new Size(770, 111);
		this.dataGridViewExcelFilter_0.TabIndex = 0;
		this.dataGridViewExcelFilter_0.DataError += this.dataGridViewExcelFilter_1_DataError;
		this.dataGridViewExcelFilter_0.EditingControlShowing += this.dataGridViewExcelFilter_0_EditingControlShowing;
		this.dataGridViewExcelFilter_0.MouseClick += this.dataGridViewExcelFilter_0_MouseClick;
		this.dataGridViewComboBoxColumn_3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewComboBoxColumn_3.DataPropertyName = "idNoCrashMeasure";
		this.dataGridViewComboBoxColumn_3.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
		this.dataGridViewComboBoxColumn_3.HeaderText = "Мероприятие";
		this.dataGridViewComboBoxColumn_3.Name = "idNoCrashMeasureColumn";
		this.dataGridViewComboBoxColumn_3.Resizable = DataGridViewTriState.True;
		this.dataGridViewFilterDateTimePickerColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewFilterDateTimePickerColumn_0.DataPropertyName = "dateComplete";
		dataGridViewCellStyle.Format = "MMMM.yyyy";
		this.dataGridViewFilterDateTimePickerColumn_0.DefaultCellStyle = dataGridViewCellStyle;
		this.dataGridViewFilterDateTimePickerColumn_0.HeaderText = "Срок выполнения";
		this.dataGridViewFilterDateTimePickerColumn_0.Name = "dateCompleteDataGridViewTextBoxColumn";
		this.dataGridViewFilterDateTimePickerColumn_0.Resizable = DataGridViewTriState.True;
		this.dataGridViewFilterDateTimePickerColumn_0.SortMode = DataGridViewColumnSortMode.Automatic;
		this.dataGridViewComboBoxColumn_4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewComboBoxColumn_4.DataPropertyName = "idOrg";
		this.dataGridViewComboBoxColumn_4.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
		this.dataGridViewComboBoxColumn_4.HeaderText = "Организация";
		this.dataGridViewComboBoxColumn_4.Name = "idOrgColumn";
		this.dataGridViewComboBoxColumn_4.Resizable = DataGridViewTriState.True;
		this.bindingSource_0.DataMember = "dtNoCrashMeasure";
		this.bindingSource_0.DataSource = this.dataSet_0;
		this.dataSet_0.DataSetName = "NewDataSet";
		this.dataSet_0.Tables.AddRange(new DataTable[]
		{
			this.dataTable_1,
			this.dataTable_2,
			this.dataTable_3,
			this.dataTable_4
		});
		this.dataTable_1.Columns.AddRange(new DataColumn[]
		{
			this.dataColumn_0,
			this.dataColumn_1,
			this.dataColumn_2
		});
		this.dataTable_1.TableName = "dtNoCrashMeasure";
		this.dataColumn_0.ColumnName = "idNoCrashMeasure";
		this.dataColumn_0.DataType = typeof(int);
		this.dataColumn_1.ColumnName = "dateComplete";
		this.dataColumn_1.DataType = typeof(DateTime);
		this.dataColumn_2.ColumnName = "idOrg";
		this.dataColumn_2.DataType = typeof(int);
		this.dataTable_2.Columns.AddRange(new DataColumn[]
		{
			this.dataColumn_3,
			this.dataColumn_4,
			this.dataColumn_5,
			this.dataColumn_6
		});
		this.dataTable_2.TableName = "dtDefection";
		this.dataColumn_3.Caption = "idDefection";
		this.dataColumn_3.ColumnName = "idDefection";
		this.dataColumn_3.DataType = typeof(int);
		this.dataColumn_4.ColumnName = "idNPA";
		this.dataColumn_4.DataType = typeof(int);
		this.dataColumn_5.ColumnName = "punctNPA";
		this.dataColumn_6.ColumnName = "idOrg";
		this.dataColumn_6.DataType = typeof(int);
		this.dataTable_3.Columns.AddRange(new DataColumn[]
		{
			this.dataColumn_7,
			this.dataColumn_8,
			this.dataColumn_9,
			this.dataColumn_10,
			this.dataColumn_11,
			this.dataColumn_12,
			this.dataColumn_13
		});
		this.dataTable_3.TableName = "dtParametersEquipment";
		this.dataColumn_7.ColumnName = "AutoProtect";
		this.dataColumn_7.DataType = typeof(bool);
		this.dataColumn_8.ColumnName = "idMark";
		this.dataColumn_8.DataType = typeof(int);
		this.dataColumn_9.ColumnName = "Parameters";
		this.dataColumn_9.DataType = typeof(int);
		this.dataColumn_10.ColumnName = "Voltage";
		this.dataColumn_10.DataType = typeof(int);
		this.dataColumn_11.ColumnName = "NodeDetail";
		this.dataColumn_11.DataType = typeof(int);
		this.dataColumn_12.ColumnName = "VoltageSeti";
		this.dataColumn_12.DataType = typeof(int);
		this.dataColumn_13.ColumnName = "CountDefectEquipment";
		this.dataColumn_13.DataType = typeof(int);
		this.dataTable_4.Columns.AddRange(new DataColumn[]
		{
			this.dataColumn_14,
			this.dataColumn_15,
			this.dataColumn_16,
			this.dataColumn_17,
			this.dataColumn_18,
			this.dataColumn_19,
			this.dataColumn_20,
			this.dataColumn_21,
			this.dataColumn_22,
			this.dataColumn_23,
			this.dataColumn_24,
			this.dataColumn_25,
			this.dataColumn_26
		});
		this.dataTable_4.TableName = "dtComission";
		this.dataColumn_14.ColumnName = "Order";
		this.dataColumn_15.ColumnName = "Chairman";
		this.dataColumn_15.DataType = typeof(int);
		this.dataColumn_16.ColumnName = "PostChairman";
		this.dataColumn_17.ColumnName = "Member1";
		this.dataColumn_17.DataType = typeof(int);
		this.dataColumn_18.ColumnName = "PostMember1";
		this.dataColumn_19.ColumnName = "Member2";
		this.dataColumn_19.DataType = typeof(int);
		this.dataColumn_20.ColumnName = "PostMember2";
		this.dataColumn_21.ColumnName = "Member3";
		this.dataColumn_21.DataType = typeof(int);
		this.dataColumn_22.ColumnName = "PostMember3";
		this.dataColumn_23.ColumnName = "Member4";
		this.dataColumn_23.DataType = typeof(int);
		this.dataColumn_24.ColumnName = "PostMember4";
		this.dataColumn_25.ColumnName = "Member5";
		this.dataColumn_25.DataType = typeof(int);
		this.dataColumn_26.ColumnName = "PostMember5";
		this.groupBox_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.groupBox_0.Controls.Add(this.button_5);
		this.groupBox_0.Controls.Add(this.button_4);
		this.groupBox_0.Controls.Add(this.nullableDateTimePicker_1);
		this.groupBox_0.Controls.Add(this.nullableDateTimePicker_2);
		this.groupBox_0.Controls.Add(this.label_14);
		this.groupBox_0.Controls.Add(this.label_15);
		this.groupBox_0.Controls.Add(this.label_16);
		this.groupBox_0.Controls.Add(this.comboBoxReadOnly_6);
		this.groupBox_0.Controls.Add(this.label_13);
		this.groupBox_0.Controls.Add(this.comboBoxReadOnly_5);
		this.groupBox_0.Controls.Add(this.label_12);
		this.groupBox_0.Controls.Add(this.comboBoxReadOnly_4);
		this.groupBox_0.Controls.Add(this.label_11);
		this.groupBox_0.Controls.Add(this.comboBoxReadOnly_3);
		this.groupBox_0.Controls.Add(this.label_10);
		this.groupBox_0.Controls.Add(this.label_9);
		this.groupBox_0.Controls.Add(this.comboBoxReadOnly_2);
		this.groupBox_0.Controls.Add(this.checkBox_1);
		this.groupBox_0.Controls.Add(this.nullableDateTimePicker_0);
		this.groupBox_0.Controls.Add(this.label_6);
		this.groupBox_0.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.groupBox_0.Location = new Point(0, 44);
		this.groupBox_0.Name = "groupBoxGeneral";
		this.groupBox_0.Size = new Size(776, 299);
		this.groupBox_0.TabIndex = 3;
		this.groupBox_0.TabStop = false;
		this.groupBox_0.Text = "1. Общие сведения";
		this.button_4.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.button_4.BackgroundImage = Resources.refresh_16;
		this.button_4.BackgroundImageLayout = ImageLayout.Stretch;
		this.button_4.FlatStyle = FlatStyle.Popup;
		this.button_4.Location = new Point(300, 19);
		this.button_4.Name = "btnRefreshDateDoc";
		this.button_4.Size = new Size(20, 20);
		this.button_4.TabIndex = 18;
		this.button_4.UseVisualStyleBackColor = true;
		this.button_4.Click += this.button_4_Click;
		this.nullableDateTimePicker_1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.nullableDateTimePicker_1.CustomFormat = "dd.MM.yyyy HH:mm";
		this.nullableDateTimePicker_1.DataBindings.Add(new Binding("Value", this.class171_0, "tJ_DamageActDetection.dateEndCrashMoscow", true, DataSourceUpdateMode.OnPropertyChanged));
		this.nullableDateTimePicker_1.Enabled = false;
		this.nullableDateTimePicker_1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.nullableDateTimePicker_1.Format = DateTimePickerFormat.Custom;
		this.nullableDateTimePicker_1.Location = new Point(228, 270);
		this.nullableDateTimePicker_1.Name = "dtpEndCrashMoscow";
		this.nullableDateTimePicker_1.Size = new Size(514, 20);
		this.nullableDateTimePicker_1.TabIndex = 17;
		this.nullableDateTimePicker_1.Value = new DateTime(2016, 3, 28, 16, 32, 55, 541);
		this.nullableDateTimePicker_2.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.nullableDateTimePicker_2.CustomFormat = "dd.MM.yyyy HH:mm";
		this.nullableDateTimePicker_2.DataBindings.Add(new Binding("Value", this.class171_0, "tJ_DamageActDetection.dateEndCrashLocal", true));
		this.nullableDateTimePicker_2.Enabled = false;
		this.nullableDateTimePicker_2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.nullableDateTimePicker_2.Format = DateTimePickerFormat.Custom;
		this.nullableDateTimePicker_2.Location = new Point(228, 244);
		this.nullableDateTimePicker_2.Name = "dtpEndCrashLocal";
		this.nullableDateTimePicker_2.Size = new Size(514, 20);
		this.nullableDateTimePicker_2.TabIndex = 16;
		this.nullableDateTimePicker_2.Value = new DateTime(2016, 3, 28, 16, 32, 55, 541);
		this.nullableDateTimePicker_2.ValueChanged += this.nullableDateTimePicker_2_ValueChanged;
		this.label_14.AutoSize = true;
		this.label_14.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.label_14.Location = new Point(142, 276);
		this.label_14.Name = "label17";
		this.label_14.Size = new Size(80, 13);
		this.label_14.TabIndex = 15;
		this.label_14.Text = "(московского)";
		this.label_15.AutoSize = true;
		this.label_15.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.label_15.Location = new Point(161, 250);
		this.label_15.Name = "label16";
		this.label_15.Size = new Size(61, 13);
		this.label_15.TabIndex = 14;
		this.label_15.Text = "(местного)";
		this.label_16.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.label_16.Location = new Point(8, 250);
		this.label_16.Name = "label15";
		this.label_16.Size = new Size(116, 53);
		this.label_16.TabIndex = 13;
		this.label_16.Text = "Дата и время ликвидации аварийного режима";
		this.comboBoxReadOnly_6.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.comboBoxReadOnly_6.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBoxReadOnly_6.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBoxReadOnly_6.DataBindings.Add(new Binding("SelectedValue", this.class171_0, "tJ_DamageActDetection.idReasonCrash", true));
		this.comboBoxReadOnly_6.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.comboBoxReadOnly_6.FormattingEnabled = true;
		this.comboBoxReadOnly_6.Location = new Point(11, 215);
		this.comboBoxReadOnly_6.Name = "cmbReasonCrash";
		this.comboBoxReadOnly_6.ReadOnlyBackColor = SystemColors.Control;
		this.comboBoxReadOnly_6.ReadOnlyForeColor = SystemColors.WindowText;
		this.comboBoxReadOnly_6.Size = new Size(759, 21);
		this.comboBoxReadOnly_6.TabIndex = 12;
		this.label_13.AutoSize = true;
		this.label_13.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.label_13.Location = new Point(8, 199);
		this.label_13.Name = "label14";
		this.label_13.Size = new Size(258, 13);
		this.label_13.TabIndex = 11;
		this.label_13.Text = "Классификация организационных причин аварии";
		this.comboBoxReadOnly_5.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.comboBoxReadOnly_5.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBoxReadOnly_5.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBoxReadOnly_5.DataBindings.Add(new Binding("SelectedValue", this.class171_0, "tJ_DamageActDetection.idReasonCrashEquipment", true));
		this.comboBoxReadOnly_5.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.comboBoxReadOnly_5.FormattingEnabled = true;
		this.comboBoxReadOnly_5.Location = new Point(11, 175);
		this.comboBoxReadOnly_5.Name = "cmbReasonCrashEquipment";
		this.comboBoxReadOnly_5.ReadOnlyBackColor = SystemColors.Control;
		this.comboBoxReadOnly_5.ReadOnlyForeColor = SystemColors.WindowText;
		this.comboBoxReadOnly_5.Size = new Size(759, 21);
		this.comboBoxReadOnly_5.TabIndex = 10;
		this.label_12.AutoSize = true;
		this.label_12.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.label_12.Location = new Point(8, 159);
		this.label_12.Name = "label13";
		this.label_12.Size = new Size(336, 13);
		this.label_12.TabIndex = 9;
		this.label_12.Text = "Классификация технических причин повреждений оборудования";
		this.comboBoxReadOnly_4.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.comboBoxReadOnly_4.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBoxReadOnly_4.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBoxReadOnly_4.DataBindings.Add(new Binding("SelectedValue", this.class171_0, "tJ_DamageActDetection.idTypeEquipment", true));
		this.comboBoxReadOnly_4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.comboBoxReadOnly_4.FormattingEnabled = true;
		this.comboBoxReadOnly_4.Location = new Point(11, 135);
		this.comboBoxReadOnly_4.Name = "cmbTypeEquipment";
		this.comboBoxReadOnly_4.ReadOnlyBackColor = SystemColors.Control;
		this.comboBoxReadOnly_4.ReadOnlyForeColor = SystemColors.WindowText;
		this.comboBoxReadOnly_4.Size = new Size(759, 21);
		this.comboBoxReadOnly_4.TabIndex = 8;
		this.label_11.AutoSize = true;
		this.label_11.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.label_11.Location = new Point(8, 119);
		this.label_11.Name = "label12";
		this.label_11.Size = new Size(195, 13);
		this.label_11.TabIndex = 7;
		this.label_11.Text = "Классификация видов оборудования";
		this.comboBoxReadOnly_3.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.comboBoxReadOnly_3.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBoxReadOnly_3.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBoxReadOnly_3.DataBindings.Add(new Binding("SelectedValue", this.class171_0, "tJ_DamageActDetection.idSignCrash", true));
		this.comboBoxReadOnly_3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.comboBoxReadOnly_3.FormattingEnabled = true;
		this.comboBoxReadOnly_3.Location = new Point(11, 95);
		this.comboBoxReadOnly_3.Name = "cmbSignCrash";
		this.comboBoxReadOnly_3.ReadOnlyBackColor = SystemColors.Control;
		this.comboBoxReadOnly_3.ReadOnlyForeColor = SystemColors.WindowText;
		this.comboBoxReadOnly_3.Size = new Size(759, 21);
		this.comboBoxReadOnly_3.TabIndex = 6;
		this.label_10.AutoSize = true;
		this.label_10.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.label_10.Location = new Point(8, 79);
		this.label_10.Name = "label11";
		this.label_10.Size = new Size(141, 13);
		this.label_10.TabIndex = 5;
		this.label_10.Text = "Учетные признаки аварии";
		this.label_9.AutoSize = true;
		this.label_9.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.label_9.Location = new Point(8, 54);
		this.label_9.Name = "label10";
		this.label_9.Size = new Size(74, 13);
		this.label_9.TabIndex = 4;
		this.label_9.Text = "Организация";
		this.comboBoxReadOnly_2.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.comboBoxReadOnly_2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBoxReadOnly_2.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBoxReadOnly_2.DataBindings.Add(new Binding("SelectedValue", this.class171_0, "tJ_DamageActDetection.idOrg", true));
		this.comboBoxReadOnly_2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.comboBoxReadOnly_2.FormattingEnabled = true;
		this.comboBoxReadOnly_2.Location = new Point(114, 51);
		this.comboBoxReadOnly_2.Name = "cmbOrg";
		this.comboBoxReadOnly_2.ReadOnlyBackColor = SystemColors.Control;
		this.comboBoxReadOnly_2.ReadOnlyForeColor = SystemColors.WindowText;
		this.comboBoxReadOnly_2.Size = new Size(656, 21);
		this.comboBoxReadOnly_2.TabIndex = 3;
		this.checkBox_1.AutoSize = true;
		this.checkBox_1.DataBindings.Add(new Binding("Checked", this.class171_0, "tJ_DamageActDetection.isNoOff", true));
		this.checkBox_1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.checkBox_1.Location = new Point(326, 21);
		this.checkBox_1.Name = "chkNoOff";
		this.checkBox_1.Size = new Size(73, 17);
		this.checkBox_1.TabIndex = 2;
		this.checkBox_1.Text = "без откл.";
		this.checkBox_1.UseVisualStyleBackColor = true;
		this.nullableDateTimePicker_0.CustomFormat = "dd.MM.yyyy HH:mm";
		this.nullableDateTimePicker_0.DataBindings.Add(new Binding("Value", this.class171_0, "tJ_Damage.DateDoc", true));
		this.nullableDateTimePicker_0.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.nullableDateTimePicker_0.Format = DateTimePickerFormat.Custom;
		this.nullableDateTimePicker_0.Location = new Point(164, 19);
		this.nullableDateTimePicker_0.Name = "dtpDateDoc";
		this.nullableDateTimePicker_0.Size = new Size(130, 20);
		this.nullableDateTimePicker_0.TabIndex = 1;
		this.nullableDateTimePicker_0.Value = new DateTime(2016, 3, 28, 16, 32, 55, 541);
		this.label_6.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.label_6.Location = new Point(8, 16);
		this.label_6.Name = "label7";
		this.label_6.Size = new Size(152, 32);
		this.label_6.TabIndex = 0;
		this.label_6.Text = "Дата и время возникновения события";
		this.button_2.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.button_2.Location = new Point(716, 12);
		this.button_2.Name = "buttonChooseParentDamage";
		this.button_2.Size = new Size(26, 23);
		this.button_2.TabIndex = 2;
		this.button_2.Text = "...";
		this.button_2.UseVisualStyleBackColor = true;
		this.button_2.Click += this.button_2_Click;
		this.textBox_2.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_2.BackColor = SystemColors.Window;
		this.textBox_2.Location = new Point(130, 12);
		this.textBox_2.Name = "txtParentDamage";
		this.textBox_2.ReadOnly = true;
		this.textBox_2.Size = new Size(580, 20);
		this.textBox_2.TabIndex = 1;
		this.label_5.Location = new Point(8, 9);
		this.label_5.Name = "label6";
		this.label_5.Size = new Size(116, 32);
		this.label_5.TabIndex = 0;
		this.label_5.Text = "Документ аварийного события";
		this.checkBox_0.AutoSize = true;
		this.checkBox_0.DataBindings.Add(new Binding("Checked", this.class171_0, "tJ_DamageActDetection.isCrash", true));
		this.checkBox_0.Location = new Point(584, 36);
		this.checkBox_0.Name = "chkCrash";
		this.checkBox_0.Size = new Size(63, 17);
		this.checkBox_0.TabIndex = 10;
		this.checkBox_0.Text = "Авария";
		this.checkBox_0.UseVisualStyleBackColor = true;
		this.checkBox_0.CheckedChanged += this.checkBox_0_CheckedChanged;
		this.comboBoxReadOnly_0.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBoxReadOnly_0.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBoxReadOnly_0.DataBindings.Add(new Binding("SelectedValue", this.class171_0, "tJ_Damage.idDivision", true));
		this.comboBoxReadOnly_0.FormattingEnabled = true;
		this.comboBoxReadOnly_0.Location = new Point(390, 34);
		this.comboBoxReadOnly_0.Name = "cmbDivision";
		this.comboBoxReadOnly_0.ReadOnlyBackColor = SystemColors.Control;
		this.comboBoxReadOnly_0.ReadOnlyForeColor = SystemColors.WindowText;
		this.comboBoxReadOnly_0.Size = new Size(174, 21);
		this.comboBoxReadOnly_0.TabIndex = 9;
		this.label_0.AutoSize = true;
		this.label_0.Location = new Point(302, 35);
		this.label_0.Name = "label5";
		this.label_0.Size = new Size(82, 13);
		this.label_0.TabIndex = 8;
		this.label_0.Text = "Сетевой район";
		this.comboBoxReadOnly_1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBoxReadOnly_1.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBoxReadOnly_1.DataBindings.Add(new Binding("SelectedValue", this.class171_0, "tJ_Damage.idCompiler", true));
		this.comboBoxReadOnly_1.FormattingEnabled = true;
		this.comboBoxReadOnly_1.Location = new Point(114, 32);
		this.comboBoxReadOnly_1.Name = "cmbCompiler";
		this.comboBoxReadOnly_1.ReadOnlyBackColor = SystemColors.Control;
		this.comboBoxReadOnly_1.ReadOnlyForeColor = SystemColors.WindowText;
		this.comboBoxReadOnly_1.Size = new Size(166, 21);
		this.comboBoxReadOnly_1.TabIndex = 7;
		this.label_1.Location = new Point(8, 29);
		this.label_1.Name = "label4";
		this.label_1.Size = new Size(104, 30);
		this.label_1.TabIndex = 6;
		this.label_1.Text = "Ответственный за оформление акта";
		this.dateTimePicker_0.CustomFormat = "dd.MM.yyyy HH:mm";
		this.dateTimePicker_0.DataBindings.Add(new Binding("Value", this.class171_0, "tJ_Damage.DateOwner", true));
		this.dateTimePicker_0.Format = DateTimePickerFormat.Custom;
		this.dateTimePicker_0.Location = new Point(615, 6);
		this.dateTimePicker_0.Name = "dtpDateOwner";
		this.dateTimePicker_0.Size = new Size(153, 20);
		this.dateTimePicker_0.TabIndex = 5;
		this.dateTimePicker_0.ValueChanged += this.dateTimePicker_0_ValueChanged;
		this.label_2.AutoSize = true;
		this.label_2.Location = new Point(499, 9);
		this.label_2.Name = "label3";
		this.label_2.Size = new Size(110, 13);
		this.label_2.TabIndex = 4;
		this.label_2.Text = "Дата создания акта";
		this.textBox_0.BackColor = SystemColors.Window;
		this.textBox_0.Location = new Point(286, 6);
		this.textBox_0.Name = "txtOwner";
		this.textBox_0.ReadOnly = true;
		this.textBox_0.Size = new Size(207, 20);
		this.textBox_0.TabIndex = 3;
		this.label_3.AutoSize = true;
		this.label_3.Location = new Point(217, 9);
		this.label_3.Name = "label2";
		this.label_3.Size = new Size(63, 13);
		this.label_3.TabIndex = 2;
		this.label_3.Text = "Автор акта";
		this.label_4.AutoSize = true;
		this.label_4.Location = new Point(8, 9);
		this.label_4.Name = "label1";
		this.label_4.Size = new Size(80, 13);
		this.label_4.TabIndex = 1;
		this.label_4.Text = "Номер заявки";
		this.textBox_1.BackColor = SystemColors.Window;
		this.textBox_1.DataBindings.Add(new Binding("Text", this.class171_0, "tJ_Damage.NumRequest", true));
		this.textBox_1.Location = new Point(114, 6);
		this.textBox_1.Name = "txtNumRequest";
		this.textBox_1.ReadOnly = true;
		this.textBox_1.Size = new Size(80, 20);
		this.textBox_1.TabIndex = 0;
		this.tabPage_4.Controls.Add(this.groupBox_1);
		this.tabPage_4.Location = new Point(4, 22);
		this.tabPage_4.Name = "tabPageDescription";
		this.tabPage_4.Size = new Size(776, 541);
		this.tabPage_4.TabIndex = 4;
		this.tabPage_4.Text = "Описательный блок";
		this.tabPage_4.UseVisualStyleBackColor = true;
		this.groupBox_1.Controls.Add(this.richTextBox_1);
		this.groupBox_1.Controls.Add(this.richTextBox_2);
		this.groupBox_1.Controls.Add(this.comboBoxReadOnly_9);
		this.groupBox_1.Controls.Add(this.label_19);
		this.groupBox_1.Controls.Add(this.comboBoxReadOnly_10);
		this.groupBox_1.Controls.Add(this.label_20);
		this.groupBox_1.Controls.Add(this.comboBoxReadOnly_11);
		this.groupBox_1.Controls.Add(this.label_21);
		this.groupBox_1.Controls.Add(this.dataGridViewExcelFilter_1);
		this.groupBox_1.Controls.Add(this.label_18);
		this.groupBox_1.Controls.Add(this.comboBoxReadOnly_8);
		this.groupBox_1.Controls.Add(this.label_17);
		this.groupBox_1.Controls.Add(this.comboBoxReadOnly_7);
		this.groupBox_1.Controls.Add(this.textBox_3);
		this.groupBox_1.Controls.Add(this.label_7);
		this.groupBox_1.Controls.Add(this.label_8);
		this.groupBox_1.Dock = DockStyle.Fill;
		this.groupBox_1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.groupBox_1.Location = new Point(0, 0);
		this.groupBox_1.Name = "groupBoxDescription";
		this.groupBox_1.Size = new Size(776, 541);
		this.groupBox_1.TabIndex = 0;
		this.groupBox_1.TabStop = false;
		this.groupBox_1.Text = "2. Описательный блок";
		this.richTextBox_1.AcceptsTab = true;
		this.richTextBox_1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.richTextBox_1.DataBindings.Add(new Binding("Text", this.class171_0, "tJ_DamageActDetection.ReasonBeginCrash", true));
		this.richTextBox_1.Font = new Font("Microsoft Sans Serif", 8.25f);
		this.richTextBox_1.Location = new Point(8, 373);
		this.richTextBox_1.Name = "txtReasonBeginCrash";
		this.richTextBox_1.Size = new Size(758, 68);
		this.richTextBox_1.TabIndex = 25;
		this.richTextBox_1.Text = "";
		this.richTextBox_2.AcceptsTab = true;
		this.richTextBox_2.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.richTextBox_2.DataBindings.Add(new Binding("Text", this.class171_0, "tJ_DamageActDetection.StatusCurrentCrash", true));
		this.richTextBox_2.Font = new Font("Microsoft Sans Serif", 8.25f);
		this.richTextBox_2.Location = new Point(9, 125);
		this.richTextBox_2.Name = "txtStatusCurrentCrash";
		this.richTextBox_2.Size = new Size(757, 52);
		this.richTextBox_2.TabIndex = 24;
		this.richTextBox_2.Text = "";
		this.comboBoxReadOnly_9.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.comboBoxReadOnly_9.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBoxReadOnly_9.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBoxReadOnly_9.DataBindings.Add(new Binding("SelectedValue", this.class171_0, "tJ_DamageActDetection.idFault", true));
		this.comboBoxReadOnly_9.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.comboBoxReadOnly_9.FormattingEnabled = true;
		this.comboBoxReadOnly_9.Location = new Point(9, 514);
		this.comboBoxReadOnly_9.Name = "cmbFault";
		this.comboBoxReadOnly_9.ReadOnlyBackColor = SystemColors.Control;
		this.comboBoxReadOnly_9.ReadOnlyForeColor = SystemColors.WindowText;
		this.comboBoxReadOnly_9.Size = new Size(757, 21);
		this.comboBoxReadOnly_9.TabIndex = 23;
		this.label_19.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.label_19.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.label_19.Location = new Point(9, 483);
		this.label_19.Name = "label22";
		this.label_19.Size = new Size(755, 28);
		this.label_19.TabIndex = 22;
		this.label_19.Text = componentResourceManager.GetString("label22.Text");
		this.comboBoxReadOnly_10.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.comboBoxReadOnly_10.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBoxReadOnly_10.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBoxReadOnly_10.DataBindings.Add(new Binding("SelectedValue", this.class171_0, "tJ_DamageActDetection.idClassifierDamage", true));
		this.comboBoxReadOnly_10.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.comboBoxReadOnly_10.FormattingEnabled = true;
		this.comboBoxReadOnly_10.Location = new Point(8, 460);
		this.comboBoxReadOnly_10.Name = "cmbClassifierDamage";
		this.comboBoxReadOnly_10.ReadOnlyBackColor = SystemColors.Control;
		this.comboBoxReadOnly_10.ReadOnlyForeColor = SystemColors.WindowText;
		this.comboBoxReadOnly_10.Size = new Size(757, 21);
		this.comboBoxReadOnly_10.TabIndex = 21;
		this.label_20.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.label_20.AutoSize = true;
		this.label_20.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.label_20.Location = new Point(4, 444);
		this.label_20.Name = "label21";
		this.label_20.Size = new Size(587, 13);
		this.label_20.TabIndex = 20;
		this.label_20.Text = "Перечень и описание повреждения оборудования объектов электроэнергетики и энергопринимающих устройств";
		this.comboBoxReadOnly_11.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.comboBoxReadOnly_11.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBoxReadOnly_11.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBoxReadOnly_11.DataBindings.Add(new Binding("SelectedValue", this.class171_0, "tJ_DamageActDetection.idReasonBeginCrash", true));
		this.comboBoxReadOnly_11.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.comboBoxReadOnly_11.FormattingEnabled = true;
		this.comboBoxReadOnly_11.Location = new Point(8, 354);
		this.comboBoxReadOnly_11.Name = "cmbReasonBeginCrash";
		this.comboBoxReadOnly_11.ReadOnlyBackColor = SystemColors.Control;
		this.comboBoxReadOnly_11.ReadOnlyForeColor = SystemColors.WindowText;
		this.comboBoxReadOnly_11.Size = new Size(756, 21);
		this.comboBoxReadOnly_11.TabIndex = 19;
		this.label_21.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.label_21.AutoSize = true;
		this.label_21.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.label_21.Location = new Point(6, 338);
		this.label_21.Name = "label20";
		this.label_21.Size = new Size(246, 13);
		this.label_21.TabIndex = 18;
		this.label_21.Text = "Причины возникновения аварии и ее развития";
		this.dataGridViewExcelFilter_1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.dataGridViewExcelFilter_1.AutoGenerateColumns = false;
		this.dataGridViewExcelFilter_1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridViewExcelFilter_1.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewComboBoxColumn_0,
			this.dataGridViewComboBoxColumn_1,
			this.dataGridViewTextBoxColumn_0,
			this.dataGridViewComboBoxColumn_2
		});
		this.dataGridViewExcelFilter_1.DataSource = this.bindingSource_1;
		this.dataGridViewExcelFilter_1.Location = new Point(0, 221);
		this.dataGridViewExcelFilter_1.Margin = new Padding(2);
		this.dataGridViewExcelFilter_1.Name = "dgvDefection";
		this.dataGridViewExcelFilter_1.RowHeadersWidth = 22;
		this.dataGridViewExcelFilter_1.RowTemplate.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 7.8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.dataGridViewExcelFilter_1.RowTemplate.Height = 24;
		this.dataGridViewExcelFilter_1.Size = new Size(777, 115);
		this.dataGridViewExcelFilter_1.TabIndex = 17;
		this.dataGridViewExcelFilter_1.DataError += this.dataGridViewExcelFilter_1_DataError;
		this.dataGridViewComboBoxColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewComboBoxColumn_0.DataPropertyName = "idDefection";
		this.dataGridViewComboBoxColumn_0.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
		this.dataGridViewComboBoxColumn_0.FillWeight = 103.6082f;
		this.dataGridViewComboBoxColumn_0.HeaderText = "Описание нарушения";
		this.dataGridViewComboBoxColumn_0.Name = "idDefectionDataGridViewTextBoxColumn";
		this.dataGridViewComboBoxColumn_0.Resizable = DataGridViewTriState.True;
		this.dataGridViewComboBoxColumn_1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewComboBoxColumn_1.DataPropertyName = "idNPA";
		this.dataGridViewComboBoxColumn_1.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
		this.dataGridViewComboBoxColumn_1.HeaderText = "Наименование НПА (НТД)";
		this.dataGridViewComboBoxColumn_1.Name = "idNPADgvColumn";
		this.dataGridViewComboBoxColumn_1.Resizable = DataGridViewTriState.True;
		this.dataGridViewComboBoxColumn_1.SortMode = DataGridViewColumnSortMode.Automatic;
		this.dataGridViewTextBoxColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_0.DataPropertyName = "punctNPA";
		this.dataGridViewTextBoxColumn_0.FillWeight = 50f;
		this.dataGridViewTextBoxColumn_0.HeaderText = "Пункт НПА (НТД)";
		this.dataGridViewTextBoxColumn_0.Name = "punctNPADataGridViewTextBoxColumn";
		this.dataGridViewComboBoxColumn_2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewComboBoxColumn_2.DataPropertyName = "idOrg";
		this.dataGridViewComboBoxColumn_2.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
		this.dataGridViewComboBoxColumn_2.FillWeight = 103.6082f;
		this.dataGridViewComboBoxColumn_2.HeaderText = "Организация";
		this.dataGridViewComboBoxColumn_2.Name = "idOrgDefectionDgvColumn";
		this.dataGridViewComboBoxColumn_2.Resizable = DataGridViewTriState.True;
		this.bindingSource_1.DataMember = "dtDefection";
		this.bindingSource_1.DataSource = this.dataSet_0;
		this.label_18.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.label_18.Location = new Point(6, 180);
		this.label_18.Name = "label19";
		this.label_18.Size = new Size(759, 39);
		this.label_18.TabIndex = 16;
		this.label_18.Text = componentResourceManager.GetString("label19.Text");
		this.comboBoxReadOnly_8.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.comboBoxReadOnly_8.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBoxReadOnly_8.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBoxReadOnly_8.DataBindings.Add(new Binding("SelectedValue", this.class171_0, "tJ_DamageActDetection.idStatusCurrentCrash", true));
		this.comboBoxReadOnly_8.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.comboBoxReadOnly_8.FormattingEnabled = true;
		this.comboBoxReadOnly_8.Location = new Point(9, 106);
		this.comboBoxReadOnly_8.Name = "cmbStatusCurrentCrash";
		this.comboBoxReadOnly_8.ReadOnlyBackColor = SystemColors.Control;
		this.comboBoxReadOnly_8.ReadOnlyForeColor = SystemColors.WindowText;
		this.comboBoxReadOnly_8.Size = new Size(756, 21);
		this.comboBoxReadOnly_8.TabIndex = 15;
		this.label_17.AutoSize = true;
		this.label_17.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.label_17.Location = new Point(9, 90);
		this.label_17.Name = "label18";
		this.label_17.Size = new Size(648, 13);
		this.label_17.TabIndex = 14;
		this.label_17.Text = "Описание состояния и режима работы объектов электроэнергетики и (или) энергопринимающих установок во время аварии";
		this.comboBoxReadOnly_7.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.comboBoxReadOnly_7.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBoxReadOnly_7.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBoxReadOnly_7.DataBindings.Add(new Binding("SelectedValue", this.class171_0, "tJ_DamageActDetection.idStatusBeforeCrash", true));
		this.comboBoxReadOnly_7.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.comboBoxReadOnly_7.FormattingEnabled = true;
		this.comboBoxReadOnly_7.Location = new Point(9, 66);
		this.comboBoxReadOnly_7.Name = "cmbStatusBeforeCrash";
		this.comboBoxReadOnly_7.ReadOnlyBackColor = SystemColors.Control;
		this.comboBoxReadOnly_7.ReadOnlyForeColor = SystemColors.WindowText;
		this.comboBoxReadOnly_7.Size = new Size(757, 21);
		this.comboBoxReadOnly_7.TabIndex = 13;
		this.textBox_3.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_3.BackColor = SystemColors.Window;
		this.textBox_3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.textBox_3.Location = new Point(56, 40);
		this.textBox_3.Name = "txtSchmObj";
		this.textBox_3.ReadOnly = true;
		this.textBox_3.Size = new Size(710, 20);
		this.textBox_3.TabIndex = 2;
		this.label_7.AutoSize = true;
		this.label_7.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.label_7.Location = new Point(6, 43);
		this.label_7.Name = "label9";
		this.label_7.Size = new Size(45, 13);
		this.label_7.TabIndex = 1;
		this.label_7.Text = "Объект";
		this.label_8.AutoSize = true;
		this.label_8.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.label_8.Location = new Point(6, 19);
		this.label_8.Name = "label8";
		this.label_8.Size = new Size(694, 13);
		this.label_8.TabIndex = 0;
		this.label_8.Text = "Описание состояния и режима работы объектов электроэнергетики и (или) энергопринимающих установок до возникновения аварии";
		this.tabPage_1.Controls.Add(this.splitContainer_1);
		this.tabPage_1.Controls.Add(this.dataGridView_0);
		this.tabPage_1.Controls.Add(this.toolStrip_0);
		this.tabPage_1.Controls.Add(this.label_22);
		this.tabPage_1.Location = new Point(4, 22);
		this.tabPage_1.Name = "tabPageSchm";
		this.tabPage_1.Padding = new Padding(3);
		this.tabPage_1.Size = new Size(776, 541);
		this.tabPage_1.TabIndex = 1;
		this.tabPage_1.Text = "Оборудование";
		this.tabPage_1.UseVisualStyleBackColor = true;
		this.splitContainer_1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.splitContainer_1.Location = new Point(3, 153);
		this.splitContainer_1.Margin = new Padding(2);
		this.splitContainer_1.Name = "splitContainer2";
		this.splitContainer_1.Panel1.Controls.Add(this.textBox_21);
		this.splitContainer_1.Panel1.Controls.Add(this.label_32);
		this.splitContainer_1.Panel1.Controls.Add(this.comboBoxReadOnly_18);
		this.splitContainer_1.Panel1.Controls.Add(this.label_33);
		this.splitContainer_1.Panel1.Controls.Add(this.textBox_7);
		this.splitContainer_1.Panel1.Controls.Add(this.checkBox_2);
		this.splitContainer_1.Panel1.Controls.Add(this.label_34);
		this.splitContainer_1.Panel1.Controls.Add(this.comboBoxReadOnly_15);
		this.splitContainer_1.Panel1.Controls.Add(this.textBox_8);
		this.splitContainer_1.Panel1.Controls.Add(this.comboBoxReadOnly_14);
		this.splitContainer_1.Panel1.Controls.Add(this.label_35);
		this.splitContainer_1.Panel1.Controls.Add(this.label_25);
		this.splitContainer_1.Panel1.Controls.Add(this.textBox_9);
		this.splitContainer_1.Panel1.Controls.Add(this.label_24);
		this.splitContainer_1.Panel1.Controls.Add(this.label_36);
		this.splitContainer_1.Panel1.Controls.Add(this.comboBoxReadOnly_13);
		this.splitContainer_1.Panel1.Controls.Add(this.comboBoxReadOnly_19);
		this.splitContainer_1.Panel1.Controls.Add(this.label_23);
		this.splitContainer_1.Panel1.Controls.Add(this.label_30);
		this.splitContainer_1.Panel1.Controls.Add(this.comboBoxReadOnly_12);
		this.splitContainer_1.Panel1.Controls.Add(this.textBox_6);
		this.splitContainer_1.Panel1.Controls.Add(this.JmtCydXvoo4);
		this.splitContainer_1.Panel1.Controls.Add(this.label_28);
		this.splitContainer_1.Panel1.Controls.Add(this.comboBoxReadOnly_16);
		this.splitContainer_1.Panel1.Controls.Add(this.textBox_4);
		this.splitContainer_1.Panel1.Controls.Add(this.label_26);
		this.splitContainer_1.Panel1.Controls.Add(this.label_29);
		this.splitContainer_1.Panel1.Controls.Add(this.ouoCyeHwemd);
		this.splitContainer_1.Panel1.Controls.Add(this.textBox_5);
		this.splitContainer_1.Panel1.Controls.Add(this.label_27);
		this.splitContainer_1.Panel2.Controls.Add(this.label_31);
		this.splitContainer_1.Panel2.Controls.Add(this.comboBoxReadOnly_17);
		this.splitContainer_1.Panel2.Controls.Add(this.label_43);
		this.splitContainer_1.Panel2.Controls.Add(this.nullableDateTimePicker_4);
		this.splitContainer_1.Panel2.Controls.Add(this.label_41);
		this.splitContainer_1.Panel2.Controls.Add(this.label_42);
		this.splitContainer_1.Panel2.Controls.Add(this.textBox_12);
		this.splitContainer_1.Panel2.Controls.Add(this.label_39);
		this.splitContainer_1.Panel2.Controls.Add(this.textBox_10);
		this.splitContainer_1.Panel2.Controls.Add(this.label_40);
		this.splitContainer_1.Panel2.Controls.Add(this.textBox_11);
		this.splitContainer_1.Panel2.Controls.Add(this.label_37);
		this.splitContainer_1.Panel2.Controls.Add(this.comboBoxReadOnly_20);
		this.splitContainer_1.Panel2.Controls.Add(this.label_38);
		this.splitContainer_1.Panel2.Controls.Add(this.comboBoxReadOnly_21);
		this.splitContainer_1.Panel2.Controls.Add(this.nullableDateTimePicker_3);
		this.splitContainer_1.Size = new Size(773, 394);
		this.splitContainer_1.SplitterDistance = 346;
		this.splitContainer_1.SplitterWidth = 3;
		this.splitContainer_1.TabIndex = 28;
		this.textBox_21.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_21.DataBindings.Add(new Binding("Text", this.bindingSource_2, "nodeDetailTxt", true));
		this.textBox_21.Location = new Point(127, 121);
		this.textBox_21.Name = "txtNodeDetail";
		this.textBox_21.Size = new Size(207, 20);
		this.textBox_21.TabIndex = 32;
		this.bindingSource_2.DataMember = "tJ_DamageCharacter";
		this.bindingSource_2.DataSource = this.class171_0;
		this.bindingSource_2.CurrentChanged += this.bindingSource_2_CurrentChanged;
		this.label_32.AutoSize = true;
		this.label_32.Location = new Point(11, 362);
		this.label_32.Margin = new Padding(2, 0, 2, 0);
		this.label_32.Name = "label37";
		this.label_32.Size = new Size(57, 13);
		this.label_32.TabIndex = 31;
		this.label_32.Text = "Материал";
		this.comboBoxReadOnly_18.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.comboBoxReadOnly_18.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBoxReadOnly_18.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBoxReadOnly_18.DataBindings.Add(new Binding("SelectedValue", this.bindingSource_2, "idMaterial", true));
		this.comboBoxReadOnly_18.FormattingEnabled = true;
		this.comboBoxReadOnly_18.Location = new Point(127, 359);
		this.comboBoxReadOnly_18.Margin = new Padding(2);
		this.comboBoxReadOnly_18.Name = "cmbMaterial";
		this.comboBoxReadOnly_18.ReadOnlyBackColor = SystemColors.Control;
		this.comboBoxReadOnly_18.ReadOnlyForeColor = SystemColors.WindowText;
		this.comboBoxReadOnly_18.Size = new Size(207, 21);
		this.comboBoxReadOnly_18.TabIndex = 30;
		this.label_33.AutoSize = true;
		this.label_33.Location = new Point(11, 339);
		this.label_33.Margin = new Padding(2, 0, 2, 0);
		this.label_33.Name = "label36";
		this.label_33.Size = new Size(93, 13);
		this.label_33.TabIndex = 29;
		this.label_33.Text = "Длина КЛ, ВЛ, м";
		this.textBox_7.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_7.DataBindings.Add(new Binding("Text", this.bindingSource_2, "LengthLine", true));
		this.textBox_7.Location = new Point(127, 337);
		this.textBox_7.Margin = new Padding(2);
		this.textBox_7.Name = "txtLenghtLine";
		this.textBox_7.Size = new Size(207, 20);
		this.textBox_7.TabIndex = 28;
		this.checkBox_2.AutoSize = true;
		this.checkBox_2.DataBindings.Add(new Binding("Checked", this.bindingSource_2, "AutoProtect", true));
		this.checkBox_2.Location = new Point(14, 6);
		this.checkBox_2.Margin = new Padding(2);
		this.checkBox_2.Name = "chkAutoProtect";
		this.checkBox_2.Size = new Size(151, 17);
		this.checkBox_2.TabIndex = 11;
		this.checkBox_2.Text = "Автоматическая защита";
		this.checkBox_2.UseVisualStyleBackColor = true;
		this.label_34.Location = new Point(11, 306);
		this.label_34.Margin = new Padding(2, 0, 2, 0);
		this.label_34.Name = "label35";
		this.label_34.Size = new Size(158, 29);
		this.label_34.TabIndex = 27;
		this.label_34.Text = "Продолжительность работы оборудования с перегрузкой";
		this.comboBoxReadOnly_15.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.comboBoxReadOnly_15.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBoxReadOnly_15.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBoxReadOnly_15.DataBindings.Add(new Binding("SelectedValue", this.bindingSource_2, "idMark", true));
		this.comboBoxReadOnly_15.FormattingEnabled = true;
		this.comboBoxReadOnly_15.Location = new Point(127, 28);
		this.comboBoxReadOnly_15.Margin = new Padding(2);
		this.comboBoxReadOnly_15.Name = "cmbMarkEquipment";
		this.comboBoxReadOnly_15.ReadOnlyBackColor = SystemColors.Control;
		this.comboBoxReadOnly_15.ReadOnlyForeColor = SystemColors.WindowText;
		this.comboBoxReadOnly_15.Size = new Size(207, 21);
		this.comboBoxReadOnly_15.TabIndex = 3;
		this.textBox_8.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_8.DataBindings.Add(new Binding("Text", this.bindingSource_2, "LengthOverload", true));
		this.textBox_8.Location = new Point(184, 314);
		this.textBox_8.Margin = new Padding(2);
		this.textBox_8.Name = "txtLengthOverload";
		this.textBox_8.Size = new Size(150, 20);
		this.textBox_8.TabIndex = 26;
		this.comboBoxReadOnly_14.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.comboBoxReadOnly_14.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBoxReadOnly_14.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBoxReadOnly_14.DataBindings.Add(new Binding("SelectedValue", this.bindingSource_2, "idParameters", true));
		this.comboBoxReadOnly_14.FormattingEnabled = true;
		this.comboBoxReadOnly_14.Location = new Point(127, 52);
		this.comboBoxReadOnly_14.Margin = new Padding(2);
		this.comboBoxReadOnly_14.Name = "cmbParameters";
		this.comboBoxReadOnly_14.ReadOnlyBackColor = SystemColors.Control;
		this.comboBoxReadOnly_14.ReadOnlyForeColor = SystemColors.WindowText;
		this.comboBoxReadOnly_14.Size = new Size(207, 21);
		this.comboBoxReadOnly_14.TabIndex = 4;
		this.label_35.AutoSize = true;
		this.label_35.Location = new Point(11, 286);
		this.label_35.Margin = new Padding(2, 0, 2, 0);
		this.label_35.Name = "label34";
		this.label_35.Size = new Size(163, 13);
		this.label_35.TabIndex = 25;
		this.label_35.Text = "Условия отказа оборудования";
		this.label_25.AutoSize = true;
		this.label_25.Location = new Point(11, 30);
		this.label_25.Margin = new Padding(2, 0, 2, 0);
		this.label_25.Name = "label24";
		this.label_25.Size = new Size(40, 13);
		this.label_25.TabIndex = 5;
		this.label_25.Text = "Марка";
		this.textBox_9.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_9.DataBindings.Add(new Binding("Text", this.bindingSource_2, "ClauseFail", true));
		this.textBox_9.Location = new Point(184, 284);
		this.textBox_9.Margin = new Padding(2);
		this.textBox_9.Name = "txtClauseFail";
		this.textBox_9.Size = new Size(150, 20);
		this.textBox_9.TabIndex = 24;
		this.label_24.AutoSize = true;
		this.label_24.Location = new Point(11, 54);
		this.label_24.Margin = new Padding(2, 0, 2, 0);
		this.label_24.Name = "label25";
		this.label_24.Size = new Size(66, 13);
		this.label_24.TabIndex = 6;
		this.label_24.Text = "Параметры";
		this.label_36.AutoSize = true;
		this.label_36.Location = new Point(11, 262);
		this.label_36.Margin = new Padding(2, 0, 2, 0);
		this.label_36.Name = "label33";
		this.label_36.Size = new Size(111, 13);
		this.label_36.TabIndex = 23;
		this.label_36.Text = "Состояние нейтрали";
		this.comboBoxReadOnly_13.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.comboBoxReadOnly_13.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBoxReadOnly_13.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBoxReadOnly_13.DataBindings.Add(new Binding("SelectedValue", this.bindingSource_2, "idVoltage", true));
		this.comboBoxReadOnly_13.FormattingEnabled = true;
		this.comboBoxReadOnly_13.Location = new Point(166, 76);
		this.comboBoxReadOnly_13.Margin = new Padding(2);
		this.comboBoxReadOnly_13.Name = "cmbVoltage";
		this.comboBoxReadOnly_13.ReadOnlyBackColor = SystemColors.Control;
		this.comboBoxReadOnly_13.ReadOnlyForeColor = SystemColors.WindowText;
		this.comboBoxReadOnly_13.Size = new Size(168, 21);
		this.comboBoxReadOnly_13.TabIndex = 7;
		this.comboBoxReadOnly_19.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.comboBoxReadOnly_19.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBoxReadOnly_19.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBoxReadOnly_19.DataBindings.Add(new Binding("SelectedValue", this.bindingSource_2, "idNeutralState", true));
		this.comboBoxReadOnly_19.FormattingEnabled = true;
		this.comboBoxReadOnly_19.Location = new Point(127, 259);
		this.comboBoxReadOnly_19.Margin = new Padding(2);
		this.comboBoxReadOnly_19.Name = "cmbNeutralState";
		this.comboBoxReadOnly_19.ReadOnlyBackColor = SystemColors.Control;
		this.comboBoxReadOnly_19.ReadOnlyForeColor = SystemColors.WindowText;
		this.comboBoxReadOnly_19.Size = new Size(207, 21);
		this.comboBoxReadOnly_19.TabIndex = 22;
		this.label_23.AutoSize = true;
		this.label_23.Location = new Point(11, 79);
		this.label_23.Margin = new Padding(2, 0, 2, 0);
		this.label_23.Name = "label26";
		this.label_23.Size = new Size(154, 13);
		this.label_23.TabIndex = 8;
		this.label_23.Text = "Контсруктивное напряжение";
		this.label_30.AutoSize = true;
		this.label_30.Location = new Point(11, 239);
		this.label_30.Margin = new Padding(2, 0, 2, 0);
		this.label_30.Name = "label32";
		this.label_30.Size = new Size(172, 13);
		this.label_30.TabIndex = 21;
		this.label_30.Text = "Год изготовления оборудования";
		this.comboBoxReadOnly_12.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.comboBoxReadOnly_12.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBoxReadOnly_12.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBoxReadOnly_12.DataBindings.Add(new Binding("SelectedValue", this.bindingSource_2, "nodeDetail", true));
		this.comboBoxReadOnly_12.FormattingEnabled = true;
		this.comboBoxReadOnly_12.Location = new Point(127, 101);
		this.comboBoxReadOnly_12.Margin = new Padding(2);
		this.comboBoxReadOnly_12.Name = "cmbNodeDetail";
		this.comboBoxReadOnly_12.ReadOnlyBackColor = SystemColors.Control;
		this.comboBoxReadOnly_12.ReadOnlyForeColor = SystemColors.WindowText;
		this.comboBoxReadOnly_12.Size = new Size(207, 21);
		this.comboBoxReadOnly_12.TabIndex = 9;
		this.textBox_6.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_6.DataBindings.Add(new Binding("Text", this.bindingSource_2, "YearManufacture", true));
		this.textBox_6.Location = new Point(184, 237);
		this.textBox_6.Margin = new Padding(2);
		this.textBox_6.Name = "txtYearManufature";
		this.textBox_6.Size = new Size(150, 20);
		this.textBox_6.TabIndex = 20;
		this.textBox_6.Enter += this.textBox_6_Enter;
		this.textBox_6.Leave += this.textBox_6_Leave;
		this.JmtCydXvoo4.AutoSize = true;
		this.JmtCydXvoo4.Location = new Point(11, 103);
		this.JmtCydXvoo4.Margin = new Padding(2, 0, 2, 0);
		this.JmtCydXvoo4.Name = "label27";
		this.JmtCydXvoo4.Size = new Size(74, 13);
		this.JmtCydXvoo4.TabIndex = 10;
		this.JmtCydXvoo4.Text = "Узел. деталь";
		this.label_28.AutoSize = true;
		this.label_28.Location = new Point(11, 216);
		this.label_28.Margin = new Padding(2, 0, 2, 0);
		this.label_28.Name = "label31";
		this.label_28.Size = new Size(97, 13);
		this.label_28.TabIndex = 19;
		this.label_28.Text = "Заводской номер";
		this.comboBoxReadOnly_16.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.comboBoxReadOnly_16.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBoxReadOnly_16.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBoxReadOnly_16.DataBindings.Add(new Binding("SelectedValue", this.bindingSource_2, "idVoltageSeti", true));
		this.comboBoxReadOnly_16.FormattingEnabled = true;
		this.comboBoxReadOnly_16.Location = new Point(166, 167);
		this.comboBoxReadOnly_16.Margin = new Padding(2);
		this.comboBoxReadOnly_16.Name = "cmbVoltageSeti";
		this.comboBoxReadOnly_16.ReadOnlyBackColor = SystemColors.Control;
		this.comboBoxReadOnly_16.ReadOnlyForeColor = SystemColors.WindowText;
		this.comboBoxReadOnly_16.Size = new Size(168, 21);
		this.comboBoxReadOnly_16.TabIndex = 12;
		this.textBox_4.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_4.DataBindings.Add(new Binding("Text", this.bindingSource_2, "FactoryNumber", true));
		this.textBox_4.Location = new Point(127, 214);
		this.textBox_4.Margin = new Padding(2);
		this.textBox_4.Name = "txtFactoryNumber";
		this.textBox_4.Size = new Size(207, 20);
		this.textBox_4.TabIndex = 18;
		this.label_26.AutoSize = true;
		this.label_26.Location = new Point(11, 169);
		this.label_26.Margin = new Padding(2, 0, 2, 0);
		this.label_26.Name = "label28";
		this.label_26.Size = new Size(97, 13);
		this.label_26.TabIndex = 13;
		this.label_26.Text = "Напряжение сети";
		this.label_29.AutoSize = true;
		this.label_29.Location = new Point(11, 194);
		this.label_29.Margin = new Padding(2, 0, 2, 0);
		this.label_29.Name = "label30";
		this.label_29.Size = new Size(152, 13);
		this.label_29.TabIndex = 17;
		this.label_29.Text = "Изготовитель оборудования";
		this.ouoCyeHwemd.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.ouoCyeHwemd.DataBindings.Add(new Binding("Text", this.bindingSource_2, "CountDefectEquipment", true));
		this.ouoCyeHwemd.Location = new Point(207, 144);
		this.ouoCyeHwemd.Margin = new Padding(2);
		this.ouoCyeHwemd.Name = "txtCountDefectEquipment";
		this.ouoCyeHwemd.Size = new Size(127, 20);
		this.ouoCyeHwemd.TabIndex = 14;
		this.textBox_5.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_5.DataBindings.Add(new Binding("Text", this.bindingSource_2, "Manufacturer", true));
		this.textBox_5.Location = new Point(166, 191);
		this.textBox_5.Margin = new Padding(2);
		this.textBox_5.Name = "txtManufacturer";
		this.textBox_5.Size = new Size(168, 20);
		this.textBox_5.TabIndex = 16;
		this.label_27.AutoSize = true;
		this.label_27.Location = new Point(11, 147);
		this.label_27.Margin = new Padding(2, 0, 2, 0);
		this.label_27.Name = "label29";
		this.label_27.Size = new Size(184, 13);
		this.label_27.TabIndex = 15;
		this.label_27.Text = "Кол-во отказавшего оборудования";
		this.label_31.AutoSize = true;
		this.label_31.Location = new Point(15, 30);
		this.label_31.Margin = new Padding(2, 0, 2, 0);
		this.label_31.Name = "label38";
		this.label_31.Size = new Size(91, 13);
		this.label_31.TabIndex = 33;
		this.label_31.Text = "Условия работы";
		this.comboBoxReadOnly_17.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.comboBoxReadOnly_17.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBoxReadOnly_17.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBoxReadOnly_17.DataBindings.Add(new Binding("SelectedValue", this.bindingSource_2, "ClauseWork", true));
		this.comboBoxReadOnly_17.FormattingEnabled = true;
		this.comboBoxReadOnly_17.Location = new Point(186, 27);
		this.comboBoxReadOnly_17.Margin = new Padding(2);
		this.comboBoxReadOnly_17.Name = "cmbClauseWork";
		this.comboBoxReadOnly_17.ReadOnlyBackColor = SystemColors.Control;
		this.comboBoxReadOnly_17.ReadOnlyForeColor = SystemColors.WindowText;
		this.comboBoxReadOnly_17.Size = new Size(226, 21);
		this.comboBoxReadOnly_17.TabIndex = 32;
		this.label_43.AutoSize = true;
		this.label_43.Location = new Point(14, 147);
		this.label_43.Margin = new Padding(2, 0, 2, 0);
		this.label_43.Name = "label45";
		this.label_43.Size = new Size(119, 13);
		this.label_43.TabIndex = 23;
		this.label_43.Text = "Дата восстановления";
		this.nullableDateTimePicker_4.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.nullableDateTimePicker_4.CustomFormat = "HH:mm";
		this.nullableDateTimePicker_4.DataBindings.Add(new Binding("Value", this.bindingSource_2, "timeRecovery", true));
		this.nullableDateTimePicker_4.Location = new Point(238, 143);
		this.nullableDateTimePicker_4.Margin = new Padding(2);
		this.nullableDateTimePicker_4.Name = "dtpTimeRecovery";
		this.nullableDateTimePicker_4.Size = new Size(174, 20);
		this.nullableDateTimePicker_4.TabIndex = 22;
		this.nullableDateTimePicker_4.Value = new DateTime(2016, 4, 12, 13, 47, 41, 144);
		this.nullableDateTimePicker_4.ValueChanged += this.nullableDateTimePicker_4_ValueChanged;
		this.label_41.AutoSize = true;
		this.label_41.Location = new Point(14, 124);
		this.label_41.Margin = new Padding(2, 0, 2, 0);
		this.label_41.Name = "label44";
		this.label_41.Size = new Size(220, 13);
		this.label_41.TabIndex = 21;
		this.label_41.Text = "Последние эксплуатационные испытания";
		this.label_42.AutoSize = true;
		this.label_42.Location = new Point(14, 100);
		this.label_42.Margin = new Padding(2, 0, 2, 0);
		this.label_42.Name = "label43";
		this.label_42.Size = new Size(182, 13);
		this.label_42.TabIndex = 20;
		this.label_42.Text = "Срок службы поврежденного узла";
		this.textBox_12.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_12.DataBindings.Add(new Binding("Text", this.bindingSource_2, "lenghtWorkEquipment", true, DataSourceUpdateMode.OnPropertyChanged));
		this.textBox_12.Location = new Point(201, 98);
		this.textBox_12.Margin = new Padding(2);
		this.textBox_12.Name = "txtLengthWorkEquipment";
		this.textBox_12.Size = new Size(211, 20);
		this.textBox_12.TabIndex = 19;
		this.label_39.AutoSize = true;
		this.label_39.Location = new Point(15, 77);
		this.label_39.Margin = new Padding(2, 0, 2, 0);
		this.label_39.Name = "label42";
		this.label_39.Size = new Size(117, 13);
		this.label_39.TabIndex = 18;
		this.label_39.Text = "Начало эксплуатации";
		this.textBox_10.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_10.DataBindings.Add(new Binding("Text", this.bindingSource_2, "yearBegEquipment", true, DataSourceUpdateMode.OnPropertyChanged));
		this.textBox_10.Location = new Point(186, 75);
		this.textBox_10.Margin = new Padding(2);
		this.textBox_10.Name = "txtYearBegEquipment";
		this.textBox_10.Size = new Size(226, 20);
		this.textBox_10.TabIndex = 17;
		this.textBox_10.TextChanged += this.textBox_10_TextChanged;
		this.label_40.AutoSize = true;
		this.label_40.Location = new Point(15, 54);
		this.label_40.Margin = new Padding(2, 0, 2, 0);
		this.label_40.Name = "label41";
		this.label_40.Size = new Size(166, 13);
		this.label_40.TabIndex = 16;
		this.label_40.Text = "Сопутсвующие обстоятельства";
		this.textBox_11.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_11.DataBindings.Add(new Binding("Text", this.bindingSource_2, "AssociatedFact", true));
		this.textBox_11.Location = new Point(186, 52);
		this.textBox_11.Margin = new Padding(2);
		this.textBox_11.Name = "txtAssociatedFact";
		this.textBox_11.Size = new Size(226, 20);
		this.textBox_11.TabIndex = 15;
		this.label_37.AutoSize = true;
		this.label_37.Location = new Point(15, 289);
		this.label_37.Margin = new Padding(2, 0, 2, 0);
		this.label_37.Name = "label40";
		this.label_37.Size = new Size(121, 13);
		this.label_37.TabIndex = 8;
		this.label_37.Text = "Причина повреждения";
		this.label_37.Visible = false;
		this.comboBoxReadOnly_20.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.comboBoxReadOnly_20.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBoxReadOnly_20.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBoxReadOnly_20.DataBindings.Add(new Binding("SelectedValue", this.bindingSource_2, "idReasonDamage", true));
		this.comboBoxReadOnly_20.FormattingEnabled = true;
		this.comboBoxReadOnly_20.Location = new Point(141, 287);
		this.comboBoxReadOnly_20.Margin = new Padding(2);
		this.comboBoxReadOnly_20.Name = "cmbReasonDamage";
		this.comboBoxReadOnly_20.ReadOnlyBackColor = SystemColors.Control;
		this.comboBoxReadOnly_20.ReadOnlyForeColor = SystemColors.WindowText;
		this.comboBoxReadOnly_20.Size = new Size(239, 21);
		this.comboBoxReadOnly_20.TabIndex = 7;
		this.comboBoxReadOnly_20.Visible = false;
		this.label_38.AutoSize = true;
		this.label_38.Location = new Point(15, 265);
		this.label_38.Margin = new Padding(2, 0, 2, 0);
		this.label_38.Name = "label39";
		this.label_38.Size = new Size(126, 13);
		this.label_38.TabIndex = 6;
		this.label_38.Text = "Характер повреждения";
		this.label_38.Visible = false;
		this.comboBoxReadOnly_21.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.comboBoxReadOnly_21.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBoxReadOnly_21.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBoxReadOnly_21.DataBindings.Add(new Binding("SelectedValue", this.bindingSource_2, "idCharacterDamage", true));
		this.comboBoxReadOnly_21.FormattingEnabled = true;
		this.comboBoxReadOnly_21.Location = new Point(141, 263);
		this.comboBoxReadOnly_21.Margin = new Padding(2);
		this.comboBoxReadOnly_21.Name = "cmbCharacterDamage";
		this.comboBoxReadOnly_21.ReadOnlyBackColor = SystemColors.Control;
		this.comboBoxReadOnly_21.ReadOnlyForeColor = SystemColors.WindowText;
		this.comboBoxReadOnly_21.Size = new Size(239, 21);
		this.comboBoxReadOnly_21.TabIndex = 4;
		this.comboBoxReadOnly_21.Visible = false;
		this.nullableDateTimePicker_3.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.nullableDateTimePicker_3.CustomFormat = "yyyy г.";
		this.nullableDateTimePicker_3.DataBindings.Add(new Binding("Value", this.bindingSource_2, "LastDateTest", true));
		this.nullableDateTimePicker_3.Format = DateTimePickerFormat.Custom;
		this.nullableDateTimePicker_3.Location = new Point(238, 120);
		this.nullableDateTimePicker_3.Margin = new Padding(2);
		this.nullableDateTimePicker_3.MinDate = new DateTime(1913, 1, 1, 0, 0, 0, 0);
		this.nullableDateTimePicker_3.Name = "dtpLastDateTest";
		this.nullableDateTimePicker_3.ShowUpDown = true;
		this.nullableDateTimePicker_3.Size = new Size(174, 20);
		this.nullableDateTimePicker_3.TabIndex = 0;
		this.nullableDateTimePicker_3.Value = new DateTime(2016, 4, 12, 13, 47, 41, 144);
		this.dataGridView_0.AllowUserToAddRows = false;
		this.dataGridView_0.AllowUserToDeleteRows = false;
		this.dataGridView_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.dataGridView_0.AutoGenerateColumns = false;
		this.dataGridView_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView_0.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewComboBoxColumn_6,
			this.dataGridViewTextBoxColumn_8,
			this.dataGridViewTextBoxColumn_9,
			this.dataGridViewTextBoxColumn_10,
			this.dataGridViewTextBoxColumn_11,
			this.dataGridViewTextBoxColumn_12,
			this.dataGridViewTextBoxColumn_13,
			this.dataGridViewTextBoxColumn_14
		});
		this.dataGridView_0.DataSource = this.bindingSource_2;
		this.dataGridView_0.Location = new Point(3, 39);
		this.dataGridView_0.Margin = new Padding(2);
		this.dataGridView_0.Name = "dgvEquipment";
		this.dataGridView_0.RowTemplate.Height = 24;
		this.dataGridView_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		this.dataGridView_0.Size = new Size(773, 115);
		this.dataGridView_0.TabIndex = 2;
		this.dataGridView_0.RowsAdded += this.dataGridView_0_RowsAdded;
		this.dataGridViewComboBoxColumn_6.DataPropertyName = "col1";
		this.dataGridViewComboBoxColumn_6.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
		this.dataGridViewComboBoxColumn_6.HeaderText = "Тип";
		this.dataGridViewComboBoxColumn_6.Name = "typeEquipmentDgvColumn";
		this.dataGridViewComboBoxColumn_6.ReadOnly = true;
		this.dataGridViewComboBoxColumn_6.Resizable = DataGridViewTriState.True;
		this.dataGridViewComboBoxColumn_6.SortMode = DataGridViewColumnSortMode.Automatic;
		this.dataGridViewTextBoxColumn_8.DataPropertyName = "id";
		this.dataGridViewTextBoxColumn_8.HeaderText = "id";
		this.dataGridViewTextBoxColumn_8.Name = "idDamCharacterDgvColumn";
		this.dataGridViewTextBoxColumn_8.ReadOnly = true;
		this.dataGridViewTextBoxColumn_8.Visible = false;
		this.dataGridViewTextBoxColumn_9.DataPropertyName = "idSchmObj";
		this.dataGridViewTextBoxColumn_9.HeaderText = "idSchmObj";
		this.dataGridViewTextBoxColumn_9.Name = "idSchmObjDgvColumn";
		this.dataGridViewTextBoxColumn_9.ReadOnly = true;
		this.dataGridViewTextBoxColumn_9.Visible = false;
		this.dataGridViewTextBoxColumn_10.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_10.HeaderText = "Оборудование";
		this.dataGridViewTextBoxColumn_10.Name = "schmObjDgvColumn";
		this.dataGridViewTextBoxColumn_10.ReadOnly = true;
		this.dataGridViewTextBoxColumn_11.DataPropertyName = "idDamage";
		this.dataGridViewTextBoxColumn_11.HeaderText = "idDamage";
		this.dataGridViewTextBoxColumn_11.Name = "idDamageDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_11.ReadOnly = true;
		this.dataGridViewTextBoxColumn_11.Visible = false;
		this.dataGridViewTextBoxColumn_12.DataPropertyName = "col2";
		this.dataGridViewTextBoxColumn_12.HeaderText = "col2";
		this.dataGridViewTextBoxColumn_12.Name = "col2DataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_12.ReadOnly = true;
		this.dataGridViewTextBoxColumn_12.Visible = false;
		this.dataGridViewTextBoxColumn_13.DataPropertyName = "col3";
		this.dataGridViewTextBoxColumn_13.HeaderText = "col3";
		this.dataGridViewTextBoxColumn_13.Name = "col3DataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_13.ReadOnly = true;
		this.dataGridViewTextBoxColumn_13.Visible = false;
		this.dataGridViewTextBoxColumn_14.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_14.DataPropertyName = "SchmObjName";
		this.dataGridViewTextBoxColumn_14.HeaderText = "Примечание";
		this.dataGridViewTextBoxColumn_14.Name = "schmObjNameDgvColumn";
		this.toolStrip_0.GripStyle = ToolStripGripStyle.Hidden;
		this.toolStrip_0.Items.AddRange(new ToolStripItem[]
		{
			this.toolStripButton_0,
			this.toolStripButton_1
		});
		this.toolStrip_0.Location = new Point(3, 17);
		this.toolStrip_0.Name = "toolStripEquipment";
		this.toolStrip_0.Size = new Size(770, 25);
		this.toolStrip_0.TabIndex = 1;
		this.toolStrip_0.Text = "toolStrip1";
		this.toolStripButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_0.Image = (Image)componentResourceManager.GetObject("toolBtnAddEquipment.Image");
		this.toolStripButton_0.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_0.Name = "toolBtnAddEquipment";
		this.toolStripButton_0.Size = new Size(23, 22);
		this.toolStripButton_0.Text = "Добавить отказавшее оборудование";
		this.toolStripButton_0.Click += this.toolStripButton_0_Click;
		this.toolStripButton_1.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_1.Image = (Image)componentResourceManager.GetObject("toolBtnDelEquipment.Image");
		this.toolStripButton_1.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_1.Name = "toolBtnDelEquipment";
		this.toolStripButton_1.Size = new Size(23, 22);
		this.toolStripButton_1.Text = "Удалить отказавшее оборудование";
		this.toolStripButton_1.Click += this.toolStripButton_1_Click;
		this.label_22.Dock = DockStyle.Top;
		this.label_22.Font = new Font("Microsoft Sans Serif", 7.8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.label_22.Location = new Point(3, 3);
		this.label_22.Margin = new Padding(2, 0, 2, 0);
		this.label_22.Name = "label23";
		this.label_22.Size = new Size(770, 14);
		this.label_22.TabIndex = 0;
		this.label_22.Text = "Сведения о поврежденном или отказавшем электротехническом оборудовании элеткрических сетей";
		this.label_22.TextAlign = ContentAlignment.TopCenter;
		this.tabPage_2.Controls.Add(this.textBox_19);
		this.tabPage_2.Controls.Add(this.label_54);
		this.tabPage_2.Controls.Add(this.comboBoxReadOnly_27);
		this.tabPage_2.Controls.Add(this.textBox_20);
		this.tabPage_2.Controls.Add(this.label_55);
		this.tabPage_2.Controls.Add(this.comboBoxReadOnly_28);
		this.tabPage_2.Controls.Add(this.richTextBox_0);
		this.tabPage_2.Controls.Add(this.label_47);
		this.tabPage_2.Controls.Add(this.textBox_15);
		this.tabPage_2.Controls.Add(this.label_48);
		this.tabPage_2.Controls.Add(this.comboBoxReadOnly_23);
		this.tabPage_2.Controls.Add(this.textBox_16);
		this.tabPage_2.Controls.Add(this.label_49);
		this.tabPage_2.Controls.Add(this.comboBoxReadOnly_24);
		this.tabPage_2.Controls.Add(this.textBox_17);
		this.tabPage_2.Controls.Add(this.label_50);
		this.tabPage_2.Controls.Add(this.comboBoxReadOnly_25);
		this.tabPage_2.Controls.Add(this.label_51);
		this.tabPage_2.Controls.Add(this.textBox_14);
		this.tabPage_2.Controls.Add(this.label_45);
		this.tabPage_2.Controls.Add(this.comboBoxReadOnly_22);
		this.tabPage_2.Controls.Add(this.label_46);
		this.tabPage_2.Controls.Add(this.textBox_13);
		this.tabPage_2.Controls.Add(this.label_44);
		this.tabPage_2.Location = new Point(4, 22);
		this.tabPage_2.Margin = new Padding(2);
		this.tabPage_2.Name = "tabPageComission";
		this.tabPage_2.Size = new Size(776, 541);
		this.tabPage_2.TabIndex = 2;
		this.tabPage_2.Text = "Комиссия";
		this.tabPage_2.UseVisualStyleBackColor = true;
		this.textBox_19.DataBindings.Add(new Binding("Text", this.dataSet_0, "dtComission.PostMember5", true, DataSourceUpdateMode.OnPropertyChanged));
		this.textBox_19.Location = new Point(296, 199);
		this.textBox_19.Margin = new Padding(2);
		this.textBox_19.Name = "txtPostMemeber5";
		this.textBox_19.Size = new Size(259, 20);
		this.textBox_19.TabIndex = 23;
		this.label_54.AutoSize = true;
		this.label_54.Location = new Point(230, 201);
		this.label_54.Margin = new Padding(2, 0, 2, 0);
		this.label_54.Name = "label55";
		this.label_54.Size = new Size(65, 13);
		this.label_54.TabIndex = 22;
		this.label_54.Text = "Должность";
		this.comboBoxReadOnly_27.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBoxReadOnly_27.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBoxReadOnly_27.DataBindings.Add(new Binding("SelectedValue", this.dataSet_0, "dtComission.Member5", true));
		this.comboBoxReadOnly_27.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBoxReadOnly_27.FormattingEnabled = true;
		this.comboBoxReadOnly_27.Location = new Point(9, 199);
		this.comboBoxReadOnly_27.Margin = new Padding(2);
		this.comboBoxReadOnly_27.Name = "cmbMemberComission5";
		this.comboBoxReadOnly_27.ReadOnlyBackColor = SystemColors.Control;
		this.comboBoxReadOnly_27.ReadOnlyForeColor = SystemColors.WindowText;
		this.comboBoxReadOnly_27.Size = new Size(201, 21);
		this.comboBoxReadOnly_27.TabIndex = 21;
		this.comboBoxReadOnly_27.SelectedValueChanged += this.comboBoxReadOnly_22_SelectedValueChanged;
		this.textBox_20.DataBindings.Add(new Binding("Text", this.dataSet_0, "dtComission.PostMember4", true, DataSourceUpdateMode.OnPropertyChanged));
		this.textBox_20.Location = new Point(296, 174);
		this.textBox_20.Margin = new Padding(2);
		this.textBox_20.Name = "txtPostMemeber4";
		this.textBox_20.Size = new Size(259, 20);
		this.textBox_20.TabIndex = 20;
		this.label_55.AutoSize = true;
		this.label_55.Location = new Point(230, 177);
		this.label_55.Margin = new Padding(2, 0, 2, 0);
		this.label_55.Name = "label56";
		this.label_55.Size = new Size(65, 13);
		this.label_55.TabIndex = 19;
		this.label_55.Text = "Должность";
		this.comboBoxReadOnly_28.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBoxReadOnly_28.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBoxReadOnly_28.DataBindings.Add(new Binding("SelectedValue", this.dataSet_0, "dtComission.Member4", true));
		this.comboBoxReadOnly_28.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBoxReadOnly_28.FormattingEnabled = true;
		this.comboBoxReadOnly_28.Location = new Point(9, 174);
		this.comboBoxReadOnly_28.Margin = new Padding(2);
		this.comboBoxReadOnly_28.Name = "cmbMemberComission4";
		this.comboBoxReadOnly_28.ReadOnlyBackColor = SystemColors.Control;
		this.comboBoxReadOnly_28.ReadOnlyForeColor = SystemColors.WindowText;
		this.comboBoxReadOnly_28.Size = new Size(201, 21);
		this.comboBoxReadOnly_28.TabIndex = 18;
		this.comboBoxReadOnly_28.SelectedValueChanged += this.comboBoxReadOnly_22_SelectedValueChanged;
		this.richTextBox_0.AcceptsTab = true;
		this.richTextBox_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.richTextBox_0.DataBindings.Add(new Binding("Text", this.class171_0, "tJ_DamageActDetection.TotalComission", true));
		this.richTextBox_0.Location = new Point(9, 241);
		this.richTextBox_0.Margin = new Padding(2);
		this.richTextBox_0.Name = "txtTotalComission";
		this.richTextBox_0.Size = new Size(765, 301);
		this.richTextBox_0.TabIndex = 17;
		this.richTextBox_0.Text = "";
		this.label_47.AutoSize = true;
		this.label_47.Font = new Font("Microsoft Sans Serif", 7.8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.label_47.Location = new Point(7, 226);
		this.label_47.Margin = new Padding(2, 0, 2, 0);
		this.label_47.Name = "label53";
		this.label_47.Size = new Size(116, 13);
		this.label_47.TabIndex = 16;
		this.label_47.Text = "Выводы комиссии";
		this.textBox_15.DataBindings.Add(new Binding("Text", this.dataSet_0, "dtComission.PostMember3", true, DataSourceUpdateMode.OnPropertyChanged));
		this.textBox_15.Location = new Point(296, 149);
		this.textBox_15.Margin = new Padding(2);
		this.textBox_15.Name = "txtPostMemeber3";
		this.textBox_15.Size = new Size(259, 20);
		this.textBox_15.TabIndex = 15;
		this.label_48.AutoSize = true;
		this.label_48.Location = new Point(230, 151);
		this.label_48.Margin = new Padding(2, 0, 2, 0);
		this.label_48.Name = "label52";
		this.label_48.Size = new Size(65, 13);
		this.label_48.TabIndex = 14;
		this.label_48.Text = "Должность";
		this.comboBoxReadOnly_23.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBoxReadOnly_23.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBoxReadOnly_23.DataBindings.Add(new Binding("SelectedValue", this.dataSet_0, "dtComission.Member3", true));
		this.comboBoxReadOnly_23.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBoxReadOnly_23.FormattingEnabled = true;
		this.comboBoxReadOnly_23.Location = new Point(9, 149);
		this.comboBoxReadOnly_23.Margin = new Padding(2);
		this.comboBoxReadOnly_23.Name = "cmbMemberComission3";
		this.comboBoxReadOnly_23.ReadOnlyBackColor = SystemColors.Control;
		this.comboBoxReadOnly_23.ReadOnlyForeColor = SystemColors.WindowText;
		this.comboBoxReadOnly_23.Size = new Size(201, 21);
		this.comboBoxReadOnly_23.TabIndex = 13;
		this.comboBoxReadOnly_23.SelectedValueChanged += this.comboBoxReadOnly_22_SelectedValueChanged;
		this.textBox_16.DataBindings.Add(new Binding("Text", this.dataSet_0, "dtComission.PostMember2", true, DataSourceUpdateMode.OnPropertyChanged));
		this.textBox_16.Location = new Point(296, 124);
		this.textBox_16.Margin = new Padding(2);
		this.textBox_16.Name = "txtPostMemeber2";
		this.textBox_16.Size = new Size(259, 20);
		this.textBox_16.TabIndex = 12;
		this.label_49.AutoSize = true;
		this.label_49.Location = new Point(230, 127);
		this.label_49.Margin = new Padding(2, 0, 2, 0);
		this.label_49.Name = "label51";
		this.label_49.Size = new Size(65, 13);
		this.label_49.TabIndex = 11;
		this.label_49.Text = "Должность";
		this.comboBoxReadOnly_24.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBoxReadOnly_24.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBoxReadOnly_24.DataBindings.Add(new Binding("SelectedValue", this.dataSet_0, "dtComission.Member2", true));
		this.comboBoxReadOnly_24.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBoxReadOnly_24.FormattingEnabled = true;
		this.comboBoxReadOnly_24.Location = new Point(9, 124);
		this.comboBoxReadOnly_24.Margin = new Padding(2);
		this.comboBoxReadOnly_24.Name = "cmbMemberComission2";
		this.comboBoxReadOnly_24.ReadOnlyBackColor = SystemColors.Control;
		this.comboBoxReadOnly_24.ReadOnlyForeColor = SystemColors.WindowText;
		this.comboBoxReadOnly_24.Size = new Size(201, 21);
		this.comboBoxReadOnly_24.TabIndex = 10;
		this.comboBoxReadOnly_24.SelectedValueChanged += this.comboBoxReadOnly_22_SelectedValueChanged;
		this.textBox_17.DataBindings.Add(new Binding("Text", this.dataSet_0, "dtComission.PostMember1", true, DataSourceUpdateMode.OnPropertyChanged));
		this.textBox_17.Location = new Point(296, 100);
		this.textBox_17.Margin = new Padding(2);
		this.textBox_17.Name = "txtPostMemeber1";
		this.textBox_17.Size = new Size(259, 20);
		this.textBox_17.TabIndex = 9;
		this.label_50.AutoSize = true;
		this.label_50.Location = new Point(230, 102);
		this.label_50.Margin = new Padding(2, 0, 2, 0);
		this.label_50.Name = "label50";
		this.label_50.Size = new Size(65, 13);
		this.label_50.TabIndex = 8;
		this.label_50.Text = "Должность";
		this.comboBoxReadOnly_25.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBoxReadOnly_25.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBoxReadOnly_25.DataBindings.Add(new Binding("SelectedValue", this.dataSet_0, "dtComission.Member1", true));
		this.comboBoxReadOnly_25.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBoxReadOnly_25.FormattingEnabled = true;
		this.comboBoxReadOnly_25.Location = new Point(9, 100);
		this.comboBoxReadOnly_25.Margin = new Padding(2);
		this.comboBoxReadOnly_25.Name = "cmbMemberComission1";
		this.comboBoxReadOnly_25.ReadOnlyBackColor = SystemColors.Control;
		this.comboBoxReadOnly_25.ReadOnlyForeColor = SystemColors.WindowText;
		this.comboBoxReadOnly_25.Size = new Size(201, 21);
		this.comboBoxReadOnly_25.TabIndex = 7;
		this.comboBoxReadOnly_25.SelectedValueChanged += this.comboBoxReadOnly_22_SelectedValueChanged;
		this.label_51.AutoSize = true;
		this.label_51.Location = new Point(7, 84);
		this.label_51.Margin = new Padding(2, 0, 2, 0);
		this.label_51.Name = "label49";
		this.label_51.Size = new Size(94, 13);
		this.label_51.TabIndex = 6;
		this.label_51.Text = "Члены комиссии";
		this.textBox_14.DataBindings.Add(new Binding("Text", this.dataSet_0, "dtComission.PostChairman", true, DataSourceUpdateMode.OnPropertyChanged));
		this.textBox_14.Location = new Point(296, 52);
		this.textBox_14.Margin = new Padding(2);
		this.textBox_14.Name = "txtPostChairman";
		this.textBox_14.Size = new Size(259, 20);
		this.textBox_14.TabIndex = 5;
		this.label_45.AutoSize = true;
		this.label_45.Location = new Point(230, 54);
		this.label_45.Margin = new Padding(2, 0, 2, 0);
		this.label_45.Name = "label48";
		this.label_45.Size = new Size(65, 13);
		this.label_45.TabIndex = 4;
		this.label_45.Text = "Должность";
		this.comboBoxReadOnly_22.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBoxReadOnly_22.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBoxReadOnly_22.DataBindings.Add(new Binding("SelectedValue", this.dataSet_0, "dtComission.Chairman", true));
		this.comboBoxReadOnly_22.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBoxReadOnly_22.FormattingEnabled = true;
		this.comboBoxReadOnly_22.Location = new Point(9, 52);
		this.comboBoxReadOnly_22.Margin = new Padding(2);
		this.comboBoxReadOnly_22.Name = "cmbChairman";
		this.comboBoxReadOnly_22.ReadOnlyBackColor = SystemColors.Control;
		this.comboBoxReadOnly_22.ReadOnlyForeColor = SystemColors.WindowText;
		this.comboBoxReadOnly_22.Size = new Size(201, 21);
		this.comboBoxReadOnly_22.TabIndex = 3;
		this.comboBoxReadOnly_22.SelectedValueChanged += this.comboBoxReadOnly_22_SelectedValueChanged;
		this.label_46.AutoSize = true;
		this.label_46.Location = new Point(7, 36);
		this.label_46.Margin = new Padding(2, 0, 2, 0);
		this.label_46.Name = "label47";
		this.label_46.Size = new Size(80, 13);
		this.label_46.TabIndex = 2;
		this.label_46.Text = "Председатель";
		this.textBox_13.DataBindings.Add(new Binding("Text", this.dataSet_0, "dtComission.Order", true));
		this.textBox_13.Location = new Point(430, 11);
		this.textBox_13.Margin = new Padding(2);
		this.textBox_13.Name = "txtOrder";
		this.textBox_13.Size = new Size(242, 20);
		this.textBox_13.TabIndex = 1;
		this.label_44.AutoSize = true;
		this.label_44.Font = new Font("Microsoft Sans Serif", 7.8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.label_44.Location = new Point(58, 13);
		this.label_44.Margin = new Padding(2, 0, 2, 0);
		this.label_44.Name = "label46";
		this.label_44.Size = new Size(369, 13);
		this.label_44.TabIndex = 0;
		this.label_44.Text = "Комиссия, расследовавшая аварии, назначена приказом от";
		this.tabPage_3.Location = new Point(4, 22);
		this.tabPage_3.Margin = new Padding(2);
		this.tabPage_3.Name = "tabPagePrint";
		this.tabPage_3.Padding = new Padding(2);
		this.tabPage_3.Size = new Size(776, 541);
		this.tabPage_3.TabIndex = 3;
		this.tabPage_3.Text = "Печать";
		this.tabPage_3.UseVisualStyleBackColor = true;
		this.button_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.button_0.DialogResult = DialogResult.OK;
		this.button_0.Location = new Point(12, 573);
		this.button_0.Name = "buttonSave";
		this.button_0.Size = new Size(75, 23);
		this.button_0.TabIndex = 1;
		this.button_0.Text = "Сохранить";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_0.Click += this.button_0_Click;
		this.button_1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.button_1.DialogResult = DialogResult.Cancel;
		this.button_1.Location = new Point(700, 570);
		this.button_1.Name = "buttonCancel";
		this.button_1.Size = new Size(75, 23);
		this.button_1.TabIndex = 2;
		this.button_1.Text = "Отмена";
		this.button_1.UseVisualStyleBackColor = true;
		this.button_1.Click += this.button_1_Click;
		this.checkBox_3.Anchor = AnchorStyles.Bottom;
		this.checkBox_3.AutoSize = true;
		this.checkBox_3.DataBindings.Add(new Binding("Checked", this.class171_0, "tJ_Damage.isApply", true));
		this.checkBox_3.Location = new Point(127, 580);
		this.checkBox_3.Margin = new Padding(2);
		this.checkBox_3.Name = "chkApply";
		this.checkBox_3.Size = new Size(82, 17);
		this.checkBox_3.TabIndex = 3;
		this.checkBox_3.Text = "Исполнено";
		this.checkBox_3.UseVisualStyleBackColor = true;
		this.checkBox_3.CheckedChanged += this.checkBox_3_CheckedChanged;
		this.label_52.Anchor = AnchorStyles.Bottom;
		this.label_52.AutoSize = true;
		this.label_52.Location = new Point(438, 581);
		this.label_52.Margin = new Padding(2, 0, 2, 0);
		this.label_52.Name = "label54";
		this.label_52.Size = new Size(77, 13);
		this.label_52.TabIndex = 5;
		this.label_52.Text = "Дата и время";
		this.bindingSource_3.DataMember = "tJ_Damage";
		this.bindingSource_3.DataSource = this.class171_0;
		this.dataGridViewComboBoxColumn_5.DataPropertyName = "col1";
		this.dataGridViewComboBoxColumn_5.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
		this.dataGridViewComboBoxColumn_5.HeaderText = "Тип";
		this.dataGridViewComboBoxColumn_5.Name = "dataGridViewComboBoxColumn1";
		this.dataGridViewComboBoxColumn_5.ReadOnly = true;
		this.dataGridViewComboBoxColumn_5.Resizable = DataGridViewTriState.True;
		this.dataGridViewComboBoxColumn_5.SortMode = DataGridViewColumnSortMode.Automatic;
		this.dataGridViewTextBoxColumn_1.DataPropertyName = "id";
		this.dataGridViewTextBoxColumn_1.HeaderText = "id";
		this.dataGridViewTextBoxColumn_1.Name = "dataGridViewTextBoxColumn1";
		this.dataGridViewTextBoxColumn_1.ReadOnly = true;
		this.dataGridViewTextBoxColumn_1.Visible = false;
		this.dataGridViewTextBoxColumn_2.DataPropertyName = "idSchmObj";
		this.dataGridViewTextBoxColumn_2.HeaderText = "idSchmObj";
		this.dataGridViewTextBoxColumn_2.Name = "dataGridViewTextBoxColumn2";
		this.dataGridViewTextBoxColumn_2.ReadOnly = true;
		this.dataGridViewTextBoxColumn_2.Visible = false;
		this.dataGridViewTextBoxColumn_3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_3.HeaderText = "Оборудование";
		this.dataGridViewTextBoxColumn_3.Name = "dataGridViewTextBoxColumn3";
		this.dataGridViewTextBoxColumn_3.ReadOnly = true;
		this.dataGridViewTextBoxColumn_4.DataPropertyName = "idDamage";
		this.dataGridViewTextBoxColumn_4.HeaderText = "idDamage";
		this.dataGridViewTextBoxColumn_4.Name = "dataGridViewTextBoxColumn4";
		this.dataGridViewTextBoxColumn_4.ReadOnly = true;
		this.dataGridViewTextBoxColumn_4.Visible = false;
		this.dataGridViewTextBoxColumn_5.DataPropertyName = "col2";
		this.dataGridViewTextBoxColumn_5.HeaderText = "col2";
		this.dataGridViewTextBoxColumn_5.Name = "dataGridViewTextBoxColumn5";
		this.dataGridViewTextBoxColumn_5.ReadOnly = true;
		this.dataGridViewTextBoxColumn_5.Visible = false;
		this.dataGridViewTextBoxColumn_6.DataPropertyName = "col3";
		this.dataGridViewTextBoxColumn_6.HeaderText = "col3";
		this.dataGridViewTextBoxColumn_6.Name = "dataGridViewTextBoxColumn6";
		this.dataGridViewTextBoxColumn_6.ReadOnly = true;
		this.dataGridViewTextBoxColumn_6.Visible = false;
		this.dataGridViewTextBoxColumn_7.DataPropertyName = "idLineSection";
		this.dataGridViewTextBoxColumn_7.HeaderText = "idLineSection";
		this.dataGridViewTextBoxColumn_7.Name = "dataGridViewTextBoxColumn7";
		this.dataGridViewTextBoxColumn_7.ReadOnly = true;
		this.dataGridViewTextBoxColumn_7.Visible = false;
		this.nullableDateTimePicker_5.Anchor = AnchorStyles.Bottom;
		this.nullableDateTimePicker_5.CustomFormat = "dd.MM.yyyy HH:mm";
		this.nullableDateTimePicker_5.DataBindings.Add(new Binding("Value", this.class171_0, "tJ_Damage.DateApply", true, DataSourceUpdateMode.OnPropertyChanged));
		this.nullableDateTimePicker_5.Format = DateTimePickerFormat.Custom;
		this.nullableDateTimePicker_5.Location = new Point(520, 576);
		this.nullableDateTimePicker_5.Margin = new Padding(2);
		this.nullableDateTimePicker_5.Name = "dtpApply";
		this.nullableDateTimePicker_5.Size = new Size(151, 20);
		this.nullableDateTimePicker_5.TabIndex = 6;
		this.nullableDateTimePicker_5.Value = new DateTime(2016, 4, 14, 9, 21, 45, 414);
		this.comboBoxReadOnly_26.Anchor = AnchorStyles.Bottom;
		this.comboBoxReadOnly_26.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBoxReadOnly_26.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBoxReadOnly_26.DataBindings.Add(new Binding("SelectedValue", this.class171_0, "tJ_Damage.idWorkerApply", true));
		this.comboBoxReadOnly_26.FormattingEnabled = true;
		this.comboBoxReadOnly_26.Location = new Point(213, 576);
		this.comboBoxReadOnly_26.Margin = new Padding(2);
		this.comboBoxReadOnly_26.Name = "cmbWorkerApply";
		this.comboBoxReadOnly_26.ReadOnlyBackColor = SystemColors.Control;
		this.comboBoxReadOnly_26.ReadOnlyForeColor = SystemColors.WindowText;
		this.comboBoxReadOnly_26.Size = new Size(222, 21);
		this.comboBoxReadOnly_26.TabIndex = 4;
		this.comboBoxReadOnly_26.SelectedIndexChanged += this.comboBoxReadOnly_26_SelectedIndexChanged;
		this.button_5.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.button_5.BackgroundImage = Resources.refresh_16;
		this.button_5.BackgroundImageLayout = ImageLayout.Stretch;
		this.button_5.FlatStyle = FlatStyle.Popup;
		this.button_5.Location = new Point(745, 244);
		this.button_5.Name = "btnRefrshDateEndCrash";
		this.button_5.Size = new Size(20, 20);
		this.button_5.TabIndex = 19;
		this.button_5.UseVisualStyleBackColor = true;
		this.button_5.Click += this.button_5_Click;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(784, 608);
		base.Controls.Add(this.nullableDateTimePicker_5);
		base.Controls.Add(this.label_52);
		base.Controls.Add(this.comboBoxReadOnly_26);
		base.Controls.Add(this.checkBox_3);
		base.Controls.Add(this.button_1);
		base.Controls.Add(this.button_0);
		base.Controls.Add(this.tabControl_0);
		this.MinimumSize = new Size(800, 597);
		base.Name = "FormActDetectionAddEdit";
		base.PermissionsSql = false;
		this.Text = "Акт расследования";
		base.FormClosing += this.Form86_FormClosing;
		base.Load += this.Form86_Load;
		this.tabControl_0.ResumeLayout(false);
		this.tabPage_0.ResumeLayout(false);
		this.tabPage_0.PerformLayout();
		((ISupportInitialize)this.class171_0).EndInit();
		this.splitContainer_0.Panel1.ResumeLayout(false);
		this.splitContainer_0.Panel1.PerformLayout();
		this.splitContainer_0.ResumeLayout(false);
		this.groupBox_2.ResumeLayout(false);
		((ISupportInitialize)this.dataGridViewExcelFilter_0).EndInit();
		((ISupportInitialize)this.bindingSource_0).EndInit();
		((ISupportInitialize)this.dataSet_0).EndInit();
		((ISupportInitialize)this.dataTable_1).EndInit();
		((ISupportInitialize)this.dataTable_2).EndInit();
		((ISupportInitialize)this.dataTable_3).EndInit();
		((ISupportInitialize)this.dataTable_4).EndInit();
		this.groupBox_0.ResumeLayout(false);
		this.groupBox_0.PerformLayout();
		this.tabPage_4.ResumeLayout(false);
		this.groupBox_1.ResumeLayout(false);
		this.groupBox_1.PerformLayout();
		((ISupportInitialize)this.dataGridViewExcelFilter_1).EndInit();
		((ISupportInitialize)this.bindingSource_1).EndInit();
		this.tabPage_1.ResumeLayout(false);
		this.tabPage_1.PerformLayout();
		this.splitContainer_1.Panel1.ResumeLayout(false);
		this.splitContainer_1.Panel1.PerformLayout();
		this.splitContainer_1.Panel2.ResumeLayout(false);
		this.splitContainer_1.Panel2.PerformLayout();
		this.splitContainer_1.ResumeLayout(false);
		((ISupportInitialize)this.bindingSource_2).EndInit();
		((ISupportInitialize)this.dataGridView_0).EndInit();
		this.toolStrip_0.ResumeLayout(false);
		this.toolStrip_0.PerformLayout();
		this.tabPage_2.ResumeLayout(false);
		this.tabPage_2.PerformLayout();
		((ISupportInitialize)this.bindingSource_3).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	private int? nullable_0;

	private int? nullable_1;

	private List<int> list_0;

	private bool bool_0;

	private bool bool_1;

	private DataTable dataTable_0;

	private TabControl tabControl_0;

	private TabPage tabPage_0;

	private TabPage tabPage_1;

	private Button button_0;

	private Button button_1;

	private CheckBox checkBox_0;

	private ComboBoxReadOnly comboBoxReadOnly_0;

	private Label label_0;

	private ComboBoxReadOnly comboBoxReadOnly_1;

	private Label label_1;

	private DateTimePicker dateTimePicker_0;

	private Label label_2;

	private TextBox textBox_0;

	private Label label_3;

	private Label label_4;

	private TextBox textBox_1;

	private Class171 class171_0;

	private SplitContainer splitContainer_0;

	private Button button_2;

	private TextBox textBox_2;

	private Label label_5;

	private GroupBox groupBox_0;

	private CheckBox checkBox_1;

	private NullableDateTimePicker nullableDateTimePicker_0;

	private Label label_6;

	private GroupBox groupBox_1;

	private TextBox textBox_3;

	private Label label_7;

	private Label label_8;

	private Label label_9;

	private ComboBoxReadOnly comboBoxReadOnly_2;

	private Label label_10;

	private ComboBoxReadOnly comboBoxReadOnly_3;

	private ComboBoxReadOnly comboBoxReadOnly_4;

	private Label label_11;

	private ComboBoxReadOnly comboBoxReadOnly_5;

	private Label label_12;

	private ComboBoxReadOnly comboBoxReadOnly_6;

	private Label label_13;

	private NullableDateTimePicker nullableDateTimePicker_1;

	private NullableDateTimePicker nullableDateTimePicker_2;

	private Label label_14;

	private Label label_15;

	private Label label_16;

	private ComboBoxReadOnly comboBoxReadOnly_7;

	private GroupBox groupBox_2;

	private DataGridViewExcelFilter dataGridViewExcelFilter_0;

	private BindingSource bindingSource_0;

	private DataSet dataSet_0;

	private DataTable dataTable_1;

	private DataColumn dataColumn_0;

	private DataColumn dataColumn_1;

	private DataColumn dataColumn_2;

	private Label label_17;

	private ComboBoxReadOnly comboBoxReadOnly_8;

	private Label label_18;

	private DataTable dataTable_2;

	private DataColumn dataColumn_3;

	private DataColumn dataColumn_4;

	private DataColumn dataColumn_5;

	private DataColumn dataColumn_6;

	private DataGridViewExcelFilter dataGridViewExcelFilter_1;

	private BindingSource bindingSource_1;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_0;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_1;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_2;

	private ComboBoxReadOnly comboBoxReadOnly_9;

	private Label label_19;

	private ComboBoxReadOnly comboBoxReadOnly_10;

	private Label label_20;

	private ComboBoxReadOnly comboBoxReadOnly_11;

	private Label label_21;

	private Label label_22;

	private ToolStrip toolStrip_0;

	private ToolStripButton toolStripButton_0;

	private ToolStripButton toolStripButton_1;

	private Label JmtCydXvoo4;

	private ComboBoxReadOnly comboBoxReadOnly_12;

	private Label label_23;

	private ComboBoxReadOnly comboBoxReadOnly_13;

	private Label label_24;

	private Label label_25;

	private ComboBoxReadOnly comboBoxReadOnly_14;

	private ComboBoxReadOnly comboBoxReadOnly_15;

	private DataGridView dataGridView_0;

	private BindingSource bindingSource_2;

	private DataTable dataTable_3;

	private DataColumn dataColumn_7;

	private DataColumn dataColumn_8;

	private DataColumn dataColumn_9;

	private DataColumn dataColumn_10;

	private CheckBox checkBox_2;

	private DataColumn dataColumn_11;

	private DataColumn dataColumn_12;

	private Label label_26;

	private ComboBoxReadOnly comboBoxReadOnly_16;

	private DataColumn dataColumn_13;

	private Label label_27;

	private TextBox ouoCyeHwemd;

	private Label label_28;

	private TextBox textBox_4;

	private Label label_29;

	private TextBox textBox_5;

	private Label label_30;

	private TextBox textBox_6;

	private SplitContainer splitContainer_1;

	private Label label_31;

	private ComboBoxReadOnly comboBoxReadOnly_17;

	private Label label_32;

	private ComboBoxReadOnly comboBoxReadOnly_18;

	private Label label_33;

	private TextBox textBox_7;

	private Label label_34;

	private TextBox textBox_8;

	private Label label_35;

	private TextBox textBox_9;

	private Label label_36;

	private ComboBoxReadOnly comboBoxReadOnly_19;

	private NullableDateTimePicker nullableDateTimePicker_3;

	private Label label_37;

	private ComboBoxReadOnly comboBoxReadOnly_20;

	private Label label_38;

	private ComboBoxReadOnly comboBoxReadOnly_21;

	private Label label_39;

	private TextBox textBox_10;

	private Label label_40;

	private TextBox textBox_11;

	private Label label_41;

	private Label label_42;

	private TextBox textBox_12;

	private Label label_43;

	private NullableDateTimePicker nullableDateTimePicker_4;

	private TabPage tabPage_2;

	private TextBox textBox_13;

	private Label label_44;

	private TextBox textBox_14;

	private Label label_45;

	private ComboBoxReadOnly comboBoxReadOnly_22;

	private Label label_46;

	private RichTextBox richTextBox_0;

	private Label label_47;

	private TextBox textBox_15;

	private Label label_48;

	private ComboBoxReadOnly comboBoxReadOnly_23;

	private TextBox textBox_16;

	private Label label_49;

	private ComboBoxReadOnly comboBoxReadOnly_24;

	private TextBox textBox_17;

	private Label label_50;

	private ComboBoxReadOnly comboBoxReadOnly_25;

	private Label label_51;

	private CheckBox checkBox_3;

	private ComboBoxReadOnly comboBoxReadOnly_26;

	private Label label_52;

	private NullableDateTimePicker nullableDateTimePicker_5;

	private DataTable dataTable_4;

	private DataColumn dataColumn_14;

	private DataColumn dataColumn_15;

	private DataColumn dataColumn_16;

	private DataColumn dataColumn_17;

	private DataColumn dataColumn_18;

	private DataColumn dataColumn_19;

	private DataColumn dataColumn_20;

	private DataColumn dataColumn_21;

	private DataColumn dataColumn_22;

	private TabPage tabPage_3;

	private BindingSource bindingSource_3;

	private Label label_53;

	private TextBox textBox_18;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_3;

	private DataGridViewFilterDateTimePickerColumn dataGridViewFilterDateTimePickerColumn_0;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_4;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_5;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_3;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_4;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_5;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_6;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_7;

	private TextBox textBox_19;

	private Label label_54;

	private ComboBoxReadOnly comboBoxReadOnly_27;

	private TextBox textBox_20;

	private Label label_55;

	private ComboBoxReadOnly comboBoxReadOnly_28;

	private DataColumn dataColumn_23;

	private DataColumn dataColumn_24;

	private DataColumn dataColumn_25;

	private DataColumn dataColumn_26;

	private TextBox textBox_21;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_6;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_8;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_9;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_10;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_11;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_12;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_13;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_14;

	private TabPage tabPage_4;

	private RichTextBox richTextBox_1;

	private RichTextBox richTextBox_2;

	private Button button_3;

	private Button button_4;

	private Button button_5;
}
