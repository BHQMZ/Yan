using System;
using System.Collections;
using System.Collections.Generic;
using Nakama;
using Battle;
using Google.Protobuf;
using Action = System.Action;

namespace Manager
{
    public class NetworkManager
    {
        private App _app;
        
        private readonly Queue<Action> _executionQueue;
        private IMatch _currentMatch;
        private bool _isConnect;
        public bool IsConnect => _isConnect;

        public IUserPresence LocalUser;
        public Action<string, IUserPresence> OnSpawnPlayer;
        public Action<string, ProtoPlayerMove> OnVelocityAndPosition;
        public Action<string, ProtoPlayerRelease> OnReleaseSkill;

        public NetworkManager(App app)
        {
            _app = app;
            _executionQueue = new Queue<Action>();
        }

        public void SendMatchState(long opCode, byte[] state)
        {
            _app.NakamaConnection.Socket.SendMatchStateAsync(_currentMatch.Id, opCode, state);
        }

        public async void Start()
        {
            await _app.NakamaConnection.Connect();
            
            _app.NakamaConnection.Socket.ReceivedMatchmakerMatched += m => Enqueue(() => OnReceivedMatchmakerMatched(m));
            _app.NakamaConnection.Socket.ReceivedMatchPresence += m => Enqueue(() => OnReceivedMatchPresence(m));
            _app.NakamaConnection.Socket.ReceivedMatchState += m => Enqueue(() => OnReceivedMatchState(m));

            _isConnect = true;
            
            await _app.NakamaConnection.FindMatch();
        }

        public void Update()
        {
            UpdateExecution();
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
                    _app.StartCoroutine(action);
                });
            }
        }

        private void Enqueue(Action action)
        {
            Enqueue(ActionWrapper(action));
        }

        private IEnumerator ActionWrapper(Action a)
        {
            a();
            yield return null;
        }

        private async void OnReceivedMatchmakerMatched(IMatchmakerMatched matched)
        {
            LocalUser = matched.Self.Presence;
            
            var match = await _app.NakamaConnection.Socket.JoinMatchAsync(matched);
    
            foreach (var user in match.Presences)
            {
                OnSpawnPlayer(match.Id, user);
            }
    
            _currentMatch = match;
        }

        private void OnReceivedMatchPresence(IMatchPresenceEvent matchPresenceEvent)
        {
            foreach (var user in matchPresenceEvent.Joins)
            {
                OnSpawnPlayer(matchPresenceEvent.MatchId, user);
            }
        }

        private void OnReceivedMatchState(IMatchState matchState)
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
    }
}