using CMS.Core.Utilities.ExceptionHandling;
using Microsoft.Extensions.Options;
using NS.STMS.CORE.Utilities.ExceptionHandling;
using NS.STMS.MVC.Models;
using NS.STMS.MVC.Settings;
using NS.STMS.Resources.Language.Languages;
using System.Net;

namespace NS.STMS.MVC.Services.ExternalServices.STMSServices
{
	public class BaseSTMSService
	{

		#region CTOR

		public readonly AppSettings _appSettings;

		public BaseSTMSService(IOptions<AppSettings> appSettings)
		{
			_appSettings = appSettings.Value;
		}

		#endregion

		public void HandleResponse(HttpStatusCode statusCode, BaseResponseModel response)
		{
			bool isBusinessException = statusCode is HttpStatusCode.BadRequest || statusCode is HttpStatusCode.UnprocessableEntity;
			bool isUnauthorized = statusCode is HttpStatusCode.Forbidden || statusCode is HttpStatusCode.Unauthorized;

			if (statusCode is HttpStatusCode.OK)
			{
				return;
			}
			else if (isBusinessException)
			{
				throw new CoreException(response.Message);
			}
			else if (isUnauthorized)
			{
				throw new AuthorizationException();
			}
			else
			{
				throw new CoreException(Messages.Error_Ocurred);
			}
		}

	}
}
