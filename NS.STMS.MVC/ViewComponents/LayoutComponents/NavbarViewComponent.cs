using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using NS.STMS.MVC.Extensions;
using NS.STMS.MVC.Models.ComponentModels.LayoutComponentModels;
using NS.STMS.MVC.Preferences.StructurePreferences;
using NS.STMS.MVC.Services.InternalServices.StorageServices.Abstract;

namespace NS.STMS.MVC.ViewComponents.LayoutComponents
{
	public class NavbarViewComponent : ViewComponent
	{

		#region CTOR

		private readonly ILoginUserStorage _loginUserStorage;

		public NavbarViewComponent(ILoginUserStorage loginUserStorage)
		{
			_loginUserStorage = loginUserStorage;
		}

		#endregion

		public ViewViewComponentResult Invoke()
		{
			string path = GetType().GetViewComponentPath();

			var accessToken = _loginUserStorage.GetAccessToken();

			NavbarComponentModel model = new NavbarComponentModel
			{
				NameSurname = _loginUserStorage.GetFullName(accessToken),
				Grade = _loginUserStorage.GetGrade(accessToken),
				SchoolName = _loginUserStorage.GetSchoolName(accessToken)
			};

			return View(path, model);
		}

	}
}
