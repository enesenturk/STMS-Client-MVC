using NS.STMS.MVC.Models.Account.Authentication;

namespace NS.STMS.MVC.Services.InternalServices.StorageServices.Abstract
{
	public interface ILoginUserStorage
	{

		void Clear();

		#region AccessToken

		AccessTokenModel GetAccessToken();

		void SetAccessToken(AccessTokenModel accessTokenModel);
		void SetAcceptedTermsAndConditions();
		void SetNeedsChangePassword();

		bool IsLoggedIn();
		string GetFullName(AccessTokenModel ticket = null);
		int GetId(AccessTokenModel ticket = null);

		#endregion

		#region Date Format

		void SetPreferredDateFormat(string language);
		string GetPreferredDateFormat();

		#endregion

		#region Email

		void SetEmail(string email);
		string GetEmail();

		#endregion

		#region Language

		void SetPreferredLanguage(string language);
		string GetPreferredLanguage();

		#endregion

		#region Number Format

		void SetPreferredNumberFormat(string language);
		string GetPreferredNumberFormat();

		#endregion

		#region Refresh Token

		RefreshTokenModel GetRefreshToken();
		void SetRefreshToken(RefreshTokenModel refreshTokenModel);

		#endregion

	}
}
