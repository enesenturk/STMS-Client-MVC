using NS.STMS.MVC.Models;
using NS.STMS.Resources.Language.Helpers;

namespace NS.STMS.MVC.Extensions
{
	public static class JSonDtoExtensions
	{

		public static List<JSonDto> SetLangaugeTextFromValue(this List<JSonDto> records)
		{
			foreach (var record in records)
			{
				string languageText = LanguageHelper.GetLanguageByKey(record.Value);

				record.Value = languageText;
			}

			return records;
		}

		public static List<JSonDto> OrderList(this List<JSonDto> selections)
		{
			bool zeroSelections = selections.Count == 0;

			if (zeroSelections)
				return selections;

			JSonDto nullSelection = GetNull(ref selections);

			bool nullExists = nullSelection != null;

			if (nullExists)
				RemoveNull(ref selections, nullSelection);

			OrderSelections(ref selections);

			if (nullExists)
				InsertNull(ref selections, nullSelection);

			List<JSonDto> Ordered = selections;

			return Ordered;
		}

		#region extracted methods

		private static JSonDto GetNull(ref List<JSonDto> selections)
		{
			return selections.Where(x => x.Key == "null").FirstOrDefault();
		}

		private static void InsertNull(ref List<JSonDto> selections, JSonDto firstItem)
		{
			selections.Insert(0, firstItem);
		}

		private static void OrderSelections(ref List<JSonDto> selections)
		{
			bool areAllInts = CheckAllInts(ref selections);

			if (areAllInts)
				selections = selections.OrderBy(x => int.Parse(x.Value)).ToList();
			else
				selections = selections.OrderBy(x => x.Value).ToList();
		}

		private static bool CheckAllInts(ref List<JSonDto> selections)
		{
			return selections.All(x => int.TryParse(x.Value, out var _));
		}

		private static void RemoveNull(ref List<JSonDto> selections, JSonDto firstItem)
		{
			selections.Remove(firstItem);
		}

		#endregion

	}
}
