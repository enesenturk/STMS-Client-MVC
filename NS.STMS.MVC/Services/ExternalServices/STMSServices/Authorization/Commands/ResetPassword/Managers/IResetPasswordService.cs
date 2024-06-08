using NS.STMS.MVC.Services.ExternalServices.STMSServices.Authorization.Commands.ResetPassword.Dtos;

namespace NS.STMS.MVC.Services.ExternalServices.STMSServices.Authorization.Commands.ResetPassword.Managers
{
	public interface IResetPasswordService
	{

		void Command(ResetPasswordRequestDto request);

	}
}
