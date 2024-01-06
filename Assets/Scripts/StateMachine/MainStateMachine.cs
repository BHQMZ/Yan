using StateMachine.State;

namespace StateMachine
{
    public class MainStateMachine : StateMachineBase
    {
        public MainStateMachine()
        {
            // ChangeState(new BattleState(this));
            ChangeState(new LoginState(this));
        }
    }
}