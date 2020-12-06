using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using MarkupConverter;

internal static class Class1
{
	internal static void smethod_0(XmlElement xmlElement_0, string string_18, Class2 class2_0, Hashtable hashtable_0, List<XmlElement> list_0)
	{
		string text = class2_0.method_2(string_18, list_0);
		string attribute = HtmlToXamlConverter.GetAttribute(xmlElement_0, "style");
		string text2 = (text != null) ? text : null;
		if (attribute != null)
		{
			text2 = ((text2 == null) ? attribute : (text2 + ";" + attribute));
		}
		if (text2 != null)
		{
			string[] array = text2.Split(new char[]
			{
				';'
			});
			for (int i = 0; i < array.Length; i++)
			{
				string[] array2 = array[i].Split(new char[]
				{
					':'
				});
				if (array2.Length == 2)
				{
					string text3 = array2[0].Trim().ToLower();
					string string_19 = HtmlToXamlConverter.smethod_0(array2[1].Trim()).ToLower();
					int num = 0;
					uint num2 = PrivateImplementationDetails.ComputeStringHash(text3);
					if (num2 > 2290173017u)
					{
						if (num2 <= 3328355879u)
						{
							if (num2 <= 2679686814u)
							{
								if (num2 <= 2508680735u)
								{
									if (num2 != 2416839281u)
									{
										if (num2 != 2425137969u)
										{
											if (num2 != 2508680735u)
											{
												goto IL_914;
											}
											if (!(text3 == "width"))
											{
												goto IL_914;
											}
										}
										else
										{
											if (!(text3 == "letter-spacing"))
											{
												goto IL_914;
											}
											goto IL_914;
										}
									}
									else
									{
										if (text3 == "margin-bottom")
										{
											goto IL_572;
										}
										goto IL_914;
									}
								}
								else if (num2 != 2560944639u)
								{
									if (num2 != 2649052369u)
									{
										if (num2 != 2679686814u)
										{
											goto IL_914;
										}
										if (!(text3 == "border-left-width"))
										{
											goto IL_914;
										}
										goto IL_914;
									}
									else
									{
										if (!(text3 == "border-color"))
										{
											goto IL_914;
										}
										goto IL_850;
									}
								}
								else
								{
									if (!(text3 == "border-bottom-color"))
									{
										goto IL_914;
									}
									goto IL_914;
								}
							}
							else if (num2 <= 2876783500u)
							{
								if (num2 != 2789833231u)
								{
									if (num2 != 2797886853u)
									{
										if (num2 != 2876783500u)
										{
											goto IL_914;
										}
										if (!(text3 == "padding-left"))
										{
											goto IL_914;
										}
										goto IL_8B3;
									}
									else
									{
										if (text3 == "float")
										{
											Class1.smethod_20(string_19, ref num, hashtable_0);
											goto IL_914;
										}
										goto IL_914;
									}
								}
								else
								{
									if (text3 == "text-transform")
									{
										Class1.AjxontioHl(string_19, ref num, hashtable_0);
										goto IL_914;
									}
									goto IL_914;
								}
							}
							else if (num2 <= 3247228931u)
							{
								if (num2 != 2930062261u)
								{
									if (num2 != 3247228931u)
									{
										goto IL_914;
									}
									if (text3 == "font-weight")
									{
										Class1.smethod_12(string_19, ref num, hashtable_0);
										goto IL_914;
									}
									goto IL_914;
								}
								else
								{
									if (!(text3 == "border-left-color"))
									{
										goto IL_914;
									}
									goto IL_914;
								}
							}
							else if (num2 != 3309482346u)
							{
								if (num2 != 3328355879u)
								{
									goto IL_914;
								}
								if (text3 == "background-color")
								{
									Class1.smethod_8(string_19, ref num, hashtable_0, "background-color");
									goto IL_914;
								}
								goto IL_914;
							}
							else
							{
								if (!(text3 == "border-width"))
								{
									goto IL_914;
								}
								goto IL_850;
							}
						}
						else if (num2 <= 3659658663u)
						{
							if (num2 <= 3504398499u)
							{
								if (num2 != 3391345689u)
								{
									if (num2 != 3473090444u)
									{
										if (num2 != 3504398499u)
										{
											goto IL_914;
										}
										if (!(text3 == "border-top-color"))
										{
											goto IL_914;
										}
										goto IL_914;
									}
									else
									{
										if (!(text3 == "border-right-style"))
										{
											goto IL_914;
										}
										goto IL_914;
									}
								}
								else
								{
									if (!(text3 == "padding-right"))
									{
										goto IL_914;
									}
									goto IL_8B3;
								}
							}
							else if (num2 != 3585981250u)
							{
								if (num2 != 3614522491u)
								{
									if (num2 != 3659658663u)
									{
										goto IL_914;
									}
									if (!(text3 == "border-left-style"))
									{
										goto IL_914;
									}
									goto IL_914;
								}
								else
								{
									if (text3 == "margin")
									{
										Class1.smethod_22(string_19, ref num, hashtable_0, text3);
										goto IL_914;
									}
									goto IL_914;
								}
							}
							else if (!(text3 == "height"))
							{
								goto IL_914;
							}
						}
						else if (num2 <= 3860607080u)
						{
							if (num2 != 3769371381u)
							{
								if (num2 != 3857624035u)
								{
									if (num2 != 3860607080u)
									{
										goto IL_914;
									}
									if (!(text3 == "border-top-width"))
									{
										goto IL_914;
									}
									goto IL_914;
								}
								else
								{
									if (text3 == "border-style")
									{
										goto IL_850;
									}
									goto IL_914;
								}
							}
							else
							{
								if (text3 == "line-height")
								{
									Class1.smethod_6(string_19, ref num, hashtable_0, "line-height", true);
									goto IL_914;
								}
								goto IL_914;
							}
						}
						else if (num2 <= 3975754638u)
						{
							if (num2 != 3928017457u)
							{
								if (num2 != 3975754638u)
								{
									goto IL_914;
								}
								if (text3 == "padding-bottom")
								{
									goto IL_8B3;
								}
								goto IL_914;
							}
							else
							{
								if (!(text3 == "border-top-style"))
								{
									goto IL_914;
								}
								goto IL_914;
							}
						}
						else if (num2 != 4001223300u)
						{
							if (num2 != 4284404126u)
							{
								goto IL_914;
							}
							if (text3 == "font-size")
							{
								Class1.smethod_6(string_19, ref num, hashtable_0, "font-size", true);
								goto IL_914;
							}
							goto IL_914;
						}
						else
						{
							if (text3 == "border-right")
							{
								goto IL_914;
							}
							goto IL_914;
						}
						Class1.smethod_6(string_19, ref num, hashtable_0, text3, true);
						goto IL_914;
						IL_850:
						Class1.smethod_22(string_19, ref num, hashtable_0, text3);
						goto IL_914;
					}
					if (num2 <= 1031692888u)
					{
						if (num2 <= 659427984u)
						{
							if (num2 <= 252494808u)
							{
								if (num2 != 127652482u)
								{
									if (num2 != 219030440u)
									{
										if (num2 != 252494808u)
										{
											goto IL_914;
										}
										if (text3 == "font-style")
										{
											Class1.smethod_10(string_19, ref num, hashtable_0);
											goto IL_914;
										}
										goto IL_914;
									}
									else
									{
										if (text3 == "font-variant")
										{
											Class1.smethod_11(string_19, ref num, hashtable_0);
											goto IL_914;
										}
										goto IL_914;
									}
								}
								else
								{
									if (text3 == "text-align")
									{
										Class1.smethod_18(string_19, ref num, hashtable_0);
										goto IL_914;
									}
									goto IL_914;
								}
							}
							else if (num2 != 525480503u)
							{
								if (num2 != 549768767u)
								{
									if (num2 != 659427984u)
									{
										goto IL_914;
									}
									if (text3 == "font")
									{
										Class1.smethod_9(string_19, hashtable_0);
										goto IL_914;
									}
									goto IL_914;
								}
								else
								{
									if (text3 == "font-family")
									{
										Class1.smethod_13(string_19, ref num, hashtable_0);
										goto IL_914;
									}
									goto IL_914;
								}
							}
							else
							{
								if (text3 == "border")
								{
									Class1.smethod_23(string_19, ref num, hashtable_0);
									goto IL_914;
								}
								goto IL_914;
							}
						}
						else if (num2 <= 805531780u)
						{
							if (num2 != 742030163u)
							{
								if (num2 != 787794385u)
								{
									if (num2 != 805531780u)
									{
										goto IL_914;
									}
									if (!(text3 == "border-bottom-width"))
									{
										goto IL_914;
									}
									goto IL_914;
								}
								else
								{
									if (!(text3 == "word-spacing"))
									{
										goto IL_914;
									}
									goto IL_914;
								}
							}
							else
							{
								if (text3 == "vertical-align")
								{
									Class1.smethod_19(string_19, ref num, hashtable_0);
									goto IL_914;
								}
								goto IL_914;
							}
						}
						else if (num2 <= 883380135u)
						{
							if (num2 != 823368261u)
							{
								if (num2 != 883380135u)
								{
									goto IL_914;
								}
								if (text3 == "text-indent")
								{
									Class1.smethod_6(string_19, ref num, hashtable_0, "text-indent", false);
									goto IL_914;
								}
								goto IL_914;
							}
							else if (!(text3 == "margin-top"))
							{
								goto IL_914;
							}
						}
						else if (num2 != 946671509u)
						{
							if (num2 != 1031692888u)
							{
								goto IL_914;
							}
							if (text3 == "color")
							{
								Class1.smethod_8(string_19, ref num, hashtable_0, "color");
								goto IL_914;
							}
							goto IL_914;
						}
						else
						{
							if (!(text3 == "border-bottom"))
							{
								goto IL_914;
							}
							goto IL_914;
						}
					}
					else if (num2 <= 1326443451u)
					{
						if (num2 <= 1177978080u)
						{
							if (num2 != 1103135245u)
							{
								if (num2 != 1164572437u)
								{
									if (num2 != 1177978080u)
									{
										goto IL_914;
									}
									if (!(text3 == "margin-right"))
									{
										goto IL_914;
									}
								}
								else
								{
									if (!(text3 == "display"))
									{
										goto IL_914;
									}
									goto IL_914;
								}
							}
							else
							{
								if (!(text3 == "border-right-width"))
								{
									goto IL_914;
								}
								goto IL_914;
							}
						}
						else if (num2 != 1269553309u)
						{
							if (num2 != 1306599407u)
							{
								if (num2 != 1326443451u)
								{
									goto IL_914;
								}
								if (!(text3 == "border-left"))
								{
									goto IL_914;
								}
								goto IL_914;
							}
							else if (!(text3 == "margin-left"))
							{
								goto IL_914;
							}
						}
						else
						{
							if (text3 == "background")
							{
								Class1.smethod_24(string_19, ref num, hashtable_0);
								goto IL_914;
							}
							goto IL_914;
						}
					}
					else if (num2 <= 1550717474u)
					{
						if (num2 != 1422898045u)
						{
							if (num2 != 1466694928u)
							{
								if (num2 != 1550717474u)
								{
									goto IL_914;
								}
								if (text3 == "clear")
								{
									Class1.smethod_21(string_19, ref num, hashtable_0);
									goto IL_914;
								}
								goto IL_914;
							}
							else
							{
								if (!(text3 == "padding-top"))
								{
									goto IL_914;
								}
								goto IL_8B3;
							}
						}
						else
						{
							if (!(text3 == "border-bottom-style"))
							{
								goto IL_914;
							}
							goto IL_914;
						}
					}
					else if (num2 <= 2041122471u)
					{
						if (num2 != 2039958762u)
						{
							if (num2 != 2041122471u)
							{
								goto IL_914;
							}
							if (text3 == "text-decoration")
							{
								Class1.smethod_17(string_19, ref num, hashtable_0);
								goto IL_914;
							}
							goto IL_914;
						}
						else
						{
							if (!(text3 == "border-right-color"))
							{
								goto IL_914;
							}
							goto IL_914;
						}
					}
					else if (num2 != 2157316278u)
					{
						if (num2 != 2290173017u)
						{
							goto IL_914;
						}
						if (!(text3 == "border-top"))
						{
							goto IL_914;
						}
						goto IL_914;
					}
					else
					{
						if (text3 == "padding")
						{
							Class1.smethod_22(string_19, ref num, hashtable_0, text3);
							goto IL_914;
						}
						goto IL_914;
					}
					IL_572:
					Class1.smethod_6(string_19, ref num, hashtable_0, text3, true);
					goto IL_914;
					IL_8B3:
					Class1.smethod_6(string_19, ref num, hashtable_0, text3, true);
				}
				IL_914:;
			}
		}
	}

