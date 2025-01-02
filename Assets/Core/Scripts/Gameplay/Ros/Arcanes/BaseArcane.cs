using Cysharp.Threading.Tasks;
using ReversalOfSpirit.Gameplay.Enums;
using ReversalOfSpirit.Gameplay.Ros.Cards;
using ReversalOfSpirit.Gameplay.Ros.Cards.Actions;
using System.Collections.Generic;
using UnityEngine;

namespace ReversalOfSpirit.Gameplay.Ros.Arcanes
{
    [System.Serializable]
    public abstract class BaseArcane : ScriptableObject, IArcaneBehaviour
    {
        public int id;

        public string name;

        public int level;

        public int maxLevel;

        public int cost;

        public Dictionary<int, int> requiredManas;

        public Dictionary<string, string> descriptions;

        public virtual void Execute(IArcaneRuntimeStat runtimeStat, IRosGame game)
        {
            game.ExecuteSequential(new List<GameAction> { new ReduceManaStatAction(cost, runtimeStat.Owner, null, 1) { } });
        }

        public virtual void OnStartGame(IArcaneRuntimeStat runtimeStat, IRosGame game)
        {

        }

        public virtual async UniTask OnStartRound(IArcaneRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {

        }

        public virtual void OnStartPreAtkTurn(IArcaneRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {

        }

        public virtual void PreAtkTurn(IArcaneRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {

        }

        public virtual void OnEndPreAtkTurn(IArcaneRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {

        }

        public virtual void OnStartPhyAtkTurn(IArcaneRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {

        }

        public virtual void OnPhyAtkTurn(IArcaneRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {

        }

        public virtual void OnEndPhyAtkTurn(IArcaneRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {

        }

        public virtual void OnStartMagicalAtkTurn(IArcaneRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {

        }

        public virtual void OnMagicalTurn(IArcaneRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {

        }

        public virtual void OnEndMagicalAtkTurn(IArcaneRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {

        }

        public virtual void OnEndRound(IArcaneRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {

        }

        public virtual void OnPlayerGetDamage(int damage, IArcaneRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {

        }

        public virtual void OnPlayerGetEffect(GameEffect effect, IArcaneRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
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
