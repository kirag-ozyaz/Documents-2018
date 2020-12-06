using System;
using System.IO;
using System.Text;
using System.Xml;

namespace MarkupConverter
{
	public static class HtmlFromXamlConverter
	{
		public static string ConvertXamlToHtml(string xamlString, bool asFullDocument)
		{
			XmlTextReader xmlTextReader_ = new XmlTextReader(new StringReader(xamlString));
			StringBuilder stringBuilder = new StringBuilder(100);
			XmlTextWriter xmlTextWriter_ = new XmlTextWriter(new StringWriter(stringBuilder));
			if (!HtmlFromXamlConverter.smethod_0(xmlTextReader_, xmlTextWriter_, asFullDocument))
			{
				return "";
			}
			return stringBuilder.ToString();
		}

		private static bool smethod_0(XmlTextReader xmlTextReader_0, XmlTextWriter xmlTextWriter_0, bool bool_0)
		{
			if (!HtmlFromXamlConverter.BogorByUu1(xmlTextReader_0))
			{
				return false;
			}
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && !(xmlTextReader_0.Name != "FlowDocument"))
			{
				StringBuilder stringBuilder_ = new StringBuilder();
				if (bool_0)
				{
					xmlTextWriter_0.WriteStartElement("HTML");
					xmlTextWriter_0.WriteStartElement("BODY");
				}
				HtmlFromXamlConverter.smethod_1(xmlTextReader_0, xmlTextWriter_0, stringBuilder_);
				HtmlFromXamlConverter.smethod_4(xmlTextReader_0, xmlTextWriter_0, stringBuilder_);
				if (bool_0)
				{
					xmlTextWriter_0.WriteEndElement();
					xmlTextWriter_0.WriteEndElement();
				}
				return true;
			}
			return false;
		}

