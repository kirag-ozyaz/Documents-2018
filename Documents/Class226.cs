using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Constants;
using DataSql;

internal class Class226
{
	internal static void smethod_0(SQLSettings sqlsettings_0, SQLSettings sqlsettings_1)
	{
		Class226.rixComJilu2 = null;
		Class226.dataTable_1 = null;
		Class226.dataTable_2 = null;
		Class226.dataTable_3 = null;
		Class226.dataTable_4 = null;
		Class226.hxxCoMmTsvu = null;
		Class226.smethod_2(sqlsettings_0);
		using (SqlConnection sqlConnection = new SqlConnection(sqlsettings_1.GetConnectionString()))
		{
			sqlConnection.Open();
			using (SqlConnection sqlConnection2 = new SqlConnection(sqlsettings_0.GetConnectionString()))
			{
				sqlConnection2.Open();
				SqlCommand sqlCommand = new SqlCommand();
				sqlCommand.CommandTimeout = 0;
				sqlCommand.Connection = sqlConnection;
				sqlCommand.CommandText = "select * from [Низкое]";
				sqlCommand.CommandText += " where [Дата] < '20151012'";
				sqlCommand.CommandText += " order by [Дата]";
				DbDataAdapter dbDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				dbDataAdapter.Fill(dataTable);
				SqlCommand sqlCommand2 = new SqlCommand();
				sqlCommand2.Connection = sqlConnection2;
				int num = 0;
				foreach (object obj in dataTable.Rows)
				{
					DataRow dataRow = (DataRow)obj;
					num++;
					Class171 @class = new Class171();
					DataRow dataRow2 = @class.tJ_Damage.NewRow();
					if (sqlsettings_1.DBName == "SR")
					{
						dataRow2["idDivision"] = 1405;
					}
					if (sqlsettings_1.DBName == "SR4")
					{
						dataRow2["idDivision"] = 1406;
					}
					dataRow2["TypeDoc"] = 1401;
					dataRow2["numRequest"] = dataRow["индекс"];
					DateTime? dateTime = null;
					if (dataRow["Дата"] != DBNull.Value)
					{
						dateTime = new DateTime?(Convert.ToDateTime(dataRow["Дата"]).Date);
						if (dataRow["Время1"] != DBNull.Value)
						{
							dateTime += Convert.ToDateTime(dataRow["Время1"]).TimeOfDay;
						}
						dataRow2["dateDoc"] = dateTime;
						dataRow2["dateOwner"] = dateTime;
						string text = Class226.smethod_10(sqlsettings_1, dateTime.Value);
						if (!string.IsNullOrEmpty(text))
						{
							int? num2 = Class226.smethod_9(sqlsettings_0, text);
							if (num2 != null)
							{
								dataRow2["idCompiler"] = num2;
								int? num3 = Class226.smethod_11(sqlsettings_0, num2.Value);
								if (num3 != null)
								{
									dataRow2["idOwner"] = num3;
								}
							}
						}
					}
					string value = "";
					int? num4 = null;
					if (dataRow["Улица"] != DBNull.Value && dataRow["Дом"] != DBNull.Value)
					{
						string text2 = dataRow["Улица"].ToString();
						text2 = Class226.smethod_6(text2);
						text2 = Regex.Replace(text2, "[.]", "");
						if (!(text2 == "Л.Шевцовой"))
						{
						}
						DataTable dataTable2 = Class226.smethod_3(sqlCommand2, string.Format("select * from tr_kladrstreet where KladrObjId = 24 and ((name + ' ' + socr)  = '{0}'\r\n                                                                                    or replace(name, '1-й', '1')+' ' + socr = '{0}' \r\n                                                                                    or replace(name, '2-й', '2')+' ' + socr = '{0}' \r\n                                                                                    or replace(name, '3-й', '3')+' ' + socr = '{0}' \r\n                                                                                    or replace(name, '5-й', '5')+' ' + socr = '{0}' \r\n                                                                                    or replace(name, '4-й', '4')+' ' + socr = '{0}') ", text2));
						if (dataTable2.Rows.Count > 0)
						{
							Class226.smethod_5(sqlsettings_0, dataTable2, dataRow, out value, out num4);
						}
						else
						{
							dataTable2 = Class226.smethod_3(sqlCommand2, "select * from tr_kladrstreet where KladrObjId = 24 and name  = '" + text2 + "' and socr = 'ул'");
							if (dataTable2.Rows.Count > 0)
							{
								Class226.smethod_5(sqlsettings_0, dataTable2, dataRow, out value, out num4);
							}
							else
							{
								dataTable2 = Class226.smethod_3(sqlCommand2, "select * from tr_kladrstreet where KladrObjId = 24 and name  = '" + text2 + "'");
								if (dataTable2.Rows.Count > 0)
								{
									Class226.smethod_5(sqlsettings_0, dataTable2, dataRow, out value, out num4);
								}
								else
								{
									value = dataRow["Улица"].ToString() + " " + dataRow["Дом"].ToString();
								}
							}
						}
					}
					else
					{
						if (dataRow["Улица"] != DBNull.Value)
						{
							value = dataRow["Улица"].ToString();
						}
						if (dataRow["Дом"] != DBNull.Value)
						{
							value = dataRow["Дом"].ToString();
						}
					}
					if (num4 != null)
					{
						dataRow2["idMAp"] = num4;
					}
					if (!string.IsNullOrEmpty(value))
					{
						dataRow2["DEfectLocation"] = value;
					}
					if (dataRow["№ТП"] != DBNull.Value)
					{
						int? num5 = Class226.smethod_7(sqlsettings_0, dataRow["№ТП"].ToString());
						if (num5 != null)
						{
							dataRow2["idSchmObj"] = num5;
						}
						else if (dataRow2["DEfectLocation"] == DBNull.Value)
						{
							dataRow2["DEfectLocation"] = dataRow["№ТП"].ToString();
						}
						else
						{
							dataRow2["DEfectLocation"] = dataRow2["DEfectLocation"].ToString() + "\r\n" + dataRow["№ТП"].ToString();
						}
					}
					if (dataRow["Заявка"] != DBNull.Value)
					{
						int? num6 = Class226.smethod_8(sqlsettings_0, dataRow["Заявка"].ToString());
						if (num6 != null)
						{
							dataRow2["idReason"] = num6;
						}
						else if (dataRow2["DEfectLocation"] == DBNull.Value)
						{
							dataRow2["DEfectLocation"] = dataRow["Заявка"].ToString();
						}
						else
						{
							dataRow2["DEfectLocation"] = dataRow2["DEfectLocation"].ToString() + "\r\n" + dataRow["Заявка"].ToString();
						}
					}
					if (dataRow["ДатаИ"] != DBNull.Value)
					{
						DateTime d = Convert.ToDateTime(dataRow["ДатаИ"]).Date;
						if (dataRow["Время2"] != DBNull.Value)
						{
							d += Convert.ToDateTime(dataRow["Время2"]).TimeOfDay;
						}
						dataRow2["dateApply"] = dateTime;
						dataRow2["isApply"] = true;
					}
					if (dataRow["Флажок"] != DBNull.Value)
					{
						dataRow2["ComletedWorkText"] = dataRow["Флажок"];
					}
					if (dataRow["Исполнитель"] != DBNull.Value)
					{
						int? num7 = Class226.smethod_9(sqlsettings_0, dataRow["Исполнитель"].ToString());
						if (num7 != null)
						{
							dataRow2["idWorkerApply"] = num7;
						}
					}
					if (dataRow["Код"] != DBNull.Value)
					{
						int? num8 = Class226.smethod_12(sqlsettings_0, dataRow["Код"].ToString());
						if (num8 != null)
						{
							dataRow2["idREasonPTS"] = num8;
						}
					}
					@class.tJ_Damage.Rows.Add(dataRow2);
					int num9 = new SqlDataCommand(sqlsettings_0).InsertSqlDataOneRow(@class.tJ_Damage);
					if (num9 > 0 && dataRow["Причина"] != DBNull.Value && dataRow["Причина"].ToString() != "" && Convert.ToInt32(dataRow["Причина"]) > 0)
					{
						Class226.smethod_1(num9, Convert.ToInt32(dataRow["Причина"]), sqlsettings_0);
					}
				}
			}
		}
	}

