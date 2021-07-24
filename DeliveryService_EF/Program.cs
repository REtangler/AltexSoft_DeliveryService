using System;
using System.Linq;
using DeliveryService_EF.Comparers;
using DeliveryService_EF.Models;

namespace DeliveryService_EF
{
    public class Program
    {
        private static void Main()
        {
            Lecture2Tasks();

            Console.ReadLine();
        }

        private static void Lecture2Tasks()
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
