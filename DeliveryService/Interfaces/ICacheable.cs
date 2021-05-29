using System;
using System.Collections.Generic;

namespace DeliveryService.Interfaces
{
    public interface ICacheable
    {
        void AddList<T>(IList<T> list, Action<string> debugHandler);
        IList<T> GetList<T>();
    }
}
