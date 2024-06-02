using CMS.Core.Utilities.ExceptionHandling;
using Microsoft.Extensions.Options;
using NS.STMS.CORE.Helpers.RestfulServiceHelpers.Models;
using NS.STMS.CORE.Helpers.RestfulServiceHelpers;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Common.Addresses.Constants;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Common.Addresses.Queries.GetCounties.Dtos;
using NS.STMS.MVC.Settings;
using NS.STMS.Resources.Language.Languages;
using System.Net;

namespace NS.STMS.MVC.Services.ExternalServices.STMSServices.Common.Addresses.Queries.GetCounties.Managers
{
	public class GetCountiesService : BaseSTMSService, IGetCountiesService
	{

		#region CTOR

		public GetCountiesService(IOptions<AppSettings> appSettings) : base(appSettings)
		{
		}

		#endregion

		public GetCountiesResponseModel Query(int cityId)
		{
			string endpoint = $"{_appSettings.STMS_ApiUrl}/{CountiesConstants.Get}/{cityId}";

			RestfulServiceResponseDto response = RestfulServiceHelper.Get(endpoint);

			if (response.StatusCode is HttpStatusCode.OK)
			{
				GetCountiesResponseModel responseModel = STMSResponseHelper.GetObjectFromResponse<GetCountiesResponseModel>(response.Response);

				return responseModel;
			}
			else
			{
				throw new CoreException(Messages.Error_Ocurred);
			}
		}
	}
}
