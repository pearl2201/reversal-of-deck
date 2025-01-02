using Cysharp.Threading.Tasks;
using ReversalOfSpirit.Gameplay.Enums;
using ReversalOfSpirit.Gameplay.Ros.Cards;
using ReversalOfSpirit.Gameplay.Ros.Cards.Actions;
using System.Collections.Generic;
using System.Linq;

namespace ReversalOfSpirit.Gameplay.Ros
{
    public class RosPlayerSlot
    {
        public RosRuntimeCard Card { get; set; }


        public int CalculateArmor()
        {
            return Card.BaseArmor;
        }

        public int CalculateHp()
        {
            return Card.BaseHp;
        }

        public int CalculateAtk()
        {
            UnityEngine.Debug.Log($"CalculateAtk of {Card.CardDefinition.name} = ({Card.BaseAtk} * (1 + {AdditionTurnAtkPercent}) + {AdditionTurnAtkAbs}");
            return (int)(Card.BaseAtk * (1 + AdditionTurnAtkPercent) + AdditionTurnAtkAbs);
        }

        public int CalculateStar()
        {
            return Card.BaseStar;
        }

        public bool IsSilentRound { get; set; }

        public float AdditionTalentAtkPercent { get; set; }

        public float AdditionTurnAtkPercent { get; set; }

        public float AdditionTurnAtkAbs { get; set; }

        public GameTerritory Terriotory { get; set; }

        public IRosPlayer Player { get; set; }

        public List<GameEffect> effects;

        public RosPlayerSlot(IRosPlayer player, GameTerritory territory)
        {
            Player = player;
            Terriotory = territory;
            effects = new List<GameEffect>();
        }

        public UniTask OnStartRound()
        {
            AdditionTurnAtkPercent = 0;
            AdditionTurnAtkAbs = 0;
            return UniTask.CompletedTask;
        }

        public async UniTask OnStartRound(bool isWin, RosRoundPhrase roundPhrase)
        {
            foreach (var effect in effects.ToList())
            {
                await effect.OnStartRound(new EffectContext { Owner = Player, PlayerSlot = this }, Player.Game, roundPhrase);
            }
            RemoveFinishedEffect();
        }

        public async UniTask OnStartPreAtkTurn(bool isWin, RosRoundPhrase roundPhrase)
        {
            foreach (var effect in effects.ToList())
            {
                await effect.OnStartPreAtkTurn(new EffectContext { Owner = Player, PlayerSlot = this }, Player.Game, roundPhrase);
            }
        }

        public async UniTask PreAtkTurn(bool isWin, RosRoundPhrase roundPhrase)
        {
            foreach (var effect in effects.ToList())
            {
                await effect.PreAtkTurn(new EffectContext { Owner = Player, PlayerSlot = this }, Player.Game, roundPhrase);
            }
        }

        public async UniTask OnEndPreAtkTurn(bool isWin, RosRoundPhrase roundPhrase)
        {
            foreach (var effect in effects.ToList())
            {
                await effect.OnEndPreAtkTurn(new EffectContext { Owner = Player, PlayerSlot = this }, Player.Game, roundPhrase);
            }
        }

        public async UniTask OnStartPhyAtkTurn(bool isWin, RosRoundPhrase roundPhrase)
        {
            foreach (var effect in effects.ToList())
            {
                await effect.OnStartPhyAtkTurn(new EffectContext { Owner = Player, PlayerSlot = this }, Player.Game, roundPhrase);
            }
        }

        public async UniTask OnPhyAtkTurn(bool isWin, RosRoundPhrase roundPhrase)
        {
            foreach (var effect in effects.ToList())
            {
                await effect.OnPhyAtkTurn(new EffectContext { Owner = Player, PlayerSlot = this }, Player.Game, roundPhrase);
            }
        }

        public async UniTask OnEndPhyAtkTurn(bool isWin, RosRoundPhrase roundPhrase)
        {
            foreach (var effect in effects.ToList())
            {
                await effect.OnEndPhyAtkTurn(new EffectContext { Owner = Player, PlayerSlot = this }, Player.Game, roundPhrase);
            }
        }

        public async UniTask OnStartMagicalAtkTurn(bool isWin, RosRoundPhrase roundPhrase)
        {
            foreach (var effect in effects.ToList())
            {
                await effect.OnStartMagicalAtkTurn(new EffectContext { Owner = Player, PlayerSlot = this }, Player.Game, roundPhrase);
            }
        }

        public async UniTask OnMagicalTurn(bool isWin, RosRoundPhrase roundPhrase)
        {
            foreach (var effect in effects.ToList())
            {
                await effect.OnMagicalTurn(new EffectContext { Owner = Player, PlayerSlot = this }, Player.Game, roundPhrase);
            }
        }

        public async UniTask OnEndMagicalAtkTurn(bool isWin, RosRoundPhrase roundPhrase)
        {
            foreach (var effect in effects.ToList())
            {
                await effect.OnEndMagicalAtkTurn(new EffectContext { Owner = Player, PlayerSlot = this }, Player.Game, roundPhrase);
            }
        }

        public async UniTask OnEndRound(bool isWin, RosRoundPhrase roundPhrase)
        {
            foreach (var effect in effects.ToList())
            {
                await effect.OnEndRound(new EffectContext { Owner = Player, PlayerSlot = this }, Player.Game, roundPhrase);
            }
        }

        public async UniTask OnPlayerGetDamage(SubHpAction subHpAction)
        {
            foreach (var effect in effects.ToList())
            {
                await effect.OnPlayerGetDamage(new EffectContext { Owner = Player, PlayerSlot = this }, subHpAction, Player.Game);
            }
        }

        public async UniTask OnPlayerGetEffect(AddEffectToPlayerAction addEffectAction, bool isWin, RosRoundPhrase roundPhrase)
        {
            foreach (var effect in effects.ToList())
            {
                await effect.OnPlayerGetEffect(new EffectContext { Owner = Player, PlayerSlot = this }, addEffectAction, Player.Game);
            }
        }

        public async UniTask OnStartGame(IRosGame game)
        {
            foreach (var effect in effects.ToList())
            {
                await effect.OnStartGame(new EffectContext { Owner = Player, PlayerSlot = this }, game);
            }
        }

        public async UniTask AfterAllWin(IRosPlayer owner, bool isWin, RosRoundPhrase roundPhrase)
        {
            foreach (var effect in effects.ToList())
            {
                await effect.AfterAllWin(new EffectContext { Owner = Player, PlayerSlot = this }, owner, Player.Game, roundPhrase);
            }
        }

        public async UniTask AfterOpponentAllWin(IRosPlayer owner, bool isWin, RosRoundPhrase roundPhrase)
        {
            foreach (var effect in effects.ToList())
            {
                await effect.AfterOpponentAllWin(new EffectContext { Owner = Player, PlayerSlot = this }, owner, Player.Game, roundPhrase);
            }
        }

        public void RemoveFinishedEffect()
        {
            effects = effects.Where(x => !x.IsDone()).ToList();

        }

        public void OnAddEffectToCardSlotAction(AddEffectToPlayerCardSlotAction act)
        {
            effects.Add(act.effect);
        }
    }
}
