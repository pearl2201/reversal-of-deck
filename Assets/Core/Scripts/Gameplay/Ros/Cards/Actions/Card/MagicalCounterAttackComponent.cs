
using Cysharp.Threading.Tasks;
using System.Collections.Generic;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Actions
{
    public class MagicalCounterAttackComponent : GameAction
    {

        public int value;


        public IRosPlayer target;

        public MagicalCounterAttackComponent() : base(1) { }
        public MagicalCounterAttackComponent(int value, IRosPlayer target, RosPlayerSlot playerSlot, int turnOrder = 1) : base(playerSlot, turnOrder)
        {
            this.value = value;
            this.target = target;
        }

        public override async UniTask Execute(IRosGame game)
        {
            await base.Execute(game);
            await game.ExecuteSequential(new List<GameAction> { new SubHpAction(value, target, this.Slot, Enums.DamageType.MagicalDamage, 2) });
        }

        /*public override void Serialize(IRosGame game, NetDataWriter writer)
        {
            base.Serialize(game, writer);
            writer.Put(value);
            writer.Put(target.Id);
        }

        public override void Deserialize(IRosGame game, NetDataReader reader)
        {
            base.Deserialize(game, reader);
            value = reader.GetInt();
            target = game.GetPlayer(reader.GetInt());
        }


       */ public override string ToString()
        {
            return $"magical attack damage {value} to player {target.Id}";
        }
    }
}
