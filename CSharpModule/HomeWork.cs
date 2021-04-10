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

            decimal[] _prices = prices.ToArray();
            
            for (int i = 0; i < destinations.Count(); i++)
            {
                int discount = default;

                EURtoUSD(currencies.ElementAt(i), ref _prices[i]);

                StreetPrivilege(destinations.ElementAt(i), ref _prices[i]);

                try
                {
                    NextStreetSameName(destinations.ElementAt(i), ref discount, destinations.ElementAt(i + 1));
                }
                catch (ArgumentOutOfRangeException)
                {
                    // Ignore
                }

                YoungDiscount(ref discount, infantsIds, childrenIds, i);

                _prices[i] *= (100 - discount) / 100m;
            }

            fullPrice = _prices.Sum();

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

        private void EURtoUSD(string currency, ref decimal price)
        {
            if (currency.Equals("EUR"))
                price *= 1.19m;
        }

        private void StreetPrivilege(string address, ref decimal price)
        {
            if (address.Contains("Wayne Street"))
                price += 10;
            else if (address.Contains("North Heather Street"))
                price -= 5.36m;
        }

        private void NextStreetSameName(string address, ref int discount, string destination)
        {
            string subAddress = address.Substring(4);

            if (destination.Contains(subAddress))
                discount += 15;
        }

        private void YoungDiscount(ref int discount, IEnumerable<int> infantsIds, IEnumerable<int> childrenIds, int iteration)
        {
            if (childrenIds.Contains(iteration))
                discount += 25;
            else if (infantsIds.Contains(iteration))
                discount += 50;
        }
    }
}
