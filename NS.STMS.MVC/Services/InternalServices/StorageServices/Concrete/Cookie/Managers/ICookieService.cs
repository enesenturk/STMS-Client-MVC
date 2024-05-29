using NS.STMS.MVC.Services.InternalServices.StorageServices.Concrete.Cookie.Dtos;

namespace NS.STMS.MVC.Services.InternalServices.StorageServices.Concrete.Cookie.Managers
{
	public interface ICookieService
	{
		string Get(string key);
		void Remove(string key);
		void Set(CookieModel model);

	}
}