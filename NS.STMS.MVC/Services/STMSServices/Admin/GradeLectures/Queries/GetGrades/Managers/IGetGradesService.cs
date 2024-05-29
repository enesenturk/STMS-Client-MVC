using NS.STMS.MVC.Services.STMSServices.Admin.GradeLectures.Queries.GetGradeLectures.Dtos;
using NS.STMS.MVC.Services.STMSServices.Admin.GradeLectures.Queries.GetGrades.Dtos;

namespace NS.STMS.MVC.Services.STMSServices.Admin.GradeLectures.Queries.GetGrades.Managers
{
	public interface IGetGradesService
	{

		GetGradesResponseDto Query();

	}
}
