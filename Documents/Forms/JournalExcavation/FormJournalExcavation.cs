using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ControlsLbr.DataGridViewExcelFilter;
using DataSql;
using Documents.Properties;
using FormLbr;
using FormLbr.Classes;

namespace Documents.Forms.JournalExcavation
{
	public partial class FormJournalExcavation : FormBase
	{
		public FormJournalExcavation()
		{
			
			this.int_0 = -1;
			 
			this.InitializeComponent();
			this.method_0();
			this.toolStripButton_27.Visible = false;
		}

		private void method_0()
		{
			this.dateTimePicker_1.Value = new DateTime(DateTime.Now.Year, 1, 1);
			this.dateTimePicker_0.Value = this.dateTimePicker_1.Value.AddYears(1).AddSeconds(-1.0);
			this.dataTable_0 = new DataTable("vJ_ExcavationFile");
			this.dataTable_0.Columns.Add(new DataColumn("id", typeof(int)));
			this.dataTable_0.Columns.Add(new DataColumn("idExcavation", typeof(int)));
			this.dataTable_0.Columns.Add(new DataColumn("typeFile", typeof(int)));
			this.dataTable_0.Columns.Add(new DataColumn("typefileName", typeof(string)));
			this.dataTable_0.Columns.Add(new DataColumn("FileName", typeof(string)));
		}

		private void FormJournalExcavation_Load(object sender, EventArgs e)
		{
			this.method_2(null);
			this.method_3();
		}

		private void toolStripButton_0_Click(object sender, EventArgs e)
		{
			this.method_2(null);
		}

		private void toolStripButton_1_Click(object sender, EventArgs e)
		{
			this.dateTimePicker_1.Value = new DateTime(DateTime.Now.Year, 1, 1);
			this.dateTimePicker_0.Value = this.dateTimePicker_1.Value.AddYears(1).AddSeconds(-1.0);
			this.checkBox_1.Checked = false;
			this.checkBox_0.Checked = true;
			this.method_2(null);
		}

		private string method_1()
		{
			string text = string.Format("where dateBeg <= '{0}' and (maxStatusDate >= '{1}' or maxStatusDate is null)\r\n", this.dateTimePicker_0.Value.Date.ToString("yyyy.MM.dd"), this.dateTimePicker_1.Value.Date.AddDays(1.0).AddSeconds(-1.0).ToString("yyyy.MM.dd HH:mm:ss"));
			if (this.checkBox_1.Checked)
			{
				text += " and (agreed = 1) ";
			}
			if (this.checkBox_0.Checked)
			{
				text += " and (datePay is null) ";
			}
			return text;
		}

		private void method_2(int? nullable_0 = null)
		{
			if (nullable_0 == null)
			{
				nullable_0 = new int?(this.int_0);
			}
			string filter = "id = -1";
			this.bindingSource_2.Filter = (this.bindingSource_0.Filter = (this.bindingSource_3.Filter = (this.bindingSource_7.Filter = (this.bindingSource_4.Filter = (this.bindingSource_5.Filter = (this.bindingSource_6.Filter = (this.bindingSource_8.Filter = filter)))))));
			base.SelectSqlData(this.class130_0, this.class130_0.vJ_Excavation, true, this.method_1());
			base.SelectSqlData(this.class130_0, this.class130_0.vJ_ExcavationAddress, true);
			base.SelectSqlData(this.class130_0, this.class130_0.vJ_ExcavationSchmObj, true);
			base.SelectSqlData(this.class130_0, this.class130_0.vJ_ExcavationStatus, true);
			base.SelectSqlData(this.class130_0, this.class130_0.vJ_ExcavationSurface, true);
			this.method_4();
			base.SelectSqlData(this.dataTable_0, true, "order by filename", null, false, 0);
			this.bindingSource_8.DataSource = this.dataTable_0;
			this.method_3();
			if (nullable_0 != null)
			{
				this.dataGridViewExcelFilter_0.SearchGrid(this.dataGridViewTextBoxColumn_32.Name, nullable_0.ToString(), false);
			}
		}

		private void method_3()
		{
			this.dataGridViewTextBoxColumn_8.Visible = false;
			this.dataGridViewTextBoxColumn_38.Visible = false;
			this.dataGridViewTextBoxColumn_47.Visible = false;
			this.dataGridViewTextBoxColumn_12.Visible = false;
			this.dataGridViewTextBoxColumn_28.Visible = false;
			this.dataGridViewTextBoxColumn_21.Visible = false;
		}

		private void method_4()
		{
			string b = (this.treeView_0.SelectedNode != null) ? this.treeView_0.SelectedNode.Text : "";
			this.treeView_0.Nodes.Clear();
			TreeNode treeNode = new TreeNode("Все типы");
			this.treeView_0.Nodes.Add(treeNode);
			if (treeNode.Text == b)
			{
				this.treeView_0.SelectedNode = treeNode;
			}
			DataTable dataTable = base.SelectSqlData("tR_Classifier", true, " where ParentKey = ';Excavation;TypeFile;' and isGRoup = 0 and deleted = 0 order by value");
			this.toolStripSplitButton_0.DropDownItems.Clear();
			foreach (object obj in dataTable.Rows)
			{
				DataRow dataRow = (DataRow)obj;
				TreeNode treeNode2 = new TreeNode(dataRow["Name"].ToString());
				treeNode2.Tag = dataRow["id"];
				treeNode.Nodes.Add(treeNode2);
				if (treeNode2.Text == b)
				{
					this.treeView_0.SelectedNode = treeNode2;
				}
				ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem(dataRow["Name"].ToString());
				toolStripMenuItem.Tag = dataRow["id"];
				toolStripMenuItem.Click += this.method_6;
				this.toolStripSplitButton_0.DropDownItems.Add(toolStripMenuItem);
			}
			treeNode.ExpandAll();
		}

