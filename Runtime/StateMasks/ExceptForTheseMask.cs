using System;
using System.Collections.Generic;
using System.Linq;

namespace StateMachine.StateMasks
{
    internal class ExceptForTheseMask : StateMask 
    {
        private readonly HashSet<Type> _cannotTransitFrom;
        
        public ExceptForTheseMask(IEnumerable<Type> cannotTransitFrom) => 
            _cannotTransitFrom = new HashSet<Type>(cannotTransitFrom);

        public override bool CanTransitFrom(Type stateType) => 
            !_cannotTransitFrom.Contains(stateType);

        public override string ToString() => 
            $"From any except for: {string.Join(", ", _cannotTransitFrom.Select(n => n.Name))}";
    }
}