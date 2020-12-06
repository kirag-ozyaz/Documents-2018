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
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using ControlsLbr;
using ControlsLbr.DataGridViewExcelFilter;
using DataSql;
using Documents.Properties;
using FormLbr;
using FormLbr.Classes;

namespace Documents.Forms.TechnologicalConnection.Acts
{
	public partial class FormActElectricalInspection : FormBase
	{
		internal int method_0()
		{
			return this.int_0;
		}

		internal FormActElectricalInspection()
		{
			
			this.int_0 = -1;
			this.int_1 = -1;
			this.int_2 = -1;
			this.int_3 = -1;
			this.int_4 = 1238;
			this.dictionary_0 = new Dictionary<string, FileWatcherArgsAddl>();
			this.string_0 = "";
			
			this.method_23();
			this.method_1();
		}

		public FormActElectricalInspection(int idAct, int idTU = -1, int typeAct = 1238)
		{
			
			this.int_0 = -1;
			this.int_1 = -1;
			this.int_2 = -1;
			this.int_3 = -1;
			this.int_4 = 1238;
			this.dictionary_0 = new Dictionary<string, FileWatcherArgsAddl>();
			this.string_0 = "";
			
			this.method_23();
			this.int_0 = idAct;
			this.int_1 = idTU;
			this.int_4 = typeAct;
			this.method_1();
		}

		private void method_1()
		{
			this.Text = ((this.int_0 == -1) ? "Добавление акта осмотра электроустановки" : "Редактирование акта осмотра электроустановки");
		}

		private void FormActElectricalInspection_Load(object sender, EventArgs e)
		{
			this.dateTimePicker_0.Value = DateTime.Now.Date;
			this.method_2();
			this.method_20();
			this.method_3();
			base.LoadFormConfig(null);
			foreach (object obj in ((IEnumerable)this.dataGridView_0.Rows))
			{
				((DataGridViewRow)obj).Cells[this.dataGridViewCheckBoxColumn_0.Name].Value = false;
			}
			if (this.int_0 == -1)
			{
				DataRow dataRow = this.class10_0.tTC_Doc.NewRow();
				dataRow["DateDoc"] = DateTime.Now.Date;
				dataRow["TypeDoc"] = this.int_4;
				dataRow["idParent"] = this.int_1;
				this.class10_0.tTC_Doc.Rows.Add(dataRow);
			}
			else
			{
				base.SelectSqlData(this.class10_0, this.class10_0.tTC_Doc, true, "where id = " + this.int_0.ToString());
				base.SelectSqlData(this.class10_0, this.class10_0.tTC_ElectricalInspection, true, "where id = " + this.int_0.ToString());
				if (this.class10_0.tTC_ElectricalInspection.Rows.Count > 0)
				{
					if (this.class10_0.tTC_ElectricalInspection.Rows[0]["dateRecipient"] != DBNull.Value)
					{
						this.dateTimePicker_0.Value = Convert.ToDateTime(this.class10_0.tTC_ElectricalInspection.Rows[0]["dateRecipient"]);
					}
					if (this.class10_0.tTC_ElectricalInspection.Rows[0]["Mail"] != DBNull.Value)
					{
						try
						{
							XmlDocument xmlDocument = new XmlDocument();
							xmlDocument.LoadXml(this.class10_0.tTC_ElectricalInspection.Rows[0]["Mail"].ToString());
							this.ApplyConfig(xmlDocument);
						}
						catch
						{
						}
					}
					this.method_21();
				}
				this.method_16(this.int_0);
			}
			this.bool_0 = false;
		}

