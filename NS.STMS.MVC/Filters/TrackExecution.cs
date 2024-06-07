using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using NS.STMS.CORE.Helpers;
using NS.STMS.MVC.Services.InternalServices.StorageServices.Abstract;
using NS.STMS.MVC.Models.Account.Authentication;

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
				ClearAndRedirectToLogin(filterContext);
		}

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

			bool canAccess = CheckNoDirectAccess(filterContext);

			return canAccess;
		}

		#region extracted methods

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

		private bool CheckNoDirectAccess(ActionExecutingContext filterContext)
		{
			string controllerName = filterContext.RouteData.Values["controller"].ToString();

			if (controllerName == "Home")
				return true;

			bool canAcess = false;

			var referer = filterContext.HttpContext.Request.Headers["Referer"].ToString();

			if (!string.IsNullOrEmpty(referer))
			{
				var rUri = new UriBuilder(referer).Uri;
				var req = filterContext.HttpContext.Request;

				if (
					req.Host.Host == rUri.Host
					/*&& req.Host.Port == rUri.Port*/
					&& req.Scheme == rUri.Scheme
					)
					canAcess = true;
			}

			return canAcess;
		}

		#region Track/Let Pages

		private bool GetDoNotTrack(string controllerName, string actionName)
		{
			return
				(controllerName == "Account" && actionName == "Globalize") ||
				(controllerName == "Account" && actionName == "SetDefaultLanguage") ||
				(controllerName == "Account" && actionName == "Login") ||
				(controllerName == "Account" && actionName == "LogOut") ||
				(controllerName == "Account" && actionName == "TermsAndConditions") ||
				(controllerName == "Account" && actionName == "AcceptTermsAndConditions");
		}

		private void ClearAndRedirectToLogin(ActionExecutingContext filterContext)
		{
			filterContext.Result = new RedirectToRouteResult(
				new RouteValueDictionary(
					new
					{
						controller = "Account",
						action = "LogOut"
					})
				);
		}

		#endregion

		#endregion

	}
}
