using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc;
using NS.STMS.MVC.Models;
using NS.STMS.MVC.Models.ComponentModels.HtmlElementCompenents;
using NS.STMS.MVC.Extensions;

namespace NS.STMS.MVC.ViewComponents.HtmlElementCompenents
{
	public class InputDropDownDivViewComponent : ViewComponent
	{

		public ViewViewComponentResult Invoke(
			List<JSonDto> options,
			string key,
			string value,
			string id,
			string onChange,
			bool disabled = false
			)
		{
			string path = GetType().GetViewComponentPath();

			InputDropDownDivComponentModel model = new InputDropDownDivComponentModel
			{
				Id = id,

				_key = key,
				_value = value,

				Options = options,
				OnChange = onChange,

				Disabled = disabled
			};

			return View(path, model);
		}
	}
}
