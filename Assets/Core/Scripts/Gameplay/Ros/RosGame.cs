using Cysharp.Threading.Tasks;
using ReversalOfSpirit.Gameplay.Enums;
using ReversalOfSpirit.Gameplay.Packets;
using ReversalOfSpirit.Gameplay.Ros.Cards;
using ReversalOfSpirit.Gameplay.Ros.Cards.Actions;
using System.Collections.Generic;
namespace ReversalOfSpirit.Gameplay.Ros
{
    public interface IRosGame
    {
        int RoundIndex { get; }

        IRosConfig RosConfig { get; set; }
        IPlayerDataService PlayerDataService { get; set; }

        UniTask ExecuteSequential(List<GameAction> actions);
        void NotifySequential(List<GameAction> actions);

        IRosPlayer GetPlayer(int peerId);
        IRosPlayer GetOpponent(IRosPlayer player);
        RosPlayerSlot GetSlot(int peerId, GameTerritory territory);

        RosPlayerSlot GetOpponentSlot(IRosPlayer player, RosPlayerSlot playerSlot);

        void SetSelectionCard(int peerId, C2S_PlayerSelectionCard payload);
        void PlayerSelectionFinish(int peerId, C2S_PlayerSelectionFinish payload);
        void PlayerPresentRoundDone(int peerId, C2S_PlayerPresentRoundDone payload);

        void NotifyGameResult(NotifyGameResultAction act);
    }
}
//    [System.Serializable]
//    public class RosGame : IRosGame
//    {

//        public const int DELTA_ROUND = 20;

//        public bool isExecution => true;
//        public bool isEnd;
//        /*
//         * External Service
//         */
//        public IRosConfig RosConfig { get; set; }
//        public IPlayerDataService PlayerDataService { get; set; }

//        public int RoundIndex { get; set; }

//        public int roundActIndex { get; set; }

//        public int executionIndex { get; set; }


//        public int PlayerCount;

//        public RosPlayer PlayerA;
//        public RosPlayer PlayerB;

//        /*
//         * Turn cache
//         */

//        public bool isPrepare;
//        public double cooldown;


//        public RosGame(IRosConfig rosConfig, IPlayerDataService playerDataService, int playerCount)
//        {
//            this.RosConfig = rosConfig;
//            this.PlayerDataService = playerDataService;
//            this.PlayerCount = playerCount;
//            RoundIndex = 0;
//        }



//        public void StartRound()
//        {
//            RoundIndex++;
//            NotifySequential(new List<GameAction>() { new ShowRoundAction(RoundIndex, null, -1) });
//            Debug.Log("Server start round: " + RoundIndex);
//            PlayerA.finishRoundSelection = false;
//            PlayerB.finishRoundSelection = false;
//            PlayerA.finishRoundPresent = false;
//            PlayerB.finishRoundPresent = false;
//            PlayerA.SeedBoard();
//            PlayerB.SeedBoard();
//            PlayerA.OnStartRound();
//            PlayerB.OnStartRound();
//            cooldown = 120;
//            isPrepare = true;
//            PlayerA.BroadcastBoard();
//            PlayerB.BroadcastBoard();
//            //ChannelSender.Broadcast(nameof(S2C_SendExeImRoundActions), (writer) =>
//            //{
//            //    var act = new S2C_SendExeImRoundActions() { actions = actionPresenters };
//            //    act.Serialize(this, writer);
//            //    actionPresenters.Clear();
//            //});

//        }

//        public void Update(double deltaTime)
//        {

//            if (isPrepare)
//            {
//                cooldown -= deltaTime;
//                if (cooldown <= 0)
//                {
//                    isPrepare = false;
//                    ExecuteRound();
//                }
//            }
//        }
//        public void ExecuteSequential(List<GameAction> actions)
//        {
//            foreach (var action in actions.OrderBy(x => x.ActionSequenceIndex))
//            {
                
//                action.Execute(this);
//                if (PlayerA.CurrentHp == 0 || PlayerB.CurrentHp == 0)
//                {
//                    isEnd = true;
                    
//                }
//            }
//        }

