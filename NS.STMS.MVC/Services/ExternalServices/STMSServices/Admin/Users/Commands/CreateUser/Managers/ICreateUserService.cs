using NS.STMS.MVC.Models.Admin.Users;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.Users.Commands.CreateUser.Dtos;

namespace NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.Users.Commands.CreateUser.Managers
{
	public interface ICreateUserService
	{
		void Command(CreateUserRequestDto request);
	}
}
