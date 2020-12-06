using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml;
using ControlsLbr;
using Documents.Properties;
using FormLbr;
using FormLbr.Classes;

internal partial class FormJournalOrderAddEdit : FormBase
{
	internal int? IdDivision { get; set; }

	internal int method_0()
	{
		return this.int_0;
	}

	internal FormJournalOrderAddEdit()
	{
		
		this.int_0 = -1;
		this.dateTime_0 = new DateTime(1900, 1, 1);
		this.zyqoOhapCtg = new DateTime(9000, 1, 1);
		this.bool_1 = true;
		this.dictionary_0 = new Dictionary<int, string>();
		
		this.method_19();
	}

	internal FormJournalOrderAddEdit(int int_1, bool bool_2)
	{
		
		this.int_0 = -1;
		this.dateTime_0 = new DateTime(1900, 1, 1);
		this.zyqoOhapCtg = new DateTime(9000, 1, 1);
		this.bool_1 = true;
		this.dictionary_0 = new Dictionary<int, string>();
		
		this.method_19();
		this.int_0 = int_1;
		this.bool_0 = bool_2;
		this.dataGridViewComboBoxColumn_1.AutoComplete = true;
	}

	private void FormJournalOrderAddEdit_Load(object sender, EventArgs e)
	{
		this.method_2();
		if (this.int_0 < 0)
		{
			DateTime now = DateTime.Now;
			this.OxGovjdrwUI.Value = null;
			this.nullableDateTimePicker_0.Value = now;
			this.nullableDateTimePicker_0.Value = null;
			this.nullableDateTimePicker_2.Value = now;
			this.nullableDateTimePicker_2.Value = null;
			this.nullableDateTimePicker_0.MaxDate = this.zyqoOhapCtg;
			this.nullableDateTimePicker_3.MinDate = this.dateTime_0;
			if (this.nullableDateTimePicker_2.Value != null)
			{
				this.nullableDateTimePicker_1.MinDate = (DateTime)this.nullableDateTimePicker_2.Value;
			}
			else
			{
				this.nullableDateTimePicker_2.MinDate = this.dateTime_0;
			}
			if (this.nullableDateTimePicker_1.Value != null)
			{
				this.nullableDateTimePicker_2.MaxDate = (DateTime)this.nullableDateTimePicker_1.Value;
			}
			else
			{
				this.nullableDateTimePicker_2.MaxDate = this.zyqoOhapCtg;
			}
		}
		base.LoadFormConfig(null);
		if (base.Location.X < 0)
		{
			base.Location = new Point(0, base.Location.Y);
		}
		if (base.Location.Y < 0)
		{
			base.Location = new Point(base.Location.X, 0);
		}
		if (base.Right > base.Parent.Right)
		{
			base.Width -= base.Right - base.Parent.Right;
		}
		if (base.Bottom > base.Parent.Bottom)
		{
			base.Height -= base.Bottom - base.Parent.Bottom;
		}
		this.method_1();
		base.SelectSqlData(this.class469_0, this.class469_0.vWorkerGroup, true, " where ParentKey in (';GroupWorker;ITR;', ';GroupWorker;Workers;', ';GroupWorker;Dispatchers;')  and dateend is null order by fio ");
		Class469 @class = new Class469();
		this.dataGridViewComboBoxColumn_2.DataSource = @class;
		this.dataGridViewComboBoxColumn_2.ValueMember = "tR_Classifier.Id";
		this.dataGridViewComboBoxColumn_2.DisplayMember = "tR_Classifier.Name";
		base.SelectSqlData(@class, @class.tR_Classifier, true, " where parentkey = ';Other;JobTitle;' and isgroup = 0 and deleted = 0 order by [name]");
		this.method_4();
		if (this.int_0 == -1)
		{
			this.Text = "Новый наряд";
			if (this.IdDivision != null && this.comboBoxReadOnly_0.Visible)
			{
				this.comboBoxReadOnly_0.SelectedValue = this.IdDivision;
			}
		}
		else
		{
			this.rwbovvjUheW.Enabled = true;
			this.toolStripButton_0.Enabled = true;
			this.method_7();
			base.SelectSqlData(this.class469_0, this.class469_0.tJ_OrderBrigade, true, " where idorder = " + this.int_0.ToString());
			base.SelectSqlData(this.class469_0, this.class469_0.tJ_OrderInstruction, true, " where idorder = " + this.int_0.ToString() + " order by rec_num");
			base.SelectSqlData(this.class469_0, this.class469_0.tJ_OrderResolution, true, " where idorder = " + this.int_0.ToString() + " order by datebegin ");
			base.SelectSqlData(this.class469_0, this.class469_0.tL_OrderSchmObjList, true, " where idOrder = " + this.int_0.ToString());
			this.dictionary_0.Clear();
			foreach (DataRow dataRow in this.class469_0.tL_OrderSchmObjList)
			{
				this.dictionary_0.Add(Convert.ToInt32(dataRow["idSchmObj"]), base.CallSQLScalarFunction("dbo.fn_Schm_GetFullNameObjById", new string[]
				{
					dataRow["idSchmObj"].ToString()
				}).ToString());
			}
			if (this.dictionary_0.Count > 0)
			{
				this.toolStripButton_3.Enabled = true;
			}
			this.method_17();
			if (this.bool_0)
			{
				this.Text = "Просмотр наряда №" + this.class469_0.tJ_Order.Rows[0]["num"].ToString();
			}
			else
			{
				this.Text = "Редактирование наряда №" + this.class469_0.tJ_Order.Rows[0]["num"].ToString();
			}
			if (this.OxGovjdrwUI.Value != null)
			{
				if (this.nullableDateTimePicker_2.MaxDate > (DateTime)this.OxGovjdrwUI.Value)
				{
					this.nullableDateTimePicker_2.MaxDate = (DateTime)this.OxGovjdrwUI.Value;
				}
				this.nullableDateTimePicker_3.MaxDate = (DateTime)this.OxGovjdrwUI.Value;
			}
		}
		this.method_6();
	}

	private void FormJournalOrderAddEdit_FormClosed(object sender, FormClosedEventArgs e)
	{
		base.SaveFormConfig(null);
	}

