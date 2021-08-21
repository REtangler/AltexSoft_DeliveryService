using System;
using System.Collections.Generic;
using System.Linq;
using AltexFood_Delivery.DAL.Data;
using AltexFood_Delivery.DAL.Helpers;
using AltexFood_Delivery.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace AltexFood_Delivery.DAL.HwTasks
{
    public static class EfCoreCodeFirst
    {

        public static void RunTasks()
        {
            var configuration = ConnectionStringInitializer.Initialize();
            var db = new DataContext();
            db.Database.EnsureCreated();

            EfCoreCodeFirstTasks.db = db;

            db.Database.ExecuteSqlRaw("DELETE FROM [Products] DBCC CHECKIDENT ('EFCoreCodeFirst.dbo.Products',RESEED, 1)");
            db.Database.ExecuteSqlRaw("DELETE FROM [Categories] DBCC CHECKIDENT ('EFCoreCodeFirst.dbo.Categories',RESEED, 1)");
            db.Database.ExecuteSqlRaw("DELETE FROM [Suppliers] DBCC CHECKIDENT ('EFCoreCodeFirst.dbo.Suppliers',RESEED, 1)");

            var categories = new List<Category>
            {
                new Category
                {
                    Name = "GPU",
                    Description = "Category dedicated to - Graphics Processing Units"
                },
                new Category
                {
                    Name = "CPU",
                    Description = "Category dedicated to - Central Processing Units"
                },
                new Category
                {
                    Name = "MB",
                    Description = "Category dedicated to - Motherboards"
                }
            };
            EfCoreCodeFirstTasks.AddCategories(categories);
            var getCategories = EfCoreCodeFirstTasks.GetCategories();
            Console.WriteLine("Categories in storage: " + getCategories.Count);
            foreach (var category in getCategories)
            {
                Console.WriteLine($"{category.Name}, {category.Description}");
            }

            var suppliers = new List<Supplier>
            {
                new Supplier
                {
                    Name = "Rozetka",
                    Address = "Rozetka st. 214",
                    Email = "rozetkabusiness@rozetkamail.ua",
                    ContactNumber = "+380275568258",
                    WebAddress = "www.rozetka.ua"
                },
                new Supplier
                {
                    Name = "Prom",
                    Address = "Prom rd. 13",
                    Email = "prombusiness@prommail.ua",
                    ContactNumber = "+380457122523",
                    WebAddress = "www.prom.ua"
                }
            };
            EfCoreCodeFirstTasks.AddSuppliers(suppliers);
            var getSuppliers = EfCoreCodeFirstTasks.GetSuppliers();
            Console.WriteLine("Suppliers in storage: " + getSuppliers.Count);
            foreach (var supplier in getSuppliers)
            {
                Console.WriteLine($"{supplier.Name}, {supplier.Address}, {supplier.Email}, {supplier.ContactNumber}, {supplier.WebAddress}");
            }

            var products = new List<Product>
            {
                new Product
                {
                    Name = "Strix RTX 2070",
                    Description = "Nvidia GPU capable of ray-tracing",
                    Price = 21250,
                    AmountInStock = 4,
                    CategoryId = db.Categories.Single(c => c.Name.Equals("GPU")).Id,
                    Category = db.Categories.SingleOrDefault(c => c.Name.Equals("GPU")),
                    SupplierId = db.Suppliers.Single(s => s.Name.Equals("Prom")).Id,
                    Supplier = db.Suppliers.SingleOrDefault(s => s.Name.Equals("Prom")),
                    Type = "RTX 2070"
                },
                new Product
                {
                    Name = "Strix RTX 2070",
                    Description = "Nvidia GPU capable of ray-tracing",
                    Price = 21250,
                    AmountInStock = 4,
                    CategoryId = db.Categories.Single(c => c.Name.Equals("GPU")).Id,
                    Category = db.Categories.SingleOrDefault(c => c.Name.Equals("GPU")),
                    SupplierId = db.Suppliers.Single(s => s.Name.Equals("Rozetka")).Id,
                    Supplier = db.Suppliers.SingleOrDefault(s => s.Name.Equals("Rozetka")),
                    Type = "RTX 2070"
                },
                new Product
                {
                    Name = "Radeon RX 470",
                    Description = "AMD GPU",
                    Price = 18050,
                    AmountInStock = 13,
                    CategoryId = db.Categories.Single(c => c.Name.Equals("GPU")).Id,
                    Category = db.Categories.SingleOrDefault(c => c.Name.Equals("GPU")),
                    SupplierId = db.Suppliers.Single(s => s.Name.Equals("Rozetka")).Id,
                    Supplier = db.Suppliers.SingleOrDefault(s => s.Name.Equals("Rozetka")),
                    Type = "RX 470"
                },
                new Product
                {
                    Name = "Intel i7-10850K",
                    Description = "Intel multi-threaded CPU",
                    Price = 5099,
                    AmountInStock = 45,
                    CategoryId = db.Categories.Single(c => c.Name.Equals("CPU")).Id,
                    Category = db.Categories.SingleOrDefault(c => c.Name.Equals("CPU")),
                    SupplierId = db.Suppliers.Single(s => s.Name.Equals("Rozetka")).Id,
                    Supplier = db.Suppliers.SingleOrDefault(s => s.Name.Equals("Rozetka")),
                    Type = "i7-10850K"
                },
                new Product
                {
                    Name = "Intel i7-10850K",
                    Description = "Intel multi-threaded CPU",
                    Price = 5099,
                    AmountInStock = 45,
                    CategoryId = db.Categories.Single(c => c.Name.Equals("CPU")).Id,
                    Category = db.Categories.SingleOrDefault(c => c.Name.Equals("CPU")),
                    SupplierId = db.Suppliers.Single(s => s.Name.Equals("Prom")).Id,
                    Supplier = db.Suppliers.SingleOrDefault(s => s.Name.Equals("Prom")),
                    Type = "i7-10850K"
                },
                new Product
                {
                    Name = "Ryzen 5040",
                    Description = "AMD performance oriented CPU",
                    Price = 4749,
                    AmountInStock = 67,
                    CategoryId = db.Categories.Single(c => c.Name.Equals("CPU")).Id,
                    Category = db.Categories.SingleOrDefault(c => c.Name.Equals("CPU")),
                    SupplierId = db.Suppliers.Single(s => s.Name.Equals("Rozetka")).Id,
                    Supplier = db.Suppliers.SingleOrDefault(s => s.Name.Equals("Rozetka")),
                    Type = "Ryzen 5040"
                },
                new Product
                {
                    Name = "ASRock X570",
                    Description = "ASRock motherboard targeted at creators",
                    Price = 7199,
                    AmountInStock = 102,
                    CategoryId = db.Categories.Single(c => c.Name.Equals("MB")).Id,
                    Category = db.Categories.SingleOrDefault(c => c.Name.Equals("MB")),
                    SupplierId = db.Suppliers.Single(s => s.Name.Equals("Rozetka")).Id,
                    Supplier = db.Suppliers.SingleOrDefault(s => s.Name.Equals("Rozetka")),
                    Type = "ASRock X570"
                },
                new Product
                {
                    Name = "Asus Pro Q470M",
                    Description = "Asus cutting-edge motherboard",
                    Price = 8499,
                    AmountInStock = 81,
                    CategoryId = db.Categories.Single(c => c.Name.Equals("MB")).Id,
                    Category = db.Categories.SingleOrDefault(c => c.Name.Equals("MB")),
                    SupplierId = db.Suppliers.Single(s => s.Name.Equals("Prom")).Id,
                    Supplier = db.Suppliers.SingleOrDefault(s => s.Name.Equals("Prom")),
                    Type = "Asus Pro Q470M"
                }
            };
            EfCoreCodeFirstTasks.AddProducts(products);
            var getProducts = EfCoreCodeFirstTasks.GetProducts();
            Console.WriteLine("Products in storage: " + getProducts.Count);
            foreach (var product in getProducts)
            {
                product.Category = EfCoreCodeFirstTasks.GetCategories().SingleOrDefault(c => c.Id == product.CategoryId);
                product.Supplier = EfCoreCodeFirstTasks.GetSuppliers().SingleOrDefault(s => s.Id == product.SupplierId);
                Console.WriteLine($"{product.Name}, {product.Description}, {product.Type}, {product.Price}, {product.AmountInStock}, {product.Category?.Name}, {product.Supplier?.Name}");
            }
        }
    }
}
