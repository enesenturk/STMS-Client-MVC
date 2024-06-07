using NS.STMS.MVC.Models;
using System.Globalization;

namespace NS.STMS.MVC.Helpers
{
	public class LanguageSettingsHelper
	{

		private static string _defaultLanguage = "en-US";

		public static List<string> GetSupportedLanguages()
		{
			return new List<string>
			{
				"en-US",
				"tr-TR"
			};
		}

		public static List<JSonDto> GetSupportedLanguageDropdown()
		{
			List<JSonDto> dropdown = new List<JSonDto>();

			var supportedLanguages = GetSupportedLanguages();

			supportedLanguages.ForEach(x => dropdown.Add(new JSonDto
			{
				Key = x,
				Value = x
			}));

			return dropdown;
		}

		public static List<CultureInfo> GetSupportedLanguageCultures()
		{
			List<CultureInfo> supportedLanguageCultures = new List<CultureInfo>();

			List<string> supportedLanguages = GetSupportedLanguages();

			supportedLanguages.ForEach(l => supportedLanguageCultures.Add(new CultureInfo(l)));

			return supportedLanguageCultures;
		}

		public static string GetSupportedLanguage(string language)
		{
			var supportedLanguages = GetSupportedLanguages();

			language = supportedLanguages.Contains(language) ? language : _defaultLanguage;

			return language;
		}

	}
}
