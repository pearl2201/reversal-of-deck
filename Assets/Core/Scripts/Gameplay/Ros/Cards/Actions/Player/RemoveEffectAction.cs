using LiteNetLib.Utils;
using ReversalOfSpirit.Gameplay.Ros.Cards.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ReversalOfSpirit.Gameplay.Ros.Cards.Actions
{
    public class RemoveEffectAction : GameAction
    {
        

        public GameEffect effect;

        public IRosPlayer target;

        public RemoveEffectAction() : base(1) { }

        public RemoveEffectAction(GameEffect effect, IRosPlayer target, RosPlayerSlot playerSlot, int turnOrder = 1) : base(playerSlot, turnOrder) 
        {
            this.effect = effect;
            this.target = target;
        }

        public override void Execute(IRosGame game)
        {
            base.Execute(game);
            target.OnRemoveEffectFromPlayerAction(this);
        }

        public override void Serialize(IRosGame game, NetDataWriter writer)
        {
            base.Serialize(game, writer);
            writer.Put(target.Id);
            writer.Put(effect.GetType().ToString());
        }

        public override void Deserialize(IRosGame game, NetDataReader reader)
        {
            base.Deserialize(game, reader);
            effect = GameEffect.DeserializeGameEffect(game, reader);
        }
    }
}
