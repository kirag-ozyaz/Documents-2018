using System;
using System.Collections;

internal class Class6
{
	static Class6()
	{
		
		Class6.smethod_8();
		Class6.smethod_9();
		Class6.smethod_11();
		Class6.smethod_10();
		Class6.smethod_12();
		Class6.smethod_13();
		Class6.smethod_14();
	}

	internal static bool smethod_0(string string_0)
	{
		return Class6.arrayList_3.Contains(string_0.ToLower());
	}

	internal static bool smethod_1(string string_0)
	{
		return Class6.arrayList_1.Contains(string_0);
	}

	internal static bool smethod_2(string string_0)
	{
		return Class6.arrayList_0.Contains(string_0);
	}

	internal static bool smethod_3(string string_0)
	{
		return Class6.arrayList_2.Contains(string_0);
	}

	internal static bool smethod_4(string string_0)
	{
		return Class6.arrayList_4.Contains(string_0.ToLower());
	}

	internal static bool smethod_5(string string_0, string string_1)
	{
		uint num = PrivateImplementationDetails.ComputeStringHash(string_0);
		if (num <= 1195724803u)
		{
			if (num <= 1027948613u)
			{
				if (num != 150307336u)
				{
					if (num == 1027948613u)
					{
						if (string_0 == "td")
						{
							return Class6.arrayList_10.Contains(string_1);
						}
					}
				}
				else if (string_0 == "colgroup")
				{
					return Class6.arrayList_5.Contains(string_1) && Class6.smethod_1(string_1);
				}
			}
			else if (num != 1077001542u)
			{
				if (num != 1095059089u)
				{
					if (num == 1195724803u)
					{
						if (string_0 == "tr")
						{
							return Class6.arrayList_14.Contains(string_1);
						}
					}
				}
				else if (string_0 == "th")
				{
					return Class6.arrayList_13.Contains(string_1);
				}
			}
			else if (string_0 == "li")
			{
				return Class6.arrayList_8.Contains(string_1);
			}
		}
		else if (num <= 2340213611u)
		{
			if (num != 1293727493u)
			{
				if (num != 1562169397u)
				{
					if (num == 2340213611u)
					{
						if (string_0 == "tbody")
						{
							return Class6.arrayList_9.Contains(string_1);
						}
					}
				}
				else if (string_0 == "dd")
				{
					return Class6.arrayList_6.Contains(string_1) && Class6.smethod_1(string_1);
				}
			}
			else if (string_0 == "dt")
			{
				return Class6.arrayList_7.Contains(string_1) && Class6.smethod_1(string_1);
			}
		}
		else if (num != 2853211801u)
		{
			if (num != 3216274459u)
			{
				if (num == 4111221743u)
				{
					if (string_0 == "p")
					{
						return Class6.smethod_1(string_1);
					}
				}
			}
			else if (string_0 == "tfoot")
			{
				return Class6.arrayList_11.Contains(string_1);
			}
		}
		else if (string_0 == "thead")
		{
			return Class6.arrayList_12.Contains(string_1);
		}
		return false;
	}

	internal static bool smethod_6(string string_0)
	{
		return Class6.hashtable_0.Contains(string_0);
	}

	internal static char smethod_7(string string_0)
	{
		if (Class6.hashtable_0.Contains(string_0))
		{
			return (char)Class6.hashtable_0[string_0];
		}
		return '\0';
	}

	private static void smethod_8()
	{
		Class6.arrayList_0 = new ArrayList();
		Class6.arrayList_0.Add("a");
		Class6.arrayList_0.Add("abbr");
		Class6.arrayList_0.Add("acronym");
		Class6.arrayList_0.Add("address");
		Class6.arrayList_0.Add("b");
		Class6.arrayList_0.Add("bdo");
		Class6.arrayList_0.Add("big");
		Class6.arrayList_0.Add("button");
		Class6.arrayList_0.Add("code");
		Class6.arrayList_0.Add("del");
		Class6.arrayList_0.Add("dfn");
		Class6.arrayList_0.Add("em");
		Class6.arrayList_0.Add("font");
		Class6.arrayList_0.Add("i");
		Class6.arrayList_0.Add("ins");
		Class6.arrayList_0.Add("kbd");
		Class6.arrayList_0.Add("label");
		Class6.arrayList_0.Add("legend");
		Class6.arrayList_0.Add("q");
		Class6.arrayList_0.Add("s");
		Class6.arrayList_0.Add("samp");
		Class6.arrayList_0.Add("small");
		Class6.arrayList_0.Add("span");
		Class6.arrayList_0.Add("strike");
		Class6.arrayList_0.Add("strong");
		Class6.arrayList_0.Add("sub");
		Class6.arrayList_0.Add("sup");
		Class6.arrayList_0.Add("u");
		Class6.arrayList_0.Add("var");
	}

