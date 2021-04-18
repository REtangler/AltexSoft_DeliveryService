using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService
{
    public interface IProduceable
    {
        void CreateProduct(int id, string name, decimal price, string manufacturer, string category);
    }
}
