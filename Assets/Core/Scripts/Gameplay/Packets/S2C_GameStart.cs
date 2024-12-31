using System.Collections.Generic;

namespace ReversalOfSpirit.Gameplay.Packets
{
    public class S2C_GameStart //: INetSerializable
    {
        public List<PlayerShortInfo> players;

        //public void Serialize(NetDataWriter writer)
        //{
        //    writer.Serialize(players);
        //}

        //public void Deserialize(NetDataReader reader)
        //{
        //    players = new List<PlayerShortInfo>();
        //    players = reader.Deserialize<PlayerShortInfo>();
        //}
    }

    public class PlayerShortInfo //: INetSerializable
    {
        public string playerId;

        public int id;

        public string name;

        public int rankId;

        public int elo;

        //public void Serialize(NetDataWriter writer)
        //{
        //    writer.Put(playerId);
        //    writer.Put(id);
        //    writer.Put(name);
        //    writer.Put(rankId);
        //    writer.Put(elo);
        //}

        //public void Deserialize(NetDataReader reader)
        //{
        //    playerId = reader.GetString();
        //    id = reader.GetInt();
        //    name = reader.GetString();
        //    rankId = reader.GetInt();
        //    elo = reader.GetInt();
        //}
    }

    public class S2C_GameSetup //: INetSerializable
    {
        public List<PlayerBaseStat> players;
        //public void Serialize(NetDataWriter writer)
        //{
        //    writer.Serialize(players);
        //}

        //public void Deserialize(NetDataReader reader)
        //{
        //    players = new List<PlayerBaseStat>();
        //    players = reader.Deserialize<PlayerBaseStat>();
        //}
    }

    public class PlayerBaseStat //: INetSerializable
    {
        public int id;
        public int currentHp;
        public int totalHp;
        public int currentMana;
        public int totalMana;
        public int currentArmor;
        public int totalArmor;

        //public void Serialize(NetDataWriter writer)
        //{
        //    writer.Put(id);
        //    writer.Put(currentHp);
        //    writer.Put(totalHp);
        //    writer.Put(currentMana);
        //    writer.Put(totalMana);
        //    writer.Put(currentArmor);
        //    writer.Put(totalArmor);
        //}

        //public void Deserialize(NetDataReader reader)
        //{
        //    id = reader.GetInt();
        //    currentHp = reader.GetInt();
        //    totalHp = reader.GetInt();
        //    currentMana = reader.GetInt();
        //    totalMana = reader.GetInt();
        //    currentArmor = reader.GetInt();
        //    totalArmor = reader.GetInt();
        //}
    }
}
