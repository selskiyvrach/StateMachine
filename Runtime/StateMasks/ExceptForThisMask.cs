using System;

namespace StateMachine.StateMasks
{
    internal class ExceptForThisMask : StateMask 
    {
        private readonly Type _cannotTransitFrom;
        
        public ExceptForThisMask(Type cannotTransitFrom) => 
            _cannotTransitFrom = cannotTransitFrom;

        public override bool CanTransitFrom(Type stateType) => 
            _cannotTransitFrom != stateType;
        
        public override string ToString() => 
            $"From any except for: {_cannotTransitFrom.Name}";
    }
}