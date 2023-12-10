using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Battle;
using Google.Protobuf;
using Nakama;
using UnityEngine;
using Action = System.Action;

public class App : MonoBehaviour
{
    public NakamaConnection NakamaConnection;
    
    private readonly Queue<Action> _executionQueue = new Queue<Action>();
    
    private GameApp _gameApp;

    public IUserPresence LocalUser;
    public Action<string, IUserPresence> OnSpawnPlayer;
    public Action<string, ProtoPlayerMove> OnVelocityAndPosition;
    public Action<string, ProtoPlayerRelease> OnReleaseSkill;
    
    private IMatch currentMatch;

    public static App Instance;

    private void Awake()
    {
        DontDestroyOnLoad(this);

        Instance = this;
 
        _gameApp = new GameApp();
        _gameApp.Open();
    }

    private void Update()
    {
        UpdateExecution();
        _gameApp?.Update(Time.deltaTime, Time.frameCount);
    }

    private void LateUpdate()
    {
        _gameApp?.LateUpdate(Time.deltaTime, Time.frameCount);
    }

    private void OnDestroy()
    {
        _gameApp?.Destroy();
    }

    private void UpdateExecution()
    {
        lock(_executionQueue) {
            while (_executionQueue.Count > 0) {
                _executionQueue.Dequeue().Invoke();
            }
        }
    }
    
    private void Enqueue(IEnumerator action) {
        lock (_executionQueue) {
            _executionQueue.Enqueue(() => {
                StartCoroutine(action);
            });
        }
    }
    
    private void Enqueue(Action action)
    {
        Enqueue(ActionWrapper(action));
    }
    
    IEnumerator ActionWrapper(Action a)
    {
        a();
        yield return null;
    }


    private async void Start()
    {
        await NakamaConnection.Connect();
        
        NakamaConnection.Socket.ReceivedMatchmakerMatched += m => Enqueue(() => OnReceivedMatchmakerMatched(m));
        NakamaConnection.Socket.ReceivedMatchPresence += m => Enqueue(() => OnReceivedMatchPresence(m));
        NakamaConnection.Socket.ReceivedMatchState += m => Enqueue(async () => await OnReceivedMatchState(m));
        
        await NakamaConnection.FindMatch();
    }
    
    private async void OnReceivedMatchmakerMatched(IMatchmakerMatched matched)
    {
        LocalUser = matched.Self.Presence;
        
        var match = await NakamaConnection.Socket.JoinMatchAsync(matched);

        foreach (var user in match.Presences)
        {
            OnSpawnPlayer(match.Id, user);
        }

        currentMatch = match;
    }
    
    private void OnReceivedMatchPresence(IMatchPresenceEvent matchPresenceEvent)
    {
        foreach (var user in matchPresenceEvent.Joins)
        {
            OnSpawnPlayer(matchPresenceEvent.MatchId, user);
        }
    }

    private async Task OnReceivedMatchState(IMatchState matchState)
    {
        var userSessionId = matchState.UserPresence.SessionId;
        switch (matchState.OpCode)
        {
            case OpCodes.VelocityAndPosition:
                var move = new ProtoPlayerMove();
                
                move.MergeFrom(matchState.State);
                OnVelocityAndPosition(userSessionId, move);
                return;
            case OpCodes.Input:
                var release = new ProtoPlayerRelease();
                
                release.MergeFrom(matchState.State);
                OnReleaseSkill(userSessionId, release);
                return;
        }
    }

    public void SendMatchState(long opCode, byte[] state)
    {
        NakamaConnection.Socket.SendMatchStateAsync(currentMatch.Id, opCode, state);
    }
}
