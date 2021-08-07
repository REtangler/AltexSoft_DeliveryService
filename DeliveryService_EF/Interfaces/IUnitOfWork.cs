using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService_EF.Interfaces
{
    public interface IUnitOfWork
    {
        int Commit();
    }
}
