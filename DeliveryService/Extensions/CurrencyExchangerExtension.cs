using System;

namespace DeliveryService.Extensions
{
    public static class CurrencyExchangerExtension
    {
        public static bool IsUpToDate(this DateTime lastCheck)
        {
            return lastCheck.DayOfYear == DateTime.Now.DayOfYear;
        }
    }
}
