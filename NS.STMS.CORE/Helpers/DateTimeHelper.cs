namespace NS.STMS.CORE.Helpers
{
	public class DateTimeHelper
	{

		public static DateTime GetNow() => DateTime.Now.ToUniversalTime();

		public static DateTime GetNowPlusMinutes(int minutes) => GetNow().AddMinutes(minutes);
		public static DateTime GetNowPlusHours(int hours) => GetNow().AddHours(hours);
		public static DateTime GetNowPlusDays(int days) => GetNow().AddDays(days);

	}
}
