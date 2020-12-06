using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Documents;
using System.Xml;

namespace MarkupConverter
{
	public static class HtmlToXamlConverter
	{
		public static string ConvertHtmlToXaml(string htmlString, bool asFlowDocument)
		{
			XmlElement xmlNode_ = Class5.smethod_0(htmlString);
			string localName = asFlowDocument ? "FlowDocument" : "Section";
			XmlElement xmlElement = new XmlDocument().CreateElement(null, localName, HtmlToXamlConverter.string_0);
			Class2 class2_ = new Class2(xmlNode_);
			List<XmlElement> list_ = new List<XmlElement>(10);
			HtmlToXamlConverter.xmlElement_0 = null;
			HtmlToXamlConverter.smethod_1(xmlElement, xmlNode_, new Hashtable(), class2_, list_);
			if (!asFlowDocument)
			{
				xmlElement = HtmlToXamlConverter.smethod_11(xmlElement);
			}
			xmlElement.SetAttribute("xml:space", "preserve");
			return xmlElement.OuterXml;
		}

		public static string GetAttribute(XmlElement element, string attributeName)
		{
			attributeName = attributeName.ToLower();
			for (int i = 0; i < element.Attributes.Count; i++)
			{
				if (element.Attributes[i].Name.ToLower() == attributeName)
				{
					return element.Attributes[i].Value;
				}
			}
			return null;
		}

		internal static string smethod_0(string string_1)
		{
			if ((string_1.StartsWith("\"") && string_1.EndsWith("\"")) || (string_1.StartsWith("'") && string_1.EndsWith("'")))
			{
				string_1 = string_1.Substring(1, string_1.Length - 2).Trim();
			}
			return string_1;
		}

		private static XmlNode smethod_1(XmlElement xmlElement_1, XmlNode xmlNode_0, Hashtable hashtable_0, Class2 class2_0, List<XmlElement> list_0)
		{
			if (xmlNode_0 is XmlComment)
			{
				HtmlToXamlConverter.smethod_10((XmlComment)xmlNode_0, null);
			}
			else if (xmlNode_0 is XmlText)
			{
				xmlNode_0 = HtmlToXamlConverter.smethod_5(xmlElement_1, xmlNode_0, hashtable_0, class2_0, list_0);
			}
			else if (xmlNode_0 is XmlElement)
			{
				XmlElement xmlElement = (XmlElement)xmlNode_0;
				string text = xmlElement.LocalName;
				if (xmlElement.NamespaceURI != "http://www.w3.org/1999/xhtml")
				{
					return xmlElement;
				}
				list_0.Add(xmlElement);
				text = text.ToLower();
				uint num = PrivateImplementationDetails.ComputeStringHash(text);
				if (num <= 2335911347u)
				{
					if (num <= 1249556454u)
					{
						if (num <= 1027948613u)
						{
							if (num <= 93078660u)
							{
								if (num != 29650526u)
								{
									if (num != 93078660u)
									{
										goto IL_5EB;
									}
									if (!(text == "center"))
									{
										goto IL_5EB;
									}
									goto IL_5D1;
								}
								else
								{
									if (!(text == "cite"))
									{
										goto IL_5EB;
									}
									goto IL_5D1;
								}
							}
							else if (num != 540962730u)
							{
								if (num != 845761475u)
								{
									if (num != 1027948613u)
									{
										goto IL_5EB;
									}
									if (!(text == "td"))
									{
										goto IL_5EB;
									}
									goto IL_5EB;
								}
								else
								{
									if (!(text == "head"))
									{
										goto IL_5EB;
									}
									goto IL_605;
								}
							}
							else
							{
								if (!(text == "script"))
								{
									goto IL_5EB;
								}
								goto IL_605;
							}
						}
						else if (num <= 1079560007u)
						{
							if (num != 1077001542u)
							{
								if (num != 1079560007u)
								{
									goto IL_5EB;
								}
								if (!(text == "form"))
								{
									goto IL_5EB;
								}
								goto IL_5D1;
							}
							else
							{
								if (text == "li")
								{
									xmlNode_0 = HtmlToXamlConverter.boyCcQnOip(xmlElement_1, xmlElement, hashtable_0, class2_0, list_0);
									goto IL_605;
								}
								goto IL_5EB;
							}
						}
						else if (num != 1095059089u)
						{
							if (num != 1195724803u)
							{
								if (num != 1249556454u)
								{
									goto IL_5EB;
								}
								if (!(text == "pre"))
								{
									goto IL_5EB;
								}
								goto IL_5D1;
							}
							else
							{
								if (!(text == "tr"))
								{
									goto IL_5EB;
								}
								goto IL_5EB;
							}
						}
						else
						{
							if (!(text == "th"))
							{
								goto IL_5EB;
							}
							goto IL_5EB;
						}
					}
					else if (num <= 1598240564u)
					{
						if (num <= 1293727493u)
						{
							if (num != 1251777503u)
							{
								if (num != 1293727493u)
								{
									goto IL_5EB;
								}
								if (!(text == "dt"))
								{
									goto IL_5EB;
								}
							}
							else
							{
								if (text == "table")
								{
									HtmlToXamlConverter.smethod_15(xmlElement_1, xmlElement, hashtable_0, class2_0, list_0);
									goto IL_605;
								}
								goto IL_5EB;
							}
						}
						else if (num != 1296390517u)
						{
							if (num != 1562169397u)
							{
								if (num != 1598240564u)
								{
									goto IL_5EB;
								}
								if (!(text == "ul"))
								{
									goto IL_5EB;
								}
								goto IL_5FA;
							}
							else if (!(text == "dd"))
							{
								goto IL_5EB;
							}
						}
						else if (!(text == "tt"))
						{
							goto IL_5EB;
						}
					}
					else if (num <= 1696390349u)
					{
						if (num != 1664365302u)
						{
							if (num != 1696390349u)
							{
								goto IL_5EB;
							}
							if (!(text == "dl"))
							{
								goto IL_5EB;
							}
						}
						else
						{
							if (!(text == "ol"))
							{
								goto IL_5EB;
							}
							goto IL_5FA;
						}
					}
					else if (num != 2180927320u)
					{
						if (num != 2229740804u)
						{
							if (num != 2335911347u)
							{
								goto IL_5EB;
							}
							if (!(text == "h6"))
							{
								goto IL_5EB;
							}
						}
						else
						{
							if (text == "img")
							{
								HtmlToXamlConverter.smethod_12(xmlElement_1, xmlElement, hashtable_0, class2_0, list_0);
								goto IL_605;
							}
							goto IL_5EB;
						}
					}
					else
					{
						if (!(text == "meta"))
						{
							goto IL_5EB;
						}
						goto IL_605;
					}
				}
				else if (num <= 2888859350u)
				{
					if (num <= 2403021823u)
					{
						if (num <= 2352688966u)
						{
							if (num != 2340213611u)
							{
								if (num != 2352688966u)
								{
									goto IL_5EB;
								}
								if (!(text == "h5"))
								{
									goto IL_5EB;
								}
							}
							else
							{
								if (!(text == "tbody"))
								{
									goto IL_5EB;
								}
								goto IL_5EB;
							}
						}
						else if (num != 2369466585u)
						{
							if (num != 2386244204u)
							{
								if (num != 2403021823u)
								{
									goto IL_5EB;
								}
								if (!(text == "h2"))
								{
									goto IL_5EB;
								}
							}
							else if (!(text == "h3"))
							{
								goto IL_5EB;
							}
						}
						else if (!(text == "h4"))
						{
							goto IL_5EB;
						}
					}
					else if (num <= 2556802313u)
					{
						if (num != 2419799442u)
						{
							if (num != 2556802313u)
							{
								goto IL_5EB;
							}
							if (!(text == "title"))
							{
								goto IL_5EB;
							}
							goto IL_605;
						}
						else if (!(text == "h1"))
						{
							goto IL_5EB;
						}
					}
					else if (num != 2581912890u)
					{
						if (num != 2853211801u)
						{
							if (num != 2888859350u)
							{
								goto IL_5EB;
							}
							if (!(text == "style"))
							{
								goto IL_5EB;
							}
							goto IL_605;
						}
						else
						{
							if (!(text == "thead"))
							{
								goto IL_5EB;
							}
							goto IL_5EB;
						}
					}
					else
					{
						if (!(text == "menu"))
						{
							goto IL_5EB;
						}
						goto IL_5FA;
					}
				}
				else if (num <= 3685382517u)
				{
					if (num <= 3216274459u)
					{
						if (num != 2962327514u)
						{
							if (num != 3216274459u)
							{
								goto IL_5EB;
							}
							if (!(text == "tfoot"))
							{
								goto IL_5EB;
							}
							goto IL_5EB;
						}
						else if (!(text == "nsrtitle"))
						{
							goto IL_5EB;
						}
					}
					else if (num != 3601512955u)
					{
						if (num != 3614812112u)
						{
							if (num != 3685382517u)
							{
								goto IL_5EB;
							}
							if (!(text == "body"))
							{
								goto IL_5EB;
							}
							goto IL_5D1;
						}
						else
						{
							if (!(text == "html"))
							{
								goto IL_5EB;
							}
							goto IL_5D1;
						}
					}
					else if (!(text == "textarea"))
					{
						goto IL_5EB;
					}
				}
				else if (num <= 3848448840u)
				{
					if (num != 3784120478u)
					{
						if (num != 3848448840u)
						{
							goto IL_5EB;
						}
						if (!(text == "div"))
						{
							goto IL_5EB;
						}
						goto IL_5D1;
					}
					else
					{
						if (!(text == "blockquote"))
						{
							goto IL_5EB;
						}
						goto IL_5D1;
					}
				}
				else if (num != 3915559316u)
				{
					if (num != 4011007077u)
					{
						if (num != 4111221743u)
						{
							goto IL_5EB;
						}
						if (!(text == "p"))
						{
							goto IL_5EB;
						}
					}
					else
					{
						if (text == "caption")
						{
							goto IL_5D1;
						}
						goto IL_5EB;
					}
				}
				else
				{
					if (!(text == "dir"))
					{
						goto IL_5EB;
					}
					goto IL_5FA;
				}
				HtmlToXamlConverter.smethod_4(xmlElement_1, xmlElement, hashtable_0, class2_0, list_0);
				goto IL_605;
				IL_5D1:
				HtmlToXamlConverter.smethod_3(xmlElement_1, xmlElement, hashtable_0, class2_0, list_0);
				goto IL_605;
				IL_5EB:
				xmlNode_0 = HtmlToXamlConverter.smethod_5(xmlElement_1, xmlElement, hashtable_0, class2_0, list_0);
				goto IL_605;
				IL_5FA:
				HtmlToXamlConverter.smethod_13(xmlElement_1, xmlElement, hashtable_0, class2_0, list_0);
				IL_605:
				list_0.RemoveAt(list_0.Count - 1);
			}
			return xmlNode_0;
		}

