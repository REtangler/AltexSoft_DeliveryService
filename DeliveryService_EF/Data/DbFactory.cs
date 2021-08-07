using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace DeliveryService_EF.Data
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
