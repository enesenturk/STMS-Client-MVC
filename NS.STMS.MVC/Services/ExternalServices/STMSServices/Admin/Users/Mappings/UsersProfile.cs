using AutoMapper;
using NS.STMS.MVC.Models.Admin.Users;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.Users.Commands.CreateUser.Dtos;

namespace NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.Users.Mappings
{
	public class UsersProfile : Profile
	{

		public UsersProfile()
		{

			CreateMap<AddUserModel, CreateUserRequestDto>()
				.ForMember(dest => dest.GradeId, opt => opt.MapFrom(src => src.Grade))
				.ForMember(dest => dest.SchoolName, opt => opt.MapFrom(src => src.School))
				.ForMember(dest => dest.CountyId, opt => opt.MapFrom(src => src.County));

		}

	}
}
