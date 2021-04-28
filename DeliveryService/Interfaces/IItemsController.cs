using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryService.Models;

namespace DeliveryService.Interfaces
{
    public interface IItemsController
    {
        PcPeripheral CreatePcPeripheral(IStorable storage);
        PcPart CreatePcPart(IStorable storage);
        IStorable AddPcPartsToOrder(IStorable storage, int id);
        IStorable AddPcPeripheralsToOrder(IStorable storage, int id);
    }
}
