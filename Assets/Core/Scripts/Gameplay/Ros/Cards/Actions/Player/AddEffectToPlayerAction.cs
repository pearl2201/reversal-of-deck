
using Cysharp.Threading.Tasks;
using ReversalOfSpirit.Gameplay.Ros.Cards.Effects;


namespace ReversalOfSpirit.Gameplay.Ros.Cards.Actions
{
    public class AddEffectToPlayerAction : GameAction
    {
        public int finalStack;

        public bool isSuccess;

        public GameEffect effect;

        public IRosPlayer target;

        public AddEffectToPlayerAction() : base(1) { }

        public AddEffectToPlayerAction(GameEffect effect, IRosPlayer target, RosPlayerSlot playerSlot, int turnOrder = 1) : base(playerSlot, turnOrder)
        {
            this.effect = effect;
            this.target = target;
        }

        public override async UniTask Execute(IRosGame game)
        {
            await base.Execute(game);
            await target.OnAddEffectToPlayerAction(this);
        }

        /*public override void Serialize(IRosGame game, NetDataWriter writer)
        {
            base.Serialize(game, writer);
            writer.Put(target.Id);
            writer.Put(isSuccess);
            writer.Put(finalStack);
            writer.Put(effect.GetType().Name.ToString());

            effect.Serialize(game, writer);
        }

        public override void Deserialize(IRosGame game, NetDataReader reader)
        {
            base.Deserialize(game, reader);
            target = game.GetPlayer(reader.GetInt());
            isSuccess = reader.GetBool();
            finalStack = reader.GetInt();
            effect = GameEffect.DeserializeGameEffect(game, reader);
        }

       */ public override string ToString()
        {
            return $"add effect {effect.GetType().Name} to player {target.Id}";
        }
    }
}
