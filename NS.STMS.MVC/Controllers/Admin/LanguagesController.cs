using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NS.STMS.MVC.Models.Admin.GradeLectures;
using NS.STMS.MVC.Models.ComponentModels.LayoutComponentModels.PageHeaderModels;
using NS.STMS.MVC.Settings;
using NS.STMS.MVC.Utility;
using NS.STMS.MVC.Models.Admin.Languages;
using NS.STMS.MVC.Extensions;
using NS.STMS.MVC.Models;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.Languages.Queries.GetLanguages.Dtos;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.Languages.Queries.GetLanguages.Managers;

namespace NS.STMS.MVC.Controllers.Admin
{

    [Route("Admin/Languages")]
	public class LanguagesController : CustomBaseController
	{

		#region CTOR

		private readonly IGetLanguagesService _getLanguagesService;

		public LanguagesController(IHttpContextAccessor httpContextAccessor,
			IOptions<AppSettings> appSettings,
			IGetLanguagesService getLanguagesService) : base(httpContextAccessor, appSettings)
		{
			_getLanguagesService = getLanguagesService;
		}

		#endregion

		#region Create

		[Route("Add")]
		public ViewResult Add()
		{
			PageHeaderComponentModel pageHeader = _httpContextAccessor.HttpContext.GetPageHeader();

			GradeLecturesAddViewModel model = new GradeLecturesAddViewModel
			{
				PageHeader = pageHeader
			};

			return View($"{_viewsFolderPath}/_Add.cshtml", model);
		}

		#endregion

		#region Read

		public ViewResult Index()
		{
			PageHeaderComponentModel pageHeader = _httpContextAccessor.HttpContext.GetPageHeader(includeAddButton: true);

			LanguagesViewModel model = new LanguagesViewModel
			{
				PageHeader = pageHeader
			};

			return View($"{_viewsFolderPath}/_Index.cshtml", model);
		}

		[HttpPost]
		public JsonResult GetList()
		{
			GetLanguagesResponseDto languagesResponse = _getLanguagesService.Query();

			return Json(new BaseResponseModel
			{
				ResponseModel = languagesResponse
			});
		}

		#endregion

		#region Update

		#endregion

		#region Delete

		#endregion

	}
}
