using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using NS.STMS.MVC.Models.ComponentModels.LayoutComponentModels.PageHeaderModels;
using NS.STMS.MVC.Preferences.StructurePreferences;

namespace NS.STMS.MVC.ViewComponents.LayoutComponents
{
	public class PageHeaderViewComponent : ViewComponent
	{

		#region CTOR

		private string _url = $"{ViewStructurePreferences.ViewComponentsFolderPath}/LayoutComponents/PageHeader/Default.cshtml";

		#endregion

		public ViewViewComponentResult Invoke(PageHeaderComponentModel model)
		{
			return View(_url, model);
		}

	}
}
