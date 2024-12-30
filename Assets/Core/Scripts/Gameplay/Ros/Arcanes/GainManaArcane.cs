using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ReversalOfSpirit.Gameplay.Ros.Arcanes
{
    [CreateAssetMenu(fileName = "GainManaArcane", menuName = "ScriptableObjects/Arcane/GainManaArcane", order = 1)]
    [System.Serializable]
    public class GainManaArcane : BaseArcane
    {
        public int mana;
        public override void Execute(IArcaneRuntimeStat runtimeStat, IRosGame game)
        {
            base.Execute(runtimeStat, game);
            runtimeStat.Owner.currentMana += mana;
        }
    }
}
