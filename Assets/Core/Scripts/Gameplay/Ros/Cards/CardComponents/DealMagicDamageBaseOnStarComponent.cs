﻿
using ReversalOfSpirit.Gameplay.Enums;
using ReversalOfSpirit.Gameplay.Ros.Cards.Actions;
using System;
using System.Collections.Generic;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Components
{
    [Serializable]
    public class DealMagicDamageBaseOnStarComponent : BaseCardComponent
    {
        public int rate;

        public DealMagicDamageBaseOnStarComponent()
        {
            shortDescription = "Magic damage";
        }
        public override void OnMagicalTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            base.PreAtkTurn(runtimeStat, game, roundPhrase);
            game.ExecuteSequential(new List<GameAction> { new MagicalAttackAction(runtimeStat.Slot.CalculateStar() * rate, game.GetOpponent(runtimeStat.Owner), runtimeStat.Slot) });
        }
    }
}