	private static void smethod_1(string string_18, ref int int_0)
	{
		while (int_0 < string_18.Length && char.IsWhiteSpace(string_18[int_0]))
		{
			int_0++;
		}
	}

	private static bool smethod_2(string string_18, string string_19, ref int int_0)
	{
		Class1.smethod_1(string_19, ref int_0);
		int i = 0;
		while (i < string_18.Length)
		{
			if (int_0 + i < string_19.Length)
			{
				if (string_18[i] == string_19[int_0 + i])
				{
					i++;
					continue;
				}
			}
			return false;
		}
		if (int_0 + string_18.Length < string_19.Length && char.IsLetterOrDigit(string_19[int_0 + string_18.Length]))
		{
			return false;
		}
		int_0 += string_18.Length;
		return true;
	}

	private static string smethod_3(string[] string_18, string string_19, ref int int_0)
	{
		for (int i = 0; i < string_18.Length; i++)
		{
			if (Class1.smethod_2(string_18[i], string_19, ref int_0))
			{
				return string_18[i];
			}
		}
		return null;
	}

	private static void smethod_4(string[] string_18, string string_19, ref int int_0, Hashtable hashtable_0, string string_20)
	{
		string text = Class1.smethod_3(string_18, string_19, ref int_0);
		if (text != null)
		{
			hashtable_0[string_20] = text;
		}
	}

