using System.Collections.Generic;
using DeliveryService_EF.Models;

namespace DeliveryService_EF.Comparers
{
    public class Task5AComparer : IEqualityComparer<Product>
    {
        public bool Equals(Product x, Product y)
        {
            return x.Type.Equals(y.Type);
        }

        public int GetHashCode(Product obj)
        {
            return obj.Type.GetHashCode();
        }
    }
}