		private static void smethod_2(XmlElement xmlElement_1, string string_1)
		{
			XmlElement newChild = xmlElement_1.OwnerDocument.CreateElement(null, "LineBreak", HtmlToXamlConverter.string_0);
			xmlElement_1.AppendChild(newChild);
			if (string_1 == "hr")
			{
				XmlText newChild2 = xmlElement_1.OwnerDocument.CreateTextNode("----------------------");
				xmlElement_1.AppendChild(newChild2);
				newChild = xmlElement_1.OwnerDocument.CreateElement(null, "LineBreak", HtmlToXamlConverter.string_0);
				xmlElement_1.AppendChild(newChild);
			}
		}

		private static void smethod_3(XmlElement xmlElement_1, XmlElement xmlElement_2, Hashtable hashtable_0, Class2 class2_0, List<XmlElement> list_0)
		{
			bool flag = false;
			XmlNode xmlNode = xmlElement_2.FirstChild;
			while (xmlNode != null)
			{
				if (!(xmlNode is XmlElement) || !Class6.smethod_1(((XmlElement)xmlNode).LocalName.ToLower()))
				{
					xmlNode = xmlNode.NextSibling;
				}
				else
				{
					flag = true;
					IL_38:
					if (!flag)
					{
						HtmlToXamlConverter.smethod_4(xmlElement_1, xmlElement_2, hashtable_0, class2_0, list_0);
						return;
					}
					Hashtable hashtable_2;
					Hashtable hashtable_ = HtmlToXamlConverter.smethod_37(xmlElement_2, hashtable_0, out hashtable_2, class2_0, list_0);
					XmlElement xmlElement = xmlElement_1.OwnerDocument.CreateElement(null, "Section", HtmlToXamlConverter.string_0);
					HtmlToXamlConverter.smethod_34(xmlElement, hashtable_2, true);
					if (!xmlElement.HasAttributes)
					{
						xmlElement = xmlElement_1;
					}
					for (XmlNode xmlNode2 = xmlElement_2.FirstChild; xmlNode2 != null; xmlNode2 = ((xmlNode2 != null) ? xmlNode2.NextSibling : null))
					{
						xmlNode2 = HtmlToXamlConverter.smethod_1(xmlElement, xmlNode2, hashtable_, class2_0, list_0);
					}
					if (xmlElement != xmlElement_1)
					{
						xmlElement_1.AppendChild(xmlElement);
					}
					return;
				}
			}
			goto IL_38;
		}

		private static void smethod_4(XmlElement xmlElement_1, XmlElement xmlElement_2, Hashtable hashtable_0, Class2 class2_0, List<XmlElement> list_0)
		{
			Hashtable hashtable_2;
			Hashtable hashtable_ = HtmlToXamlConverter.smethod_37(xmlElement_2, hashtable_0, out hashtable_2, class2_0, list_0);
			XmlElement xmlElement = xmlElement_1.OwnerDocument.CreateElement(null, "Paragraph", HtmlToXamlConverter.string_0);
			HtmlToXamlConverter.smethod_34(xmlElement, hashtable_2, true);
			for (XmlNode xmlNode = xmlElement_2.FirstChild; xmlNode != null; xmlNode = xmlNode.NextSibling)
			{
				HtmlToXamlConverter.smethod_6(xmlElement, xmlNode, hashtable_, class2_0, list_0);
			}
			xmlElement_1.AppendChild(xmlElement);
		}

		private static XmlNode smethod_5(XmlElement xmlElement_1, XmlNode xmlNode_0, Hashtable hashtable_0, Class2 class2_0, List<XmlElement> list_0)
		{
			XmlElement xmlElement = xmlElement_1.OwnerDocument.CreateElement(null, "Paragraph", HtmlToXamlConverter.string_0);
			XmlNode result = null;
			while (xmlNode_0 != null)
			{
				if (xmlNode_0 is XmlComment)
				{
					HtmlToXamlConverter.smethod_10((XmlComment)xmlNode_0, null);
				}
				else if (xmlNode_0 is XmlText)
				{
					if (xmlNode_0.Value.Trim().Length > 0)
					{
						HtmlToXamlConverter.smethod_8(xmlElement, xmlNode_0.Value);
					}
				}
				else if (xmlNode_0 is XmlElement)
				{
					if (Class6.smethod_1(((XmlElement)xmlNode_0).LocalName.ToLower()))
					{
						break;
					}
					HtmlToXamlConverter.smethod_6(xmlElement, (XmlElement)xmlNode_0, hashtable_0, class2_0, list_0);
				}
				result = xmlNode_0;
				xmlNode_0 = xmlNode_0.NextSibling;
			}
			if (xmlElement.FirstChild != null)
			{
				xmlElement_1.AppendChild(xmlElement);
			}
			return result;
		}

		private static void smethod_6(XmlElement xmlElement_1, XmlNode xmlNode_0, Hashtable hashtable_0, Class2 class2_0, List<XmlElement> list_0)
		{
			if (xmlNode_0 is XmlComment)
			{
				HtmlToXamlConverter.smethod_10((XmlComment)xmlNode_0, xmlElement_1);
				return;
			}
			if (xmlNode_0 is XmlText)
			{
				HtmlToXamlConverter.smethod_8(xmlElement_1, xmlNode_0.Value);
				return;
			}
			if (xmlNode_0 is XmlElement)
			{
				XmlElement xmlElement = (XmlElement)xmlNode_0;
				if (xmlElement.NamespaceURI != "http://www.w3.org/1999/xhtml")
				{
					return;
				}
				string text = xmlElement.LocalName.ToLower();
				list_0.Add(xmlElement);
				if (!(text == "a"))
				{
					if (!(text == "img"))
					{
						if (!(text == "br") && !(text == "hr"))
						{
							if (Class6.smethod_2(text) || Class6.smethod_1(text))
							{
								HtmlToXamlConverter.smethod_7(xmlElement_1, xmlElement, hashtable_0, class2_0, list_0);
							}
						}
						else
						{
							HtmlToXamlConverter.smethod_2(xmlElement_1, text);
						}
					}
					else
					{
						HtmlToXamlConverter.smethod_12(xmlElement_1, xmlElement, hashtable_0, class2_0, list_0);
					}
				}
				else
				{
					HtmlToXamlConverter.smethod_9(xmlElement_1, xmlElement, hashtable_0, class2_0, list_0);
				}
				list_0.RemoveAt(list_0.Count - 1);
			}
		}

		private static void smethod_7(XmlElement xmlElement_1, XmlElement xmlElement_2, Hashtable hashtable_0, Class2 class2_0, List<XmlElement> list_0)
		{
			bool flag = false;
			for (XmlNode xmlNode = xmlElement_2.FirstChild; xmlNode != null; xmlNode = xmlNode.NextSibling)
			{
				if (xmlNode is XmlElement)
				{
					string a = ((XmlElement)xmlNode).LocalName.ToLower();
					if (Class6.smethod_2(a) || Class6.smethod_1(a) || a == "img" || a == "br" || a == "hr")
					{
						flag = true;
						IL_75:
						string localName = flag ? "Span" : "Run";
						Hashtable hashtable_2;
						Hashtable hashtable_ = HtmlToXamlConverter.smethod_37(xmlElement_2, hashtable_0, out hashtable_2, class2_0, list_0);
						XmlElement xmlElement = xmlElement_1.OwnerDocument.CreateElement(null, localName, HtmlToXamlConverter.string_0);
						HtmlToXamlConverter.smethod_34(xmlElement, hashtable_2, false);
						for (XmlNode xmlNode2 = xmlElement_2.FirstChild; xmlNode2 != null; xmlNode2 = xmlNode2.NextSibling)
						{
							HtmlToXamlConverter.smethod_6(xmlElement, xmlNode2, hashtable_, class2_0, list_0);
						}
						xmlElement_1.AppendChild(xmlElement);
						return;
					}
				}
			}
			goto IL_75;
		}

