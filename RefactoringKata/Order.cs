using System.Collections.Generic;
using System.Text;

namespace RefactoringKata
{
	public class Order
	{
		private readonly int id;
		private readonly List<Product> _products = new List<Product>();

		public Order(int id)
		{
			this.id = id;
		}

		public int GetOrderId()
		{
			return id;
		}

		public int GetProductsCount()
		{
			return _products.Count;
		}

		public Product GetProduct(int j)
		{
			return _products[j];
		}

		public void AddProduct(Product product)
		{
			_products.Add(product);
		}

		public string MakeOrderItem()
		{
			var sb = new StringBuilder();
			sb.Append(JsonMaker.MakeItem("id", GetOrderId()));
			sb.Append(JsonMaker.MakeKey("products"));
			sb.Append(MakeOrderAllProduct());

			return JsonMaker.AddCurlyBrackets(sb.ToString());
		}

		private string MakeOrderAllProduct()
		{
			var sb = new StringBuilder();

			for (var j = 0; j < GetProductsCount(); j++)
			{
				sb.Append(GetProduct(j).MakeProductItem());
				if (j < GetProductsCount() - 1)
				{
					sb.Append(Symbol.CAMA);
				}
			}

			return JsonMaker.AddSquareBrackets(sb.ToString());
		}
	}
}