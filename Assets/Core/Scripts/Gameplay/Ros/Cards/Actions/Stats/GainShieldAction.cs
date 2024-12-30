using LiteNetLib.Utils;
using ReversalOfSpirit.Gameplay.Ros;
using ReversalOfSpirit.Gameplay.Ros.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Actions
{
    public class GainShieldAction: GameAction
    {
        public int value;
        public int lastValue;
        public int finalValue;

        public IRosPlayer target;

        public GainShieldAction() : base(1) { }

        public GainShieldAction(int value, IRosPlayer target, RosPlayerSlot playerSlot, int turnOrder = 1) : base(playerSlot, turnOrder) 
        {
            this.value = value;
            this.lastValue = lastValue;
            this.target = target;
        }

        public override void Execute(IRosGame game)
        {
            base.Execute(game);
            target.OnGainShieldAction(this);

        }

        public override void Serialize(IRosGame game, NetDataWriter writer)
        {
            base.Serialize(game, writer);
            writer.Put(target.Id);
            writer.Put(value);
            writer.Put(lastValue);
            writer.Put(finalValue);
        }

        public override void Deserialize(IRosGame game, NetDataReader reader)
        {
            base.Deserialize(game, reader);
            target = game.GetPlayer(reader.GetInt());
            value = reader.GetInt();
            lastValue = reader.GetInt();
            finalValue = reader.GetInt();
        }

        public override string ToString()
        {
            return $"player {target.Id}  gain {value} shield, result is {finalValue} ";
        }
    }
}
