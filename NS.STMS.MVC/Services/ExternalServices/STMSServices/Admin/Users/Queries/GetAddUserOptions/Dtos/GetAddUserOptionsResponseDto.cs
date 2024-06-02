using NS.STMS.MVC.Models;

namespace NS.STMS.MVC.Services.ExternalServices.STMSServices.Admin.Users.Queries.GetAddUserOptions.Dtos
{
	public class GetAddUserOptionsResponseDto
	{

		public List<JSonDto> Countries { get; set; }
		public List<JSonDto> Grades { get; set; }

	}
}
