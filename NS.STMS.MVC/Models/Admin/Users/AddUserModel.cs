namespace NS.STMS.MVC.Models.Admin.Users
{
	public class AddUserModel
	{

		public string Name { get; set; }
		public string Surname { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string ReenterPassword { get; set; }
		public DateTime DateOfBirth { get; set; }

		public int Grade { get; set; }
		public string School { get; set; }

		public int County { get; set; }

	}
}
