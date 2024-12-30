using ReversalOfSpirit.Gameplay.Enums;
using ReversalOfSpirit.Gameplay.Ros.Cards.Actions;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Components
{
    [Serializable]
    public class RestoreHpComponent : BaseCardComponent
    {
        public int hp;

        public RestoreHpComponent()
        {
            shortDescription = "Restore Hp";
        }

        public override void PreAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            base.PreAtkTurn(runtimeStat, game, roundPhrase);
            game.ExecuteSequential(new List<GameAction> { new RestoreHpAction(hp, runtimeStat.Owner, runtimeStat.Slot) });
        }
    }
}
