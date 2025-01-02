using Cysharp.Threading.Tasks;
using ReversalOfSpirit.Gameplay.Enums;
using ReversalOfSpirit.Gameplay.Ros.Cards.Actions;
using System.Collections.Generic;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Components
{
    public class RaiseAtkComponent : BaseCardComponent
    {
        public float percent;


        public override async UniTask PreAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            await base.PreAtkTurn(runtimeStat, game, roundPhrase);
            await game.ExecuteSequential(new List<GameAction> { new IncreaseTurnAtkPercentAction(percent, runtimeStat.Slot, runtimeStat.Slot) });
        }
    }
}
