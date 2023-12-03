using System.Collections.Generic;

namespace StateMachine
{
    public abstract class CompositeCondition : ICondition
    {
        protected readonly HashSet<ICondition> Children;

        protected CompositeCondition(IEnumerable<ICondition> children) => 
            Children = new HashSet<ICondition>(children);

        public abstract bool IsMet(StateMachine stateMachine);
    }
}