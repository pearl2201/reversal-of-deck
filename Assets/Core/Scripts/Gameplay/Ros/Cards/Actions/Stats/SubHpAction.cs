using ReversalOfSpirit.Gameplay.Enums;

namespace ReversalOfSpirit.Gameplay.Ros.Cards.Actions
{
    public class SubHpAction : GameAction
    {
        public int value;
        public int lastValue;
        public int finalArmorValue;
        public int finalHpValue;

        public IRosPlayer target;


        public DamageType damageType;

        public SubHpAction() : base(1) { }

        public SubHpAction(int value, IRosPlayer target, RosPlayerSlot playerSlot, DamageType damageType = DamageType.PhysicalDamage, int turnOrder = 1) : base(playerSlot, turnOrder)
        {
            this.value = value;
            this.lastValue = value;
            this.target = target;
            this.damageType = damageType;
        }

        public override void Execute(IRosGame game)
        {
            base.Execute(game);
            target.OnSubHpAction(this);

        }

        ///*public override void Serialize(IRosGame game, NetDataWriter writer)
        //{
        //    base.Serialize(game, writer);
        //    writer.Put(target.Id);
        //    writer.Put(value);
        //    writer.Put(lastValue);
        //    writer.Put(finalArmorValue);
        //    writer.Put(finalHpValue);
        //    writer.Put((int)damageType);
        //}

        //public override void Deserialize(IRosGame game, NetDataReader reader)
        //{
        //    base.Deserialize(game, reader);
        //    target = game.GetPlayer(reader.GetInt());
        //    value = reader.GetInt();
        //    lastValue = reader.GetInt();
        //    finalArmorValue = reader.GetInt();
        //    finalHpValue = reader.GetInt();
        //    damageType = (DamageType)reader.GetInt();

        //}

        public override string ToString()
        {
            return $"player {target.Id}  receive {value} {damageType}, result is {finalArmorValue} armor, {finalHpValue} hp ";
        }
    }
}
