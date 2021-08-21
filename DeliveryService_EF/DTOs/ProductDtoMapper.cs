using AltexFood_Delivery.DAL.Models;

namespace AltexFood_Delivery.DAL.DTOs
{
    public static class ProductDtoMapper
    {
        public static Product MapToProduct(ProductDto productsDto)
        {
            return new Product
            {
                Id = productsDto.Id,
                Name = productsDto.Name,
                AmountInStock = productsDto.AmountInStock,
                CategoryId = productsDto.CategoryId,
                Category = Models.Category.GetCategory(productsDto.CategoryId),
                Description = productsDto.Description,
                Price = productsDto.Price,
                SupplierId = productsDto.SupplierId,
                Supplier = Models.Supplier.GetSupplier(productsDto.SupplierId),
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
                CategoryId = product.CategoryId,
                Description = product.Description,
                Price = product.Price,
                SupplierId = product.SupplierId,
                Type = product.Type
            };
        }
    }
}
