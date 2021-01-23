using System.Collections.Generic;

namespace Conditions.Sql.Tests
{
	public class Basket
	{
		public int BasketId { get; set; }
		public string BuyerId { get; set; }
		public IList<BasketItem> Items { get; set; } = new List<BasketItem>();
	}
}
