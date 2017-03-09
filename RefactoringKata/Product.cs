using System.Text;

namespace RefactoringKata
{
	public class Product
	{
		private static int SIZE_NOT_APPLICABLE = -1;

		private string Code { get; set; }
		private int Color { get; set; }
		private int Size { get; set; }
		private double Price { get; set; }
		private string Currency { get; set; }

		private readonly string[] _colorStr = { "no color", "blue", "red", "yellow", "M", "L", "XL", "XXL" };
		private readonly string[] _sizeStr = { "Invalid Size", "XS", "S", "M", "L", "XL", "XXL" };

		public Product(string code, int color, int size, double price, string currency)
		{
			Code = code;
			Color = color;
			Size = size;
			Price = price;
			Currency = currency;
		}

		public string MakeProductItem()
		{
			var sb = new StringBuilder();
			sb.Append(JsonMaker.MakeItem("code", Code));
			sb.Append(JsonMaker.MakeItem("color", _colorStr[Color]));
			if (Size != Product.SIZE_NOT_APPLICABLE)
			{
				sb.Append(JsonMaker.MakeItem("size", _sizeStr[Size]));
			}
			sb.Append(JsonMaker.MakeItem("price", (decimal)Price));
			sb.Append(JsonMaker.MakeItemWithoutCama("currency", Currency));
			return JsonMaker.AddCurlyBrackets(sb.ToString());
		}
	}
}