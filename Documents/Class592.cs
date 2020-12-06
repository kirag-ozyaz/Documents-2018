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
[DesignerCategory("code")]
[Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
[DataObject(true)]
internal class Class592 : Component
{
	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public Class592()
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

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
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
		dataTableMapping.DataSetTable = "tblAbnObj1";
		dataTableMapping.ColumnMappings.Add("Title", "Title");
		dataTableMapping.ColumnMappings.Add("ObjId", "ObjId");
		dataTableMapping.ColumnMappings.Add("Point", "Point");
		this.sqlDataAdapter_0.TableMappings.Add(dataTableMapping);
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
		this.sqlCommand_0 = new SqlCommand[1];
		this.sqlCommand_0[0] = new SqlCommand();
		this.sqlCommand_0[0].Connection = this.SqlConnection_0;
		this.sqlCommand_0[0].CommandText = "SELECT        tAbnObj.id AS ObjId, tAbnObj.Name AS Point, tConnect.Comment AS Title\r\nFROM            tAbnObj LEFT OUTER JOIN\r\n                         tConnect ON tConnect.idObj = tAbnObj.id\r\nWHERE        (tAbnObj.idAbn = @AbnId)";
		this.sqlCommand_0[0].CommandType = CommandType.Text;
		this.sqlCommand_0[0].Parameters.Add(new SqlParameter("@AbnId", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "idAbn", DataRowVersion.Current, false, null, "", "", ""));
	}

	[DataObjectMethod(DataObjectMethodType.Fill, true)]
	[HelpKeyword("vs.data.TableAdapter")]
	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public virtual int vmethod_0(Class548.Class556 class556_0, int? nullable_0)
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
			class556_0.Clear();
		}
		return this.SqlDataAdapter_0.Fill(class556_0);
	}

	[DebuggerNonUserCode]
	[DataObjectMethod(DataObjectMethodType.Select, true)]
	[HelpKeyword("vs.data.TableAdapter")]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public virtual Class548.Class556 vmethod_1(int? nullable_0)
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
		Class548.Class556 @class = new Class548.Class556();
		this.SqlDataAdapter_0.Fill(@class);
		return @class;
	}

	private SqlDataAdapter sqlDataAdapter_0;

	private SqlConnection sqlConnection_0;

	private SqlTransaction sqlTransaction_0;

	private SqlCommand[] sqlCommand_0;

	private bool bool_0;
}
