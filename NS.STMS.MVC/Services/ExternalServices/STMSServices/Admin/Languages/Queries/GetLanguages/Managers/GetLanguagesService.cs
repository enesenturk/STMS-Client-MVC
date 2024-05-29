using CMS.Core.Utilities.ExceptionHandling;
using Microsoft.Extensions.Options;
using NS.STMS.CORE.Helpers.RestfulServiceHelpers.Models;
using System.Net;
using NS.STMS.CORE.Helpers.RestfulServiceHelpers;
using NS.STMS.MVC.Settings;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.Languages.Constants;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.Languages.Queries.GetLanguages.Dtos;

namespace NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.Languages.Queries.GetLanguages.Managers
{
    public class GetLanguagesService : BaseSTMSService, IGetLanguagesService
    {

        #region CTOR

        public GetLanguagesService(IOptions<AppSettings> appSettings) : base(appSettings)
        {
        }

        #endregion

        public GetLanguagesResponseDto Query()
        {
            string endpoint = $"{_appSettings.STMS_ApiUrl}/{LanguagesConstants.Get}";

            RestfulServiceResponseDto response = RestfulServiceHelper.Get(endpoint);

            if (response.StatusCode is HttpStatusCode.OK)
            {
                GetLanguagesResponseDto responseModel = STMSResponseHelper.GetObjectFromResponse<GetLanguagesResponseDto>(response.Response);

                return responseModel;
            }
            else
            {
                throw new CoreException("An error occurred. Please contact to the system admin.");
            }
        }

    }
}
