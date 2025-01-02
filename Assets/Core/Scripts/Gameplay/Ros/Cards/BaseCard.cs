using Cysharp.Threading.Tasks;
using ReversalOfSpirit.Gameplay.Enums;
using ReversalOfSpirit.Gameplay.Ros.Cards.Actions;
using System.Collections.Generic;
using UnityEngine;

namespace ReversalOfSpirit.Gameplay.Ros.Cards
{
    public class BaseCard : ScriptableObject, ICardBehaviour
    {
        public int id;

        public string name;

        public Sprite avatar;

        public string description;

        public int level;

        public int maxLevel;

        public int armor;

        public int hp;

        public int atk;
        [SerializeReference]
        public List<BaseCardComponent> components = new List<BaseCardComponent>();


        public virtual async UniTask OnStartRound(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            foreach (var component in components)
            {
                await component.OnStartRound(runtimeStat, game, roundPhrase);
            }
        }

        public virtual async UniTask OnStartPreAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            foreach (var component in components)
            {
                await component.OnStartPreAtkTurn(runtimeStat, game, roundPhrase);
            }
        }

        public virtual async UniTask PreAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            foreach (var component in components)
            {
                await component.PreAtkTurn(runtimeStat, game, roundPhrase);
            }
        }

        public virtual async UniTask OnEndPreAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            foreach (var component in components)
            {
                await component.OnEndPreAtkTurn(runtimeStat, game, roundPhrase);
            }
        }

        public virtual async UniTask OnStartPhyAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            foreach (var component in components)
            {
                await component.OnStartPhyAtkTurn(runtimeStat, game, roundPhrase);
            }
        }

        public virtual async UniTask OnPhyAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            foreach (var component in components)
            {
                await component.OnPhyAtkTurn(runtimeStat, game, roundPhrase);
            }
            await game.ExecuteSequential(new List<GameAction> { new PhysicalAttackAction(runtimeStat.Slot.CalculateAtk(), game.GetOpponent(runtimeStat.Owner), runtimeStat.Slot) });
        }

        public virtual async UniTask OnEndPhyAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            foreach (var component in components)
            {
                await component.OnEndPhyAtkTurn(runtimeStat, game, roundPhrase);
            }
        }

        public virtual async UniTask OnStartMagicalAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            foreach (var component in components)
            {
                await component.OnStartMagicalAtkTurn(runtimeStat, game, roundPhrase);
            }
        }

        public virtual async UniTask OnMagicalTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            foreach (var component in components)
            {
                await component.OnMagicalTurn(runtimeStat, game, roundPhrase);
            }
        }

        public virtual async UniTask OnEndMagicalAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            foreach (var component in components)
            {
                await component.OnEndMagicalAtkTurn(runtimeStat, game, roundPhrase);
            }
        }

        public virtual async UniTask OnEndRound(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            foreach (var component in components)
            {
                await component.OnEndRound(runtimeStat, game, roundPhrase);
            }
        }

        public virtual async UniTask OnPlayerGetDamage(int damage, DamageType damageType, ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            foreach (var component in components)
            {
                await component.OnPlayerGetDamage(damage, damageType, runtimeStat, game, roundPhrase);
            }
        }

        public virtual async UniTask OnPlayerGetEffect(GameEffect effect, ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            foreach (var component in components)
            {
                await component.OnPlayerGetEffect(effect, runtimeStat, game, roundPhrase);
            }
        }

        public virtual async UniTask OnStartGame(ICardRuntimeStat runtimeStat, IRosGame game)
        {
            foreach (var component in components)
            {
                await component.OnStartGame(runtimeStat, game);
            }
        }

        public async UniTask AfterAllWin(IRosPlayer owner, IRosGame game, RosRoundPhrase roundPhrase)
        {
            foreach (var component in components)
            {
                await component.AfterAllWin(owner, game, roundPhrase);
            }
        }

        public async UniTask AfterOpponentAllWin(IRosPlayer owner, IRosGame game, RosRoundPhrase roundPhrase)
        {
            foreach (var component in components)
            {
                await component.AfterOpponentAllWin(owner, game, roundPhrase);
            }
        }
    }
}
