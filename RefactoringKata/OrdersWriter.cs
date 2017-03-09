using System.Net.Mail;
using System.Text;

namespace RefactoringKata
{
	public class OrdersWriter
	{
		private readonly Orders _orders;

		public OrdersWriter(Orders orders)
		{
			_orders = orders;
		}

		public string GetContents()
		{
			var sb = new StringBuilder();

			sb.Append(JsonMaker.MakeKey("orders"));
			sb.Append(JsonMaker.AddSquareBrackets(_orders.MakeOrdersItem()));
			return JsonMaker.AddCurlyBrackets(sb.ToString());
		}
	}
}