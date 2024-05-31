using Microsoft.AspNetCore.Mvc;
using NS.STMS.MVC.Models;
using NS.STMS.MVC.Models.Account;
using NS.STMS.MVC.Services.InternalServices.StorageServices.Abstract;

namespace NS.STMS.MVC.Controllers
{
	public class AccountController : Controller
	{

		#region CTOR

		private readonly IGlobalizationStorage _globalizationStorage;

		public AccountController(IGlobalizationStorage globalizationStorage)
		{
			_globalizationStorage = globalizationStorage;
		}

		#endregion

		[HttpPost]
		public JsonResult SetLanguage(SetLanguageRequestModel request)
		{
			_globalizationStorage.SetLanguage(request.Language);

			return Json(new BaseResponseModel
			{
				ResponseModel = request
			});
		}

	}
}
