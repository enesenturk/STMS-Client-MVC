using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NS.STMS.MVC.Extensions;
using NS.STMS.MVC.Extracteds;
using NS.STMS.MVC.Helpers;
using NS.STMS.MVC.Models;
using NS.STMS.MVC.Models.Account;
using NS.STMS.MVC.Models.Account.Authentication;
using NS.STMS.MVC.Models.Account.Preferences;
using NS.STMS.MVC.Models.ComponentModels.LayoutComponentModels.PageHeaderModels;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Authorization.Commands.AcceptTermsAndConditions.Dtos;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Authorization.Commands.AcceptTermsAndConditions.Managers;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Authorization.Queries.Login.Dtos;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Authorization.Queries.Login.Managers;
using NS.STMS.MVC.Services.InternalServices.StorageServices.Abstract;
using NS.STMS.MVC.Settings;
using NS.STMS.MVC.Utility;

namespace NS.STMS.MVC.Controllers
{
	public class AccountController : CustomBaseController
	{

		#region CTOR

		private readonly AccountControllerExtracteds _accountControllerExtracteds;

		private readonly IAcceptTermsAndConditionsService _acceptTermsAndConditionsService;
		private readonly ILoginService _loginService;

		private readonly ILoginUserStorage _loginUserStorage;

		public AccountController(
			AccountControllerExtracteds accountControllerExtracteds,

			ILoginService loginService,
			IAcceptTermsAndConditionsService acceptTermsAndConditionsService,
			ILoginUserStorage loginUserStorage,

			IHttpContextAccessor httpContextAccessor, IMapper mapper, IOptions<AppSettings> appSettings) : base(httpContextAccessor, mapper, appSettings)
		{
			_accountControllerExtracteds = accountControllerExtracteds;
			_acceptTermsAndConditionsService = acceptTermsAndConditionsService;
			_loginService = loginService;

			_loginUserStorage = loginUserStorage;
		}

		#endregion

		#region Globalization

		public ViewResult Globalize()
		{
			return View("Globalize");
		}

		[HttpPost]
		public JsonResult SetDefaultLanguage(SetLanguageRequestModel request)
		{
			_loginUserStorage.SetPreferredLanguage(request.Language);

			return Json(new BaseResponseModel
			{
			});
		}

		#endregion

		#region Login

		[HttpGet]
		public ActionResult Login()
		{
			bool alreadyLoggedIn = _loginUserStorage.IsLoggedIn();

			if (alreadyLoggedIn)
			{
				return RedirectToAction("Index", "Home");
			}
			else
			{
				return View("Login");
			}
		}

		[HttpPost]
		public JsonResult Login(LoginRequestModel model)
		{
			LoginRequestDto request = _mapper.Map<LoginRequestDto>(model);

			TryLoginResponseDto response = _loginService.Query(request);

			BaseResponseModel loginResponse = _accountControllerExtracteds.GetLoginResponseDto(response, model);

			return Json(loginResponse);
		}

		public ActionResult LogOut()
		{
			_loginUserStorage.Clear();
			//_paginationCache.Clear();
			//_navigatedFilterCache.Clear();
			//_imageCache.Clear();
			//_dateTimeFormatter.Clear();
			_accountControllerExtracteds.AbandonSession();

			return RedirectToAction("Globalize", "Account");
		}

		#endregion

		#region Preferences

		public ViewResult Preferences()
		{
			PageHeaderComponentModel pageHeader = _httpContextAccessor.HttpContext.GetPageHeader();

			PreferencesViewModel model = new PreferencesViewModel
			{
				PageHeader = pageHeader,

				PreferredDateFormat = _loginUserStorage.GetPreferredDateFormat(),
				PreferredLanguage = _loginUserStorage.GetPreferredLanguage(),
				PreferredNumberFormat = _loginUserStorage.GetPreferredNumberFormat(),

				SupportedDateFormats = DateFormatSettingsHelper.GetSupportedDateFormatDropdown(),
				SupportedLanguages = LanguageSettingsHelper.GetSupportedLanguageDropdown(),
				SupportedNumberFormats = NumberFormatSettingsHelper.GetSupportedNumberFormatDropdown()
			};

			return View("Preferences", model);
		}

		#endregion

		#region Terms and Conditions

		[HttpGet]
		public ActionResult TermsAndConditions()
		{
			return View("TermsAndConditions");
		}

		[HttpPost]
		public JsonResult AcceptTermsAndConditions()
		{
			string email = _loginUserStorage.GetEmail();

			AcceptTermsAndConditionsRequestDto request = new AcceptTermsAndConditionsRequestDto
			{
				Email = email
			};

			_acceptTermsAndConditionsService.Command(request);

			_loginUserStorage.SetAcceptedTermsAndConditions();

			AccessTokenModel accessToken = _loginUserStorage.GetAccessToken();

			bool UpdatePasswordRequired = accessToken.NeedsChangePassword;

			return Json(new BaseResponseModel
			{
				Type = UpdatePasswordRequired ? "UpdatePasswordRequired" : "S"
			});
		}

		#endregion

		#region Update Password Required

		[HttpGet]
		public ActionResult UpdatePasswordRequired()
		{
			return View("UpdatePasswordRequired");
		}

		#endregion

	}
}
