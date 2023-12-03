using System;
using System.Collections.Generic;

namespace StateMachine.StateMasks
{
    public abstract class StateMask
    {
        public static StateMask FromAnyExcept(IEnumerable<Type> cannotTransitFrom) => 
            new ExceptForTheseMask(cannotTransitFrom);
        
        public static StateMask FromAnyExcept(params Type[] cannotTransitFrom) => 
            new ExceptForTheseMask(cannotTransitFrom);
        
        public static StateMask FromAnyExcept(Type cannotTransitFrom) => 
            new ExceptForThisMask(cannotTransitFrom);

        public static StateMask FromFollowing(IEnumerable<Type> canTransitFrom) => 
            new FromAnyOfTheseMask(canTransitFrom);
        
        public static StateMask FromFollowing(params Type[] canTransitFrom) => 
            new FromAnyOfTheseMask(canTransitFrom);
        
        public static StateMask FromFollowing(Type canTransitFrom) => 
            new FromSingleMask(canTransitFrom);
        
        public abstract bool CanTransitFrom(Type stateType);
    }
}