using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NS.STMS.MVC.Extensions;
using NS.STMS.MVC.Models;
using NS.STMS.MVC.Models.Admin.GradeLectures;
using NS.STMS.MVC.Models.ComponentModels.LayoutComponentModels.PageHeaderModels;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.GradeLectures.Commands.CreateGradeLecture.Dtos;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.GradeLectures.Commands.CreateGradeLecture.Managers;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.GradeLectures.Dtos;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.GradeLectures.Queries.GetGradeLectures.Dtos;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.GradeLectures.Queries.GetGradeLectures.Managers;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.GradeLectures.Queries.GetGradesAndLectures.Dtos;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.GradeLectures.Queries.GetGradesAndLectures.Managers;
using NS.STMS.MVC.Settings;
using NS.STMS.MVC.Utility;

namespace NS.STMS.MVC.Controllers.Admin
{

	[Route("Admin/GradeLectures")]
	public class GradeLecturesController : CustomBaseController
	{

		#region CTOR

		private readonly int _countryId = 1;
		private readonly ICreateGradeLectureService _createGradeLectureService;

		private readonly IGetGradeLecturesService _getGradeLecturesService;
		private readonly IGetGradesAndLecturesService _getGradesAndLecturesService;

		public GradeLecturesController(IHttpContextAccessor httpContextAccessor,
			IOptions<AppSettings> appSettings,

			ICreateGradeLectureService createGradeLectureService,

			IGetGradeLecturesService getGradeLecturesService,
			IGetGradesAndLecturesService getGradesAndLecturesService) : base(httpContextAccessor, appSettings)
		{

			_createGradeLectureService = createGradeLectureService;

			_getGradeLecturesService = getGradeLecturesService;
			_getGradesAndLecturesService = getGradesAndLecturesService;
		}

		#endregion

		#region Create

		[Route("Add")]
		[HttpGet]
		public ViewResult Add()
		{
			PageHeaderComponentModel pageHeader = _httpContextAccessor.HttpContext.GetPageHeader();

			GetGradesAndLecturesResponseDto gradesAndLecturesResponse = _getGradesAndLecturesService.Query(_countryId);

			gradesAndLecturesResponse.Lectures = gradesAndLecturesResponse.Lectures.SetLangaugeTextFromValue().OrderList();

			GradeLecturesAddViewModel model = new GradeLecturesAddViewModel
			{
				PageHeader = pageHeader,
				Grades = gradesAndLecturesResponse.Grades,
				Lectures = gradesAndLecturesResponse.Lectures
			};

			return View($"{_viewsFolderPath}/_Add.cshtml", model);
		}

		[Route("Add")]
		[HttpPost]
		public JsonResult Add(GradeLectureDto request)
		{
			CreateGradeLectureRequestDto model = new CreateGradeLectureRequestDto
			{
				GradeId = request.GradeId,
				LectureId = request.LectureId
			};

			_createGradeLectureService.Command(model);

			return Json(new BaseResponseModel
			{
				ResponseModel = request
			});
		}

		#endregion

		#region Read

		public ViewResult Index()
		{
			PageHeaderComponentModel pageHeader = _httpContextAccessor.HttpContext.GetPageHeader(includeAddButton: true);

			GradeLecturesViewModel model = new GradeLecturesViewModel
			{
				PageHeader = pageHeader
			};

			return View($"{_viewsFolderPath}/_Index.cshtml", model);
		}

		[Route("GetList")]
		public JsonResult GetList()
		{
			GetGradeLecturesResponseDto gradeLecturesResponse = _getGradeLecturesService.Query(_countryId);

			gradeLecturesResponse.Lectures = gradeLecturesResponse.Lectures.SetLangaugeTextFromValue().OrderList();

			return Json(new BaseResponseModel
			{
				ResponseModel = gradeLecturesResponse
			});
		}

		#endregion

		#region Update

		#endregion

		#region Delete

		#endregion

	}
}
