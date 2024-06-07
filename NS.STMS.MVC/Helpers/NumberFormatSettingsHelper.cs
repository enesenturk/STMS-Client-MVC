using NS.STMS.MVC.Models;

namespace NS.STMS.MVC.Helpers
{
	public class NumberFormatSettingsHelper
	{
		private static string _defaultNumberFormat = "en-US";

		public static List<string> GetSupportedNumberFormats()
		{
			return new List<string>
			{
				"en-US",
				"tr-TR"
			};
		}

		public static List<JSonDto> GetSupportedNumberFormatDropdown()
		{
			List<JSonDto> dropdown = new List<JSonDto>();

			var supportedNumberFormats = GetSupportedNumberFormats();

			supportedNumberFormats.ForEach(x => dropdown.Add(new JSonDto
			{
				Key = x,
				Value = x
			}));

			return dropdown;
		}

		public static string GetSupportedNumberFormat(string numberFormat)
		{
			var supportedNumberFormats = GetSupportedNumberFormats();

			numberFormat = supportedNumberFormats.Contains(numberFormat) ? numberFormat : _defaultNumberFormat;

			return numberFormat;
		}

	}
}
