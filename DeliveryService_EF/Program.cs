using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using DeliveryService_EF.Comparers;
using DeliveryService_EF.Models;

namespace DeliveryService_EF
{
    public class Program
    {
        private static void Main()
        {
            LinqTasks();

            Console.ReadLine();
        }

        private static void LinqTasks()
        {
            var t1Products = Task1();
            foreach (var product in t1Products)
            {
                Console.WriteLine($"Product name: {product.Name}\nPrice: {product.Price}\nDescription: {product.Description}\n===============\n");
            }

            Console.WriteLine("********** End of Task #1 **********\n\n");
            Console.WriteLine("Press enter to continue to next task.");
            Console.ReadLine();
            Console.Clear();

            var t2Products = Task2();
            foreach (var product in t2Products)
            {
                Console.WriteLine($"Product name: {product.Item1}\nSupplier name: {product.Item2}\n===============\n");
            }

            Console.WriteLine("********** End of Task #2 **********\n\n");
            Console.WriteLine("Press enter to continue to next task.");
            Console.ReadLine();
            Console.Clear();

            var t2IdProducts = Task2Id();
            foreach (var product in t2IdProducts)
            {
                Console.WriteLine($"Product name: {product.Item1}\nSupplier name: {product.Item2}\n===============\n");
            }

            Console.WriteLine("********** End of Task #2 using Supplier Id instead of an Supplier object **********\n\n");
            Console.WriteLine("Press enter to continue to next task.");
            Console.ReadLine();
            Console.Clear();

            var t3Products = Task3();
            foreach (var product in t3Products)
            {
                Console.WriteLine($"Category name: {product.Item1}\nCategory count: {product.Item2.Count()}\n===============\n");
            }

            Console.WriteLine("********** End of Task #3 **********\n\n");
            Console.WriteLine("Press enter to continue to next task.");
            Console.ReadLine();
            Console.Clear();

            var t4Products = Task4();
            foreach (var product in t4Products)
            {
                Console.WriteLine($"Supplier name: {product.Item1}\nProduct count: {product.Item2}\n===============\n");
            }

            Console.WriteLine("********** End of Task #4 **********\n\n");
            Console.WriteLine("Press enter to continue to next task.");
            Console.ReadLine();
            Console.Clear();

            var mutualProducts = Task5A(1, 2);
            foreach (var product in mutualProducts)
            {
                Console.WriteLine(product.Name);
            }
            Console.WriteLine("********** End of Task #5A **********\n\n");
            Console.WriteLine("Press enter to continue to next task.");
            Console.ReadLine();
            Console.Clear();

            var uniqueProducts = Task5B(1);
            foreach (var product in uniqueProducts)
            {
                Console.WriteLine(product.Name);
            }
            Console.WriteLine("********** End of Task #5B **********\n\n");
            Console.WriteLine("Press enter exit the program.");
        }

        private static List<Product> Task1()
        {
            Console.WriteLine("********** Task #1 **********");

            var products = Product.GetProducts()
                .OrderBy(x => x.Name).ToList();

            return products;
        }

        private static List<(string, string)> Task2()
        {
            Console.WriteLine("********** Task #2 **********");

            var products = Product.GetProducts()
                .Select(x => new
                {
                    ProductName = x.Name, SupplierName = x.Supplier.Name
                });

            var pList = new List<(string, string)>();
            foreach (var product in products)
            {
                pList.Add((product.ProductName, product.SupplierName));
            }

            return pList;
        }

        /// <summary>
        /// If there was an integer Id instead of an object in Product model, we would do this using a Join
        /// </summary>
        private static List<(string, string)> Task2Id()
        {
            Console.WriteLine("********** Task #2 using Supplier Id instead of an Supplier object **********");

            var products = Product.GetProducts()
                .Join(Supplier.GetSuppliers(), 
                    p => p.Supplier.Id, // here would be Supplier as actual integer instead of object
                    s => s.Id,
                    (p, s) => new {ProductName = p.Name, SupplierName = s.Name});

            var pList = new List<(string, string)>();
            foreach (var product in products)
            {
                pList.Add((product.ProductName, product.SupplierName));
            }

            return pList;
        }

        private static List<(string, IEnumerable<Product>)> Task3()
        {
            Console.WriteLine("********** Task #3 **********");

            var products = Category.GetCategories()
                .GroupJoin(Product.GetProducts(),
                    c => c.Id,
                    p => p.Category.Id,
                    (c, p) => new {CategoryName = c.Name, CategoryProducts = p});

            var pList = new List<(string, IEnumerable<Product>)>();
            foreach (var product in products)
            {
                pList.Add((product.CategoryName, product.CategoryProducts.ToList()));
            }

            return pList;
        }

        private static List<(string, int)> Task4()
        {
            Console.WriteLine("********** Task #4 **********");

            var products = Supplier.GetSuppliers()
                .GroupJoin(Product.GetProducts(),
                    s => s.Id,
                    p => p.Supplier.Id,
                    (s, p) => new {SupplierName = s.Name, ProductCount = p.Count()})
                .OrderByDescending(pCount => pCount.ProductCount).ToList();

            var pList = new List<(string, int)>();
            foreach (var product in products)
            {
                pList.Add((product.SupplierName, product.ProductCount));
            }

            return pList;
        }

        private static List<Product> Task5A(int firstSupplier, int secondSupplier)
        {
            Console.WriteLine("********** Task #5A **********");

            var comparer = new Task5Comparer();

            var products = Product.GetProducts();

            var firstSupplierProducts = products.
                Where(s => s.Supplier.Id == firstSupplier);
            var secondSupplierProducts = products
                .Where(s => s.Supplier.Id == secondSupplier);

            var mutualProducts = firstSupplierProducts.Intersect(secondSupplierProducts, comparer);

            return mutualProducts.ToList();
        }

        private static List<Product> Task5B(int supplierId)
        {
            Console.WriteLine("********** Task #5B **********");

            var comparer = new Task5Comparer();

            var products = Product.GetProducts();

            var productsOfSupplier = products
                .Where(p => p.Supplier.Id == supplierId);
            var otherProducts = products
                .Where(p => p.Supplier.Id != supplierId);

            var uniqueProducts = productsOfSupplier.Except(otherProducts, comparer);

            return uniqueProducts.ToList();
        }
    }
}
