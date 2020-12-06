using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using DataSql;

internal static class Class34
{
	internal static DataTable smethod_0(SQLSettings sqlsettings_0, DateTime dateTime_1, DateTime dateTime_2)
	{
		string text = "'" + dateTime_1.Date.ToString("yyyyMMdd") + "'";
		string text2 = "'" + dateTime_2.Date.ToString("yyyyMMdd") + " 23:59:59'";
		string text3 = string.Concat(new string[]
		{
			" ((dateTripBeg >= ",
			text,
			" and datetripBEg <= ",
			text2,
			") or (datetripend >= ",
			text,
			" and datetripEnd <= ",
			text2,
			") or (datetripBeg <= ",
			text,
			" and dateTRipEnd >= ",
			text2,
			")) "
		});
		string text4 = " (idDivision = " + Class34.int_0.ToString() + ") ";
		DataTable dataTable = new DataTable();
		using (SqlConnection sqlConnection = new SqlConnection(sqlsettings_0.GetConnectionString()))
		{
			try
			{
				sqlConnection.Open();
				new SqlDataAdapter(string.Concat(new string[]
				{
					"select * from vJ_RequestForRepairDaily where ",
					text3,
					" and ",
					text4,
					" and deleted = 0  and sendSite = 1 and (crash = 0 or crash is null) and agreed = 1  order by sr, id, datetripBeg"
				}), sqlConnection).Fill(dataTable);
				if (dateTime_1.Date == dateTime_2.Date)
				{
					foreach (object obj in dataTable.Rows)
					{
						DataRow dataRow = (DataRow)obj;
						if (dateTime_1.Date > Convert.ToDateTime(dataRow["dateTripBeg"]))
						{
							dataRow["dateTRipBeg"] = dateTime_1.Date;
						}
						if (dateTime_2.Date.AddDays(1.0).AddMinutes(-1.0) < Convert.ToDateTime(dataRow["DateTripEnd"]))
						{
							dataRow["dateTripEnd"] = dateTime_2.Date.AddDays(1.0).AddMinutes(-1.0);
						}
					}
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message, ex.InnerException);
			}
		}
		return dataTable;
	}

