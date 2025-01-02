
using Cysharp.Threading.Tasks;
using ReversalOfSpirit.Gameplay.Enums;
using ReversalOfSpirit.Gameplay.Ros.Cards.Actions;
using ReversalOfSpirit.Gameplay.Ros.Cards.Effects;

namespace ReversalOfSpirit.Gameplay.Ros.Cards
{
    public interface IEffectContext
    {
        public IRosPlayer Owner { get; }

        public RosPlayerSlot PlayerSlot { get; }
    }

    public class EffectContext : IEffectContext
    {
        public IRosPlayer Owner { get; set; }
        public RosPlayerSlot PlayerSlot { get; set; }
    }

    public enum EffectTriggerTimeCondition
    {
        CurrentRound,
        NextRound,
        CardPlay
    }

    public enum EffectEndType
    {
        OnTrigger,
        OnRoundCount
    }
    public interface IEffectBehaviour
    {
        UniTask OnStartGame(IEffectContext context, IRosGame game);

         UniTask OnStartRound(IEffectContext context, IRosGame game, RosRoundPhrase roundPhrase);

         UniTask OnStartPreAtkTurn(IEffectContext context, IRosGame game, RosRoundPhrase roundPhrase);

         UniTask PreAtkTurn(IEffectContext context, IRosGame game, RosRoundPhrase roundPhrase);

         UniTask OnEndPreAtkTurn(IEffectContext context, IRosGame game, RosRoundPhrase roundPhrase);

         UniTask OnStartPhyAtkTurn(IEffectContext context, IRosGame game, RosRoundPhrase roundPhrase);

         UniTask OnPhyAtkTurn(IEffectContext context, IRosGame game, RosRoundPhrase roundPhrase);

         UniTask OnEndPhyAtkTurn(IEffectContext context, IRosGame game, RosRoundPhrase roundPhrase);

         UniTask OnStartMagicalAtkTurn(IEffectContext context, IRosGame game, RosRoundPhrase roundPhrase);

         UniTask OnMagicalTurn(IEffectContext context, IRosGame game, RosRoundPhrase roundPhrase);

         UniTask OnEndMagicalAtkTurn(IEffectContext context, IRosGame game, RosRoundPhrase roundPhrase);

         UniTask OnEndRound(IEffectContext context, IRosGame game, RosRoundPhrase roundPhrase);

         UniTask OnPlayerGetDamage(IEffectContext context, SubHpAction subHpAction, IRosGame game);

         UniTask OnPlayerGetEffect(IEffectContext context, AddEffectToPlayerAction addEffectAction, IRosGame game);


         UniTask AfterAllWin(IEffectContext context, IRosPlayer owner, IRosGame game, RosRoundPhrase roundPhrase);

         UniTask AfterOpponentAllWin(IEffectContext context, IRosPlayer owner, IRosGame game, RosRoundPhrase roundPhrase);
    }
    public abstract class GameEffect : IEffectBehaviour
    {
        public int AssignedRoundIndex { get; protected set; } = 0;
        public bool IsStackable { get; protected set; }

        public int Stack { get; set; }
        public abstract GameEffectRoleType RoleType { get; }

        public abstract EffectTriggerTimeCondition TriggerTime { get; }

        public abstract int RoundCount { get; }

        public int currentRoundRemain { get; protected set; }

        public abstract EffectEndType EndType { get; }

        public bool IsExecuted { get; protected set; }
        public virtual bool IsDone()
        {
            if (currentRoundRemain == 0 && EffectEndType.OnRoundCount == EndType)
            {
                return true;
            }
            else if (EndType == EffectEndType.OnTrigger && IsExecuted)
            {
                return true;
            }
            return false;
        }


