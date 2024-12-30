using LiteNetLib.Utils;
using ReversalOfSpirit.Gameplay.Enums;
using ReversalOfSpirit.Gameplay.Ros;
using ReversalOfSpirit.Gameplay.Ros.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UnityEngine.GraphicsBuffer;


namespace ReversalOfSpirit.Gameplay.Ros.Cards.Actions
{
    public class CharmCardAction : GameAction
    {


        public int cardId;

        public GameTerritory territory;

        public IRosPlayer target;
        public CharmCardAction() : base(1) { }
        public CharmCardAction(int cardId, GameTerritory territory, IRosPlayer target, RosPlayerSlot playerSlot, int turnOrder = 1) : base(playerSlot, turnOrder) 
        {
            this.territory = territory;
            this.cardId = cardId;
            this.target = target;
        }

        public override void Execute(IRosGame game)
        {
            base.Execute(game);
            game.C2S_SetSelectionCard(target.Id, new Packets.C2S_PlayerSelectionCard
            {
                cardId = cardId,
                slot = territory
            });
        }

        public override void Serialize(IRosGame game, NetDataWriter writer)
        {
            base.Serialize(game, writer);
            writer.Put(cardId);
            writer.Put((int)territory);
            writer.Put(target.Id);
        }

        public override void Deserialize(IRosGame game, NetDataReader reader)
        {
            base.Deserialize(game, reader);
            cardId = reader.GetInt();
            territory = (GameTerritory)reader.GetInt();
            target = game.GetPlayer(reader.GetInt());
        }

        public override string ToString()
        {
            return $"charm {cardId} to player {target.Id} - {territory}";
        }
    }
}
