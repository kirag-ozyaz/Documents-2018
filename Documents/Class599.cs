using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using Documents.Properties;

[DataObject(true)]
[HelpKeyword("vs.data.TableAdapter")]
[Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
[ToolboxItem(true)]
[DesignerCategory("code")]
internal class Class599 : Component
{
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	protected IDbCommand[] IDbCommand_0
	{
		get
		{
			if (this.idbCommand_0 == null)
			{
				this.method_0();
			}
			return this.idbCommand_0;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	private void method_0()
	{
		this.idbCommand_0 = new IDbCommand[4];
		this.idbCommand_0[0] = new SqlCommand();
		((SqlCommand)this.idbCommand_0[0]).Connection = new SqlConnection(Settings.Default.PrvDBConnectionString);
		((SqlCommand)this.idbCommand_0[0]).CommandText = "dbo.GetAbonentAdressStr";
		((SqlCommand)this.idbCommand_0[0]).CommandType = CommandType.StoredProcedure;
		((SqlCommand)this.idbCommand_0[0]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.VarChar, 50, ParameterDirection.ReturnValue, 0, 0, null, DataRowVersion.Current, false, null, "", "", ""));
		((SqlCommand)this.idbCommand_0[0]).Parameters.Add(new SqlParameter("@CA", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
		this.idbCommand_0[1] = new SqlCommand();
		((SqlCommand)this.idbCommand_0[1]).Connection = new SqlConnection(Settings.Default.PrvDbncConnectionString);
		((SqlCommand)this.idbCommand_0[1]).CommandText = "dbo.GetAbonentAdressStr";
		((SqlCommand)this.idbCommand_0[1]).CommandType = CommandType.StoredProcedure;
		((SqlCommand)this.idbCommand_0[1]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.VarChar, 50, ParameterDirection.ReturnValue, 0, 0, null, DataRowVersion.Current, false, null, "", "", ""));
		((SqlCommand)this.idbCommand_0[1]).Parameters.Add(new SqlParameter("@CA", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
		this.idbCommand_0[2] = new SqlCommand();
		((SqlCommand)this.idbCommand_0[2]).Connection = new SqlConnection(Settings.Default.PrvDBConnectionString);
		((SqlCommand)this.idbCommand_0[2]).CommandText = "dbo.GetAbonentConnectedMatrix";
		((SqlCommand)this.idbCommand_0[2]).CommandType = CommandType.StoredProcedure;
		((SqlCommand)this.idbCommand_0[2]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Bit, 1, ParameterDirection.ReturnValue, 1, 0, null, DataRowVersion.Current, false, null, "", "", ""));
		((SqlCommand)this.idbCommand_0[2]).Parameters.Add(new SqlParameter("@CA", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
		this.idbCommand_0[3] = new SqlCommand();
		((SqlCommand)this.idbCommand_0[3]).Connection = new SqlConnection(Settings.Default.PrvDbncConnectionString);
		((SqlCommand)this.idbCommand_0[3]).CommandText = "dbo.GetAbonentConnectedMatrix";
		((SqlCommand)this.idbCommand_0[3]).CommandType = CommandType.StoredProcedure;
		((SqlCommand)this.idbCommand_0[3]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Bit, 1, ParameterDirection.ReturnValue, 1, 0, null, DataRowVersion.Current, false, null, "", "", ""));
		((SqlCommand)this.idbCommand_0[3]).Parameters.Add(new SqlParameter("@CA", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	internal virtual string vmethod_0(int? nullable_0)
	{
		SqlCommand sqlCommand = (SqlCommand)this.IDbCommand_0[0];
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
		try
		{
			sqlCommand.ExecuteNonQuery();
		}
		finally
		{
			if (state == ConnectionState.Closed)
			{
				sqlCommand.Connection.Close();
			}
		}
		if (sqlCommand.Parameters[0].Value != null)
		{
			if (sqlCommand.Parameters[0].Value.GetType() != typeof(DBNull))
			{
				return (string)sqlCommand.Parameters[0].Value;
			}
		}
		return null;
	}

	[HelpKeyword("vs.data.TableAdapter")]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	internal virtual string vmethod_1(int? nullable_0)
	{
		SqlCommand sqlCommand = (SqlCommand)this.IDbCommand_0[1];
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
		try
		{
			sqlCommand.ExecuteNonQuery();
		}
		finally
		{
			if (state == ConnectionState.Closed)
			{
				sqlCommand.Connection.Close();
			}
		}
		if (sqlCommand.Parameters[0].Value != null)
		{
			if (sqlCommand.Parameters[0].Value.GetType() != typeof(DBNull))
			{
				return (string)sqlCommand.Parameters[0].Value;
			}
		}
		return null;
	}

	[DebuggerNonUserCode]
	[HelpKeyword("vs.data.TableAdapter")]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	internal virtual bool? vmethod_2(int? nullable_0)
	{
		SqlCommand sqlCommand = (SqlCommand)this.IDbCommand_0[2];
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
		try
		{
			sqlCommand.ExecuteNonQuery();
		}
		finally
		{
			if (state == ConnectionState.Closed)
			{
				sqlCommand.Connection.Close();
			}
		}
		if (sqlCommand.Parameters[0].Value != null)
		{
			if (sqlCommand.Parameters[0].Value.GetType() != typeof(DBNull))
			{
				return new bool?((bool)sqlCommand.Parameters[0].Value);
			}
		}
		return null;
	}

	[HelpKeyword("vs.data.TableAdapter")]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	internal virtual bool? vmethod_3(int? nullable_0)
	{
		SqlCommand sqlCommand = (SqlCommand)this.IDbCommand_0[3];
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
		try
		{
			sqlCommand.ExecuteNonQuery();
		}
		finally
		{
			if (state == ConnectionState.Closed)
			{
				sqlCommand.Connection.Close();
			}
		}
		if (sqlCommand.Parameters[0].Value != null)
		{
			if (sqlCommand.Parameters[0].Value.GetType() != typeof(DBNull))
			{
				return new bool?((bool)sqlCommand.Parameters[0].Value);
			}
		}
		return null;
	}

	public Class599()
	{
		
		
	}

	private IDbCommand[] idbCommand_0;
}
