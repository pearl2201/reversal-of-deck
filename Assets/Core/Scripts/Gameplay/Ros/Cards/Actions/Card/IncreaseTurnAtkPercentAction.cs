
using ReversalOfSpirit.Gameplay.Enums;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Actions
{
    public class IncreaseTurnAtkPercentAction : GameAction
    {


        public float value;

        public int finalValue;
        public RosPlayerSlot slot;
        public IncreaseTurnAtkPercentAction() : base(1) { }
        public IncreaseTurnAtkPercentAction(float value, RosPlayerSlot slot, RosPlayerSlot playerSlot, int turnOrder = 1) : base(playerSlot, turnOrder)
        {
            this.value = value;
            this.slot = slot;
            this.finalValue = (int)value;
        }

        public override void Execute(IRosGame game)
        {
            base.Execute(game);
            slot.AdditionTurnAtkPercent += value;
            finalValue = slot.CalculateAtk();
        }

        ///*public override void Serialize(IRosGame game, NetDataWriter writer)
        //{
        //    base.Serialize(game, writer);
        //    writer.Put(value);
        //    writer.Put(finalValue);
        //    writer.Put(slot.Player.Id);
        //    writer.Put((int)slot.Terriotory);
        //}

        //public override void Deserialize(IRosGame game, NetDataReader reader)
        //{
        //    base.Deserialize(game, reader);
        //    value = reader.GetFloat();
        //    finalValue = reader.GetInt();
        //    var playerId = reader.GetInt();
        //    var terriotory = (GameTerritory)reader.GetInt();
        //    slot = game.GetSlot(playerId, terriotory);
        //}

        public override string ToString()
        {
            return $"Increase {value} atk percent to player {slot.Player.Id} - {slot.Terriotory.ToString()}";
        }
    }
}
