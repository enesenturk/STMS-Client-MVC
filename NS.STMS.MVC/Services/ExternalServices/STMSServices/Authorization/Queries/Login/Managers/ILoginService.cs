using NS.STMS.MVC.Services.ExternalServices.STMSServices.Authorization.Queries.Login.Dtos;

namespace NS.STMS.MVC.Services.ExternalServices.STMSServices.Authorization.Queries.Login.Managers
{
	public interface ILoginService
	{

		TryLoginResponseDto Query(LoginRequestDto request);

	}
}
