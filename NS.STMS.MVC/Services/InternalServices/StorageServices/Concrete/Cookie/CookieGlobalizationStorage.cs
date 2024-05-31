using CMS.Core.Utilities.ExceptionHandling;
using Microsoft.AspNetCore.Localization;
using NS.STMS.CORE.Helpers;
using NS.STMS.MVC.Helpers;
using NS.STMS.MVC.Preferences.CookiePreferences;
using NS.STMS.MVC.Services.InternalServices.StorageServices.Abstract;
using NS.STMS.MVC.Services.InternalServices.StorageServices.Concrete.Cookie.Dtos;
using NS.STMS.MVC.Services.InternalServices.StorageServices.Concrete.Cookie.Managers;
using NS.STMS.Resources.Language.Languages;
using System.Globalization;

namespace NS.STMS.MVC.Services.InternalServices.StorageServices.Concrete.Cookie
{
	public class CookieGlobalizationStorage : IGlobalizationStorage
	{

		#region CTOR

		private ICookieService _cookieService;

		public CookieGlobalizationStorage(ICookieService cookieService)
		{
			_cookieService = cookieService;
		}

		#endregion

		#region Time Difference

		public int GetTimeZoneDifference()
		{
			string localTimezone = _cookieService.Get(GlobalizationCookiePreferences.LocalTimeZone);

			if (string.IsNullOrEmpty(localTimezone))
				throw new CoreException(Messages.Error_Ocurred);

			return Convert.ToInt32(localTimezone);
		}

		public void SetTimeZoneDifference(int differenceMinutes)
		{
			_cookieService.Set(new CookieModel
			{
				key = GlobalizationCookiePreferences.LocalTimeZone,
				value = differenceMinutes.ToString(),
				httpOnly = true,
				expire = DateTimeHelper.GetNowPlusDays(GlobalizationCookiePreferences.TimeoutDays)
			});
		}

		#endregion

		#region Language

		public CultureInfo GetLanguageCulture()
		{
			string culture = _cookieService.Get(GlobalizationCookiePreferences.Language);

			if (string.IsNullOrEmpty(culture))
				return null;

			return new CultureInfo(culture);
		}

		public void SetLanguage(string langauge)
		{
			langauge = LanguageSettingsHelper.GetSupportedLanguage(langauge);

			_cookieService.Set(new CookieModel
			{
				key = GlobalizationCookiePreferences.Language,
				value = langauge,
				httpOnly = true,
				expire = DateTimeHelper.GetNowPlusDays(GlobalizationCookiePreferences.TimeoutDays)
			});

			_cookieService.Set(new CookieModel
			{
				key = CookieRequestCultureProvider.DefaultCookieName,
				value = CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(langauge)),
				httpOnly = true,
				expire = DateTimeHelper.GetNowPlusDays(GlobalizationCookiePreferences.TimeoutDays)
			});
		}

		#endregion

	}
}
