using System;
using System.IO;
using System.Linq;
using DeliveryService_EF.Comparers;
using DeliveryService_EF.Models;
using DeliveryService_EF.Repos;
using Microsoft.Extensions.Configuration;

namespace DeliveryService_EF
{
    public class Program
    {
        private static void Main()
        {
            var configuration = Initialize();
            var repo = new DapperRepo(configuration);
            var contribRepo = new DapperContribRepo(configuration);

            //DapperTasks(repo);
            DapperNestedTasks(repo);

            //DapperContribTasks(contribRepo);

            Console.ReadLine();
        }

        private static IConfiguration Initialize()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }

        private static void DapperTasks(DapperRepo repo)
        {
            Console.WriteLine("***** ***** ***** ***** *****");
            Console.WriteLine($"***** ** {nameof(DapperTasks)} ** *****");
            Console.WriteLine("***** ***** ***** ***** *****\n");

            {
                Console.WriteLine($"===== {nameof(repo.GetProducts)} =====");
                var result = repo.GetProducts();
                foreach (var product in result)
                {
                    Console.WriteLine($"{product.Name}, {product.Description}, {product.Price}, {product.AmountInStock}");
                }
                Console.WriteLine($"===== {nameof(repo.GetProducts)} =====\n");
            }

            {
                Console.WriteLine($"===== {nameof(repo.GetProductById)} =====");
                var result = repo.GetProductById(1);
                Console.WriteLine($"{result.Name}, {result.Description}, {result.Price}, {result.AmountInStock}");
                Console.WriteLine($"===== {nameof(repo.GetProductById)} =====\n");
            }
            //commented to not add same copy every time the program is launched
           /* {
                Console.WriteLine($"===== {nameof(repo.AddProduct)} =====");
                var product = new Product
                {
                    Name = "MSI GeForce RTX 3090 Suprim X",
                    Description = "Ultra high performance graphics card capable of ray tracing.",
                    Price = 80999.00m,
                    AmountInStock = 0
                };
                var result = repo.AddProduct(product);
                Console.WriteLine($"{result.Name}, {result.Description}, {result.Price}, {result.AmountInStock}");
                Console.WriteLine($"===== {nameof(repo.AddProduct)} =====\n");
            }*/

           {
               Console.WriteLine($"===== {nameof(repo.UpdateProduct)} =====");
               var result = repo.UpdateProduct(12, 1);
               Console.WriteLine($"{result.Name}, {result.Description}, {result.Price}, {result.AmountInStock}");
               Console.WriteLine($"===== {nameof(repo.UpdateProduct)} =====\n");
           }

           {
               Console.WriteLine($"===== {nameof(repo.DeleteProduct)} =====");

               var productToDelete = new Product
               {
                   Name = "to be deleted",
                   Description = "to be deleted",
                   Price = 999,
                   AmountInStock = 999
               };

               var deletedProduct = repo.AddProduct(productToDelete);

               var result = repo.DeleteProduct(deletedProduct.Id);

               Console.WriteLine($"{result.Name}, {result.Description}, {result.Price}, {result.AmountInStock}");
               Console.WriteLine($"===== {nameof(repo.DeleteProduct)} =====\n");
           }

           Console.WriteLine("***** ***** ***** ***** *****");
           Console.WriteLine($"***** ** {nameof(DapperTasks)} ** *****");
           Console.WriteLine("***** ***** ***** ***** *****\n");
        }

