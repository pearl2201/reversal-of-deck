using Cysharp.Threading.Tasks;
using ReversalOfSpirit.Gameplay.Enums;
using ReversalOfSpirit.Gameplay.Ros.Cards.Actions;
using System;
using System.Collections.Generic;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Components
{
    [Serializable]
    public class DealDrainDamageBaseOnTotalPartyAtk : BaseCardComponent
    {
        public int rate;

        public DealDrainDamageBaseOnTotalPartyAtk()
        {
            shortDescription = "Drain damage";
        }
        public override async UniTask OnMagicalTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
           await base.OnMagicalTurn(runtimeStat, game, roundPhrase);
            await game.ExecuteSequential(new List<GameAction> { new MagicalAttackAction(runtimeStat.Slot.CalculateStar() * rate, game.GetOpponent(runtimeStat.Owner), runtimeStat.Slot) });
        }
    }
}
