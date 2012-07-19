namespace JsonFormatterPlus.Internals.Strategies
{
    internal sealed class SkipWhileNotInStringStrategy : ICharacterStrategy
    {
        private readonly char selectionCharacter;

        public SkipWhileNotInStringStrategy(char selectionCharacter)
        {
            this.selectionCharacter = selectionCharacter;
        }

        public void Execute(JsonFormatterStrategyContext context)
        {
            if (context.IsProcessingString)
            {
                context.AppendCurrentChar();
            }
        }

        public char ForWhichCharacter
        {
            get
            {
                return this.selectionCharacter;
            }
        }
    }
}
