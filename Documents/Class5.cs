using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

internal class Class5
{
	private Class5(string string_0)
	{
		
		
		this.xmlDocument_0 = new XmlDocument();
		this.stack_0 = new Stack<XmlElement>();
		this.stack_1 = new Stack<XmlElement>();
		this.class4_0 = new Class4(string_0);
		this.class4_0.method_0();
	}

	internal static XmlElement smethod_0(string string_0)
	{
		return new Class5(string_0).method_1();
	}

	internal static string smethod_1(string string_0)
	{
		int num = string_0.IndexOf("StartHTML:");
		if (num < 0)
		{
			return "ERROR: Urecognized html header";
		}
		num = int.Parse(string_0.Substring(num + "StartHTML:".Length, "0123456789".Length));
		if (num < 0 || num > string_0.Length)
		{
			return "ERROR: Urecognized html header";
		}
		int num2 = string_0.IndexOf("EndHTML:");
		if (num2 < 0)
		{
			return "ERROR: Urecognized html header";
		}
		num2 = int.Parse(string_0.Substring(num2 + "EndHTML:".Length, "0123456789".Length));
		if (num2 > string_0.Length)
		{
			num2 = string_0.Length;
		}
		return string_0.Substring(num, num2 - num);
	}

	internal static string smethod_2(string string_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		int num = "Version:1.0\r\nStartHTML:{0:D10}\r\nEndHTML:{1:D10}\r\nStartFragment:{2:D10}\r\nEndFragment:{3:D10}\r\nStartSelection:{4:D10}\r\nEndSelection:{5:D10}\r\n".Length + 6 * ("0123456789".Length - "{0:D10}".Length);
		int num2 = num + string_0.Length;
		int num3 = string_0.IndexOf("<!--StartFragment-->", 0);
		if (num3 >= 0)
		{
			num3 = num + num3 + "<!--StartFragment-->".Length;
		}
		else
		{
			num3 = num;
		}
		int num4 = string_0.IndexOf("<!--EndFragment-->", 0);
		if (num4 >= 0)
		{
			num4 = num + num4;
		}
		else
		{
			num4 = num2;
		}
		stringBuilder.AppendFormat("Version:1.0\r\nStartHTML:{0:D10}\r\nEndHTML:{1:D10}\r\nStartFragment:{2:D10}\r\nEndFragment:{3:D10}\r\nStartSelection:{4:D10}\r\nEndSelection:{5:D10}\r\n", new object[]
		{
			num,
			num2,
			num3,
			num4,
			num3,
			num4
		});
		stringBuilder.Append(string_0);
		return stringBuilder.ToString();
	}

	private void method_0(bool bool_0, string string_0)
	{
		if (!bool_0)
		{
			throw new Exception("Assertion error: " + string_0);
		}
	}

	private XmlElement method_1()
	{
		XmlElement xmlElement = this.xmlDocument_0.CreateElement("html", "http://www.w3.org/1999/xhtml");
		this.method_5(xmlElement);
		while (this.class4_0.method_4() != (Enum0)9)
		{
			if (this.class4_0.method_4() == (Enum0)0)
			{
				this.class4_0.method_1();
				if (this.class4_0.method_4() == (Enum0)5)
				{
					string text = this.class4_0.method_5().ToLower();
					this.class4_0.method_1();
					XmlElement xmlElement_ = this.xmlDocument_0.CreateElement(text, "http://www.w3.org/1999/xhtml");
					this.method_11(xmlElement_);
					if (this.class4_0.method_4() != (Enum0)3 && !Class6.smethod_0(text))
					{
						if (Class6.smethod_2(text))
						{
							this.method_4(xmlElement_);
						}
						else if (Class6.smethod_1(text) || Class6.smethod_3(text))
						{
							this.method_5(xmlElement_);
						}
					}
					else
					{
						this.method_3(xmlElement_);
					}
				}
			}
			else if (this.class4_0.method_4() == (Enum0)1)
			{
				this.class4_0.method_1();
				if (this.class4_0.method_4() == (Enum0)5)
				{
					string string_ = this.class4_0.method_5().ToLower();
					this.class4_0.method_1();
					this.method_7(string_);
				}
			}
			else if (this.class4_0.method_4() == (Enum0)7)
			{
				this.method_8(this.class4_0.method_5());
			}
			else if (this.class4_0.method_4() == (Enum0)8)
			{
				this.method_9(this.class4_0.method_5());
			}
			this.class4_0.method_0();
		}
		if (xmlElement.FirstChild is XmlElement && xmlElement.FirstChild == xmlElement.LastChild && xmlElement.FirstChild.LocalName.ToLower() == "html")
		{
			xmlElement = (XmlElement)xmlElement.FirstChild;
		}
		return xmlElement;
	}

