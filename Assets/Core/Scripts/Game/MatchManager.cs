using Mirror.Examples.MultipleMatch;
using Mirror;
using UnityEngine;
using System.Collections;
using ReversalOfSpirit.Gameplay.Ros;
using System.Collections.Generic;
using ReversalOfSpirit.Gameplay.Ros.Cards;
using ReversalOfSpirit.Gameplay.Enums;
using ReversalOfSpirit.Gameplay.Packets;
using ReversalOfSpirit.Gameplay.Ros.Cards.Actions;
using System.Linq;
using Unity.VisualScripting;

namespace Ros
{
    [RequireComponent(typeof(NetworkMatch))]
    public class MatchManager : NetworkBehaviour, IRosGame
    {

        public const int DELTA_ROUND = 20;

        public bool isExecution => true;
        public bool isEnd;

        public bool isPrepare;
        public double cooldown;
        public int roundIndex;

        public int RoundIndex => roundIndex;
        internal readonly SyncDictionary<NetworkIdentity, MatchPlayerData> matchPlayerData = new SyncDictionary<NetworkIdentity, MatchPlayerData>();

        [ReadOnly, SerializeField] internal GameManager canvasController;
        [ReadOnly, SerializeField] internal BasePlayer player1;
        [ReadOnly, SerializeField] internal BasePlayer player2;

        [Command(requiresAuthority = false)]
        public void CmdMakePlay(NetworkConnectionToClient sender = null)
        {

        }
        public override void OnStartClient()
        {
            //canvasGroup.alpha = 1f;
            //canvasGroup.interactable = true;
            //canvasGroup.blocksRaycasts = true;

            //exitButton.gameObject.SetActive(false);
            //playAgainButton.gameObject.SetActive(false);
        }

        [ServerCallback]
        bool CheckWinner()
        {
            return false;
        }

        [ClientCallback]
        public void UpdateWins(SyncDictionary<NetworkIdentity, MatchPlayerData>.Operation op, NetworkIdentity key, MatchPlayerData matchPlayerData)
        {
            if (key.gameObject.GetComponent<NetworkIdentity>().isLocalPlayer)
            {
                //winCountLocal.text = $"Player {matchPlayerData.playerIndex}\n{matchPlayerData.wins}";
            }

            else
            {
                //winCountOpponent.text = $"Player {matchPlayerData.playerIndex}\n{matchPlayerData.wins}";
            }

        }

        [ClientRpc]
        public void RpcUpdateCell(CellValue cellValue, NetworkIdentity player)
        {

        }

        [ClientRpc]
        public void RpcShowWinner(NetworkIdentity winner)
        {

        }

        // Assigned in inspector to BackButton::OnClick
        [Client]
        public void RequestExitGame()
        {
            CmdRequestExitGame();
        }

        [Command(requiresAuthority = false)]
        public void CmdRequestExitGame(NetworkConnectionToClient sender = null)
        {
            StartCoroutine(ServerEndMatch(sender, false));
        }

        [ServerCallback]
        public void OnPlayerDisconnected(NetworkConnectionToClient conn)
        {
            // Check that the disconnecting client is a player in this match
            if (player1 == conn.identity || player2 == conn.identity)
                StartCoroutine(ServerEndMatch(conn, true));
        }

        [ServerCallback]
        public IEnumerator ServerEndMatch(NetworkConnectionToClient conn, bool disconnected)
        {
            RpcExitGame();

            canvasController.OnPlayerDisconnected -= OnPlayerDisconnected;

            // Wait for the ClientRpc to get out ahead of object destruction
            yield return new WaitForSeconds(0.1f);

            // Mirror will clean up the disconnecting client so we only need to clean up the other remaining client.
            // If both players are just returning to the Lobby, we need to remove both connection Players

            if (!disconnected)
            {
                NetworkServer.RemovePlayerForConnection(player1.connectionToClient, RemovePlayerOptions.Destroy);


                NetworkServer.RemovePlayerForConnection(player2.connectionToClient, RemovePlayerOptions.Destroy);
               
            }
            else if (conn == player1.connectionToClient)
            {
                // player1 has disconnected - send player2 back to Lobby
                NetworkServer.RemovePlayerForConnection(player2.connectionToClient, RemovePlayerOptions.Destroy);
       
            }
            else if (conn == player2.connectionToClient)
            {
                // player2 has disconnected - send player1 back to Lobby
                NetworkServer.RemovePlayerForConnection(player1.connectionToClient, RemovePlayerOptions.Destroy);
          
            }

            // Skip a frame to allow the Removal(s) to complete
            yield return null;

            // Send latest match list
            //canvasController.SendMatchList();

            NetworkServer.Destroy(gameObject);
        }

