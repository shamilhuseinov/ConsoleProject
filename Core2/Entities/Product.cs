using System;
namespace Core.Entities
{
	public class Product : BaseEntity
	{
		public string Name { get; set; } = "";

		public decimal Price { get; set; }

		public int Count { get; set; }

		public Supplier? Supplier { get; set; }
	}
}

