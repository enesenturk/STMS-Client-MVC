using NS.STMS.MVC.Models;
using NS.STMS.MVC.Services.STMSServices.GradeLectures.Dtos;

namespace NS.STMS.MVC.Services.STMSServices.GradeLectures.Queries.GetGradeLectures.Dtos
{
    public class GetGradeLecturesResponseDto
    {
        public List<JSonDto> Lectures { get; set; }
        public List<JSonDto> Grades { get; set; }

        public List<GradeLectureDto> GradeLectures { get; set; } = new List<GradeLectureDto>();
    }
}
