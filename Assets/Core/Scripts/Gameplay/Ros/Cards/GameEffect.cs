
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
        void OnStartGame(IEffectContext context, IRosGame game);

        void OnStartRound(IEffectContext context, IRosGame game, RosRoundPhrase roundPhrase);

        void OnStartPreAtkTurn(IEffectContext context, IRosGame game, RosRoundPhrase roundPhrase);

        void PreAtkTurn(IEffectContext context, IRosGame game, RosRoundPhrase roundPhrase);

        void OnEndPreAtkTurn(IEffectContext context, IRosGame game, RosRoundPhrase roundPhrase);

        void OnStartPhyAtkTurn(IEffectContext context, IRosGame game, RosRoundPhrase roundPhrase);

        void OnPhyAtkTurn(IEffectContext context, IRosGame game, RosRoundPhrase roundPhrase);

        void OnEndPhyAtkTurn(IEffectContext context, IRosGame game, RosRoundPhrase roundPhrase);

        void OnStartMagicalAtkTurn(IEffectContext context, IRosGame game, RosRoundPhrase roundPhrase);

        void OnMagicalTurn(IEffectContext context, IRosGame game, RosRoundPhrase roundPhrase);

        void OnEndMagicalAtkTurn(IEffectContext context, IRosGame game, RosRoundPhrase roundPhrase);

        void OnEndRound(IEffectContext context, IRosGame game, RosRoundPhrase roundPhrase);

        void OnPlayerGetDamage(IEffectContext context, SubHpAction subHpAction, IRosGame game);

        void OnPlayerGetEffect(IEffectContext context, AddEffectToPlayerAction addEffectAction, IRosGame game);


        void AfterAllWin(IEffectContext context, IRosPlayer owner, IRosGame game, RosRoundPhrase roundPhrase);

        void AfterOpponentAllWin(IEffectContext context, IRosPlayer owner, IRosGame game, RosRoundPhrase roundPhrase);
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


        public virtual void OnStartRound(IEffectContext context, IRosGame game, RosRoundPhrase roundPhrase) { AssignedRoundIndex = game.roundIndex; }
        public virtual void OnStartPreAtkTurn(IEffectContext context, IRosGame game, RosRoundPhrase roundPhrase) { AssignedRoundIndex = game.roundIndex; }
        public virtual void PreAtkTurn(IEffectContext context, IRosGame game, RosRoundPhrase roundPhrase) { AssignedRoundIndex = game.roundIndex; }
        public virtual void OnEndPreAtkTurn(IEffectContext context, IRosGame game, RosRoundPhrase roundPhrase) { AssignedRoundIndex = game.roundIndex; }
        public virtual void OnStartPhyAtkTurn(IEffectContext context, IRosGame game, RosRoundPhrase roundPhrase) { AssignedRoundIndex = game.roundIndex; }
        public virtual void OnPhyAtkTurn(IEffectContext context, IRosGame game, RosRoundPhrase roundPhrase) { AssignedRoundIndex = game.roundIndex; }
        public virtual void OnEndPhyAtkTurn(IEffectContext context, IRosGame game, RosRoundPhrase roundPhrase) { AssignedRoundIndex = game.roundIndex; }
        public virtual void OnStartMagicalAtkTurn(IEffectContext context, IRosGame game, RosRoundPhrase roundPhrase) { AssignedRoundIndex = game.roundIndex; }
        public virtual void OnMagicalTurn(IEffectContext context, IRosGame game, RosRoundPhrase roundPhrase) { AssignedRoundIndex = game.roundIndex; }
        public virtual void OnEndMagicalAtkTurn(IEffectContext context, IRosGame game, RosRoundPhrase roundPhrase) { AssignedRoundIndex = game.roundIndex; }
        public virtual void OnEndRound(IEffectContext context, IRosGame game, RosRoundPhrase roundPhrase) { AssignedRoundIndex = game.roundIndex; }
        public virtual void OnPlayerGetDamage(IEffectContext context, SubHpAction subHpAction, IRosGame game) { AssignedRoundIndex = game.roundIndex; }
        public virtual void OnPlayerGetEffect(IEffectContext context, AddEffectToPlayerAction addEffectAction, IRosGame game) { AssignedRoundIndex = game.roundIndex; }
        public virtual void OnStartGame(IEffectContext context, IRosGame game) { AssignedRoundIndex = game.roundIndex; }

        public virtual void AfterAllWin(IEffectContext context, IRosPlayer owner, IRosGame game, RosRoundPhrase roundPhrase) { AssignedRoundIndex = game.roundIndex; }

        public void AfterOpponentAllWin(IEffectContext context, IRosPlayer owner, IRosGame game, RosRoundPhrase roundPhrase)
        {
            AssignedRoundIndex = game.roundIndex;
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
