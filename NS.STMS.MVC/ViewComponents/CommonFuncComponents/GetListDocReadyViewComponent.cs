using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc;
using NS.STMS.MVC.Extensions;
using NS.STMS.MVC.Models.ComponentModels.CommonFuncComponents.GetListModels;

namespace NS.STMS.MVC.ViewComponents.CommonFuncComponents
{
	public class GetListDocReadyViewComponent : ViewComponent
	{

		public ViewViewComponentResult Invoke(bool hasPagination = true, bool hasFilter = true)
		{
			string path = GetType().GetViewComponentPath();

			GetListDocReadyComponentModel model = new GetListDocReadyComponentModel
			{
				HasFilter = hasFilter,
				HasPagination = hasPagination
			};

			return View(path, model);
		}

	}
}
