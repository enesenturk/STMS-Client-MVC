using CMS.Core.Utilities.ExceptionHandling;
using Microsoft.Extensions.Options;
using NS.STMS.CORE.Helpers.RestfulServiceHelpers.Models;
using NS.STMS.CORE.Helpers.RestfulServiceHelpers;
using NS.STMS.MVC.Settings;
using System.Net;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.GradeLectures.Constants;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.GradeLectures.Queries.GetGrades.Dtos;
using NS.STMS.Resources.Language.Languages;

namespace NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.GradeLectures.Queries.GetGrades.Managers
{
    public class GetGradesService : BaseSTMSService, IGetGradesService
    {

        #region CTOR

        public GetGradesService(IOptions<AppSettings> appSettings) : base(appSettings)
        {
        }

        #endregion

        public GetGradesResponseDto Query()
        {
            string endpoint = $"{_appSettings.STMS_ApiUrl}/{GradesConstants.Get}";

            RestfulServiceResponseDto response = RestfulServiceHelper.Get(endpoint);

            if (response.StatusCode is HttpStatusCode.OK)
            {
                GetGradesResponseDto responseModel = STMSResponseHelper.GetObjectFromResponse<GetGradesResponseDto>(response.Response);

                return responseModel;
            }
            else
            {
                throw new CoreException(Messages.Error_Ocurred);
            }
        }

    }
}
