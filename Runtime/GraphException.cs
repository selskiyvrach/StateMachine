using System;

namespace StateMachine
{
    public class GraphException : Exception
    {
        public GraphException(string message) : base(message)
        {
        }
    }
}