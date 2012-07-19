namespace JsonFormatterPlus.Internals.Strategies
{
    internal sealed class DoubleQuoteStrategy : ICharacterStrategy
    {
        public void ExecutePrintyPrint(JsonFormatterStrategyContext context)
        {
            if (!context.IsProcessingSingleQuoteInitiatedString && !context.WasLastCharacterABackSlash)
                context.IsProcessingDoubleQuoteInitiatedString = !context.IsProcessingDoubleQuoteInitiatedString;

            context.AppendCurrentChar();
        }

        public char ForWhichCharacter
        {
            get { return '"'; }
        }
    }
}
