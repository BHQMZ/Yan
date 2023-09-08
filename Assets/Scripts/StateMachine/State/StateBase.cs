namespace StateMachine.State
{
    public abstract class StateBase
    {
        protected StateMachineBase _stateMachine;
        
        public StateBase(StateMachineBase stateMachine)
        {
            _stateMachine = stateMachine;
        }
        
        public abstract void Enter();

        public abstract void Update(float deltaTime, float frameCount);
        
        public abstract void LateUpdate(float deltaTime, float frameCount);

        public abstract void Exit();
    }
}