        private static void DapperNestedTasks(DapperRepo repo)
        {
            Console.WriteLine("***** ***** ***** ***** *****");
            Console.WriteLine($"***** {nameof(DapperNestedTasks)} *****");
            Console.WriteLine("***** ***** ***** ***** *****\n");

            {
                Console.WriteLine($"===== {nameof(repo.GetProductsNested)} =====");
                var result = repo.GetProductsNested();
                foreach (var product in result)
                {
                    Console.WriteLine($"{product.Name}, {product.Description}, {product.Price}, {product.AmountInStock}, {product.CategoryId?.Name}");
                }
                Console.WriteLine($"===== {nameof(repo.GetProductsNested)} =====\n");
            }

            {
                Console.WriteLine($"===== {nameof(repo.GetProductByIdNested)} =====");
                var product = repo.GetProductByIdNested(12);
                Console.WriteLine($"{product.Name}, {product.Description}, {product.Price}, {product.AmountInStock}, {product.CategoryId?.Name}");
                Console.WriteLine($"===== {nameof(repo.GetProductByIdNested)} =====\n");
            }
            //commented to not add same copy every time the program is launched
            /*{
                Console.WriteLine($"===== {nameof(repo.AddProductNested)} =====");
                var product = new Product
                {
                    Name = "AFOX GeForce GT1030",
                    Description = "Budget graphics card.",
                    Price = 2639.00m,
                    AmountInStock = 98
                };
                var result = repo.AddProductNested(product, Category.GetCategory(2)); // put incorrect category to then update it to correct one (should be 1)
                Console.WriteLine($"{result.Name}, {result.Description}, {result.Price}, {result.AmountInStock}, {result.CategoryId.Name}");
                Console.WriteLine($"===== {nameof(repo.AddProductNested)} =====\n");
            }*/

            {
                Console.WriteLine($"===== {nameof(repo.UpdateProductNested)} =====");
                var result = repo.UpdateProductNested(1008, Category.GetCategory(1));
                Console.WriteLine($"{result.Name}, {result.Description}, {result.Price}, {result.AmountInStock}, {result.CategoryId.Name}");
                Console.WriteLine($"===== {nameof(repo.UpdateProductNested)} =====\n");
            }

            {
                Console.WriteLine($"===== {nameof(repo.DeleteProductNested)} =====");

                var productToDelete = new Product
                {
                    Name = "to be deleted",
                    Description = "to be deleted",
                    Price = 999,
                    AmountInStock = 999
                };

                var categoryToDelete = new Category
                {
                    Id = 1002,
                    Name = "tbd",
                    Description = "tbd"
                };

                repo.AddProductNested(productToDelete, categoryToDelete);
                repo.AddProductNested(productToDelete, categoryToDelete);

                var result = repo.DeleteProductNested(categoryToDelete.Id);

                foreach (var product in result)
                {
                    Console.WriteLine($"{product.Name}, {product.Description}, {product.Price}, {product.AmountInStock}, {product.CategoryId.Name}");
                }

                Console.WriteLine($"===== {nameof(repo.DeleteProductNested)} =====\n");
            }

            Console.WriteLine("***** ***** ***** ***** *****");
            Console.WriteLine($"***** {nameof(DapperNestedTasks)} *****");
            Console.WriteLine("***** ***** ***** ***** *****\n");
        }

        private static void DapperContribTasks(DapperContribRepo contribRepo)
        {
            Console.WriteLine("***** ***** ***** ***** *****");
            Console.WriteLine($"***** {nameof(DapperContribTasks)} ****");
            Console.WriteLine("***** ***** ***** ***** *****\n");

            {
                Console.WriteLine($"===== {nameof(contribRepo.GetProducts)} =====");
                var result = contribRepo.GetProducts();
                foreach (var product in result)
                {
                    Console.WriteLine($"{product.Name}, {product.Description}, {product.Price}, {product.AmountInStock}");
                }
                Console.WriteLine($"===== {nameof(contribRepo.GetProducts)} =====\n");
            }

            {
                Console.WriteLine($"===== {nameof(contribRepo.GetProductById)} =====");
                var result = contribRepo.GetProductById(1);
                Console.WriteLine($"{result.Name}, {result.Description}, {result.Price}, {result.AmountInStock}");
                Console.WriteLine($"===== {nameof(contribRepo.GetProductById)} =====\n");
            }
            //commented to not add same copy every time the program is launched
            /*{
                Console.WriteLine($"===== {nameof(contribRepo.AddProduct)} =====");
                var product = new Product
                {
                    Name = "AMD Ryzen Threadripper PRO 3975WX",
                    Description = "Ultra high performance CPU.",
                    Price = 88358.00m,
                    AmountInStock = 0
                };
                var result = contribRepo.AddProduct(product);
                Console.WriteLine($"{result.Name}, {result.Description}, {result.Price}, {result.AmountInStock}");
                Console.WriteLine($"===== {nameof(contribRepo.AddProduct)} =====\n");
            }*/

            {
               Console.WriteLine($"===== {nameof(contribRepo.UpdateProduct)} =====");
               var result = contribRepo.UpdateProduct(12, 1);
               Console.WriteLine($"{result.Name}, {result.Description}, {result.Price}, {result.AmountInStock}");
               Console.WriteLine($"===== {nameof(contribRepo.UpdateProduct)} =====\n");
            }

            {
               Console.WriteLine($"===== {nameof(contribRepo.DeleteProduct)} =====");
               var productToDelete = new Product
               {
                   Name = "to be deleted",
                   Description = "to be deleted",
                   Price = 999,
                   AmountInStock = 999
               };

               var deletedProduct = contribRepo.AddProduct(productToDelete);

               var result = contribRepo.DeleteProduct(deletedProduct.Id);

               Console.WriteLine($"{result.Name}, {result.Description}, {result.Price}, {result.AmountInStock}");
               Console.WriteLine($"===== {nameof(contribRepo.DeleteProduct)} =====\n");
            }

            Console.WriteLine("***** ***** ***** ***** *****");
            Console.WriteLine($"***** {nameof(DapperContribTasks)} ****");
            Console.WriteLine("***** ***** ***** ***** *****\n");
        }

