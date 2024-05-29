using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using NS.STMS.MVC.Extensions;
using NS.STMS.MVC.Preferences.StructurePreferences;

namespace NS.STMS.MVC.ViewComponents.LayoutComponents
{
	public class NavbarViewComponent : ViewComponent
	{

		public ViewViewComponentResult Invoke()
		{
			string path = GetType().GetViewComponentPath();

			return View(path);
		}

	}
}
