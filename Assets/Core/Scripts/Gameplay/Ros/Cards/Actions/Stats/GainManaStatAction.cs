
using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Actions
{

    public class GainManaStatAction : GameAction
    {
        public int value;
        public int lastValue;

        public int finalValue;

        public IRosPlayer target;

        public GainManaStatAction() : base(1) { }

        public GainManaStatAction(int value, IRosPlayer target, RosPlayerSlot playerSlot, int turnOrder = 1) : base(playerSlot, turnOrder)
        {
            this.value = value;
            this.lastValue = value;
            this.target = target;
            this.finalValue = value;
        }

        public override async UniTask Execute(IRosGame game)
        {

             target.OnGainManaStatAction(this);

        }


        /*public override void Serialize(IRosGame game, NetDataWriter writer)
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

       */ public override string ToString()
        {
            return $"player {target.Id}  gain {value} mana, result is {finalValue} ";
        }

    }
}
