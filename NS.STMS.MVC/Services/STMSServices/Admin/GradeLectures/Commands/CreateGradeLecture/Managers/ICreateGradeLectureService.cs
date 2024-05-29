using NS.STMS.MVC.Services.STMSServices.Admin.GradeLectures.Commands.CreateGradeLecture.Dtos;

namespace NS.STMS.MVC.Services.STMSServices.Admin.GradeLectures.Commands.CreateGradeLecture.Managers
{
    public interface ICreateGradeLectureService
    {

        void Command(CreateGradeLectureRequestDto request);

    }
}
