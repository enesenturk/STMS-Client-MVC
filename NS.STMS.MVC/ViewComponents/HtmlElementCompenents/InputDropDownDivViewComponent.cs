using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc;
using NS.STMS.MVC.Preferences.StructurePreferences;
using NS.STMS.MVC.Models;
using NS.STMS.MVC.Models.ComponentModels.HtmlElementCompenents;

namespace NS.STMS.MVC.ViewComponents.HtmlElementCompenents
{
	public class InputDropDownDivViewComponent : ViewComponent
	{

		#region CTOR

		private string _url = $"{ViewStructurePreferences.ViewComponentsFolderPath}/HtmlElementCompenents/InputDropDownDiv/Default.cshtml";

		#endregion

		public ViewViewComponentResult Invoke(
			List<JSonDto> options,
			string key,
			object value,
			string id,
			string onChange,
			bool disabled = false
			)
		{
			InputDropDownDivComponentModel model = new InputDropDownDivComponentModel
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
