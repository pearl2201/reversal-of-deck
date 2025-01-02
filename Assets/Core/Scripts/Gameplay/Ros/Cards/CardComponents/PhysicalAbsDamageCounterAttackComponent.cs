using Cysharp.Threading.Tasks;
using ReversalOfSpirit.Gameplay.Enums;
using ReversalOfSpirit.Gameplay.Ros.Cards.Actions;
using ReversalOfSpirit.Gameplay.Ros.Cards.Effects;
using System.Collections.Generic;
namespace ReversalOfSpirit.Gameplay.Ros.Cards.Components
{
    [System.Serializable]
    public class PhysicalAbsDamageCounterAttackComponent : BaseCardComponent
    {
        public int flatDamage;

        public PhysicalAbsDamageCounterAttackComponent(int flatDamage)
        {
            this.flatDamage = flatDamage;

            shortDescription = "Counter attack";

        }

        public override async UniTask OnEndMagicalAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            await base.OnEndMagicalAtkTurn(runtimeStat, game, roundPhrase);

            await game.ExecuteSequential(new List<GameAction> { new AddEffectToPlayerCardSlotAction(new AbsortPhysicalForCounterAttackEffect(flatDamage), game.GetOpponent(runtimeStat.Owner), runtimeStat.Slot.Terriotory, runtimeStat.Slot, 1) });
        }
    }
}
