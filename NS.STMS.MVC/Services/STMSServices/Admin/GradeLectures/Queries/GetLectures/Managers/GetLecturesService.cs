using CMS.Core.Utilities.ExceptionHandling;
using Microsoft.Extensions.Options;
using NS.STMS.CORE.Helpers.RestfulServiceHelpers.Models;
using NS.STMS.CORE.Helpers.RestfulServiceHelpers;
using NS.STMS.MVC.Services.STMSServices.Admin.GradeLectures.Constants;
using NS.STMS.MVC.Services.STMSServices.Admin.GradeLectures.Queries.GetLectures.Dtos;
using NS.STMS.MVC.Settings;
using System.Net;

namespace NS.STMS.MVC.Services.STMSServices.Admin.GradeLectures.Queries.GetLectures.Managers
{
	public class GetLecturesService : BaseSTMSService, IGetLecturesService
	{

		#region CTOR

		public GetLecturesService(IOptions<AppSettings> appSettings) : base(appSettings)
		{
		}

		#endregion

		public GetLecturesResponseDto Query()
		{
			string endpoint = $"{_appSettings.STMS_ApiUrl}/{LecturesConstants.Get}";

			RestfulServiceResponseDto response = RestfulServiceHelper.Get(endpoint);

			if (response.StatusCode is HttpStatusCode.OK)
			{
				GetLecturesResponseDto responseModel = STMSResponseHelper.GetObjectFromResponse<GetLecturesResponseDto>(response.Response);

				return responseModel;
			}
			else
			{
				throw new CoreException("An error occurred. Please contact to the system admin.");
			}
		}

	}
}
