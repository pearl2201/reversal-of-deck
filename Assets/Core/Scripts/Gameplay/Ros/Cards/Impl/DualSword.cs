
using ReversalOfSpirit.Gameplay.Ros.Cards.Components;
using UnityEngine;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Impl
{
    [CreateAssetMenu(fileName = "Swordsman", menuName = "ScriptableObjects/Card/DualSword", order = 1)]
    [System.Serializable]
    public class DualSword : BaseCard
    {

        DualSword()
        {

            components = new System.Collections.Generic.List<BaseCardComponent>
            {
               new RaiseAtkComponent() { }
            };
        }
    }
}
