using System;
using Core.Entities;
using Core.Helpers;
using Data.Contents;
using Data.Repository.Concrete;

namespace Presentation.Services
{
	public class SupplierService
	{
		private readonly SupplierRepository _supplierRepository;
		public SupplierService()
		{
			_supplierRepository = new SupplierRepository();
		}

		int id;
		public void Create()
		{
			id++;
			ConsoleHelper.WriteWithColor("Enter the name of the supplier", ConsoleColor.Cyan);
			string name = Console.ReadLine();

			var supplier = new Supplier
			{
				Id = id,
				Name = name
			};

			_supplierRepository.Create(supplier);

			ConsoleHelper.WriteWithColor($"Id: {supplier.Id}, Name: {supplier.Name} has been created successfully", ConsoleColor.Green);
		}

		public void Update()
		{
			if (_supplierRepository.GetAll().Count==0)
			{
                ConsoleHelper.WriteWithColor("First you should create a supplier", ConsoleColor.Red);
            }
			else
			{
                GetAll();
            UpdateSupplierDescription: ConsoleHelper.WriteWithColor("Enter the Id of the supplier that you want to update", ConsoleColor.Cyan);
                int id;
                bool issucceeded = int.TryParse(Console.ReadLine(), out id);
                if (!issucceeded)
                {
                    ConsoleHelper.WriteWithColor("Id is not in a correct format", ConsoleColor.Red);
                    goto UpdateSupplierDescription;
                }

                if (id <= 0)
                {
                    ConsoleHelper.WriteWithColor("Id should be more than 0", ConsoleColor.Red);
                    goto UpdateSupplierDescription;
                }
                var supplier = _supplierRepository.Get(id);
                if (supplier is null)
                {
                    ConsoleHelper.WriteWithColor("There is not any supplier in this id", ConsoleColor.Red);
                    goto UpdateSupplierDescription;
                }


                ConsoleHelper.WriteWithColor("Enter new name", ConsoleColor.Cyan);
                var name = Console.ReadLine();

                supplier.Name = name;

                _supplierRepository.Update(supplier);

                ConsoleHelper.WriteWithColor($"{supplier.Name} has been updated successfully", ConsoleColor.Green);
            }
		}

		public void Delete()
		{
			if (_supplierRepository.GetAll().Count!=0)
			{
				GetAll();
            DeleteSupplierDescription: ConsoleHelper.WriteWithColor("Enter the Id of the supplier that you want to delete", ConsoleColor.Cyan);

                int id;
                bool issucceeded = int.TryParse(Console.ReadLine(), out id);
                if (!issucceeded)
                {
                    ConsoleHelper.WriteWithColor("Id is not in a correct format", ConsoleColor.Red);
                    goto DeleteSupplierDescription;
                }

                if (id <= 0)
                {
                    ConsoleHelper.WriteWithColor("Id should be more than 0", ConsoleColor.Red);
                    goto DeleteSupplierDescription;
                }
                var supplier = _supplierRepository.Get(id);
                if (supplier is null)
                {
                    ConsoleHelper.WriteWithColor("There is not any supplier in this id", ConsoleColor.Red);
                    goto DeleteSupplierDescription;
                }

				_supplierRepository.Delete(supplier);
                ConsoleHelper.WriteWithColor($"{supplier.Name} has been deleted successfully", ConsoleColor.Green);

            }
            else
			{
				ConsoleHelper.WriteWithColor("There is not any supplier to delete", ConsoleColor.Red);
			}
		}

		public void GetAll()
		{
			if (_supplierRepository.GetAll().Count!=0)
			{
				var suppliers = _supplierRepository.GetAll();
				ConsoleHelper.WriteWithColor("---All suppliers---", ConsoleColor.Blue);
				foreach (var supplier in suppliers)
				{
                    ConsoleHelper.WriteWithColor($"Id: {supplier.Name}, Name: {supplier.Name}", ConsoleColor.Cyan);
                }

			}
			else
			{
                ConsoleHelper.WriteWithColor("There is not any supplier to get", ConsoleColor.Red);
            }
        }
	}
}

