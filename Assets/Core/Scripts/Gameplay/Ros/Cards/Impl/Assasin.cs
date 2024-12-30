using ReversalOfSpirit.Gameplay.Ros.Cards.Components;
using System.Collections.Generic;
using UnityEngine;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Impl
{
    [CreateAssetMenu(fileName = "Assasin", menuName = "ScriptableObjects/Card/Assasin", order = 1)]
    [System.Serializable]
    public class Assasin : BaseCard
    {
        public int counterDamage;
        Assasin()
        {
            components = new List<BaseCardComponent>()
            {
                new PhysicalAbsDamageCounterAttackComponent(counterDamage)
            };
        }
    }
}
