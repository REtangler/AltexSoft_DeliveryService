using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryService_EF.Data;
using DeliveryService_EF.Interfaces;

namespace DeliveryService_EF.Helpers
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbFactory _dbFactory;

        public UnitOfWork(DbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public int Commit()
        {
            return _dbFactory.DbContext.SaveChanges();
        }
    }
}
