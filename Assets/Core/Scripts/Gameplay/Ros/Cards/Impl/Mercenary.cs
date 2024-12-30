using ReversalOfSpirit.Gameplay.Ros.Cards.Components;
using System.Collections.Generic;
using UnityEngine;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Impl
{
    [CreateAssetMenu(fileName = "Mercenary", menuName = "ScriptableObjects/Card/Mercenary", order = 1)]
    [System.Serializable]
    public class Mercenary : BaseCard
    {

        Mercenary()
        {
            components = new List<BaseCardComponent>()
            {
                new GainShieldBaseOnStarComponent(),
                new ShieldBashComponent()
            };
        }
    }
}
