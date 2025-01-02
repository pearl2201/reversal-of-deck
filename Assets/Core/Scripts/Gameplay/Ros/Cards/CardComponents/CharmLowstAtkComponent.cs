
using Cysharp.Threading.Tasks;
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

        public override async UniTask PreAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            await base.PreAtkTurn(runtimeStat, game, roundPhrase);
            await game.ExecuteSequential(new System.Collections.Generic.List<GameAction>
            {
                new AddEffectToPlayerAction(new CharmLowestAtkEffect()
                {
                    Stack = count
                },game.GetOpponent(runtimeStat.Owner), runtimeStat.Slot)
            });
        }


    }
}
