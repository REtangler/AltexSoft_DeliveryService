using System;
using System.Collections.Generic;
using System.Linq;
using DeliveryService.Interfaces;

namespace DeliveryService.Data
{
    public class Cache : ICacheable
    {
        private readonly IList<object> _currentList;
        private readonly IList<DateTime> _timings;

        public Cache()
        {
            _currentList = new List<object>(2);
            _timings = new List<DateTime>(2);
        }

        public void AddList<T>(IList<T> list, Action<string> debugHandler)
        {
            if (_currentList.Count < 2)
            {
                _currentList.Add(list);
                _timings.Add(DateTime.Now);
            }
            else
            {
                _currentList.RemoveAt(0);
                _timings.RemoveAt(0);

                _currentList.Add(list);
                _timings.Add(DateTime.Now);
            }
            debugHandler.Invoke(typeof(T).Name);
        }

        public IList<T> GetList<T>()
        {
            var tempList = (IList<T>)_currentList.SingleOrDefault(x => typeof(List<T>) == x.GetType());
            if (tempList is null) 
                return null;

            var ind = _currentList.IndexOf(tempList);
            if (Math.Abs(DateTime.Now.Minute - _timings[ind].Minute) > 2)
            {
                _currentList.RemoveAt(ind);
                _timings.RemoveAt(ind);
                return null;
            }

            return tempList;
        }
    }
}
