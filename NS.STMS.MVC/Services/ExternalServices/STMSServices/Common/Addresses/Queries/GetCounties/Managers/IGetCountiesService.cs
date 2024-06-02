using NS.STMS.MVC.Services.ExternalServices.STMSServices.Common.Addresses.Queries.GetCounties.Dtos;

namespace NS.STMS.MVC.Services.ExternalServices.STMSServices.Common.Addresses.Queries.GetCounties.Managers
{
	public interface IGetCountiesService
	{

		GetCountiesResponseModel Query(int cityId);

	}
}
