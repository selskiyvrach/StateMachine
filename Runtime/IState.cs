namespace StateMachine
{
    public interface IState
    {
        void Enter();
        void Exit();
        public void Tick(float timeDelta);
    }
}