		private static void smethod_8(XmlElement xmlElement_1, string string_1)
		{
			for (int i = 0; i < string_1.Length; i++)
			{
				if (char.IsControl(string_1[i]))
				{
					string_1 = string_1.Remove(i--, 1);
				}
			}
			string_1 = string_1.Replace('\u00a0', ' ');
			if (string_1.Length > 0)
			{
				xmlElement_1.AppendChild(xmlElement_1.OwnerDocument.CreateTextNode(string_1));
			}
		}

		private static void smethod_9(XmlElement xmlElement_1, XmlElement xmlElement_2, Hashtable hashtable_0, Class2 class2_0, List<XmlElement> list_0)
		{
			string attribute = HtmlToXamlConverter.GetAttribute(xmlElement_2, "href");
			if (attribute == null)
			{
				HtmlToXamlConverter.smethod_7(xmlElement_1, xmlElement_2, hashtable_0, class2_0, list_0);
				return;
			}
			Hashtable hashtable_2;
			Hashtable hashtable_ = HtmlToXamlConverter.smethod_37(xmlElement_2, hashtable_0, out hashtable_2, class2_0, list_0);
			XmlElement xmlElement = xmlElement_1.OwnerDocument.CreateElement(null, "Hyperlink", HtmlToXamlConverter.string_0);
			HtmlToXamlConverter.smethod_34(xmlElement, hashtable_2, false);
			string[] array = attribute.Split(new char[]
			{
				'#'
			});
			if (array.Length != 0 && array[0].Trim().Length > 0)
			{
				xmlElement.SetAttribute("NavigateUri", array[0].Trim());
			}
			if (array.Length == 2 && array[1].Trim().Length > 0)
			{
				xmlElement.SetAttribute("TargetName", array[1].Trim());
			}
			for (XmlNode xmlNode = xmlElement_2.FirstChild; xmlNode != null; xmlNode = xmlNode.NextSibling)
			{
				HtmlToXamlConverter.smethod_6(xmlElement, xmlNode, hashtable_, class2_0, list_0);
			}
			xmlElement_1.AppendChild(xmlElement);
		}

		private static void smethod_10(XmlComment xmlComment_0, XmlElement xmlElement_1)
		{
			if (xmlComment_0.Value == "StartFragment")
			{
				HtmlToXamlConverter.xmlElement_0 = xmlElement_1;
				return;
			}
			if (xmlComment_0.Value == "EndFragment" && HtmlToXamlConverter.xmlElement_0 == null && xmlElement_1 != null)
			{
				HtmlToXamlConverter.xmlElement_0 = xmlElement_1;
			}
		}

		private static XmlElement smethod_11(XmlElement xmlElement_1)
		{
			if (HtmlToXamlConverter.xmlElement_0 != null)
			{
				if (HtmlToXamlConverter.xmlElement_0.LocalName == "Span")
				{
					xmlElement_1 = HtmlToXamlConverter.xmlElement_0;
				}
				else
				{
					xmlElement_1 = xmlElement_1.OwnerDocument.CreateElement(null, "Span", HtmlToXamlConverter.string_0);
					while (HtmlToXamlConverter.xmlElement_0.FirstChild != null)
					{
						XmlNode firstChild = HtmlToXamlConverter.xmlElement_0.FirstChild;
						HtmlToXamlConverter.xmlElement_0.RemoveChild(firstChild);
						xmlElement_1.AppendChild(firstChild);
					}
				}
			}
			return xmlElement_1;
		}

		private static void smethod_12(XmlElement xmlElement_1, XmlElement xmlElement_2, Hashtable hashtable_0, Class2 class2_0, List<XmlElement> list_0)
		{
		}

		private static void smethod_13(XmlElement xmlElement_1, XmlElement xmlElement_2, Hashtable hashtable_0, Class2 class2_0, List<XmlElement> list_0)
		{
			string a = xmlElement_2.LocalName.ToLower();
			Hashtable hashtable_2;
			Hashtable hashtable_ = HtmlToXamlConverter.smethod_37(xmlElement_2, hashtable_0, out hashtable_2, class2_0, list_0);
			XmlElement xmlElement = xmlElement_1.OwnerDocument.CreateElement(null, "List", HtmlToXamlConverter.string_0);
			if (a == "ol")
			{
				xmlElement.SetAttribute("MarkerStyle", "Decimal");
			}
			else
			{
				xmlElement.SetAttribute("MarkerStyle", "Disc");
			}
			HtmlToXamlConverter.smethod_34(xmlElement, hashtable_2, true);
			for (XmlNode xmlNode = xmlElement_2.FirstChild; xmlNode != null; xmlNode = xmlNode.NextSibling)
			{
				if (xmlNode is XmlElement && xmlNode.LocalName.ToLower() == "li")
				{
					list_0.Add((XmlElement)xmlNode);
					HtmlToXamlConverter.smethod_14(xmlElement, (XmlElement)xmlNode, hashtable_, class2_0, list_0);
					list_0.RemoveAt(list_0.Count - 1);
				}
			}
			if (xmlElement.HasChildNodes)
			{
				xmlElement_1.AppendChild(xmlElement);
			}
		}

		private static XmlElement boyCcQnOip(XmlElement xmlElement_1, XmlElement xmlElement_2, Hashtable hashtable_0, Class2 class2_0, List<XmlElement> list_0)
		{
			XmlElement result = null;
			XmlNode lastChild = xmlElement_1.LastChild;
			XmlElement xmlElement;
			if (lastChild != null && lastChild.LocalName == "List")
			{
				xmlElement = (XmlElement)lastChild;
			}
			else
			{
				xmlElement = xmlElement_1.OwnerDocument.CreateElement(null, "List", HtmlToXamlConverter.string_0);
				xmlElement_1.AppendChild(xmlElement);
			}
			XmlNode xmlNode = xmlElement_2;
			string a = (xmlNode == null) ? null : xmlNode.LocalName.ToLower();
			while (xmlNode != null && a == "li")
			{
				HtmlToXamlConverter.smethod_14(xmlElement, (XmlElement)xmlNode, hashtable_0, class2_0, list_0);
				result = (XmlElement)xmlNode;
				xmlNode = xmlNode.NextSibling;
				a = ((xmlNode == null) ? null : xmlNode.LocalName.ToLower());
			}
			return result;
		}

		private static void smethod_14(XmlElement xmlElement_1, XmlElement xmlElement_2, Hashtable hashtable_0, Class2 class2_0, List<XmlElement> list_0)
		{
			Hashtable hashtable;
			Hashtable hashtable_ = HtmlToXamlConverter.smethod_37(xmlElement_2, hashtable_0, out hashtable, class2_0, list_0);
			XmlElement xmlElement = xmlElement_1.OwnerDocument.CreateElement(null, "ListItem", HtmlToXamlConverter.string_0);
			for (XmlNode xmlNode = xmlElement_2.FirstChild; xmlNode != null; xmlNode = ((xmlNode != null) ? xmlNode.NextSibling : null))
			{
				xmlNode = HtmlToXamlConverter.smethod_1(xmlElement, xmlNode, hashtable_, class2_0, list_0);
			}
			xmlElement_1.AppendChild(xmlElement);
		}

