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
[DataObject(true)]
[ToolboxItem(true)]
[DesignerCategory("code")]
[Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
internal class Class587 : Component
{
	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public Class587()
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

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	protected SqlCommand[] SqlCommand_0
	{
		get
		{
			if (this.sqlCommand_0 == null)
			{
				this.yodCfaeyZwQ();
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
			return this.xyvCfghWcOx;
		}
		set
		{
			this.xyvCfghWcOx = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	private void method_0()
	{
		this.sqlDataAdapter_0 = new SqlDataAdapter();
		DataTableMapping dataTableMapping = new DataTableMapping();
		dataTableMapping.SourceTable = "Table";
		dataTableMapping.DataSetTable = "tblAbnAplForDisconReason";
		dataTableMapping.ColumnMappings.Add("Id", "Id");
		dataTableMapping.ColumnMappings.Add("Reason", "Reason");
		dataTableMapping.ColumnMappings.Add("IdTypeApl", "IdTypeApl");
		this.sqlDataAdapter_0.TableMappings.Add(dataTableMapping);
		this.sqlDataAdapter_0.DeleteCommand = new SqlCommand();
		this.sqlDataAdapter_0.DeleteCommand.Connection = this.SqlConnection_0;
		this.sqlDataAdapter_0.DeleteCommand.CommandText = "DELETE FROM tblAbnAplForDisconReason\r\nWHERE        (Id = @Original_Id)";
		this.sqlDataAdapter_0.DeleteCommand.CommandType = CommandType.Text;
		this.sqlDataAdapter_0.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Id", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Original, false, null, "", "", ""));
		this.sqlDataAdapter_0.InsertCommand = new SqlCommand();
		this.sqlDataAdapter_0.InsertCommand.Connection = this.SqlConnection_0;
		this.sqlDataAdapter_0.InsertCommand.CommandText = "INSERT INTO [tblAbnAplForDisconReason] ([Reason], [IdTypeApl]) VALUES (@Reason, @IdTypeApl);\r\nSELECT Id, Reason, IdTypeApl FROM tblAbnAplForDisconReason WHERE (Id = SCOPE_IDENTITY())";
		this.sqlDataAdapter_0.InsertCommand.CommandType = CommandType.Text;
		this.sqlDataAdapter_0.InsertCommand.Parameters.Add(new SqlParameter("@Reason", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Reason", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.InsertCommand.Parameters.Add(new SqlParameter("@IdTypeApl", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "IdTypeApl", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.UpdateCommand = new SqlCommand();
		this.sqlDataAdapter_0.UpdateCommand.Connection = this.SqlConnection_0;
		this.sqlDataAdapter_0.UpdateCommand.CommandText = "UPDATE       tblAbnAplForDisconReason\r\nSET                Reason = @Reason, IdTypeApl = @IdTypeApl\r\nWHERE        (Id = @Original_Id); \r\nSELECT Id, Reason, IdTypeApl FROM tblAbnAplForDisconReason WHERE (Id = @Id)";
		this.sqlDataAdapter_0.UpdateCommand.CommandType = CommandType.Text;
		this.sqlDataAdapter_0.UpdateCommand.Parameters.Add(new SqlParameter("@Reason", SqlDbType.NVarChar, 100, ParameterDirection.Input, 0, 0, "Reason", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.UpdateCommand.Parameters.Add(new SqlParameter("@IdTypeApl", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "IdTypeApl", DataRowVersion.Current, false, null, "", "", ""));
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

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	private void yodCfaeyZwQ()
	{
		this.sqlCommand_0 = new SqlCommand[2];
		this.sqlCommand_0[0] = new SqlCommand();
		this.sqlCommand_0[0].Connection = this.SqlConnection_0;
		this.sqlCommand_0[0].CommandText = "SELECT        Id, Reason, IdTypeApl\r\nFROM            tblAbnAplForDisconReason\r\nWHERE        (IdTypeApl = @IdTypeApl)";
		this.sqlCommand_0[0].CommandType = CommandType.Text;
		this.sqlCommand_0[0].Parameters.Add(new SqlParameter("@IdTypeApl", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "IdTypeApl", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlCommand_0[1] = new SqlCommand();
		this.sqlCommand_0[1].Connection = this.SqlConnection_0;
		this.sqlCommand_0[1].CommandText = "SELECT        Reason\r\nFROM            tblAbnAplForDisconReason\r\nWHERE        (Id = @Id)";
		this.sqlCommand_0[1].CommandType = CommandType.Text;
		this.sqlCommand_0[1].Parameters.Add(new SqlParameter("@Id", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Current, false, null, "", "", ""));
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	[DataObjectMethod(DataObjectMethodType.Fill, true)]
	[HelpKeyword("vs.data.TableAdapter")]
	public virtual int vmethod_0(Class548.Class551 class551_0, int? nullable_0)
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
			class551_0.Clear();
		}
		return this.SqlDataAdapter_0.Fill(class551_0);
	}

	[HelpKeyword("vs.data.TableAdapter")]
	[DebuggerNonUserCode]
	[DataObjectMethod(DataObjectMethodType.Select, true)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public virtual Class548.Class551 vmethod_1(int? nullable_0)
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
		Class548.Class551 @class = new Class548.Class551();
		this.SqlDataAdapter_0.Fill(@class);
		return @class;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	[DebuggerNonUserCode]
	public virtual int vmethod_2(Class548.Class551 class551_0)
	{
		return this.SqlDataAdapter_0.Update(class551_0);
	}

	[HelpKeyword("vs.data.TableAdapter")]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	public virtual int vmethod_3(Class548 class548_0)
	{
		return this.SqlDataAdapter_0.Update(class548_0, "tblAbnAplForDisconReason");
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	[DebuggerNonUserCode]
	public virtual int vmethod_4(DataRow dataRow_0)
	{
		return this.SqlDataAdapter_0.Update(new DataRow[]
		{
			dataRow_0
		});
	}

	[DebuggerNonUserCode]
	[HelpKeyword("vs.data.TableAdapter")]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public virtual int vmethod_5(DataRow[] dataRow_0)
	{
		return this.SqlDataAdapter_0.Update(dataRow_0);
	}

	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Delete, true)]
	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public virtual int vmethod_6(int int_0)
	{
		this.SqlDataAdapter_0.DeleteCommand.Parameters[0].Value = int_0;
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

	[HelpKeyword("vs.data.TableAdapter")]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	[DataObjectMethod(DataObjectMethodType.Insert, true)]
	public virtual int vmethod_7(string string_0, int? nullable_0)
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

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DataObjectMethod(DataObjectMethodType.Update, true)]
	[DebuggerNonUserCode]
	[HelpKeyword("vs.data.TableAdapter")]
	public virtual int vmethod_8(string string_0, int? nullable_0, int int_0, int int_1)
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
		this.SqlDataAdapter_0.UpdateCommand.Parameters[2].Value = int_0;
		this.SqlDataAdapter_0.UpdateCommand.Parameters[3].Value = int_1;
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
	public virtual object vmethod_9(int int_0)
	{
		SqlCommand sqlCommand = this.SqlCommand_0[1];
		sqlCommand.Parameters[0].Value = int_0;
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

	private bool xyvCfghWcOx;
}
