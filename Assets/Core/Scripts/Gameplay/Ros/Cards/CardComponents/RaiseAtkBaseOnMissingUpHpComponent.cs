using Cysharp.Threading.Tasks;
using ReversalOfSpirit.Gameplay.Enums;
using ReversalOfSpirit.Gameplay.Ros.Cards.Actions;
using System.Collections.Generic;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Components
{
    public class RaiseAtkBaseOnMissingUpHpComponent : BaseCardComponent
    {
        public float percent;

        public int maxValue;




        public override async UniTask PreAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            await base.PreAtkTurn(runtimeStat, game, roundPhrase);
            var val = runtimeStat.Owner.GetMissingUpHp() * percent;
            if (val > maxValue)
            {
                val = maxValue;
            }
            await game.ExecuteSequential(new List<GameAction> { new IncreaseTurnAtkAbsAction(val, runtimeStat.Slot, runtimeStat.Slot) });
        }
    }
}
