using System;
using AltexFood_Delivery.BLL.Interfaces;
using AltexFood_Delivery.BLL.Services;
using AltexFood_Delivery.BLL.Utils;
using AltexFood_Delivery.DAL.Data;
using AltexFood_Delivery.DAL.Helpers;
using AltexFood_Delivery.DAL.Interfaces;
using AltexFood_Delivery.DAL.Repos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AltexFood_Delivery.Api.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                });
            services.AddScoped<Func<DataContext>>((provider) => provider.GetService<DataContext>);
            services.AddScoped<DbFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped(typeof(IRepository<>), typeof(Repository<>))
                .AddScoped<IProductRepository, ProductRepository>()
                .AddScoped<ICategoryRepository, CategoryRepository>();
        }

        public static IServiceCollection AddBll(this IServiceCollection services)
        {
            return services
                .AddScoped<CategoryService>()
                .AddScoped<ProductService>()
                .AddScoped<ICurrencyRetriever, CurrencyRetriever>();
        }
    }
}
