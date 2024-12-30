using ReversalOfSpirit.Gameplay.Ros.Arcanes;
using ReversalOfSpirit.Gameplay.Ros.Cards;
using ReversalOfSpirit.Gameplay.Ros.Talent;
using System.Collections.Generic;

namespace ReversalOfSpirit.Gameplay.Ros
{

    public interface IRosConfig
    {
        List<ReversalOfSpirit.Gameplay.Ros.Cards.BaseCard> CardDefinitions { get; }

        List<BaseArcane> Arcanes { get; }

        List<BaseTalent> Talents { get; }
    }


}
