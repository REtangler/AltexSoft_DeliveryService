using System.IO;
using Microsoft.Extensions.Configuration;

namespace AltexFood_Delivery.DAL.Helpers
{
    public static class ConnectionStringInitializer
    {
        public static IConfiguration Initialize()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }
    }
}
