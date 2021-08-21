﻿using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DeliveryService.Interfaces
{
    public interface ICurrencyRetriever
    {
        Task<decimal> GetExchangeRatesAsync(string convertTo);
        Task<IList<string>> GetAllCurrencies();
    }
}
