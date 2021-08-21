using AltexFood_Delivery.DAL.Data;
using AltexFood_Delivery.DAL.Helpers;
using AltexFood_Delivery.DAL.Repos;

namespace AltexFood_Delivery.DAL.HwTasks
{
    public static class RepoUnitOfWork
    {
        public static void RunTasks()
        {
            var dbFactory = new DbFactory(() => new DataContext());
            var unitOfWork = new UnitOfWork(dbFactory);
            var productRepository = new ProductRepository(dbFactory);
            var repounit = new RepoUnitOfWorkTask(unitOfWork, productRepository);

            repounit.RunTasks();
            
            unitOfWork.Commit();
        }
    }
}
