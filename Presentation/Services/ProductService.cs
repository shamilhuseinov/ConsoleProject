using System;
using Core.Entities;
using Core.Helpers;
using Data.Repository.Concrete;

namespace Presentation.Services
{
	public class ProductService
	{
		public readonly ProductRepository _productRepository;
		public readonly SupplierRepository _supplierRepository;
		private readonly SupplierService _supplierService;
		public ProductService()
		{
			_productRepository = new ProductRepository();
			_supplierRepository = new SupplierRepository();
			_supplierService = new SupplierService();

        }

		int id;
		public void Create()
		{
			if (_supplierRepository.GetAll().Count!=0)
			{
				id++;
				ConsoleHelper.WriteWithColor("Enter the name of the drug", ConsoleColor.Cyan);
				string name = Console.ReadLine();

			ProductPriceDescription: ConsoleHelper.WriteWithColor("Enter the price of the Product", ConsoleColor.Cyan);
				decimal price;
				bool issucceeded = decimal.TryParse(Console.ReadLine(), out price);

				if (!issucceeded)
				{
					ConsoleHelper.WriteWithColor("Product price is not in a correct format", ConsoleColor.Red);
					goto ProductPriceDescription;
				}

				if (price<=0)
				{
                    ConsoleHelper.WriteWithColor("Product price should be more than 0", ConsoleColor.Red);
                    goto ProductPriceDescription;
                }

			ProductCountDescription: ConsoleHelper.WriteWithColor("Enter the count of the Product", ConsoleColor.Cyan);
				int count;
				issucceeded = int.TryParse(Console.ReadLine(), out count);
				if (!issucceeded)
				{
                    ConsoleHelper.WriteWithColor("Product count is not in a correct format", ConsoleColor.Red);
					goto ProductCountDescription;
                }

				if (count <=0)
				{
                    ConsoleHelper.WriteWithColor("Product count should be more than 0", ConsoleColor.Red);
                    goto ProductCountDescription;
                }

				_supplierService.GetAll();
			SupplierIdDescription: ConsoleHelper.WriteWithColor("Enter the id of the supplier", ConsoleColor.Cyan);
				int supplierId;
				issucceeded = int.TryParse(Console.ReadLine(), out supplierId);
				if (!issucceeded)
				{
					ConsoleHelper.WriteWithColor("Supplier id is not in a correct format", ConsoleColor.Red);
					goto SupplierIdDescription;
				}

				if (supplierId<=0)
				{
					ConsoleHelper.WriteWithColor("Supplier id should be more than 0", ConsoleColor.Red);
					goto SupplierIdDescription;
				}

				var supplier = _supplierRepository.Get(supplierId);
				if (supplier is null)
				{
					ConsoleHelper.WriteWithColor("There is no any supplier in this id", ConsoleColor.Red);
					goto SupplierIdDescription;
				}

				var product = new Product
				{
					Id = id,
					Name = name,
					Price = price,
					Count = count,
					Supplier = supplier
				};

				_productRepository.Create(product);

				ConsoleHelper.WriteWithColor($"Product (Id: {product.Id}, Name: {product.Name}, Price: {product.Price}, Count: {product.Count}, SupplierId: {product.Supplier.Id}, SupplierName: {product.Supplier.Name} has been created successfully", ConsoleColor.Green);

            }
			else
			{
				ConsoleHelper.WriteWithColor("First you should create a Supplier");
			}
		}

