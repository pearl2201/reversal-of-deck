using ReversalOfSpirit.Gameplay.Ros.Cards.Components;
using ReversalOfSpirit.Gameplay.Ros.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Impl
{
    [CreateAssetMenu(fileName = "Healer", menuName = "ScriptableObjects/Card/Healer", order = 1)]
    [System.Serializable]
    public class Healer : BaseCard
    {

        Healer()
        {
            components = new List<BaseCardComponent>()
            {
                new RestoreHpComponent()
            };
        }
    }
}
