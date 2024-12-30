using ReversalOfSpirit.Gameplay.Ros.Cards.Components;
using System.Collections.Generic;
using UnityEngine;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Impl
{
    [CreateAssetMenu(fileName = "Samurai", menuName = "ScriptableObjects/Card/Samurai", order = 1)]
    [System.Serializable]
    public class Samurai : BaseCard
    {

        Samurai()
        {
            components = new List<BaseCardComponent>()
            {
                new CurseOpponentHandComponent(),
                new DealMagicDamageBaseOnStarComponent()
            };
        }
    }
}
