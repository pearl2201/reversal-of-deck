using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ReversalOfSpirit.Gameplay.Ros.Talent
{
    [CreateAssetMenu(fileName = "AddArmorOnStartGameTalent", menuName = "ScriptableObjects/Talents/AddArmorOnStartGameTalent", order = 1)]
    [System.Serializable]
    public class AddArmorOnStartGameTalent : BaseTalent
    {

        public int armor;

        public override void OnStartGame(ITalentRuntimeStat runtimeStat, IRosGame game)
        {
            base.OnStartGame(runtimeStat, game);

            runtimeStat.Owner.OnGainShieldAction(new Cards.Actions.GainShieldAction(armor, runtimeStat.Owner, null, 1));
        }
    }
}