		private static void smethod_15(XmlElement xmlElement_1, XmlElement xmlElement_2, Hashtable hashtable_0, Class2 class2_0, List<XmlElement> list_0)
		{
			Hashtable hashtable;
			Hashtable hashtable_ = HtmlToXamlConverter.smethod_37(xmlElement_2, hashtable_0, out hashtable, class2_0, list_0);
			XmlElement xmlElement = HtmlToXamlConverter.smethod_16(xmlElement_2);
			if (xmlElement != null)
			{
				list_0.Add(xmlElement);
				for (XmlNode xmlNode = xmlElement.FirstChild; xmlNode != null; xmlNode = ((xmlNode != null) ? xmlNode.NextSibling : null))
				{
					xmlNode = HtmlToXamlConverter.smethod_1(xmlElement_1, xmlNode, hashtable_, class2_0, list_0);
				}
				list_0.RemoveAt(list_0.Count - 1);
				return;
			}
			XmlElement xmlElement2 = xmlElement_1.OwnerDocument.CreateElement(null, "Table", HtmlToXamlConverter.string_0);
			ArrayList arrayList_ = HtmlToXamlConverter.smethod_23(xmlElement_2, class2_0);
			HtmlToXamlConverter.smethod_17(xmlElement_2, xmlElement2, arrayList_, hashtable_, class2_0, list_0);
			XmlNode xmlNode2 = xmlElement_2.FirstChild;
			while (xmlNode2 != null)
			{
				string a = xmlNode2.LocalName.ToLower();
				if (!(a == "tbody") && !(a == "thead") && !(a == "tfoot"))
				{
					if (a == "tr")
					{
						XmlElement xmlElement3 = xmlElement2.OwnerDocument.CreateElement(null, "TableRowGroup", HtmlToXamlConverter.string_0);
						xmlNode2 = HtmlToXamlConverter.smethod_20(xmlElement3, xmlNode2, hashtable_, arrayList_, class2_0, list_0);
						if (xmlElement3.HasChildNodes)
						{
							xmlElement2.AppendChild(xmlElement3);
						}
					}
					else
					{
						xmlNode2 = xmlNode2.NextSibling;
					}
				}
				else
				{
					XmlElement xmlElement4 = xmlElement2.OwnerDocument.CreateElement(null, "TableRowGroup", HtmlToXamlConverter.string_0);
					xmlElement2.AppendChild(xmlElement4);
					list_0.Add((XmlElement)xmlNode2);
					Hashtable hashtable2;
					Hashtable hashtable_2 = HtmlToXamlConverter.smethod_37((XmlElement)xmlNode2, hashtable_, out hashtable2, class2_0, list_0);
					HtmlToXamlConverter.smethod_20(xmlElement4, xmlNode2.FirstChild, hashtable_2, arrayList_, class2_0, list_0);
					if (xmlElement4.HasChildNodes)
					{
						xmlElement2.AppendChild(xmlElement4);
					}
					list_0.RemoveAt(list_0.Count - 1);
					xmlNode2 = xmlNode2.NextSibling;
				}
			}
			if (xmlElement2.HasChildNodes)
			{
				xmlElement_1.AppendChild(xmlElement2);
			}
		}

		private static XmlElement smethod_16(XmlElement xmlElement_1)
		{
			XmlElement xmlElement = null;
			for (XmlNode xmlNode = xmlElement_1.FirstChild; xmlNode != null; xmlNode = xmlNode.NextSibling)
			{
				string a = xmlNode.LocalName.ToLower();
				if (!(a == "tbody") && !(a == "thead") && !(a == "tfoot"))
				{
					if (xmlNode.LocalName.ToLower() == "tr")
					{
						if (xmlElement != null)
						{
							return null;
						}
						for (XmlNode xmlNode2 = xmlNode.FirstChild; xmlNode2 != null; xmlNode2 = xmlNode2.NextSibling)
						{
							string a2 = xmlNode2.LocalName.ToLower();
							if (a2 == "td" || a2 == "th")
							{
								if (xmlElement != null)
								{
									return null;
								}
								xmlElement = (XmlElement)xmlNode2;
							}
						}
					}
				}
				else
				{
					if (xmlElement != null)
					{
						return null;
					}
					for (XmlNode xmlNode3 = xmlNode.FirstChild; xmlNode3 != null; xmlNode3 = xmlNode3.NextSibling)
					{
						if (xmlNode3.LocalName.ToLower() == "tr")
						{
							if (xmlElement != null)
							{
								return null;
							}
							for (XmlNode xmlNode4 = xmlNode3.FirstChild; xmlNode4 != null; xmlNode4 = xmlNode4.NextSibling)
							{
								string a3 = xmlNode4.LocalName.ToLower();
								if (a3 == "td" || a3 == "th")
								{
									if (xmlElement != null)
									{
										return null;
									}
									xmlElement = (XmlElement)xmlNode4;
								}
							}
						}
					}
				}
			}
			return xmlElement;
		}

		private static void smethod_17(XmlElement xmlElement_1, XmlElement xmlElement_2, ArrayList arrayList_0, Hashtable hashtable_0, Class2 class2_0, List<XmlElement> list_0)
		{
			if (arrayList_0 != null)
			{
				for (int i = 0; i < arrayList_0.Count - 1; i++)
				{
					XmlElement xmlElement = xmlElement_2.OwnerDocument.CreateElement(null, "TableColumn", HtmlToXamlConverter.string_0);
					xmlElement.SetAttribute("Width", ((double)arrayList_0[i + 1] - (double)arrayList_0[i]).ToString());
					xmlElement_2.AppendChild(xmlElement);
				}
				return;
			}
			for (XmlNode xmlNode = xmlElement_1.FirstChild; xmlNode != null; xmlNode = xmlNode.NextSibling)
			{
				if (xmlNode.LocalName.ToLower() == "colgroup")
				{
					HtmlToXamlConverter.smethod_18(xmlElement_2, (XmlElement)xmlNode, hashtable_0, class2_0, list_0);
				}
				else if (xmlNode.LocalName.ToLower() == "col")
				{
					HtmlToXamlConverter.smethod_19(xmlElement_2, (XmlElement)xmlNode, hashtable_0, class2_0, list_0);
				}
				else if (xmlNode is XmlElement)
				{
					break;
				}
			}
		}

		private static void smethod_18(XmlElement xmlElement_1, XmlElement xmlElement_2, Hashtable hashtable_0, Class2 class2_0, List<XmlElement> list_0)
		{
			Hashtable hashtable;
			Hashtable hashtable_ = HtmlToXamlConverter.smethod_37(xmlElement_2, hashtable_0, out hashtable, class2_0, list_0);
			for (XmlNode xmlNode = xmlElement_2.FirstChild; xmlNode != null; xmlNode = xmlNode.NextSibling)
			{
				if (xmlNode is XmlElement && xmlNode.LocalName.ToLower() == "col")
				{
					HtmlToXamlConverter.smethod_19(xmlElement_1, (XmlElement)xmlNode, hashtable_, class2_0, list_0);
				}
			}
		}

		private static void smethod_19(XmlElement xmlElement_1, XmlElement xmlElement_2, Hashtable hashtable_0, Class2 class2_0, List<XmlElement> list_0)
		{
			Hashtable hashtable;
			HtmlToXamlConverter.smethod_37(xmlElement_2, hashtable_0, out hashtable, class2_0, list_0);
			XmlElement newChild = xmlElement_1.OwnerDocument.CreateElement(null, "TableColumn", HtmlToXamlConverter.string_0);
			xmlElement_1.AppendChild(newChild);
		}

		private static XmlNode smethod_20(XmlElement xmlElement_1, XmlNode xmlNode_0, Hashtable hashtable_0, ArrayList arrayList_0, Class2 class2_0, List<XmlElement> list_0)
		{
			XmlNode xmlNode = xmlNode_0;
			ArrayList arrayList = null;
			if (arrayList_0 != null)
			{
				arrayList = new ArrayList();
				HtmlToXamlConverter.smethod_29(arrayList, arrayList_0.Count);
			}
			while (xmlNode != null && xmlNode.LocalName.ToLower() != "tbody")
			{
				if (xmlNode.LocalName.ToLower() == "tr")
				{
					XmlElement xmlElement = xmlElement_1.OwnerDocument.CreateElement(null, "TableRow", HtmlToXamlConverter.string_0);
					list_0.Add((XmlElement)xmlNode);
					Hashtable hashtable;
					Hashtable hashtable_ = HtmlToXamlConverter.smethod_37((XmlElement)xmlNode, hashtable_0, out hashtable, class2_0, list_0);
					HtmlToXamlConverter.smethod_21(xmlElement, xmlNode.FirstChild, hashtable_, arrayList_0, arrayList, class2_0, list_0);
					if (xmlElement.HasChildNodes)
					{
						xmlElement_1.AppendChild(xmlElement);
					}
					list_0.RemoveAt(list_0.Count - 1);
					xmlNode = xmlNode.NextSibling;
				}
				else if (xmlNode.LocalName.ToLower() == "td")
				{
					XmlElement xmlElement2 = xmlElement_1.OwnerDocument.CreateElement(null, "TableRow", HtmlToXamlConverter.string_0);
					xmlNode = HtmlToXamlConverter.smethod_21(xmlElement2, xmlNode, hashtable_0, arrayList_0, arrayList, class2_0, list_0);
					if (xmlElement2.HasChildNodes)
					{
						xmlElement_1.AppendChild(xmlElement2);
					}
				}
				else
				{
					xmlNode = xmlNode.NextSibling;
				}
			}
			return xmlNode;
		}

