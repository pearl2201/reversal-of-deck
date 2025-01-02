
using Cysharp.Threading.Tasks;
using ReversalOfSpirit.Gameplay.Enums;
using ReversalOfSpirit.Gameplay.Ros.Cards.Actions;
using ReversalOfSpirit.Gameplay.Ros.Cards.Effects;
namespace ReversalOfSpirit.Gameplay.Ros.Cards.Components
{
    [System.Serializable]
    public class RaiseAtkOfNextTurnComponent : BaseCardComponent
    {
        public int percent;

        public RaiseAtkOfNextTurnComponent()
        {
            shortDescription = "Terriority: magic damage";
        }
        public override async UniTask PreAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            await base.PreAtkTurn(runtimeStat, game, roundPhrase);
            await game.ExecuteSequential(new System.Collections.Generic.List<GameAction>
            {
                new AddEffectToPlayerAction(new RaiseAtkOfNextTurnEffect()
                {
                   Percent = percent
                },runtimeStat.Owner, runtimeStat.Slot)
            });
        }
    }
}
