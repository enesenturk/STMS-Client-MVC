using AutoMapper;
using CMS.Core.Utilities.ExceptionHandling;
using NS.STMS.MVC.Models;
using NS.STMS.MVC.Models.Account.Authentication;
using NS.STMS.MVC.Services.ExternalServices.STMSServices.Authorization.Queries.Login.Dtos;
using NS.STMS.MVC.Services.InternalServices.StorageServices.Abstract;
using NS.STMS.MVC.Services.InternalServices.StorageServices.Concrete.Cookie.Constants;
using NS.STMS.MVC.Services.InternalServices.StorageServices.Concrete.Cookie.Managers;
using NS.STMS.Resources.Language.Languages;
using System.Net;

namespace NS.STMS.MVC.Extracteds
{
	public class AccountControllerExtracteds
	{

		#region CTOR

		private readonly IMapper _mapper;

		private readonly ILoginUserStorage _loginUserStorage;

		private readonly ICookieService _cookieService;

		public AccountControllerExtracteds(IMapper mapper, ILoginUserStorage loginUserStorage, ICookieService cookieService)
		{
			_mapper = mapper;

			_loginUserStorage = loginUserStorage;

			_cookieService = cookieService;
		}

		#endregion

		internal BaseResponseModel GetLoginResponseDto(TryLoginResponseDto response, LoginRequestModel model)
		{
			if (response.StatusCode == HttpStatusCode.NotFound)
			{
				throw new CoreException(Messages.Wrong_Credentials);
			}
			else if (response.StatusCode == HttpStatusCode.Locked)
			{
				throw new CoreException(Messages.User_Blocked);
			}
			else if ((int)response.StatusCode == 212)
			{
				throw new CoreException(Messages.Please_Verify_Email);
			}
			// successful login
			else if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Found || response.StatusCode == HttpStatusCode.NonAuthoritativeInformation)
			{
				if (response.LoginResponse is null)
					throw new CoreException(Messages.Error_Ocurred);

				_loginUserStorage.SetPreferredDateFormat(response.LoginResponse.PreferredDateFormat);
				_loginUserStorage.SetPreferredNumberFormat(response.LoginResponse.PreferredNumberFormat);
				_loginUserStorage.SetPreferredLanguage(response.LoginResponse.PreferredLanguage);

				AccessTokenModel accessTokenModel = _mapper.Map<AccessTokenModel>(response.LoginResponse);
				accessTokenModel.AcceptedTermsAndConditions = response.StatusCode != HttpStatusCode.Found;
				accessTokenModel.NeedsChangePassword = response.StatusCode == HttpStatusCode.NonAuthoritativeInformation;
				_loginUserStorage.SetAccessToken(accessTokenModel);

				RefreshTokenModel refreshTokenModel = _mapper.Map<RefreshTokenModel>(response.LoginResponse);
				_loginUserStorage.SetRefreshToken(refreshTokenModel);

				if (response.StatusCode == HttpStatusCode.Found)
				{
					_loginUserStorage.SetEncryptedParameter(CookieLoginUserConstants.CookieName_Email, model.Email);

					return new BaseResponseModel
					{
						Type = "TermsAndConditions"
					};
				}
				else if (response.StatusCode == HttpStatusCode.NonAuthoritativeInformation)
				{
					return new BaseResponseModel
					{
						Type = "UpdatePasswordRequired"
					};
				}
				else
				{
					return new BaseResponseModel
					{
					};
				}
			}
			else
			{
				throw new CoreException(Messages.Error_Ocurred);
			}
		}

		internal void AbandonSession() => _cookieService.Remove(".AspNetCore.Session");

	}
}
