using System;
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
using Constants;
using ControlsLbr;
using ControlsLbr.DataGridViewExcelFilter;
using Documents.Properties;
using FormLbr;
using FormLbr.Classes;

namespace Documents.Forms.TechnologicalConnection.Rebinding
{
	public partial class FormDocChangeSwitch : FormBase
	{
		internal int? method_0()
		{
			return this.nullable_0;
		}

		public FormDocChangeSwitch(int? idDoc = null, bool isReadOnly = false)
		{
			
			this.dictionary_0 = new Dictionary<string, FileWatcherArgsAddl>();
			this.string_0 = "";
			
			this.method_39();
			this.nullable_0 = idDoc;
			this.bool_0 = isReadOnly;
			if (isReadOnly)
			{
				this.button_0.Visible = false;
			}
		}

		private void FormDocChangeSwitch_Load(object sender, EventArgs e)
		{
			this.dateTimePicker_0.Value = DateTime.Now.Date;
			this.method_4();
			this.method_10();
			this.method_3();
			if (this.nullable_0 == null)
			{
				this.method_1();
				this.method_2();
			}
			else
			{
				base.SelectSqlData(this.class10_0, this.class10_0.tTC_Doc, true, "where id = " + this.nullable_0.ToString());
				if (this.class10_0.tTC_Doc.Rows.Count > 0)
				{
					base.SelectSqlData(this.class10_0.tTC_ChangeSwitch, true, "where id = " + this.nullable_0.ToString(), null, false, 0);
					if (this.class10_0.tTC_ChangeSwitch.Rows.Count == 0)
					{
						this.method_2();
					}
					else
					{
						this.method_5();
						if (this.class10_0.tTC_ChangeSwitch.Rows[0]["isApply"] != DBNull.Value && Convert.ToBoolean(this.class10_0.tTC_ChangeSwitch.Rows[0]["isApply"]))
						{
							this.groupBox_2.Enabled = false;
							this.groupBox_1.Enabled = false;
							this.checkBox_0.Enabled = false;
							this.nullableDateTimePicker_1.Enabled = false;
							this.comboBox_7.Enabled = false;
							this.checkBox_1.Enabled = false;
							this.dataGridViewExcelFilter_0.ReadOnly = true;
						}
						this.method_15();
					}
					this.method_32();
				}
				else
				{
					this.method_1();
					this.method_2();
				}
			}
			this.sRyUoJyHrD();
			this.nclUhXcedv = false;
		}

		private void FormDocChangeSwitch_Shown(object sender, EventArgs e)
		{
			this.method_14();
			this.nclUhXcedv = false;
		}

		private void FormDocChangeSwitch_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (base.DialogResult != DialogResult.OK)
			{
				if (this.bool_0 || !this.nclUhXcedv || MessageBox.Show("Сохранить внесенные изменения", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
				{
					base.DialogResult = DialogResult.Cancel;
					return;
				}
			}
			if (!this.method_16())
			{
				base.DialogResult = DialogResult.None;
				e.Cancel = true;
				return;
			}
			if (this.checkBox_0.Enabled && this.checkBox_0.Checked && MessageBox.Show("Привязка у объектов изменится!!! Провести документ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
			{
				base.DialogResult = DialogResult.Cancel;
				e.Cancel = true;
				return;
			}
			if (this.method_17())
			{
				base.DialogResult = DialogResult.OK;
				return;
			}
			base.DialogResult = DialogResult.None;
			e.Cancel = true;
		}

		private void method_1()
		{
			DataRow dataRow = this.class10_0.tTC_Doc.NewRow();
			dataRow["dateDoc"] = DateTime.Now.Date;
			dataRow["typeDoc"] = 1346;
			this.class10_0.tTC_Doc.Rows.Add(dataRow);
		}

		private void method_2()
		{
			DataRow dataRow = this.class10_0.tTC_ChangeSwitch.NewRow();
			dataRow["id"] = this.class10_0.tTC_Doc.Rows[0]["id"];
			dataRow["idSchmObjOld"] = -1;
			dataRow["idSchmObjNew"] = -1;
			dataRow["isApply"] = false;
			this.class10_0.tTC_ChangeSwitch.Rows.Add(dataRow);
		}

		private void method_3()
		{
			DataTable dataTable = new DataTable("vR_Worker");
			dataTable.Columns.Add("id", typeof(int));
			dataTable.Columns.Add("fio", typeof(string));
			base.SelectSqlData(dataTable, true, "where dateEnd is null order by fio", null, false, 0);
			this.comboBox_7.DisplayMember = "fio";
			this.comboBox_7.ValueMember = "id";
			this.comboBox_7.DataSource = dataTable;
			this.comboBox_7.SelectedIndex = -1;
		}

		private void method_4()
		{
			DataTable dataTable = new DataTable("tR_Classifier");
			dataTable.Columns.Add("id", typeof(int));
			dataTable.Columns.Add("name", typeof(string));
			base.SelectSqlData(dataTable, true, "where ParentKey = ';TechConnect;TypeDoc;Rebinding;TypeDocInRebinding;' and isGroup = 0 and deleted = 0 order by name", null, false, 0);
			this.comboBox_0.DisplayMember = "name";
			this.comboBox_0.ValueMember = "id";
			this.comboBox_0.DataSource = dataTable;
			this.comboBox_0.SelectedIndex = -1;
			base.SelectSqlData(this.dataTable_1, true, "where ParentKey = ';TechConnect;TypeDoc;Rebinding;TypeDocInRebinding;' and isGroup = 0 order by name", null, false, 0);
		}

		private void button_0_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void button_1_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void method_5()
		{
			if (this.class10_0.tTC_ChangeSwitch.Rows.Count == 0)
			{
				return;
			}
			if (this.class10_0.tTC_ChangeSwitch.Rows[0]["idSchmObjOld"] != DBNull.Value)
			{
				this.method_6(Convert.ToInt32(this.class10_0.tTC_ChangeSwitch.Rows[0]["idSchmObjOld"]), true);
			}
			if (this.class10_0.tTC_ChangeSwitch.Rows[0]["idSchmObjNew"] != DBNull.Value)
			{
				this.method_6(Convert.ToInt32(this.class10_0.tTC_ChangeSwitch.Rows[0]["idSchmObjNew"]), false);
			}
		}

		private void method_6(int int_0, bool bool_1)
		{
			DataTable dataTable = new DataTable("tSchm_ObjList");
			dataTable.Columns.Add("id", typeof(int));
			dataTable.Columns.Add("typeCodeId", typeof(int));
			base.SelectSqlData(dataTable, true, "where id = " + int_0, null, false, 0);
			if (dataTable.Rows.Count > 0)
			{
				if (this.method_7(Convert.ToInt32(dataTable.Rows[0]["TypeCodeId"])))
				{
					int num = Convert.ToInt32(dataTable.Rows[0]["id"]);
					string text = "";
					foreach (object obj in Enum.GetValues(typeof(SchmTypeBus)))
					{
						SchmTypeBus schmTypeBus = (SchmTypeBus)obj;
						text = text + Convert.ToInt32(schmTypeBus).ToString() + ",";
					}
					text = text.Remove(text.Length - 1);
					DataTable dataTable2 = new DataTable("vSchm_TreeCellLine");
					dataTable2.Columns.Add("ParentLink", typeof(int));
					base.SelectSqlData(dataTable2, true, string.Concat(new string[]
					{
						" left join vSchm_ObjList l on vSchm_TreeCellLine.ParentLink = l.id  where vSchm_TreeCellLine.id = ",
						num.ToString(),
						" and l.typeCodeId in (",
						text,
						")"
					}), null, false, 0);
					if (dataTable2.Rows.Count > 0)
					{
						int num2 = Convert.ToInt32(dataTable2.Rows[0]["ParentLink"]);
						DataTable dataTable3 = new DataTable("tSchm_ObjList");
						dataTable3.Columns.Add("idParent", typeof(int));
						base.SelectSqlData(dataTable3, true, "where id = " + num2.ToString(), null, false, 0);
						if (dataTable3.Rows.Count > 0 && dataTable3.Rows[0]["idParent"] != DBNull.Value)
						{
							int num3 = Convert.ToInt32(dataTable3.Rows[0]["idParent"]);
							if (bool_1)
							{
								this.comboBox_6.SelectedValue = num3;
								this.comboBox_5.SelectedValue = num2;
								this.comboBox_4.SelectedValue = num;
								return;
							}
							this.comboBox_3.SelectedValue = num3;
							this.comboBox_2.SelectedValue = num2;
							this.comboBox_1.SelectedValue = num;
							return;
						}
					}
				}
				else if (this.method_8(Convert.ToInt32(dataTable.Rows[0]["TypeCodeId"])))
				{
					int num2 = int_0;
					DataTable dataTable4 = new DataTable("tSchm_ObjList");
					dataTable4.Columns.Add("idParent", typeof(int));
					base.SelectSqlData(dataTable4, true, "where id = " + num2.ToString(), null, false, 0);
					if (dataTable4.Rows.Count > 0 && dataTable4.Rows[0]["idParent"] != DBNull.Value)
					{
						int num3 = Convert.ToInt32(dataTable4.Rows[0]["idParent"]);
						if (bool_1)
						{
							this.comboBox_6.SelectedValue = num3;
							this.comboBox_5.SelectedValue = num2;
							return;
						}
						this.comboBox_3.SelectedValue = num3;
						this.comboBox_2.SelectedValue = num2;
						return;
					}
				}
				else if (this.method_9(Convert.ToInt32(dataTable.Rows[0]["TypeCodeId"])))
				{
					if (bool_1)
					{
						this.comboBox_6.SelectedValue = int_0;
						return;
					}
					this.comboBox_3.SelectedValue = int_0;
				}
			}
		}

		private bool method_7(int int_0)
		{
			using (IEnumerator enumerator = Enum.GetValues(typeof(SchmTypeCell)).GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if ((SchmTypeBus)enumerator.Current == (SchmTypeBus)int_0)
					{
						return true;
					}
				}
			}
			return false;
		}

		private bool method_8(int int_0)
		{
			using (IEnumerator enumerator = Enum.GetValues(typeof(SchmTypeBus)).GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if ((SchmTypeBus)enumerator.Current == (SchmTypeBus)int_0)
					{
						return true;
					}
				}
			}
			return false;
		}

		private bool method_9(int int_0)
		{
			using (IEnumerator enumerator = Enum.GetValues(typeof(SchmTypeSubstation)).GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if ((SchmTypeBus)enumerator.Current == (SchmTypeBus)int_0)
					{
						return true;
					}
				}
			}
			return false;
		}

