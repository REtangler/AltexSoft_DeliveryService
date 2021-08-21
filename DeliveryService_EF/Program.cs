using System;
using AltexFood_Delivery.DAL.HwTasks;

namespace AltexFood_Delivery.DAL
{
    public class Program
    {
        private static void Main()
        {
            LinqTasks.RunTasks();
            DapperHw.Run();
            EfCoreCodeFirst.RunTasks();

            Console.WriteLine("================================");
            Console.WriteLine("IRepository and IUnitOfWork Task:");

            RepoUnitOfWork.RunTasks();

            Console.ReadLine();
        }
    }
}
