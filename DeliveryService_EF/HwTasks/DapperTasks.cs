using System;
using AltexFood_Delivery.DAL.Models;
using AltexFood_Delivery.DAL.Repos;

namespace AltexFood_Delivery.DAL.HwTasks
{
    public static class DapperTasks
    {
        public static void RunTasks(DapperRepo repo)
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
            //AddProduct(repo);

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

        private static void AddProduct(DapperRepo repo)
        {
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
        }
    }
}
