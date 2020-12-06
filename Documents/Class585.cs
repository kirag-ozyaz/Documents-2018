using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using Documents.Properties;

[ToolboxItem(true)]
[HelpKeyword("vs.data.TableAdapter")]
[Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
[DesignerCategory("code")]
[DataObject(true)]
internal class Class585 : Component
{
	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public Class585()
	{
		
		
		this.Boolean_0 = true;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	protected internal SqlDataAdapter SqlDataAdapter_0
	{
		get
		{
			if (this.sqlDataAdapter_0 == null)
			{
				this.method_0();
			}
			return this.sqlDataAdapter_0;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	internal SqlConnection SqlConnection_0
	{
		get
		{
			if (this.sqlConnection_0 == null)
			{
				this.method_1();
			}
			return this.sqlConnection_0;
		}
		set
		{
			this.sqlConnection_0 = value;
			if (this.SqlDataAdapter_0.InsertCommand != null)
			{
				this.SqlDataAdapter_0.InsertCommand.Connection = value;
			}
			if (this.SqlDataAdapter_0.DeleteCommand != null)
			{
				this.SqlDataAdapter_0.DeleteCommand.Connection = value;
			}
			if (this.SqlDataAdapter_0.UpdateCommand != null)
			{
				this.SqlDataAdapter_0.UpdateCommand.Connection = value;
			}
			for (int i = 0; i < this.SqlCommand_0.Length; i++)
			{
				if (this.SqlCommand_0[i] != null)
				{
					this.SqlCommand_0[i].Connection = value;
				}
			}
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	internal SqlTransaction SqlTransaction_0
	{
		get
		{
			return this.sqlTransaction_0;
		}
		set
		{
			this.sqlTransaction_0 = value;
			for (int i = 0; i < this.SqlCommand_0.Length; i++)
			{
				this.SqlCommand_0[i].Transaction = this.sqlTransaction_0;
			}
			if (this.SqlDataAdapter_0 != null && this.SqlDataAdapter_0.DeleteCommand != null)
			{
				this.SqlDataAdapter_0.DeleteCommand.Transaction = this.sqlTransaction_0;
			}
			if (this.SqlDataAdapter_0 != null && this.SqlDataAdapter_0.InsertCommand != null)
			{
				this.SqlDataAdapter_0.InsertCommand.Transaction = this.sqlTransaction_0;
			}
			if (this.SqlDataAdapter_0 != null && this.SqlDataAdapter_0.UpdateCommand != null)
			{
				this.SqlDataAdapter_0.UpdateCommand.Transaction = this.sqlTransaction_0;
			}
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	protected SqlCommand[] SqlCommand_0
	{
		get
		{
			if (this.sqlCommand_0 == null)
			{
				this.method_2();
			}
			return this.sqlCommand_0;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public bool Boolean_0
	{
		get
		{
			return this.bool_0;
		}
		set
		{
			this.bool_0 = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	private void method_0()
	{
		this.sqlDataAdapter_0 = new SqlDataAdapter();
		DataTableMapping dataTableMapping = new DataTableMapping();
		dataTableMapping.SourceTable = "Table";
		dataTableMapping.DataSetTable = "tblAbnAplForDiscon";
		dataTableMapping.ColumnMappings.Add("NumDoc", "NumDoc");
		dataTableMapping.ColumnMappings.Add("NetArea", "NetArea");
		dataTableMapping.ColumnMappings.Add("TypeAction", "TypeAction");
		dataTableMapping.ColumnMappings.Add("DateAppl", "DateAppl");
		dataTableMapping.ColumnMappings.Add("DateAction", "DateAction");
		dataTableMapping.ColumnMappings.Add("Id", "Id");
		dataTableMapping.ColumnMappings.Add("LegalAbns", "LegalAbns");
		dataTableMapping.ColumnMappings.Add("Sent", "Sent");
		this.sqlDataAdapter_0.TableMappings.Add(dataTableMapping);
		this.sqlDataAdapter_0.DeleteCommand = new SqlCommand();
		this.sqlDataAdapter_0.DeleteCommand.Connection = this.SqlConnection_0;
		this.sqlDataAdapter_0.DeleteCommand.CommandText = "DELETE FROM [tblAbnAplForDiscon] WHERE (([Id] = @Original_Id) AND ((@IsNull_NumDoc = 1 AND [NumDoc] IS NULL) OR ([NumDoc] = @Original_NumDoc)) AND ((@IsNull_NetArea = 1 AND [NetArea] IS NULL) OR ([NetArea] = @Original_NetArea)) AND ((@IsNull_TypeAction = 1 AND [TypeAction] IS NULL) OR ([TypeAction] = @Original_TypeAction)) AND ((@IsNull_DateAppl = 1 AND [DateAppl] IS NULL) OR ([DateAppl] = @Original_DateAppl)) AND ((@IsNull_DateAction = 1 AND [DateAction] IS NULL) OR ([DateAction] = @Original_DateAction)) AND ((@IsNull_LegalAbns = 1 AND [LegalAbns] IS NULL) OR ([LegalAbns] = @Original_LegalAbns)) AND ((@IsNull_Sent = 1 AND [Sent] IS NULL) OR ([Sent] = @Original_Sent)))";
		this.sqlDataAdapter_0.DeleteCommand.CommandType = CommandType.Text;
		this.sqlDataAdapter_0.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Id", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Original, false, null, "", "", ""));
		this.sqlDataAdapter_0.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_NumDoc", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "NumDoc", DataRowVersion.Original, true, null, "", "", ""));
		this.sqlDataAdapter_0.DeleteCommand.Parameters.Add(new SqlParameter("@Original_NumDoc", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "NumDoc", DataRowVersion.Original, false, null, "", "", ""));
		this.sqlDataAdapter_0.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_NetArea", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "NetArea", DataRowVersion.Original, true, null, "", "", ""));
		this.sqlDataAdapter_0.DeleteCommand.Parameters.Add(new SqlParameter("@Original_NetArea", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "NetArea", DataRowVersion.Original, false, null, "", "", ""));
		this.sqlDataAdapter_0.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_TypeAction", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "TypeAction", DataRowVersion.Original, true, null, "", "", ""));
		this.sqlDataAdapter_0.DeleteCommand.Parameters.Add(new SqlParameter("@Original_TypeAction", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "TypeAction", DataRowVersion.Original, false, null, "", "", ""));
		this.sqlDataAdapter_0.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_DateAppl", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "DateAppl", DataRowVersion.Original, true, null, "", "", ""));
		this.sqlDataAdapter_0.DeleteCommand.Parameters.Add(new SqlParameter("@Original_DateAppl", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "DateAppl", DataRowVersion.Original, false, null, "", "", ""));
		this.sqlDataAdapter_0.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_DateAction", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "DateAction", DataRowVersion.Original, true, null, "", "", ""));
		this.sqlDataAdapter_0.DeleteCommand.Parameters.Add(new SqlParameter("@Original_DateAction", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "DateAction", DataRowVersion.Original, false, null, "", "", ""));
		this.sqlDataAdapter_0.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_LegalAbns", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "LegalAbns", DataRowVersion.Original, true, null, "", "", ""));
		this.sqlDataAdapter_0.DeleteCommand.Parameters.Add(new SqlParameter("@Original_LegalAbns", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "LegalAbns", DataRowVersion.Original, false, null, "", "", ""));
		this.sqlDataAdapter_0.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Sent", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Sent", DataRowVersion.Original, true, null, "", "", ""));
		this.sqlDataAdapter_0.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Sent", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Sent", DataRowVersion.Original, false, null, "", "", ""));
		this.sqlDataAdapter_0.InsertCommand = new SqlCommand();
		this.sqlDataAdapter_0.InsertCommand.Connection = this.SqlConnection_0;
		this.sqlDataAdapter_0.InsertCommand.CommandText = "INSERT INTO [tblAbnAplForDiscon] ([NumDoc], [NetArea], [TypeAction], [DateAppl], [DateAction], [LegalAbns], [Sent]) VALUES (@NumDoc, @NetArea, @TypeAction, @DateAppl, @DateAction, @LegalAbns, @Sent);\r\nSELECT Id, NumDoc, NetArea, TypeAction, DateAppl, DateAction, LegalAbns, Sent FROM tblAbnAplForDiscon WHERE (Id = SCOPE_IDENTITY())";
		this.sqlDataAdapter_0.InsertCommand.CommandType = CommandType.Text;
		this.sqlDataAdapter_0.InsertCommand.Parameters.Add(new SqlParameter("@NumDoc", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "NumDoc", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.InsertCommand.Parameters.Add(new SqlParameter("@NetArea", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "NetArea", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.InsertCommand.Parameters.Add(new SqlParameter("@TypeAction", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "TypeAction", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.InsertCommand.Parameters.Add(new SqlParameter("@DateAppl", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "DateAppl", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.InsertCommand.Parameters.Add(new SqlParameter("@DateAction", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "DateAction", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.InsertCommand.Parameters.Add(new SqlParameter("@LegalAbns", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "LegalAbns", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.InsertCommand.Parameters.Add(new SqlParameter("@Sent", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Sent", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.UpdateCommand = new SqlCommand();
		this.sqlDataAdapter_0.UpdateCommand.Connection = this.SqlConnection_0;
		this.sqlDataAdapter_0.UpdateCommand.CommandText = "UPDATE       tblAbnAplForDiscon\r\nSET                NumDoc = @NumDoc, NetArea = @NetArea, TypeAction = @TypeAction, DateAppl = @DateAppl, DateAction = @DateAction, LegalAbns = @LegalAbns, \r\n                         Sent = @Sent\r\nWHERE        (Id = @Original_Id); \r\nSELECT Id, NumDoc, NetArea, TypeAction, DateAppl, DateAction, LegalAbns, Sent FROM tblAbnAplForDiscon WHERE (Id = @Id)";
		this.sqlDataAdapter_0.UpdateCommand.CommandType = CommandType.Text;
		this.sqlDataAdapter_0.UpdateCommand.Parameters.Add(new SqlParameter("@NumDoc", SqlDbType.NChar, 10, ParameterDirection.Input, 0, 0, "NumDoc", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.UpdateCommand.Parameters.Add(new SqlParameter("@NetArea", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "NetArea", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.UpdateCommand.Parameters.Add(new SqlParameter("@TypeAction", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "TypeAction", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.UpdateCommand.Parameters.Add(new SqlParameter("@DateAppl", SqlDbType.DateTime, 8, ParameterDirection.Input, 0, 0, "DateAppl", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.UpdateCommand.Parameters.Add(new SqlParameter("@DateAction", SqlDbType.DateTime, 8, ParameterDirection.Input, 0, 0, "DateAction", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.UpdateCommand.Parameters.Add(new SqlParameter("@LegalAbns", SqlDbType.Bit, 1, ParameterDirection.Input, 0, 0, "LegalAbns", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.UpdateCommand.Parameters.Add(new SqlParameter("@Sent", SqlDbType.DateTime, 8, ParameterDirection.Input, 0, 0, "Sent", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Id", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Original, false, null, "", "", ""));
		this.sqlDataAdapter_0.UpdateCommand.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Original, false, null, "", "", ""));
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	private void method_1()
	{
		this.sqlConnection_0 = new SqlConnection();
		this.sqlConnection_0.ConnectionString = Settings.Default.trueGESConnectionString;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	private void method_2()
	{
		this.sqlCommand_0 = new SqlCommand[12];
		this.sqlCommand_0[0] = new SqlCommand();
		this.sqlCommand_0[0].Connection = this.SqlConnection_0;
		this.sqlCommand_0[0].CommandText = "SELECT        Id, NumDoc, NetArea, TypeAction, DateAppl, DateAction, LegalAbns, Sent\r\nFROM            tblAbnAplForDiscon";
		this.sqlCommand_0[0].CommandType = CommandType.Text;
		this.sqlCommand_0[1] = new SqlCommand();
		this.sqlCommand_0[1].Connection = this.SqlConnection_0;
		this.sqlCommand_0[1].CommandText = "SELECT DateAction, DateAppl, Id, LegalAbns, NetArea, NumDoc, Sent, TypeAction FROM tblAbnAplForDiscon WHERE (Id = @id)";
		this.sqlCommand_0[1].CommandType = CommandType.Text;
		this.sqlCommand_0[1].Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlCommand_0[2] = new SqlCommand();
		this.sqlCommand_0[2].Connection = this.SqlConnection_0;
		this.sqlCommand_0[2].CommandText = "SELECT     tblAbnAplForDiscon.Id, tblAbnAplForDiscon.NumDoc, tblAbnAplForDiscon.NetArea, tblAbnAplForDiscon.TypeAction, tblAbnAplForDiscon.DateAppl, \r\n                      tblAbnAplForDiscon.DateAction, tblAbnAplForDiscon.LegalAbns, tblAbnAplForDiscon.Sent\r\nFROM         dbo.tblAbnAplForDiscon INNER JOIN\r\n                      tblAbnAplForDisconIndividualUsers ON tblAbnAplForDiscon.Id = tblAbnAplForDisconIndividualUsers.IdAplForDiscon\r\nWHERE     (tblAbnAplForDisconIndividualUsers.Address LIKE @name) ";
		this.sqlCommand_0[2].CommandType = CommandType.Text;
		this.sqlCommand_0[2].Parameters.Add(new SqlParameter("@name", SqlDbType.NVarChar, 200, ParameterDirection.Input, 0, 0, "Address", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlCommand_0[3] = new SqlCommand();
		this.sqlCommand_0[3].Connection = this.SqlConnection_0;
		this.sqlCommand_0[3].CommandText = "SELECT     tblAbnAplForDiscon.Id, tblAbnAplForDiscon.NumDoc, tblAbnAplForDiscon.NetArea, tblAbnAplForDiscon.TypeAction, tblAbnAplForDiscon.DateAppl, \r\n                      tblAbnAplForDiscon.DateAction, tblAbnAplForDiscon.LegalAbns, tblAbnAplForDiscon.Sent\r\nFROM         dbo.tblAbnAplForDiscon INNER JOIN\r\n                      tblAbnAplForDisconIndividualUsers ON tblAbnAplForDiscon.Id = tblAbnAplForDisconIndividualUsers.IdAplForDiscon\r\nWHERE     (tblAbnAplForDisconIndividualUsers.Code = @code) ";
		this.sqlCommand_0[3].CommandType = CommandType.Text;
		this.sqlCommand_0[3].Parameters.Add(new SqlParameter("@code", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "Code", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlCommand_0[4] = new SqlCommand();
		this.sqlCommand_0[4].Connection = this.SqlConnection_0;
		this.sqlCommand_0[4].CommandText = "SELECT     tblAbnAplForDiscon.Id, tblAbnAplForDiscon.NumDoc, tblAbnAplForDiscon.NetArea, tblAbnAplForDiscon.TypeAction, tblAbnAplForDiscon.DateAppl, \r\n                      tblAbnAplForDiscon.DateAction, tblAbnAplForDiscon.LegalAbns, tblAbnAplForDiscon.Sent\r\nFROM         dbo.tblAbnAplForDiscon INNER JOIN\r\n                      tblAbnAplForDisconIndividualUsers ON tblAbnAplForDiscon.Id = tblAbnAplForDisconIndividualUsers.IdAplForDiscon\r\nWHERE     (tblAbnAplForDisconIndividualUsers.FIO LIKE @name) ";
		this.sqlCommand_0[4].CommandType = CommandType.Text;
		this.sqlCommand_0[4].Parameters.Add(new SqlParameter("@name", SqlDbType.NVarChar, 100, ParameterDirection.Input, 0, 0, "FIO", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlCommand_0[5] = new SqlCommand();
		this.sqlCommand_0[5].Connection = this.SqlConnection_0;
		this.sqlCommand_0[5].CommandText = "SELECT     tblAbnAplForDiscon.Id, tblAbnAplForDiscon.NumDoc, tblAbnAplForDiscon.NetArea, tblAbnAplForDiscon.TypeAction, tblAbnAplForDiscon.DateAppl, \r\n                      tblAbnAplForDiscon.DateAction, tblAbnAplForDiscon.LegalAbns, tblAbnAplForDiscon.Sent\r\nFROM         tblAbnAplForDiscon INNER JOIN\r\n                      tblAbnAplForDisconObjects ON tblAbnAplForDiscon.Id = tblAbnAplForDisconObjects.IdAplForDiscon Left JOIN\r\n                      tAbn ON tblAbnAplForDisconObjects.AbnId = tAbn.id\r\nWHERE     (tAbn.CodeAbonent = @code)";
		this.sqlCommand_0[5].CommandType = CommandType.Text;
		this.sqlCommand_0[5].Parameters.Add(new SqlParameter("@code", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "CodeAbonent", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlCommand_0[6] = new SqlCommand();
		this.sqlCommand_0[6].Connection = this.SqlConnection_0;
		this.sqlCommand_0[6].CommandText = "SELECT     tblAbnAplForDiscon.Id, tblAbnAplForDiscon.NumDoc, tblAbnAplForDiscon.NetArea, tblAbnAplForDiscon.TypeAction, tblAbnAplForDiscon.DateAppl, \r\n                      tblAbnAplForDiscon.DateAction, tblAbnAplForDiscon.LegalAbns, tblAbnAplForDiscon.Sent\r\nFROM         tblAbnAplForDiscon INNER JOIN\r\n                      tblAbnAplForDisconObjects ON tblAbnAplForDiscon.Id = tblAbnAplForDisconObjects.IdAplForDiscon Left JOIN\r\n                      tAbn ON tblAbnAplForDisconObjects.AbnId = tAbn.id\r\nWHERE     (tAbn.Name LIKE @name) OR\r\n                     (tblAbnAplForDisconObjects.NoDogAbn LIKE @name)";
		this.sqlCommand_0[6].CommandType = CommandType.Text;
		this.sqlCommand_0[6].Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar, 100, ParameterDirection.Input, 0, 0, "Name", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlCommand_0[7] = new SqlCommand();
		this.sqlCommand_0[7].Connection = this.SqlConnection_0;
		this.sqlCommand_0[7].CommandText = "SELECT     tblAbnAplForDiscon.Id, tblAbnAplForDiscon.NumDoc, tblAbnAplForDiscon.NetArea, tblAbnAplForDiscon.TypeAction, tblAbnAplForDiscon.DateAppl, \r\n                      tblAbnAplForDiscon.DateAction, tblAbnAplForDiscon.LegalAbns, tblAbnAplForDiscon.Sent\r\nFROM         tblAbnAplForDiscon INNER JOIN\r\n                      tblAbnAplForDisconObjects ON tblAbnAplForDiscon.Id = tblAbnAplForDisconObjects.IdAplForDiscon left JOIN\r\n                      tAbnObj ON tblAbnAplForDisconObjects.AbnObjId = tAbnObj.id\r\nWHERE     (tAbnObj.Name LIKE @name) ";
		this.sqlCommand_0[7].CommandType = CommandType.Text;
		this.sqlCommand_0[7].Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar, 255, ParameterDirection.Input, 0, 0, "Name", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlCommand_0[8] = new SqlCommand();
		this.sqlCommand_0[8].Connection = this.SqlConnection_0;
		this.sqlCommand_0[8].CommandText = "SELECT        DateAction\r\nFROM            tblAbnAplForDiscon\r\nWHERE        (Id = @id)";
		this.sqlCommand_0[8].CommandType = CommandType.Text;
		this.sqlCommand_0[8].Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlCommand_0[9] = new SqlCommand();
		this.sqlCommand_0[9].Connection = this.SqlConnection_0;
		this.sqlCommand_0[9].CommandText = "SELECT        DateAppl\r\nFROM            tblAbnAplForDiscon\r\nWHERE        (Id = @id)";
		this.sqlCommand_0[9].CommandType = CommandType.Text;
		this.sqlCommand_0[9].Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlCommand_0[10] = new SqlCommand();
		this.sqlCommand_0[10].Connection = this.SqlConnection_0;
		this.sqlCommand_0[10].CommandText = "SELECT        NumDoc\r\nFROM            tblAbnAplForDiscon\r\nWHERE        (Id = @Id)";
		this.sqlCommand_0[10].CommandType = CommandType.Text;
		this.sqlCommand_0[10].Parameters.Add(new SqlParameter("@Id", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlCommand_0[11] = new SqlCommand();
		this.sqlCommand_0[11].Connection = this.SqlConnection_0;
		this.sqlCommand_0[11].CommandText = "SELECT TOP (1) Id AS LastId FROM tblAbnAplForDiscon ORDER BY LastId DESC";
		this.sqlCommand_0[11].CommandType = CommandType.Text;
	}

	[DataObjectMethod(DataObjectMethodType.Fill, true)]
	[HelpKeyword("vs.data.TableAdapter")]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	public virtual int vmethod_0(Class548.Class549 class549_0)
	{
		this.SqlDataAdapter_0.SelectCommand = this.SqlCommand_0[0];
		if (this.Boolean_0)
		{
			class549_0.Clear();
		}
		return this.SqlDataAdapter_0.Fill(class549_0);
	}

	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Select, true)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	public virtual Class548.Class549 vmethod_1()
	{
		this.SqlDataAdapter_0.SelectCommand = this.SqlCommand_0[0];
		Class548.Class549 @class = new Class548.Class549();
		this.SqlDataAdapter_0.Fill(@class);
		return @class;
	}

	[DataObjectMethod(DataObjectMethodType.Fill, false)]
	[DebuggerNonUserCode]
	[HelpKeyword("vs.data.TableAdapter")]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public virtual int vmethod_2(Class548.Class549 class549_0, int? nullable_0)
	{
		this.SqlDataAdapter_0.SelectCommand = this.SqlCommand_0[1];
		if (nullable_0 != null)
		{
			this.SqlDataAdapter_0.SelectCommand.Parameters[0].Value = nullable_0.Value;
		}
		else
		{
			this.SqlDataAdapter_0.SelectCommand.Parameters[0].Value = DBNull.Value;
		}
		if (this.Boolean_0)
		{
			class549_0.Clear();
		}
		return this.SqlDataAdapter_0.Fill(class549_0);
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Select, false)]
	[DebuggerNonUserCode]
	public virtual Class548.Class549 vmethod_3(int? nullable_0)
	{
		this.SqlDataAdapter_0.SelectCommand = this.SqlCommand_0[1];
		if (nullable_0 != null)
		{
			this.SqlDataAdapter_0.SelectCommand.Parameters[0].Value = nullable_0.Value;
		}
		else
		{
			this.SqlDataAdapter_0.SelectCommand.Parameters[0].Value = DBNull.Value;
		}
		Class548.Class549 @class = new Class548.Class549();
		this.SqlDataAdapter_0.Fill(@class);
		return @class;
	}

	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Fill, false)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	public virtual int vmethod_4(Class548.Class549 class549_0, string string_0)
	{
		this.SqlDataAdapter_0.SelectCommand = this.SqlCommand_0[2];
		if (string_0 == null)
		{
			this.SqlDataAdapter_0.SelectCommand.Parameters[0].Value = DBNull.Value;
		}
		else
		{
			this.SqlDataAdapter_0.SelectCommand.Parameters[0].Value = string_0;
		}
		if (this.Boolean_0)
		{
			class549_0.Clear();
		}
		return this.SqlDataAdapter_0.Fill(class549_0);
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Select, false)]
	[DebuggerNonUserCode]
	public virtual Class548.Class549 vmethod_5(string string_0)
	{
		this.SqlDataAdapter_0.SelectCommand = this.SqlCommand_0[2];
		if (string_0 == null)
		{
			this.SqlDataAdapter_0.SelectCommand.Parameters[0].Value = DBNull.Value;
		}
		else
		{
			this.SqlDataAdapter_0.SelectCommand.Parameters[0].Value = string_0;
		}
		Class548.Class549 @class = new Class548.Class549();
		this.SqlDataAdapter_0.Fill(@class);
		return @class;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Fill, false)]
	[DebuggerNonUserCode]
	public virtual int vmethod_6(Class548.Class549 class549_0, int? nullable_0)
	{
		this.SqlDataAdapter_0.SelectCommand = this.SqlCommand_0[3];
		if (nullable_0 != null)
		{
			this.SqlDataAdapter_0.SelectCommand.Parameters[0].Value = nullable_0.Value;
		}
		else
		{
			this.SqlDataAdapter_0.SelectCommand.Parameters[0].Value = DBNull.Value;
		}
		if (this.Boolean_0)
		{
			class549_0.Clear();
		}
		return this.SqlDataAdapter_0.Fill(class549_0);
	}

	[DebuggerNonUserCode]
	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Select, false)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public virtual Class548.Class549 vmethod_7(int? nullable_0)
	{
		this.SqlDataAdapter_0.SelectCommand = this.SqlCommand_0[3];
		if (nullable_0 != null)
		{
			this.SqlDataAdapter_0.SelectCommand.Parameters[0].Value = nullable_0.Value;
		}
		else
		{
			this.SqlDataAdapter_0.SelectCommand.Parameters[0].Value = DBNull.Value;
		}
		Class548.Class549 @class = new Class548.Class549();
		this.SqlDataAdapter_0.Fill(@class);
		return @class;
	}

	[DataObjectMethod(DataObjectMethodType.Fill, false)]
	[HelpKeyword("vs.data.TableAdapter")]
	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public virtual int vmethod_8(Class548.Class549 class549_0, string string_0)
	{
		this.SqlDataAdapter_0.SelectCommand = this.SqlCommand_0[4];
		if (string_0 == null)
		{
			this.SqlDataAdapter_0.SelectCommand.Parameters[0].Value = DBNull.Value;
		}
		else
		{
			this.SqlDataAdapter_0.SelectCommand.Parameters[0].Value = string_0;
		}
		if (this.Boolean_0)
		{
			class549_0.Clear();
		}
		return this.SqlDataAdapter_0.Fill(class549_0);
	}

	[DataObjectMethod(DataObjectMethodType.Select, false)]
	[HelpKeyword("vs.data.TableAdapter")]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	public virtual Class548.Class549 vmethod_9(string string_0)
	{
		this.SqlDataAdapter_0.SelectCommand = this.SqlCommand_0[4];
		if (string_0 == null)
		{
			this.SqlDataAdapter_0.SelectCommand.Parameters[0].Value = DBNull.Value;
		}
		else
		{
			this.SqlDataAdapter_0.SelectCommand.Parameters[0].Value = string_0;
		}
		Class548.Class549 @class = new Class548.Class549();
		this.SqlDataAdapter_0.Fill(@class);
		return @class;
	}

	[DataObjectMethod(DataObjectMethodType.Fill, false)]
	[HelpKeyword("vs.data.TableAdapter")]
	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public virtual int vmethod_10(Class548.Class549 class549_0, int int_0)
	{
		this.SqlDataAdapter_0.SelectCommand = this.SqlCommand_0[5];
		this.SqlDataAdapter_0.SelectCommand.Parameters[0].Value = int_0;
		if (this.Boolean_0)
		{
			class549_0.Clear();
		}
		return this.SqlDataAdapter_0.Fill(class549_0);
	}

	[DataObjectMethod(DataObjectMethodType.Select, false)]
	[DebuggerNonUserCode]
	[HelpKeyword("vs.data.TableAdapter")]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public virtual Class548.Class549 vmethod_11(int int_0)
	{
		this.SqlDataAdapter_0.SelectCommand = this.SqlCommand_0[5];
		this.SqlDataAdapter_0.SelectCommand.Parameters[0].Value = int_0;
		Class548.Class549 @class = new Class548.Class549();
		this.SqlDataAdapter_0.Fill(@class);
		return @class;
	}

	[DebuggerNonUserCode]
	[DataObjectMethod(DataObjectMethodType.Fill, false)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	public virtual int vmethod_12(Class548.Class549 class549_0, string string_0)
	{
		this.SqlDataAdapter_0.SelectCommand = this.SqlCommand_0[6];
		if (string_0 == null)
		{
			this.SqlDataAdapter_0.SelectCommand.Parameters[0].Value = DBNull.Value;
		}
		else
		{
			this.SqlDataAdapter_0.SelectCommand.Parameters[0].Value = string_0;
		}
		if (this.Boolean_0)
		{
			class549_0.Clear();
		}
		return this.SqlDataAdapter_0.Fill(class549_0);
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	[DebuggerNonUserCode]
	[DataObjectMethod(DataObjectMethodType.Select, false)]
	public virtual Class548.Class549 vmethod_13(string string_0)
	{
		this.SqlDataAdapter_0.SelectCommand = this.SqlCommand_0[6];
		if (string_0 == null)
		{
			this.SqlDataAdapter_0.SelectCommand.Parameters[0].Value = DBNull.Value;
		}
		else
		{
			this.SqlDataAdapter_0.SelectCommand.Parameters[0].Value = string_0;
		}
		Class548.Class549 @class = new Class548.Class549();
		this.SqlDataAdapter_0.Fill(@class);
		return @class;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Fill, false)]
	public virtual int vmethod_14(Class548.Class549 class549_0, string string_0)
	{
		this.SqlDataAdapter_0.SelectCommand = this.SqlCommand_0[7];
		if (string_0 == null)
		{
			this.SqlDataAdapter_0.SelectCommand.Parameters[0].Value = DBNull.Value;
		}
		else
		{
			this.SqlDataAdapter_0.SelectCommand.Parameters[0].Value = string_0;
		}
		if (this.Boolean_0)
		{
			class549_0.Clear();
		}
		return this.SqlDataAdapter_0.Fill(class549_0);
	}

	[DataObjectMethod(DataObjectMethodType.Select, false)]
	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	public virtual Class548.Class549 vmethod_15(string string_0)
	{
		this.SqlDataAdapter_0.SelectCommand = this.SqlCommand_0[7];
		if (string_0 == null)
		{
			this.SqlDataAdapter_0.SelectCommand.Parameters[0].Value = DBNull.Value;
		}
		else
		{
			this.SqlDataAdapter_0.SelectCommand.Parameters[0].Value = string_0;
		}
		Class548.Class549 @class = new Class548.Class549();
		this.SqlDataAdapter_0.Fill(@class);
		return @class;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	[DebuggerNonUserCode]
	public virtual int vmethod_16(Class548.Class549 class549_0)
	{
		return this.SqlDataAdapter_0.Update(class549_0);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	public virtual int vmethod_17(Class548 class548_0)
	{
		return this.SqlDataAdapter_0.Update(class548_0, "tblAbnAplForDiscon");
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	public virtual int vmethod_18(DataRow dataRow_0)
	{
		return this.SqlDataAdapter_0.Update(new DataRow[]
		{
			dataRow_0
		});
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	public virtual int vmethod_19(DataRow[] dataRow_0)
	{
		return this.SqlDataAdapter_0.Update(dataRow_0);
	}

	[DebuggerNonUserCode]
	[DataObjectMethod(DataObjectMethodType.Delete, true)]
	[HelpKeyword("vs.data.TableAdapter")]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public virtual int vmethod_20(int? nullable_0, string string_0, int? nullable_1, int? nullable_2, DateTime? nullable_3, DateTime? nullable_4, bool? nullable_5, DateTime? nullable_6)
	{
		if (nullable_0 != null)
		{
			this.SqlDataAdapter_0.DeleteCommand.Parameters[0].Value = nullable_0.Value;
		}
		else
		{
			this.SqlDataAdapter_0.DeleteCommand.Parameters[0].Value = DBNull.Value;
		}
		if (string_0 == null)
		{
			this.SqlDataAdapter_0.DeleteCommand.Parameters[1].Value = 1;
			this.SqlDataAdapter_0.DeleteCommand.Parameters[2].Value = DBNull.Value;
		}
		else
		{
			this.SqlDataAdapter_0.DeleteCommand.Parameters[1].Value = 0;
			this.SqlDataAdapter_0.DeleteCommand.Parameters[2].Value = string_0;
		}
		if (nullable_1 != null)
		{
			this.SqlDataAdapter_0.DeleteCommand.Parameters[3].Value = 0;
			this.SqlDataAdapter_0.DeleteCommand.Parameters[4].Value = nullable_1.Value;
		}
		else
		{
			this.SqlDataAdapter_0.DeleteCommand.Parameters[3].Value = 1;
			this.SqlDataAdapter_0.DeleteCommand.Parameters[4].Value = DBNull.Value;
		}
		if (nullable_2 != null)
		{
			this.SqlDataAdapter_0.DeleteCommand.Parameters[5].Value = 0;
			this.SqlDataAdapter_0.DeleteCommand.Parameters[6].Value = nullable_2.Value;
		}
		else
		{
			this.SqlDataAdapter_0.DeleteCommand.Parameters[5].Value = 1;
			this.SqlDataAdapter_0.DeleteCommand.Parameters[6].Value = DBNull.Value;
		}
		if (nullable_3 != null)
		{
			this.SqlDataAdapter_0.DeleteCommand.Parameters[7].Value = 0;
			this.SqlDataAdapter_0.DeleteCommand.Parameters[8].Value = nullable_3.Value;
		}
		else
		{
			this.SqlDataAdapter_0.DeleteCommand.Parameters[7].Value = 1;
			this.SqlDataAdapter_0.DeleteCommand.Parameters[8].Value = DBNull.Value;
		}
		if (nullable_4 != null)
		{
			this.SqlDataAdapter_0.DeleteCommand.Parameters[9].Value = 0;
			this.SqlDataAdapter_0.DeleteCommand.Parameters[10].Value = nullable_4.Value;
		}
		else
		{
			this.SqlDataAdapter_0.DeleteCommand.Parameters[9].Value = 1;
			this.SqlDataAdapter_0.DeleteCommand.Parameters[10].Value = DBNull.Value;
		}
		if (nullable_5 != null)
		{
			this.SqlDataAdapter_0.DeleteCommand.Parameters[11].Value = 0;
			this.SqlDataAdapter_0.DeleteCommand.Parameters[12].Value = nullable_5.Value;
		}
		else
		{
			this.SqlDataAdapter_0.DeleteCommand.Parameters[11].Value = 1;
			this.SqlDataAdapter_0.DeleteCommand.Parameters[12].Value = DBNull.Value;
		}
		if (nullable_6 != null)
		{
			this.SqlDataAdapter_0.DeleteCommand.Parameters[13].Value = 0;
			this.SqlDataAdapter_0.DeleteCommand.Parameters[14].Value = nullable_6.Value;
		}
		else
		{
			this.SqlDataAdapter_0.DeleteCommand.Parameters[13].Value = 1;
			this.SqlDataAdapter_0.DeleteCommand.Parameters[14].Value = DBNull.Value;
		}
		ConnectionState state = this.SqlDataAdapter_0.DeleteCommand.Connection.State;
		if ((this.SqlDataAdapter_0.DeleteCommand.Connection.State & ConnectionState.Open) != ConnectionState.Open)
		{
			this.SqlDataAdapter_0.DeleteCommand.Connection.Open();
		}
		int result;
		try
		{
			result = this.SqlDataAdapter_0.DeleteCommand.ExecuteNonQuery();
		}
		finally
		{
			if (state == ConnectionState.Closed)
			{
				this.SqlDataAdapter_0.DeleteCommand.Connection.Close();
			}
		}
		return result;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	[DataObjectMethod(DataObjectMethodType.Insert, true)]
	[HelpKeyword("vs.data.TableAdapter")]
	public virtual int vmethod_21(string string_0, int? nullable_0, int? nullable_1, DateTime? nullable_2, DateTime? nullable_3, bool? nullable_4, DateTime? nullable_5)
	{
		if (string_0 == null)
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[0].Value = DBNull.Value;
		}
		else
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[0].Value = string_0;
		}
		if (nullable_0 != null)
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[1].Value = nullable_0.Value;
		}
		else
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[1].Value = DBNull.Value;
		}
		if (nullable_1 != null)
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[2].Value = nullable_1.Value;
		}
		else
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[2].Value = DBNull.Value;
		}
		if (nullable_2 != null)
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[3].Value = nullable_2.Value;
		}
		else
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[3].Value = DBNull.Value;
		}
		if (nullable_3 != null)
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[4].Value = nullable_3.Value;
		}
		else
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[4].Value = DBNull.Value;
		}
		if (nullable_4 != null)
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[5].Value = nullable_4.Value;
		}
		else
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[5].Value = DBNull.Value;
		}
		if (nullable_5 != null)
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[6].Value = nullable_5.Value;
		}
		else
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[6].Value = DBNull.Value;
		}
		ConnectionState state = this.SqlDataAdapter_0.InsertCommand.Connection.State;
		if ((this.SqlDataAdapter_0.InsertCommand.Connection.State & ConnectionState.Open) != ConnectionState.Open)
		{
			this.SqlDataAdapter_0.InsertCommand.Connection.Open();
		}
		int result;
		try
		{
			result = this.SqlDataAdapter_0.InsertCommand.ExecuteNonQuery();
		}
		finally
		{
			if (state == ConnectionState.Closed)
			{
				this.SqlDataAdapter_0.InsertCommand.Connection.Close();
			}
		}
		return result;
	}

	[DebuggerNonUserCode]
	[DataObjectMethod(DataObjectMethodType.Update, true)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	public virtual int vmethod_22(string string_0, int? nullable_0, int? nullable_1, DateTime? nullable_2, DateTime? nullable_3, bool? nullable_4, DateTime? nullable_5, int int_0, int int_1)
	{
		if (string_0 == null)
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[0].Value = DBNull.Value;
		}
		else
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[0].Value = string_0;
		}
		if (nullable_0 != null)
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[1].Value = nullable_0.Value;
		}
		else
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[1].Value = DBNull.Value;
		}
		if (nullable_1 != null)
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[2].Value = nullable_1.Value;
		}
		else
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[2].Value = DBNull.Value;
		}
		if (nullable_2 != null)
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[3].Value = nullable_2.Value;
		}
		else
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[3].Value = DBNull.Value;
		}
		if (nullable_3 != null)
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[4].Value = nullable_3.Value;
		}
		else
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[4].Value = DBNull.Value;
		}
		if (nullable_4 != null)
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[5].Value = nullable_4.Value;
		}
		else
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[5].Value = DBNull.Value;
		}
		if (nullable_5 != null)
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[6].Value = nullable_5.Value;
		}
		else
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[6].Value = DBNull.Value;
		}
		this.SqlDataAdapter_0.UpdateCommand.Parameters[7].Value = int_0;
		this.SqlDataAdapter_0.UpdateCommand.Parameters[8].Value = int_1;
		ConnectionState state = this.SqlDataAdapter_0.UpdateCommand.Connection.State;
		if ((this.SqlDataAdapter_0.UpdateCommand.Connection.State & ConnectionState.Open) != ConnectionState.Open)
		{
			this.SqlDataAdapter_0.UpdateCommand.Connection.Open();
		}
		int result;
		try
		{
			result = this.SqlDataAdapter_0.UpdateCommand.ExecuteNonQuery();
		}
		finally
		{
			if (state == ConnectionState.Closed)
			{
				this.SqlDataAdapter_0.UpdateCommand.Connection.Close();
			}
		}
		return result;
	}

	[HelpKeyword("vs.data.TableAdapter")]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	public virtual object vmethod_23(int? nullable_0)
	{
		SqlCommand sqlCommand = this.SqlCommand_0[8];
		if (nullable_0 != null)
		{
			sqlCommand.Parameters[0].Value = nullable_0.Value;
		}
		else
		{
			sqlCommand.Parameters[0].Value = DBNull.Value;
		}
		ConnectionState state = sqlCommand.Connection.State;
		if ((sqlCommand.Connection.State & ConnectionState.Open) != ConnectionState.Open)
		{
			sqlCommand.Connection.Open();
		}
		object obj;
		try
		{
			obj = sqlCommand.ExecuteScalar();
		}
		finally
		{
			if (state == ConnectionState.Closed)
			{
				sqlCommand.Connection.Close();
			}
		}
		if (obj != null)
		{
			if (obj.GetType() != typeof(DBNull))
			{
				return obj;
			}
		}
		return null;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	[DebuggerNonUserCode]
	public virtual object vmethod_24(int? nullable_0)
	{
		SqlCommand sqlCommand = this.SqlCommand_0[9];
		if (nullable_0 != null)
		{
			sqlCommand.Parameters[0].Value = nullable_0.Value;
		}
		else
		{
			sqlCommand.Parameters[0].Value = DBNull.Value;
		}
		ConnectionState state = sqlCommand.Connection.State;
		if ((sqlCommand.Connection.State & ConnectionState.Open) != ConnectionState.Open)
		{
			sqlCommand.Connection.Open();
		}
		object obj;
		try
		{
			obj = sqlCommand.ExecuteScalar();
		}
		finally
		{
			if (state == ConnectionState.Closed)
			{
				sqlCommand.Connection.Close();
			}
		}
		if (obj != null)
		{
			if (obj.GetType() != typeof(DBNull))
			{
				return obj;
			}
		}
		return null;
	}

	[HelpKeyword("vs.data.TableAdapter")]
	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public virtual object vmethod_25(int? nullable_0)
	{
		SqlCommand sqlCommand = this.SqlCommand_0[10];
		if (nullable_0 != null)
		{
			sqlCommand.Parameters[0].Value = nullable_0.Value;
		}
		else
		{
			sqlCommand.Parameters[0].Value = DBNull.Value;
		}
		ConnectionState state = sqlCommand.Connection.State;
		if ((sqlCommand.Connection.State & ConnectionState.Open) != ConnectionState.Open)
		{
			sqlCommand.Connection.Open();
		}
		object obj;
		try
		{
			obj = sqlCommand.ExecuteScalar();
		}
		finally
		{
			if (state == ConnectionState.Closed)
			{
				sqlCommand.Connection.Close();
			}
		}
		if (obj != null)
		{
			if (obj.GetType() != typeof(DBNull))
			{
				return obj;
			}
		}
		return null;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	[HelpKeyword("vs.data.TableAdapter")]
	public virtual object vmethod_26()
	{
		SqlCommand sqlCommand = this.SqlCommand_0[11];
		ConnectionState state = sqlCommand.Connection.State;
		if ((sqlCommand.Connection.State & ConnectionState.Open) != ConnectionState.Open)
		{
			sqlCommand.Connection.Open();
		}
		object obj;
		try
		{
			obj = sqlCommand.ExecuteScalar();
		}
		finally
		{
			if (state == ConnectionState.Closed)
			{
				sqlCommand.Connection.Close();
			}
		}
		if (obj != null)
		{
			if (obj.GetType() != typeof(DBNull))
			{
				return obj;
			}
		}
		return null;
	}

	private SqlDataAdapter sqlDataAdapter_0;

	private SqlConnection sqlConnection_0;

	private SqlTransaction sqlTransaction_0;

	private SqlCommand[] sqlCommand_0;

	private bool bool_0;
}
