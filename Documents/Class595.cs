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
[DataObject(true)]
[Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
[ToolboxItem(true)]
[HelpKeyword("vs.data.TableAdapter")]
internal class Class595 : Component
{
	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public Class595()
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
		dataTableMapping.DataSetTable = "tblAbnObj2";
		dataTableMapping.ColumnMappings.Add("AbnID", "AbnID");
		dataTableMapping.ColumnMappings.Add("Title", "Title");
		dataTableMapping.ColumnMappings.Add("ObjId", "ObjId");
		dataTableMapping.ColumnMappings.Add("DateDog", "DateDog");
		dataTableMapping.ColumnMappings.Add("Code", "Code");
		dataTableMapping.ColumnMappings.Add("NameShort", "NameShort");
		dataTableMapping.ColumnMappings.Add("CanceledAplId", "CanceledAplId");
		dataTableMapping.ColumnMappings.Add("idPoint", "idPoint");
		dataTableMapping.ColumnMappings.Add("NoDogAbn", "NoDogAbn");
		dataTableMapping.ColumnMappings.Add("NoDogObj", "NoDogObj");
		dataTableMapping.ColumnMappings.Add("DateAction", "DateAction");
		this.sqlDataAdapter_0.TableMappings.Add(dataTableMapping);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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
		this.sqlCommand_0[0].CommandText = "SELECT        tAbnObj.id AS ObjId, tAbnObj.Name AS Title, tAbnDoc_Dogovor.DogDate AS DateDog, tAbn.CodeAbonent AS Code, tAbn.Name AS NameShort, tAbn.id AS AbnID, \r\n                         tblAbnAplForDiscon.Id AS CanceledAplId, tblAbnAplForDisconObjects.PlaceId AS idPoint, tblAbnAplForDisconObjects.NoDogAbn, \r\n                         tblAbnAplForDisconObjects.NoDogObj, tblAbnAplForDiscon.DateAction\r\nFROM            tblAbnAplForDisconObjects LEFT OUTER JOIN\r\n                         tAbnObj ON tblAbnAplForDisconObjects.AbnObjId = tAbnObj.id INNER JOIN\r\n                         tblAbnAplForDiscon ON tblAbnAplForDisconObjects.IdAplForDiscon = tblAbnAplForDiscon.Id LEFT OUTER JOIN\r\n                         tAbnDoc_Dogovor ON tblAbnAplForDisconObjects.AbnId = tAbnDoc_Dogovor.idAbn LEFT OUTER JOIN\r\n                         tAbn ON tblAbnAplForDisconObjects.AbnId = tAbn.id\r\nWHERE        (tblAbnAplForDisconObjects.IdCancelApl IS NULL OR\r\n                         tblAbnAplForDisconObjects.IdCancelApl = @NumCurApl) AND (tblAbnAplForDiscon.Id = @Id)";
		this.sqlCommand_0[0].CommandType = CommandType.Text;
		this.sqlCommand_0[0].Parameters.Add(new SqlParameter("@NumCurApl", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "IdCancelApl", DataRowVersion.Current, false, null, "", "", ""));
		this.sqlCommand_0[0].Parameters.Add(new SqlParameter("@Id", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "CanceledAplId", DataRowVersion.Current, false, null, "", "", ""));
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DataObjectMethod(DataObjectMethodType.Fill, true)]
	[DebuggerNonUserCode]
	[HelpKeyword("vs.data.TableAdapter")]
	public virtual int vmethod_0(Class548.Class559 class559_0, int? nullable_0, int int_0)
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
			class559_0.Clear();
		}
		return this.SqlDataAdapter_0.Fill(class559_0);
	}

	[HelpKeyword("vs.data.TableAdapter")]
	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DataObjectMethod(DataObjectMethodType.Select, true)]
	public virtual Class548.Class559 vmethod_1(int? nullable_0, int int_0)
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
		Class548.Class559 @class = new Class548.Class559();
		this.SqlDataAdapter_0.Fill(@class);
		return @class;
	}

	private SqlDataAdapter sqlDataAdapter_0;

	private SqlConnection sqlConnection_0;

	private SqlTransaction sqlTransaction_0;

	private SqlCommand[] sqlCommand_0;

	private bool bool_0;
}
