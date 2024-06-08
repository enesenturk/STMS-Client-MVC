using Microsoft.Extensions.Options;
using NS.STMS.CORE.Helpers.RestfulServiceHelpers.Models;
using NS.STMS.CORE.Helpers.RestfulServiceHelpers;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Authorization.Constants;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Authorization.Queries.ForgotPassword.Dtos;
using NS.STMS.MVC.Settings;
using NS.STMS.MVC.Models;

namespace NS.STMS.MVC.Services.ExternalServices.STMSServices.Authorization.Queries.ForgotPassword.Managers
{
	public class ForgotPasswordService : BaseSTMSService, IForgotPasswordService
	{

		#region CTOR

		public ForgotPasswordService(IOptions<AppSettings> appSettings) : base(appSettings)
		{
		}

		#endregion

		public void Query(ForgotPasswordRequestDto request)
		{
			string endpoint = $"{_appSettings.STMS_ApiUrl}/{ForgotPasswordConstants.Post}";

			RestfulServiceResponseDto response = RestfulServiceHelper.Post(endpoint, request);

			BaseResponseModel responseModel = STMSResponseHelper.GetBaseResponseFromResponse(response.Response);

			HandleResponse(response.StatusCode, responseModel);
		}

	}
}
