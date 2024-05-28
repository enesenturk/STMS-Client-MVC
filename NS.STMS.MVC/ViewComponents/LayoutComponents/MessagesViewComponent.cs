using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using NS.STMS.MVC.Preferences.StructurePreferences;

namespace NS.STMS.MVC.ViewComponents.LayoutComponents
{
	public class MessagesViewComponent : ViewComponent
	{

		#region CTOR

		private string _url = $"{ViewStructurePreferences.ViewComponentsFolderPath}/LayoutComponents/Messages/Default.cshtml";

		#endregion

		public ViewViewComponentResult Invoke()
		{
			return View(_url);
		}

	}
}
