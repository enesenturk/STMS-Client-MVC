using NS.STMS.MVC.Services.ExternalServices.STMSServices.Common.Addresses.Queries.GetCities.Dtos;

namespace NS.STMS.MVC.Services.ExternalServices.STMSServices.Common.Addresses.Queries.GetCities.Managers
{
	public interface IGetCitiesService
	{

		GetCitiesResponseModel Query(int countryId);

	}
}
