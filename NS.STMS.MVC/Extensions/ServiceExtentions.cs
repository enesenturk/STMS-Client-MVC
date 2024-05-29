using NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.GradeLectures.Commands.CreateGradeLecture.Managers;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.GradeLectures.Queries.GetGradeLectures.Managers;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.GradeLectures.Queries.GetGrades.Managers;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.GradeLectures.Queries.GetLectures.Managers;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.Languages.Queries.GetLanguages.Managers;

namespace NS.STMS.MVC.Extensions
{
    public static class ServiceExtentions
	{

		public static void BindSTMSServices(this IServiceCollection services)
		{
			#region Admin

			#region Grade Lectures

			services.AddSingleton<ICreateGradeLectureService, CreateGradeLectureService>();
			services.AddSingleton<IGetGradeLecturesService, GetGradeLecturesService>();
			services.AddSingleton<IGetGradesService, GetGradesService>();
			services.AddSingleton<IGetLecturesService, GetLecturesService>();

			#endregion

			#region Language

			services.AddSingleton<IGetLanguagesService, GetLanguagesService>();

			#endregion

			#endregion

		}

	}
}
