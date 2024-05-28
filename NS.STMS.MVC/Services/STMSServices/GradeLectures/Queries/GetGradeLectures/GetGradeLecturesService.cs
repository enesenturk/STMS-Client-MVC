using CMS.Core.Utilities.ExceptionHandling;
using Microsoft.Extensions.Options;
using NS.STMS.CORE.Helpers.RestfulServiceHelpers;
using NS.STMS.CORE.Helpers.RestfulServiceHelpers.Models;
using NS.STMS.MVC.Services.STMSServices.GradeLectures.Constants;
using NS.STMS.MVC.Services.STMSServices.GradeLectures.Queries.GetGradeLectures.Dtos;
using NS.STMS.MVC.Settings;
using System.Net;

namespace NS.STMS.MVC.Services.STMSServices.GradeLectures.Queries.GetGradeLectures
{
	public class GetGradeLecturesService : BaseSTMSService, IGetGradeLecturesService
	{

		#region CTOR

		public GetGradeLecturesService(IOptions<AppSettings> appSettings) : base(appSettings)
		{
		}

		#endregion

		public GetGradeLecturesResponseDto Query()
		{
			string endpoint = $"{_appSettings.STMS_ApiUrl}/{EndpointConstants.GetGradeLectures}";

			RestfulServiceResponseDto response = RestfulServiceHelper.Get(endpoint);

			if (response.StatusCode is HttpStatusCode.OK)
			{
				GetGradeLecturesResponseDto responseModel = STMSResponseHelper.GetObjectFromResponse<GetGradeLecturesResponseDto>(response.Response);

				return responseModel;
			}
			else
			{
				throw new CoreException("An error occurred. Please contact to the system admin.");
			}
		}

	}
}
