using Microsoft.AspNetCore.Localization;
using Newtonsoft.Json;
using NS.STMS.CORE.Helpers;
using NS.STMS.CORE.Utilities.ExceptionHandling;
using NS.STMS.MVC.Helpers;
using NS.STMS.MVC.Models.Account.Authentication;
using NS.STMS.MVC.Services.InternalServices.StorageServices.Abstract;
using NS.STMS.MVC.Services.InternalServices.StorageServices.Concrete.Cookie.Constants;
using NS.STMS.MVC.Services.InternalServices.StorageServices.Concrete.Cookie.Dtos;
using NS.STMS.MVC.Services.InternalServices.StorageServices.Concrete.Cookie.Extensions;
using NS.STMS.MVC.Services.InternalServices.StorageServices.Concrete.Cookie.Managers;
using NS.STMS.MVC.Services.InternalServices.StorageServices.Concrete.Cookie.Preferences;
using NS.STMS.Resources.Security.Encryption;

namespace NS.STMS.MVC.Services.InternalServices.StorageServices.Concrete.Cookie
{
	public class CookieLoginUserStorage : ILoginUserStorage
	{

		#region CTOR

		private ICookieService _cookieService;

		public CookieLoginUserStorage(ICookieService cookieService)
		{
			_cookieService = cookieService;
		}

		#endregion

		public void Clear() => _cookieService.Clear<CookieLoginUserConstants>();

		#region AccessToken

		public AccessTokenModel GetAccessToken()
		{
			string accessToken = _cookieService.Get(CookieLoginUserConstants.CookieName_AccessToken);

			if (string.IsNullOrEmpty(accessToken))
				return null;

			try
			{
				string accessTokenSerialized = EncryptionHelper.Decrypt(accessToken, CookieLoginUserConstants.EncrtyptionKey);

				AccessTokenModel accessTokenModel = JsonConvert.DeserializeObject<AccessTokenModel>(accessTokenSerialized);

				return accessTokenModel;
			}
			catch (Exception e)
			{
				throw new AuthorizationException();
			}
		}

		public void SetAccessToken(AccessTokenModel accessTokenModel)
		{
			accessTokenModel.ExpiresAt = DateTimeHelper.GetNowPlusMinutes(CookieTimeoutPreferences.AccessTokenTimeoutMinutes);

			string accessTokenSerialized = JsonConvert.SerializeObject(accessTokenModel);
			string accessToken = EncryptionHelper.Encrypt(accessTokenSerialized, CookieLoginUserConstants.EncrtyptionKey);

			_cookieService.Set(new CookieModel
			{
				key = CookieLoginUserConstants.CookieName_AccessToken,
				value = accessToken,
				httpOnly = true,
				expire = DateTimeHelper.GetNowPlusHours(CookieTimeoutPreferences.NonSensitiveTimeoutDays)
			});
		}

		public void SetAcceptedTermsAndConditions()
		{
			AccessTokenModel ticket = GetAccessToken();

			if (ticket is null)
				throw new AuthorizationException();

			ticket.AcceptedTermsAndConditions = true;

			SetAccessToken(ticket);
		}

		public void SetNeedsChangePassword()
		{
			AccessTokenModel ticket = GetAccessToken();

			if (ticket is null)
				throw new AuthorizationException();

			ticket.NeedsChangePassword = false;

			SetAccessToken(ticket);
		}

		public bool IsLoggedIn()
		{
			AccessTokenModel ticket = GetAccessToken();

			if (ticket is null)
				return false;

			return ticket.AcceptedTermsAndConditions && !ticket.NeedsChangePassword;
		}

		public string GetFullName(AccessTokenModel ticket = null)
		{
			if (ticket is null)
				ticket = GetAccessToken();

			if (ticket is null)
				throw new AuthorizationException();

			return $"{ticket.Name} {ticket.Surname}";
		}

		public int GetId(AccessTokenModel ticket = null)
		{
			if (ticket is null)
				ticket = GetAccessToken();

			if (ticket is null)
				throw new AuthorizationException();

			return ticket.Id;
		}

		#endregion

		#region Date Format

		public void SetPreferredDateFormat(string dateFormat)
		{
			string supportedDateFormat = DateFormatSettingsHelper.GetSupportedDateFormat(dateFormat);

			_cookieService.Set(new CookieModel
			{
				key = CookieLoginUserConstants.CookieName_DateFormat,
				value = supportedDateFormat,
				httpOnly = true,
				expire = DateTimeHelper.GetNowPlusDays(CookieTimeoutPreferences.NonSensitiveTimeoutDays)
			});
		}