		private void bindingSource_1_CurrentChanged(object sender, EventArgs e)
		{
			if (this.bindingSource_1.Current != null)
			{
				this.int_0 = Convert.ToInt32(((DataRowView)this.bindingSource_1.Current).Row["id"]);
				this.bindingSource_2.Filter = (this.bindingSource_0.Filter = "idExcavation = " + this.int_0.ToString());
				this.bindingSource_3.Filter = "idExcavation  = " + this.int_0.ToString() + " and idType = " + 1.ToString();
				this.bindingSource_7.Filter = "idExcavation  = " + this.int_0.ToString() + " and idType = " + 2.ToString();
				this.bindingSource_4.Filter = "idExcavation = " + this.int_0.ToString() + " and idType = " + 3.ToString();
				this.bindingSource_5.Filter = "idExcavation = " + this.int_0.ToString() + " and idType = " + 1.ToString();
				this.bindingSource_6.Filter = "idExcavation = " + this.int_0.ToString() + " and idType = " + 2.ToString();
				this.bindingSource_8.Filter = "idExcavation = " + this.int_0.ToString();
				if (this.treeView_0.SelectedNode != null && this.treeView_0.SelectedNode.Tag != null)
				{
					this.bindingSource_8.Filter = "idExcavation = " + this.int_0.ToString() + " and typeFile = " + this.treeView_0.SelectedNode.Tag.ToString();
				}
			}
		}

		private void toolStripButton_2_Click(object sender, EventArgs e)
		{
			FormExcavationAddEdit2 form = new FormExcavationAddEdit2(-1);
			form.SqlSettings = this.SqlSettings;
			form.MdiParent = base.MdiParent;
			form.Show();
			form.FormClosed -= this.method_5;
			form.FormClosed += this.method_5;
		}

		private void method_5(object sender, FormClosedEventArgs e)
		{
			FormExcavationAddEdit2 form = (FormExcavationAddEdit2)sender;
			if (form.DialogResult == DialogResult.OK)
			{
				this.method_2(new int?(form.int_0));
			}
		}

		private void toolStripButton_3_Click(object sender, EventArgs e)
		{
			FormExcavationAddEdit2 form = new FormExcavationAddEdit2(this.int_0);
			form.SqlSettings = this.SqlSettings;
			form.MdiParent = base.MdiParent;
			form.Show();
			form.FormClosed -= this.method_5;
			form.FormClosed += this.method_5;
		}

		private void dataGridViewExcelFilter_0_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (this.toolStrip_0.Visible && this.toolStrip_0.Enabled && this.toolStripButton_3.Visible && this.toolStripButton_3.Enabled)
			{
				this.toolStripButton_3_Click(sender, e);
			}
		}

		private void toolStripButton_4_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_0.CurrentRow != null && MessageBox.Show("Вы действительно хотите удалить текущую раскопку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes && base.DeleteSqlDataById(this.class130_0.tJ_Excavation, this.int_0))
			{
				this.dataGridViewExcelFilter_0.Rows.Remove(this.dataGridViewExcelFilter_0.CurrentRow);
			}
		}

		private void toolStripButton_8_Click(object sender, EventArgs e)
		{
			new Form64
			{
				SqlSettings = this.SqlSettings,
				MdiParent = base.MdiParent
			}.Show();
		}

		private void toolStripButton_31_Click(object sender, EventArgs e)
		{
			this.method_2(null);
		}

