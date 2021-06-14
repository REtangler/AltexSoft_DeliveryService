using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Interfaces
{
    public interface IExchangeable
    {
        Task<decimal> ExchangeCurrency(decimal money, string convertTo);
        Task<IList<string>> GetAllCurrencies();
    }
}
