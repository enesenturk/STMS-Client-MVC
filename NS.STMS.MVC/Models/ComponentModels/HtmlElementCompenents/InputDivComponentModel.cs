namespace NS.STMS.MVC.Models.ComponentModels.HtmlElementCompenents
{
	public class InputDivComponentModel
	{

		public string _key { get; set; }
		public string _value { get; set; }

		public string Id { get; set; }
		public string Type { get; set; }
		public string ContainerClasses { get; set; }
		public string InputClasses { get; set; }
		public int MaxLength { get; set; }
		public string ErrorId { get { return $"{Id}Error"; } }
		public string OnChange { get; set; }
		public bool Disabled { get; set; }

	}
}