	private static void smethod_9()
	{
		Class6.arrayList_1 = new ArrayList();
		Class6.arrayList_1.Add("blockquote");
		Class6.arrayList_1.Add("body");
		Class6.arrayList_1.Add("caption");
		Class6.arrayList_1.Add("center");
		Class6.arrayList_1.Add("cite");
		Class6.arrayList_1.Add("dd");
		Class6.arrayList_1.Add("dir");
		Class6.arrayList_1.Add("div");
		Class6.arrayList_1.Add("dl");
		Class6.arrayList_1.Add("dt");
		Class6.arrayList_1.Add("form");
		Class6.arrayList_1.Add("h1");
		Class6.arrayList_1.Add("h2");
		Class6.arrayList_1.Add("h3");
		Class6.arrayList_1.Add("h4");
		Class6.arrayList_1.Add("h5");
		Class6.arrayList_1.Add("h6");
		Class6.arrayList_1.Add("html");
		Class6.arrayList_1.Add("li");
		Class6.arrayList_1.Add("menu");
		Class6.arrayList_1.Add("ol");
		Class6.arrayList_1.Add("p");
		Class6.arrayList_1.Add("pre");
		Class6.arrayList_1.Add("table");
		Class6.arrayList_1.Add("tbody");
		Class6.arrayList_1.Add("td");
		Class6.arrayList_1.Add("textarea");
		Class6.arrayList_1.Add("tfoot");
		Class6.arrayList_1.Add("th");
		Class6.arrayList_1.Add("thead");
		Class6.arrayList_1.Add("tr");
		Class6.arrayList_1.Add("tt");
		Class6.arrayList_1.Add("ul");
	}

	private static void smethod_10()
	{
		Class6.arrayList_3 = new ArrayList();
		Class6.arrayList_3.Add("area");
		Class6.arrayList_3.Add("base");
		Class6.arrayList_3.Add("basefont");
		Class6.arrayList_3.Add("br");
		Class6.arrayList_3.Add("col");
		Class6.arrayList_3.Add("frame");
		Class6.arrayList_3.Add("hr");
		Class6.arrayList_3.Add("img");
		Class6.arrayList_3.Add("input");
		Class6.arrayList_3.Add("isindex");
		Class6.arrayList_3.Add("link");
		Class6.arrayList_3.Add("meta");
		Class6.arrayList_3.Add("param");
	}

	private static void smethod_11()
	{
		Class6.arrayList_2 = new ArrayList();
		Class6.arrayList_2.Add("applet");
		Class6.arrayList_2.Add("base");
		Class6.arrayList_2.Add("basefont");
		Class6.arrayList_2.Add("colgroup");
		Class6.arrayList_2.Add("fieldset");
		Class6.arrayList_2.Add("frameset");
		Class6.arrayList_2.Add("head");
		Class6.arrayList_2.Add("iframe");
		Class6.arrayList_2.Add("map");
		Class6.arrayList_2.Add("noframes");
		Class6.arrayList_2.Add("noscript");
		Class6.arrayList_2.Add("object");
		Class6.arrayList_2.Add("optgroup");
		Class6.arrayList_2.Add("option");
		Class6.arrayList_2.Add("script");
		Class6.arrayList_2.Add("select");
		Class6.arrayList_2.Add("style");
		Class6.arrayList_2.Add("title");
	}

	private static void smethod_12()
	{
		Class6.arrayList_4 = new ArrayList();
		Class6.arrayList_4.Add("body");
		Class6.arrayList_4.Add("colgroup");
		Class6.arrayList_4.Add("dd");
		Class6.arrayList_4.Add("dt");
		Class6.arrayList_4.Add("head");
		Class6.arrayList_4.Add("html");
		Class6.arrayList_4.Add("li");
		Class6.arrayList_4.Add("p");
		Class6.arrayList_4.Add("tbody");
		Class6.arrayList_4.Add("td");
		Class6.arrayList_4.Add("tfoot");
		Class6.arrayList_4.Add("thead");
		Class6.arrayList_4.Add("th");
		Class6.arrayList_4.Add("tr");
	}

