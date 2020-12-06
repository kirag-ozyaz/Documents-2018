using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;
using DataSql;

namespace Documents
{
	public class DataRetriever : GInterface0
	{
		public DataRetriever(string connectionString, string tableName)
		{
			
			this.string_1 = "*";
			this.int_0 = -1;
			this.sqlDataAdapter_0 = new SqlDataAdapter();
			
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			this.sqlCommand_0 = sqlConnection.CreateCommand();
			this.string_0 = tableName;
		}

		public DataRetriever(SQLSettings sqlSett, string tableName)
		{
			
			this.string_1 = "*";
			this.int_0 = -1;
			this.sqlDataAdapter_0 = new SqlDataAdapter();
			
			SqlDataConnect sqlDataConnect = new SqlDataConnect();
			sqlDataConnect.OpenConnection(sqlSett);
			this.sqlCommand_0 = sqlDataConnect.Connection.CreateCommand();
			this.string_0 = tableName;
		}

		public DataRetriever(SQLSettings sqlSett, string tableName, ArrayList listOfColumnNamesGridView)
		{
			
			this.string_1 = "*";
			this.int_0 = -1;
			this.sqlDataAdapter_0 = new SqlDataAdapter();
			
			SqlDataConnect sqlDataConnect = new SqlDataConnect();
			sqlDataConnect.OpenConnection(sqlSett);
			this.sqlCommand_0 = sqlDataConnect.Connection.CreateCommand();
			this.string_1 = " ";
			foreach (object obj in listOfColumnNamesGridView)
			{
				if (obj.GetType() == typeof(ClassesDoc.ParametryColumnsDataGridView))
				{
					this.string_1 = string.Concat(new object[]
					{
						this.string_1,
						"[",
						((ClassesDoc.ParametryColumnsDataGridView)obj).Column,
						"], "
					});
				}
			}
			this.string_1 = this.string_1.Remove(this.string_1.LastIndexOf(", "));
			this.string_0 = tableName;
		}

		public int RowCount
		{
			get
			{
				if (this.int_0 != -1)
				{
					return this.int_0;
				}
				this.sqlCommand_0.CommandText = "SELECT COUNT(*) FROM " + this.string_0;
				this.int_0 = (int)this.sqlCommand_0.ExecuteScalar();
				return this.int_0;
			}
		}

		public DataColumnCollection Columns
		{
			get
			{
				if (this.dataColumnCollection_0 != null)
				{
					return this.dataColumnCollection_0;
				}
				this.sqlCommand_0.CommandText = "SELECT " + this.string_1 + " FROM " + this.string_0;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
				sqlDataAdapter.SelectCommand = this.sqlCommand_0;
				DataTable dataTable = new DataTable();
				dataTable.Locale = CultureInfo.InvariantCulture;
				sqlDataAdapter.FillSchema(dataTable, SchemaType.Source);
				this.dataColumnCollection_0 = dataTable.Columns;
				return this.dataColumnCollection_0;
			}
		}

		private string method_0()
		{
			if (this.string_2 != null)
			{
				return this.string_2;
			}
			StringBuilder stringBuilder = new StringBuilder();
			bool flag = true;
			foreach (object obj in this.Columns)
			{
				DataColumn dataColumn = (DataColumn)obj;
				if (!flag)
				{
					stringBuilder.Append(", ");
				}
				stringBuilder.Append(dataColumn.ColumnName);
				flag = false;
			}
			this.string_2 = stringBuilder.ToString();
			return this.string_2;
		}

		public DataTable SupplyPageOfData(int lowerPageBoundary, int rowsPerPage)
		{
			if (this.string_3 == null)
			{
				this.string_3 = this.Columns[0].ColumnName;
			}
			if (!this.Columns[this.string_3].Unique)
			{
				throw new InvalidOperationException(string.Format("Column {0} must contain unique values.", this.string_3));
			}
			this.sqlCommand_0.CommandText = string.Concat(new object[]
			{
				"Select Top ",
				rowsPerPage,
				" ",
				this.method_0(),
				" From ",
				this.string_0,
				" WHERE ",
				this.string_3,
				" NOT IN (SELECT TOP ",
				lowerPageBoundary,
				" ",
				this.string_3,
				" From ",
				this.string_0,
				" Order By ",
				this.string_3,
				") Order By ",
				this.string_3
			});
			this.sqlDataAdapter_0.SelectCommand = this.sqlCommand_0;
			DataTable dataTable = new DataTable();
			dataTable.Locale = CultureInfo.InvariantCulture;
			this.sqlDataAdapter_0.Fill(dataTable);
			return dataTable;
		}

		private string string_0;

		private SqlCommand sqlCommand_0;

		private string string_1;

		private int int_0;

		private DataColumnCollection dataColumnCollection_0;

		private string string_2;

		private string string_3;

		private SqlDataAdapter sqlDataAdapter_0;
	}
}
