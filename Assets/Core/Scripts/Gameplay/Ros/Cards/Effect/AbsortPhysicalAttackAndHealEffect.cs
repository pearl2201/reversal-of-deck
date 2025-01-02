

using Cysharp.Threading.Tasks;
using ReversalOfSpirit.Gameplay.Enums;
using ReversalOfSpirit.Gameplay.Ros.Cards.Actions;
using System.Collections.Generic;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Effects
{
    public class AbsortPhysicalAttackAndHealEffect : GameEffect
    {
        public float percent;

        public int absortValue;

        public AbsortPhysicalAttackAndHealEffect() { }
        public AbsortPhysicalAttackAndHealEffect(float percent)
        {
            this.percent = percent;
        }

        public override GameEffectRoleType RoleType => GameEffectRoleType.Negative;


        public override async UniTask OnPlayerGetDamage(IEffectContext context, SubHpAction subHpAction, IRosGame game)
        {
            base.OnPlayerGetDamage(context, subHpAction, game);
            if (subHpAction.damageType == DamageType.PhysicalDamage)
            {
                subHpAction.lastValue = 0;
                absortValue = (int)(subHpAction.value * percent);
                context.Owner.Game.ExecuteSequential(
                    new List<GameAction>() {
                        new AbsorbPhysicalDamageAction(subHpAction.value, percent, this, context.Owner, context.PlayerSlot.Terriotory, context.PlayerSlot, subHpAction.ActionSequenceIndex + 1) ,
                        new RestoreHpAction(absortValue,context.Owner,context.PlayerSlot,subHpAction.ActionSequenceIndex + 2) ,
                    });
                IsExecuted = true;
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
