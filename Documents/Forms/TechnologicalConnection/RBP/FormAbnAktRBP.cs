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
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using Constants;
using ControlsLbr;
using ControlsLbr.DataGridViewExcelFilter;
using ControlsLbr.WPF;
using DataSql;
using Documents.Forms.TechnologicalConnection.TU;
using FormLbr;
using FormLbr.Classes;
using OfficeLB.Word;

namespace Documents.Forms.TechnologicalConnection.RBP
{
	public partial class FormAbnAktRBP : FormBase
	{
		public int IdList { get; set; }

		public int IdActTehConnection { get; set; }

		public int IdTU
		{
			get
			{
				return this.int_2;
			}
			set
			{
				this.int_2 = value;
				if (value != -1)
				{
					this.comboBoxReadOnly_0.ReadOnly = true;
					this.button_4.Enabled = false;
					DataTable dataTable = base.SelectSqlData("vtc_tu", true, "where id = " + this.IdTU.ToString());
					if (dataTable.Rows.Count > 0)
					{
						if (dataTable.Rows[0]["idAbn"] != DBNull.Value)
						{
							this.IdAbn = Convert.ToInt32(dataTable.Rows[0]["idAbn"]);
						}
						if (dataTable.Rows[0]["idAbnObj"] != DBNull.Value)
						{
							this.IdAbnObj = Convert.ToInt32(dataTable.Rows[0]["idAbnobj"]);
							return;
						}
					}
				}
				else
				{
					this.comboBoxReadOnly_0.ReadOnly = false;
					this.button_4.Enabled = true;
				}
			}
		}

		public int IdAbnObj
		{
			get
			{
				return this.int_4;
			}
			set
			{
				if (this.int_4 != value)
				{
					this.int_4 = value;
					this.comboBoxReadOnly_0.SelectedValue = this.int_4;
				}
			}
		}

		public int IdAbn
		{
			get
			{
				return this.int_3;
			}
			set
			{
				this.int_3 = value;
				if (value == -1)
				{
					this.textBox_19.Text = "";
					return;
				}
				DataTable dataTable = new DataTable("tAbn");
				dataTable.Columns.Add("name", typeof(string));
				base.SelectSqlData(dataTable, true, "where id = " + this.int_3.ToString(), null, false, 0);
				if (dataTable.Rows.Count > 0)
				{
					this.textBox_19.Text = dataTable.Rows[0]["name"].ToString();
				}
				else
				{
					this.textBox_19.Text = "";
				}
				this.method_13();
			}
		}

		private TypeDocValue method_0()
		{
			return this.typeDocValue_0;
		}

		private void method_1(TypeDocValue value)
		{
			if (this.typeDocValue_0 != value)
			{
				this.typeDocValue_0 = value;
				if (this.SqlSettings != null)
				{
					string nameFunction = "dbo.fn_GetIdClassifier";
					string[] array = new string[2];
					array[0] = ";TypeDoc;tAbnObj;";
					int num = 1;
					int num2 = (int)this.typeDocValue_0;
					array[num] = num2.ToString();
					this.nullable_0 = new int?((int)base.CallSQLScalarFunction(nameFunction, array));
				}
				TypeDocValue typeDocValue = this.typeDocValue_0;
				if (typeDocValue != TypeDocValue.ActBalance)
				{
					if (typeDocValue != TypeDocValue.ActLiability)
					{
						return;
					}
					if (this.tabControl_0.TabPages.Contains(this.tabPage_6))
					{
						this.tabControl_0.TabPages.Remove(this.tabPage_6);
					}
				}
				else if (!this.tabControl_0.TabPages.Contains(this.tabPage_6))
				{
					this.tabControl_0.TabPages.Insert(1, this.tabPage_6);
					return;
				}
			}
		}

		private void method_2()
		{
			this.textBoxDropDown_0 = new TextBoxDropDown();
			this.elementHost_5.Child = this.textBoxDropDown_0;
			this.textBoxDropDown_0.TextChanged += new TextChangedEventHandler(this.textBox_14_TextChanged);
			this.textBoxDropDown_1 = new TextBoxDropDown();
			this.elementHost_6.Child = this.textBoxDropDown_1;
			this.textBoxDropDown_1.TextChanged += new TextChangedEventHandler(this.textBox_14_TextChanged);
			this.textBoxDropDown_7 = new TextBoxDropDown();
			this.elementHost_4.Child = this.textBoxDropDown_7;
			this.textBoxDropDown_7.TextChanged += new TextChangedEventHandler(this.textBox_14_TextChanged);
			this.textBoxDropDown_5 = new TextBoxDropDown();
			this.elementHost_0.Child = this.textBoxDropDown_5;
			this.textBoxDropDown_5.TextChanged += new TextChangedEventHandler(this.textBox_14_TextChanged);
			this.textBoxDropDown_6 = new TextBoxDropDown();
			this.elementHost_1.Child = this.textBoxDropDown_6;
			this.textBoxDropDown_6.TextChanged += new TextChangedEventHandler(this.textBox_14_TextChanged);
			this.QaFgrduphk = new TextBoxDropDown();
			this.elementHost_7.Child = this.QaFgrduphk;
			this.QaFgrduphk.TextChanged += new TextChangedEventHandler(this.textBox_14_TextChanged);
			this.textBoxDropDown_2 = new TextBoxDropDown();
			this.elementHost_2.Child = this.textBoxDropDown_2;
			this.textBoxDropDown_2.TextChanged += new TextChangedEventHandler(this.textBox_14_TextChanged);
			this.textBoxDropDown_3 = new TextBoxDropDown();
			this.elementHost_3.Child = this.textBoxDropDown_3;
			this.textBoxDropDown_3.TextChanged += new TextChangedEventHandler(this.textBox_14_TextChanged);
			this.textBoxDropDown_4 = new TextBoxDropDown();
			this.uLmgjiJpjw.Child = this.textBoxDropDown_4;
			this.textBoxDropDown_4.TextChanged += new TextChangedEventHandler(this.textBox_14_TextChanged);
		}

		private void method_3(bool bool_3)
		{
			this.comboBox_1.Enabled = bool_3;
			this.comboBox_0.Enabled = bool_3;
			this.textBox_7.ReadOnly = bool_3;
			this.textBox_1.ReadOnly = bool_3;
			this.textBoxDropDown_5.ReadOnly = bool_3;
			this.textBoxDropDown_2.ReadOnly = bool_3;
			this.textBoxDropDown_0.ReadOnly = bool_3;
			this.peygMhnWkn.ReadOnly = bool_3;
			this.QaFgrduphk.ReadOnly = bool_3;
			this.textBoxDropDown_4.ReadOnly = bool_3;
			this.textBoxDropDown_7.ReadOnly = bool_3;
			this.textBoxDropDown_6.ReadOnly = bool_3;
			this.textBoxDropDown_3.ReadOnly = bool_3;
			this.textBoxDropDown_1.ReadOnly = bool_3;
			this.textBox_5.ReadOnly = bool_3;
			this.textBox_4.ReadOnly = bool_3;
			this.textBox_6.ReadOnly = bool_3;
			this.textBox_18.ReadOnly = bool_3;
			this.pbtrqMeGe2.ReadOnly = bool_3;
			this.textBox_14.ReadOnly = bool_3;
			this.textBox_9.ReadOnly = bool_3;
			this.BpwgFdgOge.ReadOnly = bool_3;
			this.textBox_10.ReadOnly = bool_3;
			this.textBox_13.ReadOnly = bool_3;
			this.textBox_8.ReadOnly = bool_3;
			this.textBox_15.ReadOnly = bool_3;
			this.textBox_3.ReadOnly = bool_3;
			this.textBox_0.ReadOnly = bool_3;
			this.textBox_17.ReadOnly = bool_3;
			this.textBox_16.ReadOnly = bool_3;
			this.textBox_2.ReadOnly = bool_3;
			this.textBox_11.ReadOnly = bool_3;
			this.textBox_12.ReadOnly = bool_3;
			this.toolStripButton_0.Enabled = bool_3;
			this.toolStripButton_1.Enabled = bool_3;
			this.toolStripDropDownButton_0.Enabled = bool_3;
			this.toolStripButton_4.Enabled = bool_3;
			this.toolStripButton_6.Enabled = bool_3;
			this.toolStripButton_7.Enabled = bool_3;
			this.button_3.Enabled = bool_3;
			this.button_1.Enabled = bool_3;
			this.button_0.Enabled = bool_3;
		}

		public FormAbnAktRBP()
		{
			
			this.int_2 = -1;
			this.int_3 = -1;
			this.int_4 = -1;
			this.process_0 = new Process();
			this.dictionary_0 = new Dictionary<string, FileWatcherArgsAddl>();
			this.string_0 = "";
			
			this.textBoxDropDown_0 = Activator.CreateInstance<TextBoxDropDown>();
			this.method_37();
			this.method_2();
		}

		public FormAbnAktRBP(SQLSettings settings, bool inf, bool inf1, int idAbn, int idAbnObj, TypeDocValue value)
		{
			
			this.int_2 = -1;
			this.int_3 = -1;
			this.int_4 = -1;
			this.process_0 = new Process();
			this.dictionary_0 = new Dictionary<string, FileWatcherArgsAddl>();
			this.string_0 = "";
			
			this.method_37();
			this.method_2();
			this.SqlSettings = settings;
			this.IdAbnObj = idAbnObj;
			this.IdAbn = idAbn;
			this.IdActTehConnection = -1;
			this.method_4(value);
		}

		private void method_4(TypeDocValue typeDocValue_1)
		{
			this.IdList = -1;
			this.method_1(typeDocValue_1);
			this.enum2_0 = (Enum2)0;
			this.method_9();
			this.method_10();
			this.method_7();
			this.Text = ((this.method_0() == TypeDocValue.ActBalance) ? "Добавление акта разграничения балансовой принадлежности" : ((this.method_0() == TypeDocValue.ActLiability) ? "Добавление акта разграничения эксплуатационной ответственности" : ""));
			base.SelectSqlData(this.class255_0, this.class255_0.tAbnDoc_Dogovor, true, " where idAbn = " + this.IdAbn.ToString() + " and FlagBreak = 0");
			if (this.class255_0.tAbnDoc_Dogovor.Count > 0 && this.class255_0.tAbnDoc_Dogovor.Rows[0]["BasisOF"] != DBNull.Value)
			{
				this.textBox_5.Text = this.class255_0.tAbnDoc_Dogovor.First<Class255.Class442>().BasisOF;
			}
			else
			{
				this.textBox_5.Text = "устава";
			}
			this.textBox_1.Text = "до границы раздела " + ((this.method_0() == TypeDocValue.ActBalance) ? "балансовой принадлежности" : "эксплуатационной ответственности") + " со стороны потребителя";
			string text = "";
			string text2 = "";
			base.SelectSqlData(this.class255_0, this.class255_0.tG_AbnChief, true, " where idAbn = " + this.IdAbn.ToString());
			if (this.class255_0.tG_AbnChief.Rows.Count > 0)
			{
				if (this.class255_0.tG_AbnChief[0]["R_Post"] != DBNull.Value && this.class255_0.tG_AbnChief[0]["R_F"] != DBNull.Value && this.class255_0.tG_AbnChief[0]["R_I"] != DBNull.Value)
				{
					if (this.class255_0.tG_AbnChief[0]["R_O"] != DBNull.Value)
					{
						text2 = this.class255_0.tG_AbnChief.First<Class255.Class451>().R_F;
						if (text2.Length > 0 && this.class255_0.tG_AbnChief.First<Class255.Class451>().R_I.Length > 0)
						{
							text2 = text2 + " " + this.class255_0.tG_AbnChief.First<Class255.Class451>().R_I.Substring(0, 1) + ".";
						}
						if (text2.Length > 0 && this.class255_0.tG_AbnChief.First<Class255.Class451>().R_O.Length > 0)
						{
							text2 = text2 + " " + this.class255_0.tG_AbnChief.First<Class255.Class451>().R_O.Substring(0, 1) + ".";
						}
						text2 = ((this.class255_0.tG_AbnChief.First<Class255.Class451>()["R_Post"] != DBNull.Value) ? (this.class255_0.tG_AbnChief.First<Class255.Class451>().R_Post + " ") : "") + text2;
						goto IL_330;
					}
				}
				MessageBox.Show("Не заполнены должность и/или ФИО руководителя организациии в родительном падеже.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				IL_330:
				if (this.class255_0.tG_AbnChief[0]["I_Post"] != DBNull.Value && this.class255_0.tG_AbnChief[0]["I_F"] != DBNull.Value && this.class255_0.tG_AbnChief[0]["I_I"] != DBNull.Value)
				{
					if (this.class255_0.tG_AbnChief[0]["I_O"] != DBNull.Value)
					{
						text = this.class255_0.tG_AbnChief.First<Class255.Class451>().I_F;
						if (text.Length > 0 && this.class255_0.tG_AbnChief.First<Class255.Class451>().I_I.Length > 0)
						{
							text = text + " " + this.class255_0.tG_AbnChief.First<Class255.Class451>().I_I.Substring(0, 1) + ".";
						}
						if (text.Length > 0 && this.class255_0.tG_AbnChief.First<Class255.Class451>().I_O.Length > 0)
						{
							text = text + " " + this.class255_0.tG_AbnChief.First<Class255.Class451>().I_O.Substring(0, 1) + ".";
							goto IL_4AC;
						}
						goto IL_4AC;
					}
				}
				MessageBox.Show("Не заполнены должность и/или ФИО руководителя организациии в именительном падеже.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				MessageBox.Show("Не заполнены должность и ФИО руководителя организациии.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			IL_4AC:
			this.textBox_6.Text = text2;
			this.textBox_0.Text = text;
		}

		public FormAbnAktRBP(SQLSettings settings, bool inf, int idAbn, TypeDocValue value)
		{
			
			this.int_2 = -1;
			this.int_3 = -1;
			this.int_4 = -1;
			this.process_0 = new Process();
			this.dictionary_0 = new Dictionary<string, FileWatcherArgsAddl>();
			this.string_0 = "";
			
			this.method_37();
			this.method_2();
			this.SqlSettings = settings;
			this.IdAbn = idAbn;
			this.method_1(value);
			this.IdActTehConnection = -1;
			this.IdList = -1;
			this.enum2_0 = (Enum2)0;
			this.method_9();
			this.method_10();
			this.method_7();
			base.SelectSqlData(this.class255_0, this.class255_0.tAbnDoc_Dogovor, true, " where idAbn = " + idAbn.ToString() + " and FlagBreak = 0");
			if (this.class255_0.tAbnDoc_Dogovor.Count > 0 && this.class255_0.tAbnDoc_Dogovor.Rows[0]["BasisOF"] != DBNull.Value)
			{
				this.textBox_5.Text = this.class255_0.tAbnDoc_Dogovor.First<Class255.Class442>().BasisOF;
			}
			else
			{
				this.textBox_5.Text = "устава";
			}
			this.textBox_1.Text = "до границы раздела " + ((this.method_0() == TypeDocValue.ActBalance) ? "балансовой принадлежности" : "эксплуатационной ответственности") + " со стороны потребителя";
			string text = "";
			string text2 = "";
			base.SelectSqlData(this.class255_0, this.class255_0.tG_AbnChief, true, " where idAbn = " + idAbn.ToString());
			if (this.class255_0.tG_AbnChief.Rows.Count > 0)
			{
				text = this.class255_0.tG_AbnChief.First<Class255.Class451>().R_F;
				if (text.Length > 0 && this.class255_0.tG_AbnChief.First<Class255.Class451>().R_I.Length > 0)
				{
					text = text + " " + this.class255_0.tG_AbnChief.First<Class255.Class451>().R_I.Substring(0, 1) + ".";
				}
				if (text.Length > 0 && this.class255_0.tG_AbnChief.First<Class255.Class451>().R_O.Length > 0)
				{
					text = text + " " + this.class255_0.tG_AbnChief.First<Class255.Class451>().R_O.Substring(0, 1) + ".";
				}
				text2 = ((this.class255_0.tG_AbnChief.First<Class255.Class451>()["R_Post"] != DBNull.Value) ? this.class255_0.tG_AbnChief.First<Class255.Class451>().R_Post : "") + " " + text;
			}
			this.textBox_6.Text = text2;
			this.textBox_0.Text = text;
		}

		public FormAbnAktRBP(SQLSettings settings, int idAbnObj, int idList)
		{
			
			this.int_2 = -1;
			this.int_3 = -1;
			this.int_4 = -1;
			this.process_0 = new Process();
			this.dictionary_0 = new Dictionary<string, FileWatcherArgsAddl>();
			this.string_0 = "";
			
			this.method_37();
			this.method_2();
			this.SqlSettings = settings;
			this.IdAbn = this.method_18(idAbnObj);
			this.IdAbnObj = idAbnObj;
			this.IdList = idList;
			this.IdActTehConnection = -1;
			this.method_1(this.method_5(idList));
			this.enum2_0 = (Enum2)2;
			this.method_9();
			this.method_10();
			this.method_6(idList);
			this.method_7();
			base.SelectSqlData(this.class255_0, this.class255_0.tAbnObjDoc_Image, true, "where idList=" + idList + " order by id");
			if (this.class255_0.tAbnObjDoc_Image.Count > 0)
			{
				for (int i = 0; i < this.class255_0.tAbnObjDoc_Image.Count; i++)
				{
					if (this.class255_0.tAbnObjDoc_Image.Rows[i]["Scan"] != DBNull.Value)
					{
						this.method_11((byte[])this.class255_0.tAbnObjDoc_Image.Rows[i]["Scan"], (int)this.class255_0.tAbnObjDoc_Image.Rows[i]["id"]);
					}
				}
				if (this.dataGridViewExcelFilter_0.CurrentRow != null)
				{
					this.pictureBox_0.Image = (Bitmap)this.dataGridViewExcelFilter_0.CurrentRow.Cells["ImageOriginal"].Value;
				}
				this.pictureBox_0.SizeMode = PictureBoxSizeMode.StretchImage;
			}
			this.Text = "Редактирование акта разграничения " + ((this.method_0() == TypeDocValue.ActBalance) ? "балансовой принадлежности" : "эксплуатационной ответственности");
		}

		public FormAbnAktRBP(SQLSettings settings, int idAbnObj, int idList, bool inf)
		{
			
			this.int_2 = -1;
			this.int_3 = -1;
			this.int_4 = -1;
			this.process_0 = new Process();
			this.dictionary_0 = new Dictionary<string, FileWatcherArgsAddl>();
			this.string_0 = "";
			
			this.method_37();
			this.method_2();
			this.SqlSettings = settings;
			this.IdAbnObj = idAbnObj;
			this.IdList = idList;
			this.IdActTehConnection = -1;
			this.method_1(this.method_5(idList));
			this.enum2_0 = (Enum2)3;
			this.method_9();
			this.method_10();
			this.method_6(idList);
			this.method_3(false);
			this.method_7();
			base.SelectSqlData(this.class255_0, this.class255_0.tAbnObjDoc_Image, true, "where idList=" + idList + " order by id");
			if (this.class255_0.tAbnObjDoc_Image.Count > 0)
			{
				for (int i = 0; i < this.class255_0.tAbnObjDoc_Image.Count; i++)
				{
					this.method_11((byte[])this.class255_0.tAbnObjDoc_Image.Rows[i]["Scan"], (int)this.class255_0.tAbnObjDoc_Image.Rows[i]["id"]);
				}
				this.pictureBox_0.Image = (Bitmap)this.dataGridViewExcelFilter_0.CurrentRow.Cells["ImageOriginal"].Value;
				this.pictureBox_0.SizeMode = PictureBoxSizeMode.StretchImage;
			}
			this.button_3.Enabled = false;
			this.Text = "Просмотр акта разграничения " + ((this.method_0() == TypeDocValue.ActBalance) ? "балансовой принадлежности" : "эксплуатационной ответственности");
		}

		public FormAbnAktRBP(SQLSettings settings, int idAbnObj, int idList, int idAbn)
		{
			
			this.int_2 = -1;
			this.int_3 = -1;
			this.int_4 = -1;
			this.process_0 = new Process();
			this.dictionary_0 = new Dictionary<string, FileWatcherArgsAddl>();
			this.string_0 = "";
			
			this.method_37();
			this.method_2();
			this.SqlSettings = settings;
			this.IdAbnObj = idAbnObj;
			this.IdList = idList;
			this.IdAbn = idAbn;
			this.IdActTehConnection = -1;
			this.enum2_0 = (Enum2)1;
			this.method_1(this.method_5(idList));
			this.method_9();
			this.method_10();
			this.method_7();
			this.method_6(idList);
			base.SelectSqlData(this.class255_0, this.class255_0.tAbnDoc_Dogovor, true, " where idAbn = " + idAbn.ToString() + " and FlagBreak = 0");
			if (this.class255_0.tAbnDoc_Dogovor.Count > 0 && this.class255_0.tAbnDoc_Dogovor.Rows[0]["BasisOF"] != DBNull.Value)
			{
				this.textBox_5.Text = this.class255_0.tAbnDoc_Dogovor.First<Class255.Class442>().BasisOF;
			}
			else
			{
				this.textBox_5.Text = "устава";
			}
			this.textBox_1.Text = "до границы раздела " + ((this.method_0() == TypeDocValue.ActBalance) ? "балансовой принадлежности" : "эксплуатационной ответственности") + " со стороны потребителя";
			string text = "";
			string text2 = "";
			base.SelectSqlData(this.class255_0, this.class255_0.tG_AbnChief, true, " where idAbn = " + idAbn.ToString());
			if (this.class255_0.tG_AbnChief.Rows.Count > 0)
			{
				text = this.class255_0.tG_AbnChief.First<Class255.Class451>().R_F;
				if (text.Length > 0 && this.class255_0.tG_AbnChief.First<Class255.Class451>().R_I.Length > 0)
				{
					text = text + " " + this.class255_0.tG_AbnChief.First<Class255.Class451>().R_I.Substring(0, 1) + ".";
				}
				if (text.Length > 0 && this.class255_0.tG_AbnChief.First<Class255.Class451>().R_O.Length > 0)
				{
					text = text + " " + this.class255_0.tG_AbnChief.First<Class255.Class451>().R_O.Substring(0, 1) + ".";
				}
				text2 = ((this.class255_0.tG_AbnChief.First<Class255.Class451>()["R_Post"] != DBNull.Value) ? this.class255_0.tG_AbnChief.First<Class255.Class451>().R_Post : "") + " " + text;
			}
			this.textBox_6.Text = text2;
			this.textBox_0.Text = text;
			this.method_14((int)this.method_0());
			this.IdList = -1;
			this.Text = "Копирование акта разграничения" + ((this.method_0() == TypeDocValue.ActBalance) ? "балансовой принадлежности" : "эксплуатационной ответственности");
		}

		public FormAbnAktRBP(SQLSettings settings, int idActTeh, int idTU, TypeDocValue value)
		{
			
			this.int_2 = -1;
			this.int_3 = -1;
			this.int_4 = -1;
			this.process_0 = new Process();
			this.dictionary_0 = new Dictionary<string, FileWatcherArgsAddl>();
			this.string_0 = "";
			
			this.method_37();
			this.method_2();
			this.SqlSettings = settings;
			this.IdActTehConnection = idActTeh;
			this.IdTU = idTU;
			this.method_27();
			string selectCommandText = "select id, idAbn, idAbnObj from vtc_tu where id = " + idTU.ToString();
			DataTable dataTable = new DataTable();
			SqlDataConnect sqlDataConnect = new SqlDataConnect();
			if (sqlDataConnect.OpenConnection(this.SqlSettings))
			{
				try
				{
					new SqlDataAdapter(selectCommandText, sqlDataConnect.Connection).Fill(dataTable);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, ex.Source);
				}
			}
			if (dataTable.Rows.Count > 0)
			{
				this.IdAbn = ((dataTable.Rows[0]["idAbn"] != DBNull.Value) ? ((int)dataTable.Rows[0]["idAbn"]) : -1);
				this.IdAbnObj = ((dataTable.Rows[0]["idAbnObj"] != DBNull.Value) ? ((int)dataTable.Rows[0]["idAbnObj"]) : -1);
			}
			else
			{
				this.IdAbn = -1;
				this.IdAbnObj = -1;
			}
			this.method_4(value);
		}

		private void FormAbnAktRBP_Load(object sender, EventArgs e)
		{
			this.label_5.Text = (this.label_18.Text = (this.label_26.Text = "Границей " + ((this.method_0() == TypeDocValue.ActBalance) ? "балансовой принадлежности" : ((this.method_0() == TypeDocValue.ActLiability) ? "эксплуатационной ответственности" : "")) + " сторон является:"));
			if (this.tabControl_0.TabPages.Contains(this.tabPage_5))
			{
				this.tabControl_0.TabPages.Remove(this.tabPage_5);
			}
			if (this.IdList > 0)
			{
				this.method_26();
			}
			if (this.IdActTehConnection <= 0 && this.IdTU > 0)
			{
				DataTable dataTable = base.SelectSqlData("ttc_doc", true, " where idParent = " + this.IdTU.ToString() + " and typeDoc = " + 1240.ToString());
				if (dataTable.Rows.Count > 0)
				{
					this.IdActTehConnection = Convert.ToInt32(dataTable.Rows[0]["id"]);
				}
			}
			if ((this.IdAbn <= 0 || this.int_4 <= 0) && this.IdList > 0)
			{
				Class255.Class341 @class = new Class255.Class341();
				base.SelectSqlData(@class, true, "where id = " + this.IdList.ToString(), null, false, 0);
				if (@class.Rows.Count > 0 && @class.Rows[0]["idAbnObj"] != DBNull.Value && this.IdAbnObj <= 0)
				{
					this.IdAbnObj = Convert.ToInt32(@class.Rows[0]["idAbnObj"]);
				}
				if (@class.Rows[0]["idAbn"] != DBNull.Value && this.IdAbn <= 0)
				{
					this.IdAbn = Convert.ToInt32(@class.Rows[0]["idAbn"]);
				}
			}
		}

		private TypeDocValue method_5(int int_5)
		{
			string selectCommandText = "select c.Value from tAbnObjDoc_List d join tR_Classifier c on d.idDocType = c.id where d.id = " + int_5.ToString();
			int num = 0;
			DataTable dataTable = new DataTable();
			SqlDataConnect sqlDataConnect = new SqlDataConnect();
			if (sqlDataConnect.OpenConnection(this.SqlSettings))
			{
				try
				{
					new SqlDataAdapter(selectCommandText, sqlDataConnect.Connection).Fill(dataTable);
					int num2;
					if (dataTable.Rows.Count > 0)
					{
						if (dataTable.Rows[0]["Value"] != DBNull.Value)
						{
							num2 = int.Parse(Math.Round((decimal)dataTable.Rows[0]["Value"], 0).ToString());
							goto IL_A4;
						}
					}
					num2 = 0;
					IL_A4:
					num = num2;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, ex.Source);
				}
			}
			if (num <= 0)
			{
				return TypeDocValue.None;
			}
			return (TypeDocValue)num;
		}

		private void method_6(int int_5)
		{
			base.SelectSqlData(this.class255_0, this.class255_0.tAbnObjDoc_AktRBP, true, string.Format(" where idList = {0}", int_5));
			if (this.class255_0.tAbnObjDoc_AktRBP.Count > 0)
			{
				this.IdActTehConnection = ((this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>()["idActTehConnection"] == DBNull.Value) ? -1 : this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().idActTehConnection);
				this.IdTU = ((this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>()["idTU"] == DBNull.Value) ? -1 : this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().idTU);
				this.dateTimePicker_0.Value = DateTime.Parse(this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().ActData);
				this.comboBox_0.SelectedValue = this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().NetRegion;
				this.textBox_7.Text = this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().DataNumber;
				this.textBox_6.Text = this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().OrgFace;
				this.textBox_5.Text = this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().OrgBase;
				this.textBoxDropDown_7.Text = this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().OrgBalance;
				this.textBoxDropDown_1.Text = this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().PotrBalance;
				this.textBoxDropDown_0.Text = this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().BorderBalance;
				this.textBox_4.Text = this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().OrgExpl;
				this.textBox_3.Text = this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().PotrExpl;
				this.textBox_2.Text = this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().Responsibility;
				this.textBox_1.Text = this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().Admission;
				this.textBox_0.Text = this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().PotrSignature;
				this.textBox_18.Text = ((this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>()["Other"] == DBNull.Value) ? "" : this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().Other);
				this.textBox_8.Text = this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().OwnerName;
				this.textBox_9.Text = this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().OwnerChief;
				this.pbtrqMeGe2.Text = this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().OwnerBase;
				this.QaFgrduphk.Text = this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().OrganizExpl;
				this.textBoxDropDown_6.Text = this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().PotrebExpl;
				this.textBoxDropDown_5.Text = this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().BorderExpl;
				this.textBox_10.Text = this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().OwnerChief2;
				this.peygMhnWkn.Text = this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().tbDogByOTONum;
				this.textBox_12.Text = this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().tbTO2;
				this.textBox_11.Text = this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().tbTO1;
				this.textBox_15.Text = this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().OwnerName_Four;
				this.BpwgFdgOge.Text = this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().OwnerChief_Four;
				this.textBox_14.Text = this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().OwnerBase_Four;
				this.textBoxDropDown_4.Text = this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().OrganizExpl_Four;
				this.textBoxDropDown_2.Text = this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().Border2Expl_Four;
				this.textBoxDropDown_3.Text = this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().OwnerExpl_Four;
				this.textBox_13.Text = this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().OwnerChief2_Four;
				if (this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>()["idActRebinding"] != DBNull.Value)
				{
					this.KmmLzOmYaL(this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().idActRebinding);
				}
			}
		}

		private void KmmLzOmYaL(int int_5)
		{
			Class10.Class44 @class = new Class10.Class44();
			base.SelectSqlData(@class, true, "where id = " + int_5.ToString(), null, false, 0);
			if (@class.Rows.Count > 0)
			{
				this.panel_1.Visible = true;
				this.toolStrip_2.Enabled = false;
				this.dataGridView_1.Enabled = false;
				if (@class.Rows[0]["numDoc"] != DBNull.Value)
				{
					this.textBox_20.Text = @class.Rows[0]["numDoc"].ToString();
				}
				if (@class.Rows[0]["dateDoc"] != DBNull.Value)
				{
					this.dateTimePicker_1.Value = Convert.ToDateTime(@class.Rows[0]["dateDoc"]);
				}
				if (@class.Rows[0]["typeDocName"] != DBNull.Value)
				{
					this.textBox_21.Text = @class.Rows[0]["typeDocName"].ToString();
				}
			}
		}

		private void method_7()
		{
			foreach (object obj in new SqlDataCommand(this.SqlSettings).SelectSqlData(" SELECT doc.id, doc.FileName  FROM tR_DocTemplate AS doc  INNER JOIN [tR_Classifier] AS c ON doc.idTypeDoc = c.id  WHERE c.ParentKey = ';TypeDoc;tR_DocTemplate;' AND c.Deleted = ((0)) AND c.isGroup = ((0)) AND c.Value = 3 and doc.deleted = 0").Rows)
			{
				DataRow dataRow = (DataRow)obj;
				ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
				toolStripMenuItem.Text = dataRow["FileName"].ToString();
				toolStripMenuItem.Tag = dataRow["id"];
				toolStripMenuItem.Click += this.method_8;
				this.toolStripDropDownButton_0.DropDownItems.Add(toolStripMenuItem);
				ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem();
				toolStripMenuItem2.Text = dataRow["FileName"].ToString();
				toolStripMenuItem2.Tag = dataRow["id"];
				toolStripMenuItem2.Click += this.method_8;
				this.toolStripMenuItem_3.DropDownItems.Add(toolStripMenuItem2);
			}
		}

		private void method_8(object sender, EventArgs e)
		{
			string string_ = "";
			string string_2 = "";
			this.method_17(string_, string_2, sender, true);
		}

		private void method_9()
		{
			DataTable dataTable = base.SelectSqlData("tR_Classifier", true, "WHERE ParentKey = ';NetworkAreas;' AND isGroup = ((0)) AND Deleted = ((0))");
			DataRow dataRow = dataTable.NewRow();
			dataRow["id"] = -1;
			dataRow["Name"] = "";
			dataRow["isGroup"] = 0;
			dataRow["Deleted"] = 0;
			dataTable.Rows.Add(dataRow);
			this.comboBox_0.DataSource = dataTable;
			this.comboBox_0.DisplayMember = "Name";
			this.comboBox_0.ValueMember = "Id";
			this.comboBox_0.SelectedValue = -1;
		}

		private void method_10()
		{
			string connectionString = this.SqlSettings.GetConnectionString();
			this.textBoxDropDown_7.TextBoxWidth = (double)this.elementHost_4.Width;
			this.textBoxDropDown_7.Connection = connectionString;
			this.textBoxDropDown_7.NumberField = 1;
			this.textBoxDropDown_1.TextBoxWidth = (double)this.elementHost_6.Width;
			this.textBoxDropDown_1.Connection = connectionString;
			this.textBoxDropDown_1.NumberField = 2;
			this.textBoxDropDown_0.TextBoxWidth = (double)this.elementHost_5.Width;
			this.textBoxDropDown_0.Connection = connectionString;
			this.textBoxDropDown_0.NumberField = 3;
		}

		private void method_11(byte[] byte_0, int int_5)
		{
			try
			{
				Bitmap bitmap = ImageCompress.LoadBitmap(byte_0);
				if (bitmap != null)
				{
					this.dataGridViewExcelFilter_0.Rows.Add(new object[]
					{
						new Bitmap(bitmap, 120, 160),
						bitmap,
						true,
						int_5
					});
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void button_1_Click(object sender, EventArgs e)
		{
			this.textBox_4.Text = this.textBoxDropDown_7.Text;
		}

		private void button_0_Click(object sender, EventArgs e)
		{
			this.textBox_3.Text = this.textBoxDropDown_1.Text;
		}

		private void button_3_Click(object sender, EventArgs e)
		{
			try
			{
				this.bool_2 = this.method_34();
				if (this.bool_2)
				{
					base.DialogResult = DialogResult.OK;
					base.Close();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void method_12(object sender, EventArgs e)
		{
			if (this.peygMhnWkn.Text != "")
			{
				this.textBox_2.Text = "";
				this.textBox_2.Enabled = false;
				return;
			}
			this.textBox_2.Enabled = true;
		}

		private void toolStripMenuItem_0_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "JPEG Documents|*.jpg";
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				Bitmap bitmap = new Bitmap(openFileDialog.FileName);
				this.dataRow_1 = this.class255_0.tAbnObjDoc_Image.NewRow();
				this.dataRow_1["idList"] = this.IdList;
				this.dataRow_1["Scan"] = ImageCompress.GetCompressBytes(bitmap, 30L);
				this.class255_0.tAbnObjDoc_Image.Rows.Add(this.dataRow_1);
				base.InsertSqlDataOneRow(this.class255_0, this.class255_0.tAbnObjDoc_Image);
				this.dataRow_1.AcceptChanges();
				this.pictureBox_0.Image = ImageCompress.LoadBitmap(openFileDialog.FileName);
				this.pictureBox_0.SizeMode = PictureBoxSizeMode.StretchImage;
				this.dataGridViewExcelFilter_0.Rows.Add(new object[]
				{
					new Bitmap(bitmap, 120, 160),
					ImageCompress.LoadBitmap(openFileDialog.FileName),
					false
				});
				bitmap.Dispose();
				this.bool_1 = true;
			}
		}

		private void dataGridViewExcelFilter_0_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && e.RowIndex >= 0)
			{
				this.pictureBox_0.Image = (Bitmap)this.dataGridViewExcelFilter_0.CurrentRow.Cells["ImageOriginal"].Value;
				this.pictureBox_0.SizeMode = PictureBoxSizeMode.StretchImage;
			}
			if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
			{
				this.pictureBox_0.Image = (Bitmap)this.dataGridViewExcelFilter_0.CurrentRow.Cells["ImageOriginal"].Value;
				this.pictureBox_0.SizeMode = PictureBoxSizeMode.StretchImage;
				this.dataGridViewExcelFilter_0.Rows[e.RowIndex].Selected = true;
				this.dataGridViewExcelFilter_0.CurrentCell = this.dataGridViewExcelFilter_0[0, e.RowIndex];
				this.pictureBox_0.Image = (Bitmap)this.dataGridViewExcelFilter_0.CurrentRow.Cells["ImageOriginal"].Value;
				this.pictureBox_0.SizeMode = PictureBoxSizeMode.StretchImage;
				this.contextMenuStrip_0.Show(Cursor.Position);
			}
		}

		private void toolStripMenuItem_1_Click(object sender, EventArgs e)
		{
			if (base.DeleteSqlDataById(this.class255_0.tAbnObjDoc_Image, (int)this.dataGridViewExcelFilter_0.CurrentRow.Cells["id"].Value))
			{
				this.dataGridViewExcelFilter_0.Rows.RemoveAt(this.dataGridViewExcelFilter_0.CurrentRow.Index);
				MessageBox.Show("Изображение удалено..");
				this.bool_1 = true;
				return;
			}
			MessageBox.Show("Изображение удалить не удалось..");
		}

		private void toolStripButton_2_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.DefaultExt = ".jpg";
			saveFileDialog.FileName = "Temp";
			saveFileDialog.Title = "Сохраните файл с изображением в любой папке";
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				ImageCompress.SaveBitmapUsingExtension(this.pictureBox_0.Image, saveFileDialog.FileName);
				MessageBox.Show("Изображение успешно сохранено.");
			}
		}

		private void method_13()
		{
			Class10.Class11 @class = new Class10.Class11();
			base.SelectSqlData(@class, true, " where id = " + this.IdAbn.ToString(), null, false, 0);
			if (@class.Rows.Count > 0)
			{
				this.comboBoxReadOnly_0.SelectedValueChanged -= this.comboBoxReadOnly_0_SelectedValueChanged;
				int num = Convert.ToInt32(@class.Rows[0]["typeAbn"]);
				Class10.Class16 class2 = new Class10.Class16();
				DataColumn dataColumn = new DataColumn("AddressFL");
				dataColumn.Expression = "street + ', д. ' + houseall + isnull(', кв. ' + name, '')";
				class2.Columns.Add(dataColumn);
				dataColumn = new DataColumn("AddressUL");
				dataColumn.Expression = "street + ', д. ' + houseall";
				class2.Columns.Add(dataColumn);
				base.SelectSqlData(class2, true, "where idAbn = " + this.IdAbn.ToString() + " order by name", null, false, 0);
				this.comboBoxReadOnly_0.ValueMember = "id";
				this.comboBoxReadOnly_0.DataSource = class2;
				if (num != 206 && num != 253)
				{
					if (num != 1037)
					{
						this.comboBoxReadOnly_0.DisplayMember = "name";
						goto IL_154;
					}
				}
				this.comboBoxReadOnly_0.DisplayMember = "AddressFL";
				IL_154:
				this.comboBoxReadOnly_0.SelectedValue = this.IdAbnObj;
				if (this.comboBoxReadOnly_0.SelectedValue == null)
				{
					this.IdAbnObj = -1;
				}
				this.comboBoxReadOnly_0.SelectedValueChanged += this.comboBoxReadOnly_0_SelectedValueChanged;
				return;
			}
			this.comboBoxReadOnly_0.Items.Clear();
			this.IdAbnObj = -1;
		}

		private void comboBoxReadOnly_0_SelectedValueChanged(object sender, EventArgs e)
		{
			if (this.comboBoxReadOnly_0.SelectedValue != null || this.comboBoxReadOnly_0.SelectedValue != DBNull.Value)
			{
				this.IdAbnObj = Convert.ToInt32(this.comboBoxReadOnly_0.SelectedValue);
			}
		}

		private void comboBox_0_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		private void toolStripButton_3_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.DefaultExt = ".jpg";
			saveFileDialog.FileName = "Temp";
			saveFileDialog.Title = "Сохраните файл с изображением в любой папке";
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				ImageCompress.SaveBitmapUsingExtension(this.pictureBox_0.Image, saveFileDialog.FileName);
			}
			if (saveFileDialog.FileName != "")
			{
				this.process_0.StartInfo.FileName = saveFileDialog.FileName;
				this.process_0.EnableRaisingEvents = true;
				this.process_0.Exited += this.process_0_Exited;
				this.process_0.Start();
				return;
			}
			MessageBox.Show("Отсутствует имя файла!");
		}

