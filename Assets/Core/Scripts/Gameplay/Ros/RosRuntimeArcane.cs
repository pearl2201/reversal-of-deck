using ReversalOfSpirit.Gameplay.Ros.Arcanes;

namespace ReversalOfSpirit.Gameplay.Ros
{
    public class RosRuntimeArcane: IArcaneRuntimeStat
    {
        public int Level { get; set; }
        public BaseArcane Arcane { get; set; }

        public IRosPlayer Owner { get; set; }
    }
}
