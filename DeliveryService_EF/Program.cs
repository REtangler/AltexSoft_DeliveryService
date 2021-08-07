using System;
using System.IO;
using DeliveryService_EF.Data;
using DeliveryService_EF.Helpers;
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

            Console.WriteLine("================================");
            Console.WriteLine("IRepository and IUnitOfWork Task:");

            RepoUnitOfWork.RunTasks();

            Console.ReadLine();
        }
    }
}
