using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DeliveryService.Interfaces
{
    public interface ICurrencyRetriever
    {
        string ConvertTo { get; set; }
        Task<Stream> GetExchangeRatesAsync();
        Task<decimal> DeserializeResponseAsync(Stream responseStream);
        Task<IList<string>> GetAllCurrencies();
    }
}
