
using System.Collections.Generic;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Actions
{
    public class DrainAttackAction : GameAction
    {


        public int value;


        public IRosPlayer target;

        public DrainAttackAction() : base(1) { }
        public DrainAttackAction(int value, IRosPlayer target, RosPlayerSlot playerSlot, int turnOrder = 1) : base(playerSlot, turnOrder)
        {
            this.value = value;
            this.target = target;
        }

        public override void Execute(IRosGame game)
        {
            base.Execute(game);
            game.ExecuteSequential(new List<GameAction> { new SubHpAction(value, target, this.Slot, Enums.DamageType.DrainDamage, ActionSequenceIndex + 1), new RestoreHpAction(value, game.GetOpponent(target), this.Slot, ActionSequenceIndex + 2) });
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
            return $"Drain damage {value} to player {target.Id}";
        }
    }
}
