using NS.STMS.MVC.Models;
using NS.STMS.MVC.Models.Admin.GradeLectures;

namespace NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.GradeLectures.Queries.GetGradeLectures.Dtos
{
    public class GetGradeLecturesResponseDto
    {
        public List<JSonDto> Lectures { get; set; }
        public List<JSonDto> Grades { get; set; }

        public List<GradeLectureModel> GradeLectures { get; set; } = new List<GradeLectureModel>();
    }
}
