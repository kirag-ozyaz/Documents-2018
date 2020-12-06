using System;

namespace MarkupConverter
{
	public interface IMarkupConverter
	{
		string ConvertXamlToHtml(string xamlText);

		string ConvertHtmlToXaml(string htmlText);

		string ConvertRtfToHtml(string rtfText);
	}
}
