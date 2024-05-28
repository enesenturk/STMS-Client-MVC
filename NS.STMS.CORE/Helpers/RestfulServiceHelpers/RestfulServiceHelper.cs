using Newtonsoft.Json;
using NS.STMS.CORE.Helpers.RestfulServiceHelpers.Models;
using System.Net.Http.Headers;
using System.Text;

namespace NS.STMS.CORE.Helpers.RestfulServiceHelpers
{
	public class RestfulServiceHelper
	{

		public static async Task<RestfulServiceResponseDto> Delete(string URL, object dataModel, List<RestfulServiceHeaderDto> headers = null)
		{
			using (HttpClient client = new HttpClient())
			{
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				foreach (RestfulServiceHeaderDto header in headers)
					client.DefaultRequestHeaders.Add(header.Name, header.Value);

				StringContent stringContent = null;

				if (dataModel is not null)
				{
					string content = JsonConvert.SerializeObject(dataModel);
					stringContent = new StringContent(content, Encoding.UTF8, "application/json");
				}

				HttpRequestMessage request = new HttpRequestMessage
				{
					Method = HttpMethod.Delete,
					RequestUri = new Uri(URL),
					Content = stringContent
				};

				HttpResponseMessage response = await client.SendAsync(request);
				string result = response.Content.ReadAsStringAsync().Result;

				return new RestfulServiceResponseDto
				{
					Response = result,
					StatusCode = response.StatusCode
				};
			}
		}

		public static RestfulServiceResponseDto Get(string URL, string parameters = null, List<RestfulServiceHeaderDto> headers = null)
		{
			using (HttpClient client = new HttpClient())
			{
				client.InitializeHttpClient(URL);

				client.DefaultRequestHeaders.AddAll(headers);

				RestfulServiceResponseDto response = client.GetAsync(parameters).Result.GetResponse();

				return response;
			}
		}

		public static RestfulServiceResponseDto Post(string URL, object dataModel, List<RestfulServiceHeaderDto> headers = null)
		{
			using (HttpClient client = new HttpClient())
			{
				client.InitializeHttpClient(URL);

				client.DefaultRequestHeaders.AddAll(headers);

				StringContent stringContent = dataModel.GetStringContent();

				RestfulServiceResponseDto response = client.PostAsync(URL, stringContent).Result.GetResponse();

				return response;
			}
		}

		public static RestfulServiceResponseDto Put(string URL, object dataModel, List<RestfulServiceHeaderDto> headers = null)
		{
			using (HttpClient client = new HttpClient())
			{
				client.InitializeHttpClient(URL);

				client.DefaultRequestHeaders.AddAll(headers);

				StringContent stringContent = dataModel.GetStringContent();

				RestfulServiceResponseDto response = client.PutAsync(URL, stringContent).Result.GetResponse();

				return response;
			}
		}

	}
}
