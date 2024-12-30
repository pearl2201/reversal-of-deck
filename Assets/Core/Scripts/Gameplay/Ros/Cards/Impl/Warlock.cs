using ReversalOfSpirit.Gameplay.Ros.Cards.Components;
using System.Collections.Generic;
using UnityEngine;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Impl
{
    [CreateAssetMenu(fileName = "Warlock", menuName = "ScriptableObjects/Card/Warlock", order = 1)]
    [System.Serializable]
    public class Warlock : BaseCard
    {

        Warlock()
        {
            components = new List<BaseCardComponent>()
            {
           
                new MagicDamageComponent()
            };
        }
    }
}
