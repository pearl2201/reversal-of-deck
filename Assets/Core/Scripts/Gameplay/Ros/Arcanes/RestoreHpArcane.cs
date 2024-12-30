using ReversalOfSpirit.Gameplay.Ros.Cards.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ReversalOfSpirit.Gameplay.Ros.Arcanes
{
    [CreateAssetMenu(fileName = "RestoreHpArcane", menuName = "ScriptableObjects/Arcane/RestoreHpArcane", order = 1)]
    [System.Serializable]
    public class RestoreHpArcane : BaseArcane
    {
        public int hp;
        public override void Execute(IArcaneRuntimeStat runtimeStat, IRosGame game)
        {
            base.Execute(runtimeStat, game);

            runtimeStat.Owner.Game.NotifySequential(new List<Cards.GameAction> { new RestoreHpAction(hp,runtimeStat.Owner,null,1){
            }});
        }
    }
}