	private static string smethod_5(string string_18, ref int int_0, bool bool_0)
	{
		Class1.smethod_1(string_18, ref int_0);
		int num = int_0;
		if (int_0 < string_18.Length && string_18[int_0] == '-')
		{
			int_0++;
		}
		if (int_0 >= string_18.Length || !char.IsDigit(string_18[int_0]))
		{
			return null;
		}
		while (int_0 < string_18.Length)
		{
			if (!char.IsDigit(string_18[int_0]) && string_18[int_0] != '.')
			{
				break;
			}
			int_0++;
		}
		string str = string_18.Substring(num, int_0 - num);
		string text = Class1.smethod_3(Class1.string_8, string_18, ref int_0);
		if (text == null)
		{
			text = "px";
		}
		if (bool_0 && string_18[num] == '-')
		{
			return "0";
		}
		return str + text;
	}

	private static void smethod_6(string string_18, ref int int_0, Hashtable hashtable_0, string string_19, bool bool_0)
	{
		string text = Class1.smethod_5(string_18, ref int_0, bool_0);
		if (text != null)
		{
			hashtable_0[string_19] = text;
		}
	}

	private static string smethod_7(string string_18, ref int int_0)
	{
		Class1.smethod_1(string_18, ref int_0);
		string text = null;
		if (int_0 < string_18.Length)
		{
			int num = int_0;
			char c = string_18[int_0];
			if (c == '#')
			{
				for (int_0++; int_0 < string_18.Length; int_0++)
				{
					c = char.ToUpper(string_18[int_0]);
					if (('0' > c || c > '9') && ('A' > c || c > 'F'))
					{
						break;
					}
				}
				if (int_0 > num + 1)
				{
					text = string_18.Substring(num, int_0 - num);
				}
			}
			else if (string_18.Substring(int_0, 3).ToLower() == "rbg")
			{
				while (int_0 < string_18.Length)
				{
					if (string_18[int_0] == ')')
					{
						break;
					}
					int_0++;
				}
				if (int_0 < string_18.Length)
				{
					int_0++;
				}
				text = "gray";
			}
			else if (char.IsLetter(c))
			{
				text = Class1.smethod_3(Class1.string_0, string_18, ref int_0);
				if (text == null)
				{
					text = Class1.smethod_3(Class1.string_1, string_18, ref int_0);
					if (text != null)
					{
						text = "black";
					}
				}
			}
		}
		return text;
	}

