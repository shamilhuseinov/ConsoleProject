using System;
using Core.Entities;

namespace Data.Contents
{
	public class DbContent
	{
		public DbContent()
		{
			Products = new List<Product>();
			Suppliers = new List<Supplier>();
            Admins = new List<Admin>();
        }

        public static List<Product> Products { get; set; }

		public static List<Supplier> Suppliers { get; set; }

		public static List<Admin> Admins { get; set; }
	}
}

