using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using ControlsLbr;
using ControlsLbr.DataGridViewExcelFilter;
using Documents.Properties;
using FormLbr;
using FormLbr.Classes;

internal partial class Form54 : FormBase
{
	public Form54()
	{
		
		this.int_0 = -1;
		this.int_1 = -1;
		this.enum15_0 = (Enum15)2;
		this.dateTime_0 = new DateTime(1900, 1, 1);
		this.dateTime_1 = new DateTime(9000, 1, 1);
		this.dictionary_0 = new Dictionary<int, string>();
		this.int_2 = -1;
		
		this.method_12();
	}

	public Form54(int int_3, int int_4, Enum15 enum15_1, bool bool_1 = false)
	{
		
		this.int_0 = -1;
		this.int_1 = -1;
		this.enum15_0 = (Enum15)2;
		this.dateTime_0 = new DateTime(1900, 1, 1);
		this.dateTime_1 = new DateTime(9000, 1, 1);
		this.dictionary_0 = new Dictionary<int, string>();
		this.int_2 = -1;
		
		this.method_12();
		this.int_0 = int_3;
		this.int_1 = int_4;
		this.enum15_0 = enum15_1;
		this.bool_0 = bool_1;
	}

	public Form54(DataRow dataRow_1)
	{
		
		this.int_0 = -1;
		this.int_1 = -1;
		this.enum15_0 = (Enum15)2;
		this.dateTime_0 = new DateTime(1900, 1, 1);
		this.dateTime_1 = new DateTime(9000, 1, 1);
		this.dictionary_0 = new Dictionary<int, string>();
		this.int_2 = -1;
		
		this.method_12();
		this.int_0 = -1;
		this.int_1 = Convert.ToInt32(dataRow_1["idDivision"]);
		this.enum15_0 = (Enum15)0;
		this.dataRow_0 = dataRow_1;
	}

	private void Form54_Load(object sender, EventArgs e)
	{
		this.nullableDateTimePicker_1.Value = DateTime.Now;
		this.dateTimePicker_1.Value = DateTime.Now.Date.AddHours(8.0);
		this.dateTimePicker_0.Value = DateTime.Now.Date.AddHours(17.0);
		this.method_1();
		this.method_4();
		this.method_5();
		this.method_0();
		base.LoadFormConfig(null);
		switch (this.enum15_0)
		{
		case (Enum15)0:
			if (this.dataRow_0 != null)
			{
				DataRow dataRow = this.class255_0.tJ_RequestForRepair.NewRow();
				dataRow["num"] = 0;
				dataRow["dateCreate"] = DateTime.Now;
				dataRow["idWorker"] = this.dataRow_0["idWorker"];
				dataRow["reguestFiled"] = this.dataRow_0["reguestFiled"];
				dataRow["idSR"] = this.dataRow_0["idSR"];
				dataRow["schmObj"] = this.dataRow_0["schmObj"];
				dataRow["Purpose"] = this.dataRow_0["Purpose"];
				dataRow["IsPlanned"] = this.dataRow_0["IsPlanned"];
				dataRow["agreed"] = this.dataRow_0["agreed"];
				dataRow["iddivision"] = this.dataRow_0["iddivision"];
				dataRow["Crash"] = this.dataRow_0["Crash"];
				DataTable dataTable = this.method_3();
				base.SelectSqlData(dataTable, true, " where [Login] = SYSTEM_USER ", null, false, 0);
				if (dataTable.Rows.Count > 0)
				{
					dataRow["idUserCreate"] = dataTable.Rows[0]["iduser"];
					if (dataTable.Rows[0]["idWorker"] != DBNull.Value)
					{
						dataRow["IdWorker"] = dataTable.Rows[0]["idWorker"];
					}
				}
				this.class255_0.tJ_RequestForRepair.Rows.Add(dataRow);
			}
			else
			{
				DataRow dataRow2 = this.class255_0.tJ_RequestForRepair.NewRow();
				dataRow2["num"] = 0;
				dataRow2["dateCreate"] = DateTime.Now;
				dataRow2["idWorker"] = -1;
				dataRow2["reguestFiled"] = "";
				dataRow2["idSR"] = this.int_2;
				dataRow2["schmObj"] = "";
				dataRow2["Purpose"] = "";
				dataRow2["Crash"] = this.bool_0;
				if (this.bool_0)
				{
					dataRow2["isPlanned"] = false;
				}
				else
				{
					dataRow2["IsPlanned"] = true;
				}
				dataRow2["agreed"] = false;
				dataRow2["iddivision"] = this.int_1;
				DataTable dataTable2 = this.method_3();
				base.SelectSqlData(dataTable2, true, " where [Login] = SYSTEM_USER ", null, false, 0);
				if (dataTable2.Rows.Count > 0)
				{
					dataRow2["idUserCreate"] = dataTable2.Rows[0]["iduser"];
					if (dataTable2.Rows[0]["idWorker"] != DBNull.Value)
					{
						dataRow2["IdWorker"] = dataTable2.Rows[0]["idWorker"];
					}
				}
				this.class255_0.tJ_RequestForRepair.Rows.Add(dataRow2);
				if (this.bool_0)
				{
					this.comboBox_1.SelectedIndex = 0;
				}
				else
				{
					this.comboBox_1.SelectedIndex = 1;
				}
				if (this.comboBox_6.SelectedItem != null)
				{
					dataRow2["reguestFiled"] = this.comboBox_6.Text;
				}
			}
			break;
		case (Enum15)1:
			if (this.int_0 > 0)
			{
				base.SelectSqlData(this.class255_0, this.class255_0.tJ_RequestForRepair, true, " where id = " + this.int_0.ToString());
				base.SelectSqlData(this.class255_0, this.class255_0.tJ_RequestForRepairDaily, true, " where idRequest = " + this.int_0.ToString());
				base.SelectSqlData(this.class255_0, this.class255_0.tJ_RequestForRepairDoc, true, " where idRequest = " + this.int_0.ToString());
				this.method_9();
			}
			break;
		case (Enum15)2:
			if (this.int_0 > 0)
			{
				base.SelectSqlData(this.class255_0, this.class255_0.tJ_RequestForRepair, true, " where id = " + this.int_0.ToString());
				base.SelectSqlData(this.class255_0, this.class255_0.tJ_RequestForRepairDaily, true, " where idRequest = " + this.int_0.ToString());
				base.SelectSqlData(this.class255_0, this.class255_0.tJ_RequestForRepairDoc, true, " where idRequest = " + this.int_0.ToString());
				this.method_9();
			}
			this.comboBox_6.Enabled = false;
			this.comboBox_4.Enabled = false;
			this.comboBox_0.Enabled = false;
			this.textBox_1.ReadOnly = true;
			this.textBox_0.ReadOnly = true;
			this.comboBox_1.Enabled = false;
			this.groupBox_2.Enabled = false;
			this.textBox_3.ReadOnly = true;
			this.textBox_2.ReadOnly = true;
			this.textBox_5.ReadOnly = true;
			this.checkBox_0.Enabled = false;
			this.nullableDateTimePicker_0.Enabled = false;
			this.comboBox_2.Enabled = false;
			break;
		}
		if (this.class255_0.tJ_RequestForRepair.Rows.Count > 0)
		{
			if (this.int_1 <= 0)
			{
				this.int_1 = Convert.ToInt32(this.class255_0.tJ_RequestForRepair.Rows[0]["IdDivision"]);
			}
			if (Convert.ToBoolean(this.class255_0.tJ_RequestForRepair.Rows[0]["IsPlanned"]))
			{
				this.comboBox_1.SelectedIndex = 1;
			}
			else
			{
				this.comboBox_1.SelectedIndex = 0;
			}
			if (this.class255_0.tJ_RequestForRepair.Rows[0]["Crash"] != DBNull.Value && Convert.ToBoolean(this.class255_0.tJ_RequestForRepair.Rows[0]["Crash"]))
			{
				this.comboBox_1.Enabled = false;
			}
		}
		if (this.int_1 == 921)
		{
			this.groupBox_1.Visible = false;
		}
	}

	private void method_0()
	{
		DataTable dataTable = new DataTable("tUser");
		dataTable.Columns.Add("idUser", typeof(int));
		base.SelectSqlData(dataTable, true, " left join vworkergroup w on w.id = tuser.idWorker\r\n                                where w.ParentKey = ';GroupWorker;Dispatchers;' and tuser.login = SYSTEM_USER", null, false, 0);
		if (dataTable.Rows.Count == 0)
		{
			this.groupBox_1.Enabled = false;
			this.nullableDateTimePicker_1.Enabled = false;
			this.nullableDateTimePicker_2.Enabled = false;
			return;
		}
		this.groupBox_1.Enabled = true;
		this.nullableDateTimePicker_1.Enabled = true;
		this.nullableDateTimePicker_2.Enabled = true;
	}

	private void groupBox_1_VisibleChanged(object sender, EventArgs e)
	{
		if (!this.groupBox_1.Visible)
		{
			this.tabControl_0.Height = 325;
			base.Height = 391;
			this.button_1.Location = new Point(this.button_1.Location.X, 331);
			this.button_0.Location = new Point(this.button_0.Location.X, 331);
			return;
		}
		this.tabControl_0.Height = 581;
		base.Height = 647;
		this.button_1.Location = new Point(this.button_1.Location.X, 587);
		this.button_0.Location = new Point(this.button_0.Location.X, 587);
	}

