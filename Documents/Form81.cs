using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml;
using ControlsLbr;
using ControlsLbr.DataGridViewExcelFilter;
using DataSql;
using Documents.Properties;
using FormLbr;
using FormLbr.Classes;
using RequestsClient.Forms.JournalRequestForRepair;
using SchemeModel;
using SchemeModel.Calculations;

internal partial class Form81 : FormBase
{
	internal int method_0()
	{
		return this.int_0;
	}

	internal bool method_1()
	{
		return this.bool_1;
	}

	internal void method_2(bool bool_3)
	{
		this.bool_1 = bool_3;
		this.method_3();
	}

	private void method_3()
	{
		if (this.method_1())
		{
			this.Text = "Просмотр документа аварийное отключение 6-10 кВ";
		}
		if (this.dateTimePicker_1.Value.Year < 2016)
		{
			this.textBox_1.ReadOnly = this.method_1();
		}
		this.dateTimePicker_1.Enabled = !this.method_1();
		this.comboBoxReadOnly_1.ReadOnly = this.method_1();
		this.comboBoxReadOnly_0.ReadOnly = this.method_1();
		this.button_2.Enabled = !this.method_1();
		this.richTextBox_0.ReadOnly = this.method_1();
		this.comboBoxReadOnly_4.ReadOnly = this.method_1();
		this.dataGridView_0.ReadOnly = this.method_1();
		this.dataGridView_0.AllowUserToDeleteRows = false;
		this.dataGridViewButtonColumn_0.Visible = !this.method_1();
		this.comboBoxReadOnly_5.ReadOnly = this.method_1();
		this.textBox_7.ReadOnly = this.method_1();
		this.textBox_6.ReadOnly = this.method_1();
		this.textBox_5.ReadOnly = this.method_1();
		this.textBox_4.ReadOnly = this.method_1();
		this.textBox_10.ReadOnly = this.method_1();
		this.textBox_8.ReadOnly = this.method_1();
		this.comboBox_0.Enabled = !this.method_1();
		this.comboBox_1.Enabled = !this.method_1();
		this.comboBoxReadOnly_3.ReadOnly = this.method_1();
		this.dataGridViewExcelFilter_0.ReadOnly = this.method_1();
		this.dataGridViewExcelFilter_0.AllowUserToDeleteRows = false;
		this.radioButton_1.Enabled = (this.radioButton_0.Enabled = !this.method_1());
		this.richTextBox_1.ReadOnly = this.method_1();
		this.checkBox_0.Enabled = !this.method_1();
		this.comboBoxReadOnly_2.ReadOnly = this.method_1();
		this.nullableDateTimePicker_0.Enabled = !this.method_1();
		this.comboBoxReadOnly_6.ReadOnly = this.method_1();
		this.checkBox_2.Enabled = !this.method_1();
		this.checkBox_1.Enabled = !this.method_1();
		this.richTextBox_2.ReadOnly = (this.richTextBox_3.ReadOnly = (!this.checkBox_1.Checked && this.method_1()));
		this.toolStripButton_1.Enabled = (this.toolStripButton_0.Enabled = !this.method_1());
		this.button_1.Visible = !this.method_1();
		this.button_3.Visible = !this.method_1();
		this.toolStripButton_2.Enabled = !this.method_1();
		this.toolStripDropDownButton_0.Enabled = !this.method_1();
		this.numericUpDown_3.ReadOnly = (this.numericUpDown_4.ReadOnly = (this.numericUpDown_6.ReadOnly = (this.numericUpDown_5.ReadOnly = (this.numericUpDown_2.ReadOnly = (this.numericUpDown_1.ReadOnly = (this.numericUpDown_0.ReadOnly = this.method_1()))))));
		this.numericUpDown_13.ReadOnly = (this.numericUpDown_14.ReadOnly = (this.numericUpDown_15.ReadOnly = (this.numericUpDown_16.ReadOnly = (this.numericUpDown_9.ReadOnly = (this.numericUpDown_8.ReadOnly = (this.numericUpDown_7.ReadOnly = this.method_1()))))));
		this.numericUpDown_12.ReadOnly = (this.numericUpDown_11.ReadOnly = (this.numericUpDown_10.ReadOnly = this.method_1()));
	}

	internal Form81(int int_1 = -1)
	{
		
		this.int_0 = -1;
		this.dateTime_0 = DateTimePicker.MaximumDateTime;
		this.string_0 = "";
		this.list_0 = new List<int>();
		
		this.method_71();
		this.int_0 = int_1;
		this.Text = ((int_1 == -1) ? "Добавить аварийное отключение 6-10 кВ" : (this.method_1() ? "Просмотр документа аварийное отключение 6-10 кВ" : "Редактировать аварийное отключение 6-10 кВ"));
		this.nullableDateTimePicker_0.Value = DateTime.Now;
	}

	private void Form81_Load(object sender, EventArgs e)
	{
		this.method_5();
		this.method_9();
		this.method_10();
		this.method_12();
		this.method_13();
		this.method_14();
		this.method_15();
		this.method_16();
		this.method_17();
		this.method_18(this.comboBox_0);
		this.method_18(this.comboBox_1);
		this.method_34();
		base.SelectSqlData(this.class171_0.vWorkerGroup, true, " where ParentKey in (';GroupWorker;ITR;', ';GroupWorker;Workers;', ';GroupWorker;Dispatchers;')  and dateend is null order by fio ", null, false, 0);
		base.LoadFormConfig(null);
		if (this.int_0 == -1)
		{
			DataRow dataRow = this.class171_0.tJ_Damage.NewRow();
			dataRow["TYpeDoc"] = 1402;
			dataRow["dateDoc"] = DateTime.Now;
			dataRow["dateOwner"] = DateTime.Now;
			this.class171_0.tJ_Damage.Rows.Add(dataRow);
			this.method_6();
		}
		else
		{
			this.dateTimePicker_1.ValueChanged -= this.dateTimePicker_1_ValueChanged;
			base.SelectSqlData(this.class171_0.tJ_Damage, true, "where id = " + this.int_0.ToString(), null, false, 0);
			this.dateTimePicker_1.ValueChanged += this.dateTimePicker_1_ValueChanged;
			if (this.class171_0.tJ_Damage.Rows.Count > 0)
			{
				if (this.class171_0.tJ_Damage.Rows[0]["numDoc"] != DBNull.Value)
				{
					this.Text = this.Text + " №" + this.class171_0.tJ_Damage.Rows[0]["numDoc"].ToString();
				}
				if (this.class171_0.tJ_Damage.Rows[0]["idSchmObj"] != DBNull.Value)
				{
					this.textBox_2.Text = base.CallSQLScalarFunction("dbo.fn_Schm_GetFullNameObjById", new string[]
					{
						this.class171_0.tJ_Damage.Rows[0]["idSchmObj"].ToString()
					}).ToString();
				}
				if (this.class171_0.tJ_Damage.Rows[0]["idDivisionApply"] != DBNull.Value || (this.class171_0.tJ_Damage.Rows[0]["isLaboratory"] != DBNull.Value && Convert.ToBoolean(this.class171_0.tJ_Damage.Rows[0]["isLaboratory"])))
				{
					this.checkBox_1.Checked = true;
				}
				if (this.class171_0.tJ_Damage.Rows[0]["is81"] != DBNull.Value && !Convert.ToBoolean(this.class171_0.tJ_Damage.Rows[0]["is81"]))
				{
					this.toolStripButton_2.Checked = true;
				}
				else
				{
					this.toolStripButton_2.Checked = false;
				}
			}
			this.method_33();
			this.method_4();
			base.SelectSqlData(this.class171_0.tJ_DamageHV, true, "where idDamage = " + this.int_0.ToString(), null, false, 0);
			if (this.class171_0.tJ_DamageHV.Rows.Count == 0)
			{
				this.method_6();
			}
			this.method_48();
			Class228.smethod_5(this.class171_0.tJ_Damage, this.dataTable_1, this.SqlSettings);
			this.method_67();
			this.method_70();
			this.toolStripStatusLabel_4.Text = "Количество абонентов: " + this.dataTable_1.DefaultView.ToTable(true, new string[]
			{
				"idAbn"
			}).Rows.Count.ToString();
			base.SelectSqlData(this.class171_0.tJ_DamageOn, true, "where idDamage = " + this.int_0.ToString(), null, false, 0);
			if (this.class171_0.tJ_DamageHV.Rows.Count > 0)
			{
				if (this.class171_0.tJ_DamageHV.Rows[0]["isAverage"] != DBNull.Value && !Convert.ToBoolean(this.class171_0.tJ_DamageHV.Rows[0]["isAverage"]))
				{
					this.radioButton_0.Checked = true;
				}
				else
				{
					this.radioButton_1.Checked = true;
				}
			}
		}
		this.method_52();
		this.method_11();
		this.method_35();
		if (this.dateTimePicker_1.Value.Year >= 2016)
		{
			this.textBox_1.ReadOnly = true;
		}
		this.bool_0 = false;
	}

	private void Form81_Shown(object sender, EventArgs e)
	{
		this.bool_0 = false;
		this.method_37();
	}

