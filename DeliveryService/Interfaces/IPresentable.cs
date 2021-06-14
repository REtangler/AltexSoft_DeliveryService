using System.Threading.Tasks;
using DeliveryService.Models;

namespace DeliveryService.Interfaces
{
    public interface IPresentable
    {
        Task Start();
        Task StartBusinessDialogue();
        Task<int> StartClientDialogue();
        Task<int?> AddPcPartsToOrder();
        Task<int?> AddPcPeripheralsToOrder();
        PcPeripheral GetPcPeripheralInfo();
        PcPart GetPcPartInfo();
        string GetClientAddress();
        string GetClientPhoneNumber();
        Task ShowOrders();
        Task ShowPcPeripherals();
        Task ShowPcParts();
        Task ChooseCurrency();
    }
}
