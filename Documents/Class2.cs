using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using MarkupConverter;

internal class Class2
{
	public Class2(XmlElement xmlElement_0)
	{
		
		
		if (xmlElement_0 != null)
		{
			this.method_0(xmlElement_0);
		}
	}

	public void method_0(XmlElement xmlElement_0)
	{
		if (xmlElement_0.LocalName.ToLower() == "link")
		{
			return;
		}
		if (xmlElement_0.LocalName.ToLower() != "style")
		{
			for (XmlNode xmlNode = xmlElement_0.FirstChild; xmlNode != null; xmlNode = xmlNode.NextSibling)
			{
				if (xmlNode is XmlElement)
				{
					this.method_0((XmlElement)xmlNode);
				}
			}
			return;
		}
		StringBuilder stringBuilder = new StringBuilder();
		for (XmlNode xmlNode2 = xmlElement_0.FirstChild; xmlNode2 != null; xmlNode2 = xmlNode2.NextSibling)
		{
			if (xmlNode2 is XmlText || xmlNode2 is XmlComment)
			{
				stringBuilder.Append(this.XrlobotWk2(xmlNode2.Value));
			}
		}
		int i = 0;
		while (i < stringBuilder.Length)
		{
			int num = i;
			while (i < stringBuilder.Length)
			{
				if (stringBuilder[i] == '{')
				{
					break;
				}
				if (stringBuilder[i] == '@')
				{
					while (i < stringBuilder.Length)
					{
						if (stringBuilder[i] == ';')
						{
							break;
						}
						i++;
					}
					num = i + 1;
				}
				i++;
			}
			if (i < stringBuilder.Length)
			{
				int num2 = i;
				while (i < stringBuilder.Length)
				{
					if (stringBuilder[i] == '}')
					{
						break;
					}
					i++;
				}
				if (i - num2 > 2)
				{
					this.method_1(stringBuilder.ToString(num, num2 - num), stringBuilder.ToString(num2 + 1, i - num2 - 2));
				}
				if (i < stringBuilder.Length)
				{
					i++;
				}
			}
		}
	}

	private string XrlobotWk2(string string_0)
	{
		int num = string_0.IndexOf("/*");
		if (num < 0)
		{
			return string_0;
		}
		int num2 = string_0.IndexOf("*/", num + 2);
		if (num2 < 0)
		{
			return string_0.Substring(0, num);
		}
		return string_0.Substring(0, num) + " " + this.XrlobotWk2(string_0.Substring(num2 + 2));
	}

	public void method_1(string string_0, string string_1)
	{
		string_0 = string_0.Trim().ToLower();
		string_1 = string_1.Trim().ToLower();
		if (string_0.Length != 0 && string_1.Length != 0)
		{
			if (this.list_0 == null)
			{
				this.list_0 = new List<Class2.Class3>();
			}
			string[] array = string_0.Split(new char[]
			{
				','
			});
			for (int i = 0; i < array.Length; i++)
			{
				string text = array[i].Trim();
				if (text.Length > 0)
				{
					this.list_0.Add(new Class2.Class3(text, string_1));
				}
			}
			return;
		}
	}

	public string method_2(string string_0, List<XmlElement> list_1)
	{
		if (this.list_0 != null)
		{
			for (int i = this.list_0.Count - 1; i >= 0; i--)
			{
				string[] array = this.list_0[i].einCcOcrwTt.Split(new char[]
				{
					' '
				});
				int num = array.Length - 1;
				int count = list_1.Count;
				string string_ = array[num].Trim();
				if (this.method_3(string_, list_1[list_1.Count - 1]))
				{
					return this.list_0[i].string_0;
				}
			}
		}
		return null;
	}

	private bool method_3(string string_0, XmlElement xmlElement_0)
	{
		if (string_0.Length == 0)
		{
			return false;
		}
		int num = string_0.IndexOf('.');
		int num2 = string_0.IndexOf('#');
		string text = null;
		string text2 = null;
		string text3 = null;
		if (num >= 0)
		{
			if (num > 0)
			{
				text3 = string_0.Substring(0, num);
			}
			text = string_0.Substring(num + 1);
		}
		else if (num2 >= 0)
		{
			if (num2 > 0)
			{
				text3 = string_0.Substring(0, num2);
			}
			text2 = string_0.Substring(num2 + 1);
		}
		else
		{
			text3 = string_0;
		}
		return (text3 == null || !(text3 != xmlElement_0.LocalName)) && (text2 == null || !(HtmlToXamlConverter.GetAttribute(xmlElement_0, "id") != text2)) && (text == null || !(HtmlToXamlConverter.GetAttribute(xmlElement_0, "class") != text));
	}

	private List<Class2.Class3> list_0;

	private class Class3
	{
		public Class3(string string_1, string string_2)
		{
			
			
			this.einCcOcrwTt = string_1;
			this.string_0 = string_2;
		}

		public string einCcOcrwTt;

		public string string_0;
	}
}