	private static void smethod_8(string string_18, ref int int_0, Hashtable hashtable_0, string string_19)
	{
		string text = Class1.smethod_7(string_18, ref int_0);
		if (text != null)
		{
			hashtable_0[string_19] = text;
		}
	}

	private static void smethod_9(string string_18, Hashtable hashtable_0)
	{
		int num = 0;
		Class1.smethod_10(string_18, ref num, hashtable_0);
		Class1.smethod_11(string_18, ref num, hashtable_0);
		Class1.smethod_12(string_18, ref num, hashtable_0);
		Class1.smethod_6(string_18, ref num, hashtable_0, "font-size", true);
		Class1.smethod_1(string_18, ref num);
		if (num < string_18.Length && string_18[num] == '/')
		{
			num++;
			Class1.smethod_6(string_18, ref num, hashtable_0, "line-height", true);
		}
		Class1.smethod_13(string_18, ref num, hashtable_0);
	}

	private static void smethod_10(string string_18, ref int int_0, Hashtable hashtable_0)
	{
		Class1.smethod_4(Class1.string_3, string_18, ref int_0, hashtable_0, "font-style");
	}

	private static void smethod_11(string string_18, ref int int_0, Hashtable hashtable_0)
	{
		Class1.smethod_4(Class1.string_4, string_18, ref int_0, hashtable_0, "font-variant");
	}

