using System;
using System.Collections.Generic;

namespace DeliveryService.Interfaces
{
    public interface ICacheable
    {
        void AddObjectToCache<T>(IList<T> list, Action<string> debugHandler);
        IList<T> GetObjectFromCache<T>();
    }
}
