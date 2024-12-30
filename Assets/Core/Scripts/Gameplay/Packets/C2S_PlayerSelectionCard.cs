using LiteNetLib.Utils;
using ReversalOfSpirit.Gameplay.Enums;

namespace ReversalOfSpirit.Gameplay.Packets
{
    public class C2S_PlayerSelectionCard : INetSerializable
    {
        public int cardId;
        public GameTerritory slot;
        public virtual void Serialize(NetDataWriter writer)
        {
            writer.Put(cardId);
            writer.Put((int)slot);
        }

        public virtual void Deserialize(NetDataReader reader)
        {
            cardId = reader.GetInt();
            slot = (GameTerritory)reader.GetInt();
        }
    }
}
