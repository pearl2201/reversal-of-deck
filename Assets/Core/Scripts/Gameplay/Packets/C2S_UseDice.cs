using LiteNetLib.Utils;
using System.Collections.Generic;

namespace ReversalOfSpirit.Gameplay.Packets
{
    public class C2S_UseDice : INetSerializable
    {
        public List<SerializedVector2Int> swapHandItems;
        public void Serialize(NetDataWriter writer)
        {
            writer.Serialize(swapHandItems);
        }

        public void Deserialize(NetDataReader reader)
        {
            swapHandItems = reader.Deserialize<SerializedVector2Int>();
        }
    }

    public class SerializedVector2Int : INetSerializable
    {
        public int x;
        public int y;

        public void Serialize(NetDataWriter writer)
        {
            writer.Put(x);
            writer.Put(y);
        }

        public void Deserialize(NetDataReader reader)
        {
            x = reader.GetInt();
            y = reader.GetInt();
        }
    }


}
