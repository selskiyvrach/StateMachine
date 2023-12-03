using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace StateMachine
{
    public class StateMachine
    {
        private readonly Graph _graph;
        private readonly List<Transition> _transitions = new();
        public IState CurrentState { get; private set; }
        public string Name { get; }
        public bool Enabled { get; private set; }
        public bool GraphValid { get; private set; }

        public StateMachine(string name, Graph graph)
        {
            Name = name;
            _graph = graph;
            GraphValid = _graph.IsValid();
            if (GraphValid) 
                return;
            Debug.LogError($"[{Name}: Invalid graph]");
        }

        public void Enable()
        {            
            if (!GraphValid) 
                return;
            Enabled = true;
            EnterState(_graph.StartState);
        }

        public void Disable()
        {
            if (!GraphValid) 
                return;
            Enabled = false;
        }

        public void Tick(float deltaTime)
        {
            if(!Enabled)
                return;
            CurrentState.Tick(deltaTime);
            EvaluateTransitions();
        }

        private void EnterState(Type stateType)
        {
            if (CurrentState?.GetType() == stateType)
                return;
            var fromState = CurrentState?.GetType();
            CurrentState?.Exit();
            CurrentState = _graph.States[stateType];
            CurrentState.Enter();
            _transitions.Clear();
            _transitions.AddRange(_graph.Transitions.Where(n => n.FromStatesMask.CanTransitFrom(CurrentState.GetType())));
            Debug.Log($"[{Name}] {fromState}->{CurrentState.GetType()}");
        }

        private void EvaluateTransitions()
        {
            var transition = _transitions.FirstOrDefault(n => n.Condition.IsMet(this));
            if(transition is not null)
                EnterState(transition.ToState);
        }
    }
}