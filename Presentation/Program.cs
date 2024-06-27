using System.Text;
using Core.Constants;
using Core.Helpers;
using Data;
using Presentation.Services;

namespace Presentation
{
    public static class Program
    {
        private readonly static SupplierService _supplierService;
        private readonly static ProductService _productService;
        private readonly static AdminService _adminService;

        static Program()
        {
            DbInitializer.SeedAdmins();

            _supplierService = new SupplierService();
            _productService = new ProductService();
            _adminService = new AdminService();
        }

        static void Main()
        {
            {

                Console.OutputEncoding = Encoding.UTF8;
                ConsoleHelper.WriteWithColor("---W E L C O M E---", ConsoleColor.Blue);

            AuthorizeDesc: var admin = _adminService.Authenticate();
                while (true)
                {
                MainMenuDescription:
                    ConsoleHelper.WriteWithColor("1 - Suppliers", ConsoleColor.Yellow);
                    ConsoleHelper.WriteWithColor("2 - Products", ConsoleColor.Yellow);
                    ConsoleHelper.WriteWithColor("0 - Logout", ConsoleColor.Yellow);

                    ConsoleHelper.WriteWithColor("Select your option", ConsoleColor.Cyan);

                    int option;
                    bool issucceeded = int.TryParse(Console.ReadLine(), out option);
                    if (!issucceeded)
                    {
                        ConsoleHelper.WriteWithColor("Your option is not in a correct format", ConsoleColor.Red);
                        goto MainMenuDescription;
                    }

                    switch (option)
                    {
                        case (int)MainMenuOptions.Suppliers:
                            while (true)
                            {
                            SuppliersOptionDescription: ConsoleHelper.WriteWithColor("1 - Create Supplier", ConsoleColor.Yellow);
                                ConsoleHelper.WriteWithColor("2 - Update Supplier", ConsoleColor.Yellow);
                                ConsoleHelper.WriteWithColor("3 - Delete Supplier", ConsoleColor.Yellow);
                                ConsoleHelper.WriteWithColor("4 - Get all Suppliers", ConsoleColor.Yellow);
                                ConsoleHelper.WriteWithColor("0 - Go to Main Menu", ConsoleColor.Yellow);

                                ConsoleHelper.WriteWithColor("Select your option", ConsoleColor.Cyan);

                                int supplierOption;
                                issucceeded = int.TryParse(Console.ReadLine(), out supplierOption);
                                if (!issucceeded)
                                {
                                    ConsoleHelper.WriteWithColor("Your option is not in a correct format", ConsoleColor.Red);
                                    goto SuppliersOptionDescription;
                                }
                                switch (supplierOption)
                                {
                                    case (int)SupplierOptions.CreateSupplier:
                                        _supplierService.Create();
                                        break;
                                    case (int)SupplierOptions.UpdateSupplier:
                                        _supplierService.Update();
                                        break;
                                    case (int)SupplierOptions.DeleteSupplier:
                                        _supplierService.Delete();
                                        break;
                                    case (int)SupplierOptions.GetAllSuppliers:
                                        _supplierService.GetAll();
                                        break;
                                    case (int)SupplierOptions.GoToMainMenu:
                                        goto MainMenuDescription;
                                    default:
                                        ConsoleHelper.WriteWithColor("There is not any option like that", ConsoleColor.Red);
                                        goto SuppliersOptionDescription;
                                }

                            }
                        case (int)MainMenuOptions.Products:
                            while (true)
                            {
                            ProductsOptionDescription: ConsoleHelper.WriteWithColor("1 - Create Product", ConsoleColor.Yellow);
                                ConsoleHelper.WriteWithColor("2 - Update Product", ConsoleColor.Yellow);
                                ConsoleHelper.WriteWithColor("3 - Delete Product", ConsoleColor.Yellow);
                                ConsoleHelper.WriteWithColor("4 - Get All Products", ConsoleColor.Yellow);
                                ConsoleHelper.WriteWithColor("5 - Get All Products by Supplier", ConsoleColor.Yellow);
                                ConsoleHelper.WriteWithColor("6 - Get Filtered Products", ConsoleColor.Yellow);
                                ConsoleHelper.WriteWithColor("0 - Go to Main Menu", ConsoleColor.Yellow);

                                ConsoleHelper.WriteWithColor("Select your option", ConsoleColor.Cyan);

                                int productOption;
                                issucceeded = int.TryParse(Console.ReadLine(), out productOption);
                                if (!issucceeded)
                                {
                                    ConsoleHelper.WriteWithColor("Your option is not in a correct format", ConsoleColor.Red);
                                    goto ProductsOptionDescription;
                                }

                                switch (productOption)
                                {
                                    case (int)ProductOptions.CreateProduct:
                                        _productService.Create();
                                        break;
                                    case (int)ProductOptions.UpdateProduct:
                                        _productService.Update();
                                        break;
                                    case (int)ProductOptions.DeleteProduct:
                                        _productService.Delete();
                                        break;
                                    case (int)ProductOptions.GetAllProducts:
                                        _productService.GetAll();
                                        break;
                                    case (int)ProductOptions.GetAllProductsBySupplier:
                                        _productService.GetAllBySupplier();
                                        break;
                                    case (int)ProductOptions.GetAllFilteredProducts:
                                        _productService.Filter();
                                        break;
                                    case (int)ProductOptions.GoToMainMenu:
                                        goto MainMenuDescription;
                                    default:
                                        ConsoleHelper.WriteWithColor("There is not any option like that", ConsoleColor.Red);
                                        goto ProductsOptionDescription;
                                }

                            }
                        case (int)MainMenuOptions.Logout:
                            goto AuthorizeDesc;
                        default:
                            goto MainMenuDescription;
                    }
                }
            }
        }
    }
}