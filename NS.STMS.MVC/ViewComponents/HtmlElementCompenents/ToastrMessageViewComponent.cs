using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc;
using NS.STMS.MVC.Preferences.StructurePreferences;

namespace NS.STMS.MVC.ViewComponents.HtmlElementCompenents
{
	public class ToastrMessageViewComponent : ViewComponent
	{

		#region CTOR

		private string _url = $"{ViewStructurePreferences.ViewComponentsFolderPath}/HtmlElementCompenents/ToastrMessage/Default.cshtml";

		#endregion

		public ViewViewComponentResult Invoke()
		{
			return View(_url);
		}

	}
}
