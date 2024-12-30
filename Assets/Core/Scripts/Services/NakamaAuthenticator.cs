using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class NakamaAuthenticator : NetworkAuthenticator
{

    readonly HashSet<NetworkConnectionToClient> connectionsPendingDisconnect = new HashSet<NetworkConnectionToClient>();
#if UNITY_SERVER
    [SerializeField] string sessionKey;
#endif
    public string currentUserId;
    public string currentAccessToken;
    #region Messages

    public struct AuthRequestMessage : NetworkMessage
    {
        // use whatever credentials make sense for your game
        // for example, you might want to pass the accessToken if using oauth
        public string userId;
        public string accessToken;
    }

    public struct AuthResponseMessage : NetworkMessage
    {
        public byte code;
        public string message;
    }

    #endregion

    #region Server

    /// <summary>
    /// Called on server from StartServer to initialize the Authenticator
    /// <para>Server message handlers should be registered in this method.</para>
    /// </summary>
    public override void OnStartServer()
    {
        // register a handler for the authentication request we expect from client
        NetworkServer.RegisterHandler<AuthRequestMessage>(OnAuthRequestMessage, false);
    }

    /// <summary>
    /// Called on server from StopServer to reset the Authenticator
    /// <para>Server message handlers should be unregistered in this method.</para>
    /// </summary>
    public override void OnStopServer()
    {
        // unregister the handler for the authentication request
        NetworkServer.UnregisterHandler<AuthRequestMessage>();
    }

    /// <summary>
    /// Called on server from OnServerConnectInternal when a client needs to authenticate
    /// </summary>
    /// <param name="conn">Connection to client.</param>
    public override void OnServerAuthenticate(NetworkConnectionToClient conn)
    {
        // do nothing...wait for AuthRequestMessage from client
    }

    /// <summary>
    /// Called on server when the client's AuthRequestMessage arrives
    /// </summary>
    /// <param name="conn">Connection to client.</param>
    /// <param name="msg">The message payload</param>
    public void OnAuthRequestMessage(NetworkConnectionToClient conn, AuthRequestMessage msg)
    {
        //Debug.Log($"Authentication Request: {msg.authUsername} {msg.authPassword}");

        if (connectionsPendingDisconnect.Contains(conn)) return;

        // check the credentials by calling your web server, database table, playfab api, or any method appropriate.
        //if (msg.authUsername == serverUsername && msg.authPassword == serverPassword)
        bool valid = false;
        object uid = "";
        #if UNITY_SERVER
        try
        {
            var jwt = JWT.JsonWebToken.DecodeToObject(msg.accessToken, sessionKey) as IDictionary<string, object>;
            if (jwt.TryGetValue("uid", out uid))
            {
                valid = true;
            }
        }
        catch (JWT.SignatureVerificationException)
        {
            Console.WriteLine("Invalid token!");
        }
#endif
        if (valid)
        {
            // create and send msg to client so it knows to proceed
            AuthResponseMessage authResponseMessage = new AuthResponseMessage
            {
                code = 100,
                message = "Success"
            };

            conn.Send(authResponseMessage);
            conn.authenticationData = uid;
            // Accept the successful authentication
            ServerAccept(conn);
        }
        else
        {
            connectionsPendingDisconnect.Add(conn);

            // create and send msg to client so it knows to disconnect
            AuthResponseMessage authResponseMessage = new AuthResponseMessage
            {
                code = 200,
                message = "Invalid Credentials"
            };

            conn.Send(authResponseMessage);

            // must set NetworkConnection isAuthenticated = false
            conn.isAuthenticated = false;

            // disconnect the client after 1 second so that response message gets delivered
            StartCoroutine(DelayedDisconnect(conn, 1f));
        }
    }

    IEnumerator DelayedDisconnect(NetworkConnectionToClient conn, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        // Reject the unsuccessful authentication
        ServerReject(conn);

        yield return null;

        // remove conn from pending connections
        connectionsPendingDisconnect.Remove(conn);
    }

#endregion

    #region Client

    /// <summary>
    /// Called on client from StartClient to initialize the Authenticator
    /// <para>Client message handlers should be registered in this method.</para>
    /// </summary>
    public override void OnStartClient()
    {
        // register a handler for the authentication response we expect from server
        NetworkClient.RegisterHandler<AuthResponseMessage>(OnAuthResponseMessage, false);
    }

    /// <summary>
    /// Called on client from StopClient to reset the Authenticator
    /// <para>Client message handlers should be unregistered in this method.</para>
    /// </summary>
    public override void OnStopClient()
    {
        // unregister the handler for the authentication response
        NetworkClient.UnregisterHandler<AuthResponseMessage>();
    }

    /// <summary>
    /// Called on client from OnClientConnectInternal when a client needs to authenticate
    /// </summary>
    public override void OnClientAuthenticate()
    {
        AuthRequestMessage authRequestMessage = new AuthRequestMessage
        {
            accessToken = currentAccessToken,
            userId = currentUserId
        };

        NetworkClient.Send(authRequestMessage);
    }

    /// <summary>
    /// Called on client when the server's AuthResponseMessage arrives
    /// </summary>
    /// <param name="msg">The message payload</param>
    public void OnAuthResponseMessage(AuthResponseMessage msg)
    {
        if (msg.code == 100)
        {
            //Debug.Log($"Authentication Response: {msg.message}");

            // Authentication has been accepted
            ClientAccept();
        }
        else
        {
            Debug.LogError($"Authentication Response: {msg.message}");

            // Authentication has been rejected
            ClientReject();
        }
    }

    #endregion
}
