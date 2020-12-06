using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Xml;
using DataSql;
using Microsoft.Office.Interop.Excel;
using SchemeModel;
using SchemeModel.Calculations;

internal class Class222
{
	internal static void smethod_0(string string_0, SQLSettings sqlsettings_0)
	{
		int num = 0;
		try
		{
			Microsoft.Office.Interop.Excel.Application application = new ApplicationClass();
			application.Visible = true;
			Workbook workbook = application.Workbooks.Open(string_0, 0, false, 5, "", "", false, XlPlatform.xlWindows, "", true, false, 0, true, false, false);
			try
			{
				Range usedRange = ((Worksheet)workbook.ActiveSheet).UsedRange;
				for (int i = 5; i <= usedRange.Rows.Count; i++)
				{
					Class171 @class = new Class171();
					@class.tJ_Damage.Columns.Add("commentXml", typeof(string));
					DataRow newRD = @class.tJ_Damage.NewRow();
					newRD["TypeDoc"] = 1402;
					newRD["idCompiler"] = 255;
					newRD["idDivision"] = 1405;
					DataRow dataRow = @class.tJ_DamageOn.NewRow();
					dataRow["idDamage"] = -1;
					dataRow["countSchmObj"] = 0;
					DataRow dataRow2 = @class.tJ_DamageHV.NewRow();
					dataRow2["idDamage"] = -1;
					dataRow2["coefFI"] = 0.9;
					dataRow2["coefseason"] = 0.8;
					DataRow dataRow3 = @class.tJ_DamageCharacter.NewRow();
					dataRow3["idDamage"] = -1;
					num++;
					if (num == 64)
					{
					}
					SQLSettings sqlsettings = new SQLSettings("ulges-sql2", "ges", "WINDOWS", "", "");
					SqlDataCommand sqlDataCommand = new SqlDataCommand(sqlsettings);
					XmlDocument xmlDocument = new XmlDocument();
					XmlNode xmlNode = xmlDocument.CreateElement("Doc");
					xmlDocument.AppendChild(xmlNode);
					XmlNode xmlNode2 = xmlDocument.CreateElement("Row");
					xmlNode.AppendChild(xmlNode2);
					XmlNode xmlNode3 = xmlDocument.CreateElement("Comment");
					xmlNode.AppendChild(xmlNode3);
					XmlAttribute xmlAttribute = xmlDocument.CreateAttribute("NYear");
					if ((usedRange.Cells[i, 1] as Range).get_Value(Type.Missing) != null)
					{
						xmlAttribute.Value = (usedRange.Cells[i, 1] as Range).get_Value(Type.Missing).ToString();
					}
					xmlNode3.Attributes.Append(xmlAttribute);
					xmlAttribute = xmlDocument.CreateAttribute("ClassificationDamage");
					if ((usedRange.Cells[i, 2] as Range).get_Value(Type.Missing) != null)
					{
						xmlAttribute.Value = (usedRange.Cells[i, 2] as Range).get_Value(Type.Missing).ToString();
					}
					xmlNode3.Attributes.Append(xmlAttribute);
					xmlAttribute = xmlDocument.CreateAttribute("NMonth");
					if ((usedRange.Cells[i, 3] as Range).get_Value(Type.Missing) != null)
					{
						xmlAttribute.Value = (usedRange.Cells[i, 3] as Range).get_Value(Type.Missing).ToString();
					}
					xmlNode3.Attributes.Append(xmlAttribute);
					DateTime dateTime = new DateTime(2015, 1, 1);
					xmlAttribute = xmlDocument.CreateAttribute("DateOff");
					if ((usedRange.Cells[i, 6] as Range).get_Value(Type.Missing) != null && !string.IsNullOrEmpty((usedRange.Cells[i, 6] as Range).get_Value(Type.Missing).ToString()))
					{
						dateTime = Convert.ToDateTime((usedRange.Cells[i, 6] as Range).get_Value(Type.Missing).ToString());
					}
					if ((usedRange.Cells[i, 7] as Range).get_Value(Type.Missing) != null && !string.IsNullOrEmpty((usedRange.Cells[i, 7] as Range).get_Value(Type.Missing).ToString()))
					{
						TimeSpan timeOfDay = Convert.ToDateTime(Class222.smethod_1((usedRange.Cells[i, 7] as Range).get_Value(Type.Missing).ToString())).TimeOfDay;
						dateTime = dateTime.Add(timeOfDay);
					}
					xmlAttribute.Value = dateTime.ToString();
					xmlNode2.Attributes.Append(xmlAttribute);
					newRD["dateDoc"] = dateTime;
					DateTime dateTime2 = dateTime;
					xmlAttribute = xmlDocument.CreateAttribute("DateOn");
					if ((usedRange.Cells[i, 8] as Range).get_Value(Type.Missing) != null && !string.IsNullOrEmpty((usedRange.Cells[i, 8] as Range).get_Value(Type.Missing).ToString()))
					{
						dateTime2 = Convert.ToDateTime((usedRange.Cells[i, 8] as Range).get_Value(Type.Missing).ToString());
					}
					if ((usedRange.Cells[i, 9] as Range).get_Value(Type.Missing) != null && !string.IsNullOrEmpty((usedRange.Cells[i, 9] as Range).get_Value(Type.Missing).ToString()))
					{
						TimeSpan timeOfDay2 = Convert.ToDateTime(Class222.smethod_1((usedRange.Cells[i, 9] as Range).get_Value(Type.Missing).ToString())).TimeOfDay;
						dateTime2 = dateTime2.Add(timeOfDay2);
					}
					xmlAttribute.Value = dateTime2.ToString();
					xmlNode2.Attributes.Append(xmlAttribute);
					newRD["isApply"] = true;
					newRD["dateApply"] = dateTime2;
					dataRow["dateOn"] = dateTime2;
					xmlAttribute = xmlDocument.CreateAttribute("SR");
					if ((usedRange.Cells[i, 10] as Range).get_Value(Type.Missing) != null)
					{
						xmlAttribute.Value = (usedRange.Cells[i, 10] as Range).get_Value(Type.Missing).ToString();
					}
					xmlNode3.Attributes.Append(xmlAttribute);
					xmlAttribute = xmlDocument.CreateAttribute("SchmName");
					if ((usedRange.Cells[i, 11] as Range).get_Value(Type.Missing) != null && !string.IsNullOrEmpty((usedRange.Cells[i, 11] as Range).get_Value(Type.Missing).ToString()))
					{
						string str = (usedRange.Cells[i, 11] as Range).get_Value(Type.Missing).ToString();
						xmlAttribute.Value = (usedRange.Cells[i, 11] as Range).get_Value(Type.Missing).ToString();
						System.Data.DataTable dataTable = sqlDataCommand.SelectSqlData("vSchm_ObjList", true, "where (typeCodeSocr+'-'+name) = '" + str + "' and deleted = 0 ", null);
						if (dataTable.Rows.Count > 0)
						{
							XmlAttribute xmlAttribute2 = xmlDocument.CreateAttribute("SchmId");
							xmlAttribute2.Value = dataTable.Rows[0]["id"].ToString();
							newRD["idSchmObj"] = dataTable.Rows[0]["id"];
							xmlNode2.Attributes.Append(xmlAttribute2);
						}
						if ((usedRange.Cells[i, 12] as Range).get_Value(Type.Missing) != null && !string.IsNullOrEmpty((usedRange.Cells[i, 12] as Range).get_Value(Type.Missing).ToString()))
						{
							string text = (usedRange.Cells[i, 12] as Range).get_Value(Type.Missing).ToString();
							XmlAttribute xmlAttribute3 = xmlDocument.CreateAttribute("CellName");
							xmlAttribute3.Value = text;
							xmlNode2.Attributes.Append(xmlAttribute3);
							if (dataTable.Rows.Count > 0)
							{
								System.Data.DataTable dataTable2 = sqlDataCommand.SelectSqlData("vSchm_ObjList", true, string.Concat(new string[]
								{
									"where idParent = ",
									dataTable.Rows[0]["id"].ToString(),
									" and typeCodeId in (672,674,675,676) and deleted = 0 and name = '",
									text,
									"'"
								}), null);
								if (dataTable2.Rows.Count > 0)
								{
									XmlAttribute xmlAttribute4 = xmlDocument.CreateAttribute("CellId");
									xmlAttribute4.Value = dataTable2.Rows[0]["Id"].ToString();
									newRD["idSchmObj"] = dataTable2.Rows[0]["Id"];
									xmlNode2.Attributes.Append(xmlAttribute4);
									int num2 = Convert.ToInt32(dataTable2.Rows[0]["TypeCodeId"]);
									if (num2 != 675)
									{
										if (num2 == 676)
										{
											dataRow2["PowerV"] = 10;
										}
									}
									else
									{
										dataRow2["PowerV"] = 6;
									}
								}
							}
						}
					}
					xmlNode2.Attributes.Append(xmlAttribute);
					if ((usedRange.Cells[i, 13] as Range).get_Value(Type.Missing) != null && !string.IsNullOrEmpty((usedRange.Cells[i, 13] as Range).get_Value(Type.Missing).ToString()))
					{
						xmlAttribute = xmlDocument.CreateAttribute("TypeRZA");
						xmlAttribute.Value = (usedRange.Cells[i, 13] as Range).get_Value(Type.Missing).ToString();
						xmlNode2.Attributes.Append(xmlAttribute);
						System.Data.DataTable dataTable3 = sqlDataCommand.SelectSqlData("tr_classifier", true, " where PArentId = 1566 and Name = '" + xmlAttribute.Value + "'", null);
						if (dataTable3.Rows.Count > 0)
						{
							xmlAttribute = xmlDocument.CreateAttribute("TypeRZA");
							xmlAttribute.Value = dataTable3.Rows[0]["id"].ToString();
							dataRow2["idTypeRZA"] = dataTable3.Rows[0]["id"];
							xmlNode2.Attributes.Append(xmlAttribute);
						}
					}
					if ((usedRange.Cells[i, 14] as Range).get_Value(Type.Missing) != null && !string.IsNullOrEmpty((usedRange.Cells[i, 14] as Range).get_Value(Type.Missing).ToString()))
					{
						xmlAttribute = xmlDocument.CreateAttribute("col1Name");
						xmlAttribute.Value = (usedRange.Cells[i, 14] as Range).get_Value(Type.Missing).ToString();
						xmlNode2.Attributes.Append(xmlAttribute);
						System.Data.DataTable dataTable4 = sqlDataCommand.SelectSqlData("tr_classifier", true, " where PArentId = 1438 and Name like '%" + xmlAttribute.Value + "%'", null);
						if (dataTable4.Rows.Count > 0)
						{
							xmlAttribute = xmlDocument.CreateAttribute("col1");
							xmlAttribute.Value = dataTable4.Rows[0]["id"].ToString();
							dataRow3["col1"] = dataTable4.Rows[0]["id"];
							xmlNode2.Attributes.Append(xmlAttribute);
							if ((usedRange.Cells[i, 17] as Range).get_Value(Type.Missing) != null && !string.IsNullOrEmpty((usedRange.Cells[i, 17] as Range).get_Value(Type.Missing).ToString()))
							{
								xmlAttribute = xmlDocument.CreateAttribute("col2Name");
								xmlAttribute.Value = (usedRange.Cells[i, 17] as Range).get_Value(Type.Missing).ToString();
								xmlNode2.Attributes.Append(xmlAttribute);
								System.Data.DataTable dataTable5 = sqlDataCommand.SelectSqlData("tr_classifier", true, string.Concat(new string[]
								{
									" where PArentId = ",
									dataTable4.Rows[0]["id"].ToString(),
									" and Name like '%",
									xmlAttribute.Value,
									"%'"
								}), null);
								if (dataTable5.Rows.Count > 0)
								{
									xmlAttribute = xmlDocument.CreateAttribute("col2");
									xmlAttribute.Value = dataTable5.Rows[0]["id"].ToString();
									dataRow3["col2"] = dataTable5.Rows[0]["id"];
									xmlNode2.Attributes.Append(xmlAttribute);
								}
							}
						}
					}
					if ((usedRange.Cells[i, 15] as Range).get_Value(Type.Missing) != null && !string.IsNullOrEmpty((usedRange.Cells[i, 15] as Range).get_Value(Type.Missing).ToString()))
					{
						xmlAttribute = xmlDocument.CreateAttribute("Accessory");
						xmlAttribute.Value = (usedRange.Cells[i, 15] as Range).get_Value(Type.Missing).ToString();
						xmlNode2.Attributes.Append(xmlAttribute);
					}
					if ((usedRange.Cells[i, 16] as Range).get_Value(Type.Missing) != null && !string.IsNullOrEmpty((usedRange.Cells[i, 16] as Range).get_Value(Type.Missing).ToString()))
					{
						xmlAttribute = xmlDocument.CreateAttribute("Location");
						xmlAttribute.Value = (usedRange.Cells[i, 16] as Range).get_Value(Type.Missing).ToString();
						newRD["DefectLocation"] = xmlAttribute.Value;
						xmlNode2.Attributes.Append(xmlAttribute);
					}
					newRD["ComletedWorkText"] = "";
					if ((usedRange.Cells[i, 18] as Range).get_Value(Type.Missing) != null && !string.IsNullOrEmpty((usedRange.Cells[i, 18] as Range).get_Value(Type.Missing).ToString()))
					{
						xmlAttribute = xmlDocument.CreateAttribute("Responsible");
						xmlAttribute.Value = (usedRange.Cells[i, 18] as Range).get_Value(Type.Missing).ToString();
						DataRow newRD2 = newRD;
						newRD2["ComletedWorkText"] = newRD2["ComletedWorkText"] + xmlAttribute.Value;
						xmlNode3.Attributes.Append(xmlAttribute);
					}
					if ((usedRange.Cells[i, 19] as Range).get_Value(Type.Missing) != null && !string.IsNullOrEmpty((usedRange.Cells[i, 19] as Range).get_Value(Type.Missing).ToString()))
					{
						xmlAttribute = xmlDocument.CreateAttribute("Nokwt");
						string s = (usedRange.Cells[i, 19] as Range).get_Value(Type.Missing).ToString();
						decimal num3 = 0m;
						decimal.TryParse(s, out num3);
						xmlAttribute.Value = num3.ToString();
						dataRow["noAdmissionKWT"] = num3;
						dataRow2["NoAdmissionKWT"] = num3;
						xmlNode3.Attributes.Append(xmlAttribute);
					}
					if ((usedRange.Cells[i, 22] as Range).get_Value(Type.Missing) != null && !string.IsNullOrEmpty((usedRange.Cells[i, 22] as Range).get_Value(Type.Missing).ToString()))
					{
						xmlAttribute = xmlDocument.CreateAttribute("Reason");
						string text2 = (usedRange.Cells[i, 22] as Range).get_Value(Type.Missing).ToString();
						xmlAttribute.Value = text2;
						DataRow newRD2 = newRD;
						newRD2["ComletedWorkText"] = newRD2["ComletedWorkText"] + "\r\n" + text2;
						xmlNode3.Attributes.Append(xmlAttribute);
					}
					if ((usedRange.Cells[i, 23] as Range).get_Value(Type.Missing) != null && !string.IsNullOrEmpty((usedRange.Cells[i, 23] as Range).get_Value(Type.Missing).ToString()))
					{
						xmlAttribute = xmlDocument.CreateAttribute("Comment");
						string text3 = (usedRange.Cells[i, 23] as Range).get_Value(Type.Missing).ToString();
						xmlAttribute.Value = text3;
						DataRow newRD2 = newRD;
						newRD2["ComletedWorkText"] = newRD2["ComletedWorkText"] + "\r\n" + text3;
						xmlNode3.Attributes.Append(xmlAttribute);
					}
					if ((usedRange.Cells[i, 24] as Range).get_Value(Type.Missing) != null && !string.IsNullOrEmpty((usedRange.Cells[i, 24] as Range).get_Value(Type.Missing).ToString()))
					{
						xmlAttribute = xmlDocument.CreateAttribute("CommentX");
						string text4 = (usedRange.Cells[i, 24] as Range).get_Value(Type.Missing).ToString();
						xmlAttribute.Value = text4;
						DataRow newRD2 = newRD;
						newRD2["ComletedWorkText"] = newRD2["ComletedWorkText"] + "\r\n" + text4;
						xmlNode3.Attributes.Append(xmlAttribute);
					}
					if ((usedRange.Cells[i, 25] as Range).get_Value(Type.Missing) != null && !string.IsNullOrEmpty((usedRange.Cells[i, 25] as Range).get_Value(Type.Missing).ToString()))
					{
						xmlAttribute = xmlDocument.CreateAttribute("CommentY");
						string text5 = (usedRange.Cells[i, 25] as Range).get_Value(Type.Missing).ToString();
						xmlAttribute.Value = text5;
						DataRow newRD2 = newRD;
						newRD2["ComletedWorkText"] = newRD2["ComletedWorkText"] + "\r\n" + text5;
						xmlNode3.Attributes.Append(xmlAttribute);
					}
					if ((usedRange.Cells[i, 26] as Range).get_Value(Type.Missing) != null && !string.IsNullOrEmpty((usedRange.Cells[i, 26] as Range).get_Value(Type.Missing).ToString()))
					{
						xmlAttribute = xmlDocument.CreateAttribute("CommentZ");
						string text6 = (usedRange.Cells[i, 26] as Range).get_Value(Type.Missing).ToString();
						xmlAttribute.Value = text6;
						DataRow newRD2 = newRD;
						newRD2["ComletedWorkText"] = newRD2["ComletedWorkText"] + "\r\n" + text6;
						xmlNode3.Attributes.Append(xmlAttribute);
					}
					if ((usedRange.Cells[i, 27] as Range).get_Value(Type.Missing) != null && !string.IsNullOrEmpty((usedRange.Cells[i, 27] as Range).get_Value(Type.Missing).ToString()))
					{
						xmlAttribute = xmlDocument.CreateAttribute("CommentAA");
						string text7 = (usedRange.Cells[i, 27] as Range).get_Value(Type.Missing).ToString();
						xmlAttribute.Value = text7;
						DataRow newRD2 = newRD;
						newRD2["ComletedWorkText"] = newRD2["ComletedWorkText"] + "\r\n" + text7;
						xmlNode3.Attributes.Append(xmlAttribute);
					}
					newRD["CommentXml"] = xmlDocument.InnerXml;
					if (newRD["idSchmObj"] != DBNull.Value)
					{
						ElectricModel electricModel = new ElectricModel();
						electricModel.SqlSettings = sqlsettings;
						electricModel.LoadSchema(dateTime);
						TreeNodeObj treeNodeObj_ = electricModel.PoweringReportForDrawObject(Convert.ToInt32(newRD["idSchmObj"]), true);
						List<int> list_ = new List<int>();
						Class222.smethod_3(treeNodeObj_, list_);
						System.Data.DataTable dataTable6 = Class222.smethod_4(list_, sqlsettings);
						IEnumerable<ElectricObject> source = from obj in electricModel.Objects
						where obj.Id == Convert.ToInt32(newRD["idSchmObj"])
						select obj;
						List<ElectricObject> list = electricModel.PoweringReportForDrawObject(source.First<ElectricObject>(), true, true);
						System.Data.DataTable dataTable7 = new System.Data.DataTable("vl_schmAbnFull");
						dataTable7.Columns.Add("idAbn", typeof(int));
						dataTable7.Columns.Add("idAbnObj", typeof(int));
						if (list.Count > 0)
						{
							string text8 = "";
							foreach (ElectricObject electricObject in list)
							{
								if (string.IsNullOrEmpty(text8))
								{
									text8 = electricObject.Id.ToString();
								}
								else
								{
									text8 = text8 + "," + electricObject.Id.ToString();
								}
							}
							sqlDataCommand.SelectSqlData(dataTable7, true, " where idSchmObj in (" + text8 + ") and abnActive = 1 and objactive = 1  group by idAbn, codeAbonent, nameAbn, typeAbn, idAbnObj, nameObj ", new int?(0), false, 0);
						}
						else
						{
							dataTable7.Clear();
						}
						dataRow["countSchmObj"] = dataTable6.Rows.Count;
						dataRow2["countSchmObj"] = dataTable6.Rows.Count;
						dataRow2["countSchmObjOff"] = 0;
						dataRow2["ConnectedPower"] = dataTable6.Compute("Sum(Power)", "");
						dataRow2["PowerA"] = dataTable6.Compute("Sum(Load)", "");
						dataRow2["TransOff"] = Class222.smethod_2(dataTable6).InnerXml;
						dataRow2["AbnOff"] = Class228.smethod_3(dataTable7).InnerXml;
					}
					@class.tJ_Damage.Rows.Add(newRD);
					@class.tJ_DamageCharacter.Rows.Add(dataRow3);
					@class.tJ_DamageHV.Rows.Add(dataRow2);
					@class.tJ_DamageOn.Rows.Add(dataRow);
					SqlDataCommand sqlDataCommand2 = new SqlDataCommand(sqlsettings_0);
					int num4 = sqlDataCommand2.InsertSqlDataOneRow(@class.tJ_Damage);
					if (num4 > 0)
					{
						@class.tJ_DamageCharacter.Rows[0]["idDamage"] = num4;
						@class.tJ_DamageCharacter.Rows[0].EndEdit();
						sqlDataCommand2.InsertSqlData(@class, @class.tJ_DamageCharacter);
						@class.tJ_DamageHV.Rows[0]["idDamage"] = num4;
						@class.tJ_DamageHV.Rows[0].EndEdit();
						sqlDataCommand2.InsertSqlData(@class, @class.tJ_DamageHV);
						@class.tJ_DamageOn.Rows[0]["idDamage"] = num4;
						@class.tJ_DamageOn.Rows[0].EndEdit();
						sqlDataCommand2.InsertSqlData(@class, @class.tJ_DamageOn);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + num.ToString(), string_0);
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
	}

	internal static string smethod_1(string string_0)
	{
		double num = 0.0;
		try
		{
			num = double.Parse(string_0);
		}
		catch
		{
		}
		int num2 = (int)Math.Round(num * 1440.0 % 60.0);
		int num3 = (int)(num * 1440.0 / 60.0);
		if (num2 == 60)
		{
			num2 = 0;
			num3++;
		}
		return num3 + ":" + num2;
	}

	private static XmlDocument smethod_2(System.Data.DataTable dataTable_0)
	{
		XmlDocument xmlDocument = new XmlDocument();
		XmlNode xmlNode = xmlDocument.CreateElement("TransOff");
		xmlDocument.AppendChild(xmlNode);
		foreach (object obj in dataTable_0.Rows)
		{
			DataRow dataRow = (DataRow)obj;
			XmlNode xmlNode2 = xmlDocument.CreateElement("Row");
			xmlNode.AppendChild(xmlNode2);
			XmlAttribute xmlAttribute = xmlDocument.CreateAttribute("idSub");
			xmlAttribute.Value = dataRow["idSub"].ToString();
			xmlNode2.Attributes.Append(xmlAttribute);
			xmlAttribute = xmlDocument.CreateAttribute("idTr");
			xmlAttribute.Value = dataRow["idTr"].ToString();
			xmlNode2.Attributes.Append(xmlAttribute);
			xmlAttribute = xmlDocument.CreateAttribute("Power");
			xmlAttribute.Value = dataRow["Power"].ToString();
			xmlNode2.Attributes.Append(xmlAttribute);
			xmlAttribute = xmlDocument.CreateAttribute("Load");
			xmlAttribute.Value = dataRow["Load"].ToString();
			xmlNode2.Attributes.Append(xmlAttribute);
		}
		return xmlDocument;
	}

	private static void smethod_3(TreeNodeObj treeNodeObj_0, List<int> list_0)
	{
		if (treeNodeObj_0.Tag != null && treeNodeObj_0.Tag is ElectricLine)
		{
			foreach (ElectricRelation electricRelation in ((ElectricLine)treeNodeObj_0.Tag).Relations)
			{
				foreach (ElectricObject electricObject in electricRelation.ChildObjects)
				{
					if (electricObject is ElectricSwitch && ((ElectricSwitch)electricObject).TypeSwitch == TypeSwitch.TransformerTool && !list_0.Contains(electricObject.Id))
					{
						list_0.Add(electricObject.Id);
					}
				}
			}
		}
		foreach (TreeNodeObj treeNodeObj_ in treeNodeObj_0.Nodes)
		{
			Class222.smethod_3(treeNodeObj_, list_0);
		}
	}

	private static System.Data.DataTable smethod_4(List<int> list_0, SQLSettings sqlsettings_0)
	{
		System.Data.DataTable dataTable = new System.Data.DataTable();
		dataTable.Columns.Add("idTr", typeof(int));
		dataTable.Columns.Add("TrName", typeof(string));
		dataTable.Columns.Add("idSub", typeof(int));
		dataTable.Columns.Add("Sub", typeof(string));
		dataTable.Columns.Add("Power", typeof(int));
		dataTable.Columns.Add("load", typeof(int));
		dataTable.Clear();
		using (SqlConnection sqlConnection = new SqlConnection(sqlsettings_0.GetConnectionString() + ";Connection Timeout=1000"))
		{
			sqlConnection.Open();
			using (SqlCommand sqlCommand = new SqlCommand(Class7.smethod_2("Documents.Forms.DailyReport.SqlScripts.GetTransformerSchmObj.sql"), sqlConnection))
			{
				sqlCommand.CommandTimeout = 0;
				System.Data.DataTable dataTable2 = new System.Data.DataTable();
				new SqlDataAdapter(sqlCommand).Fill(dataTable2);
				int num = 0;
				foreach (int num2 in list_0)
				{
					DataRow[] array = dataTable2.Select("id = " + num2.ToString());
					if (array.Length != 0)
					{
						DataRow dataRow = dataTable.NewRow();
						dataRow["idTR"] = array[0]["id"];
						dataRow["TrNAme"] = array[0]["Наименование"];
						dataRow["idSub"] = array[0]["idSub"];
						dataRow["Sub"] = array[0]["Расположение"];
						if (array[0]["Мощность"] != DBNull.Value && !string.IsNullOrEmpty(array[0]["Мощность"].ToString()))
						{
							dataRow["Power"] = array[0]["Мощность"];
						}
						if (array[0]["Мощность"] != DBNull.Value && !string.IsNullOrEmpty(array[0]["Мощность"].ToString()))
						{
							num += Convert.ToInt32(array[0]["Мощность"]);
						}
						dataTable.Rows.Add(dataRow);
					}
				}
			}
			using (SqlCommand sqlCommand2 = new SqlCommand("SELECT mat.idbus, mat.[IdObjList],\r\n                        \t(case when max([Ia]) >= max([Ib]) and max([Ia]) >= max([Ic]) \r\n                        \t then max([Ia]) \telse case when max([Ib]) >= max([Ic]) and max([Ib]) >= max([Ia]) then max([Ib]) \r\n                        \t\t\t\t\t                                else case when max([Ic]) >= max([Ia]) and max([Ic]) >= max([Ib]) \r\n                        \t\t\t\t\t                                then max([Ic]) end end end) as I\r\n                         FROM [tJ_MeasAmperageTransf] as mat\r\n                               inner join [tJ_Measurement] as m on mat.[idMeasurement] = m.id\r\n                          where  mat.deleted = 0 and m.[TypeDoc] = 1192\r\n                        \tand ((year(m.[DateD]) = \r\n                        \t\t\t(select case when month(max(dateD)) = 12 then year(max(dateD)) + 1\r\n                        \t\t\t\t\telse year(max(dateD)) end from tj_measurement mes \r\n                        \t\t\tleft join [tJ_MeasAmperageTransf] mt on mt.[idMeasurement] = mes.id\r\n                        \t\t\t where mt.idBus = mat.idBus and mt.deleted = 0 and m.typeDoc = 1192\t\r\n                        \t\t\t and  mt.[Ia] is not null and  mt.[Ib] is not null and  mt.[Ic] is not null)\r\n                                      and month(m.[DateD]) between 1 and 11)\t\r\n                           or (year(m.[DateD]) =(select case when month(max(dateD)) = 12 then year(max(dateD)) + 1\r\n                        \telse year(max(dateD)) end\r\n                        \tfrom tj_measurement mes \r\n                        \tleft join [tJ_MeasAmperageTransf] mt on mt.[idMeasurement] = mes.id\r\n                        \twhere mt.idBus = mat.idBus and mt.deleted = 0 and m.typeDoc = 1192\r\n                        \t and  mt.[Ia] is not null and  mt.[Ib] is not null and  mt.[Ic] is not null)-1 and month(m.[DateD])=12)) \r\n                            and  mat.[Ia] is not null and  mat.[Ib] is not null and  mat.[Ic] is not null \r\n                          group by mat.idBus,  mat.[idObjList]", sqlConnection))
			{
				sqlCommand2.CommandTimeout = 0;
				System.Data.DataTable dataTable3 = new System.Data.DataTable();
				new SqlDataAdapter(sqlCommand2).Fill(dataTable3);
				foreach (object obj in dataTable.Rows)
				{
					DataRow dataRow2 = (DataRow)obj;
					DataRow[] array2 = dataTable3.Select("idObjList = " + dataRow2["idTr"].ToString());
					if (array2.Length != 0)
					{
						dataRow2["Load"] = array2[0]["I"];
					}
				}
			}
		}
		return dataTable;
	}

	public Class222()
	{
		
		
	}
}
