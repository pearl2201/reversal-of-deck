namespace ReversalOfSpirit.Gameplay.Ros.Cards.Actions
{
    public class IncreaseTurnAtkAbsAction : GameAction
    {

        public float finalValue;
        public float value;


        public RosPlayerSlot slot;
        public IncreaseTurnAtkAbsAction() : base(1) { }
        public IncreaseTurnAtkAbsAction(float value, RosPlayerSlot slot, RosPlayerSlot playerSlot, int turnOrder = 1) : base(playerSlot, turnOrder)
        {
            this.value = value;
            this.finalValue = value;
            this.slot = slot;
        }

        public override void Execute(IRosGame game)
        {
            base.Execute(game);
            slot.AdditionTurnAtkAbs += value;
            finalValue = slot.CalculateAtk();
        }

        /*public override void Serialize(IRosGame game, NetDataWriter writer)
        {
            base.Serialize(game, writer);
            writer.Put(value);
            writer.Put(finalValue);
            writer.Put(slot.Player.Id);
            writer.Put((int)slot.Terriotory);
        }

        public override void Deserialize(IRosGame game, NetDataReader reader)
        {
            base.Deserialize(game, reader);
            value = reader.GetFloat();
            finalValue = reader.GetFloat();
            var playerId = reader.GetInt();
            var terriotory = (GameTerritory)reader.GetInt();
            slot = game.GetSlot(playerId, terriotory);
        }
*/
        public override string ToString()
        {
            return $"Increase {value} atk abs to player {slot.Player.Id} - {slot.Terriotory.ToString()}";
        }
    }
}
