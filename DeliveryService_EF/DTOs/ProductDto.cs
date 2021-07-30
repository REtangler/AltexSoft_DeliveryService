using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryService_EF.Models;


namespace DeliveryService_EF.DTOs
{
    [Dapper.Contrib.Extensions.Table("Products")]
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int AmountInStock { get; set; }
        public int? Category { get; set; }
        public int? Supplier { get; set; }
        public string Type { get; set; }

        public static Product MapToProduct(ProductDto productsDto)
        {
            return new Product
            {
                Id = productsDto.Id,
                Name = productsDto.Name,
                AmountInStock = productsDto.AmountInStock,
                CategoryId = productsDto.Category,
                Category = productsDto.Category == null ? null : Models.Category.GetCategory((int)productsDto.Category),
                Description = productsDto.Description,
                Price = productsDto.Price,
                SupplierId = productsDto.Supplier,
                Supplier = productsDto.Supplier == null ? null : Models.Supplier.GetSupplier((int)productsDto.Supplier),
                Type = productsDto.Type
            };
        }

        public static ProductDto MapToDto(Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                AmountInStock = product.AmountInStock,
                Category = product.Category?.Id,
                Description = product.Description,
                Price = product.Price,
                Supplier = product.Supplier?.Id,
                Type = product.Type
            };
        }
    }
}
