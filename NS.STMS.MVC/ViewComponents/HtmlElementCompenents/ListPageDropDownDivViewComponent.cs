using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc;
using NS.STMS.MVC.Preferences.StructurePreferences;
using NS.STMS.MVC.Models;
using NS.STMS.MVC.Models.ComponentModels.HtmlElementCompenents;

namespace NS.STMS.MVC.ViewComponents.HtmlElementCompenents
{
	public class ListPageDropDownDivViewComponent : ViewComponent
	{

		#region CTOR

		private string _url = $"{ViewStructurePreferences.ViewComponentsFolderPath}/HtmlElementCompenents/ListPageDropDownDiv/Default.cshtml";

		#endregion

		public ViewViewComponentResult Invoke(
			List<JSonDto> options,
			string key,
			object value,
			string id,
			bool disabled = false,
			string onChange = "setDataForListFilter('ListFilterData', currentPage);")
		{
			ListPageDropDownDivComponentModel model = new ListPageDropDownDivComponentModel
			{
				Id = id,

				_key = key,
				_value = value == null ? null : value.ToString(),

				Options = options,
				OnChange = onChange,
				Disabled = disabled
			};

			return View(_url, model);
		}
	}
}
