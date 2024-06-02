using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc;
using NS.STMS.MVC.Extensions;

namespace NS.STMS.MVC.ViewComponents.CommonFuncComponents
{
	public class PostJsonHelperViewComponent : ViewComponent
	{

		public ViewViewComponentResult Invoke()
		{
			string path = GetType().GetViewComponentPath();

			return View(path);
		}

	}
}
