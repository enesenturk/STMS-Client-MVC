using System.Globalization;

namespace NS.STMS.MVC.Helpers
{
	public class LanguageSettingsHelper
	{

		private static string _defaultLanguage = "tr-TR";

		public static List<string> GetSupportedLanguages()
		{
			return new List<string>
			{
				"tr-TR",
				"en-US"
			};
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