		private void method_10()
		{
			string text = "";
			foreach (object obj in Enum.GetValues(typeof(SchmTypeSubstation)))
			{
				SchmTypeSubstation schmTypeSubstation = (SchmTypeSubstation)obj;
				text = text + Convert.ToInt32(schmTypeSubstation).ToString() + ",";
			}
			text = text.Remove(text.Length - 1);
			DataTable dataTable = new DataTable("vSchm_ObjList");
			dataTable.Columns.Add("id", typeof(int));
			dataTable.Columns.Add("typeCodeSocr", typeof(string));
			dataTable.Columns.Add("Name", typeof(string));
			dataTable.Columns.Add("TypeName", typeof(string), "TypeCodeSocr + '-' + Name");
			BindingSource bindingSource = new BindingSource();
			bindingSource.DataSource = dataTable;
			this.comboBox_6.DataSource = bindingSource;
			this.comboBox_6.DisplayMember = "TypeName";
			this.comboBox_6.ValueMember = "id";
			BindingSource bindingSource2 = new BindingSource();
			bindingSource2.DataSource = dataTable;
			this.comboBox_3.DataSource = bindingSource2;
			this.comboBox_3.DisplayMember = "TypeName";
			this.comboBox_3.ValueMember = "id";
			base.SelectSqlData(dataTable, true, "where typecodeid in (" + text + ") and deleted = 0 order by typecodeSocr, name", null, false, 0);
		}

		private void method_11(ComboBox comboBox_8, int int_0)
		{
			string text = "";
			foreach (object obj in Enum.GetValues(typeof(SchmTypeBus)))
			{
				SchmTypeBus schmTypeBus = (SchmTypeBus)obj;
				text = text + Convert.ToInt32(schmTypeBus).ToString() + ",";
			}
			text = text.Remove(text.Length - 1);
			DataTable dataTable = new DataTable("vSchm_ObjList");
			dataTable.Columns.Add("id", typeof(int));
			dataTable.Columns.Add("typeCodeSocr", typeof(string));
			dataTable.Columns.Add("Name", typeof(string));
			dataTable.Columns.Add("TypeName", typeof(string), "TypeCodeSocr + '-' + Name");
			comboBox_8.DataSource = dataTable;
			comboBox_8.DisplayMember = "TypeName";
			comboBox_8.ValueMember = "id";
			base.SelectSqlData(dataTable, true, string.Concat(new string[]
			{
				"where idParent = ",
				int_0.ToString(),
				" and typecodeid in (",
				text,
				") and deleted = 0 order by typecodeSocr, name"
			}), null, false, 0);
			comboBox_8.SelectedIndex = -1;
		}

		private void method_12(ComboBox comboBox_8, int int_0)
		{
			DataTable dataTable = new DataTable("vSchm_TreeCellLine");
			dataTable.Columns.Add("id", typeof(int));
			dataTable.Columns.Add("FullName", typeof(string));
			comboBox_8.DataSource = dataTable;
			comboBox_8.DisplayMember = "FullName";
			comboBox_8.ValueMember = "id";
			base.SelectSqlData(dataTable, true, " where ParentLink = " + int_0.ToString() + " order by fullname", null, false, 0);
			comboBox_8.SelectedIndex = -1;
		}

		private void comboBox_6_SelectedIndexChanged(object sender, EventArgs e)
		{
			ComboBox comboBox = (ComboBox)sender;
			ComboBox comboBox2 = this.comboBox_5;
			if (comboBox == this.comboBox_3)
			{
				comboBox2 = this.comboBox_2;
			}
			if (comboBox.SelectedIndex >= 0 && comboBox.SelectedValue != null)
			{
				this.method_11(comboBox2, Convert.ToInt32(comboBox.SelectedValue));
			}
			else
			{
				comboBox2.DataSource = null;
			}
			if (comboBox == this.comboBox_6)
			{
				this.method_13();
			}
			this.nclUhXcedv = true;
		}

		private void comboBox_5_SelectedIndexChanged(object sender, EventArgs e)
		{
			ComboBox comboBox = (ComboBox)sender;
			ComboBox comboBox2 = this.comboBox_4;
			if (comboBox == this.comboBox_2)
			{
				comboBox2 = this.comboBox_1;
			}
			if (comboBox.SelectedIndex >= 0 && comboBox.SelectedValue != null)
			{
				this.method_12(comboBox2, Convert.ToInt32(comboBox.SelectedValue));
			}
			else
			{
				comboBox2.DataSource = null;
			}
			if (comboBox == this.comboBox_5)
			{
				this.method_13();
			}
			this.nclUhXcedv = true;
		}

		private void comboBox_4_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.method_13();
			this.nclUhXcedv = true;
		}

