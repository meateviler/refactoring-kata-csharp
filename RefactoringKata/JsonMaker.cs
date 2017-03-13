using System.Text;

namespace RefactoringKata
{
	public class JsonMaker
	{
		public JsonMaker()
		{
		}

		private static string GetQuterString(string str)
		{
			return "\"" + str + "\"";
		}

		public static string MakeItem(string key, string value)
		{
			return MakeItemWithoutCama(key, value) + Symbol.CAMA;
		}

		public static string MakeItemWithoutCama(string key, string value)
		{
			var sb = new StringBuilder(MakeKey(key));
			return sb.Append(GetQuterString(value)).ToString();
		}

		public static string MakeItem(string key, decimal value)
		{
			var sb = new StringBuilder(MakeKey(key));
			sb.Append(value);
			sb.Append(Symbol.CAMA);
			return sb.ToString();
		}

		public static string MakeKey(string key)
		{
			var sb = new StringBuilder(GetQuterString(key));
			return sb.Append(Symbol.COLN).ToString();
		}

		public static string AddCurlyBrackets(string item)
		{
			var sb = new StringBuilder();
			sb.Append(Symbol.LEFT_CURLY_BRACKETS);
			sb.Append(item);
			sb.Append(Symbol.RIGHT_CURLY_BRACKETS);
			return sb.ToString();
		}

		public static string AddSquareBrackets(string item)
		{
			var sb = new StringBuilder();
			sb.Append(Symbol.LEFT_SQUARE_BRACKETS);
			sb.Append(item);
			sb.Append(Symbol.RIGHT_SQUARE_BRACKETS);
			return sb.ToString();
		}
	}
}