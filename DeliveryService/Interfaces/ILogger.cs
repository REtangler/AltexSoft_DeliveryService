namespace AltexFood_Delivery.BLL.Interfaces
{
    public interface ILogger
    {
        string FilePath { get; init; }
        string FileName { get; init; }
        void Log(string message);
    }
}