//        public void NotifySequential(List<GameAction> actions)
//        {
//            foreach (var action in actions.OrderBy(x => x.ActionSequenceIndex))
//            {
//                action.Execute(this);
//            }
//        }

//        public void ExecuteRound()
//        {
//            Debug.Log("[*] Server execute round: " + RoundIndex);
//            isPrepare = false;
            
//            ExecuteRoundPhrase(RosRoundPhrase.Arguard);
            
//            ExecuteRoundPhrase(RosRoundPhrase.MidCenter);
            
//            ExecuteRoundPhrase(RosRoundPhrase.Rearguard);
            

//            if (RoundIndex == 6 && !isEnd)
//            {
//                ExecuteSequential(new List<GameAction> { new NotifyGameResultAction(PlayerA.CurrentHp == 0 ? PlayerA.Id : PlayerB.Id, null, 1) });
//                isEnd = true;
//            }

//            // if (!isEnd)
//            {
//                //PlayerA.Send(nameof(S2C_SendRoundActions), (writer) =>
//                //{
//                //    var act = new S2C_SendRoundActions() { actions = lst };
//                //    act.Serialize(this, writer);
//                //    actionPresenters.Clear();
//                //});
//                //PlayerB.Send(nameof(S2C_SendRoundActions), (writer) =>
//                //{
//                //    var act = new S2C_SendRoundActions() { actions = lst };
//                //    act.Serialize(this, writer);
//                //    actionPresenters.Clear();
//                //});

//            }




//        }

//        public void ExecuteRoundPhrase(RosRoundPhrase roundPhrase)
//        {
//            Debug.Log("[*] Server execute round phrase: " + roundPhrase.ToString());

//            RoundResult roundResult = RoundResult.PlayerAWin;
//            RosTurnPhrase turnPhrase = RosTurnPhrase.BeforeAttack;
//            var playerASlot = PlayerA.cardSlots[(GameTerritory)((int)roundPhrase - 1)];
//            var playerBSlot = PlayerB.cardSlots[(GameTerritory)((int)roundPhrase - 1)];

//            IRosPlayer turnWinner = playerASlot.Star >= playerBSlot.Star ? PlayerA : PlayerB;
//            IRosPlayer turnLoser = playerASlot.Star >= playerBSlot.Star ? PlayerB : PlayerA;
//            RosRuntimeCard winnerCard = playerASlot.Star >= playerBSlot.Star ? PlayerA.GetRuntimeCard(playerASlot.CardId) : PlayerB.GetRuntimeCard(playerBSlot.CardId);
//            RosRuntimeCard loserCard = playerASlot.Star >= playerBSlot.Star ? PlayerB.GetRuntimeCard(playerBSlot.CardId) : PlayerA.GetRuntimeCard(playerASlot.CardId);
//            winnerCard.Slot = turnWinner.terrioritySlots[(GameTerritory)((int)roundPhrase - 1)];
//            loserCard.Slot = turnLoser.terrioritySlots[(GameTerritory)((int)roundPhrase - 1)];
//            winnerCard.Slot.Card = winnerCard;
//            loserCard.Slot.Card = loserCard;
//            winnerCard.BaseStar = Mathf.Max(playerASlot.Star, playerBSlot.Star);
//            loserCard.BaseStar = Mathf.Min(playerASlot.Star, playerBSlot.Star);
//            Debug.Log("WinnerCard: " + winnerCard.CardDefinition.name);
//            Debug.Log("LoserCard: " + loserCard.CardDefinition.name);

//            if (playerASlot.Star > playerBSlot.Star)
//            {
//                roundResult = RoundResult.PlayerAWin;
//            }
//            else if (playerASlot.Star == playerBSlot.Star)
//            {
//                roundResult = RoundResult.Draw;
//            }
//            else
//            {
//                roundResult = RoundResult.PlayerBWin;
//            }
//            var turnActions = new List<GameAction>();
//            Debug.Log($"turnLoser: {turnLoser == null}, turnWinner: {turnWinner == null}, winnerCard: {winnerCard == null}, loserCard: {loserCard == null}, winnerCardId: {winnerCard.CardDefinition.name}, loserCardId: {loserCard.CardDefinition.name}");

            
//            ExecuteSequential(new List<GameAction>() { new RevealCardAction(new List<BoardCardView>()
//            {
//                new BoardCardView
//                {
//                    atk = winnerCard.Slot.CalculateAtk(),
//                    cardId = winnerCard.CardDefinition.id,
//                    ownerid = winnerCard.Owner.Id,
//                    star = winnerCard.BaseStar
//                },
//                new BoardCardView
//                {
//                    atk = loserCard.Slot.CalculateAtk(),
//                    cardId = loserCard.CardDefinition.id,
//                    ownerid = loserCard.Owner.Id,
//                    star = loserCard.BaseStar
//                }
//            }, null, -1) });
//            /*
//             * PreAtkTurn
//             */
            
