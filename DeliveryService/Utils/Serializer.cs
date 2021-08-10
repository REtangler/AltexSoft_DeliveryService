using System;
using System.IO;
using System.Text;
using System.Text.Json;
using DeliveryService.Data;
using DeliveryService.Interfaces;

namespace DeliveryService.Utils
{
    public class Serializer : ISerializable
    {
        public string FilePath { get; }
        public string FileName { get; }

        public Serializer()
        {
            FileName = "DataStorage.json";
            FilePath = AppDomain.CurrentDomain.BaseDirectory + FileName;
        }

        public void SerializeAndSave(IStorable storage)
        {
            var serialized = JsonSerializer.Serialize(storage);

            using var file = new FileStream(FilePath, FileMode.Create);
            using var stream = new StreamWriter(file, Encoding.UTF8);

            stream.Write(serialized);
        }

        public IStorable DeserializeFromFile()
        {
            if (!File.Exists(FilePath))
                return new Storage();

            using var file = new FileStream(FilePath, FileMode.Open);
            using var stream = new StreamReader(file, Encoding.UTF8);

            var storage = stream.ReadToEnd();

            return JsonSerializer.Deserialize<Storage>(storage);
        }
    }
}