	private XmlElement method_2(XmlElement xmlElement_0)
	{
		XmlElement xmlElement = this.xmlDocument_0.CreateElement(xmlElement_0.LocalName, "http://www.w3.org/1999/xhtml");
		for (int i = 0; i < xmlElement_0.Attributes.Count; i++)
		{
			XmlAttribute xmlAttribute = xmlElement_0.Attributes[i];
			xmlElement.SetAttribute(xmlAttribute.Name, xmlAttribute.Value);
		}
		return xmlElement;
	}

	private void method_3(XmlElement xmlElement_0)
	{
		this.method_0(this.stack_0.Count > 0, "AddEmptyElement: Stack of opened elements cannot be empty, as we have at least one artificial root element");
		this.stack_0.Peek().AppendChild(xmlElement_0);
	}

	private void method_4(XmlElement xmlElement_0)
	{
		this.stack_1.Push(xmlElement_0);
	}

	private void method_5(XmlElement xmlElement_0)
	{
		if (Class6.smethod_1(xmlElement_0.LocalName))
		{
			while (this.stack_0.Count > 0 && Class6.smethod_2(this.stack_0.Peek().LocalName))
			{
				XmlElement xmlElement_ = this.stack_0.Pop();
				this.method_0(this.stack_0.Count > 0, "OpenStructuringElement: stack of opened elements cannot become empty here");
				this.stack_1.Push(this.method_2(xmlElement_));
			}
		}
		if (this.stack_0.Count > 0)
		{
			XmlElement xmlElement = this.stack_0.Peek();
			if (Class6.smethod_5(xmlElement.LocalName, xmlElement_0.LocalName))
			{
				this.stack_0.Pop();
				xmlElement = ((this.stack_0.Count > 0) ? this.stack_0.Peek() : null);
			}
			if (xmlElement != null)
			{
				xmlElement.AppendChild(xmlElement_0);
			}
		}
		this.stack_0.Push(xmlElement_0);
	}

	private bool method_6(string string_0)
	{
		using (Stack<XmlElement>.Enumerator enumerator = this.stack_0.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.LocalName == string_0)
				{
					return true;
				}
			}
		}
		return false;
	}

	private void method_7(string string_0)
	{
		this.method_0(this.stack_0.Count > 0, "CloseElement: Stack of opened elements cannot be empty, as we have at least one artificial root element");
		if (this.stack_1.Count > 0 && this.stack_1.Peek().LocalName == string_0)
		{
			XmlElement newChild = this.stack_1.Pop();
			this.method_0(this.stack_0.Count > 0, "CloseElement: Stack of opened elements cannot be empty, as we have at least one artificial root element");
			this.stack_0.Peek().AppendChild(newChild);
			return;
		}
		if (this.method_6(string_0))
		{
			while (this.stack_0.Count > 1)
			{
				XmlElement xmlElement = this.stack_0.Pop();
				if (xmlElement.LocalName == string_0)
				{
					return;
				}
				if (Class6.smethod_2(xmlElement.LocalName))
				{
					this.stack_1.Push(this.method_2(xmlElement));
				}
			}
		}
	}

	private void method_8(string string_0)
	{
		this.method_10();
		this.method_0(this.stack_0.Count > 0, "AddTextContent: Stack of opened elements cannot be empty, as we have at least one artificial root element");
		XmlNode xmlNode = this.stack_0.Peek();
		XmlText newChild = this.xmlDocument_0.CreateTextNode(string_0);
		xmlNode.AppendChild(newChild);
	}

	private void method_9(string string_0)
	{
		this.method_10();
		this.method_0(this.stack_0.Count > 0, "AddComment: Stack of opened elements cannot be empty, as we have at least one artificial root element");
		XmlNode xmlNode = this.stack_0.Peek();
		XmlComment newChild = this.xmlDocument_0.CreateComment(string_0);
		xmlNode.AppendChild(newChild);
	}

	private void method_10()
	{
		if (this.stack_1.Count > 0)
		{
			XmlElement xmlElement = this.stack_1.Pop();
			this.method_10();
			this.method_0(this.stack_0.Count > 0, "OpenPendingInlineElements: Stack of opened elements cannot be empty, as we have at least one artificial root element");
			this.stack_0.Peek().AppendChild(xmlElement);
			this.stack_0.Push(xmlElement);
		}
	}

	private void method_11(XmlElement xmlElement_0)
	{
		while (this.class4_0.method_4() != (Enum0)9 && this.class4_0.method_4() != (Enum0)2)
		{
			if (this.class4_0.method_4() == (Enum0)3)
			{
				break;
			}
			if (this.class4_0.method_4() == (Enum0)5)
			{
				string name = this.class4_0.method_5();
				this.class4_0.method_2();
				this.class4_0.method_3();
				string value = this.class4_0.method_5();
				xmlElement_0.SetAttribute(name, value);
			}
			this.class4_0.method_1();
		}
	}

	private Class4 class4_0;

	private XmlDocument xmlDocument_0;

	private Stack<XmlElement> stack_0;

	private Stack<XmlElement> stack_1;
}
