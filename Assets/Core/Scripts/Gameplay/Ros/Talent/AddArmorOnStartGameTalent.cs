using Cysharp.Threading.Tasks;
using UnityEngine;

namespace ReversalOfSpirit.Gameplay.Ros.Talent
{
    [CreateAssetMenu(fileName = "AddArmorOnStartGameTalent", menuName = "ScriptableObjects/Talents/AddArmorOnStartGameTalent", order = 1)]
    [System.Serializable]
    public class AddArmorOnStartGameTalent : BaseTalent
    {

        public int armor;

        public override async UniTask OnStartGame(ITalentRuntimeStat runtimeStat, IRosGame game)
        {
            await base.OnStartGame(runtimeStat, game);

            await runtimeStat.Owner.OnGainShieldAction(new Cards.Actions.GainShieldAction(armor, runtimeStat.Owner, null, 1));
        }
    }
}
