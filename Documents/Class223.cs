using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using DataSql;
using MySql.Data.MySqlClient;

internal class Class223
{
	internal static void smethod_0(SQLSettings sqlsettings_0)
	{
		MySqlConnection mySqlConnection = new MySqlConnection(string.Format("Server=192.168.1.135; Port=3306; Database=repa; Uid=root; Pwd=312jDSK-98; CharSet=utf8;", new object[0]));
		try
		{
			mySqlConnection.Open();
			DataTable dataTable = new DataTable("Data");
			DataTable dataTable2 = new DataTable();
			DataTable dataTable3 = new DataTable();
			DataTable dataTable4 = new DataTable();
			DataTable dataTable5 = new DataTable();
			DataTable dataTable6 = new DataTable();
			using (MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter("select id, num, `date`, `time`, street, house, fault, ppno,\r\n                                 cast( repait_fakt as char) as repait_fakt, repait_plan, who, comment, sms from data\r\n                                 where `date` < '20160927'\r\n                                 order by `date`", mySqlConnection))
			{
				mySqlDataAdapter.Fill(dataTable);
			}
			using (MySqlDataAdapter mySqlDataAdapter2 = new MySqlDataAdapter("select * from asoca.build", mySqlConnection))
			{
				mySqlDataAdapter2.Fill(dataTable2);
			}
			using (MySqlDataAdapter mySqlDataAdapter3 = new MySqlDataAdapter("select * from street", mySqlConnection))
			{
				mySqlDataAdapter3.Fill(dataTable3);
			}
			using (MySqlDataAdapter mySqlDataAdapter4 = new MySqlDataAdapter("select * from fault", mySqlConnection))
			{
				mySqlDataAdapter4.Fill(dataTable4);
			}
			using (MySqlDataAdapter mySqlDataAdapter5 = new MySqlDataAdapter("select * from fault_in", mySqlConnection))
			{
				mySqlDataAdapter5.Fill(dataTable5);
			}
			using (MySqlDataAdapter mySqlDataAdapter6 = new MySqlDataAdapter("select id, `date`, ppno, fault, comment, yes, sms, notlight, who, \r\n                                `time`,  cast( repairdate as char) as repairdate,\r\n                                 repairtime, repairCharacter from data_In \r\n                                 where `date` < '20160927'\r\n                                 order by `date`", mySqlConnection))
			{
				mySqlDataAdapter6.Fill(dataTable6);
			}
			foreach (object obj in dataTable.Rows)
			{
				DataRow dataRow = (DataRow)obj;
				try
				{
					Class171.Class172 @class = new Class171.Class172();
					DataRow dataRow2 = @class.NewRow();
					DateTime dateTime = Convert.ToDateTime(dataRow["date"]);
					TimeSpan value;
					TimeSpan.TryParse(dataRow["time"].ToString(), out value);
					dateTime.Add(value);
					dataRow2["dateDoc"] = dateTime;
					dataRow2["TypeDoc"] = 1401;
					dataRow2["numRequest"] = dataRow["num"];
					dataRow2["idDivision"] = 1407;
					DataRow[] array = dataTable2.Select("id = " + dataRow["ppno"].ToString());
					if (array.Length != 0)
					{
						SqlDataCommand sqlDataCommand = new SqlDataCommand(new SQLSettings("ulges-sql2", "GES", "WINDOWS", "", ""));
						DataTable dataTable7 = sqlDataCommand.SelectSqlData("select id, name from tSChm_ObjList\r\n                                                    where typeCodeId = 1275 and name = '" + array[0]["Name"].ToString() + "'");
						if (dataTable7.Rows.Count > 0)
						{
							dataRow2["idSchmObj"] = dataTable7.Rows[0]["id"];
						}
						else
						{
							string text = array[0]["Name"].ToString();
							if (text.IndexOf("-01") > 0)
							{
								text = text.Substring(0, text.IndexOf("-01"));
								dataTable7 = sqlDataCommand.SelectSqlData("select id, name from tSChm_ObjList\r\n                                                    where typeCodeId = 1275 and name = '" + text + "'");
								if (dataTable7.Rows.Count > 0)
								{
									dataRow2["idSchmObj"] = dataTable7.Rows[0]["id"];
								}
								else if (text.IndexOf("-02") > 0)
								{
									text = text.Substring(0, text.IndexOf("-02"));
									dataTable7 = sqlDataCommand.SelectSqlData("select id, name from tSChm_ObjList\r\n                                                    where typeCodeId = 1275 and name = '" + text + "'");
									if (dataTable7.Rows.Count > 0)
									{
										dataRow2["idSchmObj"] = dataTable7.Rows[0]["id"];
									}
								}
							}
						}
						if (dataRow2["idSchmObj"] == DBNull.Value)
						{
							dataRow2["DefectLocation"] = "ППНО-" + array[0]["Name"].ToString();
						}
					}
					DataRow[] array2 = dataTable3.Select("num = " + dataRow["street"].ToString());
					if (array2.Length != 0)
					{
						string text2 = array2[0]["name"].ToString();
						if (dataRow["house"] != DBNull.Value)
						{
							text2 = text2 + " " + dataRow["house"].ToString();
						}
						if (dataRow2["DefectLocation"] == DBNull.Value)
						{
							dataRow2["DefectLocation"] = text2;
						}
						else
						{
							dataRow2["DefectLocation"] = dataRow2["DefectLocation"].ToString() + "\r\n" + text2;
						}
					}
					dataRow2["ComletedWorkText"] = dataRow["Comment"];
					dataRow2["DatePlanApply"] = dataRow["repait_plan"];
					if (dataRow["repait_fakt"].ToString() != "0000-00-00")
					{
						DateTime dateTime2 = Convert.ToDateTime(dataRow["repait_fakt"]);
						dataRow2["isApply"] = true;
						dataRow2["dateApply"] = dateTime2;
					}
					@class.Rows.Add(dataRow2);
					SqlDataCommand sqlDataCommand2 = new SqlDataCommand(sqlsettings_0);
					int int_ = sqlDataCommand2.InsertSqlDataOneRow(@class);
					DataRow[] array3 = dataTable4.Select("num = " + dataRow["Fault"]);
					if (array3.Length != 0)
					{
						DataTable dataTable8 = sqlDataCommand2.SelectSqlData("select id, ParentId\r\n                                                                from tR_Classifier\r\n                                                                where ParentKey like ';ReportDaily;NatureDamage;LV;%' \r\n                                                                and name = '" + array3[0]["name"].ToString() + "'");
						if (dataTable8.Rows.Count > 0)
						{
							Class223.smethod_1(int_, dataTable8.Rows[0], sqlsettings_0);
						}
						else if (array3[0]["name"].ToString().IndexOf("УО-") == 0)
						{
							dataTable8 = sqlDataCommand2.SelectSqlData("select id, ParentId\r\n                                                                from tR_Classifier\r\n                                                                where ParentKey like ';ReportDaily;NatureDamage;LV;%' \r\n                                                                and ParentId = 2154\r\n                                                                and name = '" + array3[0]["name"].ToString().Substring(3).Replace("\r\n", "") + "'");
							if (dataTable8.Rows.Count > 0)
							{
								Class223.smethod_1(int_, dataTable8.Rows[0], sqlsettings_0);
							}
						}
						else if (array3[0]["name"].ToString().IndexOf("Св-к-") == 0)
						{
							dataTable8 = sqlDataCommand2.SelectSqlData("select id, ParentId\r\n                                                                from tR_Classifier\r\n                                                                where ParentKey like ';ReportDaily;NatureDamage;LV;%' \r\n                                                                and ParentId = 2158\r\n                                                                and name = '" + array3[0]["name"].ToString().Substring(5) + "'");
							if (dataTable8.Rows.Count > 0)
							{
								Class223.smethod_1(int_, dataTable8.Rows[0], sqlsettings_0);
							}
						}
						else if (array3[0]["name"].ToString().IndexOf("Линия-") == 0)
						{
							dataTable8 = sqlDataCommand2.SelectSqlData("select id, ParentId\r\n                                                                from tR_Classifier\r\n                                                                where ParentKey like ';ReportDaily;NatureDamage;LV;%' \r\n                                                                and ParentId in (2155, 2191)\r\n                                                                and name = '" + array3[0]["name"].ToString().Substring(6) + "'");
							if (dataTable8.Rows.Count > 0)
							{
								Class223.smethod_1(int_, dataTable8.Rows[0], sqlsettings_0);
							}
						}
						else if (array3[0]["name"].ToString().IndexOf("Сборка-") == 0)
						{
							dataTable8 = sqlDataCommand2.SelectSqlData("select id, ParentId\r\n                                                                from tR_Classifier\r\n                                                                where ParentKey like ';ReportDaily;NatureDamage;LV;%' \r\n                                                                and ParentId = 2159\r\n                                                                and name = '" + array3[0]["name"].ToString().Substring(7) + "'");
							if (dataTable8.Rows.Count > 0)
							{
								Class223.smethod_1(int_, dataTable8.Rows[0], sqlsettings_0);
							}
						}
						else if (array3[0]["name"].ToString().IndexOf("Опора-") == 0)
						{
							dataTable8 = sqlDataCommand2.SelectSqlData("select id, ParentId\r\n                                                                from tR_Classifier\r\n                                                                where ParentKey like ';ReportDaily;NatureDamage;LV;%' \r\n                                                                and ParentId = 2156\r\n                                                                and name = '" + array3[0]["name"].ToString().Substring(6) + "'");
							if (dataTable8.Rows.Count > 0)
							{
								Class223.smethod_1(int_, dataTable8.Rows[0], sqlsettings_0);
							}
						}
						else if (array3[0]["name"].ToString().IndexOf("Торшер-") == 0)
						{
							dataTable8 = sqlDataCommand2.SelectSqlData("select id, ParentId\r\n                                                                from tR_Classifier\r\n                                                                where ParentKey like ';ReportDaily;NatureDamage;LV;%' \r\n                                                                and ParentId = 2157\r\n                                                                and name = '" + array3[0]["name"].ToString().Substring(7) + "'");
							if (dataTable8.Rows.Count > 0)
							{
								Class223.smethod_1(int_, dataTable8.Rows[0], sqlsettings_0);
							}
						}
					}
					Class223.smethod_3(int_, dataRow2, Convert.ToInt32(dataRow["who"]), sqlsettings_0);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, ex.Source);
				}
			}
			foreach (object obj2 in dataTable6.Rows)
			{
				DataRow dataRow3 = (DataRow)obj2;
				try
				{
					Class171.Class172 class2 = new Class171.Class172();
					DataRow dataRow4 = class2.NewRow();
					DateTime dateTime3 = Convert.ToDateTime(dataRow3["date"]);
					TimeSpan value2;
					TimeSpan.TryParse(dataRow3["time"].ToString(), out value2);
					dateTime3.Add(value2);
					dataRow4["dateDoc"] = dateTime3;
					dataRow4["TypeDoc"] = 1401;
					dataRow4["numRequest"] = dataRow3["id"];
					dataRow4["idDivision"] = 1407;
					DataRow[] array4 = dataTable2.Select("id = " + dataRow3["ppno"].ToString());
					if (array4.Length != 0)
					{
						SqlDataCommand sqlDataCommand3 = new SqlDataCommand(new SQLSettings("ulges-sql2", "GES", "WINDOWS", "", ""));
						DataTable dataTable9 = sqlDataCommand3.SelectSqlData("select id, name from tSChm_ObjList\r\n                                                    where typeCodeId = 1275 and name = '" + array4[0]["Name"].ToString() + "'");
						if (dataTable9.Rows.Count > 0)
						{
							dataRow4["idSchmObj"] = dataTable9.Rows[0]["id"];
						}
						else
						{
							string text3 = array4[0]["Name"].ToString();
							if (text3.IndexOf("-01") > 0)
							{
								text3 = text3.Substring(0, text3.IndexOf("-01"));
								dataTable9 = sqlDataCommand3.SelectSqlData("select id, name from tSChm_ObjList\r\n                                                    where typeCodeId = 1275 and name = '" + text3 + "'");
								if (dataTable9.Rows.Count > 0)
								{
									dataRow4["idSchmObj"] = dataTable9.Rows[0]["id"];
								}
								else if (text3.IndexOf("-02") > 0)
								{
									text3 = text3.Substring(0, text3.IndexOf("-02"));
									dataTable9 = sqlDataCommand3.SelectSqlData("select id, name from tSChm_ObjList\r\n                                                    where typeCodeId = 1275 and name = '" + text3 + "'");
									if (dataTable9.Rows.Count > 0)
									{
										dataRow4["idSchmObj"] = dataTable9.Rows[0]["id"];
									}
								}
							}
						}
						if (dataRow4["idSchmObj"] == DBNull.Value)
						{
							dataRow4["DefectLocation"] = "ППНО-" + array4[0]["Name"].ToString();
						}
					}
					dataRow4["ComletedWorkText"] = dataRow3["Comment"];
					if (dataRow3["repairDate"].ToString() != "0000-00-00")
					{
						DateTime dateTime4 = Convert.ToDateTime(dataRow3["repairDate"]);
						TimeSpan.TryParse(dataRow3["repairtime"].ToString(), out value2);
						dateTime4.Add(value2);
						dataRow4["isApply"] = true;
						dataRow4["dateApply"] = dateTime4;
					}
					class2.Rows.Add(dataRow4);
					int int_2 = new SqlDataCommand(sqlsettings_0).InsertSqlDataOneRow(class2);
					Class223.smethod_2(int_2, Convert.ToInt32(dataRow3["Fault"]), sqlsettings_0);
					Class223.smethod_3(int_2, dataRow4, Convert.ToInt32(dataRow3["who"]), sqlsettings_0);
				}
				catch (Exception ex2)
				{
					MessageBox.Show(ex2.Message, ex2.Source);
				}
			}
		}
		catch (Exception ex3)
		{
			MessageBox.Show(ex3.Message, ex3.Source);
		}
	}

	private static void smethod_1(int int_0, DataRow dataRow_0, SQLSettings sqlsettings_0)
	{
		Class171.Class184 @class = new Class171.Class184();
		DataRow dataRow = @class.NewRow();
		dataRow["idDamage"] = int_0;
		if (Convert.ToInt32(dataRow_0["ParentId"]) == 2146)
		{
			dataRow["col2"] = dataRow_0["id"];
			dataRow["col1"] = dataRow_0["ParentId"];
		}
		else
		{
			dataRow["col3"] = dataRow_0["id"];
			if (dataRow_0["ParentId"] != DBNull.Value)
			{
				DataTable dataTable = new SqlDataCommand(sqlsettings_0).SelectSqlData("select id, ParentId\r\n                                                                from tR_Classifier\r\n                                                                where id = " + dataRow_0["ParentId"].ToString());
				if (dataTable.Rows.Count > 0)
				{
					dataRow["col2"] = dataTable.Rows[0]["id"].ToString();
					if (dataTable.Rows[0]["ParentId"] != DBNull.Value)
					{
						dataRow["col1"] = dataTable.Rows[0]["ParentId"];
					}
				}
			}
		}
		@class.Rows.Add(dataRow);
		new SqlDataCommand(sqlsettings_0).InsertSqlData(@class);
	}

	private static void smethod_2(int int_0, int int_1, SQLSettings sqlsettings_0)
	{
		string text = "";
		switch (int_1)
		{
		case 10:
			text = string.Format("insert into tJ_DamageCharacter (idDamage, col1, col2, col3)\r\n                                                values ({0}, 2146, 2155, null)", int_0);
			break;
		case 12:
			text = string.Format("insert into tJ_DamageCharacter (idDamage, col1, col2, col3)\r\n                                                values ({0}, 2146, 2155, 2186)", int_0);
			break;
		case 14:
			text = string.Format("insert into tJ_DamageCharacter (idDamage, col1, col2, col3)\r\n                                                values ({0}, 2146, 2155, 2174)", int_0);
			break;
		case 19:
			text = string.Format("insert into tJ_DamageCharacter (idDamage, col1, col2, col3)\r\n                                                values ({0}, 2146, 2155, 2184)", int_0);
			break;
		case 20:
			text = string.Format("insert into tJ_DamageCharacter (idDamage, col1, col2, col3)\r\n                                                values ({0}, 2146, 2191, null)", int_0);
			break;
		case 22:
			text = string.Format("insert into tJ_DamageCharacter (idDamage, col1, col2, col3)\r\n                                                values ({0}, 2146, 2191, 2193)", int_0);
			break;
		case 24:
			text = string.Format("insert into tJ_DamageCharacter (idDamage, col1, col2, col3)\r\n                                                values ({0}, 2146, 2191, 2192)", int_0);
			break;
		case 26:
			text = string.Format("insert into tJ_DamageCharacter (idDamage, col1, col2, col3)\r\n                                                values ({0}, 2146, 2191, 2194)", int_0);
			break;
		case 29:
			text = string.Format("insert into tJ_DamageCharacter (idDamage, col1, col2, col3)\r\n                                                values ({0}, 2146, 2191, 2195)", int_0);
			break;
		case 31:
			text = string.Format("insert into tJ_DamageCharacter (idDamage, col1, col2, col3)\r\n                                                values ({0}, 2146, 2159, 2216)", int_0);
			break;
		case 32:
			text = string.Format("insert into tJ_DamageCharacter (idDamage, col1, col2, col3)\r\n                                                values ({0}, 2146, 2159, 2217)", int_0);
			break;
		case 33:
			text = string.Format("insert into tJ_DamageCharacter (idDamage, col1, col2, col3)\r\n                                                values ({0}, 2146, 2159, 2218)", int_0);
			break;
		case 34:
			text = string.Format("insert into tJ_DamageCharacter (idDamage, col1, col2, col3)\r\n                                                values ({0}, 2146, 2159, 2219)", int_0);
			break;
		case 35:
			text = string.Format("insert into tJ_DamageCharacter (idDamage, col1, col2, col3)\r\n                                                values ({0}, 2146, 2159, 2220)", int_0);
			break;
		case 39:
			text = string.Format("insert into tJ_DamageCharacter (idDamage, col1, col2, col3)\r\n                                                values ({0}, 2146, 2159, 2215)", int_0);
			break;
		case 42:
			text = string.Format("insert into tJ_DamageCharacter (idDamage, col1, col2, col3)\r\n                                                values ({0}, 2146, 2160, 2222)", int_0);
			break;
		case 43:
			text = string.Format("insert into tJ_DamageCharacter (idDamage, col1, col2, col3)\r\n                                                values ({0}, 2146, 2160, 2223)", int_0);
			break;
		case 45:
			text = string.Format("insert into tJ_DamageCharacter (idDamage, col1, col2, col3)\r\n                                                values ({0}, 2146, 2160, 2224)", int_0);
			break;
		case 46:
			text = string.Format("insert into tJ_DamageCharacter (idDamage, col1, col2, col3)\r\n                                                values ({0}, 2146, 2160, 2225)", int_0);
			break;
		case 47:
			text = string.Format("insert into tJ_DamageCharacter (idDamage, col1, col2, col3)\r\n                                                values ({0}, 2146, 2160, 2226)", int_0);
			break;
		case 49:
			text = string.Format("insert into tJ_DamageCharacter (idDamage, col1, col2, col3)\r\n                                                values ({0}, 2146, 2160, 2227)", int_0);
			break;
		case 52:
			text = string.Format("insert into tJ_DamageCharacter (idDamage, col1, col2, col3)\r\n                                                values ({0}, 2146, 2156, 2197)", int_0);
			break;
		case 54:
			text = string.Format("insert into tJ_DamageCharacter (idDamage, col1, col2, col3)\r\n                                                values ({0}, 2146, 2156, 2196)", int_0);
			break;
		}
		if (!string.IsNullOrEmpty(text))
		{
			try
			{
				using (SqlConnection sqlConnection = new SqlConnection(sqlsettings_0.GetConnectionString()))
				{
					sqlConnection.Open();
					using (SqlCommand sqlCommand = new SqlCommand())
					{
						sqlCommand.Connection = sqlConnection;
						sqlCommand.CommandText = text;
						sqlCommand.ExecuteNonQuery();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}

	private static void smethod_3(int int_0, DataRow dataRow_0, int int_1, SQLSettings sqlsettings_0)
	{
		if (int_1 != 9 && int_1 != 0)
		{
			int num = -1;
			switch (int_1)
			{
			case 1:
				num = 2238;
				break;
			case 2:
				num = 2239;
				break;
			case 3:
				num = 2240;
				break;
			case 4:
				num = 2241;
				break;
			}
			Class171.Class172 @class = new Class171.Class172();
			SqlDataCommand sqlDataCommand = new SqlDataCommand(sqlsettings_0);
			sqlDataCommand.SelectSqlData(@class, true, "where id = " + int_0.ToString(), null, false, 0);
			if (@class.Rows.Count > 0)
			{
				@class.Rows[0]["ComletedWorkText"] = DBNull.Value;
				if (int_1 == 5)
				{
					@class.Rows[0]["isLaboratory"] = true;
				}
				else
				{
					@class.Rows[0]["idDivisionApply"] = num;
				}
				@class.Rows[0].EndEdit();
				sqlDataCommand.UpdateSqlData(@class);
			}
			Class171.Class172 class2 = new Class171.Class172();
			DataRow dataRow = class2.NewRow();
			dataRow["idParent"] = int_0;
			dataRow["dateDoc"] = dataRow_0["dateDoc"];
			dataRow["typeDoc"] = 1403;
			dataRow["numRequest"] = dataRow_0["numRequest"];
			dataRow["iddivision"] = dataRow_0["iddivision"];
			dataRow["idSchmObj"] = dataRow_0["idSchmObj"];
			dataRow["defectLocation"] = dataRow_0["defectLocation"];
			dataRow["ComletedWorkText"] = dataRow_0["ComletedWorkText"];
			dataRow["isApply"] = dataRow_0["isApply"];
			dataRow["dateApply"] = dataRow_0["DateApply"];
			if (int_1 == 5)
			{
				dataRow["isLaboratory"] = true;
			}
			else
			{
				dataRow["idDivisionApply"] = num;
			}
			dataRow["datePlanApply"] = dataRow_0["DatePlanApply"];
			class2.Rows.Add(dataRow);
			int num2 = sqlDataCommand.InsertSqlDataOneRow(class2);
			try
			{
				using (SqlConnection sqlConnection = new SqlConnection(sqlsettings_0.GetConnectionString()))
				{
					sqlConnection.Open();
					using (SqlCommand sqlCommand = new SqlCommand())
					{
						sqlCommand.Connection = sqlConnection;
						sqlCommand.CommandText = string.Concat(new string[]
						{
							"insert into tj_damageCharacter (idDAmage, col1, col2, col3)\r\n                                            (select ",
							num2.ToString(),
							", col1, col2, col3\r\n                                            from tJ_DamageCharacter where idDAmage = ",
							int_0.ToString(),
							")"
						});
						sqlCommand.ExecuteNonQuery();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			return;
		}
	}

	public Class223()
	{
		
		
	}
}
