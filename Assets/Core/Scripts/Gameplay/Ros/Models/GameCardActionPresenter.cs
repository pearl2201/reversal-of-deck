using ReversalOfSpirit.Gameplay.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class GameCardActionPresenter
{
    public GameCardEffectKind EffectKind { get; set; }

    public GameEffectSlot? EffectSrcSlot { get; set; }

    public int EffectValue { get; set; }

    public int PhysicalDamage { get; set; }

    public StatChange Armor { get; set; }

    public StatChange Hp { get; set; }

    public List<EffectChange> EffectChanges { get; set; }

    public int ExecutionCardId { get; set; }

    public int ExecutionCardOwnerId { get; set; }

}

public class StatChange
{

    public int DstPeerId { get; set; }
    public int Value { get; set; }

    public int Src { get; set; }

    public int ClaimDst { get; set; }
}

public class EffectChange
{
    public GameEffectSlot? EffectSrcSlot { get; set; }

    public int PeerId { get; set; }
}