		private void FormActElectricalInspection_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.bool_0)
			{
				DialogResult dialogResult = MessageBox.Show("Были внесены изменения. Сохранить документ?", "Сохранение", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
				if (dialogResult == DialogResult.Yes)
				{
					if (!this.method_6())
					{
						e.Cancel = true;
						return;
					}
					bool flag = false;
					int i = 0;
					while (i < this.dataGridView_0.Rows.Count - 1)
					{
						if (Convert.ToBoolean(this.dataGridView_0.Rows[i].Cells[this.dataGridViewCheckBoxColumn_0.Name].Value))
						{
							i++;
						}
						else
						{
							flag = true;
							IL_8A:
							if (flag && MessageBox.Show("Данные успешно сохранены.\r\nОтправить документ выбранным адресатам?", "Отправка почты", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
							{
								this.method_19(true);
								goto IL_A9;
							}
							goto IL_A9;
						}
					}
					goto IL_8A;
				}
				IL_A9:
				if (dialogResult == DialogResult.Cancel)
				{
					e.Cancel = true;
					return;
				}
			}
		}

		private void FormActElectricalInspection_FormClosed(object sender, FormClosedEventArgs e)
		{
			base.SaveFormConfig(null);
		}

		private void method_2()
		{
			DataTable dataTable = new DataTable("vWorkerGroup");
			dataTable.Columns.Add(new DataColumn("id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("fio", typeof(string)));
			base.SelectSqlData(dataTable, true, "where parentKey = ';GroupWorker;HeadRegion;' order by fio", null, false, 0);
			DataRow dataRow = dataTable.NewRow();
			dataRow["id"] = DBNull.Value;
			dataRow["fio"] = "";
			dataTable.Rows.InsertAt(dataRow, 0);
			this.comboBox_1.DisplayMember = "FIO";
			this.comboBox_1.ValueMember = "id";
			this.comboBox_1.DataSource = dataTable;
			dataTable = new DataTable("vR_worker");
			dataTable.Columns.Add(new DataColumn("id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("fio", typeof(string)));
			BindingSource bindingSource = new BindingSource();
			bindingSource.DataSource = dataTable;
			base.SelectSqlData(dataTable, true, "where dateEnd is null order by fio", null, false, 0);
			this.dataGridViewComboBoxColumn_0.DisplayMember = "FIO";
			this.dataGridViewComboBoxColumn_0.ValueMember = "id";
			this.dataGridViewComboBoxColumn_0.DataSource = bindingSource;
		}

		private void method_3()
		{
			string text = string.Concat(new string[]
			{
				"select  d.id, d.numdoc, d.datedoc,  isnull(d.numdoc, '') + ' от ' + isnull(convert( varchar(10),d.Datedoc, 104), '') as numDatedoc  from ttc_doc d  where typeDoc = ",
				1123.ToString(),
				" and (id not in (select idparent from ttc_doc where typedoc = ",
				1238.ToString(),
				" and idParent is not null) or id in (select idParent from ttc_doc where id = ",
				this.method_0().ToString(),
				" and idParent is not null)) "
			});
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
			this.comboBox_0.SelectedValueChanged -= this.comboBox_0_SelectedValueChanged;
			BindingSource bindingSource = new BindingSource();
			bindingSource.DataSource = dataTable;
			bindingSource.Sort = "numDoc, dateDoc";
			this.comboBox_0.DataSource = bindingSource;
			this.comboBox_0.DisplayMember = "numDateDoc";
			this.comboBox_0.ValueMember = "id";
			this.comboBox_0.SelectedValueChanged += this.comboBox_0_SelectedValueChanged;
			if (this.int_1 != -1)
			{
				this.comboBox_0.SelectedValue = this.int_1;
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
					this.int_1 = Convert.ToInt32(this.comboBox_0.SelectedValue);
					this.method_4(this.int_1);
					goto IL_66;
				}
			}
			this.textBox_1.Text = (this.textBox_2.Text = "");
			this.int_1 = -1;
			IL_66:
			this.bool_0 = true;
		}

		private void method_4(int int_5)
		{
			Class10.Class12 @class = new Class10.Class12();
			base.SelectSqlData(@class, true, " where id = " + int_5.ToString(), null, false, 0);
			if (@class.Rows.Count > 0)
			{
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
				if (num2 == -1)
				{
					this.int_3 = -1;
					this.int_2 = -1;
					this.textBox_2.Text = (this.textBox_1.Text = "");
					return;
				}
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
					if (class5.Rows.Count <= 0)
					{
						this.textBox_2.Text = (this.textBox_1.Text = "");
						return;
					}
					this.textBox_2.Text = class5.Rows[0]["name"].ToString();
					int num3 = Convert.ToInt32(class5.Rows[0]["typeAbn"]);
					if (class4.Rows[0]["idAbnObj"] == DBNull.Value)
					{
						this.textBox_1.Text = "";
						return;
					}
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
								this.textBox_1.Text = class6.Rows[0]["name"].ToString();
								return;
							}
						}
						this.textBox_1.Text = class6.Rows[0]["AddressFL"].ToString();
						return;
					}
					this.textBox_1.Text = "";
					return;
				}
			}
			else
			{
				this.int_3 = -1;
				this.int_2 = -1;
				this.textBox_2.Text = (this.textBox_1.Text = "");
			}
		}

		private void method_5(object object_0, object object_1)
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
						this.textBox_1.Text = "";
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
								this.textBox_1.Text = class2.Rows[0]["name"].ToString();
								return;
							}
						}
						this.textBox_1.Text = class2.Rows[0]["AddressFL"].ToString();
						return;
					}
					this.textBox_1.Text = "";
					return;
				}
				else
				{
					this.textBox_2.Text = (this.textBox_1.Text = "");
				}
			}
		}

		private void textBox_0_TextChanged(object sender, EventArgs e)
		{
			this.bool_0 = true;
		}

		private void nullableDateTimePicker_0_ValueChanged(object sender, EventArgs e)
		{
			this.bool_0 = true;
		}

		private void textBox_3_TextChanged(object sender, EventArgs e)
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

		private bool method_6()
		{
			if (this.comboBox_0.SelectedIndex < 0)
			{
				MessageBox.Show("Не выбрано техническое условие");
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
			}
			else if (!base.UpdateSqlData(this.class10_0, this.class10_0.tTC_Doc))
			{
				return false;
			}
			base.SelectSqlData(this.class10_0, this.class10_0.tTC_Doc, true, "where id = " + this.int_0.ToString());
			if (!this.method_7())
			{
				return false;
			}
			if (!this.method_17())
			{
				return false;
			}
			this.bool_0 = false;
			return true;
		}

		private bool method_7()
		{
			if (this.int_0 == -1)
			{
				return false;
			}
			if (this.class10_0.tTC_ElectricalInspection.Rows.Count == 0)
			{
				DataRow dataRow = this.class10_0.tTC_ElectricalInspection.NewRow();
				dataRow["id"] = this.int_0;
				if (this.comboBox_1.SelectedIndex >= 0)
				{
					dataRow["idWorker"] = this.comboBox_1.SelectedValue;
				}
				dataRow["DateRecipient"] = this.dateTimePicker_0.Value;
				XmlDocument xmlDocument = this.CreateXmlConfig();
				if (xmlDocument != null)
				{
					dataRow["Mail"] = xmlDocument.InnerXml;
				}
				XmlDocument xmlDocument2 = this.method_22();
				if (xmlDocument2 != null)
				{
					dataRow["Officials"] = xmlDocument2.InnerXml;
				}
				this.class10_0.tTC_ElectricalInspection.Rows.Add(dataRow);
				if (!base.InsertSqlData(this.class10_0.tTC_ElectricalInspection))
				{
					return false;
				}
				this.class10_0.tTC_ElectricalInspection.AcceptChanges();
			}
			else
			{
				this.class10_0.tTC_ElectricalInspection.Rows[0]["id"] = this.int_0;
				XmlDocument xmlDocument3 = this.CreateXmlConfig();
				if (xmlDocument3 != null)
				{
					this.class10_0.tTC_ElectricalInspection.Rows[0]["Mail"] = xmlDocument3.InnerXml;
				}
				XmlDocument xmlDocument4 = this.method_22();
				if (xmlDocument4 != null)
				{
					this.class10_0.tTC_ElectricalInspection.Rows[0]["Officials"] = xmlDocument4.InnerXml;
				}
				this.class10_0.tTC_ElectricalInspection.Rows[0].EndEdit();
				if (!base.UpdateSqlData(this.class10_0.tTC_ElectricalInspection))
				{
					return false;
				}
				this.class10_0.tTC_ElectricalInspection.AcceptChanges();
			}
			return true;
		}

		private void button_1_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void button_0_Click(object sender, EventArgs e)
		{
			if (this.method_6())
			{
				bool flag = false;
				for (int i = 0; i < this.dataGridView_0.Rows.Count - 1; i++)
				{
					if (!Convert.ToBoolean(this.dataGridView_0.Rows[i].Cells[this.dataGridViewCheckBoxColumn_0.Name].Value))
					{
						flag = true;
						IL_5D:
						if (flag && MessageBox.Show("Данные успешно сохранены.\r\nОтправить документ выбранным адресатам?", "Отправка почты", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
						{
							this.method_19(true);
						}
						base.Close();
						return;
					}
				}
				goto IL_5D;
			}
		}

		private void method_8()
		{
			foreach (object obj in new SqlDataCommand(this.SqlSettings).SelectSqlData(" SELECT doc.id, doc.FileName  FROM tR_DocTemplate AS doc  INNER JOIN [tR_Classifier] AS c ON doc.idTypeDoc = c.id  WHERE c.ParentKey = ';TypeDoc;tR_DocTemplate;' AND c.Deleted = ((0)) AND c.isGroup = ((0)) AND c.Value = 1 and doc.deleted = 0").Rows)
			{
				DataRow dataRow = (DataRow)obj;
				ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
				toolStripMenuItem.Text = dataRow["FileName"].ToString();
				toolStripMenuItem.Tag = dataRow["id"];
				toolStripMenuItem.Click += this.method_10;
				this.toolStripDropDownButton_0.DropDownItems.Add(toolStripMenuItem);
				ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem();
				toolStripMenuItem2.Text = dataRow["FileName"].ToString();
				toolStripMenuItem2.Tag = dataRow["id"];
				toolStripMenuItem2.Click += this.method_10;
				this.toolStripMenuItem_1.DropDownItems.Add(toolStripMenuItem2);
			}
		}

		private string method_9(string string_1, int? nullable_0 = null, byte[] byte_1 = null)
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
					if (byte_1 == null)
					{
						FileBinary fileBinary = new FileBinary(string_1);
						@class.File = fileBinary.ByteArray;
						@class.dateChange = fileBinary.LastChanged;
					}
					else
					{
						@class.File = byte_1;
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

		private void toolStripMenuItem_2_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Multiselect = true;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				foreach (string string_ in openFileDialog.FileNames)
				{
					if (!string.IsNullOrEmpty(this.method_9(string_, null, null)))
					{
						this.bool_0 = true;
					}
				}
			}
		}

		private void method_10(object sender, EventArgs e)
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
			string text2 = this.method_15();
			string newFileNameIsExists = FileBinary.GetNewFileNameIsExists(text2, text, false);
			string text3 = this.method_9(text, new int?(num), array);
			if (!string.IsNullOrEmpty(text3))
			{
				this.bool_0 = true;
				FileBinary fileBinary = new FileBinary(array, newFileNameIsExists, DateTime.Now);
				fileBinary.SaveToDisk(text2);
				extension = new System.IO.FileInfo(text).Extension;
				Process.Start(text2 + "\\" + fileBinary.Name);
				if (this.dictionary_0.ContainsKey(text3))
				{
					FileWatcher fileWatcher = new FileWatcher(text2, fileBinary.Name);
					fileWatcher.AnyChanged += this.method_12;
					fileWatcher.Start();
					this.dictionary_0[text3].TempName = newFileNameIsExists;
					this.dictionary_0[text3].Watcher = fileWatcher;
					this.dictionary_0[text3].OpenState = FileOpenState.Editing;
					return;
				}
				MessageBox.Show("Что то пошло не так");
			}
		}

		private void toolStripMenuItem_3_Click(object sender, EventArgs e)
		{
			this.method_11(true);
		}

		private void toolStripMenuItem_4_Click(object sender, EventArgs e)
		{
			this.method_11(false);
		}

		private void toolStripMenuItem_5_Click(object sender, EventArgs e)
		{
			if (this.bindingSource_0.Current != null && MessageBox.Show("Вы действительно хотите удалить выбранный файл?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				Class10.Class88 @class = (Class10.Class88)((DataRowView)this.bindingSource_0.Current).Row;
				string fileName = @class.FileName;
				if (this.dictionary_0.ContainsKey(fileName))
				{
					if (this.dictionary_0[fileName].Watcher != null)
					{
						this.dictionary_0[fileName].Watcher.AnyChanged -= this.method_12;
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
			if (this.dataGridViewExcelFilter_0.CurrentRow != null)
			{
				this.string_0 = this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewFilterTextBoxColumn_0.Name].Value.ToString();
				this.dataGridViewExcelFilter_0.CurrentCell = this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewFilterTextBoxColumn_0.Name];
				this.dataGridViewExcelFilter_0.CurrentCell.Value = Path.GetFileNameWithoutExtension(this.string_0);
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

		private void method_11(bool bool_1 = false)
		{
			if (this.bindingSource_0.Current != null)
			{
				Class10.Class88 @class = (Class10.Class88)((DataRowView)this.bindingSource_0.Current).Row;
				string fileName = @class.FileName;
				string text = this.method_15();
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
							fileWatcher.AnyChanged += this.method_12;
							fileWatcher.Start();
							this.dictionary_0[fileName].Watcher = fileWatcher;
						}
						else
						{
							this.dictionary_0[fileName].Watcher.AnyChanged -= this.method_12;
							this.dictionary_0[fileName].Watcher.Stop();
							FileWatcher fileWatcher2 = new FileWatcher(text, newFileNameIsExists);
							fileWatcher2.AnyChanged += this.method_12;
							fileWatcher2.Start();
							this.dictionary_0[fileName].Watcher = fileWatcher2;
						}
						this.dictionary_0[fileName].TempName = newFileNameIsExists;
						this.dictionary_0[fileName].OpenState = FileOpenState.Editing;
						return;
					}
					FileWatcher fileWatcher3 = new FileWatcher(text, newFileNameIsExists);
					fileWatcher3.AnyChanged += this.method_12;
					fileWatcher3.Start();
					FileWatcherArgsAddl value = new FileWatcherArgsAddl(idTemplate, fileName, newFileNameIsExists, fileWatcher3, FileOpenState.Editing);
					this.dictionary_0.Add(fileName, value);
				}
			}
		}

		private void method_12(object sender, FileSystemEventArgs e)
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
			this.method_14();
		}

		private bool method_13(string string_1)
		{
			return (from row in this.class10_0.tTC_DocFile
			where row.FileName == string_1
			select row).Count<Class10.Class88>() > 0;
		}

		private void method_14()
		{
			if (base.InvokeRequired)
			{
				base.Invoke(new Action(this.method_24));
				return;
			}
			this.bindingSource_0.ResetBindings(false);
		}

		private string method_15()
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

		private void method_16(int int_5)
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
						this.dictionary_0.Add(sqlDataReader["FileName"].ToString(), value);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, ex.Source);
			}
		}

		private bool method_17()
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
			string text = this.dataGridViewExcelFilter_0[e.ColumnIndex, e.RowIndex].Value.ToString() + Path.GetExtension(this.string_0);
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
				this.dataGridViewExcelFilter_0[e.ColumnIndex, e.RowIndex].Value = text;
				this.bool_0 = true;
			}
			this.string_0 = null;
		}

		private void dataGridViewExcelFilter_0_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
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

		private void dataGridView_0_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
		{
			if (e.Control is ComboBox)
			{
				(e.Control as ComboBox).AutoCompleteMode = AutoCompleteMode.SuggestAppend;
				(e.Control as ComboBox).AutoCompleteSource = AutoCompleteSource.ListItems;
				BindingSource bindingSource = (BindingSource)(e.Control as ComboBox).DataSource;
				if (bindingSource != null)
				{
					bindingSource.Filter = "";
					string text = "";
					foreach (object obj in ((IEnumerable)this.dataGridView_0.Rows))
					{
						DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
						if ((this.dataGridView_0.CurrentCell == null || this.dataGridView_0.CurrentCell.RowIndex != dataGridViewRow.Index) && dataGridViewRow.Cells[this.dataGridViewComboBoxColumn_0.Name].Value != null)
						{
							text = text + dataGridViewRow.Cells[this.dataGridViewComboBoxColumn_0.Name].Value.ToString() + ",";
						}
					}
					if (text.Length > 0)
					{
						bindingSource.Filter = "id not in (" + text.Remove(text.Length - 1) + ")";
					}
					if (this.dataGridView_0.CurrentCell != null && this.dataGridView_0.CurrentCell.Value != null)
					{
						(e.Control as ComboBox).SelectedValue = this.dataGridView_0.CurrentCell.Value;
					}
				}
				(e.Control as ComboBox).SelectedValueChanged -= this.method_18;
				(e.Control as ComboBox).SelectedValueChanged += this.method_18;
			}
		}

		private void method_18(object sender, EventArgs e)
		{
			if (this.dataGridView_0.CurrentCell != null && ((ComboBox)sender).SelectedValue != null && ((ComboBox)sender).SelectedValue.GetType() != typeof(DataRowView))
			{
				DataTable dataTable = base.SelectSqlData("tR_WorkerContact", true, "where Worker = " + Convert.ToInt32(((ComboBox)sender).SelectedValue).ToString() + " and Type = 44");
				if (dataTable.Rows.Count > 0 && dataTable.Rows[0]["Description"] != DBNull.Value)
				{
					this.dataGridView_0[this.dataGridViewTextBoxColumn_9.Name, this.dataGridView_0.CurrentCell.RowIndex].Value = dataTable.Rows[0]["Description"].ToString();
				}
				else
				{
					this.dataGridView_0[this.dataGridViewTextBoxColumn_9.Name, this.dataGridView_0.CurrentCell.RowIndex].Value = "адрес не задан";
				}
				this.dataGridView_0[this.dataGridViewCheckBoxColumn_0.Name, this.dataGridView_0.CurrentCell.RowIndex].Value = false;
				this.bool_0 = true;
			}
		}

		private void dataGridView_0_DataError(object sender, DataGridViewDataErrorEventArgs e)
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

		private void dataGridView_0_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
		{
			for (int i = 0; i < e.RowCount; i++)
			{
				DataGridViewComboBoxCell dataGridViewComboBoxCell = (DataGridViewComboBoxCell)this.dataGridView_0[this.dataGridViewComboBoxColumn_0.Name, e.RowIndex + i];
				if (!string.IsNullOrEmpty(this.SqlSettings.ServerDB))
				{
					DataTable dataTable = new DataTable("vR_worker");
					dataTable.Columns.Add(new DataColumn("id", typeof(int)));
					dataTable.Columns.Add(new DataColumn("fio", typeof(string)));
					BindingSource bindingSource = new BindingSource();
					bindingSource.DataSource = dataTable;
					base.SelectSqlData(dataTable, true, "where dateEnd is null order by fio", null, false, 0);
					dataGridViewComboBoxCell.DisplayMember = "FIO";
					dataGridViewComboBoxCell.ValueMember = "id";
					dataGridViewComboBoxCell.DataSource = bindingSource;
				}
				this.bool_0 = true;
			}
		}

		private void dataGridView_0_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
		{
			this.bool_0 = true;
		}

		protected override XmlDocument CreateXmlConfig()
		{
			XmlDocument xmlDocument = new XmlDocument();
			XmlNode xmlNode = xmlDocument.CreateElement(base.Name);
			xmlDocument.AppendChild(xmlNode);
			XmlNode xmlNode2 = xmlDocument.CreateElement("Mail");
			xmlNode.AppendChild(xmlNode2);
			XmlAttribute xmlAttribute = xmlDocument.CreateAttribute("Subject");
			xmlAttribute.Value = this.textBox_10.Text;
			xmlNode2.Attributes.Append(xmlAttribute);
			XmlNode xmlNode3 = xmlDocument.CreateElement("SMTP");
			xmlNode2.AppendChild(xmlNode3);
			xmlAttribute = xmlDocument.CreateAttribute("Name");
			xmlAttribute.Value = this.textBox_9.Text;
			xmlNode3.Attributes.Append(xmlAttribute);
			xmlAttribute = xmlDocument.CreateAttribute("Port");
			xmlAttribute.Value = this.textBox_8.Text;
			xmlNode3.Attributes.Append(xmlAttribute);
			xmlAttribute = xmlDocument.CreateAttribute("Login");
			xmlAttribute.Value = this.textBox_5.Text;
			xmlNode3.Attributes.Append(xmlAttribute);
			xmlAttribute = xmlDocument.CreateAttribute("Password");
			xmlAttribute.Value = FormActElectricalInspection.smethod_0(this.textBox_6.Text);
			xmlNode3.Attributes.Append(xmlAttribute);
			XmlNode xmlNode4 = xmlDocument.CreateElement("Sender");
			xmlNode2.AppendChild(xmlNode4);
			xmlAttribute = xmlDocument.CreateAttribute("Address");
			xmlAttribute.Value = this.textBox_4.Text;
			xmlNode4.Attributes.Append(xmlAttribute);
			xmlAttribute = xmlDocument.CreateAttribute("Name");
			xmlAttribute.Value = this.textBox_7.Text;
			xmlNode4.Attributes.Append(xmlAttribute);
			XmlNode xmlNode5 = xmlDocument.CreateElement("Recipients");
			xmlNode2.AppendChild(xmlNode5);
			for (int i = 0; i < this.dataGridView_0.Rows.Count - 1; i++)
			{
				XmlNode xmlNode6 = xmlDocument.CreateElement("Recipient");
				xmlNode5.AppendChild(xmlNode6);
				xmlAttribute = xmlDocument.CreateAttribute("Address");
				if (this.dataGridView_0[this.dataGridViewTextBoxColumn_9.Name, i].Value == null)
				{
					xmlAttribute.Value = "";
				}
				else
				{
					xmlAttribute.Value = this.dataGridView_0[this.dataGridViewTextBoxColumn_9.Name, i].Value.ToString();
				}
				xmlNode6.Attributes.Append(xmlAttribute);
				xmlAttribute = xmlDocument.CreateAttribute("Name");
				xmlAttribute.Value = this.dataGridView_0[this.dataGridViewComboBoxColumn_0.Name, i].Value.ToString();
				xmlNode6.Attributes.Append(xmlAttribute);
				xmlAttribute = xmlDocument.CreateAttribute("IsSend");
				if (this.dataGridView_0[this.dataGridViewCheckBoxColumn_0.Name, i].Value != null && Convert.ToBoolean(this.dataGridView_0[this.dataGridViewCheckBoxColumn_0.Name, i].Value))
				{
					xmlAttribute.Value = true.ToString();
				}
				else
				{
					xmlAttribute.Value = false.ToString();
				}
				xmlNode6.Attributes.Append(xmlAttribute);
			}
			return xmlDocument;
		}

		protected override void ApplyConfig(XmlDocument doc)
		{
			this.dataGridView_0.Rows.Clear();
			XmlNode xmlNode = doc.SelectSingleNode(base.Name);
			if (xmlNode != null)
			{
				XmlNode xmlNode2 = xmlNode.SelectSingleNode("Mail");
				if (xmlNode2 == null)
				{
					return;
				}
				XmlAttribute xmlAttribute = xmlNode2.Attributes["Subject"];
				if (xmlAttribute != null)
				{
					this.textBox_10.Text = xmlAttribute.Value;
				}
				XmlNode xmlNode3 = xmlNode2.SelectSingleNode("SMTP");
				if (xmlNode3 == null)
				{
					return;
				}
				xmlAttribute = xmlNode3.Attributes["Name"];
				if (xmlAttribute != null)
				{
					this.textBox_9.Text = xmlAttribute.Value;
				}
				xmlAttribute = xmlNode3.Attributes["Port"];
				if (xmlAttribute != null)
				{
					this.textBox_8.Text = xmlAttribute.Value;
				}
				xmlAttribute = xmlNode3.Attributes["Login"];
				if (xmlAttribute != null)
				{
					this.textBox_5.Text = xmlAttribute.Value;
				}
				xmlAttribute = xmlNode3.Attributes["Password"];
				if (xmlAttribute != null)
				{
					this.textBox_6.Text = FormActElectricalInspection.hgOouuWdOmE(xmlAttribute.Value);
				}
				XmlNode xmlNode4 = xmlNode2.SelectSingleNode("Sender");
				if (xmlNode4 == null)
				{
					return;
				}
				xmlAttribute = xmlNode4.Attributes["Address"];
				if (xmlAttribute != null)
				{
					this.textBox_4.Text = xmlAttribute.Value;
				}
				xmlAttribute = xmlNode4.Attributes["Name"];
				if (xmlAttribute != null)
				{
					this.textBox_7.Text = xmlAttribute.Value;
				}
				XmlNode xmlNode5 = xmlNode2.SelectSingleNode("Recipients");
				if (xmlNode5 == null)
				{
					return;
				}
				XmlNodeList xmlNodeList = xmlNode5.SelectNodes("Recipient");
				if (xmlNodeList != null)
				{
					foreach (object obj in xmlNodeList)
					{
						XmlNode xmlNode6 = (XmlNode)obj;
						object value = -1;
						object value2 = "";
						xmlAttribute = xmlNode6.Attributes["Address"];
						if (xmlAttribute != null)
						{
							value2 = xmlAttribute.Value;
						}
						xmlAttribute = xmlNode6.Attributes["Name"];
						if (xmlAttribute != null)
						{
							value = xmlAttribute.Value;
						}
						bool flag = false;
						xmlAttribute = xmlNode6.Attributes["IsSend"];
						if (xmlAttribute != null)
						{
							flag = Convert.ToBoolean(xmlAttribute.Value);
						}
						this.dataGridView_0.Rows.Add(1);
						this.dataGridView_0.Rows[this.dataGridView_0.Rows.Count - 2].Cells[this.dataGridViewComboBoxColumn_0.Name].Value = Convert.ToInt32(value);
						this.dataGridView_0.Rows[this.dataGridView_0.Rows.Count - 2].Cells[this.dataGridViewTextBoxColumn_9.Name].Value = value2;
						this.dataGridView_0.Rows[this.dataGridView_0.Rows.Count - 2].Cells[this.dataGridViewCheckBoxColumn_0.Name].Value = flag;
					}
				}
			}
		}

		private static string smethod_0(string string_1)
		{
			if (string.IsNullOrEmpty(string_1))
			{
				return "";
			}
			DESCryptoServiceProvider descryptoServiceProvider = new DESCryptoServiceProvider();
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, descryptoServiceProvider.CreateEncryptor(FormActElectricalInspection.byte_0, FormActElectricalInspection.byte_0), CryptoStreamMode.Write);
			StreamWriter streamWriter = new StreamWriter(cryptoStream);
			streamWriter.Write(string_1);
			streamWriter.Flush();
			cryptoStream.FlushFinalBlock();
			streamWriter.Flush();
			return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
		}

		private static string hgOouuWdOmE(string string_1)
		{
			if (string.IsNullOrEmpty(string_1))
			{
				return "";
			}
			DESCryptoServiceProvider descryptoServiceProvider = new DESCryptoServiceProvider();
			return new StreamReader(new CryptoStream(new MemoryStream(Convert.FromBase64String(string_1)), descryptoServiceProvider.CreateDecryptor(FormActElectricalInspection.byte_0, FormActElectricalInspection.byte_0), CryptoStreamMode.Read)).ReadToEnd();
		}

		private void method_19(bool bool_1 = false)
		{
			if (this.dataGridView_0.Rows.Count > 0)
			{
				string text = "Сформирован акт осмотра электроустановок №" + this.textBox_0.Text + " от " + Convert.ToDateTime(this.nullableDateTimePicker_0.Value).ToString("dd.MM.yyyy");
				if (this.comboBox_0.SelectedValue != null)
				{
					try
					{
						DataTable dataTable = base.SelectSqlData("ttc_doc", true, "where id = " + this.comboBox_0.SelectedValue.ToString());
						if (dataTable.Rows.Count > 0)
						{
							text = string.Concat(new string[]
							{
								text,
								" по техническим условиям №",
								dataTable.Rows[0]["numdoc"].ToString(),
								" от ",
								Convert.ToDateTime(dataTable.Rows[0]["datedoc"]).ToString("dd.MM.yyyy")
							});
						}
					}
					catch
					{
					}
				}
				text = text + "\r\n\r\n Крайняя дата осмотра - " + this.dateTimePicker_0.Value.ToString("dd.MM.yyyy");
				for (int i = 0; i < this.dataGridView_0.Rows.Count - 1; i++)
				{
					if (!bool_1 || !Convert.ToBoolean(this.dataGridView_0[this.dataGridViewCheckBoxColumn_0.Name, i].Value))
					{
						List<Struct6> list = new List<Struct6>();
						list.Add(new Struct6(this.dataGridView_0[this.dataGridViewTextBoxColumn_9.Name, i].Value.ToString(), this.dataGridView_0[this.dataGridViewComboBoxColumn_0.Name, i].FormattedValue.ToString()));
						if (Class129.smethod_13(this.textBox_9.Text, Convert.ToInt32(this.textBox_8.Text), this.textBox_5.Text, this.textBox_6.Text, this.textBox_4.Text, this.textBox_7.Text, list, this.textBox_10.Text, text, null, false))
						{
							this.dataGridView_0[this.dataGridViewCheckBoxColumn_0.Name, i].Value = true;
						}
						else
						{
							this.dataGridView_0[this.dataGridViewCheckBoxColumn_0.Name, i].Value = false;
						}
					}
				}
			}
			if (this.method_7())
			{
				this.bool_0 = false;
			}
		}

		private void button_2_Click(object sender, EventArgs e)
		{
			DialogResult dialogResult = MessageBox.Show("Пропустить адресатов, которым уже отправлено данное сообщение?", "Отправка почты", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
			if (dialogResult == DialogResult.Cancel)
			{
				return;
			}
			bool bool_ = false;
			if (dialogResult == DialogResult.Yes)
			{
				bool_ = true;
			}
			if (!this.bool_0)
			{
				if (this.int_0 != -1)
				{
					this.method_19(bool_);
					return;
				}
			}
			if (MessageBox.Show("Перед отправкой необходимо сохранить документа. Сохранить?", "Сохранение", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK && this.method_6())
			{
				this.method_19(bool_);
				return;
			}
		}

		private void textBox_9_TextChanged(object sender, EventArgs e)
		{
			this.bool_0 = true;
		}

		private void textBox_8_TextChanged(object sender, EventArgs e)
		{
			this.bool_0 = true;
		}

		private void textBox_5_TextChanged(object sender, EventArgs e)
		{
			this.bool_0 = true;
		}

		private void textBox_6_TextChanged(object sender, EventArgs e)
		{
			this.bool_0 = true;
		}

		private void textBox_4_TextChanged(object sender, EventArgs e)
		{
			this.bool_0 = true;
		}

		private void textBox_7_TextChanged(object sender, EventArgs e)
		{
			this.bool_0 = true;
		}

		private void dateTimePicker_0_ValueChanged(object sender, EventArgs e)
		{
			this.bool_0 = true;
		}

		private void textBox_11_TextChanged(object sender, EventArgs e)
		{
			this.bool_0 = true;
		}

		private void fseouXlYtQN(object sender, EventArgs e)
		{
			this.bool_0 = true;
		}

		private void textBox_14_TextChanged(object sender, EventArgs e)
		{
			this.bool_0 = true;
		}

		private void textBox_29_TextChanged(object sender, EventArgs e)
		{
			this.bool_0 = true;
		}

		private void comboBox_5_TextChanged(object sender, EventArgs e)
		{
			this.bool_0 = true;
		}

		private void method_20()
		{
			DataTable dataTable = new DataTable("tR_Worker");
			dataTable.Columns.Add("id", typeof(int));
			dataTable.Columns.Add("F", typeof(string));
			dataTable.Columns.Add("I", typeof(string));
			dataTable.Columns.Add("O", typeof(string));
			dataTable.Columns.Add("FIO", typeof(string), "F + ' ' + I + ' ' + O");
			this.comboBox_5.DisplayMember = "FIO";
			this.comboBox_5.ValueMember = "id";
			this.comboBox_5.DataSource = dataTable;
			base.SelectSqlData(dataTable, true, " where dateEnd is null order by F, I, O", null, false, 0);
			this.comboBox_5.SelectedIndex = -1;
			dataTable = new DataTable("tR_Worker");
			dataTable.Columns.Add("id", typeof(int));
			dataTable.Columns.Add("F", typeof(string));
			dataTable.Columns.Add("I", typeof(string));
			dataTable.Columns.Add("O", typeof(string));
			dataTable.Columns.Add("FIO", typeof(string), "F + ' ' + I + ' ' + O");
			this.comboBox_4.DisplayMember = "FIO";
			this.comboBox_4.ValueMember = "id";
			this.comboBox_4.DataSource = dataTable;
			base.SelectSqlData(dataTable, true, " where dateEnd is null order by F, I, O", null, false, 0);
			this.comboBox_4.SelectedIndex = -1;
			dataTable = new DataTable("tR_Worker");
			dataTable.Columns.Add("id", typeof(int));
			dataTable.Columns.Add("F", typeof(string));
			dataTable.Columns.Add("I", typeof(string));
			dataTable.Columns.Add("O", typeof(string));
			dataTable.Columns.Add("FIO", typeof(string), "F + ' ' + I + ' ' + O");
			this.comboBox_3.DisplayMember = "FIO";
			this.comboBox_3.ValueMember = "id";
			this.comboBox_3.DataSource = dataTable;
			base.SelectSqlData(dataTable, true, " where dateEnd is null order by F, I, O", null, false, 0);
			this.comboBox_3.SelectedIndex = -1;
			dataTable = new DataTable("tR_Worker");
			dataTable.Columns.Add("id", typeof(int));
			dataTable.Columns.Add("F", typeof(string));
			dataTable.Columns.Add("I", typeof(string));
			dataTable.Columns.Add("O", typeof(string));
			dataTable.Columns.Add("FIO", typeof(string), "F + ' ' + I + ' ' + O");
			this.comboBox_2.DisplayMember = "FIO";
			this.comboBox_2.ValueMember = "id";
			this.comboBox_2.DataSource = dataTable;
			base.SelectSqlData(dataTable, true, " where dateEnd is null order by F, I, O", null, false, 0);
			this.comboBox_2.SelectedIndex = -1;
		}

		private void comboBox_5_SelectedValueChanged(object sender, EventArgs e)
		{
			ComboBox comboBox = (ComboBox)sender;
			if (comboBox.SelectedIndex >= 0 && comboBox.SelectedValue != null)
			{
				DataTable dataTable = base.SelectSqlData("tr_Worker", true, "where id = " + comboBox.SelectedValue.ToString());
				if (dataTable.Rows.Count > 0 && dataTable.Rows[0]["JobTitle"] != DBNull.Value)
				{
					DataTable dataTable2 = base.SelectSqlData("tr_jobtitle", true, " where id = " + dataTable.Rows[0]["JobTitle"].ToString());
					if (dataTable2.Rows.Count > 0 && dataTable2.Rows[0]["Description"] != DBNull.Value)
					{
						this.textBox_21.Text = dataTable2.Rows[0]["Description"].ToString();
					}
				}
			}
		}

		private void jMnoueSwlPi(object sender, EventArgs e)
		{
			ComboBox comboBox = (ComboBox)sender;
			if (comboBox.SelectedIndex >= 0 && comboBox.SelectedValue != null)
			{
				DataTable dataTable = base.SelectSqlData("tr_Worker", true, "where id = " + comboBox.SelectedValue.ToString());
				if (dataTable.Rows.Count > 0 && dataTable.Rows[0]["JobTitle"] != DBNull.Value)
				{
					DataTable dataTable2 = base.SelectSqlData("tr_jobtitle", true, " where id = " + dataTable.Rows[0]["JobTitle"].ToString());
					if (dataTable2.Rows.Count > 0 && dataTable2.Rows[0]["Description"] != DBNull.Value)
					{
						this.textBox_20.Text = dataTable2.Rows[0]["Description"].ToString();
					}
				}
			}
		}

		private void comboBox_3_SelectedValueChanged(object sender, EventArgs e)
		{
			ComboBox comboBox = (ComboBox)sender;
			if (comboBox.SelectedIndex >= 0 && comboBox.SelectedValue != null)
			{
				DataTable dataTable = base.SelectSqlData("tr_Worker", true, "where id = " + comboBox.SelectedValue.ToString());
				if (dataTable.Rows.Count > 0 && dataTable.Rows[0]["JobTitle"] != DBNull.Value)
				{
					DataTable dataTable2 = base.SelectSqlData("tr_jobtitle", true, " where id = " + dataTable.Rows[0]["JobTitle"].ToString());
					if (dataTable2.Rows.Count > 0 && dataTable2.Rows[0]["Description"] != DBNull.Value)
					{
						this.textBox_19.Text = dataTable2.Rows[0]["Description"].ToString();
					}
				}
			}
		}

		private void comboBox_2_SelectedValueChanged(object sender, EventArgs e)
		{
			ComboBox comboBox = (ComboBox)sender;
			if (comboBox.SelectedIndex >= 0 && comboBox.SelectedValue != null)
			{
				DataTable dataTable = base.SelectSqlData("tr_Worker", true, "where id = " + comboBox.SelectedValue.ToString());
				if (dataTable.Rows.Count > 0 && dataTable.Rows[0]["JobTitle"] != DBNull.Value)
				{
					DataTable dataTable2 = base.SelectSqlData("tr_jobtitle", true, " where id = " + dataTable.Rows[0]["JobTitle"].ToString());
					if (dataTable2.Rows.Count > 0 && dataTable2.Rows[0]["Description"] != DBNull.Value)
					{
						this.textBox_18.Text = dataTable2.Rows[0]["Description"].ToString();
					}
				}
			}
		}

		private void method_21()
		{
			if (this.class10_0.tTC_ElectricalInspection.Rows.Count > 0 && this.class10_0.tTC_ElectricalInspection.Rows[0]["Officials"] != DBNull.Value)
			{
				try
				{
					XmlDocument xmlDocument = new XmlDocument();
					xmlDocument.LoadXml(this.class10_0.tTC_ElectricalInspection.Rows[0]["Officials"].ToString());
					XmlNode xmlNode = xmlDocument.SelectSingleNode("Official");
					if (xmlNode != null)
					{
						XmlNode xmlNode2 = xmlNode.SelectSingleNode("Seti");
						if (xmlNode2 != null)
						{
							XmlNode xmlNode3 = xmlNode2.SelectSingleNode("FIO1");
							if (xmlNode3 != null)
							{
								XmlAttribute xmlAttribute = xmlNode3.Attributes["FIO"];
								if (xmlAttribute != null)
								{
									this.comboBox_5.Text = xmlAttribute.Value;
								}
								xmlAttribute = xmlNode3.Attributes["JobTitle"];
								if (xmlAttribute != null)
								{
									this.textBox_21.Text = xmlAttribute.Value;
								}
							}
							XmlNode xmlNode4 = xmlNode2.SelectSingleNode("FIO2");
							if (xmlNode4 != null)
							{
								XmlAttribute xmlAttribute2 = xmlNode4.Attributes["FIO"];
								if (xmlAttribute2 != null)
								{
									this.comboBox_4.Text = xmlAttribute2.Value;
								}
								xmlAttribute2 = xmlNode4.Attributes["JobTitle"];
								if (xmlAttribute2 != null)
								{
									this.textBox_20.Text = xmlAttribute2.Value;
								}
							}
							XmlNode xmlNode5 = xmlNode2.SelectSingleNode("FIO3");
							if (xmlNode5 != null)
							{
								XmlAttribute xmlAttribute3 = xmlNode5.Attributes["FIO"];
								if (xmlAttribute3 != null)
								{
									this.comboBox_3.Text = xmlAttribute3.Value;
								}
								xmlAttribute3 = xmlNode5.Attributes["JobTitle"];
								if (xmlAttribute3 != null)
								{
									this.textBox_19.Text = xmlAttribute3.Value;
								}
							}
							XmlNode xmlNode6 = xmlNode2.SelectSingleNode("Official");
							if (xmlNode6 != null)
							{
								XmlAttribute xmlAttribute4 = xmlNode6.Attributes["FIO"];
								if (xmlAttribute4 != null)
								{
									this.comboBox_2.Text = xmlAttribute4.Value;
								}
								xmlAttribute4 = xmlNode6.Attributes["JobTitle"];
								if (xmlAttribute4 != null)
								{
									this.textBox_18.Text = xmlAttribute4.Value;
								}
							}
						}
						XmlNode xmlNode7 = xmlNode.SelectSingleNode("Declarer");
						if (xmlNode7 != null)
						{
							XmlNode xmlNode8 = xmlNode7.SelectSingleNode("FIO1");
							if (xmlNode8 != null)
							{
								XmlAttribute xmlAttribute5 = xmlNode8.Attributes["FIO"];
								if (xmlAttribute5 != null)
								{
									this.textBox_28.Text = xmlAttribute5.Value;
								}
								xmlAttribute5 = xmlNode8.Attributes["JobTitle"];
								if (xmlAttribute5 != null)
								{
									this.textBox_29.Text = xmlAttribute5.Value;
								}
							}
							xmlNode8 = xmlNode7.SelectSingleNode("FIO2");
							if (xmlNode8 != null)
							{
								XmlAttribute xmlAttribute6 = xmlNode8.Attributes["FIO"];
								if (xmlAttribute6 != null)
								{
									this.textBox_26.Text = xmlAttribute6.Value;
								}
								xmlAttribute6 = xmlNode8.Attributes["JobTitle"];
								if (xmlAttribute6 != null)
								{
									this.textBox_27.Text = xmlAttribute6.Value;
								}
							}
							xmlNode8 = xmlNode7.SelectSingleNode("FIO3");
							if (xmlNode8 != null)
							{
								XmlAttribute xmlAttribute7 = xmlNode8.Attributes["FIO"];
								if (xmlAttribute7 != null)
								{
									this.textBox_24.Text = xmlAttribute7.Value;
								}
								xmlAttribute7 = xmlNode8.Attributes["JobTitle"];
								if (xmlAttribute7 != null)
								{
									this.textBox_25.Text = xmlAttribute7.Value;
								}
							}
							xmlNode8 = xmlNode7.SelectSingleNode("FIO4");
							if (xmlNode8 != null)
							{
								XmlAttribute xmlAttribute8 = xmlNode8.Attributes["FIO"];
								if (xmlAttribute8 != null)
								{
									this.textBox_22.Text = xmlAttribute8.Value;
								}
								xmlAttribute8 = xmlNode8.Attributes["JobTitle"];
								if (xmlAttribute8 != null)
								{
									this.textBox_23.Text = xmlAttribute8.Value;
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

		private XmlDocument method_22()
		{
			XmlDocument xmlDocument = new XmlDocument();
			XmlNode xmlNode = xmlDocument.CreateElement("Official");
			xmlDocument.AppendChild(xmlNode);
			XmlNode xmlNode2 = xmlDocument.CreateElement("Seti");
			xmlNode.AppendChild(xmlNode2);
			XmlNode xmlNode3 = xmlDocument.CreateElement("FIO1");
			xmlNode2.AppendChild(xmlNode3);
			XmlAttribute xmlAttribute = xmlDocument.CreateAttribute("FIO");
			xmlAttribute.Value = this.comboBox_5.Text;
			xmlNode3.Attributes.Append(xmlAttribute);
			xmlAttribute = xmlDocument.CreateAttribute("JobTitle");
			xmlAttribute.Value = this.textBox_21.Text;
			xmlNode3.Attributes.Append(xmlAttribute);
			XmlNode xmlNode4 = xmlDocument.CreateElement("FIO2");
			xmlNode2.AppendChild(xmlNode4);
			xmlAttribute = xmlDocument.CreateAttribute("FIO");
			xmlAttribute.Value = this.comboBox_4.Text;
			xmlNode4.Attributes.Append(xmlAttribute);
			xmlAttribute = xmlDocument.CreateAttribute("JobTitle");
			xmlAttribute.Value = this.textBox_20.Text;
			xmlNode4.Attributes.Append(xmlAttribute);
			XmlNode xmlNode5 = xmlDocument.CreateElement("FIO3");
			xmlNode2.AppendChild(xmlNode5);
			xmlAttribute = xmlDocument.CreateAttribute("FIO");
			xmlAttribute.Value = this.comboBox_3.Text;
			xmlNode5.Attributes.Append(xmlAttribute);
			xmlAttribute = xmlDocument.CreateAttribute("JobTitle");
			xmlAttribute.Value = this.textBox_19.Text;
			xmlNode5.Attributes.Append(xmlAttribute);
			XmlNode xmlNode6 = xmlDocument.CreateElement("Official");
			xmlNode2.AppendChild(xmlNode6);
			xmlAttribute = xmlDocument.CreateAttribute("FIO");
			xmlAttribute.Value = this.comboBox_2.Text;
			xmlNode6.Attributes.Append(xmlAttribute);
			xmlAttribute = xmlDocument.CreateAttribute("JobTitle");
			xmlAttribute.Value = this.textBox_18.Text;
			xmlNode6.Attributes.Append(xmlAttribute);
			XmlNode xmlNode7 = xmlDocument.CreateElement("Declarer");
			xmlNode.AppendChild(xmlNode7);
			XmlNode xmlNode8 = xmlDocument.CreateElement("FIO1");
			xmlNode7.AppendChild(xmlNode8);
			xmlAttribute = xmlDocument.CreateAttribute("FIO");
			xmlAttribute.Value = this.textBox_28.Text;
			xmlNode8.Attributes.Append(xmlAttribute);
			xmlAttribute = xmlDocument.CreateAttribute("JobTitle");
			xmlAttribute.Value = this.textBox_29.Text;
			xmlNode8.Attributes.Append(xmlAttribute);
			xmlNode8 = xmlDocument.CreateElement("FIO2");
			xmlNode7.AppendChild(xmlNode8);
			xmlAttribute = xmlDocument.CreateAttribute("FIO");
			xmlAttribute.Value = this.textBox_26.Text;
			xmlNode8.Attributes.Append(xmlAttribute);
			xmlAttribute = xmlDocument.CreateAttribute("JobTitle");
			xmlAttribute.Value = this.textBox_27.Text;
			xmlNode8.Attributes.Append(xmlAttribute);
			xmlNode8 = xmlDocument.CreateElement("FIO3");
			xmlNode7.AppendChild(xmlNode8);
			xmlAttribute = xmlDocument.CreateAttribute("FIO");
			xmlAttribute.Value = this.textBox_24.Text;
			xmlNode8.Attributes.Append(xmlAttribute);
			xmlAttribute = xmlDocument.CreateAttribute("JobTitle");
			xmlAttribute.Value = this.textBox_25.Text;
			xmlNode8.Attributes.Append(xmlAttribute);
			xmlNode8 = xmlDocument.CreateElement("FIO4");
			xmlNode7.AppendChild(xmlNode8);
			xmlAttribute = xmlDocument.CreateAttribute("FIO");
			xmlAttribute.Value = this.textBox_22.Text;
			xmlNode8.Attributes.Append(xmlAttribute);
			xmlAttribute = xmlDocument.CreateAttribute("JobTitle");
			xmlAttribute.Value = this.textBox_23.Text;
			xmlNode8.Attributes.Append(xmlAttribute);
			return xmlDocument;
		}

		private void method_23()
		{
			this.icontainer_0 = new Container();
			DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
			this.label_0 = new Label();
			this.textBox_0 = new TextBox();
			this.class10_0 = new Class10();
			this.label_1 = new Label();
			this.nullableDateTimePicker_0 = new NullableDateTimePicker();
			this.label_2 = new Label();
			this.textBox_1 = new TextBox();
			this.label_3 = new Label();
			this.comboBox_0 = new ComboBox();
			this.textBox_2 = new TextBox();
			this.label_4 = new Label();
			this.textBox_3 = new TextBox();
			this.label_5 = new Label();
			this.button_0 = new Button();
			this.button_1 = new Button();
			this.tabControl_0 = new TabControl();
			this.tabPage_0 = new TabPage();
			this.textBox_12 = new TextBox();
			this.label_15 = new Label();
			this.textBox_11 = new TextBox();
			this.label_14 = new Label();
			this.comboBox_1 = new ComboBox();
			this.label_6 = new Label();
			this.tabPage_3 = new TabPage();
			this.textBox_15 = new TextBox();
			this.rqQopNsonqw = new Label();
			this.textBox_16 = new TextBox();
			this.label_18 = new Label();
			this.textBox_17 = new TextBox();
			this.label_19 = new Label();
			this.textBox_13 = new TextBox();
			this.label_16 = new Label();
			this.textBox_14 = new TextBox();
			this.label_17 = new Label();
			this.tabPage_4 = new TabPage();
			this.splitContainer_1 = new SplitContainer();
			this.tjLoptxYsZw = new GroupBox();
			this.textBox_18 = new TextBox();
			this.label_22 = new Label();
			this.comboBox_2 = new ComboBox();
			this.label_23 = new Label();
			this.groupBox_0 = new GroupBox();
			this.textBox_19 = new TextBox();
			this.label_24 = new Label();
			this.comboBox_3 = new ComboBox();
			this.label_25 = new Label();
			this.groupBox_1 = new GroupBox();
			this.textBox_20 = new TextBox();
			this.label_26 = new Label();
			this.comboBox_4 = new ComboBox();
			this.label_27 = new Label();
			this.groupBox_2 = new GroupBox();
			this.textBox_21 = new TextBox();
			this.label_28 = new Label();
			this.comboBox_5 = new ComboBox();
			this.label_29 = new Label();
			this.label_20 = new Label();
			this.groupBox_3 = new GroupBox();
			this.textBox_22 = new TextBox();
			this.textBox_23 = new TextBox();
			this.label_30 = new Label();
			this.label_31 = new Label();
			this.groupBox_4 = new GroupBox();
			this.textBox_24 = new TextBox();
			this.textBox_25 = new TextBox();
			this.label_32 = new Label();
			this.iouopidywFk = new Label();
			this.groupBox_5 = new GroupBox();
			this.textBox_26 = new TextBox();
			this.textBox_27 = new TextBox();
			this.label_33 = new Label();
			this.label_34 = new Label();
			this.groupBox_6 = new GroupBox();
			this.textBox_28 = new TextBox();
			this.textBox_29 = new TextBox();
			this.label_35 = new Label();
			this.label_36 = new Label();
			this.label_21 = new Label();
			this.tabPage_1 = new TabPage();
			this.dataGridViewExcelFilter_0 = new DataGridViewExcelFilter();
			this.dataGridViewImageColumnNotNull_0 = new DataGridViewImageColumnNotNull();
			this.dataGridViewFilterTextBoxColumn_0 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_3 = new DataGridViewTextBoxColumn();
			this.bindingSource_0 = new BindingSource(this.icontainer_0);
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
			this.tabPage_2 = new TabPage();
			this.dateTimePicker_0 = new DateTimePicker();
			this.rkgopmMiUdA = new Label();
			this.button_2 = new Button();
			this.textBox_10 = new TextBox();
			this.label_13 = new Label();
			this.dataGridView_0 = new DataGridView();
			this.dataGridViewComboBoxColumn_0 = new DataGridViewComboBoxColumn();
			this.dataGridViewTextBoxColumn_9 = new DataGridViewTextBoxColumn();
			this.dataGridViewCheckBoxColumn_0 = new DataGridViewCheckBoxColumn();
			this.splitContainer_0 = new SplitContainer();
			this.textBox_4 = new TextBox();
			this.label_7 = new Label();
			this.textBox_5 = new TextBox();
			this.label_8 = new Label();
			this.textBox_6 = new TextBox();
			this.textBox_7 = new TextBox();
			this.label_9 = new Label();
			this.label_10 = new Label();
			this.textBox_8 = new TextBox();
			this.label_11 = new Label();
			this.textBox_9 = new TextBox();
			this.label_12 = new Label();
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
			this.dataGridViewFilterTextBoxColumn_1 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewTextBoxColumn_4 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_5 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_6 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_7 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_8 = new DataGridViewTextBoxColumn();
			((ISupportInitialize)this.class10_0).BeginInit();
			this.tabControl_0.SuspendLayout();
			this.tabPage_0.SuspendLayout();
			this.tabPage_3.SuspendLayout();
			this.tabPage_4.SuspendLayout();
			this.splitContainer_1.Panel1.SuspendLayout();
			this.splitContainer_1.Panel2.SuspendLayout();
			this.splitContainer_1.SuspendLayout();
			this.tjLoptxYsZw.SuspendLayout();
			this.groupBox_0.SuspendLayout();
			this.groupBox_1.SuspendLayout();
			this.groupBox_2.SuspendLayout();
			this.groupBox_3.SuspendLayout();
			this.groupBox_4.SuspendLayout();
			this.groupBox_5.SuspendLayout();
			this.groupBox_6.SuspendLayout();
			this.tabPage_1.SuspendLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_0).BeginInit();
			((ISupportInitialize)this.bindingSource_0).BeginInit();
			this.toolStrip_0.SuspendLayout();
			this.tabPage_2.SuspendLayout();
			((ISupportInitialize)this.dataGridView_0).BeginInit();
			this.splitContainer_0.Panel1.SuspendLayout();
			this.splitContainer_0.Panel2.SuspendLayout();
			this.splitContainer_0.SuspendLayout();
			this.contextMenuStrip_0.SuspendLayout();
			base.SuspendLayout();
			this.label_0.AutoSize = true;
			this.label_0.Location = new Point(12, 6);
			this.label_0.Name = "label2";
			this.label_0.Size = new Size(67, 13);
			this.label_0.TabIndex = 18;
			this.label_0.Text = "Номер акта";
			this.textBox_0.BackColor = SystemColors.Window;
			this.textBox_0.DataBindings.Add(new Binding("Text", this.class10_0, "tTC_Doc.numDoc", true));
			this.textBox_0.Location = new Point(8, 22);
			this.textBox_0.Name = "txtNumDoc";
			this.textBox_0.ReadOnly = true;
			this.textBox_0.Size = new Size(175, 20);
			this.textBox_0.TabIndex = 19;
			this.textBox_0.TextChanged += this.textBox_0_TextChanged;
			this.class10_0.DataSetName = "DataSetTechConnection";
			this.class10_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
			this.label_1.AutoSize = true;
			this.label_1.Location = new Point(186, 6);
			this.label_1.Name = "label3";
			this.label_1.Size = new Size(59, 13);
			this.label_1.TabIndex = 21;
			this.label_1.Text = "Дата акта";
			this.nullableDateTimePicker_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.nullableDateTimePicker_0.DataBindings.Add(new Binding("Value", this.class10_0, "tTC_Doc.dateDoc", true));
			this.nullableDateTimePicker_0.Location = new Point(189, 22);
			this.nullableDateTimePicker_0.Name = "dateTimePickerDocOut";
			this.nullableDateTimePicker_0.Size = new Size(435, 20);
			this.nullableDateTimePicker_0.TabIndex = 20;
			this.nullableDateTimePicker_0.Value = new DateTime(2013, 4, 29, 14, 38, 3, 750);
			this.nullableDateTimePicker_0.ValueChanged += this.nullableDateTimePicker_0_ValueChanged;
			this.label_2.AutoSize = true;
			this.label_2.Location = new Point(12, 242);
			this.label_2.Name = "label5";
			this.label_2.Size = new Size(45, 13);
			this.label_2.TabIndex = 26;
			this.label_2.Text = "Объект";
			this.textBox_1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_1.BackColor = SystemColors.Window;
			this.textBox_1.Location = new Point(145, 239);
			this.textBox_1.Name = "txtAbnObj";
			this.textBox_1.ReadOnly = true;
			this.textBox_1.Size = new Size(479, 20);
			this.textBox_1.TabIndex = 27;
			this.label_3.AutoSize = true;
			this.label_3.Location = new Point(12, 192);
			this.label_3.Name = "labelNumDateIn";
			this.label_3.Size = new Size(94, 13);
			this.label_3.TabIndex = 22;
			this.label_3.Text = "Номер и дата ТУ";
			this.comboBox_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.comboBox_0.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			this.comboBox_0.AutoCompleteSource = AutoCompleteSource.ListItems;
			this.comboBox_0.DataBindings.Add(new Binding("SelectedValue", this.class10_0, "tTC_Doc.IdParent", true));
			this.comboBox_0.FormattingEnabled = true;
			this.comboBox_0.Location = new Point(145, 189);
			this.comboBox_0.Name = "cmbNumDateIn";
			this.comboBox_0.Size = new Size(479, 21);
			this.comboBox_0.TabIndex = 23;
			this.comboBox_0.SelectedIndexChanged += this.comboBox_0_SelectedIndexChanged;
			this.comboBox_0.SelectedValueChanged += this.comboBox_0_SelectedValueChanged;
			this.textBox_2.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_2.BackColor = SystemColors.Window;
			this.textBox_2.Location = new Point(145, 215);
			this.textBox_2.Name = "txtAbn";
			this.textBox_2.ReadOnly = true;
			this.textBox_2.Size = new Size(479, 20);
			this.textBox_2.TabIndex = 25;
			this.label_4.AutoSize = true;
			this.label_4.Location = new Point(12, 218);
			this.label_4.Name = "label9";
			this.label_4.Size = new Size(49, 13);
			this.label_4.TabIndex = 24;
			this.label_4.Text = "Абонент";
			this.textBox_3.AcceptsReturn = true;
			this.textBox_3.AcceptsTab = true;
			this.textBox_3.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_3.DataBindings.Add(new Binding("Text", this.class10_0, "tTC_Doc.Comment", true));
			this.textBox_3.Location = new Point(8, 278);
			this.textBox_3.Multiline = true;
			this.textBox_3.Name = "txtBody";
			this.textBox_3.Size = new Size(619, 61);
			this.textBox_3.TabIndex = 29;
			this.textBox_3.TextChanged += this.textBox_3_TextChanged;
			this.label_5.AutoSize = true;
			this.label_5.Location = new Point(12, 262);
			this.label_5.Name = "label7";
			this.label_5.Size = new Size(77, 13);
			this.label_5.TabIndex = 28;
			this.label_5.Text = "Комментарий";
			this.button_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.button_0.Location = new Point(9, 384);
			this.button_0.Name = "buttonSave";
			this.button_0.Size = new Size(75, 23);
			this.button_0.TabIndex = 30;
			this.button_0.Text = "Сохранить";
			this.button_0.UseVisualStyleBackColor = true;
			this.button_0.Click += this.button_0_Click;
			this.button_1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.button_1.Location = new Point(550, 384);
			this.button_1.Name = "buttonClose";
			this.button_1.Size = new Size(75, 23);
			this.button_1.TabIndex = 31;
			this.button_1.Text = "Закрыть";
			this.button_1.UseVisualStyleBackColor = true;
			this.button_1.Click += this.button_1_Click;
			this.tabControl_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.tabControl_0.Controls.Add(this.tabPage_0);
			this.tabControl_0.Controls.Add(this.tabPage_3);
			this.tabControl_0.Controls.Add(this.tabPage_4);
			this.tabControl_0.Controls.Add(this.tabPage_1);
			this.tabControl_0.Controls.Add(this.tabPage_2);
			this.tabControl_0.Location = new Point(0, 0);
			this.tabControl_0.Name = "tabControl";
			this.tabControl_0.SelectedIndex = 0;
			this.tabControl_0.Size = new Size(638, 371);
			this.tabControl_0.TabIndex = 32;
			this.tabPage_0.Controls.Add(this.textBox_12);
			this.tabPage_0.Controls.Add(this.label_15);
			this.tabPage_0.Controls.Add(this.textBox_11);
			this.tabPage_0.Controls.Add(this.label_14);
			this.tabPage_0.Controls.Add(this.comboBox_1);
			this.tabPage_0.Controls.Add(this.label_6);
			this.tabPage_0.Controls.Add(this.textBox_0);
			this.tabPage_0.Controls.Add(this.nullableDateTimePicker_0);
			this.tabPage_0.Controls.Add(this.label_1);
			this.tabPage_0.Controls.Add(this.textBox_3);
			this.tabPage_0.Controls.Add(this.label_0);
			this.tabPage_0.Controls.Add(this.label_5);
			this.tabPage_0.Controls.Add(this.label_4);
			this.tabPage_0.Controls.Add(this.label_2);
			this.tabPage_0.Controls.Add(this.textBox_2);
			this.tabPage_0.Controls.Add(this.textBox_1);
			this.tabPage_0.Controls.Add(this.comboBox_0);
			this.tabPage_0.Controls.Add(this.label_3);
			this.tabPage_0.Location = new Point(4, 22);
			this.tabPage_0.Name = "tabPageGeneral";
			this.tabPage_0.Padding = new Padding(3);
			this.tabPage_0.Size = new Size(630, 345);
			this.tabPage_0.TabIndex = 0;
			this.tabPage_0.Text = "Общие";
			this.tabPage_0.UseVisualStyleBackColor = true;
			this.textBox_12.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_12.DataBindings.Add(new Binding("Text", this.class10_0, "tTC_ElectricalInspection.Electrical", true));
			this.textBox_12.Location = new Point(8, 132);
			this.textBox_12.Multiline = true;
			this.textBox_12.Name = "textBox1";
			this.textBox_12.Size = new Size(616, 51);
			this.textBox_12.TabIndex = 35;
			this.textBox_12.TextChanged += this.fseouXlYtQN;
			this.label_15.AutoSize = true;
			this.label_15.Location = new Point(12, 116);
			this.label_15.Name = "label16";
			this.label_15.Size = new Size(174, 13);
			this.label_15.TabIndex = 34;
			this.label_15.Text = "Осмотренные электроустановки";
			this.textBox_11.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_11.DataBindings.Add(new Binding("Text", this.class10_0, "tTC_ElectricalInspection.Declarer", true));
			this.textBox_11.Location = new Point(8, 93);
			this.textBox_11.Name = "txtDeclarer";
			this.textBox_11.Size = new Size(616, 20);
			this.textBox_11.TabIndex = 33;
			this.textBox_11.TextChanged += this.textBox_11_TextChanged;
			this.label_14.AutoSize = true;
			this.label_14.Location = new Point(11, 77);
			this.label_14.Name = "label15";
			this.label_14.Size = new Size(235, 13);
			this.label_14.TabIndex = 32;
			this.label_14.Text = "Заявитель (уполномоченный представитель)";
			this.comboBox_1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.comboBox_1.DataBindings.Add(new Binding("SelectedValue", this.class10_0, "tTC_ElectricalInspection.idWorker", true));
			this.comboBox_1.FormattingEnabled = true;
			this.comboBox_1.Location = new Point(99, 53);
			this.comboBox_1.Name = "cmbChiefSR";
			this.comboBox_1.Size = new Size(525, 21);
			this.comboBox_1.TabIndex = 31;
			this.comboBox_1.SelectedIndexChanged += this.comboBox_1_SelectedIndexChanged;
			this.label_6.AutoSize = true;
			this.label_6.Location = new Point(12, 56);
			this.label_6.Name = "label1";
			this.label_6.Size = new Size(81, 13);
			this.label_6.TabIndex = 30;
			this.label_6.Text = "Акт составлен";
			this.tabPage_3.Controls.Add(this.textBox_15);
			this.tabPage_3.Controls.Add(this.rqQopNsonqw);
			this.tabPage_3.Controls.Add(this.textBox_16);
			this.tabPage_3.Controls.Add(this.label_18);
			this.tabPage_3.Controls.Add(this.textBox_17);
			this.tabPage_3.Controls.Add(this.label_19);
			this.tabPage_3.Controls.Add(this.textBox_13);
			this.tabPage_3.Controls.Add(this.label_16);
			this.tabPage_3.Controls.Add(this.textBox_14);
			this.tabPage_3.Controls.Add(this.label_17);
			this.tabPage_3.Location = new Point(4, 22);
			this.tabPage_3.Name = "tabPageSet";
			this.tabPage_3.Padding = new Padding(3);
			this.tabPage_3.Size = new Size(630, 345);
			this.tabPage_3.TabIndex = 3;
			this.tabPage_3.Text = "Установлено";
			this.tabPage_3.UseVisualStyleBackColor = true;
			this.textBox_15.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_15.DataBindings.Add(new Binding("Text", this.class10_0, "tTC_ElectricalInspection.SetDocument", true));
			this.textBox_15.Location = new Point(8, 293);
			this.textBox_15.Multiline = true;
			this.textBox_15.Name = "txtSetDocument";
			this.textBox_15.Size = new Size(616, 49);
			this.textBox_15.TabIndex = 9;
			this.textBox_15.TextChanged += this.textBox_14_TextChanged;
			this.rqQopNsonqw.AutoSize = true;
			this.rqQopNsonqw.Location = new Point(8, 277);
			this.rqQopNsonqw.Name = "label21";
			this.rqQopNsonqw.Size = new Size(234, 13);
			this.rqQopNsonqw.TabIndex = 8;
			this.rqQopNsonqw.Text = "Документы, рассмотренные в ходе осмотра";
			this.textBox_16.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_16.DataBindings.Add(new Binding("Text", this.class10_0, "tTC_ElectricalInspection.SetReserveCP", true));
			this.textBox_16.Location = new Point(8, 223);
			this.textBox_16.Multiline = true;
			this.textBox_16.Name = "txtSetReserveCP";
			this.textBox_16.Size = new Size(616, 49);
			this.textBox_16.TabIndex = 7;
			this.textBox_16.TextChanged += this.textBox_14_TextChanged;
			this.label_18.AutoSize = true;
			this.label_18.Location = new Point(8, 207);
			this.label_18.Name = "label20";
			this.label_18.Size = new Size(223, 13);
			this.label_18.TabIndex = 6;
			this.label_18.Text = "Автономный резервный источник питания";
			this.textBox_17.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_17.DataBindings.Add(new Binding("Text", this.class10_0, "tTC_ElectricalInspection.SerRZA", true));
			this.textBox_17.Location = new Point(8, 156);
			this.textBox_17.Multiline = true;
			this.textBox_17.Name = "txtSetRZA";
			this.textBox_17.Size = new Size(616, 49);
			this.textBox_17.TabIndex = 5;
			this.textBox_17.TextChanged += this.textBox_14_TextChanged;
			this.label_19.AutoSize = true;
			this.label_19.Location = new Point(8, 140);
			this.label_19.Name = "label19";
			this.label_19.Size = new Size(435, 13);
			this.label_19.TabIndex = 4;
			this.label_19.Text = "Устройства защиты, релейной защиты, противоаварийной и режимной автоматики";
			this.textBox_13.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_13.DataBindings.Add(new Binding("Text", this.class10_0, "tTC_ElectricalInspection.SetMeterDevice", true));
			this.textBox_13.Location = new Point(8, 87);
			this.textBox_13.Multiline = true;
			this.textBox_13.Name = "txtSetMeterDevice";
			this.textBox_13.Size = new Size(616, 49);
			this.textBox_13.TabIndex = 3;
			this.textBox_13.TextChanged += this.textBox_14_TextChanged;
			this.label_16.AutoSize = true;
			this.label_16.Location = new Point(8, 71);
			this.label_16.Name = "label18";
			this.label_16.Size = new Size(202, 13);
			this.label_16.TabIndex = 2;
			this.label_16.Text = "Хар-ки установленных приборов учета";
			this.textBox_14.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_14.DataBindings.Add(new Binding("Text", this.class10_0, "tTC_ElectricalInspection.SetElectrical", true));
			this.textBox_14.Location = new Point(8, 19);
			this.textBox_14.Multiline = true;
			this.textBox_14.Name = "txtSetElectrical";
			this.textBox_14.Size = new Size(616, 49);
			this.textBox_14.TabIndex = 1;
			this.textBox_14.TextChanged += this.textBox_14_TextChanged;
			this.label_17.AutoSize = true;
			this.label_17.Location = new Point(8, 3);
			this.label_17.Name = "label17";
			this.label_17.Size = new Size(359, 13);
			this.label_17.TabIndex = 0;
			this.label_17.Text = "Перечень и хар-ки электрооборудования, предъявленного к осмотру";
			this.tabPage_4.Controls.Add(this.splitContainer_1);
			this.tabPage_4.Location = new Point(4, 22);
			this.tabPage_4.Name = "tabPageOfficials";
			this.tabPage_4.Size = new Size(630, 345);
			this.tabPage_4.TabIndex = 4;
			this.tabPage_4.Text = "Должностные лица";
			this.tabPage_4.UseVisualStyleBackColor = true;
			this.splitContainer_1.Dock = DockStyle.Fill;
			this.splitContainer_1.Location = new Point(0, 0);
			this.splitContainer_1.Name = "splitContainer2";
			this.splitContainer_1.Panel1.Controls.Add(this.tjLoptxYsZw);
			this.splitContainer_1.Panel1.Controls.Add(this.groupBox_0);
			this.splitContainer_1.Panel1.Controls.Add(this.groupBox_1);
			this.splitContainer_1.Panel1.Controls.Add(this.groupBox_2);
			this.splitContainer_1.Panel1.Controls.Add(this.label_20);
			this.splitContainer_1.Panel2.Controls.Add(this.groupBox_3);
			this.splitContainer_1.Panel2.Controls.Add(this.groupBox_4);
			this.splitContainer_1.Panel2.Controls.Add(this.groupBox_5);
			this.splitContainer_1.Panel2.Controls.Add(this.groupBox_6);
			this.splitContainer_1.Panel2.Controls.Add(this.label_21);
			this.splitContainer_1.Size = new Size(630, 345);
			this.splitContainer_1.SplitterDistance = 315;
			this.splitContainer_1.TabIndex = 0;
			this.tjLoptxYsZw.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.tjLoptxYsZw.Controls.Add(this.textBox_18);
			this.tjLoptxYsZw.Controls.Add(this.label_22);
			this.tjLoptxYsZw.Controls.Add(this.comboBox_2);
			this.tjLoptxYsZw.Controls.Add(this.label_23);
			this.tjLoptxYsZw.Location = new Point(3, 253);
			this.tjLoptxYsZw.Name = "groupBoxSetOfficial";
			this.tjLoptxYsZw.Size = new Size(309, 69);
			this.tjLoptxYsZw.TabIndex = 4;
			this.tjLoptxYsZw.TabStop = false;
			this.tjLoptxYsZw.Text = "Должностное лицо сетевой организации";
			this.textBox_18.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_18.Location = new Point(77, 40);
			this.textBox_18.Name = "txtSetJobTitleOfficial";
			this.textBox_18.Size = new Size(226, 20);
			this.textBox_18.TabIndex = 3;
			this.textBox_18.TextChanged += this.textBox_29_TextChanged;
			this.label_22.AutoSize = true;
			this.label_22.Location = new Point(6, 43);
			this.label_22.Name = "label30";
			this.label_22.Size = new Size(65, 13);
			this.label_22.TabIndex = 2;
			this.label_22.Text = "Должность";
			this.comboBox_2.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.comboBox_2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			this.comboBox_2.AutoCompleteSource = AutoCompleteSource.ListItems;
			this.comboBox_2.FormattingEnabled = true;
			this.comboBox_2.Location = new Point(46, 13);
			this.comboBox_2.Name = "cmbSetOfficial";
			this.comboBox_2.Size = new Size(257, 21);
			this.comboBox_2.TabIndex = 1;
			this.comboBox_2.SelectedValueChanged += this.comboBox_2_SelectedValueChanged;
			this.comboBox_2.TextChanged += this.comboBox_5_TextChanged;
			this.label_23.AutoSize = true;
			this.label_23.Location = new Point(6, 16);
			this.label_23.Name = "label31";
			this.label_23.Size = new Size(34, 13);
			this.label_23.TabIndex = 0;
			this.label_23.Text = "ФИО";
			this.groupBox_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox_0.Controls.Add(this.textBox_19);
			this.groupBox_0.Controls.Add(this.label_24);
			this.groupBox_0.Controls.Add(this.comboBox_3);
			this.groupBox_0.Controls.Add(this.label_25);
			this.groupBox_0.Location = new Point(3, 178);
			this.groupBox_0.Name = "groupBoxSet3";
			this.groupBox_0.Size = new Size(309, 69);
			this.groupBox_0.TabIndex = 3;
			this.groupBox_0.TabStop = false;
			this.groupBox_0.Text = "3";
			this.textBox_19.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_19.Location = new Point(77, 40);
			this.textBox_19.Name = "txtSetJobTitle3";
			this.textBox_19.Size = new Size(226, 20);
			this.textBox_19.TabIndex = 3;
			this.textBox_19.TextChanged += this.textBox_29_TextChanged;
			this.label_24.AutoSize = true;
			this.label_24.Location = new Point(6, 43);
			this.label_24.Name = "label28";
			this.label_24.Size = new Size(65, 13);
			this.label_24.TabIndex = 2;
			this.label_24.Text = "Должность";
			this.comboBox_3.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.comboBox_3.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			this.comboBox_3.AutoCompleteSource = AutoCompleteSource.ListItems;
			this.comboBox_3.FormattingEnabled = true;
			this.comboBox_3.Location = new Point(46, 13);
			this.comboBox_3.Name = "cmbSetFIO3";
			this.comboBox_3.Size = new Size(257, 21);
			this.comboBox_3.TabIndex = 1;
			this.comboBox_3.SelectedValueChanged += this.comboBox_3_SelectedValueChanged;
			this.comboBox_3.TextChanged += this.comboBox_5_TextChanged;
			this.label_25.AutoSize = true;
			this.label_25.Location = new Point(6, 16);
			this.label_25.Name = "label29";
			this.label_25.Size = new Size(34, 13);
			this.label_25.TabIndex = 0;
			this.label_25.Text = "ФИО";
			this.groupBox_1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox_1.Controls.Add(this.textBox_20);
			this.groupBox_1.Controls.Add(this.label_26);
			this.groupBox_1.Controls.Add(this.comboBox_4);
			this.groupBox_1.Controls.Add(this.label_27);
			this.groupBox_1.Location = new Point(3, 103);
			this.groupBox_1.Name = "groupBoxSet2";
			this.groupBox_1.Size = new Size(309, 69);
			this.groupBox_1.TabIndex = 2;
			this.groupBox_1.TabStop = false;
			this.groupBox_1.Text = "2";
			this.textBox_20.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_20.Location = new Point(77, 40);
			this.textBox_20.Name = "txtSetJobTitle2";
			this.textBox_20.Size = new Size(226, 20);
			this.textBox_20.TabIndex = 3;
			this.textBox_20.TextChanged += this.textBox_29_TextChanged;
			this.label_26.AutoSize = true;
			this.label_26.Location = new Point(6, 43);
			this.label_26.Name = "label26";
			this.label_26.Size = new Size(65, 13);
			this.label_26.TabIndex = 2;
			this.label_26.Text = "Должность";
			this.comboBox_4.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.comboBox_4.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			this.comboBox_4.AutoCompleteSource = AutoCompleteSource.ListItems;
			this.comboBox_4.FormattingEnabled = true;
			this.comboBox_4.Location = new Point(46, 13);
			this.comboBox_4.Name = "cmbSetFIO2";
			this.comboBox_4.Size = new Size(257, 21);
			this.comboBox_4.TabIndex = 1;
			this.comboBox_4.SelectedValueChanged += this.jMnoueSwlPi;
			this.comboBox_4.TextChanged += this.comboBox_5_TextChanged;
			this.label_27.AutoSize = true;
			this.label_27.Location = new Point(6, 16);
			this.label_27.Name = "label27";
			this.label_27.Size = new Size(34, 13);
			this.label_27.TabIndex = 0;
			this.label_27.Text = "ФИО";
			this.groupBox_2.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox_2.Controls.Add(this.textBox_21);
			this.groupBox_2.Controls.Add(this.label_28);
			this.groupBox_2.Controls.Add(this.comboBox_5);
			this.groupBox_2.Controls.Add(this.label_29);
			this.groupBox_2.Location = new Point(3, 25);
			this.groupBox_2.Name = "groupBoxSet1";
			this.groupBox_2.Size = new Size(309, 72);
			this.groupBox_2.TabIndex = 1;
			this.groupBox_2.TabStop = false;
			this.groupBox_2.Text = "1";
			this.textBox_21.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_21.Location = new Point(77, 40);
			this.textBox_21.Name = "txtSetJobTitle1";
			this.textBox_21.Size = new Size(226, 20);
			this.textBox_21.TabIndex = 3;
			this.textBox_21.TextChanged += this.textBox_29_TextChanged;
			this.label_28.AutoSize = true;
			this.label_28.Location = new Point(6, 43);
			this.label_28.Name = "label25";
			this.label_28.Size = new Size(65, 13);
			this.label_28.TabIndex = 2;
			this.label_28.Text = "Должность";
			this.comboBox_5.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.comboBox_5.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			this.comboBox_5.AutoCompleteSource = AutoCompleteSource.ListItems;
			this.comboBox_5.FormattingEnabled = true;
			this.comboBox_5.Location = new Point(46, 13);
			this.comboBox_5.Name = "cmbSetFIO1";
			this.comboBox_5.Size = new Size(257, 21);
			this.comboBox_5.TabIndex = 1;
			this.comboBox_5.SelectedValueChanged += this.comboBox_5_SelectedValueChanged;
			this.comboBox_5.TextChanged += this.comboBox_5_TextChanged;
			this.label_29.AutoSize = true;
			this.label_29.Location = new Point(6, 16);
			this.label_29.Name = "label24";
			this.label_29.Size = new Size(34, 13);
			this.label_29.TabIndex = 0;
			this.label_29.Text = "ФИО";
			this.label_20.AutoSize = true;
			this.label_20.Location = new Point(8, 9);
			this.label_20.Name = "label22";
			this.label_20.Size = new Size(132, 13);
			this.label_20.TabIndex = 0;
			this.label_20.Text = "От сетевой организации";
			this.groupBox_3.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox_3.Controls.Add(this.textBox_22);
			this.groupBox_3.Controls.Add(this.textBox_23);
			this.groupBox_3.Controls.Add(this.label_30);
			this.groupBox_3.Controls.Add(this.label_31);
			this.groupBox_3.Location = new Point(6, 253);
			this.groupBox_3.Name = "groupBox1";
			this.groupBox_3.Size = new Size(309, 69);
			this.groupBox_3.TabIndex = 4;
			this.groupBox_3.TabStop = false;
			this.groupBox_3.Text = "Заявитель (уполномоченный представитель)";
			this.textBox_22.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_22.Location = new Point(46, 14);
			this.textBox_22.Name = "txtDeclarerFIO4";
			this.textBox_22.Size = new Size(256, 20);
			this.textBox_22.TabIndex = 1;
			this.textBox_22.TextChanged += this.textBox_29_TextChanged;
			this.textBox_23.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_23.Location = new Point(77, 40);
			this.textBox_23.Name = "txtDeclarerJob4";
			this.textBox_23.Size = new Size(226, 20);
			this.textBox_23.TabIndex = 3;
			this.textBox_23.TextChanged += this.textBox_29_TextChanged;
			this.label_30.AutoSize = true;
			this.label_30.Location = new Point(6, 43);
			this.label_30.Name = "label32";
			this.label_30.Size = new Size(65, 13);
			this.label_30.TabIndex = 2;
			this.label_30.Text = "Должность";
			this.label_31.AutoSize = true;
			this.label_31.Location = new Point(6, 16);
			this.label_31.Name = "label33";
			this.label_31.Size = new Size(34, 13);
			this.label_31.TabIndex = 0;
			this.label_31.Text = "ФИО";
			this.groupBox_4.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox_4.Controls.Add(this.textBox_24);
			this.groupBox_4.Controls.Add(this.textBox_25);
			this.groupBox_4.Controls.Add(this.label_32);
			this.groupBox_4.Controls.Add(this.iouopidywFk);
			this.groupBox_4.Location = new Point(6, 178);
			this.groupBox_4.Name = "groupBox2";
			this.groupBox_4.Size = new Size(309, 69);
			this.groupBox_4.TabIndex = 3;
			this.groupBox_4.TabStop = false;
			this.groupBox_4.Text = "3";
			this.textBox_24.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_24.Location = new Point(46, 14);
			this.textBox_24.Name = "txtDeclarerFIO3";
			this.textBox_24.Size = new Size(256, 20);
			this.textBox_24.TabIndex = 1;
			this.textBox_24.TextChanged += this.textBox_29_TextChanged;
			this.textBox_25.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_25.Location = new Point(77, 40);
			this.textBox_25.Name = "txtDeclarerJob3";
			this.textBox_25.Size = new Size(226, 20);
			this.textBox_25.TabIndex = 3;
			this.textBox_25.TextChanged += this.textBox_29_TextChanged;
			this.label_32.AutoSize = true;
			this.label_32.Location = new Point(6, 43);
			this.label_32.Name = "label34";
			this.label_32.Size = new Size(65, 13);
			this.label_32.TabIndex = 2;
			this.label_32.Text = "Должность";
			this.iouopidywFk.AutoSize = true;
			this.iouopidywFk.Location = new Point(6, 16);
			this.iouopidywFk.Name = "label35";
			this.iouopidywFk.Size = new Size(34, 13);
			this.iouopidywFk.TabIndex = 0;
			this.iouopidywFk.Text = "ФИО";
			this.groupBox_5.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox_5.Controls.Add(this.textBox_26);
			this.groupBox_5.Controls.Add(this.textBox_27);
			this.groupBox_5.Controls.Add(this.label_33);
			this.groupBox_5.Controls.Add(this.label_34);
			this.groupBox_5.Location = new Point(6, 103);
			this.groupBox_5.Name = "groupBox3";
			this.groupBox_5.Size = new Size(309, 69);
			this.groupBox_5.TabIndex = 2;
			this.groupBox_5.TabStop = false;
			this.groupBox_5.Text = "2";
			this.textBox_26.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_26.Location = new Point(47, 14);
			this.textBox_26.Name = "txtDeclarerFIO2";
			this.textBox_26.Size = new Size(256, 20);
			this.textBox_26.TabIndex = 1;
			this.textBox_26.TextChanged += this.textBox_29_TextChanged;
			this.textBox_27.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_27.Location = new Point(77, 40);
			this.textBox_27.Name = "txtDeclarerJob2";
			this.textBox_27.Size = new Size(226, 20);
			this.textBox_27.TabIndex = 3;
			this.textBox_27.TextChanged += this.textBox_29_TextChanged;
			this.label_33.AutoSize = true;
			this.label_33.Location = new Point(6, 43);
			this.label_33.Name = "label36";
			this.label_33.Size = new Size(65, 13);
			this.label_33.TabIndex = 2;
			this.label_33.Text = "Должность";
			this.label_34.AutoSize = true;
			this.label_34.Location = new Point(6, 16);
			this.label_34.Name = "label37";
			this.label_34.Size = new Size(34, 13);
			this.label_34.TabIndex = 0;
			this.label_34.Text = "ФИО";
			this.groupBox_6.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox_6.Controls.Add(this.textBox_28);
			this.groupBox_6.Controls.Add(this.textBox_29);
			this.groupBox_6.Controls.Add(this.label_35);
			this.groupBox_6.Controls.Add(this.label_36);
			this.groupBox_6.Location = new Point(6, 25);
			this.groupBox_6.Name = "groupBox4";
			this.groupBox_6.Size = new Size(309, 72);
			this.groupBox_6.TabIndex = 1;
			this.groupBox_6.TabStop = false;
			this.groupBox_6.Text = "1";
			this.textBox_28.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_28.Location = new Point(46, 14);
			this.textBox_28.Name = "txtDeclarerFIO1";
			this.textBox_28.Size = new Size(256, 20);
			this.textBox_28.TabIndex = 1;
			this.textBox_28.TextChanged += this.textBox_29_TextChanged;
			this.textBox_29.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_29.Location = new Point(77, 40);
			this.textBox_29.Name = "txtDeclarerJob1";
			this.textBox_29.Size = new Size(226, 20);
			this.textBox_29.TabIndex = 3;
			this.textBox_29.TextChanged += this.textBox_29_TextChanged;
			this.label_35.AutoSize = true;
			this.label_35.Location = new Point(6, 43);
			this.label_35.Name = "label38";
			this.label_35.Size = new Size(65, 13);
			this.label_35.TabIndex = 2;
			this.label_35.Text = "Должность";
			this.label_36.AutoSize = true;
			this.label_36.Location = new Point(6, 16);
			this.label_36.Name = "label39";
			this.label_36.Size = new Size(34, 13);
			this.label_36.TabIndex = 0;
			this.label_36.Text = "ФИО";
			this.label_21.AutoSize = true;
			this.label_21.Location = new Point(12, 9);
			this.label_21.Name = "label23";
			this.label_21.Size = new Size(76, 13);
			this.label_21.TabIndex = 0;
			this.label_21.Text = "От заявителя";
			this.tabPage_1.Controls.Add(this.dataGridViewExcelFilter_0);
			this.tabPage_1.Controls.Add(this.toolStrip_0);
			this.tabPage_1.Location = new Point(4, 22);
			this.tabPage_1.Name = "tabPageFile";
			this.tabPage_1.Padding = new Padding(3);
			this.tabPage_1.Size = new Size(630, 345);
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
				this.dataGridViewTextBoxColumn_0,
				this.dataGridViewTextBoxColumn_1,
				this.dataGridViewTextBoxColumn_2,
				this.dataGridViewTextBoxColumn_3
			});
			this.dataGridViewExcelFilter_0.DataSource = this.bindingSource_0;
			this.dataGridViewExcelFilter_0.Dock = DockStyle.Fill;
			this.dataGridViewExcelFilter_0.EditMode = DataGridViewEditMode.EditProgrammatically;
			this.dataGridViewExcelFilter_0.Location = new Point(3, 28);
			this.dataGridViewExcelFilter_0.Name = "dgvFile";
			this.dataGridViewExcelFilter_0.ReadOnly = true;
			this.dataGridViewExcelFilter_0.RowHeadersVisible = false;
			this.dataGridViewExcelFilter_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewExcelFilter_0.Size = new Size(624, 314);
			this.dataGridViewExcelFilter_0.TabIndex = 8;
			this.dataGridViewExcelFilter_0.VirtualMode = true;
			this.dataGridViewExcelFilter_0.CellDoubleClick += this.dataGridViewExcelFilter_0_CellDoubleClick;
			this.dataGridViewExcelFilter_0.CellEndEdit += this.dataGridViewExcelFilter_0_CellEndEdit;
			this.dataGridViewExcelFilter_0.CellMouseClick += this.dataGridViewExcelFilter_0_CellMouseClick;
			this.dataGridViewExcelFilter_0.CellValidating += this.dataGridViewExcelFilter_0_CellValidating;
			this.dataGridViewExcelFilter_0.CellValueNeeded += this.dataGridViewExcelFilter_0_CellValueNeeded;
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
			this.dataGridViewTextBoxColumn_0.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_0.HeaderText = "id";
			this.dataGridViewTextBoxColumn_0.Name = "id";
			this.dataGridViewTextBoxColumn_0.ReadOnly = true;
			this.dataGridViewTextBoxColumn_0.Visible = false;
			this.dataGridViewTextBoxColumn_1.DataPropertyName = "idDoc";
			this.dataGridViewTextBoxColumn_1.HeaderText = "idDoc";
			this.dataGridViewTextBoxColumn_1.Name = "idDoc";
			this.dataGridViewTextBoxColumn_1.ReadOnly = true;
			this.dataGridViewTextBoxColumn_1.Visible = false;
			this.dataGridViewTextBoxColumn_2.DataPropertyName = "dateChange";
			this.dataGridViewTextBoxColumn_2.HeaderText = "dateChange";
			this.dataGridViewTextBoxColumn_2.Name = "dateChangeDgvColumn";
			this.dataGridViewTextBoxColumn_2.ReadOnly = true;
			this.dataGridViewTextBoxColumn_2.Visible = false;
			this.dataGridViewTextBoxColumn_3.DataPropertyName = "idTemplate";
			this.dataGridViewTextBoxColumn_3.HeaderText = "idTemplate";
			this.dataGridViewTextBoxColumn_3.Name = "idTemplateDgvColumn";
			this.dataGridViewTextBoxColumn_3.ReadOnly = true;
			this.dataGridViewTextBoxColumn_3.Visible = false;
			this.bindingSource_0.DataMember = "tTC_DocFile";
			this.bindingSource_0.DataSource = this.class10_0;
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
			this.toolStrip_0.Size = new Size(624, 25);
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
			this.toolStripMenuItem_0.Click += this.toolStripMenuItem_2_Click;
			this.toolStripSeparator_0.Name = "toolStripSeparator2";
			this.toolStripSeparator_0.Size = new Size(187, 6);
			this.toolStripButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_0.Image = Resources.ElementEdit;
			this.toolStripButton_0.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_0.Name = "toolBtnEditFile";
			this.toolStripButton_0.Size = new Size(23, 22);
			this.toolStripButton_0.Text = "Редактировать файл";
			this.toolStripButton_0.Click += this.toolStripMenuItem_3_Click;
			this.toolStripButton_1.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_1.Image = Resources.ElementInformation;
			this.toolStripButton_1.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_1.Name = "toolBtnOpenFile";
			this.toolStripButton_1.Size = new Size(23, 22);
			this.toolStripButton_1.Text = "Открыть файл";
			this.toolStripButton_1.Click += this.toolStripMenuItem_4_Click;
			this.toolStripButton_2.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_2.Image = Resources.ElementDel;
			this.toolStripButton_2.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_2.Name = "toolBtnDelFile";
			this.toolStripButton_2.Size = new Size(23, 22);
			this.toolStripButton_2.Text = "Удалить файл";
			this.toolStripButton_2.Click += this.toolStripMenuItem_5_Click;
			this.toolStripSeparator_1.Name = "toolStripSeparator3";
			this.toolStripSeparator_1.Size = new Size(6, 25);
			this.toolStripButton_3.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_3.Image = Resources.rename;
			this.toolStripButton_3.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_3.Name = "toolBtnRenameFile";
			this.toolStripButton_3.Size = new Size(23, 22);
			this.toolStripButton_3.Text = "Переименовать";
			this.toolStripButton_3.Click += this.toolStripMenuItem_6_Click;
			this.toolStripButton_4.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_4.Image = Resources.save;
			this.toolStripButton_4.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_4.Name = "toolBtnSaveFile";
			this.toolStripButton_4.Size = new Size(23, 22);
			this.toolStripButton_4.Text = "Сохранить файл на диск";
			this.toolStripButton_4.Click += this.toolStripMenuItem_7_Click;
			this.tabPage_2.Controls.Add(this.dateTimePicker_0);
			this.tabPage_2.Controls.Add(this.rkgopmMiUdA);
			this.tabPage_2.Controls.Add(this.button_2);
			this.tabPage_2.Controls.Add(this.textBox_10);
			this.tabPage_2.Controls.Add(this.label_13);
			this.tabPage_2.Controls.Add(this.dataGridView_0);
			this.tabPage_2.Controls.Add(this.splitContainer_0);
			this.tabPage_2.Controls.Add(this.textBox_8);
			this.tabPage_2.Controls.Add(this.label_11);
			this.tabPage_2.Controls.Add(this.textBox_9);
			this.tabPage_2.Controls.Add(this.label_12);
			this.tabPage_2.Location = new Point(4, 22);
			this.tabPage_2.Name = "tabPagePost";
			this.tabPage_2.Padding = new Padding(3);
			this.tabPage_2.Size = new Size(630, 345);
			this.tabPage_2.TabIndex = 2;
			this.tabPage_2.Text = "Почта";
			this.tabPage_2.UseVisualStyleBackColor = true;
			this.dateTimePicker_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.dateTimePicker_0.DataBindings.Add(new Binding("Value", this.class10_0, "tTC_ElectricalInspection.DateRecipient", true));
			this.dateTimePicker_0.Location = new Point(412, 313);
			this.dateTimePicker_0.Name = "dtpDateRecipient";
			this.dateTimePicker_0.Size = new Size(209, 20);
			this.dateTimePicker_0.TabIndex = 15;
			this.dateTimePicker_0.ValueChanged += this.dateTimePicker_0_ValueChanged;
			this.rkgopmMiUdA.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.rkgopmMiUdA.AutoSize = true;
			this.rkgopmMiUdA.Location = new Point(370, 319);
			this.rkgopmMiUdA.Name = "label13";
			this.rkgopmMiUdA.Size = new Size(36, 13);
			this.rkgopmMiUdA.TabIndex = 14;
			this.rkgopmMiUdA.Text = "Дата:";
			this.button_2.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.button_2.Location = new Point(5, 314);
			this.button_2.Name = "buttonSend";
			this.button_2.Size = new Size(75, 23);
			this.button_2.TabIndex = 13;
			this.button_2.Text = "Отправить";
			this.button_2.UseVisualStyleBackColor = true;
			this.button_2.Click += this.button_2_Click;
			this.textBox_10.Location = new Point(89, 137);
			this.textBox_10.Name = "txtSubject";
			this.textBox_10.Size = new Size(338, 20);
			this.textBox_10.TabIndex = 12;
			this.textBox_10.Text = "Акт осмотра электроустановки";
			this.label_13.AutoSize = true;
			this.label_13.Location = new Point(8, 140);
			this.label_13.Name = "label12";
			this.label_13.Size = new Size(75, 13);
			this.label_13.TabIndex = 11;
			this.label_13.Text = "Тема письма";
			this.dataGridView_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.dataGridView_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView_0.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewComboBoxColumn_0,
				this.dataGridViewTextBoxColumn_9,
				this.dataGridViewCheckBoxColumn_0
			});
			this.dataGridView_0.Location = new Point(0, 156);
			this.dataGridView_0.Name = "dgvRecipient";
			this.dataGridView_0.Size = new Size(630, 152);
			this.dataGridView_0.TabIndex = 10;
			this.dataGridView_0.DataError += this.dataGridView_0_DataError;
			this.dataGridView_0.EditingControlShowing += this.dataGridView_0_EditingControlShowing;
			this.dataGridView_0.RowsAdded += this.dataGridView_0_RowsAdded;
			this.dataGridView_0.RowsRemoved += this.dataGridView_0_RowsRemoved;
			this.dataGridViewComboBoxColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewComboBoxColumn_0.HeaderText = "Имя получателя";
			this.dataGridViewComboBoxColumn_0.Name = "fioRecipientDgvColumn";
			this.dataGridViewTextBoxColumn_9.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_9.HeaderText = "Адрес получателя";
			this.dataGridViewTextBoxColumn_9.Name = "mailDgvColumn";
			this.dataGridViewTextBoxColumn_9.ReadOnly = true;
			this.dataGridViewCheckBoxColumn_0.HeaderText = "Отправлено";
			this.dataGridViewCheckBoxColumn_0.Name = "isSendDgvColumn";
			this.dataGridViewCheckBoxColumn_0.ReadOnly = true;
			this.dataGridViewCheckBoxColumn_0.Width = 70;
			this.splitContainer_0.IsSplitterFixed = true;
			this.splitContainer_0.Location = new Point(0, 45);
			this.splitContainer_0.Name = "splitContainer1";
			this.splitContainer_0.Panel1.Controls.Add(this.textBox_4);
			this.splitContainer_0.Panel1.Controls.Add(this.label_7);
			this.splitContainer_0.Panel1.Controls.Add(this.textBox_5);
			this.splitContainer_0.Panel1.Controls.Add(this.label_8);
			this.splitContainer_0.Panel2.Controls.Add(this.textBox_6);
			this.splitContainer_0.Panel2.Controls.Add(this.textBox_7);
			this.splitContainer_0.Panel2.Controls.Add(this.label_9);
			this.splitContainer_0.Panel2.Controls.Add(this.label_10);
			this.splitContainer_0.Size = new Size(427, 87);
			this.splitContainer_0.SplitterDistance = 211;
			this.splitContainer_0.SplitterWidth = 1;
			this.splitContainer_0.TabIndex = 9;
			this.textBox_4.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_4.Location = new Point(14, 55);
			this.textBox_4.Name = "textBoxSenderAddress";
			this.textBox_4.Size = new Size(194, 20);
			this.textBox_4.TabIndex = 3;
			this.textBox_4.TextChanged += this.textBox_4_TextChanged;
			this.label_7.AutoSize = true;
			this.label_7.Location = new Point(11, 39);
			this.label_7.Name = "label10";
			this.label_7.Size = new Size(105, 13);
			this.label_7.TabIndex = 2;
			this.label_7.Text = "Адрес отправителя";
			this.textBox_5.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_5.Location = new Point(14, 16);
			this.textBox_5.Name = "textBoxLogin";
			this.textBox_5.Size = new Size(194, 20);
			this.textBox_5.TabIndex = 1;
			this.textBox_5.TextChanged += this.textBox_5_TextChanged;
			this.label_8.AutoSize = true;
			this.label_8.Location = new Point(11, 0);
			this.label_8.Name = "label8";
			this.label_8.Size = new Size(38, 13);
			this.label_8.TabIndex = 0;
			this.label_8.Text = "Логин";
			this.textBox_6.Location = new Point(6, 16);
			this.textBox_6.Name = "textBoxPassword";
			this.textBox_6.PasswordChar = '☻';
			this.textBox_6.Size = new Size(206, 20);
			this.textBox_6.TabIndex = 8;
			this.textBox_6.TextChanged += this.textBox_6_TextChanged;
			this.textBox_7.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_7.Location = new Point(6, 55);
			this.textBox_7.Name = "textBoxSenderName";
			this.textBox_7.Size = new Size(205, 20);
			this.textBox_7.TabIndex = 5;
			this.textBox_7.TextChanged += this.textBox_7_TextChanged;
			this.label_9.AutoSize = true;
			this.label_9.Location = new Point(3, 39);
			this.label_9.Name = "label11";
			this.label_9.Size = new Size(96, 13);
			this.label_9.TabIndex = 4;
			this.label_9.Text = "Имя отправителя";
			this.label_10.AutoSize = true;
			this.label_10.Location = new Point(3, 0);
			this.label_10.Name = "label4";
			this.label_10.Size = new Size(45, 13);
			this.label_10.TabIndex = 2;
			this.label_10.Text = "Пароль";
			this.textBox_8.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.textBox_8.Location = new Point(328, 19);
			this.textBox_8.Name = "textBoxSmtpPort";
			this.textBox_8.Size = new Size(96, 20);
			this.textBox_8.TabIndex = 8;
			this.textBox_8.Text = "25";
			this.textBox_8.TextChanged += this.textBox_8_TextChanged;
			this.label_11.AutoSize = true;
			this.label_11.Location = new Point(327, 3);
			this.label_11.Name = "label6";
			this.label_11.Size = new Size(32, 13);
			this.label_11.TabIndex = 7;
			this.label_11.Text = "Порт";
			this.textBox_9.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_9.Location = new Point(11, 19);
			this.textBox_9.Name = "txtSmtpServer";
			this.textBox_9.Size = new Size(295, 20);
			this.textBox_9.TabIndex = 6;
			this.textBox_9.Text = "domino";
			this.textBox_9.TextChanged += this.textBox_9_TextChanged;
			this.label_12.AutoSize = true;
			this.label_12.Location = new Point(8, 3);
			this.label_12.Name = "label14";
			this.label_12.Size = new Size(94, 13);
			this.label_12.TabIndex = 5;
			this.label_12.Text = "Сервер отправки";
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
			this.dataGridViewFilterTextBoxColumn_1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewFilterTextBoxColumn_1.DataPropertyName = "FileName";
			this.dataGridViewFilterTextBoxColumn_1.HeaderText = "Файл";
			this.dataGridViewFilterTextBoxColumn_1.Name = "dataGridViewFilterTextBoxColumn1";
			this.dataGridViewFilterTextBoxColumn_1.Resizable = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_4.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_4.HeaderText = "id";
			this.dataGridViewTextBoxColumn_4.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_4.Visible = false;
			this.dataGridViewTextBoxColumn_5.DataPropertyName = "idDoc";
			this.dataGridViewTextBoxColumn_5.HeaderText = "idDoc";
			this.dataGridViewTextBoxColumn_5.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn_5.Visible = false;
			this.dataGridViewTextBoxColumn_6.DataPropertyName = "dateChange";
			this.dataGridViewTextBoxColumn_6.HeaderText = "dateChange";
			this.dataGridViewTextBoxColumn_6.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn_6.Visible = false;
			this.dataGridViewTextBoxColumn_7.DataPropertyName = "idTemplate";
			this.dataGridViewTextBoxColumn_7.HeaderText = "idTemplate";
			this.dataGridViewTextBoxColumn_7.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn_7.Visible = false;
			this.dataGridViewTextBoxColumn_8.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_8.HeaderText = "Адрес получателя";
			this.dataGridViewTextBoxColumn_8.Name = "dataGridViewTextBoxColumn5";
			this.dataGridViewTextBoxColumn_8.ReadOnly = true;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(637, 419);
			base.Controls.Add(this.tabControl_0);
			base.Controls.Add(this.button_1);
			base.Controls.Add(this.button_0);
			base.Name = "FormActElectricalInspection";
			this.Text = "Добавление/редактирование акта осмотра электроустановки";
			base.FormClosing += this.FormActElectricalInspection_FormClosing;
			base.FormClosed += this.FormActElectricalInspection_FormClosed;
			base.Load += this.FormActElectricalInspection_Load;
			((ISupportInitialize)this.class10_0).EndInit();
			this.tabControl_0.ResumeLayout(false);
			this.tabPage_0.ResumeLayout(false);
			this.tabPage_0.PerformLayout();
			this.tabPage_3.ResumeLayout(false);
			this.tabPage_3.PerformLayout();
			this.tabPage_4.ResumeLayout(false);
			this.splitContainer_1.Panel1.ResumeLayout(false);
			this.splitContainer_1.Panel1.PerformLayout();
			this.splitContainer_1.Panel2.ResumeLayout(false);
			this.splitContainer_1.Panel2.PerformLayout();
			this.splitContainer_1.ResumeLayout(false);
			this.tjLoptxYsZw.ResumeLayout(false);
			this.tjLoptxYsZw.PerformLayout();
			this.groupBox_0.ResumeLayout(false);
			this.groupBox_0.PerformLayout();
			this.groupBox_1.ResumeLayout(false);
			this.groupBox_1.PerformLayout();
			this.groupBox_2.ResumeLayout(false);
			this.groupBox_2.PerformLayout();
			this.groupBox_3.ResumeLayout(false);
			this.groupBox_3.PerformLayout();
			this.groupBox_4.ResumeLayout(false);
			this.groupBox_4.PerformLayout();
			this.groupBox_5.ResumeLayout(false);
			this.groupBox_5.PerformLayout();
			this.groupBox_6.ResumeLayout(false);
			this.groupBox_6.PerformLayout();
			this.tabPage_1.ResumeLayout(false);
			this.tabPage_1.PerformLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_0).EndInit();
			((ISupportInitialize)this.bindingSource_0).EndInit();
			this.toolStrip_0.ResumeLayout(false);
			this.toolStrip_0.PerformLayout();
			this.tabPage_2.ResumeLayout(false);
			this.tabPage_2.PerformLayout();
			((ISupportInitialize)this.dataGridView_0).EndInit();
			this.splitContainer_0.Panel1.ResumeLayout(false);
			this.splitContainer_0.Panel1.PerformLayout();
			this.splitContainer_0.Panel2.ResumeLayout(false);
			this.splitContainer_0.Panel2.PerformLayout();
			this.splitContainer_0.ResumeLayout(false);
			this.contextMenuStrip_0.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		static FormActElectricalInspection()
		{
			// Note: this type is marked as 'beforefieldinit'.
			
			FormActElectricalInspection.byte_0 = Encoding.ASCII.GetBytes("jf8hSDJH");
		}

		[CompilerGenerated]
		private void method_24()
		{
			this.bindingSource_0.ResetBindings(false);
		}

		internal static void Gch0tROh91RryEaFPD67(Form form_0, bool bool_1)
		{
			form_0.Dispose(bool_1);
		}

		private int int_0;

		private int int_1;

		private int int_2;

		private int int_3;

		private int int_4;

		private bool bool_0;

		private Dictionary<string, FileWatcherArgsAddl> dictionary_0;

		private string string_0;

		private static byte[] byte_0;

		private Label label_0;

		private TextBox textBox_0;

		private Label label_1;

		private NullableDateTimePicker nullableDateTimePicker_0;

		private Label label_2;

		private TextBox textBox_1;

		private Label label_3;

		private ComboBox comboBox_0;

		private TextBox textBox_2;

		private Label label_4;

		private TextBox textBox_3;

		private Label label_5;

		private Button button_0;

		private Button button_1;

		private Class10 class10_0;

		private TabControl tabControl_0;

		private TabPage tabPage_0;

		private TabPage tabPage_1;

		private BindingSource bindingSource_0;

		private DataGridViewExcelFilter dataGridViewExcelFilter_0;

		private DataGridViewImageColumnNotNull dataGridViewImageColumnNotNull_0;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_0;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_3;

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

		private ComboBox comboBox_1;

		private Label label_6;

		private TabPage tabPage_2;

		private SplitContainer splitContainer_0;

		private TextBox textBox_4;

		private Label label_7;

		private TextBox textBox_5;

		private Label label_8;

		private TextBox textBox_6;

		private TextBox textBox_7;

		private Label label_9;

		private Label label_10;

		private TextBox textBox_8;

		private Label label_11;

		private TextBox textBox_9;

		private Label label_12;

		private DataGridView dataGridView_0;

		private TextBox textBox_10;

		private Label label_13;

		private Button button_2;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_1;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_4;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_5;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_6;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_7;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_8;

		private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_0;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_9;

		private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn_0;

		private DateTimePicker dateTimePicker_0;

		private Label rkgopmMiUdA;

		private TextBox textBox_11;

		private Label label_14;

		private TextBox textBox_12;

		private Label label_15;

		private TabPage tabPage_3;

		private TextBox textBox_13;

		private Label label_16;

		private TextBox textBox_14;

		private Label label_17;

		private TextBox textBox_15;

		private Label rqQopNsonqw;

		private TextBox textBox_16;

		private Label label_18;

		private TextBox textBox_17;

		private Label label_19;

		private TabPage tabPage_4;

		private SplitContainer splitContainer_1;

		private Label label_20;

		private Label label_21;

		private GroupBox tjLoptxYsZw;

		private TextBox textBox_18;

		private Label label_22;

		private ComboBox comboBox_2;

		private Label label_23;

		private GroupBox groupBox_0;

		private TextBox textBox_19;

		private Label label_24;

		private ComboBox comboBox_3;

		private Label label_25;

		private GroupBox groupBox_1;

		private TextBox textBox_20;

		private Label label_26;

		private ComboBox comboBox_4;

		private Label label_27;

		private GroupBox groupBox_2;

		private TextBox textBox_21;

		private Label label_28;

		private ComboBox comboBox_5;

		private Label label_29;

		private GroupBox groupBox_3;

		private TextBox textBox_22;

		private TextBox textBox_23;

		private Label label_30;

		private Label label_31;

		private GroupBox groupBox_4;

		private TextBox textBox_24;

		private TextBox textBox_25;

		private Label label_32;

		private Label iouopidywFk;

		private GroupBox groupBox_5;

		private TextBox textBox_26;

		private TextBox textBox_27;

		private Label label_33;

		private Label label_34;

		private GroupBox groupBox_6;

		private TextBox textBox_28;

		private TextBox textBox_29;

		private Label label_35;

		private Label label_36;
	}
}
