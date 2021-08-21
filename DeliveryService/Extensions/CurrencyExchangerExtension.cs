using System;

namespace AltexFood_Delivery.BLL.Extensions
{
    public static class CurrencyExchangerExtension
    {
        public static bool IsUpToDate(this DateTime lastCheck)
        {
            return lastCheck.DayOfYear == DateTime.Now.DayOfYear;
        }
    }
}
