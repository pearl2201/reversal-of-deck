using ReversalOfSpirit.Gameplay.Enums;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Components
{
    public class RemoveAllBuffFromOpponentBench : BaseCardComponent
    {
     


        public RemoveAllBuffFromOpponentBench()
        {
            shortDescription = "Remove Buff";
        }

        public override void PreAtkTurn(ICardRuntimeStat runtimeStat, IRosGame game, RosRoundPhrase roundPhrase)
        {
            base.PreAtkTurn(runtimeStat, game, roundPhrase);
            //game.ExecuteSequential(new List<GameAction> { new RestoreHpAction(Hp, runtimeStat.Owner) });
        }
    }
}
