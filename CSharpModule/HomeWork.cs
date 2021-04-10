using System;
using System.Collections.Generic;
using System.Linq;

namespace AltexSoft_DeliveryService
{
    internal class HomeWork
    {
        private decimal GetFullPrice(
            IEnumerable<string> destinations,
            IEnumerable<string> clients,
            IEnumerable<int> infantsIds,
            IEnumerable<int> childrenIds,
            IEnumerable<decimal> prices,
            IEnumerable<string> currencies)
        {
            return CalculatePrice(destinations, clients, infantsIds, childrenIds, prices, currencies);
        }

        public decimal InvokePriceCalculation()
        {
            var destinations = new[]
            {
                "949 Fairfield Court, Madison Heights, MI 48071",
                "367 Wayne Street, Hendersonville, NC 28792",
                "910 North Heather Street, Cocoa, FL 32927",
                "911 North Heather Street, Cocoa, FL 32927",
                "706 Tarkiln Hill Ave, Middleburg, FL 32068"
            };

            var clients = new[]
            {
                "Autumn Baldwin",
                "Jorge Hoffman",
                "Amiah Simmons",
                "Sariah Bennett",
                "Xavier Bowers"
            };

            var infantsIds = new[] { 2 };
            var childrenIds = new[] { 3, 4 };

            var prices = new[] { 100, 25.23m, 58, 23.12m, 125 };
            var currencies = new[] { "USD", "USD", "EUR", "USD", "USD" };

            return GetFullPrice(destinations, clients, infantsIds, childrenIds, prices, currencies);
        }

        private decimal CalculatePrice(IEnumerable<string> destinations,
            IEnumerable<string> clients,
            IEnumerable<int> infantsIds,
            IEnumerable<int> childrenIds,
            IEnumerable<decimal> prices,
            IEnumerable<string> currencies)
        {
            decimal fullPrice = default;
            
            if (!ValidateData(destinations, clients, prices, currencies)) return fullPrice;

            decimal[] pricesArray = prices.ToArray();
            
            for (int i = 0; i < destinations.Count(); i++)
            {
                int discount = default;

                ConvertEURtoUSD(currencies.ElementAt(i), ref pricesArray[i]);

                SetStreetPrice(destinations.ElementAt(i), ref pricesArray[i]);

                if (i > 0)
                    SetSameStreetDiscount(destinations.ElementAt(i), ref discount, destinations.ElementAt(i - 1));

                SetYoungDiscount(ref discount, infantsIds, childrenIds, i);

                pricesArray[i] *= (100 - discount) / 100m;
            }

            fullPrice = pricesArray.Sum();

            return fullPrice;
        }

        private bool ValidateData(IEnumerable<string> destinations,
            IEnumerable<string> clients,
            IEnumerable<decimal> prices,
            IEnumerable<string> currencies)
        {
            return destinations.Count() == clients.Count() && 
                            clients.Count() == prices.Count() &&
                            prices.Count() == currencies.Count();
        }

        private void ConvertEURtoUSD(string currency, ref decimal price)
        {
            if (currency.Equals("EUR"))
                price *= 1.19m;
        }

        private void SetStreetPrice(string address, ref decimal price)
        {
            if (address.Contains("Wayne Street"))
                price += 10;
            else if (address.Contains("North Heather Street"))
                price -= 5.36m;
        }

        private void SetSameStreetDiscount(string address, ref int discount, string prevAddress)
        {
            string subAddress = address.Substring(address.IndexOf(' ') + 1);

            if (prevAddress.Contains(subAddress))
                discount += 15;
        }

        private void SetYoungDiscount(ref int discount, IEnumerable<int> infantsIds, IEnumerable<int> childrenIds, int iteration)
        {
            if (childrenIds.Contains(iteration))
                discount += 25;
            else if (infantsIds.Contains(iteration))
                discount += 50;
        }
    }
}
