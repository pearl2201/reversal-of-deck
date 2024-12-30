using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversalOfSpirit.Gameplay.Ros
{
    public class RosRoundState
    {
        public int FirstPlayerWinCount { get; set; }

        public int SecondPlayerWinCount { get; set; }

        public int LastPhysicalDamage { get; set; } // counter physical attack

        public int LastMagicalDamage { get; set; } // counter magical attack

        public bool IsPlayerABeSilenceTurn { get; set; }

        public bool IsPlayerBBeSilenceTurn { get; set; }

        public bool IsPlayerAIgnoreArmorAttack { get; set; }

        public bool IsPlayerBIgnoreArmorAttack { get; set; }
    }
}
