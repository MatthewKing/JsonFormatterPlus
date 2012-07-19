namespace JsonFormatterPlus.Internals.Strategies
{
    public class SingleQuoteStrategy : ICharacterStrategy
    {
        public void ExecutePrintyPrint(JsonFormatterStrategyContext context)
        {
            if (!context.IsProcessingDoubleQuoteInitiatedString && !context.WasLastCharacterABackSlash)
                context.IsProcessingSingleQuoteInitiatedString = !context.IsProcessingSingleQuoteInitiatedString;

            context.AppendCurrentChar();
        }

        public char ForWhichCharacter
        {
            get { return '\''; }
        }
    }
}