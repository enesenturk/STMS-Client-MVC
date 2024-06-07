using NS.STMS.MVC.Services.ExternalServices.STMSServices.Authorization.Commands.AcceptTermsAndConditions.Dtos;

namespace NS.STMS.MVC.Services.ExternalServices.STMSServices.Authorization.Commands.AcceptTermsAndConditions.Managers
{
	public interface IAcceptTermsAndConditionsService
	{

		void Command(AcceptTermsAndConditionsRequestDto request);

	}
}
