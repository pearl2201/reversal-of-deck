
using ReversalOfSpirit.Gameplay.Enums;
using ReversalOfSpirit.Gameplay.Ros.Cards.Actions;
using ReversalOfSpirit.Gameplay.Ros.Cards.Effects;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Components
{
    [System.Serializable]
    public class CharmLowstAtkComponent : BaseCardComponent
    {
        public int count;

        public CharmLowstAtkComponent()
        {
            shortDescription = "Charm";
        }

        public override void PreAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            base.PreAtkTurn(runtimeStat, game, roundPhrase);
            game.ExecuteSequential(new System.Collections.Generic.List<GameAction>
            {
                new AddEffectToPlayerAction(new CharmLowestAtkEffect()
                {
                    Stack = count
                },game.GetOpponent(runtimeStat.Owner), runtimeStat.Slot)
            });
        }


    }
}
