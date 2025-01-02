
using Cysharp.Threading.Tasks;
using ReversalOfSpirit.Gameplay.Ros.Arcanes;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Actions.Player
{
    public class UserSkillAction : GameAction
    {

        public int finalManaValue;
        public IRosPlayer target;

        public UserSkillAction() : base(1) { }

        public UserSkillAction(IRosPlayer target, RosPlayerSlot playerSlot, int turnOrder = 1) : base(playerSlot, turnOrder)
        {
            this.target = target;
        }

        public override async UniTask Execute(IRosGame game)
        {
            await base.Execute(game);
            target.arcane.Arcane.Execute(new ArcaneRuntimeStat { Owner = target }, game);
        }

        /*public override void Serialize(IRosGame game, NetDataWriter writer)
        {
            base.Serialize(game, writer);
            writer.Put(target.Id);
        }

        public override void Deserialize(IRosGame game, NetDataReader reader)
        {
            base.Deserialize(game, reader);
            target = game.GetPlayer(reader.GetInt());
        }*/
    }
}