		private static XmlNode smethod_21(XmlElement xmlElement_1, XmlNode xmlNode_0, Hashtable hashtable_0, ArrayList arrayList_0, ArrayList arrayList_1, Class2 class2_0, List<XmlElement> list_0)
		{
			XmlNode xmlNode = xmlNode_0;
			int num = 0;
			while (xmlNode != null && xmlNode.LocalName.ToLower() != "tr" && xmlNode.LocalName.ToLower() != "tbody" && xmlNode.LocalName.ToLower() != "thead" && xmlNode.LocalName.ToLower() != "tfoot")
			{
				if (!(xmlNode.LocalName.ToLower() == "td") && !(xmlNode.LocalName.ToLower() == "th"))
				{
					xmlNode = xmlNode.NextSibling;
				}
				else
				{
					XmlElement xmlElement = xmlElement_1.OwnerDocument.CreateElement(null, "TableCell", HtmlToXamlConverter.string_0);
					list_0.Add((XmlElement)xmlNode);
					Hashtable hashtable;
					Hashtable hashtable_ = HtmlToXamlConverter.smethod_37((XmlElement)xmlNode, hashtable_0, out hashtable, class2_0, list_0);
					HtmlToXamlConverter.smethod_41((XmlElement)xmlNode, xmlElement);
					if (arrayList_0 != null)
					{
						while (num < arrayList_1.Count && (int)arrayList_1[num] > 0)
						{
							arrayList_1[num] = (int)arrayList_1[num] - 1;
							num++;
						}
						double num2 = (double)arrayList_0[num];
						double double_ = HtmlToXamlConverter.smethod_31((XmlElement)xmlNode);
						int num3 = HtmlToXamlConverter.smethod_32(num, double_, arrayList_0);
						int num4 = HtmlToXamlConverter.smethod_26((XmlElement)xmlNode);
						xmlElement.SetAttribute("ColumnSpan", num3.ToString());
						for (int i = num; i < num + num3; i++)
						{
							arrayList_1[i] = num4 - 1;
						}
						num += num3;
					}
					HtmlToXamlConverter.smethod_22(xmlElement, xmlNode.FirstChild, hashtable_, class2_0, list_0);
					if (xmlElement.HasChildNodes)
					{
						xmlElement_1.AppendChild(xmlElement);
					}
					list_0.RemoveAt(list_0.Count - 1);
					xmlNode = xmlNode.NextSibling;
				}
			}
			return xmlNode;
		}

		private static void smethod_22(XmlElement xmlElement_1, XmlNode xmlNode_0, Hashtable hashtable_0, Class2 class2_0, List<XmlElement> list_0)
		{
			for (XmlNode xmlNode = xmlNode_0; xmlNode != null; xmlNode = ((xmlNode != null) ? xmlNode.NextSibling : null))
			{
				xmlNode = HtmlToXamlConverter.smethod_1(xmlElement_1, xmlNode, hashtable_0, class2_0, list_0);
			}
		}

		private static ArrayList smethod_23(XmlElement xmlElement_1, Class2 class2_0)
		{
			if (!xmlElement_1.HasChildNodes)
			{
				return null;
			}
			bool flag = true;
			ArrayList arrayList = new ArrayList();
			ArrayList arrayList_ = new ArrayList();
			XmlNode xmlNode = xmlElement_1.FirstChild;
			double num = 0.0;
			while (xmlNode != null && flag)
			{
				string a = xmlNode.LocalName.ToLower();
				if (!(a == "tbody"))
				{
					if (!(a == "tr"))
					{
						if (a == "td")
						{
							flag = false;
						}
					}
					else
					{
						double num2 = HtmlToXamlConverter.smethod_25((XmlElement)xmlNode, arrayList, arrayList_, num, class2_0);
						if (num2 > num)
						{
							num = num2;
						}
						else if (num2 == 0.0)
						{
							flag = false;
						}
					}
				}
				else
				{
					double num3 = HtmlToXamlConverter.smethod_24((XmlElement)xmlNode, arrayList, arrayList_, num, class2_0);
					if (num3 > num)
					{
						num = num3;
					}
					else if (num3 == 0.0)
					{
						flag = false;
					}
				}
				xmlNode = xmlNode.NextSibling;
			}
			if (flag)
			{
				arrayList.Add(num);
				HtmlToXamlConverter.smethod_33(arrayList);
			}
			else
			{
				arrayList = null;
			}
			return arrayList;
		}

		private static double smethod_24(XmlElement xmlElement_1, ArrayList arrayList_0, ArrayList arrayList_1, double double_0, Class2 class2_0)
		{
			double num = 0.0;
			bool flag = true;
			if (!xmlElement_1.HasChildNodes)
			{
				return num;
			}
			HtmlToXamlConverter.smethod_28(arrayList_1);
			XmlNode xmlNode = xmlElement_1.FirstChild;
			while (xmlNode != null && flag)
			{
				string a = xmlNode.LocalName.ToLower();
				if (!(a == "tr"))
				{
					if (a == "td")
					{
						flag = false;
					}
				}
				else
				{
					double num2 = HtmlToXamlConverter.smethod_25((XmlElement)xmlNode, arrayList_0, arrayList_1, num, class2_0);
					if (num2 > num)
					{
						num = num2;
					}
				}
				xmlNode = xmlNode.NextSibling;
			}
			HtmlToXamlConverter.smethod_28(arrayList_1);
			if (!flag)
			{
				return 0.0;
			}
			return num;
		}

		private static double smethod_25(XmlElement xmlElement_1, ArrayList arrayList_0, ArrayList arrayList_1, double double_0, Class2 class2_0)
		{
			if (!xmlElement_1.HasChildNodes)
			{
				return 0.0;
			}
			bool flag = true;
			double num = 0.0;
			XmlNode xmlNode = xmlElement_1.FirstChild;
			int num2 = 0;
			if (0 < arrayList_1.Count && (double)arrayList_0[num2] == num)
			{
				while (num2 < arrayList_1.Count && (int)arrayList_1[num2] > 0)
				{
					arrayList_1[num2] = (int)arrayList_1[num2] - 1;
					num2++;
					num = (double)arrayList_0[num2];
				}
			}
			while (xmlNode != null && flag)
			{
				HtmlToXamlConverter.smethod_33(arrayList_0);
				string a = xmlNode.LocalName.ToLower();
				if (a == "td")
				{
					if (num2 < arrayList_0.Count)
					{
						if (num < (double)arrayList_0[num2])
						{
							arrayList_0.Insert(num2, num);
							arrayList_1.Insert(num2, 0);
						}
					}
					else
					{
						arrayList_0.Add(num);
						arrayList_1.Add(0);
					}
					double num3 = HtmlToXamlConverter.smethod_31((XmlElement)xmlNode);
					if (num3 != -1.0)
					{
						int num4 = HtmlToXamlConverter.smethod_26((XmlElement)xmlNode);
						int num5 = HtmlToXamlConverter.smethod_27(num2, num3, arrayList_0, arrayList_1);
						if (num5 != -1)
						{
							for (int i = num2; i < num5; i++)
							{
								arrayList_1[i] = num4 - 1;
							}
							num2 = num5;
							num += num3;
							if (num2 < arrayList_1.Count && (double)arrayList_0[num2] == num)
							{
								while (num2 < arrayList_1.Count && (int)arrayList_1[num2] > 0)
								{
									arrayList_1[num2] = (int)arrayList_1[num2] - 1;
									num2++;
									num = (double)arrayList_0[num2];
								}
							}
						}
						else
						{
							flag = false;
						}
					}
					else
					{
						flag = false;
					}
				}
				xmlNode = xmlNode.NextSibling;
			}
			double result;
			if (flag)
			{
				result = num;
			}
			else
			{
				result = 0.0;
			}
			return result;
		}

		private static int smethod_26(XmlElement xmlElement_1)
		{
			string attribute = HtmlToXamlConverter.GetAttribute(xmlElement_1, "rowspan");
			int result;
			if (attribute != null)
			{
				if (!int.TryParse(attribute, out result))
				{
					result = 1;
				}
			}
			else
			{
				result = 1;
			}
			return result;
		}

		private static int smethod_27(int int_0, double double_0, ArrayList arrayList_0, ArrayList arrayList_1)
		{
			double num = (double)arrayList_0[int_0];
			int num2 = int_0 + 1;
			while (num2 < arrayList_0.Count && (double)arrayList_0[num2] < num + double_0)
			{
				if (num2 == -1)
				{
					break;
				}
				if ((int)arrayList_1[num2] > 0)
				{
					num2 = -1;
				}
				else
				{
					num2++;
				}
			}
			return num2;
		}

		private static void smethod_28(ArrayList arrayList_0)
		{
			for (int i = 0; i < arrayList_0.Count; i++)
			{
				arrayList_0[i] = 0;
			}
		}

		private static void smethod_29(ArrayList arrayList_0, int int_0)
		{
			for (int i = 0; i < int_0; i++)
			{
				arrayList_0.Add(0);
			}
		}

		private static double smethod_30(XmlElement xmlElement_1, double double_0)
		{
			double num = HtmlToXamlConverter.smethod_31(xmlElement_1);
			double result;
			if (num == -1.0)
			{
				result = -1.0;
			}
			else
			{
				result = double_0 + num;
			}
			return result;
		}

		private static double smethod_31(XmlElement xmlElement_1)
		{
			double num = -1.0;
			string text = HtmlToXamlConverter.GetAttribute(xmlElement_1, "width");
			if (text == null)
			{
				text = HtmlToXamlConverter.smethod_38(HtmlToXamlConverter.GetAttribute(xmlElement_1, "style"), "width");
			}
			if (!HtmlToXamlConverter.smethod_39(text, out num) || num == 0.0)
			{
				num = -1.0;
			}
			return num;
		}

		private static int smethod_32(int int_0, double double_0, ArrayList arrayList_0)
		{
			int num = int_0;
			double num2 = 0.0;
			while (num2 < double_0 && num < arrayList_0.Count - 1)
			{
				double num3 = (double)arrayList_0[num + 1] - (double)arrayList_0[num];
				num2 += num3;
				num++;
			}
			return num - int_0;
		}

