using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Xml;
using DataSql;

internal static class Class227
{
	internal static void smethod_0(int int_0, SQLSettings sqlsettings_0)
	{
		try
		{
			SqlDataCommand sqlDataCommand = new SqlDataCommand(sqlsettings_0);
			DataTable dataTable = sqlDataCommand.SelectSqlData("select idSchmObj, idDivisionApply, isLaboratory from tj_damage where id = " + int_0.ToString());
			int num = -1;
			bool flag = false;
			if (dataTable.Rows.Count != 0)
			{
				if (dataTable.Rows[0]["idDivisionApply"] != DBNull.Value)
				{
					num = Convert.ToInt32(dataTable.Rows[0]["idDivisionApply"]);
				}
				if (dataTable.Rows[0]["isLaboratory"] != DBNull.Value)
				{
					flag = Convert.ToBoolean(dataTable.Rows[0]["isLaboratory"]);
				}
				if (num != -1 || flag)
				{
					string str = "";
					if (dataTable.Rows[0]["idSchmObj"] != DBNull.Value)
					{
						str = sqlDataCommand.CallSQLScalarFunction("[dbo].[fn_Schm_GetFullNameObjById]", new string[]
						{
							dataTable.Rows[0]["idSchmObj"].ToString()
						}).ToString();
					}
					DataTable dataTable2 = sqlDataCommand.SelectSqlData("tSettings", true, "where module = 'DamageMail'", null);
					if (dataTable2.Rows.Count != 0)
					{
						if (dataTable2.Rows[0]["Settings"] != DBNull.Value)
						{
							XmlDocument xmlDocument = new XmlDocument();
							xmlDocument.LoadXml(dataTable2.Rows[0]["Settings"].ToString());
							XmlNode xmlNode = xmlDocument.SelectSingleNode("DamageMail");
							if (xmlNode != null)
							{
								XmlAttribute xmlAttribute = xmlNode.Attributes["useMail"];
								if (xmlAttribute != null && Convert.ToBoolean(xmlAttribute.Value))
								{
									string string_ = "";
									string string_2 = "";
									string string_3 = "";
									string string_4 = "";
									string string_5 = "";
									int int_ = 25;
									XmlNode xmlNode2 = xmlNode.SelectSingleNode("SMTP");
									if (xmlNode2 != null)
									{
										xmlAttribute = xmlNode2.Attributes["Name"];
										if (xmlAttribute != null)
										{
											string_ = xmlAttribute.Value;
										}
										xmlAttribute = xmlNode2.Attributes["Port"];
										if (xmlAttribute != null && !string.IsNullOrEmpty(xmlAttribute.Value))
										{
											int_ = Convert.ToInt32(xmlAttribute.Value);
										}
										xmlAttribute = xmlNode2.Attributes["Login"];
										if (xmlAttribute != null)
										{
											string_2 = xmlAttribute.Value;
										}
										xmlAttribute = xmlNode2.Attributes["Pwd"];
										if (xmlAttribute != null)
										{
											string_3 = xmlAttribute.Value;
										}
										XmlNode xmlNode3 = xmlNode.SelectSingleNode("Sender");
										if (xmlNode3 != null)
										{
											xmlAttribute = xmlNode3.Attributes["Address"];
											if (xmlAttribute != null)
											{
												string_4 = xmlAttribute.Value;
											}
											xmlAttribute = xmlNode3.Attributes["Name"];
											if (xmlAttribute != null)
											{
												string_5 = xmlAttribute.Value;
											}
										}
										DataTable dataTable3 = Class227.smethod_1(xmlDocument, sqlsettings_0);
										string text = "divId in (";
										if (num != -1)
										{
											text += num.ToString();
										}
										if (flag)
										{
											if (num != -1)
											{
												text += ",-1";
											}
											else
											{
												text += "-1";
											}
										}
										text += ")";
										foreach (DataRow dataRow in from row in dataTable3.Select(text).AsEnumerable<DataRow>()
										group row by row["Tag"] into grp
										select grp.First<DataRow>())
										{
											string text2 = dataRow["Tag"].ToString();
											DataTable dataTable4 = sqlDataCommand.SelectSqlData(string.Concat(new string[]
											{
												"select ch.id, isnull(ch.col3, isnull(ch.col2, col1)) as col from tJ_DamageCharacter ch\r\n\t                                                            left join tR_Classifier c on isnull(ch.col3, isnull(ch.col2, col1)) = c.id\r\n                                                             where ch.idDamage = ",
												int_0.ToString(),
												" and c.Comment like '%",
												text2,
												"%'"
											}));
											if (dataTable4.Rows.Count != 0)
											{
												foreach (object obj in dataTable4.Rows)
												{
													DataRow dataRow2 = (DataRow)obj;
													int num2 = -1;
													if (dataRow2["col"] != DBNull.Value)
													{
														num2 = Convert.ToInt32(dataRow2["col"]);
													}
													string str2 = "";
													DataTable dataTable5 = sqlDataCommand.SelectSqlData("select name from tr_Classifier where id = " + num2.ToString());
													if (dataTable5.Rows.Count > 0 && dataTable5.Rows[0]["NAme"] != DBNull.Value)
													{
														str2 = dataTable5.Rows[0]["NAme"].ToString();
													}
													DataRow[] array = dataTable3.Select(text + " and tag = '" + text2 + "' and contact is not null");
													List<Struct6> list = new List<Struct6>();
													foreach (DataRow dataRow3 in array)
													{
														list.Add(new Struct6(dataRow3["Contact"].ToString(), dataRow3["FIO"].ToString()));
													}
													Class129.smethod_13(string_, int_, string_2, string_3, string_4, string_5, list, "DamageMail", str + "\r\n" + str2, null, false);
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, ex.Source);
		}
	}

	internal static DataTable smethod_1(XmlDocument xmlDocument_0, SQLSettings sqlsettings_0)
	{
		DataTable dataTable = new DataTable();
		dataTable.Columns.Add("tag", typeof(string));
		dataTable.Columns.Add("divName", typeof(string));
		dataTable.Columns.Add("divId", typeof(int));
		dataTable.Columns.Add("FIO", typeof(string));
		dataTable.Columns.Add("idWorker", typeof(int));
		dataTable.Columns.Add("Contact", typeof(string));
		DataTable dataTable2 = new DataTable("tR_Classifier");
		DataColumn dataColumn = dataTable2.Columns.Add("id", typeof(int));
		dataTable2.Columns.Add("name", typeof(string));
		dataTable2.PrimaryKey = new DataColumn[]
		{
			dataColumn
		};
		SqlDataCommand sqlDataCommand = new SqlDataCommand(sqlsettings_0);
		sqlDataCommand.SelectSqlData(dataTable2, true, "", null, false, 0);
		DataTable dataTable3 = new DataTable("tR_Worker");
		DataColumn dataColumn2 = dataTable3.Columns.Add("id", typeof(int));
		dataTable3.Columns.Add("F", typeof(string));
		dataTable3.Columns.Add("I", typeof(string));
		dataTable3.Columns.Add("O", typeof(string));
		dataTable3.Columns.Add("FIO", typeof(string), "F + isnull(' ' + I, '') + isnull(' ' + O, '')");
		dataTable3.PrimaryKey = new DataColumn[]
		{
			dataColumn2
		};
		sqlDataCommand.SelectSqlData(dataTable3, true, "", null, false, 0);
		XmlNode xmlNode = xmlDocument_0.SelectSingleNode("DamageMail");
		if (xmlNode != null)
		{
			XmlNode xmlNode2 = xmlNode.SelectSingleNode("Recipients");
			if (xmlNode2 != null)
			{
				foreach (object obj in xmlNode2.SelectNodes("TagName"))
				{
					XmlNode xmlNode3 = (XmlNode)obj;
					string text = "";
					XmlAttribute xmlAttribute = xmlNode3.Attributes["TagName"];
					if (xmlAttribute != null)
					{
						text = xmlAttribute.Value;
					}
					dataTable.Rows.Add(new object[]
					{
						text
					});
					foreach (object obj2 in xmlNode3.SelectNodes("Division"))
					{
						XmlNode xmlNode4 = (XmlNode)obj2;
						string text2 = "";
						int? num = null;
						xmlAttribute = xmlNode4.Attributes["DivId"];
						if (xmlAttribute != null)
						{
							num = new int?(Convert.ToInt32(xmlAttribute.Value));
						}
						DataRow dataRow = dataTable2.Rows.Find(num.Value);
						if (dataRow != null)
						{
							text2 = dataRow["name"].ToString();
						}
						else
						{
							xmlAttribute = xmlNode4.Attributes["DivName"];
							if (xmlAttribute != null)
							{
								text2 = xmlAttribute.Value;
							}
						}
						dataTable.Rows.Add(new object[]
						{
							text,
							text2,
							num
						});
						foreach (object obj3 in xmlNode4.SelectNodes("Contact"))
						{
							XmlNode xmlNode5 = (XmlNode)obj3;
							string text3 = "";
							int? num2 = null;
							string text4 = "";
							xmlAttribute = xmlNode5.Attributes["IdWorker"];
							if (xmlAttribute != null)
							{
								num2 = new int?(Convert.ToInt32(xmlAttribute.Value));
							}
							dataRow = dataTable3.Rows.Find(num2.Value);
							if (dataRow != null)
							{
								text3 = dataRow["fio"].ToString();
							}
							else
							{
								xmlAttribute = xmlNode5.Attributes["FIO"];
								if (xmlAttribute != null)
								{
									text3 = xmlAttribute.Value;
								}
							}
							xmlAttribute = xmlNode5.Attributes["Contact"];
							if (xmlAttribute != null)
							{
								text4 = xmlAttribute.Value;
							}
							dataTable.Rows.Add(new object[]
							{
								text,
								text2,
								num,
								text3,
								num2,
								text4
							});
						}
					}
				}
			}
		}
		DataView defaultView = dataTable.DefaultView;
		defaultView.Sort = "tag, divname, fio, contact";
		return defaultView.ToTable();
	}
}
