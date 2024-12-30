using ReversalOfSpirit.Gameplay.Enums;
using ReversalOfSpirit.Gameplay.Ros.Cards.Actions;
using System.Collections.Generic;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Effects
{
    public class RaiseAtkOfNextTurnEffect : GameEffect
    {
        public float Percent { get; set; }
        public override GameEffectRoleType RoleType => GameEffectRoleType.Negative;

        public override void PreAtkTurn(IEffectContext context, IRosGame game, RosRoundPhrase roundPhrase)
        {
            base.PreAtkTurn(context, game, roundPhrase);
            game.ExecuteSequential(new List<GameAction>() { new IncreaseTurnAtkPercentAction(Stack, context.PlayerSlot, context.PlayerSlot) });
            IsExecuted = true;
        }

        public override EffectTriggerTimeCondition TriggerTime => EffectTriggerTimeCondition.CurrentRound;

        public override int RoundCount => 0;

        public override EffectEndType EndType => EffectEndType.OnTrigger;
    }
}
