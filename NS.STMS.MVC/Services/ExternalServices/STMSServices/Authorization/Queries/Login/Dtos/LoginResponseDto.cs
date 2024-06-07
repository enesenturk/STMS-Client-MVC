namespace NS.STMS.MVC.Services.ExternalServices.STMSServices.Authorization.Queries.Login.Dtos
{
	public class LoginResponseDto
	{

		public string Id { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Email { get; set; }
		public DateOnly DateOfBirth { get; set; }
		public string ImageBase64 { get; set; }

		public string PreferredLanguage { get; set; }
		public string PreferredDateFormat { get; set; }
		public string PreferredNumberFormat { get; set; }

		public StudentLoginResponseDto Student { get; set; }

	}
}