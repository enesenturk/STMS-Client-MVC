using CMS.Core.Utilities.ExceptionHandling;
using Microsoft.Extensions.Options;
using NS.STMS.CORE.Helpers.RestfulServiceHelpers.Models;
using NS.STMS.CORE.Helpers.RestfulServiceHelpers;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.Users.Queries.GetUsers.Dtos;
using NS.STMS.MVC.Settings;
using NS.STMS.Resources.Language.Languages;
using System.Net;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.Users.Constants;

namespace NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.Users.Queries.GetUsers.Managers
{
	public class GetUsersService : BaseSTMSService, IGetUsersService
	{

		#region CTOR

		public GetUsersService(IOptions<AppSettings> appSettings) : base(appSettings)
		{
		}

		#endregion

		public GetUsersResponseDto Query()
		{
			string endpoint = $"{_appSettings.STMS_ApiUrl}/{UsersConstants.Get}";

			RestfulServiceResponseDto response = RestfulServiceHelper.Get(endpoint);

			if (response.StatusCode is HttpStatusCode.OK)
			{
				GetUsersResponseDto responseModel = STMSResponseHelper.GetObjectFromResponse<GetUsersResponseDto>(response.Response);

				return responseModel;
			}
			else
			{
				throw new CoreException(Messages.Error_Ocurred);
			}
		}

	}
}
