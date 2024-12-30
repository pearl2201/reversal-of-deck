using ReversalOfSpirit.Gameplay.Ros.Cards;
using ReversalOfSpirit.Gameplay.Ros.Talent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversalOfSpirit.Gameplay.Ros
{
    public class RosRuntimeTalent: ITalentRuntimeStat
    {
        public int Level { get; set; }
        public BaseTalent Talent { get; set; }

        public IRosPlayer Owner { get; set; }
    }
}
