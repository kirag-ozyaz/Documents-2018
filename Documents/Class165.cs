using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DataSql;

internal static class Class165
{
	private static DataTable smethod_0(SQLSettings sqlsettings_0, DateTime dateTime_0, bool bool_0, bool bool_1)
	{
		SqlDataCommand sqlDataCommand = new SqlDataCommand(sqlsettings_0);
		DataTable dataTable = sqlDataCommand.SelectSqlData("vAbnType", true, " where typeKontragent = " + 1115.ToString(), null);
		string text = "";
		foreach (object obj in dataTable.Rows)
		{
			DataRow dataRow = (DataRow)obj;
			if (!string.IsNullOrEmpty(text))
			{
				text += ",";
			}
			text += dataRow["idAbn"].ToString();
		}
		string text2 = "";
		if (!string.IsNullOrEmpty(text))
		{
			if (bool_1)
			{
				text2 = text2 + " and (vj_excavation.idContractor in (" + text + ")) ";
			}
			else
			{
				text2 = text2 + " and (vj_excavation.idContractor not in (" + text + ")) ";
			}
		}
		string text3 = bool_0 ? " and vj_excavation.agreed = 1 " : "";
		string where = string.Concat(new string[]
		{
			"left join tj_excavationstatus sOrder on sOrder.id = (select top 1 id from tj_excavationstatus where idExcavation = vj_excavation.id and idType = 1  and datechange <= '",
			dateTime_0.ToString("yyyyMMdd"),
			"' order by datechange desc) left join tr_classifier cOrder on cOrder.id = sOrder.idStatus left join tj_excavationstatus sWork on sWork.id = (select top 1 id from tj_excavationstatus where idExcavation = vj_excavation.id and idType = 2  and datechange <= '",
			dateTime_0.ToString("yyyyMMdd"),
			"'  order by datechange desc) left join tr_classifier cStatusWork on cStatusWork.id = sWork.idStatus where cOrder.value not in (1,6) and cStatusWork.ParentKey <> ';Excavation;StatusWork;RealEnd;'  and (vj_excavation.dateBeg <= '",
			dateTime_0.ToString("yyyyMMdd"),
			"') and (vj_excavation.dateend is null or vj_excavation.dateEnd >= '",
			dateTime_0.ToString("yyyyMMdd"),
			"') ",
			text3,
			text2,
			" order by vj_excavation.region, vj_excavation.address"
		});
		return sqlDataCommand.SelectSqlData("vJ_Excavation", true, where, null);
	}

	private static void smethod_1(StringBuilder stringBuilder_0, DataTable dataTable_0)
	{
		string text = "";
		for (int i = 0; i < dataTable_0.Rows.Count; i++)
		{
			DataRow dataRow = dataTable_0.Rows[i];
			if (text != dataRow["region"].ToString())
			{
				text = dataRow["region"].ToString();
				stringBuilder_0.Append("<TR>\n");
				string str = string.IsNullOrEmpty(text) ? "&nbsp" : (text + " район");
				stringBuilder_0.Append("<TD VALIGN=CENTER BGCOLOR=#c0dcc0 COLSPAN=6><FONT SIZE=2><I><B>" + str + "</B></I></FONT>\n");
				stringBuilder_0.Append("</tr>\n");
			}
			stringBuilder_0.Append("<TR>\n");
			if (dataRow["address"] != DBNull.Value)
			{
				stringBuilder_0.Append("<TD width=\"150\" VALIGN=CENTER><FONT SIZE=2>" + dataRow["address"].ToString() + "</FONT>\n");
			}
			else
			{
				stringBuilder_0.Append("<TD width=\"150\" VALIGN=CENTER><FONT SIZE=2>&nbsp</FONT>\n");
			}
			if (dataRow["permission"] != DBNull.Value)
			{
				stringBuilder_0.Append("<TD width=\"80\" VALIGN=CENTER><FONT SIZE=2>" + dataRow["permission"].ToString() + "</FONT>\n");
			}
			else
			{
				stringBuilder_0.Append("<TD width=\"80\" VALIGN=CENTER><FONT SIZE=2>&nbsp</FONT>\n");
			}
			string text2 = string.Concat(new string[]
			{
				dataRow["typeWorkName"].ToString(),
				", (",
				dataRow["nameKL"].ToString(),
				"),\n<br>",
				dataRow["StatusWork"].ToString()
			});
			if (string.IsNullOrEmpty(text2))
			{
				text2 = "&nbsp";
			}
			stringBuilder_0.Append("<TD width=\"300\" VALIGN=CENTER><FONT SIZE=2>" + text2 + "</FONT>\n");
			if (dataRow["damage"] != DBNull.Value)
			{
				stringBuilder_0.Append("<TD width=\"100\" VALIGN=CENTER><FONT SIZE=2>" + dataRow["damage"].ToString() + "</FONT>\n");
			}
			else
			{
				stringBuilder_0.Append("<TD width=\"100\" VALIGN=CENTER><FONT SIZE=2>&nbsp</FONT>\n");
			}
			string str2 = (dataRow["dateEndorder"] == DBNull.Value) ? "--.--.----" : Convert.ToDateTime(dataRow["dateEndorder"]).ToString("dd.MM.yyyy");
			text2 = "ордер " + dataRow["statusorder"].ToString() + "\n<br>до " + str2;
			stringBuilder_0.Append("<TD width=\"150\" VALIGN=CENTER><FONT SIZE=2>" + text2 + "</FONT>\n");
			stringBuilder_0.Append("</tr>\n");
			i = i++;
		}
	}

