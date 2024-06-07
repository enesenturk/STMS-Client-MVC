using CMS.Core.Utilities.ExceptionHandling;
using Microsoft.Extensions.Options;
using NS.STMS.CORE.Helpers.RestfulServiceHelpers.Models;
using NS.STMS.CORE.Helpers.RestfulServiceHelpers;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Authorization.Commands.AcceptTermsAndConditions.Dtos;
using NS.STMS.MVC.Settings;
using NS.STMS.Resources.Language.Languages;
using System.Net;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Authorization.Constants;

namespace NS.STMS.MVC.Services.ExternalServices.STMSServices.Authorization.Commands.AcceptTermsAndConditions.Managers
{
	public class AcceptTermsAndConditionsService : BaseSTMSService, IAcceptTermsAndConditionsService
	{

		#region CTOR

		public AcceptTermsAndConditionsService(IOptions<AppSettings> appSettings) : base(appSettings)
		{
		}

		#endregion

		public void Command(AcceptTermsAndConditionsRequestDto request)
		{
			string endpoint = $"{_appSettings.STMS_ApiUrl}/{AcceptTermsAndConditionsConstants.Put}";

			RestfulServiceResponseDto response = RestfulServiceHelper.Put(endpoint, request);

			if (response.StatusCode is HttpStatusCode.OK)
			{
				//object responseModel = STMSResponseHelper.GetObjectFromResponse<object>(response.Response);
			}
			else
			{
				throw new CoreException(Messages.Error_Ocurred);
			}
		}

	}
}
