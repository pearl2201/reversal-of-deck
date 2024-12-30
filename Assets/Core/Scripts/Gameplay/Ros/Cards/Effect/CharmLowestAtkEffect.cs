using ReversalOfSpirit.Gameplay.Enums;
using ReversalOfSpirit.Gameplay.Ros.Cards.Actions;
using System.Linq;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Effects
{
    public class CharmLowestAtkEffect : GameEffect
    {
        public override GameEffectRoleType RoleType => GameEffectRoleType.Negative;

        public override void OnStartRound(IEffectContext context, IRosGame game, RosRoundPhrase roundPhrase)
        {
            base.OnStartRound(context, game, roundPhrase);
            var charmCard = context.Owner.handItems.GroupBy(x => x.id).Select(x => new { id = x.Key, count = x.Count() }).OrderBy(x => x.count).Take(Stack).ToList();
            var actions = new System.Collections.Generic.List<GameAction>
            {
                new CharmCardAction(charmCard[0].id, GameTerritory.Vanguard, context.Owner, context.PlayerSlot)
            };

            if (Stack >= 2)
            {
                actions.Add(new CharmCardAction(charmCard[1].id, GameTerritory.Center, context.Owner, context.PlayerSlot));
            }
            if (Stack >= 3)
            {
                actions.Add(new CharmCardAction(charmCard[2].id, GameTerritory.Rearguard, context.Owner, context.PlayerSlot));
            }
            game.ExecuteSequential(actions);
           
        }

        public override EffectTriggerTimeCondition TriggerTime => EffectTriggerTimeCondition.NextRound;

        public override int RoundCount => 1;

        public override EffectEndType EndType => EffectEndType.OnTrigger;
    }
}
