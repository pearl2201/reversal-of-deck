using ReversalOfSpirit.Gameplay.Enums;
using ReversalOfSpirit.Gameplay.Ros.Cards;
using System.Collections.Generic;

namespace ReversalOfSpirit.Gameplay.Ros
{
    public class RosRuntimeCard : ICardRuntimeStat
    {
        public int Level { get; set; }
        public BaseCard CardDefinition { get; set; }

        public IRosPlayer Owner { get; set; }

        public int GetPhysicalAttack()
        {
            return CardDefinition.atk;
        }

        public int BaseArmor => CardDefinition.armor;

        public int BaseHp => CardDefinition.hp;

        public int BaseAtk => CardDefinition.atk;

        public List<GameEffect> Effects { get; set; }

        public RosPlayerSlot? Slot { get; set; }

        public int BaseStar { get; set; }

        public RosRuntimeCard()
        {
            Effects = new List<GameEffect>();
        }



        public void OnStartRound(IRosGame game, RosRoundPhrase roundPhrase)
        {
            CardDefinition.OnStartRound(this, game, roundPhrase);
        }

        public void OnStartPreAtkTurn(IRosGame game, RosRoundPhrase roundPhrase)
        {
            CardDefinition.OnStartPreAtkTurn(this, game, roundPhrase);
        }

        public void PreAtkTurn(IRosGame game, RosRoundPhrase roundPhrase)
        {
            CardDefinition.PreAtkTurn(this, game, roundPhrase);
        }

        public void OnEndPreAtkTurn(IRosGame game, RosRoundPhrase roundPhrase)
        {
            CardDefinition.OnEndPreAtkTurn(this, game, roundPhrase);
        }

        public void OnStartPhyAtkTurn(IRosGame game, RosRoundPhrase roundPhrase)
        {
            CardDefinition.OnStartPhyAtkTurn(this, game, roundPhrase);
        }

        public void OnPhyAtkTurn(IRosGame game, RosRoundPhrase roundPhrase)
        {
            CardDefinition.OnPhyAtkTurn(this, game, roundPhrase);
        }

        public void OnEndPhyAtkTurn(IRosGame game, RosRoundPhrase roundPhrase)
        {
            CardDefinition.OnEndPhyAtkTurn(this, game, roundPhrase);
        }

        public void OnStartMagicalAtkTurn(IRosGame game, RosRoundPhrase roundPhrase)
        {
            CardDefinition.OnStartMagicalAtkTurn(this, game, roundPhrase);
        }

        public void OnMagicalTurn(IRosGame game, RosRoundPhrase roundPhrase)
        {
            CardDefinition.OnMagicalTurn(this, game, roundPhrase);
        }

        public void OnEndMagicalAtkTurn(IRosGame game, RosRoundPhrase roundPhrase)
        {
            CardDefinition.OnEndMagicalAtkTurn(this, game, roundPhrase);
        }

        public void OnEndRound(IRosGame game, RosRoundPhrase roundPhrase)
        {
            CardDefinition.OnEndRound(this, game, roundPhrase);
        }

        public void OnPlayerGetDamage(int damage, DamageType damageType, IRosGame game, RosRoundPhrase roundPhrase)
        {
            CardDefinition.OnPlayerGetDamage(damage, damageType, this, game, roundPhrase);
        }

        public void OnPlayerGetEffect(GameEffect effect, IRosGame game, RosRoundPhrase roundPhrase)
        {
            CardDefinition.OnPlayerGetEffect(effect, this, game, roundPhrase);
        }

        public void OnStartGame(IRosGame game)
        {
            CardDefinition.OnStartGame(this, game);
        }

        public void AfterAllWin(IRosPlayer owner, IRosGame game, RosRoundPhrase roundPhrase)
        {
            CardDefinition.AfterAllWin(owner, game, roundPhrase);
        }

        public void AfterOpponentAllWin(IRosPlayer owner, IRosGame game, RosRoundPhrase roundPhrase)
        {
            CardDefinition.AfterOpponentAllWin(owner, game, roundPhrase);
        }


    }
}