	private static void smethod_12(string string_18, ref int int_0, Hashtable hashtable_0)
	{
		Class1.smethod_4(Class1.string_5, string_18, ref int_0, hashtable_0, "font-weight");
	}

	private static void smethod_13(string string_18, ref int int_0, Hashtable hashtable_0)
	{
		string text = null;
		while (int_0 < string_18.Length)
		{
			string text2 = Class1.smethod_3(Class1.string_2, string_18, ref int_0);
			if (text2 == null)
			{
				if (int_0 < string_18.Length && (string_18[int_0] == '"' || string_18[int_0] == '\''))
				{
					char c = string_18[int_0];
					int_0++;
					int num = int_0;
					while (int_0 < string_18.Length)
					{
						if (string_18[int_0] == c)
						{
							break;
						}
						int_0++;
					}
					text2 = "\"" + string_18.Substring(num, int_0 - num) + "\"";
				}
				if (text2 == null)
				{
					int num2 = int_0;
					while (int_0 < string_18.Length && string_18[int_0] != ',')
					{
						if (string_18[int_0] == ';')
						{
							break;
						}
						int_0++;
					}
					if (int_0 > num2)
					{
						text2 = string_18.Substring(num2, int_0 - num2).Trim();
						if (text2.Length == 0)
						{
							text2 = null;
						}
					}
				}
			}
			Class1.smethod_1(string_18, ref int_0);
			if (int_0 < string_18.Length && string_18[int_0] == ',')
			{
				int_0++;
			}
			if (text2 == null)
			{
				break;
			}
			if (text == null && text2.Length > 0)
			{
				if (text2[0] == '"' || text2[0] == '\'')
				{
					text2 = text2.Substring(1, text2.Length - 2);
				}
				text = text2;
			}
		}
		if (text != null)
		{
			hashtable_0["font-family"] = text;
		}
	}

