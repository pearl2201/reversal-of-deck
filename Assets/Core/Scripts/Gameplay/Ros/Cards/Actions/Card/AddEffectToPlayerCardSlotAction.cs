
using ReversalOfSpirit.Gameplay.Ros.Cards.Effects;
using ReversalOfSpirit.Gameplay.Ros.Cards;
using ReversalOfSpirit.Gameplay.Ros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReversalOfSpirit.Gameplay.Enums;
using Cysharp.Threading.Tasks;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Actions
{
    public class AddEffectToPlayerCardSlotAction : GameAction
    {
        public int finalStack;

        public bool isSuccess;

        public GameEffect effect;

        public IRosPlayer target;

        public GameTerritory terriority;

        public AddEffectToPlayerCardSlotAction() : base(1) { }

        public AddEffectToPlayerCardSlotAction(GameEffect effect, IRosPlayer target, GameTerritory terriority, RosPlayerSlot playerSlot, int turnOrder = 1) : base(playerSlot, turnOrder)
        {
            this.effect = effect;
            this.target = target;
            this.terriority = terriority;
        }

        public override async UniTask Execute(IRosGame game)
        {
            await base.Execute(game);
            target.terrioritySlots[terriority].OnAddEffectToCardSlotAction(this);
        }

        /*public override void Serialize(IRosGame game, NetDataWriter writer)
        {
            base.Serialize(game, writer);
            writer.Put(target.Id);
            writer.Put((int)terriority);
            writer.Put(isSuccess);
            writer.Put(finalStack);
            writer.Put(effect.GetType().Name.ToString());

            effect.Serialize(game, writer);
        }

        public override void Deserialize(IRosGame game, NetDataReader reader)
        {
            base.Deserialize(game, reader);
            target = game.GetPlayer(reader.GetInt());
            terriority = (GameTerritory)(reader.GetInt());
            isSuccess = reader.GetBool();
            finalStack = reader.GetInt();
            effect = GameEffect.DeserializeGameEffect(game, reader);
        }

       */ public override string ToString()
        {
            return $"add effect {effect.GetType().Name} to player {target.Id}";
        }
    }
}
