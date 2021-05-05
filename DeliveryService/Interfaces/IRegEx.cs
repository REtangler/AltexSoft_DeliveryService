using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Interfaces
{
    public interface IRegEx
    {
        bool CheckNumber(string input);
        bool CheckAddress(string input);
    }
}