	private static void smethod_14(string string_18, Hashtable hashtable_0)
	{
		int i = 0;
		while (i < string_18.Length)
		{
			string text = Class1.smethod_15(string_18, ref i);
			if (text != null)
			{
				hashtable_0["list-style-type"] = text;
			}
			else
			{
				string text2 = Class1.smethod_16(string_18, ref i);
				if (text2 == null)
				{
					break;
				}
				hashtable_0["list-style-position"] = text2;
			}
		}
	}

	private static string smethod_15(string string_18, ref int int_0)
	{
		return Class1.smethod_3(Class1.string_9, string_18, ref int_0);
	}

	private static string smethod_16(string string_18, ref int int_0)
	{
		return Class1.smethod_3(Class1.string_10, string_18, ref int_0);
	}

	private static void smethod_17(string string_18, ref int int_0, Hashtable hashtable_0)
	{
		for (int i = 1; i < Class1.string_11.Length; i++)
		{
			hashtable_0["text-decoration-" + Class1.string_11[i]] = "false";
		}
		while (int_0 < string_18.Length)
		{
			string text = Class1.smethod_3(Class1.string_11, string_18, ref int_0);
			if (text == null || text == "none")
			{
				break;
			}
			hashtable_0["text-decoration-" + text] = "true";
		}
	}

	private static void AjxontioHl(string string_18, ref int int_0, Hashtable hashtable_0)
	{
		Class1.smethod_4(Class1.string_12, string_18, ref int_0, hashtable_0, "text-transform");
	}

	private static void smethod_18(string string_18, ref int int_0, Hashtable hashtable_0)
	{
		Class1.smethod_4(Class1.string_13, string_18, ref int_0, hashtable_0, "text-align");
	}

	private static void smethod_19(string string_18, ref int int_0, Hashtable hashtable_0)
	{
		Class1.smethod_4(Class1.string_14, string_18, ref int_0, hashtable_0, "vertical-align");
	}

	private static void smethod_20(string string_18, ref int int_0, Hashtable hashtable_0)
	{
		Class1.smethod_4(Class1.string_15, string_18, ref int_0, hashtable_0, "float");
	}

	private static void smethod_21(string string_18, ref int int_0, Hashtable hashtable_0)
	{
		Class1.smethod_4(Class1.string_16, string_18, ref int_0, hashtable_0, "clear");
	}

	private static bool smethod_22(string string_18, ref int int_0, Hashtable hashtable_0, string string_19)
	{
		string text = (string_19 == "border-color") ? Class1.smethod_7(string_18, ref int_0) : ((string_19 == "border-style") ? Class1.zoUosuoKw8(string_18, ref int_0) : Class1.smethod_5(string_18, ref int_0, true));
		if (text != null)
		{
			hashtable_0[string_19 + "-top"] = text;
			hashtable_0[string_19 + "-bottom"] = text;
			hashtable_0[string_19 + "-right"] = text;
			hashtable_0[string_19 + "-left"] = text;
			text = ((string_19 == "border-color") ? Class1.smethod_7(string_18, ref int_0) : ((string_19 == "border-style") ? Class1.zoUosuoKw8(string_18, ref int_0) : Class1.smethod_5(string_18, ref int_0, true)));
			if (text != null)
			{
				hashtable_0[string_19 + "-right"] = text;
				hashtable_0[string_19 + "-left"] = text;
				text = ((string_19 == "border-color") ? Class1.smethod_7(string_18, ref int_0) : ((string_19 == "border-style") ? Class1.zoUosuoKw8(string_18, ref int_0) : Class1.smethod_5(string_18, ref int_0, true)));
				if (text != null)
				{
					hashtable_0[string_19 + "-bottom"] = text;
					text = ((string_19 == "border-color") ? Class1.smethod_7(string_18, ref int_0) : ((string_19 == "border-style") ? Class1.zoUosuoKw8(string_18, ref int_0) : Class1.smethod_5(string_18, ref int_0, true)));
					if (text != null)
					{
						hashtable_0[string_19 + "-left"] = text;
					}
				}
			}
			return true;
		}
		return false;
	}

