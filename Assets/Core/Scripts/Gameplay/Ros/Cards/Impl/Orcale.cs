using ReversalOfSpirit.Gameplay.Ros.Cards.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Impl
{
    [CreateAssetMenu(fileName = "Orcale", menuName = "ScriptableObjects/Card/Orcale", order = 1)]
    [System.Serializable]
    public class Orcale : BaseCard
    {

        Orcale()
        {
            components = new List<BaseCardComponent>()
            {
                new GainSwapCardChanceComponent()
            };
        }
    }
}
