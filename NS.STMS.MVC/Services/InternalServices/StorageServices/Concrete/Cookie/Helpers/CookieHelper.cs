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

	}
}
