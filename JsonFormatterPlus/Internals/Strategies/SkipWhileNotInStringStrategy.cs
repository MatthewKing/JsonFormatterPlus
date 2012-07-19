namespace JsonFormatterPlus.Internals.Strategies
{
    internal sealed class SkipWhileNotInStringStrategy : ICharacterStrategy
    {
        private readonly char _selectionCharacter;

        public SkipWhileNotInStringStrategy(char selectionCharacter)
        {
            _selectionCharacter = selectionCharacter;
        }

        public void ExecutePrintyPrint(JsonFormatterStrategyContext context)
        {
            if(context.IsProcessingString)
                context.AppendCurrentChar();
        }

        public char ForWhichCharacter
        {
            get
            {
                return _selectionCharacter;
            }
        }
    }
}
