using ReversalOfSpirit.Gameplay.Ros.Cards.Actions;
using ReversalOfSpirit.Gameplay.Ros.Cards;
using ReversalOfSpirit.Gameplay.Ros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static UnityEngine.GraphicsBuffer;
using System.Diagnostics;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Actions
{
    public class MagicalAttackAction : GameAction
    {
        

        public int value;


        public IRosPlayer target;
        public MagicalAttackAction() : base(1) { }
        public MagicalAttackAction(int value, IRosPlayer target, RosPlayerSlot playerSlot, int turnOrder = 1) : base(playerSlot, turnOrder) 
        {
            UnityEngine.Debug.Log("Init magical attack action: " + value);
            this.value = value;
            this.target = target;
        }

        public override void Execute(IRosGame game)
        {
            base.Execute(game);
            game.ExecuteSequential(new List<GameAction> { new SubHpAction(value, target, this.Slot, Enums.DamageType.MagicalDamage) });
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
            return $"magical damage {value} to player {target.Id}";
        }
    }
}
