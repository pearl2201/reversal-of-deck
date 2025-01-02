
using Cysharp.Threading.Tasks;
using ReversalOfSpirit.Gameplay.Enums;
using ReversalOfSpirit.Gameplay.Packets;
using ReversalOfSpirit.Gameplay.Ros.Cards;
using ReversalOfSpirit.Gameplay.Ros.Cards.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ReversalOfSpirit.Gameplay.Ros
{
    public interface IRosPlayer
    {
        int Id { get; }
        bool finishRoundSelection { get; set; }

        bool finishRoundPresent { get; set; }

        Dictionary<GameTerritory, CardSlotSelection> cardSlots { get; set; }
        Dictionary<GameTerritory, RosPlayerSlot> terrioritySlots { get; set; }

        public RosRuntimeArcane arcane
        {
            get;
        }
        void SeedBoard();

        UniTask OnStartRound();

        void BroadcastBoard();
        int CurrentHp { get; set; }
        int CurrentArmor { get; set; }
        int CurrentMana { get; set; }
        int MaxStartGameHp { get; set; }
        int MaxStartGameArmor { get; set; }
        int MaxStartGameAtk { get; set; }

        int MaxStartGameMana { get; set; }

        RosRuntimeCard GetRuntimeCard(int cardId);

        UniTask OnStartPreAtkTurn(bool isWin, RosRoundPhrase roundPhrase);
        UniTask PreAtkTurn(bool isWin, RosRoundPhrase roundPhrase);
        UniTask OnEndPreAtkTurn(bool isWin, RosRoundPhrase roundPhrase);
        UniTask OnStartPhyAtkTurn(bool isWin, RosRoundPhrase roundPhrase);
        UniTask OnPhyAtkTurn(bool isWin, RosRoundPhrase roundPhrase);
        UniTask OnEndPhyAtkTurn(bool isWin, RosRoundPhrase roundPhrase);
        UniTask OnStartMagicalAtkTurn(bool isWin, RosRoundPhrase roundPhrase);
        UniTask OnMagicalTurn(bool isWin, RosRoundPhrase roundPhrase);
        UniTask OnEndMagicalAtkTurn(bool isWin, RosRoundPhrase roundPhrase);
        UniTask OnStartGame();


        void OnSelectCard(GameTerritory slot, int cardId);

        IRosGame Game { get; }




        List<HandItem> handItems { get; set; }
        GameEffect GetGameEffect<T>() where T : GameEffect;


        UniTask OnSubHpAction(SubHpAction act);
        UniTask OnRestoreHpStatAction(RestoreHpAction act);

        UniTask OnGainShieldAction(GainShieldAction act);

        UniTask OnSubShieldAction(SubShieldAction act);
        UniTask OnReduceManaStatAction(ReduceManaStatAction act);

        UniTask OnGainManaStatAction(GainManaStatAction act);

        UniTask OnSubtractCardSwapChanceAction(SubtractCardSwapChanceAction act);

        UniTask OnGainCardSwapChanceAction(GainCardSwapChanceAction act);
        UniTask OnAddEffectToPlayerAction(AddEffectToPlayerAction effactect);
        UniTask OnRemoveEffectFromPlayerAction(RemoveEffectAction act);

        int GetMissingUpHp();

        PlayerShortInfo ShortInfo { get; }
    }
    //}
    //[System.Serializable]
    //public abstract class RosPlayer : IRosPlayer
    //{
    //    protected RosGame game;
    //    public IRosGame Game => game;
    //    public System.Random rng;
    //    public int CurrentHp { get; set; }
    //    public int CurrentArmor { get; set; }
    //    public int CurrentMana { get; set; }
    //    public int MaxStartGameHp { get; set; }
    //    public int MaxStartGameArmor { get; set; }
    //    public int MaxStartGameAtk { get; set; }

    //    public int MaxStartGameMana { get; set; }
    //    public float bonusGameHpPercent;
    //    public float bonusGameArmorPercent;
    //    public float bonusTurnAtkPercent;

    //    public int diceCount;
    //    public bool finishRoundSelection { get; set; }

    //    public bool finishRoundPresent
    //    {
    //        get; set;
    //    }


    //    public List<RosRuntimeCard> runtimeCards;
    //    public List<RosRuntimeTalent> talents;
    //    public List<GameEffect> effects;
    //    public RosRuntimeArcane arcane { get; set; }

    //    public List<HandItem> handItems { get; set; }
    //    public Dictionary<GameTerritory, CardSlotSelection> cardSlots { get; set; }
    //    public Dictionary<GameTerritory, RosPlayerSlot> terrioritySlots { get; set; }

    //    public PlayerShortInfo ShortInfo { get; set; }
    //    public RosPlayer(RosGame game)
    //    {
    //        this.game = game;
    //        handItems = new List<HandItem>();
    //        rng = new System.Random();
    //        cardSlots = new Dictionary<GameTerritory, CardSlotSelection>();
    //        effects = new List<GameEffect>();
    //        var arguardSlot = new RosPlayerSlot(this, GameTerritory.Vanguard);
    //        var midcenterSlot = new RosPlayerSlot(this, GameTerritory.Center);
    //        var rearguardSlot = new RosPlayerSlot(this, GameTerritory.Rearguard);
    //        terrioritySlots = new Dictionary<GameTerritory, RosPlayerSlot> { { GameTerritory.Vanguard, arguardSlot }, { GameTerritory.Center, midcenterSlot }, { GameTerritory.Rearguard, rearguardSlot } };
    //        runtimeCards = new List<RosRuntimeCard>();
    //        talents = new List<RosRuntimeTalent>();
    //        finishRoundPresent = false;
    //    }

    //    public int CurrentMaxHp => (int)(MaxStartGameHp * (1 + bonusGameHpPercent));
    //    public int CurrentMaxArmor => (int)(MaxStartGameArmor * (1 + bonusGameArmorPercent));
    //    public void SetupProfile(PlayerProfile profile)
    //    {
    //        ShortInfo = new PlayerShortInfo
    //        {
    //            elo = profile.elo,
    //            name = profile.name,
    //            id = Id,
    //            rankId = profile.rankId,
    //            playerId = profile.id
    //        };
    //        foreach (var card in profile.playerCardData)
    //        {
    //            runtimeCards.Add(new RosRuntimeCard
    //            {
    //                CardDefinition = game.RosConfig.CardDefinitions.FirstOrDefault(x => x.id == card.cardId),
    //                Level = card.level,
    //                Owner = this
    //            });
    //        }
    //        foreach (var talentData in profile.talents)
    //        {
    //            talents.Add(new RosRuntimeTalent
    //            {
    //                Talent = game.RosConfig.Talents.FirstOrDefault(x => x.id == talentData.talentId),
    //                Level = talentData.level,
    //                Owner = this
    //            });
    //        }

    //        arcane = new RosRuntimeArcane
    //        {
    //            Arcane = game.RosConfig.Arcanes.FirstOrDefault(x => x.id == profile.arcane.arcaneId),
    //            Level = profile.arcane.level,
    //            Owner = this
    //        };

    //        MaxStartGameAtk = runtimeCards.Sum(x => x.BaseAtk) + (int)(1 * talents.Select(x => x.Talent.GetAdditionAtk()).Sum());
    //        MaxStartGameHp = runtimeCards.Sum(x => x.BaseHp) + (int)(1 * talents.Select(x => x.Talent.GetAdditionHp()).Sum());
    //        MaxStartGameArmor = runtimeCards.Sum(x => x.BaseArmor) + (int)(1 * talents.Select(x => x.Talent.GetAdditionArmor()).Sum());
    //        MaxStartGameMana = arcane.Arcane.cost;
    //        diceCount = 0;
    //        CurrentHp = MaxStartGameHp;
    //        CurrentArmor = 0;
    //        CurrentMana = 0;
    //    }

    //    //public void Send<T>(T packet) where T : INetSerializable
    //    //{
    //    //    Send(typeof(T).Name, packet);
    //    //}

    //    //public abstract void Send(string packetId, Action<NetDataWriter> writerFunc);

    //    //public void Broadcast<T>(T packet) where T : INetSerializable
    //    //{
    //    //    Send(typeof(T).Name, packet);
    //    //}


    //    //public abstract void Send<T>(string packetId, T packet) where T : INetSerializable;

    //    //public abstract void Broadcast<T>(string packetId, T packet) where T : INetSerializable;

    //    public RosRuntimeCard GetRuntimeCard(int cardId)
    //    {
    //        return runtimeCards.FirstOrDefault(x => x.CardDefinition.id == cardId);
    //    }

    //    public void OnStartGame()
    //    {
    //        foreach (var talent in talents)
    //        {
    //            talent.Talent.OnStartGame(talent, game);
    //        }
    //    }

    //    public async UniTask OnStartRound()
    //    {
    //        foreach (var slot in terrioritySlots)
    //        {
    //            slot.Value.OnStartRound();
    //        }
    //        foreach (var talent in talents)
    //        {
    //            talent.Talent.OnStartRound(talent, game, RosRoundPhrase.Prepare);
    //        }
    //        foreach (var effect in effects)
    //        {
    //            effect.OnStartRound(new EffectContext { Owner = this }, game, RosRoundPhrase.Prepare);
    //        }
    //        foreach (var terriotirySlot in terrioritySlots)
    //        {
    //            terriotirySlot.Value.OnStartRound();
    //        }
    //        game.NotifySequential(new List<GameAction> { new GainManaStatAction(20, this, terrioritySlots[GameTerritory.Vanguard], 1) });

    //    }

    //    public abstract int Id { get; }

    //    public virtual void SeedBoard()
    //    {


    //        for (int x = 0; x < 8; x++)
    //        {
    //            for (int y = 0; y < 6; y++)
    //            {
    //                handItems.Add(new HandItem()
    //                {
    //                    x = x,
    //                    y = y,
    //                    id = runtimeCards[rng.Next(0, runtimeCards.Count)].CardDefinition.id
    //                });
    //            }
    //        }

    //        cardSlots.Clear();
    //    }

    //    public void BroadcastBoard()
    //    {
    //        S2C_SeedBoardPacket packet = new S2C_SeedBoardPacket()
    //        {
    //            handItems = handItems
    //        };
    //        //Send(packet);
    //    }

    //    public void OnSelectCard(GameTerritory slot, int cardId)
    //    {
    //        Debug.Log($"Player {Id} select {cardId} for slot {slot.ToString()}");
    //        S2C_SelectCardSuccess packet = new S2C_SelectCardSuccess()
    //        {
    //            slot = slot,
    //            cardId = cardId,
    //            handItems = new List<HandItem>()
    //        };

    //        int star = 0;
    //        for (int x = 0; x < handItems.Count; x++)
    //        {
    //            var handItem = handItems[x];
    //            if (handItem.id == cardId)
    //            {
    //                handItem.id = runtimeCards[rng.Next(0, runtimeCards.Count)].CardDefinition.id;
    //                packet.handItems.Add(handItem);
    //                star++;
    //            }
    //        }
    //        cardSlots[slot] = new CardSlotSelection() { CardId = cardId, Star = star };
    //        //Send(packet);
    //    }

    //    public void OnUseSkill(C2S_PlayerUseSkill useSkill)
    //    {

    //    }


    //    public void OnGainManaStatAction(GainManaStatAction mana)
    //    {
            
    //        CurrentMana = Clamp(CurrentMana + mana.value, 0, arcane.Arcane.cost);
    //        mana.finalValue = CurrentMana;
    //        Debug.Log($"Player {Id} gain {mana.value}: {mana.finalValue}");
    //    }



    //    public void ReduceMaxArmor(float percent)
    //    {
    //        bonusGameArmorPercent = Clamp(bonusGameArmorPercent - percent, 0, int.MaxValue);
    //    }

    //    public void ReduceMaxHp(float percent)
    //    {
    //        bonusGameHpPercent = Clamp(bonusGameHpPercent - percent, 0, int.MaxValue);
    //    }

    //    public void IncreaseMaxArmor(float percent)
    //    {
    //        bonusGameArmorPercent = Clamp(bonusGameArmorPercent + percent, 0, int.MaxValue);
    //    }

    //    public void IncreaseMaxHp(float percent)
    //    {
    //        bonusGameArmorPercent = Clamp(bonusGameArmorPercent + percent, 0, int.MaxValue);
    //    }



    //    public void SilentTurnPhrase(int count)
    //    {

    //    }


    //    public void RemoveGameEffect<T>() where T : GameEffect
    //    {
    //        effects.RemoveAll(x => x.GetType() == typeof(T));
    //    }

    //    public void OnRemoveEffectFromPlayerAction(GameEffect effect)
    //    {
    //        effects.Remove(effect);
    //    }

    //    public GameEffect GetGameEffect<T>() where T : GameEffect
    //    {
    //        return effects.FirstOrDefault(x => x.GetType() == typeof(T));
    //    }


    //    public int GetMissingUpHp()
    //    {
    //        return CurrentMaxHp - CurrentHp;
    //    }

    //    public int Clamp(int value, int minValue, int maxValue)
    //    {
    //        if (value > maxValue)
    //        {
    //            value = maxValue;
    //        }
    //        if (value < minValue)
    //        {
    //            value = minValue;
    //        }
    //        return value;
    //    }

    //    public float Clamp(float value, float minValue, float maxValue)
    //    {
    //        if (value > maxValue)
    //        {
    //            value = maxValue;
    //        }
    //        if (value < minValue)
    //        {
    //            value = minValue;
    //        }
    //        return value;
    //    }

    //    public async UniTask OnStartRound(bool isWin, RosRoundPhrase roundPhrase)
    //    {
    //        foreach (var effect in effects.ToList())
    //        {
    //            effect.OnStartRound(new EffectContext { Owner = this, PlayerSlot = terrioritySlots[(GameTerritory)((int)roundPhrase - 1)] }, game, roundPhrase);
    //        }
    //        foreach (var effect in terrioritySlots.ToList())
    //        {
    //            effect.Value.OnStartRound();
    //        }
    //        RemoveFinishedEffect();
    //    }

    //    public void OnStartPreAtkTurn(bool isWin, RosRoundPhrase roundPhrase)
    //    {
    //        foreach (var effect in effects.ToList())
    //        {
    //            effect.OnStartPreAtkTurn(new EffectContext { Owner = this, PlayerSlot = terrioritySlots[(GameTerritory)((int)roundPhrase - 1)] }, game, roundPhrase);
    //        }
    //        foreach (var effect in terrioritySlots.ToList())
    //        {
    //            effect.Value.OnStartPreAtkTurn(isWin, roundPhrase);
    //        }
    //        RemoveFinishedEffect();
    //    }

    //    public void PreAtkTurn(bool isWin, RosRoundPhrase roundPhrase)
    //    {
    //        foreach (var effect in effects.ToList())
    //        {
    //            effect.PreAtkTurn(new EffectContext { Owner = this, PlayerSlot = terrioritySlots[(GameTerritory)((int)roundPhrase - 1)] }, game, roundPhrase);
    //        }
    //        foreach (var effect in terrioritySlots.ToList())
    //        {
    //            effect.Value.PreAtkTurn(isWin, roundPhrase);
    //        }
    //        RemoveFinishedEffect();
    //    }

    //    public void OnEndPreAtkTurn(bool isWin, RosRoundPhrase roundPhrase)
    //    {
    //        foreach (var effect in effects.ToList())
    //        {
    //            effect.OnEndPreAtkTurn(new EffectContext { Owner = this, PlayerSlot = terrioritySlots[(GameTerritory)((int)roundPhrase - 1)] }, game, roundPhrase);
    //        }
    //        foreach (var effect in terrioritySlots.ToList())
    //        {
    //            effect.Value.OnEndPreAtkTurn(isWin, roundPhrase);
    //        }
    //        RemoveFinishedEffect();
    //    }

    //    public void OnStartPhyAtkTurn(bool isWin, RosRoundPhrase roundPhrase)
    //    {
    //        foreach (var effect in effects.ToList())
    //        {
    //            effect.OnStartPhyAtkTurn(new EffectContext { Owner = this, PlayerSlot = terrioritySlots[(GameTerritory)((int)roundPhrase - 1)] }, game, roundPhrase);
    //        }
    //        foreach (var effect in terrioritySlots.ToList())
    //        {
    //            effect.Value.OnStartPhyAtkTurn(isWin, roundPhrase);
    //        }
    //        RemoveFinishedEffect();
    //    }

    //    public void OnPhyAtkTurn(bool isWin, RosRoundPhrase roundPhrase)
    //    {
    //        foreach (var effect in effects.ToList())
    //        {
    //            effect.OnPhyAtkTurn(new EffectContext { Owner = this, PlayerSlot = terrioritySlots[(GameTerritory)((int)roundPhrase - 1)] }, game, roundPhrase);
    //        }
    //        foreach (var effect in terrioritySlots.ToList())
    //        {
    //            effect.Value.OnPhyAtkTurn(isWin, roundPhrase);
    //        }
    //        RemoveFinishedEffect();
    //    }

    //    public void OnEndPhyAtkTurn(bool isWin, RosRoundPhrase roundPhrase)
    //    {
    //        foreach (var effect in effects.ToList())
    //        {
    //            effect.OnEndPhyAtkTurn(new EffectContext { Owner = this, PlayerSlot = terrioritySlots[(GameTerritory)((int)roundPhrase - 1)] }, game, roundPhrase);
    //        }
    //        foreach (var effect in terrioritySlots.ToList())
    //        {
    //            effect.Value.OnEndPhyAtkTurn(isWin, roundPhrase);
    //        }
    //        RemoveFinishedEffect();
    //    }

    //    public void OnStartMagicalAtkTurn(bool isWin, RosRoundPhrase roundPhrase)
    //    {
    //        foreach (var effect in effects.ToList())
    //        {
    //            effect.OnStartMagicalAtkTurn(new EffectContext { Owner = this, PlayerSlot = terrioritySlots[(GameTerritory)((int)roundPhrase - 1)] }, game, roundPhrase);
    //        }
    //        foreach (var effect in terrioritySlots.ToList())
    //        {
    //            effect.Value.OnStartMagicalAtkTurn(isWin, roundPhrase);
    //        }
    //        RemoveFinishedEffect();
    //    }

    //    public void OnMagicalTurn(bool isWin, RosRoundPhrase roundPhrase)
    //    {
    //        foreach (var effect in effects.ToList())
    //        {
    //            effect.OnMagicalTurn(new EffectContext { Owner = this, PlayerSlot = terrioritySlots[(GameTerritory)((int)roundPhrase - 1)] }, game, roundPhrase);
    //        }
    //        foreach (var effect in terrioritySlots.ToList())
    //        {
    //            effect.Value.OnMagicalTurn(isWin, roundPhrase);
    //        }
    //        RemoveFinishedEffect();
    //    }

    //    public void OnEndMagicalAtkTurn(bool isWin, RosRoundPhrase roundPhrase)
    //    {
    //        foreach (var effect in effects.ToList())
    //        {
    //            effect.OnEndMagicalAtkTurn(new EffectContext { Owner = this, PlayerSlot = terrioritySlots[(GameTerritory)((int)roundPhrase - 1)] }, game, roundPhrase);
    //        }
    //        foreach (var effect in terrioritySlots.ToList())
    //        {
    //            effect.Value.OnEndMagicalAtkTurn(isWin, roundPhrase);
    //        }
    //        RemoveFinishedEffect();
    //    }

    //    public void OnEndRound(bool isWin, RosRoundPhrase roundPhrase)
    //    {
    //        foreach (var effect in effects.ToList())
    //        {
    //            effect.OnEndRound(new EffectContext { Owner = this, PlayerSlot = terrioritySlots[(GameTerritory)((int)roundPhrase - 1)] }, game, roundPhrase);
    //        }
    //        foreach (var effect in terrioritySlots.ToList())
    //        {
    //            effect.Value.OnEndRound(isWin, roundPhrase);
    //        }
    //        RemoveFinishedEffect();
    //    }


    //    public void OnPlayerGetEffect(AddEffectToPlayerAction addEffect, bool isWin, RosRoundPhrase roundPhrase)
    //    {
    //        foreach (var effect in effects.ToList())
    //        {
    //            effect.OnPlayerGetEffect(new EffectContext { Owner = this, PlayerSlot = terrioritySlots[(GameTerritory)((int)roundPhrase - 1)] }, addEffect, game);
    //        }
    //        foreach (var effect in terrioritySlots.ToList())
    //        {
    //            effect.Value.OnPlayerGetEffect(addEffect, isWin, roundPhrase);
    //        }
    //        RemoveFinishedEffect();
    //    }

    //    public void OnStartGame(IRosGame game)
    //    {
    //        foreach (var effect in effects.ToList())
    //        {
    //            effect.OnStartGame(new EffectContext { Owner = this }, game);
    //        }
    //        foreach (var effect in terrioritySlots.ToList())
    //        {
    //            effect.Value.OnStartGame(game);
    //        }
    //        RemoveFinishedEffect();
    //    }

    //    public void AfterAllWin(IRosPlayer owner, bool isWin, RosRoundPhrase roundPhrase)
    //    {
    //        foreach (var effect in effects.ToList())
    //        {
    //            effect.AfterAllWin(new EffectContext { Owner = this, PlayerSlot = terrioritySlots[(GameTerritory)((int)roundPhrase - 1)] }, owner, game, roundPhrase);
    //        }
    //        foreach (var effect in terrioritySlots.ToList())
    //        {
    //            effect.Value.AfterAllWin(owner, isWin, roundPhrase);
    //        }
    //        RemoveFinishedEffect();
    //    }

    //    public void AfterOpponentAllWin(IRosPlayer owner, bool isWin, RosRoundPhrase roundPhrase)
    //    {
    //        foreach (var effect in effects.ToList())
    //        {
    //            effect.AfterOpponentAllWin(new EffectContext { Owner = this, PlayerSlot = terrioritySlots[(GameTerritory)((int)roundPhrase - 1)] }, owner, game, roundPhrase);
    //        }
    //        foreach (var effect in terrioritySlots.ToList())
    //        {
    //            effect.Value.AfterOpponentAllWin(owner, isWin, roundPhrase);
    //        }
    //        RemoveFinishedEffect();
    //    }

    //    public void RemoveFinishedEffect()
    //    {
    //        effects = effects.Where(x => !x.IsDone()).ToList();

    //    }

    //    public void OnSubHpAction(SubHpAction act)
    //    {
    //        foreach (var effect in effects.ToList())
    //        {
    //            effect.OnPlayerGetDamage(new EffectContext { Owner = this, PlayerSlot = act.Slot }, act, game);
    //        }
    //        foreach (var effect in terrioritySlots.ToList())
    //        {
    //            effect.Value.OnPlayerGetDamage(act);
    //        }
    //        RemoveFinishedEffect();

    //        Debug.Log($"Player {Id} take {act.value} {act.damageType.ToString()} damage");
    //        if (act.damageType == DamageType.PhysicalDamage || act.damageType == DamageType.CounterAttackPhysicalDamage)
    //        {
    //            if (CurrentArmor > act.lastValue)
    //            {
    //                CurrentArmor = CurrentArmor - act.lastValue;
    //                act.finalHpValue = CurrentHp;
    //                act.finalArmorValue = CurrentArmor;
    //            }
    //            else
    //            {
    //                CurrentArmor = 0;
    //                act.finalArmorValue = 0;
    //                CurrentHp = Clamp(CurrentHp - act.lastValue, 0, CurrentMaxHp);
    //                act.finalHpValue = CurrentHp;
    //            }
    //        }
    //        else
    //        {
    //            CurrentHp = Clamp(CurrentHp - act.lastValue, 0, CurrentMaxHp);
    //            act.finalHpValue = CurrentHp;
    //            act.finalArmorValue = CurrentArmor;
    //        }

    //    }

    //    public void OnRestoreHpStatAction(RestoreHpAction act)
    //    {
    //        Debug.Log($"Player {Id} restore {act.value} hp");
    //        CurrentHp = Clamp(CurrentHp + act.value, 0, CurrentMaxHp);
    //        act.finalValue = CurrentHp;
    //    }

    //    public void OnGainShieldAction(GainShieldAction act)
    //    {
    //        Debug.Log($"Player {Id} restore {act.value} shield");
    //        CurrentArmor = Clamp(CurrentArmor + act.value, 0, CurrentMaxArmor);
    //        act.finalValue = CurrentArmor;
    //    }

    //    public void OnSubShieldAction(SubShieldAction act)
    //    {
    //        CurrentArmor = Clamp(CurrentArmor - act.value, 0, CurrentMaxArmor);

    //        act.finalValue = CurrentArmor;
    //    }

    //    public void OnReduceManaStatAction(ReduceManaStatAction act)
    //    {
    //        CurrentMana = Clamp(CurrentMana - act.value, 0, arcane.Arcane.cost);
    //        act.finalValue = CurrentMana;
    //    }

    //    public void OnSubtractCardSwapChanceAction(SubtractCardSwapChanceAction act)
    //    {
    //        diceCount = Clamp(diceCount - act.value, 0, int.MaxValue);
    //        act.finalValue = diceCount;
    //    }

    //    public void OnGainCardSwapChanceAction(GainCardSwapChanceAction act)
    //    {

    //        diceCount += act.value;
    //        act.finalValue = diceCount;
    //    }

    //    public void OnAddEffectToPlayerAction(AddEffectToPlayerAction act)
    //    {
    //        effects.Add(act.effect);
    //        act.isSuccess = true;
    //        act.finalStack = act.effect.Stack;
    //    }

    //    public void OnRemoveEffectFromPlayerAction(RemoveEffectAction act)
    //    {
    //        effects.Add(act.effect);
    //    }
    //}


}

    public class CardSlotSelection
    {
        public int CardId { get; set; }

        public int Star { get; set; }
    }