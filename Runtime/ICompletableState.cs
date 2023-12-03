namespace StateMachine
{
    public interface ICompletableState
    {
        bool IsCompleted { get; }
    }
}