	private void FormJournalOrderAddEdit_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (this.class469_0.tJ_Order.Rows.Count > 0 && (this.class469_0.tJ_Order.Rows[0]["Registered"] == DBNull.Value || !Convert.ToBoolean(this.class469_0.tJ_Order.Rows[0]["Registered"])))
		{
			this.class469_0.tJ_Order.Rows[0].EndEdit();
			DataTable changes = this.class469_0.tJ_Order.GetChanges();
			if (changes != null && changes.Rows.Count > 0)
			{
				if (MessageBox.Show("Сохранить внесенные изменения в наряд?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					if (this.method_10())
					{
						this.method_8();
						return;
					}
					e.Cancel = false;
					return;
				}
			}
			else
			{
				foreach (object obj in this.class469_0.tJ_OrderBrigade.Rows)
				{
					DataRow dataRow = (DataRow)obj;
					if (dataRow.RowState != DataRowState.Deleted)
					{
						if (Convert.ToInt32(dataRow["idorder"]) != this.method_0())
						{
							dataRow["idorder"] = this.int_0;
						}
						dataRow.EndEdit();
					}
				}
				changes = this.class469_0.tJ_OrderBrigade.GetChanges();
				if (changes != null && changes.Rows.Count > 0)
				{
					if (MessageBox.Show("Сохранить внесенные изменения в наряд?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						if (this.method_10())
						{
							this.method_8();
							return;
						}
						e.Cancel = false;
						return;
					}
				}
				else
				{
					int i = 0;
					foreach (object obj2 in this.class469_0.tJ_OrderInstruction.Rows)
					{
						DataRow dataRow2 = (DataRow)obj2;
						if (dataRow2.RowState != DataRowState.Deleted)
						{
							if (Convert.ToInt32(dataRow2["idorder"]) != this.method_0())
							{
								dataRow2["idorder"] = this.int_0;
							}
							if (dataRow2["rec_num"] == DBNull.Value || Convert.ToInt32(dataRow2["rec_num"]) != i++)
							{
								dataRow2["rec_num"] = i;
							}
							dataRow2.EndEdit();
						}
					}
					changes = this.class469_0.tJ_OrderInstruction.GetChanges();
					if (changes != null && changes.Rows.Count > 0)
					{
						if (MessageBox.Show("Сохранить внесенные изменения в наряд?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
						{
							if (this.method_10())
							{
								this.method_8();
								return;
							}
							e.Cancel = false;
							return;
						}
					}
					else
					{
						foreach (int num in this.dictionary_0.Keys)
						{
							if (this.class469_0.tL_OrderSchmObjList.Select(" idSChmObj = " + num.ToString()).Length == 0)
							{
								DataRow dataRow3 = this.class469_0.tL_OrderSchmObjList.NewRow();
								dataRow3["idOrder"] = this.method_0();
								dataRow3["idSchmObj"] = num;
								this.class469_0.tL_OrderSchmObjList.Rows.Add(dataRow3);
							}
						}
						for (i = 0; i < this.class469_0.tL_OrderSchmObjList.Rows.Count; i++)
						{
							if (this.class469_0.tL_OrderSchmObjList.Rows[i].RowState != DataRowState.Deleted && !this.dictionary_0.ContainsKey(Convert.ToInt32(this.class469_0.tL_OrderSchmObjList.Rows[i]["idSChmObj"])))
							{
								this.class469_0.tL_OrderSchmObjList.Rows[i].Delete();
							}
						}
						changes = this.class469_0.tL_OrderSchmObjList.GetChanges();
						if (changes != null && changes.Rows.Count > 0 && MessageBox.Show("Сохранить внесенные изменения в наряд?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
						{
							if (this.method_10())
							{
								this.method_8();
								return;
							}
							e.Cancel = false;
							return;
						}
					}
				}
			}
		}
	}

	private void method_1()
	{
		if (this.IdDivision == null && this.method_0() > 0)
		{
			DataTable dataTable = new DataTable("tJ_Order");
			dataTable.Columns.Add("idDivision", typeof(int));
			base.SelectSqlData(dataTable, true, " where id = " + this.method_0().ToString(), null, false, 0);
			if (dataTable.Rows.Count > 0 && dataTable.Rows[0]["idDivision"] != DBNull.Value)
			{
				this.IdDivision = new int?(Convert.ToInt32(dataTable.Rows[0]["idDivision"]));
			}
		}
		if (this.IdDivision != null)
		{
			base.SelectSqlData(this.class469_0.tR_Classifier, true, string.Format(" where ParentId = {0} and isGRoup = 0 and deleted = 0 ", this.IdDivision.Value), null, false, 0);
		}
		if (this.class469_0.tR_Classifier.Rows.Count == 0)
		{
			base.SelectSqlData(this.class469_0.tR_Classifier, true, " where parentkey = ';NetworkAreas;' and isgroup = 0 and deleted = 0", null, false, 0);
		}
	}

	private void method_2()
	{
		DataTable dataTable = new DataTable("tR_Classifier");
		dataTable.Columns.Add("id", typeof(int));
		dataTable.Columns.Add("name", typeof(string));
		dataTable.Columns.Add("value", typeof(decimal));
		base.SelectSqlData(dataTable, true, " where ((ParentKey = ';Other;DivisionOrder;' and isGRoup = 0)\r\n                                            or (ParentKey like ';Other;DivisionOrder;%;' and isGRoup = 1)) and deleted = 0 ", null, false, 0);
		if (dataTable.Rows.Count == 0)
		{
			this.label_15.Visible = false;
			this.comboBoxReadOnly_0.Visible = false;
			return;
		}
		this.comboBoxReadOnly_0.DisplayMember = "name";
		this.comboBoxReadOnly_0.ValueMember = "id";
		this.comboBoxReadOnly_0.DataSource = dataTable;
	}

	private DataTable method_3()
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

	private void method_4()
	{
		DataTable dataTable = this.method_3();
		base.SelectSqlData(dataTable, true, " where ParentKey in (';GroupWorker;ITR;')  and dateend is null group by id, fio, groupelectrical order by fio ", null, false, 0);
		this.comboBox_2.DataSource = dataTable;
		this.comboBox_2.DisplayMember = "FIOGROUP";
		this.comboBox_2.ValueMember = "ID";
		DataTable dataTable2 = this.method_3();
		base.SelectSqlData(dataTable2, true, " where ParentKey in (';GroupWorker;ITR;', ';GroupWorker;Workers;', ';GroupWorker;Dispatchers;')  and dateend is null group by id, fio, groupelectrical order by fio ", null, false, 0);
		this.comboBox_1.DataSource = dataTable2;
		this.comboBox_1.DisplayMember = "FIOGROUP";
		this.comboBox_1.ValueMember = "ID";
		DataTable dataTable3 = this.method_3();
		base.SelectSqlData(dataTable3, true, " where ParentKey in (';GroupWorker;ITR;', ';GroupWorker;Workers;')  and dateend is null group by id, fio, groupelectrical order by fio ", null, false, 0);
		this.comboBox_3.DataSource = dataTable3;
		this.comboBox_3.DisplayMember = "FIOGROUP";
		this.comboBox_3.ValueMember = "ID";
		DataTable dataTable4 = this.method_3();
		base.SelectSqlData(dataTable4, true, " where ParentKey in (';GroupWorker;ITR;', ';GroupWorker;Workers;')  and dateend is null group by id, fio, groupelectrical order by fio ", null, false, 0);
		this.comboBox_4.DataSource = dataTable4;
		this.comboBox_4.DisplayMember = "FIOGROUP";
		this.comboBox_4.ValueMember = "ID";
		DataTable dataTable5 = this.method_3();
		base.SelectSqlData(dataTable5, true, " where ParentKey in (';GroupWorker;ITR;', ';GroupWorker;Dispatchers;')  and dateend is null group by id, fio, groupelectrical order by fio ", null, false, 0);
		this.comboBox_5.DataSource = dataTable5;
		this.comboBox_5.DisplayMember = "FIOGROUP";
		this.comboBox_5.ValueMember = "ID";
		DataTable dataTable6 = this.method_3();
		base.SelectSqlData(dataTable6, true, " where ParentKey in (';GroupWorker;ITR;', ';GroupWorker;Dispatchers;')  and dateend is null group by id, fio, groupelectrical order by fio ", null, false, 0);
		this.KdqovVhxpIs.DataSource = dataTable6;
		this.KdqovVhxpIs.DisplayMember = "FIOGROUP";
		this.KdqovVhxpIs.ValueMember = "ID";
		DataTable dataTable7 = this.method_3();
		BindingSource bindingSource = new BindingSource();
		bindingSource.DataSource = dataTable7;
		base.SelectSqlData(dataTable7, true, " where ParentKey in (';GroupWorker;Workers;')  and dateend is null group by id, fio, groupelectrical order by fio ", null, false, 0);
		this.dataGridViewComboBoxColumn_1.DataSource = bindingSource;
		this.dataGridViewComboBoxColumn_1.DisplayMember = "FIOGROUP";
		this.dataGridViewComboBoxColumn_1.ValueMember = "ID";
		this.method_5();
	}

	private void method_5()
	{
		int? num = null;
		if (this.int_0 > 0)
		{
			DataTable dataTable = new DataTable("tJ_Order");
			dataTable.Columns.Add("idDivision", typeof(int));
			base.SelectSqlData(dataTable, true, " where id = " + this.int_0.ToString(), null, false, 0);
			if (dataTable.Rows.Count > 0 && dataTable.Rows[0]["idDivision"] != DBNull.Value)
			{
				num = new int?(Convert.ToInt32(dataTable.Rows[0]["idDivision"]));
			}
		}
		if (num == null)
		{
			num = this.IdDivision;
		}
		decimal? num2 = null;
		if (num != null)
		{
			DataTable dataTable2 = new DataTable("tR_Classifier");
			dataTable2.Columns.Add("Value", typeof(decimal));
			base.SelectSqlData(dataTable2, true, "where id = " + num.ToString(), null, false, 0);
			if (dataTable2.Rows.Count > 0 && dataTable2.Rows[0]["Value"] != DBNull.Value)
			{
				num2 = new decimal?(Convert.ToDecimal(dataTable2.Rows[0]["Value"]));
			}
		}
		DataTable dataTable3 = this.method_3();
		if (num2 == 2)
		{
			base.SelectSqlData(dataTable3, true, " where ParentKey in (';GroupWorker;DispatchersSESNO;')  and dateend is null group by id, fio, groupelectrical order by fio ", null, false, 0);
		}
		else
		{
			base.SelectSqlData(dataTable3, true, " where ParentKey in (';GroupWorker;Dispatchers;')  and dateend is null group by id, fio, groupelectrical order by fio ", null, false, 0);
		}
		this.dataGridViewComboBoxColumn_0.DataSource = dataTable3;
		this.dataGridViewComboBoxColumn_0.DisplayMember = "FIOGROUP";
		this.dataGridViewComboBoxColumn_0.ValueMember = "ID";
		this.comboBox_6.DataSource = dataTable3;
		this.comboBox_6.DisplayMember = "FIOGROUP";
		this.comboBox_6.ValueMember = "ID";
		DataTable dataTable4 = this.method_3();
		if (num2 == 2)
		{
			base.SelectSqlData(dataTable4, true, " where ParentKey in (';GroupWorker;DispatchersSESNO;')  and dateend is null group by id, fio, groupelectrical order by fio ", null, false, 0);
		}
		else
		{
			base.SelectSqlData(dataTable4, true, " where ParentKey in (';GroupWorker;Dispatchers;')  and dateend is null group by id, fio, groupelectrical order by fio ", null, false, 0);
		}
		this.comboBox_7.DataSource = dataTable4;
		this.comboBox_7.DisplayMember = "FIOGROUP";
		this.comboBox_7.ValueMember = "ID";
	}

	private void method_6()
	{
		this.comboBox_6.SelectedIndex = -1;
		if (this.int_0 == -1)
		{
			this.nullableDateTimePicker_0.Value = null;
			this.nullableDateTimePicker_1.Value = null;
			this.textBox_0.BackColor = Color.Yellow;
			this.comboBox_0.SelectedIndex = -1;
			this.comboBox_2.SelectedIndex = -1;
			this.comboBox_1.SelectedIndex = -1;
			this.comboBox_3.SelectedIndex = -1;
			this.comboBox_4.SelectedIndex = -1;
			this.comboBox_5.SelectedIndex = -1;
			this.nullableDateTimePicker_2.Value = null;
			this.KdqovVhxpIs.SelectedIndex = -1;
			this.OxGovjdrwUI.Value = null;
			this.button_1.Enabled = false;
		}
		else if (this.class469_0.tJ_Order.Rows.Count > 0)
		{
			if (Convert.ToBoolean(this.class469_0.tJ_Order.Rows[0]["Registered"]))
			{
				this.textBox_0.BackColor = Color.White;
				this.panel_0.Enabled = true;
				this.nullableDateTimePicker_0.Enabled = false;
				this.nullableDateTimePicker_1.Enabled = false;
				this.comboBox_0.Enabled = false;
				this.comboBox_2.Enabled = false;
				this.comboBox_1.Enabled = false;
				this.comboBox_3.Enabled = false;
				this.comboBox_4.Enabled = false;
				this.comboBox_5.Enabled = false;
				this.richTextBox_0.ReadOnly = true;
				this.richTextBox_1.ReadOnly = true;
				this.nullableDateTimePicker_2.Enabled = false;
				this.VaCovZpCew7.ReadOnly = true;
				this.VaCovZpCew7.AllowUserToAddRows = false;
				this.dataGridView_0.ReadOnly = true;
				this.dataGridView_0.AllowUserToAddRows = false;
				this.button_1.Enabled = false;
				this.button_0.Enabled = false;
				this.toolStripButton_2.Enabled = false;
				this.toolStripButton_1.Enabled = false;
				this.comboBox_6.Enabled = true;
				int count = this.class469_0.tJ_OrderResolution.Rows.Count;
				if (count > 0)
				{
					this.textBox_0.BackColor = Color.LawnGreen;
					if (this.class469_0.tJ_OrderResolution.Rows[count - 1]["DateEnd"] == DBNull.Value)
					{
						this.nullableDateTimePicker_3.MinDate = (DateTime)this.class469_0.tJ_OrderResolution.Rows[count - 1]["DateBegin"];
						if (this.nullableDateTimePicker_3.MinDate <= DateTime.Now)
						{
							if (this.nullableDateTimePicker_3.MaxDate >= DateTime.Now)
							{
								this.nullableDateTimePicker_3.Value = DateTime.Now;
							}
							else
							{
								this.nullableDateTimePicker_3.Value = this.nullableDateTimePicker_3.MaxDate;
							}
						}
						else
						{
							this.nullableDateTimePicker_3.Value = this.nullableDateTimePicker_3.MinDate;
						}
						this.button_2.Text = "Закончить работу";
						this.comboBox_6.Enabled = false;
						this.bool_1 = false;
					}
					else
					{
						this.nullableDateTimePicker_3.MinDate = (DateTime)this.class469_0.tJ_OrderResolution.Rows[count - 1]["DateEnd"];
						this.nullableDateTimePicker_3.Value = null;
						this.button_2.Text = "Выдать разрешение";
						this.comboBox_6.Enabled = true;
						this.bool_1 = true;
					}
				}
				else
				{
					this.nullableDateTimePicker_3.Value = null;
				}
				this.nullableDateTimePicker_3.Enabled = true;
				this.button_2.Enabled = true;
				this.comboBox_7.Enabled = true;
				this.nullableDateTimePicker_4.Enabled = true;
				this.button_3.Enabled = true;
				if (Convert.ToDateTime(this.nullableDateTimePicker_1.Value) < DateTime.Now)
				{
					if (this.OxGovjdrwUI.Value != null)
					{
						if (this.OxGovjdrwUI.Value != DBNull.Value)
						{
							if (Convert.ToDateTime(this.OxGovjdrwUI.Value) < DateTime.Now)
							{
								this.button_2.Enabled = false;
								goto IL_567;
							}
							goto IL_567;
						}
					}
					this.button_2.Enabled = false;
				}
			}
			else
			{
				this.textBox_0.BackColor = Color.Yellow;
				this.panel_0.Enabled = false;
				this.nullableDateTimePicker_0.Enabled = true;
				this.nullableDateTimePicker_1.Enabled = true;
				this.comboBox_0.Enabled = true;
				this.comboBox_2.Enabled = true;
				this.comboBox_1.Enabled = true;
				this.comboBox_3.Enabled = true;
				this.comboBox_4.Enabled = true;
				this.comboBox_5.Enabled = true;
				this.richTextBox_0.ReadOnly = false;
				this.richTextBox_1.ReadOnly = false;
				this.nullableDateTimePicker_2.Enabled = true;
				this.VaCovZpCew7.ReadOnly = false;
				this.VaCovZpCew7.AllowUserToAddRows = true;
				this.dataGridView_0.ReadOnly = false;
				this.dataGridView_0.AllowUserToAddRows = true;
				this.button_1.Enabled = true;
				this.button_0.Enabled = true;
				this.toolStripButton_2.Enabled = true;
				this.toolStripButton_1.Enabled = true;
			}
			IL_567:
			if (this.class469_0.tJ_Order.Rows[0]["dateClose"] != DBNull.Value)
			{
				this.textBox_0.BackColor = Color.Gray;
				this.panel_0.Enabled = false;
				this.comboBox_6.Enabled = false;
				this.nullableDateTimePicker_3.Enabled = false;
				this.button_2.Enabled = false;
				this.comboBox_7.Enabled = false;
				this.nullableDateTimePicker_4.Enabled = false;
				this.button_3.Enabled = false;
			}
			if (this.class469_0.tJ_Order.Rows[0]["dateEndExt"] != DBNull.Value)
			{
				this.button_4.Visible = false;
				this.panel_0.Enabled = false;
			}
		}
		if (this.bool_0)
		{
			this.nullableDateTimePicker_0.Enabled = false;
			this.nullableDateTimePicker_1.Enabled = false;
			this.comboBox_0.Enabled = false;
			this.comboBox_2.Enabled = false;
			this.comboBox_1.Enabled = false;
			this.comboBox_3.Enabled = false;
			this.comboBox_4.Enabled = false;
			this.comboBox_5.Enabled = false;
			this.richTextBox_0.ReadOnly = true;
			this.richTextBox_1.ReadOnly = true;
			this.nullableDateTimePicker_2.Enabled = false;
			this.VaCovZpCew7.ReadOnly = true;
			this.VaCovZpCew7.AllowUserToAddRows = false;
			this.dataGridView_0.ReadOnly = true;
			this.dataGridView_0.AllowUserToAddRows = false;
			this.button_1.Enabled = false;
			this.button_0.Enabled = false;
			this.comboBox_6.Enabled = false;
			this.comboBox_6.Enabled = false;
			this.nullableDateTimePicker_3.Enabled = false;
			this.button_2.Enabled = false;
			this.comboBox_7.Enabled = false;
			this.nullableDateTimePicker_4.Enabled = false;
			this.button_3.Enabled = false;
		}
		if (base.PermissionsControlsEnabled || base.PermissionsControlsVisible)
		{
			base.SetControlsPropertiesUser();
		}
	}

	private void nullableDateTimePicker_0_ValueChanged(object sender, EventArgs e)
	{
		if (this.nullableDateTimePicker_0.Value != null)
		{
			this.label_1.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
			this.nullableDateTimePicker_1.MaxDate = Convert.ToDateTime(this.nullableDateTimePicker_0.Value).AddDays(15.0);
			this.nullableDateTimePicker_1.MinDate = (DateTime)this.nullableDateTimePicker_0.Value;
			this.nullableDateTimePicker_2.MaxDate = (DateTime)this.nullableDateTimePicker_0.Value;
			this.nullableDateTimePicker_3.MinDate = (DateTime)this.nullableDateTimePicker_0.Value;
			return;
		}
		this.nullableDateTimePicker_1.MaxDate = this.zyqoOhapCtg;
		this.nullableDateTimePicker_3.MinDate = this.dateTime_0;
		if (this.nullableDateTimePicker_2.Value != null)
		{
			this.nullableDateTimePicker_1.MinDate = (DateTime)this.nullableDateTimePicker_2.Value;
		}
		else
		{
			this.nullableDateTimePicker_2.MinDate = this.dateTime_0;
		}
		if (this.nullableDateTimePicker_1.Value != null)
		{
			this.nullableDateTimePicker_2.MaxDate = (DateTime)this.nullableDateTimePicker_1.Value;
			return;
		}
		this.nullableDateTimePicker_2.MaxDate = this.zyqoOhapCtg;
	}

	private void nullableDateTimePicker_1_ValueChanged(object sender, EventArgs e)
	{
		if (this.nullableDateTimePicker_1.Value != null)
		{
			this.label_2.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
			this.nullableDateTimePicker_0.MaxDate = (DateTime)this.nullableDateTimePicker_1.Value;
			if (this.nullableDateTimePicker_2.Value != null && Convert.ToDateTime(this.nullableDateTimePicker_2.Value) > Convert.ToDateTime(this.nullableDateTimePicker_1.Value).AddDays(-15.0))
			{
				this.nullableDateTimePicker_0.MinDate = (DateTime)this.nullableDateTimePicker_2.Value;
			}
			else
			{
				this.nullableDateTimePicker_0.MinDate = Convert.ToDateTime(this.nullableDateTimePicker_1.Value).AddDays(-15.0);
			}
			if (this.nullableDateTimePicker_2.MaxDate > (DateTime)this.nullableDateTimePicker_1.Value)
			{
				this.nullableDateTimePicker_2.MaxDate = (DateTime)this.nullableDateTimePicker_1.Value;
			}
			if (this.OxGovjdrwUI.Value != null)
			{
				this.nullableDateTimePicker_3.MaxDate = (DateTime)this.OxGovjdrwUI.Value;
			}
			else
			{
				this.nullableDateTimePicker_3.MaxDate = (DateTime)this.nullableDateTimePicker_1.Value;
			}
			this.OxGovjdrwUI.MinDate = (DateTime)this.nullableDateTimePicker_1.Value;
			return;
		}
		this.OxGovjdrwUI.MinDate = this.dateTime_0;
		this.nullableDateTimePicker_0.MaxDate = this.zyqoOhapCtg;
		this.nullableDateTimePicker_3.MaxDate = this.zyqoOhapCtg;
		if (this.nullableDateTimePicker_2.Value != null)
		{
			this.nullableDateTimePicker_0.MinDate = (DateTime)this.nullableDateTimePicker_2.Value;
		}
		else
		{
			this.nullableDateTimePicker_0.MinDate = this.dateTime_0;
		}
		if (this.nullableDateTimePicker_0.Value != null)
		{
			this.nullableDateTimePicker_2.MaxDate = (DateTime)this.nullableDateTimePicker_0.Value;
			return;
		}
		this.nullableDateTimePicker_2.MaxDate = this.zyqoOhapCtg;
	}

	private void nullableDateTimePicker_2_ValueChanged(object sender, EventArgs e)
	{
		if (this.nullableDateTimePicker_2.Value != null)
		{
			this.label_13.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
			if (this.comboBox_5.SelectedValue != null)
			{
				this.label_10.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
			}
			if (this.nullableDateTimePicker_1.Value != null && Convert.ToDateTime(this.nullableDateTimePicker_2.Value) < Convert.ToDateTime(this.nullableDateTimePicker_1.Value).AddDays(-15.0))
			{
				this.nullableDateTimePicker_0.MinDate = Convert.ToDateTime(this.nullableDateTimePicker_1.Value).AddDays(-15.0);
			}
			else
			{
				this.nullableDateTimePicker_0.MinDate = (DateTime)this.nullableDateTimePicker_2.Value;
			}
			if (this.nullableDateTimePicker_1.MinDate < (DateTime)this.nullableDateTimePicker_2.Value)
			{
				this.nullableDateTimePicker_1.MinDate = (DateTime)this.nullableDateTimePicker_2.Value;
			}
			this.nullableDateTimePicker_4.MinDate = (DateTime)this.nullableDateTimePicker_2.Value;
			return;
		}
		this.nullableDateTimePicker_0.MinDate = this.dateTime_0;
		if (this.nullableDateTimePicker_0.Value != null)
		{
			this.nullableDateTimePicker_1.MinDate = (DateTime)this.nullableDateTimePicker_0.Value;
			return;
		}
		this.nullableDateTimePicker_1.MinDate = this.dateTime_0;
	}

	private void richTextBox_0_TextChanged(object sender, EventArgs e)
	{
		if (!string.IsNullOrEmpty(this.richTextBox_0.Text))
		{
			this.label_3.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
		}
	}

	private void comboBox_0_SelectedValueChanged(object sender, EventArgs e)
	{
		if (this.comboBox_0.SelectedValue != null)
		{
			this.label_4.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
		}
	}

	private void comboBox_1_SelectedValueChanged(object sender, EventArgs e)
	{
		if (this.comboBox_1.SelectedValue != null)
		{
			this.dfRoOrlkqAm.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
		}
	}

	private void comboBox_4_SelectedValueChanged(object sender, EventArgs e)
	{
		if (this.comboBox_4.SelectedValue != null)
		{
			this.label_7.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
		}
	}

	private void comboBox_5_SelectedValueChanged(object sender, EventArgs e)
	{
		if (this.comboBox_5.SelectedValue != null && this.nullableDateTimePicker_2.Value != null)
		{
			this.label_10.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
		}
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		if (this.method_10())
		{
			this.method_8();
		}
	}

	private void method_7()
	{
		if (this.method_0() > 0)
		{
			base.SelectSqlData(this.class469_0, this.class469_0.tJ_Order, true, " where id = " + this.int_0);
			if (this.class469_0.tJ_Order.Rows.Count > 0)
			{
				this.nullableDateTimePicker_4.Value = this.class469_0.tJ_Order.Rows[0]["DateClose"];
				this.comboBox_7.SelectedValue = this.class469_0.tJ_Order.Rows[0]["closeWorker"];
				if (this.comboBoxReadOnly_0.Visible && this.class469_0.tJ_Order.Rows[0]["idDivision"] == DBNull.Value)
				{
					DataRow[] array = ((DataTable)this.comboBoxReadOnly_0.DataSource).Select("VAlue = 1");
					if (array.Length != 0)
					{
						this.comboBoxReadOnly_0.SelectedValue = array[0]["id"];
					}
				}
			}
		}
	}

	private bool method_8()
	{
		if (this.int_0 != -1)
		{
			this.class469_0.tJ_Order.Rows[0].EndEdit();
			if (base.UpdateSqlData(this.class469_0, this.class469_0.tJ_Order))
			{
				this.method_7();
				this.method_9();
				if (this.method_13() && this.method_14())
				{
					return true;
				}
			}
			return false;
		}
		DataRow dataRow = this.class469_0.tJ_Order.NewRow();
		dataRow["num"] = 0;
		dataRow["DateBegin"] = this.nullableDateTimePicker_0.Value;
		dataRow["DateEnd"] = this.nullableDateTimePicker_1.Value;
		dataRow["idSR"] = this.comboBox_0.SelectedValue;
		dataRow["Instruction"] = this.richTextBox_0.Text;
		dataRow["headWorker"] = ((this.comboBox_2.SelectedValue == null) ? DBNull.Value : this.comboBox_2.SelectedValue);
		dataRow["acceptWorker"] = this.comboBox_1.SelectedValue;
		dataRow["watchWorker"] = ((this.comboBox_3.SelectedValue == null) ? DBNull.Value : this.comboBox_3.SelectedValue);
		dataRow["makerWorker"] = this.comboBox_4.SelectedValue;
		if (!string.IsNullOrEmpty(this.richTextBox_1.Text))
		{
			dataRow["otherInstruction"] = this.richTextBox_1.Text;
		}
		dataRow["dateOutput"] = this.nullableDateTimePicker_2.Value;
		dataRow["outputWorker"] = this.comboBox_5.SelectedValue;
		dataRow["Registered"] = false;
		dataRow["idDivision"] = ((this.comboBoxReadOnly_0.SelectedValue == null) ? DBNull.Value : this.comboBoxReadOnly_0.SelectedValue);
		this.class469_0.tJ_Order.Rows.Add(dataRow);
		this.class469_0.tJ_Order.Rows[0].EndEdit();
		this.int_0 = base.InsertSqlDataOneRow(this.class469_0, this.class469_0.tJ_Order);
		if (this.int_0 != -1)
		{
			this.rwbovvjUheW.Enabled = true;
			this.toolStripButton_0.Enabled = true;
			this.method_7();
			this.button_1.Enabled = true;
			this.method_9();
			return this.method_13() && this.method_14();
		}
		return false;
	}

	private void method_9()
	{
		foreach (int num in this.dictionary_0.Keys)
		{
			if (this.class469_0.tL_OrderSchmObjList.Select(" idSChmObj = " + num.ToString()).Length == 0)
			{
				DataRow dataRow = this.class469_0.tL_OrderSchmObjList.NewRow();
				dataRow["idOrder"] = this.method_0();
				dataRow["idSchmObj"] = num;
				this.class469_0.tL_OrderSchmObjList.Rows.Add(dataRow);
			}
		}
		for (int i = 0; i < this.class469_0.tL_OrderSchmObjList.Rows.Count; i++)
		{
			if (this.class469_0.tL_OrderSchmObjList.Rows[i].RowState != DataRowState.Deleted && !this.dictionary_0.ContainsKey(Convert.ToInt32(this.class469_0.tL_OrderSchmObjList.Rows[i]["idSChmObj"])))
			{
				this.class469_0.tL_OrderSchmObjList.Rows[i].Delete();
			}
		}
		base.InsertSqlData(this.class469_0, this.class469_0.tL_OrderSchmObjList);
		base.DeleteSqlData(this.class469_0, this.class469_0.tL_OrderSchmObjList);
		this.class469_0.tL_OrderSchmObjList.AcceptChanges();
	}

	private bool method_10()
	{
		bool flag = true;
		if (this.nullableDateTimePicker_0.Value == null)
		{
			this.label_1.ForeColor = Color.Red;
			flag = false;
		}
		if (this.nullableDateTimePicker_1.Value == null)
		{
			this.label_2.ForeColor = Color.Red;
			flag = false;
		}
		if (string.IsNullOrEmpty(this.richTextBox_0.Text))
		{
			this.label_3.ForeColor = Color.Red;
			flag = false;
		}
		if (this.comboBox_0.SelectedValue == null)
		{
			this.label_4.ForeColor = Color.Red;
			flag = false;
		}
		if (this.comboBox_1.SelectedValue == null)
		{
			this.dfRoOrlkqAm.ForeColor = Color.Red;
			flag = false;
		}
		if (this.comboBox_4.SelectedValue == null)
		{
			this.label_7.ForeColor = Color.Red;
			flag = false;
		}
		if (this.comboBox_5.SelectedValue == null)
		{
			this.label_10.ForeColor = Color.Red;
			flag = false;
		}
		if (this.nullableDateTimePicker_2.Value == null)
		{
			this.label_13.ForeColor = Color.Red;
			flag = false;
		}
		if (!flag)
		{
			MessageBox.Show("Не введены обязательные значения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		return flag;
	}

	private bool method_11()
	{
		if (!this.method_10())
		{
			return false;
		}
		if (this.listBox_0.Items.Count <= 0)
		{
			MessageBox.Show("Наряд не привязан к объектам схемы!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return false;
		}
		if (this.class469_0.tJ_OrderBrigade.Rows.Count <= 0)
		{
			MessageBox.Show("Нет ни одного члена бригады!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return false;
		}
		return true;
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		if (this.class469_0.tJ_Order.Rows.Count > 0 && this.method_11())
		{
			if (this.method_8())
			{
				this.class469_0.tJ_Order.Rows[0]["Registered"] = true;
				this.class469_0.tJ_Order.Rows[0].EndEdit();
				if (base.UpdateSqlData(this.class469_0, this.class469_0.tJ_Order))
				{
					this.method_7();
					this.method_6();
					return;
				}
				this.class469_0.tJ_Order.Rows[0]["Registered"] = false;
				return;
			}
			else
			{
				this.class469_0.tJ_Order.Rows[0]["Registered"] = false;
			}
		}
	}

	private void button_4_Click(object sender, EventArgs e)
	{
		if (this.class469_0.tJ_Order.Rows.Count > 0)
		{
			if (this.KdqovVhxpIs.SelectedIndex < 0)
			{
				MessageBox.Show("Не выбран сотрудник, продливающий наряд");
				return;
			}
			if (this.OxGovjdrwUI.Value == null)
			{
				MessageBox.Show("Не выбрана дата продления");
				return;
			}
			if (this.method_8())
			{
				this.method_6();
				if (this.OxGovjdrwUI.Value != null)
				{
					if (this.nullableDateTimePicker_2.MaxDate > (DateTime)this.OxGovjdrwUI.Value)
					{
						this.nullableDateTimePicker_2.MaxDate = (DateTime)this.OxGovjdrwUI.Value;
					}
					this.nullableDateTimePicker_3.MaxDate = (DateTime)this.OxGovjdrwUI.Value;
				}
			}
		}
	}

	private void VaCovZpCew7_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
	{
		for (int i = 0; i < e.RowCount; i++)
		{
			DataGridViewComboBoxCell dataGridViewComboBoxCell = (DataGridViewComboBoxCell)this.VaCovZpCew7[this.dataGridViewComboBoxColumn_1.Name, e.RowIndex + i];
			if (!string.IsNullOrEmpty(this.SqlSettings.ServerDB))
			{
				DataTable dataTable = this.method_3();
				BindingSource bindingSource = new BindingSource();
				bindingSource.DataSource = dataTable;
				base.SelectSqlData(dataTable, true, " where ParentKey in (';GroupWorker;Workers;')  and dateend is null group by id, fio, groupelectrical order by fio ", null, false, 0);
				dataGridViewComboBoxCell.DataSource = bindingSource;
				dataGridViewComboBoxCell.DisplayMember = "FIOGROUP";
				dataGridViewComboBoxCell.ValueMember = "ID";
			}
			if (this.VaCovZpCew7[this.dataGridViewComboBoxColumn_1.Name, e.RowIndex + i].Value != null)
			{
				DataRow dataRow = ((dataGridViewComboBoxCell.DataSource as BindingSource).DataSource as DataTable).Rows.Find(dataGridViewComboBoxCell.Value);
				if (dataRow != null && dataRow["GroupElectrical"] != DBNull.Value)
				{
					switch (Convert.ToInt32(dataRow["GroupElectrical"]))
					{
					case 1:
						this.VaCovZpCew7[this.dataGridViewTextBoxColumn_11.Name, e.RowIndex + i].Value = "I";
						break;
					case 2:
						this.VaCovZpCew7[this.dataGridViewTextBoxColumn_11.Name, e.RowIndex + i].Value = "II";
						break;
					case 3:
						this.VaCovZpCew7[this.dataGridViewTextBoxColumn_11.Name, e.RowIndex + i].Value = "III";
						break;
					case 4:
						this.VaCovZpCew7[this.dataGridViewTextBoxColumn_11.Name, e.RowIndex + i].Value = "IV";
						break;
					case 5:
						this.VaCovZpCew7[this.dataGridViewTextBoxColumn_11.Name, e.RowIndex + i].Value = "V";
						break;
					default:
						this.VaCovZpCew7[this.dataGridViewTextBoxColumn_11.Name, e.RowIndex + i].Value = "";
						break;
					}
				}
			}
		}
	}

	private void VaCovZpCew7_CellValueChanged(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex >= 0 && (this.VaCovZpCew7[this.dataGridViewTextBoxColumn_10.Name, e.RowIndex].Value == DBNull.Value || Convert.ToInt32(this.VaCovZpCew7[this.dataGridViewTextBoxColumn_10.Name, e.RowIndex].Value) != this.int_0))
		{
			this.VaCovZpCew7[this.dataGridViewTextBoxColumn_10.Name, e.RowIndex].Value = this.int_0;
		}
	}

	private void VaCovZpCew7_CellEndEdit(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex >= 0 && this.VaCovZpCew7.Columns[e.ColumnIndex].Name == this.dataGridViewComboBoxColumn_1.Name && this.VaCovZpCew7[e.ColumnIndex, e.RowIndex].Value != DBNull.Value)
		{
			foreach (object obj in ((IEnumerable)this.VaCovZpCew7.Rows))
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
				if (e.RowIndex != dataGridViewRow.Index && dataGridViewRow.Cells["brigadeWorkerColumn"].Value != null && this.VaCovZpCew7[e.ColumnIndex, e.RowIndex].Value != null && Convert.ToInt32(dataGridViewRow.Cells["brigadeWorkerColumn"].Value) == Convert.ToInt32(this.VaCovZpCew7[e.ColumnIndex, e.RowIndex].Value))
				{
					DataRow[] array = this.class469_0.vWorkerGroup.Select("id = " + this.VaCovZpCew7[e.ColumnIndex, e.RowIndex].Value);
					string str = "";
					if (array.Length != 0)
					{
						str = array[0]["FIO"].ToString();
					}
					MessageBox.Show("Работник " + str + " уже введен в данный наряд", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					this.VaCovZpCew7.BeginEdit(true);
					break;
				}
			}
		}
	}

	private void dataGridView_1_DataError(object sender, DataGridViewDataErrorEventArgs e)
	{
		try
		{
			e.ThrowException = false;
			e.Cancel = true;
			if (e.ColumnIndex >= 0 && e.ColumnIndex < ((DataGridView)sender).Columns.Count && e.RowIndex >= 0 && e.RowIndex < ((DataGridView)sender).Rows.Count)
			{
				((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = e.Exception.Message;
			}
		}
		catch (Exception)
		{
		}
	}

	private void VaCovZpCew7_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
	{
		if (this.VaCovZpCew7.CurrentCell != null && this.VaCovZpCew7.Columns[this.VaCovZpCew7.CurrentCell.ColumnIndex] == this.dataGridViewComboBoxColumn_2)
		{
			return;
		}
		if (e.Control is ComboBox)
		{
			(e.Control as ComboBox).AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			(e.Control as ComboBox).AutoCompleteSource = AutoCompleteSource.ListItems;
			BindingSource bindingSource = (BindingSource)(e.Control as ComboBox).DataSource;
			if (bindingSource != null)
			{
				bindingSource.Filter = "";
				string text = "";
				foreach (object obj in ((IEnumerable)this.VaCovZpCew7.Rows))
				{
					DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
					if ((this.VaCovZpCew7.CurrentCell == null || this.VaCovZpCew7.CurrentCell.RowIndex != dataGridViewRow.Index) && dataGridViewRow.Cells[this.dataGridViewComboBoxColumn_1.Name].Value != null)
					{
						text = text + dataGridViewRow.Cells[this.dataGridViewComboBoxColumn_1.Name].Value.ToString() + ",";
					}
				}
				if (text.Length > 0)
				{
					bindingSource.Filter = "id not in (" + text.Remove(text.Length - 1) + ")";
				}
				if (this.VaCovZpCew7.CurrentCell != null && this.VaCovZpCew7.CurrentCell.Value != null)
				{
					(e.Control as ComboBox).SelectedValue = this.VaCovZpCew7.CurrentCell.Value;
				}
			}
			(e.Control as ComboBox).SelectedValueChanged -= this.method_12;
			(e.Control as ComboBox).SelectedValueChanged += this.method_12;
		}
	}

	private void VaCovZpCew7_KeyDown(object sender, KeyEventArgs e)
	{
		if (this.VaCovZpCew7.CurrentCell != null && this.VaCovZpCew7.Columns[this.VaCovZpCew7.CurrentCell.ColumnIndex] == this.dataGridViewComboBoxColumn_2 && Control.ModifierKeys == Keys.None && e.KeyCode == Keys.Delete)
		{
			this.VaCovZpCew7.CurrentCell.Value = DBNull.Value;
		}
	}

	private void method_12(object sender, EventArgs e)
	{
		if (this.VaCovZpCew7.CurrentCell != null && ((ComboBox)sender).SelectedValue != null && ((ComboBox)sender).SelectedValue.GetType() != typeof(DataRowView))
		{
			BindingSource bindingSource = ((ComboBox)sender).DataSource as BindingSource;
			if (bindingSource != null)
			{
				DataTable dataTable = bindingSource.DataSource as DataTable;
				if (dataTable != null)
				{
					DataRow dataRow = dataTable.Rows.Find(((ComboBox)sender).SelectedValue);
					if (dataRow["GroupElectrical"] != DBNull.Value)
					{
						switch (Convert.ToInt32(dataRow["GroupElectrical"]))
						{
						case 1:
							this.VaCovZpCew7[this.dataGridViewTextBoxColumn_11.Name, this.VaCovZpCew7.CurrentCell.RowIndex].Value = "I";
							return;
						case 2:
							this.VaCovZpCew7[this.dataGridViewTextBoxColumn_11.Name, this.VaCovZpCew7.CurrentCell.RowIndex].Value = "II";
							return;
						case 3:
							this.VaCovZpCew7[this.dataGridViewTextBoxColumn_11.Name, this.VaCovZpCew7.CurrentCell.RowIndex].Value = "III";
							return;
						case 4:
							this.VaCovZpCew7[this.dataGridViewTextBoxColumn_11.Name, this.VaCovZpCew7.CurrentCell.RowIndex].Value = "IV";
							return;
						case 5:
							this.VaCovZpCew7[this.dataGridViewTextBoxColumn_11.Name, this.VaCovZpCew7.CurrentCell.RowIndex].Value = "V";
							return;
						default:
							this.VaCovZpCew7[this.dataGridViewTextBoxColumn_11.Name, this.VaCovZpCew7.CurrentCell.RowIndex].Value = "";
							return;
						}
					}
					else
					{
						this.VaCovZpCew7[this.dataGridViewTextBoxColumn_11.Name, this.VaCovZpCew7.CurrentCell.RowIndex].Value = "";
					}
				}
			}
		}
	}

	private bool method_13()
	{
		foreach (object obj in this.class469_0.tJ_OrderBrigade.Rows)
		{
			DataRow dataRow = (DataRow)obj;
			if (dataRow.RowState != DataRowState.Deleted)
			{
				dataRow["idorder"] = this.int_0;
				dataRow.EndEdit();
			}
		}
		if (base.InsertSqlData(this.class469_0, this.class469_0.tJ_OrderBrigade) && base.UpdateSqlData(this.class469_0, this.class469_0.tJ_OrderBrigade) && base.DeleteSqlData(this.class469_0, this.class469_0.tJ_OrderBrigade))
		{
			base.SelectSqlData(this.class469_0, this.class469_0.tJ_OrderBrigade, true, " where idorder = " + this.int_0.ToString());
			return true;
		}
		return false;
	}

	private void dataGridView_0_CellValueChanged(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex >= 0)
		{
			this.dataGridView_0["idOrderDgvColumnInstruction", e.RowIndex].Value = this.int_0;
		}
	}

	private void dataGridView_0_DataError(object sender, DataGridViewDataErrorEventArgs e)
	{
		MessageBox.Show(e.Exception.Message);
		e.Cancel = true;
	}

	private void dataGridView_0_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
	{
		if (e.ColumnIndex == -1 && e.RowIndex > -1)
		{
			DataRow dataRow = this.class469_0.tJ_OrderInstruction.NewRow();
			dataRow["idorder"] = this.int_0;
			dataRow["NameObj"] = "-";
			dataRow["Instruction"] = "-";
			this.class469_0.tJ_OrderInstruction.Rows.InsertAt(dataRow, e.RowIndex);
		}
	}

	private bool method_14()
	{
		int num = 0;
		foreach (object obj in this.class469_0.tJ_OrderInstruction.Rows)
		{
			DataRow dataRow = (DataRow)obj;
			if (dataRow.RowState != DataRowState.Deleted)
			{
				dataRow["idorder"] = this.int_0;
				dataRow["rec_num"] = num++;
				dataRow.EndEdit();
			}
		}
		if (base.InsertSqlData(this.class469_0, this.class469_0.tJ_OrderInstruction) && base.UpdateSqlData(this.class469_0, this.class469_0.tJ_OrderInstruction) && base.DeleteSqlData(this.class469_0, this.class469_0.tJ_OrderInstruction))
		{
			base.SelectSqlData(this.class469_0, this.class469_0.tJ_OrderInstruction, true, " where idorder = " + this.int_0.ToString() + " order by rec_num");
			return true;
		}
		return false;
	}

	private void comboBox_6_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.comboBox_6.SelectedValue != null && this.nullableDateTimePicker_3.Value == null)
		{
			if (this.nullableDateTimePicker_3.MaxDate >= DateTime.Now)
			{
				if (this.nullableDateTimePicker_3.MinDate <= DateTime.Now)
				{
					this.nullableDateTimePicker_3.Value = DateTime.Now;
					return;
				}
				this.nullableDateTimePicker_3.Value = this.nullableDateTimePicker_3.MinDate;
				return;
			}
			else
			{
				this.nullableDateTimePicker_3.Value = this.nullableDateTimePicker_3.MinDate;
			}
		}
	}

	private void button_2_Click(object sender, EventArgs e)
	{
		if (this.bool_1)
		{
			if (this.int_0 > 0)
			{
				if (this.nullableDateTimePicker_3.Value == null)
				{
					MessageBox.Show("Не введена дата выдачи разрешения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}
				if (this.comboBox_6.SelectedValue == null)
				{
					MessageBox.Show("Не выбран диспетчер, выдающий разрешение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}
				if (DateTime.Now < Convert.ToDateTime(this.nullableDateTimePicker_0.Value) && MessageBox.Show("Текущее время, меньше чем дата начала работ.\n Вы уверены, что хотите выдать разрешение?", "Нельзя выдать разрешение", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2) == DialogResult.No)
				{
					return;
				}
				DataRow dataRow = this.class469_0.tJ_OrderResolution.NewRow();
				dataRow["idOrder"] = this.int_0;
				dataRow["idWorker"] = this.comboBox_6.SelectedValue;
				dataRow["datebegin"] = Convert.ToDateTime(this.nullableDateTimePicker_3.Value).AddSeconds((double)(-(double)Convert.ToDateTime(this.nullableDateTimePicker_3.Value).Second));
				this.class469_0.tJ_OrderResolution.Rows.Add(dataRow);
				base.InsertSqlData(this.class469_0, this.class469_0.tJ_OrderResolution);
			}
		}
		else if (this.int_0 > 0)
		{
			int count = this.class469_0.tJ_OrderResolution.Rows.Count;
			if (count > 0)
			{
				if (this.nullableDateTimePicker_3.Value == null)
				{
					MessageBox.Show("Не введена дата окончания работы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}
				this.class469_0.tJ_OrderResolution.Rows[count - 1]["dateEnd"] = Convert.ToDateTime(this.nullableDateTimePicker_3.Value).AddSeconds((double)(-(double)Convert.ToDateTime(this.nullableDateTimePicker_3.Value).Second));
				this.class469_0.tJ_OrderResolution.Rows[count - 1].EndEdit();
				base.UpdateSqlData(this.class469_0, this.class469_0.tJ_OrderResolution);
			}
		}
		this.method_15();
	}

	private void method_15()
	{
		base.SelectSqlData(this.class469_0, this.class469_0.tJ_OrderResolution, true, " where idorder = " + this.int_0.ToString() + " order by datebegin ");
		this.method_6();
	}

	private void comboBox_7_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.class469_0.tJ_Order.Rows.Count > 0 && this.comboBox_7.SelectedValue != null && this.nullableDateTimePicker_4.Value == null)
		{
			if (this.nullableDateTimePicker_4.MaxDate >= DateTime.Now)
			{
				if (this.nullableDateTimePicker_4.MinDate <= DateTime.Now)
				{
					try
					{
						this.nullableDateTimePicker_4.Value = DateTime.Now;
						return;
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message);
						return;
					}
				}
				if (this.int_0 > 0 && this.class469_0.tJ_Order.Rows.Count > 0)
				{
					this.class469_0.tJ_Order.Rows[0]["dateclose"] = this.nullableDateTimePicker_4.MinDate;
					return;
				}
				this.nullableDateTimePicker_4.Value = this.nullableDateTimePicker_4.MinDate;
				return;
			}
			else
			{
				if (this.int_0 > 0 && this.class469_0.tJ_Order.Rows.Count > 0)
				{
					this.class469_0.tJ_Order.Rows[0]["dateclose"] = this.nullableDateTimePicker_4.MaxDate;
					return;
				}
				this.nullableDateTimePicker_4.Value = this.nullableDateTimePicker_4.MaxDate;
			}
		}
	}

	private void button_3_Click(object sender, EventArgs e)
	{
		if (this.nullableDateTimePicker_4.Value == null)
		{
			MessageBox.Show("Не введена дата закрытия наряда", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return;
		}
		if (this.comboBox_7.SelectedValue == null)
		{
			MessageBox.Show("Не выбран диспетчер, закрывающий наряд", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return;
		}
		if (this.class469_0.tJ_Order.Rows.Count > 0 && Convert.ToBoolean(this.class469_0.tJ_Order.Rows[0]["Registered"]))
		{
			this.class469_0.tJ_Order.Rows[0]["DateClose"] = Convert.ToDateTime(this.nullableDateTimePicker_4.Value).AddSeconds((double)(-(double)Convert.ToDateTime(this.nullableDateTimePicker_4.Value).Second));
			this.class469_0.tJ_Order.Rows[0]["closeWorker"] = this.comboBox_7.SelectedValue;
			this.method_8();
		}
		this.method_7();
		this.method_6();
	}

	private void toolStripButton_0_Click(object sender, EventArgs e)
	{
		if (this.method_0() > 0)
		{
			Class121.smethod_0(this.method_0(), this.SqlSettings);
		}
	}

	private void rwbovvjUheW_Click(object sender, EventArgs e)
	{
		if (MessageBox.Show("Скопировать текущий наряд?", "Копирование", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
		{
			this.int_0 = -1;
			this.class469_0.tL_OrderSchmObjList.Clear();
			new Class469();
			DataTable dataTable = this.class469_0.tJ_OrderBrigade.Copy();
			this.class469_0.tJ_OrderBrigade.Clear();
			this.VaCovZpCew7.DataMember = "";
			foreach (object obj in dataTable.Rows)
			{
				DataRow dataRow = (DataRow)obj;
				DataRow dataRow2 = this.class469_0.tJ_OrderBrigade.NewRow();
				dataRow2["idOrder"] = this.method_0();
				dataRow2["idWorker"] = dataRow["idWorker"];
				dataRow2["idJobTitle"] = dataRow["idJobTitle"];
				dataRow2["isUnderstudy"] = dataRow["isUnderstudy"];
				this.class469_0.tJ_OrderBrigade.Rows.Add(dataRow2);
			}
			this.VaCovZpCew7.DataMember = "tJ_OrderBrigade";
			DataTable dataTable2 = this.class469_0.tJ_OrderInstruction.Copy();
			this.class469_0.tJ_OrderInstruction.Clear();
			foreach (object obj2 in dataTable2.Rows)
			{
				DataRow dataRow3 = (DataRow)obj2;
				DataRow dataRow4 = this.class469_0.tJ_OrderInstruction.NewRow();
				dataRow4["idOrder"] = this.method_0();
				dataRow4["nameObj"] = dataRow3["nameObj"];
				dataRow4["Instruction"] = dataRow3["Instruction"];
				dataRow4["rec_num"] = dataRow3["rec_num"];
				this.class469_0.tJ_OrderInstruction.Rows.Add(dataRow4);
			}
			this.class469_0.tJ_OrderResolution.Clear();
			this.method_16();
			this.textBox_0.BackColor = Color.Yellow;
			this.panel_0.Enabled = false;
			this.nullableDateTimePicker_0.Enabled = true;
			this.nullableDateTimePicker_1.Enabled = true;
			this.comboBox_0.Enabled = true;
			this.comboBox_2.Enabled = true;
			this.comboBox_1.Enabled = true;
			this.comboBox_3.Enabled = true;
			this.comboBox_4.Enabled = true;
			this.comboBox_5.Enabled = true;
			this.richTextBox_0.ReadOnly = false;
			this.richTextBox_1.ReadOnly = false;
			this.nullableDateTimePicker_2.Enabled = true;
			this.VaCovZpCew7.ReadOnly = false;
			this.VaCovZpCew7.AllowUserToAddRows = true;
			this.dataGridView_0.ReadOnly = false;
			this.dataGridView_0.AllowUserToAddRows = true;
			this.button_1.Enabled = true;
			this.button_0.Enabled = true;
			this.toolStripButton_2.Enabled = true;
			this.toolStripButton_1.Enabled = true;
			this.panel_0.Enabled = false;
			this.comboBox_6.Enabled = false;
			this.nullableDateTimePicker_3.Enabled = false;
			this.button_2.Enabled = false;
			this.comboBox_7.Enabled = false;
			this.nullableDateTimePicker_4.Enabled = false;
			this.button_3.Enabled = false;
			this.panel_0.Enabled = false;
			this.rwbovvjUheW.Enabled = false;
			this.toolStripButton_0.Enabled = false;
			if (base.PermissionsControlsEnabled || base.PermissionsControlsVisible)
			{
				base.SetControlsPropertiesUser();
			}
		}
	}

	private void method_16()
	{
		object value = this.nullableDateTimePicker_0.Value;
		object value2 = this.nullableDateTimePicker_1.Value;
		object selectedValue = this.comboBox_0.SelectedValue;
		object text = this.richTextBox_0.Text;
		object selectedValue2 = this.comboBox_2.SelectedValue;
		object selectedValue3 = this.comboBox_1.SelectedValue;
		object selectedValue4 = this.comboBox_3.SelectedValue;
		object selectedValue5 = this.comboBox_4.SelectedValue;
		object text2 = this.richTextBox_1.Text;
		object value3 = this.nullableDateTimePicker_2.Value;
		object selectedValue6 = this.comboBox_5.SelectedValue;
		object selectedValue7 = this.comboBoxReadOnly_0.SelectedValue;
		this.class469_0.tJ_Order.Clear();
		this.nullableDateTimePicker_0.Value = null;
		this.nullableDateTimePicker_1.Value = null;
		if (selectedValue == null)
		{
			this.comboBox_0.SelectedIndex = -1;
		}
		else
		{
			this.comboBox_0.SelectedValue = selectedValue;
		}
		this.richTextBox_0.Text = text.ToString();
		if (selectedValue2 == null)
		{
			this.comboBox_2.SelectedIndex = -1;
		}
		else
		{
			this.comboBox_2.SelectedValue = selectedValue2;
		}
		if (selectedValue3 == null)
		{
			this.comboBox_1.SelectedIndex = -1;
		}
		else
		{
			this.comboBox_1.SelectedValue = selectedValue3;
		}
		if (selectedValue4 == null)
		{
			this.comboBox_3.SelectedIndex = -1;
		}
		else
		{
			this.comboBox_3.SelectedValue = selectedValue4;
		}
		if (selectedValue5 == null)
		{
			this.comboBox_4.SelectedIndex = -1;
		}
		else
		{
			this.comboBox_4.SelectedValue = selectedValue5;
		}
		if (selectedValue7 == null)
		{
			this.comboBoxReadOnly_0.SelectedIndex = -1;
		}
		else
		{
			this.comboBoxReadOnly_0.SelectedValue = selectedValue7;
		}
		this.richTextBox_1.Text = text2.ToString();
		this.nullableDateTimePicker_2.Value = null;
		this.comboBox_5.SelectedValue = DBNull.Value;
		this.dictionary_0.Clear();
		this.method_17();
		this.toolStripButton_3.Enabled = false;
	}

	private void Form29_KeyDown(object sender, KeyEventArgs e)
	{
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
		xmlAttribute = xmlDocument.CreateAttribute("Width");
		xmlAttribute.Value = base.Width.ToString();
		xmlNode.Attributes.Append(xmlAttribute);
		xmlAttribute = xmlDocument.CreateAttribute("Height");
		xmlAttribute.Value = base.Height.ToString();
		xmlNode.Attributes.Append(xmlAttribute);
		xmlAttribute = xmlDocument.CreateAttribute("SplitterDistance");
		xmlAttribute.Value = this.splitContainer_0.SplitterDistance.ToString();
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
				base.Location = new Point(num.Value, num2.Value);
			}
			xmlAttribute = xmlNode.Attributes["Width"];
			if (xmlAttribute != null)
			{
				base.Width = Convert.ToInt32(xmlAttribute.Value);
			}
			xmlAttribute = xmlNode.Attributes["Height"];
			if (xmlAttribute != null)
			{
				base.Height = Convert.ToInt32(xmlAttribute.Value);
			}
			xmlAttribute = xmlNode.Attributes["SplitterDistance"];
			if (xmlAttribute != null)
			{
				this.splitContainer_0.SplitterDistance = Convert.ToInt32(xmlAttribute.Value);
			}
		}
	}

	private void toolStripButton_1_Click(object sender, EventArgs e)
	{
		Form31 form = new Form31();
		form.method_1(this.dictionary_0);
		form.SqlSettings = this.SqlSettings;
		if (form.ShowDialog() == DialogResult.OK)
		{
			this.dictionary_0 = form.method_0();
			if (this.dictionary_0.Count > 0)
			{
				this.toolStripButton_3.Enabled = true;
			}
			this.method_17();
		}
	}

	private void toolStripButton_2_Click(object sender, EventArgs e)
	{
		foreach (object obj in this.listBox_0.SelectedItems)
		{
			this.dictionary_0.Remove(((FormJournalOrderAddEdit.Struct4)obj).int_0);
		}
		this.method_17();
		if (this.dictionary_0.Count > 0)
		{
			this.toolStripButton_3.Enabled = true;
			return;
		}
		this.toolStripButton_3.Enabled = false;
	}

	private void method_17()
	{
		this.listBox_0.Items.Clear();
		foreach (int num in this.dictionary_0.Keys)
		{
			this.listBox_0.Items.Add(new FormJournalOrderAddEdit.Struct4(num, this.dictionary_0[num]));
		}
	}

	private void toolStripButton_3_Click(object sender, EventArgs e)
	{
		GoToSchemaEventArgs e2 = new GoToSchemaEventArgs(this.dictionary_0.Keys.ToList<int>());
		this.OnGoToSchema(e2);
	}

	private void method_18(ComboBox comboBox_8, TextBox textBox_6)
	{
		if (comboBox_8.SelectedValue == null)
		{
			textBox_6.Text = "";
			return;
		}
		DataRow dataRow = (comboBox_8.DataSource as DataTable).Rows.Find(comboBox_8.SelectedValue);
		if (dataRow["GroupElectrical"] == DBNull.Value)
		{
			textBox_6.Text = "";
			return;
		}
		switch (Convert.ToInt32(dataRow["GroupElectrical"]))
		{
		case 1:
			textBox_6.Text = "I";
			return;
		case 2:
			textBox_6.Text = "II";
			return;
		case 3:
			textBox_6.Text = "III";
			return;
		case 4:
			textBox_6.Text = "IV";
			return;
		case 5:
			textBox_6.Text = "V";
			return;
		default:
			textBox_6.Text = "";
			return;
		}
	}

	private void comboBox_2_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.method_18((ComboBox)sender, this.textBox_1);
	}

	private void comboBox_5_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.method_18((ComboBox)sender, this.textBox_2);
		if (this.comboBox_5.SelectedValue != null && this.nullableDateTimePicker_2.Value == null)
		{
			if (this.nullableDateTimePicker_2.MaxDate >= DateTime.Now)
			{
				if (this.nullableDateTimePicker_2.MinDate <= DateTime.Now)
				{
					this.nullableDateTimePicker_2.Value = DateTime.Now;
					return;
				}
				this.nullableDateTimePicker_2.Value = this.nullableDateTimePicker_2.MinDate;
				return;
			}
			else
			{
				this.nullableDateTimePicker_2.Value = this.nullableDateTimePicker_2.MaxDate;
			}
		}
	}

	private void comboBox_1_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.method_18((ComboBox)sender, this.textBox_5);
	}

	private void comboBox_3_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.method_18((ComboBox)sender, this.textBox_4);
	}

	private void comboBox_4_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.method_18((ComboBox)sender, this.textBox_3);
	}

	private void comboBox_2_TextChanged(object sender, EventArgs e)
	{
		if (string.IsNullOrEmpty(((ComboBox)sender).Text))
		{
			((ComboBox)sender).SelectedIndex = -1;
			if (this.class469_0.tJ_Order.Rows.Count > 0)
			{
				this.class469_0.tJ_Order.Rows[0]["headWorker"] = DBNull.Value;
			}
			this.method_18((ComboBox)sender, this.textBox_1);
		}
	}

	private void comboBox_3_TextChanged(object sender, EventArgs e)
	{
		if (string.IsNullOrEmpty(((ComboBox)sender).Text))
		{
			((ComboBox)sender).SelectedIndex = -1;
			if (this.class469_0.tJ_Order.Rows.Count > 0)
			{
				this.class469_0.tJ_Order.Rows[0]["watchWorker"] = DBNull.Value;
			}
			this.method_18((ComboBox)sender, this.textBox_4);
		}
	}

	private void comboBox_5_TextChanged(object sender, EventArgs e)
	{
		if (string.IsNullOrEmpty(((ComboBox)sender).Text))
		{
			((ComboBox)sender).SelectedIndex = -1;
			this.method_18((ComboBox)sender, this.textBox_2);
		}
	}

	private void comboBox_1_TextChanged(object sender, EventArgs e)
	{
		if (string.IsNullOrEmpty(((ComboBox)sender).Text))
		{
			((ComboBox)sender).SelectedIndex = -1;
			this.method_18((ComboBox)sender, this.textBox_5);
		}
	}

	private void comboBox_4_TextChanged(object sender, EventArgs e)
	{
		if (string.IsNullOrEmpty(((ComboBox)sender).Text))
		{
			((ComboBox)sender).SelectedIndex = -1;
			this.method_18((ComboBox)sender, this.textBox_3);
		}
	}

	private void method_19()
	{
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
		this.label_0 = new Label();
		this.textBox_0 = new TextBox();
		this.class469_0 = new Class469();
		this.label_1 = new Label();
		this.label_2 = new Label();
		this.label_3 = new Label();
		this.richTextBox_0 = new RichTextBox();
		this.label_4 = new Label();
		this.comboBox_0 = new ComboBox();
		this.label_5 = new Label();
		this.dfRoOrlkqAm = new Label();
		this.label_6 = new Label();
		this.label_7 = new Label();
		this.label_8 = new Label();
		this.label_9 = new Label();
		this.richTextBox_1 = new RichTextBox();
		this.label_10 = new Label();
		this.comboBox_1 = new ComboBox();
		this.nullableDateTimePicker_0 = new NullableDateTimePicker();
		this.nullableDateTimePicker_1 = new NullableDateTimePicker();
		this.comboBox_2 = new ComboBox();
		this.comboBox_3 = new ComboBox();
		this.comboBox_4 = new ComboBox();
		this.comboBox_5 = new ComboBox();
		this.nullableDateTimePicker_2 = new NullableDateTimePicker();
		this.button_0 = new Button();
		this.button_1 = new Button();
		this.VaCovZpCew7 = new DataGridView();
		this.dataGridViewTextBoxColumn_9 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_10 = new DataGridViewTextBoxColumn();
		this.dataGridViewComboBoxColumn_1 = new DataGridViewComboBoxColumn();
		this.dataGridViewTextBoxColumn_11 = new DataGridViewTextBoxColumn();
		this.dataGridViewComboBoxColumn_2 = new DataGridViewComboBoxColumn();
		this.dataGridViewCheckBoxColumn_0 = new DataGridViewCheckBoxColumn();
		this.label_11 = new Label();
		this.dataGridView_0 = new DataGridView();
		this.dataGridViewTextBoxColumn_4 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_5 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_6 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_7 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_8 = new DataGridViewTextBoxColumn();
		this.dataGridView_1 = new DataGridView();
		this.dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
		this.dataGridViewComboBoxColumn_0 = new DataGridViewComboBoxColumn();
		this.dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_3 = new DataGridViewTextBoxColumn();
		this.comboBox_6 = new ComboBox();
		this.nullableDateTimePicker_3 = new NullableDateTimePicker();
		this.button_2 = new Button();
		this.button_3 = new Button();
		this.nullableDateTimePicker_4 = new NullableDateTimePicker();
		this.comboBox_7 = new ComboBox();
		this.toolStrip_0 = new ToolStrip();
		this.toolStripButton_0 = new ToolStripButton();
		this.rwbovvjUheW = new ToolStripButton();
		this.splitContainer_0 = new SplitContainer();
		this.label_13 = new Label();
		this.panel_0 = new Panel();
		this.button_4 = new Button();
		this.OxGovjdrwUI = new NullableDateTimePicker();
		this.KdqovVhxpIs = new MultiColumnComboBox();
		this.JjLovUvvoc5 = new Label();
		this.textBox_2 = new TextBox();
		this.toolStrip_1 = new ToolStrip();
		this.toolStripButton_1 = new ToolStripButton();
		this.toolStripButton_2 = new ToolStripButton();
		this.toolStripButton_3 = new ToolStripButton();
		this.listBox_0 = new ListBox();
		this.label_15 = new Label();
		this.comboBoxReadOnly_0 = new ComboBoxReadOnly();
		this.label_14 = new Label();
		this.textBox_3 = new TextBox();
		this.textBox_4 = new TextBox();
		this.textBox_5 = new TextBox();
		this.textBox_1 = new TextBox();
		this.label_12 = new Label();
		((ISupportInitialize)this.class469_0).BeginInit();
		((ISupportInitialize)this.VaCovZpCew7).BeginInit();
		((ISupportInitialize)this.dataGridView_0).BeginInit();
		((ISupportInitialize)this.dataGridView_1).BeginInit();
		this.toolStrip_0.SuspendLayout();
		this.splitContainer_0.Panel1.SuspendLayout();
		this.splitContainer_0.Panel2.SuspendLayout();
		this.splitContainer_0.SuspendLayout();
		this.panel_0.SuspendLayout();
		this.toolStrip_1.SuspendLayout();
		base.SuspendLayout();
		this.label_0.AutoSize = true;
		this.label_0.Location = new Point(13, 37);
		this.label_0.Name = "label1";
		this.label_0.Size = new Size(91, 13);
		this.label_0.TabIndex = 0;
		this.label_0.Text = "Наряд-допуск №";
		this.textBox_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_0.DataBindings.Add(new Binding("Text", this.class469_0, "tJ_Order.num", true));
		this.textBox_0.Location = new Point(110, 34);
		this.textBox_0.Name = "txtNumOrder";
		this.textBox_0.ReadOnly = true;
		this.textBox_0.Size = new Size(102, 20);
		this.textBox_0.TabIndex = 1;
		this.class469_0.DataSetName = "DataSetOrder";
		this.class469_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		this.label_1.AutoSize = true;
		this.label_1.Location = new Point(13, 77);
		this.label_1.Name = "labelDateBegin";
		this.label_1.Size = new Size(84, 13);
		this.label_1.TabIndex = 2;
		this.label_1.Text = "Начало работы";
		this.label_2.AutoSize = true;
		this.label_2.Location = new Point(13, 99);
		this.label_2.Name = "labelDateEnd";
		this.label_2.Size = new Size(102, 13);
		this.label_2.TabIndex = 3;
		this.label_2.Text = "Окончание работы";
		this.label_3.AutoSize = true;
		this.label_3.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.label_3.Location = new Point(13, 123);
		this.label_3.Name = "labelInstruction";
		this.label_3.Size = new Size(87, 17);
		this.label_3.TabIndex = 6;
		this.label_3.Text = "Поручается";
		this.richTextBox_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.richTextBox_0.DataBindings.Add(new Binding("Text", this.class469_0, "tJ_Order.instruction", true));
		this.richTextBox_0.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.richTextBox_0.Location = new Point(16, 143);
		this.richTextBox_0.Name = "richTxtInstruction";
		this.richTextBox_0.Size = new Size(230, 86);
		this.richTextBox_0.TabIndex = 7;
		this.richTextBox_0.Text = "";
		this.richTextBox_0.TextChanged += this.richTextBox_0_TextChanged;
		this.label_4.AutoSize = true;
		this.label_4.Location = new Point(44, 17);
		this.label_4.Name = "labelSR";
		this.label_4.Size = new Size(82, 13);
		this.label_4.TabIndex = 8;
		this.label_4.Text = "Сетевой район";
		this.comboBox_0.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBox_0.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBox_0.DataBindings.Add(new Binding("SelectedValue", this.class469_0, "tJ_Order.idSR", true));
		this.comboBox_0.DataSource = this.class469_0;
		this.comboBox_0.DisplayMember = "tR_Classifier.Name";
		this.comboBox_0.FormattingEnabled = true;
		this.comboBox_0.Location = new Point(132, 14);
		this.comboBox_0.Name = "cmbSR";
		this.comboBox_0.Size = new Size(158, 21);
		this.comboBox_0.TabIndex = 9;
		this.comboBox_0.ValueMember = "tR_Classifier.Id";
		this.comboBox_0.SelectedValueChanged += this.comboBox_0_SelectedValueChanged;
		this.label_5.AutoSize = true;
		this.label_5.Location = new Point(16, 67);
		this.label_5.Name = "label6";
		this.label_5.Size = new Size(110, 13);
		this.label_5.TabIndex = 10;
		this.label_5.Text = "Руководитель работ";
		this.dfRoOrlkqAm.AutoSize = true;
		this.dfRoOrlkqAm.Location = new Point(44, 95);
		this.dfRoOrlkqAm.Name = "labelAccept";
		this.dfRoOrlkqAm.Size = new Size(80, 13);
		this.dfRoOrlkqAm.TabIndex = 11;
		this.dfRoOrlkqAm.Text = "Допускающий";
		this.label_6.AutoSize = true;
		this.label_6.Location = new Point(44, 124);
		this.label_6.Name = "label8";
		this.label_6.Size = new Size(82, 13);
		this.label_6.TabIndex = 12;
		this.label_6.Text = "Наблюдающий";
		this.label_7.AutoSize = true;
		this.label_7.Location = new Point(6, 152);
		this.label_7.Name = "labelMaker";
		this.label_7.Size = new Size(118, 13);
		this.label_7.TabIndex = 13;
		this.label_7.Text = "Производитель работ";
		this.label_8.AutoSize = true;
		this.label_8.Location = new Point(307, 17);
		this.label_8.Name = "label10";
		this.label_8.Size = new Size(87, 13);
		this.label_8.TabIndex = 14;
		this.label_8.Text = "Члены бригады";
		this.label_9.AutoSize = true;
		this.label_9.Location = new Point(13, 232);
		this.label_9.Name = "label11";
		this.label_9.Size = new Size(114, 13);
		this.label_9.TabIndex = 15;
		this.label_9.Text = "Отдельные указания";
		this.richTextBox_1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.richTextBox_1.DataBindings.Add(new Binding("Text", this.class469_0, "tJ_Order.otherInstruction", true));
		this.richTextBox_1.Location = new Point(16, 248);
		this.richTextBox_1.Name = "richTxtOtrherInstructions";
		this.richTextBox_1.Size = new Size(230, 85);
		this.richTextBox_1.TabIndex = 16;
		this.richTextBox_1.Text = "";
		this.label_10.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.label_10.AutoSize = true;
		this.label_10.Location = new Point(13, 408);
		this.label_10.Name = "labelOutput";
		this.label_10.Size = new Size(74, 13);
		this.label_10.TabIndex = 17;
		this.label_10.Text = "Наряд выдал";
		this.comboBox_1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBox_1.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBox_1.DataBindings.Add(new Binding("SelectedValue", this.class469_0, "tJ_Order.acceptworker", true));
		this.comboBox_1.DisplayMember = "FIO";
		this.comboBox_1.FormattingEnabled = true;
		this.comboBox_1.Location = new Point(132, 92);
		this.comboBox_1.Name = "cmbAcceptWorker";
		this.comboBox_1.Size = new Size(133, 21);
		this.comboBox_1.TabIndex = 21;
		this.comboBox_1.ValueMember = "id";
		this.comboBox_1.SelectedIndexChanged += this.comboBox_1_SelectedIndexChanged;
		this.comboBox_1.SelectedValueChanged += this.comboBox_1_SelectedValueChanged;
		this.comboBox_1.TextChanged += this.comboBox_1_TextChanged;
		this.nullableDateTimePicker_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.nullableDateTimePicker_0.CustomFormat = "dd:MM:yyyy HH:mm";
		this.nullableDateTimePicker_0.DataBindings.Add(new Binding("Value", this.class469_0, "tJ_Order.dateBegin", true));
		this.nullableDateTimePicker_0.Format = DateTimePickerFormat.Custom;
		this.nullableDateTimePicker_0.Location = new Point(115, 71);
		this.nullableDateTimePicker_0.Name = "dateTimePickerDateBegin";
		this.nullableDateTimePicker_0.Size = new Size(131, 20);
		this.nullableDateTimePicker_0.TabIndex = 24;
		this.nullableDateTimePicker_0.Value = new DateTime(2012, 6, 5, 9, 25, 13, 282);
		this.nullableDateTimePicker_0.ValueChanged += this.nullableDateTimePicker_0_ValueChanged;
		this.nullableDateTimePicker_1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.nullableDateTimePicker_1.CustomFormat = "dd:MM:yyyy HH:mm";
		this.nullableDateTimePicker_1.DataBindings.Add(new Binding("Value", this.class469_0, "tJ_Order.dateEnd", true));
		this.nullableDateTimePicker_1.Format = DateTimePickerFormat.Custom;
		this.nullableDateTimePicker_1.Location = new Point(115, 93);
		this.nullableDateTimePicker_1.Name = "dateTimePickerDateEnd";
		this.nullableDateTimePicker_1.Size = new Size(131, 20);
		this.nullableDateTimePicker_1.TabIndex = 25;
		this.nullableDateTimePicker_1.Value = new DateTime(2012, 6, 5, 9, 28, 51, 995);
		this.nullableDateTimePicker_1.ValueChanged += this.nullableDateTimePicker_1_ValueChanged;
		this.comboBox_2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBox_2.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBox_2.DataBindings.Add(new Binding("SelectedValue", this.class469_0, "tJ_Order.headworker", true));
		this.comboBox_2.DisplayMember = "FIO";
		this.comboBox_2.FormattingEnabled = true;
		this.comboBox_2.Location = new Point(132, 64);
		this.comboBox_2.Name = "cmbHeadWorker";
		this.comboBox_2.Size = new Size(133, 21);
		this.comboBox_2.TabIndex = 26;
		this.comboBox_2.ValueMember = "id";
		this.comboBox_2.SelectedIndexChanged += this.comboBox_2_SelectedIndexChanged;
		this.comboBox_2.TextChanged += this.comboBox_2_TextChanged;
		this.comboBox_3.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBox_3.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBox_3.DataBindings.Add(new Binding("SelectedValue", this.class469_0, "tJ_Order.watchWorker", true));
		this.comboBox_3.DisplayMember = "FIO";
		this.comboBox_3.FormattingEnabled = true;
		this.comboBox_3.Location = new Point(132, 121);
		this.comboBox_3.Name = "cmbWatchWorker";
		this.comboBox_3.Size = new Size(133, 21);
		this.comboBox_3.TabIndex = 27;
		this.comboBox_3.ValueMember = "id";
		this.comboBox_3.SelectedIndexChanged += this.comboBox_3_SelectedIndexChanged;
		this.comboBox_3.TextChanged += this.comboBox_3_TextChanged;
		this.comboBox_4.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBox_4.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBox_4.DataBindings.Add(new Binding("SelectedValue", this.class469_0, "tJ_Order.makerWorker", true));
		this.comboBox_4.DisplayMember = "FIO";
		this.comboBox_4.FormattingEnabled = true;
		this.comboBox_4.Location = new Point(132, 149);
		this.comboBox_4.Name = "cmbMakerWorker";
		this.comboBox_4.Size = new Size(133, 21);
		this.comboBox_4.TabIndex = 28;
		this.comboBox_4.ValueMember = "id";
		this.comboBox_4.SelectedIndexChanged += this.comboBox_4_SelectedIndexChanged;
		this.comboBox_4.SelectedValueChanged += this.comboBox_4_SelectedValueChanged;
		this.comboBox_4.TextChanged += this.comboBox_4_TextChanged;
		this.comboBox_5.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.comboBox_5.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBox_5.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBox_5.DataBindings.Add(new Binding("SelectedValue", this.class469_0, "tJ_Order.outputWorker", true));
		this.comboBox_5.DisplayMember = "FIO";
		this.comboBox_5.FormattingEnabled = true;
		this.comboBox_5.Location = new Point(93, 405);
		this.comboBox_5.Name = "cmbOutputWorker";
		this.comboBox_5.Size = new Size(124, 21);
		this.comboBox_5.TabIndex = 29;
		this.comboBox_5.ValueMember = "id";
		this.comboBox_5.SelectedIndexChanged += this.comboBox_5_SelectedIndexChanged;
		this.comboBox_5.SelectedValueChanged += this.comboBox_5_SelectedValueChanged;
		this.comboBox_5.TextChanged += this.comboBox_5_TextChanged;
		this.nullableDateTimePicker_2.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.nullableDateTimePicker_2.CustomFormat = "dd:MM:yyyy HH:mm";
		this.nullableDateTimePicker_2.DataBindings.Add(new Binding("Value", this.class469_0, "tJ_Order.dateOutput", true));
		this.nullableDateTimePicker_2.Format = DateTimePickerFormat.Custom;
		this.nullableDateTimePicker_2.Location = new Point(93, 431);
		this.nullableDateTimePicker_2.Name = "dateTimePickerDateOutput";
		this.nullableDateTimePicker_2.Size = new Size(152, 20);
		this.nullableDateTimePicker_2.TabIndex = 30;
		this.nullableDateTimePicker_2.Value = new DateTime(2012, 6, 5, 9, 28, 51, 995);
		this.nullableDateTimePicker_2.ValueChanged += this.nullableDateTimePicker_2_ValueChanged;
		this.button_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.button_0.Location = new Point(16, 517);
		this.button_0.Name = "buttonSave";
		this.button_0.Size = new Size(75, 23);
		this.button_0.TabIndex = 31;
		this.button_0.Text = "Сохранить";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_0.Click += this.button_0_Click;
		this.button_1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.button_1.Location = new Point(97, 517);
		this.button_1.Name = "buttonRegister";
		this.button_1.Size = new Size(114, 23);
		this.button_1.TabIndex = 32;
		this.button_1.Text = "Зарегистрировать";
		this.button_1.UseVisualStyleBackColor = true;
		this.button_1.Click += this.button_1_Click;
		this.VaCovZpCew7.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.VaCovZpCew7.AutoGenerateColumns = false;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = SystemColors.Control;
		dataGridViewCellStyle.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		this.VaCovZpCew7.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		this.VaCovZpCew7.ColumnHeadersVisible = false;
		this.VaCovZpCew7.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewTextBoxColumn_9,
			this.dataGridViewTextBoxColumn_10,
			this.dataGridViewComboBoxColumn_1,
			this.dataGridViewTextBoxColumn_11,
			this.dataGridViewComboBoxColumn_2,
			this.dataGridViewCheckBoxColumn_0
		});
		this.VaCovZpCew7.DataMember = "tJ_OrderBrigade";
		this.VaCovZpCew7.DataSource = this.class469_0;
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = SystemColors.Window;
		dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
		this.VaCovZpCew7.DefaultCellStyle = dataGridViewCellStyle2;
		this.VaCovZpCew7.Location = new Point(296, 36);
		this.VaCovZpCew7.Name = "dgvBrigade";
		dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle3.BackColor = SystemColors.Control;
		dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
		this.VaCovZpCew7.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
		this.VaCovZpCew7.RowHeadersWidth = 30;
		this.VaCovZpCew7.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
		this.VaCovZpCew7.Size = new Size(310, 134);
		this.VaCovZpCew7.TabIndex = 33;
		this.VaCovZpCew7.CellEndEdit += this.VaCovZpCew7_CellEndEdit;
		this.VaCovZpCew7.CellValueChanged += this.VaCovZpCew7_CellValueChanged;
		this.VaCovZpCew7.DataError += this.dataGridView_1_DataError;
		this.VaCovZpCew7.EditingControlShowing += this.VaCovZpCew7_EditingControlShowing;
		this.VaCovZpCew7.RowsAdded += this.VaCovZpCew7_RowsAdded;
		this.VaCovZpCew7.KeyDown += this.VaCovZpCew7_KeyDown;
		this.dataGridViewTextBoxColumn_9.DataPropertyName = "id";
		this.dataGridViewTextBoxColumn_9.HeaderText = "id";
		this.dataGridViewTextBoxColumn_9.Name = "idDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_9.ReadOnly = true;
		this.dataGridViewTextBoxColumn_9.Visible = false;
		this.dataGridViewTextBoxColumn_10.DataPropertyName = "idOrder";
		this.dataGridViewTextBoxColumn_10.HeaderText = "idOrder";
		this.dataGridViewTextBoxColumn_10.Name = "idOrderDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_10.Visible = false;
		this.dataGridViewComboBoxColumn_1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewComboBoxColumn_1.DataPropertyName = "idWorker";
		this.dataGridViewComboBoxColumn_1.HeaderText = "idWorker";
		this.dataGridViewComboBoxColumn_1.Name = "brigadeWorkerColumn";
		this.dataGridViewComboBoxColumn_1.Resizable = DataGridViewTriState.True;
		this.dataGridViewComboBoxColumn_1.SortMode = DataGridViewColumnSortMode.Automatic;
		dataGridViewCellStyle4.BackColor = Color.LightGray;
		this.dataGridViewTextBoxColumn_11.DefaultCellStyle = dataGridViewCellStyle4;
		this.dataGridViewTextBoxColumn_11.HeaderText = "Гр";
		this.dataGridViewTextBoxColumn_11.Name = "GroupElectricalTxtColumn";
		this.dataGridViewTextBoxColumn_11.ReadOnly = true;
		this.dataGridViewTextBoxColumn_11.Width = 25;
		this.dataGridViewComboBoxColumn_2.DataPropertyName = "idJobTitle";
		this.dataGridViewComboBoxColumn_2.HeaderText = "должн.";
		this.dataGridViewComboBoxColumn_2.Name = "idJobTitleDgvColumn";
		this.dataGridViewCheckBoxColumn_0.DataPropertyName = "isUnderstudy";
		dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle5.BackColor = Color.LightGray;
		dataGridViewCellStyle5.NullValue = false;
		this.dataGridViewCheckBoxColumn_0.DefaultCellStyle = dataGridViewCellStyle5;
		this.dataGridViewCheckBoxColumn_0.HeaderText = "дублер";
		this.dataGridViewCheckBoxColumn_0.Name = "isUnderstudyDgvColumn";
		this.dataGridViewCheckBoxColumn_0.Width = 40;
		this.label_11.AutoSize = true;
		this.label_11.Location = new Point(147, 177);
		this.label_11.Name = "label13";
		this.label_11.Size = new Size(183, 13);
		this.label_11.TabIndex = 34;
		this.label_11.Text = "Меры по подготовке рабочих мест";
		this.dataGridView_0.AllowDrop = true;
		this.dataGridView_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.dataGridView_0.AutoGenerateColumns = false;
		this.dataGridView_0.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
		dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle6.BackColor = SystemColors.Control;
		dataGridViewCellStyle6.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
		this.dataGridView_0.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
		this.dataGridView_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView_0.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewTextBoxColumn_4,
			this.dataGridViewTextBoxColumn_5,
			this.dataGridViewTextBoxColumn_6,
			this.dataGridViewTextBoxColumn_7,
			this.dataGridViewTextBoxColumn_8
		});
		this.dataGridView_0.DataMember = "tJ_OrderInstruction";
		this.dataGridView_0.DataSource = this.class469_0;
		dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle7.BackColor = SystemColors.Window;
		dataGridViewCellStyle7.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle7.ForeColor = SystemColors.ControlText;
		dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
		this.dataGridView_0.DefaultCellStyle = dataGridViewCellStyle7;
		this.dataGridView_0.Location = new Point(9, 193);
		this.dataGridView_0.Name = "dgvInstruction";
		dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle8.BackColor = SystemColors.Control;
		dataGridViewCellStyle8.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle8.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
		this.dataGridView_0.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
		dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
		this.dataGridView_0.RowsDefaultCellStyle = dataGridViewCellStyle9;
		this.dataGridView_0.RowTemplate.Height = 44;
		this.dataGridView_0.RowTemplate.Resizable = DataGridViewTriState.True;
		this.dataGridView_0.Size = new Size(597, 169);
		this.dataGridView_0.TabIndex = 35;
		this.dataGridView_0.CellDoubleClick += this.dataGridView_0_CellDoubleClick;
		this.dataGridView_0.CellValueChanged += this.dataGridView_0_CellValueChanged;
		this.dataGridView_0.DataError += this.dataGridView_0_DataError;
		this.dataGridViewTextBoxColumn_4.DataPropertyName = "id";
		this.dataGridViewTextBoxColumn_4.HeaderText = "id";
		this.dataGridViewTextBoxColumn_4.Name = "idDataGridViewTextBoxColumn1";
		this.dataGridViewTextBoxColumn_4.ReadOnly = true;
		this.dataGridViewTextBoxColumn_4.Visible = false;
		this.dataGridViewTextBoxColumn_5.DataPropertyName = "idOrder";
		this.dataGridViewTextBoxColumn_5.HeaderText = "idOrder";
		this.dataGridViewTextBoxColumn_5.Name = "idOrderDgvColumnInstruction";
		this.dataGridViewTextBoxColumn_5.Visible = false;
		this.dataGridViewTextBoxColumn_6.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_6.DataPropertyName = "NameObj";
		this.dataGridViewTextBoxColumn_6.FillWeight = 35f;
		this.dataGridViewTextBoxColumn_6.HeaderText = "Наименование электроустановок";
		this.dataGridViewTextBoxColumn_6.Name = "nameObjDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_6.SortMode = DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn_7.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_7.DataPropertyName = "Instruction";
		this.dataGridViewTextBoxColumn_7.FillWeight = 65f;
		this.dataGridViewTextBoxColumn_7.HeaderText = "Что должно быть отключено и где заземлено";
		this.dataGridViewTextBoxColumn_7.Name = "instructionDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_7.SortMode = DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn_8.DataPropertyName = "rec_num";
		this.dataGridViewTextBoxColumn_8.HeaderText = "rec_num";
		this.dataGridViewTextBoxColumn_8.Name = "recnumDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_8.Visible = false;
		this.dataGridView_1.AllowUserToAddRows = false;
		this.dataGridView_1.AllowUserToDeleteRows = false;
		this.dataGridView_1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.dataGridView_1.AutoGenerateColumns = false;
		this.dataGridView_1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView_1.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewTextBoxColumn_0,
			this.dataGridViewTextBoxColumn_1,
			this.dataGridViewComboBoxColumn_0,
			this.dataGridViewTextBoxColumn_2,
			this.dataGridViewTextBoxColumn_3
		});
		this.dataGridView_1.DataMember = "tJ_OrderResolution";
		this.dataGridView_1.DataSource = this.class469_0;
		this.dataGridView_1.Location = new Point(9, 381);
		this.dataGridView_1.Name = "dgvResolution";
		this.dataGridView_1.ReadOnly = true;
		this.dataGridView_1.RowHeadersVisible = false;
		this.dataGridView_1.RowTemplate.Resizable = DataGridViewTriState.False;
		this.dataGridView_1.Size = new Size(421, 117);
		this.dataGridView_1.TabIndex = 36;
		this.dataGridView_1.DataError += this.dataGridView_1_DataError;
		this.dataGridViewTextBoxColumn_0.DataPropertyName = "id";
		this.dataGridViewTextBoxColumn_0.HeaderText = "id";
		this.dataGridViewTextBoxColumn_0.Name = "idDataGridViewTextBoxColumn2";
		this.dataGridViewTextBoxColumn_0.ReadOnly = true;
		this.dataGridViewTextBoxColumn_0.Visible = false;
		this.dataGridViewTextBoxColumn_1.DataPropertyName = "idOrder";
		this.dataGridViewTextBoxColumn_1.HeaderText = "idOrder";
		this.dataGridViewTextBoxColumn_1.Name = "idOrderDataGridViewTextBoxColumn1";
		this.dataGridViewTextBoxColumn_1.ReadOnly = true;
		this.dataGridViewTextBoxColumn_1.Visible = false;
		this.dataGridViewComboBoxColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewComboBoxColumn_0.DataPropertyName = "idWorker";
		this.dataGridViewComboBoxColumn_0.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
		this.dataGridViewComboBoxColumn_0.FillWeight = 40f;
		this.dataGridViewComboBoxColumn_0.FlatStyle = FlatStyle.System;
		this.dataGridViewComboBoxColumn_0.HeaderText = "Выдал";
		this.dataGridViewComboBoxColumn_0.Name = "workerResolutionColumn";
		this.dataGridViewComboBoxColumn_0.ReadOnly = true;
		this.dataGridViewComboBoxColumn_0.Resizable = DataGridViewTriState.True;
		this.dataGridViewTextBoxColumn_2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_2.DataPropertyName = "DateBegin";
		this.dataGridViewTextBoxColumn_2.FillWeight = 30f;
		this.dataGridViewTextBoxColumn_2.HeaderText = "Начало работ";
		this.dataGridViewTextBoxColumn_2.Name = "dateBeginDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_2.ReadOnly = true;
		this.dataGridViewTextBoxColumn_2.SortMode = DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn_3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_3.DataPropertyName = "DateEnd";
		this.dataGridViewTextBoxColumn_3.FillWeight = 30f;
		this.dataGridViewTextBoxColumn_3.HeaderText = "Работа закончена";
		this.dataGridViewTextBoxColumn_3.Name = "dateEndDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_3.ReadOnly = true;
		this.dataGridViewTextBoxColumn_3.SortMode = DataGridViewColumnSortMode.NotSortable;
		this.comboBox_6.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.comboBox_6.Enabled = false;
		this.comboBox_6.FormattingEnabled = true;
		this.comboBox_6.Location = new Point(436, 381);
		this.comboBox_6.Name = "cmbWorkerResolution";
		this.comboBox_6.Size = new Size(170, 21);
		this.comboBox_6.TabIndex = 37;
		this.comboBox_6.SelectedIndexChanged += this.comboBox_6_SelectedIndexChanged;
		this.nullableDateTimePicker_3.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.nullableDateTimePicker_3.CustomFormat = "dd:MM:yyyy HH:mm";
		this.nullableDateTimePicker_3.Enabled = false;
		this.nullableDateTimePicker_3.Format = DateTimePickerFormat.Custom;
		this.nullableDateTimePicker_3.Location = new Point(436, 408);
		this.nullableDateTimePicker_3.Name = "dateTimePickerResolution";
		this.nullableDateTimePicker_3.Size = new Size(170, 20);
		this.nullableDateTimePicker_3.TabIndex = 38;
		this.nullableDateTimePicker_3.Value = new DateTime(2012, 6, 5, 9, 28, 51, 995);
		this.button_2.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.button_2.Enabled = false;
		this.button_2.Location = new Point(472, 434);
		this.button_2.Name = "buttonResolution";
		this.button_2.Size = new Size(134, 23);
		this.button_2.TabIndex = 39;
		this.button_2.Text = "Выдать разрешение";
		this.button_2.UseVisualStyleBackColor = true;
		this.button_2.Click += this.button_2_Click;
		this.button_3.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.button_3.Enabled = false;
		this.button_3.Location = new Point(472, 517);
		this.button_3.Name = "buttonCloseOrder";
		this.button_3.Size = new Size(134, 23);
		this.button_3.TabIndex = 42;
		this.button_3.Text = "Закрыть наряд";
		this.button_3.UseVisualStyleBackColor = true;
		this.button_3.Click += this.button_3_Click;
		this.nullableDateTimePicker_4.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.nullableDateTimePicker_4.CustomFormat = "dd:MM:yyyy HH:mm";
		this.nullableDateTimePicker_4.Enabled = false;
		this.nullableDateTimePicker_4.Format = DateTimePickerFormat.Custom;
		this.nullableDateTimePicker_4.Location = new Point(260, 520);
		this.nullableDateTimePicker_4.Name = "dateTimePickerClose";
		this.nullableDateTimePicker_4.Size = new Size(170, 20);
		this.nullableDateTimePicker_4.TabIndex = 41;
		this.nullableDateTimePicker_4.Value = new DateTime(2012, 6, 5, 9, 28, 51, 995);
		this.comboBox_7.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.comboBox_7.Enabled = false;
		this.comboBox_7.FormattingEnabled = true;
		this.comboBox_7.Location = new Point(84, 519);
		this.comboBox_7.Name = "cmbCloseWorker";
		this.comboBox_7.Size = new Size(170, 21);
		this.comboBox_7.TabIndex = 40;
		this.comboBox_7.SelectedIndexChanged += this.comboBox_7_SelectedIndexChanged;
		this.toolStrip_0.GripStyle = ToolStripGripStyle.Hidden;
		this.toolStrip_0.Items.AddRange(new ToolStripItem[]
		{
			this.toolStripButton_0,
			this.rwbovvjUheW
		});
		this.toolStrip_0.Location = new Point(0, 0);
		this.toolStrip_0.Name = "toolStripReport";
		this.toolStrip_0.Size = new Size(252, 25);
		this.toolStrip_0.TabIndex = 43;
		this.toolStrip_0.Text = "toolStrip1";
		this.toolStripButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_0.Enabled = false;
		this.toolStripButton_0.Image = Resources.microsoftoffice2007excel_7581;
		this.toolStripButton_0.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_0.Name = "toolBtnReport";
		this.toolStripButton_0.Size = new Size(23, 22);
		this.toolStripButton_0.Text = "Печать наряда";
		this.toolStripButton_0.Click += this.toolStripButton_0_Click;
		this.rwbovvjUheW.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.rwbovvjUheW.Enabled = false;
		this.rwbovvjUheW.Image = Resources.CopyBuffer;
		this.rwbovvjUheW.ImageTransparentColor = Color.Magenta;
		this.rwbovvjUheW.Name = "toolBtnCopyOrder";
		this.rwbovvjUheW.Size = new Size(23, 22);
		this.rwbovvjUheW.Text = "Копировать наряд";
		this.rwbovvjUheW.Click += this.rwbovvjUheW_Click;
		this.splitContainer_0.Dock = DockStyle.Fill;
		this.splitContainer_0.FixedPanel = FixedPanel.Panel1;
		this.splitContainer_0.Location = new Point(0, 0);
		this.splitContainer_0.Name = "splitContainer";
		this.splitContainer_0.Panel1.Controls.Add(this.label_13);
		this.splitContainer_0.Panel1.Controls.Add(this.panel_0);
		this.splitContainer_0.Panel1.Controls.Add(this.textBox_2);
		this.splitContainer_0.Panel1.Controls.Add(this.toolStrip_1);
		this.splitContainer_0.Panel1.Controls.Add(this.listBox_0);
		this.splitContainer_0.Panel1.Controls.Add(this.button_0);
		this.splitContainer_0.Panel1.Controls.Add(this.toolStrip_0);
		this.splitContainer_0.Panel1.Controls.Add(this.label_0);
		this.splitContainer_0.Panel1.Controls.Add(this.textBox_0);
		this.splitContainer_0.Panel1.Controls.Add(this.label_1);
		this.splitContainer_0.Panel1.Controls.Add(this.label_2);
		this.splitContainer_0.Panel1.Controls.Add(this.label_3);
		this.splitContainer_0.Panel1.Controls.Add(this.richTextBox_0);
		this.splitContainer_0.Panel1.Controls.Add(this.label_9);
		this.splitContainer_0.Panel1.Controls.Add(this.richTextBox_1);
		this.splitContainer_0.Panel1.Controls.Add(this.label_10);
		this.splitContainer_0.Panel1.Controls.Add(this.nullableDateTimePicker_0);
		this.splitContainer_0.Panel1.Controls.Add(this.nullableDateTimePicker_1);
		this.splitContainer_0.Panel1.Controls.Add(this.button_1);
		this.splitContainer_0.Panel1.Controls.Add(this.comboBox_5);
		this.splitContainer_0.Panel1.Controls.Add(this.nullableDateTimePicker_2);
		this.splitContainer_0.Panel2.Controls.Add(this.label_15);
		this.splitContainer_0.Panel2.Controls.Add(this.comboBoxReadOnly_0);
		this.splitContainer_0.Panel2.Controls.Add(this.label_14);
		this.splitContainer_0.Panel2.Controls.Add(this.textBox_3);
		this.splitContainer_0.Panel2.Controls.Add(this.textBox_4);
		this.splitContainer_0.Panel2.Controls.Add(this.textBox_5);
		this.splitContainer_0.Panel2.Controls.Add(this.textBox_1);
		this.splitContainer_0.Panel2.Controls.Add(this.label_12);
		this.splitContainer_0.Panel2.Controls.Add(this.VaCovZpCew7);
		this.splitContainer_0.Panel2.Controls.Add(this.button_3);
		this.splitContainer_0.Panel2.Controls.Add(this.label_4);
		this.splitContainer_0.Panel2.Controls.Add(this.nullableDateTimePicker_4);
		this.splitContainer_0.Panel2.Controls.Add(this.comboBox_0);
		this.splitContainer_0.Panel2.Controls.Add(this.comboBox_7);
		this.splitContainer_0.Panel2.Controls.Add(this.label_5);
		this.splitContainer_0.Panel2.Controls.Add(this.button_2);
		this.splitContainer_0.Panel2.Controls.Add(this.dfRoOrlkqAm);
		this.splitContainer_0.Panel2.Controls.Add(this.nullableDateTimePicker_3);
		this.splitContainer_0.Panel2.Controls.Add(this.label_6);
		this.splitContainer_0.Panel2.Controls.Add(this.comboBox_6);
		this.splitContainer_0.Panel2.Controls.Add(this.label_7);
		this.splitContainer_0.Panel2.Controls.Add(this.dataGridView_1);
		this.splitContainer_0.Panel2.Controls.Add(this.label_8);
		this.splitContainer_0.Panel2.Controls.Add(this.dataGridView_0);
		this.splitContainer_0.Panel2.Controls.Add(this.comboBox_1);
		this.splitContainer_0.Panel2.Controls.Add(this.label_11);
		this.splitContainer_0.Panel2.Controls.Add(this.comboBox_2);
		this.splitContainer_0.Panel2.Controls.Add(this.comboBox_3);
		this.splitContainer_0.Panel2.Controls.Add(this.comboBox_4);
		this.splitContainer_0.Size = new Size(876, 543);
		this.splitContainer_0.SplitterDistance = 252;
		this.splitContainer_0.TabIndex = 44;
		this.label_13.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.label_13.AutoSize = true;
		this.label_13.Location = new Point(13, 437);
		this.label_13.Name = "labelOutputDate";
		this.label_13.Size = new Size(77, 13);
		this.label_13.TabIndex = 50;
		this.label_13.Text = "Дата и время";
		this.panel_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.panel_0.BackColor = SystemColors.ControlDark;
		this.panel_0.Controls.Add(this.button_4);
		this.panel_0.Controls.Add(this.OxGovjdrwUI);
		this.panel_0.Controls.Add(this.KdqovVhxpIs);
		this.panel_0.Controls.Add(this.JjLovUvvoc5);
		this.panel_0.Enabled = false;
		this.panel_0.Location = new Point(13, 457);
		this.panel_0.Name = "panelExtension";
		this.panel_0.Size = new Size(233, 54);
		this.panel_0.TabIndex = 49;
		this.button_4.Location = new Point(6, 27);
		this.button_4.Name = "buttonExtension";
		this.button_4.Size = new Size(75, 23);
		this.button_4.TabIndex = 32;
		this.button_4.Text = "Продлить";
		this.button_4.UseVisualStyleBackColor = true;
		this.button_4.Click += this.button_4_Click;
		this.OxGovjdrwUI.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.OxGovjdrwUI.CustomFormat = "dd:MM:yyyy HH:mm";
		this.OxGovjdrwUI.DataBindings.Add(new Binding("Value", this.class469_0, "tJ_Order.dateEndExt", true));
		this.OxGovjdrwUI.Format = DateTimePickerFormat.Custom;
		this.OxGovjdrwUI.Location = new Point(93, 30);
		this.OxGovjdrwUI.Name = "dateTimePickerDateEndExt";
		this.OxGovjdrwUI.Size = new Size(137, 20);
		this.OxGovjdrwUI.TabIndex = 31;
		this.OxGovjdrwUI.Value = new DateTime(2012, 6, 5, 9, 28, 51, 995);
		this.KdqovVhxpIs.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
		this.KdqovVhxpIs.AutoComplete = false;
		this.KdqovVhxpIs.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.KdqovVhxpIs.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.KdqovVhxpIs.AutoDropdown = false;
		this.KdqovVhxpIs.BackColorEven = Color.White;
		this.KdqovVhxpIs.BackColorOdd = Color.White;
		this.KdqovVhxpIs.ColumnNames = "";
		this.KdqovVhxpIs.ColumnWidthDefault = 75;
		this.KdqovVhxpIs.ColumnWidths = "0;120;0;30";
		this.KdqovVhxpIs.DataBindings.Add(new Binding("SelectedValue", this.class469_0, "tJ_Order.extWorker", true));
		this.KdqovVhxpIs.DisplayMember = "id";
		this.KdqovVhxpIs.DrawMode = DrawMode.OwnerDrawVariable;
		this.KdqovVhxpIs.FormattingEnabled = true;
		this.KdqovVhxpIs.LinkedColumnIndex = 0;
		this.KdqovVhxpIs.LinkedTextBox = null;
		this.KdqovVhxpIs.Location = new Point(93, 3);
		this.KdqovVhxpIs.Name = "cmbExtWorker";
		this.KdqovVhxpIs.Size = new Size(137, 21);
		this.KdqovVhxpIs.TabIndex = 30;
		this.KdqovVhxpIs.ValueMember = "id";
		this.JjLovUvvoc5.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.JjLovUvvoc5.AutoSize = true;
		this.JjLovUvvoc5.Location = new Point(3, 1);
		this.JjLovUvvoc5.Name = "label3";
		this.JjLovUvvoc5.Size = new Size(84, 13);
		this.JjLovUvvoc5.TabIndex = 18;
		this.JjLovUvvoc5.Text = "Наряд продлил";
		this.textBox_2.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.textBox_2.Location = new Point(218, 405);
		this.textBox_2.Name = "txtOutputWorker";
		this.textBox_2.ReadOnly = true;
		this.textBox_2.Size = new Size(27, 20);
		this.textBox_2.TabIndex = 48;
		this.toolStrip_1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.toolStrip_1.Dock = DockStyle.None;
		this.toolStrip_1.GripStyle = ToolStripGripStyle.Hidden;
		this.toolStrip_1.Items.AddRange(new ToolStripItem[]
		{
			this.toolStripButton_1,
			this.toolStripButton_2,
			this.toolStripButton_3
		});
		this.toolStrip_1.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
		this.toolStrip_1.Location = new Point(16, 331);
		this.toolStrip_1.Name = "toolStripScheme";
		this.toolStrip_1.Size = new Size(24, 71);
		this.toolStrip_1.TabIndex = 46;
		this.toolStrip_1.Text = "toolStrip1";
		this.toolStripButton_1.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_1.Image = Resources.ElementAdd;
		this.toolStripButton_1.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_1.Name = "toolBtnLinkSchmObj";
		this.toolStripButton_1.Size = new Size(22, 20);
		this.toolStripButton_1.Text = "Привязать к схеме";
		this.toolStripButton_1.Click += this.toolStripButton_1_Click;
		this.toolStripButton_2.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_2.Image = Resources.ElementDel;
		this.toolStripButton_2.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_2.Name = "toolBtnDelSchmObj";
		this.toolStripButton_2.Size = new Size(22, 20);
		this.toolStripButton_2.Text = "Удалить";
		this.toolStripButton_2.Click += this.toolStripButton_2_Click;
		this.toolStripButton_3.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_3.Enabled = false;
		this.toolStripButton_3.Image = Resources.ElementInformation;
		this.toolStripButton_3.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_3.Name = "toolBtnViewSChmObj";
		this.toolStripButton_3.Size = new Size(22, 20);
		this.toolStripButton_3.Text = "Показать на схеме";
		this.toolStripButton_3.Click += this.toolStripButton_3_Click;
		this.listBox_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.listBox_0.FormattingEnabled = true;
		this.listBox_0.Location = new Point(42, 333);
		this.listBox_0.Name = "listBoxLinkScmObjects";
		this.listBox_0.SelectionMode = SelectionMode.MultiSimple;
		this.listBox_0.Size = new Size(203, 69);
		this.listBox_0.Sorted = true;
		this.listBox_0.TabIndex = 45;
		this.label_15.AutoSize = true;
		this.label_15.Location = new Point(39, 43);
		this.label_15.Name = "labelDivision";
		this.label_15.Size = new Size(87, 13);
		this.label_15.TabIndex = 50;
		this.label_15.Text = "Подразделение";
		this.comboBoxReadOnly_0.BackColor = SystemColors.Control;
		this.comboBoxReadOnly_0.DataBindings.Add(new Binding("SelectedValue", this.class469_0, "tJ_Order.idDivision", true, DataSourceUpdateMode.OnPropertyChanged));
		this.comboBoxReadOnly_0.ForeColor = SystemColors.WindowText;
		this.comboBoxReadOnly_0.FormattingEnabled = true;
		this.comboBoxReadOnly_0.Location = new Point(132, 40);
		this.comboBoxReadOnly_0.Name = "cmbDivision";
		this.comboBoxReadOnly_0.ReadOnly = true;
		this.comboBoxReadOnly_0.ReadOnlyBackColor = SystemColors.Window;
		this.comboBoxReadOnly_0.ReadOnlyForeColor = SystemColors.WindowText;
		this.comboBoxReadOnly_0.Size = new Size(158, 21);
		this.comboBoxReadOnly_0.TabIndex = 49;
		this.label_14.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.label_14.AutoSize = true;
		this.label_14.Location = new Point(561, 17);
		this.label_14.Name = "label4";
		this.label_14.Size = new Size(45, 13);
		this.label_14.TabIndex = 48;
		this.label_14.Text = "Дублер";
		this.textBox_3.Location = new Point(263, 149);
		this.textBox_3.Name = "txtMakerWorker";
		this.textBox_3.ReadOnly = true;
		this.textBox_3.Size = new Size(27, 20);
		this.textBox_3.TabIndex = 47;
		this.textBox_4.Location = new Point(263, 121);
		this.textBox_4.Name = "txtWatchWorker";
		this.textBox_4.ReadOnly = true;
		this.textBox_4.Size = new Size(27, 20);
		this.textBox_4.TabIndex = 46;
		this.textBox_5.Location = new Point(263, 92);
		this.textBox_5.Name = "txtAcceptWorker";
		this.textBox_5.ReadOnly = true;
		this.textBox_5.Size = new Size(27, 20);
		this.textBox_5.TabIndex = 45;
		this.textBox_1.Location = new Point(263, 64);
		this.textBox_1.Name = "txtHeadWorker";
		this.textBox_1.ReadOnly = true;
		this.textBox_1.Size = new Size(27, 20);
		this.textBox_1.TabIndex = 44;
		this.label_12.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.label_12.AutoSize = true;
		this.label_12.Location = new Point(8, 365);
		this.label_12.Name = "label2";
		this.label_12.Size = new Size(386, 13);
		this.label_12.TabIndex = 43;
		this.label_12.Text = "Разрешение на подготовку рабочих мест и на допуск к выполнению работ";
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(876, 543);
		base.Controls.Add(this.splitContainer_0);
		base.KeyPreview = true;
		base.Name = "FormJournalOrderAddEdit";
		this.Text = "FormJournalOrderAddEdit";
		base.FormClosing += this.FormJournalOrderAddEdit_FormClosing;
		base.FormClosed += this.FormJournalOrderAddEdit_FormClosed;
		base.Load += this.FormJournalOrderAddEdit_Load;
		base.KeyDown += this.Form29_KeyDown;
		((ISupportInitialize)this.class469_0).EndInit();
		((ISupportInitialize)this.VaCovZpCew7).EndInit();
		((ISupportInitialize)this.dataGridView_0).EndInit();
		((ISupportInitialize)this.dataGridView_1).EndInit();
		this.toolStrip_0.ResumeLayout(false);
		this.toolStrip_0.PerformLayout();
		this.splitContainer_0.Panel1.ResumeLayout(false);
		this.splitContainer_0.Panel1.PerformLayout();
		this.splitContainer_0.Panel2.ResumeLayout(false);
		this.splitContainer_0.Panel2.PerformLayout();
		this.splitContainer_0.ResumeLayout(false);
		this.panel_0.ResumeLayout(false);
		this.panel_0.PerformLayout();
		this.toolStrip_1.ResumeLayout(false);
		this.toolStrip_1.PerformLayout();
		base.ResumeLayout(false);
	}

