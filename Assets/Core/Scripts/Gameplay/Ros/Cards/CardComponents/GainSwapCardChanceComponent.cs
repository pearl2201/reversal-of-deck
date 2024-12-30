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
        public override void PreAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            base.PreAtkTurn(runtimeStat, game, roundPhrase);
            game.ExecuteSequential(new List<GameAction>
            {
                new GainCardSwapChanceAction(chances, runtimeStat.Owner, runtimeStat.Slot)
            });
        }
    }
}
