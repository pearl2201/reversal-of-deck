using Cysharp.Threading.Tasks;
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

        public virtual UniTask OnStartGame(ITalentRuntimeStat runtimeStat, IRosGame game)
        {
            return UniTask.CompletedTask;
        }

        public virtual UniTask OnStartRound(ITalentRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            return UniTask.CompletedTask;
        }

        public virtual UniTask OnStartPreAtkTurn(ITalentRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            return UniTask.CompletedTask;
        }

        public virtual UniTask PreAtkTurn(ITalentRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            return UniTask.CompletedTask;
        }

        public virtual UniTask OnEndPreAtkTurn(ITalentRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            return UniTask.CompletedTask;
        }

        public virtual UniTask OnStartPhyAtkTurn(ITalentRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            return UniTask.CompletedTask;
        }

        public virtual UniTask OnPhyAtkTurn(ITalentRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            return UniTask.CompletedTask;
        }

        public virtual UniTask OnEndPhyAtkTurn(ITalentRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            return UniTask.CompletedTask;
        }

        public virtual UniTask OnStartMagicalAtkTurn(ITalentRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            return UniTask.CompletedTask;
        }

        public virtual UniTask OnMagicalTurn(ITalentRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            return UniTask.CompletedTask;
        }

        public virtual UniTask OnEndMagicalAtkTurn(ITalentRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            return UniTask.CompletedTask;
        }

        public virtual UniTask OnEndRound(ITalentRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            return UniTask.CompletedTask;
        }

        public virtual UniTask OnPlayerGetDamage(int damage, ITalentRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            return UniTask.CompletedTask;
        }

        public virtual UniTask OnPlayerGetEffect(GameEffect effect, ITalentRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            return UniTask.CompletedTask;
        }

        public virtual UniTask AfterAllWin(IRosPlayer owner, IRosGame game, RosRoundPhrase roundPhrase)
        {
            return UniTask.CompletedTask;
        }

        public virtual UniTask AfterOpponentAllWin(IRosPlayer owner, IRosGame game, RosRoundPhrase roundPhrase)
        {
            return UniTask.CompletedTask;
        }
    }
}
