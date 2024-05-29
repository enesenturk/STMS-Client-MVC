using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc;
using NS.STMS.MVC.Models;
using NS.STMS.MVC.Models.ComponentModels.HtmlElementCompenents;
using NS.STMS.MVC.Extensions;

namespace NS.STMS.MVC.ViewComponents.HtmlElementCompenents
{
	public class ListPageDropDownDivViewComponent : ViewComponent
	{

		public ViewViewComponentResult Invoke(
			List<JSonDto> options,
			string key,
			object value,
			string id,
			bool disabled = false,
			string onChange = "setDataForListFilter('ListFilterData', currentPage);")
		{
			string path = GetType().GetViewComponentPath();

			ListPageDropDownDivComponentModel model = new ListPageDropDownDivComponentModel
			{
				Id = id,

				_key = key,
				_value = value == null ? null : value.ToString(),

				Options = options,
				OnChange = onChange,
				Disabled = disabled
			};

			return View(path, model);
		}
	}
}
