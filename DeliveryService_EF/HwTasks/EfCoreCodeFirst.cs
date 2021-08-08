using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DeliveryService_EF.Data;
using DeliveryService_EF.Helpers;
using Microsoft.EntityFrameworkCore;

namespace DeliveryService_EF.HwTasks
{
    public static class EfCoreCodeFirst
    {

        public static void RunTasks()
        {
            var configuration = ConnectionStringInitializer.Initialize();
            var db = new DataContext();
            db.Database.EnsureCreated();

            EfCoreCodeFirstTasks._db = db;

            db.Database.ExecuteSqlRaw("DELETE FROM [Products] DBCC CHECKIDENT ('EFCoreCodeFirst.dbo.Products',RESEED, 1)");
            db.Database.ExecuteSqlRaw("DELETE FROM [Categories] DBCC CHECKIDENT ('EFCoreCodeFirst.dbo.Categories',RESEED, 1)");
            db.Database.ExecuteSqlRaw("DELETE FROM [Suppliers] DBCC CHECKIDENT ('EFCoreCodeFirst.dbo.Suppliers',RESEED, 1)");

            EfCoreCodeFirstTasks.AddCategories();
            EfCoreCodeFirstTasks.GetCategories();

            EfCoreCodeFirstTasks.AddSuppliers();
            EfCoreCodeFirstTasks.GetSuppliers();

            EfCoreCodeFirstTasks.AddProducts();
            EfCoreCodeFirstTasks.GetProducts();
        }
    }
}
