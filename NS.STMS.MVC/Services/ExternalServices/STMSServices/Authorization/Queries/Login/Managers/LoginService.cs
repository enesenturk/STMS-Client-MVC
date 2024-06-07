using Microsoft.Extensions.Options;
using NS.STMS.CORE.Helpers.RestfulServiceHelpers.Models;
using NS.STMS.CORE.Helpers.RestfulServiceHelpers;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Authorization.Constants;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Authorization.Queries.Login.Dtos;
using NS.STMS.MVC.Settings;
using System.Net;

namespace NS.STMS.MVC.Services.ExternalServices.STMSServices.Authorization.Queries.Login.Managers
{
	public class LoginService : BaseSTMSService, ILoginService
	{

		#region CTOR

		public LoginService(IOptions<AppSettings> appSettings) : base(appSettings)
		{
		}

		#endregion

		public TryLoginResponseDto Query(LoginRequestDto request)
		{
			string endpoint = $"{_appSettings.STMS_ApiUrl}/{LoginConstants.Post}";

			RestfulServiceResponseDto response = RestfulServiceHelper.Post(endpoint, request);

			TryLoginResponseDto responseDto = new TryLoginResponseDto
			{
				StatusCode = response.StatusCode
			};

			if (response.StatusCode == HttpStatusCode.OK || (int)response.StatusCode == 302 || response.StatusCode == HttpStatusCode.NonAuthoritativeInformation)
			{
				LoginResponseDto responseModel = STMSResponseHelper.GetObjectFromResponse<LoginResponseDto>(response.Response);

				responseDto.LoginResponse = responseModel;

				return responseDto;
			}
			else
			{
				return responseDto;
			}
		}

	}
}
