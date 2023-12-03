namespace StateMachine
{
    public class StateCompletedCondition : ICondition
    {
        public bool IsMet(StateMachine stateMachine) =>
            stateMachine.CurrentState is ICompletableState { IsCompleted: true };
    }
}