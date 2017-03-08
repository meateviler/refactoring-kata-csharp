using System.Text;

namespace RefactoringKata
{
	public class OrdersWriter
	{
		private static string COLN = ": ";
		private static string CAMA = ", ";
		private static string LEFT_CURLY_BRACKETS = "{";
		private static string RIGHT_CURLY_BRACKETS = "}";
		private static string LEFT_SQUARE_BRACKETS  = "[";
		private static string RIGHT_SQUARE_BRACKETS  = "]";
		private Orders _orders;

		public OrdersWriter(Orders orders)
		{
			_orders = orders;
		}

		public string GetContents()
		{
			var sb = new StringBuilder();
			sb.Append(LEFT_CURLY_BRACKETS);
			sb.Append(MakeKey("orders"));
			sb.Append(LEFT_SQUARE_BRACKETS);
			sb.Append(MakeOrdersXML());
			sb.Append(RIGHT_SQUARE_BRACKETS);
			sb.Append(RIGHT_CURLY_BRACKETS);

			return sb.ToString();
		}

		private string GetQuterString(string str)
		{
			return "\"" + str + "\"";
		}

		private string MakeXMLItem(string key, string value)
		{
			return MakeXMLItemWithoutCama(key, value) + CAMA;
		}

		private string MakeXMLItemWithoutCama(string key, string value)
		{
			var sb = new StringBuilder(MakeKey(key));
			return sb.Append(GetQuterString(value)).ToString();
		}

		private string MakeXMLItem(string key, decimal value)
		{
			var sb = new StringBuilder(MakeKey(key));
			sb.Append(value);
			sb.Append(CAMA);
			return sb.ToString();
		}

		private string MakeKey(string key)
		{
			var sb = new StringBuilder(GetQuterString(key));
			return sb.Append(COLN).ToString();
		}

		private string MakeOrdersXML()
		{
			var sb = new StringBuilder();
			for (var i = 0; i < _orders.GetOrdersCount(); i++)
			{
				sb.Append(MakeOrderXML(_orders.GetOrder(i)));
				if (i < _orders.GetOrdersCount() - 1)
				{
					sb.Append(CAMA);
				}
			}
			return sb.ToString();
		}

		private string MakeOrderXML(Order order)
		{
			var sb = new StringBuilder();
			sb.Append(LEFT_CURLY_BRACKETS);
			sb.Append(MakeXMLItem("id", order.GetOrderId()));
			sb.Append(MakeKey("products"));
			sb.Append(LEFT_SQUARE_BRACKETS);

			for (var j = 0; j < order.GetProductsCount(); j++)
			{
				sb.Append(MakeProductXML(order.GetProduct(j)));
				if (j < order.GetProductsCount() - 1)
				{
					sb.Append(CAMA);
				}
			}
			sb.Append(RIGHT_SQUARE_BRACKETS);
			sb.Append(RIGHT_CURLY_BRACKETS);

			return sb.ToString();
		}

		private string MakeProductXML(Product product)
		{
			var sb = new StringBuilder();
			sb.Append(LEFT_CURLY_BRACKETS);
			sb.Append(MakeXMLItem("code", product.Code));
			sb.Append(MakeXMLItem("color", product.GetColorStr()));
			if (product.Size != Product.SIZE_NOT_APPLICABLE)
			{
				sb.Append(MakeXMLItem("size", product.GetSizeString()));
			}
			sb.Append(MakeXMLItem("price", (decimal)product.Price));
			sb.Append(MakeXMLItemWithoutCama("currency", product.Currency));
			sb.Append(RIGHT_CURLY_BRACKETS);
			return sb.ToString();
		}
	}
}