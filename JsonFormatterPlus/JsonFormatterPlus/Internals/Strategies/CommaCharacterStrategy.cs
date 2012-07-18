namespace JsonFormatterPlus.Internals.Strategies
{
    public class CommaStrategy : ICharacterStrategy
    {
        public void ExecutePrintyPrint(JsonFormatterStrategyContext context)
        {
            context.AppendCurrentChar();

            if (context.IsProcessingString) return;

            context.BuildContextIndents();
            context.IsProcessingVariableAssignment = false;
        }

        public char ForWhichCharacter
        {
            get { return ','; }
        }
    }
}
