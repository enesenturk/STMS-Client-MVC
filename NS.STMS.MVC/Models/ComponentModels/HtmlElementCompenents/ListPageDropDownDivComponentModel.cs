namespace NS.STMS.MVC.Models.ComponentModels.HtmlElementCompenents
{
	public class ListPageDropDownDivComponentModel
	{

		public string _key { get; set; }
		public string _value { get; set; }
		
		
		public string Id { get; set; }
		public string ErrorId { get { return $"{Id}Error"; } }
		public string OnChange { get; set; }
		public bool Disabled { get; set; }
		public List<JSonDto> Options { get; set; }

	}
}
