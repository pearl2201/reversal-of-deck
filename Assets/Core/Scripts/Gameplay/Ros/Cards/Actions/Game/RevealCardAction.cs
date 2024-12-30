using LiteNetLib.Utils;
using ReversalOfSpirit.Gameplay.Packets;
using System.Collections.Generic;
using System.Text;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Actions
{
    public class RevealCardAction : GameAction
    {

        public List<BoardCardView> boardCards;

        public RevealCardAction() : base(1) { }

        public RevealCardAction(List<BoardCardView> boardCards, RosPlayerSlot playerSlot, int turnOrder = 1) : base(playerSlot, turnOrder)
        {
            this.boardCards = boardCards;
        }

        public override void Execute(IRosGame game)
        {
            base.Execute(game);
            

        }


        public override void Serialize(IRosGame game, NetDataWriter writer)
        {
            base.Serialize(game, writer);
            writer.Serialize<BoardCardView>(boardCards);
        }

        public override void Deserialize(IRosGame game, NetDataReader reader)
        {
            base.Deserialize(game, reader);
            boardCards = new List<BoardCardView>();
            boardCards = reader.Deserialize<BoardCardView>();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("RevealCard: ");
            foreach (var boardCard in boardCards)
            {
                builder.AppendLine(boardCard.ToString());
            }

            return builder.ToString();
        }

    }

    public class BoardCardView : INetSerializable
    {
        public int ownerid;
        public int star;
        public int cardId;
        public int atk;

        public void Serialize(NetDataWriter writer)
        {
            writer.Put(ownerid);
            writer.Put(star);
            writer.Put(cardId);
            writer.Put(atk);
        }

        public void Deserialize(NetDataReader reader)
        {
            ownerid = reader.GetInt();
            star = reader.GetInt();
            cardId = reader.GetInt();
            atk = reader.GetInt();
        }

        public override string ToString()
        {
            return $"Player {ownerid} use {cardId} - {atk} atk, {star} star";
        }
    }
}
