using DeliveryService.Models;

namespace DeliveryService.Interfaces
{
    public interface IPresentable
    {
        int? AddPcPartsToOrder(IStorable storage);
        int? AddPcPeripheralsToOrder(IStorable storage);
        PcPeripheral GetPcPeripheralInfo(int id);
        PcPart GetPcPartInfo(int id);
        string GetClientAddress();
        string GetClientPhoneNumber();
    }
}
