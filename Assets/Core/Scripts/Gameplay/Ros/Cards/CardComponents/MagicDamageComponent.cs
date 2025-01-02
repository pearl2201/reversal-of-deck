using Cysharp.Threading.Tasks;
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
        public override async UniTask OnMagicalTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            await base.OnMagicalTurn(runtimeStat, game, roundPhrase);
            await game.ExecuteSequential(new List<GameAction> { new MagicalAttackAction(magicDamage, game.GetOpponent(runtimeStat.Owner), runtimeStat.Slot) });
        }


    }
}
