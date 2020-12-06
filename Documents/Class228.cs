using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using DataSql;
using SchemeModel;

internal static class Class228
{
	internal static void smethod_0(SQLSettings sqlsettings_0, DataRow dataRow_0, TextBox textBox_0, ref bool bool_0, int? nullable_0 = null)
	{
		Form28 form = new Form28();
		form.SqlSettings = sqlsettings_0;
		form.method_5(nullable_0);
		form.FormBorderStyle = FormBorderStyle.FixedDialog;
		Form form2 = form;
		form.MaximizeBox = false;
		form2.MinimizeBox = false;
		if (form.ShowDialog() == DialogResult.OK)
		{
			bool_0 = true;
			if (form.method_0().Count > 0)
			{
				dataRow_0["idSchmObj"] = form.method_0().First<KeyValuePair<int, string>>().Key;
				textBox_0.Text = form.method_0().First<KeyValuePair<int, string>>().Value;
				return;
			}
			dataRow_0["idSchmObj"] = DBNull.Value;
			textBox_0.Text = string.Empty;
		}
	}

	internal static void smethod_1(DataRow dataRow_0, Class171 class171_0, int int_0, int int_1, bool bool_0 = false, bool bool_1 = false)
	{
		dataRow_0["DateDoc"] = class171_0.tJ_Damage.Rows[0]["dateDoc"];
		dataRow_0["TypeDoc"] = int_1;
		if (Convert.ToDateTime(class171_0.tJ_Damage.Rows[0]["dateDoc"]).Year < 2016)
		{
			dataRow_0["numRequest"] = class171_0.tJ_Damage.Rows[0]["numRequest"];
		}
		dataRow_0["idCompiler"] = class171_0.tJ_Damage.Rows[0]["idCompiler"];
		dataRow_0["idDivision"] = class171_0.tJ_Damage.Rows[0]["idDivision"];
		dataRow_0["idSchmObj"] = class171_0.tJ_Damage.Rows[0]["idSchmObj"];
		dataRow_0["idStreet"] = class171_0.tJ_Damage.Rows[0]["idStreet"];
		dataRow_0["idMap"] = class171_0.tJ_Damage.Rows[0]["idMap"];
		dataRow_0["defectlocation"] = class171_0.tJ_Damage.Rows[0]["defectlocation"];
		dataRow_0["idreason"] = class171_0.tJ_Damage.Rows[0]["idreason"];
		if (bool_0)
		{
			dataRow_0["idDivisionApply"] = class171_0.tJ_Damage.Rows[0]["idDivisionApply"];
			dataRow_0["DivisionInstruction"] = class171_0.tJ_Damage.Rows[0]["DivisionInstruction"];
		}
		else
		{
			dataRow_0["idDivisionApply"] = DBNull.Value;
		}
		if (bool_1)
		{
			dataRow_0["isLaboratory"] = class171_0.tJ_Damage.Rows[0]["isLaboratory"];
			dataRow_0["DivisionInstruction"] = class171_0.tJ_Damage.Rows[0]["LaboratoryInstruction"];
		}
		else
		{
			dataRow_0["isLaboratory"] = DBNull.Value;
		}
		dataRow_0["idCompletedWorkODS"] = class171_0.tJ_Damage.Rows[0]["idCompletedWork"];
		dataRow_0["CompletedWorkTextODS"] = class171_0.tJ_Damage.Rows[0]["ComletedWorkText"];
		dataRow_0["is81"] = class171_0.tJ_Damage.Rows[0]["is81"];
		dataRow_0["idParent"] = int_0;
	}

	internal static DataTable MyrCoTyHjHw()
	{
		return new DataTable("tR_KladrObj")
		{
			Columns = 
			{
				{
					"id",
					typeof(int)
				},
				{
					"parentid",
					typeof(int)
				},
				{
					"name",
					typeof(string)
				},
				{
					"primarykey",
					typeof(string)
				},
				{
					"socr",
					typeof(string)
				},
				{
					"fullname",
					typeof(string),
					"name + isnull(' ' + socr, '')"
				}
			}
		};
	}

