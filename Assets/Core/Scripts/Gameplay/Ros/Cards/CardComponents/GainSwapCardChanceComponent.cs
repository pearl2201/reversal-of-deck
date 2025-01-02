using Cysharp.Threading.Tasks;
using ReversalOfSpirit.Gameplay.Enums;
using ReversalOfSpirit.Gameplay.Ros.Cards.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Components
{
    public class GainSwapCardChanceComponent : BaseCardComponent
    {
        public int chances;

        public GainSwapCardChanceComponent()
        {
            shortDescription = "Gain swap chance";
        }
        public override async UniTask PreAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            await base.PreAtkTurn(runtimeStat, game, roundPhrase);
            await game.ExecuteSequential(new List<GameAction>
            {
                new GainCardSwapChanceAction(chances, runtimeStat.Owner, runtimeStat.Slot)
            });
        }
    }
}
