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
using Constants;
using ControlsLbr.DataGridViewExcelFilter;
using DataSql;
using Documents.Properties;
using FormLbr;
using FormLbr.Classes;

namespace Documents.Forms.Memorandums
{
	public partial class FormMemorandumJournal : FormBase
	{
		public FormMemorandumJournal()
		{
			
			this.string_0 = Environment.GetFolderPath(Environment.SpecialFolder.Templates) + "\\LotusTemp\\";
			
			this.method_27();
			this.stateFormCreate_0 = StateFormCreate.View;
		}

		public FormMemorandumJournal(StateFormCreate state)
		{
			
			this.string_0 = Environment.GetFolderPath(Environment.SpecialFolder.Templates) + "\\LotusTemp\\";
			
			this.method_27();
			this.stateFormCreate_0 = state;
		}

		public StateFormCreate CreateState
		{
			get
			{
				return this.stateFormCreate_0;
			}
			set
			{
				this.stateFormCreate_0 = value;
			}
		}

		public int IdTU { get; set; }

		private void backgroundWorker_0_DoWork(object sender, DoWorkEventArgs e)
		{
			this.method_17(true);
			this.method_7("Загружаются данные из \"Босс референт\".");
			try
			{
				this.method_0();
			}
			catch (SqlException ex)
			{
				MessageBox.Show(ex.StackTrace);
			}
			catch (Exception ex2)
			{
				MessageBox.Show(ex2.StackTrace);
			}
			this.method_7("Загрузка успешно завершена.");
		}

		private void backgroundWorker_0_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			RowsLoading rowsLoading = (RowsLoading)e.UserState;
			this.method_7(string.Concat(new object[]
			{
				"Всего: ",
				rowsLoading.Count,
				"; Добавлено: ",
				rowsLoading.Loaded.ToString(),
				"Обновлено: ",
				rowsLoading.Exists.ToString()
			}));
		}

