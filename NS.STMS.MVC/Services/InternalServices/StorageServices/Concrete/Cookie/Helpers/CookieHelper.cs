using System.Reflection;

namespace NS.STMS.MVC.Services.InternalServices.StorageServices.Concrete.Cookie.Helpers
{
	public class CookieHelper
	{
		public static CookieOptions CreateCookieOptions(DateTime timeOut, bool httpOnly)
		{
			CookieOptions options = new CookieOptions
			{
				Expires = timeOut,
				HttpOnly = httpOnly
			};

			return options;
		}

		public static List<string> GetCookieNamesOfType<T>()
		{
			Type constantsType = typeof(T);

			var fields = constantsType.GetProperties();
			List<string> cookieNames = fields.Where(x => x.Name.Contains("CookieName_")).Select(x => x.Name).ToList();

			return cookieNames;
		}

	}
}
