using Cysharp.Threading.Tasks;
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
        public override async UniTask PreAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            await base.PreAtkTurn(runtimeStat, game, roundPhrase);
            await game.ExecuteSequential(new List<GameAction> { new IncreaseTurnAtkAbsAction(percent*runtimeStat.Owner.CurrentArmor, runtimeStat.Slot, runtimeStat.Slot) });
        }
    }
}