		private void method_13()
		{
			int? num = null;
			if (this.comboBox_4.SelectedValue != null)
			{
				num = new int?(Convert.ToInt32(this.comboBox_4.SelectedValue));
			}
			else if (this.comboBox_5.SelectedValue != null)
			{
				num = new int?(Convert.ToInt32(this.comboBox_5.SelectedValue));
			}
			else
			{
				if (this.comboBox_6.SelectedValue == null)
				{
					this.class10_0.vAbnObj.Clear();
					return;
				}
				num = new int?(Convert.ToInt32(this.comboBox_6.SelectedValue));
			}
			if (num != null)
			{
				base.SelectSqlData(this.class10_0.vAbnObj, true, string.Format(" inner join tl_schmAbn l on l.idAbnObj = vAbnObj.id  where l.idSchmObj = {0} and vAbnObj.deleted = 0 and vAbnObj.isActive = 1", num), null, false, 0);
				using (IEnumerator enumerator = ((IEnumerable)this.dataGridViewExcelFilter_0.Rows).GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						((DataGridViewRow)obj).Cells[this.dataGridViewCheckBoxColumn_0.Name].Value = this.checkBox_1.Checked;
					}
					return;
				}
			}
			this.class10_0.vAbnObj.Clear();
		}

		private void method_14()
		{
			if (this.class10_0.tTC_ChangeSwitch.Rows.Count != 0)
			{
				if (this.class10_0.tTC_ChangeSwitch.Rows[0]["listIdAbnObj"] != DBNull.Value)
				{
					List<string> list = new List<string>();
					XmlDocument xmlDocument = new XmlDocument();
					xmlDocument.LoadXml(this.class10_0.tTC_ChangeSwitch.Rows[0]["listIdAbnObj"].ToString());
					if (xmlDocument != null)
					{
						XmlNode xmlNode = xmlDocument.SelectSingleNode("List");
						if (xmlNode != null)
						{
							foreach (XmlNode xmlNode2 in xmlNode.SelectNodes("idAbnObj"))
							{
								if (!string.IsNullOrEmpty(xmlNode2.InnerText))
								{
									int num = Convert.ToInt32(xmlNode2.InnerText);
									bool flag = false;
									using (IEnumerator enumerator2 = ((IEnumerable)this.dataGridViewExcelFilter_0.Rows).GetEnumerator())
									{
										while (enumerator2.MoveNext())
										{
											object obj = enumerator2.Current;
											DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
											if (Convert.ToInt32(dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_1.Name].Value) == num)
											{
												dataGridViewRow.Cells[this.dataGridViewCheckBoxColumn_0.Name].Value = true;
												flag = true;
												break;
											}
										}
										goto IL_183;
									}
									IL_170:
									list.Add(num.ToString());
									continue;
									IL_183:
									if (!flag)
									{
										goto IL_170;
									}
								}
							}
							if (list.Count > 0)
							{
								string str = string.Join(",", list.ToArray());
								Class10.Class63 @class = new Class10.Class63();
								base.SelectSqlData(@class, true, "where id in (" + str + ")", null, false, 0);
								foreach (object obj2 in @class.Rows)
								{
									DataRow row = (DataRow)obj2;
									this.class10_0.vAbnObj.ImportRow(row);
									this.dataGridViewExcelFilter_0.Rows[this.dataGridViewExcelFilter_0.Rows.Count - 1].Cells[this.dataGridViewCheckBoxColumn_0.Name].Value = true;
								}
							}
							this.dataGridViewExcelFilter_0.Refresh();
						}
					}
					return;
				}
			}
		}

		private void method_15()
		{
			if (this.class10_0.tTC_ChangeSwitch.Rows.Count != 0)
			{
				if (this.class10_0.tTC_ChangeSwitch.Rows[0]["docsIn"] != DBNull.Value)
				{
					XmlDocument xmlDocument = new XmlDocument();
					xmlDocument.LoadXml(this.class10_0.tTC_ChangeSwitch.Rows[0]["docsIn"].ToString());
					if (xmlDocument != null)
					{
						XmlNode xmlNode = xmlDocument.SelectSingleNode("List");
						if (xmlNode != null)
						{
							foreach (object obj in xmlNode.SelectNodes("row"))
							{
								XmlNode xmlNode2 = (XmlNode)obj;
								DataRow dataRow = this.dataTable_0.NewRow();
								foreach (object obj2 in this.dataTable_0.Columns)
								{
									DataColumn dataColumn = (DataColumn)obj2;
									XmlAttribute xmlAttribute = xmlNode2.Attributes[dataColumn.ColumnName];
									if (xmlAttribute != null && !string.IsNullOrEmpty(xmlAttribute.Value))
									{
										if (dataColumn.DataType == typeof(DateTime))
										{
											dataRow[dataColumn.ColumnName] = Convert.ToDateTime(xmlAttribute.Value);
										}
										else if (dataColumn.DataType == typeof(int))
										{
											dataRow[dataColumn.ColumnName] = Convert.ToInt32(xmlAttribute.Value);
										}
										else
										{
											dataRow[dataColumn.ColumnName] = xmlAttribute.Value;
										}
									}
								}
								this.dataTable_0.Rows.Add(dataRow);
							}
						}
					}
					return;
				}
			}
		}

		private void checkBox_1_CheckedChanged(object sender, EventArgs e)
		{
			foreach (object obj in ((IEnumerable)this.dataGridViewExcelFilter_0.Rows))
			{
				((DataGridViewRow)obj).Cells[this.dataGridViewCheckBoxColumn_0.Name].Value = this.checkBox_1.Checked;
			}
			this.nclUhXcedv = true;
		}

		private bool method_16()
		{
			return true;
		}

		private bool method_17()
		{
			return this.method_18() && this.method_19() && this.method_33();
		}

		private bool method_18()
		{
			this.class10_0.tTC_Doc.Rows[0].EndEdit();
			if (this.nullable_0 == null)
			{
				this.nullable_0 = new int?(base.InsertSqlDataOneRow(this.class10_0, this.class10_0.tTC_Doc));
				if (this.nullable_0 == -1)
				{
					return false;
				}
			}
			else if (!base.UpdateSqlData(this.class10_0.tTC_Doc))
			{
				return false;
			}
			return true;
		}

		private bool method_19()
		{
			this.class10_0.tTC_ChangeSwitch.Rows[0]["id"] = this.nullable_0;
			int? num = this.method_20();
			if (num != null)
			{
				this.class10_0.tTC_ChangeSwitch.Rows[0]["idSchmObjOld"] = num;
			}
			else
			{
				this.class10_0.tTC_ChangeSwitch.Rows[0]["idSchmObjOld"] = DBNull.Value;
			}
			int? num2 = this.method_21();
			if (num2 != null)
			{
				this.class10_0.tTC_ChangeSwitch.Rows[0]["idSchmObjNew"] = num2;
			}
			else
			{
				this.class10_0.tTC_ChangeSwitch.Rows[0]["idSchmObjNew"] = DBNull.Value;
			}
			this.class10_0.tTC_ChangeSwitch.Rows[0]["listIdAbnObj"] = this.method_23().InnerXml;
			if (this.nullableDateTimePicker_1.Value == null)
			{
				this.class10_0.tTC_ChangeSwitch.Rows[0]["dateApply"] = DBNull.Value;
			}
			else
			{
				this.class10_0.tTC_ChangeSwitch.Rows[0]["dateApply"] = this.nullableDateTimePicker_1.Value;
			}
			if (this.comboBox_7.SelectedIndex < 0)
			{
				this.class10_0.tTC_ChangeSwitch.Rows[0]["idWorkerApply"] = DBNull.Value;
			}
			else
			{
				this.class10_0.tTC_ChangeSwitch.Rows[0]["idWorkerApply"] = this.comboBox_7.SelectedValue;
			}
			this.class10_0.tTC_ChangeSwitch.Rows[0]["docsIn"] = this.method_24().InnerXml;
			this.class10_0.tTC_ChangeSwitch.Rows[0].EndEdit();
			return base.InsertSqlData(this.class10_0.tTC_ChangeSwitch) && base.UpdateSqlData(this.class10_0.tTC_ChangeSwitch) && this.method_22(num, num2);
		}

		private int? method_20()
		{
			if (this.comboBox_4.SelectedIndex >= 0)
			{
				return new int?(Convert.ToInt32(this.comboBox_4.SelectedValue));
			}
			if (this.comboBox_5.SelectedIndex >= 0)
			{
				return new int?(Convert.ToInt32(this.comboBox_5.SelectedValue));
			}
			if (this.comboBox_6.SelectedIndex >= 0)
			{
				return new int?(Convert.ToInt32(this.comboBox_6.SelectedValue));
			}
			return null;
		}

		private int? method_21()
		{
			if (this.comboBox_1.SelectedIndex >= 0)
			{
				return new int?(Convert.ToInt32(this.comboBox_1.SelectedValue));
			}
			if (this.comboBox_2.SelectedIndex >= 0)
			{
				return new int?(Convert.ToInt32(this.comboBox_2.SelectedValue));
			}
			if (this.comboBox_3.SelectedIndex >= 0)
			{
				return new int?(Convert.ToInt32(this.comboBox_3.SelectedValue));
			}
			return null;
		}

		private bool method_22(int? nullable_1, int? nullable_2)
		{
			if (nullable_1 != null && nullable_2 != null && this.checkBox_0.Checked && this.checkBox_0.Enabled)
			{
				List<string> list = new List<string>();
				foreach (object obj in ((IEnumerable)this.dataGridViewExcelFilter_0.Rows))
				{
					DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
					if (Convert.ToBoolean(dataGridViewRow.Cells[this.dataGridViewCheckBoxColumn_0.Name].Value))
					{
						list.Add(dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_1.Name].Value.ToString());
					}
				}
				if (list.Count == 0)
				{
					return true;
				}
				Class10.Class52 @class = new Class10.Class52();
				base.SelectSqlData(@class, true, string.Format("where idSchmObj = {0} and idAbnObj in ({1}) and typeDoc = {2} and idDoc is not null", nullable_1, string.Join(",", list.ToArray()), 497), null, false, 0);
				bool result;
				using (SqlConnection sqlConnection = new SqlConnection(this.SqlSettings.GetConnectionString()))
				{
					try
					{
						sqlConnection.Open();
						using (SqlCommand sqlCommand = new SqlCommand(string.Format("update tL_SchmAbn set idSchmObj = {0}, idDoc = {1}, TypeDoc = {2}  where idSchmObj = {3} and idAbnObj in ({4})", new object[]
						{
							nullable_2,
							this.nullable_0,
							1346,
							nullable_1,
							string.Join(",", list.ToArray())
						}), sqlConnection))
						{
							sqlCommand.ExecuteNonQuery();
						}
						if (@class.Rows.Count > 0)
						{
							string text = "";
							foreach (object obj2 in @class.Rows)
							{
								DataRow dataRow = (DataRow)obj2;
								if (string.IsNullOrEmpty(text))
								{
									text = dataRow["idDoc"].ToString();
								}
								else
								{
									text = text + "," + dataRow["idDoc"].ToString();
								}
							}
							using (SqlCommand sqlCommand2 = new SqlCommand(string.Format("update tAbnobjDoc_AKtRBP set idActRebinding = {0} where idList in ({1})", this.nullable_0, text), sqlConnection))
							{
								sqlCommand2.ExecuteNonQuery();
							}
						}
						return true;
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, ex.Source);
						result = false;
					}
					finally
					{
						sqlConnection.Close();
					}
				}
				return result;
			}
			return true;
		}

		private XmlDocument method_23()
		{
			XmlDocument xmlDocument = new XmlDocument();
			XmlNode xmlNode = xmlDocument.CreateElement("List");
			xmlDocument.AppendChild(xmlNode);
			foreach (object obj in ((IEnumerable)this.dataGridViewExcelFilter_0.Rows))
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
				if (Convert.ToBoolean(dataGridViewRow.Cells[this.dataGridViewCheckBoxColumn_0.Name].Value))
				{
					XmlNode xmlNode2 = xmlDocument.CreateElement("idAbnObj");
					xmlNode2.InnerText = dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_1.Name].Value.ToString();
					xmlNode.AppendChild(xmlNode2);
				}
			}
			return xmlDocument;
		}

		private XmlDocument method_24()
		{
			XmlDocument xmlDocument = new XmlDocument();
			XmlNode xmlNode = xmlDocument.CreateElement("List");
			xmlDocument.AppendChild(xmlNode);
			foreach (object obj in this.dataTable_0.Rows)
			{
				DataRow dataRow = (DataRow)obj;
				XmlNode xmlNode2 = xmlDocument.CreateElement("row");
				foreach (object obj2 in this.dataTable_0.Columns)
				{
					DataColumn dataColumn = (DataColumn)obj2;
					XmlAttribute xmlAttribute = xmlDocument.CreateAttribute(dataColumn.ColumnName);
					if (dataRow[dataColumn.ColumnName] != DBNull.Value)
					{
						xmlAttribute.Value = dataRow[dataColumn.ColumnName].ToString();
					}
					xmlNode2.Attributes.Append(xmlAttribute);
				}
				xmlNode.AppendChild(xmlNode2);
			}
			return xmlDocument;
		}

		private void dataGridViewExcelFilter_0_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			this.nclUhXcedv = true;
		}

		private void sRyUoJyHrD()
		{
		}

		private string method_25(string string_1, int? nullable_1 = null, byte[] byte_0 = null)
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
					FileWatcherArgsAddl value = new FileWatcherArgsAddl(nullable_1, fileName, null, FileOpenState.None);
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
					if (nullable_1 != null)
					{
						@class.idTemplate = nullable_1.Value;
					}
					this.class10_0.tTC_DocFile.method_0(@class);
					return fileName;
				}
			}
			goto IL_57;
		}

		private void toolStripMenuItem_0_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Multiselect = true;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				foreach (string string_ in openFileDialog.FileNames)
				{
					if (!string.IsNullOrEmpty(this.method_25(string_, null, null)))
					{
						this.nclUhXcedv = true;
					}
				}
			}
		}

		private void method_26(object sender, EventArgs e)
		{
			int num = (int)((ToolStripMenuItem)sender).Tag;
			string text;
			byte[] array;
			this.GetTepmlate(num, out text, out array);
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
			string text2 = this.method_31();
			string newFileNameIsExists = FileBinary.GetNewFileNameIsExists(text2, text, false);
			string text3 = this.method_25(text, new int?(num), array);
			if (!string.IsNullOrEmpty(text3))
			{
				this.nclUhXcedv = true;
				FileBinary fileBinary = new FileBinary(array, newFileNameIsExists, DateTime.Now);
				fileBinary.SaveToDisk(text2);
				extension = new System.IO.FileInfo(text).Extension;
				Process.Start(text2 + "\\" + fileBinary.Name);
				if (this.dictionary_0.ContainsKey(text3))
				{
					FileWatcher fileWatcher = new FileWatcher(text2, fileBinary.Name);
					fileWatcher.AnyChanged += this.method_28;
					fileWatcher.Start();
					this.dictionary_0[text3].TempName = newFileNameIsExists;
					this.dictionary_0[text3].Watcher = fileWatcher;
					this.dictionary_0[text3].OpenState = FileOpenState.Editing;
					return;
				}
				MessageBox.Show("Что то пошло не так");
			}
		}

		private void toolStripButton_0_Click(object sender, EventArgs e)
		{
			this.method_27(true);
		}

		private void toolStripButton_1_Click(object sender, EventArgs e)
		{
			this.method_27(false);
		}

		private void toolStripButton_2_Click(object sender, EventArgs e)
		{
			if (this.bindingSource_1.Current != null && MessageBox.Show("Вы действительно хотите удалить выбранный файл?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				Class10.Class88 @class = (Class10.Class88)((DataRowView)this.bindingSource_1.Current).Row;
				string fileName = @class.FileName;
				if (this.dictionary_0.ContainsKey(fileName))
				{
					if (this.dictionary_0[fileName].Watcher != null)
					{
						this.dictionary_0[fileName].Watcher.AnyChanged -= this.method_28;
						this.dictionary_0[fileName].Watcher.Stop();
					}
					this.dictionary_0.Remove(fileName);
				}
				@class.Delete();
				this.nclUhXcedv = true;
			}
		}

		private void toolStripButton_3_Click(object sender, EventArgs e)
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

		private void toolStripButton_4_Click(object sender, EventArgs e)
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

		private void method_27(bool bool_1 = false)
		{
			if (this.bindingSource_1.Current != null)
			{
				Class10.Class88 @class = (Class10.Class88)((DataRowView)this.bindingSource_1.Current).Row;
				string fileName = @class.FileName;
				string text = this.method_31();
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
							fileWatcher.AnyChanged += this.method_28;
							fileWatcher.Start();
							this.dictionary_0[fileName].Watcher = fileWatcher;
						}
						else
						{
							this.dictionary_0[fileName].Watcher.AnyChanged -= this.method_28;
							this.dictionary_0[fileName].Watcher.Stop();
							FileWatcher fileWatcher2 = new FileWatcher(text, newFileNameIsExists);
							fileWatcher2.AnyChanged += this.method_28;
							fileWatcher2.Start();
							this.dictionary_0[fileName].Watcher = fileWatcher2;
						}
						this.dictionary_0[fileName].TempName = newFileNameIsExists;
						this.dictionary_0[fileName].OpenState = FileOpenState.Editing;
						return;
					}
					FileWatcher fileWatcher3 = new FileWatcher(text, newFileNameIsExists);
					fileWatcher3.AnyChanged += this.method_28;
					fileWatcher3.Start();
					FileWatcherArgsAddl value = new FileWatcherArgsAddl(idTemplate, fileName, newFileNameIsExists, fileWatcher3, FileOpenState.Editing);
					this.dictionary_0.Add(fileName, value);
				}
			}
		}

		private void method_28(object sender, FileSystemEventArgs e)
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
					if (this.nullable_0 != null)
					{
						@class.idDoc = this.nullable_0.Value;
					}
					else
					{
						@class.idDoc = -1;
					}
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
					this.nclUhXcedv = true;
				}
			}
			this.method_30();
		}

		private bool method_29(string string_1)
		{
			return (from row in this.class10_0.tTC_DocFile
			where row.FileName == string_1
			select row).Count<Class10.Class88>() > 0;
		}

		private void method_30()
		{
			if (base.InvokeRequired)
			{
				base.Invoke(new Action(this.method_40));
				return;
			}
			this.bindingSource_1.ResetBindings(false);
		}

		private string method_31()
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

		public void GetTepmlate(int idTemplate, out string fileName, out byte[] fileData)
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

		private void method_32()
		{
			try
			{
				using (SqlConnection sqlConnection = new SqlConnection(this.SqlSettings.GetConnectionString()))
				{
					sqlConnection.Open();
					SqlDataReader sqlDataReader = new SqlCommand("SELECT id, idDoc, FileName, dateChange, idTemplate FROM tTC_DocFile WHERE idDoc = " + this.nullable_0.ToString(), sqlConnection).ExecuteReader();
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

		private bool method_33()
		{
			foreach (DataRow dataRow in this.class10_0.tTC_DocFile)
			{
				if (dataRow.RowState != DataRowState.Deleted && dataRow.RowState != DataRowState.Detached && Convert.ToInt32(dataRow["idDoc"]) != this.nullable_0)
				{
					dataRow["idDoc"] = this.nullable_0;
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

		private void method_34(object sender, DataGridViewCellValueEventArgs e)
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

		private void method_35(object sender, DataGridViewCellEventArgs e)
		{
			this.toolStripButton_1_Click(sender, e);
		}

		private void method_36(object sender, DataGridViewCellEventArgs e)
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
				this.nclUhXcedv = true;
			}
			this.string_0 = null;
		}

		private void method_37(object sender, DataGridViewCellValidatingEventArgs e)
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

		private void method_38(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Button == MouseButtons.Right)
			{
				this.dataGridViewExcelFilter_1.ClearSelection();
				this.dataGridViewExcelFilter_1.Rows[e.RowIndex].Selected = true;
				this.dataGridViewExcelFilter_1.CurrentCell = this.dataGridViewExcelFilter_1[e.ColumnIndex, e.RowIndex];
				this.dataGridViewExcelFilter_1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
			}
		}

		private void dateTimePicker_0_ValueChanged(object sender, EventArgs e)
		{
			this.nclUhXcedv = true;
		}

		private void comboBox_0_SelectedValueChanged(object sender, EventArgs e)
		{
			this.nclUhXcedv = true;
		}

		private void textBox_1_TextChanged(object sender, EventArgs e)
		{
			this.nclUhXcedv = true;
		}

		private void checkBox_0_CheckedChanged(object sender, EventArgs e)
		{
			if (this.checkBox_0.Checked)
			{
				this.nullableDateTimePicker_1.Value = DateTime.Now.Date;
				DataTable dataTable = new DataTable("tUser");
				dataTable.Columns.Add("idWorker", typeof(int));
				base.SelectSqlData(dataTable, true, "where [Login] = SYSTEM_USER", null, false, 0);
				if (dataTable.Rows.Count > 0 && dataTable.Rows[0]["idWorker"] != DBNull.Value)
				{
					this.comboBox_7.SelectedValue = dataTable.Rows[0]["idWorker"];
				}
			}
			else if (this.class10_0.tTC_ChangeSwitch.Rows.Count > 0)
			{
				this.nullableDateTimePicker_1.Value = null;
				this.comboBox_7.SelectedIndex = -1;
			}
			this.nclUhXcedv = true;
		}

		private void toolStripButton_5_Click(object sender, EventArgs e)
		{
			DataRow dataRow = this.dataTable_0.NewRow();
			if (new Form18(dataRow)
			{
				SqlSettings = this.SqlSettings
			}.ShowDialog() == DialogResult.OK)
			{
				this.dataTable_0.Rows.Add(dataRow);
				this.nclUhXcedv = true;
			}
		}

		private void toolStripButton_6_Click(object sender, EventArgs e)
		{
			if (this.bindingSource_2.Current != null && new Form18(((DataRowView)this.bindingSource_2.Current).Row)
			{
				SqlSettings = this.SqlSettings
			}.ShowDialog() == DialogResult.OK)
			{
				this.nclUhXcedv = true;
			}
		}

		private void IubRlywhYQ_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_2.CurrentRow != null && MessageBox.Show("Вы действительно хотите удалить текущую строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				this.dataGridViewExcelFilter_2.Rows.Remove(this.dataGridViewExcelFilter_2.CurrentRow);
				this.nclUhXcedv = true;
			}
		}

		private void dataGridViewExcelFilter_2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				this.toolStripButton_6_Click(sender, e);
			}
		}

		private void method_39()
		{
			this.icontainer_0 = new Container();
			DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
			this.tabControl_0 = new TabControl();
			this.tabPage_0 = new TabPage();
			this.comboBox_7 = new ComboBox();
			this.class10_0 = new Class10();
			this.label_12 = new Label();
			this.nullableDateTimePicker_1 = new NullableDateTimePicker();
			this.label_13 = new Label();
			this.checkBox_1 = new CheckBox();
			this.dataGridViewExcelFilter_0 = new DataGridViewExcelFilter();
			this.dataGridViewCheckBoxColumn_0 = new DataGridViewCheckBoxColumn();
			this.dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_3 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_4 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_5 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_6 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_7 = new DataGridViewTextBoxColumn();
			this.bindingSource_0 = new BindingSource(this.icontainer_0);
			this.label_5 = new Label();
			this.groupBox_1 = new GroupBox();
			this.label_6 = new Label();
			this.comboBox_1 = new ComboBox();
			this.label_7 = new Label();
			this.comboBox_2 = new ComboBox();
			this.comboBox_3 = new ComboBox();
			this.label_8 = new Label();
			this.groupBox_2 = new GroupBox();
			this.label_9 = new Label();
			this.comboBox_4 = new ComboBox();
			this.label_10 = new Label();
			this.comboBox_5 = new ComboBox();
			this.comboBox_6 = new ComboBox();
			this.label_11 = new Label();
			this.checkBox_0 = new CheckBox();
			this.label_0 = new Label();
			this.textBox_0 = new TextBox();
			this.label_1 = new Label();
			this.groupBox_0 = new GroupBox();
			this.dataGridViewExcelFilter_2 = new DataGridViewExcelFilter();
			this.dataGridViewComboBoxColumn_0 = new DataGridViewComboBoxColumn();
			this.dataSet_0 = new DataSet();
			this.dataTable_0 = new DataTable();
			this.dataColumn_0 = new DataColumn();
			this.dataColumn_1 = new DataColumn();
			this.dataColumn_2 = new DataColumn();
			this.dataColumn_3 = new DataColumn();
			this.dataTable_1 = new DataTable();
			this.dataColumn_4 = new DataColumn();
			this.dataColumn_5 = new DataColumn();
			this.dataGridViewTextBoxColumn_11 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_12 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_13 = new DataGridViewTextBoxColumn();
			this.bindingSource_2 = new BindingSource(this.icontainer_0);
			this.toolStrip_1 = new ToolStrip();
			this.toolStripButton_5 = new ToolStripButton();
			this.toolStripButton_6 = new ToolStripButton();
			this.IubRlywhYQ = new ToolStripButton();
			this.comboBox_0 = new ComboBox();
			this.label_2 = new Label();
			this.nullableDateTimePicker_0 = new NullableDateTimePicker();
			this.label_3 = new Label();
			this.textBox_1 = new TextBox();
			this.label_4 = new Label();
			this.dateTimePicker_0 = new DateTimePicker();
			this.tabPage_1 = new TabPage();
			this.dataGridViewExcelFilter_1 = new DataGridViewExcelFilter();
			this.dataGridViewImageColumnNotNull_0 = new DataGridViewImageColumnNotNull();
			this.dataGridViewFilterTextBoxColumn_0 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewTextBoxColumn_8 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_9 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_10 = new DataGridViewTextBoxColumn();
			this.bindingSource_1 = new BindingSource(this.icontainer_0);
			this.toolStrip_0 = new ToolStrip();
			this.toolStripDropDownButton_0 = new ToolStripDropDownButton();
			this.toolStripMenuItem_0 = new ToolStripMenuItem();
			this.toolStripSeparator_0 = new ToolStripSeparator();
			this.toolStripButton_0 = new ToolStripButton();
			this.toolStripButton_1 = new ToolStripButton();
			this.toolStripButton_2 = new ToolStripButton();
			this.toolStripSeparator_1 = new ToolStripSeparator();
			this.toolStripButton_3 = new ToolStripButton();
			this.toolStripButton_4 = new ToolStripButton();
			this.button_0 = new Button();
			this.button_1 = new Button();
			this.tabControl_0.SuspendLayout();
			this.tabPage_0.SuspendLayout();
			((ISupportInitialize)this.class10_0).BeginInit();
			((ISupportInitialize)this.dataGridViewExcelFilter_0).BeginInit();
			((ISupportInitialize)this.bindingSource_0).BeginInit();
			this.groupBox_1.SuspendLayout();
			this.groupBox_2.SuspendLayout();
			this.groupBox_0.SuspendLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_2).BeginInit();
			((ISupportInitialize)this.dataSet_0).BeginInit();
			((ISupportInitialize)this.dataTable_0).BeginInit();
			((ISupportInitialize)this.dataTable_1).BeginInit();
			((ISupportInitialize)this.bindingSource_2).BeginInit();
			this.toolStrip_1.SuspendLayout();
			this.tabPage_1.SuspendLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_1).BeginInit();
			((ISupportInitialize)this.bindingSource_1).BeginInit();
			this.toolStrip_0.SuspendLayout();
			base.SuspendLayout();
			this.tabControl_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.tabControl_0.Controls.Add(this.tabPage_0);
			this.tabControl_0.Controls.Add(this.tabPage_1);
			this.tabControl_0.Location = new Point(0, 0);
			this.tabControl_0.Name = "tabControl";
			this.tabControl_0.SelectedIndex = 0;
			this.tabControl_0.Size = new Size(572, 453);
			this.tabControl_0.TabIndex = 0;
			this.tabPage_0.Controls.Add(this.comboBox_7);
			this.tabPage_0.Controls.Add(this.label_12);
			this.tabPage_0.Controls.Add(this.nullableDateTimePicker_1);
			this.tabPage_0.Controls.Add(this.label_13);
			this.tabPage_0.Controls.Add(this.checkBox_1);
			this.tabPage_0.Controls.Add(this.dataGridViewExcelFilter_0);
			this.tabPage_0.Controls.Add(this.label_5);
			this.tabPage_0.Controls.Add(this.groupBox_1);
			this.tabPage_0.Controls.Add(this.groupBox_2);
			this.tabPage_0.Controls.Add(this.checkBox_0);
			this.tabPage_0.Controls.Add(this.label_0);
			this.tabPage_0.Controls.Add(this.textBox_0);
			this.tabPage_0.Controls.Add(this.label_1);
			this.tabPage_0.Controls.Add(this.groupBox_0);
			this.tabPage_0.Controls.Add(this.dateTimePicker_0);
			this.tabPage_0.Location = new Point(4, 22);
			this.tabPage_0.Name = "tabPage1";
			this.tabPage_0.Padding = new Padding(3);
			this.tabPage_0.Size = new Size(564, 427);
			this.tabPage_0.TabIndex = 0;
			this.tabPage_0.Text = "Общие";
			this.tabPage_0.UseVisualStyleBackColor = true;
			this.comboBox_7.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.comboBox_7.DataBindings.Add(new Binding("SelectedValue", this.class10_0, "tTC_ChangeSwitch.idWorkerApply", true));
			this.comboBox_7.FormattingEnabled = true;
			this.comboBox_7.Location = new Point(429, 401);
			this.comboBox_7.Name = "cmbWorkerApply";
			this.comboBox_7.Size = new Size(132, 21);
			this.comboBox_7.TabIndex = 29;
			this.comboBox_7.SelectedValueChanged += this.comboBox_0_SelectedValueChanged;
			this.class10_0.DataSetName = "DataSetTechConnection";
			this.class10_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
			this.label_12.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.label_12.AutoSize = true;
			this.label_12.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 204);
			this.label_12.Location = new Point(335, 405);
			this.label_12.Name = "label14";
			this.label_12.Size = new Size(88, 13);
			this.label_12.TabIndex = 28;
			this.label_12.Text = "Согласующий";
			this.nullableDateTimePicker_1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.nullableDateTimePicker_1.DataBindings.Add(new Binding("Value", this.class10_0, "tTC_ChangeSwitch.dateApply", true));
			this.nullableDateTimePicker_1.Location = new Point(180, 401);
			this.nullableDateTimePicker_1.Name = "dtpApply";
			this.nullableDateTimePicker_1.Size = new Size(149, 20);
			this.nullableDateTimePicker_1.TabIndex = 27;
			this.nullableDateTimePicker_1.Value = new DateTime(2015, 4, 28, 8, 22, 31, 621);
			this.nullableDateTimePicker_1.ValueChanged += this.dateTimePicker_0_ValueChanged;
			this.label_13.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.label_13.AutoSize = true;
			this.label_13.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 204);
			this.label_13.Location = new Point(137, 405);
			this.label_13.Name = "label13";
			this.label_13.Size = new Size(37, 13);
			this.label_13.TabIndex = 26;
			this.label_13.Text = "Дата";
			this.checkBox_1.AutoSize = true;
			this.checkBox_1.Checked = true;
			this.checkBox_1.CheckState = CheckState.Checked;
			this.checkBox_1.Location = new Point(75, 283);
			this.checkBox_1.Name = "checkBoxSelAll";
			this.checkBox_1.Size = new Size(91, 17);
			this.checkBox_1.TabIndex = 25;
			this.checkBox_1.Text = "Выбрать все";
			this.checkBox_1.UseVisualStyleBackColor = true;
			this.checkBox_1.CheckedChanged += this.checkBox_1_CheckedChanged;
			this.dataGridViewExcelFilter_0.AllowUserToAddRows = false;
			this.dataGridViewExcelFilter_0.AllowUserToDeleteRows = false;
			this.dataGridViewExcelFilter_0.AllowUserToResizeRows = false;
			this.dataGridViewExcelFilter_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.dataGridViewExcelFilter_0.AutoGenerateColumns = false;
			this.dataGridViewExcelFilter_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewExcelFilter_0.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewCheckBoxColumn_0,
				this.dataGridViewTextBoxColumn_0,
				this.dataGridViewTextBoxColumn_1,
				this.dataGridViewTextBoxColumn_2,
				this.dataGridViewTextBoxColumn_3,
				this.dataGridViewTextBoxColumn_4,
				this.dataGridViewTextBoxColumn_5,
				this.dataGridViewTextBoxColumn_6,
				this.dataGridViewTextBoxColumn_7
			});
			this.dataGridViewExcelFilter_0.DataSource = this.bindingSource_0;
			this.dataGridViewExcelFilter_0.Location = new Point(0, 300);
			this.dataGridViewExcelFilter_0.Name = "dgvAbnObj";
			this.dataGridViewExcelFilter_0.RowHeadersVisible = false;
			this.dataGridViewExcelFilter_0.Size = new Size(564, 98);
			this.dataGridViewExcelFilter_0.TabIndex = 24;
			this.dataGridViewExcelFilter_0.CellValueChanged += this.dataGridViewExcelFilter_0_CellValueChanged;
			this.dataGridViewCheckBoxColumn_0.HeaderText = "";
			this.dataGridViewCheckBoxColumn_0.Name = "cmbChecked";
			this.dataGridViewCheckBoxColumn_0.Resizable = DataGridViewTriState.True;
			this.dataGridViewCheckBoxColumn_0.SortMode = DataGridViewColumnSortMode.Automatic;
			this.dataGridViewCheckBoxColumn_0.Width = 50;
			this.dataGridViewTextBoxColumn_0.DataPropertyName = "CodeAbonent";
			this.dataGridViewTextBoxColumn_0.HeaderText = "Код";
			this.dataGridViewTextBoxColumn_0.Name = "codeAbonentDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_0.ReadOnly = true;
			this.dataGridViewTextBoxColumn_1.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_1.HeaderText = "id";
			this.dataGridViewTextBoxColumn_1.Name = "idAbnObjDgvColumn";
			this.dataGridViewTextBoxColumn_1.Visible = false;
			this.dataGridViewTextBoxColumn_2.DataPropertyName = "idAbn";
			this.dataGridViewTextBoxColumn_2.HeaderText = "idAbn";
			this.dataGridViewTextBoxColumn_2.Name = "idAbnDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_2.Visible = false;
			this.dataGridViewTextBoxColumn_3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_3.DataPropertyName = "Name";
			this.dataGridViewTextBoxColumn_3.HeaderText = "Абонент";
			this.dataGridViewTextBoxColumn_3.Name = "nameDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_3.ReadOnly = true;
			this.dataGridViewTextBoxColumn_4.DataPropertyName = "TypeAbn";
			this.dataGridViewTextBoxColumn_4.HeaderText = "TypeAbn";
			this.dataGridViewTextBoxColumn_4.Name = "typeAbnDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_4.Visible = false;
			this.dataGridViewTextBoxColumn_5.DataPropertyName = "typeAbnName";
			this.dataGridViewTextBoxColumn_5.HeaderText = "typeAbnName";
			this.dataGridViewTextBoxColumn_5.Name = "typeAbnNameDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_5.Visible = false;
			this.dataGridViewTextBoxColumn_6.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_6.DataPropertyName = "nameObj";
			this.dataGridViewTextBoxColumn_6.HeaderText = "Объект";
			this.dataGridViewTextBoxColumn_6.Name = "nameObjDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_6.ReadOnly = true;
			this.dataGridViewTextBoxColumn_7.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_7.DataPropertyName = "address";
			this.dataGridViewTextBoxColumn_7.HeaderText = "Адрес";
			this.dataGridViewTextBoxColumn_7.Name = "addressDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_7.ReadOnly = true;
			this.bindingSource_0.DataMember = "vAbnObj";
			this.bindingSource_0.DataSource = this.class10_0;
			this.label_5.AutoSize = true;
			this.label_5.Location = new Point(16, 284);
			this.label_5.Name = "label12";
			this.label_5.Size = new Size(53, 13);
			this.label_5.TabIndex = 23;
			this.label_5.Text = "Объекты";
			this.groupBox_1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox_1.Controls.Add(this.label_6);
			this.groupBox_1.Controls.Add(this.comboBox_1);
			this.groupBox_1.Controls.Add(this.label_7);
			this.groupBox_1.Controls.Add(this.comboBox_2);
			this.groupBox_1.Controls.Add(this.comboBox_3);
			this.groupBox_1.Controls.Add(this.label_8);
			this.groupBox_1.Location = new Point(6, 217);
			this.groupBox_1.Name = "groupBoxNewSchm";
			this.groupBox_1.Size = new Size(550, 64);
			this.groupBox_1.TabIndex = 22;
			this.groupBox_1.TabStop = false;
			this.groupBox_1.Text = "Новый объект";
			this.label_6.AutoSize = true;
			this.label_6.Location = new Point(307, 16);
			this.label_6.Name = "label9";
			this.label_6.Size = new Size(44, 13);
			this.label_6.TabIndex = 5;
			this.label_6.Text = "Ячейка";
			this.comboBox_1.FormattingEnabled = true;
			this.comboBox_1.Location = new Point(296, 32);
			this.comboBox_1.Name = "cmbCellNew";
			this.comboBox_1.Size = new Size(121, 21);
			this.comboBox_1.TabIndex = 4;
			this.comboBox_1.SelectedValueChanged += this.comboBox_0_SelectedValueChanged;
			this.label_7.AutoSize = true;
			this.label_7.Location = new Point(169, 16);
			this.label_7.Name = "label10";
			this.label_7.Size = new Size(34, 13);
			this.label_7.TabIndex = 3;
			this.label_7.Text = "Шина";
			this.comboBox_2.FormattingEnabled = true;
			this.comboBox_2.Location = new Point(160, 32);
			this.comboBox_2.Name = "cmbBusNew";
			this.comboBox_2.Size = new Size(121, 21);
			this.comboBox_2.TabIndex = 2;
			this.comboBox_2.SelectedIndexChanged += this.comboBox_5_SelectedIndexChanged;
			this.comboBox_2.SelectedValueChanged += this.comboBox_0_SelectedValueChanged;
			this.comboBox_3.FormattingEnabled = true;
			this.comboBox_3.Location = new Point(13, 32);
			this.comboBox_3.Name = "cmbSubNew";
			this.comboBox_3.Size = new Size(121, 21);
			this.comboBox_3.TabIndex = 1;
			this.comboBox_3.SelectedIndexChanged += this.comboBox_6_SelectedIndexChanged;
			this.comboBox_3.SelectedValueChanged += this.comboBox_0_SelectedValueChanged;
			this.label_8.AutoSize = true;
			this.label_8.Location = new Point(10, 16);
			this.label_8.Name = "label11";
			this.label_8.Size = new Size(68, 13);
			this.label_8.TabIndex = 0;
			this.label_8.Text = "Подстанция";
			this.groupBox_2.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox_2.Controls.Add(this.label_9);
			this.groupBox_2.Controls.Add(this.comboBox_4);
			this.groupBox_2.Controls.Add(this.label_10);
			this.groupBox_2.Controls.Add(this.comboBox_5);
			this.groupBox_2.Controls.Add(this.comboBox_6);
			this.groupBox_2.Controls.Add(this.label_11);
			this.groupBox_2.Location = new Point(6, 147);
			this.groupBox_2.Name = "groupBoxOldSchm";
			this.groupBox_2.Size = new Size(550, 64);
			this.groupBox_2.TabIndex = 21;
			this.groupBox_2.TabStop = false;
			this.groupBox_2.Text = "Старый объект";
			this.label_9.AutoSize = true;
			this.label_9.Location = new Point(307, 16);
			this.label_9.Name = "label8";
			this.label_9.Size = new Size(44, 13);
			this.label_9.TabIndex = 5;
			this.label_9.Text = "Ячейка";
			this.comboBox_4.FormattingEnabled = true;
			this.comboBox_4.Location = new Point(296, 32);
			this.comboBox_4.Name = "cmbCellOld";
			this.comboBox_4.Size = new Size(121, 21);
			this.comboBox_4.TabIndex = 4;
			this.comboBox_4.SelectedIndexChanged += this.comboBox_4_SelectedIndexChanged;
			this.comboBox_4.SelectedValueChanged += this.comboBox_0_SelectedValueChanged;
			this.label_10.AutoSize = true;
			this.label_10.Location = new Point(169, 16);
			this.label_10.Name = "label7";
			this.label_10.Size = new Size(34, 13);
			this.label_10.TabIndex = 3;
			this.label_10.Text = "Шина";
			this.comboBox_5.FormattingEnabled = true;
			this.comboBox_5.Location = new Point(160, 32);
			this.comboBox_5.Name = "cmbBusOld";
			this.comboBox_5.Size = new Size(121, 21);
			this.comboBox_5.TabIndex = 2;
			this.comboBox_5.SelectedIndexChanged += this.comboBox_5_SelectedIndexChanged;
			this.comboBox_5.SelectedValueChanged += this.comboBox_0_SelectedValueChanged;
			this.comboBox_6.FormattingEnabled = true;
			this.comboBox_6.Location = new Point(13, 32);
			this.comboBox_6.Name = "cmbSubOld";
			this.comboBox_6.Size = new Size(121, 21);
			this.comboBox_6.TabIndex = 1;
			this.comboBox_6.SelectedIndexChanged += this.comboBox_6_SelectedIndexChanged;
			this.comboBox_6.SelectedValueChanged += this.comboBox_0_SelectedValueChanged;
			this.label_11.AutoSize = true;
			this.label_11.Location = new Point(10, 16);
			this.label_11.Name = "label6";
			this.label_11.Size = new Size(68, 13);
			this.label_11.TabIndex = 0;
			this.label_11.Text = "Подстанция";
			this.checkBox_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.checkBox_0.AutoSize = true;
			this.checkBox_0.DataBindings.Add(new Binding("Checked", this.class10_0, "tTC_ChangeSwitch.isApply", true));
			this.checkBox_0.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 204);
			this.checkBox_0.Location = new Point(11, 404);
			this.checkBox_0.Name = "checkBoxApply";
			this.checkBox_0.Size = new Size(103, 17);
			this.checkBox_0.TabIndex = 20;
			this.checkBox_0.Text = "Согласовано";
			this.checkBox_0.TextAlign = ContentAlignment.MiddleCenter;
			this.checkBox_0.UseVisualStyleBackColor = true;
			this.checkBox_0.CheckedChanged += this.checkBox_0_CheckedChanged;
			this.label_0.AutoSize = true;
			this.label_0.Location = new Point(8, 12);
			this.label_0.Name = "label1";
			this.label_0.Size = new Size(75, 13);
			this.label_0.TabIndex = 5;
			this.label_0.Text = "№ документа";
			this.textBox_0.BackColor = SystemColors.Window;
			this.textBox_0.DataBindings.Add(new Binding("Text", this.class10_0, "tTC_Doc.numDoc", true));
			this.textBox_0.Location = new Point(89, 9);
			this.textBox_0.Name = "txtDocNum";
			this.textBox_0.ReadOnly = true;
			this.textBox_0.Size = new Size(82, 20);
			this.textBox_0.TabIndex = 6;
			this.label_1.AutoSize = true;
			this.label_1.Location = new Point(177, 12);
			this.label_1.Name = "label2";
			this.label_1.Size = new Size(90, 13);
			this.label_1.TabIndex = 7;
			this.label_1.Text = "Дата документа";
			this.groupBox_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox_0.Controls.Add(this.dataGridViewExcelFilter_2);
			this.groupBox_0.Controls.Add(this.toolStrip_1);
			this.groupBox_0.Controls.Add(this.comboBox_0);
			this.groupBox_0.Controls.Add(this.label_2);
			this.groupBox_0.Controls.Add(this.nullableDateTimePicker_0);
			this.groupBox_0.Controls.Add(this.label_3);
			this.groupBox_0.Controls.Add(this.textBox_1);
			this.groupBox_0.Controls.Add(this.label_4);
			this.groupBox_0.Location = new Point(8, 39);
			this.groupBox_0.Name = "groupBoxDocIn";
			this.groupBox_0.Size = new Size(550, 107);
			this.groupBox_0.TabIndex = 9;
			this.groupBox_0.TabStop = false;
			this.groupBox_0.Text = "Регламентирующие документы";
			this.dataGridViewExcelFilter_2.AllowUserToAddRows = false;
			this.dataGridViewExcelFilter_2.AllowUserToDeleteRows = false;
			this.dataGridViewExcelFilter_2.AutoGenerateColumns = false;
			this.dataGridViewExcelFilter_2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewExcelFilter_2.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewComboBoxColumn_0,
				this.dataGridViewTextBoxColumn_11,
				this.dataGridViewTextBoxColumn_12,
				this.dataGridViewTextBoxColumn_13
			});
			this.dataGridViewExcelFilter_2.DataSource = this.bindingSource_2;
			this.dataGridViewExcelFilter_2.Dock = DockStyle.Fill;
			this.dataGridViewExcelFilter_2.Location = new Point(27, 16);
			this.dataGridViewExcelFilter_2.Name = "dgvDocIn";
			this.dataGridViewExcelFilter_2.ReadOnly = true;
			this.dataGridViewExcelFilter_2.Size = new Size(520, 88);
			this.dataGridViewExcelFilter_2.TabIndex = 7;
			this.dataGridViewExcelFilter_2.CellDoubleClick += this.dataGridViewExcelFilter_2_CellDoubleClick;
			this.dataGridViewComboBoxColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewComboBoxColumn_0.DataPropertyName = "typeDoc";
			this.dataGridViewComboBoxColumn_0.DataSource = this.dataSet_0;
			this.dataGridViewComboBoxColumn_0.DisplayMember = "tR_Classifier.name";
			this.dataGridViewComboBoxColumn_0.HeaderText = "Тип";
			this.dataGridViewComboBoxColumn_0.Name = "typeDocDataGridViewTextBoxColumn";
			this.dataGridViewComboBoxColumn_0.ReadOnly = true;
			this.dataGridViewComboBoxColumn_0.Resizable = DataGridViewTriState.True;
			this.dataGridViewComboBoxColumn_0.SortMode = DataGridViewColumnSortMode.Automatic;
			this.dataGridViewComboBoxColumn_0.ValueMember = "tR_Classifier.id";
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
				this.dataColumn_3
			});
			this.dataTable_0.TableName = "dtDocIn";
			this.dataColumn_0.ColumnName = "numDoc";
			this.dataColumn_1.ColumnName = "dateDoc";
			this.dataColumn_1.DataType = typeof(DateTime);
			this.dataColumn_2.ColumnName = "typeDoc";
			this.dataColumn_2.DataType = typeof(int);
			this.dataColumn_3.ColumnName = "Comment";
			this.dataTable_1.Columns.AddRange(new DataColumn[]
			{
				this.dataColumn_4,
				this.dataColumn_5
			});
			this.dataTable_1.TableName = "tR_Classifier";
			this.dataColumn_4.ColumnName = "id";
			this.dataColumn_4.DataType = typeof(int);
			this.dataColumn_5.ColumnName = "name";
			this.dataGridViewTextBoxColumn_11.DataPropertyName = "numDoc";
			this.dataGridViewTextBoxColumn_11.HeaderText = "№ док.";
			this.dataGridViewTextBoxColumn_11.Name = "numDocDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_11.ReadOnly = true;
			this.dataGridViewTextBoxColumn_11.Width = 80;
			this.dataGridViewTextBoxColumn_12.DataPropertyName = "dateDoc";
			this.dataGridViewTextBoxColumn_12.HeaderText = "Дата";
			this.dataGridViewTextBoxColumn_12.Name = "dateDocDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_12.ReadOnly = true;
			this.dataGridViewTextBoxColumn_12.Width = 80;
			this.dataGridViewTextBoxColumn_13.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_13.DataPropertyName = "Comment";
			this.dataGridViewTextBoxColumn_13.HeaderText = "Комментарий";
			this.dataGridViewTextBoxColumn_13.Name = "commentDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_13.ReadOnly = true;
			this.bindingSource_2.DataMember = "dtDocIn";
			this.bindingSource_2.DataSource = this.dataSet_0;
			this.toolStrip_1.Dock = DockStyle.Left;
			this.toolStrip_1.GripStyle = ToolStripGripStyle.Hidden;
			this.toolStrip_1.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripButton_5,
				this.toolStripButton_6,
				this.IubRlywhYQ
			});
			this.toolStrip_1.Location = new Point(3, 16);
			this.toolStrip_1.Name = "toolStripDocIn";
			this.toolStrip_1.Size = new Size(24, 88);
			this.toolStrip_1.TabIndex = 6;
			this.toolStrip_1.Text = "toolStrip1";
			this.toolStripButton_5.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_5.Image = Resources.ElementAdd;
			this.toolStripButton_5.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_5.Name = "toolBtnAddDocIn";
			this.toolStripButton_5.Size = new Size(21, 20);
			this.toolStripButton_5.Text = "toolStripButton1";
			this.toolStripButton_5.Click += this.toolStripButton_5_Click;
			this.toolStripButton_6.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_6.Image = Resources.ElementEdit;
			this.toolStripButton_6.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_6.Name = "toolBtnEditDocIn";
			this.toolStripButton_6.Size = new Size(21, 20);
			this.toolStripButton_6.Text = "toolStripButton2";
			this.toolStripButton_6.Click += this.toolStripButton_6_Click;
			this.IubRlywhYQ.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.IubRlywhYQ.Image = Resources.ElementDel;
			this.IubRlywhYQ.ImageTransparentColor = Color.Magenta;
			this.IubRlywhYQ.Name = "toolBtnDelDocIn";
			this.IubRlywhYQ.Size = new Size(21, 20);
			this.IubRlywhYQ.Text = "toolStripButton3";
			this.IubRlywhYQ.Click += this.IubRlywhYQ_Click;
			this.comboBox_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.comboBox_0.DataBindings.Add(new Binding("SelectedValue", this.class10_0, "tTC_ChangeSwitch.TypeDocIn", true));
			this.comboBox_0.FormattingEnabled = true;
			this.comboBox_0.Location = new Point(172, 23);
			this.comboBox_0.Name = "cmbTypeDocIn";
			this.comboBox_0.Size = new Size(212, 21);
			this.comboBox_0.TabIndex = 5;
			this.comboBox_0.SelectedValueChanged += this.comboBox_0_SelectedValueChanged;
			this.label_2.AutoSize = true;
			this.label_2.Location = new Point(178, 15);
			this.label_2.Name = "label5";
			this.label_2.Size = new Size(83, 13);
			this.label_2.TabIndex = 4;
			this.label_2.Text = "Тип документа";
			this.nullableDateTimePicker_0.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.nullableDateTimePicker_0.CustomFormat = "";
			this.nullableDateTimePicker_0.DataBindings.Add(new Binding("Value", this.class10_0, "tTC_ChangeSwitch.dateDocIn", true));
			this.nullableDateTimePicker_0.Location = new Point(429, 21);
			this.nullableDateTimePicker_0.Name = "dtpDateDocIn";
			this.nullableDateTimePicker_0.Size = new Size(115, 20);
			this.nullableDateTimePicker_0.TabIndex = 3;
			this.nullableDateTimePicker_0.Value = new DateTime(2013, 4, 15, 13, 28, 53, 804);
			this.nullableDateTimePicker_0.ValueChanged += this.dateTimePicker_0_ValueChanged;
			this.label_3.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.label_3.AutoSize = true;
			this.label_3.Location = new Point(390, 26);
			this.label_3.Name = "label3";
			this.label_3.Size = new Size(33, 13);
			this.label_3.TabIndex = 2;
			this.label_3.Text = "Дата";
			this.textBox_1.DataBindings.Add(new Binding("Text", this.class10_0, "tTC_ChangeSwitch.numDocIn", true));
			this.textBox_1.Location = new Point(57, 24);
			this.textBox_1.Name = "txtNumDocIn";
			this.textBox_1.Size = new Size(106, 20);
			this.textBox_1.TabIndex = 1;
			this.textBox_1.TextChanged += this.textBox_1_TextChanged;
			this.label_4.AutoSize = true;
			this.label_4.Location = new Point(10, 27);
			this.label_4.Name = "label4";
			this.label_4.Size = new Size(41, 13);
			this.label_4.TabIndex = 0;
			this.label_4.Text = "Номер";
			this.dateTimePicker_0.DataBindings.Add(new Binding("Value", this.class10_0, "tTC_Doc.dateDoc", true));
			this.dateTimePicker_0.Location = new Point(273, 9);
			this.dateTimePicker_0.Name = "dtpDateDoc";
			this.dateTimePicker_0.Size = new Size(146, 20);
			this.dateTimePicker_0.TabIndex = 8;
			this.dateTimePicker_0.ValueChanged += this.dateTimePicker_0_ValueChanged;
			this.tabPage_1.Controls.Add(this.dataGridViewExcelFilter_1);
			this.tabPage_1.Controls.Add(this.toolStrip_0);
			this.tabPage_1.Location = new Point(4, 22);
			this.tabPage_1.Name = "tabPage2";
			this.tabPage_1.Padding = new Padding(3);
			this.tabPage_1.Size = new Size(564, 427);
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
				this.dataGridViewTextBoxColumn_8,
				this.dataGridViewTextBoxColumn_9,
				this.dataGridViewTextBoxColumn_10
			});
			this.dataGridViewExcelFilter_1.DataSource = this.bindingSource_1;
			this.dataGridViewExcelFilter_1.Dock = DockStyle.Fill;
			this.dataGridViewExcelFilter_1.EditMode = DataGridViewEditMode.EditProgrammatically;
			this.dataGridViewExcelFilter_1.Location = new Point(3, 28);
			this.dataGridViewExcelFilter_1.Name = "dgvFile";
			this.dataGridViewExcelFilter_1.ReadOnly = true;
			this.dataGridViewExcelFilter_1.RowHeadersVisible = false;
			this.dataGridViewExcelFilter_1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewExcelFilter_1.Size = new Size(558, 396);
			this.dataGridViewExcelFilter_1.TabIndex = 8;
			this.dataGridViewExcelFilter_1.VirtualMode = true;
			dataGridViewCellStyle.NullValue = null;
			this.dataGridViewImageColumnNotNull_0.DefaultCellStyle = dataGridViewCellStyle;
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
			this.dataGridViewTextBoxColumn_8.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_8.HeaderText = "id";
			this.dataGridViewTextBoxColumn_8.Name = "id";
			this.dataGridViewTextBoxColumn_8.ReadOnly = true;
			this.dataGridViewTextBoxColumn_8.Visible = false;
			this.dataGridViewTextBoxColumn_9.DataPropertyName = "dateChange";
			this.dataGridViewTextBoxColumn_9.HeaderText = "dateChange";
			this.dataGridViewTextBoxColumn_9.Name = "dateChangeDgvColumn";
			this.dataGridViewTextBoxColumn_9.ReadOnly = true;
			this.dataGridViewTextBoxColumn_9.Visible = false;
			this.dataGridViewTextBoxColumn_10.DataPropertyName = "idTemplate";
			this.dataGridViewTextBoxColumn_10.HeaderText = "idTemplate";
			this.dataGridViewTextBoxColumn_10.Name = "idTemplateDgvColumn";
			this.dataGridViewTextBoxColumn_10.ReadOnly = true;
			this.dataGridViewTextBoxColumn_10.Visible = false;
			this.bindingSource_1.DataMember = "tTC_DocFile";
			this.bindingSource_1.DataSource = this.class10_0;
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
			this.toolStrip_0.Size = new Size(558, 25);
			this.toolStrip_0.TabIndex = 7;
			this.toolStrip_0.Text = "toolStrip1";
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
			this.toolStripMenuItem_0.Click += this.toolStripMenuItem_0_Click;
			this.toolStripSeparator_0.Name = "toolStripSeparator2";
			this.toolStripSeparator_0.Size = new Size(187, 6);
			this.toolStripButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_0.Image = Resources.ElementEdit;
			this.toolStripButton_0.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_0.Name = "toolBtnEditFile";
			this.toolStripButton_0.Size = new Size(23, 22);
			this.toolStripButton_0.Text = "Редактировать файл";
			this.toolStripButton_0.Click += this.toolStripButton_0_Click;
			this.toolStripButton_1.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_1.Image = Resources.ElementInformation;
			this.toolStripButton_1.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_1.Name = "toolBtnOpenFile";
			this.toolStripButton_1.Size = new Size(23, 22);
			this.toolStripButton_1.Text = "Открыть файл";
			this.toolStripButton_1.Click += this.toolStripButton_1_Click;
			this.toolStripButton_2.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_2.Image = Resources.ElementDel;
			this.toolStripButton_2.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_2.Name = "toolBtnDelFile";
			this.toolStripButton_2.Size = new Size(23, 22);
			this.toolStripButton_2.Text = "Удалить файл";
			this.toolStripButton_2.Click += this.toolStripButton_2_Click;
			this.toolStripSeparator_1.Name = "toolStripSeparator3";
			this.toolStripSeparator_1.Size = new Size(6, 25);
			this.toolStripButton_3.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_3.Image = Resources.rename;
			this.toolStripButton_3.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_3.Name = "toolBtnRenameFile";
			this.toolStripButton_3.Size = new Size(23, 22);
			this.toolStripButton_3.Text = "Переименовать";
			this.toolStripButton_3.Click += this.toolStripButton_3_Click;
			this.toolStripButton_4.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_4.Image = Resources.save;
			this.toolStripButton_4.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_4.Name = "toolBtnSaveFile";
			this.toolStripButton_4.Size = new Size(23, 22);
			this.toolStripButton_4.Text = "Сохранить файл на диск";
			this.toolStripButton_4.Click += this.toolStripButton_4_Click;
			this.button_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.button_0.DialogResult = DialogResult.OK;
			this.button_0.Location = new Point(349, 459);
			this.button_0.Name = "buttonSaveAndClose";
			this.button_0.Size = new Size(132, 23);
			this.button_0.TabIndex = 21;
			this.button_0.Text = "Сохранить и закрыть";
			this.button_0.UseVisualStyleBackColor = true;
			this.button_0.Click += this.button_0_Click;
			this.button_1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.button_1.DialogResult = DialogResult.Cancel;
			this.button_1.Location = new Point(487, 459);
			this.button_1.Name = "buttonClose";
			this.button_1.Size = new Size(75, 23);
			this.button_1.TabIndex = 20;
			this.button_1.Text = "Закрыть";
			this.button_1.UseVisualStyleBackColor = true;
			this.button_1.Click += this.button_1_Click;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(572, 491);
			base.Controls.Add(this.button_0);
			base.Controls.Add(this.button_1);
			base.Controls.Add(this.tabControl_0);
			base.Name = "FormDocChangeSwitch";
			this.Text = "Смена рубильника";
			base.FormClosing += this.FormDocChangeSwitch_FormClosing;
			base.Load += this.FormDocChangeSwitch_Load;
			base.Shown += this.FormDocChangeSwitch_Shown;
			this.tabControl_0.ResumeLayout(false);
			this.tabPage_0.ResumeLayout(false);
			this.tabPage_0.PerformLayout();
			((ISupportInitialize)this.class10_0).EndInit();
			((ISupportInitialize)this.dataGridViewExcelFilter_0).EndInit();
			((ISupportInitialize)this.bindingSource_0).EndInit();
			this.groupBox_1.ResumeLayout(false);
			this.groupBox_1.PerformLayout();
			this.groupBox_2.ResumeLayout(false);
			this.groupBox_2.PerformLayout();
			this.groupBox_0.ResumeLayout(false);
			this.groupBox_0.PerformLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_2).EndInit();
			((ISupportInitialize)this.dataSet_0).EndInit();
			((ISupportInitialize)this.dataTable_0).EndInit();
			((ISupportInitialize)this.dataTable_1).EndInit();
			((ISupportInitialize)this.bindingSource_2).EndInit();
			this.toolStrip_1.ResumeLayout(false);
			this.toolStrip_1.PerformLayout();
			this.tabPage_1.ResumeLayout(false);
			this.tabPage_1.PerformLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_1).EndInit();
			((ISupportInitialize)this.bindingSource_1).EndInit();
			this.toolStrip_0.ResumeLayout(false);
			this.toolStrip_0.PerformLayout();
			base.ResumeLayout(false);
		}

		[CompilerGenerated]
		private void method_40()
		{
			this.bindingSource_1.ResetBindings(false);
		}

		private int? nullable_0;

		private bool nclUhXcedv;

		private bool bool_0;

		private Dictionary<string, FileWatcherArgsAddl> dictionary_0;

		private string string_0;

		private TabControl tabControl_0;

		private TabPage tabPage_0;

		private TabPage tabPage_1;

		private Class10 class10_0;

		private Label label_0;

		private TextBox textBox_0;

		private Label label_1;

		private GroupBox groupBox_0;

		private ComboBox comboBox_0;

		private Label label_2;

		private NullableDateTimePicker nullableDateTimePicker_0;

		private Label label_3;

		private TextBox textBox_1;

		private Label label_4;

		private DateTimePicker dateTimePicker_0;

		private Button button_0;

		private Button button_1;

		private CheckBox checkBox_0;

		private DataGridViewExcelFilter dataGridViewExcelFilter_0;

		private Label label_5;

		private GroupBox groupBox_1;

		private Label label_6;

		private ComboBox comboBox_1;

		private Label label_7;

		private ComboBox comboBox_2;

		private ComboBox comboBox_3;

		private Label label_8;

		private GroupBox groupBox_2;

		private Label label_9;

		private ComboBox comboBox_4;

		private Label label_10;

		private ComboBox comboBox_5;

		private ComboBox comboBox_6;

		private Label label_11;

		private CheckBox checkBox_1;

		private BindingSource bindingSource_0;

		private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn_0;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_3;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_4;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_5;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_6;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_7;

		private BindingSource bindingSource_1;

		private DataGridViewExcelFilter dataGridViewExcelFilter_1;

		private DataGridViewImageColumnNotNull dataGridViewImageColumnNotNull_0;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_0;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_8;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_9;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_10;

		private ToolStrip toolStrip_0;

		private ToolStripDropDownButton toolStripDropDownButton_0;

		private ToolStripMenuItem toolStripMenuItem_0;

		private ToolStripSeparator toolStripSeparator_0;

		private ToolStripButton toolStripButton_0;

		private ToolStripButton toolStripButton_1;

		private ToolStripButton toolStripButton_2;

		private ToolStripSeparator toolStripSeparator_1;

		private ToolStripButton toolStripButton_3;

		private ToolStripButton toolStripButton_4;

		private ComboBox comboBox_7;

		private Label label_12;

		private NullableDateTimePicker nullableDateTimePicker_1;

		private Label label_13;

		private DataGridViewExcelFilter dataGridViewExcelFilter_2;

		private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_0;

		private DataSet dataSet_0;

		private DataTable dataTable_0;

		private DataColumn dataColumn_0;

		private DataColumn dataColumn_1;

		private DataColumn dataColumn_2;

		private DataColumn dataColumn_3;

		private DataTable dataTable_1;

		private DataColumn dataColumn_4;

		private DataColumn dataColumn_5;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_11;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_12;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_13;

		private BindingSource bindingSource_2;

		private ToolStrip toolStrip_1;

		private ToolStripButton toolStripButton_5;

		private ToolStripButton toolStripButton_6;

		private ToolStripButton IubRlywhYQ;
	}
}
