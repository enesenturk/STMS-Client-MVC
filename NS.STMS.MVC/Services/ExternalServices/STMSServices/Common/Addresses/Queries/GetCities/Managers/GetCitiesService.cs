using CMS.Core.Utilities.ExceptionHandling;
using Microsoft.Extensions.Options;
using NS.STMS.CORE.Helpers.RestfulServiceHelpers.Models;
using NS.STMS.CORE.Helpers.RestfulServiceHelpers;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Common.Addresses.Queries.GetCities.Dtos;
using NS.STMS.MVC.Settings;
using NS.STMS.Resources.Language.Languages;
using System.Net;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Common.Addresses.Constants;

namespace NS.STMS.MVC.Services.ExternalServices.STMSServices.Common.Addresses.Queries.GetCities.Managers
{
	public class GetCitiesService : BaseSTMSService, IGetCitiesService
	{

		#region CTOR

		public GetCitiesService(IOptions<AppSettings> appSettings) : base(appSettings)
		{
		}

		#endregion

		public GetCitiesResponseModel Query(int countryId)
		{
			string endpoint = $"{_appSettings.STMS_ApiUrl}/{CitiesConstants.Get}/{countryId}";

			RestfulServiceResponseDto response = RestfulServiceHelper.Get(endpoint);

			if (response.StatusCode is HttpStatusCode.OK)
			{
				GetCitiesResponseModel responseModel = STMSResponseHelper.GetObjectFromResponse<GetCitiesResponseModel>(response.Response);

				return responseModel;
			}
			else
			{
				throw new CoreException(Messages.Error_Ocurred);
			}
		}

	}
}
