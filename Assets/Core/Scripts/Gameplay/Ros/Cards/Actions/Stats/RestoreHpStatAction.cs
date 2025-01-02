
using Cysharp.Threading.Tasks;
using ReversalOfSpirit.Gameplay.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Actions
{
    public class RestoreHpAction : GameAction
    {
        public int value;

        public int lastValue;

        public int finalValue;

        public IRosPlayer target;

        public RestoreHpAction() : base(1) { }

        public RestoreHpAction(int value, IRosPlayer target, RosPlayerSlot playerSlot, int turnOrder = 1) : base(playerSlot, turnOrder) 
        {
            this.value = value;
            this.target = target;
            this.lastValue = value;
        }

        public override async UniTask Execute(IRosGame game)
        {
            await base.Execute(game);
            target.OnRestoreHpStatAction(this);

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
            return $"player {target.Id}  restore {value} hp, result is {finalValue} ";
        }
    }
}
