using ReversalOfSpirit.Gameplay.Ros.Cards.Components;
using System.Collections.Generic;
using UnityEngine;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Impl
{
    [CreateAssetMenu(fileName = "Succubus", menuName = "ScriptableObjects/Card/Succubus", order = 1)]
    [System.Serializable]
    public class Succubus : BaseCard
    {

        Succubus()
        {
            components = new List<BaseCardComponent>()
            {
                new DealDrainDamageBaseOnTotalPartyAtk(),
                new CharmLowstAtkComponent()
            };
        }
    }
}
