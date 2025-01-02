using Cysharp.Threading.Tasks;
using Mirror;
using ReversalOfSpirit.Gameplay.Enums;
using ReversalOfSpirit.Gameplay.Packets;
using ReversalOfSpirit.Gameplay.Ros;
using ReversalOfSpirit.Gameplay.Ros.Cards;
using ReversalOfSpirit.Gameplay.Ros.Cards.Actions;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Ros
{
    public class BasePlayer : NetworkBehaviour, IRosPlayer
    {

        [SyncVar]
        public string playerName;
        [SyncVar]
        public int currentHp;
        [SyncVar]
        public int currentArmor;
        [SyncVar]
        public int currentMana;
        [SyncVar]
        public int maxStartGameHp;
        [SyncVar]
        public int maxStartGameArmor;
        [SyncVar]
        public int maxStartGameAtk;
        [SyncVar]
        public int maxStartGameMana;

        public float bonusGameHpPercent;
        public float bonusGameArmorPercent;
        public float bonusTurnAtkPercent;

        public int diceCount;

        public int CurrentMaxHp => (int)(MaxStartGameHp * (1 + bonusGameHpPercent));
        public int CurrentMaxArmor => (int)(MaxStartGameArmor * (1 + bonusGameArmorPercent));

        IRosGame game;
        public override void OnStartServer()
        {
            playerName = (string)connectionToClient.authenticationData;
        }


        public override void OnStartClient()
        {
            base.OnStartClient();
        }
        public override void OnStartLocalPlayer()
        {
            // assign data
        }

        public int Id => throw new System.NotImplementedException();

        public bool finishRoundSelection { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public bool finishRoundPresent { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public Dictionary<GameTerritory, CardSlotSelection> cardSlots { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public Dictionary<GameTerritory, RosPlayerSlot> terrioritySlots { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public RosRuntimeArcane arcane { get; set; }


        public List<RosRuntimeCard> runtimeCards;
        public List<RosRuntimeTalent> talents;
        public List<GameEffect> effects;
        public IRosGame Game => throw new System.NotImplementedException();

        public List<HandItem> handItems { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }


        public void SeedBoard()
        {
            throw new System.NotImplementedException();
        }

        public void OnStartGame()
        {
            foreach (var talent in talents)
            {
                talent.Talent.OnStartGame(talent, game);
            }
        }

        public async UniTask OnStartRound()
        {
            foreach (var slot in terrioritySlots)
            {
               await slot.Value.OnStartRound();
            }
            foreach (var talent in talents)
            {
                talent.Talent.OnStartRound(talent, game, RosRoundPhrase.Prepare);
            }
            foreach (var effect in effects)
            {
                await effect.OnStartRound(new EffectContext { Owner = this }, game, RosRoundPhrase.Prepare);
            }
            foreach (var terriotirySlot in terrioritySlots)
            {
                await terriotirySlot.Value.OnStartRound();
            }
            game.NotifySequential(new List<GameAction> { new GainManaStatAction(20, this, terrioritySlots[GameTerritory.Vanguard], 1) });

        }

        [TargetRpc]
        public void SelectCardSuccess()
        {

        }


        public void OnSelectCard(GameTerritory slot, int cardId)
        {
            Debug.Log($"Player {Id} select {cardId} for slot {slot.ToString()}");
            S2C_SelectCardSuccess packet = new S2C_SelectCardSuccess()
            {
                slot = slot,
                cardId = cardId,
                handItems = new List<HandItem>()
            };

            int star = 0;
            for (int x = 0; x < handItems.Count; x++)
            {
                var handItem = handItems[x];
                if (handItem.id == cardId)
                {
                    handItem.id = runtimeCards[UnityEngine.Random.Range(0, runtimeCards.Count)].CardDefinition.id;
                    packet.handItems.Add(handItem);
                    star++;
                }
            }
            cardSlots[slot] = new CardSlotSelection() { CardId = cardId, Star = star };
            //Send(packet);
        }
        public void BroadcastBoard()
        {
            throw new System.NotImplementedException();
        }

 
    

        public RosRuntimeCard GetRuntimeCard(int cardId)
        {
            throw new System.NotImplementedException();
        }


        public UniTask OnGainManaStatAction(GainManaStatAction mana)
        {

            CurrentMana = Clamp(CurrentMana + mana.value, 0, arcane.Arcane.cost);
            mana.finalValue = CurrentMana;
            Debug.Log($"Player {Id} gain {mana.value}: {mana.finalValue}");
            return UniTask.CompletedTask;
        }



        public void ReduceMaxArmor(float percent)
        {
            bonusGameArmorPercent = Clamp(bonusGameArmorPercent - percent, 0, int.MaxValue);
        }

        public void ReduceMaxHp(float percent)
        {
            bonusGameHpPercent = Clamp(bonusGameHpPercent - percent, 0, int.MaxValue);
        }

        public void IncreaseMaxArmor(float percent)
        {
            bonusGameArmorPercent = Clamp(bonusGameArmorPercent + percent, 0, int.MaxValue);
        }

        public void IncreaseMaxHp(float percent)
        {
            bonusGameArmorPercent = Clamp(bonusGameArmorPercent + percent, 0, int.MaxValue);
        }



        public void SilentTurnPhrase(int count)
        {

        }


        public void RemoveGameEffect<T>() where T : GameEffect
        {
            effects.RemoveAll(x => x.GetType() == typeof(T));
        }

        public void OnRemoveEffectFromPlayerAction(GameEffect effect)
        {
            effects.Remove(effect);
        }

        public GameEffect GetGameEffect<T>() where T : GameEffect
        {
            return effects.FirstOrDefault(x => x.GetType() == typeof(T));
        }


        public int GetMissingUpHp()
        {
            return CurrentMaxHp - CurrentHp;
        }

        public int Clamp(int value, int minValue, int maxValue)
        {
            if (value > maxValue)
            {
                value = maxValue;
            }
            if (value < minValue)
            {
                value = minValue;
            }
            return value;
        }

        public float Clamp(float value, float minValue, float maxValue)
        {
            if (value > maxValue)
            {
                value = maxValue;
            }
            if (value < minValue)
            {
                value = minValue;
            }
            return value;
        }

        public async UniTask OnStartRound(bool isWin, RosRoundPhrase roundPhrase)
        {
            foreach (var effect in effects.ToList())
            {
                await effect.OnStartRound(new EffectContext { Owner = this, PlayerSlot = terrioritySlots[(GameTerritory)((int)roundPhrase - 1)] }, game, roundPhrase);
            }
            foreach (var effect in terrioritySlots.ToList())
            {
                await effect.Value.OnStartRound();
            }
            RemoveFinishedEffect();
        }

        public async UniTask OnStartPreAtkTurn(bool isWin, RosRoundPhrase roundPhrase)
        {
            foreach (var effect in effects.ToList())
            {
                await effect.OnStartPreAtkTurn(new EffectContext { Owner = this, PlayerSlot = terrioritySlots[(GameTerritory)((int)roundPhrase - 1)] }, game, roundPhrase);
            }
            foreach (var effect in terrioritySlots.ToList())
            {
                await effect.Value.OnStartPreAtkTurn(isWin, roundPhrase);
            }
            RemoveFinishedEffect();
        }

        public async UniTask PreAtkTurn(bool isWin, RosRoundPhrase roundPhrase)
        {
            foreach (var effect in effects.ToList())
            {
                await effect.PreAtkTurn(new EffectContext { Owner = this, PlayerSlot = terrioritySlots[(GameTerritory)((int)roundPhrase - 1)] }, game, roundPhrase);
            }
            foreach (var effect in terrioritySlots.ToList())
            {
                await effect.Value.PreAtkTurn(isWin, roundPhrase);
            }
            RemoveFinishedEffect();
        }

        public async UniTask OnEndPreAtkTurn(bool isWin, RosRoundPhrase roundPhrase)
        {
            foreach (var effect in effects.ToList())
            {
                await effect.OnEndPreAtkTurn(new EffectContext { Owner = this, PlayerSlot = terrioritySlots[(GameTerritory)((int)roundPhrase - 1)] }, game, roundPhrase);
            }
            foreach (var effect in terrioritySlots.ToList())
            {
                await effect.Value.OnEndPreAtkTurn(isWin, roundPhrase);
            }
            RemoveFinishedEffect();
        }

        public async UniTask OnStartPhyAtkTurn(bool isWin, RosRoundPhrase roundPhrase)
        {
            foreach (var effect in effects.ToList())
            {
                await effect.OnStartPhyAtkTurn(new EffectContext { Owner = this, PlayerSlot = terrioritySlots[(GameTerritory)((int)roundPhrase - 1)] }, game, roundPhrase);
            }
            foreach (var effect in terrioritySlots.ToList())
            {
                await effect.Value.OnStartPhyAtkTurn(isWin, roundPhrase);
            }
            RemoveFinishedEffect();
        }

        public async UniTask OnPhyAtkTurn(bool isWin, RosRoundPhrase roundPhrase)
        {
            foreach (var effect in effects.ToList())
            {
                await effect.OnPhyAtkTurn(new EffectContext { Owner = this, PlayerSlot = terrioritySlots[(GameTerritory)((int)roundPhrase - 1)] }, game, roundPhrase);
            }
            foreach (var effect in terrioritySlots.ToList())
            {
                await effect.Value.OnPhyAtkTurn(isWin, roundPhrase);
            }
            RemoveFinishedEffect();
        }

        public async UniTask OnEndPhyAtkTurn(bool isWin, RosRoundPhrase roundPhrase)
        {
            foreach (var effect in effects.ToList())
            {
                await effect.OnEndPhyAtkTurn(new EffectContext { Owner = this, PlayerSlot = terrioritySlots[(GameTerritory)((int)roundPhrase - 1)] }, game, roundPhrase);
            }
            foreach (var effect in terrioritySlots.ToList())
            {
                await effect.Value.OnEndPhyAtkTurn(isWin, roundPhrase);
            }
            RemoveFinishedEffect();
        }

        public async UniTask OnStartMagicalAtkTurn(bool isWin, RosRoundPhrase roundPhrase)
        {
            foreach (var effect in effects.ToList())
            {
                await effect.OnStartMagicalAtkTurn(new EffectContext { Owner = this, PlayerSlot = terrioritySlots[(GameTerritory)((int)roundPhrase - 1)] }, game, roundPhrase);
            }
            foreach (var effect in terrioritySlots.ToList())
            {
                await effect.Value.OnStartMagicalAtkTurn(isWin, roundPhrase);
            }
            RemoveFinishedEffect();
        }

        public async UniTask OnMagicalTurn(bool isWin, RosRoundPhrase roundPhrase)
        {
            foreach (var effect in effects.ToList())
            {
                await effect.OnMagicalTurn(new EffectContext { Owner = this, PlayerSlot = terrioritySlots[(GameTerritory)((int)roundPhrase - 1)] }, game, roundPhrase);
            }
            foreach (var effect in terrioritySlots.ToList())
            {
                await effect.Value.OnMagicalTurn(isWin, roundPhrase);
            }
            RemoveFinishedEffect();
        }

        public async UniTask OnEndMagicalAtkTurn(bool isWin, RosRoundPhrase roundPhrase)
        {
            foreach (var effect in effects.ToList())
            {
                await effect.OnEndMagicalAtkTurn(new EffectContext { Owner = this, PlayerSlot = terrioritySlots[(GameTerritory)((int)roundPhrase - 1)] }, game, roundPhrase);
            }
            foreach (var effect in terrioritySlots.ToList())
            {
                await effect.Value.OnEndMagicalAtkTurn(isWin, roundPhrase);
            }
            RemoveFinishedEffect();
        }

        public async UniTask OnEndRound(bool isWin, RosRoundPhrase roundPhrase)
        {
            foreach (var effect in effects.ToList())
            {
                await effect.OnEndRound(new EffectContext { Owner = this, PlayerSlot = terrioritySlots[(GameTerritory)((int)roundPhrase - 1)] }, game, roundPhrase);
            }
            foreach (var effect in terrioritySlots.ToList())
            {
                await effect.Value.OnEndRound(isWin, roundPhrase);
            }
            RemoveFinishedEffect();
        }


        public async UniTask OnPlayerGetEffect(AddEffectToPlayerAction addEffect, bool isWin, RosRoundPhrase roundPhrase)
        {
            foreach (var effect in effects.ToList())
            {
                await effect.OnPlayerGetEffect(new EffectContext { Owner = this, PlayerSlot = terrioritySlots[(GameTerritory)((int)roundPhrase - 1)] }, addEffect, game);
            }
            foreach (var effect in terrioritySlots.ToList())
            {
                await effect.Value.OnPlayerGetEffect(addEffect, isWin, roundPhrase);
            }
            RemoveFinishedEffect();
        }

        public async UniTask OnStartGame(IRosGame game)
        {
            foreach (var effect in effects.ToList())
            {
                await effect.OnStartGame(new EffectContext { Owner = this }, game);
            }
            foreach (var effect in terrioritySlots.ToList())
            {
                await effect.Value.OnStartGame(game);
            }
            RemoveFinishedEffect();
        }

        public async UniTask AfterAllWin(IRosPlayer owner, bool isWin, RosRoundPhrase roundPhrase)
        {
            foreach (var effect in effects.ToList())
            {
                await effect.AfterAllWin(new EffectContext { Owner = this, PlayerSlot = terrioritySlots[(GameTerritory)((int)roundPhrase - 1)] }, owner, game, roundPhrase);
            }
            foreach (var effect in terrioritySlots.ToList())
            {
                await effect.Value.AfterAllWin(owner, isWin, roundPhrase);
            }
            RemoveFinishedEffect();
        }

        public async UniTask AfterOpponentAllWin(IRosPlayer owner, bool isWin, RosRoundPhrase roundPhrase)
        {
            foreach (var effect in effects.ToList())
            {
                await effect.AfterOpponentAllWin(new EffectContext { Owner = this, PlayerSlot = terrioritySlots[(GameTerritory)((int)roundPhrase - 1)] }, owner, game, roundPhrase);
            }
            foreach (var effect in terrioritySlots.ToList())
            {
                await effect.Value.AfterOpponentAllWin(owner, isWin, roundPhrase);
            }
            RemoveFinishedEffect();
        }

        public void RemoveFinishedEffect()
        {
            effects = effects.Where(x => !x.IsDone()).ToList();

        }

        public async UniTask OnSubHpAction(SubHpAction act)
        {
            foreach (var effect in effects.ToList())
            {
                await effect.OnPlayerGetDamage(new EffectContext { Owner = this, PlayerSlot = act.Slot }, act, game);
            }
            foreach (var effect in terrioritySlots.ToList())
            {
                await effect.Value.OnPlayerGetDamage(act);
            }
            RemoveFinishedEffect();

            Debug.Log($"Player {Id} take {act.value} {act.damageType.ToString()} damage");
            if (act.damageType == DamageType.PhysicalDamage || act.damageType == DamageType.CounterAttackPhysicalDamage)
            {
                if (CurrentArmor > act.lastValue)
                {
                    CurrentArmor = CurrentArmor - act.lastValue;
                    act.finalHpValue = CurrentHp;
                    act.finalArmorValue = CurrentArmor;
                }
                else
                {
                    CurrentArmor = 0;
                    act.finalArmorValue = 0;
                    CurrentHp = Clamp(CurrentHp - act.lastValue, 0, CurrentMaxHp);
                    act.finalHpValue = CurrentHp;
                }
            }
            else
            {
                CurrentHp = Clamp(CurrentHp - act.lastValue, 0, CurrentMaxHp);
                act.finalHpValue = CurrentHp;
                act.finalArmorValue = CurrentArmor;
            }

        }

        public void OnRestoreHpStatAction(RestoreHpAction act)
        {
            Debug.Log($"Player {Id} restore {act.value} hp");
            CurrentHp = Clamp(CurrentHp + act.value, 0, CurrentMaxHp);
            act.finalValue = CurrentHp;
        }

        public void OnGainShieldAction(GainShieldAction act)
        {
            Debug.Log($"Player {Id} restore {act.value} shield");
            CurrentArmor = Clamp(CurrentArmor + act.value, 0, CurrentMaxArmor);
            act.finalValue = CurrentArmor;
        }

        public void OnSubShieldAction(SubShieldAction act)
        {
            CurrentArmor = Clamp(CurrentArmor - act.value, 0, CurrentMaxArmor);

            act.finalValue = CurrentArmor;
        }

        public void OnReduceManaStatAction(ReduceManaStatAction act)
        {
            CurrentMana = Clamp(CurrentMana - act.value, 0, arcane.Arcane.cost);
            act.finalValue = CurrentMana;
        }

        public void OnSubtractCardSwapChanceAction(SubtractCardSwapChanceAction act)
        {
            diceCount = Clamp(diceCount - act.value, 0, int.MaxValue);
            act.finalValue = diceCount;
        }

        public void OnGainCardSwapChanceAction(GainCardSwapChanceAction act)
        {

            diceCount += act.value;
            act.finalValue = diceCount;
        }

        public void OnAddEffectToPlayerAction(AddEffectToPlayerAction act)
        {
            effects.Add(act.effect);
            act.isSuccess = true;
            act.finalStack = act.effect.Stack;
        }

        public void OnRemoveEffectFromPlayerAction(RemoveEffectAction act)
        {
            effects.Add(act.effect);
        }
        

        public PlayerShortInfo ShortInfo => throw new System.NotImplementedException();

        public int CurrentHp { get { return currentHp; } set { currentHp = value; } }  
        public int CurrentArmor { get { return currentArmor; } set { currentArmor = value; } }
        public int CurrentMana { get { return currentMana; } set { currentMana = value; } }
        public int MaxStartGameHp { get { return maxStartGameHp; } set { maxStartGameHp = value; } }
        public int MaxStartGameArmor { get { return maxStartGameArmor; } set { maxStartGameArmor = value; } }
        public int MaxStartGameAtk { get { return maxStartGameAtk; } set { maxStartGameAtk = value; } }
        public int MaxStartGameMana { get { return maxStartGameMana; } set { maxStartGameMana = value; } }
    }
}
