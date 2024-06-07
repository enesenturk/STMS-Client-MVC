using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NS.STMS.MVC.Extensions;
using NS.STMS.MVC.Settings;

namespace NS.STMS.MVC.Utility
{
	public class CustomBaseController : Controller
	{

		#region CTOR

		public readonly IHttpContextAccessor _httpContextAccessor;
		public readonly IMapper _mapper;

		public readonly AppSettings _appSettings;
		public readonly string _viewsFolderPath;

		public CustomBaseController(IHttpContextAccessor httpContextAccessor, IMapper mapper, IOptions<AppSettings> appSettings)
		{
			_httpContextAccessor = httpContextAccessor;
			_mapper = mapper;

			_appSettings = appSettings.Value;
			_viewsFolderPath = _httpContextAccessor.HttpContext.GetViewsFolderPath();
		}

		#endregion

	}
}