	private static void smethod_1(int int_0, int int_1, SQLSettings sqlsettings_0)
	{
		Class171 @class = new Class171();
		DataRow dataRow = @class.tJ_DamageCharacter.NewRow();
		dataRow["idDamage"] = int_0;
		string text = int_1.ToString();
		if (text.Length > 0)
		{
			DataRow[] array = Class226.dataTable_0.Select(string.Format("ParentKey = ';REportDaily;NatureDamage;LV;Code{0};'", text[0]));
			if (array.Length != 0)
			{
				dataRow["col1"] = array[0]["id"];
			}
		}
		if (text.Length > 1)
		{
			DataRow[] array2 = Class226.dataTable_0.Select(string.Format("ParentKey = ';REportDaily;NatureDamage;LV;Code{0};Code{1};'", text[0], text[1]));
			if (array2.Length != 0)
			{
				dataRow["col2"] = array2[0]["id"];
			}
		}
		if (text.Length > 2)
		{
			DataRow[] array3 = Class226.dataTable_0.Select(string.Format("ParentKey = ';REportDaily;NatureDamage;LV;Code{0};Code{1};Code{2};'", text[0], text[1], text[2]));
			if (array3.Length != 0)
			{
				dataRow["col3"] = array3[0]["id"];
			}
		}
		@class.tJ_DamageCharacter.Rows.Add(dataRow);
		new SqlDataCommand(sqlsettings_0).InsertSqlData(@class, @class.tJ_DamageCharacter);
	}

