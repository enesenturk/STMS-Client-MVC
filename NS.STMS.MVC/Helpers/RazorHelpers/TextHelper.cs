using Microsoft.AspNetCore.Html;

namespace NS.STMS.MVC.Helpers.RazorHelpers
{
	public class TextHelper
	{

		public static HtmlString ToHtml(string text)
		{
			return new HtmlString(text);
		}

	}
}
