using Cysharp.Threading.Tasks;
using ReversalOfSpirit.Gameplay.Enums;
using System;

namespace ReversalOfSpirit.Gameplay.Ros.Cards
{
    [Serializable]
    public class BaseCardComponent : ICardBehaviour
    {
        public string longDescription;
        public string shortDescription;
        public virtual UniTask OnStartRound(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase) { return UniTask.CompletedTask; }
        public virtual UniTask OnStartPreAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase) { return UniTask.CompletedTask; }
        public virtual UniTask PreAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase) { return UniTask.CompletedTask; }
        public virtual UniTask OnEndPreAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase) { return UniTask.CompletedTask; }
        public virtual UniTask OnStartPhyAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase) { return UniTask.CompletedTask; }
        public virtual UniTask OnPhyAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase) { return UniTask.CompletedTask; }
        public virtual UniTask OnEndPhyAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase) { return UniTask.CompletedTask; }
        public virtual UniTask OnStartMagicalAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase) { return UniTask.CompletedTask; }
        public virtual UniTask OnMagicalTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase) { return UniTask.CompletedTask; }
        public virtual UniTask OnEndMagicalAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase) { return UniTask.CompletedTask; }
        public virtual UniTask OnEndRound(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase) { return UniTask.CompletedTask; }
        public virtual UniTask OnPlayerGetDamage(int damage, DamageType damageType, ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase) { return UniTask.CompletedTask; }
        public virtual UniTask OnPlayerGetEffect(GameEffect effect, ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase) { return UniTask.CompletedTask; }
        public virtual UniTask OnStartGame(ICardRuntimeStat runtimeStat, IRosGame game) { return UniTask.CompletedTask; }

        public virtual UniTask AfterAllWin(IRosPlayer owner, IRosGame game, RosRoundPhrase roundPhrase) { return UniTask.CompletedTask; }

        public UniTask AfterOpponentAllWin(IRosPlayer owner, IRosGame game, RosRoundPhrase roundPhrase)
        {
            return UniTask.CompletedTask;
        }

        public virtual string GetShortDescription()
        {
            return String.Empty;
        }

        public virtual string GetLongDescription()
        {
            return String.Empty;
        }
    }
}
