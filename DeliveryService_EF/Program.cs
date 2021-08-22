using System;
using AltexFood_Delivery.DAL.HwTasks;

namespace AltexFood_Delivery.DAL
{
    public class Program
    {
        private static void Main()
        {
            RepoUnitOfWork.RunTasks();

            Console.ReadLine();
        }
    }
}
