using LiteNetLib.Utils;
using ReversalOfSpirit.Gameplay.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Actions
{
    public class RaiseTerritoryAttackStatAction : GameAction
    {
        public float value;

        public RosPlayerSlot target;

        public RaiseTerritoryAttackStatAction() : base(1) { }

        public RaiseTerritoryAttackStatAction(float value, RosPlayerSlot target, RosPlayerSlot playerSlot, int turnOrder = 1) : base(playerSlot, turnOrder) 
        {
            this.value = value;
            this.target = target;
        }

        public override void Execute(IRosGame game)
        {
            base.Execute(game);
            target.AdditionTurnAtkPercent += value;

        }

        public override void Serialize(IRosGame game, NetDataWriter writer)
        {
            base.Serialize(game, writer);
            writer.Put(value);
            writer.Put(target.Player.Id);
            writer.Put((int)target.Terriotory);
        }

        public override void Deserialize(IRosGame game, NetDataReader reader)
        {
            base.Deserialize(game, reader);
            value = reader.GetFloat();
            var playerId = reader.GetInt();
            var terriotory = (GameTerritory)reader.GetInt();
            target = game.GetSlot(playerId, terriotory);
        }

        public override string ToString()
        {
            return $"Increase {value} atk abs to player {target.Player.Id} - {target.Terriotory.ToString()}";
        }
    }
}
