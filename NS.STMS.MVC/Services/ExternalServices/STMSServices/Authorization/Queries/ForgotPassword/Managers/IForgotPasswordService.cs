using NS.STMS.MVC.Services.ExternalServices.STMSServices.Authorization.Queries.ForgotPassword.Dtos;

namespace NS.STMS.MVC.Services.ExternalServices.STMSServices.Authorization.Queries.ForgotPassword.Managers
{
	public interface IForgotPasswordService
	{

		void Query(ForgotPasswordRequestDto request);

	}
}
