using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace NS.STMS.MVC.Helpers
{
	public class ActionResultHelper
	{

		public static void ClearAndRedirectToLogin(ref ActionExecutingContext filterContext)
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

		public static void ClearAndRedirectToLogin(ref ExceptionContext filterContext)
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

	}
}
