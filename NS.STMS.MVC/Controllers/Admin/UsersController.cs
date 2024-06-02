using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NS.STMS.MVC.Settings;
using NS.STMS.MVC.Utility;

namespace NS.STMS.MVC.Controllers.Admin
{
	[Route("Admin/Users")]
	public class UsersController : CustomBaseController
	{

		#region CTOR

		private readonly int _countryId = 1;

		public UsersController(IHttpContextAccessor httpContextAccessor,
			IOptions<AppSettings> appSettings
			) : base(httpContextAccessor, appSettings)
		{
		}

		#endregion

	}
}
