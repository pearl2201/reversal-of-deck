using ReversalOfSpirit.Gameplay.Enums;
using ReversalOfSpirit.Gameplay.Ros.Cards;
using ReversalOfSpirit.Gameplay.Ros.Cards.Actions;
using System.Collections.Generic;
using System.Diagnostics;
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

        public float AbsortPhysicalDamage { get; set; }

        public GameTerritory Terriotory { get; set; }

        public IRosPlayer Player { get; set; }

        public List<GameEffect> effects;

        public RosPlayerSlot(IRosPlayer player, GameTerritory territory)
        {
            Player = player;
            Terriotory = territory;
            effects = new List<GameEffect>();
        }

        public void OnStartRound()
        {
            AdditionTurnAtkPercent = 0;
            AdditionTurnAtkAbs = 0;
            AbsortPhysicalDamage = 0;
        }

        public void OnStartRound(bool isWin, RosRoundPhrase roundPhrase)
        {
            foreach (var effect in effects.ToList())
            {
                effect.OnStartRound(new EffectContext { Owner = Player, PlayerSlot = this }, Player.Game, roundPhrase);
            }
            RemoveFinishedEffect();
        }

        public void OnStartPreAtkTurn(bool isWin, RosRoundPhrase roundPhrase)
        {
            foreach (var effect in effects.ToList())
            {
                effect.OnStartPreAtkTurn(new EffectContext { Owner = Player, PlayerSlot = this }, Player.Game, roundPhrase);
            }
        }

        public void PreAtkTurn(bool isWin, RosRoundPhrase roundPhrase)
        {
            foreach (var effect in effects.ToList())
            {
                effect.PreAtkTurn(new EffectContext { Owner = Player, PlayerSlot = this }, Player.Game, roundPhrase);
            }
        }

        public void OnEndPreAtkTurn(bool isWin, RosRoundPhrase roundPhrase)
        {
            foreach (var effect in effects.ToList())
            {
                effect.OnEndPreAtkTurn(new EffectContext { Owner = Player, PlayerSlot = this }, Player.Game, roundPhrase);
            }
        }

        public void OnStartPhyAtkTurn(bool isWin, RosRoundPhrase roundPhrase)
        {
            foreach (var effect in effects.ToList())
            {
                effect.OnStartPhyAtkTurn(new EffectContext { Owner = Player, PlayerSlot = this }, Player.Game, roundPhrase);
            }
        }

        public void OnPhyAtkTurn(bool isWin, RosRoundPhrase roundPhrase)
        {
            foreach (var effect in effects.ToList())
            {
                effect.OnPhyAtkTurn(new EffectContext { Owner = Player, PlayerSlot = this }, Player.Game, roundPhrase);
            }
        }

        public void OnEndPhyAtkTurn(bool isWin, RosRoundPhrase roundPhrase)
        {
            foreach (var effect in effects.ToList())
            {
                effect.OnEndPhyAtkTurn(new EffectContext { Owner = Player, PlayerSlot = this }, Player.Game, roundPhrase);
            }
        }

        public void OnStartMagicalAtkTurn(bool isWin, RosRoundPhrase roundPhrase)
        {
            foreach (var effect in effects.ToList())
            {
                effect.OnStartMagicalAtkTurn(new EffectContext { Owner = Player, PlayerSlot = this }, Player.Game, roundPhrase);
            }
        }

        public void OnMagicalTurn(bool isWin, RosRoundPhrase roundPhrase)
        {
            foreach (var effect in effects.ToList())
            {
                effect.OnMagicalTurn(new EffectContext { Owner = Player, PlayerSlot = this }, Player.Game, roundPhrase);
            }
        }

        public void OnEndMagicalAtkTurn(bool isWin, RosRoundPhrase roundPhrase)
        {
            foreach (var effect in effects.ToList())
            {
                effect.OnEndMagicalAtkTurn(new EffectContext { Owner = Player, PlayerSlot = this }, Player.Game, roundPhrase);
            }
        }

        public void OnEndRound(bool isWin, RosRoundPhrase roundPhrase)
        {
            foreach (var effect in effects.ToList())
            {
                effect.OnEndRound(new EffectContext { Owner = Player, PlayerSlot = this }, Player.Game, roundPhrase);
            }
        }

        public void OnPlayerGetDamage(SubHpAction subHpAction)
        {
            foreach (var effect in effects.ToList())
            {
                effect.OnPlayerGetDamage(new EffectContext { Owner = Player, PlayerSlot = this }, subHpAction, Player.Game);
            }
        }

        public void OnPlayerGetEffect(AddEffectToPlayerAction addEffectAction, bool isWin, RosRoundPhrase roundPhrase)
        {
            foreach (var effect in effects.ToList())
            {
                effect.OnPlayerGetEffect(new EffectContext { Owner = Player, PlayerSlot = this }, addEffectAction, Player.Game);
            }
        }

        public void OnStartGame(IRosGame game)
        {
            foreach (var effect in effects.ToList())
            {
                effect.OnStartGame(new EffectContext { Owner = Player, PlayerSlot = this }, game);
            }
        }

        public void AfterAllWin(IRosPlayer owner, bool isWin, RosRoundPhrase roundPhrase)
        {
            foreach (var effect in effects.ToList())
            {
                effect.AfterAllWin(new EffectContext { Owner = Player, PlayerSlot = this }, owner, Player.Game, roundPhrase);
            }
        }

        public void AfterOpponentAllWin(IRosPlayer owner, bool isWin, RosRoundPhrase roundPhrase)
        {
            foreach (var effect in effects.ToList())
            {
                effect.AfterOpponentAllWin(new EffectContext { Owner = Player, PlayerSlot = this }, owner, Player.Game, roundPhrase);
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
