using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc;
using NS.STMS.MVC.Models.ComponentModels.HtmlElementCompenents;
using NS.STMS.MVC.Extensions;

namespace NS.STMS.MVC.ViewComponents.HtmlElementCompenents
{
	public class InputDivViewComponent : ViewComponent
	{

		public ViewViewComponentResult Invoke(
			string key,
			object value,
			string id,
			int maxLength,
			string onChange,
			string type = "text",
			bool disabled = false
			)
		{
			string path = GetType().GetViewComponentPath();

			InputDivComponentModel model = new InputDivComponentModel
			{
				Id = id,
				Type = type,
				MaxLength = maxLength,

				_key = key,
				_value = value == null ? null : value.ToString(),

				OnChange = onChange,

				Disabled = disabled
			};

			return View(path, model);
		}
	}
}
