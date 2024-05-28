using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc;
using NS.STMS.MVC.Preferences.StructurePreferences;

namespace NS.STMS.MVC.ViewComponents.FileComponents
{
	public class TableExcelViewComponent : ViewComponent
	{

		#region CTOR

		private string _url = $"{ViewStructurePreferences.ViewComponentsFolderPath}/FileComponents/TableExcel/Default.cshtml";

		#endregion

		public ViewViewComponentResult Invoke()
		{
			return View(_url);
		}

	}
}
