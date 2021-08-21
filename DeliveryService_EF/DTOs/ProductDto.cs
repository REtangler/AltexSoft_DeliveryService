using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using DeliveryService_EF.Models;

namespace DeliveryService_EF.DTOs
{
    [Table("Products")]
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int AmountInStock { get; set; }
        public int? CategoryId { get; set; }
        public int? SupplierId { get; set; }
        public string Type { get; set; }

        public static Product MapToProduct(ProductDto productsDto)
        {
            return new Product
            {
                Id = productsDto.Id,
                Name = productsDto.Name,
                AmountInStock = productsDto.AmountInStock,
                Category = productsDto.CategoryId == null ? null : Category.GetCategory((int)productsDto.CategoryId),
                Description = productsDto.Description,
                Price = productsDto.Price,
                Supplier = productsDto.SupplierId == null ? null : Supplier.GetSupplier((int)productsDto.SupplierId),
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
                CategoryId = product.Category?.Id,
                Description = product.Description,
                Price = product.Price,
                SupplierId = product.Supplier?.Id,
                Type = product.Type
            };
        }
    }
}
