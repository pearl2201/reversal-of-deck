using ReversalOfSpirit.Gameplay.Enums;
using ReversalOfSpirit.Gameplay.Ros.Cards.Actions;
using System.Collections.Generic;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Components
{
    public class ShieldBashComponent : BaseCardComponent
    {
        public float percent;

        public ShieldBashComponent()
        {
            shortDescription = "Shield bash";
        }
        public override void PreAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            base.PreAtkTurn(runtimeStat, game, roundPhrase);
            game.ExecuteSequential(new List<GameAction> { new IncreaseTurnAtkAbsAction(percent*runtimeStat.Owner.currentArmor, runtimeStat.Slot, runtimeStat.Slot) });
        }
    }
}
