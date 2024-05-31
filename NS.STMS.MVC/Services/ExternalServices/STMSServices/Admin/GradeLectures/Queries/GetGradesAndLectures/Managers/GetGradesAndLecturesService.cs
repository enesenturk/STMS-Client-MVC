using CMS.Core.Utilities.ExceptionHandling;
using Microsoft.Extensions.Options;
using NS.STMS.CORE.Helpers.RestfulServiceHelpers.Models;
using NS.STMS.CORE.Helpers.RestfulServiceHelpers;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.GradeLectures.Constants;
using NS.STMS.MVC.Settings;
using System.Net;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.GradeLectures.Queries.GetGradesAndLectures.Dtos;
using NS.STMS.Resources.Language.Languages;

namespace NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.GradeLectures.Queries.GetGradesAndLectures.Managers
{
	public class GetGradesAndLecturesService : BaseSTMSService, IGetGradesAndLecturesService
	{

		#region CTOR

		public GetGradesAndLecturesService(IOptions<AppSettings> appSettings) : base(appSettings)
		{
		}

		#endregion

		public GetGradesAndLecturesResponseDto Query()
		{
			string endpoint = $"{_appSettings.STMS_ApiUrl}/{GradesAndLecturesConstants.Get}";

			RestfulServiceResponseDto response = RestfulServiceHelper.Get(endpoint);

			if (response.StatusCode is HttpStatusCode.OK)
			{
				GetGradesAndLecturesResponseDto responseModel = STMSResponseHelper.GetObjectFromResponse<GetGradesAndLecturesResponseDto>(response.Response);

				return responseModel;
			}
			else
			{
				throw new CoreException(Messages.Error_Ocurred);
			}
		}
	}
}
