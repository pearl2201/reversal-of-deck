using ReversalOfSpirit.Gameplay.Ros.Cards.Components;
using UnityEngine;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Impl
{
    [CreateAssetMenu(fileName = "Sorceress", menuName = "ScriptableObjects/Card/Sorceress", order = 1)]
    [System.Serializable]
    public class Sorceress : BaseCard
    {

        Sorceress()
        {

            components = new System.Collections.Generic.List<BaseCardComponent>
            {
               new RestoreHpComponent() { },
                new GainShieldComponent()
            };
        }
    }
}