	internal static void smethod_1(SQLSettings sqlsettings_0, string string_9, DateTime dateTime_1, DateTime dateTime_2)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\"lang=\"ru\" xml:lang=\"ru\">\r\n                            <html>\r\n                            <meta http-equiv=\"Content-Language\" content=\"ru\" />\r\n                             <meta http-equiv=\"Content-Type\" content=\"text/html; charset=windows-1251\" />\r\n                             <head>\r\n                            <title></title>\r\n                            <BASEFONT FACE=\"Arial\" SIZE=8>\r\n                            <style>\r\n                            td,th{\r\n\t                            background-color:#FFFFFF;\r\n\t                            font-size:small;\r\n                            }\r\n                            th{\r\n\t                            text-align:center;\r\n\t                            vertical-align:center;\r\n                            }\r\n                            td{\r\n\t                            vertical-align:top;\r\n                            }\r\n                            .first-cell{\r\n\t                            width:20%;\r\n                            }\r\n                            .last-cell-date{\r\n\t                            width:11%;\r\n                            }\r\n                            .cell-status{\r\n\t                            width:19%;\r\n                            }\r\n                            .last-cell-time{\r\n\t                        width:8%;\r\n                            }\r\n                            .cell_sr{\r\n                                width:100%;\r\n                            }\r\n                            </style>\r\n                            <script type=\"text/javascript\">\r\n                            function doResize(){\r\n\t                            document.getElementById('t-header').setAttribute('width',document.getElementById('t-data').offsetWidth);\r\n                            }\r\n                            </script>\r\n                            </head>\r\n                            <body onLoad=\"doResize()\" onResize=\"doResize()\">");
		stringBuilder.Append("<table  id=\"t-header\" style = \" position:fixed; top:0px; height:85px; z-index:1000;background-color:black;\">\n");
		stringBuilder.Append("<TR>\n");
		stringBuilder.Append("<th    COLSPAN=8><I><B>Плановые работы в сетях МУП \"УльГЭС\"</B></I></FONT>");
		stringBuilder.Append("</tr>\n");
		stringBuilder.Append("<TR>\n");
		stringBuilder.Append(string.Format("<th    COLSPAN=8><I><B>за период с {0}г. по {1}г.</B></I></FONT>", dateTime_1.ToString("dd.MM.yyyy"), dateTime_2.ToString("dd.MM.yyyy")));
		stringBuilder.Append("</tr>\n");
		stringBuilder.Append("<TR>\n");
		stringBuilder.Append("<th  class=\"first-cell\" ALIGN=CENTER  ROWSPAN=2><B>Отключаемый <br />объект</B>\r\n\t\t\t                 <th    ROWSPAN=2><B>Адрес</B>\r\n\t\t\t                 <th    COLSPAN=2><B>Отключение</B>\r\n\t\t\t                 <th    COLSPAN=2><B>Включение</B>\r\n\t\t\t                 <th   class=\"cell-status\" ROWSPAN=2><B>Статус</B>");
		stringBuilder.Append("</tr>\n");
		stringBuilder.Append("<TR>\n");
		stringBuilder.Append("<th class=\"last-cell-date\"    ><B>Дата</B>\r\n\t\t\t                <th class=\"last-cell-time\"    ><B>Время</B>\r\n\t\t\t                <th class=\"last-cell-date\"    ><B>Дата</B>\r\n\t\t\t                <th class=\"last-cell-time\"    ><B>Время</B>");
		stringBuilder.Append("</tr>\n");
		stringBuilder.Append("</table>\n");
		stringBuilder.Append("<TABLE id=\"t-data\" style=\"width:100%; position:relative;top:75px;background-color:black;\">\n");
		stringBuilder.Append("<tbody>\n");
		DataTable dataTable = Class34.smethod_0(sqlsettings_0, dateTime_1, dateTime_2);
		int num = -1;
		if (dataTable.Rows.Count == 0)
		{
			stringBuilder.Append("<TR>\n");
			stringBuilder.Append("<TD class=\"cell-sr\" COLSPAN=8 style=\"background-color:#bfffff;\">плановых работ в электрических сетях МУП \"УльГЭС\" нет\n");
			stringBuilder.Append("</tr>\n");
		}
		for (int i = 0; i < dataTable.Rows.Count; i++)
		{
			DataRow dataRow = dataTable.Rows[i];
			string str = dataRow["datetripbeg"].ToString();
			string str2 = dataRow["datetripend"].ToString();
			int num2 = i;
			int num3 = 0;
			for (;;)
			{
				num2++;
				if (num2 >= dataTable.Rows.Count || Convert.ToInt32(dataRow["id"]) != Convert.ToInt32(dataTable.Rows[num2]["id"]))
				{
					break;
				}
				str = str + "\n" + dataRow["datetripbeg"].ToString();
				str2 = str2 + "\n" + dataRow["datetripend"].ToString();
				num3++;
			}
			if (num != Convert.ToInt32(dataRow["idSR"]))
			{
				stringBuilder.Append("<TR>\n");
				string str3 = Class34.smethod_2(dataRow["SR"].ToString());
				stringBuilder.Append("<TD class=\"cell-sr\" COLSPAN=8 style=\"background-color:#c0dcc0;\">" + str3 + "\n");
				stringBuilder.Append("</tr>\n");
				num = Convert.ToInt32(dataRow["idSR"]);
			}
			stringBuilder.Append("<TR>\n");
			string text = dataRow["SchmObj"].ToString();
			text = text.Replace(",", ", ");
			text = text.Replace(",  ", ", ");
			stringBuilder.Append(string.Format("<TD class=\"first-cell\" >{0}\n", text));
			string text2 = (dataRow["Address"] == DBNull.Value || string.IsNullOrEmpty(dataRow["Address"].ToString())) ? "&nbsp;" : dataRow["Address"].ToString();
			List<string> list = text2.Split(new string[]
			{
				"\r\n"
			}, StringSplitOptions.None).ToList<string>();
			if (list.Count > 1 && list.Contains(""))
			{
				list.Remove("");
			}
			list.Sort();
			text2 = string.Join("<br>", list.ToArray());
			text2 = text2.Replace(",", ", ");
			text2 = text2.Replace(",  ", ", ");
			stringBuilder.Append(string.Format("<TD >{0}\n", text2));
			string text3 = "";
			string text4 = "";
			string text5 = "";
			string text6 = "";
			num2 = i;
			num3 = 0;
			for (;;)
			{
				num2++;
				if (num2 >= dataTable.Rows.Count || Convert.ToInt32(dataRow["id"]) != Convert.ToInt32(dataTable.Rows[num2]["id"]))
				{
					break;
				}
				DataRow dataRow2 = dataTable.Rows[num2];
				text3 = text3 + "<br>" + Convert.ToDateTime(dataRow2["datetripbeg"]).Date.ToShortDateString();
				text5 = text5 + "<br>" + Convert.ToDateTime(dataRow2["datetripbeg"]).ToShortTimeString();
				text4 = text4 + "<br>" + Convert.ToDateTime(dataRow2["datetripEnd"]).Date.ToShortDateString();
				text6 = text6 + "<br>" + Convert.ToDateTime(dataRow2["datetripEnd"]).ToShortTimeString();
				num3++;
			}
			stringBuilder.Append("<TD class=\"last-cell-date\">" + Convert.ToDateTime(dataRow["datetripbeg"]).Date.ToShortDateString() + text3 + "\n");
			stringBuilder.Append("<TD class=\"last-cell-time\">" + Convert.ToDateTime(dataRow["datetripbeg"]).ToShortTimeString() + text5 + "\n");
			stringBuilder.Append("<TD class=\"last-cell-date\">" + Convert.ToDateTime(dataRow["datetripEnd"]).Date.ToShortDateString() + text4 + "\n");
			stringBuilder.Append("<TD class=\"last-cell-time\">" + Convert.ToDateTime(dataRow["datetripEnd"]).ToShortTimeString() + text6 + "\n");
			string arg = (dataRow["SiteStatus"] == DBNull.Value || string.IsNullOrEmpty(dataRow["SiteStatus"].ToString())) ? "&nbsp;" : dataRow["SiteStatus"].ToString();
			stringBuilder.Append(string.Format("<TD class=\"cell-status\" >{0}\n", arg));
			i += num3;
		}
		stringBuilder.Append("</tbody>\n");
		stringBuilder.Append("</table>\n");
		stringBuilder.Append("</body>\n");
		stringBuilder.Append("</html>\n");
		Class34.smethod_3(string_9, stringBuilder);
	}

	private static string smethod_2(string string_9)
	{
		if (string_9 == "Сетевой район №1")
		{
			return "Ленинский район";
		}
		if (string_9 == "Сетевой район №2")
		{
			return "Засвияжский район";
		}
		if (string_9 == "Сетевой район №3")
		{
			return "Железнодорожный район";
		}
		if (!(string_9 == "Сетевой район №4"))
		{
			return "";
		}
		return "Заволжский район";
	}

	private static void smethod_3(string string_9, StringBuilder stringBuilder_0)
	{
		try
		{
			File.Delete(string_9);
			StreamWriter streamWriter = new StreamWriter(string_9, true, Encoding.GetEncoding(1251));
			streamWriter.Write(stringBuilder_0.ToString());
			streamWriter.Close();
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message, ex.InnerException);
		}
	}

	internal static string smethod_4()
	{
		return Class34.smethod_6() + Class34.string_0;
	}

	internal static void smethod_5(SQLSettings sqlsettings_0)
	{
		using (SqlConnection sqlConnection = new SqlConnection(sqlsettings_0.GetConnectionString()))
		{
			try
			{
				sqlConnection.Open();
				DbDataAdapter dbDataAdapter = new SqlDataAdapter("select [Settings] from tSettings where module = 'FTP05'", sqlConnection);
				DataTable dataTable = new DataTable();
				dbDataAdapter.Fill(dataTable);
				if (dataTable.Rows.Count > 0 && dataTable.Rows[0]["Settings"] != DBNull.Value)
				{
					XmlDocument xmlDocument = new XmlDocument();
					xmlDocument.LoadXml(dataTable.Rows[0]["Settings"].ToString());
					XmlNode xmlNode = xmlDocument.SelectSingleNode("ReqForRepairFTP");
					if (xmlNode != null)
					{
						XmlNode xmlNode2 = xmlNode.SelectSingleNode("FTP");
						if (xmlNode2 != null)
						{
							XmlAttribute xmlAttribute = xmlNode2.Attributes["UseFTP"];
							if (xmlAttribute != null)
							{
								Class34.bool_0 = Convert.ToBoolean(xmlAttribute.Value);
							}
							else
							{
								Class34.bool_0 = false;
							}
							xmlAttribute = xmlNode2.Attributes["FileName"];
							if (xmlAttribute != null)
							{
								Class34.string_0 = xmlAttribute.Value;
							}
							xmlAttribute = xmlNode2.Attributes["PathName"];
							if (xmlAttribute != null)
							{
								Class34.string_1 = xmlAttribute.Value;
							}
							xmlAttribute = xmlNode2.Attributes["FTPName"];
							if (xmlAttribute != null)
							{
								Class34.string_2 = xmlAttribute.Value;
							}
							xmlAttribute = xmlNode2.Attributes["User"];
							if (xmlAttribute != null)
							{
								Class34.string_3 = xmlAttribute.Value;
							}
							xmlAttribute = xmlNode2.Attributes["Pwd"];
							if (xmlAttribute != null)
							{
								Class34.string_4 = xmlAttribute.Value;
							}
							xmlAttribute = xmlNode2.Attributes["Proxy"];
							if (xmlAttribute != null)
							{
								Class34.string_5 = xmlAttribute.Value;
								xmlAttribute = xmlNode2.Attributes["ProxyUser"];
								if (xmlAttribute != null)
								{
									Class34.string_6 = xmlAttribute.Value;
								}
								xmlAttribute = xmlNode2.Attributes["ProxyPwd"];
								if (xmlAttribute != null)
								{
									Class34.string_7 = xmlAttribute.Value;
								}
							}
							XmlNode xmlNode3 = xmlNode2.SelectSingleNode("Shedule");
							if (xmlNode3 != null)
							{
								xmlAttribute = xmlNode3.Attributes["Start"];
								if (xmlAttribute != null)
								{
									Class34.dateTime_0 = Convert.ToDateTime(xmlAttribute.Value);
								}
								xmlAttribute = xmlNode3.Attributes["Period"];
								if (xmlAttribute != null)
								{
									Class34.int_1 = Convert.ToInt32(xmlAttribute.Value);
								}
								xmlNode2 = xmlNode.SelectSingleNode("PathCURL");
								if (xmlNode2 != null && !string.IsNullOrEmpty(xmlNode2.InnerText))
								{
									Class34.string_8 = xmlNode2.InnerText;
								}
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message, ex.InnerException);
			}
		}
	}

	private static string smethod_6()
	{
		string str = "EIS\\RequestForRepair";
		string text = Path.GetTempPath() + "\\" + str + "\\";
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		return text;
	}

	internal static void smethod_7()
	{
		if (Class34.bool_0)
		{
			Class36.smethod_0(Class34.string_8, Class34.string_2, Class34.string_3, Class34.string_4, Class34.smethod_4(), Class34.string_5, Class34.string_6, Class34.string_7);
		}
	}

	// Note: this type is marked as 'beforefieldinit'.
	static Class34()
	{
		Class38.TqlX7ZmzmDDi2();
		Class34.int_0 = 920;
		Class34.bool_0 = true;
		Class34.string_0 = "plan_rabota.php";
		Class34.string_1 = "";
		Class34.string_2 = "";
		Class34.string_3 = "";
		Class34.string_4 = "";
		Class34.string_5 = "";
		Class34.string_6 = "";
		Class34.string_7 = "";
		Class34.dateTime_0 = DateTime.MinValue;
		Class34.int_1 = 0;
		Class34.string_8 = "";
	}

	private static int int_0;

	private static bool bool_0;

	private static string string_0;

	private static string string_1;

	private static string string_2;

	private static string string_3;

	private static string string_4;

	private static string string_5;

	private static string string_6;

	private static string string_7;

	private static DateTime dateTime_0;

	private static int int_1;

	private static string string_8;
}
