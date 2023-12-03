namespace StateMachine
{
    public static class ConditionExtensions
    {
        public static ICondition And(this ICondition condition1, ICondition condition2) =>
            new WhenAllCondition(new []{ condition1, condition2 });

        public static ICondition Negate(this ICondition condition) => 
            new NegateCondition(condition);
    }
}