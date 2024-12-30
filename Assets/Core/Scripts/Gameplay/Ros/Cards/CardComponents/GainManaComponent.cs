using ReversalOfSpirit.Gameplay.Enums;
using ReversalOfSpirit.Gameplay.Ros.Cards.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Components
{
    public class GainManaComponent : BaseCardComponent
    {
        public int mana;

        public GainManaComponent()
        {
            shortDescription = "Gain mana";
        }
        public override void PreAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            base.PreAtkTurn(runtimeStat, game, roundPhrase);
            game.ExecuteSequential(new List<GameAction> { new GainManaStatAction(mana, runtimeStat.Owner, runtimeStat.Slot) });
        }
    }
}
