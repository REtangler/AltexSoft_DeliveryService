namespace DeliveryService.Interfaces
{
    public interface IRegEx
    {
        bool CheckNumber(string input);
        bool CheckAddress(string input);
    }
}
