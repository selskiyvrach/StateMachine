using System;
using System.Collections.Generic;
using StateMachine.StateMasks;

namespace StateMachine
{
    public sealed class Transition
    {
        public StateMask FromStatesMask {get; }
        public Type ToState {get; }
        public ICondition Condition { get; }

        public Transition(Type from, Type to, ICondition condition) : this(StateMask.FromFollowing(from), to, condition) {}

        public Transition(IEnumerable<Type> fromStates, Type to, ICondition condition) : this(StateMask.FromFollowing(fromStates), to, condition) {}

        public Transition(StateMask stateMaskMask, Type to, ICondition condition) : this (to, condition) => 
            FromStatesMask = stateMaskMask;

        private Transition(Type toState, ICondition condition)
        {
            ToState = toState;
            Condition = condition;
        }

        public bool CanTransitFrom(Type type) => 
            FromStatesMask.CanTransitFrom(type);
    }
}