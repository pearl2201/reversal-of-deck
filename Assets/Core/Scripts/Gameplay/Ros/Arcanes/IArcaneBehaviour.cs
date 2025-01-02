using ReversalOfSpirit.Gameplay.Enums;
using ReversalOfSpirit.Gameplay.Ros.Cards;

namespace ReversalOfSpirit.Gameplay.Ros.Arcanes
{
    public interface IArcaneRuntimeStat
    {
        public IRosPlayer Owner { get; }
    }

    public class ArcaneRuntimeStat : IArcaneRuntimeStat
    {
        public IRosPlayer Owner { get; set; }
    }

    public interface IArcaneBehaviour
    {
        void OnStartGame(IArcaneRuntimeStat runtimeStat, IRosGame game);

        async UniTask OnStartRound(IArcaneRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        void OnStartPreAtkTurn(IArcaneRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        void PreAtkTurn(IArcaneRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        void OnEndPreAtkTurn(IArcaneRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        void OnStartPhyAtkTurn(IArcaneRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        void OnPhyAtkTurn(IArcaneRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        void OnEndPhyAtkTurn(IArcaneRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        void OnStartMagicalAtkTurn(IArcaneRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        void OnMagicalTurn(IArcaneRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        void OnEndMagicalAtkTurn(IArcaneRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        void OnEndRound(IArcaneRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        void OnPlayerGetDamage(int damage, IArcaneRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        void OnPlayerGetEffect(GameEffect effect, IArcaneRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);


        void AfterAllWin(IRosPlayer owner, IRosGame game, RosRoundPhrase roundPhrase);

        void AfterOpponentAllWin(IRosPlayer owner, IRosGame game, RosRoundPhrase roundPhrase);
    }
}
