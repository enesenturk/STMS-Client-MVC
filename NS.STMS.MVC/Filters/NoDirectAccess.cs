using Microsoft.AspNetCore.Mvc.Filters;
using NS.STMS.MVC.Extensions;
using NS.STMS.MVC.Helpers;

namespace NS.STMS.MVC.Filters
{
	public class NoDirectAccess : ActionFilterAttribute
	{

		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			string actionName = filterContext.RouteData.Values["action"].ToString();
			string controllerName = filterContext.RouteData.Values["controller"].ToString();

			bool letAccess = GetDoNotTrack(controllerName, actionName);

			if (letAccess)
				return;

			bool canAccess = CheckNoDirectAccess(filterContext);

			if (!canAccess)
				ActionResultHelper.ClearAndRedirectToLogin(ref filterContext);
		}

		#region extracted methods

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

		private bool GetDoNotTrack(string controllerName, string actionName)
		{
			return
				(controllerName == "Account" && actionName == "Globalize") ||
				(controllerName == "Account" && actionName == "ForgotPassword") ||
				(controllerName == "Account" && actionName == "Login") ||
				(controllerName == "Account" && actionName == "LogOut");
		}

		#endregion

	}
}