		private void toolStripButton_27_Click(object sender, EventArgs e)
		{
			DialogResult dialogResult = MessageBox.Show("Удалить все данные перед загрузкой", "Удаление", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
			if (dialogResult == DialogResult.Yes)
			{
				SqlDataConnect sqlDataConnect = new SqlDataConnect();
				sqlDataConnect.OpenConnection(this.SqlSettings);
				new SqlCommand("delete tJ_Excavation", sqlDataConnect.Connection).ExecuteNonQuery();
			}
			if (dialogResult != DialogResult.Cancel)
			{
				SqlDataCommand sqlDataCommand = new SqlDataCommand(new SQLSettings("ulges-sql", "PTS", "WINDOWS", "", ""));
				DataTable dataTable = sqlDataCommand.SelectSqlData("ExWorkList", false, " order by date_begin desc ", null);
				DataTable dataTable2 = sqlDataCommand.SelectSqlData("ExEnums2ExWrkList", false, "", null);
				sqlDataCommand.SelectSqlData("ExEnums", false, "", null);
				DataTable dataTable3 = sqlDataCommand.SelectSqlData("tbl_Streets", false, "", null);
				DataTable dataTable4 = base.SelectSqlData("tr_kladrStreet", false, " where kladrObjId = 24");
				DataTable dataTable5 = base.SelectSqlData("tSchm_ObjList", false, " where typeCodeid = 546 and deleted = 0 order by name");
				foreach (object obj in dataTable.Rows)
				{
					DataRow dataRow = (DataRow)obj;
					DataRow dataRow2 = this.class130_0.tJ_Excavation.NewRow();
					dataRow2["dateBeg"] = dataRow["date_Begin"];
					dataRow2["idContractor"] = 434002;
					switch (Convert.ToInt32(dataRow["excavation_type"]))
					{
					case 1:
						dataRow2["typeWork"] = 1049;
						break;
					case 2:
						dataRow2["typeWork"] = 1050;
						break;
					case 3:
						dataRow2["typeWork"] = 1051;
						break;
					case 4:
						dataRow2["typeWork"] = 1052;
						break;
					case 5:
						dataRow2["typeWork"] = 1053;
						break;
					}
					dataRow2["datebegOrder"] = dataRow["order_date_begin"];
					dataRow2["dateEndOrder"] = dataRow["order_date_end"];
					dataRow2["numpermission"] = dataRow["num_permission"];
					dataRow2["datepermission"] = dataRow["date_permission"];
					dataRow2["dateUnderAsphalt"] = dataRow["date_transfer"];
					dataRow2["dateAsphalt"] = dataRow["date_asphalting"];
					dataRow2["dateEnd"] = dataRow["date_End"];
					if (dataRow["payment_month"] != DBNull.Value)
					{
						dataRow2["DatePay"] = new DateTime(Convert.ToDateTime(dataRow["date_Begin"]).Year, Convert.ToInt32(dataRow["payment_month"]), 1);
					}
					this.class130_0.tJ_Excavation.Rows.Add(dataRow2);
					int num = base.InsertSqlDataOneRow(this.class130_0, this.class130_0.tJ_Excavation);
					this.class130_0.tJ_Excavation.Clear();
					dataRow2 = this.class130_0.tJ_ExcavationStatus.NewRow();
					dataRow2["idExcavation"] = num;
					dataRow2["idType"] = 1;
					switch (Convert.ToInt32(dataRow["order_state"]))
					{
					case 1:
						dataRow2["idStatus"] = 1073;
						break;
					case 2:
						dataRow2["idStatus"] = 1074;
						break;
					case 3:
						dataRow2["idStatus"] = 1076;
						break;
					case 4:
						dataRow2["idStatus"] = 1072;
						break;
					}
					dataRow2["dateChange"] = dataRow["date_begin"];
					this.class130_0.tJ_ExcavationStatus.Rows.Add(dataRow2);
					base.InsertSqlDataOneRow(this.class130_0, this.class130_0.tJ_ExcavationStatus);
					this.class130_0.tJ_ExcavationStatus.Clear();
					dataRow2 = this.class130_0.tJ_ExcavationStatus.NewRow();
					dataRow2["idExcavation"] = num;
					dataRow2["idType"] = 2;
					switch (Convert.ToInt32(dataRow["excavation_state"]))
					{
					case 1:
						dataRow2["idStatus"] = 1099;
						break;
					case 2:
						dataRow2["idStatus"] = 1096;
						break;
					case 3:
						dataRow2["idStatus"] = 1100;
						break;
					case 4:
						dataRow2["idStatus"] = 1097;
						break;
					case 5:
						dataRow2["idStatus"] = 1102;
						break;
					case 6:
						dataRow2["idStatus"] = 1101;
						break;
					case 7:
						dataRow2["idStatus"] = 1103;
						break;
					case 8:
						dataRow2["idStatus"] = 1104;
						break;
					}
					dataRow2["dateChange"] = dataRow["date_begin"];
					this.class130_0.tJ_ExcavationStatus.Rows.Add(dataRow2);
					base.InsertSqlDataOneRow(this.class130_0, this.class130_0.tJ_ExcavationStatus);
					this.class130_0.tJ_ExcavationStatus.Clear();
					dataRow2 = this.class130_0.tJ_ExcavationAddress.NewRow();
					dataRow2["idExcavation"] = num;
					switch (Convert.ToInt32(dataRow["district"]))
					{
					case 1:
						dataRow2["idregion"] = 196;
						break;
					case 2:
						dataRow2["idregion"] = 198;
						break;
					case 3:
						dataRow2["idregion"] = 197;
						break;
					case 4:
						dataRow2["idregion"] = 199;
						break;
					}
					DataRow[] array = dataTable3.Select("codestreet = " + dataRow["address"].ToString());
					if (array.Length == 0)
					{
						goto IL_9B5;
					}
					string text = array[0]["Prefix"].ToString();
					if (text[text.Length - 1] == '.')
					{
						text = text.Remove(text.Length - 1);
					}
					string text2 = array[0]["Name"].ToString();
					if (text == "пр-т")
					{
						text = "пр-кт";
					}
					if (text == "шоссе")
					{
						text = "ш";
					}
					if (text == "площадь")
					{
						text = "пл";
					}
					if (text == "бульвар")
					{
						text = "б-р";
					}
					if (text2 == "К. Маркса")
					{
						text2 = "Карла Маркса";
					}
					if (text2 == "Л. Шевцовой")
					{
						text2 = "Любови Шевцовой";
					}
					if (text2 == "К. Либкнехта")
					{
						text2 = "Карла Либкнехта";
					}
					if (text2 == "Р.Люксембург")
					{
						text2 = "Розы Люксембург";
					}
					if (text2 == "Б. Хитрового")
					{
						text2 = "Б.Хитрово";
					}
					if (text2 == "Вр.Михайлова")
					{
						text2 = "Врача Михайлова";
					}
					if (text2 == "У.Громовой")
					{
						text2 = "Ульяны Громовой";
					}
					if (text2 == "40 лет Победы")
					{
						text2 = "40-летия Победы";
					}
					if (text2 == "50 лет ВЛКСМ")
					{
						text2 = "50-летия ВЛКСМ";
					}
					if (text2 == "Героя Аверьянова")
					{
						text2 = "Героя России Аверьянова";
					}
					if (text2 == "УКСМ" && text == "поселок")
					{
						text = "ул";
					}
					if (text2 == "Степана Разина" && text == "спуск")
					{
						text2 = "Спуск Степана Разина";
						text = "ул";
					}
					if (text == "1 пер")
					{
						text2 += " 1-й";
						text = "пер";
					}
					if (text == "2 пер")
					{
						text2 += " 2-й";
						text = "пер";
					}
					if (text == "3 пер")
					{
						text2 += " 3-й";
						text = "пер";
					}
					if (text2 == "Лазо 2-й")
					{
						text2 = "Сергея Лазо 2-й";
					}
					if (text2 == "Хо Ши Мина" && text == "ул")
					{
						text = "пр-кт";
					}
					DataRow[] array2 = dataTable4.Select(string.Concat(new string[]
					{
						"name = '",
						text2,
						"' and Socr = '",
						text,
						"'"
					}));
					if (array2.Length == 0)
					{
						using (StreamWriter streamWriter = new StreamWriter("excavation.log", true))
						{
							streamWriter.WriteLine(text2 + "  " + text);
							goto IL_9C0;
						}
						goto IL_9B5;
					}
					dataRow2["idStreet"] = array2[0]["id"];
					IL_9C0:
					dataRow2["House"] = dataRow["address_note"];
					this.class130_0.tJ_ExcavationAddress.Rows.Add(dataRow2);
					base.InsertSqlDataOneRow(this.class130_0, this.class130_0.tJ_ExcavationAddress);
					this.class130_0.tJ_ExcavationAddress.Clear();
					dataRow2 = this.class130_0.tJ_ExcavationSchmObj.NewRow();
					dataRow2["idExcavation"] = num;
					DataRow[] array3 = dataTable5.Select("Name = '" + dataRow["cable_name"].ToString() + "'");
					dataRow2["nameKL"] = dataRow["cable_name"];
					if (array3.Length != 0)
					{
						dataRow2["idKL"] = array3[0]["id"];
					}
					this.class130_0.tJ_ExcavationSchmObj.Rows.Add(dataRow2);
					base.InsertSqlDataOneRow(this.class130_0, this.class130_0.tJ_ExcavationSchmObj);
					this.class130_0.tJ_ExcavationSchmObj.Clear();
					foreach (DataRow dataRow3 in dataTable2.Select("ex_id = " + dataRow["id"].ToString() + " and enum_code = 4"))
					{
						dataRow2 = this.class130_0.tJ_ExcavationSurface.NewRow();
						dataRow2["idExcavation"] = num;
						dataRow2["idType"] = 1;
						switch (Convert.ToInt32(dataRow3["enum_num_value"]))
						{
						case 1:
							dataRow2["idSurface"] = 1060;
							break;
						case 2:
							dataRow2["idSurface"] = 1061;
							break;
						case 3:
							dataRow2["idSurface"] = 1062;
							break;
						case 4:
							dataRow2["idSurface"] = 1063;
							break;
						case 5:
							dataRow2["idSurface"] = 1064;
							break;
						case 6:
							dataRow2["idSurface"] = 1065;
							break;
						case 7:
							dataRow2["idSurface"] = 1066;
							break;
						}
						this.class130_0.tJ_ExcavationSurface.Rows.Add(dataRow2);
						base.InsertSqlDataOneRow(this.class130_0, this.class130_0.tJ_ExcavationSurface);
						this.class130_0.tJ_ExcavationSurface.Clear();
					}
					foreach (DataRow dataRow4 in dataTable2.Select("ex_id = " + dataRow["id"].ToString() + " and enum_code = 9"))
					{
						dataRow2 = this.class130_0.tJ_ExcavationSurface.NewRow();
						dataRow2["idExcavation"] = num;
						dataRow2["idType"] = 2;
						dataRow2["Value"] = dataRow4["quantity"];
						switch (Convert.ToInt32(dataRow4["enum_num_value"]))
						{
						case 1:
							dataRow2["idSurface"] = 1060;
							dataRow2["unit"] = "кв.м";
							break;
						case 2:
							dataRow2["idSurface"] = 1061;
							dataRow2["unit"] = "кв.м";
							break;
						case 3:
							dataRow2["idSurface"] = 1063;
							dataRow2["unit"] = "кв.м";
							break;
						case 4:
							dataRow2["idSurface"] = 1066;
							dataRow2["unit"] = "м";
							break;
						case 5:
							dataRow2["idSurface"] = 1062;
							dataRow2["unit"] = "кв.м";
							break;
						case 6:
							dataRow2["idSurface"] = 1064;
							dataRow2["unit"] = "кв.м";
							break;
						case 7:
							dataRow2["idSurface"] = 1066;
							break;
						}
						this.class130_0.tJ_ExcavationSurface.Rows.Add(dataRow2);
						base.InsertSqlDataOneRow(this.class130_0, this.class130_0.tJ_ExcavationSurface);
						this.class130_0.tJ_ExcavationSurface.Clear();
					}
					foreach (DataRow dataRow5 in dataTable2.Select("ex_id = " + dataRow["id"].ToString() + " and enum_code = 7"))
					{
						dataRow2 = this.class130_0.tJ_ExcavationSurface.NewRow();
						dataRow2["idExcavation"] = num;
						dataRow2["comment"] = dataRow5["note"];
						dataRow2["idType"] = 3;
						dataRow2["Value"] = dataRow5["quantity"];
						switch (Convert.ToInt32(dataRow5["enum_num_value"]))
						{
						case 1:
							dataRow2["idSurface"] = 1055;
							dataRow2["unit"] = "тонн";
							break;
						case 2:
							dataRow2["idSurface"] = 1056;
							dataRow2["unit"] = "кг";
							break;
						case 3:
							dataRow2["idSurface"] = 1057;
							dataRow2["unit"] = "тонн";
							break;
						case 4:
							dataRow2["idSurface"] = 1058;
							dataRow2["unit"] = "м";
							break;
						}
						this.class130_0.tJ_ExcavationSurface.Rows.Add(dataRow2);
						base.InsertSqlDataOneRow(this.class130_0, this.class130_0.tJ_ExcavationSurface);
						this.class130_0.tJ_ExcavationSurface.Clear();
					}
					if (dataRow["permission_file_name"] != DBNull.Value)
					{
						string text3 = dataRow["permission_file_name"].ToString();
						dataRow2 = this.class130_0.tJ_ExcavationFile.NewRow();
						dataRow2["idExcavation"] = num;
						dataRow2["typeFile"] = 1106;
						dataRow2["FileName"] = text3;
						if (File.Exists(text3))
						{
							dataRow2["File"] = File.ReadAllBytes(text3);
						}
						this.class130_0.tJ_ExcavationFile.Rows.Add(dataRow2);
						base.InsertSqlDataOneRow(this.class130_0, this.class130_0.tJ_ExcavationFile);
						this.class130_0.tJ_ExcavationFile.Clear();
					}
					if (dataRow["photo_dir"] == DBNull.Value)
					{
						continue;
					}
					string text4 = dataRow["photo_dir"].ToString();
					DirectoryInfo directoryInfo = new DirectoryInfo(text4);
					if (Directory.Exists(text4) && directoryInfo.GetFiles().Count<System.IO.FileInfo>() != 0 && directoryInfo.GetFiles().Count<System.IO.FileInfo>() <= 10)
					{
						foreach (System.IO.FileInfo fileInfo in directoryInfo.GetFiles())
						{
							dataRow2 = this.class130_0.tJ_ExcavationFile.NewRow();
							dataRow2["idExcavation"] = num;
							dataRow2["typeFile"] = 1107;
							dataRow2["FileName"] = fileInfo.FullName;
							dataRow2["File"] = File.ReadAllBytes(fileInfo.FullName);
							this.class130_0.tJ_ExcavationFile.Rows.Add(dataRow2);
							base.InsertSqlDataOneRow(this.class130_0, this.class130_0.tJ_ExcavationFile);
							this.class130_0.tJ_ExcavationFile.Clear();
						}
						continue;
					}
					dataRow2 = this.class130_0.tJ_ExcavationFile.NewRow();
					dataRow2["idExcavation"] = num;
					dataRow2["typeFile"] = 1107;
					dataRow2["FileName"] = text4;
					this.class130_0.tJ_ExcavationFile.Rows.Add(dataRow2);
					base.InsertSqlDataOneRow(this.class130_0, this.class130_0.tJ_ExcavationFile);
					this.class130_0.tJ_ExcavationFile.Clear();
					continue;
					IL_9B5:
					MessageBox.Show("Что то с адресом");
					goto IL_9C0;
				}
				this.method_2(null);
				MessageBox.Show("Ура!!!");
			}
		}

		private void toolStripButton_29_Click(object sender, EventArgs e)
		{
			new FormReportAct(this.int_0)
			{
				MdiParent = base.MdiParent,
				SqlSettings = this.SqlSettings
			}.Show();
		}

		private void toolStripButton_30_Click(object sender, EventArgs e)
		{
			new Form68
			{
				MdiParent = base.MdiParent,
				SqlSettings = this.SqlSettings
			}.Show();
		}

		private void toolStripButton_32_Click(object sender, EventArgs e)
		{
			new Form66
			{
				MdiParent = base.MdiParent,
				SqlSettings = this.SqlSettings
			}.Show();
		}

		private void toolStripButton_5_Click(object sender, EventArgs e)
		{
			int num = this.int_0;
			Form61 form = new Form61(-1, this.int_0);
			form.SqlSettings = this.SqlSettings;
			if (form.ShowDialog() == DialogResult.OK)
			{
				base.SelectSqlData(this.class130_0, this.class130_0.vJ_Excavation, true, this.method_1());
				this.dataGridViewExcelFilter_0.SearchGrid(this.dataGridViewTextBoxColumn_32.Name, num.ToString(), false);
				base.SelectSqlData(this.class130_0, this.class130_0.vJ_ExcavationAddress, true);
				this.dataGridViewExcelFilter_1.SearchGrid(this.dataGridViewTextBoxColumn_4.Name, form.Id.ToString(), false);
			}
		}

		private void toolStripButton_6_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_1.CurrentRow != null)
			{
				int num = this.int_0;
				Form61 form = new Form61(Convert.ToInt32(this.dataGridViewExcelFilter_1.CurrentRow.Cells[this.dataGridViewTextBoxColumn_4.Name].Value), this.int_0);
				form.SqlSettings = this.SqlSettings;
				if (form.ShowDialog() == DialogResult.OK)
				{
					base.SelectSqlData(this.class130_0, this.class130_0.vJ_Excavation, true, this.method_1());
					this.dataGridViewExcelFilter_0.SearchGrid(this.dataGridViewTextBoxColumn_32.Name, num.ToString(), false);
					base.SelectSqlData(this.class130_0, this.class130_0.vJ_ExcavationAddress, true);
					this.dataGridViewExcelFilter_1.SearchGrid(this.dataGridViewTextBoxColumn_4.Name, form.Id.ToString(), false);
				}
			}
		}

		private void toolStripButton_7_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_1.CurrentRow != null && MessageBox.Show("Вы действительно хотите удалить текущий адрес?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes && base.DeleteSqlDataById(this.class130_0.tJ_ExcavationAddress, Convert.ToInt32(this.dataGridViewExcelFilter_1.CurrentRow.Cells[this.dataGridViewTextBoxColumn_4.Name].Value)))
			{
				this.dataGridViewExcelFilter_1.Rows.Remove(this.dataGridViewExcelFilter_1.CurrentRow);
				int num = this.int_0;
				base.SelectSqlData(this.class130_0, this.class130_0.vJ_Excavation, true, this.method_1());
				this.dataGridViewExcelFilter_0.SearchGrid(this.dataGridViewTextBoxColumn_32.Name, num.ToString(), false);
			}
		}

		private void dataGridViewExcelFilter_1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (this.toolStripButton_6.Visible && this.toolStripButton_6.Enabled && this.toolStrip_2.Visible && this.toolStrip_2.Enabled)
			{
				this.toolStripButton_6_Click(sender, e);
			}
		}

		private void toolStripButton_9_Click(object sender, EventArgs e)
		{
			int num = this.int_0;
			Form65 form = new Form65(-1, this.int_0);
			form.SqlSettings = this.SqlSettings;
			if (form.ShowDialog() == DialogResult.OK)
			{
				base.SelectSqlData(this.class130_0, this.class130_0.vJ_Excavation, true, this.method_1());
				this.dataGridViewExcelFilter_0.SearchGrid(this.dataGridViewTextBoxColumn_32.Name, num.ToString(), false);
				base.SelectSqlData(this.class130_0, this.class130_0.vJ_ExcavationSchmObj, true);
				this.dataGridViewExcelFilter_2.SearchGrid(this.dataGridViewTextBoxColumn_8.Name, form.method_2().ToString(), false);
			}
		}

		private void toolStripButton_10_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_2.CurrentRow != null)
			{
				int num = this.int_0;
				if (new Form65(Convert.ToInt32(this.dataGridViewExcelFilter_2.CurrentRow.Cells[this.dataGridViewTextBoxColumn_8.Name].Value), this.int_0)
				{
					SqlSettings = this.SqlSettings
				}.ShowDialog() == DialogResult.OK)
				{
					base.SelectSqlData(this.class130_0, this.class130_0.vJ_Excavation, true, this.method_1());
					this.dataGridViewExcelFilter_0.SearchGrid(this.dataGridViewTextBoxColumn_32.Name, num.ToString(), false);
					base.SelectSqlData(this.class130_0, this.class130_0.vJ_ExcavationSchmObj, true);
					this.dataGridViewExcelFilter_2.SearchGrid(this.dataGridViewTextBoxColumn_8.Name, this.dataGridViewExcelFilter_2.CurrentRow.Cells[this.dataGridViewTextBoxColumn_8.Name].Value.ToString(), false);
				}
			}
		}

		private void dataGridViewExcelFilter_2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (this.toolStripButton_10.Visible && this.toolStripButton_10.Enabled && this.toolStrip_3.Visible && this.toolStrip_3.Enabled)
			{
				this.toolStripButton_10_Click(sender, e);
			}
		}

		private void toolStripButton_11_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_2.CurrentRow != null && MessageBox.Show("Вы действительно хотите удалить текущую кабельную линию?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes && base.DeleteSqlDataById(this.class130_0.tJ_ExcavationSchmObj, Convert.ToInt32(this.dataGridViewExcelFilter_2.CurrentRow.Cells[this.dataGridViewTextBoxColumn_8.Name].Value)))
			{
				this.dataGridViewExcelFilter_2.Rows.Remove(this.dataGridViewExcelFilter_2.CurrentRow);
				int num = this.int_0;
				base.SelectSqlData(this.class130_0, this.class130_0.vJ_Excavation, true, this.method_1());
				this.dataGridViewExcelFilter_0.SearchGrid(this.dataGridViewTextBoxColumn_32.Name, num.ToString(), false);
			}
		}

		private void dataGridViewExcelFilter_0_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
		{
			this.dataGridViewExcelFilter_0.AutoResizeRow(e.RowIndex);
		}

		private void dataGridViewExcelFilter_0_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				if (this.dataGridViewExcelFilter_0[this.dataGridViewFilterTextBoxColumn_13.Name, e.RowIndex].Value != null && this.dataGridViewExcelFilter_0[this.dataGridViewFilterTextBoxColumn_13.Name, e.RowIndex].Value != DBNull.Value)
				{
					e.CellStyle.BackColor = Color.LightSkyBlue;
				}
				if (this.dataGridViewExcelFilter_0[this.dataGridViewTextBoxColumn_37.Name, e.RowIndex].Value != null && this.dataGridViewExcelFilter_0[this.dataGridViewTextBoxColumn_37.Name, e.RowIndex].Value != DBNull.Value)
				{
					e.CellStyle.BackColor = Color.LightGreen;
				}
				if (this.dataGridViewExcelFilter_0[this.dataGridViewFilterTextBoxColumn_15.Name, e.RowIndex].Value != null && this.dataGridViewExcelFilter_0[this.dataGridViewFilterTextBoxColumn_15.Name, e.RowIndex].Value != DBNull.Value)
				{
					e.CellStyle.BackColor = Color.LightGray;
				}
				if (this.dataGridViewExcelFilter_0[this.dataGridViewFilterCheckBoxColumn_0.Name, e.RowIndex].Value != null && this.dataGridViewExcelFilter_0[this.dataGridViewFilterCheckBoxColumn_0.Name, e.RowIndex].Value != DBNull.Value && Convert.ToBoolean(this.dataGridViewExcelFilter_0[this.dataGridViewFilterCheckBoxColumn_0.Name, e.RowIndex].Value))
				{
					e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Italic);
				}
			}
		}

		private void toolStripButton_12_Click(object sender, EventArgs e)
		{
			int num = this.int_0;
			Form62 form = new Form62(-1, this.int_0, (Enum18)1);
			form.SqlSettings = this.SqlSettings;
			if (form.ShowDialog() == DialogResult.OK)
			{
				base.SelectSqlData(this.class130_0, this.class130_0.vJ_Excavation, true, this.method_1());
				this.dataGridViewExcelFilter_0.SearchGrid(this.dataGridViewTextBoxColumn_32.Name, num.ToString(), false);
				base.SelectSqlData(this.class130_0, this.class130_0.vJ_ExcavationStatus, true);
				this.dataGridViewExcelFilter_3.SearchGrid(this.dataGridViewTextBoxColumn_38.Name, form.method_0().ToString(), false);
			}
		}

		private void toolStripButton_13_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_3.CurrentRow != null)
			{
				Form62 form = new Form62(Convert.ToInt32(this.dataGridViewExcelFilter_3.CurrentRow.Cells[this.dataGridViewTextBoxColumn_38.Name].Value), this.int_0, (Enum18)1);
				form.SqlSettings = this.SqlSettings;
				if (form.ShowDialog() == DialogResult.OK)
				{
					int num = this.int_0;
					base.SelectSqlData(this.class130_0, this.class130_0.vJ_Excavation, true, this.method_1());
					this.dataGridViewExcelFilter_0.SearchGrid(this.dataGridViewTextBoxColumn_32.Name, num.ToString(), false);
					base.SelectSqlData(this.class130_0, this.class130_0.vJ_ExcavationStatus, true);
					this.dataGridViewExcelFilter_3.SearchGrid(this.dataGridViewTextBoxColumn_38.Name, form.method_0().ToString(), false);
				}
			}
		}

		private void dataGridViewExcelFilter_3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (this.toolStripButton_13.Visible && this.toolStripButton_13.Enabled && this.toolStrip_4.Visible && this.toolStrip_4.Enabled)
			{
				this.toolStripButton_13_Click(sender, e);
			}
		}

		private void toolStripButton_14_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_3.CurrentRow != null && MessageBox.Show("Вы действительно хотите удалить текущий статус ордера?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes && base.DeleteSqlDataById(this.class130_0.tJ_ExcavationStatus, Convert.ToInt32(this.dataGridViewExcelFilter_3.CurrentRow.Cells[this.dataGridViewTextBoxColumn_38.Name].Value)))
			{
				this.dataGridViewExcelFilter_3.Rows.Remove(this.dataGridViewExcelFilter_3.CurrentRow);
				int num = this.int_0;
				base.SelectSqlData(this.class130_0, this.class130_0.vJ_Excavation, true, this.method_1());
				this.dataGridViewExcelFilter_0.SearchGrid(this.dataGridViewTextBoxColumn_32.Name, num.ToString(), false);
			}
		}

		private void toolStripButton_15_Click(object sender, EventArgs e)
		{
			Form63 form = new Form63(-1, this.int_0, (Enum19)3);
			form.SqlSettings = this.SqlSettings;
			if (form.ShowDialog() == DialogResult.OK)
			{
				base.SelectSqlData(this.class130_0, this.class130_0.vJ_ExcavationSurface, true);
				this.dataGridViewExcelFilter_4.SearchGrid(this.dataGridViewTextBoxColumn_12.Name, form.method_0().ToString(), false);
			}
		}

		private void toolStripButton_16_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_4.CurrentRow != null)
			{
				Form63 form = new Form63(Convert.ToInt32(this.dataGridViewExcelFilter_4.CurrentRow.Cells[this.dataGridViewTextBoxColumn_12.Name].Value), this.int_0, (Enum19)3);
				form.SqlSettings = this.SqlSettings;
				if (form.ShowDialog() == DialogResult.OK)
				{
					base.SelectSqlData(this.class130_0, this.class130_0.vJ_ExcavationSurface, true);
					this.dataGridViewExcelFilter_4.SearchGrid(this.dataGridViewTextBoxColumn_12.Name, form.method_0().ToString(), false);
				}
			}
		}

		private void dataGridViewExcelFilter_4_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (this.toolStripButton_16.Visible && this.toolStripButton_16.Enabled && this.toolStrip_5.Visible && this.toolStrip_5.Enabled)
			{
				this.toolStripButton_16_Click(sender, e);
			}
		}

		private void toolStripButton_17_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_4.CurrentRow != null && MessageBox.Show("Вы действительно хотите удалить текущий материал?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes && base.DeleteSqlDataById(this.class130_0.tJ_ExcavationSurface, Convert.ToInt32(this.dataGridViewExcelFilter_4.CurrentRow.Cells[this.dataGridViewTextBoxColumn_12.Name].Value)))
			{
				this.dataGridViewExcelFilter_4.Rows.Remove(this.dataGridViewExcelFilter_4.CurrentRow);
			}
		}

		private void toolStripButton_18_Click(object sender, EventArgs e)
		{
			Form63 form = new Form63(-1, this.int_0, (Enum19)1);
			form.SqlSettings = this.SqlSettings;
			if (form.ShowDialog() == DialogResult.OK)
			{
				base.SelectSqlData(this.class130_0, this.class130_0.vJ_ExcavationSurface, true);
				this.dataGridViewExcelFilter_5.SearchGrid(this.dataGridViewTextBoxColumn_21.Name, form.method_0().ToString(), false);
			}
		}

		private void toolStripButton_19_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_5.CurrentRow != null)
			{
				Form63 form = new Form63(Convert.ToInt32(this.dataGridViewExcelFilter_5.CurrentRow.Cells[this.dataGridViewTextBoxColumn_21.Name].Value), this.int_0, (Enum19)1);
				form.SqlSettings = this.SqlSettings;
				if (form.ShowDialog() == DialogResult.OK)
				{
					base.SelectSqlData(this.class130_0, this.class130_0.vJ_ExcavationSurface, true);
					this.dataGridViewExcelFilter_5.SearchGrid(this.dataGridViewTextBoxColumn_21.Name, form.method_0().ToString(), false);
				}
			}
		}

		private void dataGridViewExcelFilter_5_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (this.toolStripButton_19.Visible && this.toolStripButton_19.Enabled && this.toolStrip_6.Visible && this.toolStrip_6.Enabled)
			{
				this.toolStripButton_19_Click(sender, e);
			}
		}

		private void toolStripButton_20_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_5.CurrentRow != null && MessageBox.Show("Вы действительно хотите удалить текущее повреждение?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes && base.DeleteSqlDataById(this.class130_0.tJ_ExcavationSurface, Convert.ToInt32(this.dataGridViewExcelFilter_5.CurrentRow.Cells[this.dataGridViewTextBoxColumn_21.Name].Value)))
			{
				this.dataGridViewExcelFilter_5.Rows.Remove(this.dataGridViewExcelFilter_5.CurrentRow);
			}
		}

		private void toolStripButton_21_Click(object sender, EventArgs e)
		{
			Form63 form = new Form63(-1, this.int_0, (Enum19)2);
			form.SqlSettings = this.SqlSettings;
			if (form.ShowDialog() == DialogResult.OK)
			{
				base.SelectSqlData(this.class130_0, this.class130_0.vJ_ExcavationSurface, true);
				this.dataGridViewExcelFilter_6.SearchGrid(this.dataGridViewTextBoxColumn_23.Name, form.method_0().ToString(), false);
			}
		}

		private void toolStripButton_22_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_6.CurrentRow != null)
			{
				Form63 form = new Form63(Convert.ToInt32(this.dataGridViewExcelFilter_6.CurrentRow.Cells[this.dataGridViewTextBoxColumn_23.Name].Value), this.int_0, (Enum19)2);
				form.SqlSettings = this.SqlSettings;
				if (form.ShowDialog() == DialogResult.OK)
				{
					base.SelectSqlData(this.class130_0, this.class130_0.vJ_ExcavationSurface, true);
					this.dataGridViewExcelFilter_6.SearchGrid(this.dataGridViewTextBoxColumn_23.Name, form.method_0().ToString(), false);
				}
			}
		}

		private void dataGridViewExcelFilter_6_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (this.toolStripButton_22.Visible && this.toolStripButton_22.Enabled && this.toolStrip_7.Visible && this.toolStrip_7.Enabled)
			{
				this.toolStripButton_22_Click(sender, e);
			}
		}

		private void toolStripButton_23_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_6.CurrentRow != null && MessageBox.Show("Вы действительно хотите удалить текущую площадь восстановления?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes && base.DeleteSqlDataById(this.class130_0.tJ_ExcavationSurface, Convert.ToInt32(this.dataGridViewExcelFilter_6.CurrentRow.Cells[this.dataGridViewTextBoxColumn_23.Name].Value)))
			{
				this.dataGridViewExcelFilter_6.Rows.Remove(this.dataGridViewExcelFilter_6.CurrentRow);
			}
		}

		private void toolStripButton_24_Click(object sender, EventArgs e)
		{
			Form62 form = new Form62(-1, this.int_0, (Enum18)2);
			form.SqlSettings = this.SqlSettings;
			if (form.ShowDialog() == DialogResult.OK)
			{
				int num = this.int_0;
				base.SelectSqlData(this.class130_0, this.class130_0.vJ_Excavation, true, this.method_1());
				this.dataGridViewExcelFilter_0.SearchGrid(this.dataGridViewTextBoxColumn_32.Name, num.ToString(), false);
				base.SelectSqlData(this.class130_0, this.class130_0.vJ_ExcavationStatus, true);
				this.dataGridViewExcelFilter_7.SearchGrid(this.dataGridViewTextBoxColumn_47.Name, form.method_0().ToString(), false);
			}
		}

		private void toolStripButton_25_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_7.CurrentRow != null)
			{
				Form62 form = new Form62(Convert.ToInt32(this.dataGridViewExcelFilter_7.CurrentRow.Cells[this.dataGridViewTextBoxColumn_47.Name].Value), this.int_0, (Enum18)2);
				form.SqlSettings = this.SqlSettings;
				if (form.ShowDialog() == DialogResult.OK)
				{
					int num = this.int_0;
					base.SelectSqlData(this.class130_0, this.class130_0.vJ_Excavation, true, this.method_1());
					this.dataGridViewExcelFilter_0.SearchGrid(this.dataGridViewTextBoxColumn_32.Name, num.ToString(), false);
					base.SelectSqlData(this.class130_0, this.class130_0.vJ_ExcavationStatus, true);
					this.dataGridViewExcelFilter_7.SearchGrid(this.dataGridViewTextBoxColumn_47.Name, form.method_0().ToString(), false);
				}
			}
		}

		private void dataGridViewExcelFilter_7_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (this.toolStripButton_25.Visible && this.toolStripButton_25.Enabled && this.toolStrip_8.Visible && this.toolStrip_8.Enabled)
			{
				this.toolStripButton_25_Click(sender, e);
			}
		}

		private void toolStripButton_26_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_7.CurrentRow != null && MessageBox.Show("Вы действительно хотите удалить текущий статус?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes && base.DeleteSqlDataById(this.class130_0.tJ_ExcavationStatus, Convert.ToInt32(this.dataGridViewExcelFilter_7.CurrentRow.Cells[this.dataGridViewTextBoxColumn_47.Name].Value)))
			{
				this.dataGridViewExcelFilter_7.Rows.Remove(this.dataGridViewExcelFilter_7.CurrentRow);
				int num = this.int_0;
				base.SelectSqlData(this.class130_0, this.class130_0.vJ_Excavation, true, this.method_1());
				this.dataGridViewExcelFilter_0.SearchGrid(this.dataGridViewTextBoxColumn_32.Name, num.ToString(), false);
			}
		}

		private void method_6(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Multiselect = true;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.class130_0.tJ_ExcavationFile.Clear();
				foreach (string text in openFileDialog.FileNames)
				{
					DataRow dataRow = this.class130_0.tJ_ExcavationFile.NewRow();
					dataRow["idExcavation"] = this.int_0;
					dataRow["typeFile"] = Convert.ToInt32(((ToolStripMenuItem)sender).Tag);
					dataRow["FileName"] = text;
					dataRow["File"] = File.ReadAllBytes(text);
					this.class130_0.tJ_ExcavationFile.Rows.Add(dataRow);
				}
				base.InsertSqlData(this.class130_0, this.class130_0.tJ_ExcavationFile);
				this.class130_0.tJ_ExcavationFile.Clear();
				base.SelectSqlData(this.dataTable_0, true, "order by filename", null, false, 0);
			}
		}

		private void toolStripButton_28_Click(object sender, EventArgs e)
		{
			foreach (object obj in this.dataGridViewExcelFilter_8.SelectedRows)
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
				base.DeleteSqlDataById(this.class130_0.tJ_ExcavationFile, Convert.ToInt32(dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_28.Name].Value));
			}
			base.SelectSqlData(this.dataTable_0, true, "order by filename", null, false, 0);
		}

		private void dataGridViewExcelFilter_8_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
		{
			if (((DataGridView)sender).RowCount > 0 && this.dataGridViewExcelFilter_8[this.dataGridViewTextBoxColumn_31.Name, e.RowIndex].Value != null)
			{
				if (e.ColumnIndex == this.dataGridViewExcelFilter_8.Columns[this.dataGridViewLinkColumn_0.Name].Index)
				{
					if (!string.IsNullOrEmpty(Path.GetFileName(this.dataGridViewExcelFilter_8[this.dataGridViewTextBoxColumn_31.Name, e.RowIndex].Value.ToString())))
					{
						e.Value = Path.GetFileName(this.dataGridViewExcelFilter_8[this.dataGridViewTextBoxColumn_31.Name, e.RowIndex].Value.ToString());
					}
					else
					{
						e.Value = this.dataGridViewExcelFilter_8[this.dataGridViewTextBoxColumn_31.Name, e.RowIndex].Value.ToString();
					}
				}
				if (e.ColumnIndex == this.dataGridViewExcelFilter_8.Columns[this.dataGridViewImageColumnNotNull_0.Name].Index)
				{
					Icon icon = FormLbr.Classes.FileInfo.IconOfFile(this.dataGridViewExcelFilter_8[this.dataGridViewTextBoxColumn_31.Name, e.RowIndex].Value.ToString());
					if (icon != null)
					{
						e.Value = icon.ToBitmap();
					}
				}
			}
		}

		private void dataGridViewExcelFilter_8_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (this.dataGridViewExcelFilter_8.CurrentRow == null)
			{
				return;
			}
			try
			{
				int num = Convert.ToInt32(this.dataGridViewExcelFilter_8.CurrentRow.Cells[this.dataGridViewTextBoxColumn_28.Name].Value);
				if (e.ColumnIndex == this.dataGridViewExcelFilter_8.Columns[this.dataGridViewLinkColumn_0.Name].Index)
				{
					base.SelectSqlData(this.class130_0, this.class130_0.vJ_ExcavationFile, true, "where id = " + num.ToString());
					string path = this.class130_0.vJ_ExcavationFile.method_2(num)["FileName"].ToString();
					object obj = this.class130_0.vJ_ExcavationFile.method_2(num)["File"];
					if (obj == DBNull.Value)
					{
						Process.Start(Path.GetDirectoryName(path));
					}
					else
					{
						byte[] array = (byte[])obj;
						string text = Path.GetTempFileName();
						text = Path.ChangeExtension(text, Path.GetExtension(path));
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
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, ex.Source);
			}
		}

		private void treeView_0_AfterSelect(object sender, TreeViewEventArgs e)
		{
			this.bindingSource_8.Filter = "idExcavation = " + this.int_0.ToString();
			if (this.treeView_0.SelectedNode != null && this.treeView_0.SelectedNode.Tag != null)
			{
				this.bindingSource_8.Filter = "idExcavation = " + this.int_0.ToString() + " and typeFile = " + this.treeView_0.SelectedNode.Tag.ToString();
			}
		}

		private void tabControl_0_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.method_3();
		}

		private int int_0;

	
	}
}
