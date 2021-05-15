using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Logic
{
    public class Logger
    {
        private string FilePath { get; init; }
        private string FileName { get; init; }

        public Logger()
        {
            FileName = DateTime.Now.ToShortDateString() + ".txt";
            FilePath = AppDomain.CurrentDomain.BaseDirectory + "/" + FileName;
        }

        public void Log(string message)
        {
            using var f = new FileStream(FilePath, FileMode.Append);
            using var w = new StreamWriter(f);
            
            w.WriteLine($"Log Entry: {DateTime.Now.ToLongDateString()} {DateTime.Now.ToLongTimeString()}");
            w.WriteLine(message);
            w.WriteLine();
        }
    }
}