	private void Form81_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (!this.button_0.Enabled)
		{
			e.Cancel = true;
			return;
		}
		if (base.DialogResult != DialogResult.OK)
		{
			if (!this.bool_0 || this.method_1() || MessageBox.Show("Сохранить внесенные изменения", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
			{
				base.DialogResult = DialogResult.Cancel;
				return;
			}
		}
		if (!this.method_22() || !this.method_23())
		{
			base.DialogResult = DialogResult.None;
			e.Cancel = true;
			return;
		}
		if (this.method_24())
		{
			base.SaveFormConfig(null);
			base.DialogResult = DialogResult.OK;
			return;
		}
		base.DialogResult = DialogResult.None;
		e.Cancel = true;
	}

	private void method_4()
	{
		if (this.int_0 > 0)
		{
			Class171.Class172 @class = new Class171.Class172();
			base.SelectSqlData(@class, true, string.Format("where idParent = {0} and TypeDoc = {1} and idDivisionApply is not null and isApply = 1 ", this.int_0, 1844), null, false, 0);
			if (@class.Rows.Count > 0)
			{
				this.checkBox_1.Enabled = false;
				this.comboBoxReadOnly_6.ReadOnly = true;
				this.richTextBox_3.ReadOnly = true;
			}
			base.SelectSqlData(@class, true, string.Format("where idParent = {0} and TypeDoc = {1} and isLaboratory is not null and isApply = 1 ", this.int_0, 1844), null, false, 0);
			if (@class.Rows.Count > 0)
			{
				this.checkBox_1.Enabled = false;
				this.checkBox_2.Enabled = false;
				this.richTextBox_2.ReadOnly = true;
			}
		}
	}

	private void method_5()
	{
		if (this.int_0 > 0)
		{
			this.class172_0 = new Class171.Class172();
			base.SelectSqlData(this.class172_0, true, "where id = " + this.int_0.ToString(), null, false, 0);
			this.class184_0 = new Class171.Class184();
			base.SelectSqlData(this.class184_0, true, "where idDamage = " + this.int_0.ToString(), null, false, 0);
		}
	}

	private void method_6()
	{
		DataRow dataRow = this.class171_0.tJ_DamageHV.NewRow();
		dataRow["idDamage"] = this.int_0;
		dataRow["CoefFI"] = 0.9;
		dataRow["CoefSeason"] = 0.8;
		this.class171_0.tJ_DamageHV.Rows.Add(dataRow);
	}

	private DataTable method_7()
	{
		return new DataTable("tR_Classifier")
		{
			Columns = 
			{
				{
					"id",
					typeof(int)
				},
				{
					"name",
					typeof(string)
				}
			}
		};
	}

	private DataTable method_8()
	{
		return new DataTable
		{
			Columns = 
			{
				{
					"name",
					typeof(string)
				},
				{
					"flag",
					typeof(bool)
				}
			},
			Rows = 
			{
				new object[]
				{
					"",
					DBNull.Value
				},
				new object[]
				{
					"0",
					false
				},
				new object[]
				{
					"1",
					true
				}
			}
		};
	}

	private void method_9()
	{
		DataTable dataTable = this.method_7();
		if (this.class172_0 != null && this.class172_0.Rows.Count > 0 && this.class172_0.Rows[0]["idDivision"] != DBNull.Value)
		{
			base.SelectSqlData(dataTable, true, string.Format(" where (ParentKey = ';GroupWorker;DailyREport;' and isgroup = 0 and deleted = 0) \r\n                                            or (id = {0})", this.class172_0.Rows[0]["idDivision"]), null, false, 0);
		}
		else
		{
			base.SelectSqlData(dataTable, true, " where ParentKey = ';GroupWorker;DailyREport;' and isgroup = 0 and deleted = 0", null, false, 0);
		}
		this.comboBoxReadOnly_0.DisplayMember = "name";
		this.comboBoxReadOnly_0.ValueMember = "id";
		this.comboBoxReadOnly_0.DataSource = dataTable;
		this.comboBoxReadOnly_0.SelectedIndex = -1;
	}

	private void method_10()
	{
		DataTable dataTable = new DataTable("vWorkerGroup");
		dataTable.Columns.Add("id", typeof(int));
		dataTable.Columns.Add("FIO", typeof(string));
		dataTable.Columns.Add("idGroup", typeof(int));
		base.SelectSqlData(dataTable, true, "where ParentKey like ';GroupWorker;DailyReport;' and dateEnd is null order by fio ", null, false, 0);
		this.comboBoxReadOnly_1.DisplayMember = "FIO";
		this.comboBoxReadOnly_1.ValueMember = "id";
		this.comboBoxReadOnly_1.DataSource = dataTable;
		this.comboBoxReadOnly_1.SelectedIndex = -1;
	}

	private void method_11()
	{
		if (this.int_0 == -1)
		{
			DataTable dataTable = new DataTable("tUser");
			dataTable.Columns.Add("name", typeof(string));
			dataTable.Columns.Add("idWorker", typeof(string));
			base.SelectSqlData(dataTable, true, "where [login] = SYSTEM_USER", null, false, 0);
			if (dataTable.Rows.Count > 0)
			{
				if (dataTable.Rows[0]["name"] != DBNull.Value)
				{
					this.textBox_0.Text = dataTable.Rows[0]["name"].ToString();
				}
				if (dataTable.Rows[0]["idWorker"] != DBNull.Value)
				{
					DataRow[] array = ((DataTable)this.comboBoxReadOnly_1.DataSource).Select("id = " + dataTable.Rows[0]["idWorker"]);
					if (array.Count<DataRow>() > 0 && this.int_0 == -1 && this.class171_0.tJ_Damage.Rows.Count > 0)
					{
						this.class171_0.tJ_Damage.Rows[0]["idCompiler"] = array[0]["id"];
						return;
					}
				}
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

	private void method_12()
	{
		DataTable dataTable = this.method_7();
		if (this.class172_0 != null && this.class172_0.Rows.Count > 0 && this.class172_0.Rows[0]["idReason"] != DBNull.Value)
		{
			base.SelectSqlData(dataTable, true, string.Format(" where (ParentKey = ';ReportDaily;DamageReason;HV;' and isgroup = 0 and deleted = 0) \r\n                                            or (id = {0}) order by name", this.class172_0.Rows[0]["idReason"]), null, false, 0);
		}
		else
		{
			base.SelectSqlData(dataTable, true, " where ParentKey = ';ReportDaily;DamageReason;HV;' and isgroup = 0 and deleted = 0 order by name", null, false, 0);
		}
		this.comboBoxReadOnly_4.DisplayMember = "name";
		this.comboBoxReadOnly_4.ValueMember = "id";
		this.comboBoxReadOnly_4.DataSource = dataTable;
		this.comboBoxReadOnly_4.SelectedIndex = -1;
	}

	private void method_13()
	{
		DataTable dataTable = this.method_7();
		if (this.class172_0 != null && this.class172_0.Rows.Count > 0 && this.class172_0.Rows[0]["idCompletedWork"] != DBNull.Value)
		{
			base.SelectSqlData(dataTable, true, string.Format(" where (ParentKey = ';ReportDaily;CompletedWork;HV;' and isgroup = 0 and deleted = 0) \r\n                                            or (id = {0}) order by name", this.class172_0.Rows[0]["idCompletedWork"]), null, false, 0);
		}
		else
		{
			base.SelectSqlData(dataTable, true, " where ParentKey = ';ReportDaily;CompletedWork;HV;' and isgroup = 0 and deleted = 0 order by name", null, false, 0);
		}
		this.comboBoxReadOnly_3.DisplayMember = "name";
		this.comboBoxReadOnly_3.ValueMember = "id";
		this.comboBoxReadOnly_3.DataSource = dataTable;
		this.comboBoxReadOnly_3.SelectedIndex = -1;
	}

	private void method_14()
	{
		DataTable dataTable = new DataTable("vWorkerGroup");
		dataTable.Columns.Add("id", typeof(int));
		dataTable.Columns.Add("FIO", typeof(string));
		dataTable.Columns.Add("idGroup", typeof(int));
		base.SelectSqlData(dataTable, true, "where ParentKey like ';GroupWorker;DailyReport;' and dateEnd is null order by fio ", null, false, 0);
		this.comboBoxReadOnly_2.DisplayMember = "FIO";
		this.comboBoxReadOnly_2.ValueMember = "id";
		this.comboBoxReadOnly_2.DataSource = dataTable;
		this.comboBoxReadOnly_2.SelectedIndex = -1;
	}

	private void method_15()
	{
		DataTable dataTable = this.method_7();
		base.SelectSqlData(dataTable, true, " where ParentKey = ';ReportDaily;DivisionApply;' and isgroup = 0 and deleted = 0 order by name", null, false, 0);
		this.comboBoxReadOnly_6.DisplayMember = "name";
		this.comboBoxReadOnly_6.ValueMember = "id";
		this.comboBoxReadOnly_6.DataSource = dataTable;
		this.comboBoxReadOnly_6.SelectedIndex = -1;
	}

	private void method_16()
	{
		DataTable dataTable = this.method_7();
		base.SelectSqlData(dataTable, true, " where ParentKey = ';ReportDaily;TypeRZA;' and isgroup = 0 and deleted = 0 order by name", null, false, 0);
		this.comboBoxReadOnly_5.DisplayMember = "name";
		this.comboBoxReadOnly_5.ValueMember = "id";
		this.comboBoxReadOnly_5.DataSource = dataTable;
		this.comboBoxReadOnly_5.SelectedIndex = -1;
	}

	private void method_17()
	{
		DataTable dataTable = this.method_7();
		base.SelectSqlData(dataTable, true, " where  parentKey = ';SKUEE;TypeAbn;' and isGRoup = 0 and deleted  = 0", null, false, 0);
		this.dataGridViewFilterComboBoxColumn_0.DisplayMember = "name";
		this.dataGridViewFilterComboBoxColumn_0.ValueMember = "id";
		BindingSource bindingSource = new BindingSource();
		bindingSource.DataSource = dataTable;
		this.dataGridViewFilterComboBoxColumn_0.DataSource = bindingSource;
	}

	private void method_18(ComboBox comboBox_2)
	{
		DataTable dataSource = this.method_8();
		comboBox_2.DisplayMember = "name";
		comboBox_2.ValueMember = "flag";
		comboBox_2.DataSource = dataSource;
		comboBox_2.SelectedIndex = -1;
	}

	private void richTextBox_1_TextChanged(object sender, EventArgs e)
	{
		this.bool_0 = true;
	}

	private void method_19(object sender, EventArgs e)
	{
		this.bool_0 = true;
	}

	private void comboBoxReadOnly_1_SelectedValueChanged(object sender, EventArgs e)
	{
		this.bool_0 = true;
		if (this.class171_0.tJ_Damage.Rows.Count > 0)
		{
			if (this.comboBoxReadOnly_1.SelectedValue == null)
			{
				this.comboBoxReadOnly_0.SelectedValue = null;
				return;
			}
			this.label_1.ForeColor = Color.Black;
			DataRow[] array = ((DataTable)this.comboBoxReadOnly_1.DataSource).Select("id = " + this.comboBoxReadOnly_1.SelectedValue.ToString());
			if (array.Count<DataRow>() > 0)
			{
				this.comboBoxReadOnly_0.SelectedValue = array[0]["idGRoup"];
			}
		}
	}

	private void method_20(object sender, EventArgs e)
	{
		this.bool_0 = true;
	}

	private void comboBoxReadOnly_5_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.bool_0 = true;
		if (this.comboBoxReadOnly_5.SelectedIndex >= 0)
		{
			this.label_10.ForeColor = Color.Black;
		}
	}

	private void dateTimePicker_1_ValueChanged(object sender, EventArgs e)
	{
		if (this.dateTimePicker_1.Value.Year >= 2016)
		{
			this.label_5.ForeColor = Color.Black;
			this.textBox_1.ReadOnly = true;
		}
		else
		{
			if (string.IsNullOrEmpty(this.textBox_1.Text))
			{
				this.label_5.ForeColor = Color.Red;
			}
			this.textBox_1.ReadOnly = false;
		}
		this.bool_2 = true;
		this.bool_0 = true;
	}

	private void dateTimePicker_1_Validated(object sender, EventArgs e)
	{
		if (this.bool_2)
		{
			this.method_46();
		}
		this.bool_2 = false;
	}

	private void textBox_1_TextChanged(object sender, EventArgs e)
	{
		if (!string.IsNullOrEmpty(this.textBox_1.Text))
		{
			this.label_5.ForeColor = Color.Black;
		}
		this.bool_0 = true;
	}

	private void textBox_2_TextChanged(object sender, EventArgs e)
	{
		if (!string.IsNullOrEmpty(this.textBox_2.Text))
		{
			this.label_6.ForeColor = Color.Black;
		}
		this.bool_0 = true;
	}

	private void comboBoxReadOnly_4_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.comboBoxReadOnly_4.SelectedIndex >= 0)
		{
			this.label_9.ForeColor = Color.Black;
		}
		this.bool_0 = true;
	}

	private void button_2_Click(object sender, EventArgs e)
	{
		Class228.smethod_0(this.SqlSettings, this.class171_0.tJ_Damage.Rows[0], this.textBox_2, ref this.bool_0, null);
		this.method_21();
		this.method_46();
	}

	private void method_21()
	{
		if (this.class171_0.tJ_Damage.Rows.Count > 0 && this.class171_0.tJ_Damage.Rows[0]["idSchmObj"] != DBNull.Value)
		{
			DataTable dataTable = base.SelectSqlData("tR_Classifier", true, string.Format(" inner join tSchm_ObjList o on o.typeCodeId = tR_Classifier.id\r\n                            where o.id = {0} and (tR_Classifier.ParentKey like ';SCM;BUS;%' or tR_Classifier.ParentKey like ';SCM;BUS;%')", this.class171_0.tJ_Damage.Rows[0]["idSchmObj"]));
			if (dataTable.Rows.Count > 0 && dataTable.Rows[0]["Value"] != DBNull.Value)
			{
				this.textBox_4.Text = Convert.ToDecimal(dataTable.Rows[0]["Value"]).ToString("0.####");
				return;
			}
			this.textBox_4.Text = "";
			this.label_14.ForeColor = Color.Red;
		}
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		base.Close();
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		base.Close();
	}

	private bool method_22()
	{
		bool flag = true;
		if (this.dateTimePicker_1.Value.Year < 2016 && string.IsNullOrEmpty(this.textBox_1.Text))
		{
			this.label_5.ForeColor = Color.Red;
			flag = false;
		}
		if (this.comboBoxReadOnly_1.SelectedIndex < 0)
		{
			this.label_1.ForeColor = Color.Red;
			flag = false;
		}
		if (string.IsNullOrEmpty(this.textBox_2.Text))
		{
			this.label_6.ForeColor = Color.Red;
			flag = false;
		}
		if (this.comboBoxReadOnly_4.SelectedIndex < 0)
		{
			this.label_9.ForeColor = Color.Red;
			flag = false;
		}
		if (this.dataGridView_0.Rows.Count <= 1)
		{
			this.label_22.ForeColor = Color.Red;
			flag = false;
		}
		if (this.comboBoxReadOnly_5.SelectedIndex < 0)
		{
			this.label_10.ForeColor = Color.Red;
			flag = false;
		}
		if (this.checkBox_0.Checked)
		{
			if (this.comboBoxReadOnly_3.SelectedIndex < 0)
			{
				this.label_8.ForeColor = Color.Red;
				flag = false;
			}
			if (this.comboBoxReadOnly_2.SelectedIndex < 0)
			{
				this.checkBox_0.ForeColor = Color.Red;
				flag = false;
			}
			if (this.nullableDateTimePicker_0.Value == null || this.nullableDateTimePicker_0.Value == DBNull.Value)
			{
				this.label_7.ForeColor = Color.Red;
				flag = false;
			}
			if (this.class171_0.tJ_DamageOn.Rows.Count == 0 || this.dataGridViewExcelFilter_0.Rows.Count <= 1)
			{
				this.label_11.ForeColor = Color.Red;
				flag = false;
			}
		}
		if (!flag)
		{
			MessageBox.Show("Не заполнены обязательный поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		return flag;
	}

	private bool method_23()
	{
		if (this.class171_0.tJ_Damage.Rows.Count > 0)
		{
			DataTable dataTable = new DataTable("tJ_Damage");
			dataTable.Columns.Add("id", typeof(int));
			dataTable.Columns.Add("numREquest", typeof(string));
			dataTable.Columns.Add("dateDoc", typeof(DateTime));
			base.SelectSqlData(dataTable, true, string.Format("where numRequest = '{0}' and year(dateDoc) = {1} and typeDoc = {2} and id <> {3} and idDivision = {4}", new object[]
			{
				this.class171_0.tJ_Damage.Rows[0]["numRequest"].ToString(),
				Convert.ToDateTime(this.class171_0.tJ_Damage.Rows[0]["dateDoc"]).Year,
				1402,
				this.class171_0.tJ_Damage.Rows[0]["id"].ToString(),
				Convert.ToInt32(this.class171_0.tJ_Damage.Rows[0]["idDivision"])
			}), null, false, 0);
			return dataTable.Rows.Count <= 0 || MessageBox.Show(string.Format("Заявка с номером {0} в текущем году уже была. Хотите все равно сохранить?", this.class171_0.tJ_Damage.Rows[0]["numRequest"].ToString()), "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
		}
		return true;
	}

	private bool method_24()
	{
		if (!this.checkBox_1.Checked)
		{
			this.comboBoxReadOnly_6.SelectedIndex = -1;
			this.checkBox_2.Checked = false;
		}
		this.class171_0.tJ_Damage.Rows[0]["is81"] = !this.toolStripButton_2.Checked;
		this.method_27();
		this.method_47();
		this.class171_0.tJ_Damage.Rows[0].EndEdit();
		if (this.int_0 == -1)
		{
			this.int_0 = base.InsertSqlDataOneRow(this.class171_0, this.class171_0.tJ_Damage);
			if (this.int_0 == -1)
			{
				return false;
			}
		}
		else if (!base.UpdateSqlData(this.class171_0.tJ_Damage))
		{
			return false;
		}
		base.SelectSqlData(this.class171_0.tJ_Damage, true, "where id = " + this.int_0.ToString(), null, false, 0);
		return this.method_26() && this.method_25() && this.method_28() && this.method_29();
	}

	private bool method_25()
	{
		base.SelectSqlData(this.class171_0.tJ_DamageCharacter, true, "where idDamage = " + this.int_0.ToString(), null, false, 0);
		for (int i = this.dataGridView_0.Rows.Count - 1; i < this.class171_0.tJ_DamageCharacter.Rows.Count; i++)
		{
			this.class171_0.tJ_DamageCharacter.Rows[i].Delete();
		}
		for (int j = 0; j < this.dataGridView_0.Rows.Count - 1; j++)
		{
			if (j < this.class171_0.tJ_DamageCharacter.Rows.Count)
			{
				this.class171_0.tJ_DamageCharacter.Rows[j]["idDamage"] = this.int_0;
				if (this.dataGridView_0.Rows[j].Cells[this.dataGridViewComboBoxColumn_0.Name].Value != null)
				{
					this.class171_0.tJ_DamageCharacter.Rows[j]["col1"] = this.dataGridView_0.Rows[j].Cells[this.dataGridViewComboBoxColumn_0.Name].Value;
				}
				else
				{
					this.class171_0.tJ_DamageCharacter.Rows[j]["col1"] = DBNull.Value;
				}
				if (this.dataGridView_0.Rows[j].Cells[this.dataGridViewComboBoxColumn_2.Name].Value != null)
				{
					this.class171_0.tJ_DamageCharacter.Rows[j]["col2"] = this.dataGridView_0.Rows[j].Cells[this.dataGridViewComboBoxColumn_2.Name].Value;
				}
				else
				{
					this.class171_0.tJ_DamageCharacter.Rows[j]["col2"] = DBNull.Value;
				}
				if (this.dataGridView_0.Rows[j].Cells[this.dataGridViewComboBoxColumn_3.Name].Value != null)
				{
					this.class171_0.tJ_DamageCharacter.Rows[j]["col3"] = this.dataGridView_0.Rows[j].Cells[this.dataGridViewComboBoxColumn_3.Name].Value;
				}
				else
				{
					this.class171_0.tJ_DamageCharacter.Rows[j]["col3"] = DBNull.Value;
				}
				if (this.dataGridView_0.Rows[j].Cells[this.dataGridViewTextBoxColumn_4.Name].Value != null)
				{
					this.class171_0.tJ_DamageCharacter.Rows[j]["idSchmObj"] = this.dataGridView_0.Rows[j].Cells[this.dataGridViewTextBoxColumn_4.Name].Value;
				}
				else
				{
					this.class171_0.tJ_DamageCharacter.Rows[j]["idSchmObj"] = DBNull.Value;
				}
				if (this.dataGridView_0.Rows[j].Cells[this.dataGridViewComboBoxColumn_1.Name].Value != null)
				{
					this.class171_0.tJ_DamageCharacter.Rows[j]["idLineSection"] = this.dataGridView_0.Rows[j].Cells[this.dataGridViewComboBoxColumn_1.Name].Value;
				}
				else
				{
					this.class171_0.tJ_DamageCharacter.Rows[j]["idLineSection"] = DBNull.Value;
				}
				this.class171_0.tJ_DamageCharacter.Rows[j].EndEdit();
			}
			else
			{
				DataRow dataRow = this.class171_0.tJ_DamageCharacter.NewRow();
				dataRow["idDamage"] = this.int_0;
				if (this.dataGridView_0.Rows[j].Cells[this.dataGridViewComboBoxColumn_0.Name].Value != null)
				{
					dataRow["col1"] = this.dataGridView_0.Rows[j].Cells[this.dataGridViewComboBoxColumn_0.Name].Value;
				}
				if (this.dataGridView_0.Rows[j].Cells[this.dataGridViewComboBoxColumn_2.Name].Value != null)
				{
					dataRow["col2"] = this.dataGridView_0.Rows[j].Cells[this.dataGridViewComboBoxColumn_2.Name].Value;
				}
				if (this.dataGridView_0.Rows[j].Cells[this.dataGridViewComboBoxColumn_3.Name].Value != null)
				{
					dataRow["col3"] = this.dataGridView_0.Rows[j].Cells[this.dataGridViewComboBoxColumn_3.Name].Value;
				}
				if (this.dataGridView_0.Rows[j].Cells[this.dataGridViewTextBoxColumn_4.Name].Value != null)
				{
					dataRow["idSchmObj"] = this.dataGridView_0.Rows[j].Cells[this.dataGridViewTextBoxColumn_4.Name].Value;
				}
				if (this.dataGridView_0.Rows[j].Cells[this.dataGridViewComboBoxColumn_1.Name].Value != null)
				{
					dataRow["idLineSection"] = this.dataGridView_0.Rows[j].Cells[this.dataGridViewComboBoxColumn_1.Name].Value;
				}
				this.class171_0.tJ_DamageCharacter.Rows.Add(dataRow);
			}
		}
		if (!base.DeleteSqlData(this.class171_0.tJ_DamageCharacter))
		{
			return false;
		}
		if (!base.UpdateSqlData(this.class171_0.tJ_DamageCharacter))
		{
			return false;
		}
		if (!base.InsertSqlData(this.class171_0.tJ_DamageCharacter))
		{
			return false;
		}
		base.SelectSqlData(this.class171_0.tJ_DamageCharacter, true, "where idDamage = " + this.int_0.ToString(), null, false, 0);
		return true;
	}

	private bool method_26()
	{
		if (this.class171_0.tJ_DamageHV.Rows.Count > 0)
		{
			this.class171_0.tJ_DamageHV.Rows[0]["idDamage"] = this.int_0;
			this.class171_0.tJ_DamageHV.Rows[0]["isAverage"] = this.radioButton_1.Checked;
			this.class171_0.tJ_DamageHV.Rows[0].EndEdit();
			if (!base.InsertSqlData(this.class171_0.tJ_DamageHV))
			{
				return false;
			}
			if (!base.UpdateSqlData(this.class171_0.tJ_DamageHV))
			{
				return false;
			}
			base.SelectSqlData(this.class171_0.tJ_DamageHV, true, "where idDamage = " + this.int_0.ToString(), null, false, 0);
		}
		return true;
	}

	private void method_27()
	{
		XmlDocument xmlDocument = new XmlDocument();
		if (this.class171_0.tJ_Damage.Rows[0]["CommentXml"] != DBNull.Value)
		{
			try
			{
				xmlDocument.LoadXml(this.class171_0.tJ_Damage.Rows[0]["CommentXml"].ToString());
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
		foreach (object obj in this.dataTable_1.Rows)
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
		this.method_66(xmlNode2);
		this.method_69(xmlNode2);
		this.class171_0.tJ_Damage.Rows[0]["CommentXml"] = xmlDocument.InnerXml;
	}

	private bool method_28()
	{
		if (this.radioButton_1.Checked)
		{
			using (IEnumerator enumerator = this.class171_0.tJ_DamageOn.Rows.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					DataRow dataRow = (DataRow)obj;
					if (dataRow.RowState != DataRowState.Deleted)
					{
						dataRow["idDamage"] = this.int_0;
						dataRow.EndEdit();
					}
				}
				goto IL_2B0;
			}
		}
		DataTable dataTable = new DataTable();
		if (this.class176_0.Rows.Count > 0)
		{
			dataTable = (from row in this.class176_0.AsEnumerable<Class171.Class201>()
			orderby row.Field("DateOn")
			select row).CopyToDataTable<Class171.Class201>();
		}
		else
		{
			dataTable = this.class176_0;
		}
		int num = 0;
		foreach (DataRow dataRow2 in this.class171_0.tJ_DamageOn)
		{
			if (dataRow2.RowState != DataRowState.Deleted)
			{
				if (num < this.class176_0.Rows.Count)
				{
					dataRow2["idDamage"] = this.int_0;
					dataRow2["dateOn"] = dataTable.Rows[num]["dateOn"];
					dataRow2["countSchmObj"] = dataTable.Rows[num]["countSchmObj"];
					dataRow2["noAdmissionKWT"] = dataTable.Rows[num]["noAdmissionKWT"];
					dataRow2.EndEdit();
				}
				else
				{
					this.class176_0.Rows[num].Delete();
				}
				num++;
			}
		}
		if (num < this.class176_0.Rows.Count)
		{
			for (int i = num; i < dataTable.Rows.Count; i++)
			{
				DataRow dataRow3 = this.class171_0.tJ_DamageOn.NewRow();
				dataRow3["idDamage"] = this.int_0;
				dataRow3["dateOn"] = dataTable.Rows[i]["dateOn"];
				dataRow3["countSchmObj"] = dataTable.Rows[i]["countSchmObj"];
				dataRow3["noAdmissionKWT"] = dataTable.Rows[i]["noAdmissionKWT"];
				this.class171_0.tJ_DamageOn.Rows.Add(dataRow3);
			}
		}
		IL_2B0:
		if (base.InsertSqlData(this.class171_0.tJ_DamageOn) && base.UpdateSqlData(this.class171_0.tJ_DamageOn) && base.DeleteSqlData(this.class171_0.tJ_DamageOn))
		{
			base.SelectSqlData(this.class171_0.tJ_DamageOn, true, " where idDamage = " + this.int_0.ToString(), null, false, 0);
			return true;
		}
		return false;
	}

	private bool method_29()
	{
		Class171.Class172 @class = new Class171.Class172();
		base.SelectSqlData(@class, true, string.Format("where idParent = {0} and TypeDoc = {1} and idDivisionApply is not null", this.int_0, 1844), null, false, 0);
		if (this.checkBox_1.Checked && this.comboBoxReadOnly_6.SelectedIndex >= 0)
		{
			for (int i = 1; i < @class.Rows.Count; i++)
			{
				@class.Rows[i].Delete();
			}
			if (@class.Rows.Count > 0)
			{
				Class228.smethod_1(@class.Rows[0], this.class171_0, this.int_0, 1844, true, false);
				@class.Rows[0].EndEdit();
				if (!base.UpdateSqlData(@class))
				{
					return false;
				}
				if (!this.method_30(Convert.ToInt32(@class.Rows[0]["id"])))
				{
					return false;
				}
			}
			else
			{
				DataRow dataRow = @class.NewRow();
				Class228.smethod_1(dataRow, this.class171_0, this.int_0, 1844, true, false);
				@class.Rows.Add(dataRow);
				int num = base.InsertSqlDataOneRow(dataRow);
				if (num <= 0)
				{
					return false;
				}
				if (!this.method_30(num))
				{
					return false;
				}
			}
		}
		else
		{
			foreach (object obj in @class.Rows)
			{
				((DataRow)obj).Delete();
			}
			if (!base.DeleteSqlData(@class))
			{
				return false;
			}
		}
		base.SelectSqlData(@class, true, string.Format("where idParent = {0} and TypeDoc = {1} and isLaboratory is not null", this.int_0, 1844), null, false, 0);
		if (this.checkBox_1.Checked && this.checkBox_2.Checked)
		{
			for (int j = 1; j < @class.Rows.Count; j++)
			{
				@class.Rows[j].Delete();
			}
			if (@class.Rows.Count > 0)
			{
				Class228.smethod_1(@class.Rows[0], this.class171_0, this.int_0, 1844, false, true);
				@class.Rows[0].EndEdit();
				if (!base.UpdateSqlData(@class))
				{
					return false;
				}
				if (!this.method_30(Convert.ToInt32(@class.Rows[0]["id"])))
				{
					return false;
				}
			}
			else
			{
				DataRow dataRow2 = @class.NewRow();
				Class228.smethod_1(dataRow2, this.class171_0, this.int_0, 1844, false, true);
				@class.Rows.Add(dataRow2);
				int num2 = base.InsertSqlDataOneRow(dataRow2);
				if (num2 <= 0)
				{
					return false;
				}
				if (!this.method_30(num2))
				{
					return false;
				}
			}
		}
		else
		{
			foreach (object obj2 in @class.Rows)
			{
				((DataRow)obj2).Delete();
			}
			if (!base.DeleteSqlData(@class))
			{
				return false;
			}
		}
		return true;
	}

	private bool method_30(int int_1)
	{
		Class171.Class184 @class = new Class171.Class184();
		base.SelectSqlData(@class, true, "where idDamage = " + int_1.ToString(), null, false, 0);
		for (int i = this.class171_0.tJ_DamageCharacter.Rows.Count; i < @class.Rows.Count; i++)
		{
			@class.Rows[i].Delete();
		}
		for (int j = 0; j < this.class171_0.tJ_DamageCharacter.Rows.Count; j++)
		{
			if (j < @class.Rows.Count)
			{
				@class.Rows[j]["idDamage"] = int_1;
				@class.Rows[j]["col1"] = this.class171_0.tJ_DamageCharacter.Rows[j]["col1"];
				@class.Rows[j]["col2"] = this.class171_0.tJ_DamageCharacter.Rows[j]["col2"];
				@class.Rows[j]["col3"] = this.class171_0.tJ_DamageCharacter.Rows[j]["col3"];
				@class.Rows[j]["idSchmObj"] = this.class171_0.tJ_DamageCharacter.Rows[j]["idSchmObj"];
				@class.Rows[j]["idLineSection"] = this.class171_0.tJ_DamageCharacter.Rows[j]["idLineSection"];
				@class.Rows[j].EndEdit();
			}
			else
			{
				DataRow dataRow = @class.NewRow();
				dataRow["idDamage"] = int_1;
				dataRow["col1"] = this.class171_0.tJ_DamageCharacter.Rows[j]["col1"];
				dataRow["col2"] = this.class171_0.tJ_DamageCharacter.Rows[j]["col2"];
				dataRow["col3"] = this.class171_0.tJ_DamageCharacter.Rows[j]["col3"];
				dataRow["idSChmObj"] = this.class171_0.tJ_DamageCharacter.Rows[j]["idSchmObj"];
				dataRow["idLineSection"] = this.class171_0.tJ_DamageCharacter.Rows[j]["idLineSection"];
				@class.Rows.Add(dataRow);
			}
		}
		return base.DeleteSqlData(@class) && base.UpdateSqlData(@class) && base.InsertSqlData(@class);
	}

	private DataTable method_31()
	{
		return new DataTable("tR_KladrObj")
		{
			Columns = 
			{
				{
					"id",
					typeof(int)
				},
				{
					"name",
					typeof(string)
				},
				{
					"socr",
					typeof(string)
				},
				{
					"fullname",
					typeof(string),
					"name + isnull(' ' + socr, '')"
				}
			}
		};
	}

	private DataTable method_32()
	{
		return new DataTable("tR_KladrStreet")
		{
			Columns = 
			{
				{
					"id",
					typeof(int)
				},
				{
					"KladrObjId",
					typeof(int)
				},
				{
					"name",
					typeof(string)
				},
				{
					"socr",
					typeof(string)
				},
				{
					"fullname",
					typeof(string),
					"name + isnull(' ' + socr, '')"
				}
			}
		};
	}

	protected override XmlDocument CreateXmlConfig()
	{
		XmlDocument xmlDocument = new XmlDocument();
		XmlNode newChild = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", null);
		xmlDocument.AppendChild(newChild);
		XmlNode newChild2 = xmlDocument.CreateElement(base.Name);
		xmlDocument.AppendChild(newChild2);
		return xmlDocument;
	}

	protected override void ApplyConfig(XmlDocument xmlDocument_0)
	{
		xmlDocument_0.SelectSingleNode(base.Name);
	}

	private void method_33()
	{
		this.dataGridView_0.Rows.Clear();
		base.SelectSqlData(this.class171_0.tJ_DamageCharacter, true, "where idDamage = " + this.int_0.ToString(), null, false, 0);
		int num = 0;
		foreach (DataRow dataRow in this.class171_0.tJ_DamageCharacter)
		{
			this.dataGridView_0.Rows.Add();
			if (dataRow["col1"] != DBNull.Value)
			{
				this.dataGridView_0.CurrentCell = this.dataGridView_0.Rows[num].Cells[this.dataGridViewComboBoxColumn_0.Name];
				this.dataGridView_0.Rows[num].Cells[this.dataGridViewComboBoxColumn_0.Name].Value = dataRow["col1"];
				DataTable dataTable = this.method_7();
				if (this.class184_0 != null)
				{
					DataRow[] array = this.class184_0.Select("id = " + dataRow["id"].ToString());
					if (array.Length != 0 && array[0]["col2"] != DBNull.Value)
					{
						base.SelectSqlData(dataTable, true, string.Format(" where (parentId = {0} and isGroup = 1 and Deleted = 0) or (id = {1}) order by parentKey", dataRow["col1"], array[0]["col2"]), null, false, 0);
					}
					else
					{
						base.SelectSqlData(dataTable, true, string.Format(" where parentId = {0} and isGroup = 1 and Deleted = 0 order by parentKey", dataRow["col1"]), null, false, 0);
					}
				}
				else
				{
					base.SelectSqlData(dataTable, true, string.Format(" where parentId = {0} and isGroup = 1 and Deleted = 0 order by parentKey", dataRow["col1"]), null, false, 0);
				}
				DataGridViewComboBoxCell dataGridViewComboBoxCell = this.dataGridView_0[this.dataGridViewComboBoxColumn_2.Index, num] as DataGridViewComboBoxCell;
				dataGridViewComboBoxCell.DataSource = dataTable;
				dataGridViewComboBoxCell.DisplayMember = "name";
				dataGridViewComboBoxCell.ValueMember = "id";
			}
			if (dataRow["col2"] != DBNull.Value)
			{
				this.dataGridView_0.CurrentCell = this.dataGridView_0.Rows[num].Cells[this.dataGridViewComboBoxColumn_0.Name];
				this.dataGridView_0.Rows[num].Cells[this.dataGridViewComboBoxColumn_2.Name].Value = dataRow["col2"];
				DataTable dataTable2 = this.method_7();
				if (this.class184_0 != null)
				{
					DataRow[] array2 = this.class184_0.Select("id = " + dataRow["id"].ToString());
					if (array2.Length != 0 && array2[0]["col3"] != DBNull.Value)
					{
						base.SelectSqlData(dataTable2, true, string.Format(" where (parentId = {0} and isGroup = 1 and Deleted = 0) or (id = {1}) order by parentKey", dataRow["col2"], array2[0]["col3"]), null, false, 0);
					}
					else
					{
						base.SelectSqlData(dataTable2, true, string.Format(" where parentId = {0} and isGroup = 1 and Deleted = 0 order by parentKey", dataRow["col2"]), null, false, 0);
					}
				}
				else
				{
					base.SelectSqlData(dataTable2, true, string.Format(" where parentId = {0} and isGroup = 1 and Deleted = 0 order by parentKey", dataRow["col2"]), null, false, 0);
				}
				DataGridViewComboBoxCell dataGridViewComboBoxCell2 = this.dataGridView_0[this.dataGridViewComboBoxColumn_3.Index, num] as DataGridViewComboBoxCell;
				dataGridViewComboBoxCell2.DataSource = dataTable2;
				dataGridViewComboBoxCell2.DisplayMember = "name";
				dataGridViewComboBoxCell2.ValueMember = "id";
			}
			if (dataRow["col3"] != DBNull.Value)
			{
				this.dataGridView_0.Rows[num].Cells[this.dataGridViewComboBoxColumn_3.Name].Value = dataRow["col3"];
			}
			if (dataRow["idSchmObj"] != DBNull.Value)
			{
				this.dataGridView_0[this.dataGridViewTextBoxColumn_4.Index, num].Value = dataRow["idSchmObj"];
				object obj = base.CallSQLScalarFunction("dbo.fn_Schm_GetFullNameObjById", new string[]
				{
					dataRow["idSchmObj"].ToString()
				});
				if (obj != null && obj != DBNull.Value)
				{
					this.dataGridView_0[this.dataGridViewTextBoxColumn_3.Index, num].Value = obj.ToString();
				}
				DataGridViewComboBoxCell dataGridViewComboBoxCell3 = this.dataGridView_0[this.dataGridViewComboBoxColumn_1.Index, num] as DataGridViewComboBoxCell;
				DataTable dataTable3 = new DataTable("tP_CabSection");
				dataTable3.Columns.Add("id", typeof(int));
				dataTable3.Columns.Add("number", typeof(int));
				base.SelectSqlData(dataTable3, true, "where idObjList = " + dataRow["idSchmObj"].ToString() + " order by number", null, false, 0);
				dataGridViewComboBoxCell3.DataSource = dataTable3;
				dataGridViewComboBoxCell3.ValueMember = "id";
				dataGridViewComboBoxCell3.DisplayMember = "number";
				dataGridViewComboBoxCell3.ReadOnly = false;
				if (dataRow["idLineSection"] != DBNull.Value)
				{
					dataGridViewComboBoxCell3.Value = dataRow["idLineSection"];
				}
				else
				{
					dataGridViewComboBoxCell3.Value = null;
				}
			}
			num++;
		}
	}

	private void method_34()
	{
		DataTable dataTable = this.method_7();
		string text = "";
		if (this.class184_0 != null && this.class184_0.Rows.Count > 0)
		{
			foreach (object obj in this.class184_0.Rows)
			{
				DataRow dataRow = (DataRow)obj;
				if (string.IsNullOrEmpty(text))
				{
					text = dataRow["col1"].ToString();
				}
				else
				{
					text = text + "," + dataRow["col1"].ToString();
				}
			}
		}
		if (string.IsNullOrEmpty(text))
		{
			base.SelectSqlData(dataTable, true, "where ParentId in (select id from \r\n                                        tr_classifier where ParentKey = ';ReportDaily;NatureDamage;HV;') \r\n                                        and isGroup = 1 and deleted = 0 order by ParentKey", null, false, 0);
		}
		else
		{
			base.SelectSqlData(dataTable, true, string.Format("where (ParentId in (select id from \r\n                                        tr_classifier where ParentKey = ';ReportDaily;NatureDamage;HV;') \r\n                                        and isGroup = 1 and deleted = 0) or \r\n                                        (id in ({0})) order by ParentKey", text), null, false, 0);
		}
		BindingSource bindingSource = new BindingSource();
		bindingSource.DataSource = dataTable;
		bindingSource.Position = -1;
		this.dataGridViewComboBoxColumn_0.DisplayMember = "name";
		this.dataGridViewComboBoxColumn_0.ValueMember = "id";
		this.dataGridViewComboBoxColumn_0.DataSource = bindingSource;
	}

	private void dataGridView_0_DataError(object sender, DataGridViewDataErrorEventArgs e)
	{
		if (this.dataGridView_0.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn)
		{
			e.Cancel = true;
		}
	}

	private void dataGridView_0_CurrentCellDirtyStateChanged(object sender, EventArgs e)
	{
		if (this.dataGridView_0.IsCurrentCellDirty)
		{
			this.dataGridView_0.CommitEdit(DataGridViewDataErrorContexts.Commit);
			this.bool_0 = true;
			this.label_22.ForeColor = Color.Black;
			if ((this.dataGridView_0.CurrentCell.ColumnIndex == this.dataGridViewComboBoxColumn_0.Index || this.dataGridView_0.CurrentCell.ColumnIndex == this.dataGridViewComboBoxColumn_2.Index) && this.dataGridView_0.CurrentCell.Value != null)
			{
				if (this.dataGridView_0.CurrentCell.ColumnIndex == this.dataGridViewComboBoxColumn_0.Index)
				{
					DataGridViewComboBoxCell dataGridViewComboBoxCell = this.dataGridView_0[this.dataGridViewComboBoxColumn_1.Index, this.dataGridView_0.CurrentRow.Index] as DataGridViewComboBoxCell;
					dataGridViewComboBoxCell.DataSource = null;
					dataGridViewComboBoxCell.Value = null;
					this.dataGridView_0[this.dataGridViewTextBoxColumn_3.Index, this.dataGridView_0.CurrentRow.Index].Value = null;
					this.dataGridView_0[this.dataGridViewTextBoxColumn_4.Index, this.dataGridView_0.CurrentRow.Index].Value = null;
				}
				DataTable dataTable = this.method_7();
				base.SelectSqlData(dataTable, true, string.Format(" where parentId = {0} and isGroup = 1 and Deleted = 0 order by parentKey", this.dataGridView_0.CurrentCell.Value), null, false, 0);
				int columnIndex = (this.dataGridView_0.CurrentCell.ColumnIndex == this.dataGridViewComboBoxColumn_0.Index) ? this.dataGridViewComboBoxColumn_2.Index : ((this.dataGridView_0.CurrentCell.ColumnIndex == this.dataGridViewComboBoxColumn_2.Index) ? this.dataGridViewComboBoxColumn_3.Index : -1);
				DataGridViewComboBoxCell dataGridViewComboBoxCell2 = this.dataGridView_0[columnIndex, this.dataGridView_0.CurrentRow.Index] as DataGridViewComboBoxCell;
				dataGridViewComboBoxCell2.DataSource = dataTable;
				dataGridViewComboBoxCell2.DisplayMember = "name";
				dataGridViewComboBoxCell2.ValueMember = "id";
				if (dataGridViewComboBoxCell2.Value != null && dataTable.Select("id = " + dataGridViewComboBoxCell2.Value.ToString()).Length == 0)
				{
					dataGridViewComboBoxCell2.Value = null;
				}
				if (dataGridViewComboBoxCell2.Value == null && dataGridViewComboBoxCell2.ColumnIndex == this.dataGridViewComboBoxColumn_2.Index)
				{
					DataGridViewComboBoxCell dataGridViewComboBoxCell3 = this.dataGridView_0[this.dataGridViewComboBoxColumn_3.Index, this.dataGridView_0.CurrentRow.Index] as DataGridViewComboBoxCell;
					dataGridViewComboBoxCell3.DataSource = null;
					dataGridViewComboBoxCell3.Value = null;
				}
			}
		}
	}

	private void dataGridView_0_MouseClick(object sender, MouseEventArgs e)
	{
		if (this.dataGridView_0.HitTest(e.X, e.Y).Type == DataGridViewHitTestType.RowHeader)
		{
			this.dataGridView_0.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
			this.dataGridView_0.EndEdit();
			return;
		}
		this.dataGridView_0.EditMode = DataGridViewEditMode.EditOnEnter;
	}

	private void dataGridView_0_CellContentClick(object sender, DataGridViewCellEventArgs e)
	{
		if (e.ColumnIndex == this.dataGridViewButtonColumn_0.Index && e.RowIndex >= 0)
		{
			if (this.dataGridView_0[this.dataGridViewComboBoxColumn_0.Index, e.RowIndex].Value == null)
			{
				MessageBox.Show("Не выбран тип объекта");
				return;
			}
			DataTable dataTable = this.method_7();
			dataTable.Columns.Add("ParentKey", typeof(string));
			base.SelectSqlData(dataTable, true, " where id = " + this.dataGridView_0[this.dataGridViewComboBoxColumn_0.Index, e.RowIndex].Value.ToString(), null, false, 0);
			if (dataTable.Rows.Count == 0)
			{
				return;
			}
			List<int> list = new List<int>();
			string a = dataTable.Rows[0]["ParentKey"].ToString();
			if (!(a == ";ReportDaily;NatureDamage;HV;AirLine;"))
			{
				if (!(a == ";ReportDaily;NatureDamage;HV;CableLine;"))
				{
					if (a == ";ReportDaily;NatureDamage;HV;Subs;")
					{
						list.Add(536);
						list.Add(535);
						list.Add(537);
						list.Add(1034);
						list.Add(538);
						list.Add(1275);
					}
				}
				else
				{
					list.Add(546);
					list.Add(548);
				}
			}
			else
			{
				list.Add(547);
				list.Add(983);
				list.Add(548);
			}
			DataGridViewComboBoxCell dataGridViewComboBoxCell = this.dataGridView_0[this.dataGridViewComboBoxColumn_1.Index, e.RowIndex] as DataGridViewComboBoxCell;
			if (!(dataTable.Rows[0]["ParentKey"].ToString() == ";ReportDaily;NatureDamage;HV;AirLine;") && !(dataTable.Rows[0]["ParentKey"].ToString() == ";ReportDaily;NatureDamage;HV;CableLine;"))
			{
				if (dataTable.Rows[0]["ParentKey"].ToString() == ";ReportDaily;NatureDamage;HV;Subs;")
				{
					Form28 form = new Form28();
					form.SqlSettings = this.SqlSettings;
					form.method_3(false);
					if (form.ShowDialog() == DialogResult.OK)
					{
						if (form.method_0().Count > 0)
						{
							this.dataGridView_0[this.dataGridViewTextBoxColumn_4.Name, e.RowIndex].Value = form.method_0().First<KeyValuePair<int, string>>().Key;
							this.dataGridView_0[this.dataGridViewTextBoxColumn_3.Name, e.RowIndex].Value = form.method_0().First<KeyValuePair<int, string>>().Value;
						}
						else
						{
							this.dataGridView_0[this.dataGridViewTextBoxColumn_4.Name, e.RowIndex].Value = DBNull.Value;
							this.dataGridView_0[this.dataGridViewTextBoxColumn_3.Name, e.RowIndex].Value = DBNull.Value;
						}
						this.bool_0 = true;
					}
					dataGridViewComboBoxCell.DataSource = null;
					dataGridViewComboBoxCell.Value = null;
					dataGridViewComboBoxCell.ReadOnly = true;
					return;
				}
				Form27 form2 = new Form27();
				form2.SqlSettings = this.SqlSettings;
				form2.method_3(false);
				if (form2.ShowDialog() == DialogResult.OK)
				{
					if (form2.method_0().Count > 0)
					{
						this.dataGridView_0[this.dataGridViewTextBoxColumn_4.Name, e.RowIndex].Value = form2.method_0().First<KeyValuePair<int, string>>().Key;
						this.dataGridView_0[this.dataGridViewTextBoxColumn_3.Name, e.RowIndex].Value = form2.method_0().First<KeyValuePair<int, string>>().Value;
					}
					else
					{
						this.dataGridView_0[this.dataGridViewTextBoxColumn_4.Name, e.RowIndex].Value = DBNull.Value;
						this.dataGridView_0[this.dataGridViewTextBoxColumn_3.Name, e.RowIndex].Value = DBNull.Value;
					}
					this.bool_0 = true;
				}
				dataGridViewComboBoxCell.DataSource = null;
				dataGridViewComboBoxCell.Value = null;
				dataGridViewComboBoxCell.ReadOnly = true;
			}
			else
			{
				Form26 form3 = new Form26(list);
				form3.method_5(false);
				form3.SqlSettings = this.SqlSettings;
				if (form3.ShowDialog() == DialogResult.OK)
				{
					this.dataGridView_0[this.dataGridViewTextBoxColumn_3.Name, e.RowIndex].Value = form3.method_0().string_0;
					this.dataGridView_0[this.dataGridViewTextBoxColumn_4.Name, e.RowIndex].Value = form3.method_0().int_0;
					DataTable dataTable2 = new DataTable("tP_CabSection");
					dataTable2.Columns.Add("id", typeof(int));
					dataTable2.Columns.Add("number", typeof(int));
					base.SelectSqlData(dataTable2, true, "where idObjList = " + form3.method_0().int_0.ToString() + " order by number", null, false, 0);
					dataGridViewComboBoxCell.DataSource = dataTable2;
					dataGridViewComboBoxCell.ValueMember = "id";
					dataGridViewComboBoxCell.DisplayMember = "number";
					dataGridViewComboBoxCell.Value = null;
					dataGridViewComboBoxCell.ReadOnly = false;
					this.bool_0 = true;
					return;
				}
			}
		}
	}

	private void method_35()
	{
		if (!this.method_1() && this.checkBox_0.Checked)
		{
			this.textBox_1.ReadOnly = true;
			this.dateTimePicker_1.Enabled = false;
			this.comboBoxReadOnly_1.ReadOnly = true;
			this.comboBoxReadOnly_0.ReadOnly = true;
			this.button_2.Enabled = false;
			this.dataGridView_0.ReadOnly = true;
			this.dataGridView_0.AllowUserToDeleteRows = false;
			this.richTextBox_0.ReadOnly = true;
			this.comboBoxReadOnly_4.ReadOnly = true;
			this.comboBoxReadOnly_5.ReadOnly = true;
			TextBoxBase textBoxBase = this.textBox_7;
			TextBoxBase textBoxBase2 = this.textBox_6;
			TextBoxBase textBoxBase3 = this.textBox_5;
			TextBoxBase textBoxBase4 = this.textBox_4;
			TextBoxBase textBoxBase5 = this.textBox_8;
			this.textBox_10.ReadOnly = true;
			textBoxBase5.ReadOnly = true;
			textBoxBase4.ReadOnly = true;
			textBoxBase3.ReadOnly = true;
			textBoxBase2.ReadOnly = true;
			textBoxBase.ReadOnly = true;
			Control control = this.comboBox_1;
			this.comboBox_0.Enabled = false;
			control.Enabled = false;
			this.dataGridViewButtonColumn_0.Visible = false;
			ToolStripItem toolStripItem = this.toolStripButton_1;
			this.toolStripButton_0.Enabled = false;
			toolStripItem.Enabled = false;
			this.comboBoxReadOnly_3.ReadOnly = true;
			this.dataGridViewExcelFilter_0.ReadOnly = true;
			this.dataGridViewExcelFilter_0.AllowUserToDeleteRows = false;
			Control control2 = this.radioButton_1;
			this.radioButton_0.Enabled = false;
			control2.Enabled = false;
			this.richTextBox_1.ReadOnly = true;
			this.checkBox_0.Enabled = false;
			this.comboBoxReadOnly_2.ReadOnly = true;
			this.nullableDateTimePicker_0.Enabled = false;
			this.button_3.Visible = false;
			this.toolStripButton_2.Enabled = false;
			this.toolStripDropDownButton_0.Enabled = false;
			UpDownBase upDownBase = this.numericUpDown_3;
			UpDownBase upDownBase2 = this.numericUpDown_4;
			UpDownBase upDownBase3 = this.numericUpDown_6;
			UpDownBase upDownBase4 = this.numericUpDown_5;
			UpDownBase upDownBase5 = this.numericUpDown_2;
			UpDownBase upDownBase6 = this.numericUpDown_1;
			this.numericUpDown_0.ReadOnly = true;
			upDownBase6.ReadOnly = true;
			upDownBase5.ReadOnly = true;
			upDownBase4.ReadOnly = true;
			upDownBase3.ReadOnly = true;
			upDownBase2.ReadOnly = true;
			upDownBase.ReadOnly = true;
			UpDownBase upDownBase7 = this.numericUpDown_13;
			UpDownBase upDownBase8 = this.numericUpDown_14;
			UpDownBase upDownBase9 = this.numericUpDown_15;
			UpDownBase upDownBase10 = this.numericUpDown_16;
			UpDownBase upDownBase11 = this.numericUpDown_9;
			UpDownBase upDownBase12 = this.numericUpDown_8;
			this.numericUpDown_7.ReadOnly = true;
			upDownBase12.ReadOnly = true;
			upDownBase11.ReadOnly = true;
			upDownBase10.ReadOnly = true;
			upDownBase9.ReadOnly = true;
			upDownBase8.ReadOnly = true;
			upDownBase7.ReadOnly = true;
			UpDownBase upDownBase13 = this.numericUpDown_12;
			UpDownBase upDownBase14 = this.numericUpDown_11;
			this.numericUpDown_10.ReadOnly = true;
			upDownBase14.ReadOnly = true;
			upDownBase13.ReadOnly = true;
		}
	}

	private void comboBoxReadOnly_3_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.bool_0 = true;
		if (this.comboBoxReadOnly_3.SelectedIndex >= 0)
		{
			this.label_8.ForeColor = Color.Black;
		}
	}

	private void comboBoxReadOnly_2_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.bool_0 = true;
		if (this.comboBoxReadOnly_2.SelectedIndex >= 0)
		{
			this.checkBox_0.ForeColor = Color.Black;
		}
	}

	private void nullableDateTimePicker_0_ValueChanged(object sender, EventArgs e)
	{
		this.bool_0 = true;
		if (this.nullableDateTimePicker_0.Value != null)
		{
			this.label_7.ForeColor = Color.Black;
		}
	}

	private void checkBox_0_CheckedChanged(object sender, EventArgs e)
	{
	}

	private void checkBox_1_CheckedChanged(object sender, EventArgs e)
	{
		this.label_25.Visible = this.checkBox_1.Checked;
		this.comboBoxReadOnly_6.Visible = this.checkBox_1.Checked;
		this.checkBox_2.Visible = this.checkBox_1.Checked;
		this.label_24.Visible = (this.richTextBox_3.Visible = (this.checkBox_1.Checked && this.comboBoxReadOnly_6.SelectedIndex >= 0));
		this.label_23.Visible = (this.richTextBox_2.Visible = (this.checkBox_1.Checked && this.checkBox_2.Checked));
		this.bool_0 = true;
	}

	private void comboBoxReadOnly_6_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.label_24.Visible = (this.richTextBox_3.Visible = (this.checkBox_1.Checked && this.comboBoxReadOnly_6.SelectedIndex >= 0));
		this.bool_0 = true;
	}

	private void checkBox_2_CheckedChanged(object sender, EventArgs e)
	{
		this.label_23.Visible = (this.richTextBox_2.Visible = (this.checkBox_1.Checked && this.checkBox_2.Checked));
		this.bool_0 = true;
	}

	private void dataGridViewExcelFilter_0_CellValueChanged(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex >= 0)
		{
			if (this.dataGridViewExcelFilter_0[this.dataGridViewTextBoxColumn_23.Name, e.RowIndex].Value == DBNull.Value || Convert.ToInt32(this.dataGridViewExcelFilter_0[this.dataGridViewTextBoxColumn_23.Name, e.RowIndex].Value) != this.int_0)
			{
				this.dataGridViewExcelFilter_0[this.dataGridViewTextBoxColumn_23.Name, e.RowIndex].Value = this.int_0;
			}
			if (this.dataGridViewExcelFilter_0.Columns[e.ColumnIndex] == this.dataGridViewFilterDateTimePickerColumn_0 || this.dataGridViewExcelFilter_0.Columns[e.ColumnIndex] == this.dataGridViewTextBoxColumn_20)
			{
				this.bool_0 = true;
				if (this.dataGridViewExcelFilter_0[this.dataGridViewTextBoxColumn_20.Name, e.RowIndex].Value != DBNull.Value)
				{
					this.method_40();
					this.method_39();
				}
				if (this.dataGridViewExcelFilter_0[this.dataGridViewFilterDateTimePickerColumn_0.Name, e.RowIndex].Value != DBNull.Value)
				{
					this.method_43();
				}
				if (this.dataGridViewExcelFilter_0[this.dataGridViewFilterDateTimePickerColumn_0.Name, e.RowIndex].Value != DBNull.Value && this.dataGridViewExcelFilter_0[this.dataGridViewTextBoxColumn_20.Name, e.RowIndex].Value != DBNull.Value)
				{
					this.dataGridViewExcelFilter_0[this.dataGridViewTextBoxColumn_21.Name, e.RowIndex].Value = this.method_36(e.RowIndex);
					for (int i = e.RowIndex + 1; i < this.dataGridViewExcelFilter_0.Rows.Count - 1; i++)
					{
						this.dataGridViewExcelFilter_0[this.dataGridViewTextBoxColumn_21.Name, i].Value = this.method_36(i);
					}
					this.method_38();
				}
			}
		}
	}

	private decimal method_36(int int_1)
	{
		decimal result;
		try
		{
			if (string.IsNullOrEmpty(this.textBox_8.Text))
			{
				result = 0m;
			}
			else if (string.IsNullOrEmpty(this.textBox_5.Text))
			{
				result = 0m;
			}
			else if (string.IsNullOrEmpty(this.textBox_4.Text))
			{
				result = 0m;
			}
			else if (string.IsNullOrEmpty(this.textBox_7.Text))
			{
				result = 0m;
			}
			else if (string.IsNullOrEmpty(this.textBox_10.Text))
			{
				result = 0m;
			}
			else if (this.dataGridViewExcelFilter_0[this.dataGridViewFilterDateTimePickerColumn_0.Name, int_1].Value == DBNull.Value)
			{
				result = 0m;
			}
			else if (this.dataGridViewExcelFilter_0[this.dataGridViewTextBoxColumn_20.Name, int_1].Value == DBNull.Value)
			{
				result = 0m;
			}
			else
			{
				int num = 0;
				for (int i = 0; i < int_1; i++)
				{
					num += Convert.ToInt32(this.dataGridViewExcelFilter_0[this.dataGridViewTextBoxColumn_20.Name, i].Value);
				}
				DateTime d = Convert.ToDateTime(this.dataGridViewExcelFilter_0[this.dataGridViewFilterDateTimePickerColumn_0.Name, int_1].Value);
				d = d.AddSeconds((double)(-(double)d.Second));
				DateTime dateTime = (int_1 > 0) ? Convert.ToDateTime(this.dataGridViewExcelFilter_0[this.dataGridViewFilterDateTimePickerColumn_0.Name, int_1 - 1].Value) : this.dateTimePicker_1.Value;
				decimal d2 = Convert.ToDecimal((d - dateTime.AddSeconds((double)(-(double)dateTime.Second))).TotalHours);
				result = Convert.ToDecimal((Convert.ToDecimal(Math.Sqrt(3.0)) * (Convert.ToDecimal(this.textBox_5.Text) / Convert.ToInt32(this.textBox_7.Text)) * Convert.ToDecimal(this.textBox_4.Text) * d2 * Convert.ToDecimal(this.textBox_8.Text) * (Convert.ToInt32(this.textBox_7.Text) - num) * Convert.ToDecimal(this.textBox_10.Text)).ToString("0.##"));
			}
		}
		catch
		{
			result = 0m;
		}
		return result;
	}

	private void method_37()
	{
		if (this.radioButton_1.Checked)
		{
			for (int i = 0; i < this.dataGridViewExcelFilter_0.Rows.Count - 1; i++)
			{
				this.dataGridViewExcelFilter_0[this.dataGridViewTextBoxColumn_21.Name, i].Value = this.method_36(i);
			}
		}
		this.method_43();
		this.method_40();
		this.method_39();
		this.method_38();
	}

	private void method_38()
	{
		decimal d = 0m;
		for (int i = 0; i < this.dataGridViewExcelFilter_0.Rows.Count - 1; i++)
		{
			if (this.dataGridViewExcelFilter_0[this.dataGridViewTextBoxColumn_21.Name, i].Value != DBNull.Value)
			{
				d += Convert.ToDecimal(this.dataGridViewExcelFilter_0[this.dataGridViewTextBoxColumn_21.Name, i].Value);
			}
		}
		this.textBox_3.Text = d.ToString("0.##");
	}

	private void method_39()
	{
		if (!string.IsNullOrEmpty(this.textBox_7.Text))
		{
			int num = this.method_42();
			this.textBox_9.Text = (Convert.ToInt32(this.textBox_7.Text) - num).ToString();
			if (num != 0)
			{
				this.label_13.Text = string.Format("Недопуск эл. энергии, кВт*ч ({0} тр.)", num);
			}
		}
	}

	private void method_40()
	{
		for (int i = 0; i < this.dataGridViewExcelFilter_0.Rows.Count - 1; i++)
		{
			this.dataGridViewExcelFilter_0[this.dataGridViewTextBoxColumn_19.Name, i].Value = this.method_41(i);
		}
	}

	private int method_41(int int_1)
	{
		int num = 0;
		if (!string.IsNullOrEmpty(this.textBox_7.Text))
		{
			num = Convert.ToInt32(this.textBox_7.Text);
			for (int i = 0; i < int_1; i++)
			{
				num -= Convert.ToInt32(this.dataGridViewExcelFilter_0[this.dataGridViewTextBoxColumn_20.Name, i].Value);
			}
		}
		return num;
	}

	private int method_42()
	{
		int num = 0;
		for (int i = 0; i < this.dataGridViewExcelFilter_0.Rows.Count - 1; i++)
		{
			if (this.dataGridViewExcelFilter_0[this.dataGridViewTextBoxColumn_20.Name, i].Value != DBNull.Value)
			{
				num += Convert.ToInt32(this.dataGridViewExcelFilter_0[this.dataGridViewTextBoxColumn_20.Name, i].Value);
			}
		}
		return num;
	}

	private void method_43()
	{
		for (int i = 0; i < this.dataGridViewExcelFilter_0.Rows.Count - 1; i++)
		{
			if (i == 0)
			{
				this.dataGridViewExcelFilter_0[this.dataGridViewTextBoxColumn_18.Name, i].Value = this.dateTimePicker_1.Value;
			}
			else
			{
				this.dataGridViewExcelFilter_0[this.dataGridViewTextBoxColumn_18.Name, i].Value = this.dataGridViewExcelFilter_0[this.dataGridViewFilterDateTimePickerColumn_0.Name, i - 1].Value;
			}
		}
	}

	private void dataGridViewExcelFilter_0_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
	{
		if (this.dataGridViewExcelFilter_0.CurrentCell != null && this.dataGridViewExcelFilter_0.Columns[this.dataGridViewExcelFilter_0.CurrentCell.ColumnIndex] == this.dataGridViewFilterDateTimePickerColumn_0 && e.Control is DateTimePicker)
		{
			if (this.dataGridViewExcelFilter_0.CurrentCell.RowIndex == 0)
			{
				((DateTimePicker)e.Control).MinDate = this.dateTimePicker_1.Value;
			}
			else
			{
				((DateTimePicker)e.Control).MinDate = Convert.ToDateTime(this.dataGridViewExcelFilter_0[this.dataGridViewFilterDateTimePickerColumn_0.Index, this.dataGridViewExcelFilter_0.CurrentCell.RowIndex - 1].Value);
			}
			((DateTimePicker)e.Control).MaxDate = this.dateTime_0;
			if (this.dataGridViewExcelFilter_0.CurrentCell.Value == DBNull.Value)
			{
				this.dataGridViewExcelFilter_0.CurrentCell.Value = ((DateTimePicker)e.Control).Value;
			}
		}
	}

	private void dataGridViewExcelFilter_0_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
	{
		this.bool_0 = true;
		this.method_37();
	}

	private void dataGridViewExcelFilter_0_DataError(object sender, DataGridViewDataErrorEventArgs e)
	{
		try
		{
			e.ThrowException = false;
			e.Cancel = true;
			MessageBox.Show(e.Exception.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		catch (Exception)
		{
		}
	}

	private void dataGridViewExcelFilter_0_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
	{
		if (this.class171_0.tJ_DamageOn.Rows.Count > 0 || this.dataGridViewExcelFilter_0.Rows.Count > 1)
		{
			this.label_11.ForeColor = Color.Black;
		}
	}

	private void toolStripButton_1_Click(object sender, EventArgs e)
	{
		this.method_46();
	}

	private void method_44(TreeNodeObj treeNodeObj_0, List<int> list_1)
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
			this.method_44(treeNodeObj_, list_1);
		}
	}

	private void method_45(List<int> list_1)
	{
		this.dataTable_0.Clear();
		using (SqlConnection sqlConnection = new SqlConnection(this.SqlSettings.GetConnectionString() + ";Connection Timeout=1000"))
		{
			sqlConnection.Open();
			using (SqlCommand sqlCommand = new SqlCommand(Class7.smethod_2("Documents.Forms.DailyReport.SqlScripts.GetTransformerSchmObj.sql"), sqlConnection))
			{
				sqlCommand.CommandTimeout = 0;
				DataTable dataTable = new DataTable();
				new SqlDataAdapter(sqlCommand).Fill(dataTable);
				int num = 0;
				foreach (int num2 in list_1)
				{
					DataRow[] array = dataTable.Select("id = " + num2.ToString());
					if (array.Length != 0)
					{
						DataRow dataRow = this.dataTable_0.NewRow();
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
						this.dataTable_0.Rows.Add(dataRow);
					}
				}
			}
			using (SqlCommand sqlCommand2 = new SqlCommand("SELECT mat.idbus, mat.[IdObjList],\r\n                        \t(case when max([Ia]) >= max([Ib]) and max([Ia]) >= max([Ic]) \r\n                        \t then max([Ia]) \telse case when max([Ib]) >= max([Ic]) and max([Ib]) >= max([Ia]) then max([Ib]) \r\n                        \t\t\t\t\t                                else case when max([Ic]) >= max([Ia]) and max([Ic]) >= max([Ib]) \r\n                        \t\t\t\t\t                                then max([Ic]) end end end) as I\r\n                         FROM [tJ_MeasAmperageTransf] as mat\r\n                               inner join [tJ_Measurement] as m on mat.[idMeasurement] = m.id\r\n                          where  mat.deleted = 0 and m.[TypeDoc] = 1192\r\n                        \tand ((year(m.[DateD]) = \r\n                        \t\t\t(select case when month(max(dateD)) = 12 then year(max(dateD)) + 1\r\n                        \t\t\t\t\telse year(max(dateD)) end from tj_measurement mes \r\n                        \t\t\tleft join [tJ_MeasAmperageTransf] mt on mt.[idMeasurement] = mes.id\r\n                        \t\t\t where mt.idBus = mat.idBus and mt.deleted = 0 and m.typeDoc = 1192\t\r\n                        \t\t\t and  mt.[Ia] is not null and  mt.[Ib] is not null and  mt.[Ic] is not null)\r\n                                      and month(m.[DateD]) between 1 and 11)\t\r\n                           or (year(m.[DateD]) =(select case when month(max(dateD)) = 12 then year(max(dateD)) + 1\r\n                        \telse year(max(dateD)) end\r\n                        \tfrom tj_measurement mes \r\n                        \tleft join [tJ_MeasAmperageTransf] mt on mt.[idMeasurement] = mes.id\r\n                        \twhere mt.idBus = mat.idBus and mt.deleted = 0 and m.typeDoc = 1192\r\n                        \t and  mt.[Ia] is not null and  mt.[Ib] is not null and  mt.[Ic] is not null)-1 and month(m.[DateD])=12)) \r\n                            and  mat.[Ia] is not null and  mat.[Ib] is not null and  mat.[Ic] is not null \r\n                          group by mat.idBus,  mat.[idObjList]", sqlConnection))
			{
				sqlCommand2.CommandTimeout = 0;
				DataTable dataTable2 = new DataTable();
				new SqlDataAdapter(sqlCommand2).Fill(dataTable2);
				foreach (object obj in this.dataTable_0.Rows)
				{
					DataRow dataRow2 = (DataRow)obj;
					DataRow[] array2 = dataTable2.Select("idObjList = " + dataRow2["idTr"].ToString());
					if (array2.Length != 0)
					{
						dataRow2["Load"] = array2[0]["I"];
					}
				}
			}
		}
	}

	private void method_46()
	{
		if (this.class171_0.tJ_Damage.Rows.Count > 0 && this.class171_0.tJ_Damage.Rows[0]["idSchmObj"] != DBNull.Value)
		{
			Control control = this.label_20;
			this.progressBar_0.Visible = true;
			control.Visible = true;
			this.toolStripButton_0.Enabled = false;
			this.toolStripButton_1.Enabled = false;
			this.button_2.Enabled = false;
			this.dateTimePicker_1.Enabled = false;
			this.dataGridViewExcelFilter_1.Enabled = false;
			this.dataGridViewExcelFilter_1.DataSource = null;
			this.treeDataGridView_0.Enabled = false;
			this.dataGridViewExcelFilter_2.Enabled = false;
			this.dataGridViewExcelFilter_2.DataSource = null;
			Control control2 = this.button_0;
			this.button_1.Enabled = false;
			control2.Enabled = false;
			this.backgroundWorker_0.RunWorkerAsync(this.dateTimePicker_1.Value);
			return;
		}
		this.dataTable_0.Clear();
		this.dataTable_1.Clear();
	}

	private void backgroundWorker_0_DoWork(object sender, DoWorkEventArgs e)
	{
		ElectricModel electricModel = new ElectricModel();
		electricModel.SqlSettings = this.SqlSettings;
		electricModel.LoadSchema(Convert.ToDateTime(e.Argument));
		TreeNodeObj treeNodeObj_ = electricModel.PoweringReportForDrawObject(Convert.ToInt32(this.class171_0.tJ_Damage.Rows[0]["idSchmObj"]), true);
		List<int> list_ = new List<int>();
		this.method_44(treeNodeObj_, list_);
		this.method_45(list_);
		this.method_54();
		this.list_0 = new List<int>();
		this.method_56(null, treeNodeObj_);
		IEnumerable<ElectricObject> source = electricModel.Objects.Where(new Func<ElectricObject, bool>(this.method_72));
		List<ElectricObject> list = electricModel.PoweringReportForDrawObject(source.First<ElectricObject>(), true, true);
		Class228.smethod_6(this.dataTable_1, this.SqlSettings, list, this.dateTimePicker_1.Value);
		this.toolStripStatusLabel_4.Text = "Количество абонентов: " + this.dataTable_1.DefaultView.ToTable(true, new string[]
		{
			"idAbn"
		}).Rows.Count.ToString();
	}

	private void backgroundWorker_0_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		Control control = this.label_20;
		this.progressBar_0.Visible = false;
		control.Visible = false;
		this.toolStripButton_0.Enabled = true;
		this.toolStripButton_1.Enabled = true;
		this.dataGridViewExcelFilter_1.Enabled = true;
		this.dataGridViewExcelFilter_1.DataSource = this.bindingSource_0;
		this.treeDataGridView_0.Enabled = true;
		this.dataGridViewExcelFilter_2.Enabled = true;
		this.dataGridViewExcelFilter_2.DataSource = this.bindingSource_1;
		Control control2 = this.button_0;
		this.button_1.Enabled = true;
		control2.Enabled = true;
		this.button_2.Enabled = true;
		this.dateTimePicker_1.Enabled = true;
		this.method_51();
		this.method_61(this.treeDataGridView_0.Nodes);
		this.method_64();
		this.method_65();
		this.method_68();
	}