		public void Update()
		{
			if (_productRepository.GetAll().Count!=0)
			{
				GetAll();
			UpdateProductDescription: ConsoleHelper.WriteWithColor("Enter the id of the product that you want to update", ConsoleColor.Cyan);
				int id;
				bool issucceeded = int.TryParse(Console.ReadLine(), out id);
				if (!issucceeded)
				{
					ConsoleHelper.WriteWithColor("Id is not in a correct format", ConsoleColor.Red);
					goto UpdateProductDescription;
                }

                if (id<=0)
                {
                    ConsoleHelper.WriteWithColor("Id should be more than 0", ConsoleColor.Red);
                    goto UpdateProductDescription;
                }

				var product = _productRepository.Get(id);
				if (product is null)
				{
					ConsoleHelper.WriteWithColor("There is not any product in this id");
					goto UpdateProductDescription;
				}

				ConsoleHelper.WriteWithColor("Enter new name", ConsoleColor.Cyan);
				string name = Console.ReadLine();

			UpdatePriceDescription: ConsoleHelper.WriteWithColor("Enter new price", ConsoleColor.Blue);
;				decimal price;
				issucceeded = decimal.TryParse(Console.ReadLine(), out price);
				if (!issucceeded)
				{
					ConsoleHelper.WriteWithColor("Price is not in a correct format", ConsoleColor.Red);
					goto UpdatePriceDescription;
                }

				if (price<=0)
				{
                    ConsoleHelper.WriteWithColor("Price should be more than 0", ConsoleColor.Red);
                    goto UpdatePriceDescription;
                }

            UpdateCountDescription: ConsoleHelper.WriteWithColor("Enter new count", ConsoleColor.Blue);
                int count;
                issucceeded = int.TryParse(Console.ReadLine(), out count);
                if (!issucceeded)
                {
                    ConsoleHelper.WriteWithColor("Count is not in a correct format", ConsoleColor.Red);
                    goto UpdateCountDescription;
                }

                if (count <= 0)
                {
                    ConsoleHelper.WriteWithColor("Count should be more than 0", ConsoleColor.Red);
                    goto UpdateCountDescription;
                }

				_supplierService.GetAll();
                UpdateSupplierDescription:  ConsoleHelper.WriteWithColor("Enter new supplier's id", ConsoleColor.Cyan);
                int supplierId;
                issucceeded = int.TryParse(Console.ReadLine(), out supplierId);
                if (!issucceeded)
                {
                    ConsoleHelper.WriteWithColor("Supplier Id is not in a correct format", ConsoleColor.Red);
                    goto UpdateSupplierDescription;
                }

                if (id <= 0)
                {
                    ConsoleHelper.WriteWithColor("Supplier Id should be more than 0", ConsoleColor.Red);
                    goto UpdateSupplierDescription;
                }

				var supplier = _supplierRepository.Get(supplierId);
				if (supplier is null)
				{
					ConsoleHelper.WriteWithColor("There is not any supplier in this id", ConsoleColor.Red);
					goto UpdateSupplierDescription;
				}

				product.Name = name;
				product.Price = price;
				product.Count = count;
				product.Supplier = supplier;

				_productRepository.Update(product);

				ConsoleHelper.WriteWithColor($"Product with Id: {product.Id}, Name: {product.Name}, Price: {product.Price}, Count: {product.Count}, SupplierId: {product.Supplier.Id}, SupplierName: {product.Supplier.Name} has been updated successfully", ConsoleColor.Green);


            }
			else
			{
				ConsoleHelper.WriteWithColor("There is not any product to update", ConsoleColor.Red);
			}
		}

		public void Delete()
		{
			if (_productRepository.GetAll().Count!=0)
			{
				GetAll();
				DeleteProductDescription: ConsoleHelper.WriteWithColor("Enter the id of the product that you want to delete", ConsoleColor.Cyan);
                int id;
                bool issucceeded = int.TryParse(Console.ReadLine(), out id);
                if (!issucceeded)
                {
                    ConsoleHelper.WriteWithColor("Id is not in a correct format", ConsoleColor.Red);
                    goto DeleteProductDescription;
                }

                if (id <= 0)
                {
                    ConsoleHelper.WriteWithColor("Id should be more than 0", ConsoleColor.Red);
                    goto DeleteProductDescription;
                }

                var product = _productRepository.Get(id);
                if (product is null)
                {
                    ConsoleHelper.WriteWithColor("There is not any product in this id");
                    goto DeleteProductDescription;
                }

				_productRepository.Delete(product);
                ConsoleHelper.WriteWithColor($"Product with Id: {product.Id}, Name: {product.Name}, Price: {product.Price}, Count: {product.Count}, SupplierId: {product.Supplier.Id}, SupplierName: {product.Supplier.Name} has been deleted successfully", ConsoleColor.Green);

            }
            else
			{
				ConsoleHelper.WriteWithColor("There is not any product to delete", ConsoleColor.Red);
			}
		}

