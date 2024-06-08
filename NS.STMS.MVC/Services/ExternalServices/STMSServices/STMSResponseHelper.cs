using CMS.Core.Utilities.ExceptionHandling;
using Newtonsoft.Json.Linq;
using NS.STMS.MVC.Models;
using NS.STMS.Resources.Language.Languages;

namespace NS.STMS.MVC.Services.ExternalServices.STMSServices
{
	public class STMSResponseHelper
	{

		internal static T GetObjectFromResponse<T>(string response)
		{
			BaseResponseModel baseResponse = JObject.Parse(response).ToObject<BaseResponseModel>();

			if (baseResponse.Type is "S")
			{
				if (baseResponse.ResponseModel is null)
					return default;

				T responseModel = ((JToken)baseResponse.ResponseModel).ToObject<T>();

				return responseModel;
			}
			else
			{
				throw new CoreException(Messages.Error_Ocurred);
			}
		}

		internal static BaseResponseModel GetBaseResponseFromResponse(string response)
		{
			BaseResponseModel baseResponse = JObject.Parse(response).ToObject<BaseResponseModel>();

			return baseResponse;
		}

	}
}
