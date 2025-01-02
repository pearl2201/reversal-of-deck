using Cysharp.Threading.Tasks;

namespace ReversalOfSpirit.Gameplay.Ros.Cards
{
    public interface IActionNetSerialize
    {


        //void Serialize(IRosGame game, NetDataWriter writer);

        //void Deserialize(IRosGame game, NetDataReader reader);
    }

    public abstract class GameAction : IActionNetSerialize
    {

        public GameAction(int turnOrder)
        {
            ActionSequenceIndex = turnOrder;
        }
        public GameAction(RosPlayerSlot slot, int turnOrder)
        {
            this.Slot = slot;
            ActionSequenceIndex = turnOrder;
        }
        /// <summary>
        /// Turn order cang cao thi cang dien ra sau cung, dung cho cac skill clean
        /// </summary>
        ///

        public int ActionSequenceIndex { get; set; }

        public RosPlayerSlot Slot { get; set; }
        public virtual UniTask Execute(IRosGame game)
        {   
            return UniTask.CompletedTask;
        }
       
    }
}