	private static void smethod_23(string string_18, ref int int_0, Hashtable hashtable_0)
	{
		while (Class1.smethod_22(string_18, ref int_0, hashtable_0, "border-width") || Class1.smethod_22(string_18, ref int_0, hashtable_0, "border-style") || Class1.smethod_22(string_18, ref int_0, hashtable_0, "border-color"))
		{
		}
	}

	private static string zoUosuoKw8(string string_18, ref int int_0)
	{
		return Class1.smethod_3(Class1.aiXoFprffY, string_18, ref int_0);
	}

	private static void smethod_24(string string_18, ref int int_0, Hashtable hashtable_0)
	{
	}

	static Class1()
	{
		// Note: this type is marked as 'beforefieldinit'.
		
		Class1.string_0 = new string[]
		{
			"aliceblue",
			"antiquewhite",
			"aqua",
			"aquamarine",
			"azure",
			"beige",
			"bisque",
			"black",
			"blanchedalmond",
			"blue",
			"blueviolet",
			"brown",
			"burlywood",
			"cadetblue",
			"chartreuse",
			"chocolate",
			"coral",
			"cornflowerblue",
			"cornsilk",
			"crimson",
			"cyan",
			"darkblue",
			"darkcyan",
			"darkgoldenrod",
			"darkgray",
			"darkgreen",
			"darkkhaki",
			"darkmagenta",
			"darkolivegreen",
			"darkorange",
			"darkorchid",
			"darkred",
			"darksalmon",
			"darkseagreen",
			"darkslateblue",
			"darkslategray",
			"darkturquoise",
			"darkviolet",
			"deeppink",
			"deepskyblue",
			"dimgray",
			"dodgerblue",
			"firebrick",
			"floralwhite",
			"forestgreen",
			"fuchsia",
			"gainsboro",
			"ghostwhite",
			"gold",
			"goldenrod",
			"gray",
			"green",
			"greenyellow",
			"honeydew",
			"hotpink",
			"indianred",
			"indigo",
			"ivory",
			"khaki",
			"lavender",
			"lavenderblush",
			"lawngreen",
			"lemonchiffon",
			"lightblue",
			"lightcoral",
			"lightcyan",
			"lightgoldenrodyellow",
			"lightgreen",
			"lightgrey",
			"lightpink",
			"lightsalmon",
			"lightseagreen",
			"lightskyblue",
			"lightslategray",
			"lightsteelblue",
			"lightyellow",
			"lime",
			"limegreen",
			"linen",
			"magenta",
			"maroon",
			"mediumaquamarine",
			"mediumblue",
			"mediumorchid",
			"mediumpurple",
			"mediumseagreen",
			"mediumslateblue",
			"mediumspringgreen",
			"mediumturquoise",
			"mediumvioletred",
			"midnightblue",
			"mintcream",
			"mistyrose",
			"moccasin",
			"navajowhite",
			"navy",
			"oldlace",
			"olive",
			"olivedrab",
			"orange",
			"orangered",
			"orchid",
			"palegoldenrod",
			"palegreen",
			"paleturquoise",
			"palevioletred",
			"papayawhip",
			"peachpuff",
			"peru",
			"pink",
			"plum",
			"powderblue",
			"purple",
			"red",
			"rosybrown",
			"royalblue",
			"saddlebrown",
			"salmon",
			"sandybrown",
			"seagreen",
			"seashell",
			"sienna",
			"silver",
			"skyblue",
			"slateblue",
			"slategray",
			"snow",
			"springgreen",
			"steelblue",
			"tan",
			"teal",
			"thistle",
			"tomato",
			"turquoise",
			"violet",
			"wheat",
			"white",
			"whitesmoke",
			"yellow",
			"yellowgreen"
		};
		Class1.string_1 = new string[]
		{
			"activeborder",
			"activecaption",
			"appworkspace",
			"background",
			"buttonface",
			"buttonhighlight",
			"buttonshadow",
			"buttontext",
			"captiontext",
			"graytext",
			"highlight",
			"highlighttext",
			"inactiveborder",
			"inactivecaption",
			"inactivecaptiontext",
			"infobackground",
			"infotext",
			"menu",
			"menutext",
			"scrollbar",
			"threeddarkshadow",
			"threedface",
			"threedhighlight",
			"threedlightshadow",
			"threedshadow",
			"window",
			"windowframe",
			"windowtext"
		};
		Class1.string_2 = new string[]
		{
			"serif",
			"sans-serif",
			"monospace",
			"cursive",
			"fantasy"
		};
		Class1.string_3 = new string[]
		{
			"normal",
			"italic",
			"oblique"
		};
		Class1.string_4 = new string[]
		{
			"normal",
			"small-caps"
		};
		Class1.string_5 = new string[]
		{
			"normal",
			"bold",
			"bolder",
			"lighter",
			"100",
			"200",
			"300",
			"400",
			"500",
			"600",
			"700",
			"800",
			"900"
		};
		Class1.string_6 = new string[]
		{
			"xx-small",
			"x-small",
			"small",
			"medium",
			"large",
			"x-large",
			"xx-large"
		};
		Class1.string_7 = new string[]
		{
			"larger",
			"smaller"
		};
		Class1.string_8 = new string[]
		{
			"px",
			"mm",
			"cm",
			"in",
			"pt",
			"pc",
			"em",
			"ex",
			"%"
		};
		Class1.string_9 = new string[]
		{
			"disc",
			"circle",
			"square",
			"decimal",
			"lower-roman",
			"upper-roman",
			"lower-alpha",
			"upper-alpha",
			"none"
		};
		Class1.string_10 = new string[]
		{
			"inside",
			"outside"
		};
		Class1.string_11 = new string[]
		{
			"none",
			"underline",
			"overline",
			"line-through",
			"blink"
		};
		Class1.string_12 = new string[]
		{
			"none",
			"capitalize",
			"uppercase",
			"lowercase"
		};
		Class1.string_13 = new string[]
		{
			"left",
			"right",
			"center",
			"justify"
		};
		Class1.string_14 = new string[]
		{
			"baseline",
			"sub",
			"super",
			"top",
			"text-top",
			"middle",
			"bottom",
			"text-bottom"
		};
		Class1.string_15 = new string[]
		{
			"left",
			"right",
			"none"
		};
		Class1.string_16 = new string[]
		{
			"none",
			"left",
			"right",
			"both"
		};
		Class1.aiXoFprffY = new string[]
		{
			"none",
			"dotted",
			"dashed",
			"solid",
			"double",
			"groove",
			"ridge",
			"inset",
			"outset"
		};
		Class1.string_17 = new string[]
		{
			"block",
			"inline",
			"list-item",
			"none"
		};
	}

	private static readonly string[] string_0;

	private static readonly string[] string_1;

	private static readonly string[] string_2;

	private static readonly string[] string_3;

	private static readonly string[] string_4;

	private static readonly string[] string_5;

	private static readonly string[] string_6;

	private static readonly string[] string_7;

	private static readonly string[] string_8;

	private static readonly string[] string_9;

	private static readonly string[] string_10;

	private static readonly string[] string_11;

	private static readonly string[] string_12;

	private static readonly string[] string_13;

	private static readonly string[] string_14;

	private static readonly string[] string_15;

	private static readonly string[] string_16;

	private static readonly string[] aiXoFprffY;

	private static string[] string_17;
}
