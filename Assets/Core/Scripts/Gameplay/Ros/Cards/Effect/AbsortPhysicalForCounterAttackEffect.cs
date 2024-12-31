
using ReversalOfSpirit.Gameplay.Enums;
using ReversalOfSpirit.Gameplay.Ros.Cards.Actions;
using System.Collections.Generic;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Effects
{
    public class AbsortPhysicalForCounterAttackEffect : GameEffect
    {
        public float percent;

        public int absortValue;

        public AbsortPhysicalForCounterAttackEffect() { }
        public AbsortPhysicalForCounterAttackEffect(float percent)
        {
            this.percent = percent;
        }

        public override GameEffectRoleType RoleType => GameEffectRoleType.Negative;

        public override void OnEndMagicalAtkTurn(IEffectContext context, IRosGame game, RosRoundPhrase roundPhrase)
        {
            base.OnEndMagicalAtkTurn(context, game, roundPhrase);
            if (absortValue > 0)
            {
                context.Owner.Game.ExecuteSequential(new List<GameAction>() { new PhysicalCounterAttackAction(absortValue, game.GetOpponent(context.Owner), context.PlayerSlot) });
                IsExecuted = true;
            }
        }

        public override void OnPlayerGetDamage(IEffectContext context, SubHpAction subHpAction, IRosGame game)
        {
            base.OnPlayerGetDamage(context, subHpAction, game);
            if (subHpAction.damageType == DamageType.PhysicalDamage)
            {
                subHpAction.lastValue = 0;
                absortValue = (int)(subHpAction.value * percent);
                context.Owner.Game.ExecuteSequential(new List<GameAction>() { new AbsorbPhysicalDamageAction(subHpAction.value, percent, this, context.Owner, context.PlayerSlot.Terriotory, context.PlayerSlot, subHpAction.ActionSequenceIndex + 1) });
            }
        }

        public override EffectTriggerTimeCondition TriggerTime => EffectTriggerTimeCondition.CardPlay;

        public override int RoundCount => 0;

        public override EffectEndType EndType => EffectEndType.OnTrigger;

        /*public override void Serialize(IRosGame game, NetDataWriter writer)
        {
            writer.Put(percent);
            writer.Put(absortValue);
        }

        public override void Deserialize(IRosGame game, NetDataReader reader)
        {
            percent = reader.GetFloat();
            absortValue = reader.GetInt();
        }
        */
    }
}
