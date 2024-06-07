using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using NS.STMS.MVC.Models;
using CMS.Core.Utilities.ExceptionHandling;
using NS.STMS.CORE.Helpers;
using NS.STMS.MVC.Services.InternalServices.StorageServices.Concrete.Cookie.Managers;
using NS.STMS.MVC.Services.InternalServices.StorageServices.Concrete.Cookie.Dtos;
using NS.STMS.MVC.Preferences.CookiePreferences;
using NS.STMS.Resources.Language.Languages;
using NS.STMS.CORE.Utilities.ExceptionHandling;

namespace NS.STMS.MVC.Filters
{
	public class ExceptionHandler : ExceptionFilterAttribute
	{

		public override void OnException(ExceptionContext filterContext)
		{
			Type exceptionType = filterContext.Exception.GetType();

			bool isAuthorizationException = exceptionType == typeof(AuthorizationException);

			if (isAuthorizationException)
			{
				filterContext.Result = new RedirectToRouteResult(
					new RouteValueDictionary {
						{ "action", "LogOut" },
						{ "controller", "Account" }
					});
			}

			Type actionReturnType = GetActionReturnType(filterContext);

			if (
				actionReturnType == typeof(JsonResult) ||
				actionReturnType == typeof(Task<JsonResult>)
				)
			{
				HandleJsonExeption(filterContext);
			}
			else
			{
				HandleViewExeption(filterContext);
			}
		}

		#region extracted methods

		private Type GetActionReturnType(ExceptionContext filterContext)
		{
			Type returnType = (filterContext.ActionDescriptor as ControllerActionDescriptor).MethodInfo.ReturnType;

			return returnType;
		}

		private void HandleViewExeption(ExceptionContext filterContext)
		{
			string exeptionMessage = GetExceptionMessage(filterContext);

			filterContext.ExceptionHandled = true;

			// TODO
			ICookieService cookieService = (ICookieService)filterContext.HttpContext.RequestServices.GetService(typeof(ICookieService));
			cookieService.Set(new CookieModel
			{
				key = ExceptionCookiePreferences.Name,
				value = exeptionMessage,
				httpOnly = false,
				expire = DateTimeHelper.GetNow().AddSeconds(ExceptionCookiePreferences.TimeoutSeconds)
			});

			filterContext.Result = new RedirectToRouteResult(
				new RouteValueDictionary {
					{ "action", "Index" },
					{ "controller", "Home" }
				}
			);
		}

		private void HandleJsonExeption(ExceptionContext filterContext)
		{
			string exeptionMessage = GetExceptionMessage(filterContext);

			BaseResponseModel response = new BaseResponseModel
			{
				Type = "E",
				Message = exeptionMessage
			};

			filterContext.ExceptionHandled = true;
			filterContext.Result = new JsonResult(response);
		}

		private string GetExceptionMessage(ExceptionContext filterContext)
		{
			Type exceptionType = filterContext.Exception.GetType();

			bool isCoreException = exceptionType == typeof(CoreException);

			string exceptionMessage = isCoreException ? filterContext.Exception.Message : Messages.Error_Ocurred;

			return exceptionMessage;
		}

		#endregion

	}
}
