namespace JsonFormatterPlus.Internals.Strategies
{
    internal sealed class ColonCharacterStrategy : ICharacterStrategy
    {
        public char ForWhichCharacter => ':';

        public void Execute(JsonFormatterStrategyContext context)
        {
            if (context.IsProcessingString)
            {
                context.AppendCurrentChar();
                return;
            }

            context.IsProcessingVariableAssignment = true;
            context.AppendCurrentChar();
            context.AppendSpace();
        }
    }
}
