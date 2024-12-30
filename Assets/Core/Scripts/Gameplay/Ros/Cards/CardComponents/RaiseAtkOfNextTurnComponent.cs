
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
        public override void PreAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            base.PreAtkTurn(runtimeStat, game, roundPhrase);
            game.ExecuteSequential(new System.Collections.Generic.List<GameAction>
            {
                new AddEffectToPlayerAction(new RaiseAtkOfNextTurnEffect()
                {
                   Percent = percent
                },runtimeStat.Owner, runtimeStat.Slot)
            });
        }
    }
}