		private static void smethod_33(ArrayList arrayList_0)
		{
			for (int i = 0; i < arrayList_0.Count; i++)
			{
				double num = (double)arrayList_0[i];
			}
		}

		private static void smethod_34(XmlElement xmlElement_1, Hashtable hashtable_0, bool bool_0)
		{
			bool flag = false;
			string string_ = "0";
			string string_2 = "0";
			string string_3 = "0";
			string string_4 = "0";
			bool flag2 = false;
			string string_5 = "0";
			string string_6 = "0";
			string string_7 = "0";
			string string_8 = "0";
			string text = null;
			bool flag3 = false;
			string string_9 = "0";
			string string_10 = "0";
			string string_11 = "0";
			string string_12 = "0";
			IDictionaryEnumerator enumerator = hashtable_0.GetEnumerator();
			while (enumerator.MoveNext())
			{
				string text2 = (string)enumerator.Key;
				uint num = PrivateImplementationDetails.ComputeStringHash(text2);
				if (num <= 2010921002u)
				{
					if (num <= 1142570743u)
					{
						if (num <= 823368261u)
						{
							if (num <= 219030440u)
							{
								if (num != 127652482u)
								{
									if (num != 219030440u)
									{
										continue;
									}
									if (!(text2 == "font-variant"))
									{
										continue;
									}
									continue;
								}
								else
								{
									if (text2 == "text-align" && bool_0)
									{
										xmlElement_1.SetAttribute("TextAlignment", (string)enumerator.Value);
										continue;
									}
									continue;
								}
							}
							else if (num != 252494808u)
							{
								if (num != 549768767u)
								{
									if (num != 823368261u)
									{
										continue;
									}
									if (text2 == "margin-top")
									{
										flag = true;
										string_ = (string)enumerator.Value;
										continue;
									}
									continue;
								}
								else
								{
									if (text2 == "font-family")
									{
										xmlElement_1.SetAttribute("FontFamily", (string)enumerator.Value);
										continue;
									}
									continue;
								}
							}
							else
							{
								if (text2 == "font-style")
								{
									xmlElement_1.SetAttribute("FontStyle", (string)enumerator.Value);
									continue;
								}
								continue;
							}
						}
						else if (num <= 1031692888u)
						{
							if (num != 883380135u)
							{
								if (num != 1031692888u)
								{
									continue;
								}
								if (text2 == "color")
								{
									HtmlToXamlConverter.smethod_36(xmlElement_1, TextElement.ForegroundProperty, (string)enumerator.Value);
									continue;
								}
								continue;
							}
							else
							{
								if (text2 == "text-indent" && bool_0)
								{
									xmlElement_1.SetAttribute("TextIndent", (string)enumerator.Value);
									continue;
								}
								continue;
							}
						}
						else if (num != 1043390919u)
						{
							if (num != 1053765672u)
							{
								if (num != 1142570743u)
								{
									continue;
								}
								if (text2 == "border-color-top")
								{
									text = (string)enumerator.Value;
									continue;
								}
								continue;
							}
							else if (!(text2 == "text-decoration-line-through"))
							{
								continue;
							}
						}
						else
						{
							if (!(text2 == "border-style-left"))
							{
								continue;
							}
							continue;
						}
					}
					else if (num <= 1466694928u)
					{
						if (num <= 1177978080u)
						{
							if (num != 1164572437u)
							{
								if (num != 1177978080u)
								{
									continue;
								}
								if (text2 == "margin-right")
								{
									flag = true;
									string_4 = (string)enumerator.Value;
									continue;
								}
								continue;
							}
							else
							{
								if (!(text2 == "display"))
								{
									continue;
								}
								continue;
							}
						}
						else if (num != 1306599407u)
						{
							if (num != 1441012905u)
							{
								if (num != 1466694928u)
								{
									continue;
								}
								if (text2 == "padding-top")
								{
									flag2 = true;
									string_5 = (string)enumerator.Value;
									continue;
								}
								continue;
							}
							else
							{
								if (!(text2 == "border-style-bottom"))
								{
									continue;
								}
								continue;
							}
						}
						else
						{
							if (text2 == "margin-left")
							{
								flag = true;
								string_3 = (string)enumerator.Value;
								continue;
							}
							continue;
						}
					}
					else if (num <= 1582255333u)
					{
						if (num != 1550717474u)
						{
							if (num != 1582255333u)
							{
								continue;
							}
							if (text2 == "border-width-right")
							{
								flag3 = true;
								string_12 = (string)enumerator.Value;
								continue;
							}
							continue;
						}
						else
						{
							if (!(text2 == "clear"))
							{
								continue;
							}
							continue;
						}
					}
					else if (num != 1623313461u)
					{
						if (num != 1853416278u)
						{
							if (num != 2010921002u)
							{
								continue;
							}
							if (text2 == "border-width-bottom")
							{
								flag3 = true;
								string_10 = (string)enumerator.Value;
								continue;
							}
							continue;
						}
						else if (!(text2 == "text-decoration-overline"))
						{
							continue;
						}
					}
					else
					{
						if (text2 == "border-color-left")
						{
							text = (string)enumerator.Value;
							continue;
						}
						continue;
					}
				}
				else if (num <= 2844431412u)
				{
					if (num <= 2533208432u)
					{
						if (num <= 2302461567u)
						{
							if (num != 2275550012u)
							{
								if (num != 2302461567u)
								{
									continue;
								}
								if (text2 == "border-color-bottom")
								{
									text = (string)enumerator.Value;
									continue;
								}
								continue;
							}
							else
							{
								if (text2 == "border-width-top")
								{
									flag3 = true;
									string_9 = (string)enumerator.Value;
									continue;
								}
								continue;
							}
						}
						else if (num != 2416839281u)
						{
							if (num != 2508680735u)
							{
								if (num != 2533208432u)
								{
									continue;
								}
								if (text2 == "border-width-left")
								{
									flag3 = true;
									string_11 = (string)enumerator.Value;
									continue;
								}
								continue;
							}
							else
							{
								if (!(text2 == "width"))
								{
									continue;
								}
								continue;
							}
						}
						else
						{
							if (text2 == "margin-bottom")
							{
								flag = true;
								string_2 = (string)enumerator.Value;
								continue;
							}
							continue;
						}
					}
					else if (num <= 2797886853u)
					{
						if (num != 2789833231u)
						{
							if (num != 2797886853u)
							{
								continue;
							}
							if (!(text2 == "float"))
							{
								continue;
							}
							continue;
						}
						else
						{
							if (!(text2 == "text-transform"))
							{
								continue;
							}
							continue;
						}
					}
					else if (num != 2828698125u)
					{
						if (num != 2835574862u)
						{
							if (num != 2844431412u)
							{
								continue;
							}
							if (!(text2 == "text-decoration-none"))
							{
								continue;
							}
						}
						else
						{
							if (text2 == "border-color-right")
							{
								text = (string)enumerator.Value;
								continue;
							}
							continue;
						}
					}
					else
					{
						if (!(text2 == "border-style-top"))
						{
							continue;
						}
						continue;
					}
				}
				else if (num <= 3341934034u)
				{
					if (num <= 3173719076u)
					{
						if (num != 2876783500u)
						{
							if (num != 3173719076u)
							{
								continue;
							}
							if (text2 == "list-style-type" && xmlElement_1.LocalName == "List")
							{
								text2 = ((string)enumerator.Value).ToLower();
								num = PrivateImplementationDetails.ComputeStringHash(text2);
								string value;
								if (num <= 1892056626u)
								{
									if (num <= 673280137u)
									{
										if (num != 520654156u)
										{
											if (num != 673280137u)
											{
												goto IL_820;
											}
											if (!(text2 == "circle"))
											{
												goto IL_820;
											}
											value = "Circle";
										}
										else
										{
											if (!(text2 == "decimal"))
											{
												goto IL_820;
											}
											value = "Decimal";
										}
									}
									else if (num != 1029714956u)
									{
										if (num != 1374042131u)
										{
											if (num != 1892056626u)
											{
												goto IL_820;
											}
											if (!(text2 == "box"))
											{
												goto IL_820;
											}
											value = "Box";
										}
										else
										{
											if (!(text2 == "upper-roman"))
											{
												goto IL_820;
											}
											value = "UpperRoman";
										}
									}
									else
									{
										if (!(text2 == "disc"))
										{
											goto IL_820;
										}
										value = "Disc";
									}
								}
								else if (num <= 3031831110u)
								{
									if (num != 2913447899u)
									{
										if (num != 3031831110u)
										{
											goto IL_820;
										}
										if (!(text2 == "square"))
										{
											goto IL_820;
										}
										value = "Square";
									}
									else
									{
										if (!(text2 == "none"))
										{
											goto IL_820;
										}
										value = "None";
									}
								}
								else if (num != 3084654112u)
								{
									if (num != 3907785873u)
									{
										if (num != 4050104546u)
										{
											goto IL_820;
										}
										if (!(text2 == "lower-roman"))
										{
											goto IL_820;
										}
										value = "LowerRoman";
									}
									else
									{
										if (!(text2 == "lower-latin"))
										{
											goto IL_820;
										}
										value = "LowerLatin";
									}
								}
								else
								{
									if (!(text2 == "upper-latin"))
									{
										goto IL_820;
									}
									value = "UpperLatin";
								}
								IL_830:
								xmlElement_1.SetAttribute("MarkerStyle", value);
								continue;
								IL_820:
								value = "Disc";
								goto IL_830;
							}
							continue;
						}
						else
						{
							if (text2 == "padding-left")
							{
								flag2 = true;
								string_7 = (string)enumerator.Value;
								continue;
							}
							continue;
						}
					}
					else if (num != 3247228931u)
					{
						if (num != 3328355879u)
						{
							if (num != 3341934034u)
							{
								continue;
							}
							if (text2 == "text-decoration-underline" && !bool_0 && (string)enumerator.Value == "true")
							{
								xmlElement_1.SetAttribute("TextDecorations", "Underline");
								continue;
							}
							continue;
						}
						else
						{
							if (text2 == "background-color")
							{
								HtmlToXamlConverter.smethod_36(xmlElement_1, TextElement.BackgroundProperty, (string)enumerator.Value);
								continue;
							}
							continue;
						}
					}
					else
					{
						if (text2 == "font-weight")
						{
							xmlElement_1.SetAttribute("FontWeight", (string)enumerator.Value);
							continue;
						}
						continue;
					}
				}
				else if (num <= 3666530808u)
				{
					if (num != 3391345689u)
					{
						if (num != 3585981250u)
						{
							if (num != 3666530808u)
							{
								continue;
							}
							if (!(text2 == "border-style-right"))
							{
								continue;
							}
							continue;
						}
						else
						{
							if (!(text2 == "height"))
							{
								continue;
							}
							continue;
						}
					}
					else
					{
						if (text2 == "padding-right")
						{
							flag2 = true;
							string_8 = (string)enumerator.Value;
							continue;
						}
						continue;
					}
				}
				else if (num != 3864881540u)
				{
					if (num != 3975754638u)
					{
						if (num != 4284404126u)
						{
							continue;
						}
						if (text2 == "font-size")
						{
							xmlElement_1.SetAttribute("FontSize", (string)enumerator.Value);
							continue;
						}
						continue;
					}
					else
					{
						if (text2 == "padding-bottom")
						{
							flag2 = true;
							string_6 = (string)enumerator.Value;
							continue;
						}
						continue;
					}
				}
				else if (!(text2 == "text-decoration-blink"))
				{
					continue;
				}
				if (bool_0)
				{
				}
			}
			if (bool_0)
			{
				if (flag)
				{
					HtmlToXamlConverter.smethod_35(xmlElement_1, "Margin", string_3, string_4, string_, string_2);
				}
				if (flag2)
				{
					HtmlToXamlConverter.smethod_35(xmlElement_1, "Padding", string_7, string_8, string_5, string_6);
				}
				if (text != null)
				{
					xmlElement_1.SetAttribute("BorderBrush", text);
				}
				if (flag3)
				{
					HtmlToXamlConverter.smethod_35(xmlElement_1, "BorderThickness", string_11, string_12, string_9, string_10);
				}
			}
		}

