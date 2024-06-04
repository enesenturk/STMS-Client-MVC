using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc;
using NS.STMS.MVC.Models.ComponentModels.HtmlElementCompenents;
using NS.STMS.MVC.Extensions;

namespace NS.STMS.MVC.ViewComponents.HtmlElementCompenents
{
	public class DateInputDivViewComponent : ViewComponent
	{

		public ViewViewComponentResult Invoke(
			string key,
			object value,
			string id,
			string onChange,
			bool disabled = false
			)
		{
			string path = GetType().GetViewComponentPath();

			DateInputDivComponentModel model = new DateInputDivComponentModel
			{
				Id = id,

				_key = key,
				_value = value == null ? null : value.ToString(),

				OnChange = onChange,

				Disabled = disabled
			};

			return View(path, model);
		}
	}
}
