using ReversalOfSpirit.Gameplay.Enums;
using ReversalOfSpirit.Gameplay.Ros.Cards.Actions;
using System.Collections.Generic;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Components
{
    public class GainShieldComponent : BaseCardComponent
    {
        public int shield;

        public GainShieldComponent()
        {
            shortDescription = "Gain shield";
        }

        public override void PreAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            base.PreAtkTurn(runtimeStat, game, roundPhrase);
            game.ExecuteSequential(new List<GameAction>
            {
                new GainShieldAction(shield, runtimeStat.Owner, runtimeStat.Slot)
            });
        }
    }
}
