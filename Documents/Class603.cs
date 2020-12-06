using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Domino;
using FormLbr.Classes;

internal class Class603 : IDisposable
{
	internal string Category { get; set; }

	internal string UNID { get; set; }

	internal string Password { get; set; }

	[CompilerGenerated]
	internal string method_0()
	{
		return this.string_8;
	}

	[CompilerGenerated]
	private void method_1(string string_9)
	{
		this.string_8 = string_9;
	}

	internal Class606 method_2()
	{
		if (this.notesSession_0 == null)
		{
			this.notesSession_0 = new NotesSessionClass();
			this.notesSession_0.Initialize(this.Password);
		}
		List<Class606> list = this.method_14(this.notesSession_0.UserName);
		if (list.Count <= 0)
		{
			return new Class606("", "", "", "");
		}
		return list.First<Class606>();
	}

	internal Class603()
	{
		
		this.string_4 = Environment.GetFolderPath(Environment.SpecialFolder.Templates) + "\\LotusTemp\\";
		this.class354_0 = new Class255.Class354();
		
		this.method_3();
		if (Directory.Exists(this.string_4))
		{
			Directory.CreateDirectory(this.string_4);
		}
	}

	internal Class603(string string_9)
	{
		
		this.string_4 = Environment.GetFolderPath(Environment.SpecialFolder.Templates) + "\\LotusTemp\\";
		this.class354_0 = new Class255.Class354();
		
		this.Password = string_9;
		this.method_3();
	}

	internal void method_3()
	{
		if (string.IsNullOrEmpty(this.Password))
		{
			throw new Exception("Не указан пароль пользователя");
		}
		this.notesSession_0 = new NotesSessionClass();
		this.notesSession_0.Initialize(this.Password);
	}

