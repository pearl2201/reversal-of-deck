using System.Collections.Generic;

namespace ReversalOfSpirit.Gameplay.Ros
{
    public interface IPlayerDataService
    {
        public PlayerProfile GetPlayerProfile(int peerId);

        public PlayerProfile GetBotPlayerProfile(int peerId);
    }
    [System.Serializable]
    public class PlayerProfile
    {
        public string id;
        public int elo;
        public int rankId;
        public string name ;
        public PlayerArcaneData arcane ;

        public List<PlayerTalentData> talents ;

        public List<PlayerCardData> playerCardData ;
    }
    [System.Serializable]
    public class PlayerArcaneData
    {
        public int arcaneId ;

        public int level ;
    }
    [System.Serializable]
    public class PlayerTalentData
    {
        public int talentId ;

        public int level ;
    }

    [System.Serializable]
    public class PlayerCardData
    {
        public int cardId ;

        public int level ;
    }

}