        [ClientRpc]
        public void RpcExitGame()
        {
            canvasController.OnMatchEnded();
        }

       

        public IRosConfig RosConfig { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IPlayerDataService PlayerDataService { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }



        public void StartRound()
        {
            roundIndex++;
            NotifySequential(new List<GameAction>() { new ShowRoundAction(roundIndex, null, -1) });
            Debug.Log("Server start round: " + roundIndex);
            player1.finishRoundSelection = false;
            player2.finishRoundSelection = false;
            player1.finishRoundPresent = false;
            player2.finishRoundPresent = false;
            player1.SeedBoard();
            player2.SeedBoard();
            player1.OnStartRound();
            player2.OnStartRound();
            cooldown = 120;
            isPrepare = true;
            player1.BroadcastBoard();
            player2.BroadcastBoard();
            //ChannelSender.Broadcast(nameof(S2C_SendExeImRoundActions), (writer) =>
            //{
            //    var act = new S2C_SendExeImRoundActions() { actions = actionPresenters };
            //    act.Serialize(this, writer);
            //    actionPresenters.Clear();
            //});

        }

        public void Update()
        {

            if (isPrepare)
            {
                cooldown -= Time.deltaTime;
                if (cooldown <= 0)
                {
                    isPrepare = false;
                    ExecuteRound();
                }
            }
        }
        public void ExecuteSequential(List<GameAction> actions)
        {
            foreach (var action in actions.OrderBy(x => x.ActionSequenceIndex))
            {

                action.Execute(this);
                if (player1.CurrentHp == 0 || player2.CurrentHp == 0)
                {
                    isEnd = true;

                }
            }
        }

        public void NotifySequential(List<GameAction> actions)
        {
            foreach (var action in actions.OrderBy(x => x.ActionSequenceIndex))
            {
                action.Execute(this);
            }
        }

        public void ExecuteRound()
        {
            Debug.Log("[*] Server execute round: " + roundIndex);
            isPrepare = false;

            ExecuteRoundPhrase(RosRoundPhrase.Arguard);

            ExecuteRoundPhrase(RosRoundPhrase.MidCenter);

            ExecuteRoundPhrase(RosRoundPhrase.Rearguard);


            if (roundIndex == 6 && !isEnd)
            {
                ExecuteSequential(new List<GameAction> { new NotifyGameResultAction(player1.CurrentHp == 0 ? player1.Id : player2.Id, null, 1) });
                isEnd = true;
            }

            // if (!isEnd)
            {
                //player1.Send(nameof(S2C_SendRoundActions), (writer) =>
                //{
                //    var act = new S2C_SendRoundActions() { actions = lst };
                //    act.Serialize(this, writer);
                //    actionPresenters.Clear();
                //});
                //player2.Send(nameof(S2C_SendRoundActions), (writer) =>
                //{
                //    var act = new S2C_SendRoundActions() { actions = lst };
                //    act.Serialize(this, writer);
                //    actionPresenters.Clear();
                //});

            }




        }

        public void ExecuteRoundPhrase(RosRoundPhrase roundPhrase)
        {
            Debug.Log("[*] Server execute round phrase: " + roundPhrase.ToString());

            RoundResult roundResult = RoundResult.PlayerAWin;
            RosTurnPhrase turnPhrase = RosTurnPhrase.BeforeAttack;
            var player1Slot = player1.cardSlots[(GameTerritory)((int)roundPhrase - 1)];
            var player2Slot = player2.cardSlots[(GameTerritory)((int)roundPhrase - 1)];

            IRosPlayer turnWinner = player1Slot.Star >= player2Slot.Star ? player1 : player2;
            IRosPlayer turnLoser = player1Slot.Star >= player2Slot.Star ? player2 : player1;
            RosRuntimeCard winnerCard = player1Slot.Star >= player2Slot.Star ? player1.GetRuntimeCard(player1Slot.CardId) : player2.GetRuntimeCard(player2Slot.CardId);
            RosRuntimeCard loserCard = player1Slot.Star >= player2Slot.Star ? player2.GetRuntimeCard(player2Slot.CardId) : player1.GetRuntimeCard(player1Slot.CardId);
            winnerCard.Slot = turnWinner.terrioritySlots[(GameTerritory)((int)roundPhrase - 1)];
            loserCard.Slot = turnLoser.terrioritySlots[(GameTerritory)((int)roundPhrase - 1)];
            winnerCard.Slot.Card = winnerCard;
            loserCard.Slot.Card = loserCard;
            winnerCard.BaseStar = Mathf.Max(player1Slot.Star, player2Slot.Star);
            loserCard.BaseStar = Mathf.Min(player1Slot.Star, player2Slot.Star);
            Debug.Log("WinnerCard: " + winnerCard.CardDefinition.name);
            Debug.Log("LoserCard: " + loserCard.CardDefinition.name);

            if (player1Slot.Star > player2Slot.Star)
            {
                roundResult = RoundResult.PlayerAWin;
            }
            else if (player1Slot.Star == player2Slot.Star)
            {
                roundResult = RoundResult.Draw;
            }
            else
            {
                roundResult = RoundResult.PlayerBWin;
            }
            var turnActions = new List<GameAction>();
            Debug.Log($"turnLoser: {turnLoser == null}, turnWinner: {turnWinner == null}, winnerCard: {winnerCard == null}, loserCard: {loserCard == null}, winnerCardId: {winnerCard.CardDefinition.name}, loserCardId: {loserCard.CardDefinition.name}");


            ExecuteSequential(new List<GameAction>() { new RevealCardAction(new List<BoardCardView>()
            {
                new BoardCardView
                {
                    atk = winnerCard.Slot.CalculateAtk(),
                    cardId = winnerCard.CardDefinition.id,
                    ownerid = winnerCard.Owner.Id,
                    star = winnerCard.BaseStar
                },
                new BoardCardView
                {
                    atk = loserCard.Slot.CalculateAtk(),
                    cardId = loserCard.CardDefinition.id,
                    ownerid = loserCard.Owner.Id,
                    star = loserCard.BaseStar
                }
            }, null, -1) });
            /*
             * PreAtkTurn
             */

            turnWinner.OnStartPreAtkTurn(true, roundPhrase);
            turnLoser.OnStartPreAtkTurn(false, roundPhrase);

            winnerCard.OnStartPreAtkTurn(this, roundPhrase);
            loserCard.OnStartPreAtkTurn(this, roundPhrase);


            turnWinner.PreAtkTurn(true, roundPhrase);
            turnLoser.PreAtkTurn(false, roundPhrase);

            winnerCard.PreAtkTurn(this, roundPhrase);
            loserCard.PreAtkTurn(this, roundPhrase);


            turnWinner.OnEndPreAtkTurn(true, roundPhrase);
            turnLoser.OnEndPreAtkTurn(false, roundPhrase);

            winnerCard.OnEndPreAtkTurn(this, roundPhrase);
            loserCard.OnEndPreAtkTurn(this, roundPhrase);
            /*
             * PhysicalTurn
             */

            turnWinner.OnStartPhyAtkTurn(true, roundPhrase);
            turnLoser.OnStartPhyAtkTurn(false, roundPhrase);

            winnerCard.OnStartPhyAtkTurn(this, roundPhrase);
            loserCard.OnStartPhyAtkTurn(this, roundPhrase);


            turnWinner.OnPhyAtkTurn(true, roundPhrase);
            turnLoser.OnPhyAtkTurn(false, roundPhrase);

            if (roundResult != RoundResult.Draw)
            {
                winnerCard.OnPhyAtkTurn(this, roundPhrase);
            }


            turnWinner.OnEndPhyAtkTurn(true, roundPhrase);
            turnLoser.OnEndPhyAtkTurn(false, roundPhrase);

            winnerCard.OnEndPhyAtkTurn(this, roundPhrase);
            loserCard.OnEndPhyAtkTurn(this, roundPhrase);

            /*
             * Magical turn
             */

            turnWinner.OnStartMagicalAtkTurn(true, roundPhrase);
            turnLoser.OnStartMagicalAtkTurn(false, roundPhrase);

            winnerCard.OnStartMagicalAtkTurn(this, roundPhrase);
            loserCard.OnStartMagicalAtkTurn(this, roundPhrase);


            turnWinner.OnMagicalTurn(true, roundPhrase);
            turnLoser.OnMagicalTurn(false, roundPhrase);



            if (roundResult != RoundResult.Draw)
            {
                winnerCard.OnMagicalTurn(this, roundPhrase);
            }


            turnWinner.OnEndMagicalAtkTurn(true, roundPhrase);
            turnLoser.OnEndMagicalAtkTurn(false, roundPhrase);

            winnerCard.OnEndMagicalAtkTurn(this, roundPhrase);
            loserCard.OnEndMagicalAtkTurn(this, roundPhrase);




        }

        public void ExecuteTurnPhrase(IRosPlayer winner, IRosGame loser, RosRuntimeCard winnerCard, RosRuntimeCard loserCard, RosRoundPhrase roundPhrase, RosTurnPhrase turnPhrase)
        {

        }

        public void C2S_ChannelReady(int peerId, C2S_ChannelReady payload)
        {
            //if (PlayerCount == 1)
            //{
            //    player1 = new RosRealPlayer(0, peerId, this);
            //    player2 = new RosBot(this);
            //}
            //else if (player1 == null)
            //{
            //    player1 = new RosRealPlayer(0, peerId, this);
            //}
            //else if (player2 == null)
            //{
            //    player2 = new RosRealPlayer(1, peerId, this);
            //}
            if (player1 != null && player2 != null)
            {
                if (roundIndex == 0)
                {
                    //ChannelSender.Broadcast(nameof(S2C_GameStart), new S2C_GameStart()
                    //{
                    //    players = new List<PlayerShortInfo>()
                    //    {
                    //        player1.ShortInfo,
                    //        player2.ShortInfo
                    //    }
                    //});
                    player1.OnStartGame();
                    player2.OnStartGame();
                    //ChannelSender.Broadcast(nameof(S2C_GameSetup), new S2C_GameSetup()
                    //{
                    //    players = new List<player2aseStat>()
                    //    {
                    //        new player2aseStat
                    //        {
                    //            id = player1.Id,
                    //            currentArmor = player1.currentArmor,
                    //            currentHp = player1.currentHp,
                    //            currentMana = player1.currentMana,
                    //            totalArmor = player1.maxStartGameArmor,
                    //            totalHp = player1.maxStartGameHp,
                    //            totalMana = player1.maxStartGameMana
                    //        },
                    //        new player2aseStat
                    //        {
                    //            id = player2.Id,
                    //            currentArmor = player2.currentArmor,
                    //            currentHp = player2.currentHp,
                    //            currentMana = player2.currentMana,
                    //            totalArmor = player2.maxStartGameArmor,
                    //            totalHp = player2.maxStartGameHp,
                    //            totalMana = player2.maxStartGameMana
                    //        }
                    //    }
                    //});
                }

                StartRound();

            }

        }

        [Command]
        public void SetSelectionCard(int peerId, C2S_PlayerSelectionCard payload)
        {
            var player = GetPlayer(peerId);
            player.OnSelectCard(payload.slot, payload.cardId);
        }

        [Command]

        public void PlayerSelectionFinish(int peerId, C2S_PlayerSelectionFinish payload)
        {
            var player = GetPlayer(peerId);
            player.finishRoundSelection = true;
            if (player1.finishRoundSelection && player2.finishRoundSelection)
            {
                ExecuteRound();
            }

        }

        public void C2S_PlayerSwapSelectionCard(int peerId, C2S_PlayerSwapSelectionCard payload)
        {

        }

        public void PlayerPresentRoundDone(int peerId, C2S_PlayerPresentRoundDone payload)
        {
            var player = GetPlayer(peerId);
            player.finishRoundPresent = true;
            if (player1.finishRoundPresent && player2.finishRoundPresent)
            {
                StartRound();
            }
        }

        [Command]
        public void C2S_PlayerUseSkill(int peerId, C2S_PlayerUseSkill payload)
        {

        }

        public IRosPlayer GetPlayer(int peerId)
        {
            if (player1.Id == peerId)
            {
                return player1;
            }
            return player2;
        }

        public void AddHpToPlayer(IRosPlayer player, int value)
        {

        }

        public IRosPlayer GetOpponent(IRosPlayer player)
        {
            if (player == player1)
            {
                return player2;
            }
            else
            {
                return player1;
            }
        }

        public RosPlayerSlot GetOpponentSlot(IRosPlayer player, RosPlayerSlot playerSlot)
        {
            var opponent = GetOpponent(player);


            return opponent.terrioritySlots[playerSlot.Terriotory];
        }

        public RosPlayerSlot GetSlot(int peerId, GameTerritory territory)
        {
            var player = GetPlayer(peerId);

            return player.terrioritySlots[territory];
        }

        public void NotifyGameResult(NotifyGameResultAction act)
        {

        }
    }
}
