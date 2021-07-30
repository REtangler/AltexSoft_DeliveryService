using System;
using System.IO;
using DeliveryService_EF.HwTasks;
using DeliveryService_EF.Repos;
using Microsoft.Extensions.Configuration;

namespace DeliveryService_EF
{
    public class Program
    {
        private static void Main()
        {
            EfCoreCodeFirst.RunTasks();

            Console.ReadLine();
        }
    }
}
