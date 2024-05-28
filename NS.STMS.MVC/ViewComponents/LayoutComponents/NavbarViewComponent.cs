using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using NS.STMS.MVC.Preferences.StructurePreferences;

namespace NS.STMS.MVC.ViewComponents.LayoutComponents
{
	public class NavbarViewComponent : ViewComponent
	{

		#region CTOR

		private string _url = $"{ViewStructurePreferences.ViewComponentsFolderPath}/LayoutComponents/Navbar/Default.cshtml";

		#endregion

		public ViewViewComponentResult Invoke()
		{
			return View(_url);
		}

	}
}
