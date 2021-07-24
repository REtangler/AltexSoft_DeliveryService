using System.Collections.Generic;

namespace DeliveryService_EF.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int AmountInStock { get; set; }
        public Category CategoryId { get; set; }
        public Supplier SupplierId { get; set; }
        public string Type { get; set; }

        public static IList<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Strix RTX 2070",
                    Description = "Nvidia GPU capable of ray-tracing",
                    Price = 21250,
                    AmountInStock = 4,
                    CategoryId = Category.GetCategory(1),
                    SupplierId = Supplier.GetSupplier(2),
                    Type = "RTX 2070"
                },
                new Product
                {
                    Id = 2,
                    Name = "Strix RTX 2070",
                    Description = "Nvidia GPU capable of ray-tracing",
                    Price = 21250,
                    AmountInStock = 4,
                    CategoryId = Category.GetCategory(1),
                    SupplierId = Supplier.GetSupplier(1),
                    Type = "RTX 2070"
                },
                new Product
                {
                    Id = 3,
                    Name = "Radeon RX 470",
                    Description = "AMD GPU",
                    Price = 18050,
                    AmountInStock = 13,
                    CategoryId = Category.GetCategory(1),
                    SupplierId = Supplier.GetSupplier(1),
                    Type = "RX 470"
                },
                new Product
                {
                    Id = 4,
                    Name = "Intel i7-10850K",
                    Description = "Intel multi-threaded CPU",
                    Price = 5099,
                    AmountInStock = 45,
                    CategoryId = Category.GetCategory(2),
                    SupplierId = Supplier.GetSupplier(1),
                    Type = "i7-10850K"
                },
                new Product
                {
                    Id = 5,
                    Name = "Intel i7-10850K",
                    Description = "Intel multi-threaded CPU",
                    Price = 5099,
                    AmountInStock = 45,
                    CategoryId = Category.GetCategory(2),
                    SupplierId = Supplier.GetSupplier(2),
                    Type = "i7-10850K"
                },
                new Product
                {
                    Id = 6,
                    Name = "Ryzen 5040",
                    Description = "AMD performance oriented CPU",
                    Price = 4749,
                    AmountInStock = 67,
                    CategoryId = Category.GetCategory(2),
                    SupplierId = Supplier.GetSupplier(1),
                    Type = "Ryzen 5040"
                },
                new Product
                {
                    Id = 7,
                    Name = "ASRock X570",
                    Description = "ASRock motherboard targeted at creators",
                    Price = 7199,
                    AmountInStock = 102,
                    CategoryId = Category.GetCategory(3),
                    SupplierId = Supplier.GetSupplier(1),
                    Type = "ASRock X570"
                },
                new Product
                {
                    Id = 8,
                    Name = "Asus Pro Q470M",
                    Description = "Asus cutting-edge motherboard",
                    Price = 8499,
                    AmountInStock = 81,
                    CategoryId = Category.GetCategory(3),
                    SupplierId = Supplier.GetSupplier(2),
                    Type = "Asus Pro Q470M"
                }
            };
        }
    }
}