	internal static DataTable smethod_2()
	{
		return new DataTable("tR_KladrStreet")
		{
			Columns = 
			{
				{
					"id",
					typeof(int)
				},
				{
					"KladrObjId",
					typeof(int)
				},
				{
					"name",
					typeof(string)
				},
				{
					"socr",
					typeof(string)
				},
				{
					"fullname",
					typeof(string),
					"name + isnull(' ' + socr, '')"
				}
			}
		};
	}

	internal static XmlDocument smethod_3(DataTable dataTable_0)
	{
		XmlDocument xmlDocument = new XmlDocument();
		XmlNode xmlNode = xmlDocument.CreateElement("AbnOff");
		xmlDocument.AppendChild(xmlNode);
		foreach (object obj in dataTable_0.Rows)
		{
			DataRow dataRow = (DataRow)obj;
			if (dataRow.RowState != DataRowState.Deleted)
			{
				XmlNode xmlNode2 = xmlDocument.CreateElement("Row");
				xmlNode.AppendChild(xmlNode2);
				XmlAttribute xmlAttribute = xmlDocument.CreateAttribute("idAbnObj");
				xmlAttribute.Value = dataRow["idAbnObj"].ToString();
				xmlNode2.Attributes.Append(xmlAttribute);
			}
		}
		return xmlDocument;
	}

	internal static void smethod_4(DataTable dataTable_0, DataTable dataTable_1, SQLSettings sqlsettings_0)
	{
		dataTable_1.Clear();
		if (dataTable_0.Rows.Count > 0 && dataTable_0.Rows[0]["AbnOff"] != DBNull.Value)
		{
			try
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.LoadXml(dataTable_0.Rows[0]["AbnOff"].ToString());
				XmlNode xmlNode = xmlDocument.SelectSingleNode("AbnOff");
				if (xmlNode != null)
				{
					List<string> list = new List<string>();
					foreach (object obj in xmlNode.SelectNodes("Row"))
					{
						XmlAttribute xmlAttribute = ((XmlNode)obj).Attributes["idAbnObj"];
						if (xmlAttribute != null && !string.IsNullOrEmpty(xmlAttribute.Value))
						{
							list.Add(xmlAttribute.Value);
						}
					}
					if (list.Count > 0)
					{
						new SqlDataCommand(sqlsettings_0).SelectSqlData(dataTable_1, true, " where idAbnObj in (" + string.Join(",", list.ToArray()) + ") and abnActive = 1 and objactive = 1  group by idAbn, codeAbonent, nameAbn, typeAbn, idAbnObj, nameObj, commentODS ", new int?(0), false, 0);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, ex.Source);
			}
		}
	}

