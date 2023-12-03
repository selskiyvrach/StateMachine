using System.Collections.Generic;
using System.Linq;

namespace StateMachine
{
    public class WhenAllCondition : CompositeCondition
    {
        public WhenAllCondition(IEnumerable<ICondition> children) : base(children)
        {
        }

        public override bool IsMet(StateMachine stateMachine) => 
            Children.All(n => n.IsMet(stateMachine));

        public override string ToString() => 
            $"When all {string.Join(", ", Children.Select(n => n.ToString()))}";
    }
}