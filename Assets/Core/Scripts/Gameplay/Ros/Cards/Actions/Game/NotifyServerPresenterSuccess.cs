using LiteNetLib.Utils;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Actions
{
    public class NotifyServerPresenterSuccessActionn : GameAction
    {

        private IRosPlayer target;

        public NotifyServerPresenterSuccessActionn() : base(1) { }

        public NotifyServerPresenterSuccessActionn(IRosPlayer target, RosPlayerSlot playerSlot, int turnOrder = 1) : base(playerSlot, turnOrder)
        {
            this.target = target;
        }

        public override void Execute(IRosGame game)
        {
            base.Execute(game);
            //game.C2S_PlayerPresentRoundDone(Slot.Player.Id, new Packets.C2S_PlayerPresentRoundDone() { });

        }


        public override void Serialize(IRosGame game, NetDataWriter writer)
        {
            base.Serialize(game, writer);
            writer.Put(target.Id);
        }

        public override void Deserialize(IRosGame game, NetDataReader reader)
        {
            base.Deserialize(game, reader);
            target = game.GetPlayer(reader.GetInt());
        }

        public override string ToString()
        {
            return $"Notify game presenter end: {target.Id}";
        }

    }
}