	private int int_0;

	private bool bool_0;

	private DateTime dateTime_0;

	private DateTime zyqoOhapCtg;

	[CompilerGenerated]
	private int? nullable_0;

	private bool bool_1;

	private Dictionary<int, string> dictionary_0;

	private Label label_0;

	private TextBox textBox_0;

	private Label label_1;

	private Label label_2;

	private Label label_3;

	private RichTextBox richTextBox_0;

	private Label label_4;

	private ComboBox comboBox_0;

	private Label label_5;

	private Label dfRoOrlkqAm;

	private Label label_6;

	private Label label_7;

	private Label label_8;

	private Label label_9;

	private RichTextBox richTextBox_1;

	private Label label_10;

	private ComboBox comboBox_1;

	private Class469 class469_0;

	private NullableDateTimePicker nullableDateTimePicker_0;

	private NullableDateTimePicker nullableDateTimePicker_1;

	private ComboBox comboBox_2;

	private ComboBox comboBox_3;

	private ComboBox comboBox_4;

	private ComboBox comboBox_5;

	private NullableDateTimePicker nullableDateTimePicker_2;

	private Button button_0;

	private Button button_1;

	private DataGridView VaCovZpCew7;

	private Label label_11;

	private DataGridView dataGridView_0;

	private DataGridView dataGridView_1;

