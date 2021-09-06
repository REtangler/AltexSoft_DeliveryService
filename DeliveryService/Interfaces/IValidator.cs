namespace AltexFood_Delivery.BLL.Interfaces
{
    public interface IValidator
    {
        bool CheckNumber(string input);
        bool CheckAddress(string input);
    }
}
