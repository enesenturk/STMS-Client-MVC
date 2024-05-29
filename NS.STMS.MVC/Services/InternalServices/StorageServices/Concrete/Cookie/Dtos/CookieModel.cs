namespace NS.STMS.MVC.Services.InternalServices.StorageServices.Concrete.Cookie.Dtos
{
	public class CookieModel
	{

		public string key { get; set; }
		public string value { get; set; }
		public DateTime? expire { get; set; }
		public bool httpOnly { get; set; } = true;
		public bool isJson { get; set; }

	}
}
