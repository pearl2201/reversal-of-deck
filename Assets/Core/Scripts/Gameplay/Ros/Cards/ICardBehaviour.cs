using Cysharp.Threading.Tasks;
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
        UniTask OnStartGame(ICardRuntimeStat runtimeStat, IRosGame game);

        UniTask OnStartRound(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        UniTask OnStartPreAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        UniTask PreAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        UniTask OnEndPreAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        UniTask OnStartPhyAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        UniTask OnPhyAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        UniTask OnEndPhyAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        UniTask OnStartMagicalAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        UniTask OnMagicalTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        UniTask OnEndMagicalAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        UniTask OnEndRound(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        UniTask OnPlayerGetDamage(int damage, DamageType damageType, ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        UniTask OnPlayerGetEffect(GameEffect effect, ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);


        UniTask AfterAllWin(IRosPlayer owner, IRosGame game, RosRoundPhrase roundPhrase);

        UniTask AfterOpponentAllWin(IRosPlayer owner, IRosGame game, RosRoundPhrase roundPhrase);
    }
    


}
