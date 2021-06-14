using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DeliveryService.Extensions;
using DeliveryService.Interfaces;
using Newtonsoft.Json.Linq;

namespace DeliveryService.Utils
{
    public class CurrencyExchanger : IExchangeable
    {
        private const string CurrencyUri = "https://free.currconv.com/api/v7/currencies?apiKey=ce0787c762396ee4fc33";

        private string ConvertFrom { get; }
        private string ConvertTo { get; set; }
        private IList<string> Currencies { get; set; }
        private DateTime LastCurrencyCheck { get; set; }

        public CurrencyExchanger()
        {
            ConvertFrom = "UAH";
        }

        public async Task<decimal> ExchangeCurrency(decimal money, string convertTo)
        {
            ConvertTo = convertTo;

            var response = await GetExchangeRatesAsync();
            var exchangeRate = await DeserializeResponseAsync(response);

            return money * exchangeRate;
        }

        private async Task<Stream> GetExchangeRatesAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://free.currconv.com/api/v7/convert?q={ConvertFrom}_{ConvertTo}&compact=ultra&apiKey=ce0787c762396ee4fc33");
            var response = await client.SendAsync(request);

            return await response.Content.ReadAsStreamAsync();
        }

        private async Task<decimal> DeserializeResponseAsync(Stream responseStream)
        {
            using var streamReader = new StreamReader(responseStream);
            var jsonString = await streamReader.ReadToEndAsync();

            var parsedObject = JObject.Parse(jsonString);
            var exchangeRate = (decimal)parsedObject.SelectToken($"{ConvertFrom}_{ConvertTo}");

            return exchangeRate;
        }

        public async Task<IList<string>> GetAllCurrencies()
        {
            if (Currencies != null && LastCurrencyCheck.IsUpToDate())
                return Currencies;

            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, CurrencyUri);
            var response = await client.SendAsync(request);

            using var streamReader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var jsonString = await streamReader.ReadToEndAsync();

            var data = JObject.Parse(jsonString).SelectToken("results").Select(x => x.Last.SelectToken("id").ToString());

            Currencies = data.ToList();
            LastCurrencyCheck = DateTime.Now;

            return data.ToList();
        }
    }
}
