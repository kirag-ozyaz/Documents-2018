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
using DataSql;
using Documents.Properties;
using FormLbr;
using FormLbr.Classes;

namespace Documents.Forms.TechnologicalConnection.Acts
{
	public partial class FormActPerformingTU : FormBase
	{
		internal int method_0()
		{
			return this.int_0;
		}

		internal FormActPerformingTU()
		{
			
			this.int_0 = -1;
			this.int_1 = -1;
			this.int_2 = -1;
			this.int_3 = -1;
			this.itEoAbhpdmf = 1239;
			this.dictionary_0 = new Dictionary<string, FileWatcherArgsAddl>();
			this.string_0 = "";
			
			this.method_17();
			this.method_1();
		}

		public FormActPerformingTU(int idAct, int idTU = -1, int typeAct = 1239)
		{
			
			this.int_0 = -1;
			this.int_1 = -1;
			this.int_2 = -1;
			this.int_3 = -1;
			this.itEoAbhpdmf = 1239;
			this.dictionary_0 = new Dictionary<string, FileWatcherArgsAddl>();
			this.string_0 = "";
			
			this.method_17();
			this.int_0 = idAct;
			this.int_1 = idTU;
			this.itEoAbhpdmf = typeAct;
			this.method_1();
		}

		private void method_1()
		{
			this.Text = ((this.int_0 == -1) ? "Добавление акта выполнения ТУ" : "Редактирование акта выполнения ТУ");
		}

		private void FormActPerformingTU_Load(object sender, EventArgs e)
		{
			this.method_3();
			if (this.int_0 == -1)
			{
				DataRow dataRow = this.eHqoAiqcXw1.tTC_Doc.NewRow();
				dataRow["DateDoc"] = DateTime.Now.Date;
				dataRow["TypeDoc"] = this.itEoAbhpdmf;
				dataRow["idParent"] = this.int_1;
				this.eHqoAiqcXw1.tTC_Doc.Rows.Add(dataRow);
				this.method_2();
			}
			else
			{
				base.SelectSqlData(this.eHqoAiqcXw1, this.eHqoAiqcXw1.tTC_Doc, true, "where id = " + this.int_0.ToString());
				base.SelectSqlData(this.eHqoAiqcXw1, this.eHqoAiqcXw1.tTC_PerformingTU, true, "where id = " + this.int_0.ToString());
				if (this.eHqoAiqcXw1.tTC_PerformingTU.Rows.Count == 0)
				{
					this.method_2();
				}
				this.method_15(this.int_0);
			}
			this.bool_0 = false;
		}

		private void FormActPerformingTU_FormClosed(object sender, FormClosedEventArgs e)
		{
			base.SaveFormConfig(null);
		}

		private void method_2()
		{
			DataRow dataRow = this.eHqoAiqcXw1.tTC_PerformingTU.NewRow();
			dataRow["id"] = this.int_0;
			this.eHqoAiqcXw1.tTC_PerformingTU.Rows.Add(dataRow);
			base.LoadFormConfig(null);
		}

