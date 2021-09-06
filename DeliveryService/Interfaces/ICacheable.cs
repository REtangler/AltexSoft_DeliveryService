using System;
using System.Collections.Generic;

namespace AltexFood_Delivery.BLL.Interfaces
{
    public interface ICacheable
    {
        void AddObjectToCache<T>(IList<T> list, Action<string> debugHandler);
        IList<T> GetObjectFromCache<T>();
    }
}
