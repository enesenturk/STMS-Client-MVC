namespace NS.STMS.CORE.Helpers.ConvertionHelpers
{
	public class TextConvertionHelper
	{

		public static string PutSpaceWhenUpperCase(string text)
		{
			return string.Concat(text.Select(x => char.IsUpper(x) ? " " + x : x.ToString())).TrimStart();
		}

	}
}