	internal static void smethod_5(DataTable dataTable_0, DataTable dataTable_1, SQLSettings sqlsettings_0)
	{
		dataTable_1.Clear();
		if (dataTable_0.Rows.Count > 0 && dataTable_0.Rows[0]["CommentXml"] != DBNull.Value)
		{
			try
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.LoadXml(dataTable_0.Rows[0]["CommentXml"].ToString());
				XmlNode xmlNode = xmlDocument.SelectSingleNode("Doc");
				if (xmlNode != null)
				{
					XmlNode xmlNode2 = xmlNode.SelectSingleNode("AbnOff");
					if (xmlNode2 != null)
					{
						List<string> list = new List<string>();
						foreach (object obj in xmlNode2.SelectNodes("Row"))
						{
							XmlAttribute xmlAttribute = ((XmlNode)obj).Attributes["idAbnObj"];
							if (xmlAttribute != null && !string.IsNullOrEmpty(xmlAttribute.Value))
							{
								list.Add(xmlAttribute.Value);
							}
						}
						if (list.Count > 0)
						{
							DateTime dateTime = DateTime.Now;
							if (dataTable_0.Rows[0]["DateDoc"] != DBNull.Value)
							{
								dateTime = Convert.ToDateTime(dataTable_0.Rows[0]["DateDoc"]);
							}
							string text = "select ";
							foreach (object obj2 in dataTable_1.Columns)
							{
								DataColumn dataColumn = (DataColumn)obj2;
								if (dataColumn.ColumnName.ToLower() != "countpoint")
								{
									text = text + "[" + dataColumn.ColumnName + "], ";
								}
							}
							text += string.Format("(select count(id) from tPoint where idAbnObj = vl_SChmAbnFull.idAbnObj \r\n                                                    and dateBegin <= '{0}' \r\n                                                    and (dateEnd >= '{0}' or dateEnd is null)) as countPoint ", dateTime.ToString("yyyyMMdd"));
							text = text + " from " + dataTable_1.TableName;
							text = text + " where idAbnObj in (" + string.Join(",", list.ToArray()) + ") and abnActive = 1 and objactive = 1 ";
							text += " group by ";
							for (int i = 0; i < dataTable_1.Columns.Count; i++)
							{
								if (dataTable_1.Columns[i].ColumnName.ToLower() != "countpoint")
								{
									if (i == 0)
									{
										text = text + "[" + dataTable_1.Columns[i].ColumnName + "]";
									}
									else
									{
										text = text + ",[" + dataTable_1.Columns[i].ColumnName + "]";
									}
								}
							}
							using (SqlConnection sqlConnection = new SqlConnection(sqlsettings_0.GetConnectionString()))
							{
								dataTable_1.Clear();
								sqlConnection.Open();
								using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(text, sqlConnection))
								{
									sqlDataAdapter.SelectCommand.CommandTimeout = 0;
									sqlDataAdapter.Fill(dataTable_1);
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
	}

	internal static void smethod_6(DataTable dataTable_0, SQLSettings sqlsettings_0, List<ElectricObject> list_0, DateTime dateTime_0)
	{
		if (list_0 != null && list_0.Count != 0)
		{
			string text = "";
			foreach (ElectricObject electricObject in list_0)
			{
				if (string.IsNullOrEmpty(text))
				{
					text = electricObject.Id.ToString();
				}
				else
				{
					text = text + "," + electricObject.Id.ToString();
				}
			}
			string text2 = "select ";
			foreach (object obj in dataTable_0.Columns)
			{
				DataColumn dataColumn = (DataColumn)obj;
				if (dataColumn.ColumnName.ToLower() != "countpoint")
				{
					text2 = text2 + "[" + dataColumn.ColumnName + "], ";
				}
			}
			text2 += string.Format("(select count(id) from tPoint where idAbnObj = vl_SChmAbnFull.idAbnObj \r\n                                                    and dateBegin <= '{0}' \r\n                                                    and (dateEnd >= '{0}' or dateEnd is null)) as countPoint ", dateTime_0.ToString("yyyyMMdd"));
			text2 = text2 + " from " + dataTable_0.TableName;
			text2 = text2 + " where idSchmObj in (" + text + ") and abnActive = 1 and objactive = 1 ";
			text2 += " group by ";
			for (int i = 0; i < dataTable_0.Columns.Count; i++)
			{
				if (dataTable_0.Columns[i].ColumnName.ToLower() != "countpoint")
				{
					if (i == 0)
					{
						text2 = text2 + "[" + dataTable_0.Columns[i].ColumnName + "]";
					}
					else
					{
						text2 = text2 + ",[" + dataTable_0.Columns[i].ColumnName + "]";
					}
				}
			}
			using (SqlConnection sqlConnection = new SqlConnection(sqlsettings_0.GetConnectionString()))
			{
				dataTable_0.Clear();
				sqlConnection.Open();
				using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(text2, sqlConnection))
				{
					sqlDataAdapter.SelectCommand.CommandTimeout = 0;
					sqlDataAdapter.Fill(dataTable_0);
				}
			}
			return;
		}
		dataTable_0.Clear();
	}
}
