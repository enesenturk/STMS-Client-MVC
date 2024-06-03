using AutoMapper;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.GradeLectures.Commands.CreateGradeLecture.Managers;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.GradeLectures.Queries.GetGradeLectures.Managers;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.GradeLectures.Queries.GetGrades.Managers;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.GradeLectures.Queries.GetGradesAndLectures.Managers;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.GradeLectures.Queries.GetLectures.Managers;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.Users.Commands.CreateUser.Managers;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.Users.Mappings;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.Users.Queries.GetAddUserOptions.Managers;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.Users.Queries.GetUsers.Managers;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Common.Addresses.Queries.GetCities.Managers;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Common.Addresses.Queries.GetCounties.Managers;
using NS.STMS.MVC.Services.InternalServices.StorageServices.Abstract;
using NS.STMS.MVC.Services.InternalServices.StorageServices.Concrete.Cookie;
using NS.STMS.MVC.Services.InternalServices.StorageServices.Concrete.Cookie.Managers;

namespace NS.STMS.MVC.Extensions
{
	public static class ServiceExtentions
	{

		public static void BindMapper(this IServiceCollection services)
		{
			// AutoMapper Configurations
			var mapperConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new UsersProfile());
			});

			IMapper mapper = mapperConfig.CreateMapper();
			services.AddSingleton(mapper);
		}

		public static void BindSTMSServices(this IServiceCollection services)
		{

			#region Admin

			#region Grade Lectures

			services.AddSingleton<ICreateGradeLectureService, CreateGradeLectureService>();
			services.AddSingleton<IGetGradeLecturesService, GetGradeLecturesService>();
			services.AddSingleton<IGetGradesAndLecturesService, GetGradesAndLecturesService>();
			services.AddSingleton<IGetGradesService, GetGradesService>();
			services.AddSingleton<IGetLecturesService, GetLecturesService>();

			#endregion

			#region Users

			services.AddSingleton<ICreateUserService, CreateUserService>();
			services.AddSingleton<IGetAddUserOptionsService, GetAddUserOptionsService>();
			services.AddSingleton<IGetUsersService, GetUsersService>();

			#endregion

			#endregion

			#region Common

			#region Address

			services.AddSingleton<IGetCitiesService, GetCitiesService>();
			services.AddSingleton<IGetCountiesService, GetCountiesService>();

			#endregion

			#endregion

		}

		public static void BindSorageServices(this IServiceCollection services)
		{
			services.AddSingleton<ICookieService, CookieService>();

			services.AddSingleton<IGlobalizationStorage, CookieGlobalizationStorage>();

		}

	}
}
