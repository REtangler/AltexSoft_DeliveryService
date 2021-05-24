using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Interfaces
{
    public interface ISerializable
    {
        string FilePath { get; init; }

        string FileName { get; init; }

        void SerializeAndSave(IStorable storage);

        IStorable DeserializeFromFile();
    }
}
