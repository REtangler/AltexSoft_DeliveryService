namespace DeliveryService.Interfaces
{
    public interface IValidator
    {
        bool CheckNumber(string input);
        bool CheckAddress(string input);
    }
}
