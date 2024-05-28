using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NS.STMS.MVC.Models.Admin.GradeLectures;
using NS.STMS.MVC.Models.ComponentModels.LayoutComponentModels.PageHeaderModels;
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

		public ViewResult Index()
		{
			GetGradeLecturesResponseDto gradeLecturesResponse = _getGradeLecturesService.Query();

			GradeLecturesViewModel model = new GradeLecturesViewModel
			{
				GradeLecturesDto = gradeLecturesResponse,
				PageHeader = new PageHeaderComponentModel
				{
					Text = "Grade Lectures",
					Breadcrumbs = new List<NavBreadcrumbItemComponentModel>
					{
						new NavBreadcrumbItemComponentModel
						{
							Text = "List",
							Href = "/Admin/GradeLectures"
						}
					},
					AddButton = new AddButtonComponentModel
					{
						Text = "Add",
						Href = "/Admin/GradeLectures/Add"
					}
				}
			};

			return View($"{_viewsFolderPath}/_Index.cshtml", model);
		}

		#region Create

		[Route("Add")]
		public ViewResult Add()
		{
			GradeLecturesAddViewModel model = new GradeLecturesAddViewModel
			{
				PageHeader = new PageHeaderComponentModel
				{
					Text = "Grade Lectures",
					Breadcrumbs = new List<NavBreadcrumbItemComponentModel>
					{
						new NavBreadcrumbItemComponentModel
						{
							Text = "List",
							Href = "/Admin/GradeLectures"
						},
						new NavBreadcrumbItemComponentModel
						{
							Text = "Add",
							Href = "/Admin/GradeLectures/Add"
						},
					}
				}
			};

			return View($"{_viewsFolderPath}/_Add.cshtml", model);
		}

		#endregion

		#region Read



		#endregion

		#region Update

		#endregion

		#region Delete

		#endregion

	}
}
