using ReversalOfSpirit.Gameplay.Ros.Cards.Components;
using ReversalOfSpirit.Gameplay.Ros.Cards.Effects;
using System.Collections.Generic;
using UnityEngine;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Impl
{
    [CreateAssetMenu(fileName = "Artisan", menuName = "ScriptableObjects/Card/Artisan", order = 1)]
    [System.Serializable]
    public class Artisan : BaseCard
    {
        public int counterDamage;
        Artisan()
        {
            components = new List<BaseCardComponent>()
            {
                new RaiseAtkOfNextTurnComponent(),
                new GainShieldComponent(),
            };
        }
    }
}