		private static void smethod_1(XmlTextReader xmlTextReader_0, XmlTextWriter xmlTextWriter_0, StringBuilder stringBuilder_0)
		{
			stringBuilder_0.Remove(0, stringBuilder_0.Length);
			if (!xmlTextReader_0.HasAttributes)
			{
				return;
			}
			bool flag = false;
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				string text = null;
				string name = xmlTextReader_0.Name;
				uint num = PrivateImplementationDetails.ComputeStringHash(name);
				if (num <= 2181051574u)
				{
					if (num <= 1332187941u)
					{
						if (num <= 973318696u)
						{
							if (num != 85690647u)
							{
								if (num != 121036118u)
								{
									if (num == 973318696u)
									{
										if (!(name == "Capitals"))
										{
										}
									}
								}
								else if (name == "Padding")
								{
									text = "padding:" + HtmlFromXamlConverter.smethod_3(xmlTextReader_0.Value) + ";";
								}
							}
							else if (!(name == "Emphasis"))
							{
							}
						}
						else if (num <= 1089698543u)
						{
							if (num != 994238399u)
							{
								if (num == 1089698543u)
								{
									if (name == "RowSpan")
									{
										xmlTextWriter_0.WriteAttributeString("ROWSPAN", xmlTextReader_0.Value);
									}
								}
							}
							else if (name == "Width")
							{
								text = "width:" + xmlTextReader_0.Value + ";";
							}
						}
						else if (num != 1282463423u)
						{
							if (num == 1332187941u)
							{
								if (!(name == "ColumnBreakBefore"))
								{
								}
							}
						}
						else if (name == "BorderThickness")
						{
							text = "border-width:" + HtmlFromXamlConverter.smethod_3(xmlTextReader_0.Value) + ";";
							flag = true;
						}
					}
					else if (num <= 1813401013u)
					{
						if (num != 1484831110u)
						{
							if (num != 1726175488u)
							{
								if (num == 1813401013u)
								{
									if (name == "FontStyle")
									{
										text = "font-style:" + xmlTextReader_0.Value.ToLower() + ";";
									}
								}
							}
							else if (!(name == "IsKeptWithNext"))
							{
							}
						}
						else if (!(name == "StandardLigatures"))
						{
						}
					}
					else if (num <= 1883455196u)
					{
						if (num != 1836252672u)
						{
							if (num == 1883455196u)
							{
								if (name == "TextIndent")
								{
									text = "text-indent:" + xmlTextReader_0.Value + ";";
								}
							}
						}
						else if (!(name == "TextEffects"))
						{
						}
					}
					else if (num != 1918801359u)
					{
						if (num == 2181051574u)
						{
							if (!(name == "PageBreakBefore"))
							{
							}
						}
					}
					else if (!(name == "Variants"))
					{
					}
				}
				else if (num <= 3037753912u)
				{
					if (num <= 2812248845u)
					{
						if (num != 2244251939u)
						{
							if (num != 2724873441u)
							{
								if (num == 2812248845u)
								{
									if (!(name == "FontStretch"))
									{
									}
								}
							}
							else if (name == "FontSize")
							{
								text = "font-size:" + xmlTextReader_0.Value + ";";
							}
						}
						else if (name == "ColumnSpan")
						{
							xmlTextWriter_0.WriteAttributeString("COLSPAN", xmlTextReader_0.Value);
						}
					}
					else if (num <= 2844640867u)
					{
						if (num != 2822774003u)
						{
							if (num == 2844640867u)
							{
								if (name == "TextAlignment")
								{
									text = "text-align:" + xmlTextReader_0.Value + ";";
								}
							}
						}
						else if (!(name == "IsKeptTogether"))
						{
						}
					}
					else if (num != 2994397609u)
					{
						if (num == 3037753912u)
						{
							if (!(name == "LineHeight"))
							{
							}
						}
					}
					else if (name == "TextDecorations")
					{
						text = "text-decoration:underline;";
					}
				}
				else if (num <= 3301734811u)
				{
					if (num <= 3137079997u)
					{
						if (num != 3133010275u)
						{
							if (num == 3137079997u)
							{
								if (name == "Background")
								{
									text = "background-color:" + HtmlFromXamlConverter.smethod_2(xmlTextReader_0.Value) + ";";
								}
							}
						}
						else if (!(name == "Fraction"))
						{
						}
					}
					else if (num != 3286546394u)
					{
						if (num == 3301734811u)
						{
							if (name == "Margin")
							{
								text = "margin:" + HtmlFromXamlConverter.smethod_3(xmlTextReader_0.Value) + ";";
							}
						}
					}
					else if (!(name == "FlowDirection"))
					{
					}
				}
				else if (num <= 3537472213u)
				{
					if (num != 3496045264u)
					{
						if (num == 3537472213u)
						{
							if (name == "BorderBrush")
							{
								text = "border-color:" + HtmlFromXamlConverter.smethod_2(xmlTextReader_0.Value) + ";";
								flag = true;
							}
						}
					}
					else if (name == "FontWeight")
					{
						text = "font-weight:" + xmlTextReader_0.Value.ToLower() + ";";
					}
				}
				else if (num != 3647682272u)
				{
					if (num == 4130445440u)
					{
						if (name == "FontFamily")
						{
							text = "font-family:" + xmlTextReader_0.Value + ";";
						}
					}
				}
				else if (name == "Foreground")
				{
					text = "color:" + HtmlFromXamlConverter.smethod_2(xmlTextReader_0.Value) + ";";
				}
				if (text != null)
				{
					stringBuilder_0.Append(text);
				}
			}
			if (flag)
			{
				stringBuilder_0.Append("border-style:solid;mso-element:para-border-div;");
			}
			xmlTextReader_0.MoveToElement();
		}

		private static string smethod_2(string string_0)
		{
			if (string_0.StartsWith("#"))
			{
				string_0 = "#" + string_0.Substring(3);
			}
			return string_0;
		}

		private static string smethod_3(string string_0)
		{
			string[] array = string_0.Split(new char[]
			{
				','
			});
			for (int i = 0; i < array.Length; i++)
			{
				double a;
				if (double.TryParse(array[i], out a))
				{
					array[i] = Math.Ceiling(a).ToString();
				}
				else
				{
					array[i] = "1";
				}
			}
			switch (array.Length)
			{
			case 1:
				return string_0;
			case 2:
				return array[1] + " " + array[0];
			case 4:
				return string.Concat(new string[]
				{
					array[1],
					" ",
					array[2],
					" ",
					array[3],
					" ",
					array[0]
				});
			}
			return array[0];
		}

		private static void smethod_4(XmlTextReader xmlTextReader_0, XmlTextWriter xmlTextWriter_0, StringBuilder stringBuilder_0)
		{
			bool flag = false;
			if (xmlTextReader_0.IsEmptyElement)
			{
				if (xmlTextWriter_0 != null && !flag && stringBuilder_0.Length > 0)
				{
					xmlTextWriter_0.WriteAttributeString("STYLE", stringBuilder_0.ToString());
					stringBuilder_0.Remove(0, stringBuilder_0.Length);
				}
				return;
			}
			while (HtmlFromXamlConverter.BogorByUu1(xmlTextReader_0))
			{
				if (xmlTextReader_0.NodeType == XmlNodeType.EndElement)
				{
					break;
				}
				XmlNodeType nodeType = xmlTextReader_0.NodeType;
				switch (nodeType)
				{
				case XmlNodeType.Element:
					if (xmlTextReader_0.Name.Contains("."))
					{
						HtmlFromXamlConverter.smethod_5(xmlTextReader_0, stringBuilder_0);
						continue;
					}
					if (xmlTextWriter_0 != null && !flag && stringBuilder_0.Length > 0)
					{
						xmlTextWriter_0.WriteAttributeString("STYLE", stringBuilder_0.ToString());
						stringBuilder_0.Remove(0, stringBuilder_0.Length);
					}
					flag = true;
					HtmlFromXamlConverter.smethod_6(xmlTextReader_0, xmlTextWriter_0, stringBuilder_0);
					continue;
				case XmlNodeType.Attribute:
					continue;
				case XmlNodeType.Text:
				case XmlNodeType.CDATA:
					break;
				default:
					if (nodeType == XmlNodeType.Comment)
					{
						if (xmlTextWriter_0 != null)
						{
							if (!flag && stringBuilder_0.Length > 0)
							{
								xmlTextWriter_0.WriteAttributeString("STYLE", stringBuilder_0.ToString());
							}
							xmlTextWriter_0.WriteComment(xmlTextReader_0.Value);
						}
						flag = true;
						continue;
					}
					if (nodeType != XmlNodeType.SignificantWhitespace)
					{
						continue;
					}
					break;
				}
				if (xmlTextWriter_0 != null)
				{
					if (!flag && stringBuilder_0.Length > 0)
					{
						xmlTextWriter_0.WriteAttributeString("STYLE", stringBuilder_0.ToString());
					}
					xmlTextWriter_0.WriteString(xmlTextReader_0.Value);
				}
				flag = true;
			}
		}

		private static void smethod_5(XmlTextReader xmlTextReader_0, StringBuilder stringBuilder_0)
		{
			if (stringBuilder_0 != null && xmlTextReader_0.Name.EndsWith(".TextDecorations"))
			{
				stringBuilder_0.Append("text-decoration:underline;");
			}
			HtmlFromXamlConverter.smethod_4(xmlTextReader_0, null, null);
		}

		private static void smethod_6(XmlTextReader xmlTextReader_0, XmlTextWriter xmlTextWriter_0, StringBuilder stringBuilder_0)
		{
			if (xmlTextWriter_0 == null)
			{
				HtmlFromXamlConverter.smethod_4(xmlTextReader_0, null, null);
				return;
			}
			string name = xmlTextReader_0.Name;
			uint num = PrivateImplementationDetails.ComputeStringHash(name);
			string text;
			if (num <= 2377171085u)
			{
				if (num <= 1385410265u)
				{
					if (num != 763853676u)
					{
						if (num != 1165397398u)
						{
							if (num != 1385410265u)
							{
								goto IL_2B7;
							}
							if (name == "Paragraph")
							{
								text = "P";
								goto IL_2C1;
							}
							goto IL_2B7;
						}
						else
						{
							if (name == "Bold")
							{
								text = "B";
								goto IL_2C1;
							}
							goto IL_2B7;
						}
					}
					else
					{
						if (name == "Section")
						{
							text = "DIV";
							goto IL_2C1;
						}
						goto IL_2B7;
					}
				}
				else if (num <= 2368288673u)
				{
					if (num != 2302113563u)
					{
						if (num != 2368288673u)
						{
							goto IL_2B7;
						}
						if (!(name == "List"))
						{
							goto IL_2B7;
						}
						string attribute = xmlTextReader_0.GetAttribute("MarkerStyle");
						if (attribute != null && !(attribute == "None") && !(attribute == "Disc") && !(attribute == "Circle") && !(attribute == "Square") && !(attribute == "Box"))
						{
							text = "OL";
							goto IL_2C1;
						}
						text = "UL";
						goto IL_2C1;
					}
					else
					{
						if (name == "BlockUIContainer")
						{
							text = "DIV";
							goto IL_2C1;
						}
						goto IL_2B7;
					}
				}
				else if (num != 2371348074u)
				{
					if (num != 2377171085u)
					{
						goto IL_2B7;
					}
					if (name == "Italic")
					{
						text = "I";
						goto IL_2C1;
					}
					goto IL_2B7;
				}
				else if (!(name == "Run"))
				{
					goto IL_2B7;
				}
			}
			else if (num <= 3282865434u)
			{
				if (num <= 2840215565u)
				{
					if (num != 2661514708u)
					{
						if (num != 2840215565u)
						{
							goto IL_2B7;
						}
						if (name == "TableColumn")
						{
							text = "COL";
							goto IL_2C1;
						}
						goto IL_2B7;
					}
					else
					{
						if (name == "TableRowGroup")
						{
							text = "TBODY";
							goto IL_2C1;
						}
						goto IL_2B7;
					}
				}
				else if (num != 2879928289u)
				{
					if (num != 3282865434u)
					{
						goto IL_2B7;
					}
					if (name == "ListItem")
					{
						text = "LI";
						goto IL_2C1;
					}
					goto IL_2B7;
				}
				else if (!(name == "Span"))
				{
					goto IL_2B7;
				}
			}
			else if (num <= 3596280077u)
			{
				if (num != 3284997757u)
				{
					if (num != 3596280077u)
					{
						goto IL_2B7;
					}
					if (name == "TableRow")
					{
						text = "TR";
						goto IL_2C1;
					}
					goto IL_2B7;
				}
				else
				{
					if (name == "InlineUIContainer")
					{
						text = "SPAN";
						goto IL_2C1;
					}
					goto IL_2B7;
				}
			}
			else if (num != 3607948159u)
			{
				if (num != 3970290371u)
				{
					goto IL_2B7;
				}
				if (name == "TableCell")
				{
					text = "TD";
					goto IL_2C1;
				}
				goto IL_2B7;
			}
			else
			{
				if (!(name == "Table"))
				{
					goto IL_2B7;
				}
				text = "TABLE";
				goto IL_2C1;
			}
			text = "SPAN";
			goto IL_2C1;
			IL_2B7:
			text = null;
			IL_2C1:
			if (xmlTextWriter_0 != null && text != null)
			{
				xmlTextWriter_0.WriteStartElement(text);
				HtmlFromXamlConverter.smethod_1(xmlTextReader_0, xmlTextWriter_0, stringBuilder_0);
				HtmlFromXamlConverter.smethod_4(xmlTextReader_0, xmlTextWriter_0, stringBuilder_0);
				xmlTextWriter_0.WriteEndElement();
				return;
			}
			HtmlFromXamlConverter.smethod_4(xmlTextReader_0, null, null);
		}

		private static bool BogorByUu1(XmlReader xmlReader_0)
		{
			while (xmlReader_0.Read())
			{
				switch (xmlReader_0.NodeType)
				{
				case XmlNodeType.None:
				case XmlNodeType.Element:
				case XmlNodeType.Text:
				case XmlNodeType.CDATA:
				case XmlNodeType.SignificantWhitespace:
				case XmlNodeType.EndElement:
					return true;
				case XmlNodeType.Comment:
					return true;
				case XmlNodeType.Whitespace:
					if (xmlReader_0.XmlSpace == XmlSpace.Preserve)
					{
						return true;
					}
					break;
				}
			}
			return false;
		}
	}
}
