namespace NS.STMS.MVC.Services.ExternalServices.STMSServices.Authorization.Commands.ResetPassword.Dtos
{
	public class ResetPasswordRequestDto
	{

		public string Password { get; set; }
		public Guid Token { get; set; }

	}
}
