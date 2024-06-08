using AutoMapper;
using NS.STMS.MVC.Models.Account.Authentication;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Authorization.Commands.ResetPassword.Dtos;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Authorization.Queries.ForgotPassword.Dtos;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Authorization.Queries.Login.Dtos;

namespace NS.STMS.MVC.Mappings
{
	public class AuthorizationProfile : Profile
	{

		public AuthorizationProfile()
		{

			CreateMap<ForgotPasswordRequestModel, ForgotPasswordRequestDto>();
			CreateMap<ResetPasswordRequestModel, ResetPasswordRequestDto>();

			CreateMap<LoginResponseDto, AccessTokenModel>();
			CreateMap<LoginResponseDto, RefreshTokenModel>();

		}

	}
}
