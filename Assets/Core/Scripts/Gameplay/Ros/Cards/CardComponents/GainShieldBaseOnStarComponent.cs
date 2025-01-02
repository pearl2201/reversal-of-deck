
using Cysharp.Threading.Tasks;
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
        public override async UniTask PreAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            await base.PreAtkTurn(runtimeStat, game, roundPhrase);
            await game.ExecuteSequential(new List<GameAction> { new GainShieldAction(runtimeStat.Slot.CalculateStar() * rate, runtimeStat.Owner, runtimeStat.Slot) });
        }
    }
}
