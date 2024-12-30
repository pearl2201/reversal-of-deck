using ReversalOfSpirit.Gameplay.Ros.Cards.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Impl
{
    [CreateAssetMenu(fileName = "Errant", menuName = "ScriptableObjects/Card/Errant", order = 1)]
    [System.Serializable]
    public class Errant : BaseCard
    {

        Errant()
        {
            components = new List<BaseCardComponent>()
            {
                new RaiseAtkBaseOnMissingUpHpComponent(),
                new SubtractSwapCardChanceComponent()
            };
        }
    }
}
