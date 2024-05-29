using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using NS.STMS.MVC.Extensions;

namespace NS.STMS.MVC.ViewComponents.LayoutComponents
{
	public class MessagesViewComponent : ViewComponent
	{

		public ViewViewComponentResult Invoke()
		{
			string path = GetType().GetViewComponentPath();

			return View(path);
		}

	}
}
