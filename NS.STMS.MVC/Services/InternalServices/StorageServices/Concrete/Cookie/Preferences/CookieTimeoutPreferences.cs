namespace NS.STMS.MVC.Services.InternalServices.StorageServices.Concrete.Cookie.Preferences
{
	public class CookieTimeoutPreferences
	{

		public static int AccessTokenTimeoutMinutes
		{
			get
			{
				return 5;
			}
		}

		public static int RefreshTokenTimeoutDays
		{
			get
			{
				return 5;
			}
		}

		public static int NonSensitiveTimeoutDays
		{
			get
			{
				return 15;
			}
		}

	}
}