		private void method_3()
		{
			string text = string.Concat(new string[]
			{
				"select  d.id, d.numdoc, d.datedoc,  isnull(d.numdoc, '') + ' от ' + isnull(convert( varchar(10),d.Datedoc, 104), '') as numDatedoc  from ttc_doc d  where typeDoc = ",
				1123.ToString(),
				" and (id not in (select idparent from ttc_doc where typedoc = ",
				1239.ToString(),
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

		private void method_4(int int_4)
		{
			Class10.Class12 @class = new Class10.Class12();
			base.SelectSqlData(@class, true, " where id = " + int_4.ToString(), null, false, 0);
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

		private void textBox_7_TextChanged(object sender, EventArgs e)
		{
			this.bool_0 = true;
		}

		private void textBox_6_TextChanged(object sender, EventArgs e)
		{
			this.bool_0 = true;
		}

		private void textBox_5_TextChanged(object sender, EventArgs e)
		{
			this.bool_0 = true;
		}

		private void textBox_4_TextChanged(object sender, EventArgs e)
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
			this.eHqoAiqcXw1.tTC_Doc.Rows[0].EndEdit();
			if (this.int_0 == -1)
			{
				this.int_0 = base.InsertSqlDataOneRow(this.eHqoAiqcXw1, this.eHqoAiqcXw1.tTC_Doc);
				if (this.int_0 == -1)
				{
					return false;
				}
			}
			else if (!base.UpdateSqlData(this.eHqoAiqcXw1, this.eHqoAiqcXw1.tTC_Doc))
			{
				return false;
			}
			return this.method_7() && this.method_16();
		}

		private bool method_7()
		{
			this.eHqoAiqcXw1.tTC_PerformingTU.Rows[0]["id"] = this.int_0;
			this.eHqoAiqcXw1.tTC_PerformingTU.Rows[0].EndEdit();
			return base.InsertSqlData(this.eHqoAiqcXw1.tTC_PerformingTU) && base.UpdateSqlData(this.eHqoAiqcXw1.tTC_PerformingTU);
		}

		private void button_1_Click(object sender, EventArgs e)
		{
			if (this.bool_0)
			{
				DialogResult dialogResult = MessageBox.Show("Документ был изменен. Сохранить документ?", "Сохранение", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
				if (dialogResult == DialogResult.Yes && this.method_6())
				{
					base.Close();
				}
				if (dialogResult == DialogResult.No)
				{
					base.Close();
					return;
				}
			}
			else
			{
				base.Close();
			}
		}

		private void button_0_Click(object sender, EventArgs e)
		{
			if (this.method_6())
			{
				base.Close();
			}
		}

		private void bqvoAnbClsu()
		{
			foreach (object obj in new SqlDataCommand(this.SqlSettings).SelectSqlData(" SELECT doc.id, doc.FileName  FROM tR_DocTemplate AS doc  INNER JOIN [tR_Classifier] AS c ON doc.idTypeDoc = c.id  WHERE c.ParentKey = ';TypeDoc;tR_DocTemplate;' AND c.Deleted = ((0)) AND c.isGroup = ((0)) AND c.Value = 1 and doc.deleted = 0").Rows)
			{
				DataRow dataRow = (DataRow)obj;
				ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
				toolStripMenuItem.Text = dataRow["FileName"].ToString();
				toolStripMenuItem.Tag = dataRow["id"];
				toolStripMenuItem.Click += this.method_9;
				this.bcDoNmAufdx.DropDownItems.Add(toolStripMenuItem);
				ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem();
				toolStripMenuItem2.Text = dataRow["FileName"].ToString();
				toolStripMenuItem2.Tag = dataRow["id"];
				toolStripMenuItem2.Click += this.method_9;
				this.toolStripMenuItem_1.DropDownItems.Add(toolStripMenuItem2);
			}
		}

		private string method_8(string string_1, int? nullable_0 = null, byte[] byte_0 = null)
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
					Class10.Class88 @class = this.eHqoAiqcXw1.tTC_DocFile.method_5();
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
					this.eHqoAiqcXw1.tTC_DocFile.method_0(@class);
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
					if (!string.IsNullOrEmpty(this.method_8(string_, null, null)))
					{
						this.bool_0 = true;
					}
				}
			}
		}

		private void method_9(object sender, EventArgs e)
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
			string text2 = this.method_14();
			string newFileNameIsExists = FileBinary.GetNewFileNameIsExists(text2, text, false);
			string text3 = this.method_8(text, new int?(num), array);
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

		private void toolStripMenuItem_3_Click(object sender, EventArgs e)
		{
			this.method_10(true);
		}

		private void toolStripMenuItem_4_Click(object sender, EventArgs e)
		{
			this.method_10(false);
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
						this.dictionary_0[fileName].Watcher.AnyChanged -= this.method_11;
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

		private void method_10(bool bool_1 = false)
		{
			if (this.bindingSource_0.Current != null)
			{
				Class10.Class88 @class = (Class10.Class88)((DataRowView)this.bindingSource_0.Current).Row;
				string fileName = @class.FileName;
				string text = this.method_14();
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

		private void method_11(object sender, FileSystemEventArgs e)
		{
			IEnumerable<KeyValuePair<string, FileWatcherArgsAddl>> fwargs = from item in this.dictionary_0
			where item.Value.TempName == e.Name
			select item;
			if (fwargs.Count<KeyValuePair<string, FileWatcherArgsAddl>>() > 0)
			{
				FileBinary fileBinary = new FileBinary(e.FullPath);
				EnumerableRowCollection<Class10.Class88> source = from rowFiles in this.eHqoAiqcXw1.tTC_DocFile
				where rowFiles.RowState != DataRowState.Deleted && rowFiles.FileName == fwargs.First<KeyValuePair<string, FileWatcherArgsAddl>>().Value.OriginalName
				select rowFiles;
				if (source.Count<Class10.Class88>() == 0)
				{
					Class10.Class88 @class = this.eHqoAiqcXw1.tTC_DocFile.method_5();
					@class.idDoc = this.int_0;
					@class.FileName = fwargs.First<KeyValuePair<string, FileWatcherArgsAddl>>().Value.OriginalName;
					@class.File = fileBinary.ByteArray;
					@class.dateChange = fileBinary.LastChanged;
					@class.idTemplate = fwargs.First<KeyValuePair<string, FileWatcherArgsAddl>>().Value.IdTemplate.Value;
					this.eHqoAiqcXw1.tTC_DocFile.Rows.Add(@class);
				}
				else
				{
					source.First<Class10.Class88>().File = fileBinary.ByteArray;
					source.First<Class10.Class88>().dateChange = fileBinary.LastChanged;
					source.First<Class10.Class88>().EndEdit();
					this.bool_0 = true;
				}
			}
			this.method_13();
		}

		private bool method_12(string string_1)
		{
			return (from row in this.eHqoAiqcXw1.tTC_DocFile
			where row.FileName == string_1
			select row).Count<Class10.Class88>() > 0;
		}

		private void method_13()
		{
			if (base.InvokeRequired)
			{
				base.Invoke(new Action(this.method_18));
				return;
			}
			this.bindingSource_0.ResetBindings(false);
		}

		private string method_14()
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

		private void method_15(int int_4)
		{
			try
			{
				using (SqlConnection sqlConnection = new SqlConnection(this.SqlSettings.GetConnectionString()))
				{
					sqlConnection.Open();
					SqlDataReader sqlDataReader = new SqlCommand("SELECT id, idDoc, FileName, dateChange, idTemplate FROM tTC_DocFile WHERE idDoc = " + int_4.ToString(), sqlConnection).ExecuteReader();
					while (sqlDataReader.Read())
					{
						Class10.Class88 @class = this.eHqoAiqcXw1.tTC_DocFile.method_5();
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
						this.eHqoAiqcXw1.tTC_DocFile.Rows.Add(@class);
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

		private bool method_16()
		{
			foreach (DataRow dataRow in this.eHqoAiqcXw1.tTC_DocFile)
			{
				if (dataRow.RowState != DataRowState.Deleted && dataRow.RowState != DataRowState.Detached && Convert.ToInt32(dataRow["idDoc"]) != this.int_0)
				{
					dataRow["idDoc"] = this.int_0;
					dataRow.EndEdit();
				}
			}
			if (base.InsertSqlData(this.eHqoAiqcXw1, this.eHqoAiqcXw1.tTC_DocFile) && base.UpdateSqlDataOnlyChange(this.eHqoAiqcXw1.tTC_DocFile) && base.DeleteSqlData(this.eHqoAiqcXw1, this.eHqoAiqcXw1.tTC_DocFile))
			{
				this.eHqoAiqcXw1.tTC_DocFile.AcceptChanges();
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

		protected override XmlDocument CreateXmlConfig()
		{
			XmlDocument xmlDocument = new XmlDocument();
			XmlNode xmlNode = xmlDocument.CreateElement(base.Name);
			xmlDocument.AppendChild(xmlNode);
			XmlNode xmlNode2 = xmlDocument.CreateElement("NetWork");
			xmlNode.AppendChild(xmlNode2);
			XmlAttribute xmlAttribute = xmlDocument.CreateAttribute("Face");
			xmlAttribute.Value = this.textBox_7.Text;
			xmlNode2.Attributes.Append(xmlAttribute);
			xmlAttribute = xmlDocument.CreateAttribute("Basis");
			xmlAttribute.Value = this.textBox_6.Text;
			xmlNode2.Attributes.Append(xmlAttribute);
			return xmlDocument;
		}

		protected override void ApplyConfig(XmlDocument doc)
		{
			XmlNode xmlNode = doc.SelectSingleNode(base.Name);
			if (xmlNode != null)
			{
				XmlNode xmlNode2 = xmlNode.SelectSingleNode("NetWork");
				if (xmlNode2 == null)
				{
					return;
				}
				XmlAttribute xmlAttribute = xmlNode2.Attributes["Face"];
				if (xmlAttribute != null)
				{
					if (this.eHqoAiqcXw1.tTC_PerformingTU.Rows.Count > 0)
					{
						this.eHqoAiqcXw1.tTC_PerformingTU.Rows[0]["FaceNetWork"] = xmlAttribute.Value;
					}
					else
					{
						this.textBox_7.Text = xmlAttribute.Value;
					}
				}
				xmlAttribute = xmlNode2.Attributes["Basis"];
				if (xmlAttribute != null)
				{
					if (this.eHqoAiqcXw1.tTC_PerformingTU.Rows.Count > 0)
					{
						this.eHqoAiqcXw1.tTC_PerformingTU.Rows[0]["BasisNetWork"] = xmlAttribute.Value;
						return;
					}
					this.textBox_6.Text = xmlAttribute.Value;
				}
			}
		}

		private void method_17()
		{
			this.icontainer_0 = new Container();
			DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
			this.label_0 = new Label();
			this.textBox_0 = new TextBox();
			this.eHqoAiqcXw1 = new Class10();
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
			this.groupBox_0 = new GroupBox();
			this.textBox_4 = new TextBox();
			this.label_6 = new Label();
			this.textBox_5 = new TextBox();
			this.label_7 = new Label();
			this.groupBox_1 = new GroupBox();
			this.textBox_6 = new TextBox();
			this.tZuoNktfyIY = new Label();
			this.textBox_7 = new TextBox();
			this.label_8 = new Label();
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
			this.bcDoNmAufdx = new ToolStripDropDownButton();
			this.toolStripMenuItem_0 = new ToolStripMenuItem();
			this.toolStripSeparator_0 = new ToolStripSeparator();
			this.toolStripButton_0 = new ToolStripButton();
			this.toolStripButton_1 = new ToolStripButton();
			this.toolStripButton_2 = new ToolStripButton();
			this.toolStripSeparator_1 = new ToolStripSeparator();
			this.toolStripButton_3 = new ToolStripButton();
			this.XldoNswxZle = new ToolStripButton();
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
			((ISupportInitialize)this.eHqoAiqcXw1).BeginInit();
			this.tabControl_0.SuspendLayout();
			this.tabPage_0.SuspendLayout();
			this.groupBox_0.SuspendLayout();
			this.groupBox_1.SuspendLayout();
			this.tabPage_1.SuspendLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_0).BeginInit();
			((ISupportInitialize)this.bindingSource_0).BeginInit();
			this.toolStrip_0.SuspendLayout();
			this.contextMenuStrip_0.SuspendLayout();
			base.SuspendLayout();
			this.label_0.AutoSize = true;
			this.label_0.Location = new Point(12, 6);
			this.label_0.Name = "label2";
			this.label_0.Size = new Size(67, 13);
			this.label_0.TabIndex = 18;
			this.label_0.Text = "Номер акта";
			this.textBox_0.BackColor = SystemColors.Window;
			this.textBox_0.DataBindings.Add(new Binding("Text", this.eHqoAiqcXw1, "tTC_Doc.numDoc", true));
			this.textBox_0.Location = new Point(8, 22);
			this.textBox_0.Name = "txtNumDoc";
			this.textBox_0.ReadOnly = true;
			this.textBox_0.Size = new Size(175, 20);
			this.textBox_0.TabIndex = 19;
			this.textBox_0.TextChanged += this.textBox_0_TextChanged;
			this.eHqoAiqcXw1.DataSetName = "DataSetTechConnection";
			this.eHqoAiqcXw1.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
			this.label_1.AutoSize = true;
			this.label_1.Location = new Point(186, 6);
			this.label_1.Name = "label3";
			this.label_1.Size = new Size(59, 13);
			this.label_1.TabIndex = 21;
			this.label_1.Text = "Дата акта";
			this.nullableDateTimePicker_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.nullableDateTimePicker_0.DataBindings.Add(new Binding("Value", this.eHqoAiqcXw1, "tTC_Doc.dateDoc", true));
			this.nullableDateTimePicker_0.Location = new Point(189, 22);
			this.nullableDateTimePicker_0.Name = "dateTimePickerDocOut";
			this.nullableDateTimePicker_0.Size = new Size(435, 20);
			this.nullableDateTimePicker_0.TabIndex = 20;
			this.nullableDateTimePicker_0.Value = new DateTime(2013, 4, 29, 14, 38, 3, 750);
			this.nullableDateTimePicker_0.ValueChanged += this.nullableDateTimePicker_0_ValueChanged;
			this.label_2.AutoSize = true;
			this.label_2.Location = new Point(12, 101);
			this.label_2.Name = "label5";
			this.label_2.Size = new Size(45, 13);
			this.label_2.TabIndex = 26;
			this.label_2.Text = "Объект";
			this.textBox_1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_1.BackColor = SystemColors.Window;
			this.textBox_1.Location = new Point(145, 98);
			this.textBox_1.Name = "txtAbnObj";
			this.textBox_1.ReadOnly = true;
			this.textBox_1.Size = new Size(479, 20);
			this.textBox_1.TabIndex = 27;
			this.label_3.AutoSize = true;
			this.label_3.Location = new Point(12, 51);
			this.label_3.Name = "labelNumDateIn";
			this.label_3.Size = new Size(94, 13);
			this.label_3.TabIndex = 22;
			this.label_3.Text = "Номер и дата ТУ";
			this.comboBox_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.comboBox_0.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			this.comboBox_0.AutoCompleteSource = AutoCompleteSource.ListItems;
			this.comboBox_0.DataBindings.Add(new Binding("SelectedValue", this.eHqoAiqcXw1, "tTC_Doc.IdParent", true));
			this.comboBox_0.FormattingEnabled = true;
			this.comboBox_0.Location = new Point(145, 48);
			this.comboBox_0.Name = "cmbNumDateIn";
			this.comboBox_0.Size = new Size(479, 21);
			this.comboBox_0.TabIndex = 23;
			this.comboBox_0.SelectedValueChanged += this.comboBox_0_SelectedValueChanged;
			this.textBox_2.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_2.BackColor = SystemColors.Window;
			this.textBox_2.Location = new Point(145, 74);
			this.textBox_2.Name = "txtAbn";
			this.textBox_2.ReadOnly = true;
			this.textBox_2.Size = new Size(479, 20);
			this.textBox_2.TabIndex = 25;
			this.label_4.AutoSize = true;
			this.label_4.Location = new Point(12, 77);
			this.label_4.Name = "label9";
			this.label_4.Size = new Size(49, 13);
			this.label_4.TabIndex = 24;
			this.label_4.Text = "Абонент";
			this.textBox_3.AcceptsReturn = true;
			this.textBox_3.AcceptsTab = true;
			this.textBox_3.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_3.DataBindings.Add(new Binding("Text", this.eHqoAiqcXw1, "tTC_Doc.Comment", true));
			this.textBox_3.Location = new Point(8, 285);
			this.textBox_3.Multiline = true;
			this.textBox_3.Name = "txtBody";
			this.textBox_3.Size = new Size(619, 52);
			this.textBox_3.TabIndex = 29;
			this.textBox_3.TextChanged += this.textBox_3_TextChanged;
			this.label_5.AutoSize = true;
			this.label_5.Location = new Point(12, 269);
			this.label_5.Name = "label7";
			this.label_5.Size = new Size(77, 13);
			this.label_5.TabIndex = 28;
			this.label_5.Text = "Комментарий";
			this.button_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.button_0.Location = new Point(9, 382);
			this.button_0.Name = "buttonSave";
			this.button_0.Size = new Size(75, 23);
			this.button_0.TabIndex = 30;
			this.button_0.Text = "Сохранить";
			this.button_0.UseVisualStyleBackColor = true;
			this.button_0.Click += this.button_0_Click;
			this.button_1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.button_1.Location = new Point(550, 382);
			this.button_1.Name = "buttonClose";
			this.button_1.Size = new Size(75, 23);
			this.button_1.TabIndex = 31;
			this.button_1.Text = "Закрыть";
			this.button_1.UseVisualStyleBackColor = true;
			this.button_1.Click += this.button_1_Click;
			this.tabControl_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.tabControl_0.Controls.Add(this.tabPage_0);
			this.tabControl_0.Controls.Add(this.tabPage_1);
			this.tabControl_0.Location = new Point(0, 0);
			this.tabControl_0.Name = "tabControl";
			this.tabControl_0.SelectedIndex = 0;
			this.tabControl_0.Size = new Size(638, 369);
			this.tabControl_0.TabIndex = 32;
			this.tabPage_0.Controls.Add(this.groupBox_0);
			this.tabPage_0.Controls.Add(this.groupBox_1);
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
			this.tabPage_0.Size = new Size(630, 343);
			this.tabPage_0.TabIndex = 0;
			this.tabPage_0.Text = "Общие";
			this.tabPage_0.UseVisualStyleBackColor = true;
			this.groupBox_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox_0.Controls.Add(this.textBox_4);
			this.groupBox_0.Controls.Add(this.label_6);
			this.groupBox_0.Controls.Add(this.textBox_5);
			this.groupBox_0.Controls.Add(this.label_7);
			this.groupBox_0.Location = new Point(8, 188);
			this.groupBox_0.Name = "groupBoxApplicant";
			this.groupBox_0.Size = new Size(616, 78);
			this.groupBox_0.TabIndex = 31;
			this.groupBox_0.TabStop = false;
			this.groupBox_0.Text = "Заявитель";
			this.textBox_4.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_4.DataBindings.Add(new Binding("Text", this.eHqoAiqcXw1, "tTC_PerformingTU.BasisApplicant", true));
			this.textBox_4.Location = new Point(165, 45);
			this.textBox_4.Name = "txtBasisApplicant";
			this.textBox_4.Size = new Size(445, 20);
			this.textBox_4.TabIndex = 3;
			this.textBox_4.TextChanged += this.textBox_4_TextChanged;
			this.label_6.AutoSize = true;
			this.label_6.Location = new Point(9, 48);
			this.label_6.Name = "label6";
			this.label_6.Size = new Size(153, 13);
			this.label_6.TabIndex = 2;
			this.label_6.Text = "действующего на основании";
			this.textBox_5.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_5.DataBindings.Add(new Binding("Text", this.eHqoAiqcXw1, "tTC_PerformingTU.FaceApplicant", true));
			this.textBox_5.Location = new Point(165, 19);
			this.textBox_5.Name = "txtFaceApplicant";
			this.textBox_5.Size = new Size(445, 20);
			this.textBox_5.TabIndex = 1;
			this.textBox_5.TextChanged += this.textBox_5_TextChanged;
			this.label_7.AutoSize = true;
			this.label_7.Location = new Point(9, 22);
			this.label_7.Name = "label8";
			this.label_7.Size = new Size(40, 13);
			this.label_7.TabIndex = 0;
			this.label_7.Text = "в лице";
			this.groupBox_1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox_1.Controls.Add(this.textBox_6);
			this.groupBox_1.Controls.Add(this.tZuoNktfyIY);
			this.groupBox_1.Controls.Add(this.textBox_7);
			this.groupBox_1.Controls.Add(this.label_8);
			this.groupBox_1.Location = new Point(8, 117);
			this.groupBox_1.Name = "groupBoSet";
			this.groupBox_1.Size = new Size(616, 70);
			this.groupBox_1.TabIndex = 30;
			this.groupBox_1.TabStop = false;
			this.groupBox_1.Text = "Сетевая организация";
			this.textBox_6.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_6.DataBindings.Add(new Binding("Text", this.eHqoAiqcXw1, "tTC_PerformingTU.BasisNetWork", true));
			this.textBox_6.Location = new Point(165, 45);
			this.textBox_6.Name = "txtBasisNetwork";
			this.textBox_6.Size = new Size(445, 20);
			this.textBox_6.TabIndex = 3;
			this.textBox_6.TextChanged += this.textBox_6_TextChanged;
			this.tZuoNktfyIY.AutoSize = true;
			this.tZuoNktfyIY.Location = new Point(9, 48);
			this.tZuoNktfyIY.Name = "label4";
			this.tZuoNktfyIY.Size = new Size(153, 13);
			this.tZuoNktfyIY.TabIndex = 2;
			this.tZuoNktfyIY.Text = "действующего на основании";
			this.textBox_7.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_7.DataBindings.Add(new Binding("Text", this.eHqoAiqcXw1, "tTC_PerformingTU.FaceNetWork", true));
			this.textBox_7.Location = new Point(165, 19);
			this.textBox_7.Name = "txtFaceNetWork";
			this.textBox_7.Size = new Size(445, 20);
			this.textBox_7.TabIndex = 1;
			this.textBox_7.TextChanged += this.textBox_7_TextChanged;
			this.label_8.AutoSize = true;
			this.label_8.Location = new Point(9, 22);
			this.label_8.Name = "label1";
			this.label_8.Size = new Size(40, 13);
			this.label_8.TabIndex = 0;
			this.label_8.Text = "в лице";
			this.tabPage_1.Controls.Add(this.dataGridViewExcelFilter_0);
			this.tabPage_1.Controls.Add(this.toolStrip_0);
			this.tabPage_1.Location = new Point(4, 22);
			this.tabPage_1.Name = "tabPageFile";
			this.tabPage_1.Padding = new Padding(3);
			this.tabPage_1.Size = new Size(630, 343);
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
			this.dataGridViewExcelFilter_0.Size = new Size(624, 312);
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
			this.bindingSource_0.DataSource = this.eHqoAiqcXw1;
			this.toolStrip_0.Items.AddRange(new ToolStripItem[]
			{
				this.bcDoNmAufdx,
				this.toolStripButton_0,
				this.toolStripButton_1,
				this.toolStripButton_2,
				this.toolStripSeparator_1,
				this.toolStripButton_3,
				this.XldoNswxZle
			});
			this.toolStrip_0.Location = new Point(3, 3);
			this.toolStrip_0.Name = "toolStripFile";
			this.toolStrip_0.Size = new Size(624, 25);
			this.toolStrip_0.TabIndex = 7;
			this.toolStrip_0.Text = "toolStrip1";
			this.bcDoNmAufdx.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.bcDoNmAufdx.DropDownItems.AddRange(new ToolStripItem[]
			{
				this.toolStripMenuItem_0,
				this.toolStripSeparator_0
			});
			this.bcDoNmAufdx.Image = Resources.ElementAdd;
			this.bcDoNmAufdx.ImageTransparentColor = Color.Magenta;
			this.bcDoNmAufdx.Name = "toolBtnAddFile";
			this.bcDoNmAufdx.Size = new Size(29, 22);
			this.bcDoNmAufdx.Text = "Добавить файл";
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
			this.XldoNswxZle.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.XldoNswxZle.Image = Resources.save;
			this.XldoNswxZle.ImageTransparentColor = Color.Magenta;
			this.XldoNswxZle.Name = "toolBtnSaveFile";
			this.XldoNswxZle.Size = new Size(23, 22);
			this.XldoNswxZle.Text = "Сохранить файл на диск";
			this.XldoNswxZle.Click += this.toolStripMenuItem_7_Click;
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
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(637, 417);
			base.Controls.Add(this.tabControl_0);
			base.Controls.Add(this.button_1);
			base.Controls.Add(this.button_0);
			base.Name = "FormActPerformingTU";
			this.Text = "Добавление/редактирование акта вуполнения ТУ";
			base.FormClosed += this.FormActPerformingTU_FormClosed;
			base.Load += this.FormActPerformingTU_Load;
			((ISupportInitialize)this.eHqoAiqcXw1).EndInit();
			this.tabControl_0.ResumeLayout(false);
			this.tabPage_0.ResumeLayout(false);
			this.tabPage_0.PerformLayout();
			this.groupBox_0.ResumeLayout(false);
			this.groupBox_0.PerformLayout();
			this.groupBox_1.ResumeLayout(false);
			this.groupBox_1.PerformLayout();
			this.tabPage_1.ResumeLayout(false);
			this.tabPage_1.PerformLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_0).EndInit();
			((ISupportInitialize)this.bindingSource_0).EndInit();
			this.toolStrip_0.ResumeLayout(false);
			this.toolStrip_0.PerformLayout();
			this.contextMenuStrip_0.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		[CompilerGenerated]
		private void method_18()
		{
			this.bindingSource_0.ResetBindings(false);
		}

		private int int_0;

		private int int_1;

		private int int_2;

		private int int_3;

		private int itEoAbhpdmf;

		private bool bool_0;

		private Dictionary<string, FileWatcherArgsAddl> dictionary_0;

		private string string_0;

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

		private Class10 eHqoAiqcXw1;

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

		private ToolStripDropDownButton bcDoNmAufdx;

		private ToolStripMenuItem toolStripMenuItem_0;

		private ToolStripSeparator toolStripSeparator_0;

		private ToolStripButton toolStripButton_0;

		private ToolStripButton toolStripButton_1;

		private ToolStripButton toolStripButton_2;

		private ToolStripSeparator toolStripSeparator_1;

		private ToolStripButton toolStripButton_3;

		private ToolStripButton XldoNswxZle;

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

		private GroupBox groupBox_0;

		private TextBox textBox_4;

		private Label label_6;

		private TextBox textBox_5;

		private Label label_7;

		private GroupBox groupBox_1;

		private TextBox textBox_6;

		private Label tZuoNktfyIY;

		private TextBox textBox_7;

		private Label label_8;
	}
}
