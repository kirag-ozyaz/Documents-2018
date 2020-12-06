using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace MarkupConverter
{
	public static class RtfToHtmlConverter
	{
		public static string ConvertRtfToHtml(string rtfText)
		{
			return HtmlFromXamlConverter.ConvertXamlToHtml(string.Format("<FlowDocument>{0}</FlowDocument>", RtfToHtmlConverter.smethod_0(rtfText)), false);
		}

		private static string smethod_0(string string_0)
		{
			RichTextBox richTextBox = new RichTextBox();
			if (string.IsNullOrEmpty(string_0))
			{
				return "";
			}
			TextRange textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (StreamWriter streamWriter = new StreamWriter(memoryStream))
				{
					streamWriter.Write(string_0);
					streamWriter.Flush();
					memoryStream.Seek(0L, SeekOrigin.Begin);
					textRange.Load(memoryStream, DataFormats.Rtf);
				}
			}
			string result;
			using (MemoryStream memoryStream2 = new MemoryStream())
			{
				textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
				textRange.Save(memoryStream2, DataFormats.Xaml);
				memoryStream2.Seek(0L, SeekOrigin.Begin);
				using (StreamReader streamReader = new StreamReader(memoryStream2))
				{
					result = streamReader.ReadToEnd();
				}
			}
			return result;
		}
	}
}