	internal static bool smethod_2(SQLSettings sqlsettings_0, string string_0, DateTime dateTime_0, bool bool_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("<html>\n");
		stringBuilder.Append("<head>\n");
		stringBuilder.Append("<title></title>\n");
		stringBuilder.Append("<BASEFONT FACE=\"Arial\" SIZE=8>\n");
		stringBuilder.Append("</head>\n");
		stringBuilder.Append("<body>\n");
		stringBuilder.Append("<TABLE BORDER CELLSPACING=0 style=\"word-wrap: break-word\">\n");
		stringBuilder.Append("<TR>\n");
		stringBuilder.Append("<TD ALIGN=CENTER BORDERCOLOR=#ffffff COLSPAN=5><FONT SIZE=2><I><B>Сведения о земляных работах МУП \"УльГЭС\"</B></I></FONT>\n");
		stringBuilder.Append("</tr>\n");
		stringBuilder.Append("<TR>\n");
		stringBuilder.Append("<TD ALIGN=RIGHT BORDERCOLOR=#ffffff COLSPAN=5><FONT SIZE=2><I><B>по состоянию на " + dateTime_0.ToShortDateString() + "г.</B></I></FONT>\n");
		stringBuilder.Append("</tr>\n");
		stringBuilder.Append("<TR>\n");
		stringBuilder.Append("<TD width=\"150\" ALIGN=CENTER VALIGN=CENTER><FONT SIZE=2><B>Адрес</B></FONT>\n");
		stringBuilder.Append("<TD width=\"80\"  ALIGN=CENTER VALIGN=CENTER><FONT SIZE=2><B>Номер, дата разрешения</B></FONT>\n");
		stringBuilder.Append("<TD width=\"300\" ALIGN=CENTER VALIGN=CENTER><FONT SIZE=2><B>Характер и состояние земляных работ</B></FONT>\n");
		stringBuilder.Append("<TD width=\"100\" ALIGN=CENTER VALIGN=CENTER><FONT SIZE=2><B>Место производства работ</B></FONT>\n");
		stringBuilder.Append("<TD width=\"150\" ALIGN=CENTER VALIGN=CENTER><FONT SIZE=2><B>Срок сдачи разрешения</B></FONT>\n");
		stringBuilder.Append("</tr>\n");
		DataTable dataTable = Class165.smethod_0(sqlsettings_0, dateTime_0, bool_0, true);
		Class165.smethod_1(stringBuilder, dataTable);
		dataTable = Class165.smethod_0(sqlsettings_0, dateTime_0, bool_0, false);
		if (dataTable.Rows.Count > 0)
		{
			stringBuilder.Append("<TR>\n");
			stringBuilder.Append("<TD ALIGN=CENTER VALIGN=CENTER BGCOLOR=#808080 COLSPAN=6><FONT SIZE=2><I><B>Земляные работы, выполняемые подрядчиками</B></I></FONT>\n");
			stringBuilder.Append("</tr>\n");
		}
		Class165.smethod_1(stringBuilder, dataTable);
		stringBuilder.Append("</table>\n");
		stringBuilder.Append("</body>\n");
		stringBuilder.Append("</html>\n");
		return Class165.smethod_3(string_0, stringBuilder);
	}

	private static bool smethod_3(string string_0, StringBuilder stringBuilder_0)
	{
		bool result;
		try
		{
			File.Delete(string_0);
			StreamWriter streamWriter = new StreamWriter(string_0, true, Encoding.Unicode);
			streamWriter.Write(stringBuilder_0.ToString());
			streamWriter.Close();
			result = true;
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			result = false;
		}
		return result;
	}
}
