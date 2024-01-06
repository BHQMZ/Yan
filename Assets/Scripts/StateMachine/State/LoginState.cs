namespace StateMachine.State
{
    public class LoginState : StateBase
    {
        public LoginState(StateMachineBase stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            App.Network.Start();
        }

        public override void Update(float deltaTime, float frameCount)
        {
            if (App.Network.IsConnect)
            {
                _stateMachine.ChangeState(new BattleState(_stateMachine));
            }
        }

        public override void LateUpdate(float deltaTime, float frameCount)
        {
        }

        public override void Exit()
        {
        }
    }
}