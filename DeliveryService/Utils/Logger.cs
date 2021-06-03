using System;
using System.IO;
using DeliveryService.Interfaces;

namespace DeliveryService.Utils
{
    public class Logger : ILogger
    {
        public string FilePath { get; init; }
        public string FileName { get; init; }

        public Logger()
        {
            FileName = DateTime.Now.ToShortDateString() + ".txt";
            FilePath = AppDomain.CurrentDomain.BaseDirectory + FileName;
        }

        public void Log(string message)
        {
            using var fileStream = new FileStream(FilePath, FileMode.Append);
            using var streamWriter = new StreamWriter(fileStream);

            var logEntry = $"Log Entry: {DateTime.Now.ToLongDateString()} {DateTime.Now.ToLongTimeString()}\n{message}\n\n";
            streamWriter.WriteLine(logEntry);
        }
    }
}
