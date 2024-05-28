namespace CMS.Core.Utilities.ExceptionHandling
{
	[Serializable]
	public class AuthorizationException : Exception
	{
		public AuthorizationException()
		{

		}

		public AuthorizationException(string message)
			: base(String.Format(message))
		{

		}
	}
}