	private void method_1()
	{
		if (this.int_1 > 0)
		{
			base.SelectSqlData(this.class255_0, this.class255_0.tR_Classifier, true, "where id = " + this.int_1.ToString());
		}
		string str = "";
		if (this.class255_0.tR_Classifier.Rows.Count > 0)
		{
			str = " " + this.class255_0.tR_Classifier.Rows[0]["SocrName"].ToString();
		}
		switch (this.enum15_0)
		{
		case (Enum15)0:
			if (this.bool_0)
			{
				this.Text = "Создать новую аварийную заявку" + str;
				return;
			}
			this.Text = "Создать новую заявку" + str;
			return;
		case (Enum15)1:
			if (this.bool_0)
			{
				this.Text = "Редактирование аварийной заявки" + str;
				return;
			}
			this.Text = "Редактирование заявки" + str;
			return;
		case (Enum15)2:
			if (this.bool_0)
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

	private DataTable method_2()
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

	private DataTable method_3()
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

	private void method_4()
	{
		DataTable dataTable = this.method_3();
		base.SelectSqlData(dataTable, true, " order by name ", null, false, 0);
		this.comboBox_3.DataSource = dataTable;
		this.comboBox_3.DisplayMember = "NAME";
		this.comboBox_3.ValueMember = "IDUSER";
		DataTable dataTable2 = this.method_2();
		base.SelectSqlData(dataTable2, true, " where ParentKey in (';GroupWorker;ITR;')  and dateend is null group by id, fio, groupelectrical order by fio ", null, false, 0);
		this.comboBox_6.DataSource = dataTable2;
		this.comboBox_6.DisplayMember = "FIO";
		this.comboBox_6.ValueMember = "ID";
		this.comboBox_4.DataSource = dataTable2;
		this.comboBox_4.DisplayMember = "FIO";
		this.comboBox_4.ValueMember = "ID";
		DataTable dataTable3 = this.method_2();
		base.SelectSqlData(dataTable3, true, " where ParentKey in (';GroupWorker;ReconcileRequestRepair;')  and dateend is null group by id, fio, groupelectrical order by fio ", null, false, 0);
		this.comboBox_2.DataSource = dataTable3;
		this.comboBox_2.DisplayMember = "FIO";
		this.comboBox_2.ValueMember = "ID";
		base.SelectSqlData(this.class255_0, this.class255_0.tR_Classifier, true, " where ParentKey = ';NetworkAreas;' and deleted = 0 and isGroup = 0 order by name ");
		this.comboBox_0.DataSource = this.class255_0.tR_Classifier;
		this.comboBox_0.DisplayMember = "name";
		this.comboBox_0.ValueMember = "ID";
	}

	private void method_5()
	{
		this.dataTable_0 = new DataTable("tR_RequestForRepairClient");
		base.SelectSqlData(this.dataTable_0, true, "where type = 5 order by name", null, false, 0);
		DataTable dataTable = new DataTable("tR_RequestForRepairClient");
		dataTable.Columns.Add("name", typeof(string));
		dataTable.Columns.Add("value", typeof(int));
		this.comboBox_5.DataSource = dataTable;
		this.comboBox_5.DisplayMember = "Name";
		this.comboBox_5.ValueMember = "Value";
		if (dataTable.Rows.Count == 0)
		{
			foreach (object obj in this.dataTable_0.Rows)
			{
				DataRow dataRow = (DataRow)obj;
				dataTable.Rows.Add(new object[]
				{
					dataRow["name"],
					dataRow["Value"]
				});
			}
		}
	}

	private bool method_6()
	{
		bool result = true;
		if (string.IsNullOrEmpty(this.comboBox_4.Text))
		{
			this.label_1.ForeColor = Color.Red;
			result = false;
		}
		if (this.comboBox_0.SelectedIndex < 0)
		{
			this.label_2.ForeColor = Color.Red;
			result = false;
		}
		if (string.IsNullOrEmpty(this.textBox_1.Text))
		{
			this.label_6.ForeColor = Color.Red;
			result = false;
		}
		if (string.IsNullOrEmpty(this.textBox_0.Text))
		{
			this.label_5.ForeColor = Color.Red;
			result = false;
		}
		if (this.comboBox_1.SelectedIndex < 0)
		{
			this.label_4.ForeColor = Color.Red;
			result = false;
		}
		if (this.class255_0.tJ_RequestForRepairDaily.Rows.Count <= 0)
		{
			List<Color> list = new List<Color>();
			foreach (object obj in this.groupBox_2.Controls)
			{
				Control control = (Control)obj;
				list.Add(control.ForeColor);
			}
			this.groupBox_2.ForeColor = Color.Red;
			int num = 0;
			foreach (object obj2 in this.groupBox_2.Controls)
			{
				((Control)obj2).ForeColor = list[num];
				num++;
			}
			result = false;
		}
		if (this.checkBox_0.Checked && this.int_1 == 920 && this.comboBox_5.SelectedIndex < 0)
		{
			this.label_16.ForeColor = Color.Red;
			result = false;
		}
		return result;
	}

	private void Form54_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (base.DialogResult == DialogResult.OK)
		{
			if (this.enum15_0 != (Enum15)2 && !this.method_6())
			{
				MessageBox.Show("Не введены обязательные поля", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				e.Cancel = true;
				return;
			}
			Enum15 @enum = this.enum15_0;
			if (@enum == (Enum15)0)
			{
				this.class255_0.tJ_RequestForRepair.Rows[0].EndEdit();
				this.int_0 = base.InsertSqlDataOneRow(this.class255_0, this.class255_0.tJ_RequestForRepair);
				foreach (DataRow dataRow in this.class255_0.tJ_RequestForRepairDaily)
				{
					if (dataRow.RowState != DataRowState.Detached && dataRow.RowState != DataRowState.Deleted)
					{
						dataRow["idRequest"] = this.int_0;
						dataRow.EndEdit();
					}
				}
				base.InsertSqlData(this.class255_0, this.class255_0.tJ_RequestForRepairDaily);
				base.UpdateSqlData(this.class255_0, this.class255_0.tJ_RequestForRepairDaily);
				base.DeleteSqlData(this.class255_0, this.class255_0.tJ_RequestForRepairDaily);
				this.method_10();
				this.method_11();
				return;
			}
			if (@enum != (Enum15)1)
			{
				return;
			}
			this.class255_0.tJ_RequestForRepair.Rows[0].EndEdit();
			base.UpdateSqlData(this.class255_0, this.class255_0.tJ_RequestForRepair);
			foreach (DataRow dataRow2 in this.class255_0.tJ_RequestForRepairDaily)
			{
				if (dataRow2.RowState != DataRowState.Detached && dataRow2.RowState != DataRowState.Deleted)
				{
					dataRow2["idRequest"] = this.int_0;
					dataRow2.EndEdit();
				}
			}
			base.InsertSqlData(this.class255_0, this.class255_0.tJ_RequestForRepairDaily);
			base.UpdateSqlData(this.class255_0, this.class255_0.tJ_RequestForRepairDaily);
			base.DeleteSqlData(this.class255_0, this.class255_0.tJ_RequestForRepairDaily);
			this.method_10();
			this.method_11();
		}
	}

	private void Form54_FormClosed(object sender, FormClosedEventArgs e)
	{
		base.SaveFormConfig(null);
	}

	private void comboBox_1_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.comboBox_1.SelectedIndex >= 0)
		{
			this.label_4.ForeColor = SystemColors.ControlText;
		}
		if (this.class255_0.tJ_RequestForRepair.Rows.Count > 0)
		{
			if (this.comboBox_1.SelectedIndex == 0)
			{
				this.class255_0.tJ_RequestForRepair.Rows[0]["IsPlanned"] = false;
				return;
			}
			this.class255_0.tJ_RequestForRepair.Rows[0]["IsPlanned"] = true;
		}
	}

	private void checkBox_2_CheckedChanged(object sender, EventArgs e)
	{
		this.checkBox_1.Enabled = this.checkBox_2.Checked;
	}

	private void dateTimePicker_1_ValueChanged(object sender, EventArgs e)
	{
		this.dateTimePicker_0.MinDate = this.dateTimePicker_1.Value.AddMinutes(1.0);
	}

	private void dateTimePicker_0_ValueChanged(object sender, EventArgs e)
	{
		this.dateTimePicker_1.MaxDate = this.dateTimePicker_0.Value.AddMinutes(-1.0);
	}

	private void dataGridView_0_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
	{
		DataRow dataRow = (from o in this.class255_0.tJ_RequestForRepairDaily
		where o.RowState != DataRowState.Deleted && o.RowState != DataRowState.Detached
		select o into a
		orderby a.dateEnd descending
		select a).First<Class255.Class370>();
		if (Convert.ToDateTime(dataRow["DateEnd"]) > this.dateTimePicker_1.MaxDate)
		{
			this.dateTimePicker_1.MaxDate = DateTimePicker.MaximumDateTime;
		}
		this.dateTimePicker_1.MinDate = Convert.ToDateTime(dataRow["DateEnd"]);
	}

	private void dataGridView_0_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
	{
		if (this.class255_0.tJ_RequestForRepairDaily.Rows.Count <= 0)
		{
			this.dateTimePicker_1.MinDate = this.dateTime_0;
			return;
		}
		if ((from o in this.class255_0.tJ_RequestForRepairDaily
		where o.RowState != DataRowState.Deleted && o.RowState != DataRowState.Detached
		select o).Count<Class255.Class370>() > 0)
		{
			DataRow dataRow = (from o in this.class255_0.tJ_RequestForRepairDaily
			where o.RowState != DataRowState.Deleted && o.RowState != DataRowState.Detached
			select o into a
			orderby a.dateEnd descending
			select a).First<Class255.Class370>();
			this.dateTimePicker_1.MinDate = Convert.ToDateTime(dataRow["DateEnd"]);
			return;
		}
		this.dateTimePicker_1.MinDate = this.dateTime_0;
	}

