using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryService_EF.Repos;
using Microsoft.Extensions.Configuration;

namespace DeliveryService_EF.HwTasks
{
    public static class DapperHw
    {
        public static void Run()
        {
            var configuration = Initialize();
            var repo = new DapperRepo(configuration);
            var contribRepo = new DapperContribRepo(configuration);

            DapperTasks.RunTasks(repo);
            DapperNestedTasks.RunTasks(repo);

            DapperContribTasks.RunTasks(contribRepo);
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
