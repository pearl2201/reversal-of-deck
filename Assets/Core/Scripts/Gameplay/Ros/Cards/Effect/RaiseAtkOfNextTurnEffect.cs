using Cysharp.Threading.Tasks;
using ReversalOfSpirit.Gameplay.Enums;
using ReversalOfSpirit.Gameplay.Ros.Cards.Actions;
using System.Collections.Generic;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Effects
{
    public class RaiseAtkOfNextTurnEffect : GameEffect
    {
        public float Percent { get; set; }
        public override GameEffectRoleType RoleType => GameEffectRoleType.Negative;

        public override async UniTask PreAtkTurn(IEffectContext context, IRosGame game, RosRoundPhrase roundPhrase)
        {
            await base.PreAtkTurn(context, game, roundPhrase);
            await game.ExecuteSequential(new List<GameAction>() { new IncreaseTurnAtkPercentAction(Stack, context.PlayerSlot, context.PlayerSlot) });
            IsExecuted = true;
        }

        public override EffectTriggerTimeCondition TriggerTime => EffectTriggerTimeCondition.CurrentRound;

        public override int RoundCount => 0;

        public override EffectEndType EndType => EffectEndType.OnTrigger;
    }
}
