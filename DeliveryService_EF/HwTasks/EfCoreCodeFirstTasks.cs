using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DeliveryService_EF.Data;
using DeliveryService_EF.DTOs;
using DeliveryService_EF.Models;
using Microsoft.EntityFrameworkCore;

namespace DeliveryService_EF.HwTasks
{
    public class EfCoreCodeFirstTasks
    {
        private readonly DataContext _db;

        public EfCoreCodeFirstTasks(DataContext db)
        {
            _db = db;
        }

        public void AddProducts()
        {
            var products = new List<Product>
            {
                new Product
                {
                    Name = "Strix RTX 2070",
                    Description = "Nvidia GPU capable of ray-tracing",
                    Price = 21250,
                    AmountInStock = 4,
                    CategoryId = 1,
                    Category = _db.Categories.SingleOrDefault(c => c.Id == 1),
                    SupplierId = 2,
                    Supplier = _db.Suppliers.SingleOrDefault(c => c.Id == 2),
                    Type = "RTX 2070"
                },
                new Product
                {
                    Name = "Strix RTX 2070",
                    Description = "Nvidia GPU capable of ray-tracing",
                    Price = 21250,
                    AmountInStock = 4,
                    CategoryId = 1,
                    Category = _db.Categories.SingleOrDefault(c => c.Id == 1),
                    SupplierId = 1,
                    Supplier = _db.Suppliers.SingleOrDefault(c => c.Id == 1),
                    Type = "RTX 2070"
                },
                new Product
                {
                    Name = "Radeon RX 470",
                    Description = "AMD GPU",
                    Price = 18050,
                    AmountInStock = 13,
                    CategoryId = 1,
                    Category = _db.Categories.SingleOrDefault(c => c.Id == 1),
                    SupplierId = 1,
                    Supplier = _db.Suppliers.SingleOrDefault(c => c.Id == 1),
                    Type = "RX 470"
                },
                new Product
                {
                    Name = "Intel i7-10850K",
                    Description = "Intel multi-threaded CPU",
                    Price = 5099,
                    AmountInStock = 45,
                    CategoryId = 2,
                    Category = _db.Categories.SingleOrDefault(c => c.Id == 2),
                    SupplierId = 1,
                    Supplier = _db.Suppliers.SingleOrDefault(c => c.Id == 1),
                    Type = "i7-10850K"
                },
                new Product
                {
                    Name = "Intel i7-10850K",
                    Description = "Intel multi-threaded CPU",
                    Price = 5099,
                    AmountInStock = 45,
                    CategoryId = 2,
                    Category = _db.Categories.SingleOrDefault(c => c.Id == 2),
                    SupplierId = 2,
                    Supplier = _db.Suppliers.SingleOrDefault(c => c.Id == 2),
                    Type = "i7-10850K"
                },
                new Product
                {
                    Name = "Ryzen 5040",
                    Description = "AMD performance oriented CPU",
                    Price = 4749,
                    AmountInStock = 67,
                    CategoryId = 2,
                    Category = _db.Categories.SingleOrDefault(c => c.Id == 2),
                    SupplierId = 1,
                    Supplier = _db.Suppliers.SingleOrDefault(c => c.Id == 1),
                    Type = "Ryzen 5040"
                },
                new Product
                {
                    Name = "ASRock X570",
                    Description = "ASRock motherboard targeted at creators",
                    Price = 7199,
                    AmountInStock = 102,
                    CategoryId = 3,
                    Category = _db.Categories.SingleOrDefault(c => c.Id == 3),
                    SupplierId = 1,
                    Supplier = _db.Suppliers.SingleOrDefault(c => c.Id == 1),
                    Type = "ASRock X570"
                },
                new Product
                {
                    Name = "Asus Pro Q470M",
                    Description = "Asus cutting-edge motherboard",
                    Price = 8499,
                    AmountInStock = 81,
                    CategoryId = 3,
                    Category = _db.Categories.SingleOrDefault(c => c.Id == 3),
                    SupplierId = 2,
                    Supplier = _db.Suppliers.SingleOrDefault(c => c.Id == 2),
                    Type = "Asus Pro Q470M"
                }
            };

            _db.Products.AddRange(products);
            _db.SaveChanges();
        }

        public void GetProducts()
        {
            var products = _db.Products.ToList();
            Console.WriteLine("Products in storage: " + products.Count);

            var categories = _db.Categories.ToList();
            var suppliers = _db.Suppliers.ToList();
            foreach (var product in products)
            {
                product.Category = categories.SingleOrDefault(c => c.Id == product.CategoryId);
                product.Supplier = suppliers.SingleOrDefault(s => s.Id == product.SupplierId);
                Console.WriteLine($"{product.Name}, {product.Description}, {product.Type}, {product.Price}, {product.AmountInStock}, {product.Category?.Name}, {product.Supplier?.Name}");
            }
        }

        public void AddCategories()
        {
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

            _db.Categories.AddRange(categories);
            _db.SaveChanges();
        }

        public void GetCategories()
        {
            var categories = _db.Categories.ToList();
            Console.WriteLine("Categories in storage: " + categories.Count);

            foreach (var category in categories)
            {
                Console.WriteLine($"{category.Name}, {category.Description}");
            }
        }

        public void AddSuppliers()
        {
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

            _db.Suppliers.AddRange(suppliers);
            _db.SaveChanges();
        }

        public void GetSuppliers()
        {
            var suppliers = _db.Suppliers.ToList();
            Console.WriteLine("Suppliers in storage: " + suppliers.Count);

            foreach (var supplier in suppliers)
            {
                Console.WriteLine($"{supplier.Name}, {supplier.Address}, {supplier.Email}, {supplier.ContactNumber}, {supplier.WebAddress}");
            }
        }
    }
}
