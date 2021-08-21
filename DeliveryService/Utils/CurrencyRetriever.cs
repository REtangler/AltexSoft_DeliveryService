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
    public class CurrencyRetriever : ICurrencyRetriever
    {
        private const string ApiKey = "YourApiKey";
        private readonly string _currencyUri = $"https://free.currconv.com/api/v7/currencies?apiKey={ApiKey}";

        private string ConvertFrom { get; }
        private IList<string> Currencies { get; set; }
        private DateTime LastCurrencyCheck { get; set; }

        public CurrencyRetriever()
        {
            ConvertFrom = "UAH";
        }

        public async Task<decimal> DeserializeResponseAsync(string convertTo)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://free.currconv.com/api/v7/convert?q={ConvertFrom}_{convertTo}&compact=ultra&apiKey={ApiKey}");
            var response = await client.SendAsync(request);

            using var streamReader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var jsonString = await streamReader.ReadToEndAsync();

            var parsedObject = JObject.Parse(jsonString);
            var exchangeRate = (decimal)parsedObject.SelectToken($"{ConvertFrom}_{convertTo}");

            return exchangeRate;
        }

        public async Task<IList<string>> GetAllCurrencies()
        {
            if (Currencies != null && LastCurrencyCheck.IsUpToDate())
                return Currencies;

            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, _currencyUri);
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
