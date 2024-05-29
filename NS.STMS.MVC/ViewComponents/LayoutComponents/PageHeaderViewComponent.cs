using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using NS.STMS.MVC.Extensions;
using NS.STMS.MVC.Models.ComponentModels.LayoutComponentModels.PageHeaderModels;

namespace NS.STMS.MVC.ViewComponents.LayoutComponents
{
	public class PageHeaderViewComponent : ViewComponent
	{

		public ViewViewComponentResult Invoke(PageHeaderComponentModel model)
		{
			string path = GetType().GetViewComponentPath();

			return View(path, model);
		}

	}
}
