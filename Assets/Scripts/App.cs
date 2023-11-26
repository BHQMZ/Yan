using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nakama;
using UnityEngine;

public class App : MonoBehaviour
{
    public NakamaConnection NakamaConnection;
    
    private readonly Queue<Action> _executionQueue = new Queue<Action>();
    
    private GameApp _gameApp;

    private void Awake()
    {
        DontDestroyOnLoad(this);
 
        // _gameApp = new GameApp();
        // _gameApp.Open();
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
    }
    
    private void OnReceivedMatchPresence(IMatchPresenceEvent matchPresenceEvent)
    {
    }

    private async Task OnReceivedMatchState(IMatchState matchState)
    {
        var userSessionId = matchState.UserPresence.SessionId;
        switch (matchState.OpCode)
        {
            
        }
    }
}
