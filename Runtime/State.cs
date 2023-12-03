namespace StateMachine
{
    public class State : IState
    {
        public virtual void Enter()
        {
        }

        public virtual void Exit()
        {
        }

        public virtual void Tick(float timeDelta)
        {
        }

        public override string ToString() => 
            GetType().Name;
    }
}