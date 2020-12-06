using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
using SchemeModel;

internal partial class Form83 : FormBase
{
	internal int method_0()
	{
		return this.int_0;
	}

	internal bool method_1()
	{
		return this.bool_1;
	}

	internal void method_2(bool bool_2)
	{
		this.bool_1 = bool_2;
		this.method_3();
	}

	private void method_3()
	{
		if (this.method_1())
		{
			this.Text = "Просмотр дефекта";
		}
		this.textBox_1.ReadOnly = this.method_1();
		this.nullableDateTimePicker_0.Enabled = !this.method_1();
		this.comboBoxReadOnly_1.ReadOnly = this.method_1();
		this.comboBoxReadOnly_0.ReadOnly = this.method_1();
		this.button_2.Enabled = !this.method_1();
		this.richTextBox_1.ReadOnly = this.method_1();
		this.comboBoxReadOnly_2.ReadOnly = (this.comboBoxReadOnly_3.ReadOnly = (this.comboBoxReadOnly_4.ReadOnly = (this.comboBoxReadOnly_5.ReadOnly = this.method_1())));
		this.textBox_4.ReadOnly = (this.textBox_3.ReadOnly = this.method_1());
		this.comboBoxReadOnly_6.ReadOnly = this.method_1();
		this.dataGridView_0.ReadOnly = this.method_1();
		this.comboBox_1.Enabled = !this.method_1();
		this.richTextBox_0.ReadOnly = this.method_1();
		this.checkBox_0.Enabled = !this.method_1();
		this.comboBox_0.Enabled = (this.nullableDateTimePicker_1.Enabled = (this.nullableDateTimePicker_2.Enabled = !this.method_1()));
		this.toolStripButton_1.Enabled = (this.toolStripButton_2.Enabled = !this.method_1());
		this.button_1.Visible = !this.method_1();
		this.toolStripButton_0.Enabled = !this.method_1();
		this.toolStripDropDownButton_0.Enabled = !this.method_1();
		this.numericUpDown_3.ReadOnly = (this.numericUpDown_4.ReadOnly = (this.numericUpDown_6.ReadOnly = (this.numericUpDown_5.ReadOnly = (this.numericUpDown_2.ReadOnly = (this.numericUpDown_1.ReadOnly = (this.numericUpDown_0.ReadOnly = this.method_1()))))));
		this.numericUpDown_13.ReadOnly = (this.numericUpDown_14.ReadOnly = (this.numericUpDown_15.ReadOnly = (this.numericUpDown_16.ReadOnly = (this.numericUpDown_9.ReadOnly = (this.numericUpDown_8.ReadOnly = (this.numericUpDown_7.ReadOnly = this.method_1()))))));
		this.numericUpDown_12.ReadOnly = (this.numericUpDown_11.ReadOnly = (this.numericUpDown_10.ReadOnly = this.method_1()));
	}

	internal Form83(int int_2 = -1, int int_3 = 1403)
	{
		
		this.int_0 = -1;
		this.int_1 = 1403;
		
		this.method_38();
		this.nullableDateTimePicker_0.Value = DateTime.Now;
		this.nullableDateTimePicker_1.Value = DateTime.Now;
		this.int_0 = int_2;
		this.int_1 = int_3;
		string str = (int_3 == 1403) ? " НН" : " ВН";
		this.Text = ((int_2 == -1) ? ("Добавить дефект" + str) : (this.method_1() ? "Просмотр дефекта" : "Редактировать дефект"));
	}

	private void Form83_Load(object sender, EventArgs e)
	{
		this.method_5();
		this.method_4();
		this.method_7();
		this.method_8();
		this.method_24();
		this.method_10();
		this.method_11(this.comboBox_1);
		this.method_11(this.comboBoxReadOnly_7);
		this.method_12();
		this.method_13();
		this.method_14();
		this.method_29();
		base.LoadFormConfig(null);
		if (this.int_0 == -1)
		{
			DataRow dataRow = this.class171_0.tJ_Damage.NewRow();
			dataRow["TypeDoc"] = this.int_1;
			dataRow["dateOwner"] = DateTime.Now;
			this.class171_0.tJ_Damage.Rows.Add(dataRow);
		}
		else
		{
			Class171.Class172 @class = new Class171.Class172();
			base.SelectSqlData(@class, true, "where id = " + this.int_0.ToString(), null, false, 0);
			if (@class.Rows.Count > 0 && @class.Rows[0]["dateDoc"] != DBNull.Value)
			{
				this.nullableDateTimePicker_0.Value = Convert.ToDateTime(@class.Rows[0]["dateDoc"]);
			}
			base.SelectSqlData(this.class171_0.tJ_Damage, true, "where id = " + this.int_0.ToString(), null, false, 0);
			if (this.class171_0.tJ_Damage.Rows.Count > 0)
			{
				if (this.class171_0.tJ_Damage.Rows[0]["typeDoc"] != DBNull.Value)
				{
					this.int_1 = Convert.ToInt32(this.class171_0.tJ_Damage.Rows[0]["typeDoc"]);
					if (this.int_1 == 1403)
					{
						this.Text += " НН";
					}
					else
					{
						this.Text += " ВН";
					}
				}
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
				if (this.class171_0.tJ_Damage.Rows[0]["is81"] != DBNull.Value && !Convert.ToBoolean(this.class171_0.tJ_Damage.Rows[0]["is81"]))
				{
					this.toolStripButton_0.Checked = true;
				}
				else
				{
					this.toolStripButton_0.Checked = false;
				}
			}
			this.method_28();
			this.method_25();
			if (this.class171_0.tJ_Damage.Rows.Count > 0)
			{
				DataTable dataTable = this.class171_0.tJ_Damage;
				if (dataTable.Rows[0]["idParent"] != DBNull.Value)
				{
					Class171.Class172 class2 = new Class171.Class172();
					base.SelectSqlData(class2, true, "where id = " + dataTable.Rows[0]["idParent"].ToString(), null, false, 0);
					if (class2.Rows.Count > 0)
					{
						dataTable = class2;
					}
				}
				Class228.smethod_5(dataTable, this.dataTable_1, this.SqlSettings);
				this.method_34(dataTable);
				this.method_37(dataTable);
				this.toolStripStatusLabel_2.Text = "Количество абонентов: " + this.dataTable_1.DefaultView.ToTable(true, new string[]
				{
					"idAbn"
				}).Rows.Count.ToString();
			}
		}
		if (this.int_1 == 1844)
		{
			this.comboBox_1.Visible = false;
		}
		this.method_9();
		this.method_30();
		this.bool_0 = false;
	}

	private void method_4()
	{
		if (this.method_0() >= 0)
		{
			DataTable dataTable = new DataTable("tJ_Damage");
			dataTable.Columns.Add("idParent", typeof(int));
			base.SelectSqlData(dataTable, true, "where id = " + this.int_0.ToString(), null, false, 0);
			if (dataTable.Rows.Count > 0 && dataTable.Rows[0]["idParent"] != DBNull.Value)
			{
				this.comboBoxReadOnly_8.ReadOnly = true;
				this.checkBox_1.Enabled = false;
				TextBoxBase textBoxBase = this.richTextBox_3;
				ComboBoxReadOnly comboBoxReadOnly = this.comboBoxReadOnly_7;
				this.richTextBox_2.ReadOnly = true;
				comboBoxReadOnly.ReadOnly = true;
				textBoxBase.ReadOnly = true;
				this.button_3.Enabled = true;
				DataTable dataTable2 = new DataTable("vJ_Damage");
				dataTable2.Columns.Add("numDoc", typeof(int));
				dataTable2.Columns.Add("dateDoc", typeof(DateTime));
				dataTable2.Columns.Add("typeDocName", typeof(string));
				dataTable2.Columns.Add("TypeDoc", typeof(int));
				dataTable2.Columns.Add("nameDoc", typeof(string), "typedocname + isnull(' №' + convert(numDoc, System.String), ' №б/н') + isnull(' от ' + convert(dateDoc, System.String), '')");
				base.SelectSqlData(dataTable2, true, "where id = " + dataTable.Rows[0]["idParent"].ToString(), null, false, 0);
				if (dataTable2.Rows.Count > 0)
				{
					this.textBox_5.Text = dataTable2.Rows[0]["nameDoc"].ToString();
					this.nullable_0 = new int?((int)Convert.ToInt16(dataTable2.Rows[0]["TypeDoc"]));
				}
				this.toolStripButton_0.Enabled = false;
			}
		}
	}

	private void Form83_Shown(object sender, EventArgs e)
	{
		this.bool_0 = false;
	}

