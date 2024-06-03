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
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.Users.Commands.CreateUser.Dtos;
using AutoMapper;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.Users.Commands.CreateUser.Managers;
using NS.STMS.Resources.Security.Encryption;
using System.Security.Cryptography;

namespace NS.STMS.MVC.Controllers.Admin
{
	[Route("Admin/Users")]
	public class UsersController : CustomBaseController
	{

		#region CTOR

		private readonly ICreateUserService _createUserService;

		private readonly IGetAddUserOptionsService _getAddUserOptionsService;
		private readonly IGetUsersService _getUsersService;

		public UsersController(
			ICreateUserService createUserService,
			IGetAddUserOptionsService getAddUserOptionsService,
			IGetUsersService getUsersService,

			IHttpContextAccessor httpContextAccessor, IMapper mapper, IOptions<AppSettings> appSettings) : base(httpContextAccessor, mapper, appSettings)
		{
			_createUserService = createUserService;
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
			response.Countries.AddSelectOption();
			response.Countries = response.Countries.SetLangaugeTextFromValue().OrderList();

			response.Grades.AddSelectOption();
			response.Grades = response.Grades.SetLangaugeTextFromValue().OrderList();

			AddUserViewModel model = new AddUserViewModel
			{
				PageHeader = pageHeader,
				Countries = response.Countries,
				Grades = response.Grades,
			};

			return View($"{_viewsFolderPath}/_Add.cshtml", model);
		}

		[Route("Add")]
		[HttpPost]
		public JsonResult Add(AddUserModel model)
		{
			CreateUserRequestDto request = _mapper.Map<CreateUserRequestDto>(model);

			request.Password = EncryptionHelper.Encrypt(request.Password, _appSettings.EncryptionKey);

			_createUserService.Command(request);

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
