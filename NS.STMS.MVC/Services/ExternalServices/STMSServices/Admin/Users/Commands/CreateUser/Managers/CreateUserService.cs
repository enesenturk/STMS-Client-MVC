using CMS.Core.Utilities.ExceptionHandling;
using Microsoft.Extensions.Options;
using NS.STMS.CORE.Helpers.RestfulServiceHelpers.Models;
using NS.STMS.CORE.Helpers.RestfulServiceHelpers;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.Users.Commands.CreateUser.Dtos;
using NS.STMS.MVC.Settings;
using NS.STMS.Resources.Language.Languages;
using System.Net;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.Users.Constants;

namespace NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.Users.Commands.CreateUser.Managers
{
	public class CreateUserService : BaseSTMSService, ICreateUserService
	{

		#region CTOR

		public CreateUserService(IOptions<AppSettings> appSettings) : base(appSettings)
		{
		}

		#endregion

		public void Command(CreateUserRequestDto request)
		{
			string endpoint = $"{_appSettings.STMS_ApiUrl}/{UsersConstants.Post}";

			RestfulServiceResponseDto response = RestfulServiceHelper.Post(endpoint, request);

			if (response.StatusCode is HttpStatusCode.OK)
			{
				object responseModel = STMSResponseHelper.GetObjectFromResponse<object>(response.Response);
			}
			else
			{
				throw new CoreException(Messages.Error_Ocurred);
			}
		}

	}
}
