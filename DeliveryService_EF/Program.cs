using System;
using System.IO;
using DeliveryService_EF.HwTasks;
using DeliveryService_EF.Repos;
using Microsoft.Extensions.Configuration;

namespace DeliveryService_EF
{
    public class Program
    {
        private static void Main()
        {
            var configuration = Initialize();
            var repo = new DapperRepo(configuration);
            var contribRepo = new DapperContribRepo(configuration);

            DapperTasks.RunTasks(repo);
            DapperNestedTasks.RunTasks(repo);

            DapperContribTasks.RunTasks(contribRepo);

            Console.ReadLine();
        }

        private static IConfiguration Initialize()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }
    }
}
