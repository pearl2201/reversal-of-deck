using ReversalOfSpirit.Gameplay.Enums;
using ReversalOfSpirit.Gameplay.Ros.Cards.Actions;
using System;
using System.Collections.Generic;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Components
{

    [Serializable]
    public class DecreaseOpponentTurnAtkPercentComponent : BaseCardComponent
    {
        public float percent;

        public DecreaseOpponentTurnAtkPercentComponent()
        {
            shortDescription = "Decrease attack";
        }
        public override void PreAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            base.PreAtkTurn(runtimeStat, game, roundPhrase);
            game.ExecuteSequential(new List<GameAction> { new DecreaseTurnAtkPercentAction(percent, game.GetOpponentSlot(runtimeStat.Owner, runtimeStat.Slot), runtimeStat.Slot) });
        }
    }
}
