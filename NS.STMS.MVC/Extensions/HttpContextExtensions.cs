using NS.STMS.CORE.Helpers.ConvertionHelpers;
using NS.STMS.MVC.Models.ComponentModels.LayoutComponentModels.PageHeaderModels;
using NS.STMS.MVC.Preferences.StructurePreferences;

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

		public static PageHeaderComponentModel GetPageHeader(this HttpContext context, bool includeAddButton = false)
		{
			string path = context.Request.Path.Value;
			string controllerName = context.GetCurrentControllerName();

			string headerText = TextConvertionHelper.PutSpaceWhenUpperCase(controllerName);
			AddButtonComponentModel addButton = GetAddButton(context, path, includeAddButton);
			List<NavBreadcrumbItemComponentModel> breadcrumbs = GetBreadcrumbs(context, path);

			PageHeaderComponentModel pageHeader = new PageHeaderComponentModel
			{
				Text = headerText,
				AddButton = addButton,
				Breadcrumbs = breadcrumbs
			};

			return pageHeader;
		}

		public static string GetViewsFolderPath(this HttpContext context)
		{
			string controllerName = context.GetCurrentControllerName();

			string viewsFolderPath = $"{ViewStructurePreferences.AdminFolderPath}/{controllerName}";

			return viewsFolderPath;
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
					Text = "List",
					Href = path
				});
			}
			else
			{
				breadcrumbs.Add(new NavBreadcrumbItemComponentModel
				{
					Text = "List",
					Href = path.Replace($"/{actionName}", "")
				});

				breadcrumbs.Add(new NavBreadcrumbItemComponentModel
				{
					Text = actionName,
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
					Text = "Add",
					Href = $"{path}/Add"
				};
			}

			return addButton;
		}

		#endregion

	}
}
