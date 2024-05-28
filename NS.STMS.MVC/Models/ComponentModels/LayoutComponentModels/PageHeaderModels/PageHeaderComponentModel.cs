namespace NS.STMS.MVC.Models.ComponentModels.LayoutComponentModels.PageHeaderModels
{
	public class PageHeaderComponentModel
	{

		public string Text { get; set; }
		public List<NavBreadcrumbItemComponentModel> Breadcrumbs { get; set; }
		public AddButtonComponentModel AddButton { get; set; }

	}
}