//            turnWinner.OnStartPreAtkTurn(true, roundPhrase);
//            turnLoser.OnStartPreAtkTurn(false, roundPhrase);
            
//            winnerCard.OnStartPreAtkTurn(this, roundPhrase);
//            loserCard.OnStartPreAtkTurn(this, roundPhrase);

            
//            turnWinner.PreAtkTurn(true, roundPhrase);
//            turnLoser.PreAtkTurn(false, roundPhrase);
            
//            winnerCard.PreAtkTurn(this, roundPhrase);
//            loserCard.PreAtkTurn(this, roundPhrase);

            
//            turnWinner.OnEndPreAtkTurn(true, roundPhrase);
//            turnLoser.OnEndPreAtkTurn(false, roundPhrase);
            
//            winnerCard.OnEndPreAtkTurn(this, roundPhrase);
//            loserCard.OnEndPreAtkTurn(this, roundPhrase);
//            /*
//             * PhysicalTurn
//             */
            
//            turnWinner.OnStartPhyAtkTurn(true, roundPhrase);
//            turnLoser.OnStartPhyAtkTurn(false, roundPhrase);
            
//            winnerCard.OnStartPhyAtkTurn(this, roundPhrase);
//            loserCard.OnStartPhyAtkTurn(this, roundPhrase);

            
//            turnWinner.OnPhyAtkTurn(true, roundPhrase);
//            turnLoser.OnPhyAtkTurn(false, roundPhrase);
            
//            if (roundResult != RoundResult.Draw)
//            {
//                winnerCard.OnPhyAtkTurn(this, roundPhrase);
//            }

            
//            turnWinner.OnEndPhyAtkTurn(true, roundPhrase);
//            turnLoser.OnEndPhyAtkTurn(false, roundPhrase);
            
//            winnerCard.OnEndPhyAtkTurn(this, roundPhrase);
//            loserCard.OnEndPhyAtkTurn(this, roundPhrase);

//            /*
//             * Magical turn
//             */
            
//            turnWinner.OnStartMagicalAtkTurn(true, roundPhrase);
//            turnLoser.OnStartMagicalAtkTurn(false, roundPhrase);
            
//            winnerCard.OnStartMagicalAtkTurn(this, roundPhrase);
//            loserCard.OnStartMagicalAtkTurn(this, roundPhrase);

            
//            turnWinner.OnMagicalTurn(true, roundPhrase);
//            turnLoser.OnMagicalTurn(false, roundPhrase);

            

//            if (roundResult != RoundResult.Draw)
//            {
//                winnerCard.OnMagicalTurn(this, roundPhrase);
//            }

            
//            turnWinner.OnEndMagicalAtkTurn(true, roundPhrase);
//            turnLoser.OnEndMagicalAtkTurn(false, roundPhrase);
            
//            winnerCard.OnEndMagicalAtkTurn(this, roundPhrase);
//            loserCard.OnEndMagicalAtkTurn(this, roundPhrase);




//        }

//        public void ExecuteTurnPhrase(IRosPlayer winner, IRosGame loser, RosRuntimeCard winnerCard, RosRuntimeCard loserCard, RosRoundPhrase roundPhrase, RosTurnPhrase turnPhrase)
//        {

//        }

