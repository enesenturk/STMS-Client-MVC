using Microsoft.AspNetCore.Mvc.Filters;
using NS.STMS.CORE.Helpers;
using NS.STMS.MVC.Services.InternalServices.StorageServices.Abstract;
using NS.STMS.MVC.Models.Account.Authentication;
using NS.STMS.MVC.Extensions;
using NS.STMS.MVC.Helpers;

namespace NS.STMS.MVC.Filters
{
	public class TrackExecution : ActionFilterAttribute
	{

		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			string actionName = filterContext.RouteData.Values["action"].ToString();
			string controllerName = filterContext.RouteData.Values["controller"].ToString();

			bool letAccess = GetDoNotTrack(controllerName, actionName);

			if (letAccess)
				return;

			bool hasTicket = TicketControl(filterContext);

			if (!hasTicket)
				ActionResultHelper.ClearAndRedirectToLogin(ref filterContext);
		}

		#region extracted methods

		private bool TicketControl(ActionExecutingContext filterContext)
		{
			ILoginUserStorage loginUserStorage = (ILoginUserStorage)filterContext.HttpContext.RequestServices.GetService(typeof(ILoginUserStorage));

			AccessTokenModel accessToken = loginUserStorage.GetAccessToken();

			if (accessToken is null) return false;

			bool isRequiredCookiesExist = IsRequiredCookiesExist(loginUserStorage);

			if (!isRequiredCookiesExist) return false;

			DateTime UtcNow = DateTimeHelper.GetNow();
			bool accessTokenExpired = UtcNow > accessToken.ExpiresAt;

			if (accessTokenExpired)
			{
				RefreshTokenModel refreshToken = loginUserStorage.GetRefreshToken();
				bool refreshTokenExpired = UtcNow > refreshToken.ExpiresAt;

				if (refreshTokenExpired) return false;

				//bool sensitiveDataHasChanged = SensitiveDataHasChanged();

				loginUserStorage.SetAccessToken(accessToken);

				return true;
			}

			return true;
		}

		private bool IsRequiredCookiesExist(ILoginUserStorage loginUserStorage)
		{
			RefreshTokenModel refreshToken = loginUserStorage.GetRefreshToken();
			if (refreshToken is null) return false;

			string preferredDateFormat = loginUserStorage.GetPreferredDateFormat();
			if (string.IsNullOrEmpty(preferredDateFormat)) return false;

			string preferredNumberFormat = loginUserStorage.GetPreferredNumberFormat();
			if (string.IsNullOrEmpty(preferredNumberFormat)) return false;

			string preferredLanguage = loginUserStorage.GetPreferredLanguage();
			if (string.IsNullOrEmpty(preferredLanguage)) return false;

			return true;
		}

		#region Track/Let Pages

		private bool GetDoNotTrack(string controllerName, string actionName)
		{
			return
				(controllerName == "Account" && actionName == "AcceptTermsAndConditions") ||
				(controllerName == "Account" && actionName == "ForgotPassword") ||
				(controllerName == "Account" && actionName == "Globalize") ||
				(controllerName == "Account" && actionName == "Login") ||
				(controllerName == "Account" && actionName == "LogOut") ||
				(controllerName == "Account" && actionName == "ResetPassword") ||
				(controllerName == "Account" && actionName == "SetDefaultLanguage") ||
				(controllerName == "Account" && actionName == "TermsAndConditions");
		}

		#endregion

		#endregion

	}
}
