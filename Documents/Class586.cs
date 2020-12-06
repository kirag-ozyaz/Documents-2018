using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using Documents.Properties;

[HelpKeyword("vs.data.TableAdapter")]
[ToolboxItem(true)]
[Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
[DesignerCategory("code")]
[DataObject(true)]
internal class Class586 : Component
{
	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public Class586()
	{
		
		
		this.Boolean_0 = true;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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
			if (this.NkyCfIhZwkL == null)
			{
				this.method_1();
			}
			return this.NkyCfIhZwkL;
		}
		set
		{
			this.NkyCfIhZwkL = value;
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

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	private void method_0()
	{
		this.sqlDataAdapter_0 = new SqlDataAdapter();
		DataTableMapping dataTableMapping = new DataTableMapping();
		dataTableMapping.SourceTable = "Table";
		dataTableMapping.DataSetTable = "tblAbnAplForDisconObjects";
		dataTableMapping.ColumnMappings.Add("Id", "Id");
		dataTableMapping.ColumnMappings.Add("IdAplForDiscon", "IdAplForDiscon");
		dataTableMapping.ColumnMappings.Add("AbnId", "AbnId");
		dataTableMapping.ColumnMappings.Add("AbnObjId", "AbnObjId");
		dataTableMapping.ColumnMappings.Add("PlaceId", "PlaceId");
		dataTableMapping.ColumnMappings.Add("Reason", "Reason");
		dataTableMapping.ColumnMappings.Add("Comments", "Comments");
		dataTableMapping.ColumnMappings.Add("DateDog", "DateDog");
		dataTableMapping.ColumnMappings.Add("Code", "Code");
		dataTableMapping.ColumnMappings.Add("NameShort", "NameShort");
		dataTableMapping.ColumnMappings.Add("AbnObj", "AbnObj");
		dataTableMapping.ColumnMappings.Add("IdCancelApl", "IdCancelApl");
		dataTableMapping.ColumnMappings.Add("DateExec", "DateExec");
		dataTableMapping.ColumnMappings.Add("FIOExec", "FIOExec");
		dataTableMapping.ColumnMappings.Add("ReasonFailure", "ReasonFailure");
		dataTableMapping.ColumnMappings.Add("NetAreaExec", "NetAreaExec");
		dataTableMapping.ColumnMappings.Add("Officer", "Officer");
		dataTableMapping.ColumnMappings.Add("ReasonCaption", "ReasonCaption");
		dataTableMapping.ColumnMappings.Add("CancelAplNumDoc", "CancelAplNumDoc");
		dataTableMapping.ColumnMappings.Add("NetAreaExecDescription", "NetAreaExecDescription");
		dataTableMapping.ColumnMappings.Add("FIOWorker", "FIOWorker");
		dataTableMapping.ColumnMappings.Add("NoDogAbn", "NoDogAbn");
		dataTableMapping.ColumnMappings.Add("NoDogObj", "NoDogObj");
		dataTableMapping.ColumnMappings.Add("Matrix", "Matrix");
		dataTableMapping.ColumnMappings.Add("DateAppl", "DateAppl");
		dataTableMapping.ColumnMappings.Add("TypeAction", "TypeAction");
		dataTableMapping.ColumnMappings.Add("NetArea", "NetArea");
		dataTableMapping.ColumnMappings.Add("DateAction", "DateAction");
		dataTableMapping.ColumnMappings.Add("Sent", "Sent");
		dataTableMapping.ColumnMappings.Add("IsFullRestriction", "IsFullRestriction");
		this.sqlDataAdapter_0.TableMappings.Add(dataTableMapping);
		this.sqlDataAdapter_0.DeleteCommand = new SqlCommand();
		this.sqlDataAdapter_0.DeleteCommand.Connection = this.SqlConnection_0;
		this.sqlDataAdapter_0.DeleteCommand.CommandText = "DELETE FROM tblAbnAplForDisconObjects\r\nWHERE        (Id = @Original_Id)";
		this.sqlDataAdapter_0.DeleteCommand.CommandType = CommandType.Text;
		this.sqlDataAdapter_0.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Id", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Original, false, null, "", "", ""));
		this.sqlDataAdapter_0.InsertCommand = new SqlCommand();
		this.sqlDataAdapter_0.InsertCommand.Connection = this.SqlConnection_0;
		this.sqlDataAdapter_0.InsertCommand.CommandText = "INSERT INTO tblAbnAplForDisconObjects\r\n                         (IdAplForDiscon, AbnId, AbnObjId, PlaceId, Reason, Comments, IdCancelApl, DateExec, FIOExec, ReasonFailure, NetAreaExec, Officer, NoDogAbn, NoDogObj, Matrix, \r\n                         IsFullRestriction)\r\nVALUES        (@IdAplForDiscon,@AbnId,@AbnObjId,@PlaceId,@Reason,@Comments,@IdCancelApl,@DateExec,@FIOExec,@ReasonFailure,@NetAreaExec,@Officer,@NoDogAbn,@NoDogObj,@Matrix,@IsFullRestriction);          \r\nSELECT Id, IdAplForDiscon, AbnId, AbnObjId, PlaceId, Reason, Comments FROM tblAbnAplForDisconObjects WHERE (Id = @Id)";
		this.sqlDataAdapter_0.InsertCommand.CommandType = CommandType.Text;
		this.sqlDataAdapter_0.InsertCommand.Parameters.Add(new SqlParameter("@IdAplForDiscon", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "IdAplForDiscon", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.InsertCommand.Parameters.Add(new SqlParameter("@AbnId", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "AbnId", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.InsertCommand.Parameters.Add(new SqlParameter("@AbnObjId", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "AbnObjId", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.InsertCommand.Parameters.Add(new SqlParameter("@PlaceId", SqlDbType.VarChar, 255, ParameterDirection.Input, 0, 0, "PlaceId", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.InsertCommand.Parameters.Add(new SqlParameter("@Reason", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "Reason", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.InsertCommand.Parameters.Add(new SqlParameter("@Comments", SqlDbType.VarChar, 255, ParameterDirection.Input, 0, 0, "Comments", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.InsertCommand.Parameters.Add(new SqlParameter("@IdCancelApl", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "IdCancelApl", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.InsertCommand.Parameters.Add(new SqlParameter("@DateExec", SqlDbType.DateTime, 8, ParameterDirection.Input, 0, 0, "DateExec", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.InsertCommand.Parameters.Add(new SqlParameter("@FIOExec", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "FIOExec", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.InsertCommand.Parameters.Add(new SqlParameter("@ReasonFailure", SqlDbType.VarChar, 500, ParameterDirection.Input, 0, 0, "ReasonFailure", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.InsertCommand.Parameters.Add(new SqlParameter("@NetAreaExec", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "NetAreaExec", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.InsertCommand.Parameters.Add(new SqlParameter("@Officer", SqlDbType.VarChar, 100, ParameterDirection.Input, 0, 0, "Officer", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.InsertCommand.Parameters.Add(new SqlParameter("@NoDogAbn", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, 0, 0, "NoDogAbn", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.InsertCommand.Parameters.Add(new SqlParameter("@NoDogObj", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, 0, 0, "NoDogObj", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.InsertCommand.Parameters.Add(new SqlParameter("@Matrix", SqlDbType.Bit, 1, ParameterDirection.Input, 0, 0, "Matrix", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.InsertCommand.Parameters.Add(new SqlParameter("@IsFullRestriction", SqlDbType.Bit, 1, ParameterDirection.Input, 0, 0, "IsFullRestriction", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.InsertCommand.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.UpdateCommand = new SqlCommand();
		this.sqlDataAdapter_0.UpdateCommand.Connection = this.SqlConnection_0;
		this.sqlDataAdapter_0.UpdateCommand.CommandText = "UPDATE       tblAbnAplForDisconObjects\r\nSET                IdAplForDiscon = @IdAplForDiscon, AbnId = @AbnId, AbnObjId = @AbnObjId, PlaceId = @PlaceId, Reason = @Reason, Comments = @Comments, \r\n                         IdCancelApl = @IdCancelApl, DateExec = @DateExec, FIOExec = @FIOExec, ReasonFailure = @ReasonFailure, NetAreaExec = @NetAreaExec, Officer = @Officer, \r\n                         NoDogAbn = @NoDogAbn, NoDogObj = @NoDogObj, Matrix = @Matrix, IsFullRestriction = @IsFullRestriction\r\nWHERE        (Id = @Original_Id)";
		this.sqlDataAdapter_0.UpdateCommand.CommandType = CommandType.Text;
		this.sqlDataAdapter_0.UpdateCommand.Parameters.Add(new SqlParameter("@IdAplForDiscon", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "IdAplForDiscon", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.UpdateCommand.Parameters.Add(new SqlParameter("@AbnId", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "AbnId", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.UpdateCommand.Parameters.Add(new SqlParameter("@AbnObjId", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "AbnObjId", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.UpdateCommand.Parameters.Add(new SqlParameter("@PlaceId", SqlDbType.VarChar, 255, ParameterDirection.Input, 0, 0, "PlaceId", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.UpdateCommand.Parameters.Add(new SqlParameter("@Reason", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "Reason", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.UpdateCommand.Parameters.Add(new SqlParameter("@Comments", SqlDbType.VarChar, 255, ParameterDirection.Input, 0, 0, "Comments", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.UpdateCommand.Parameters.Add(new SqlParameter("@IdCancelApl", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "IdCancelApl", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.UpdateCommand.Parameters.Add(new SqlParameter("@DateExec", SqlDbType.DateTime, 8, ParameterDirection.Input, 0, 0, "DateExec", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.UpdateCommand.Parameters.Add(new SqlParameter("@FIOExec", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "FIOExec", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.UpdateCommand.Parameters.Add(new SqlParameter("@ReasonFailure", SqlDbType.VarChar, 500, ParameterDirection.Input, 0, 0, "ReasonFailure", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.UpdateCommand.Parameters.Add(new SqlParameter("@NetAreaExec", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "NetAreaExec", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.UpdateCommand.Parameters.Add(new SqlParameter("@Officer", SqlDbType.VarChar, 100, ParameterDirection.Input, 0, 0, "Officer", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.UpdateCommand.Parameters.Add(new SqlParameter("@NoDogAbn", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, 0, 0, "NoDogAbn", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.UpdateCommand.Parameters.Add(new SqlParameter("@NoDogObj", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, 0, 0, "NoDogObj", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.UpdateCommand.Parameters.Add(new SqlParameter("@Matrix", SqlDbType.Bit, 1, ParameterDirection.Input, 0, 0, "Matrix", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.UpdateCommand.Parameters.Add(new SqlParameter("@IsFullRestriction", SqlDbType.Bit, 1, ParameterDirection.Input, 0, 0, "IsFullRestriction", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Id", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Original, false, null, "", "", ""));
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	private void method_1()
	{
		this.NkyCfIhZwkL = new SqlConnection();
		this.NkyCfIhZwkL.ConnectionString = Settings.Default.trueGESConnectionString;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	private void method_2()
	{
		this.sqlCommand_0 = new SqlCommand[10];
		this.sqlCommand_0[0] = new SqlCommand();
		this.sqlCommand_0[0].Connection = this.SqlConnection_0;
		this.sqlCommand_0[0].CommandText = "SELECT        tblAbnAplForDisconObjects.Id, tblAbnAplForDisconObjects.IdAplForDiscon, tblAbnAplForDisconObjects.AbnId, tblAbnAplForDisconObjects.AbnObjId, \r\n                         tblAbnAplForDisconObjects.PlaceId, tblAbnAplForDisconObjects.Reason, tblAbnAplForDisconObjects.Comments, tAbnDoc_Dogovor.DogDate AS DateDog, \r\n                         tAbn.CodeAbonent AS Code, tAbn.Name AS NameShort, tAbnObj.Name AS AbnObj, tblAbnAplForDisconObjects.IdCancelApl, tblAbnAplForDisconObjects.DateExec, \r\n                         tblAbnAplForDisconObjects.FIOExec, tblAbnAplForDisconObjects.ReasonFailure, tblAbnAplForDisconObjects.NetAreaExec, tblAbnAplForDisconObjects.Officer, \r\n                         tblAbnAplForDisconReason.Reason AS ReasonCaption, tblAbnAplForDiscon.NumDoc AS CancelAplNumDoc, Division.Description AS NetAreaExecDescription, \r\n                         Worker.F + ' ' + Worker.I + ' ' + Worker.O AS FIOWorker, tblAbnAplForDisconObjects.NoDogAbn, tblAbnAplForDisconObjects.NoDogObj, \r\n                         tblAbnAplForDisconObjects.Matrix, tblAbnAplForDiscon.DateAppl, tblAbnAplForDiscon.TypeAction, tblAbnAplForDiscon.NetArea, tblAbnAplForDiscon.DateAction, \r\n                         tblAbnAplForDiscon.Sent, tblAbnAplForDisconObjects.IsFullRestriction\r\nFROM            tblAbnAplForDisconObjects LEFT OUTER JOIN\r\n                         tAbn ON tblAbnAplForDisconObjects.AbnId = tAbn.id LEFT OUTER JOIN\r\n                         tAbnDoc_Dogovor ON tblAbnAplForDisconObjects.AbnId = tAbnDoc_Dogovor.idAbn LEFT OUTER JOIN\r\n                         tAbnDoc_List ON tAbnDoc_Dogovor.idList = tAbnDoc_List.id LEFT OUTER JOIN\r\n                         tAbnObj ON tblAbnAplForDisconObjects.AbnObjId = tAbnObj.id LEFT OUTER JOIN\r\n                         tblAbnAplForDisconReason ON tblAbnAplForDisconObjects.Reason = tblAbnAplForDisconReason.Id LEFT OUTER JOIN\r\n                         tblAbnAplForDiscon ON tblAbnAplForDisconObjects.IdCancelApl = tblAbnAplForDiscon.Id LEFT OUTER JOIN\r\n                         tR_Division AS Division ON tblAbnAplForDisconObjects.NetAreaExec = Division.id LEFT OUTER JOIN\r\n                         tR_Worker AS Worker ON tblAbnAplForDisconObjects.FIOExec = Worker.id\r\nWHERE        (tblAbnAplForDisconObjects.IdAplForDiscon = @IdAplForDiscon) AND (tblAbnAplForDisconObjects.AbnId IS NULL) OR\r\n                         (tblAbnAplForDisconObjects.IdAplForDiscon = @IdAplForDiscon) AND (tblAbnAplForDisconObjects.AbnId IS NOT NULL) AND (tAbnDoc_List.isActive = 1)";
		this.sqlCommand_0[0].CommandType = CommandType.Text;
		this.sqlCommand_0[0].Parameters.Add(new SqlParameter("@IdAplForDiscon", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "IdAplForDiscon", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlCommand_0[1] = new SqlCommand();
		this.sqlCommand_0[1].Connection = this.SqlConnection_0;
		this.sqlCommand_0[1].CommandText = "SELECT        tblAbnAplForDisconObjects.Id, tblAbnAplForDisconObjects.IdAplForDiscon, tblAbnAplForDisconObjects.AbnId, tblAbnAplForDisconObjects.AbnObjId, \r\n                         tblAbnAplForDisconObjects.PlaceId, tblAbnAplForDisconObjects.Reason, tblAbnAplForDisconObjects.Comments, tAbnDoc_Dogovor.DogDate AS DateDog, \r\n                         tAbn.CodeAbonent AS Code, tAbn.Name AS NameShort, tAbnObj.Name AS AbnObj, tblAbnAplForDisconObjects.IdCancelApl, tblAbnAplForDisconObjects.DateExec, \r\n                         tblAbnAplForDisconObjects.FIOExec, tblAbnAplForDisconObjects.ReasonFailure, tblAbnAplForDisconObjects.NetAreaExec, tblAbnAplForDisconObjects.Officer, \r\n                         tblAbnAplForDisconReason.Reason AS ReasonCaption, tblAbnAplForDiscon.NumDoc AS CancelAplNumDoc, Division.Description AS NetAreaExecDescription, \r\n                         Worker.F + ' ' + Worker.I + ' ' + Worker.O AS FIOWorker, tblAbnAplForDisconObjects.NoDogAbn, tblAbnAplForDisconObjects.NoDogObj, \r\n                         tblAbnAplForDisconObjects.Matrix, tblAbnAplForDiscon.DateAppl, tblAbnAplForDiscon.TypeAction, tblAbnAplForDiscon.NetArea, tblAbnAplForDiscon.DateAction, \r\n                         tblAbnAplForDiscon.Sent, tblAbnAplForDisconObjects.IsFullRestriction\r\nFROM            tblAbnAplForDisconObjects LEFT OUTER JOIN\r\n                         tAbn ON tblAbnAplForDisconObjects.AbnId = tAbn.id LEFT OUTER JOIN\r\n                         tAbnDoc_Dogovor ON tblAbnAplForDisconObjects.AbnId = tAbnDoc_Dogovor.idAbn LEFT OUTER JOIN\r\n                         tAbnDoc_List ON tAbnDoc_Dogovor.idList = tAbnDoc_List.id LEFT OUTER JOIN\r\n                         tAbnObj ON tblAbnAplForDisconObjects.AbnObjId = tAbnObj.id LEFT OUTER JOIN\r\n                         tblAbnAplForDisconReason ON tblAbnAplForDisconObjects.Reason = tblAbnAplForDisconReason.Id LEFT OUTER JOIN\r\n                         tblAbnAplForDiscon ON tblAbnAplForDisconObjects.IdCancelApl = tblAbnAplForDiscon.Id LEFT OUTER JOIN\r\n                         tR_Division AS Division ON tblAbnAplForDisconObjects.NetAreaExec = Division.id LEFT OUTER JOIN\r\n                         tR_Worker AS Worker ON tblAbnAplForDisconObjects.FIOExec = Worker.id\r\nWHERE        (tblAbnAplForDisconObjects.AbnId IS NULL) AND (tblAbnAplForDisconObjects.NoDogAbn LIKE @name) OR\r\n                         (tblAbnAplForDisconObjects.AbnId IS NOT NULL) AND (tAbnDoc_List.isActive = 1) AND (tAbn.Name LIKE @name)";
		this.sqlCommand_0[1].CommandType = CommandType.Text;
		this.sqlCommand_0[1].Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, 0, 0, "NoDogAbn", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlCommand_0[2] = new SqlCommand();
		this.sqlCommand_0[2].Connection = this.SqlConnection_0;
		this.sqlCommand_0[2].CommandText = "SELECT        tblAbnAplForDisconObjects.Id, tblAbnAplForDisconObjects.IdAplForDiscon, tblAbnAplForDisconObjects.AbnId, tblAbnAplForDisconObjects.AbnObjId, \r\n                         tblAbnAplForDisconObjects.PlaceId, tblAbnAplForDisconObjects.Reason, tblAbnAplForDisconObjects.Comments, tAbnDoc_Dogovor.DogDate AS DateDog, \r\n                         tAbn.CodeAbonent AS Code, tAbn.Name AS NameShort, tAbnObj.Name AS AbnObj, tblAbnAplForDisconObjects.IdCancelApl, tblAbnAplForDisconObjects.DateExec, \r\n                         tblAbnAplForDisconObjects.FIOExec, tblAbnAplForDisconObjects.ReasonFailure, tblAbnAplForDisconObjects.NetAreaExec, tblAbnAplForDisconObjects.Officer, \r\n                         tblAbnAplForDisconReason.Reason AS ReasonCaption, tblAbnAplForDiscon.NumDoc AS CancelAplNumDoc, Division.Description AS NetAreaExecDescription, \r\n                         Worker.F + ' ' + Worker.I + ' ' + Worker.O AS FIOWorker, tblAbnAplForDisconObjects.NoDogAbn, tblAbnAplForDisconObjects.NoDogObj, \r\n                         tblAbnAplForDisconObjects.Matrix, tblAbnAplForDisconObjects.IsFullRestriction\r\nFROM            tblAbnAplForDisconObjects LEFT OUTER JOIN\r\n                         tAbn ON tblAbnAplForDisconObjects.AbnId = tAbn.id LEFT OUTER JOIN\r\n                         tAbnDoc_Dogovor ON tblAbnAplForDisconObjects.AbnId = tAbnDoc_Dogovor.idAbn LEFT OUTER JOIN\r\n                         tAbnDoc_List ON tAbnDoc_Dogovor.idList = tAbnDoc_List.id LEFT OUTER JOIN\r\n                         tAbnObj ON tblAbnAplForDisconObjects.AbnObjId = tAbnObj.id LEFT OUTER JOIN\r\n                         tblAbnAplForDisconReason ON tblAbnAplForDisconObjects.Reason = tblAbnAplForDisconReason.Id LEFT OUTER JOIN\r\n                         tblAbnAplForDiscon ON tblAbnAplForDisconObjects.IdCancelApl = tblAbnAplForDiscon.Id LEFT OUTER JOIN\r\n                         tR_Division AS Division ON tblAbnAplForDisconObjects.NetAreaExec = Division.id LEFT OUTER JOIN\r\n                         tR_Worker AS Worker ON tblAbnAplForDisconObjects.FIOExec = Worker.id\r\nWHERE        (tblAbnAplForDisconObjects.Id = @Id) AND (tblAbnAplForDisconObjects.AbnId IS NULL) OR\r\n                         (tblAbnAplForDisconObjects.Id = @Id) AND (tblAbnAplForDisconObjects.AbnId IS NOT NULL) AND (tAbnDoc_List.isActive = 1)";
		this.sqlCommand_0[2].CommandType = CommandType.Text;
		this.sqlCommand_0[2].Parameters.Add(new SqlParameter("@Id", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlCommand_0[3] = new SqlCommand();
		this.sqlCommand_0[3].Connection = this.SqlConnection_0;
		this.sqlCommand_0[3].CommandText = "SELECT        tblAbnAplForDisconObjects.Id, tblAbnAplForDisconObjects.IdAplForDiscon, tblAbnAplForDisconObjects.AbnId, tblAbnAplForDisconObjects.AbnObjId, \r\n                         tblAbnAplForDisconObjects.PlaceId, tblAbnAplForDisconObjects.Reason, tblAbnAplForDisconObjects.Comments, tAbnDoc_Dogovor.DogDate AS DateDog, \r\n                         tAbn.CodeAbonent AS Code, tAbn.Name AS NameShort, tAbnObj.Name AS AbnObj, tblAbnAplForDisconObjects.IdCancelApl, tblAbnAplForDisconObjects.DateExec, \r\n                         tblAbnAplForDisconObjects.FIOExec, tblAbnAplForDisconObjects.ReasonFailure, tblAbnAplForDisconObjects.NetAreaExec, tblAbnAplForDisconObjects.Officer, \r\n                         tblAbnAplForDisconReason.Reason AS ReasonCaption, tblAbnAplForDiscon.NumDoc AS CancelAplNumDoc, Division.Description AS NetAreaExecDescription, \r\n                         Worker.F + ' ' + Worker.I + ' ' + Worker.O AS FIOWorker, tblAbnAplForDisconObjects.NoDogAbn, tblAbnAplForDisconObjects.NoDogObj, \r\n                         tblAbnAplForDisconObjects.Matrix, tblAbnAplForDiscon.DateAppl, tblAbnAplForDiscon.TypeAction, tblAbnAplForDiscon.NetArea, tblAbnAplForDiscon.DateAction, \r\n                         tblAbnAplForDiscon.Sent, tblAbnAplForDisconObjects.IsFullRestriction\r\nFROM            tblAbnAplForDisconObjects LEFT OUTER JOIN\r\n                         tAbn ON tblAbnAplForDisconObjects.AbnId = tAbn.id LEFT OUTER JOIN\r\n                         tAbnDoc_Dogovor ON tblAbnAplForDisconObjects.AbnId = tAbnDoc_Dogovor.idAbn LEFT OUTER JOIN\r\n                         tAbnDoc_List ON tAbnDoc_Dogovor.idList = tAbnDoc_List.id LEFT OUTER JOIN\r\n                         tAbnObj ON tblAbnAplForDisconObjects.AbnObjId = tAbnObj.id LEFT OUTER JOIN\r\n                         tblAbnAplForDisconReason ON tblAbnAplForDisconObjects.Reason = tblAbnAplForDisconReason.Id LEFT OUTER JOIN\r\n                         tblAbnAplForDiscon ON tblAbnAplForDisconObjects.IdCancelApl = tblAbnAplForDiscon.Id LEFT OUTER JOIN\r\n                         tR_Division AS Division ON tblAbnAplForDisconObjects.NetAreaExec = Division.id LEFT OUTER JOIN\r\n                         tR_Worker AS Worker ON tblAbnAplForDisconObjects.FIOExec = Worker.id\r\nWHERE        (tAbnDoc_List.isActive = 1) AND (tblAbnAplForDisconObjects.AbnId IS NOT NULL) AND (tAbnObj.Name LIKE @name)";
		this.sqlCommand_0[3].CommandType = CommandType.Text;
		this.sqlCommand_0[3].Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar, 255, ParameterDirection.Input, 0, 0, "AbnObj", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlCommand_0[4] = new SqlCommand();
		this.sqlCommand_0[4].Connection = this.SqlConnection_0;
		this.sqlCommand_0[4].CommandText = "SELECT        tblAbnAplForDisconObjects.Id, tblAbnAplForDisconObjects.IdAplForDiscon, tblAbnAplForDisconObjects.AbnId, tblAbnAplForDisconObjects.AbnObjId, \r\n                         tblAbnAplForDisconObjects.PlaceId, tblAbnAplForDisconObjects.Reason, tblAbnAplForDisconObjects.Comments, tAbnDoc_Dogovor.DogDate AS DateDog, \r\n                         tAbn.CodeAbonent AS Code, tAbn.Name AS NameShort, tAbnObj.Name AS AbnObj, tblAbnAplForDisconObjects.IdCancelApl, tblAbnAplForDisconObjects.DateExec, \r\n                         tblAbnAplForDisconObjects.FIOExec, tblAbnAplForDisconObjects.ReasonFailure, tblAbnAplForDisconObjects.NetAreaExec, tblAbnAplForDisconObjects.Officer, \r\n                         tblAbnAplForDisconReason.Reason AS ReasonCaption, tblAbnAplForDiscon.NumDoc AS CancelAplNumDoc, Division.Description AS NetAreaExecDescription, \r\n                         Worker.F + ' ' + Worker.I + ' ' + Worker.O AS FIOWorker, tblAbnAplForDisconObjects.NoDogAbn, tblAbnAplForDisconObjects.NoDogObj, \r\n                         tblAbnAplForDisconObjects.Matrix, tblAbnAplForDiscon.DateAppl, tblAbnAplForDiscon.TypeAction, tblAbnAplForDiscon.NetArea, tblAbnAplForDiscon.DateAction, \r\n                         tblAbnAplForDiscon.Sent, tblAbnAplForDisconObjects.IsFullRestriction\r\nFROM            tblAbnAplForDisconObjects LEFT OUTER JOIN\r\n                         tAbn ON tblAbnAplForDisconObjects.AbnId = tAbn.id LEFT OUTER JOIN\r\n                         tAbnDoc_Dogovor ON tblAbnAplForDisconObjects.AbnId = tAbnDoc_Dogovor.idAbn LEFT OUTER JOIN\r\n                         tAbnDoc_List ON tAbnDoc_Dogovor.idList = tAbnDoc_List.id LEFT OUTER JOIN\r\n                         tAbnObj ON tblAbnAplForDisconObjects.AbnObjId = tAbnObj.id LEFT OUTER JOIN\r\n                         tblAbnAplForDisconReason ON tblAbnAplForDisconObjects.Reason = tblAbnAplForDisconReason.Id LEFT OUTER JOIN\r\n                         tblAbnAplForDiscon ON tblAbnAplForDisconObjects.IdCancelApl = tblAbnAplForDiscon.Id LEFT OUTER JOIN\r\n                         tR_Division AS Division ON tblAbnAplForDisconObjects.NetAreaExec = Division.id LEFT OUTER JOIN\r\n                         tR_Worker AS Worker ON tblAbnAplForDisconObjects.FIOExec = Worker.id INNER JOIN\r\n                         tblAbnAplForDiscon AS apl ON apl.Id = tblAbnAplForDisconObjects.IdAplForDiscon AND apl.TypeAction = 0\r\nWHERE        (tblAbnAplForDisconObjects.IdAplForDiscon = @IdAplForDiscon) AND (tblAbnAplForDisconObjects.AbnId IS NOT NULL) AND (tAbnDoc_List.isActive = 1) AND \r\n                         (tblAbnAplForDisconObjects.IdCancelApl IS NULL) AND (tblAbnAplForDisconObjects.DateExec IS NOT NULL) AND \r\n                         (tblAbnAplForDisconObjects.AbnObjId NOT IN\r\n                             (SELECT        obj1.AbnObjId\r\n                               FROM            tblAbnAplForDisconObjects AS obj1 INNER JOIN\r\n                                                         tblAbnAplForDiscon AS apl1 ON obj1.IdAplForDiscon = apl1.Id AND apl1.TypeAction = 1\r\n                               WHERE        (obj1.IdCancelApl IS NULL) AND (obj1.DateExec IS NOT NULL) AND (obj1.AbnId IS NOT NULL) AND (apl.DateAppl < apl1.DateAppl)))";
		this.sqlCommand_0[4].CommandType = CommandType.Text;
		this.sqlCommand_0[4].Parameters.Add(new SqlParameter("@IdAplForDiscon", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "IdAplForDiscon", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlCommand_0[5] = new SqlCommand();
		this.sqlCommand_0[5].Connection = this.SqlConnection_0;
		this.sqlCommand_0[5].CommandText = "SELECT        tblAbnAplForDisconObjects.Id, tblAbnAplForDisconObjects.IdAplForDiscon, tblAbnAplForDisconObjects.AbnId, tblAbnAplForDisconObjects.AbnObjId, \r\n                         tblAbnAplForDisconObjects.PlaceId, tblAbnAplForDisconObjects.Reason, tblAbnAplForDisconObjects.Comments, tAbnDoc_Dogovor.DogDate AS DateDog, \r\n                         tAbn.CodeAbonent AS Code, tAbn.Name AS NameShort, tAbnObj.Name AS AbnObj, tblAbnAplForDisconObjects.IdCancelApl, tblAbnAplForDisconObjects.DateExec, \r\n                         tblAbnAplForDisconObjects.FIOExec, tblAbnAplForDisconObjects.ReasonFailure, tblAbnAplForDisconObjects.NetAreaExec, tblAbnAplForDisconObjects.Officer, \r\n                         tblAbnAplForDisconReason.Reason AS ReasonCaption, tblAbnAplForDiscon.NumDoc AS CancelAplNumDoc, Division.Description AS NetAreaExecDescription, \r\n                         Worker.F + ' ' + Worker.I + ' ' + Worker.O AS FIOWorker, tblAbnAplForDisconObjects.NoDogAbn, tblAbnAplForDisconObjects.NoDogObj, \r\n                         tblAbnAplForDisconObjects.Matrix, tblAbnAplForDiscon.TypeAction, tblAbnAplForDiscon.DateAppl, tblAbnAplForDiscon.NetArea, tblAbnAplForDiscon.Sent, \r\n                         tblAbnAplForDiscon.DateAction, tblAbnAplForDisconObjects.IsFullRestriction\r\nFROM            tblAbnAplForDisconObjects LEFT OUTER JOIN\r\n                         tAbn ON tblAbnAplForDisconObjects.AbnId = tAbn.id LEFT OUTER JOIN\r\n                         tAbnDoc_Dogovor ON tblAbnAplForDisconObjects.AbnId = tAbnDoc_Dogovor.idAbn LEFT OUTER JOIN\r\n                         tAbnDoc_List ON tAbnDoc_Dogovor.idList = tAbnDoc_List.id LEFT OUTER JOIN\r\n                         tAbnObj ON tblAbnAplForDisconObjects.AbnObjId = tAbnObj.id LEFT OUTER JOIN\r\n                         tblAbnAplForDisconReason ON tblAbnAplForDisconObjects.Reason = tblAbnAplForDisconReason.Id LEFT OUTER JOIN\r\n                         tblAbnAplForDiscon ON tblAbnAplForDisconObjects.IdAplForDiscon = tblAbnAplForDiscon.Id LEFT OUTER JOIN\r\n                         tR_Division AS Division ON tblAbnAplForDisconObjects.NetAreaExec = Division.id LEFT OUTER JOIN\r\n                         tR_Worker AS Worker ON tblAbnAplForDisconObjects.FIOExec = Worker.id\r\nWHERE        (tblAbnAplForDisconObjects.DateExec IS NULL) AND (tblAbnAplForDiscon.DateAction < @BegPer) AND (tblAbnAplForDisconObjects.IdCancelApl IS NULL) AND \r\n                         (tblAbnAplForDisconObjects.AbnId IS NULL) OR\r\n                         (tblAbnAplForDisconObjects.DateExec IS NULL) AND (tblAbnAplForDiscon.DateAction < @BegPer) AND (tblAbnAplForDisconObjects.IdCancelApl IS NULL) AND \r\n                         (tblAbnAplForDisconObjects.AbnId IS NOT NULL) AND (tAbnDoc_List.isActive = 1)";
		this.sqlCommand_0[5].CommandType = CommandType.Text;
		this.sqlCommand_0[5].Parameters.Add(new SqlParameter("@BegPer", SqlDbType.DateTime, 8, ParameterDirection.Input, 0, 0, "DateAction", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlCommand_0[6] = new SqlCommand();
		this.sqlCommand_0[6].Connection = this.SqlConnection_0;
		this.sqlCommand_0[6].CommandText = "UPDATE       tblAbnAplForDisconObjects\r\nSET                IdCancelApl = NULL\r\nWHERE        (AbnObjId = @AbnObjId) AND (IdCancelApl = @IdCancelApl)";
		this.sqlCommand_0[6].CommandType = CommandType.Text;
		this.sqlCommand_0[6].Parameters.Add(new SqlParameter("@AbnObjId", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "AbnObjId", DataRowVersion.Original, false, null, "", "", ""));
		this.sqlCommand_0[6].Parameters.Add(new SqlParameter("@IdCancelApl", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "IdCancelApl", DataRowVersion.Original, false, null, "", "", ""));
		this.sqlCommand_0[7] = new SqlCommand();
		this.sqlCommand_0[7].Connection = this.SqlConnection_0;
		this.sqlCommand_0[7].CommandText = "UPDATE       tblAbnAplForDisconObjects\r\nSET                IdCancelApl = NULL\r\nWHERE        (NoDogObj = @NoDogObj) AND (IdCancelApl = @IdCancelApl)";
		this.sqlCommand_0[7].CommandType = CommandType.Text;
		this.sqlCommand_0[7].Parameters.Add(new SqlParameter("@NoDogObj", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, 0, 0, "NoDogObj", DataRowVersion.Original, false, null, "", "", ""));
		this.sqlCommand_0[7].Parameters.Add(new SqlParameter("@IdCancelApl", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "IdCancelApl", DataRowVersion.Original, false, null, "", "", ""));
		this.sqlCommand_0[8] = new SqlCommand();
		this.sqlCommand_0[8].Connection = this.SqlConnection_0;
		this.sqlCommand_0[8].CommandText = "UPDATE       tblAbnAplForDisconObjects\r\nSET                IdCancelApl = @IdCancelApl\r\nWHERE        (IdAplForDiscon = @idAplForDiscon) AND (NoDogObj = @NoDogObj)";
		this.sqlCommand_0[8].CommandType = CommandType.Text;
		this.sqlCommand_0[8].Parameters.Add(new SqlParameter("@IdCancelApl", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "IdCancelApl", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlCommand_0[8].Parameters.Add(new SqlParameter("@idAplForDiscon", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "IdAplForDiscon", DataRowVersion.Original, false, null, "", "", ""));
		this.sqlCommand_0[8].Parameters.Add(new SqlParameter("@NoDogObj", SqlDbType.VarChar, 255, ParameterDirection.Input, 0, 0, "NoDogObj", DataRowVersion.Original, false, null, "", "", ""));
		this.sqlCommand_0[9] = new SqlCommand();
		this.sqlCommand_0[9].Connection = this.SqlConnection_0;
		this.sqlCommand_0[9].CommandText = "UPDATE       tblAbnAplForDisconObjects\r\nSET                IdCancelApl = @IdCancelApl\r\nWHERE        (AbnObjId = @AbnObjId) AND (IdAplForDiscon = @idAplForDiscon)";
		this.sqlCommand_0[9].CommandType = CommandType.Text;
		this.sqlCommand_0[9].Parameters.Add(new SqlParameter("@IdCancelApl", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "IdCancelApl", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlCommand_0[9].Parameters.Add(new SqlParameter("@AbnObjId", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "AbnObjId", DataRowVersion.Original, false, null, "", "", ""));
		this.sqlCommand_0[9].Parameters.Add(new SqlParameter("@idAplForDiscon", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "IdAplForDiscon", DataRowVersion.Original, false, null, "", "", ""));
	}

	[DebuggerNonUserCode]
	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Fill, true)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public virtual int vmethod_0(Class548.Class550 class550_0, int? nullable_0)
	{
		this.SqlDataAdapter_0.SelectCommand = this.SqlCommand_0[0];
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
			class550_0.Clear();
		}
		return this.SqlDataAdapter_0.Fill(class550_0);
	}

	[DebuggerNonUserCode]
	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Select, true)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public virtual Class548.Class550 vmethod_1(int? nullable_0)
	{
		this.SqlDataAdapter_0.SelectCommand = this.SqlCommand_0[0];
		if (nullable_0 != null)
		{
			this.SqlDataAdapter_0.SelectCommand.Parameters[0].Value = nullable_0.Value;
		}
		else
		{
			this.SqlDataAdapter_0.SelectCommand.Parameters[0].Value = DBNull.Value;
		}
		Class548.Class550 @class = new Class548.Class550();
		this.SqlDataAdapter_0.Fill(@class);
		return @class;
	}

	[DebuggerNonUserCode]
	[HelpKeyword("vs.data.TableAdapter")]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DataObjectMethod(DataObjectMethodType.Fill, false)]
	public virtual int vmethod_2(Class548.Class550 class550_0, string string_0)
	{
		this.SqlDataAdapter_0.SelectCommand = this.SqlCommand_0[1];
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
			class550_0.Clear();
		}
		return this.SqlDataAdapter_0.Fill(class550_0);
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	[DebuggerNonUserCode]
	[DataObjectMethod(DataObjectMethodType.Select, false)]
	public virtual Class548.Class550 vmethod_3(string string_0)
	{
		this.SqlDataAdapter_0.SelectCommand = this.SqlCommand_0[1];
		if (string_0 == null)
		{
			this.SqlDataAdapter_0.SelectCommand.Parameters[0].Value = DBNull.Value;
		}
		else
		{
			this.SqlDataAdapter_0.SelectCommand.Parameters[0].Value = string_0;
		}
		Class548.Class550 @class = new Class548.Class550();
		this.SqlDataAdapter_0.Fill(@class);
		return @class;
	}

	[HelpKeyword("vs.data.TableAdapter")]
	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DataObjectMethod(DataObjectMethodType.Fill, false)]
	public virtual int vmethod_4(Class548.Class550 class550_0, int? nullable_0)
	{
		this.SqlDataAdapter_0.SelectCommand = this.SqlCommand_0[2];
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
			class550_0.Clear();
		}
		return this.SqlDataAdapter_0.Fill(class550_0);
	}

	[DataObjectMethod(DataObjectMethodType.Select, false)]
	[HelpKeyword("vs.data.TableAdapter")]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	public virtual Class548.Class550 vmethod_5(int? nullable_0)
	{
		this.SqlDataAdapter_0.SelectCommand = this.SqlCommand_0[2];
		if (nullable_0 != null)
		{
			this.SqlDataAdapter_0.SelectCommand.Parameters[0].Value = nullable_0.Value;
		}
		else
		{
			this.SqlDataAdapter_0.SelectCommand.Parameters[0].Value = DBNull.Value;
		}
		Class548.Class550 @class = new Class548.Class550();
		this.SqlDataAdapter_0.Fill(@class);
		return @class;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Fill, false)]
	[DebuggerNonUserCode]
	public virtual int vmethod_6(Class548.Class550 class550_0, string string_0)
	{
		this.SqlDataAdapter_0.SelectCommand = this.SqlCommand_0[3];
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
			class550_0.Clear();
		}
		return this.SqlDataAdapter_0.Fill(class550_0);
	}

	[DataObjectMethod(DataObjectMethodType.Select, false)]
	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	public virtual Class548.Class550 vmethod_7(string string_0)
	{
		this.SqlDataAdapter_0.SelectCommand = this.SqlCommand_0[3];
		if (string_0 == null)
		{
			this.SqlDataAdapter_0.SelectCommand.Parameters[0].Value = DBNull.Value;
		}
		else
		{
			this.SqlDataAdapter_0.SelectCommand.Parameters[0].Value = string_0;
		}
		Class548.Class550 @class = new Class548.Class550();
		this.SqlDataAdapter_0.Fill(@class);
		return @class;
	}

	[DataObjectMethod(DataObjectMethodType.Fill, false)]
	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	public virtual int vmethod_8(Class548.Class550 class550_0, int? nullable_0)
	{
		this.SqlDataAdapter_0.SelectCommand = this.SqlCommand_0[4];
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
			class550_0.Clear();
		}
		return this.SqlDataAdapter_0.Fill(class550_0);
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	[DataObjectMethod(DataObjectMethodType.Select, false)]
	[HelpKeyword("vs.data.TableAdapter")]
	public virtual Class548.Class550 vmethod_9(int? nullable_0)
	{
		this.SqlDataAdapter_0.SelectCommand = this.SqlCommand_0[4];
		if (nullable_0 != null)
		{
			this.SqlDataAdapter_0.SelectCommand.Parameters[0].Value = nullable_0.Value;
		}
		else
		{
			this.SqlDataAdapter_0.SelectCommand.Parameters[0].Value = DBNull.Value;
		}
		Class548.Class550 @class = new Class548.Class550();
		this.SqlDataAdapter_0.Fill(@class);
		return @class;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Fill, false)]
	[DebuggerNonUserCode]
	public virtual int vmethod_10(Class548.Class550 class550_0, DateTime? nullable_0)
	{
		this.SqlDataAdapter_0.SelectCommand = this.SqlCommand_0[5];
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
			class550_0.Clear();
		}
		return this.SqlDataAdapter_0.Fill(class550_0);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Select, false)]
	public virtual Class548.Class550 vmethod_11(DateTime? nullable_0)
	{
		this.SqlDataAdapter_0.SelectCommand = this.SqlCommand_0[5];
		if (nullable_0 != null)
		{
			this.SqlDataAdapter_0.SelectCommand.Parameters[0].Value = nullable_0.Value;
		}
		else
		{
			this.SqlDataAdapter_0.SelectCommand.Parameters[0].Value = DBNull.Value;
		}
		Class548.Class550 @class = new Class548.Class550();
		this.SqlDataAdapter_0.Fill(@class);
		return @class;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	[HelpKeyword("vs.data.TableAdapter")]
	public virtual int vmethod_12(Class548.Class550 class550_0)
	{
		return this.SqlDataAdapter_0.Update(class550_0);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	public virtual int vmethod_13(Class548 class548_0)
	{
		return this.SqlDataAdapter_0.Update(class548_0, "tblAbnAplForDisconObjects");
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	[HelpKeyword("vs.data.TableAdapter")]
	public virtual int vmethod_14(DataRow dataRow_0)
	{
		return this.SqlDataAdapter_0.Update(new DataRow[]
		{
			dataRow_0
		});
	}

	[DebuggerNonUserCode]
	[HelpKeyword("vs.data.TableAdapter")]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public virtual int vmethod_15(DataRow[] dataRow_0)
	{
		return this.SqlDataAdapter_0.Update(dataRow_0);
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	[DebuggerNonUserCode]
	[DataObjectMethod(DataObjectMethodType.Delete, true)]
	public virtual int vmethod_16(int? nullable_0)
	{
		if (nullable_0 != null)
		{
			this.SqlDataAdapter_0.DeleteCommand.Parameters[0].Value = nullable_0.Value;
		}
		else
		{
			this.SqlDataAdapter_0.DeleteCommand.Parameters[0].Value = DBNull.Value;
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
	[HelpKeyword("vs.data.TableAdapter")]
	[DebuggerNonUserCode]
	[DataObjectMethod(DataObjectMethodType.Insert, true)]
	public virtual int vmethod_17(int? nullable_0, int? nullable_1, int? nullable_2, string string_0, int? nullable_3, string string_1, int? nullable_4, DateTime? nullable_5, int? nullable_6, string string_2, int? nullable_7, string string_3, string string_4, string string_5, bool? nullable_8, bool? nullable_9, int int_0)
	{
		if (nullable_0 != null)
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[0].Value = nullable_0.Value;
		}
		else
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[0].Value = DBNull.Value;
		}
		if (nullable_1 != null)
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[1].Value = nullable_1.Value;
		}
		else
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[1].Value = DBNull.Value;
		}
		if (nullable_2 != null)
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[2].Value = nullable_2.Value;
		}
		else
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[2].Value = DBNull.Value;
		}
		if (string_0 == null)
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[3].Value = DBNull.Value;
		}
		else
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[3].Value = string_0;
		}
		if (nullable_3 != null)
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[4].Value = nullable_3.Value;
		}
		else
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[4].Value = DBNull.Value;
		}
		if (string_1 == null)
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[5].Value = DBNull.Value;
		}
		else
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[5].Value = string_1;
		}
		if (nullable_4 != null)
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[6].Value = nullable_4.Value;
		}
		else
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[6].Value = DBNull.Value;
		}
		if (nullable_5 != null)
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[7].Value = nullable_5.Value;
		}
		else
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[7].Value = DBNull.Value;
		}
		if (nullable_6 != null)
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[8].Value = nullable_6.Value;
		}
		else
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[8].Value = DBNull.Value;
		}
		if (string_2 == null)
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[9].Value = DBNull.Value;
		}
		else
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[9].Value = string_2;
		}
		if (nullable_7 != null)
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[10].Value = nullable_7.Value;
		}
		else
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[10].Value = DBNull.Value;
		}
		if (string_3 == null)
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[11].Value = DBNull.Value;
		}
		else
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[11].Value = string_3;
		}
		if (string_4 == null)
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[12].Value = DBNull.Value;
		}
		else
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[12].Value = string_4;
		}
		if (string_5 == null)
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[13].Value = DBNull.Value;
		}
		else
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[13].Value = string_5;
		}
		if (nullable_8 != null)
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[14].Value = nullable_8.Value;
		}
		else
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[14].Value = DBNull.Value;
		}
		if (nullable_9 != null)
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[15].Value = nullable_9.Value;
		}
		else
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[15].Value = DBNull.Value;
		}
		this.SqlDataAdapter_0.InsertCommand.Parameters[16].Value = int_0;
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

	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Update, true)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	public virtual int vmethod_18(int? nullable_0, int? nullable_1, int? nullable_2, string string_0, int? nullable_3, string string_1, int? nullable_4, DateTime? nullable_5, int? nullable_6, string string_2, int? nullable_7, string string_3, string string_4, string string_5, bool? nullable_8, bool? nullable_9, int int_0)
	{
		if (nullable_0 != null)
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[0].Value = nullable_0.Value;
		}
		else
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[0].Value = DBNull.Value;
		}
		if (nullable_1 != null)
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[1].Value = nullable_1.Value;
		}
		else
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[1].Value = DBNull.Value;
		}
		if (nullable_2 != null)
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[2].Value = nullable_2.Value;
		}
		else
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[2].Value = DBNull.Value;
		}
		if (string_0 == null)
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[3].Value = DBNull.Value;
		}
		else
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[3].Value = string_0;
		}
		if (nullable_3 != null)
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[4].Value = nullable_3.Value;
		}
		else
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[4].Value = DBNull.Value;
		}
		if (string_1 == null)
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[5].Value = DBNull.Value;
		}
		else
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[5].Value = string_1;
		}
		if (nullable_4 != null)
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[6].Value = nullable_4.Value;
		}
		else
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[6].Value = DBNull.Value;
		}
		if (nullable_5 != null)
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[7].Value = nullable_5.Value;
		}
		else
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[7].Value = DBNull.Value;
		}
		if (nullable_6 != null)
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[8].Value = nullable_6.Value;
		}
		else
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[8].Value = DBNull.Value;
		}
		if (string_2 == null)
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[9].Value = DBNull.Value;
		}
		else
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[9].Value = string_2;
		}
		if (nullable_7 != null)
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[10].Value = nullable_7.Value;
		}
		else
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[10].Value = DBNull.Value;
		}
		if (string_3 == null)
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[11].Value = DBNull.Value;
		}
		else
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[11].Value = string_3;
		}
		if (string_4 == null)
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[12].Value = DBNull.Value;
		}
		else
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[12].Value = string_4;
		}
		if (string_5 == null)
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[13].Value = DBNull.Value;
		}
		else
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[13].Value = string_5;
		}
		if (nullable_8 != null)
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[14].Value = nullable_8.Value;
		}
		else
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[14].Value = DBNull.Value;
		}
		if (nullable_9 != null)
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[15].Value = nullable_9.Value;
		}
		else
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[15].Value = DBNull.Value;
		}
		this.SqlDataAdapter_0.UpdateCommand.Parameters[16].Value = int_0;
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

	[DataObjectMethod(DataObjectMethodType.Update, false)]
	[HelpKeyword("vs.data.TableAdapter")]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	public virtual int vmethod_19(int? nullable_0, int? nullable_1)
	{
		SqlCommand sqlCommand = this.SqlCommand_0[6];
		if (nullable_0 != null)
		{
			sqlCommand.Parameters[0].Value = nullable_0.Value;
		}
		else
		{
			sqlCommand.Parameters[0].Value = DBNull.Value;
		}
		if (nullable_1 != null)
		{
			sqlCommand.Parameters[1].Value = nullable_1.Value;
		}
		else
		{
			sqlCommand.Parameters[1].Value = DBNull.Value;
		}
		ConnectionState state = sqlCommand.Connection.State;
		if ((sqlCommand.Connection.State & ConnectionState.Open) != ConnectionState.Open)
		{
			sqlCommand.Connection.Open();
		}
		int result;
		try
		{
			result = sqlCommand.ExecuteNonQuery();
		}
		finally
		{
			if (state == ConnectionState.Closed)
			{
				sqlCommand.Connection.Close();
			}
		}
		return result;
	}

	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Update, false)]
	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public virtual int vmethod_20(string string_0, int? nullable_0)
	{
		SqlCommand sqlCommand = this.SqlCommand_0[7];
		if (string_0 == null)
		{
			sqlCommand.Parameters[0].Value = DBNull.Value;
		}
		else
		{
			sqlCommand.Parameters[0].Value = string_0;
		}
		if (nullable_0 != null)
		{
			sqlCommand.Parameters[1].Value = nullable_0.Value;
		}
		else
		{
			sqlCommand.Parameters[1].Value = DBNull.Value;
		}
		ConnectionState state = sqlCommand.Connection.State;
		if ((sqlCommand.Connection.State & ConnectionState.Open) != ConnectionState.Open)
		{
			sqlCommand.Connection.Open();
		}
		int result;
		try
		{
			result = sqlCommand.ExecuteNonQuery();
		}
		finally
		{
			if (state == ConnectionState.Closed)
			{
				sqlCommand.Connection.Close();
			}
		}
		return result;
	}

	[DebuggerNonUserCode]
	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Update, false)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public virtual int vmethod_21(int? nullable_0, int? nullable_1, string string_0)
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
		if (nullable_1 != null)
		{
			sqlCommand.Parameters[1].Value = nullable_1.Value;
		}
		else
		{
			sqlCommand.Parameters[1].Value = DBNull.Value;
		}
		if (string_0 == null)
		{
			sqlCommand.Parameters[2].Value = DBNull.Value;
		}
		else
		{
			sqlCommand.Parameters[2].Value = string_0;
		}
		ConnectionState state = sqlCommand.Connection.State;
		if ((sqlCommand.Connection.State & ConnectionState.Open) != ConnectionState.Open)
		{
			sqlCommand.Connection.Open();
		}
		int result;
		try
		{
			result = sqlCommand.ExecuteNonQuery();
		}
		finally
		{
			if (state == ConnectionState.Closed)
			{
				sqlCommand.Connection.Close();
			}
		}
		return result;
	}

	[DebuggerNonUserCode]
	[HelpKeyword("vs.data.TableAdapter")]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public virtual int vmethod_22(int? nullable_0, int? nullable_1, int? nullable_2)
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
		if (nullable_1 != null)
		{
			sqlCommand.Parameters[1].Value = nullable_1.Value;
		}
		else
		{
			sqlCommand.Parameters[1].Value = DBNull.Value;
		}
		if (nullable_2 != null)
		{
			sqlCommand.Parameters[2].Value = nullable_2.Value;
		}
		else
		{
			sqlCommand.Parameters[2].Value = DBNull.Value;
		}
		ConnectionState state = sqlCommand.Connection.State;
		if ((sqlCommand.Connection.State & ConnectionState.Open) != ConnectionState.Open)
		{
			sqlCommand.Connection.Open();
		}
		int result;
		try
		{
			result = sqlCommand.ExecuteNonQuery();
		}
		finally
		{
			if (state == ConnectionState.Closed)
			{
				sqlCommand.Connection.Close();
			}
		}
		return result;
	}

	private SqlDataAdapter sqlDataAdapter_0;

	private SqlConnection NkyCfIhZwkL;

	private SqlTransaction sqlTransaction_0;

	private SqlCommand[] sqlCommand_0;

	private bool bool_0;
}