	private static void smethod_2(SQLSettings sqlsettings_0)
	{
		Class226.dataTable_0 = new SqlDataCommand(sqlsettings_0).SelectSqlData("tR_Classifier", true, "where  parentKey like ';REportDaily;NatureDamage;LV;%'", null);
	}

	private static DataTable smethod_3(SqlCommand sqlCommand_0, string string_0)
	{
		DataTable result;
		try
		{
			sqlCommand_0.CommandText = string_0;
			DbDataAdapter dbDataAdapter = new SqlDataAdapter(sqlCommand_0);
			DataTable dataTable = new DataTable();
			dbDataAdapter.Fill(dataTable);
			result = dataTable;
		}
		catch
		{
			result = Class226.smethod_3(sqlCommand_0, string_0);
		}
		return result;
	}

	private static int smethod_4(SQLSettings sqlsettings_0, int int_0, int int_1, string string_0)
	{
		Class171 @class = new Class171();
		SqlDataCommand sqlDataCommand = new SqlDataCommand(sqlsettings_0);
		string text = string.IsNullOrEmpty(string_0) ? " and HousePrefix is null " : (" and HousePrefix = '" + string_0 + "'");
		sqlDataCommand.SelectSqlData(@class.tMapObj, true, string.Concat(new string[]
		{
			"where Street = ",
			int_0.ToString(),
			" and House = ",
			int_1.ToString(),
			text,
			" and IsHouse = 1 and Name is null"
		}), null, false, 0);
		if (@class.tMapObj.Rows.Count > 0)
		{
			return Convert.ToInt32(@class.tMapObj.Rows[0]["idMap"]);
		}
		DataRow dataRow = @class.tMapObj.NewRow();
		dataRow["Street"] = int_0;
		dataRow["House"] = int_1;
		if (!string.IsNullOrEmpty(string_0))
		{
			dataRow["HousePrefix"] = string_0;
		}
		dataRow["IsHouse"] = true;
		dataRow["Deleted"] = 0;
		@class.tMapObj.Rows.Add(dataRow);
		@class.tMapObj.Rows[0].EndEdit();
		return sqlDataCommand.InsertSqlDataOneRow(@class.tMapObj);
	}

	private static void smethod_5(SQLSettings sqlsettings_0, DataTable dataTable_5, DataRow dataRow_0, out string string_0, out int? nullable_0)
	{
		nullable_0 = null;
		string_0 = "";
		string text = dataRow_0["Дом"].ToString();
		if (string.IsNullOrEmpty(text))
		{
			string_0 = dataRow_0["Улица"].ToString();
			return;
		}
		if (!char.IsDigit(text[0]))
		{
			string_0 = dataRow_0["Улица"].ToString() + " " + text;
			return;
		}
		int num = text.Length - 1;
		int i = 0;
		while (i < text.Length)
		{
			if (char.IsDigit(text[i]))
			{
				i++;
			}
			else
			{
				num = i - 1;
				IL_9B:
				int int_ = Convert.ToInt32(text.Substring(0, num + 1));
				if (text.Length - 1 > num && text.Length - num <= 3)
				{
					string string_ = text.Substring(num + 1);
					nullable_0 = new int?(Class226.smethod_4(sqlsettings_0, Convert.ToInt32(dataTable_5.Rows[0]["id"]), int_, string_));
					return;
				}
				nullable_0 = new int?(Class226.smethod_4(sqlsettings_0, Convert.ToInt32(dataTable_5.Rows[0]["id"]), int_, ""));
				string_0 = text.Substring(num + 1);
				return;
			}
		}
		goto IL_9B;
	}