	internal bool method_4(string string_9)
	{
		NotesDocument documentByUNID = this.notesSession_0.GetDatabase("Domino/ULGES/RU", "Referent\\offmemo.nsf", false).GetDocumentByUNID(string_9);
		if (!(documentByUNID.GetFirstItem("Status").Text == "X") && !(documentByUNID.GetFirstItem("Status").Text == "Send"))
		{
			return true;
		}
		MessageBox.Show("Вы не можете править этот документ!", "Предупреждение.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		return false;
	}

	internal bool method_5(string string_9, string string_10, string string_11, Enum26 enum26_0, string[] string_12, string string_13, string[] string_14, List<string> list_0)
	{
		Class603.smethod_0(string_9, string_12, string_13);
		if (this.notesSession_0 == null)
		{
			this.method_3();
		}
		this.notesDatabase_0 = this.notesSession_0.GetDatabase("Domino/ULGES/RU", "Referent\\offmemo.nsf", false);
		this.notesDatabase_3 = this.notesSession_0.GetDatabase("Domino/ULGES/RU", "Referent\\itstaff.nsf", false);
		this.notesDatabase_2 = this.notesSession_0.GetDatabase("Domino/ULGES/RU", "names.nsf", false);
		this.notesView_1 = this.notesDatabase_2.GetView("_people");
		this.notesView_2 = this.notesDatabase_3.GetView("Структура");
		this.notesView_3 = this.notesDatabase_3.GetView("Сотрудники\\вся информация");
		this.method_24(ref this.notesItem_0, ref this.notesDocument_1);
		this.method_23(ref this.notesItem_2, ref this.notesDocument_2);
		this.method_18(ref this.string_2, ref this.notesDocument_3);
		this.method_22(string_13, ref this.string_0, ref this.notesItem_3, ref this.notesDocument_4);
		this.method_19(ref this.string_1, ref this.notesItem_0, ref this.notesDocument_5);
		NotesDocument notesDocument = this.notesDatabase_0.CreateDocument();
		notesDocument.AppendItemValue("Form", "OfficeMemo");
		notesDocument.AppendItemValue("NewBody", "0");
		notesDocument.AppendItemValue("Status", enum26_0.ToString());
		NotesRichTextItem notesRichTextItem = notesDocument.CreateRichTextItem("Body_e");
		notesRichTextItem.AddNewLine(1, false);
		notesRichTextItem.AppendText(string_11);
		notesRichTextItem.AddNewLine(2, false);
		notesDocument.AppendItemValue("Subject", string_10);
		notesDocument.AppendItemValue("Category", "Служебная записка (ТП)");
		notesDocument.AppendItemValue("Stamp", "1");
		notesDocument.AppendItemValue("IO_InExec", this.method_0());
		notesDocument.AppendItemValue("IO_InP", this.string_1);
		notesDocument.AppendItemValue("IO_InP_Notes", this.string_0);
		notesDocument.AppendItemValue("IO_InP_Notes_Proxy", this.string_0);
		notesDocument.AppendItemValue("IO_InExec_Notes", this.notesItem_0);
		notesDocument.AppendItemValue("Access_IO_InP", this.string_0);
		notesDocument.AppendItemValue("IO_InExec_Dept", (this.notesItem_2 != null) ? this.notesItem_2.Text : "");
		notesDocument.AppendItemValue("IO_InDep", (this.notesItem_2 != null) ? this.notesItem_2.Text : "");
		notesDocument.AppendItemValue("IO_InExec_DeptID", this.string_2);
		notesDocument.AppendItemValue("IO_InDepID", this.string_2);
		notesDocument.AppendItemValue("Access_Flags", "InheritReaders");
		notesDocument.AppendItemValue("AuthorSite", "CN=Domino/O=ULGES/C=RU");
		notesDocument.AppendItemValue("Access_Servers", "CN=Domino/O=ULGES/C=RU");
		notesDocument.AppendItemValue("Access_FlagsMod", "InheritReaders");
		notesDocument.AppendItemValue("Access_Created", DateTime.Now);
		notesDocument.AppendItemValue("Access_CName", this.method_0());
		notesDocument.AppendItemValue("Access_CreatedBy", this.notesItem_0.Text);
		notesDocument.AppendItemValue("IO_InExec_D", ((this.notesItem_2 != null) ? this.notesItem_2.Text : "") + "\\" + this.method_0());
		notesDocument.AppendItemValue("IO_In_D", ((this.notesItem_3 != null) ? this.notesItem_3.Text : "") + "\\" + this.string_1);
		notesDocument.AppendItemValue("Access_MName", this.method_0());
		notesDocument.AppendItemValue("Access_ModifiedBy", this.notesItem_0.Text);
		notesDocument.AppendItemValue("Access_ExtremeReaders", "[Extreme]");
		NotesItem value;
		NotesItem value2;
		NotesItem notesItem;
		NotesItem value3;
		this.method_16(string_12, notesDocument, out value, out value2, out notesItem, out value3);
		NotesItem value4;
		NotesItem value5;
		this.method_20(string_14, notesDocument, notesItem, out value4, out value5);
		notesDocument.AppendItemValue("IO_IntCorr", this.notesItem_2.Text);
		notesDocument.AppendItemValue("IO_IntCorrID", value);
		notesDocument.AppendItemValue("IO_IntCorrPers", value2);
		notesDocument.AppendItemValue("IO_Org_D", value3);
		notesDocument.AppendItemValue("ReviewersID", value4);
		notesDocument.AppendItemValue("Reviewers", value5);
		notesDocument.AppendItemValue("WriteAccess", notesItem);
		if (list_0 != null)
		{
			foreach (string text in list_0)
			{
				if (text != "")
				{
					System.IO.FileInfo fileInfo = new System.IO.FileInfo(text);
					fileInfo.Name.Replace(fileInfo.Extension, "");
					NotesRichTextItem notesRichTextItem2;
					if (notesDocument.HasItem("Body"))
					{
						notesRichTextItem2 = (NotesRichTextItem)notesDocument.GetFirstItem("Body");
					}
					else
					{
						notesRichTextItem2 = notesDocument.CreateRichTextItem("Body");
					}
					notesRichTextItem2.EmbedObject(EMBED_TYPE.EMBED_ATTACHMENT, "", text, null);
				}
			}
		}
		bool result = notesDocument.Save(true, true, false);
		this.UNID = notesDocument.UniversalID;
		return result;
	}

	internal bool method_6(string string_9, string string_10, string string_11, string string_12, Enum26 enum26_0, string[] string_13, string string_14, string[] string_15, List<string> list_0)
	{
		this.UNID = string_9;
		Class603.smethod_0(string_10, string_13, string_14);
		if (this.notesSession_0 == null)
		{
			this.method_3();
		}
		this.notesDatabase_0 = this.notesSession_0.GetDatabase("Domino/ULGES/RU", "Referent\\offmemo.nsf", false);
		NotesDocument documentByUNID = this.notesDatabase_0.GetDocumentByUNID(string_9);
		if (!(documentByUNID.GetFirstItem("Status").Text == "X") && !(documentByUNID.GetFirstItem("Status").Text == "Send"))
		{
			this.notesDatabase_3 = this.notesSession_0.GetDatabase("Domino/ULGES/RU", "Referent\\itstaff.nsf", false);
			this.notesDatabase_2 = this.notesSession_0.GetDatabase("Domino/ULGES/RU", "names.nsf", false);
			this.notesView_1 = this.notesDatabase_2.GetView("_people");
			this.notesView_2 = this.notesDatabase_3.GetView("Структура");
			this.notesView_3 = this.notesDatabase_3.GetView("Сотрудники\\вся информация");
			this.method_24(ref this.notesItem_0, ref this.notesDocument_1);
			this.method_23(ref this.notesItem_2, ref this.notesDocument_2);
			this.method_18(ref this.string_2, ref this.notesDocument_3);
			this.method_22(string_14, ref this.string_0, ref this.notesItem_3, ref this.notesDocument_4);
			this.method_19(ref this.string_1, ref this.notesItem_0, ref this.notesDocument_5);
			documentByUNID.ReplaceItemValue("Form", "OfficeMemo");
			documentByUNID.ReplaceItemValue("NewBody", "0");
			documentByUNID.ReplaceItemValue("Status", enum26_0.ToString());
			if (documentByUNID.HasItem("Body_e"))
			{
				((NotesRichTextItem)documentByUNID.GetFirstItem("Body_e")).Remove();
			}
			NotesRichTextItem notesRichTextItem = documentByUNID.CreateRichTextItem("Body_e");
			notesRichTextItem.AddNewLine(1, false);
			notesRichTextItem.AppendText(string_12);
			notesRichTextItem.AddNewLine(2, false);
			documentByUNID.ReplaceItemValue("Subject", string_11);
			documentByUNID.ReplaceItemValue("Category", "Служебная записка (ТП)");
			documentByUNID.ReplaceItemValue("Stamp", "1");
			documentByUNID.ReplaceItemValue("IO_InExec", this.method_0());
			documentByUNID.ReplaceItemValue("IO_InP", this.string_1);
			documentByUNID.ReplaceItemValue("IO_InP_Notes", this.string_0);
			documentByUNID.ReplaceItemValue("IO_InP_Notes_Proxy", this.string_0);
			documentByUNID.ReplaceItemValue("IO_InExec_Notes", this.notesItem_0);
			documentByUNID.ReplaceItemValue("Access_IO_InP", this.string_0);
			documentByUNID.ReplaceItemValue("IO_InExec_Dept", (this.notesItem_2 != null) ? this.notesItem_2.Text : "");
			documentByUNID.ReplaceItemValue("IO_InDep", (this.notesItem_2 != null) ? this.notesItem_2.Text : "");
			documentByUNID.ReplaceItemValue("IO_InExec_DeptID", this.string_2);
			documentByUNID.ReplaceItemValue("IO_InDepID", this.string_2);
			documentByUNID.ReplaceItemValue("Access_Flags", "InheritReaders");
			documentByUNID.ReplaceItemValue("AuthorSite", "CN=Domino/O=ULGES/C=RU");
			documentByUNID.ReplaceItemValue("Access_Servers", "CN=Domino/O=ULGES/C=RU");
			documentByUNID.ReplaceItemValue("Access_FlagsMod", "InheritReaders");
			documentByUNID.ReplaceItemValue("Access_Created", DateTime.Now);
			documentByUNID.ReplaceItemValue("Access_CName", this.method_0());
			documentByUNID.ReplaceItemValue("Access_CreatedBy", this.notesItem_0.Text);
			documentByUNID.ReplaceItemValue("IO_InExec_D", ((this.notesItem_2 != null) ? this.notesItem_2.Text : "") + "\\" + this.method_0());
			documentByUNID.ReplaceItemValue("IO_In_D", ((this.notesItem_3 != null) ? this.notesItem_3.Text : "") + "\\" + this.string_1);
			documentByUNID.ReplaceItemValue("Access_MName", this.method_0());
			documentByUNID.ReplaceItemValue("Access_ModifiedBy", this.notesItem_0.Text);
			documentByUNID.ReplaceItemValue("Access_ExtremeReaders", "[Extreme]");
			NotesItem value;
			NotesItem value2;
			NotesItem notesItem;
			NotesItem value3;
			this.method_17(string_13, documentByUNID, out value, out value2, out notesItem, out value3);
			NotesItem value4;
			NotesItem value5;
			this.method_21(string_15, documentByUNID, notesItem, out value4, out value5);
			documentByUNID.ReplaceItemValue("IO_IntCorr", this.notesItem_2.Text);
			documentByUNID.ReplaceItemValue("IO_IntCorrID", value);
			documentByUNID.ReplaceItemValue("IO_IntCorrPers", value2);
			documentByUNID.ReplaceItemValue("IO_Org_D", value3);
			documentByUNID.ReplaceItemValue("ReviewersID", value4);
			documentByUNID.ReplaceItemValue("Reviewers", value5);
			documentByUNID.ReplaceItemValue("WriteAccess", notesItem);
			if (list_0 != null)
			{
				foreach (string text in list_0)
				{
					if (text != "")
					{
						System.IO.FileInfo fileInfo = new System.IO.FileInfo(text);
						fileInfo.Name.Replace(fileInfo.Extension, "");
						NotesRichTextItem notesRichTextItem2;
						if (documentByUNID.HasItem("Body"))
						{
							notesRichTextItem2 = (NotesRichTextItem)documentByUNID.GetFirstItem("Body");
							if (notesRichTextItem2.EmbeddedObjects != null)
							{
								object[] array = (object[])notesRichTextItem2.EmbeddedObjects;
								for (int i = 0; i < array.Length; i++)
								{
									((NotesEmbeddedObject)array[i]).Remove();
								}
							}
						}
						else
						{
							notesRichTextItem2 = documentByUNID.CreateRichTextItem("Body");
						}
						notesRichTextItem2.EmbedObject(EMBED_TYPE.EMBED_ATTACHMENT, "", text, null);
					}
				}
			}
			return documentByUNID.Save(true, true, false);
		}
		MessageBox.Show("Вы не можете править этот документ!", "Предупреждение.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		return false;
	}

	internal List<string> method_7(NotesDocument notesDocument_6, bool bool_0 = false, string string_9 = "")
	{
		List<string> list = new List<string>();
		NotesRichTextItem notesRichTextItem = (NotesRichTextItem)notesDocument_6.GetFirstItem("Body");
		if (notesDocument_6.HasEmbedded && notesRichTextItem != null)
		{
			foreach (NotesEmbeddedObject notesEmbeddedObject in (object[])notesRichTextItem.EmbeddedObjects)
			{
				if (notesEmbeddedObject.type == EMBED_TYPE.EMBED_ATTACHMENT)
				{
					string name = notesEmbeddedObject.Name;
					if (bool_0)
					{
						notesEmbeddedObject.ExtractFile(string_9 + name);
					}
					list.Add(name.Replace("\r\n", ""));
				}
			}
		}
		return list;
	}

	internal List<NotesDocument> method_8()
	{
		List<NotesDocument> list = null;
		try
		{
			if (this.notesSession_0 == null)
			{
				this.method_3();
			}
			this.notesDatabase_1 = this.notesSession_0.GetDatabase("Domino/ULGES/RU", "Referent\\ittask.nsf", false);
			this.notesView_0 = this.notesDatabase_1.GetView("UICommissionsAll");
			this.notesDocument_0 = this.notesView_0.GetFirstDocument();
			while (this.notesDocument_0 != null)
			{
				list.Add(this.notesDocument_0);
				this.notesDocument_0 = this.notesView_0.GetNextDocument(this.notesDocument_0);
			}
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
		return list;
	}

	internal List<Class604> uubCttfhrkq(string string_9 = "", bool bool_0 = false)
	{
		List<Class604> list = null;
		try
		{
			if (this.notesSession_0 == null)
			{
				this.notesSession_0 = new NotesSessionClass();
				this.notesSession_0.Initialize(this.Password);
			}
			this.notesDatabase_1 = this.notesSession_0.GetDatabase("Domino/ULGES/RU", "Referent\\ittask.nsf", false);
			this.notesView_0 = this.notesDatabase_1.GetView("UICommissionsAll");
			this.notesDocument_0 = this.notesView_0.GetFirstDocument();
			while (this.notesDocument_0 != null)
			{
				if (!(string_9 != "") || !(string_9 != this.method_15(this.notesDocument_0.GetFirstItem("ctb_InheritedID"))))
				{
					list = this.method_9(list);
					this.notesDocument_0 = this.notesView_0.GetNextDocument(this.notesDocument_0);
				}
			}
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
		return list;
	}

	private List<Class604> method_9(List<Class604> list_0)
	{
		if (this.notesDocument_0.GetFirstItem("ctb_InheritedID") != null)
		{
			Class604 @class = new Class604();
			@class.UniversalID = this.notesDocument_0.UniversalID;
			@class.Body = this.method_15(this.notesDocument_0.GetFirstItem("Body"));
			@class.ctbStatus = this.method_15(this.notesDocument_0.GetFirstItem("ctbStatus"));
			@class.ctb_InheritedID = this.method_15(this.notesDocument_0.GetFirstItem("ctb_InheritedID"));
			@class.ctbBoss = this.method_15(this.notesDocument_0.GetFirstItem("ctbBoss"));
			@class.ctbSubject = this.method_15(this.notesDocument_0.GetFirstItem("ctbSubject"));
			@class.ctbExecutor = this.method_15(this.notesDocument_0.GetFirstItem("ctbExecutor"));
			@class.ctbSign = this.method_15(this.notesDocument_0.GetFirstItem("ctbSign"));
			@class.ctbBoss = this.method_15(this.notesDocument_0.GetFirstItem("ctbBoss"));
			@class.ctbComment = this.method_15(this.notesDocument_0.GetFirstItem("ctbComment"));
			@class.ctbDateCreate = this.method_15(this.notesDocument_0.GetFirstItem("ctbDateCreate"));
			@class.ctbDateFact = this.method_15(this.notesDocument_0.GetFirstItem("ctbDateFact"));
			@class.ctbDocNum = this.method_15(this.notesDocument_0.GetFirstItem("ctbDocNum"));
			@class.Header_Title = this.method_15(this.notesDocument_0.GetFirstItem("Header_Title"));
			if (this.notesDocument_0.HasItem("Body"))
			{
				List<Class607> list = new List<Class607>();
				NotesRichTextItem notesRichTextItem = (NotesRichTextItem)this.notesDocument_0.GetFirstItem("Body");
				if (notesRichTextItem.EmbeddedObjects != null && ((object[])notesRichTextItem.EmbeddedObjects).Count<object>() > 0)
				{
					string[] array = notesRichTextItem.Text.Split(new string[]
					{
						" - "
					}, StringSplitOptions.RemoveEmptyEntries);
					for (int i = 0; i < array.Count<string>(); i++)
					{
						NotesEmbeddedObject notesEmbeddedObject = (NotesEmbeddedObject)((object[])notesRichTextItem.EmbeddedObjects)[i];
						notesEmbeddedObject.ExtractFile(this.string_4 + notesEmbeddedObject.ToString());
						FileBinary fileBinary = new FileBinary(this.string_4 + notesEmbeddedObject.ToString());
						Class607 class2 = new Class607();
						class2.method_7(fileBinary.ByteArray);
						class2.method_1(fileBinary.Extension);
						class2.method_3(fileBinary.KbSize);
						class2.method_5(class2.method_4());
						class2.Name = array[i];
						list.Add(class2);
						File.Delete(this.string_4 + notesEmbeddedObject.ToString());
					}
				}
				@class.method_1(list);
			}
			if (list_0 == null)
			{
				list_0 = new List<Class604>();
			}
			list_0.Add(@class);
		}
		return list_0;
	}

	internal List<Class605> uybCtvHfSxo(string string_9 = "", bool bool_0 = false)
	{
		List<Class605> list = new List<Class605>();
		List<Class605> result;
		try
		{
			if (this.notesSession_0 == null)
			{
				this.notesSession_0 = new NotesSessionClass();
				this.notesSession_0.Initialize(this.Password);
			}
			NotesDatabase database = this.notesSession_0.GetDatabase("Domino/ULGES/RU", "Referent\\offmemo.nsf", false);
			if (string_9 != "")
			{
				this.method_10(list, database.GetDocumentByUNID(string_9));
			}
			NotesView view = database.GetView("UIOfficeMemoAll");
			NotesDocument notesDocument = view.GetFirstDocument();
			while (notesDocument != null)
			{
				if (notesDocument.GetItemValue("Category") != null || !(notesDocument.GetItemValue("Category").ToString() != "Служебная записка (ТП)"))
				{
					this.method_10(list, notesDocument);
					notesDocument = view.GetNextDocument(notesDocument);
				}
			}
			this.notesSession_0 = null;
			result = list;
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.ToString());
			result = list;
		}
		finally
		{
			this.notesSession_0 = null;
		}
		return result;
	}

	private void method_10(List<Class605> list_0, NotesDocument notesDocument_6)
	{
		Class605 @class = new Class605();
		@class.UniversalID = notesDocument_6.UniversalID;
		@class.Body_C = this.method_15(notesDocument_6.GetFirstItem("Body_C"));
		@class.Category = this.method_15(notesDocument_6.GetFirstItem("Category"));
		@class.CorrName = this.method_15(notesDocument_6.GetFirstItem("CorrName"));
		@class.ctb_InheritedID = this.method_15(notesDocument_6.GetFirstItem("ctb_InheritedID"));
		@class.ctbDateCreate = this.method_15(notesDocument_6.GetFirstItem("ctbDateCreate"));
		@class.IO_InExec = this.method_15(notesDocument_6.GetFirstItem("IO_InExec"));
		@class.IO_InP = this.method_15(notesDocument_6.GetFirstItem("IO_InP"));
		@class.RespDate = this.method_15(notesDocument_6.GetFirstItem("RespDate"));
		@class.RespNum = this.method_15(notesDocument_6.GetFirstItem("RespNum"));
		@class.Reviewers = this.method_15(notesDocument_6.GetFirstItem("Reviewers"));
		@class.RgNum = this.method_15(notesDocument_6.GetFirstItem("RgNum"));
		@class.SignDate = this.method_15(notesDocument_6.GetFirstItem("SignDate"));
		@class.Status = this.method_15(notesDocument_6.GetFirstItem("Status"));
		@class.Subject = this.method_15(notesDocument_6.GetFirstItem("Subject"));
		if (notesDocument_6.HasItem("Body"))
		{
			List<Class607> list = new List<Class607>();
			NotesRichTextItem notesRichTextItem = (NotesRichTextItem)notesDocument_6.GetFirstItem("Body");
			if (notesRichTextItem.EmbeddedObjects != null && ((object[])notesRichTextItem.EmbeddedObjects).Count<object>() > 0)
			{
				string[] array = notesRichTextItem.Text.Split(new string[]
				{
					" - "
				}, StringSplitOptions.RemoveEmptyEntries);
				for (int i = 0; i < array.Count<string>(); i++)
				{
					NotesEmbeddedObject notesEmbeddedObject = (NotesEmbeddedObject)((object[])notesRichTextItem.EmbeddedObjects)[i];
					notesEmbeddedObject.ExtractFile(this.string_4 + notesEmbeddedObject.ToString());
					FileBinary fileBinary = new FileBinary(this.string_4 + notesEmbeddedObject.ToString());
					Class607 class2 = new Class607();
					class2.method_7(fileBinary.ByteArray);
					class2.method_1(fileBinary.Extension);
					class2.method_3(fileBinary.KbSize);
					class2.method_5(class2.method_4());
					class2.Name = array[i];
					list.Add(class2);
					File.Delete(this.string_4 + notesEmbeddedObject.ToString());
				}
			}
			@class.method_0(list);
		}
		list_0.Add(@class);
	}

	internal DataTable method_11()
	{
		DataTable dataTable = new DataTable();
		DataTable result;
		try
		{
			if (this.notesSession_0 == null)
			{
				this.notesSession_0 = new NotesSessionClass();
				this.notesSession_0.Initialize(this.Password);
			}
			NotesView view = this.notesSession_0.GetDatabase("Domino/ULGES/RU", "Referent\\offmemo.nsf", false).GetView("UIOfficeMemoAll");
			dataTable.Columns.Add("UniversalID");
			NotesDocument notesDocument = view.GetFirstDocument();
			foreach (NotesItem notesItem in (object[])notesDocument.Items)
			{
				dataTable.Columns.Add(notesItem.Name, typeof(object));
			}
			while (notesDocument != null)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow["UniversalID"] = notesDocument.UniversalID;
				foreach (NotesItem notesItem2 in (object[])notesDocument.Items)
				{
					try
					{
						if (!dataTable.Columns.Contains(notesItem2.Name))
						{
							dataTable.Columns.Add(notesItem2.Name);
						}
						dataRow[notesItem2.Name] = ((notesItem2 == null || notesItem2.Text == null) ? "" : notesItem2.Text);
						goto IL_164;
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.ToString());
						goto IL_164;
					}
					break;
					IL_164:;
				}
				dataTable.Rows.Add(dataRow);
				notesDocument = view.GetNextDocument(notesDocument);
			}
			this.notesSession_0 = null;
			result = dataTable;
		}
		catch (Exception ex2)
		{
			MessageBox.Show(ex2.ToString());
			result = dataTable;
		}
		finally
		{
			this.notesSession_0 = null;
		}
		return result;
	}

	internal DataTable method_12(string[] string_9)
	{
		DataTable dataTable = new DataTable();
		try
		{
			if (this.notesSession_0 == null)
			{
				this.notesSession_0 = new NotesSessionClass();
				this.notesSession_0.Initialize(this.Password);
			}
			NotesView view = this.notesSession_0.GetDatabase("Domino/ULGES/RU", "Referent\\offmemo.nsf", false).GetView("UIOfficeMemoAll");
			foreach (string columnName in string_9)
			{
				dataTable.Columns.Add(columnName);
			}
			for (NotesDocument notesDocument = view.GetFirstDocument(); notesDocument != null; notesDocument = view.GetNextDocument(notesDocument))
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow["UniversalID"] = notesDocument.UniversalID;
				foreach (NotesItem notesItem in (object[])notesDocument.Items)
				{
					try
					{
						if (string_9.Contains(notesItem.Name))
						{
							dataRow[notesItem.Name] = ((notesItem == null || notesItem.Text == null) ? "" : notesItem.Text);
						}
						goto IL_11F;
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.ToString());
						goto IL_11F;
					}
					break;
					IL_11F:;
				}
				dataTable.Rows.Add(dataRow);
			}
			this.notesSession_0 = null;
		}
		catch (Exception ex2)
		{
			MessageBox.Show(ex2.ToString());
		}
		finally
		{
			this.notesSession_0 = null;
		}
		return dataTable;
	}

	internal List<Class606> method_13()
	{
		return this.method_14("");
	}

	internal List<Class606> method_14(string string_9)
	{
		List<Class606> list = new List<Class606>();
		try
		{
			if (this.notesSession_0 == null)
			{
				this.notesSession_0 = new NotesSessionClass();
				this.notesSession_0.Initialize(this.Password);
			}
			NotesDatabase database = this.notesSession_0.GetDatabase("Domino/ULGES/RU", "Referent\\itstaff.nsf", false);
			if (!database.IsOpen)
			{
				database.Open();
			}
			NotesView view = database.GetView("Сотрудники\\вся информация");
			for (NotesDocument notesDocument = view.GetFirstDocument(); notesDocument != null; notesDocument = view.GetNextDocument(notesDocument))
			{
				IItem2 firstItem = notesDocument.GetFirstItem("Form");
				NotesItem firstItem2 = notesDocument.GetFirstItem("User_NotesName");
				if (firstItem.Text == "Person" && (string_9 == "" || (firstItem2 != null && string_9 == firstItem2.Text)))
				{
					Class606 @class = new Class606();
					@class.Form = ((notesDocument.GetFirstItem("Form") != null) ? notesDocument.GetFirstItem("Form").Text : "");
					@class.FirstName = ((notesDocument.GetFirstItem("FirstName") != null) ? notesDocument.GetFirstItem("FirstName").Text : "");
					@class.LastName = ((notesDocument.GetFirstItem("LastName") != null) ? notesDocument.GetFirstItem("LastName").Text : "");
					@class.MiddleInitial = ((notesDocument.GetFirstItem("MiddleInitial") != null) ? notesDocument.GetFirstItem("MiddleInitial").Text : "");
					@class.FIO = string.Concat(new string[]
					{
						@class.LastName,
						" ",
						@class.FirstName,
						" ",
						@class.MiddleInitial
					});
					@class.FullName = ((notesDocument.GetFirstItem("FullName") != null) ? notesDocument.GetFirstItem("FullName").Text : "");
					@class.Owner = ((notesDocument.GetFirstItem("Owner") != null) ? notesDocument.GetFirstItem("Owner").Text : "");
					@class.method_1((notesDocument.GetFirstItem("Person_Name") != null) ? notesDocument.GetFirstItem("Person_Name").Text : "");
					@class.UniversalID = notesDocument.UniversalID;
					@class.method_3((notesDocument.GetFirstItem("User_NotesName") != null) ? notesDocument.GetFirstItem("User_NotesName").Text : "");
					list.Add(@class);
					if (string_9 != "")
					{
						return list;
					}
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.ToString());
		}
		finally
		{
			this.notesSession_0 = null;
		}
		return list;
	}

	private string method_15(NotesItem notesItem_4)
	{
		if (notesItem_4 != null)
		{
			if (!string.IsNullOrEmpty(notesItem_4.Text))
			{
				return notesItem_4.Text;
			}
			if (notesItem_4.Values != null && notesItem_4.Values is string)
			{
				return notesItem_4.Values.ToString();
			}
		}
		return "";
	}

	private void method_16(string[] string_9, NotesDocument notesDocument_6, out NotesItem notesItem_4, out NotesItem notesItem_5, out NotesItem notesItem_6, out NotesItem notesItem_7)
	{
		notesItem_4 = notesDocument_6.AppendItemValue("IO_IntCorrID", "");
		NotesItem notesItem = notesDocument_6.AppendItemValue("IO_IntCorr", "");
		notesItem_5 = notesDocument_6.AppendItemValue("IO_IntCorrPers", "");
		notesItem_6 = notesDocument_6.AppendItemValue("WriteAccess", "");
		notesItem_7 = notesDocument_6.AppendItemValue("IO_Org_D", "");
		this.string_3 = "";
		int i = 0;
		IL_260:
		while (i < string_9.Length)
		{
			string text = string_9[i];
			this.notesDocument_3 = this.notesView_3.GetFirstDocument();
			while (this.notesDocument_3 != null)
			{
				if (this.notesDocument_3.GetFirstItem("form") != null && this.notesDocument_3.GetFirstItem("form").Text == "Person" && this.notesDocument_3.GetFirstItem("Person_Name") != null && this.notesDocument_3.GetFirstItem("Person_Name").Text == text)
				{
					this.string_2 = this.notesDocument_3.UniversalID;
					this.string_3 = this.notesDocument_3.ParentDocumentUNID;
					this.notesDocument_2 = this.notesView_2.GetFirstDocument();
					while (this.notesDocument_2 != null)
					{
						if (this.notesDocument_2.GetFirstItem("form") != null && this.notesDocument_2.GetFirstItem("form").Text == "Person" && this.notesDocument_2.GetFirstItem("Person_Name") != null && this.notesDocument_2.GetFirstItem("Person_Name").Text == text)
						{
							this.notesItem_2 = this.notesDocument_2.GetFirstItem("DBody_Struct_Dept");
							break;
						}
						this.notesDocument_2 = this.notesView_2.GetNextDocument(this.notesDocument_2);
					}
					IL_1E1:
					notesItem_7.AppendToTextList(this.notesItem_2.Text + "\\" + text);
					notesItem_4.AppendToTextList(this.string_3);
					notesItem.AppendToTextList(this.notesItem_2.Text ?? "");
					notesItem_5.AppendToTextList(text + "|" + this.string_2);
					notesItem_6.AppendToTextList(this.notesDocument_3.GetFirstItem("User_NotesName").Text);
					i++;
					goto IL_260;
					break;
				}
				this.notesDocument_3 = this.notesView_3.GetNextDocument(this.notesDocument_3);
			}
			goto IL_1E1;
		}
	}

	private void method_17(string[] string_9, NotesDocument notesDocument_6, out NotesItem notesItem_4, out NotesItem notesItem_5, out NotesItem notesItem_6, out NotesItem notesItem_7)
	{
		notesItem_4 = notesDocument_6.ReplaceItemValue("IO_IntCorrID", "");
		NotesItem notesItem = notesDocument_6.ReplaceItemValue("IO_IntCorr", "");
		notesItem_5 = notesDocument_6.ReplaceItemValue("IO_IntCorrPers", "");
		notesItem_6 = notesDocument_6.ReplaceItemValue("WriteAccess", "");
		notesItem_7 = notesDocument_6.ReplaceItemValue("IO_Org_D", "");
		this.string_3 = "";
		int i = 0;
		IL_260:
		while (i < string_9.Length)
		{
			string text = string_9[i];
			this.notesDocument_3 = this.notesView_3.GetFirstDocument();
			while (this.notesDocument_3 != null)
			{
				if (this.notesDocument_3.GetFirstItem("form") != null && this.notesDocument_3.GetFirstItem("form").Text == "Person" && this.notesDocument_3.GetFirstItem("Person_Name") != null && this.notesDocument_3.GetFirstItem("Person_Name").Text == text)
				{
					this.string_2 = this.notesDocument_3.UniversalID;
					this.string_3 = this.notesDocument_3.ParentDocumentUNID;
					this.notesDocument_2 = this.notesView_2.GetFirstDocument();
					while (this.notesDocument_2 != null)
					{
						if (this.notesDocument_2.GetFirstItem("form") != null && this.notesDocument_2.GetFirstItem("form").Text == "Person" && this.notesDocument_2.GetFirstItem("Person_Name") != null && this.notesDocument_2.GetFirstItem("Person_Name").Text == text)
						{
							this.notesItem_2 = this.notesDocument_2.GetFirstItem("DBody_Struct_Dept");
							break;
						}
						this.notesDocument_2 = this.notesView_2.GetNextDocument(this.notesDocument_2);
					}
					IL_1E1:
					notesItem_7.AppendToTextList(this.notesItem_2.Text + "\\" + text);
					notesItem_4.AppendToTextList(this.string_3);
					notesItem.AppendToTextList(this.notesItem_2.Text ?? "");
					notesItem_5.AppendToTextList(text + "|" + this.string_2);
					notesItem_6.AppendToTextList(this.notesDocument_3.GetFirstItem("User_NotesName").Text);
					i++;
					goto IL_260;
					break;
				}
				this.notesDocument_3 = this.notesView_3.GetNextDocument(this.notesDocument_3);
			}
			goto IL_1E1;
		}
	}

	private static void smethod_0(string string_9, string[] string_10, string string_11)
	{
		if (string.IsNullOrEmpty(string_9))
		{
			throw new Exception("Не заполнена \"Категория\"");
		}
		(from r in string_10
		where !string.IsNullOrEmpty(r)
		select r).Count<string>();
		if ((from r in string_10
		where !string.IsNullOrEmpty(r)
		select r).Count<string>() == 0)
		{
			throw new Exception("Не заполнен \"Адресат\"");
		}
		if (string.IsNullOrEmpty(string_11))
		{
			throw new Exception("Не заполнен \"Подписант\"");
		}
	}

	private void method_18(ref string string_9, ref NotesDocument notesDocument_6)
	{
		for (notesDocument_6 = this.notesView_3.GetFirstDocument(); notesDocument_6 != null; notesDocument_6 = this.notesView_3.GetNextDocument(notesDocument_6))
		{
			if (notesDocument_6.GetFirstItem("form") != null && notesDocument_6.GetFirstItem("form").Text == "Person" && notesDocument_6.GetFirstItem("Person_Name") != null && notesDocument_6.GetFirstItem("Person_Name").Text == this.method_0())
			{
				string_9 = notesDocument_6.ParentDocumentUNID;
				return;
			}
		}
	}

	private void method_19(ref string string_9, ref NotesItem notesItem_4, ref NotesDocument notesDocument_6)
	{
		notesDocument_6 = this.notesView_3.GetFirstDocument();
		string_9 = "";
		notesDocument_6 = this.notesView_1.GetFirstDocument();
		while (notesDocument_6 != null)
		{
			if (notesDocument_6.GetFirstItem("Owner") == null || !(notesDocument_6.GetFirstItem("Owner").Text == this.string_0))
			{
				notesDocument_6 = this.notesView_1.GetNextDocument(notesDocument_6);
			}
			else
			{
				this.notesItem_1 = notesDocument_6.GetFirstItem("Owner");
				IL_76:
				if (this.notesItem_1 == null)
				{
					throw new Exception("Не заполнен \"Подписант\".");
				}
				string_9 = string.Concat(new string[]
				{
					notesDocument_6.GetFirstItem("LastName").Text,
					" ",
					notesDocument_6.GetFirstItem("FirstName").Text,
					" ",
					notesDocument_6.GetFirstItem("MiddleInitial").Text
				});
				return;
			}
		}
		goto IL_76;
	}

	private void method_20(string[] string_9, NotesDocument notesDocument_6, NotesItem notesItem_4, out NotesItem notesItem_5, out NotesItem notesItem_6)
	{
		notesItem_5 = notesDocument_6.AppendItemValue("ReviewersID", "");
		notesItem_6 = notesDocument_6.AppendItemValue("Reviewers", "");
		notesDocument_6.AppendItemValue("Access_ANames", this.method_0());
		notesDocument_6.AppendItemValue("Access_Authors", this.notesItem_0);
		int i = 0;
		IL_14F:
		while (i < string_9.Length)
		{
			string b = string_9[i];
			this.notesDocument_3 = this.notesView_3.GetFirstDocument();
			while (this.notesDocument_3 != null)
			{
				if (this.notesDocument_3.GetFirstItem("form") != null && this.notesDocument_3.GetFirstItem("form").Text == "Person" && this.notesDocument_3.GetFirstItem("Person_Name") != null && this.notesDocument_3.GetFirstItem("Person_Name").Text == b)
				{
					this.string_2 = this.notesDocument_3.UniversalID;
					NotesItem firstItem = this.notesDocument_3.GetFirstItem("Person_Name");
					notesItem_5.AppendToTextList(this.string_2);
					notesItem_6.AppendToTextList(firstItem.Text);
					notesItem_4.AppendToTextList(this.notesDocument_3.GetFirstItem("User_NotesName").Text);
					IL_14B:
					i++;
					goto IL_14F;
				}
				this.notesDocument_3 = this.notesView_3.GetNextDocument(this.notesDocument_3);
			}
			goto IL_14B;
		}
	}

	private void method_21(string[] string_9, NotesDocument notesDocument_6, NotesItem notesItem_4, out NotesItem notesItem_5, out NotesItem notesItem_6)
	{
		notesItem_5 = notesDocument_6.ReplaceItemValue("ReviewersID", "");
		notesItem_6 = notesDocument_6.ReplaceItemValue("Reviewers", "");
		notesDocument_6.ReplaceItemValue("Access_ANames", this.method_0());
		notesDocument_6.ReplaceItemValue("Access_Authors", this.notesItem_0);
		int i = 0;
		IL_14F:
		while (i < string_9.Length)
		{
			string b = string_9[i];
			this.notesDocument_3 = this.notesView_3.GetFirstDocument();
			while (this.notesDocument_3 != null)
			{
				if (this.notesDocument_3.GetFirstItem("form") != null && this.notesDocument_3.GetFirstItem("form").Text == "Person" && this.notesDocument_3.GetFirstItem("Person_Name") != null && this.notesDocument_3.GetFirstItem("Person_Name").Text == b)
				{
					this.string_2 = this.notesDocument_3.UniversalID;
					NotesItem firstItem = this.notesDocument_3.GetFirstItem("Person_Name");
					notesItem_5.AppendToTextList(this.string_2);
					notesItem_6.AppendToTextList(firstItem.Text);
					notesItem_4.AppendToTextList(this.notesDocument_3.GetFirstItem("User_NotesName").Text);
					IL_14B:
					i++;
					goto IL_14F;
				}
				this.notesDocument_3 = this.notesView_3.GetNextDocument(this.notesDocument_3);
			}
			goto IL_14B;
		}
	}

	private void method_22(string string_9, ref string string_10, ref NotesItem notesItem_4, ref NotesDocument notesDocument_6)
	{
		notesDocument_6 = this.notesView_3.GetFirstDocument();
		notesItem_4 = null;
		string_10 = "";
		while (notesDocument_6 != null)
		{
			if (notesDocument_6.GetFirstItem("form") != null && notesDocument_6.GetFirstItem("form").Text == "Person" && notesDocument_6.GetFirstItem("Person_Name").Text == string_9)
			{
				string_10 = notesDocument_6.GetFirstItem("User_NotesName").Text;
				notesItem_4 = this.notesItem_2;
				return;
			}
			notesDocument_6 = this.notesView_3.GetNextDocument(notesDocument_6);
		}
	}

	private void method_23(ref NotesItem notesItem_4, ref NotesDocument notesDocument_6)
	{
		notesDocument_6 = this.notesView_2.GetFirstDocument();
		this.notesItem_2 = null;
		while (notesDocument_6 != null)
		{
			if (notesDocument_6.GetFirstItem("form") != null && notesDocument_6.GetFirstItem("form").Text == "Person" && notesDocument_6.GetFirstItem("Person_Name") != null && notesDocument_6.GetFirstItem("Person_Name").Text == this.method_0())
			{
				this.notesItem_2 = notesDocument_6.GetFirstItem("DBody_Struct_Dept");
				return;
			}
			notesDocument_6 = this.notesView_2.GetNextDocument(notesDocument_6);
		}
	}

	private void method_24(ref NotesItem notesItem_4, ref NotesDocument notesDocument_6)
	{
		for (notesDocument_6 = this.notesView_1.GetFirstDocument(); notesDocument_6 != null; notesDocument_6 = this.notesView_1.GetNextDocument(notesDocument_6))
		{
			if (notesDocument_6.GetFirstItem("Owner").Text == this.notesSession_0.UserName)
			{
				notesItem_4 = notesDocument_6.GetFirstItem("Owner");
				IL_55:
				this.method_1(((notesDocument_6.GetFirstItem("LastName").Text != null) ? (notesDocument_6.GetFirstItem("LastName").Text.Trim() + " ") : "") + ((notesDocument_6.GetFirstItem("FirstName").Text != null) ? (notesDocument_6.GetFirstItem("FirstName").Text.Trim() + " ") : "") + ((notesDocument_6.GetFirstItem("MiddleInitial").Text != null) ? notesDocument_6.GetFirstItem("MiddleInitial").Text.Trim() : ""));
				return;
			}
		}
		goto IL_55;
	}

	internal void method_25()
	{
		this.notesItem_3 = null;
		this.notesItem_2 = null;
		this.notesItem_0 = null;
		this.notesDocument_5 = null;
		this.notesDocument_4 = null;
		this.notesDocument_3 = null;
		this.notesDocument_2 = null;
		this.notesDocument_1 = null;
		this.notesView_3 = null;
		this.notesView_2 = null;
		this.notesView_1 = null;
		this.notesDatabase_3 = null;
		this.notesDatabase_2 = null;
		this.notesDatabase_0 = null;
		this.notesSession_0 = null;
	}

	void IDisposable.Dispose()
	{
		this.notesItem_3 = null;
		this.notesItem_2 = null;
		this.notesItem_0 = null;
		this.notesDocument_5 = null;
		this.notesDocument_4 = null;
		this.notesDocument_3 = null;
		this.notesDocument_2 = null;
		this.notesDocument_1 = null;
		this.notesView_3 = null;
		this.notesView_2 = null;
		this.notesView_1 = null;
		this.notesDatabase_3 = null;
		this.notesDatabase_2 = null;
		this.notesDatabase_0 = null;
		this.notesSession_0 = null;
	}

	private NotesSession notesSession_0;

	private NotesDatabase notesDatabase_0;

	private NotesDatabase notesDatabase_1;

	private NotesDatabase notesDatabase_2;

	private NotesDatabase notesDatabase_3;

	private NotesView notesView_0;

	private NotesView notesView_1;

	private NotesView notesView_2;

	private NotesView notesView_3;

	private NotesDocument notesDocument_0;

	private NotesDocument notesDocument_1;

	private NotesDocument notesDocument_2;

	private NotesDocument notesDocument_3;

	private NotesDocument notesDocument_4;

	private NotesDocument notesDocument_5;

	private NotesItem notesItem_0;

	private NotesItem notesItem_1;

	private NotesItem notesItem_2;

	private NotesItem notesItem_3;

	private string string_0;

	private string string_1;

	private string string_2;

	private string string_3;

	private string string_4;

	private Class255.Class354 class354_0;

	[CompilerGenerated]
	private string string_5;

	[CompilerGenerated]
	private string string_6;

	[CompilerGenerated]
	private string string_7;

	[CompilerGenerated]
	private string string_8;
}