	private static void smethod_13()
	{
		Class6.arrayList_5 = new ArrayList();
		Class6.arrayList_5.Add("colgroup");
		Class6.arrayList_5.Add("tr");
		Class6.arrayList_5.Add("thead");
		Class6.arrayList_5.Add("tfoot");
		Class6.arrayList_5.Add("tbody");
		Class6.arrayList_6 = new ArrayList();
		Class6.arrayList_6.Add("dd");
		Class6.arrayList_6.Add("dt");
		Class6.arrayList_7 = new ArrayList();
		Class6.arrayList_6.Add("dd");
		Class6.arrayList_6.Add("dt");
		Class6.arrayList_8 = new ArrayList();
		Class6.arrayList_8.Add("li");
		Class6.arrayList_9 = new ArrayList();
		Class6.arrayList_9.Add("tbody");
		Class6.arrayList_9.Add("thead");
		Class6.arrayList_9.Add("tfoot");
		Class6.arrayList_14 = new ArrayList();
		Class6.arrayList_14.Add("thead");
		Class6.arrayList_14.Add("tfoot");
		Class6.arrayList_14.Add("tbody");
		Class6.arrayList_14.Add("tr");
		Class6.arrayList_10 = new ArrayList();
		Class6.arrayList_10.Add("td");
		Class6.arrayList_10.Add("th");
		Class6.arrayList_10.Add("tr");
		Class6.arrayList_10.Add("tbody");
		Class6.arrayList_10.Add("tfoot");
		Class6.arrayList_10.Add("thead");
		Class6.arrayList_13 = new ArrayList();
		Class6.arrayList_13.Add("td");
		Class6.arrayList_13.Add("th");
		Class6.arrayList_13.Add("tr");
		Class6.arrayList_13.Add("tbody");
		Class6.arrayList_13.Add("tfoot");
		Class6.arrayList_13.Add("thead");
		Class6.arrayList_12 = new ArrayList();
		Class6.arrayList_12.Add("tbody");
		Class6.arrayList_12.Add("tfoot");
		Class6.arrayList_11 = new ArrayList();
		Class6.arrayList_11.Add("tbody");
		Class6.arrayList_11.Add("thead");
	}

