using System.Collections.Generic;
using System.Text;

namespace RefactoringKata
{
	public class Orders
	{
		private List<Order> _orders = new List<Order>();

		public void AddOrder(Order order)
		{
			_orders.Add(order);
		}

		private int GetOrdersCount()
		{
			return _orders.Count;
		}

		private Order GetOrder(int i)
		{
			return _orders[i];
		}

		public string MakeOrdersItem()
		{
			var sb = new StringBuilder();
			for (var i = 0; i < GetOrdersCount(); i++)
			{
				sb.Append(GetOrder(i).MakeOrderItem());
				if (i < GetOrdersCount() - 1)
				{
					sb.Append(Symbol.CAMA);
				}
			}
			return sb.ToString();
		}
	}
}