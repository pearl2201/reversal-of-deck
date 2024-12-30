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


        public virtual void OnStartRound(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            foreach (var component in components)
            {
                component.OnStartRound(runtimeStat, game, roundPhrase);
            }
        }

        public virtual void OnStartPreAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            foreach (var component in components)
            {
                component.OnStartPreAtkTurn(runtimeStat, game, roundPhrase);
            }
        }

        public virtual void PreAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            foreach (var component in components)
            {
                component.PreAtkTurn(runtimeStat, game, roundPhrase);
            }
        }

        public virtual void OnEndPreAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            foreach (var component in components)
            {
                component.OnEndPreAtkTurn(runtimeStat, game, roundPhrase);
            }
        }

        public virtual void OnStartPhyAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            foreach (var component in components)
            {
                component.OnStartPhyAtkTurn(runtimeStat, game, roundPhrase);
            }
        }

        public virtual void OnPhyAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            foreach (var component in components)
            {
                component.OnPhyAtkTurn(runtimeStat, game, roundPhrase);
            }
            game.ExecuteSequential(new List<GameAction> { new PhysicalAttackAction(runtimeStat.Slot.CalculateAtk(), game.GetOpponent(runtimeStat.Owner), runtimeStat.Slot) });
        }

        public virtual void OnEndPhyAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            foreach (var component in components)
            {
                component.OnEndPhyAtkTurn(runtimeStat, game, roundPhrase);
            }
        }

        public virtual void OnStartMagicalAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            foreach (var component in components)
            {
                component.OnStartMagicalAtkTurn(runtimeStat, game, roundPhrase);
            }
        }

        public virtual void OnMagicalTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            foreach (var component in components)
            {
                component.OnMagicalTurn(runtimeStat, game, roundPhrase);
            }
        }

        public virtual void OnEndMagicalAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            foreach (var component in components)
            {
                component.OnEndMagicalAtkTurn(runtimeStat, game, roundPhrase);
            }
        }

        public virtual void OnEndRound(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            foreach (var component in components)
            {
                component.OnEndRound(runtimeStat, game, roundPhrase);
            }
        }

        public virtual void OnPlayerGetDamage(int damage, DamageType damageType, ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            foreach (var component in components)
            {
                component.OnPlayerGetDamage(damage, damageType, runtimeStat, game, roundPhrase);
            }
        }

        public virtual void OnPlayerGetEffect(GameEffect effect, ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            foreach (var component in components)
            {
                component.OnPlayerGetEffect(effect, runtimeStat, game, roundPhrase);
            }
        }

        public virtual void OnStartGame(ICardRuntimeStat runtimeStat, IRosGame game)
        {
            foreach (var component in components)
            {
                component.OnStartGame(runtimeStat, game);
            }
        }

        public void AfterAllWin(IRosPlayer owner, IRosGame game, RosRoundPhrase roundPhrase)
        {
            foreach (var component in components)
            {
                component.AfterAllWin(owner, game, roundPhrase);
            }
        }

        public void AfterOpponentAllWin(IRosPlayer owner, IRosGame game, RosRoundPhrase roundPhrase)
        {
            foreach (var component in components)
            {
                component.AfterOpponentAllWin(owner, game, roundPhrase);
            }
        }
    }
}
