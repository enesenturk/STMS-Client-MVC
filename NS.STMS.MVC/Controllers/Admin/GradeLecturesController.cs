using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NS.STMS.MVC.Extensions;
using NS.STMS.MVC.Models;
using NS.STMS.MVC.Models.Admin.GradeLectures;
using NS.STMS.MVC.Models.ComponentModels.LayoutComponentModels.PageHeaderModels;
using NS.STMS.MVC.Services.STMSServices.Admin.GradeLectures.Commands.CreateGradeLecture.Dtos;
using NS.STMS.MVC.Services.STMSServices.Admin.GradeLectures.Commands.CreateGradeLecture.Managers;
using NS.STMS.MVC.Services.STMSServices.Admin.GradeLectures.Dtos;
using NS.STMS.MVC.Services.STMSServices.Admin.GradeLectures.Queries.GetGradeLectures.Dtos;
using NS.STMS.MVC.Services.STMSServices.Admin.GradeLectures.Queries.GetGradeLectures.Managers;
using NS.STMS.MVC.Services.STMSServices.Admin.GradeLectures.Queries.GetGrades.Dtos;
using NS.STMS.MVC.Services.STMSServices.Admin.GradeLectures.Queries.GetGrades.Managers;
using NS.STMS.MVC.Services.STMSServices.Admin.GradeLectures.Queries.GetLectures.Dtos;
using NS.STMS.MVC.Services.STMSServices.Admin.GradeLectures.Queries.GetLectures.Managers;
using NS.STMS.MVC.Settings;
using NS.STMS.MVC.Utility;

namespace NS.STMS.MVC.Controllers.Admin
{

	[Route("Admin/GradeLectures")]
	public class GradeLecturesController : CustomBaseController
	{

		#region CTOR

		private readonly ICreateGradeLectureService _createGradeLectureService;

		private readonly IGetGradeLecturesService _getGradeLecturesService;
		private readonly IGetGradesService _getGradesService;
		private readonly IGetLecturesService _getLecturesService;

		public GradeLecturesController(IHttpContextAccessor httpContextAccessor,
			IOptions<AppSettings> appSettings,

			ICreateGradeLectureService createGradeLectureService,

			IGetGradeLecturesService getGradeLecturesService,
			IGetGradesService getGradesService,
			IGetLecturesService getLecturesService) : base(httpContextAccessor, appSettings)
		{
			_createGradeLectureService = createGradeLectureService;

			_getGradeLecturesService = getGradeLecturesService;
			_getGradesService = getGradesService;
			_getLecturesService = getLecturesService;
		}

		#endregion

		#region Create

		[Route("Add")]
		[HttpGet]
		public ViewResult Add()
		{
			PageHeaderComponentModel pageHeader = _httpContextAccessor.HttpContext.GetPageHeader();

			GetGradesResponseDto gradesResponse = _getGradesService.Query();
			GetLecturesResponseDto lecturesResponse = _getLecturesService.Query();

			GradeLecturesAddViewModel model = new GradeLecturesAddViewModel
			{
				PageHeader = pageHeader,
				Grades = gradesResponse.Grades,
				Lectures = lecturesResponse.Lectures
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
			GetGradeLecturesResponseDto gradeLecturesResponse = _getGradeLecturesService.Query();

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
