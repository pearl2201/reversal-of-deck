using ReversalOfSpirit.Gameplay.Ros.Cards.Components;
using ReversalOfSpirit.Gameplay.Ros.Cards.Effects;
using System.Collections.Generic;
using UnityEngine;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Impl
{
    [CreateAssetMenu(fileName = "Patrol", menuName = "ScriptableObjects/Card/Patrol", order = 1)]
    [System.Serializable]
    public class Patrol : BaseCard
    {
        public int counterDamage;
        Patrol()
        {
            components = new List<BaseCardComponent>()
            {
                new GainShieldComponent(),
            };
        }
    }
}
