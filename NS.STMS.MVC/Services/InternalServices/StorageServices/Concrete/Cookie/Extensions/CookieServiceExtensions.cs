using NS.STMS.MVC.Services.InternalServices.StorageServices.Concrete.Cookie.Helpers;
using NS.STMS.MVC.Services.InternalServices.StorageServices.Concrete.Cookie.Managers;
using System.Reflection;

namespace NS.STMS.MVC.Services.InternalServices.StorageServices.Concrete.Cookie.Extensions
{
	public static class CookieServiceExtensions
	{

		public static void Clear<T>(this ICookieService cookieService)
		{
			Type myType = typeof(T);

			List<string> cookieFieldNames = CookieHelper.GetCookieNamesOfType<T>();

			foreach (string cookieFieldName in cookieFieldNames)
			{
				PropertyInfo propertyInfo = myType.GetProperty(cookieFieldName);
				string cookieName = propertyInfo.GetValue(null).ToString();

				cookieService.Remove(cookieName);
			}
		}

	}
}
