
using Cysharp.Threading.Tasks;
using ReversalOfSpirit.Gameplay.Enums;
using ReversalOfSpirit.Gameplay.Ros.Cards.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Effects
{

    public class PhysicalAbsCounterAttackEffect : GameEffect
    {
        public int damage;

        public bool beAttacked;

        public PhysicalAbsCounterAttackEffect() { }
        public PhysicalAbsCounterAttackEffect(int damage)
        {
            this.damage = damage;
        }

        public override GameEffectRoleType RoleType => GameEffectRoleType.Neutralize;

        public override async UniTask OnEndMagicalAtkTurn(IEffectContext context, IRosGame game, RosRoundPhrase roundPhrase)
        {
            await base.OnEndMagicalAtkTurn(context, game, roundPhrase);
            if (beAttacked)
            {
                await context.Owner.Game.ExecuteSequential(new List<GameAction>() { new PhysicalCounterAttackAction(damage, game.GetOpponent(context.Owner), context.PlayerSlot) });
            }
        }

        public override async UniTask OnPlayerGetDamage(IEffectContext context, SubHpAction subHpAction, IRosGame game)
        {
            await base.OnPlayerGetDamage(context, subHpAction, game);
            if (subHpAction.damageType == DamageType.PhysicalDamage || subHpAction.damageType == DamageType.MagicalDamage || subHpAction.damageType == DamageType.CurseDamage)
                this.beAttacked = true;
        }

        public override EffectTriggerTimeCondition TriggerTime => EffectTriggerTimeCondition.CardPlay;

        public override int RoundCount => 0;

        public override EffectEndType EndType => EffectEndType.OnTrigger;

        /*public override void Serialize(IRosGame game, NetDataWriter writer)
        {
            writer.Put(damage);
            writer.Put(beAttacked);
        }

        public override void Deserialize(IRosGame game, NetDataReader reader)
        {
            damage = reader.GetInt();
            beAttacked = reader.GetBool();
        }
        */
    }
}
