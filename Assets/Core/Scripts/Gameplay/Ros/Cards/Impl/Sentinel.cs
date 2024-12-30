using ReversalOfSpirit.Gameplay.Ros.Cards.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Impl
{
    [CreateAssetMenu(fileName = "Sentinel", menuName = "ScriptableObjects/Card/Sentinel", order = 1)]
    [System.Serializable]
    public class Sentinel : BaseCard
    {

        Sentinel()
        {
            components = new List<BaseCardComponent>()
            {
                new RaiseAtkComponent(),
                new MagicDamageComponent()
            };
        }
    }
}
