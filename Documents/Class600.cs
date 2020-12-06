using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;

[DesignerCategory("code")]
[Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
[ToolboxItem(true)]
[HelpKeyword("vs.data.TableAdapterManager")]
internal class Class600 : Component
{
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	public Class600.Enum23 Enum23_0
	{
		get
		{
			return this.enum23_0;
		}
		set
		{
			this.enum23_0 = value;
		}
	}

	[DebuggerNonUserCode]
	[Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public Class585 Class585_0
	{
		get
		{
			return this.class585_0;
		}
		set
		{
			this.class585_0 = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
	public Class586 Class586_0
	{
		get
		{
			return this.class586_0;
		}
		set
		{
			this.class586_0 = value;
		}
	}

	[Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	public Class587 Class587_0
	{
		get
		{
			return this.class587_0;
		}
		set
		{
			this.class587_0 = value;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
	[DebuggerNonUserCode]
	public Class590 Class590_0
	{
		get
		{
			return this.class590_0;
		}
		set
		{
			this.class590_0 = value;
		}
	}

	[Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	public Class594 Class594_0
	{
		get
		{
			return this.class594_0;
		}
		set
		{
			this.class594_0 = value;
		}
	}

	[Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	public Class598 Class598_0
	{
		get
		{
			return this.class598_0;
		}
		set
		{
			this.class598_0 = value;
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

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[Browsable(false)]
	[DebuggerNonUserCode]
	public IDbConnection IDbConnection_0
	{
		get
		{
			if (this.idbConnection_0 != null)
			{
				return this.idbConnection_0;
			}
			if (this.class585_0 != null && this.class585_0.SqlConnection_0 != null)
			{
				return this.class585_0.SqlConnection_0;
			}
			if (this.class586_0 != null && this.class586_0.SqlConnection_0 != null)
			{
				return this.class586_0.SqlConnection_0;
			}
			if (this.class587_0 != null && this.class587_0.SqlConnection_0 != null)
			{
				return this.class587_0.SqlConnection_0;
			}
			if (this.class590_0 != null && this.class590_0.SqlConnection_0 != null)
			{
				return this.class590_0.SqlConnection_0;
			}
			if (this.class594_0 != null && this.class594_0.SqlConnection_0 != null)
			{
				return this.class594_0.SqlConnection_0;
			}
			if (this.class598_0 != null && this.class598_0.SqlConnection_0 != null)
			{
				return this.class598_0.SqlConnection_0;
			}
			return null;
		}
		set
		{
			this.idbConnection_0 = value;
		}
	}

	[DebuggerNonUserCode]
	[Browsable(false)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public int Int32_0
	{
		get
		{
			int num = 0;
			if (this.class585_0 != null)
			{
				num++;
			}
			if (this.class586_0 != null)
			{
				num++;
			}
			if (this.class587_0 != null)
			{
				num++;
			}
			if (this.class590_0 != null)
			{
				num++;
			}
			if (this.class594_0 != null)
			{
				num++;
			}
			if (this.class598_0 != null)
			{
				num++;
			}
			return num;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	private int method_0(Class548 class548_0, List<DataRow> list_0, List<DataRow> list_1)
	{
		int num = 0;
		if (this.class594_0 != null)
		{
			DataRow[] array = class548_0.tblAbnAplConnectPointForIndividualUsers.Select(null, null, DataViewRowState.ModifiedCurrent);
			array = this.method_3(array, list_1);
			if (array != null && array.Length != 0)
			{
				num += this.class594_0.vmethod_5(array);
				list_0.AddRange(array);
			}
		}
		if (this.class598_0 != null)
		{
			DataRow[] array2 = class548_0.tR_Worker.Select(null, null, DataViewRowState.ModifiedCurrent);
			array2 = this.method_3(array2, list_1);
			if (array2 != null && array2.Length != 0)
			{
				num += this.class598_0.vmethod_7(array2);
				list_0.AddRange(array2);
			}
		}
		if (this.class587_0 != null)
		{
			DataRow[] array3 = class548_0.tblAbnAplForDisconReason.Select(null, null, DataViewRowState.ModifiedCurrent);
			array3 = this.method_3(array3, list_1);
			if (array3 != null && array3.Length != 0)
			{
				num += this.class587_0.vmethod_5(array3);
				list_0.AddRange(array3);
			}
		}
		if (this.class585_0 != null)
		{
			DataRow[] array4 = class548_0.tblAbnAplForDiscon.Select(null, null, DataViewRowState.ModifiedCurrent);
			array4 = this.method_3(array4, list_1);
			if (array4 != null && array4.Length != 0)
			{
				num += this.class585_0.vmethod_19(array4);
				list_0.AddRange(array4);
			}
		}
		if (this.class586_0 != null)
		{
			DataRow[] array5 = class548_0.tblAbnAplForDisconObjects.Select(null, null, DataViewRowState.ModifiedCurrent);
			array5 = this.method_3(array5, list_1);
			if (array5 != null && array5.Length != 0)
			{
				num += this.class586_0.vmethod_15(array5);
				list_0.AddRange(array5);
			}
		}
		if (this.class590_0 != null)
		{
			DataRow[] array6 = class548_0.tblAbnAplForDisconIndividualUsers.Select(null, null, DataViewRowState.ModifiedCurrent);
			array6 = this.method_3(array6, list_1);
			if (array6 != null && array6.Length != 0)
			{
				num += this.class590_0.vmethod_15(array6);
				list_0.AddRange(array6);
			}
		}
		return num;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	private int method_1(Class548 class548_0, List<DataRow> list_0)
	{
		int num = 0;
		if (this.class594_0 != null)
		{
			DataRow[] array = class548_0.tblAbnAplConnectPointForIndividualUsers.Select(null, null, DataViewRowState.Added);
			if (array != null && array.Length != 0)
			{
				num += this.class594_0.vmethod_5(array);
				list_0.AddRange(array);
			}
		}
		if (this.class598_0 != null)
		{
			DataRow[] array2 = class548_0.tR_Worker.Select(null, null, DataViewRowState.Added);
			if (array2 != null && array2.Length != 0)
			{
				num += this.class598_0.vmethod_7(array2);
				list_0.AddRange(array2);
			}
		}
		if (this.class587_0 != null)
		{
			DataRow[] array3 = class548_0.tblAbnAplForDisconReason.Select(null, null, DataViewRowState.Added);
			if (array3 != null && array3.Length != 0)
			{
				num += this.class587_0.vmethod_5(array3);
				list_0.AddRange(array3);
			}
		}
		if (this.class585_0 != null)
		{
			DataRow[] array4 = class548_0.tblAbnAplForDiscon.Select(null, null, DataViewRowState.Added);
			if (array4 != null && array4.Length != 0)
			{
				num += this.class585_0.vmethod_19(array4);
				list_0.AddRange(array4);
			}
		}
		if (this.class586_0 != null)
		{
			DataRow[] array5 = class548_0.tblAbnAplForDisconObjects.Select(null, null, DataViewRowState.Added);
			if (array5 != null && array5.Length != 0)
			{
				num += this.class586_0.vmethod_15(array5);
				list_0.AddRange(array5);
			}
		}
		if (this.class590_0 != null)
		{
			DataRow[] array6 = class548_0.tblAbnAplForDisconIndividualUsers.Select(null, null, DataViewRowState.Added);
			if (array6 != null && array6.Length != 0)
			{
				num += this.class590_0.vmethod_15(array6);
				list_0.AddRange(array6);
			}
		}
		return num;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	private int method_2(Class548 class548_0, List<DataRow> list_0)
	{
		int num = 0;
		if (this.class590_0 != null)
		{
			DataRow[] array = class548_0.tblAbnAplForDisconIndividualUsers.Select(null, null, DataViewRowState.Deleted);
			if (array != null && array.Length != 0)
			{
				num += this.class590_0.vmethod_15(array);
				list_0.AddRange(array);
			}
		}
		if (this.class586_0 != null)
		{
			DataRow[] array2 = class548_0.tblAbnAplForDisconObjects.Select(null, null, DataViewRowState.Deleted);
			if (array2 != null && array2.Length != 0)
			{
				num += this.class586_0.vmethod_15(array2);
				list_0.AddRange(array2);
			}
		}
		if (this.class585_0 != null)
		{
			DataRow[] array3 = class548_0.tblAbnAplForDiscon.Select(null, null, DataViewRowState.Deleted);
			if (array3 != null && array3.Length != 0)
			{
				num += this.class585_0.vmethod_19(array3);
				list_0.AddRange(array3);
			}
		}
		if (this.class587_0 != null)
		{
			DataRow[] array4 = class548_0.tblAbnAplForDisconReason.Select(null, null, DataViewRowState.Deleted);
			if (array4 != null && array4.Length != 0)
			{
				num += this.class587_0.vmethod_5(array4);
				list_0.AddRange(array4);
			}
		}
		if (this.class598_0 != null)
		{
			DataRow[] array5 = class548_0.tR_Worker.Select(null, null, DataViewRowState.Deleted);
			if (array5 != null && array5.Length != 0)
			{
				num += this.class598_0.vmethod_7(array5);
				list_0.AddRange(array5);
			}
		}
		if (this.class594_0 != null)
		{
			DataRow[] array6 = class548_0.tblAbnAplConnectPointForIndividualUsers.Select(null, null, DataViewRowState.Deleted);
			if (array6 != null && array6.Length != 0)
			{
				num += this.class594_0.vmethod_5(array6);
				list_0.AddRange(array6);
			}
		}
		return num;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	private DataRow[] method_3(DataRow[] dataRow_0, List<DataRow> list_0)
	{
		if (dataRow_0 == null || dataRow_0.Length < 1)
		{
			return dataRow_0;
		}
		if (list_0 != null && list_0.Count >= 1)
		{
			List<DataRow> list = new List<DataRow>();
			foreach (DataRow item in dataRow_0)
			{
				if (!list_0.Contains(item))
				{
					list.Add(item);
				}
			}
			return list.ToArray();
		}
		return dataRow_0;
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	public virtual int vmethod_0(Class548 class548_0)
	{
		if (class548_0 == null)
		{
			throw new ArgumentNullException("dataSet");
		}
		if (!class548_0.HasChanges())
		{
			return 0;
		}
		if (this.class585_0 != null && !this.vmethod_2(this.class585_0.SqlConnection_0))
		{
			throw new ArgumentException("Все адаптеры таблицы, управляемые диспетчером адаптера таблицы TableAdapterManager, должны использовать одинаковую строку подключения.");
		}
		if (this.class586_0 != null && !this.vmethod_2(this.class586_0.SqlConnection_0))
		{
			throw new ArgumentException("Все адаптеры таблицы, управляемые диспетчером адаптера таблицы TableAdapterManager, должны использовать одинаковую строку подключения.");
		}
		if (this.class587_0 != null && !this.vmethod_2(this.class587_0.SqlConnection_0))
		{
			throw new ArgumentException("Все адаптеры таблицы, управляемые диспетчером адаптера таблицы TableAdapterManager, должны использовать одинаковую строку подключения.");
		}
		if (this.class590_0 != null && !this.vmethod_2(this.class590_0.SqlConnection_0))
		{
			throw new ArgumentException("Все адаптеры таблицы, управляемые диспетчером адаптера таблицы TableAdapterManager, должны использовать одинаковую строку подключения.");
		}
		if (this.class594_0 != null && !this.vmethod_2(this.class594_0.SqlConnection_0))
		{
			throw new ArgumentException("Все адаптеры таблицы, управляемые диспетчером адаптера таблицы TableAdapterManager, должны использовать одинаковую строку подключения.");
		}
		if (this.class598_0 != null && !this.vmethod_2(this.class598_0.SqlConnection_0))
		{
			throw new ArgumentException("Все адаптеры таблицы, управляемые диспетчером адаптера таблицы TableAdapterManager, должны использовать одинаковую строку подключения.");
		}
		IDbConnection dbConnection = this.IDbConnection_0;
		if (dbConnection == null)
		{
			throw new ApplicationException("TableAdapterManager не содержит сведений о подключении. Укажите для каждого адаптера таблицы TableAdapterManager допустимый экземпляр адаптера таблицы.");
		}
		bool flag = false;
		if ((dbConnection.State & ConnectionState.Broken) == ConnectionState.Broken)
		{
			dbConnection.Close();
		}
		if (dbConnection.State == ConnectionState.Closed)
		{
			dbConnection.Open();
			flag = true;
		}
		IDbTransaction dbTransaction = dbConnection.BeginTransaction();
		if (dbTransaction == null)
		{
			throw new ApplicationException("Не удается начать транзакцию. Текущее соединение данных не поддерживает транзакции или текущее состояние не позволяет начать транзакцию.");
		}
		List<DataRow> list = new List<DataRow>();
		List<DataRow> list2 = new List<DataRow>();
		List<DataAdapter> list3 = new List<DataAdapter>();
		Dictionary<object, IDbConnection> dictionary = new Dictionary<object, IDbConnection>();
		int num = 0;
		DataSet dataSet = null;
		if (this.Boolean_0)
		{
			dataSet = new DataSet();
			dataSet.Merge(class548_0);
		}
		try
		{
			if (this.class585_0 != null)
			{
				dictionary.Add(this.class585_0, this.class585_0.SqlConnection_0);
				this.class585_0.SqlConnection_0 = (SqlConnection)dbConnection;
				this.class585_0.SqlTransaction_0 = (SqlTransaction)dbTransaction;
				if (this.class585_0.SqlDataAdapter_0.AcceptChangesDuringUpdate)
				{
					this.class585_0.SqlDataAdapter_0.AcceptChangesDuringUpdate = false;
					list3.Add(this.class585_0.SqlDataAdapter_0);
				}
			}
			if (this.class586_0 != null)
			{
				dictionary.Add(this.class586_0, this.class586_0.SqlConnection_0);
				this.class586_0.SqlConnection_0 = (SqlConnection)dbConnection;
				this.class586_0.SqlTransaction_0 = (SqlTransaction)dbTransaction;
				if (this.class586_0.SqlDataAdapter_0.AcceptChangesDuringUpdate)
				{
					this.class586_0.SqlDataAdapter_0.AcceptChangesDuringUpdate = false;
					list3.Add(this.class586_0.SqlDataAdapter_0);
				}
			}
			if (this.class587_0 != null)
			{
				dictionary.Add(this.class587_0, this.class587_0.SqlConnection_0);
				this.class587_0.SqlConnection_0 = (SqlConnection)dbConnection;
				this.class587_0.SqlTransaction_0 = (SqlTransaction)dbTransaction;
				if (this.class587_0.SqlDataAdapter_0.AcceptChangesDuringUpdate)
				{
					this.class587_0.SqlDataAdapter_0.AcceptChangesDuringUpdate = false;
					list3.Add(this.class587_0.SqlDataAdapter_0);
				}
			}
			if (this.class590_0 != null)
			{
				dictionary.Add(this.class590_0, this.class590_0.SqlConnection_0);
				this.class590_0.SqlConnection_0 = (SqlConnection)dbConnection;
				this.class590_0.SqlTransaction_0 = (SqlTransaction)dbTransaction;
				if (this.class590_0.SqlDataAdapter_0.AcceptChangesDuringUpdate)
				{
					this.class590_0.SqlDataAdapter_0.AcceptChangesDuringUpdate = false;
					list3.Add(this.class590_0.SqlDataAdapter_0);
				}
			}
			if (this.class594_0 != null)
			{
				dictionary.Add(this.class594_0, this.class594_0.SqlConnection_0);
				this.class594_0.SqlConnection_0 = (SqlConnection)dbConnection;
				this.class594_0.SqlTransaction_0 = (SqlTransaction)dbTransaction;
				if (this.class594_0.SqlDataAdapter_0.AcceptChangesDuringUpdate)
				{
					this.class594_0.SqlDataAdapter_0.AcceptChangesDuringUpdate = false;
					list3.Add(this.class594_0.SqlDataAdapter_0);
				}
			}
			if (this.class598_0 != null)
			{
				dictionary.Add(this.class598_0, this.class598_0.SqlConnection_0);
				this.class598_0.SqlConnection_0 = (SqlConnection)dbConnection;
				this.class598_0.SqlTransaction_0 = (SqlTransaction)dbTransaction;
				if (this.class598_0.SqlDataAdapter_0.AcceptChangesDuringUpdate)
				{
					this.class598_0.SqlDataAdapter_0.AcceptChangesDuringUpdate = false;
					list3.Add(this.class598_0.SqlDataAdapter_0);
				}
			}
			if (this.Enum23_0 == (Class600.Enum23)1)
			{
				num += this.method_0(class548_0, list, list2);
				num += this.method_1(class548_0, list2);
			}
			else
			{
				num += this.method_1(class548_0, list2);
				num += this.method_0(class548_0, list, list2);
			}
			num += this.method_2(class548_0, list);
			dbTransaction.Commit();
			if (0 < list2.Count)
			{
				DataRow[] array = new DataRow[list2.Count];
				list2.CopyTo(array);
				for (int i = 0; i < array.Length; i++)
				{
					array[i].AcceptChanges();
				}
			}
			if (0 < list.Count)
			{
				DataRow[] array2 = new DataRow[list.Count];
				list.CopyTo(array2);
				for (int j = 0; j < array2.Length; j++)
				{
					array2[j].AcceptChanges();
				}
			}
		}
		catch (Exception ex)
		{
			dbTransaction.Rollback();
			if (this.Boolean_0)
			{
				class548_0.Clear();
				class548_0.Merge(dataSet);
			}
			else if (0 < list2.Count)
			{
				DataRow[] array3 = new DataRow[list2.Count];
				list2.CopyTo(array3);
				foreach (DataRow dataRow in array3)
				{
					dataRow.AcceptChanges();
					dataRow.SetAdded();
				}
			}
			throw ex;
		}
		finally
		{
			if (flag)
			{
				dbConnection.Close();
			}
			if (this.class585_0 != null)
			{
				this.class585_0.SqlConnection_0 = (SqlConnection)dictionary[this.class585_0];
				this.class585_0.SqlTransaction_0 = null;
			}
			if (this.class586_0 != null)
			{
				this.class586_0.SqlConnection_0 = (SqlConnection)dictionary[this.class586_0];
				this.class586_0.SqlTransaction_0 = null;
			}
			if (this.class587_0 != null)
			{
				this.class587_0.SqlConnection_0 = (SqlConnection)dictionary[this.class587_0];
				this.class587_0.SqlTransaction_0 = null;
			}
			if (this.class590_0 != null)
			{
				this.class590_0.SqlConnection_0 = (SqlConnection)dictionary[this.class590_0];
				this.class590_0.SqlTransaction_0 = null;
			}
			if (this.class594_0 != null)
			{
				this.class594_0.SqlConnection_0 = (SqlConnection)dictionary[this.class594_0];
				this.class594_0.SqlTransaction_0 = null;
			}
			if (this.class598_0 != null)
			{
				this.class598_0.SqlConnection_0 = (SqlConnection)dictionary[this.class598_0];
				this.class598_0.SqlTransaction_0 = null;
			}
			if (0 < list3.Count)
			{
				DataAdapter[] array4 = new DataAdapter[list3.Count];
				list3.CopyTo(array4);
				for (int l = 0; l < array4.Length; l++)
				{
					array4[l].AcceptChangesDuringUpdate = true;
				}
			}
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	protected virtual void vmethod_1(DataRow[] dataRow_0, DataRelation dataRelation_0, bool bool_1)
	{
		Array.Sort<DataRow>(dataRow_0, new Class600.Class601(dataRelation_0, bool_1));
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	[DebuggerNonUserCode]
	protected virtual bool vmethod_2(IDbConnection idbConnection_1)
	{
		return this.idbConnection_0 != null || this.IDbConnection_0 == null || idbConnection_1 == null || string.Equals(this.IDbConnection_0.ConnectionString, idbConnection_1.ConnectionString, StringComparison.Ordinal);
	}

	public Class600()
	{
		
		
	}

	private Class600.Enum23 enum23_0;

	private Class585 class585_0;

	private Class586 class586_0;

	private Class587 class587_0;

	private Class590 class590_0;

	private Class594 class594_0;

	private Class598 class598_0;

	private bool bool_0;

	private IDbConnection idbConnection_0;

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public enum Enum23
	{

	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	private class Class601 : IComparer<DataRow>
	{
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal Class601(DataRelation dataRelation_1, bool bool_0)
		{
			
			
			this.dataRelation_0 = dataRelation_1;
			if (bool_0)
			{
				this.int_0 = -1;
				return;
			}
			this.int_0 = 1;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private DataRow method_0(DataRow dataRow_0, out int int_1)
		{
			DataRow result = dataRow_0;
			int_1 = 0;
			IDictionary<DataRow, DataRow> dictionary = new Dictionary<DataRow, DataRow>();
			dictionary[dataRow_0] = dataRow_0;
			DataRow parentRow = dataRow_0.GetParentRow(this.dataRelation_0, DataRowVersion.Default);
			while (parentRow != null && !dictionary.ContainsKey(parentRow))
			{
				int_1++;
				result = parentRow;
				dictionary[parentRow] = parentRow;
				parentRow = parentRow.GetParentRow(this.dataRelation_0, DataRowVersion.Default);
			}
			if (int_1 == 0)
			{
				dictionary.Clear();
				dictionary[dataRow_0] = dataRow_0;
				parentRow = dataRow_0.GetParentRow(this.dataRelation_0, DataRowVersion.Original);
				while (parentRow != null && !dictionary.ContainsKey(parentRow))
				{
					int_1++;
					result = parentRow;
					dictionary[parentRow] = parentRow;
					parentRow = parentRow.GetParentRow(this.dataRelation_0, DataRowVersion.Original);
				}
			}
			return result;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[DebuggerNonUserCode]
		public int Compare(DataRow x, DataRow y)
		{
			if (x == y)
			{
				return 0;
			}
			if (x == null)
			{
				return -1;
			}
			if (y == null)
			{
				return 1;
			}
			int num = 0;
			DataRow dataRow = this.method_0(x, out num);
			int value = 0;
			DataRow dataRow2 = this.method_0(y, out value);
			if (dataRow == dataRow2)
			{
				return this.int_0 * num.CompareTo(value);
			}
			if (dataRow.Table.Rows.IndexOf(dataRow) < dataRow2.Table.Rows.IndexOf(dataRow2))
			{
				return -1;
			}
			return 1;
		}

		private DataRelation dataRelation_0;

		private int int_0;
	}
}
