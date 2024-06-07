using AutoMapper;
using NS.STMS.MVC.Models.Account.Authentication;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Authorization.Queries.Login.Dtos;

namespace NS.STMS.MVC.Services.ExternalServices.STMSServices.Authorization.Mappings
{
	public class LoginProfile : Profile
	{

		public LoginProfile()
		{

			CreateMap<LoginRequestModel, LoginRequestDto>();

		}

	}
}