	private static string smethod_6(string string_0)
	{
		string_0 = string_0.Replace("Л.Шевцовой", "Любови Шевцовой");
		string_0 = string_0.Replace("Б.Хмельницкого", "Богдана Хмельницкого");
		string_0 = string_0.Replace("1 Зап. пригоpод", "Западный Пригород 1-я");
		string_0 = string_0.Replace("1 Зап. Пригоpод", "Западный Пригород 1-я");
		string_0 = string_0.Replace("Халтурина спуск", "Спуск Халтурина");
		string_0 = string_0.Replace("Фруктовая 1", "Фруктовая");
		string_0 = string_0.Replace("У.Громовой", "Ульяны Громовой");
		string_0 = string_0.Replace("9-го Мая", "9 Мая");
		string_0 = string_0.Replace("З.Космодемьянской", "Зои Космодемьянской");
		string_0 = string_0.Replace("Л.Толстого", "Льва Толстого");
		string_0 = string_0.Replace("Матросова", "Александра Матросова");
		string_0 = string_0.Replace("Наб.р.симбирки", "Набережная реки Симбирки");
		string_0 = string_0.Replace("К.Маркса", "Карла Маркса");
		string_0 = string_0.Replace("Нариманова просп.", "Нариманова пр-кт");
		string_0 = string_0.Replace("Ново свияжск.пригород", "Новосвияжский Пригород");
		string_0 = string_0.Replace("Верхне Полевая", "Верхнеполевая");
		string_0 = string_0.Replace("Вр.Михайлова", "Врача Михайлова");
		string_0 = string_0.Replace("Д.Ульянова", "Дмитрия Ульянова");
		string_0 = string_0.Replace("Ж.Дивизии", "Железной Дивизии");
		string_0 = string_0.Replace("Зап. Бульвар", "Западный б-р");
		string_0 = string_0.Replace("Лазо", "Сергея Лазо");
		string_0 = string_0.Replace("Тюленина", "Сергея Тюленина");
		string_0 = string_0.Replace("Московское шоссе", "Московское ш");
		string_0 = string_0.Replace("К.Либкнехта", "Карла Либкнехта");
		string_0 = string_0.Replace("О.Кошевого", "Олега Кошевого");
		string_0 = string_0.Replace("Наб.р.свияги", "Набережная реки Свияги");
		string_0 = string_0.Replace("Минаева спуск", "Спуск Минаева");
		string_0 = string_0.Replace("Немировича Данченко", "Немировича-Данченко");
		string_0 = string_0.Replace("Р.Люксембург", "Розы Люксембург");
		string_0 = string_0.Replace("Старо-сельденская", "Старосельдинская");
		string_0 = string_0.Replace("Нижне-Полевая", "Нижнеполевая");
		string_0 = string_0.Replace("Полбина п-д", "Полбина проезд");
		string_0 = string_0.Replace("Нижне-Татарская", "Нижнетатарская");
		string_0 = string_0.Replace("Старо свияжск.пригород", "Старосвияжский Пригород");
		string_0 = string_0.Replace("П.Морозова", "Павлика Морозова");
		string_0 = string_0.Replace("проезд Аверьянова", "Героя России Аверьянова");
		string_0 = string_0.Replace("Проспект Гая", "Гая пр-кт");
		string_0 = string_0.Replace("С.Разина спуск", "Спуск Степана Разина");
		string_0 = string_0.Replace("2 Зап. Пригород", "Западный Пригород 2-я");
		string_0 = string_0.Replace("Прокофьева п.р.", "Прокофьева проезд");
		string_0 = string_0.Replace("С.Разина", "Степана Разина");
		return string_0;
	}

