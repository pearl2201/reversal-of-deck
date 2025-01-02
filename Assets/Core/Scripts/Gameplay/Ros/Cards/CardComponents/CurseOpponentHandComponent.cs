using Cysharp.Threading.Tasks;
using ReversalOfSpirit.Gameplay.Enums;
using ReversalOfSpirit.Gameplay.Ros.Cards.Actions;
using ReversalOfSpirit.Gameplay.Ros.Cards.Effects;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Components
{
    [System.Serializable]
    public class CurseOpponentHandComponent : BaseCardComponent
    {
        public int stack;

        public CurseOpponentHandComponent()
        {
            shortDescription = "Curse";
        }
        public override async UniTask PreAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            await base.PreAtkTurn(runtimeStat, game, roundPhrase);
            await game.ExecuteSequential(new System.Collections.Generic.List<GameAction>
            {
                new AddEffectToPlayerAction(new CurseEffect()
                {
                    Stack = stack
                },game.GetOpponent(runtimeStat.Owner), runtimeStat.Slot)
            });
        }
    }
}
