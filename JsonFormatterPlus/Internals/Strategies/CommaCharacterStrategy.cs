namespace JsonFormatterPlus.Internals.Strategies
{
    internal sealed class CommaStrategy : ICharacterStrategy
    {
        public void Execute(JsonFormatterStrategyContext context)
        {
            context.AppendCurrentChar();

            if (context.IsProcessingString)
            {
                return;
            }

            context.BuildContextIndents();
            context.IsProcessingVariableAssignment = false;
        }

        public char ForWhichCharacter
        {
            get { return ','; }
        }
    }
}
