using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using Dapper;
using DeliveryService_EF.Interfaces;
using DeliveryService_EF.Models;
using Microsoft.Extensions.Configuration;

namespace DeliveryService_EF.Repos
{
    public class DapperRepo : IDapperRepository
    {
        private readonly IConfiguration _configuration;

        public DapperRepo(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IList<Product> GetProducts()
        {
            const string sql = "SELECT [Id], [Name], [Description], [Price], [AmountInStock] FROM [dbo].[Products]";

            using var connection = new SqlConnection(_configuration.GetConnectionString("DapperConnection"));

            connection.Open();

            var products = connection.Query<Product>(sql).ToList();

            return products;
            
        }

        public IList<Product> GetProductsNested()
        {
            var sql =
                "SELECT [Products].[Id], [Products].[Name], [Products].[Description], [Price], [AmountInStock], [Categories].[Id], [Categories].[Name], [Categories].[Description] " +
                "FROM [dbo].[Products] LEFT JOIN [dbo].[Categories] " +
                "ON Categories.Id = Products.CategoryId ";

            using var connection = new SqlConnection(_configuration.GetConnectionString("DapperConnection"));

            connection.Open();

            var products = connection.Query<Product, Category, Product>(sql,
                    (product, category) =>
                    {
                        product.Category = category;
                        return product;
                    })
                .Distinct()
                .ToList();

            return products;
        }

        public Product GetProductById(int id)
        {
            var sql = "SELECT [Id], [Name], [Description], [Price], [AmountInStock] FROM [dbo].[Products] WHERE Products.Id = @Id";

            using var connection = new SqlConnection(_configuration.GetConnectionString("DapperConnection"));

            connection.Open();

            var products = connection.Query<Product>(sql, new {Id = id}).ToList();

            return products.SingleOrDefault();
        }

        public Product GetProductByIdNested(int id) // rewrite to not call other method
        {
            var products = GetProductsNested();
            return products.SingleOrDefault(x => x.Id == id);
        }

        public Product AddProduct(Product product)
        {
            var sql = "INSERT INTO [dbo].[Products] " +
                      "([Name] ,[Description] ,[Price] ,[AmountInStock]) " +
                      $"VALUES ('{product.Name}' ,'{product.Description}' ,{product.Price.ToString(CultureInfo.InvariantCulture)} ,{product.AmountInStock})";

            using var connection = new SqlConnection(_configuration.GetConnectionString("DapperConnection"));

            connection.Open();

            connection.Query<Product>(sql);

            var addedProduct = GetProducts().LastOrDefault();

            return addedProduct;
        }

        public Product AddProductNested(Product product, Category category)
        {
            var sql = "INSERT INTO [dbo].[Products] " +
                      "([Name] ,[Description] ,[Price] ,[AmountInStock], [CategoryId]) " +
                      $"VALUES (@ProductName, @ProductDescription, @ProductPrice, @ProductAmountInStock, @ProductCategoryId)";

            using var connection = new SqlConnection(_configuration.GetConnectionString("DapperConnection"));

            connection.Open();

            connection.Execute(sql,
                new {
                    ProductName = product.Name, 
                    ProductDescription = product.Description, 
                    ProductPrice = product.Price.ToString(CultureInfo.InvariantCulture), 
                    ProductAmountInStock = product.AmountInStock, 
                    ProductCategory = category.Id

                });


            var addedProduct = GetProductsNested().LastOrDefault();

            return addedProduct;
        }

        public Product UpdateProduct(int id, int amountInStock)
        {
            var sql = $"UPDATE [dbo].[Products] SET [AmountInStock] = {amountInStock} WHERE Products.Id = @ID";

            using var connection = new SqlConnection(_configuration.GetConnectionString("DapperConnection"));

            connection.Open();

            connection.Query<Product>(sql, new {Id = id});

            return GetProductById(id);
        }

        public Product UpdateProductNested(int id, Category category)
        {
            var sql = "UPDATE [dbo].[Products] SET [Category] = @CategoryId WHERE Products.Id = @ID";

            using var connection = new SqlConnection(_configuration.GetConnectionString("DapperConnection"));

            connection.Open();

            connection.Execute(sql, new {Id = id, Category = category.Id});

            return GetProductByIdNested(id);
        }

        public Product DeleteProduct(int id)
        {
            var sql = $"DELETE FROM [dbo].[Products] WHERE Products.Id = {id}";

            using var connection = new SqlConnection(_configuration.GetConnectionString("DapperConnection"));

            connection.Open();

            var deletedProduct = GetProductById(id);

            connection.Query<Product>(sql);

            return deletedProduct;
        }

        public IList<Product> DeleteProductNested(int categoryId)
        {
            var sqlGetDeleted = "SELECT [Id], [Name], [Description], [Price], [AmountInStock], [CategoryId] " +
                                "FROM [dbo].[Products] WHERE Products.CategoryId = @Category";
            var sql = "DELETE FROM [dbo].[Products] WHERE Products.CategoryId = @Category";

            using var connection = new SqlConnection(_configuration.GetConnectionString("DapperConnection"));

            connection.Open();

            var deletedProducts = connection.Query<Product, Category, Product>(sqlGetDeleted,
                    (product, category) =>
                    {
                        product.Category = category;
                        return product;
                    },
                    new {Category = categoryId},
                    splitOn: "Category")
                .Distinct()
                .ToList();;

            connection.Execute(sql, new {Category = categoryId});

            return deletedProducts;
        }
    }
}
