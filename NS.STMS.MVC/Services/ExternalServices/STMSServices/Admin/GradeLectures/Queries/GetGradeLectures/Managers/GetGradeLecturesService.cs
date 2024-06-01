using CMS.Core.Utilities.ExceptionHandling;
using Microsoft.Extensions.Options;
using NS.STMS.CORE.Helpers.RestfulServiceHelpers;
using NS.STMS.CORE.Helpers.RestfulServiceHelpers.Models;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.GradeLectures.Constants;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.GradeLectures.Queries.GetGradeLectures.Dtos;
using NS.STMS.MVC.Settings;
using NS.STMS.Resources.Language.Languages;
using System.Net;

namespace NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.GradeLectures.Queries.GetGradeLectures.Managers
{
	public class GetGradeLecturesService : BaseSTMSService, IGetGradeLecturesService
	{

		#region CTOR

		public GetGradeLecturesService(IOptions<AppSettings> appSettings) : base(appSettings)
		{
		}

		#endregion

		public GetGradeLecturesResponseDto Query(int countryId)
		{
			string endpoint = $"{_appSettings.STMS_ApiUrl}/{GradeLecturesConstants.Get}/{countryId}";

			RestfulServiceResponseDto response = RestfulServiceHelper.Get(endpoint);

			if (response.StatusCode is HttpStatusCode.OK)
			{
				GetGradeLecturesResponseDto responseModel = STMSResponseHelper.GetObjectFromResponse<GetGradeLecturesResponseDto>(response.Response);

				return responseModel;
			}
			else
			{
				throw new CoreException(Messages.Error_Ocurred);
			}
		}

	}
}
