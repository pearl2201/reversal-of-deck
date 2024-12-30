using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversalOfSpirit.Gameplay.Enums
{
    public enum GameTerritory
    {
        Vanguard,
        Center,
        Rearguard
    }

    public enum GameEffectSlot
    {
        Vanguard,
        Center,
        Rearguard,
        Player
    }

    public enum DamageType
    {
        PhysicalDamage,
        MagicalDamage,
        DrainDamage,
        CurseDamage,
        CounterAttackPhysicalDamage
    }

    public enum GameCardConditionKind
    {
        None,
        Lose,
        Win,
        Vanguard,
        Center,
        Rearguard,
        LoseWithScoreLessOrEqual,
        WinAsVanguard,
        WinWithEvenScore,
        LoseWithEventScore,
        WinWithOddScore,
        LoseWithOddScore,
        WinWithScoreGreaterOrEqual,
        WinWithAllDicesHasAtleastSameDice,
        CurrentDiceLessOrEqual,
        CurrentDiceGreaterOrEqual
    }

    public enum GameCardEffectTriggerTimeKind
    {
        Immediate,
        AfterRoundSlot,
        AfterRound
    }

    public enum GameCardEffectKind
    {
        AddFlatArmor,
        AddPercentArmor,
        AddFlatHealth,
        AddPercentHealth,

        ReduceOpponentFlatArmor,
        ReduceOpponentPercentArmor,
        ReduceOpponentFlatHealth,
        ReduceOpponentPercentHealth,

        PhysicalAttackDamage,
        MagicalAttackDamage,

        DealBonusDamageBaseSumAllDices,
        CounterAttackFlatDamage,
        CounterAttackPercentageDamage,

        IncreasePhysicalAttackPercentage,
        DecreaseOpponentCardPhysicalAttackPercentage,
        IncreasePhysicalAttackBaseOnArmorPercentage,

        GainSwapDiceChances,
        LockOpponentLowestAttackInBench,

        IncreaseMana,
        DecreaseOpponentMana,

    }

    public enum GameActionKind
    {
        IncreaseAmor,
        DecreaseOpponentArmor,
        PhysicalAttackDamage,
        MagicalAttackDamage
    }

    public enum GameDurationEffectTarget
    {
        All,
        TeamA,
        TeamB
    }

    public enum GameDurationKind
    {
        Permanent,
        Consume
    }


    public enum GameDurationStep
    {
        Turn,
        Round
    }

    public enum GameSkillEffectKind
    {
        BuffArmor,
        CutOpponentArmor
    }

    public enum RoundResult
    {
        PlayerAWin,
        PlayerBWin,
        Draw
    }

    public enum CardActionPhrase
    {
        HealAndBuffArmor,
        BuffAndDebuff,
        NormalAttack,
        MagicAttack,
        CounterAttack,
        PostAttack,
        TripleAttack
    }

    public enum PlayerTeam
    {
        TeamA,
        TeamB
    }

    public enum RosRoundPhrase
    {
        Prepare,
        Arguard,
        MidCenter,
        Rearguard
    }

    public enum RosTurnPhrase
    {
        StartRound,
        StartTurn,
        BeforeAttack,
        PhysicalAttack,
        MagicalAttack,
        CounterAttack,
        EndTurn,
        EndRound
    }

    public enum GameEffectRoleType
    {
        Position,
        Negative,
        Neutralize,
    }

    public enum RaiseAtkBase
    {
        Abs,
        MissingUpHp
    }
    public static class PlayerTeamExtensions
    {
        public static PlayerTeam GetOpponentPlayerTeam(this PlayerTeam team)
        {
            if (team == PlayerTeam.TeamA)
            {
                return PlayerTeam.TeamB;
            }
            return PlayerTeam.TeamA;
        }
    }

    public class Temp
    {
        public static Dictionary<GameCardEffectKind, CardActionPhrase> Effect2Phrases = new Dictionary<GameCardEffectKind, CardActionPhrase>()
        {
            {GameCardEffectKind.AddFlatArmor, CardActionPhrase.HealAndBuffArmor },
            {GameCardEffectKind.AddFlatHealth, CardActionPhrase.HealAndBuffArmor },
            {GameCardEffectKind.AddPercentArmor, CardActionPhrase.HealAndBuffArmor },
            {GameCardEffectKind.AddPercentHealth, CardActionPhrase.HealAndBuffArmor },
            {GameCardEffectKind.IncreasePhysicalAttackPercentage, CardActionPhrase.BuffAndDebuff }
        };
    }
}
