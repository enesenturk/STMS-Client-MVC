using CMS.Core.Utilities.ExceptionHandling;
using Microsoft.Extensions.Options;
using NS.STMS.CORE.Helpers.RestfulServiceHelpers.Models;
using NS.STMS.CORE.Helpers.RestfulServiceHelpers;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.Users.Constants;
using NS.STMS.MVC.Settings;
using NS.STMS.Resources.Language.Languages;
using System.Net;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.Users.Queries.GetAddUserOptions.Dtos;

namespace NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.Users.Queries.GetAddUserOptions.Managers
{
	public class GetAddUserOptionsService : BaseSTMSService, IGetAddUserOptionsService
	{

		#region CTOR

		public GetAddUserOptionsService(IOptions<AppSettings> appSettings) : base(appSettings)
		{
		}

		#endregion

		public GetAddUserOptionsResponseDto Query()
		{
			string endpoint = $"{_appSettings.STMS_ApiUrl}/{AddUserOptionsConstants.Get}";

			RestfulServiceResponseDto response = RestfulServiceHelper.Get(endpoint);

			if (response.StatusCode is HttpStatusCode.OK)
			{
				GetAddUserOptionsResponseDto responseModel = STMSResponseHelper.GetObjectFromResponse<GetAddUserOptionsResponseDto>(response.Response);

				return responseModel;
			}
			else
			{
				throw new CoreException(Messages.Error_Ocurred);
			}
		}

	}
}
