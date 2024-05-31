using System.Globalization;

namespace NS.STMS.MVC.Services.InternalServices.StorageServices.Abstract
{
	public interface IGlobalizationStorage
	{

		int GetTimeZoneDifference();
		void SetTimeZoneDifference(int differenceMinutes);

		CultureInfo GetLanguageCulture();
		void SetLanguage(string language);

	}
}
