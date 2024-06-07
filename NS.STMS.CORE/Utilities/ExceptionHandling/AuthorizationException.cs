namespace NS.STMS.CORE.Utilities.ExceptionHandling
{
	public class AuthorizationException : Exception
	{

		public AuthorizationException()
		{

		}

		public AuthorizationException(string message, string code = "")
			: base(message, new Exception($"{code}"))
		{

		}

	}

}
