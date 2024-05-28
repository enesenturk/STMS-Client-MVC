using CMS.Core.Utilities.ExceptionHandling;
using Newtonsoft.Json.Linq;
using NS.STMS.MVC.Models;

namespace NS.STMS.MVC.Services.STMSServices
{
	public class STMSResponseHelper
	{

		internal static T GetObjectFromResponse<T>(string response)
		{
			BaseResponseModel baseResponse = JObject.Parse(response).ToObject<BaseResponseModel>();

			if (baseResponse.Type is "S")
			{
				T responseModel = ((JToken)baseResponse.ResponseModel).ToObject<T>();

				return responseModel;
			}
			else
			{
				throw new CoreException("An error occurred. Please contact to the system admin.");
			}
		}

	}
}