	private static void smethod_14()
	{
		Class6.hashtable_0 = new Hashtable();
		Class6.hashtable_0["Aacute"] = 'Á';
		Class6.hashtable_0["aacute"] = 'á';
		Class6.hashtable_0["Acirc"] = 'Â';
		Class6.hashtable_0["acirc"] = 'â';
		Class6.hashtable_0["acute"] = '´';
		Class6.hashtable_0["AElig"] = 'Æ';
		Class6.hashtable_0["aelig"] = 'æ';
		Class6.hashtable_0["Agrave"] = 'À';
		Class6.hashtable_0["agrave"] = 'à';
		Class6.hashtable_0["alefsym"] = 'ℵ';
		Class6.hashtable_0["Alpha"] = 'Α';
		Class6.hashtable_0["alpha"] = 'α';
		Class6.hashtable_0["amp"] = '&';
		Class6.hashtable_0["and"] = '∧';
		Class6.hashtable_0["ang"] = '∠';
		Class6.hashtable_0["Aring"] = 'Å';
		Class6.hashtable_0["aring"] = 'å';
		Class6.hashtable_0["asymp"] = '≈';
		Class6.hashtable_0["Atilde"] = 'Ã';
		Class6.hashtable_0["atilde"] = 'ã';
		Class6.hashtable_0["Auml"] = 'Ä';
		Class6.hashtable_0["auml"] = 'ä';
		Class6.hashtable_0["bdquo"] = '„';
		Class6.hashtable_0["Beta"] = 'Β';
		Class6.hashtable_0["beta"] = 'β';
		Class6.hashtable_0["brvbar"] = '¦';
		Class6.hashtable_0["bull"] = '•';
		Class6.hashtable_0["cap"] = '∩';
		Class6.hashtable_0["Ccedil"] = 'Ç';
		Class6.hashtable_0["ccedil"] = 'ç';
		Class6.hashtable_0["cent"] = '¢';
		Class6.hashtable_0["Chi"] = 'Χ';
		Class6.hashtable_0["chi"] = 'χ';
		Class6.hashtable_0["circ"] = 'ˆ';
		Class6.hashtable_0["clubs"] = '♣';
		Class6.hashtable_0["cong"] = '≅';
		Class6.hashtable_0["copy"] = '©';
		Class6.hashtable_0["crarr"] = '↵';
		Class6.hashtable_0["cup"] = '∪';
		Class6.hashtable_0["curren"] = '¤';
		Class6.hashtable_0["dagger"] = '†';
		Class6.hashtable_0["Dagger"] = '‡';
		Class6.hashtable_0["darr"] = '↓';
		Class6.hashtable_0["dArr"] = '⇓';
		Class6.hashtable_0["deg"] = '°';
		Class6.hashtable_0["Delta"] = 'Δ';
		Class6.hashtable_0["delta"] = 'δ';
		Class6.hashtable_0["diams"] = '♦';
		Class6.hashtable_0["divide"] = '÷';
		Class6.hashtable_0["Eacute"] = 'É';
		Class6.hashtable_0["eacute"] = 'é';
		Class6.hashtable_0["Ecirc"] = 'Ê';
		Class6.hashtable_0["ecirc"] = 'ê';
		Class6.hashtable_0["Egrave"] = 'È';
		Class6.hashtable_0["egrave"] = 'è';
		Class6.hashtable_0["empty"] = '∅';
		Class6.hashtable_0["emsp"] = '\u2003';
		Class6.hashtable_0["ensp"] = '\u2002';
		Class6.hashtable_0["Epsilon"] = 'Ε';
		Class6.hashtable_0["epsilon"] = 'ε';
		Class6.hashtable_0["equiv"] = '≡';
		Class6.hashtable_0["Eta"] = 'Η';
		Class6.hashtable_0["eta"] = 'η';
		Class6.hashtable_0["ETH"] = 'Ð';
		Class6.hashtable_0["eth"] = 'ð';
		Class6.hashtable_0["Euml"] = 'Ë';
		Class6.hashtable_0["euml"] = 'ë';
		Class6.hashtable_0["euro"] = '€';
		Class6.hashtable_0["exist"] = '∃';
		Class6.hashtable_0["fnof"] = 'ƒ';
		Class6.hashtable_0["forall"] = '∀';
		Class6.hashtable_0["frac12"] = '½';
		Class6.hashtable_0["frac14"] = '¼';
		Class6.hashtable_0["frac34"] = '¾';
		Class6.hashtable_0["frasl"] = '⁄';
		Class6.hashtable_0["Gamma"] = 'Γ';
		Class6.hashtable_0["gamma"] = 'γ';
		Class6.hashtable_0["ge"] = '≥';
		Class6.hashtable_0["gt"] = '>';
		Class6.hashtable_0["harr"] = '↔';
		Class6.hashtable_0["hArr"] = '⇔';
		Class6.hashtable_0["hearts"] = '♥';
		Class6.hashtable_0["hellip"] = '…';
		Class6.hashtable_0["Iacute"] = 'Í';
		Class6.hashtable_0["iacute"] = 'í';
		Class6.hashtable_0["Icirc"] = 'Î';
		Class6.hashtable_0["icirc"] = 'î';
		Class6.hashtable_0["iexcl"] = '¡';
		Class6.hashtable_0["Igrave"] = 'Ì';
		Class6.hashtable_0["igrave"] = 'ì';
		Class6.hashtable_0["image"] = 'ℑ';
		Class6.hashtable_0["infin"] = '∞';
		Class6.hashtable_0["int"] = '∫';
		Class6.hashtable_0["Iota"] = 'Ι';
		Class6.hashtable_0["iota"] = 'ι';
		Class6.hashtable_0["iquest"] = '¿';
		Class6.hashtable_0["isin"] = '∈';
		Class6.hashtable_0["Iuml"] = 'Ï';
		Class6.hashtable_0["iuml"] = 'ï';
		Class6.hashtable_0["Kappa"] = 'Κ';
		Class6.hashtable_0["kappa"] = 'κ';
		Class6.hashtable_0["Lambda"] = 'Λ';
		Class6.hashtable_0["lambda"] = 'λ';
		Class6.hashtable_0["lang"] = '〈';
		Class6.hashtable_0["laquo"] = '«';
		Class6.hashtable_0["larr"] = '←';
		Class6.hashtable_0["lArr"] = '⇐';
		Class6.hashtable_0["lceil"] = '⌈';
		Class6.hashtable_0["ldquo"] = '“';
		Class6.hashtable_0["le"] = '≤';
		Class6.hashtable_0["lfloor"] = '⌊';
		Class6.hashtable_0["lowast"] = '∗';
		Class6.hashtable_0["loz"] = '◊';
		Class6.hashtable_0["lrm"] = '‎';
		Class6.hashtable_0["lsaquo"] = '‹';
		Class6.hashtable_0["lsquo"] = '‘';
		Class6.hashtable_0["lt"] = '<';
		Class6.hashtable_0["macr"] = '¯';
		Class6.hashtable_0["mdash"] = '—';
		Class6.hashtable_0["micro"] = 'µ';
		Class6.hashtable_0["middot"] = '·';
		Class6.hashtable_0["minus"] = '−';
		Class6.hashtable_0["Mu"] = 'Μ';
		Class6.hashtable_0["mu"] = 'μ';
		Class6.hashtable_0["nabla"] = '∇';
		Class6.hashtable_0["nbsp"] = '\u00a0';
		Class6.hashtable_0["ndash"] = '–';
		Class6.hashtable_0["ne"] = '≠';
		Class6.hashtable_0["ni"] = '∋';
		Class6.hashtable_0["not"] = '¬';
		Class6.hashtable_0["notin"] = '∉';
		Class6.hashtable_0["nsub"] = '⊄';
		Class6.hashtable_0["Ntilde"] = 'Ñ';
		Class6.hashtable_0["ntilde"] = 'ñ';
		Class6.hashtable_0["Nu"] = 'Ν';
		Class6.hashtable_0["nu"] = 'ν';
		Class6.hashtable_0["Oacute"] = 'Ó';
		Class6.hashtable_0["ocirc"] = 'ô';
		Class6.hashtable_0["OElig"] = 'Œ';
		Class6.hashtable_0["oelig"] = 'œ';
		Class6.hashtable_0["Ograve"] = 'Ò';
		Class6.hashtable_0["ograve"] = 'ò';
		Class6.hashtable_0["oline"] = '‾';
		Class6.hashtable_0["Omega"] = 'Ω';
		Class6.hashtable_0["omega"] = 'ω';
		Class6.hashtable_0["Omicron"] = 'Ο';
		Class6.hashtable_0["omicron"] = 'ο';
		Class6.hashtable_0["oplus"] = '⊕';
		Class6.hashtable_0["or"] = '∨';
		Class6.hashtable_0["ordf"] = 'ª';
		Class6.hashtable_0["ordm"] = 'º';
		Class6.hashtable_0["Oslash"] = 'Ø';
		Class6.hashtable_0["oslash"] = 'ø';
		Class6.hashtable_0["Otilde"] = 'Õ';
		Class6.hashtable_0["otilde"] = 'õ';
		Class6.hashtable_0["otimes"] = '⊗';
		Class6.hashtable_0["Ouml"] = 'Ö';
		Class6.hashtable_0["ouml"] = 'ö';
		Class6.hashtable_0["para"] = '¶';
		Class6.hashtable_0["part"] = '∂';
		Class6.hashtable_0["permil"] = '‰';
		Class6.hashtable_0["perp"] = '⊥';
		Class6.hashtable_0["Phi"] = 'Φ';
		Class6.hashtable_0["phi"] = 'φ';
		Class6.hashtable_0["pi"] = 'π';
		Class6.hashtable_0["piv"] = 'ϖ';
		Class6.hashtable_0["plusmn"] = '±';
		Class6.hashtable_0["pound"] = '£';
		Class6.hashtable_0["prime"] = '′';
		Class6.hashtable_0["Prime"] = '″';
		Class6.hashtable_0["prod"] = '∏';
		Class6.hashtable_0["prop"] = '∝';
		Class6.hashtable_0["Psi"] = 'Ψ';
		Class6.hashtable_0["psi"] = 'ψ';
		Class6.hashtable_0["quot"] = '"';
		Class6.hashtable_0["radic"] = '√';
		Class6.hashtable_0["rang"] = '〉';
		Class6.hashtable_0["raquo"] = '»';
		Class6.hashtable_0["rarr"] = '→';
		Class6.hashtable_0["rArr"] = '⇒';
		Class6.hashtable_0["rceil"] = '⌉';
		Class6.hashtable_0["rdquo"] = '”';
		Class6.hashtable_0["real"] = 'ℜ';
		Class6.hashtable_0["reg"] = '®';
		Class6.hashtable_0["rfloor"] = '⌋';
		Class6.hashtable_0["Rho"] = 'Ρ';
		Class6.hashtable_0["rho"] = 'ρ';
		Class6.hashtable_0["rlm"] = '‏';
		Class6.hashtable_0["rsaquo"] = '›';
		Class6.hashtable_0["rsquo"] = '’';
		Class6.hashtable_0["sbquo"] = '‚';
		Class6.hashtable_0["Scaron"] = 'Š';
		Class6.hashtable_0["scaron"] = 'š';
		Class6.hashtable_0["sdot"] = '⋅';
		Class6.hashtable_0["sect"] = '§';
		Class6.hashtable_0["shy"] = '­';
		Class6.hashtable_0["Sigma"] = 'Σ';
		Class6.hashtable_0["sigma"] = 'σ';
		Class6.hashtable_0["sigmaf"] = 'ς';
		Class6.hashtable_0["sim"] = '∼';
		Class6.hashtable_0["spades"] = '♠';
		Class6.hashtable_0["sub"] = '⊂';
		Class6.hashtable_0["sube"] = '⊆';
		Class6.hashtable_0["sum"] = '∑';
		Class6.hashtable_0["sup"] = '⊃';
		Class6.hashtable_0["sup1"] = '¹';
		Class6.hashtable_0["sup2"] = '²';
		Class6.hashtable_0["sup3"] = '³';
		Class6.hashtable_0["supe"] = '⊇';
		Class6.hashtable_0["szlig"] = 'ß';
		Class6.hashtable_0["Tau"] = 'Τ';
		Class6.hashtable_0["tau"] = 'τ';
		Class6.hashtable_0["there4"] = '∴';
		Class6.hashtable_0["Theta"] = 'Θ';
		Class6.hashtable_0["theta"] = 'θ';
		Class6.hashtable_0["thetasym"] = 'ϑ';
		Class6.hashtable_0["thinsp"] = '\u2009';
		Class6.hashtable_0["THORN"] = 'Þ';
		Class6.hashtable_0["thorn"] = 'þ';
		Class6.hashtable_0["tilde"] = '˜';
		Class6.hashtable_0["times"] = '×';
		Class6.hashtable_0["trade"] = '™';
		Class6.hashtable_0["Uacute"] = 'Ú';
		Class6.hashtable_0["uacute"] = 'ú';
		Class6.hashtable_0["uarr"] = '↑';
		Class6.hashtable_0["uArr"] = '⇑';
		Class6.hashtable_0["Ucirc"] = 'Û';
		Class6.hashtable_0["ucirc"] = 'û';
		Class6.hashtable_0["Ugrave"] = 'Ù';
		Class6.hashtable_0["ugrave"] = 'ù';
		Class6.hashtable_0["uml"] = '¨';
		Class6.hashtable_0["upsih"] = 'ϒ';
		Class6.hashtable_0["Upsilon"] = 'Υ';
		Class6.hashtable_0["upsilon"] = 'υ';
		Class6.hashtable_0["Uuml"] = 'Ü';
		Class6.hashtable_0["uuml"] = 'ü';
		Class6.hashtable_0["weierp"] = '℘';
		Class6.hashtable_0["Xi"] = 'Ξ';
		Class6.hashtable_0["xi"] = 'ξ';
		Class6.hashtable_0["Yacute"] = 'Ý';
		Class6.hashtable_0["yacute"] = 'ý';
		Class6.hashtable_0["yen"] = '¥';
		Class6.hashtable_0["Yuml"] = 'Ÿ';
		Class6.hashtable_0["yuml"] = 'ÿ';
		Class6.hashtable_0["Zeta"] = 'Ζ';
		Class6.hashtable_0["zeta"] = 'ζ';
		Class6.hashtable_0["zwj"] = '‍';
		Class6.hashtable_0["zwnj"] = '‌';
	}

	public Class6()
	{
		
		
	}

	private static ArrayList arrayList_0;

	private static ArrayList arrayList_1;

	private static ArrayList arrayList_2;

	private static ArrayList arrayList_3;

	private static ArrayList arrayList_4;

	private static ArrayList arrayList_5;

	private static ArrayList arrayList_6;

	private static ArrayList arrayList_7;

	private static ArrayList arrayList_8;

	private static ArrayList arrayList_9;

	private static ArrayList arrayList_10;

	private static ArrayList arrayList_11;

	private static ArrayList arrayList_12;

	private static ArrayList arrayList_13;

	private static ArrayList arrayList_14;

	private static Hashtable hashtable_0;
}
