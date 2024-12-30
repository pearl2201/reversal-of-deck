
using ReversalOfSpirit.Gameplay.Ros.Cards.Components;
using UnityEngine;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Impl
{
    [CreateAssetMenu(fileName = "Swordsman", menuName = "ScriptableObjects/Card/Swordsman", order = 1)]
    [System.Serializable]
    public class Swordsman : BaseCard
    {

        Swordsman()
        {

            components = new System.Collections.Generic.List<BaseCardComponent>
            {
               new RaiseAtkComponent() { }
            };
        }
    }
}
