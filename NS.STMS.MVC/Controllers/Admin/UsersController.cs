using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NS.STMS.MVC.Extensions;
using NS.STMS.MVC.Models.ComponentModels.LayoutComponentModels.PageHeaderModels;
using NS.STMS.MVC.Models;
using NS.STMS.MVC.Settings;
using NS.STMS.MVC.Utility;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.Users.Queries.GetUsers.Managers;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.Users.Queries.GetUsers.Dtos;
using NS.STMS.MVC.Models.Admin.Users;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.Users.Queries.GetAddUserOptions.Dtos;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.Users.Queries.GetAddUserOptions.Managers;

namespace NS.STMS.MVC.Controllers.Admin
{
	[Route("Admin/Users")]
	public class UsersController : CustomBaseController
	{

		#region CTOR

		private readonly IGetAddUserOptionsService _getAddUserOptionsService;
		private readonly IGetUsersService _getUsersService;

		public UsersController(
			IGetAddUserOptionsService getAddUserOptionsService,
			IGetUsersService getUsersService,

			IHttpContextAccessor httpContextAccessor, IOptions<AppSettings> appSettings) : base(httpContextAccessor, appSettings)
		{
			_getAddUserOptionsService = getAddUserOptionsService;
			_getUsersService = getUsersService;
		}

		#endregion

		#region Create

		[Route("Add")]
		[HttpGet]
		public ViewResult Add()
		{
			PageHeaderComponentModel pageHeader = _httpContextAccessor.HttpContext.GetPageHeader();

			GetAddUserOptionsResponseDto response = _getAddUserOptionsService.Query();
			response.Countries = response.Countries.SetLangaugeTextFromValue().OrderList();
			response.Grades = response.Grades.SetLangaugeTextFromValue().OrderList();

			AddUsersViewModel model = new AddUsersViewModel
			{
				PageHeader = pageHeader,
				Countries = response.Countries,
				Grades = response.Grades,
			};

			return View($"{_viewsFolderPath}/_Add.cshtml", model);
		}

		//[Route("Add")]
		//[HttpPost]
		//public JsonResult Add(GradeLectureModel request)
		//{
		//	CreateGradeLectureRequestDto model = new CreateGradeLectureRequestDto
		//	{
		//		GradeId = request.GradeId,
		//		LectureId = request.LectureId
		//	};

		//	_createGradeLectureService.Command(model);

		//	return Json(new BaseResponseModel
		//	{
		//		ResponseModel = request
		//	});
		//}

		#endregion

		#region Read

		public ViewResult Index()
		{
			PageHeaderComponentModel pageHeader = _httpContextAccessor.HttpContext.GetPageHeader(includeAddButton: true);

			UsersViewModel model = new UsersViewModel
			{
				PageHeader = pageHeader
			};

			return View($"{_viewsFolderPath}/_Index.cshtml", model);
		}

		[Route("GetList")]
		public JsonResult GetList()
		{
			GetUsersResponseDto response = _getUsersService.Query();

			return Json(new BaseResponseModel
			{
				ResponseModel = response
			});
		}

		#endregion

		#region Update

		#endregion

		#region Delete

		#endregion

	}
}
