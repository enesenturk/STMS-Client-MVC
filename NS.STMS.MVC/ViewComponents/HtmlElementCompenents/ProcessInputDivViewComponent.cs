using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc;
using NS.STMS.MVC.Extensions;
using NS.STMS.MVC.Models.ComponentModels.HtmlElementCompenents;

namespace NS.STMS.MVC.ViewComponents.HtmlElementCompenents
{
	public class ProcessInputDivViewComponent : ViewComponent
	{

		public ViewViewComponentResult Invoke(
			string id,
			string text,
			string onClick,
			string btnClass,
			bool disabled = false
			)
		{
			string path = GetType().GetViewComponentPath();

			ProcessInputDivViewModel model = new ProcessInputDivViewModel
			{
				Id = id,
				BtnClass = btnClass,
				Text = text,
				OnClick = onClick,
				Disabled = disabled
			};

			return View(path, model);
		}
	}
}
