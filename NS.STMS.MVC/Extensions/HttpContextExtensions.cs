using Microsoft.AspNetCore.Mvc.Controllers;
using NS.STMS.MVC.Preferences.StructurePreferences;

namespace NS.STMS.MVC.Extensions
{
	public static class HttpContextExtensions
	{

		public static string GetCurrentControllerName(this HttpContext context)
		{
			string controllerName = context.GetRouteValue("controller").ToString();

			return controllerName;
		}

		public static string GetViewsFolderPath(this HttpContext context)
		{
			string controllerName = context.GetCurrentControllerName();

			string viewsFolderPath = $"{ViewStructurePreferences.AdminFolderPath}/{controllerName}";

			return viewsFolderPath;
		}

	}
}
