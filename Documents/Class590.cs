using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using Documents.Properties;

[DesignerCategory("code")]
[Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
[HelpKeyword("vs.data.TableAdapter")]
[ToolboxItem(true)]
[DataObject(true)]
internal class Class590 : Component
{
	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public Class590()
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

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
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
		dataTableMapping.DataSetTable = "tblAbnAplForDisconIndividualUsers";
		dataTableMapping.ColumnMappings.Add("Id", "Id");
		dataTableMapping.ColumnMappings.Add("FIO", "FIO");
		dataTableMapping.ColumnMappings.Add("Address", "Address");
		dataTableMapping.ColumnMappings.Add("PlaceId", "PlaceId");
		dataTableMapping.ColumnMappings.Add("Reason", "Reason");
		dataTableMapping.ColumnMappings.Add("IdAplForDiscon", "IdAplForDiscon");
		dataTableMapping.ColumnMappings.Add("Comments", "Comments");
		dataTableMapping.ColumnMappings.Add("IsNC", "IsNC");
		dataTableMapping.ColumnMappings.Add("IdAbn", "IdAbn");
		dataTableMapping.ColumnMappings.Add("Code", "Code");
		dataTableMapping.ColumnMappings.Add("DateDog", "DateDog");
		dataTableMapping.ColumnMappings.Add("IdCancelApl", "IdCancelApl");
		dataTableMapping.ColumnMappings.Add("Point", "Point");
		dataTableMapping.ColumnMappings.Add("Officer", "Officer");
		dataTableMapping.ColumnMappings.Add("DateExec", "DateExec");
		dataTableMapping.ColumnMappings.Add("FioExec", "FioExec");
		dataTableMapping.ColumnMappings.Add("NetAreaExec", "NetAreaExec");
		dataTableMapping.ColumnMappings.Add("ReasonFailure", "ReasonFailure");
		dataTableMapping.ColumnMappings.Add("ReasonCaption", "ReasonCaption");
		dataTableMapping.ColumnMappings.Add("CancelAplNum", "CancelAplNum");
		dataTableMapping.ColumnMappings.Add("NetAreaExecDescription", "NetAreaExecDescription");
		dataTableMapping.ColumnMappings.Add("FIOWorker", "FIOWorker");
		dataTableMapping.ColumnMappings.Add("Matrix", "Matrix");
		dataTableMapping.ColumnMappings.Add("Sent", "Sent");
		dataTableMapping.ColumnMappings.Add("DateAction", "DateAction");
		dataTableMapping.ColumnMappings.Add("TypeAction", "TypeAction");
		dataTableMapping.ColumnMappings.Add("NetArea", "NetArea");
		dataTableMapping.ColumnMappings.Add("DateAppl", "DateAppl");
		dataTableMapping.ColumnMappings.Add("IsFullRestriction", "IsFullRestriction");
		this.sqlDataAdapter_0.TableMappings.Add(dataTableMapping);
		this.sqlDataAdapter_0.DeleteCommand = new SqlCommand();
		this.sqlDataAdapter_0.DeleteCommand.Connection = this.SqlConnection_0;
		this.sqlDataAdapter_0.DeleteCommand.CommandText = "DELETE FROM tblAbnAplForDisconIndividualUsers\r\nWHERE        (Id = @Original_Id)";
		this.sqlDataAdapter_0.DeleteCommand.CommandType = CommandType.Text;
		this.sqlDataAdapter_0.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Id", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Original, false, null, "", "", ""));
		this.sqlDataAdapter_0.InsertCommand = new SqlCommand();
		this.sqlDataAdapter_0.InsertCommand.Connection = this.SqlConnection_0;
		this.sqlDataAdapter_0.InsertCommand.CommandText = "INSERT INTO tblAbnAplForDisconIndividualUsers\r\n                         (FIO, Address, PlaceId, Reason, IdAplForDiscon, Comments, IsNC, IdAbn, Code, DateDog, IdCancelApl, Officer, DateExec, FioExec, NetAreaExec, ReasonFailure, \r\n                         Matrix, IsFullRestriction)\r\nVALUES        (@FIO,@Address,@PlaceId,@Reason,@IdAplForDiscon,@Comments,@IsNC,@IdAbn,@Code,@DateDog,@IdCancelApl,@Officer,@DateExec,@FioExec,@NetAreaExec,@ReasonFailure,@Matrix,@IsFullRestriction);     \r\nSELECT Id, FIO, Address, PlaceId, Reason, IdAplForDiscon, Comments, IsNC, IdAbn, Code, DateDog, IdCancelApl FROM tblAbnAplForDisconIndividualUsers WHERE (Id = SCOPE_IDENTITY())";
		this.sqlDataAdapter_0.InsertCommand.CommandType = CommandType.Text;
		this.sqlDataAdapter_0.InsertCommand.Parameters.Add(new SqlParameter("@FIO", SqlDbType.NVarChar, 100, ParameterDirection.Input, 0, 0, "FIO", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.InsertCommand.Parameters.Add(new SqlParameter("@Address", SqlDbType.NVarChar, 200, ParameterDirection.Input, 0, 0, "Address", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.InsertCommand.Parameters.Add(new SqlParameter("@PlaceId", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "PlaceId", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.InsertCommand.Parameters.Add(new SqlParameter("@Reason", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "Reason", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.InsertCommand.Parameters.Add(new SqlParameter("@IdAplForDiscon", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "IdAplForDiscon", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.InsertCommand.Parameters.Add(new SqlParameter("@Comments", SqlDbType.NVarChar, 255, ParameterDirection.Input, 0, 0, "Comments", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.InsertCommand.Parameters.Add(new SqlParameter("@IsNC", SqlDbType.Bit, 1, ParameterDirection.Input, 0, 0, "IsNC", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.InsertCommand.Parameters.Add(new SqlParameter("@IdAbn", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "IdAbn", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.InsertCommand.Parameters.Add(new SqlParameter("@Code", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "Code", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.InsertCommand.Parameters.Add(new SqlParameter("@DateDog", SqlDbType.DateTime, 8, ParameterDirection.Input, 0, 0, "DateDog", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.InsertCommand.Parameters.Add(new SqlParameter("@IdCancelApl", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "IdCancelApl", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.InsertCommand.Parameters.Add(new SqlParameter("@Officer", SqlDbType.VarChar, 100, ParameterDirection.Input, 0, 0, "Officer", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.InsertCommand.Parameters.Add(new SqlParameter("@DateExec", SqlDbType.DateTime, 8, ParameterDirection.Input, 0, 0, "DateExec", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.InsertCommand.Parameters.Add(new SqlParameter("@FioExec", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "FioExec", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.InsertCommand.Parameters.Add(new SqlParameter("@NetAreaExec", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "NetAreaExec", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.InsertCommand.Parameters.Add(new SqlParameter("@ReasonFailure", SqlDbType.VarChar, 500, ParameterDirection.Input, 0, 0, "ReasonFailure", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.InsertCommand.Parameters.Add(new SqlParameter("@Matrix", SqlDbType.Bit, 1, ParameterDirection.Input, 0, 0, "Matrix", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.InsertCommand.Parameters.Add(new SqlParameter("@IsFullRestriction", SqlDbType.Bit, 1, ParameterDirection.Input, 0, 0, "IsFullRestriction", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.UpdateCommand = new SqlCommand();
		this.sqlDataAdapter_0.UpdateCommand.Connection = this.SqlConnection_0;
		this.sqlDataAdapter_0.UpdateCommand.CommandText = "UPDATE       tblAbnAplForDisconIndividualUsers\r\nSET                FIO = @FIO, Address = @Address, PlaceId = @PlaceId, Reason = @Reason, IdAplForDiscon = @IdAplForDiscon, Comments = @Comments, IsNC = @IsNC, \r\n                         IdAbn = @IdAbn, Code = @Code, DateDog = @DateDog, IdCancelApl = @IdCancelApl, Officer = @Officer, DateExec = @DateExec, FioExec = @FioExec, \r\n                         NetAreaExec = @NetAreaExec, ReasonFailure = @ReasonFailure, Matrix = @Matrix, IsFullRestriction = @IsFullRestriction\r\nWHERE        (Id = @Original_Id);     \r\nSELECT Id, FIO, Address, PlaceId, Reason, IdAplForDiscon, Comments, IsNC, IdAbn, Code, DateDog, IdCancelApl FROM tblAbnAplForDisconIndividualUsers WHERE (Id = @Id)";
		this.sqlDataAdapter_0.UpdateCommand.CommandType = CommandType.Text;
		this.sqlDataAdapter_0.UpdateCommand.Parameters.Add(new SqlParameter("@FIO", SqlDbType.NVarChar, 100, ParameterDirection.Input, 0, 0, "FIO", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.UpdateCommand.Parameters.Add(new SqlParameter("@Address", SqlDbType.NVarChar, 200, ParameterDirection.Input, 0, 0, "Address", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.UpdateCommand.Parameters.Add(new SqlParameter("@PlaceId", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "PlaceId", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.UpdateCommand.Parameters.Add(new SqlParameter("@Reason", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "Reason", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.UpdateCommand.Parameters.Add(new SqlParameter("@IdAplForDiscon", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "IdAplForDiscon", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.UpdateCommand.Parameters.Add(new SqlParameter("@Comments", SqlDbType.NVarChar, 255, ParameterDirection.Input, 0, 0, "Comments", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.UpdateCommand.Parameters.Add(new SqlParameter("@IsNC", SqlDbType.Bit, 1, ParameterDirection.Input, 0, 0, "IsNC", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.UpdateCommand.Parameters.Add(new SqlParameter("@IdAbn", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "IdAbn", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.UpdateCommand.Parameters.Add(new SqlParameter("@Code", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "Code", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.UpdateCommand.Parameters.Add(new SqlParameter("@DateDog", SqlDbType.DateTime, 8, ParameterDirection.Input, 0, 0, "DateDog", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.UpdateCommand.Parameters.Add(new SqlParameter("@IdCancelApl", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "IdCancelApl", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.UpdateCommand.Parameters.Add(new SqlParameter("@Officer", SqlDbType.VarChar, 100, ParameterDirection.Input, 0, 0, "Officer", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.UpdateCommand.Parameters.Add(new SqlParameter("@DateExec", SqlDbType.DateTime, 8, ParameterDirection.Input, 0, 0, "DateExec", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.UpdateCommand.Parameters.Add(new SqlParameter("@FioExec", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "FioExec", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.UpdateCommand.Parameters.Add(new SqlParameter("@NetAreaExec", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "NetAreaExec", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.UpdateCommand.Parameters.Add(new SqlParameter("@ReasonFailure", SqlDbType.VarChar, 500, ParameterDirection.Input, 0, 0, "ReasonFailure", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.UpdateCommand.Parameters.Add(new SqlParameter("@Matrix", SqlDbType.Bit, 1, ParameterDirection.Input, 0, 0, "Matrix", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.UpdateCommand.Parameters.Add(new SqlParameter("@IsFullRestriction", SqlDbType.Bit, 1, ParameterDirection.Input, 0, 0, "IsFullRestriction", DataRowVersion.Current, false, null, "", "", ""));
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
		this.sqlCommand_0 = new SqlCommand[8];
		this.sqlCommand_0[0] = new SqlCommand();
		this.sqlCommand_0[0].Connection = this.SqlConnection_0;
		this.sqlCommand_0[0].CommandText = "SELECT        tblAbnAplForDisconIndividualUsers.Id, tblAbnAplForDisconIndividualUsers.FIO, tblAbnAplForDisconIndividualUsers.Address, \r\n                         tblAbnAplForDisconIndividualUsers.PlaceId, tblAbnAplForDisconIndividualUsers.Reason, tblAbnAplForDisconIndividualUsers.IdAplForDiscon, \r\n                         tblAbnAplForDisconIndividualUsers.Comments, tblAbnAplForDisconIndividualUsers.IsNC, tblAbnAplForDisconIndividualUsers.IdAbn, \r\n                         tblAbnAplForDisconIndividualUsers.Code, tblAbnAplForDisconIndividualUsers.DateDog, tblAbnAplForDisconIndividualUsers.IdCancelApl, \r\n                         tblAbnAplConnectPointForIndividualUsers.Point, tblAbnAplForDisconIndividualUsers.Officer, tblAbnAplForDisconIndividualUsers.DateExec, \r\n                         tblAbnAplForDisconIndividualUsers.FioExec, tblAbnAplForDisconIndividualUsers.NetAreaExec, tblAbnAplForDisconIndividualUsers.ReasonFailure, \r\n                         tblAbnAplForDisconReason.Reason AS ReasonCaption, tblAbnAplForDiscon.NumDoc AS CancelAplNum, Division.Description AS NetAreaExecDescription, \r\n                         Worker.F + ' ' + Worker.I + ' ' + Worker.O AS FIOWorker, tblAbnAplForDisconIndividualUsers.Matrix, tblAbnAplForDiscon.Sent, tblAbnAplForDiscon.DateAction, \r\n                         tblAbnAplForDiscon.TypeAction, tblAbnAplForDiscon.NetArea, tblAbnAplForDiscon.DateAppl, tblAbnAplForDisconIndividualUsers.IsFullRestriction\r\nFROM            tblAbnAplForDisconIndividualUsers INNER JOIN\r\n                         tblAbnAplConnectPointForIndividualUsers ON tblAbnAplForDisconIndividualUsers.PlaceId = tblAbnAplConnectPointForIndividualUsers.Id INNER JOIN\r\n                         tblAbnAplForDisconReason ON tblAbnAplForDisconIndividualUsers.Reason = tblAbnAplForDisconReason.Id LEFT OUTER JOIN\r\n                         tblAbnAplForDiscon ON tblAbnAplForDisconIndividualUsers.IdCancelApl = tblAbnAplForDiscon.Id LEFT OUTER JOIN\r\n                         tR_Division AS Division ON tblAbnAplForDisconIndividualUsers.NetAreaExec = Division.id LEFT OUTER JOIN\r\n                         tR_Worker AS Worker ON tblAbnAplForDisconIndividualUsers.FioExec = Worker.id\r\nWHERE        (tblAbnAplForDisconIndividualUsers.IdAplForDiscon = @IdAplForDiscon)";
		this.sqlCommand_0[0].CommandType = CommandType.Text;
		this.sqlCommand_0[0].Parameters.Add(new SqlParameter("@IdAplForDiscon", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "IdAplForDiscon", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlCommand_0[1] = new SqlCommand();
		this.sqlCommand_0[1].Connection = this.SqlConnection_0;
		this.sqlCommand_0[1].CommandText = "SELECT        tblAbnAplForDisconIndividualUsers.Id, tblAbnAplForDisconIndividualUsers.FIO, tblAbnAplForDisconIndividualUsers.Address, \r\n                         tblAbnAplForDisconIndividualUsers.PlaceId, tblAbnAplForDisconIndividualUsers.Reason, tblAbnAplForDisconIndividualUsers.IdAplForDiscon, \r\n                         tblAbnAplForDisconIndividualUsers.Comments, tblAbnAplForDisconIndividualUsers.IsNC, tblAbnAplForDisconIndividualUsers.IdAbn, \r\n                         tblAbnAplForDisconIndividualUsers.Code, tblAbnAplForDisconIndividualUsers.DateDog, tblAbnAplForDisconIndividualUsers.IdCancelApl, \r\n                         tblAbnAplConnectPointForIndividualUsers.Point, tblAbnAplForDisconIndividualUsers.Officer, tblAbnAplForDisconIndividualUsers.DateExec, \r\n                         tblAbnAplForDisconIndividualUsers.FioExec, tblAbnAplForDisconIndividualUsers.NetAreaExec, tblAbnAplForDisconIndividualUsers.ReasonFailure, \r\n                         tblAbnAplForDisconReason.Reason AS ReasonCaption, tblAbnAplForDiscon.NumDoc AS CancelAplNum, Division.Description AS NetAreaExecDescription, \r\n                         Worker.F + ' ' + Worker.I + ' ' + Worker.O AS FIOWorker, tblAbnAplForDisconIndividualUsers.Matrix, tblAbnAplForDisconIndividualUsers.IsFullRestriction\r\nFROM            tblAbnAplForDisconIndividualUsers INNER JOIN\r\n                         tblAbnAplConnectPointForIndividualUsers ON tblAbnAplForDisconIndividualUsers.PlaceId = tblAbnAplConnectPointForIndividualUsers.Id INNER JOIN\r\n                         tblAbnAplForDisconReason ON tblAbnAplForDisconIndividualUsers.Reason = tblAbnAplForDisconReason.Id LEFT OUTER JOIN\r\n                         tblAbnAplForDiscon ON tblAbnAplForDisconIndividualUsers.IdCancelApl = tblAbnAplForDiscon.Id LEFT OUTER JOIN\r\n                         tR_Division AS Division ON tblAbnAplForDisconIndividualUsers.NetAreaExec = Division.id LEFT OUTER JOIN\r\n                         tR_Worker AS Worker ON tblAbnAplForDisconIndividualUsers.FioExec = Worker.id\r\nWHERE        (tblAbnAplForDisconIndividualUsers.Address LIKE @Address)";
		this.sqlCommand_0[1].CommandType = CommandType.Text;
		this.sqlCommand_0[1].Parameters.Add(new SqlParameter("@Address", SqlDbType.NVarChar, 200, ParameterDirection.Input, 0, 0, "Address", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlCommand_0[2] = new SqlCommand();
		this.sqlCommand_0[2].Connection = this.SqlConnection_0;
		this.sqlCommand_0[2].CommandText = "SELECT        tblAbnAplForDisconIndividualUsers.Id, tblAbnAplForDisconIndividualUsers.FIO, tblAbnAplForDisconIndividualUsers.Address, \r\n                         tblAbnAplForDisconIndividualUsers.PlaceId, tblAbnAplForDisconIndividualUsers.Reason, tblAbnAplForDisconIndividualUsers.IdAplForDiscon, \r\n                         tblAbnAplForDisconIndividualUsers.Comments, tblAbnAplForDisconIndividualUsers.IsNC, tblAbnAplForDisconIndividualUsers.IdAbn, \r\n                         tblAbnAplForDisconIndividualUsers.Code, tblAbnAplForDisconIndividualUsers.DateDog, tblAbnAplForDisconIndividualUsers.IdCancelApl, \r\n                         tblAbnAplConnectPointForIndividualUsers.Point, tblAbnAplForDisconIndividualUsers.Officer, tblAbnAplForDisconIndividualUsers.DateExec, \r\n                         tblAbnAplForDisconIndividualUsers.FioExec, tblAbnAplForDisconIndividualUsers.NetAreaExec, tblAbnAplForDisconIndividualUsers.ReasonFailure, \r\n                         tblAbnAplForDisconReason.Reason AS ReasonCaption, tblAbnAplForDiscon.NumDoc AS CancelAplNum, Division.Description AS NetAreaExecDescription, \r\n                         Worker.F + ' ' + Worker.I + ' ' + Worker.O AS FIOWorker, tblAbnAplForDisconIndividualUsers.Matrix, tblAbnAplForDiscon.Sent, tblAbnAplForDiscon.DateAction, \r\n                         tblAbnAplForDiscon.TypeAction, tblAbnAplForDiscon.NetArea, tblAbnAplForDiscon.DateAppl, tblAbnAplForDisconIndividualUsers.IsFullRestriction\r\nFROM            tblAbnAplForDisconIndividualUsers INNER JOIN\r\n                         tblAbnAplConnectPointForIndividualUsers ON tblAbnAplForDisconIndividualUsers.PlaceId = tblAbnAplConnectPointForIndividualUsers.Id INNER JOIN\r\n                         tblAbnAplForDisconReason ON tblAbnAplForDisconIndividualUsers.Reason = tblAbnAplForDisconReason.Id LEFT OUTER JOIN\r\n                         tblAbnAplForDiscon ON tblAbnAplForDisconIndividualUsers.IdCancelApl = tblAbnAplForDiscon.Id LEFT OUTER JOIN\r\n                         tR_Division AS Division ON tblAbnAplForDisconIndividualUsers.NetAreaExec = Division.id LEFT OUTER JOIN\r\n                         tR_Worker AS Worker ON tblAbnAplForDisconIndividualUsers.FioExec = Worker.id INNER JOIN\r\n                         tblAbnAplForDiscon AS apl ON tblAbnAplForDisconIndividualUsers.IdAplForDiscon = apl.id AND apl.TypeAction = 0\r\nWHERE        (tblAbnAplForDisconIndividualUsers.IdAplForDiscon = @IdAplForDiscon) AND (tblAbnAplForDisconIndividualUsers.IdCancelApl IS NULL) AND \r\n                         (tblAbnAplForDisconIndividualUsers.DateExec IS NOT NULL) AND (tblAbnAplForDisconIndividualUsers.Code IS NOT NULL) AND \r\n                         (tblAbnAplForDisconIndividualUsers.Code NOT IN\r\n                             (SELECT        obj1.Code\r\n                               FROM            tblAbnAplForDisconIndividualUsers AS obj1 INNER JOIN\r\n                                                         tblAbnAplForDiscon AS apl1 ON obj1.IdAplForDiscon = apl1.Id AND apl1.TypeAction = 1\r\n                               WHERE        (obj1.IdCancelApl IS NULL) AND (obj1.DateExec IS NOT NULL) AND (obj1.Code IS NOT NULL) AND (apl.DateAppl < apl1.DateAppl)))";
		this.sqlCommand_0[2].CommandType = CommandType.Text;
		this.sqlCommand_0[2].Parameters.Add(new SqlParameter("@IdAplForDiscon", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "IdAplForDiscon", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlCommand_0[3] = new SqlCommand();
		this.sqlCommand_0[3].Connection = this.SqlConnection_0;
		this.sqlCommand_0[3].CommandText = "SELECT        tblAbnAplForDisconIndividualUsers.Id, tblAbnAplForDisconIndividualUsers.FIO, tblAbnAplForDisconIndividualUsers.Address, \r\n                         tblAbnAplForDisconIndividualUsers.PlaceId, tblAbnAplForDisconIndividualUsers.Reason, tblAbnAplForDisconIndividualUsers.IdAplForDiscon, \r\n                         tblAbnAplForDisconIndividualUsers.Comments, tblAbnAplForDisconIndividualUsers.IsNC, tblAbnAplForDisconIndividualUsers.IdAbn, \r\n                         tblAbnAplForDisconIndividualUsers.Code, tblAbnAplForDisconIndividualUsers.DateDog, tblAbnAplForDisconIndividualUsers.IdCancelApl, \r\n                         tblAbnAplConnectPointForIndividualUsers.Point, tblAbnAplForDisconIndividualUsers.Officer, tblAbnAplForDisconIndividualUsers.DateExec, \r\n                         tblAbnAplForDisconIndividualUsers.FioExec, tblAbnAplForDisconIndividualUsers.NetAreaExec, tblAbnAplForDisconIndividualUsers.ReasonFailure, \r\n                         tblAbnAplForDisconReason.Reason AS ReasonCaption, tblAbnAplForDiscon.NumDoc AS CancelAplNum, Division.Description AS NetAreaExecDescription, \r\n                         Worker.F + ' ' + Worker.I + ' ' + Worker.O AS FIOWorker, tblAbnAplForDisconIndividualUsers.Matrix, tblAbnAplForDisconIndividualUsers.IsFullRestriction\r\nFROM            tblAbnAplForDisconIndividualUsers INNER JOIN\r\n                         tblAbnAplConnectPointForIndividualUsers ON tblAbnAplForDisconIndividualUsers.PlaceId = tblAbnAplConnectPointForIndividualUsers.Id INNER JOIN\r\n                         tblAbnAplForDisconReason ON tblAbnAplForDisconIndividualUsers.Reason = tblAbnAplForDisconReason.Id LEFT OUTER JOIN\r\n                         tblAbnAplForDiscon ON tblAbnAplForDisconIndividualUsers.IdCancelApl = tblAbnAplForDiscon.Id LEFT OUTER JOIN\r\n                         tR_Division AS Division ON tblAbnAplForDisconIndividualUsers.NetAreaExec = Division.id LEFT OUTER JOIN\r\n                         tR_Worker AS Worker ON tblAbnAplForDisconIndividualUsers.FioExec = Worker.id\r\nWHERE        (tblAbnAplForDisconIndividualUsers.Id = @Id)";
		this.sqlCommand_0[3].CommandType = CommandType.Text;
		this.sqlCommand_0[3].Parameters.Add(new SqlParameter("@Id", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlCommand_0[4] = new SqlCommand();
		this.sqlCommand_0[4].Connection = this.SqlConnection_0;
		this.sqlCommand_0[4].CommandText = "SELECT        tblAbnAplForDisconIndividualUsers.Id, tblAbnAplForDisconIndividualUsers.FIO, tblAbnAplForDisconIndividualUsers.Address, \r\n                         tblAbnAplForDisconIndividualUsers.PlaceId, tblAbnAplForDisconIndividualUsers.Reason, tblAbnAplForDisconIndividualUsers.IdAplForDiscon, \r\n                         tblAbnAplForDisconIndividualUsers.Comments, tblAbnAplForDisconIndividualUsers.IsNC, tblAbnAplForDisconIndividualUsers.IdAbn, \r\n                         tblAbnAplForDisconIndividualUsers.Code, tblAbnAplForDisconIndividualUsers.DateDog, tblAbnAplForDisconIndividualUsers.IdCancelApl, \r\n                         tblAbnAplConnectPointForIndividualUsers.Point, tblAbnAplForDisconIndividualUsers.Officer, tblAbnAplForDisconIndividualUsers.DateExec, \r\n                         tblAbnAplForDisconIndividualUsers.FioExec, tblAbnAplForDisconIndividualUsers.NetAreaExec, tblAbnAplForDisconIndividualUsers.ReasonFailure, \r\n                         tblAbnAplForDisconReason.Reason AS ReasonCaption, tblAbnAplForDiscon.NumDoc AS CancelAplNum, Division.Description AS NetAreaExecDescription, \r\n                         Worker.F + ' ' + Worker.I + ' ' + Worker.O AS FIOWorker, tblAbnAplForDisconIndividualUsers.Matrix, tblAbnAplForDisconIndividualUsers.IsFullRestriction\r\nFROM            tblAbnAplForDisconIndividualUsers INNER JOIN\r\n                         tblAbnAplConnectPointForIndividualUsers ON tblAbnAplForDisconIndividualUsers.PlaceId = tblAbnAplConnectPointForIndividualUsers.Id INNER JOIN\r\n                         tblAbnAplForDisconReason ON tblAbnAplForDisconIndividualUsers.Reason = tblAbnAplForDisconReason.Id LEFT OUTER JOIN\r\n                         tblAbnAplForDiscon ON tblAbnAplForDisconIndividualUsers.IdCancelApl = tblAbnAplForDiscon.Id LEFT OUTER JOIN\r\n                         tR_Division AS Division ON tblAbnAplForDisconIndividualUsers.NetAreaExec = Division.id LEFT OUTER JOIN\r\n                         tR_Worker AS Worker ON tblAbnAplForDisconIndividualUsers.FioExec = Worker.id\r\nWHERE        (tblAbnAplForDisconIndividualUsers.FIO LIKE @name)";
		this.sqlCommand_0[4].CommandType = CommandType.Text;
		this.sqlCommand_0[4].Parameters.Add(new SqlParameter("@name", SqlDbType.NVarChar, 100, ParameterDirection.Input, 0, 0, "FIO", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlCommand_0[5] = new SqlCommand();
		this.sqlCommand_0[5].Connection = this.SqlConnection_0;
		this.sqlCommand_0[5].CommandText = "SELECT        tblAbnAplForDisconIndividualUsers.Id, tblAbnAplForDisconIndividualUsers.FIO, tblAbnAplForDisconIndividualUsers.Address, \r\n                         tblAbnAplForDisconIndividualUsers.PlaceId, tblAbnAplForDisconIndividualUsers.Reason, tblAbnAplForDisconIndividualUsers.IdAplForDiscon, \r\n                         tblAbnAplForDisconIndividualUsers.Comments, tblAbnAplForDisconIndividualUsers.IsNC, tblAbnAplForDisconIndividualUsers.IdAbn, \r\n                         tblAbnAplForDisconIndividualUsers.Code, tblAbnAplForDisconIndividualUsers.DateDog, tblAbnAplForDisconIndividualUsers.IdCancelApl, \r\n                         tblAbnAplConnectPointForIndividualUsers.Point, tblAbnAplForDisconIndividualUsers.Officer, tblAbnAplForDisconIndividualUsers.DateExec, \r\n                         tblAbnAplForDisconIndividualUsers.FioExec, tblAbnAplForDisconIndividualUsers.NetAreaExec, tblAbnAplForDisconIndividualUsers.ReasonFailure, \r\n                         tblAbnAplForDisconReason.Reason AS ReasonCaption, tblAbnAplForDiscon.NumDoc AS CancelAplNum, Division.Description AS NetAreaExecDescription, \r\n                         Worker.F + ' ' + Worker.I + ' ' + Worker.O AS FIOWorker, tblAbnAplForDisconIndividualUsers.Matrix, tblAbnAplForDiscon.DateAction, tblAbnAplForDiscon.NetArea, \r\n                         tblAbnAplForDiscon.TypeAction, tblAbnAplForDiscon.DateAppl, tblAbnAplForDiscon.Sent, tblAbnAplForDisconIndividualUsers.IsFullRestriction\r\nFROM            tblAbnAplForDisconIndividualUsers INNER JOIN\r\n                         tblAbnAplConnectPointForIndividualUsers ON tblAbnAplForDisconIndividualUsers.PlaceId = tblAbnAplConnectPointForIndividualUsers.Id INNER JOIN\r\n                         tblAbnAplForDisconReason ON tblAbnAplForDisconIndividualUsers.Reason = tblAbnAplForDisconReason.Id LEFT OUTER JOIN\r\n                         tblAbnAplForDiscon ON tblAbnAplForDisconIndividualUsers.IdAplForDiscon = tblAbnAplForDiscon.Id LEFT OUTER JOIN\r\n                         tR_Division AS Division ON tblAbnAplForDisconIndividualUsers.NetAreaExec = Division.id LEFT OUTER JOIN\r\n                         tR_Worker AS Worker ON tblAbnAplForDisconIndividualUsers.FioExec = Worker.id\r\nWHERE        (tblAbnAplForDisconIndividualUsers.DateExec IS NULL) AND (tblAbnAplForDiscon.DateAction < @BegPer) AND \r\n                         (tblAbnAplForDisconIndividualUsers.IdCancelApl IS NULL)";
		this.sqlCommand_0[5].CommandType = CommandType.Text;
		this.sqlCommand_0[5].Parameters.Add(new SqlParameter("@BegPer", SqlDbType.DateTime, 8, ParameterDirection.Input, 0, 0, "DateAction", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlCommand_0[6] = new SqlCommand();
		this.sqlCommand_0[6].Connection = this.SqlConnection_0;
		this.sqlCommand_0[6].CommandText = "UPDATE       tblAbnAplForDisconIndividualUsers\r\nSET                IdCancelApl = NULL\r\nWHERE        (FIO = @FIO) AND (IdCancelApl = @IdCancelApl);      \r\n";
		this.sqlCommand_0[6].CommandType = CommandType.Text;
		this.sqlCommand_0[6].Parameters.Add(new SqlParameter("@FIO", SqlDbType.NVarChar, 100, ParameterDirection.Input, 0, 0, "FIO", DataRowVersion.Original, false, null, "", "", ""));
		this.sqlCommand_0[6].Parameters.Add(new SqlParameter("@IdCancelApl", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "IdCancelApl", DataRowVersion.Original, false, null, "", "", ""));
		this.sqlCommand_0[7] = new SqlCommand();
		this.sqlCommand_0[7].Connection = this.SqlConnection_0;
		this.sqlCommand_0[7].CommandText = "UPDATE       tblAbnAplForDisconIndividualUsers\r\nSET                IdCancelApl = @IdCancelApl\r\nWHERE        (IdAplForDiscon = @Original_IdAplForDiscon) AND (FIO = @FIO);    \r\n";
		this.sqlCommand_0[7].CommandType = CommandType.Text;
		this.sqlCommand_0[7].Parameters.Add(new SqlParameter("@IdCancelApl", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "IdCancelApl", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlCommand_0[7].Parameters.Add(new SqlParameter("@Original_IdAplForDiscon", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "IdAplForDiscon", DataRowVersion.Original, false, null, "", "", ""));
		this.sqlCommand_0[7].Parameters.Add(new SqlParameter("@FIO", SqlDbType.NVarChar, 100, ParameterDirection.Input, 0, 0, "FIO", DataRowVersion.Original, false, null, "", "", ""));
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DataObjectMethod(DataObjectMethodType.Fill, true)]
	[HelpKeyword("vs.data.TableAdapter")]
	public virtual int vmethod_0(Class548.Class554 class554_0, int? nullable_0)
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
			class554_0.Clear();
		}
		return this.SqlDataAdapter_0.Fill(class554_0);
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Select, true)]
	[DebuggerNonUserCode]
	public virtual Class548.Class554 vmethod_1(int? nullable_0)
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
		Class548.Class554 @class = new Class548.Class554();
		this.SqlDataAdapter_0.Fill(@class);
		return @class;
	}

	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Fill, false)]
	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public virtual int vmethod_2(Class548.Class554 class554_0, string string_0)
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
			class554_0.Clear();
		}
		return this.SqlDataAdapter_0.Fill(class554_0);
	}

	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Select, false)]
	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public virtual Class548.Class554 vmethod_3(string string_0)
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
		Class548.Class554 @class = new Class548.Class554();
		this.SqlDataAdapter_0.Fill(@class);
		return @class;
	}

	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Fill, false)]
	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public virtual int vmethod_4(Class548.Class554 class554_0, int? nullable_0)
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
			class554_0.Clear();
		}
		return this.SqlDataAdapter_0.Fill(class554_0);
	}

	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Select, false)]
	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public virtual Class548.Class554 vmethod_5(int? nullable_0)
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
		Class548.Class554 @class = new Class548.Class554();
		this.SqlDataAdapter_0.Fill(@class);
		return @class;
	}

	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Fill, false)]
	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public virtual int vmethod_6(Class548.Class554 class554_0, int int_0)
	{
		this.SqlDataAdapter_0.SelectCommand = this.SqlCommand_0[3];
		this.SqlDataAdapter_0.SelectCommand.Parameters[0].Value = int_0;
		if (this.Boolean_0)
		{
			class554_0.Clear();
		}
		return this.SqlDataAdapter_0.Fill(class554_0);
	}

	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Select, false)]
	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public virtual Class548.Class554 vmethod_7(int int_0)
	{
		this.SqlDataAdapter_0.SelectCommand = this.SqlCommand_0[3];
		this.SqlDataAdapter_0.SelectCommand.Parameters[0].Value = int_0;
		Class548.Class554 @class = new Class548.Class554();
		this.SqlDataAdapter_0.Fill(@class);
		return @class;
	}

	[DataObjectMethod(DataObjectMethodType.Fill, false)]
	[HelpKeyword("vs.data.TableAdapter")]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	public virtual int vmethod_8(Class548.Class554 class554_0, string string_0)
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
			class554_0.Clear();
		}
		return this.SqlDataAdapter_0.Fill(class554_0);
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Select, false)]
	[DebuggerNonUserCode]
	public virtual Class548.Class554 vmethod_9(string string_0)
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
		Class548.Class554 @class = new Class548.Class554();
		this.SqlDataAdapter_0.Fill(@class);
		return @class;
	}

	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Fill, false)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	public virtual int vmethod_10(Class548.Class554 class554_0, DateTime? nullable_0)
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
			class554_0.Clear();
		}
		return this.SqlDataAdapter_0.Fill(class554_0);
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Select, false)]
	[DebuggerNonUserCode]
	public virtual Class548.Class554 vmethod_11(DateTime? nullable_0)
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
		Class548.Class554 @class = new Class548.Class554();
		this.SqlDataAdapter_0.Fill(@class);
		return @class;
	}

	[HelpKeyword("vs.data.TableAdapter")]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	public virtual int vmethod_12(Class548.Class554 class554_0)
	{
		return this.SqlDataAdapter_0.Update(class554_0);
	}

	[HelpKeyword("vs.data.TableAdapter")]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	public virtual int vmethod_13(Class548 class548_0)
	{
		return this.SqlDataAdapter_0.Update(class548_0, "tblAbnAplForDisconIndividualUsers");
	}

	[HelpKeyword("vs.data.TableAdapter")]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	public virtual int vmethod_14(DataRow dataRow_0)
	{
		return this.SqlDataAdapter_0.Update(new DataRow[]
		{
			dataRow_0
		});
	}

	[HelpKeyword("vs.data.TableAdapter")]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	public virtual int vmethod_15(DataRow[] dataRow_0)
	{
		return this.SqlDataAdapter_0.Update(dataRow_0);
	}

	[DataObjectMethod(DataObjectMethodType.Delete, true)]
	[HelpKeyword("vs.data.TableAdapter")]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
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

	[DebuggerNonUserCode]
	[DataObjectMethod(DataObjectMethodType.Insert, true)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	public virtual int vmethod_17(string string_0, string string_1, int? nullable_0, int? nullable_1, int? nullable_2, string string_2, bool? nullable_3, int? nullable_4, int? nullable_5, DateTime? nullable_6, int? nullable_7, string string_3, DateTime? nullable_8, int? nullable_9, int? nullable_10, string string_4, bool? nullable_11, bool? nullable_12)
	{
		if (string_0 == null)
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[0].Value = DBNull.Value;
		}
		else
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[0].Value = string_0;
		}
		if (string_1 == null)
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[1].Value = DBNull.Value;
		}
		else
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[1].Value = string_1;
		}
		if (nullable_0 != null)
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[2].Value = nullable_0.Value;
		}
		else
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[2].Value = DBNull.Value;
		}
		if (nullable_1 != null)
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[3].Value = nullable_1.Value;
		}
		else
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[3].Value = DBNull.Value;
		}
		if (nullable_2 != null)
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[4].Value = nullable_2.Value;
		}
		else
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[4].Value = DBNull.Value;
		}
		if (string_2 == null)
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[5].Value = DBNull.Value;
		}
		else
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[5].Value = string_2;
		}
		if (nullable_3 != null)
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[6].Value = nullable_3.Value;
		}
		else
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[6].Value = DBNull.Value;
		}
		if (nullable_4 != null)
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[7].Value = nullable_4.Value;
		}
		else
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[7].Value = DBNull.Value;
		}
		if (nullable_5 != null)
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[8].Value = nullable_5.Value;
		}
		else
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[8].Value = DBNull.Value;
		}
		if (nullable_6 != null)
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[9].Value = nullable_6.Value;
		}
		else
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[9].Value = DBNull.Value;
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
		if (nullable_8 != null)
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[12].Value = nullable_8.Value;
		}
		else
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[12].Value = DBNull.Value;
		}
		if (nullable_9 != null)
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[13].Value = nullable_9.Value;
		}
		else
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[13].Value = DBNull.Value;
		}
		if (nullable_10 != null)
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[14].Value = nullable_10.Value;
		}
		else
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[14].Value = DBNull.Value;
		}
		if (string_4 == null)
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[15].Value = DBNull.Value;
		}
		else
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[15].Value = string_4;
		}
		if (nullable_11 != null)
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[16].Value = nullable_11.Value;
		}
		else
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[16].Value = DBNull.Value;
		}
		if (nullable_12 != null)
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[17].Value = nullable_12.Value;
		}
		else
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[17].Value = DBNull.Value;
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

	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Update, true)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	public virtual int vmethod_18(string string_0, string string_1, int? nullable_0, int? nullable_1, int? nullable_2, string string_2, bool? nullable_3, int? nullable_4, int? nullable_5, DateTime? nullable_6, int? nullable_7, string string_3, DateTime? nullable_8, int? nullable_9, int? nullable_10, string string_4, bool? nullable_11, bool? nullable_12, int int_0, int int_1)
	{
		if (string_0 == null)
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[0].Value = DBNull.Value;
		}
		else
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[0].Value = string_0;
		}
		if (string_1 == null)
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[1].Value = DBNull.Value;
		}
		else
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[1].Value = string_1;
		}
		if (nullable_0 != null)
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[2].Value = nullable_0.Value;
		}
		else
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[2].Value = DBNull.Value;
		}
		if (nullable_1 != null)
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[3].Value = nullable_1.Value;
		}
		else
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[3].Value = DBNull.Value;
		}
		if (nullable_2 != null)
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[4].Value = nullable_2.Value;
		}
		else
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[4].Value = DBNull.Value;
		}
		if (string_2 == null)
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[5].Value = DBNull.Value;
		}
		else
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[5].Value = string_2;
		}
		if (nullable_3 != null)
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[6].Value = nullable_3.Value;
		}
		else
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[6].Value = DBNull.Value;
		}
		if (nullable_4 != null)
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[7].Value = nullable_4.Value;
		}
		else
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[7].Value = DBNull.Value;
		}
		if (nullable_5 != null)
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[8].Value = nullable_5.Value;
		}
		else
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[8].Value = DBNull.Value;
		}
		if (nullable_6 != null)
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[9].Value = nullable_6.Value;
		}
		else
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[9].Value = DBNull.Value;
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
		if (nullable_8 != null)
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[12].Value = nullable_8.Value;
		}
		else
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[12].Value = DBNull.Value;
		}
		if (nullable_9 != null)
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[13].Value = nullable_9.Value;
		}
		else
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[13].Value = DBNull.Value;
		}
		if (nullable_10 != null)
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[14].Value = nullable_10.Value;
		}
		else
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[14].Value = DBNull.Value;
		}
		if (string_4 == null)
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[15].Value = DBNull.Value;
		}
		else
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[15].Value = string_4;
		}
		if (nullable_11 != null)
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[16].Value = nullable_11.Value;
		}
		else
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[16].Value = DBNull.Value;
		}
		if (nullable_12 != null)
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[17].Value = nullable_12.Value;
		}
		else
		{
			this.SqlDataAdapter_0.UpdateCommand.Parameters[17].Value = DBNull.Value;
		}
		this.SqlDataAdapter_0.UpdateCommand.Parameters[18].Value = int_0;
		this.SqlDataAdapter_0.UpdateCommand.Parameters[19].Value = int_1;
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

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	[HelpKeyword("vs.data.TableAdapter")]
	public virtual int vmethod_19(string string_0, int? nullable_0)
	{
		SqlCommand sqlCommand = this.SqlCommand_0[6];
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

	[HelpKeyword("vs.data.TableAdapter")]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	public virtual int vmethod_20(int? nullable_0, int? nullable_1, string string_0)
	{
		SqlCommand sqlCommand = this.SqlCommand_0[7];
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

	private SqlDataAdapter sqlDataAdapter_0;

	private SqlConnection sqlConnection_0;

	private SqlTransaction sqlTransaction_0;

	private SqlCommand[] sqlCommand_0;

	private bool bool_0;
}