		private static void smethod_35(XmlElement xmlElement_1, string string_1, string string_2, string string_3, string string_4, string string_5)
		{
			if (string_2[0] == '0' || string_2[0] == '-')
			{
				string_2 = "0";
			}
			if (string_3[0] == '0' || string_3[0] == '-')
			{
				string_3 = "0";
			}
			if (string_4[0] == '0' || string_4[0] == '-')
			{
				string_4 = "0";
			}
			if (string_5[0] == '0' || string_5[0] == '-')
			{
				string_5 = "0";
			}
			string value;
			if (string_2 == string_3 && string_4 == string_5)
			{
				if (string_2 == string_4)
				{
					value = string_2;
				}
				else
				{
					value = string_2 + "," + string_4;
				}
			}
			else
			{
				value = string.Concat(new string[]
				{
					string_2,
					",",
					string_4,
					",",
					string_3,
					",",
					string_5
				});
			}
			xmlElement_1.SetAttribute(string_1, value);
		}

		private static void smethod_36(XmlElement xmlElement_1, DependencyProperty dependencyProperty_0, string string_1)
		{
			TypeConverter converter = TypeDescriptor.GetConverter(dependencyProperty_0.PropertyType);
			try
			{
				if (converter.ConvertFromInvariantString(string_1) != null)
				{
					xmlElement_1.SetAttribute(dependencyProperty_0.Name, string_1);
				}
			}
			catch (Exception)
			{
			}
		}

		private static Hashtable smethod_37(XmlElement xmlElement_1, Hashtable hashtable_0, out Hashtable hashtable_1, Class2 class2_0, List<XmlElement> list_0)
		{
			Hashtable hashtable = new Hashtable();
			IDictionaryEnumerator enumerator = hashtable_0.GetEnumerator();
			while (enumerator.MoveNext())
			{
				hashtable[enumerator.Key] = enumerator.Value;
			}
			string text = xmlElement_1.LocalName.ToLower();
			string namespaceURI = xmlElement_1.NamespaceURI;
			hashtable_1 = new Hashtable();
			uint num = PrivateImplementationDetails.ComputeStringHash(text);
			if (num <= 3307167098u)
			{
				if (num <= 1664365302u)
				{
					if (num <= 1249556454u)
					{
						if (num != 659427984u)
						{
							if (num != 1075471351u)
							{
								if (num != 1249556454u)
								{
									goto IL_626;
								}
								if (text == "pre")
								{
									hashtable_1["font-family"] = "Courier New";
									hashtable_1["font-size"] = "8pt";
									hashtable_1["text-align"] = "Left";
									goto IL_626;
								}
								goto IL_626;
							}
							else
							{
								if (!(text == "em"))
								{
									goto IL_626;
								}
								goto IL_5E5;
							}
						}
						else
						{
							if (!(text == "font"))
							{
								goto IL_626;
							}
							string attribute = HtmlToXamlConverter.GetAttribute(xmlElement_1, "face");
							if (attribute != null)
							{
								hashtable_1["font-family"] = attribute;
							}
							attribute = HtmlToXamlConverter.GetAttribute(xmlElement_1, "size");
							if (attribute != null)
							{
								double num2 = double.Parse(attribute) * 4.0;
								if (num2 < 1.0)
								{
									num2 = 1.0;
								}
								else if (num2 > 1000.0)
								{
									num2 = 1000.0;
								}
								hashtable_1["font-size"] = num2.ToString();
							}
							attribute = HtmlToXamlConverter.GetAttribute(xmlElement_1, "color");
							if (attribute != null)
							{
								hashtable_1["color"] = attribute;
								goto IL_626;
							}
							goto IL_626;
						}
					}
					else if (num <= 1598240564u)
					{
						if (num != 1251777503u)
						{
							if (num != 1598240564u)
							{
								goto IL_626;
							}
							if (text == "ul")
							{
								hashtable_1["list-style-type"] = "disc";
								goto IL_626;
							}
							goto IL_626;
						}
						else
						{
							if (!(text == "table"))
							{
								goto IL_626;
							}
							goto IL_626;
						}
					}
					else if (num != 1625946989u)
					{
						if (num != 1664365302u)
						{
							goto IL_626;
						}
						if (text == "ol")
						{
							hashtable_1["list-style-type"] = "decimal";
							goto IL_626;
						}
						goto IL_626;
					}
					else
					{
						if (!(text == "italic"))
						{
							goto IL_626;
						}
						goto IL_5E5;
					}
				}
				else if (num <= 2386244204u)
				{
					if (num <= 2352688966u)
					{
						if (num != 2335911347u)
						{
							if (num != 2352688966u)
							{
								goto IL_626;
							}
							if (text == "h5")
							{
								hashtable_1["font-size"] = "12pt";
								goto IL_626;
							}
							goto IL_626;
						}
						else
						{
							if (text == "h6")
							{
								hashtable_1["font-size"] = "10pt";
								goto IL_626;
							}
							goto IL_626;
						}
					}
					else if (num != 2369466585u)
					{
						if (num != 2386244204u)
						{
							goto IL_626;
						}
						if (text == "h3")
						{
							hashtable_1["font-size"] = "18pt";
							goto IL_626;
						}
						goto IL_626;
					}
					else
					{
						if (text == "h4")
						{
							hashtable_1["font-size"] = "16pt";
							goto IL_626;
						}
						goto IL_626;
					}
				}
				else if (num <= 2419799442u)
				{
					if (num != 2403021823u)
					{
						if (num != 2419799442u)
						{
							goto IL_626;
						}
						if (text == "h1")
						{
							hashtable_1["font-size"] = "22pt";
							goto IL_626;
						}
						goto IL_626;
					}
					else
					{
						if (text == "h2")
						{
							hashtable_1["font-size"] = "20pt";
							goto IL_626;
						}
						goto IL_626;
					}
				}
				else if (num != 3222025668u)
				{
					if (num != 3307167098u)
					{
						goto IL_626;
					}
					if (!(text == "strong"))
					{
						goto IL_626;
					}
				}
				else
				{
					if (text == "samp")
					{
						hashtable_1["font-family"] = "Courier New";
						hashtable_1["font-size"] = "8pt";
						hashtable_1["text-align"] = "Left";
						goto IL_626;
					}
					goto IL_626;
				}
			}
			else
			{
				if (num > 3784120478u)
				{
					if (num <= 3876335077u)
					{
						if (num <= 3848448840u)
						{
							if (num != 3826002220u)
							{
								if (num != 3848448840u)
								{
									goto IL_626;
								}
								if (!(text == "div"))
								{
									goto IL_626;
								}
								goto IL_626;
							}
							else
							{
								if (!(text == "a"))
								{
									goto IL_626;
								}
								goto IL_626;
							}
						}
						else if (num != 3850515583u)
						{
							if (num != 3876335077u)
							{
								goto IL_626;
							}
							if (text == "b")
							{
								goto IL_576;
							}
							goto IL_626;
						}
						else if (!(text == "underline"))
						{
							goto IL_626;
						}
					}
					else if (num <= 4027333648u)
					{
						if (num != 3960223172u)
						{
							if (num != 4027333648u)
							{
								goto IL_626;
							}
							if (!(text == "u"))
							{
								goto IL_626;
							}
						}
						else
						{
							if (text == "i")
							{
								goto IL_5E5;
							}
							goto IL_626;
						}
					}
					else if (num != 4105856554u)
					{
						if (num != 4111221743u)
						{
							goto IL_626;
						}
						if (!(text == "p"))
						{
							goto IL_626;
						}
						goto IL_626;
					}
					else
					{
						if (text == "acronym")
						{
							goto IL_626;
						}
						goto IL_626;
					}
					hashtable_1["text-decoration-underline"] = "true";
					goto IL_626;
				}
				if (num <= 3614812112u)
				{
					if (num != 3394116799u)
					{
						if (num != 3478605747u)
						{
							if (num != 3614812112u)
							{
								goto IL_626;
							}
							if (!(text == "html"))
							{
								goto IL_626;
							}
							goto IL_626;
						}
						else if (!(text == "dfn"))
						{
							goto IL_626;
						}
					}
					else
					{
						if (!(text == "sup"))
						{
							goto IL_626;
						}
						goto IL_626;
					}
				}
				else if (num <= 3696113941u)
				{
					if (num != 3685382517u)
					{
						if (num != 3696113941u)
						{
							goto IL_626;
						}
						if (!(text == "sub"))
						{
							goto IL_626;
						}
						goto IL_626;
					}
					else
					{
						if (!(text == "body"))
						{
							goto IL_626;
						}
						goto IL_626;
					}
				}
				else if (num != 3734435446u)
				{
					if (num != 3784120478u)
					{
						goto IL_626;
					}
					if (text == "blockquote")
					{
						hashtable_1["margin-left"] = "16";
						goto IL_626;
					}
					goto IL_626;
				}
				else if (!(text == "bold"))
				{
					goto IL_626;
				}
			}
			IL_576:
			hashtable_1["font-weight"] = "bold";
			goto IL_626;
			IL_5E5:
			hashtable_1["font-style"] = "italic";
			IL_626:
			Class1.smethod_0(xmlElement_1, text, class2_0, hashtable_1, list_0);
			enumerator = hashtable_1.GetEnumerator();
			while (enumerator.MoveNext())
			{
				hashtable[enumerator.Key] = enumerator.Value;
			}
			return hashtable;
		}