//        public void C2S_ChannelReady(int peerId, C2S_ChannelReady payload)
//        {
//            if (PlayerCount == 1)
//            {
//                PlayerA = new RosRealPlayer(0, peerId, this);
//                PlayerB = new RosBot(this);
//            }
//            else if (PlayerA == null)
//            {
//                PlayerA = new RosRealPlayer(0, peerId, this);
//            }
//            else if (PlayerB == null)
//            {
//                PlayerB = new RosRealPlayer(1, peerId, this);
//            }
//            if (PlayerA != null && PlayerB != null)
//            {
//                if (RoundIndex == 0)
//                {
//                    //ChannelSender.Broadcast(nameof(S2C_GameStart), new S2C_GameStart()
//                    //{
//                    //    players = new List<PlayerShortInfo>()
//                    //    {
//                    //        PlayerA.ShortInfo,
//                    //        PlayerB.ShortInfo
//                    //    }
//                    //});
//                    PlayerA.OnStartGame();
//                    PlayerB.OnStartGame();
//                    //ChannelSender.Broadcast(nameof(S2C_GameSetup), new S2C_GameSetup()
//                    //{
//                    //    players = new List<PlayerBaseStat>()
//                    //    {
//                    //        new PlayerBaseStat
//                    //        {
//                    //            id = PlayerA.Id,
//                    //            currentArmor = PlayerA.currentArmor,
//                    //            currentHp = PlayerA.currentHp,
//                    //            currentMana = PlayerA.currentMana,
//                    //            totalArmor = PlayerA.maxStartGameArmor,
//                    //            totalHp = PlayerA.maxStartGameHp,
//                    //            totalMana = PlayerA.maxStartGameMana
//                    //        },
//                    //        new PlayerBaseStat
//                    //        {
//                    //            id = PlayerB.Id,
//                    //            currentArmor = PlayerB.currentArmor,
//                    //            currentHp = PlayerB.currentHp,
//                    //            currentMana = PlayerB.currentMana,
//                    //            totalArmor = PlayerB.maxStartGameArmor,
//                    //            totalHp = PlayerB.maxStartGameHp,
//                    //            totalMana = PlayerB.maxStartGameMana
//                    //        }
//                    //    }
//                    //});
//                }

//                StartRound();

//            }

//        }

//        public void SetSelectionCard(int peerId, C2S_PlayerSelectionCard payload)
//        {
//            var player = GetPlayer(peerId);
//            player.OnSelectCard(payload.slot, payload.cardId);
//        }

//        public void PlayerSelectionFinish(int peerId, C2S_PlayerSelectionFinish payload)
//        {
//            var player = GetPlayer(peerId);
//            player.finishRoundSelection = true;
//            if (PlayerA.finishRoundSelection && PlayerB.finishRoundSelection)
//            {
//                ExecuteRound();
//            }

//        }

//        public void C2S_PlayerSwapSelectionCard(int peerId, C2S_PlayerSwapSelectionCard payload)
//        {

//        }

//        public void PlayerPresentRoundDone(int peerId, C2S_PlayerPresentRoundDone payload)
//        {
//            var player = GetPlayer(peerId);
//            player.finishRoundPresent = true;
//            if (PlayerA.finishRoundPresent && PlayerB.finishRoundPresent)
//            {
//                StartRound();
//            }
//        }

//        public void C2S_PlayerUseSkill(int peerId, C2S_PlayerUseSkill payload)
//        {

//        }

//        public IRosPlayer GetPlayer(int peerId)
//        {
//            if (PlayerA.Id == peerId)
//            {
//                return PlayerA;
//            }
//            return PlayerB;
//        }

//        public void AddHpToPlayer(IRosPlayer player, int value)
//        {

//        }

//        public IRosPlayer GetOpponent(IRosPlayer player)
//        {
//            if (player == PlayerA)
//            {
//                return PlayerB;
//            }
//            else
//            {
//                return PlayerA;
//            }
//        }

//        public RosPlayerSlot GetOpponentSlot(IRosPlayer player, RosPlayerSlot playerSlot)
//        {
//            var opponent = GetOpponent(player);


//            return opponent.terrioritySlots[playerSlot.Terriotory];
//        }

//        public RosPlayerSlot GetSlot(int peerId, GameTerritory territory)
//        {
//            var player = GetPlayer(peerId);

//            return player.terrioritySlots[territory];
//        }

//        public void NotifyGameResult(NotifyGameResultAction act)
//        {

//        }
//    }
//}
