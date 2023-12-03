using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace StateMachine
{
    public class Graph
    {
        private readonly Dictionary<Type, IState> _states = new();
        private readonly HashSet<Transition> _transitions = new();
        
        public IReadOnlyDictionary<Type, IState> States => _states;
        public IReadOnlyCollection<Transition> Transitions => _transitions;
        public Type StartState { get; set; }
        
        public void AddStates(IEnumerable<IState> states)
        {
            foreach (var state in states) 
                AddState(state);
        }

        public void AddState(IState state)
        {
            var type = state.GetType();
            if (_states.ContainsKey(type))
            {
                Debug.LogError($"[Graph] State [{type}] already exist");
                return;
            }

            _states.Add(type, state);
        }

        public void AddTransition(Transition transition)
        {
            var toState = transition.ToState;
            
            if (!_states.ContainsKey(toState))
            {
                Debug.LogError($"[Graph] Cannot add transition - to state [{toState.Name}] does not exist");
                return;
            }

            if(!_states.Any(n => transition.CanTransitFrom(n.Key)))
            {
                Debug.LogError($"[Graph] Cannot add transition - no state to transition from via mask [{transition.FromStatesMask}]");
                return;
            }
                
            if(!_transitions.Add(transition))
                Debug.LogError($"[Graph] Cannot add transition - to state [{toState}] it already exists");
        }

        public void AddTransitions(IEnumerable<Transition> transitions)
        {
            foreach (var transition in transitions) 
                AddTransition(transition);
        }

        public bool IsValid() => 
            new GraphValidator().IsValid(this);
    }
}