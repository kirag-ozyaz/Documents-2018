﻿using System;
using System.Collections;
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
using DataSql;
using Documents.Properties;
using FormLbr;
using FormLbr.Classes;
using OfficeLB.Word;

namespace Documents.Forms.TechnologicalConnection.TU
{
	public partial class FormTUAddEdit : FormBase
	{
		public int IdTU
		{
			get
			{
				return this.int_0;
			}
		}

		public FormTUAddEdit()
		{
			
			this.int_0 = -1;
			this.int_1 = -1;
			this.int_2 = -1;
			this.string_0 = "-1";
			this.int_3 = -1;
			this.int_4 = -1;
			this.dicWatcherFile = new Dictionary<string, FileWatcherArgsAddl>();
			this.string_1 = "";
			
			this.method_28();
		}

		public FormTUAddEdit(int idTU = -1, int idDocIn = -1)
		{
			
			this.int_0 = -1;
			this.int_1 = -1;
			this.int_2 = -1;
			this.string_0 = "-1";
			this.int_3 = -1;
			this.int_4 = -1;
			this.dicWatcherFile = new Dictionary<string, FileWatcherArgsAddl>();
			this.string_1 = "";
			
			this.method_28();
			this.int_0 = idTU;
			this.int_1 = idDocIn;
		}

		private void FormTUAddEdit_Load(object sender, EventArgs e)
		{
			this.method_2();
			this.method_1();
			this.method_3();
			this.method_5();
			this.method_6();
			this.method_7();
			if (this.int_0 == -1)
			{
				this.Text = "Новое тех. условие";
			}
			else
			{
				this.Text = "Редактирование тех. условия";
				base.SelectSqlData(this.class10_0, this.class10_0.tTC_Doc, true, "where id = " + this.int_0.ToString());
				if (this.class10_0.tTC_Doc.Rows.Count > 0 && this.class10_0.tTC_Doc.Rows[0]["numDoc"] != DBNull.Value)
				{
					this.string_0 = this.class10_0.tTC_Doc.Rows[0]["numDoc"].ToString();
				}
				base.SelectSqlData(this.class10_0, this.class10_0.tTC_DocOut, true, "where idDocOut = " + this.int_0.ToString());
				NullableNumericUpDown nullableNumericUpDown = this.nullableNumericUpDown_0;
				NullableNumericUpDown nullableNumericUpDown2 = this.nullableNumericUpDown_1;
				NullableNumericUpDown nullableNumericUpDown3 = this.nullableNumericUpDown_2;
				decimal? value = new decimal?(0m);
				nullableNumericUpDown3.Value = value;
				nullableNumericUpDown.Value = (nullableNumericUpDown2.Value = value);
				base.SelectSqlData(this.class10_0, this.class10_0.tTC_TU, true, "where id = " + this.int_0.ToString());
				base.SelectSqlData(this.class10_0.tTC_TUTypeWork, true, "where idtu = " + this.int_0.ToString() + " order by num ", null, false, 0);
				this.method_0();
				this.method_22(this.int_0);
			}
			this.LoadTemplate();
			this.method_25();
			this.method_26();
			this.isFile = false;
		}

		private void method_0()
		{
			this.dataGridView_0.Rows.Clear();
			string where = string.Concat(new string[]
			{
				" where idTU = ",
				this.int_0.ToString(),
				" and (typeDoc is null or typeDoc = ",
				1123.ToString(),
				")   order by num"
			});
			base.SelectSqlData(this.class10_0, this.class10_0.tTC_TUPointAttach, true, where);
			base.SelectSqlData(this.class10_0, this.class10_0.vTC_TUPointAttach, true, where);
			foreach (DataRow dataRow in this.class10_0.vTC_TUPointAttach)
			{
				this.dataGridView_0.Rows.Add(new object[]
				{
					dataRow["id"],
					dataRow["num"],
					dataRow["idSubPoint"],
					dataRow["SubPoint"],
					dataRow["idBusPoint"],
					dataRow["BusPoint"],
					dataRow["idCellPoint"],
					dataRow["CellPoint"],
					dataRow["idSubCP"],
					dataRow["SubCP"],
					dataRow["idBusCP"],
					dataRow["BusCP"],
					dataRow["idCellCP"],
					dataRow["CellCP"],
					dataRow["VoltageLevel"],
					dataRow["VoltageLevelName"],
					dataRow["PowerSum"],
					dataRow["Description"]
				});
			}
		}

		private void method_1()
		{
			NullableNumericUpDown nullableNumericUpDown = this.nullableNumericUpDown_0;
			NullableNumericUpDown nullableNumericUpDown2 = this.nullableNumericUpDown_2;
			NullableNumericUpDown nullableNumericUpDown3 = this.nullableNumericUpDown_1;
			decimal? value = null;
			nullableNumericUpDown3.Value = value;
			nullableNumericUpDown.Value = (nullableNumericUpDown2.Value = value);
		}

		private void method_2()
		{
			this.dHewKxZoUa();
			if (this.dataTable_0.Rows.Count > 0)
			{
				this.toolStripComboBox_0.ComboBox.DataSource = null;
				this.toolStripComboBox_0.Items.Clear();
				this.toolStripComboBox_0.ComboBox.DisplayMember = "Name";
				this.toolStripComboBox_0.ComboBox.ValueMember = "Name";
				this.toolStripComboBox_0.ComboBox.DataSource = this.dataTable_0;
			}
			if (this.dataTable_1.Rows.Count > 0)
			{
				this.toolStripComboBox_1.ComboBox.DataSource = null;
				this.toolStripComboBox_1.Items.Clear();
				this.toolStripComboBox_1.ComboBox.DisplayMember = "Name";
				this.toolStripComboBox_1.ComboBox.ValueMember = "Name";
				this.toolStripComboBox_1.ComboBox.DataSource = this.dataTable_1;
			}
		}

		private void FormTUAddEdit_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.isFile && MessageBox.Show("Сохранить внесенные изменения?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes && !this.method_9())
			{
				e.Cancel = true;
				return;
			}
			foreach (FileWatcherArgsAddl fileWatcherArgsAddl in this.dicWatcherFile.Values)
			{
				if (fileWatcherArgsAddl.Watcher != null)
				{
					fileWatcherArgsAddl.Watcher.Dispose();
				}
			}
		}

		private void method_3()
		{
			string text = string.Concat(new string[]
			{
				"select  r.id, r.numin, r.datein,  isnull(r.numIn, '') + ' от ' + isnull(convert( varchar(10),r.DateIn, 104), '') as numDateIn from ttc_request r left join ttc_doc d on d.id = r.id  where (d.typeDoc = ",
				1113.ToString(),
				" or d.TypeDoc = ",
				1203.ToString(),
				")  and r.id not in (select docOut.idDoc  from ttc_docout docOut  left join ttc_doc r on r.id = docOut.idDoc and (r.typeDoc = ",
				1113.ToString(),
				" or r.typeDoc = ",
				1203.ToString(),
				")  left join ttc_doc tu on tu.id = docout.iddocout and tu.typedoc = ",
				1123.ToString(),
				" where r.id is not null and tu.id is not null) "
			});
			if (this.int_0 != -1)
			{
				text = string.Concat(new string[]
				{
					text,
					" union select  req.id, req.numin, req.datein,  isnull(req.numIn, '') + ' от ' + isnull(convert( varchar(10),req.DateIn, 104), '') as numDateIn  from ttc_docout docOut  left join ttc_doc r on r.id = docOut.idDoc and (r.typeDoc = ",
					1113.ToString(),
					" or r.typeDoc = ",
					1203.ToString(),
					")  left join ttc_request req on r.id = req.id  left join ttc_doc tu on tu.id = docout.iddocout and tu.typedoc = ",
					1123.ToString(),
					" where r.id is not null and tu.id = ",
					this.int_0.ToString()
				});
			}
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
			this.comboBox_0.SelectedValueChanged -= this.comboBox_0_SelectedValueChanged;
			BindingSource bindingSource = new BindingSource();
			bindingSource.DataSource = dataTable;
			bindingSource.Sort = "numIn, dateIn";
			this.comboBox_0.DataSource = bindingSource;
			this.comboBox_0.DisplayMember = "numDateIn";
			this.comboBox_0.ValueMember = "id";
			this.comboBox_0.SelectedValueChanged += this.comboBox_0_SelectedValueChanged;
			if (this.int_1 != -1)
			{
				this.comboBox_0.SelectedValue = this.int_1;
				return;
			}
			this.comboBox_0.SelectedIndex = -1;
		}

		private void method_4(int int_5)
		{
			Class10.Class13 @class = new Class10.Class13();
			base.SelectSqlData(@class, true, " where id = " + int_5.ToString(), null, false, 0);
			if (@class.Rows.Count > 0)
			{
				if (@class.Rows[0]["idAbn"] != DBNull.Value)
				{
					this.int_3 = Convert.ToInt32(@class.Rows[0]["idAbn"]);
					this.label_4.ForeColor = Color.FromKnownColor(KnownColor.WindowText);
					Class10.Class11 class2 = new Class10.Class11();
					base.SelectSqlData(class2, true, "where id = " + this.int_3.ToString(), null, false, 0);
					if (class2.Rows.Count > 0)
					{
						this.textBox_1.Text = class2.Rows[0]["name"].ToString();
						int num = Convert.ToInt32(class2.Rows[0]["typeAbn"]);
						if (@class.Rows[0]["idAbnObj"] != DBNull.Value)
						{
							this.int_4 = Convert.ToInt32(@class.Rows[0]["idAbnObj"]);
							Class10.Class16 class3 = new Class10.Class16();
							DataColumn dataColumn = new DataColumn("AddressFL");
							dataColumn.Expression = "street + ', д. ' + houseall + ', кв. ' + name";
							class3.Columns.Add(dataColumn);
							dataColumn = new DataColumn("AddressUL");
							dataColumn.Expression = "street + ', д. ' + houseall";
							class3.Columns.Add(dataColumn);
							base.SelectSqlData(class3, true, "where id = " + this.int_4.ToString() + " order by name", null, false, 0);
							if (class3.Rows.Count > 0)
							{
								if (num != 206 && num != 253)
								{
									if (num != 1037)
									{
										this.textBox_2.Text = class3.Rows[0]["name"].ToString();
										goto IL_259;
									}
								}
								this.textBox_2.Text = class3.Rows[0]["AddressFL"].ToString();
								IL_259:
								this.label_3.ForeColor = Color.FromKnownColor(KnownColor.WindowText);
							}
							else
							{
								this.int_4 = -1;
								this.textBox_2.Text = "";
								this.label_3.ForeColor = Color.Red;
							}
						}
						else
						{
							this.int_4 = -1;
							this.textBox_2.Text = "";
							this.label_3.ForeColor = Color.Red;
						}
					}
					else
					{
						this.int_3 = -1;
						this.int_4 = -1;
						this.textBox_1.Text = (this.textBox_2.Text = "");
						this.label_4.ForeColor = (this.label_3.ForeColor = Color.Red);
					}
				}
				else
				{
					this.int_3 = -1;
					this.int_4 = -1;
					this.textBox_1.Text = (this.textBox_2.Text = "");
					this.label_4.ForeColor = (this.label_3.ForeColor = Color.Red);
				}
				if (@class.Rows[0]["PowerCurrent"] != DBNull.Value && this.nullableNumericUpDown_0.Value == null)
				{
					this.nullableNumericUpDown_0.Value = new decimal?(Convert.ToDecimal(@class.Rows[0]["PowerCurrent"]));
				}
				if (@class.Rows[0]["PowerAdd"] != DBNull.Value && this.nullableNumericUpDown_1.Value == null)
				{
					this.nullableNumericUpDown_1.Value = new decimal?(Convert.ToDecimal(@class.Rows[0]["PowerAdd"]));
				}
				if (@class.Rows[0]["Power"] != DBNull.Value && this.nullableNumericUpDown_2.Value == null)
				{
					this.nullableNumericUpDown_2.Value = new decimal?(Convert.ToDecimal(@class.Rows[0]["Power"]));
				}
				if (@class.Rows[0]["VoltageLevel"] != DBNull.Value && this.comboBox_3.SelectedIndex < 0)
				{
					this.comboBox_3.SelectedValue = @class.Rows[0]["VoltageLevel"];
				}
				Class10.Class12 class4 = new Class10.Class12();
				base.SelectSqlData(class4, true, " where id = " + int_5.ToString(), null, false, 0);
				int num2 = int_5;
				if (class4.Rows.Count > 0 && class4.Rows[0]["idParent"] != DBNull.Value)
				{
					num2 = Convert.ToInt32(class4.Rows[0]["idParent"]);
				}
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
			this.class10_0.vTC_RequestHistory.Clear();
			this.int_3 = -1;
			this.int_4 = -1;
			this.textBox_1.Text = (this.textBox_2.Text = "");
			this.label_4.ForeColor = (this.label_3.ForeColor = Color.Red);
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
			this.textBox_2.Text = (this.textBox_1.Text = "");
			this.int_4 = -1;
			this.int_3 = -1;
			this.label_4.ForeColor = (this.label_3.ForeColor = Color.Red);
			this.int_2 = -1;
		}

		private void comboBox_0_TextChanged(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(this.comboBox_0.Text))
			{
				this.comboBox_0.SelectedIndex = -1;
				this.textBox_2.Text = (this.textBox_1.Text = "");
				this.int_2 = -1;
			}
		}

		private void method_5()
		{
			Class10.Class14 @class = new Class10.Class14();
			base.SelectSqlData(@class, true, " where ParentKey = ';SKUEE;Category;' and isGroup = 0 and deleted = 0 order by name", null, false, 0);
			this.comboBox_1.DataSource = @class;
			this.comboBox_1.DisplayMember = "name";
			this.comboBox_1.ValueMember = "id";
			this.comboBox_1.SelectedIndex = -1;
		}

		private void method_6()
		{
			DataTable dataTable = new DataTable("vWorkerGroup");
			dataTable.Columns.Add("id", typeof(int));
			dataTable.Columns.Add("fio", typeof(string));
			base.SelectSqlData(dataTable, true, "where ParentKey = ';GroupWorker;PerformerTU;' and dateEnd is null order by fio", null, false, 0);
			this.comboBox_2.DataSource = dataTable;
			this.comboBox_2.DisplayMember = "fio";
			this.comboBox_2.ValueMember = "id";
			this.comboBox_2.SelectedIndex = -1;
		}

		private void method_7()
		{
			Class10.Class14 @class = new Class10.Class14();
			base.SelectSqlData(@class, true, " where ParentKey like ';VoltageLevels;%' and isGroup = 0 and deleted = 0 order by value", null, false, 0);
			this.comboBox_3.DisplayMember = "name";
			this.comboBox_3.ValueMember = "id";
			this.comboBox_3.DataSource = @class;
			this.comboBox_3.SelectedIndex = -1;
		}

		private void toolStripButton_0_Click(object sender, EventArgs e)
		{
			GForm0 gform = new GForm0();
			gform.SqlSettings = this.SqlSettings;
			if (gform.ShowDialog() == DialogResult.OK)
			{
				this.dataGridView_0.Rows.Add(new object[]
				{
					-1,
					-1,
					gform.idSubPoint,
					gform.SubPoint,
					gform.idBusPoint,
					gform.BusPoint,
					gform.idCellPoint,
					gform.CellPoint,
					gform.idSubCP,
					gform.SubCP,
					gform.idBusCP,
					gform.BusCP,
					gform.idCellCP,
					gform.CellCP,
					gform.idVoltagelevel,
					gform.VoltageLevel,
					gform.PowerSum,
					gform.DescriptionPoint
				});
				this.isFile = true;
			}
		}

