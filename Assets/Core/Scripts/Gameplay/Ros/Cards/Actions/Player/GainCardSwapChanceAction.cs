using LiteNetLib.Utils;
using ReversalOfSpirit.Models;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Actions
{
    public class GainCardSwapChanceAction : GameAction
    {


        public int value;
        public int lastValue;

        public int finalValue;

        public IRosPlayer target;

        public GainCardSwapChanceAction() : base(1) { }

        public GainCardSwapChanceAction(int chances, IRosPlayer target, RosPlayerSlot playerSlot, int turnOrder = 1) : base(playerSlot, turnOrder)
        {
            this.value = chances;
            this.lastValue = chances;
            this.target = target;
        }

        public override void Execute(IRosGame game)
        {
            base.Execute(game);
            target.OnGainCardSwapChanceAction(this);
        }

        public override void Serialize(IRosGame game, NetDataWriter writer)
        {
            base.Serialize(game, writer);
            writer.Put(value);
            writer.Put(lastValue);
            writer.Put(target.Id);
            writer.Put(finalValue);
        }

        public override void Deserialize(IRosGame game, NetDataReader reader)
        {
            base.Deserialize(game, reader);
            value = reader.GetInt();
            lastValue = reader.GetInt();
            target = game.GetPlayer(reader.GetInt());
            finalValue = reader.GetInt();
        }

        public override string ToString()
        {
            return $"player {target.Id}  gain {value} swap card chances, result is {finalValue} ";
        }
    }
}
