using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using NS.STMS.MVC.Extensions;
using NS.STMS.MVC.Models.ComponentModels.LayoutComponentModels;
using NS.STMS.MVC.Services.InternalServices.StorageServices.Abstract;

namespace NS.STMS.MVC.ViewComponents.LayoutComponents
{
	public class UserMenuViewComponent : ViewComponent
	{

		#region CTOR

		private readonly ILoginUserStorage _loginUserStorage;

		public UserMenuViewComponent(ILoginUserStorage loginUserStorage)
		{
			_loginUserStorage = loginUserStorage;
		}

		#endregion

		public ViewViewComponentResult Invoke()
		{
			string path = GetType().GetViewComponentPath();

			UserMenuComponentModel model = new UserMenuComponentModel
			{
				NameSurname = _loginUserStorage.GetFullName()
			};

			return View(path, model);
		}

	}
}