		private void backgroundWorker_0_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.toolStripButton_0.Enabled = true;
			this.method_17(false);
			this.method_24(true);
		}

		private void toolStripButton_0_Click(object sender, EventArgs e)
		{
			this.toolStripButton_0.Enabled = false;
			this.class603_0 = this.method_12();
			if (this.class603_0 == null)
			{
				this.toolStripButton_0.Enabled = true;
				return;
			}
			this.backgroundWorker_0.RunWorkerAsync();
		}

		private bool method_0()
		{
			Class603 @class = this.method_12();
			this.method_7("Загружаем служебные записки...");
			List<Class605> list = @class.uybCtvHfSxo("", true);
			if (list.Count<Class605>() == 0)
			{
				return false;
			}
			this.method_7("Загружаем поручения...");
			List<Class604> source = @class.uubCttfhrkq("", true);
			this.method_7("Обновляем данные...");
			this.method_7("Загружаем пользователей Босс Референт...");
			DataTable dataTable_ = base.SelectSqlData("vJ_BossUser", true, "");
			using (List<Class605>.Enumerator enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					Class605 memorandum = enumerator.Current;
					int num = -1;
					if (!(from r in this.class255_0.tJ_Memorandum
					select r.UniversalID).Contains(memorandum.UniversalID))
					{
						num = this.method_1(memorandum, num);
					}
					else
					{
						num = (from r in this.class255_0.tJ_Memorandum
						where r.UniversalID == memorandum.UniversalID
						select r).First<Class255.Class462>().id;
						this.method_2(memorandum);
					}
					if (num == -1)
					{
						return false;
					}
					this.method_5(num, (Enum25)1300, dataTable_, memorandum.CorrName);
					this.method_5(num, (Enum25)1297, dataTable_, memorandum.IO_InP);
					this.method_5(num, (Enum25)1298, dataTable_, memorandum.Reviewers);
					this.method_4(memorandum.rrwCvexvfrc(), (Enum24)1, num);
					this.method_3(memorandum.UniversalID, num, (from r in source
					where r.ctb_InheritedID == memorandum.UniversalID
					select r).ToList<Class604>(), -1, dataTable_);
				}
			}
			return true;
		}

		private int method_1(Class605 class605_0, int int_1)
		{
			this.method_7("Вставляем данные в таблицу разрешений...");
			string text = "idWorker, Deleted, UniversalID";
			string text2 = string.Format("{0}, 0,'{1}'", this.method_9(), class605_0.UniversalID);
			if (class605_0.Status != "")
			{
				text += ",[Status]";
				text2 += string.Format(",{0}", this.method_11(class605_0.Status));
			}
			if (class605_0.Body_C != "")
			{
				text += ",[Body_C]";
				text2 += string.Format(",'{0}'", class605_0.Body_C);
			}
			if (class605_0.Subject != "")
			{
				text += ",[Subject]";
				text2 += string.Format(",'{0}'", class605_0.Subject);
			}
			if (class605_0.RespDate.Length >= 10)
			{
				text += ",[RespDate]";
				text2 += string.Format(",CONVERT(SMALLDATETIME,'{0}',101)", this.method_8(class605_0.RespDate));
			}
			if (class605_0.SignDate.Length >= 10)
			{
				text += ",[SignDate]";
				text2 += string.Format(",CONVERT(SMALLDATETIME,'{0}',101)", this.method_8(class605_0.SignDate));
			}
			if (class605_0.RgNum != "")
			{
				text += ",[RgNum]";
				text2 += string.Format(",'{0}'", class605_0.RgNum);
			}
			if (class605_0.RespNum != "")
			{
				text += ",[RespNum]";
				text2 += string.Format(",'{0}'", class605_0.RespNum);
			}
			if (class605_0.CorrName != "")
			{
				text += ",[CorrName]";
				text2 += string.Format(",'{0}'", class605_0.CorrName);
			}
			if (class605_0.ctbDateCreate.Length >= 10)
			{
				text += string.Format(",[ctbDateCreate]", new object[0]);
				text2 += string.Format(",CONVERT(SMALLDATETIME,'{0}',101)", this.method_8(class605_0.ctbDateCreate));
			}
			string text3 = string.Format("insert into tJ_Memorandum ({0}) values ({1})", text, text2);
			this.toolStripTextBox_0.Text = text3;
			return this.method_13(text3, "tJ_Memorandum");
		}

		private void method_2(Class605 class605_0)
		{
			this.method_7("Обновляем данные в таблице разрешений...");
			string text = string.Format("update tJ_Memorandum set UniversalID = '{0}'", class605_0.UniversalID);
			if (class605_0.RespDate.Length >= 10)
			{
				text += string.Format(",[RespDate] = CONVERT(SMALLDATETIME,'{0}',101)", this.method_8(class605_0.RespDate));
			}
			if (class605_0.Status != "")
			{
				text += string.Format(",[Status] = '{0}'", this.method_11(class605_0.Status));
			}
			if (class605_0.Subject != "")
			{
				text += string.Format(",[Subject] = '{0}'", class605_0.Subject);
			}
			if (class605_0.Body_C != "")
			{
				text += string.Format(",[Body_C] = '{0}'", class605_0.Body_C);
			}
			if (class605_0.SignDate.Length >= 10)
			{
				text += string.Format(",[SignDate] = CONVERT(SMALLDATETIME,'{0}',101)", this.method_8(class605_0.SignDate));
			}
			if (class605_0.RgNum != "")
			{
				text += string.Format(",[RgNum] = '{0}'", class605_0.RgNum);
			}
			if (class605_0.RespNum != "")
			{
				text += string.Format(",[RespNum] = '{0}'", class605_0.RespNum);
			}
			if (class605_0.CorrName != "")
			{
				text += string.Format(",[CorrName] = '{0}'", class605_0.CorrName);
			}
			text += string.Format(" WHERE UniversalID = '{0}'", class605_0.UniversalID);
			this.method_16(this.SqlSettings, text);
		}

		private void method_3(string string_1, int int_1, List<Class604> list_0, int int_2, DataTable dataTable_0)
		{
			foreach (Class604 @class in list_0)
			{
				this.class255_0.tJ_MemCommission.Rows.Clear();
				base.SelectSqlData(this.class255_0, this.class255_0.tJ_MemCommission, true, string.Format("WHERE UNID = '{0}' AND Deleted = 0", @class.UniversalID));
				int int_3;
				if (this.class255_0.tJ_MemCommission.Count<Class255.Class467>() > 0)
				{
					this.method_7("Обновляем данные в таблице поручений...");
					string text = string.Format("update tJ_MemCommission set UNID = '{0}'", @class.UniversalID);
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
						text += string.Format(",[DateFact] = CONVERT(SMALLDATETIME,'{0}',101)", this.method_8(@class.ctbDateFact));
					}
					if (@class.ctbComment != "")
					{
						text += string.Format(",[Comment] = '{0}'", @class.ctbComment);
					}
					if (@class.ctbExecutor != "")
					{
						text += string.Format(",[Performer] = '{0}'", this.method_6(@class.ctbExecutor, dataTable_0));
					}
					if (@class.ctbStatus != "")
					{
						text += string.Format(",[Status] = '{0}'", this.method_10(@class));
					}
					text += string.Format(" WHERE UNID = '{0}'", @class.UniversalID);
					int_3 = (int)base.SelectSqlData("tJ_MemCommission", true, string.Format(" WHERE UNID = '{0}'", @class.UniversalID)).Rows[0]["id"];
					this.method_16(this.SqlSettings, text);
				}
				else
				{
					this.method_7("Вставляем данные в таблицу поручений...");
					string text2 = "idMemorandum, UNID, Deleted,Comment";
					string text3 = string.Format("{0},'{1}', 0, '{2}'", int_1, @class.UniversalID, @class.ctbComment);
					if (@class.ctbDateFact.Length >= 10)
					{
						text2 += ",[DateFact]";
						text3 += string.Format(",CONVERT(SMALLDATETIME,'{0}',101)", this.method_8(@class.ctbDateFact));
					}
					if (@class.ctbExecutor != "")
					{
						text2 += ",[Performer]";
						text3 += string.Format(",{0}", this.method_6(@class.ctbExecutor, dataTable_0));
					}
					if (@class.ctbStatus != "")
					{
						text2 += ",[Status]";
						text3 += string.Format(",{0}", this.method_10(@class));
					}
					string string_2 = string.Format("insert into tJ_MemCommission ({0}) values ({1})", text2, text3);
					int_3 = this.method_13(string_2, "tJ_MemCommission");
				}
				this.method_4(@class.method_0(), (Enum24)2, int_3);
			}
		}

		private void method_4(List<Class607> list_0, Enum24 enum24_0, int int_1)
		{
			if (list_0 == null)
			{
				return;
			}
			Class255 @class = new Class255();
			base.SelectSqlData(@class, @class.tJ_MemFiles, true, string.Format("WHERE TypeDoc = {0} AND idDocument = {1} AND Deleted = 0", (int)enum24_0, int_1));
			using (List<Class607>.Enumerator enumerator = list_0.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					Class607 file = enumerator.Current;
					EnumerableRowCollection<Class255.Class461> source = from r in @class.tJ_MemFiles
					where r.Name == file.Name
					select r;
					if (source.Count<Class255.Class461>() > 0)
					{
						this.method_7("Обновляем данные в таблице файлов...");
						Class255.Class461 class2 = source.First<Class255.Class461>();
						class2.Deleted = false;
						class2.File = file.method_6();
						class2.idDocument = int_1;
						if (file.method_4() > new DateTime(1970, 1, 1))
						{
							class2.LastChange = file.method_4();
						}
						class2.Name = file.Name;
						class2.TypeDoc = (int)enum24_0;
						class2.EndEdit();
					}
					else
					{
						this.method_7("Вставляем данные в таблицу файлов...");
						Class255.Class461 class3 = @class.tJ_MemFiles.method_5();
						class3.Deleted = false;
						class3.File = file.method_6();
						class3.idDocument = int_1;
						if (file.method_4() > new DateTime(1970, 1, 1))
						{
							class3.LastChange = file.method_4();
						}
						class3.Name = file.Name;
						class3.TypeDoc = (int)enum24_0;
						class3.EndEdit();
						@class.tJ_MemFiles.method_0(class3);
					}
					base.InsertSqlData(@class.tJ_MemFiles);
					base.UpdateSqlData(@class.tJ_MemFiles);
				}
			}
		}

		private void method_5(int int_1, Enum25 enum25_0, DataTable dataTable_0, string string_1)
		{
			this.method_7("Вставляем данные в таблицу пользователей...");
			Class255 @class = new Class255();
			base.SelectSqlData(@class, @class.tJ_MemWorker, true, string.Format("WHERE Deleted = 0 AND idMemorandum = {0} AND typeWorker = {1}", int_1, (int)enum25_0));
			List<string> personsArrayString = string_1.Split(new char[]
			{
				';'
			}, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
			EnumerableRowCollection<int> personArrayInt = from row in dataTable_0.AsEnumerable()
			where row["FullFIO"] != DBNull.Value && personsArrayString.Contains(row.Field("FullFIO"))
			select row.Field("id");
			(from person in @class.tJ_MemWorker
			where !personArrayInt.Contains(person.idWorker)
			select person).ToList<Class255.Class464>().ForEach(delegate(Class255.Class464 r)
			{
				r.Deleted = true;
			});
			foreach (int num in personArrayInt)
			{
				if (!(from r in @class.tJ_MemWorker
				select r.idWorker).Contains(num))
				{
					Class255.Class464 class2 = @class.tJ_MemWorker.method_5();
					class2.idMemorandum = int_1;
					class2.idWorker = num;
					class2.typeWorker = (int)enum25_0;
					class2.Deleted = false;
					class2.EndEdit();
					@class.tJ_MemWorker.method_0(class2);
				}
			}
			base.InsertSqlData(@class.tJ_MemWorker);
		}

		private int method_6(string string_1, DataTable dataTable_0)
		{
			EnumerableRowCollection<int> source = from row in dataTable_0.AsEnumerable()
			where row["FullFIO"] != DBNull.Value && string_1.Contains(row.Field("FullFIO"))
			select row.Field("id");
			if (source.Count<int>() > 0)
			{
				return source.First<int>();
			}
			return -1;
		}

		private void method_7(string string_1)
		{
			if (this.label_0.InvokeRequired)
			{
				Dispatcher.Invoke(this, delegate
				{
					this.label_0.Text = string_1;
				});
				return;
			}
			this.label_0.Text = string_1;
		}

		private string method_8(string string_1)
		{
			if (string.IsNullOrEmpty(string_1) && string_1.Length < 10)
			{
				return null;
			}
			string[] array = string_1.Substring(0, 10).Split(new char[]
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

		private int method_9()
		{
			DataTable dataTable = base.SelectSqlData("tUser", true, "WHERE [Login] LIKE SYSTEM_USER");
			if (dataTable.Rows.Count > 0)
			{
				return (int)dataTable.Rows[0]["IDUser"];
			}
			return -1;
		}

		private int method_10(Class604 class604_0)
		{
			DataTable dataTable = base.SelectSqlData("tR_Classifier", true, "WHERE ParentKey = ';TechConnect;Commission;' AND [Comment] LIKE '" + class604_0.Header_Title + "' AND Deleted = 0");
			if (dataTable.Rows.Count > 0)
			{
				return (int)dataTable.Rows[0]["Id"];
			}
			return -1;
		}

		private int method_11(string string_1)
		{
			DataTable dataTable = base.SelectSqlData("tR_Classifier", true, "WHERE ParentKey = ';TechConnect;StatusMemorandum;' AND [Comment] LIKE '" + string_1 + "' AND Deleted = 0");
			if (dataTable.Rows.Count > 0)
			{
				return (int)dataTable.Rows[0]["Id"];
			}
			return -1;
		}

		private Class603 method_12()
		{
			Class603 result;
			try
			{
				this.eissettings_0 = this.method_15();
				if (!this.eissettings_0.FrmTUSettings.IsSavePassport || this.eissettings_0.FrmTUSettings.Password == "")
				{
					Form36 form = new Form36();
					form.SqlSettings = this.SqlSettings;
					form.method_1(this.eissettings_0.FrmTUSettings.IsSavePassport);
					form.Password = this.eissettings_0.FrmTUSettings.Password;
					if (form.ShowDialog() != DialogResult.OK)
					{
						return null;
					}
					this.eissettings_0.FrmTUSettings.IsSavePassport = form.method_0();
					this.eissettings_0.FrmTUSettings.Password = form.Password;
					new AppConfig().SaveAppConfig(this.eissettings_0);
				}
				result = new Class603(this.eissettings_0.FrmTUSettings.Password);
			}
			catch (Exception)
			{
				return null;
			}
			return result;
		}

		private int method_13(string string_1, string string_2)
		{
			SqlDataConnect sqlDataConnect = new SqlDataConnect();
			int result = -1;
			try
			{
				sqlDataConnect.OpenConnection(this.SqlSettings);
				SqlTransaction sqlTransaction = sqlDataConnect.Connection.BeginTransaction();
				SqlCommand sqlCommand = new SqlCommand(string_1, sqlDataConnect.Connection);
				sqlCommand.Transaction = sqlTransaction;
				sqlCommand.ExecuteNonQuery();
				sqlCommand.CommandText = "select IDENT_CURRENT('" + string_2 + "')";
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

		private bool method_14()
		{
			foreach (object obj in ((IEnumerable)this.dataGridViewExcelFilter_0.Rows))
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
				if (dataGridViewRow.Cells["isSelected"].Value != null && (bool)dataGridViewRow.Cells["isSelected"].Value)
				{
					return true;
				}
			}
			return false;
		}

		private EISSettings method_15()
		{
			AppConfig appConfig = new AppConfig();
			this.eissettings_0 = appConfig.OpenAppConfig();
			if (this.eissettings_0.FrmTUSettings == null)
			{
				FormTUSettings formTUSettings = new FormTUSettings();
				formTUSettings.IsSavePassport = false;
				formTUSettings.Password = "";
				this.eissettings_0.FrmTUSettings = formTUSettings;
				appConfig.SaveAppConfig(this.eissettings_0);
			}
			return this.eissettings_0;
		}

		private void method_16(SQLSettings sqlsettings_0, string string_1)
		{
			SqlDataConnect sqlDataConnect = new SqlDataConnect();
			try
			{
				sqlDataConnect.OpenConnection(sqlsettings_0);
				new SqlCommand(string_1, sqlDataConnect.Connection).ExecuteNonQuery();
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

		private void method_17(bool bool_0)
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

		private void method_18()
		{
			using (SqlConnection sqlConnection = new SqlConnection(this.SqlSettings.GetConnectionString()))
			{
				if (this.bindingSource_0.Current != null)
				{
					this.class255_0.tJ_MemFiles.Clear();
					string str = string.Format("WHERE (TypeDoc = 1 AND idDocument = {0})", (int)((DataRowView)this.bindingSource_0.Current)["id"]) + ((this.bindingSource_3.Current != null) ? string.Format(" OR (TypeDoc = 2 AND idDocument = {0})", (int)((DataRowView)this.bindingSource_3.Current)["id"]) : "");
					sqlConnection.Open();
					new SqlDataAdapter(new SqlCommand("SELECT [id],[idDocument],[TypeDoc],[Name],[Size],[LastChange],[Deleted] FROM tJ_MemFiles " + str, sqlConnection)).Fill(this.class255_0.tJ_MemFiles);
				}
				else
				{
					this.class255_0.tJ_MemFiles.Clear();
				}
			}
		}

		private void method_19()
		{
			if (this.bindingSource_0.Current != null)
			{
				Form37 form = new Form37();
				form.SqlSettings = this.SqlSettings;
				form.MdiParent = base.MdiParent;
				form.idUser = this.method_9();
				form.method_3((int)((DataRowView)this.bindingSource_0.Current)["id"]);
				form.method_5(StateFormCreate.Edit);
				form.FormClosed += this.method_20;
				form.Show();
			}
		}

		private void method_20(object sender, FormClosedEventArgs e)
		{
			this.method_23(((Form37)sender).method_2());
		}

		private void method_21()
		{
			if (this.bindingSource_0.Current != null)
			{
				Form37 form = new Form37();
				form.SqlSettings = this.SqlSettings;
				form.MdiParent = base.MdiParent;
				form.idUser = this.method_9();
				form.method_3((int)((DataRowView)this.bindingSource_0.Current)["id"]);
				form.method_5(StateFormCreate.View);
				form.Show();
			}
		}

		private void method_22()
		{
			if (this.bindingSource_0.Current != null && MessageBox.Show("Вы действительно хотите удалить текущую запись?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				EnumerableRowCollection<Class255.Class462> source = this.class255_0.tJ_Memorandum.Where(new Func<Class255.Class462, bool>(this.method_28));
				if (source.Count<Class255.Class462>() > 0)
				{
					source.First<Class255.Class462>().Deleted = true;
					if (base.UpdateSqlData(this.class255_0.tJ_Memorandum))
					{
						this.class255_0.tJ_Memorandum.AcceptChanges();
						MessageBox.Show("Запись успешно удалена.");
						this.method_24(false);
					}
				}
			}
		}

		private void method_23(int int_1)
		{
			this.method_24(false);
			this.bindingSource_0.Position = this.bindingSource_0.Find("id", int_1);
		}

		private void method_24(bool bool_0)
		{
			try
			{
				bool_0 = (bool_0 ? (this.bindingSource_0.Current != null) : bool_0);
				int num = -1;
				if (bool_0)
				{
					num = (int)((DataRowView)this.bindingSource_0.Current)["id"];
				}
				this.bindingSource_0.RaiseListChangedEvents = true;
				this.bindingSource_0.CurrentChanged -= this.bindingSource_0_CurrentChanged;
				base.SelectSqlData(this.class255_0, this.class255_0.tJ_Memorandum, true, string.Format("WHERE idTehConnect IS NULL AND Deleted = 0", this.method_9()));
				base.SelectSqlData(this.class255_0, this.class255_0.vJ_Memorandum, true, string.Format("WHERE idTehConnect IS NULL AND Deleted = 0", this.method_9()));
				this.bindingSource_0.CurrentChanged += this.bindingSource_0_CurrentChanged;
				this.bindingSource_0.RaiseListChangedEvents = false;
				this.bindingSource_0_CurrentChanged(this.bindingSource_0, new EventArgs());
				if (bool_0)
				{
					this.bindingSource_0.Position = this.bindingSource_0.Find("id", num);
				}
			}
			catch (Exception)
			{
			}
		}

		private void method_25(BindingSource bindingSource_4, string string_1)
		{
			if (bindingSource_4.Current != null)
			{
				Class255.Class461 @class = (Class255.Class461)((DataRowView)bindingSource_4.Current).Row;
				string name = @class.Name;
				string newFileNameIsExists = FileBinary.GetNewFileNameIsExists(string_1, name, false);
				DateTime lastChange = @class.LastChange;
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
				fileBinary.SaveToDisk(string_1);
				Process.Start(string_1 + "\\" + fileBinary.Name);
			}
		}

		private void toolStripButton_1_Click(object sender, EventArgs e)
		{
		}

		private void toolStripButton_2_Click(object sender, EventArgs e)
		{
			this.method_19();
		}

		private void toolStripButton_3_Click(object sender, EventArgs e)
		{
			this.method_21();
		}

		private void toolStripButton_4_Click(object sender, EventArgs e)
		{
			this.method_22();
		}

		private void toolStripButton_5_Click(object sender, EventArgs e)
		{
			this.method_24(true);
		}

		private void FormMemorandumJournal_Load(object sender, EventArgs e)
		{
			if (!Directory.Exists(this.string_0))
			{
				Directory.CreateDirectory(this.string_0);
			}
			this.method_24(false);
			if (this.stateFormCreate_0 == StateFormCreate.View)
			{
				this.toolStripButton_1.Visible = false;
				this.dataGridViewFilterCheckBoxColumn_0.Visible = false;
				this.dataGridViewExcelFilter_0.Refresh();
				this.button_0.Visible = false;
				return;
			}
			this.toolStripButton_1.Visible = false;
			this.toolStripButton_2.Visible = false;
			this.toolStripSeparator_0.Visible = false;
			this.toolStripButton_4.Visible = false;
			this.toolStripSeparator_1.Visible = false;
		}

		private void FormMemorandumJournal_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.stateFormCreate_0 != StateFormCreate.View && base.DialogResult == DialogResult.OK)
			{
				if (!this.method_14())
				{
					MessageBox.Show("Не выбрано ни одной строки.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					e.Cancel = true;
					return;
				}
				string text = "";
				foreach (object obj in ((IEnumerable)this.dataGridViewExcelFilter_0.Rows))
				{
					DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
					if (dataGridViewRow.Cells["isSelected"].Value != null && (bool)dataGridViewRow.Cells["isSelected"].Value)
					{
						text = text + dataGridViewRow.Cells["idDataGridViewTextBoxColumn"].Value.ToString() + ",";
					}
				}
				if (text.Length > 0)
				{
					text = text.Remove(text.LastIndexOf(','));
					base.SelectSqlData(this.class255_0, this.class255_0.tJ_Memorandum, true, "WHERE id IN (" + text + ") AND Deleted = 0");
					foreach (Class255.Class462 @class in this.class255_0.tJ_Memorandum)
					{
						@class.idTehConnect = this.IdTU;
						@class.EndEdit();
					}
					base.UpdateSqlData(this.class255_0, this.class255_0.tJ_Memorandum);
				}
			}
			if (this.class603_0 != null)
			{
				this.class603_0.method_25();
			}
		}

		private void button_0_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		private void button_1_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void dataGridViewExcelFilter_0_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
		}

		private void bindingSource_3_CurrentChanged(object sender, EventArgs e)
		{
			this.method_18();
		}

		private void bindingSource_0_CurrentChanged(object sender, EventArgs e)
		{
			if (this.bindingSource_0.Current != null)
			{
				this.toolStripButton_2.Enabled = (((DataRowView)this.bindingSource_0.Current)["Status"].ToString() == "Черновик" && (int)((DataRowView)this.bindingSource_0.Current)["idWorker"] == this.method_9());
			}
		}

		private void method_26(object sender, DataGridViewCellEventArgs e)
		{
			if (((DataGridView)sender).Name == "dgvFileMemorandum")
			{
				this.method_25(this.bindingSource_2, this.string_0);
			}
			if (((DataGridView)sender).Name == "dgvFileCommission")
			{
				this.method_25(this.bindingSource_1, this.string_0);
			}
		}

		private void dataGridViewExcelFilter_0_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex != -1 && e.RowIndex != -1 && this.bindingSource_0.Current != null)
			{
				if (this.toolStripButton_2.Enabled)
				{
					this.method_19();
					return;
				}
				this.method_21();
			}
		}

		private void method_27()
		{
			this.icontainer_0 = new Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FormMemorandumJournal));
			DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
			this.tableLayoutPanel_0 = new TableLayoutPanel();
			this.toolStrip_0 = new ToolStrip();
			this.toolStripButton_1 = new ToolStripButton();
			this.toolStripButton_2 = new ToolStripButton();
			this.toolStripButton_3 = new ToolStripButton();
			this.toolStripSeparator_0 = new ToolStripSeparator();
			this.toolStripButton_4 = new ToolStripButton();
			this.toolStripSeparator_1 = new ToolStripSeparator();
			this.toolStripButton_5 = new ToolStripButton();
			this.toolStripSeparator_2 = new ToolStripSeparator();
			this.toolStripButton_0 = new ToolStripButton();
			this.toolStripTextBox_0 = new ToolStripTextBox();
			this.button_0 = new Button();
			this.button_1 = new Button();
			this.dataGridViewExcelFilter_0 = new DataGridViewExcelFilter();
			this.dataGridViewFilterCheckBoxColumn_0 = new DataGridViewFilterCheckBoxColumn();
			this.dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_3 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_4 = new DataGridViewTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_0 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_1 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_2 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_3 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewTextBoxColumn_5 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_6 = new DataGridViewTextBoxColumn();
			this.YnAoeMfxeTk = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewTextBoxColumn_7 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_8 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_9 = new DataGridViewTextBoxColumn();
			this.dataGridViewCheckBoxColumn_0 = new DataGridViewCheckBoxColumn();
			this.bindingSource_0 = new BindingSource(this.icontainer_0);
			this.class255_0 = new Class255();
			this.progressBar_0 = new ProgressBar();
			this.bindingSource_2 = new BindingSource(this.icontainer_0);
			this.bindingSource_1 = new BindingSource(this.icontainer_0);
			this.bindingSource_3 = new BindingSource(this.icontainer_0);
			this.backgroundWorker_0 = new BackgroundWorker();
			this.label_0 = new Label();
			this.tableLayoutPanel_0.SuspendLayout();
			this.toolStrip_0.SuspendLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_0).BeginInit();
			((ISupportInitialize)this.bindingSource_0).BeginInit();
			((ISupportInitialize)this.class255_0).BeginInit();
			((ISupportInitialize)this.bindingSource_2).BeginInit();
			((ISupportInitialize)this.bindingSource_1).BeginInit();
			((ISupportInitialize)this.bindingSource_3).BeginInit();
			base.SuspendLayout();
			this.tableLayoutPanel_0.ColumnCount = 4;
			this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 268f));
			this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 125f));
			this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 117f));
			this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20f));
			this.tableLayoutPanel_0.Controls.Add(this.toolStrip_0, 0, 0);
			this.tableLayoutPanel_0.Controls.Add(this.button_0, 2, 3);
			this.tableLayoutPanel_0.Controls.Add(this.button_1, 3, 3);
			this.tableLayoutPanel_0.Controls.Add(this.dataGridViewExcelFilter_0, 0, 1);
			this.tableLayoutPanel_0.Controls.Add(this.progressBar_0, 0, 3);
			this.tableLayoutPanel_0.Controls.Add(this.label_0, 1, 3);
			this.tableLayoutPanel_0.Dock = DockStyle.Fill;
			this.tableLayoutPanel_0.Location = new Point(0, 0);
			this.tableLayoutPanel_0.Name = "tlpGeneral";
			this.tableLayoutPanel_0.RowCount = 4;
			this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Absolute, 26f));
			this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Percent, 70.43189f));
			this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Percent, 29.56811f));
			this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Absolute, 41f));
			this.tableLayoutPanel_0.Size = new Size(843, 440);
			this.tableLayoutPanel_0.TabIndex = 0;
			this.tableLayoutPanel_0.SetColumnSpan(this.toolStrip_0, 4);
			this.toolStrip_0.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripButton_1,
				this.toolStripButton_2,
				this.toolStripButton_3,
				this.toolStripSeparator_0,
				this.toolStripButton_4,
				this.toolStripSeparator_1,
				this.toolStripButton_5,
				this.toolStripSeparator_2,
				this.toolStripButton_0,
				this.toolStripTextBox_0
			});
			this.toolStrip_0.Location = new Point(0, 0);
			this.toolStrip_0.Name = "tsGeneral";
			this.toolStrip_0.Size = new Size(843, 25);
			this.toolStrip_0.TabIndex = 1;
			this.toolStrip_0.Text = "toolStrip1";
			this.toolStripButton_1.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_1.Image = Resources.ElementAdd;
			this.toolStripButton_1.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_1.Name = "tsbMemorandumAdd";
			this.toolStripButton_1.Size = new Size(23, 22);
			this.toolStripButton_1.Text = "Добавить";
			this.toolStripButton_1.Click += this.toolStripButton_1_Click;
			this.toolStripButton_2.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_2.Image = Resources.ElementEdit;
			this.toolStripButton_2.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_2.Name = "tsbMemorandumEdit";
			this.toolStripButton_2.Size = new Size(23, 22);
			this.toolStripButton_2.Text = "Редактировать";
			this.toolStripButton_2.Click += this.toolStripButton_2_Click;
			this.toolStripButton_3.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_3.Image = Resources.ElementInformation;
			this.toolStripButton_3.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_3.Name = "tsbMemorandumView";
			this.toolStripButton_3.Size = new Size(23, 22);
			this.toolStripButton_3.Text = "Открыть";
			this.toolStripButton_3.Click += this.toolStripButton_3_Click;
			this.toolStripSeparator_0.Name = "tssMemorandumDelete";
			this.toolStripSeparator_0.Size = new Size(6, 25);
			this.toolStripButton_4.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_4.Image = Resources.ElementDel;
			this.toolStripButton_4.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_4.Name = "tsbMemorandumDelete";
			this.toolStripButton_4.Size = new Size(23, 22);
			this.toolStripButton_4.Text = "Удалить";
			this.toolStripButton_4.Click += this.toolStripButton_4_Click;
			this.toolStripSeparator_1.Name = "tssLoadFromBoss";
			this.toolStripSeparator_1.Size = new Size(6, 25);
			this.toolStripButton_5.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_5.Image = Resources.refresh_16;
			this.toolStripButton_5.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_5.Name = "tsbMemorandumRefresh";
			this.toolStripButton_5.Size = new Size(23, 22);
			this.toolStripButton_5.Text = "Обновить";
			this.toolStripButton_5.Click += this.toolStripButton_5_Click;
			this.toolStripSeparator_2.Name = "toolStripSeparator1";
			this.toolStripSeparator_2.Size = new Size(6, 25);
			this.toolStripButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_0.Image = (Image)componentResourceManager.GetObject("tsbLoadFromBoss.Image");
			this.toolStripButton_0.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_0.Name = "tsbLoadFromBoss";
			this.toolStripButton_0.Size = new Size(23, 22);
			this.toolStripButton_0.Text = "Загрузка данных из \"Босс Референт\"";
			this.toolStripButton_0.Click += this.toolStripButton_0_Click;
			this.toolStripTextBox_0.Name = "toolStripTextBox1";
			this.toolStripTextBox_0.Size = new Size(800, 23);
			this.toolStripTextBox_0.Visible = false;
			this.button_0.Dock = DockStyle.Right;
			this.button_0.Location = new Point(616, 406);
			this.button_0.Margin = new Padding(3, 8, 15, 10);
			this.button_0.Name = "btnComplite";
			this.button_0.Size = new Size(95, 24);
			this.button_0.TabIndex = 2;
			this.button_0.Text = "Применить";
			this.button_0.UseVisualStyleBackColor = true;
			this.button_0.Click += this.button_0_Click;
			this.button_1.Dock = DockStyle.Left;
			this.button_1.Location = new Point(734, 406);
			this.button_1.Margin = new Padding(8, 8, 3, 10);
			this.button_1.Name = "btnCancel";
			this.button_1.Size = new Size(90, 24);
			this.button_1.TabIndex = 3;
			this.button_1.Text = "Отмена";
			this.button_1.UseVisualStyleBackColor = true;
			this.button_1.Click += this.button_1_Click;
			this.dataGridViewExcelFilter_0.AllowUserToAddRows = false;
			this.dataGridViewExcelFilter_0.AllowUserToDeleteRows = false;
			this.dataGridViewExcelFilter_0.AllowUserToOrderColumns = true;
			this.dataGridViewExcelFilter_0.AutoGenerateColumns = false;
			dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle.BackColor = SystemColors.Control;
			dataGridViewCellStyle.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
			this.dataGridViewExcelFilter_0.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
			this.dataGridViewExcelFilter_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewExcelFilter_0.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewFilterCheckBoxColumn_0,
				this.dataGridViewTextBoxColumn_0,
				this.dataGridViewTextBoxColumn_1,
				this.dataGridViewTextBoxColumn_2,
				this.dataGridViewTextBoxColumn_3,
				this.dataGridViewTextBoxColumn_4,
				this.dataGridViewFilterTextBoxColumn_0,
				this.dataGridViewFilterTextBoxColumn_1,
				this.dataGridViewFilterTextBoxColumn_2,
				this.dataGridViewFilterTextBoxColumn_3,
				this.dataGridViewTextBoxColumn_5,
				this.dataGridViewTextBoxColumn_6,
				this.YnAoeMfxeTk,
				this.dataGridViewTextBoxColumn_7,
				this.dataGridViewTextBoxColumn_8,
				this.dataGridViewTextBoxColumn_9,
				this.dataGridViewCheckBoxColumn_0
			});
			this.tableLayoutPanel_0.SetColumnSpan(this.dataGridViewExcelFilter_0, 4);
			this.dataGridViewExcelFilter_0.DataSource = this.bindingSource_0;
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = SystemColors.Window;
			dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
			this.dataGridViewExcelFilter_0.DefaultCellStyle = dataGridViewCellStyle2;
			this.dataGridViewExcelFilter_0.Dock = DockStyle.Fill;
			this.dataGridViewExcelFilter_0.Location = new Point(3, 29);
			this.dataGridViewExcelFilter_0.Name = "dgvMemorandums";
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = SystemColors.Control;
			dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
			this.dataGridViewExcelFilter_0.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.dataGridViewExcelFilter_0.RowHeadersVisible = false;
			this.dataGridViewExcelFilter_0.RowHeadersWidth = 21;
			this.tableLayoutPanel_0.SetRowSpan(this.dataGridViewExcelFilter_0, 2);
			this.dataGridViewExcelFilter_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewExcelFilter_0.Size = new Size(837, 366);
			this.dataGridViewExcelFilter_0.TabIndex = 4;
			this.dataGridViewExcelFilter_0.CellDoubleClick += this.dataGridViewExcelFilter_0_CellDoubleClick;
			this.dataGridViewExcelFilter_0.DataError += this.dataGridViewExcelFilter_0_DataError;
			this.dataGridViewFilterCheckBoxColumn_0.HeaderText = "";
			this.dataGridViewFilterCheckBoxColumn_0.Name = "isSelected";
			this.dataGridViewFilterCheckBoxColumn_0.Width = 30;
			this.dataGridViewTextBoxColumn_0.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_0.HeaderText = "id";
			this.dataGridViewTextBoxColumn_0.Name = "idDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_0.Visible = false;
			this.dataGridViewTextBoxColumn_1.DataPropertyName = "idTehConnect";
			this.dataGridViewTextBoxColumn_1.HeaderText = "idTehConnect";
			this.dataGridViewTextBoxColumn_1.Name = "idTehConnectDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_1.Visible = false;
			this.dataGridViewTextBoxColumn_2.DataPropertyName = "idWorker";
			this.dataGridViewTextBoxColumn_2.HeaderText = "idWorker";
			this.dataGridViewTextBoxColumn_2.Name = "idWorkerDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_2.Visible = false;
			this.dataGridViewTextBoxColumn_3.DataPropertyName = "UniversalID";
			this.dataGridViewTextBoxColumn_3.HeaderText = "UniversalID";
			this.dataGridViewTextBoxColumn_3.Name = "universalIDDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_3.Visible = false;
			this.dataGridViewTextBoxColumn_4.DataPropertyName = "ctb_InheritedID";
			this.dataGridViewTextBoxColumn_4.HeaderText = "ctb_InheritedID";
			this.dataGridViewTextBoxColumn_4.Name = "ctbInheritedIDDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_4.Visible = false;
			this.dataGridViewFilterTextBoxColumn_0.DataPropertyName = "Status";
			this.dataGridViewFilterTextBoxColumn_0.HeaderText = "Статус";
			this.dataGridViewFilterTextBoxColumn_0.Name = "statusDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_0.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_0.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_1.DataPropertyName = "StatusOrder";
			this.dataGridViewFilterTextBoxColumn_1.HeaderText = "Статус поручения";
			this.dataGridViewFilterTextBoxColumn_1.Name = "statusOrderDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_1.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_1.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_1.Visible = false;
			this.dataGridViewFilterTextBoxColumn_2.DataPropertyName = "RgNum";
			this.dataGridViewFilterTextBoxColumn_2.HeaderText = "Рег. номер";
			this.dataGridViewFilterTextBoxColumn_2.Name = "rgNumDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_2.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_2.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_2.Width = 150;
			this.dataGridViewFilterTextBoxColumn_3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewFilterTextBoxColumn_3.DataPropertyName = "Subject";
			this.dataGridViewFilterTextBoxColumn_3.HeaderText = "По вопросу";
			this.dataGridViewFilterTextBoxColumn_3.Name = "subjectDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_3.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_3.Resizable = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_5.DataPropertyName = "Body_C";
			this.dataGridViewTextBoxColumn_5.HeaderText = "Body_C";
			this.dataGridViewTextBoxColumn_5.Name = "bodyCDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_5.Visible = false;
			this.dataGridViewTextBoxColumn_6.DataPropertyName = "RespDate";
			this.dataGridViewTextBoxColumn_6.HeaderText = "RespDate";
			this.dataGridViewTextBoxColumn_6.Name = "respDateDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_6.Visible = false;
			this.YnAoeMfxeTk.DataPropertyName = "SignDate";
			this.YnAoeMfxeTk.HeaderText = "Дата подписи";
			this.YnAoeMfxeTk.Name = "signDateDataGridViewTextBoxColumn";
			this.YnAoeMfxeTk.ReadOnly = true;
			this.YnAoeMfxeTk.Resizable = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_7.DataPropertyName = "RespNum";
			this.dataGridViewTextBoxColumn_7.HeaderText = "RespNum";
			this.dataGridViewTextBoxColumn_7.Name = "respNumDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_7.Visible = false;
			this.dataGridViewTextBoxColumn_8.DataPropertyName = "CorrName";
			this.dataGridViewTextBoxColumn_8.HeaderText = "CorrName";
			this.dataGridViewTextBoxColumn_8.Name = "corrNameDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_8.Visible = false;
			this.dataGridViewTextBoxColumn_9.DataPropertyName = "ctbDateCreate";
			this.dataGridViewTextBoxColumn_9.HeaderText = "ctbDateCreate";
			this.dataGridViewTextBoxColumn_9.Name = "ctbDateCreateDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_9.Visible = false;
			this.dataGridViewCheckBoxColumn_0.DataPropertyName = "Deleted";
			this.dataGridViewCheckBoxColumn_0.HeaderText = "Deleted";
			this.dataGridViewCheckBoxColumn_0.Name = "deletedDataGridViewCheckBoxColumn";
			this.dataGridViewCheckBoxColumn_0.Visible = false;
			this.bindingSource_0.DataMember = "vJ_Memorandum";
			this.bindingSource_0.DataSource = this.class255_0;
			this.bindingSource_0.CurrentChanged += this.bindingSource_0_CurrentChanged;
			this.class255_0.DataSetName = "DataSetGES";
			this.class255_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
			this.progressBar_0.Dock = DockStyle.Fill;
			this.progressBar_0.Location = new Point(8, 406);
			this.progressBar_0.Margin = new Padding(8, 8, 3, 10);
			this.progressBar_0.Name = "psbMemorandum";
			this.progressBar_0.Size = new Size(322, 24);
			this.progressBar_0.TabIndex = 5;
			this.bindingSource_2.DataMember = "tJ_MemFiles";
			this.bindingSource_2.DataSource = this.class255_0;
			this.bindingSource_2.Filter = "TypeDoc = 1";
			this.bindingSource_1.DataMember = "tJ_MemFiles";
			this.bindingSource_1.DataSource = this.class255_0;
			this.bindingSource_1.Filter = "TypeDoc = 2";
			this.bindingSource_3.DataMember = "vJ_MemCommission";
			this.bindingSource_3.DataSource = this.class255_0;
			this.bindingSource_3.CurrentChanged += this.bindingSource_3_CurrentChanged;
			this.backgroundWorker_0.WorkerReportsProgress = true;
			this.backgroundWorker_0.WorkerSupportsCancellation = true;
			this.backgroundWorker_0.DoWork += this.backgroundWorker_0_DoWork;
			this.backgroundWorker_0.ProgressChanged += this.backgroundWorker_0_ProgressChanged;
			this.backgroundWorker_0.RunWorkerCompleted += this.backgroundWorker_0_RunWorkerCompleted;
			this.label_0.AutoSize = true;
			this.label_0.Dock = DockStyle.Fill;
			this.label_0.Location = new Point(336, 398);
			this.label_0.Name = "lbStatus";
			this.label_0.Size = new Size(262, 42);
			this.label_0.TabIndex = 6;
			this.label_0.TextAlign = ContentAlignment.MiddleLeft;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(843, 440);
			base.Controls.Add(this.tableLayoutPanel_0);
			base.Name = "FormMemorandumJournal";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Разрешения на тех. присоединение";
			base.FormClosing += this.FormMemorandumJournal_FormClosing;
			base.Load += this.FormMemorandumJournal_Load;
			this.tableLayoutPanel_0.ResumeLayout(false);
			this.tableLayoutPanel_0.PerformLayout();
			this.toolStrip_0.ResumeLayout(false);
			this.toolStrip_0.PerformLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_0).EndInit();
			((ISupportInitialize)this.bindingSource_0).EndInit();
			((ISupportInitialize)this.class255_0).EndInit();
			((ISupportInitialize)this.bindingSource_2).EndInit();
			((ISupportInitialize)this.bindingSource_1).EndInit();
			((ISupportInitialize)this.bindingSource_3).EndInit();
			base.ResumeLayout(false);
		}

		[CompilerGenerated]
		private bool method_28(Class255.Class462 class462_0)
		{
			return class462_0.RowState == DataRowState.Unchanged && class462_0.id == (int)((DataRowView)this.bindingSource_0.Current)["id"];
		}

		private string string_0;

		[CompilerGenerated]
		private int int_0;

		private StateFormCreate stateFormCreate_0;

		private EISSettings eissettings_0;

		private Class603 class603_0;

		private TableLayoutPanel tableLayoutPanel_0;

		private ToolStrip toolStrip_0;

		private Button button_0;

		private Button button_1;

		private DataGridViewExcelFilter dataGridViewExcelFilter_0;

		private BindingSource bindingSource_0;

		private Class255 class255_0;

		private ToolStripButton toolStripButton_0;

		private BackgroundWorker backgroundWorker_0;

		private ProgressBar progressBar_0;

		private BindingSource bindingSource_1;

		private BindingSource bindingSource_2;

		private BindingSource bindingSource_3;

		private ToolStripButton toolStripButton_1;

		private ToolStripButton toolStripButton_2;

		private ToolStripButton toolStripButton_3;

		private ToolStripSeparator toolStripSeparator_0;

		private ToolStripButton toolStripButton_4;

		private ToolStripSeparator toolStripSeparator_1;

		private DataGridViewFilterCheckBoxColumn dataGridViewFilterCheckBoxColumn_0;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_3;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_4;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_0;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_1;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_2;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_3;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_5;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_6;

		private DataGridViewFilterTextBoxColumn YnAoeMfxeTk;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_7;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_8;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_9;

		private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn_0;

		private ToolStripButton toolStripButton_5;

		private ToolStripSeparator toolStripSeparator_2;

		private ToolStripTextBox toolStripTextBox_0;

		private Label label_0;
	}
}
