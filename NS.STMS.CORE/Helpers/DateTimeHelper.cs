namespace NS.STMS.CORE.Helpers
{
	public class DateTimeHelper
	{

		public static DateTime GetNow() => DateTime.Now.ToUniversalTime();
		public static DateTime GetNowPlusDays(int days) => GetNow().AddDays(days);

	}
}
