using Mirror.Examples.MultipleMatch;
using Mirror;
using UnityEngine;
using System.Collections;

namespace Ros
{
    [RequireComponent(typeof(NetworkMatch))]
    public class MatchManager : NetworkBehaviour
    {
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
    }
}
