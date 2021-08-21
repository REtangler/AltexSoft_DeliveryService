using System;
using DeliveryService_EF.Models;
using DeliveryService_EF.Repos;

namespace DeliveryService_EF.HwTasks
{
    public static class DapperContribTasks
    {
        public static void RunTasks(DapperContribRepo contribRepo)
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
            //AddProduct(contribRepo);

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

        private static void AddProduct(DapperContribRepo contribRepo)
        {
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
        }
    }
}
