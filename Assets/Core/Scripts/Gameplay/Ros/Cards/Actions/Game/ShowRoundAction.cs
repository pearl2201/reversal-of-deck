

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Actions
{
    public class ShowRoundAction : GameAction
    {

        public int roundIndex;

        public ShowRoundAction() : base(1) { }

        public ShowRoundAction(int roundIndex, RosPlayerSlot playerSlot, int turnOrder = 1) : base(playerSlot, turnOrder)
        {
            this.roundIndex = roundIndex;
        }

        public override void Execute(IRosGame game)
        {
            base.Execute(game);
            //game.C2S_PlayerPresentRoundDone(Slot.Player.Id, new Packets.C2S_PlayerSelectionFinish() { });

        }


        /*public override void Serialize(IRosGame game, NetDataWriter writer)
        {
            base.Serialize(game, writer);
            writer.Put(roundIndex);
        }

        public override void Deserialize(IRosGame game, NetDataReader reader)
        {
            base.Deserialize(game, reader);
            roundIndex = reader.GetInt();
        }

       */ public override string ToString()
        {
            return $"ShowRoundIndex: {roundIndex}";
        }

    }
}