		private void process_0_Exited(object sender, EventArgs e)
		{
			this.process_0.Exited -= this.process_0_Exited;
		}

		private void method_14(int int_5)
		{
			if ((int)this.comboBox_0.SelectedValue != -1)
			{
				SqlDataConnect sqlDataConnect = new SqlDataConnect();
				try
				{
					sqlDataConnect.OpenConnection(this.SqlSettings);
					SqlCommand sqlCommand = new SqlCommand("select dbo.fn_GetMaxNumAct(@Region, @ActYear, @TypeDocValue)", sqlDataConnect.Connection);
					SqlParameter value = new SqlParameter("@Region", (int)this.comboBox_0.SelectedValue);
					sqlCommand.Parameters.Add(value);
					SqlParameter value2 = new SqlParameter("@ActYear", this.dateTimePicker_0.Value.Year);
					sqlCommand.Parameters.Add(value2);
					SqlParameter value3 = new SqlParameter("@TypeDocValue", int_5);
					sqlCommand.Parameters.Add(value3);
					sqlCommand.CommandTimeout = 0;
					string text = sqlCommand.ExecuteScalar().ToString();
					this.textBox_7.Text = text;
					return;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, ex.Source);
					return;
				}
				finally
				{
					sqlDataConnect.CloseConnection();
				}
			}
			this.textBox_7.Text = "";
		}

		private void comboBox_0_SelectedValueChanged(object sender, EventArgs e)
		{
			if (this.comboBox_0.SelectedValue is int && this.enum2_0 == (Enum2)0)
			{
				this.method_14((int)this.method_0());
			}
		}

		private void button_2_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			base.Close();
		}

		private void toolStripMenuItem_4_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Multiselect = true;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				foreach (string string_ in openFileDialog.FileNames)
				{
					if (!string.IsNullOrEmpty(this.method_22(string_, null, null, true)))
					{
						this.bool_1 = true;
					}
				}
			}
		}

		private void toolStripMenuItem_5_Click(object sender, EventArgs e)
		{
			this.method_23(true);
		}

		private void toolStripMenuItem_6_Click(object sender, EventArgs e)
		{
			this.method_23(false);
		}

		private void toolStripMenuItem_7_Click(object sender, EventArgs e)
		{
			if (this.bindingSource_0.Current != null && MessageBox.Show("Вы действительно хотите удалить выбранный файл?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				Class255.Class452 @class = (Class255.Class452)((DataRowView)this.bindingSource_0.Current).Row;
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
				this.bool_1 = true;
			}
		}

		private void toolStripMenuItem_8_Click(object sender, EventArgs e)
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

		private void toolStripMenuItem_9_Click(object sender, EventArgs e)
		{
			if (this.bindingSource_0.Current != null)
			{
				Class255.Class452 @class = (Class255.Class452)((DataRowView)this.bindingSource_0.Current).Row;
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

		private void dataGridViewExcelFilter_1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			this.toolStripMenuItem_6_Click(sender, e);
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
			}
			this.dataGridViewExcelFilter_1[e.ColumnIndex, e.RowIndex].Value = text;
			this.bool_1 = true;
			this.string_0 = null;
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

		private void dataGridViewExcelFilter_1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Button == MouseButtons.Right)
			{
				this.dataGridViewExcelFilter_1.ClearSelection();
				this.dataGridViewExcelFilter_1.Rows[e.RowIndex].Selected = true;
				this.dataGridViewExcelFilter_1.CurrentCell = this.dataGridViewExcelFilter_1[e.ColumnIndex, e.RowIndex];
				Rectangle cellDisplayRectangle = this.dataGridViewExcelFilter_1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
				this.contextMenuStrip_1.Show((System.Windows.Forms.Control)sender, cellDisplayRectangle.Left + e.X, cellDisplayRectangle.Top + e.Y);
			}
		}

		private void method_15(object sender, DataGridViewDataErrorEventArgs e)
		{
		}

		public void CreateActRbp(string AbnName, string fullFileName)
		{
			string replaceWith = "";
			string text = "";
			string text2 = "";
			string text3 = "";
			string text4 = "";
			string text5 = "";
			string str = "";
			base.SelectSqlData(this.class255_0.tAbnDoc_List, true, string.Format(" where idAbn = {0} and idDocType = {1} and isActive <> 0 and Deleted = 0", this.IdAbn, 501), null, true, 0);
			if (this.class255_0.tAbnDoc_List.Rows.Count > 0)
			{
				text5 = string.Format("Приложение №4 к договору № {0} от {1} г.", this.class255_0.tAbnDoc_List.First<Class255.Class449>().DocNumber.Trim(), this.class255_0.tAbnDoc_List.First<Class255.Class449>().DocDate.ToShortDateString());
			}
			base.SelectSqlData(this.class255_1.tG_AbnAddress, true, string.Format(" where idAbn = {0} and idTypeAddress = {1} order by DateChange desc", this.IdAbn, 54), null, true, 0);
			if (this.class255_1.tG_AbnAddress.Count > 0)
			{
				str = this.class255_1.tG_AbnAddress.First<Class255.Class450>().Representation;
			}
			base.SelectSqlData(this.class255_1.tAbnContact, true, " where idAbn = " + this.IdAbn + " and Post LIKE 'ОДС'", null, true, 0);
			if (this.class255_1.tAbnContact.Count > 0)
			{
				replaceWith = this.class255_1.tAbnContact.First<Class255.Class448>().Phone;
			}
			if (this.IdActTehConnection != -1)
			{
				base.SelectSqlData(this.class255_0, this.class255_0.tTC_Doc, true, string.Format("WHERE id = {0}", this.IdActTehConnection));
				if (this.class255_0.tTC_Doc.Rows.Count > 0)
				{
					text = ((this.class255_0.tTC_Doc.First<Class255.Class456>()["dateDoc"] == DBNull.Value) ? "" : this.class255_0.tTC_Doc.First<Class255.Class456>().dateDoc.ToShortDateString());
					text2 = ((this.class255_0.tTC_Doc.First<Class255.Class456>()["numDoc"] == DBNull.Value) ? "" : this.class255_0.tTC_Doc.First<Class255.Class456>().numDoc.ToString());
				}
				base.SelectSqlData(this.class255_0, this.class255_0.tTC_ActTC, true, string.Format("WHERE id = {0}", this.IdActTehConnection));
				if (this.class255_0.tTC_ActTC.Rows.Count > 0)
				{
					text3 = ((this.class255_0.tTC_ActTC.First<Class255.Class453>()["PowerSum"] == DBNull.Value) ? "" : this.class255_0.tTC_ActTC.First<Class255.Class453>().PowerSum.ToString());
					text4 = "";
				}
				base.SelectSqlData(this.class255_0, this.class255_0.vTC_TUPointAttach, true, string.Format("WHERE idTU = {0} and (typeDoc is null or typeDoc = {1})", this.IdActTehConnection, 1240));
			}
			OfficeLB.Word.Application application = null;
			try
			{
				application = new OfficeLB.Word.Application();
			}
			catch (Exception)
			{
				MessageBox.Show("Отсутствует предустановленный MS Office Word", "Ошибка MS Office", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			if (application != null)
			{
				try
				{
					application.Documents.Open(fullFileName);
					Selection selection = application.Selection;
					if (text5.Length > 0)
					{
						selection.FindAndReplace("[Привязка_кдоговору]", text5, true);
					}
					else
					{
						selection.FindAndReplace("[Привязка_кдоговору]", "", true);
					}
					selection.FindAndReplace("[Абонент_наименование]", AbnName + " " + str, true);
					selection.FindAndReplace("[Телефон]", "32-32-34", true);
					selection.FindAndReplace("[Телефон2]", replaceWith, true);
					DataTable dataTable = base.SelectSqlData("tR_Classifier", true, "WHERE id = " + this.comboBox_0.SelectedValue.ToString());
					string text6 = (dataTable.Rows.Count > 0) ? Math.Round((decimal)dataTable.Rows[0]["Value"], 0).ToString() : "";
					selection.FindAndReplace("[Номер_района]", text6, true);
					string replaceWith2 = "";
					base.SelectSqlData(this.class255_0.vP_Worker, true, string.Format(" where ParentKey = ';GroupWorker;HeadRegionApart;' AND Value = {0}", (dataTable.Rows.Count > 0) ? dataTable.Rows[0]["Value"].ToString().Replace(',', '.') : "-1"), null, true, 0);
					if (this.class255_0.vP_Worker.Rows.Count > 0)
					{
						replaceWith2 = this.class255_0.vP_Worker.Rows[0]["FIO"].ToString().Trim();
					}
					selection.FindAndReplace("[Начальник_района]", replaceWith2, true);
					selection.FindAndReplace("[Дата_Акта]", this.dateTimePicker_0.Value.ToShortDateString(), true);
					string replaceWith3 = string.Concat(new string[]
					{
						text6,
						"/",
						this.textBox_7.Text,
						"/",
						this.dateTimePicker_0.Value.Year.ToString().Substring(2, 2)
					});
					selection.FindAndReplace("[Номер_Акта]", replaceWith3, true);
					selection.FindAndReplace("[Потребитель_влице]", this.textBox_6.Text, true);
					selection.FindAndReplace("[Потребитель_Основание]", this.textBox_5.Text, true);
					selection.Find.ClearFormatting();
					selection.Find.Text = "[Сетевая_оборудование]";
					if (selection.Find.Execute())
					{
						selection.FindAndReplace("[Сетевая_оборудование]", this.textBoxDropDown_7.Text, false);
						selection.FindAndReplace("[Сетевая_оборудование]", "", true);
					}
					selection.Find.ClearFormatting();
					selection.Find.Text = "[Потребитель_оборудование]";
					if (selection.Find.Execute())
					{
						selection.FindAndReplace("[Потребитель_оборудование]", this.textBoxDropDown_1.Text, false);
						selection.FindAndReplace("[Потребитель_оборудование]", "", true);
					}
					selection.Find.ClearFormatting();
					selection.Find.Text = "[Граница]";
					if (selection.Find.Execute())
					{
						selection.FindAndReplace("[Граница]", this.textBoxDropDown_0.Text, false);
						selection.FindAndReplace("[Граница]", "", true);
					}
					selection.FindAndReplace("[Сетевая_эксплуатация]", this.textBox_4.Text, false);
					selection.FindAndReplace("[Сетевая_эксплуатация]", "", true);
					selection.FindAndReplace("[Потребитель_эксплуатация]", this.textBox_3.Text, false);
					selection.FindAndReplace("[Потребитель_эксплуатация]", "", true);
					selection.FindAndReplace("[Ответственность]", this.textBox_2.Text, false);
					selection.FindAndReplace("[Ответственность]", "", true);
					if (selection.FindAndReplace("[Ответственность2]", "[Ответственность2]", true))
					{
						selection.FindAndReplace("[Ответственность2]", this.textBox_2.Text, false);
					}
					selection.FindAndReplace("[Потребитель_допуск]", this.textBox_1.Text, false);
					selection.FindAndReplace("[Потребитель_допуск]", "", true);
					selection.FindAndReplace("[Потребитель_подпись]", this.textBox_0.Text, true);
					selection.FindAndReplace("[Дата тех прис]", (text.Length == 0) ? "                  " : text, true);
					selection.FindAndReplace("[Номер тех прис]", (text2.Length == 0) ? "                  " : text2, true);
					selection.FindAndReplace("[Макс мощность]", (text3.Length == 0) ? "        " : text3, true);
					selection.FindAndReplace("[Ном мощность]", (text4.Length == 0) ? "        " : text4, true);
					selection.FindAndReplace("[Адрес границы]", "                                                                                                                                                                      ", true);
					if (this.textBox_18.Text.Length > 0)
					{
						selection.FindAndReplace("[Прочее]", this.textBox_18.Text, false);
					}
					else
					{
						selection.FindAndReplace("[Прочее]", "                                                                                                                                                                   ", true);
					}
					if (application.ActiveDocument.Tables.Count == 3 && application.ActiveDocument.Tables[1].Columns.Count == 7 && application.ActiveDocument.Tables[2].Columns.Count == 2 && application.ActiveDocument.Tables[3].Columns.Count == 1)
					{
						Table table = application.ActiveDocument.Tables[1];
						for (int i = 0; i < this.class255_0.vTC_TUPointAttach.Count; i++)
						{
							Row row = table.Rows[i + 2];
							Range range = row.Cells[1].Range;
							row.Cells[1].Range.Text = this.class255_0.vTC_TUPointAttach.Rows[i]["AttachmentPoint"].ToString();
							row.Cells[2].Range.Text = this.class255_0.vTC_TUPointAttach.Rows[i]["PowerSupply"].ToString();
							row.Cells[3].Range.Text = "";
							row.Cells[4].Range.Text = this.class255_0.vTC_TUPointAttach.Rows[i]["voltagelevelname"].ToString();
							row.Cells[5].Range.Text = this.class255_0.vTC_TUPointAttach.Rows[i]["powersum"].ToString();
							row.Cells[6].Range.Text = "";
							row.Cells[7].Range.Text = this.class255_0.vTC_TUPointAttach.Rows[i]["Category"].ToString();
							if (table.Rows.Count != this.class255_0.vTC_TUPointAttach.Count + 1)
							{
								table.Rows.Add();
							}
						}
						Table table2 = application.ActiveDocument.Tables[2];
						table2.Rows[2].Cells[1].Range.Text = this.textBoxDropDown_7.Text;
						table2.Rows[2].Cells[2].Range.Text = this.textBoxDropDown_1.Text;
					}
					selection.FindAndReplace("[Владелец_имя]", this.textBox_8.Text, true);
					selection.FindAndReplace("[Владелец_влице]", this.textBox_9.Text, true);
					selection.FindAndReplace("[Владелец_основание]", this.pbtrqMeGe2.Text, true);
					selection.FindAndReplace("[Владелец_оборудование]", this.QaFgrduphk.Text, false);
					selection.FindAndReplace("[Владелец_оборудование]", "", true);
					selection.FindAndReplace("[Владелец_эксплуатация]", this.textBoxDropDown_6.Text, false);
					selection.FindAndReplace("[Владелец_эксплуатация]", "", true);
					selection.FindAndReplace("[Граница2]", this.textBoxDropDown_5.Text, false);
					selection.FindAndReplace("[Граница2]", "", true);
					selection.FindAndReplace("[Владелец_подпись]", this.textBox_10.Text, true);
					selection.FindAndReplace("[Номер_ОТО]", this.peygMhnWkn.Text, false);
					selection.FindAndReplace("[Номер_ОТО]", "", true);
					selection.FindAndReplace("[Договор_ОТО2]", this.textBox_12.Text, false);
					selection.FindAndReplace("[Договор_ОТО2]", "", true);
					selection.FindAndReplace("[Договор_OTO1]", this.textBox_11.Text, false);
					selection.FindAndReplace("[Договор_OTO1]", "", true);
					selection.FindAndReplace("[Владелец2_имя]", this.textBox_15.Text, true);
					selection.FindAndReplace("[Владелец2_влице]", this.textBox_13.Text, true);
					selection.FindAndReplace("[Владелец2_основание]", this.textBox_14.Text, true);
					selection.FindAndReplace("[Владелец2_оборудование]", this.textBoxDropDown_4.Text, false);
					selection.FindAndReplace("[Владелец2_оборудование]", "", true);
					selection.FindAndReplace("[Владелец2_эксплуатация]", this.textBoxDropDown_3.Text, false);
					selection.FindAndReplace("[Владелец2_эксплуатация]", "", true);
					selection.FindAndReplace("[Граница3]", this.textBoxDropDown_2.Text, false);
					selection.FindAndReplace("[Граница3]", "", true);
					selection.FindAndReplace("[Владелец2_подпись]", this.textBox_13.Text, true);
				}
				catch (Exception)
				{
					MessageBox.Show("Не удалось создать документ", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				try
				{
					application.ActiveDocument.Save();
					application.Visible = true;
				}
				catch (Exception)
				{
					application.Quit();
					MessageBox.Show("Не удалось сохранить документ", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
		}

		private string method_16(string string_1)
		{
			string str = string.IsNullOrEmpty(string_1) ? string_1 : "tmp";
			string text = Path.GetTempPath() + "\\" + str + "\\";
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			return text;
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

		private void method_17(string string_1, string string_2, object object_0, bool bool_3 = false)
		{
			string text = this.method_19(this.IdAbn);
			int num = (int)((ToolStripMenuItem)object_0).Tag;
			string text2;
			byte[] array;
			this.GetTepmlate(num, out text2, out array);
			if (string.IsNullOrEmpty(string_2))
			{
				DateTime value = this.dateTimePicker_0.Value;
				string_2 = string.Concat(new string[]
				{
					base.CallSQLScalarFunction("dbo.TPStr", new string[]
					{
						this.IdAbnObj.ToString()
					}).ToString(),
					" ",
					text,
					" ",
					this.textBox_7.Text,
					" ",
					value.ToString("ddMMyy")
				}).Replace("\"", string.Empty) + ".doc";
			}
			string extension = new System.IO.FileInfo(string_2).Extension;
			uint num2 = PrivateImplementationDetails.ComputeStringHash(extension);
			if (num2 <= 1719562636u)
			{
				if (num2 <= 502676545u)
				{
					if (num2 != 469959950u)
					{
						if (num2 != 502676545u)
						{
							goto IL_224;
						}
						if (!(extension == ".xltx"))
						{
							goto IL_224;
						}
					}
					else
					{
						if (!(extension == ".xlsx"))
						{
							goto IL_224;
						}
						goto IL_224;
					}
				}
				else if (num2 != 1616086803u)
				{
					if (num2 != 1719562636u)
					{
						goto IL_224;
					}
					if (!(extension == ".dotx"))
					{
						goto IL_224;
					}
					goto IL_1F9;
				}
				else
				{
					if (!(extension == ".docx"))
					{
						goto IL_224;
					}
					goto IL_224;
				}
			}
			else if (num2 <= 3182675714u)
			{
				if (num2 != 3098787619u)
				{
					if (num2 != 3182675714u)
					{
						goto IL_224;
					}
					if (!(extension == ".xls"))
					{
						goto IL_224;
					}
					goto IL_224;
				}
				else if (!(extension == ".xlt"))
				{
					goto IL_224;
				}
			}
			else if (num2 != 3238515961u)
			{
				if (num2 != 3523735484u)
				{
					goto IL_224;
				}
				if (extension == ".dot")
				{
					goto IL_1F9;
				}
				goto IL_224;
			}
			else
			{
				if (extension == ".doc")
				{
					goto IL_224;
				}
				goto IL_224;
			}
			string_2 = string_2.Replace(extension, extension.Replace("t", "s"));
			goto IL_224;
			IL_1F9:
			string_2 = string_2.Replace(extension, extension.Replace("t", "c"));
			IL_224:
			string text3 = string.IsNullOrEmpty(string_1) ? this.method_16(this.textBox_7.Text) : string_1;
			string newFileNameIsExists = FileBinary.GetNewFileNameIsExists(text3, string_2, false);
			string text4 = this.method_22(string_2, new int?(num), array, bool_3);
			if (!string.IsNullOrEmpty(text4))
			{
				this.bool_1 = true;
				FileBinary fileBinary = new FileBinary(array, newFileNameIsExists, DateTime.Now);
				fileBinary.SaveToDisk(text3);
				extension = new System.IO.FileInfo(string_2).Extension;
				if (bool_3)
				{
					if (this.dictionary_0.ContainsKey(text4))
					{
						FileWatcher fileWatcher = new FileWatcher(text3, fileBinary.Name);
						fileWatcher.AnyChanged += this.method_20;
						fileWatcher.Start();
						this.dictionary_0[text4].TempName = newFileNameIsExists;
						this.dictionary_0[text4].Watcher = fileWatcher;
						this.dictionary_0[text4].OpenState = FileOpenState.Editing;
					}
					else
					{
						MessageBox.Show("Что то пошло не так");
					}
				}
				this.CreateActRbp(text, text3 + "\\" + newFileNameIsExists);
			}
		}

		private int method_18(int int_5)
		{
			int result = -1;
			DataTable dataTable = base.SelectSqlData("tAbnObj", true, string.Format(" where id = {0}", int_5));
			if (dataTable.Rows.Count > 0)
			{
				result = (int)dataTable.Rows[0]["idAbn"];
			}
			return result;
		}

		private string method_19(int int_5)
		{
			string result = "";
			base.SelectSqlData(this.class255_0.vAbn, true, string.Format(" where id = {0}", int_5), null, true, 0);
			if (this.class255_0.vAbn.Rows.Count > 0)
			{
				result = this.class255_0.vAbn.First<Class255.Class455>().Name.Trim();
			}
			return result;
		}

		private void method_20(object sender, FileSystemEventArgs e)
		{
			IEnumerable<KeyValuePair<string, FileWatcherArgsAddl>> fwargs = from item in this.dictionary_0
			where item.Value.TempName == e.Name
			select item;
			if (fwargs.Count<KeyValuePair<string, FileWatcherArgsAddl>>() > 0)
			{
				FileBinary fileBinary = new FileBinary(e.FullPath);
				EnumerableRowCollection<Class255.Class452> source = from rowFiles in this.class255_0.tAbnObjDoc_File
				where rowFiles.RowState != DataRowState.Deleted && rowFiles.FileName == fwargs.First<KeyValuePair<string, FileWatcherArgsAddl>>().Value.OriginalName
				select rowFiles;
				if (source.Count<Class255.Class452>() == 0)
				{
					Class255.Class452 @class = this.class255_0.tAbnObjDoc_File.method_5();
					Class255.Class452 class2 = @class;
					int id;
					if (this.class255_0.tAbnObjDoc_File.Min((Class255.Class452 min) => min.id) >= 0)
					{
						id = -1;
					}
					else
					{
						id = this.class255_0.tAbnObjDoc_File.Min((Class255.Class452 min) => min.id) - 1;
					}
					class2.id = id;
					@class.idList = this.IdList;
					@class.FileName = fwargs.First<KeyValuePair<string, FileWatcherArgsAddl>>().Value.OriginalName;
					@class.File = fileBinary.ByteArray;
					@class.dateChange = fileBinary.LastChanged;
					@class.idTemplate = fwargs.First<KeyValuePair<string, FileWatcherArgsAddl>>().Value.IdTemplate.Value;
					this.class255_0.tAbnObjDoc_File.method_0(@class);
				}
				else
				{
					source.First<Class255.Class452>().File = fileBinary.ByteArray;
					source.First<Class255.Class452>().dateChange = fileBinary.LastChanged;
					source.First<Class255.Class452>().EndEdit();
					this.bool_1 = true;
				}
				this.method_21();
				this.bool_1 = true;
			}
		}

		private void method_21()
		{
			if (base.InvokeRequired)
			{
				base.Invoke(new Action(this.method_38));
				return;
			}
			this.bindingSource_0.ResetBindings(false);
		}

		private string method_22(string string_1, int? nullable_1 = null, byte[] byte_0 = null, bool bool_3 = false)
		{
			string fileName = Path.GetFileName(string_1);
			bool flag = true;
			while ((base.SelectSqlData("tAbnObjDoc_File", true, string.Format("where idList = {0} AND FileName = '{1}'", this.IdList, fileName)).Rows.Count > 0 || this.dictionary_0.ContainsKey(fileName)) && bool_3)
			{
				if (MessageBox.Show("Файл с именем " + fileName + " уже существует. Изменить имя файла на другое?", "Внимание.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
				{
					flag = false;
					break;
				}
				FormNewFileName formNewFileName = new FormNewFileName(fileName);
				if (formNewFileName.ShowDialog() == DialogResult.OK)
				{
					fileName = formNewFileName.FileName;
				}
			}
			if (!flag)
			{
				return null;
			}
			if (bool_3)
			{
				FileWatcherArgsAddl value = new FileWatcherArgsAddl(nullable_1, fileName, null, FileOpenState.None);
				this.dictionary_0.Add(fileName, value);
				Class255.Class452 @class = this.class255_0.tAbnObjDoc_File.method_5();
				Class255.Class452 class2 = @class;
				int id;
				if (this.class255_0.tAbnObjDoc_File.Count <= 0)
				{
					id = -1;
				}
				else
				{
					id = (from r in this.class255_0.tAbnObjDoc_File
					where r.RowState != DataRowState.Deleted
					select r).Min((Class255.Class452 min) => min.id) - 1;
				}
				class2.id = id;
				@class.idList = this.IdList;
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
				this.class255_0.tAbnObjDoc_File.method_0(@class);
				@class.EndEdit();
				this.bool_1 = true;
			}
			return fileName;
		}

		private void method_23(bool bool_3 = false)
		{
			if (this.bindingSource_0.Current != null)
			{
				Class255.Class452 @class = (Class255.Class452)((DataRowView)this.bindingSource_0.Current).Row;
				string fileName = @class.FileName;
				string text = this.method_16(this.textBox_7.Text);
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
				if (bool_3)
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
					}
					else
					{
						FileWatcher fileWatcher3 = new FileWatcher(text, newFileNameIsExists);
						fileWatcher3.AnyChanged += this.method_20;
						fileWatcher3.Start();
						FileWatcherArgsAddl value = new FileWatcherArgsAddl(idTemplate, fileName, newFileNameIsExists, fileWatcher3, FileOpenState.Editing);
						this.dictionary_0.Add(fileName, value);
					}
					this.bool_1 = true;
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

		private bool method_24(int int_5)
		{
			foreach (DataRow dataRow in this.class255_0.tAbnObjDoc_File)
			{
				if (dataRow.RowState != DataRowState.Deleted && dataRow.RowState != DataRowState.Detached && Convert.ToInt32(dataRow["idList"]) != int_5)
				{
					dataRow["idList"] = int_5;
					dataRow.EndEdit();
				}
			}
			if (base.InsertSqlData(this.class255_0, this.class255_0.tAbnObjDoc_File) && base.UpdateSqlDataOnlyChange(this.class255_0.tAbnObjDoc_File) && base.DeleteSqlData(this.class255_0, this.class255_0.tAbnObjDoc_File))
			{
				this.class255_0.tAbnObjDoc_File.AcceptChanges();
				return true;
			}
			return false;
		}

		private void tabControl_0_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.tabControl_0.SelectedTab == this.tabPage_4)
			{
				if ((from r in this.class255_0.tAbnObjDoc_File
				select r.RowState == DataRowState.Added || r.RowState == DataRowState.Modified || r.RowState == DataRowState.Deleted).Count<bool>() == 0)
				{
					base.SelectSqlData(this.class255_0, this.class255_0.tAbnObjDoc_File, true, "where idList = " + this.IdList.ToString());
				}
			}
			if (this.tabControl_0.SelectedTab == this.tabPage_5)
			{
				this.method_25(this.IdActTehConnection);
			}
		}

		private void FormAbnAktRBP_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.enum2_0 != (Enum2)3 && base.DialogResult != DialogResult.OK && !this.bool_2 && this.bool_1 && MessageBox.Show("Документ изменен. Сохранить текущие изменения?", "Сохранение.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				try
				{
					if (this.method_34())
					{
						base.DialogResult = DialogResult.OK;
					}
					else
					{
						e.Cancel = true;
					}
				}
				catch (Exception ex)
				{
					if (MessageBox.Show(ex.Message + Environment.NewLine + "Закрыть окно?", "Ошибка", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand) == DialogResult.Cancel)
					{
						e.Cancel = true;
					}
				}
			}
		}

		private void textBox_14_TextChanged(object sender, EventArgs e)
		{
			this.bool_1 = this.bool_0;
		}

		private void FormAbnAktRBP_Shown(object sender, EventArgs e)
		{
			this.bool_0 = true;
		}

		private void method_25(int int_5)
		{
			this.bindingSource_2.RaiseListChangedEvents = true;
			this.bindingSource_2.CurrentChanged -= this.bindingSource_2_CurrentChanged;
			string text = "select  d.id, d.numdoc, d.datedoc,  isnull(d.numdoc + ' ', '') + 'от ' + isnull(convert( varchar(10),d.Datedoc, 104), '') as numDatedoc  from ttc_doc d  where typeDoc = " + 1240.ToString();
			text += "union select -1, null, null, '' order by numDoc, dateDoc ";
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
			this.bindingSource_2.DataSource = dataTable;
			this.bindingSource_2.Sort = "numDoc, dateDoc";
			this.comboBox_1.DataSource = this.bindingSource_2;
			this.comboBox_1.DisplayMember = "numDateDoc";
			this.comboBox_1.ValueMember = "id";
			if (int_5 != -1)
			{
				this.bindingSource_2.Position = this.bindingSource_2.Find("id", int_5);
			}
			this.bindingSource_2.CurrentChanged += this.bindingSource_2_CurrentChanged;
			this.bindingSource_2.RaiseListChangedEvents = false;
			this.bindingSource_2_CurrentChanged(this.bindingSource_2, new EventArgs());
		}

		private void bindingSource_2_CurrentChanged(object sender, EventArgs e)
		{
			if (this.bindingSource_2.Current != null)
			{
				this.IdActTehConnection = (int)((DataRowView)this.bindingSource_2.Current)["id"];
				base.SelectSqlData(this.class255_0, this.class255_0.tTC_ActTC, true, string.Format("WHERE id = {0} ", this.IdActTehConnection));
				base.SelectSqlData(this.class255_0, this.class255_0.vTC_TUPointAttach, true, string.Format("WHERE idTU = {0} and (typeDoc is null or typeDoc = {1})", this.IdActTehConnection, 1240));
				return;
			}
			this.IdActTehConnection = -1;
			this.class255_0.tTC_ActTC.Rows.Clear();
			this.class255_0.vTC_TUPointAttach.Rows.Clear();
		}

		private void method_26()
		{
			this.dataGridView_1.Rows.Clear();
			if (this.IdList > 0)
			{
				string where = string.Concat(new string[]
				{
					" where idTU = ",
					this.IdList.ToString(),
					" and typeDoc = ",
					this.nullable_0.ToString(),
					"  order by num"
				});
				base.SelectSqlData(this.class10_0, this.class10_0.tTC_TUPointAttach, true, where);
				base.SelectSqlData(this.class10_0, this.class10_0.vTC_TUPointAttach, true, where);
				foreach (DataRow dataRow in this.class10_0.vTC_TUPointAttach)
				{
					this.dataGridView_1.Rows.Add(new object[]
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
						dataRow["PowerSum"]
					});
				}
			}
		}

		private void method_27()
		{
			this.dataGridView_1.Rows.Clear();
			base.SelectSqlData(this.class10_0, this.class10_0.vTC_TUPointAttach, true, string.Concat(new string[]
			{
				" where idTU = ",
				this.IdTU.ToString(),
				" and (typeDoc is null or typeDoc = ",
				1123.ToString(),
				")  order by num"
			}));
			foreach (DataRow dataRow in this.class10_0.vTC_TUPointAttach)
			{
				this.dataGridView_1.Rows.Add(new object[]
				{
					-1,
					-1,
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
					dataRow["PowerSum"]
				});
			}
		}

		private void toolStripButton_9_Click(object sender, EventArgs e)
		{
			GForm0 gform = new GForm0();
			gform.SqlSettings = this.SqlSettings;
			if (gform.ShowDialog() == DialogResult.OK)
			{
				this.dataGridView_1.Rows.Add(new object[]
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
					gform.PowerSum
				});
				this.bool_1 = true;
			}
		}

		private void toolStripButton_10_Click(object sender, EventArgs e)
		{
			if (this.dataGridView_1.CurrentRow != null)
			{
				GForm0 gform = new GForm0(this.dataGridView_1.CurrentRow);
				gform.SqlSettings = this.SqlSettings;
				if (gform.ShowDialog() == DialogResult.OK)
				{
					this.dataGridView_1.CurrentRow.Cells[this.dataGridViewTextBoxColumn_60.Name].Value = gform.idSubPoint;
					this.dataGridView_1.CurrentRow.Cells[this.dataGridViewTextBoxColumn_61.Name].Value = gform.SubPoint;
					this.dataGridView_1.CurrentRow.Cells[this.dataGridViewTextBoxColumn_62.Name].Value = gform.idBusPoint;
					this.dataGridView_1.CurrentRow.Cells[this.dataGridViewTextBoxColumn_63.Name].Value = gform.BusPoint;
					this.dataGridView_1.CurrentRow.Cells[this.dataGridViewTextBoxColumn_64.Name].Value = gform.idCellPoint;
					this.dataGridView_1.CurrentRow.Cells[this.dataGridViewTextBoxColumn_65.Name].Value = gform.CellPoint;
					this.dataGridView_1.CurrentRow.Cells[this.dataGridViewTextBoxColumn_66.Name].Value = gform.idSubCP;
					this.dataGridView_1.CurrentRow.Cells[this.dataGridViewTextBoxColumn_67.Name].Value = gform.SubCP;
					this.dataGridView_1.CurrentRow.Cells[this.dataGridViewTextBoxColumn_68.Name].Value = gform.idBusCP;
					this.dataGridView_1.CurrentRow.Cells[this.dataGridViewTextBoxColumn_69.Name].Value = gform.BusCP;
					this.dataGridView_1.CurrentRow.Cells[this.dataGridViewTextBoxColumn_70.Name].Value = gform.idCellCP;
					this.dataGridView_1.CurrentRow.Cells[this.dataGridViewTextBoxColumn_71.Name].Value = gform.CellCP;
					this.dataGridView_1.CurrentRow.Cells[this.dataGridViewTextBoxColumn_72.Name].Value = gform.idVoltagelevel;
					this.dataGridView_1.CurrentRow.Cells[this.dataGridViewTextBoxColumn_73.Name].Value = gform.VoltageLevel;
					this.dataGridView_1.CurrentRow.Cells[this.dataGridViewTextBoxColumn_74.Name].Value = gform.PowerSum;
					this.bool_1 = true;
				}
			}
		}

		private void dataGridView_1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && this.toolStripButton_10.Visible && this.toolStripButton_10.Enabled)
			{
				this.toolStripButton_10_Click(sender, e);
			}
		}

		private void toolStripButton_11_Click(object sender, EventArgs e)
		{
			if (this.dataGridView_1.CurrentRow != null)
			{
				this.dataGridView_1.Rows.Remove(this.dataGridView_1.CurrentRow);
				this.bool_1 = true;
			}
		}

		private void toolStripButton_12_Click(object sender, EventArgs e)
		{
			if (this.dataGridView_1.CurrentRow != null && this.dataGridView_1.CurrentRow.Index > 0)
			{
				int index = this.dataGridView_1.CurrentRow.Index;
				DataGridViewRow currentRow = this.dataGridView_1.CurrentRow;
				this.dataGridView_1.Rows.Remove(this.dataGridView_1.CurrentRow);
				this.dataGridView_1.Rows.Insert(index - 1, currentRow);
				this.dataGridView_1.FirstDisplayedScrollingRowIndex = index - 1;
				this.dataGridView_1[this.dataGridViewTextBoxColumn_61.Name, index - 1].Selected = true;
				this.dataGridView_1.CurrentCell = this.dataGridView_1[this.dataGridViewTextBoxColumn_61.Name, index - 1];
				this.bool_1 = true;
			}
		}

		private void toolStripButton_13_Click(object sender, EventArgs e)
		{
			if (this.dataGridView_1.CurrentRow != null && this.dataGridView_1.CurrentRow.Index < this.dataGridView_1.Rows.Count - 1)
			{
				int index = this.dataGridView_1.CurrentRow.Index;
				DataGridViewRow currentRow = this.dataGridView_1.CurrentRow;
				this.dataGridView_1.Rows.Remove(this.dataGridView_1.CurrentRow);
				this.dataGridView_1.Rows.Insert(index + 1, currentRow);
				this.dataGridView_1.FirstDisplayedScrollingRowIndex = index + 1;
				this.dataGridView_1[this.dataGridViewTextBoxColumn_61.Name, index + 1].Selected = true;
				this.dataGridView_1.CurrentCell = this.dataGridView_1[this.dataGridViewTextBoxColumn_61.Name, index + 1];
				this.bool_1 = true;
			}
		}

		private bool method_28()
		{
			if (!this.method_29(this.class10_0.tTC_TUPointAttach, this.IdList, Convert.ToInt32(this.nullable_0)))
			{
				return false;
			}
			if (this.IdActTehConnection > 0)
			{
				string where = string.Concat(new string[]
				{
					" where idTU = ",
					this.IdActTehConnection.ToString(),
					" and (typeDoc is null or typeDoc = ",
					1240.ToString(),
					")   order by num"
				});
				Class10.Class33 @class = new Class10.Class33();
				base.SelectSqlData(@class, true, where, null, false, 0);
				if (!this.method_29(@class, this.IdActTehConnection, 1240))
				{
					return false;
				}
				this.method_31();
			}
			return true;
		}

		private bool method_29(DataTable dataTable_0, int int_5, int int_6)
		{
			foreach (object obj in ((IEnumerable)this.dataGridView_1.Rows))
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
				if (dataGridViewRow.Index < dataTable_0.Rows.Count)
				{
					dataTable_0.Rows[dataGridViewRow.Index]["idTU"] = int_5;
					dataTable_0.Rows[dataGridViewRow.Index]["num"] = dataGridViewRow.Index + 1;
					dataTable_0.Rows[dataGridViewRow.Index]["idSubPoint"] = ((dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_60.Name].Value != null) ? dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_60.Name].Value : DBNull.Value);
					dataTable_0.Rows[dataGridViewRow.Index]["idBusPoint"] = ((dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_62.Name].Value != null) ? dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_62.Name].Value : DBNull.Value);
					dataTable_0.Rows[dataGridViewRow.Index]["idCellPoint"] = ((dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_64.Name].Value != null) ? dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_64.Name].Value : DBNull.Value);
					dataTable_0.Rows[dataGridViewRow.Index]["idSubCP"] = ((dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_66.Name].Value != null) ? dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_66.Name].Value : DBNull.Value);
					dataTable_0.Rows[dataGridViewRow.Index]["idBusCP"] = ((dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_68.Name].Value != null) ? dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_68.Name].Value : DBNull.Value);
					dataTable_0.Rows[dataGridViewRow.Index]["idCellCP"] = ((dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_70.Name].Value != null) ? dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_70.Name].Value : DBNull.Value);
					dataTable_0.Rows[dataGridViewRow.Index]["voltageLevel"] = ((dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_72.Name].Value != null) ? dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_72.Name].Value : DBNull.Value);
					dataTable_0.Rows[dataGridViewRow.Index]["PowerSum"] = ((dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_74.Name].Value != null) ? dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_74.Name].Value : DBNull.Value);
					dataTable_0.Rows[dataGridViewRow.Index]["TypeDoc"] = int_6;
					dataTable_0.Rows[dataGridViewRow.Index].EndEdit();
				}
				else
				{
					DataRow dataRow = dataTable_0.NewRow();
					dataRow["idTU"] = int_5;
					dataRow["num"] = dataGridViewRow.Index + 1;
					if (dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_60.Name].Value != null)
					{
						dataRow["idSubPoint"] = dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_60.Name].Value;
					}
					if (dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_62.Name].Value != null)
					{
						dataRow["idBusPoint"] = dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_62.Name].Value;
					}
					if (dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_64.Name].Value != null)
					{
						dataRow["idCellPoint"] = dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_64.Name].Value;
					}
					if (dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_66.Name].Value != null)
					{
						dataRow["idSubCP"] = dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_66.Name].Value;
					}
					if (dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_68.Name].Value != null)
					{
						dataRow["idBusCP"] = dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_68.Name].Value;
					}
					if (dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_70.Name].Value != null)
					{
						dataRow["idCellCP"] = dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_70.Name].Value;
					}
					if (dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_72.Name].Value != null)
					{
						dataRow["voltageLevel"] = dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_72.Name].Value;
					}
					if (dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_74.Name].Value != null)
					{
						dataRow["PowerSum"] = dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_74.Name].Value;
					}
					dataRow["TypeDoc"] = int_6;
					dataTable_0.Rows.Add(dataRow);
				}
			}
			for (int i = dataTable_0.Rows.Count - 1; i > this.dataGridView_1.Rows.Count - 1; i--)
			{
				dataTable_0.Rows[i].Delete();
			}
			base.InsertSqlData(dataTable_0);
			base.UpdateSqlData(dataTable_0);
			base.DeleteSqlData(dataTable_0);
			this.method_26();
			return true;
		}

		private bool method_30()
		{
			if (this.panel_1.Visible)
			{
				return true;
			}
			if (this.IdAbn > 0 && this.IdAbnObj > 0)
			{
				Class10.Class52 @class = new Class10.Class52();
				base.SelectSqlData(@class, true, " where idDoc = " + this.IdList.ToString() + " and typeDoc = " + this.nullable_0.ToString(), null, false, 0);
				List<int> list = new List<int>();
				foreach (DataRow dataRow in this.class10_0.tTC_TUPointAttach)
				{
					int num = -1;
					if (dataRow["idCellPoint"] != DBNull.Value)
					{
						num = Convert.ToInt32(dataRow["idCellPoint"]);
					}
					else if (dataRow["idBusPoint"] != DBNull.Value)
					{
						num = Convert.ToInt32(dataRow["idBusPoint"]);
					}
					else if (dataRow["idSubPoint"] != DBNull.Value)
					{
						num = Convert.ToInt32(dataRow["idSubPoint"]);
					}
					if (num != -1)
					{
						DataRow[] array = @class.Select("idSChmObj = " + num.ToString());
						if (array.Count<DataRow>() > 0)
						{
							array[0]["idAbn"] = this.IdAbn;
							array[0]["idAbnObj"] = this.IdAbnObj;
							array[0]["idPoint"] = DBNull.Value;
							array[0]["idDoc"] = this.IdList;
							array[0]["typeDoc"] = this.nullable_0;
							array[0].EndEdit();
							list.Add((int)array[0]["id"]);
						}
						else
						{
							DataRow dataRow2 = @class.NewRow();
							dataRow2["idSchmObj"] = num;
							dataRow2["idAbn"] = this.IdAbn;
							dataRow2["idAbnObj"] = this.IdAbnObj;
							dataRow2["idPoint"] = DBNull.Value;
							dataRow2["idDoc"] = this.IdList;
							dataRow2["typeDoc"] = this.nullable_0;
							@class.Rows.Add(dataRow2);
						}
					}
				}
				foreach (object obj in @class.Rows)
				{
					DataRow dataRow3 = (DataRow)obj;
					if (dataRow3.RowState != DataRowState.Added && !list.Contains(Convert.ToInt32(dataRow3["id"])))
					{
						base.DeleteSqlDataById(@class, Convert.ToInt32(dataRow3["id"]));
					}
				}
				return base.InsertSqlData(@class) && base.UpdateSqlData(@class);
			}
			return true;
		}

		private bool method_31()
		{
			Class10.Class52 @class = new Class10.Class52();
			base.SelectSqlData(@class, true, " where idDoc = " + this.IdActTehConnection.ToString() + " and typeDoc = " + 1240.ToString(), null, false, 0);
			foreach (object obj in @class.Rows)
			{
				DataRow dataRow = (DataRow)obj;
				base.DeleteSqlDataById(@class, Convert.ToInt32(dataRow["id"]));
			}
			return true;
		}

		private bool method_32()
		{
			if (this.IdAbn > 0 && this.IdAbnObj > 0)
			{
				Class10.Class11 @class = new Class10.Class11();
				base.SelectSqlData(@class, true, "where id = " + this.IdAbn.ToString(), null, false, 0);
				Class10.Class29 class2 = new Class10.Class29();
				base.SelectSqlData(class2, true, "where id = " + this.IdAbnObj.ToString(), null, false, 0);
				if (@class.Rows.Count > 0)
				{
					if (Convert.ToInt32(@class.Rows[0]["TypeAbn"]) == 1037)
					{
						@class.Rows[0]["TypeAbn"] = 206;
					}
					if (Convert.ToInt32(@class.Rows[0]["TypeAbn"]) == 1038)
					{
						@class.Rows[0]["TypeAbn"] = 207;
					}
					@class.Rows[0].EndEdit();
					if (!base.UpdateSqlData(@class))
					{
						return false;
					}
				}
				if (class2.Rows.Count > 0 && class2.Rows[0]["typeObj"] != DBNull.Value)
				{
					if (Convert.ToInt32(class2.Rows[0]["typeObj"]) == 1148)
					{
						class2.Rows[0]["typeObj"] = 1146;
					}
					if (Convert.ToInt32(class2.Rows[0]["typeObj"]) == 1149)
					{
						class2.Rows[0]["typeObj"] = 1147;
					}
					class2.Rows[0].EndEdit();
					if (!base.UpdateSqlData(class2))
					{
						return false;
					}
				}
				Class10.Class58 class3 = new Class10.Class58();
				base.SelectSqlData(class3, true, string.Format(" where idAbn = {0}", this.IdAbn), null, false, 0);
				if (class3.Rows.Count == 0)
				{
					DataRow dataRow = class3.NewRow();
					dataRow["idAbn"] = this.IdAbn;
					dataRow["isActive"] = true;
					dataRow["dateChange"] = this.dateTimePicker_0.Value;
					class3.Rows.Add(dataRow);
					if (!base.InsertSqlData(class3))
					{
						return false;
					}
				}
				return true;
			}
			return true;
		}

		private int method_33(int int_5, string string_1, DateTime dateTime_0, int int_6)
		{
			base.SelectSqlData(this.class255_0.tAbnObjDoc_List, true, string.Concat(new string[]
			{
				" where idAbnObj = ",
				int_5.ToString(),
				" and  idDocType=",
				int_6.ToString(),
				" and isActive = 1"
			}), null, true, 0);
			if (this.class255_0.tAbnObjDoc_List.Rows.Count > 0)
			{
				this.class255_0.tAbnObjDoc_List.First<Class255.Class447>().isActive = false;
				base.UpdateSqlData(this.class255_0, this.class255_0.tAbnObjDoc_List);
			}
			this.dataRow_0 = this.class255_0.tAbnObjDoc_List.NewRow();
			this.dataRow_0["idAbnObj"] = int_5;
			this.dataRow_0["DocNumber"] = string_1;
			this.dataRow_0["DocDate"] = dateTime_0;
			this.dataRow_0["idDocType"] = int_6;
			this.dataRow_0["isActive"] = true;
			this.dataRow_0["Deleted"] = false;
			this.dataRow_0["idAbn"] = this.IdAbn;
			this.class255_0.tAbnObjDoc_List.Rows.Add(this.dataRow_0);
			base.InsertSqlData(this.class255_0, this.class255_0.tAbnObjDoc_List);
			base.SelectSqlData(this.class255_0.tAbnObjDoc_List, true, string.Concat(new string[]
			{
				" where idAbnObj = ",
				int_5.ToString(),
				" and  idDocType=",
				int_6.ToString(),
				" and  isActive = 1 order by id desc "
			}), null, true, 0);
			if (this.class255_0.tAbnObjDoc_List.Rows.Count > 0)
			{
				return Convert.ToInt32(this.class255_0.tAbnObjDoc_List.First<Class255.Class447>().id);
			}
			MessageBox.Show("Не удалось добавить документ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return -1;
		}

		private bool method_34()
		{
			if (this.comboBox_0.SelectedValue != null && (int)this.comboBox_0.SelectedValue != -1 && !(this.textBox_7.Text == ""))
			{
				bool result;
				try
				{
					int num = -1;
					int num2 = -1;
					int int_ = (int)base.CallSQLScalarFunction("dbo.fn_GetIdClassifier", new string[]
					{
						";TypeDoc;tAbnObj;",
						((int)this.method_0()).ToString()
					});
					this.button_3.DialogResult = DialogResult.OK;
					if (this.IdList == -1)
					{
						this.IdList = this.method_33(this.IdAbnObj, this.textBox_7.Text, this.dateTimePicker_0.Value, int_);
						if (this.IdList != -1)
						{
							this.dataRow_0 = this.class255_0.tAbnObjDoc_AktRBP.NewRow();
							this.dataRow_0["idList"] = this.IdList;
							if (this.IdActTehConnection != -1)
							{
								this.dataRow_0["idActTehConnection"] = this.IdActTehConnection;
							}
							else
							{
								this.dataRow_0["idActTehConnection"] = DBNull.Value;
							}
							if (this.IdTU != -1)
							{
								this.dataRow_0["idTU"] = this.IdTU;
							}
							else
							{
								this.dataRow_0["idTU"] = DBNull.Value;
							}
							this.dataRow_0["ActData"] = this.dateTimePicker_0.Value.ToShortDateString();
							this.dataRow_0["NetRegion"] = (int)this.comboBox_0.SelectedValue;
							this.dataRow_0["DataNumber"] = this.textBox_7.Text;
							this.dataRow_0["OrgFace"] = this.textBox_6.Text;
							this.dataRow_0["OrgBase"] = this.textBox_5.Text;
							this.dataRow_0["OrgBalance"] = this.textBoxDropDown_7.Text;
							this.dataRow_0["PotrBalance"] = this.textBoxDropDown_1.Text;
							this.dataRow_0["BorderBalance"] = this.textBoxDropDown_0.Text;
							this.dataRow_0["OrgExpl"] = this.textBox_4.Text;
							this.dataRow_0["PotrExpl"] = this.textBox_3.Text;
							this.dataRow_0["Responsibility"] = this.textBox_2.Text;
							this.dataRow_0["Admission"] = this.textBox_1.Text;
							this.dataRow_0["PotrSignature"] = this.textBox_0.Text;
							this.dataRow_0["Other"] = this.textBox_18.Text;
							this.dataRow_0["OwnerName"] = this.textBox_8.Text;
							this.dataRow_0["OwnerChief"] = this.textBox_9.Text;
							this.dataRow_0["OwnerBase"] = this.pbtrqMeGe2.Text;
							this.dataRow_0["OrganizExpl"] = this.QaFgrduphk.Text;
							this.dataRow_0["PotrebExpl"] = this.textBoxDropDown_6.Text;
							this.dataRow_0["BorderExpl"] = this.textBoxDropDown_5.Text;
							this.dataRow_0["OwnerChief2"] = this.textBox_10.Text;
							this.dataRow_0["tbDogByOTONum"] = this.peygMhnWkn.Text;
							this.dataRow_0["tbTO2"] = this.textBox_12.Text;
							this.dataRow_0["tbTO1"] = this.textBox_11.Text;
							this.dataRow_0["OwnerName_Four"] = this.textBox_15.Text;
							this.dataRow_0["OwnerChief_Four"] = this.BpwgFdgOge.Text;
							this.dataRow_0["OwnerBase_Four"] = this.textBox_14.Text;
							this.dataRow_0["OrganizExpl_Four"] = this.textBoxDropDown_4.Text;
							this.dataRow_0["Border2Expl_Four"] = this.textBoxDropDown_2.Text;
							this.dataRow_0["OwnerExpl_Four"] = this.textBoxDropDown_3.Text;
							this.dataRow_0["OwnerChief2_Four"] = this.textBox_13.Text;
							this.class255_0.tAbnObjDoc_AktRBP.Rows.Add(this.dataRow_0);
							base.InsertSqlData(this.class255_0, this.class255_0.tAbnObjDoc_AktRBP);
						}
						else
						{
							MessageBox.Show("Не удалось сохранить акт.", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
					}
					else
					{
						base.SelectSqlData(this.class255_0, this.class255_0.tAbnObjDoc_AktRBP, true, " where idList = " + this.IdList);
						base.SelectSqlData(this.class255_0, this.class255_0.tAbnObjDoc_List, true, "where id = " + this.IdList);
						if (this.class255_0.tAbnObjDoc_List.Rows.Count > 0)
						{
							if (this.class255_0.tAbnObjDoc_List.Rows[0]["idAbnObj"] != DBNull.Value)
							{
								num2 = Convert.ToInt32(this.class255_0.tAbnObjDoc_List.Rows[0]["idAbnObj"]);
							}
							if (this.class255_0.tAbnObjDoc_List.Rows[0]["idAbn"] != DBNull.Value)
							{
								num = Convert.ToInt32(this.class255_0.tAbnObjDoc_List.Rows[0]["idAbn"]);
							}
						}
						if (this.IdActTehConnection != -1)
						{
							this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>()["idActTehConnection"] = this.IdActTehConnection;
						}
						else
						{
							this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>()["idActTehConnection"] = DBNull.Value;
						}
						if (this.IdTU != -1)
						{
							this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>()["idTU"] = this.IdTU;
							this.class255_0.tAbnObjDoc_List.First<Class255.Class447>().isActive = true;
						}
						else
						{
							this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>()["idTU"] = DBNull.Value;
						}
						if ((num <= 0 || num2 <= 0) && this.IdTU != -1)
						{
							DataTable dataTable = base.SelectSqlData("vtc_tu", true, "where id = " + this.IdTU.ToString());
							if (dataTable.Rows.Count > 0)
							{
								if (dataTable.Rows[0]["idAbn"] != DBNull.Value)
								{
									this.IdAbn = Convert.ToInt32(dataTable.Rows[0]["idAbn"]);
									this.class255_0.tAbnObjDoc_List.First<Class255.Class447>().idAbn = this.IdAbn;
								}
								if (dataTable.Rows[0]["idAbnObj"] != DBNull.Value)
								{
									this.IdAbnObj = Convert.ToInt32(dataTable.Rows[0]["idAbnobj"]);
									this.class255_0.tAbnObjDoc_List.First<Class255.Class447>().idAbnObj = this.IdAbnObj;
								}
							}
						}
						if (num != this.IdAbn)
						{
							this.class255_0.tAbnObjDoc_List.First<Class255.Class447>().idAbn = this.IdAbn;
						}
						if (num2 != this.IdAbnObj)
						{
							this.class255_0.tAbnObjDoc_List.First<Class255.Class447>().idAbnObj = this.IdAbnObj;
						}
						this.class255_0.tAbnObjDoc_List.First<Class255.Class447>().DocDate = this.dateTimePicker_0.Value;
						this.class255_0.tAbnObjDoc_List.First<Class255.Class447>().DocNumber = this.textBox_7.Text;
						this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().ActData = this.dateTimePicker_0.Value.ToShortDateString();
						this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().NetRegion = (int)this.comboBox_0.SelectedValue;
						this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().DataNumber = this.textBox_7.Text;
						this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().OrgFace = this.textBox_6.Text;
						this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().OrgBase = this.textBox_5.Text;
						this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().OrgBalance = this.textBoxDropDown_7.Text;
						this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().PotrBalance = this.textBoxDropDown_1.Text;
						this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().BorderBalance = this.textBoxDropDown_0.Text;
						this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().OrgExpl = this.textBox_4.Text;
						this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().PotrExpl = this.textBox_3.Text;
						this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().Responsibility = this.textBox_2.Text;
						this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().Admission = this.textBox_1.Text;
						this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().PotrSignature = this.textBox_0.Text;
						this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().Other = this.textBox_18.Text;
						this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().OwnerName = this.textBox_8.Text;
						this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().OwnerChief = this.textBox_9.Text;
						this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().OwnerBase = this.pbtrqMeGe2.Text;
						this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().OrganizExpl = this.QaFgrduphk.Text;
						this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().PotrebExpl = this.textBoxDropDown_6.Text;
						this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().BorderExpl = this.textBoxDropDown_5.Text;
						this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().OwnerChief2 = this.textBox_10.Text;
						this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().tbDogByOTONum = this.peygMhnWkn.Text;
						this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().tbTO2 = this.textBox_12.Text;
						this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().tbTO1 = this.textBox_11.Text;
						this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().OwnerName_Four = this.textBox_15.Text;
						this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().OwnerChief_Four = this.BpwgFdgOge.Text;
						this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().OwnerBase_Four = this.textBox_14.Text;
						this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().OrganizExpl_Four = this.textBoxDropDown_4.Text;
						this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().Border2Expl_Four = this.textBoxDropDown_2.Text;
						this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().OwnerExpl_Four = this.textBoxDropDown_3.Text;
						this.class255_0.tAbnObjDoc_AktRBP.First<Class255.Class443>().OwnerChief2_Four = this.textBox_13.Text;
						base.UpdateSqlData(this.class255_0, this.class255_0.tAbnObjDoc_List);
						base.UpdateSqlData(this.class255_0, this.class255_0.tAbnObjDoc_AktRBP);
					}
					if (this.method_0() == TypeDocValue.ActBalance && !this.method_32())
					{
						result = false;
					}
					else if (!this.method_28())
					{
						result = false;
					}
					else if (this.method_0() == TypeDocValue.ActBalance && !this.method_30())
					{
						result = false;
					}
					else
					{
						this.method_24(this.IdList);
						base.DialogResult = DialogResult.OK;
						result = true;
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					result = false;
				}
				return result;
			}
			MessageBox.Show("Не выбран район или отсутствует номер акта");
			return false;
		}

		private void button_4_Click(object sender, EventArgs e)
		{
			FormTechConnectionAddAbn formTechConnectionAddAbn = new FormTechConnectionAddAbn(this.int_3, this.int_4, true);
			formTechConnectionAddAbn.ShowForm += this.method_36;
			formTechConnectionAddAbn.SqlSettings = this.SqlSettings;
			formTechConnectionAddAbn.MdiParent = base.MdiParent;
			formTechConnectionAddAbn.FormClosed += this.method_35;
			formTechConnectionAddAbn.Show();
		}

		private void method_35(object sender, FormClosedEventArgs e)
		{
			FormTechConnectionAddAbn formTechConnectionAddAbn = (FormTechConnectionAddAbn)sender;
			if (formTechConnectionAddAbn.DialogResult == DialogResult.OK)
			{
				this.textBox_19.Text = formTechConnectionAddAbn.AbnName;
				this.int_3 = formTechConnectionAddAbn.IdAbn;
				this.int_4 = formTechConnectionAddAbn.GetIdAbnObj();
				this.method_13();
			}
		}

		private FormBase method_36(object object_0, ShowFormEventArgs showFormEventArgs_0)
		{
			return this.OnShowForm(showFormEventArgs_0);
		}

		private void method_37()
		{
			this.icontainer_0 = new Container();
			DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FormAbnAktRBP));
			DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
			this.tableLayoutPanel_0 = new TableLayoutPanel();
			this.tabControl_0 = new System.Windows.Forms.TabControl();
			this.tabPage_0 = new TabPage();
			this.tableLayoutPanel_5 = new TableLayoutPanel();
			this.label_12 = new System.Windows.Forms.Label();
			this.label_2 = new System.Windows.Forms.Label();
			this.label_1 = new System.Windows.Forms.Label();
			this.dateTimePicker_0 = new DateTimePicker();
			this.label_11 = new System.Windows.Forms.Label();
			this.button_0 = new System.Windows.Forms.Button();
			this.textBox_1 = new System.Windows.Forms.TextBox();
			this.elementHost_5 = new ElementHost();
			this.textBox_2 = new System.Windows.Forms.TextBox();
			this.button_1 = new System.Windows.Forms.Button();
			this.textBox_3 = new System.Windows.Forms.TextBox();
			this.comboBox_0 = new System.Windows.Forms.ComboBox();
			this.elementHost_6 = new ElementHost();
			this.label_10 = new System.Windows.Forms.Label();
			this.elementHost_4 = new ElementHost();
			this.textBox_7 = new System.Windows.Forms.TextBox();
			this.textBox_4 = new System.Windows.Forms.TextBox();
			this.label_9 = new System.Windows.Forms.Label();
			this.textBox_6 = new System.Windows.Forms.TextBox();
			this.label_3 = new System.Windows.Forms.Label();
			this.label_8 = new System.Windows.Forms.Label();
			this.textBox_5 = new System.Windows.Forms.TextBox();
			this.label_7 = new System.Windows.Forms.Label();
			this.label_4 = new System.Windows.Forms.Label();
			this.label_6 = new System.Windows.Forms.Label();
			this.label_5 = new System.Windows.Forms.Label();
			this.label_0 = new System.Windows.Forms.Label();
			this.textBox_0 = new System.Windows.Forms.TextBox();
			this.label_37 = new System.Windows.Forms.Label();
			this.textBox_18 = new System.Windows.Forms.TextBox();
			this.label_38 = new System.Windows.Forms.Label();
			this.textBox_19 = new System.Windows.Forms.TextBox();
			this.label_39 = new System.Windows.Forms.Label();
			this.comboBoxReadOnly_0 = new ComboBoxReadOnly();
			this.button_4 = new System.Windows.Forms.Button();
			this.tabPage_6 = new TabPage();
			this.dataGridView_1 = new DataGridView();
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
			this.dataGridViewTextBoxColumn_68 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_69 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_70 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_71 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_72 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_73 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_74 = new DataGridViewTextBoxColumn();
			this.panel_1 = new System.Windows.Forms.Panel();
			this.textBox_21 = new System.Windows.Forms.TextBox();
			this.label_40 = new System.Windows.Forms.Label();
			this.label_41 = new System.Windows.Forms.Label();
			this.dateTimePicker_1 = new DateTimePicker();
			this.textBox_20 = new System.Windows.Forms.TextBox();
			this.label_42 = new System.Windows.Forms.Label();
			this.toolStrip_2 = new ToolStrip();
			this.toolStripButton_9 = new ToolStripButton();
			this.toolStripButton_10 = new ToolStripButton();
			this.toolStripButton_11 = new ToolStripButton();
			this.toolStripSeparator_4 = new ToolStripSeparator();
			this.toolStripButton_12 = new ToolStripButton();
			this.toolStripButton_13 = new ToolStripButton();
			this.tabPage_5 = new TabPage();
			this.tableLayoutPanel_2 = new TableLayoutPanel();
			this.panel_0 = new System.Windows.Forms.Panel();
			this.tableLayoutPanel_6 = new TableLayoutPanel();
			this.textBox_17 = new System.Windows.Forms.TextBox();
			this.bindingSource_3 = new BindingSource(this.icontainer_0);
			this.class255_0 = new Class255();
			this.dataGridView_0 = new DataGridView();
			this.dataGridViewTextBoxColumn_34 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_35 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_36 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_37 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_38 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_39 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_40 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_41 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_42 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_43 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_44 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_45 = new DataGridViewTextBoxColumn();
			this.dvuBbFynsI = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_46 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_47 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_48 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_49 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_50 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_51 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_52 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_53 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_54 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_55 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_56 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_57 = new DataGridViewTextBoxColumn();
			this.bindingSource_1 = new BindingSource(this.icontainer_0);
			this.label_35 = new System.Windows.Forms.Label();
			this.label_34 = new System.Windows.Forms.Label();
			this.label_33 = new System.Windows.Forms.Label();
			this.label_32 = new System.Windows.Forms.Label();
			this.textBox_16 = new System.Windows.Forms.TextBox();
			this.comboBox_1 = new System.Windows.Forms.ComboBox();
			this.label_36 = new System.Windows.Forms.Label();
			this.tabPage_1 = new TabPage();
			this.tableLayoutPanel_3 = new TableLayoutPanel();
			this.label_23 = new System.Windows.Forms.Label();
			this.label_13 = new System.Windows.Forms.Label();
			this.label_15 = new System.Windows.Forms.Label();
			this.textBox_8 = new System.Windows.Forms.TextBox();
			this.label_14 = new System.Windows.Forms.Label();
			this.textBox_9 = new System.Windows.Forms.TextBox();
			this.label_16 = new System.Windows.Forms.Label();
			this.pbtrqMeGe2 = new System.Windows.Forms.TextBox();
			this.label_19 = new System.Windows.Forms.Label();
			this.elementHost_7 = new ElementHost();
			this.peygMhnWkn = new System.Windows.Forms.TextBox();
			this.label_18 = new System.Windows.Forms.Label();
			this.label_17 = new System.Windows.Forms.Label();
			this.textBox_10 = new System.Windows.Forms.TextBox();
			this.textBox_11 = new System.Windows.Forms.TextBox();
			this.label_21 = new System.Windows.Forms.Label();
			this.label_24 = new System.Windows.Forms.Label();
			this.label_22 = new System.Windows.Forms.Label();
			this.label_20 = new System.Windows.Forms.Label();
			this.textBox_12 = new System.Windows.Forms.TextBox();
			this.elementHost_1 = new ElementHost();
			this.elementHost_0 = new ElementHost();
			this.tabPage_3 = new TabPage();
			this.tableLayoutPanel_4 = new TableLayoutPanel();
			this.label_31 = new System.Windows.Forms.Label();
			this.textBox_13 = new System.Windows.Forms.TextBox();
			this.label_30 = new System.Windows.Forms.Label();
			this.label_25 = new System.Windows.Forms.Label();
			this.textBox_15 = new System.Windows.Forms.TextBox();
			this.elementHost_3 = new ElementHost();
			this.lqAgvlGle9 = new System.Windows.Forms.Label();
			this.label_29 = new System.Windows.Forms.Label();
			this.elementHost_2 = new ElementHost();
			this.label_26 = new System.Windows.Forms.Label();
			this.BpwgFdgOge = new System.Windows.Forms.TextBox();
			this.label_27 = new System.Windows.Forms.Label();
			this.label_28 = new System.Windows.Forms.Label();
			this.uLmgjiJpjw = new ElementHost();
			this.textBox_14 = new System.Windows.Forms.TextBox();
			this.tabPage_2 = new TabPage();
			this.tableLayoutPanel_7 = new TableLayoutPanel();
			this.pictureBox_0 = new PictureBox();
			this.toolStrip_0 = new ToolStrip();
			this.toolStripButton_0 = new ToolStripButton();
			this.toolStripButton_1 = new ToolStripButton();
			this.toolStripButton_2 = new ToolStripButton();
			this.toolStripButton_3 = new ToolStripButton();
			this.dataGridViewExcelFilter_0 = new DataGridViewExcelFilter();
			this.dataGridViewImageColumn_0 = new DataGridViewImageColumn();
			this.dataGridViewImageColumn_1 = new DataGridViewImageColumn();
			this.dataGridViewCheckBoxColumn_0 = new DataGridViewCheckBoxColumn();
			this.dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
			this.tabPage_4 = new TabPage();
			this.tableLayoutPanel_1 = new TableLayoutPanel();
			this.toolStrip_1 = new ToolStrip();
			this.toolStripDropDownButton_0 = new ToolStripDropDownButton();
			this.toolStripMenuItem_2 = new ToolStripMenuItem();
			this.toolStripSeparator_0 = new ToolStripSeparator();
			this.toolStripButton_4 = new ToolStripButton();
			this.toolStripButton_5 = new ToolStripButton();
			this.toolStripButton_6 = new ToolStripButton();
			this.toolStripSeparator_1 = new ToolStripSeparator();
			this.toolStripButton_7 = new ToolStripButton();
			this.toolStripButton_8 = new ToolStripButton();
			this.dataGridViewExcelFilter_1 = new DataGridViewExcelFilter();
			this.dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_0 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewTextBoxColumn_3 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_4 = new DataGridViewTextBoxColumn();
			this.dataGridViewImageColumnNotNull_0 = new DataGridViewImageColumnNotNull();
			this.bindingSource_0 = new BindingSource(this.icontainer_0);
			this.button_2 = new System.Windows.Forms.Button();
			this.button_3 = new System.Windows.Forms.Button();
			this.bindingSource_2 = new BindingSource(this.icontainer_0);
			this.contextMenuStrip_0 = new ContextMenuStrip(this.icontainer_0);
			this.toolStripMenuItem_0 = new ToolStripMenuItem();
			this.toolStripMenuItem_1 = new ToolStripMenuItem();
			this.contextMenuStrip_1 = new ContextMenuStrip(this.icontainer_0);
			this.toolStripMenuItem_3 = new ToolStripMenuItem();
			this.toolStripMenuItem_4 = new ToolStripMenuItem();
			this.toolStripSeparator_2 = new ToolStripSeparator();
			this.toolStripMenuItem_5 = new ToolStripMenuItem();
			this.toolStripMenuItem_6 = new ToolStripMenuItem();
			this.toolStripMenuItem_7 = new ToolStripMenuItem();
			this.toolStripSeparator_3 = new ToolStripSeparator();
			this.toolStripMenuItem_8 = new ToolStripMenuItem();
			this.toolStripMenuItem_9 = new ToolStripMenuItem();
			this.dataGridViewImageColumn_2 = new DataGridViewImageColumn();
			this.dataGridViewImageColumn_3 = new DataGridViewImageColumn();
			this.dataGridViewCheckBoxColumn_1 = new DataGridViewCheckBoxColumn();
			this.dataGridViewImageColumnNotNull_1 = new DataGridViewImageColumnNotNull();
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
			this.dataGridViewTextBoxColumn_18 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_19 = new DataGridViewTextBoxColumn();
			this.qXfByJsXia = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_20 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_21 = new DataGridViewTextBoxColumn();
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
			this.dataGridViewFilterTextBoxColumn_1 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewTextBoxColumn_32 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_33 = new DataGridViewTextBoxColumn();
			this.class10_0 = new Class10();
			this.class255_1 = new Class255();
			this.tableLayoutPanel_0.SuspendLayout();
			this.tabControl_0.SuspendLayout();
			this.tabPage_0.SuspendLayout();
			this.tableLayoutPanel_5.SuspendLayout();
			this.tabPage_6.SuspendLayout();
			((ISupportInitialize)this.dataGridView_1).BeginInit();
			this.panel_1.SuspendLayout();
			this.toolStrip_2.SuspendLayout();
			this.tabPage_5.SuspendLayout();
			this.tableLayoutPanel_2.SuspendLayout();
			this.panel_0.SuspendLayout();
			this.tableLayoutPanel_6.SuspendLayout();
			((ISupportInitialize)this.bindingSource_3).BeginInit();
			((ISupportInitialize)this.class255_0).BeginInit();
			((ISupportInitialize)this.dataGridView_0).BeginInit();
			((ISupportInitialize)this.bindingSource_1).BeginInit();
			this.tabPage_1.SuspendLayout();
			this.tableLayoutPanel_3.SuspendLayout();
			this.tabPage_3.SuspendLayout();
			this.tableLayoutPanel_4.SuspendLayout();
			this.tabPage_2.SuspendLayout();
			this.tableLayoutPanel_7.SuspendLayout();
			((ISupportInitialize)this.pictureBox_0).BeginInit();
			this.toolStrip_0.SuspendLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_0).BeginInit();
			this.tabPage_4.SuspendLayout();
			this.tableLayoutPanel_1.SuspendLayout();
			this.toolStrip_1.SuspendLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_1).BeginInit();
			((ISupportInitialize)this.bindingSource_0).BeginInit();
			((ISupportInitialize)this.bindingSource_2).BeginInit();
			this.contextMenuStrip_0.SuspendLayout();
			this.contextMenuStrip_1.SuspendLayout();
			((ISupportInitialize)this.class10_0).BeginInit();
			((ISupportInitialize)this.class255_1).BeginInit();
			base.SuspendLayout();
			this.tableLayoutPanel_0.ColumnCount = 2;
			this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 122f));
			this.tableLayoutPanel_0.Controls.Add(this.tabControl_0, 0, 0);
			this.tableLayoutPanel_0.Controls.Add(this.button_2, 1, 1);
			this.tableLayoutPanel_0.Controls.Add(this.button_3, 0, 1);
			this.tableLayoutPanel_0.Dock = DockStyle.Fill;
			this.tableLayoutPanel_0.Location = new Point(0, 0);
			this.tableLayoutPanel_0.Margin = new Padding(3, 3, 10, 3);
			this.tableLayoutPanel_0.Name = "tableLayoutPanel1";
			this.tableLayoutPanel_0.RowCount = 2;
			this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Absolute, 45f));
			this.tableLayoutPanel_0.Size = new Size(757, 728);
			this.tableLayoutPanel_0.TabIndex = 0;
			this.tableLayoutPanel_0.SetColumnSpan(this.tabControl_0, 2);
			this.tabControl_0.Controls.Add(this.tabPage_0);
			this.tabControl_0.Controls.Add(this.tabPage_6);
			this.tabControl_0.Controls.Add(this.tabPage_5);
			this.tabControl_0.Controls.Add(this.tabPage_1);
			this.tabControl_0.Controls.Add(this.tabPage_3);
			this.tabControl_0.Controls.Add(this.tabPage_2);
			this.tabControl_0.Controls.Add(this.tabPage_4);
			this.tabControl_0.Dock = DockStyle.Fill;
			this.tabControl_0.Location = new Point(3, 3);
			this.tabControl_0.Name = "tpMain";
			this.tabControl_0.SelectedIndex = 0;
			this.tabControl_0.Size = new Size(751, 677);
			this.tabControl_0.TabIndex = 0;
			this.tabControl_0.SelectedIndexChanged += this.tabControl_0_SelectedIndexChanged;
			this.tabPage_0.Controls.Add(this.tableLayoutPanel_5);
			this.tabPage_0.Location = new Point(4, 22);
			this.tabPage_0.Name = "tpPrimerAkt";
			this.tabPage_0.Padding = new Padding(3);
			this.tabPage_0.Size = new Size(743, 651);
			this.tabPage_0.TabIndex = 0;
			this.tabPage_0.Text = "Параметры акта";
			this.tabPage_0.UseVisualStyleBackColor = true;
			this.tableLayoutPanel_5.ColumnCount = 9;
			this.tableLayoutPanel_5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 11f));
			this.tableLayoutPanel_5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 63f));
			this.tableLayoutPanel_5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 152f));
			this.tableLayoutPanel_5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 86f));
			this.tableLayoutPanel_5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 155f));
			this.tableLayoutPanel_5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 124f));
			this.tableLayoutPanel_5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80f));
			this.tableLayoutPanel_5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel_5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 31f));
			this.tableLayoutPanel_5.Controls.Add(this.label_12, 1, 0);
			this.tableLayoutPanel_5.Controls.Add(this.label_2, 1, 17);
			this.tableLayoutPanel_5.Controls.Add(this.label_1, 1, 19);
			this.tableLayoutPanel_5.Controls.Add(this.dateTimePicker_0, 2, 0);
			this.tableLayoutPanel_5.Controls.Add(this.label_11, 3, 0);
			this.tableLayoutPanel_5.Controls.Add(this.button_0, 8, 15);
			this.tableLayoutPanel_5.Controls.Add(this.textBox_1, 1, 20);
			this.tableLayoutPanel_5.Controls.Add(this.elementHost_5, 1, 10);
			this.tableLayoutPanel_5.Controls.Add(this.textBox_2, 1, 18);
			this.tableLayoutPanel_5.Controls.Add(this.button_1, 8, 12);
			this.tableLayoutPanel_5.Controls.Add(this.textBox_3, 1, 15);
			this.tableLayoutPanel_5.Controls.Add(this.comboBox_0, 4, 0);
			this.tableLayoutPanel_5.Controls.Add(this.elementHost_6, 1, 8);
			this.tableLayoutPanel_5.Controls.Add(this.label_10, 5, 0);
			this.tableLayoutPanel_5.Controls.Add(this.elementHost_4, 1, 6);
			this.tableLayoutPanel_5.Controls.Add(this.textBox_7, 6, 0);
			this.tableLayoutPanel_5.Controls.Add(this.textBox_4, 1, 12);
			this.tableLayoutPanel_5.Controls.Add(this.label_9, 1, 3);
			this.tableLayoutPanel_5.Controls.Add(this.textBox_6, 1, 4);
			this.tableLayoutPanel_5.Controls.Add(this.label_3, 1, 14);
			this.tableLayoutPanel_5.Controls.Add(this.label_8, 4, 3);
			this.tableLayoutPanel_5.Controls.Add(this.textBox_5, 4, 4);
			this.tableLayoutPanel_5.Controls.Add(this.label_7, 1, 5);
			this.tableLayoutPanel_5.Controls.Add(this.label_4, 1, 11);
			this.tableLayoutPanel_5.Controls.Add(this.label_6, 1, 7);
			this.tableLayoutPanel_5.Controls.Add(this.label_5, 1, 9);
			this.tableLayoutPanel_5.Controls.Add(this.label_0, 1, 21);
			this.tableLayoutPanel_5.Controls.Add(this.textBox_0, 3, 21);
			this.tableLayoutPanel_5.Controls.Add(this.label_37, 1, 22);
			this.tableLayoutPanel_5.Controls.Add(this.textBox_18, 3, 22);
			this.tableLayoutPanel_5.Controls.Add(this.label_38, 1, 1);
			this.tableLayoutPanel_5.Controls.Add(this.textBox_19, 1, 2);
			this.tableLayoutPanel_5.Controls.Add(this.label_39, 4, 1);
			this.tableLayoutPanel_5.Controls.Add(this.comboBoxReadOnly_0, 4, 2);
			this.tableLayoutPanel_5.Controls.Add(this.button_4, 8, 2);
			this.tableLayoutPanel_5.Dock = DockStyle.Fill;
			this.tableLayoutPanel_5.Location = new Point(3, 3);
			this.tableLayoutPanel_5.Name = "tableLayoutPanel7";
			this.tableLayoutPanel_5.RowCount = 23;
			this.tableLayoutPanel_5.RowStyles.Add(new RowStyle(SizeType.Absolute, 26f));
			this.tableLayoutPanel_5.RowStyles.Add(new RowStyle(SizeType.Absolute, 25f));
			this.tableLayoutPanel_5.RowStyles.Add(new RowStyle(SizeType.Absolute, 25f));
			this.tableLayoutPanel_5.RowStyles.Add(new RowStyle(SizeType.Absolute, 19f));
			this.tableLayoutPanel_5.RowStyles.Add(new RowStyle(SizeType.Absolute, 25f));
			this.tableLayoutPanel_5.RowStyles.Add(new RowStyle(SizeType.Absolute, 19f));
			this.tableLayoutPanel_5.RowStyles.Add(new RowStyle(SizeType.Absolute, 53f));
			this.tableLayoutPanel_5.RowStyles.Add(new RowStyle(SizeType.Absolute, 21f));
			this.tableLayoutPanel_5.RowStyles.Add(new RowStyle(SizeType.Absolute, 60f));
			this.tableLayoutPanel_5.RowStyles.Add(new RowStyle(SizeType.Absolute, 21f));
			this.tableLayoutPanel_5.RowStyles.Add(new RowStyle(SizeType.Absolute, 63f));
			this.tableLayoutPanel_5.RowStyles.Add(new RowStyle(SizeType.Absolute, 21f));
			this.tableLayoutPanel_5.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
			this.tableLayoutPanel_5.RowStyles.Add(new RowStyle(SizeType.Absolute, 8f));
			this.tableLayoutPanel_5.RowStyles.Add(new RowStyle(SizeType.Absolute, 19f));
			this.tableLayoutPanel_5.RowStyles.Add(new RowStyle(SizeType.Absolute, 31f));
			this.tableLayoutPanel_5.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
			this.tableLayoutPanel_5.RowStyles.Add(new RowStyle(SizeType.Absolute, 16f));
			this.tableLayoutPanel_5.RowStyles.Add(new RowStyle(SizeType.Absolute, 26f));
			this.tableLayoutPanel_5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
			this.tableLayoutPanel_5.RowStyles.Add(new RowStyle(SizeType.Absolute, 26f));
			this.tableLayoutPanel_5.RowStyles.Add(new RowStyle(SizeType.Absolute, 21f));
			this.tableLayoutPanel_5.RowStyles.Add(new RowStyle(SizeType.Absolute, 8f));
			this.tableLayoutPanel_5.Size = new Size(737, 645);
			this.tableLayoutPanel_5.TabIndex = 40;
			this.label_12.AutoSize = true;
			this.label_12.Dock = DockStyle.Fill;
			this.label_12.Location = new Point(14, 0);
			this.label_12.Name = "lbData";
			this.label_12.Size = new Size(57, 26);
			this.label_12.TabIndex = 3;
			this.label_12.Text = "Дата";
			this.label_12.TextAlign = ContentAlignment.MiddleRight;
			this.label_2.AutoSize = true;
			this.tableLayoutPanel_5.SetColumnSpan(this.label_2, 8);
			this.label_2.Dock = DockStyle.Fill;
			this.label_2.Location = new Point(14, 492);
			this.label_2.Name = "lbOtvetst";
			this.label_2.Size = new Size(720, 16);
			this.label_2.TabIndex = 20;
			this.label_2.Text = "Ответственность за состояние и обслуживание контактных соединений:";
			this.label_2.TextAlign = ContentAlignment.BottomLeft;
			this.label_1.AutoSize = true;
			this.tableLayoutPanel_5.SetColumnSpan(this.label_1, 8);
			this.label_1.Dock = DockStyle.Fill;
			this.label_1.Location = new Point(14, 534);
			this.label_1.Name = "lbPotrOb";
			this.label_1.Size = new Size(720, 20);
			this.label_1.TabIndex = 22;
			this.label_1.Text = "Потребитель допущен к оперативным действиям со следующим оборудованием:";
			this.label_1.TextAlign = ContentAlignment.BottomLeft;
			this.dateTimePicker_0.Dock = DockStyle.Fill;
			this.dateTimePicker_0.Location = new Point(77, 3);
			this.dateTimePicker_0.Name = "dtpActDate";
			this.dateTimePicker_0.Size = new Size(146, 20);
			this.dateTimePicker_0.TabIndex = 8;
			this.label_11.AutoSize = true;
			this.label_11.Dock = DockStyle.Fill;
			this.label_11.Location = new Point(229, 0);
			this.label_11.Name = "lbRaion";
			this.label_11.Size = new Size(80, 26);
			this.label_11.TabIndex = 4;
			this.label_11.Text = "Район";
			this.label_11.TextAlign = ContentAlignment.MiddleRight;
			this.button_0.Location = new Point(709, 436);
			this.button_0.Name = "btnPotrExpl";
			this.button_0.Size = new Size(24, 22);
			this.button_0.TabIndex = 27;
			this.button_0.Text = ",,,";
			this.button_0.UseVisualStyleBackColor = true;
			this.button_0.Click += this.button_0_Click;
			this.tableLayoutPanel_5.SetColumnSpan(this.textBox_1, 8);
			this.textBox_1.Dock = DockStyle.Fill;
			this.textBox_1.Location = new Point(14, 557);
			this.textBox_1.Name = "tbAdmission";
			this.textBox_1.Size = new Size(720, 20);
			this.textBox_1.TabIndex = 23;
			this.textBox_1.TextChanged += this.textBox_14_TextChanged;
			this.tableLayoutPanel_5.SetColumnSpan(this.elementHost_5, 8);
			this.elementHost_5.Dock = DockStyle.Fill;
			this.elementHost_5.Location = new Point(14, 297);
			this.elementHost_5.Name = "hostBorderBalance";
			this.elementHost_5.Size = new Size(720, 57);
			this.elementHost_5.TabIndex = 37;
			this.elementHost_5.Text = "elementHost3";
			this.elementHost_5.Child = null;
			this.tableLayoutPanel_5.SetColumnSpan(this.textBox_2, 8);
			this.textBox_2.Dock = DockStyle.Fill;
			this.textBox_2.Location = new Point(14, 511);
			this.textBox_2.Name = "tbResponsibility";
			this.textBox_2.Size = new Size(720, 20);
			this.textBox_2.TabIndex = 21;
			this.textBox_2.TextChanged += this.textBox_14_TextChanged;
			this.button_1.Location = new Point(709, 381);
			this.button_1.Name = "btnOrgExpl";
			this.button_1.Size = new Size(24, 22);
			this.button_1.TabIndex = 26;
			this.button_1.Text = ",,,";
			this.button_1.UseVisualStyleBackColor = true;
			this.button_1.Click += this.button_1_Click;
			this.tableLayoutPanel_5.SetColumnSpan(this.textBox_3, 7);
			this.textBox_3.Dock = DockStyle.Fill;
			this.textBox_3.ForeColor = SystemColors.ControlText;
			this.textBox_3.Location = new Point(14, 436);
			this.textBox_3.Multiline = true;
			this.textBox_3.Name = "tbPotrExpl";
			this.tableLayoutPanel_5.SetRowSpan(this.textBox_3, 2);
			this.textBox_3.Size = new Size(689, 53);
			this.textBox_3.TabIndex = 19;
			this.textBox_3.TextChanged += this.textBox_14_TextChanged;
			this.comboBox_0.Dock = DockStyle.Fill;
			this.comboBox_0.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_0.FormattingEnabled = true;
			this.comboBox_0.Location = new Point(315, 3);
			this.comboBox_0.Name = "cbRegion";
			this.comboBox_0.Size = new Size(149, 21);
			this.comboBox_0.TabIndex = 6;
			this.comboBox_0.SelectedIndexChanged += this.comboBox_0_SelectedIndexChanged;
			this.comboBox_0.SelectedValueChanged += this.comboBox_0_SelectedValueChanged;
			this.tableLayoutPanel_5.SetColumnSpan(this.elementHost_6, 8);
			this.elementHost_6.Dock = DockStyle.Fill;
			this.elementHost_6.Location = new Point(14, 216);
			this.elementHost_6.Name = "hostPotrBalance";
			this.elementHost_6.Size = new Size(720, 54);
			this.elementHost_6.TabIndex = 36;
			this.elementHost_6.Text = "elementHost2";
			this.elementHost_6.Child = null;
			this.label_10.AutoSize = true;
			this.label_10.Dock = DockStyle.Fill;
			this.label_10.Location = new Point(470, 0);
			this.label_10.Name = "lbMumber";
			this.label_10.Size = new Size(118, 26);
			this.label_10.TabIndex = 5;
			this.label_10.Text = "Порядковый номер";
			this.label_10.TextAlign = ContentAlignment.MiddleRight;
			this.tableLayoutPanel_5.SetColumnSpan(this.elementHost_4, 8);
			this.elementHost_4.Dock = DockStyle.Fill;
			this.elementHost_4.Location = new Point(14, 142);
			this.elementHost_4.Name = "hostOrgBalance";
			this.elementHost_4.Size = new Size(720, 47);
			this.elementHost_4.TabIndex = 35;
			this.elementHost_4.Text = "elementHost1";
			this.elementHost_4.Child = null;
			this.textBox_7.Dock = DockStyle.Fill;
			this.textBox_7.Location = new Point(594, 3);
			this.textBox_7.Name = "tbActNumber";
			this.textBox_7.Size = new Size(74, 20);
			this.textBox_7.TabIndex = 7;
			this.textBox_7.TextChanged += this.textBox_14_TextChanged;
			this.tableLayoutPanel_5.SetColumnSpan(this.textBox_4, 7);
			this.textBox_4.Dock = DockStyle.Fill;
			this.textBox_4.ForeColor = SystemColors.ControlText;
			this.textBox_4.Location = new Point(14, 381);
			this.textBox_4.Multiline = true;
			this.textBox_4.Name = "tbOrgExpl";
			this.tableLayoutPanel_5.SetRowSpan(this.textBox_4, 2);
			this.textBox_4.Size = new Size(689, 30);
			this.textBox_4.TabIndex = 17;
			this.textBox_4.TextChanged += this.textBox_14_TextChanged;
			this.label_9.AutoSize = true;
			this.tableLayoutPanel_5.SetColumnSpan(this.label_9, 3);
			this.label_9.Dock = DockStyle.Fill;
			this.label_9.Location = new Point(14, 76);
			this.label_9.Name = "lbAbn";
			this.label_9.Size = new Size(295, 19);
			this.label_9.TabIndex = 10;
			this.label_9.Text = "Абонент в лице:";
			this.label_9.TextAlign = ContentAlignment.MiddleLeft;
			this.tableLayoutPanel_5.SetColumnSpan(this.textBox_6, 3);
			this.textBox_6.Dock = DockStyle.Fill;
			this.textBox_6.Location = new Point(14, 98);
			this.textBox_6.Name = "tbOrgFace";
			this.textBox_6.Size = new Size(295, 20);
			this.textBox_6.TabIndex = 9;
			this.textBox_6.TextChanged += this.textBox_14_TextChanged;
			this.label_3.AutoSize = true;
			this.tableLayoutPanel_5.SetColumnSpan(this.label_3, 8);
			this.label_3.Dock = DockStyle.Fill;
			this.label_3.Location = new Point(14, 414);
			this.label_3.Name = "lbPotrExpl";
			this.label_3.Size = new Size(720, 19);
			this.label_3.TabIndex = 18;
			this.label_3.Text = "В эксплуатации Потребителя находится:";
			this.label_3.TextAlign = ContentAlignment.BottomLeft;
			this.label_8.AutoSize = true;
			this.tableLayoutPanel_5.SetColumnSpan(this.label_8, 5);
			this.label_8.Dock = DockStyle.Fill;
			this.label_8.Location = new Point(315, 76);
			this.label_8.Name = "lbOsn";
			this.label_8.Size = new Size(419, 19);
			this.label_8.TabIndex = 11;
			this.label_8.Text = "Действующий на основании:";
			this.tableLayoutPanel_5.SetColumnSpan(this.textBox_5, 5);
			this.textBox_5.Dock = DockStyle.Fill;
			this.textBox_5.Location = new Point(315, 98);
			this.textBox_5.Name = "tbOrgBase";
			this.textBox_5.Size = new Size(419, 20);
			this.textBox_5.TabIndex = 12;
			this.textBox_5.TextChanged += this.textBox_14_TextChanged;
			this.label_7.AutoSize = true;
			this.tableLayoutPanel_5.SetColumnSpan(this.label_7, 8);
			this.label_7.Dock = DockStyle.Fill;
			this.label_7.Location = new Point(14, 120);
			this.label_7.Name = "lbOrganiz";
			this.label_7.Size = new Size(720, 19);
			this.label_7.TabIndex = 13;
			this.label_7.Text = "На балансе Сетевой организации находится:";
			this.label_7.TextAlign = ContentAlignment.BottomLeft;
			this.label_4.AutoSize = true;
			this.tableLayoutPanel_5.SetColumnSpan(this.label_4, 8);
			this.label_4.Dock = DockStyle.Fill;
			this.label_4.Location = new Point(14, 357);
			this.label_4.Name = "lbOrgExpl";
			this.label_4.Size = new Size(720, 21);
			this.label_4.TabIndex = 16;
			this.label_4.Text = "В эксплуатации Сетевой организации находится:";
			this.label_4.TextAlign = ContentAlignment.BottomLeft;
			this.label_6.AutoSize = true;
			this.tableLayoutPanel_5.SetColumnSpan(this.label_6, 8);
			this.label_6.Dock = DockStyle.Fill;
			this.label_6.Location = new Point(14, 192);
			this.label_6.Name = "lbPotreb";
			this.label_6.Size = new Size(720, 21);
			this.label_6.TabIndex = 14;
			this.label_6.Text = "На балансе Потребителя находится:";
			this.label_6.TextAlign = ContentAlignment.BottomLeft;
			this.label_5.AutoSize = true;
			this.tableLayoutPanel_5.SetColumnSpan(this.label_5, 8);
			this.label_5.Dock = DockStyle.Fill;
			this.label_5.Location = new Point(14, 273);
			this.label_5.Name = "lbBorder";
			this.label_5.Size = new Size(720, 21);
			this.label_5.TabIndex = 15;
			this.label_5.Text = "Границей балансовой принадлежности является:";
			this.label_5.TextAlign = ContentAlignment.BottomLeft;
			this.label_0.AutoSize = true;
			this.tableLayoutPanel_5.SetColumnSpan(this.label_0, 2);
			this.label_0.Dock = DockStyle.Fill;
			this.label_0.Location = new Point(14, 580);
			this.label_0.Name = "lbPodpis";
			this.label_0.Size = new Size(209, 21);
			this.label_0.TabIndex = 24;
			this.label_0.Text = "Потребитель(для подписи):";
			this.label_0.TextAlign = ContentAlignment.MiddleRight;
			this.tableLayoutPanel_5.SetColumnSpan(this.textBox_0, 6);
			this.textBox_0.Dock = DockStyle.Fill;
			this.textBox_0.Location = new Point(229, 583);
			this.textBox_0.Name = "tbPotrSignature";
			this.textBox_0.Size = new Size(505, 20);
			this.textBox_0.TabIndex = 25;
			this.textBox_0.TextChanged += this.textBox_14_TextChanged;
			this.label_37.AutoSize = true;
			this.tableLayoutPanel_5.SetColumnSpan(this.label_37, 2);
			this.label_37.Dock = DockStyle.Fill;
			this.label_37.Location = new Point(14, 601);
			this.label_37.Name = "label17";
			this.label_37.Size = new Size(209, 44);
			this.label_37.TabIndex = 38;
			this.label_37.Text = "Прочее";
			this.label_37.TextAlign = ContentAlignment.MiddleRight;
			this.tableLayoutPanel_5.SetColumnSpan(this.textBox_18, 6);
			this.textBox_18.Dock = DockStyle.Fill;
			this.textBox_18.ForeColor = SystemColors.ControlText;
			this.textBox_18.Location = new Point(229, 604);
			this.textBox_18.Multiline = true;
			this.textBox_18.Name = "tbOther";
			this.textBox_18.Size = new Size(505, 38);
			this.textBox_18.TabIndex = 39;
			this.label_38.AutoSize = true;
			this.tableLayoutPanel_5.SetColumnSpan(this.label_38, 3);
			this.label_38.Dock = DockStyle.Fill;
			this.label_38.Location = new Point(14, 26);
			this.label_38.Name = "label2";
			this.label_38.Size = new Size(295, 25);
			this.label_38.TabIndex = 40;
			this.label_38.Text = "Абонент";
			this.label_38.TextAlign = ContentAlignment.MiddleLeft;
			this.textBox_19.BackColor = SystemColors.Window;
			this.tableLayoutPanel_5.SetColumnSpan(this.textBox_19, 3);
			this.textBox_19.Dock = DockStyle.Fill;
			this.textBox_19.Location = new Point(14, 54);
			this.textBox_19.Name = "txtAbn";
			this.textBox_19.ReadOnly = true;
			this.textBox_19.Size = new Size(295, 20);
			this.textBox_19.TabIndex = 41;
			this.label_39.AutoSize = true;
			this.tableLayoutPanel_5.SetColumnSpan(this.label_39, 3);
			this.label_39.Dock = DockStyle.Fill;
			this.label_39.Location = new Point(315, 26);
			this.label_39.Name = "label7";
			this.label_39.Size = new Size(353, 25);
			this.label_39.TabIndex = 42;
			this.label_39.Text = "Объект";
			this.label_39.TextAlign = ContentAlignment.MiddleLeft;
			this.tableLayoutPanel_5.SetColumnSpan(this.comboBoxReadOnly_0, 4);
			this.comboBoxReadOnly_0.Dock = DockStyle.Fill;
			this.comboBoxReadOnly_0.FormattingEnabled = true;
			this.comboBoxReadOnly_0.Location = new Point(315, 54);
			this.comboBoxReadOnly_0.Name = "cmbAbnObj";
			this.comboBoxReadOnly_0.ReadOnlyBackColor = SystemColors.Control;
			this.comboBoxReadOnly_0.ReadOnlyForeColor = SystemColors.WindowText;
			this.comboBoxReadOnly_0.Size = new Size(388, 21);
			this.comboBoxReadOnly_0.TabIndex = 43;
			this.comboBoxReadOnly_0.SelectedValueChanged += this.comboBoxReadOnly_0_SelectedValueChanged;
			this.button_4.Dock = DockStyle.Fill;
			this.button_4.Location = new Point(709, 54);
			this.button_4.Name = "btnChangeAbn";
			this.button_4.Size = new Size(25, 19);
			this.button_4.TabIndex = 44;
			this.button_4.Text = ",,,";
			this.button_4.UseVisualStyleBackColor = true;
			this.button_4.Click += this.button_4_Click;
			this.tabPage_6.Controls.Add(this.dataGridView_1);
			this.tabPage_6.Controls.Add(this.panel_1);
			this.tabPage_6.Controls.Add(this.toolStrip_2);
			this.tabPage_6.Location = new Point(4, 22);
			this.tabPage_6.Name = "tabPagePointAttach";
			this.tabPage_6.Padding = new Padding(3);
			this.tabPage_6.Size = new Size(743, 651);
			this.tabPage_6.TabIndex = 6;
			this.tabPage_6.Text = "Точки присоединения";
			this.tabPage_6.UseVisualStyleBackColor = true;
			this.dataGridView_1.AllowUserToAddRows = false;
			this.dataGridView_1.AllowUserToDeleteRows = false;
			this.dataGridView_1.AllowUserToResizeColumns = false;
			this.dataGridView_1.AllowUserToResizeRows = false;
			dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle.BackColor = SystemColors.Control;
			dataGridViewCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
			this.dataGridView_1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
			this.dataGridView_1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView_1.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewTextBoxColumn_58,
				this.dataGridViewTextBoxColumn_59,
				this.dataGridViewTextBoxColumn_60,
				this.dataGridViewTextBoxColumn_61,
				this.dataGridViewTextBoxColumn_62,
				this.dataGridViewTextBoxColumn_63,
				this.dataGridViewTextBoxColumn_64,
				this.dataGridViewTextBoxColumn_65,
				this.dataGridViewTextBoxColumn_66,
				this.dataGridViewTextBoxColumn_67,
				this.dataGridViewTextBoxColumn_68,
				this.dataGridViewTextBoxColumn_69,
				this.dataGridViewTextBoxColumn_70,
				this.dataGridViewTextBoxColumn_71,
				this.dataGridViewTextBoxColumn_72,
				this.dataGridViewTextBoxColumn_73,
				this.dataGridViewTextBoxColumn_74
			});
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
			this.dataGridView_1.DefaultCellStyle = dataGridViewCellStyle2;
			this.dataGridView_1.Dock = DockStyle.Fill;
			this.dataGridView_1.Location = new Point(3, 87);
			this.dataGridView_1.MultiSelect = false;
			this.dataGridView_1.Name = "dgvPointAttach";
			this.dataGridView_1.ReadOnly = true;
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = SystemColors.Control;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
			this.dataGridView_1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.dataGridView_1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView_1.Size = new Size(737, 561);
			this.dataGridView_1.TabIndex = 20;
			this.dataGridView_1.CellDoubleClick += this.dataGridView_1_CellDoubleClick;
			this.dataGridViewTextBoxColumn_58.HeaderText = "id";
			this.dataGridViewTextBoxColumn_58.Name = "dataGridViewTextBoxColumn31";
			this.dataGridViewTextBoxColumn_58.ReadOnly = true;
			this.dataGridViewTextBoxColumn_58.Visible = false;
			this.dataGridViewTextBoxColumn_59.HeaderText = "num";
			this.dataGridViewTextBoxColumn_59.Name = "dataGridViewTextBoxColumn32";
			this.dataGridViewTextBoxColumn_59.ReadOnly = true;
			this.dataGridViewTextBoxColumn_59.Visible = false;
			this.dataGridViewTextBoxColumn_60.HeaderText = "idSubPoint";
			this.dataGridViewTextBoxColumn_60.Name = "idSubPointColumn";
			this.dataGridViewTextBoxColumn_60.ReadOnly = true;
			this.dataGridViewTextBoxColumn_60.Visible = false;
			this.dataGridViewTextBoxColumn_61.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_61.HeaderText = "ТП/РП";
			this.dataGridViewTextBoxColumn_61.Name = "subPointDgvColumn";
			this.dataGridViewTextBoxColumn_61.ReadOnly = true;
			this.dataGridViewTextBoxColumn_61.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn_62.HeaderText = "idBusPoint";
			this.dataGridViewTextBoxColumn_62.Name = "idBusPointColumn";
			this.dataGridViewTextBoxColumn_62.ReadOnly = true;
			this.dataGridViewTextBoxColumn_62.Visible = false;
			this.dataGridViewTextBoxColumn_63.HeaderText = "Шина";
			this.dataGridViewTextBoxColumn_63.Name = "busPointDgvColumn";
			this.dataGridViewTextBoxColumn_63.ReadOnly = true;
			this.dataGridViewTextBoxColumn_63.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn_63.Width = 50;
			this.dataGridViewTextBoxColumn_64.HeaderText = "idCellPoint";
			this.dataGridViewTextBoxColumn_64.Name = "idCellPointColumn";
			this.dataGridViewTextBoxColumn_64.ReadOnly = true;
			this.dataGridViewTextBoxColumn_64.Visible = false;
			this.dataGridViewTextBoxColumn_65.HeaderText = "Ячейка";
			this.dataGridViewTextBoxColumn_65.Name = "cellPoinDgvColumn";
			this.dataGridViewTextBoxColumn_65.ReadOnly = true;
			this.dataGridViewTextBoxColumn_65.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn_65.Width = 50;
			this.dataGridViewTextBoxColumn_66.HeaderText = "idSubCP";
			this.dataGridViewTextBoxColumn_66.Name = "idSubCPColumn";
			this.dataGridViewTextBoxColumn_66.ReadOnly = true;
			this.dataGridViewTextBoxColumn_66.Visible = false;
			this.dataGridViewTextBoxColumn_67.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_67.HeaderText = "ЦП";
			this.dataGridViewTextBoxColumn_67.Name = "subCPDgvColumn";
			this.dataGridViewTextBoxColumn_67.ReadOnly = true;
			this.dataGridViewTextBoxColumn_67.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn_68.HeaderText = "idBusCP";
			this.dataGridViewTextBoxColumn_68.Name = "idBusCPColumn";
			this.dataGridViewTextBoxColumn_68.ReadOnly = true;
			this.dataGridViewTextBoxColumn_68.Visible = false;
			this.dataGridViewTextBoxColumn_69.HeaderText = "Шина";
			this.dataGridViewTextBoxColumn_69.Name = "busCPDgvColumn";
			this.dataGridViewTextBoxColumn_69.ReadOnly = true;
			this.dataGridViewTextBoxColumn_69.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn_69.Width = 50;
			this.dataGridViewTextBoxColumn_70.HeaderText = "idCellCP";
			this.dataGridViewTextBoxColumn_70.Name = "idCellCPColumn";
			this.dataGridViewTextBoxColumn_70.ReadOnly = true;
			this.dataGridViewTextBoxColumn_70.Visible = false;
			this.dataGridViewTextBoxColumn_71.HeaderText = "Ячейка";
			this.dataGridViewTextBoxColumn_71.Name = "cellCPDgvColumn";
			this.dataGridViewTextBoxColumn_71.ReadOnly = true;
			this.dataGridViewTextBoxColumn_71.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn_71.Width = 50;
			this.dataGridViewTextBoxColumn_72.HeaderText = "VoltageLevel";
			this.dataGridViewTextBoxColumn_72.Name = "voltageLevelDgvColumn";
			this.dataGridViewTextBoxColumn_72.ReadOnly = true;
			this.dataGridViewTextBoxColumn_72.Visible = false;
			this.dataGridViewTextBoxColumn_73.HeaderText = "Напр-ние";
			this.dataGridViewTextBoxColumn_73.Name = "voltageLevelNameDgvColumn";
			this.dataGridViewTextBoxColumn_73.ReadOnly = true;
			this.dataGridViewTextBoxColumn_74.HeaderText = "Мощ-сть";
			this.dataGridViewTextBoxColumn_74.Name = "powerSumDgvColumn";
			this.dataGridViewTextBoxColumn_74.ReadOnly = true;
			this.panel_1.Controls.Add(this.textBox_21);
			this.panel_1.Controls.Add(this.label_40);
			this.panel_1.Controls.Add(this.label_41);
			this.panel_1.Controls.Add(this.dateTimePicker_1);
			this.panel_1.Controls.Add(this.textBox_20);
			this.panel_1.Controls.Add(this.label_42);
			this.panel_1.Dock = DockStyle.Top;
			this.panel_1.Location = new Point(3, 28);
			this.panel_1.Name = "panelActRebinding";
			this.panel_1.Size = new Size(737, 59);
			this.panel_1.TabIndex = 21;
			this.panel_1.Visible = false;
			this.textBox_21.BackColor = SystemColors.Window;
			this.textBox_21.Location = new Point(296, 27);
			this.textBox_21.Name = "txtTypeDocRebindning";
			this.textBox_21.ReadOnly = true;
			this.textBox_21.Size = new Size(191, 20);
			this.textBox_21.TabIndex = 6;
			this.label_40.AutoSize = true;
			this.label_40.Location = new Point(304, 11);
			this.label_40.Name = "label20";
			this.label_40.Size = new Size(83, 13);
			this.label_40.TabIndex = 5;
			this.label_40.Text = "Тип документа";
			this.label_41.AutoSize = true;
			this.label_41.Location = new Point(143, 11);
			this.label_41.Name = "label19";
			this.label_41.Size = new Size(33, 13);
			this.label_41.TabIndex = 3;
			this.label_41.Text = "Дата";
			this.dateTimePicker_1.Enabled = false;
			this.dateTimePicker_1.Location = new Point(132, 27);
			this.dateTimePicker_1.Name = "dtpDateDocRebindning";
			this.dateTimePicker_1.Size = new Size(145, 20);
			this.dateTimePicker_1.TabIndex = 2;
			this.textBox_20.BackColor = SystemColors.Window;
			this.textBox_20.Location = new Point(17, 27);
			this.textBox_20.Name = "txtNumDocRebindning";
			this.textBox_20.ReadOnly = true;
			this.textBox_20.Size = new Size(100, 20);
			this.textBox_20.TabIndex = 1;
			this.label_42.AutoSize = true;
			this.label_42.Location = new Point(24, 11);
			this.label_42.Name = "label18";
			this.label_42.Size = new Size(72, 13);
			this.label_42.TabIndex = 0;
			this.label_42.Text = "Документ №";
			this.toolStrip_2.GripStyle = ToolStripGripStyle.Hidden;
			this.toolStrip_2.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripButton_9,
				this.toolStripButton_10,
				this.toolStripButton_11,
				this.toolStripSeparator_4,
				this.toolStripButton_12,
				this.toolStripButton_13
			});
			this.toolStrip_2.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
			this.toolStrip_2.Location = new Point(3, 3);
			this.toolStrip_2.Name = "toolStripDGVPointAttach";
			this.toolStrip_2.Size = new Size(737, 25);
			this.toolStrip_2.TabIndex = 19;
			this.toolStrip_2.Text = "toolStrip1";
			this.toolStripButton_9.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_9.Image = (System.Drawing.Image)componentResourceManager.GetObject("toolBtnAddLink.Image");
			this.toolStripButton_9.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_9.Name = "toolBtnAddLink";
			this.toolStripButton_9.Size = new Size(23, 22);
			this.toolStripButton_9.Text = "Добавить";
			this.toolStripButton_9.Click += this.toolStripButton_9_Click;
			this.toolStripButton_10.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_10.Image = (System.Drawing.Image)componentResourceManager.GetObject("toolBtnEditLink.Image");
			this.toolStripButton_10.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_10.Name = "toolBtnEditLink";
			this.toolStripButton_10.Size = new Size(23, 22);
			this.toolStripButton_10.Text = "Редактировать";
			this.toolStripButton_10.Click += this.toolStripButton_10_Click;
			this.toolStripButton_11.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_11.Image = (System.Drawing.Image)componentResourceManager.GetObject("toolBtnDelLink.Image");
			this.toolStripButton_11.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_11.Name = "toolBtnDelLink";
			this.toolStripButton_11.Size = new Size(23, 22);
			this.toolStripButton_11.Text = "Удалить";
			this.toolStripButton_11.Click += this.toolStripButton_11_Click;
			this.toolStripSeparator_4.Name = "toolStripSeparator1";
			this.toolStripSeparator_4.Size = new Size(6, 25);
			this.toolStripButton_12.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_12.Image = (System.Drawing.Image)componentResourceManager.GetObject("toolBtnUpLink.Image");
			this.toolStripButton_12.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_12.Name = "toolBtnUpLink";
			this.toolStripButton_12.Size = new Size(23, 22);
			this.toolStripButton_12.Text = "Вверх";
			this.toolStripButton_12.Click += this.toolStripButton_12_Click;
			this.toolStripButton_13.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_13.Image = (System.Drawing.Image)componentResourceManager.GetObject("toolBtnDownLink.Image");
			this.toolStripButton_13.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_13.Name = "toolBtnDownLink";
			this.toolStripButton_13.Size = new Size(23, 22);
			this.toolStripButton_13.Text = "Вниз";
			this.toolStripButton_13.Click += this.toolStripButton_13_Click;
			this.tabPage_5.Controls.Add(this.tableLayoutPanel_2);
			this.tabPage_5.Location = new Point(4, 22);
			this.tabPage_5.Name = "tpActTehConnection";
			this.tabPage_5.Padding = new Padding(3);
			this.tabPage_5.Size = new Size(743, 651);
			this.tabPage_5.TabIndex = 5;
			this.tabPage_5.Text = "Акт о тех. присоединении";
			this.tabPage_5.UseVisualStyleBackColor = true;
			this.tableLayoutPanel_2.ColumnCount = 1;
			this.tableLayoutPanel_2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel_2.Controls.Add(this.panel_0, 0, 0);
			this.tableLayoutPanel_2.Dock = DockStyle.Fill;
			this.tableLayoutPanel_2.Location = new Point(3, 3);
			this.tableLayoutPanel_2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel_2.RowCount = 1;
			this.tableLayoutPanel_2.RowStyles.Add(new RowStyle(SizeType.Absolute, 727f));
			this.tableLayoutPanel_2.Size = new Size(737, 645);
			this.tableLayoutPanel_2.TabIndex = 0;
			this.panel_0.Controls.Add(this.tableLayoutPanel_6);
			this.panel_0.Dock = DockStyle.Fill;
			this.panel_0.Location = new Point(3, 3);
			this.panel_0.Name = "pnlActTehConnection";
			this.panel_0.Size = new Size(731, 721);
			this.panel_0.TabIndex = 0;
			this.tableLayoutPanel_6.ColumnCount = 5;
			this.tableLayoutPanel_6.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20f));
			this.tableLayoutPanel_6.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 291f));
			this.tableLayoutPanel_6.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 151f));
			this.tableLayoutPanel_6.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 133f));
			this.tableLayoutPanel_6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel_6.Controls.Add(this.textBox_17, 3, 3);
			this.tableLayoutPanel_6.Controls.Add(this.dataGridView_0, 0, 6);
			this.tableLayoutPanel_6.Controls.Add(this.label_35, 2, 3);
			this.tableLayoutPanel_6.Controls.Add(this.label_34, 1, 4);
			this.tableLayoutPanel_6.Controls.Add(this.label_33, 4, 4);
			this.tableLayoutPanel_6.Controls.Add(this.label_32, 4, 3);
			this.tableLayoutPanel_6.Controls.Add(this.textBox_16, 3, 4);
			this.tableLayoutPanel_6.Controls.Add(this.comboBox_1, 3, 1);
			this.tableLayoutPanel_6.Controls.Add(this.label_36, 1, 1);
			this.tableLayoutPanel_6.Dock = DockStyle.Fill;
			this.tableLayoutPanel_6.Location = new Point(0, 0);
			this.tableLayoutPanel_6.Name = "tableLayoutPanel5";
			this.tableLayoutPanel_6.RowCount = 7;
			this.tableLayoutPanel_6.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
			this.tableLayoutPanel_6.RowStyles.Add(new RowStyle(SizeType.Absolute, 26f));
			this.tableLayoutPanel_6.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
			this.tableLayoutPanel_6.RowStyles.Add(new RowStyle(SizeType.Absolute, 25f));
			this.tableLayoutPanel_6.RowStyles.Add(new RowStyle(SizeType.Absolute, 25f));
			this.tableLayoutPanel_6.RowStyles.Add(new RowStyle(SizeType.Absolute, 11f));
			this.tableLayoutPanel_6.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel_6.Size = new Size(731, 721);
			this.tableLayoutPanel_6.TabIndex = 9;
			this.textBox_17.DataBindings.Add(new Binding("Text", this.bindingSource_3, "PowerSum", true));
			this.textBox_17.Dock = DockStyle.Fill;
			this.textBox_17.Location = new Point(465, 69);
			this.textBox_17.Name = "tbPowerMax";
			this.textBox_17.ReadOnly = true;
			this.textBox_17.Size = new Size(127, 20);
			this.textBox_17.TabIndex = 1;
			this.bindingSource_3.DataMember = "tTC_ActTC";
			this.bindingSource_3.DataSource = this.class255_0;
			this.class255_0.DataSetName = "dsAbnObjAkt";
			this.class255_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
			this.dataGridView_0.AllowUserToAddRows = false;
			this.dataGridView_0.AllowUserToDeleteRows = false;
			this.dataGridView_0.AutoGenerateColumns = false;
			dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle4.BackColor = SystemColors.Control;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
			this.dataGridView_0.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
			this.dataGridView_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView_0.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewTextBoxColumn_34,
				this.dataGridViewTextBoxColumn_35,
				this.dataGridViewTextBoxColumn_36,
				this.dataGridViewTextBoxColumn_37,
				this.dataGridViewTextBoxColumn_38,
				this.dataGridViewTextBoxColumn_39,
				this.dataGridViewTextBoxColumn_40,
				this.dataGridViewTextBoxColumn_41,
				this.dataGridViewTextBoxColumn_42,
				this.dataGridViewTextBoxColumn_43,
				this.dataGridViewTextBoxColumn_44,
				this.dataGridViewTextBoxColumn_45,
				this.dvuBbFynsI,
				this.dataGridViewTextBoxColumn_46,
				this.dataGridViewTextBoxColumn_47,
				this.dataGridViewTextBoxColumn_48,
				this.dataGridViewTextBoxColumn_49,
				this.dataGridViewTextBoxColumn_50,
				this.dataGridViewTextBoxColumn_51,
				this.dataGridViewTextBoxColumn_52,
				this.dataGridViewTextBoxColumn_53,
				this.dataGridViewTextBoxColumn_54,
				this.dataGridViewTextBoxColumn_55,
				this.dataGridViewTextBoxColumn_56,
				this.dataGridViewTextBoxColumn_57
			});
			this.tableLayoutPanel_6.SetColumnSpan(this.dataGridView_0, 5);
			this.dataGridView_0.DataSource = this.bindingSource_1;
			dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle5.BackColor = SystemColors.Window;
			dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
			this.dataGridView_0.DefaultCellStyle = dataGridViewCellStyle5;
			this.dataGridView_0.Dock = DockStyle.Fill;
			this.dataGridView_0.Location = new Point(3, 130);
			this.dataGridView_0.Name = "dgvPointAttachTC";
			dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle6.BackColor = SystemColors.Control;
			dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
			this.dataGridView_0.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
			this.dataGridView_0.RowHeadersVisible = false;
			this.dataGridView_0.Size = new Size(725, 588);
			this.dataGridView_0.TabIndex = 3;
			this.dataGridViewTextBoxColumn_34.DataPropertyName = "idTU";
			this.dataGridViewTextBoxColumn_34.HeaderText = "idTU";
			this.dataGridViewTextBoxColumn_34.Name = "idTUDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_34.Visible = false;
			this.dataGridViewTextBoxColumn_35.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_35.HeaderText = "id";
			this.dataGridViewTextBoxColumn_35.Name = "idDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_35.Visible = false;
			this.dataGridViewTextBoxColumn_36.DataPropertyName = "num";
			this.dataGridViewTextBoxColumn_36.HeaderText = "num";
			this.dataGridViewTextBoxColumn_36.Name = "numDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_36.Visible = false;
			this.dataGridViewTextBoxColumn_37.DataPropertyName = "idSubPoint";
			this.dataGridViewTextBoxColumn_37.HeaderText = "idSubPoint";
			this.dataGridViewTextBoxColumn_37.Name = "idSubPointDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_37.Visible = false;
			this.dataGridViewTextBoxColumn_38.DataPropertyName = "SubPoint";
			this.dataGridViewTextBoxColumn_38.HeaderText = "SubPoint";
			this.dataGridViewTextBoxColumn_38.Name = "subPointDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_38.ReadOnly = true;
			this.dataGridViewTextBoxColumn_38.Visible = false;
			this.dataGridViewTextBoxColumn_39.DataPropertyName = "idBusPoint";
			this.dataGridViewTextBoxColumn_39.HeaderText = "idBusPoint";
			this.dataGridViewTextBoxColumn_39.Name = "idBusPointDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_39.Visible = false;
			this.dataGridViewTextBoxColumn_40.DataPropertyName = "BusPoint";
			this.dataGridViewTextBoxColumn_40.HeaderText = "BusPoint";
			this.dataGridViewTextBoxColumn_40.Name = "busPointDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_40.Visible = false;
			this.dataGridViewTextBoxColumn_41.DataPropertyName = "BusFullPoint";
			this.dataGridViewTextBoxColumn_41.HeaderText = "BusFullPoint";
			this.dataGridViewTextBoxColumn_41.Name = "busFullPointDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_41.ReadOnly = true;
			this.dataGridViewTextBoxColumn_41.Visible = false;
			this.dataGridViewTextBoxColumn_42.DataPropertyName = "idCellPoint";
			this.dataGridViewTextBoxColumn_42.HeaderText = "idCellPoint";
			this.dataGridViewTextBoxColumn_42.Name = "idCellPointDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_42.Visible = false;
			this.dataGridViewTextBoxColumn_43.DataPropertyName = "CellPoint";
			this.dataGridViewTextBoxColumn_43.HeaderText = "CellPoint";
			this.dataGridViewTextBoxColumn_43.Name = "cellPointDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_43.Visible = false;
			this.dataGridViewTextBoxColumn_44.DataPropertyName = "CellFullPoint";
			this.dataGridViewTextBoxColumn_44.HeaderText = "CellFullPoint";
			this.dataGridViewTextBoxColumn_44.Name = "cellFullPointDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_44.ReadOnly = true;
			this.dataGridViewTextBoxColumn_44.Visible = false;
			this.dataGridViewTextBoxColumn_45.DataPropertyName = "idSubCP";
			this.dataGridViewTextBoxColumn_45.HeaderText = "idSubCP";
			this.dataGridViewTextBoxColumn_45.Name = "idSubCPDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_45.Visible = false;
			this.dvuBbFynsI.DataPropertyName = "SubCP";
			this.dvuBbFynsI.HeaderText = "SubCP";
			this.dvuBbFynsI.Name = "subCPDataGridViewTextBoxColumn";
			this.dvuBbFynsI.ReadOnly = true;
			this.dvuBbFynsI.Visible = false;
			this.dataGridViewTextBoxColumn_46.DataPropertyName = "idBusCP";
			this.dataGridViewTextBoxColumn_46.HeaderText = "idBusCP";
			this.dataGridViewTextBoxColumn_46.Name = "idBusCPDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_46.Visible = false;
			this.dataGridViewTextBoxColumn_47.DataPropertyName = "BusCP";
			this.dataGridViewTextBoxColumn_47.HeaderText = "BusCP";
			this.dataGridViewTextBoxColumn_47.Name = "busCPDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_47.Visible = false;
			this.dataGridViewTextBoxColumn_48.DataPropertyName = "idCellCP";
			this.dataGridViewTextBoxColumn_48.HeaderText = "idCellCP";
			this.dataGridViewTextBoxColumn_48.Name = "idCellCPDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_48.Visible = false;
			this.dataGridViewTextBoxColumn_49.DataPropertyName = "CellCP";
			this.dataGridViewTextBoxColumn_49.HeaderText = "CellCP";
			this.dataGridViewTextBoxColumn_49.Name = "cellCPDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_49.Visible = false;
			this.dataGridViewTextBoxColumn_50.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_50.DataPropertyName = "AttachmentPoint";
			this.dataGridViewTextBoxColumn_50.HeaderText = "Точка присоединения";
			this.dataGridViewTextBoxColumn_50.Name = "attachmentPointDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_50.ReadOnly = true;
			this.dataGridViewTextBoxColumn_51.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_51.DataPropertyName = "PowerSupply";
			this.dataGridViewTextBoxColumn_51.HeaderText = "Источник питания (наименование питающих линий)";
			this.dataGridViewTextBoxColumn_51.Name = "powerSupplyDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_51.ReadOnly = true;
			this.dataGridViewTextBoxColumn_52.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_52.HeaderText = "Описание точки присоединения";
			this.dataGridViewTextBoxColumn_52.Name = "APDescription";
			this.dataGridViewTextBoxColumn_53.DataPropertyName = "voltagelevel";
			this.dataGridViewTextBoxColumn_53.HeaderText = "voltagelevel";
			this.dataGridViewTextBoxColumn_53.Name = "voltagelevelDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_53.Visible = false;
			this.dataGridViewTextBoxColumn_54.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_54.DataPropertyName = "voltagelevelname";
			this.dataGridViewTextBoxColumn_54.HeaderText = "Уровень напряжения (кВ)";
			this.dataGridViewTextBoxColumn_54.Name = "voltagelevelnameDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_55.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_55.DataPropertyName = "powersum";
			this.dataGridViewTextBoxColumn_55.HeaderText = "Максимальная мощность (кВт)";
			this.dataGridViewTextBoxColumn_55.Name = "powersumDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_56.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_56.HeaderText = "Величина номинальной мощности присоединенных троансформаторов (кВА)";
			this.dataGridViewTextBoxColumn_56.Name = "PowerTransfNom";
			this.dataGridViewTextBoxColumn_57.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_57.DataPropertyName = "Category";
			this.dataGridViewTextBoxColumn_57.HeaderText = "Категория надежности электроснабжения";
			this.dataGridViewTextBoxColumn_57.Name = "categoryDataGridViewTextBoxColumn";
			this.bindingSource_1.DataMember = "vTC_TUPointAttach";
			this.bindingSource_1.DataSource = this.class255_0;
			this.bindingSource_1.Sort = "";
			this.label_35.AutoSize = true;
			this.label_35.Dock = DockStyle.Fill;
			this.label_35.Location = new Point(314, 66);
			this.label_35.Name = "label13";
			this.label_35.Size = new Size(145, 25);
			this.label_35.TabIndex = 5;
			this.label_35.Text = "Максимальная мощность";
			this.label_35.TextAlign = ContentAlignment.MiddleRight;
			this.label_34.AutoSize = true;
			this.tableLayoutPanel_6.SetColumnSpan(this.label_34, 2);
			this.label_34.Dock = DockStyle.Fill;
			this.label_34.Location = new Point(23, 91);
			this.label_34.Name = "label14";
			this.label_34.Size = new Size(436, 25);
			this.label_34.TabIndex = 6;
			this.label_34.Text = "Совокупная величина номинальной мощности присоединенных трансформаторов";
			this.label_34.TextAlign = ContentAlignment.MiddleRight;
			this.label_33.AutoSize = true;
			this.label_33.Dock = DockStyle.Fill;
			this.label_33.Location = new Point(598, 91);
			this.label_33.Name = "label15";
			this.label_33.Size = new Size(130, 25);
			this.label_33.TabIndex = 7;
			this.label_33.Text = "кВА";
			this.label_33.TextAlign = ContentAlignment.MiddleLeft;
			this.label_32.AutoSize = true;
			this.label_32.Dock = DockStyle.Fill;
			this.label_32.Location = new Point(598, 66);
			this.label_32.Name = "label16";
			this.label_32.Size = new Size(130, 25);
			this.label_32.TabIndex = 8;
			this.label_32.Text = "кВт";
			this.label_32.TextAlign = ContentAlignment.MiddleLeft;
			this.textBox_16.Dock = DockStyle.Fill;
			this.textBox_16.Location = new Point(465, 94);
			this.textBox_16.Name = "tbPowerNom";
			this.textBox_16.ReadOnly = true;
			this.textBox_16.Size = new Size(127, 20);
			this.textBox_16.TabIndex = 2;
			this.comboBox_1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			this.comboBox_1.AutoCompleteSource = AutoCompleteSource.ListItems;
			this.comboBox_1.DisplayMember = "id";
			this.comboBox_1.Dock = DockStyle.Fill;
			this.comboBox_1.FormattingEnabled = true;
			this.comboBox_1.Location = new Point(465, 23);
			this.comboBox_1.Name = "cbActTehConnection";
			this.comboBox_1.Size = new Size(127, 21);
			this.comboBox_1.TabIndex = 0;
			this.comboBox_1.ValueMember = "id";
			this.label_36.AutoSize = true;
			this.tableLayoutPanel_6.SetColumnSpan(this.label_36, 2);
			this.label_36.Dock = DockStyle.Fill;
			this.label_36.Location = new Point(23, 20);
			this.label_36.Name = "label12";
			this.label_36.Size = new Size(436, 26);
			this.label_36.TabIndex = 4;
			this.label_36.Text = "Акт технологического присоединения";
			this.label_36.TextAlign = ContentAlignment.MiddleRight;
			this.tabPage_1.Controls.Add(this.tableLayoutPanel_3);
			this.tabPage_1.Location = new Point(4, 22);
			this.tabPage_1.Name = "tpDopoln";
			this.tabPage_1.Padding = new Padding(3);
			this.tabPage_1.Size = new Size(743, 651);
			this.tabPage_1.TabIndex = 1;
			this.tabPage_1.Text = "Дополнительно-1";
			this.tabPage_1.UseVisualStyleBackColor = true;
			this.tableLayoutPanel_3.ColumnCount = 6;
			this.tableLayoutPanel_3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 11f));
			this.tableLayoutPanel_3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 184f));
			this.tableLayoutPanel_3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 179f));
			this.tableLayoutPanel_3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel_3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 118f));
			this.tableLayoutPanel_3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 8f));
			this.tableLayoutPanel_3.Controls.Add(this.label_23, 4, 15);
			this.tableLayoutPanel_3.Controls.Add(this.label_13, 1, 0);
			this.tableLayoutPanel_3.Controls.Add(this.label_15, 1, 1);
			this.tableLayoutPanel_3.Controls.Add(this.textBox_8, 1, 2);
			this.tableLayoutPanel_3.Controls.Add(this.label_14, 1, 3);
			this.tableLayoutPanel_3.Controls.Add(this.textBox_9, 1, 4);
			this.tableLayoutPanel_3.Controls.Add(this.label_16, 1, 5);
			this.tableLayoutPanel_3.Controls.Add(this.pbtrqMeGe2, 1, 6);
			this.tableLayoutPanel_3.Controls.Add(this.label_19, 1, 7);
			this.tableLayoutPanel_3.Controls.Add(this.elementHost_7, 1, 8);
			this.tableLayoutPanel_3.Controls.Add(this.peygMhnWkn, 3, 15);
			this.tableLayoutPanel_3.Controls.Add(this.label_18, 1, 9);
			this.tableLayoutPanel_3.Controls.Add(this.label_17, 1, 11);
			this.tableLayoutPanel_3.Controls.Add(this.textBox_10, 2, 13);
			this.tableLayoutPanel_3.Controls.Add(this.textBox_11, 1, 18);
			this.tableLayoutPanel_3.Controls.Add(this.label_21, 1, 13);
			this.tableLayoutPanel_3.Controls.Add(this.label_24, 1, 15);
			this.tableLayoutPanel_3.Controls.Add(this.label_22, 1, 17);
			this.tableLayoutPanel_3.Controls.Add(this.label_20, 1, 14);
			this.tableLayoutPanel_3.Controls.Add(this.textBox_12, 1, 16);
			this.tableLayoutPanel_3.Controls.Add(this.elementHost_1, 1, 12);
			this.tableLayoutPanel_3.Controls.Add(this.elementHost_0, 1, 10);
			this.tableLayoutPanel_3.Dock = DockStyle.Fill;
			this.tableLayoutPanel_3.Location = new Point(3, 3);
			this.tableLayoutPanel_3.Name = "tableLayoutPanel4";
			this.tableLayoutPanel_3.RowCount = 20;
			this.tableLayoutPanel_3.RowStyles.Add(new RowStyle(SizeType.Absolute, 34f));
			this.tableLayoutPanel_3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
			this.tableLayoutPanel_3.RowStyles.Add(new RowStyle(SizeType.Absolute, 24f));
			this.tableLayoutPanel_3.RowStyles.Add(new RowStyle(SizeType.Absolute, 26f));
			this.tableLayoutPanel_3.RowStyles.Add(new RowStyle(SizeType.Absolute, 25f));
			this.tableLayoutPanel_3.RowStyles.Add(new RowStyle(SizeType.Absolute, 24f));
			this.tableLayoutPanel_3.RowStyles.Add(new RowStyle(SizeType.Absolute, 26f));
			this.tableLayoutPanel_3.RowStyles.Add(new RowStyle(SizeType.Absolute, 23f));
			this.tableLayoutPanel_3.RowStyles.Add(new RowStyle(SizeType.Absolute, 66f));
			this.tableLayoutPanel_3.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
			this.tableLayoutPanel_3.RowStyles.Add(new RowStyle(SizeType.Absolute, 61f));
			this.tableLayoutPanel_3.RowStyles.Add(new RowStyle(SizeType.Absolute, 18f));
			this.tableLayoutPanel_3.RowStyles.Add(new RowStyle(SizeType.Absolute, 58f));
			this.tableLayoutPanel_3.RowStyles.Add(new RowStyle(SizeType.Absolute, 23f));
			this.tableLayoutPanel_3.RowStyles.Add(new RowStyle(SizeType.Absolute, 43f));
			this.tableLayoutPanel_3.RowStyles.Add(new RowStyle(SizeType.Absolute, 26f));
			this.tableLayoutPanel_3.RowStyles.Add(new RowStyle(SizeType.Absolute, 24f));
			this.tableLayoutPanel_3.RowStyles.Add(new RowStyle(SizeType.Absolute, 25f));
			this.tableLayoutPanel_3.RowStyles.Add(new RowStyle(SizeType.Absolute, 86f));
			this.tableLayoutPanel_3.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel_3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
			this.tableLayoutPanel_3.Size = new Size(737, 645);
			this.tableLayoutPanel_3.TabIndex = 36;
			this.label_23.AutoSize = true;
			this.label_23.Dock = DockStyle.Fill;
			this.label_23.Location = new Point(614, 499);
			this.label_23.Name = "lbTO2";
			this.label_23.Size = new Size(112, 26);
			this.label_23.TabIndex = 26;
			this.label_23.Text = "в эксплуатации";
			this.label_23.TextAlign = ContentAlignment.MiddleCenter;
			this.label_13.AutoSize = true;
			this.tableLayoutPanel_3.SetColumnSpan(this.label_13, 4);
			this.label_13.Dock = DockStyle.Fill;
			this.label_13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label_13.Location = new Point(14, 0);
			this.label_13.Name = "lbCaptionDop";
			this.label_13.Size = new Size(712, 34);
			this.label_13.TabIndex = 0;
			this.label_13.Text = "Дополнительные поля для 3-х стороннего акта";
			this.label_15.AutoSize = true;
			this.tableLayoutPanel_3.SetColumnSpan(this.label_15, 4);
			this.label_15.Dock = DockStyle.Fill;
			this.label_15.Location = new Point(14, 34);
			this.label_15.Name = "lbOwnerName";
			this.label_15.Size = new Size(712, 20);
			this.label_15.TabIndex = 1;
			this.label_15.Text = "Владелец сетей:";
			this.label_15.TextAlign = ContentAlignment.BottomLeft;
			this.tableLayoutPanel_3.SetColumnSpan(this.textBox_8, 4);
			this.textBox_8.Dock = DockStyle.Fill;
			this.textBox_8.Location = new Point(14, 57);
			this.textBox_8.Name = "tbOwnerName";
			this.textBox_8.Size = new Size(712, 20);
			this.textBox_8.TabIndex = 2;
			this.textBox_8.TextChanged += this.textBox_14_TextChanged;
			this.label_14.AutoSize = true;
			this.tableLayoutPanel_3.SetColumnSpan(this.label_14, 4);
			this.label_14.Dock = DockStyle.Fill;
			this.label_14.Location = new Point(14, 78);
			this.label_14.Name = "lbOwnerChief";
			this.label_14.Size = new Size(712, 26);
			this.label_14.TabIndex = 3;
			this.label_14.Text = "в лице:";
			this.label_14.TextAlign = ContentAlignment.BottomLeft;
			this.tableLayoutPanel_3.SetColumnSpan(this.textBox_9, 4);
			this.textBox_9.Dock = DockStyle.Fill;
			this.textBox_9.Location = new Point(14, 107);
			this.textBox_9.Name = "tbOwnerChief";
			this.textBox_9.Size = new Size(712, 20);
			this.textBox_9.TabIndex = 4;
			this.textBox_9.TextChanged += this.textBox_14_TextChanged;
			this.label_16.AutoSize = true;
			this.tableLayoutPanel_3.SetColumnSpan(this.label_16, 4);
			this.label_16.Dock = DockStyle.Fill;
			this.label_16.Location = new Point(14, 129);
			this.label_16.Name = "lbOwnerBase";
			this.label_16.Size = new Size(712, 24);
			this.label_16.TabIndex = 5;
			this.label_16.Text = "действующий на основании:";
			this.label_16.TextAlign = ContentAlignment.BottomLeft;
			this.tableLayoutPanel_3.SetColumnSpan(this.pbtrqMeGe2, 4);
			this.pbtrqMeGe2.Dock = DockStyle.Fill;
			this.pbtrqMeGe2.Location = new Point(14, 156);
			this.pbtrqMeGe2.Name = "tbOwnerBase";
			this.pbtrqMeGe2.Size = new Size(712, 20);
			this.pbtrqMeGe2.TabIndex = 6;
			this.pbtrqMeGe2.TextChanged += this.textBox_14_TextChanged;
			this.label_19.AutoSize = true;
			this.tableLayoutPanel_3.SetColumnSpan(this.label_19, 4);
			this.label_19.Dock = DockStyle.Fill;
			this.label_19.Location = new Point(14, 179);
			this.label_19.Name = "lbOwnerApp";
			this.label_19.Size = new Size(712, 23);
			this.label_19.TabIndex = 7;
			this.label_19.Text = "На балансе Владельца сетей находится:";
			this.label_19.TextAlign = ContentAlignment.BottomLeft;
			this.tableLayoutPanel_3.SetColumnSpan(this.elementHost_7, 4);
			this.elementHost_7.Dock = DockStyle.Fill;
			this.elementHost_7.Location = new Point(14, 205);
			this.elementHost_7.Name = "elementHost1";
			this.elementHost_7.Size = new Size(712, 60);
			this.elementHost_7.TabIndex = 35;
			this.elementHost_7.Text = "elementHost1";
			this.elementHost_7.Child = null;
			this.peygMhnWkn.Dock = DockStyle.Fill;
			this.peygMhnWkn.Location = new Point(377, 502);
			this.peygMhnWkn.Name = "tbDogByOTONum";
			this.peygMhnWkn.Size = new Size(231, 20);
			this.peygMhnWkn.TabIndex = 25;
			this.peygMhnWkn.TextChanged += this.textBox_14_TextChanged;
			this.label_18.AutoSize = true;
			this.tableLayoutPanel_3.SetColumnSpan(this.label_18, 4);
			this.label_18.Dock = DockStyle.Fill;
			this.label_18.Location = new Point(14, 268);
			this.label_18.Name = "lbBorder2Expl";
			this.label_18.Size = new Size(712, 28);
			this.label_18.TabIndex = 19;
			this.label_18.Text = "Границей балансовой принадлежности сторон является:";
			this.label_18.TextAlign = ContentAlignment.BottomLeft;
			this.label_17.AutoSize = true;
			this.tableLayoutPanel_3.SetColumnSpan(this.label_17, 4);
			this.label_17.Dock = DockStyle.Fill;
			this.label_17.Location = new Point(14, 357);
			this.label_17.Name = "label1";
			this.label_17.Size = new Size(712, 18);
			this.label_17.TabIndex = 20;
			this.label_17.Text = "В эксплуатации владельца сетей находится:";
			this.label_17.TextAlign = ContentAlignment.BottomLeft;
			this.tableLayoutPanel_3.SetColumnSpan(this.textBox_10, 3);
			this.textBox_10.Dock = DockStyle.Fill;
			this.textBox_10.Location = new Point(198, 436);
			this.textBox_10.Name = "tbOwnerChief2";
			this.textBox_10.Size = new Size(528, 20);
			this.textBox_10.TabIndex = 22;
			this.textBox_10.TextChanged += this.textBox_14_TextChanged;
			this.tableLayoutPanel_3.SetColumnSpan(this.textBox_11, 4);
			this.textBox_11.Dock = DockStyle.Fill;
			this.textBox_11.Location = new Point(14, 577);
			this.textBox_11.Name = "tbTO1";
			this.textBox_11.Size = new Size(712, 20);
			this.textBox_11.TabIndex = 29;
			this.textBox_11.TextChanged += this.textBox_14_TextChanged;
			this.label_21.AutoSize = true;
			this.label_21.Dock = DockStyle.Fill;
			this.label_21.Location = new Point(14, 433);
			this.label_21.Name = "lbOwnerChief2";
			this.label_21.Size = new Size(178, 23);
			this.label_21.TabIndex = 21;
			this.label_21.Text = "Владелец сетей(для подписи):";
			this.label_21.TextAlign = ContentAlignment.MiddleLeft;
			this.label_24.AutoSize = true;
			this.tableLayoutPanel_3.SetColumnSpan(this.label_24, 2);
			this.label_24.Dock = DockStyle.Fill;
			this.label_24.Location = new Point(14, 499);
			this.label_24.Name = "lbDogByOTONum";
			this.label_24.Size = new Size(357, 26);
			this.label_24.TabIndex = 24;
			this.label_24.Text = "При наличии договора на Оперативно-техническое обслуживание № ";
			this.label_24.TextAlign = ContentAlignment.MiddleLeft;
			this.label_22.AutoSize = true;
			this.tableLayoutPanel_3.SetColumnSpan(this.label_22, 4);
			this.label_22.Dock = DockStyle.Fill;
			this.label_22.Location = new Point(14, 549);
			this.label_22.Name = "lbTO1";
			this.label_22.Size = new Size(712, 25);
			this.label_22.TabIndex = 28;
			this.label_22.Text = "При наличии договора на Оперативно-техническое обслуживание ответственность";
			this.label_22.TextAlign = ContentAlignment.BottomLeft;
			this.label_20.AutoSize = true;
			this.tableLayoutPanel_3.SetColumnSpan(this.label_20, 4);
			this.label_20.Dock = DockStyle.Fill;
			this.label_20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label_20.Location = new Point(14, 456);
			this.label_20.Name = "label3";
			this.label_20.Size = new Size(712, 43);
			this.label_20.TabIndex = 23;
			this.label_20.Text = "Дополнительные поля для акта c ТО";
			this.label_20.TextAlign = ContentAlignment.MiddleCenter;
			this.label_20.UseWaitCursor = true;
			this.tableLayoutPanel_3.SetColumnSpan(this.textBox_12, 4);
			this.textBox_12.Dock = DockStyle.Fill;
			this.textBox_12.Location = new Point(14, 528);
			this.textBox_12.Name = "tbTO2";
			this.textBox_12.Size = new Size(712, 20);
			this.textBox_12.TabIndex = 27;
			this.textBox_12.TextChanged += this.textBox_14_TextChanged;
			this.tableLayoutPanel_3.SetColumnSpan(this.elementHost_1, 4);
			this.elementHost_1.Dock = DockStyle.Fill;
			this.elementHost_1.Location = new Point(14, 378);
			this.elementHost_1.Name = "hostOwnerExpl";
			this.elementHost_1.Size = new Size(712, 52);
			this.elementHost_1.TabIndex = 33;
			this.elementHost_1.Text = "elementHost5";
			this.elementHost_1.Child = null;
			this.tableLayoutPanel_3.SetColumnSpan(this.elementHost_0, 4);
			this.elementHost_0.Dock = DockStyle.Fill;
			this.elementHost_0.Location = new Point(14, 299);
			this.elementHost_0.Name = "hostBorder2Expl";
			this.elementHost_0.Size = new Size(712, 55);
			this.elementHost_0.TabIndex = 34;
			this.elementHost_0.Text = "elementHost6";
			this.elementHost_0.Child = null;
			this.tabPage_3.Controls.Add(this.tableLayoutPanel_4);
			this.tabPage_3.Location = new Point(4, 22);
			this.tabPage_3.Name = "tpDopoln2";
			this.tabPage_3.Padding = new Padding(3);
			this.tabPage_3.Size = new Size(743, 651);
			this.tabPage_3.TabIndex = 3;
			this.tabPage_3.Text = "Дополнительно-2";
			this.tabPage_3.UseVisualStyleBackColor = true;
			this.tableLayoutPanel_4.ColumnCount = 4;
			this.tableLayoutPanel_4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 13f));
			this.tableLayoutPanel_4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 181f));
			this.tableLayoutPanel_4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel_4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 14f));
			this.tableLayoutPanel_4.Controls.Add(this.label_31, 1, 0);
			this.tableLayoutPanel_4.Controls.Add(this.textBox_13, 2, 13);
			this.tableLayoutPanel_4.Controls.Add(this.label_30, 1, 1);
			this.tableLayoutPanel_4.Controls.Add(this.label_25, 1, 13);
			this.tableLayoutPanel_4.Controls.Add(this.textBox_15, 1, 2);
			this.tableLayoutPanel_4.Controls.Add(this.elementHost_3, 1, 12);
			this.tableLayoutPanel_4.Controls.Add(this.lqAgvlGle9, 1, 11);
			this.tableLayoutPanel_4.Controls.Add(this.label_29, 1, 3);
			this.tableLayoutPanel_4.Controls.Add(this.elementHost_2, 1, 10);
			this.tableLayoutPanel_4.Controls.Add(this.label_26, 1, 9);
			this.tableLayoutPanel_4.Controls.Add(this.BpwgFdgOge, 1, 4);
			this.tableLayoutPanel_4.Controls.Add(this.label_27, 1, 7);
			this.tableLayoutPanel_4.Controls.Add(this.label_28, 1, 5);
			this.tableLayoutPanel_4.Controls.Add(this.uLmgjiJpjw, 1, 8);
			this.tableLayoutPanel_4.Controls.Add(this.textBox_14, 1, 6);
			this.tableLayoutPanel_4.Dock = DockStyle.Fill;
			this.tableLayoutPanel_4.Location = new Point(3, 3);
			this.tableLayoutPanel_4.Name = "tableLayoutPanel3";
			this.tableLayoutPanel_4.RowCount = 15;
			this.tableLayoutPanel_4.RowStyles.Add(new RowStyle(SizeType.Absolute, 32f));
			this.tableLayoutPanel_4.RowStyles.Add(new RowStyle(SizeType.Absolute, 38f));
			this.tableLayoutPanel_4.RowStyles.Add(new RowStyle(SizeType.Absolute, 25f));
			this.tableLayoutPanel_4.RowStyles.Add(new RowStyle(SizeType.Absolute, 24f));
			this.tableLayoutPanel_4.RowStyles.Add(new RowStyle(SizeType.Absolute, 25f));
			this.tableLayoutPanel_4.RowStyles.Add(new RowStyle(SizeType.Absolute, 23f));
			this.tableLayoutPanel_4.RowStyles.Add(new RowStyle(SizeType.Absolute, 25f));
			this.tableLayoutPanel_4.RowStyles.Add(new RowStyle(SizeType.Absolute, 24f));
			this.tableLayoutPanel_4.RowStyles.Add(new RowStyle(SizeType.Absolute, 66f));
			this.tableLayoutPanel_4.RowStyles.Add(new RowStyle(SizeType.Absolute, 25f));
			this.tableLayoutPanel_4.RowStyles.Add(new RowStyle(SizeType.Absolute, 70f));
			this.tableLayoutPanel_4.RowStyles.Add(new RowStyle(SizeType.Absolute, 23f));
			this.tableLayoutPanel_4.RowStyles.Add(new RowStyle(SizeType.Absolute, 73f));
			this.tableLayoutPanel_4.RowStyles.Add(new RowStyle(SizeType.Absolute, 25f));
			this.tableLayoutPanel_4.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel_4.Size = new Size(737, 645);
			this.tableLayoutPanel_4.TabIndex = 49;
			this.label_31.AutoSize = true;
			this.tableLayoutPanel_4.SetColumnSpan(this.label_31, 2);
			this.label_31.Dock = DockStyle.Fill;
			this.label_31.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label_31.Location = new Point(16, 0);
			this.label_31.Name = "label4";
			this.label_31.Size = new Size(704, 32);
			this.label_31.TabIndex = 1;
			this.label_31.Text = "Дополнительные поля для 4-х стороннего акта";
			this.label_31.TextAlign = ContentAlignment.MiddleCenter;
			this.textBox_13.Dock = DockStyle.Fill;
			this.textBox_13.Location = new Point(197, 476);
			this.textBox_13.Name = "tbOwnerChief2_Four";
			this.textBox_13.Size = new Size(523, 20);
			this.textBox_13.TabIndex = 45;
			this.textBox_13.TextChanged += this.textBox_14_TextChanged;
			this.label_30.AutoSize = true;
			this.tableLayoutPanel_4.SetColumnSpan(this.label_30, 2);
			this.label_30.Dock = DockStyle.Fill;
			this.label_30.Location = new Point(16, 32);
			this.label_30.Name = "label11";
			this.label_30.Size = new Size(704, 38);
			this.label_30.TabIndex = 35;
			this.label_30.Text = "Владелец сетей:";
			this.label_30.TextAlign = ContentAlignment.BottomLeft;
			this.label_25.AutoSize = true;
			this.label_25.Dock = DockStyle.Fill;
			this.label_25.Location = new Point(16, 473);
			this.label_25.Name = "label5";
			this.label_25.Size = new Size(175, 25);
			this.label_25.TabIndex = 44;
			this.label_25.Text = "Владелец сетей(для подписи):";
			this.label_25.TextAlign = ContentAlignment.MiddleLeft;
			this.tableLayoutPanel_4.SetColumnSpan(this.textBox_15, 2);
			this.textBox_15.Dock = DockStyle.Fill;
			this.textBox_15.Location = new Point(16, 73);
			this.textBox_15.Name = "tbOwnerName_Four";
			this.textBox_15.Size = new Size(704, 20);
			this.textBox_15.TabIndex = 36;
			this.textBox_15.TextChanged += this.textBox_14_TextChanged;
			this.tableLayoutPanel_4.SetColumnSpan(this.elementHost_3, 2);
			this.elementHost_3.Dock = DockStyle.Fill;
			this.elementHost_3.Location = new Point(16, 403);
			this.elementHost_3.Name = "hostOwnerExpl_Four";
			this.elementHost_3.Size = new Size(704, 67);
			this.elementHost_3.TabIndex = 47;
			this.elementHost_3.Text = "elementHost5";
			this.elementHost_3.Child = null;
			this.lqAgvlGle9.AutoSize = true;
			this.tableLayoutPanel_4.SetColumnSpan(this.lqAgvlGle9, 2);
			this.lqAgvlGle9.Dock = DockStyle.Fill;
			this.lqAgvlGle9.Location = new Point(16, 377);
			this.lqAgvlGle9.Name = "label6";
			this.lqAgvlGle9.Size = new Size(704, 23);
			this.lqAgvlGle9.TabIndex = 43;
			this.lqAgvlGle9.Text = "В эксплуатации владельца сетей находится:";
			this.lqAgvlGle9.TextAlign = ContentAlignment.BottomLeft;
			this.label_29.AutoSize = true;
			this.tableLayoutPanel_4.SetColumnSpan(this.label_29, 2);
			this.label_29.Dock = DockStyle.Fill;
			this.label_29.Location = new Point(16, 95);
			this.label_29.Name = "label10";
			this.label_29.Size = new Size(704, 24);
			this.label_29.TabIndex = 37;
			this.label_29.Text = "в лице:";
			this.label_29.TextAlign = ContentAlignment.BottomLeft;
			this.tableLayoutPanel_4.SetColumnSpan(this.elementHost_2, 2);
			this.elementHost_2.Dock = DockStyle.Fill;
			this.elementHost_2.Location = new Point(16, 310);
			this.elementHost_2.Name = "hostBorder2Expl_Four";
			this.elementHost_2.Size = new Size(704, 64);
			this.elementHost_2.TabIndex = 48;
			this.elementHost_2.Text = "elementHost6";
			this.elementHost_2.Child = null;
			this.label_26.AutoSize = true;
			this.tableLayoutPanel_4.SetColumnSpan(this.label_26, 2);
			this.label_26.Dock = DockStyle.Fill;
			this.label_26.Location = new Point(16, 282);
			this.label_26.Name = "lbBorder2Expl_Four";
			this.label_26.Size = new Size(704, 25);
			this.label_26.TabIndex = 42;
			this.label_26.Text = "Границей балансовой принадлежности сторон является:";
			this.label_26.TextAlign = ContentAlignment.BottomLeft;
			this.tableLayoutPanel_4.SetColumnSpan(this.BpwgFdgOge, 2);
			this.BpwgFdgOge.Dock = DockStyle.Fill;
			this.BpwgFdgOge.Location = new Point(16, 122);
			this.BpwgFdgOge.Name = "tbOwnerChief_Four";
			this.BpwgFdgOge.Size = new Size(704, 20);
			this.BpwgFdgOge.TabIndex = 38;
			this.BpwgFdgOge.TextChanged += this.textBox_14_TextChanged;
			this.label_27.AutoSize = true;
			this.tableLayoutPanel_4.SetColumnSpan(this.label_27, 2);
			this.label_27.Dock = DockStyle.Fill;
			this.label_27.Location = new Point(16, 192);
			this.label_27.Name = "label8";
			this.label_27.Size = new Size(704, 24);
			this.label_27.TabIndex = 41;
			this.label_27.Text = "На балансе Владельца сетей находится:";
			this.label_27.TextAlign = ContentAlignment.BottomLeft;
			this.label_28.AutoSize = true;
			this.tableLayoutPanel_4.SetColumnSpan(this.label_28, 2);
			this.label_28.Dock = DockStyle.Fill;
			this.label_28.Location = new Point(16, 144);
			this.label_28.Name = "label9";
			this.label_28.Size = new Size(704, 23);
			this.label_28.TabIndex = 39;
			this.label_28.Text = "действующий на основании:";
			this.label_28.TextAlign = ContentAlignment.BottomLeft;
			this.tableLayoutPanel_4.SetColumnSpan(this.uLmgjiJpjw, 2);
			this.uLmgjiJpjw.Dock = DockStyle.Fill;
			this.uLmgjiJpjw.Location = new Point(16, 219);
			this.uLmgjiJpjw.Name = "hostOrganizExpl_Four";
			this.uLmgjiJpjw.Size = new Size(704, 60);
			this.uLmgjiJpjw.TabIndex = 46;
			this.uLmgjiJpjw.Text = "elementHost4";
			this.uLmgjiJpjw.Child = null;
			this.tableLayoutPanel_4.SetColumnSpan(this.textBox_14, 2);
			this.textBox_14.Dock = DockStyle.Fill;
			this.textBox_14.Location = new Point(16, 170);
			this.textBox_14.Name = "tbOwnerBase_Four";
			this.textBox_14.Size = new Size(704, 20);
			this.textBox_14.TabIndex = 40;
			this.textBox_14.TextChanged += this.textBox_14_TextChanged;
			this.tabPage_2.Controls.Add(this.tableLayoutPanel_7);
			this.tabPage_2.Location = new Point(4, 22);
			this.tabPage_2.Name = "tpPrivyazka";
			this.tabPage_2.Padding = new Padding(3);
			this.tabPage_2.Size = new Size(743, 651);
			this.tabPage_2.TabIndex = 2;
			this.tabPage_2.Text = "Изображение";
			this.tabPage_2.UseVisualStyleBackColor = true;
			this.tableLayoutPanel_7.ColumnCount = 2;
			this.tableLayoutPanel_7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.90953f));
			this.tableLayoutPanel_7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 76.09047f));
			this.tableLayoutPanel_7.Controls.Add(this.pictureBox_0, 1, 1);
			this.tableLayoutPanel_7.Controls.Add(this.toolStrip_0, 0, 0);
			this.tableLayoutPanel_7.Controls.Add(this.dataGridViewExcelFilter_0, 0, 1);
			this.tableLayoutPanel_7.Dock = DockStyle.Fill;
			this.tableLayoutPanel_7.Location = new Point(3, 3);
			this.tableLayoutPanel_7.Name = "tableLayoutPanel6";
			this.tableLayoutPanel_7.RowCount = 2;
			this.tableLayoutPanel_7.RowStyles.Add(new RowStyle(SizeType.Absolute, 26f));
			this.tableLayoutPanel_7.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
			this.tableLayoutPanel_7.Size = new Size(737, 645);
			this.tableLayoutPanel_7.TabIndex = 40;
			this.pictureBox_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.pictureBox_0.Location = new Point(179, 29);
			this.pictureBox_0.Name = "pbScanDoc";
			this.pictureBox_0.Size = new Size(555, 613);
			this.pictureBox_0.TabIndex = 1;
			this.pictureBox_0.TabStop = false;
			this.tableLayoutPanel_7.SetColumnSpan(this.toolStrip_0, 2);
			this.toolStrip_0.Dock = DockStyle.Fill;
			this.toolStrip_0.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripButton_0,
				this.toolStripButton_1,
				this.toolStripButton_2,
				this.toolStripButton_3
			});
			this.toolStrip_0.Location = new Point(0, 0);
			this.toolStrip_0.Name = "toolStripImage";
			this.toolStrip_0.Size = new Size(737, 26);
			this.toolStrip_0.TabIndex = 0;
			this.toolStrip_0.Text = "toolStrip1";
			this.toolStripButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_0.Image = (System.Drawing.Image)componentResourceManager.GetObject("tsbImage.Image");
			this.toolStripButton_0.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_0.Name = "tsbImage";
			this.toolStripButton_0.Size = new Size(23, 23);
			this.toolStripButton_0.Text = "Добавить изображение";
			this.toolStripButton_0.Click += this.toolStripMenuItem_0_Click;
			this.toolStripButton_1.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_1.Image = (System.Drawing.Image)componentResourceManager.GetObject("tsbRemoveImage.Image");
			this.toolStripButton_1.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_1.Name = "tsbRemoveImage";
			this.toolStripButton_1.Size = new Size(23, 23);
			this.toolStripButton_1.Text = "Удалить изображение";
			this.toolStripButton_1.Click += this.toolStripMenuItem_1_Click;
			this.toolStripButton_2.Alignment = ToolStripItemAlignment.Right;
			this.toolStripButton_2.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_2.Image = (System.Drawing.Image)componentResourceManager.GetObject("tsbSaveImage.Image");
			this.toolStripButton_2.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_2.Name = "tsbSaveImage";
			this.toolStripButton_2.Size = new Size(23, 23);
			this.toolStripButton_2.Text = "Сохранить изображение в файл для просмотра и печати";
			this.toolStripButton_2.Click += this.toolStripButton_2_Click;
			this.toolStripButton_3.Alignment = ToolStripItemAlignment.Right;
			this.toolStripButton_3.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_3.Image = (System.Drawing.Image)componentResourceManager.GetObject("toolStripButton1.Image");
			this.toolStripButton_3.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_3.Name = "toolStripButton1";
			this.toolStripButton_3.Size = new Size(23, 23);
			this.toolStripButton_3.Text = "Открытие и печать изображения";
			this.toolStripButton_3.Click += this.toolStripButton_3_Click;
			this.dataGridViewExcelFilter_0.AllowUserToAddRows = false;
			this.dataGridViewExcelFilter_0.AllowUserToDeleteRows = false;
			dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle7.BackColor = SystemColors.Control;
			dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle7.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
			this.dataGridViewExcelFilter_0.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
			this.dataGridViewExcelFilter_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewExcelFilter_0.ColumnHeadersVisible = false;
			this.dataGridViewExcelFilter_0.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewImageColumn_0,
				this.dataGridViewImageColumn_1,
				this.dataGridViewCheckBoxColumn_0,
				this.dataGridViewTextBoxColumn_0
			});
			dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle8.BackColor = SystemColors.Window;
			dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle8.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
			this.dataGridViewExcelFilter_0.DefaultCellStyle = dataGridViewCellStyle8;
			this.dataGridViewExcelFilter_0.Dock = DockStyle.Fill;
			this.dataGridViewExcelFilter_0.Location = new Point(3, 29);
			this.dataGridViewExcelFilter_0.Name = "dataGridViewImages";
			this.dataGridViewExcelFilter_0.ReadOnly = true;
			dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle9.BackColor = SystemColors.Control;
			dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle9.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle9.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle9.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
			this.dataGridViewExcelFilter_0.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
			this.dataGridViewExcelFilter_0.RowHeadersWidth = 4;
			this.dataGridViewExcelFilter_0.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dataGridViewExcelFilter_0.RowTemplate.Height = 200;
			this.dataGridViewExcelFilter_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewExcelFilter_0.Size = new Size(170, 613);
			this.dataGridViewExcelFilter_0.TabIndex = 39;
			this.dataGridViewExcelFilter_0.CellMouseClick += this.dataGridViewExcelFilter_0_CellMouseClick;
			this.dataGridViewImageColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewImageColumn_0.HeaderText = "image";
			this.dataGridViewImageColumn_0.Name = "image";
			this.dataGridViewImageColumn_0.ReadOnly = true;
			this.dataGridViewImageColumn_1.HeaderText = "ImageOriginal";
			this.dataGridViewImageColumn_1.Name = "ImageOriginal";
			this.dataGridViewImageColumn_1.ReadOnly = true;
			this.dataGridViewImageColumn_1.Visible = false;
			this.dataGridViewCheckBoxColumn_0.HeaderText = "Compressed";
			this.dataGridViewCheckBoxColumn_0.Name = "Compressed";
			this.dataGridViewCheckBoxColumn_0.ReadOnly = true;
			this.dataGridViewCheckBoxColumn_0.Visible = false;
			this.dataGridViewTextBoxColumn_0.HeaderText = "id";
			this.dataGridViewTextBoxColumn_0.Name = "id";
			this.dataGridViewTextBoxColumn_0.ReadOnly = true;
			this.dataGridViewTextBoxColumn_0.Visible = false;
			this.tabPage_4.Controls.Add(this.tableLayoutPanel_1);
			this.tabPage_4.Location = new Point(4, 22);
			this.tabPage_4.Name = "tpFiles";
			this.tabPage_4.Size = new Size(743, 651);
			this.tabPage_4.TabIndex = 4;
			this.tabPage_4.Text = "Файлы";
			this.tabPage_4.UseVisualStyleBackColor = true;
			this.tableLayoutPanel_1.ColumnCount = 1;
			this.tableLayoutPanel_1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel_1.Controls.Add(this.toolStrip_1, 0, 0);
			this.tableLayoutPanel_1.Controls.Add(this.dataGridViewExcelFilter_1, 0, 1);
			this.tableLayoutPanel_1.Dock = DockStyle.Fill;
			this.tableLayoutPanel_1.Location = new Point(0, 0);
			this.tableLayoutPanel_1.Name = "tlpFiles";
			this.tableLayoutPanel_1.RowCount = 2;
			this.tableLayoutPanel_1.RowStyles.Add(new RowStyle(SizeType.Absolute, 24f));
			this.tableLayoutPanel_1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel_1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
			this.tableLayoutPanel_1.Size = new Size(743, 651);
			this.tableLayoutPanel_1.TabIndex = 0;
			this.toolStrip_1.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripDropDownButton_0,
				this.toolStripButton_4,
				this.toolStripButton_5,
				this.toolStripButton_6,
				this.toolStripSeparator_1,
				this.toolStripButton_7,
				this.toolStripButton_8
			});
			this.toolStrip_1.Location = new Point(0, 0);
			this.toolStrip_1.Name = "toolStripFile";
			this.toolStrip_1.Size = new Size(743, 24);
			this.toolStrip_1.TabIndex = 8;
			this.toolStrip_1.Text = "toolStrip1";
			this.toolStripDropDownButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripDropDownButton_0.DropDownItems.AddRange(new ToolStripItem[]
			{
				this.toolStripMenuItem_2,
				this.toolStripSeparator_0
			});
			this.toolStripDropDownButton_0.Image = (System.Drawing.Image)componentResourceManager.GetObject("toolBtnAddFile.Image");
			this.toolStripDropDownButton_0.ImageTransparentColor = Color.Magenta;
			this.toolStripDropDownButton_0.Name = "toolBtnAddFile";
			this.toolStripDropDownButton_0.Size = new Size(29, 21);
			this.toolStripDropDownButton_0.Text = "Добавить файл";
			this.toolStripMenuItem_2.Name = "toolItemAddExistFile";
			this.toolStripMenuItem_2.Size = new Size(190, 22);
			this.toolStripMenuItem_2.Text = "Сущесвующий файл";
			this.toolStripMenuItem_2.Click += this.toolStripMenuItem_4_Click;
			this.toolStripSeparator_0.Name = "toolStripSeparator2";
			this.toolStripSeparator_0.Size = new Size(187, 6);
			this.toolStripButton_4.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_4.Image = (System.Drawing.Image)componentResourceManager.GetObject("toolBtnEditFile.Image");
			this.toolStripButton_4.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_4.Name = "toolBtnEditFile";
			this.toolStripButton_4.Size = new Size(23, 21);
			this.toolStripButton_4.Text = "Редактировать файл";
			this.toolStripButton_4.Click += this.toolStripMenuItem_5_Click;
			this.toolStripButton_5.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_5.Image = (System.Drawing.Image)componentResourceManager.GetObject("toolBtnOpenFile.Image");
			this.toolStripButton_5.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_5.Name = "toolBtnOpenFile";
			this.toolStripButton_5.Size = new Size(23, 21);
			this.toolStripButton_5.Text = "Открыть файл";
			this.toolStripButton_5.Click += this.toolStripMenuItem_6_Click;
			this.toolStripButton_6.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_6.Image = (System.Drawing.Image)componentResourceManager.GetObject("toolBtnDelFile.Image");
			this.toolStripButton_6.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_6.Name = "toolBtnDelFile";
			this.toolStripButton_6.Size = new Size(23, 21);
			this.toolStripButton_6.Text = "Удалить файл";
			this.toolStripButton_6.Click += this.toolStripMenuItem_7_Click;
			this.toolStripSeparator_1.Name = "toolStripSeparator3";
			this.toolStripSeparator_1.Size = new Size(6, 24);
			this.toolStripButton_7.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_7.Image = (System.Drawing.Image)componentResourceManager.GetObject("toolBtnRenameFile.Image");
			this.toolStripButton_7.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_7.Name = "toolBtnRenameFile";
			this.toolStripButton_7.Size = new Size(23, 21);
			this.toolStripButton_7.Text = "Переименовать";
			this.toolStripButton_7.Click += this.toolStripMenuItem_8_Click;
			this.toolStripButton_8.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_8.Image = (System.Drawing.Image)componentResourceManager.GetObject("toolBtnSaveFile.Image");
			this.toolStripButton_8.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_8.Name = "toolBtnSaveFile";
			this.toolStripButton_8.Size = new Size(23, 21);
			this.toolStripButton_8.Text = "Сохранить файл на диск";
			this.toolStripButton_8.Click += this.toolStripMenuItem_9_Click;
			this.dataGridViewExcelFilter_1.AllowUserToAddRows = false;
			this.dataGridViewExcelFilter_1.AllowUserToDeleteRows = false;
			this.dataGridViewExcelFilter_1.AllowUserToResizeColumns = false;
			this.dataGridViewExcelFilter_1.AllowUserToResizeRows = false;
			this.dataGridViewExcelFilter_1.AutoGenerateColumns = false;
			dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle10.BackColor = SystemColors.Control;
			dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle10.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle10.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle10.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle10.WrapMode = DataGridViewTriState.True;
			this.dataGridViewExcelFilter_1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
			this.dataGridViewExcelFilter_1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewExcelFilter_1.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewTextBoxColumn_1,
				this.dataGridViewTextBoxColumn_2,
				this.dataGridViewFilterTextBoxColumn_0,
				this.dataGridViewTextBoxColumn_3,
				this.dataGridViewTextBoxColumn_4,
				this.dataGridViewImageColumnNotNull_0
			});
			this.dataGridViewExcelFilter_1.DataSource = this.bindingSource_0;
			dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle11.BackColor = SystemColors.Window;
			dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle11.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle11.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle11.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle11.WrapMode = DataGridViewTriState.False;
			this.dataGridViewExcelFilter_1.DefaultCellStyle = dataGridViewCellStyle11;
			this.dataGridViewExcelFilter_1.Dock = DockStyle.Fill;
			this.dataGridViewExcelFilter_1.EditMode = DataGridViewEditMode.EditProgrammatically;
			this.dataGridViewExcelFilter_1.Location = new Point(3, 27);
			this.dataGridViewExcelFilter_1.MultiSelect = false;
			this.dataGridViewExcelFilter_1.Name = "dgvFile";
			this.dataGridViewExcelFilter_1.ReadOnly = true;
			dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle12.BackColor = SystemColors.Control;
			dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle12.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle12.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle12.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle12.WrapMode = DataGridViewTriState.True;
			this.dataGridViewExcelFilter_1.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
			this.dataGridViewExcelFilter_1.RowHeadersVisible = false;
			this.dataGridViewExcelFilter_1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewExcelFilter_1.Size = new Size(737, 621);
			this.dataGridViewExcelFilter_1.TabIndex = 7;
			this.dataGridViewExcelFilter_1.VirtualMode = true;
			this.dataGridViewExcelFilter_1.CellDoubleClick += this.dataGridViewExcelFilter_1_CellDoubleClick;
			this.dataGridViewExcelFilter_1.CellEndEdit += this.dataGridViewExcelFilter_1_CellEndEdit;
			this.dataGridViewExcelFilter_1.CellMouseClick += this.dataGridViewExcelFilter_1_CellMouseClick;
			this.dataGridViewExcelFilter_1.CellValidating += this.dataGridViewExcelFilter_1_CellValidating;
			this.dataGridViewExcelFilter_1.CellValueNeeded += this.dataGridViewExcelFilter_1_CellValueNeeded;
			this.dataGridViewTextBoxColumn_1.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_1.HeaderText = "id";
			this.dataGridViewTextBoxColumn_1.Name = "idDgvColumn";
			this.dataGridViewTextBoxColumn_1.ReadOnly = true;
			this.dataGridViewTextBoxColumn_1.Visible = false;
			this.dataGridViewTextBoxColumn_2.DataPropertyName = "idList";
			this.dataGridViewTextBoxColumn_2.HeaderText = "idList";
			this.dataGridViewTextBoxColumn_2.Name = "idListDgvColumn";
			this.dataGridViewTextBoxColumn_2.ReadOnly = true;
			this.dataGridViewTextBoxColumn_2.Visible = false;
			this.dataGridViewFilterTextBoxColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewFilterTextBoxColumn_0.DataPropertyName = "FileName";
			this.dataGridViewFilterTextBoxColumn_0.HeaderText = "Файл";
			this.dataGridViewFilterTextBoxColumn_0.Name = "fileNameDgvColumn";
			this.dataGridViewFilterTextBoxColumn_0.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_0.Resizable = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_3.DataPropertyName = "dateChange";
			this.dataGridViewTextBoxColumn_3.HeaderText = "dateChange";
			this.dataGridViewTextBoxColumn_3.Name = "dateChangeDgvColumn";
			this.dataGridViewTextBoxColumn_3.ReadOnly = true;
			this.dataGridViewTextBoxColumn_3.Visible = false;
			this.dataGridViewTextBoxColumn_4.DataPropertyName = "idTemplate";
			this.dataGridViewTextBoxColumn_4.HeaderText = "idTemplate";
			this.dataGridViewTextBoxColumn_4.Name = "idTemplateDgvColumn";
			this.dataGridViewTextBoxColumn_4.ReadOnly = true;
			this.dataGridViewTextBoxColumn_4.Visible = false;
			dataGridViewCellStyle13.NullValue = null;
			this.dataGridViewImageColumnNotNull_0.DefaultCellStyle = dataGridViewCellStyle13;
			this.dataGridViewImageColumnNotNull_0.HeaderText = "";
			this.dataGridViewImageColumnNotNull_0.ImageLayout = DataGridViewImageCellLayout.Zoom;
			this.dataGridViewImageColumnNotNull_0.Name = "imageDgvColumn";
			this.dataGridViewImageColumnNotNull_0.ReadOnly = true;
			this.dataGridViewImageColumnNotNull_0.Width = 30;
			this.bindingSource_0.DataMember = "tAbnObjDoc_File";
			this.bindingSource_0.DataSource = this.class255_0;
			this.button_2.BackColor = Color.LightGray;
			this.button_2.DialogResult = DialogResult.Cancel;
			this.button_2.Dock = DockStyle.Left;
			this.button_2.Location = new Point(641, 688);
			this.button_2.Margin = new Padding(6, 5, 3, 12);
			this.button_2.Name = "btnCancel";
			this.button_2.Size = new Size(94, 28);
			this.button_2.TabIndex = 34;
			this.button_2.Text = "Отменить";
			this.button_2.UseVisualStyleBackColor = false;
			this.button_2.Click += this.button_2_Click;
			this.button_3.BackColor = Color.LightGray;
			this.button_3.DialogResult = DialogResult.OK;
			this.button_3.Dock = DockStyle.Right;
			this.button_3.Location = new Point(535, 688);
			this.button_3.Margin = new Padding(3, 5, 6, 12);
			this.button_3.Name = "btnComplit";
			this.button_3.Size = new Size(94, 28);
			this.button_3.TabIndex = 33;
			this.button_3.Text = "Готово";
			this.button_3.UseVisualStyleBackColor = false;
			this.button_3.Click += this.button_3_Click;
			this.bindingSource_2.CurrentChanged += this.bindingSource_2_CurrentChanged;
			this.contextMenuStrip_0.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripMenuItem_0,
				this.toolStripMenuItem_1
			});
			this.contextMenuStrip_0.Name = "contextMenuStripImage";
			this.contextMenuStrip_0.Size = new Size(127, 48);
			this.toolStripMenuItem_0.Image = (System.Drawing.Image)componentResourceManager.GetObject("добавитьToolStripMenuItem.Image");
			this.toolStripMenuItem_0.Name = "добавитьToolStripMenuItem";
			this.toolStripMenuItem_0.Size = new Size(126, 22);
			this.toolStripMenuItem_0.Text = "Добавить";
			this.toolStripMenuItem_0.Click += this.toolStripMenuItem_0_Click;
			this.toolStripMenuItem_1.Image = (System.Drawing.Image)componentResourceManager.GetObject("удалитьToolStripMenuItem.Image");
			this.toolStripMenuItem_1.Name = "удалитьToolStripMenuItem";
			this.toolStripMenuItem_1.Size = new Size(126, 22);
			this.toolStripMenuItem_1.Text = "Удалить";
			this.toolStripMenuItem_1.Click += this.toolStripMenuItem_1_Click;
			this.contextMenuStrip_1.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripMenuItem_3,
				this.toolStripMenuItem_5,
				this.toolStripMenuItem_6,
				this.toolStripMenuItem_7,
				this.toolStripSeparator_3,
				this.toolStripMenuItem_8,
				this.toolStripMenuItem_9
			});
			this.contextMenuStrip_1.Name = "contextMenuFile";
			this.contextMenuStrip_1.Size = new Size(177, 142);
			this.toolStripMenuItem_3.DropDownItems.AddRange(new ToolStripItem[]
			{
				this.toolStripMenuItem_4,
				this.toolStripSeparator_2
			});
			this.toolStripMenuItem_3.Image = (System.Drawing.Image)componentResourceManager.GetObject("toolMenuItemAddFile.Image");
			this.toolStripMenuItem_3.Name = "toolMenuItemAddFile";
			this.toolStripMenuItem_3.Size = new Size(176, 22);
			this.toolStripMenuItem_3.Text = "Добавить";
			this.toolStripMenuItem_4.Name = "toolMenuItemAddExistsFile";
			this.toolStripMenuItem_4.Size = new Size(195, 22);
			this.toolStripMenuItem_4.Text = "Существующий файл";
			this.toolStripMenuItem_4.Click += this.toolStripMenuItem_4_Click;
			this.toolStripSeparator_2.Name = "toolStripSeparator5";
			this.toolStripSeparator_2.Size = new Size(192, 6);
			this.toolStripMenuItem_5.Image = (System.Drawing.Image)componentResourceManager.GetObject("toolMenuItemEditFile.Image");
			this.toolStripMenuItem_5.Name = "toolMenuItemEditFile";
			this.toolStripMenuItem_5.Size = new Size(176, 22);
			this.toolStripMenuItem_5.Text = "Редактировать";
			this.toolStripMenuItem_5.Click += this.toolStripMenuItem_5_Click;
			this.toolStripMenuItem_6.Image = (System.Drawing.Image)componentResourceManager.GetObject("toolMenuItemViewFile.Image");
			this.toolStripMenuItem_6.Name = "toolMenuItemViewFile";
			this.toolStripMenuItem_6.Size = new Size(176, 22);
			this.toolStripMenuItem_6.Text = "Просмотр";
			this.toolStripMenuItem_6.Click += this.toolStripMenuItem_6_Click;
			this.toolStripMenuItem_7.Image = (System.Drawing.Image)componentResourceManager.GetObject("toolMenuItemDelFile.Image");
			this.toolStripMenuItem_7.Name = "toolMenuItemDelFile";
			this.toolStripMenuItem_7.Size = new Size(176, 22);
			this.toolStripMenuItem_7.Text = "Удалить";
			this.toolStripMenuItem_7.Click += this.toolStripMenuItem_7_Click;
			this.toolStripSeparator_3.Name = "toolStripSeparator4";
			this.toolStripSeparator_3.Size = new Size(173, 6);
			this.toolStripMenuItem_8.Image = (System.Drawing.Image)componentResourceManager.GetObject("toolMenuItemRenameFile.Image");
			this.toolStripMenuItem_8.Name = "toolMenuItemRenameFile";
			this.toolStripMenuItem_8.Size = new Size(176, 22);
			this.toolStripMenuItem_8.Text = "Переименовать";
			this.toolStripMenuItem_8.Click += this.toolStripMenuItem_8_Click;
			this.toolStripMenuItem_9.Image = (System.Drawing.Image)componentResourceManager.GetObject("toolMenuItemSaveFile.Image");
			this.toolStripMenuItem_9.Name = "toolMenuItemSaveFile";
			this.toolStripMenuItem_9.Size = new Size(176, 22);
			this.toolStripMenuItem_9.Text = "Сохранить на диск";
			this.toolStripMenuItem_9.Click += this.toolStripMenuItem_9_Click;
			this.dataGridViewImageColumn_2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewImageColumn_2.HeaderText = "image";
			this.dataGridViewImageColumn_2.Name = "dataGridViewImageColumn1";
			this.dataGridViewImageColumn_2.ReadOnly = true;
			this.dataGridViewImageColumn_3.HeaderText = "ImageOriginal";
			this.dataGridViewImageColumn_3.Name = "dataGridViewImageColumn2";
			this.dataGridViewImageColumn_3.ReadOnly = true;
			this.dataGridViewImageColumn_3.Visible = false;
			this.dataGridViewCheckBoxColumn_1.HeaderText = "Compressed";
			this.dataGridViewCheckBoxColumn_1.Name = "dataGridViewCheckBoxColumn1";
			this.dataGridViewCheckBoxColumn_1.ReadOnly = true;
			this.dataGridViewCheckBoxColumn_1.Visible = false;
			dataGridViewCellStyle14.NullValue = null;
			this.dataGridViewImageColumnNotNull_1.DefaultCellStyle = dataGridViewCellStyle14;
			this.dataGridViewImageColumnNotNull_1.HeaderText = "";
			this.dataGridViewImageColumnNotNull_1.ImageLayout = DataGridViewImageCellLayout.Zoom;
			this.dataGridViewImageColumnNotNull_1.Name = "dataGridViewImageColumnNotNull1";
			this.dataGridViewImageColumnNotNull_1.ReadOnly = true;
			this.dataGridViewImageColumnNotNull_1.Width = 30;
			this.dataGridViewTextBoxColumn_5.DataPropertyName = "idTU";
			this.dataGridViewTextBoxColumn_5.HeaderText = "id";
			this.dataGridViewTextBoxColumn_5.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_5.ReadOnly = true;
			this.dataGridViewTextBoxColumn_5.Visible = false;
			this.dataGridViewTextBoxColumn_6.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_6.HeaderText = "id";
			this.dataGridViewTextBoxColumn_6.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn_6.ReadOnly = true;
			this.dataGridViewTextBoxColumn_6.Visible = false;
			this.dataGridViewTextBoxColumn_7.DataPropertyName = "idList";
			this.dataGridViewTextBoxColumn_7.HeaderText = "idList";
			this.dataGridViewTextBoxColumn_7.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn_7.ReadOnly = true;
			this.dataGridViewTextBoxColumn_7.Visible = false;
			this.dataGridViewTextBoxColumn_8.DataPropertyName = "dateChange";
			this.dataGridViewTextBoxColumn_8.HeaderText = "dateChange";
			this.dataGridViewTextBoxColumn_8.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn_8.ReadOnly = true;
			this.dataGridViewTextBoxColumn_8.Visible = false;
			this.dataGridViewTextBoxColumn_9.DataPropertyName = "idTemplate";
			this.dataGridViewTextBoxColumn_9.HeaderText = "idTemplate";
			this.dataGridViewTextBoxColumn_9.Name = "dataGridViewTextBoxColumn5";
			this.dataGridViewTextBoxColumn_9.ReadOnly = true;
			this.dataGridViewTextBoxColumn_9.Visible = false;
			this.dataGridViewTextBoxColumn_10.DataPropertyName = "idBusPoint";
			this.dataGridViewTextBoxColumn_10.HeaderText = "idBusPoint";
			this.dataGridViewTextBoxColumn_10.Name = "dataGridViewTextBoxColumn6";
			this.dataGridViewTextBoxColumn_10.Visible = false;
			this.dataGridViewTextBoxColumn_11.DataPropertyName = "BusPoint";
			this.dataGridViewTextBoxColumn_11.HeaderText = "BusPoint";
			this.dataGridViewTextBoxColumn_11.Name = "dataGridViewTextBoxColumn7";
			this.dataGridViewTextBoxColumn_11.Visible = false;
			this.dataGridViewTextBoxColumn_12.DataPropertyName = "BusFullPoint";
			this.dataGridViewTextBoxColumn_12.HeaderText = "BusFullPoint";
			this.dataGridViewTextBoxColumn_12.Name = "dataGridViewTextBoxColumn8";
			this.dataGridViewTextBoxColumn_12.ReadOnly = true;
			this.dataGridViewTextBoxColumn_12.Visible = false;
			this.dataGridViewTextBoxColumn_13.DataPropertyName = "idCellPoint";
			this.dataGridViewTextBoxColumn_13.HeaderText = "idCellPoint";
			this.dataGridViewTextBoxColumn_13.Name = "dataGridViewTextBoxColumn9";
			this.dataGridViewTextBoxColumn_13.Visible = false;
			this.dataGridViewTextBoxColumn_14.DataPropertyName = "CellPoint";
			this.dataGridViewTextBoxColumn_14.HeaderText = "CellPoint";
			this.dataGridViewTextBoxColumn_14.Name = "dataGridViewTextBoxColumn10";
			this.dataGridViewTextBoxColumn_14.Visible = false;
			this.dataGridViewTextBoxColumn_15.DataPropertyName = "CellFullPoint";
			this.dataGridViewTextBoxColumn_15.HeaderText = "CellFullPoint";
			this.dataGridViewTextBoxColumn_15.Name = "dataGridViewTextBoxColumn11";
			this.dataGridViewTextBoxColumn_15.ReadOnly = true;
			this.dataGridViewTextBoxColumn_15.Visible = false;
			this.dataGridViewTextBoxColumn_16.DataPropertyName = "idSubCP";
			this.dataGridViewTextBoxColumn_16.HeaderText = "idSubCP";
			this.dataGridViewTextBoxColumn_16.Name = "dataGridViewTextBoxColumn12";
			this.dataGridViewTextBoxColumn_16.Visible = false;
			this.dataGridViewTextBoxColumn_17.DataPropertyName = "SubCP";
			this.dataGridViewTextBoxColumn_17.HeaderText = "SubCP";
			this.dataGridViewTextBoxColumn_17.Name = "dataGridViewTextBoxColumn13";
			this.dataGridViewTextBoxColumn_17.ReadOnly = true;
			this.dataGridViewTextBoxColumn_17.Visible = false;
			this.dataGridViewTextBoxColumn_18.DataPropertyName = "idBusCP";
			this.dataGridViewTextBoxColumn_18.HeaderText = "idBusCP";
			this.dataGridViewTextBoxColumn_18.Name = "dataGridViewTextBoxColumn14";
			this.dataGridViewTextBoxColumn_18.Visible = false;
			this.dataGridViewTextBoxColumn_19.DataPropertyName = "BusCP";
			this.dataGridViewTextBoxColumn_19.HeaderText = "BusCP";
			this.dataGridViewTextBoxColumn_19.Name = "dataGridViewTextBoxColumn15";
			this.dataGridViewTextBoxColumn_19.Visible = false;
			this.qXfByJsXia.DataPropertyName = "idCellCP";
			this.qXfByJsXia.HeaderText = "idCellCP";
			this.qXfByJsXia.Name = "dataGridViewTextBoxColumn16";
			this.qXfByJsXia.Visible = false;
			this.dataGridViewTextBoxColumn_20.DataPropertyName = "CellCP";
			this.dataGridViewTextBoxColumn_20.HeaderText = "CellCP";
			this.dataGridViewTextBoxColumn_20.Name = "dataGridViewTextBoxColumn17";
			this.dataGridViewTextBoxColumn_20.Visible = false;
			this.dataGridViewTextBoxColumn_21.DataPropertyName = "AttachmentPoint";
			this.dataGridViewTextBoxColumn_21.HeaderText = "Точка присоединения";
			this.dataGridViewTextBoxColumn_21.Name = "dataGridViewTextBoxColumn18";
			this.dataGridViewTextBoxColumn_21.ReadOnly = true;
			this.dataGridViewTextBoxColumn_22.DataPropertyName = "PowerSupply";
			this.dataGridViewTextBoxColumn_22.HeaderText = "Источник питания (наименование питающих линий)";
			this.dataGridViewTextBoxColumn_22.Name = "dataGridViewTextBoxColumn19";
			this.dataGridViewTextBoxColumn_22.ReadOnly = true;
			this.dataGridViewTextBoxColumn_23.HeaderText = "Описание точки присоединения";
			this.dataGridViewTextBoxColumn_23.Name = "dataGridViewTextBoxColumn20";
			this.dataGridViewTextBoxColumn_24.DataPropertyName = "voltagelevel";
			this.dataGridViewTextBoxColumn_24.HeaderText = "voltagelevel";
			this.dataGridViewTextBoxColumn_24.Name = "dataGridViewTextBoxColumn21";
			this.dataGridViewTextBoxColumn_24.Visible = false;
			this.dataGridViewTextBoxColumn_25.DataPropertyName = "voltagelevelname";
			this.dataGridViewTextBoxColumn_25.HeaderText = "Уровень напряжения (кВ)";
			this.dataGridViewTextBoxColumn_25.Name = "dataGridViewTextBoxColumn22";
			this.dataGridViewTextBoxColumn_26.DataPropertyName = "powersum";
			this.dataGridViewTextBoxColumn_26.HeaderText = "Максимальная мощность (кВт)";
			this.dataGridViewTextBoxColumn_26.Name = "dataGridViewTextBoxColumn23";
			this.dataGridViewTextBoxColumn_27.HeaderText = "Величина номинальной мощности присоединенных троансформаторов (кВА)";
			this.dataGridViewTextBoxColumn_27.Name = "dataGridViewTextBoxColumn24";
			this.dataGridViewTextBoxColumn_28.DataPropertyName = "Category";
			this.dataGridViewTextBoxColumn_28.HeaderText = "Категория надежности электроснабжения";
			this.dataGridViewTextBoxColumn_28.Name = "dataGridViewTextBoxColumn25";
			this.dataGridViewTextBoxColumn_29.HeaderText = "id";
			this.dataGridViewTextBoxColumn_29.Name = "dataGridViewTextBoxColumn26";
			this.dataGridViewTextBoxColumn_29.ReadOnly = true;
			this.dataGridViewTextBoxColumn_29.Visible = false;
			this.dataGridViewTextBoxColumn_30.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_30.HeaderText = "id";
			this.dataGridViewTextBoxColumn_30.Name = "dataGridViewTextBoxColumn27";
			this.dataGridViewTextBoxColumn_30.ReadOnly = true;
			this.dataGridViewTextBoxColumn_30.Visible = false;
			this.dataGridViewTextBoxColumn_31.DataPropertyName = "idList";
			this.dataGridViewTextBoxColumn_31.HeaderText = "idList";
			this.dataGridViewTextBoxColumn_31.Name = "dataGridViewTextBoxColumn28";
			this.dataGridViewTextBoxColumn_31.ReadOnly = true;
			this.dataGridViewTextBoxColumn_31.Visible = false;
			this.dataGridViewFilterTextBoxColumn_1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewFilterTextBoxColumn_1.DataPropertyName = "FileName";
			this.dataGridViewFilterTextBoxColumn_1.HeaderText = "Файл";
			this.dataGridViewFilterTextBoxColumn_1.Name = "dataGridViewFilterTextBoxColumn1";
			this.dataGridViewFilterTextBoxColumn_1.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_1.Resizable = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_32.DataPropertyName = "dateChange";
			this.dataGridViewTextBoxColumn_32.HeaderText = "dateChange";
			this.dataGridViewTextBoxColumn_32.Name = "dataGridViewTextBoxColumn29";
			this.dataGridViewTextBoxColumn_32.ReadOnly = true;
			this.dataGridViewTextBoxColumn_32.Visible = false;
			this.dataGridViewTextBoxColumn_33.DataPropertyName = "idTemplate";
			this.dataGridViewTextBoxColumn_33.HeaderText = "idTemplate";
			this.dataGridViewTextBoxColumn_33.Name = "dataGridViewTextBoxColumn30";
			this.dataGridViewTextBoxColumn_33.ReadOnly = true;
			this.dataGridViewTextBoxColumn_33.Visible = false;
			this.class10_0.DataSetName = "DataSetTechConnection";
			this.class10_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
			this.class255_1.DataSetName = "dsAbnDocum";
			this.class255_1.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
			base.AcceptButton = this.button_3;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.CancelButton = this.button_2;
			base.ClientSize = new Size(757, 728);
			base.Controls.Add(this.tableLayoutPanel_0);
			base.Name = "FormAbnAktRBP";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Акт разграничения балансовой принадлежности";
			base.FormClosing += this.FormAbnAktRBP_FormClosing;
			base.Load += this.FormAbnAktRBP_Load;
			base.Shown += this.FormAbnAktRBP_Shown;
			this.tableLayoutPanel_0.ResumeLayout(false);
			this.tabControl_0.ResumeLayout(false);
			this.tabPage_0.ResumeLayout(false);
			this.tableLayoutPanel_5.ResumeLayout(false);
			this.tableLayoutPanel_5.PerformLayout();
			this.tabPage_6.ResumeLayout(false);
			this.tabPage_6.PerformLayout();
			((ISupportInitialize)this.dataGridView_1).EndInit();
			this.panel_1.ResumeLayout(false);
			this.panel_1.PerformLayout();
			this.toolStrip_2.ResumeLayout(false);
			this.toolStrip_2.PerformLayout();
			this.tabPage_5.ResumeLayout(false);
			this.tableLayoutPanel_2.ResumeLayout(false);
			this.panel_0.ResumeLayout(false);
			this.tableLayoutPanel_6.ResumeLayout(false);
			this.tableLayoutPanel_6.PerformLayout();
			((ISupportInitialize)this.bindingSource_3).EndInit();
			((ISupportInitialize)this.class255_0).EndInit();
			((ISupportInitialize)this.dataGridView_0).EndInit();
			((ISupportInitialize)this.bindingSource_1).EndInit();
			this.tabPage_1.ResumeLayout(false);
			this.tableLayoutPanel_3.ResumeLayout(false);
			this.tableLayoutPanel_3.PerformLayout();
			this.tabPage_3.ResumeLayout(false);
			this.tableLayoutPanel_4.ResumeLayout(false);
			this.tableLayoutPanel_4.PerformLayout();
			this.tabPage_2.ResumeLayout(false);
			this.tableLayoutPanel_7.ResumeLayout(false);
			this.tableLayoutPanel_7.PerformLayout();
			((ISupportInitialize)this.pictureBox_0).EndInit();
			this.toolStrip_0.ResumeLayout(false);
			this.toolStrip_0.PerformLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_0).EndInit();
			this.tabPage_4.ResumeLayout(false);
			this.tableLayoutPanel_1.ResumeLayout(false);
			this.tableLayoutPanel_1.PerformLayout();
			this.toolStrip_1.ResumeLayout(false);
			this.toolStrip_1.PerformLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_1).EndInit();
			((ISupportInitialize)this.bindingSource_0).EndInit();
			((ISupportInitialize)this.bindingSource_2).EndInit();
			this.contextMenuStrip_0.ResumeLayout(false);
			this.contextMenuStrip_1.ResumeLayout(false);
			((ISupportInitialize)this.class10_0).EndInit();
			((ISupportInitialize)this.class255_1).EndInit();
			base.ResumeLayout(false);
		}

		[CompilerGenerated]
		private void method_38()
		{
			this.bindingSource_0.ResetBindings(false);
		}

		[CompilerGenerated]
		private int int_0;

		[CompilerGenerated]
		private int int_1;

		private Enum2 enum2_0;

		private DataRow dataRow_0;

		private DataRow dataRow_1;

		private int int_2;

		private int int_3;

		private int int_4;

		private Process process_0;

		private bool bool_0;

		private bool bool_1;

		private bool bool_2;

		private int? nullable_0;

		private TypeDocValue typeDocValue_0;

		private Dictionary<string, FileWatcherArgsAddl> dictionary_0;

		private string string_0;

		private TableLayoutPanel tableLayoutPanel_0;

		private System.Windows.Forms.TabControl tabControl_0;

		private TabPage tabPage_0;

		private System.Windows.Forms.Button button_0;

		private System.Windows.Forms.Button button_1;

		private System.Windows.Forms.TextBox textBox_0;

		private System.Windows.Forms.TextBox textBox_1;

		private System.Windows.Forms.TextBox textBox_2;

		private System.Windows.Forms.TextBox textBox_3;

		private System.Windows.Forms.TextBox textBox_4;

		private System.Windows.Forms.TextBox textBox_5;

		private System.Windows.Forms.TextBox textBox_6;

		private System.Windows.Forms.TextBox textBox_7;

		private System.Windows.Forms.Label label_0;

		private System.Windows.Forms.Label label_1;

		private System.Windows.Forms.Label label_2;

		private System.Windows.Forms.Label label_3;

		private System.Windows.Forms.Label label_4;

		private System.Windows.Forms.Label label_5;

		private System.Windows.Forms.Label label_6;

		private System.Windows.Forms.Label label_7;

		private System.Windows.Forms.Label label_8;

		private System.Windows.Forms.Label label_9;

		private DateTimePicker dateTimePicker_0;

		private System.Windows.Forms.ComboBox comboBox_0;

		private System.Windows.Forms.Label label_10;

		private System.Windows.Forms.Label label_11;

		private System.Windows.Forms.Label label_12;

		private TabPage tabPage_1;

		private TabPage tabPage_2;

		private System.Windows.Forms.Label label_13;

		private System.Windows.Forms.Label label_14;

		private System.Windows.Forms.TextBox textBox_8;

		private System.Windows.Forms.Label label_15;

		private System.Windows.Forms.TextBox pbtrqMeGe2;

		private System.Windows.Forms.Label label_16;

		private System.Windows.Forms.TextBox textBox_9;

		private System.Windows.Forms.Label label_17;

		private System.Windows.Forms.Label label_18;

		private System.Windows.Forms.Label label_19;

		private System.Windows.Forms.Label label_20;

		private System.Windows.Forms.TextBox textBox_10;

		private System.Windows.Forms.Label label_21;

		private System.Windows.Forms.TextBox textBox_11;

		private System.Windows.Forms.Label label_22;

		private System.Windows.Forms.TextBox textBox_12;

		private System.Windows.Forms.Label label_23;

		private System.Windows.Forms.TextBox peygMhnWkn;

		private System.Windows.Forms.Label label_24;

		private TextBoxDropDown textBoxDropDown_0;

		private TextBoxDropDown textBoxDropDown_1;

		private ElementHost elementHost_0;

		private ElementHost elementHost_1;

		private Class255 class255_0;

		private ToolStrip toolStrip_0;

		private ToolStripButton toolStripButton_0;

		private ToolStripButton toolStripButton_1;

		private ContextMenuStrip contextMenuStrip_0;

		private ToolStripMenuItem toolStripMenuItem_0;

		private ToolStripMenuItem toolStripMenuItem_1;

		private DataGridViewExcelFilter dataGridViewExcelFilter_0;

		private ToolStripButton toolStripButton_2;

		private TabPage tabPage_3;

		private System.Windows.Forms.TextBox textBox_13;

		private System.Windows.Forms.Label label_25;

		private System.Windows.Forms.Label lqAgvlGle9;

		private System.Windows.Forms.Label label_26;

		private System.Windows.Forms.Label label_27;

		private System.Windows.Forms.TextBox textBox_14;

		private System.Windows.Forms.Label label_28;

		private System.Windows.Forms.TextBox BpwgFdgOge;

		private System.Windows.Forms.Label label_29;

		private System.Windows.Forms.TextBox textBox_15;

		private System.Windows.Forms.Label label_30;

		private ElementHost elementHost_2;

		private TextBoxDropDown textBoxDropDown_2;

		private ElementHost elementHost_3;

		private TextBoxDropDown textBoxDropDown_3;

		private ElementHost uLmgjiJpjw;

		private System.Windows.Forms.Label label_31;

		private TextBoxDropDown textBoxDropDown_4;

		private System.Windows.Forms.Button button_2;

		private System.Windows.Forms.Button button_3;

		private TextBoxDropDown textBoxDropDown_5;

		private TextBoxDropDown textBoxDropDown_6;

		private TextBoxDropDown QaFgrduphk;

		private DataGridViewImageColumn dataGridViewImageColumn_0;

		private DataGridViewImageColumn dataGridViewImageColumn_1;

		private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn_0;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

		private ToolStripButton toolStripButton_3;

		private TextBoxDropDown textBoxDropDown_7;

		private ElementHost elementHost_4;

		private ElementHost elementHost_5;

		private ElementHost elementHost_6;

		private ElementHost elementHost_7;

		private TabPage tabPage_4;

		private TableLayoutPanel tableLayoutPanel_1;

		private BindingSource bindingSource_0;

		private DataGridViewExcelFilter dataGridViewExcelFilter_1;

		private DataGridViewImageColumnNotNull dataGridViewImageColumnNotNull_0;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_0;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_3;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_4;

		private ToolStrip toolStrip_1;

		private ToolStripDropDownButton toolStripDropDownButton_0;

		private ToolStripMenuItem toolStripMenuItem_2;

		private ToolStripSeparator toolStripSeparator_0;

		private ToolStripButton toolStripButton_4;

		private ToolStripButton toolStripButton_5;

		private ToolStripButton toolStripButton_6;

		private ToolStripSeparator toolStripSeparator_1;

		private ToolStripButton toolStripButton_7;

		private ToolStripButton toolStripButton_8;

		private ContextMenuStrip contextMenuStrip_1;

		private ToolStripMenuItem toolStripMenuItem_3;

		private ToolStripMenuItem toolStripMenuItem_4;

		private ToolStripSeparator toolStripSeparator_2;

		private ToolStripMenuItem toolStripMenuItem_5;

		private ToolStripMenuItem toolStripMenuItem_6;

		private ToolStripMenuItem toolStripMenuItem_7;

		private ToolStripSeparator toolStripSeparator_3;

		private ToolStripMenuItem toolStripMenuItem_8;

		private ToolStripMenuItem toolStripMenuItem_9;

		private DataGridViewImageColumn dataGridViewImageColumn_2;

		private DataGridViewImageColumn dataGridViewImageColumn_3;

		private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn_1;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_5;

		private DataGridViewImageColumnNotNull dataGridViewImageColumnNotNull_1;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_6;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_7;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_1;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_8;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_9;

		private Class255 class255_1;

		private TabPage tabPage_5;

		private TableLayoutPanel tableLayoutPanel_2;

		private System.Windows.Forms.Panel panel_0;

		private DataGridView dataGridView_0;

		private System.Windows.Forms.TextBox textBox_16;

		private System.Windows.Forms.TextBox textBox_17;

		private System.Windows.Forms.ComboBox comboBox_1;

		private BindingSource bindingSource_1;

		private System.Windows.Forms.Label label_32;

		private System.Windows.Forms.Label label_33;

		private System.Windows.Forms.Label label_34;

		private System.Windows.Forms.Label label_35;

		private System.Windows.Forms.Label label_36;

		private BindingSource bindingSource_2;

		private BindingSource bindingSource_3;

		private System.Windows.Forms.TextBox textBox_18;

		private System.Windows.Forms.Label label_37;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_10;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_11;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_12;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_13;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_14;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_15;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_16;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_17;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_18;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_19;

		private DataGridViewTextBoxColumn qXfByJsXia;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_20;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_21;

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

		private TableLayoutPanel tableLayoutPanel_3;

		private TableLayoutPanel tableLayoutPanel_4;

		private TableLayoutPanel tableLayoutPanel_5;

		private TableLayoutPanel tableLayoutPanel_6;

		private TableLayoutPanel tableLayoutPanel_7;

		private PictureBox pictureBox_0;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_34;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_35;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_36;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_37;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_38;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_39;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_40;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_41;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_42;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_43;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_44;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_45;

		private DataGridViewTextBoxColumn dvuBbFynsI;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_46;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_47;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_48;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_49;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_50;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_51;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_52;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_53;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_54;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_55;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_56;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_57;

		private TabPage tabPage_6;

		private ToolStrip toolStrip_2;

		private ToolStripButton toolStripButton_9;

		private ToolStripButton toolStripButton_10;

		private ToolStripButton toolStripButton_11;

		private ToolStripSeparator toolStripSeparator_4;

		private ToolStripButton toolStripButton_12;

		private ToolStripButton toolStripButton_13;

		private DataGridView dataGridView_1;

		private Class10 class10_0;

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

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_68;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_69;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_70;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_71;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_72;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_73;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_74;

		private System.Windows.Forms.Label label_38;

		private System.Windows.Forms.TextBox textBox_19;

		private System.Windows.Forms.Label label_39;

		private ComboBoxReadOnly comboBoxReadOnly_0;

		private System.Windows.Forms.Button button_4;

		private System.Windows.Forms.Panel panel_1;

		private System.Windows.Forms.Label label_40;

		private System.Windows.Forms.Label label_41;

		private DateTimePicker dateTimePicker_1;

		private System.Windows.Forms.TextBox textBox_20;

		private System.Windows.Forms.Label label_42;

		private System.Windows.Forms.TextBox textBox_21;
	}
}
