using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ControlsLbr;
using ControlsLbr.DataGridViewExcelFilter;
using DataSql;
using Documents.Forms.TechnologicalConnection;
using Documents.Properties;
using FormLbr;
using FormLbr.Classes;
using OfficeLB.Word;

internal partial class Form19 : FormBase
{
	internal int method_0()
	{
		return this.int_0;
	}

	internal Form19()
	{
		
		this.int_0 = -1;
		this.int_1 = -1;
		this.int_2 = -1;
		this.int_3 = -1;
		this.dictionary_0 = new Dictionary<string, FileWatcherArgsAddl>();
		this.string_0 = "";
		
		this.method_25();
		this.nullableDateTimePicker_0.Value = DateTime.Now.Date;
	}

	internal Form19(int int_4, int int_5 = -1)
	{
		
		this.int_0 = -1;
		this.int_1 = -1;
		this.int_2 = -1;
		this.int_3 = -1;
		this.dictionary_0 = new Dictionary<string, FileWatcherArgsAddl>();
		this.string_0 = "";
		
		this.method_25();
		this.nullableDateTimePicker_0.Value = DateTime.Now.Date;
		this.int_0 = int_4;
		this.int_1 = int_5;
		this.Text = ((int_4 == -1) ? "Новое письмо" : "Редактирование письма");
	}

	private void method_1()
	{
		Class10.Class14 @class = new Class10.Class14();
		base.SelectSqlData(@class, true, string.Concat(new string[]
		{
			" where id in (",
			1125.ToString(),
			",",
			1218.ToString(),
			") order by name"
		}), null, false, 0);
		this.comboBox_0.DataSource = @class;
		this.comboBox_0.DisplayMember = "Name";
		this.comboBox_0.ValueMember = "id";
		DataTable dataTable = new DataTable("vWorkerGroup");
		dataTable.Columns.Add("id", typeof(int));
		dataTable.Columns.Add("fio", typeof(string));
		base.SelectSqlData(dataTable, true, "where ParentKey = ';GroupWorker;PerformerTU;' and dateEnd is null order by fio", null, false, 0);
		this.comboBox_1.DataSource = dataTable;
		this.comboBox_1.DisplayMember = "fio";
		this.comboBox_1.ValueMember = "id";
		this.comboBox_1.SelectedIndex = -1;
	}

	private void method_2()
	{
		if (this.int_1 > 0)
		{
			DataTable dataTable = base.SelectSqlData("tTC_Doc", true, "where id = " + this.int_1.ToString());
			if (dataTable.Rows.Count > 0 && Convert.ToInt32(dataTable.Rows[0]["TypeDoc"]) == 1123)
			{
				this.radioButton_1.Checked = true;
				this.comboBox_2.SelectedValue = this.int_1;
				return;
			}
		}
		this.method_3();
	}

