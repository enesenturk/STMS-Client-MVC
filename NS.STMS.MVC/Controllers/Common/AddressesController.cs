using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NS.STMS.MVC.Models;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Common.Addresses.Queries.GetCities.Dtos;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Common.Addresses.Queries.GetCities.Managers;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Common.Addresses.Queries.GetCounties.Dtos;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Common.Addresses.Queries.GetCounties.Managers;
using NS.STMS.MVC.Settings;
using NS.STMS.MVC.Utility;

namespace NS.STMS.MVC.Controllers.Common
{
	[Route("Common/Address")]
	public class AddressesController : CustomBaseController
	{

		#region CTOR

		private readonly IGetCitiesService _getCitiesService;
		private readonly IGetCountiesService _getCountiesService;

		public AddressesController(
			IGetCitiesService getCitiesService,
			IGetCountiesService getCountiesService,

			IHttpContextAccessor httpContextAccessor, IOptions<AppSettings> appSettings) : base(httpContextAccessor, appSettings)
		{
			_getCitiesService = getCitiesService;
			_getCountiesService = getCountiesService;
		}

		#endregion

		[HttpGet]
		[Route("GetCities/{countryId}")]
		public JsonResult GetCities(int countryId)
		{
			GetCitiesResponseModel response = _getCitiesService.Query(countryId);

			return Json(new BaseResponseModel
			{
				ResponseModel = response
			});
		}

		[HttpGet]
		[Route("GetCounties/{cityId}")]
		public JsonResult GetCounties(int cityId)
		{
			GetCountiesResponseModel response = _getCountiesService.Query(cityId);

			return Json(new BaseResponseModel
			{
				ResponseModel = response
			});
		}

	}
}
