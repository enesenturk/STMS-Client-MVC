using NS.STMS.MVC.Models;

namespace NS.STMS.MVC.Helpers
{
	public class DateFormatSettingsHelper
	{

		private static string _defaultDateFormat = "en-US";

		public static List<string> GetSupportedDateFormats()
		{
			return new List<string>
			{
				"en-US",
				"tr-TR"
			};
		}

		public static List<JSonDto> GetSupportedDateFormatDropdown()
		{
			List<JSonDto> dropdown = new List<JSonDto>();

			var supportedDateFormats = GetSupportedDateFormats();

			supportedDateFormats.ForEach(x => dropdown.Add(new JSonDto
			{
				Key = x,
				Value = x
			}));

			return dropdown;
		}

		public static string GetSupportedDateFormat(string dateFormat)
		{
			var supportedDateFormats = GetSupportedDateFormats();

			dateFormat = supportedDateFormats.Contains(dateFormat) ? dateFormat : _defaultDateFormat;

			return dateFormat;
		}

	}
}
