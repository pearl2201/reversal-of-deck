
using ReversalOfSpirit.Gameplay.Enums;
using ReversalOfSpirit.Gameplay.Ros.Cards.Actions;
using System;
using System.Collections.Generic;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Components
{
    [Serializable]
    public class GainShieldBaseOnStarComponent : BaseCardComponent
    {
        public int rate;

        public GainShieldBaseOnStarComponent()
        {
            shortDescription = "Gain shield";
        }
        public override void PreAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            base.PreAtkTurn(runtimeStat, game, roundPhrase);
            game.ExecuteSequential(new List<GameAction> { new GainShieldAction(runtimeStat.Slot.CalculateStar() * rate, runtimeStat.Owner, runtimeStat.Slot) });
        }
    }
}
