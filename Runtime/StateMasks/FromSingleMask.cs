using System;

namespace StateMachine.StateMasks
{
    internal class FromSingleMask : StateMask
    {
        private readonly Type _stateType;

        public FromSingleMask(Type stateType) => 
            _stateType = stateType;

        public override bool CanTransitFrom(Type stateType) => 
            _stateType == stateType;
        
        public override string ToString() => 
            $"From this: {string.Join(", ", _stateType.Name)}";
    }
}