using Cysharp.Threading.Tasks;
using ReversalOfSpirit.Gameplay.Enums;
using ReversalOfSpirit.Gameplay.Ros.Cards.Actions;
using System.Collections.Generic;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Components
{
    public class GainShieldComponent : BaseCardComponent
    {
        public int shield;

        public GainShieldComponent()
        {
            shortDescription = "Gain shield";
        }

        public override async UniTask PreAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            await base.PreAtkTurn(runtimeStat, game, roundPhrase);
            await game.ExecuteSequential(new List<GameAction>
            {
                new GainShieldAction(shield, runtimeStat.Owner, runtimeStat.Slot)
            });
        }
    }
}
