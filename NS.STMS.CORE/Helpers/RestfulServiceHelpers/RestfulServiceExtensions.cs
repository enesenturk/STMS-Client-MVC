using Newtonsoft.Json;
using NS.STMS.CORE.Helpers.RestfulServiceHelpers.Models;
using System.Net.Http;
using System;
using System.Net.Http.Headers;
using System.Text;

namespace NS.STMS.CORE.Helpers.RestfulServiceHelpers
{
	public static class RestfulServiceExtensions
	{

		internal static void InitializeHttpClient(this HttpClient client, string URL)
		{
			client.BaseAddress = new Uri(URL);
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		}

		internal static StringContent GetStringContent(this object dataModel)
		{
			string content = JsonConvert.SerializeObject(dataModel);
			StringContent stringContent = new StringContent(content, Encoding.UTF8, "application/json");

			return stringContent;
		}

		internal static RestfulServiceResponseDto GetResponse(this HttpResponseMessage response)
		{
			string result = response.Content.ReadAsStringAsync().Result;

			return new RestfulServiceResponseDto
			{
				StatusCode = response.StatusCode,
				Response = result
			};
		}

		internal static void AddAll(this HttpRequestHeaders httpRequestHeaders, List<RestfulServiceHeaderDto> headers)
		{
			if (headers is null)
				return;

			foreach (RestfulServiceHeaderDto header in headers)
				httpRequestHeaders.Add(header.Name, header.Value);
		}

	}
}