		private static string smethod_38(string string_1, string string_2)
		{
			if (string_1 != null)
			{
				string_2 = string_2.ToLower();
				string[] array = string_1.Split(new char[]
				{
					';'
				});
				for (int i = 0; i < array.Length; i++)
				{
					string[] array2 = array[i].Split(new char[]
					{
						':'
					});
					if (array2.Length == 2 && array2[0].Trim().ToLower() == string_2)
					{
						return array2[1].Trim();
					}
				}
			}
			return null;
		}

		private static bool smethod_39(string string_1, out double double_0)
		{
			double_0 = double.NaN;
			if (string_1 != null)
			{
				string_1 = string_1.Trim().ToLower();
				if (string_1.EndsWith("pt"))
				{
					string_1 = string_1.Substring(0, string_1.Length - 2);
					if (double.TryParse(string_1, out double_0))
					{
						double_0 = double_0 * 96.0 / 72.0;
					}
					else
					{
						double_0 = double.NaN;
					}
				}
				else if (string_1.EndsWith("px"))
				{
					string_1 = string_1.Substring(0, string_1.Length - 2);
					if (!double.TryParse(string_1, out double_0))
					{
						double_0 = double.NaN;
					}
				}
				else if (!double.TryParse(string_1, out double_0))
				{
					double_0 = double.NaN;
				}
			}
			return !double.IsNaN(double_0);
		}

		private static string smethod_40(string string_1)
		{
			return string_1;
		}

		private static void smethod_41(XmlElement xmlElement_1, XmlElement xmlElement_2)
		{
			xmlElement_2.SetAttribute("BorderThickness", "1,1,1,1");
			xmlElement_2.SetAttribute("BorderBrush", "Black");
			string attribute = HtmlToXamlConverter.GetAttribute(xmlElement_1, "rowspan");
			if (attribute != null)
			{
				xmlElement_2.SetAttribute("RowSpan", attribute);
			}
		}

		static HtmlToXamlConverter()
		{
			// Note: this type is marked as 'beforefieldinit'.
			
			HtmlToXamlConverter.string_0 = "http://schemas.microsoft.com/winfx/2006/xaml/presentation";
		}

		private static XmlElement xmlElement_0;

		public const string Xaml_FlowDocument = "FlowDocument";

		public const string Xaml_Run = "Run";

		public const string Xaml_Span = "Span";

		public const string Xaml_Hyperlink = "Hyperlink";

		public const string Xaml_Hyperlink_NavigateUri = "NavigateUri";

		public const string Xaml_Hyperlink_TargetName = "TargetName";

		public const string Xaml_Section = "Section";

		public const string Xaml_List = "List";

		public const string Xaml_List_MarkerStyle = "MarkerStyle";

		public const string Xaml_List_MarkerStyle_None = "None";

		public const string Xaml_List_MarkerStyle_Decimal = "Decimal";

		public const string Xaml_List_MarkerStyle_Disc = "Disc";

		public const string Xaml_List_MarkerStyle_Circle = "Circle";

		public const string Xaml_List_MarkerStyle_Square = "Square";

		public const string Xaml_List_MarkerStyle_Box = "Box";

		public const string Xaml_List_MarkerStyle_LowerLatin = "LowerLatin";

		public const string Xaml_List_MarkerStyle_UpperLatin = "UpperLatin";

		public const string Xaml_List_MarkerStyle_LowerRoman = "LowerRoman";

		public const string Xaml_List_MarkerStyle_UpperRoman = "UpperRoman";

		public const string Xaml_ListItem = "ListItem";

		public const string Xaml_LineBreak = "LineBreak";

		public const string Xaml_Paragraph = "Paragraph";

		public const string Xaml_Margin = "Margin";

		public const string Xaml_Padding = "Padding";

		public const string Xaml_BorderBrush = "BorderBrush";

		public const string Xaml_BorderThickness = "BorderThickness";

		public const string Xaml_Table = "Table";

		public const string Xaml_TableColumn = "TableColumn";

		public const string Xaml_TableRowGroup = "TableRowGroup";

		public const string Xaml_TableRow = "TableRow";

		public const string Xaml_TableCell = "TableCell";

		public const string Xaml_TableCell_BorderThickness = "BorderThickness";

		public const string Xaml_TableCell_BorderBrush = "BorderBrush";

		public const string Xaml_TableCell_ColumnSpan = "ColumnSpan";

		public const string Xaml_TableCell_RowSpan = "RowSpan";

		public const string Xaml_Width = "Width";

		public const string Xaml_Brushes_Black = "Black";

		public const string Xaml_FontFamily = "FontFamily";

		public const string Xaml_FontSize = "FontSize";

		public const string Xaml_FontSize_XXLarge = "22pt";

		public const string Xaml_FontSize_XLarge = "20pt";

		public const string Xaml_FontSize_Large = "18pt";

		public const string Xaml_FontSize_Medium = "16pt";

		public const string Xaml_FontSize_Small = "12pt";

		public const string Xaml_FontSize_XSmall = "10pt";

		public const string Xaml_FontSize_XXSmall = "8pt";

		public const string Xaml_FontWeight = "FontWeight";

		public const string Xaml_FontWeight_Bold = "Bold";

		public const string Xaml_FontStyle = "FontStyle";

		public const string Xaml_Foreground = "Foreground";

		public const string Xaml_Background = "Background";

		public const string Xaml_TextDecorations = "TextDecorations";

		public const string Xaml_TextDecorations_Underline = "Underline";

		public const string Xaml_TextIndent = "TextIndent";

		public const string Xaml_TextAlignment = "TextAlignment";

		private static string string_0;
	}
}
