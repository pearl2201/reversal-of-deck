using DarkRift.Server.Plugins.Matchmaking;
using Mirror;

namespace Ros
{
    public class EloMatchmaker : RankingMatchmaker<MatchmakingData>
    {
        public override float GetSuitabilityMetric(MatchmakingData entity1, MatchmakingData entity2, MatchRankingContext<MatchmakingData> context)
        {
            MatchmakerRankingBuilder builder = new MatchmakerRankingBuilder();

            builder.MinimiseDifferenceLinear(entity1.elo, entity2.elo, 100, 0.7f);
            //builder.NotEqual(entity1.Class, entity2.Class, 0.3);

            return builder.Ranking;
        }
    }

    public class MatchmakingData
    {
        public int elo;
        public NetworkConnectionToClient conn;
    }
}
