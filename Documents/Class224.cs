using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DataSql;
using Microsoft.Office.Interop.Excel;

internal class Class224
{
	internal static void smethod_0(SQLSettings sqlsettings_0)
	{
		Class224.dataTable_0 = null;
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = "Excel Files(.xls)|*.xls|\r\n                Excel Files(.xlsx)|*.xlsx| Excel Files(*.xlsm)|*.xlsm";
		openFileDialog.Multiselect = true;
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			Class224.smethod_3(sqlsettings_0);
			string[] fileNames = openFileDialog.FileNames;
			for (int i = 0; i < fileNames.Length; i++)
			{
				Class225 @class = Class224.smethod_2(fileNames[i]);
				if (@class != null)
				{
					Class224.smethod_1(sqlsettings_0, @class);
				}
			}
		}
	}

	private static void smethod_1(SQLSettings sqlsettings_0, Class225 class225_0)
	{
		foreach (string text in class225_0.dictionary_0.Keys)
		{
			foreach (string text2 in class225_0.dictionary_0[text])
			{
				Class171 @class = new Class171();
				DataRow dataRow = @class.tJ_Damage.NewRow();
				dataRow["TypeDoc"] = 1403;
				dataRow["dateDoc"] = class225_0.dateTime_0;
				if (Class224.dataTable_0 != null)
				{
					DataRow[] array = Class224.dataTable_0.Select("FIO like '%" + class225_0.string_0.Trim() + "%'");
					if (array.Length != 0)
					{
						dataRow["idCompiler"] = array[0]["id"];
						dataRow["idDivision"] = array[0]["idGRoup"];
					}
				}
				if (!(text == "1 СЕТЕВОЙ РАЙОН"))
				{
					if (!(text == "2 СЕТЕВОЙ РАЙОН"))
					{
						if (!(text == "3 СЕТЕВОЙ РАЙОН"))
						{
							if (!(text == "4 СЕТЕВОЙ РАЙОН"))
							{
								if (text == "ПРОИЗВОДСТВЕННАЯ ЛАБОРАТОРИЯ")
								{
									dataRow["isLaboratory"] = true;
								}
							}
							else
							{
								dataRow["idDivisionApply"] = 1434;
							}
						}
						else
						{
							dataRow["idDivisionApply"] = 1433;
						}
					}
					else
					{
						dataRow["idDivisionApply"] = 1432;
					}
				}
				else
				{
					dataRow["idDivisionApply"] = 1431;
				}
				dataRow["DivisionInstruction"] = text2.Trim();
				@class.tJ_Damage.Rows.Add(dataRow);
				SqlDataCommand sqlDataCommand = new SqlDataCommand(sqlsettings_0);
				int num = sqlDataCommand.InsertSqlDataOneRow(@class.tJ_Damage);
				if (num > 0)
				{
					sqlDataCommand.SelectSqlData(@class.tJ_Damage, true, "where id =" + num.ToString(), null, false, 0);
					if (@class.tJ_Damage.Rows.Count > 0)
					{
						@class.tJ_Damage.Rows[0]["numRequest"] = @class.tJ_Damage.Rows[0]["numDoc"].ToString();
						@class.tJ_Damage.Rows[0].EndEdit();
						sqlDataCommand.UpdateSqlData(@class, @class.tJ_Damage);
					}
				}
			}
		}
	}

	private static Class225 smethod_2(string string_0)
	{
		DateTime? dateTime = null;
		string string_ = "";
		Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
		try
		{
			Microsoft.Office.Interop.Excel.Application application = new ApplicationClass();
			application.Visible = true;
			Workbook workbook = application.Workbooks.Open(string_0, 0, false, 5, "", "", false, XlPlatform.xlWindows, "", true, false, 0, true, false, false);
			try
			{
				Range usedRange = ((Worksheet)workbook.ActiveSheet).UsedRange;
				string value = (usedRange.Cells[7, 5] as Range).get_Value(Type.Missing).ToString();
				dateTime = new DateTime?(Convert.ToDateTime(value));
				string text = "";
				for (int i = 12; i <= usedRange.Rows.Count; i++)
				{
					if ((usedRange.Cells[i, 2] as Range).get_Value(Type.Missing) != null && !string.IsNullOrEmpty((usedRange.Cells[i, 2] as Range).get_Value(Type.Missing).ToString()))
					{
						text = (usedRange.Cells[i, 2] as Range).get_Value(Type.Missing).ToString();
						if (text.ToUpper().Contains("РАПОРТ") && text.ToUpper().Contains("СОСТАВИЛ"))
						{
							if ((usedRange.Cells[i, 5] as Range).get_Value(Type.Missing) != null)
							{
								string_ = (usedRange.Cells[i, 5] as Range).get_Value(Type.Missing).ToString();
							}
							break;
						}
					}
					else if (!string.IsNullOrEmpty(text))
					{
						if (!dictionary.ContainsKey(text))
						{
							dictionary.Add(text, new List<string>());
						}
						if ((usedRange.Cells[i, 1] as Range).get_Value(Type.Missing) != null)
						{
							string text2 = (usedRange.Cells[i, 1] as Range).get_Value(Type.Missing).ToString();
							if (!string.IsNullOrEmpty(text2))
							{
								if (text2.IndexOf(".") > 0)
								{
									bool flag = true;
									int j = 0;
									while (j < text2.IndexOf("."))
									{
										if (char.IsDigit(text2[j]))
										{
											j++;
										}
										else
										{
											flag = false;
											IL_26F:
											if (flag)
											{
												dictionary[text].Add(text2.Substring(text2.IndexOf(".") + 1));
												goto IL_346;
											}
											if (dictionary[text].Count > 0)
											{
												List<string> list = dictionary[text];
												int index = dictionary[text].Count - 1;
												list[index] += text2;
												goto IL_346;
											}
											dictionary[text].Add(text2);
											goto IL_346;
										}
									}
									goto IL_26F;
								}
								if (dictionary[text].Count > 0)
								{
									List<string> list = dictionary[text];
									int index = dictionary[text].Count - 1;
									list[index] += text2;
								}
								else
								{
									dictionary[text].Add(text2);
								}
							}
						}
					}
					IL_346:;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, string_0);
			}
			finally
			{
				workbook.Close(Type.Missing, Type.Missing, Type.Missing);
				application.Quit();
			}
		}
		catch
		{
		}
		if (dateTime == null)
		{
			return null;
		}
		return new Class225(dateTime.Value, string_, dictionary);
	}

	private static void smethod_3(SQLSettings sqlsettings_0)
	{
		DataSet dataSet = new DataSet();
		Class224.dataTable_0 = new System.Data.DataTable("vWorkerGroup");
		Class224.dataTable_0.Columns.Add("id", typeof(int));
		Class224.dataTable_0.Columns.Add("FIO", typeof(string));
		Class224.dataTable_0.Columns.Add("idGroup", typeof(int));
		SqlDataCommand sqlDataCommand = new SqlDataCommand(sqlsettings_0);
		dataSet.Tables.Add(Class224.dataTable_0);
		sqlDataCommand.SelectSqlData(Class224.dataTable_0, true, "where ParentKey like ';GroupWorker;DailyReport;%' and dateEnd is null order by fio ", null, false, 0);
	}

	public Class224()
	{
		
		
	}

	private static System.Data.DataTable dataTable_0;
}
