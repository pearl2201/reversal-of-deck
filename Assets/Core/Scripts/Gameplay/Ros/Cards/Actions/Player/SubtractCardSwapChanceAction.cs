

using Cysharp.Threading.Tasks;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Actions
{
    public class SubtractCardSwapChanceAction : GameAction
    {
        

        public int value;
        public int lastValue;

        public int finalValue;

        public IRosPlayer target;

        public SubtractCardSwapChanceAction() : base(1) { }

        public SubtractCardSwapChanceAction(int chances, IRosPlayer target, RosPlayerSlot playerSlot, int turnOrder = 1) : base(playerSlot, turnOrder) 
        {
            this.value = chances;
            this.lastValue = chances;
            this.target = target;
        }

        public override async UniTask Execute(IRosGame game)
        {
            await base.Execute(game);
            target.OnSubtractCardSwapChanceAction(this);
        }

        /*public override void Serialize(IRosGame game, NetDataWriter writer)
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

       */ public override string ToString()
        {
            return $"player {target.Id}  lost {value} swap card chances, result is {finalValue} ";
        }
    }
}
