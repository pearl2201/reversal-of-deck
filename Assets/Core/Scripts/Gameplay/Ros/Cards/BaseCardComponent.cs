using ReversalOfSpirit.Gameplay.Enums;
using System;

namespace ReversalOfSpirit.Gameplay.Ros.Cards
{
    [Serializable]
    public class BaseCardComponent : ICardBehaviour
    {
        public string longDescription;
        public string shortDescription;
        public virtual void OnStartRound(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase) { }
        public virtual void OnStartPreAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase) { }
        public virtual void PreAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase) { }
        public virtual void OnEndPreAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase) { }
        public virtual void OnStartPhyAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase) { }
        public virtual void OnPhyAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
         
        }
        public virtual void OnEndPhyAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase) { }
        public virtual void OnStartMagicalAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase) { }
        public virtual void OnMagicalTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase) { }
        public virtual void OnEndMagicalAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase) { }
        public virtual void OnEndRound(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase) { }
        public virtual void OnPlayerGetDamage(int damage, DamageType damageType, ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase) { }
        public virtual void OnPlayerGetEffect(GameEffect effect, ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase) { }
        public virtual void OnStartGame(ICardRuntimeStat runtimeStat, IRosGame game) { }

        public virtual void AfterAllWin(IRosPlayer owner, IRosGame game, RosRoundPhrase roundPhrase) { }

        public void AfterOpponentAllWin(IRosPlayer owner, IRosGame game, RosRoundPhrase roundPhrase)
        {

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
