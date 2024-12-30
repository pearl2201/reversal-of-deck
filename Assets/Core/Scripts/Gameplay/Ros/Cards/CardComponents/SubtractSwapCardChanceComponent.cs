using ReversalOfSpirit.Gameplay.Enums;
using ReversalOfSpirit.Gameplay.Ros.Cards.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Components
{
    public class SubtractSwapCardChanceComponent : BaseCardComponent
    {
        public int chances;

        public SubtractSwapCardChanceComponent()
        {
            shortDescription = "Remove swap chance";
        }

        public override void PreAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            base.PreAtkTurn(runtimeStat, game, roundPhrase);
            game.ExecuteSequential(new List<GameAction>
            {
                new SubtractCardSwapChanceAction(chances, game.GetOpponent(runtimeStat.Owner), runtimeStat.Slot)
            });
        }
    }
}
