using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Interfaces
{
    public interface ILogger
    {
        string FilePath { get; init; }
        string FileName { get; init; }
        void Log(string message);
    }
}
