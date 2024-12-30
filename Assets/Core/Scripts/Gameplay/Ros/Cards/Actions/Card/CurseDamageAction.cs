using LiteNetLib.Utils;
using System.Collections.Generic;
using static UnityEngine.GraphicsBuffer;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Actions
{

    public class CurseDamageAction : GameAction
    {


        public int value;


        public IRosPlayer target;

        public CurseDamageAction(int value, IRosPlayer target, RosPlayerSlot playerSlot, int turnOrder = 1) : base(playerSlot, turnOrder)
        {
            this.value = value;
            this.target = target;
        }

        public CurseDamageAction() : base(1) { }

        public override void Execute(IRosGame game)
        {
            base.Execute(game);
            game.ExecuteSequential(new List<GameAction> { new SubHpAction(value, target, this.Slot, Enums.DamageType.CurseDamage) });
        }

        public override void Serialize(IRosGame game, NetDataWriter writer)
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

        public override string ToString()
        {
            return $"Curse damage {value} to player {target.Id}";
        }
    }
}
