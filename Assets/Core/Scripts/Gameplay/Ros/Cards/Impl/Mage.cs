using ReversalOfSpirit.Gameplay.Ros.Cards.Components;
using System.Collections.Generic;
using UnityEngine;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Impl
{
    [CreateAssetMenu(fileName = "Mage", menuName = "ScriptableObjects/Card/Mage", order = 1)]
    [System.Serializable]
    public class Mage : BaseCard
    {

        Mage()
        {
            components = new List<BaseCardComponent>()
            {
                new MagicDamageComponent()
            };
        }
    }
}