	private static int? smethod_7(SQLSettings sqlsettings_0, string string_0)
	{
		if (Class226.dataTable_1 == null || Class226.dataTable_1.Rows.Count == 0)
		{
			SqlDataCommand sqlDataCommand = new SqlDataCommand(sqlsettings_0);
			string text = "";
			foreach (object obj in Enum.GetValues(typeof(SchmTypeSubstation)))
			{
				SchmTypeSubstation schmTypeSubstation = (SchmTypeSubstation)obj;
				if (string.IsNullOrEmpty(text))
				{
					int num = (int)schmTypeSubstation;
					text = num.ToString();
				}
				else
				{
					string str = text;
					string str2 = ",";
					int num = (int)schmTypeSubstation;
					text = str + str2 + num.ToString();
				}
			}
			Class226.dataTable_1 = sqlDataCommand.SelectSqlData("tSChm_ObjList", true, " where typeCodeId in (" + text + ") and deleted = 0 ", null);
		}
		DataRow[] array = Class226.dataTable_1.Select("name = '" + string_0 + "'");
		if (array.Length != 0)
		{
			return new int?(Convert.ToInt32(array[0]["id"]));
		}
		return null;
	}

	private static int? smethod_8(SQLSettings sqlsettings_0, string string_0)
	{
		if (Class226.rixComJilu2 == null || Class226.rixComJilu2.Rows.Count == 0)
		{
			Class226.rixComJilu2 = new SqlDataCommand(sqlsettings_0).SelectSqlData("tR_Classifier", true, " where ParentKey = ';ReportDaily;DamageReason;LV;' and isgroup = 0 and deleted = 0 order by name", null);
		}
		DataRow[] array = Class226.rixComJilu2.Select("name = '" + string_0.Replace("'", "''") + "'");
		if (array.Length != 0)
		{
			return new int?(Convert.ToInt32(array[0]["id"]));
		}
		return null;
	}

	private static int? smethod_9(SQLSettings sqlsettings_0, string string_0)
	{
		if (Class226.dataTable_2 == null || Class226.dataTable_2.Rows.Count == 0)
		{
			Class226.dataTable_2 = new SqlDataCommand(sqlsettings_0).SelectSqlData("vR_Worker", true, " order by dateEnd", null);
		}
		DataRow[] array = Class226.dataTable_2.Select("fio = '" + string_0 + "'");
		if (array.Length != 0)
		{
			return new int?(Convert.ToInt32(array[0]["id"]));
		}
		return null;
	}

	private static string smethod_10(SQLSettings sqlsettings_0, DateTime dateTime_0)
	{
		if (Class226.dataTable_3 == null || Class226.dataTable_3.Rows.Count == 0)
		{
			Class226.dataTable_3 = new SqlDataCommand(sqlsettings_0).SelectSqlData("select [Дата1], [составил] from СоставительНизкого");
		}
		DataRow[] array = Class226.dataTable_3.Select(string.Format("[Дата1] = '{0:o}'", dateTime_0.Date));
		if (array.Length != 0)
		{
			return array[0]["составил"].ToString();
		}
		return null;
	}

	private static int? smethod_11(SQLSettings sqlsettings_0, int int_0)
	{
		if (Class226.dataTable_4 == null || Class226.dataTable_4.Rows.Count == 0)
		{
			Class226.dataTable_4 = new SqlDataCommand(sqlsettings_0).SelectSqlData("tuser", true, " ", null);
		}
		DataRow[] array = Class226.dataTable_4.Select("idWorker = " + int_0.ToString());
		if (array.Length != 0)
		{
			return new int?(Convert.ToInt32(array[0]["iduser"]));
		}
		return null;
	}

	private static int? smethod_12(SQLSettings sqlsettings_0, string string_0)
	{
		if (Class226.hxxCoMmTsvu == null || Class226.hxxCoMmTsvu.Rows.Count == 0)
		{
			Class226.hxxCoMmTsvu = new SqlDataCommand(sqlsettings_0).SelectSqlData("tr_classifier", true, "where parentKey like ';ReportDaily;PTS;ReasonDamage;LV;%' and isgroup = 0 and deleted = 0", null);
		}
		DataRow[] array = Class226.hxxCoMmTsvu.Select("value = " + string_0);
		if (array.Length != 0)
		{
			return new int?(Convert.ToInt32(array[0]["id"]));
		}
		return null;
	}

	public Class226()
	{
		
		
	}

	private static DataTable dataTable_0;

	private static DataTable dataTable_1;

	private static DataTable rixComJilu2;

	private static DataTable dataTable_2;

	private static DataTable dataTable_3;

	private static DataTable dataTable_4;

	private static DataTable hxxCoMmTsvu;
}
