using System;
using System.Collections.Generic;
using System.Linq;

namespace StateMachine.StateMasks
{
    internal class FromAnyOfTheseMask : StateMask
    {
        private readonly HashSet<Type> _canTransitFrom;

        public FromAnyOfTheseMask(IEnumerable<Type> canTransitFrom) => 
            _canTransitFrom = new HashSet<Type>(canTransitFrom);

        public override bool CanTransitFrom(Type stateType) => 
            _canTransitFrom.Contains(stateType);
        
        public override string ToString() => 
            $"From any of these: {string.Join(", ", _canTransitFrom.Select(n => n.Name))}";
    }
}