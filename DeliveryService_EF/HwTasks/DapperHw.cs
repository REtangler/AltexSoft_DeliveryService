﻿using System.IO;
using AltexFood_Delivery.DAL.Repos;
using Microsoft.Extensions.Configuration;

namespace AltexFood_Delivery.DAL.HwTasks
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