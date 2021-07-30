using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper.Contrib.Extensions;
using DeliveryService_EF.DTOs;
using DeliveryService_EF.Interfaces;
using DeliveryService_EF.Models;
using Microsoft.Extensions.Configuration;

namespace DeliveryService_EF.Repos
{
    public class DapperContribRepo : IDapperRepository
    {
        private readonly IConfiguration _configuration;

        public DapperContribRepo(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IList<Product> GetProducts()
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DapperConnection")))
            {
                connection.Open();

                List<ProductDto> productsDtos = connection.GetAll<ProductDto>().ToList();

                var products = new List<Product>();
                foreach (var productsDto in productsDtos)
                {
                    products.Add(ProductDto.MapToProduct(productsDto));
                }

                return products;
            }
        }

        public IList<Product> GetProductsNested()
        {
            throw new NotImplementedException();
        }

        public Product GetProductById(int id)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DapperConnection")))
            {
                connection.Open();

                var productDto = connection.Get<ProductDto>(id);

                return ProductDto.MapToProduct(productDto);
            }
        }

        public Product GetProductByIdNested(int id)
        {
            throw new NotImplementedException();
        }

        public Product AddProduct(Product product)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DapperConnection")))
            {
                connection.Open();

                connection.Insert(ProductDto.MapToDto(product));

                var addedProduct = GetProducts().LastOrDefault();

                return addedProduct;
            }
        }

        public Product AddProductNested(Product product, Category category)
        {
            throw new NotImplementedException();
        }

        public Product UpdateProduct(int id, int amountInStock)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DapperConnection")))
            {
                connection.Open();

                var product = GetProductById(id);
                product.AmountInStock = amountInStock;

                connection.Update(ProductDto.MapToDto(product));

                return GetProductById(id);
            }
        }

        public Product UpdateProductNested(int id, Category category)
        {
            throw new NotImplementedException();
        }

        public Product DeleteProduct(int id)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DapperConnection")))
            {
                connection.Open();

                var deletedProduct = GetProductById(id);

                connection.Delete(ProductDto.MapToDto(deletedProduct));

                return deletedProduct;
            }
        }

        public IList<Product> DeleteProductNested(int id)
        {
            throw new NotImplementedException();
        }
    }
}
