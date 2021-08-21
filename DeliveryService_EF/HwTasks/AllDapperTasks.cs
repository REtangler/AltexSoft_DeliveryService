using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryService_EF.Helpers;
using DeliveryService_EF.Repos;
using Microsoft.Extensions.Configuration;

namespace DeliveryService_EF.HwTasks
{
    public static class AllDapperTasks
    {
        public static void RunTasks()
        {
            var configuration = ConnectionStringInitializer.Initialize();
            var repo = new DapperRepo(configuration);
            var contribRepo = new DapperContribRepo(configuration);

            DapperTasks.RunTasks(repo);
            DapperNestedTasks.RunTasks(repo);

            DapperContribTasks.RunTasks(contribRepo);
        }

        
    }
}
