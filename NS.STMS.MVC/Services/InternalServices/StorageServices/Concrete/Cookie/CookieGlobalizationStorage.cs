using CMS.Core.Utilities.ExceptionHandling;
using NS.STMS.CORE.Helpers;
using NS.STMS.MVC.Services.InternalServices.StorageServices.Abstract;
using NS.STMS.MVC.Services.InternalServices.StorageServices.Concrete.Cookie.Constants;
using NS.STMS.MVC.Services.InternalServices.StorageServices.Concrete.Cookie.Dtos;
using NS.STMS.MVC.Services.InternalServices.StorageServices.Concrete.Cookie.Managers;
using NS.STMS.MVC.Services.InternalServices.StorageServices.Concrete.Cookie.Preferences;
using NS.STMS.Resources.Language.Languages;

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
			string localTimezone = _cookieService.Get(CookieGlobalizationConstants.LocalTimeZone);

			if (string.IsNullOrEmpty(localTimezone))
				throw new CoreException(Messages.Error_Ocurred);

			return Convert.ToInt32(localTimezone);
		}

		public void SetTimeZoneDifference(int differenceMinutes)
		{
			_cookieService.Set(new CookieModel
			{
				key = CookieGlobalizationConstants.LocalTimeZone,
				value = differenceMinutes.ToString(),
				httpOnly = true,
				expire = DateTimeHelper.GetNowPlusDays(CookieTimeoutPreferences.NonSensitiveTimeoutDays)
			});
		}

		#endregion

	}
}
