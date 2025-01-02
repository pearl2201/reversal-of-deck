

using Cysharp.Threading.Tasks;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Actions
{

    public class NotifyGameResultAction : GameAction
    {
        public int winnerId;

    
        public NotifyGameResultAction() : base(1) { }

        public NotifyGameResultAction(int winnerId, RosPlayerSlot playerSlot, int turnOrder = 1) : base(playerSlot, turnOrder)
        {
            this.winnerId = winnerId;
        }

        public override async UniTask Execute(IRosGame game)
        {
            await base.Execute(game);
            game.NotifyGameResult(this);

        }


        /*public override void Serialize(IRosGame game, NetDataWriter writer)
        {
            base.Serialize(game, writer);
            writer.Put(winnerId);
        }

        public override void Deserialize(IRosGame game, NetDataReader reader)
        {
            base.Deserialize(game, reader);
            winnerId = reader.GetInt();
        }

       */ public override string ToString()
        {
            return $"Notify game result: {winnerId}";
        }

    }
}
