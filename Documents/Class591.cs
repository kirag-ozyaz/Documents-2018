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
[DesignerCategory("code")]
[Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
[ToolboxItem(true)]
[DataObject(true)]
internal class Class591 : Component
{
	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public Class591()
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
		dataTableMapping.DataSetTable = "tAbonent";
		dataTableMapping.ColumnMappings.Add("CodeAbonent", "CodeAbonent");
		dataTableMapping.ColumnMappings.Add("StartDate", "StartDate");
		dataTableMapping.ColumnMappings.Add("FIO", "FIO");
		dataTableMapping.ColumnMappings.Add("Address", "Address");
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
		this.sqlCommand_0[0].CommandText = "SELECT        abn.CodeAbonent, abn.datechange AS StartDate, abn.Name AS FIO, ISNULL(kladrobj.Socr, '') + ' ' + ISNULL(kladrobj.Name, '') + ', ' + ISNULL(s.Name, '') \r\n                         + ' ' + ISNULL(s.Socr, '') + ' ' + RTRIM(LTRIM(STR(map.House))) + ISNULL(map.HousePrefix, '') + ' ' + ISNULL(obj.Name, '') AS Address\r\nFROM            tMapObj AS map LEFT OUTER JOIN\r\n                         tR_KladrStreet AS s ON s.Id = map.Street LEFT OUTER JOIN\r\n                         tR_KladrObj AS kladrobj ON s.KladrObjId = kladrobj.Id LEFT OUTER JOIN\r\n                         tAbnObj AS obj ON obj.idMap = map.idMap LEFT OUTER JOIN\r\n                         vAbn AS abn ON abn.id = obj.idAbn AND abn.TypeAbn = 206\r\nWHERE        (NOT (abn.id IS NULL)) AND (abn.isActive = 1) AND (abn.CodeAbonent = @Code)";
		this.sqlCommand_0[0].CommandType = CommandType.Text;
		this.sqlCommand_0[0].Parameters.Add(new SqlParameter("@Code", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "CodeAbonent", DataRowVersion.Current, false, null, "", "", ""));
	}

	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Fill, true)]
	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public virtual int vmethod_0(Class548.Class555 class555_0, int int_0)
	{
		this.SqlDataAdapter_0.SelectCommand = this.SqlCommand_0[0];
		this.SqlDataAdapter_0.SelectCommand.Parameters[0].Value = int_0;
		if (this.Boolean_0)
		{
			class555_0.Clear();
		}
		return this.SqlDataAdapter_0.Fill(class555_0);
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Select, true)]
	public virtual Class548.Class555 vmethod_1(int int_0)
	{
		this.SqlDataAdapter_0.SelectCommand = this.SqlCommand_0[0];
		this.SqlDataAdapter_0.SelectCommand.Parameters[0].Value = int_0;
		Class548.Class555 @class = new Class548.Class555();
		this.SqlDataAdapter_0.Fill(@class);
		return @class;
	}

	private SqlDataAdapter sqlDataAdapter_0;

	private SqlConnection sqlConnection_0;

	private SqlTransaction sqlTransaction_0;

	private SqlCommand[] sqlCommand_0;

	private bool bool_0;
}
