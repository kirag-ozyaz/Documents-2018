using System;
using System.Data;

namespace Documents
{
	public class Cache
	{
		public Cache(GInterface0 dataSupplier, int rowsPerPage)
		{
			
			
			this.ginterface0_0 = dataSupplier;
			Cache.int_0 = rowsPerPage;
			this.method_1();
		}

		private bool method_0(int int_1, int int_2, ref string string_0)
		{
			if (this.method_4(0, int_1))
			{
				string_0 = this.dataPage_0[0].table.Rows[int_1 % Cache.int_0][int_2].ToString();
				return true;
			}
			if (this.method_4(1, int_1))
			{
				string_0 = this.dataPage_0[1].table.Rows[int_1 % Cache.int_0][int_2].ToString();
				return true;
			}
			return false;
		}

		public string RetrieveElement(int rowIndex, int columnIndex)
		{
			string result = null;
			if (this.method_0(rowIndex, columnIndex, ref result))
			{
				return result;
			}
			return this.method_2(rowIndex, columnIndex);
		}

		private void method_1()
		{
			this.dataPage_0 = new Cache.DataPage[]
			{
				new Cache.DataPage(this.ginterface0_0.SupplyPageOfData(Cache.DataPage.MapToLowerBoundary(0), Cache.int_0), 0),
				new Cache.DataPage(this.ginterface0_0.SupplyPageOfData(Cache.DataPage.MapToLowerBoundary(Cache.int_0), Cache.int_0), Cache.int_0)
			};
		}

		private string method_2(int int_1, int int_2)
		{
			DataTable table = this.ginterface0_0.SupplyPageOfData(Cache.DataPage.MapToLowerBoundary(int_1), Cache.int_0);
			this.dataPage_0[this.method_3(int_1)] = new Cache.DataPage(table, int_1);
			return this.RetrieveElement(int_1, int_2);
		}

		private int method_3(int int_1)
		{
			if (int_1 > this.dataPage_0[0].HighestIndex && int_1 > this.dataPage_0[1].HighestIndex)
			{
				int num = int_1 - this.dataPage_0[0].HighestIndex;
				int num2 = int_1 - this.dataPage_0[1].HighestIndex;
				if (num < num2)
				{
					return 1;
				}
				return 0;
			}
			else
			{
				int num3 = this.dataPage_0[0].LowestIndex - int_1;
				int num4 = this.dataPage_0[1].LowestIndex - int_1;
				if (num3 < num4)
				{
					return 1;
				}
				return 0;
			}
		}

		private bool method_4(int int_1, int int_2)
		{
			return int_2 <= this.dataPage_0[int_1].HighestIndex && int_2 >= this.dataPage_0[int_1].LowestIndex;
		}

		private static int int_0;

		private Cache.DataPage[] dataPage_0;

		private GInterface0 ginterface0_0;

		public struct DataPage
		{
			public DataPage(DataTable table, int rowIndex)
			{
				
				this.table = table;
				this.int_0 = Cache.DataPage.MapToLowerBoundary(rowIndex);
				this.int_1 = Cache.DataPage.gmgCcwbMuyp(rowIndex);
			}

			public int LowestIndex
			{
				get
				{
					return this.int_0;
				}
			}

			public int HighestIndex
			{
				get
				{
					return this.int_1;
				}
			}

			public static int MapToLowerBoundary(int rowIndex)
			{
				return rowIndex / Cache.int_0 * Cache.int_0;
			}

			private static int gmgCcwbMuyp(int int_2)
			{
				return Cache.DataPage.MapToLowerBoundary(int_2) + Cache.int_0 - 1;
			}

			public DataTable table;

			private int int_0;

			private int int_1;
		}
	}
}
