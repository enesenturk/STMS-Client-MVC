using Microsoft.AspNetCore.Mvc;

namespace NS.STMS.MVC.Controllers
{
	public class HomeController : Controller
	{

		#region CTOR

		private readonly ILogger<HomeController> _logger;
		
		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		#endregion

		public ViewResult Index()
		{
			return View();
		}

	}
}