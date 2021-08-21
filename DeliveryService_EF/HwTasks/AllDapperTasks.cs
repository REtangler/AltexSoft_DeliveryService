using AltexFood_Delivery.DAL.Helpers;
using AltexFood_Delivery.DAL.Repos;

namespace AltexFood_Delivery.DAL.HwTasks
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