	private void Form83_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (base.DialogResult != DialogResult.OK)
		{
			if (!this.bool_0 || this.method_1() || MessageBox.Show("Сохранить внесенные изменения", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
			{
				base.DialogResult = DialogResult.Cancel;
				return;
			}
		}
		if (!this.method_17() || !this.method_18())
		{
			base.DialogResult = DialogResult.None;
			e.Cancel = true;
			return;
		}
		if (this.method_19())
		{
			base.SaveFormConfig(null);
			base.DialogResult = DialogResult.OK;
			return;
		}
		base.DialogResult = DialogResult.None;
		e.Cancel = true;
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

	private DataTable method_6()
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

	private void method_7()
	{
		DataTable dataTable = this.method_6();
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

	private void method_8()
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

	private void method_9()
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

	private void method_10()
	{
		DataTable dataTable = this.method_6();
		if (this.nullable_0 == 1402)
		{
			if (this.class172_0 != null && this.class172_0.Rows.Count > 0 && this.class172_0.Rows[0]["idReason"] != DBNull.Value)
			{
				base.SelectSqlData(dataTable, true, string.Format(" where (ParentKey = ';ReportDaily;DamageReason;HV;' and isgroup = 0 and deleted = 0) \r\n                                            or (id = {0}) order by name", this.class172_0.Rows[0]["idReason"]), null, false, 0);
			}
			else
			{
				base.SelectSqlData(dataTable, true, " where ParentKey = ';ReportDaily;DamageReason;HV;' and isgroup = 0 and deleted = 0 order by name", null, false, 0);
			}
		}
		else if (this.class172_0 != null && this.class172_0.Rows.Count > 0 && this.class172_0.Rows[0]["idReason"] != DBNull.Value)
		{
			base.SelectSqlData(dataTable, true, string.Format(" where (ParentKey = ';ReportDaily;DamageReason;LV;' and isgroup = 0 and deleted = 0) \r\n                                            or (id = {0}) order by name", this.class172_0.Rows[0]["idReason"]), null, false, 0);
		}
		else
		{
			base.SelectSqlData(dataTable, true, " where ParentKey = ';ReportDaily;DamageReason;LV;' and isgroup = 0 and deleted = 0 order by name", null, false, 0);
		}
		this.comboBoxReadOnly_6.DisplayMember = "name";
		this.comboBoxReadOnly_6.ValueMember = "id";
		this.comboBoxReadOnly_6.DataSource = dataTable;
		this.comboBoxReadOnly_6.SelectedIndex = -1;
	}

	private void method_11(ComboBox comboBox_2)
	{
		DataTable dataTable = this.method_6();
		if (this.nullable_0 == 1402)
		{
			if (this.class172_0 != null && this.class172_0.Rows.Count > 0 && this.class172_0.Rows[0]["idCompletedWork"] != DBNull.Value)
			{
				base.SelectSqlData(dataTable, true, string.Format(" where (ParentKey = ';ReportDaily;CompletedWork;HV;' and isgroup = 0 and deleted = 0) \r\n                                            or (id = {0}) order by name", this.class172_0.Rows[0]["idCompletedWork"]), null, false, 0);
			}
			else
			{
				base.SelectSqlData(dataTable, true, " where ParentKey = ';ReportDaily;CompletedWork;HV;' and isgroup = 0 and deleted = 0 order by name", null, false, 0);
			}
		}
		else if (this.class172_0 != null && this.class172_0.Rows.Count > 0 && this.class172_0.Rows[0]["idCompletedWork"] != DBNull.Value)
		{
			base.SelectSqlData(dataTable, true, string.Format(" where (ParentKey = ';ReportDaily;CompletedWork;LV;' and isgroup = 0 and deleted = 0) \r\n                                            or (id = {0}) order by name", this.class172_0.Rows[0]["idCompletedWork"]), null, false, 0);
		}
		else
		{
			base.SelectSqlData(dataTable, true, " where ParentKey = ';ReportDaily;CompletedWork;LV;' and isgroup = 0 and deleted = 0 order by name", null, false, 0);
		}
		comboBox_2.DisplayMember = "name";
		comboBox_2.ValueMember = "id";
		comboBox_2.DataSource = dataTable;
		comboBox_2.SelectedIndex = -1;
	}

	private void method_12()
	{
		DataTable dataTable = new DataTable("vWorkerGroup");
		dataTable.Columns.Add("id", typeof(int));
		dataTable.Columns.Add("FIO", typeof(string));
		base.SelectSqlData(dataTable, true, "where ParentKey in (';GroupWorker;PersonApplDiscon;Performer;NA1;',\r\n\t\t\t\t\t\t';GroupWorker;PersonApplDiscon;Performer;NA2;',\r\n\t\t\t\t\t\t';GroupWorker;PersonApplDiscon;Performer;NA3;',\r\n\t\t\t\t\t\t';GroupWorker;PersonApplDiscon;Performer;NA4;',\r\n\t\t\t\t\t\t';GroupWorker;PersonApplDiscon;Performer;PL;',\r\n\t\t\t\t\t\t';GroupWorker;PersonApplDiscon;Performer;SKUEE;',\r\n\t\t\t\t\t\t';GroupWorker;PersonApplDiscon;Performer;SESNO;') and dateEnd is null order by fio ", null, true, 0);
		this.comboBox_0.DisplayMember = "FIO";
		this.comboBox_0.ValueMember = "id";
		this.comboBox_0.DataSource = dataTable;
		this.comboBox_0.SelectedIndex = -1;
	}

	private void method_13()
	{
		DataTable dataTable = this.method_6();
		base.SelectSqlData(dataTable, true, " where ParentKey = ';ReportDaily;DivisionApply;' and isgroup = 0 and deleted = 0 order by name", null, false, 0);
		this.comboBoxReadOnly_8.DisplayMember = "name";
		this.comboBoxReadOnly_8.ValueMember = "id";
		this.comboBoxReadOnly_8.DataSource = dataTable;
		this.comboBoxReadOnly_8.SelectedIndex = -1;
	}

	private void method_14()
	{
		DataTable dataTable = this.method_6();
		base.SelectSqlData(dataTable, true, " where  parentKey = ';SKUEE;TypeAbn;' and isGRoup = 0 and deleted  = 0", null, false, 0);
		this.dataGridViewFilterComboBoxColumn_0.DisplayMember = "name";
		this.dataGridViewFilterComboBoxColumn_0.ValueMember = "id";
		BindingSource bindingSource = new BindingSource();
		bindingSource.DataSource = dataTable;
		this.dataGridViewFilterComboBoxColumn_0.DataSource = bindingSource;
	}

	private void textBox_3_TextChanged(object sender, EventArgs e)
	{
		this.bool_0 = true;
	}

	private void nullableDateTimePicker_2_ValueChanged(object sender, EventArgs e)
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

	private void method_15(object sender, EventArgs e)
	{
		this.bool_0 = true;
	}

	private void nullableDateTimePicker_0_ValueChanged(object sender, EventArgs e)
	{
		this.bool_0 = true;
		if (this.nullableDateTimePicker_0.Value != null)
		{
			if (this.nullableDateTimePicker_0.Value != DBNull.Value)
			{
				if (Convert.ToDateTime(this.nullableDateTimePicker_0.Value).Year >= 2016)
				{
					this.textBox_1.ReadOnly = true;
					this.textBox_1.Text = null;
				}
				else
				{
					this.textBox_1.ReadOnly = false;
				}
				this.label_4.ForeColor = Color.Black;
				this.nullableDateTimePicker_1.MinDate = (this.nullableDateTimePicker_2.MinDate = Convert.ToDateTime(this.nullableDateTimePicker_0.Value));
				return;
			}
		}
		this.nullableDateTimePicker_1.MinDate = (this.nullableDateTimePicker_2.MinDate = DateTimePicker.MinimumDateTime);
		this.textBox_1.Text = null;
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

	private void comboBoxReadOnly_6_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.comboBoxReadOnly_6.SelectedIndex >= 0)
		{
			this.label_16.ForeColor = Color.Black;
		}
		this.bool_0 = true;
	}

	private void button_2_Click(object sender, EventArgs e)
	{
		Class228.smethod_0(this.SqlSettings, this.class171_0.tJ_Damage.Rows[0], this.textBox_2, ref this.bool_0, null);
		this.method_31();
	}

	private void method_16(object sender, FormClosedEventArgs e)
	{
		Form28 form = (Form28)sender;
		if (form.DialogResult == DialogResult.OK)
		{
			this.bool_0 = true;
			if (form.method_0().Count > 0)
			{
				this.class171_0.tJ_Damage.Rows[0]["idSchmObj"] = form.method_0().First<KeyValuePair<int, string>>().Key;
				this.textBox_2.Text = form.method_0().First<KeyValuePair<int, string>>().Value;
				return;
			}
			this.class171_0.tJ_Damage.Rows[0]["idSchmObj"] = DBNull.Value;
			this.textBox_2.Text = string.Empty;
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

	private bool method_17()
	{
		bool flag = true;
		if (this.nullableDateTimePicker_0.Value == null || this.nullableDateTimePicker_0.Value == DBNull.Value)
		{
			this.label_4.ForeColor = Color.Red;
			flag = false;
		}
		if (Convert.ToDateTime(this.nullableDateTimePicker_0.Value).Year < 2016 && string.IsNullOrEmpty(this.textBox_1.Text))
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
		if (this.comboBoxReadOnly_6.SelectedIndex < 0)
		{
			this.label_16.ForeColor = Color.Red;
			flag = false;
		}
		if (this.dataGridView_0.Rows.Count <= 1)
		{
			this.label_15.ForeColor = Color.Red;
			flag = false;
		}
		if (this.checkBox_0.Checked)
		{
			if (this.int_1 == 1844)
			{
				if (string.IsNullOrEmpty(this.richTextBox_0.Text))
				{
					this.label_14.ForeColor = Color.Red;
					flag = false;
				}
			}
			else if (this.comboBox_1.SelectedIndex < 0)
			{
				this.label_14.ForeColor = Color.Red;
				flag = false;
			}
			if (this.comboBox_0.SelectedIndex < 0)
			{
				this.checkBox_0.ForeColor = Color.Red;
				flag = false;
			}
			if (this.nullableDateTimePicker_1.Value == null || this.nullableDateTimePicker_1.Value == DBNull.Value)
			{
				this.label_13.ForeColor = Color.Red;
				flag = false;
			}
		}
		if (this.comboBoxReadOnly_8.SelectedIndex < 0 && !this.checkBox_1.Checked)
		{
			this.label_18.ForeColor = Color.Red;
			this.checkBox_1.ForeColor = Color.Red;
			flag = false;
		}
		if (!flag)
		{
			MessageBox.Show("Не заполнены обязательный поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		return flag;
	}

	private bool method_18()
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
				this.int_1,
				this.class171_0.tJ_Damage.Rows[0]["id"].ToString(),
				Convert.ToInt32(this.class171_0.tJ_Damage.Rows[0]["idDivision"])
			}), null, false, 0);
			return dataTable.Rows.Count <= 0 || MessageBox.Show(string.Format("Заявка с номером {0} в текущем году уже была. Хотите все равно сохранить?", this.class171_0.tJ_Damage.Rows[0]["numRequest"].ToString()), "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
		}
		return true;
	}

	private bool method_19()
	{
		if (this.nullable_0 != 1402)
		{
			if (this.comboBoxReadOnly_5.SelectedIndex >= 0 && !string.IsNullOrEmpty(this.textBox_4.Text))
			{
				int num = this.method_23();
				if (num == -1)
				{
					MessageBox.Show("Не удается создать объект - дом");
					return false;
				}
				this.class171_0.tJ_Damage.Rows[0]["idMap"] = num;
			}
			else
			{
				this.class171_0.tJ_Damage.Rows[0]["idMap"] = DBNull.Value;
			}
		}
		this.class171_0.tJ_Damage.Rows[0]["is81"] = !this.toolStripButton_0.Checked;
		this.method_20();
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
		return this.method_22() && this.method_21();
	}

	private void method_20()
	{
		if (this.class171_0.tJ_Damage.Rows[0]["idParent"] != DBNull.Value)
		{
			return;
		}
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
		this.method_33(xmlNode2);
		this.method_36(xmlNode2);
		this.class171_0.tJ_Damage.Rows[0]["CommentXml"] = xmlDocument.InnerXml;
	}

	private bool method_21()
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
				if (this.dataGridView_0.Rows[j].Cells[this.dataGridViewComboBoxColumn_4.Name].Value != null)
				{
					this.class171_0.tJ_DamageCharacter.Rows[j]["col1"] = this.dataGridView_0.Rows[j].Cells[this.dataGridViewComboBoxColumn_4.Name].Value;
				}
				else
				{
					this.class171_0.tJ_DamageCharacter.Rows[j]["col1"] = DBNull.Value;
				}
				if (this.dataGridView_0.Rows[j].Cells[this.dataGridViewComboBoxColumn_6.Name].Value != null)
				{
					this.class171_0.tJ_DamageCharacter.Rows[j]["col2"] = this.dataGridView_0.Rows[j].Cells[this.dataGridViewComboBoxColumn_6.Name].Value;
				}
				else
				{
					this.class171_0.tJ_DamageCharacter.Rows[j]["col2"] = DBNull.Value;
				}
				if (this.dataGridView_0.Rows[j].Cells[this.dataGridViewComboBoxColumn_7.Name].Value != null)
				{
					this.class171_0.tJ_DamageCharacter.Rows[j]["col3"] = this.dataGridView_0.Rows[j].Cells[this.dataGridViewComboBoxColumn_7.Name].Value;
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
				if (this.dataGridView_0.Rows[j].Cells[this.dataGridViewComboBoxColumn_5.Name].Value != null)
				{
					this.class171_0.tJ_DamageCharacter.Rows[j]["idLineSection"] = this.dataGridView_0.Rows[j].Cells[this.dataGridViewComboBoxColumn_5.Name].Value;
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
				if (this.dataGridView_0.Rows[j].Cells[this.dataGridViewComboBoxColumn_4.Name].Value != null)
				{
					dataRow["col1"] = this.dataGridView_0.Rows[j].Cells[this.dataGridViewComboBoxColumn_4.Name].Value;
				}
				if (this.dataGridView_0.Rows[j].Cells[this.dataGridViewComboBoxColumn_6.Name].Value != null)
				{
					dataRow["col2"] = this.dataGridView_0.Rows[j].Cells[this.dataGridViewComboBoxColumn_6.Name].Value;
				}
				if (this.dataGridView_0.Rows[j].Cells[this.dataGridViewComboBoxColumn_7.Name].Value != null)
				{
					dataRow["col3"] = this.dataGridView_0.Rows[j].Cells[this.dataGridViewComboBoxColumn_7.Name].Value;
				}
				if (this.dataGridView_0.Rows[j].Cells[this.dataGridViewTextBoxColumn_4.Name].Value != null)
				{
					dataRow["idSchmObj"] = this.dataGridView_0.Rows[j].Cells[this.dataGridViewTextBoxColumn_4.Name].Value;
				}
				if (this.dataGridView_0.Rows[j].Cells[this.dataGridViewComboBoxColumn_5.Name].Value != null)
				{
					dataRow["idLineSection"] = this.dataGridView_0.Rows[j].Cells[this.dataGridViewComboBoxColumn_5.Name].Value;
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

	private bool method_22()
	{
		if (this.class171_0.tJ_DamageLV.Rows.Count > 0)
		{
			this.class171_0.tJ_DamageLV.Rows[0]["idDamage"] = this.int_0;
			this.class171_0.tJ_DamageLV.Rows[0].EndEdit();
			if (!base.InsertSqlData(this.class171_0.tJ_DamageLV))
			{
				return false;
			}
			if (!base.UpdateSqlData(this.class171_0.tJ_DamageLV))
			{
				return false;
			}
			base.SelectSqlData(this.class171_0.tJ_DamageLV, true, "where idDamage = " + this.int_0.ToString(), null, false, 0);
		}
		return true;
	}

	private int method_23()
	{
		string text = string.IsNullOrEmpty(this.textBox_3.Text) ? " and HousePrefix is null " : (" and HousePrefix = '" + this.textBox_3.Text + "'");
		base.SelectSqlData(this.class171_0.tMapObj, true, string.Concat(new string[]
		{
			"where Street = ",
			this.comboBoxReadOnly_5.SelectedValue.ToString(),
			" and House = ",
			this.textBox_4.Text,
			text,
			" and IsHouse = 1 and Name is null"
		}), null, false, 0);
		if (this.class171_0.tMapObj.Rows.Count > 0)
		{
			return Convert.ToInt32(this.class171_0.tMapObj.Rows[0]["idMap"]);
		}
		DataRow dataRow = this.class171_0.tMapObj.NewRow();
		dataRow["Street"] = this.comboBoxReadOnly_5.SelectedValue;
		dataRow["House"] = this.textBox_4.Text;
		if (!string.IsNullOrEmpty(this.textBox_3.Text))
		{
			dataRow["HousePrefix"] = this.textBox_3.Text;
		}
		dataRow["IsHouse"] = true;
		dataRow["Deleted"] = 0;
		this.class171_0.tMapObj.Rows.Add(dataRow);
		this.class171_0.tMapObj.Rows[0].EndEdit();
		return base.InsertSqlDataOneRow(this.class171_0, this.class171_0.tMapObj);
	}

	private void method_24()
	{
		DataTable dataTable = Class228.MyrCoTyHjHw();
		base.SelectSqlData(dataTable, true, " where PrimaryKey = 'Subject' and deleted = 0 order by name, socr", null, false, 0);
		this.comboBoxReadOnly_2.DisplayMember = "fullname";
		this.comboBoxReadOnly_2.ValueMember = "id";
		this.comboBoxReadOnly_2.DataSource = dataTable;
	}

	private void comboBoxReadOnly_2_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.comboBoxReadOnly_2.SelectedIndex < 0)
		{
			this.comboBoxReadOnly_3.DataSource = null;
			return;
		}
		this.label_7.ForeColor = Color.Black;
		DataTable dataTable = Class228.MyrCoTyHjHw();
		base.SelectSqlData(dataTable, true, " where ParentId = " + this.comboBoxReadOnly_2.SelectedValue.ToString() + " and deleted = 0 order by name, socr", null, false, 0);
		this.comboBoxReadOnly_3.DisplayMember = "fullname";
		this.comboBoxReadOnly_3.ValueMember = "id";
		this.comboBoxReadOnly_3.DataSource = dataTable;
		this.comboBoxReadOnly_3.SelectedIndex = -1;
	}

	private void comboBoxReadOnly_3_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.comboBoxReadOnly_3.SelectedIndex < 0)
		{
			this.comboBoxReadOnly_4.DataSource = null;
			this.comboBoxReadOnly_5.DataSource = null;
			return;
		}
		this.label_8.ForeColor = Color.Black;
		DataTable dataTable = Class228.MyrCoTyHjHw();
		base.SelectSqlData(dataTable, true, " where ParentId = " + this.comboBoxReadOnly_3.SelectedValue.ToString() + " and deleted = 0 order by name, socr", null, false, 0);
		this.comboBoxReadOnly_4.DisplayMember = "fullname";
		this.comboBoxReadOnly_4.ValueMember = "id";
		this.comboBoxReadOnly_4.DataSource = dataTable;
		this.comboBoxReadOnly_4.SelectedIndex = -1;
		DataTable dataTable2 = Class228.smethod_2();
		base.SelectSqlData(dataTable2, true, " where KladrObjId = " + this.comboBoxReadOnly_3.SelectedValue + " and deleted = 0 order by name, socr ", null, false, 0);
		this.comboBoxReadOnly_5.DisplayMember = "fullname";
		this.comboBoxReadOnly_5.ValueMember = "id";
		this.comboBoxReadOnly_5.DataSource = dataTable2;
		this.comboBoxReadOnly_5.SelectedIndex = -1;
	}

	private void comboBoxReadOnly_4_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.comboBoxReadOnly_4.SelectedIndex >= 0)
		{
			DataTable dataTable = Class228.smethod_2();
			base.SelectSqlData(dataTable, true, " where KladrObjId = " + this.comboBoxReadOnly_4.SelectedValue + " and deleted = 0 order by name, socr ", null, false, 0);
			this.comboBoxReadOnly_5.DisplayMember = "fullname";
			this.comboBoxReadOnly_5.ValueMember = "id";
			this.comboBoxReadOnly_5.DataSource = dataTable;
			this.comboBoxReadOnly_5.SelectedIndex = -1;
		}
	}

	private void comboBoxReadOnly_5_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.bool_0 = true;
		if (this.comboBoxReadOnly_5.SelectedIndex >= 0)
		{
			this.label_10.ForeColor = Color.Black;
		}
	}

	private void textBox_4_TextChanged(object sender, EventArgs e)
	{
		this.bool_0 = true;
		if (!string.IsNullOrEmpty(this.textBox_4.Text))
		{
			this.label_12.ForeColor = Color.Black;
		}
	}

	private void method_25()
	{
		if (this.class171_0.tJ_Damage.Rows[0]["idmap"] == DBNull.Value && this.class171_0.tJ_Damage.Rows[0]["idStreet"] == DBNull.Value)
		{
			return;
		}
		if (this.class171_0.tJ_Damage.Rows[0]["idmap"] != DBNull.Value)
		{
			base.SelectSqlData(this.class171_0.tMapObj, true, " where idMap = " + this.class171_0.tJ_Damage.Rows[0]["idmap"].ToString(), null, false, 0);
			this.textBox_4.Text = this.class171_0.tMapObj.Rows[0]["House"].ToString();
			this.textBox_3.Text = this.class171_0.tMapObj.Rows[0]["HousePrefix"].ToString();
		}
		DataTable dataTable = Class228.smethod_2();
		if (this.class171_0.tMapObj.Rows.Count > 0)
		{
			base.SelectSqlData(dataTable, true, " where id = " + this.class171_0.tMapObj.Rows[0]["Street"].ToString(), null, false, 0);
		}
		else if (this.class171_0.tJ_Damage.Rows[0]["idStreet"] != DBNull.Value)
		{
			base.SelectSqlData(dataTable, true, " where id = " + this.class171_0.tJ_Damage.Rows[0]["idStreet"].ToString(), null, false, 0);
		}
		int int_ = 24;
		if (dataTable.Rows.Count > 0)
		{
			int_ = Convert.ToInt32(dataTable.Rows[0]["KladrObjId"]);
		}
		List<DataRow> list_ = new List<DataRow>();
		this.method_26(int_, list_);
		this.method_27(list_);
		if (this.class171_0.tMapObj.Rows.Count > 0 && this.class171_0.tMapObj.Rows[0]["Street"] != DBNull.Value)
		{
			this.comboBoxReadOnly_5.SelectedValue = this.class171_0.tMapObj.Rows[0]["Street"];
			return;
		}
		if (this.class171_0.tJ_Damage.Rows[0]["idStreet"] != DBNull.Value)
		{
			this.comboBoxReadOnly_5.SelectedValue = this.class171_0.tJ_Damage.Rows[0]["idStreet"];
		}
	}

	private void method_26(int int_2, List<DataRow> list_0)
	{
		DataTable dataTable = Class228.MyrCoTyHjHw();
		base.SelectSqlData(dataTable, true, " where id = " + int_2.ToString(), null, false, 0);
		if (dataTable.Rows.Count != 0 && (dataTable.Rows[0]["PrimaryKey"] == DBNull.Value || !(dataTable.Rows[0]["PrimaryKey"].ToString() == "Country")))
		{
			if (dataTable.Rows[0]["ParentId"] != DBNull.Value)
			{
				list_0.Add(dataTable.Rows[0]);
				this.method_26(Convert.ToInt32(dataTable.Rows[0]["ParentId"]), list_0);
				return;
			}
		}
	}

	private void method_27(List<DataRow> list_0)
	{
		DataTable dataTable = Class228.MyrCoTyHjHw();
		switch (list_0.Count)
		{
		case 0:
			this.comboBoxReadOnly_2.SelectedIndex = -1;
			this.comboBoxReadOnly_2.DisplayMember = "namefull";
			this.comboBoxReadOnly_2.ValueMember = "id";
			this.comboBoxReadOnly_2.DataSource = dataTable;
			base.SelectSqlData(dataTable, true, " where PrimaryKey = 'Subject' and deleted = 0 order by name, socr", null, false, 0);
			this.comboBoxReadOnly_2.SelectedIndex = -1;
			this.comboBoxReadOnly_2.SelectedIndex = 0;
			return;
		case 1:
			this.comboBoxReadOnly_2.SelectedIndex = -1;
			this.comboBoxReadOnly_2.DisplayMember = "namefull";
			this.comboBoxReadOnly_2.ValueMember = "id";
			this.comboBoxReadOnly_2.DataSource = dataTable;
			base.SelectSqlData(dataTable, true, " where ParentId = " + list_0[0]["ParentId"].ToString() + " and deleted = 0 order by name, socr", null, false, 0);
			this.comboBoxReadOnly_2.SelectedIndex = -1;
			this.comboBoxReadOnly_2.SelectedValue = Convert.ToInt32(list_0[0]["Id"]);
			return;
		case 2:
			this.comboBoxReadOnly_2.SelectedIndex = -1;
			this.comboBoxReadOnly_2.DisplayMember = "namefull";
			this.comboBoxReadOnly_2.ValueMember = "id";
			this.comboBoxReadOnly_2.DataSource = dataTable;
			base.SelectSqlData(dataTable, true, " where ParentId = " + list_0[1]["ParentId"].ToString() + " and deleted = 0 order by name, socr", null, false, 0);
			this.comboBoxReadOnly_2.SelectedIndex = -1;
			this.comboBoxReadOnly_2.SelectedValue = Convert.ToInt32(list_0[1]["Id"]);
			this.comboBoxReadOnly_3.SelectedValue = Convert.ToInt32(list_0[0]["Id"]);
			return;
		}
		this.comboBoxReadOnly_2.SelectedIndex = -1;
		this.comboBoxReadOnly_2.DisplayMember = "namefull";
		this.comboBoxReadOnly_2.ValueMember = "id";
		this.comboBoxReadOnly_2.DataSource = dataTable;
		base.SelectSqlData(dataTable, true, " where ParentId = " + list_0[2]["ParentId"].ToString() + " and deleted = 0 order by name, socr", null, false, 0);
		this.comboBoxReadOnly_2.SelectedIndex = -1;
		this.comboBoxReadOnly_2.SelectedValue = Convert.ToInt32(list_0[2]["Id"]);
		this.comboBoxReadOnly_3.SelectedValue = Convert.ToInt32(list_0[1]["Id"]);
		this.comboBoxReadOnly_4.SelectedValue = Convert.ToInt32(list_0[0]["Id"]);
	}

	protected override XmlDocument CreateXmlConfig()
	{
		XmlDocument xmlDocument = new XmlDocument();
		XmlNode newChild = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", null);
		xmlDocument.AppendChild(newChild);
		XmlNode xmlNode = xmlDocument.CreateElement(base.Name);
		xmlDocument.AppendChild(xmlNode);
		if (this.comboBoxReadOnly_2.SelectedValue != null)
		{
			XmlAttribute xmlAttribute = xmlDocument.CreateAttribute("idObl");
			xmlAttribute.Value = this.comboBoxReadOnly_2.SelectedValue.ToString();
			xmlNode.Attributes.Append(xmlAttribute);
		}
		if (this.comboBoxReadOnly_3.SelectedValue != null)
		{
			XmlAttribute xmlAttribute2 = xmlDocument.CreateAttribute("idRaionObl");
			xmlAttribute2.Value = this.comboBoxReadOnly_3.SelectedValue.ToString();
			xmlNode.Attributes.Append(xmlAttribute2);
		}
		return xmlDocument;
	}

	protected override void ApplyConfig(XmlDocument xmlDocument_0)
	{
		XmlNode xmlNode = xmlDocument_0.SelectSingleNode(base.Name);
		if (xmlNode != null)
		{
			XmlAttribute xmlAttribute = xmlNode.Attributes["idObl"];
			if (xmlAttribute != null)
			{
				this.comboBoxReadOnly_2.SelectedValue = Convert.ToInt32(xmlAttribute.Value);
			}
			xmlAttribute = xmlNode.Attributes["idRaionObl"];
			if (xmlAttribute != null)
			{
				this.comboBoxReadOnly_3.SelectedValue = Convert.ToInt32(xmlAttribute.Value);
			}
		}
	}

	private void method_28()
	{
		this.dataGridView_0.Rows.Clear();
		base.SelectSqlData(this.class171_0.tJ_DamageCharacter, true, "where idDamage = " + this.int_0.ToString(), null, false, 0);
		int num = 0;
		foreach (DataRow dataRow in this.class171_0.tJ_DamageCharacter)
		{
			this.dataGridView_0.Rows.Add();
			if (dataRow["col1"] != DBNull.Value)
			{
				this.dataGridView_0.CurrentCell = this.dataGridView_0.Rows[num].Cells[this.dataGridViewComboBoxColumn_4.Name];
				this.dataGridView_0.Rows[num].Cells[this.dataGridViewComboBoxColumn_4.Name].Value = dataRow["col1"];
				DataTable dataTable = this.method_6();
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
				DataGridViewComboBoxCell dataGridViewComboBoxCell = this.dataGridView_0[this.dataGridViewComboBoxColumn_6.Index, num] as DataGridViewComboBoxCell;
				dataGridViewComboBoxCell.DataSource = dataTable;
				dataGridViewComboBoxCell.DisplayMember = "name";
				dataGridViewComboBoxCell.ValueMember = "id";
			}
			if (dataRow["col2"] != DBNull.Value)
			{
				this.dataGridView_0.CurrentCell = this.dataGridView_0.Rows[num].Cells[this.dataGridViewComboBoxColumn_4.Name];
				this.dataGridView_0.Rows[num].Cells[this.dataGridViewComboBoxColumn_6.Name].Value = dataRow["col2"];
				DataTable dataTable2 = this.method_6();
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
				DataGridViewComboBoxCell dataGridViewComboBoxCell2 = this.dataGridView_0[this.dataGridViewComboBoxColumn_7.Index, num] as DataGridViewComboBoxCell;
				dataGridViewComboBoxCell2.DataSource = dataTable2;
				dataGridViewComboBoxCell2.DisplayMember = "name";
				dataGridViewComboBoxCell2.ValueMember = "id";
			}
			if (dataRow["col3"] != DBNull.Value)
			{
				this.dataGridView_0.Rows[num].Cells[this.dataGridViewComboBoxColumn_7.Name].Value = dataRow["col3"];
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
				DataGridViewComboBoxCell dataGridViewComboBoxCell3 = this.dataGridView_0[this.dataGridViewComboBoxColumn_5.Index, num] as DataGridViewComboBoxCell;
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

	private void method_29()
	{
		int value = this.int_1;
		if (this.nullable_0 != null)
		{
			value = this.nullable_0.Value;
		}
		this.dataGridViewTextBoxColumn_3.Visible = (this.dataGridViewComboBoxColumn_5.Visible = (value == 1402 || value == 1844));
		this.dataGridViewButtonColumn_0.Visible = (value == 1844);
		DataGridViewBand dataGridViewBand = this.dataGridViewComboBoxColumn_6;
		this.dataGridViewComboBoxColumn_7.Visible = true;
		dataGridViewBand.Visible = true;
		DataTable dataTable = this.method_6();
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
		switch (value)
		{
		case 1401:
		case 1403:
			if (string.IsNullOrEmpty(text))
			{
				base.SelectSqlData(dataTable, true, "where ParentId in (select id from \r\n                                        tr_classifier where ParentKey = ';ReportDaily;NatureDamage;LV;') \r\n                                        and isGroup = 1 and deleted = 0 order by ParentKey", null, false, 0);
				goto IL_1CC;
			}
			base.SelectSqlData(dataTable, true, string.Format("where (ParentId in (select id from \r\n                                        tr_classifier where ParentKey = ';ReportDaily;NatureDamage;LV;') \r\n                                        and isGroup = 1 and deleted = 0) or \r\n                                        (id in ({0})) order by ParentKey", text), null, false, 0);
			goto IL_1CC;
		case 1402:
			break;
		default:
			if (value != 1844)
			{
				goto IL_1CC;
			}
			break;
		}
		if (string.IsNullOrEmpty(text))
		{
			base.SelectSqlData(dataTable, true, "where ParentId in (select id from \r\n                                        tr_classifier where ParentKey = ';ReportDaily;NatureDamage;HV;') \r\n                                        and isGroup = 1 and deleted = 0 order by ParentKey", null, false, 0);
		}
		else
		{
			base.SelectSqlData(dataTable, true, string.Format("where (ParentId in (select id from \r\n                                        tr_classifier where ParentKey = ';ReportDaily;NatureDamage;HV;') \r\n                                        and isGroup = 1 and deleted = 0) or \r\n                                        (id in ({0})) order by ParentKey", text), null, false, 0);
		}
		IL_1CC:
		BindingSource bindingSource = new BindingSource();
		bindingSource.DataSource = dataTable;
		bindingSource.Position = -1;
		this.dataGridViewComboBoxColumn_4.DisplayMember = "name";
		this.dataGridViewComboBoxColumn_4.ValueMember = "id";
		this.dataGridViewComboBoxColumn_4.DataSource = bindingSource;
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
			this.label_15.ForeColor = Color.Black;
			if ((this.dataGridView_0.CurrentCell.ColumnIndex == this.dataGridViewComboBoxColumn_4.Index || this.dataGridView_0.CurrentCell.ColumnIndex == this.dataGridViewComboBoxColumn_6.Index) && this.dataGridView_0.CurrentCell.Value != null)
			{
				DataTable dataTable = this.method_6();
				base.SelectSqlData(dataTable, true, string.Format(" where parentId = {0} and isGroup = 1 and Deleted = 0 order by parentKey", this.dataGridView_0.CurrentCell.Value), null, false, 0);
				int columnIndex = (this.dataGridView_0.CurrentCell.ColumnIndex == this.dataGridViewComboBoxColumn_4.Index) ? this.dataGridViewComboBoxColumn_6.Index : ((this.dataGridView_0.CurrentCell.ColumnIndex == this.dataGridViewComboBoxColumn_6.Index) ? this.dataGridViewComboBoxColumn_7.Index : -1);
				DataGridViewComboBoxCell dataGridViewComboBoxCell = this.dataGridView_0[columnIndex, this.dataGridView_0.CurrentRow.Index] as DataGridViewComboBoxCell;
				dataGridViewComboBoxCell.DataSource = dataTable;
				dataGridViewComboBoxCell.DisplayMember = "name";
				dataGridViewComboBoxCell.ValueMember = "id";
				if (dataGridViewComboBoxCell.Value != null && dataTable.Select("id = " + dataGridViewComboBoxCell.Value.ToString()).Length == 0)
				{
					dataGridViewComboBoxCell.Value = null;
				}
				if (dataGridViewComboBoxCell.Value == null && dataGridViewComboBoxCell.ColumnIndex == this.dataGridViewComboBoxColumn_6.Index)
				{
					DataGridViewComboBoxCell dataGridViewComboBoxCell2 = this.dataGridView_0[this.dataGridViewComboBoxColumn_7.Index, this.dataGridView_0.CurrentRow.Index] as DataGridViewComboBoxCell;
					dataGridViewComboBoxCell2.DataSource = null;
					dataGridViewComboBoxCell2.Value = null;
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
			if (this.dataGridView_0[this.dataGridViewComboBoxColumn_4.Index, e.RowIndex].Value == null)
			{
				MessageBox.Show("Не выбран тип объекта");
				return;
			}
			DataTable dataTable = this.method_6();
			dataTable.Columns.Add("ParentKey", typeof(string));
			base.SelectSqlData(dataTable, true, " where id = " + this.dataGridView_0[this.dataGridViewComboBoxColumn_4.Index, e.RowIndex].Value.ToString(), null, false, 0);
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
			DataGridViewComboBoxCell dataGridViewComboBoxCell = this.dataGridView_0[this.dataGridViewComboBoxColumn_5.Index, e.RowIndex] as DataGridViewComboBoxCell;
			if (!(dataTable.Rows[0]["ParentKey"].ToString() == ";ReportDaily;NatureDamage;HV;AirLine;") && !(dataTable.Rows[0]["ParentKey"].ToString() == ";ReportDaily;NatureDamage;HV;CableLine;"))
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
			}
			else
			{
				Form26 form2 = new Form26(list);
				form2.method_5(false);
				form2.SqlSettings = this.SqlSettings;
				if (form2.ShowDialog() == DialogResult.OK)
				{
					this.dataGridView_0[this.dataGridViewTextBoxColumn_3.Name, e.RowIndex].Value = form2.method_0().string_0;
					this.dataGridView_0[this.dataGridViewTextBoxColumn_4.Name, e.RowIndex].Value = form2.method_0().int_0;
					DataTable dataTable2 = new DataTable("tP_CabSection");
					dataTable2.Columns.Add("id", typeof(int));
					dataTable2.Columns.Add("number", typeof(int));
					base.SelectSqlData(dataTable2, true, "where idObjList = " + form2.method_0().int_0.ToString() + " order by number", null, false, 0);
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

	private void method_30()
	{
		if (!this.method_1() && (this.checkBox_0.Checked || this.class171_0.tJ_Damage.Rows[0]["idParent"] != DBNull.Value))
		{
			this.textBox_1.ReadOnly = true;
			this.nullableDateTimePicker_0.Enabled = false;
			this.comboBoxReadOnly_1.ReadOnly = true;
			this.comboBoxReadOnly_0.ReadOnly = true;
			this.button_2.Enabled = false;
			ComboBoxReadOnly comboBoxReadOnly = this.comboBoxReadOnly_2;
			ComboBoxReadOnly comboBoxReadOnly2 = this.comboBoxReadOnly_3;
			ComboBoxReadOnly comboBoxReadOnly3 = this.comboBoxReadOnly_4;
			this.comboBoxReadOnly_5.ReadOnly = true;
			comboBoxReadOnly3.ReadOnly = true;
			comboBoxReadOnly2.ReadOnly = true;
			comboBoxReadOnly.ReadOnly = true;
			TextBoxBase textBoxBase = this.textBox_4;
			this.textBox_3.ReadOnly = true;
			textBoxBase.ReadOnly = true;
			this.richTextBox_1.ReadOnly = true;
			this.comboBoxReadOnly_6.ReadOnly = true;
			this.dataGridView_0.ReadOnly = true;
			if (this.checkBox_0.Checked)
			{
				this.groupBox_1.Enabled = false;
			}
			ToolStripItem toolStripItem = this.toolStripButton_1;
			this.toolStripButton_2.Enabled = false;
			toolStripItem.Enabled = false;
			this.toolStripButton_0.Enabled = false;
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

	private void comboBox_1_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.bool_0 = true;
		if (this.int_1 == 1403 && this.comboBox_1.SelectedIndex >= 0)
		{
			this.label_14.ForeColor = Color.Black;
		}
	}

	private void richTextBox_0_TextChanged(object sender, EventArgs e)
	{
		this.bool_0 = true;
		if (this.int_1 == 1844 && !string.IsNullOrEmpty(this.richTextBox_0.Text))
		{
			this.label_14.ForeColor = Color.Black;
		}
	}

	private void comboBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.bool_0 = true;
		if (this.comboBox_0.SelectedIndex >= 0)
		{
			this.checkBox_0.ForeColor = Color.Black;
		}
	}

	private void nullableDateTimePicker_1_ValueChanged(object sender, EventArgs e)
	{
		this.bool_0 = true;
		if (this.nullableDateTimePicker_1.Value != null)
		{
			this.label_14.ForeColor = Color.Black;
		}
	}

	private void button_3_Click(object sender, EventArgs e)
	{
		if (this.class171_0.tJ_Damage.Rows.Count > 0 && this.class171_0.tJ_Damage.Rows[0]["idParent"] != DBNull.Value)
		{
			DataTable dataTable = new DataTable("tJ_Damage");
			dataTable.Columns.Add("TypeDoc", typeof(int));
			base.SelectSqlData(dataTable, true, "where id = " + this.class171_0.tJ_Damage.Rows[0]["idParent"].ToString(), null, false, 0);
			if (dataTable.Rows.Count > 0)
			{
				int num = Convert.ToInt32(dataTable.Rows[0]["TYpeDoc"]);
				if (num == 1401)
				{
					Form84 form = new Form84(Convert.ToInt32(this.class171_0.tJ_Damage.Rows[0]["idParent"]), (Enum20)1401);
					form.SqlSettings = this.SqlSettings;
					form.MdiParent = base.MdiParent;
					form.method_2(true);
					form.Show();
					return;
				}
				if (num != 1402)
				{
					return;
				}
				Form81 form2 = new Form81(Convert.ToInt32(this.class171_0.tJ_Damage.Rows[0]["idParent"]));
				form2.SqlSettings = this.SqlSettings;
				form2.MdiParent = base.MdiParent;
				form2.method_2(true);
				form2.Show();
			}
		}
	}

	private void comboBoxReadOnly_8_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.comboBoxReadOnly_8.SelectedIndex >= 0)
		{
			this.label_18.ForeColor = Color.Black;
			this.checkBox_1.ForeColor = Color.Black;
		}
		this.bool_0 = true;
	}

	private void checkBox_1_CheckedChanged(object sender, EventArgs e)
	{
		if (this.checkBox_1.Checked)
		{
			this.label_18.ForeColor = Color.Black;
			this.checkBox_1.ForeColor = Color.Black;
		}
		this.bool_0 = true;
	}

	private void comboBoxReadOnly_8_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
		{
			this.comboBoxReadOnly_8.SelectedIndex = -1;
			this.bool_0 = true;
		}
	}

	private void toolStripButton_0_CheckedChanged(object sender, EventArgs e)
	{
		if (this.toolStripButton_0.Checked)
		{
			this.toolStripButton_0.ToolTipText = "Не использовать в бюллетене 8.1";
			this.toolStripButton_0.Image = Resources.not81;
		}
		else
		{
			this.toolStripButton_0.ToolTipText = "Использовать в бюллетене 8.1";
			this.toolStripButton_0.Image = Resources.in81;
		}
		this.bool_0 = true;
	}

	private void toolStripButton_1_Click(object sender, EventArgs e)
	{
		this.method_31();
	}

	private void method_31()
	{
		if (this.class171_0.tJ_Damage.Rows.Count > 0 && this.class171_0.tJ_Damage.Rows[0]["idSchmObj"] != DBNull.Value)
		{
			Control control = this.label_42;
			this.progressBar_0.Visible = true;
			control.Visible = true;
			this.toolStripButton_1.Enabled = false;
			this.button_2.Enabled = false;
			this.dataGridViewExcelFilter_0.Enabled = false;
			this.dataGridViewExcelFilter_0.DataSource = null;
			Control control2 = this.button_0;
			this.button_1.Enabled = false;
			control2.Enabled = false;
			this.backgroundWorker_0.RunWorkerAsync(this.nullableDateTimePicker_0.Value);
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
		electricModel.PoweringReportForDrawObject(Convert.ToInt32(this.class171_0.tJ_Damage.Rows[0]["idSchmObj"]), true);
		IEnumerable<ElectricObject> source = electricModel.Objects.Where(new Func<ElectricObject, bool>(this.method_39));
		List<ElectricObject> list_ = electricModel.PoweringReportForDrawObject(source.First<ElectricObject>(), true, true);
		DateTime dateTime_ = DateTime.Now;
		if (this.nullableDateTimePicker_0.Value != null && this.nullableDateTimePicker_0.Value != DBNull.Value)
		{
			dateTime_ = Convert.ToDateTime(this.nullableDateTimePicker_0.Value);
		}
		Class228.smethod_6(this.dataTable_1, this.SqlSettings, list_, dateTime_);
		this.toolStripStatusLabel_2.Text = "Количество абонентов: " + this.dataTable_1.DefaultView.ToTable(true, new string[]
		{
			"idAbn"
		}).Rows.Count.ToString();
	}

	private void backgroundWorker_0_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		Control control = this.label_42;
		this.progressBar_0.Visible = false;
		control.Visible = false;
		this.toolStripButton_1.Enabled = true;
		this.dataGridViewExcelFilter_0.Enabled = true;
		this.dataGridViewExcelFilter_0.DataSource = this.bindingSource_0;
		Control control2 = this.button_0;
		this.button_1.Enabled = true;
		control2.Enabled = true;
		this.button_2.Enabled = true;
		this.method_32();
		this.method_35();
	}

	private void toolStripButton_2_Click(object sender, EventArgs e)
	{
		if (this.dataGridViewExcelFilter_0.SelectedRows.Count > 0 && MessageBox.Show("Вы действительно хотите удалить выбранные строки?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
		{
			foreach (object obj in this.dataGridViewExcelFilter_0.SelectedRows)
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
				this.dataGridViewExcelFilter_0.Rows.Remove(dataGridViewRow);
			}
			this.method_32();
			this.method_35();
		}
	}

	private void toolStripDropDownButton_0_Click(object sender, EventArgs e)
	{
		this.method_32();
		this.method_35();
	}

	private void method_32()
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
		if (this.nullableDateTimePicker_0.Value != null)
		{
			if (this.nullableDateTimePicker_0.Value != DBNull.Value)
			{
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
				DataTable dataTable = new SqlDataCommand(this.SqlSettings).SelectSqlData(string.Format("select ao.id,\r\n                                        case when a.TypeAbn = 231 then -1 -- сетевая организация\r\n                                        else case when a.typeAbn = 206 and r.category is null then 493 -- если у физика нет категории - ставим ему третью\r\n                                        else case when category is null then 493 else r.category end end end as category\r\n                                     from tAbnObj ao \r\n\t                                    left join tAbn a on a.id = ao.idAbn\r\n\t                                    left join tAbnObjReg r on r.id = (select top 1 id from tAbnObjREg \r\n\t\t\t\t\t\t\t                where idAbnObj = ao.id\r\n\t\t\t\t\t\t\t                order by datechange desc)\r\n                                        left join tPoint p on p.idAbnObj = ao.id and p.dateBegin <= '{0}' and \r\n                                                                (p.dateEnd  >= '{0}' or p.dateEnd is null)\r\n\t                                    /*left join tPointReg pReg on pReg.id = (select top 1 id from tPointReg\r\n\t\t\t\t\t\t\t\t\t\t                                      where idPoint = p.id \r\n\t\t\t\t\t\t\t\t\t\t\t                        and dateBegin <= '{0}' and \r\n                                                                    (dateEnd  >= '{0}' or dateEnd is null)\r\n\t\t\t\t\t\t\t\t\t                                order by dateBegin desc)*/\r\n                                     where ao.id in ({1}) \r\n                                        and p.id is not null --and pREg.id is not null", Convert.ToDateTime(this.nullableDateTimePicker_0.Value).ToString("yyyyMMdd"), text));
				this.numericUpDown_3.Value = Convert.ToInt32(dataTable.Compute("count(id)", "category in (491,494)"));
				this.numericUpDown_6.Value = Convert.ToInt32(dataTable.Compute("count(id)", "category = 492"));
				this.numericUpDown_2.Value = Convert.ToInt32(dataTable.Compute("count(id)", "category = 493"));
				this.numericUpDown_1.Value = Convert.ToInt32(dataTable.Compute("count(id)", "category = -1"));
				return;
			}
		}
	}

	private void method_33(XmlNode xmlNode_0)
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

	private void method_34(DataTable dataTable_2)
	{
		if (dataTable_2.Rows.Count > 0 && dataTable_2.Rows[0]["CommentXml"] != DBNull.Value)
		{
			try
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.LoadXml(dataTable_2.Rows[0]["CommentXml"].ToString());
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
		this.toolStripStatusLabel_0.Text = "Количество точек поставки: " + (this.numericUpDown_3.Value + this.numericUpDown_4.Value + this.numericUpDown_6.Value + this.numericUpDown_5.Value + this.numericUpDown_2.Value + this.numericUpDown_1.Value + this.numericUpDown_0.Value).ToString();
	}

	private void method_35()
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

	private void method_36(XmlNode xmlNode_0)
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

	private void method_37(DataTable dataTable_2)
	{
		if (dataTable_2.Rows.Count > 0 && dataTable_2.Rows[0]["CommentXml"] != DBNull.Value)
		{
			try
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.LoadXml(dataTable_2.Rows[0]["CommentXml"].ToString());
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
		this.toolStripStatusLabel_1.Text = "Количество объектов: " + (this.numericUpDown_13.Value + this.numericUpDown_14.Value + this.numericUpDown_15.Value + this.numericUpDown_16.Value + this.numericUpDown_9.Value + this.numericUpDown_8.Value + this.numericUpDown_7.Value).ToString();
	}

	private void method_38()
	{
		this.icontainer_0 = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form83));
		this.tabControl_0 = new TabControl();
		this.tabPage_0 = new TabPage();
		this.toolStrip_0 = new ToolStrip();
		this.toolStripButton_0 = new ToolStripButton();
		this.comboBoxReadOnly_8 = new ComboBoxReadOnly();
		this.class171_0 = new Class171();
		this.splitContainer_0 = new SplitContainer();
		this.groupBox_0 = new GroupBox();
		this.richTextBox_1 = new RichTextBox();
		this.label_20 = new Label();
		this.groupBox_2 = new GroupBox();
		this.textBox_3 = new TextBox();
		this.label_7 = new Label();
		this.label_11 = new Label();
		this.comboBoxReadOnly_2 = new ComboBoxReadOnly();
		this.textBox_4 = new TextBox();
		this.label_8 = new Label();
		this.label_12 = new Label();
		this.comboBoxReadOnly_3 = new ComboBoxReadOnly();
		this.comboBoxReadOnly_5 = new ComboBoxReadOnly();
		this.comboBoxReadOnly_4 = new ComboBoxReadOnly();
		this.label_10 = new Label();
		this.label_9 = new Label();
		this.dataGridView_0 = new DataGridView();
		this.dataGridViewComboBoxColumn_4 = new DataGridViewComboBoxColumn();
		this.dataGridViewTextBoxColumn_3 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_4 = new DataGridViewTextBoxColumn();
		this.dataGridViewButtonColumn_0 = new DataGridViewButtonColumn();
		this.dataGridViewComboBoxColumn_5 = new DataGridViewComboBoxColumn();
		this.dataGridViewComboBoxColumn_6 = new DataGridViewComboBoxColumn();
		this.dataGridViewComboBoxColumn_7 = new DataGridViewComboBoxColumn();
		this.label_15 = new Label();
		this.comboBoxReadOnly_6 = new ComboBoxReadOnly();
		this.label_16 = new Label();
		this.button_2 = new Button();
		this.label_6 = new Label();
		this.textBox_2 = new TextBox();
		this.comboBoxReadOnly_7 = new ComboBoxReadOnly();
		this.richTextBox_2 = new RichTextBox();
		this.label_21 = new Label();
		this.richTextBox_3 = new RichTextBox();
		this.label_22 = new Label();
		this.button_3 = new Button();
		this.checkBox_1 = new CheckBox();
		this.label_18 = new Label();
		this.textBox_5 = new TextBox();
		this.label_17 = new Label();
		this.groupBox_1 = new GroupBox();
		this.nullableDateTimePicker_2 = new NullableDateTimePicker();
		this.label_19 = new Label();
		this.nullableDateTimePicker_1 = new NullableDateTimePicker();
		this.label_13 = new Label();
		this.comboBox_0 = new ComboBox();
		this.checkBox_0 = new CheckBox();
		this.richTextBox_0 = new RichTextBox();
		this.label_14 = new Label();
		this.comboBox_1 = new ComboBox();
		this.comboBoxReadOnly_0 = new ComboBoxReadOnly();
		this.label_0 = new Label();
		this.label_1 = new Label();
		this.comboBoxReadOnly_1 = new ComboBoxReadOnly();
		this.dateTimePicker_0 = new DateTimePicker();
		this.label_2 = new Label();
		this.label_3 = new Label();
		this.textBox_0 = new TextBox();
		this.label_4 = new Label();
		this.nullableDateTimePicker_0 = new NullableDateTimePicker();
		this.label_5 = new Label();
		this.textBox_1 = new TextBox();
		this.tabPage_1 = new TabPage();
		this.splitContainer_1 = new SplitContainer();
		this.dataGridViewExcelFilter_0 = new DataGridViewExcelFilter();
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
		this.splitContainer_2 = new SplitContainer();
		this.numericUpDown_0 = new NumericUpDown();
		this.numericUpDown_1 = new NumericUpDown();
		this.numericUpDown_2 = new NumericUpDown();
		this.groupBox_3 = new GroupBox();
		this.numericUpDown_3 = new NumericUpDown();
		this.numericUpDown_4 = new NumericUpDown();
		this.label_23 = new Label();
		this.label_24 = new Label();
		this.label_25 = new Label();
		this.label_26 = new Label();
		this.label_27 = new Label();
		this.groupBox_4 = new GroupBox();
		this.numericUpDown_5 = new NumericUpDown();
		this.numericUpDown_6 = new NumericUpDown();
		this.label_28 = new Label();
		this.label_29 = new Label();
		this.label_30 = new Label();
		this.numericUpDown_7 = new NumericUpDown();
		this.numericUpDown_8 = new NumericUpDown();
		this.numericUpDown_9 = new NumericUpDown();
		this.label_31 = new Label();
		this.groupBox_5 = new GroupBox();
		this.numericUpDown_10 = new NumericUpDown();
		this.numericUpDown_11 = new NumericUpDown();
		this.numericUpDown_12 = new NumericUpDown();
		this.label_32 = new Label();
		this.label_33 = new Label();
		this.label_34 = new Label();
		this.groupBox_6 = new GroupBox();
		this.numericUpDown_13 = new NumericUpDown();
		this.numericUpDown_14 = new NumericUpDown();
		this.label_35 = new Label();
		this.label_36 = new Label();
		this.label_37 = new Label();
		this.label_38 = new Label();
		this.label_39 = new Label();
		this.groupBox_7 = new GroupBox();
		this.numericUpDown_15 = new NumericUpDown();
		this.numericUpDown_16 = new NumericUpDown();
		this.label_40 = new Label();
		this.label_41 = new Label();
		this.statusStrip_0 = new StatusStrip();
		this.toolStripDropDownButton_0 = new ToolStripDropDownButton();
		this.toolStripStatusLabel_0 = new ToolStripStatusLabel();
		this.toolStripStatusLabel_1 = new ToolStripStatusLabel();
		this.toolStripStatusLabel_2 = new ToolStripStatusLabel();
		this.toolStrip_1 = new ToolStrip();
		this.toolStripButton_1 = new ToolStripButton();
		this.toolStripButton_2 = new ToolStripButton();
		this.button_0 = new Button();
		this.button_1 = new Button();
		this.toolTip_0 = new ToolTip(this.icontainer_0);
		this.dataGridViewComboBoxColumn_0 = new DataGridViewComboBoxColumn();
		this.dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
		this.dataGridViewComboBoxColumn_1 = new DataGridViewComboBoxColumn();
		this.dataGridViewComboBoxColumn_2 = new DataGridViewComboBoxColumn();
		this.dataGridViewComboBoxColumn_3 = new DataGridViewComboBoxColumn();
		this.dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
		this.backgroundWorker_0 = new BackgroundWorker();
		this.progressBar_0 = new ProgressBar();
		this.label_42 = new Label();
		this.dataColumn_13 = new DataColumn();
		this.dataColumn_14 = new DataColumn();
		this.dataColumn_15 = new DataColumn();
		this.dataGridViewFilterTextBoxColumn_0 = new DataGridViewFilterTextBoxColumn();
		this.dataGridViewTextBoxColumn_5 = new DataGridViewTextBoxColumn();
		this.dataGridViewFilterTextBoxColumn_1 = new DataGridViewFilterTextBoxColumn();
		this.dataGridViewFilterComboBoxColumn_0 = new DataGridViewFilterComboBoxColumn();
		this.dataGridViewTextBoxColumn_6 = new DataGridViewTextBoxColumn();
		this.dataGridViewFilterTextBoxColumn_2 = new DataGridViewFilterTextBoxColumn();
		this.dataGridViewFilterTextBoxColumn_3 = new DataGridViewFilterTextBoxColumn();
		this.dataGridViewFilterTextBoxColumn_4 = new DataGridViewFilterTextBoxColumn();
		this.dataGridViewFilterTextBoxColumn_5 = new DataGridViewFilterTextBoxColumn();
		this.dataGridViewFilterTextBoxColumn_6 = new DataGridViewFilterTextBoxColumn();
		this.tabControl_0.SuspendLayout();
		this.tabPage_0.SuspendLayout();
		this.toolStrip_0.SuspendLayout();
		((ISupportInitialize)this.class171_0).BeginInit();
		this.splitContainer_0.Panel1.SuspendLayout();
		this.splitContainer_0.Panel2.SuspendLayout();
		this.splitContainer_0.SuspendLayout();
		this.groupBox_0.SuspendLayout();
		this.groupBox_2.SuspendLayout();
		((ISupportInitialize)this.dataGridView_0).BeginInit();
		this.groupBox_1.SuspendLayout();
		this.tabPage_1.SuspendLayout();
		this.splitContainer_1.Panel1.SuspendLayout();
		this.splitContainer_1.Panel2.SuspendLayout();
		this.splitContainer_1.SuspendLayout();
		((ISupportInitialize)this.dataGridViewExcelFilter_0).BeginInit();
		((ISupportInitialize)this.bindingSource_0).BeginInit();
		((ISupportInitialize)this.dataSet_0).BeginInit();
		((ISupportInitialize)this.dataTable_0).BeginInit();
		((ISupportInitialize)this.dataTable_1).BeginInit();
		this.splitContainer_2.Panel1.SuspendLayout();
		this.splitContainer_2.Panel2.SuspendLayout();
		this.splitContainer_2.SuspendLayout();
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
		this.statusStrip_0.SuspendLayout();
		this.toolStrip_1.SuspendLayout();
		base.SuspendLayout();
		this.tabControl_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.tabControl_0.Controls.Add(this.tabPage_0);
		this.tabControl_0.Controls.Add(this.tabPage_1);
		this.tabControl_0.Location = new Point(0, 0);
		this.tabControl_0.Name = "tabControl1";
		this.tabControl_0.SelectedIndex = 0;
		this.tabControl_0.Size = new Size(904, 701);
		this.tabControl_0.TabIndex = 0;
		this.tabPage_0.Controls.Add(this.toolStrip_0);
		this.tabPage_0.Controls.Add(this.comboBoxReadOnly_8);
		this.tabPage_0.Controls.Add(this.splitContainer_0);
		this.tabPage_0.Controls.Add(this.button_3);
		this.tabPage_0.Controls.Add(this.checkBox_1);
		this.tabPage_0.Controls.Add(this.label_18);
		this.tabPage_0.Controls.Add(this.textBox_5);
		this.tabPage_0.Controls.Add(this.label_17);
		this.tabPage_0.Controls.Add(this.groupBox_1);
		this.tabPage_0.Controls.Add(this.comboBoxReadOnly_0);
		this.tabPage_0.Controls.Add(this.label_0);
		this.tabPage_0.Controls.Add(this.label_1);
		this.tabPage_0.Controls.Add(this.comboBoxReadOnly_1);
		this.tabPage_0.Controls.Add(this.dateTimePicker_0);
		this.tabPage_0.Controls.Add(this.label_2);
		this.tabPage_0.Controls.Add(this.label_3);
		this.tabPage_0.Controls.Add(this.textBox_0);
		this.tabPage_0.Controls.Add(this.label_4);
		this.tabPage_0.Controls.Add(this.nullableDateTimePicker_0);
		this.tabPage_0.Controls.Add(this.label_5);
		this.tabPage_0.Controls.Add(this.textBox_1);
		this.tabPage_0.Location = new Point(4, 22);
		this.tabPage_0.Name = "tabPageGeneral";
		this.tabPage_0.Padding = new Padding(3);
		this.tabPage_0.Size = new Size(896, 675);
		this.tabPage_0.TabIndex = 0;
		this.tabPage_0.Text = "Общий";
		this.tabPage_0.UseVisualStyleBackColor = true;
		this.toolStrip_0.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.toolStrip_0.Dock = DockStyle.None;
		this.toolStrip_0.GripStyle = ToolStripGripStyle.Hidden;
		this.toolStrip_0.ImageScalingSize = new Size(24, 24);
		this.toolStrip_0.Items.AddRange(new ToolStripItem[]
		{
			this.toolStripButton_0
		});
		this.toolStrip_0.Location = new Point(859, 3);
		this.toolStrip_0.Name = "toolStrip81";
		this.toolStrip_0.Size = new Size(31, 31);
		this.toolStrip_0.TabIndex = 25;
		this.toolStrip_0.Text = "toolStrip1";
		this.toolStripButton_0.Checked = true;
		this.toolStripButton_0.CheckOnClick = true;
		this.toolStripButton_0.CheckState = CheckState.Checked;
		this.toolStripButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_0.Image = Resources.not81;
		this.toolStripButton_0.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_0.Name = "toolBtn81";
		this.toolStripButton_0.Size = new Size(28, 28);
		this.toolStripButton_0.Text = "Использовать в бюллетене 8.1";
		this.toolStripButton_0.CheckedChanged += this.toolStripButton_0_CheckedChanged;
		this.comboBoxReadOnly_8.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.comboBoxReadOnly_8.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBoxReadOnly_8.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBoxReadOnly_8.DataBindings.Add(new Binding("SelectedValue", this.class171_0, "tJ_Damage.idDivisionApply", true));
		this.comboBoxReadOnly_8.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBoxReadOnly_8.FormattingEnabled = true;
		this.comboBoxReadOnly_8.Location = new Point(169, 486);
		this.comboBoxReadOnly_8.Name = "cmbDivisionApply";
		this.comboBoxReadOnly_8.ReadOnlyBackColor = SystemColors.Window;
		this.comboBoxReadOnly_8.ReadOnlyForeColor = SystemColors.WindowText;
		this.comboBoxReadOnly_8.Size = new Size(510, 21);
		this.comboBoxReadOnly_8.TabIndex = 16;
		this.comboBoxReadOnly_8.SelectedIndexChanged += this.comboBoxReadOnly_8_SelectedIndexChanged;
		this.comboBoxReadOnly_8.KeyDown += this.comboBoxReadOnly_8_KeyDown;
		this.class171_0.DataSetName = "DataSetDamage";
		this.class171_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		this.splitContainer_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.splitContainer_0.Location = new Point(3, 120);
		this.splitContainer_0.Name = "splitContainer1";
		this.splitContainer_0.Panel1.Controls.Add(this.groupBox_0);
		this.splitContainer_0.Panel2.Controls.Add(this.comboBoxReadOnly_7);
		this.splitContainer_0.Panel2.Controls.Add(this.richTextBox_2);
		this.splitContainer_0.Panel2.Controls.Add(this.label_21);
		this.splitContainer_0.Panel2.Controls.Add(this.richTextBox_3);
		this.splitContainer_0.Panel2.Controls.Add(this.label_22);
		this.splitContainer_0.Size = new Size(887, 357);
		this.splitContainer_0.SplitterDistance = 542;
		this.splitContainer_0.TabIndex = 24;
		this.groupBox_0.Controls.Add(this.richTextBox_1);
		this.groupBox_0.Controls.Add(this.label_20);
		this.groupBox_0.Controls.Add(this.groupBox_2);
		this.groupBox_0.Controls.Add(this.dataGridView_0);
		this.groupBox_0.Controls.Add(this.label_15);
		this.groupBox_0.Controls.Add(this.comboBoxReadOnly_6);
		this.groupBox_0.Controls.Add(this.label_16);
		this.groupBox_0.Controls.Add(this.button_2);
		this.groupBox_0.Controls.Add(this.label_6);
		this.groupBox_0.Controls.Add(this.textBox_2);
		this.groupBox_0.Dock = DockStyle.Fill;
		this.groupBox_0.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.groupBox_0.Location = new Point(0, 0);
		this.groupBox_0.Name = "groupBoxDefectData";
		this.groupBox_0.Size = new Size(542, 357);
		this.groupBox_0.TabIndex = 0;
		this.groupBox_0.TabStop = false;
		this.groupBox_0.Text = "Исходные данные";
		this.richTextBox_1.AcceptsTab = true;
		this.richTextBox_1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.richTextBox_1.BackColor = SystemColors.Window;
		this.richTextBox_1.DataBindings.Add(new Binding("Text", this.class171_0, "tJ_Damage.DefectLocation", true));
		this.richTextBox_1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.richTextBox_1.Location = new Point(128, 178);
		this.richTextBox_1.Name = "txtLocation";
		this.richTextBox_1.Size = new Size(408, 40);
		this.richTextBox_1.TabIndex = 6;
		this.richTextBox_1.Text = "";
		this.label_20.AutoSize = true;
		this.label_20.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.label_20.Location = new Point(12, 178);
		this.label_20.Name = "label7";
		this.label_20.Size = new Size(110, 13);
		this.label_20.TabIndex = 5;
		this.label_20.Text = "Место повреждения";
		this.groupBox_2.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.groupBox_2.Controls.Add(this.textBox_3);
		this.groupBox_2.Controls.Add(this.label_7);
		this.groupBox_2.Controls.Add(this.label_11);
		this.groupBox_2.Controls.Add(this.comboBoxReadOnly_2);
		this.groupBox_2.Controls.Add(this.textBox_4);
		this.groupBox_2.Controls.Add(this.label_8);
		this.groupBox_2.Controls.Add(this.label_12);
		this.groupBox_2.Controls.Add(this.comboBoxReadOnly_3);
		this.groupBox_2.Controls.Add(this.comboBoxReadOnly_5);
		this.groupBox_2.Controls.Add(this.comboBoxReadOnly_4);
		this.groupBox_2.Controls.Add(this.label_10);
		this.groupBox_2.Controls.Add(this.label_9);
		this.groupBox_2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.groupBox_2.Location = new Point(9, 72);
		this.groupBox_2.Name = "groupBoxAddress";
		this.groupBox_2.Size = new Size(527, 100);
		this.groupBox_2.TabIndex = 4;
		this.groupBox_2.TabStop = false;
		this.groupBox_2.Text = "Адрес";
		this.textBox_3.BackColor = SystemColors.Window;
		this.textBox_3.Location = new Point(352, 72);
		this.textBox_3.Name = "txtHousePrefix";
		this.textBox_3.Size = new Size(64, 20);
		this.textBox_3.TabIndex = 11;
		this.textBox_3.TextChanged += this.textBox_3_TextChanged;
		this.label_7.AutoSize = true;
		this.label_7.Location = new Point(6, 16);
		this.label_7.Name = "labelObl";
		this.label_7.Size = new Size(50, 13);
		this.label_7.TabIndex = 0;
		this.label_7.Text = "Область";
		this.label_11.AutoSize = true;
		this.label_11.Location = new Point(349, 56);
		this.label_11.Name = "labelHousePrefix";
		this.label_11.Size = new Size(53, 13);
		this.label_11.TabIndex = 10;
		this.label_11.Text = "Префикс";
		this.comboBoxReadOnly_2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBoxReadOnly_2.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBoxReadOnly_2.DisplayMember = "tR_KladrObj.NameSocr";
		this.comboBoxReadOnly_2.FormattingEnabled = true;
		this.comboBoxReadOnly_2.Location = new Point(6, 32);
		this.comboBoxReadOnly_2.Name = "cmbObl";
		this.comboBoxReadOnly_2.ReadOnlyBackColor = SystemColors.Window;
		this.comboBoxReadOnly_2.ReadOnlyForeColor = SystemColors.WindowText;
		this.comboBoxReadOnly_2.Size = new Size(179, 21);
		this.comboBoxReadOnly_2.TabIndex = 1;
		this.comboBoxReadOnly_2.ValueMember = "tR_KladrObj.Id";
		this.comboBoxReadOnly_2.SelectedIndexChanged += this.comboBoxReadOnly_2_SelectedIndexChanged;
		this.textBox_4.BackColor = SystemColors.Window;
		this.textBox_4.Location = new Point(273, 72);
		this.textBox_4.Name = "txtHouse";
		this.textBox_4.Size = new Size(63, 20);
		this.textBox_4.TabIndex = 9;
		this.textBox_4.TextChanged += this.textBox_4_TextChanged;
		this.label_8.AutoSize = true;
		this.label_8.Location = new Point(203, 16);
		this.label_8.Name = "labelRaionObl";
		this.label_8.Size = new Size(72, 13);
		this.label_8.TabIndex = 2;
		this.label_8.Text = "Район/город";
		this.label_12.AutoSize = true;
		this.label_12.Location = new Point(270, 56);
		this.label_12.Name = "labelHouse";
		this.label_12.Size = new Size(30, 13);
		this.label_12.TabIndex = 8;
		this.label_12.Text = "Дом";
		this.comboBoxReadOnly_3.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBoxReadOnly_3.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBoxReadOnly_3.DisplayMember = "tR_KladrObj.NameSocr";
		this.comboBoxReadOnly_3.FormattingEnabled = true;
		this.comboBoxReadOnly_3.Location = new Point(195, 32);
		this.comboBoxReadOnly_3.Name = "cmbRaionObl";
		this.comboBoxReadOnly_3.ReadOnlyBackColor = SystemColors.Window;
		this.comboBoxReadOnly_3.ReadOnlyForeColor = SystemColors.WindowText;
		this.comboBoxReadOnly_3.Size = new Size(172, 21);
		this.comboBoxReadOnly_3.TabIndex = 3;
		this.comboBoxReadOnly_3.ValueMember = "tR_KladrObj.Id";
		this.comboBoxReadOnly_3.SelectedIndexChanged += this.comboBoxReadOnly_3_SelectedIndexChanged;
		this.comboBoxReadOnly_5.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBoxReadOnly_5.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBoxReadOnly_5.DataBindings.Add(new Binding("SelectedValue", this.class171_0, "tJ_Damage.idStreet", true));
		this.comboBoxReadOnly_5.DisplayMember = "tR_KladrStreet.NameSocr";
		this.comboBoxReadOnly_5.FormattingEnabled = true;
		this.comboBoxReadOnly_5.Location = new Point(6, 72);
		this.comboBoxReadOnly_5.Name = "cmbStreet";
		this.comboBoxReadOnly_5.ReadOnlyBackColor = SystemColors.Window;
		this.comboBoxReadOnly_5.ReadOnlyForeColor = SystemColors.WindowText;
		this.comboBoxReadOnly_5.Size = new Size(244, 21);
		this.comboBoxReadOnly_5.TabIndex = 7;
		this.comboBoxReadOnly_5.ValueMember = "tR_KladrStreet.Id";
		this.comboBoxReadOnly_5.SelectedIndexChanged += this.comboBoxReadOnly_5_SelectedIndexChanged;
		this.comboBoxReadOnly_4.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.comboBoxReadOnly_4.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBoxReadOnly_4.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBoxReadOnly_4.DisplayMember = "tR_KladrObj.NameSocr";
		this.comboBoxReadOnly_4.FormattingEnabled = true;
		this.comboBoxReadOnly_4.Location = new Point(373, 32);
		this.comboBoxReadOnly_4.Name = "cmbCity";
		this.comboBoxReadOnly_4.ReadOnlyBackColor = SystemColors.Window;
		this.comboBoxReadOnly_4.ReadOnlyForeColor = SystemColors.WindowText;
		this.comboBoxReadOnly_4.Size = new Size(148, 21);
		this.comboBoxReadOnly_4.TabIndex = 5;
		this.comboBoxReadOnly_4.ValueMember = "tR_KladrObj.Id";
		this.comboBoxReadOnly_4.SelectedIndexChanged += this.comboBoxReadOnly_4_SelectedIndexChanged;
		this.label_10.AutoSize = true;
		this.label_10.Location = new Point(6, 56);
		this.label_10.Name = "labelStreet";
		this.label_10.Size = new Size(39, 13);
		this.label_10.TabIndex = 6;
		this.label_10.Text = "Улица";
		this.label_9.AutoSize = true;
		this.label_9.Location = new Point(382, 16);
		this.label_9.Name = "labelCity";
		this.label_9.Size = new Size(102, 13);
		this.label_9.TabIndex = 4;
		this.label_9.Text = "Населенный пункт";
		this.dataGridView_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.dataGridView_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView_0.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewComboBoxColumn_4,
			this.dataGridViewTextBoxColumn_3,
			this.dataGridViewTextBoxColumn_4,
			this.dataGridViewButtonColumn_0,
			this.dataGridViewComboBoxColumn_5,
			this.dataGridViewComboBoxColumn_6,
			this.dataGridViewComboBoxColumn_7
		});
		this.dataGridView_0.EditMode = DataGridViewEditMode.EditOnEnter;
		this.dataGridView_0.Location = new Point(0, 237);
		this.dataGridView_0.Name = "dgvCharacterDamage";
		this.dataGridView_0.Size = new Size(542, 120);
		this.dataGridView_0.TabIndex = 8;
		this.dataGridView_0.CellContentClick += this.dataGridView_0_CellContentClick;
		this.dataGridView_0.CurrentCellDirtyStateChanged += this.dataGridView_0_CurrentCellDirtyStateChanged;
		this.dataGridView_0.DataError += this.dataGridView_0_DataError;
		this.dataGridView_0.MouseClick += this.dataGridView_0_MouseClick;
		this.dataGridViewComboBoxColumn_4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewCellStyle.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.dataGridViewComboBoxColumn_4.DefaultCellStyle = dataGridViewCellStyle;
		this.dataGridViewComboBoxColumn_4.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
		this.dataGridViewComboBoxColumn_4.HeaderText = "Тип объекта";
		this.dataGridViewComboBoxColumn_4.Name = "Column1";
		this.dataGridViewComboBoxColumn_4.Resizable = DataGridViewTriState.True;
		this.dataGridViewComboBoxColumn_4.SortMode = DataGridViewColumnSortMode.Programmatic;
		dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.dataGridViewTextBoxColumn_3.DefaultCellStyle = dataGridViewCellStyle2;
		this.dataGridViewTextBoxColumn_3.HeaderText = "Объект";
		this.dataGridViewTextBoxColumn_3.Name = "ColumnSchmObj";
		this.dataGridViewTextBoxColumn_3.ReadOnly = true;
		dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.dataGridViewTextBoxColumn_4.DefaultCellStyle = dataGridViewCellStyle3;
		this.dataGridViewTextBoxColumn_4.HeaderText = "IdSchmObj";
		this.dataGridViewTextBoxColumn_4.Name = "ColumnIdSchmObj";
		this.dataGridViewTextBoxColumn_4.ReadOnly = true;
		this.dataGridViewTextBoxColumn_4.Visible = false;
		this.dataGridViewButtonColumn_0.HeaderText = "";
		this.dataGridViewButtonColumn_0.Name = "ColumnBtn";
		this.dataGridViewButtonColumn_0.Text = "...";
		this.dataGridViewButtonColumn_0.ToolTipText = "Выбрать объект";
		this.dataGridViewButtonColumn_0.Visible = false;
		this.dataGridViewButtonColumn_0.Width = 25;
		dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.dataGridViewComboBoxColumn_5.DefaultCellStyle = dataGridViewCellStyle4;
		this.dataGridViewComboBoxColumn_5.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
		this.dataGridViewComboBoxColumn_5.HeaderText = "Участок";
		this.dataGridViewComboBoxColumn_5.Name = "ColumnCabSection";
		this.dataGridViewComboBoxColumn_5.ReadOnly = true;
		this.dataGridViewComboBoxColumn_5.Width = 60;
		this.dataGridViewComboBoxColumn_6.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewCellStyle5.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.dataGridViewComboBoxColumn_6.DefaultCellStyle = dataGridViewCellStyle5;
		this.dataGridViewComboBoxColumn_6.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
		this.dataGridViewComboBoxColumn_6.HeaderText = "Повреждение";
		this.dataGridViewComboBoxColumn_6.Name = "Column2";
		this.dataGridViewComboBoxColumn_7.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewCellStyle6.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.dataGridViewComboBoxColumn_7.DefaultCellStyle = dataGridViewCellStyle6;
		this.dataGridViewComboBoxColumn_7.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
		this.dataGridViewComboBoxColumn_7.HeaderText = "Уточнение";
		this.dataGridViewComboBoxColumn_7.Name = "Column3";
		this.label_15.AutoSize = true;
		this.label_15.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.label_15.Location = new Point(6, 221);
		this.label_15.Name = "label1ChatacterDamage";
		this.label_15.Size = new Size(126, 13);
		this.label_15.TabIndex = 7;
		this.label_15.Text = "Характер повреждения";
		this.comboBoxReadOnly_6.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.comboBoxReadOnly_6.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBoxReadOnly_6.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBoxReadOnly_6.DataBindings.Add(new Binding("SelectedValue", this.class171_0, "tJ_Damage.idReason", true));
		this.comboBoxReadOnly_6.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.comboBoxReadOnly_6.FormattingEnabled = true;
		this.comboBoxReadOnly_6.Location = new Point(153, 45);
		this.comboBoxReadOnly_6.Name = "cmbReason";
		this.comboBoxReadOnly_6.ReadOnlyBackColor = SystemColors.Window;
		this.comboBoxReadOnly_6.ReadOnlyForeColor = SystemColors.WindowText;
		this.comboBoxReadOnly_6.Size = new Size(383, 21);
		this.comboBoxReadOnly_6.TabIndex = 3;
		this.comboBoxReadOnly_6.SelectedIndexChanged += this.comboBoxReadOnly_6_SelectedIndexChanged;
		this.label_16.AutoSize = true;
		this.label_16.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.label_16.Location = new Point(6, 48);
		this.label_16.Name = "labelReason";
		this.label_16.Size = new Size(86, 13);
		this.label_16.TabIndex = 2;
		this.label_16.Text = "Неисправность";
		this.button_2.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.button_2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.button_2.Location = new Point(509, 19);
		this.button_2.Name = "btnChoiceSchmObj";
		this.button_2.Size = new Size(27, 20);
		this.button_2.TabIndex = 2;
		this.button_2.Text = "...";
		this.button_2.UseVisualStyleBackColor = true;
		this.button_2.Click += this.button_2_Click;
		this.label_6.AutoSize = true;
		this.label_6.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.label_6.Location = new Point(6, 22);
		this.label_6.Name = "labelSchmObj";
		this.label_6.Size = new Size(108, 13);
		this.label_6.TabIndex = 0;
		this.label_6.Text = "Подстанция\\ячейка";
		this.textBox_2.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_2.BackColor = SystemColors.Window;
		this.textBox_2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.textBox_2.Location = new Point(153, 19);
		this.textBox_2.Name = "txtSchmObj";
		this.textBox_2.ReadOnly = true;
		this.textBox_2.Size = new Size(357, 20);
		this.textBox_2.TabIndex = 1;
		this.textBox_2.TextChanged += this.textBox_2_TextChanged;
		this.comboBoxReadOnly_7.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.comboBoxReadOnly_7.BackColor = SystemColors.Window;
		this.comboBoxReadOnly_7.DataBindings.Add(new Binding("SelectedValue", this.class171_0, "tJ_Damage.idCompletedWorkODS", true));
		this.comboBoxReadOnly_7.ForeColor = SystemColors.WindowText;
		this.comboBoxReadOnly_7.FormattingEnabled = true;
		this.comboBoxReadOnly_7.Location = new Point(192, 178);
		this.comboBoxReadOnly_7.Name = "cmbComplWorkODS";
		this.comboBoxReadOnly_7.ReadOnlyBackColor = SystemColors.Window;
		this.comboBoxReadOnly_7.ReadOnlyForeColor = SystemColors.WindowText;
		this.comboBoxReadOnly_7.Size = new Size(145, 21);
		this.comboBoxReadOnly_7.TabIndex = 3;
		this.richTextBox_2.AcceptsTab = true;
		this.richTextBox_2.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.richTextBox_2.BackColor = SystemColors.Window;
		this.richTextBox_2.DataBindings.Add(new Binding("Text", this.class171_0, "tJ_Damage.CompletedWorkTextODS", true));
		this.richTextBox_2.Location = new Point(2, 206);
		this.richTextBox_2.Name = "txtComplWorkODS";
		this.richTextBox_2.Size = new Size(335, 151);
		this.richTextBox_2.TabIndex = 4;
		this.richTextBox_2.Text = "";
		this.label_21.AutoSize = true;
		this.label_21.Location = new Point(3, 181);
		this.label_21.Name = "label9";
		this.label_21.Size = new Size(189, 13);
		this.label_21.TabIndex = 2;
		this.label_21.Text = "Выполненная работа составителем";
		this.richTextBox_3.AcceptsTab = true;
		this.richTextBox_3.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.richTextBox_3.BackColor = SystemColors.Window;
		this.richTextBox_3.DataBindings.Add(new Binding("Text", this.class171_0, "tJ_Damage.DivisionInstruction", true));
		this.richTextBox_3.Location = new Point(2, 25);
		this.richTextBox_3.Name = "txtInstruction";
		this.richTextBox_3.Size = new Size(335, 147);
		this.richTextBox_3.TabIndex = 1;
		this.richTextBox_3.Text = "";
		this.label_22.AutoSize = true;
		this.label_22.Location = new Point(12, 9);
		this.label_22.Name = "label8";
		this.label_22.Size = new Size(57, 13);
		this.label_22.TabIndex = 0;
		this.label_22.Text = "Указания";
		this.button_3.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.button_3.Enabled = false;
		this.button_3.Location = new Point(853, 92);
		this.button_3.Name = "btnShowDocParent";
		this.button_3.Size = new Size(27, 20);
		this.button_3.TabIndex = 23;
		this.button_3.Text = "...";
		this.toolTip_0.SetToolTip(this.button_3, "Открыть документ");
		this.button_3.UseVisualStyleBackColor = true;
		this.button_3.Click += this.button_3_Click;
		this.checkBox_1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.checkBox_1.AutoSize = true;
		this.checkBox_1.DataBindings.Add(new Binding("Checked", this.class171_0, "tJ_Damage.isLaboratory", true));
		this.checkBox_1.Location = new Point(689, 489);
		this.checkBox_1.Name = "checkBoxLaboratory";
		this.checkBox_1.Size = new Size(191, 17);
		this.checkBox_1.TabIndex = 17;
		this.checkBox_1.Text = "Производственная лаборатория";
		this.checkBox_1.UseVisualStyleBackColor = true;
		this.checkBox_1.CheckedChanged += this.checkBox_1_CheckedChanged;
		this.label_18.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.label_18.AutoSize = true;
		this.label_18.Location = new Point(8, 489);
		this.label_18.Name = "labelDivisionApply";
		this.label_18.Size = new Size(155, 13);
		this.label_18.TabIndex = 15;
		this.label_18.Text = "Подразделение исполнитель";
		this.textBox_5.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_5.BackColor = SystemColors.Window;
		this.textBox_5.Location = new Point(129, 93);
		this.textBox_5.Name = "txtDocParent";
		this.textBox_5.ReadOnly = true;
		this.textBox_5.Size = new Size(725, 20);
		this.textBox_5.TabIndex = 13;
		this.label_17.AutoSize = true;
		this.label_17.Location = new Point(8, 96);
		this.label_17.Name = "label1";
		this.label_17.Size = new Size(115, 13);
		this.label_17.TabIndex = 12;
		this.label_17.Text = "Документ-основание";
		this.groupBox_1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.groupBox_1.Controls.Add(this.nullableDateTimePicker_2);
		this.groupBox_1.Controls.Add(this.label_19);
		this.groupBox_1.Controls.Add(this.nullableDateTimePicker_1);
		this.groupBox_1.Controls.Add(this.label_13);
		this.groupBox_1.Controls.Add(this.comboBox_0);
		this.groupBox_1.Controls.Add(this.checkBox_0);
		this.groupBox_1.Controls.Add(this.richTextBox_0);
		this.groupBox_1.Controls.Add(this.label_14);
		this.groupBox_1.Controls.Add(this.comboBox_1);
		this.groupBox_1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.groupBox_1.Location = new Point(3, 513);
		this.groupBox_1.Name = "groupBoxResult";
		this.groupBox_1.Size = new Size(887, 156);
		this.groupBox_1.TabIndex = 14;
		this.groupBox_1.TabStop = false;
		this.groupBox_1.Text = "Результат (принятые меры)";
		this.nullableDateTimePicker_2.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.nullableDateTimePicker_2.CustomFormat = "dd.MM.yyyy HH:mm";
		this.nullableDateTimePicker_2.DataBindings.Add(new Binding("Value", this.class171_0, "tJ_Damage.DatePlanApply", true, DataSourceUpdateMode.OnPropertyChanged));
		this.nullableDateTimePicker_2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.nullableDateTimePicker_2.Format = DateTimePickerFormat.Custom;
		this.nullableDateTimePicker_2.Location = new Point(267, 103);
		this.nullableDateTimePicker_2.Name = "dtpDatePlanApply";
		this.nullableDateTimePicker_2.Size = new Size(417, 20);
		this.nullableDateTimePicker_2.TabIndex = 4;
		this.nullableDateTimePicker_2.Value = new DateTime(2015, 8, 6, 10, 0, 53, 2);
		this.nullableDateTimePicker_2.ValueChanged += this.nullableDateTimePicker_2_ValueChanged;
		this.label_19.AutoSize = true;
		this.label_19.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.label_19.Location = new Point(10, 108);
		this.label_19.Name = "label5";
		this.label_19.Size = new Size(251, 13);
		this.label_19.TabIndex = 3;
		this.label_19.Text = "Планируемая дата и время выполнения работы";
		this.nullableDateTimePicker_1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.nullableDateTimePicker_1.CustomFormat = "dd.MM.yyyy HH:mm";
		this.nullableDateTimePicker_1.DataBindings.Add(new Binding("Value", this.class171_0, "tJ_Damage.DateApply", true, DataSourceUpdateMode.OnPropertyChanged));
		this.nullableDateTimePicker_1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.nullableDateTimePicker_1.Format = DateTimePickerFormat.Custom;
		this.nullableDateTimePicker_1.Location = new Point(415, 129);
		this.nullableDateTimePicker_1.Name = "dtpDataApply";
		this.nullableDateTimePicker_1.Size = new Size(466, 20);
		this.nullableDateTimePicker_1.TabIndex = 8;
		this.nullableDateTimePicker_1.Value = new DateTime(2015, 8, 6, 10, 0, 53, 2);
		this.nullableDateTimePicker_1.ValueChanged += this.nullableDateTimePicker_1_ValueChanged;
		this.label_13.AutoSize = true;
		this.label_13.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.label_13.Location = new Point(332, 132);
		this.label_13.Name = "labelDateAplly";
		this.label_13.Size = new Size(77, 13);
		this.label_13.TabIndex = 7;
		this.label_13.Text = "Дата и время";
		this.comboBox_0.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBox_0.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBox_0.DataBindings.Add(new Binding("SelectedValue", this.class171_0, "tJ_Damage.idWorkerApply", true));
		this.comboBox_0.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.comboBox_0.FormattingEnabled = true;
		this.comboBox_0.Location = new Point(130, 129);
		this.comboBox_0.Name = "cmbWorkerApply";
		this.comboBox_0.Size = new Size(196, 21);
		this.comboBox_0.TabIndex = 6;
		this.comboBox_0.SelectedIndexChanged += this.comboBox_0_SelectedIndexChanged;
		this.checkBox_0.AutoSize = true;
		this.checkBox_0.DataBindings.Add(new Binding("Checked", this.class171_0, "tJ_Damage.isApply", true));
		this.checkBox_0.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.checkBox_0.Location = new Point(13, 132);
		this.checkBox_0.Name = "checkBoxApply";
		this.checkBox_0.Size = new Size(82, 17);
		this.checkBox_0.TabIndex = 5;
		this.checkBox_0.Text = "Исполнено";
		this.checkBox_0.UseVisualStyleBackColor = true;
		this.richTextBox_0.AcceptsTab = true;
		this.richTextBox_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.richTextBox_0.DataBindings.Add(new Binding("Text", this.class171_0, "tJ_Damage.ComletedWorkText", true));
		this.richTextBox_0.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.richTextBox_0.Location = new Point(9, 47);
		this.richTextBox_0.Name = "txtCompletedWork";
		this.richTextBox_0.Size = new Size(874, 47);
		this.richTextBox_0.TabIndex = 2;
		this.richTextBox_0.Text = "";
		this.richTextBox_0.TextChanged += this.richTextBox_0_TextChanged;
		this.label_14.AutoSize = true;
		this.label_14.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.label_14.Location = new Point(10, 22);
		this.label_14.Name = "labelCompletedWork";
		this.label_14.Size = new Size(190, 13);
		this.label_14.TabIndex = 0;
		this.label_14.Text = "Выполненная работа исполнителем";
		this.comboBox_1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.comboBox_1.DataBindings.Add(new Binding("SelectedValue", this.class171_0, "tJ_Damage.idCompletedWork", true));
		this.comboBox_1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.comboBox_1.FormattingEnabled = true;
		this.comboBox_1.Location = new Point(206, 19);
		this.comboBox_1.Name = "cmbCompletedWork";
		this.comboBox_1.Size = new Size(677, 21);
		this.comboBox_1.TabIndex = 1;
		this.comboBox_1.SelectedIndexChanged += this.comboBox_1_SelectedIndexChanged;
		this.comboBoxReadOnly_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.comboBoxReadOnly_0.BackColor = SystemColors.Window;
		this.comboBoxReadOnly_0.DataBindings.Add(new Binding("SelectedValue", this.class171_0, "tJ_Damage.idDivision", true, DataSourceUpdateMode.OnPropertyChanged));
		this.comboBoxReadOnly_0.ForeColor = SystemColors.WindowText;
		this.comboBoxReadOnly_0.FormattingEnabled = true;
		this.comboBoxReadOnly_0.Location = new Point(388, 59);
		this.comboBoxReadOnly_0.Name = "cmbDivision";
		this.comboBoxReadOnly_0.ReadOnly = true;
		this.comboBoxReadOnly_0.ReadOnlyBackColor = SystemColors.Window;
		this.comboBoxReadOnly_0.ReadOnlyForeColor = SystemColors.WindowText;
		this.comboBoxReadOnly_0.Size = new Size(498, 21);
		this.comboBoxReadOnly_0.TabIndex = 11;
		this.comboBoxReadOnly_0.TabStop = false;
		this.label_0.AutoSize = true;
		this.label_0.Location = new Point(295, 66);
		this.label_0.Name = "label6";
		this.label_0.Size = new Size(87, 13);
		this.label_0.TabIndex = 10;
		this.label_0.Text = "Подразделение";
		this.label_1.AutoSize = true;
		this.label_1.Location = new Point(8, 66);
		this.label_1.Name = "labelCompiler";
		this.label_1.Size = new Size(72, 13);
		this.label_1.TabIndex = 8;
		this.label_1.Text = "Составитель";
		this.comboBoxReadOnly_1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBoxReadOnly_1.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBoxReadOnly_1.DataBindings.Add(new Binding("SelectedValue", this.class171_0, "tJ_Damage.idCompiler", true));
		this.comboBoxReadOnly_1.FormattingEnabled = true;
		this.comboBoxReadOnly_1.Location = new Point(94, 59);
		this.comboBoxReadOnly_1.Name = "cmbCompiler";
		this.comboBoxReadOnly_1.ReadOnlyBackColor = SystemColors.Window;
		this.comboBoxReadOnly_1.ReadOnlyForeColor = SystemColors.WindowText;
		this.comboBoxReadOnly_1.Size = new Size(185, 21);
		this.comboBoxReadOnly_1.TabIndex = 9;
		this.comboBoxReadOnly_1.SelectedValueChanged += this.comboBoxReadOnly_1_SelectedValueChanged;
		this.dateTimePicker_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.dateTimePicker_0.DataBindings.Add(new Binding("Value", this.class171_0, "tJ_Damage.DateOwner", true, DataSourceUpdateMode.OnPropertyChanged));
		this.dateTimePicker_0.Enabled = false;
		this.dateTimePicker_0.Location = new Point(355, 33);
		this.dateTimePicker_0.Name = "dtpDateOwner";
		this.dateTimePicker_0.Size = new Size(484, 20);
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
		this.label_3.TabIndex = 4;
		this.label_3.Text = "Автор заявки";
		this.textBox_0.Location = new Point(94, 32);
		this.textBox_0.Name = "txtOwner";
		this.textBox_0.ReadOnly = true;
		this.textBox_0.Size = new Size(133, 20);
		this.textBox_0.TabIndex = 5;
		this.label_4.AutoSize = true;
		this.label_4.Location = new Point(233, 13);
		this.label_4.Name = "labelDateDoc";
		this.label_4.Size = new Size(116, 13);
		this.label_4.TabIndex = 2;
		this.label_4.Text = "Дата и время заявки";
		this.nullableDateTimePicker_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.nullableDateTimePicker_0.CustomFormat = "dd.MM.yyyy HH:mm";
		this.nullableDateTimePicker_0.DataBindings.Add(new Binding("Value", this.class171_0, "tJ_Damage.DateDoc", true));
		this.nullableDateTimePicker_0.Format = DateTimePickerFormat.Custom;
		this.nullableDateTimePicker_0.Location = new Point(355, 7);
		this.nullableDateTimePicker_0.Name = "dtpDateDoc";
		this.nullableDateTimePicker_0.Size = new Size(484, 20);
		this.nullableDateTimePicker_0.TabIndex = 3;
		this.nullableDateTimePicker_0.Value = new DateTime(2015, 10, 14, 11, 28, 26, 725);
		this.nullableDateTimePicker_0.ValueChanged += this.nullableDateTimePicker_0_ValueChanged;
		this.label_5.AutoSize = true;
		this.label_5.Location = new Point(8, 13);
		this.label_5.Name = "labelNumRequest";
		this.label_5.Size = new Size(80, 13);
		this.label_5.TabIndex = 0;
		this.label_5.Text = "Номер заявки";
		this.textBox_1.DataBindings.Add(new Binding("Text", this.class171_0, "tJ_Damage.NumRequest", true, DataSourceUpdateMode.OnPropertyChanged));
		this.textBox_1.Location = new Point(94, 6);
		this.textBox_1.Name = "txtNumRequest";
		this.textBox_1.Size = new Size(133, 20);
		this.textBox_1.TabIndex = 1;
		this.textBox_1.TextChanged += this.textBox_1_TextChanged;
		this.tabPage_1.Controls.Add(this.splitContainer_1);
		this.tabPage_1.Controls.Add(this.statusStrip_0);
		this.tabPage_1.Controls.Add(this.toolStrip_1);
		this.tabPage_1.Location = new Point(4, 22);
		this.tabPage_1.Name = "tabPageAbn";
		this.tabPage_1.Padding = new Padding(3);
		this.tabPage_1.Size = new Size(896, 675);
		this.tabPage_1.TabIndex = 1;
		this.tabPage_1.Text = "Отключенные абоненты";
		this.tabPage_1.UseVisualStyleBackColor = true;
		this.splitContainer_1.Dock = DockStyle.Fill;
		this.splitContainer_1.FixedPanel = FixedPanel.Panel2;
		this.splitContainer_1.IsSplitterFixed = true;
		this.splitContainer_1.Location = new Point(3, 28);
		this.splitContainer_1.Name = "splitContainerAbn";
		this.splitContainer_1.Orientation = Orientation.Horizontal;
		this.splitContainer_1.Panel1.Controls.Add(this.dataGridViewExcelFilter_0);
		this.splitContainer_1.Panel2.Controls.Add(this.splitContainer_2);
		this.splitContainer_1.Size = new Size(890, 622);
		this.splitContainer_1.SplitterDistance = 410;
		this.splitContainer_1.TabIndex = 10;
		this.dataGridViewExcelFilter_0.AllowUserToAddRows = false;
		this.dataGridViewExcelFilter_0.AllowUserToDeleteRows = false;
		this.dataGridViewExcelFilter_0.AllowUserToOrderColumns = true;
		dataGridViewCellStyle7.BackColor = Color.FromArgb(224, 224, 224);
		this.dataGridViewExcelFilter_0.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
		this.dataGridViewExcelFilter_0.AutoGenerateColumns = false;
		this.dataGridViewExcelFilter_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridViewExcelFilter_0.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewFilterTextBoxColumn_0,
			this.dataGridViewTextBoxColumn_5,
			this.dataGridViewFilterTextBoxColumn_1,
			this.dataGridViewFilterComboBoxColumn_0,
			this.dataGridViewTextBoxColumn_6,
			this.dataGridViewFilterTextBoxColumn_2,
			this.dataGridViewFilterTextBoxColumn_3,
			this.dataGridViewFilterTextBoxColumn_4,
			this.dataGridViewFilterTextBoxColumn_5,
			this.dataGridViewFilterTextBoxColumn_6
		});
		this.dataGridViewExcelFilter_0.DataSource = this.bindingSource_0;
		this.dataGridViewExcelFilter_0.Dock = DockStyle.Fill;
		this.dataGridViewExcelFilter_0.Location = new Point(0, 0);
		this.dataGridViewExcelFilter_0.Name = "dgvAbn";
		this.dataGridViewExcelFilter_0.ReadOnly = true;
		this.dataGridViewExcelFilter_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		this.dataGridViewExcelFilter_0.Size = new Size(890, 410);
		this.dataGridViewExcelFilter_0.TabIndex = 7;
		this.bindingSource_0.DataMember = "vl_SchmAbnFull";
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
		this.dataTable_0.TableName = "Table1";
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
		this.splitContainer_2.Dock = DockStyle.Fill;
		this.splitContainer_2.FixedPanel = FixedPanel.Panel1;
		this.splitContainer_2.IsSplitterFixed = true;
		this.splitContainer_2.Location = new Point(0, 0);
		this.splitContainer_2.Name = "splitContainerAbnCount";
		this.splitContainer_2.Panel1.Controls.Add(this.numericUpDown_0);
		this.splitContainer_2.Panel1.Controls.Add(this.numericUpDown_1);
		this.splitContainer_2.Panel1.Controls.Add(this.numericUpDown_2);
		this.splitContainer_2.Panel1.Controls.Add(this.groupBox_3);
		this.splitContainer_2.Panel1.Controls.Add(this.label_25);
		this.splitContainer_2.Panel1.Controls.Add(this.label_26);
		this.splitContainer_2.Panel1.Controls.Add(this.label_27);
		this.splitContainer_2.Panel1.Controls.Add(this.groupBox_4);
		this.splitContainer_2.Panel1.Controls.Add(this.label_30);
		this.splitContainer_2.Panel2.Controls.Add(this.numericUpDown_7);
		this.splitContainer_2.Panel2.Controls.Add(this.numericUpDown_8);
		this.splitContainer_2.Panel2.Controls.Add(this.numericUpDown_9);
		this.splitContainer_2.Panel2.Controls.Add(this.label_31);
		this.splitContainer_2.Panel2.Controls.Add(this.groupBox_5);
		this.splitContainer_2.Panel2.Controls.Add(this.groupBox_6);
		this.splitContainer_2.Panel2.Controls.Add(this.label_37);
		this.splitContainer_2.Panel2.Controls.Add(this.label_38);
		this.splitContainer_2.Panel2.Controls.Add(this.label_39);
		this.splitContainer_2.Panel2.Controls.Add(this.groupBox_7);
		this.splitContainer_2.Size = new Size(890, 208);
		this.splitContainer_2.SplitterDistance = 377;
		this.splitContainer_2.TabIndex = 1;
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
		this.groupBox_3.Controls.Add(this.label_23);
		this.groupBox_3.Controls.Add(this.label_24);
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
		this.label_23.AutoSize = true;
		this.label_23.Location = new Point(158, 21);
		this.label_23.Name = "label14";
		this.label_23.Size = new Size(61, 13);
		this.label_23.TabIndex = 2;
		this.label_23.Text = "Частичное";
		this.label_24.AutoSize = true;
		this.label_24.Location = new Point(6, 21);
		this.label_24.Name = "label19";
		this.label_24.Size = new Size(45, 13);
		this.label_24.TabIndex = 0;
		this.label_24.Text = "Полное";
		this.label_25.AutoSize = true;
		this.label_25.Location = new Point(14, 163);
		this.label_25.Name = "label23";
		this.label_25.Size = new Size(209, 13);
		this.label_25.TabIndex = 7;
		this.label_25.Text = "Производители электрической энергии";
		this.label_26.AutoSize = true;
		this.label_26.Location = new Point(166, 124);
		this.label_26.Name = "label22";
		this.label_26.Size = new Size(158, 13);
		this.label_26.TabIndex = 5;
		this.label_26.Text = "Электросетевая организация";
		this.label_27.AutoSize = true;
		this.label_27.Location = new Point(14, 124);
		this.label_27.Name = "label21";
		this.label_27.Size = new Size(132, 13);
		this.label_27.TabIndex = 3;
		this.label_27.Text = "3 категория надежности";
		this.groupBox_4.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.groupBox_4.Controls.Add(this.numericUpDown_5);
		this.groupBox_4.Controls.Add(this.numericUpDown_6);
		this.groupBox_4.Controls.Add(this.label_28);
		this.groupBox_4.Controls.Add(this.label_29);
		this.groupBox_4.Location = new Point(8, 70);
		this.groupBox_4.Name = "groupBox6";
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
		this.label_28.AutoSize = true;
		this.label_28.Location = new Point(158, 21);
		this.label_28.Name = "label20";
		this.label_28.Size = new Size(61, 13);
		this.label_28.TabIndex = 2;
		this.label_28.Text = "Частичное";
		this.label_29.AutoSize = true;
		this.label_29.Location = new Point(6, 21);
		this.label_29.Name = "label24";
		this.label_29.Size = new Size(45, 13);
		this.label_29.TabIndex = 0;
		this.label_29.Text = "Полное";
		this.label_30.AutoSize = true;
		this.label_30.Location = new Point(5, 0);
		this.label_30.Name = "label25";
		this.label_30.Size = new Size(147, 13);
		this.label_30.TabIndex = 0;
		this.label_30.Text = "Количество точек поставки";
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
		this.label_31.AutoSize = true;
		this.label_31.Location = new Point(3, 0);
		this.label_31.Name = "label31";
		this.label_31.Size = new Size(169, 13);
		this.label_31.TabIndex = 18;
		this.label_31.Text = "Количество потребителей услуг";
		this.groupBox_5.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.groupBox_5.Controls.Add(this.numericUpDown_10);
		this.groupBox_5.Controls.Add(this.numericUpDown_11);
		this.groupBox_5.Controls.Add(this.numericUpDown_12);
		this.groupBox_5.Controls.Add(this.label_32);
		this.groupBox_5.Controls.Add(this.label_33);
		this.groupBox_5.Controls.Add(this.label_34);
		this.groupBox_5.Location = new Point(367, 16);
		this.groupBox_5.Name = "groupBox7";
		this.groupBox_5.Size = new Size(135, 183);
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
		this.numericUpDown_10.Size = new Size(120, 20);
		this.numericUpDown_10.TabIndex = 11;
		this.numericUpDown_10.ValueChanged += this.numericUpDown_16_ValueChanged;
		this.numericUpDown_11.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.numericUpDown_11.Location = new Point(9, 73);
		NumericUpDown numericUpDown12 = this.numericUpDown_11;
		int[] array12 = new int[4];
		array12[0] = 999999;
		numericUpDown12.Maximum = new decimal(array12);
		this.numericUpDown_11.Name = "numCountAbnObj150670";
		this.numericUpDown_11.Size = new Size(120, 20);
		this.numericUpDown_11.TabIndex = 10;
		this.numericUpDown_11.ValueChanged += this.numericUpDown_16_ValueChanged;
		this.numericUpDown_12.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.numericUpDown_12.Location = new Point(9, 34);
		NumericUpDown numericUpDown13 = this.numericUpDown_12;
		int[] array13 = new int[4];
		array13[0] = 999999;
		numericUpDown13.Maximum = new decimal(array13);
		this.numericUpDown_12.Name = "numCountAbnObj150";
		this.numericUpDown_12.Size = new Size(120, 20);
		this.numericUpDown_12.TabIndex = 9;
		this.numericUpDown_12.ValueChanged += this.numericUpDown_16_ValueChanged;
		this.label_32.AutoSize = true;
		this.label_32.Location = new Point(6, 96);
		this.label_32.Name = "label34";
		this.label_32.Size = new Size(62, 13);
		this.label_32.TabIndex = 7;
		this.label_32.Text = "От 670 кВт";
		this.label_33.AutoSize = true;
		this.label_33.Location = new Point(6, 57);
		this.label_33.Name = "label33";
		this.label_33.Size = new Size(98, 13);
		this.label_33.TabIndex = 5;
		this.label_33.Text = "От 150 до 670 кВт";
		this.label_34.AutoSize = true;
		this.label_34.Location = new Point(6, 18);
		this.label_34.Name = "label32";
		this.label_34.Size = new Size(64, 13);
		this.label_34.TabIndex = 0;
		this.label_34.Text = "До 150 кВт";
		this.groupBox_6.Controls.Add(this.numericUpDown_13);
		this.groupBox_6.Controls.Add(this.numericUpDown_14);
		this.groupBox_6.Controls.Add(this.label_35);
		this.groupBox_6.Controls.Add(this.label_36);
		this.groupBox_6.Location = new Point(3, 16);
		this.groupBox_6.Name = "groupBox8";
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
		this.label_35.AutoSize = true;
		this.label_35.Location = new Point(158, 21);
		this.label_35.Name = "label26";
		this.label_35.Size = new Size(61, 13);
		this.label_35.TabIndex = 2;
		this.label_35.Text = "Частичное";
		this.label_36.AutoSize = true;
		this.label_36.Location = new Point(6, 21);
		this.label_36.Name = "label27";
		this.label_36.Size = new Size(45, 13);
		this.label_36.TabIndex = 0;
		this.label_36.Text = "Полное";
		this.label_37.AutoSize = true;
		this.label_37.Location = new Point(9, 163);
		this.label_37.Name = "label28";
		this.label_37.Size = new Size(209, 13);
		this.label_37.TabIndex = 15;
		this.label_37.Text = "Производители электрической энергии";
		this.label_38.AutoSize = true;
		this.label_38.Location = new Point(161, 124);
		this.label_38.Name = "label29";
		this.label_38.Size = new Size(158, 13);
		this.label_38.TabIndex = 13;
		this.label_38.Text = "Электросетевая организация";
		this.label_39.AutoSize = true;
		this.label_39.Location = new Point(9, 124);
		this.label_39.Name = "label30";
		this.label_39.Size = new Size(132, 13);
		this.label_39.TabIndex = 11;
		this.label_39.Text = "3 категория надежности";
		this.groupBox_7.Controls.Add(this.numericUpDown_15);
		this.groupBox_7.Controls.Add(this.numericUpDown_16);
		this.groupBox_7.Controls.Add(this.label_40);
		this.groupBox_7.Controls.Add(this.label_41);
		this.groupBox_7.Location = new Point(3, 70);
		this.groupBox_7.Name = "groupBox9";
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
		this.label_40.AutoSize = true;
		this.label_40.Location = new Point(158, 21);
		this.label_40.Name = "label35";
		this.label_40.Size = new Size(61, 13);
		this.label_40.TabIndex = 2;
		this.label_40.Text = "Частичное";
		this.label_41.AutoSize = true;
		this.label_41.Location = new Point(6, 21);
		this.label_41.Name = "label36";
		this.label_41.Size = new Size(45, 13);
		this.label_41.TabIndex = 0;
		this.label_41.Text = "Полное";
		this.statusStrip_0.Items.AddRange(new ToolStripItem[]
		{
			this.toolStripDropDownButton_0,
			this.toolStripStatusLabel_0,
			this.toolStripStatusLabel_1,
			this.toolStripStatusLabel_2
		});
		this.statusStrip_0.Location = new Point(3, 650);
		this.statusStrip_0.Name = "statusStripAbnObj";
		this.statusStrip_0.Size = new Size(890, 22);
		this.statusStrip_0.TabIndex = 11;
		this.statusStrip_0.Text = "statusStrip1";
		this.toolStripDropDownButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripDropDownButton_0.Image = (Image)componentResourceManager.GetObject("toolBtnRefreshCountAbn.Image");
		this.toolStripDropDownButton_0.ImageTransparentColor = Color.Magenta;
		this.toolStripDropDownButton_0.Name = "toolBtnRefreshCountAbn";
		this.toolStripDropDownButton_0.ShowDropDownArrow = false;
		this.toolStripDropDownButton_0.Size = new Size(20, 20);
		this.toolStripDropDownButton_0.Text = "Обновить итоги";
		this.toolStripDropDownButton_0.Click += this.toolStripDropDownButton_0_Click;
		this.toolStripStatusLabel_0.Name = "labelCountPoint";
		this.toolStripStatusLabel_0.Size = new Size(285, 17);
		this.toolStripStatusLabel_0.Spring = true;
		this.toolStripStatusLabel_0.Text = "Количество точек поставки: 0";
		this.toolStripStatusLabel_1.Name = "labelCountAbnObj";
		this.toolStripStatusLabel_1.Size = new Size(285, 17);
		this.toolStripStatusLabel_1.Spring = true;
		this.toolStripStatusLabel_1.Text = "Количество объектов: 0";
		this.toolStripStatusLabel_2.Name = "labelCountAbn";
		this.toolStripStatusLabel_2.Size = new Size(285, 17);
		this.toolStripStatusLabel_2.Spring = true;
		this.toolStripStatusLabel_2.Text = "Количество абонентов: 0";
		this.toolStrip_1.Items.AddRange(new ToolStripItem[]
		{
			this.toolStripButton_1,
			this.toolStripButton_2
		});
		this.toolStrip_1.Location = new Point(3, 3);
		this.toolStrip_1.Name = "toolStripAbn";
		this.toolStrip_1.Size = new Size(890, 25);
		this.toolStrip_1.TabIndex = 7;
		this.toolStrip_1.Text = "toolStrip1";
		this.toolStripButton_1.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_1.Image = (Image)componentResourceManager.GetObject("toolBtnRefreshAbn.Image");
		this.toolStripButton_1.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_1.Name = "toolBtnRefreshAbn";
		this.toolStripButton_1.Size = new Size(23, 22);
		this.toolStripButton_1.Text = "Обновить";
		this.toolStripButton_1.Click += this.toolStripButton_1_Click;
		this.toolStripButton_2.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_2.Image = (Image)componentResourceManager.GetObject("toolBrnDelAbn.Image");
		this.toolStripButton_2.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_2.Name = "toolBrnDelAbn";
		this.toolStripButton_2.Size = new Size(23, 22);
		this.toolStripButton_2.Text = "Удалить абонентов";
		this.toolStripButton_2.Click += this.toolStripButton_2_Click;
		this.button_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.button_0.DialogResult = DialogResult.Cancel;
		this.button_0.Location = new Point(815, 707);
		this.button_0.Name = "buttonClose";
		this.button_0.Size = new Size(75, 23);
		this.button_0.TabIndex = 1;
		this.button_0.Text = "Закрыть";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_0.Click += this.button_0_Click;
		this.button_1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.button_1.DialogResult = DialogResult.OK;
		this.button_1.Location = new Point(12, 707);
		this.button_1.Name = "buttonSave";
		this.button_1.Size = new Size(75, 23);
		this.button_1.TabIndex = 2;
		this.button_1.Text = "Сохранить";
		this.button_1.UseVisualStyleBackColor = true;
		this.button_1.Click += this.button_1_Click;
		this.dataGridViewComboBoxColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewComboBoxColumn_0.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
		this.dataGridViewComboBoxColumn_0.HeaderText = "Тип объекта";
		this.dataGridViewComboBoxColumn_0.Name = "dataGridViewComboBoxColumn1";
		this.dataGridViewComboBoxColumn_0.Resizable = DataGridViewTriState.True;
		this.dataGridViewComboBoxColumn_0.SortMode = DataGridViewColumnSortMode.Programmatic;
		this.dataGridViewTextBoxColumn_0.HeaderText = "Column1";
		this.dataGridViewTextBoxColumn_0.Name = "dataGridViewTextBoxColumn1";
		this.dataGridViewTextBoxColumn_0.ReadOnly = true;
		this.dataGridViewTextBoxColumn_1.HeaderText = "Column2";
		this.dataGridViewTextBoxColumn_1.Name = "dataGridViewTextBoxColumn2";
		this.dataGridViewTextBoxColumn_1.ReadOnly = true;
		this.dataGridViewTextBoxColumn_1.Visible = false;
		this.dataGridViewComboBoxColumn_1.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
		this.dataGridViewComboBoxColumn_1.HeaderText = "Участок";
		this.dataGridViewComboBoxColumn_1.Name = "dataGridViewComboBoxColumn2";
		this.dataGridViewComboBoxColumn_1.ReadOnly = true;
		this.dataGridViewComboBoxColumn_1.Width = 60;
		this.dataGridViewComboBoxColumn_2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewComboBoxColumn_2.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
		this.dataGridViewComboBoxColumn_2.HeaderText = "Повреждение";
		this.dataGridViewComboBoxColumn_2.Name = "dataGridViewComboBoxColumn3";
		this.dataGridViewComboBoxColumn_3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewComboBoxColumn_3.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
		this.dataGridViewComboBoxColumn_3.HeaderText = "Уточнение";
		this.dataGridViewComboBoxColumn_3.Name = "dataGridViewComboBoxColumn4";
		this.dataGridViewTextBoxColumn_2.HeaderText = "Column3";
		this.dataGridViewTextBoxColumn_2.Name = "dataGridViewTextBoxColumn3";
		this.backgroundWorker_0.DoWork += this.backgroundWorker_0_DoWork;
		this.backgroundWorker_0.RunWorkerCompleted += this.backgroundWorker_0_RunWorkerCompleted;
		this.progressBar_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.progressBar_0.Location = new Point(321, 707);
		this.progressBar_0.Name = "progressBar";
		this.progressBar_0.Size = new Size(488, 23);
		this.progressBar_0.Style = ProgressBarStyle.Marquee;
		this.progressBar_0.TabIndex = 8;
		this.progressBar_0.Visible = false;
		this.label_42.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.label_42.AutoSize = true;
		this.label_42.Location = new Point(93, 712);
		this.label_42.Name = "labelProgress";
		this.label_42.Size = new Size(180, 13);
		this.label_42.TabIndex = 7;
		this.label_42.Text = "Загрузка отключенных абонентов";
		this.label_42.Visible = false;
		this.dataColumn_13.ColumnName = "CategoryName";
		this.dataColumn_14.ColumnName = "PowerSet";
		this.dataColumn_14.DataType = typeof(decimal);
		this.dataColumn_15.ColumnName = "countPoint";
		this.dataColumn_15.DataType = typeof(int);
		this.dataGridViewFilterTextBoxColumn_0.DataPropertyName = "codeAbonent";
		this.dataGridViewFilterTextBoxColumn_0.HeaderText = "Код";
		this.dataGridViewFilterTextBoxColumn_0.Name = "codeAbonentDataGridViewTextBoxColumn";
		this.dataGridViewFilterTextBoxColumn_0.ReadOnly = true;
		this.dataGridViewFilterTextBoxColumn_0.Resizable = DataGridViewTriState.True;
		this.dataGridViewFilterTextBoxColumn_0.Visible = false;
		this.dataGridViewFilterTextBoxColumn_0.Width = 5;
		this.dataGridViewTextBoxColumn_5.DataPropertyName = "idAbn";
		this.dataGridViewTextBoxColumn_5.HeaderText = "idAbn";
		this.dataGridViewTextBoxColumn_5.Name = "idAbnDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_5.ReadOnly = true;
		this.dataGridViewTextBoxColumn_5.Visible = false;
		this.dataGridViewFilterTextBoxColumn_1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewFilterTextBoxColumn_1.DataPropertyName = "nameAbn";
		this.dataGridViewFilterTextBoxColumn_1.FillWeight = 85.10515f;
		this.dataGridViewFilterTextBoxColumn_1.HeaderText = "Абонент";
		this.dataGridViewFilterTextBoxColumn_1.Name = "nameAbnDataGridViewTextBoxColumn";
		this.dataGridViewFilterTextBoxColumn_1.ReadOnly = true;
		this.dataGridViewFilterTextBoxColumn_1.Resizable = DataGridViewTriState.True;
		this.dataGridViewFilterComboBoxColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewFilterComboBoxColumn_0.DataPropertyName = "typeAbn";
		this.dataGridViewFilterComboBoxColumn_0.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
		this.dataGridViewFilterComboBoxColumn_0.FillWeight = 70.30425f;
		this.dataGridViewFilterComboBoxColumn_0.HeaderText = "Тип абонента";
		this.dataGridViewFilterComboBoxColumn_0.Name = "typeAbnDgvColumn";
		this.dataGridViewFilterComboBoxColumn_0.ReadOnly = true;
		this.dataGridViewFilterComboBoxColumn_0.Resizable = DataGridViewTriState.True;
		this.dataGridViewTextBoxColumn_6.DataPropertyName = "idAbnObj";
		this.dataGridViewTextBoxColumn_6.HeaderText = "idAbnObj";
		this.dataGridViewTextBoxColumn_6.Name = "idAbnObjDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_6.ReadOnly = true;
		this.dataGridViewTextBoxColumn_6.Visible = false;
		this.dataGridViewFilterTextBoxColumn_2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewFilterTextBoxColumn_2.DataPropertyName = "nameObj";
		this.dataGridViewFilterTextBoxColumn_2.FillWeight = 91.27219f;
		this.dataGridViewFilterTextBoxColumn_2.HeaderText = "Объект";
		this.dataGridViewFilterTextBoxColumn_2.Name = "nameObjDataGridViewTextBoxColumn";
		this.dataGridViewFilterTextBoxColumn_2.ReadOnly = true;
		this.dataGridViewFilterTextBoxColumn_2.Resizable = DataGridViewTriState.True;
		this.dataGridViewFilterTextBoxColumn_3.DataPropertyName = "CategoryName";
		this.dataGridViewFilterTextBoxColumn_3.HeaderText = "Кат";
		this.dataGridViewFilterTextBoxColumn_3.Name = "categoryNameDgColumn";
		this.dataGridViewFilterTextBoxColumn_3.ReadOnly = true;
		this.dataGridViewFilterTextBoxColumn_3.Width = 50;
		this.dataGridViewFilterTextBoxColumn_4.DataPropertyName = "PowerSet";
		this.dataGridViewFilterTextBoxColumn_4.HeaderText = "Мощность";
		this.dataGridViewFilterTextBoxColumn_4.Name = "powerSetDgvColumn";
		this.dataGridViewFilterTextBoxColumn_4.ReadOnly = true;
		this.dataGridViewFilterTextBoxColumn_4.Width = 50;
		this.dataGridViewFilterTextBoxColumn_5.DataPropertyName = "countPoint";
		this.dataGridViewFilterTextBoxColumn_5.HeaderText = "Кол-во т.у.";
		this.dataGridViewFilterTextBoxColumn_5.Name = "countPointDgvColumn";
		this.dataGridViewFilterTextBoxColumn_5.ReadOnly = true;
		this.dataGridViewFilterTextBoxColumn_5.Width = 40;
		this.dataGridViewFilterTextBoxColumn_6.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewFilterTextBoxColumn_6.DataPropertyName = "CommentODS";
		this.dataGridViewFilterTextBoxColumn_6.FillWeight = 101.5506f;
		this.dataGridViewFilterTextBoxColumn_6.HeaderText = "Примечание";
		this.dataGridViewFilterTextBoxColumn_6.Name = "commentODSDgvColumn";
		this.dataGridViewFilterTextBoxColumn_6.ReadOnly = true;
		base.AcceptButton = this.button_1;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = this.button_0;
		base.ClientSize = new Size(902, 738);
		base.Controls.Add(this.progressBar_0);
		base.Controls.Add(this.label_42);
		base.Controls.Add(this.button_1);
		base.Controls.Add(this.button_0);
		base.Controls.Add(this.tabControl_0);
		base.Name = "FormDefectAddEdit";
		this.Text = " ";
		base.FormClosing += this.Form83_FormClosing;
		base.Load += this.Form83_Load;
		base.Shown += this.Form83_Shown;
		this.tabControl_0.ResumeLayout(false);
		this.tabPage_0.ResumeLayout(false);
		this.tabPage_0.PerformLayout();
		this.toolStrip_0.ResumeLayout(false);
		this.toolStrip_0.PerformLayout();
		((ISupportInitialize)this.class171_0).EndInit();
		this.splitContainer_0.Panel1.ResumeLayout(false);
		this.splitContainer_0.Panel2.ResumeLayout(false);
		this.splitContainer_0.Panel2.PerformLayout();
		this.splitContainer_0.ResumeLayout(false);
		this.groupBox_0.ResumeLayout(false);
		this.groupBox_0.PerformLayout();
		this.groupBox_2.ResumeLayout(false);
		this.groupBox_2.PerformLayout();
		((ISupportInitialize)this.dataGridView_0).EndInit();
		this.groupBox_1.ResumeLayout(false);
		this.groupBox_1.PerformLayout();
		this.tabPage_1.ResumeLayout(false);
		this.tabPage_1.PerformLayout();
		this.splitContainer_1.Panel1.ResumeLayout(false);
		this.splitContainer_1.Panel2.ResumeLayout(false);
		this.splitContainer_1.ResumeLayout(false);
		((ISupportInitialize)this.dataGridViewExcelFilter_0).EndInit();
		((ISupportInitialize)this.bindingSource_0).EndInit();
		((ISupportInitialize)this.dataSet_0).EndInit();
		((ISupportInitialize)this.dataTable_0).EndInit();
		((ISupportInitialize)this.dataTable_1).EndInit();
		this.splitContainer_2.Panel1.ResumeLayout(false);
		this.splitContainer_2.Panel1.PerformLayout();
		this.splitContainer_2.Panel2.ResumeLayout(false);
		this.splitContainer_2.Panel2.PerformLayout();
		this.splitContainer_2.ResumeLayout(false);
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
		this.statusStrip_0.ResumeLayout(false);
		this.statusStrip_0.PerformLayout();
		this.toolStrip_1.ResumeLayout(false);
		this.toolStrip_1.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	[CompilerGenerated]
	private bool method_39(ElectricObject electricObject_0)
	{
		return electricObject_0.Id == Convert.ToInt32(this.class171_0.tJ_Damage.Rows[0]["idSchmObj"]);
	}

	internal static void SkWKJ5r3Q9NKDpOgQChM(Form form_0, bool bool_2)
	{
		form_0.Dispose(bool_2);
	}

	private int int_0;

	private bool bool_0;

	private bool bool_1;

	private int? nullable_0;

	private int int_1;

	private Class171.Class172 class172_0;

	private Class171.Class184 class184_0;

	private TabControl tabControl_0;

	private TabPage tabPage_0;

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

	private NullableDateTimePicker nullableDateTimePicker_0;

	private Label label_5;

	private TextBox textBox_1;

	private GroupBox groupBox_0;

	private Button button_2;

	private Label label_6;

	private TextBox textBox_2;

	private Label label_7;

	private ComboBoxReadOnly comboBoxReadOnly_2;

	private ComboBoxReadOnly comboBoxReadOnly_3;

	private Label label_8;

	private Label label_9;

	private ComboBoxReadOnly comboBoxReadOnly_4;

	private ComboBoxReadOnly comboBoxReadOnly_5;

	private Label label_10;

	private TextBox textBox_3;

	private Label label_11;

	private TextBox textBox_4;

	private Label label_12;

	private GroupBox groupBox_1;

	private NullableDateTimePicker nullableDateTimePicker_1;

	private Label label_13;

	private ComboBox comboBox_0;

	private CheckBox checkBox_0;

	private RichTextBox richTextBox_0;

	private Label label_14;

	private ComboBox comboBox_1;

	private DataGridView dataGridView_0;

	private Label label_15;

	private ComboBoxReadOnly comboBoxReadOnly_6;

	private Label label_16;

	private Class171 class171_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

	private TextBox textBox_5;

	private Label label_17;

	private CheckBox checkBox_1;

	private Label label_18;

	private NullableDateTimePicker nullableDateTimePicker_2;

	private Label label_19;

	private Button button_3;

	private ToolTip toolTip_0;

	private RichTextBox richTextBox_1;

	private Label label_20;

	private GroupBox groupBox_2;

	private SplitContainer splitContainer_0;

	private RichTextBox richTextBox_2;

	private Label label_21;

	private RichTextBox richTextBox_3;

	private Label label_22;

	private ComboBoxReadOnly comboBoxReadOnly_7;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_0;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_1;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_2;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_3;

	private ComboBoxReadOnly comboBoxReadOnly_8;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_4;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_3;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_4;

	private DataGridViewButtonColumn dataGridViewButtonColumn_0;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_5;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_6;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_7;

	private ToolStrip toolStrip_0;

	private ToolStripButton toolStripButton_0;

	private TabPage tabPage_1;

	private ToolStrip toolStrip_1;

	private ToolStripButton toolStripButton_1;

	private ToolStripButton toolStripButton_2;

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

	private DataColumn dataColumn_12;

	private BindingSource bindingSource_0;

	private SplitContainer splitContainer_1;

	private DataGridViewExcelFilter dataGridViewExcelFilter_0;

	private SplitContainer splitContainer_2;

	private NumericUpDown numericUpDown_0;

	private NumericUpDown numericUpDown_1;

	private NumericUpDown numericUpDown_2;

	private GroupBox groupBox_3;

	private NumericUpDown numericUpDown_3;

	private NumericUpDown numericUpDown_4;

	private Label label_23;

	private Label label_24;

	private Label label_25;

	private Label label_26;

	private Label label_27;

	private GroupBox groupBox_4;

	private NumericUpDown numericUpDown_5;

	private NumericUpDown numericUpDown_6;

	private Label label_28;

	private Label label_29;

	private Label label_30;

	private NumericUpDown numericUpDown_7;

	private NumericUpDown numericUpDown_8;

	private NumericUpDown numericUpDown_9;

	private Label label_31;

	private GroupBox groupBox_5;

	private NumericUpDown numericUpDown_10;

	private NumericUpDown numericUpDown_11;

	private NumericUpDown numericUpDown_12;

	private Label label_32;

	private Label label_33;

	private Label label_34;

	private GroupBox groupBox_6;

	private NumericUpDown numericUpDown_13;

	private NumericUpDown numericUpDown_14;

	private Label label_35;

	private Label label_36;

	private Label label_37;

	private Label label_38;

	private Label label_39;

	private GroupBox groupBox_7;

	private NumericUpDown numericUpDown_15;

	private NumericUpDown numericUpDown_16;

	private Label label_40;

	private Label label_41;

	private StatusStrip statusStrip_0;

	private ToolStripDropDownButton toolStripDropDownButton_0;

	private ToolStripStatusLabel toolStripStatusLabel_0;

	private ToolStripStatusLabel toolStripStatusLabel_1;

	private ToolStripStatusLabel toolStripStatusLabel_2;

	private BackgroundWorker backgroundWorker_0;

	private ProgressBar progressBar_0;

	private Label label_42;

	private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_5;

	private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_1;

	private DataGridViewFilterComboBoxColumn dataGridViewFilterComboBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_6;

	private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_2;

	private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_3;

	private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_4;

	private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_5;

	private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_6;

	private DataColumn dataColumn_13;

	private DataColumn dataColumn_14;

	private DataColumn dataColumn_15;
}
