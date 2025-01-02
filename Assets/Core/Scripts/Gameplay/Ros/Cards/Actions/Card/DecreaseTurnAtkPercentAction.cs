
using Cysharp.Threading.Tasks;
using ReversalOfSpirit.Gameplay.Enums;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Actions
{
    public class DecreaseTurnAtkPercentAction : GameAction
    {


        public float value;


        public RosPlayerSlot slot;

        public DecreaseTurnAtkPercentAction(float value, RosPlayerSlot slot, RosPlayerSlot playerSlot, int turnOrder = 1) : base(playerSlot, turnOrder) 
        {
            this.value = value;
            this.slot = slot;
        }

        public DecreaseTurnAtkPercentAction() : base(1) { }
        public override async UniTask Execute(IRosGame game)
        {
            await base.Execute(game);
            slot.AdditionTurnAtkPercent -= value;
        }

        /*public override void Serialize(IRosGame game, NetDataWriter writer)
        {
            base.Serialize(game, writer);
            writer.Put(value);
            writer.Put(slot.Player.Id);
            writer.Put((int)slot.Terriotory);
        }

        public override void Deserialize(IRosGame game, NetDataReader reader)
        {
            base.Deserialize(game, reader);
            value = reader.GetFloat();
            var playerId = reader.GetInt();
            var terriotory = (GameTerritory)reader.GetInt();
            slot = game.GetSlot(playerId, terriotory);
        }

       */ public override string ToString()
        {
            return $"Decrease {value} atk percent to player {slot.Player.Id} - {slot.Terriotory.ToString()}";
        }
    }
}
