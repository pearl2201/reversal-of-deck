using ReversalOfSpirit.Gameplay.Enums;
using ReversalOfSpirit.Gameplay.Ros.Cards.Actions;
using System.Collections.Generic;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Effects
{
    public class CurseEffect : GameEffect
    {
        public CurseEffect() : base()
        {

        }
        public override GameEffectRoleType RoleType => GameEffectRoleType.Negative;

        public override void OnStartPreAtkTurn(IEffectContext context, IRosGame game, RosRoundPhrase roundPhrase)
        {
            game.ExecuteSequential(new List<GameAction>() { new CurseDamageAction(Stack, context.Owner, context.PlayerSlot) });
            IsExecuted = true;
        }

        public override EffectTriggerTimeCondition TriggerTime => EffectTriggerTimeCondition.CardPlay;

        public override int RoundCount => 0;

        public override EffectEndType EndType => EffectEndType.OnTrigger;
    }
}
