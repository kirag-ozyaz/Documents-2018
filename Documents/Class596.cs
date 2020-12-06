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
[HelpKeyword("vs.data.TableAdapter")]
[Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
[DataObject(true)]
[ToolboxItem(true)]
internal class Class596 : Component
{
	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public Class596()
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
		dataTableMapping.DataSetTable = "tblAbnAplForDisconIndividualUsersForCancel";
		dataTableMapping.ColumnMappings.Add("FIO", "FIO");
		dataTableMapping.ColumnMappings.Add("Address", "Address");
		dataTableMapping.ColumnMappings.Add("PlaceId", "PlaceId");
		dataTableMapping.ColumnMappings.Add("IsNC", "IsNC");
		dataTableMapping.ColumnMappings.Add("Code", "Code");
		dataTableMapping.ColumnMappings.Add("DateDog", "DateDog");
		dataTableMapping.ColumnMappings.Add("Id", "Id");
		dataTableMapping.ColumnMappings.Add("CanceledAplId", "CanceledAplId");
		dataTableMapping.ColumnMappings.Add("Place", "Place");
		this.sqlDataAdapter_0.TableMappings.Add(dataTableMapping);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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
		this.sqlCommand_0[0].CommandText = "SELECT        tblAbnAplForDisconIndividualUsers.FIO, tblAbnAplForDisconIndividualUsers.Address, tblAbnAplForDisconIndividualUsers.PlaceId, \r\n                         tblAbnAplForDisconIndividualUsers.IsNC, tblAbnAplForDisconIndividualUsers.Code, tblAbnAplForDisconIndividualUsers.DateDog, \r\n                         tblAbnAplForDisconIndividualUsers.Id, tblAbnAplForDiscon.Id AS CanceledAplId, tblAbnAplConnectPointForIndividualUsers.Point AS Place\r\nFROM            tblAbnAplForDisconIndividualUsers INNER JOIN\r\n                         tblAbnAplForDiscon ON tblAbnAplForDisconIndividualUsers.IdAplForDiscon = tblAbnAplForDiscon.Id INNER JOIN\r\n                         tblAbnAplConnectPointForIndividualUsers ON tblAbnAplForDisconIndividualUsers.PlaceId = tblAbnAplConnectPointForIndividualUsers.Id\r\nWHERE        (tblAbnAplForDisconIndividualUsers.IdCancelApl IS NULL OR\r\n                         tblAbnAplForDisconIndividualUsers.IdCancelApl = @NumCurApl) AND (tblAbnAplForDiscon.Id = @Id)";
		this.sqlCommand_0[0].CommandType = CommandType.Text;
		this.sqlCommand_0[0].Parameters.Add(new SqlParameter("@NumCurApl", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "IdCancelApl", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlCommand_0[0].Parameters.Add(new SqlParameter("@Id", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "CanceledAplId", DataRowVersion.Current, false, null, "", "", ""));
	}

	[DataObjectMethod(DataObjectMethodType.Fill, true)]
	[HelpKeyword("vs.data.TableAdapter")]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	public virtual int vmethod_0(Class548.Class560 class560_0, int? nullable_0, int int_0)
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
		this.SqlDataAdapter_0.SelectCommand.Parameters[1].Value = int_0;
		if (this.Boolean_0)
		{
			class560_0.Clear();
		}
		return this.SqlDataAdapter_0.Fill(class560_0);
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Select, true)]
	[DebuggerNonUserCode]
	public virtual Class548.Class560 vmethod_1(int? nullable_0, int int_0)
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
		this.SqlDataAdapter_0.SelectCommand.Parameters[1].Value = int_0;
		Class548.Class560 @class = new Class548.Class560();
		this.SqlDataAdapter_0.Fill(@class);
		return @class;
	}

	private SqlDataAdapter sqlDataAdapter_0;

	private SqlConnection sqlConnection_0;

	private SqlTransaction sqlTransaction_0;

	private SqlCommand[] sqlCommand_0;

	private bool bool_0;
}
