using Cysharp.Threading.Tasks;
using ReversalOfSpirit.Gameplay.Enums;
using ReversalOfSpirit.Gameplay.Ros.Cards;

namespace ReversalOfSpirit.Gameplay.Ros.Talent
{


    public interface ITalentRuntimeStat
    {
        IRosPlayer Owner { get; }
    }
    public interface ITalentBehaviour
    {
        UniTask OnStartGame(ITalentRuntimeStat runtimeStat, IRosGame game);

        UniTask OnStartRound(ITalentRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        UniTask OnStartPreAtkTurn(ITalentRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        UniTask PreAtkTurn(ITalentRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        UniTask OnEndPreAtkTurn(ITalentRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        UniTask OnStartPhyAtkTurn(ITalentRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        UniTask OnPhyAtkTurn(ITalentRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        UniTask OnEndPhyAtkTurn(ITalentRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        UniTask OnStartMagicalAtkTurn(ITalentRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        UniTask OnMagicalTurn(ITalentRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        UniTask OnEndMagicalAtkTurn(ITalentRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        UniTask OnEndRound(ITalentRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        UniTask OnPlayerGetDamage(int damage, ITalentRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        UniTask OnPlayerGetEffect(GameEffect effect, ITalentRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);


        UniTask AfterAllWin(IRosPlayer owner, IRosGame game, RosRoundPhrase roundPhrase);

        UniTask AfterOpponentAllWin(IRosPlayer owner, IRosGame game, RosRoundPhrase roundPhrase);
    }
}
