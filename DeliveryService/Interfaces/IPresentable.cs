using DeliveryService.Models;

namespace DeliveryService.Interfaces
{
    public interface IPresentable
    {
        void Start();
        void StartBusinessDialogue();
        int StartClientDialogue();
        int? AddPcPartsToOrder();
        int? AddPcPeripheralsToOrder();
        PcPeripheral GetPcPeripheralInfo();
        PcPart GetPcPartInfo();
        string GetClientAddress();
        string GetClientPhoneNumber();
    }
}
