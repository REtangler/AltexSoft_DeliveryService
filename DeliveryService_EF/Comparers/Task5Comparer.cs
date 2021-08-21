using System.Collections.Generic;
using AltexFood_Delivery.DAL.Models;

namespace AltexFood_Delivery.DAL.Comparers
{
    public class Task5Comparer : IEqualityComparer<Product>
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
