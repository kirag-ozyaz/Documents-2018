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
using System.Xml;
using ControlsLbr;
using ControlsLbr.DataGridViewExcelFilter;
using ControlsLbr.DataGridViewExcelFilter.DataGridViewColumsLibraty;
using DataSql;
using Documents.Properties;
using FormLbr;
using FormLbr.Classes;
using OfficeLB.Word;

internal partial class Form20 : FormBase
{
	internal int method_0()
	{
		return this.int_0;
	}

	internal Form20()
	{
		
		this.int_0 = -1;
		this.int_1 = -1;
		this.int_2 = -1;
		this.int_3 = -1;
		this.int_4 = -1;
		this.vuBolsfjNbM = new Class10();
		this.dictionary_0 = new Dictionary<string, FileWatcherArgsAddl>();
		this.string_0 = "";
		this.class10_0 = new Class10();
		this.dataTable_0 = new DataTable();
		
		this.method_24();
		this.method_1();
	}

	internal Form20(int int_5, int int_6 = -1, int int_7 = -1)
	{
		
		this.int_0 = -1;
		this.int_1 = -1;
		this.int_2 = -1;
		this.int_3 = -1;
		this.int_4 = -1;
		this.vuBolsfjNbM = new Class10();
		this.dictionary_0 = new Dictionary<string, FileWatcherArgsAddl>();
		this.string_0 = "";
		this.class10_0 = new Class10();
		this.dataTable_0 = new DataTable();
		
		this.method_24();
		this.int_0 = int_5;
		this.int_1 = int_6;
		this.int_2 = int_7;
		this.method_1();
	}

	private void method_1()
	{
		this.Text = ((this.int_0 == -1) ? "Новый договор" : "Редактирование договор");
		this.bkLolxvsRes.Value = DateTime.Now.Date;
		this.PcTolGiItLF.Value = DateTime.Now.Date;
		this.nullableDateTimePicker_1.Value = DateTime.Now.Date;
		this.nullableDateTimePicker_0.Value = DateTime.Now.Date;
	}

	private void Form20_Load(object sender, EventArgs e)
	{
		this.method_20();
		this.Ttgolyiriw2();
		this.method_3();
		this.method_8();
		if (this.int_0 == -1)
		{
			DataRow dataRow = this.class10_1.tTC_Doc.NewRow();
			dataRow["TypeDoc"] = 1220;
			dataRow["DateDoc"] = DateTime.Now.Date;
			this.class10_1.tTC_Doc.Rows.Add(dataRow);
			this.method_2();
		}
		else
		{
			base.SelectSqlData(this.class10_1, this.class10_1.tTC_Doc, true, "where id = " + this.int_0.ToString());
			this.nullableNumericUpDown_0.ValueChanged -= this.nullableNumericUpDown_0_ValueChanged;
			base.SelectSqlData(this.class10_1, this.class10_1.tTC_Contract, true, "where id = " + this.int_0.ToString());
			this.nullableNumericUpDown_0.ValueChanged += this.nullableNumericUpDown_0_ValueChanged;
			if (this.class10_1.tTC_Contract.Rows.Count == 0)
			{
				this.method_2();
			}
			base.SelectSqlData(this.vuBolsfjNbM, this.vuBolsfjNbM.tTC_Doc, true, "where idParent = " + this.int_0.ToString() + " and typeDoc = " + 1123.ToString());
			if (this.vuBolsfjNbM.tTC_Doc.Rows.Count > 0)
			{
				this.comboBox_0.SelectedValue = this.vuBolsfjNbM.tTC_Doc.Rows[0]["id"];
			}
			base.SelectSqlData(this.class10_1, this.class10_1.tTC_DocOut, true, "where idDocOut = " + this.int_0.ToString());
			this.method_14(this.int_0);
			this.method_21();
			base.SelectSqlData(this.class10_1.tTC_PaymentShedule, true, " where idDoc = " + this.int_0.ToString() + " order by DateShedule", null, false, 0);
		}
		if (this.int_2 != -1)
		{
			this.comboBox_0.SelectedValue = this.int_2;
		}
		this.bool_0 = false;
	}

	private void Form20_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (this.bool_0)
		{
			DialogResult dialogResult = MessageBox.Show("Данные были изменены. Сохранить изменения", "Сохранение", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
			if (dialogResult == DialogResult.Cancel)
			{
				e.Cancel = true;
				return;
			}
			if (dialogResult == DialogResult.Yes && !this.method_6())
			{
				e.Cancel = true;
				return;
			}
		}
	}

	private void method_2()
	{
		DataRow dataRow = this.class10_1.tTC_Contract.NewRow();
		dataRow["id"] = this.int_0;
		this.class10_1.tTC_Contract.Rows.Add(dataRow);
	}

	private void method_3()
	{
		string text = string.Concat(new string[]
		{
			"select  d.id, d.numdoc, d.datedoc,  isnull(d.numdoc, '') + ' от ' + isnull(convert( varchar(10),d.Datedoc, 104), '') as numDateDoc from ttc_doc d  where d.typeDoc = ",
			1123.ToString(),
			" and d.id not in (select doc.id  from ttc_doc doc  inner join ttc_doc dog on dog.id = doc.idParent  where doc.typeDoc = ",
			1123.ToString(),
			" and dog.typeDoc = ",
			1220.ToString(),
			")"
		});
		if (this.int_2 != -1)
		{
			text = string.Concat(new string[]
			{
				text,
				" union select  d.id, d.numdoc, d.datedoc,  isnull(d.numdoc, '') + ' от ' + isnull(convert( varchar(10),d.Datedoc, 104), '') as numDateDoc  from ttc_doc d  where d.id = ",
				this.int_2.ToString(),
				" and d.typeDoc = ",
				1123.ToString()
			});
		}
		if (this.method_0() != -1)
		{
			text = string.Concat(new string[]
			{
				text,
				" union select  d.id, d.numdoc, d.datedoc,  isnull(d.numdoc, '') + ' от ' + isnull(convert( varchar(10),d.Datedoc, 104), '') as numDateDoc  from ttc_doc dog  inner join ttc_doc d on d.idParent = dog.id and d.typeDoc = ",
				1123.ToString(),
				" where dog.id = ",
				this.method_0().ToString()
			});
		}
		text += " order by numdoc, datedoc ";
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
		this.comboBox_0.SelectedValueChanged -= this.comboBox_0_SelectedValueChanged;
		BindingSource bindingSource = new BindingSource();
		bindingSource.DataSource = dataTable;
		bindingSource.Sort = "numDoc, dateDoc";
		this.comboBox_0.DataSource = bindingSource;
		this.comboBox_0.DisplayMember = "numDateDoc";
		this.comboBox_0.ValueMember = "id";
		this.comboBox_0.SelectedValueChanged += this.comboBox_0_SelectedValueChanged;
		if (this.int_2 != -1)
		{
			this.comboBox_0.SelectedValue = this.int_2;
			return;
		}
		this.comboBox_0.SelectedIndex = -1;
	}

	private void comboBox_0_SelectedValueChanged(object sender, EventArgs e)
	{
		if (this.comboBox_0.SelectedValue != null)
		{
			if (this.comboBox_0.SelectedIndex != -1)
			{
				this.int_2 = Convert.ToInt32(this.comboBox_0.SelectedValue);
				this.method_4(this.int_2);
				return;
			}
		}
		this.textBox_2.Text = (this.textBox_3.Text = "");
		this.int_2 = -1;
	}

