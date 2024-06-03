using CMS.Core.Utilities.ExceptionHandling;
using Microsoft.Extensions.Options;
using NS.STMS.CORE.Helpers.RestfulServiceHelpers.Models;
using NS.STMS.CORE.Helpers.RestfulServiceHelpers;
using NS.STMS.MVC.Settings;
using System.Net;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.GradeLectures.Commands.CreateGradeLecture.Dtos;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.GradeLectures.Constants;
using NS.STMS.Resources.Language.Languages;

namespace NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.GradeLectures.Commands.CreateGradeLecture.Managers
{
	public class CreateGradeLectureService : BaseSTMSService, ICreateGradeLectureService
	{

		#region CTOR

		public CreateGradeLectureService(IOptions<AppSettings> appSettings) : base(appSettings)
		{
		}

		#endregion

		public void Command(CreateGradeLectureRequestDto request)
		{
			string endpoint = $"{_appSettings.STMS_ApiUrl}/{GradeLecturesConstants.Post}";

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
