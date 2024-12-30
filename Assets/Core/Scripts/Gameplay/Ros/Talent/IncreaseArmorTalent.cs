using UnityEngine;

namespace ReversalOfSpirit.Gameplay.Ros.Talent
{
    [CreateAssetMenu(fileName = "IncreaseArmorTalent", menuName = "ScriptableObjects/Talents/IncreaseArmorTalent", order = 1)]
    [System.Serializable]
    public class IncreaseArmorTalent : BaseTalent
    {
        public float Percent;

        public override float GetAdditionArmor()
        {
            return Percent;
        }
    }
}
