using ReversalOfSpirit.Gameplay.Enums;

namespace ReversalOfSpirit.Gameplay.Packets
{
    public class C2S_PlayerSwapSelectionCard
    {
        public GameTerritory fromSlot;
        public GameTerritory toSlot;
        //public void Serialize(NetDataWriter writer)
        //{
        //    writer.Put((int)fromSlot);
        //    writer.Put((int)toSlot);
        //}

        //public void Deserialize(NetDataReader reader)
        //{
        //    fromSlot = (GameTerritory)reader.GetInt();
        //    toSlot = (GameTerritory)reader.GetInt();
        //}
    }
}