	private void method_3()
	{
		string text = "select  r.id, r.numin, r.datein,  isnull(r.numIn, '') + ' от ' + isnull(convert( varchar(10),r.DateIn, 104), '') as numDateIn from ttc_request r ";
		text += " order by numIn, dateIn ";
		DataTable dataTable = new DataTable();
		SqlDataConnect sqlDataConnect = new SqlDataConnect();
		if (sqlDataConnect.OpenConnection(this.SqlSettings))
		{
			try
			{
				new SqlDataAdapter(text, sqlDataConnect.Connection).Fill(dataTable);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, ex.Source);
			}
		}
		this.comboBox_2.SelectedValueChanged -= this.comboBox_2_SelectedValueChanged;
		BindingSource bindingSource = new BindingSource();
		bindingSource.DataSource = dataTable;
		bindingSource.Filter = "numIn is not null";
		bindingSource.Sort = "numIn, dateIn";
		this.comboBox_2.DataSource = bindingSource;
		this.comboBox_2.DisplayMember = "numDateIn";
		this.comboBox_2.ValueMember = "id";
		this.comboBox_2.SelectedValueChanged += this.comboBox_2_SelectedValueChanged;
		if (this.int_1 != -1)
		{
			this.comboBox_2.SelectedValue = this.int_1;
			return;
		}
		this.comboBox_2.SelectedIndex = -1;
	}

	private void method_4()
	{
		string text = "select  d.id, d.numdoc, d.datedoc,  isnull(d.numdoc, '') + ' от ' + isnull(convert( varchar(10),d.Datedoc, 104), '') as numDatedoc  from ttc_doc d  where typeDoc = " + 1123.ToString();
		text += " order by numDoc, dateDoc ";
		DataTable dataTable = new DataTable();
		SqlDataConnect sqlDataConnect = new SqlDataConnect();
		if (sqlDataConnect.OpenConnection(this.SqlSettings))
		{
			try
			{
				new SqlDataAdapter(text, sqlDataConnect.Connection).Fill(dataTable);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, ex.Source);
			}
		}
		this.comboBox_2.SelectedValueChanged -= this.comboBox_2_SelectedValueChanged;
		BindingSource bindingSource = new BindingSource();
		bindingSource.DataSource = dataTable;
		bindingSource.Sort = "numDoc, dateDoc";
		this.comboBox_2.DataSource = bindingSource;
		this.comboBox_2.DisplayMember = "numDateDoc";
		this.comboBox_2.ValueMember = "id";
		this.comboBox_2.SelectedValueChanged += this.comboBox_2_SelectedValueChanged;
		if (this.int_1 != -1)
		{
			this.comboBox_2.SelectedValue = this.int_1;
			return;
		}
		this.comboBox_2.SelectedIndex = -1;
	}

	private void method_5(int int_4)
	{
		Class10.Class12 @class = new Class10.Class12();
		base.SelectSqlData(@class, true, " where id = " + int_4.ToString(), null, false, 0);
		if (@class.Rows.Count <= 0)
		{
			this.int_3 = -1;
			this.int_2 = -1;
			this.textBox_2.Text = (this.textBox_3.Text = (this.txtAbnObj.Text = ""));
			this.class10_0.vTC_RequestHistory.Clear();
			return;
		}
		int num = Convert.ToInt32(@class.Rows[0]["TypeDoc"]);
		int num2 = -1;
		if (num != 1113)
		{
			if (num != 1123)
			{
				if (num != 1203)
				{
					goto IL_F9;
				}
			}
			else
			{
				Class10.Class31 class2 = new Class10.Class31();
				base.SelectSqlData(class2, true, " where id = " + int_4.ToString(), null, false, 0);
				if (class2.Rows.Count > 0 && class2.Rows[0]["idRequest"] != DBNull.Value)
				{
					num2 = Convert.ToInt32(class2.Rows[0]["idRequest"]);
					goto IL_F9;
				}
				goto IL_F9;
			}
		}
		num2 = int_4;
		IL_F9:
		if (num2 != -1)
		{
			Class10.Class12 class3 = new Class10.Class12();
			base.SelectSqlData(class3, true, " where id = " + num2.ToString(), null, false, 0);
			if (class3.Rows.Count > 0 && class3.Rows[0]["idParent"] != DBNull.Value)
			{
				num2 = Convert.ToInt32(class3.Rows[0]["idParent"]);
			}
			Class10.Class13 class4 = new Class10.Class13();
			base.SelectSqlData(class4, true, " where id = " + num2.ToString(), null, false, 0);
			if (class4.Rows.Count > 0 && class4.Rows[0]["idAbn"] != DBNull.Value)
			{
				this.int_2 = Convert.ToInt32(class4.Rows[0]["idAbn"]);
				Class10.Class11 class5 = new Class10.Class11();
				base.SelectSqlData(class5, true, "where id = " + this.int_2.ToString(), null, false, 0);
				if (class5.Rows.Count > 0)
				{
					this.textBox_2.Text = class5.Rows[0]["name"].ToString();
					int num3 = Convert.ToInt32(class5.Rows[0]["typeAbn"]);
					if (class4.Rows[0]["idAbnObj"] != DBNull.Value)
					{
						this.int_3 = Convert.ToInt32(class4.Rows[0]["idAbnObj"]);
						Class10.Class16 class6 = new Class10.Class16();
						DataColumn dataColumn = new DataColumn("AddressFL");
						dataColumn.Expression = "street + ', д. ' + houseall + ', кв. ' + name";
						class6.Columns.Add(dataColumn);
						dataColumn = new DataColumn("AddressUL");
						dataColumn.Expression = "street + ', д. ' + houseall";
						class6.Columns.Add(dataColumn);
						base.SelectSqlData(class6, true, "where id = " + this.int_3.ToString() + " order by name", null, false, 0);
						if (class6.Rows.Count > 0)
						{
							if (num3 != 206 && num3 != 253)
							{
								if (num3 != 1037)
								{
									this.txtAbnObj.Text = class6.Rows[0]["name"].ToString();
									this.textBox_3.Text = class6.Rows[0]["AddressUL"].ToString();
									goto IL_480;
								}
							}
							this.txtAbnObj.Text = class6.Rows[0]["AddressFL"].ToString();
							this.textBox_3.Text = class6.Rows[0]["AddressFL"].ToString();
						}
						else
						{
							this.textBox_3.Text = (this.txtAbnObj.Text = "");
						}
					}
					else
					{
						this.textBox_3.Text = (this.txtAbnObj.Text = "");
					}
				}
				else
				{
					this.textBox_2.Text = (this.textBox_3.Text = (this.txtAbnObj.Text = ""));
				}
			}
			IL_480:
			base.SelectSqlData(this.class10_0, this.class10_0.vTC_RequestHistory, true, string.Concat(new string[]
			{
				"where id = ",
				num2.ToString(),
				" or IdParent = ",
				num2.ToString(),
				" order by dateDoc"
			}));
			return;
		}
		this.int_3 = -1;
		this.int_2 = -1;
		this.textBox_2.Text = (this.textBox_3.Text = (this.txtAbnObj.Text = ""));
		this.class10_0.vTC_RequestHistory.Clear();
	}

	private void method_6(object object_0, object object_1)
	{
		if (object_0 != DBNull.Value)
		{
			object_0 = Convert.ToInt32(object_0);
			Class10.Class11 @class = new Class10.Class11();
			base.SelectSqlData(@class, true, "where id = " + object_0.ToString(), null, false, 0);
			if (@class.Rows.Count > 0)
			{
				this.textBox_2.Text = @class.Rows[0]["name"].ToString();
				int num = Convert.ToInt32(@class.Rows[0]["typeAbn"]);
				if (object_1 == DBNull.Value)
				{
					this.textBox_3.Text = (this.txtAbnObj.Text = "");
					return;
				}
				object_1 = Convert.ToInt32(object_1);
				Class10.Class16 class2 = new Class10.Class16();
				DataColumn dataColumn = new DataColumn("AddressFL");
				dataColumn.Expression = "street + ', д. ' + houseall + ', кв. ' + name";
				class2.Columns.Add(dataColumn);
				dataColumn = new DataColumn("AddressUL");
				dataColumn.Expression = "street + ', д. ' + houseall";
				class2.Columns.Add(dataColumn);
				base.SelectSqlData(class2, true, "where id = " + object_1.ToString() + " order by name", null, false, 0);
				if (class2.Rows.Count > 0)
				{
					if (num != 206 && num != 253)
					{
						if (num != 1037)
						{
							this.txtAbnObj.Text = class2.Rows[0]["name"].ToString();
							this.textBox_3.Text = class2.Rows[0]["AddressUL"].ToString();
							return;
						}
					}
					this.textBox_3.Text = (this.txtAbnObj.Text = class2.Rows[0]["AddressFL"].ToString());
					return;
				}
				this.textBox_3.Text = (this.txtAbnObj.Text = "");
				return;
			}
			else
			{
				this.textBox_2.Text = (this.textBox_3.Text = (this.txtAbnObj.Text = ""));
			}
		}
	}

	private void radioButton_2_CheckedChanged(object sender, EventArgs e)
	{
		if (this.radioButton_2.Checked)
		{
			this.label_6.Text = "Номер и дата вх. заявки";
			this.comboBox_2.Visible = true;
			this.toolStrip_0.Visible = false;
			this.method_3();
			this.bool_0 = true;
		}
	}

	private void radioButton_1_CheckedChanged(object sender, EventArgs e)
	{
		if (this.radioButton_1.Checked)
		{
			this.label_6.Text = "Номер и дата ТУ";
			this.comboBox_2.Visible = true;
			this.toolStrip_0.Visible = false;
			this.method_4();
			this.bool_0 = true;
		}
	}

	private void radioButton_0_CheckedChanged(object sender, EventArgs e)
	{
		if (this.radioButton_0.Checked)
		{
			this.label_6.Text = "Выбор контрагента";
			this.comboBox_2.Visible = false;
			this.toolStrip_0.Visible = true;
			this.bool_0 = true;
		}
	}

	private void method_7()
	{
		DataRow dataRow = this.class10_0.tTC_Doc.NewRow();
		dataRow["TypeDoc"] = 1218;
		this.class10_0.tTC_Doc.Rows.Add(dataRow);
		DataRow dataRow2 = this.class10_0.tTC_Mail.NewRow();
		dataRow2["id"] = this.int_0;
		this.class10_0.tTC_Mail.Rows.Add(dataRow2);
	}

	private void Form19_Load(object sender, EventArgs e)
	{
		this.method_1();
		this.method_2();
		this.NysQemQnbN();
		if (this.int_0 == -1)
		{
			this.method_7();
			DataRow dataRow = this.class10_0.tTC_DocOut.NewRow();
			dataRow["idDoc"] = this.int_1;
			dataRow["idDocOut"] = this.class10_0.tTC_Doc.Rows[0]["id"];
			this.class10_0.tTC_DocOut.Rows.Add(dataRow);
		}
		else
		{
			base.SelectSqlData(this.class10_0, this.class10_0.tTC_Doc, true, "where id = " + this.int_0.ToString());
			base.SelectSqlData(this.class10_0, this.class10_0.tTC_Mail, true, "where id = " + this.int_0.ToString());
			if (this.class10_0.tTC_Mail.Rows.Count == 0)
			{
				DataRow dataRow2 = this.class10_0.tTC_Mail.NewRow();
				dataRow2["id"] = this.int_0;
				this.class10_0.tTC_Mail.Rows.Add(dataRow2);
			}
			base.SelectSqlData(this.class10_0, this.class10_0.tTC_DocOut, true, "where idDocOut = " + this.int_0.ToString());
			if (this.class10_0.tTC_DocOut.Rows.Count > 0)
			{
				Class10.Class12 @class = new Class10.Class12();
				base.SelectSqlData(@class, true, "where id = " + this.class10_0.tTC_DocOut.Rows[0]["idDoc"].ToString(), null, false, 0);
				if (@class.Rows.Count > 0)
				{
					int num = Convert.ToInt32(@class.Rows[0]["typeDoc"]);
					if (num == 1113)
					{
						this.radioButton_2.Checked = true;
						this.comboBox_2.SelectedValue = Convert.ToInt32(@class.Rows[0]["id"]);
					}
					if (num == 1123)
					{
						this.radioButton_1.Checked = true;
						this.comboBox_2.SelectedValue = Convert.ToInt32(@class.Rows[0]["id"]);
					}
				}
			}
			else
			{
				this.radioButton_0.Checked = true;
				this.method_6(this.class10_0.tTC_Mail.Rows[0]["idAbn"], this.class10_0.tTC_Mail.Rows[0]["idAbnObj"]);
			}
			this.method_23(this.int_0);
		}
		this.bool_0 = false;
	}

	private void comboBox_2_SelectedValueChanged(object sender, EventArgs e)
	{
		if (this.comboBox_2.SelectedValue != null)
		{
			if (this.comboBox_2.SelectedIndex != -1)
			{
				this.int_1 = Convert.ToInt32(this.comboBox_2.SelectedValue);
				this.method_5(this.int_1);
				return;
			}
		}
		this.textBox_3.Text = (this.txtAbnObj.Text = (this.textBox_2.Text = ""));
		this.int_1 = -1;
	}

	private bool method_8()
	{
		if (this.nullableDateTimePicker_0.Value != null)
		{
			if (this.nullableDateTimePicker_0.Value != DBNull.Value)
			{
				if (this.comboBox_0.SelectedIndex < 0)
				{
					MessageBox.Show("Не выбран тип документа");
					return false;
				}
				if (this.comboBox_1.SelectedIndex < 0)
				{
					MessageBox.Show("Не выбран исполнитель");
					return false;
				}
				if (this.comboBox_2.SelectedIndex < 0)
				{
					if (this.radioButton_2.Checked)
					{
						MessageBox.Show("Не выбрана заявка");
						return false;
					}
					if (this.radioButton_2.Checked)
					{
						MessageBox.Show("Не выбрано тех условие");
						return false;
					}
				}
				return true;
			}
		}
		MessageBox.Show("Не выбрана дата письма");
		return false;
	}

	private bool method_9()
	{
		if (!this.method_8())
		{
			return false;
		}
		this.class10_0.tTC_Doc.Rows[0].EndEdit();
		if (this.int_0 == -1)
		{
			this.int_0 = base.InsertSqlDataOneRow(this.class10_0, this.class10_0.tTC_Doc);
			if (this.int_0 == -1)
			{
				return false;
			}
			base.SelectSqlData(this.class10_0.tTC_Doc, true, " where id = " + this.int_0.ToString(), null, false, 0);
		}
		else if (!base.UpdateSqlData(this.class10_0, this.class10_0.tTC_Doc))
		{
			return false;
		}
		if (!this.method_10())
		{
			return false;
		}
		if (!this.method_11())
		{
			return false;
		}
		if (!this.method_24())
		{
			return false;
		}
		this.bool_0 = false;
		MessageBox.Show("Данные успешно сохранены.");
		return true;
	}

	private bool method_10()
	{
		if (this.radioButton_0.Checked)
		{
			if (this.class10_0.tTC_DocOut.Rows.Count > 0)
			{
				this.class10_0.tTC_DocOut.Rows[0].Delete();
				if (!base.DeleteSqlData(this.class10_0, this.class10_0.tTC_DocOut))
				{
					return false;
				}
				this.class10_0.tTC_DocOut.Clear();
			}
		}
		else if (this.class10_0.tTC_DocOut.Rows.Count > 0)
		{
			this.class10_0.tTC_DocOut.Rows[0]["idDoc"] = this.int_1;
			this.class10_0.tTC_DocOut.Rows[0]["idDocOut"] = this.int_0;
			this.class10_0.tTC_DocOut.Rows[0].EndEdit();
			if (this.class10_0.tTC_DocOut.Rows[0].RowState == DataRowState.Added)
			{
				int num = base.InsertSqlDataOneRow(this.class10_0, this.class10_0.tTC_DocOut);
				if (num == -1)
				{
					return false;
				}
				base.SelectSqlData(this.class10_0.tTC_DocOut, true, "where id = " + num.ToString(), null, false, 0);
			}
			else if (!base.UpdateSqlData(this.class10_0, this.class10_0.tTC_DocOut))
			{
				return false;
			}
		}
		else
		{
			DataRow dataRow = this.class10_0.tTC_DocOut.NewRow();
			dataRow["idDoc"] = this.int_1;
			dataRow["idDocOut"] = this.int_0;
			this.class10_0.tTC_DocOut.Rows.Add(dataRow);
			int num2 = base.InsertSqlDataOneRow(this.class10_0, this.class10_0.tTC_DocOut);
			if (num2 == -1)
			{
				return false;
			}
			base.SelectSqlData(this.class10_0.tTC_DocOut, true, "where id = " + num2.ToString(), null, false, 0);
		}
		return true;
	}

	private bool method_11()
	{
		if (this.radioButton_0.Checked && this.int_2 != -1)
		{
			this.class10_0.tTC_Mail.Rows[0]["idAbn"] = this.int_2;
			if (this.int_3 == -1)
			{
				this.class10_0.tTC_Mail.Rows[0]["idAbnObj"] = DBNull.Value;
			}
			else
			{
				this.class10_0.tTC_Mail.Rows[0]["idAbnObj"] = this.int_3;
			}
		}
		else
		{
			this.class10_0.tTC_Mail.Rows[0]["idAbn"] = DBNull.Value;
			this.class10_0.tTC_Mail.Rows[0]["idAbnObj"] = DBNull.Value;
		}
		this.class10_0.tTC_Mail.Rows[0]["id"] = this.int_0;
		this.class10_0.tTC_Mail.Rows[0].EndEdit();
		return base.InsertSqlData(this.class10_0, this.class10_0.tTC_Mail) && base.UpdateSqlData(this.class10_0, this.class10_0.tTC_Mail);
	}

	private void Form19_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (this.bool_0 && MessageBox.Show("Сохранить внесенные изменения?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes && !this.method_9())
		{
			e.Cancel = true;
			return;
		}
	}

	private void dataGridViewExcelFilter_0_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
	{
		if (e.RowIndex >= 0 && Convert.ToInt32(this.dataGridViewExcelFilter_0[this.dataGridViewTextBoxColumn_4.Name, e.RowIndex].Value) == 1113)
		{
			e.CellStyle.Font = new System.Drawing.Font(e.CellStyle.Font, FontStyle.Bold);
			e.CellStyle.BackColor = Color.LightGray;
		}
	}

	private void dataGridViewExcelFilter_0_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
	{
		this.dataGridViewExcelFilter_0.AutoResizeRow(e.RowIndex);
	}

	private void toolStripButton_0_Click(object sender, EventArgs e)
	{
		FormTechConnectionAddAbn formTechConnectionAddAbn = new FormTechConnectionAddAbn(this.int_2, this.int_3, true);
		formTechConnectionAddAbn.ShowForm += this.method_13;
		formTechConnectionAddAbn.SqlSettings = this.SqlSettings;
		formTechConnectionAddAbn.MdiParent = base.MdiParent;
		formTechConnectionAddAbn.FormClosed += this.method_12;
		formTechConnectionAddAbn.Show();
	}

	private void method_12(object sender, FormClosedEventArgs e)
	{
		FormTechConnectionAddAbn formTechConnectionAddAbn = (FormTechConnectionAddAbn)sender;
		if (formTechConnectionAddAbn.DialogResult == DialogResult.OK)
		{
			this.textBox_2.Text = formTechConnectionAddAbn.AbnName;
			this.txtAbnObj.Text = formTechConnectionAddAbn.GetNameAbnObj();
			this.int_2 = formTechConnectionAddAbn.IdAbn;
			this.int_3 = formTechConnectionAddAbn.GetIdAbnObj();
			Class10.Class16 @class = new Class10.Class16();
			DataColumn dataColumn = new DataColumn("AddressFL");
			dataColumn.Expression = "street + ', д. ' + houseall + ', кв. ' + name";
			@class.Columns.Add(dataColumn);
			dataColumn = new DataColumn("AddressUL");
			dataColumn.Expression = "street + ', д. ' + houseall";
			@class.Columns.Add(dataColumn);
			base.SelectSqlData(@class, true, "where id = " + this.int_3.ToString() + " order by name", null, false, 0);
			if (@class.Rows.Count > 0)
			{
				this.textBox_3.Text = @class.Rows[0]["AddressUL"].ToString();
			}
			else
			{
				this.textBox_3.Text = "";
			}
			this.bool_0 = true;
		}
	}

	private FormBase method_13(object object_0, ShowFormEventArgs showFormEventArgs_0)
	{
		return this.OnShowForm(showFormEventArgs_0);
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		if (this.method_9())
		{
			base.Close();
		}
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		base.Close();
	}

	private void textBox_0_TextChanged(object sender, EventArgs e)
	{
		this.bool_0 = true;
	}

	private void nullableDateTimePicker_0_ValueChanged(object sender, EventArgs e)
	{
		this.bool_0 = true;
	}

	private void comboBox_1_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.bool_0 = true;
	}

	private void comboBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.bool_0 = true;
	}

	private void textBox_1_TextChanged(object sender, EventArgs e)
	{
		this.bool_0 = true;
	}

	private void toolStripMenuItem_2_Click(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Multiselect = true;
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			foreach (string string_ in openFileDialog.FileNames)
			{
				if (!string.IsNullOrEmpty(this.method_17(string_, null, null)))
				{
					this.bool_0 = true;
				}
			}
		}
	}

	private void method_14(object sender, EventArgs e)
	{
		int num = (int)((ToolStripMenuItem)sender).Tag;
		string text;
		byte[] array;
		this.method_18(num, out text, out array);
		string extension = new System.IO.FileInfo(text).Extension;
		uint num2 = PrivateImplementationDetails.ComputeStringHash(extension);
		if (num2 <= 1719562636u)
		{
			if (num2 <= 502676545u)
			{
				if (num2 != 469959950u)
				{
					if (num2 != 502676545u)
					{
						goto IL_162;
					}
					if (!(extension == ".xltx"))
					{
						goto IL_162;
					}
				}
				else
				{
					if (!(extension == ".xlsx"))
					{
						goto IL_162;
					}
					goto IL_162;
				}
			}
			else if (num2 != 1616086803u)
			{
				if (num2 != 1719562636u)
				{
					goto IL_162;
				}
				if (!(extension == ".dotx"))
				{
					goto IL_162;
				}
				goto IL_13B;
			}
			else
			{
				if (!(extension == ".docx"))
				{
					goto IL_162;
				}
				goto IL_162;
			}
		}
		else if (num2 <= 3182675714u)
		{
			if (num2 != 3098787619u)
			{
				if (num2 != 3182675714u)
				{
					goto IL_162;
				}
				if (!(extension == ".xls"))
				{
					goto IL_162;
				}
				goto IL_162;
			}
			else if (!(extension == ".xlt"))
			{
				goto IL_162;
			}
		}
		else if (num2 != 3238515961u)
		{
			if (num2 != 3523735484u)
			{
				goto IL_162;
			}
			if (extension == ".dot")
			{
				goto IL_13B;
			}
			goto IL_162;
		}
		else
		{
			if (extension == ".doc")
			{
				goto IL_162;
			}
			goto IL_162;
		}
		text = text.Replace(extension, extension.Replace("t", "s"));
		goto IL_162;
		IL_13B:
		text = text.Replace(extension, extension.Replace("t", "c"));
		IL_162:
		string text2 = this.method_19();
		string newFileNameIsExists = FileBinary.GetNewFileNameIsExists(text2, text, false);
		string text3 = this.method_17(text, new int?(num), array);
		if (!string.IsNullOrEmpty(text3))
		{
			this.bool_0 = true;
			FileBinary fileBinary = new FileBinary(array, newFileNameIsExists, DateTime.Now);
			fileBinary.SaveToDisk(text2);
			extension = new System.IO.FileInfo(text).Extension;
			if (!(extension == ".doc") && !(extension == ".docx"))
			{
				Process.Start(text2 + "\\" + fileBinary.Name);
			}
			else if (!this.method_15(text2 + "\\" + fileBinary.Name))
			{
				Process.Start(text2 + "\\" + fileBinary.Name);
			}
			if (this.dictionary_0.ContainsKey(text3))
			{
				FileWatcher fileWatcher = new FileWatcher(text2, fileBinary.Name);
				fileWatcher.AnyChanged += this.method_20;
				fileWatcher.Start();
				this.dictionary_0[text3].TempName = newFileNameIsExists;
				this.dictionary_0[text3].Watcher = fileWatcher;
				this.dictionary_0[text3].OpenState = FileOpenState.Editing;
				return;
			}
			MessageBox.Show("Что то пошло не так");
		}
	}

	private bool method_15(string string_1)
	{
		bool result;
		try
		{
			OfficeLB.Word.Application application = new OfficeLB.Word.Application();
			Documents documents = application.Documents;
			documents.Open(string_1);
			application.Visible = true;
			Bookmarks bookmarks = documents[1].Range.Bookmarks;
			if (bookmarks.Exists("NumDoc"))
			{
				bookmarks["NumDoc"].Range.Text = this.textBox_0.Text;
			}
			if (bookmarks.Exists("DateDoc") && this.nullableDateTimePicker_0.Value != null && this.nullableDateTimePicker_0.Value != DBNull.Value)
			{
				bookmarks["DateDoc"].Range.Text = Convert.ToDateTime(this.nullableDateTimePicker_0.Value).ToString("dd MMMM yyyy") + " г.";
			}
			if (bookmarks.Exists("NameAbn"))
			{
				bookmarks["NameAbn"].Range.Text = this.textBox_2.Text;
			}
			if (bookmarks.Exists("AbnObj"))
			{
				bookmarks["AbnObj"].Range.Text = this.txtAbnObj.Text;
			}
			if (bookmarks.Exists("AbnObjAddress"))
			{
				bookmarks["AbnObjAddress"].Range.Text = this.textBox_3.Text;
			}
			return true;
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, ex.Source);
			result = false;
		}
		return result;
	}

	private void toolStripMenuItem_3_Click(object sender, EventArgs e)
	{
		this.method_22(true);
	}

	private void toolStripMenuItem_4_Click(object sender, EventArgs e)
	{
		this.method_22(false);
	}

	private void toolStripMenuItem_5_Click(object sender, EventArgs e)
	{
		if (this.FcwqEnOhCr.Current != null && MessageBox.Show("Вы действительно хотите удалить выбранный файл?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
		{
			Class10.Class88 @class = (Class10.Class88)((DataRowView)this.FcwqEnOhCr.Current).Row;
			string fileName = @class.FileName;
			if (this.dictionary_0.ContainsKey(fileName))
			{
				if (this.dictionary_0[fileName].Watcher != null)
				{
					this.dictionary_0[fileName].Watcher.AnyChanged -= this.method_20;
					this.dictionary_0[fileName].Watcher.Stop();
				}
				this.dictionary_0.Remove(fileName);
			}
			@class.Delete();
			this.bool_0 = true;
		}
	}

	private void toolStripMenuItem_6_Click(object sender, EventArgs e)
	{
		if (this.dataGridViewExcelFilter_1.CurrentRow != null)
		{
			this.string_0 = this.dataGridViewExcelFilter_1.CurrentRow.Cells[this.dataGridViewFilterTextBoxColumn_0.Name].Value.ToString();
			this.dataGridViewExcelFilter_1.CurrentCell = this.dataGridViewExcelFilter_1.CurrentRow.Cells[this.dataGridViewFilterTextBoxColumn_0.Name];
			this.dataGridViewExcelFilter_1.CurrentCell.Value = Path.GetFileNameWithoutExtension(this.string_0);
			this.dataGridViewExcelFilter_1.ReadOnly = false;
			this.dataGridViewFilterTextBoxColumn_0.ReadOnly = false;
			this.dataGridViewExcelFilter_1.BeginEdit(true);
		}
	}

	private void toolStripMenuItem_7_Click(object sender, EventArgs e)
	{
		if (this.FcwqEnOhCr.Current != null)
		{
			Class10.Class88 @class = (Class10.Class88)((DataRowView)this.FcwqEnOhCr.Current).Row;
			if (@class["File"] == DBNull.Value)
			{
				try
				{
					using (SqlConnection sqlConnection = new SqlConnection(this.SqlSettings.GetConnectionString()))
					{
						sqlConnection.Open();
						SqlDataReader sqlDataReader = new SqlCommand("SELECT [File] FROM tTC_DocFile WHERE id = " + @class["id"].ToString(), sqlConnection).ExecuteReader();
						while (sqlDataReader.Read())
						{
							@class["File"] = sqlDataReader["File"];
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, ex.Source);
				}
			}
			byte[] file = @class.File;
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.FileName = @class.FileName;
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.method_16(saveFileDialog.FileName, file);
			}
		}
	}

	public bool method_16(string string_1, byte[] byte_0)
	{
		try
		{
			FileStream fileStream = new FileStream(string_1, FileMode.Create, FileAccess.Write);
			fileStream.Write(byte_0, 0, byte_0.Length);
			fileStream.Close();
			return true;
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, ex.Source);
			ex.ToString();
		}
		return false;
	}

	private void dataGridViewExcelFilter_1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
	{
		this.toolStripMenuItem_4_Click(sender, e);
	}

	private void dataGridViewExcelFilter_1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
	{
		this.dataGridViewExcelFilter_1.ReadOnly = true;
		this.dataGridViewFilterTextBoxColumn_0.ReadOnly = true;
		string text = this.dataGridViewExcelFilter_1[e.ColumnIndex, e.RowIndex].Value.ToString() + Path.GetExtension(this.string_0);
		if (text == this.string_0)
		{
			return;
		}
		if (this.dictionary_0.ContainsKey(this.string_0))
		{
			FileWatcherArgsAddl fileWatcherArgsAddl = this.dictionary_0[this.string_0];
			fileWatcherArgsAddl.OriginalName = text;
			this.dictionary_0.Remove(this.string_0);
			this.dictionary_0.Add(text, fileWatcherArgsAddl);
			this.dataGridViewExcelFilter_1[e.ColumnIndex, e.RowIndex].Value = text;
			this.bool_0 = true;
		}
		this.string_0 = null;
	}

	private void dataGridViewExcelFilter_1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
	{
		if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Button == MouseButtons.Right)
		{
			this.dataGridViewExcelFilter_1.ClearSelection();
			this.dataGridViewExcelFilter_1.Rows[e.RowIndex].Selected = true;
			this.dataGridViewExcelFilter_1.CurrentCell = this.dataGridViewExcelFilter_1[e.ColumnIndex, e.RowIndex];
			Rectangle cellDisplayRectangle = this.dataGridViewExcelFilter_1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
			this.contextMenuStrip_0.Show((Control)sender, cellDisplayRectangle.Left + e.X, cellDisplayRectangle.Top + e.Y);
		}
	}

	private void dataGridViewExcelFilter_1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
	{
		if (e.ColumnIndex == 1 && e.RowIndex >= 0 && !string.IsNullOrEmpty(this.string_0))
		{
			string text = e.FormattedValue + Path.GetExtension(this.string_0);
			if (text == this.string_0)
			{
				return;
			}
			if (this.dictionary_0.ContainsKey(text))
			{
				MessageBox.Show("Файл с таким именем уже существует", "");
				e.Cancel = true;
			}
		}
	}

	private void dataGridViewExcelFilter_1_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
	{
		if (((DataGridView)sender).RowCount > 0 && this.dataGridViewExcelFilter_1[this.dataGridViewFilterTextBoxColumn_0.Name, e.RowIndex].Value != null)
		{
			if (e.ColumnIndex == this.dataGridViewExcelFilter_1.Columns[this.dataGridViewImageColumnNotNull_0.Name].Index)
			{
				if (!string.IsNullOrEmpty(Path.GetFileName(this.dataGridViewExcelFilter_1[this.dataGridViewFilterTextBoxColumn_0.Name, e.RowIndex].Value.ToString())))
				{
					e.Value = Path.GetFileName(this.dataGridViewExcelFilter_1[this.dataGridViewFilterTextBoxColumn_0.Name, e.RowIndex].Value.ToString());
				}
				else
				{
					e.Value = this.dataGridViewExcelFilter_1[this.dataGridViewFilterTextBoxColumn_0.Name, e.RowIndex].Value.ToString();
				}
			}
			if (e.ColumnIndex == this.dataGridViewExcelFilter_1.Columns[this.dataGridViewImageColumnNotNull_0.Name].Index)
			{
				Icon icon = FormLbr.Classes.FileInfo.IconOfFile(this.dataGridViewExcelFilter_1[this.dataGridViewFilterTextBoxColumn_0.Name, e.RowIndex].Value.ToString());
				if (icon != null)
				{
					e.Value = icon.ToBitmap();
				}
			}
		}
	}

	private string method_17(string string_1, int? nullable_0 = null, byte[] byte_0 = null)
	{
		string fileName = Path.GetFileName(string_1);
		bool flag = true;
		while (this.dictionary_0.ContainsKey(fileName))
		{
			if (MessageBox.Show("Файл с именем " + fileName + " уже существует. Изменить имя файла на другое?", "Внимание.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				FormNewFileName formNewFileName = new FormNewFileName(fileName);
				if (formNewFileName.ShowDialog() == DialogResult.OK)
				{
					fileName = formNewFileName.FileName;
				}
			}
			else
			{
				flag = false;
				IL_57:
				if (!flag)
				{
					return null;
				}
				FileWatcherArgsAddl value = new FileWatcherArgsAddl(nullable_0, fileName, null, FileOpenState.None);
				this.dictionary_0.Add(fileName, value);
				Class10.Class88 @class = this.class10_0.tTC_DocFile.method_5();
				@class.idDoc = -1;
				@class.FileName = fileName;
				if (byte_0 == null)
				{
					FileBinary fileBinary = new FileBinary(string_1);
					@class.File = fileBinary.ByteArray;
					@class.dateChange = fileBinary.LastChanged;
				}
				else
				{
					@class.File = byte_0;
					@class.dateChange = DateTime.Now;
				}
				if (nullable_0 != null)
				{
					@class.idTemplate = nullable_0.Value;
				}
				this.class10_0.tTC_DocFile.method_0(@class);
				return fileName;
			}
		}
		goto IL_57;
	}

	private void NysQemQnbN()
	{
		foreach (object obj in new SqlDataCommand(this.SqlSettings).SelectSqlData(" SELECT doc.id, doc.FileName  FROM tR_DocTemplate AS doc  INNER JOIN [tR_Classifier] AS c ON doc.idTypeDoc = c.id  WHERE c.ParentKey = ';TypeDoc;tR_DocTemplate;' AND c.Deleted = ((0)) AND c.isGroup = ((0)) AND c.Value = 2 and doc.deleted = 0").Rows)
		{
			DataRow dataRow = (DataRow)obj;
			ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
			toolStripMenuItem.Text = dataRow["FileName"].ToString();
			toolStripMenuItem.Tag = dataRow["id"];
			toolStripMenuItem.Click += this.method_14;
			this.toolStripDropDownButton_0.DropDownItems.Add(toolStripMenuItem);
			ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem();
			toolStripMenuItem2.Text = dataRow["FileName"].ToString();
			toolStripMenuItem2.Tag = dataRow["id"];
			toolStripMenuItem2.Click += this.method_14;
			this.toolStripMenuItem_1.DropDownItems.Add(toolStripMenuItem2);
		}
	}

	public void method_18(int int_4, out string string_1, out byte[] byte_0)
	{
		string_1 = "";
		byte_0 = null;
		string cmdText = "SELECT FileName, FileData FROM tR_DocTemplate WHERE id = @idTemplate";
		using (SqlConnection sqlConnection = new SqlConnection(this.SqlSettings.GetConnectionString()))
		{
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			sqlCommand.Parameters.Add("@idTemplate", SqlDbType.Int);
			sqlCommand.Parameters["@idTemplate"].Value = int_4;
			try
			{
				sqlConnection.Open();
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				while (sqlDataReader.Read())
				{
					string_1 = (string)sqlDataReader.GetValue(0);
					byte_0 = (byte[])sqlDataReader.GetValue(1);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, ex.Source);
			}
		}
	}

	private string method_19()
	{
		string text = this.textBox_0.Text;
		if (string.IsNullOrEmpty(text))
		{
			text = "tmp";
		}
		string text2 = Path.GetTempPath() + "\\" + text + "\\";
		if (!Directory.Exists(text2))
		{
			Directory.CreateDirectory(text2);
		}
		return text2;
	}

	private void method_20(object sender, FileSystemEventArgs e)
	{
		IEnumerable<KeyValuePair<string, FileWatcherArgsAddl>> fwargs = from item in this.dictionary_0
		where item.Value.TempName == e.Name
		select item;
		if (fwargs.Count<KeyValuePair<string, FileWatcherArgsAddl>>() > 0)
		{
			FileBinary fileBinary = new FileBinary(e.FullPath);
			EnumerableRowCollection<Class10.Class88> source = from rowFiles in this.class10_0.tTC_DocFile
			where rowFiles.RowState != DataRowState.Deleted && rowFiles.FileName == fwargs.First<KeyValuePair<string, FileWatcherArgsAddl>>().Value.OriginalName
			select rowFiles;
			if (source.Count<Class10.Class88>() == 0)
			{
				Class10.Class88 @class = this.class10_0.tTC_DocFile.method_5();
				@class.idDoc = this.int_0;
				@class.FileName = fwargs.First<KeyValuePair<string, FileWatcherArgsAddl>>().Value.OriginalName;
				@class.File = fileBinary.ByteArray;
				@class.dateChange = fileBinary.LastChanged;
				@class.idTemplate = fwargs.First<KeyValuePair<string, FileWatcherArgsAddl>>().Value.IdTemplate.Value;
				this.class10_0.tTC_DocFile.Rows.Add(@class);
			}
			else
			{
				source.First<Class10.Class88>().File = fileBinary.ByteArray;
				source.First<Class10.Class88>().dateChange = fileBinary.LastChanged;
				source.First<Class10.Class88>().EndEdit();
				this.bool_0 = true;
			}
		}
		this.method_21();
	}

	private void method_21()
	{
		if (base.InvokeRequired)
		{
			base.Invoke(new Action(this.method_26));
			return;
		}
		this.FcwqEnOhCr.ResetBindings(false);
	}

	private void method_22(bool bool_1 = false)
	{
		if (this.FcwqEnOhCr.Current != null)
		{
			Class10.Class88 @class = (Class10.Class88)((DataRowView)this.FcwqEnOhCr.Current).Row;
			string fileName = @class.FileName;
			string text = this.method_19();
			string newFileNameIsExists = FileBinary.GetNewFileNameIsExists(text, fileName, false);
			int? idTemplate = null;
			if (@class["idTemplate"] != DBNull.Value)
			{
				idTemplate = new int?(@class.idTemplate);
			}
			DateTime dateChange = @class.dateChange;
			if (@class["File"] == DBNull.Value)
			{
				try
				{
					using (SqlConnection sqlConnection = new SqlConnection(this.SqlSettings.GetConnectionString()))
					{
						sqlConnection.Open();
						SqlDataReader sqlDataReader = new SqlCommand("SELECT [File] FROM tTC_DocFile WHERE id = " + @class["id"].ToString(), sqlConnection).ExecuteReader();
						while (sqlDataReader.Read())
						{
							@class["File"] = sqlDataReader["File"];
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, ex.Source);
				}
			}
			byte[] file;
			try
			{
				file = @class.File;
			}
			catch
			{
				MessageBox.Show("Нет содержимого файла");
				return;
			}
			FileBinary fileBinary = new FileBinary(file, newFileNameIsExists, DateTime.Now);
			fileBinary.SaveToDisk(text);
			Process.Start(text + "\\" + fileBinary.Name);
			if (bool_1)
			{
				if (this.dictionary_0.ContainsKey(fileName))
				{
					if (this.dictionary_0[fileName].Watcher == null)
					{
						FileWatcher fileWatcher = new FileWatcher(text, newFileNameIsExists);
						fileWatcher.AnyChanged += this.method_20;
						fileWatcher.Start();
						this.dictionary_0[fileName].Watcher = fileWatcher;
					}
					else
					{
						this.dictionary_0[fileName].Watcher.AnyChanged -= this.method_20;
						this.dictionary_0[fileName].Watcher.Stop();
						FileWatcher fileWatcher2 = new FileWatcher(text, newFileNameIsExists);
						fileWatcher2.AnyChanged += this.method_20;
						fileWatcher2.Start();
						this.dictionary_0[fileName].Watcher = fileWatcher2;
					}
					this.dictionary_0[fileName].TempName = newFileNameIsExists;
					this.dictionary_0[fileName].OpenState = FileOpenState.Editing;
					return;
				}
				FileWatcher fileWatcher3 = new FileWatcher(text, newFileNameIsExists);
				fileWatcher3.AnyChanged += this.method_20;
				fileWatcher3.Start();
				FileWatcherArgsAddl value = new FileWatcherArgsAddl(idTemplate, fileName, newFileNameIsExists, fileWatcher3, FileOpenState.Editing);
				this.dictionary_0.Add(fileName, value);
			}
		}
	}

	private void method_23(int int_4)
	{
		try
		{
			using (SqlConnection sqlConnection = new SqlConnection(this.SqlSettings.GetConnectionString()))
			{
				sqlConnection.Open();
				SqlDataReader sqlDataReader = new SqlCommand("SELECT id, idDoc, FileName, dateChange, idTemplate FROM tTC_DocFile WHERE idDoc = " + int_4.ToString(), sqlConnection).ExecuteReader();
				while (sqlDataReader.Read())
				{
					Class10.Class88 @class = this.class10_0.tTC_DocFile.method_5();
					@class.id = (int)sqlDataReader["id"];
					@class.idDoc = (int)sqlDataReader["idDoc"];
					@class.FileName = sqlDataReader["FileName"].ToString();
					if (sqlDataReader["dateChange"] != DBNull.Value)
					{
						@class.dateChange = (DateTime)sqlDataReader["dateChange"];
					}
					int? idTemplate = null;
					if (sqlDataReader["idTemplate"] != DBNull.Value)
					{
						idTemplate = new int?(@class.idTemplate = (int)sqlDataReader["idTemplate"]);
					}
					this.class10_0.tTC_DocFile.Rows.Add(@class);
					@class.AcceptChanges();
					FileWatcherArgsAddl value = new FileWatcherArgsAddl(idTemplate, sqlDataReader["FileName"].ToString(), null, FileOpenState.None);
					this.dictionary_0.Add(sqlDataReader["FileName"].ToString(), value);
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, ex.Source);
		}
	}

	private bool method_24()
	{
		foreach (DataRow dataRow in this.class10_0.tTC_DocFile)
		{
			if (dataRow.RowState != DataRowState.Deleted && dataRow.RowState != DataRowState.Detached && Convert.ToInt32(dataRow["idDoc"]) != this.int_0)
			{
				dataRow["idDoc"] = this.int_0;
				dataRow.EndEdit();
			}
		}
		if (base.InsertSqlData(this.class10_0, this.class10_0.tTC_DocFile) && base.UpdateSqlDataOnlyChange(this.class10_0.tTC_DocFile) && base.DeleteSqlData(this.class10_0, this.class10_0.tTC_DocFile))
		{
			this.class10_0.tTC_DocFile.AcceptChanges();
			return true;
		}
		return false;
	}

	private void method_25()
	{
		this.icontainer_0 = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		this.label_0 = new Label();
		this.comboBox_0 = new ComboBox();
		this.class10_0 = new Class10();
		this.label_1 = new Label();
		this.textBox_0 = new TextBox();
		this.nullableDateTimePicker_0 = new NullableDateTimePicker();
		this.button_0 = new Button();
		this.button_1 = new Button();
		this.label_2 = new Label();
		this.textBox_1 = new TextBox();
		this.label_3 = new Label();
		this.label_4 = new Label();
		this.comboBox_1 = new ComboBox();
		this.xgsqmUvyuj = new GroupBox();
		this.tabControl_1 = new TabControl();
		this.tabPage_2 = new TabPage();
		this.toolStrip_0 = new ToolStrip();
		this.toolStripButton_0 = new ToolStripButton();
		this.label_5 = new Label();
		this.txtAbnObj = new TextBox();
		this.label_6 = new Label();
		this.comboBox_2 = new ComboBox();
		this.textBox_2 = new TextBox();
		this.label_7 = new Label();
		this.tabPage_3 = new TabPage();
		this.dataGridViewExcelFilter_0 = new DataGridViewExcelFilter();
		this.dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_3 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_4 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_5 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_6 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_7 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_8 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_9 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_10 = new DataGridViewTextBoxColumn();
		this.dliqwhrvoQ = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_11 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_12 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_13 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_14 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_15 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_16 = new DataGridViewTextBoxColumn();
		this.bindingSource_0 = new BindingSource(this.icontainer_0);
		this.radioButton_0 = new RadioButton();
		this.radioButton_1 = new RadioButton();
		this.radioButton_2 = new RadioButton();
		this.tabControl_0 = new TabControl();
		this.tabPage_0 = new TabPage();
		this.label_8 = new Label();
		this.textBox_3 = new TextBox();
		this.tabPage_1 = new TabPage();
		this.dataGridViewExcelFilter_1 = new DataGridViewExcelFilter();
		this.dataGridViewImageColumnNotNull_0 = new DataGridViewImageColumnNotNull();
		this.dataGridViewFilterTextBoxColumn_0 = new DataGridViewFilterTextBoxColumn();
		this.dataGridViewTextBoxColumn_17 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_18 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_19 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_20 = new DataGridViewTextBoxColumn();
		this.FcwqEnOhCr = new BindingSource(this.icontainer_0);
		this.toolStrip_1 = new ToolStrip();
		this.toolStripDropDownButton_0 = new ToolStripDropDownButton();
		this.toolStripMenuItem_0 = new ToolStripMenuItem();
		this.toolStripSeparator_0 = new ToolStripSeparator();
		this.toolStripButton_1 = new ToolStripButton();
		this.toolStripButton_2 = new ToolStripButton();
		this.toolStripButton_3 = new ToolStripButton();
		this.toolStripSeparator_1 = new ToolStripSeparator();
		this.toolStripButton_4 = new ToolStripButton();
		this.toolStripButton_5 = new ToolStripButton();
		this.contextMenuStrip_0 = new ContextMenuStrip(this.icontainer_0);
		this.toolStripMenuItem_1 = new ToolStripMenuItem();
		this.toolStripMenuItem_2 = new ToolStripMenuItem();
		this.toolStripSeparator_2 = new ToolStripSeparator();
		this.toolStripMenuItem_3 = new ToolStripMenuItem();
		this.toolStripMenuItem_4 = new ToolStripMenuItem();
		this.toolStripMenuItem_5 = new ToolStripMenuItem();
		this.toolStripSeparator_3 = new ToolStripSeparator();
		this.toolStripMenuItem_6 = new ToolStripMenuItem();
		this.toolStripMenuItem_7 = new ToolStripMenuItem();
		((ISupportInitialize)this.class10_0).BeginInit();
		this.xgsqmUvyuj.SuspendLayout();
		this.tabControl_1.SuspendLayout();
		this.tabPage_2.SuspendLayout();
		this.toolStrip_0.SuspendLayout();
		this.tabPage_3.SuspendLayout();
		((ISupportInitialize)this.dataGridViewExcelFilter_0).BeginInit();
		((ISupportInitialize)this.bindingSource_0).BeginInit();
		this.tabControl_0.SuspendLayout();
		this.tabPage_0.SuspendLayout();
		this.tabPage_1.SuspendLayout();
		((ISupportInitialize)this.dataGridViewExcelFilter_1).BeginInit();
		((ISupportInitialize)this.FcwqEnOhCr).BeginInit();
		this.toolStrip_1.SuspendLayout();
		this.contextMenuStrip_0.SuspendLayout();
		base.SuspendLayout();
		this.label_0.AutoSize = true;
		this.label_0.Location = new Point(6, 42);
		this.label_0.Name = "label1";
		this.label_0.Size = new Size(67, 13);
		this.label_0.TabIndex = 0;
		this.label_0.Text = "Тип письма";
		this.comboBox_0.DataBindings.Add(new Binding("SelectedValue", this.class10_0, "tTC_Doc.TypeDoc", true));
		this.comboBox_0.FormattingEnabled = true;
		this.comboBox_0.Location = new Point(6, 58);
		this.comboBox_0.Name = "cmbTypeMail";
		this.comboBox_0.Size = new Size(293, 21);
		this.comboBox_0.TabIndex = 1;
		this.comboBox_0.SelectedIndexChanged += this.comboBox_0_SelectedIndexChanged;
		this.class10_0.DataSetName = "DataSetTechConnection";
		this.class10_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		this.label_1.AutoSize = true;
		this.label_1.Location = new Point(6, 3);
		this.label_1.Name = "label2";
		this.label_1.Size = new Size(82, 13);
		this.label_1.TabIndex = 2;
		this.label_1.Text = "Номер письма";
		this.textBox_0.BackColor = SystemColors.Window;
		this.textBox_0.DataBindings.Add(new Binding("Text", this.class10_0, "tTC_Doc.numDoc", true));
		this.textBox_0.Location = new Point(6, 19);
		this.textBox_0.Name = "txtNumMail";
		this.textBox_0.ReadOnly = true;
		this.textBox_0.Size = new Size(128, 20);
		this.textBox_0.TabIndex = 3;
		this.textBox_0.TextChanged += this.textBox_0_TextChanged;
		this.nullableDateTimePicker_0.DataBindings.Add(new Binding("Value", this.class10_0, "tTC_Doc.dateDoc", true));
		this.nullableDateTimePicker_0.Location = new Point(140, 19);
		this.nullableDateTimePicker_0.Name = "dateTimePickerDocOut";
		this.nullableDateTimePicker_0.Size = new Size(159, 20);
		this.nullableDateTimePicker_0.TabIndex = 4;
		this.nullableDateTimePicker_0.Value = new DateTime(2013, 4, 29, 14, 38, 3, 750);
		this.nullableDateTimePicker_0.ValueChanged += this.nullableDateTimePicker_0_ValueChanged;
		this.button_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.button_0.DialogResult = DialogResult.OK;
		this.button_0.Location = new Point(14, 444);
		this.button_0.Name = "buttonOK";
		this.button_0.Size = new Size(75, 23);
		this.button_0.TabIndex = 11;
		this.button_0.Text = "Сохранить";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_0.Click += this.button_0_Click;
		this.button_1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.button_1.DialogResult = DialogResult.Cancel;
		this.button_1.Location = new Point(735, 444);
		this.button_1.Name = "buttonCancel";
		this.button_1.Size = new Size(75, 23);
		this.button_1.TabIndex = 12;
		this.button_1.Text = "Закрыть";
		this.button_1.UseVisualStyleBackColor = true;
		this.button_1.Click += this.button_1_Click;
		this.label_2.AutoSize = true;
		this.label_2.Location = new Point(13, 261);
		this.label_2.Name = "label7";
		this.label_2.Size = new Size(70, 13);
		this.label_2.TabIndex = 5;
		this.label_2.Text = "Содержание";
		this.textBox_1.AcceptsReturn = true;
		this.textBox_1.AcceptsTab = true;
		this.textBox_1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_1.DataBindings.Add(new Binding("Text", this.class10_0, "tTC_Doc.Body", true));
		this.textBox_1.Location = new Point(10, 277);
		this.textBox_1.Multiline = true;
		this.textBox_1.Name = "txtBody";
		this.textBox_1.Size = new Size(793, 129);
		this.textBox_1.TabIndex = 6;
		this.textBox_1.TextChanged += this.textBox_1_TextChanged;
		this.label_3.AutoSize = true;
		this.label_3.Location = new Point(137, 3);
		this.label_3.Name = "label3";
		this.label_3.Size = new Size(74, 13);
		this.label_3.TabIndex = 17;
		this.label_3.Text = "Дата письма";
		this.label_4.AutoSize = true;
		this.label_4.Location = new Point(305, 3);
		this.label_4.Name = "label8";
		this.label_4.Size = new Size(74, 13);
		this.label_4.TabIndex = 18;
		this.label_4.Text = "Исполнитель";
		this.comboBox_1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.comboBox_1.DataBindings.Add(new Binding("SelectedValue", this.class10_0, "tTC_Mail.Performer", true));
		this.comboBox_1.FormattingEnabled = true;
		this.comboBox_1.Location = new Point(305, 18);
		this.comboBox_1.Name = "cmbPerformer";
		this.comboBox_1.Size = new Size(501, 21);
		this.comboBox_1.TabIndex = 19;
		this.comboBox_1.SelectedIndexChanged += this.comboBox_1_SelectedIndexChanged;
		this.xgsqmUvyuj.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.xgsqmUvyuj.Controls.Add(this.tabControl_1);
		this.xgsqmUvyuj.Controls.Add(this.radioButton_0);
		this.xgsqmUvyuj.Controls.Add(this.radioButton_1);
		this.xgsqmUvyuj.Controls.Add(this.radioButton_2);
		this.xgsqmUvyuj.Location = new Point(6, 78);
		this.xgsqmUvyuj.Name = "groupBoxLinkDoc";
		this.xgsqmUvyuj.Size = new Size(800, 180);
		this.xgsqmUvyuj.TabIndex = 20;
		this.xgsqmUvyuj.TabStop = false;
		this.xgsqmUvyuj.Text = "Привязка к документу";
		this.tabControl_1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.tabControl_1.Controls.Add(this.tabPage_2);
		this.tabControl_1.Controls.Add(this.tabPage_3);
		this.tabControl_1.Location = new Point(0, 42);
		this.tabControl_1.Name = "tabControlRequest";
		this.tabControl_1.SelectedIndex = 0;
		this.tabControl_1.Size = new Size(800, 138);
		this.tabControl_1.TabIndex = 23;
		this.tabPage_2.Controls.Add(this.textBox_3);
		this.tabPage_2.Controls.Add(this.label_8);
		this.tabPage_2.Controls.Add(this.toolStrip_0);
		this.tabPage_2.Controls.Add(this.label_5);
		this.tabPage_2.Controls.Add(this.txtAbnObj);
		this.tabPage_2.Controls.Add(this.label_6);
		this.tabPage_2.Controls.Add(this.comboBox_2);
		this.tabPage_2.Controls.Add(this.textBox_2);
		this.tabPage_2.Controls.Add(this.label_7);
		this.tabPage_2.Location = new Point(4, 22);
		this.tabPage_2.Name = "tabPage1";
		this.tabPage_2.Padding = new Padding(3);
		this.tabPage_2.Size = new Size(792, 112);
		this.tabPage_2.TabIndex = 0;
		this.tabPage_2.Text = "Выбор документа";
		this.tabPage_2.UseVisualStyleBackColor = true;
		this.toolStrip_0.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.toolStrip_0.Dock = DockStyle.None;
		this.toolStrip_0.GripStyle = ToolStripGripStyle.Hidden;
		this.toolStrip_0.Items.AddRange(new ToolStripItem[]
		{
			this.toolStripButton_0
		});
		this.toolStrip_0.Location = new Point(147, 10);
		this.toolStrip_0.Name = "toolStrip1";
		this.toolStrip_0.Size = new Size(26, 25);
		this.toolStrip_0.TabIndex = 10;
		this.toolStrip_0.Text = "toolStrip1";
		this.toolStrip_0.Visible = false;
		this.toolStripButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_0.Image = Resources.partners;
		this.toolStripButton_0.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_0.Name = "toolBtnContractor";
		this.toolStripButton_0.Size = new Size(23, 22);
		this.toolStripButton_0.Text = "Выбрать контрагента";
		this.toolStripButton_0.Click += this.toolStripButton_0_Click;
		this.label_5.AutoSize = true;
		this.label_5.Location = new Point(6, 63);
		this.label_5.Name = "label5";
		this.label_5.Size = new Size(45, 13);
		this.label_5.TabIndex = 4;
		this.label_5.Text = "Объект";
		this.txtAbnObj.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.txtAbnObj.BackColor = SystemColors.Window;
		this.txtAbnObj.Location = new Point(146, 60);
		this.txtAbnObj.Name = "txtAbnObj";
		this.txtAbnObj.ReadOnly = true;
		this.txtAbnObj.Size = new Size(640, 20);
		this.txtAbnObj.TabIndex = 5;
		this.label_6.AutoSize = true;
		this.label_6.Location = new Point(6, 13);
		this.label_6.Name = "labelNumDateIn";
		this.label_6.Size = new Size(132, 13);
		this.label_6.TabIndex = 0;
		this.label_6.Text = "Номер и дата вх. заявки";
		this.comboBox_2.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.comboBox_2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBox_2.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBox_2.DataBindings.Add(new Binding("SelectedValue", this.class10_0, "tTC_DocOut.idDoc", true));
		this.comboBox_2.FormattingEnabled = true;
		this.comboBox_2.Location = new Point(146, 10);
		this.comboBox_2.Name = "cmbNumDateIn";
		this.comboBox_2.Size = new Size(640, 21);
		this.comboBox_2.TabIndex = 1;
		this.comboBox_2.SelectedValueChanged += this.comboBox_2_SelectedValueChanged;
		this.textBox_2.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_2.BackColor = SystemColors.Window;
		this.textBox_2.Location = new Point(146, 36);
		this.textBox_2.Name = "txtAbn";
		this.textBox_2.ReadOnly = true;
		this.textBox_2.Size = new Size(640, 20);
		this.textBox_2.TabIndex = 3;
		this.label_7.AutoSize = true;
		this.label_7.Location = new Point(6, 39);
		this.label_7.Name = "label9";
		this.label_7.Size = new Size(49, 13);
		this.label_7.TabIndex = 2;
		this.label_7.Text = "Абонент";
		this.tabPage_3.Controls.Add(this.dataGridViewExcelFilter_0);
		this.tabPage_3.Location = new Point(4, 22);
		this.tabPage_3.Name = "tabPagerequestHistory";
		this.tabPage_3.Padding = new Padding(3);
		this.tabPage_3.Size = new Size(792, 112);
		this.tabPage_3.TabIndex = 1;
		this.tabPage_3.Text = "История заявок";
		this.tabPage_3.UseVisualStyleBackColor = true;
		this.dataGridViewExcelFilter_0.AllowUserToAddRows = false;
		this.dataGridViewExcelFilter_0.AllowUserToDeleteRows = false;
		this.dataGridViewExcelFilter_0.AutoGenerateColumns = false;
		this.dataGridViewExcelFilter_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridViewExcelFilter_0.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewTextBoxColumn_0,
			this.dataGridViewTextBoxColumn_1,
			this.dataGridViewTextBoxColumn_2,
			this.dataGridViewTextBoxColumn_3,
			this.dataGridViewTextBoxColumn_4,
			this.dataGridViewTextBoxColumn_5,
			this.dataGridViewTextBoxColumn_6,
			this.dataGridViewTextBoxColumn_7,
			this.dataGridViewTextBoxColumn_8,
			this.dataGridViewTextBoxColumn_9,
			this.dataGridViewTextBoxColumn_10,
			this.dliqwhrvoQ,
			this.dataGridViewTextBoxColumn_11,
			this.dataGridViewTextBoxColumn_12,
			this.dataGridViewTextBoxColumn_13,
			this.dataGridViewTextBoxColumn_14,
			this.dataGridViewTextBoxColumn_15,
			this.dataGridViewTextBoxColumn_16
		});
		this.dataGridViewExcelFilter_0.DataSource = this.bindingSource_0;
		this.dataGridViewExcelFilter_0.Dock = DockStyle.Fill;
		this.dataGridViewExcelFilter_0.Location = new Point(3, 3);
		this.dataGridViewExcelFilter_0.MultiSelect = false;
		this.dataGridViewExcelFilter_0.Name = "dgvRequestHistory";
		this.dataGridViewExcelFilter_0.ReadOnly = true;
		this.dataGridViewExcelFilter_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		this.dataGridViewExcelFilter_0.Size = new Size(786, 106);
		this.dataGridViewExcelFilter_0.TabIndex = 5;
		this.dataGridViewExcelFilter_0.VirtualMode = true;
		this.dataGridViewExcelFilter_0.CellFormatting += this.dataGridViewExcelFilter_0_CellFormatting;
		this.dataGridViewExcelFilter_0.RowPostPaint += this.dataGridViewExcelFilter_0_RowPostPaint;
		this.dataGridViewTextBoxColumn_0.DataPropertyName = "numDateIn";
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		this.dataGridViewTextBoxColumn_0.DefaultCellStyle = dataGridViewCellStyle;
		this.dataGridViewTextBoxColumn_0.HeaderText = "№, дата вход.";
		this.dataGridViewTextBoxColumn_0.Name = "numDateInDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_0.ReadOnly = true;
		this.dataGridViewTextBoxColumn_0.Width = 80;
		this.dataGridViewTextBoxColumn_1.DataPropertyName = "numDoc";
		this.dataGridViewTextBoxColumn_1.HeaderText = "numDoc";
		this.dataGridViewTextBoxColumn_1.Name = "numDocDataGridViewTextBoxColumn1";
		this.dataGridViewTextBoxColumn_1.ReadOnly = true;
		this.dataGridViewTextBoxColumn_1.Visible = false;
		this.dataGridViewTextBoxColumn_2.DataPropertyName = "id";
		this.dataGridViewTextBoxColumn_2.HeaderText = "id";
		this.dataGridViewTextBoxColumn_2.Name = "idRequestHistoryDgvColumn";
		this.dataGridViewTextBoxColumn_2.ReadOnly = true;
		this.dataGridViewTextBoxColumn_2.Visible = false;
		this.dataGridViewTextBoxColumn_3.DataPropertyName = "dateDoc";
		this.dataGridViewTextBoxColumn_3.HeaderText = "Дата получения";
		this.dataGridViewTextBoxColumn_3.Name = "dateDocDataGridViewTextBoxColumn1";
		this.dataGridViewTextBoxColumn_3.ReadOnly = true;
		this.dataGridViewTextBoxColumn_3.Width = 80;
		this.dataGridViewTextBoxColumn_4.DataPropertyName = "TypeDoc";
		this.dataGridViewTextBoxColumn_4.HeaderText = "TypeDoc";
		this.dataGridViewTextBoxColumn_4.Name = "typeDocRequestHistoryDgvColumn";
		this.dataGridViewTextBoxColumn_4.ReadOnly = true;
		this.dataGridViewTextBoxColumn_4.Visible = false;
		this.dataGridViewTextBoxColumn_5.DataPropertyName = "numIn";
		this.dataGridViewTextBoxColumn_5.HeaderText = "numIn";
		this.dataGridViewTextBoxColumn_5.Name = "numInDataGridViewTextBoxColumn1";
		this.dataGridViewTextBoxColumn_5.ReadOnly = true;
		this.dataGridViewTextBoxColumn_5.Visible = false;
		this.dataGridViewTextBoxColumn_6.DataPropertyName = "dateIn";
		this.dataGridViewTextBoxColumn_6.HeaderText = "dateIn";
		this.dataGridViewTextBoxColumn_6.Name = "dateInDataGridViewTextBoxColumn1";
		this.dataGridViewTextBoxColumn_6.ReadOnly = true;
		this.dataGridViewTextBoxColumn_6.Visible = false;
		this.dataGridViewTextBoxColumn_7.DataPropertyName = "idAbn";
		this.dataGridViewTextBoxColumn_7.HeaderText = "idAbn";
		this.dataGridViewTextBoxColumn_7.Name = "idAbnDataGridViewTextBoxColumn1";
		this.dataGridViewTextBoxColumn_7.ReadOnly = true;
		this.dataGridViewTextBoxColumn_7.Visible = false;
		this.dataGridViewTextBoxColumn_8.DataPropertyName = "idAbnObj";
		this.dataGridViewTextBoxColumn_8.HeaderText = "idAbnObj";
		this.dataGridViewTextBoxColumn_8.Name = "idAbnObjDataGridViewTextBoxColumn1";
		this.dataGridViewTextBoxColumn_8.ReadOnly = true;
		this.dataGridViewTextBoxColumn_8.Visible = false;
		this.dataGridViewTextBoxColumn_9.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_9.DataPropertyName = "body";
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
		this.dataGridViewTextBoxColumn_9.DefaultCellStyle = dataGridViewCellStyle2;
		this.dataGridViewTextBoxColumn_9.HeaderText = "Тело письма";
		this.dataGridViewTextBoxColumn_9.Name = "bodyDataGridViewTextBoxColumn1";
		this.dataGridViewTextBoxColumn_9.ReadOnly = true;
		this.dataGridViewTextBoxColumn_10.DataPropertyName = "PowerCurrent";
		this.dataGridViewTextBoxColumn_10.HeaderText = "Текущая мощность";
		this.dataGridViewTextBoxColumn_10.Name = "powerCurrentDgvColumn";
		this.dataGridViewTextBoxColumn_10.ReadOnly = true;
		this.dataGridViewTextBoxColumn_10.Width = 70;
		this.dliqwhrvoQ.DataPropertyName = "PowerAdd";
		this.dliqwhrvoQ.HeaderText = "Доп мощность";
		this.dliqwhrvoQ.Name = "PowerAddDgvColumn";
		this.dliqwhrvoQ.ReadOnly = true;
		this.dliqwhrvoQ.Width = 70;
		this.dataGridViewTextBoxColumn_11.DataPropertyName = "Power";
		this.dataGridViewTextBoxColumn_11.HeaderText = "Суммарная мощность";
		this.dataGridViewTextBoxColumn_11.Name = "powerDataGridViewTextBoxColumn1";
		this.dataGridViewTextBoxColumn_11.ReadOnly = true;
		this.dataGridViewTextBoxColumn_11.Width = 70;
		this.dataGridViewTextBoxColumn_12.DataPropertyName = "VoltageName";
		this.dataGridViewTextBoxColumn_12.HeaderText = "Напряжение";
		this.dataGridViewTextBoxColumn_12.Name = "voltageNameDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_12.ReadOnly = true;
		this.dataGridViewTextBoxColumn_12.Width = 70;
		this.dataGridViewTextBoxColumn_13.DataPropertyName = "Comment";
		this.dataGridViewTextBoxColumn_13.HeaderText = "Комментарий";
		this.dataGridViewTextBoxColumn_13.Name = "commentDataGridViewTextBoxColumn1";
		this.dataGridViewTextBoxColumn_13.ReadOnly = true;
		this.dataGridViewTextBoxColumn_13.Width = 70;
		this.dataGridViewTextBoxColumn_14.DataPropertyName = "VoltageLevel";
		this.dataGridViewTextBoxColumn_14.HeaderText = "VoltageLevel";
		this.dataGridViewTextBoxColumn_14.Name = "voltageLevelDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_14.ReadOnly = true;
		this.dataGridViewTextBoxColumn_14.Visible = false;
		this.dataGridViewTextBoxColumn_15.DataPropertyName = "VoltageValue";
		this.dataGridViewTextBoxColumn_15.HeaderText = "VoltageValue";
		this.dataGridViewTextBoxColumn_15.Name = "voltageValueDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_15.ReadOnly = true;
		this.dataGridViewTextBoxColumn_15.Visible = false;
		this.dataGridViewTextBoxColumn_16.DataPropertyName = "IdParent";
		this.dataGridViewTextBoxColumn_16.HeaderText = "IdParent";
		this.dataGridViewTextBoxColumn_16.Name = "idParentDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_16.ReadOnly = true;
		this.dataGridViewTextBoxColumn_16.Visible = false;
		this.bindingSource_0.DataMember = "vTC_RequestHistory";
		this.bindingSource_0.DataSource = this.class10_0;
		this.radioButton_0.AutoSize = true;
		this.radioButton_0.Location = new Point(288, 19);
		this.radioButton_0.Name = "radioButtonNoDoc";
		this.radioButton_0.Size = new Size(95, 17);
		this.radioButton_0.TabIndex = 2;
		this.radioButton_0.Text = "Без привязки";
		this.radioButton_0.UseVisualStyleBackColor = true;
		this.radioButton_0.CheckedChanged += this.radioButton_0_CheckedChanged;
		this.radioButton_1.AutoSize = true;
		this.radioButton_1.Location = new Point(193, 19);
		this.radioButton_1.Name = "radioButtonTU";
		this.radioButton_1.Size = new Size(87, 17);
		this.radioButton_1.TabIndex = 1;
		this.radioButton_1.Text = "Тех условие";
		this.radioButton_1.UseVisualStyleBackColor = true;
		this.radioButton_1.CheckedChanged += this.radioButton_1_CheckedChanged;
		this.radioButton_2.AutoSize = true;
		this.radioButton_2.Checked = true;
		this.radioButton_2.Location = new Point(10, 19);
		this.radioButton_2.Name = "radioButtonRequest";
		this.radioButton_2.Size = new Size(177, 17);
		this.radioButton_2.TabIndex = 0;
		this.radioButton_2.TabStop = true;
		this.radioButton_2.Text = "Заявка на тех присоединение";
		this.radioButton_2.UseVisualStyleBackColor = true;
		this.radioButton_2.CheckedChanged += this.radioButton_2_CheckedChanged;
		this.tabControl_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.tabControl_0.Controls.Add(this.tabPage_0);
		this.tabControl_0.Controls.Add(this.tabPage_1);
		this.tabControl_0.Location = new Point(0, 0);
		this.tabControl_0.Name = "tabControl";
		this.tabControl_0.SelectedIndex = 0;
		this.tabControl_0.Size = new Size(820, 438);
		this.tabControl_0.TabIndex = 21;
		this.tabPage_0.Controls.Add(this.label_1);
		this.tabPage_0.Controls.Add(this.textBox_1);
		this.tabPage_0.Controls.Add(this.xgsqmUvyuj);
		this.tabPage_0.Controls.Add(this.label_2);
		this.tabPage_0.Controls.Add(this.label_0);
		this.tabPage_0.Controls.Add(this.comboBox_1);
		this.tabPage_0.Controls.Add(this.comboBox_0);
		this.tabPage_0.Controls.Add(this.label_4);
		this.tabPage_0.Controls.Add(this.textBox_0);
		this.tabPage_0.Controls.Add(this.label_3);
		this.tabPage_0.Controls.Add(this.nullableDateTimePicker_0);
		this.tabPage_0.Location = new Point(4, 22);
		this.tabPage_0.Name = "tabPageGeneral";
		this.tabPage_0.Padding = new Padding(3);
		this.tabPage_0.Size = new Size(812, 412);
		this.tabPage_0.TabIndex = 0;
		this.tabPage_0.Text = "Общие";
		this.tabPage_0.UseVisualStyleBackColor = true;
		this.label_8.AutoSize = true;
		this.label_8.Location = new Point(6, 89);
		this.label_8.Name = "label4";
		this.label_8.Size = new Size(83, 13);
		this.label_8.TabIndex = 11;
		this.label_8.Text = "Адрес объекта";
		this.textBox_3.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_3.BackColor = SystemColors.Window;
		this.textBox_3.Location = new Point(146, 86);
		this.textBox_3.Name = "txtAbnObjAddress";
		this.textBox_3.ReadOnly = true;
		this.textBox_3.Size = new Size(640, 20);
		this.textBox_3.TabIndex = 11;
		this.tabPage_1.Controls.Add(this.dataGridViewExcelFilter_1);
		this.tabPage_1.Controls.Add(this.toolStrip_1);
		this.tabPage_1.Location = new Point(4, 22);
		this.tabPage_1.Name = "tabPageFiles";
		this.tabPage_1.Padding = new Padding(3);
		this.tabPage_1.Size = new Size(812, 412);
		this.tabPage_1.TabIndex = 1;
		this.tabPage_1.Text = "Файлы";
		this.tabPage_1.UseVisualStyleBackColor = true;
		this.dataGridViewExcelFilter_1.AllowUserToAddRows = false;
		this.dataGridViewExcelFilter_1.AllowUserToDeleteRows = false;
		this.dataGridViewExcelFilter_1.AllowUserToResizeColumns = false;
		this.dataGridViewExcelFilter_1.AllowUserToResizeRows = false;
		this.dataGridViewExcelFilter_1.AutoGenerateColumns = false;
		this.dataGridViewExcelFilter_1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridViewExcelFilter_1.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewImageColumnNotNull_0,
			this.dataGridViewFilterTextBoxColumn_0,
			this.dataGridViewTextBoxColumn_17,
			this.dataGridViewTextBoxColumn_18,
			this.dataGridViewTextBoxColumn_19,
			this.dataGridViewTextBoxColumn_20
		});
		this.dataGridViewExcelFilter_1.DataSource = this.FcwqEnOhCr;
		this.dataGridViewExcelFilter_1.Dock = DockStyle.Fill;
		this.dataGridViewExcelFilter_1.EditMode = DataGridViewEditMode.EditProgrammatically;
		this.dataGridViewExcelFilter_1.Location = new Point(3, 28);
		this.dataGridViewExcelFilter_1.Name = "dgvFile";
		this.dataGridViewExcelFilter_1.ReadOnly = true;
		this.dataGridViewExcelFilter_1.RowHeadersVisible = false;
		this.dataGridViewExcelFilter_1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		this.dataGridViewExcelFilter_1.Size = new Size(806, 381);
		this.dataGridViewExcelFilter_1.TabIndex = 7;
		this.dataGridViewExcelFilter_1.VirtualMode = true;
		this.dataGridViewExcelFilter_1.CellDoubleClick += this.dataGridViewExcelFilter_1_CellDoubleClick;
		this.dataGridViewExcelFilter_1.CellEndEdit += this.dataGridViewExcelFilter_1_CellEndEdit;
		this.dataGridViewExcelFilter_1.CellMouseClick += this.dataGridViewExcelFilter_1_CellMouseClick;
		this.dataGridViewExcelFilter_1.CellValidating += this.dataGridViewExcelFilter_1_CellValidating;
		this.dataGridViewExcelFilter_1.CellValueNeeded += this.dataGridViewExcelFilter_1_CellValueNeeded;
		dataGridViewCellStyle3.NullValue = null;
		this.dataGridViewImageColumnNotNull_0.DefaultCellStyle = dataGridViewCellStyle3;
		this.dataGridViewImageColumnNotNull_0.HeaderText = "";
		this.dataGridViewImageColumnNotNull_0.ImageLayout = DataGridViewImageCellLayout.Zoom;
		this.dataGridViewImageColumnNotNull_0.Name = "imageDgvColumn";
		this.dataGridViewImageColumnNotNull_0.ReadOnly = true;
		this.dataGridViewImageColumnNotNull_0.Width = 30;
		this.dataGridViewFilterTextBoxColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewFilterTextBoxColumn_0.DataPropertyName = "FileName";
		this.dataGridViewFilterTextBoxColumn_0.HeaderText = "Файл";
		this.dataGridViewFilterTextBoxColumn_0.Name = "fileNameDgvColumn";
		this.dataGridViewFilterTextBoxColumn_0.ReadOnly = true;
		this.dataGridViewFilterTextBoxColumn_0.Resizable = DataGridViewTriState.True;
		this.dataGridViewTextBoxColumn_17.DataPropertyName = "id";
		this.dataGridViewTextBoxColumn_17.HeaderText = "id";
		this.dataGridViewTextBoxColumn_17.Name = "id";
		this.dataGridViewTextBoxColumn_17.ReadOnly = true;
		this.dataGridViewTextBoxColumn_17.Visible = false;
		this.dataGridViewTextBoxColumn_18.DataPropertyName = "idDoc";
		this.dataGridViewTextBoxColumn_18.HeaderText = "idDoc";
		this.dataGridViewTextBoxColumn_18.Name = "idDoc";
		this.dataGridViewTextBoxColumn_18.ReadOnly = true;
		this.dataGridViewTextBoxColumn_18.Visible = false;
		this.dataGridViewTextBoxColumn_19.DataPropertyName = "dateChange";
		this.dataGridViewTextBoxColumn_19.HeaderText = "dateChange";
		this.dataGridViewTextBoxColumn_19.Name = "dateChangeDgvColumn";
		this.dataGridViewTextBoxColumn_19.ReadOnly = true;
		this.dataGridViewTextBoxColumn_19.Visible = false;
		this.dataGridViewTextBoxColumn_20.DataPropertyName = "idTemplate";
		this.dataGridViewTextBoxColumn_20.HeaderText = "idTemplate";
		this.dataGridViewTextBoxColumn_20.Name = "idTemplateDgvColumn";
		this.dataGridViewTextBoxColumn_20.ReadOnly = true;
		this.dataGridViewTextBoxColumn_20.Visible = false;
		this.FcwqEnOhCr.DataMember = "tTC_DocFile";
		this.FcwqEnOhCr.DataSource = this.class10_0;
		this.toolStrip_1.Items.AddRange(new ToolStripItem[]
		{
			this.toolStripDropDownButton_0,
			this.toolStripButton_1,
			this.toolStripButton_2,
			this.toolStripButton_3,
			this.toolStripSeparator_1,
			this.toolStripButton_4,
			this.toolStripButton_5
		});
		this.toolStrip_1.Location = new Point(3, 3);
		this.toolStrip_1.Name = "toolStripFile";
		this.toolStrip_1.Size = new Size(806, 25);
		this.toolStrip_1.TabIndex = 1;
		this.toolStrip_1.Text = "toolStrip1";
		this.toolStripDropDownButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripDropDownButton_0.DropDownItems.AddRange(new ToolStripItem[]
		{
			this.toolStripMenuItem_0,
			this.toolStripSeparator_0
		});
		this.toolStripDropDownButton_0.Image = Resources.ElementAdd;
		this.toolStripDropDownButton_0.ImageTransparentColor = Color.Magenta;
		this.toolStripDropDownButton_0.Name = "toolBtnAddFile";
		this.toolStripDropDownButton_0.Size = new Size(29, 22);
		this.toolStripDropDownButton_0.Text = "Добавить файл";
		this.toolStripMenuItem_0.Name = "toolItemAddExistFile";
		this.toolStripMenuItem_0.Size = new Size(190, 22);
		this.toolStripMenuItem_0.Text = "Сущесвующий файл";
		this.toolStripMenuItem_0.Click += this.toolStripMenuItem_2_Click;
		this.toolStripSeparator_0.Name = "toolStripSeparator2";
		this.toolStripSeparator_0.Size = new Size(187, 6);
		this.toolStripButton_1.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_1.Image = Resources.ElementEdit;
		this.toolStripButton_1.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_1.Name = "toolBtnEditFile";
		this.toolStripButton_1.Size = new Size(23, 22);
		this.toolStripButton_1.Text = "Редактировать файл";
		this.toolStripButton_1.Click += this.toolStripMenuItem_3_Click;
		this.toolStripButton_2.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_2.Image = Resources.ElementInformation;
		this.toolStripButton_2.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_2.Name = "toolBtnOpenFile";
		this.toolStripButton_2.Size = new Size(23, 22);
		this.toolStripButton_2.Text = "Открыть файл";
		this.toolStripButton_2.Click += this.toolStripMenuItem_4_Click;
		this.toolStripButton_3.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_3.Image = Resources.ElementDel;
		this.toolStripButton_3.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_3.Name = "toolBtnDelFile";
		this.toolStripButton_3.Size = new Size(23, 22);
		this.toolStripButton_3.Text = "Удалить файл";
		this.toolStripButton_3.Click += this.toolStripMenuItem_5_Click;
		this.toolStripSeparator_1.Name = "toolStripSeparator3";
		this.toolStripSeparator_1.Size = new Size(6, 25);
		this.toolStripButton_4.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_4.Image = Resources.rename;
		this.toolStripButton_4.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_4.Name = "toolBtnRenameFile";
		this.toolStripButton_4.Size = new Size(23, 22);
		this.toolStripButton_4.Text = "Переименовать";
		this.toolStripButton_4.Click += this.toolStripMenuItem_6_Click;
		this.toolStripButton_5.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_5.Image = Resources.save;
		this.toolStripButton_5.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_5.Name = "toolBtnSaveFile";
		this.toolStripButton_5.Size = new Size(23, 22);
		this.toolStripButton_5.Text = "Сохранить файл на диск";
		this.toolStripButton_5.Click += this.toolStripMenuItem_7_Click;
		this.contextMenuStrip_0.Items.AddRange(new ToolStripItem[]
		{
			this.toolStripMenuItem_1,
			this.toolStripMenuItem_3,
			this.toolStripMenuItem_4,
			this.toolStripMenuItem_5,
			this.toolStripSeparator_3,
			this.toolStripMenuItem_6,
			this.toolStripMenuItem_7
		});
		this.contextMenuStrip_0.Name = "contextMenuFile";
		this.contextMenuStrip_0.Size = new Size(177, 142);
		this.toolStripMenuItem_1.DropDownItems.AddRange(new ToolStripItem[]
		{
			this.toolStripMenuItem_2,
			this.toolStripSeparator_2
		});
		this.toolStripMenuItem_1.Image = Resources.ElementAdd;
		this.toolStripMenuItem_1.Name = "toolMenuItemAddFile";
		this.toolStripMenuItem_1.Size = new Size(176, 22);
		this.toolStripMenuItem_1.Text = "Добавить";
		this.toolStripMenuItem_2.Name = "toolMenuItemAddExistsFile";
		this.toolStripMenuItem_2.Size = new Size(195, 22);
		this.toolStripMenuItem_2.Text = "Существующий файл";
		this.toolStripMenuItem_2.Click += this.toolStripMenuItem_2_Click;
		this.toolStripSeparator_2.Name = "toolStripSeparator5";
		this.toolStripSeparator_2.Size = new Size(192, 6);
		this.toolStripMenuItem_3.Image = Resources.ElementEdit;
		this.toolStripMenuItem_3.Name = "toolMenuItemEditFile";
		this.toolStripMenuItem_3.Size = new Size(176, 22);
		this.toolStripMenuItem_3.Text = "Редактировать";
		this.toolStripMenuItem_3.Click += this.toolStripMenuItem_3_Click;
		this.toolStripMenuItem_4.Image = Resources.ElementInformation;
		this.toolStripMenuItem_4.Name = "toolMenuItemViewFile";
		this.toolStripMenuItem_4.Size = new Size(176, 22);
		this.toolStripMenuItem_4.Text = "Просмотр";
		this.toolStripMenuItem_4.Click += this.toolStripMenuItem_4_Click;
		this.toolStripMenuItem_5.Image = Resources.ElementDel;
		this.toolStripMenuItem_5.Name = "toolMenuItemDelFile";
		this.toolStripMenuItem_5.Size = new Size(176, 22);
		this.toolStripMenuItem_5.Text = "Удалить";
		this.toolStripMenuItem_5.Click += this.toolStripMenuItem_5_Click;
		this.toolStripSeparator_3.Name = "toolStripSeparator4";
		this.toolStripSeparator_3.Size = new Size(173, 6);
		this.toolStripMenuItem_6.Image = Resources.rename;
		this.toolStripMenuItem_6.Name = "toolMenuItemRenameFile";
		this.toolStripMenuItem_6.Size = new Size(176, 22);
		this.toolStripMenuItem_6.Text = "Переименовать";
		this.toolStripMenuItem_6.Click += this.toolStripMenuItem_6_Click;
		this.toolStripMenuItem_7.Image = Resources.save;
		this.toolStripMenuItem_7.Name = "toolMenuItemSaveFile";
		this.toolStripMenuItem_7.Size = new Size(176, 22);
		this.toolStripMenuItem_7.Text = "Сохранить на диск";
		this.toolStripMenuItem_7.Click += this.toolStripMenuItem_7_Click;
		base.AcceptButton = this.button_0;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = this.button_1;
		base.ClientSize = new Size(821, 474);
		base.Controls.Add(this.tabControl_0);
		base.Controls.Add(this.button_1);
		base.Controls.Add(this.button_0);
		base.Name = "FormMailTUAddEdit";
		this.Text = "FormTechConnectionDocOutAddEdit";
		base.FormClosing += this.Form19_FormClosing;
		base.Load += this.Form19_Load;
		((ISupportInitialize)this.class10_0).EndInit();
		this.xgsqmUvyuj.ResumeLayout(false);
		this.xgsqmUvyuj.PerformLayout();
		this.tabControl_1.ResumeLayout(false);
		this.tabPage_2.ResumeLayout(false);
		this.tabPage_2.PerformLayout();
		this.toolStrip_0.ResumeLayout(false);
		this.toolStrip_0.PerformLayout();
		this.tabPage_3.ResumeLayout(false);
		((ISupportInitialize)this.dataGridViewExcelFilter_0).EndInit();
		((ISupportInitialize)this.bindingSource_0).EndInit();
		this.tabControl_0.ResumeLayout(false);
		this.tabPage_0.ResumeLayout(false);
		this.tabPage_0.PerformLayout();
		this.tabPage_1.ResumeLayout(false);
		this.tabPage_1.PerformLayout();
		((ISupportInitialize)this.dataGridViewExcelFilter_1).EndInit();
		((ISupportInitialize)this.FcwqEnOhCr).EndInit();
		this.toolStrip_1.ResumeLayout(false);
		this.toolStrip_1.PerformLayout();
		this.contextMenuStrip_0.ResumeLayout(false);
		base.ResumeLayout(false);
	}

	[CompilerGenerated]
	private void method_26()
	{
		this.FcwqEnOhCr.ResetBindings(false);
	}

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private bool bool_0;

	private Dictionary<string, FileWatcherArgsAddl> dictionary_0;

	private string string_0;

	private Label label_0;

	private ComboBox comboBox_0;

	private Label label_1;

	private TextBox textBox_0;

	private NullableDateTimePicker nullableDateTimePicker_0;

	private Class10 class10_0;

	private Button button_0;

	private Button button_1;

	private Label label_2;

	private TextBox textBox_1;

	private Label label_3;

	private Label label_4;

	private ComboBox comboBox_1;

	private GroupBox xgsqmUvyuj;

	private RadioButton radioButton_0;

	private RadioButton radioButton_1;

	private RadioButton radioButton_2;

	private TabControl tabControl_0;

	private TabPage tabPage_0;

	private TabPage tabPage_1;

	private TabControl tabControl_1;

	private TabPage tabPage_2;

	private Label label_5;

	private TextBox txtAbnObj;

	private Label label_6;

	private ComboBox comboBox_2;

	private TextBox textBox_2;

	private Label label_7;

	private TabPage tabPage_3;

	private ToolStrip toolStrip_0;

	private ToolStripButton toolStripButton_0;

	private BindingSource bindingSource_0;

	private DataGridViewExcelFilter dataGridViewExcelFilter_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_3;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_4;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_5;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_6;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_7;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_8;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_9;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_10;

	private DataGridViewTextBoxColumn dliqwhrvoQ;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_11;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_12;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_13;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_14;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_15;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_16;

	private ToolStrip toolStrip_1;

	private ToolStripDropDownButton toolStripDropDownButton_0;

	private ToolStripMenuItem toolStripMenuItem_0;

	private ToolStripSeparator toolStripSeparator_0;

	private ToolStripButton toolStripButton_1;

	private ToolStripButton toolStripButton_2;

	private ToolStripButton toolStripButton_3;

	private ToolStripSeparator toolStripSeparator_1;

	private ToolStripButton toolStripButton_4;

	private ToolStripButton toolStripButton_5;

	private BindingSource FcwqEnOhCr;

	private DataGridViewExcelFilter dataGridViewExcelFilter_1;

	private DataGridViewImageColumnNotNull dataGridViewImageColumnNotNull_0;

	private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_17;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_18;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_19;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_20;

	private ContextMenuStrip contextMenuStrip_0;

	private ToolStripMenuItem toolStripMenuItem_1;

	private ToolStripMenuItem toolStripMenuItem_2;

	private ToolStripSeparator toolStripSeparator_2;

	private ToolStripMenuItem toolStripMenuItem_3;

	private ToolStripMenuItem toolStripMenuItem_4;

	private ToolStripMenuItem toolStripMenuItem_5;

	private ToolStripSeparator toolStripSeparator_3;

	private ToolStripMenuItem toolStripMenuItem_6;

	private ToolStripMenuItem toolStripMenuItem_7;

	private Label label_8;

	private TextBox textBox_3;
}
