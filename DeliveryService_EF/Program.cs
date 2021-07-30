using System;
using DeliveryService_EF.HwTasks;
using DeliveryService_EF.HWtasks;

namespace DeliveryService_EF
{
    public class Program
    {
        private static void Main()
        {
            LinqTasks.RunTasks();
            DapperHw.Run();
            EfCoreCodeFirst.RunTasks();

            Console.ReadLine();
        }
    }
}
