using System;

namespace MarkupConverter
{
	public class MarkupConverter : IMarkupConverter
	{
		public string ConvertXamlToHtml(string xamlText)
		{
			return HtmlFromXamlConverter.ConvertXamlToHtml(xamlText, false);
		}

		public string ConvertHtmlToXaml(string htmlText)
		{
			return HtmlToXamlConverter.ConvertHtmlToXaml(htmlText, true);
		}

		public string ConvertRtfToHtml(string rtfText)
		{
			return RtfToHtmlConverter.ConvertRtfToHtml(rtfText);
		}

		public MarkupConverter()
		{
			
			
		}
	}
}
