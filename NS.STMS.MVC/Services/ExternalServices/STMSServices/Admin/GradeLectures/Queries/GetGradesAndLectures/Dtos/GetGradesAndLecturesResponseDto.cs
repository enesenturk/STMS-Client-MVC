using NS.STMS.MVC.Models;

namespace NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.GradeLectures.Queries.GetGradesAndLectures.Dtos
{
	public class GetGradesAndLecturesResponseDto
	{

		public List<JSonDto> Grades { get; set; }
		public List<JSonDto> Lectures { get; set; }

	}
}
