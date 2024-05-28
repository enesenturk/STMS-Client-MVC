using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using NS.STMS.MVC.Preferences.StructurePreferences;

namespace NS.STMS.MVC.ViewComponents.LayoutComponents
{
	public class UserMenuViewComponent : ViewComponent
	{

		#region CTOR

		private string _url = $"{ViewStructurePreferences.ViewComponentsFolderPath}/LayoutComponents/UserMenu/Default.cshtml";

		#endregion

		public ViewViewComponentResult Invoke()
		{
			return View(_url);
		}

	}
}
