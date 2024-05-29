using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc;
using NS.STMS.MVC.Extensions;

namespace NS.STMS.MVC.ViewComponents.HtmlElementCompenents
{
	public class ToastrMessageViewComponent : ViewComponent
	{

		public ViewViewComponentResult Invoke()
		{
			string path = GetType().GetViewComponentPath();

			return View(path);
		}

	}
}
