namespace Conditions.Sql.Tests
{
	public class BasketItem
	{
		public int BasketItemId { get; set; }
		public Basket Basket { get; set; }
		public string Name { get; set; }
	}
}
