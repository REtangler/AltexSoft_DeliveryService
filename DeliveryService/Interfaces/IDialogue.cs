using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Interfaces
{
    public interface IDialogue
    {
        IStorable BusinessDialogue(IStorable storage);
        (IStorable, int) ClientDialogue(IStorable storage);
    }
}
