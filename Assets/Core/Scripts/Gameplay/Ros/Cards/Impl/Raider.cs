
using ReversalOfSpirit.Gameplay.Ros.Cards.Components;
using UnityEngine;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Impl
{
    [CreateAssetMenu(fileName = "Raider", menuName = "ScriptableObjects/Card/Raider", order = 1)]
    [System.Serializable]
    public class Raider : BaseCard
    {

        Raider()
        {

            components = new System.Collections.Generic.List<BaseCardComponent>
            {
               new RaiseAtkComponent() { },
                new DecreaseOpponentTurnAtkPercentComponent()
            };
        }
    }
}
