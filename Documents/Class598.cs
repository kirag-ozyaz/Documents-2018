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
[ToolboxItem(true)]
[DataObject(true)]
[DesignerCategory("code")]
internal class Class598 : Component
{
	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public Class598()
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

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	private void method_0()
	{
		this.sqlDataAdapter_0 = new SqlDataAdapter();
		DataTableMapping dataTableMapping = new DataTableMapping();
		dataTableMapping.SourceTable = "Table";
		dataTableMapping.DataSetTable = "tR_Worker";
		dataTableMapping.ColumnMappings.Add("id", "id");
		dataTableMapping.ColumnMappings.Add("FIO", "FIO");
		this.sqlDataAdapter_0.TableMappings.Add(dataTableMapping);
		this.sqlDataAdapter_0.DeleteCommand = new SqlCommand();
		this.sqlDataAdapter_0.DeleteCommand.Connection = this.SqlConnection_0;
		this.sqlDataAdapter_0.DeleteCommand.CommandText = "DELETE FROM [tR_Worker] WHERE (([id] = @Original_id))";
		this.sqlDataAdapter_0.DeleteCommand.CommandType = CommandType.Text;
		this.sqlDataAdapter_0.DeleteCommand.Parameters.Add(new SqlParameter("@Original_id", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "id", DataRowVersion.Original, false, null, "", "", ""));
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
		this.sqlCommand_0 = new SqlCommand[2];
		this.sqlCommand_0[0] = new SqlCommand();
		this.sqlCommand_0[0].Connection = this.SqlConnection_0;
		this.sqlCommand_0[0].CommandText = "SELECT        id, F + ' ' + I + ' ' + O AS FIO\r\nFROM            tR_Worker\r\nWHERE        (Division = @Division) AND (DateEnd IS NULL)\r\nORDER BY FIO";
		this.sqlCommand_0[0].CommandType = CommandType.Text;
		this.sqlCommand_0[0].Parameters.Add(new SqlParameter("@Division", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "Division", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlCommand_0[1] = new SqlCommand();
		this.sqlCommand_0[1].Connection = this.SqlConnection_0;
		this.sqlCommand_0[1].CommandText = "SELECT        tR_Worker.id, tR_Worker.F + ' ' + tR_Worker.I + ' ' + tR_Worker.O AS FIO\r\nFROM            tR_Worker INNER JOIN\r\n                         tL_ClassifierWorker ON tR_Worker.id = tL_ClassifierWorker.IdWorker INNER JOIN\r\n                         tR_Classifier ON tL_ClassifierWorker.IdGroup = tR_Classifier.Id AND tR_Classifier.IsGroup = 0\r\nWHERE        (tR_Worker.DateEnd IS NULL) AND (tR_Classifier.ParentKey LIKE @Division)\r\nORDER BY FIO";
		this.sqlCommand_0[1].CommandType = CommandType.Text;
		this.sqlCommand_0[1].Parameters.Add(new SqlParameter("@Division", SqlDbType.VarChar, 50, ParameterDirection.Input, 0, 0, "ParentKey", DataRowVersion.Current, false, null, "", "", ""));
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DataObjectMethod(DataObjectMethodType.Fill, true)]
	[HelpKeyword("vs.data.TableAdapter")]
	[DebuggerNonUserCode]
	public virtual int vmethod_0(Class548.Class562 class562_0, int? nullable_0)
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
			class562_0.Clear();
		}
		return this.SqlDataAdapter_0.Fill(class562_0);
	}

	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Select, true)]
	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public virtual Class548.Class562 vmethod_1(int? nullable_0)
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
		Class548.Class562 @class = new Class548.Class562();
		this.SqlDataAdapter_0.Fill(@class);
		return @class;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Fill, false)]
	[DebuggerNonUserCode]
	public virtual int vmethod_2(Class548.Class562 class562_0, string string_0)
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
			class562_0.Clear();
		}
		return this.SqlDataAdapter_0.Fill(class562_0);
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Select, false)]
	[DebuggerNonUserCode]
	public virtual Class548.Class562 vmethod_3(string string_0)
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
		Class548.Class562 @class = new Class548.Class562();
		this.SqlDataAdapter_0.Fill(@class);
		return @class;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	[DebuggerNonUserCode]
	public virtual int vmethod_4(Class548.Class562 class562_0)
	{
		return this.SqlDataAdapter_0.Update(class562_0);
	}

	[DebuggerNonUserCode]
	[HelpKeyword("vs.data.TableAdapter")]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public virtual int vmethod_5(Class548 class548_0)
	{
		return this.SqlDataAdapter_0.Update(class548_0, "tR_Worker");
	}

	[DebuggerNonUserCode]
	[HelpKeyword("vs.data.TableAdapter")]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public virtual int vmethod_6(DataRow dataRow_0)
	{
		return this.SqlDataAdapter_0.Update(new DataRow[]
		{
			dataRow_0
		});
	}

	[HelpKeyword("vs.data.TableAdapter")]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	public virtual int vmethod_7(DataRow[] dataRow_0)
	{
		return this.SqlDataAdapter_0.Update(dataRow_0);
	}

	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Delete, true)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	public virtual int vmethod_8(int int_0)
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

	private SqlDataAdapter sqlDataAdapter_0;

	private SqlConnection sqlConnection_0;

	private SqlTransaction sqlTransaction_0;

	private SqlCommand[] sqlCommand_0;

	private bool bool_0;
}
