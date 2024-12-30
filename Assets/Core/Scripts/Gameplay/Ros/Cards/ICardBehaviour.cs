using ReversalOfSpirit.Gameplay.Enums;

namespace ReversalOfSpirit.Gameplay.Ros.Cards
{
    public interface ICardRuntimeStat
    {
        int Level { get; }

        int BaseArmor { get; }

        int BaseHp { get; }

        int BaseAtk { get; }

        IRosPlayer Owner { get; }

        RosPlayerSlot Slot { get; }
    }
    public interface ICardBehaviour
    {
        void OnStartGame(ICardRuntimeStat runtimeStat, IRosGame game);

        void OnStartRound(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        void OnStartPreAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        void PreAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        void OnEndPreAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        void OnStartPhyAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        void OnPhyAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        void OnEndPhyAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        void OnStartMagicalAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        void OnMagicalTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        void OnEndMagicalAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        void OnEndRound(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        void OnPlayerGetDamage(int damage, DamageType damageType, ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        void OnPlayerGetEffect(GameEffect effect, ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);


        void AfterAllWin(IRosPlayer owner, IRosGame game, RosRoundPhrase roundPhrase);

        void AfterOpponentAllWin(IRosPlayer owner, IRosGame game, RosRoundPhrase roundPhrase);
    }
    


}
