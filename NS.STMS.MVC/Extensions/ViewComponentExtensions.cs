using NS.STMS.MVC.Preferences.StructurePreferences;

namespace NS.STMS.MVC.Extensions
{
	public static class ViewComponentExtensions
	{

		public static string GetViewComponentPath(this Type componentType)
		{
			string componentFullName = componentType.FullName.Split("ViewComponents")[1];

			string componentPath = componentFullName.Replace(".", "/").Replace("ViewComponent", "");

			return $"{ViewStructurePreferences.ViewComponentsFolderPath}{componentPath}/Default.cshtml";
		}

	}
}