		public void GetAll()
		{
			if (_productRepository.GetAll().Count!= 0)
			{
                ConsoleHelper.WriteWithColor("---All Products---", ConsoleColor.Blue);

                var products = _productRepository.GetAll();
				foreach (var product in products)
				{
					ConsoleHelper.WriteWithColor($"Id: {product.Id}, Name: {product.Name}, Price: {product.Price}, Count: {product.Count}, SupplierId: {product.Supplier.Id}, SupplierName: {product.Supplier.Name}", ConsoleColor.Cyan);
				}
			}
			else
			{
				ConsoleHelper.WriteWithColor("There is not any product", ConsoleColor.Red);
			}
		}

		public void GetAllBySupplier()
		{
			if (_productRepository.GetAll().Count!= 0)
			{
				_supplierService.GetAll();
				SupplierIdDescription: ConsoleHelper.WriteWithColor("Enter Supplier id", ConsoleColor.Cyan);
                int supplierId;
                bool issucceeded = int.TryParse(Console.ReadLine(), out supplierId);
                if (!issucceeded)
                {
                    ConsoleHelper.WriteWithColor("Supplier id is not in a correct format", ConsoleColor.Red);
                    goto SupplierIdDescription;
                }

                if (id <= 0)
                {
                    ConsoleHelper.WriteWithColor("Supplier id should be more than 0", ConsoleColor.Red);
                    goto SupplierIdDescription;
                }

				var supplier = _supplierRepository.Get(supplierId);
				if (supplier is null)
				{
                    ConsoleHelper.WriteWithColor("There is not any supplier in this id", ConsoleColor.Red);
                    goto SupplierIdDescription;
                }

				var products = _productRepository.GetAll().Where(p=>p.Supplier == supplier);

				if (products.Count()==0)
				{
                    ConsoleHelper.WriteWithColor("There is not any product supplied by this supplier", ConsoleColor.Red);
                }

                foreach (var product in products)
				{
                    ConsoleHelper.WriteWithColor($"Id: {product.Id}, Name: {product.Name}, Price: {product.Price}, Count: {product.Count}, SupplierId: {product.Supplier.Id}, SupplierName: {product.Supplier.Name}", ConsoleColor.Cyan);
                }
            }
            else
			{
                ConsoleHelper.WriteWithColor("There is not any product", ConsoleColor.Red);
            }
        }

		public void Filter()
		{
			if (_productRepository.GetAll().Count != 0)
			{
			MaxPriceDescription: ConsoleHelper.WriteWithColor("Enter maximum price of the product", ConsoleColor.Cyan);
				int maxprice;
				bool issucceeded = int.TryParse(Console.ReadLine(), out maxprice);
				if (!issucceeded)
				{
					ConsoleHelper.WriteWithColor("Max price is not in a correct format", ConsoleColor.Red);
					goto MaxPriceDescription;
				}

				if (maxprice<=0)
				{
                    ConsoleHelper.WriteWithColor("Max price should be more than 0", ConsoleColor.Red);
                    goto MaxPriceDescription;
                }

				var products = _productRepository.GetAll().Where(p=>p.Price<=maxprice);
				if (products.Count()==0)
				{
                    ConsoleHelper.WriteWithColor("There is not any product whose price is less than max price you entered", ConsoleColor.Red);
                    goto MaxPriceDescription;
                }

                foreach (var product in products)
                {
                    ConsoleHelper.WriteWithColor($"Id: {product.Id}, Name: {product.Name}, Price: {product.Price}, Count: {product.Count}, SupplierId: {product.Supplier.Id}, SupplierName: {product.Supplier.Name}", ConsoleColor.Cyan);
                }
            }
            else
            {
                ConsoleHelper.WriteWithColor("There is not any product", ConsoleColor.Red);
            }
        }
	}
}

