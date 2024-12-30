using ReversalOfSpirit.Gameplay.Ros.Cards.Components;
using UnityEngine;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Impl
{
    [CreateAssetMenu(fileName = "Priest", menuName = "ScriptableObjects/Card/Priest", order = 1)]
    [System.Serializable]
    public class Priest : BaseCard
    {

        Priest()
        {

            components = new System.Collections.Generic.List<BaseCardComponent>
            {
               new RestoreHpComponent() { },
                new GainManaComponent()
            };
        }
    }
}