		private void toolStripButton_1_Click(object sender, EventArgs e)
		{
			if (this.dataGridView_0.CurrentRow != null)
			{
				GForm0 gform = new GForm0(this.dataGridView_0.CurrentRow);
				gform.SqlSettings = this.SqlSettings;
				if (gform.ShowDialog() == DialogResult.OK)
				{
					this.dataGridView_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_52.Name].Value = gform.idSubPoint;
					this.dataGridView_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_53.Name].Value = gform.SubPoint;
					this.dataGridView_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_54.Name].Value = gform.idBusPoint;
					this.dataGridView_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_55.Name].Value = gform.BusPoint;
					this.dataGridView_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_56.Name].Value = gform.idCellPoint;
					this.dataGridView_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_57.Name].Value = gform.CellPoint;
					this.dataGridView_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_58.Name].Value = gform.idSubCP;
					this.dataGridView_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_59.Name].Value = gform.SubCP;
					this.dataGridView_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_60.Name].Value = gform.idBusCP;
					this.dataGridView_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_61.Name].Value = gform.BusCP;
					this.dataGridView_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_62.Name].Value = gform.idCellCP;
					this.dataGridView_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_63.Name].Value = gform.CellCP;
					this.dataGridView_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_64.Name].Value = gform.idVoltagelevel;
					this.dataGridView_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_65.Name].Value = gform.VoltageLevel;
					this.dataGridView_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_66.Name].Value = gform.PowerSum;
					this.dataGridView_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_67.Name].Value = gform.DescriptionPoint;
					this.isFile = true;
				}
			}
		}

		private void dataGridView_0_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && this.toolStripButton_1.Visible && this.toolStripButton_1.Enabled)
			{
				this.toolStripButton_1_Click(sender, e);
			}
		}

		private void toolStripButton_2_Click(object sender, EventArgs e)
		{
			if (this.dataGridView_0.CurrentRow != null)
			{
				this.dataGridView_0.Rows.Remove(this.dataGridView_0.CurrentRow);
				this.isFile = true;
			}
		}

		private void toolStripButton_3_Click(object sender, EventArgs e)
		{
			if (this.dataGridView_0.CurrentRow != null && this.dataGridView_0.CurrentRow.Index > 0)
			{
				int index = this.dataGridView_0.CurrentRow.Index;
				DataGridViewRow currentRow = this.dataGridView_0.CurrentRow;
				this.dataGridView_0.Rows.Remove(this.dataGridView_0.CurrentRow);
				this.dataGridView_0.Rows.Insert(index - 1, currentRow);
				this.dataGridView_0.FirstDisplayedScrollingRowIndex = index - 1;
				this.dataGridView_0[this.dataGridViewTextBoxColumn_53.Name, index - 1].Selected = true;
				this.dataGridView_0.CurrentCell = this.dataGridView_0[this.dataGridViewTextBoxColumn_53.Name, index - 1];
				this.isFile = true;
			}
		}

		private void toolStripButton_4_Click(object sender, EventArgs e)
		{
			if (this.dataGridView_0.CurrentRow != null && this.dataGridView_0.CurrentRow.Index < this.dataGridView_0.Rows.Count - 1)
			{
				int index = this.dataGridView_0.CurrentRow.Index;
				DataGridViewRow currentRow = this.dataGridView_0.CurrentRow;
				this.dataGridView_0.Rows.Remove(this.dataGridView_0.CurrentRow);
				this.dataGridView_0.Rows.Insert(index + 1, currentRow);
				this.dataGridView_0.FirstDisplayedScrollingRowIndex = index + 1;
				this.dataGridView_0[this.dataGridViewTextBoxColumn_53.Name, index + 1].Selected = true;
				this.dataGridView_0.CurrentCell = this.dataGridView_0[this.dataGridViewTextBoxColumn_53.Name, index + 1];
				this.isFile = true;
			}
		}

		private void txtNumDoc_TextChanged(object sender, EventArgs e)
		{
			this.isFile = true;
		}

		private void dateTimePicker_0_ValueChanged(object sender, EventArgs e)
		{
			this.isFile = true;
		}

		private void comboBox_2_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.comboBox_2.SelectedIndex >= 0)
			{
				this.isFile = true;
				this.label_8.ForeColor = SystemColors.ControlText;
			}
		}

		private void comboBox_0_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.isFile = true;
		}

		private void comboBox_1_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.isFile = true;
		}

		private void textBox_4_TextChanged(object sender, EventArgs e)
		{
			this.isFile = true;
		}

		private void comboBox_3_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.isFile = true;
			if (this.comboBox_3.SelectedIndex >= 0)
			{
				if (string.IsNullOrEmpty(this.textBox_4.Text))
				{
					this.textBox_4.Text = "ВРУ-" + this.comboBox_3.Text;
					return;
				}
				using (IEnumerator enumerator = this.comboBox_3.Items.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						if (obj is DataRowView)
						{
							string str = ((DataRowView)obj)["Name"].ToString();
							if (this.textBox_4.Text.IndexOf("ВРУ-" + str) >= 0)
							{
								this.textBox_4.Text = this.textBox_4.Text.Replace("ВРУ-" + str, "ВРУ-" + this.comboBox_3.Text);
								break;
							}
						}
					}
					return;
				}
			}
			this.textBox_4.Text = "";
		}

		private void nullableNumericUpDown_0_ValueChanged(object sender, EventArgs e)
		{
			this.isFile = true;
		}

		private void nullableNumericUpDown_1_ValueChanged(object sender, EventArgs e)
		{
			this.isFile = true;
		}

		private void nullableNumericUpDown_2_ValueChanged(object sender, EventArgs e)
		{
			this.isFile = true;
		}

		private void textBox_3_TextChanged(object sender, EventArgs e)
		{
			this.isFile = true;
		}

		private void button_0_Click(object sender, EventArgs e)
		{
			this.method_9();
		}

		private void button_1_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private bool method_8()
		{
			if (string.IsNullOrEmpty(this.txtNumDoc.Text))
			{
				if (this.int_0 != -1)
				{
					this.txtNumDoc.Text = this.string_0;
				}
			}
			else
			{
				DataTable dataTable = new DataTable("ttc_doc");
				dataTable.Columns.Add("id");
				if (this.int_0 == -1)
				{
					base.SelectSqlData(dataTable, true, string.Concat(new string[]
					{
						" where numdoc = '",
						this.txtNumDoc.Text,
						"' and TypeDoc = ",
						1123.ToString(),
						" and year(dateDoc) = ",
						this.dateTimePicker_0.Value.Year.ToString()
					}), null, false, 0);
				}
				if (this.int_0 != -1 && this.string_0 != this.txtNumDoc.Text)
				{
					base.SelectSqlData(dataTable, true, string.Concat(new string[]
					{
						" where numdoc = '",
						this.txtNumDoc.Text,
						"' and TypeDoc = ",
						1123.ToString(),
						" and year(dateDoc) = ",
						this.dateTimePicker_0.Value.Year.ToString(),
						" and id <> ",
						this.int_0.ToString()
					}), null, false, 0);
				}
				if (dataTable.Rows.Count > 0)
				{
					MessageBox.Show("Техническое условие с данным номером уже существует");
					return false;
				}
			}
			if (this.int_3 == -1)
			{
				MessageBox.Show("В заявке не тех. присоединение не указан контрагент.\r\nНеобходимо в заявке на тех присоединение выбрать контрагента", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			if (this.int_4 == -1)
			{
				MessageBox.Show("В заявке не тех. присоединение не указан объект.\r\nНеобходимо в заявке на тех присоединение выбрать объект контрагента", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			if (this.comboBox_2.SelectedIndex < 0)
			{
				MessageBox.Show("Не выбран исполнитель", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				this.label_8.ForeColor = Color.Red;
				return false;
			}
			return true;
		}

		private bool method_9()
		{
			if (!this.method_8())
			{
				return false;
			}
			if (this.int_0 == -1)
			{
				this.method_10();
				if (this.int_0 == -1)
				{
					return false;
				}
			}
			else if (!this.method_11())
			{
				return false;
			}
			if (this.class10_0.tTC_Doc.Rows.Count > 0 && this.class10_0.tTC_Doc.Rows[0]["numDoc"] != DBNull.Value)
			{
				this.string_0 = this.class10_0.tTC_Doc.Rows[0]["numDoc"].ToString();
			}
			if (!this.method_12())
			{
				return false;
			}
			if (!this.method_13())
			{
				return false;
			}
			if (!this.method_14())
			{
				return false;
			}
			if (!this.method_23())
			{
				return false;
			}
			if (!this.method_24())
			{
				return false;
			}
			this.isFile = false;
			MessageBox.Show("Данные успешно сохранены.");
			return true;
		}

		private void method_10()
		{
			DataRow dataRow = this.class10_0.tTC_Doc.NewRow();
			if (!string.IsNullOrEmpty(this.txtNumDoc.Text))
			{
				dataRow["numDoc"] = this.txtNumDoc.Text;
			}
			dataRow["dateDoc"] = this.dateTimePicker_0.Value.Date;
			dataRow["typeDoc"] = 1123;
			if (!string.IsNullOrEmpty(this.textBox_3.Text))
			{
				dataRow["Body"] = this.textBox_3.Text;
			}
			this.class10_0.tTC_Doc.Rows.Add(dataRow);
			this.int_0 = base.InsertSqlDataOneRow(this.class10_0, this.class10_0.tTC_Doc);
			if (this.int_0 > 0)
			{
				base.SelectSqlData(this.class10_0, this.class10_0.tTC_Doc, true, "where id = " + this.int_0.ToString());
			}
		}

		private bool method_11()
		{
			if (this.class10_0.tTC_Doc.Rows.Count > 0)
			{
				this.class10_0.tTC_Doc.Rows[0].EndEdit();
				return base.UpdateSqlData(this.class10_0, this.class10_0.tTC_Doc);
			}
			return false;
		}

		private bool method_12()
		{
			if (this.class10_0.tTC_DocOut.Rows.Count > 0)
			{
				if (this.comboBox_0.SelectedIndex >= 0)
				{
					this.class10_0.tTC_DocOut.Rows[0]["idDoc"] = Convert.ToInt32(this.comboBox_0.SelectedValue);
					this.class10_0.tTC_DocOut.Rows[0]["idDocOut"] = this.int_0;
					this.class10_0.tTC_DocOut.Rows[0].EndEdit();
					return base.UpdateSqlData(this.class10_0, this.class10_0.tTC_DocOut);
				}
				if (Convert.ToInt32(this.class10_0.tTC_DocOut.Rows[0]["id"]) > 0)
				{
					if (base.DeleteSqlDataById(this.class10_0.tTC_DocOut, Convert.ToInt32(this.class10_0.tTC_DocOut.Rows[0]["id"])))
					{
						this.class10_0.tTC_DocOut.Clear();
						return true;
					}
					return false;
				}
			}
			else if (this.int_0 > 0 && this.comboBox_0.SelectedIndex >= 0)
			{
				DataRow dataRow = this.class10_0.tTC_DocOut.NewRow();
				dataRow["idDoc"] = Convert.ToInt32(this.comboBox_0.SelectedValue);
				dataRow["idDocOut"] = this.int_0;
				this.class10_0.tTC_DocOut.Rows.Add(dataRow);
				int num = base.InsertSqlDataOneRow(this.class10_0, this.class10_0.tTC_DocOut);
				if (num <= 0)
				{
					this.class10_0.tTC_DocOut.Clear();
					return false;
				}
				base.SelectSqlData(this.class10_0, this.class10_0.tTC_DocOut, true, " where id = " + num.ToString());
			}
			return true;
		}

		private bool method_13()
		{
			if (this.class10_0.tTC_TU.Rows.Count > 0)
			{
				if (this.nullableNumericUpDown_0.Value != null)
				{
					this.class10_0.tTC_TU.Rows[0]["Power"] = this.nullableNumericUpDown_0.Value;
				}
				else
				{
					this.class10_0.tTC_TU.Rows[0]["Power"] = DBNull.Value;
				}
				if (this.nullableNumericUpDown_1.Value != null)
				{
					this.class10_0.tTC_TU.Rows[0]["PowerAdd"] = this.nullableNumericUpDown_1.Value;
				}
				else
				{
					this.class10_0.tTC_TU.Rows[0]["PowerAdd"] = DBNull.Value;
				}
				if (this.nullableNumericUpDown_2.Value != null)
				{
					this.class10_0.tTC_TU.Rows[0]["PowerSum"] = this.nullableNumericUpDown_2.Value;
				}
				else
				{
					this.class10_0.tTC_TU.Rows[0]["PowerSum"] = DBNull.Value;
				}
				this.class10_0.tTC_TU.Rows[0].EndEdit();
				return base.UpdateSqlData(this.class10_0, this.class10_0.tTC_TU);
			}
			if (this.int_0 <= 0)
			{
				return true;
			}
			DataRow dataRow = this.class10_0.tTC_TU.NewRow();
			dataRow["id"] = this.int_0;
			if (this.nullableNumericUpDown_0.Value != null)
			{
				dataRow["Power"] = this.nullableNumericUpDown_0.Value;
			}
			if (this.nullableNumericUpDown_1.Value != null)
			{
				dataRow["PowerAdd"] = this.nullableNumericUpDown_1.Value;
			}
			if (this.nullableNumericUpDown_2.Value != null)
			{
				dataRow["PowerSum"] = this.nullableNumericUpDown_2.Value;
			}
			if (this.comboBox_1.SelectedIndex >= 0)
			{
				dataRow["Category"] = this.comboBox_1.SelectedValue;
			}
			if (this.comboBox_3.SelectedIndex >= 0)
			{
				dataRow["VoltageLevel"] = this.comboBox_3.SelectedValue;
			}
			if (this.comboBox_2.SelectedIndex >= 0)
			{
				dataRow["Performer"] = this.comboBox_2.SelectedValue;
			}
			this.class10_0.tTC_TU.Rows.Add(dataRow);
			if (base.InsertSqlData(this.class10_0, this.class10_0.tTC_TU))
			{
				this.class10_0.tTC_TU.AcceptChanges();
				return true;
			}
			this.class10_0.tTC_TU.Clear();
			return false;
		}

		private bool method_14()
		{
			foreach (object obj in ((IEnumerable)this.dataGridView_0.Rows))
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
				if (dataGridViewRow.Index < this.class10_0.tTC_TUPointAttach.Rows.Count)
				{
					this.class10_0.tTC_TUPointAttach.Rows[dataGridViewRow.Index]["idTU"] = this.int_0;
					this.class10_0.tTC_TUPointAttach.Rows[dataGridViewRow.Index]["num"] = dataGridViewRow.Index + 1;
					this.class10_0.tTC_TUPointAttach.Rows[dataGridViewRow.Index]["idSubPoint"] = ((dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_52.Name].Value != null) ? dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_52.Name].Value : DBNull.Value);
					this.class10_0.tTC_TUPointAttach.Rows[dataGridViewRow.Index]["idBusPoint"] = ((dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_54.Name].Value != null) ? dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_54.Name].Value : DBNull.Value);
					this.class10_0.tTC_TUPointAttach.Rows[dataGridViewRow.Index]["idCellPoint"] = ((dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_56.Name].Value != null) ? dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_56.Name].Value : DBNull.Value);
					this.class10_0.tTC_TUPointAttach.Rows[dataGridViewRow.Index]["idSubCP"] = ((dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_58.Name].Value != null) ? dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_58.Name].Value : DBNull.Value);
					this.class10_0.tTC_TUPointAttach.Rows[dataGridViewRow.Index]["idBusCP"] = ((dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_60.Name].Value != null) ? dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_60.Name].Value : DBNull.Value);
					this.class10_0.tTC_TUPointAttach.Rows[dataGridViewRow.Index]["idCellCP"] = ((dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_62.Name].Value != null) ? dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_62.Name].Value : DBNull.Value);
					this.class10_0.tTC_TUPointAttach.Rows[dataGridViewRow.Index]["voltageLevel"] = ((dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_64.Name].Value != null) ? dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_64.Name].Value : DBNull.Value);
					this.class10_0.tTC_TUPointAttach.Rows[dataGridViewRow.Index]["PowerSum"] = ((dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_66.Name].Value != null) ? dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_66.Name].Value : DBNull.Value);
					this.class10_0.tTC_TUPointAttach.Rows[dataGridViewRow.Index]["Description"] = ((dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_67.Name].Value != null) ? dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_67.Name].Value : DBNull.Value);
					this.class10_0.tTC_TUPointAttach.Rows[dataGridViewRow.Index]["TypeDoc"] = 1123;
					this.class10_0.tTC_TUPointAttach.Rows[dataGridViewRow.Index].EndEdit();
				}
				else
				{
					DataRow dataRow = this.class10_0.tTC_TUPointAttach.NewRow();
					dataRow["idTU"] = this.int_0;
					dataRow["num"] = dataGridViewRow.Index + 1;
					if (dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_52.Name].Value != null)
					{
						dataRow["idSubPoint"] = dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_52.Name].Value;
					}
					if (dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_54.Name].Value != null)
					{
						dataRow["idBusPoint"] = dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_54.Name].Value;
					}
					if (dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_56.Name].Value != null)
					{
						dataRow["idCellPoint"] = dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_56.Name].Value;
					}
					if (dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_58.Name].Value != null)
					{
						dataRow["idSubCP"] = dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_58.Name].Value;
					}
					if (dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_60.Name].Value != null)
					{
						dataRow["idBusCP"] = dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_60.Name].Value;
					}
					if (dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_62.Name].Value != null)
					{
						dataRow["idCellCP"] = dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_62.Name].Value;
					}
					if (dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_64.Name].Value != null)
					{
						dataRow["voltageLevel"] = dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_64.Name].Value;
					}
					if (dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_66.Name].Value != null)
					{
						dataRow["PowerSum"] = dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_66.Name].Value;
					}
					if (dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_67.Name].Value != null)
					{
						dataRow["Description"] = dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_67.Name].Value;
					}
					dataRow["TypeDoc"] = 1123;
					this.class10_0.tTC_TUPointAttach.Rows.Add(dataRow);
				}
			}
			for (int i = this.class10_0.tTC_TUPointAttach.Rows.Count - 1; i > this.dataGridView_0.Rows.Count - 1; i--)
			{
				this.class10_0.tTC_TUPointAttach.Rows[i].Delete();
			}
			base.InsertSqlData(this.class10_0, this.class10_0.tTC_TUPointAttach);
			base.UpdateSqlData(this.class10_0, this.class10_0.tTC_TUPointAttach);
			base.DeleteSqlData(this.class10_0, this.class10_0.tTC_TUPointAttach);
			this.method_0();
			return true;
		}
        /// <summary>
        /// загружаем шаблоны печатных форм документов и заполняем комбобокс
        /// </summary>
		private void LoadTemplate()
		{
			foreach (object obj in new SqlDataCommand(this.SqlSettings).SelectSqlData(" SELECT doc.id, doc.FileName  FROM tR_DocTemplate AS doc  INNER JOIN [tR_Classifier] AS c ON doc.idTypeDoc = c.id  WHERE c.ParentKey = ';TypeDoc;tR_DocTemplate;' AND c.Deleted = ((0)) AND c.isGroup = ((0)) AND c.Value = 1 and doc.deleted = 0").Rows)
			{
				DataRow dataRow = (DataRow)obj;
				ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
				toolStripMenuItem.Text = dataRow["FileName"].ToString();
				toolStripMenuItem.Tag = dataRow["id"];
				toolStripMenuItem.Click += this.toolStripMenuItem_Click;
				this.toolBtnAddFile.DropDownItems.Add(toolStripMenuItem);
				ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem();
				toolStripMenuItem2.Text = dataRow["FileName"].ToString();
				toolStripMenuItem2.Tag = dataRow["id"];
				toolStripMenuItem2.Click += this.toolStripMenuItem_Click;
				this.toolStripMenuItem_1.DropDownItems.Add(toolStripMenuItem2);
			}
		}
        /// <summary> GetFileName
        /// при создании отчета, файл должен сохраниться в базу данных
        /// </summary>
		private string GetFileName(string FileName, int? idTemplate = null, byte[] fileData = null)
		{
			string fileName = Path.GetFileName(FileName);
			bool flag = true;
			while (this.dicWatcherFile.ContainsKey(fileName))
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
					FileWatcherArgsAddl value = new FileWatcherArgsAddl(idTemplate, fileName, null, FileOpenState.None);
					this.dicWatcherFile.Add(fileName, value);
					Class10.Class88 rowDocFile = this.class10_0.tTC_DocFile.method_5(); // (Class10.Class88)base.NewRow();
                    rowDocFile.idDoc = -1;
					rowDocFile.FileName = fileName;
					if (fileData == null)
					{
						FileBinary fileBinary = new FileBinary(FileName);
						rowDocFile.File = fileBinary.ByteArray;
						rowDocFile.dateChange = fileBinary.LastChanged;
					}
					else
					{
						rowDocFile.File = fileData;
						rowDocFile.dateChange = DateTime.Now;
					}
					if (idTemplate != null)
					{
						rowDocFile.idTemplate = idTemplate.Value;
					}
					this.class10_0.tTC_DocFile.method_0(rowDocFile); // base.Rows.Add(class88_0);
                    return fileName;
				}
			}
			goto IL_57;
		}

		private void toolStripMenuItem_2_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Multiselect = true;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				foreach (string _fileName in openFileDialog.FileNames)
				{
					if (!string.IsNullOrEmpty(this.GetFileName(_fileName, null, null)))
					{
						this.isFile = true;
					}
				}
			}
		}

		private void toolStripMenuItem_Click(object sender, EventArgs e)
		{
			int idTemplate = (int)((ToolStripMenuItem)sender).Tag; // id шаблона в таблице
			string FileNameOut;
			byte[] fileData;
			this.GetFileTemplateForTable(idTemplate, out FileNameOut, out fileData);
			string extension = new System.IO.FileInfo(FileNameOut).Extension;
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
            if (extension == ".doc" || extension == ".xlsx")
            {
               

            }
            else if (extension == ".xltx" || extension == ".xlt")
            {  FileNameOut = FileNameOut.Replace(extension, extension.Replace("t", "s"));}
                else if (extension == ".dotx" || extension == ".dot")
            { FileNameOut = FileNameOut.Replace(extension, extension.Replace("t", "c")); }

                FileNameOut = FileNameOut.Replace(extension, extension.Replace("t", "s"));
			goto IL_162;
			IL_13B:
			FileNameOut = FileNameOut.Replace(extension, extension.Replace("t", "c"));
			IL_162:
			string TempPath = this.GetTempPath();
			string newFileNameIsExists = FileBinary.GetNewFileNameIsExists(TempPath, FileNameOut, false);
			string fileNameOut = this.GetFileName(FileNameOut, new int?(idTemplate), fileData);
			if (!string.IsNullOrEmpty(fileNameOut))
			{
				this.isFile = true;
				FileBinary fileBinary = new FileBinary(fileData, newFileNameIsExists, DateTime.Now);
				fileBinary.SaveToDisk(TempPath);
				extension = new System.IO.FileInfo(FileNameOut).Extension;
				if (!(extension == ".doc") && !(extension == ".docx"))
				{
					Process.Start(TempPath + "\\" + fileBinary.Name);
				}
				else if (!this.CreateDocOut(TempPath + "\\" + fileBinary.Name))
				{
					Process.Start(TempPath + "\\" + fileBinary.Name);
				}
				if (this.dicWatcherFile.ContainsKey(fileNameOut))
				{
					FileWatcher fileWatcher = new FileWatcher(TempPath, fileBinary.Name);
					fileWatcher.AnyChanged += this.FileWatcher_AnyChanged;
					fileWatcher.Start();
					this.dicWatcherFile[fileNameOut].TempName = newFileNameIsExists;
					this.dicWatcherFile[fileNameOut].Watcher = fileWatcher;
					this.dicWatcherFile[fileNameOut].OpenState = FileOpenState.Editing;
					return;
				}
				MessageBox.Show("Что то пошло не так");
			}
		}

		private bool CreateDocOut(string FileName)
		{
			bool result;
			try
			{
				OfficeLB.Word.Application application = new OfficeLB.Word.Application();
                OfficeLB.Word.Documents documents = application.Documents;
				documents.Open(FileName);
				application.Visible = true;
				Bookmarks bookmarks = documents[1].Range.Bookmarks;
				if (bookmarks.Exists("NumTU"))
				{
					bookmarks["NumTU"].Range.Text = this.txtNumDoc.Text;
				}
				if (bookmarks.Exists("DateTU"))
				{
					bookmarks["DateTU"].Range.Text = this.dateTimePicker_0.Value.ToString("dd MMMM yyyy") + " г.";
				}
				if (bookmarks.Exists("NameAbn"))
				{
					bookmarks["NameAbn"].Range.Text = this.textBox_1.Text;
				}
				if (bookmarks.Exists("VRU"))
				{
					if (string.IsNullOrEmpty(this.textBox_4.Text))
					{
						bookmarks["VRU"].Range.Text = "ВРУ-" + this.comboBox_3.Text;
					}
					else
					{
						bookmarks["VRU"].Range.Text = this.textBox_4.Text;
					}
				}
				if (bookmarks.Exists("AbnObj"))
				{
					bookmarks["AbnObj"].Range.Text = this.textBox_2.Text;
				}
				if (bookmarks.Exists("PowerMax"))
				{
					bookmarks["PowerMax"].Range.Text = this.nullableNumericUpDown_2.Value.ToString();
				}
				if (bookmarks.Exists("Category"))
				{
					bookmarks["Category"].Range.Text = this.comboBox_1.Text;
				}
				if (bookmarks.Exists("VoltageLevel"))
				{
					bookmarks["VoltageLevel"].Range.Text = this.comboBox_3.Text;
				}
				if (bookmarks.Exists("PointAttach") && this.dataGridView_0.Rows.Count > 0)
				{
					int num = -1;
					if (this.dataGridView_0.Rows[0].Cells[this.dataGridViewTextBoxColumn_56.Name].Value != null && this.dataGridView_0.Rows[0].Cells[this.dataGridViewTextBoxColumn_56.Name].Value != DBNull.Value)
					{
						num = Convert.ToInt32(this.dataGridView_0.Rows[0].Cells[this.dataGridViewTextBoxColumn_56.Name].Value);
					}
					else if (this.dataGridView_0.Rows[0].Cells[this.dataGridViewTextBoxColumn_54.Name].Value != null && this.dataGridView_0.Rows[0].Cells[this.dataGridViewTextBoxColumn_54.Name].Value != DBNull.Value)
					{
						num = Convert.ToInt32(this.dataGridView_0.Rows[0].Cells[this.dataGridViewTextBoxColumn_54.Name].Value);
					}
					else if (this.dataGridView_0.Rows[0].Cells[this.dataGridViewTextBoxColumn_52.Name].Value != null && this.dataGridView_0.Rows[0].Cells[this.dataGridViewTextBoxColumn_52.Name].Value != DBNull.Value)
					{
						num = Convert.ToInt32(this.dataGridView_0.Rows[0].Cells[this.dataGridViewTextBoxColumn_52.Name].Value);
					}
					if (num > 0)
					{
						string text = base.CallSQLScalarFunction("dbo.fn_Schm_GetFullNameObjById", new string[]
						{
							num.ToString()
						}).ToString();
						bookmarks["PointAttach"].Range.Text = text;
					}
				}
				if (bookmarks.Exists("PowerMaxPoint"))
				{
					bookmarks["PowerMaxPoint"].Range.Text = "(" + this.nullableNumericUpDown_2.Value.ToString() + " кВт)";
				}
				if (bookmarks.Exists("CP"))
				{
					if (this.dataGridView_0.Rows.Count > 0)
					{
						int num2 = -1;
						if (this.dataGridView_0.Rows[0].Cells[this.dataGridViewTextBoxColumn_62.Name].Value != null && this.dataGridView_0.Rows[0].Cells[this.dataGridViewTextBoxColumn_62.Name].Value != DBNull.Value)
						{
							num2 = Convert.ToInt32(this.dataGridView_0.Rows[0].Cells[this.dataGridViewTextBoxColumn_62.Name].Value);
						}
						else if (this.dataGridView_0.Rows[0].Cells[this.dataGridViewTextBoxColumn_60.Name].Value != null && this.dataGridView_0.Rows[0].Cells[this.dataGridViewTextBoxColumn_60.Name].Value != DBNull.Value)
						{
							num2 = Convert.ToInt32(this.dataGridView_0.Rows[0].Cells[this.dataGridViewTextBoxColumn_60.Name].Value);
						}
						else if (this.dataGridView_0.Rows[0].Cells[this.dataGridViewTextBoxColumn_58.Name].Value != null && this.dataGridView_0.Rows[0].Cells[this.dataGridViewTextBoxColumn_58.Name].Value != DBNull.Value)
						{
							num2 = Convert.ToInt32(this.dataGridView_0.Rows[0].Cells[this.dataGridViewTextBoxColumn_58.Name].Value);
						}
						if (num2 > 0)
						{
							string text2 = base.CallSQLScalarFunction("dbo.fn_Schm_GetFullNameObjById", new string[]
							{
								num2.ToString()
							}).ToString();
							bookmarks["CP"].Range.Text = text2;
						}
						else
						{
							bookmarks["CP"].Range.Text = "не предусмотрен";
						}
					}
					else
					{
						bookmarks["CP"].Range.Text = "не предусмотрен";
					}
				}
				if (bookmarks.Exists("CP2"))
				{
					if (this.dataGridView_0.Rows.Count > 1)
					{
						int num3 = -1;
						if (this.dataGridView_0.Rows[1].Cells[this.dataGridViewTextBoxColumn_62.Name].Value != null && this.dataGridView_0.Rows[1].Cells[this.dataGridViewTextBoxColumn_62.Name].Value != DBNull.Value)
						{
							num3 = Convert.ToInt32(this.dataGridView_0.Rows[1].Cells[this.dataGridViewTextBoxColumn_62.Name].Value);
						}
						else if (this.dataGridView_0.Rows[1].Cells[this.dataGridViewTextBoxColumn_60.Name].Value != null && this.dataGridView_0.Rows[1].Cells[this.dataGridViewTextBoxColumn_60.Name].Value != DBNull.Value)
						{
							num3 = Convert.ToInt32(this.dataGridView_0.Rows[1].Cells[this.dataGridViewTextBoxColumn_60.Name].Value);
						}
						else if (this.dataGridView_0.Rows[1].Cells[this.dataGridViewTextBoxColumn_58.Name].Value != null && this.dataGridView_0.Rows[1].Cells[this.dataGridViewTextBoxColumn_58.Name].Value != DBNull.Value)
						{
							num3 = Convert.ToInt32(this.dataGridView_0.Rows[1].Cells[this.dataGridViewTextBoxColumn_58.Name].Value);
						}
						if (num3 > 0)
						{
							string text3 = base.CallSQLScalarFunction("dbo.fn_Schm_GetFullNameObjById", new string[]
							{
								num3.ToString()
							}).ToString();
							bookmarks["CP2"].Range.Text = text3;
						}
						else
						{
							bookmarks["CP2"].Range.Text = "не предусмотрен";
						}
					}
					else
					{
						bookmarks["CP2"].Range.Text = "не предусмотрен";
					}
				}
				if (bookmarks.Exists("NetWork"))
				{
					string text4 = "";
					foreach (object obj in ((IEnumerable)this.dataGridViewExcelFilter_2.Rows))
					{
						DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
						if (dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_45.Name].Value != null)
						{
							if (string.IsNullOrEmpty(text4))
							{
								text4 = text4 + dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_45.Name].Value + ";";
							}
							else
							{
								text4 = string.Concat(new object[]
								{
									text4,
									"\r\n",
									dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_45.Name].Value,
									";"
								});
							}
						}
					}
					bookmarks["NetWork"].Range.Text = text4;
				}
				if (bookmarks.Exists("ClientWork"))
				{
					string text5 = "";
					foreach (object obj2 in ((IEnumerable)this.dataGridViewExcelFilter_3.Rows))
					{
						DataGridViewRow dataGridViewRow2 = (DataGridViewRow)obj2;
						if (dataGridViewRow2.Cells[this.dataGridViewTextBoxColumn_40.Name].Value != null)
						{
							if (string.IsNullOrEmpty(text5))
							{
								text5 = text5 + dataGridViewRow2.Cells[this.dataGridViewTextBoxColumn_40.Name].Value + ";";
							}
							else
							{
								text5 = string.Concat(new object[]
								{
									text5,
									"\r\n",
									dataGridViewRow2.Cells[this.dataGridViewTextBoxColumn_40.Name].Value,
									";"
								});
							}
						}
					}
					bookmarks["ClientWork"].Range.Text = text5;
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
			this.method_19(true);
		}

		private void toolStripMenuItem_4_Click(object sender, EventArgs e)
		{
			this.method_19(false);
		}

		private void toolStripMenuItem_5_Click(object sender, EventArgs e)
		{
			if (this.bindingSource_0.Current != null && MessageBox.Show("Вы действительно хотите удалить выбранный файл?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				Class10.Class88 @class = (Class10.Class88)((DataRowView)this.bindingSource_0.Current).Row;
				string fileName = @class.FileName;
				if (this.dicWatcherFile.ContainsKey(fileName))
				{
					if (this.dicWatcherFile[fileName].Watcher != null)
					{
						this.dicWatcherFile[fileName].Watcher.AnyChanged -= this.FileWatcher_AnyChanged;
						this.dicWatcherFile[fileName].Watcher.Stop();
					}
					this.dicWatcherFile.Remove(fileName);
				}
				@class.Delete();
				this.isFile = true;
			}
		}

		private void toolStripMenuItem_6_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_0.CurrentRow != null)
			{
				this.string_1 = this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewFilterTextBoxColumn_0.Name].Value.ToString();
				this.dataGridViewExcelFilter_0.CurrentCell = this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewFilterTextBoxColumn_0.Name];
				this.dataGridViewExcelFilter_0.CurrentCell.Value = Path.GetFileNameWithoutExtension(this.string_1);
				this.dataGridViewExcelFilter_0.ReadOnly = false;
				this.dataGridViewFilterTextBoxColumn_0.ReadOnly = false;
				this.dataGridViewExcelFilter_0.BeginEdit(true);
			}
		}

		private void toolStripMenuItem_7_Click(object sender, EventArgs e)
		{
			if (this.bindingSource_0.Current != null)
			{
				Class10.Class88 @class = (Class10.Class88)((DataRowView)this.bindingSource_0.Current).Row;
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
					this.ByteArrayToFile(saveFileDialog.FileName, file);
				}
			}
		}

		public bool ByteArrayToFile(string fileName, byte[] byteArray)
		{
			try
			{
				FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
				fileStream.Write(byteArray, 0, byteArray.Length);
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

		private void method_19(bool bool_1 = false)
		{
			if (this.bindingSource_0.Current != null)
			{
				Class10.Class88 @class = (Class10.Class88)((DataRowView)this.bindingSource_0.Current).Row;
				string fileName = @class.FileName;
				string text = this.GetTempPath();
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
					if (this.dicWatcherFile.ContainsKey(fileName))
					{
						if (this.dicWatcherFile[fileName].Watcher == null)
						{
							FileWatcher fileWatcher = new FileWatcher(text, newFileNameIsExists);
							fileWatcher.AnyChanged += this.FileWatcher_AnyChanged;
							fileWatcher.Start();
							this.dicWatcherFile[fileName].Watcher = fileWatcher;
						}
						else
						{
							this.dicWatcherFile[fileName].Watcher.AnyChanged -= this.FileWatcher_AnyChanged;
							this.dicWatcherFile[fileName].Watcher.Stop();
							FileWatcher fileWatcher2 = new FileWatcher(text, newFileNameIsExists);
							fileWatcher2.AnyChanged += this.FileWatcher_AnyChanged;
							fileWatcher2.Start();
							this.dicWatcherFile[fileName].Watcher = fileWatcher2;
						}
						this.dicWatcherFile[fileName].TempName = newFileNameIsExists;
						this.dicWatcherFile[fileName].OpenState = FileOpenState.Editing;
						return;
					}
					FileWatcher fileWatcher3 = new FileWatcher(text, newFileNameIsExists);
					fileWatcher3.AnyChanged += this.FileWatcher_AnyChanged;
					fileWatcher3.Start();
					FileWatcherArgsAddl value = new FileWatcherArgsAddl(idTemplate, fileName, newFileNameIsExists, fileWatcher3, FileOpenState.Editing);
					this.dicWatcherFile.Add(fileName, value);
				}
			}
		}

		private void FileWatcher_AnyChanged(object sender, FileSystemEventArgs e)
		{
			IEnumerable<KeyValuePair<string, FileWatcherArgsAddl>> fwargs = from item in this.dicWatcherFile
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
					this.isFile = true;
				}
			}
			this.dBpwcnqehH();
		}

		private bool method_20(string string_2)
		{
			return (from row in this.class10_0.tTC_DocFile
			where row.FileName == string_2
			select row).Count<Class10.Class88>() > 0;
		}

		private void dBpwcnqehH()
		{
			if (base.InvokeRequired)
			{
				base.Invoke(new Action(this.method_29));
				return;
			}
			this.bindingSource_0.ResetBindings(false);
		}

		private string GetTempPath()
		{
			string text = "EIS\\TU";
			if (!string.IsNullOrEmpty(this.txtNumDoc.Text))
			{
				text = text + "\\" + this.txtNumDoc.Text;
			}
			string text2 = Path.GetTempPath() + "\\" + text + "\\";
			if (!Directory.Exists(text2))
			{
				Directory.CreateDirectory(text2);
			}
			return text2;
		}

		public void GetFileTemplateForTable(int idTemplate, out string fileName, out byte[] fileData)
		{
			fileName = "";
			fileData = null;
			string cmdText = "SELECT FileName, FileData FROM tR_DocTemplate WHERE id = @idTemplate";
			using (SqlConnection sqlConnection = new SqlConnection(this.SqlSettings.GetConnectionString()))
			{
				SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
				sqlCommand.Parameters.Add("@idTemplate", SqlDbType.Int);
				sqlCommand.Parameters["@idTemplate"].Value = idTemplate;
				try
				{
					sqlConnection.Open();
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					while (sqlDataReader.Read())
					{
						fileName = (string)sqlDataReader.GetValue(0);
						fileData = (byte[])sqlDataReader.GetValue(1);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, ex.Source);
				}
			}
		}

		private void method_22(int int_5)
		{
			try
			{
				using (SqlConnection sqlConnection = new SqlConnection(this.SqlSettings.GetConnectionString()))
				{
					sqlConnection.Open();
					SqlDataReader sqlDataReader = new SqlCommand("SELECT id, idDoc, FileName, dateChange, idTemplate FROM tTC_DocFile WHERE idDoc = " + int_5.ToString(), sqlConnection).ExecuteReader();
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
						this.dicWatcherFile.Add(sqlDataReader["FileName"].ToString(), value);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, ex.Source);
			}
		}

		private bool method_23()
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

		private void dataGridViewExcelFilter_0_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
		{
			if (((DataGridView)sender).RowCount > 0 && this.dataGridViewExcelFilter_0[this.dataGridViewFilterTextBoxColumn_0.Name, e.RowIndex].Value != null)
			{
				if (e.ColumnIndex == this.dataGridViewExcelFilter_0.Columns[this.dataGridViewImageColumnNotNull_0.Name].Index)
				{
					if (!string.IsNullOrEmpty(Path.GetFileName(this.dataGridViewExcelFilter_0[this.dataGridViewFilterTextBoxColumn_0.Name, e.RowIndex].Value.ToString())))
					{
						e.Value = Path.GetFileName(this.dataGridViewExcelFilter_0[this.dataGridViewFilterTextBoxColumn_0.Name, e.RowIndex].Value.ToString());
					}
					else
					{
						e.Value = this.dataGridViewExcelFilter_0[this.dataGridViewFilterTextBoxColumn_0.Name, e.RowIndex].Value.ToString();
					}
				}
				if (e.ColumnIndex == this.dataGridViewExcelFilter_0.Columns[this.dataGridViewImageColumnNotNull_0.Name].Index)
				{
					Icon icon = FormLbr.Classes.FileInfo.IconOfFile(this.dataGridViewExcelFilter_0[this.dataGridViewFilterTextBoxColumn_0.Name, e.RowIndex].Value.ToString());
					if (icon != null)
					{
						e.Value = icon.ToBitmap();
					}
				}
			}
		}

		private void dataGridViewExcelFilter_0_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			this.toolStripMenuItem_4_Click(sender, e);
		}

		private void dataGridViewExcelFilter_0_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			this.dataGridViewExcelFilter_0.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_0.ReadOnly = true;
			string text = this.dataGridViewExcelFilter_0[e.ColumnIndex, e.RowIndex].Value.ToString() + Path.GetExtension(this.string_1);
			if (text == this.string_1)
			{
				return;
			}
			if (this.dicWatcherFile.ContainsKey(this.string_1))
			{
				FileWatcherArgsAddl fileWatcherArgsAddl = this.dicWatcherFile[this.string_1];
				fileWatcherArgsAddl.OriginalName = text;
				this.dicWatcherFile.Remove(this.string_1);
				this.dicWatcherFile.Add(text, fileWatcherArgsAddl);
				this.dataGridViewExcelFilter_0[e.ColumnIndex, e.RowIndex].Value = text;
				this.isFile = true;
			}
			this.string_1 = null;
		}

		private void dataGridViewExcelFilter_0_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
		{
			if (e.ColumnIndex == 1 && e.RowIndex >= 0 && !string.IsNullOrEmpty(this.string_1))
			{
				string text = e.FormattedValue + Path.GetExtension(this.string_1);
				if (text == this.string_1)
				{
					return;
				}
				if (this.dicWatcherFile.ContainsKey(text))
				{
					MessageBox.Show("Файл с таким именем уже существует", "");
					e.Cancel = true;
				}
			}
		}

		private void dataGridViewExcelFilter_0_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Button == MouseButtons.Right)
			{
				this.dataGridViewExcelFilter_0.ClearSelection();
				this.dataGridViewExcelFilter_0.Rows[e.RowIndex].Selected = true;
				this.dataGridViewExcelFilter_0.CurrentCell = this.dataGridViewExcelFilter_0[e.ColumnIndex, e.RowIndex];
				Rectangle cellDisplayRectangle = this.dataGridViewExcelFilter_0.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
				this.contextMenuStrip_0.Show((Control)sender, cellDisplayRectangle.Left + e.X, cellDisplayRectangle.Top + e.Y);
			}
		}

		private void dataGridViewExcelFilter_1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.RowIndex >= 0 && Convert.ToInt32(this.dataGridViewExcelFilter_1[this.dataGridViewTextBoxColumn_26.Name, e.RowIndex].Value) == 1113)
			{
				e.CellStyle.Font = new System.Drawing.Font(e.CellStyle.Font, FontStyle.Bold);
				e.CellStyle.BackColor = Color.LightGray;
			}
		}

		private void dataGridViewExcelFilter_1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
		{
			this.dataGridViewExcelFilter_1.AutoResizeRow(e.RowIndex);
		}

		private bool method_24()
		{
			for (int i = this.dataGridViewExcelFilter_2.Rows.Count - 2; i >= 0; i--)
			{
				if (this.dataGridViewExcelFilter_2[this.dataGridViewTextBoxColumn_45.Name, i].Value == null || this.dataGridViewExcelFilter_2[this.dataGridViewTextBoxColumn_45.Name, i].Value == DBNull.Value || string.IsNullOrEmpty(this.dataGridViewExcelFilter_2[this.dataGridViewTextBoxColumn_45.Name, i].Value.ToString()))
				{
					this.dataGridViewExcelFilter_2.Rows.RemoveAt(i);
				}
			}
			for (int j = this.dataGridViewExcelFilter_3.Rows.Count - 2; j >= 0; j--)
			{
				if (this.dataGridViewExcelFilter_3[this.dataGridViewTextBoxColumn_40.Name, j].Value == null || this.dataGridViewExcelFilter_3[this.dataGridViewTextBoxColumn_40.Name, j].Value == DBNull.Value || string.IsNullOrEmpty(this.dataGridViewExcelFilter_3[this.dataGridViewTextBoxColumn_40.Name, j].Value.ToString()))
				{
					this.dataGridViewExcelFilter_3.Rows.RemoveAt(j);
				}
			}
			int num = 1;
			foreach (object obj in ((IEnumerable)this.dataGridViewExcelFilter_2.Rows))
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
				if (dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_46.Name].Value != null && dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_46.Name].Value != DBNull.Value)
				{
					Class10.Class91 @class = this.class10_0.tTC_TUTypeWork.method_2(Convert.ToInt32(dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_46.Name].Value));
					@class["idTu"] = this.int_0;
					@class["num"] = num;
					@class.EndEdit();
					num++;
				}
			}
			num = 1;
			foreach (object obj2 in ((IEnumerable)this.dataGridViewExcelFilter_3.Rows))
			{
				DataGridViewRow dataGridViewRow2 = (DataGridViewRow)obj2;
				if (dataGridViewRow2.Cells[this.dataGridViewTextBoxColumn_41.Name].Value != null && dataGridViewRow2.Cells[this.dataGridViewTextBoxColumn_41.Name].Value != DBNull.Value)
				{
					Class10.Class91 class2 = this.class10_0.tTC_TUTypeWork.method_2(Convert.ToInt32(dataGridViewRow2.Cells[this.dataGridViewTextBoxColumn_41.Name].Value));
					class2["idTu"] = this.int_0;
					class2["num"] = num;
					class2.EndEdit();
					num++;
				}
			}
			if (!base.InsertSqlData(this.class10_0, this.class10_0.tTC_TUTypeWork))
			{
				return false;
			}
			if (!base.UpdateSqlData(this.class10_0, this.class10_0.tTC_TUTypeWork))
			{
				return false;
			}
			if (!base.DeleteSqlData(this.class10_0, this.class10_0.tTC_TUTypeWork))
			{
				return false;
			}
			base.SelectSqlData(this.class10_0.tTC_TUTypeWork, true, "where idtu = " + this.int_0.ToString() + " order by num ", null, false, 0);
			return true;
		}

		private void dataGridViewExcelFilter_3_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
		{
			((DataGridView)sender).AutoResizeRow(e.RowIndex);
		}

		private void dataGridViewExcelFilter_3_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			this.isFile = true;
		}

		private void dataGridViewExcelFilter_2_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
		{
			e.Row.Cells[this.dataGridViewTextBoxColumn_47.Name].Value = this.int_0;
			e.Row.Cells[this.dataGridViewTextBoxColumn_49.Name].Value = 1;
			e.Row.Cells[this.dataGridViewTextBoxColumn_48.Name].Value = e.Row.Index + 1;
		}

		private void dataGridViewExcelFilter_3_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
		{
			e.Row.Cells[this.dataGridViewTextBoxColumn_42.Name].Value = this.int_0;
			e.Row.Cells[this.dataGridViewTextBoxColumn_44.Name].Value = 2;
			e.Row.Cells[this.dataGridViewTextBoxColumn_43.Name].Value = e.Row.Index + 1;
		}

		private void toolStripButton_10_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_2.CurrentRow != null && this.dataGridViewExcelFilter_2.CurrentRow.Index > 0 && this.dataGridViewExcelFilter_2.CurrentRow.Cells[this.dataGridViewTextBoxColumn_46.Name].Value != null && this.dataGridViewExcelFilter_2.CurrentRow.Cells[this.dataGridViewTextBoxColumn_46.Name].Value != DBNull.Value)
			{
				DataRow dataRow = this.class10_0.tTC_TUTypeWork.method_2(Convert.ToInt32(this.dataGridViewExcelFilter_2.CurrentRow.Cells[this.dataGridViewTextBoxColumn_46.Name].Value));
				Class10.Class91 @class = this.class10_0.tTC_TUTypeWork.method_2(Convert.ToInt32(this.dataGridViewExcelFilter_2.Rows[this.dataGridViewExcelFilter_2.CurrentRow.Index - 1].Cells[this.dataGridViewTextBoxColumn_46.Name].Value));
				int num = Convert.ToInt32(@class["num"]);
				dataRow["num"] = num;
				@class["num"] = num + 1;
				dataRow.EndEdit();
				@class.EndEdit();
				this.isFile = true;
			}
		}

		private void toolStripButton_11_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_2.CurrentRow != null && this.dataGridViewExcelFilter_2.CurrentRow.Index < this.dataGridViewExcelFilter_2.Rows.Count - 2 && this.dataGridViewExcelFilter_2.CurrentRow.Cells[this.dataGridViewTextBoxColumn_46.Name].Value != null && this.dataGridViewExcelFilter_2.CurrentRow.Cells[this.dataGridViewTextBoxColumn_46.Name].Value != DBNull.Value)
			{
				DataRow dataRow = this.class10_0.tTC_TUTypeWork.method_2(Convert.ToInt32(this.dataGridViewExcelFilter_2.CurrentRow.Cells[this.dataGridViewTextBoxColumn_46.Name].Value));
				DataRow dataRow2 = this.class10_0.tTC_TUTypeWork.method_2(Convert.ToInt32(this.dataGridViewExcelFilter_2.Rows[this.dataGridViewExcelFilter_2.CurrentRow.Index + 1].Cells[this.dataGridViewTextBoxColumn_46.Name].Value));
				int num = Convert.ToInt32(dataRow["num"]);
				dataRow2["num"] = num;
				dataRow["num"] = num + 1;
				dataRow2.EndEdit();
				dataRow.EndEdit();
				this.isFile = true;
			}
		}

		private void toolStripButton_14_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(this.toolStripComboBox_0.Text))
			{
				DataRow dataRow = this.class10_0.tTC_TUTypeWork.NewRow();
				dataRow["idTU"] = this.int_0;
				dataRow["num"] = this.dataGridViewExcelFilter_2.Rows.Count;
				dataRow["Work"] = this.toolStripComboBox_0.Text;
				dataRow["typeWork"] = 1;
				this.class10_0.tTC_TUTypeWork.Rows.Add(dataRow);
				this.isFile = true;
			}
		}

		private void method_25()
		{
			int num = 0;
			foreach (object obj in this.toolStrip_2.Items)
			{
				ToolStripItem toolStripItem = (ToolStripItem)obj;
				if (toolStripItem != this.toolStripComboBox_0)
				{
					num += toolStripItem.Width;
				}
			}
			this.toolStripComboBox_0.Width = this.toolStrip_2.Width - num - 20;
		}

		private void toolStrip_2_Resize(object sender, EventArgs e)
		{
			this.method_25();
		}

		private void toolStripButton_12_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_3.CurrentRow != null && this.dataGridViewExcelFilter_3.CurrentRow.Index > 0 && this.dataGridViewExcelFilter_3.CurrentRow.Cells[this.dataGridViewTextBoxColumn_41.Name].Value != null && this.dataGridViewExcelFilter_3.CurrentRow.Cells[this.dataGridViewTextBoxColumn_41.Name].Value != DBNull.Value)
			{
				DataRow dataRow = this.class10_0.tTC_TUTypeWork.method_2(Convert.ToInt32(this.dataGridViewExcelFilter_3.CurrentRow.Cells[this.dataGridViewTextBoxColumn_41.Name].Value));
				Class10.Class91 @class = this.class10_0.tTC_TUTypeWork.method_2(Convert.ToInt32(this.dataGridViewExcelFilter_3.Rows[this.dataGridViewExcelFilter_3.CurrentRow.Index - 1].Cells[this.dataGridViewTextBoxColumn_41.Name].Value));
				int num = Convert.ToInt32(@class["num"]);
				dataRow["num"] = num;
				@class["num"] = num + 1;
				dataRow.EndEdit();
				@class.EndEdit();
				this.isFile = true;
			}
		}

		private void toolStripButton_13_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_3.CurrentRow != null && this.dataGridViewExcelFilter_3.CurrentRow.Index < this.dataGridViewExcelFilter_3.Rows.Count - 2 && this.dataGridViewExcelFilter_3.CurrentRow.Cells[this.dataGridViewTextBoxColumn_41.Name].Value != null && this.dataGridViewExcelFilter_3.CurrentRow.Cells[this.dataGridViewTextBoxColumn_41.Name].Value != DBNull.Value)
			{
				DataRow dataRow = this.class10_0.tTC_TUTypeWork.method_2(Convert.ToInt32(this.dataGridViewExcelFilter_3.CurrentRow.Cells[this.dataGridViewTextBoxColumn_41.Name].Value));
				DataRow dataRow2 = this.class10_0.tTC_TUTypeWork.method_2(Convert.ToInt32(this.dataGridViewExcelFilter_3.Rows[this.dataGridViewExcelFilter_3.CurrentRow.Index + 1].Cells[this.dataGridViewTextBoxColumn_41.Name].Value));
				int num = Convert.ToInt32(dataRow["num"]);
				dataRow2["num"] = num;
				dataRow["num"] = num + 1;
				dataRow2.EndEdit();
				dataRow.EndEdit();
				this.isFile = true;
			}
		}

		private void toolStripButton_15_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(this.toolStripComboBox_1.Text))
			{
				DataRow dataRow = this.class10_0.tTC_TUTypeWork.NewRow();
				dataRow["idTU"] = this.int_0;
				dataRow["num"] = this.dataGridViewExcelFilter_3.Rows.Count;
				dataRow["Work"] = this.toolStripComboBox_1.Text;
				dataRow["typeWork"] = 2;
				this.class10_0.tTC_TUTypeWork.Rows.Add(dataRow);
				this.isFile = true;
			}
		}

		private void method_26()
		{
			int num = 0;
			foreach (object obj in this.toolStrip_3.Items)
			{
				ToolStripItem toolStripItem = (ToolStripItem)obj;
				if (toolStripItem != this.toolStripComboBox_1)
				{
					num += toolStripItem.Width;
				}
			}
			this.toolStripComboBox_1.Width = this.toolStrip_3.Width - num - 20;
		}

		private void toolStrip_3_Resize(object sender, EventArgs e)
		{
			this.method_26();
		}

		private void toolStripButton_17_Click(object sender, EventArgs e)
		{
			if (new Form15
			{
				SqlSettings = this.SqlSettings
			}.ShowDialog() == DialogResult.OK)
			{
				this.method_2();
			}
		}

		private void dHewKxZoUa()
		{
			DataTable dataTable = this.method_27();
			base.SelectSqlData(dataTable, true, string.Format("where Module = '{0}'", "TypeWorkTU"), null, false, 0);
			try
			{
				if (dataTable.Rows.Count > 0 && dataTable.Rows[0]["Settings"] != DBNull.Value)
				{
					XmlDocument xmlDocument = new XmlDocument();
					xmlDocument.LoadXml(dataTable.Rows[0]["Settings"].ToString());
					XmlNodeReader xmlNodeReader = new XmlNodeReader(xmlDocument);
					this.dataSet_0.Clear();
					this.dataSet_0.ReadXml(xmlNodeReader);
					xmlNodeReader.Close();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, ex.Source);
			}
		}

		private DataTable method_27()
		{
			DataTable dataTable = new DataTable("tSettings");
			DataColumn dataColumn = dataTable.Columns.Add("id", typeof(int));
			dataColumn.AutoIncrement = true;
			dataTable.PrimaryKey = new DataColumn[]
			{
				dataColumn
			};
			dataTable.Columns.Add("settings", typeof(string));
			dataTable.Columns.Add("module", typeof(string));
			return dataTable;
		}

		private void method_28()
		{
			this.icontainer_0 = new Container();
			DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FormTUAddEdit));
			DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
			this.label_0 = new Label();
			this.txtNumDoc = new TextBox();
			this.class10_0 = new Class10();
			this.label_1 = new Label();
			this.dateTimePicker_0 = new DateTimePicker();
			this.label_2 = new Label();
			this.comboBox_0 = new ComboBox();
			this.textBox_2 = new TextBox();
			this.label_3 = new Label();
			this.textBox_1 = new TextBox();
			this.label_4 = new Label();
			this.label_5 = new Label();
			this.textBox_3 = new TextBox();
			this.label_6 = new Label();
			this.comboBox_1 = new ComboBox();
			this.nullableNumericUpDown_0 = new NullableNumericUpDown();
			this.label_7 = new Label();
			this.label_8 = new Label();
			this.comboBox_2 = new ComboBox();
			this.label_9 = new Label();
			this.comboBox_3 = new ComboBox();
			this.nullableNumericUpDown_1 = new NullableNumericUpDown();
			this.label_10 = new Label();
			this.nullableNumericUpDown_2 = new NullableNumericUpDown();
			this.label_11 = new Label();
			this.label_12 = new Label();
			this.dataGridView_0 = new DataGridView();
			this.dataGridViewTextBoxColumn_50 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_51 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_52 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_53 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_54 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_55 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_56 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_57 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_58 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_59 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_60 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_61 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_62 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_63 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_64 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_65 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_66 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_67 = new DataGridViewTextBoxColumn();
			this.toolStrip_0 = new ToolStrip();
			this.toolStripButton_0 = new ToolStripButton();
			this.toolStripButton_1 = new ToolStripButton();
			this.toolStripButton_2 = new ToolStripButton();
			this.toolStripSeparator_0 = new ToolStripSeparator();
			this.toolStripButton_3 = new ToolStripButton();
			this.toolStripButton_4 = new ToolStripButton();
			this.button_0 = new Button();
			this.button_1 = new Button();
			this.tabControl_0 = new TabControl();
			this.tabPage_0 = new TabPage();
			this.label_13 = new Label();
			this.textBox_4 = new TextBox();
			this.tabControl_1 = new TabControl();
			this.tabPage_2 = new TabPage();
			this.tabPage_3 = new TabPage();
			this.dataGridViewExcelFilter_1 = new DataGridViewExcelFilter();
			this.dataGridViewTextBoxColumn_22 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_23 = new DataGridViewTextBoxColumn();
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
			this.dataGridViewTextBoxColumn_35 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_36 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_37 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_38 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_39 = new DataGridViewTextBoxColumn();
			this.bindingSource_1 = new BindingSource(this.icontainer_0);
			this.tabPage_4 = new TabPage();
			this.splitContainer_0 = new SplitContainer();
			this.dataGridViewExcelFilter_2 = new DataGridViewExcelFilter();
			this.dataGridViewTextBoxColumn_45 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_46 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_47 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_48 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_49 = new DataGridViewTextBoxColumn();
			this.bindingSource_2 = new BindingSource(this.icontainer_0);
			this.toolStrip_2 = new ToolStrip();
			this.toolStripLabel_0 = new ToolStripLabel();
			this.toolStripButton_10 = new ToolStripButton();
			this.toolStripButton_11 = new ToolStripButton();
			this.toolStripSeparator_5 = new ToolStripSeparator();
			this.toolStripComboBox_0 = new ToolStripComboBox();
			this.toolStripButton_14 = new ToolStripButton();
			this.dataGridViewExcelFilter_3 = new DataGridViewExcelFilter();
			this.dataGridViewTextBoxColumn_40 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_41 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_42 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_43 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_44 = new DataGridViewTextBoxColumn();
			this.bindingSource_3 = new BindingSource(this.icontainer_0);
			this.toolStrip_3 = new ToolStrip();
			this.toolStripLabel_1 = new ToolStripLabel();
			this.toolStripButton_12 = new ToolStripButton();
			this.toolStripButton_13 = new ToolStripButton();
			this.toolStripSeparator_6 = new ToolStripSeparator();
			this.toolStripComboBox_1 = new ToolStripComboBox();
			this.toolStripButton_15 = new ToolStripButton();
			this.tabPage_1 = new TabPage();
			this.dataGridViewExcelFilter_0 = new DataGridViewExcelFilter();
			this.dataGridViewImageColumnNotNull_0 = new DataGridViewImageColumnNotNull();
			this.dataGridViewFilterTextBoxColumn_0 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewTextBoxColumn_18 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_19 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_20 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_21 = new DataGridViewTextBoxColumn();
			this.bindingSource_0 = new BindingSource(this.icontainer_0);
			this.toolStrip_1 = new ToolStrip();
			this.toolBtnAddFile = new ToolStripDropDownButton();
			this.toolStripMenuItem_0 = new ToolStripMenuItem();
			this.toolStripSeparator_1 = new ToolStripSeparator();
			this.toolStripButton_5 = new ToolStripButton();
			this.toolStripButton_6 = new ToolStripButton();
			this.toolStripButton_7 = new ToolStripButton();
			this.toolStripSeparator_2 = new ToolStripSeparator();
			this.toolStripButton_8 = new ToolStripButton();
			this.toolStripButton_9 = new ToolStripButton();
			this.backgroundWorker_0 = new BackgroundWorker();
			this.backgroundWorker_1 = new BackgroundWorker();
			this.backgroundWorker_2 = new BackgroundWorker();
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
			this.contextMenuStrip_0 = new ContextMenuStrip(this.icontainer_0);
			this.toolStripMenuItem_1 = new ToolStripMenuItem();
			this.toolStripMenuItem_2 = new ToolStripMenuItem();
			this.toolStripSeparator_3 = new ToolStripSeparator();
			this.toolStripMenuItem_3 = new ToolStripMenuItem();
			this.toolStripMenuItem_4 = new ToolStripMenuItem();
			this.toolStripMenuItem_5 = new ToolStripMenuItem();
			this.toolStripSeparator_4 = new ToolStripSeparator();
			this.toolStripMenuItem_6 = new ToolStripMenuItem();
			this.toolStripMenuItem_7 = new ToolStripMenuItem();
			this.toolStripButton_16 = new ToolStripButton();
			this.toolStripButton_17 = new ToolStripButton();
			this.dataSet_0 = new DataSet();
			this.dataTable_0 = new DataTable();
			this.dataColumn_0 = new DataColumn();
			this.dataTable_1 = new DataTable();
			this.dataColumn_1 = new DataColumn();
			((ISupportInitialize)this.class10_0).BeginInit();
			((ISupportInitialize)this.nullableNumericUpDown_0).BeginInit();
			((ISupportInitialize)this.nullableNumericUpDown_1).BeginInit();
			((ISupportInitialize)this.nullableNumericUpDown_2).BeginInit();
			((ISupportInitialize)this.dataGridView_0).BeginInit();
			this.toolStrip_0.SuspendLayout();
			this.tabControl_0.SuspendLayout();
			this.tabPage_0.SuspendLayout();
			this.tabControl_1.SuspendLayout();
			this.tabPage_2.SuspendLayout();
			this.tabPage_3.SuspendLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_1).BeginInit();
			((ISupportInitialize)this.bindingSource_1).BeginInit();
			this.tabPage_4.SuspendLayout();
			this.splitContainer_0.Panel1.SuspendLayout();
			this.splitContainer_0.Panel2.SuspendLayout();
			this.splitContainer_0.SuspendLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_2).BeginInit();
			((ISupportInitialize)this.bindingSource_2).BeginInit();
			this.toolStrip_2.SuspendLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_3).BeginInit();
			((ISupportInitialize)this.bindingSource_3).BeginInit();
			this.toolStrip_3.SuspendLayout();
			this.tabPage_1.SuspendLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_0).BeginInit();
			((ISupportInitialize)this.bindingSource_0).BeginInit();
			this.toolStrip_1.SuspendLayout();
			this.contextMenuStrip_0.SuspendLayout();
			((ISupportInitialize)this.dataSet_0).BeginInit();
			((ISupportInitialize)this.dataTable_0).BeginInit();
			((ISupportInitialize)this.dataTable_1).BeginInit();
			base.SuspendLayout();
			this.label_0.AutoSize = true;
			this.label_0.Location = new Point(16, 3);
			this.label_0.Name = "label1";
			this.label_0.Size = new Size(107, 13);
			this.label_0.TabIndex = 0;
			this.label_0.Text = "Номер тех. условия";
			this.txtNumDoc.BackColor = SystemColors.Window;
			this.txtNumDoc.DataBindings.Add(new Binding("Text", this.class10_0, "tTC_Doc.numDoc", true));
			this.txtNumDoc.Enabled = false;
			this.txtNumDoc.Location = new Point(15, 19);
			this.txtNumDoc.Name = "txtNumDoc";
			this.txtNumDoc.Size = new Size(144, 20);
			this.txtNumDoc.TabIndex = 1;
			this.txtNumDoc.TextAlign = HorizontalAlignment.Right;
			this.txtNumDoc.TextChanged += this.txtNumDoc_TextChanged;
			this.class10_0.DataSetName = "DataSetTechConnection";
			this.class10_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
			this.label_1.AutoSize = true;
			this.label_1.Location = new Point(166, 3);
			this.label_1.Name = "label2";
			this.label_1.Size = new Size(99, 13);
			this.label_1.TabIndex = 2;
			this.label_1.Text = "Дата тех. условия";
			this.dateTimePicker_0.DataBindings.Add(new Binding("Value", this.class10_0, "tTC_Doc.dateDoc", true));
			this.dateTimePicker_0.Location = new Point(169, 19);
			this.dateTimePicker_0.Name = "dateTimePickerDateDoc";
			this.dateTimePicker_0.Size = new Size(163, 20);
			this.dateTimePicker_0.TabIndex = 3;
			this.dateTimePicker_0.ValueChanged += this.dateTimePicker_0_ValueChanged;
			this.label_2.AutoSize = true;
			this.label_2.Location = new Point(6, 13);
			this.label_2.Name = "label3";
			this.label_2.Size = new Size(134, 13);
			this.label_2.TabIndex = 0;
			this.label_2.Text = "Номер и дата входящего";
			this.comboBox_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.comboBox_0.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			this.comboBox_0.AutoCompleteSource = AutoCompleteSource.ListItems;
			this.comboBox_0.DataBindings.Add(new Binding("SelectedValue", this.class10_0, "tTC_DocOut.idDoc", true));
			this.comboBox_0.FormattingEnabled = true;
			this.comboBox_0.Location = new Point(146, 10);
			this.comboBox_0.Name = "cmbNumDateIn";
			this.comboBox_0.Size = new Size(541, 21);
			this.comboBox_0.TabIndex = 1;
			this.comboBox_0.SelectedIndexChanged += this.comboBox_0_SelectedIndexChanged;
			this.comboBox_0.SelectedValueChanged += this.comboBox_0_SelectedValueChanged;
			this.comboBox_0.TextChanged += this.comboBox_0_TextChanged;
			this.textBox_2.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_2.BackColor = SystemColors.Window;
			this.textBox_2.Location = new Point(146, 60);
			this.textBox_2.Name = "txtAbnObj";
			this.textBox_2.ReadOnly = true;
			this.textBox_2.Size = new Size(541, 20);
			this.textBox_2.TabIndex = 5;
			this.label_3.AutoSize = true;
			this.label_3.Location = new Point(6, 63);
			this.label_3.Name = "labelAbnObj";
			this.label_3.Size = new Size(45, 13);
			this.label_3.TabIndex = 4;
			this.label_3.Text = "Объект";
			this.textBox_1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_1.BackColor = SystemColors.Window;
			this.textBox_1.Location = new Point(146, 36);
			this.textBox_1.Name = "txtAbn";
			this.textBox_1.ReadOnly = true;
			this.textBox_1.Size = new Size(541, 20);
			this.textBox_1.TabIndex = 3;
			this.label_4.AutoSize = true;
			this.label_4.Location = new Point(6, 39);
			this.label_4.Name = "labelAbn";
			this.label_4.Size = new Size(49, 13);
			this.label_4.TabIndex = 2;
			this.label_4.Text = "Абонент";
			this.label_5.AutoSize = true;
			this.label_5.Location = new Point(16, 429);
			this.label_5.Name = "label6";
			this.label_5.Size = new Size(70, 13);
			this.label_5.TabIndex = 20;
			this.label_5.Text = "Содержание";
			this.textBox_3.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_3.DataBindings.Add(new Binding("Text", this.class10_0, "tTC_Doc.body", true));
			this.textBox_3.Location = new Point(9, 445);
			this.textBox_3.Multiline = true;
			this.textBox_3.Name = "txtBody";
			this.textBox_3.Size = new Size(713, 58);
			this.textBox_3.TabIndex = 21;
			this.textBox_3.TextChanged += this.textBox_3_TextChanged;
			this.label_6.AutoSize = true;
			this.label_6.Location = new Point(12, 191);
			this.label_6.Name = "label7";
			this.label_6.Size = new Size(160, 13);
			this.label_6.TabIndex = 7;
			this.label_6.Text = "Категория электроснабжения";
			this.comboBox_1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.comboBox_1.DataBindings.Add(new Binding("SelectedValue", this.class10_0, "tTC_TU.Category", true));
			this.comboBox_1.FormattingEnabled = true;
			this.comboBox_1.Location = new Point(178, 188);
			this.comboBox_1.Name = "cmbCategory";
			this.comboBox_1.Size = new Size(538, 21);
			this.comboBox_1.TabIndex = 8;
			this.comboBox_1.SelectedIndexChanged += this.comboBox_1_SelectedIndexChanged;
			this.nullableNumericUpDown_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.nullableNumericUpDown_0.DataBindings.Add(new Binding("Value", this.class10_0, "tTC_TU.Power", true));
			this.nullableNumericUpDown_0.DecimalPlaces = 3;
			this.nullableNumericUpDown_0.Location = new Point(165, 242);
			NumericUpDown numericUpDown = this.nullableNumericUpDown_0;
			int[] array = new int[4];
			array[0] = 100000;
			numericUpDown.Maximum = new decimal(array);
			this.nullableNumericUpDown_0.Name = "numPower";
			this.nullableNumericUpDown_0.Size = new Size(551, 20);
			this.nullableNumericUpDown_0.TabIndex = 12;
			this.nullableNumericUpDown_0.TextAlign = HorizontalAlignment.Right;
			this.nullableNumericUpDown_0.Value = null;
			this.nullableNumericUpDown_0.ValueChanged += this.nullableNumericUpDown_0_ValueChanged;
			this.label_7.AutoSize = true;
			this.label_7.Location = new Point(13, 244);
			this.label_7.Name = "label8";
			this.label_7.Size = new Size(135, 13);
			this.label_7.TabIndex = 11;
			this.label_7.Text = "Сущесвующая мощность";
			this.label_8.AutoSize = true;
			this.label_8.Location = new Point(348, 3);
			this.label_8.Name = "labelPerformer";
			this.label_8.Size = new Size(74, 13);
			this.label_8.TabIndex = 4;
			this.label_8.Text = "Исполнитель";
			this.comboBox_2.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.comboBox_2.DataBindings.Add(new Binding("SelectedValue", this.class10_0, "tTC_TU.Performer", true));
			this.comboBox_2.FormattingEnabled = true;
			this.comboBox_2.Location = new Point(351, 18);
			this.comboBox_2.Name = "cmbPerformer";
			this.comboBox_2.Size = new Size(371, 21);
			this.comboBox_2.TabIndex = 5;
			this.comboBox_2.SelectedIndexChanged += this.comboBox_2_SelectedIndexChanged;
			this.label_9.AutoSize = true;
			this.label_9.Location = new Point(12, 218);
			this.label_9.Name = "label11";
			this.label_9.Size = new Size(116, 13);
			this.label_9.TabIndex = 9;
			this.label_9.Text = "Уровень напряжения";
			this.comboBox_3.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.comboBox_3.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			this.comboBox_3.AutoCompleteSource = AutoCompleteSource.ListItems;
			this.comboBox_3.DataBindings.Add(new Binding("SelectedValue", this.class10_0, "tTC_TU.VoltageLevel", true));
			this.comboBox_3.FormattingEnabled = true;
			this.comboBox_3.Location = new Point(165, 215);
			this.comboBox_3.Name = "cmbVoltageLevel";
			this.comboBox_3.Size = new Size(551, 21);
			this.comboBox_3.TabIndex = 10;
			this.comboBox_3.Text = "10 кВТ";
			this.comboBox_3.SelectedIndexChanged += this.comboBox_3_SelectedIndexChanged;
			this.nullableNumericUpDown_1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.nullableNumericUpDown_1.DataBindings.Add(new Binding("Value", this.class10_0, "tTC_TU.PowerAdd", true));
			this.nullableNumericUpDown_1.DecimalPlaces = 3;
			this.nullableNumericUpDown_1.Location = new Point(165, 268);
			NumericUpDown numericUpDown2 = this.nullableNumericUpDown_1;
			int[] array2 = new int[4];
			array2[0] = 100000;
			numericUpDown2.Maximum = new decimal(array2);
			this.nullableNumericUpDown_1.Name = "numPowerAdd";
			this.nullableNumericUpDown_1.Size = new Size(551, 20);
			this.nullableNumericUpDown_1.TabIndex = 14;
			this.nullableNumericUpDown_1.TextAlign = HorizontalAlignment.Right;
			this.nullableNumericUpDown_1.Value = null;
			this.nullableNumericUpDown_1.ValueChanged += this.nullableNumericUpDown_1_ValueChanged;
			this.label_10.AutoSize = true;
			this.label_10.Location = new Point(13, 270);
			this.label_10.Name = "label12";
			this.label_10.Size = new Size(148, 13);
			this.label_10.TabIndex = 13;
			this.label_10.Text = "Дополнительная мощность";
			this.nullableNumericUpDown_2.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.nullableNumericUpDown_2.DataBindings.Add(new Binding("Value", this.class10_0, "tTC_TU.PowerSum", true));
			this.nullableNumericUpDown_2.DecimalPlaces = 3;
			this.nullableNumericUpDown_2.Location = new Point(165, 294);
			NumericUpDown numericUpDown3 = this.nullableNumericUpDown_2;
			int[] array3 = new int[4];
			array3[0] = 100000;
			numericUpDown3.Maximum = new decimal(array3);
			this.nullableNumericUpDown_2.Name = "numPowerSum";
			this.nullableNumericUpDown_2.Size = new Size(551, 20);
			this.nullableNumericUpDown_2.TabIndex = 16;
			this.nullableNumericUpDown_2.TextAlign = HorizontalAlignment.Right;
			this.nullableNumericUpDown_2.Value = null;
			this.nullableNumericUpDown_2.ValueChanged += this.nullableNumericUpDown_2_ValueChanged;
			this.label_11.AutoSize = true;
			this.label_11.Location = new Point(13, 296);
			this.label_11.Name = "label13";
			this.label_11.Size = new Size(139, 13);
			this.label_11.TabIndex = 15;
			this.label_11.Text = "Максимальная мощность";
			this.label_12.AutoSize = true;
			this.label_12.Location = new Point(12, 324);
			this.label_12.Name = "label9";
			this.label_12.Size = new Size(118, 13);
			this.label_12.TabIndex = 17;
			this.label_12.Text = "Точки присоединения";
			this.dataGridView_0.AllowUserToAddRows = false;
			this.dataGridView_0.AllowUserToDeleteRows = false;
			this.dataGridView_0.AllowUserToResizeColumns = false;
			this.dataGridView_0.AllowUserToResizeRows = false;
			this.dataGridView_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle.BackColor = SystemColors.Control;
			dataGridViewCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
			this.dataGridView_0.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
			this.dataGridView_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView_0.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewTextBoxColumn_50,
				this.dataGridViewTextBoxColumn_51,
				this.dataGridViewTextBoxColumn_52,
				this.dataGridViewTextBoxColumn_53,
				this.dataGridViewTextBoxColumn_54,
				this.dataGridViewTextBoxColumn_55,
				this.dataGridViewTextBoxColumn_56,
				this.dataGridViewTextBoxColumn_57,
				this.dataGridViewTextBoxColumn_58,
				this.dataGridViewTextBoxColumn_59,
				this.dataGridViewTextBoxColumn_60,
				this.dataGridViewTextBoxColumn_61,
				this.dataGridViewTextBoxColumn_62,
				this.dataGridViewTextBoxColumn_63,
				this.dataGridViewTextBoxColumn_64,
				this.dataGridViewTextBoxColumn_65,
				this.dataGridViewTextBoxColumn_66,
				this.dataGridViewTextBoxColumn_67
			});
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
			this.dataGridView_0.DefaultCellStyle = dataGridViewCellStyle2;
			this.dataGridView_0.Location = new Point(9, 340);
			this.dataGridView_0.MultiSelect = false;
			this.dataGridView_0.Name = "dgvPointAttach";
			this.dataGridView_0.ReadOnly = true;
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = SystemColors.Control;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
			this.dataGridView_0.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.dataGridView_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView_0.Size = new Size(713, 86);
			this.dataGridView_0.TabIndex = 19;
			this.dataGridView_0.CellDoubleClick += this.dataGridView_0_CellDoubleClick;
			this.dataGridViewTextBoxColumn_50.HeaderText = "id";
			this.dataGridViewTextBoxColumn_50.Name = "idDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_50.ReadOnly = true;
			this.dataGridViewTextBoxColumn_50.Visible = false;
			this.dataGridViewTextBoxColumn_51.HeaderText = "num";
			this.dataGridViewTextBoxColumn_51.Name = "numDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_51.ReadOnly = true;
			this.dataGridViewTextBoxColumn_51.Visible = false;
			this.dataGridViewTextBoxColumn_52.HeaderText = "idSubPoint";
			this.dataGridViewTextBoxColumn_52.Name = "idSubPointColumn";
			this.dataGridViewTextBoxColumn_52.ReadOnly = true;
			this.dataGridViewTextBoxColumn_52.Visible = false;
			this.dataGridViewTextBoxColumn_53.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_53.HeaderText = "ТП/РП";
			this.dataGridViewTextBoxColumn_53.Name = "subPointDgvColumn";
			this.dataGridViewTextBoxColumn_53.ReadOnly = true;
			this.dataGridViewTextBoxColumn_53.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn_54.HeaderText = "idBusPoint";
			this.dataGridViewTextBoxColumn_54.Name = "idBusPointColumn";
			this.dataGridViewTextBoxColumn_54.ReadOnly = true;
			this.dataGridViewTextBoxColumn_54.Visible = false;
			this.dataGridViewTextBoxColumn_55.HeaderText = "Шина";
			this.dataGridViewTextBoxColumn_55.Name = "busPointDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_55.ReadOnly = true;
			this.dataGridViewTextBoxColumn_55.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn_55.Width = 50;
			this.dataGridViewTextBoxColumn_56.HeaderText = "idCellPoint";
			this.dataGridViewTextBoxColumn_56.Name = "idCellPointColumn";
			this.dataGridViewTextBoxColumn_56.ReadOnly = true;
			this.dataGridViewTextBoxColumn_56.Visible = false;
			this.dataGridViewTextBoxColumn_57.HeaderText = "Ячейка";
			this.dataGridViewTextBoxColumn_57.Name = "cellPointDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_57.ReadOnly = true;
			this.dataGridViewTextBoxColumn_57.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn_57.Width = 50;
			this.dataGridViewTextBoxColumn_58.HeaderText = "idSubCP";
			this.dataGridViewTextBoxColumn_58.Name = "idSubCPColumn";
			this.dataGridViewTextBoxColumn_58.ReadOnly = true;
			this.dataGridViewTextBoxColumn_58.Visible = false;
			this.dataGridViewTextBoxColumn_59.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_59.HeaderText = "ЦП";
			this.dataGridViewTextBoxColumn_59.Name = "subCPDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_59.ReadOnly = true;
			this.dataGridViewTextBoxColumn_59.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn_60.HeaderText = "idBusCP";
			this.dataGridViewTextBoxColumn_60.Name = "idBusCPColumn";
			this.dataGridViewTextBoxColumn_60.ReadOnly = true;
			this.dataGridViewTextBoxColumn_60.Visible = false;
			this.dataGridViewTextBoxColumn_61.HeaderText = "Шина";
			this.dataGridViewTextBoxColumn_61.Name = "busCPDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_61.ReadOnly = true;
			this.dataGridViewTextBoxColumn_61.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn_61.Width = 50;
			this.dataGridViewTextBoxColumn_62.HeaderText = "idCellCP";
			this.dataGridViewTextBoxColumn_62.Name = "idCellCPColumn";
			this.dataGridViewTextBoxColumn_62.ReadOnly = true;
			this.dataGridViewTextBoxColumn_62.Visible = false;
			this.dataGridViewTextBoxColumn_63.HeaderText = "Ячейка";
			this.dataGridViewTextBoxColumn_63.Name = "cellCPDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_63.ReadOnly = true;
			this.dataGridViewTextBoxColumn_63.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn_63.Width = 50;
			this.dataGridViewTextBoxColumn_64.HeaderText = "VoltageLevel";
			this.dataGridViewTextBoxColumn_64.Name = "voltageLevelDgvColumn";
			this.dataGridViewTextBoxColumn_64.ReadOnly = true;
			this.dataGridViewTextBoxColumn_64.Visible = false;
			this.dataGridViewTextBoxColumn_65.HeaderText = "Напр-ние";
			this.dataGridViewTextBoxColumn_65.Name = "voltageLevelNameDgvColumn";
			this.dataGridViewTextBoxColumn_65.ReadOnly = true;
			this.dataGridViewTextBoxColumn_66.HeaderText = "Мощ-сть";
			this.dataGridViewTextBoxColumn_66.Name = "powerSumDgvColumn";
			this.dataGridViewTextBoxColumn_66.ReadOnly = true;
			this.dataGridViewTextBoxColumn_67.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_67.FillWeight = 80f;
			this.dataGridViewTextBoxColumn_67.HeaderText = "Описание";
			this.dataGridViewTextBoxColumn_67.Name = "descriptionDgvColumn";
			this.dataGridViewTextBoxColumn_67.ReadOnly = true;
			this.toolStrip_0.Dock = DockStyle.None;
			this.toolStrip_0.GripStyle = ToolStripGripStyle.Hidden;
			this.toolStrip_0.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripButton_0,
				this.toolStripButton_1,
				this.toolStripButton_2,
				this.toolStripSeparator_0,
				this.toolStripButton_3,
				this.toolStripButton_4
			});
			this.toolStrip_0.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
			this.toolStrip_0.Location = new Point(152, 314);
			this.toolStrip_0.Name = "toolStripDGV";
			this.toolStrip_0.Size = new Size(124, 25);
			this.toolStrip_0.TabIndex = 18;
			this.toolStrip_0.Text = "toolStrip1";
			this.toolStripButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_0.Image = Resources.ElementAdd;
			this.toolStripButton_0.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_0.Name = "toolBtnAddLink";
			this.toolStripButton_0.Size = new Size(23, 22);
			this.toolStripButton_0.Text = "Добавить";
			this.toolStripButton_0.Click += this.toolStripButton_0_Click;
			this.toolStripButton_1.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_1.Image = Resources.ElementEdit;
			this.toolStripButton_1.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_1.Name = "toolBtnEditLink";
			this.toolStripButton_1.Size = new Size(23, 22);
			this.toolStripButton_1.Text = "Редактировать";
			this.toolStripButton_1.Click += this.toolStripButton_1_Click;
			this.toolStripButton_2.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_2.Image = Resources.ElementDel;
			this.toolStripButton_2.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_2.Name = "toolBtnDelLink";
			this.toolStripButton_2.Size = new Size(23, 22);
			this.toolStripButton_2.Text = "Удалить";
			this.toolStripButton_2.Click += this.toolStripButton_2_Click;
			this.toolStripSeparator_0.Name = "toolStripSeparator1";
			this.toolStripSeparator_0.Size = new Size(6, 25);
			this.toolStripButton_3.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_3.Image = Resources.Bitmap_0;
			this.toolStripButton_3.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_3.Name = "toolBtnUpLink";
			this.toolStripButton_3.Size = new Size(23, 22);
			this.toolStripButton_3.Text = "Вверх";
			this.toolStripButton_3.Click += this.toolStripButton_3_Click;
			this.toolStripButton_4.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_4.Image = Resources.Bitmap_4;
			this.toolStripButton_4.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_4.Name = "toolBtnDownLink";
			this.toolStripButton_4.Size = new Size(23, 22);
			this.toolStripButton_4.Text = "Вниз";
			this.toolStripButton_4.Click += this.toolStripButton_4_Click;
			this.button_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.button_0.Location = new Point(12, 541);
			this.button_0.Name = "buttonSave";
			this.button_0.Size = new Size(75, 23);
			this.button_0.TabIndex = 22;
			this.button_0.Text = "Сохранить";
			this.button_0.UseVisualStyleBackColor = true;
			this.button_0.Click += this.button_0_Click;
			this.button_1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.button_1.Location = new Point(647, 541);
			this.button_1.Name = "buttonClose";
			this.button_1.Size = new Size(75, 23);
			this.button_1.TabIndex = 23;
			this.button_1.Text = "Закрыть";
			this.button_1.UseVisualStyleBackColor = true;
			this.button_1.Click += this.button_1_Click;
			this.tabControl_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.tabControl_0.Controls.Add(this.tabPage_0);
			this.tabControl_0.Controls.Add(this.tabPage_4);
			this.tabControl_0.Controls.Add(this.tabPage_1);
			this.tabControl_0.Location = new Point(0, 0);
			this.tabControl_0.Name = "tabControl";
			this.tabControl_0.SelectedIndex = 0;
			this.tabControl_0.Size = new Size(736, 535);
			this.tabControl_0.TabIndex = 24;
			this.tabPage_0.Controls.Add(this.label_13);
			this.tabPage_0.Controls.Add(this.textBox_4);
			this.tabPage_0.Controls.Add(this.tabControl_1);
			this.tabPage_0.Controls.Add(this.label_0);
			this.tabPage_0.Controls.Add(this.txtNumDoc);
			this.tabPage_0.Controls.Add(this.label_1);
			this.tabPage_0.Controls.Add(this.toolStrip_0);
			this.tabPage_0.Controls.Add(this.dateTimePicker_0);
			this.tabPage_0.Controls.Add(this.dataGridView_0);
			this.tabPage_0.Controls.Add(this.label_12);
			this.tabPage_0.Controls.Add(this.label_5);
			this.tabPage_0.Controls.Add(this.nullableNumericUpDown_2);
			this.tabPage_0.Controls.Add(this.textBox_3);
			this.tabPage_0.Controls.Add(this.label_11);
			this.tabPage_0.Controls.Add(this.label_6);
			this.tabPage_0.Controls.Add(this.nullableNumericUpDown_1);
			this.tabPage_0.Controls.Add(this.comboBox_1);
			this.tabPage_0.Controls.Add(this.label_10);
			this.tabPage_0.Controls.Add(this.label_7);
			this.tabPage_0.Controls.Add(this.comboBox_3);
			this.tabPage_0.Controls.Add(this.nullableNumericUpDown_0);
			this.tabPage_0.Controls.Add(this.label_9);
			this.tabPage_0.Controls.Add(this.label_8);
			this.tabPage_0.Controls.Add(this.comboBox_2);
			this.tabPage_0.Location = new Point(4, 22);
			this.tabPage_0.Name = "tabPageGeneral";
			this.tabPage_0.Padding = new Padding(3);
			this.tabPage_0.Size = new Size(728, 509);
			this.tabPage_0.TabIndex = 0;
			this.tabPage_0.Text = "Общие";
			this.tabPage_0.UseVisualStyleBackColor = true;
			this.label_13.AutoSize = true;
			this.label_13.Location = new Point(13, 165);
			this.label_13.Name = "label10";
			this.label_13.Size = new Size(221, 13);
			this.label_13.TabIndex = 24;
			this.label_13.Text = "Наименование энергопринимающих уст-в";
			this.textBox_4.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_4.DataBindings.Add(new Binding("Text", this.class10_0, "tTC_TU.DeviceName", true));
			this.textBox_4.Location = new Point(240, 162);
			this.textBox_4.Name = "txtDeviceName";
			this.textBox_4.Size = new Size(476, 20);
			this.textBox_4.TabIndex = 23;
			this.textBox_4.TextChanged += this.textBox_4_TextChanged;
			this.tabControl_1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.tabControl_1.Controls.Add(this.tabPage_2);
			this.tabControl_1.Controls.Add(this.tabPage_3);
			this.tabControl_1.Location = new Point(15, 44);
			this.tabControl_1.Name = "tabControlRequest";
			this.tabControl_1.SelectedIndex = 0;
			this.tabControl_1.Size = new Size(701, 113);
			this.tabControl_1.TabIndex = 22;
			this.tabPage_2.Controls.Add(this.label_3);
			this.tabPage_2.Controls.Add(this.textBox_2);
			this.tabPage_2.Controls.Add(this.label_2);
			this.tabPage_2.Controls.Add(this.comboBox_0);
			this.tabPage_2.Controls.Add(this.textBox_1);
			this.tabPage_2.Controls.Add(this.label_4);
			this.tabPage_2.Location = new Point(4, 22);
			this.tabPage_2.Name = "tabPage1";
			this.tabPage_2.Padding = new Padding(3);
			this.tabPage_2.Size = new Size(693, 87);
			this.tabPage_2.TabIndex = 0;
			this.tabPage_2.Text = "Выбор заявки";
			this.tabPage_2.UseVisualStyleBackColor = true;
			this.tabPage_3.Controls.Add(this.dataGridViewExcelFilter_1);
			this.tabPage_3.Location = new Point(4, 22);
			this.tabPage_3.Name = "tabPagerequestHistory";
			this.tabPage_3.Padding = new Padding(3);
			this.tabPage_3.Size = new Size(693, 87);
			this.tabPage_3.TabIndex = 1;
			this.tabPage_3.Text = "История заявок";
			this.tabPage_3.UseVisualStyleBackColor = true;
			this.dataGridViewExcelFilter_1.AllowUserToAddRows = false;
			this.dataGridViewExcelFilter_1.AllowUserToDeleteRows = false;
			this.dataGridViewExcelFilter_1.AutoGenerateColumns = false;
			this.dataGridViewExcelFilter_1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewExcelFilter_1.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewTextBoxColumn_22,
				this.dataGridViewTextBoxColumn_23,
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
				this.dataGridViewTextBoxColumn_34,
				this.dataGridViewTextBoxColumn_35,
				this.dataGridViewTextBoxColumn_36,
				this.dataGridViewTextBoxColumn_37,
				this.dataGridViewTextBoxColumn_38,
				this.dataGridViewTextBoxColumn_39
			});
			this.dataGridViewExcelFilter_1.DataSource = this.bindingSource_1;
			this.dataGridViewExcelFilter_1.Dock = DockStyle.Fill;
			this.dataGridViewExcelFilter_1.Location = new Point(3, 3);
			this.dataGridViewExcelFilter_1.MultiSelect = false;
			this.dataGridViewExcelFilter_1.Name = "dgvRequestHistory";
			this.dataGridViewExcelFilter_1.ReadOnly = true;
			this.dataGridViewExcelFilter_1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewExcelFilter_1.Size = new Size(687, 81);
			this.dataGridViewExcelFilter_1.TabIndex = 4;
			this.dataGridViewExcelFilter_1.VirtualMode = true;
			this.dataGridViewExcelFilter_1.CellFormatting += this.dataGridViewExcelFilter_1_CellFormatting;
			this.dataGridViewExcelFilter_1.RowPostPaint += this.dataGridViewExcelFilter_1_RowPostPaint;
			this.dataGridViewTextBoxColumn_22.DataPropertyName = "numDateIn";
			dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_22.DefaultCellStyle = dataGridViewCellStyle4;
			this.dataGridViewTextBoxColumn_22.HeaderText = "№, дата вход.";
			this.dataGridViewTextBoxColumn_22.Name = "numDateInDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_22.ReadOnly = true;
			this.dataGridViewTextBoxColumn_22.Width = 80;
			this.dataGridViewTextBoxColumn_23.DataPropertyName = "numDoc";
			this.dataGridViewTextBoxColumn_23.HeaderText = "numDoc";
			this.dataGridViewTextBoxColumn_23.Name = "numDocDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_23.ReadOnly = true;
			this.dataGridViewTextBoxColumn_23.Visible = false;
			this.dataGridViewTextBoxColumn_24.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_24.HeaderText = "id";
			this.dataGridViewTextBoxColumn_24.Name = "idRequestHistoryDgvColumn";
			this.dataGridViewTextBoxColumn_24.ReadOnly = true;
			this.dataGridViewTextBoxColumn_24.Visible = false;
			this.dataGridViewTextBoxColumn_25.DataPropertyName = "dateDoc";
			this.dataGridViewTextBoxColumn_25.HeaderText = "Дата получения";
			this.dataGridViewTextBoxColumn_25.Name = "dateDocDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_25.ReadOnly = true;
			this.dataGridViewTextBoxColumn_25.Width = 80;
			this.dataGridViewTextBoxColumn_26.DataPropertyName = "TypeDoc";
			this.dataGridViewTextBoxColumn_26.HeaderText = "TypeDoc";
			this.dataGridViewTextBoxColumn_26.Name = "typeDocRequestHistoryDgvColumn";
			this.dataGridViewTextBoxColumn_26.ReadOnly = true;
			this.dataGridViewTextBoxColumn_26.Visible = false;
			this.dataGridViewTextBoxColumn_27.DataPropertyName = "numIn";
			this.dataGridViewTextBoxColumn_27.HeaderText = "numIn";
			this.dataGridViewTextBoxColumn_27.Name = "numInDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_27.ReadOnly = true;
			this.dataGridViewTextBoxColumn_27.Visible = false;
			this.dataGridViewTextBoxColumn_28.DataPropertyName = "dateIn";
			this.dataGridViewTextBoxColumn_28.HeaderText = "dateIn";
			this.dataGridViewTextBoxColumn_28.Name = "dateInDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_28.ReadOnly = true;
			this.dataGridViewTextBoxColumn_28.Visible = false;
			this.dataGridViewTextBoxColumn_29.DataPropertyName = "idAbn";
			this.dataGridViewTextBoxColumn_29.HeaderText = "idAbn";
			this.dataGridViewTextBoxColumn_29.Name = "idAbnDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_29.ReadOnly = true;
			this.dataGridViewTextBoxColumn_29.Visible = false;
			this.dataGridViewTextBoxColumn_30.DataPropertyName = "idAbnObj";
			this.dataGridViewTextBoxColumn_30.HeaderText = "idAbnObj";
			this.dataGridViewTextBoxColumn_30.Name = "idAbnObjDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_30.ReadOnly = true;
			this.dataGridViewTextBoxColumn_30.Visible = false;
			this.dataGridViewTextBoxColumn_31.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_31.DataPropertyName = "body";
			dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_31.DefaultCellStyle = dataGridViewCellStyle5;
			this.dataGridViewTextBoxColumn_31.HeaderText = "Тело письма";
			this.dataGridViewTextBoxColumn_31.Name = "bodyDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_31.ReadOnly = true;
			this.dataGridViewTextBoxColumn_32.DataPropertyName = "PowerCurrent";
			this.dataGridViewTextBoxColumn_32.HeaderText = "Текущая мощность";
			this.dataGridViewTextBoxColumn_32.Name = "powerCurrentDgvColumn";
			this.dataGridViewTextBoxColumn_32.ReadOnly = true;
			this.dataGridViewTextBoxColumn_32.Width = 70;
			this.dataGridViewTextBoxColumn_33.DataPropertyName = "PowerAdd";
			this.dataGridViewTextBoxColumn_33.HeaderText = "Доп мощность";
			this.dataGridViewTextBoxColumn_33.Name = "PowerAddDgvColumn";
			this.dataGridViewTextBoxColumn_33.ReadOnly = true;
			this.dataGridViewTextBoxColumn_33.Width = 70;
			this.dataGridViewTextBoxColumn_34.DataPropertyName = "Power";
			this.dataGridViewTextBoxColumn_34.HeaderText = "Суммарная мощность";
			this.dataGridViewTextBoxColumn_34.Name = "powerDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_34.ReadOnly = true;
			this.dataGridViewTextBoxColumn_34.Width = 70;
			this.dataGridViewTextBoxColumn_35.DataPropertyName = "VoltageName";
			this.dataGridViewTextBoxColumn_35.HeaderText = "Напряжение";
			this.dataGridViewTextBoxColumn_35.Name = "voltageNameDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_35.ReadOnly = true;
			this.dataGridViewTextBoxColumn_35.Width = 70;
			this.dataGridViewTextBoxColumn_36.DataPropertyName = "Comment";
			this.dataGridViewTextBoxColumn_36.HeaderText = "Комментарий";
			this.dataGridViewTextBoxColumn_36.Name = "commentDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_36.ReadOnly = true;
			this.dataGridViewTextBoxColumn_36.Width = 70;
			this.dataGridViewTextBoxColumn_37.DataPropertyName = "VoltageLevel";
			this.dataGridViewTextBoxColumn_37.HeaderText = "VoltageLevel";
			this.dataGridViewTextBoxColumn_37.Name = "voltageLevelDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_37.ReadOnly = true;
			this.dataGridViewTextBoxColumn_37.Visible = false;
			this.dataGridViewTextBoxColumn_38.DataPropertyName = "VoltageValue";
			this.dataGridViewTextBoxColumn_38.HeaderText = "VoltageValue";
			this.dataGridViewTextBoxColumn_38.Name = "voltageValueDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_38.ReadOnly = true;
			this.dataGridViewTextBoxColumn_38.Visible = false;
			this.dataGridViewTextBoxColumn_39.DataPropertyName = "IdParent";
			this.dataGridViewTextBoxColumn_39.HeaderText = "IdParent";
			this.dataGridViewTextBoxColumn_39.Name = "idParentDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_39.ReadOnly = true;
			this.dataGridViewTextBoxColumn_39.Visible = false;
			this.bindingSource_1.DataMember = "vTC_RequestHistory";
			this.bindingSource_1.DataSource = this.class10_0;
			this.tabPage_4.Controls.Add(this.splitContainer_0);
			this.tabPage_4.Location = new Point(4, 22);
			this.tabPage_4.Name = "tabPageTypeWork";
			this.tabPage_4.Size = new Size(728, 509);
			this.tabPage_4.TabIndex = 2;
			this.tabPage_4.Text = "Вид работ";
			this.tabPage_4.UseVisualStyleBackColor = true;
			this.splitContainer_0.Dock = DockStyle.Fill;
			this.splitContainer_0.Location = new Point(0, 0);
			this.splitContainer_0.Name = "splitContainerTypeWork";
			this.splitContainer_0.Orientation = Orientation.Horizontal;
			this.splitContainer_0.Panel1.Controls.Add(this.dataGridViewExcelFilter_2);
			this.splitContainer_0.Panel1.Controls.Add(this.toolStrip_2);
			this.splitContainer_0.Panel2.Controls.Add(this.dataGridViewExcelFilter_3);
			this.splitContainer_0.Panel2.Controls.Add(this.toolStrip_3);
			this.splitContainer_0.Size = new Size(728, 509);
			this.splitContainer_0.SplitterDistance = 256;
			this.splitContainer_0.TabIndex = 0;
			this.dataGridViewExcelFilter_2.AutoGenerateColumns = false;
			this.dataGridViewExcelFilter_2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewExcelFilter_2.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewTextBoxColumn_45,
				this.dataGridViewTextBoxColumn_46,
				this.dataGridViewTextBoxColumn_47,
				this.dataGridViewTextBoxColumn_48,
				this.dataGridViewTextBoxColumn_49
			});
			this.dataGridViewExcelFilter_2.DataSource = this.bindingSource_2;
			this.dataGridViewExcelFilter_2.Dock = DockStyle.Fill;
			this.dataGridViewExcelFilter_2.Location = new Point(0, 25);
			this.dataGridViewExcelFilter_2.Name = "dgvNetWork";
			this.dataGridViewExcelFilter_2.RowHeadersWidth = 21;
			this.dataGridViewExcelFilter_2.Size = new Size(728, 231);
			this.dataGridViewExcelFilter_2.TabIndex = 1;
			this.dataGridViewExcelFilter_2.CellValueChanged += this.dataGridViewExcelFilter_3_CellValueChanged;
			this.dataGridViewExcelFilter_2.DefaultValuesNeeded += this.dataGridViewExcelFilter_2_DefaultValuesNeeded;
			this.dataGridViewExcelFilter_2.RowPostPaint += this.dataGridViewExcelFilter_3_RowPostPaint;
			this.dataGridViewTextBoxColumn_45.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_45.DataPropertyName = "Work";
			dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_45.DefaultCellStyle = dataGridViewCellStyle6;
			this.dataGridViewTextBoxColumn_45.HeaderText = "Работы";
			this.dataGridViewTextBoxColumn_45.Name = "netWorkDgvColumn";
			this.dataGridViewTextBoxColumn_45.Resizable = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_45.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn_46.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_46.HeaderText = "id";
			this.dataGridViewTextBoxColumn_46.Name = "idNetWorkDgvColumn";
			this.dataGridViewTextBoxColumn_46.ReadOnly = true;
			this.dataGridViewTextBoxColumn_46.Visible = false;
			this.dataGridViewTextBoxColumn_47.DataPropertyName = "idTU";
			this.dataGridViewTextBoxColumn_47.HeaderText = "idTU";
			this.dataGridViewTextBoxColumn_47.Name = "idTUNetWorkDgvColumn";
			this.dataGridViewTextBoxColumn_47.Visible = false;
			this.dataGridViewTextBoxColumn_48.DataPropertyName = "num";
			this.dataGridViewTextBoxColumn_48.HeaderText = "num";
			this.dataGridViewTextBoxColumn_48.Name = "numNetWorkDgvColumn";
			this.dataGridViewTextBoxColumn_48.Visible = false;
			this.dataGridViewTextBoxColumn_49.DataPropertyName = "TypeWork";
			this.dataGridViewTextBoxColumn_49.HeaderText = "TypeWork";
			this.dataGridViewTextBoxColumn_49.Name = "typeWorkNetWorkDgvColumn";
			this.dataGridViewTextBoxColumn_49.Visible = false;
			this.bindingSource_2.DataMember = "tTC_TUTypeWork";
			this.bindingSource_2.DataSource = this.class10_0;
			this.bindingSource_2.Filter = "TypeWork = 1";
			this.bindingSource_2.Sort = "num";
			this.toolStrip_2.GripStyle = ToolStripGripStyle.Hidden;
			this.toolStrip_2.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripLabel_0,
				this.toolStripButton_10,
				this.toolStripButton_11,
				this.toolStripSeparator_5,
				this.toolStripComboBox_0,
				this.toolStripButton_14,
				this.toolStripButton_16
			});
			this.toolStrip_2.Location = new Point(0, 0);
			this.toolStrip_2.Name = "toolStripNetWork";
			this.toolStrip_2.Size = new Size(728, 25);
			this.toolStrip_2.TabIndex = 2;
			this.toolStrip_2.Text = "toolStrip1";
			this.toolStrip_2.Resize += this.toolStrip_2_Resize;
			this.toolStripLabel_0.Name = "toolStripLabel1";
			this.toolStripLabel_0.Size = new Size(168, 22);
			this.toolStripLabel_0.Text = "Работы сетевой организации";
			this.toolStripButton_10.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_10.Image = Resources.Bitmap_0;
			this.toolStripButton_10.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_10.Name = "toolBtnUpNetWork";
			this.toolStripButton_10.Size = new Size(23, 22);
			this.toolStripButton_10.Text = "toolStripButton1";
			this.toolStripButton_10.Click += this.toolStripButton_10_Click;
			this.toolStripButton_11.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_11.Image = Resources.Bitmap_4;
			this.toolStripButton_11.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_11.Name = "toolBtnDownNetWork";
			this.toolStripButton_11.Size = new Size(23, 22);
			this.toolStripButton_11.Text = "toolStripButton1";
			this.toolStripButton_11.Click += this.toolStripButton_11_Click;
			this.toolStripSeparator_5.Name = "toolStripSeparator6";
			this.toolStripSeparator_5.Size = new Size(6, 25);
			this.toolStripComboBox_0.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			this.toolStripComboBox_0.AutoCompleteSource = AutoCompleteSource.ListItems;
			this.toolStripComboBox_0.AutoSize = false;
			this.toolStripComboBox_0.Items.AddRange(new object[]
			{
				"Монтаж трансформаторной подстанции на границе участка. Тип ТП, количество и мощность силовых трансформаторов определить проектным решением;",
				componentResourceManager.GetString("cmbNetWork.Items"),
				"Прокладку кабельных линий 6-10 кВ от  РУ-10 кВ ТП-                 на проектируемой ТП. Способ прокладки, марку и сечение проводников определить проектным решением ",
				"Прокладку кабельных линий 0,4 кВ от ТП   . Способ прокладки, марку и сечение проводников определить проектным решением;",
				"Присоединение энергопринимающего устройства спортивной базы  к вновь построенной ЛЭП-0,4 кВ ТП  ;",
				"Комплекс организационно-технических мероприятий по обеспечению технологического присоединения;",
				"Замену силового трансформатора на силовой трансформатор мощностью    кВА в ТП-  ;"
			});
			this.toolStripComboBox_0.Name = "cmbNetWork";
			this.toolStripComboBox_0.Size = new Size(300, 23);
			this.toolStripButton_14.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_14.Image = Resources.ElementAdd;
			this.toolStripButton_14.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_14.Name = "toolBtnAddNetWork";
			this.toolStripButton_14.Size = new Size(23, 22);
			this.toolStripButton_14.Text = "Добавить";
			this.toolStripButton_14.Click += this.toolStripButton_14_Click;
			this.dataGridViewExcelFilter_3.AutoGenerateColumns = false;
			this.dataGridViewExcelFilter_3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewExcelFilter_3.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewTextBoxColumn_40,
				this.dataGridViewTextBoxColumn_41,
				this.dataGridViewTextBoxColumn_42,
				this.dataGridViewTextBoxColumn_43,
				this.dataGridViewTextBoxColumn_44
			});
			this.dataGridViewExcelFilter_3.DataSource = this.bindingSource_3;
			this.dataGridViewExcelFilter_3.Dock = DockStyle.Fill;
			this.dataGridViewExcelFilter_3.Location = new Point(0, 25);
			this.dataGridViewExcelFilter_3.Name = "dgvClientWork";
			this.dataGridViewExcelFilter_3.RowHeadersWidth = 21;
			this.dataGridViewExcelFilter_3.Size = new Size(728, 224);
			this.dataGridViewExcelFilter_3.TabIndex = 2;
			this.dataGridViewExcelFilter_3.CellValueChanged += this.dataGridViewExcelFilter_3_CellValueChanged;
			this.dataGridViewExcelFilter_3.DefaultValuesNeeded += this.dataGridViewExcelFilter_3_DefaultValuesNeeded;
			this.dataGridViewExcelFilter_3.RowPostPaint += this.dataGridViewExcelFilter_3_RowPostPaint;
			this.dataGridViewTextBoxColumn_40.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_40.DataPropertyName = "Work";
			dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_40.DefaultCellStyle = dataGridViewCellStyle7;
			this.dataGridViewTextBoxColumn_40.HeaderText = "Работы";
			this.dataGridViewTextBoxColumn_40.Name = "clientWorkDgvColumn";
			this.dataGridViewTextBoxColumn_40.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn_41.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_41.HeaderText = "id";
			this.dataGridViewTextBoxColumn_41.Name = "idClientWorkDgvColumn";
			this.dataGridViewTextBoxColumn_41.ReadOnly = true;
			this.dataGridViewTextBoxColumn_41.Visible = false;
			this.dataGridViewTextBoxColumn_42.DataPropertyName = "idTU";
			this.dataGridViewTextBoxColumn_42.HeaderText = "idTU";
			this.dataGridViewTextBoxColumn_42.Name = "idTUClientWorkDgvColumn";
			this.dataGridViewTextBoxColumn_42.Visible = false;
			this.dataGridViewTextBoxColumn_43.DataPropertyName = "num";
			this.dataGridViewTextBoxColumn_43.HeaderText = "num";
			this.dataGridViewTextBoxColumn_43.Name = "numClientWorkDgvColumn";
			this.dataGridViewTextBoxColumn_43.Visible = false;
			this.dataGridViewTextBoxColumn_44.DataPropertyName = "TypeWork";
			this.dataGridViewTextBoxColumn_44.HeaderText = "TypeWork";
			this.dataGridViewTextBoxColumn_44.Name = "typeWorkClientWorkDgvColumn";
			this.dataGridViewTextBoxColumn_44.Visible = false;
			this.bindingSource_3.DataMember = "tTC_TUTypeWork";
			this.bindingSource_3.DataSource = this.class10_0;
			this.bindingSource_3.Filter = "TypeWork = 2";
			this.bindingSource_3.Sort = "num";
			this.toolStrip_3.GripStyle = ToolStripGripStyle.Hidden;
			this.toolStrip_3.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripLabel_1,
				this.toolStripButton_12,
				this.toolStripButton_13,
				this.toolStripSeparator_6,
				this.toolStripComboBox_1,
				this.toolStripButton_15,
				this.toolStripButton_17
			});
			this.toolStrip_3.Location = new Point(0, 0);
			this.toolStrip_3.Name = "toolStripClientWork";
			this.toolStrip_3.Size = new Size(728, 25);
			this.toolStrip_3.TabIndex = 3;
			this.toolStrip_3.Text = "toolStrip1";
			this.toolStrip_3.Resize += this.toolStrip_3_Resize;
			this.toolStripLabel_1.Name = "toolStripLabel2";
			this.toolStripLabel_1.Size = new Size(105, 22);
			this.toolStripLabel_1.Text = "Работы заказчика";
			this.toolStripButton_12.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_12.Image = Resources.Bitmap_0;
			this.toolStripButton_12.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_12.Name = "toolBtnUpClientWork";
			this.toolStripButton_12.Size = new Size(23, 22);
			this.toolStripButton_12.Text = "toolStripButton1";
			this.toolStripButton_12.Click += this.toolStripButton_12_Click;
			this.toolStripButton_13.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_13.Image = Resources.Bitmap_4;
			this.toolStripButton_13.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_13.Name = "toolBtnDownClientWork";
			this.toolStripButton_13.Size = new Size(23, 22);
			this.toolStripButton_13.Text = "toolStripButton1";
			this.toolStripButton_13.Click += this.toolStripButton_13_Click;
			this.toolStripSeparator_6.Name = "toolStripSeparator7";
			this.toolStripSeparator_6.Size = new Size(6, 25);
			this.toolStripComboBox_1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			this.toolStripComboBox_1.AutoCompleteSource = AutoCompleteSource.ListItems;
			this.toolStripComboBox_1.AutoSize = false;
			this.toolStripComboBox_1.Items.AddRange(new object[]
			{
				"Строительство линии электропередач 0,4 кВ от   до ВРУ-0,4 кВ объекта; Тип ЛЭП, способ прокладки, марку и сечение проводников определить проектным решением;",
				"Монтаж ответвления от опоры ВЛ-0,4 кВ ТП-              к вводу объекта;                    ;",
				"Монтаж устройства, обеспечивающего контроль величины максимальной мощности;",
				componentResourceManager.GetString("cmbClientWork.Items"),
				componentResourceManager.GetString("cmbClientWork.Items1")
			});
			this.toolStripComboBox_1.Name = "cmbClientWork";
			this.toolStripComboBox_1.Size = new Size(300, 23);
			this.toolStripButton_15.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_15.Image = Resources.ElementAdd;
			this.toolStripButton_15.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_15.Name = "toolBtnAddClientWork";
			this.toolStripButton_15.Size = new Size(23, 22);
			this.toolStripButton_15.Text = "Добавить";
			this.toolStripButton_15.Click += this.toolStripButton_15_Click;
			this.tabPage_1.Controls.Add(this.dataGridViewExcelFilter_0);
			this.tabPage_1.Controls.Add(this.toolStrip_1);
			this.tabPage_1.Location = new Point(4, 22);
			this.tabPage_1.Name = "tabPageFile";
			this.tabPage_1.Padding = new Padding(3);
			this.tabPage_1.Size = new Size(728, 509);
			this.tabPage_1.TabIndex = 1;
			this.tabPage_1.Text = "Файлы";
			this.tabPage_1.UseVisualStyleBackColor = true;
			this.dataGridViewExcelFilter_0.AllowUserToAddRows = false;
			this.dataGridViewExcelFilter_0.AllowUserToDeleteRows = false;
			this.dataGridViewExcelFilter_0.AllowUserToResizeColumns = false;
			this.dataGridViewExcelFilter_0.AllowUserToResizeRows = false;
			this.dataGridViewExcelFilter_0.AutoGenerateColumns = false;
			this.dataGridViewExcelFilter_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewExcelFilter_0.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewImageColumnNotNull_0,
				this.dataGridViewFilterTextBoxColumn_0,
				this.dataGridViewTextBoxColumn_18,
				this.dataGridViewTextBoxColumn_19,
				this.dataGridViewTextBoxColumn_20,
				this.dataGridViewTextBoxColumn_21
			});
			this.dataGridViewExcelFilter_0.DataSource = this.bindingSource_0;
			this.dataGridViewExcelFilter_0.Dock = DockStyle.Fill;
			this.dataGridViewExcelFilter_0.EditMode = DataGridViewEditMode.EditProgrammatically;
			this.dataGridViewExcelFilter_0.Location = new Point(3, 28);
			this.dataGridViewExcelFilter_0.Name = "dgvFile";
			this.dataGridViewExcelFilter_0.ReadOnly = true;
			this.dataGridViewExcelFilter_0.RowHeadersVisible = false;
			this.dataGridViewExcelFilter_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewExcelFilter_0.Size = new Size(722, 478);
			this.dataGridViewExcelFilter_0.TabIndex = 6;
			this.dataGridViewExcelFilter_0.VirtualMode = true;
			this.dataGridViewExcelFilter_0.CellDoubleClick += this.dataGridViewExcelFilter_0_CellDoubleClick;
			this.dataGridViewExcelFilter_0.CellEndEdit += this.dataGridViewExcelFilter_0_CellEndEdit;
			this.dataGridViewExcelFilter_0.CellMouseClick += this.dataGridViewExcelFilter_0_CellMouseClick;
			this.dataGridViewExcelFilter_0.CellValidating += this.dataGridViewExcelFilter_0_CellValidating;
			this.dataGridViewExcelFilter_0.CellValueNeeded += this.dataGridViewExcelFilter_0_CellValueNeeded;
			dataGridViewCellStyle8.NullValue = null;
			this.dataGridViewImageColumnNotNull_0.DefaultCellStyle = dataGridViewCellStyle8;
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
			this.dataGridViewTextBoxColumn_18.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_18.HeaderText = "id";
			this.dataGridViewTextBoxColumn_18.Name = "id";
			this.dataGridViewTextBoxColumn_18.ReadOnly = true;
			this.dataGridViewTextBoxColumn_18.Visible = false;
			this.dataGridViewTextBoxColumn_19.DataPropertyName = "idDoc";
			this.dataGridViewTextBoxColumn_19.HeaderText = "idDoc";
			this.dataGridViewTextBoxColumn_19.Name = "idDoc";
			this.dataGridViewTextBoxColumn_19.ReadOnly = true;
			this.dataGridViewTextBoxColumn_19.Visible = false;
			this.dataGridViewTextBoxColumn_20.DataPropertyName = "dateChange";
			this.dataGridViewTextBoxColumn_20.HeaderText = "dateChange";
			this.dataGridViewTextBoxColumn_20.Name = "dateChangeDgvColumn";
			this.dataGridViewTextBoxColumn_20.ReadOnly = true;
			this.dataGridViewTextBoxColumn_20.Visible = false;
			this.dataGridViewTextBoxColumn_21.DataPropertyName = "idTemplate";
			this.dataGridViewTextBoxColumn_21.HeaderText = "idTemplate";
			this.dataGridViewTextBoxColumn_21.Name = "idTemplateDgvColumn";
			this.dataGridViewTextBoxColumn_21.ReadOnly = true;
			this.dataGridViewTextBoxColumn_21.Visible = false;
			this.bindingSource_0.DataMember = "tTC_DocFile";
			this.bindingSource_0.DataSource = this.class10_0;
			this.toolStrip_1.Items.AddRange(new ToolStripItem[]
			{
				this.toolBtnAddFile,
				this.toolStripButton_5,
				this.toolStripButton_6,
				this.toolStripButton_7,
				this.toolStripSeparator_2,
				this.toolStripButton_8,
				this.toolStripButton_9
			});
			this.toolStrip_1.Location = new Point(3, 3);
			this.toolStrip_1.Name = "toolStripFile";
			this.toolStrip_1.Size = new Size(722, 25);
			this.toolStrip_1.TabIndex = 0;
			this.toolStrip_1.Text = "toolStrip1";
			this.toolBtnAddFile.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolBtnAddFile.DropDownItems.AddRange(new ToolStripItem[]
			{
				this.toolStripMenuItem_0,
				this.toolStripSeparator_1
			});
			this.toolBtnAddFile.Image = Resources.ElementAdd;
			this.toolBtnAddFile.ImageTransparentColor = Color.Magenta;
			this.toolBtnAddFile.Name = "toolBtnAddFile";
			this.toolBtnAddFile.Size = new Size(29, 22);
			this.toolBtnAddFile.Text = "Добавить файл";
			this.toolStripMenuItem_0.Name = "toolItemAddExistFile";
			this.toolStripMenuItem_0.Size = new Size(190, 22);
			this.toolStripMenuItem_0.Text = "Сущесвующий файл";
			this.toolStripMenuItem_0.Click += this.toolStripMenuItem_2_Click;
			this.toolStripSeparator_1.Name = "toolStripSeparator2";
			this.toolStripSeparator_1.Size = new Size(187, 6);
			this.toolStripButton_5.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_5.Image = Resources.ElementEdit;
			this.toolStripButton_5.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_5.Name = "toolBtnEditFile";
			this.toolStripButton_5.Size = new Size(23, 22);
			this.toolStripButton_5.Text = "Редактировать файл";
			this.toolStripButton_5.Click += this.toolStripMenuItem_3_Click;
			this.toolStripButton_6.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_6.Image = Resources.ElementInformation;
			this.toolStripButton_6.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_6.Name = "toolBtnOpenFile";
			this.toolStripButton_6.Size = new Size(23, 22);
			this.toolStripButton_6.Text = "Открыть файл";
			this.toolStripButton_6.Click += this.toolStripMenuItem_4_Click;
			this.toolStripButton_7.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_7.Image = Resources.ElementDel;
			this.toolStripButton_7.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_7.Name = "toolBtnDelFile";
			this.toolStripButton_7.Size = new Size(23, 22);
			this.toolStripButton_7.Text = "Удалить файл";
			this.toolStripButton_7.Click += this.toolStripMenuItem_5_Click;
			this.toolStripSeparator_2.Name = "toolStripSeparator3";
			this.toolStripSeparator_2.Size = new Size(6, 25);
			this.toolStripButton_8.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_8.Image = Resources.rename;
			this.toolStripButton_8.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_8.Name = "toolBtnRenameFile";
			this.toolStripButton_8.Size = new Size(23, 22);
			this.toolStripButton_8.Text = "Переименовать";
			this.toolStripButton_8.Click += this.toolStripMenuItem_6_Click;
			this.toolStripButton_9.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_9.Image = Resources.save;
			this.toolStripButton_9.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_9.Name = "toolBtnSaveFile";
			this.toolStripButton_9.Size = new Size(23, 22);
			this.toolStripButton_9.Text = "Сохранить файл на диск";
			this.toolStripButton_9.Click += this.toolStripMenuItem_7_Click;
			this.dataGridViewTextBoxColumn_0.HeaderText = "id";
			this.dataGridViewTextBoxColumn_0.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_0.Visible = false;
			this.dataGridViewTextBoxColumn_1.HeaderText = "num";
			this.dataGridViewTextBoxColumn_1.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn_1.Visible = false;
			this.dataGridViewTextBoxColumn_2.HeaderText = "idSubPoint";
			this.dataGridViewTextBoxColumn_2.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn_2.Visible = false;
			this.dataGridViewTextBoxColumn_3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_3.HeaderText = "ТП/РП";
			this.dataGridViewTextBoxColumn_3.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn_3.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn_4.HeaderText = "idBusPoint";
			this.dataGridViewTextBoxColumn_4.Name = "dataGridViewTextBoxColumn5";
			this.dataGridViewTextBoxColumn_4.Visible = false;
			this.dataGridViewTextBoxColumn_5.HeaderText = "Шина";
			this.dataGridViewTextBoxColumn_5.Name = "dataGridViewTextBoxColumn6";
			this.dataGridViewTextBoxColumn_5.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn_5.Width = 50;
			this.dataGridViewTextBoxColumn_6.HeaderText = "idCellPoint";
			this.dataGridViewTextBoxColumn_6.Name = "dataGridViewTextBoxColumn7";
			this.dataGridViewTextBoxColumn_6.Visible = false;
			this.dataGridViewTextBoxColumn_7.HeaderText = "Ячейка";
			this.dataGridViewTextBoxColumn_7.Name = "dataGridViewTextBoxColumn8";
			this.dataGridViewTextBoxColumn_7.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn_7.Width = 50;
			this.dataGridViewTextBoxColumn_8.HeaderText = "idSubCP";
			this.dataGridViewTextBoxColumn_8.Name = "dataGridViewTextBoxColumn9";
			this.dataGridViewTextBoxColumn_8.Visible = false;
			this.dataGridViewTextBoxColumn_9.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_9.HeaderText = "ЦП";
			this.dataGridViewTextBoxColumn_9.Name = "dataGridViewTextBoxColumn10";
			this.dataGridViewTextBoxColumn_9.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn_10.HeaderText = "idBusCP";
			this.dataGridViewTextBoxColumn_10.Name = "dataGridViewTextBoxColumn11";
			this.dataGridViewTextBoxColumn_10.Visible = false;
			this.dataGridViewTextBoxColumn_11.HeaderText = "Шина";
			this.dataGridViewTextBoxColumn_11.Name = "dataGridViewTextBoxColumn12";
			this.dataGridViewTextBoxColumn_11.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn_11.Width = 50;
			this.dataGridViewTextBoxColumn_12.HeaderText = "idCellCP";
			this.dataGridViewTextBoxColumn_12.Name = "dataGridViewTextBoxColumn13";
			this.dataGridViewTextBoxColumn_12.Visible = false;
			this.dataGridViewTextBoxColumn_13.HeaderText = "Ячейка";
			this.dataGridViewTextBoxColumn_13.Name = "dataGridViewTextBoxColumn14";
			this.dataGridViewTextBoxColumn_13.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn_13.Width = 50;
			this.dataGridViewTextBoxColumn_14.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_14.HeaderText = "id";
			this.dataGridViewTextBoxColumn_14.Name = "dataGridViewTextBoxColumn15";
			this.dataGridViewTextBoxColumn_14.ReadOnly = true;
			this.dataGridViewTextBoxColumn_14.Visible = false;
			this.dataGridViewTextBoxColumn_15.DataPropertyName = "idDoc";
			this.dataGridViewTextBoxColumn_15.HeaderText = "idDoc";
			this.dataGridViewTextBoxColumn_15.Name = "dataGridViewTextBoxColumn16";
			this.dataGridViewTextBoxColumn_15.Visible = false;
			this.dataGridViewTextBoxColumn_16.DataPropertyName = "dateChange";
			this.dataGridViewTextBoxColumn_16.HeaderText = "dateChange";
			this.dataGridViewTextBoxColumn_16.Name = "dataGridViewTextBoxColumn17";
			this.dataGridViewTextBoxColumn_16.Visible = false;
			this.dataGridViewTextBoxColumn_17.DataPropertyName = "idTemplate";
			this.dataGridViewTextBoxColumn_17.HeaderText = "idTemplate";
			this.dataGridViewTextBoxColumn_17.Name = "dataGridViewTextBoxColumn18";
			this.dataGridViewTextBoxColumn_17.Visible = false;
			this.contextMenuStrip_0.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripMenuItem_1,
				this.toolStripMenuItem_3,
				this.toolStripMenuItem_4,
				this.toolStripMenuItem_5,
				this.toolStripSeparator_4,
				this.toolStripMenuItem_6,
				this.toolStripMenuItem_7
			});
			this.contextMenuStrip_0.Name = "contextMenuFile";
			this.contextMenuStrip_0.Size = new Size(177, 142);
			this.toolStripMenuItem_1.DropDownItems.AddRange(new ToolStripItem[]
			{
				this.toolStripMenuItem_2,
				this.toolStripSeparator_3
			});
			this.toolStripMenuItem_1.Image = Resources.ElementAdd;
			this.toolStripMenuItem_1.Name = "toolMenuItemAddFile";
			this.toolStripMenuItem_1.Size = new Size(176, 22);
			this.toolStripMenuItem_1.Text = "Добавить";
			this.toolStripMenuItem_2.Name = "toolMenuItemAddExistsFile";
			this.toolStripMenuItem_2.Size = new Size(195, 22);
			this.toolStripMenuItem_2.Text = "Существующий файл";
			this.toolStripMenuItem_2.Click += this.toolStripMenuItem_2_Click;
			this.toolStripSeparator_3.Name = "toolStripSeparator5";
			this.toolStripSeparator_3.Size = new Size(192, 6);
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
			this.toolStripSeparator_4.Name = "toolStripSeparator4";
			this.toolStripSeparator_4.Size = new Size(173, 6);
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
			this.toolStripButton_16.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_16.Image = Resources.report;
			this.toolStripButton_16.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_16.Name = "toolBtnReferenceTypeWork";
			this.toolStripButton_16.Size = new Size(23, 22);
			this.toolStripButton_16.Text = "Справочник типов работ";
			this.toolStripButton_16.Click += this.toolStripButton_17_Click;
			this.toolStripButton_17.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_17.Image = Resources.report;
			this.toolStripButton_17.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_17.Name = "toolBtnReferenceTypeWork2";
			this.toolStripButton_17.Size = new Size(23, 22);
			this.toolStripButton_17.Text = "Справочник типов работ";
			this.toolStripButton_17.Click += this.toolStripButton_17_Click;
			this.dataSet_0.DataSetName = "NewDataSet";
			this.dataSet_0.Tables.AddRange(new DataTable[]
			{
				this.dataTable_0,
				this.dataTable_1
			});
			this.dataTable_0.Columns.AddRange(new DataColumn[]
			{
				this.dataColumn_0
			});
			this.dataTable_0.TableName = "netWork";
			this.dataColumn_0.ColumnName = "Name";
			this.dataTable_1.Columns.AddRange(new DataColumn[]
			{
				this.dataColumn_1
			});
			this.dataTable_1.TableName = "clientWork";
			this.dataColumn_1.ColumnName = "Name";
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(734, 576);
			base.Controls.Add(this.tabControl_0);
			base.Controls.Add(this.button_1);
			base.Controls.Add(this.button_0);
			base.Name = "FormTUAddEdit";
			this.Text = "FormTUAddEdit";
			base.FormClosing += this.FormTUAddEdit_FormClosing;
			base.Load += this.FormTUAddEdit_Load;
			((ISupportInitialize)this.class10_0).EndInit();
			((ISupportInitialize)this.nullableNumericUpDown_0).EndInit();
			((ISupportInitialize)this.nullableNumericUpDown_1).EndInit();
			((ISupportInitialize)this.nullableNumericUpDown_2).EndInit();
			((ISupportInitialize)this.dataGridView_0).EndInit();
			this.toolStrip_0.ResumeLayout(false);
			this.toolStrip_0.PerformLayout();
			this.tabControl_0.ResumeLayout(false);
			this.tabPage_0.ResumeLayout(false);
			this.tabPage_0.PerformLayout();
			this.tabControl_1.ResumeLayout(false);
			this.tabPage_2.ResumeLayout(false);
			this.tabPage_2.PerformLayout();
			this.tabPage_3.ResumeLayout(false);
			((ISupportInitialize)this.dataGridViewExcelFilter_1).EndInit();
			((ISupportInitialize)this.bindingSource_1).EndInit();
			this.tabPage_4.ResumeLayout(false);
			this.splitContainer_0.Panel1.ResumeLayout(false);
			this.splitContainer_0.Panel1.PerformLayout();
			this.splitContainer_0.Panel2.ResumeLayout(false);
			this.splitContainer_0.Panel2.PerformLayout();
			this.splitContainer_0.ResumeLayout(false);
			((ISupportInitialize)this.dataGridViewExcelFilter_2).EndInit();
			((ISupportInitialize)this.bindingSource_2).EndInit();
			this.toolStrip_2.ResumeLayout(false);
			this.toolStrip_2.PerformLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_3).EndInit();
			((ISupportInitialize)this.bindingSource_3).EndInit();
			this.toolStrip_3.ResumeLayout(false);
			this.toolStrip_3.PerformLayout();
			this.tabPage_1.ResumeLayout(false);
			this.tabPage_1.PerformLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_0).EndInit();
			((ISupportInitialize)this.bindingSource_0).EndInit();
			this.toolStrip_1.ResumeLayout(false);
			this.toolStrip_1.PerformLayout();
			this.contextMenuStrip_0.ResumeLayout(false);
			((ISupportInitialize)this.dataSet_0).EndInit();
			((ISupportInitialize)this.dataTable_0).EndInit();
			((ISupportInitialize)this.dataTable_1).EndInit();
			base.ResumeLayout(false);
		}

		[CompilerGenerated]
		private void method_29()
		{
			this.bindingSource_0.ResetBindings(false);
		}

		internal static void c9jp2ZsHmrkbgO9xHsJ(Form form_0, bool bool_1)
		{
			form_0.Dispose(bool_1);
		}

		private int int_0;

		private int int_1;

		private int int_2;

		private string string_0;

		private bool isFile;

		private int int_3;

		private int int_4;

		private Dictionary<string, FileWatcherArgsAddl> dicWatcherFile;

		private string string_1;

		private Label label_0;

		private TextBox txtNumDoc;

		private Label label_1;

		private DateTimePicker dateTimePicker_0;

		private Label label_2;

		private ComboBox comboBox_0;

		private Label label_3;

		private TextBox textBox_1;

		private Label label_4;

		private TextBox textBox_2;

		private Label label_5;

		private TextBox textBox_3;

		private Label label_6;

		private ComboBox comboBox_1;

		private NullableNumericUpDown nullableNumericUpDown_0;

		private Label label_7;

		private Label label_8;

		private ComboBox comboBox_2;

		private Label label_9;

		private ComboBox comboBox_3;

		private NullableNumericUpDown nullableNumericUpDown_1;

		private Label label_10;

		private NullableNumericUpDown nullableNumericUpDown_2;

		private Label label_11;

		private Label label_12;

		private DataGridView dataGridView_0;

		private Class10 class10_0;

		private ToolStrip toolStrip_0;

		private ToolStripButton toolStripButton_0;

		private ToolStripButton toolStripButton_1;

		private ToolStripButton toolStripButton_2;

		private ToolStripSeparator toolStripSeparator_0;

		private ToolStripButton toolStripButton_3;

		private ToolStripButton toolStripButton_4;

		private Button button_0;

		private Button button_1;

		private TabControl tabControl_0;

		private TabPage tabPage_0;

		private TabPage tabPage_1;

		private ToolStrip toolStrip_1;

		private DataGridViewExcelFilter dataGridViewExcelFilter_0;

		private ToolStripDropDownButton toolBtnAddFile;

		private ToolStripMenuItem toolStripMenuItem_0;

		private ToolStripSeparator toolStripSeparator_1;

		private ToolStripButton toolStripButton_5;

		private ToolStripButton toolStripButton_6;

		private ToolStripButton toolStripButton_7;

		private BackgroundWorker backgroundWorker_0;

		private BackgroundWorker backgroundWorker_1;

		private BackgroundWorker backgroundWorker_2;

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

		private BindingSource bindingSource_0;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_14;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_15;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_16;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_17;

		private DataGridViewImageColumnNotNull dataGridViewImageColumnNotNull_0;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_0;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_18;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_19;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_20;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_21;

		private ToolStripSeparator toolStripSeparator_2;

		private ToolStripButton toolStripButton_8;

		private ToolStripButton toolStripButton_9;

		private ContextMenuStrip contextMenuStrip_0;

		private ToolStripMenuItem toolStripMenuItem_1;

		private ToolStripMenuItem toolStripMenuItem_2;

		private ToolStripSeparator toolStripSeparator_3;

		private ToolStripMenuItem toolStripMenuItem_3;

		private ToolStripMenuItem toolStripMenuItem_4;

		private ToolStripMenuItem toolStripMenuItem_5;

		private ToolStripSeparator toolStripSeparator_4;

		private ToolStripMenuItem toolStripMenuItem_6;

		private ToolStripMenuItem toolStripMenuItem_7;

		private TabControl tabControl_1;

		private TabPage tabPage_2;

		private TabPage tabPage_3;

		private BindingSource bindingSource_1;

		private DataGridViewExcelFilter dataGridViewExcelFilter_1;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_22;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_23;

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

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_35;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_36;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_37;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_38;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_39;

		private TabPage tabPage_4;

		private SplitContainer splitContainer_0;

		private DataGridViewExcelFilter dataGridViewExcelFilter_2;

		private DataGridViewExcelFilter dataGridViewExcelFilter_3;

		private BindingSource bindingSource_2;

		private BindingSource bindingSource_3;

		private ToolStrip toolStrip_2;

		private ToolStripLabel toolStripLabel_0;

		private ToolStripButton toolStripButton_10;

		private ToolStripButton toolStripButton_11;

		private ToolStrip toolStrip_3;

		private ToolStripLabel toolStripLabel_1;

		private ToolStripButton toolStripButton_12;

		private ToolStripButton toolStripButton_13;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_40;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_41;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_42;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_43;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_44;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_45;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_46;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_47;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_48;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_49;

		private ToolStripSeparator toolStripSeparator_5;

		private ToolStripComboBox toolStripComboBox_0;

		private ToolStripButton toolStripButton_14;

		private ToolStripSeparator toolStripSeparator_6;

		private ToolStripComboBox toolStripComboBox_1;

		private ToolStripButton toolStripButton_15;

		private Label label_13;

		private TextBox textBox_4;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_50;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_51;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_52;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_53;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_54;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_55;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_56;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_57;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_58;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_59;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_60;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_61;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_62;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_63;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_64;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_65;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_66;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_67;

		private ToolStripButton toolStripButton_16;

		private ToolStripButton toolStripButton_17;

		private DataSet dataSet_0;

		private DataTable dataTable_0;

		private DataColumn dataColumn_0;

		private DataTable dataTable_1;

		private DataColumn dataColumn_1;
	}
}
