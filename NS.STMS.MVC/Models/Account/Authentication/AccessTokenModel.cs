using NS.STMS.MVC.Services.ExternalServices.STMSServices.Authorization.Queries.Login.Dtos;

namespace NS.STMS.MVC.Models.Account.Authentication
{
	public class AccessTokenModel
	{

		public int Id { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Email { get; set; }

		public bool AcceptedTermsAndConditions { get; set; }
		public bool NeedsChangePassword { get; set; }

		public StudentLoginResponseDto Student { get; set; }

		public DateTime ExpiresAt { get; set; }

	}
}
