using System;
using AltexFood_Delivery.DAL.Models;
using AltexFood_Delivery.DAL.Repos;

namespace AltexFood_Delivery.DAL.HwTasks
{
    public static class DapperNestedTasks
    {
        public static void RunTasks(DapperRepo repo)
        {
            Console.WriteLine("***** ***** ***** ***** *****");
            Console.WriteLine($"***** {nameof(DapperNestedTasks)} *****");
            Console.WriteLine("***** ***** ***** ***** *****\n");

            {
                Console.WriteLine($"===== {nameof(repo.GetProductsNested)} =====");
                var result = repo.GetProductsNested();
                foreach (var product in result)
                {
                    Console.WriteLine($"{product.Name}, {product.Description}, {product.Price}, {product.AmountInStock}, {product.Category?.Name}");
                }
                Console.WriteLine($"===== {nameof(repo.GetProductsNested)} =====\n");
            }

            {
                Console.WriteLine($"===== {nameof(repo.GetProductByIdNested)} =====");
                var product = repo.GetProductByIdNested(12);
                Console.WriteLine($"{product.Name}, {product.Description}, {product.Price}, {product.AmountInStock}, {product.Category?.Name}");
                Console.WriteLine($"===== {nameof(repo.GetProductByIdNested)} =====\n");
            }
            //commented to not add same copy every time the program is launched
            //AddProductsNested(repo);

            {
                Console.WriteLine($"===== {nameof(repo.UpdateProductNested)} =====");
                var result = repo.UpdateProductNested(1008, Category.GetCategory(1));
                Console.WriteLine($"{result.Name}, {result.Description}, {result.Price}, {result.AmountInStock}, {result.Category.Name}");
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
                    Console.WriteLine($"{product.Name}, {product.Description}, {product.Price}, {product.AmountInStock}, {product.Category.Name}");
                }

                Console.WriteLine($"===== {nameof(repo.DeleteProductNested)} =====\n");
            }

            Console.WriteLine("***** ***** ***** ***** *****");
            Console.WriteLine($"***** {nameof(DapperNestedTasks)} *****");
            Console.WriteLine("***** ***** ***** ***** *****\n");
        }

        private static void AddProductsNested(DapperRepo repo)
        {
            Console.WriteLine($"===== {nameof(repo.AddProductNested)} =====");
            var product = new Product
            {
                Name = "AFOX GeForce GT1030",
                Description = "Budget graphics card.",
                Price = 2639.00m,
                AmountInStock = 98
            };
            var result = repo.AddProductNested(product, Category.GetCategory(2)); // put incorrect category to then update it to correct one (should be 1)
            Console.WriteLine($"{result.Name}, {result.Description}, {result.Price}, {result.AmountInStock}, {result.Category.Name}");
            Console.WriteLine($"===== {nameof(repo.AddProductNested)} =====\n");
        }
    }
}
