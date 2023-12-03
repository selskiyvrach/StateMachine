using System.Collections.Generic;
using System.Linq;

namespace StateMachine
{
    public class WhenAnyCondition : CompositeCondition
    {
        public WhenAnyCondition(IEnumerable<ICondition> children) : base(children)
        {
        }

        public override bool IsMet(StateMachine stateMachine) => 
            Children.Any(n => n.IsMet(stateMachine));
        
        public override string ToString() => 
            $"When any {string.Join(", ", Children.Select(n => n.ToString()))}";
    }
}