using LiteNetLib.Utils;
using System.Collections.Generic;

namespace ReversalOfSpirit.Gameplay.Packets
{
    public class S2C_SelectCardSuccess : C2S_PlayerSelectionCard
    {
        public List<HandItem> handItems;

        public override void Serialize(NetDataWriter writer)
        {
            base.Serialize(writer);
            writer.Serialize(handItems);
        }

        public override void Deserialize(NetDataReader reader)
        {
            base.Deserialize(reader);
            handItems = reader.DeserializeHandItems();
        }
    }
}
