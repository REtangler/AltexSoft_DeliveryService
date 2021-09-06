using System.Collections.Generic;
using System.Threading.Tasks;

namespace AltexFood_Delivery.BLL.Interfaces
{
    public interface ICurrencyRetriever
    {
        Task<decimal> GetExchangeRatesAsync(string convertTo);
        Task<IList<string>> GetAllCurrencies();
    }
}