	private void method_47()
	{
		XmlDocument xmlDocument = new XmlDocument();
		if (this.class171_0.tJ_Damage.Rows[0]["CommentXml"] != DBNull.Value)
		{
			try
			{
				xmlDocument.LoadXml(this.class171_0.tJ_Damage.Rows[0]["CommentXml"].ToString());
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
		foreach (object obj in this.dataTable_0.Rows)
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
		this.method_57(xmlNode2);
		this.class171_0.tJ_Damage.Rows[0]["CommentXml"] = xmlDocument.InnerXml;
	}

	private void method_48()
	{
		this.dataTable_0.Clear();
		if (this.class171_0.tJ_Damage.Rows.Count > 0 && this.class171_0.tJ_Damage.Rows[0]["CommentXml"] != DBNull.Value)
		{
			try
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.LoadXml(this.class171_0.tJ_Damage.Rows[0]["CommentXml"].ToString());
				XmlNode xmlNode = xmlDocument.SelectSingleNode("Doc");
				if (xmlNode != null)
				{
					XmlNode xmlNode2 = xmlNode.SelectSingleNode("TransOff");
					if (xmlNode2 != null)
					{
						List<string> list = new List<string>();
						List<string> list2 = new List<string>();
						foreach (object obj in xmlNode2.SelectNodes("Row"))
						{
							XmlNode xmlNode3 = (XmlNode)obj;
							DataRow dataRow = this.dataTable_0.NewRow();
							XmlAttribute xmlAttribute = xmlNode3.Attributes["idSub"];
							if (xmlAttribute != null && !string.IsNullOrEmpty(xmlAttribute.Value))
							{
								dataRow["idSub"] = xmlAttribute.Value;
								list.Add(xmlAttribute.Value);
							}
							xmlAttribute = xmlNode3.Attributes["idTr"];
							if (xmlAttribute != null && !string.IsNullOrEmpty(xmlAttribute.Value))
							{
								dataRow["idTr"] = xmlAttribute.Value;
								list2.Add(xmlAttribute.Value);
							}
							xmlAttribute = xmlNode3.Attributes["Power"];
							if (xmlAttribute != null && !string.IsNullOrEmpty(xmlAttribute.Value))
							{
								dataRow["Power"] = xmlAttribute.Value;
							}
							xmlAttribute = xmlNode3.Attributes["Load"];
							if (xmlAttribute != null && !string.IsNullOrEmpty(xmlAttribute.Value))
							{
								dataRow["Load"] = xmlAttribute.Value;
							}
							this.dataTable_0.Rows.Add(dataRow);
						}
						DataTable dataTable = new DataTable("vSchm_ObjList");
						dataTable.Columns.Add("id", typeof(int));
						dataTable.Columns.Add("name", typeof(string));
						dataTable.Columns.Add("typeCodeSocr", typeof(string));
						dataTable.Columns.Add("fullname", typeof(string), "typeCodeSocr + '-'+name");
						if (list.Count > 0)
						{
							base.SelectSqlData(dataTable, true, " where id in (" + string.Join(",", list.ToArray()) + ")", null, false, 0);
						}
						DataTable dataTable2 = new DataTable("tSchm_ObjList");
						dataTable2.Columns.Add("id", typeof(int));
						dataTable2.Columns.Add("name", typeof(string));
						if (list2.Count > 0)
						{
							base.SelectSqlData(dataTable2, true, " where id in (" + string.Join(",", list2.ToArray()) + ")", null, false, 0);
						}
						if (dataTable.Rows.Count > 0 || dataTable2.Rows.Count > 0)
						{
							foreach (object obj2 in this.dataTable_0.Rows)
							{
								DataRow dataRow2 = (DataRow)obj2;
								if (dataRow2["idSub"] != DBNull.Value)
								{
									DataRow[] array = dataTable.Select("id = " + dataRow2["idSub"].ToString());
									if (array.Length != 0)
									{
										dataRow2["Sub"] = array[0]["FullName"];
									}
								}
								if (dataRow2["idTr"] != DBNull.Value)
								{
									DataRow[] array2 = dataTable2.Select("id = " + dataRow2["idTr"].ToString());
									if (array2.Length != 0)
									{
										dataRow2["TrName"] = array2[0]["Name"];
									}
								}
							}
						}
						this.toolStripStatusLabel_0.Text = "Кол-во трансформаторов: " + this.dataTable_0.Rows.Count.ToString();
						this.toolStripStatusLabel_1.Text = "Суммарная мощность: " + this.dataTable_0.Compute("Sum(Power)", "").ToString();
						this.toolStripStatusLabel_2.Text = "Суммарная нагрузка: " + this.dataTable_0.Compute("Sum(Load)", "").ToString();
						this.method_59(xmlDocument);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, ex.Source);
			}
		}
	}

	private void dataGridViewExcelFilter_1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
	{
	}

	private void dataGridViewExcelFilter_1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
	{
	}

	private void dataGridViewExcelFilter_1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
	{
	}

	private void method_49()
	{
		this.textBox_6.Text = this.dataTable_0.Compute("Sum(Power)", "").ToString();
		this.toolStripStatusLabel_1.Text = "Суммарная мощность: " + this.dataTable_0.Compute("Sum(Power)", "").ToString();
	}

	private void method_50()
	{
		this.textBox_5.Text = this.dataTable_0.Compute("Sum(Load)", "").ToString();
		this.toolStripStatusLabel_2.Text = "Суммарная нагрузка: " + this.dataTable_0.Compute("Sum(Load)", "").ToString();
	}

	private void method_51()
	{
		if (this.dataTable_0.Rows.Count == 0)
		{
			this.textBox_7.Text = string.Empty;
		}
		else
		{
			this.textBox_7.Text = this.dataTable_0.Rows.Count.ToString();
		}
		this.toolStripStatusLabel_0.Text = "Кол-во трансформаторов: " + this.dataTable_0.Rows.Count.ToString();
		this.method_49();
		this.method_50();
	}

	private void button_3_Click(object sender, EventArgs e)
	{
		this.method_51();
		this.method_21();
	}

	private void textBox_7_TextChanged(object sender, EventArgs e)
	{
		this.bool_0 = true;
		this.method_37();
	}

	private void textBox_5_TextChanged(object sender, EventArgs e)
	{
		this.bool_0 = true;
		this.method_37();
	}

	private void textBox_4_TextChanged(object sender, EventArgs e)
	{
		this.label_14.ForeColor = Color.Black;
		this.bool_0 = true;
		this.method_61(this.treeDataGridView_0.Nodes);
		this.method_64();
	}

	private void textBox_8_TextChanged(object sender, EventArgs e)
	{
		this.bool_0 = true;
		this.method_61(this.treeDataGridView_0.Nodes);
		this.method_64();
	}

	private void textBox_10_TextChanged(object sender, EventArgs e)
	{
		this.bool_0 = true;
		this.method_61(this.treeDataGridView_0.Nodes);
		this.method_64();
	}

	private void method_52()
	{
		if (this.class171_0.tJ_Damage.Rows.Count > 0)
		{
			if (this.class171_0.tJ_Damage.Rows[0]["idReqForRepair"] != DBNull.Value)
			{
				DataTable dataTable = base.SelectSqlData("tj_requestForRepair", true, "where id = " + this.class171_0.tJ_Damage.Rows[0]["idReqForRepair"].ToString());
				if (dataTable.Rows.Count > 0)
				{
					this.textBox_11.Text = "Аварийная заявка №" + dataTable.Rows[0]["num"].ToString() + " от " + Convert.ToDateTime(dataTable.Rows[0]["dateCreate"]).ToString("dd.MM.yyyy");
					if (dataTable.Rows[0]["dateFactEnd"] != DBNull.Value)
					{
						this.dateTime_0 = Convert.ToDateTime(dataTable.Rows[0]["dateFactEnd"]);
					}
					this.string_0 = "";
					if (dataTable.Rows[0]["schmObj"] != DBNull.Value)
					{
						this.string_0 = "Объект: " + dataTable.Rows[0]["schmObj"].ToString();
					}
					if (dataTable.Rows[0]["Purpose"] != DBNull.Value)
					{
						if (string.IsNullOrEmpty(this.string_0))
						{
							this.string_0 = "Цель: " + dataTable.Rows[0]["Purpose"].ToString();
						}
						else
						{
							this.string_0 = this.string_0 + "\r\nЦель: " + dataTable.Rows[0]["Purpose"].ToString();
						}
					}
					if (dataTable.Rows[0]["AgreeWith"] != DBNull.Value)
					{
						if (string.IsNullOrEmpty(this.string_0))
						{
							this.string_0 = "Согласовать с: " + dataTable.Rows[0]["AgreeWith"].ToString();
						}
						else
						{
							this.string_0 = this.string_0 + "\r\nСогласовать с: " + dataTable.Rows[0]["AgreeWith"].ToString();
						}
					}
					if (dataTable.Rows[0]["Comment"] != DBNull.Value)
					{
						if (string.IsNullOrEmpty(this.string_0))
						{
							this.string_0 = "Комментарий: " + dataTable.Rows[0]["Comment"].ToString();
						}
						else
						{
							this.string_0 = this.string_0 + "\r\nКомментарий: " + dataTable.Rows[0]["Comment"].ToString();
						}
					}
					this.toolTip_0.ToolTipTitle = this.textBox_11.Text;
					this.toolTip_0.SetToolTip(this.textBox_11, this.string_0);
					this.toolTip_0.SetToolTip(this.button_4, "Открыть документ");
				}
				this.button_2.Enabled = false;
				return;
			}
			this.button_4.Enabled = false;
		}
	}

	private void textBox_11_MouseHover(object sender, EventArgs e)
	{
	}

	private void textBox_11_MouseLeave(object sender, EventArgs e)
	{
	}

	private void button_4_Click(object sender, EventArgs e)
	{
		if (this.class171_0.tJ_Damage.Rows[0]["idReqForRepair"] != DBNull.Value)
		{
			FormJournalRequestForRepairAddEdit formJournalRequestForRepairAddEdit = new FormJournalRequestForRepairAddEdit(Convert.ToInt32(this.class171_0.tJ_Damage.Rows[0]["idReqForRepair"]), -1, eActionRequestRepair.Read, false);
			formJournalRequestForRepairAddEdit.GoToSchema += this.method_53;
			formJournalRequestForRepairAddEdit.SqlSettings = this.SqlSettings;
			formJournalRequestForRepairAddEdit.MdiParent = base.MdiParent;
			formJournalRequestForRepairAddEdit.Show();
		}
	}

	private void method_53(object sender, GoToSchemaEventArgs e)
	{
		this.OnGoToSchema(e);
	}

	private void method_54()
	{
		if (this.treeDataGridView_0.InvokeRequired)
		{
			this.treeDataGridView_0.Invoke(new MethodInvoker(this.method_54));
			return;
		}
		this.treeDataGridView_0.Nodes.Clear();
	}

	private TreeDataGridViewNode method_55(TreeDataGridViewNodeCollection treeDataGridViewNodeCollection_0, params object[] values)
	{
		if (this.treeDataGridView_0.InvokeRequired)
		{
			return (TreeDataGridViewNode)this.treeDataGridView_0.Invoke(new Form81.Delegate74(this.method_55), new object[]
			{
				treeDataGridViewNodeCollection_0,
				values
			});
		}
		return treeDataGridViewNodeCollection_0.Add(values);
	}

	private void method_56(TreeDataGridViewNode treeDataGridViewNode_0, TreeNodeObj treeNodeObj_0)
	{
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
						if (treeDataGridViewNode_0 == null)
						{
							treeDataGridViewNode_0 = this.method_55(this.treeDataGridView_0.Nodes, new object[]
							{
								electricBus.Parent.ToString(),
								electricBus.Parent.Id,
								electricBus.ToString(),
								electricBus.Id,
								electricLine.ToString(),
								electricLine.Id
							});
						}
						else
						{
							treeDataGridViewNode_0 = this.method_55(treeDataGridViewNode_0.Nodes, new object[]
							{
								electricBus.Parent.ToString(),
								electricBus.Parent.Id,
								electricBus.ToString(),
								electricBus.Id,
								electricLine.ToString(),
								electricLine.Id
							});
						}
					}
				}
				foreach (ElectricRelation electricRelation in ((ElectricLine)treeNodeObj_0.Tag).Relations)
				{
					foreach (ElectricObject electricObject in electricRelation.ChildObjects)
					{
						if (electricObject is ElectricSwitch && ((ElectricSwitch)electricObject).TypeSwitch == TypeSwitch.TransformerTool && treeDataGridViewNode_0 != null)
						{
							if (treeDataGridViewNode_0.Cells[this.dataGridViewTextBoxColumn_30.Index].Value != null && !string.IsNullOrEmpty(treeDataGridViewNode_0.Cells[this.dataGridViewTextBoxColumn_30.Index].Value.ToString()))
							{
								treeDataGridViewNode_0 = treeDataGridViewNode_0.Parent.Nodes.Add(new object[]
								{
									treeDataGridViewNode_0.Cells[this.treeGridColumn_0.Index].Value,
									treeDataGridViewNode_0.Cells[this.dataGridViewTextBoxColumn_24.Index].Value,
									treeDataGridViewNode_0.Cells[this.dataGridViewTextBoxColumn_25.Index].Value,
									treeDataGridViewNode_0.Cells[this.dataGridViewTextBoxColumn_26.Index].Value,
									treeDataGridViewNode_0.Cells[this.dataGridViewTextBoxColumn_27.Index].Value,
									treeDataGridViewNode_0.Cells[this.dataGridViewTextBoxColumn_28.Index].Value
								});
							}
							DataRow[] array = this.dataTable_0.Select("idTr = " + electricObject.Id.ToString());
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
								if (treeDataGridViewNode_0.Cells[8].Value != null && !string.IsNullOrEmpty(treeDataGridViewNode_0.Cells[8].Value.ToString()))
								{
									treeDataGridViewNode_0.Cells[8].Value = Convert.ToInt32(treeDataGridViewNode_0.Cells[8].Value) + num;
								}
								else
								{
									treeDataGridViewNode_0.Cells[8].Value = num;
								}
							}
							if (num2 != null)
							{
								if (treeDataGridViewNode_0.Cells[9].Value != null && !string.IsNullOrEmpty(treeDataGridViewNode_0.Cells[9].Value.ToString()))
								{
									treeDataGridViewNode_0.Cells[9].Value = Convert.ToInt32(treeDataGridViewNode_0.Cells[9].Value) + num2;
								}
								else
								{
									treeDataGridViewNode_0.Cells[9].Value = num2;
								}
							}
							if (treeDataGridViewNode_0.Cells[6].Value != null && !string.IsNullOrEmpty(treeDataGridViewNode_0.Cells[6].Value.ToString()))
							{
								DataGridViewCell dataGridViewCell = treeDataGridViewNode_0.Cells[6];
								dataGridViewCell.Value = dataGridViewCell.Value + ";" + electricObject.ToString();
								DataGridViewCell dataGridViewCell2 = treeDataGridViewNode_0.Cells[7];
								dataGridViewCell2.Value = dataGridViewCell2.Value + ";" + electricObject.Id;
							}
							else
							{
								treeDataGridViewNode_0.Cells[6].Value = electricObject.ToString();
								treeDataGridViewNode_0.Cells[7].Value = electricObject.Id;
							}
						}
					}
				}
			}
		}
		foreach (TreeNodeObj treeNodeObj_ in treeNodeObj_0.Nodes)
		{
			this.method_56(treeDataGridViewNode_0, treeNodeObj_);
		}
	}

	private void method_57(XmlNode xmlNode_0)
	{
		if (xmlNode_0 != null && xmlNode_0.OwnerDocument != null)
		{
			XmlDocument ownerDocument = xmlNode_0.OwnerDocument;
			if (xmlNode_0 != null)
			{
				XmlNode xmlNode = ownerDocument.CreateElement("TransTree");
				xmlNode_0.AppendChild(xmlNode);
				foreach (TreeDataGridViewNode treeDataGridViewNode_ in this.treeDataGridView_0.Nodes)
				{
					this.method_58(treeDataGridViewNode_, xmlNode);
				}
			}
			return;
		}
	}

	private void method_58(TreeDataGridViewNode treeDataGridViewNode_0, XmlNode xmlNode_0)
	{
		XmlNode xmlNode = xmlNode_0.OwnerDocument.CreateElement("NodeDgv");
		xmlNode_0.AppendChild(xmlNode);
		foreach (object obj in this.treeDataGridView_0.Columns)
		{
			DataGridViewColumn dataGridViewColumn = (DataGridViewColumn)obj;
			if (!string.IsNullOrEmpty(dataGridViewColumn.DataPropertyName) && treeDataGridViewNode_0.Cells[dataGridViewColumn.Index].Value != null)
			{
				XmlAttribute xmlAttribute = xmlNode_0.OwnerDocument.CreateAttribute(dataGridViewColumn.DataPropertyName);
				xmlAttribute.Value = treeDataGridViewNode_0.Cells[dataGridViewColumn.Index].Value.ToString();
				xmlNode.Attributes.Append(xmlAttribute);
			}
		}
		foreach (TreeDataGridViewNode treeDataGridViewNode_ in treeDataGridViewNode_0.Nodes)
		{
			this.method_58(treeDataGridViewNode_, xmlNode);
		}
	}

	private void method_59(XmlDocument xmlDocument_0)
	{
		XmlNode xmlNode = xmlDocument_0.SelectSingleNode("Doc");
		if (xmlNode == null)
		{
			return;
		}
		XmlNode xmlNode2 = xmlNode.SelectSingleNode("TransOff");
		if (xmlNode2 == null)
		{
			return;
		}
		XmlNode xmlNode3 = xmlNode2.SelectSingleNode("TransTree");
		if (xmlNode3 == null)
		{
			return;
		}
		foreach (object obj in xmlNode3.SelectNodes("NodeDgv"))
		{
			XmlNode xmlNode_ = (XmlNode)obj;
			this.method_60(xmlNode_, this.treeDataGridView_0.Nodes);
		}
	}

	private void method_60(XmlNode xmlNode_0, TreeDataGridViewNodeCollection treeDataGridViewNodeCollection_0)
	{
		TreeDataGridViewNode treeDataGridViewNode = treeDataGridViewNodeCollection_0.Add(new object[0]);
		foreach (object obj in this.treeDataGridView_0.Columns)
		{
			DataGridViewColumn dataGridViewColumn = (DataGridViewColumn)obj;
			if (!string.IsNullOrEmpty(dataGridViewColumn.DataPropertyName))
			{
				XmlAttribute xmlAttribute = xmlNode_0.Attributes[dataGridViewColumn.DataPropertyName];
				if (xmlAttribute != null && !string.IsNullOrEmpty(xmlAttribute.Value))
				{
					treeDataGridViewNode.Cells[dataGridViewColumn.Index].Value = xmlAttribute.Value;
				}
			}
		}
		foreach (object obj2 in xmlNode_0.SelectNodes("NodeDgv"))
		{
			XmlNode xmlNode_ = (XmlNode)obj2;
			this.method_60(xmlNode_, treeDataGridViewNode.Nodes);
		}
	}

	private void treeDataGridView_0_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
	{
		if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
		{
			if (this.treeDataGridView_0[this.dataGridViewTextBoxColumn_29.Index, e.RowIndex].Value != null && !string.IsNullOrEmpty(this.treeDataGridView_0[this.dataGridViewTextBoxColumn_29.Index, e.RowIndex].Value.ToString()))
			{
				e.CellStyle.BackColor = Color.LightGray;
			}
			if (this.treeDataGridView_0[this.dataGridViewTextBoxColumn_33.Index, e.RowIndex].Value != null && !string.IsNullOrEmpty(this.treeDataGridView_0[this.dataGridViewTextBoxColumn_33.Index, e.RowIndex].Value.ToString()))
			{
				e.CellStyle.ForeColor = Color.Blue;
			}
		}
	}

	private void treeDataGridView_0_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
	{
		if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Button == MouseButtons.Right && !this.method_1() && !this.checkBox_0.Checked)
		{
			this.contextMenuStrip_0.Show(Cursor.Position);
		}
	}

	private void toolStripMenuItem_0_Click(object sender, EventArgs e)
	{
		FormChooseDateOn formChooseDateOn = new FormChooseDateOn();
		if (formChooseDateOn.ShowDialog() == DialogResult.OK)
		{
			foreach (object obj in this.treeDataGridView_0.SelectedRows)
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
				dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_33.Index].Value = formChooseDateOn.DateOn.ToString("dd.MM.yyyy HH:mm");
				if (formChooseDateOn.method_0())
				{
					TreeDataGridViewNode nodeForRow = this.treeDataGridView_0.GetNodeForRow(dataGridViewRow);
					this.method_62(nodeForRow, new DateTime?(formChooseDateOn.DateOn));
				}
			}
			this.method_61(this.treeDataGridView_0.Nodes);
			this.method_64();
			this.bool_0 = true;
		}
	}

	private void toolStripMenuItem_1_Click(object sender, EventArgs e)
	{
		foreach (object obj in this.treeDataGridView_0.SelectedRows)
		{
			DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
			dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_33.Index].Value = null;
			TreeDataGridViewNode nodeForRow = this.treeDataGridView_0.GetNodeForRow(dataGridViewRow);
			this.method_62(nodeForRow, null);
		}
		this.method_61(this.treeDataGridView_0.Nodes);
		this.method_64();
		this.bool_0 = true;
	}

	private decimal method_61(TreeDataGridViewNodeCollection treeDataGridViewNodeCollection_0)
	{
		decimal num = 0m;
		foreach (TreeDataGridViewNode treeDataGridViewNode in treeDataGridViewNodeCollection_0)
		{
			decimal num2 = this.method_61(treeDataGridViewNode.Nodes);
			treeDataGridViewNode.Cells[this.dataGridViewTextBoxColumn_34.Index].Value = num2;
			num += num2;
			if (!string.IsNullOrEmpty(this.textBox_4.Text) && treeDataGridViewNode.Cells[this.dataGridViewTextBoxColumn_32.Index].Value != null && treeDataGridViewNode.Cells[this.dataGridViewTextBoxColumn_33.Index].Value != null)
			{
				decimal d = Convert.ToDecimal((Convert.ToDateTime(treeDataGridViewNode.Cells[this.dataGridViewTextBoxColumn_33.Index].Value) - this.dateTimePicker_1.Value.AddSeconds((double)(-(double)this.dateTimePicker_1.Value.Second))).TotalHours);
				decimal num3 = Convert.ToDecimal((Convert.ToDecimal(Math.Sqrt(3.0)) * Convert.ToDecimal(treeDataGridViewNode.Cells[this.dataGridViewTextBoxColumn_32.Index].Value) * Convert.ToDecimal(this.textBox_4.Text) * d * Convert.ToDecimal(this.textBox_8.Text) * Convert.ToDecimal(this.textBox_10.Text)).ToString("0.##"));
				treeDataGridViewNode.Cells[this.dataGridViewTextBoxColumn_34.Index].Value = num3;
				num += num3;
			}
		}
		return num;
	}

	private void method_62(TreeDataGridViewNode treeDataGridViewNode_0, DateTime? nullable_0)
	{
		if (treeDataGridViewNode_0 != null)
		{
			if (nullable_0 == null)
			{
				treeDataGridViewNode_0.Cells[this.dataGridViewTextBoxColumn_33.Index].Value = null;
			}
			else
			{
				treeDataGridViewNode_0.Cells[this.dataGridViewTextBoxColumn_33.Index].Value = nullable_0.Value.ToString("dd.MM.yyyy HH:mm");
			}
			foreach (TreeDataGridViewNode treeDataGridViewNode_ in treeDataGridViewNode_0.Nodes)
			{
				this.method_62(treeDataGridViewNode_, nullable_0);
			}
		}
	}

	private void method_63(TreeDataGridViewNodeCollection treeDataGridViewNodeCollection_0)
	{
		foreach (TreeDataGridViewNode treeDataGridViewNode in treeDataGridViewNodeCollection_0)
		{
			this.method_63(treeDataGridViewNode.Nodes);
			if (treeDataGridViewNode.Cells[this.dataGridViewTextBoxColumn_33.Index].Value != null && !string.IsNullOrEmpty(treeDataGridViewNode.Cells[this.dataGridViewTextBoxColumn_33.Index].Value.ToString()) && treeDataGridViewNode.Cells[this.dataGridViewTextBoxColumn_30.Index].Value != null && !string.IsNullOrEmpty(treeDataGridViewNode.Cells[this.dataGridViewTextBoxColumn_30.Index].Value.ToString()))
			{
				DateTime dateTime = Convert.ToDateTime(treeDataGridViewNode.Cells[this.dataGridViewTextBoxColumn_33.Index].Value);
				decimal num = 0m;
				if (treeDataGridViewNode.Cells[this.dataGridViewTextBoxColumn_34.Index].Value != null && !string.IsNullOrEmpty(treeDataGridViewNode.Cells[this.dataGridViewTextBoxColumn_34.Index].Value.ToString()) && treeDataGridViewNode.Cells[this.dataGridViewTextBoxColumn_32.Index].Value != null && !string.IsNullOrEmpty(treeDataGridViewNode.Cells[this.dataGridViewTextBoxColumn_32.Index].Value.ToString()))
				{
					num = Convert.ToDecimal(treeDataGridViewNode.Cells[this.dataGridViewTextBoxColumn_34.Index].Value);
				}
				DataRow[] array = this.class176_0.Select("dateOn = '" + dateTime.ToString("dd.MM.yyyy HH:mm") + "'");
				if (array.Length != 0)
				{
					array[0]["CountSchmObj"] = Convert.ToInt32(array[0]["CountSchmObj"]) + 1;
					array[0]["noAdmissionKWT"] = Convert.ToDecimal(array[0]["noAdmissionKWT"]) + num;
				}
				else
				{
					DataRow dataRow = this.class176_0.NewRow();
					dataRow["IdDamage"] = this.method_0();
					dataRow["dateOn"] = dateTime;
					dataRow["CountSchmObj"] = 1;
					dataRow["noAdmissionKWT"] = num;
					this.class176_0.Rows.Add(dataRow);
				}
			}
		}
	}

	private void method_64()
	{
		if (this.radioButton_1.Checked)
		{
			this.dataGridViewExcelFilter_0.DataSource = this.class171_0.tJ_DamageOn;
			if (!this.method_1() && !this.checkBox_0.Checked)
			{
				this.dataGridViewExcelFilter_0.ReadOnly = false;
				this.dataGridViewExcelFilter_0.AllowUserToDeleteRows = true;
			}
		}
		else
		{
			this.class176_0 = new Class171.Class176();
			this.method_63(this.treeDataGridView_0.Nodes);
			if (this.class176_0.Rows.Count > 0)
			{
				OrderedEnumerableRowCollection<Class171.Class201> source = from row in this.class176_0.AsEnumerable<Class171.Class201>()
				orderby row.Field("DateOn")
				select row;
				this.dataGridViewExcelFilter_0.DataSource = source.CopyToDataTable<Class171.Class201>();
			}
			else
			{
				this.dataGridViewExcelFilter_0.DataSource = this.class176_0;
			}
			this.dataGridViewExcelFilter_0.ReadOnly = true;
			this.dataGridViewExcelFilter_0.AllowUserToDeleteRows = false;
		}
		this.method_37();
		this.bool_0 = true;
	}

	private void radioButton_1_CheckedChanged(object sender, EventArgs e)
	{
		this.method_64();
	}

	private void toolStripButton_2_CheckedChanged(object sender, EventArgs e)
	{
		if (this.toolStripButton_2.Checked)
		{
			this.toolStripButton_2.ToolTipText = "Не использовать в бюллетене 8.1";
			this.toolStripButton_2.Image = Resources.not81;
		}
		else
		{
			this.toolStripButton_2.ToolTipText = "Использовать в бюллетене 8.1";
			this.toolStripButton_2.Image = Resources.in81;
		}
		this.bool_0 = true;
	}

	private void toolStripDropDownButton_0_Click(object sender, EventArgs e)
	{
		this.method_65();
		this.method_68();
	}

	private void method_65()
	{
		NumericUpDown numericUpDown = this.numericUpDown_4;
		NumericUpDown numericUpDown2 = this.numericUpDown_5;
		decimal value = 0m;
		numericUpDown2.Value = value;
		numericUpDown.Value = value;
		this.numericUpDown_0.Value = 0m;
		if (this.dataTable_1.Rows.Count == 0)
		{
			NumericUpDown numericUpDown3 = this.numericUpDown_3;
			NumericUpDown numericUpDown4 = this.numericUpDown_6;
			NumericUpDown numericUpDown5 = this.numericUpDown_2;
			NumericUpDown numericUpDown6 = this.numericUpDown_1;
			NumericUpDown numericUpDown7 = this.numericUpDown_0;
			decimal value2 = 0m;
			numericUpDown7.Value = value2;
			numericUpDown3.Value = (numericUpDown4.Value = (numericUpDown5.Value = (numericUpDown6.Value = value2)));
			return;
		}
		string text = "";
		foreach (object obj in this.dataTable_1.Rows)
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
		DataTable dataTable = new SqlDataCommand(this.SqlSettings).SelectSqlData(string.Format("select ao.id,\r\n                                        case when a.TypeAbn = 231 then -1 -- сетевая организация\r\n                                        else case when a.typeAbn = 206 and r.category is null then 493 -- если у физика нет категории - ставим ему третью\r\n                                        else case when category is null then 493 else r.category end end end as category\r\n                                     from tAbnObj ao \r\n\t                                    left join tAbn a on a.id = ao.idAbn\r\n\t                                    left join tAbnObjReg r on r.id = (select top 1 id from tAbnObjREg \r\n\t\t\t\t\t\t\t                where idAbnObj = ao.id\r\n\t\t\t\t\t\t\t                order by datechange desc)\r\n                                        left join tPoint p on p.idAbnObj = ao.id and p.dateBegin <= '{0}' and \r\n                                                                (p.dateEnd  >= '{0}' or p.dateEnd is null)\r\n\t                                    /*left join tPointReg pReg on pReg.id = (select top 1 id from tPointReg\r\n\t\t\t\t\t\t\t\t\t\t                                      where idPoint = p.id \r\n\t\t\t\t\t\t\t\t\t\t\t                        and dateBegin <= '{0}' and \r\n                                                                    (dateEnd  >= '{0}' or dateEnd is null)\r\n\t\t\t\t\t\t\t\t\t                                order by dateBegin desc)*/\r\n                                     where ao.id in ({1}) \r\n                                        and p.id is not null --and pREg.id is not null", this.dateTimePicker_1.Value.ToString("yyyyMMdd"), text));
		this.numericUpDown_3.Value = Convert.ToInt32(dataTable.Compute("count(id)", "category in (491,494)"));
		this.numericUpDown_6.Value = Convert.ToInt32(dataTable.Compute("count(id)", "category = 492"));
		this.numericUpDown_2.Value = Convert.ToInt32(dataTable.Compute("count(id)", "category = 493"));
		this.numericUpDown_1.Value = Convert.ToInt32(dataTable.Compute("count(id)", "category = -1"));
	}

	private void method_66(XmlNode xmlNode_0)
	{
		try
		{
			if (xmlNode_0 != null && xmlNode_0.OwnerDocument != null)
			{
				XmlDocument ownerDocument = xmlNode_0.OwnerDocument;
				XmlNode xmlNode = ownerDocument.CreateElement("CountPoint");
				xmlNode_0.AppendChild(xmlNode);
				XmlAttribute xmlAttribute = ownerDocument.CreateAttribute("countPointCat1");
				xmlAttribute.Value = this.numericUpDown_3.Value.ToString();
				xmlNode.Attributes.Append(xmlAttribute);
				xmlAttribute = ownerDocument.CreateAttribute("countPointCat1Full");
				xmlAttribute.Value = this.numericUpDown_4.Value.ToString();
				xmlNode.Attributes.Append(xmlAttribute);
				xmlAttribute = ownerDocument.CreateAttribute("countPointCat2");
				xmlAttribute.Value = this.numericUpDown_6.Value.ToString();
				xmlNode.Attributes.Append(xmlAttribute);
				xmlAttribute = ownerDocument.CreateAttribute("countPointCat2Full");
				xmlAttribute.Value = this.numericUpDown_5.Value.ToString();
				xmlNode.Attributes.Append(xmlAttribute);
				xmlAttribute = ownerDocument.CreateAttribute("countPointCat3");
				xmlAttribute.Value = this.numericUpDown_2.Value.ToString();
				xmlNode.Attributes.Append(xmlAttribute);
				xmlAttribute = ownerDocument.CreateAttribute("countPointEE");
				xmlAttribute.Value = this.numericUpDown_1.Value.ToString();
				xmlNode.Attributes.Append(xmlAttribute);
				xmlAttribute = ownerDocument.CreateAttribute("countPointSource");
				xmlAttribute.Value = this.numericUpDown_0.Value.ToString();
				xmlNode.Attributes.Append(xmlAttribute);
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void method_67()
	{
		if (this.class171_0.tJ_Damage.Rows.Count > 0 && this.class171_0.tJ_Damage.Rows[0]["CommentXml"] != DBNull.Value)
		{
			try
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.LoadXml(this.class171_0.tJ_Damage.Rows[0]["CommentXml"].ToString());
				XmlNode xmlNode = xmlDocument.SelectSingleNode("Doc");
				if (xmlNode != null)
				{
					XmlNode xmlNode2 = xmlNode.SelectSingleNode("AbnOff");
					if (xmlNode2 != null)
					{
						XmlNode xmlNode3 = xmlNode2.SelectSingleNode("CountPoint");
						if (xmlNode3 != null)
						{
							XmlAttribute xmlAttribute = xmlNode3.Attributes["countPointCat1"];
							if (xmlAttribute != null && !string.IsNullOrEmpty(xmlAttribute.Value))
							{
								this.numericUpDown_3.Value = Convert.ToInt32(xmlAttribute.Value);
							}
							xmlAttribute = xmlNode3.Attributes["countPointCat1Full"];
							if (xmlAttribute != null && !string.IsNullOrEmpty(xmlAttribute.Value))
							{
								this.numericUpDown_4.Value = Convert.ToInt32(xmlAttribute.Value);
							}
							xmlAttribute = xmlNode3.Attributes["countPointCat2"];
							if (xmlAttribute != null && !string.IsNullOrEmpty(xmlAttribute.Value))
							{
								this.numericUpDown_6.Value = Convert.ToInt32(xmlAttribute.Value);
							}
							xmlAttribute = xmlNode3.Attributes["countPointCat2Full"];
							if (xmlAttribute != null && !string.IsNullOrEmpty(xmlAttribute.Value))
							{
								this.numericUpDown_5.Value = Convert.ToInt32(xmlAttribute.Value);
							}
							xmlAttribute = xmlNode3.Attributes["countPointCat3"];
							if (xmlAttribute != null && !string.IsNullOrEmpty(xmlAttribute.Value))
							{
								this.numericUpDown_2.Value = Convert.ToInt32(xmlAttribute.Value);
							}
							xmlAttribute = xmlNode3.Attributes["countPointEE"];
							if (xmlAttribute != null && !string.IsNullOrEmpty(xmlAttribute.Value))
							{
								this.numericUpDown_1.Value = Convert.ToInt32(xmlAttribute.Value);
							}
							xmlAttribute = xmlNode3.Attributes["countPointSource"];
							if (xmlAttribute != null && !string.IsNullOrEmpty(xmlAttribute.Value))
							{
								this.numericUpDown_0.Value = Convert.ToInt32(xmlAttribute.Value);
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

	private void numericUpDown_6_ValueChanged(object sender, EventArgs e)
	{
		this.bool_0 = true;
		this.toolStripStatusLabel_3.Text = "Количество точек поставки: " + (this.numericUpDown_3.Value + this.numericUpDown_4.Value + this.numericUpDown_6.Value + this.numericUpDown_5.Value + this.numericUpDown_2.Value + this.numericUpDown_1.Value + this.numericUpDown_0.Value).ToString();
	}

	private void method_68()
	{
		NumericUpDown numericUpDown = this.numericUpDown_14;
		NumericUpDown numericUpDown2 = this.numericUpDown_16;
		decimal value = 0m;
		numericUpDown2.Value = value;
		numericUpDown.Value = value;
		this.numericUpDown_7.Value = 0m;
		if (this.dataTable_1.Rows.Count == 0)
		{
			NumericUpDown numericUpDown3 = this.numericUpDown_13;
			NumericUpDown numericUpDown4 = this.numericUpDown_15;
			NumericUpDown numericUpDown5 = this.numericUpDown_9;
			NumericUpDown numericUpDown6 = this.numericUpDown_8;
			NumericUpDown numericUpDown7 = this.numericUpDown_7;
			decimal value2 = 0m;
			numericUpDown7.Value = value2;
			numericUpDown3.Value = (numericUpDown4.Value = (numericUpDown5.Value = (numericUpDown6.Value = value2)));
			NumericUpDown numericUpDown8 = this.numericUpDown_12;
			NumericUpDown numericUpDown9 = this.numericUpDown_11;
			NumericUpDown numericUpDown10 = this.numericUpDown_10;
			decimal value3 = 0m;
			numericUpDown10.Value = value3;
			numericUpDown8.Value = (numericUpDown9.Value = value3);
			return;
		}
		string text = "";
		foreach (object obj in this.dataTable_1.Rows)
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
		this.numericUpDown_13.Value = Convert.ToInt32(dataTable.Compute("count(id)", "category in (491,494)"));
		this.numericUpDown_15.Value = Convert.ToInt32(dataTable.Compute("count(id)", "category = 492"));
		this.numericUpDown_9.Value = Convert.ToInt32(dataTable.Compute("count(id)", "category = 493"));
		this.numericUpDown_8.Value = Convert.ToInt32(dataTable.Compute("count(id)", "category = -1"));
		dataTable = sqlDataCommand.SelectSqlData("select ao.id,\r\n                                         case when a.TypeAbn = 206 or r.PowerSEt is null then 15\r\n                                        \telse r.PowerSEt end PowerSEt\r\n                                     from tAbnObj ao \r\n\t                                    left join tAbn a on a.id = ao.idAbn\r\n\t                                    left join tAbnObjReg r on r.id = (select top 1 id from tAbnObjREg \r\n\t\t\t\t\t\t\t                where idAbnObj = ao.id\r\n\t\t\t\t\t\t\t                order by datechange desc)\r\n                                     where ao.id in (" + text + ")");
		this.numericUpDown_12.Value = Convert.ToInt32(dataTable.Compute("count(id)", "PowerSet <= 150"));
		this.numericUpDown_11.Value = Convert.ToInt32(dataTable.Compute("count(id)", "PowerSet > 150 and PowerSet <= 670"));
		this.numericUpDown_10.Value = Convert.ToInt32(dataTable.Compute("count(id)", "PowerSet > 670"));
	}

	private void method_69(XmlNode xmlNode_0)
	{
		try
		{
			if (xmlNode_0 != null && xmlNode_0.OwnerDocument != null)
			{
				XmlDocument ownerDocument = xmlNode_0.OwnerDocument;
				XmlNode xmlNode = ownerDocument.CreateElement("CountAbnObj");
				xmlNode_0.AppendChild(xmlNode);
				XmlAttribute xmlAttribute = ownerDocument.CreateAttribute("countAbnObjCat1");
				xmlAttribute.Value = this.numericUpDown_13.Value.ToString();
				xmlNode.Attributes.Append(xmlAttribute);
				xmlAttribute = ownerDocument.CreateAttribute("countAbnObjCat1Full");
				xmlAttribute.Value = this.numericUpDown_14.Value.ToString();
				xmlNode.Attributes.Append(xmlAttribute);
				xmlAttribute = ownerDocument.CreateAttribute("countAbnObjCat2");
				xmlAttribute.Value = this.numericUpDown_15.Value.ToString();
				xmlNode.Attributes.Append(xmlAttribute);
				xmlAttribute = ownerDocument.CreateAttribute("countAbnObjCat2Full");
				xmlAttribute.Value = this.numericUpDown_16.Value.ToString();
				xmlNode.Attributes.Append(xmlAttribute);
				xmlAttribute = ownerDocument.CreateAttribute("countAbnObjCat3");
				xmlAttribute.Value = this.numericUpDown_9.Value.ToString();
				xmlNode.Attributes.Append(xmlAttribute);
				xmlAttribute = ownerDocument.CreateAttribute("countAbnObjEE");
				xmlAttribute.Value = this.numericUpDown_8.Value.ToString();
				xmlNode.Attributes.Append(xmlAttribute);
				xmlAttribute = ownerDocument.CreateAttribute("countAbnObjSource");
				xmlAttribute.Value = this.numericUpDown_7.Value.ToString();
				xmlNode.Attributes.Append(xmlAttribute);
				xmlAttribute = ownerDocument.CreateAttribute("countAbnObj150");
				xmlAttribute.Value = this.numericUpDown_12.Value.ToString();
				xmlNode.Attributes.Append(xmlAttribute);
				xmlAttribute = ownerDocument.CreateAttribute("countAbnObj150670");
				xmlAttribute.Value = this.numericUpDown_11.Value.ToString();
				xmlNode.Attributes.Append(xmlAttribute);
				xmlAttribute = ownerDocument.CreateAttribute("countAbnObj670");
				xmlAttribute.Value = this.numericUpDown_10.Value.ToString();
				xmlNode.Attributes.Append(xmlAttribute);
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void method_70()
	{
		if (this.class171_0.tJ_Damage.Rows.Count > 0 && this.class171_0.tJ_Damage.Rows[0]["CommentXml"] != DBNull.Value)
		{
			try
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.LoadXml(this.class171_0.tJ_Damage.Rows[0]["CommentXml"].ToString());
				XmlNode xmlNode = xmlDocument.SelectSingleNode("Doc");
				if (xmlNode != null)
				{
					XmlNode xmlNode2 = xmlNode.SelectSingleNode("AbnOff");
					if (xmlNode2 != null)
					{
						XmlNode xmlNode3 = xmlNode2.SelectSingleNode("CountAbnObj");
						if (xmlNode3 != null)
						{
							XmlAttribute xmlAttribute = xmlNode3.Attributes["countAbnObjCat1"];
							if (xmlAttribute != null && !string.IsNullOrEmpty(xmlAttribute.Value))
							{
								this.numericUpDown_13.Value = Convert.ToInt32(xmlAttribute.Value);
							}
							xmlAttribute = xmlNode3.Attributes["countAbnObjCat1Full"];
							if (xmlAttribute != null && !string.IsNullOrEmpty(xmlAttribute.Value))
							{
								this.numericUpDown_14.Value = Convert.ToInt32(xmlAttribute.Value);
							}
							xmlAttribute = xmlNode3.Attributes["countAbnObjCat2"];
							if (xmlAttribute != null && !string.IsNullOrEmpty(xmlAttribute.Value))
							{
								this.numericUpDown_15.Value = Convert.ToInt32(xmlAttribute.Value);
							}
							xmlAttribute = xmlNode3.Attributes["countAbnObjCat2Full"];
							if (xmlAttribute != null && !string.IsNullOrEmpty(xmlAttribute.Value))
							{
								this.numericUpDown_16.Value = Convert.ToInt32(xmlAttribute.Value);
							}
							xmlAttribute = xmlNode3.Attributes["countAbnObjCat3"];
							if (xmlAttribute != null && !string.IsNullOrEmpty(xmlAttribute.Value))
							{
								this.numericUpDown_9.Value = Convert.ToInt32(xmlAttribute.Value);
							}
							xmlAttribute = xmlNode3.Attributes["countAbnObjEE"];
							if (xmlAttribute != null && !string.IsNullOrEmpty(xmlAttribute.Value))
							{
								this.numericUpDown_8.Value = Convert.ToInt32(xmlAttribute.Value);
							}
							xmlAttribute = xmlNode3.Attributes["countAbnObjSource"];
							if (xmlAttribute != null && !string.IsNullOrEmpty(xmlAttribute.Value))
							{
								this.numericUpDown_7.Value = Convert.ToInt32(xmlAttribute.Value);
							}
							xmlAttribute = xmlNode3.Attributes["countAbnObj150"];
							if (xmlAttribute != null && !string.IsNullOrEmpty(xmlAttribute.Value))
							{
								this.numericUpDown_12.Value = Convert.ToInt32(xmlAttribute.Value);
							}
							xmlAttribute = xmlNode3.Attributes["countAbnObj150670"];
							if (xmlAttribute != null && !string.IsNullOrEmpty(xmlAttribute.Value))
							{
								this.numericUpDown_11.Value = Convert.ToInt32(xmlAttribute.Value);
							}
							xmlAttribute = xmlNode3.Attributes["countAbnObj670"];
							if (xmlAttribute != null && !string.IsNullOrEmpty(xmlAttribute.Value))
							{
								this.numericUpDown_10.Value = Convert.ToInt32(xmlAttribute.Value);
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

	private void numericUpDown_16_ValueChanged(object sender, EventArgs e)
	{
		this.bool_0 = true;
		this.toolStripStatusLabel_5.Text = "Количество объектов: " + (this.numericUpDown_13.Value + this.numericUpDown_14.Value + this.numericUpDown_15.Value + this.numericUpDown_16.Value + this.numericUpDown_9.Value + this.numericUpDown_8.Value + this.numericUpDown_7.Value).ToString();
	}

	private void comboBoxReadOnly_0_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	private void method_71()
	{
		this.icontainer_0 = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form81));
		DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
		this.tabControl_0 = new TabControl();
		this.tabPage_0 = new TabPage();
		this.toolStrip_2 = new ToolStrip();
		this.toolStripButton_2 = new ToolStripButton();
		this.splitContainer_0 = new SplitContainer();
		this.comboBox_1 = new ComboBox();
		this.class171_0 = new Class171();
		this.label_28 = new Label();
		this.comboBox_0 = new ComboBox();
		this.label_27 = new Label();
		this.label_26 = new Label();
		this.textBox_10 = new TextBox();
		this.button_3 = new Button();
		this.textBox_8 = new TextBox();
		this.label_18 = new Label();
		this.label_14 = new Label();
		this.textBox_4 = new TextBox();
		this.label_15 = new Label();
		this.textBox_5 = new TextBox();
		this.textBox_6 = new TextBox();
		this.label_16 = new Label();
		this.textBox_7 = new TextBox();
		this.label_17 = new Label();
		this.comboBoxReadOnly_5 = new ComboBoxReadOnly();
		this.label_10 = new Label();
		this.groupBox_0 = new GroupBox();
		this.button_4 = new Button();
		this.textBox_11 = new TextBox();
		this.label_29 = new Label();
		this.label_21 = new Label();
		this.label_22 = new Label();
		this.dataGridView_0 = new DataGridView();
		this.dataGridViewComboBoxColumn_0 = new DataGridViewComboBoxColumn();
		this.dataGridViewTextBoxColumn_3 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_4 = new DataGridViewTextBoxColumn();
		this.dataGridViewButtonColumn_0 = new DataGridViewButtonColumn();
		this.dataGridViewComboBoxColumn_1 = new DataGridViewComboBoxColumn();
		this.dataGridViewComboBoxColumn_2 = new DataGridViewComboBoxColumn();
		this.dataGridViewComboBoxColumn_3 = new DataGridViewComboBoxColumn();
		this.richTextBox_0 = new RichTextBox();
		this.comboBoxReadOnly_4 = new ComboBoxReadOnly();
		this.label_9 = new Label();
		this.button_2 = new Button();
		this.label_6 = new Label();
		this.textBox_2 = new TextBox();
		this.groupBox_1 = new GroupBox();
		this.groupBox_2 = new GroupBox();
		this.richTextBox_2 = new RichTextBox();
		this.label_23 = new Label();
		this.richTextBox_3 = new RichTextBox();
		this.label_24 = new Label();
		this.checkBox_1 = new CheckBox();
		this.label_25 = new Label();
		this.checkBox_2 = new CheckBox();
		this.comboBoxReadOnly_6 = new ComboBoxReadOnly();
		this.splitContainer_1 = new SplitContainer();
		this.radioButton_0 = new RadioButton();
		this.radioButton_1 = new RadioButton();
		this.label_19 = new Label();
		this.label_13 = new Label();
		this.textBox_9 = new TextBox();
		this.textBox_3 = new TextBox();
		this.dataGridViewExcelFilter_0 = new DataGridViewExcelFilter();
		this.dataGridViewTextBoxColumn_18 = new DataGridViewTextBoxColumn();
		this.dataGridViewFilterDateTimePickerColumn_0 = new DataGridViewFilterDateTimePickerColumn();
		this.dataGridViewTextBoxColumn_20 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_19 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_21 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_22 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_23 = new DataGridViewTextBoxColumn();
		this.label_11 = new Label();
		this.label_12 = new Label();
		this.checkBox_0 = new CheckBox();
		this.nullableDateTimePicker_0 = new NullableDateTimePicker();
		this.label_7 = new Label();
		this.richTextBox_1 = new RichTextBox();
		this.comboBoxReadOnly_2 = new ComboBoxReadOnly();
		this.label_8 = new Label();
		this.comboBoxReadOnly_3 = new ComboBoxReadOnly();
		this.comboBoxReadOnly_0 = new ComboBoxReadOnly();
		this.label_0 = new Label();
		this.label_1 = new Label();
		this.comboBoxReadOnly_1 = new ComboBoxReadOnly();
		this.dateTimePicker_0 = new DateTimePicker();
		this.label_2 = new Label();
		this.label_3 = new Label();
		this.textBox_0 = new TextBox();
		this.label_4 = new Label();
		this.dateTimePicker_1 = new DateTimePicker();
		this.label_5 = new Label();
		this.textBox_1 = new TextBox();
		this.tabPage_1 = new TabPage();
		this.splitContainer_2 = new SplitContainer();
		this.dataGridViewExcelFilter_1 = new DataGridViewExcelFilter();
		this.dataGridViewTextBoxColumn_12 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_13 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_14 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_15 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_16 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_17 = new DataGridViewTextBoxColumn();
		this.bindingSource_0 = new BindingSource(this.icontainer_0);
		this.dataSet_0 = new DataSet();
		this.dataTable_0 = new DataTable();
		this.dataColumn_0 = new DataColumn();
		this.dataColumn_1 = new DataColumn();
		this.dataColumn_2 = new DataColumn();
		this.dataColumn_3 = new DataColumn();
		this.dataColumn_4 = new DataColumn();
		this.dataColumn_5 = new DataColumn();
		this.dataTable_1 = new DataTable();
		this.dataColumn_6 = new DataColumn();
		this.dataColumn_7 = new DataColumn();
		this.dataColumn_8 = new DataColumn();
		this.dataColumn_9 = new DataColumn();
		this.dataColumn_10 = new DataColumn();
		this.dataColumn_11 = new DataColumn();
		this.dataColumn_12 = new DataColumn();
		this.dataColumn_13 = new DataColumn();
		this.dataColumn_14 = new DataColumn();
		this.dataColumn_15 = new DataColumn();
		this.treeDataGridView_0 = new TreeDataGridView();
		this.treeGridColumn_0 = new TreeGridColumn();
		this.dataGridViewTextBoxColumn_24 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_25 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_26 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_27 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_28 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_29 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_30 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_31 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_32 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_33 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_34 = new DataGridViewTextBoxColumn();
		this.statusStrip_0 = new StatusStrip();
		this.toolStripStatusLabel_0 = new ToolStripStatusLabel();
		this.toolStripStatusLabel_1 = new ToolStripStatusLabel();
		this.toolStripStatusLabel_2 = new ToolStripStatusLabel();
		this.toolStrip_0 = new ToolStrip();
		this.toolStripButton_0 = new ToolStripButton();
		this.tabPage_2 = new TabPage();
		this.splitContainer_3 = new SplitContainer();
		this.dataGridViewExcelFilter_2 = new DataGridViewExcelFilter();
		this.dataGridViewFilterTextBoxColumn_0 = new DataGridViewFilterTextBoxColumn();
		this.dataGridViewTextBoxColumn_35 = new DataGridViewTextBoxColumn();
		this.dataGridViewFilterTextBoxColumn_1 = new DataGridViewFilterTextBoxColumn();
		this.dataGridViewFilterComboBoxColumn_0 = new DataGridViewFilterComboBoxColumn();
		this.dataGridViewTextBoxColumn_36 = new DataGridViewTextBoxColumn();
		this.dataGridViewFilterTextBoxColumn_2 = new DataGridViewFilterTextBoxColumn();
		this.dataGridViewFilterTextBoxColumn_3 = new DataGridViewFilterTextBoxColumn();
		this.dataGridViewFilterTextBoxColumn_4 = new DataGridViewFilterTextBoxColumn();
		this.dataGridViewFilterTextBoxColumn_5 = new DataGridViewFilterTextBoxColumn();
		this.dataGridViewFilterTextBoxColumn_6 = new DataGridViewFilterTextBoxColumn();
		this.bindingSource_1 = new BindingSource(this.icontainer_0);
		this.toolStrip_1 = new ToolStrip();
		this.toolStripButton_1 = new ToolStripButton();
		this.splitContainer_4 = new SplitContainer();
		this.numericUpDown_0 = new NumericUpDown();
		this.numericUpDown_1 = new NumericUpDown();
		this.numericUpDown_2 = new NumericUpDown();
		this.groupBox_3 = new GroupBox();
		this.numericUpDown_3 = new NumericUpDown();
		this.numericUpDown_4 = new NumericUpDown();
		this.label_30 = new Label();
		this.label_31 = new Label();
		this.label_32 = new Label();
		this.label_33 = new Label();
		this.label_34 = new Label();
		this.groupBox_4 = new GroupBox();
		this.numericUpDown_5 = new NumericUpDown();
		this.numericUpDown_6 = new NumericUpDown();
		this.label_35 = new Label();
		this.label_36 = new Label();
		this.label_37 = new Label();
		this.numericUpDown_7 = new NumericUpDown();
		this.numericUpDown_8 = new NumericUpDown();
		this.numericUpDown_9 = new NumericUpDown();
		this.label_38 = new Label();
		this.groupBox_5 = new GroupBox();
		this.numericUpDown_10 = new NumericUpDown();
		this.numericUpDown_11 = new NumericUpDown();
		this.numericUpDown_12 = new NumericUpDown();
		this.label_39 = new Label();
		this.label_40 = new Label();
		this.label_41 = new Label();
		this.groupBox_6 = new GroupBox();
		this.numericUpDown_13 = new NumericUpDown();
		this.numericUpDown_14 = new NumericUpDown();
		this.label_42 = new Label();
		this.label_43 = new Label();
		this.label_44 = new Label();
		this.label_45 = new Label();
		this.label_46 = new Label();
		this.groupBox_7 = new GroupBox();
		this.numericUpDown_15 = new NumericUpDown();
		this.numericUpDown_16 = new NumericUpDown();
		this.label_47 = new Label();
		this.label_48 = new Label();
		this.statusStrip_1 = new StatusStrip();
		this.toolStripDropDownButton_0 = new ToolStripDropDownButton();
		this.toolStripStatusLabel_3 = new ToolStripStatusLabel();
		this.toolStripStatusLabel_5 = new ToolStripStatusLabel();
		this.toolStripStatusLabel_4 = new ToolStripStatusLabel();
		this.button_0 = new Button();
		this.button_1 = new Button();
		this.backgroundWorker_0 = new BackgroundWorker();
		this.label_20 = new Label();
		this.progressBar_0 = new ProgressBar();
		this.dataGridViewComboBoxColumn_4 = new DataGridViewComboBoxColumn();
		this.dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
		this.dataGridViewButtonColumn_1 = new DataGridViewButtonColumn();
		this.dataGridViewComboBoxColumn_5 = new DataGridViewComboBoxColumn();
		this.dataGridViewComboBoxColumn_6 = new DataGridViewComboBoxColumn();
		this.dataGridViewComboBoxColumn_7 = new DataGridViewComboBoxColumn();
		this.dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_5 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_6 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_7 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_8 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_9 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_10 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_11 = new DataGridViewTextBoxColumn();
		this.toolTip_0 = new ToolTip(this.icontainer_0);
		this.contextMenuStrip_0 = new ContextMenuStrip(this.icontainer_0);
		this.toolStripMenuItem_0 = new ToolStripMenuItem();
		this.toolStripMenuItem_1 = new ToolStripMenuItem();
		this.tabControl_0.SuspendLayout();
		this.tabPage_0.SuspendLayout();
		this.toolStrip_2.SuspendLayout();
		this.splitContainer_0.Panel1.SuspendLayout();
		this.splitContainer_0.Panel2.SuspendLayout();
		this.splitContainer_0.SuspendLayout();
		((ISupportInitialize)this.class171_0).BeginInit();
		this.groupBox_0.SuspendLayout();
		((ISupportInitialize)this.dataGridView_0).BeginInit();
		this.groupBox_1.SuspendLayout();
		this.groupBox_2.SuspendLayout();
		this.splitContainer_1.Panel1.SuspendLayout();
		this.splitContainer_1.Panel2.SuspendLayout();
		this.splitContainer_1.SuspendLayout();
		((ISupportInitialize)this.dataGridViewExcelFilter_0).BeginInit();
		this.tabPage_1.SuspendLayout();
		this.splitContainer_2.Panel1.SuspendLayout();
		this.splitContainer_2.Panel2.SuspendLayout();
		this.splitContainer_2.SuspendLayout();
		((ISupportInitialize)this.dataGridViewExcelFilter_1).BeginInit();
		((ISupportInitialize)this.bindingSource_0).BeginInit();
		((ISupportInitialize)this.dataSet_0).BeginInit();
		((ISupportInitialize)this.dataTable_0).BeginInit();
		((ISupportInitialize)this.dataTable_1).BeginInit();
		((ISupportInitialize)this.treeDataGridView_0).BeginInit();
		this.statusStrip_0.SuspendLayout();
		this.toolStrip_0.SuspendLayout();
		this.tabPage_2.SuspendLayout();
		this.splitContainer_3.Panel1.SuspendLayout();
		this.splitContainer_3.Panel2.SuspendLayout();
		this.splitContainer_3.SuspendLayout();
		((ISupportInitialize)this.dataGridViewExcelFilter_2).BeginInit();
		((ISupportInitialize)this.bindingSource_1).BeginInit();
		this.toolStrip_1.SuspendLayout();
		this.splitContainer_4.Panel1.SuspendLayout();
		this.splitContainer_4.Panel2.SuspendLayout();
		this.splitContainer_4.SuspendLayout();
		((ISupportInitialize)this.numericUpDown_0).BeginInit();
		((ISupportInitialize)this.numericUpDown_1).BeginInit();
		((ISupportInitialize)this.numericUpDown_2).BeginInit();
		this.groupBox_3.SuspendLayout();
		((ISupportInitialize)this.numericUpDown_3).BeginInit();
		((ISupportInitialize)this.numericUpDown_4).BeginInit();
		this.groupBox_4.SuspendLayout();
		((ISupportInitialize)this.numericUpDown_5).BeginInit();
		((ISupportInitialize)this.numericUpDown_6).BeginInit();
		((ISupportInitialize)this.numericUpDown_7).BeginInit();
		((ISupportInitialize)this.numericUpDown_8).BeginInit();
		((ISupportInitialize)this.numericUpDown_9).BeginInit();
		this.groupBox_5.SuspendLayout();
		((ISupportInitialize)this.numericUpDown_10).BeginInit();
		((ISupportInitialize)this.numericUpDown_11).BeginInit();
		((ISupportInitialize)this.numericUpDown_12).BeginInit();
		this.groupBox_6.SuspendLayout();
		((ISupportInitialize)this.numericUpDown_13).BeginInit();
		((ISupportInitialize)this.numericUpDown_14).BeginInit();
		this.groupBox_7.SuspendLayout();
		((ISupportInitialize)this.numericUpDown_15).BeginInit();
		((ISupportInitialize)this.numericUpDown_16).BeginInit();
		this.statusStrip_1.SuspendLayout();
		this.contextMenuStrip_0.SuspendLayout();
		base.SuspendLayout();
		this.tabControl_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.tabControl_0.Controls.Add(this.tabPage_0);
		this.tabControl_0.Controls.Add(this.tabPage_1);
		this.tabControl_0.Controls.Add(this.tabPage_2);
		this.tabControl_0.Location = new Point(0, 0);
		this.tabControl_0.Name = "tabControlMain";
		this.tabControl_0.SelectedIndex = 0;
		this.tabControl_0.Size = new Size(969, 645);
		this.tabControl_0.TabIndex = 0;
		this.tabPage_0.Controls.Add(this.toolStrip_2);
		this.tabPage_0.Controls.Add(this.splitContainer_0);
		this.tabPage_0.Controls.Add(this.comboBoxReadOnly_0);
		this.tabPage_0.Controls.Add(this.label_0);
		this.tabPage_0.Controls.Add(this.label_1);
		this.tabPage_0.Controls.Add(this.comboBoxReadOnly_1);
		this.tabPage_0.Controls.Add(this.dateTimePicker_0);
		this.tabPage_0.Controls.Add(this.label_2);
		this.tabPage_0.Controls.Add(this.label_3);
		this.tabPage_0.Controls.Add(this.textBox_0);
		this.tabPage_0.Controls.Add(this.label_4);
		this.tabPage_0.Controls.Add(this.dateTimePicker_1);
		this.tabPage_0.Controls.Add(this.label_5);
		this.tabPage_0.Controls.Add(this.textBox_1);
		this.tabPage_0.Location = new Point(4, 22);
		this.tabPage_0.Name = "tabPageGeneral";
		this.tabPage_0.Padding = new Padding(3);
		this.tabPage_0.Size = new Size(961, 619);
		this.tabPage_0.TabIndex = 0;
		this.tabPage_0.Text = "Общий";
		this.tabPage_0.UseVisualStyleBackColor = true;
		this.toolStrip_2.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.toolStrip_2.Dock = DockStyle.None;
		this.toolStrip_2.GripStyle = ToolStripGripStyle.Hidden;
		this.toolStrip_2.ImageScalingSize = new Size(24, 24);
		this.toolStrip_2.Items.AddRange(new ToolStripItem[]
		{
			this.toolStripButton_2
		});
		this.toolStrip_2.Location = new Point(927, 3);
		this.toolStrip_2.Name = "toolStrip81";
		this.toolStrip_2.Size = new Size(31, 31);
		this.toolStrip_2.TabIndex = 19;
		this.toolStrip_2.Text = "toolStrip1";
		this.toolStripButton_2.Checked = true;
		this.toolStripButton_2.CheckOnClick = true;
		this.toolStripButton_2.CheckState = CheckState.Checked;
		this.toolStripButton_2.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_2.Image = Resources.not81;
		this.toolStripButton_2.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_2.Name = "toolBtn81";
		this.toolStripButton_2.Size = new Size(28, 28);
		this.toolStripButton_2.Text = "Использовать в бюллетене 8.1";
		this.toolStripButton_2.CheckedChanged += this.toolStripButton_2_CheckedChanged;
		this.splitContainer_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.splitContainer_0.Location = new Point(3, 60);
		this.splitContainer_0.Name = "splitContainerMainGeneral";
		this.splitContainer_0.Panel1.Controls.Add(this.comboBox_1);
		this.splitContainer_0.Panel1.Controls.Add(this.label_28);
		this.splitContainer_0.Panel1.Controls.Add(this.comboBox_0);
		this.splitContainer_0.Panel1.Controls.Add(this.label_27);
		this.splitContainer_0.Panel1.Controls.Add(this.label_26);
		this.splitContainer_0.Panel1.Controls.Add(this.textBox_10);
		this.splitContainer_0.Panel1.Controls.Add(this.button_3);
		this.splitContainer_0.Panel1.Controls.Add(this.textBox_8);
		this.splitContainer_0.Panel1.Controls.Add(this.label_18);
		this.splitContainer_0.Panel1.Controls.Add(this.label_14);
		this.splitContainer_0.Panel1.Controls.Add(this.textBox_4);
		this.splitContainer_0.Panel1.Controls.Add(this.label_15);
		this.splitContainer_0.Panel1.Controls.Add(this.textBox_5);
		this.splitContainer_0.Panel1.Controls.Add(this.textBox_6);
		this.splitContainer_0.Panel1.Controls.Add(this.label_16);
		this.splitContainer_0.Panel1.Controls.Add(this.textBox_7);
		this.splitContainer_0.Panel1.Controls.Add(this.label_17);
		this.splitContainer_0.Panel1.Controls.Add(this.comboBoxReadOnly_5);
		this.splitContainer_0.Panel1.Controls.Add(this.label_10);
		this.splitContainer_0.Panel1.Controls.Add(this.groupBox_0);
		this.splitContainer_0.Panel2.Controls.Add(this.groupBox_1);
		this.splitContainer_0.Size = new Size(958, 556);
		this.splitContainer_0.SplitterDistance = 507;
		this.splitContainer_0.TabIndex = 18;
		this.comboBox_1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.comboBox_1.DataBindings.Add(new Binding("SelectedValue", this.class171_0, "tJ_DamageHV.APR", true));
		this.comboBox_1.FormattingEnabled = true;
		this.comboBox_1.Location = new Point(277, 530);
		this.comboBox_1.Name = "cmbAPV";
		this.comboBox_1.Size = new Size(74, 21);
		this.comboBox_1.TabIndex = 35;
		this.class171_0.DataSetName = "DataSetDamage";
		this.class171_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		this.label_28.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.label_28.AutoSize = true;
		this.label_28.Location = new Point(178, 535);
		this.label_28.Name = "label12";
		this.label_28.Size = new Size(29, 13);
		this.label_28.TabIndex = 34;
		this.label_28.Text = "АПВ";
		this.comboBox_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.comboBox_0.DataBindings.Add(new Binding("SelectedValue", this.class171_0, "tJ_DamageHV.AVR", true));
		this.comboBox_0.FormattingEnabled = true;
		this.comboBox_0.Location = new Point(115, 530);
		this.comboBox_0.Name = "cmbAVR";
		this.comboBox_0.Size = new Size(55, 21);
		this.comboBox_0.TabIndex = 33;
		this.label_27.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.label_27.AutoSize = true;
		this.label_27.Location = new Point(10, 535);
		this.label_27.Name = "label8";
		this.label_27.Size = new Size(28, 13);
		this.label_27.TabIndex = 32;
		this.label_27.Text = "АВР";
		this.label_26.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.label_26.Location = new Point(357, 479);
		this.label_26.Name = "label7";
		this.label_26.Size = new Size(68, 26);
		this.label_26.TabIndex = 31;
		this.label_26.Text = "Коэфф. сезонности";
		this.textBox_10.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.textBox_10.BackColor = SystemColors.Window;
		this.textBox_10.DataBindings.Add(new Binding("Text", this.class171_0, "tJ_DamageHV.CoefSeason", true));
		this.textBox_10.Location = new Point(431, 479);
		this.textBox_10.Name = "txtCoefSeason";
		this.textBox_10.Size = new Size(65, 20);
		this.textBox_10.TabIndex = 30;
		this.textBox_10.TextChanged += this.textBox_10_TextChanged;
		this.button_3.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.button_3.Location = new Point(430, 530);
		this.button_3.Name = "buttonLoadTextBoxSum";
		this.button_3.Size = new Size(75, 23);
		this.button_3.TabIndex = 29;
		this.button_3.Text = "Заполнить";
		this.button_3.UseVisualStyleBackColor = true;
		this.button_3.Click += this.button_3_Click;
		this.textBox_8.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.textBox_8.BackColor = SystemColors.Window;
		this.textBox_8.DataBindings.Add(new Binding("Text", this.class171_0, "tJ_DamageHV.CoefFI", true));
		this.textBox_8.Location = new Point(431, 505);
		this.textBox_8.Name = "txtCosFi";
		this.textBox_8.Size = new Size(65, 20);
		this.textBox_8.TabIndex = 28;
		this.textBox_8.TextChanged += this.textBox_8_TextChanged;
		this.label_18.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.label_18.AutoSize = true;
		this.label_18.Location = new Point(357, 511);
		this.label_18.Name = "label16";
		this.label_18.Size = new Size(32, 13);
		this.label_18.TabIndex = 27;
		this.label_18.Text = "cos fi";
		this.label_14.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.label_14.AutoSize = true;
		this.label_14.Location = new Point(178, 511);
		this.label_14.Name = "labelPowerV";
		this.label_14.Size = new Size(90, 13);
		this.label_14.TabIndex = 24;
		this.label_14.Text = "Напряжение, кВ";
		this.textBox_4.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.textBox_4.BackColor = SystemColors.Window;
		this.textBox_4.DataBindings.Add(new Binding("Text", this.class171_0, "tJ_DamageHV.PowerV", true, DataSourceUpdateMode.OnPropertyChanged));
		this.textBox_4.Location = new Point(277, 508);
		this.textBox_4.Name = "txtV";
		this.textBox_4.Size = new Size(74, 20);
		this.textBox_4.TabIndex = 23;
		this.textBox_4.TextChanged += this.textBox_4_TextChanged;
		this.label_15.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.label_15.AutoSize = true;
		this.label_15.Location = new Point(10, 511);
		this.label_15.Name = "label11";
		this.label_15.Size = new Size(68, 13);
		this.label_15.TabIndex = 22;
		this.label_15.Text = "Нагрузка, А";
		this.textBox_5.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.textBox_5.BackColor = SystemColors.Window;
		this.textBox_5.DataBindings.Add(new Binding("Text", this.class171_0, "tJ_DamageHV.PowerA", true, DataSourceUpdateMode.OnPropertyChanged));
		this.textBox_5.Location = new Point(115, 508);
		this.textBox_5.Name = "txtA";
		this.textBox_5.Size = new Size(55, 20);
		this.textBox_5.TabIndex = 20;
		this.textBox_5.TextChanged += this.textBox_5_TextChanged;
		this.textBox_6.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.textBox_6.BackColor = SystemColors.Window;
		this.textBox_6.DataBindings.Add(new Binding("Text", this.class171_0, "tJ_DamageHV.ConnectedPower", true, DataSourceUpdateMode.OnPropertyChanged));
		this.textBox_6.Location = new Point(277, 479);
		this.textBox_6.Name = "txtKWT";
		this.textBox_6.ReadOnly = true;
		this.textBox_6.Size = new Size(74, 20);
		this.textBox_6.TabIndex = 19;
		this.textBox_6.TextChanged += this.richTextBox_1_TextChanged;
		this.label_16.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.label_16.Location = new Point(178, 476);
		this.label_16.Name = "label10";
		this.label_16.Size = new Size(108, 29);
		this.label_16.TabIndex = 18;
		this.label_16.Text = "Присоединенная мощность, кВт";
		this.textBox_7.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.textBox_7.BackColor = SystemColors.Window;
		this.textBox_7.DataBindings.Add(new Binding("Text", this.class171_0, "tJ_DamageHV.CountSchmObj", true, DataSourceUpdateMode.OnPropertyChanged));
		this.textBox_7.Location = new Point(115, 479);
		this.textBox_7.Name = "txtCountSchmObj";
		this.textBox_7.Size = new Size(55, 20);
		this.textBox_7.TabIndex = 17;
		this.textBox_7.TextChanged += this.textBox_7_TextChanged;
		this.label_17.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.label_17.Location = new Point(10, 476);
		this.label_17.Name = "label9";
		this.label_17.Size = new Size(108, 29);
		this.label_17.TabIndex = 16;
		this.label_17.Text = "Количество электроустановок";
		this.comboBoxReadOnly_5.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.comboBoxReadOnly_5.DataBindings.Add(new Binding("SelectedValue", this.class171_0, "tJ_DamageHV.idTypeRZA", true));
		this.comboBoxReadOnly_5.FormattingEnabled = true;
		this.comboBoxReadOnly_5.Location = new Point(202, 449);
		this.comboBoxReadOnly_5.Name = "cmbTypeRZA";
		this.comboBoxReadOnly_5.ReadOnlyBackColor = SystemColors.Window;
		this.comboBoxReadOnly_5.ReadOnlyForeColor = SystemColors.WindowText;
		this.comboBoxReadOnly_5.Size = new Size(296, 21);
		this.comboBoxReadOnly_5.TabIndex = 15;
		this.comboBoxReadOnly_5.SelectedIndexChanged += this.comboBoxReadOnly_5_SelectedIndexChanged;
		this.label_10.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.label_10.AutoSize = true;
		this.label_10.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.label_10.Location = new Point(10, 452);
		this.label_10.Name = "labelTypeRZA";
		this.label_10.Size = new Size(186, 13);
		this.label_10.TabIndex = 14;
		this.label_10.Text = "Тип работы релейной защиты";
		this.groupBox_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.groupBox_0.Controls.Add(this.button_4);
		this.groupBox_0.Controls.Add(this.textBox_11);
		this.groupBox_0.Controls.Add(this.label_29);
		this.groupBox_0.Controls.Add(this.label_21);
		this.groupBox_0.Controls.Add(this.label_22);
		this.groupBox_0.Controls.Add(this.dataGridView_0);
		this.groupBox_0.Controls.Add(this.richTextBox_0);
		this.groupBox_0.Controls.Add(this.comboBoxReadOnly_4);
		this.groupBox_0.Controls.Add(this.label_9);
		this.groupBox_0.Controls.Add(this.button_2);
		this.groupBox_0.Controls.Add(this.label_6);
		this.groupBox_0.Controls.Add(this.textBox_2);
		this.groupBox_0.Location = new Point(0, 0);
		this.groupBox_0.Name = "groupBoxDefectData";
		this.groupBox_0.Size = new Size(504, 443);
		this.groupBox_0.TabIndex = 13;
		this.groupBox_0.TabStop = false;
		this.groupBox_0.Text = "Исходные данные";
		this.button_4.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.button_4.Location = new Point(469, 15);
		this.button_4.Name = "btnRequestForRepair";
		this.button_4.Size = new Size(27, 20);
		this.button_4.TabIndex = 12;
		this.button_4.Text = "...";
		this.button_4.UseVisualStyleBackColor = true;
		this.button_4.Click += this.button_4_Click;
		this.textBox_11.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_11.BackColor = SystemColors.Window;
		this.textBox_11.Location = new Point(141, 16);
		this.textBox_11.Name = "txtDocParent";
		this.textBox_11.ReadOnly = true;
		this.textBox_11.Size = new Size(329, 20);
		this.textBox_11.TabIndex = 11;
		this.textBox_11.MouseLeave += this.textBox_11_MouseLeave;
		this.textBox_11.MouseHover += this.textBox_11_MouseHover;
		this.label_29.AutoSize = true;
		this.label_29.Location = new Point(10, 19);
		this.label_29.Name = "label13";
		this.label_29.Size = new Size(115, 13);
		this.label_29.TabIndex = 10;
		this.label_29.Text = "Документ-основание";
		this.label_21.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.label_21.AutoSize = true;
		this.label_21.Location = new Point(5, 318);
		this.label_21.Name = "label17";
		this.label_21.Size = new Size(110, 13);
		this.label_21.TabIndex = 9;
		this.label_21.Text = "Место повреждения";
		this.label_22.AutoSize = true;
		this.label_22.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.label_22.Location = new Point(10, 79);
		this.label_22.Name = "labelDamageCharacter";
		this.label_22.Size = new Size(146, 13);
		this.label_22.TabIndex = 8;
		this.label_22.Text = "Характер повреждения";
		this.dataGridView_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.dataGridView_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView_0.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewComboBoxColumn_0,
			this.dataGridViewTextBoxColumn_3,
			this.dataGridViewTextBoxColumn_4,
			this.dataGridViewButtonColumn_0,
			this.dataGridViewComboBoxColumn_1,
			this.dataGridViewComboBoxColumn_2,
			this.dataGridViewComboBoxColumn_3
		});
		this.dataGridView_0.EditMode = DataGridViewEditMode.EditOnEnter;
		this.dataGridView_0.Location = new Point(0, 95);
		this.dataGridView_0.Name = "dgvCharacterDamage";
		this.dataGridView_0.Size = new Size(504, 220);
		this.dataGridView_0.TabIndex = 7;
		this.dataGridView_0.CellContentClick += this.dataGridView_0_CellContentClick;
		this.dataGridView_0.CurrentCellDirtyStateChanged += this.dataGridView_0_CurrentCellDirtyStateChanged;
		this.dataGridView_0.DataError += this.dataGridView_0_DataError;
		this.dataGridView_0.MouseClick += this.dataGridView_0_MouseClick;
		this.dataGridViewComboBoxColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewComboBoxColumn_0.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
		this.dataGridViewComboBoxColumn_0.FillWeight = 50f;
		this.dataGridViewComboBoxColumn_0.HeaderText = "Тип объекта";
		this.dataGridViewComboBoxColumn_0.Name = "Column1";
		this.dataGridViewComboBoxColumn_0.Resizable = DataGridViewTriState.True;
		this.dataGridViewComboBoxColumn_0.SortMode = DataGridViewColumnSortMode.Programmatic;
		this.dataGridViewTextBoxColumn_3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_3.HeaderText = "Объект";
		this.dataGridViewTextBoxColumn_3.Name = "ColumnSchmObj";
		this.dataGridViewTextBoxColumn_4.HeaderText = "idSchmObj";
		this.dataGridViewTextBoxColumn_4.Name = "columnIdSchmObj";
		this.dataGridViewTextBoxColumn_4.Visible = false;
		this.dataGridViewButtonColumn_0.FillWeight = 40f;
		this.dataGridViewButtonColumn_0.HeaderText = "";
		this.dataGridViewButtonColumn_0.Name = "ColumnBtn";
		this.dataGridViewButtonColumn_0.Text = "...";
		this.dataGridViewButtonColumn_0.ToolTipText = "Выбрать объект";
		this.dataGridViewButtonColumn_0.Width = 25;
		this.dataGridViewComboBoxColumn_1.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
		this.dataGridViewComboBoxColumn_1.HeaderText = "Участок";
		this.dataGridViewComboBoxColumn_1.Name = "ColumnCabSection";
		this.dataGridViewComboBoxColumn_1.Resizable = DataGridViewTriState.True;
		this.dataGridViewComboBoxColumn_1.SortMode = DataGridViewColumnSortMode.Programmatic;
		this.dataGridViewComboBoxColumn_1.Width = 60;
		this.dataGridViewComboBoxColumn_2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewComboBoxColumn_2.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
		this.dataGridViewComboBoxColumn_2.HeaderText = "Повреждение";
		this.dataGridViewComboBoxColumn_2.Name = "Column2";
		this.dataGridViewComboBoxColumn_2.Resizable = DataGridViewTriState.True;
		this.dataGridViewComboBoxColumn_2.SortMode = DataGridViewColumnSortMode.Automatic;
		this.dataGridViewComboBoxColumn_3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewComboBoxColumn_3.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
		this.dataGridViewComboBoxColumn_3.HeaderText = "Уточнение";
		this.dataGridViewComboBoxColumn_3.Name = "Column3";
		this.dataGridViewComboBoxColumn_3.Resizable = DataGridViewTriState.True;
		this.dataGridViewComboBoxColumn_3.SortMode = DataGridViewColumnSortMode.Automatic;
		this.richTextBox_0.AcceptsTab = true;
		this.richTextBox_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.richTextBox_0.BackColor = SystemColors.Window;
		this.richTextBox_0.DataBindings.Add(new Binding("Text", this.class171_0, "tJ_Damage.DefectLocation", true));
		this.richTextBox_0.Location = new Point(0, 334);
		this.richTextBox_0.Name = "txtLocation";
		this.richTextBox_0.Size = new Size(504, 66);
		this.richTextBox_0.TabIndex = 0;
		this.richTextBox_0.Text = "";
		this.comboBoxReadOnly_4.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.comboBoxReadOnly_4.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBoxReadOnly_4.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBoxReadOnly_4.DataBindings.Add(new Binding("SelectedValue", this.class171_0, "tJ_Damage.idReason", true));
		this.comboBoxReadOnly_4.FormattingEnabled = true;
		this.comboBoxReadOnly_4.Location = new Point(115, 406);
		this.comboBoxReadOnly_4.Name = "cmbReason";
		this.comboBoxReadOnly_4.ReadOnlyBackColor = SystemColors.Window;
		this.comboBoxReadOnly_4.ReadOnlyForeColor = SystemColors.WindowText;
		this.comboBoxReadOnly_4.Size = new Size(382, 21);
		this.comboBoxReadOnly_4.TabIndex = 5;
		this.comboBoxReadOnly_4.SelectedIndexChanged += this.comboBoxReadOnly_4_SelectedIndexChanged;
		this.label_9.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.label_9.AutoSize = true;
		this.label_9.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.label_9.Location = new Point(10, 409);
		this.label_9.Name = "labelReason";
		this.label_9.Size = new Size(99, 13);
		this.label_9.TabIndex = 4;
		this.label_9.Text = "Неисправность";
		this.button_2.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.button_2.Location = new Point(469, 45);
		this.button_2.Name = "btnChoiceSchmObj";
		this.button_2.Size = new Size(27, 20);
		this.button_2.TabIndex = 2;
		this.button_2.Text = "...";
		this.button_2.UseVisualStyleBackColor = true;
		this.button_2.Click += this.button_2_Click;
		this.label_6.AutoSize = true;
		this.label_6.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.label_6.Location = new Point(10, 49);
		this.label_6.Name = "labelSchmObj";
		this.label_6.Size = new Size(125, 13);
		this.label_6.TabIndex = 1;
		this.label_6.Text = "Подстанция\\ячейка";
		this.textBox_2.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_2.BackColor = SystemColors.Window;
		this.textBox_2.Location = new Point(141, 45);
		this.textBox_2.Name = "txtSchmObj";
		this.textBox_2.ReadOnly = true;
		this.textBox_2.Size = new Size(329, 20);
		this.textBox_2.TabIndex = 0;
		this.textBox_2.TextChanged += this.textBox_2_TextChanged;
		this.groupBox_1.Controls.Add(this.groupBox_2);
		this.groupBox_1.Controls.Add(this.splitContainer_1);
		this.groupBox_1.Controls.Add(this.label_8);
		this.groupBox_1.Controls.Add(this.comboBoxReadOnly_3);
		this.groupBox_1.Dock = DockStyle.Fill;
		this.groupBox_1.Location = new Point(0, 0);
		this.groupBox_1.Name = "groupBoxResult";
		this.groupBox_1.Size = new Size(447, 556);
		this.groupBox_1.TabIndex = 14;
		this.groupBox_1.TabStop = false;
		this.groupBox_1.Text = "Результат (принятые меры)";
		this.groupBox_2.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.groupBox_2.Controls.Add(this.richTextBox_2);
		this.groupBox_2.Controls.Add(this.label_23);
		this.groupBox_2.Controls.Add(this.richTextBox_3);
		this.groupBox_2.Controls.Add(this.label_24);
		this.groupBox_2.Controls.Add(this.checkBox_1);
		this.groupBox_2.Controls.Add(this.label_25);
		this.groupBox_2.Controls.Add(this.checkBox_2);
		this.groupBox_2.Controls.Add(this.comboBoxReadOnly_6);
		this.groupBox_2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.groupBox_2.Location = new Point(0, 361);
		this.groupBox_2.Name = "groupBoxDefect";
		this.groupBox_2.Size = new Size(447, 195);
		this.groupBox_2.TabIndex = 19;
		this.groupBox_2.TabStop = false;
		this.groupBox_2.Text = "Журнал дефектов";
		this.richTextBox_2.AcceptsTab = true;
		this.richTextBox_2.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.richTextBox_2.BackColor = SystemColors.Window;
		this.richTextBox_2.DataBindings.Add(new Binding("Text", this.class171_0, "tJ_Damage.LaboratoryInstruction", true));
		this.richTextBox_2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.richTextBox_2.Location = new Point(81, 144);
		this.richTextBox_2.Name = "txtLaboratoryInstruction";
		this.richTextBox_2.Size = new Size(360, 48);
		this.richTextBox_2.TabIndex = 22;
		this.richTextBox_2.Text = "";
		this.richTextBox_2.Visible = false;
		this.label_23.AutoSize = true;
		this.label_23.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.label_23.Location = new Point(6, 145);
		this.label_23.Name = "labelLaboratoryInstruction";
		this.label_23.Size = new Size(57, 13);
		this.label_23.TabIndex = 21;
		this.label_23.Text = "Указания";
		this.label_23.Visible = false;
		this.richTextBox_3.AcceptsTab = true;
		this.richTextBox_3.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.richTextBox_3.BackColor = SystemColors.Window;
		this.richTextBox_3.DataBindings.Add(new Binding("Text", this.class171_0, "tJ_Damage.DivisionInstruction", true));
		this.richTextBox_3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.richTextBox_3.Location = new Point(81, 61);
		this.richTextBox_3.Name = "txtDivisionInstruction";
		this.richTextBox_3.Size = new Size(360, 58);
		this.richTextBox_3.TabIndex = 20;
		this.richTextBox_3.Text = "";
		this.richTextBox_3.Visible = false;
		this.label_24.AutoSize = true;
		this.label_24.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.label_24.Location = new Point(6, 61);
		this.label_24.Name = "labelDivisionInstruction";
		this.label_24.Size = new Size(57, 13);
		this.label_24.TabIndex = 19;
		this.label_24.Text = "Указания";
		this.label_24.Visible = false;
		this.checkBox_1.AutoSize = true;
		this.checkBox_1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.checkBox_1.Location = new Point(6, 25);
		this.checkBox_1.Name = "chbDefect";
		this.checkBox_1.Size = new Size(66, 17);
		this.checkBox_1.TabIndex = 18;
		this.checkBox_1.Text = "Дефект";
		this.checkBox_1.UseVisualStyleBackColor = true;
		this.checkBox_1.CheckedChanged += this.checkBox_1_CheckedChanged;
		this.label_25.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.label_25.Location = new Point(78, 19);
		this.label_25.Name = "labelDivisionApply";
		this.label_25.Size = new Size(96, 27);
		this.label_25.TabIndex = 15;
		this.label_25.Text = "Подразделение исполнитель";
		this.label_25.Visible = false;
		this.checkBox_2.AutoSize = true;
		this.checkBox_2.DataBindings.Add(new Binding("Checked", this.class171_0, "tJ_Damage.isLaboratory", true, DataSourceUpdateMode.OnPropertyChanged));
		this.checkBox_2.Enabled = false;
		this.checkBox_2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.checkBox_2.Location = new Point(6, 121);
		this.checkBox_2.Name = "checkBoxLaboratory";
		this.checkBox_2.Size = new Size(191, 17);
		this.checkBox_2.TabIndex = 17;
		this.checkBox_2.Text = "Производственная лаборатория";
		this.checkBox_2.UseVisualStyleBackColor = true;
		this.checkBox_2.Visible = false;
		this.checkBox_2.CheckedChanged += this.checkBox_2_CheckedChanged;
		this.comboBoxReadOnly_6.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.comboBoxReadOnly_6.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBoxReadOnly_6.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBoxReadOnly_6.BackColor = SystemColors.Control;
		this.comboBoxReadOnly_6.DataBindings.Add(new Binding("SelectedValue", this.class171_0, "tJ_Damage.idDivisionApply", true, DataSourceUpdateMode.OnPropertyChanged));
		this.comboBoxReadOnly_6.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBoxReadOnly_6.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.comboBoxReadOnly_6.ForeColor = SystemColors.WindowText;
		this.comboBoxReadOnly_6.FormattingEnabled = true;
		this.comboBoxReadOnly_6.Location = new Point(180, 21);
		this.comboBoxReadOnly_6.Name = "cmbDivisionApply";
		this.comboBoxReadOnly_6.ReadOnly = true;
		this.comboBoxReadOnly_6.ReadOnlyBackColor = SystemColors.Window;
		this.comboBoxReadOnly_6.ReadOnlyForeColor = SystemColors.WindowText;
		this.comboBoxReadOnly_6.Size = new Size(261, 21);
		this.comboBoxReadOnly_6.TabIndex = 16;
		this.comboBoxReadOnly_6.TabStop = false;
		this.comboBoxReadOnly_6.Visible = false;
		this.comboBoxReadOnly_6.SelectedIndexChanged += this.comboBoxReadOnly_6_SelectedIndexChanged;
		this.splitContainer_1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.splitContainer_1.Location = new Point(0, 38);
		this.splitContainer_1.Name = "splitContainerWorkApplyGeneral";
		this.splitContainer_1.Orientation = Orientation.Horizontal;
		this.splitContainer_1.Panel1.Controls.Add(this.radioButton_0);
		this.splitContainer_1.Panel1.Controls.Add(this.radioButton_1);
		this.splitContainer_1.Panel1.Controls.Add(this.label_19);
		this.splitContainer_1.Panel1.Controls.Add(this.label_13);
		this.splitContainer_1.Panel1.Controls.Add(this.textBox_9);
		this.splitContainer_1.Panel1.Controls.Add(this.textBox_3);
		this.splitContainer_1.Panel1.Controls.Add(this.dataGridViewExcelFilter_0);
		this.splitContainer_1.Panel1.Controls.Add(this.label_11);
		this.splitContainer_1.Panel2.Controls.Add(this.label_12);
		this.splitContainer_1.Panel2.Controls.Add(this.checkBox_0);
		this.splitContainer_1.Panel2.Controls.Add(this.nullableDateTimePicker_0);
		this.splitContainer_1.Panel2.Controls.Add(this.label_7);
		this.splitContainer_1.Panel2.Controls.Add(this.richTextBox_1);
		this.splitContainer_1.Panel2.Controls.Add(this.comboBoxReadOnly_2);
		this.splitContainer_1.Size = new Size(447, 323);
		this.splitContainer_1.SplitterDistance = 192;
		this.splitContainer_1.TabIndex = 8;
		this.radioButton_0.AutoSize = true;
		this.radioButton_0.Location = new Point(223, 5);
		this.radioButton_0.Name = "rbOnFact";
		this.radioButton_0.Size = new Size(70, 17);
		this.radioButton_0.TabIndex = 28;
		this.radioButton_0.Text = "по факту";
		this.radioButton_0.UseVisualStyleBackColor = true;
		this.radioButton_1.AutoSize = true;
		this.radioButton_1.Checked = true;
		this.radioButton_1.Location = new Point(75, 5);
		this.radioButton_1.Name = "rbOnAverage";
		this.radioButton_1.Size = new Size(89, 17);
		this.radioButton_1.TabIndex = 27;
		this.radioButton_1.TabStop = true;
		this.radioButton_1.Text = "по среднему";
		this.radioButton_1.UseVisualStyleBackColor = true;
		this.radioButton_1.CheckedChanged += this.radioButton_1_CheckedChanged;
		this.label_19.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.label_19.AutoSize = true;
		this.label_19.Location = new Point(10, 140);
		this.label_19.Name = "label15";
		this.label_19.Size = new Size(213, 13);
		this.label_19.TabIndex = 4;
		this.label_19.Text = "Количество невключенных эл.установок";
		this.label_13.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.label_13.AutoSize = true;
		this.label_13.Location = new Point(10, 166);
		this.label_13.Name = "labelSumNoAdmissionKWT";
		this.label_13.Size = new Size(151, 13);
		this.label_13.TabIndex = 26;
		this.label_13.Text = "Недопуск эл. энергии, кВт*ч";
		this.textBox_9.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.textBox_9.BackColor = SystemColors.Window;
		this.textBox_9.DataBindings.Add(new Binding("Text", this.class171_0, "tJ_DamageHV.CountSchmObjOff", true, DataSourceUpdateMode.OnPropertyChanged));
		this.textBox_9.Location = new Point(256, 137);
		this.textBox_9.Name = "txtCountSchmObjOff";
		this.textBox_9.ReadOnly = true;
		this.textBox_9.Size = new Size(100, 20);
		this.textBox_9.TabIndex = 2;
		this.textBox_3.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.textBox_3.BackColor = SystemColors.Window;
		this.textBox_3.DataBindings.Add(new Binding("Text", this.class171_0, "tJ_DamageHV.NoAdmissionKWT", true, DataSourceUpdateMode.OnPropertyChanged));
		this.textBox_3.Location = new Point(256, 163);
		this.textBox_3.Name = "txtNoKWT";
		this.textBox_3.ReadOnly = true;
		this.textBox_3.Size = new Size(100, 20);
		this.textBox_3.TabIndex = 25;
		this.dataGridViewExcelFilter_0.AllowUserToOrderColumns = true;
		this.dataGridViewExcelFilter_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.dataGridViewExcelFilter_0.AutoGenerateColumns = false;
		this.dataGridViewExcelFilter_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridViewExcelFilter_0.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewTextBoxColumn_18,
			this.dataGridViewFilterDateTimePickerColumn_0,
			this.dataGridViewTextBoxColumn_20,
			this.dataGridViewTextBoxColumn_19,
			this.dataGridViewTextBoxColumn_21,
			this.dataGridViewTextBoxColumn_22,
			this.dataGridViewTextBoxColumn_23
		});
		this.dataGridViewExcelFilter_0.DataMember = "tJ_DamageOn";
		this.dataGridViewExcelFilter_0.DataSource = this.class171_0;
		this.dataGridViewExcelFilter_0.Location = new Point(0, 23);
		this.dataGridViewExcelFilter_0.Name = "dgvOn";
		this.dataGridViewExcelFilter_0.RowHeadersWidth = 21;
		this.dataGridViewExcelFilter_0.Size = new Size(447, 108);
		this.dataGridViewExcelFilter_0.TabIndex = 1;
		this.dataGridViewExcelFilter_0.CellValueChanged += this.dataGridViewExcelFilter_0_CellValueChanged;
		this.dataGridViewExcelFilter_0.DataError += this.dataGridViewExcelFilter_0_DataError;
		this.dataGridViewExcelFilter_0.EditingControlShowing += this.dataGridViewExcelFilter_0_EditingControlShowing;
		this.dataGridViewExcelFilter_0.RowsAdded += this.dataGridViewExcelFilter_0_RowsAdded;
		this.dataGridViewExcelFilter_0.RowsRemoved += this.dataGridViewExcelFilter_0_RowsRemoved;
		this.dataGridViewTextBoxColumn_18.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewCellStyle.BackColor = Color.FromArgb(224, 224, 224);
		dataGridViewCellStyle.Format = "dd.MM.yyyy HH:mm";
		this.dataGridViewTextBoxColumn_18.DefaultCellStyle = dataGridViewCellStyle;
		this.dataGridViewTextBoxColumn_18.HeaderText = "Дата1";
		this.dataGridViewTextBoxColumn_18.Name = "dateBegDgvColumn";
		this.dataGridViewTextBoxColumn_18.ReadOnly = true;
		this.dataGridViewTextBoxColumn_18.Visible = false;
		this.dataGridViewFilterDateTimePickerColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewFilterDateTimePickerColumn_0.DataPropertyName = "dateOn";
		dataGridViewCellStyle2.Format = "dd.MM.yyyy HH:mm";
		this.dataGridViewFilterDateTimePickerColumn_0.DefaultCellStyle = dataGridViewCellStyle2;
		this.dataGridViewFilterDateTimePickerColumn_0.FillWeight = 100.5905f;
		this.dataGridViewFilterDateTimePickerColumn_0.HeaderText = "Дата включения";
		this.dataGridViewFilterDateTimePickerColumn_0.MinimumWidth = 70;
		this.dataGridViewFilterDateTimePickerColumn_0.Name = "dateOnDgvColumn";
		this.dataGridViewFilterDateTimePickerColumn_0.Resizable = DataGridViewTriState.True;
		this.dataGridViewFilterDateTimePickerColumn_0.SortMode = DataGridViewColumnSortMode.Automatic;
		this.dataGridViewTextBoxColumn_20.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_20.DataPropertyName = "countSchmObj";
		this.dataGridViewTextBoxColumn_20.FillWeight = 99.64599f;
		this.dataGridViewTextBoxColumn_20.HeaderText = "Количество трансформаторов";
		this.dataGridViewTextBoxColumn_20.MinimumWidth = 70;
		this.dataGridViewTextBoxColumn_20.Name = "countSchmObjDgvColumn";
		this.dataGridViewTextBoxColumn_19.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewCellStyle3.BackColor = Color.FromArgb(224, 224, 224);
		this.dataGridViewTextBoxColumn_19.DefaultCellStyle = dataGridViewCellStyle3;
		this.dataGridViewTextBoxColumn_19.HeaderText = "Количество отключенных";
		this.dataGridViewTextBoxColumn_19.Name = "countSchmObjOffDgvColumn";
		this.dataGridViewTextBoxColumn_19.ReadOnly = true;
		this.dataGridViewTextBoxColumn_19.Visible = false;
		this.dataGridViewTextBoxColumn_21.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_21.DataPropertyName = "noAdmissionKWT";
		dataGridViewCellStyle4.BackColor = Color.FromArgb(224, 224, 224);
		this.dataGridViewTextBoxColumn_21.DefaultCellStyle = dataGridViewCellStyle4;
		this.dataGridViewTextBoxColumn_21.HeaderText = "Недопуск эл.энергии";
		this.dataGridViewTextBoxColumn_21.Name = "noAdmissionKWTDgvColumn";
		this.dataGridViewTextBoxColumn_21.ReadOnly = true;
		this.dataGridViewTextBoxColumn_21.Visible = false;
		this.dataGridViewTextBoxColumn_22.DataPropertyName = "id";
		this.dataGridViewTextBoxColumn_22.HeaderText = "id";
		this.dataGridViewTextBoxColumn_22.Name = "idDataGridViewTextBoxColumn1";
		this.dataGridViewTextBoxColumn_22.ReadOnly = true;
		this.dataGridViewTextBoxColumn_22.Visible = false;
		this.dataGridViewTextBoxColumn_23.DataPropertyName = "idDamage";
		this.dataGridViewTextBoxColumn_23.HeaderText = "idDamage";
		this.dataGridViewTextBoxColumn_23.Name = "idDamageDataGridViewTextBoxColumn1";
		this.dataGridViewTextBoxColumn_23.ReadOnly = true;
		this.dataGridViewTextBoxColumn_23.Visible = false;
		this.label_11.AutoSize = true;
		this.label_11.Location = new Point(6, 7);
		this.label_11.Name = "labelDamageOn";
		this.label_11.Size = new Size(63, 13);
		this.label_11.TabIndex = 0;
		this.label_11.Text = "Включение";
		this.label_12.AutoSize = true;
		this.label_12.Location = new Point(10, 0);
		this.label_12.Name = "label1";
		this.label_12.Size = new Size(70, 13);
		this.label_12.TabIndex = 7;
		this.label_12.Text = "Примечание";
		this.checkBox_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.checkBox_0.AutoSize = true;
		this.checkBox_0.DataBindings.Add(new Binding("Checked", this.class171_0, "tJ_Damage.isApply", true, DataSourceUpdateMode.OnPropertyChanged));
		this.checkBox_0.Location = new Point(13, 76);
		this.checkBox_0.Name = "checkBoxApply";
		this.checkBox_0.Size = new Size(82, 17);
		this.checkBox_0.TabIndex = 3;
		this.checkBox_0.Text = "Исполнено";
		this.checkBox_0.UseVisualStyleBackColor = true;
		this.checkBox_0.CheckedChanged += this.checkBox_0_CheckedChanged;
		this.nullableDateTimePicker_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.nullableDateTimePicker_0.CustomFormat = "dd.MM.yyyy HH:mm";
		this.nullableDateTimePicker_0.DataBindings.Add(new Binding("Value", this.class171_0, "tJ_Damage.DateApply", true));
		this.nullableDateTimePicker_0.Format = DateTimePickerFormat.Custom;
		this.nullableDateTimePicker_0.Location = new Point(101, 101);
		this.nullableDateTimePicker_0.Name = "dtpDataApply";
		this.nullableDateTimePicker_0.Size = new Size(256, 20);
		this.nullableDateTimePicker_0.TabIndex = 6;
		this.nullableDateTimePicker_0.Value = new DateTime(2015, 8, 6, 10, 0, 53, 2);
		this.nullableDateTimePicker_0.ValueChanged += this.nullableDateTimePicker_0_ValueChanged;
		this.label_7.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.label_7.AutoSize = true;
		this.label_7.Location = new Point(10, 106);
		this.label_7.Name = "labelDateAplly";
		this.label_7.Size = new Size(77, 13);
		this.label_7.TabIndex = 5;
		this.label_7.Text = "Дата и время";
		this.richTextBox_1.AcceptsTab = true;
		this.richTextBox_1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.richTextBox_1.BackColor = SystemColors.Window;
		this.richTextBox_1.DataBindings.Add(new Binding("Text", this.class171_0, "tJ_Damage.ComletedWorkText", true));
		this.richTextBox_1.Location = new Point(0, 16);
		this.richTextBox_1.Name = "txtCompletedWork";
		this.richTextBox_1.Size = new Size(447, 52);
		this.richTextBox_1.TabIndex = 2;
		this.richTextBox_1.Text = "";
		this.richTextBox_1.TextChanged += this.richTextBox_1_TextChanged;
		this.comboBoxReadOnly_2.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.comboBoxReadOnly_2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBoxReadOnly_2.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBoxReadOnly_2.DataBindings.Add(new Binding("SelectedValue", this.class171_0, "tJ_Damage.idWorkerApply", true));
		this.comboBoxReadOnly_2.FormattingEnabled = true;
		this.comboBoxReadOnly_2.Location = new Point(101, 74);
		this.comboBoxReadOnly_2.Name = "cmbWorkerApply";
		this.comboBoxReadOnly_2.ReadOnlyBackColor = SystemColors.Window;
		this.comboBoxReadOnly_2.ReadOnlyForeColor = SystemColors.WindowText;
		this.comboBoxReadOnly_2.Size = new Size(196, 21);
		this.comboBoxReadOnly_2.TabIndex = 4;
		this.comboBoxReadOnly_2.SelectedIndexChanged += this.comboBoxReadOnly_2_SelectedIndexChanged;
		this.label_8.AutoSize = true;
		this.label_8.Location = new Point(10, 22);
		this.label_8.Name = "labelCompletedWork";
		this.label_8.Size = new Size(114, 13);
		this.label_8.TabIndex = 1;
		this.label_8.Text = "Выполненная работа";
		this.comboBoxReadOnly_3.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.comboBoxReadOnly_3.DataBindings.Add(new Binding("SelectedValue", this.class171_0, "tJ_Damage.idCompletedWork", true));
		this.comboBoxReadOnly_3.FormattingEnabled = true;
		this.comboBoxReadOnly_3.Location = new Point(130, 19);
		this.comboBoxReadOnly_3.Name = "cmbCompletedWork";
		this.comboBoxReadOnly_3.ReadOnlyBackColor = SystemColors.Window;
		this.comboBoxReadOnly_3.ReadOnlyForeColor = SystemColors.WindowText;
		this.comboBoxReadOnly_3.Size = new Size(313, 21);
		this.comboBoxReadOnly_3.TabIndex = 0;
		this.comboBoxReadOnly_3.SelectedIndexChanged += this.comboBoxReadOnly_3_SelectedIndexChanged;
		this.comboBoxReadOnly_0.DataBindings.Add(new Binding("SelectedValue", this.class171_0, "tJ_Damage.idDivision", true, DataSourceUpdateMode.OnPropertyChanged));
		this.comboBoxReadOnly_0.FormattingEnabled = true;
		this.comboBoxReadOnly_0.Location = new Point(605, 33);
		this.comboBoxReadOnly_0.Name = "cmbDivision";
		this.comboBoxReadOnly_0.ReadOnly = true;
		this.comboBoxReadOnly_0.ReadOnlyBackColor = SystemColors.Window;
		this.comboBoxReadOnly_0.ReadOnlyForeColor = SystemColors.WindowText;
		this.comboBoxReadOnly_0.Size = new Size(266, 21);
		this.comboBoxReadOnly_0.TabIndex = 11;
		this.comboBoxReadOnly_0.TabStop = false;
		this.comboBoxReadOnly_0.SelectedIndexChanged += this.comboBoxReadOnly_0_SelectedIndexChanged;
		this.label_0.AutoSize = true;
		this.label_0.Location = new Point(515, 39);
		this.label_0.Name = "label6";
		this.label_0.Size = new Size(87, 13);
		this.label_0.TabIndex = 10;
		this.label_0.Text = "Подразделение";
		this.label_1.AutoSize = true;
		this.label_1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.label_1.Location = new Point(515, 13);
		this.label_1.Name = "labelCompiler";
		this.label_1.Size = new Size(83, 13);
		this.label_1.TabIndex = 9;
		this.label_1.Text = "Составитель";
		this.comboBoxReadOnly_1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBoxReadOnly_1.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBoxReadOnly_1.DataBindings.Add(new Binding("SelectedValue", this.class171_0, "tJ_Damage.idCompiler", true));
		this.comboBoxReadOnly_1.FormattingEnabled = true;
		this.comboBoxReadOnly_1.Location = new Point(605, 5);
		this.comboBoxReadOnly_1.Name = "cmbCompiler";
		this.comboBoxReadOnly_1.ReadOnlyBackColor = SystemColors.Window;
		this.comboBoxReadOnly_1.ReadOnlyForeColor = SystemColors.WindowText;
		this.comboBoxReadOnly_1.Size = new Size(266, 21);
		this.comboBoxReadOnly_1.TabIndex = 8;
		this.comboBoxReadOnly_1.SelectedValueChanged += this.comboBoxReadOnly_1_SelectedValueChanged;
		this.dateTimePicker_0.DataBindings.Add(new Binding("Value", this.class171_0, "tJ_Damage.DateOwner", true));
		this.dateTimePicker_0.Enabled = false;
		this.dateTimePicker_0.Location = new Point(355, 33);
		this.dateTimePicker_0.Name = "dtpDateOwner";
		this.dateTimePicker_0.Size = new Size(144, 20);
		this.dateTimePicker_0.TabIndex = 7;
		this.label_2.AutoSize = true;
		this.label_2.Location = new Point(233, 39);
		this.label_2.Name = "label4";
		this.label_2.Size = new Size(84, 13);
		this.label_2.TabIndex = 6;
		this.label_2.Text = "Дата создания";
		this.label_3.AutoSize = true;
		this.label_3.Location = new Point(8, 39);
		this.label_3.Name = "label3";
		this.label_3.Size = new Size(76, 13);
		this.label_3.TabIndex = 5;
		this.label_3.Text = "Автор заявки";
		this.textBox_0.Location = new Point(105, 32);
		this.textBox_0.Name = "txtOwner";
		this.textBox_0.ReadOnly = true;
		this.textBox_0.Size = new Size(122, 20);
		this.textBox_0.TabIndex = 4;
		this.label_4.AutoSize = true;
		this.label_4.Location = new Point(233, 13);
		this.label_4.Name = "label2";
		this.label_4.Size = new Size(116, 13);
		this.label_4.TabIndex = 3;
		this.label_4.Text = "Дата и время заявки";
		this.dateTimePicker_1.CustomFormat = "dd.MM.yyyy HH:mm";
		this.dateTimePicker_1.DataBindings.Add(new Binding("Value", this.class171_0, "tJ_Damage.DateDoc", true));
		this.dateTimePicker_1.Format = DateTimePickerFormat.Custom;
		this.dateTimePicker_1.Location = new Point(355, 7);
		this.dateTimePicker_1.Name = "dtpDateDoc";
		this.dateTimePicker_1.Size = new Size(144, 20);
		this.dateTimePicker_1.TabIndex = 2;
		this.dateTimePicker_1.ValueChanged += this.dateTimePicker_1_ValueChanged;
		this.dateTimePicker_1.Validated += this.dateTimePicker_1_Validated;
		this.label_5.AutoSize = true;
		this.label_5.Location = new Point(8, 13);
		this.label_5.Name = "labelNumRequest";
		this.label_5.Size = new Size(80, 13);
		this.label_5.TabIndex = 1;
		this.label_5.Text = "Номер заявки";
		this.textBox_1.BackColor = SystemColors.Window;
		this.textBox_1.DataBindings.Add(new Binding("Text", this.class171_0, "tJ_Damage.NumRequest", true, DataSourceUpdateMode.OnPropertyChanged));
		this.textBox_1.Location = new Point(105, 6);
		this.textBox_1.Name = "txtNumRequest";
		this.textBox_1.Size = new Size(122, 20);
		this.textBox_1.TabIndex = 0;
		this.textBox_1.TextChanged += this.textBox_1_TextChanged;
		this.tabPage_1.Controls.Add(this.splitContainer_2);
		this.tabPage_1.Controls.Add(this.statusStrip_0);
		this.tabPage_1.Controls.Add(this.toolStrip_0);
		this.tabPage_1.Location = new Point(4, 22);
		this.tabPage_1.Name = "tabPageTransformer";
		this.tabPage_1.Padding = new Padding(3);
		this.tabPage_1.Size = new Size(961, 619);
		this.tabPage_1.TabIndex = 1;
		this.tabPage_1.Text = "Отключенные трансформаторы";
		this.tabPage_1.UseVisualStyleBackColor = true;
		this.splitContainer_2.Dock = DockStyle.Fill;
		this.splitContainer_2.Location = new Point(3, 28);
		this.splitContainer_2.Name = "splitContainerTrans";
		this.splitContainer_2.Orientation = Orientation.Horizontal;
		this.splitContainer_2.Panel1.Controls.Add(this.dataGridViewExcelFilter_1);
		this.splitContainer_2.Panel2.Controls.Add(this.treeDataGridView_0);
		this.splitContainer_2.Size = new Size(955, 566);
		this.splitContainer_2.SplitterDistance = 283;
		this.splitContainer_2.TabIndex = 4;
		this.dataGridViewExcelFilter_1.AllowUserToAddRows = false;
		this.dataGridViewExcelFilter_1.AllowUserToDeleteRows = false;
		this.dataGridViewExcelFilter_1.AllowUserToOrderColumns = true;
		dataGridViewCellStyle5.BackColor = Color.FromArgb(224, 224, 224);
		this.dataGridViewExcelFilter_1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
		this.dataGridViewExcelFilter_1.AutoGenerateColumns = false;
		this.dataGridViewExcelFilter_1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridViewExcelFilter_1.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewTextBoxColumn_12,
			this.dataGridViewTextBoxColumn_13,
			this.dataGridViewTextBoxColumn_14,
			this.dataGridViewTextBoxColumn_15,
			this.dataGridViewTextBoxColumn_16,
			this.dataGridViewTextBoxColumn_17
		});
		this.dataGridViewExcelFilter_1.DataSource = this.bindingSource_0;
		this.dataGridViewExcelFilter_1.Dock = DockStyle.Fill;
		this.dataGridViewExcelFilter_1.Location = new Point(0, 0);
		this.dataGridViewExcelFilter_1.Name = "dgvTrans";
		this.dataGridViewExcelFilter_1.RowHeadersWidth = 21;
		this.dataGridViewExcelFilter_1.Size = new Size(955, 283);
		this.dataGridViewExcelFilter_1.TabIndex = 2;
		this.dataGridViewExcelFilter_1.CellEndEdit += this.dataGridViewExcelFilter_1_CellEndEdit;
		this.dataGridViewExcelFilter_1.RowsAdded += this.dataGridViewExcelFilter_1_RowsAdded;
		this.dataGridViewExcelFilter_1.RowsRemoved += this.dataGridViewExcelFilter_1_RowsRemoved;
		this.dataGridViewTextBoxColumn_12.DataPropertyName = "Sub";
		this.dataGridViewTextBoxColumn_12.HeaderText = "Подстанция";
		this.dataGridViewTextBoxColumn_12.Name = "subDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_12.ReadOnly = true;
		this.dataGridViewTextBoxColumn_12.Visible = false;
		this.dataGridViewTextBoxColumn_12.Width = 5;
		this.dataGridViewTextBoxColumn_13.DataPropertyName = "idSub";
		this.dataGridViewTextBoxColumn_13.HeaderText = "idSub";
		this.dataGridViewTextBoxColumn_13.Name = "idSubDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_13.ReadOnly = true;
		this.dataGridViewTextBoxColumn_13.Visible = false;
		this.dataGridViewTextBoxColumn_14.DataPropertyName = "idTr";
		this.dataGridViewTextBoxColumn_14.HeaderText = "idTr";
		this.dataGridViewTextBoxColumn_14.Name = "idTrDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_14.ReadOnly = true;
		this.dataGridViewTextBoxColumn_14.Visible = false;
		this.dataGridViewTextBoxColumn_15.DataPropertyName = "TrName";
		this.dataGridViewTextBoxColumn_15.HeaderText = "Трасформатор";
		this.dataGridViewTextBoxColumn_15.Name = "trNameDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_15.ReadOnly = true;
		this.dataGridViewTextBoxColumn_16.DataPropertyName = "Power";
		this.dataGridViewTextBoxColumn_16.HeaderText = "Мощность";
		this.dataGridViewTextBoxColumn_16.Name = "powerDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_17.DataPropertyName = "Load";
		this.dataGridViewTextBoxColumn_17.HeaderText = "Нагрузка";
		this.dataGridViewTextBoxColumn_17.Name = "loadDataGridViewTextBoxColumn";
		this.bindingSource_0.DataMember = "tableTrans";
		this.bindingSource_0.DataSource = this.dataSet_0;
		this.dataSet_0.DataSetName = "NewDataSet";
		this.dataSet_0.Tables.AddRange(new DataTable[]
		{
			this.dataTable_0,
			this.dataTable_1
		});
		this.dataTable_0.Columns.AddRange(new DataColumn[]
		{
			this.dataColumn_0,
			this.dataColumn_1,
			this.dataColumn_2,
			this.dataColumn_3,
			this.dataColumn_4,
			this.dataColumn_5
		});
		this.dataTable_0.TableName = "tableTrans";
		this.dataColumn_0.ColumnName = "idSub";
		this.dataColumn_0.DataType = typeof(int);
		this.dataColumn_1.ColumnName = "Sub";
		this.dataColumn_2.ColumnName = "idTr";
		this.dataColumn_2.DataType = typeof(int);
		this.dataColumn_3.ColumnName = "TrName";
		this.dataColumn_4.ColumnName = "Power";
		this.dataColumn_4.DataType = typeof(int);
		this.dataColumn_5.ColumnName = "Load";
		this.dataColumn_5.DataType = typeof(int);
		this.dataTable_1.Columns.AddRange(new DataColumn[]
		{
			this.dataColumn_6,
			this.dataColumn_7,
			this.dataColumn_8,
			this.dataColumn_9,
			this.dataColumn_10,
			this.dataColumn_11,
			this.dataColumn_12,
			this.dataColumn_13,
			this.dataColumn_14,
			this.dataColumn_15
		});
		this.dataTable_1.TableName = "vl_SchmAbnFull";
		this.dataColumn_6.ColumnName = "idAbn";
		this.dataColumn_6.DataType = typeof(int);
		this.dataColumn_7.ColumnName = "codeAbonent";
		this.dataColumn_7.DataType = typeof(int);
		this.dataColumn_8.ColumnName = "nameAbn";
		this.dataColumn_9.ColumnName = "typeAbn";
		this.dataColumn_9.DataType = typeof(int);
		this.dataColumn_10.ColumnName = "idAbnObj";
		this.dataColumn_10.DataType = typeof(int);
		this.dataColumn_11.ColumnName = "nameObj";
		this.dataColumn_12.ColumnName = "CommentODS";
		this.dataColumn_13.ColumnName = "CategoryName";
		this.dataColumn_14.ColumnName = "PowerSet";
		this.dataColumn_14.DataType = typeof(decimal);
		this.dataColumn_15.ColumnName = "CountPoint";
		this.dataColumn_15.DataType = typeof(int);
		this.treeDataGridView_0.AllowUserToAddRows = false;
		this.treeDataGridView_0.AllowUserToDeleteRows = false;
		this.treeDataGridView_0.Columns.AddRange(new DataGridViewColumn[]
		{
			this.treeGridColumn_0,
			this.dataGridViewTextBoxColumn_24,
			this.dataGridViewTextBoxColumn_25,
			this.dataGridViewTextBoxColumn_26,
			this.dataGridViewTextBoxColumn_27,
			this.dataGridViewTextBoxColumn_28,
			this.dataGridViewTextBoxColumn_29,
			this.dataGridViewTextBoxColumn_30,
			this.dataGridViewTextBoxColumn_31,
			this.dataGridViewTextBoxColumn_32,
			this.dataGridViewTextBoxColumn_33,
			this.dataGridViewTextBoxColumn_34
		});
		this.treeDataGridView_0.Dock = DockStyle.Fill;
		this.treeDataGridView_0.EditMode = DataGridViewEditMode.EditProgrammatically;
		this.treeDataGridView_0.ImageList = null;
		this.treeDataGridView_0.Location = new Point(0, 0);
		this.treeDataGridView_0.Name = "dgvTree";
		this.treeDataGridView_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		this.treeDataGridView_0.Size = new Size(955, 279);
		this.treeDataGridView_0.TabIndex = 3;
		this.treeDataGridView_0.CellFormatting += this.treeDataGridView_0_CellFormatting;
		this.treeDataGridView_0.CellMouseClick += this.treeDataGridView_0_CellMouseClick;
		this.treeGridColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.treeGridColumn_0.DataPropertyName = "SubName";
		this.treeGridColumn_0.DefaultNodeImage = null;
		this.treeGridColumn_0.HeaderText = "Подстанция";
		this.treeGridColumn_0.Name = "subNameColumn";
		this.treeGridColumn_0.SortMode = DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn_24.DataPropertyName = "idSub";
		this.dataGridViewTextBoxColumn_24.HeaderText = "idSub";
		this.dataGridViewTextBoxColumn_24.Name = "idSubColumn";
		this.dataGridViewTextBoxColumn_24.SortMode = DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn_24.Visible = false;
		this.dataGridViewTextBoxColumn_25.DataPropertyName = "BusName";
		this.dataGridViewTextBoxColumn_25.HeaderText = "Шина";
		this.dataGridViewTextBoxColumn_25.Name = "busNameColumn";
		this.dataGridViewTextBoxColumn_25.SortMode = DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn_26.DataPropertyName = "idBus";
		this.dataGridViewTextBoxColumn_26.HeaderText = "idBus";
		this.dataGridViewTextBoxColumn_26.Name = "idBusColumn";
		this.dataGridViewTextBoxColumn_26.SortMode = DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn_26.Visible = false;
		this.dataGridViewTextBoxColumn_27.DataPropertyName = "CellName";
		this.dataGridViewTextBoxColumn_27.HeaderText = "Ячейка";
		this.dataGridViewTextBoxColumn_27.Name = "cellNameColumn";
		this.dataGridViewTextBoxColumn_27.SortMode = DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn_28.DataPropertyName = "idCell";
		this.dataGridViewTextBoxColumn_28.HeaderText = "idCell";
		this.dataGridViewTextBoxColumn_28.Name = "idCellColumn";
		this.dataGridViewTextBoxColumn_28.SortMode = DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn_28.Visible = false;
		this.dataGridViewTextBoxColumn_29.DataPropertyName = "TrName";
		this.dataGridViewTextBoxColumn_29.HeaderText = "Трансформатор";
		this.dataGridViewTextBoxColumn_29.Name = "trNameColumn";
		this.dataGridViewTextBoxColumn_29.SortMode = DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn_30.DataPropertyName = "idTr";
		this.dataGridViewTextBoxColumn_30.HeaderText = "idTr";
		this.dataGridViewTextBoxColumn_30.Name = "idTrColumn";
		this.dataGridViewTextBoxColumn_30.SortMode = DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn_30.Visible = false;
		this.dataGridViewTextBoxColumn_31.DataPropertyName = "Power";
		this.dataGridViewTextBoxColumn_31.HeaderText = "Мощность";
		this.dataGridViewTextBoxColumn_31.Name = "powerColumn";
		this.dataGridViewTextBoxColumn_31.SortMode = DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn_32.DataPropertyName = "Load";
		this.dataGridViewTextBoxColumn_32.HeaderText = "Нагрузка";
		this.dataGridViewTextBoxColumn_32.Name = "loadColumn";
		this.dataGridViewTextBoxColumn_32.SortMode = DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn_33.DataPropertyName = "DateOn";
		dataGridViewCellStyle6.Format = "g";
		dataGridViewCellStyle6.NullValue = null;
		this.dataGridViewTextBoxColumn_33.DefaultCellStyle = dataGridViewCellStyle6;
		this.dataGridViewTextBoxColumn_33.HeaderText = "Дата включения";
		this.dataGridViewTextBoxColumn_33.Name = "dateOnColumn";
		this.dataGridViewTextBoxColumn_33.SortMode = DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn_34.DataPropertyName = "noAddmissionKWT";
		this.dataGridViewTextBoxColumn_34.HeaderText = "Недоотпуск";
		this.dataGridViewTextBoxColumn_34.Name = "noAdmissionKWTColumn";
		this.dataGridViewTextBoxColumn_34.SortMode = DataGridViewColumnSortMode.NotSortable;
		this.statusStrip_0.Items.AddRange(new ToolStripItem[]
		{
			this.toolStripStatusLabel_0,
			this.toolStripStatusLabel_1,
			this.toolStripStatusLabel_2
		});
		this.statusStrip_0.Location = new Point(3, 594);
		this.statusStrip_0.Name = "statusStripTrans";
		this.statusStrip_0.Size = new Size(955, 22);
		this.statusStrip_0.TabIndex = 5;
		this.statusStrip_0.Text = "statusStrip1";
		this.toolStripStatusLabel_0.Name = "labelCountTr";
		this.toolStripStatusLabel_0.Size = new Size(313, 17);
		this.toolStripStatusLabel_0.Spring = true;
		this.toolStripStatusLabel_0.Text = "Кол-во трансформаторов: 0";
		this.toolStripStatusLabel_1.Name = "labelSumPower";
		this.toolStripStatusLabel_1.Size = new Size(313, 17);
		this.toolStripStatusLabel_1.Spring = true;
		this.toolStripStatusLabel_1.Text = "Суммарная мощность: 0";
		this.toolStripStatusLabel_2.Name = "labelSumLoad";
		this.toolStripStatusLabel_2.Size = new Size(313, 17);
		this.toolStripStatusLabel_2.Spring = true;
		this.toolStripStatusLabel_2.Text = "Суммарная нагрузка: 0";
		this.toolStrip_0.Items.AddRange(new ToolStripItem[]
		{
			this.toolStripButton_0
		});
		this.toolStrip_0.Location = new Point(3, 3);
		this.toolStrip_0.Name = "toolStripTransformer";
		this.toolStrip_0.Size = new Size(955, 25);
		this.toolStrip_0.TabIndex = 0;
		this.toolStrip_0.Text = "toolStrip1";
		this.toolStripButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_0.Image = (Image)componentResourceManager.GetObject("toolBtnRefreshTrans.Image");
		this.toolStripButton_0.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_0.Name = "toolBtnRefreshTrans";
		this.toolStripButton_0.Size = new Size(23, 22);
		this.toolStripButton_0.Text = "Обновить";
		this.toolStripButton_0.Click += this.toolStripButton_1_Click;
		this.tabPage_2.Controls.Add(this.splitContainer_3);
		this.tabPage_2.Controls.Add(this.statusStrip_1);
		this.tabPage_2.Location = new Point(4, 22);
		this.tabPage_2.Name = "tabPageAbn";
		this.tabPage_2.Padding = new Padding(3);
		this.tabPage_2.Size = new Size(961, 619);
		this.tabPage_2.TabIndex = 2;
		this.tabPage_2.Text = "Отключенные абоненты";
		this.tabPage_2.UseVisualStyleBackColor = true;
		this.splitContainer_3.Dock = DockStyle.Fill;
		this.splitContainer_3.FixedPanel = FixedPanel.Panel2;
		this.splitContainer_3.IsSplitterFixed = true;
		this.splitContainer_3.Location = new Point(3, 3);
		this.splitContainer_3.Name = "splitContainerAbnMain";
		this.splitContainer_3.Orientation = Orientation.Horizontal;
		this.splitContainer_3.Panel1.Controls.Add(this.dataGridViewExcelFilter_2);
		this.splitContainer_3.Panel1.Controls.Add(this.toolStrip_1);
		this.splitContainer_3.Panel2.Controls.Add(this.splitContainer_4);
		this.splitContainer_3.Size = new Size(955, 591);
		this.splitContainer_3.SplitterDistance = 380;
		this.splitContainer_3.TabIndex = 7;
		this.dataGridViewExcelFilter_2.AllowUserToAddRows = false;
		this.dataGridViewExcelFilter_2.AllowUserToDeleteRows = false;
		this.dataGridViewExcelFilter_2.AllowUserToOrderColumns = true;
		dataGridViewCellStyle7.BackColor = Color.FromArgb(224, 224, 224);
		this.dataGridViewExcelFilter_2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
		this.dataGridViewExcelFilter_2.AutoGenerateColumns = false;
		this.dataGridViewExcelFilter_2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridViewExcelFilter_2.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewFilterTextBoxColumn_0,
			this.dataGridViewTextBoxColumn_35,
			this.dataGridViewFilterTextBoxColumn_1,
			this.dataGridViewFilterComboBoxColumn_0,
			this.dataGridViewTextBoxColumn_36,
			this.dataGridViewFilterTextBoxColumn_2,
			this.dataGridViewFilterTextBoxColumn_3,
			this.dataGridViewFilterTextBoxColumn_4,
			this.dataGridViewFilterTextBoxColumn_5,
			this.dataGridViewFilterTextBoxColumn_6
		});
		this.dataGridViewExcelFilter_2.DataSource = this.bindingSource_1;
		this.dataGridViewExcelFilter_2.Dock = DockStyle.Fill;
		this.dataGridViewExcelFilter_2.Location = new Point(0, 25);
		this.dataGridViewExcelFilter_2.Name = "dgvAbn";
		this.dataGridViewExcelFilter_2.ReadOnly = true;
		this.dataGridViewExcelFilter_2.Size = new Size(955, 355);
		this.dataGridViewExcelFilter_2.TabIndex = 4;
		this.dataGridViewFilterTextBoxColumn_0.DataPropertyName = "codeAbonent";
		this.dataGridViewFilterTextBoxColumn_0.HeaderText = "Код";
		this.dataGridViewFilterTextBoxColumn_0.Name = "codeAbonentDataGridViewTextBoxColumn";
		this.dataGridViewFilterTextBoxColumn_0.ReadOnly = true;
		this.dataGridViewFilterTextBoxColumn_0.Resizable = DataGridViewTriState.True;
		this.dataGridViewFilterTextBoxColumn_0.Visible = false;
		this.dataGridViewFilterTextBoxColumn_0.Width = 5;
		this.dataGridViewTextBoxColumn_35.DataPropertyName = "idAbn";
		this.dataGridViewTextBoxColumn_35.HeaderText = "idAbn";
		this.dataGridViewTextBoxColumn_35.Name = "idAbnDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_35.ReadOnly = true;
		this.dataGridViewTextBoxColumn_35.Visible = false;
		this.dataGridViewFilterTextBoxColumn_1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewFilterTextBoxColumn_1.DataPropertyName = "nameAbn";
		this.dataGridViewFilterTextBoxColumn_1.FillWeight = 76.81039f;
		this.dataGridViewFilterTextBoxColumn_1.HeaderText = "Абонент";
		this.dataGridViewFilterTextBoxColumn_1.Name = "nameAbnDataGridViewTextBoxColumn";
		this.dataGridViewFilterTextBoxColumn_1.ReadOnly = true;
		this.dataGridViewFilterTextBoxColumn_1.Resizable = DataGridViewTriState.True;
		this.dataGridViewFilterComboBoxColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewFilterComboBoxColumn_0.DataPropertyName = "typeAbn";
		this.dataGridViewFilterComboBoxColumn_0.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
		this.dataGridViewFilterComboBoxColumn_0.FillWeight = 67.16079f;
		this.dataGridViewFilterComboBoxColumn_0.HeaderText = "Тип абонента";
		this.dataGridViewFilterComboBoxColumn_0.Name = "typeAbnDgvColumn";
		this.dataGridViewFilterComboBoxColumn_0.ReadOnly = true;
		this.dataGridViewFilterComboBoxColumn_0.Resizable = DataGridViewTriState.True;
		this.dataGridViewTextBoxColumn_36.DataPropertyName = "idAbnObj";
		this.dataGridViewTextBoxColumn_36.HeaderText = "idAbnObj";
		this.dataGridViewTextBoxColumn_36.Name = "idAbnObjDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_36.ReadOnly = true;
		this.dataGridViewTextBoxColumn_36.Visible = false;
		this.dataGridViewFilterTextBoxColumn_2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewFilterTextBoxColumn_2.DataPropertyName = "nameObj";
		this.dataGridViewFilterTextBoxColumn_2.FillWeight = 93.08762f;
		this.dataGridViewFilterTextBoxColumn_2.HeaderText = "Объект";
		this.dataGridViewFilterTextBoxColumn_2.Name = "nameObjDataGridViewTextBoxColumn";
		this.dataGridViewFilterTextBoxColumn_2.ReadOnly = true;
		this.dataGridViewFilterTextBoxColumn_2.Resizable = DataGridViewTriState.True;
		this.dataGridViewFilterTextBoxColumn_3.DataPropertyName = "CategoryName";
		this.dataGridViewFilterTextBoxColumn_3.HeaderText = "Кат.";
		this.dataGridViewFilterTextBoxColumn_3.Name = "categoryNameDgvColumn";
		this.dataGridViewFilterTextBoxColumn_3.ReadOnly = true;
		this.dataGridViewFilterTextBoxColumn_3.Width = 40;
		this.dataGridViewFilterTextBoxColumn_4.DataPropertyName = "PowerSet";
		this.dataGridViewFilterTextBoxColumn_4.HeaderText = "Мощность";
		this.dataGridViewFilterTextBoxColumn_4.Name = "powerSetDgvColumn";
		this.dataGridViewFilterTextBoxColumn_4.ReadOnly = true;
		this.dataGridViewFilterTextBoxColumn_4.Width = 60;
		this.dataGridViewFilterTextBoxColumn_5.DataPropertyName = "CountPoint";
		this.dataGridViewFilterTextBoxColumn_5.HeaderText = "Кол-во т.у.";
		this.dataGridViewFilterTextBoxColumn_5.Name = "сountPointDgvColumn";
		this.dataGridViewFilterTextBoxColumn_5.ReadOnly = true;
		this.dataGridViewFilterTextBoxColumn_5.Width = 40;
		this.dataGridViewFilterTextBoxColumn_6.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewFilterTextBoxColumn_6.DataPropertyName = "CommentODS";
		this.dataGridViewFilterTextBoxColumn_6.FillWeight = 111.0855f;
		this.dataGridViewFilterTextBoxColumn_6.HeaderText = "Примечание";
		this.dataGridViewFilterTextBoxColumn_6.Name = "commentODSDgvColumn";
		this.dataGridViewFilterTextBoxColumn_6.ReadOnly = true;
		this.bindingSource_1.DataMember = "vl_SchmAbnFull";
		this.bindingSource_1.DataSource = this.dataSet_0;
		this.toolStrip_1.Items.AddRange(new ToolStripItem[]
		{
			this.toolStripButton_1
		});
		this.toolStrip_1.Location = new Point(0, 0);
		this.toolStrip_1.Name = "toolStripAbn";
		this.toolStrip_1.Size = new Size(955, 25);
		this.toolStrip_1.TabIndex = 5;
		this.toolStrip_1.Text = "toolStrip1";
		this.toolStripButton_1.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_1.Image = (Image)componentResourceManager.GetObject("toolBtnRefreshAbn.Image");
		this.toolStripButton_1.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_1.Name = "toolBtnRefreshAbn";
		this.toolStripButton_1.Size = new Size(23, 22);
		this.toolStripButton_1.Text = "Обновить";
		this.toolStripButton_1.Click += this.toolStripButton_1_Click;
		this.splitContainer_4.Dock = DockStyle.Fill;
		this.splitContainer_4.FixedPanel = FixedPanel.Panel1;
		this.splitContainer_4.IsSplitterFixed = true;
		this.splitContainer_4.Location = new Point(0, 0);
		this.splitContainer_4.Name = "splitContainerAbnCount";
		this.splitContainer_4.Panel1.Controls.Add(this.numericUpDown_0);
		this.splitContainer_4.Panel1.Controls.Add(this.numericUpDown_1);
		this.splitContainer_4.Panel1.Controls.Add(this.numericUpDown_2);
		this.splitContainer_4.Panel1.Controls.Add(this.groupBox_3);
		this.splitContainer_4.Panel1.Controls.Add(this.label_32);
		this.splitContainer_4.Panel1.Controls.Add(this.label_33);
		this.splitContainer_4.Panel1.Controls.Add(this.label_34);
		this.splitContainer_4.Panel1.Controls.Add(this.groupBox_4);
		this.splitContainer_4.Panel1.Controls.Add(this.label_37);
		this.splitContainer_4.Panel2.Controls.Add(this.numericUpDown_7);
		this.splitContainer_4.Panel2.Controls.Add(this.numericUpDown_8);
		this.splitContainer_4.Panel2.Controls.Add(this.numericUpDown_9);
		this.splitContainer_4.Panel2.Controls.Add(this.label_38);
		this.splitContainer_4.Panel2.Controls.Add(this.groupBox_5);
		this.splitContainer_4.Panel2.Controls.Add(this.groupBox_6);
		this.splitContainer_4.Panel2.Controls.Add(this.label_44);
		this.splitContainer_4.Panel2.Controls.Add(this.label_45);
		this.splitContainer_4.Panel2.Controls.Add(this.label_46);
		this.splitContainer_4.Panel2.Controls.Add(this.groupBox_7);
		this.splitContainer_4.Size = new Size(955, 207);
		this.splitContainer_4.SplitterDistance = 377;
		this.splitContainer_4.TabIndex = 0;
		this.numericUpDown_0.Location = new Point(17, 179);
		NumericUpDown numericUpDown = this.numericUpDown_0;
		int[] array = new int[4];
		array[0] = 999999;
		numericUpDown.Maximum = new decimal(array);
		this.numericUpDown_0.Name = "numCountPointSource";
		this.numericUpDown_0.Size = new Size(144, 20);
		this.numericUpDown_0.TabIndex = 11;
		this.numericUpDown_0.ValueChanged += this.numericUpDown_6_ValueChanged;
		this.numericUpDown_1.Location = new Point(169, 141);
		NumericUpDown numericUpDown2 = this.numericUpDown_1;
		int[] array2 = new int[4];
		array2[0] = 999999;
		numericUpDown2.Maximum = new decimal(array2);
		this.numericUpDown_1.Name = "numCountPointEE";
		this.numericUpDown_1.Size = new Size(160, 20);
		this.numericUpDown_1.TabIndex = 10;
		this.numericUpDown_1.ValueChanged += this.numericUpDown_6_ValueChanged;
		this.numericUpDown_2.Location = new Point(17, 141);
		NumericUpDown numericUpDown3 = this.numericUpDown_2;
		int[] array3 = new int[4];
		array3[0] = 999999;
		numericUpDown3.Maximum = new decimal(array3);
		this.numericUpDown_2.Name = "numCountPointCat3";
		this.numericUpDown_2.Size = new Size(144, 20);
		this.numericUpDown_2.TabIndex = 9;
		this.numericUpDown_2.ValueChanged += this.numericUpDown_6_ValueChanged;
		this.groupBox_3.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.groupBox_3.Controls.Add(this.numericUpDown_3);
		this.groupBox_3.Controls.Add(this.numericUpDown_4);
		this.groupBox_3.Controls.Add(this.label_30);
		this.groupBox_3.Controls.Add(this.label_31);
		this.groupBox_3.Location = new Point(8, 16);
		this.groupBox_3.Name = "groupBoxAbnObj1Catergory";
		this.groupBox_3.Size = new Size(358, 51);
		this.groupBox_3.TabIndex = 1;
		this.groupBox_3.TabStop = false;
		this.groupBox_3.Text = "1 категория надежности";
		this.numericUpDown_3.Location = new Point(225, 19);
		NumericUpDown numericUpDown4 = this.numericUpDown_3;
		int[] array4 = new int[4];
		array4[0] = 999999;
		numericUpDown4.Maximum = new decimal(array4);
		this.numericUpDown_3.Name = "numCountPointCat1";
		this.numericUpDown_3.Size = new Size(96, 20);
		this.numericUpDown_3.TabIndex = 5;
		this.numericUpDown_3.ValueChanged += this.numericUpDown_6_ValueChanged;
		this.numericUpDown_4.Location = new Point(57, 18);
		NumericUpDown numericUpDown5 = this.numericUpDown_4;
		int[] array5 = new int[4];
		array5[0] = 999999;
		numericUpDown5.Maximum = new decimal(array5);
		this.numericUpDown_4.Name = "numCountPointCat1Full";
		this.numericUpDown_4.Size = new Size(96, 20);
		this.numericUpDown_4.TabIndex = 4;
		this.numericUpDown_4.ValueChanged += this.numericUpDown_6_ValueChanged;
		this.label_30.AutoSize = true;
		this.label_30.Location = new Point(158, 21);
		this.label_30.Name = "label18";
		this.label_30.Size = new Size(61, 13);
		this.label_30.TabIndex = 2;
		this.label_30.Text = "Частичное";
		this.label_31.AutoSize = true;
		this.label_31.Location = new Point(6, 21);
		this.label_31.Name = "label14";
		this.label_31.Size = new Size(45, 13);
		this.label_31.TabIndex = 0;
		this.label_31.Text = "Полное";
		this.label_32.AutoSize = true;
		this.label_32.Location = new Point(14, 163);
		this.label_32.Name = "label23";
		this.label_32.Size = new Size(209, 13);
		this.label_32.TabIndex = 7;
		this.label_32.Text = "Производители электрической энергии";
		this.label_33.AutoSize = true;
		this.label_33.Location = new Point(166, 124);
		this.label_33.Name = "label22";
		this.label_33.Size = new Size(158, 13);
		this.label_33.TabIndex = 5;
		this.label_33.Text = "Электросетевая организация";
		this.label_34.AutoSize = true;
		this.label_34.Location = new Point(14, 124);
		this.label_34.Name = "label21";
		this.label_34.Size = new Size(132, 13);
		this.label_34.TabIndex = 3;
		this.label_34.Text = "3 категория надежности";
		this.groupBox_4.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.groupBox_4.Controls.Add(this.numericUpDown_5);
		this.groupBox_4.Controls.Add(this.numericUpDown_6);
		this.groupBox_4.Controls.Add(this.label_35);
		this.groupBox_4.Controls.Add(this.label_36);
		this.groupBox_4.Location = new Point(8, 70);
		this.groupBox_4.Name = "groupBox1";
		this.groupBox_4.Size = new Size(358, 51);
		this.groupBox_4.TabIndex = 2;
		this.groupBox_4.TabStop = false;
		this.groupBox_4.Text = "2 категория надежности";
		this.numericUpDown_5.Location = new Point(57, 18);
		NumericUpDown numericUpDown6 = this.numericUpDown_5;
		int[] array6 = new int[4];
		array6[0] = 999999;
		numericUpDown6.Maximum = new decimal(array6);
		this.numericUpDown_5.Name = "numCountPointCat2Full";
		this.numericUpDown_5.Size = new Size(96, 20);
		this.numericUpDown_5.TabIndex = 7;
		this.numericUpDown_5.ValueChanged += this.numericUpDown_6_ValueChanged;
		this.numericUpDown_6.Location = new Point(225, 18);
		NumericUpDown numericUpDown7 = this.numericUpDown_6;
		int[] array7 = new int[4];
		array7[0] = 999999;
		numericUpDown7.Maximum = new decimal(array7);
		this.numericUpDown_6.Name = "numCountPointCat2";
		this.numericUpDown_6.Size = new Size(96, 20);
		this.numericUpDown_6.TabIndex = 6;
		this.numericUpDown_6.ValueChanged += this.numericUpDown_6_ValueChanged;
		this.label_35.AutoSize = true;
		this.label_35.Location = new Point(158, 21);
		this.label_35.Name = "label19";
		this.label_35.Size = new Size(61, 13);
		this.label_35.TabIndex = 2;
		this.label_35.Text = "Частичное";
		this.label_36.AutoSize = true;
		this.label_36.Location = new Point(6, 21);
		this.label_36.Name = "label20";
		this.label_36.Size = new Size(45, 13);
		this.label_36.TabIndex = 0;
		this.label_36.Text = "Полное";
		this.label_37.AutoSize = true;
		this.label_37.Location = new Point(5, 0);
		this.label_37.Name = "label5";
		this.label_37.Size = new Size(147, 13);
		this.label_37.TabIndex = 0;
		this.label_37.Text = "Количество точек поставки";
		this.numericUpDown_7.Location = new Point(12, 179);
		NumericUpDown numericUpDown8 = this.numericUpDown_7;
		int[] array8 = new int[4];
		array8[0] = 999999;
		numericUpDown8.Maximum = new decimal(array8);
		this.numericUpDown_7.Name = "numCountAbnObjSource";
		this.numericUpDown_7.Size = new Size(144, 20);
		this.numericUpDown_7.TabIndex = 21;
		this.numericUpDown_7.ValueChanged += this.numericUpDown_16_ValueChanged;
		this.numericUpDown_8.Location = new Point(164, 140);
		NumericUpDown numericUpDown9 = this.numericUpDown_8;
		int[] array9 = new int[4];
		array9[0] = 999999;
		numericUpDown9.Maximum = new decimal(array9);
		this.numericUpDown_8.Name = "numCountAbnObjEE";
		this.numericUpDown_8.Size = new Size(160, 20);
		this.numericUpDown_8.TabIndex = 20;
		this.numericUpDown_8.ValueChanged += this.numericUpDown_16_ValueChanged;
		this.numericUpDown_9.Location = new Point(12, 140);
		NumericUpDown numericUpDown10 = this.numericUpDown_9;
		int[] array10 = new int[4];
		array10[0] = 999999;
		numericUpDown10.Maximum = new decimal(array10);
		this.numericUpDown_9.Name = "numCountAbnObjCat3";
		this.numericUpDown_9.Size = new Size(144, 20);
		this.numericUpDown_9.TabIndex = 19;
		this.numericUpDown_9.ValueChanged += this.numericUpDown_16_ValueChanged;
		this.label_38.AutoSize = true;
		this.label_38.Location = new Point(3, 0);
		this.label_38.Name = "label31";
		this.label_38.Size = new Size(169, 13);
		this.label_38.TabIndex = 18;
		this.label_38.Text = "Количество потребителей услуг";
		this.groupBox_5.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.groupBox_5.Controls.Add(this.numericUpDown_10);
		this.groupBox_5.Controls.Add(this.numericUpDown_11);
		this.groupBox_5.Controls.Add(this.numericUpDown_12);
		this.groupBox_5.Controls.Add(this.label_39);
		this.groupBox_5.Controls.Add(this.label_40);
		this.groupBox_5.Controls.Add(this.label_41);
		this.groupBox_5.Location = new Point(367, 16);
		this.groupBox_5.Name = "groupBox4";
		this.groupBox_5.Size = new Size(200, 183);
		this.groupBox_5.TabIndex = 17;
		this.groupBox_5.TabStop = false;
		this.groupBox_5.Text = "Максимальная мощность";
		this.numericUpDown_10.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.numericUpDown_10.Location = new Point(9, 112);
		NumericUpDown numericUpDown11 = this.numericUpDown_10;
		int[] array11 = new int[4];
		array11[0] = 999999;
		numericUpDown11.Maximum = new decimal(array11);
		this.numericUpDown_10.Name = "numCountAbnObj670";
		this.numericUpDown_10.Size = new Size(185, 20);
		this.numericUpDown_10.TabIndex = 11;
		this.numericUpDown_10.ValueChanged += this.numericUpDown_16_ValueChanged;
		this.numericUpDown_11.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.numericUpDown_11.Location = new Point(9, 73);
		NumericUpDown numericUpDown12 = this.numericUpDown_11;
		int[] array12 = new int[4];
		array12[0] = 999999;
		numericUpDown12.Maximum = new decimal(array12);
		this.numericUpDown_11.Name = "numCountAbnObj150670";
		this.numericUpDown_11.Size = new Size(185, 20);
		this.numericUpDown_11.TabIndex = 10;
		this.numericUpDown_11.ValueChanged += this.numericUpDown_16_ValueChanged;
		this.numericUpDown_12.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.numericUpDown_12.Location = new Point(9, 34);
		NumericUpDown numericUpDown13 = this.numericUpDown_12;
		int[] array13 = new int[4];
		array13[0] = 999999;
		numericUpDown13.Maximum = new decimal(array13);
		this.numericUpDown_12.Name = "numCountAbnObj150";
		this.numericUpDown_12.Size = new Size(185, 20);
		this.numericUpDown_12.TabIndex = 9;
		this.numericUpDown_12.ValueChanged += this.numericUpDown_16_ValueChanged;
		this.label_39.AutoSize = true;
		this.label_39.Location = new Point(6, 96);
		this.label_39.Name = "label34";
		this.label_39.Size = new Size(62, 13);
		this.label_39.TabIndex = 7;
		this.label_39.Text = "От 670 кВт";
		this.label_40.AutoSize = true;
		this.label_40.Location = new Point(6, 57);
		this.label_40.Name = "label33";
		this.label_40.Size = new Size(98, 13);
		this.label_40.TabIndex = 5;
		this.label_40.Text = "От 150 до 670 кВт";
		this.label_41.AutoSize = true;
		this.label_41.Location = new Point(6, 18);
		this.label_41.Name = "label32";
		this.label_41.Size = new Size(64, 13);
		this.label_41.TabIndex = 0;
		this.label_41.Text = "До 150 кВт";
		this.groupBox_6.Controls.Add(this.numericUpDown_13);
		this.groupBox_6.Controls.Add(this.numericUpDown_14);
		this.groupBox_6.Controls.Add(this.label_42);
		this.groupBox_6.Controls.Add(this.label_43);
		this.groupBox_6.Location = new Point(3, 16);
		this.groupBox_6.Name = "groupBox2";
		this.groupBox_6.Size = new Size(358, 51);
		this.groupBox_6.TabIndex = 9;
		this.groupBox_6.TabStop = false;
		this.groupBox_6.Text = "1 категория надежности";
		this.numericUpDown_13.Location = new Point(225, 19);
		NumericUpDown numericUpDown14 = this.numericUpDown_13;
		int[] array14 = new int[4];
		array14[0] = 999999;
		numericUpDown14.Maximum = new decimal(array14);
		this.numericUpDown_13.Name = "numCountAbnObjCat1";
		this.numericUpDown_13.Size = new Size(96, 20);
		this.numericUpDown_13.TabIndex = 6;
		this.numericUpDown_13.ValueChanged += this.numericUpDown_16_ValueChanged;
		this.numericUpDown_14.Location = new Point(53, 18);
		NumericUpDown numericUpDown15 = this.numericUpDown_14;
		int[] array15 = new int[4];
		array15[0] = 999999;
		numericUpDown15.Maximum = new decimal(array15);
		this.numericUpDown_14.Name = "numCountAbnObjCat1Full";
		this.numericUpDown_14.Size = new Size(96, 20);
		this.numericUpDown_14.TabIndex = 5;
		this.numericUpDown_14.ValueChanged += this.numericUpDown_16_ValueChanged;
		this.label_42.AutoSize = true;
		this.label_42.Location = new Point(158, 21);
		this.label_42.Name = "label24";
		this.label_42.Size = new Size(61, 13);
		this.label_42.TabIndex = 2;
		this.label_42.Text = "Частичное";
		this.label_43.AutoSize = true;
		this.label_43.Location = new Point(6, 21);
		this.label_43.Name = "label25";
		this.label_43.Size = new Size(45, 13);
		this.label_43.TabIndex = 0;
		this.label_43.Text = "Полное";
		this.label_44.AutoSize = true;
		this.label_44.Location = new Point(9, 163);
		this.label_44.Name = "label26";
		this.label_44.Size = new Size(209, 13);
		this.label_44.TabIndex = 15;
		this.label_44.Text = "Производители электрической энергии";
		this.label_45.AutoSize = true;
		this.label_45.Location = new Point(161, 124);
		this.label_45.Name = "label27";
		this.label_45.Size = new Size(158, 13);
		this.label_45.TabIndex = 13;
		this.label_45.Text = "Электросетевая организация";
		this.label_46.AutoSize = true;
		this.label_46.Location = new Point(9, 124);
		this.label_46.Name = "label28";
		this.label_46.Size = new Size(132, 13);
		this.label_46.TabIndex = 11;
		this.label_46.Text = "3 категория надежности";
		this.groupBox_7.Controls.Add(this.numericUpDown_15);
		this.groupBox_7.Controls.Add(this.numericUpDown_16);
		this.groupBox_7.Controls.Add(this.label_47);
		this.groupBox_7.Controls.Add(this.label_48);
		this.groupBox_7.Location = new Point(3, 70);
		this.groupBox_7.Name = "groupBox3";
		this.groupBox_7.Size = new Size(358, 51);
		this.groupBox_7.TabIndex = 10;
		this.groupBox_7.TabStop = false;
		this.groupBox_7.Text = "2 категория надежности";
		this.numericUpDown_15.Location = new Point(225, 18);
		NumericUpDown numericUpDown16 = this.numericUpDown_15;
		int[] array16 = new int[4];
		array16[0] = 999999;
		numericUpDown16.Maximum = new decimal(array16);
		this.numericUpDown_15.Name = "numCountAbnObjCat2";
		this.numericUpDown_15.Size = new Size(96, 20);
		this.numericUpDown_15.TabIndex = 7;
		this.numericUpDown_15.ValueChanged += this.numericUpDown_16_ValueChanged;
		this.numericUpDown_16.Location = new Point(53, 18);
		NumericUpDown numericUpDown17 = this.numericUpDown_16;
		int[] array17 = new int[4];
		array17[0] = 999999;
		numericUpDown17.Maximum = new decimal(array17);
		this.numericUpDown_16.Name = "numCountAbnObjCat2Full";
		this.numericUpDown_16.Size = new Size(96, 20);
		this.numericUpDown_16.TabIndex = 6;
		this.numericUpDown_16.ValueChanged += this.numericUpDown_16_ValueChanged;
		this.label_47.AutoSize = true;
		this.label_47.Location = new Point(158, 21);
		this.label_47.Name = "label29";
		this.label_47.Size = new Size(61, 13);
		this.label_47.TabIndex = 2;
		this.label_47.Text = "Частичное";
		this.label_48.AutoSize = true;
		this.label_48.Location = new Point(6, 21);
		this.label_48.Name = "label30";
		this.label_48.Size = new Size(45, 13);
		this.label_48.TabIndex = 0;
		this.label_48.Text = "Полное";
		this.statusStrip_1.Items.AddRange(new ToolStripItem[]
		{
			this.toolStripDropDownButton_0,
			this.toolStripStatusLabel_3,
			this.toolStripStatusLabel_5,
			this.toolStripStatusLabel_4
		});
		this.statusStrip_1.Location = new Point(3, 594);
		this.statusStrip_1.Name = "statusStripAbnObj";
		this.statusStrip_1.Size = new Size(955, 22);
		this.statusStrip_1.TabIndex = 6;
		this.statusStrip_1.Text = "statusStrip1";
		this.toolStripDropDownButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripDropDownButton_0.Image = (Image)componentResourceManager.GetObject("toolBtnRefreshCountAbn.Image");
		this.toolStripDropDownButton_0.ImageTransparentColor = Color.Magenta;
		this.toolStripDropDownButton_0.Name = "toolBtnRefreshCountAbn";
		this.toolStripDropDownButton_0.ShowDropDownArrow = false;
		this.toolStripDropDownButton_0.Size = new Size(20, 20);
		this.toolStripDropDownButton_0.Text = "Обновить итоги";
		this.toolStripDropDownButton_0.Click += this.toolStripDropDownButton_0_Click;
		this.toolStripStatusLabel_3.Name = "labelCountPoint";
		this.toolStripStatusLabel_3.Size = new Size(306, 17);
		this.toolStripStatusLabel_3.Spring = true;
		this.toolStripStatusLabel_3.Text = "Количество точек поставки: 0";
		this.toolStripStatusLabel_5.Name = "labelCountAbnObj";
		this.toolStripStatusLabel_5.Size = new Size(306, 17);
		this.toolStripStatusLabel_5.Spring = true;
		this.toolStripStatusLabel_5.Text = "Количество объектов: 0";
		this.toolStripStatusLabel_4.Name = "labelCountAbn";
		this.toolStripStatusLabel_4.Size = new Size(306, 17);
		this.toolStripStatusLabel_4.Spring = true;
		this.toolStripStatusLabel_4.Text = "Количество абонентов: 0";
		this.button_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.button_0.DialogResult = DialogResult.Cancel;
		this.button_0.Location = new Point(880, 651);
		this.button_0.Name = "buttonClose";
		this.button_0.Size = new Size(75, 23);
		this.button_0.TabIndex = 1;
		this.button_0.Text = "Закрыть";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_0.Click += this.button_0_Click;
		this.button_1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.button_1.DialogResult = DialogResult.OK;
		this.button_1.Location = new Point(13, 651);
		this.button_1.Name = "buttonSave";
		this.button_1.Size = new Size(75, 23);
		this.button_1.TabIndex = 2;
		this.button_1.Text = "Сохранить";
		this.button_1.UseVisualStyleBackColor = true;
		this.button_1.Click += this.button_1_Click;
		this.backgroundWorker_0.DoWork += this.backgroundWorker_0_DoWork;
		this.backgroundWorker_0.RunWorkerCompleted += this.backgroundWorker_0_RunWorkerCompleted;
		this.label_20.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.label_20.AutoSize = true;
		this.label_20.Location = new Point(93, 656);
		this.label_20.Name = "labelProgress";
		this.label_20.Size = new Size(222, 13);
		this.label_20.TabIndex = 3;
		this.label_20.Text = "Загрузка отключенных трансформаторов ";
		this.label_20.Visible = false;
		this.progressBar_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.progressBar_0.Location = new Point(321, 651);
		this.progressBar_0.Name = "progressBar";
		this.progressBar_0.Size = new Size(553, 23);
		this.progressBar_0.Style = ProgressBarStyle.Marquee;
		this.progressBar_0.TabIndex = 4;
		this.progressBar_0.Visible = false;
		this.dataGridViewComboBoxColumn_4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewComboBoxColumn_4.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
		this.dataGridViewComboBoxColumn_4.FillWeight = 50f;
		this.dataGridViewComboBoxColumn_4.HeaderText = "Тип объекта";
		this.dataGridViewComboBoxColumn_4.Name = "dataGridViewComboBoxColumn1";
		this.dataGridViewComboBoxColumn_4.Resizable = DataGridViewTriState.True;
		this.dataGridViewComboBoxColumn_4.SortMode = DataGridViewColumnSortMode.Programmatic;
		this.dataGridViewTextBoxColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_0.HeaderText = "Column1";
		this.dataGridViewTextBoxColumn_0.Name = "dataGridViewTextBoxColumn1";
		this.dataGridViewTextBoxColumn_1.HeaderText = "Column2";
		this.dataGridViewTextBoxColumn_1.Name = "dataGridViewTextBoxColumn2";
		this.dataGridViewTextBoxColumn_1.Visible = false;
		this.dataGridViewButtonColumn_1.FillWeight = 40f;
		this.dataGridViewButtonColumn_1.HeaderText = "";
		this.dataGridViewButtonColumn_1.Name = "dataGridViewButtonColumn1";
		this.dataGridViewButtonColumn_1.Text = "...";
		this.dataGridViewButtonColumn_1.ToolTipText = "Выбрать объект";
		this.dataGridViewButtonColumn_1.Width = 25;
		this.dataGridViewComboBoxColumn_5.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
		this.dataGridViewComboBoxColumn_5.HeaderText = "Участок";
		this.dataGridViewComboBoxColumn_5.Name = "dataGridViewComboBoxColumn2";
		this.dataGridViewComboBoxColumn_5.Resizable = DataGridViewTriState.True;
		this.dataGridViewComboBoxColumn_5.SortMode = DataGridViewColumnSortMode.Programmatic;
		this.dataGridViewComboBoxColumn_5.Width = 60;
		this.dataGridViewComboBoxColumn_6.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewComboBoxColumn_6.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
		this.dataGridViewComboBoxColumn_6.HeaderText = "Повреждение";
		this.dataGridViewComboBoxColumn_6.Name = "dataGridViewComboBoxColumn3";
		this.dataGridViewComboBoxColumn_6.Resizable = DataGridViewTriState.True;
		this.dataGridViewComboBoxColumn_6.SortMode = DataGridViewColumnSortMode.Automatic;
		this.dataGridViewComboBoxColumn_7.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewComboBoxColumn_7.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
		this.dataGridViewComboBoxColumn_7.HeaderText = "Уточнение";
		this.dataGridViewComboBoxColumn_7.Name = "dataGridViewComboBoxColumn4";
		this.dataGridViewComboBoxColumn_7.Resizable = DataGridViewTriState.True;
		this.dataGridViewComboBoxColumn_7.SortMode = DataGridViewColumnSortMode.Automatic;
		this.dataGridViewTextBoxColumn_2.DataPropertyName = "id";
		this.dataGridViewTextBoxColumn_2.HeaderText = "Column3";
		this.dataGridViewTextBoxColumn_2.Name = "dataGridViewTextBoxColumn3";
		this.dataGridViewTextBoxColumn_2.ReadOnly = true;
		this.dataGridViewTextBoxColumn_2.Visible = false;
		this.dataGridViewTextBoxColumn_5.DataPropertyName = "idDamage";
		this.dataGridViewTextBoxColumn_5.HeaderText = "idDamage";
		this.dataGridViewTextBoxColumn_5.Name = "dataGridViewTextBoxColumn4";
		this.dataGridViewTextBoxColumn_5.Visible = false;
		this.dataGridViewTextBoxColumn_6.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_6.DataPropertyName = "countSchmObj";
		this.dataGridViewTextBoxColumn_6.HeaderText = "Количество подстанций";
		this.dataGridViewTextBoxColumn_6.Name = "dataGridViewTextBoxColumn5";
		this.dataGridViewTextBoxColumn_7.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_7.DataPropertyName = "noAdmissionKWT";
		this.dataGridViewTextBoxColumn_7.HeaderText = "Недопуск эл.энергии";
		this.dataGridViewTextBoxColumn_7.Name = "dataGridViewTextBoxColumn6";
		this.dataGridViewTextBoxColumn_8.DataPropertyName = "Sub";
		this.dataGridViewTextBoxColumn_8.HeaderText = "Подстанция";
		this.dataGridViewTextBoxColumn_8.Name = "dataGridViewTextBoxColumn13";
		this.dataGridViewTextBoxColumn_9.DataPropertyName = "idSub";
		this.dataGridViewTextBoxColumn_9.HeaderText = "idSub";
		this.dataGridViewTextBoxColumn_9.Name = "dataGridViewTextBoxColumn14";
		this.dataGridViewTextBoxColumn_9.Visible = false;
		this.dataGridViewTextBoxColumn_10.DataPropertyName = "Power";
		this.dataGridViewTextBoxColumn_10.HeaderText = "Мощность";
		this.dataGridViewTextBoxColumn_10.Name = "dataGridViewTextBoxColumn17";
		this.dataGridViewTextBoxColumn_11.DataPropertyName = "Load";
		this.dataGridViewTextBoxColumn_11.HeaderText = "Нагрузка";
		this.dataGridViewTextBoxColumn_11.Name = "dataGridViewTextBoxColumn18";
		this.toolTip_0.IsBalloon = true;
		this.toolTip_0.ShowAlways = true;
		this.contextMenuStrip_0.Items.AddRange(new ToolStripItem[]
		{
			this.toolStripMenuItem_0,
			this.toolStripMenuItem_1
		});
		this.contextMenuStrip_0.Name = "contextMenuDgvTree";
		this.contextMenuStrip_0.Size = new Size(137, 48);
		this.toolStripMenuItem_0.Name = "toolMenuItemOn";
		this.toolStripMenuItem_0.Size = new Size(136, 22);
		this.toolStripMenuItem_0.Text = "Включить";
		this.toolStripMenuItem_0.Click += this.toolStripMenuItem_0_Click;
		this.toolStripMenuItem_1.Name = "toolMenuItemOff";
		this.toolStripMenuItem_1.Size = new Size(136, 22);
		this.toolStripMenuItem_1.Text = "Отключить";
		this.toolStripMenuItem_1.Click += this.toolStripMenuItem_1_Click;
		base.AcceptButton = this.button_1;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = this.button_0;
		base.ClientSize = new Size(967, 682);
		base.Controls.Add(this.progressBar_0);
		base.Controls.Add(this.label_20);
		base.Controls.Add(this.button_1);
		base.Controls.Add(this.button_0);
		base.Controls.Add(this.tabControl_0);
		base.Name = "FormDamageHVAddEdit";
		this.Text = "FormDamageLVAddEdit";
		base.FormClosing += this.Form81_FormClosing;
		base.Load += this.Form81_Load;
		base.Shown += this.Form81_Shown;
		this.tabControl_0.ResumeLayout(false);
		this.tabPage_0.ResumeLayout(false);
		this.tabPage_0.PerformLayout();
		this.toolStrip_2.ResumeLayout(false);
		this.toolStrip_2.PerformLayout();
		this.splitContainer_0.Panel1.ResumeLayout(false);
		this.splitContainer_0.Panel1.PerformLayout();
		this.splitContainer_0.Panel2.ResumeLayout(false);
		this.splitContainer_0.ResumeLayout(false);
		((ISupportInitialize)this.class171_0).EndInit();
		this.groupBox_0.ResumeLayout(false);
		this.groupBox_0.PerformLayout();
		((ISupportInitialize)this.dataGridView_0).EndInit();
		this.groupBox_1.ResumeLayout(false);
		this.groupBox_1.PerformLayout();
		this.groupBox_2.ResumeLayout(false);
		this.groupBox_2.PerformLayout();
		this.splitContainer_1.Panel1.ResumeLayout(false);
		this.splitContainer_1.Panel1.PerformLayout();
		this.splitContainer_1.Panel2.ResumeLayout(false);
		this.splitContainer_1.Panel2.PerformLayout();
		this.splitContainer_1.ResumeLayout(false);
		((ISupportInitialize)this.dataGridViewExcelFilter_0).EndInit();
		this.tabPage_1.ResumeLayout(false);
		this.tabPage_1.PerformLayout();
		this.splitContainer_2.Panel1.ResumeLayout(false);
		this.splitContainer_2.Panel2.ResumeLayout(false);
		this.splitContainer_2.ResumeLayout(false);
		((ISupportInitialize)this.dataGridViewExcelFilter_1).EndInit();
		((ISupportInitialize)this.bindingSource_0).EndInit();
		((ISupportInitialize)this.dataSet_0).EndInit();
		((ISupportInitialize)this.dataTable_0).EndInit();
		((ISupportInitialize)this.dataTable_1).EndInit();
		((ISupportInitialize)this.treeDataGridView_0).EndInit();
		this.statusStrip_0.ResumeLayout(false);
		this.statusStrip_0.PerformLayout();
		this.toolStrip_0.ResumeLayout(false);
		this.toolStrip_0.PerformLayout();
		this.tabPage_2.ResumeLayout(false);
		this.tabPage_2.PerformLayout();
		this.splitContainer_3.Panel1.ResumeLayout(false);
		this.splitContainer_3.Panel1.PerformLayout();
		this.splitContainer_3.Panel2.ResumeLayout(false);
		this.splitContainer_3.ResumeLayout(false);
		((ISupportInitialize)this.dataGridViewExcelFilter_2).EndInit();
		((ISupportInitialize)this.bindingSource_1).EndInit();
		this.toolStrip_1.ResumeLayout(false);
		this.toolStrip_1.PerformLayout();
		this.splitContainer_4.Panel1.ResumeLayout(false);
		this.splitContainer_4.Panel1.PerformLayout();
		this.splitContainer_4.Panel2.ResumeLayout(false);
		this.splitContainer_4.Panel2.PerformLayout();
		this.splitContainer_4.ResumeLayout(false);
		((ISupportInitialize)this.numericUpDown_0).EndInit();
		((ISupportInitialize)this.numericUpDown_1).EndInit();
		((ISupportInitialize)this.numericUpDown_2).EndInit();
		this.groupBox_3.ResumeLayout(false);
		this.groupBox_3.PerformLayout();
		((ISupportInitialize)this.numericUpDown_3).EndInit();
		((ISupportInitialize)this.numericUpDown_4).EndInit();
		this.groupBox_4.ResumeLayout(false);
		this.groupBox_4.PerformLayout();
		((ISupportInitialize)this.numericUpDown_5).EndInit();
		((ISupportInitialize)this.numericUpDown_6).EndInit();
		((ISupportInitialize)this.numericUpDown_7).EndInit();
		((ISupportInitialize)this.numericUpDown_8).EndInit();
		((ISupportInitialize)this.numericUpDown_9).EndInit();
		this.groupBox_5.ResumeLayout(false);
		this.groupBox_5.PerformLayout();
		((ISupportInitialize)this.numericUpDown_10).EndInit();
		((ISupportInitialize)this.numericUpDown_11).EndInit();
		((ISupportInitialize)this.numericUpDown_12).EndInit();
		this.groupBox_6.ResumeLayout(false);
		this.groupBox_6.PerformLayout();
		((ISupportInitialize)this.numericUpDown_13).EndInit();
		((ISupportInitialize)this.numericUpDown_14).EndInit();
		this.groupBox_7.ResumeLayout(false);
		this.groupBox_7.PerformLayout();
		((ISupportInitialize)this.numericUpDown_15).EndInit();
		((ISupportInitialize)this.numericUpDown_16).EndInit();
		this.statusStrip_1.ResumeLayout(false);
		this.statusStrip_1.PerformLayout();
		this.contextMenuStrip_0.ResumeLayout(false);
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	[CompilerGenerated]
	private bool method_72(ElectricObject electricObject_0)
	{
		return electricObject_0.Id == Convert.ToInt32(this.class171_0.tJ_Damage.Rows[0]["idSchmObj"]);
	}

	private int int_0;

	private bool bool_0;

	private bool bool_1;

	private DateTime dateTime_0;

	private Class171.Class172 class172_0;

	private Class171.Class184 class184_0;

	private bool bool_2;

	private string string_0;

	private List<int> list_0;

	private Class171.Class176 class176_0;

	private TabControl tabControl_0;

	private TabPage tabPage_0;

	private TabPage tabPage_1;

	private Button button_0;

	private Button button_1;

	private ComboBoxReadOnly comboBoxReadOnly_0;

	private Label label_0;

	private Label label_1;

	private ComboBoxReadOnly comboBoxReadOnly_1;

	private DateTimePicker dateTimePicker_0;

	private Label label_2;

	private Label label_3;

	private TextBox textBox_0;

	private Label label_4;

	private DateTimePicker dateTimePicker_1;

	private Label label_5;

	private TextBox textBox_1;

	private GroupBox groupBox_0;

	private Button button_2;

	private Label label_6;

	private TextBox textBox_2;

	private RichTextBox richTextBox_0;

	private GroupBox groupBox_1;

	private NullableDateTimePicker nullableDateTimePicker_0;

	private Label label_7;

	private ComboBoxReadOnly comboBoxReadOnly_2;

	private CheckBox checkBox_0;

	private RichTextBox richTextBox_1;

	private Label label_8;

	private ComboBoxReadOnly comboBoxReadOnly_3;

	private DataGridView dataGridView_0;

	private ComboBoxReadOnly comboBoxReadOnly_4;

	private Label label_9;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

	private SplitContainer splitContainer_0;

	private ComboBoxReadOnly comboBoxReadOnly_5;

	private Label label_10;

	private SplitContainer splitContainer_1;

	private DataGridViewExcelFilter dataGridViewExcelFilter_0;

	private Label label_11;

	private Label label_12;

	private Label label_13;

	private TextBox textBox_3;

	private Label label_14;

	private TextBox textBox_4;

	private Label label_15;

	private TextBox textBox_5;

	private TextBox textBox_6;

	private Label label_16;

	private TextBox textBox_7;

	private Label label_17;

	private TextBox textBox_8;

	private Label label_18;

	private Label label_19;

	private TextBox textBox_9;

	private ToolStrip toolStrip_0;

	private ToolStripButton toolStripButton_0;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_3;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_4;

	private DataGridViewButtonColumn dataGridViewButtonColumn_0;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_1;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_2;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_3;

	private DataGridViewExcelFilter dataGridViewExcelFilter_1;

	private DataSet dataSet_0;

	private DataTable dataTable_0;

	private DataColumn dataColumn_0;

	private DataColumn dataColumn_1;

	private DataColumn dataColumn_2;

	private DataColumn dataColumn_3;

	private DataColumn dataColumn_4;

	private DataColumn dataColumn_5;

	private DataTable dataTable_1;

	private DataColumn dataColumn_6;

	private DataColumn dataColumn_7;

	private DataColumn dataColumn_8;

	private DataColumn dataColumn_9;

	private DataColumn dataColumn_10;

	private DataColumn dataColumn_11;

	private TabPage tabPage_2;

	private DataGridViewExcelFilter dataGridViewExcelFilter_2;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_5;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_6;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_7;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_8;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_9;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_10;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_11;

	private BackgroundWorker backgroundWorker_0;

	private BindingSource bindingSource_0;

	private Label label_20;

	private ProgressBar progressBar_0;

	private BindingSource bindingSource_1;

	private ToolStrip toolStrip_1;

	private ToolStripButton toolStripButton_1;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_12;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_13;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_14;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_15;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_16;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_17;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_4;

	private DataGridViewButtonColumn dataGridViewButtonColumn_1;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_5;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_6;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_7;

	private Label label_21;

	private Label label_22;

	private Button button_3;

	private GroupBox groupBox_2;

	private RichTextBox richTextBox_2;

	private Label label_23;

	private RichTextBox richTextBox_3;

	private Label label_24;

	private CheckBox checkBox_1;

	private Label label_25;

	private CheckBox checkBox_2;

	private ComboBoxReadOnly comboBoxReadOnly_6;

	private Label label_26;

	private TextBox textBox_10;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_18;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_19;

	private ComboBox comboBox_0;

	private Label label_27;

	private ComboBox comboBox_1;

	private Label label_28;

	private TextBox textBox_11;

	private Label label_29;

	private Button button_4;

	private ToolTip toolTip_0;

	private TreeDataGridView treeDataGridView_0;

	private SplitContainer splitContainer_2;

	private StatusStrip statusStrip_0;

	private ToolStripStatusLabel toolStripStatusLabel_0;

	private ToolStripStatusLabel toolStripStatusLabel_1;

	private ToolStripStatusLabel toolStripStatusLabel_2;

	private StatusStrip statusStrip_1;

	private ToolStripStatusLabel toolStripStatusLabel_3;

	private ToolStripStatusLabel toolStripStatusLabel_4;

	private DataGridViewFilterDateTimePickerColumn dataGridViewFilterDateTimePickerColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_20;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_21;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_22;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_23;

	private Class171 class171_0;

	private ContextMenuStrip contextMenuStrip_0;

	private ToolStripMenuItem toolStripMenuItem_0;

	private TreeGridColumn treeGridColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_24;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_25;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_26;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_27;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_28;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_29;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_30;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_31;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_32;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_33;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_34;

	private RadioButton radioButton_0;

	private RadioButton radioButton_1;

	private ToolStripMenuItem toolStripMenuItem_1;

	private DataColumn dataColumn_12;

	private ToolStrip toolStrip_2;

	private ToolStripButton toolStripButton_2;

	private SplitContainer splitContainer_3;

	private SplitContainer splitContainer_4;

	private GroupBox groupBox_3;

	private Label label_30;

	private Label label_31;

	private Label label_32;

	private Label label_33;

	private Label label_34;

	private GroupBox groupBox_4;

	private Label label_35;

	private Label label_36;

	private Label label_37;

	private Label label_38;

	private GroupBox groupBox_5;

	private Label label_39;

	private Label label_40;

	private Label label_41;

	private GroupBox groupBox_6;

	private Label label_42;

	private Label label_43;

	private Label label_44;

	private Label label_45;

	private Label label_46;

	private GroupBox groupBox_7;

	private Label label_47;

	private Label label_48;

	private ToolStripDropDownButton toolStripDropDownButton_0;

	private NumericUpDown numericUpDown_0;

	private NumericUpDown numericUpDown_1;

	private NumericUpDown numericUpDown_2;

	private NumericUpDown numericUpDown_3;

	private NumericUpDown numericUpDown_4;

	private NumericUpDown numericUpDown_5;

	private NumericUpDown numericUpDown_6;

	private NumericUpDown numericUpDown_7;

	private NumericUpDown numericUpDown_8;

	private NumericUpDown numericUpDown_9;

	private NumericUpDown numericUpDown_10;

	private NumericUpDown numericUpDown_11;

	private NumericUpDown numericUpDown_12;

	private NumericUpDown numericUpDown_13;

	private NumericUpDown numericUpDown_14;

	private NumericUpDown numericUpDown_15;

	private NumericUpDown numericUpDown_16;

	private ToolStripStatusLabel toolStripStatusLabel_5;

	private DataColumn dataColumn_13;

	private DataColumn dataColumn_14;

	private DataColumn dataColumn_15;

	private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_35;

	private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_1;

	private DataGridViewFilterComboBoxColumn dataGridViewFilterComboBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_36;

	private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_2;

	private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_3;

	private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_4;

	private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_5;

	private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_6;

	private delegate TreeDataGridViewNode Delegate74(TreeDataGridViewNodeCollection nodes, params object[] values);
}
