namespace DeliveryService.Interfaces
{
    public interface ISerializable
    {
        string FilePath { get; }

        string FileName { get; }

        void SerializeAndSave(IStorable storage);

        IStorable DeserializeFromFile();
    }
}
