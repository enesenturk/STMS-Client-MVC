using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc;
using NS.STMS.MVC.Preferences.StructurePreferences;
using NS.STMS.MVC.Models.ComponentModels.BaseViewComponentModels.GetListModels;

namespace NS.STMS.MVC.ViewComponents.BaseViewComponents
{
	public class GetListViewComponent : ViewComponent
	{

		#region CTOR

		private string _url = $"{ViewStructurePreferences.ViewComponentsFolderPath}/BaseViewComponents/GetList/Default.cshtml";

		#endregion

		public ViewViewComponentResult Invoke(bool hasPagination = true, bool hasFilter = true)
		{
			GetListComponentModel model = new GetListComponentModel
			{
				HasFilter = hasFilter,
				HasPagination = hasPagination
			};

			return View(_url, model);
		}

	}
}
