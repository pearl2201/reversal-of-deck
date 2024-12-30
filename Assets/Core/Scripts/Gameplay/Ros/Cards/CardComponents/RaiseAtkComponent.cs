using ReversalOfSpirit.Gameplay.Enums;
using ReversalOfSpirit.Gameplay.Ros.Cards.Actions;
using System.Collections.Generic;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Components
{
    public class RaiseAtkComponent : BaseCardComponent
    {
        public float percent;


        public override void PreAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            base.PreAtkTurn(runtimeStat, game, roundPhrase);
            game.ExecuteSequential(new List<GameAction> { new IncreaseTurnAtkPercentAction(percent, runtimeStat.Slot, runtimeStat.Slot) });
        }
    }
}
