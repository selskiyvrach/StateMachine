namespace StateMachine
{
    public interface ICondition
    {
        bool IsMet(StateMachine stateMachine);
    }
}