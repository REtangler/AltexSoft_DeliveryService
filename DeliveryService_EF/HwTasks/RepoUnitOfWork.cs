using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryService_EF.Data;
using DeliveryService_EF.Helpers;
using DeliveryService_EF.Repos;

namespace DeliveryService_EF.HwTasks
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
