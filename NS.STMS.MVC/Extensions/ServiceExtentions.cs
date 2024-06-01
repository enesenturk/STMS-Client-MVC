using NS.STMS.Caching.Cachers.Abstract;
using NS.STMS.Caching.Cachers.Concrete.MemoryCache;
using NS.STMS.Caching.Managers.Abstract;
using NS.STMS.Caching.Managers.Concrete;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.GradeLectures.Commands.CreateGradeLecture.Managers;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.GradeLectures.Queries.GetGradeLectures.Managers;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.GradeLectures.Queries.GetGrades.Managers;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.GradeLectures.Queries.GetGradesAndLectures.Managers;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.GradeLectures.Queries.GetLectures.Managers;
using NS.STMS.MVC.Services.InternalServices.StorageServices.Abstract;
using NS.STMS.MVC.Services.InternalServices.StorageServices.Concrete.Cookie;
using NS.STMS.MVC.Services.InternalServices.StorageServices.Concrete.Cookie.Managers;

namespace NS.STMS.MVC.Extensions
{
	public static class ServiceExtentions
	{

		public static void BindCacheServices(this IServiceCollection services)
		{

			services.AddSingleton<ICache, MemoryCacher>();
			services.AddSingleton<ICacheService, CacheManager>();

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

			#endregion

		}

		public static void BindSorageServices(this IServiceCollection services)
		{
			services.AddSingleton<ICookieService, CookieService>();

			services.AddSingleton<IGlobalizationStorage, CookieGlobalizationStorage>();

		}

	}
}
