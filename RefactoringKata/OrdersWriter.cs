using System.Net.Mail;
using System.Text;

namespace RefactoringKata
{
	public class OrdersWriter
	{
		private Orders _orders;

		public OrdersWriter(Orders orders)
		{
			_orders = orders;
		}

		public string GetContents()
		{
			var sb = new StringBuilder();

			sb.Append(JsonMaker.MakeKey("orders"));
			sb.Append(JsonMaker.AddSquareBrackets(MakeOrdersItem()));
			return JsonMaker.AddCurlyBrackets(sb.ToString());
		}

		private string MakeOrdersItem()
		{
			var sb = new StringBuilder();
			for (var i = 0; i < _orders.GetOrdersCount(); i++)
			{
				sb.Append(MakeOrderItem(_orders.GetOrder(i)));
				if (i < _orders.GetOrdersCount() - 1)
				{
					sb.Append(Symbol.CAMA);
				}
			}
			return sb.ToString();
		}

		private string MakeOrderItem(Order order)
		{
			var sb = new StringBuilder();
			sb.Append(JsonMaker.MakeItem("id", order.GetOrderId()));
			sb.Append(JsonMaker.MakeKey("products"));
			sb.Append(MakeOrderAllProduct(order));

			return JsonMaker.AddCurlyBrackets(sb.ToString());
		}

		private string MakeOrderAllProduct(Order order)
		{
			var sb = new StringBuilder();

			for (var j = 0; j < order.GetProductsCount(); j++)
			{
				sb.Append(order.GetProduct(j).MakeProductItem());
				if (j < order.GetProductsCount() - 1)
				{
					sb.Append(Symbol.CAMA);
				}
			}

			return JsonMaker.AddSquareBrackets(sb.ToString());
		}
	}
}