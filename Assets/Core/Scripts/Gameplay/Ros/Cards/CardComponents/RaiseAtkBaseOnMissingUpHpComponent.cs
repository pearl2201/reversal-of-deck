using ReversalOfSpirit.Gameplay.Enums;
using ReversalOfSpirit.Gameplay.Ros.Cards.Actions;
using System.Collections.Generic;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Components
{
    public class RaiseAtkBaseOnMissingUpHpComponent : BaseCardComponent
    {
        public float percent;

        public int maxValue;




        public override void PreAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            base.PreAtkTurn(runtimeStat, game, roundPhrase);
            var val = runtimeStat.Owner.GetMissingUpHp() * percent;
            if (val > maxValue)
            {
                val = maxValue;
            }
            game.ExecuteSequential(new List<GameAction> { new IncreaseTurnAtkAbsAction(val, runtimeStat.Slot, runtimeStat.Slot) });
        }
    }
}
