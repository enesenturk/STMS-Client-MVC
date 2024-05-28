﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NS.STMS.MVC.Extensions;
using NS.STMS.MVC.Settings;

namespace NS.STMS.MVC.Utility
{
	public class CustomBaseController : Controller
	{

		#region CTOR

		private readonly IHttpContextAccessor _httpContextAccessor;

		private readonly AppSettings _appSettings;

		public readonly string _viewsFolderPath;

		public CustomBaseController(IHttpContextAccessor httpContextAccessor, IOptions<AppSettings> appSettings)
		{
			_httpContextAccessor = httpContextAccessor;

			_appSettings = appSettings.Value;

			_viewsFolderPath = _httpContextAccessor.HttpContext.GetViewsFolderPath();
		}

		#endregion

	}
}
