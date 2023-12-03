namespace StateMachine
{
    public class NegateCondition : ICondition
    {
        private readonly ICondition _condition;

        public NegateCondition(ICondition condition) => 
            _condition = condition;

        public bool IsMet(StateMachine stateMachine) => 
            !_condition.IsMet(stateMachine);

        public override string ToString() => 
            $"Not{_condition}";
    }
}