using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc;
using NS.STMS.MVC.Models.ComponentModels.HtmlElementCompenents;
using NS.STMS.MVC.Extensions;

namespace NS.STMS.MVC.ViewComponents.HtmlElementCompenents
{
	public class PasswordInputDivViewComponent : ViewComponent
	{

		public ViewViewComponentResult Invoke(
			bool reenter
			)
		{
			string path = GetType().GetViewComponentPath();

			PasswordInputDivComponentModel model = new PasswordInputDivComponentModel
			{
				ReenterPassword = reenter,
			};

			return View(path, model);
		}
	}
}
