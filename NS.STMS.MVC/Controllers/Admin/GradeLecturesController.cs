using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NS.STMS.MVC.Services.STMSServices.GradeLectures.Queries.GetGradeLectures;
using NS.STMS.MVC.Services.STMSServices.GradeLectures.Queries.GetGradeLectures.Dtos;
using NS.STMS.MVC.Settings;
using NS.STMS.MVC.Utility;

namespace NS.STMS.MVC.Controllers.Admin
{

	[Route("Admin/GradeLectures")]
	public class GradeLecturesController : CustomBaseController
	{

		#region CTOR

		private readonly IGetGradeLecturesService _getGradeLecturesService;

		public GradeLecturesController(IHttpContextAccessor httpContextAccessor,
			IOptions<AppSettings> appSettings,
			IGetGradeLecturesService getGradeLecturesService) : base(httpContextAccessor, appSettings)
		{
			_getGradeLecturesService = getGradeLecturesService;
		}

		#endregion

		public PartialViewResult Index()
		{
			GetGradeLecturesResponseDto gradeLecturesResponse = _getGradeLecturesService.Query();

			return PartialView($"{_viewsFolderPath}/_Index.cshtml");
		}

		#region Create

		#endregion

		#region Read

		#endregion

		#region Update

		#endregion

		#region Delete

		#endregion

	}
}
