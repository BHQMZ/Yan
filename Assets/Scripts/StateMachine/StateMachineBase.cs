using StateMachine.State;

namespace StateMachine
{
    public class StateMachineBase
    {
        private StateBase _currentState;
        private StateBase _previousState;
        private StateBase _globalState;

        public void Update(float deltaTime, float frameCount)
        {
            _currentState?.Update(deltaTime, frameCount);
            _globalState?.Update(deltaTime, frameCount);
        }
        
        public void LateUpdate(float deltaTime, float frameCount)
        {
            _currentState?.LateUpdate(deltaTime, frameCount);
            _globalState?.LateUpdate(deltaTime, frameCount);
        }

        public void ChangeState(StateBase newState)
        {
            _previousState = _currentState;
            _currentState?.Exit();
            _currentState = newState;
            _currentState?.Enter();
        }
        
        public void RevertToPreviousState()
        {
            ChangeState(_previousState);
        }
        
        public void SetGlobalState(StateBase newState)
        {
            _globalState?.Exit();
            _globalState = newState;
            _globalState?.Enter();
        }
    }
}