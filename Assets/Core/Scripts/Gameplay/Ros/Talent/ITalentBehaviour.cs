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
        void OnStartGame(ITalentRuntimeStat runtimeStat, IRosGame game);

        void OnStartRound(ITalentRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        void OnStartPreAtkTurn(ITalentRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        void PreAtkTurn(ITalentRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        void OnEndPreAtkTurn(ITalentRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        void OnStartPhyAtkTurn(ITalentRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        void OnPhyAtkTurn(ITalentRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        void OnEndPhyAtkTurn(ITalentRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        void OnStartMagicalAtkTurn(ITalentRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        void OnMagicalTurn(ITalentRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        void OnEndMagicalAtkTurn(ITalentRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        void OnEndRound(ITalentRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        void OnPlayerGetDamage(int damage, ITalentRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);

        void OnPlayerGetEffect(GameEffect effect, ITalentRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase);


        void AfterAllWin(IRosPlayer owner, IRosGame game, RosRoundPhrase roundPhrase);

        void AfterOpponentAllWin(IRosPlayer owner, IRosGame game, RosRoundPhrase roundPhrase);
    }
}
