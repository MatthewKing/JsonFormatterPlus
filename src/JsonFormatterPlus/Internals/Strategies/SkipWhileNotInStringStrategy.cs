namespace JsonFormatterPlus.Internals.Strategies
{
    internal sealed class SkipWhileNotInStringStrategy : ICharacterStrategy
    {
        public char ForWhichCharacter { get; }

        public SkipWhileNotInStringStrategy(char selectionCharacter)
        {
            ForWhichCharacter = selectionCharacter;
        }

        public void Execute(JsonFormatterStrategyContext context)
        {
            if (context.IsProcessingString)
            {
                context.AppendCurrentChar();
            }
        }
    }
}
