
using UnityEngine;
using Nakama;
using Satori;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Collections.Generic;

public class AuthenticationService : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    async Task StartAsync()
    {
        var retryConfiguration = new Nakama.RetryConfiguration(baseDelayMs: 1, maxRetries: 5, delegate { Debug.Log("about to retry."); });
        var client = new Nakama.Client("", "", 7777, "");
        // Configure the retry configuration globally.
        client.GlobalRetryConfiguration = retryConfiguration;
        client.Timeout = 15;
        var session = await client.AuthenticateDeviceAsync("<DeviceId>");


        bool appearOnline = true;
        int connectionTimeout = 30;
        // or
#if UNITY_WEBGL && !UNITY_EDITOR
    ISocketAdapter adapter = new JsWebSocketAdapter();
#else
        ISocketAdapter adapter = new WebSocketAdapter();
#endif
        var socket = Socket.From(client, adapter);
        var account = await client.GetAccountAsync(session);
        var users = await client.GetUsersAsync(session, new List<string>() { });
        var user = users.Users.GetEnumerator().Current;
        account.me

    }
    // Update is called once per frame
    void Update()
    {

    }
}
