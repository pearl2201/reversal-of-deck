

using ReversalOfSpirit.Gameplay.Enums;
using ReversalOfSpirit.Gameplay.Ros;

namespace ReversalOfSpirit.Gameplay.Ros.Cards
{
    public interface IActionNetSerialize
    {


        //void Serialize(IRosGame game, NetDataWriter writer);

        //void Deserialize(IRosGame game, NetDataReader reader);
    }

    public abstract class GameAction : IActionNetSerialize
    {
        public int RoundActIndex { get; set; }
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

        // group action same order
        public int FinalTurnOrder => RoundActIndex + ActionSequenceIndex;

        // after group action same order, we still need an execution index to avoid some action has same effect to display animation
        public int ExecutionIndex { get; set; }

        public RosPlayerSlot Slot { get; set; }
        public virtual void Execute(IRosGame game)
        {
            if (game.isExecution)
            {
                ExecutionIndex = game.executionIndex;
                RoundActIndex = game.roundActIndex;
            }    
        }
        //public virtual void Serialize(IRosGame game, NetDataWriter writer)
        //{
        //    writer.Put(RoundActIndex);
        //    writer.Put(ActionSequenceIndex);
        //    writer.Put(ExecutionIndex);
        //    writer.Put(Slot != null);
        //    if (Slot != null)
        //    {
        //        writer.Put((int)Slot.Terriotory);
        //        writer.Put(Slot.Player.Id);
        //    }

        //}
        //public virtual void Deserialize(IRosGame game, NetDataReader reader)
        //{
        //    RoundActIndex = reader.GetInt();
        //    ActionSequenceIndex = reader.GetInt();
        //    ExecutionIndex = reader.GetInt();
        //    var hasSlot = reader.GetBool();
        //    if (hasSlot)
        //    {
        //        var terriority = (GameTerritory)reader.GetInt();
        //        var playerId = reader.GetInt();
        //        Slot = game.GetSlot(playerId, terriority);
        //    }
        //}
    }
}