	private void dataGridView_0_CellEndEdit(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex == this.dataGridView_0.Rows.Count - 1)
		{
			DateTime dateTime = Convert.ToDateTime(this.dataGridView_0[this.dataGridViewFilterDateTimePickerColumn_1.Name, e.RowIndex].Value);
			if (dateTime > this.dateTimePicker_1.MaxDate)
			{
				this.dateTimePicker_1.MaxDate = DateTimePicker.MaximumDateTime;
			}
			this.dateTimePicker_1.MinDate = dateTime;
		}
	}

	private void dataGridView_0_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
	{
		if (e.Control is DateTimePicker)
		{
			if (this.dataGridView_0.CurrentCell.OwningColumn.Name == this.dataGridViewFilterDateTimePickerColumn_0.Name)
			{
				(e.Control as DateTimePicker).MaxDate = Convert.ToDateTime(this.dataGridView_0[this.dataGridViewFilterDateTimePickerColumn_1.Name, this.dataGridView_0.CurrentCell.RowIndex].Value);
				if (this.dataGridView_0.CurrentCell.RowIndex == 0)
				{
					(e.Control as DateTimePicker).MinDate = new DateTime(2000, 1, 1);
				}
				if (this.dataGridView_0.CurrentCell.RowIndex > 0)
				{
					(e.Control as DateTimePicker).MinDate = Convert.ToDateTime(this.dataGridView_0[this.dataGridViewFilterDateTimePickerColumn_1.Name, this.dataGridView_0.CurrentCell.RowIndex - 1].Value);
				}
			}
			if (this.dataGridView_0.CurrentCell.OwningColumn.Name == this.dataGridViewFilterDateTimePickerColumn_1.Name)
			{
				(e.Control as DateTimePicker).MinDate = Convert.ToDateTime(this.dataGridView_0[this.dataGridViewFilterDateTimePickerColumn_0.Name, this.dataGridView_0.CurrentCell.RowIndex].Value);
				if (this.dataGridView_0.CurrentCell.RowIndex == this.dataGridView_0.Rows.Count - 1)
				{
					(e.Control as DateTimePicker).MaxDate = new DateTime(9998, 12, 31);
				}
				if (this.dataGridView_0.CurrentCell.RowIndex < this.dataGridView_0.Rows.Count - 1)
				{
					(e.Control as DateTimePicker).MaxDate = Convert.ToDateTime(this.dataGridView_0[this.dataGridViewFilterDateTimePickerColumn_0.Name, this.dataGridView_0.CurrentCell.RowIndex + 1].Value);
				}
			}
		}
	}

	private void dataGridView_0_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
	{
		if (e.RowIndex >= 0)
		{
			DayOfWeek dayOfWeek = Convert.ToDateTime(this.dataGridView_0[this.dataGridViewFilterDateTimePickerColumn_0.Name, e.RowIndex].Value).DayOfWeek;
			DayOfWeek dayOfWeek2 = Convert.ToDateTime(this.dataGridView_0[this.dataGridViewFilterDateTimePickerColumn_1.Name, e.RowIndex].Value).DayOfWeek;
			if ((dayOfWeek == DayOfWeek.Sunday || dayOfWeek == DayOfWeek.Saturday) && this.dataGridView_0.Columns[e.ColumnIndex] == this.dataGridViewFilterDateTimePickerColumn_0)
			{
				e.CellStyle.ForeColor = Color.Red;
			}
			if ((dayOfWeek2 == DayOfWeek.Sunday || dayOfWeek2 == DayOfWeek.Saturday) && this.dataGridView_0.Columns[e.ColumnIndex] == this.dataGridViewFilterDateTimePickerColumn_1)
			{
				e.CellStyle.ForeColor = Color.Red;
			}
		}
	}

	private void button_2_Click(object sender, EventArgs e)
	{
		bool flag = false;
		this.dataGridView_0.RowsAdded -= this.dataGridView_0_RowsAdded;
		if (this.checkBox_2.Checked)
		{
			for (int i = 0; i <= (this.dateTimePicker_0.Value - this.dateTimePicker_1.Value).Days; i++)
			{
				if (this.checkBox_1.Checked || (this.dateTimePicker_1.Value.AddDays((double)i).DayOfWeek != DayOfWeek.Saturday && this.dateTimePicker_1.Value.AddDays((double)i).DayOfWeek != DayOfWeek.Sunday))
				{
					try
					{
						DataRow dataRow = this.class255_0.tJ_RequestForRepairDaily.NewRow();
						dataRow["idRequest"] = this.int_0;
						dataRow["dateBeg"] = this.dateTimePicker_1.Value.AddDays((double)i);
						dataRow["dateEnd"] = this.dateTimePicker_1.Value.AddDays((double)i).Date + this.dateTimePicker_0.Value.TimeOfDay;
						this.class255_0.tJ_RequestForRepairDaily.Rows.Add(dataRow);
						flag = true;
						this.groupBox_2.ForeColor = SystemColors.ControlText;
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
				DataRow dataRow2 = this.class255_0.tJ_RequestForRepairDaily.NewRow();
				dataRow2["idRequest"] = this.int_0;
				dataRow2["dateBeg"] = this.dateTimePicker_1.Value;
				dataRow2["dateEnd"] = this.dateTimePicker_0.Value;
				this.class255_0.tJ_RequestForRepairDaily.Rows.Add(dataRow2);
				flag = true;
				this.groupBox_2.ForeColor = SystemColors.ControlText;
			}
			catch (Exception ex2)
			{
				MessageBox.Show(ex2.Message, ex2.Source, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
		this.dataGridView_0.RowsAdded += this.dataGridView_0_RowsAdded;
		if (flag)
		{
			DataRow dataRow3 = (from o in this.class255_0.tJ_RequestForRepairDaily
			where o.RowState != DataRowState.Deleted && o.RowState != DataRowState.Detached
			select o into a
			orderby a.dateEnd descending
			select a).First<Class255.Class370>();
			if (Convert.ToDateTime(dataRow3["DateEnd"]) > this.dateTimePicker_1.MaxDate)
			{
				this.dateTimePicker_1.MaxDate = this.dateTime_1;
			}
			this.dateTimePicker_1.MinDate = Convert.ToDateTime(dataRow3["DateEnd"]);
		}
	}

	private void comboBox_6_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.comboBox_6.SelectedIndex >= 0)
		{
			this.label_17.ForeColor = SystemColors.ControlText;
		}
	}

	private void method_7(object sender, EventArgs e)
	{
		if (!string.IsNullOrEmpty(this.comboBox_4.Text))
		{
			this.label_1.ForeColor = SystemColors.ControlText;
		}
	}

	private void comboBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.comboBox_0.SelectedIndex >= 0)
		{
			this.label_2.ForeColor = SystemColors.ControlText;
		}
	}

	private void textBox_1_TextChanged(object sender, EventArgs e)
	{
		if (!string.IsNullOrEmpty(this.textBox_1.Text))
		{
			this.label_6.ForeColor = SystemColors.ControlText;
		}
	}

	private void textBox_0_TextChanged(object sender, EventArgs e)
	{
		if (!string.IsNullOrEmpty(this.textBox_0.Text))
		{
			this.label_6.ForeColor = SystemColors.ControlText;
		}
	}

	private void checkBox_0_CheckedChanged(object sender, EventArgs e)
	{
		if (this.checkBox_0.Checked)
		{
			if (this.class255_0.tJ_RequestForRepair.Rows.Count > 0 && this.nullableDateTimePicker_0.Value == null)
			{
				this.class255_0.tJ_RequestForRepair.Rows[0]["Agreed"] = true;
				this.nullableDateTimePicker_0.Value = (this.class255_0.tJ_RequestForRepair.Rows[0]["DateAgreed"] = DateTime.Now);
				return;
			}
		}
		else if (this.class255_0.tJ_RequestForRepair.Rows.Count > 0 && this.nullableDateTimePicker_0.Value != null)
		{
			this.class255_0.tJ_RequestForRepair.Rows[0]["Agreed"] = false;
			this.nullableDateTimePicker_0.Value = null;
			this.class255_0.tJ_RequestForRepair.Rows[0]["DateAgreed"] = DBNull.Value;
		}
	}

	private void method_8()
	{
		this.dataSet_0.Tables[this.dataTable_1.TableName].Clear();
		if (this.class255_0.tL_RequestForRepairSchmObjList.Rows.Count > 0)
		{
			DataView defaultView = this.class255_0.tL_RequestForRepairSchmObjList.DefaultView;
			defaultView.Sort = "Num";
			DataTable dataTable = defaultView.ToTable();
			int num = 0;
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
						DataRow dataRow2 = this.dataSet_0.Tables[this.dataTable_1.TableName].NewRow();
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
						dataRow2["Num"] = num;
						this.dataSet_0.Tables[this.dataTable_1.TableName].Rows.Add(dataRow2);
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
				}
			}
			if (list.Count > 0)
			{
				list.Sort();
				DataRow dataRow4 = this.dataSet_0.Tables[this.dataTable_1.TableName].NewRow();
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
				dataRow4["Num"] = num;
				this.dataSet_0.Tables[this.dataTable_1.TableName].Rows.Add(dataRow4);
			}
			if (this.dataSet_0.Tables[this.dataTable_1.TableName].Rows.Count > 0)
			{
				this.toolStripButton_2.Enabled = true;
				return;
			}
			this.toolStripButton_2.Enabled = false;
		}
	}

	private void method_9()
	{
		base.SelectSqlData(this.class255_0, this.class255_0.tL_RequestForRepairSchmObjList, true, " where idRequest = " + this.int_0.ToString());
		this.method_8();
	}

	private void toolStripButton_0_Click(object sender, EventArgs e)
	{
		Form55 form = new Form55();
		form.SqlSettings = this.SqlSettings;
		if (form.ShowDialog() == DialogResult.OK)
		{
			int num = 1;
			if (this.class255_0.tL_RequestForRepairSchmObjList.Rows.Count > 0)
			{
				num = (int)(this.class255_0.tL_RequestForRepairSchmObjList.Max((Class255.Class372 x) => x.Num) + 1);
			}
			this.dictionary_0 = form.method_0();
			foreach (int num2 in this.dictionary_0.Keys)
			{
				DataRow dataRow = this.class255_0.tL_RequestForRepairSchmObjList.NewRow();
				dataRow["idRequest"] = this.int_0;
				dataRow["idSchmObj"] = num2;
				dataRow["DAteBeg"] = form.DateBeg;
				dataRow["DAteEnd"] = form.DateEnd;
				dataRow["duration"] = form.Duration;
				dataRow["num"] = num;
				this.class255_0.tL_RequestForRepairSchmObjList.Rows.Add(dataRow);
			}
			this.method_8();
		}
	}

	private void dataGridViewExcelFilter_0_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
	{
		this.toolStripButton_3_Click(sender, e);
	}

	private void toolStripButton_3_Click(object sender, EventArgs e)
	{
		if (this.dataGridViewExcelFilter_0.CurrentRow == null)
		{
			return;
		}
		DataRow[] array = this.class255_0.tL_RequestForRepairSchmObjList.Select("num = " + this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_4.Name].Value.ToString());
		this.dictionary_0.Clear();
		if (array.Length != 0)
		{
			Form55 form = new Form55();
			form.SqlSettings = this.SqlSettings;
			form.DateBeg = Convert.ToDateTime(array[0]["dateBeg"]);
			form.DateEnd = Convert.ToDateTime(array[0]["dateEnd"]);
			form.Duration = array[0]["Duration"].ToString();
			form.Num = Convert.ToInt16(array[0]["Num"]);
			foreach (DataRow dataRow in array)
			{
				this.dictionary_0.Add(Convert.ToInt32(dataRow["idSchmObj"]), base.CallSQLScalarFunction("dbo.fn_Schm_GetFullNameObjById", new string[]
				{
					dataRow["idSchmObj"].ToString()
				}).ToString());
			}
			form.method_1(this.dictionary_0);
			if (form.ShowDialog() == DialogResult.OK)
			{
				this.dictionary_0 = form.method_0();
				foreach (DataRow dataRow2 in array)
				{
					if (this.dictionary_0.ContainsKey(Convert.ToInt32(dataRow2["idSchmObj"])))
					{
						dataRow2["DAteBeg"] = form.DateBeg;
						dataRow2["DAteEnd"] = form.DateEnd;
						dataRow2["duration"] = form.Duration;
						this.dictionary_0.Remove(Convert.ToInt32(dataRow2["idSchmObj"]));
					}
					else
					{
						dataRow2.Delete();
					}
				}
				foreach (int num in this.dictionary_0.Keys)
				{
					DataRow dataRow3 = this.class255_0.tL_RequestForRepairSchmObjList.NewRow();
					dataRow3["idRequest"] = this.int_0;
					dataRow3["idSchmObj"] = num;
					dataRow3["DAteBeg"] = form.DateBeg;
					dataRow3["DAteEnd"] = form.DateEnd;
					dataRow3["duration"] = form.Duration;
					dataRow3["num"] = form.Num;
					this.class255_0.tL_RequestForRepairSchmObjList.Rows.Add(dataRow3);
				}
				this.method_8();
			}
		}
	}

	private void toolStripButton_1_Click(object sender, EventArgs e)
	{
		foreach (object obj in this.dataGridViewExcelFilter_0.SelectedRows)
		{
			DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
			DataRow[] array = this.class255_0.tL_RequestForRepairSchmObjList.Select("num = " + dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_4.Name].Value.ToString());
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Delete();
			}
		}
		this.method_8();
	}

	private void toolStripButton_2_Click(object sender, EventArgs e)
	{
		this.dictionary_0.Clear();
		foreach (object obj in this.dataGridViewExcelFilter_0.SelectedRows)
		{
			DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
			foreach (DataRow dataRow in this.class255_0.tL_RequestForRepairSchmObjList.Select("num = " + dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_4.Name].Value.ToString()))
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

	private void method_10()
	{
		foreach (DataRow dataRow in this.class255_0.tL_RequestForRepairSchmObjList)
		{
			if (dataRow.RowState != DataRowState.Detached && dataRow.RowState != DataRowState.Deleted)
			{
				dataRow["idRequest"] = this.int_0;
				dataRow.EndEdit();
			}
		}
		base.InsertSqlData(this.class255_0, this.class255_0.tL_RequestForRepairSchmObjList);
		base.UpdateSqlData(this.class255_0, this.class255_0.tL_RequestForRepairSchmObjList);
		base.DeleteSqlData(this.class255_0, this.class255_0.tL_RequestForRepairSchmObjList);
		this.class255_0.tL_RequestForRepairSchmObjList.AcceptChanges();
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

	private void toolStripButton_4_Click(object sender, EventArgs e)
	{
		try
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Multiselect = true;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				for (int i = 0; i < openFileDialog.FileNames.Length; i++)
				{
					DataRow dataRow = this.class255_0.tJ_RequestForRepairDoc.NewRow();
					dataRow["idRequest"] = this.int_0;
					dataRow["Document"] = File.ReadAllBytes(openFileDialog.FileNames[i]);
					dataRow["FileName"] = Path.GetFileName(openFileDialog.FileNames[i]);
					this.class255_0.tJ_RequestForRepairDoc.Rows.Add(dataRow);
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, ex.Source);
		}
	}

	private void toolStripButton_5_Click(object sender, EventArgs e)
	{
		if (this.dataGridViewExcelFilter_1.CurrentRow != null)
		{
			Convert.ToInt32(this.dataGridViewExcelFilter_1.CurrentRow.Cells[this.dataGridViewTextBoxColumn_5.Name].Value);
			this.dataGridViewExcelFilter_1.Rows.Remove(this.dataGridViewExcelFilter_1.CurrentRow);
			return;
		}
		MessageBox.Show("Не выбрано ни одного файла");
	}

	private void toolStripButton_6_Click(object sender, EventArgs e)
	{
		if (this.dataGridViewExcelFilter_1.CurrentRow == null)
		{
			return;
		}
		int num = Convert.ToInt32(this.dataGridViewExcelFilter_1.CurrentRow.Cells[this.dataGridViewTextBoxColumn_5.Name].Value);
		byte[] array = (byte[])this.class255_0.tJ_RequestForRepairDoc.method_2(num)["Document"];
		string text = Path.GetTempFileName();
		text = Path.ChangeExtension(text, Path.GetExtension(this.class255_0.tJ_RequestForRepairDoc.method_2(num)["FileName"].ToString()));
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

	private void toolStripButton_7_Click(object sender, EventArgs e)
	{
		try
		{
			int num = Convert.ToInt32(this.dataGridViewExcelFilter_1.CurrentRow.Cells[this.dataGridViewTextBoxColumn_5.Name].Value);
			string text = this.dataGridViewExcelFilter_1.CurrentRow.Cells[this.dataGridViewLinkColumn_0.Name].Value.ToString();
			string extension = Path.GetExtension(text);
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = "(*" + extension + ")|*" + extension;
			saveFileDialog.FileName = text;
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				byte[] array = (byte[])this.class255_0.tJ_RequestForRepairDoc.method_2(num)["Document"];
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

	private void dataGridViewExcelFilter_1_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
	{
		if (this.dataGridViewExcelFilter_1.RowCount > 0 && this.dataGridViewExcelFilter_1[this.dataGridViewLinkColumn_0.Name, e.RowIndex].Value != null && e.ColumnIndex == this.dataGridViewExcelFilter_1.Columns[this.dataGridViewImageColumnNotNull_0.Name].Index)
		{
			Icon icon = FormLbr.Classes.FileInfo.IconOfFile(this.dataGridViewExcelFilter_1[this.dataGridViewLinkColumn_0.Name, e.RowIndex].Value.ToString());
			e.Value = icon.ToBitmap();
		}
	}

	private void dataGridViewExcelFilter_1_CellContentClick(object sender, DataGridViewCellEventArgs e)
	{
		if (this.dataGridViewExcelFilter_1.CurrentRow == null)
		{
			return;
		}
		int num = Convert.ToInt32(this.dataGridViewExcelFilter_1.CurrentRow.Cells[this.dataGridViewTextBoxColumn_5.Name].Value);
		if (e.ColumnIndex == this.dataGridViewExcelFilter_1.Columns[this.dataGridViewLinkColumn_0.Name].Index)
		{
			byte[] array = (byte[])this.class255_0.tJ_RequestForRepairDoc.method_2(num)["Document"];
			string text = Path.GetTempFileName();
			text = Path.ChangeExtension(text, Path.GetExtension(this.class255_0.tJ_RequestForRepairDoc.method_2(num)["FileName"].ToString()));
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

	private void method_11()
	{
		foreach (DataRow dataRow in this.class255_0.tJ_RequestForRepairDoc)
		{
			if (dataRow.RowState != DataRowState.Detached && dataRow.RowState != DataRowState.Deleted)
			{
				dataRow["idRequest"] = this.int_0;
				dataRow.EndEdit();
			}
		}
		base.InsertSqlData(this.class255_0, this.class255_0.tJ_RequestForRepairDoc);
		base.UpdateSqlData(this.class255_0, this.class255_0.tJ_RequestForRepairDoc);
		base.DeleteSqlData(this.class255_0, this.class255_0.tJ_RequestForRepairDoc);
		this.class255_0.tL_RequestForRepairSchmObjList.AcceptChanges();
	}

	private void button_3_Click(object sender, EventArgs e)
	{
		if (this.class255_0.tJ_RequestForRepair.Rows.Count <= 0)
		{
			return;
		}
		DataRow dataRow = this.class255_0.tJ_RequestForRepair.NewRow();
		dataRow.ItemArray = this.class255_0.tJ_RequestForRepair.Rows[0].ItemArray;
		this.class255_0.tJ_RequestForRepairDoc.Clear();
		this.class255_0.tJ_RequestForRepairDaily.Clear();
		DataRow dataRow2 = this.class255_0.tJ_RequestForRepair.NewRow();
		dataRow2["num"] = 0;
		dataRow2["dateCreate"] = DateTime.Now;
		if (dataRow["idWorker"] != DBNull.Value)
		{
			dataRow2["idWorker"] = dataRow["idWorker"];
		}
		dataRow2["reguestFiled"] = dataRow["reguestFiled"];
		dataRow2["idSR"] = dataRow["idSR"];
		dataRow2["schmObj"] = dataRow["schmObj"];
		dataRow2["Purpose"] = dataRow["Purpose"];
		dataRow2["IsPlanned"] = dataRow["IsPlanned"];
		dataRow2["Crash"] = dataRow["Crash"];
		dataRow2["agreed"] = false;
		dataRow2["iddivision"] = dataRow["iddivision"];
		DataTable dataTable = this.method_3();
		base.SelectSqlData(dataTable, true, " where [Login] = SYSTEM_USER ", null, false, 0);
		if (dataTable.Rows.Count > 0)
		{
			dataRow2["idUserCreate"] = dataTable.Rows[0]["iduser"];
			if (dataTable.Rows[0]["idWorker"] != DBNull.Value)
			{
				dataRow2["IdWorker"] = dataTable.Rows[0]["idWorker"];
			}
		}
		if (dataRow2["idWorker"] == DBNull.Value)
		{
			dataRow2["idWorker"] = -1;
		}
		this.int_0 = -1;
		this.enum15_0 = (Enum15)0;
		this.class255_0.tJ_RequestForRepair.Rows.Add(dataRow2);
		this.class255_0.tJ_RequestForRepair.Rows.RemoveAt(0);
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
		if (this.enum15_0 == (Enum15)0)
		{
			xmlAttribute.Value = this.comboBox_0.SelectedValue.ToString();
		}
		else
		{
			xmlAttribute.Value = this.int_2.ToString();
		}
		xmlNode.Attributes.Append(xmlAttribute);
		return xmlDocument;
	}

	protected override void ApplyConfig(XmlDocument xmlDocument_0)
	{
		XmlNode xmlNode = xmlDocument_0.SelectSingleNode(base.Name);
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
				this.int_2 = Convert.ToInt32(xmlAttribute.Value);
			}
		}
	}

	private void method_12()
	{
		this.icontainer_0 = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		this.class255_0 = new Class255();
		this.label_0 = new Label();
		this.label_1 = new Label();
		this.label_2 = new Label();
		this.comboBox_0 = new ComboBox();
		this.groupBox_0 = new GroupBox();
		this.comboBox_1 = new ComboBox();
		this.label_4 = new Label();
		this.label_5 = new Label();
		this.textBox_0 = new TextBox();
		this.textBox_1 = new TextBox();
		this.comboBox_6 = new ComboBox();
		this.label_6 = new Label();
		this.label_17 = new Label();
		this.toolStrip_0 = new ToolStrip();
		this.toolStripButton_0 = new ToolStripButton();
		this.toolStripButton_3 = new ToolStripButton();
		this.toolStripButton_1 = new ToolStripButton();
		this.toolStripButton_2 = new ToolStripButton();
		this.groupBox_2 = new GroupBox();
		this.button_2 = new Button();
		this.dataGridView_0 = new DataGridView();
		this.dataGridViewTextBoxColumn_8 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_9 = new DataGridViewTextBoxColumn();
		this.dataGridViewFilterDateTimePickerColumn_0 = new DataGridViewFilterDateTimePickerColumn();
		this.dataGridViewFilterDateTimePickerColumn_1 = new DataGridViewFilterDateTimePickerColumn();
		this.checkBox_1 = new CheckBox();
		this.checkBox_2 = new CheckBox();
		this.dateTimePicker_0 = new DateTimePicker();
		this.label_7 = new Label();
		this.dateTimePicker_1 = new DateTimePicker();
		this.label_3 = new Label();
		this.nullableDateTimePicker_2 = new NullableDateTimePicker();
		this.label_15 = new Label();
		this.groupBox_1 = new GroupBox();
		this.comboBox_5 = new ComboBox();
		this.label_16 = new Label();
		this.textBox_5 = new TextBox();
		this.comboBox_2 = new ComboBox();
		this.label_8 = new Label();
		this.label_9 = new Label();
		this.nullableDateTimePicker_0 = new NullableDateTimePicker();
		this.checkBox_0 = new CheckBox();
		this.nullableDateTimePicker_1 = new NullableDateTimePicker();
		this.label_14 = new Label();
		this.label_10 = new Label();
		this.label_11 = new Label();
		this.label_12 = new Label();
		this.textBox_2 = new TextBox();
		this.textBox_3 = new TextBox();
		this.button_0 = new Button();
		this.button_1 = new Button();
		this.comboBox_3 = new ComboBox();
		this.label_13 = new Label();
		this.textBox_4 = new TextBox();
		this.tabControl_0 = new TabControl();
		this.tabPage_0 = new TabPage();
		this.comboBox_4 = new ComboBox();
		this.toolStrip_2 = new ToolStrip();
		this.toolStripButton_8 = new ToolStripButton();
		this.tabPage_1 = new TabPage();
		this.dataGridViewExcelFilter_0 = new DataGridViewExcelFilter();
		this.dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_3 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_4 = new DataGridViewTextBoxColumn();
		this.bindingSource_0 = new BindingSource(this.icontainer_0);
		this.dataSet_0 = new DataSet();
		this.dataTable_1 = new DataTable();
		this.dataColumn_0 = new DataColumn();
		this.dataColumn_1 = new DataColumn();
		this.dataColumn_2 = new DataColumn();
		this.dataColumn_3 = new DataColumn();
		this.dataColumn_4 = new DataColumn();
		this.dataTable_2 = new DataTable();
		this.dataColumn_5 = new DataColumn();
		this.dataColumn_6 = new DataColumn();
		this.dataColumn_7 = new DataColumn();
		this.dataColumn_8 = new DataColumn();
		this.tabPage_2 = new TabPage();
		this.dataGridViewExcelFilter_1 = new DataGridViewExcelFilter();
		this.dataGridViewTextBoxColumn_5 = new DataGridViewTextBoxColumn();
		this.dataGridViewImageColumnNotNull_0 = new DataGridViewImageColumnNotNull();
		this.dataGridViewTextBoxColumn_6 = new DataGridViewTextBoxColumn();
		this.dataGridViewLinkColumn_0 = new DataGridViewLinkColumn();
		this.dataGridViewTextBoxColumn_7 = new DataGridViewTextBoxColumn();
		this.bindingSource_1 = new BindingSource(this.icontainer_0);
		this.toolStrip_1 = new ToolStrip();
		this.toolStripButton_4 = new ToolStripButton();
		this.toolStripButton_5 = new ToolStripButton();
		this.toolStripButton_6 = new ToolStripButton();
		this.toolStripButton_7 = new ToolStripButton();
		this.button_3 = new Button();
		((ISupportInitialize)this.class255_0).BeginInit();
		this.groupBox_0.SuspendLayout();
		this.toolStrip_0.SuspendLayout();
		this.groupBox_2.SuspendLayout();
		((ISupportInitialize)this.dataGridView_0).BeginInit();
		this.groupBox_1.SuspendLayout();
		this.tabControl_0.SuspendLayout();
		this.tabPage_0.SuspendLayout();
		this.toolStrip_2.SuspendLayout();
		this.tabPage_1.SuspendLayout();
		((ISupportInitialize)this.dataGridViewExcelFilter_0).BeginInit();
		((ISupportInitialize)this.bindingSource_0).BeginInit();
		((ISupportInitialize)this.dataSet_0).BeginInit();
		((ISupportInitialize)this.dataTable_1).BeginInit();
		((ISupportInitialize)this.dataTable_2).BeginInit();
		this.tabPage_2.SuspendLayout();
		((ISupportInitialize)this.dataGridViewExcelFilter_1).BeginInit();
		((ISupportInitialize)this.bindingSource_1).BeginInit();
		this.toolStrip_1.SuspendLayout();
		base.SuspendLayout();
		this.class255_0.DataSetName = "DataSetGES";
		this.class255_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		this.label_0.AutoSize = true;
		this.label_0.Location = new Point(58, 8);
		this.label_0.Name = "label1";
		this.label_0.Size = new Size(37, 13);
		this.label_0.TabIndex = 0;
		this.label_0.Text = "Автор";
		this.label_1.AutoSize = true;
		this.label_1.Location = new Point(19, 35);
		this.label_1.Name = "labelRequestFiled";
		this.label_1.Size = new Size(76, 13);
		this.label_1.TabIndex = 4;
		this.label_1.Text = "Заявку подал";
		this.label_2.AutoSize = true;
		this.label_2.Location = new Point(302, 35);
		this.label_2.Name = "labelSR";
		this.label_2.Size = new Size(38, 13);
		this.label_2.TabIndex = 6;
		this.label_2.Text = "Район";
		this.comboBox_0.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBox_0.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBox_0.DataBindings.Add(new Binding("SelectedValue", this.class255_0, "tJ_RequestForRepair.idSR", true));
		this.comboBox_0.FormattingEnabled = true;
		this.comboBox_0.Location = new Point(358, 32);
		this.comboBox_0.Name = "cmbSR";
		this.comboBox_0.Size = new Size(198, 21);
		this.comboBox_0.TabIndex = 7;
		this.comboBox_0.SelectedIndexChanged += this.comboBox_0_SelectedIndexChanged;
		this.groupBox_0.Controls.Add(this.comboBox_1);
		this.groupBox_0.Controls.Add(this.label_4);
		this.groupBox_0.Controls.Add(this.label_5);
		this.groupBox_0.Controls.Add(this.textBox_0);
		this.groupBox_0.Controls.Add(this.textBox_1);
		this.groupBox_0.Controls.Add(this.comboBox_6);
		this.groupBox_0.Controls.Add(this.label_6);
		this.groupBox_0.Controls.Add(this.label_17);
		this.groupBox_0.Location = new Point(11, 53);
		this.groupBox_0.Name = "groupBox1";
		this.groupBox_0.Size = new Size(545, 97);
		this.groupBox_0.TabIndex = 8;
		this.groupBox_0.TabStop = false;
		this.comboBox_1.FormattingEnabled = true;
		this.comboBox_1.Items.AddRange(new object[]
		{
			"Аварийный",
			"Плановый"
		});
		this.comboBox_1.Location = new Point(101, 68);
		this.comboBox_1.Name = "cmbIsPlanned";
		this.comboBox_1.Size = new Size(121, 21);
		this.comboBox_1.TabIndex = 5;
		this.comboBox_1.SelectedIndexChanged += this.comboBox_1_SelectedIndexChanged;
		this.label_4.AutoSize = true;
		this.label_4.Location = new Point(6, 71);
		this.label_4.Name = "labelIsPlanned";
		this.label_4.Size = new Size(89, 13);
		this.label_4.TabIndex = 4;
		this.label_4.Text = "Вид отключения";
		this.label_5.AutoSize = true;
		this.label_5.Location = new Point(6, 45);
		this.label_5.Name = "labelPurpose";
		this.label_5.Size = new Size(33, 13);
		this.label_5.TabIndex = 3;
		this.label_5.Text = "Цель";
		this.textBox_0.DataBindings.Add(new Binding("Text", this.class255_0, "tJ_RequestForRepair.Purpose", true));
		this.textBox_0.Location = new Point(101, 42);
		this.textBox_0.Name = "txtPurpose";
		this.textBox_0.Size = new Size(438, 20);
		this.textBox_0.TabIndex = 2;
		this.textBox_0.TextChanged += this.textBox_0_TextChanged;
		this.textBox_1.DataBindings.Add(new Binding("Text", this.class255_0, "tJ_RequestForRepair.schmObj", true));
		this.textBox_1.Location = new Point(101, 16);
		this.textBox_1.Name = "txtObject";
		this.textBox_1.Size = new Size(438, 20);
		this.textBox_1.TabIndex = 1;
		this.textBox_1.TextChanged += this.textBox_1_TextChanged;
		this.comboBox_6.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBox_6.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBox_6.DataBindings.Add(new Binding("SelectedValue", this.class255_0, "tJ_RequestForRepair.idWorker", true));
		this.comboBox_6.FormattingEnabled = true;
		this.comboBox_6.Location = new Point(319, 68);
		this.comboBox_6.Name = "cmbWorker";
		this.comboBox_6.Size = new Size(198, 21);
		this.comboBox_6.TabIndex = 3;
		this.comboBox_6.Visible = false;
		this.comboBox_6.SelectedIndexChanged += this.comboBox_6_SelectedIndexChanged;
		this.label_6.AutoSize = true;
		this.label_6.Location = new Point(6, 16);
		this.label_6.Name = "labelObject";
		this.label_6.Size = new Size(45, 13);
		this.label_6.TabIndex = 0;
		this.label_6.Text = "Объект";
		this.label_17.AutoSize = true;
		this.label_17.Location = new Point(254, 71);
		this.label_17.Name = "labelWorker";
		this.label_17.Size = new Size(56, 13);
		this.label_17.TabIndex = 15;
		this.label_17.Text = "Оператор";
		this.label_17.Visible = false;
		this.toolStrip_0.GripStyle = ToolStripGripStyle.Hidden;
		this.toolStrip_0.Items.AddRange(new ToolStripItem[]
		{
			this.toolStripButton_0,
			this.toolStripButton_3,
			this.toolStripButton_1,
			this.toolStripButton_2
		});
		this.toolStrip_0.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
		this.toolStrip_0.Location = new Point(3, 3);
		this.toolStrip_0.Name = "toolStripScheme";
		this.toolStrip_0.Size = new Size(562, 25);
		this.toolStrip_0.TabIndex = 47;
		this.toolStrip_0.Text = "toolStrip1";
		this.toolStripButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_0.Image = Resources.ElementAdd;
		this.toolStripButton_0.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_0.Name = "toolBtnLinkSchmObj";
		this.toolStripButton_0.Size = new Size(23, 22);
		this.toolStripButton_0.Text = "Привязать к схеме";
		this.toolStripButton_0.Click += this.toolStripButton_0_Click;
		this.toolStripButton_3.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_3.Image = Resources.ElementEdit;
		this.toolStripButton_3.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_3.Name = "toolBtnLinkSchmObjEdit";
		this.toolStripButton_3.Size = new Size(23, 22);
		this.toolStripButton_3.Text = "Редактировать";
		this.toolStripButton_3.Click += this.toolStripButton_3_Click;
		this.toolStripButton_1.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_1.Image = Resources.ElementDel;
		this.toolStripButton_1.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_1.Name = "toolBtnDelSchmObj";
		this.toolStripButton_1.Size = new Size(23, 22);
		this.toolStripButton_1.Text = "Удалить";
		this.toolStripButton_1.Click += this.toolStripButton_1_Click;
		this.toolStripButton_2.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_2.Enabled = false;
		this.toolStripButton_2.Image = Resources.ElementInformation;
		this.toolStripButton_2.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_2.Name = "toolBtnViewSChmObj";
		this.toolStripButton_2.Size = new Size(23, 22);
		this.toolStripButton_2.Text = "Показать на схеме";
		this.toolStripButton_2.Click += this.toolStripButton_2_Click;
		this.groupBox_2.Controls.Add(this.button_2);
		this.groupBox_2.Controls.Add(this.dataGridView_0);
		this.groupBox_2.Controls.Add(this.checkBox_1);
		this.groupBox_2.Controls.Add(this.checkBox_2);
		this.groupBox_2.Controls.Add(this.dateTimePicker_0);
		this.groupBox_2.Controls.Add(this.label_7);
		this.groupBox_2.Controls.Add(this.dateTimePicker_1);
		this.groupBox_2.Controls.Add(this.label_3);
		this.groupBox_2.Location = new Point(11, 151);
		this.groupBox_2.Name = "groupBoxDaily";
		this.groupBox_2.Size = new Size(545, 141);
		this.groupBox_2.TabIndex = 10;
		this.groupBox_2.TabStop = false;
		this.groupBox_2.Text = "Даты отключения";
		this.button_2.Location = new Point(9, 115);
		this.button_2.Name = "buttonDaily";
		this.button_2.Size = new Size(75, 23);
		this.button_2.TabIndex = 13;
		this.button_2.Text = "Добавить";
		this.button_2.UseVisualStyleBackColor = true;
		this.button_2.Click += this.button_2_Click;
		this.dataGridView_0.AllowUserToAddRows = false;
		this.dataGridView_0.AllowUserToResizeColumns = false;
		this.dataGridView_0.AllowUserToResizeRows = false;
		this.dataGridView_0.AutoGenerateColumns = false;
		this.dataGridView_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView_0.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewTextBoxColumn_8,
			this.dataGridViewTextBoxColumn_9,
			this.dataGridViewFilterDateTimePickerColumn_0,
			this.dataGridViewFilterDateTimePickerColumn_1
		});
		this.dataGridView_0.DataMember = "tJ_RequestForRepairDaily";
		this.dataGridView_0.DataSource = this.class255_0;
		this.dataGridView_0.Location = new Point(178, 8);
		this.dataGridView_0.Name = "dgvDaily";
		this.dataGridView_0.RowHeadersWidth = 30;
		this.dataGridView_0.Size = new Size(367, 101);
		this.dataGridView_0.TabIndex = 12;
		this.dataGridView_0.VirtualMode = true;
		this.dataGridView_0.CellEndEdit += this.dataGridView_0_CellEndEdit;
		this.dataGridView_0.CellFormatting += this.dataGridView_0_CellFormatting;
		this.dataGridView_0.EditingControlShowing += this.dataGridView_0_EditingControlShowing;
		this.dataGridView_0.RowsAdded += this.dataGridView_0_RowsAdded;
		this.dataGridView_0.RowsRemoved += this.dataGridView_0_RowsRemoved;
		this.dataGridViewTextBoxColumn_8.DataPropertyName = "id";
		this.dataGridViewTextBoxColumn_8.HeaderText = "id";
		this.dataGridViewTextBoxColumn_8.Name = "idDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_8.ReadOnly = true;
		this.dataGridViewTextBoxColumn_8.Visible = false;
		this.dataGridViewTextBoxColumn_9.DataPropertyName = "idRequest";
		this.dataGridViewTextBoxColumn_9.HeaderText = "idRequest";
		this.dataGridViewTextBoxColumn_9.Name = "idRequestDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_9.Visible = false;
		this.dataGridViewFilterDateTimePickerColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewFilterDateTimePickerColumn_0.DataPropertyName = "dateBeg";
		dataGridViewCellStyle.Format = "dd.MM.yyyy HH:mm";
		this.dataGridViewFilterDateTimePickerColumn_0.DefaultCellStyle = dataGridViewCellStyle;
		this.dataGridViewFilterDateTimePickerColumn_0.FillWeight = 50f;
		this.dataGridViewFilterDateTimePickerColumn_0.HeaderText = "Начало";
		this.dataGridViewFilterDateTimePickerColumn_0.Name = "dateBegDataGridViewTextBoxColumn";
		this.dataGridViewFilterDateTimePickerColumn_0.Resizable = DataGridViewTriState.True;
		this.dataGridViewFilterDateTimePickerColumn_1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewFilterDateTimePickerColumn_1.DataPropertyName = "dateEnd";
		dataGridViewCellStyle2.Format = "dd.MM.yyyy HH:mm";
		this.dataGridViewFilterDateTimePickerColumn_1.DefaultCellStyle = dataGridViewCellStyle2;
		this.dataGridViewFilterDateTimePickerColumn_1.FillWeight = 50f;
		this.dataGridViewFilterDateTimePickerColumn_1.HeaderText = "Окончание";
		this.dataGridViewFilterDateTimePickerColumn_1.Name = "dateEndDataGridViewTextBoxColumn";
		this.dataGridViewFilterDateTimePickerColumn_1.Resizable = DataGridViewTriState.True;
		this.checkBox_1.AutoSize = true;
		this.checkBox_1.Checked = true;
		this.checkBox_1.CheckState = CheckState.Checked;
		this.checkBox_1.Enabled = false;
		this.checkBox_1.Location = new Point(9, 92);
		this.checkBox_1.Name = "checkBoxWeekEnd";
		this.checkBox_1.Size = new Size(78, 17);
		this.checkBox_1.TabIndex = 11;
		this.checkBox_1.Text = "Выходные";
		this.checkBox_1.UseVisualStyleBackColor = true;
		this.checkBox_2.AutoSize = true;
		this.checkBox_2.Location = new Point(9, 69);
		this.checkBox_2.Name = "checkBoxDaily";
		this.checkBox_2.Size = new Size(83, 17);
		this.checkBox_2.TabIndex = 10;
		this.checkBox_2.Text = "Ежедневно";
		this.checkBox_2.UseVisualStyleBackColor = true;
		this.checkBox_2.CheckedChanged += this.checkBox_2_CheckedChanged;
		this.dateTimePicker_0.CustomFormat = "dd.MM.yyyy HH:mm";
		this.dateTimePicker_0.Format = DateTimePickerFormat.Custom;
		this.dateTimePicker_0.Location = new Point(30, 43);
		this.dateTimePicker_0.Name = "dateTimePickerEnd";
		this.dateTimePicker_0.Size = new Size(124, 20);
		this.dateTimePicker_0.TabIndex = 1;
		this.dateTimePicker_0.ValueChanged += this.dateTimePicker_0_ValueChanged;
		this.label_7.AutoSize = true;
		this.label_7.Location = new Point(6, 50);
		this.label_7.Name = "label9";
		this.label_7.Size = new Size(19, 13);
		this.label_7.TabIndex = 9;
		this.label_7.Text = "по";
		this.dateTimePicker_1.CustomFormat = "dd.MM.yyyy HH:mm";
		this.dateTimePicker_1.Format = DateTimePickerFormat.Custom;
		this.dateTimePicker_1.Location = new Point(30, 19);
		this.dateTimePicker_1.Name = "dateTimePickerBeg";
		this.dateTimePicker_1.Size = new Size(124, 20);
		this.dateTimePicker_1.TabIndex = 0;
		this.dateTimePicker_1.ValueChanged += this.dateTimePicker_1_ValueChanged;
		this.label_3.AutoSize = true;
		this.label_3.Location = new Point(11, 22);
		this.label_3.Name = "label8";
		this.label_3.Size = new Size(13, 13);
		this.label_3.TabIndex = 8;
		this.label_3.Text = "с";
		this.nullableDateTimePicker_2.CustomFormat = "dd.MM.yyyy HH:mm";
		this.nullableDateTimePicker_2.DataBindings.Add(new Binding("Value", this.class255_0, "tJ_RequestForRepair.dateFactEnd", true));
		this.nullableDateTimePicker_2.Format = DateTimePickerFormat.Custom;
		this.nullableDateTimePicker_2.Location = new Point(147, 45);
		this.nullableDateTimePicker_2.Name = "dtpFactEnd";
		this.nullableDateTimePicker_2.Size = new Size(227, 20);
		this.nullableDateTimePicker_2.TabIndex = 17;
		this.nullableDateTimePicker_2.Value = new DateTime(2015, 8, 10, 13, 57, 6, 22);
		this.label_15.AutoSize = true;
		this.label_15.Location = new Point(10, 51);
		this.label_15.Name = "label3";
		this.label_15.Size = new Size(131, 13);
		this.label_15.TabIndex = 14;
		this.label_15.Text = "Время закрытия заявки";
		this.groupBox_1.Controls.Add(this.nullableDateTimePicker_2);
		this.groupBox_1.Controls.Add(this.label_15);
		this.groupBox_1.Controls.Add(this.comboBox_5);
		this.groupBox_1.Controls.Add(this.label_16);
		this.groupBox_1.Controls.Add(this.textBox_5);
		this.groupBox_1.Controls.Add(this.comboBox_2);
		this.groupBox_1.Controls.Add(this.label_8);
		this.groupBox_1.Controls.Add(this.label_9);
		this.groupBox_1.Controls.Add(this.nullableDateTimePicker_0);
		this.groupBox_1.Controls.Add(this.checkBox_0);
		this.groupBox_1.Controls.Add(this.nullableDateTimePicker_1);
		this.groupBox_1.Controls.Add(this.label_14);
		this.groupBox_1.Controls.Add(this.label_10);
		this.groupBox_1.Controls.Add(this.label_11);
		this.groupBox_1.Controls.Add(this.label_12);
		this.groupBox_1.Controls.Add(this.textBox_2);
		this.groupBox_1.Controls.Add(this.textBox_3);
		this.groupBox_1.Location = new Point(11, 294);
		this.groupBox_1.Name = "groupBoxODS";
		this.groupBox_1.Size = new Size(545, 256);
		this.groupBox_1.TabIndex = 9;
		this.groupBox_1.TabStop = false;
		this.groupBox_1.VisibleChanged += this.groupBox_1_VisibleChanged;
		this.comboBox_5.DataBindings.Add(new Binding("SelectedValue", this.class255_0, "tJ_RequestForRepair.status", true));
		this.comboBox_5.FormattingEnabled = true;
		this.comboBox_5.Location = new Point(165, 224);
		this.comboBox_5.Name = "cmbStatus";
		this.comboBox_5.Size = new Size(374, 21);
		this.comboBox_5.TabIndex = 15;
		this.label_16.AutoSize = true;
		this.label_16.Location = new Point(79, 227);
		this.label_16.Name = "labelStatus";
		this.label_16.Size = new Size(80, 13);
		this.label_16.TabIndex = 14;
		this.label_16.Text = "Статус заявки";
		this.textBox_5.DataBindings.Add(new Binding("Text", this.class255_0, "tJ_RequestForRepair.Address", true));
		this.textBox_5.Location = new Point(106, 126);
		this.textBox_5.Multiline = true;
		this.textBox_5.Name = "txtAdress";
		this.textBox_5.Size = new Size(433, 64);
		this.textBox_5.TabIndex = 11;
		this.comboBox_2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBox_2.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBox_2.DataBindings.Add(new Binding("SelectedValue", this.class255_0, "tJ_RequestForRepair.WorkerAgreed", true));
		this.comboBox_2.FormattingEnabled = true;
		this.comboBox_2.Location = new Point(400, 196);
		this.comboBox_2.Name = "cmbDispatcher";
		this.comboBox_2.Size = new Size(139, 21);
		this.comboBox_2.TabIndex = 10;
		this.label_8.AutoSize = true;
		this.label_8.Location = new Point(316, 198);
		this.label_8.Name = "label14";
		this.label_8.Size = new Size(78, 13);
		this.label_8.TabIndex = 9;
		this.label_8.Text = "Руководитель";
		this.label_9.AutoSize = true;
		this.label_9.Location = new Point(108, 198);
		this.label_9.Name = "label13";
		this.label_9.Size = new Size(33, 13);
		this.label_9.TabIndex = 8;
		this.label_9.Text = "Дата";
		this.nullableDateTimePicker_0.DataBindings.Add(new Binding("Value", this.class255_0, "tJ_RequestForRepair.DateAgreed", true));
		this.nullableDateTimePicker_0.Location = new Point(147, 196);
		this.nullableDateTimePicker_0.Name = "dateTimePickerDateAgreed";
		this.nullableDateTimePicker_0.Size = new Size(163, 20);
		this.nullableDateTimePicker_0.TabIndex = 7;
		this.nullableDateTimePicker_0.Value = new DateTime(2012, 9, 26, 9, 58, 28, 932);
		this.checkBox_0.AutoSize = true;
		this.checkBox_0.DataBindings.Add(new Binding("Checked", this.class255_0, "tJ_RequestForRepair.Agreed", true));
		this.checkBox_0.Location = new Point(14, 199);
		this.checkBox_0.Name = "checkBoxAgreed";
		this.checkBox_0.Size = new Size(83, 17);
		this.checkBox_0.TabIndex = 6;
		this.checkBox_0.Text = "Разрешено";
		this.checkBox_0.UseVisualStyleBackColor = true;
		this.checkBox_0.CheckedChanged += this.checkBox_0_CheckedChanged;
		this.nullableDateTimePicker_1.CustomFormat = "dd.MM.yyyy HH:mm";
		this.nullableDateTimePicker_1.DataBindings.Add(new Binding("Value", this.class255_0, "tJ_RequestForRepair.dateOpenRequest", true));
		this.nullableDateTimePicker_1.Format = DateTimePickerFormat.Custom;
		this.nullableDateTimePicker_1.Location = new Point(147, 19);
		this.nullableDateTimePicker_1.Name = "dtpDateCreate";
		this.nullableDateTimePicker_1.Size = new Size(227, 20);
		this.nullableDateTimePicker_1.TabIndex = 17;
		this.nullableDateTimePicker_1.Value = new DateTime(2012, 10, 18, 8, 39, 41, 178);
		this.label_14.AutoSize = true;
		this.label_14.Location = new Point(11, 21);
		this.label_14.Name = "label2";
		this.label_14.Size = new Size(130, 13);
		this.label_14.TabIndex = 16;
		this.label_14.Text = "Время открытия заявки";
		this.label_10.AutoSize = true;
		this.label_10.Location = new Point(11, 129);
		this.label_10.Name = "label12";
		this.label_10.Size = new Size(44, 13);
		this.label_10.TabIndex = 5;
		this.label_10.Text = "Адреса";
		this.label_11.AutoSize = true;
		this.label_11.Location = new Point(11, 103);
		this.label_11.Name = "label11";
		this.label_11.Size = new Size(77, 13);
		this.label_11.TabIndex = 4;
		this.label_11.Text = "Комментарий";
		this.label_12.AutoSize = true;
		this.label_12.Location = new Point(11, 77);
		this.label_12.Name = "label10";
		this.label_12.Size = new Size(81, 13);
		this.label_12.TabIndex = 3;
		this.label_12.Text = "Согласовать с";
		this.textBox_2.DataBindings.Add(new Binding("Text", this.class255_0, "tJ_RequestForRepair.Comment", true));
		this.textBox_2.Location = new Point(106, 100);
		this.textBox_2.Name = "txtComment";
		this.textBox_2.Size = new Size(433, 20);
		this.textBox_2.TabIndex = 1;
		this.textBox_3.DataBindings.Add(new Binding("Text", this.class255_0, "tJ_RequestForRepair.AgreeWith", true));
		this.textBox_3.Location = new Point(106, 74);
		this.textBox_3.Name = "txtAgreeWith";
		this.textBox_3.Size = new Size(433, 20);
		this.textBox_3.TabIndex = 0;
		this.button_0.DialogResult = DialogResult.OK;
		this.button_0.Location = new Point(15, 587);
		this.button_0.Name = "buttonOK";
		this.button_0.Size = new Size(75, 23);
		this.button_0.TabIndex = 10;
		this.button_0.Text = "ОК";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_0.Click += this.button_0_Click;
		this.button_1.DialogResult = DialogResult.Cancel;
		this.button_1.Location = new Point(485, 587);
		this.button_1.Name = "buttonCancel";
		this.button_1.Size = new Size(75, 23);
		this.button_1.TabIndex = 11;
		this.button_1.Text = "Отмена";
		this.button_1.UseVisualStyleBackColor = true;
		this.button_1.Click += this.button_1_Click;
		this.comboBox_3.DataBindings.Add(new Binding("SelectedValue", this.class255_0, "tJ_RequestForRepair.idUserCreate", true));
		this.comboBox_3.Enabled = false;
		this.comboBox_3.FormattingEnabled = true;
		this.comboBox_3.Location = new Point(101, 5);
		this.comboBox_3.Name = "cmbUserCreate";
		this.comboBox_3.Size = new Size(181, 21);
		this.comboBox_3.TabIndex = 12;
		this.label_13.AutoSize = true;
		this.label_13.Location = new Point(302, 8);
		this.label_13.Name = "label15";
		this.label_13.Size = new Size(41, 13);
		this.label_13.TabIndex = 13;
		this.label_13.Text = "Номер";
		this.textBox_4.DataBindings.Add(new Binding("Text", this.class255_0, "tJ_RequestForRepair.num", true));
		this.textBox_4.Location = new Point(358, 5);
		this.textBox_4.Name = "txtNum";
		this.textBox_4.ReadOnly = true;
		this.textBox_4.Size = new Size(198, 20);
		this.textBox_4.TabIndex = 14;
		this.tabControl_0.Controls.Add(this.tabPage_0);
		this.tabControl_0.Controls.Add(this.tabPage_1);
		this.tabControl_0.Controls.Add(this.tabPage_2);
		this.tabControl_0.Location = new Point(0, 0);
		this.tabControl_0.Name = "tabControl";
		this.tabControl_0.SelectedIndex = 0;
		this.tabControl_0.Size = new Size(576, 581);
		this.tabControl_0.TabIndex = 49;
		this.tabPage_0.Controls.Add(this.comboBox_4);
		this.tabPage_0.Controls.Add(this.toolStrip_2);
		this.tabPage_0.Controls.Add(this.comboBox_0);
		this.tabPage_0.Controls.Add(this.label_0);
		this.tabPage_0.Controls.Add(this.groupBox_2);
		this.tabPage_0.Controls.Add(this.label_1);
		this.tabPage_0.Controls.Add(this.groupBox_1);
		this.tabPage_0.Controls.Add(this.groupBox_0);
		this.tabPage_0.Controls.Add(this.label_2);
		this.tabPage_0.Controls.Add(this.comboBox_3);
		this.tabPage_0.Controls.Add(this.textBox_4);
		this.tabPage_0.Controls.Add(this.label_13);
		this.tabPage_0.Location = new Point(4, 22);
		this.tabPage_0.Name = "tabPageGeneral";
		this.tabPage_0.Padding = new Padding(3);
		this.tabPage_0.Size = new Size(568, 555);
		this.tabPage_0.TabIndex = 0;
		this.tabPage_0.Text = "Общие";
		this.tabPage_0.UseVisualStyleBackColor = true;
		this.comboBox_4.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBox_4.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBox_4.DataBindings.Add(new Binding("Text", this.class255_0, "tJ_RequestForRepair.reguestFiled", true));
		this.comboBox_4.FormattingEnabled = true;
		this.comboBox_4.Location = new Point(101, 32);
		this.comboBox_4.Name = "txtRequestFiled";
		this.comboBox_4.Size = new Size(181, 21);
		this.comboBox_4.TabIndex = 19;
		this.toolStrip_2.Dock = DockStyle.None;
		this.toolStrip_2.GripStyle = ToolStripGripStyle.Hidden;
		this.toolStrip_2.Items.AddRange(new ToolStripItem[]
		{
			this.toolStripButton_8
		});
		this.toolStrip_2.Location = new Point(0, 0);
		this.toolStrip_2.Name = "toolStripMain";
		this.toolStrip_2.Size = new Size(26, 25);
		this.toolStrip_2.TabIndex = 18;
		this.toolStrip_2.Text = "toolStrip1";
		this.toolStripButton_8.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_8.Image = Resources.CopyBuffer;
		this.toolStripButton_8.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_8.Name = "toolBtnCopy";
		this.toolStripButton_8.Size = new Size(23, 22);
		this.toolStripButton_8.Text = "Копировать";
		this.toolStripButton_8.Click += this.button_3_Click;
		this.tabPage_1.Controls.Add(this.dataGridViewExcelFilter_0);
		this.tabPage_1.Controls.Add(this.toolStrip_0);
		this.tabPage_1.Location = new Point(4, 22);
		this.tabPage_1.Name = "tabPageSwitching";
		this.tabPage_1.Padding = new Padding(3);
		this.tabPage_1.Size = new Size(568, 555);
		this.tabPage_1.TabIndex = 1;
		this.tabPage_1.Text = "Оперативные переключения";
		this.tabPage_1.UseVisualStyleBackColor = true;
		this.dataGridViewExcelFilter_0.AllowUserToAddRows = false;
		this.dataGridViewExcelFilter_0.AllowUserToDeleteRows = false;
		this.dataGridViewExcelFilter_0.AllowUserToOrderColumns = true;
		this.dataGridViewExcelFilter_0.AllowUserToVisibleColumns = false;
		this.dataGridViewExcelFilter_0.AutoGenerateColumns = false;
		this.dataGridViewExcelFilter_0.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
		this.dataGridViewExcelFilter_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridViewExcelFilter_0.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewTextBoxColumn_0,
			this.dataGridViewTextBoxColumn_1,
			this.dataGridViewTextBoxColumn_2,
			this.dataGridViewTextBoxColumn_3,
			this.dataGridViewTextBoxColumn_4
		});
		this.dataGridViewExcelFilter_0.DataSource = this.bindingSource_0;
		this.dataGridViewExcelFilter_0.Dock = DockStyle.Fill;
		this.dataGridViewExcelFilter_0.Location = new Point(3, 28);
		this.dataGridViewExcelFilter_0.Name = "dgvLinkObjects";
		this.dataGridViewExcelFilter_0.ReadOnly = true;
		this.dataGridViewExcelFilter_0.RowHeadersWidth = 21;
		this.dataGridViewExcelFilter_0.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
		this.dataGridViewExcelFilter_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		this.dataGridViewExcelFilter_0.Size = new Size(562, 524);
		this.dataGridViewExcelFilter_0.TabIndex = 49;
		this.dataGridViewExcelFilter_0.CellDoubleClick += this.dataGridViewExcelFilter_0_CellDoubleClick;
		this.dataGridViewTextBoxColumn_0.DataPropertyName = "Objects";
		dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
		this.dataGridViewTextBoxColumn_0.DefaultCellStyle = dataGridViewCellStyle3;
		this.dataGridViewTextBoxColumn_0.HeaderText = "Объекты";
		this.dataGridViewTextBoxColumn_0.Name = "objectsDataGridViewTextBoxColumn1";
		this.dataGridViewTextBoxColumn_0.ReadOnly = true;
		this.dataGridViewTextBoxColumn_0.SortMode = DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn_0.Width = 250;
		this.dataGridViewTextBoxColumn_1.DataPropertyName = "DateBeg";
		this.dataGridViewTextBoxColumn_1.HeaderText = "Начало";
		this.dataGridViewTextBoxColumn_1.Name = "dateBegDataGridViewTextBoxColumn2";
		this.dataGridViewTextBoxColumn_1.ReadOnly = true;
		this.dataGridViewTextBoxColumn_1.SortMode = DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn_1.Width = 90;
		this.dataGridViewTextBoxColumn_2.DataPropertyName = "DateEnd";
		this.dataGridViewTextBoxColumn_2.HeaderText = "Окончание";
		this.dataGridViewTextBoxColumn_2.Name = "dateEndDataGridViewTextBoxColumn2";
		this.dataGridViewTextBoxColumn_2.ReadOnly = true;
		this.dataGridViewTextBoxColumn_2.SortMode = DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn_2.Width = 90;
		this.dataGridViewTextBoxColumn_3.DataPropertyName = "Duration";
		this.dataGridViewTextBoxColumn_3.HeaderText = "Длительность";
		this.dataGridViewTextBoxColumn_3.Name = "durationDataGridViewTextBoxColumn1";
		this.dataGridViewTextBoxColumn_3.ReadOnly = true;
		this.dataGridViewTextBoxColumn_3.SortMode = DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn_3.Width = 90;
		this.dataGridViewTextBoxColumn_4.DataPropertyName = "Num";
		this.dataGridViewTextBoxColumn_4.HeaderText = "Num";
		this.dataGridViewTextBoxColumn_4.Name = "numDataGridViewTextBoxColumn1";
		this.dataGridViewTextBoxColumn_4.ReadOnly = true;
		this.dataGridViewTextBoxColumn_4.Visible = false;
		this.bindingSource_0.DataMember = "tableLinkObjects";
		this.bindingSource_0.DataSource = this.dataSet_0;
		this.bindingSource_0.Sort = "Num";
		this.dataSet_0.DataSetName = "NewDataSet";
		this.dataSet_0.Tables.AddRange(new DataTable[]
		{
			this.dataTable_1,
			this.dataTable_2
		});
		this.dataTable_1.Columns.AddRange(new DataColumn[]
		{
			this.dataColumn_0,
			this.dataColumn_1,
			this.dataColumn_2,
			this.dataColumn_3,
			this.dataColumn_4
		});
		this.dataTable_1.TableName = "tableLinkObjects";
		this.dataColumn_0.ColumnName = "Objects";
		this.dataColumn_1.ColumnName = "DateBeg";
		this.dataColumn_1.DataType = typeof(DateTime);
		this.dataColumn_2.ColumnName = "DateEnd";
		this.dataColumn_2.DataType = typeof(DateTime);
		this.dataColumn_3.ColumnName = "Duration";
		this.dataColumn_4.ColumnName = "Num";
		this.dataColumn_4.DataType = typeof(short);
		this.dataTable_2.Columns.AddRange(new DataColumn[]
		{
			this.dataColumn_5,
			this.dataColumn_6,
			this.dataColumn_7,
			this.dataColumn_8
		});
		this.dataTable_2.Constraints.AddRange(new Constraint[]
		{
			new UniqueConstraint("Constraint1", new string[]
			{
				"id"
			}, true)
		});
		this.dataTable_2.PrimaryKey = new DataColumn[]
		{
			this.dataColumn_5
		};
		this.dataTable_2.TableName = "tJ_RequestForReapirDoc";
		this.dataColumn_5.AllowDBNull = false;
		this.dataColumn_5.AutoIncrement = true;
		this.dataColumn_5.ColumnName = "id";
		this.dataColumn_5.DataType = typeof(int);
		this.dataColumn_6.AllowDBNull = false;
		this.dataColumn_6.ColumnName = "idRequest";
		this.dataColumn_6.DataType = typeof(int);
		this.dataColumn_7.ColumnName = "FileName";
		this.dataColumn_8.ColumnName = "Comment";
		this.tabPage_2.Controls.Add(this.dataGridViewExcelFilter_1);
		this.tabPage_2.Controls.Add(this.toolStrip_1);
		this.tabPage_2.Location = new Point(4, 22);
		this.tabPage_2.Name = "tabPageDocuments";
		this.tabPage_2.Padding = new Padding(3);
		this.tabPage_2.Size = new Size(568, 555);
		this.tabPage_2.TabIndex = 2;
		this.tabPage_2.Text = "Документы";
		this.tabPage_2.UseVisualStyleBackColor = true;
		this.dataGridViewExcelFilter_1.AllowUserToAddRows = false;
		this.dataGridViewExcelFilter_1.AllowUserToDeleteRows = false;
		this.dataGridViewExcelFilter_1.AutoGenerateColumns = false;
		this.dataGridViewExcelFilter_1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridViewExcelFilter_1.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewTextBoxColumn_5,
			this.dataGridViewImageColumnNotNull_0,
			this.dataGridViewTextBoxColumn_6,
			this.dataGridViewLinkColumn_0,
			this.dataGridViewTextBoxColumn_7
		});
		this.dataGridViewExcelFilter_1.DataSource = this.bindingSource_1;
		this.dataGridViewExcelFilter_1.Dock = DockStyle.Fill;
		this.dataGridViewExcelFilter_1.Location = new Point(3, 28);
		this.dataGridViewExcelFilter_1.Name = "dgvDocs";
		this.dataGridViewExcelFilter_1.RowHeadersWidth = 21;
		this.dataGridViewExcelFilter_1.Size = new Size(562, 524);
		this.dataGridViewExcelFilter_1.TabIndex = 1;
		this.dataGridViewExcelFilter_1.VirtualMode = true;
		this.dataGridViewExcelFilter_1.CellContentClick += this.dataGridViewExcelFilter_1_CellContentClick;
		this.dataGridViewExcelFilter_1.CellValueNeeded += this.dataGridViewExcelFilter_1_CellValueNeeded;
		this.dataGridViewTextBoxColumn_5.DataPropertyName = "id";
		this.dataGridViewTextBoxColumn_5.HeaderText = "id";
		this.dataGridViewTextBoxColumn_5.Name = "idDataGridViewTextBoxColumnDoc";
		this.dataGridViewTextBoxColumn_5.ReadOnly = true;
		this.dataGridViewTextBoxColumn_5.Visible = false;
		dataGridViewCellStyle4.NullValue = null;
		this.dataGridViewImageColumnNotNull_0.DefaultCellStyle = dataGridViewCellStyle4;
		this.dataGridViewImageColumnNotNull_0.HeaderText = "";
		this.dataGridViewImageColumnNotNull_0.Name = "ColumnImage";
		this.dataGridViewImageColumnNotNull_0.ReadOnly = true;
		this.dataGridViewImageColumnNotNull_0.Resizable = DataGridViewTriState.False;
		this.dataGridViewImageColumnNotNull_0.Width = 30;
		this.dataGridViewTextBoxColumn_6.DataPropertyName = "idRequest";
		this.dataGridViewTextBoxColumn_6.HeaderText = "idRequest";
		this.dataGridViewTextBoxColumn_6.Name = "idRequestDataGridViewTextBoxColumn1";
		this.dataGridViewTextBoxColumn_6.Visible = false;
		this.dataGridViewLinkColumn_0.DataPropertyName = "FileName";
		this.dataGridViewLinkColumn_0.HeaderText = "Файл";
		this.dataGridViewLinkColumn_0.Name = "fileNameDataGridViewTextBoxColumn";
		this.dataGridViewLinkColumn_0.ReadOnly = true;
		this.dataGridViewLinkColumn_0.Resizable = DataGridViewTriState.True;
		this.dataGridViewLinkColumn_0.SortMode = DataGridViewColumnSortMode.Automatic;
		this.dataGridViewLinkColumn_0.Width = 200;
		this.dataGridViewTextBoxColumn_7.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_7.DataPropertyName = "Comment";
		this.dataGridViewTextBoxColumn_7.HeaderText = "Комментарий";
		this.dataGridViewTextBoxColumn_7.Name = "commentDataGridViewTextBoxColumn";
		this.bindingSource_1.DataMember = "tJ_RequestForRepairDoc";
		this.bindingSource_1.DataSource = this.class255_0;
		this.toolStrip_1.Items.AddRange(new ToolStripItem[]
		{
			this.toolStripButton_4,
			this.toolStripButton_5,
			this.toolStripButton_6,
			this.toolStripButton_7
		});
		this.toolStrip_1.Location = new Point(3, 3);
		this.toolStrip_1.Name = "toolStripDocuments";
		this.toolStrip_1.Size = new Size(562, 25);
		this.toolStrip_1.TabIndex = 0;
		this.toolStrip_1.Text = "toolStrip1";
		this.toolStripButton_4.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_4.Image = Resources.ElementAdd;
		this.toolStripButton_4.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_4.Name = "toolBtnAddDoc";
		this.toolStripButton_4.Size = new Size(23, 22);
		this.toolStripButton_4.Text = "Добавить документ";
		this.toolStripButton_4.Click += this.toolStripButton_4_Click;
		this.toolStripButton_5.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_5.Image = Resources.ElementDel;
		this.toolStripButton_5.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_5.Name = "toolBtnDelDoc";
		this.toolStripButton_5.Size = new Size(23, 22);
		this.toolStripButton_5.Text = "Удалить документ";
		this.toolStripButton_5.Click += this.toolStripButton_5_Click;
		this.toolStripButton_6.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_6.Image = Resources.ElementInformation;
		this.toolStripButton_6.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_6.Name = "toolBtnViewDoc";
		this.toolStripButton_6.Size = new Size(23, 22);
		this.toolStripButton_6.Text = "Открыть документ";
		this.toolStripButton_6.Click += this.toolStripButton_6_Click;
		this.toolStripButton_7.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_7.Image = Resources.ElementGo;
		this.toolStripButton_7.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_7.Name = "toolBtnSaveDoc";
		this.toolStripButton_7.Size = new Size(23, 22);
		this.toolStripButton_7.Text = "Сохранить документ";
		this.toolStripButton_7.Click += this.toolStripButton_7_Click;
		this.button_3.Location = new Point(240, 587);
		this.button_3.Name = "buttonCopy";
		this.button_3.Size = new Size(75, 23);
		this.button_3.TabIndex = 50;
		this.button_3.Text = "Копировать";
		this.button_3.UseVisualStyleBackColor = true;
		this.button_3.Visible = false;
		this.button_3.Click += this.button_3_Click;
		base.AcceptButton = this.button_0;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = this.button_1;
		base.ClientSize = new Size(572, 619);
		base.Controls.Add(this.button_3);
		base.Controls.Add(this.tabControl_0);
		base.Controls.Add(this.button_1);
		base.Controls.Add(this.button_0);
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.MaximizeBox = false;
		base.Name = "FormJournalRequestForRepairAddEdit";
		this.Text = "FormJournalRequestForRepairAddEdit";
		base.FormClosing += this.Form54_FormClosing;
		base.FormClosed += this.Form54_FormClosed;
		base.Load += this.Form54_Load;
		((ISupportInitialize)this.class255_0).EndInit();
		this.groupBox_0.ResumeLayout(false);
		this.groupBox_0.PerformLayout();
		this.toolStrip_0.ResumeLayout(false);
		this.toolStrip_0.PerformLayout();
		this.groupBox_2.ResumeLayout(false);
		this.groupBox_2.PerformLayout();
		((ISupportInitialize)this.dataGridView_0).EndInit();
		this.groupBox_1.ResumeLayout(false);
		this.groupBox_1.PerformLayout();
		this.tabControl_0.ResumeLayout(false);
		this.tabPage_0.ResumeLayout(false);
		this.tabPage_0.PerformLayout();
		this.toolStrip_2.ResumeLayout(false);
		this.toolStrip_2.PerformLayout();
		this.tabPage_1.ResumeLayout(false);
		this.tabPage_1.PerformLayout();
		((ISupportInitialize)this.dataGridViewExcelFilter_0).EndInit();
		((ISupportInitialize)this.bindingSource_0).EndInit();
		((ISupportInitialize)this.dataSet_0).EndInit();
		((ISupportInitialize)this.dataTable_1).EndInit();
		((ISupportInitialize)this.dataTable_2).EndInit();
		this.tabPage_2.ResumeLayout(false);
		this.tabPage_2.PerformLayout();
		((ISupportInitialize)this.dataGridViewExcelFilter_1).EndInit();
		((ISupportInitialize)this.bindingSource_1).EndInit();
		this.toolStrip_1.ResumeLayout(false);
		this.toolStrip_1.PerformLayout();
		base.ResumeLayout(false);
	}

	private int int_0;

	private int int_1;

	private Enum15 enum15_0;

	private DateTime dateTime_0;

	private DateTime dateTime_1;

	private bool bool_0;

	private DataRow dataRow_0;

	private DataTable dataTable_0;

	private Dictionary<int, string> dictionary_0;

	private int int_2;

	private Class255 class255_0;

	private Label label_0;

	private Label label_1;

	private Label label_2;

	private ComboBox comboBox_0;

	private GroupBox groupBox_0;

	private Label label_3;

	private ComboBox comboBox_1;

	private Label label_4;

	private Label label_5;

	private TextBox textBox_0;

	private TextBox textBox_1;

	private Label label_6;

	private Label label_7;

	private GroupBox groupBox_1;

	private TextBox textBox_2;

	private TextBox textBox_3;

	private Button button_0;

	private Button button_1;

	private ComboBox comboBox_2;

	private Label label_8;

	private Label label_9;

	private NullableDateTimePicker nullableDateTimePicker_0;

	private CheckBox checkBox_0;

	private Label label_10;

	private Label label_11;

	private Label label_12;

	private ComboBox comboBox_3;

	private Label label_13;

	private TextBox textBox_4;

	private GroupBox groupBox_2;

	private Button button_2;

	private DataGridView dataGridView_0;

	private CheckBox checkBox_1;

	private CheckBox checkBox_2;

	private DateTimePicker dateTimePicker_0;

	private DateTimePicker dateTimePicker_1;

	private Label label_14;

	private NullableDateTimePicker nullableDateTimePicker_1;

	private ToolStrip toolStrip_0;

	private ToolStripButton toolStripButton_0;

	private ToolStripButton toolStripButton_1;

	private ToolStripButton toolStripButton_2;

	private TabControl tabControl_0;

	private TabPage tabPage_0;

	private TabPage tabPage_1;

	private TabPage tabPage_2;

	private DataSet dataSet_0;

	private DataTable dataTable_1;

	private DataColumn dataColumn_0;

	private DataColumn dataColumn_1;

	private DataColumn dataColumn_2;

	private DataColumn dataColumn_3;

	private DataColumn dataColumn_4;

	private ToolStripButton toolStripButton_3;

	private DataGridViewExcelFilter dataGridViewExcelFilter_0;

	private BindingSource bindingSource_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_3;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_4;

	private DataGridViewExcelFilter dataGridViewExcelFilter_1;

	private BindingSource bindingSource_1;

	private ToolStrip toolStrip_1;

	private ToolStripButton toolStripButton_4;

	private DataTable dataTable_2;

	private DataColumn dataColumn_5;

	private DataColumn dataColumn_6;

	private DataColumn dataColumn_7;

	private DataColumn dataColumn_8;

	private ToolStripButton toolStripButton_5;

	private ToolStripButton toolStripButton_6;

	private ToolStripButton toolStripButton_7;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_5;

	private DataGridViewImageColumnNotNull dataGridViewImageColumnNotNull_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_6;

	private DataGridViewLinkColumn dataGridViewLinkColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_7;

	private Button button_3;

	private ToolStrip toolStrip_2;

	private ToolStripButton toolStripButton_8;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_8;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_9;

	private DataGridViewFilterDateTimePickerColumn dataGridViewFilterDateTimePickerColumn_0;

	private DataGridViewFilterDateTimePickerColumn dataGridViewFilterDateTimePickerColumn_1;

	private TextBox textBox_5;

	private ComboBox comboBox_4;

	private Label label_15;

	private NullableDateTimePicker nullableDateTimePicker_2;

	private ComboBox comboBox_5;

	private Label label_16;

	private ComboBox comboBox_6;

	private Label label_17;
}