	private void method_4(int int_5)
	{
		Class10.Class12 @class = new Class10.Class12();
		base.SelectSqlData(@class, true, " where id = " + int_5.ToString(), null, false, 0);
		if (@class.Rows.Count <= 0)
		{
			this.int_4 = -1;
			this.int_3 = -1;
			this.textBox_3.Text = (this.textBox_2.Text = "");
			this.class10_1.vTC_RequestHistory.Clear();
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
				base.SelectSqlData(class2, true, " where id = " + int_5.ToString(), null, false, 0);
				if (class2.Rows.Count > 0 && class2.Rows[0]["idRequest"] != DBNull.Value)
				{
					num2 = Convert.ToInt32(class2.Rows[0]["idRequest"]);
					goto IL_F9;
				}
				goto IL_F9;
			}
		}
		num2 = int_5;
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
				this.int_3 = Convert.ToInt32(class4.Rows[0]["idAbn"]);
				Class10.Class11 class5 = new Class10.Class11();
				base.SelectSqlData(class5, true, "where id = " + this.int_3.ToString(), null, false, 0);
				if (class5.Rows.Count > 0)
				{
					this.textBox_3.Text = class5.Rows[0]["name"].ToString();
					int num3 = Convert.ToInt32(class5.Rows[0]["typeAbn"]);
					if (class4.Rows[0]["idAbnObj"] != DBNull.Value)
					{
						this.int_4 = Convert.ToInt32(class4.Rows[0]["idAbnObj"]);
						Class10.Class16 class6 = new Class10.Class16();
						DataColumn dataColumn = new DataColumn("AddressFL");
						dataColumn.Expression = "street + ', д. ' + houseall + ', кв. ' + name";
						class6.Columns.Add(dataColumn);
						dataColumn = new DataColumn("AddressUL");
						dataColumn.Expression = "street + ', д. ' + houseall";
						class6.Columns.Add(dataColumn);
						base.SelectSqlData(class6, true, "where id = " + this.int_4.ToString() + " order by name", null, false, 0);
						if (class6.Rows.Count > 0)
						{
							if (num3 != 206 && num3 != 253)
							{
								if (num3 != 1037)
								{
									this.textBox_2.Text = class6.Rows[0]["name"].ToString();
									goto IL_3FE;
								}
							}
							this.textBox_2.Text = class6.Rows[0]["AddressFL"].ToString();
						}
						else
						{
							this.textBox_2.Text = "";
						}
					}
					else
					{
						this.textBox_2.Text = "";
					}
				}
				else
				{
					this.textBox_3.Text = (this.textBox_2.Text = "");
				}
			}
			IL_3FE:
			base.SelectSqlData(this.class10_1, this.class10_1.vTC_RequestHistory, true, string.Concat(new string[]
			{
				"where id = ",
				num2.ToString(),
				" or IdParent = ",
				num2.ToString(),
				" order by dateDoc"
			}));
			return;
		}
		this.int_4 = -1;
		this.int_3 = -1;
		this.textBox_3.Text = (this.textBox_2.Text = "");
		this.class10_1.vTC_RequestHistory.Clear();
	}

	private bool method_5()
	{
		if (string.IsNullOrEmpty(this.textBox_0.Text))
		{
			MessageBox.Show("Не введен номер договора");
			return false;
		}
		if (this.comboBox_0.SelectedIndex < 0)
		{
			MessageBox.Show("Не выбрано тех условие");
			return false;
		}
		return true;
	}

	private bool method_6()
	{
		if (!this.method_5())
		{
			return false;
		}
		this.class10_1.tTC_Doc.Rows[0].EndEdit();
		if (this.int_0 == -1)
		{
			this.int_0 = base.InsertSqlDataOneRow(this.class10_1, this.class10_1.tTC_Doc);
			if (this.int_0 == -1)
			{
				return false;
			}
		}
		else if (!base.UpdateSqlData(this.class10_1, this.class10_1.tTC_Doc))
		{
			return false;
		}
		base.SelectSqlData(this.class10_1.tTC_Doc, true, " where id = " + this.int_0.ToString(), null, false, 0);
		this.class10_1.tTC_Contract.Rows[0]["id"] = this.int_0;
		this.class10_1.tTC_Contract.Rows[0].EndEdit();
		if (!base.InsertSqlData(this.class10_1, this.class10_1.tTC_Contract))
		{
			return false;
		}
		if (!base.UpdateSqlData(this.class10_1, this.class10_1.tTC_Contract))
		{
			return false;
		}
		this.nullableNumericUpDown_0.ValueChanged -= this.nullableNumericUpDown_0_ValueChanged;
		base.SelectSqlData(this.class10_1.tTC_Contract, true, " where id = " + this.int_0.ToString(), null, false, 0);
		this.nullableNumericUpDown_0.ValueChanged += this.nullableNumericUpDown_0_ValueChanged;
		base.SelectSqlData(this.vuBolsfjNbM, this.vuBolsfjNbM.tTC_DocOut, true, " where iddocout = " + this.int_2.ToString());
		if (this.vuBolsfjNbM.tTC_DocOut.Rows.Count > 0)
		{
			this.int_1 = Convert.ToInt32(this.vuBolsfjNbM.tTC_DocOut.Rows[0]["idDoc"]);
			if (this.class10_1.tTC_DocOut.Rows.Count > 0)
			{
				if (Convert.ToInt32(this.class10_1.tTC_DocOut.Rows[0]["idDoc"]) != this.int_1)
				{
					this.class10_1.tTC_DocOut.Rows[0]["idDoc"] = this.int_1;
					this.class10_1.tTC_DocOut.Rows[0].EndEdit();
					if (!base.UpdateSqlData(this.class10_1, this.class10_1.tTC_DocOut))
					{
						return false;
					}
				}
			}
			else if (this.vuBolsfjNbM.tTC_DocOut.Rows.Count > 0)
			{
				DataRow dataRow = this.class10_1.tTC_DocOut.NewRow();
				dataRow["idDoc"] = this.int_1;
				dataRow["idDocOut"] = this.int_0;
				this.class10_1.tTC_DocOut.Rows.Add(dataRow);
				if (!base.InsertSqlData(this.class10_1, this.class10_1.tTC_DocOut))
				{
					return false;
				}
			}
		}
		if (this.vuBolsfjNbM.tTC_Doc.Rows.Count > 0)
		{
			if (Convert.ToInt32(this.vuBolsfjNbM.tTC_Doc.Rows[0]["id"]) == this.int_2)
			{
				this.vuBolsfjNbM.tTC_Doc.Rows[0]["idParent"] = this.int_0;
				this.vuBolsfjNbM.tTC_Doc.Rows[0].EndEdit();
				if (!base.UpdateSqlData(this.vuBolsfjNbM, this.vuBolsfjNbM.tTC_Doc))
				{
					return false;
				}
			}
			else
			{
				this.vuBolsfjNbM.tTC_Doc.Rows[0]["idParent"] = DBNull.Value;
				this.vuBolsfjNbM.tTC_Doc.Rows[0].EndEdit();
				if (!base.UpdateSqlData(this.vuBolsfjNbM, this.vuBolsfjNbM.tTC_Doc))
				{
					return false;
				}
				base.SelectSqlData(this.vuBolsfjNbM, this.vuBolsfjNbM.tTC_Doc, true, " where id = " + this.int_2.ToString());
				this.vuBolsfjNbM.tTC_Doc.Rows[0]["idParent"] = this.int_0;
				this.vuBolsfjNbM.tTC_Doc.Rows[0].EndEdit();
				if (!base.UpdateSqlData(this.vuBolsfjNbM, this.vuBolsfjNbM.tTC_Doc))
				{
					return false;
				}
			}
		}
		else
		{
			base.SelectSqlData(this.vuBolsfjNbM, this.vuBolsfjNbM.tTC_Doc, true, " where id = " + this.int_2.ToString());
			if (this.vuBolsfjNbM.tTC_Doc.Rows.Count > 0)
			{
				this.vuBolsfjNbM.tTC_Doc.Rows[0]["idParent"] = this.int_0;
				this.vuBolsfjNbM.tTC_Doc.Rows[0].EndEdit();
				if (!base.UpdateSqlData(this.vuBolsfjNbM, this.vuBolsfjNbM.tTC_Doc))
				{
					return false;
				}
			}
		}
		base.SelectSqlData(this.vuBolsfjNbM, this.vuBolsfjNbM.tTC_Doc, true, " where id = " + this.int_2.ToString());
		if (!this.method_15())
		{
			return false;
		}
		if (!this.method_22())
		{
			return false;
		}
		if (!this.method_23())
		{
			return false;
		}
		this.bool_0 = false;
		return true;
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		if (this.method_6())
		{
			MessageBox.Show("Данные успешно сохранены");
		}
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		base.Close();
	}

	private void dataGridViewExcelFilter_0_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
	{
		if (e.RowIndex >= 0 && this.dataGridViewExcelFilter_0.Columns.Contains(this.dataGridViewTextBoxColumn_4) && Convert.ToInt32(this.dataGridViewExcelFilter_0[this.dataGridViewTextBoxColumn_4.Name, e.RowIndex].Value) == 1113)
		{
			e.CellStyle.Font = new System.Drawing.Font(e.CellStyle.Font, FontStyle.Bold);
			e.CellStyle.BackColor = Color.LightGray;
		}
	}

	private void dataGridViewExcelFilter_0_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
	{
		this.dataGridViewExcelFilter_0.AutoResizeRow(e.RowIndex);
	}

	private void textBox_0_TextChanged(object sender, EventArgs e)
	{
		this.bool_0 = true;
	}

	private void bkLolxvsRes_ValueChanged(object sender, EventArgs e)
	{
		this.bool_0 = true;
	}

	private void comboBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.bool_0 = true;
	}

	private void nullableNumericUpDown_0_ValueChanged(object sender, EventArgs e)
	{
		this.bool_0 = true;
		if (this.nullableNumericUpDown_0.Value == null)
		{
			if (this.class10_1.tTC_Contract.Rows.Count > 0)
			{
				this.class10_1.tTC_Contract.Rows[0]["sumContract"] = DBNull.Value;
				this.nullableNumericUpDown_1.Value = null;
				this.class10_1.tTC_Contract.Rows[0]["sumnds"] = DBNull.Value;
				return;
			}
		}
		else if (this.class10_1.tTC_Contract.Rows.Count > 0)
		{
			this.class10_1.tTC_Contract.Rows[0]["sumContract"] = this.nullableNumericUpDown_0.Value.Value;
			this.nullableNumericUpDown_1.Value = new decimal?(this.nullableNumericUpDown_0.Value.Value * 18m / 118m);
			this.class10_1.tTC_Contract.Rows[0]["sumnds"] = this.nullableNumericUpDown_0.Value.Value * 18m / 118m;
		}
	}

	private void PcTolGiItLF_ValueChanged(object sender, EventArgs e)
	{
		this.bool_0 = true;
	}

	private void textBox_1_TextChanged(object sender, EventArgs e)
	{
		this.bool_0 = true;
	}

	private string method_7(string string_1, int? nullable_0 = null, byte[] byte_0 = null)
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
				Class10.Class88 @class = this.class10_1.tTC_DocFile.method_5();
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
				this.class10_1.tTC_DocFile.method_0(@class);
				return fileName;
			}
		}
		goto IL_57;
	}

	private void method_8()
	{
		foreach (object obj in new SqlDataCommand(this.SqlSettings).SelectSqlData(" SELECT doc.id, doc.FileName  FROM tR_DocTemplate AS doc  INNER JOIN [tR_Classifier] AS c ON doc.idTypeDoc = c.id  WHERE c.ParentKey = ';TypeDoc;tR_DocTemplate;' AND c.Deleted = ((0)) AND c.isGroup = ((0)) AND c.Value = 4 and doc.deleted = 0").Rows)
		{
			DataRow dataRow = (DataRow)obj;
			ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
			toolStripMenuItem.Text = dataRow["FileName"].ToString();
			toolStripMenuItem.Tag = dataRow["id"];
			toolStripMenuItem.Click += this.method_16;
			this.toolStripDropDownButton_0.DropDownItems.Add(toolStripMenuItem);
			ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem();
			toolStripMenuItem2.Text = dataRow["FileName"].ToString();
			toolStripMenuItem2.Tag = dataRow["id"];
			toolStripMenuItem2.Click += this.method_16;
			this.toolStripMenuItem_0.DropDownItems.Add(toolStripMenuItem2);
		}
	}

	public void method_9(int int_5, out string string_1, out byte[] byte_0)
	{
		string_1 = "";
		byte_0 = null;
		string cmdText = "SELECT FileName, FileData FROM tR_DocTemplate WHERE id = @idTemplate";
		using (SqlConnection sqlConnection = new SqlConnection(this.SqlSettings.GetConnectionString()))
		{
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			sqlCommand.Parameters.Add("@idTemplate", SqlDbType.Int);
			sqlCommand.Parameters["@idTemplate"].Value = int_5;
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

	private string method_10()
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

	private void method_11(object sender, FileSystemEventArgs e)
	{
		IEnumerable<KeyValuePair<string, FileWatcherArgsAddl>> fwargs = from item in this.dictionary_0
		where item.Value.TempName == e.Name
		select item;
		if (fwargs.Count<KeyValuePair<string, FileWatcherArgsAddl>>() > 0)
		{
			FileBinary fileBinary = new FileBinary(e.FullPath);
			EnumerableRowCollection<Class10.Class88> source = from rowFiles in this.class10_1.tTC_DocFile
			where rowFiles.RowState != DataRowState.Deleted && rowFiles.FileName == fwargs.First<KeyValuePair<string, FileWatcherArgsAddl>>().Value.OriginalName
			select rowFiles;
			if (source.Count<Class10.Class88>() == 0)
			{
				Class10.Class88 @class = this.class10_1.tTC_DocFile.method_5();
				@class.idDoc = this.int_0;
				@class.FileName = fwargs.First<KeyValuePair<string, FileWatcherArgsAddl>>().Value.OriginalName;
				@class.File = fileBinary.ByteArray;
				@class.dateChange = fileBinary.LastChanged;
				@class.idTemplate = fwargs.First<KeyValuePair<string, FileWatcherArgsAddl>>().Value.IdTemplate.Value;
				this.class10_1.tTC_DocFile.Rows.Add(@class);
			}
			else
			{
				source.First<Class10.Class88>().File = fileBinary.ByteArray;
				source.First<Class10.Class88>().dateChange = fileBinary.LastChanged;
				source.First<Class10.Class88>().EndEdit();
				this.bool_0 = true;
			}
		}
		this.method_12();
	}

	private void method_12()
	{
		if (base.InvokeRequired)
		{
			base.Invoke(new Action(this.method_25));
			return;
		}
		this.bindingSource_1.ResetBindings(false);
	}

	private void method_13(bool bool_1 = false)
	{
		if (this.bindingSource_1.Current != null)
		{
			Class10.Class88 @class = (Class10.Class88)((DataRowView)this.bindingSource_1.Current).Row;
			string fileName = @class.FileName;
			string text = this.method_10();
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
						fileWatcher.AnyChanged += this.method_11;
						fileWatcher.Start();
						this.dictionary_0[fileName].Watcher = fileWatcher;
					}
					else
					{
						this.dictionary_0[fileName].Watcher.AnyChanged -= this.method_11;
						this.dictionary_0[fileName].Watcher.Stop();
						FileWatcher fileWatcher2 = new FileWatcher(text, newFileNameIsExists);
						fileWatcher2.AnyChanged += this.method_11;
						fileWatcher2.Start();
						this.dictionary_0[fileName].Watcher = fileWatcher2;
					}
					this.dictionary_0[fileName].TempName = newFileNameIsExists;
					this.dictionary_0[fileName].OpenState = FileOpenState.Editing;
					return;
				}
				FileWatcher fileWatcher3 = new FileWatcher(text, newFileNameIsExists);
				fileWatcher3.AnyChanged += this.method_11;
				fileWatcher3.Start();
				FileWatcherArgsAddl value = new FileWatcherArgsAddl(idTemplate, fileName, newFileNameIsExists, fileWatcher3, FileOpenState.Editing);
				this.dictionary_0.Add(fileName, value);
			}
		}
	}

	private void method_14(int int_5)
	{
		try
		{
			using (SqlConnection sqlConnection = new SqlConnection(this.SqlSettings.GetConnectionString()))
			{
				sqlConnection.Open();
				SqlDataReader sqlDataReader = new SqlCommand("SELECT id, idDoc, FileName, dateChange, idTemplate FROM tTC_DocFile WHERE idDoc = " + int_5.ToString(), sqlConnection).ExecuteReader();
				while (sqlDataReader.Read())
				{
					Class10.Class88 @class = this.class10_1.tTC_DocFile.method_5();
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
					this.class10_1.tTC_DocFile.Rows.Add(@class);
					@class.AcceptChanges();
					FileWatcherArgsAddl value = new FileWatcherArgsAddl(idTemplate, sqlDataReader["FileName"].ToString(), null, FileOpenState.None);
					this.dictionary_0.Add(sqlDataReader["FileName"].ToString(), value);
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, "Загрузка файлов");
		}
	}

	private bool method_15()
	{
		foreach (DataRow dataRow in this.class10_1.tTC_DocFile)
		{
			if (dataRow.RowState != DataRowState.Deleted && dataRow.RowState != DataRowState.Detached && Convert.ToInt32(dataRow["idDoc"]) != this.int_0)
			{
				dataRow["idDoc"] = this.int_0;
				dataRow.EndEdit();
			}
		}
		if (base.InsertSqlData(this.class10_1, this.class10_1.tTC_DocFile) && base.UpdateSqlDataOnlyChange(this.class10_1.tTC_DocFile) && base.DeleteSqlData(this.class10_1, this.class10_1.tTC_DocFile))
		{
			this.class10_1.tTC_DocFile.AcceptChanges();
			return true;
		}
		return false;
	}

	private void dataGridViewExcelFilter_1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
	{
		this.toolStripMenuItem_3_Click(sender, e);
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

	private void toolStripMenuItem_1_Click(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Multiselect = true;
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			foreach (string string_ in openFileDialog.FileNames)
			{
				if (!string.IsNullOrEmpty(this.method_7(string_, null, null)))
				{
					this.bool_0 = true;
				}
			}
		}
	}

	private void method_16(object sender, EventArgs e)
	{
		int num = (int)((ToolStripMenuItem)sender).Tag;
		string text;
		byte[] array;
		this.method_9(num, out text, out array);
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
		string text2 = this.method_10();
		string newFileNameIsExists = FileBinary.GetNewFileNameIsExists(text2, text, false);
		string text3 = this.method_7(text, new int?(num), array);
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
			else if (!this.method_17(text2 + "\\" + fileBinary.Name))
			{
				Process.Start(text2 + "\\" + fileBinary.Name);
			}
			if (this.dictionary_0.ContainsKey(text3))
			{
				FileWatcher fileWatcher = new FileWatcher(text2, fileBinary.Name);
				fileWatcher.AnyChanged += this.method_11;
				fileWatcher.Start();
				this.dictionary_0[text3].TempName = newFileNameIsExists;
				this.dictionary_0[text3].Watcher = fileWatcher;
				this.dictionary_0[text3].OpenState = FileOpenState.Editing;
				return;
			}
			MessageBox.Show("Что то пошло не так");
		}
	}

	private bool method_17(string string_1)
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
			if (bookmarks.Exists("DateDoc") && this.bkLolxvsRes.Value != null && this.bkLolxvsRes.Value != DBNull.Value)
			{
				bookmarks["DateDoc"].Range.Text = Convert.ToDateTime(this.bkLolxvsRes.Value).ToString("dd MMMM yyyy") + " г.";
			}
			DataRow[] array;
			if (this.comboBox_1.SelectedValue != null)
			{
				array = this.dataTable_0.Select("id = " + this.comboBox_1.SelectedValue.ToString());
			}
			else
			{
				array = null;
			}
			if (bookmarks.Exists("Face") && array != null && array.Length != 0)
			{
				bookmarks["Face"].Range.Text = array[0]["Face"].ToString();
			}
			if (bookmarks.Exists("SetDir_R") && array != null && array.Length != 0)
			{
				bookmarks["SetDir_R"].Range.Text = string.Concat(new string[]
				{
					array[0]["F_R"].ToString(),
					" ",
					array[0]["I_R"].ToString(),
					" ",
					array[0]["o_R"].ToString()
				});
			}
			if (bookmarks.Exists("SetDir_I1") && array != null && array.Length != 0)
			{
				bookmarks["SetDir_I1"].Range.Text = string.Concat(new string[]
				{
					array[0]["F_I"].ToString(),
					" ",
					array[0]["I_I"].ToString(),
					" ",
					array[0]["o_I"].ToString()
				});
			}
			if (bookmarks.Exists("SetDirUse") && array != null && array.Length != 0)
			{
				bookmarks["SetDirUse"].Range.Text = array[0]["use"].ToString();
			}
			Class10.Class11 @class = new Class10.Class11();
			base.SelectSqlData(@class, true, " where id  = " + this.int_3.ToString(), null, false, 0);
			if (@class.Rows.Count > 0)
			{
				int num = Convert.ToInt32(@class.Rows[0]["typeAbn"]);
				string text = @class.Rows[0]["name"].ToString();
				if (num == 206 || num == 253 || num == 1037)
				{
					text = "Гражданин(ка) РФ " + text;
				}
				if (bookmarks.Exists("AbnName"))
				{
					bookmarks["AbnName"].Range.Text = text;
				}
				if (bookmarks.Exists("AbnNameEnd"))
				{
					bookmarks["AbnNameEnd"].Range.Text = text;
				}
				string text4;
				if (num != 206 && num != 253)
				{
					if (num != 1037)
					{
						DataTable dataTable = base.SelectSqlData("tG_AbnChief", true, " where idAbn = " + this.int_3.ToString() + " order by datechange desc");
						if (text.IndexOf("Индивидуальный предприниматель") < 0 && text.ToUpper().IndexOf("ИП ") != 0)
						{
							string text2 = "";
							string text3 = "";
							if (dataTable.Rows.Count > 0)
							{
								text2 = dataTable.Rows[0]["r_post"].ToString();
								text3 = string.Concat(new string[]
								{
									dataTable.Rows[0]["r_f"].ToString(),
									" ",
									dataTable.Rows[0]["r_i"].ToString(),
									" ",
									dataTable.Rows[0]["r_o"].ToString()
								});
							}
							text4 = string.Concat(new string[]
							{
								", в лице ",
								text2,
								" ",
								text3,
								" действующий на основании ___________"
							});
						}
						else
						{
							text4 = ", действующий(ая) на основании Свидетельства о государственной регисктрации физического лица в качестве индивидуального препринимателя №_______________ выданное _______________";
						}
						if (dataTable.Rows.Count > 0 && bookmarks.Exists("AbnNameChief"))
						{
							bookmarks["AbnNameChief"].Range.Text = string.Concat(new string[]
							{
								dataTable.Rows[0]["i_f"].ToString(),
								" ",
								dataTable.Rows[0]["i_i"].ToString(),
								" ",
								dataTable.Rows[0]["i_o"].ToString()
							});
							goto IL_5B0;
						}
						goto IL_5B0;
					}
				}
				text4 = "(паспорт ______ выдан ______________________________________)";
				if (bookmarks.Exists("AbnNameChief"))
				{
					bookmarks["AbnNameChief"].Range.Text = text;
				}
				IL_5B0:
				if (bookmarks.Exists("AbnInfo"))
				{
					bookmarks["AbnInfo"].Range.Text = text4;
				}
			}
			DataTable dataTable2 = base.SelectSqlData("ttc_tu", true, "where id  = " + this.int_2.ToString());
			DataTable dataTable3 = base.SelectSqlData("vtc_tu", true, "where id  = " + this.int_2.ToString());
			if (dataTable2.Rows.Count > 0)
			{
				if (bookmarks.Exists("VRU"))
				{
					if (dataTable2.Rows[0]["devicename"] != DBNull.Value)
					{
						bookmarks["VRU"].Range.Text = dataTable2.Rows[0]["devicename"].ToString();
					}
					else if (dataTable3.Rows[0]["Voltagelevel"] != DBNull.Value)
					{
						bookmarks["VRU"].Range.Text = "ВРУ" + dataTable3.Rows[0]["voltagelevel"].ToString() + "кВт";
					}
					else
					{
						bookmarks["VRU"].Range.Text = "ВРУ";
					}
				}
				if (bookmarks.Exists("PowerAdd"))
				{
					if (dataTable2.Rows[0]["PowerAdd"] != DBNull.Value)
					{
						bookmarks["PowerAdd"].Range.Text = dataTable2.Rows[0]["PowerAdd"].ToString();
					}
					else
					{
						bookmarks["PowerAdd"].Range.Text = "0";
					}
				}
				if (bookmarks.Exists("PowerCurrent"))
				{
					if (dataTable2.Rows[0]["Power"] != DBNull.Value)
					{
						bookmarks["PowerCurrent"].Range.Text = dataTable2.Rows[0]["Power"].ToString();
					}
					else
					{
						bookmarks["PowerCurrent"].Range.Text = "0";
					}
				}
				if (bookmarks.Exists("VoltageLevel"))
				{
					if (dataTable3.Rows[0]["VoltageLevel"] != DBNull.Value)
					{
						bookmarks["VoltageLevel"].Range.Text = dataTable3.Rows[0]["VoltageLevel"].ToString();
					}
					else
					{
						bookmarks["VoltageLevel"].Range.Text = "0";
					}
				}
				if (bookmarks.Exists("CategoryName"))
				{
					if (dataTable3.Rows[0]["CategoryName"] != DBNull.Value)
					{
						bookmarks["CategoryName"].Range.Text = dataTable3.Rows[0]["CategoryName"].ToString();
					}
					else
					{
						bookmarks["CategoryName"].Range.Text = "0";
					}
				}
			}
			if (bookmarks.Exists("SumContract") && this.nullableNumericUpDown_0.Value != null)
			{
				bookmarks["SumContract"].Range.Text = this.nullableNumericUpDown_0.Value.ToString();
			}
			if (bookmarks.Exists("SumContractFull") && this.nullableNumericUpDown_0.Value != null)
			{
				bookmarks["SumContractFull"].Range.Text = "(" + RuDateAndMoneyConverter.CurrencyToTxt(Convert.ToDouble(this.nullableNumericUpDown_0.Value), false) + ")";
			}
			if (bookmarks.Exists("SumNDS") && this.nullableNumericUpDown_1.Value != null)
			{
				bookmarks["SumNDS"].Range.Text = this.nullableNumericUpDown_1.Value.ToString();
			}
			if (bookmarks.Exists("SumNDSFull") && this.nullableNumericUpDown_1.Value != null)
			{
				bookmarks["SumNDSFull"].Range.Text = "(" + RuDateAndMoneyConverter.CurrencyToTxt(Convert.ToDouble(this.nullableNumericUpDown_1.Value), false) + ")";
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

	private void toolStripMenuItem_2_Click(object sender, EventArgs e)
	{
		this.method_13(true);
	}

	private void toolStripMenuItem_3_Click(object sender, EventArgs e)
	{
		this.method_13(false);
	}

	private void toolStripMenuItem_4_Click(object sender, EventArgs e)
	{
		if (this.bindingSource_1.Current != null && MessageBox.Show("Вы действительно хотите удалить выбранный файл?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
		{
			Class10.Class88 @class = (Class10.Class88)((DataRowView)this.bindingSource_1.Current).Row;
			string fileName = @class.FileName;
			if (this.dictionary_0.ContainsKey(fileName))
			{
				if (this.dictionary_0[fileName].Watcher != null)
				{
					this.dictionary_0[fileName].Watcher.AnyChanged -= this.method_11;
					this.dictionary_0[fileName].Watcher.Stop();
				}
				this.dictionary_0.Remove(fileName);
			}
			@class.Delete();
			this.bool_0 = true;
		}
	}

	private void pmfzBinpoF(object sender, EventArgs e)
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

	private void toolStripMenuItem_6_Click(object sender, EventArgs e)
	{
		if (this.bindingSource_1.Current != null)
		{
			Class10.Class88 @class = (Class10.Class88)((DataRowView)this.bindingSource_1.Current).Row;
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
				this.method_18(saveFileDialog.FileName, file);
			}
		}
	}

	public bool method_18(string string_1, byte[] byte_0)
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

	private void toolStripButton_5_Click(object sender, EventArgs e)
	{
		Form22 form = new Form22();
		form.SqlSettings = this.SqlSettings;
		if (form.ShowDialog() == DialogResult.OK)
		{
			if (form.method_0() != null && form.method_1() != null)
			{
				DataRow dataRow = this.class10_0.tTC_Doc.NewRow();
				dataRow["typeDoc"] = form.method_0()["typeDoc"];
				dataRow["numDoc"] = form.method_0()["numdoc"];
				dataRow["dateDoc"] = form.method_0()["datedoc"];
				dataRow["comment"] = form.method_0()["comment"];
				this.class10_0.tTC_Doc.Rows.Add(dataRow);
				DataRow dataRow2 = this.class10_0.tTC_Payment.NewRow();
				dataRow2["id"] = dataRow["id"];
				dataRow2["summa"] = form.method_1()["summa"];
				dataRow2["idDog"] = form.method_1()["iddog"];
				this.class10_0.tTC_Payment.Rows.Add(dataRow2);
				this.method_19();
			}
			this.bool_0 = true;
		}
	}

	private void toolStripButton_6_Click(object sender, EventArgs e)
	{
		if (this.dataGridView_0.CurrentRow != null)
		{
			int num = Convert.ToInt32(this.dataGridView_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_21.Name].Value);
			DataRow[] array = this.class10_0.tTC_Doc.Select("id = " + num.ToString());
			if (array.Length != 0)
			{
				DataRow[] array2 = this.class10_0.tTC_Payment.Select("id = " + num.ToString());
				Form22 form = new Form22(array[0], (array2.Length != 0) ? array2[0] : null);
				form.SqlSettings = this.SqlSettings;
				if (form.ShowDialog() == DialogResult.OK)
				{
					if (form.method_0() != null && form.method_1() != null)
					{
						array[0]["typeDoc"] = form.method_0()["typeDoc"];
						array[0]["numDoc"] = form.method_0()["numdoc"];
						array[0]["dateDoc"] = form.method_0()["datedoc"];
						array[0]["comment"] = form.method_0()["comment"];
						if (array2.Length == 0)
						{
							DataRow dataRow = this.class10_0.tTC_Payment.NewRow();
							dataRow["id"] = array[0]["id"];
							dataRow["summa"] = form.method_1()["summa"];
							dataRow["idDog"] = form.method_1()["iddog"];
							this.class10_0.tTC_Payment.Rows.Add(dataRow);
						}
						else
						{
							array2[0]["id"] = array[0]["id"];
							array2[0]["summa"] = form.method_1()["summa"];
							array2[0]["idDog"] = form.method_1()["iddog"];
						}
						this.method_19();
					}
					this.bool_0 = true;
				}
			}
		}
	}

	private void toolStripButton_7_Click(object sender, EventArgs e)
	{
		if (this.dataGridView_0.CurrentRow != null && MessageBox.Show("Вы действительно хотите удалить текущий документ", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
		{
			int num = Convert.ToInt32(this.dataGridView_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_21.Name].Value);
			DataRow[] array = this.class10_0.tTC_Doc.Select("id = " + num.ToString());
			if (array.Length != 0)
			{
				array[0].Delete();
			}
			DataRow[] array2 = this.class10_0.tTC_Payment.Select("id = " + num.ToString());
			if (array2.Length != 0)
			{
				array2[0].Delete();
			}
			this.bool_0 = true;
			this.method_19();
		}
	}

	private void method_19()
	{
		this.dataGridView_0.Rows.Clear();
		this.class10_0.tTC_Doc.DefaultView.Sort = "dateDoc desc";
		foreach (object obj in this.class10_0.tTC_Doc.DefaultView.ToTable(true, new string[0]).Rows)
		{
			DataRow dataRow = (DataRow)obj;
			DataRow[] array = this.class10_0.tTC_Payment.Select("id = " + dataRow["id"].ToString());
			if (array.Length != 0)
			{
				this.dataGridView_0.Rows.Add(new object[]
				{
					dataRow["typeDoc"],
					dataRow["id"],
					dataRow["NumDoc"],
					dataRow["datedoc"],
					array[0]["summa"],
					dataRow["comment"],
					array[0]["iddog"]
				});
			}
			else
			{
				DataGridViewRowCollection rows = this.dataGridView_0.Rows;
				object[] array2 = new object[7];
				array2[0] = dataRow["typeDoc"];
				array2[1] = dataRow["id"];
				array2[2] = dataRow["NumDoc"];
				array2[3] = dataRow["datedoc"];
				array2[5] = dataRow["comment"];
				rows.Add(array2);
			}
		}
	}

	private void method_20()
	{
		Class10.Class14 @class = new Class10.Class14();
		base.SelectSqlData(@class, true, " where ParentKey = ';TechConnect;TypeDoc;Payment;' and isGroup = 0 and deleted = 0 order by name", null, false, 0);
		this.dataGridViewComboBoxColumn_0.ValueMember = "id";
		this.dataGridViewComboBoxColumn_0.DisplayMember = "name";
		this.dataGridViewComboBoxColumn_0.DataSource = @class;
		DataTable dataTable = new DataTable("tTC_Doc");
		dataTable.Columns.Add(new DataColumn("id", typeof(int)));
		dataTable.Columns.Add(new DataColumn("numDoc", typeof(string)));
		dataTable.Columns.Add(new DataColumn("dateDoc", typeof(DateTime)));
		dataTable.Columns.Add(new DataColumn("numdate", typeof(string), "isnull(numDoc, '') + ' от ' + substring(isnull(Convert(dateDoc, 'System.String'), '          '), 1, 10)"));
		base.SelectSqlData(dataTable, true, " where typeDoc = " + 1220.ToString() + " order by numDoc, dateDoc", null, false, 0);
		this.dataGridViewComboBoxColumn_1.ValueMember = "id";
		this.dataGridViewComboBoxColumn_1.DisplayMember = "numdate";
		this.dataGridViewComboBoxColumn_1.DataSource = dataTable;
	}

	private void dataGridView_0_DataError(object sender, DataGridViewDataErrorEventArgs e)
	{
		if (e.Exception.Message == "DataGridViewComboBoxCell value is not valid.")
		{
			object value = this.dataGridView_0.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
			if (!((DataGridViewComboBoxColumn)this.dataGridView_0.Columns[e.ColumnIndex]).Items.Contains(value))
			{
				((DataGridViewComboBoxColumn)this.dataGridView_0.Columns[e.ColumnIndex]).Items.Add(value);
				e.ThrowException = false;
			}
		}
	}

	private void dataGridView_0_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
	{
		if (this.toolStripButton_6.Visible && this.toolStripButton_6.Enabled)
		{
			this.toolStripButton_6_Click(sender, e);
		}
	}

	private void method_21()
	{
		string text = "";
		foreach (object obj in Enum.GetValues(typeof(Enum5)))
		{
			Enum5 @enum = (Enum5)obj;
			if (string.IsNullOrEmpty(text))
			{
				int num = (int)@enum;
				text = num.ToString();
			}
			else
			{
				string str = text;
				string str2 = ",";
				int num = (int)@enum;
				text = str + str2 + num.ToString();
			}
		}
		base.SelectSqlData(this.class10_0, this.class10_0.tTC_Doc, true, string.Concat(new string[]
		{
			" where idParent = ",
			this.int_0.ToString(),
			" and typeDoc in (",
			text,
			")"
		}));
		base.SelectSqlData(this.class10_0, this.class10_0.tTC_Payment, true, string.Concat(new string[]
		{
			" where id in (select id from ttc_doc where idParent= ",
			this.int_0.ToString(),
			" and typeDoc in (",
			text,
			"))"
		}));
		this.method_19();
	}

	private bool method_22()
	{
		foreach (DataRow dataRow in this.class10_0.tTC_Doc)
		{
			if (dataRow.RowState != DataRowState.Deleted)
			{
				dataRow["idParent"] = this.int_0;
				dataRow.EndEdit();
			}
		}
		DataTable changes = this.class10_0.tTC_Doc.GetChanges(DataRowState.Added);
		if (changes != null && changes.Rows.Count > 0)
		{
			foreach (object obj in changes.Rows)
			{
				DataRow dataRow2 = (DataRow)obj;
				int num = Convert.ToInt32(dataRow2["id"]);
				int num2 = base.InsertSqlDataOneRow(dataRow2);
				DataRow[] array = this.class10_0.tTC_Payment.Select("id =" + num.ToString());
				if (array.Length != 0)
				{
					array[0]["id"] = num2;
					array[0].EndEdit();
				}
			}
		}
		if (!base.InsertSqlData(this.class10_0, this.class10_0.tTC_Payment))
		{
			return false;
		}
		if (!base.UpdateSqlData(this.class10_0, this.class10_0.tTC_Doc))
		{
			return false;
		}
		if (!base.UpdateSqlData(this.class10_0, this.class10_0.tTC_Payment))
		{
			return false;
		}
		if (!base.DeleteSqlData(this.class10_0, this.class10_0.tTC_Doc))
		{
			return false;
		}
		if (!base.DeleteSqlData(this.class10_0, this.class10_0.tTC_Payment))
		{
			return false;
		}
		this.method_21();
		return true;
	}

	private void dataGridView_1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex >= 0 && (this.dataGridView_1[this.dataGridViewTextBoxColumn_27.Name, e.RowIndex].Value == DBNull.Value || Convert.ToInt32(this.dataGridView_1[this.dataGridViewTextBoxColumn_27.Name, e.RowIndex].Value) != this.int_0))
		{
			this.dataGridView_1[this.dataGridViewTextBoxColumn_27.Name, e.RowIndex].Value = this.int_0;
		}
	}

	private bool method_23()
	{
		foreach (DataRow dataRow in this.class10_1.tTC_PaymentShedule)
		{
			if (dataRow.RowState != DataRowState.Deleted)
			{
				dataRow["idDoc"] = this.int_0;
				dataRow.EndEdit();
			}
		}
		if (!base.InsertSqlData(this.class10_1, this.class10_1.tTC_PaymentShedule))
		{
			return false;
		}
		if (!base.UpdateSqlData(this.class10_1, this.class10_1.tTC_PaymentShedule))
		{
			return false;
		}
		if (!base.DeleteSqlData(this.class10_1, this.class10_1.tTC_PaymentShedule))
		{
			return false;
		}
		base.SelectSqlData(this.class10_1.tTC_PaymentShedule, true, " where idDoc = " + this.int_0.ToString() + " order by DateShedule", null, false, 0);
		return true;
	}

	private void Ttgolyiriw2()
	{
		DataTable dataTable = base.SelectSqlData("tSettings", true, " where module = 'TCContractWord'");
		this.dataTable_0.Columns.Add("id", typeof(int));
		this.dataTable_0.Columns.Add("name", typeof(string));
		this.dataTable_0.Columns.Add("face", typeof(string));
		this.dataTable_0.Columns.Add("f_r", typeof(string));
		this.dataTable_0.Columns.Add("i_r", typeof(string));
		this.dataTable_0.Columns.Add("o_r", typeof(string));
		this.dataTable_0.Columns.Add("f_i", typeof(string));
		this.dataTable_0.Columns.Add("i_i", typeof(string));
		this.dataTable_0.Columns.Add("o_i", typeof(string));
		this.dataTable_0.Columns.Add("use", typeof(string));
		if (dataTable.Rows.Count > 0 && dataTable.Rows[0]["Settings"] != DBNull.Value)
		{
			try
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.LoadXml(dataTable.Rows[0]["Settings"].ToString());
				XmlNode xmlNode = xmlDocument.SelectSingleNode("document");
				if (xmlNode != null)
				{
					foreach (object obj in xmlNode.SelectNodes("Row"))
					{
						XmlNode xmlNode2 = (XmlNode)obj;
						this.dataTable_0.Rows.Add(new object[]
						{
							Convert.ToInt32(xmlNode2.Attributes["Id"].Value),
							string.Concat(new string[]
							{
								xmlNode2.Attributes["Face"].Value,
								" ",
								xmlNode2.Attributes["F_R"].Value,
								" ",
								xmlNode2.Attributes["I_R"].Value,
								" ",
								xmlNode2.Attributes["O_R"].Value
							}),
							xmlNode2.Attributes["Face"].Value,
							xmlNode2.Attributes["F_R"].Value,
							xmlNode2.Attributes["I_R"].Value,
							xmlNode2.Attributes["O_R"].Value,
							xmlNode2.Attributes["F_I"].Value,
							xmlNode2.Attributes["I_I"].Value,
							xmlNode2.Attributes["O_I"].Value,
							xmlNode2.Attributes["use"].Value
						});
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, ex.Source);
			}
		}
		this.comboBox_1.DisplayMember = "name";
		this.comboBox_1.ValueMember = "id";
		this.comboBox_1.DataSource = this.dataTable_0;
	}

	private void method_24()
	{
		this.icontainer_0 = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
		this.label_0 = new Label();
		this.textBox_0 = new TextBox();
		this.class10_1 = new Class10();
		this.bkLolxvsRes = new NullableDateTimePicker();
		this.button_0 = new Button();
		this.button_1 = new Button();
		this.bTpoltpxnYl = new Label();
		this.textBox_1 = new TextBox();
		this.label_1 = new Label();
		this.tabControl_0 = new TabControl();
		this.tabPage_0 = new TabPage();
		this.comboBox_1 = new ComboBox();
		this.label_10 = new Label();
		this.nullableNumericUpDown_1 = new NullableNumericUpDown();
		this.label_9 = new Label();
		this.nullableDateTimePicker_0 = new NullableDateTimePicker();
		this.label_7 = new Label();
		this.nullableDateTimePicker_1 = new NullableDateTimePicker();
		this.label_8 = new Label();
		this.PcTolGiItLF = new NullableDateTimePicker();
		this.label_5 = new Label();
		this.nullableNumericUpDown_0 = new NullableNumericUpDown();
		this.label_6 = new Label();
		this.label_2 = new Label();
		this.textBox_2 = new TextBox();
		this.label_3 = new Label();
		this.comboBox_0 = new ComboBox();
		this.textBox_3 = new TextBox();
		this.label_4 = new Label();
		this.tabPage_1 = new TabPage();
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
		this.dataGridViewTextBoxColumn_11 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_12 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_13 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_14 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_15 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_16 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_17 = new DataGridViewTextBoxColumn();
		this.bindingSource_0 = new BindingSource(this.icontainer_0);
		this.tabPage_2 = new TabPage();
		this.dataGridViewExcelFilter_1 = new DataGridViewExcelFilter();
		this.dataGridViewImageColumnNotNull_0 = new DataGridViewImageColumnNotNull();
		this.dataGridViewFilterTextBoxColumn_0 = new DataGridViewFilterTextBoxColumn();
		this.dataGridViewTextBoxColumn_18 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_19 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_20 = new DataGridViewTextBoxColumn();
		this.bindingSource_1 = new BindingSource(this.icontainer_0);
		this.toolStrip_0 = new ToolStrip();
		this.toolStripDropDownButton_0 = new ToolStripDropDownButton();
		this.mwcooynIkAe = new ToolStripMenuItem();
		this.toolStripSeparator_0 = new ToolStripSeparator();
		this.toolStripButton_0 = new ToolStripButton();
		this.toolStripButton_1 = new ToolStripButton();
		this.toolStripButton_2 = new ToolStripButton();
		this.toolStripSeparator_1 = new ToolStripSeparator();
		this.toolStripButton_3 = new ToolStripButton();
		this.toolStripButton_4 = new ToolStripButton();
		this.SuvoovyfcoT = new TabPage();
		this.dataGridView_0 = new DataGridView();
		this.dataGridViewComboBoxColumn_0 = new DataGridViewComboBoxColumn();
		this.dataGridViewTextBoxColumn_21 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_22 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_23 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_24 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_25 = new DataGridViewTextBoxColumn();
		this.dataGridViewComboBoxColumn_1 = new DataGridViewComboBoxColumn();
		this.toolStrip_1 = new ToolStrip();
		this.toolStripButton_5 = new ToolStripButton();
		this.toolStripButton_6 = new ToolStripButton();
		this.toolStripButton_7 = new ToolStripButton();
		this.tabPage_3 = new TabPage();
		this.dataGridView_1 = new DataGridView();
		this.dataGridViewFilterDateTimePickerColumn_0 = new DataGridViewFilterDateTimePickerColumn();
		this.dataGridViewTextBoxColumn_26 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_27 = new DataGridViewTextBoxColumn();
		this.dataGridViewNumericColumn_0 = new DataGridViewNumericColumn();
		this.dataGridViewTextBoxColumn_28 = new DataGridViewTextBoxColumn();
		this.cKuooUatTyq = new BindingSource(this.icontainer_0);
		this.toolStrip_2 = new ToolStrip();
		this.toolStripButton_8 = new ToolStripButton();
		this.toolStripButton_9 = new ToolStripButton();
		this.toolStripButton_10 = new ToolStripButton();
		this.contextMenuStrip_0 = new ContextMenuStrip(this.icontainer_0);
		this.toolStripMenuItem_0 = new ToolStripMenuItem();
		this.toolStripMenuItem_1 = new ToolStripMenuItem();
		this.toolStripSeparator_2 = new ToolStripSeparator();
		this.toolStripMenuItem_2 = new ToolStripMenuItem();
		this.toolStripMenuItem_3 = new ToolStripMenuItem();
		this.toolStripMenuItem_4 = new ToolStripMenuItem();
		this.cplooIfVoRt = new ToolStripSeparator();
		this.toolStripMenuItem_5 = new ToolStripMenuItem();
		this.toolStripMenuItem_6 = new ToolStripMenuItem();
		((ISupportInitialize)this.class10_1).BeginInit();
		this.tabControl_0.SuspendLayout();
		this.tabPage_0.SuspendLayout();
		((ISupportInitialize)this.nullableNumericUpDown_1).BeginInit();
		((ISupportInitialize)this.nullableNumericUpDown_0).BeginInit();
		this.tabPage_1.SuspendLayout();
		((ISupportInitialize)this.dataGridViewExcelFilter_0).BeginInit();
		((ISupportInitialize)this.bindingSource_0).BeginInit();
		this.tabPage_2.SuspendLayout();
		((ISupportInitialize)this.dataGridViewExcelFilter_1).BeginInit();
		((ISupportInitialize)this.bindingSource_1).BeginInit();
		this.toolStrip_0.SuspendLayout();
		this.SuvoovyfcoT.SuspendLayout();
		((ISupportInitialize)this.dataGridView_0).BeginInit();
		this.toolStrip_1.SuspendLayout();
		this.tabPage_3.SuspendLayout();
		((ISupportInitialize)this.dataGridView_1).BeginInit();
		((ISupportInitialize)this.cKuooUatTyq).BeginInit();
		this.toolStrip_2.SuspendLayout();
		this.contextMenuStrip_0.SuspendLayout();
		base.SuspendLayout();
		this.label_0.AutoSize = true;
		this.label_0.Location = new Point(9, 9);
		this.label_0.Name = "label2";
		this.label_0.Size = new Size(124, 13);
		this.label_0.TabIndex = 2;
		this.label_0.Text = "Номер договора на ТП";
		this.textBox_0.DataBindings.Add(new Binding("Text", this.class10_1, "tTC_Doc.numDoc", true));
		this.textBox_0.Location = new Point(12, 25);
		this.textBox_0.Name = "txtNumDocOut";
		this.textBox_0.Size = new Size(198, 20);
		this.textBox_0.TabIndex = 3;
		this.textBox_0.TextChanged += this.textBox_0_TextChanged;
		this.class10_1.DataSetName = "DataSetTechConnection";
		this.class10_1.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		this.bkLolxvsRes.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.bkLolxvsRes.DataBindings.Add(new Binding("Value", this.class10_1, "tTC_Doc.dateDoc", true));
		this.bkLolxvsRes.Location = new Point(230, 25);
		this.bkLolxvsRes.Name = "dateTimePickerDocOut";
		this.bkLolxvsRes.Size = new Size(224, 20);
		this.bkLolxvsRes.TabIndex = 4;
		this.bkLolxvsRes.Value = new DateTime(2013, 4, 29, 14, 38, 3, 750);
		this.bkLolxvsRes.ValueChanged += this.bkLolxvsRes_ValueChanged;
		this.button_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.button_0.Location = new Point(12, 414);
		this.button_0.Name = "buttonSave";
		this.button_0.Size = new Size(75, 23);
		this.button_0.TabIndex = 11;
		this.button_0.Text = "Сохранить";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_0.Click += this.button_0_Click;
		this.button_1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.button_1.DialogResult = DialogResult.Cancel;
		this.button_1.Location = new Point(379, 414);
		this.button_1.Name = "buttonCancel";
		this.button_1.Size = new Size(75, 23);
		this.button_1.TabIndex = 12;
		this.button_1.Text = "Закрыть";
		this.button_1.UseVisualStyleBackColor = true;
		this.button_1.Click += this.button_1_Click;
		this.bTpoltpxnYl.AutoSize = true;
		this.bTpoltpxnYl.Location = new Point(7, 250);
		this.bTpoltpxnYl.Name = "label6";
		this.bTpoltpxnYl.Size = new Size(77, 13);
		this.bTpoltpxnYl.TabIndex = 9;
		this.bTpoltpxnYl.Text = "Комментарий";
		this.textBox_1.AcceptsReturn = true;
		this.textBox_1.AcceptsTab = true;
		this.textBox_1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_1.DataBindings.Add(new Binding("Text", this.class10_1, "tTC_Doc.Comment", true));
		this.textBox_1.Location = new Point(10, 266);
		this.textBox_1.Multiline = true;
		this.textBox_1.Name = "txtComment";
		this.textBox_1.Size = new Size(439, 59);
		this.textBox_1.TabIndex = 10;
		this.textBox_1.TextChanged += this.textBox_1_TextChanged;
		this.label_1.AutoSize = true;
		this.label_1.Location = new Point(227, 9);
		this.label_1.Name = "label1";
		this.label_1.Size = new Size(116, 13);
		this.label_1.TabIndex = 17;
		this.label_1.Text = "Дата договора на ТП";
		this.tabControl_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.tabControl_0.Controls.Add(this.tabPage_0);
		this.tabControl_0.Controls.Add(this.tabPage_1);
		this.tabControl_0.Controls.Add(this.tabPage_2);
		this.tabControl_0.Controls.Add(this.SuvoovyfcoT);
		this.tabControl_0.Controls.Add(this.tabPage_3);
		this.tabControl_0.Location = new Point(1, 51);
		this.tabControl_0.Name = "tabControl1";
		this.tabControl_0.SelectedIndex = 0;
		this.tabControl_0.Size = new Size(463, 357);
		this.tabControl_0.TabIndex = 18;
		this.tabPage_0.Controls.Add(this.comboBox_1);
		this.tabPage_0.Controls.Add(this.label_10);
		this.tabPage_0.Controls.Add(this.nullableNumericUpDown_1);
		this.tabPage_0.Controls.Add(this.label_9);
		this.tabPage_0.Controls.Add(this.nullableDateTimePicker_0);
		this.tabPage_0.Controls.Add(this.label_7);
		this.tabPage_0.Controls.Add(this.nullableDateTimePicker_1);
		this.tabPage_0.Controls.Add(this.label_8);
		this.tabPage_0.Controls.Add(this.PcTolGiItLF);
		this.tabPage_0.Controls.Add(this.label_5);
		this.tabPage_0.Controls.Add(this.textBox_1);
		this.tabPage_0.Controls.Add(this.nullableNumericUpDown_0);
		this.tabPage_0.Controls.Add(this.bTpoltpxnYl);
		this.tabPage_0.Controls.Add(this.label_6);
		this.tabPage_0.Controls.Add(this.label_2);
		this.tabPage_0.Controls.Add(this.textBox_2);
		this.tabPage_0.Controls.Add(this.label_3);
		this.tabPage_0.Controls.Add(this.comboBox_0);
		this.tabPage_0.Controls.Add(this.textBox_3);
		this.tabPage_0.Controls.Add(this.label_4);
		this.tabPage_0.Location = new Point(4, 22);
		this.tabPage_0.Name = "tabPageGeneral";
		this.tabPage_0.Padding = new Padding(3);
		this.tabPage_0.Size = new Size(455, 331);
		this.tabPage_0.TabIndex = 0;
		this.tabPage_0.Text = "Общие";
		this.tabPage_0.UseVisualStyleBackColor = true;
		this.comboBox_1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.comboBox_1.DataBindings.Add(new Binding("SelectedValue", this.class10_1, "tTC_Contract.idSettingWord", true));
		this.comboBox_1.FormattingEnabled = true;
		this.comboBox_1.Location = new Point(10, 218);
		this.comboBox_1.Name = "cmbSetFace";
		this.comboBox_1.Size = new Size(439, 21);
		this.comboBox_1.TabIndex = 23;
		this.label_10.AutoSize = true;
		this.label_10.Location = new Point(7, 202);
		this.label_10.Name = "label11";
		this.label_10.Size = new Size(147, 13);
		this.label_10.TabIndex = 22;
		this.label_10.Text = "Сетевая оргнизация в лице";
		this.nullableNumericUpDown_1.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.nullableNumericUpDown_1.DataBindings.Add(new Binding("Value", this.class10_1, "tTC_Contract.SumNDS", true));
		this.nullableNumericUpDown_1.DecimalPlaces = 2;
		this.nullableNumericUpDown_1.Location = new Point(355, 90);
		NumericUpDown numericUpDown = this.nullableNumericUpDown_1;
		int[] array = new int[4];
		array[0] = 999999999;
		numericUpDown.Maximum = new decimal(array);
		this.nullableNumericUpDown_1.Name = "numSumNDS";
		this.nullableNumericUpDown_1.Size = new Size(94, 20);
		this.nullableNumericUpDown_1.TabIndex = 21;
		this.nullableNumericUpDown_1.Value = null;
		this.label_9.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.label_9.AutoSize = true;
		this.label_9.Location = new Point(255, 97);
		this.label_9.Name = "label10";
		this.label_9.Size = new Size(94, 13);
		this.label_9.TabIndex = 20;
		this.label_9.Text = "в том числе НДС";
		this.nullableDateTimePicker_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.nullableDateTimePicker_0.DataBindings.Add(new Binding("Value", this.class10_1, "tTC_Contract.DateImplFact", true));
		this.nullableDateTimePicker_0.Location = new Point(223, 168);
		this.nullableDateTimePicker_0.Name = "dtpImplFact";
		this.nullableDateTimePicker_0.Size = new Size(226, 20);
		this.nullableDateTimePicker_0.TabIndex = 19;
		this.nullableDateTimePicker_0.Value = new DateTime(2014, 2, 10, 13, 59, 54, 128);
		this.label_7.AutoSize = true;
		this.label_7.Location = new Point(7, 174);
		this.label_7.Name = "label8";
		this.label_7.Size = new Size(210, 13);
		this.label_7.TabIndex = 18;
		this.label_7.Text = "Дата фактического выполнения мер-ий";
		this.nullableDateTimePicker_1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.nullableDateTimePicker_1.DataBindings.Add(new Binding("Value", this.class10_1, "tTC_Contract.DateBegFact", true));
		this.nullableDateTimePicker_1.Location = new Point(223, 142);
		this.nullableDateTimePicker_1.Name = "dtpBegFact";
		this.nullableDateTimePicker_1.Size = new Size(226, 20);
		this.nullableDateTimePicker_1.TabIndex = 17;
		this.nullableDateTimePicker_1.Value = new DateTime(2014, 2, 10, 13, 59, 54, 128);
		this.label_8.AutoSize = true;
		this.label_8.Location = new Point(7, 148);
		this.label_8.Name = "label7";
		this.label_8.Size = new Size(177, 13);
		this.label_8.TabIndex = 16;
		this.label_8.Text = "Дата начала действия (возврата)";
		this.PcTolGiItLF.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.PcTolGiItLF.DataBindings.Add(new Binding("Value", this.class10_1, "tTC_Contract.DatePerfomance", true));
		this.PcTolGiItLF.Location = new Point(107, 116);
		this.PcTolGiItLF.Name = "nullableDateTimePicker1";
		this.PcTolGiItLF.Size = new Size(342, 20);
		this.PcTolGiItLF.TabIndex = 15;
		this.PcTolGiItLF.Value = new DateTime(2014, 2, 10, 13, 59, 54, 128);
		this.PcTolGiItLF.ValueChanged += this.PcTolGiItLF_ValueChanged;
		this.label_5.AutoSize = true;
		this.label_5.Location = new Point(7, 122);
		this.label_5.Name = "label4";
		this.label_5.Size = new Size(95, 13);
		this.label_5.TabIndex = 14;
		this.label_5.Text = "Срок исполнения";
		this.nullableNumericUpDown_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.nullableNumericUpDown_0.DataBindings.Add(new Binding("Value", this.class10_1, "tTC_Contract.SumContract", true));
		this.nullableNumericUpDown_0.DecimalPlaces = 2;
		this.nullableNumericUpDown_0.Location = new Point(107, 90);
		NumericUpDown numericUpDown2 = this.nullableNumericUpDown_0;
		int[] array2 = new int[4];
		array2[0] = 999999999;
		numericUpDown2.Maximum = new decimal(array2);
		this.nullableNumericUpDown_0.Name = "numSumContract";
		this.nullableNumericUpDown_0.Size = new Size(142, 20);
		this.nullableNumericUpDown_0.TabIndex = 13;
		this.nullableNumericUpDown_0.Value = null;
		this.nullableNumericUpDown_0.ValueChanged += this.nullableNumericUpDown_0_ValueChanged;
		this.label_6.AutoSize = true;
		this.label_6.Location = new Point(7, 97);
		this.label_6.Name = "label3";
		this.label_6.Size = new Size(83, 13);
		this.label_6.TabIndex = 12;
		this.label_6.Text = "Цена договора";
		this.label_2.AutoSize = true;
		this.label_2.Location = new Point(7, 59);
		this.label_2.Name = "label5";
		this.label_2.Size = new Size(45, 13);
		this.label_2.TabIndex = 10;
		this.label_2.Text = "Объект";
		this.textBox_2.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_2.BackColor = SystemColors.Window;
		this.textBox_2.Location = new Point(107, 56);
		this.textBox_2.Name = "txtAbnObj";
		this.textBox_2.ReadOnly = true;
		this.textBox_2.Size = new Size(342, 20);
		this.textBox_2.TabIndex = 11;
		this.label_3.AutoSize = true;
		this.label_3.Location = new Point(7, 9);
		this.label_3.Name = "labelNumDateIn";
		this.label_3.Size = new Size(94, 13);
		this.label_3.TabIndex = 6;
		this.label_3.Text = "Номер и дата ТУ";
		this.comboBox_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.comboBox_0.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBox_0.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBox_0.FormattingEnabled = true;
		this.comboBox_0.Location = new Point(107, 6);
		this.comboBox_0.Name = "cmbNumDateIn";
		this.comboBox_0.Size = new Size(342, 21);
		this.comboBox_0.TabIndex = 7;
		this.comboBox_0.SelectedIndexChanged += this.comboBox_0_SelectedIndexChanged;
		this.comboBox_0.SelectedValueChanged += this.comboBox_0_SelectedValueChanged;
		this.textBox_3.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_3.BackColor = SystemColors.Window;
		this.textBox_3.Location = new Point(107, 32);
		this.textBox_3.Name = "txtAbn";
		this.textBox_3.ReadOnly = true;
		this.textBox_3.Size = new Size(342, 20);
		this.textBox_3.TabIndex = 9;
		this.label_4.AutoSize = true;
		this.label_4.Location = new Point(7, 35);
		this.label_4.Name = "label9";
		this.label_4.Size = new Size(49, 13);
		this.label_4.TabIndex = 8;
		this.label_4.Text = "Абонент";
		this.tabPage_1.Controls.Add(this.dataGridViewExcelFilter_0);
		this.tabPage_1.Location = new Point(4, 22);
		this.tabPage_1.Name = "tabPageHistoryRequest";
		this.tabPage_1.Padding = new Padding(3);
		this.tabPage_1.Size = new Size(455, 331);
		this.tabPage_1.TabIndex = 1;
		this.tabPage_1.Text = "История заявок";
		this.tabPage_1.UseVisualStyleBackColor = true;
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
			this.dataGridViewTextBoxColumn_11,
			this.dataGridViewTextBoxColumn_12,
			this.dataGridViewTextBoxColumn_13,
			this.dataGridViewTextBoxColumn_14,
			this.dataGridViewTextBoxColumn_15,
			this.dataGridViewTextBoxColumn_16,
			this.dataGridViewTextBoxColumn_17
		});
		this.dataGridViewExcelFilter_0.DataSource = this.bindingSource_0;
		this.dataGridViewExcelFilter_0.Dock = DockStyle.Fill;
		this.dataGridViewExcelFilter_0.Location = new Point(3, 3);
		this.dataGridViewExcelFilter_0.MultiSelect = false;
		this.dataGridViewExcelFilter_0.Name = "dgvRequestHistory";
		this.dataGridViewExcelFilter_0.ReadOnly = true;
		this.dataGridViewExcelFilter_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		this.dataGridViewExcelFilter_0.Size = new Size(449, 325);
		this.dataGridViewExcelFilter_0.TabIndex = 6;
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
		this.dataGridViewTextBoxColumn_11.DataPropertyName = "PowerAdd";
		this.dataGridViewTextBoxColumn_11.HeaderText = "Доп мощность";
		this.dataGridViewTextBoxColumn_11.Name = "PowerAddDgvColumn";
		this.dataGridViewTextBoxColumn_11.ReadOnly = true;
		this.dataGridViewTextBoxColumn_11.Width = 70;
		this.dataGridViewTextBoxColumn_12.DataPropertyName = "Power";
		this.dataGridViewTextBoxColumn_12.HeaderText = "Суммарная мощность";
		this.dataGridViewTextBoxColumn_12.Name = "powerDataGridViewTextBoxColumn1";
		this.dataGridViewTextBoxColumn_12.ReadOnly = true;
		this.dataGridViewTextBoxColumn_12.Width = 70;
		this.dataGridViewTextBoxColumn_13.DataPropertyName = "VoltageName";
		this.dataGridViewTextBoxColumn_13.HeaderText = "Напряжение";
		this.dataGridViewTextBoxColumn_13.Name = "voltageNameDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_13.ReadOnly = true;
		this.dataGridViewTextBoxColumn_13.Width = 70;
		this.dataGridViewTextBoxColumn_14.DataPropertyName = "Comment";
		this.dataGridViewTextBoxColumn_14.HeaderText = "Комментарий";
		this.dataGridViewTextBoxColumn_14.Name = "commentDataGridViewTextBoxColumn1";
		this.dataGridViewTextBoxColumn_14.ReadOnly = true;
		this.dataGridViewTextBoxColumn_14.Width = 70;
		this.dataGridViewTextBoxColumn_15.DataPropertyName = "VoltageLevel";
		this.dataGridViewTextBoxColumn_15.HeaderText = "VoltageLevel";
		this.dataGridViewTextBoxColumn_15.Name = "voltageLevelDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_15.ReadOnly = true;
		this.dataGridViewTextBoxColumn_15.Visible = false;
		this.dataGridViewTextBoxColumn_16.DataPropertyName = "VoltageValue";
		this.dataGridViewTextBoxColumn_16.HeaderText = "VoltageValue";
		this.dataGridViewTextBoxColumn_16.Name = "voltageValueDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_16.ReadOnly = true;
		this.dataGridViewTextBoxColumn_16.Visible = false;
		this.dataGridViewTextBoxColumn_17.DataPropertyName = "IdParent";
		this.dataGridViewTextBoxColumn_17.HeaderText = "IdParent";
		this.dataGridViewTextBoxColumn_17.Name = "idParentDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_17.ReadOnly = true;
		this.dataGridViewTextBoxColumn_17.Visible = false;
		this.bindingSource_0.DataMember = "vTC_RequestHistory";
		this.bindingSource_0.DataSource = this.class10_1;
		this.tabPage_2.Controls.Add(this.dataGridViewExcelFilter_1);
		this.tabPage_2.Controls.Add(this.toolStrip_0);
		this.tabPage_2.Location = new Point(4, 22);
		this.tabPage_2.Name = "tabPageFiles";
		this.tabPage_2.Padding = new Padding(3);
		this.tabPage_2.Size = new Size(455, 331);
		this.tabPage_2.TabIndex = 2;
		this.tabPage_2.Text = "Файлы";
		this.tabPage_2.UseVisualStyleBackColor = true;
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
			this.dataGridViewTextBoxColumn_18,
			this.dataGridViewTextBoxColumn_19,
			this.dataGridViewTextBoxColumn_20
		});
		this.dataGridViewExcelFilter_1.DataSource = this.bindingSource_1;
		this.dataGridViewExcelFilter_1.Dock = DockStyle.Fill;
		this.dataGridViewExcelFilter_1.EditMode = DataGridViewEditMode.EditProgrammatically;
		this.dataGridViewExcelFilter_1.Location = new Point(3, 28);
		this.dataGridViewExcelFilter_1.Name = "dgvFile";
		this.dataGridViewExcelFilter_1.ReadOnly = true;
		this.dataGridViewExcelFilter_1.RowHeadersVisible = false;
		this.dataGridViewExcelFilter_1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		this.dataGridViewExcelFilter_1.Size = new Size(449, 300);
		this.dataGridViewExcelFilter_1.TabIndex = 8;
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
		this.bindingSource_1.DataMember = "tTC_DocFile";
		this.bindingSource_1.DataSource = this.class10_1;
		this.toolStrip_0.Items.AddRange(new ToolStripItem[]
		{
			this.toolStripDropDownButton_0,
			this.toolStripButton_0,
			this.toolStripButton_1,
			this.toolStripButton_2,
			this.toolStripSeparator_1,
			this.toolStripButton_3,
			this.toolStripButton_4
		});
		this.toolStrip_0.Location = new Point(3, 3);
		this.toolStrip_0.Name = "toolStripFile";
		this.toolStrip_0.Size = new Size(449, 25);
		this.toolStrip_0.TabIndex = 2;
		this.toolStrip_0.Text = "toolStrip1";
		this.toolStripDropDownButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripDropDownButton_0.DropDownItems.AddRange(new ToolStripItem[]
		{
			this.mwcooynIkAe,
			this.toolStripSeparator_0
		});
		this.toolStripDropDownButton_0.Image = Resources.ElementAdd;
		this.toolStripDropDownButton_0.ImageTransparentColor = Color.Magenta;
		this.toolStripDropDownButton_0.Name = "toolBtnAddFile";
		this.toolStripDropDownButton_0.Size = new Size(29, 22);
		this.toolStripDropDownButton_0.Text = "Добавить файл";
		this.mwcooynIkAe.Name = "toolItemAddExistFile";
		this.mwcooynIkAe.Size = new Size(190, 22);
		this.mwcooynIkAe.Text = "Сущесвующий файл";
		this.mwcooynIkAe.Click += this.toolStripMenuItem_1_Click;
		this.toolStripSeparator_0.Name = "toolStripSeparator2";
		this.toolStripSeparator_0.Size = new Size(187, 6);
		this.toolStripButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_0.Image = Resources.ElementEdit;
		this.toolStripButton_0.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_0.Name = "toolBtnEditFile";
		this.toolStripButton_0.Size = new Size(23, 22);
		this.toolStripButton_0.Text = "Редактировать файл";
		this.toolStripButton_0.Click += this.toolStripMenuItem_2_Click;
		this.toolStripButton_1.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_1.Image = Resources.ElementInformation;
		this.toolStripButton_1.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_1.Name = "toolBtnOpenFile";
		this.toolStripButton_1.Size = new Size(23, 22);
		this.toolStripButton_1.Text = "Открыть файл";
		this.toolStripButton_1.Click += this.toolStripMenuItem_3_Click;
		this.toolStripButton_2.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_2.Image = Resources.ElementDel;
		this.toolStripButton_2.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_2.Name = "toolBtnDelFile";
		this.toolStripButton_2.Size = new Size(23, 22);
		this.toolStripButton_2.Text = "Удалить файл";
		this.toolStripButton_2.Click += this.toolStripMenuItem_4_Click;
		this.toolStripSeparator_1.Name = "toolStripSeparator3";
		this.toolStripSeparator_1.Size = new Size(6, 25);
		this.toolStripButton_3.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_3.Image = Resources.rename;
		this.toolStripButton_3.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_3.Name = "toolBtnRenameFile";
		this.toolStripButton_3.Size = new Size(23, 22);
		this.toolStripButton_3.Text = "Переименовать";
		this.toolStripButton_3.Click += this.pmfzBinpoF;
		this.toolStripButton_4.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_4.Image = Resources.save;
		this.toolStripButton_4.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_4.Name = "toolBtnSaveFile";
		this.toolStripButton_4.Size = new Size(23, 22);
		this.toolStripButton_4.Text = "Сохранить файл на диск";
		this.toolStripButton_4.Click += this.toolStripMenuItem_6_Click;
		this.SuvoovyfcoT.Controls.Add(this.dataGridView_0);
		this.SuvoovyfcoT.Controls.Add(this.toolStrip_1);
		this.SuvoovyfcoT.Location = new Point(4, 22);
		this.SuvoovyfcoT.Name = "tabPagePayment";
		this.SuvoovyfcoT.Padding = new Padding(3);
		this.SuvoovyfcoT.Size = new Size(455, 331);
		this.SuvoovyfcoT.TabIndex = 3;
		this.SuvoovyfcoT.Text = "Платежи";
		this.SuvoovyfcoT.UseVisualStyleBackColor = true;
		this.dataGridView_0.AllowUserToAddRows = false;
		this.dataGridView_0.AllowUserToDeleteRows = false;
		this.dataGridView_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView_0.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewComboBoxColumn_0,
			this.dataGridViewTextBoxColumn_21,
			this.dataGridViewTextBoxColumn_22,
			this.dataGridViewTextBoxColumn_23,
			this.dataGridViewTextBoxColumn_24,
			this.dataGridViewTextBoxColumn_25,
			this.dataGridViewComboBoxColumn_1
		});
		this.dataGridView_0.Dock = DockStyle.Fill;
		this.dataGridView_0.Location = new Point(3, 28);
		this.dataGridView_0.Name = "dgvPayment";
		this.dataGridView_0.ReadOnly = true;
		this.dataGridView_0.Size = new Size(449, 300);
		this.dataGridView_0.TabIndex = 1;
		this.dataGridView_0.CellDoubleClick += this.dataGridView_0_CellDoubleClick;
		this.dataGridView_0.DataError += this.dataGridView_0_DataError;
		this.dataGridViewComboBoxColumn_0.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
		this.dataGridViewComboBoxColumn_0.HeaderText = "Тип документа";
		this.dataGridViewComboBoxColumn_0.Name = "typeDocDgvColumn";
		this.dataGridViewComboBoxColumn_0.ReadOnly = true;
		this.dataGridViewTextBoxColumn_21.HeaderText = "id";
		this.dataGridViewTextBoxColumn_21.Name = "idDocDgvColumn";
		this.dataGridViewTextBoxColumn_21.ReadOnly = true;
		this.dataGridViewTextBoxColumn_21.Visible = false;
		this.dataGridViewTextBoxColumn_22.HeaderText = "Номер";
		this.dataGridViewTextBoxColumn_22.Name = "numDgvColumn";
		this.dataGridViewTextBoxColumn_22.ReadOnly = true;
		this.dataGridViewTextBoxColumn_23.HeaderText = "Дата";
		this.dataGridViewTextBoxColumn_23.Name = "dateDgvColumn";
		this.dataGridViewTextBoxColumn_23.ReadOnly = true;
		this.dataGridViewTextBoxColumn_24.HeaderText = "Сумма";
		this.dataGridViewTextBoxColumn_24.Name = "sumDgvColumn";
		this.dataGridViewTextBoxColumn_24.ReadOnly = true;
		this.dataGridViewTextBoxColumn_25.HeaderText = "Комментарий";
		this.dataGridViewTextBoxColumn_25.Name = "commentDgvColumn";
		this.dataGridViewTextBoxColumn_25.ReadOnly = true;
		this.dataGridViewComboBoxColumn_1.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
		this.dataGridViewComboBoxColumn_1.HeaderText = "Договор";
		this.dataGridViewComboBoxColumn_1.Name = "dogDgvColumn";
		this.dataGridViewComboBoxColumn_1.ReadOnly = true;
		this.toolStrip_1.Items.AddRange(new ToolStripItem[]
		{
			this.toolStripButton_5,
			this.toolStripButton_6,
			this.toolStripButton_7
		});
		this.toolStrip_1.Location = new Point(3, 3);
		this.toolStrip_1.Name = "toolStripPayment";
		this.toolStrip_1.Size = new Size(449, 25);
		this.toolStrip_1.TabIndex = 0;
		this.toolStrip_1.Text = "toolStrip1";
		this.toolStripButton_5.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_5.Image = Resources.ElementAdd;
		this.toolStripButton_5.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_5.Name = "toolBtnAddPayment";
		this.toolStripButton_5.Size = new Size(23, 22);
		this.toolStripButton_5.Text = "Добавить платеж";
		this.toolStripButton_5.Click += this.toolStripButton_5_Click;
		this.toolStripButton_6.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_6.Image = Resources.ElementEdit;
		this.toolStripButton_6.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_6.Name = "toolBtnEditPayment";
		this.toolStripButton_6.Size = new Size(23, 22);
		this.toolStripButton_6.Text = "Редактировать платеж";
		this.toolStripButton_6.Click += this.toolStripButton_6_Click;
		this.toolStripButton_7.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_7.Image = Resources.ElementDel;
		this.toolStripButton_7.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_7.Name = "toolBtnDelPayment";
		this.toolStripButton_7.Size = new Size(23, 22);
		this.toolStripButton_7.Text = "Удалить платеж";
		this.toolStripButton_7.Click += this.toolStripButton_7_Click;
		this.tabPage_3.Controls.Add(this.dataGridView_1);
		this.tabPage_3.Controls.Add(this.toolStrip_2);
		this.tabPage_3.Location = new Point(4, 22);
		this.tabPage_3.Name = "tabPagePaymentShedule";
		this.tabPage_3.Padding = new Padding(3);
		this.tabPage_3.Size = new Size(455, 331);
		this.tabPage_3.TabIndex = 4;
		this.tabPage_3.Text = "График платежей";
		this.tabPage_3.UseVisualStyleBackColor = true;
		this.dataGridView_1.AutoGenerateColumns = false;
		this.dataGridView_1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView_1.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewFilterDateTimePickerColumn_0,
			this.dataGridViewTextBoxColumn_26,
			this.dataGridViewTextBoxColumn_27,
			this.dataGridViewNumericColumn_0,
			this.dataGridViewTextBoxColumn_28
		});
		this.dataGridView_1.DataSource = this.cKuooUatTyq;
		this.dataGridView_1.Dock = DockStyle.Fill;
		this.dataGridView_1.Location = new Point(3, 3);
		this.dataGridView_1.Name = "dgvPaymentShedule";
		this.dataGridView_1.Size = new Size(449, 325);
		this.dataGridView_1.TabIndex = 2;
		this.dataGridView_1.CellValueChanged += this.dataGridView_1_CellValueChanged;
		this.dataGridViewFilterDateTimePickerColumn_0.DataPropertyName = "DateShedule";
		dataGridViewCellStyle4.Format = "dd MM yyyy";
		dataGridViewCellStyle4.NullValue = null;
		this.dataGridViewFilterDateTimePickerColumn_0.DefaultCellStyle = dataGridViewCellStyle4;
		this.dataGridViewFilterDateTimePickerColumn_0.HeaderText = "Дата";
		this.dataGridViewFilterDateTimePickerColumn_0.Name = "dateSheduleDataGridViewTextBoxColumn";
		this.dataGridViewFilterDateTimePickerColumn_0.Resizable = DataGridViewTriState.True;
		this.dataGridViewFilterDateTimePickerColumn_0.SortMode = DataGridViewColumnSortMode.Automatic;
		this.dataGridViewTextBoxColumn_26.DataPropertyName = "id";
		this.dataGridViewTextBoxColumn_26.HeaderText = "id";
		this.dataGridViewTextBoxColumn_26.Name = "idDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_26.ReadOnly = true;
		this.dataGridViewTextBoxColumn_26.Visible = false;
		this.dataGridViewTextBoxColumn_27.DataPropertyName = "idDoc";
		this.dataGridViewTextBoxColumn_27.HeaderText = "idDoc";
		this.dataGridViewTextBoxColumn_27.Name = "idDocPSDgvColumn";
		this.dataGridViewTextBoxColumn_27.Visible = false;
		this.dataGridViewNumericColumn_0.DataPropertyName = "Summa";
		this.dataGridViewNumericColumn_0.DecimalLength = 2;
		dataGridViewCellStyle5.Format = "F2";
		this.dataGridViewNumericColumn_0.DefaultCellStyle = dataGridViewCellStyle5;
		this.dataGridViewNumericColumn_0.HeaderText = "Сумма";
		this.dataGridViewNumericColumn_0.Name = "summaDataGridViewTextBoxColumn";
		this.dataGridViewNumericColumn_0.Resizable = DataGridViewTriState.True;
		this.dataGridViewNumericColumn_0.ShowNullWhenZero = true;
		this.dataGridViewTextBoxColumn_28.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_28.DataPropertyName = "Comment";
		this.dataGridViewTextBoxColumn_28.HeaderText = "Коментарий";
		this.dataGridViewTextBoxColumn_28.Name = "commentDataGridViewTextBoxColumn";
		this.cKuooUatTyq.DataMember = "tTC_PaymentShedule";
		this.cKuooUatTyq.DataSource = this.class10_1;
		this.toolStrip_2.Items.AddRange(new ToolStripItem[]
		{
			this.toolStripButton_8,
			this.toolStripButton_9,
			this.toolStripButton_10
		});
		this.toolStrip_2.Location = new Point(3, 3);
		this.toolStrip_2.Name = "toolStrip1";
		this.toolStrip_2.Size = new Size(468, 25);
		this.toolStrip_2.TabIndex = 1;
		this.toolStrip_2.Text = "toolStrip1";
		this.toolStrip_2.Visible = false;
		this.toolStripButton_8.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_8.Image = Resources.ElementAdd;
		this.toolStripButton_8.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_8.Name = "toolBtnAddPaymentShedule";
		this.toolStripButton_8.Size = new Size(23, 22);
		this.toolStripButton_8.Text = "Добавить";
		this.toolStripButton_9.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_9.Image = Resources.ElementEdit;
		this.toolStripButton_9.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_9.Name = "toolBtnEditPaymentShedule";
		this.toolStripButton_9.Size = new Size(23, 22);
		this.toolStripButton_9.Text = "Редактировать";
		this.toolStripButton_10.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_10.Image = Resources.ElementDel;
		this.toolStripButton_10.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_10.Name = "toolBtnDelPaymentShedule";
		this.toolStripButton_10.Size = new Size(23, 22);
		this.toolStripButton_10.Text = "Удалить";
		this.contextMenuStrip_0.Items.AddRange(new ToolStripItem[]
		{
			this.toolStripMenuItem_0,
			this.toolStripMenuItem_2,
			this.toolStripMenuItem_3,
			this.toolStripMenuItem_4,
			this.cplooIfVoRt,
			this.toolStripMenuItem_5,
			this.toolStripMenuItem_6
		});
		this.contextMenuStrip_0.Name = "contextMenuFile";
		this.contextMenuStrip_0.Size = new Size(177, 142);
		this.toolStripMenuItem_0.DropDownItems.AddRange(new ToolStripItem[]
		{
			this.toolStripMenuItem_1,
			this.toolStripSeparator_2
		});
		this.toolStripMenuItem_0.Image = Resources.ElementAdd;
		this.toolStripMenuItem_0.Name = "toolMenuItemAddFile";
		this.toolStripMenuItem_0.Size = new Size(176, 22);
		this.toolStripMenuItem_0.Text = "Добавить";
		this.toolStripMenuItem_1.Name = "toolMenuItemAddExistsFile";
		this.toolStripMenuItem_1.Size = new Size(195, 22);
		this.toolStripMenuItem_1.Text = "Существующий файл";
		this.toolStripMenuItem_1.Click += this.toolStripMenuItem_1_Click;
		this.toolStripSeparator_2.Name = "toolStripSeparator5";
		this.toolStripSeparator_2.Size = new Size(192, 6);
		this.toolStripMenuItem_2.Image = Resources.ElementEdit;
		this.toolStripMenuItem_2.Name = "toolMenuItemEditFile";
		this.toolStripMenuItem_2.Size = new Size(176, 22);
		this.toolStripMenuItem_2.Text = "Редактировать";
		this.toolStripMenuItem_2.Click += this.toolStripMenuItem_2_Click;
		this.toolStripMenuItem_3.Image = Resources.ElementInformation;
		this.toolStripMenuItem_3.Name = "toolMenuItemViewFile";
		this.toolStripMenuItem_3.Size = new Size(176, 22);
		this.toolStripMenuItem_3.Text = "Просмотр";
		this.toolStripMenuItem_3.Click += this.toolStripMenuItem_3_Click;
		this.toolStripMenuItem_4.Image = Resources.ElementDel;
		this.toolStripMenuItem_4.Name = "toolMenuItemDelFile";
		this.toolStripMenuItem_4.Size = new Size(176, 22);
		this.toolStripMenuItem_4.Text = "Удалить";
		this.toolStripMenuItem_4.Click += this.toolStripMenuItem_4_Click;
		this.cplooIfVoRt.Name = "toolStripSeparator4";
		this.cplooIfVoRt.Size = new Size(173, 6);
		this.toolStripMenuItem_5.Image = Resources.rename;
		this.toolStripMenuItem_5.Name = "toolMenuItemRenameFile";
		this.toolStripMenuItem_5.Size = new Size(176, 22);
		this.toolStripMenuItem_5.Text = "Переименовать";
		this.toolStripMenuItem_5.Click += this.pmfzBinpoF;
		this.toolStripMenuItem_6.Image = Resources.save;
		this.toolStripMenuItem_6.Name = "toolMenuItemSaveFile";
		this.toolStripMenuItem_6.Size = new Size(176, 22);
		this.toolStripMenuItem_6.Text = "Сохранить на диск";
		this.toolStripMenuItem_6.Click += this.toolStripMenuItem_6_Click;
		base.AcceptButton = this.button_0;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = this.button_1;
		base.ClientSize = new Size(461, 449);
		base.Controls.Add(this.tabControl_0);
		base.Controls.Add(this.label_1);
		base.Controls.Add(this.button_1);
		base.Controls.Add(this.button_0);
		base.Controls.Add(this.bkLolxvsRes);
		base.Controls.Add(this.textBox_0);
		base.Controls.Add(this.label_0);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "FormContractAddEdit";
		this.Text = "FormTechConnectionDocOutAddEdit";
		base.FormClosing += this.Form20_FormClosing;
		base.Load += this.Form20_Load;
		((ISupportInitialize)this.class10_1).EndInit();
		this.tabControl_0.ResumeLayout(false);
		this.tabPage_0.ResumeLayout(false);
		this.tabPage_0.PerformLayout();
		((ISupportInitialize)this.nullableNumericUpDown_1).EndInit();
		((ISupportInitialize)this.nullableNumericUpDown_0).EndInit();
		this.tabPage_1.ResumeLayout(false);
		((ISupportInitialize)this.dataGridViewExcelFilter_0).EndInit();
		((ISupportInitialize)this.bindingSource_0).EndInit();
		this.tabPage_2.ResumeLayout(false);
		this.tabPage_2.PerformLayout();
		((ISupportInitialize)this.dataGridViewExcelFilter_1).EndInit();
		((ISupportInitialize)this.bindingSource_1).EndInit();
		this.toolStrip_0.ResumeLayout(false);
		this.toolStrip_0.PerformLayout();
		this.SuvoovyfcoT.ResumeLayout(false);
		this.SuvoovyfcoT.PerformLayout();
		((ISupportInitialize)this.dataGridView_0).EndInit();
		this.toolStrip_1.ResumeLayout(false);
		this.toolStrip_1.PerformLayout();
		this.tabPage_3.ResumeLayout(false);
		this.tabPage_3.PerformLayout();
		((ISupportInitialize)this.dataGridView_1).EndInit();
		((ISupportInitialize)this.cKuooUatTyq).EndInit();
		this.toolStrip_2.ResumeLayout(false);
		this.toolStrip_2.PerformLayout();
		this.contextMenuStrip_0.ResumeLayout(false);
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	[CompilerGenerated]
	private void method_25()
	{
		this.bindingSource_1.ResetBindings(false);
	}

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private int int_4;

	private bool bool_0;

	private Class10 vuBolsfjNbM;

	private Dictionary<string, FileWatcherArgsAddl> dictionary_0;

	private string string_0;

	private Class10 class10_0;

	private DataTable dataTable_0;

	private Label label_0;

	private TextBox textBox_0;

	private NullableDateTimePicker bkLolxvsRes;

	private Class10 class10_1;

	private Button button_0;

	private Button button_1;

	private Label bTpoltpxnYl;

	private TextBox textBox_1;

	private Label label_1;

	private TabControl tabControl_0;

	private TabPage tabPage_0;

	private TabPage tabPage_1;

	private Label label_2;

	private TextBox textBox_2;

	private Label label_3;

	private ComboBox comboBox_0;

	private TextBox textBox_3;

	private Label label_4;

	private NullableDateTimePicker PcTolGiItLF;

	private Label label_5;

	private NullableNumericUpDown nullableNumericUpDown_0;

	private Label label_6;

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

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_11;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_12;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_13;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_14;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_15;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_16;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_17;

	private TabPage tabPage_2;

	private ToolStrip toolStrip_0;

	private ToolStripDropDownButton toolStripDropDownButton_0;

	private ToolStripMenuItem mwcooynIkAe;

	private ToolStripSeparator toolStripSeparator_0;

	private ToolStripButton toolStripButton_0;

	private ToolStripButton toolStripButton_1;

	private ToolStripButton toolStripButton_2;

	private ToolStripSeparator toolStripSeparator_1;

	private ToolStripButton toolStripButton_3;

	private ToolStripButton toolStripButton_4;

	private BindingSource bindingSource_1;

	private DataGridViewExcelFilter dataGridViewExcelFilter_1;

	private DataGridViewImageColumnNotNull dataGridViewImageColumnNotNull_0;

	private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_18;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_19;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_20;

	private ContextMenuStrip contextMenuStrip_0;

	private ToolStripMenuItem toolStripMenuItem_0;

	private ToolStripMenuItem toolStripMenuItem_1;

	private ToolStripSeparator toolStripSeparator_2;

	private ToolStripMenuItem toolStripMenuItem_2;

	private ToolStripMenuItem toolStripMenuItem_3;

	private ToolStripMenuItem toolStripMenuItem_4;

	private ToolStripSeparator cplooIfVoRt;

	private ToolStripMenuItem toolStripMenuItem_5;

	private ToolStripMenuItem toolStripMenuItem_6;

	private TabPage SuvoovyfcoT;

	private ToolStrip toolStrip_1;

	private ToolStripButton toolStripButton_5;

	private ToolStripButton toolStripButton_6;

	private ToolStripButton toolStripButton_7;

	private DataGridView dataGridView_0;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_21;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_22;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_23;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_24;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_25;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_1;

	private TabPage tabPage_3;

	private DataGridView dataGridView_1;

	private BindingSource cKuooUatTyq;

	private ToolStrip toolStrip_2;

	private ToolStripButton toolStripButton_8;

	private ToolStripButton toolStripButton_9;

	private ToolStripButton toolStripButton_10;

	private DataGridViewFilterDateTimePickerColumn dataGridViewFilterDateTimePickerColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_26;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_27;

	private DataGridViewNumericColumn dataGridViewNumericColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_28;

	private NullableDateTimePicker nullableDateTimePicker_0;

	private Label label_7;

	private NullableDateTimePicker nullableDateTimePicker_1;

	private Label label_8;

	private NullableNumericUpDown nullableNumericUpDown_1;

	private Label label_9;

	private ComboBox comboBox_1;

	private Label label_10;
}
