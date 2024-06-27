using System;
namespace Core.Entities
{
	public class Supplier : BaseEntity
	{
		public string Name { get; set; } = "";

		public List<Product>? Products { get; set; }
	}
}