	private ComboBox comboBox_6;

	private NullableDateTimePicker nullableDateTimePicker_3;

	private Button button_2;

	private Button button_3;

	private NullableDateTimePicker nullableDateTimePicker_4;

	private ComboBox comboBox_7;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_3;

	private ToolStrip toolStrip_0;

	private ToolStripButton toolStripButton_0;

	private SplitContainer splitContainer_0;

	private Label label_12;

	private ToolStrip toolStrip_1;

	private ToolStripButton toolStripButton_1;

	private ToolStripButton toolStripButton_2;

	private ToolStripButton toolStripButton_3;

	private ListBox listBox_0;

	private ToolStripButton rwbovvjUheW;

	private TextBox textBox_1;

	private TextBox textBox_2;

	private TextBox textBox_3;

	private TextBox textBox_4;

	private TextBox textBox_5;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_4;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_5;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_6;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_7;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_8;

	private Panel panel_0;

	private Button button_4;

	private NullableDateTimePicker OxGovjdrwUI;

	private MultiColumnComboBox KdqovVhxpIs;

	private Label JjLovUvvoc5;

	private Label label_13;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_9;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_10;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_1;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_11;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_2;

	private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn_0;

	private Label label_14;

	private Label label_15;

	private ComboBoxReadOnly comboBoxReadOnly_0;

	private struct Struct4
	{
		public Struct4(int int_1, string string_1)
		{
			
			this.string_0 = string_1;
			this.int_0 = int_1;
		}

		public override string ToString()
		{
			return this.string_0;
		}

		public string string_0;

		public int int_0;
	}
}
