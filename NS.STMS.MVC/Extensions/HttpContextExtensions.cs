using NS.STMS.CORE.Helpers.ConvertionHelpers;
using NS.STMS.MVC.Models.ComponentModels.LayoutComponentModels.PageHeaderModels;
using NS.STMS.MVC.Preferences.StructurePreferences;
using NS.STMS.Resources.Language.Helpers;
using NS.STMS.Resources.Language.Languages;

namespace NS.STMS.MVC.Extensions
{
	public static class HttpContextExtensions
	{

		public static string GetCurrentActionName(this HttpContext context)
		{
			string actionName = context.GetRouteValue("action").ToString();

			return actionName;
		}

		public static string GetCurrentControllerName(this HttpContext context)
		{
			string controllerName = context.GetRouteValue("controller").ToString();

			return controllerName;
		}

		public static string GetCurrentPath(this HttpContext context)
		{
			string path = context.Request.Path.Value;

			return path;
		}

		public static PageHeaderComponentModel GetPageHeader(this HttpContext context, bool includeAddButton = false)
		{
			string path = context.GetCurrentPath();
			string controllerName = context.GetCurrentControllerName();

			string headerText = TextConvertionHelper.PutSpaceWhenUpperCase(controllerName);
			AddButtonComponentModel addButton = GetAddButton(context, path, includeAddButton);
			List<NavBreadcrumbItemComponentModel> breadcrumbs = GetBreadcrumbs(context, path);

			PageHeaderComponentModel pageHeader = new PageHeaderComponentModel
			{
				Text = LanguageHelper.GetLanguageByKey(headerText),
				AddButton = addButton,
				Breadcrumbs = breadcrumbs
			};

			return pageHeader;
		}

		public static string GetViewsFolderPath(this HttpContext context)
		{
			string path = context.GetCurrentPath();
			string actionName = context.GetCurrentActionName();

			if (actionName is "Index")
			{
				string viewsFolderPath = $"{ViewStructurePreferences.ViewsFolderPath}{path}";

				return viewsFolderPath;
			}
			else
			{
				string folderPath = path.Replace($"/{actionName}", "");

				string viewsFolderPath = $"{ViewStructurePreferences.ViewsFolderPath}{folderPath}";

				return viewsFolderPath;
			}
		}

		#region extracted methods 

		private static List<NavBreadcrumbItemComponentModel> GetBreadcrumbs(HttpContext context, string path)
		{
			string actionName = context.GetCurrentActionName();

			List<NavBreadcrumbItemComponentModel> breadcrumbs = new List<NavBreadcrumbItemComponentModel>();

			if (actionName is "Index")
			{
				breadcrumbs.Add(new NavBreadcrumbItemComponentModel
				{
					Text = Messages.List,
					Href = path
				});
			}
			else
			{
				breadcrumbs.Add(new NavBreadcrumbItemComponentModel
				{
					Text = Messages.List,
					Href = path.Replace($"/{actionName}", "")
				});

				breadcrumbs.Add(new NavBreadcrumbItemComponentModel
				{
					Text = LanguageHelper.GetLanguageByKey(actionName),
					Href = path
				});
			}

			return breadcrumbs;
		}

		private static AddButtonComponentModel GetAddButton(HttpContext context, string path, bool includeAddButton)
		{
			AddButtonComponentModel addButton = null;
			if (includeAddButton)
			{
				addButton = new AddButtonComponentModel
				{
					Text = Messages.Add,
					Href = $"{path}/Add"
				};
			}

			return addButton;
		}

		#endregion

	}
}
