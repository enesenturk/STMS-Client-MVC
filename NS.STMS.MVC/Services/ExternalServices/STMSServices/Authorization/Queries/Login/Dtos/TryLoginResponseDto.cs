using System.Net;

namespace NS.STMS.MVC.Services.ExternalServices.STMSServices.Authorization.Queries.Login.Dtos
{
	public class TryLoginResponseDto
	{

		public LoginResponseDto LoginResponse { get; set; }
		public HttpStatusCode StatusCode { get; set; }

	}
}
