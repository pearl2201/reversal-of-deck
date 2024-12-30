using ReversalOfSpirit.Gameplay.Ros.Cards.Components;
using UnityEngine;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Impl
{
    [CreateAssetMenu(fileName = "Ranger", menuName = "ScriptableObjects/Card/Ranger", order = 1)]
    [System.Serializable]
    public class Ranger : BaseCard
    {

        Ranger()
        {

            components = new System.Collections.Generic.List<BaseCardComponent>
            {
               new RaiseAtkComponent() { },
                new GainShieldComponent()
            };
        }
    }
}
