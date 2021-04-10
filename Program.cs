using System;

namespace AltexSoft_DeliveryService
{
    class Program
    {
        static void Main(string[] args)
        {
            var homework = new HomeWork();
            var result = homework.InvokePriceCalculation();

            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
