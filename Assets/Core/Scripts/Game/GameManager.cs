using DarkRift.Server.Plugins.Matchmaking;
using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Ros
{
    public class GameManager : MonoBehaviour
    {

        /// <summary>
        /// Match Controllers listen for this to terminate their match and clean up
        /// </summary>
        public event Action<NetworkConnectionToClient> OnPlayerDisconnected;

        /// <summary>
        /// Cross-reference of client that created the corresponding match in openMatches below
        /// </summary>
        internal static readonly Dictionary<NetworkConnectionToClient, Guid> playerMatches = new Dictionary<NetworkConnectionToClient, Guid>();

        /// <summary>
        /// Network Connections of all players in a match
        /// </summary>
        internal static readonly Dictionary<Guid, HashSet<NetworkConnectionToClient>> matchConnections = new Dictionary<Guid, HashSet<NetworkConnectionToClient>>();

        /// <summary>
        /// Player informations by Network Connection
        /// </summary>
        internal static readonly Dictionary<NetworkConnection, PlayerInfo> playerInfos = new Dictionary<NetworkConnection, PlayerInfo>();

        internal static readonly Dictionary<NetworkConnectionToClient, IMatchmakerQueueTask<MatchmakingData>> matchmakingDict = new Dictionary<NetworkConnectionToClient, IMatchmakerQueueTask<MatchmakingData>>();

        /// <summary>
        /// GUID of a match the local player has created
        /// </summary>
        internal Guid localPlayerMatch = Guid.Empty;

        /// <summary>
        /// GUID of a match the local player has joined
        /// </summary>
        internal Guid localJoinedMatch = Guid.Empty;

        /// <summary>
        /// GUID of a match the local player has selected in the Toggle Group match list
        /// </summary>
        internal Guid selectedMatch = Guid.Empty;

        [SerializeField] MatchManager matchControllerPrefab;
        [SerializeField] EloMatchmaker eloMatchmaker;
        private void Start()
        {
            eloMatchmaker.GroupFormed += OnMatchForms;
        }


        // Called from several places to ensure a clean reset
        //  - MatchNetworkManager.Awake
        //  - OnStartServer
        //  - OnStartClient
        //  - OnClientDisconnect
        //  - ResetCanvas
        public void InitializeData()
        {

        }

        // Called from OnStopServer and OnStopClient when shutting down
        void ResetCanvas()
        {

        }

        [ServerCallback]
        internal void OnServerReady(NetworkConnectionToClient conn)
        {

        }

        [ServerCallback]
        internal IEnumerator OnServerDisconnect(NetworkConnectionToClient conn)
        {
            yield return null;
        }

        [ServerCallback]
        internal void OnStopServer()
        {
            ResetCanvas();
        }

        [ClientCallback]
        internal void OnClientConnect()
        {

        }

        [ClientCallback]
        internal void OnClientDisconnect()
        {
            InitializeData();
        }

        [ClientCallback]
        internal void OnStopClient()
        {
            ResetCanvas();
        }

        // Methods in this section are called from MatchNetworkManager's corresponding methods

        [ServerCallback]
        internal void OnStartServer()
        {
            InitializeData();
            NetworkServer.RegisterHandler<ServerMatchMessage>(OnServerMatchMessage);
            NetworkServer.RegisterHandler<ServerPveMessage>(OnServerPveMessage);
        }



        /// <summary>
        /// Assigned in inspector to Join button
        /// </summary>
        [ClientCallback]
        public void RequestJoinMatch()
        {
            NetworkClient.Send(new ServerMatchMessage { serverMatchOperation = ServerMatchOperation.CreateOrJoin});
        }

        /// <summary>
        /// Assigned in inspector to Join button
        /// </summary>
        [ClientCallback]
        public void CancelMatch()
        {
            NetworkClient.Send(new ServerMatchMessage { serverMatchOperation = ServerMatchOperation.Cancel });
        }

        /// <summary>
        /// Assigned in inspector to Join button
        /// </summary>
        [ClientCallback]
        public void RequestBotMatch()
        {
            NetworkClient.Send(new ServerMatchMessage { serverMatchOperation = ServerMatchOperation.Cancel });
        }

        /// <summary>
        /// Assigned in inspector to Join button
        /// </summary>
        [ClientCallback]
        public void RequestPveMatch(int botId)
        {
            NetworkClient.Send(new ServerPveMessage { serverMatchOperation = ServerMatchOperation.Cancel });
        }
        private void OnServerPveMessage(NetworkConnectionToClient client, ServerPveMessage message)
        {

        }

        public void OnServerMatchMessage(NetworkConnectionToClient conn, ServerMatchMessage msg)
        {
            switch (msg.serverMatchOperation)
            {
                case ServerMatchOperation.None:
                    {
                        Debug.LogWarning("Missing ServerMatchOperation");
                        break;
                    }
                case ServerMatchOperation.CreateOrJoin:
                    {
                        OnServerCreateMatch(conn);
                        break;
                    }
                case ServerMatchOperation.Cancel:
                    {
                        OnServerCancelMatch(conn);
                        break;
                    }
                case ServerMatchOperation.Bot:
                    {
                        OnServerCreateBotMatch(conn);
                        break;
                    }
            }
        }

        [ServerCallback]
        public void OnServerCreateMatch(NetworkConnectionToClient client)
        {
            var queueTask = eloMatchmaker.Enqueue(new MatchmakingData
            {
                conn = client,
                elo = 200
            });
            matchmakingDict[client] = queueTask;
        }

        [ServerCallback]
        public void OnServerCancelMatch(NetworkConnectionToClient client)
        {
            if (matchmakingDict.TryGetValue(client, out var match))
            {
                match.Cancel();
                matchmakingDict.Remove(client);
            }
        }

        [ServerCallback]
        public void OnServerCreateBotMatch(NetworkConnectionToClient client)
        {
            if (matchmakingDict.TryGetValue(client, out var match))
            {
                match.Cancel();
                matchmakingDict.Remove(client);
            }

            BotService.Instance.FindBotProfile(200);
        } 



        private void OnMatchForms(object sender, GroupFormedEventArgs<MatchmakingData> e)
        {
            Guid matchId = Guid.NewGuid();
            GameObject matchControllerObject = Instantiate(matchControllerPrefab.gameObject);
            matchControllerObject.GetComponent<NetworkMatch>().matchId = matchId;
            NetworkServer.Spawn(matchControllerObject);

            MatchManager matchController = matchControllerObject.GetComponent<MatchManager>();

            foreach (NetworkConnectionToClient playerConn in e.Group.Select(x => x.conn))
            {
                playerConn.Send(new ClientMatchMessage { clientMatchOperation = ClientMatchOperation.Started });

                GameObject player = Instantiate(NetworkManager.singleton.playerPrefab);
                player.GetComponent<NetworkMatch>().matchId = matchId;
                NetworkServer.AddPlayerForConnection(playerConn, player);
                var p = player.GetComponent<Player>();
                if (matchController.player1 == null)
                    matchController.player1 = p;
                else
                    matchController.player2 = p;

                /* Reset ready state for after the match. */
                PlayerInfo playerInfo = playerInfos[playerConn];
                playerInfo.ready = false;
                playerInfos[playerConn] = playerInfo;
            }

            OnPlayerDisconnected += matchController.OnPlayerDisconnected;
        }

        

        [ClientCallback]
        internal void OnStartClient()
        {
            InitializeData();
            //createButton.gameObject.SetActive(true);
            //joinButton.gameObject.SetActive(true);
            NetworkClient.RegisterHandler<ClientMatchMessage>(OnClientMatchMessage);
        }

        [ClientCallback]
        public void OnClientMatchMessage(ClientMatchMessage msg)
        {
            switch (msg.clientMatchOperation)
            {
                case ClientMatchOperation.None:
                    {
                        Debug.LogWarning("Missing ClientMatchOperation");
                        break;
                    }
            }
        }

        /// <summary>
        /// Called from <see cref="MatchController.RpcExitGame"/>
        /// </summary>
        [ClientCallback]
        public void OnMatchEnded()
        {
            localPlayerMatch = Guid.Empty;
            localJoinedMatch = Guid.Empty;
            //ShowLobbyView();
        }
    }
}
