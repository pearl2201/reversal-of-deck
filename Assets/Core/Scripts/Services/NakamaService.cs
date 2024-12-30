using Mirror.Examples.MultipleMatch;
using Nakama;
using UnityEngine;

public class NakamaService : MonoBehaviour
{
    public static NakamaService Instance { get; private set; }
    [SerializeField] MatchNetworkManager networkManager;
    [SerializeField] NakamaAuthenticator nakamaAuthenticator;
    [SerializeField] string protocol;
    [SerializeField] string host;
    [SerializeField] int port;
    [SerializeField] string serverKey;
    [SerializeField] string httpKey;
    public NakamaAdminService Admin { get; private set; }

    public Nakama.Client Client {  get; private set; }
    public ISession Session { get; private set; }
    public ISocket Socket { get; private set; }

    public string UserId { get; private set; }

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }
    public void Start()
    {
        var retryConfiguration = new Nakama.RetryConfiguration(baseDelayMs: 1, maxRetries: 5, delegate { Debug.Log("about to retry."); });
        Client = new Nakama.Client(protocol, host, port, serverKey);
        // Configure the retry configuration globally.
        Client.GlobalRetryConfiguration = retryConfiguration;
        Client.Timeout = 15;
    }

    public async Awaitable Auth(string customId)
    {
        Session = await Client.AuthenticateCustomAsync(customId);
        // or
#if UNITY_WEBGL && !UNITY_EDITOR
    ISocketAdapter adapter = new JsWebSocketAdapter();
#else
        ISocketAdapter adapter = new WebSocketAdapter();
#endif
        Socket = Nakama.Socket.From(Client, adapter);
        var account = await Client.GetAccountAsync(Session);
        Debug.Log(account.User.Id);
        UserId = account.User.Id;
        //session.
        //otherTest();
        nakamaAuthenticator.currentAccessToken = Session.AuthToken;
        nakamaAuthenticator.currentUserId = account.User.Id;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
