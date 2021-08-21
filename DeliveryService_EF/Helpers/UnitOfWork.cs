using AltexFood_Delivery.DAL.Data;
using AltexFood_Delivery.DAL.Interfaces;

namespace AltexFood_Delivery.DAL.Helpers
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
