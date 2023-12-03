namespace StateMachine
{
    public class GraphValidator
    {
        public bool IsValid(Graph graph) => 
            graph.States.ContainsKey(graph.StartState);
    }
}