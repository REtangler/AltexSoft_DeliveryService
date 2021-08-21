using System;
using System.Collections.Generic;
using System.Linq;
using AltexFood_Delivery.BLL.Interfaces;

namespace AltexFood_Delivery.BLL.Data
{
    public class Cache : ICacheable
    {
        private static readonly object Lock = new object();
        private readonly IList<object> _cachedObjects;
        private readonly IList<DateTime> _timings;

        public Cache()
        {
            _cachedObjects = new List<object>(2);
            _timings = new List<DateTime>(2);
        }

        public void AddObjectToCache<T>(IList<T> list, Action<string> debugHandler)
        {
            lock (Lock)
            {
                if (_cachedObjects.Count < 2)
                {
                    _cachedObjects.Add(list);
                    _timings.Add(DateTime.Now);
                }
                else
                {
                    _cachedObjects.RemoveAt(0);
                    _timings.RemoveAt(0);

                    _cachedObjects.Add(list);
                    _timings.Add(DateTime.Now);
                }

                debugHandler.Invoke(typeof(T).Name);
            }
        }

        public IList<T> GetObjectFromCache<T>()
        {
            lock (Lock)
            {
                var tempList = (IList<T>)_cachedObjects.SingleOrDefault(x => typeof(List<T>) == x.GetType());
                if (tempList is null) 
                    return null;

                var indexOfList = _cachedObjects.IndexOf(tempList);

                if (Math.Abs(DateTime.Now.Minute - _timings[indexOfList].Minute) > 2)
                {
                    _cachedObjects.RemoveAt(indexOfList);
                    _timings.RemoveAt(indexOfList);
                    return null;
                }

                return tempList;
            }
        }
    }
}