		public string GetPreferredDateFormat()
		{
			return _cookieService.Get(CookieLoginUserConstants.CookieName_DateFormat);
		}

		#endregion

		#region Email

		public void DeleteEncryptedParameter(string name)
		{
			_cookieService.Remove(name);
		}

		public string GetEncryptedParameter(string name)
		{
			string parameterEncrypted = _cookieService.Get(name);

			if (string.IsNullOrEmpty(parameterEncrypted))
				return null;

			string parameter = EncryptionHelper.Decrypt(parameterEncrypted, CookieLoginUserConstants.EncrtyptionKey);

			return parameter;
		}

		public void SetEncryptedParameter(string name, string parameter)
		{
			string parameterEncrypted = EncryptionHelper.Encrypt(parameter, CookieLoginUserConstants.EncrtyptionKey);

			_cookieService.Set(new CookieModel
			{
				key = name,
				value = parameterEncrypted,
				httpOnly = true,
				expire = DateTimeHelper.GetNowPlusDays(CookieTimeoutPreferences.NonSensitiveTimeoutDays)
			});
		}

		#endregion

		#region Language

		public void SetPreferredLanguage(string language)
		{
			string supportedLanguage = LanguageSettingsHelper.GetSupportedLanguage(language);

			_cookieService.Set(new CookieModel
			{
				key = CookieLoginUserConstants.CookieName_Language,
				value = supportedLanguage,
				httpOnly = true,
				expire = DateTimeHelper.GetNowPlusDays(CookieTimeoutPreferences.NonSensitiveTimeoutDays)
			});

			_cookieService.Set(new CookieModel
			{
				key = CookieRequestCultureProvider.DefaultCookieName,
				value = CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(supportedLanguage)),
				httpOnly = true,
				expire = DateTimeHelper.GetNowPlusDays(CookieTimeoutPreferences.NonSensitiveTimeoutDays)
			});
		}

		public string GetPreferredLanguage()
		{
			return _cookieService.Get(CookieLoginUserConstants.CookieName_Language);
		}

		#endregion

		#region Number Format

		public void SetPreferredNumberFormat(string numberFormat)
		{
			string supportedNumberFormat = NumberFormatSettingsHelper.GetSupportedNumberFormat(numberFormat);

			_cookieService.Set(new CookieModel
			{
				key = CookieLoginUserConstants.CookieName_NumberFormat,
				value = supportedNumberFormat,
				httpOnly = true,
				expire = DateTimeHelper.GetNowPlusDays(CookieTimeoutPreferences.NonSensitiveTimeoutDays)
			});
		}

		public string GetPreferredNumberFormat()
		{
			return _cookieService.Get(CookieLoginUserConstants.CookieName_NumberFormat);
		}

		#endregion

		#region Refresh Token

		public RefreshTokenModel GetRefreshToken()
		{
			string refreshToken = _cookieService.Get(CookieLoginUserConstants.CookieName_RefreshToken);

			if (string.IsNullOrEmpty(refreshToken))
				return null;

			try
			{
				string refreshTokenSerialized = EncryptionHelper.Decrypt(refreshToken, CookieLoginUserConstants.RefreshTokenEncrtyptionKey);

				RefreshTokenModel refreshTokenModel = JsonConvert.DeserializeObject<RefreshTokenModel>(refreshTokenSerialized);

				return refreshTokenModel;
			}
			catch (Exception e)
			{
				throw new AuthorizationException();
			}
		}

		public void SetRefreshToken(RefreshTokenModel refreshTokenModel)
		{
			refreshTokenModel.ExpiresAt = DateTimeHelper.GetNowPlusDays(CookieTimeoutPreferences.RefreshTokenTimeoutDays);

			string refreshTokenSerialized = JsonConvert.SerializeObject(refreshTokenModel);
			string refreshToken = EncryptionHelper.Encrypt(refreshTokenSerialized, CookieLoginUserConstants.RefreshTokenEncrtyptionKey);

			_cookieService.Set(new CookieModel
			{
				key = CookieLoginUserConstants.CookieName_RefreshToken,
				value = refreshToken,
				httpOnly = true,
				expire = DateTimeHelper.GetNowPlusHours(CookieTimeoutPreferences.NonSensitiveTimeoutDays)
			});
		}

		#endregion

	}
}
