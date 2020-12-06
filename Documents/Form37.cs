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
using System.Net;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Constants;
using DataSql;
using Documents.Properties;
using FormLbr;
using FormLbr.Classes;

internal partial class Form37 : FormBase
{
	[CompilerGenerated]
	internal int method_0()
	{
		return this.nuJobVrqPl0;
	}

	[CompilerGenerated]
	internal void method_1(int int_2)
	{
		this.nuJobVrqPl0 = int_2;
	}

	internal int idUser { get; set; }

	[CompilerGenerated]
	internal int method_2()
	{
		return this.int_1;
	}

	[CompilerGenerated]
	internal void method_3(int int_2)
	{
		this.int_1 = int_2;
	}

	internal string UniversalID { get; set; }

	[CompilerGenerated]
	internal StateFormCreate method_4()
	{
		return this.stateFormCreate_0;
	}

	[CompilerGenerated]
	internal void method_5(StateFormCreate stateFormCreate_1)
	{
		this.stateFormCreate_0 = stateFormCreate_1;
	}

	public Form37()
	{
		
		this.enum26_0 = (Enum26)1302;
		this.string_1 = "192.168.1.253";
		this.uMvobSoyZvu = Environment.GetFolderPath(Environment.SpecialFolder.Templates) + "\\LotusTemp\\";
		
		this.method_29();
	}

	private EISSettings method_6()
	{
		AppConfig appConfig = new AppConfig();
		this.pJbobrNgebT = appConfig.OpenAppConfig();
		if (this.pJbobrNgebT.FrmTUSettings == null)
		{
			FormTUSettings formTUSettings = new FormTUSettings();
			formTUSettings.IsSavePassport = false;
			formTUSettings.Password = "";
			this.pJbobrNgebT.FrmTUSettings = formTUSettings;
			appConfig.SaveAppConfig(this.pJbobrNgebT);
		}
		return this.pJbobrNgebT;
	}

	private Class603 method_7()
	{
		Class603 @class;
		try
		{
			this.pJbobrNgebT = this.method_6();
			if (!this.pJbobrNgebT.FrmTUSettings.IsSavePassport || this.pJbobrNgebT.FrmTUSettings.Password == "")
			{
				Form36 form = new Form36();
				form.SqlSettings = this.SqlSettings;
				form.method_1(this.pJbobrNgebT.FrmTUSettings.IsSavePassport);
				form.Password = this.pJbobrNgebT.FrmTUSettings.Password;
				if (form.ShowDialog() != DialogResult.OK)
				{
					return null;
				}
				this.pJbobrNgebT.FrmTUSettings.IsSavePassport = form.method_0();
				this.pJbobrNgebT.FrmTUSettings.Password = form.Password;
				new AppConfig().SaveAppConfig(this.pJbobrNgebT);
			}
			@class = new Class603(this.pJbobrNgebT.FrmTUSettings.Password);
			this.class606_0 = @class.method_2();
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return null;
		}
		return @class;
	}

	private void method_8()
	{
		StateFormCreate stateFormCreate = this.method_4();
		if (stateFormCreate != StateFormCreate.Add)
		{
			if (stateFormCreate != StateFormCreate.Edit)
			{
				if (stateFormCreate == StateFormCreate.View)
				{
					this.dataGridView_1.AllowUserToAddRows = false;
					this.dataGridView_0.AllowUserToAddRows = false;
					this.MfmowWfuJrX.AllowUserToAddRows = false;
					this.dataGridView_1.ReadOnly = true;
					this.dataGridView_0.ReadOnly = true;
					this.MfmowWfuJrX.ReadOnly = true;
					this.button_2.Visible = false;
					this.button_0.Visible = false;
					this.toolStripButton_7.Enabled = false;
					this.toolStripButton_5.Enabled = false;
					this.toolStripButton_0.Enabled = false;
					this.toolStripButton_1.Enabled = false;
				}
			}
			else
			{
				this.dataGridView_1.AllowUserToAddRows = true;
				this.dataGridView_0.AllowUserToAddRows = true;
				this.MfmowWfuJrX.AllowUserToAddRows = true;
				this.dataGridView_1.AllowUserToDeleteRows = true;
				this.dataGridView_0.AllowUserToDeleteRows = true;
				this.MfmowWfuJrX.AllowUserToDeleteRows = true;
				this.dataGridView_1.ReadOnly = false;
				this.dataGridView_0.ReadOnly = false;
				this.MfmowWfuJrX.ReadOnly = false;
				this.button_2.Visible = true;
				this.button_0.Visible = true;
				this.toolStripButton_7.Enabled = true;
				this.toolStripButton_5.Enabled = true;
				this.toolStripButton_0.Enabled = true;
				this.toolStripButton_1.Enabled = true;
			}
		}
		else
		{
			this.tabPage_3.Parent = null;
			this.dataGridView_1.AllowUserToDeleteRows = true;
			this.dataGridView_0.AllowUserToDeleteRows = true;
			this.MfmowWfuJrX.AllowUserToDeleteRows = true;
		}
		if (!Directory.Exists(this.uMvobSoyZvu))
		{
			Directory.CreateDirectory(this.uMvobSoyZvu);
		}
		base.SelectSqlData(this.class255_0, this.class255_0.vJ_BossUser, true);
		if (this.method_4() == StateFormCreate.View || this.method_4() == StateFormCreate.Edit)
		{
			base.SelectSqlData(this.class255_0, this.class255_0.tJ_Memorandum, true, "WHERE id = " + this.method_2().ToString() + " AND Deleted = ((0))");
			base.SelectSqlData(this.class255_0, this.class255_0.tJ_MemWorker, true, "WHERE idMemorandum = " + this.method_2().ToString() + " AND Deleted = ((0))");
			base.SelectSqlData(this.class255_0, this.class255_0.tJ_MemCommission, true, "WHERE idMemorandum = " + this.method_2().ToString() + " AND Deleted = ((0))");
			base.SelectSqlData(this.class255_0, this.class255_0.vJ_MemCommission, true, "WHERE idMemorandum = " + this.method_2().ToString() + " AND Deleted = ((0))");
			this.method_13();
			this.UniversalID = ((this.class255_0.tJ_Memorandum.First<Class255.Class462>()["UniversalID"] != DBNull.Value) ? this.class255_0.tJ_Memorandum.First<Class255.Class462>().UniversalID : "");
		}
		base.SelectSqlData(this.class255_0, this.class255_0.vJ_BossUser, true, "");
		this.class255_0.tJ_MemWorker.TableNewRow += this.method_9;
		if (this.method_4() == StateFormCreate.Edit && !string.IsNullOrEmpty(this.UniversalID))
		{
			this.backgroundWorker_0.RunWorkerAsync(this.UniversalID);
		}
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		base.Close();
	}

