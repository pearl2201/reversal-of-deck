using ReversalOfSpirit.Gameplay.Enums;
using ReversalOfSpirit.Gameplay.Ros.Cards.Actions;
using System.Collections.Generic;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Components
{
    public class MagicDamageComponent : BaseCardComponent
    {
        public int magicDamage;

        public MagicDamageComponent()
        {
            shortDescription = "Magic damage";
        }
        public override void OnMagicalTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            base.OnMagicalTurn(runtimeStat, game, roundPhrase);
            game.ExecuteSequential(new List<GameAction> { new MagicalAttackAction(magicDamage, game.GetOpponent(runtimeStat.Owner), runtimeStat.Slot) });
        }


    }
}
