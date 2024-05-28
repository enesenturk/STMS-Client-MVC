using NS.STMS.MVC.Services.STMSServices.GradeLectures.Queries.GetGradeLectures;

namespace NS.STMS.MVC.Extensions
{
    public static class ServiceExtentions
	{

		public static void BindSTMSServices(this IServiceCollection services)
		{
			services.AddSingleton<IGetGradeLecturesService, GetGradeLecturesService>();
		}

	}
}
