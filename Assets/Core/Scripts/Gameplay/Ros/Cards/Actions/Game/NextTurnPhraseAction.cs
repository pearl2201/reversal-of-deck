
using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Actions.Game
{
    public class NextTurnPhraseAction : GameAction
    {
        public int winnerId;


        public NextTurnPhraseAction() : base(1) { }

        public NextTurnPhraseAction(int winnerId, RosPlayerSlot playerSlot, int turnOrder = 1) : base(playerSlot, turnOrder)
        {
            this.winnerId = winnerId;
        }

        public override async UniTask Execute(IRosGame game)
        {
            await base.Execute(game);
   

        }


        /*public override void Serialize(IRosGame game, NetDataWriter writer)
        {
            base.Serialize(game, writer);
     
        }

        public override void Deserialize(IRosGame game, NetDataReader reader)
        {
            base.Deserialize(game, reader);
      
        }

       */ public override string ToString()
        {
            return $"Notify game result: {winnerId}";
        }

    }
}