        private static void LinqTasks()
        {
            Task1();
            Console.WriteLine("Press enter to continue to next task.");
            Console.ReadLine();
            Console.Clear();

            Task2();
            Console.WriteLine("Press enter to continue to next task.");
            Console.ReadLine();
            Console.Clear();

            Task2Id();
            Console.WriteLine("Press enter to continue to next task.");
            Console.ReadLine();
            Console.Clear();

            Task3();
            Console.WriteLine("Press enter to continue to next task.");
            Console.ReadLine();
            Console.Clear();

            Task4();
            Console.WriteLine("Press enter to continue to next task.");
            Console.ReadLine();
            Console.Clear();

            Task5A(1, 2);
            Console.WriteLine("Press enter to continue to next task.");
            Console.ReadLine();
            Console.Clear();

            Task5B(1);
            Console.WriteLine("Press enter exit the program.");
        }

        private static void Task1()
        {
            Console.WriteLine("********** Task #1 **********");

            var products = Product.GetProducts()
                .OrderBy(x => x.Name);

            foreach (var product in products)
            {
                Console.WriteLine($"Product name: {product.Name}\nPrice: {product.Price}\nDescription: {product.Description}\n===============\n");
            }

            Console.WriteLine("********** End of Task #1 **********\n\n");
        }

        private static void Task2()
        {
            Console.WriteLine("********** Task #2 **********");

            var products = Product.GetProducts()
                .Select(x => new
                {
                    ProductName = x.Name, SupplierName = x.SupplierId.Name
                });

            foreach (var product in products)
            {
                Console.WriteLine($"Product name: {product.ProductName}\nSupplier name: {product.SupplierName}\n===============\n");
            }

            Console.WriteLine("********** End of Task #2 **********\n\n");
        }

        /// <summary>
        /// If there was an integer Id instead of an object in Product model, we would do this using a Join
        /// </summary>
        private static void Task2Id()
        {
            Console.WriteLine("********** Task #2 using Supplier Id instead of an Supplier object **********");

            var products = Product.GetProducts()
                .Join(Supplier.GetSuppliers(), 
                    p => p.SupplierId.Id, // here would be SupplierId as actual integer instead of object
                    s => s.Id,
                    (p, s) => new {ProductName = p.Name, SupplierName = s.Name});

            foreach (var product in products)
            {
                Console.WriteLine($"Product name: {product.ProductName}\nSupplier name: {product.SupplierName}\n===============\n");
            }

            Console.WriteLine("********** End of Task #2 using Supplier Id instead of an Supplier object **********\n\n");
        }

        private static void Task3()
        {
            Console.WriteLine("********** Task #3 **********");

            var products = Category.GetCategories()
                .GroupJoin(Product.GetProducts(),
                    c => c.Id,
                    p => p.CategoryId.Id,
                    (c, p) => new {CategoryName = c.Name, CategoryProducts = p});

            foreach (var product in products)
            {
                Console.WriteLine($"Category name: {product.CategoryName}\nCategory count: {product.CategoryProducts.Count()}\n===============\n");
            }

            Console.WriteLine("********** End of Task #3 **********\n\n");
        }

        private static void Task4()
        {
            Console.WriteLine("********** Task #4 **********");

            var products = Supplier.GetSuppliers()
                .GroupJoin(Product.GetProducts(),
                    s => s.Id,
                    p => p.SupplierId.Id,
                    (s, p) => new {SupplierName = s.Name, ProductCount = p.Count()})
                .OrderByDescending(pCount => pCount.ProductCount);

            foreach (var product in products)
            {
                Console.WriteLine($"Supplier name: {product.SupplierName}\nProduct count: {product.ProductCount}\n===============\n");
            }

            Console.WriteLine("********** End of Task #4 **********\n\n");
        }

        private static void Task5A(int firstSupplier, int secondSupplier)
        {
            Console.WriteLine("********** Task #5A **********");

            var comparer = new Task5AComparer();

            var products = Product.GetProducts();

            var firstSupplierProducts = products.
                Where(s => s.SupplierId.Id == firstSupplier);
            var secondSupplierProducts = products
                .Where(s => s.SupplierId.Id == secondSupplier);

            var mutualProducts = firstSupplierProducts.Intersect(secondSupplierProducts, comparer);

            foreach (var product in mutualProducts)
            {
                Console.WriteLine(product.Name);
            }

            Console.WriteLine("********** End of Task #5A **********\n\n");
        }

        private static void Task5B(int supplierId)
        {
            Console.WriteLine("********** Task #5B **********");

            var comparer = new Task5BComparer();

            var products = Product.GetProducts();

            var productsOfSupplier = products
                .Where(p => p.SupplierId.Id == supplierId);
            var otherProducts = products
                .Where(p => p.SupplierId.Id != supplierId);

            var uniqueProducts = productsOfSupplier.Except(otherProducts, comparer);
                

            foreach (var product in uniqueProducts)
            {
                Console.WriteLine(product.Name);
            }

            Console.WriteLine("********** End of Task #5B **********\n\n");
        }
    }
}
