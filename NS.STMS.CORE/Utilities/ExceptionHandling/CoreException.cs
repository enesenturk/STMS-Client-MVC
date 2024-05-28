namespace CMS.Core.Utilities.ExceptionHandling
{
	public class CoreException : Exception
	{

		public CoreException()
		{

		}

		public CoreException(string message, string code = "")
			: base(message, new Exception($"{code}"))
		{

		}

	}
}
