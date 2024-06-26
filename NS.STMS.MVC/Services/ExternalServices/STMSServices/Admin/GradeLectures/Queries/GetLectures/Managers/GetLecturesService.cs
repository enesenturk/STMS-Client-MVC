﻿using CMS.Core.Utilities.ExceptionHandling;
using Microsoft.Extensions.Options;
using NS.STMS.CORE.Helpers.RestfulServiceHelpers.Models;
using NS.STMS.CORE.Helpers.RestfulServiceHelpers;
using NS.STMS.MVC.Settings;
using System.Net;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.GradeLectures.Constants;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.GradeLectures.Queries.GetLectures.Dtos;
using NS.STMS.Resources.Language.Languages;

namespace NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.GradeLectures.Queries.GetLectures.Managers
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
                throw new CoreException(Messages.Error_Ocurred);
            }
        }

    }
}
