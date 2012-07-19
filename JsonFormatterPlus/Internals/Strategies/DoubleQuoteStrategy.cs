namespace JsonFormatterPlus.Internals.Strategies
{
    public class DoubleQuoteStrategy : ICharacterStrategy
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
