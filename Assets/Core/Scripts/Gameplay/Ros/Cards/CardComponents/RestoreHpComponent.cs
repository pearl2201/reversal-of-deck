using Cysharp.Threading.Tasks;
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

        public override async UniTask PreAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            await base.PreAtkTurn(runtimeStat, game, roundPhrase);
            await game.ExecuteSequential(new List<GameAction> { new RestoreHpAction(hp, runtimeStat.Owner, runtimeStat.Slot) });
        }
    }
}
