using LiteNetLib.Utils;

namespace ReversalOfSpirit.Gameplay.Packets
{
    public class DefaultINetSerializer: INetSerializable
    {
        public void Serialize(NetDataWriter writer)
        {
           
        }

        public void Deserialize(NetDataReader reader)
        {
           
        }
    }
    public class C2S_PlayerUseSkill : DefaultINetSerializer
    {
    }
}
