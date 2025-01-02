using Cysharp.Threading.Tasks;
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
        public override async UniTask PreAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            await base.PreAtkTurn(runtimeStat, game, roundPhrase);
            await game.ExecuteSequential(new List<GameAction> { new DecreaseTurnAtkPercentAction(percent, game.GetOpponentSlot(runtimeStat.Owner, runtimeStat.Slot), runtimeStat.Slot) });
        }
    }
}
