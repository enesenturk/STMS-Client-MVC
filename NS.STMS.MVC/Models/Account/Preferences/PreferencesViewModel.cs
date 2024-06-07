namespace NS.STMS.MVC.Models.Account.Preferences
{
	public class PreferencesViewModel : BaseViewModel
	{

		public string PreferredDateFormat { get; set; }
		public string PreferredLanguage { get; set; }
		public string PreferredNumberFormat { get; set; }

		public List<JSonDto> SupportedDateFormats { get; set; }
		public List<JSonDto> SupportedLanguages { get; set; }
		public List<JSonDto> SupportedNumberFormats { get; set; }

	}
}
