using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using Documents.Properties;

[Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
[HelpKeyword("vs.data.TableAdapter")]
[DataObject(true)]
[DesignerCategory("code")]
[ToolboxItem(true)]
internal class Class594 : Component
{
	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public Class594()
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
		dataTableMapping.DataSetTable = "tblAbnAplConnectPointForIndividualUsers";
		dataTableMapping.ColumnMappings.Add("Id", "Id");
		dataTableMapping.ColumnMappings.Add("Point", "Point");
		this.sqlDataAdapter_0.TableMappings.Add(dataTableMapping);
		this.sqlDataAdapter_0.DeleteCommand = new SqlCommand();
		this.sqlDataAdapter_0.DeleteCommand.Connection = this.SqlConnection_0;
		this.sqlDataAdapter_0.DeleteCommand.CommandText = "DELETE FROM [dbo].[tblAbnAplConnectPointForIndividualUsers] WHERE (([Id] = @Original_Id) AND ((@IsNull_Point = 1 AND [Point] IS NULL) OR ([Point] = @Original_Point)))";
		this.sqlDataAdapter_0.DeleteCommand.CommandType = CommandType.Text;
		this.sqlDataAdapter_0.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Id", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Original, false, null, "", "", ""));
		this.sqlDataAdapter_0.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Point", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Point", DataRowVersion.Original, true, null, "", "", ""));
		this.sqlDataAdapter_0.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Point", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Point", DataRowVersion.Original, false, null, "", "", ""));
		this.sqlDataAdapter_0.InsertCommand = new SqlCommand();
		this.sqlDataAdapter_0.InsertCommand.Connection = this.SqlConnection_0;
		this.sqlDataAdapter_0.InsertCommand.CommandText = "INSERT INTO [dbo].[tblAbnAplConnectPointForIndividualUsers] ([Point]) VALUES (@Point);\r\nSELECT Id, Point FROM tblAbnAplConnectPointForIndividualUsers WHERE (Id = SCOPE_IDENTITY())";
		this.sqlDataAdapter_0.InsertCommand.CommandType = CommandType.Text;
		this.sqlDataAdapter_0.InsertCommand.Parameters.Add(new SqlParameter("@Point", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Point", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlDataAdapter_0.UpdateCommand = new SqlCommand();
		this.sqlDataAdapter_0.UpdateCommand.Connection = this.SqlConnection_0;
		this.sqlDataAdapter_0.UpdateCommand.CommandText = "UPDATE       tblAbnAplConnectPointForIndividualUsers\r\nSET                Point = @Point\r\nWHERE        (Id = @Original_Id); \r\nSELECT Id, Point FROM tblAbnAplConnectPointForIndividualUsers WHERE (Id = @Id)";
		this.sqlDataAdapter_0.UpdateCommand.CommandType = CommandType.Text;
		this.sqlDataAdapter_0.UpdateCommand.Parameters.Add(new SqlParameter("@Point", SqlDbType.NVarChar, 255, ParameterDirection.Input, 0, 0, "Point", DataRowVersion.Current, false, null, "", "", ""));
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
	private void method_2()
	{
		this.sqlCommand_0 = new SqlCommand[1];
		this.sqlCommand_0[0] = new SqlCommand();
		this.sqlCommand_0[0].Connection = this.SqlConnection_0;
		this.sqlCommand_0[0].CommandText = "SELECT Id, Point FROM dbo.tblAbnAplConnectPointForIndividualUsers";
		this.sqlCommand_0[0].CommandType = CommandType.Text;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DataObjectMethod(DataObjectMethodType.Fill, true)]
	[HelpKeyword("vs.data.TableAdapter")]
	public virtual int vmethod_0(Class548.Class558 class558_0)
	{
		this.SqlDataAdapter_0.SelectCommand = this.SqlCommand_0[0];
		if (this.Boolean_0)
		{
			class558_0.Clear();
		}
		return this.SqlDataAdapter_0.Fill(class558_0);
	}

	[DataObjectMethod(DataObjectMethodType.Select, true)]
	[HelpKeyword("vs.data.TableAdapter")]
	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public virtual Class548.Class558 vmethod_1()
	{
		this.SqlDataAdapter_0.SelectCommand = this.SqlCommand_0[0];
		Class548.Class558 @class = new Class548.Class558();
		this.SqlDataAdapter_0.Fill(@class);
		return @class;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	public virtual int vmethod_2(Class548.Class558 class558_0)
	{
		return this.SqlDataAdapter_0.Update(class558_0);
	}

	[HelpKeyword("vs.data.TableAdapter")]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	public virtual int vmethod_3(Class548 class548_0)
	{
		return this.SqlDataAdapter_0.Update(class548_0, "tblAbnAplConnectPointForIndividualUsers");
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	public virtual int vmethod_4(DataRow dataRow_0)
	{
		return this.SqlDataAdapter_0.Update(new DataRow[]
		{
			dataRow_0
		});
	}

	[HelpKeyword("vs.data.TableAdapter")]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	public virtual int vmethod_5(DataRow[] dataRow_0)
	{
		return this.SqlDataAdapter_0.Update(dataRow_0);
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Delete, true)]
	[DebuggerNonUserCode]
	public virtual int vmethod_6(int? nullable_0, string string_0)
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

	[DataObjectMethod(DataObjectMethodType.Insert, true)]
	[DebuggerNonUserCode]
	[HelpKeyword("vs.data.TableAdapter")]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public virtual int vmethod_7(string string_0)
	{
		if (string_0 == null)
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[0].Value = DBNull.Value;
		}
		else
		{
			this.SqlDataAdapter_0.InsertCommand.Parameters[0].Value = string_0;
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
	[DebuggerNonUserCode]
	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Update, true)]
	public virtual int vmethod_8(string string_0, int? nullable_0, int? nullable_1)
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

	private SqlDataAdapter sqlDataAdapter_0;

	private SqlConnection sqlConnection_0;

	private SqlTransaction sqlTransaction_0;

	private SqlCommand[] sqlCommand_0;

	private bool bool_0;
}
