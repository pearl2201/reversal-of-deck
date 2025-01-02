using ReversalOfSpirit.Gameplay.Enums;
using ReversalOfSpirit.Gameplay.Ros.Cards;
using UnityEngine;

namespace ReversalOfSpirit.Gameplay.Ros.Talent
{
    [System.Serializable]
    public abstract class BaseTalent : ScriptableObject, ITalentBehaviour
    {
        public int id;

        public string name;

        public int level;

        public int maxLevel;

        public virtual float GetAdditionAtk()
        {
            return 0;
        }

        public virtual float GetAdditionArmor()
        {
            return 0;
        }

        public virtual float GetAdditionHp()
        {
            return 0;
        }

        public virtual float GetAdditionAtkByPosition(GameTerritory slot)
        {
            return 0;
        }

        public virtual void OnStartGame(ITalentRuntimeStat runtimeStat, IRosGame game)
        {

        }

        public virtual async UniTask OnStartRound(ITalentRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {

        }

        public virtual void OnStartPreAtkTurn(ITalentRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {

        }

        public virtual void PreAtkTurn(ITalentRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {

        }

        public virtual void OnEndPreAtkTurn(ITalentRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {

        }

        public virtual void OnStartPhyAtkTurn(ITalentRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {

        }

        public virtual void OnPhyAtkTurn(ITalentRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {

        }

        public virtual void OnEndPhyAtkTurn(ITalentRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {

        }

        public virtual void OnStartMagicalAtkTurn(ITalentRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {

        }

        public virtual void OnMagicalTurn(ITalentRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {

        }

        public virtual void OnEndMagicalAtkTurn(ITalentRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {

        }

        public virtual void OnEndRound(ITalentRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {

        }

        public virtual void OnPlayerGetDamage(int damage, ITalentRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {

        }

        public virtual void OnPlayerGetEffect(GameEffect effect, ITalentRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {

        }

        public virtual void AfterAllWin(IRosPlayer owner, IRosGame game, RosRoundPhrase roundPhrase)
        {

        }

        public virtual void AfterOpponentAllWin(IRosPlayer owner, IRosGame game, RosRoundPhrase roundPhrase)
        {

        }
    }
}