        public virtual UniTask OnStartRound(IEffectContext context, IRosGame game, RosRoundPhrase roundPhrase) { AssignedRoundIndex = game.RoundIndex; return UniTask.CompletedTask; }
        public virtual UniTask OnStartPreAtkTurn(IEffectContext context, IRosGame game, RosRoundPhrase roundPhrase) { AssignedRoundIndex = game.RoundIndex; return UniTask.CompletedTask;}
        public virtual UniTask PreAtkTurn(IEffectContext context, IRosGame game, RosRoundPhrase roundPhrase) { AssignedRoundIndex = game.RoundIndex; return UniTask.CompletedTask;}
        public virtual UniTask OnEndPreAtkTurn(IEffectContext context, IRosGame game, RosRoundPhrase roundPhrase) { AssignedRoundIndex = game.RoundIndex; return UniTask.CompletedTask;}
        public virtual UniTask OnStartPhyAtkTurn(IEffectContext context, IRosGame game, RosRoundPhrase roundPhrase) { AssignedRoundIndex = game.RoundIndex; return UniTask.CompletedTask;}
        public virtual UniTask OnPhyAtkTurn(IEffectContext context, IRosGame game, RosRoundPhrase roundPhrase) { AssignedRoundIndex = game.RoundIndex; return UniTask.CompletedTask;}
        public virtual UniTask OnEndPhyAtkTurn(IEffectContext context, IRosGame game, RosRoundPhrase roundPhrase) { AssignedRoundIndex = game.RoundIndex; return UniTask.CompletedTask;}
        public virtual UniTask OnStartMagicalAtkTurn(IEffectContext context, IRosGame game, RosRoundPhrase roundPhrase) { AssignedRoundIndex = game.RoundIndex; return UniTask.CompletedTask;}
        public virtual UniTask OnMagicalTurn(IEffectContext context, IRosGame game, RosRoundPhrase roundPhrase) { AssignedRoundIndex = game.RoundIndex; return UniTask.CompletedTask;}
        public virtual UniTask OnEndMagicalAtkTurn(IEffectContext context, IRosGame game, RosRoundPhrase roundPhrase) { AssignedRoundIndex = game.RoundIndex; return UniTask.CompletedTask;}
        public virtual UniTask OnEndRound(IEffectContext context, IRosGame game, RosRoundPhrase roundPhrase) { AssignedRoundIndex = game.RoundIndex; return UniTask.CompletedTask;}
        public virtual UniTask OnPlayerGetDamage(IEffectContext context, SubHpAction subHpAction, IRosGame game) { AssignedRoundIndex = game.RoundIndex; return UniTask.CompletedTask;}
        public virtual UniTask OnPlayerGetEffect(IEffectContext context, AddEffectToPlayerAction addEffectAction, IRosGame game) { AssignedRoundIndex = game.RoundIndex; return UniTask.CompletedTask;}
        public virtual UniTask OnStartGame(IEffectContext context, IRosGame game) { AssignedRoundIndex = game.RoundIndex; return UniTask.CompletedTask;}
        public virtual UniTask AfterAllWin(IEffectContext context, IRosPlayer owner, IRosGame game, RosRoundPhrase roundPhrase) { AssignedRoundIndex = game.RoundIndex; return UniTask.CompletedTask;}

        public UniTask AfterOpponentAllWin(IEffectContext context, IRosPlayer owner, IRosGame game, RosRoundPhrase roundPhrase)
        {
            AssignedRoundIndex = game.RoundIndex;
            return UniTask.CompletedTask;
        }

        //public virtual void Serialize(IRosGame game, NetDataWriter writer)
        //{

        //}

        //public virtual void Deserialize(IRosGame game, NetDataReader reader)
        //{

        //}

        //public static GameEffect DeserializeGameEffect(IRosGame game, NetDataReader reader)
        //{
        //    var effectType = reader.GetString();
        //    GameEffect effect = null;
        //    if (effectType == nameof(CurseEffect))
        //    {
        //        effect = new CurseEffect();
        //        effect.Deserialize(game, reader);
        //    }
        //    else if (effectType == nameof(CharmLowestAtkEffect))
        //    {
        //        effect = new CharmLowestAtkEffect();
        //        effect.Deserialize(game, reader);
        //    }
        //    else if (effectType == nameof(RaiseAtkOfNextTurnEffect))
        //    {
        //        effect = new RaiseAtkOfNextTurnEffect();
        //        effect.Deserialize(game, reader);
        //    }
        //    else if (effectType == nameof(AbsortPhysicalForCounterAttackEffect))
        //    {
        //        effect = new AbsortPhysicalForCounterAttackEffect();
        //        effect.Deserialize(game, reader);
        //    }
        //    else if (effectType == nameof(PhysicalAbsCounterAttackEffect))
        //    {
        //        effect = new PhysicalAbsCounterAttackEffect();
        //        effect.Deserialize(game, reader);
        //    }
        //    else
        //    {
        //        UnityEngine.Debug.LogError("Unknow effect type: " + effectType);
        //    }
        //    return effect;
        //}

    }
}