	private void button_2_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.OK;
		base.Close();
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.OK;
		this.enum26_0 = (Enum26)1303;
		base.Close();
	}

	private void Form37_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (base.DialogResult == DialogResult.OK)
		{
			try
			{
				if (!this.method_12())
				{
					base.DialogResult = DialogResult.Cancel;
					e.Cancel = true;
				}
			}
			catch (Exception)
			{
				base.DialogResult = DialogResult.Cancel;
				e.Cancel = true;
			}
		}
	}

	private void Form37_Load(object sender, EventArgs e)
	{
		this.method_8();
	}

	private void method_9(object sender, DataTableNewRowEventArgs e)
	{
		e.Row["idMemorandum"] = -1;
		e.Row["Deleted"] = false;
		e.Row["typeWorker"] = ((this.tabControl_0.SelectedTab == this.tabPage_0) ? 1297 : ((this.tabControl_0.SelectedTab == this.tabPage_1) ? 1298 : ((this.tabControl_0.SelectedTab == this.ggJowlBkuPL) ? 1300 : -1)));
	}

	private void method_10()
	{
		base.SelectSqlData(this.class255_0, this.class255_0.tJ_Memorandum, true, string.Format("WHERE id = {0} AND Deleted = ((0))", this.method_2()));
		base.SelectSqlData(this.class255_0, this.class255_0.tJ_MemCommission, true, string.Format("WHERE idMemorandum = {0} AND Deleted = ((0))", this.method_2()));
		this.method_13();
	}

	private string method_11(int int_2)
	{
		int idBoss = (from r in this.class255_0.tJ_MemWorker
		where r.idMemorandum == int_2 && r.typeWorker == 1299
		select r).First<Class255.Class464>().idWorker;
		return (from r in this.class255_0.vJ_BossUser
		where r.Id == idBoss
		select r).First<Class255.Class460>().FIO;
	}

	private bool method_12()
	{
		int num = 1;
		bool result;
		try
		{
			EnumerableRowCollection<Class255.Class460> source = this.class255_0.vJ_BossUser.Where(new Func<Class255.Class460, bool>(this.method_30));
			if (source.Count<Class255.Class460>() == 0)
			{
				MessageBox.Show("Не выбраны адресаты.", "Предупреждение.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				result = false;
			}
			else
			{
				string[] array = (from r2 in source
				select string.Concat(new string[]
				{
					r2.FirstName,
					" ",
					r2.LastName,
					" ",
					r2.MiddleInitial
				})).ToArray<string>();
				EnumerableRowCollection<Class255.Class460> source2 = this.class255_0.vJ_BossUser.Where(new Func<Class255.Class460, bool>(this.method_31));
				if (source2.Count<Class255.Class460>() == 0)
				{
					MessageBox.Show("Не выбраны подписанты.", "Предупреждение.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					result = false;
				}
				else
				{
					string text = (from r2 in source2
					select string.Concat(new string[]
					{
						r2.FirstName,
						" ",
						r2.LastName,
						" ",
						r2.MiddleInitial
					})).First<string>();
					EnumerableRowCollection<Class255.Class460> source3 = this.class255_0.vJ_BossUser.Where(new Func<Class255.Class460, bool>(this.method_32));
					if (source3.Count<Class255.Class460>() == 0)
					{
						MessageBox.Show("Не выбраны визирующие.", "Предупреждение.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						result = false;
					}
					else
					{
						string[] array2 = (from r2 in source3
						select string.Concat(new string[]
						{
							r2.FirstName,
							" ",
							r2.LastName,
							" ",
							r2.MiddleInitial
						})).ToArray<string>();
						Class603 @class = this.method_7();
						bool flag = false;
						if (@class != null)
						{
							MessageBox.Show((num + 1).ToString());
							StateFormCreate stateFormCreate = this.method_4();
							if (stateFormCreate != StateFormCreate.Add)
							{
								if (stateFormCreate != StateFormCreate.Edit)
								{
									return false;
								}
								flag = @class.method_6(this.UniversalID, "Служебная записка (ТП)", this.textBox_0.Text, this.textBox_1.Text, this.enum26_0, array, text, array2, this.list_0);
								this.UniversalID = @class.UNID;
							}
							else
							{
								flag = @class.method_5("Служебная записка (ТП)", this.textBox_0.Text, this.textBox_1.Text, this.enum26_0, array, text, array2, this.list_0);
								this.UniversalID = @class.UNID;
							}
						}
						MessageBox.Show("Saving lotus");
						if (flag)
						{
							if (this.method_4() == StateFormCreate.Add)
							{
								Class255.Class462 class2 = this.class255_0.tJ_Memorandum.method_5();
								class2.idTehConnect = this.method_0();
								class2.idWorker = this.idUser;
								class2.Status = (int)this.enum26_0;
								class2.Subject = this.textBox_0.Text;
								class2.Body_C = this.textBox_1.Text;
								class2.ctbDateCreate = DateTime.Now;
								if (@class != null)
								{
									class2.UniversalID = @class.UNID;
								}
								class2.Deleted = false;
								class2.EndEdit();
								this.method_3(base.InsertSqlDataOneRow(class2));
								if (this.method_2() != -1)
								{
									foreach (Class255.Class464 class3 in this.class255_0.tJ_MemWorker)
									{
										class3.idMemorandum = this.method_2();
										class3.EndEdit();
									}
									base.InsertSqlData(this.class255_0.tJ_MemWorker);
									foreach (Class255.Class461 class4 in this.class255_0.tJ_MemFiles)
									{
										class4.idDocument = this.method_2();
										class4.TypeDoc = 1;
										class4.EndEdit();
									}
									base.InsertSqlData(this.class255_0.tJ_MemFiles);
								}
							}
							else
							{
								this.class255_0.tJ_Memorandum.First<Class255.Class462>().EndEdit();
								base.UpdateSqlData(this.class255_0.tJ_Memorandum);
								foreach (Class255.Class461 class5 in this.class255_0.tJ_MemFiles)
								{
									class5.EndEdit();
								}
								base.UpdateSqlData(this.class255_0.tJ_MemFiles);
								base.DeleteSqlData(this.class255_0.tJ_MemFiles);
								foreach (Class255.Class464 class6 in this.class255_0.tJ_MemWorker)
								{
									class6.EndEdit();
								}
								base.UpdateSqlData(this.class255_0.tJ_MemWorker);
								base.DeleteSqlData(this.class255_0.tJ_MemWorker);
							}
						}
						result = true;
					}
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.ToString());
			result = false;
		}
		return result;
	}

	private void toolStripButton_0_Click(object sender, EventArgs e)
	{
		if (this.openFileDialog_0.ShowDialog() == DialogResult.OK)
		{
			if (this.list_0 == null)
			{
				this.list_0 = new List<string>();
			}
			foreach (string text in this.openFileDialog_0.FileNames)
			{
				if (!this.list_0.Contains(text))
				{
					this.list_0.Add(text);
				}
				FileBinary fileBinary = new FileBinary(text);
				Class255.Class461 @class = this.class255_0.tJ_MemFiles.method_5();
				@class.Deleted = false;
				@class.File = fileBinary.ByteArray;
				@class.idDocument = -1;
				@class.Name = fileBinary.Name;
				@class.Size = fileBinary.KbSize;
				@class.TypeDoc = 1;
				@class.LastChange = fileBinary.LastChanged;
				@class.EndEdit();
				this.class255_0.tJ_MemFiles.method_0(@class);
			}
		}
	}

	private void toolStripButton_1_Click(object sender, EventArgs e)
	{
		if (this.bindingSource_5.Current != null && MessageBox.Show("Вы действительно хотите удалить выбранный файл?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
		{
			((Class255.Class461)((DataRowView)this.bindingSource_5.Current).Row).Delete();
		}
	}

	private void toolStripButton_4_Click(object sender, EventArgs e)
	{
		this.method_14(this.bindingSource_5, this.uMvobSoyZvu);
	}

	private void toolStripButton_2_Click(object sender, EventArgs e)
	{
		this.method_13();
	}

	private void method_13()
	{
		using (SqlConnection sqlConnection = new SqlConnection(this.SqlSettings.GetConnectionString()))
		{
			string str = string.Format("WHERE (TypeDoc = 1 AND idDocument = {0})", this.method_2()) + ((this.bindingSource_6.Current != null) ? string.Format(" OR (TypeDoc = 2 AND idDocument = {0})", (int)((DataRowView)this.bindingSource_6.Current)["id"]) : "");
			sqlConnection.Open();
			new SqlDataAdapter(new SqlCommand("SELECT [id],[idDocument],[TypeDoc],[Name],[Size],[LastChange],[Deleted] FROM tJ_MemFiles " + str, sqlConnection)).Fill(this.class255_0.tJ_MemFiles);
		}
	}

	private void toolStripButton_5_Click(object sender, EventArgs e)
	{
		if (this.openFileDialog_0.ShowDialog() == DialogResult.OK)
		{
			string[] fileNames = this.openFileDialog_0.FileNames;
			for (int i = 0; i < fileNames.Length; i++)
			{
				FileBinary fileBinary = new FileBinary(fileNames[i]);
				Class255.Class461 @class = this.class255_0.tJ_MemFiles.method_5();
				@class.Deleted = false;
				@class.File = fileBinary.ByteArray;
				@class.idDocument = -1;
				@class.Name = fileBinary.Name;
				@class.Size = fileBinary.KbSize;
				@class.TypeDoc = 2;
				@class.LastChange = fileBinary.LastChanged;
				@class.EndEdit();
				this.class255_0.tJ_MemFiles.method_0(@class);
			}
		}
	}

	private void toolStripButton_6_Click(object sender, EventArgs e)
	{
		this.method_14(this.bindingSource_7, this.uMvobSoyZvu);
	}

	private void method_14(BindingSource bindingSource_12, string string_2)
	{
		if (bindingSource_12.Current != null)
		{
			Class255.Class461 @class = (Class255.Class461)((DataRowView)bindingSource_12.Current).Row;
			string name = @class.Name;
			string newFileNameIsExists = FileBinary.GetNewFileNameIsExists(string_2, name, false);
			if (@class["LastChange"] != DBNull.Value)
			{
				DateTime lastChange = @class.LastChange;
			}
			else
			{
				DateTime now = DateTime.Now;
			}
			if (@class["File"] == DBNull.Value)
			{
				try
				{
					using (SqlConnection sqlConnection = new SqlConnection(this.SqlSettings.GetConnectionString()))
					{
						sqlConnection.Open();
						SqlDataReader sqlDataReader = new SqlCommand("SELECT [File] FROM tJ_MemFiles WHERE id = " + @class["id"].ToString(), sqlConnection).ExecuteReader();
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
			fileBinary.SaveToDisk(string_2);
			Process.Start(string_2 + "\\" + fileBinary.Name);
		}
	}

	private void KmnoeqvguoO(object sender, EventArgs e)
	{
		if (this.bindingSource_5.Current != null && MessageBox.Show("Вы действительно хотите удалить выбранный файл?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
		{
			((Class255.Class461)((DataRowView)this.bindingSource_5.Current).Row).Delete();
		}
	}

	private void toolStripButton_8_Click(object sender, EventArgs e)
	{
		this.method_13();
	}

	private void method_15(string string_2)
	{
		Class603 @class = this.method_7();
		if (string.IsNullOrEmpty(string_2) && @class != null)
		{
			this.class605_0 = @class.uybCtvHfSxo(string_2, true).First<Class605>();
			if (this.label_4.InvokeRequired)
			{
				Dispatcher.Invoke(this, new AsyncAction(this.method_33));
			}
			else
			{
				this.label_4.Text = this.class605_0.SignDate + "/" + this.class605_0.RgNum;
			}
			this.method_18(this.class605_0);
			this.method_20(this.class605_0.rrwCvexvfrc(), (Enum24)1, this.method_2());
			this.method_19(string_2, @class.uubCttfhrkq(string_2, true), -1);
		}
	}

	private int method_16(string string_2)
	{
		DataTable dataTable = base.SelectSqlData("tR_Classifier", true, "WHERE ParentKey = ';TechConnect;StatusMemorandum;' AND [Comment] LIKE '" + string_2 + "' AND Deleted = 0");
		if (dataTable.Rows.Count > 0)
		{
			return (int)dataTable.Rows[0]["Id"];
		}
		return -1;
	}

	private string method_17(string string_2)
	{
		if (string.IsNullOrEmpty(string_2) && string_2.Length < 10)
		{
			return null;
		}
		string[] array = string_2.Substring(0, 10).Split(new char[]
		{
			'.'
		});
		if (array.Count<string>() != 3)
		{
			return null;
		}
		return string.Concat(new string[]
		{
			array[1],
			"/",
			array[0],
			"/",
			array[2]
		});
	}

	private void method_18(Class605 class605_1)
	{
		string text = string.Format("update tJ_Memorandum set UniversalID = '{0}'", class605_1.UniversalID);
		if (class605_1.RespDate.Length >= 10)
		{
			text += string.Format(",[RespDate] = CONVERT(SMALLDATETIME,'{0}',101)", this.method_17(class605_1.RespDate));
		}
		if (class605_1.Status != "")
		{
			text += string.Format(",[Status] = '{0}'", this.method_16(class605_1.Status));
		}
		if (class605_1.Subject != "")
		{
			text += string.Format(",[Subject] = '{0}'", class605_1.Subject);
		}
		if (class605_1.Body_C != "")
		{
			text += string.Format(",[Body_C] = '{0}'", class605_1.Body_C);
		}
		if (class605_1.SignDate.Length >= 10)
		{
			text += string.Format(",[SignDate] = CONVERT(SMALLDATETIME,'{0}',101)", this.method_17(class605_1.SignDate));
		}
		if (class605_1.RgNum != "")
		{
			text += string.Format(",[RgNum] = '{0}'", class605_1.RgNum);
		}
		if (class605_1.RespNum != "")
		{
			text += string.Format(",[RespNum] = '{0}'", class605_1.RespNum);
		}
		if (class605_1.CorrName != "")
		{
			text += string.Format(",[CorrName] = '{0}'", class605_1.CorrName);
		}
		text += string.Format(" WHERE UniversalID = '{0}'", class605_1.UniversalID);
		this.method_21(this.SqlSettings, text);
	}

	private void method_19(string string_2, List<Class604> list_1, int int_2)
	{
		Func<Class255.Class467, bool> <>9__0;
		foreach (Class604 @class in list_1)
		{
			TypedTableBase<Class255.Class467> tJ_MemCommission = this.class255_0.tJ_MemCommission;
			Func<Class255.Class467, bool> predicate;
			if ((predicate = <>9__0) == null)
			{
				predicate = (<>9__0 = ((Class255.Class467 r) => r.UNID == string_2));
			}
			int int_3;
			if (tJ_MemCommission.Where(predicate).Count<Class255.Class467>() > 0)
			{
				string text = string.Format("update tJ_MemCommission set UniversalID = '{0}'", @class.UniversalID);
				if (@class.ctbSubject != "")
				{
					text += string.Format(",[Subject] = '{0}'", @class.ctbSubject);
				}
				if (@class.Body != "")
				{
					text += string.Format(",[Body] = '{0}'", @class.Body);
				}
				if (@class.ctbDateFact.Length >= 10)
				{
					text += string.Format(",[DateFact] = CONVERT(SMALLDATETIME,'{0}',101)", this.method_17(@class.ctbDateFact));
				}
				if (@class.ctbComment != "")
				{
					text += string.Format(",[Comment] = '{0}'", @class.ctbComment);
				}
				if (@class.ctbExecutor != "")
				{
					text += string.Format(",[Performer] = '{0}'", this.xuuobnpbypF(@class.ctbExecutor));
				}
				if (@class.ctbStatus != "")
				{
					text += string.Format(",[Status] = '{0}'", this.method_25(@class));
				}
				text += string.Format(" WHERE UNID = '{0}'", @class.UniversalID);
				int_3 = (int)base.SelectSqlData("tJ_MemCommission", true, string.Format(" WHERE UNID = '{0}'", @class.UniversalID)).Rows[0]["id"];
				this.method_21(this.SqlSettings, text);
			}
			else
			{
				string text2 = "idMemorandum, UNID, Deleted,Comment";
				string text3 = string.Format("{0},'{1}', 0, {2}", this.method_2(), @class.UniversalID, @class.ctbComment);
				if (@class.ctbDateFact.Length >= 10)
				{
					text2 += ",[RespDate]";
					text3 += string.Format(",CONVERT(SMALLDATETIME,'{0}',101)", @class.ctbDateFact);
				}
				if (@class.ctbExecutor != "")
				{
					text2 += ",[Performer]";
					text3 += string.Format(",{0}", this.xuuobnpbypF(@class.ctbExecutor));
				}
				if (@class.ctbStatus != "")
				{
					text2 += ",[Status]";
					text3 += string.Format(",{0}", this.method_25(@class));
				}
				string string_3 = string.Format("insert into tJ_MemCommission ({0}) values ({1})", text2, text3);
				int_3 = this.method_22(string_3, "tJ_MemCommission");
			}
			this.method_20(@class.method_0(), (Enum24)2, int_3);
		}
	}

	private void method_20(List<Class607> list_1, Enum24 enum24_0, int int_2)
	{
		using (List<Class607>.Enumerator enumerator = list_1.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				Class607 file = enumerator.Current;
				EnumerableRowCollection<Class255.Class461> source = from r in this.class255_0.tJ_MemFiles
				where r.TypeDoc == (int)enum24_0 && r.idDocument == int_2 && r.Name == file.Name
				select r;
				if (source.Count<Class255.Class461>() > 0)
				{
					Class255.Class461 @class = source.First<Class255.Class461>();
					@class.Deleted = false;
					@class.File = file.method_6();
					@class.idDocument = int_2;
					@class.LastChange = file.method_4();
					@class.Name = file.Name;
					@class.TypeDoc = (int)enum24_0;
					base.UpdateSqlData(this.class255_0.tJ_MemFiles);
				}
				else
				{
					Class255.Class461 class2 = this.class255_0.tJ_MemFiles.method_5();
					class2.Deleted = false;
					class2.File = file.method_6();
					class2.idDocument = int_2;
					class2.LastChange = file.method_4();
					class2.Name = file.Name;
					class2.TypeDoc = (int)enum24_0;
					base.InsertSqlDataOneRow(class2);
				}
			}
		}
	}

	private void method_21(SQLSettings sqlsettings_0, string string_2)
	{
		SqlDataConnect sqlDataConnect = new SqlDataConnect();
		try
		{
			sqlDataConnect.OpenConnection(sqlsettings_0);
			new SqlCommand(string_2, sqlDataConnect.Connection).ExecuteNonQuery();
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, ex.Source);
		}
		finally
		{
			sqlDataConnect.CloseConnection();
		}
	}

	private int method_22(string string_2, string string_3)
	{
		SqlDataConnect sqlDataConnect = new SqlDataConnect();
		int result = -1;
		try
		{
			sqlDataConnect.OpenConnection(this.SqlSettings);
			SqlTransaction sqlTransaction = sqlDataConnect.Connection.BeginTransaction();
			SqlCommand sqlCommand = new SqlCommand(string_2, sqlDataConnect.Connection);
			sqlCommand.Transaction = sqlTransaction;
			sqlCommand.ExecuteNonQuery();
			sqlCommand.CommandText = "select IDENT_CURRENT('" + string_3 + "')";
			result = Convert.ToInt32(sqlCommand.ExecuteScalar());
			sqlTransaction.Commit();
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, ex.Source);
		}
		finally
		{
			sqlDataConnect.CloseConnection();
		}
		return result;
	}

	private int xuuobnpbypF(string string_2)
	{
		DataTable dataTable = base.SelectSqlData("tJ_BossUser", true, "WHERE F + ' ' + I + ' ' + O LIKE '" + string_2 + "'");
		if (dataTable.Rows.Count > 0)
		{
			return (int)dataTable.Rows[0]["ID"];
		}
		return -1;
	}

	private string method_23(int int_2)
	{
		DataTable dataTable = base.SelectSqlData("tJ_BossUser", true, "WHERE id = " + int_2.ToString() + "'");
		if (dataTable.Rows.Count > 0)
		{
			return dataTable.Rows[0]["mail"].ToString();
		}
		return "";
	}

	private void method_24(int int_2, out string string_2, out string string_3)
	{
		string_2 = "";
		string_3 = "";
		DataTable dataTable = base.SelectSqlData("tJ_BossUser", true, "WHERE id = " + int_2.ToString() + "'");
		if (dataTable.Rows.Count > 0)
		{
			string_2 = ((dataTable.Rows[0]["mail"] != DBNull.Value) ? dataTable.Rows[0]["mail"].ToString() : "");
			string_3 = ((dataTable.Rows[0]["password"] != DBNull.Value) ? dataTable.Rows[0]["password"].ToString() : "");
		}
	}

	private int method_25(Class604 class604_0)
	{
		DataTable dataTable = base.SelectSqlData("tR_Classifier", true, "WHERE ParentKey = ';TechConnect;Commission;' AND [Comment] LIKE '" + class604_0.Header_Title + "' AND Deleted = 0");
		if (dataTable.Rows.Count > 0)
		{
			return (int)dataTable.Rows[0]["Id"];
		}
		return -1;
	}

	private void bindingSource_6_CurrentChanged(object sender, EventArgs e)
	{
		this.method_13();
	}

	private void backgroundWorker_0_DoWork(object sender, DoWorkEventArgs e)
	{
		this.method_26(true);
		string string_ = e.Argument.ToString();
		this.method_15(string_);
	}

	private void backgroundWorker_0_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		this.method_26(false);
		this.method_10();
		this.method_13();
	}

	private void tableLayoutPanel_1_TabIndexChanged(object sender, EventArgs e)
	{
		this.method_13();
	}

	private void method_26(bool bool_0)
	{
		if (this.progressBar_0.InvokeRequired)
		{
			Dispatcher.Invoke(this, delegate
			{
				this.progressBar_0.Style = (bool_0 ? ProgressBarStyle.Marquee : ProgressBarStyle.Blocks);
			});
			return;
		}
		this.progressBar_0.Style = (bool_0 ? ProgressBarStyle.Marquee : ProgressBarStyle.Blocks);
	}

	private void MfmowWfuJrX_DataError(object sender, DataGridViewDataErrorEventArgs e)
	{
	}

	private void button_3_Click(object sender, EventArgs e)
	{
		this.method_27();
	}

	private void method_27()
	{
		if (this.class255_0.tJ_MemCommission.Rows.Count == 0)
		{
			return;
		}
		foreach (object obj in ((IEnumerable)this.dataGridView_5.Rows))
		{
			DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
			if (dataGridViewRow.Cells["Send"].Value != null && dataGridViewRow.Cells["Send"].Value != DBNull.Value)
			{
				foreach (Class255.Class467 @class in this.class255_0.tJ_MemCommission)
				{
					string text = "";
					string text2 = "";
					string text3 = (@class["Subject"] != DBNull.Value) ? @class["Subject"].ToString() : "";
					string text4 = (@class["Body"] != DBNull.Value) ? @class["Body"].ToString() : "";
					if (string.IsNullOrEmpty(this.class606_0.FIO))
					{
						this.method_7();
					}
					int int_ = this.xuuobnpbypF(this.class606_0.FIO);
					this.method_24(int_, out text, out text2);
					if (string.IsNullOrEmpty(text))
					{
						MessageBox.Show("Отсутствует адрес электронного почтового ящика в справочнике пользователей.", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						return;
					}
					if (string.IsNullOrEmpty(text2))
					{
						MessageBox.Show("Отсутствует пароль к адресу почтового ящика в справочнике пользователей.", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						return;
					}
					if (string.IsNullOrEmpty(text3) && string.IsNullOrEmpty(text4))
					{
						MessageBox.Show("Отсутствуют заголовок и текст письма.", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						return;
					}
					string string_ = this.method_23((int)dataGridViewRow.Cells["Send"].Value);
					this.method_28(this.string_1, text, text2, string_, text3, text4, null);
				}
			}
		}
	}

	private void method_28(string string_2, string string_3, string string_4, string string_5, string string_6, string string_7, string string_8 = null)
	{
		try
		{
			MailMessage mailMessage = new MailMessage();
			mailMessage.From = new MailAddress(string_3);
			mailMessage.To.Add(new MailAddress(string_5));
			mailMessage.Subject = string_6;
			mailMessage.Body = string_7;
			if (!string.IsNullOrEmpty(string_8))
			{
				mailMessage.Attachments.Add(new Attachment(string_8));
			}
			new SmtpClient
			{
				Host = string_2,
				Port = 25,
				EnableSsl = true,
				Credentials = new NetworkCredential(string_3.Split(new char[]
				{
					'@'
				})[0], string_4),
				DeliveryMethod = SmtpDeliveryMethod.Network
			}.Send(mailMessage);
			mailMessage.Dispose();
		}
		catch (Exception ex)
		{
			throw new Exception("Mail.Send: " + ex.Message);
		}
	}

	private void likobppyWqA(object sender, EventArgs e)
	{
		if (this.method_4() == StateFormCreate.Edit && !string.IsNullOrEmpty(this.UniversalID))
		{
			this.backgroundWorker_0.RunWorkerAsync(this.UniversalID);
		}
	}

	private void dataGridView_3_DataError(object sender, DataGridViewDataErrorEventArgs e)
	{
	}

	private void dataGridView_5_CellContentClick(object sender, DataGridViewCellEventArgs e)
	{
	}

	private void bindingSource_11_AddingNew(object sender, AddingNewEventArgs e)
	{
		if (e.NewObject != null)
		{
			((DataRowView)e.NewObject)["idWorker"] = -1;
		}
	}

	private void method_29()
	{
		this.icontainer_0 = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
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
		DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
		this.label_0 = new Label();
		this.textBox_0 = new TextBox();
		this.bindingSource_4 = new BindingSource(this.icontainer_0);
		this.class255_0 = new Class255();
		this.label_1 = new Label();
		this.textBox_1 = new TextBox();
		this.tabControl_0 = new TabControl();
		this.tabPage_0 = new TabPage();
		this.dataGridView_0 = new DataGridView();
		this.dataGridViewComboBoxColumn_0 = new DataGridViewComboBoxColumn();
		this.bindingSource_0 = new BindingSource(this.icontainer_0);
		this.dataGridViewCheckBoxColumn_0 = new DataGridViewCheckBoxColumn();
		this.dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
		this.bindingSource_1 = new BindingSource(this.icontainer_0);
		this.ggJowlBkuPL = new TabPage();
		this.dataGridView_1 = new DataGridView();
		this.dataGridViewComboBoxColumn_2 = new DataGridViewComboBoxColumn();
		this.bindingSource_8 = new BindingSource(this.icontainer_0);
		this.dataGridViewCheckBoxColumn_2 = new DataGridViewCheckBoxColumn();
		this.dataGridViewTextBoxColumn_26 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_27 = new DataGridViewTextBoxColumn();
		this.cpfoGteKiSP = new DataGridViewTextBoxColumn();
		this.bindingSource_2 = new BindingSource(this.icontainer_0);
		this.tabPage_1 = new TabPage();
		this.MfmowWfuJrX = new DataGridView();
		this.dataGridViewComboBoxColumn_3 = new DataGridViewComboBoxColumn();
		this.bindingSource_9 = new BindingSource(this.icontainer_0);
		this.dataGridViewCheckBoxColumn_3 = new DataGridViewCheckBoxColumn();
		this.dataGridViewTextBoxColumn_28 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_29 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_30 = new DataGridViewTextBoxColumn();
		this.bindingSource_3 = new BindingSource(this.icontainer_0);
		this.tabPage_4 = new TabPage();
		this.tableLayoutPanel_3 = new TableLayoutPanel();
		this.button_3 = new Button();
		this.dataGridView_5 = new DataGridView();
		this.dataGridViewComboBoxColumn_4 = new DataGridViewComboBoxColumn();
		this.bindingSource_10 = new BindingSource(this.icontainer_0);
		this.bindingSource_11 = new BindingSource(this.icontainer_0);
		this.button_0 = new Button();
		this.button_1 = new Button();
		this.tabControl_1 = new TabControl();
		this.tabPage_2 = new TabPage();
		this.tableLayoutPanel_0 = new TableLayoutPanel();
		this.toolStrip_0 = new ToolStrip();
		this.toolStripButton_0 = new ToolStripButton();
		this.toolStripButton_4 = new ToolStripButton();
		this.toolStripSeparator_0 = new ToolStripSeparator();
		this.toolStripButton_1 = new ToolStripButton();
		this.toolStripButton_2 = new ToolStripButton();
		this.dataGridView_2 = new DataGridView();
		this.dataGridViewTextBoxColumn_12 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_13 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_14 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_15 = new DataGridViewTextBoxColumn();
		this.bindingSource_5 = new BindingSource(this.icontainer_0);
		this.label_2 = new Label();
		this.label_3 = new Label();
		this.PeVowpgDlnO = new Label();
		this.label_4 = new Label();
		this.tabPage_3 = new TabPage();
		this.tableLayoutPanel_2 = new TableLayoutPanel();
		this.dataGridView_4 = new DataGridView();
		this.dataGridViewTextBoxColumn_16 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_17 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_18 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_19 = new DataGridViewTextBoxColumn();
		this.bindingSource_7 = new BindingSource(this.icontainer_0);
		this.toolStrip_1 = new ToolStrip();
		this.toolStripButton_5 = new ToolStripButton();
		this.toolStripButton_6 = new ToolStripButton();
		this.toolStripSeparator_1 = new ToolStripSeparator();
		this.toolStripButton_7 = new ToolStripButton();
		this.toolStripButton_8 = new ToolStripButton();
		this.dataGridView_3 = new DataGridView();
		this.dataGridViewTextBoxColumn_20 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_21 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_22 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_23 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_24 = new DataGridViewTextBoxColumn();
		this.oEdoGsvuknR = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_25 = new DataGridViewTextBoxColumn();
		this.dataGridViewComboBoxColumn_1 = new DataGridViewComboBoxColumn();
		this.dataGridViewCheckBoxColumn_1 = new DataGridViewCheckBoxColumn();
		this.bindingSource_6 = new BindingSource(this.icontainer_0);
		this.tableLayoutPanel_1 = new TableLayoutPanel();
		this.progressBar_0 = new ProgressBar();
		this.jiHowLcbiwf = new ToolStrip();
		this.toolStripButton_3 = new ToolStripButton();
		this.button_2 = new Button();
		this.dataGridViewTextBoxColumn_3 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_4 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_5 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_6 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_7 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_8 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_9 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_10 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_11 = new DataGridViewTextBoxColumn();
		this.openFileDialog_0 = new OpenFileDialog();
		this.backgroundWorker_0 = new BackgroundWorker();
		((ISupportInitialize)this.bindingSource_4).BeginInit();
		((ISupportInitialize)this.class255_0).BeginInit();
		this.tabControl_0.SuspendLayout();
		this.tabPage_0.SuspendLayout();
		((ISupportInitialize)this.dataGridView_0).BeginInit();
		((ISupportInitialize)this.bindingSource_0).BeginInit();
		((ISupportInitialize)this.bindingSource_1).BeginInit();
		this.ggJowlBkuPL.SuspendLayout();
		((ISupportInitialize)this.dataGridView_1).BeginInit();
		((ISupportInitialize)this.bindingSource_8).BeginInit();
		((ISupportInitialize)this.bindingSource_2).BeginInit();
		this.tabPage_1.SuspendLayout();
		((ISupportInitialize)this.MfmowWfuJrX).BeginInit();
		((ISupportInitialize)this.bindingSource_9).BeginInit();
		((ISupportInitialize)this.bindingSource_3).BeginInit();
		this.tabPage_4.SuspendLayout();
		this.tableLayoutPanel_3.SuspendLayout();
		((ISupportInitialize)this.dataGridView_5).BeginInit();
		((ISupportInitialize)this.bindingSource_10).BeginInit();
		((ISupportInitialize)this.bindingSource_11).BeginInit();
		this.tabControl_1.SuspendLayout();
		this.tabPage_2.SuspendLayout();
		this.tableLayoutPanel_0.SuspendLayout();
		this.toolStrip_0.SuspendLayout();
		((ISupportInitialize)this.dataGridView_2).BeginInit();
		((ISupportInitialize)this.bindingSource_5).BeginInit();
		this.tabPage_3.SuspendLayout();
		this.tableLayoutPanel_2.SuspendLayout();
		((ISupportInitialize)this.dataGridView_4).BeginInit();
		((ISupportInitialize)this.bindingSource_7).BeginInit();
		this.toolStrip_1.SuspendLayout();
		((ISupportInitialize)this.dataGridView_3).BeginInit();
		((ISupportInitialize)this.bindingSource_6).BeginInit();
		this.tableLayoutPanel_1.SuspendLayout();
		this.jiHowLcbiwf.SuspendLayout();
		base.SuspendLayout();
		this.label_0.AutoSize = true;
		this.label_0.Dock = DockStyle.Fill;
		this.label_0.Location = new Point(3, 29);
		this.label_0.Name = "label1";
		this.label_0.Size = new Size(118, 29);
		this.label_0.TabIndex = 0;
		this.label_0.Text = "Предмет поручения";
		this.label_0.TextAlign = ContentAlignment.MiddleRight;
		this.textBox_0.DataBindings.Add(new Binding("Text", this.bindingSource_4, "Subject", true));
		this.textBox_0.Dock = DockStyle.Fill;
		this.textBox_0.Location = new Point(127, 34);
		this.textBox_0.Margin = new Padding(3, 5, 3, 3);
		this.textBox_0.Name = "tbSubject";
		this.textBox_0.Size = new Size(277, 20);
		this.textBox_0.TabIndex = 1;
		this.bindingSource_4.DataMember = "tJ_Memorandum";
		this.bindingSource_4.DataSource = this.class255_0;
		this.class255_0.DataSetName = "DataSetGES";
		this.class255_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		this.label_1.AutoSize = true;
		this.label_1.Dock = DockStyle.Fill;
		this.label_1.Location = new Point(3, 58);
		this.label_1.Name = "label2";
		this.label_1.Size = new Size(118, 23);
		this.label_1.TabIndex = 2;
		this.label_1.Text = "Поручение:";
		this.label_1.TextAlign = ContentAlignment.MiddleRight;
		this.tableLayoutPanel_0.SetColumnSpan(this.textBox_1, 2);
		this.textBox_1.DataBindings.Add(new Binding("Text", this.bindingSource_4, "Body_C", true));
		this.textBox_1.Dock = DockStyle.Fill;
		this.textBox_1.Location = new Point(3, 84);
		this.textBox_1.Multiline = true;
		this.textBox_1.Name = "tbBody";
		this.textBox_1.Size = new Size(401, 161);
		this.textBox_1.TabIndex = 3;
		this.tableLayoutPanel_0.SetColumnSpan(this.tabControl_0, 2);
		this.tabControl_0.Controls.Add(this.tabPage_0);
		this.tabControl_0.Controls.Add(this.ggJowlBkuPL);
		this.tabControl_0.Controls.Add(this.tabPage_1);
		this.tabControl_0.Controls.Add(this.tabPage_4);
		this.tabControl_0.Dock = DockStyle.Fill;
		this.tabControl_0.Location = new Point(410, 32);
		this.tabControl_0.Name = "tcGeneral";
		this.tableLayoutPanel_0.SetRowSpan(this.tabControl_0, 3);
		this.tabControl_0.SelectedIndex = 0;
		this.tabControl_0.Size = new Size(407, 213);
		this.tabControl_0.TabIndex = 4;
		this.tabPage_0.Controls.Add(this.dataGridView_0);
		this.tabPage_0.Location = new Point(4, 22);
		this.tabPage_0.Name = "tpSignatory";
		this.tabPage_0.Padding = new Padding(3);
		this.tabPage_0.Size = new Size(399, 187);
		this.tabPage_0.TabIndex = 0;
		this.tabPage_0.Text = "Подписал";
		this.tabPage_0.UseVisualStyleBackColor = true;
		this.dataGridView_0.AllowUserToOrderColumns = true;
		this.dataGridView_0.AutoGenerateColumns = false;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = SystemColors.Control;
		dataGridViewCellStyle.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		this.dataGridView_0.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		this.dataGridView_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView_0.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewComboBoxColumn_0,
			this.dataGridViewCheckBoxColumn_0,
			this.dataGridViewTextBoxColumn_0,
			this.dataGridViewTextBoxColumn_1,
			this.dataGridViewTextBoxColumn_2
		});
		this.dataGridView_0.DataSource = this.bindingSource_1;
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = SystemColors.Window;
		dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
		this.dataGridView_0.DefaultCellStyle = dataGridViewCellStyle2;
		this.dataGridView_0.Dock = DockStyle.Fill;
		this.dataGridView_0.EditMode = DataGridViewEditMode.EditOnEnter;
		this.dataGridView_0.Location = new Point(3, 3);
		this.dataGridView_0.MultiSelect = false;
		this.dataGridView_0.Name = "dgvSignatory";
		dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle3.BackColor = SystemColors.Control;
		dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
		this.dataGridView_0.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
		this.dataGridView_0.RowHeadersVisible = false;
		this.dataGridView_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		this.dataGridView_0.Size = new Size(393, 181);
		this.dataGridView_0.TabIndex = 1;
		this.dataGridView_0.DataError += this.MfmowWfuJrX_DataError;
		this.dataGridViewComboBoxColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewComboBoxColumn_0.DataPropertyName = "idWorker";
		this.dataGridViewComboBoxColumn_0.DataSource = this.bindingSource_0;
		this.dataGridViewComboBoxColumn_0.DisplayMember = "FIO";
		this.dataGridViewComboBoxColumn_0.HeaderText = "ФИО";
		this.dataGridViewComboBoxColumn_0.Name = "idWorkerDataGridViewTextBoxColumn3";
		this.dataGridViewComboBoxColumn_0.Resizable = DataGridViewTriState.True;
		this.dataGridViewComboBoxColumn_0.SortMode = DataGridViewColumnSortMode.Automatic;
		this.dataGridViewComboBoxColumn_0.ValueMember = "Id";
		this.bindingSource_0.DataMember = "vJ_BossUser";
		this.bindingSource_0.DataSource = this.class255_0;
		this.dataGridViewCheckBoxColumn_0.DataPropertyName = "Deleted";
		this.dataGridViewCheckBoxColumn_0.HeaderText = "Deleted";
		this.dataGridViewCheckBoxColumn_0.Name = "deletedDataGridViewCheckBoxColumn3";
		this.dataGridViewCheckBoxColumn_0.Visible = false;
		this.dataGridViewTextBoxColumn_0.DataPropertyName = "id";
		this.dataGridViewTextBoxColumn_0.HeaderText = "id";
		this.dataGridViewTextBoxColumn_0.Name = "idDataGridViewTextBoxColumn3";
		this.dataGridViewTextBoxColumn_0.ReadOnly = true;
		this.dataGridViewTextBoxColumn_0.Visible = false;
		this.dataGridViewTextBoxColumn_1.DataPropertyName = "idMemorandum";
		this.dataGridViewTextBoxColumn_1.HeaderText = "idMemorandum";
		this.dataGridViewTextBoxColumn_1.Name = "idMemorandumDataGridViewTextBoxColumn3";
		this.dataGridViewTextBoxColumn_1.Visible = false;
		this.dataGridViewTextBoxColumn_2.DataPropertyName = "typeWorker";
		this.dataGridViewTextBoxColumn_2.HeaderText = "typeWorker";
		this.dataGridViewTextBoxColumn_2.Name = "typeWorkerDataGridViewTextBoxColumn3";
		this.dataGridViewTextBoxColumn_2.Visible = false;
		this.bindingSource_1.DataMember = "tJ_MemWorker";
		this.bindingSource_1.DataSource = this.class255_0;
		this.bindingSource_1.Filter = "TypeWorker = 1297";
		this.ggJowlBkuPL.Controls.Add(this.dataGridView_1);
		this.ggJowlBkuPL.Location = new Point(4, 22);
		this.ggJowlBkuPL.Name = "tpAddressee";
		this.ggJowlBkuPL.Padding = new Padding(3);
		this.ggJowlBkuPL.Size = new Size(399, 187);
		this.ggJowlBkuPL.TabIndex = 1;
		this.ggJowlBkuPL.Text = "Адресат";
		this.ggJowlBkuPL.UseVisualStyleBackColor = true;
		this.dataGridView_1.AllowUserToOrderColumns = true;
		this.dataGridView_1.AutoGenerateColumns = false;
		dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle4.BackColor = SystemColors.Control;
		dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
		this.dataGridView_1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
		this.dataGridView_1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView_1.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewComboBoxColumn_2,
			this.dataGridViewCheckBoxColumn_2,
			this.dataGridViewTextBoxColumn_26,
			this.dataGridViewTextBoxColumn_27,
			this.cpfoGteKiSP
		});
		this.dataGridView_1.DataSource = this.bindingSource_2;
		dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle5.BackColor = SystemColors.Window;
		dataGridViewCellStyle5.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
		dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
		this.dataGridView_1.DefaultCellStyle = dataGridViewCellStyle5;
		this.dataGridView_1.Dock = DockStyle.Fill;
		this.dataGridView_1.EditMode = DataGridViewEditMode.EditOnEnter;
		this.dataGridView_1.Location = new Point(3, 3);
		this.dataGridView_1.MultiSelect = false;
		this.dataGridView_1.Name = "dgvAddressee";
		dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle6.BackColor = SystemColors.Control;
		dataGridViewCellStyle6.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
		this.dataGridView_1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
		this.dataGridView_1.RowHeadersVisible = false;
		this.dataGridView_1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		this.dataGridView_1.Size = new Size(393, 181);
		this.dataGridView_1.TabIndex = 2;
		this.dataGridView_1.DataError += this.MfmowWfuJrX_DataError;
		this.dataGridViewComboBoxColumn_2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewComboBoxColumn_2.DataPropertyName = "idWorker";
		this.dataGridViewComboBoxColumn_2.DataSource = this.bindingSource_8;
		this.dataGridViewComboBoxColumn_2.DisplayMember = "FIO";
		this.dataGridViewComboBoxColumn_2.HeaderText = "ФИО";
		this.dataGridViewComboBoxColumn_2.Name = "idWorkerDataGridViewTextBoxColumn2";
		this.dataGridViewComboBoxColumn_2.Resizable = DataGridViewTriState.True;
		this.dataGridViewComboBoxColumn_2.SortMode = DataGridViewColumnSortMode.Automatic;
		this.dataGridViewComboBoxColumn_2.ValueMember = "Id";
		this.bindingSource_8.DataMember = "vJ_BossUser";
		this.bindingSource_8.DataSource = this.class255_0;
		this.dataGridViewCheckBoxColumn_2.DataPropertyName = "Deleted";
		this.dataGridViewCheckBoxColumn_2.HeaderText = "Deleted";
		this.dataGridViewCheckBoxColumn_2.Name = "deletedDataGridViewCheckBoxColumn2";
		this.dataGridViewCheckBoxColumn_2.Visible = false;
		this.dataGridViewTextBoxColumn_26.DataPropertyName = "id";
		this.dataGridViewTextBoxColumn_26.HeaderText = "id";
		this.dataGridViewTextBoxColumn_26.Name = "idDataGridViewTextBoxColumn2";
		this.dataGridViewTextBoxColumn_26.ReadOnly = true;
		this.dataGridViewTextBoxColumn_26.Visible = false;
		this.dataGridViewTextBoxColumn_27.DataPropertyName = "idMemorandum";
		this.dataGridViewTextBoxColumn_27.HeaderText = "idMemorandum";
		this.dataGridViewTextBoxColumn_27.Name = "idMemorandumDataGridViewTextBoxColumn2";
		this.dataGridViewTextBoxColumn_27.Visible = false;
		this.cpfoGteKiSP.DataPropertyName = "typeWorker";
		this.cpfoGteKiSP.HeaderText = "typeWorker";
		this.cpfoGteKiSP.Name = "typeWorkerDataGridViewTextBoxColumn2";
		this.cpfoGteKiSP.Visible = false;
		this.bindingSource_2.DataMember = "tJ_MemWorker";
		this.bindingSource_2.DataSource = this.class255_0;
		this.bindingSource_2.Filter = "TypeWorker = 1300";
		this.tabPage_1.Controls.Add(this.MfmowWfuJrX);
		this.tabPage_1.Location = new Point(4, 22);
		this.tabPage_1.Name = "tpVizier";
		this.tabPage_1.Padding = new Padding(3);
		this.tabPage_1.Size = new Size(399, 187);
		this.tabPage_1.TabIndex = 3;
		this.tabPage_1.Text = "Визирующие";
		this.tabPage_1.UseVisualStyleBackColor = true;
		this.MfmowWfuJrX.AllowUserToOrderColumns = true;
		this.MfmowWfuJrX.AutoGenerateColumns = false;
		dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle7.BackColor = SystemColors.Control;
		dataGridViewCellStyle7.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle7.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
		this.MfmowWfuJrX.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
		this.MfmowWfuJrX.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.MfmowWfuJrX.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewComboBoxColumn_3,
			this.dataGridViewCheckBoxColumn_3,
			this.dataGridViewTextBoxColumn_28,
			this.dataGridViewTextBoxColumn_29,
			this.dataGridViewTextBoxColumn_30
		});
		this.MfmowWfuJrX.DataSource = this.bindingSource_3;
		dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle8.BackColor = SystemColors.Window;
		dataGridViewCellStyle8.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle8.ForeColor = SystemColors.ControlText;
		dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
		this.MfmowWfuJrX.DefaultCellStyle = dataGridViewCellStyle8;
		this.MfmowWfuJrX.Dock = DockStyle.Fill;
		this.MfmowWfuJrX.EditMode = DataGridViewEditMode.EditOnEnter;
		this.MfmowWfuJrX.Location = new Point(3, 3);
		this.MfmowWfuJrX.MultiSelect = false;
		this.MfmowWfuJrX.Name = "dgvVizier";
		dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle9.BackColor = SystemColors.Control;
		dataGridViewCellStyle9.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle9.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle9.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle9.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
		this.MfmowWfuJrX.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
		this.MfmowWfuJrX.RowHeadersVisible = false;
		this.MfmowWfuJrX.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		this.MfmowWfuJrX.Size = new Size(393, 181);
		this.MfmowWfuJrX.TabIndex = 3;
		this.MfmowWfuJrX.DataError += this.MfmowWfuJrX_DataError;
		this.dataGridViewComboBoxColumn_3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewComboBoxColumn_3.DataPropertyName = "idWorker";
		this.dataGridViewComboBoxColumn_3.DataSource = this.bindingSource_9;
		this.dataGridViewComboBoxColumn_3.DisplayMember = "FIO";
		this.dataGridViewComboBoxColumn_3.HeaderText = "ФИО";
		this.dataGridViewComboBoxColumn_3.Name = "idWorkerDataGridViewTextBoxColumn";
		this.dataGridViewComboBoxColumn_3.Resizable = DataGridViewTriState.True;
		this.dataGridViewComboBoxColumn_3.SortMode = DataGridViewColumnSortMode.Automatic;
		this.dataGridViewComboBoxColumn_3.ValueMember = "Id";
		this.bindingSource_9.DataMember = "vJ_BossUser";
		this.bindingSource_9.DataSource = this.class255_0;
		this.dataGridViewCheckBoxColumn_3.DataPropertyName = "Deleted";
		this.dataGridViewCheckBoxColumn_3.HeaderText = "Deleted";
		this.dataGridViewCheckBoxColumn_3.Name = "deletedDataGridViewCheckBoxColumn";
		this.dataGridViewCheckBoxColumn_3.Visible = false;
		this.dataGridViewTextBoxColumn_28.DataPropertyName = "id";
		this.dataGridViewTextBoxColumn_28.HeaderText = "id";
		this.dataGridViewTextBoxColumn_28.Name = "idDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_28.ReadOnly = true;
		this.dataGridViewTextBoxColumn_28.Visible = false;
		this.dataGridViewTextBoxColumn_29.DataPropertyName = "idMemorandum";
		this.dataGridViewTextBoxColumn_29.HeaderText = "idMemorandum";
		this.dataGridViewTextBoxColumn_29.Name = "idMemorandumDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_29.Visible = false;
		this.dataGridViewTextBoxColumn_30.DataPropertyName = "typeWorker";
		this.dataGridViewTextBoxColumn_30.HeaderText = "typeWorker";
		this.dataGridViewTextBoxColumn_30.Name = "typeWorkerDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_30.Visible = false;
		this.bindingSource_3.DataMember = "tJ_MemWorker";
		this.bindingSource_3.DataSource = this.class255_0;
		this.bindingSource_3.Filter = "TypeWorker = 1298";
		this.tabPage_4.Controls.Add(this.tableLayoutPanel_3);
		this.tabPage_4.Location = new Point(4, 22);
		this.tabPage_4.Name = "tpSend";
		this.tabPage_4.Padding = new Padding(3);
		this.tabPage_4.Size = new Size(399, 187);
		this.tabPage_4.TabIndex = 4;
		this.tabPage_4.Text = "Уведомить";
		this.tabPage_4.UseVisualStyleBackColor = true;
		this.tableLayoutPanel_3.ColumnCount = 2;
		this.tableLayoutPanel_3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
		this.tableLayoutPanel_3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 125f));
		this.tableLayoutPanel_3.Controls.Add(this.button_3, 1, 1);
		this.tableLayoutPanel_3.Controls.Add(this.dataGridView_5, 0, 0);
		this.tableLayoutPanel_3.Dock = DockStyle.Fill;
		this.tableLayoutPanel_3.Location = new Point(3, 3);
		this.tableLayoutPanel_3.Name = "tableLayoutPanel3";
		this.tableLayoutPanel_3.RowCount = 2;
		this.tableLayoutPanel_3.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
		this.tableLayoutPanel_3.RowStyles.Add(new RowStyle(SizeType.Absolute, 29f));
		this.tableLayoutPanel_3.Size = new Size(393, 181);
		this.tableLayoutPanel_3.TabIndex = 0;
		this.button_3.Dock = DockStyle.Fill;
		this.button_3.Location = new Point(271, 155);
		this.button_3.Name = "btnSendMail";
		this.button_3.Size = new Size(119, 23);
		this.button_3.TabIndex = 0;
		this.button_3.Text = "Отправить письмо";
		this.button_3.UseVisualStyleBackColor = true;
		this.button_3.Click += this.button_3_Click;
		this.dataGridView_5.AllowUserToOrderColumns = true;
		this.dataGridView_5.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView_5.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewComboBoxColumn_4
		});
		this.tableLayoutPanel_3.SetColumnSpan(this.dataGridView_5, 2);
		this.dataGridView_5.Dock = DockStyle.Fill;
		this.dataGridView_5.EditMode = DataGridViewEditMode.EditOnEnter;
		this.dataGridView_5.Location = new Point(3, 3);
		this.dataGridView_5.Name = "dgvSend";
		this.dataGridView_5.RowHeadersVisible = false;
		this.dataGridView_5.Size = new Size(387, 146);
		this.dataGridView_5.TabIndex = 1;
		this.dataGridView_5.CellContentClick += this.dataGridView_5_CellContentClick;
		this.dataGridViewComboBoxColumn_4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewComboBoxColumn_4.DataSource = this.bindingSource_10;
		this.dataGridViewComboBoxColumn_4.DisplayMember = "FIO";
		this.dataGridViewComboBoxColumn_4.HeaderText = "ФИО";
		this.dataGridViewComboBoxColumn_4.Name = "Send";
		this.dataGridViewComboBoxColumn_4.Resizable = DataGridViewTriState.True;
		this.dataGridViewComboBoxColumn_4.SortMode = DataGridViewColumnSortMode.Automatic;
		this.dataGridViewComboBoxColumn_4.ValueMember = "Id";
		this.bindingSource_10.DataMember = "vJ_BossUser";
		this.bindingSource_10.DataSource = this.class255_0;
		this.bindingSource_11.DataMember = "tJ_MemWorker";
		this.bindingSource_11.DataSource = this.class255_0;
		this.bindingSource_11.Filter = "TypeWorker = 1312";
		this.bindingSource_11.AddingNew += this.bindingSource_11_AddingNew;
		this.button_0.Dock = DockStyle.Right;
		this.button_0.Location = new Point(642, 544);
		this.button_0.Margin = new Padding(3, 8, 3, 8);
		this.button_0.Name = "btnSend";
		this.button_0.Size = new Size(92, 25);
		this.button_0.TabIndex = 5;
		this.button_0.Text = "Отправить";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_0.Click += this.button_0_Click;
		this.button_1.Dock = DockStyle.Left;
		this.button_1.Location = new Point(752, 544);
		this.button_1.Margin = new Padding(15, 8, 3, 8);
		this.button_1.Name = "btnCancel";
		this.button_1.Size = new Size(75, 25);
		this.button_1.TabIndex = 6;
		this.button_1.Text = "Закрыть";
		this.button_1.UseVisualStyleBackColor = true;
		this.button_1.Click += this.button_1_Click;
		this.tableLayoutPanel_1.SetColumnSpan(this.tabControl_1, 4);
		this.tabControl_1.Controls.Add(this.tabPage_2);
		this.tabControl_1.Controls.Add(this.tabPage_3);
		this.tabControl_1.Dock = DockStyle.Fill;
		this.tabControl_1.Location = new Point(3, 29);
		this.tabControl_1.Name = "tabControl1";
		this.tabControl_1.SelectedIndex = 0;
		this.tabControl_1.Size = new Size(834, 504);
		this.tabControl_1.TabIndex = 7;
		this.tabPage_2.Controls.Add(this.tableLayoutPanel_0);
		this.tabPage_2.Location = new Point(4, 22);
		this.tabPage_2.Name = "tpGeneral";
		this.tabPage_2.Padding = new Padding(3);
		this.tabPage_2.Size = new Size(826, 478);
		this.tabPage_2.TabIndex = 0;
		this.tabPage_2.Text = "Общие";
		this.tabPage_2.UseVisualStyleBackColor = true;
		this.tableLayoutPanel_0.ColumnCount = 4;
		this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 124f));
		this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 283f));
		this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 214f));
		this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		this.tableLayoutPanel_0.Controls.Add(this.toolStrip_0, 0, 4);
		this.tableLayoutPanel_0.Controls.Add(this.dataGridView_2, 0, 5);
		this.tableLayoutPanel_0.Controls.Add(this.label_2, 1, 6);
		this.tableLayoutPanel_0.Controls.Add(this.label_3, 0, 0);
		this.tableLayoutPanel_0.Controls.Add(this.label_0, 0, 1);
		this.tableLayoutPanel_0.Controls.Add(this.PeVowpgDlnO, 0, 6);
		this.tableLayoutPanel_0.Controls.Add(this.label_1, 0, 2);
		this.tableLayoutPanel_0.Controls.Add(this.textBox_0, 1, 1);
		this.tableLayoutPanel_0.Controls.Add(this.textBox_1, 0, 3);
		this.tableLayoutPanel_0.Controls.Add(this.tabControl_0, 2, 1);
		this.tableLayoutPanel_0.Controls.Add(this.label_4, 1, 0);
		this.tableLayoutPanel_0.Dock = DockStyle.Fill;
		this.tableLayoutPanel_0.Location = new Point(3, 3);
		this.tableLayoutPanel_0.Name = "tableLayoutPanel1";
		this.tableLayoutPanel_0.RowCount = 7;
		this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Absolute, 29f));
		this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Absolute, 29f));
		this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Absolute, 23f));
		this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
		this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Absolute, 24f));
		this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
		this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Absolute, 33f));
		this.tableLayoutPanel_0.Size = new Size(820, 472);
		this.tableLayoutPanel_0.TabIndex = 0;
		this.tableLayoutPanel_0.SetColumnSpan(this.toolStrip_0, 4);
		this.toolStrip_0.Dock = DockStyle.Fill;
		this.toolStrip_0.Items.AddRange(new ToolStripItem[]
		{
			this.toolStripButton_0,
			this.toolStripButton_4,
			this.toolStripSeparator_0,
			this.toolStripButton_1,
			this.toolStripButton_2
		});
		this.toolStrip_0.Location = new Point(0, 248);
		this.toolStrip_0.Name = "tsFiles";
		this.toolStrip_0.Size = new Size(820, 24);
		this.toolStrip_0.TabIndex = 8;
		this.toolStrip_0.Text = "toolStrip1";
		this.toolStripButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_0.Image = Resources.ElementAdd;
		this.toolStripButton_0.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_0.Name = "tsbAddFiles";
		this.toolStripButton_0.Size = new Size(23, 21);
		this.toolStripButton_0.Text = "Добавить файл";
		this.toolStripButton_0.Click += this.toolStripButton_0_Click;
		this.toolStripButton_4.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_4.Image = Resources.ElementInformation;
		this.toolStripButton_4.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_4.Name = "tsbViewFiles";
		this.toolStripButton_4.Size = new Size(23, 21);
		this.toolStripButton_4.Text = "Открыть файл";
		this.toolStripButton_4.Click += this.toolStripButton_4_Click;
		this.toolStripSeparator_0.Name = "toolStripSeparator1";
		this.toolStripSeparator_0.Size = new Size(6, 24);
		this.toolStripButton_1.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_1.Image = Resources.ElementDel;
		this.toolStripButton_1.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_1.Name = "tsbDeleteFiles";
		this.toolStripButton_1.Size = new Size(23, 21);
		this.toolStripButton_1.Text = "Удалить файл";
		this.toolStripButton_1.Click += this.toolStripButton_1_Click;
		this.toolStripButton_2.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_2.Image = Resources.refresh_16;
		this.toolStripButton_2.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_2.Name = "tsbRefreshFiles";
		this.toolStripButton_2.Size = new Size(23, 21);
		this.toolStripButton_2.Text = "Обновить";
		this.toolStripButton_2.Visible = false;
		this.toolStripButton_2.Click += this.toolStripButton_2_Click;
		this.dataGridView_2.AllowUserToAddRows = false;
		this.dataGridView_2.AllowUserToDeleteRows = false;
		this.dataGridView_2.AutoGenerateColumns = false;
		dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle10.BackColor = SystemColors.Control;
		dataGridViewCellStyle10.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle10.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle10.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle10.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle10.WrapMode = DataGridViewTriState.True;
		this.dataGridView_2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
		this.dataGridView_2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView_2.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewTextBoxColumn_12,
			this.dataGridViewTextBoxColumn_13,
			this.dataGridViewTextBoxColumn_14,
			this.dataGridViewTextBoxColumn_15
		});
		this.tableLayoutPanel_0.SetColumnSpan(this.dataGridView_2, 4);
		this.dataGridView_2.DataSource = this.bindingSource_5;
		dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle11.BackColor = SystemColors.Window;
		dataGridViewCellStyle11.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle11.ForeColor = SystemColors.ControlText;
		dataGridViewCellStyle11.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle11.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle11.WrapMode = DataGridViewTriState.False;
		this.dataGridView_2.DefaultCellStyle = dataGridViewCellStyle11;
		this.dataGridView_2.Dock = DockStyle.Fill;
		this.dataGridView_2.Location = new Point(3, 275);
		this.dataGridView_2.Name = "dgvFiles";
		this.dataGridView_2.ReadOnly = true;
		dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle12.BackColor = SystemColors.Control;
		dataGridViewCellStyle12.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle12.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle12.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle12.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle12.WrapMode = DataGridViewTriState.True;
		this.dataGridView_2.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
		this.dataGridView_2.RowHeadersVisible = false;
		this.dataGridView_2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		this.dataGridView_2.Size = new Size(814, 161);
		this.dataGridView_2.TabIndex = 8;
		this.dataGridViewTextBoxColumn_12.DataPropertyName = "id";
		this.dataGridViewTextBoxColumn_12.HeaderText = "id";
		this.dataGridViewTextBoxColumn_12.Name = "idDataGridViewTextBoxColumn1";
		this.dataGridViewTextBoxColumn_12.ReadOnly = true;
		this.dataGridViewTextBoxColumn_12.Visible = false;
		this.dataGridViewTextBoxColumn_13.DataPropertyName = "idDocument";
		this.dataGridViewTextBoxColumn_13.HeaderText = "idDocument";
		this.dataGridViewTextBoxColumn_13.Name = "idDocumentDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_13.ReadOnly = true;
		this.dataGridViewTextBoxColumn_13.Visible = false;
		this.dataGridViewTextBoxColumn_14.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_14.DataPropertyName = "Name";
		this.dataGridViewTextBoxColumn_14.HeaderText = "Файл";
		this.dataGridViewTextBoxColumn_14.Name = "nameDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_14.ReadOnly = true;
		this.dataGridViewTextBoxColumn_15.DataPropertyName = "Size";
		this.dataGridViewTextBoxColumn_15.HeaderText = "Size";
		this.dataGridViewTextBoxColumn_15.Name = "sizeDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_15.ReadOnly = true;
		this.dataGridViewTextBoxColumn_15.Visible = false;
		this.bindingSource_5.DataMember = "tJ_MemFiles";
		this.bindingSource_5.DataSource = this.class255_0;
		this.bindingSource_5.Filter = "TypeDoc = 1";
		this.label_2.AutoSize = true;
		this.tableLayoutPanel_0.SetColumnSpan(this.label_2, 3);
		this.label_2.Dock = DockStyle.Fill;
		this.label_2.Location = new Point(127, 439);
		this.label_2.Name = "lb";
		this.label_2.Size = new Size(690, 33);
		this.label_2.TabIndex = 6;
		this.label_2.TextAlign = ContentAlignment.MiddleLeft;
		this.label_3.AutoSize = true;
		this.label_3.Dock = DockStyle.Fill;
		this.label_3.Location = new Point(3, 0);
		this.label_3.Name = "label5";
		this.label_3.Size = new Size(118, 29);
		this.label_3.TabIndex = 7;
		this.label_3.Text = "Документ:";
		this.label_3.TextAlign = ContentAlignment.MiddleRight;
		this.PeVowpgDlnO.AutoSize = true;
		this.PeVowpgDlnO.Dock = DockStyle.Fill;
		this.PeVowpgDlnO.Location = new Point(3, 439);
		this.PeVowpgDlnO.Name = "label3";
		this.PeVowpgDlnO.Size = new Size(118, 33);
		this.PeVowpgDlnO.TabIndex = 5;
		this.PeVowpgDlnO.Text = "Исполнитель";
		this.PeVowpgDlnO.TextAlign = ContentAlignment.MiddleRight;
		this.label_4.AutoSize = true;
		this.tableLayoutPanel_0.SetColumnSpan(this.label_4, 3);
		this.label_4.DataBindings.Add(new Binding("Text", this.bindingSource_4, "RgNum", true));
		this.label_4.Dock = DockStyle.Fill;
		this.label_4.Location = new Point(127, 0);
		this.label_4.Name = "lbDocument";
		this.label_4.Size = new Size(690, 29);
		this.label_4.TabIndex = 9;
		this.label_4.TextAlign = ContentAlignment.MiddleLeft;
		this.tabPage_3.Controls.Add(this.tableLayoutPanel_2);
		this.tabPage_3.Location = new Point(4, 22);
		this.tabPage_3.Name = "tbProcess";
		this.tabPage_3.Padding = new Padding(3);
		this.tabPage_3.Size = new Size(826, 478);
		this.tabPage_3.TabIndex = 1;
		this.tabPage_3.Text = "Процесс";
		this.tabPage_3.UseVisualStyleBackColor = true;
		this.tableLayoutPanel_2.ColumnCount = 2;
		this.tableLayoutPanel_2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
		this.tableLayoutPanel_2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
		this.tableLayoutPanel_2.Controls.Add(this.dataGridView_4, 0, 2);
		this.tableLayoutPanel_2.Controls.Add(this.toolStrip_1, 0, 1);
		this.tableLayoutPanel_2.Controls.Add(this.dataGridView_3, 0, 0);
		this.tableLayoutPanel_2.Dock = DockStyle.Fill;
		this.tableLayoutPanel_2.Location = new Point(3, 3);
		this.tableLayoutPanel_2.Name = "tlpProcess";
		this.tableLayoutPanel_2.RowCount = 3;
		this.tableLayoutPanel_2.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
		this.tableLayoutPanel_2.RowStyles.Add(new RowStyle(SizeType.Absolute, 26f));
		this.tableLayoutPanel_2.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
		this.tableLayoutPanel_2.Size = new Size(820, 472);
		this.tableLayoutPanel_2.TabIndex = 0;
		this.dataGridView_4.AllowUserToAddRows = false;
		this.dataGridView_4.AllowUserToDeleteRows = false;
		this.dataGridView_4.AutoGenerateColumns = false;
		dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle13.BackColor = SystemColors.Control;
		dataGridViewCellStyle13.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle13.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle13.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle13.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle13.WrapMode = DataGridViewTriState.True;
		this.dataGridView_4.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
		this.dataGridView_4.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView_4.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewTextBoxColumn_16,
			this.dataGridViewTextBoxColumn_17,
			this.dataGridViewTextBoxColumn_18,
			this.dataGridViewTextBoxColumn_19
		});
		this.tableLayoutPanel_2.SetColumnSpan(this.dataGridView_4, 4);
		this.dataGridView_4.DataSource = this.bindingSource_7;
		dataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle14.BackColor = SystemColors.Window;
		dataGridViewCellStyle14.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle14.ForeColor = SystemColors.ControlText;
		dataGridViewCellStyle14.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle14.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle14.WrapMode = DataGridViewTriState.False;
		this.dataGridView_4.DefaultCellStyle = dataGridViewCellStyle14;
		this.dataGridView_4.Dock = DockStyle.Fill;
		this.dataGridView_4.Location = new Point(3, 252);
		this.dataGridView_4.Name = "dgvFileCommission";
		this.dataGridView_4.ReadOnly = true;
		dataGridViewCellStyle15.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle15.BackColor = SystemColors.Control;
		dataGridViewCellStyle15.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle15.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle15.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle15.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle15.WrapMode = DataGridViewTriState.True;
		this.dataGridView_4.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
		this.dataGridView_4.RowHeadersVisible = false;
		this.dataGridView_4.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		this.dataGridView_4.Size = new Size(814, 217);
		this.dataGridView_4.TabIndex = 10;
		this.dataGridViewTextBoxColumn_16.DataPropertyName = "id";
		this.dataGridViewTextBoxColumn_16.HeaderText = "id";
		this.dataGridViewTextBoxColumn_16.Name = "dataGridViewTextBoxColumn10";
		this.dataGridViewTextBoxColumn_16.ReadOnly = true;
		this.dataGridViewTextBoxColumn_16.Visible = false;
		this.dataGridViewTextBoxColumn_17.DataPropertyName = "idDocument";
		this.dataGridViewTextBoxColumn_17.HeaderText = "idDocument";
		this.dataGridViewTextBoxColumn_17.Name = "dataGridViewTextBoxColumn11";
		this.dataGridViewTextBoxColumn_17.ReadOnly = true;
		this.dataGridViewTextBoxColumn_17.Visible = false;
		this.dataGridViewTextBoxColumn_18.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_18.DataPropertyName = "Name";
		this.dataGridViewTextBoxColumn_18.HeaderText = "Файл";
		this.dataGridViewTextBoxColumn_18.Name = "dataGridViewTextBoxColumn12";
		this.dataGridViewTextBoxColumn_18.ReadOnly = true;
		this.dataGridViewTextBoxColumn_19.DataPropertyName = "Size";
		this.dataGridViewTextBoxColumn_19.HeaderText = "Size";
		this.dataGridViewTextBoxColumn_19.Name = "dataGridViewTextBoxColumn13";
		this.dataGridViewTextBoxColumn_19.ReadOnly = true;
		this.dataGridViewTextBoxColumn_19.Visible = false;
		this.bindingSource_7.DataMember = "tJ_MemFiles";
		this.bindingSource_7.DataSource = this.class255_0;
		this.bindingSource_7.Filter = "TypeDoc = 2";
		this.tableLayoutPanel_2.SetColumnSpan(this.toolStrip_1, 4);
		this.toolStrip_1.Dock = DockStyle.Fill;
		this.toolStrip_1.Items.AddRange(new ToolStripItem[]
		{
			this.toolStripButton_5,
			this.toolStripButton_6,
			this.toolStripSeparator_1,
			this.toolStripButton_7,
			this.toolStripButton_8
		});
		this.toolStrip_1.Location = new Point(0, 223);
		this.toolStrip_1.Name = "tsFileCommission";
		this.toolStrip_1.Size = new Size(820, 26);
		this.toolStrip_1.TabIndex = 9;
		this.toolStrip_1.Text = "toolStrip1";
		this.toolStripButton_5.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_5.Image = Resources.ElementAdd;
		this.toolStripButton_5.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_5.Name = "tsbAddFileCommission";
		this.toolStripButton_5.Size = new Size(23, 23);
		this.toolStripButton_5.Text = "Добавить файл";
		this.toolStripButton_5.Click += this.toolStripButton_5_Click;
		this.toolStripButton_6.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_6.Image = Resources.ElementInformation;
		this.toolStripButton_6.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_6.Name = "tsbViewFileCommission";
		this.toolStripButton_6.Size = new Size(23, 23);
		this.toolStripButton_6.Text = "Открыть файл";
		this.toolStripButton_6.Click += this.toolStripButton_6_Click;
		this.toolStripSeparator_1.Name = "toolStripSeparator2";
		this.toolStripSeparator_1.Size = new Size(6, 26);
		this.toolStripButton_7.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_7.Image = Resources.ElementDel;
		this.toolStripButton_7.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_7.Name = "tsbDeleteFileCommission";
		this.toolStripButton_7.Size = new Size(23, 23);
		this.toolStripButton_7.Text = "Удалить файл";
		this.toolStripButton_7.Click += this.KmnoeqvguoO;
		this.toolStripButton_8.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_8.Image = Resources.refresh_16;
		this.toolStripButton_8.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_8.Name = "tsbRefreshFileCommission";
		this.toolStripButton_8.Size = new Size(23, 23);
		this.toolStripButton_8.Text = "Обновить";
		this.toolStripButton_8.Visible = false;
		this.toolStripButton_8.Click += this.toolStripButton_8_Click;
		this.dataGridView_3.AllowUserToAddRows = false;
		this.dataGridView_3.AllowUserToDeleteRows = false;
		this.dataGridView_3.AllowUserToOrderColumns = true;
		this.dataGridView_3.AutoGenerateColumns = false;
		this.dataGridView_3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView_3.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewTextBoxColumn_20,
			this.dataGridViewTextBoxColumn_21,
			this.dataGridViewTextBoxColumn_22,
			this.dataGridViewTextBoxColumn_23,
			this.dataGridViewTextBoxColumn_24,
			this.oEdoGsvuknR,
			this.dataGridViewTextBoxColumn_25,
			this.dataGridViewComboBoxColumn_1,
			this.dataGridViewCheckBoxColumn_1
		});
		this.tableLayoutPanel_2.SetColumnSpan(this.dataGridView_3, 2);
		this.dataGridView_3.DataSource = this.bindingSource_6;
		this.dataGridView_3.Dock = DockStyle.Fill;
		this.dataGridView_3.Location = new Point(3, 3);
		this.dataGridView_3.Name = "dgvCommission";
		this.dataGridView_3.ReadOnly = true;
		this.dataGridView_3.RowHeadersVisible = false;
		this.dataGridView_3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		this.dataGridView_3.Size = new Size(814, 217);
		this.dataGridView_3.TabIndex = 0;
		this.dataGridView_3.DataError += this.dataGridView_3_DataError;
		this.dataGridViewTextBoxColumn_20.DataPropertyName = "id";
		this.dataGridViewTextBoxColumn_20.HeaderText = "Column1";
		this.dataGridViewTextBoxColumn_20.Name = "id";
		this.dataGridViewTextBoxColumn_20.ReadOnly = true;
		this.dataGridViewTextBoxColumn_20.Visible = false;
		this.dataGridViewTextBoxColumn_21.DataPropertyName = "UNID";
		this.dataGridViewTextBoxColumn_21.HeaderText = "UNID";
		this.dataGridViewTextBoxColumn_21.Name = "uNIDDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_21.ReadOnly = true;
		this.dataGridViewTextBoxColumn_21.Visible = false;
		this.dataGridViewTextBoxColumn_22.DataPropertyName = "DateFact";
		this.dataGridViewTextBoxColumn_22.HeaderText = "Дата факт. выполнения";
		this.dataGridViewTextBoxColumn_22.Name = "dateFactDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_22.ReadOnly = true;
		this.dataGridViewTextBoxColumn_23.DataPropertyName = "Status";
		this.dataGridViewTextBoxColumn_23.HeaderText = "Отметка о выполнении";
		this.dataGridViewTextBoxColumn_23.Name = "statusDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_23.ReadOnly = true;
		this.dataGridViewTextBoxColumn_23.Width = 150;
		this.dataGridViewTextBoxColumn_24.DataPropertyName = "Subject";
		this.dataGridViewTextBoxColumn_24.HeaderText = "Тема";
		this.dataGridViewTextBoxColumn_24.Name = "Subject";
		this.dataGridViewTextBoxColumn_24.ReadOnly = true;
		this.dataGridViewTextBoxColumn_24.Width = 150;
		this.oEdoGsvuknR.DataPropertyName = "Body";
		this.oEdoGsvuknR.HeaderText = "Текст письма";
		this.oEdoGsvuknR.Name = "Body";
		this.oEdoGsvuknR.ReadOnly = true;
		this.oEdoGsvuknR.Width = 150;
		this.dataGridViewTextBoxColumn_25.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_25.DataPropertyName = "Comment";
		this.dataGridViewTextBoxColumn_25.HeaderText = "Комментарий к исполнению";
		this.dataGridViewTextBoxColumn_25.Name = "commentDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_25.ReadOnly = true;
		this.dataGridViewComboBoxColumn_1.DataPropertyName = "Performer";
		this.dataGridViewComboBoxColumn_1.DataSource = this.bindingSource_0;
		this.dataGridViewComboBoxColumn_1.DisplayMember = "FIO";
		this.dataGridViewComboBoxColumn_1.FlatStyle = FlatStyle.Popup;
		this.dataGridViewComboBoxColumn_1.HeaderText = "Выполнил";
		this.dataGridViewComboBoxColumn_1.Name = "performerDataGridViewTextBoxColumn";
		this.dataGridViewComboBoxColumn_1.ReadOnly = true;
		this.dataGridViewComboBoxColumn_1.Resizable = DataGridViewTriState.True;
		this.dataGridViewComboBoxColumn_1.SortMode = DataGridViewColumnSortMode.Automatic;
		this.dataGridViewComboBoxColumn_1.ValueMember = "Id";
		this.dataGridViewComboBoxColumn_1.Width = 130;
		this.dataGridViewCheckBoxColumn_1.DataPropertyName = "Deleted";
		this.dataGridViewCheckBoxColumn_1.HeaderText = "Deleted";
		this.dataGridViewCheckBoxColumn_1.Name = "deletedDataGridViewCheckBoxColumn1";
		this.dataGridViewCheckBoxColumn_1.ReadOnly = true;
		this.dataGridViewCheckBoxColumn_1.Visible = false;
		this.bindingSource_6.DataMember = "vJ_MemCommission";
		this.bindingSource_6.DataSource = this.class255_0;
		this.bindingSource_6.CurrentChanged += this.bindingSource_6_CurrentChanged;
		this.tableLayoutPanel_1.ColumnCount = 4;
		this.tableLayoutPanel_1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		this.tableLayoutPanel_1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 382f));
		this.tableLayoutPanel_1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110f));
		this.tableLayoutPanel_1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 103f));
		this.tableLayoutPanel_1.Controls.Add(this.progressBar_0, 0, 2);
		this.tableLayoutPanel_1.Controls.Add(this.button_1, 3, 2);
		this.tableLayoutPanel_1.Controls.Add(this.tabControl_1, 0, 1);
		this.tableLayoutPanel_1.Controls.Add(this.button_0, 2, 2);
		this.tableLayoutPanel_1.Controls.Add(this.jiHowLcbiwf, 0, 0);
		this.tableLayoutPanel_1.Controls.Add(this.button_2, 1, 2);
		this.tableLayoutPanel_1.Dock = DockStyle.Fill;
		this.tableLayoutPanel_1.Location = new Point(0, 0);
		this.tableLayoutPanel_1.Name = "tableLayoutPanel2";
		this.tableLayoutPanel_1.RowCount = 3;
		this.tableLayoutPanel_1.RowStyles.Add(new RowStyle(SizeType.Absolute, 26f));
		this.tableLayoutPanel_1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		this.tableLayoutPanel_1.RowStyles.Add(new RowStyle(SizeType.Absolute, 41f));
		this.tableLayoutPanel_1.Size = new Size(840, 577);
		this.tableLayoutPanel_1.TabIndex = 8;
		this.tableLayoutPanel_1.TabIndexChanged += this.tableLayoutPanel_1_TabIndexChanged;
		this.progressBar_0.Dock = DockStyle.Fill;
		this.progressBar_0.Location = new Point(8, 544);
		this.progressBar_0.Margin = new Padding(8, 8, 3, 10);
		this.progressBar_0.Name = "psbMemorandum";
		this.progressBar_0.Size = new Size(234, 23);
		this.progressBar_0.TabIndex = 9;
		this.tableLayoutPanel_1.SetColumnSpan(this.jiHowLcbiwf, 4);
		this.jiHowLcbiwf.Dock = DockStyle.Fill;
		this.jiHowLcbiwf.Items.AddRange(new ToolStripItem[]
		{
			this.toolStripButton_3
		});
		this.jiHowLcbiwf.Location = new Point(0, 0);
		this.jiHowLcbiwf.Name = "tsMemorandum";
		this.jiHowLcbiwf.Size = new Size(840, 26);
		this.jiHowLcbiwf.TabIndex = 8;
		this.jiHowLcbiwf.Text = "toolStrip2";
		this.toolStripButton_3.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_3.Image = Resources.refresh_16;
		this.toolStripButton_3.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_3.Name = "tsbUpdate";
		this.toolStripButton_3.Size = new Size(23, 23);
		this.toolStripButton_3.Text = "Синхронизировать данные";
		this.toolStripButton_3.Click += this.likobppyWqA;
		this.button_2.Dock = DockStyle.Right;
		this.button_2.Location = new Point(537, 544);
		this.button_2.Margin = new Padding(3, 8, 3, 8);
		this.button_2.Name = "btnSave";
		this.button_2.Size = new Size(87, 25);
		this.button_2.TabIndex = 10;
		this.button_2.Text = "Сохранить";
		this.button_2.UseVisualStyleBackColor = true;
		this.button_2.Click += this.button_2_Click;
		this.dataGridViewTextBoxColumn_3.DataPropertyName = "id";
		this.dataGridViewTextBoxColumn_3.HeaderText = "id";
		this.dataGridViewTextBoxColumn_3.Name = "dataGridViewTextBoxColumn1";
		this.dataGridViewTextBoxColumn_3.ReadOnly = true;
		this.dataGridViewTextBoxColumn_3.Visible = false;
		this.dataGridViewTextBoxColumn_4.DataPropertyName = "idMemorandum";
		this.dataGridViewTextBoxColumn_4.HeaderText = "idMemorandum";
		this.dataGridViewTextBoxColumn_4.Name = "dataGridViewTextBoxColumn2";
		this.dataGridViewTextBoxColumn_4.Visible = false;
		this.dataGridViewTextBoxColumn_5.DataPropertyName = "typeWorker";
		this.dataGridViewTextBoxColumn_5.HeaderText = "typeWorker";
		this.dataGridViewTextBoxColumn_5.Name = "dataGridViewTextBoxColumn3";
		this.dataGridViewTextBoxColumn_5.Visible = false;
		this.dataGridViewTextBoxColumn_6.DataPropertyName = "id";
		this.dataGridViewTextBoxColumn_6.HeaderText = "id";
		this.dataGridViewTextBoxColumn_6.Name = "dataGridViewTextBoxColumn4";
		this.dataGridViewTextBoxColumn_6.ReadOnly = true;
		this.dataGridViewTextBoxColumn_6.Visible = false;
		this.dataGridViewTextBoxColumn_7.DataPropertyName = "idMemorandum";
		this.dataGridViewTextBoxColumn_7.HeaderText = "idMemorandum";
		this.dataGridViewTextBoxColumn_7.Name = "dataGridViewTextBoxColumn5";
		this.dataGridViewTextBoxColumn_7.Visible = false;
		this.dataGridViewTextBoxColumn_8.DataPropertyName = "typeWorker";
		this.dataGridViewTextBoxColumn_8.HeaderText = "typeWorker";
		this.dataGridViewTextBoxColumn_8.Name = "dataGridViewTextBoxColumn6";
		this.dataGridViewTextBoxColumn_8.Visible = false;
		this.dataGridViewTextBoxColumn_9.DataPropertyName = "id";
		this.dataGridViewTextBoxColumn_9.HeaderText = "id";
		this.dataGridViewTextBoxColumn_9.Name = "dataGridViewTextBoxColumn7";
		this.dataGridViewTextBoxColumn_9.ReadOnly = true;
		this.dataGridViewTextBoxColumn_9.Visible = false;
		this.dataGridViewTextBoxColumn_10.DataPropertyName = "idMemorandum";
		this.dataGridViewTextBoxColumn_10.HeaderText = "idMemorandum";
		this.dataGridViewTextBoxColumn_10.Name = "dataGridViewTextBoxColumn8";
		this.dataGridViewTextBoxColumn_10.Visible = false;
		this.dataGridViewTextBoxColumn_11.DataPropertyName = "typeWorker";
		this.dataGridViewTextBoxColumn_11.HeaderText = "typeWorker";
		this.dataGridViewTextBoxColumn_11.Name = "dataGridViewTextBoxColumn9";
		this.dataGridViewTextBoxColumn_11.Visible = false;
		this.openFileDialog_0.Multiselect = true;
		this.backgroundWorker_0.DoWork += this.backgroundWorker_0_DoWork;
		this.backgroundWorker_0.RunWorkerCompleted += this.backgroundWorker_0_RunWorkerCompleted;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(840, 577);
		base.Controls.Add(this.tableLayoutPanel_1);
		base.Name = "FormSendMemorandum";
		base.StartPosition = FormStartPosition.CenterScreen;
		this.Text = "Отправка документа";
		base.FormClosing += this.Form37_FormClosing;
		base.Load += this.Form37_Load;
		((ISupportInitialize)this.bindingSource_4).EndInit();
		((ISupportInitialize)this.class255_0).EndInit();
		this.tabControl_0.ResumeLayout(false);
		this.tabPage_0.ResumeLayout(false);
		((ISupportInitialize)this.dataGridView_0).EndInit();
		((ISupportInitialize)this.bindingSource_0).EndInit();
		((ISupportInitialize)this.bindingSource_1).EndInit();
		this.ggJowlBkuPL.ResumeLayout(false);
		((ISupportInitialize)this.dataGridView_1).EndInit();
		((ISupportInitialize)this.bindingSource_8).EndInit();
		((ISupportInitialize)this.bindingSource_2).EndInit();
		this.tabPage_1.ResumeLayout(false);
		((ISupportInitialize)this.MfmowWfuJrX).EndInit();
		((ISupportInitialize)this.bindingSource_9).EndInit();
		((ISupportInitialize)this.bindingSource_3).EndInit();
		this.tabPage_4.ResumeLayout(false);
		this.tableLayoutPanel_3.ResumeLayout(false);
		((ISupportInitialize)this.dataGridView_5).EndInit();
		((ISupportInitialize)this.bindingSource_10).EndInit();
		((ISupportInitialize)this.bindingSource_11).EndInit();
		this.tabControl_1.ResumeLayout(false);
		this.tabPage_2.ResumeLayout(false);
		this.tableLayoutPanel_0.ResumeLayout(false);
		this.tableLayoutPanel_0.PerformLayout();
		this.toolStrip_0.ResumeLayout(false);
		this.toolStrip_0.PerformLayout();
		((ISupportInitialize)this.dataGridView_2).EndInit();
		((ISupportInitialize)this.bindingSource_5).EndInit();
		this.tabPage_3.ResumeLayout(false);
		this.tableLayoutPanel_2.ResumeLayout(false);
		this.tableLayoutPanel_2.PerformLayout();
		((ISupportInitialize)this.dataGridView_4).EndInit();
		((ISupportInitialize)this.bindingSource_7).EndInit();
		this.toolStrip_1.ResumeLayout(false);
		this.toolStrip_1.PerformLayout();
		((ISupportInitialize)this.dataGridView_3).EndInit();
		((ISupportInitialize)this.bindingSource_6).EndInit();
		this.tableLayoutPanel_1.ResumeLayout(false);
		this.tableLayoutPanel_1.PerformLayout();
		this.jiHowLcbiwf.ResumeLayout(false);
		this.jiHowLcbiwf.PerformLayout();
		base.ResumeLayout(false);
	}

	[CompilerGenerated]
	private bool method_30(Class255.Class460 class460_0)
	{
		return (from r in this.class255_0.tJ_MemWorker
		where r.typeWorker == 1300
		select r into r1
		select r1.idWorker).Contains(class460_0.Id);
	}

	[CompilerGenerated]
	private bool method_31(Class255.Class460 class460_0)
	{
		return (from r in this.class255_0.tJ_MemWorker
		where r.typeWorker == 1297
		select r into r1
		select r1.idWorker).Contains(class460_0.Id);
	}

	[CompilerGenerated]
	private bool method_32(Class255.Class460 class460_0)
	{
		return (from r in this.class255_0.tJ_MemWorker
		where r.typeWorker == 1298
		select r into r1
		select r1.idWorker).Contains(class460_0.Id);
	}

	[CompilerGenerated]
	private void method_33()
	{
		this.label_4.Text = this.class605_0.SignDate + "/" + this.class605_0.RgNum;
	}

	internal static void JuN2rJOSUqP7wM18S9pE(Form form_0, bool bool_0)
	{
		form_0.Dispose(bool_0);
	}

	[CompilerGenerated]
	private int nuJobVrqPl0;

	[CompilerGenerated]
	private int int_0;

	[CompilerGenerated]
	private int int_1;

	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private StateFormCreate stateFormCreate_0;

	private Enum26 enum26_0;

	private EISSettings pJbobrNgebT;

	private Class605 class605_0;

	private Class606 class606_0;

	private List<string> list_0;

	private readonly string string_1;

	private readonly string uMvobSoyZvu;

	private Label label_0;

	private TextBox textBox_0;

	private Label label_1;

	private TextBox textBox_1;

	private TabControl tabControl_0;

	private TabPage tabPage_0;

	private TabPage ggJowlBkuPL;

	private DataGridView dataGridView_0;

	private DataGridView dataGridView_1;

	private Button button_0;

	private Button button_1;

	private BindingSource bindingSource_0;

	private Class255 class255_0;

	private BindingSource bindingSource_1;

	private BindingSource bindingSource_2;

	private TabPage tabPage_1;

	private DataGridView MfmowWfuJrX;

	private BindingSource bindingSource_3;

	private BindingSource bindingSource_4;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_0;

	private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn_0;

	private TabControl tabControl_1;

	private TabPage tabPage_2;

	private Label label_2;

	private Label PeVowpgDlnO;

	private TabPage tabPage_3;

	private DataGridView dataGridView_2;

	private Label label_3;

	private TableLayoutPanel tableLayoutPanel_0;

	private ToolStrip toolStrip_0;

	private TableLayoutPanel tableLayoutPanel_1;

	private ToolStripButton toolStripButton_0;

	private ToolStripButton toolStripButton_1;

	private ToolStripButton toolStripButton_2;

	private Label label_4;

	private TableLayoutPanel tableLayoutPanel_2;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_3;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_4;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_5;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_6;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_7;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_8;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_9;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_10;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_11;

	private BindingSource bindingSource_5;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_12;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_13;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_14;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_15;

	private ToolStrip jiHowLcbiwf;

	private ToolStripButton toolStripButton_3;

	private OpenFileDialog openFileDialog_0;

	private ToolStripButton toolStripButton_4;

	private ToolStripSeparator toolStripSeparator_0;

	private BindingSource bindingSource_6;

	private DataGridView dataGridView_3;

	private DataGridView dataGridView_4;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_16;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_17;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_18;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_19;

	private ToolStrip toolStrip_1;

	private ToolStripButton toolStripButton_5;

	private ToolStripButton toolStripButton_6;

	private ToolStripSeparator toolStripSeparator_1;

	private ToolStripButton toolStripButton_7;

	private ToolStripButton toolStripButton_8;

	private BindingSource bindingSource_7;

	private BackgroundWorker backgroundWorker_0;

	private ProgressBar progressBar_0;

	private Button button_2;

	private TabPage tabPage_4;

	private TableLayoutPanel tableLayoutPanel_3;

	private Button button_3;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_20;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_21;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_22;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_23;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_24;

	private DataGridViewTextBoxColumn oEdoGsvuknR;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_25;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_1;

	private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn_1;

	private DataGridView dataGridView_5;

	private BindingSource bindingSource_8;

	private BindingSource bindingSource_9;

	private BindingSource bindingSource_10;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_2;

	private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn_2;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_26;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_27;

	private DataGridViewTextBoxColumn cpfoGteKiSP;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_3;

	private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn_3;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_28;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_29;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_30;

	private BindingSource bindingSource_11;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_4;
}
