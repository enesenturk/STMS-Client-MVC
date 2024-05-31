using CMS.Core.Utilities.ExceptionHandling;
using NS.STMS.MVC.Services.InternalServices.StorageServices.Concrete.Cookie.Dtos;
using NS.STMS.MVC.Services.InternalServices.StorageServices.Concrete.Cookie.Extensions;
using NS.STMS.MVC.Services.InternalServices.StorageServices.Concrete.Cookie.Helpers;
using NS.STMS.Resources.Language.Languages;

namespace NS.STMS.MVC.Services.InternalServices.StorageServices.Concrete.Cookie.Managers
{
	public class CookieService : ICookieService
	{

		#region CTOR

		private IHttpContextAccessor _httpContextAccessor;

		public CookieService(IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
		}

		#endregion

		public string Get(string key)
		{
			string cookie = _httpContextAccessor.HttpContext.Request.Cookies[key];

			bool hasCookie = !string.IsNullOrEmpty(cookie);

			return hasCookie ? cookie : null;
		}

		public void Remove(string key)
		{
			_httpContextAccessor.HttpContext.Response.Cookies.Delete(key);
		}

		public void Set(CookieModel model)
		{
			if (model.expire is null)
				throw new CoreException(Messages.Error_Ocurred);

			CookieOptions cookieOptions = CookieHelper.CreateCookieOptions(model.expire.Value, model.httpOnly);

			if (model.isJson)
				_httpContextAccessor.HttpContext.Response.Cookies.Append(model.key, model.value, cookieOptions);
			else
				_httpContextAccessor.HttpContext.Response.AppendUnencodedCookie(model.key, model.value, cookieOptions);
		}

	}
}
