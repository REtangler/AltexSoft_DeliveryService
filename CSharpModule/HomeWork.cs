using System;
using System.Collections.Generic;
using System.Linq;

namespace AltexSoft_DeliveryService
{
    internal class HomeWork
    {
        private const int InfantDiscount = 50;
        private const int ChildrenDiscount = 25;
        private const int SameStreetDiscount = 15;

        private const decimal StreetPrivilegeDiscount = 5.36m;
        private const decimal StreetPrivilegePenalty = 10;

        private const decimal EurToUsdExchangeRate = 1.19m;

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

            var pricesArray = prices.ToArray();
            
            for (int i = 0; i < destinations.Count(); i++)
            {
                int discount = default;

                pricesArray[i] = ConvertEurToUsd(currencies.ElementAt(i), pricesArray[i]);

                pricesArray[i] = SetStreetPrice(destinations.ElementAt(i), pricesArray[i]);

                if (i > 0)
                    discount = SetSameStreetDiscount(destinations.ElementAt(i), discount, destinations.ElementAt(i - 1));

                discount = SetYoungDiscount(discount, infantsIds, childrenIds, i);

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

        private decimal ConvertEurToUsd(string currency, decimal price)
        {
            if (currency.Equals("EUR"))
                return price * EurToUsdExchangeRate;
            return price;
        }

        private decimal SetStreetPrice(string address, decimal price)
        {
            if (address.Contains("Wayne Street"))
                price += StreetPrivilegePenalty;
            else if (address.Contains("North Heather Street"))
                price -= StreetPrivilegeDiscount;
            return price;
        }

        private int SetSameStreetDiscount(string address, int discount, string prevAddress)
        {
            var subAddress = address.Substring(address.IndexOf(' ') + 1);

            if (prevAddress.Contains(subAddress))
                discount += SameStreetDiscount;
            return discount;
        }

        private int SetYoungDiscount(int discount, IEnumerable<int> infantsIds, IEnumerable<int> childrenIds, int iteration)
        {
            if (childrenIds.Contains(iteration))
                discount += ChildrenDiscount;
            else if (infantsIds.Contains(iteration))
                discount += InfantDiscount;
            return discount;
        }
    }
}
