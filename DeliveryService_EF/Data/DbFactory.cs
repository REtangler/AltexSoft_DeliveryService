using System;
using Microsoft.EntityFrameworkCore;

namespace AltexFood_Delivery.DAL.Data
{
    public class DbFactory
    {
        private Func<DataContext> _instanceFunc;
        private DbContext _dbContext;
        public DbContext DbContext => _dbContext ??= _instanceFunc.Invoke();

        public DbFactory(Func<DataContext> dbContextFactory)
        {
            _instanceFunc = dbContextFactory;
        }
    }
}
