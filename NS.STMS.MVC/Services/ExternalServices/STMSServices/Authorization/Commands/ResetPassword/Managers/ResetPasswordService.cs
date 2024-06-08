using Microsoft.Extensions.Options;
using NS.STMS.CORE.Helpers.RestfulServiceHelpers.Models;
using NS.STMS.CORE.Helpers.RestfulServiceHelpers;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Authorization.Commands.ResetPassword.Dtos;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Authorization.Constants;
using NS.STMS.MVC.Settings;
using NS.STMS.MVC.Models;

namespace NS.STMS.MVC.Services.ExternalServices.STMSServices.Authorization.Commands.ResetPassword.Managers
{
	public class ResetPasswordService : BaseSTMSService, IResetPasswordService
	{

		#region CTOR

		public ResetPasswordService(IOptions<AppSettings> appSettings) : base(appSettings)
		{
		}

		#endregion

		public void Command(ResetPasswordRequestDto request)
		{
			string endpoint = $"{_appSettings.STMS_ApiUrl}/{ResetPasswordConstants.Put}";

			RestfulServiceResponseDto response = RestfulServiceHelper.Put(endpoint, request);

			BaseResponseModel responseModel = STMSResponseHelper.GetBaseResponseFromResponse(response.Response);

			HandleResponse(response.StatusCode, responseModel);
		}

	}
}
